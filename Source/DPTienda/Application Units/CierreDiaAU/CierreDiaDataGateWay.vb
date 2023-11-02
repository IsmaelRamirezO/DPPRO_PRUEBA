Option Explicit On 

Imports System.Data.SqlClient
Imports DportenisPro.DPTienda.ApplicationUnits.CierreDiaAU.wsPSug
Imports System.IO
Imports System.Collections.Generic
Imports DportenisPro.DPTienda.ApplicationUnits.ValeCaja

Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU
Imports DportenisPro.DPTienda.ApplicationUnits.Facturas
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoTipoVenta
Imports DportenisPro.DPTienda.ApplicationUnits.ContratosAU
Imports DportenisPro.DPTienda.ApplicationUnits.AbonosApartadosAU
Imports DportenisPro.DPTienda.ApplicationUnits.CancelacionAbonoAU
Imports DportenisPro.DPTienda.ApplicationUnits.DistribucionNC
Imports DportenisPro.DPTienda.ApplicationUnits.NotasCreditoAU
Imports DportenisPro.DPTienda.ApplicationUnits.Asociados
Imports DportenisPro.DPTienda.ApplicationUnits.AjusteGeneralTalla
Imports DportenisPro.DPTienda.ApplicationUnits.FingerPrintAU



Public Class CierreDiaDataGateWay

    Private oParent As CierreDiaManager

    Dim oDPVale As cDPVale
    Dim oProcesosSAPMgr As ProcesoSAPManager

#Region "Constructors / Destructors"

    Public Sub New(ByVal Parent As CierreDiaManager)

        oParent = Parent
        oSAPMgr = New ProcesoSAPManager(oParent.ApplicationContext, oParent.SAPApplicationConfig)
        oSAPMgr.ConfigCierreFI = oParent.ConfigSaveArchivos
        'Creamos Nuestro Objeto Articulo
        oCatalogoArticuloMgr = New CatalogoArticuloManager(oParent.ApplicationContext)
        oArticulo = oCatalogoArticuloMgr.Create

        oFacturaMgr = New FacturaManager(oParent.ApplicationContext)

        'Creamos objeto Contrato Manager
        oContratoMngr = New ContratoManager(oParent.ApplicationContext)

        'Creamos objeto Abonos Aportados
        oAbonosApartadosMgr = New AbonosApartadosManager(oParent.ApplicationContext)

        'Creamos objeto Cancelar Abonos
        oCancelaAbonosMgr = New CancelacionAbonoManager(oParent.ApplicationContext)

        'Creamos objeto Distribucion
        oDistribucionNCMgr = New DistribucionNCManager(oParent.ApplicationContext)

        'Creamos objeto NotaCredito
        oNotaCreditoMgr = New NotasCreditoManager(oParent.ApplicationContext, oParent.SAPApplicationConfig, oParent.ConfigSaveArchivos)

        'Creamos objeto AjusteTalla
        oAjusteMgr = New AjusteGeneralTallaManager(oParent.ApplicationContext)

    End Sub

#End Region

#Region "Methods"

    Public Sub Insert(ByVal pCierreDia As CierreDia)

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                                 DataStorageConfiguration.GetConnectionString)

        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand

        Dim datFechaCierre As Date
        'Dim datFechaCierreTEST As Date

        Dim intReturnValue As Integer



        datFechaCierre = Format(pCierreDia.Fecha, "Short Date")
        'datFechaCierre = pCierreDia.Fecha
        'datFechaCierreTEST = Format(pCierreDia.Fecha, "Short Date")

        With sccmdInsert

            .Connection = sccnnConnection

            .CommandText = "[CierreDiaIns]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@InicioDiaID", System.Data.SqlDbType.Int))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Faltante", System.Data.SqlDbType.Decimal))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Sobrante", System.Data.SqlDbType.Decimal))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Impreso", System.Data.SqlDbType.Bit))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Usuario", System.Data.SqlDbType.VarChar, 12))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@StatusRegistro", System.Data.SqlDbType.Bit))


            'Out Put :
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CierreDiaID", System.Data.SqlDbType.Int))
            .Parameters("@CierreDiaID").Direction = ParameterDirection.Output

        End With

        Try

            sccnnConnection.Open()

            With sccmdInsert

                'Assign Parameters Values
                .Parameters("@InicioDiaID").Value = ExtraerInicioDiaID(datFechaCierre)
                .Parameters("@Faltante").Value = CalcularTotalFaltante(datFechaCierre)
                .Parameters("@Sobrante").Value = CalcularTotalSobrante(datFechaCierre)
                .Parameters("@Impreso").Value = 1
                .Parameters("@Usuario").Value = pCierreDia.Usuario
                .Parameters("@Fecha").Value = datFechaCierre
                .Parameters("@StatusRegistro").Value = 1

                'Execute Command
                .ExecuteNonQuery()

                intReturnValue = .Parameters("@CierreDiaID").Value

            End With

            'Reset New State of Linea Object 
            pCierreDia.ResetFlagNew()
            pCierreDia.ResetFlagDirty()

            sccnnConnection.Close()


            'Crear Archivo Psug :

            'PsugIns(Format(datFechaCierre, "Short Date"))
            'PsugIns(datFechaCierre)

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

    Public Function SelectFecha(ByVal Fecha As Date) As CierreDia

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader
        Dim oCierreDia As CierreDia

        oCierreDia = oParent.Create

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[CierreDiaSelFecha]"
            .CommandType = System.Data.CommandType.StoredProcedure

            '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodBanco", System.Data.SqlDbType.VarChar, 4))

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime, 8))

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
                        oCierreDia.Fecha = .GetDateTime(5)

                        'Reset New State of Linea Object 
                        oCierreDia.ResetFlagNew()
                        oCierreDia.ResetFlagDirty()

                    End With

                Else
                    oCierreDia = Nothing
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

        'If (oCierreDia Is Nothing) Then
        'Throw New ApplicationException("El registro no pudo ser leido debido a que el ID de Banco no existe.")
        'End If

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return oCierreDia

    End Function

    Public Function ValidaCobranza(ByVal Fecha As DateTime) As Boolean

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader
        Dim Valida As Boolean

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[CierreDiaValidaCobranza]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New SqlParameter("@Fecha", SqlDbType.DateTime, 8))

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

                    Valida = False

                Else

                    Valida = True

                End If

            End With

            scdrReader.Close()
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

        'If (oCierreDia Is Nothing) Then
        'Throw New ApplicationException("El registro no pudo ser leido debido a que el ID de Banco no existe.")
        'End If

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return Valida

    End Function

    Public Function ValidarCierreDia(ByVal FechaCierreUser As Date) As Boolean

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        Dim bolReturnValue As Boolean



        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[CierreDiaValidarCierreDia]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime))

        End With


        Try

            sccnnConnection.Open()

            With sccmdSelect

                'Assign Parameters Values
                .Parameters("@Fecha").Value = Format(FechaCierreUser, "Short Date")  'Date.Now

                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    scdrReader.Close()
                    sccnnConnection.Close()

                    bolReturnValue = False

                Else

                    bolReturnValue = True

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

        Return bolReturnValue

    End Function

    Public Function ValidarCierreDiaImpresion(ByVal FechaCierreUser As Date) As Boolean

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        Dim dsDataSet As DataSet
        dsDataSet = New DataSet

        Dim bolReturnValue As Boolean



        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[CierreDiaValidarCierreDiaImpresion]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime))

        End With


        Try

            sccnnConnection.Open()

            With sccmdSelect
                'Assign Parameters Values
                '.Parameters("@Fecha").Value = Format(DateAdd(DateInterval.Day, -1, FechaCierreUser), "Short Date")   'Date.Now

                .Parameters("@Fecha").Value = Format(DateAdd(DateInterval.Day, -1, FechaCierreUser), "Short Date")

                'DateAdd(DateInterval.Day, -1, FechaCierreUser)

                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If Not (scdrReader.HasRows) Then

                    scdrReader.Close()
                    sccnnConnection.Close()

                    bolReturnValue = True

                Else


                    If scdrReader.GetBoolean(scdrReader.GetOrdinal("Impreso")) Then

                        bolReturnValue = True

                    Else

                        bolReturnValue = False

                    End If




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

        Return bolReturnValue

    End Function

    Public Function ValidarCajasCerradas(ByVal FechaCierreUser As Date) As Boolean

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        Dim bolReturnValue As Boolean



        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[CierreDiaValidarCajasCerradas]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime))

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TotalCajas", System.Data.SqlDbType.Int))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TotalCajasCerradas", System.Data.SqlDbType.Int))


            'Out Put :
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ReturnValue", System.Data.SqlDbType.Int))
            .Parameters("@ReturnValue").Direction = ParameterDirection.Output

        End With


        Try

            sccnnConnection.Open()

            With sccmdSelect

                'Assign Parameters Values
                .Parameters("@Fecha").Value = Format(FechaCierreUser, "Short Date")  'Date.Now
                .Parameters("@TotalCajas").Value = 0
                .Parameters("@TotalCajasCerradas").Value = 0
                .Parameters("@ReturnValue").Value = 0


                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    With scdrReader

                        'If (.GetBoolean(0) = True) Then
                        If (.GetInt32(0) = 1) Then

                            bolReturnValue = True

                            scdrReader.Close()
                            sccnnConnection.Close()

                        Else

                            bolReturnValue = False

                            scdrReader.Close()
                            sccnnConnection.Close()

                        End If

                    End With

                Else

                    bolReturnValue = False

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

        Return bolReturnValue

    End Function

    Public Function ExtraerInicioDiaID(ByVal FechaCierre As Date) As Integer

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        Dim intInicioCajaID As Integer


        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[CierreDiaExtraerInicioDiaID]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime))

            'OutPut :
            '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@InicioDiaID", System.Data.SqlDbType.Int))
            '.Parameters("@InicioDiaID").Direction = ParameterDirection.Output

        End With


        Try

            sccnnConnection.Open()

            With sccmdSelect

                'Assign Parameters Values
                .Parameters("@CodAlmacen").Value = oParent.ApplicationContext.ApplicationConfiguration.Almacen
                .Parameters("@Fecha").Value = Format(FechaCierre, "Short Date")
                '.Parameters("@InicioDiaID").Value = 0

                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    With scdrReader

                        intInicioCajaID = .GetInt32(0)

                    End With

                Else

                    scdrReader.Close()
                    sccnnConnection.Close()

                    intInicioCajaID = 0

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


        Return intInicioCajaID

    End Function

    Private Function CalcularTotalSobrante(ByVal FechaCierreDia As Date) As Decimal

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        Dim decTotalSobrante As Decimal


        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[CierreDiaTotalSobrante]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime))

            'OutPut :
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TotalSobrante", System.Data.SqlDbType.Decimal))
            .Parameters("@TotalSobrante").Direction = ParameterDirection.Output

        End With


        Try

            sccnnConnection.Open()

            With sccmdSelect

                'Assign Parameters Values
                .Parameters("@Fecha").Value = Format(FechaCierreDia, "Short Date")
                .Parameters("@TotalSobrante").Value = 0

                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    With scdrReader

                        decTotalSobrante = .GetDecimal(0)

                    End With

                Else

                    scdrReader.Close()
                    sccnnConnection.Close()

                    decTotalSobrante = 0

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


        Return decTotalSobrante

    End Function

    Private Function CalcularTotalFaltante(ByVal FechaCierreDia As Date) As Decimal

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                                DataStorageConfiguration.GetConnectionString)


        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        Dim decTotalSobrante As Decimal


        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[CierreDiaTotalFaltante]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime))

            'OutPut :
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TotalFaltante", System.Data.SqlDbType.Decimal))
            .Parameters("@TotalFaltante").Direction = ParameterDirection.Output

        End With


        Try

            sccnnConnection.Open()

            With sccmdSelect

                'Assign Parameters Values
                .Parameters("@Fecha").Value = Format(FechaCierreDia, "Short Date")
                .Parameters("@TotalFaltante").Value = 0

                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    With scdrReader

                        decTotalSobrante = .GetDecimal(0)

                    End With

                Else

                    scdrReader.Close()
                    sccnnConnection.Close()

                    decTotalSobrante = 0

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


        Return decTotalSobrante

    End Function

    Public Function GetReporteVentasGeneral(ByVal FechaCierre As Date) As DataSet

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim scReporteInventarioAdapter As New SqlDataAdapter
        Dim scRepVentasGeneral As New SqlCommand
        Dim dsResult As DataSet
        Dim dsFormatedResult As DataSet

        scReporteInventarioAdapter.SelectCommand = scRepVentasGeneral

        With scRepVentasGeneral

            .CommandText = "[RepVentasGeneral]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Connection = sccnnConnection

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaInicial", System.Data.SqlDbType.DateTime, 8))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaFinal", System.Data.SqlDbType.DateTime, 8))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar, 2))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 3))

            .Parameters("@CodAlmacen").Value = oParent.ApplicationContext.ApplicationConfiguration.Almacen    'Almacen
            .Parameters("@CodCaja").Value = oParent.ApplicationContext.ApplicationConfiguration.NoCaja  'Codcaja
            .Parameters("@FechaInicial").Value = FechaCierre
            .Parameters("@FechaFinal").Value = FechaCierre

        End With

        Try

            sccnnConnection.Open()

            dsResult = New DataSet
            dsFormatedResult = New DataSet

            scReporteInventarioAdapter.Fill(dsResult)

            If (dsResult.Tables(0).Rows.Count > 0) Then

                dsFormatedResult = FormatDataSetGeneral(dsResult)

            Else

                dsFormatedResult = Nothing

            End If

        Catch ex As Exception

            Throw ex

        Finally

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

        End Try

        Return dsFormatedResult

    End Function

    Private Function FormatDataSetGeneral(ByVal Source As DataSet) As DataSet

        Dim dsTarget As New DataSet("ReporteVentas")
        Dim dtMainTable As New DataTable("ReporteVentas")

        'Columna: Folio
        Dim dcFolio As DataColumn = New DataColumn
        With dcFolio
            .DataType = System.Type.GetType("System.String")
            .Caption = "Folio"
            .ColumnName = "Folio"
        End With
        dtMainTable.Columns.Add(dcFolio)

        'Columna: Total de Artículos
        Dim dcTotalArticulos As DataColumn = New DataColumn
        With dcTotalArticulos
            .DataType = System.Type.GetType("System.Decimal")
            .Caption = "Total Articulos"
            .ColumnName = "TotalArticulos"
            '.DefaultValue = 25
        End With
        dtMainTable.Columns.Add(dcTotalArticulos)

        'Columna: Importe
        Dim dcImporte As DataColumn = New DataColumn
        With dcImporte
            .DataType = System.Type.GetType("System.Decimal")
            .Caption = "Importe"
            .ColumnName = "Importe"
            '.DefaultValue = 25
        End With
        dtMainTable.Columns.Add(dcImporte)

        'Columna: Descuento
        Dim dcDescuento As DataColumn = New DataColumn
        With dcDescuento
            .DataType = System.Type.GetType("System.String")
            .Caption = "Descuento"
            .ColumnName = "Descuento"
            '.DefaultValue = 25
        End With
        dtMainTable.Columns.Add(dcDescuento)

        'Columna: Formas de Pago
        Dim dcFormaPago As DataColumn
        Dim intFormaPago As Integer
        For intFormaPago = 1 To 10
            dcFormaPago = New DataColumn
            With dcFormaPago
                .DataType = System.Type.GetType("System.String")
                .Caption = "Forma de Pago" & intFormaPago.ToString("00")
                .ColumnName = "FormaPago" & intFormaPago.ToString("00")
            End With
            dtMainTable.Columns.Add(dcFormaPago)

        Next

        'Columna: Pago
        Dim dcPago As DataColumn
        Dim intPago As Integer
        For intPago = 1 To 10
            dcPago = New DataColumn
            With dcPago
                .DataType = System.Type.GetType("System.Decimal")
                .Caption = "Pago" & intPago.ToString("00")
                .ColumnName = "Pago" & intPago.ToString("00")
            End With
            dtMainTable.Columns.Add(dcPago)

        Next

        'Columna: Vendedor
        Dim dcVendedor As DataColumn = New DataColumn
        With dcVendedor
            .DataType = System.Type.GetType("System.String")
            .Caption = "Vendedor"
            .ColumnName = "Vendedor"
            '.DefaultValue = 25
        End With
        dtMainTable.Columns.Add(dcVendedor)

        'Columna: Cliente
        Dim dcCliente As DataColumn = New DataColumn
        With dcCliente
            .DataType = System.Type.GetType("System.String")
            .Caption = "Cliente"
            .ColumnName = "Cliente"
            '.DefaultValue = 25
        End With
        dtMainTable.Columns.Add(dcCliente)

        'Columna: Tipo de Venta
        Dim dcTipoVenta As DataColumn = New DataColumn
        With dcTipoVenta
            .DataType = System.Type.GetType("System.String")
            .Caption = "Tipo de Venta"
            .ColumnName = "TipoVenta"
            '.DefaultValue = 25
        End With
        dtMainTable.Columns.Add(dcTipoVenta)

        'Columna: Nota de Crédito
        Dim dcNCred As DataColumn = New DataColumn
        With dcNCred
            .DataType = System.Type.GetType("System.String")
            .Caption = "Nota de Credito"
            .ColumnName = "NCred"
            '.DefaultValue = 25
        End With
        dtMainTable.Columns.Add(dcNCred)

        'Columna: Status
        Dim dcStatus As DataColumn = New DataColumn
        With dcStatus
            .DataType = System.Type.GetType("System.String")
            .Caption = "Status"
            .ColumnName = "Status"
            '.DefaultValue = 25
        End With
        dtMainTable.Columns.Add(dcStatus)

        'Columna: Total de Registros
        Dim dcTotalRegistros As DataColumn = New DataColumn
        With dcTotalRegistros
            .DataType = System.Type.GetType("System.String")
            .Caption = "Total de Registros"
            .ColumnName = "TotalRegistros"
            '.DefaultValue = 25
        End With
        dtMainTable.Columns.Add(dcTotalRegistros)

        dsTarget.Tables.Add(dtMainTable)

        Dim oSourceRow As DataRow
        Dim oTargetSource As DataRow

        Dim strFolio As String
        Dim intColFormaPago As Integer
        Dim intColTotalRegistros As Integer
        Dim TotalImporte As Decimal
        Dim TotalResult As Decimal


        For Each oSourceRow In Source.Tables(0).Rows

            If (strFolio <> oSourceRow.Item(0).ToString) Then

                If (Not oTargetSource Is Nothing) Then

                    dtMainTable.Rows.Add(oTargetSource)

                End If

                strFolio = oSourceRow.Item(0).ToString
                oTargetSource = dtMainTable.NewRow()

                oTargetSource("Folio") = strFolio
                oTargetSource("TotalArticulos") = oSourceRow.Item(1).ToString
                oTargetSource("Importe") = oSourceRow.Item(2).ToString
                oTargetSource("Descuento") = oSourceRow.Item(3).ToString
                oTargetSource("Vendedor") = oSourceRow.Item(4).ToString
                oTargetSource("Cliente") = oSourceRow.Item(5).ToString
                oTargetSource("TipoVenta") = oSourceRow.Item(6).ToString
                'oTargetSource("NCred") = oSourceRow.Item(7).ToString
                oTargetSource("Status") = oSourceRow.Item(7).ToString
                intColFormaPago = 1
                intColTotalRegistros += 1
                TotalImporte = CType(oSourceRow("Total"), Decimal)
                TotalResult += TotalImporte

            End If

            oTargetSource("FormaPago" & intColFormaPago.ToString("00")) = oSourceRow.Item(9).ToString
            oTargetSource("Pago" & intColFormaPago.ToString("00")) = oSourceRow("MontoPago")

            intColFormaPago += 1


        Next

        If (Not oTargetSource Is Nothing) Then

            dtMainTable.Rows.Add(oTargetSource)

        End If


        oTargetSource = dtMainTable.NewRow()
        oTargetSource("Importe") = TotalResult
        oTargetSource("Folio") = "IMPORTE TOTAL"
        oTargetSource("TotalRegistros") = intColTotalRegistros
        dtMainTable.Rows.Add(oTargetSource)

        If (oTargetSource("TotalRegistros") = 0) Then

            MsgBox("Los datos proporcionados no produjeron resultados.", MsgBoxStyle.Exclamation)

        End If

        dtMainTable.AcceptChanges()

        Return dsTarget

    End Function

    Private Function CreatFilePsuc(ByVal datFecha As Date) As DataSet

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaPsuc As SqlDataAdapter
        Dim dsPsuc As DataSet

        sccmdSelectAll = New SqlCommand
        scdaPsuc = New SqlDataAdapter
        dsPsuc = New DataSet("Psuc")

        With sccmdSelectAll

            .Connection = sccnnConnection

            .CommandText = "[PsucCreatFile]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime))

        End With

        scdaPsuc.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            scdaPsuc.SelectCommand.Parameters("@Fecha").Value = datFecha

            'Fill DataSet
            scdaPsuc.Fill(dsPsuc, "Psuc")

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

        Return dsPsuc

    End Function

    Private Sub PsugIns(ByVal datFecha As Date)

        Dim dsFilePsug As DataSet

        'Crear Archivo Pedido Sugerido [PSug].
        dsFilePsug = CreatFilePsuc(datFecha)

        If (dsFilePsug.Tables(0).Rows.Count = 0) Then
            Return
        End If


        'Dim owsPSug As New wsPSug.PedidoSugerido("http://ws.dpportal.com.mx/Credito/PedidoSugerido.asmx")
        'Dim owsPSug As New wsPSug.PedidoSugerido


        If Not oParent.ApplicationContext.ApplicationConfiguration.WSUrl = String.Empty Then

            'owsPSug.Url = oParent.ApplicationContext.ApplicationConfiguration.WSUrl.TrimEnd("/") + "/" + _
            'owsPSug.strURL

        End If

        'owsPSug.PSucIns(dsFilePsug, oParent.ApplicationContext.Security.CurrentUser.Name)
        'datFecha = (Format(datFecha, "General Date"))

        'owsPSug.Insert(dsFilePsug, oParent.ApplicationContext.Security.CurrentUser.Name, DateAdd(DateInterval.Day, 1, datFecha))

        datFecha = CDate(Format(datFecha, "dd/MM/yyyy") & " 13:00:00")

        'owsPSug.Insert(dsFilePsug, oParent.ApplicationContext.Security.CurrentUser.Name, datFecha)

        'owsPSug.Dispose()
        'owsPSug = Nothing

    End Sub

    Public Function ValidarReporteNotasCredito(ByVal datFechaCierre As Date) As Boolean

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdDataSet As SqlCommand
        Dim scdaDataSet As SqlDataAdapter
        Dim dsNotasCredito As New DataSet


        sccmdDataSet = New SqlCommand
        scdaDataSet = New SqlDataAdapter

        Dim bolReturnValue As Boolean


        With sccmdDataSet

            .Connection = sccnnConnection

            .CommandText = "[CierreDiaReporteNotasCredito]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime))


        End With

        scdaDataSet.SelectCommand = sccmdDataSet

        Try
            With sccmdDataSet

                sccnnConnection.Open()

                .Parameters("@Fecha").Value = Format(datFechaCierre, "Short Date")

                'Fill DataSet
                scdaDataSet.Fill(dsNotasCredito, "NotasCredito")

                If (dsNotasCredito.Tables("NotasCredito").Rows.Count > 0) Then
                    bolReturnValue = True
                End If

                sccnnConnection.Close()

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

        Return bolReturnValue

    End Function

    Public Function ValidarReporteCancelacionApartados(ByVal datFechaCierre As Date) As Boolean

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdDataSet As SqlCommand
        Dim scdaDataSet As SqlDataAdapter
        Dim dsApartados As New DataSet

        Dim bolReturnValue As Boolean

        sccmdDataSet = New SqlCommand
        scdaDataSet = New SqlDataAdapter


        With sccmdDataSet

            .Connection = sccnnConnection

            .CommandText = "[CierreDiaReporteCancelacionApartados]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime))


        End With

        scdaDataSet.SelectCommand = sccmdDataSet

        Try
            With sccmdDataSet

                sccnnConnection.Open()

                .Parameters("@Fecha").Value = Format(datFechaCierre, "Short Date")

                'Fill DataSet
                scdaDataSet.Fill(dsApartados, "Apartados")

                If (dsApartados.Tables("Apartados").Rows.Count > 0) Then
                    bolReturnValue = True
                End If

                sccnnConnection.Close()

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

        Return bolReturnValue

    End Function


    Public Sub CierreAnio(ByVal intAnio As Integer)

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdCierreAnio As SqlCommand
        Dim scdaCierreAnio As SqlDataAdapter

        Dim bolReturnValue As Boolean

        sccmdCierreAnio = New SqlCommand
        scdaCierreAnio = New SqlDataAdapter


        With sccmdCierreAnio

            .Connection = sccnnConnection

            .CommandText = "[CierredeAnioProcesoSel]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Anio", System.Data.SqlDbType.Int, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Usuario", System.Data.SqlDbType.VarChar))

        End With

        scdaCierreAnio.SelectCommand = sccmdCierreAnio

        Try

            With sccmdCierreAnio

                sccnnConnection.Open()

                .Parameters("@Anio").Value = intAnio
                .Parameters("@Usuario").Value = oParent.ApplicationContext.Security.CurrentUser.Name

                .ExecuteNonQuery()

                sccnnConnection.Close()

            End With

        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("No se completo proceso de Cierre de Año. Error de Base de Datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("No se completo proceso de Cierre de Año. Error de Aplicación.", ex)

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

    End Sub

    Public Sub PreciosArticulosDelAll()

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                                 DataStorageConfiguration.GetConnectionString)

        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand
        '-----------------------------------------------------------------------------------------------------------------------
        'FLIZARRAGA 09/04/2016: Se le agrega el timeout configurable se incremento para terminar de eliminar los registros de mas
        '-----------------------------------------------------------------------------------------------------------------------
        sccmdInsert.CommandTimeout = oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration.ConnectionTimeout
        With sccmdInsert

            .Connection = sccnnConnection

            .CommandText = "[CierreDiaUpdPreciosAll]"
            .CommandType = System.Data.CommandType.StoredProcedure

            '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@InicioDiaID", System.Data.SqlDbType.Int))

        End With

        Try

            sccnnConnection.Open()

            With sccmdInsert

                'Assign Parameters Values

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

            Throw New ApplicationException("Los registros no pudieron ser actualizados debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("Los registros no pudieron ser actualizados debido a un error de aplicación.", ex)

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

    End Sub

#End Region

#Region "Web Services"

    Private Function GetCodigoSAPAsoc(ByVal dpValeID As Integer) As String

        Return oNotaCreditoMgr.GetFolioSAPByDPVale(dpValeID)

    End Function


    Public Function GetDPValeInfo(ByVal dpValeID As Integer) As String()

        Return oNotaCreditoMgr.GetDPValeInfo(dpValeID)

    End Function


    Friend Function GetDpValeIDDP(ByVal FolioFactura As Integer) As String

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                                DataStorageConfiguration.GetConnectionString)


        Dim sccmdSelect As SqlCommand = New SqlCommand
        Dim scdrReader As SqlDataReader
        Dim DPValeID As String = ""

        Try

            With sccmdSelect

                .Connection = sccnnConnection
                '.CommandText = " SELECT FacturasFormasPago.DPValeID " & _
                '                " FROM  Factura INNER JOIN FacturasFormasPago ON " & _
                '                " Factura.FacturaID = FacturasFormasPago.FacturaID " & _
                '                " WHERE Factura.FolioFactura  = " & FolioFactura & _
                '                " ORDER by FacturasFormasPago.DPValeID DESC"
                .CommandText = "[FacturasGetDPValeID]"
                .CommandType = CommandType.StoredProcedure

                '.Parameters.Add(New SqlParameter("@FolioFactura", SqlDbType.Int, 4))
                '.Parameters.Add(New SqlParameter("@CodCaja", SqlDbType.VarChar, 4))
                .Parameters.Add(New SqlParameter("@FacturaID", SqlDbType.Int, 4))

                '.Parameters("@FolioFactura").Value = FolioFactura
                '.Parameters("@CodCaja").Value = oParent.ApplicationContext.ApplicationConfiguration.NoCaja
                .Parameters("@FacturaID").Value = FolioFactura
            End With
            sccnnConnection.Open()

            'Execute Command
            scdrReader = sccmdSelect.ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

            'Assign Other Values
            scdrReader.Read()
            If (scdrReader.HasRows) Then

                With scdrReader

                    DPValeID = .GetString(0)

                End With

            End If

            scdrReader.Close()

            sccnnConnection.Close()

            'sccnnConnection.Dispose()
            'sccnnConnection = Nothing

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

        Return DPValeID

    End Function

#End Region

#Region "Methods SAP"


    Friend Function VentasTienda(ByVal FechaCierre As Date, Optional ByVal band As Boolean = True, Optional ByVal VPN As Boolean = True) As DataSet

        If band Then
            ' '''Guardamos Facturas que no tienen Folio SAP.
            'Dim ofrmGuardarFacturasPendientes As New frmGuardarFacturasPendientes
            'ofrmGuardarFacturasPendientes.oParent = oParent
            'ofrmGuardarFacturasPendientes.ShowDialog()
            ' '''Guardamos Facturas que no tienen Folio SAP.
            'If FacturaSelDontSaved.Tables(0).Rows.Count > 0 Then
            '    Exit Function
            'End If
        End If

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                                 DataStorageConfiguration.GetConnectionString)

        Dim sccmdSelectVentas As SqlCommand = New SqlCommand
        Dim dsResultados As New DataSet

        Try

            With sccmdSelectVentas

                .Connection = sccnnConnection
                .CommandText = _
                        "SELECT	DISTINCT Factura.CodAlmacen," & _
                        "ZPP_COBRANZAS.Tienda,Factura.FolioFactura," & _
                        "Factura.FolioFiSAP as FolioSAP,Factura.ClienteID,Monto=cast(FacturasFormasPago.MontoPago as Decimal(8,2))," & _
                        "FacturasFormasPago.CodFormasPago,FacturasFormasPago.CodBanco,Factura.Fecha,Factura.CodTipoVenta " & _
                        "FROM	Factura INNER JOIN FacturasFormasPago ON Factura.FacturaID =FacturasFormasPago.FacturaID " & _
                        "INNER JOIN CatalogoCentros ON Factura.CodAlmacen =CatalogoCentros.OficinaVtas " & _
                        "INNER JOIN ZPP_COBRANZAS ON CatalogoCentros.CentroSAP =ZPP_COBRANZAS.Werks " & _
                        "WHERE FacturasFormasPago.FI05SAP = 0 AND Factura.Fecha ='" & Format(FechaCierre, "dd/MM/yyyy") & "'  AND " & _
                        "FacturasFormasPago.CodFormasPago IN ('EFEC', 'TACR', 'TADB') AND " & _
                        "Factura.CodTipoVenta IN ('P','D','V','F','O','I','S','K') AND Factura.status='GRA' AND Factura.CodAlmacen = '" & _
                        oParent.ApplicationContext.ApplicationConfiguration.Almacen & "' " & _
                        "ORDER BY Factura.ClienteID ASC"
                .CommandType = CommandType.Text

            End With

            sccnnConnection.Open()

            Dim sqlDAVentas As New SqlDataAdapter(sccmdSelectVentas)
            sqlDAVentas.Fill(dsResultados, "Ventas")

            sccnnConnection.Close()
            If Not CrearFolder(VPN, FechaCierre) Then
                VPN = False
            End If

            sm_GenerateFileTxt(dsResultados, FechaCierre, VPN)

            Return dsResultados

        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                sccnnConnection.Close()
            End If

            Throw New ApplicationException("El registro no pudo ser leido debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                sccnnConnection.Close()
            End If

            Throw New ApplicationException("El registro no pudo ser leido debido a un error de aplicación.", ex)

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

    End Function

    'Funcion Cobranza Up
    Friend Function VentasTiendaUp(ByVal FechaCierre As Date, ByRef strMensaje As String, Optional ByVal band As Boolean = True, Optional ByVal VPN As Boolean = True) As String
        Dim strResult As String = "N"
        'band = False
        'If band Then
        ' '''Guardamos Facturas que no tienen Folio SAP.
        'Dim ofrmGuardarFacturasPendientes As New frmGuardarFacturasPendientes
        'ofrmGuardarFacturasPendientes.oParent = oParent
        'ofrmGuardarFacturasPendientes.ShowDialog()
        ' '''Guardamos Facturas que no tienen Folio SAP.
        'If FacturaSelDontSaved.Tables(0).Rows.Count > 0 Then
        '    strResult = ""
        '    Exit Function
        'End If
        ' End If

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                                 DataStorageConfiguration.GetConnectionString)

        Dim sccmdSelectVentas As SqlCommand = New SqlCommand
        Dim dsResultados As New DataSet

        Try

            With sccmdSelectVentas

                .Connection = sccnnConnection
                .CommandText = "CierreDiaCobranzaDiaria"
                .CommandType = CommandType.StoredProcedure


                '.Parameters.Add(New SqlParameter("@FechaCierre", SqlDbType.Date, 10, "FechaCierre"))
                '.Parameters.Add(New SqlParameter("@CodAlmacen", SqlDbType.VarChar, 3, "Almacen"))
                .Parameters.AddWithValue("@FechaInicio", FechaCierre.Date)
                .Parameters.AddWithValue("@FechaFin", FechaCierre.Date.AddDays(1).Date)
                .Parameters.AddWithValue("@CodAlmacen", oParent.ApplicationContext.ApplicationConfiguration.Almacen)
            End With

            sccnnConnection.Open()

            Dim sqlDAVentas As New SqlDataAdapter(sccmdSelectVentas)
            sqlDAVentas.Fill(dsResultados, "Ventas")
            sccmdSelectVentas.Dispose()
            Dim dtNotasCredito As New DataSet()
            sccmdSelectVentas.Parameters.Clear()
            sccmdSelectVentas.CommandType = CommandType.StoredProcedure
            sccmdSelectVentas.CommandText = "GetNotasCreditoByDay"
            sccmdSelectVentas.Parameters.AddWithValue("@FechaCierre", FechaCierre)
            sccmdSelectVentas.Parameters.AddWithValue("@CodAlmacen", oParent.ApplicationContext.ApplicationConfiguration.Almacen)
            sqlDAVentas = New SqlDataAdapter(sccmdSelectVentas)
            sqlDAVentas.Fill(dtNotasCredito)
            sccnnConnection.Close()
            '------------------------------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 29/06/2016: Volvemos hacer la conciliación para eliminar los pedidos que no se guardaron en SAP.
            '------------------------------------------------------------------------------------------------------------------------------------
            'Dim dtFacturas As DataTable = oSAPMgr.ZSD_VALIDA_PEDIDOS(FechaCierre) ', FechaCierre)
            ''Dim dtFacturas As DataTable = oSAPMgr.ZSD_VALIDA_PEDIDOS(FechaCierre, FechaCierre)
            'If dtFacturas.Rows.Count > 0 Then
            '    Dim lstFacturas As New List(Of String)
            '    Dim rows() As DataRow = Nothing
            '    For Each row As DataRow In dsResultados.Tables(0).Rows
            '        'If CStr(row("CodTipoVenta")) <> "V" Then
            '        rows = dtFacturas.Select("BSTNK='" & CStr(row("Referencia") & "'"))
            '        If rows.Length = 0 Then
            '            If lstFacturas.Contains(CStr(row("Referencia"))) = False Then
            '                lstFacturas.Add(CStr(row("Referencia")))
            '            End If
            '        End If
            '        'End If
            '    Next
            '    For Each renglon As String In lstFacturas
            '        rows = dsResultados.Tables(0).Select("Referencia='" & renglon & "'")
            '        If rows.Length > 0 Then
            '            For Each fila As DataRow In rows
            '                dsResultados.Tables(0).Rows.Remove(fila)
            '                dsResultados.Tables(0).AcceptChanges()
            '            Next
            '        End If
            '    Next
            'End If
            'If Not CrearFolder(VPN, FechaCierre) Then
            '    VPN = False
            'End If
            sm_GenerateNotaCredito(dtNotasCredito, FechaCierre, strMensaje)
            sm_GenerateFileTxtUp(dsResultados, FechaCierre, strMensaje, VPN)
            strResult = "S"

            Return strMensaje

        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                sccnnConnection.Close()
            End If

            Throw New ApplicationException("El registro no pudo ser leido debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                sccnnConnection.Close()
            End If

            Throw New ApplicationException("El registro no pudo ser leido debido a un error de aplicación.", ex)

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

    End Function

    'Funcion Vale Caja Up
    Friend Function VentasTiendaUpVC(ByVal FechaCierre As Date, ByRef strMensaje As String, Optional ByVal band As Boolean = True, Optional ByVal VPN As Boolean = True) As String
        Dim strResult As String
        If band Then
            ' '''Guardamos Facturas que no tienen Folio SAP.
            'Dim ofrmGuardarFacturasPendientes As New frmGuardarFacturasPendientes
            'ofrmGuardarFacturasPendientes.oParent = oParent
            'ofrmGuardarFacturasPendientes.ShowDialog()
            ' '''Guardamos Facturas que no tienen Folio SAP.
            'If FacturaSelDontSaved.Tables(0).Rows.Count > 0 Then
            '    strResult = ""
            '    Exit Function
            'End If
        End If

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                                 DataStorageConfiguration.GetConnectionString)

        Dim sccmdSelectVentas As SqlCommand = New SqlCommand
        Dim dsResultados As New DataSet

        Try

            With sccmdSelectVentas

                .Connection = sccnnConnection
                .CommandText = "[SelValeCajaVtas]"
                .CommandType = CommandType.StoredProcedure

                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime, 8))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Almacen", System.Data.SqlDbType.VarChar, 5))

                .Parameters("@Fecha").Value = Format(FechaCierre, "dd/MM/yyyy")
                .Parameters("@Almacen").Value = oParent.ApplicationContext.ApplicationConfiguration.Almacen
            End With

            sccnnConnection.Open()

            Dim sqlDAVentas As New SqlDataAdapter(sccmdSelectVentas)
            sqlDAVentas.Fill(dsResultados, "Ventas")

            sccnnConnection.Close()
            'If Not CrearFolder(VPN, FechaCierre) Then
            '    VPN = False
            'End If

            '----------------------------------------------------------------------------------------------------------------
            'JNAVA (04/07/2013) Obtenemos ValeCaja de Si Hay
            '----------------------------------------------------------------------------------------------------------------
            Dim dsResultadosSH As New DataSet
            sccmdSelectVentas = New SqlCommand
            With sccmdSelectVentas
                .Connection = sccnnConnection
                .CommandText = "[SelValeCajaVtasSH]"
                .CommandType = CommandType.StoredProcedure

                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime, 8))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Almacen", System.Data.SqlDbType.VarChar, 5))

                .Parameters("@Fecha").Value = Format(FechaCierre, "dd/MM/yyyy")
                .Parameters("@Almacen").Value = oParent.ApplicationContext.ApplicationConfiguration.Almacen
            End With
            sccnnConnection.Open()

            Dim sqlDAVentasSH As New SqlDataAdapter(sccmdSelectVentas)
            sqlDAVentasSH.Fill(dsResultadosSH, "Ventas")

            'Agregamos Registros de Vales de Caja de SH al registro de Vale de Caja normales.
            For Each oRowSH As DataRow In dsResultadosSH.Tables(0).Rows
                dsResultados.Tables(0).ImportRow(oRowSH)
            Next
            dsResultados.Tables(0).AcceptChanges()

            sccnnConnection.Close()
            '----------------------------------------------------------------------------------------------------------------


            strResult = sm_GenerateFileTxtUpVC(dsResultados, FechaCierre, strMensaje, VPN)

            Return strResult

        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                sccnnConnection.Close()
            End If

            Throw New ApplicationException("El registro no pudo ser leido debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                sccnnConnection.Close()
            End If

            Throw New ApplicationException("El registro no pudo ser leido debido a un error de aplicación.", ex)

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

    End Function

    'Funcion Vale Caja DPVL Up
    Friend Function VentasTiendaUpVCDPVL(ByVal FechaCierre As Date, ByRef strMensaje As String, Optional ByVal band As Boolean = True, Optional ByVal VPN As Boolean = True) As String
        Dim strResult As String
        If band Then
            '''Guardamos Facturas que no tienen Folio SAP.
            'Dim ofrmGuardarFacturasPendientes As New frmGuardarFacturasPendientes
            'ofrmGuardarFacturasPendientes.oParent = oParent
            'ofrmGuardarFacturasPendientes.ShowDialog()
            ''''Guardamos Facturas que no tienen Folio SAP.
            'If FacturaSelDontSaved.Tables(0).Rows.Count > 0 Then
            '    strResult = ""
            '    Exit Function
            'End If
        End If

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                                 DataStorageConfiguration.GetConnectionString)

        Dim sccmdSelectVentas As SqlCommand = New SqlCommand
        Dim dsResultados As New DataSet

        Try

            With sccmdSelectVentas

                .Connection = sccnnConnection
                .CommandText = "[SelValeCajaVtasDPVL]"
                .CommandType = CommandType.StoredProcedure

                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime, 8))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Almacen", System.Data.SqlDbType.VarChar, 5))

                .Parameters("@Fecha").Value = Format(FechaCierre, "dd/MM/yyyy")
                .Parameters("@Almacen").Value = oParent.ApplicationContext.ApplicationConfiguration.Almacen
            End With

            sccnnConnection.Open()

            Dim sqlDAVentas As New SqlDataAdapter(sccmdSelectVentas)
            sqlDAVentas.Fill(dsResultados, "Ventas")

            sccnnConnection.Close()
            'If Not CrearFolder(VPN, FechaCierre) Then
            '    VPN = False
            'End If


            strResult = sm_GenerateFileTxtUpVCDPVL(dsResultados, FechaCierre, strMensaje, VPN)


            Return strResult

        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                sccnnConnection.Close()
            End If

            Throw New ApplicationException("El registro no pudo ser leido debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                sccnnConnection.Close()
            End If

            Throw New ApplicationException("El registro no pudo ser leido debido a un error de aplicación.", ex)

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

    End Function

    'Funcion Vale Caja CANCAPAR Up
    Friend Function VentasTiendaUpVCCANCAPAR(ByVal FechaCierre As Date, ByRef strMensaje As String, Optional ByVal band As Boolean = True, Optional ByVal VPN As Boolean = True) As String
        Dim strResult As String
        'If band Then
        '    '''Guardamos Facturas que no tienen Folio SAP.
        '    Dim ofrmGuardarFacturasPendientes As New frmGuardarFacturasPendientes
        '    ofrmGuardarFacturasPendientes.oParent = oParent
        '    ofrmGuardarFacturasPendientes.ShowDialog()
        '    '''Guardamos Facturas que no tienen Folio SAP.
        '    If FacturaSelDontSaved.Tables(0).Rows.Count > 0 Then
        '        strResult = ""
        '        Exit Function
        '    End If
        'End If

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                                 DataStorageConfiguration.GetConnectionString)

        Dim sccmdSelectVentas As SqlCommand = New SqlCommand
        Dim dsResultados As New DataSet

        Try

            With sccmdSelectVentas

                .Connection = sccnnConnection
                .CommandText = "[SelValeCajaVtasCancApar]"
                .CommandType = CommandType.StoredProcedure

                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime, 8))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Almacen", System.Data.SqlDbType.VarChar, 5))

                .Parameters("@Fecha").Value = Format(FechaCierre, "dd/MM/yyyy")
                .Parameters("@Almacen").Value = oParent.ApplicationContext.ApplicationConfiguration.Almacen
            End With

            sccnnConnection.Open()

            Dim sqlDAVentas As New SqlDataAdapter(sccmdSelectVentas)
            sqlDAVentas.Fill(dsResultados, "Ventas")

            sccnnConnection.Close()
            'If Not CrearFolder(VPN, FechaCierre) Then
            '    VPN = False
            'End If

            strResult = sm_GenerateFileTxtUpVCCANCAPAR(dsResultados, FechaCierre, strMensaje, VPN)


            Return strResult

        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                sccnnConnection.Close()
            End If

            Throw New ApplicationException("El registro no pudo ser leido debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                sccnnConnection.Close()
            End If

            Throw New ApplicationException("El registro no pudo ser leido debido a un error de aplicación.", ex)

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

    End Function

    'Funcion Abonos Up
    Friend Function VentasTiendaUpAB(ByVal FechaCierre As Date, ByRef strMensaje As String, Optional ByVal band As Boolean = True, Optional ByVal VPN As Boolean = True) As String
        Dim strResult As String
        If band Then
            ' '''Guardamos Facturas que no tienen Folio SAP.
            'Dim ofrmGuardarFacturasPendientes As New frmGuardarFacturasPendientes
            'ofrmGuardarFacturasPendientes.oParent = oParent
            'ofrmGuardarFacturasPendientes.ShowDialog()
            ' '''Guardamos Facturas que no tienen Folio SAP.
            'If FacturaSelDontSaved.Tables(0).Rows.Count > 0 Then
            '    strResult = ""
            '    Exit Function
            'End If
        End If

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                                 DataStorageConfiguration.GetConnectionString)

        Dim sccmdSelectVentas As SqlCommand = New SqlCommand
        Dim dsResultados As New DataSet

        Try

            With sccmdSelectVentas

                .Connection = sccnnConnection
                .CommandText = "[SelVentasLiquidacion]"
                '.CommandText = _
                '        "SELECT	DISTINCT Factura.FolioFiSAP, AbonosApartados.DocFI, Apartados.ClienteID " & _
                '        "FROM Factura INNER JOIN FacturasFormasPago ON Factura.FacturaID =FacturasFormasPago.FacturaID  " & _
                '        "INNER JOIN Apartados ON Apartados.ApartadoId = Factura.ApartadoId " & _
                '        "INNER JOIN AbonosApartados ON  Apartados.ApartadoId = AbonosApartados.ApartadoId " & _
                '        "WHERE FacturasFormasPago.FI05SAP = 0 AND  Convert(Datetime,Convert(Varchar,Factura.Fecha,101),101) =  '" & Format(FechaCierre, "dd/MM/yyyy") & "'  AND " & _
                '        "FacturasFormasPago.CodFormasPago IN ('LIQU') AND  " & _
                '        "Factura.CodTipoVenta IN ('A') AND Factura.status='GRA' AND Factura.CodAlmacen = '" & _
                '        oParent.ApplicationContext.ApplicationConfiguration.Almacen & "' " & _
                '        "ORDER BY AbonosApartados.DocFI ASC, Apartados.ClienteID ASC"
                '.CommandType = CommandType.Text
                .CommandType = CommandType.StoredProcedure

                .Parameters.Add(New SqlParameter("@CodAlmacen", SqlDbType.VarChar, 4))
                .Parameters.Add(New SqlParameter("@Fecha", SqlDbType.DateTime, 8))

                .Parameters("@CodAlmacen").Value = oParent.ApplicationContext.ApplicationConfiguration.Almacen.Trim.PadLeft(3, "0")
                .Parameters("@Fecha").Value = FechaCierre
            End With

            sccnnConnection.Open()

            Dim sqlDAVentas As New SqlDataAdapter(sccmdSelectVentas)
            sqlDAVentas.Fill(dsResultados, "Ventas")

            sccnnConnection.Close()

            'Dataset para el DataView
            'Dim sccmdSelectVentasDV As SqlCommand = New SqlCommand
            Dim dsResultadosDV As New DataSet

            'With sccmdSelectVentasDV

            '    .Connection = sccnnConnection
            '    .CommandText = _
            '            "SELECT  DISTINCT Apartados.ClienteID, Factura.FolioFISAP " & _
            '            "FROM Factura INNER JOIN FacturasFormasPago ON Factura.FacturaID =FacturasFormasPago.FacturaID  " & _
            '            "INNER JOIN Apartados ON Apartados.ApartadoId = Factura.ApartadoId " & _
            '            "INNER JOIN AbonosApartados ON  Apartados.ApartadoId = AbonosApartados.ApartadoId " & _
            '            "WHERE FacturasFormasPago.FI05SAP = 0 AND  Convert(Datetime,Convert(Varchar,Factura.Fecha,101),101) =  '" & Format(FechaCierre, "dd/MM/yyyy") & "'  AND " & _
            '            "FacturasFormasPago.CodFormasPago IN ('LIQU') AND  " & _
            '            "Factura.CodTipoVenta IN ('A') AND Factura.status='GRA' AND Factura.CodAlmacen = '" & _
            '            oParent.ApplicationContext.ApplicationConfiguration.Almacen & "' " & _
            '            "ORDER BY Apartados.ClienteID ASC"
            '    .CommandType = CommandType.Text
            'End With

            'sccnnConnection.Open()

            'Dim sqlDAVentasDV As New SqlDataAdapter(sccmdSelectVentasDV)
            'sqlDAVentasDV.Fill(dsResultadosDV, "Ventas")

            'sccnnConnection.Close()

            dsResultadosDV = dsResultados.Copy


            'If Not CrearFolder(VPN, FechaCierre) Then
            '    VPN = False
            'End If
            strResult = sm_GenerateFileTxtUpAB(dsResultados, dsResultadosDV, FechaCierre, strMensaje, VPN)


            Return strResult

        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                sccnnConnection.Close()
            End If

            Throw New ApplicationException("El registro no pudo ser leido debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                sccnnConnection.Close()
            End If

            Throw New ApplicationException("El registro no pudo ser leido debido a un error de aplicación.", ex)

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

    End Function

    Public Function SelectMotivosFac(ByVal datFechaIni As Date, ByVal datFechaFin As Date, ByVal strTipoMovto As String) As DataSet

        Dim oResult As DataSet
        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                                 DataStorageConfiguration.GetConnectionString)

        Dim sccmdSelect As SqlCommand

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[CatalogoMotivosFacSel]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaIni", System.Data.SqlDbType.DateTime, 8))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaFin", System.Data.SqlDbType.DateTime, 8))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TipoMovto", System.Data.SqlDbType.VarChar, 5))
            .Parameters("@FechaIni").Value = datFechaIni
            .Parameters("@FechaFin").Value = datFechaFin
            .Parameters("@TipoMovto").Value = strTipoMovto

        End With

        Dim oFacturaAdapter As SqlDataAdapter
        oFacturaAdapter = New SqlDataAdapter
        oFacturaAdapter.SelectCommand = sccmdSelect

        Try

            sccnnConnection.Open()

            oResult = New DataSet

            oFacturaAdapter.Fill(oResult)

        Catch ex As Exception

            Throw ex

        Finally

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

        End Try

        sccmdSelect.Dispose()
        sccmdSelect = Nothing

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return oResult

    End Function

    Public Function BancoSel(ByVal Tienda As String, ByVal ClaCobr As String) As DataSet

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaBanco As SqlDataAdapter
        Dim dsBanco As DataSet

        sccmdSelectAll = New SqlCommand
        scdaBanco = New SqlDataAdapter
        dsBanco = New DataSet

        With sccmdSelectAll

            .Connection = sccnnConnection

            .CommandText = "[BancoSel]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@tienda", System.Data.SqlDbType.VarChar, 30))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@clacobr", System.Data.SqlDbType.VarChar, 9))

        End With

        scdaBanco.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            scdaBanco.SelectCommand.Parameters("@tienda").Value = Tienda.TrimEnd
            scdaBanco.SelectCommand.Parameters("@clacobr").Value = ClaCobr.TrimEnd

            'Fill DataSet
            scdaBanco.Fill(dsBanco)

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

        Return dsBanco
    End Function
    Private Sub sm_GenerateFileTxt(ByVal dsVentas As DataSet, ByVal FechaCierre As Date, Optional ByVal VPN As Boolean = True)
        Dim oMontarURed As New MontarUnidadRed.cMontaUnidadRed(oParent.ConfigSaveArchivos.Password, oParent.ConfigSaveArchivos.Usuario, oParent.ConfigSaveArchivos.Unidad, oParent.ConfigSaveArchivos.Ruta)
        Dim imes As Integer = FechaCierre.Date.Month
        Dim ruta As String
        oDPVale = New cDPVale
        If VPN Then
            ruta = oParent.ConfigSaveArchivos.Ruta & "\" & Mid(oParent.ApplicationContext.ApplicationConfiguration.Almacen, 2, 2) & "\" & GetMes(imes) & "\"
        Else
            ruta = "C:\VTAS\" & GetMes(imes) & "\"
        End If

        Try
            If dsVentas.Tables(0).Rows.Count = 0 Or dsVentas Is Nothing Then
                'If band Then

                'End If
                If VPN Then
                    oMontarURed.Desconecta()
                    oMontarURed.Desconecta()
                End If
                Exit Sub
            End If

            Dim strRuta As String = ruta & "VTA" & oParent.ApplicationContext.ApplicationConfiguration.Almacen & FechaCierre.ToShortDateString.Replace("/", "") & ".txt"
            Dim txtWriter As New System.IO.StreamWriter(strRuta, False)

            ''DataView para las ventas
            Dim dvTarjetaUno As New DataView(dsVentas.Tables(0))
            Dim intIndex As Integer
            Dim strEncabezado As String

            '----------------Numero de Referencia---------------
            Dim numref As New NumeroReferencia.cNumReferencia
            Dim strNumRef As String = numref.getNumReferencia(oParent.ApplicationContext.ApplicationConfiguration.Almacen.PadLeft(4, "0"), CStr(Format(FechaCierre.Date.Date, "ddMMyyyy")))
            '------------------------------------------------------
            '*********************************PUBLICO GENERAL******************************
            ''Pagos Terminal 1
            dvTarjetaUno.RowFilter = "CodBanco like 'T1' and CodTipoVenta='P'"
            dvTarjetaUno.Sort = "FolioSAP"
            dvTarjetaUno.RowStateFilter = DataViewRowState.OriginalRows

            txtWriter.WriteLine(Chr(13))

            If dvTarjetaUno.Count > 0 Then

                strEncabezado = "40" & "TARJETA 1".PadRight(9, " ") & CStr(dvTarjetaUno(0)("Tienda")).PadRight(20, " ") & _
                                                 CStr(Format(dvTarjetaUno.Table.Compute("sum(Monto)", "CodBanco like 'T1'  and CodTipoVenta='P'"), "##########.#0")).PadLeft(16, " ") & _
                                                oParent.ApplicationContext.ApplicationConfiguration.Almacen.PadLeft(10, "0") & "    " & FechaCierre.ToShortDateString.Replace("/", "")
                txtWriter.WriteLine(strEncabezado)
                For intIndex = 0 To dvTarjetaUno.Count - 1
                    txtWriter.WriteLine("11" & CStr(dvTarjetaUno(intIndex)("FolioSAP")).PadLeft(10, "0") & CStr(dvTarjetaUno(intIndex)("Monto")).PadRight(16, " ") & "Venta Dia " & CDate(dvTarjetaUno(intIndex)("Fecha")).ToShortDateString.Replace("/", "") & oParent.ApplicationContext.ApplicationConfiguration.Almacen.PadLeft(10, "0"))
                Next

            End If

            ''Pagos Terminal 2
            dvTarjetaUno.RowFilter = "CodBanco like 'T2' and CodTipoVenta='P'"

            If dvTarjetaUno.Count > 0 Then

                strEncabezado = "40" & "TARJETA 2".PadRight(9, " ") & CStr(dvTarjetaUno(0)("Tienda")).PadRight(20, " ") & _
                                                  CStr(Format(dvTarjetaUno.Table.Compute("sum(Monto)", "CodBanco like 'T2'  and CodTipoVenta='P'"), "##########.#0")).PadLeft(16, " ") & _
                                                  oParent.ApplicationContext.ApplicationConfiguration.Almacen.PadLeft(10, "0") & "    " & FechaCierre.ToShortDateString.Replace("/", "")
                txtWriter.WriteLine(strEncabezado)
                For intIndex = 0 To dvTarjetaUno.Count - 1
                    txtWriter.WriteLine("11" & CStr(dvTarjetaUno(intIndex)("FolioSAP")).PadLeft(10, "0") & CStr(dvTarjetaUno(intIndex)("Monto")).PadRight(16, " ") & "Venta Dia " & CDate(dvTarjetaUno(intIndex)("Fecha")).ToShortDateString.Replace("/", "") & oParent.ApplicationContext.ApplicationConfiguration.Almacen.PadLeft(10, "0"))
                Next

            End If

            ''Pagos Terminal 3
            dvTarjetaUno.RowFilter = "CodBanco like 'T3' and CodTipoVenta='P'"

            If dvTarjetaUno.Count > 0 Then
                strEncabezado = "40" & "TARJETA 3".PadRight(9, " ") & CStr(dvTarjetaUno(0)("Tienda")).PadRight(20, " ") & _
                                                  CStr(Format(dvTarjetaUno.Table.Compute("sum(Monto)", "CodBanco like 'T3'  and CodTipoVenta='P'"), "##########.#0")).PadLeft(16, " ") & _
                                                  oParent.ApplicationContext.ApplicationConfiguration.Almacen.PadLeft(10, "0") & "    " & FechaCierre.ToShortDateString.Replace("/", "")
                txtWriter.WriteLine(strEncabezado)
                For intIndex = 0 To dvTarjetaUno.Count - 1
                    txtWriter.WriteLine("11" & CStr(dvTarjetaUno(intIndex)("FolioSAP")).PadLeft(10, "0") & CStr(dvTarjetaUno(intIndex)("Monto")).PadRight(16, " ") & "Venta Dia " & CDate(dvTarjetaUno(intIndex)("Fecha")).ToShortDateString.Replace("/", "") & oParent.ApplicationContext.ApplicationConfiguration.Almacen.PadLeft(10, "0"))
                Next

            End If

            ''Pagos Efectivo
            dvTarjetaUno.RowFilter = "CodFormasPago like 'EFEC' and CodTipoVenta='P'"

            If dvTarjetaUno.Count > 0 Then

                strEncabezado = "40" & "EFECTIVO".PadRight(9, " ") & CStr(dvTarjetaUno(0)("Tienda")).PadRight(20, " ") & _
                                         CStr(Format(dvTarjetaUno.Table.Compute("sum(Monto)", "CodFormasPago like 'EFEC'  and CodTipoVenta='P'"), "##########.#0")).PadLeft(16, " ") & _
                                         oParent.ApplicationContext.ApplicationConfiguration.Almacen.PadLeft(10, "0") & strNumRef
                txtWriter.WriteLine(strEncabezado)
                For intIndex = 0 To dvTarjetaUno.Count - 1
                    txtWriter.WriteLine("11" & CStr(dvTarjetaUno(intIndex)("FolioSAP")).PadLeft(10, "0") & CStr(dvTarjetaUno(intIndex)("Monto")).PadRight(16, " ") & "Venta Dia " & CDate(dvTarjetaUno(intIndex)("Fecha")).ToShortDateString.Replace("/", "") & oParent.ApplicationContext.ApplicationConfiguration.Almacen.PadLeft(10, "0"))
                Next

            End If

            '*********************************DIPS******************************
            dvTarjetaUno.RowFilter = "CodFormasPago like 'EFEC' and CodTipoVenta='D'"
            'Efectivo
            For intIndex = 0 To dvTarjetaUno.Count - 1

                strEncabezado = "40" & "EFECTIVO".PadRight(9, " ") & CStr(dvTarjetaUno(intIndex)("Tienda")).PadRight(20, " ") & _
                                  CStr(Format(dvTarjetaUno(intIndex)("Monto"), "##########.#0")).PadLeft(16, " ") & _
                                  CStr("121000002").PadLeft(10, "0") & strNumRef
                txtWriter.WriteLine(strEncabezado)
                txtWriter.WriteLine("11" & CStr(dvTarjetaUno(intIndex)("FolioSAP")).PadLeft(10, "0") & CStr(dvTarjetaUno(intIndex)("Monto")).PadRight(16, " ") & "Venta Dia " & CDate(dvTarjetaUno(intIndex)("Fecha")).ToShortDateString.Replace("/", "") & CStr(dvTarjetaUno(intIndex)("ClienteID")).PadLeft(10, "0"))
            Next

            'Tarjeta 1
            dvTarjetaUno.RowFilter = "CodBanco like 'T1' and CodTipoVenta='D'"

            For intIndex = 0 To dvTarjetaUno.Count - 1
                strEncabezado = "40" & "TARJETA 1".PadRight(9, " ") & CStr(dvTarjetaUno(intIndex)("Tienda")).PadRight(20, " ") & _
                                  CStr(Format(dvTarjetaUno(intIndex)("Monto"), "##########.#0")).PadLeft(16, " ") & _
                                  CStr("121000002").PadLeft(10, "0") & "    " & FechaCierre.ToShortDateString.Replace("/", "")
                txtWriter.WriteLine(strEncabezado)
                txtWriter.WriteLine("11" & CStr(dvTarjetaUno(intIndex)("FolioSAP")).PadLeft(10, "0") & CStr(dvTarjetaUno(intIndex)("Monto")).PadRight(16, " ") & "Venta Dia " & CDate(dvTarjetaUno(intIndex)("Fecha")).ToShortDateString.Replace("/", "") & CStr(dvTarjetaUno(intIndex)("ClienteID")).PadLeft(10, "0"))

            Next

            'Tarjeta 2
            dvTarjetaUno.RowFilter = "CodBanco like 'T2' and CodTipoVenta='D'"

            For intIndex = 0 To dvTarjetaUno.Count - 1
                strEncabezado = "40" & "TARJETA 2".PadRight(9, " ") & CStr(dvTarjetaUno(intIndex)("Tienda")).PadRight(20, " ") & _
                                  CStr(Format(dvTarjetaUno(intIndex)("Monto"), "##########.#0")).PadLeft(16, " ") & _
                                  CStr("121000002").PadRight(10, "0") & "    " & FechaCierre.ToShortDateString.Replace("/", "")
                txtWriter.WriteLine(strEncabezado)
                txtWriter.WriteLine("11" & CStr(dvTarjetaUno(intIndex)("FolioSAP")).PadLeft(10, "0") & CStr(dvTarjetaUno(intIndex)("Monto")).PadRight(16, " ") & "Venta Dia " & CDate(dvTarjetaUno(intIndex)("Fecha")).ToShortDateString.Replace("/", "") & CStr(dvTarjetaUno(intIndex)("ClienteID")).PadLeft(10, "0"))
            Next

            'Tarjeta 3
            dvTarjetaUno.RowFilter = "CodBanco like 'T3' and CodTipoVenta='D'"

            For intIndex = 0 To dvTarjetaUno.Count - 1
                strEncabezado = "40" & "TARJETA 3".PadRight(9, " ") & CStr(dvTarjetaUno(intIndex)("Tienda")).PadRight(20, " ") & _
                                  CStr(Format(dvTarjetaUno(intIndex)("Monto"), "##########.#0")).PadLeft(16, " ") & _
                                    CStr("121000002").PadRight(10, "0") & "    " & FechaCierre.ToShortDateString.Replace("/", "")
                txtWriter.WriteLine(strEncabezado)
                txtWriter.WriteLine("11" & CStr(dvTarjetaUno(intIndex)("FolioSAP")).PadLeft(10, "0") & CStr(dvTarjetaUno(intIndex)("Monto")).PadRight(16, " ") & "Venta Dia " & CDate(dvTarjetaUno(intIndex)("Fecha")).ToShortDateString.Replace("/", "") & CStr(dvTarjetaUno(intIndex)("ClienteID")).PadLeft(10, "0"))
            Next

            '*********************************DPVALE******************************
            'Efectivo
            dvTarjetaUno.RowFilter = "CodFormasPago like 'EFEC' and CodTipoVenta='V'"

            For intIndex = 0 To dvTarjetaUno.Count - 1

                strEncabezado = "40" & "EFECTIVO".PadRight(9, " ") & CStr(dvTarjetaUno(intIndex)("Tienda")).PadRight(20, " ") & _
                                  CStr(Format(dvTarjetaUno(intIndex)("Monto"), "##########.#0")).PadLeft(16, " ") & _
                                  CStr("122000001").PadLeft(10, "0") & strNumRef
                txtWriter.WriteLine(strEncabezado)

                If Not Me.oParent.SAPApplicationConfig.DPValeSAP Then
                    txtWriter.WriteLine("11" & CStr(dvTarjetaUno(intIndex)("FolioSAP")).PadLeft(10, "0") & CStr(dvTarjetaUno(intIndex)("Monto")).PadRight(16, " ") & "Venta Dia " & CDate(dvTarjetaUno(intIndex)("Fecha")).ToShortDateString.Replace("/", "") & CStr(GetCodigoSAPAsoc(GetDpValeIDDP(CInt(dvTarjetaUno(intIndex)("FacturaID"))))).PadRight(10, " "))
                Else

                    Dim strDpValeIDDP As String = CStr(GetDpValeIDDP(CInt(dvTarjetaUno(intIndex)("FacturaID"))))

                    Me.oDPVale.INUMVA = strDpValeIDDP
                    Me.oDPVale.I_RUTA = "X"

                    '--------------------------------------------------------------------------------------------
                    ' JNAVA (02.08.2016): Obtenemos la Info del DPVale 
                    '--------------------------------------------------------------------------------------------
                    'oDPVale = oSAPMgr.ZBAPI_VALIDA_DPVALE(oDPVale)
                    Dim S2Credit As New ProcesosS2Credit(oParent)
                    If oParent.ConfigSaveArchivos.AplicarS2Credit Then
                        oDPVale = S2Credit.ValidaDPVale(oDPVale)
                    Else
                        oDPVale = oSAPMgr.ZBAPI_VALIDA_DPVALE(oDPVale)
                    End If
                    '--------------------------------------------------------------------------------------------

                    txtWriter.WriteLine("11" & CStr(dvTarjetaUno(intIndex)("FolioSAP")).PadLeft(10, "0") & CStr(dvTarjetaUno(intIndex)("Monto")).PadRight(16, " ") & "Venta Dia " & CDate(dvTarjetaUno(intIndex)("Fecha")).ToShortDateString.Replace("/", "") & CStr(oDPVale.InfoDPVALE.Rows(0).Item("KUNNR")).PadRight(10, " "))
                End If

            Next

            'Tarjeta 1
            dvTarjetaUno.RowFilter = "CodBanco like 'T1' and CodTipoVenta='V'"

            For intIndex = 0 To dvTarjetaUno.Count - 1
                strEncabezado = "40" & "TARJETA 1".PadRight(9, " ") & CStr(dvTarjetaUno(intIndex)("Tienda")).PadRight(20, " ") & _
                                  CStr(Format(dvTarjetaUno(intIndex)("Monto"), "##########.#0")).PadLeft(16, " ") & _
                                  CStr("122000001").PadLeft(10, "0") & "    " & FechaCierre.ToShortDateString.Replace("/", "")
                txtWriter.WriteLine(strEncabezado)

                If Not Me.oParent.SAPApplicationConfig.DPValeSAP Then
                    txtWriter.WriteLine("11" & CStr(dvTarjetaUno(intIndex)("FolioSAP")).PadLeft(10, "0") & CStr(dvTarjetaUno(intIndex)("Monto")).PadRight(16, " ") & "Venta Dia " & CDate(dvTarjetaUno(intIndex)("Fecha")).ToShortDateString.Replace("/", "") & CStr(GetCodigoSAPAsoc(GetDpValeIDDP(CInt(dvTarjetaUno(intIndex)("FacturaID"))))).PadRight(10, " "))
                Else

                    Dim strDpValeIDDP As String = CStr(GetDpValeIDDP(CInt(dvTarjetaUno(intIndex)("FacturaID"))))

                    Me.oDPVale.INUMVA = strDpValeIDDP
                    Me.oDPVale.I_RUTA = "X"

                    '--------------------------------------------------------------------------------------------
                    ' JNAVA (02.08.2016): Obtenemos la Info del DPVale 
                    '--------------------------------------------------------------------------------------------
                    'oDPVale = oSAPMgr.ZBAPI_VALIDA_DPVALE(oDPVale)
                    Dim S2Credit As New ProcesosS2Credit(oParent)
                    If oParent.ConfigSaveArchivos.AplicarS2Credit Then
                        oDPVale = S2Credit.ValidaDPVale(oDPVale)
                    Else
                        oDPVale = oSAPMgr.ZBAPI_VALIDA_DPVALE(oDPVale)
                    End If
                    '--------------------------------------------------------------------------------------------

                    txtWriter.WriteLine("11" & CStr(dvTarjetaUno(intIndex)("FolioSAP")).PadLeft(10, "0") & CStr(dvTarjetaUno(intIndex)("Monto")).PadRight(16, " ") & "Venta Dia " & CDate(dvTarjetaUno(intIndex)("Fecha")).ToShortDateString.Replace("/", "") & CStr(oDPVale.InfoDPVALE.Rows(0).Item("KUNNR")).PadRight(10, " "))
                End If

            Next


            'Tarjeta 2
            dvTarjetaUno.RowFilter = "CodBanco like 'T2' and CodTipoVenta='V'"

            For intIndex = 0 To dvTarjetaUno.Count - 1
                strEncabezado = "40" & "TARJETA 2".PadRight(9, " ") & CStr(dvTarjetaUno(intIndex)("Tienda")).PadRight(20, " ") & _
                                  CStr(Format(dvTarjetaUno(intIndex)("Monto"), "##########.#0")).PadLeft(16, " ") & _
                                CStr("122000001").PadRight(10, "0") & "    " & FechaCierre.ToShortDateString.Replace("/", "")
                txtWriter.WriteLine(strEncabezado)

                If Not Me.oParent.SAPApplicationConfig.DPValeSAP Then
                    txtWriter.WriteLine("11" & CStr(dvTarjetaUno(intIndex)("FolioSAP")).PadLeft(10, "0") & CStr(dvTarjetaUno(intIndex)("Monto")).PadRight(16, " ") & "Venta Dia " & CDate(dvTarjetaUno(intIndex)("Fecha")).ToShortDateString.Replace("/", "") & CStr(GetCodigoSAPAsoc(GetDpValeIDDP(CInt(dvTarjetaUno(intIndex)("FacturaID"))))).PadRight(10, " "))
                Else

                    Dim strDpValeIDDP As String = CStr(GetDpValeIDDP(CInt(dvTarjetaUno(intIndex)("FacturaID"))))

                    Me.oDPVale.INUMVA = strDpValeIDDP
                    Me.oDPVale.I_RUTA = "X"

                    '--------------------------------------------------------------------------------------------
                    ' JNAVA (02.08.2016): Obtenemos la Info del DPVale 
                    '--------------------------------------------------------------------------------------------
                    'oDPVale = oSAPMgr.ZBAPI_VALIDA_DPVALE(oDPVale)
                    Dim S2Credit As New ProcesosS2Credit(oParent)
                    If oParent.ConfigSaveArchivos.AplicarS2Credit Then
                        oDPVale = S2Credit.ValidaDPVale(oDPVale)
                    Else
                        oDPVale = oSAPMgr.ZBAPI_VALIDA_DPVALE(oDPVale)
                    End If
                    '--------------------------------------------------------------------------------------------

                    txtWriter.WriteLine("11" & CStr(dvTarjetaUno(intIndex)("FolioSAP")).PadLeft(10, "0") & CStr(dvTarjetaUno(intIndex)("Monto")).PadRight(16, " ") & "Venta Dia " & CDate(dvTarjetaUno(intIndex)("Fecha")).ToShortDateString.Replace("/", "") & CStr(oDPVale.InfoDPVALE.Rows(0).Item("KUNNR")).PadRight(10, " "))
                End If

            Next

            'Tarjeta 3
            dvTarjetaUno.RowFilter = "CodBanco like 'T3' and CodTipoVenta='V'"

            For intIndex = 0 To dvTarjetaUno.Count - 1
                strEncabezado = "40" & "TARJETA 3".PadRight(9, " ") & CStr(dvTarjetaUno(intIndex)("Tienda")).PadRight(20, " ") & _
                                  CStr(Format(dvTarjetaUno(intIndex)("Monto"), "##########.#0")).PadLeft(16, " ") & _
                                CStr("122000001").PadRight(10, "0") & "    " & FechaCierre.ToShortDateString.Replace("/", "")
                txtWriter.WriteLine(strEncabezado)

                If Not Me.oParent.SAPApplicationConfig.DPValeSAP Then
                    txtWriter.WriteLine("11" & CStr(dvTarjetaUno(intIndex)("FolioSAP")).PadLeft(10, "0") & CStr(dvTarjetaUno(intIndex)("Monto")).PadRight(16, " ") & "Venta Dia " & CDate(dvTarjetaUno(intIndex)("Fecha")).ToShortDateString.Replace("/", "") & CStr(GetCodigoSAPAsoc(GetDpValeIDDP(CInt(dvTarjetaUno(intIndex)("FacturaID"))))).PadRight(10, " "))
                Else

                    Dim strDpValeIDDP As String = CStr(GetDpValeIDDP(CInt(dvTarjetaUno(intIndex)("FacturaID"))))

                    Me.oDPVale.INUMVA = strDpValeIDDP
                    Me.oDPVale.I_RUTA = "X"

                    '--------------------------------------------------------------------------------------------
                    ' JNAVA (02.08.2016): Obtenemos la Info del DPVale 
                    '--------------------------------------------------------------------------------------------
                    'oDPVale = oSAPMgr.ZBAPI_VALIDA_DPVALE(oDPVale)
                    Dim S2Credit As New ProcesosS2Credit(oParent)
                    If oParent.ConfigSaveArchivos.AplicarS2Credit Then
                        oDPVale = S2Credit.ValidaDPVale(oDPVale)
                    Else
                        oDPVale = oSAPMgr.ZBAPI_VALIDA_DPVALE(oDPVale)
                    End If
                    '--------------------------------------------------------------------------------------------

                    txtWriter.WriteLine("11" & CStr(dvTarjetaUno(intIndex)("FolioSAP")).PadLeft(10, "0") & CStr(dvTarjetaUno(intIndex)("Monto")).PadRight(16, " ") & "Venta Dia " & CDate(dvTarjetaUno(intIndex)("Fecha")).ToShortDateString.Replace("/", "") & CStr(oDPVale.InfoDPVALE.Rows(0).Item("KUNNR")).PadRight(10, " "))
                End If

            Next

            '*********************************FONACOT******************************
            'Efectivo
            dvTarjetaUno.RowFilter = "CodFormasPago like 'EFEC' and CodTipoVenta='F'"

            For intIndex = 0 To dvTarjetaUno.Count - 1

                strEncabezado = "40" & "EFECTIVO".PadRight(9, " ") & CStr(dvTarjetaUno(intIndex)("Tienda")).PadRight(20, " ") & _
                                  CStr(Format(dvTarjetaUno(intIndex)("Monto"), "##########.#0")).PadLeft(16, " ") & _
                                  CStr("121000001").PadLeft(10, "0") & strNumRef
                txtWriter.WriteLine(strEncabezado)
                txtWriter.WriteLine("11" & CStr(dvTarjetaUno(intIndex)("FolioSAP")).PadLeft(10, "0") & CStr(dvTarjetaUno(intIndex)("Monto")).PadRight(16, " ") & "Venta Dia " & CDate(dvTarjetaUno(intIndex)("Fecha")).ToShortDateString.Replace("/", "") & CStr("260000000").PadLeft(10, "0"))
            Next

            'Tarjeta 1
            dvTarjetaUno.RowFilter = "CodBanco like 'T1' and CodTipoVenta='F'"

            For intIndex = 0 To dvTarjetaUno.Count - 1
                strEncabezado = "40" & "TARJETA 1".PadRight(9, " ") & CStr(dvTarjetaUno(intIndex)("Tienda")).PadRight(20, " ") & _
                                  CStr(Format(dvTarjetaUno(intIndex)("Monto"), "##########.#0")).PadLeft(16, " ") & _
                                    CStr("121000001").PadLeft(10, "0") & "    " & FechaCierre.ToShortDateString.Replace("/", "")
                txtWriter.WriteLine(strEncabezado)
                txtWriter.WriteLine("11" & CStr(dvTarjetaUno(intIndex)("FolioSAP")).PadLeft(10, "0") & CStr(dvTarjetaUno(intIndex)("Monto")).PadRight(16, " ") & "Venta Dia " & CDate(dvTarjetaUno(intIndex)("Fecha")).ToShortDateString.Replace("/", "") & CStr("260000000").PadLeft(10, "0"))
            Next

            'Tarjeta 2
            dvTarjetaUno.RowFilter = "CodBanco like 'T2' and CodTipoVenta='F'"

            For intIndex = 0 To dvTarjetaUno.Count - 1
                strEncabezado = "40" & "TARJETA 2".PadRight(9, " ") & CStr(dvTarjetaUno(intIndex)("Tienda")).PadRight(20, " ") & _
                                CStr(Format(dvTarjetaUno(intIndex)("Monto"), "##########.#0")).PadLeft(16, " ") & _
                                CStr("121000001").PadRight(10, "0") & "    " & FechaCierre.ToShortDateString.Replace("/", "")
                txtWriter.WriteLine(strEncabezado)
                txtWriter.WriteLine("11" & CStr(dvTarjetaUno(intIndex)("FolioSAP")).PadLeft(10, "0") & CStr(dvTarjetaUno(intIndex)("Monto")).PadRight(16, " ") & "Venta Dia " & CDate(dvTarjetaUno(intIndex)("Fecha")).ToShortDateString.Replace("/", "") & CStr("260000000").PadLeft(10, "0"))
            Next

            'Tarjeta 3
            dvTarjetaUno.RowFilter = "CodBanco like 'T3' and CodTipoVenta='F'"

            For intIndex = 0 To dvTarjetaUno.Count - 1
                strEncabezado = "40" & "TARJETA 3".PadRight(9, " ") & CStr(dvTarjetaUno(intIndex)("Tienda")).PadRight(20, " ") & _
                                CStr(Format(dvTarjetaUno(intIndex)("Monto"), "##########.#0")).PadLeft(16, " ") & _
                                CStr("121000001").PadRight(10, "0") & "    " & FechaCierre.ToShortDateString.Replace("/", "")
                txtWriter.WriteLine(strEncabezado)
                txtWriter.WriteLine("11" & CStr(dvTarjetaUno(intIndex)("FolioSAP")).PadLeft(10, "0") & CStr(dvTarjetaUno(intIndex)("Monto")).PadRight(16, " ") & "Venta Dia " & CDate(dvTarjetaUno(intIndex)("Fecha")).ToShortDateString.Replace("/", "") & CStr("260000000").PadLeft(10, "0"))
            Next

            '*********************************TARJETA FONACOT******************************
            'Efectivo
            dvTarjetaUno.RowFilter = "CodFormasPago like 'EFEC' and CodTipoVenta='K'"

            For intIndex = 0 To dvTarjetaUno.Count - 1

                strEncabezado = "40" & "EFECTIVO".PadRight(9, " ") & CStr(dvTarjetaUno(intIndex)("Tienda")).PadRight(20, " ") & _
                                  CStr(Format(dvTarjetaUno(intIndex)("Monto"), "##########.#0")).PadLeft(16, " ") & _
                                  CStr("121000001").PadLeft(10, "0") & strNumRef
                txtWriter.WriteLine(strEncabezado)
                txtWriter.WriteLine("11" & CStr(dvTarjetaUno(intIndex)("FolioSAP")).PadLeft(10, "0") & CStr(dvTarjetaUno(intIndex)("Monto")).PadRight(16, " ") & "Venta Dia " & CDate(dvTarjetaUno(intIndex)("Fecha")).ToShortDateString.Replace("/", "") & CStr("260002268").PadLeft(10, "0"))
            Next

            'Tarjeta 1
            dvTarjetaUno.RowFilter = "CodBanco like 'T1' and CodTipoVenta='K'"

            For intIndex = 0 To dvTarjetaUno.Count - 1
                strEncabezado = "40" & "TARJETA 1".PadRight(9, " ") & CStr(dvTarjetaUno(intIndex)("Tienda")).PadRight(20, " ") & _
                                  CStr(Format(dvTarjetaUno(intIndex)("Monto"), "##########.#0")).PadLeft(16, " ") & _
                                    CStr("121000001").PadLeft(10, "0") & "    " & FechaCierre.ToShortDateString.Replace("/", "")
                txtWriter.WriteLine(strEncabezado)
                txtWriter.WriteLine("11" & CStr(dvTarjetaUno(intIndex)("FolioSAP")).PadLeft(10, "0") & CStr(dvTarjetaUno(intIndex)("Monto")).PadRight(16, " ") & "Venta Dia " & CDate(dvTarjetaUno(intIndex)("Fecha")).ToShortDateString.Replace("/", "") & CStr("260002268").PadLeft(10, "0"))
            Next

            'Tarjeta 2
            dvTarjetaUno.RowFilter = "CodBanco like 'T2' and CodTipoVenta='K'"

            For intIndex = 0 To dvTarjetaUno.Count - 1
                strEncabezado = "40" & "TARJETA 2".PadRight(9, " ") & CStr(dvTarjetaUno(intIndex)("Tienda")).PadRight(20, " ") & _
                                CStr(Format(dvTarjetaUno(intIndex)("Monto"), "##########.#0")).PadLeft(16, " ") & _
                                CStr("121000001").PadRight(10, "0") & "    " & FechaCierre.ToShortDateString.Replace("/", "")
                txtWriter.WriteLine(strEncabezado)
                txtWriter.WriteLine("11" & CStr(dvTarjetaUno(intIndex)("FolioSAP")).PadLeft(10, "0") & CStr(dvTarjetaUno(intIndex)("Monto")).PadRight(16, " ") & "Venta Dia " & CDate(dvTarjetaUno(intIndex)("Fecha")).ToShortDateString.Replace("/", "") & CStr("260002268").PadLeft(10, "0"))
            Next

            'Tarjeta 3
            dvTarjetaUno.RowFilter = "CodBanco like 'T3' and CodTipoVenta='K'"

            For intIndex = 0 To dvTarjetaUno.Count - 1
                strEncabezado = "40" & "TARJETA 3".PadRight(9, " ") & CStr(dvTarjetaUno(intIndex)("Tienda")).PadRight(20, " ") & _
                                CStr(Format(dvTarjetaUno(intIndex)("Monto"), "##########.#0")).PadLeft(16, " ") & _
                                CStr("121000001").PadRight(10, "0") & "    " & FechaCierre.ToShortDateString.Replace("/", "")
                txtWriter.WriteLine(strEncabezado)
                txtWriter.WriteLine("11" & CStr(dvTarjetaUno(intIndex)("FolioSAP")).PadLeft(10, "0") & CStr(dvTarjetaUno(intIndex)("Monto")).PadRight(16, " ") & "Venta Dia " & CDate(dvTarjetaUno(intIndex)("Fecha")).ToShortDateString.Replace("/", "") & CStr("260002268").PadLeft(10, "0"))
            Next

            '*********************************FACILITO******************************
            'Efectivo
            dvTarjetaUno.RowFilter = "CodFormasPago like 'EFEC' and CodTipoVenta='O'"

            For intIndex = 0 To dvTarjetaUno.Count - 1

                strEncabezado = "40" & "EFECTIVO".PadRight(9, " ") & CStr(dvTarjetaUno(intIndex)("Tienda")).PadRight(20, " ") & _
                                  CStr(Format(dvTarjetaUno(intIndex)("Monto"), "##########.#0")).PadLeft(16, " ") & _
                                  CStr("121000001").PadLeft(10, "0") & strNumRef
                txtWriter.WriteLine(strEncabezado)
                txtWriter.WriteLine("11" & CStr(dvTarjetaUno(intIndex)("FolioSAP")).PadLeft(10, "0") & CStr(dvTarjetaUno(intIndex)("Monto")).PadRight(16, " ") & "Venta Dia " & CDate(dvTarjetaUno(intIndex)("Fecha")).ToShortDateString.Replace("/", "") & CStr("260000001").PadLeft(10, "0"))
            Next

            'Tarjeta 1
            dvTarjetaUno.RowFilter = "CodBanco like 'T1' and CodTipoVenta='O'"

            For intIndex = 0 To dvTarjetaUno.Count - 1
                strEncabezado = "40" & "TARJETA 1".PadRight(9, " ") & CStr(dvTarjetaUno(intIndex)("Tienda")).PadRight(20, " ") & _
                                 CStr(Format(dvTarjetaUno(intIndex)("Monto"), "##########.#0")).PadLeft(16, " ") & _
                                 CStr("121000001").PadLeft(10, "0") & "    " & FechaCierre.ToShortDateString.Replace("/", "")
                txtWriter.WriteLine(strEncabezado)
                txtWriter.WriteLine("11" & CStr(dvTarjetaUno(intIndex)("FolioSAP")).PadLeft(10, "0") & CStr(dvTarjetaUno(intIndex)("Monto")).PadRight(16, " ") & "Venta Dia " & CDate(dvTarjetaUno(intIndex)("Fecha")).ToShortDateString.Replace("/", "") & CStr("260000001").PadLeft(10, "0"))
            Next

            'Tarjeta 2
            dvTarjetaUno.RowFilter = "CodBanco like 'T2' and CodTipoVenta='O'"

            For intIndex = 0 To dvTarjetaUno.Count - 1
                strEncabezado = "40" & "TARJETA 2".PadRight(9, " ") & CStr(dvTarjetaUno(intIndex)("Tienda")).PadRight(20, " ") & _
                                  CStr(Format(dvTarjetaUno(intIndex)("Monto"), "##########.#0")).PadLeft(16, " ") & _
                                  CStr("121000001").PadRight(10, "0") & "    " & FechaCierre.ToShortDateString.Replace("/", "")
                txtWriter.WriteLine(strEncabezado)
                txtWriter.WriteLine("11" & CStr(dvTarjetaUno(intIndex)("FolioSAP")).PadLeft(10, "0") & CStr(dvTarjetaUno(intIndex)("Monto")).PadRight(16, " ") & "Venta Dia " & CDate(dvTarjetaUno(intIndex)("Fecha")).ToShortDateString.Replace("/", "") & CStr("260000001").PadLeft(10, "0"))
            Next

            'Tarjeta 3
            dvTarjetaUno.RowFilter = "CodBanco like 'T3' and CodTipoVenta='O'"

            For intIndex = 0 To dvTarjetaUno.Count - 1
                strEncabezado = "40" & "TARJETA 3".PadRight(9, " ") & CStr(dvTarjetaUno(intIndex)("Tienda")).PadRight(20, " ") & _
                                  CStr(Format(dvTarjetaUno(intIndex)("Monto"), "##########.#0")).PadLeft(16, " ") & _
                                  CStr("121000001").PadRight(10, "0") & "    " & FechaCierre.ToShortDateString.Replace("/", "")
                txtWriter.WriteLine(strEncabezado)
                txtWriter.WriteLine("11" & CStr(dvTarjetaUno(intIndex)("FolioSAP")).PadLeft(10, "0") & CStr(dvTarjetaUno(intIndex)("Monto")).PadRight(16, " ") & "Venta Dia " & CDate(dvTarjetaUno(intIndex)("Fecha")).ToShortDateString.Replace("/", "") & CStr("260000001").PadLeft(10, "0"))
            Next

            '*********************************SOCIOS 053******************************
            'Efectivo
            dvTarjetaUno.RowFilter = "CodFormasPago like 'EFEC' and CodTipoVenta='S'"

            For intIndex = 0 To dvTarjetaUno.Count - 1

                strEncabezado = "40" & "EFECTIVO".PadRight(9, " ") & CStr(dvTarjetaUno(intIndex)("Tienda")).PadRight(20, " ") & _
                                  CStr(Format(dvTarjetaUno(intIndex)("Monto"), "##########.#0")).PadLeft(16, " ") & _
                                  CStr("121000001").PadLeft(10, "0") & strNumRef
                txtWriter.WriteLine(strEncabezado)
                txtWriter.WriteLine("11" & CStr(dvTarjetaUno(intIndex)("FolioSAP")).PadLeft(10, "0") & CStr(dvTarjetaUno(intIndex)("Monto")).PadRight(16, " ") & "Venta Dia " & CDate(dvTarjetaUno(intIndex)("Fecha")).ToShortDateString.Replace("/", "") & CStr(dvTarjetaUno(intIndex)("ClienteID")).PadLeft(10, "0"))
            Next

            'Tarjeta 1
            dvTarjetaUno.RowFilter = "CodBanco like 'T1' and CodTipoVenta='S'"

            For intIndex = 0 To dvTarjetaUno.Count - 1
                strEncabezado = "40" & "TARJETA 1".PadRight(9, " ") & CStr(dvTarjetaUno(intIndex)("Tienda")).PadRight(20, " ") & _
                                  CStr(Format(dvTarjetaUno(intIndex)("Monto"), "##########.#0")).PadLeft(16, " ") & _
                                  CStr("121000001").PadLeft(10, "0") & "    " & FechaCierre.ToShortDateString.Replace("/", "")
                txtWriter.WriteLine(strEncabezado)
                txtWriter.WriteLine("11" & CStr(dvTarjetaUno(intIndex)("FolioSAP")).PadLeft(10, "0") & CStr(dvTarjetaUno(intIndex)("Monto")).PadRight(16, " ") & "Venta Dia " & CDate(dvTarjetaUno(intIndex)("Fecha")).ToShortDateString.Replace("/", "") & CStr(dvTarjetaUno(intIndex)("ClienteID")).PadLeft(10, "0"))
            Next

            'Tarjeta 2
            dvTarjetaUno.RowFilter = "CodBanco like 'T2' and CodTipoVenta='S'"

            For intIndex = 0 To dvTarjetaUno.Count - 1
                strEncabezado = "40" & "TARJETA 2".PadRight(9, " ") & CStr(dvTarjetaUno(intIndex)("Tienda")).PadRight(20, " ") & _
                                  CStr(Format(dvTarjetaUno(intIndex)("Monto"), "##########.#0")).PadLeft(16, " ") & _
                                  CStr("121000001").PadRight(10, "0") & "    " & FechaCierre.ToShortDateString.Replace("/", "")
                txtWriter.WriteLine(strEncabezado)
                txtWriter.WriteLine("11" & CStr(dvTarjetaUno(intIndex)("FolioSAP")).PadLeft(10, "0") & CStr(dvTarjetaUno(intIndex)("Monto")).PadRight(16, " ") & "Venta Dia " & CDate(dvTarjetaUno(intIndex)("Fecha")).ToShortDateString.Replace("/", "") & CStr(dvTarjetaUno(intIndex)("ClienteID")).PadLeft(10, "0"))
            Next

            'Tarjeta 3
            dvTarjetaUno.RowFilter = "CodBanco like 'T3' and CodTipoVenta='S'"

            For intIndex = 0 To dvTarjetaUno.Count - 1
                strEncabezado = "40" & "TARJETA 3".PadRight(9, " ") & CStr(dvTarjetaUno(intIndex)("Tienda")).PadRight(20, " ") & _
                                  CStr(Format(dvTarjetaUno(intIndex)("Monto"), "##########.#0")).PadLeft(16, " ") & _
                                  CStr("121000001").PadRight(10, "0") & "    " & FechaCierre.ToShortDateString.Replace("/", "")
                txtWriter.WriteLine(strEncabezado)
                txtWriter.WriteLine("11" & CStr(dvTarjetaUno(intIndex)("FolioSAP")).PadLeft(10, "0") & CStr(dvTarjetaUno(intIndex)("Monto")).PadRight(16, " ") & "Venta Dia " & CDate(dvTarjetaUno(intIndex)("Fecha")).ToShortDateString.Replace("/", "") & CStr(dvTarjetaUno(intIndex)("ClienteID")).PadLeft(10, "0"))
            Next

            '*********************************FACTURACION FISCAL ******************************
            'Efectivo
            dvTarjetaUno.RowFilter = "CodFormasPago like 'EFEC' and CodTipoVenta='I'"

            For intIndex = 0 To dvTarjetaUno.Count - 1

                strEncabezado = "40" & "EFECTIVO".PadRight(9, " ") & CStr(dvTarjetaUno(intIndex)("Tienda")).PadRight(20, " ") & _
                                  CStr(Format(dvTarjetaUno(intIndex)("Monto"), "##########.#0")).PadLeft(16, " ") & _
                                  CStr("121000001").PadLeft(10, "0") & strNumRef
                txtWriter.WriteLine(strEncabezado)
                txtWriter.WriteLine("11" & CStr(dvTarjetaUno(intIndex)("FolioSAP")).PadLeft(10, "0") & CStr(dvTarjetaUno(intIndex)("Monto")).PadRight(16, " ") & "Venta Dia " & CDate(dvTarjetaUno(intIndex)("Fecha")).ToShortDateString.Replace("/", "") & CStr(dvTarjetaUno(intIndex)("ClienteID")).PadLeft(10, "0"))
            Next

            'Tarjeta 1
            dvTarjetaUno.RowFilter = "CodBanco like 'T1' and CodTipoVenta='I'"

            For intIndex = 0 To dvTarjetaUno.Count - 1
                strEncabezado = "40" & "TARJETA 1".PadRight(9, " ") & CStr(dvTarjetaUno(intIndex)("Tienda")).PadRight(20, " ") & _
                                  CStr(Format(dvTarjetaUno(intIndex)("Monto"), "##########.#0")).PadLeft(16, " ") & _
                                  CStr("121000001").PadLeft(10, "0") & "    " & FechaCierre.ToShortDateString.Replace("/", "")
                txtWriter.WriteLine(strEncabezado)
                txtWriter.WriteLine("11" & CStr(dvTarjetaUno(intIndex)("FolioSAP")).PadLeft(10, "0") & CStr(dvTarjetaUno(intIndex)("Monto")).PadRight(16, " ") & "Venta Dia " & CDate(dvTarjetaUno(intIndex)("Fecha")).ToShortDateString.Replace("/", "") & CStr(dvTarjetaUno(intIndex)("ClienteID")).PadLeft(10, "0"))
            Next

            'Tarjeta 2
            dvTarjetaUno.RowFilter = "CodBanco like 'T2' and CodTipoVenta='I'"

            For intIndex = 0 To dvTarjetaUno.Count - 1
                strEncabezado = "40" & "TARJETA 2".PadRight(9, " ") & CStr(dvTarjetaUno(intIndex)("Tienda")).PadRight(20, " ") & _
                                  CStr(Format(dvTarjetaUno(intIndex)("Monto"), "##########.#0")).PadLeft(16, " ") & _
                                  CStr("121000001").PadRight(10, "0") & "    " & FechaCierre.ToShortDateString.Replace("/", "")
                txtWriter.WriteLine(strEncabezado)
                txtWriter.WriteLine("11" & CStr(dvTarjetaUno(intIndex)("FolioSAP")).PadLeft(10, "0") & CStr(dvTarjetaUno(intIndex)("Monto")).PadRight(16, " ") & "Venta Dia " & CDate(dvTarjetaUno(intIndex)("Fecha")).ToShortDateString.Replace("/", "") & CStr(dvTarjetaUno(intIndex)("ClienteID")).PadLeft(10, "0"))
            Next

            'Tarjeta 3
            dvTarjetaUno.RowFilter = "CodBanco like 'T3' and CodTipoVenta='I'"

            For intIndex = 0 To dvTarjetaUno.Count - 1
                strEncabezado = "40" & "TARJETA 3".PadRight(9, " ") & CStr(dvTarjetaUno(intIndex)("Tienda")).PadRight(20, " ") & _
                                  CStr(Format(dvTarjetaUno(intIndex)("Monto"), "##########.#0")).PadLeft(16, " ") & _
                                  CStr("121000001").PadRight(10, "0") & "    " & FechaCierre.ToShortDateString.Replace("/", "")
                txtWriter.WriteLine(strEncabezado)
                txtWriter.WriteLine("11" & CStr(dvTarjetaUno(intIndex)("FolioSAP")).PadLeft(10, "0") & CStr(dvTarjetaUno(intIndex)("Monto")).PadRight(16, " ") & "Venta Dia " & CDate(dvTarjetaUno(intIndex)("Fecha")).ToShortDateString.Replace("/", "") & CStr(dvTarjetaUno(intIndex)("ClienteID")).PadLeft(10, "0"))
            Next

            txtWriter.Close()


            txtWriter = Nothing

            oMontarURed.Desconecta()
            oMontarURed.Desconecta()



        Catch ex As Exception
            Throw ex
        End Try

    End Sub
    Private Function GetNumRefBBV(ByVal strTienda As String) As String
        GetNumRefBBV = ""
        If strTienda = "001" Then
            GetNumRefBBV = "018452"
        ElseIf strTienda = "002" Then
            GetNumRefBBV = "038351"
        ElseIf strTienda = "003" Then
            GetNumRefBBV = "024021"
        ElseIf strTienda = "004" Then
            GetNumRefBBV = "999645"
        ElseIf strTienda = "005" Then
            GetNumRefBBV = "993713"
        ElseIf strTienda = "006" Then
            GetNumRefBBV = "996575"
        ElseIf strTienda = "007" Then
            GetNumRefBBV = "137468"
        ElseIf strTienda = "008" Then
            GetNumRefBBV = "136965"
            'ElseIf strTienda = "011" Then
            '    GetNumRefBBV = "137476"
        ElseIf strTienda = "012" Then
            GetNumRefBBV = "029566"
        ElseIf strTienda = "014" Then
            GetNumRefBBV = "038336"
        ElseIf strTienda = "015" Then
            GetNumRefBBV = "045422"
        ElseIf strTienda = "016" Then
            GetNumRefBBV = "048970"
        ElseIf strTienda = "017" Then
            GetNumRefBBV = "048988"
        ElseIf strTienda = "018" Then
            GetNumRefBBV = "136973"
        ElseIf strTienda = "019" Then
            GetNumRefBBV = "071584"
        ElseIf strTienda = "020" Then
            GetNumRefBBV = "080312"
        ElseIf strTienda = "021" Then
            GetNumRefBBV = "192206"
        ElseIf strTienda = "022" Then
            GetNumRefBBV = "099924"
        ElseIf strTienda = "023" Then
            GetNumRefBBV = "136957"
        ElseIf strTienda = "024" Then
            GetNumRefBBV = "102249"
        ElseIf strTienda = "025" Then
            GetNumRefBBV = "103981"
        ElseIf strTienda = "026" Then
            GetNumRefBBV = "107503"
        ElseIf strTienda = "027" Then
            GetNumRefBBV = "110192"
        ElseIf strTienda = "029" Then
            GetNumRefBBV = "119755"
        ElseIf strTienda = "030" Then
            GetNumRefBBV = "122890"
        ElseIf strTienda = "031" Then
            GetNumRefBBV = "129002"
        ElseIf strTienda = "032" Then
            GetNumRefBBV = "135603"
        ElseIf strTienda = "033" Then
            GetNumRefBBV = "148705"
        ElseIf strTienda = "034" Then
            GetNumRefBBV = "151097"
        ElseIf strTienda = "035" Then
            GetNumRefBBV = "155700"
        ElseIf strTienda = "036" Then
            GetNumRefBBV = "188743"
        ElseIf strTienda = "037" Then
            GetNumRefBBV = "179759"
        ElseIf strTienda = "039" Then
            GetNumRefBBV = "198213"
        ElseIf strTienda = "040" Then
            GetNumRefBBV = "204151"
        ElseIf strTienda = "041" Then
            GetNumRefBBV = "208384"
        ElseIf strTienda = "042" Then
            GetNumRefBBV = "229240"
        ElseIf strTienda = "043" Then
            GetNumRefBBV = "239108"
        ElseIf strTienda = "045" Then
            GetNumRefBBV = "244751"
        ElseIf strTienda = "046" Then
            GetNumRefBBV = "277066"
        ElseIf strTienda = "047" Then
            GetNumRefBBV = "277074"
        ElseIf strTienda = "048" Then
            GetNumRefBBV = "282413"
        ElseIf strTienda = "049" Then
            GetNumRefBBV = "282397"
        ElseIf strTienda = "050" Then
            GetNumRefBBV = "291505"
        ElseIf strTienda = "051" Then
            GetNumRefBBV = "294368"
        ElseIf strTienda = "052" Then
            GetNumRefBBV = "395371"
        ElseIf strTienda = "053" Then
            GetNumRefBBV = "422126"
        ElseIf strTienda = "054" Then
            GetNumRefBBV = "517764"
        ElseIf strTienda = "055" Then
            GetNumRefBBV = "576422"
        ElseIf strTienda = "056" Then
            GetNumRefBBV = "653601"
        ElseIf strTienda = "057" Then
            GetNumRefBBV = "045362"
        ElseIf strTienda = "058" Then
            GetNumRefBBV = "333846"
        ElseIf strTienda = "059" Then
            GetNumRefBBV = "935305"
        ElseIf strTienda = "060" Then
            GetNumRefBBV = "424959"
        ElseIf strTienda = "061" Then
            GetNumRefBBV = "499183"
        ElseIf strTienda = "062" Then
            GetNumRefBBV = "877055"
        ElseIf strTienda = "063" Then
            GetNumRefBBV = "630270"
        ElseIf strTienda = "064" Then
            GetNumRefBBV = "563780"
        ElseIf strTienda = "065" Then
            GetNumRefBBV = "618592"
        ElseIf strTienda = "066" Then
            GetNumRefBBV = "137476"
        End If
    End Function

    Private Sub sm_GenerateNotaCredito(ByVal dsNotas As DataSet, ByVal FechaCierre As Date, ByRef strMensaje As String)
        Dim dt As DataTable
        Dim strNumRefBBV As String = ""
        '----------------Numero de Referencia---------------
        Dim numref As New NumeroReferencia.cNumReferencia
        Dim strNumRef As String = numref.getNumReferencia(oParent.ApplicationContext.ApplicationConfiguration.Almacen.PadLeft(4, "0"), CStr(Format(FechaCierre.Date.Date, "ddMMyyyy")))
        '------------------------------------------------------
        strNumRefBBV = GetNumRefBBV(oParent.ApplicationContext.ApplicationConfiguration.Almacen)
        oProcesosSAPMgr = New ProcesoSAPManager(oParent.ApplicationContext, oParent.SAPApplicationConfig)
        oProcesosSAPMgr.ConfigCierreFI = oParent.ConfigSaveArchivos
        Dim oZBAPI_ABONO_CIERREDIA As ZBapiAbonoCierreDia
        Dim strResult As String = ""
        Dim fecha As String = ""
        Dim FechaRefBancos As Date = FechaCierre
        '------------------------------------------------------------------------------------------------------------------
        'FLIZARRAGA 01/11/2017: Se suben las devoluciones de las tarjetas de credito.
        '------------------------------------------------------------------------------------------------------------------
        Dim dtDevolucionesTarjetas As DataTable
        Dim fpago As DataRow = Nothing, devs() As DataRow = Nothing
        dtDevolucionesTarjetas = GetDevolucionesTarjetas(oParent.ApplicationContext.ApplicationConfiguration.Almacen, FechaCierre)

        Select Case FechaCierre.DayOfWeek
            Case DayOfWeek.Friday
                FechaRefBancos = FechaRefBancos.AddDays(3)
            Case DayOfWeek.Saturday
                FechaRefBancos = FechaRefBancos.AddDays(2)
            Case Else
                FechaRefBancos = FechaRefBancos.AddDays(1)
        End Select
        Dim oValeCajaMgr As New ValeCajaManager(oParent.ApplicationContext)
        Dim oValeCaja As ValeCaja.ValeCaja = Nothing
        '------------------------------------------------------------------------------------------
        'FLIZARRAGA 26/02/2016: Se suben las notas de credito de publico en general
        '------------------------------------------------------------------------------------------
        Dim dvNotasPublicoGeneral As New DataView(dsNotas.Tables(0))
        Dim dsBanco As DataSet = Nothing
        Dim fila As DataRow = Nothing
        Dim nota As DataRow = Nothing
        Dim rows() As DataRow = Nothing, Notas() As DataRow = Nothing
        Dim referencias As String = ""
        dvNotasPublicoGeneral.RowFilter = "CodTipoVenta='P'"
        dvNotasPublicoGeneral.Sort = "Referencia"
        dvNotasPublicoGeneral.RowStateFilter = DataViewRowState.CurrentRows
        If dvNotasPublicoGeneral.Count > 0 Then
            oZBAPI_ABONO_CIERREDIA = New ZBapiAbonoCierreDia
            oZBAPI_ABONO_CIERREDIA.Tienda = "T" & oParent.ApplicationContext.ApplicationConfiguration.Almacen
            oZBAPI_ABONO_CIERREDIA.Cliente = oParent.ApplicationContext.ApplicationConfiguration.Almacen.PadLeft(10, "0")
            oZBAPI_ABONO_CIERREDIA.Detalle = "X"
            oZBAPI_ABONO_CIERREDIA.MotivoPedido = "ZPG"
            oZBAPI_ABONO_CIERREDIA.Fecha = FechaCierre.ToString("yyyyMMdd")
            oZBAPI_ABONO_CIERREDIA.i_FactDpPro = "X"
            oZBAPI_ABONO_CIERREDIA.i_Mode = "N"
            oZBAPI_ABONO_CIERREDIA.Devolucion = True
            For Each row As DataRowView In dvNotasPublicoGeneral
                rows = oZBAPI_ABONO_CIERREDIA.Documents.Select("BSTNK='" & CStr(row("Referencia")) & "'")
                If rows.Length = 0 Then
                    fila = oZBAPI_ABONO_CIERREDIA.Documents.NewRow()
                    fila("BSTNK") = CStr(row("Referencia"))
                    oZBAPI_ABONO_CIERREDIA.Documents.Rows.Add(fila)
                    referencias &= "'" & CStr(row("Referencia")) & "',"
                End If
                nota = oZBAPI_ABONO_CIERREDIA.NotasCredito.NewRow()
                nota("NOTACREDITOID") = CStr(row("NotaCreditoID"))
                oZBAPI_ABONO_CIERREDIA.NotasCredito.Rows.Add(nota)
            Next
            If oZBAPI_ABONO_CIERREDIA.Documents.Rows.Count > 0 And oZBAPI_ABONO_CIERREDIA.NotasCredito.Rows.Count > 0 Then
                oProcesosSAPMgr.WRITE_ZBAPI_ABONO_CIERREDIA(oZBAPI_ABONO_CIERREDIA, dt)
                Dim strError As String = ""
                For Each row As DataRow In dt.Rows
                    If dt.Columns.Contains("TYPE") Then
                        If row.IsNull("TYPE") = False Then
                            If CStr(row("TYPE")) = "E" Or CStr(row("TYPE")) = "W" Then
                                strError &= CStr(row("MESSAGE"))
                            End If
                        End If
                    End If
                Next
                If strError.Trim() <> "" Then
                    strMensaje &= strError & vbCrLf
                End If
                For Each row As DataRow In oZBAPI_ABONO_CIERREDIA.NotasCredito.Rows
                    UpdateCompensarNotaCredito(CInt(row("NOTACREDITOID")))
                Next
            End If
        End If

        '------------------------------------------------------------------------------------------------------
        'FLIZARRAGA 03/11/2017: Se suben las devoluciones de tarjetas de publico en general
        '------------------------------------------------------------------------------------------------------
        Dim dvDevolucionPGeneral As New DataView(dtDevolucionesTarjetas)
        dvDevolucionPGeneral.RowFilter = "CodTipoVenta='P'"
        dvDevolucionPGeneral.Sort = "Referencia"
        dvDevolucionPGeneral.RowStateFilter = DataViewRowState.CurrentRows
        If dvDevolucionPGeneral.Count > 0 Then
            oZBAPI_ABONO_CIERREDIA = New ZBapiAbonoCierreDia
            oZBAPI_ABONO_CIERREDIA.Tienda = "T" & oParent.ApplicationContext.ApplicationConfiguration.Almacen
            oZBAPI_ABONO_CIERREDIA.Cliente = oParent.ApplicationContext.ApplicationConfiguration.Almacen.PadLeft(10, "0")
            oZBAPI_ABONO_CIERREDIA.Detalle = "X"
            oZBAPI_ABONO_CIERREDIA.MotivoPedido = "ZPG"
            oZBAPI_ABONO_CIERREDIA.Fecha = FechaCierre.ToString("yyyyMMdd")
            oZBAPI_ABONO_CIERREDIA.i_FactDpPro = "X"
            oZBAPI_ABONO_CIERREDIA.i_Mode = "N"
            oZBAPI_ABONO_CIERREDIA.Devolucion = True
            For Each row As DataRowView In dvDevolucionPGeneral
                rows = oZBAPI_ABONO_CIERREDIA.Documents.Select("BSTNK='" & CStr(row("Referencia")) & "'")
                If rows.Length = 0 Then
                    fila = oZBAPI_ABONO_CIERREDIA.Documents.NewRow()
                    fila("BSTNK") = CStr(row("Referencia"))
                    oZBAPI_ABONO_CIERREDIA.Documents.Rows.Add(fila)
                End If
                fpago = oZBAPI_ABONO_CIERREDIA.FormasPago.NewRow()

                fpago("BSTNK") = CStr(row("Referencia"))

                fpago("FPAGOID") = CStr(row("FormaPagoID"))
                fpago("REFBA") = strNumRef
                fpago("MONTO") = CDec(row("MontoPago"))
                fpago("RCAJA") = ""
                fpago("PAGEN") = ""
                fpago("SIHAY") = ""
                Select Case CStr(row("CodFormasPago"))
                    Case "EFEC"
                        fpago("TPAGO") = "DEVE"
                        fpago("CLCOB") = "DEVEEFEC"
                    Case "TACR"
                        Select Case CStr(row("CodBanco")).Trim()
                            Case "T1"
                                fpago("TPAGO") = "DEVT"
                                fpago("CLCOB") = "DEVTARBMX"
                                fpago("REFBA") = CStr(row("NoAfiliacion")) & Format(FechaCierre, "ddMMyy")
                            Case "T2"
                                fpago("TPAGO") = "DEVT"
                                fpago("CLCOB") = "DEVTARBMX"
                                fpago("REFBA") = CStr(row("NoAfiliacion")) & Format(FechaCierre, "ddMMyy")
                            Case "T3"
                                fpago("TPAGO") = "DEVT"
                                fpago("CLCOB") = "DEVTARBMX"
                                fpago("REFBA") = CStr(row("NoAfiliacion")) & Format(FechaCierre, "ddMMyy")
                            Case Else
                                fpago("TPAGO") = CStr(row("CodFormasPago"))
                                fpago("CLCOB") = ""
                        End Select
                    Case "TADB"
                        Select Case CStr(row("CodBanco")).Trim()
                            Case "T1"
                                fpago("TPAGO") = "DEVT"
                                fpago("CLCOB") = "DEVTARBMX"
                                fpago("REFBA") = CStr(row("NoAfiliacion")) & Format(FechaCierre, "ddMMyy")
                            Case "T2"
                                fpago("TPAGO") = "DEVT"
                                fpago("CLCOB") = "DEVTARBMX"
                                fpago("REFBA") = CStr(row("NoAfiliacion")) & Format(FechaCierre, "ddMMyy")
                            Case "T3"
                                fpago("TPAGO") = "DEVT"
                                fpago("CLCOB") = "DEVTARBMX"
                                fpago("REFBA") = CStr(row("NoAfiliacion")) & Format(FechaCierre, "ddMMyy")
                            Case Else
                                fpago("TPAGO") = CStr(row("CodFormasPago"))
                                fpago("CLCOB") = ""
                        End Select
                    Case "VCJA"
                        oValeCaja = oValeCajaMgr.GetByValeCajaId(CInt(row("DPValeID")))
                        fpago("RCAJA") = oValeCaja.FolioDocumento
                        fpago("TPAGO") = CStr(row("CodFormasPago"))
                        fpago("CLCOB") = ""
                        If oValeCaja.TipoDocumento.Trim() = "CP" Or oValeCaja.TipoDocumento.Trim() = "PI" Then fpago("SIHAY") = "X"
                    Case "DPPT"
                        fpago("TPAGO") = CStr(row("CodFormasPago"))
                        fpago("CLCOB") = "DPPUNTOS".PadRight(9, " ")
                    Case "DPCA"
                        fpago("TPAGO") = CStr(row("CodFormasPago"))
                        fpago("CLCOB") = "DPCARDCR".PadRight(9, " ")
                End Select
                fpago("COMPE") = "X"
                fpago("PAGEN") = ""
                dsBanco = Me.BancoSel(oZBAPI_ABONO_CIERREDIA.Tienda, CStr(fpago("CLCOB")))
                If dsBanco.Tables(0).Rows.Count > 0 Then
                    fpago("BANCO") = dsBanco.Tables(0).Rows(0)!Banco
                Else
                    fpago("BANCO") = ""
                End If
                oZBAPI_ABONO_CIERREDIA.FormasPago.Rows.Add(fpago)

                Notas = oZBAPI_ABONO_CIERREDIA.NotasCredito.Select("NOTACREDITOID=" & CStr(row("NotaCreditoId")))
                If Notas.Length = 0 Then
                    nota = oZBAPI_ABONO_CIERREDIA.NotasCredito.NewRow()
                    nota("NOTACREDITOID") = CStr(row("NotaCreditoID"))
                    oZBAPI_ABONO_CIERREDIA.NotasCredito.Rows.Add(nota)
                End If
            Next
            If oZBAPI_ABONO_CIERREDIA.Documents.Rows.Count > 0 And oZBAPI_ABONO_CIERREDIA.NotasCredito.Rows.Count > 0 Then
                oProcesosSAPMgr.WRITE_ZBAPI_ABONO_CIERREDIA(oZBAPI_ABONO_CIERREDIA, dt)
                Dim strError As String = ""
                For Each row As DataRow In dt.Rows
                    If dt.Columns.Contains("TYPE") Then
                        If row.IsNull("TYPE") = False Then
                            If CStr(row("TYPE")) = "E" Or CStr(row("TYPE")) = "W" Then
                                strError &= CStr(row("MESSAGE"))
                            End If
                        End If
                    End If
                Next
                If strError.Trim() <> "" Then
                    strMensaje &= strError & vbCrLf
                End If
                For Each row As DataRow In oZBAPI_ABONO_CIERREDIA.NotasCredito.Rows
                    UpdateCompensarNotaCredito(CInt(row("NOTACREDITOID")))
                    UpdateCompensarDevolucionesTarjeta(CInt(row("NOTACREDITOID")))
                Next
            End If
        End If

        '------------------------------------------------------------------------------------------------------
        'FLIZARRAGA 26/02/2016: Se suben las notas de credito de DIPS
        '------------------------------------------------------------------------------------------------------
        Dim dvVentasDips As New DataView(dsNotas.Tables(0))
        dvVentasDips.RowFilter = "CodTipoVenta='D'"
        dvVentasDips.Sort = "ClienteId"
        dvVentasDips.RowStateFilter = DataViewRowState.CurrentRows
        Dim ClienteId As String = ""
        If dvVentasDips.Count > 0 Then
            For Each row As DataRowView In dvVentasDips
                If ClienteId <> CStr(row("ClienteId")) Then
                    If ClienteId <> "" Then
                        oProcesosSAPMgr.WRITE_ZBAPI_ABONO_CIERREDIA(oZBAPI_ABONO_CIERREDIA, dt)
                        Dim strError As String = ""
                        For Each rowErr As DataRow In dt.Rows
                            If dt.Columns.Contains("TYPE") Then
                                If rowErr.IsNull("TYPE") = False Then
                                    If CStr(rowErr("TYPE")) = "E" Or CStr(rowErr("TYPE")) = "W" Then
                                        strError &= CStr(rowErr("MESSAGE"))
                                    End If
                                End If
                            End If
                        Next
                        If strError.Trim() <> "" Then
                            strMensaje &= strError & vbCrLf
                        End If
                        For Each rowNota As DataRow In oZBAPI_ABONO_CIERREDIA.NotasCredito.Rows
                            UpdateCompensarNotaCredito(CInt(rowNota("NOTACREDITOID")))
                        Next
                    End If
                    ClienteId = CStr(row("ClienteId"))
                    oZBAPI_ABONO_CIERREDIA = New ZBapiAbonoCierreDia
                    oZBAPI_ABONO_CIERREDIA.Tienda = "T" & oParent.ApplicationContext.ApplicationConfiguration.Almacen
                    oZBAPI_ABONO_CIERREDIA.Cliente = oParent.ApplicationContext.ApplicationConfiguration.Almacen.PadLeft(10, "0")
                    oZBAPI_ABONO_CIERREDIA.MotivoPedido = "ZDC"
                    oZBAPI_ABONO_CIERREDIA.Fecha = FechaCierre.ToString("yyyyMMdd")
                    oZBAPI_ABONO_CIERREDIA.i_FactDpPro = "X"
                    oZBAPI_ABONO_CIERREDIA.i_Mode = "N"
                    oZBAPI_ABONO_CIERREDIA.Devolucion = True
                End If
                rows = oZBAPI_ABONO_CIERREDIA.Documents.Select("BSTNK='" & CStr(row("Referencia")) & "'")
                If rows.Length = 0 Then
                    fila = oZBAPI_ABONO_CIERREDIA.Documents.NewRow()
                    fila("BSTNK") = CStr(row("Referencia"))
                    oZBAPI_ABONO_CIERREDIA.Documents.Rows.Add(fila)
                End If
                nota = oZBAPI_ABONO_CIERREDIA.NotasCredito.NewRow()
                nota("NOTACREDITOID") = CStr(row("NotaCreditoID"))
                oZBAPI_ABONO_CIERREDIA.NotasCredito.Rows.Add(nota)
            Next
            oProcesosSAPMgr.WRITE_ZBAPI_ABONO_CIERREDIA(oZBAPI_ABONO_CIERREDIA, dt)
            Dim strErr As String = ""
            For Each rowErr As DataRow In dt.Rows
                If dt.Columns.Contains("TYPE") Then
                    If rowErr.IsNull("TYPE") = False Then
                        If CStr(rowErr("TYPE")) = "E" Or CStr(rowErr("TYPE")) = "W" Then
                            strErr &= CStr(rowErr("MESSAGE"))
                        End If
                    End If
                End If
            Next
            If strErr.Trim() <> "" Then
                strMensaje &= strErr & vbCrLf
            End If
            For Each rowNota As DataRow In oZBAPI_ABONO_CIERREDIA.NotasCredito.Rows
                UpdateCompensarNotaCredito(CInt(rowNota("NOTACREDITOID")))
            Next
        End If
        '------------------------------------------------------------------------------------------------------
        'FLIZARRAGA 03/11/2017: Se suben las devoluciones de tarjetas de DIPS
        '------------------------------------------------------------------------------------------------------
        Dim dvDevolucionDips As New DataView(dtDevolucionesTarjetas)
        dvDevolucionDips.RowFilter = "CodTipoVenta='D'"
        dvDevolucionDips.Sort = "Referencia"
        dvDevolucionDips.RowStateFilter = DataViewRowState.CurrentRows
        ClienteId = ""
        If dvDevolucionDips.Count > 0 Then
            For Each row As DataRowView In dvDevolucionDips
                If ClienteId <> CStr(row("ClienteId")) Then
                    If ClienteId <> "" Then
                        oProcesosSAPMgr.WRITE_ZBAPI_ABONO_CIERREDIA(oZBAPI_ABONO_CIERREDIA, dt)
                        Dim strError As String = ""
                        For Each rowErr As DataRow In dt.Rows
                            If dt.Columns.Contains("TYPE") Then
                                If rowErr.IsNull("TYPE") = False Then
                                    If CStr(rowErr("TYPE")) = "E" Or CStr(rowErr("TYPE")) = "W" Then
                                        strError &= CStr(rowErr("MESSAGE"))
                                    End If
                                End If
                            End If
                        Next
                        If strError.Trim() <> "" Then
                            strMensaje &= strError & vbCrLf
                        End If
                        For Each rowNota As DataRow In oZBAPI_ABONO_CIERREDIA.NotasCredito.Rows
                            UpdateCompensarNotaCredito(CInt(rowNota("NOTACREDITOID")))
                            UpdateCompensarDevolucionesTarjeta(CInt(rowNota("NOTACREDITOID")))
                        Next
                    End If
                    ClienteId = CStr(row("ClienteId"))
                    oZBAPI_ABONO_CIERREDIA = New ZBapiAbonoCierreDia
                    oZBAPI_ABONO_CIERREDIA.Tienda = "T" & oParent.ApplicationContext.ApplicationConfiguration.Almacen
                    oZBAPI_ABONO_CIERREDIA.Cliente = oParent.ApplicationContext.ApplicationConfiguration.Almacen.PadLeft(10, "0")
                    oZBAPI_ABONO_CIERREDIA.MotivoPedido = "ZDC"
                    oZBAPI_ABONO_CIERREDIA.Fecha = FechaCierre.ToString("yyyyMMdd")
                    oZBAPI_ABONO_CIERREDIA.i_FactDpPro = "X"
                    oZBAPI_ABONO_CIERREDIA.i_Mode = "N"
                    oZBAPI_ABONO_CIERREDIA.Devolucion = True
                End If
                rows = oZBAPI_ABONO_CIERREDIA.Documents.Select("BSTNK='" & CStr(row("Referencia")) & "'")
                If rows.Length = 0 Then
                    fila = oZBAPI_ABONO_CIERREDIA.Documents.NewRow()
                    fila("BSTNK") = CStr(row("Referencia"))
                    oZBAPI_ABONO_CIERREDIA.Documents.Rows.Add(fila)
                End If
                fpago = oZBAPI_ABONO_CIERREDIA.FormasPago.NewRow()

                fpago("BSTNK") = CStr(row("Referencia"))

                fpago("FPAGOID") = CStr(row("FormaPagoID"))
                fpago("REFBA") = strNumRef
                fpago("MONTO") = CDec(row("MontoPago"))
                fpago("RCAJA") = ""
                fpago("PAGEN") = ""
                fpago("SIHAY") = ""
                Select Case CStr(row("CodFormasPago"))
                    Case "EFEC"
                        fpago("TPAGO") = "DEVE"
                        fpago("CLCOB") = "DEVEEFEC"
                    Case "TACR"
                        Select Case CStr(row("CodBanco")).Trim()
                            Case "T1"
                                fpago("TPAGO") = "DEVT"
                                fpago("CLCOB") = "DEVTARBMX"
                                fpago("REFBA") = CStr(row("NoAfiliacion")) & Format(FechaCierre, "ddMMyy")
                            Case "T2"
                                fpago("TPAGO") = "DEVT"
                                fpago("CLCOB") = "DEVTARBMX"
                                fpago("REFBA") = CStr(row("NoAfiliacion")) & Format(FechaCierre, "ddMMyy")
                            Case "T3"
                                fpago("TPAGO") = "DEVT"
                                fpago("CLCOB") = "DEVTARBMX"
                                fpago("REFBA") = CStr(row("NoAfiliacion")) & Format(FechaCierre, "ddMMyy")
                            Case Else
                                fpago("TPAGO") = CStr(row("CodFormasPago"))
                                fpago("CLCOB") = ""
                        End Select
                    Case "TADB"
                        Select Case CStr(row("CodBanco")).Trim()
                            Case "T1"
                                fpago("TPAGO") = "DEVT"
                                fpago("CLCOB") = "DEVTARBMX"
                                fpago("REFBA") = CStr(row("NoAfiliacion")) & Format(FechaCierre, "ddMMyy")
                            Case "T2"
                                fpago("TPAGO") = "DEVT"
                                fpago("CLCOB") = "DEVTARBMX"
                                fpago("REFBA") = CStr(row("NoAfiliacion")) & Format(FechaCierre, "ddMMyy")
                            Case "T3"
                                fpago("TPAGO") = "DEVT"
                                fpago("CLCOB") = "DEVTARBMX"
                                fpago("REFBA") = CStr(row("NoAfiliacion")) & Format(FechaCierre, "ddMMyy")
                            Case Else
                                fpago("TPAGO") = CStr(row("CodFormasPago"))
                                fpago("CLCOB") = ""
                        End Select
                    Case "VCJA"
                        oValeCaja = oValeCajaMgr.GetByValeCajaId(CInt(row("DPValeID")))
                        fpago("RCAJA") = oValeCaja.FolioDocumento
                        fpago("TPAGO") = CStr(row("CodFormasPago"))
                        fpago("CLCOB") = ""
                        If oValeCaja.TipoDocumento.Trim() = "CP" Or oValeCaja.TipoDocumento.Trim() = "PI" Then fpago("SIHAY") = "X"
                    Case "DPPT"
                        fpago("TPAGO") = CStr(row("CodFormasPago"))
                        fpago("CLCOB") = "DPPUNTOS".PadRight(9, " ")
                    Case "DPCA"
                        fpago("TPAGO") = CStr(row("CodFormasPago"))
                        fpago("CLCOB") = "DPCARDCR".PadRight(9, " ")
                End Select
                fpago("COMPE") = "X"
                fpago("PAGEN") = ""
                dsBanco = Me.BancoSel(oZBAPI_ABONO_CIERREDIA.Tienda, CStr(fpago("CLCOB")))
                If dsBanco.Tables(0).Rows.Count > 0 Then
                    fpago("BANCO") = dsBanco.Tables(0).Rows(0)!Banco
                Else
                    fpago("BANCO") = ""
                End If
                oZBAPI_ABONO_CIERREDIA.FormasPago.Rows.Add(fpago)

                Notas = oZBAPI_ABONO_CIERREDIA.NotasCredito.Select("NOTACREDITOID=" & CStr(row("NotaCreditoId")))
                If Notas.Length = 0 Then
                    nota = oZBAPI_ABONO_CIERREDIA.NotasCredito.NewRow()
                    nota("NOTACREDITOID") = CStr(row("NotaCreditoID"))
                    oZBAPI_ABONO_CIERREDIA.NotasCredito.Rows.Add(nota)
                End If
            Next
            If oZBAPI_ABONO_CIERREDIA.Documents.Rows.Count > 0 AndAlso oZBAPI_ABONO_CIERREDIA.NotasCredito.Rows.Count > 0 Then
                oProcesosSAPMgr.WRITE_ZBAPI_ABONO_CIERREDIA(oZBAPI_ABONO_CIERREDIA, dt)
                Dim strErr As String = ""
                For Each rowErr As DataRow In dt.Rows
                    If dt.Columns.Contains("TYPE") Then
                        If rowErr.IsNull("TYPE") = False Then
                            If CStr(rowErr("TYPE")) = "E" Or CStr(rowErr("TYPE")) = "W" Then
                                strErr &= CStr(rowErr("MESSAGE"))
                            End If
                        End If
                    End If
                Next
                If strErr.Trim() <> "" Then
                    strMensaje &= strErr & vbCrLf
                End If
                For Each rowNota As DataRow In oZBAPI_ABONO_CIERREDIA.NotasCredito.Rows
                    UpdateCompensarNotaCredito(CInt(rowNota("NOTACREDITOID")))
                    UpdateCompensarDevolucionesTarjeta(CInt(rowNota("NOTACREDITOID")))
                Next
            End If
        End If

        '------------------------------------------------------------------------------------------------------------------
        'FLIZARRAGA 27/02/2016: Se suben las notas de credito de Facilito
        '------------------------------------------------------------------------------------------------------------------
        Dim dvVentasFacilito As New DataView(dsNotas.Tables(0))
        dvVentasFacilito.RowFilter = "CodTipoVenta='O'"
        dvVentasFacilito.Sort = "Referencia"
        dvVentasFacilito.RowStateFilter = DataViewRowState.CurrentRows
        If dvVentasFacilito.Count > 0 Then
            oZBAPI_ABONO_CIERREDIA = New ZBapiAbonoCierreDia
            oZBAPI_ABONO_CIERREDIA.Tienda = "T" & oParent.ApplicationContext.ApplicationConfiguration.Almacen
            oZBAPI_ABONO_CIERREDIA.Cliente = oParent.ApplicationContext.ApplicationConfiguration.Almacen.PadLeft(10, "0")
            oZBAPI_ABONO_CIERREDIA.MotivoPedido = "ZFA"
            oZBAPI_ABONO_CIERREDIA.Fecha = FechaCierre.ToString("yyyyMMdd")
            oZBAPI_ABONO_CIERREDIA.i_FactDpPro = "X"
            oZBAPI_ABONO_CIERREDIA.i_Mode = "N"
            oZBAPI_ABONO_CIERREDIA.Devolucion = True
            For Each row As DataRowView In dvVentasFacilito
                rows = oZBAPI_ABONO_CIERREDIA.Documents.Select("BSTNK='" & CStr(row("Referencia")) & "'")
                If rows.Length = 0 Then
                    fila = oZBAPI_ABONO_CIERREDIA.Documents.NewRow()
                    fila("BSTNK") = CStr(row("Referencia"))
                    oZBAPI_ABONO_CIERREDIA.Documents.Rows.Add(fila)
                End If
                nota = oZBAPI_ABONO_CIERREDIA.NotasCredito.NewRow()
                nota("NOTACREDITOID") = CStr(row("NotaCreditoID"))
                oZBAPI_ABONO_CIERREDIA.NotasCredito.Rows.Add(nota)
            Next
            oProcesosSAPMgr.WRITE_ZBAPI_ABONO_CIERREDIA(oZBAPI_ABONO_CIERREDIA, dt)
            Dim strError As String = ""
            For Each row As DataRow In dt.Rows
                If dt.Columns.Contains("TYPE") Then
                    If row.IsNull("TYPE") = False Then
                        If CStr(row("TYPE")) = "E" Or CStr(row("TYPE")) = "W" Then
                            strError &= CStr(row("MESSAGE"))
                        End If
                    End If
                End If
            Next
            If strError.Trim() <> "" Then
                strMensaje &= strError & vbCrLf
            End If
            For Each row As DataRow In oZBAPI_ABONO_CIERREDIA.NotasCredito.Rows
                UpdateCompensarNotaCredito(CInt(row("NOTACREDITOID")))
            Next
        End If

        '------------------------------------------------------------------------------------------------------------------
        'FLIZARRAGA 27/02/2016: Se suben las Notas de credito de DPVale
        '------------------------------------------------------------------------------------------------------------------
        Dim dvVentasDPVale As New DataView(dsNotas.Tables(0))
        dvVentasDPVale.RowFilter = "CodTipoVenta='V'"
        dvVentasDPVale.Sort = "Referencia"
        dvVentasDPVale.RowStateFilter = DataViewRowState.CurrentRows
        If dvVentasDPVale.Count > 0 Then
            oZBAPI_ABONO_CIERREDIA = New ZBapiAbonoCierreDia
            oZBAPI_ABONO_CIERREDIA.Tienda = "T" & oParent.ApplicationContext.ApplicationConfiguration.Almacen
            oZBAPI_ABONO_CIERREDIA.Cliente = oParent.ApplicationContext.ApplicationConfiguration.Almacen.PadLeft(10, "0")
            oZBAPI_ABONO_CIERREDIA.MotivoPedido = "ZDV"
            oZBAPI_ABONO_CIERREDIA.Fecha = FechaCierre.ToString("yyyyMMdd")
            oZBAPI_ABONO_CIERREDIA.i_FactDpPro = "X"
            oZBAPI_ABONO_CIERREDIA.i_Mode = "N"
            oZBAPI_ABONO_CIERREDIA.Devolucion = True
            For Each row As DataRowView In dvVentasDPVale
                rows = oZBAPI_ABONO_CIERREDIA.Documents.Select("BSTNK='" & CStr(row("Referencia")) & "'")
                If rows.Length = 0 Then
                    fila = oZBAPI_ABONO_CIERREDIA.Documents.NewRow()
                    fila("BSTNK") = CStr(row("Referencia"))
                    oZBAPI_ABONO_CIERREDIA.Documents.Rows.Add(fila)
                End If
                nota = oZBAPI_ABONO_CIERREDIA.NotasCredito.NewRow()
                nota("NOTACREDITOID") = CStr(row("NotaCreditoID"))
                oZBAPI_ABONO_CIERREDIA.NotasCredito.Rows.Add(nota)
            Next
            oProcesosSAPMgr.WRITE_ZBAPI_ABONO_CIERREDIA(oZBAPI_ABONO_CIERREDIA, dt)
            Dim strError As String = ""
            For Each row As DataRow In dt.Rows
                If dt.Columns.Contains("TYPE") Then
                    If row.IsNull("TYPE") = False Then
                        If CStr(row("TYPE")) = "E" Or CStr(row("TYPE")) = "W" Then
                            strError &= CStr(row("MESSAGE"))
                        End If
                    End If
                End If
            Next
            If strError.Trim() <> "" Then
                strMensaje &= strError & vbCrLf
            End If
            For Each row As DataRow In oZBAPI_ABONO_CIERREDIA.NotasCredito.Rows
                UpdateCompensarNotaCredito(CInt(row("NOTACREDITOID")))
            Next
        End If

        '------------------------------------------------------------------------------------------------------------------
        'FLIZARRAGA 27/02/2016: Se suben las notas de credito  de socios
        '------------------------------------------------------------------------------------------------------------------
        Dim dvVentasSocios As New DataView(dsNotas.Tables(0))
        dvVentasSocios.RowFilter = "CodTipoVenta='S'"
        dvVentasSocios.Sort = "Referencia"
        dvVentasSocios.RowStateFilter = DataViewRowState.CurrentRows
        If dvVentasSocios.Count > 0 Then
            oZBAPI_ABONO_CIERREDIA = New ZBapiAbonoCierreDia
            oZBAPI_ABONO_CIERREDIA.Tienda = "T" & oParent.ApplicationContext.ApplicationConfiguration.Almacen
            oZBAPI_ABONO_CIERREDIA.Cliente = oParent.ApplicationContext.ApplicationConfiguration.Almacen.PadLeft(10, "0")
            oZBAPI_ABONO_CIERREDIA.MotivoPedido = "ZDC"
            oZBAPI_ABONO_CIERREDIA.Fecha = FechaCierre.ToString("yyyyMMdd")
            oZBAPI_ABONO_CIERREDIA.i_FactDpPro = "X"
            oZBAPI_ABONO_CIERREDIA.i_Mode = "N"
            oZBAPI_ABONO_CIERREDIA.Devolucion = True
            For Each row As DataRowView In dvVentasSocios
                rows = oZBAPI_ABONO_CIERREDIA.Documents.Select("BSTNK='" & CStr(row("Referencia")) & "'")
                If rows.Length = 0 Then
                    fila = oZBAPI_ABONO_CIERREDIA.Documents.NewRow()
                    fila("BSTNK") = CStr(row("Referencia"))
                    oZBAPI_ABONO_CIERREDIA.Documents.Rows.Add(fila)
                End If
                nota = oZBAPI_ABONO_CIERREDIA.NotasCredito.NewRow()
                nota("NOTACREDITOID") = CStr(row("NotaCreditoID"))
                oZBAPI_ABONO_CIERREDIA.NotasCredito.Rows.Add(nota)
            Next
            oProcesosSAPMgr.WRITE_ZBAPI_ABONO_CIERREDIA(oZBAPI_ABONO_CIERREDIA, dt)
            Dim strError As String = ""
            For Each row As DataRow In dt.Rows
                If dt.Columns.Contains("TYPE") Then
                    If row.IsNull("TYPE") = False Then
                        If CStr(row("TYPE")) = "E" Or CStr(row("TYPE")) = "W" Then
                            strError &= CStr(row("MESSAGE"))
                        End If
                    End If
                End If
            Next
            If strError.Trim() <> "" Then
                strMensaje &= strError & vbCrLf
            End If
            For Each row As DataRow In oZBAPI_ABONO_CIERREDIA.NotasCredito.Rows
                UpdateCompensarNotaCredito(CInt(row("NOTACREDITOID")))
            Next
        End If

        '------------------------------------------------------------------------------------------------------------------
        'FLIZARRAGA 27/02/2016: Se suben los pagos de Apartados
        '------------------------------------------------------------------------------------------------------------------
        Dim dvVentasApartados As New DataView(dsNotas.Tables(0))
        dvVentasApartados.RowFilter = "CodTipoVenta='A'"
        dvVentasApartados.Sort = "Referencia"
        dvVentasApartados.RowStateFilter = DataViewRowState.CurrentRows
        If dvVentasApartados.Count > 0 Then
            oZBAPI_ABONO_CIERREDIA = New ZBapiAbonoCierreDia
            oZBAPI_ABONO_CIERREDIA.Tienda = "T" & oParent.ApplicationContext.ApplicationConfiguration.Almacen
            oZBAPI_ABONO_CIERREDIA.Cliente = oParent.ApplicationContext.ApplicationConfiguration.Almacen.PadLeft(10, "0")
            oZBAPI_ABONO_CIERREDIA.MotivoPedido = "ZAP"
            oZBAPI_ABONO_CIERREDIA.Fecha = FechaCierre.ToString("yyyyMMdd")
            oZBAPI_ABONO_CIERREDIA.i_FactDpPro = "X"
            oZBAPI_ABONO_CIERREDIA.i_Mode = "N"
            oZBAPI_ABONO_CIERREDIA.Devolucion = True
            Dim contratoMgr As New ContratoManager(oParent.ApplicationContext)
            Dim saldoSaldado As Decimal = 0
            For Each row As DataRowView In dvVentasApartados
                rows = oZBAPI_ABONO_CIERREDIA.Documents.Select("BSTNK='" & CStr(row("Referencia")) & "'")
                If rows.Length = 0 Then
                    fila = oZBAPI_ABONO_CIERREDIA.Documents.NewRow()
                    fila("BSTNK") = CStr(row("Referencia"))
                    oZBAPI_ABONO_CIERREDIA.Documents.Rows.Add(fila)
                End If
                nota = oZBAPI_ABONO_CIERREDIA.NotasCredito.NewRow()
                nota("NOTACREDITOID") = CStr(row("NotaCreditoID"))
                oZBAPI_ABONO_CIERREDIA.NotasCredito.Rows.Add(nota)
            Next
            oProcesosSAPMgr.WRITE_ZBAPI_ABONO_CIERREDIA(oZBAPI_ABONO_CIERREDIA, dt)
            Dim strError As String = ""
            For Each row As DataRow In dt.Rows
                If dt.Columns.Contains("TYPE") Then
                    If row.IsNull("TYPE") = False Then
                        If CStr(row("TYPE")) = "E" Or CStr(row("TYPE")) = "W" Then
                            strError &= CStr(row("MESSAGE"))
                        End If
                    End If
                End If
            Next
            If strError.Trim() <> "" Then
                strMensaje &= strError & vbCrLf
            End If
            For Each row As DataRow In oZBAPI_ABONO_CIERREDIA.NotasCredito.Rows
                UpdateCompensarNotaCredito(CInt(row("NOTACREDITOID")))
            Next
        End If

        '------------------------------------------------------------------------------------------------------------------
        'FLIZARRAGA 27/02/2016: Se suben las notas de credito pagos de Fonacot
        '------------------------------------------------------------------------------------------------------------------
        Dim dvVentasFonacot As New DataView(dsNotas.Tables(0))
        dvVentasFonacot.RowFilter = "CodTipoVenta='K' OR CodTipoVenta='F'"
        dvVentasFonacot.Sort = "Referencia"
        dvVentasFonacot.RowStateFilter = DataViewRowState.CurrentRows
        If dvVentasFonacot.Count > 0 Then
            oZBAPI_ABONO_CIERREDIA = New ZBapiAbonoCierreDia
            oZBAPI_ABONO_CIERREDIA.Tienda = "T" & oParent.ApplicationContext.ApplicationConfiguration.Almacen
            oZBAPI_ABONO_CIERREDIA.Cliente = oParent.ApplicationContext.ApplicationConfiguration.Almacen.PadLeft(10, "0")
            oZBAPI_ABONO_CIERREDIA.MotivoPedido = "ZFO"
            oZBAPI_ABONO_CIERREDIA.Fecha = FechaCierre.ToString("yyyyMMdd")
            oZBAPI_ABONO_CIERREDIA.i_FactDpPro = "X"
            oZBAPI_ABONO_CIERREDIA.i_Mode = "N"
            oZBAPI_ABONO_CIERREDIA.Devolucion = True
            Dim contratoMgr As New ContratoManager(oParent.ApplicationContext)
            For Each row As DataRowView In dvVentasFonacot
                rows = oZBAPI_ABONO_CIERREDIA.Documents.Select("BSTNK='" & CStr(row("Referencia")) & "'")
                If rows.Length = 0 Then
                    fila = oZBAPI_ABONO_CIERREDIA.Documents.NewRow()
                    fila("BSTNK") = CStr(row("Referencia"))
                    oZBAPI_ABONO_CIERREDIA.Documents.Rows.Add(fila)
                End If
                nota = oZBAPI_ABONO_CIERREDIA.NotasCredito.NewRow()
                nota("NOTACREDITOID") = CStr(row("NotaCreditoID"))
                oZBAPI_ABONO_CIERREDIA.NotasCredito.Rows.Add(nota)
            Next
            oProcesosSAPMgr.WRITE_ZBAPI_ABONO_CIERREDIA(oZBAPI_ABONO_CIERREDIA, dt)
            Dim strError As String = ""
            For Each row As DataRow In dt.Rows
                If dt.Columns.Contains("TYPE") Then
                    If row.IsNull("TYPE") = False Then
                        If CStr(row("TYPE")) = "E" Or CStr(row("TYPE")) = "W" Then
                            strError &= CStr(row("MESSAGE"))
                        End If
                    End If
                End If
            Next
            If strError.Trim() <> "" Then
                strMensaje &= strError & vbCrLf
            End If
            For Each row As DataRow In oZBAPI_ABONO_CIERREDIA.NotasCredito.Rows
                UpdateCompensarNotaCredito(CInt(row("NOTACREDITOID")))
            Next
        End If
        '------------------------------------------------------------------------------------------------------------------
        'FLIZARRAGA 27/02/2016: Se suben las notas de credito de Ventas de Empleados
        '------------------------------------------------------------------------------------------------------------------

        Dim dvVentasEmpleados As New DataView(dsNotas.Tables(0))
        dvVentasEmpleados.RowFilter = "CodTipoVenta='E'"
        dvVentasEmpleados.Sort = "Referencia"
        dvVentasEmpleados.RowStateFilter = DataViewRowState.CurrentRows
        If dvVentasEmpleados.Count > 0 Then
            oZBAPI_ABONO_CIERREDIA = New ZBapiAbonoCierreDia
            oZBAPI_ABONO_CIERREDIA.Tienda = "T" & oParent.ApplicationContext.ApplicationConfiguration.Almacen
            oZBAPI_ABONO_CIERREDIA.Cliente = oParent.ApplicationContext.ApplicationConfiguration.Almacen.PadLeft(10, "0")
            oZBAPI_ABONO_CIERREDIA.MotivoPedido = "ZDET"
            oZBAPI_ABONO_CIERREDIA.Fecha = FechaCierre.ToString("yyyyMMdd")
            oZBAPI_ABONO_CIERREDIA.i_FactDpPro = "X"
            oZBAPI_ABONO_CIERREDIA.i_Mode = "N"
            oZBAPI_ABONO_CIERREDIA.Devolucion = True
            Dim contratoMgr As New ContratoManager(oParent.ApplicationContext)
            For Each row As DataRowView In dvVentasEmpleados
                rows = oZBAPI_ABONO_CIERREDIA.Documents.Select("BSTNK='" & CStr(row("Referencia")) & "'")
                If rows.Length = 0 Then
                    fila = oZBAPI_ABONO_CIERREDIA.Documents.NewRow()
                    fila("BSTNK") = CStr(row("Referencia"))
                    oZBAPI_ABONO_CIERREDIA.Documents.Rows.Add(fila)
                End If
                nota = oZBAPI_ABONO_CIERREDIA.NotasCredito.NewRow()
                nota("NOTACREDITOID") = CStr(row("NotaCreditoID"))
                oZBAPI_ABONO_CIERREDIA.NotasCredito.Rows.Add(nota)
            Next
            oProcesosSAPMgr.WRITE_ZBAPI_ABONO_CIERREDIA(oZBAPI_ABONO_CIERREDIA, dt)
            Dim strError As String = ""
            For Each row As DataRow In dt.Rows
                If dt.Columns.Contains("TYPE") Then
                    If row.IsNull("TYPE") = False Then
                        If CStr(row("TYPE")) = "E" Or CStr(row("TYPE")) = "W" Then
                            strError &= CStr(row("MESSAGE"))
                        End If
                    End If
                End If
            Next
            If strError.Trim() <> "" Then
                strMensaje &= strError & vbCrLf
            End If
            For Each row As DataRow In oZBAPI_ABONO_CIERREDIA.NotasCredito.Rows
                UpdateCompensarNotaCredito(CInt(row("NOTACREDITOID")))
            Next
        End If
        '------------------------------------------------------------------------------------------------------
        'FLIZARRAGA 26/02/2016: Se Suben las notas de Pagos de Facturación Fiscal
        '------------------------------------------------------------------------------------------------------
        Dim dvVentasFF As New DataView(dsNotas.Tables(0))
        Dim NotaCreditoId As String = ""
        dvVentasFF.RowFilter = "CodTipoVenta='I'"
        dvVentasFF.Sort = "NotaCreditoID"
        dvVentasFF.RowStateFilter = DataViewRowState.CurrentRows
        If dvVentasFF.Count > 0 Then
            Dim strError As String = ""
            For Each row As DataRowView In dvVentasFF
                If NotaCreditoId <> CStr(CStr(row("NotaCreditoID"))) Then
                    If NotaCreditoId <> "" Then
                        oProcesosSAPMgr.WRITE_ZBAPI_ABONO_CIERREDIA(oZBAPI_ABONO_CIERREDIA, dt)
                        For Each rowMsg As DataRow In dt.Rows
                            If dt.Columns.Contains("TYPE") Then
                                If rowMsg.IsNull("TYPE") = False Then
                                    If CStr(rowMsg("TYPE")) = "E" Or CStr(rowMsg("TYPE")) = "W" Then
                                        strError &= CStr(rowMsg("MESSAGE"))
                                    End If
                                End If
                            End If
                        Next
                        If strError.Trim() <> "" Then
                            strMensaje &= strError & vbCrLf
                        End If
                        For Each rowNota As DataRow In oZBAPI_ABONO_CIERREDIA.NotasCredito.Rows
                            UpdateCompensarNotaCredito(CInt(rowNota("NOTACREDITOID")))
                        Next
                    End If
                    NotaCreditoId = CStr(row("NotaCreditoID"))
                    oZBAPI_ABONO_CIERREDIA = New ZBapiAbonoCierreDia
                    oZBAPI_ABONO_CIERREDIA.Tienda = "T" & oParent.ApplicationContext.ApplicationConfiguration.Almacen
                    oZBAPI_ABONO_CIERREDIA.Cliente = oParent.ApplicationContext.ApplicationConfiguration.Almacen.PadLeft(10, "0")
                    oZBAPI_ABONO_CIERREDIA.MotivoPedido = "ZFF"
                    oZBAPI_ABONO_CIERREDIA.Fecha = FechaCierre.ToString("yyyyMMdd")
                    oZBAPI_ABONO_CIERREDIA.i_FactDpPro = "X"
                    oZBAPI_ABONO_CIERREDIA.i_Mode = "N"
                    oZBAPI_ABONO_CIERREDIA.Devolucion = True
                End If
                rows = oZBAPI_ABONO_CIERREDIA.Documents.Select("BSTNK='" & CStr(row("Referencia")) & "'")
                If rows.Length = 0 Then
                    fila = oZBAPI_ABONO_CIERREDIA.Documents.NewRow()
                    fila("BSTNK") = CStr(row("Referencia"))
                    oZBAPI_ABONO_CIERREDIA.Documents.Rows.Add(fila)
                End If
                nota = oZBAPI_ABONO_CIERREDIA.NotasCredito.NewRow()
                nota("NOTACREDITOID") = CStr(row("NotaCreditoID"))
                oZBAPI_ABONO_CIERREDIA.NotasCredito.Rows.Add(nota)
            Next
            oProcesosSAPMgr.WRITE_ZBAPI_ABONO_CIERREDIA(oZBAPI_ABONO_CIERREDIA, dt)
            Dim strErr As String = ""
            For Each row As DataRow In dt.Rows
                If dt.Columns.Contains("TYPE") Then
                    If row.IsNull("TYPE") = False Then
                        If CStr(row("TYPE")) = "E" Or CStr(row("TYPE")) = "W" Then
                            strErr &= CStr(row("MESSAGE"))
                        End If
                    End If
                End If
            Next
            If strErr.Trim() <> "" Then
                strMensaje &= strErr & vbCrLf
            End If
            For Each row As DataRow In oZBAPI_ABONO_CIERREDIA.NotasCredito.Rows
                UpdateCompensarNotaCredito(CInt(row("NOTACREDITOID")))
            Next
        End If
        '------------------------------------------------------------------------------------------------------
        'FLIZARRAGA 03/11/2017: Se suben las devoluciones de Facturación Fiscal
        '------------------------------------------------------------------------------------------------------
        Dim dvDevolucionFF As New DataView(dtDevolucionesTarjetas)
        dvDevolucionFF.RowFilter = "CodTipoVenta='I'"
        dvDevolucionFF.Sort = "Referencia"
        dvDevolucionFF.RowStateFilter = DataViewRowState.CurrentRows
        NotaCreditoId = ""
        If dvDevolucionFF.Count > 0 Then
            Dim strError As String = ""
            For Each row As DataRowView In dvDevolucionFF
                If NotaCreditoId <> CStr(CStr(row("NotaCreditoID"))) Then
                    If NotaCreditoId <> "" Then
                        oProcesosSAPMgr.WRITE_ZBAPI_ABONO_CIERREDIA(oZBAPI_ABONO_CIERREDIA, dt)
                        For Each rowMsg As DataRow In dt.Rows
                            If dt.Columns.Contains("TYPE") Then
                                If rowMsg.IsNull("TYPE") = False Then
                                    If CStr(rowMsg("TYPE")) = "E" Or CStr(rowMsg("TYPE")) = "W" Then
                                        strError &= CStr(rowMsg("MESSAGE"))
                                    End If
                                End If
                            End If
                        Next
                        If strError.Trim() <> "" Then
                            strMensaje &= strError & vbCrLf
                        End If
                        For Each rowNota As DataRow In oZBAPI_ABONO_CIERREDIA.NotasCredito.Rows
                            UpdateCompensarNotaCredito(CInt(rowNota("NOTACREDITOID")))
                            UpdateCompensarDevolucionesTarjeta(CInt(row("NOTACREDITOID")))
                        Next
                    End If
                    NotaCreditoId = CStr(row("NotaCreditoID"))
                    oZBAPI_ABONO_CIERREDIA = New ZBapiAbonoCierreDia
                    oZBAPI_ABONO_CIERREDIA.Tienda = "T" & oParent.ApplicationContext.ApplicationConfiguration.Almacen
                    oZBAPI_ABONO_CIERREDIA.Cliente = oParent.ApplicationContext.ApplicationConfiguration.Almacen.PadLeft(10, "0")
                    oZBAPI_ABONO_CIERREDIA.MotivoPedido = "ZFF"
                    oZBAPI_ABONO_CIERREDIA.Fecha = FechaCierre.ToString("yyyyMMdd")
                    oZBAPI_ABONO_CIERREDIA.i_FactDpPro = "X"
                    oZBAPI_ABONO_CIERREDIA.i_Mode = "N"
                    oZBAPI_ABONO_CIERREDIA.Devolucion = True
                End If
                rows = oZBAPI_ABONO_CIERREDIA.Documents.Select("BSTNK='" & CStr(row("Referencia")) & "'")
                If rows.Length = 0 Then
                    fila = oZBAPI_ABONO_CIERREDIA.Documents.NewRow()
                    fila("BSTNK") = CStr(row("Referencia"))
                    oZBAPI_ABONO_CIERREDIA.Documents.Rows.Add(fila)
                End If
                fpago = oZBAPI_ABONO_CIERREDIA.FormasPago.NewRow()

                fpago("BSTNK") = CStr(row("Referencia"))

                fpago("FPAGOID") = CStr(row("FormaPagoID"))
                fpago("REFBA") = strNumRef
                fpago("MONTO") = CDec(row("MontoPago"))
                fpago("RCAJA") = ""
                fpago("PAGEN") = ""
                fpago("SIHAY") = ""
                Select Case CStr(row("CodFormasPago"))
                    Case "EFEC"
                        fpago("TPAGO") = "DEVE"
                        fpago("CLCOB") = "DEVEEFEC"
                    Case "TACR"
                        Select Case CStr(row("CodBanco")).Trim()
                            Case "T1"
                                fpago("TPAGO") = "DEVT"
                                fpago("CLCOB") = "DEVTARBMX"
                                fpago("REFBA") = CStr(row("NoAfiliacion")) & Format(FechaCierre, "ddMMyy")
                            Case "T2"
                                fpago("TPAGO") = "DEVT"
                                fpago("CLCOB") = "DEVTARBMX"
                                fpago("REFBA") = CStr(row("NoAfiliacion")) & Format(FechaCierre, "ddMMyy")
                            Case "T3"
                                fpago("TPAGO") = "DEVT"
                                fpago("CLCOB") = "DEVTARBMX"
                                fpago("REFBA") = CStr(row("NoAfiliacion")) & Format(FechaCierre, "ddMMyy")
                            Case Else
                                fpago("TPAGO") = CStr(row("CodFormasPago"))
                                fpago("CLCOB") = ""
                        End Select
                    Case "TADB"
                        Select Case CStr(row("CodBanco")).Trim()
                            Case "T1"
                                fpago("TPAGO") = "DEVT"
                                fpago("CLCOB") = "DEVTARBMX"
                                fpago("REFBA") = CStr(row("NoAfiliacion")) & Format(FechaCierre, "ddMMyy")
                            Case "T2"
                                fpago("TPAGO") = "DEVT"
                                fpago("CLCOB") = "DEVTARBMX"
                                fpago("REFBA") = CStr(row("NoAfiliacion")) & Format(FechaCierre, "ddMMyy")
                            Case "T3"
                                fpago("TPAGO") = "DEVT"
                                fpago("CLCOB") = "DEVTARBMX"
                                fpago("REFBA") = CStr(row("NoAfiliacion")) & Format(FechaCierre, "ddMMyy")
                            Case Else
                                fpago("TPAGO") = CStr(row("CodFormasPago"))
                                fpago("CLCOB") = ""
                        End Select
                    Case "VCJA"
                        oValeCaja = oValeCajaMgr.GetByValeCajaId(CInt(row("DPValeID")))
                        fpago("RCAJA") = oValeCaja.FolioDocumento
                        fpago("TPAGO") = CStr(row("CodFormasPago"))
                        fpago("CLCOB") = ""
                        If oValeCaja.TipoDocumento.Trim() = "CP" Or oValeCaja.TipoDocumento.Trim() = "PI" Then fpago("SIHAY") = "X"
                    Case "DPPT"
                        fpago("TPAGO") = CStr(row("CodFormasPago"))
                        fpago("CLCOB") = "DPPUNTOS".PadRight(9, " ")
                    Case "DPCA"
                        fpago("TPAGO") = CStr(row("CodFormasPago"))
                        fpago("CLCOB") = "DPCARDCR".PadRight(9, " ")
                End Select
                fpago("COMPE") = "X"
                fpago("PAGEN") = ""
                dsBanco = Me.BancoSel(oZBAPI_ABONO_CIERREDIA.Tienda, CStr(fpago("CLCOB")))
                If dsBanco.Tables(0).Rows.Count > 0 Then
                    fpago("BANCO") = dsBanco.Tables(0).Rows(0)!Banco
                Else
                    fpago("BANCO") = ""
                End If
                oZBAPI_ABONO_CIERREDIA.FormasPago.Rows.Add(fpago)
                Notas = oZBAPI_ABONO_CIERREDIA.NotasCredito.Select("NOTACREDITOID=" & CStr(row("NotaCreditoId")))
                If Notas.Length = 0 Then
                    nota = oZBAPI_ABONO_CIERREDIA.NotasCredito.NewRow()
                    nota("NOTACREDITOID") = CStr(row("NotaCreditoID"))
                    oZBAPI_ABONO_CIERREDIA.NotasCredito.Rows.Add(nota)
                End If
            Next
            If oZBAPI_ABONO_CIERREDIA.Documents.Rows.Count > 0 AndAlso oZBAPI_ABONO_CIERREDIA.NotasCredito.Rows.Count > 0 Then
                oProcesosSAPMgr.WRITE_ZBAPI_ABONO_CIERREDIA(oZBAPI_ABONO_CIERREDIA, dt)
                Dim strErr As String = ""
                For Each row As DataRow In dt.Rows
                    If dt.Columns.Contains("TYPE") Then
                        If row.IsNull("TYPE") = False Then
                            If CStr(row("TYPE")) = "E" Or CStr(row("TYPE")) = "W" Then
                                strErr &= CStr(row("MESSAGE"))
                            End If
                        End If
                    End If
                Next
                If strErr.Trim() <> "" Then
                    strMensaje &= strErr & vbCrLf
                End If
                For Each row As DataRow In oZBAPI_ABONO_CIERREDIA.NotasCredito.Rows
                    UpdateCompensarNotaCredito(CInt(row("NOTACREDITOID")))
                    UpdateCompensarDevolucionesTarjeta(CInt(row("NOTACREDITOID")))
                Next
            End If
        End If
    End Sub

    'Funcion Cobranza Up
    Private Sub sm_GenerateFileTxtUp(ByVal dsVentas As DataSet, ByVal FechaCierre As Date, ByRef strMensaje As String, Optional ByVal VPN As Boolean = True)
        Dim dt As DataTable
        Dim oMontarURed As New MontarUnidadRed.cMontaUnidadRed(oParent.ConfigSaveArchivos.Password, oParent.ConfigSaveArchivos.Usuario, oParent.ConfigSaveArchivos.Unidad, oParent.ConfigSaveArchivos.Ruta)
        Dim imes As Integer = FechaCierre.Date.Month
        Dim ruta As String
        oProcesosSAPMgr = New ProcesoSAPManager(oParent.ApplicationContext, oParent.SAPApplicationConfig)
        oProcesosSAPMgr.ConfigCierreFI = oParent.ConfigSaveArchivos
        oDPVale = New cDPVale
        If VPN Then
            ruta = oParent.ConfigSaveArchivos.Ruta & "\" & Mid(oParent.ApplicationContext.ApplicationConfiguration.Almacen, 2, 2) & "\" & GetMes(imes) & "\"
        Else
            ruta = "C:\VTAS\" & GetMes(imes) & "\"
        End If

        'On Error GoTo MensajeError
        Try

            Dim strRuta As String = ruta & "VTA" & oParent.ApplicationContext.ApplicationConfiguration.Almacen & FechaCierre.ToShortDateString.Replace("/", "") & ".txt"
            'Dim txtWriter As New System.IO.StreamWriter(strRuta, False)

            ''DataView para las ventas
            Dim dvTarjetaUno As New DataView(dsVentas.Tables(0))
            Dim intIndex As Integer
            Dim strEncabezado As String
            Dim strNumRefBBV As String = ""

            '------------------------------------------------------
            ' JNAVA (19.03.2014): Cliente DPCA
            '------------------------------------------------------
            Dim strCliente As String

            '----------------Numero de Referencia---------------
            Dim numref As New NumeroReferencia.cNumReferencia
            Dim strNumRef As String = numref.getNumReferencia(oParent.ApplicationContext.ApplicationConfiguration.Almacen.PadLeft(4, "0"), CStr(Format(FechaCierre.Date.Date, "ddMMyyyy")))
            '------------------------------------------------------

            strNumRefBBV = GetNumRefBBV(oParent.ApplicationContext.ApplicationConfiguration.Almacen)


            Dim oZBAPI_ABONO_CIERREDIA As ZBapiAbonoCierreDia
            Dim strResult As String = ""
            Dim fecha As String = ""
            Dim FechaRefBancos As Date = FechaCierre

            Select Case FechaCierre.DayOfWeek
                Case DayOfWeek.Friday
                    FechaRefBancos = FechaRefBancos.AddDays(3)
                Case DayOfWeek.Saturday
                    FechaRefBancos = FechaRefBancos.AddDays(2)
                Case Else
                    FechaRefBancos = FechaRefBancos.AddDays(1)
            End Select
            Dim oValeCajaMgr As New ValeCajaManager(oParent.ApplicationContext)
            Dim oValeCaja As ValeCaja.ValeCaja = Nothing
            '------------------------------------------------------------------------------------------
            'FLIZARRAGA 26/02/2016: Tipo de ventas PUBLICO GENERAL
            '------------------------------------------------------------------------------------------
            Dim dvVentasPublicoGeneral As New DataView(dsVentas.Tables(0))
            Dim dsBanco As DataSet = Nothing
            Dim fila As DataRow = Nothing
            Dim fpago As DataRow = Nothing
            Dim rows() As DataRow = Nothing
            dvVentasPublicoGeneral.RowFilter = "CodTipoVenta='P'"
            dvVentasPublicoGeneral.Sort = "Referencia"
            dvVentasPublicoGeneral.RowStateFilter = DataViewRowState.CurrentRows
            If dvVentasPublicoGeneral.Count > 0 Then
                oZBAPI_ABONO_CIERREDIA = New ZBapiAbonoCierreDia
                oZBAPI_ABONO_CIERREDIA.Tienda = "T" & oParent.ApplicationContext.ApplicationConfiguration.Almacen
                oZBAPI_ABONO_CIERREDIA.Cliente = oParent.ApplicationContext.ApplicationConfiguration.Almacen.PadLeft(10, "0")
                oZBAPI_ABONO_CIERREDIA.Detalle = "X"
                oZBAPI_ABONO_CIERREDIA.MotivoPedido = "ZPG"
                oZBAPI_ABONO_CIERREDIA.Fecha = FechaCierre.ToString("yyyyMMdd")
                oZBAPI_ABONO_CIERREDIA.i_FactDpPro = "X"
                oZBAPI_ABONO_CIERREDIA.i_Mode = "N"
                oZBAPI_ABONO_CIERREDIA.Devolucion = False
                For Each row As DataRowView In dvVentasPublicoGeneral
                    rows = oZBAPI_ABONO_CIERREDIA.Documents.Select("BSTNK='" & CStr(row("Referencia")) & "'")
                    If rows.Length = 0 Then
                        fila = oZBAPI_ABONO_CIERREDIA.Documents.NewRow()
                        fila("BSTNK") = CStr(row("Referencia"))
                        oZBAPI_ABONO_CIERREDIA.Documents.Rows.Add(fila)
                    End If
                    fpago = oZBAPI_ABONO_CIERREDIA.FormasPago.NewRow()
                    '-----------------------------------------------------------------------
                    ' JNAVA (11.11.2016): Agregamos el campo BSTNK = Referencia de Factura
                    '-----------------------------------------------------------------------
                    fpago("BSTNK") = CStr(row("Referencia"))
                    '-----------------------------------------------------------------------
                    fpago("FPAGOID") = CStr(row("FormaPagoID"))
                    fpago("TPAGO") = CStr(row("CodFormasPago"))
                    fpago("REFBA") = strNumRef
                    fpago("MONTO") = CDec(row("Monto"))
                    fpago("RCAJA") = ""
                    fpago("PAGEN") = ""
                    fpago("SIHAY") = ""
                    Select Case CStr(row("CodFormasPago"))
                        Case "EFEC"
                            fpago("CLCOB") = "EFECTIVO"
                        Case "TACR"
                            Select Case CStr(row("CodBanco")).Trim()
                                Case "T1"
                                    fpago("CLCOB") = "TARJETA 1".PadRight(9, " ")
                                    fpago("REFBA") = CStr(row("NoAfiliacion")) & Format(FechaCierre, "ddMMyy")
                                Case "T2"
                                    fpago("CLCOB") = "TARJETA 2".PadRight(9, " ")
                                    fpago("REFBA") = CStr(row("NoAfiliacion")) & Format(FechaCierre, "ddMMyy")
                                Case "T3"
                                    fpago("CLCOB") = "TARJETA 3".PadRight(9, " ")
                                    fpago("REFBA") = CStr(row("NoAfiliacion")) & Format(FechaCierre, "ddMMyy")
                                Case Else
                                    fpago("CLCOB") = ""
                            End Select
                        Case "TADB"
                            Select Case CStr(row("CodBanco")).Trim()
                                Case "T1"
                                    fpago("CLCOB") = "TARJETA 1".PadRight(9, " ")
                                    fpago("REFBA") = CStr(row("NoAfiliacion")) & Format(FechaCierre, "ddMMyy")
                                Case "T2"
                                    fpago("CLCOB") = "TARJETA 2".PadRight(9, " ")
                                    fpago("REFBA") = CStr(row("NoAfiliacion")) & Format(FechaCierre, "ddMMyy")
                                Case "T3"
                                    fpago("CLCOB") = "TARJETA 3".PadRight(9, " ")
                                    fpago("REFBA") = CStr(row("NoAfiliacion")) & Format(FechaCierre, "ddMMyy")
                                Case Else
                                    fpago("CLCOB") = ""
                            End Select
                        Case "VCJA"
                            oValeCaja = oValeCajaMgr.GetByValeCajaId(CInt(row("DPValeID")))
                            fpago("RCAJA") = oValeCaja.FolioDocumento
                            fpago("CLCOB") = ""
                            If oValeCaja.TipoDocumento.Trim() = "CP" Or oValeCaja.TipoDocumento.Trim() = "PI" Then fpago("SIHAY") = "X"
                        Case "DPPT"
                            fpago("CLCOB") = "DPPUNTOS".PadRight(9, " ")
                        Case "DPCA"
                            fpago("CLCOB") = "DPCARDCR".PadRight(9, " ")
                    End Select
                    fpago("COMPE") = "X"
                    fpago("PAGEN") = ""
                    dsBanco = Me.BancoSel(oZBAPI_ABONO_CIERREDIA.Tienda, CStr(fpago("CLCOB")))
                    If dsBanco.Tables(0).Rows.Count > 0 Then
                        fpago("BANCO") = dsBanco.Tables(0).Rows(0)!Banco
                    Else
                        fpago("BANCO") = ""
                    End If
                    oZBAPI_ABONO_CIERREDIA.FormasPago.Rows.Add(fpago)
                Next
                oProcesosSAPMgr.WRITE_ZBAPI_ABONO_CIERREDIA(oZBAPI_ABONO_CIERREDIA, dt)
                Dim strError As String = ""
                For Each row As DataRow In dt.Rows
                    If dt.Columns.Contains("TYPE") Then
                        If row.IsNull("TYPE") = False Then
                            If CStr(row("TYPE")) = "E" Or CStr(row("TYPE")) = "W" Then
                                strError &= CStr(row("MESSAGE"))
                            End If
                        End If
                    End If
                Next
                If strError.Trim() <> "" Then
                    strMensaje &= strError & vbCrLf
                End If
                For Each row As DataRow In oZBAPI_ABONO_CIERREDIA.FormasPago.Rows
                    FacturaFI05ok(CInt(row("FPAGOID")))
                Next
            End If
            '------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 26/02/2016: Pagos de Tarjetas de DIPS
            '------------------------------------------------------------------------------------------------------
            Dim dvVentasDips As New DataView(dsVentas.Tables(0))
            Dim ClienteId As String = ""
            dvVentasDips.RowFilter = "CodTipoVenta='D'"
            dvVentasDips.Sort = "ClienteId"
            dvVentasDips.RowStateFilter = DataViewRowState.CurrentRows
            If dvVentasDips.Count > 0 Then
                For Each row As DataRowView In dvVentasDips
                    If ClienteId <> CStr(row("ClienteId")) Then
                        If ClienteId <> "" Then
                            oProcesosSAPMgr.WRITE_ZBAPI_ABONO_CIERREDIA(oZBAPI_ABONO_CIERREDIA, dt)
                            Dim strError As String = ""
                            For Each rowErr As DataRow In dt.Rows
                                If dt.Columns.Contains("TYPE") Then
                                    If rowErr.IsNull("TYPE") = False Then
                                        If CStr(rowErr("TYPE")) = "E" Or CStr(rowErr("TYPE")) = "W" Then
                                            strError &= CStr(rowErr("MESSAGE"))
                                        End If
                                    End If
                                End If
                            Next
                            If strError.Trim() <> "" Then
                                strMensaje &= strError & vbCrLf
                            End If
                            For Each rowNota As DataRow In oZBAPI_ABONO_CIERREDIA.FormasPago.Rows
                                FacturaFI05ok(CInt(rowNota("FPAGOID")))
                            Next
                        End If
                        ClienteId = CStr(row("ClienteId"))
                        oZBAPI_ABONO_CIERREDIA = New ZBapiAbonoCierreDia
                        oZBAPI_ABONO_CIERREDIA.Tienda = "T" & oParent.ApplicationContext.ApplicationConfiguration.Almacen
                        oZBAPI_ABONO_CIERREDIA.Cliente = oParent.ApplicationContext.ApplicationConfiguration.Almacen.PadLeft(10, "0")
                        oZBAPI_ABONO_CIERREDIA.MotivoPedido = "ZDC"
                        oZBAPI_ABONO_CIERREDIA.Fecha = FechaCierre.ToString("yyyyMMdd")
                        oZBAPI_ABONO_CIERREDIA.i_FactDpPro = "X"
                        oZBAPI_ABONO_CIERREDIA.i_Mode = "N"
                        oZBAPI_ABONO_CIERREDIA.Devolucion = False
                    End If
                    rows = oZBAPI_ABONO_CIERREDIA.Documents.Select("BSTNK='" & CStr(row("Referencia")) & "'")
                    If rows.Length = 0 Then
                        fila = oZBAPI_ABONO_CIERREDIA.Documents.NewRow()
                        fila("BSTNK") = CStr(row("Referencia"))
                        oZBAPI_ABONO_CIERREDIA.Documents.Rows.Add(fila)
                    End If
                    fpago = oZBAPI_ABONO_CIERREDIA.FormasPago.NewRow()
                    '-----------------------------------------------------------------------
                    ' JNAVA (11.11.2016): Agregamos el campo BSTNK = Referencia de Factura
                    '-----------------------------------------------------------------------
                    fpago("BSTNK") = CStr(row("Referencia"))
                    '-----------------------------------------------------------------------
                    fpago("FPAGOID") = CStr(row("FormaPagoID"))
                    fpago("TPAGO") = CStr(row("CodFormasPago"))
                    fpago("REFBA") = strNumRef
                    fpago("MONTO") = CDec(row("Monto"))
                    fpago("RCAJA") = ""
                    fpago("PAGEN") = ""
                    fpago("SIHAY") = ""
                    Select Case CStr(row("CodFormasPago"))
                        Case "EFEC"
                            fpago("CLCOB") = "EFECTIVO"
                        Case "TACR"
                            Select Case CStr(row("CodBanco")).Trim()
                                Case "T1"
                                    fpago("CLCOB") = "TARJETA 1".PadRight(9, " ")
                                    fpago("REFBA") = CStr(row("NoAfiliacion")) & Format(FechaCierre, "ddMMyy")
                                Case "T2"
                                    fpago("CLCOB") = "TARJETA 2".PadRight(9, " ")
                                    fpago("REFBA") = CStr(row("NoAfiliacion")) & Format(FechaCierre, "ddMMyy")
                                Case "T3"
                                    fpago("CLCOB") = "TARJETA 3".PadRight(9, " ")
                                    fpago("REFBA") = CStr(row("NoAfiliacion")) & Format(FechaCierre, "ddMMyy")
                                Case Else
                                    fpago("CLCOB") = ""
                            End Select
                        Case "TADB"
                            Select Case CStr(row("CodBanco")).Trim()
                                Case "T1"
                                    fpago("CLCOB") = "TARJETA 1".PadRight(9, " ")
                                    fpago("REFBA") = CStr(row("NoAfiliacion")) & Format(FechaCierre, "ddMMyy")
                                Case "T2"
                                    fpago("CLCOB") = "TARJETA 2".PadRight(9, " ")
                                    fpago("REFBA") = CStr(row("NoAfiliacion")) & Format(FechaCierre, "ddMMyy")
                                Case "T3"
                                    fpago("CLCOB") = "TARJETA 3".PadRight(9, " ")
                                    fpago("REFBA") = CStr(row("NoAfiliacion")) & Format(FechaCierre, "ddMMyy")
                                Case Else
                                    fpago("CLCOB") = ""
                            End Select
                        Case "VCJA"
                            oValeCaja = oValeCajaMgr.GetByValeCajaId(CInt(row("DPValeID")))
                            fpago("RCAJA") = oValeCaja.FolioDocumento
                            fpago("CLCOB") = ""
                            If oValeCaja.TipoDocumento.Trim() = "CP" Or oValeCaja.TipoDocumento.Trim() = "PI" Then fpago("SIHAY") = "X"
                        Case "DPPT"
                            fpago("CLCOB") = "DPPUNTOS".PadRight(9, " ")
                        Case "DPCA"
                            fpago("CLCOB") = "DPCARDCR".PadRight(9, " ")
                    End Select
                    dsBanco = Me.BancoSel(oZBAPI_ABONO_CIERREDIA.Tienda, CStr(fpago("CLCOB")))
                    If dsBanco.Tables(0).Rows.Count > 0 Then
                        fpago("BANCO") = dsBanco.Tables(0).Rows(0)!Banco
                    Else
                        fpago("BANCO") = ""
                    End If
                    fpago("COMPE") = "X"
                    oZBAPI_ABONO_CIERREDIA.FormasPago.Rows.Add(fpago)
                Next
                oProcesosSAPMgr.WRITE_ZBAPI_ABONO_CIERREDIA(oZBAPI_ABONO_CIERREDIA, dt)
                Dim strErr As String = ""
                For Each rowErr As DataRow In dt.Rows
                    If dt.Columns.Contains("TYPE") Then
                        If rowErr.IsNull("TYPE") = False Then
                            If CStr(rowErr("TYPE")) = "E" Or CStr(rowErr("TYPE")) = "W" Then
                                strErr &= CStr(rowErr("MESSAGE"))
                            End If
                        End If
                    End If
                Next
                If strErr.Trim() <> "" Then
                    strMensaje &= strErr & vbCrLf
                End If
                For Each rowNota As DataRow In oZBAPI_ABONO_CIERREDIA.FormasPago.Rows
                    FacturaFI05ok(CInt(rowNota("FPAGOID")))
                Next
            End If

            '------------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 27/02/2016: Se suben las formas de Pagos de Facilito
            '------------------------------------------------------------------------------------------------------------------

            Dim dvVentasFacilito As New DataView(dsVentas.Tables(0))
            dvVentasFacilito.RowFilter = "CodTipoVenta='O'"
            dvVentasFacilito.Sort = "Referencia"
            dvVentasFacilito.RowStateFilter = DataViewRowState.CurrentRows
            If dvVentasFacilito.Count > 0 Then
                oZBAPI_ABONO_CIERREDIA = New ZBapiAbonoCierreDia
                oZBAPI_ABONO_CIERREDIA.Tienda = "T" & oParent.ApplicationContext.ApplicationConfiguration.Almacen
                oZBAPI_ABONO_CIERREDIA.Cliente = oParent.ApplicationContext.ApplicationConfiguration.Almacen.PadLeft(10, "0")
                oZBAPI_ABONO_CIERREDIA.MotivoPedido = "ZFA"
                oZBAPI_ABONO_CIERREDIA.Fecha = FechaCierre.ToString("yyyyMMdd")
                oZBAPI_ABONO_CIERREDIA.i_FactDpPro = "X"
                oZBAPI_ABONO_CIERREDIA.i_Mode = "N"
                oZBAPI_ABONO_CIERREDIA.Devolucion = False
                For Each row As DataRowView In dvVentasFacilito
                    rows = oZBAPI_ABONO_CIERREDIA.Documents.Select("BSTNK='" & CStr(row("Referencia")) & "'")
                    If rows.Length = 0 Then
                        fila = oZBAPI_ABONO_CIERREDIA.Documents.NewRow()
                        fila("BSTNK") = CStr(row("Referencia"))
                        oZBAPI_ABONO_CIERREDIA.Documents.Rows.Add(fila)
                    End If
                    fpago = oZBAPI_ABONO_CIERREDIA.FormasPago.NewRow()
                    '-----------------------------------------------------------------------
                    ' JNAVA (11.11.2016): Agregamos el campo BSTNK = Referencia de Factura
                    '-----------------------------------------------------------------------
                    fpago("BSTNK") = CStr(row("Referencia"))
                    '-----------------------------------------------------------------------
                    fpago("FPAGOID") = CStr(row("FormaPagoID"))
                    fpago("TPAGO") = CStr(row("CodFormasPago"))
                    fpago("REFBA") = strNumRef
                    fpago("MONTO") = CDec(row("Monto"))
                    fpago("RCAJA") = ""
                    fpago("PAGEN") = ""
                    fpago("SIHAY") = ""
                    Select Case CStr(row("CodFormasPago"))
                        Case "EFEC"
                            fpago("CLCOB") = "EFECTIVO"
                        Case "TACR"
                            Select Case CStr(row("CodBanco")).Trim()
                                Case "T1"
                                    fpago("CLCOB") = "TARJETA 1".PadRight(9, " ")
                                    fpago("REFBA") = CStr(row("NoAfiliacion")) & Format(FechaCierre, "ddMMyy")
                                Case "T2"
                                    fpago("CLCOB") = "TARJETA 2".PadRight(9, " ")
                                    fpago("REFBA") = CStr(row("NoAfiliacion")) & Format(FechaCierre, "ddMMyy")
                                Case "T3"
                                    fpago("CLCOB") = "TARJETA 3".PadRight(9, " ")
                                    fpago("REFBA") = CStr(row("NoAfiliacion")) & Format(FechaCierre, "ddMMyy")
                                Case Else
                                    fpago("CLCOB") = ""
                            End Select
                        Case "TADB"
                            Select Case CStr(row("CodBanco")).Trim()
                                Case "T1"
                                    fpago("CLCOB") = "TARJETA 1".PadRight(9, " ")
                                    fpago("REFBA") = CStr(row("NoAfiliacion")) & Format(FechaCierre, "ddMMyy")
                                Case "T2"
                                    fpago("CLCOB") = "TARJETA 2".PadRight(9, " ")
                                    fpago("REFBA") = CStr(row("NoAfiliacion")) & Format(FechaCierre, "ddMMyy")
                                Case "T3"
                                    fpago("CLCOB") = "TARJETA 3".PadRight(9, " ")
                                    fpago("REFBA") = CStr(row("NoAfiliacion")) & Format(FechaCierre, "ddMMyy")
                                Case Else
                                    fpago("CLCOB") = ""
                            End Select
                        Case "FACI"
                            fpago("CLCOB") = ""
                        Case "VCJA"
                            oValeCaja = oValeCajaMgr.GetByValeCajaId(CInt(row("DPValeID")))
                            fpago("RCAJA") = oValeCaja.FolioDocumento
                            fpago("CLCOB") = ""
                            If oValeCaja.TipoDocumento.Trim() = "CP" Or oValeCaja.TipoDocumento.Trim() = "PI" Then fpago("SIHAY") = "X"
                        Case "DPPT"
                            fpago("CLCOB") = "DPPUNTOS".PadRight(9, " ")
                        Case "DPCA"
                            fpago("CLCOB") = "DPCARDCR".PadRight(9, " ")
                    End Select
                    fpago("COMPE") = ""
                    dsBanco = Me.BancoSel(oZBAPI_ABONO_CIERREDIA.Tienda, CStr(fpago("CLCOB")))
                    If dsBanco.Tables(0).Rows.Count > 0 Then
                        fpago("BANCO") = dsBanco.Tables(0).Rows(0)!Banco
                    Else
                        fpago("BANCO") = ""
                    End If
                    oZBAPI_ABONO_CIERREDIA.FormasPago.Rows.Add(fpago)
                Next
                oProcesosSAPMgr.WRITE_ZBAPI_ABONO_CIERREDIA(oZBAPI_ABONO_CIERREDIA, dt)
                Dim strError As String = ""
                For Each row As DataRow In dt.Rows
                    If dt.Columns.Contains("TYPE") Then
                        If row.IsNull("TYPE") = False Then
                            If CStr(row("TYPE")) = "E" Or CStr(row("TYPE")) = "W" Then
                                strError &= CStr(row("MESSAGE"))
                            End If
                        End If
                    End If
                Next
                If strError.Trim() <> "" Then
                    strMensaje &= strError & vbCrLf
                End If
                For Each row As DataRow In oZBAPI_ABONO_CIERREDIA.FormasPago.Rows
                    FacturaFI05ok(CInt(row("FPAGOID")))
                Next
            End If

            '------------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 27/02/2016: Se suben las formas de Pagos de DPVale
            '------------------------------------------------------------------------------------------------------------------

            Dim dvVentasDPVale As New DataView(dsVentas.Tables(0))
            dvVentasDPVale.RowFilter = "CodTipoVenta='V'"
            dvVentasDPVale.Sort = "Referencia"
            dvVentasDPVale.RowStateFilter = DataViewRowState.CurrentRows
            If dvVentasDPVale.Count > 0 Then
                oZBAPI_ABONO_CIERREDIA = New ZBapiAbonoCierreDia
                oZBAPI_ABONO_CIERREDIA.Tienda = "T" & oParent.ApplicationContext.ApplicationConfiguration.Almacen
                oZBAPI_ABONO_CIERREDIA.Cliente = oParent.ApplicationContext.ApplicationConfiguration.Almacen.PadLeft(10, "0")
                oZBAPI_ABONO_CIERREDIA.MotivoPedido = "ZDV"
                oZBAPI_ABONO_CIERREDIA.Fecha = FechaCierre.ToString("yyyyMMdd")
                oZBAPI_ABONO_CIERREDIA.i_FactDpPro = "X"
                oZBAPI_ABONO_CIERREDIA.i_Mode = "N"
                oZBAPI_ABONO_CIERREDIA.Devolucion = False
                For Each row As DataRowView In dvVentasDPVale
                    rows = oZBAPI_ABONO_CIERREDIA.Documents.Select("BSTNK='" & CStr(row("Referencia")) & "'")
                    If rows.Length = 0 Then
                        fila = oZBAPI_ABONO_CIERREDIA.Documents.NewRow()
                        fila("BSTNK") = CStr(row("Referencia"))
                        oZBAPI_ABONO_CIERREDIA.Documents.Rows.Add(fila)
                    End If
                    fpago = oZBAPI_ABONO_CIERREDIA.FormasPago.NewRow()
                    '-----------------------------------------------------------------------
                    ' JNAVA (11.11.2016): Agregamos el campo BSTNK = Referencia de Factura
                    '-----------------------------------------------------------------------
                    fpago("BSTNK") = CStr(row("Referencia"))
                    '-----------------------------------------------------------------------
                    fpago("FPAGOID") = CStr(row("FormaPagoID"))
                    fpago("TPAGO") = CStr(row("CodFormasPago"))
                    fpago("REFBA") = strNumRef
                    fpago("MONTO") = CDec(row("Monto"))
                    fpago("RCAJA") = ""
                    fpago("PAGEN") = ""
                    fpago("SIHAY") = ""
                    Select Case CStr(row("CodFormasPago"))
                        Case "EFEC"
                            fpago("CLCOB") = "EFECTIVO"
                        Case "TACR"
                            Select Case CStr(row("CodBanco")).Trim()
                                Case "T1"
                                    fpago("CLCOB") = "TARJETA 1".PadRight(9, " ")
                                    fpago("REFBA") = CStr(row("NoAfiliacion")) & Format(FechaCierre, "ddMMyy")
                                Case "T2"
                                    fpago("CLCOB") = "TARJETA 2".PadRight(9, " ")
                                    fpago("REFBA") = CStr(row("NoAfiliacion")) & Format(FechaCierre, "ddMMyy")
                                Case "T3"
                                    fpago("CLCOB") = "TARJETA 3".PadRight(9, " ")
                                    fpago("REFBA") = CStr(row("NoAfiliacion")) & Format(FechaCierre, "ddMMyy")
                                Case Else
                                    fpago("CLCOB") = ""
                            End Select
                        Case "TADB"
                            Select Case CStr(row("CodBanco")).Trim()
                                Case "T1"
                                    fpago("CLCOB") = "TARJETA 1".PadRight(9, " ")
                                    fpago("REFBA") = CStr(row("NoAfiliacion")) & Format(FechaCierre, "ddMMyy")
                                Case "T2"
                                    fpago("CLCOB") = "TARJETA 2".PadRight(9, " ")
                                    fpago("REFBA") = CStr(row("NoAfiliacion")) & Format(FechaCierre, "ddMMyy")
                                Case "T3"
                                    fpago("CLCOB") = "TARJETA 3".PadRight(9, " ")
                                    fpago("REFBA") = CStr(row("NoAfiliacion")) & Format(FechaCierre, "ddMMyy")
                                Case Else
                                    fpago("CLCOB") = ""
                            End Select
                        Case "FACI"
                            fpago("CLCOB") = ""
                            fpago("COMPE") = ""
                        Case "VCJA"
                            oValeCaja = oValeCajaMgr.GetByValeCajaId(CInt(row("DPValeID")))
                            fpago("RCAJA") = oValeCaja.FolioDocumento
                            fpago("CLCOB") = ""
                            If oValeCaja.TipoDocumento.Trim() = "CP" Or oValeCaja.TipoDocumento.Trim() = "PI" Then fpago("SIHAY") = "X"
                        Case "DPPT"
                            fpago("CLCOB") = "DPPUNTOS".PadRight(9, " ")
                        Case "DPCA"
                            fpago("CLCOB") = "DPCARDCR".PadRight(9, " ")
                        Case "DPVL"
                            fpago("CLCOB") = ""
                    End Select
                    fpago("COMPE") = ""
                    dsBanco = Me.BancoSel(oZBAPI_ABONO_CIERREDIA.Tienda, CStr(fpago("CLCOB")))
                    If dsBanco.Tables(0).Rows.Count > 0 Then
                        fpago("BANCO") = dsBanco.Tables(0).Rows(0)!Banco
                    Else
                        fpago("BANCO") = ""
                    End If
                    oZBAPI_ABONO_CIERREDIA.FormasPago.Rows.Add(fpago)
                Next
                oProcesosSAPMgr.WRITE_ZBAPI_ABONO_CIERREDIA(oZBAPI_ABONO_CIERREDIA, dt)
                Dim strError As String = ""
                For Each row As DataRow In dt.Rows
                    If dt.Columns.Contains("TYPE") Then
                        If row.IsNull("TYPE") = False Then
                            If CStr(row("TYPE")) = "E" Or CStr(row("TYPE")) = "W" Then
                                strError &= CStr(row("MESSAGE"))
                            End If
                        End If
                    End If
                Next
                If strError.Trim() <> "" Then
                    strMensaje &= strError & vbCrLf
                End If
                For Each row As DataRow In oZBAPI_ABONO_CIERREDIA.FormasPago.Rows
                    FacturaFI05ok(CInt(row("FPAGOID")))
                Next
            End If

            '------------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 27/02/2016: Se suben las formas de Pagos de socios
            '------------------------------------------------------------------------------------------------------------------
            Dim dvVentasSocios As New DataView(dsVentas.Tables(0))
            dvVentasSocios.RowFilter = "CodTipoVenta='S'"
            dvVentasSocios.Sort = "Referencia"
            dvVentasSocios.RowStateFilter = DataViewRowState.CurrentRows

            If dvVentasSocios.Count > 0 Then
                oZBAPI_ABONO_CIERREDIA = New ZBapiAbonoCierreDia
                oZBAPI_ABONO_CIERREDIA.Tienda = "T" & oParent.ApplicationContext.ApplicationConfiguration.Almacen
                oZBAPI_ABONO_CIERREDIA.Cliente = oParent.ApplicationContext.ApplicationConfiguration.Almacen.PadLeft(10, "0")
                oZBAPI_ABONO_CIERREDIA.MotivoPedido = "ZDC"
                oZBAPI_ABONO_CIERREDIA.Fecha = FechaCierre.ToString("yyyyMMdd")
                oZBAPI_ABONO_CIERREDIA.i_FactDpPro = "X"
                oZBAPI_ABONO_CIERREDIA.i_Mode = "N"
                oZBAPI_ABONO_CIERREDIA.Devolucion = False
                For Each row As DataRowView In dvVentasSocios
                    rows = oZBAPI_ABONO_CIERREDIA.Documents.Select("BSTNK='" & CStr(row("Referencia")) & "'")
                    If rows.Length = 0 Then
                        fila = oZBAPI_ABONO_CIERREDIA.Documents.NewRow()
                        fila("BSTNK") = CStr(row("Referencia"))
                        oZBAPI_ABONO_CIERREDIA.Documents.Rows.Add(fila)
                    End If
                    fpago = oZBAPI_ABONO_CIERREDIA.FormasPago.NewRow()
                    '-----------------------------------------------------------------------
                    ' JNAVA (11.11.2016): Agregamos el campo BSTNK = Referencia de Factura
                    '-----------------------------------------------------------------------
                    fpago("BSTNK") = CStr(row("Referencia"))
                    '-----------------------------------------------------------------------
                    fpago("FPAGOID") = CStr(row("FormaPagoID"))
                    fpago("TPAGO") = CStr(row("CodFormasPago"))
                    fpago("REFBA") = strNumRef
                    fpago("MONTO") = CDec(row("Monto"))
                    fpago("RCAJA") = ""
                    fpago("PAGEN") = ""
                    fpago("SIHAY") = ""
                    Select Case CStr(row("CodFormasPago"))
                        Case "EFEC"
                            fpago("CLCOB") = "EFECTIVO"
                        Case "TACR"
                            Select Case CStr(row("CodBanco")).Trim()
                                Case "T1"
                                    fpago("CLCOB") = "TARJETA 1".PadRight(9, " ")
                                    fpago("REFBA") = CStr(row("NoAfiliacion")) & Format(FechaCierre, "ddMMyy")
                                Case "T2"
                                    fpago("CLCOB") = "TARJETA 2".PadRight(9, " ")
                                    fpago("REFBA") = CStr(row("NoAfiliacion")) & Format(FechaCierre, "ddMMyy")
                                Case "T3"
                                    fpago("CLCOB") = "TARJETA 3".PadRight(9, " ")
                                    fpago("REFBA") = CStr(row("NoAfiliacion")) & Format(FechaCierre, "ddMMyy")
                                Case Else
                                    fpago("CLCOB") = ""
                            End Select
                        Case "TADB"
                            Select Case CStr(row("CodBanco")).Trim()
                                Case "T1"
                                    fpago("CLCOB") = "TARJETA 1".PadRight(9, " ")
                                    fpago("REFBA") = CStr(row("NoAfiliacion")) & Format(FechaCierre, "ddMMyy")
                                Case "T2"
                                    fpago("CLCOB") = "TARJETA 2".PadRight(9, " ")
                                    fpago("REFBA") = CStr(row("NoAfiliacion")) & Format(FechaCierre, "ddMMyy")
                                Case "T3"
                                    fpago("CLCOB") = "TARJETA 3".PadRight(9, " ")
                                    fpago("REFBA") = CStr(row("NoAfiliacion")) & Format(FechaCierre, "ddMMyy")
                                Case Else
                                    fpago("CLCOB") = ""
                            End Select
                        Case "FACI"
                            fpago("CLCOB") = ""
                        Case "VCJA"
                            oValeCaja = oValeCajaMgr.GetByValeCajaId(CInt(row("DPValeID")))
                            fpago("RCAJA") = oValeCaja.FolioDocumento
                            fpago("CLCOB") = ""
                            If oValeCaja.TipoDocumento.Trim() = "CP" Or oValeCaja.TipoDocumento.Trim() = "PI" Then fpago("SIHAY") = "X"
                        Case "DPPT"
                            fpago("CLCOB") = "DPPUNTOS".PadRight(9, " ")
                        Case "DPCA"
                            fpago("CLCOB") = "DPCARDCR".PadRight(9, " ")
                    End Select
                    fpago("COMPE") = "X"
                    dsBanco = Me.BancoSel(oZBAPI_ABONO_CIERREDIA.Tienda, CStr(fpago("CLCOB")))
                    If dsBanco.Tables(0).Rows.Count > 0 Then
                        fpago("BANCO") = dsBanco.Tables(0).Rows(0)!Banco
                    Else
                        fpago("BANCO") = ""
                    End If
                    oZBAPI_ABONO_CIERREDIA.FormasPago.Rows.Add(fpago)
                Next
                oProcesosSAPMgr.WRITE_ZBAPI_ABONO_CIERREDIA(oZBAPI_ABONO_CIERREDIA, dt)
                Dim strError As String = ""
                For Each row As DataRow In dt.Rows
                    If dt.Columns.Contains("TYPE") Then
                        If row.IsNull("TYPE") = False Then
                            If CStr(row("TYPE")) = "E" Or CStr(row("TYPE")) = "W" Then
                                strError &= CStr(row("MESSAGE"))
                            End If
                        End If
                    End If
                Next
                If strError.Trim() <> "" Then
                    strMensaje &= strError & vbCrLf
                End If
                For Each row As DataRow In oZBAPI_ABONO_CIERREDIA.FormasPago.Rows
                    FacturaFI05ok(CInt(row("FPAGOID")))
                Next
            End If

            '------------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 27/02/2016: Se suben los pagos de Apartados
            '------------------------------------------------------------------------------------------------------------------

            Dim dvVentasApartados As New DataView(dsVentas.Tables(0))
            dvVentasApartados.RowFilter = "CodTipoVenta='A'"
            dvVentasApartados.Sort = "Referencia"
            dvVentasApartados.RowStateFilter = DataViewRowState.CurrentRows
            If dvVentasApartados.Count > 0 Then
                oZBAPI_ABONO_CIERREDIA = New ZBapiAbonoCierreDia
                oZBAPI_ABONO_CIERREDIA.Tienda = "T" & oParent.ApplicationContext.ApplicationConfiguration.Almacen
                oZBAPI_ABONO_CIERREDIA.Cliente = oParent.ApplicationContext.ApplicationConfiguration.Almacen.PadLeft(10, "0")
                oZBAPI_ABONO_CIERREDIA.MotivoPedido = "ZAP"
                oZBAPI_ABONO_CIERREDIA.Fecha = FechaCierre.ToString("yyyyMMdd")
                oZBAPI_ABONO_CIERREDIA.i_FactDpPro = "X"
                oZBAPI_ABONO_CIERREDIA.i_Mode = "N"
                oZBAPI_ABONO_CIERREDIA.Devolucion = False
                Dim contratoMgr As New ContratoManager(oParent.ApplicationContext)
                Dim facturaIdApartado As Integer
                Dim saldoSaldado As Decimal = 0
                For Each row As DataRowView In dvVentasApartados
                    rows = oZBAPI_ABONO_CIERREDIA.Documents.Select("BSTNK='" & CStr(row("Referencia")) & "'")
                    If rows.Length = 0 Then
                        fila = oZBAPI_ABONO_CIERREDIA.Documents.NewRow()
                        fila("BSTNK") = CStr(row("Referencia"))
                        oZBAPI_ABONO_CIERREDIA.Documents.Rows.Add(fila)
                    End If
                    facturaIdApartado = CInt(row("FacturaID"))
                    saldoSaldado = contratoMgr.GetApartadoSaldado(facturaIdApartado)
                    If saldoSaldado = 0 Then
                        Dim dtAnticipos As DataTable = contratoMgr.GetAnticiposByApartadoId(CInt(row("ApartadoID")))
                        For Each rowAnt As DataRow In dtAnticipos.Rows
                            fpago = oZBAPI_ABONO_CIERREDIA.FormasPago.NewRow()
                            '-----------------------------------------------------------------------
                            ' JNAVA (11.11.2016): Agregamos el campo BSTNK = Referencia de Factura
                            '-----------------------------------------------------------------------
                            fpago("BSTNK") = CStr(row("Referencia"))
                            '-----------------------------------------------------------------------
                            fpago("FPAGOID") = CStr(row("FormaPagoID"))
                            fpago("TPAGO") = CStr(row("CodFormasPago"))
                            fpago("REFBA") = strNumRef
                            fpago("MONTO") = CDec(rowAnt("Abono"))
                            fpago("RCAJA") = CStr(rowAnt("DocFi"))
                            fpago("CLCOB") = CStr(rowAnt("ClaCobr")).Trim()
                            fpago("COMPE") = "X"
                            fpago("PAGEN") = "X"
                            fpago("SIHAY") = ""
                            dsBanco = Me.BancoSel(oZBAPI_ABONO_CIERREDIA.Tienda, CStr(fpago("CLCOB")))
                            If dsBanco.Tables(0).Rows.Count > 0 Then
                                fpago("BANCO") = dsBanco.Tables(0).Rows(0)!Banco
                            Else
                                fpago("BANCO") = ""
                            End If
                            oZBAPI_ABONO_CIERREDIA.FormasPago.Rows.Add(fpago)
                        Next
                    End If
                Next
                oProcesosSAPMgr.WRITE_ZBAPI_ABONO_CIERREDIA(oZBAPI_ABONO_CIERREDIA, dt)
                Dim strError As String = ""
                For Each row As DataRow In dt.Rows
                    If dt.Columns.Contains("TYPE") Then
                        If row.IsNull("TYPE") = False Then
                            If CStr(row("TYPE")) = "E" Or CStr(row("TYPE")) = "W" Then
                                strError &= CStr(row("MESSAGE"))
                            End If
                        End If
                    End If
                Next
                If strError.Trim() <> "" Then
                    strMensaje &= strError & vbCrLf
                End If
                For Each row As DataRow In oZBAPI_ABONO_CIERREDIA.FormasPago.Rows
                    FacturaFI05ok(CInt(row("FPAGOID")))
                Next
            End If

            '------------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 27/02/2016: Se suben los pagos de Fonacot
            '------------------------------------------------------------------------------------------------------------------

            Dim dvVentasFonacot As New DataView(dsVentas.Tables(0))
            dvVentasFonacot.RowFilter = "CodTipoVenta='K' OR CodTipoVenta='F'"
            dvVentasFonacot.Sort = "Referencia"
            dvVentasFonacot.RowStateFilter = DataViewRowState.CurrentRows
            If dvVentasFonacot.Count > 0 Then
                oZBAPI_ABONO_CIERREDIA = New ZBapiAbonoCierreDia
                oZBAPI_ABONO_CIERREDIA.Tienda = "T" & oParent.ApplicationContext.ApplicationConfiguration.Almacen
                oZBAPI_ABONO_CIERREDIA.Cliente = oParent.ApplicationContext.ApplicationConfiguration.Almacen.PadLeft(10, "0")
                oZBAPI_ABONO_CIERREDIA.MotivoPedido = "ZFO"
                oZBAPI_ABONO_CIERREDIA.Fecha = FechaCierre.ToString("yyyyMMdd")
                oZBAPI_ABONO_CIERREDIA.i_FactDpPro = "X"
                oZBAPI_ABONO_CIERREDIA.i_Mode = "N"
                oZBAPI_ABONO_CIERREDIA.Devolucion = False
                Dim contratoMgr As New ContratoManager(oParent.ApplicationContext)
                For Each row As DataRowView In dvVentasFonacot
                    rows = oZBAPI_ABONO_CIERREDIA.Documents.Select("BSTNK='" & CStr(row("Referencia")) & "'")
                    If rows.Length = 0 Then
                        fila = oZBAPI_ABONO_CIERREDIA.Documents.NewRow()
                        fila("BSTNK") = CStr(row("Referencia"))
                        oZBAPI_ABONO_CIERREDIA.Documents.Rows.Add(fila)
                    End If
                    fpago = oZBAPI_ABONO_CIERREDIA.FormasPago.NewRow()
                    '-----------------------------------------------------------------------
                    ' JNAVA (11.11.2016): Agregamos el campo BSTNK = Referencia de Factura
                    '-----------------------------------------------------------------------
                    fpago("BSTNK") = CStr(row("Referencia"))
                    '-----------------------------------------------------------------------
                    fpago("FPAGOID") = CStr(row("FormaPagoID"))
                    fpago("TPAGO") = CStr(row("CodFormasPago"))
                    fpago("REFBA") = strNumRef
                    fpago("MONTO") = CDec(row("Monto"))
                    fpago("RCAJA") = ""
                    fpago("PAGEN") = ""
                    fpago("SIHAY") = ""
                    Select Case CStr(row("CodFormasPago")).Trim()
                        Case "EFEC"
                            fpago("CLCOB") = "EFECTIVO"
                        Case "TACR"
                            Select Case CStr(row("CodBanco")).Trim()
                                Case "T1"
                                    fpago("CLCOB") = "TARJETA 1".PadRight(9, " ")
                                    fpago("REFBA") = CStr(row("NoAfiliacion")) & Format(FechaCierre, "ddMMyy")
                                Case "T2"
                                    fpago("CLCOB") = "TARJETA 2".PadRight(9, " ")
                                    fpago("REFBA") = CStr(row("NoAfiliacion")) & Format(FechaCierre, "ddMMyy")
                                Case "T3"
                                    fpago("CLCOB") = "TARJETA 3".PadRight(9, " ")
                                    fpago("REFBA") = CStr(row("NoAfiliacion")) & Format(FechaCierre, "ddMMyy")
                                Case Else
                                    fpago("CLCOB") = ""
                            End Select
                        Case "TADB"
                            Select Case CStr(row("CodBanco")).Trim()
                                Case "T1"
                                    fpago("CLCOB") = "TARJETA 1".PadRight(9, " ")
                                    fpago("REFBA") = CStr(row("NoAfiliacion")) & Format(FechaCierre, "ddMMyy")
                                Case "T2"
                                    fpago("CLCOB") = "TARJETA 2".PadRight(9, " ")
                                    fpago("REFBA") = CStr(row("NoAfiliacion")) & Format(FechaCierre, "ddMMyy")
                                Case "T3"
                                    fpago("CLCOB") = "TARJETA 3".PadRight(9, " ")
                                    fpago("REFBA") = CStr(row("NoAfiliacion")) & Format(FechaCierre, "ddMMyy")
                                Case Else
                                    fpago("CLCOB") = ""
                            End Select
                        Case "FACI"
                            fpago("CLCOB") = ""
                        Case "FONA"
                            fpago("CLCOB") = ""
                        Case "VCJA"
                            oValeCaja = oValeCajaMgr.GetByValeCajaId(CInt(row("DPValeID")))
                            fpago("RCAJA") = oValeCaja.FolioDocumento
                            fpago("CLCOB") = ""
                            If oValeCaja.TipoDocumento.Trim() = "CP" Or oValeCaja.TipoDocumento.Trim() = "PI" Then fpago("SIHAY") = "X"
                        Case "DPPT"
                            fpago("CLCOB") = "DPPUNTOS".PadRight(9, " ")
                        Case "DPCA"
                            fpago("CLCOB") = "DPCARDCR".PadRight(9, " ")
                        Case "TFON", "FONA"
                            fpago("CLCOB") = ""
                    End Select
                    fpago("COMPE") = ""
                    dsBanco = Me.BancoSel(oZBAPI_ABONO_CIERREDIA.Tienda, CStr(fpago("CLCOB")))
                    If dsBanco.Tables(0).Rows.Count > 0 Then
                        fpago("BANCO") = dsBanco.Tables(0).Rows(0)!Banco
                    Else
                        fpago("BANCO") = ""
                    End If
                    oZBAPI_ABONO_CIERREDIA.FormasPago.Rows.Add(fpago)
                Next
                oProcesosSAPMgr.WRITE_ZBAPI_ABONO_CIERREDIA(oZBAPI_ABONO_CIERREDIA, dt)
                Dim strError As String = ""
                For Each row As DataRow In dt.Rows
                    If dt.Columns.Contains("TYPE") Then
                        If row.IsNull("TYPE") = False Then
                            If CStr(row("TYPE")) = "E" Or CStr(row("TYPE")) = "W" Then
                                strError &= CStr(row("MESSAGE"))
                            End If
                        End If
                    End If
                Next
                If strError.Trim() <> "" Then
                    strMensaje &= strError & vbCrLf
                End If
                For Each row As DataRow In oZBAPI_ABONO_CIERREDIA.FormasPago.Rows
                    FacturaFI05ok(CInt(row("FPAGOID")))
                Next
            End If

            '------------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 27/02/2016: Se suben los pagos de Ventas de Empleados
            '------------------------------------------------------------------------------------------------------------------

            Dim dvVentasEmpleados As New DataView(dsVentas.Tables(0))
            dvVentasEmpleados.RowFilter = "CodTipoVenta='E'"
            dvVentasEmpleados.Sort = "Referencia"
            dvVentasEmpleados.RowStateFilter = DataViewRowState.CurrentRows
            If dvVentasEmpleados.Count > 0 Then
                oZBAPI_ABONO_CIERREDIA = New ZBapiAbonoCierreDia
                oZBAPI_ABONO_CIERREDIA.Tienda = "T" & oParent.ApplicationContext.ApplicationConfiguration.Almacen
                oZBAPI_ABONO_CIERREDIA.Cliente = oParent.ApplicationContext.ApplicationConfiguration.Almacen.PadLeft(10, "0")
                oZBAPI_ABONO_CIERREDIA.MotivoPedido = "ZVE"
                oZBAPI_ABONO_CIERREDIA.Fecha = FechaCierre.ToString("yyyyMMdd")
                oZBAPI_ABONO_CIERREDIA.i_FactDpPro = "X"
                oZBAPI_ABONO_CIERREDIA.i_Mode = "N"
                oZBAPI_ABONO_CIERREDIA.Devolucion = False
                Dim contratoMgr As New ContratoManager(oParent.ApplicationContext)
                For Each row As DataRowView In dvVentasEmpleados
                    rows = oZBAPI_ABONO_CIERREDIA.Documents.Select("BSTNK='" & CStr(row("Referencia")) & "'")
                    If rows.Length = 0 Then
                        fila = oZBAPI_ABONO_CIERREDIA.Documents.NewRow()
                        fila("BSTNK") = CStr(row("Referencia"))
                        oZBAPI_ABONO_CIERREDIA.Documents.Rows.Add(fila)
                    End If
                    fpago = oZBAPI_ABONO_CIERREDIA.FormasPago.NewRow()
                    '-----------------------------------------------------------------------
                    ' JNAVA (11.11.2016): Agregamos el campo BSTNK = Referencia de Factura
                    '-----------------------------------------------------------------------
                    fpago("BSTNK") = CStr(row("Referencia"))
                    '-----------------------------------------------------------------------
                    fpago("FPAGOID") = CStr(row("FormaPagoID"))
                    fpago("TPAGO") = CStr(row("CodFormasPago"))
                    fpago("REFBA") = strNumRef
                    fpago("MONTO") = CDec(row("Monto"))
                    fpago("RCAJA") = ""
                    fpago("PAGEN") = ""
                    fpago("SIHAY") = ""
                    Select Case CStr(row("CodFormasPago")).Trim()
                        Case "EFEC"
                            fpago("CLCOB") = "EFECTIVO"
                        Case "TACR"
                            Select Case CStr(row("CodBanco")).Trim()
                                Case "T1"
                                    fpago("CLCOB") = "TARJETA 1".PadRight(9, " ")
                                    fpago("REFBA") = CStr(row("NoAfiliacion")) & Format(FechaCierre, "ddMMyy")
                                Case "T2"
                                    fpago("CLCOB") = "TARJETA 2".PadRight(9, " ")
                                    fpago("REFBA") = CStr(row("NoAfiliacion")) & Format(FechaCierre, "ddMMyy")
                                Case "T3"
                                    fpago("CLCOB") = "TARJETA 3".PadRight(9, " ")
                                    fpago("REFBA") = CStr(row("NoAfiliacion")) & Format(FechaCierre, "ddMMyy")
                                Case Else
                                    fpago("CLCOB") = ""
                            End Select
                        Case "TADB"
                            Select Case CStr(row("CodBanco")).Trim()
                                Case "T1"
                                    fpago("CLCOB") = "TARJETA 1".PadRight(9, " ")
                                    fpago("REFBA") = CStr(row("NoAfiliacion")) & Format(FechaCierre, "ddMMyy")
                                Case "T2"
                                    fpago("CLCOB") = "TARJETA 2".PadRight(9, " ")
                                    fpago("REFBA") = CStr(row("NoAfiliacion")) & Format(FechaCierre, "ddMMyy")
                                Case "T3"
                                    fpago("CLCOB") = "TARJETA 3".PadRight(9, " ")
                                    fpago("REFBA") = CStr(row("NoAfiliacion")) & Format(FechaCierre, "ddMMyy")
                                Case Else
                                    fpago("CLCOB") = ""
                            End Select
                        Case "FACI"
                            fpago("CLCOB") = ""
                        Case "FONA"
                            fpago("CLCOB") = ""
                        Case "VCJA"
                            oValeCaja = oValeCajaMgr.GetByValeCajaId(CInt(row("DPValeID")))
                            fpago("RCAJA") = oValeCaja.FolioDocumento
                            fpago("CLCOB") = ""
                            If oValeCaja.TipoDocumento.Trim() = "CP" Or oValeCaja.TipoDocumento.Trim() = "PI" Then fpago("SIHAY") = "X"
                        Case "DPPT"
                            fpago("CLCOB") = "DPPUNTOS".PadRight(9, " ")
                        Case "DPCA"
                            fpago("CLCOB") = "DPCARDCR".PadRight(9, " ")
                    End Select
                    fpago("COMPE") = "X"
                    dsBanco = Me.BancoSel(oZBAPI_ABONO_CIERREDIA.Tienda, CStr(fpago("CLCOB")))
                    If dsBanco.Tables(0).Rows.Count > 0 Then
                        fpago("BANCO") = dsBanco.Tables(0).Rows(0)!Banco
                    Else
                        fpago("BANCO") = ""
                    End If
                    oZBAPI_ABONO_CIERREDIA.FormasPago.Rows.Add(fpago)
                Next
                oProcesosSAPMgr.WRITE_ZBAPI_ABONO_CIERREDIA(oZBAPI_ABONO_CIERREDIA, dt)
                Dim strError As String = ""
                For Each row As DataRow In dt.Rows
                    If dt.Columns.Contains("TYPE") Then
                        If row.IsNull("TYPE") = False Then
                            If CStr(row("TYPE")) = "E" Or CStr(row("TYPE")) = "W" Then
                                strError &= CStr(row("MESSAGE"))
                            End If
                        End If
                    End If
                Next
                If strError.Trim() <> "" Then
                    strMensaje &= strError & vbCrLf
                End If
                For Each row As DataRow In oZBAPI_ABONO_CIERREDIA.FormasPago.Rows
                    FacturaFI05ok(CInt(row("FPAGOID")))
                Next
            End If

            '------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 26/02/2016: Pagos de Facturación Fiscal
            '------------------------------------------------------------------------------------------------------
            Dim dvVentasFF As New DataView(dsVentas.Tables(0))
            Dim FacturaId As String = ""
            dvVentasFF.RowFilter = "CodTipoVenta='I'"
            dvVentasFF.Sort = "FacturaID"
            dvVentasFF.RowStateFilter = DataViewRowState.CurrentRows
            If dvVentasFF.Count > 0 Then
                Dim strErrorFF As String = ""
                For Each row As DataRowView In dvVentasFF
                    If FacturaId <> CStr(row("FacturaID")) Then
                        If FacturaId <> "" Then
                            oProcesosSAPMgr.WRITE_ZBAPI_ABONO_CIERREDIA(oZBAPI_ABONO_CIERREDIA, dt)

                            For Each rowErr As DataRow In dt.Rows
                                If dt.Columns.Contains("TYPE") Then
                                    If rowErr.IsNull("TYPE") = False Then
                                        If CStr(rowErr("TYPE")) = "E" Or CStr(rowErr("TYPE")) = "W" Then
                                            strErrorFF &= CStr(rowErr("MESSAGE"))
                                        End If
                                    End If
                                End If
                            Next
                            If strErrorFF.Trim() <> "" Then
                                strMensaje &= strErrorFF & vbCrLf
                            End If
                            For Each rowNota As DataRow In oZBAPI_ABONO_CIERREDIA.FormasPago.Rows
                                FacturaFI05ok(CInt(rowNota("FPAGOID")))
                            Next
                        End If
                        FacturaId = CStr(row("FacturaID"))
                        oZBAPI_ABONO_CIERREDIA = New ZBapiAbonoCierreDia
                        oZBAPI_ABONO_CIERREDIA.Tienda = "T" & oParent.ApplicationContext.ApplicationConfiguration.Almacen
                        oZBAPI_ABONO_CIERREDIA.Cliente = oParent.ApplicationContext.ApplicationConfiguration.Almacen.PadLeft(10, "0")
                        oZBAPI_ABONO_CIERREDIA.MotivoPedido = "ZFF"
                        oZBAPI_ABONO_CIERREDIA.Fecha = FechaCierre.ToString("yyyyMMdd")
                        oZBAPI_ABONO_CIERREDIA.i_FactDpPro = "X"
                        oZBAPI_ABONO_CIERREDIA.i_Mode = "N"
                        oZBAPI_ABONO_CIERREDIA.Devolucion = False
                    End If
                    rows = oZBAPI_ABONO_CIERREDIA.Documents.Select("BSTNK='" & CStr(row("Referencia")) & "'")
                    If rows.Length = 0 Then
                        fila = oZBAPI_ABONO_CIERREDIA.Documents.NewRow()
                        fila("BSTNK") = CStr(row("Referencia"))
                        oZBAPI_ABONO_CIERREDIA.Documents.Rows.Add(fila)
                    End If
                    fpago = oZBAPI_ABONO_CIERREDIA.FormasPago.NewRow()
                    '-----------------------------------------------------------------------
                    ' JNAVA (11.11.2016): Agregamos el campo BSTNK = Referencia de Factura
                    '-----------------------------------------------------------------------
                    fpago("BSTNK") = CStr(row("Referencia"))
                    '-----------------------------------------------------------------------
                    fpago("FPAGOID") = CStr(row("FormaPagoID"))
                    fpago("TPAGO") = CStr(row("CodFormasPago"))
                    fpago("BANCO") = oZBAPI_ABONO_CIERREDIA.Banco
                    fpago("REFBA") = strNumRef
                    fpago("MONTO") = CDec(row("Monto"))
                    fpago("RCAJA") = ""
                    fpago("PAGEN") = ""
                    fpago("SIHAY") = ""
                    Select Case CStr(row("CodFormasPago")).Trim()
                        Case "EFEC"
                            fpago("CLCOB") = "EFECTIVO"
                        Case "TACR"
                            Select Case CStr(row("CodBanco")).Trim()
                                Case "T1"
                                    fpago("CLCOB") = "TARJETA 1".PadRight(9, " ")
                                    fpago("REFBA") = CStr(row("NoAfiliacion")) & Format(FechaCierre, "ddMMyy")
                                Case "T2"
                                    fpago("CLCOB") = "TARJETA 2".PadRight(9, " ")
                                    fpago("REFBA") = CStr(row("NoAfiliacion")) & Format(FechaCierre, "ddMMyy")
                                Case "T3"
                                    fpago("CLCOB") = "TARJETA 3".PadRight(9, " ")
                                    fpago("REFBA") = CStr(row("NoAfiliacion")) & Format(FechaCierre, "ddMMyy")
                                Case Else
                                    fpago("CLCOB") = ""
                            End Select
                        Case "TADB"
                            Select Case CStr(row("CodBanco")).Trim()
                                Case "T1"
                                    fpago("CLCOB") = "TARJETA 1".PadRight(9, " ")
                                    fpago("REFBA") = CStr(row("NoAfiliacion")) & Format(FechaCierre, "ddMMyy")
                                Case "T2"
                                    fpago("CLCOB") = "TARJETA 2".PadRight(9, " ")
                                    fpago("REFBA") = CStr(row("NoAfiliacion")) & Format(FechaCierre, "ddMMyy")
                                Case "T3"
                                    fpago("CLCOB") = "TARJETA 3".PadRight(9, " ")
                                    fpago("REFBA") = CStr(row("NoAfiliacion")) & Format(FechaCierre, "ddMMyy")
                                Case Else
                                    fpago("CLCOB") = ""
                            End Select
                        Case "FACI"
                            fpago("CLCOB") = ""
                        Case "FONA"
                            fpago("CLCOB") = ""
                        Case "VCJA"
                            oValeCaja = oValeCajaMgr.GetByValeCajaId(CInt(row("DPValeID")))
                            fpago("RCAJA") = oValeCaja.FolioDocumento
                            fpago("CLCOB") = ""
                            If oValeCaja.TipoDocumento.Trim() = "CP" Or oValeCaja.TipoDocumento.Trim() = "PI" Then fpago("SIHAY") = "X"
                        Case "DPPT"
                            fpago("CLCOB") = "DPPUNTOS".PadRight(9, " ")
                        Case "DPCA"
                            fpago("CLCOB") = "DPCARDCR".PadRight(9, " ")
                    End Select
                    fpago("COMPE") = "X"
                    fpago("PAGEN") = ""
                    dsBanco = Me.BancoSel(oZBAPI_ABONO_CIERREDIA.Tienda, CStr(fpago("CLCOB")))
                    If dsBanco.Tables(0).Rows.Count > 0 Then
                        fpago("BANCO") = dsBanco.Tables(0).Rows(0)!Banco
                    Else
                        fpago("BANCO") = ""
                    End If
                    oZBAPI_ABONO_CIERREDIA.FormasPago.Rows.Add(fpago)
                Next
                oProcesosSAPMgr.WRITE_ZBAPI_ABONO_CIERREDIA(oZBAPI_ABONO_CIERREDIA, dt)
                Dim strError As String = ""
                For Each rowErr As DataRow In dt.Rows
                    If dt.Columns.Contains("TYPE") Then
                        If rowErr.IsNull("TYPE") = False Then
                            If CStr(rowErr("TYPE")) = "E" Or CStr(rowErr("TYPE")) = "W" Then
                                strError &= CStr(rowErr("MESSAGE"))
                            End If
                        End If
                    End If
                Next
                If strError.Trim() <> "" Then
                    strMensaje &= strError & vbCrLf
                End If
                For Each rowNota As DataRow In oZBAPI_ABONO_CIERREDIA.FormasPago.Rows
                    FacturaFI05ok(CInt(rowNota("FPAGOID")))
                Next
            End If

            '------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 08/02/2017: Se suben las formas de pagos de los abonos de DPCard
            '------------------------------------------------------------------------------------------------------

            Dim dtPagosDpCard As DataTable = GetFormasPagosAbonosDPCard(FechaCierre)
            Dim oCatalogoBancoMgr As New CatalogoBancosAU.CatalogoBancosManager(oParent.ApplicationContext)
            If dtPagosDpCard.Rows.Count > 0 Then
                oZBAPI_ABONO_CIERREDIA = New ZBapiAbonoCierreDia
                oZBAPI_ABONO_CIERREDIA.Tienda = "T" & oParent.ApplicationContext.ApplicationConfiguration.Almacen
                oZBAPI_ABONO_CIERREDIA.Cliente = oParent.ApplicationContext.ApplicationConfiguration.Almacen.PadLeft(10, "0")
                oZBAPI_ABONO_CIERREDIA.MotivoPedido = "ZAD"
                oZBAPI_ABONO_CIERREDIA.Fecha = FechaCierre.ToString("yyyyMMdd")
                oZBAPI_ABONO_CIERREDIA.i_FactDpPro = "X"
                oZBAPI_ABONO_CIERREDIA.i_Mode = "N"
                oZBAPI_ABONO_CIERREDIA.Devolucion = False
                Dim contratoMgr As New ContratoManager(oParent.ApplicationContext)
                Dim dtBanco As DataTable = oCatalogoBancoMgr.GetAll(False).Tables(0)
                Dim dvBanco As DataView = Nothing
                Dim strAfiliacion As String = ""
                For Each row As DataRow In dtPagosDpCard.Rows
                    fpago = oZBAPI_ABONO_CIERREDIA.FormasPago.NewRow()
                    fpago("TPAGO") = "ABDC"
                    fpago("REFBA") = strNumRef
                    fpago("MONTO") = CDec(row("MontoPago"))
                    fpago("RCAJA") = ""
                    fpago("PAGEN") = ""
                    fpago("BSTNK") = ""
                    fpago("SIHAY") = ""
                    Select Case CStr(row("CodFormasPago")).Trim()
                        Case "EFEC"
                            fpago("CLCOB") = "ABDPCEFEC"
                        Case "TACR"
                            dvBanco = New DataView(dtBanco, "CodBanco = '" & CStr(row("CodBanco")) & "'", "CodBanco", DataViewRowState.CurrentRows)
                            strAfiliacion = oFacturaMgr.GetAfiliacion(CInt(row("Promocion")), dvBanco(0)!IDEmisor)
                            Select Case CStr(row("CodBanco")).Trim()
                                Case "T1"
                                    fpago("CLCOB") = "ABDPCTAR1"
                                    fpago("REFBA") = strAfiliacion & Format(FechaCierre, "ddMMyy")
                                Case "T2"
                                    fpago("CLCOB") = "ABDPCTAR2"
                                    fpago("REFBA") = strAfiliacion & Format(FechaCierre, "ddMMyy")
                                Case "T3"
                                    fpago("CLCOB") = "ABDPCTAR3"
                                    fpago("REFBA") = strAfiliacion & Format(FechaCierre, "ddMMyy")
                                Case Else
                                    fpago("CLCOB") = ""
                            End Select
                        Case "TADB"
                            dvBanco = New DataView(dtBanco, "CodBanco = '" & CStr(row("CodBanco")) & "'", "CodBanco", DataViewRowState.CurrentRows)
                            strAfiliacion = oFacturaMgr.GetAfiliacion(CInt(row("Promocion")), dvBanco(0)!IDEmisor)
                            Select Case CStr(row("CodBanco")).Trim()
                                Case "T1"
                                    fpago("CLCOB") = "ABDPCTAR1"
                                    fpago("REFBA") = strAfiliacion & Format(FechaCierre, "ddMMyy")
                                Case "T2"
                                    fpago("CLCOB") = "ABDPCTAR2"
                                    fpago("REFBA") = strAfiliacion & Format(FechaCierre, "ddMMyy")
                                Case "T3"
                                    fpago("CLCOB") = "ABDPCTAR3"
                                    fpago("REFBA") = strAfiliacion & Format(FechaCierre, "ddMMyy")
                                Case Else
                                    fpago("CLCOB") = ""
                            End Select
                        Case "FACI"
                            fpago("CLCOB") = ""
                        Case "FONA"
                            fpago("CLCOB") = ""
                        Case "VCJA"
                            oValeCaja = oValeCajaMgr.GetByValeCajaId(CInt(row("DPValeID")))
                            fpago("RCAJA") = oValeCaja.FolioDocumento
                            fpago("CLCOB") = ""
                            If oValeCaja.TipoDocumento.Trim() = "CP" Or oValeCaja.TipoDocumento.Trim() = "PI" Then fpago("SIHAY") = "X"
                        Case "DPPT"
                            fpago("CLCOB") = "DPPUNTOS".PadRight(9, " ")
                        Case "DPCA"
                            fpago("CLCOB") = "DPCARDCR".PadRight(9, " ")
                    End Select
                    fpago("COMPE") = ""
                    dsBanco = Me.BancoSel(oZBAPI_ABONO_CIERREDIA.Tienda, CStr(fpago("CLCOB")))
                    If dsBanco.Tables(0).Rows.Count > 0 Then
                        fpago("BANCO") = dsBanco.Tables(0).Rows(0)!Banco
                    Else
                        fpago("BANCO") = ""
                    End If
                    oZBAPI_ABONO_CIERREDIA.FormasPago.Rows.Add(fpago)
                Next
                oProcesosSAPMgr.WRITE_ZBAPI_ABONO_CIERREDIA(oZBAPI_ABONO_CIERREDIA, dt)
                Dim strError As String = ""
                For Each row As DataRow In dt.Rows
                    If dt.Columns.Contains("TYPE") Then
                        If row.IsNull("TYPE") = False Then
                            If CStr(row("TYPE")) = "E" Or CStr(row("TYPE")) = "W" Then
                                strError &= CStr(row("MESSAGE"))
                            End If
                        End If
                    End If
                Next
                If strError.Trim() <> "" Then
                    strMensaje &= strError & vbCrLf
                End If
                For Each row As DataRow In dtPagosDpCard.Rows
                    ActualizarCompensarPagos(CInt(row("OtrosPagosDetalleID")))
                Next
            End If

            ''*********************************PUBLICO GENERAL******************************
            ' ''Pagos Terminal 1
            'dvTarjetaUno.RowFilter = "CodBanco like 'T1' and CodTipoVenta='P'"
            'dvTarjetaUno.Sort = "Referencia"
            'dvTarjetaUno.RowStateFilter = DataViewRowState.OriginalRows

            ''txtWriter.WriteLine(Chr(13)) 

            'If dvTarjetaUno.Count > 0 Then
            '    dt = New DataTable

            '    oZBAPI_ABONO_CIERREDIA = New ZBapiAbonoCierreDia

            '    oZBAPI_ABONO_CIERREDIA.Tienda = CStr(dvTarjetaUno(0)("Tienda")).PadRight(20, " ")

            '    oZBAPI_ABONO_CIERREDIA.Cliente = oParent.ApplicationContext.ApplicationConfiguration.Almacen.PadLeft(10, "0")

            '    oZBAPI_ABONO_CIERREDIA.Detalle = "X"

            '    'oZBAPI_ABONO_CIERREDIA.Ref_Banco = strNumRefBBV & FechaCierre.ToShortDateString.Replace("/", "")

            '    oZBAPI_ABONO_CIERREDIA.ClaCobr = "TARJETA 1".PadRight(9, " ")

            '    dsBanco = Me.BancoSel(oZBAPI_ABONO_CIERREDIA.Tienda, oZBAPI_ABONO_CIERREDIA.ClaCobr)
            '    If dsBanco.Tables(0).Rows.Count > 0 Then
            '        oZBAPI_ABONO_CIERREDIA.Banco = dsBanco.Tables(0).Rows(0).Item("Banco")
            '        oZBAPI_ABONO_CIERREDIA.HKONT = dsBanco.Tables(0).Rows(0)!HKONT
            '        oZBAPI_ABONO_CIERREDIA.Gsberg = dsBanco.Tables(0).Rows(0)!Gsberg
            '    Else
            '        oZBAPI_ABONO_CIERREDIA.Banco = ""
            '        oZBAPI_ABONO_CIERREDIA.HKONT = ""
            '        oZBAPI_ABONO_CIERREDIA.Gsberg = ""
            '    End If

            '    oZBAPI_ABONO_CIERREDIA.i_FactDpPro = "X"

            '    oZBAPI_ABONO_CIERREDIA.i_Mode = "N"

            '    For intIndex = 0 To dvTarjetaUno.Count - 1

            '        If CStr(dvTarjetaUno(0)("NoAfiliacion")).Length > 6 Then
            '            strNumRefBBV = Mid(CStr(dvTarjetaUno(intIndex)("NoAfiliacion")), 2)
            '        Else
            '            strNumRefBBV = CStr(dvTarjetaUno(intIndex)("NoAfiliacion")).PadLeft(6, "0")
            '        End If

            '        oZBAPI_ABONO_CIERREDIA.Ref_Banco = strNumRefBBV & Format(FechaRefBancos, "ddMMyyyy") '& _
            '        'Mid(Format(FechaCierre, "yyyy"), 2)
            '        fecha = CStr(CDate(dvTarjetaUno(intIndex)("Fecha")).ToShortDateString.Replace("/", ""))
            '        oZBAPI_ABONO_CIERREDIA.Fecha = Mid(fecha, 5, 4) & Mid(fecha, 3, 2) & Mid(fecha, 1, 2)
            '        oZBAPI_ABONO_CIERREDIA.Importe = CStr(dvTarjetaUno(intIndex)("Monto")).PadRight(16, " ")
            '        oZBAPI_ABONO_CIERREDIA.vBeln = CStr(dvTarjetaUno(intIndex)("FolioSAP")).PadLeft(10, "0")

            '        oProcesosSAPMgr = New ProcesoSAPManager(Me.oParent.ApplicationContext, Me.oParent.SAPApplicationConfig)
            '        'oZBAPI_ABONO_CIERREDIA.Fecha = "20150922"
            '        'strResult = oProcesosSAPMgr.WRITE_ZBAPI_ABONO_CIERREDIA(oZBAPI_ABONO_CIERREDIA, dt)
            '        oProcesosSAPMgr.WRITE_ZBAPI_ABONO_CIERREDIA(oZBAPI_ABONO_CIERREDIA, dt)
            '        Dim strError As String = ""
            '        For Each row As DataRow In dt.Rows
            '            If CStr(row("TYPE")).Trim() = "E" Then
            '                strError &= CStr(row("MESSAGE"))
            '            End If
            '        Next
            '        If strError.Trim() <> "" Then
            '            strMensaje &= strError & vbCrLf
            '        End If

            '        'If strResult = "Y" Then
            '        '    'actualizar el campo FI05SAP
            '        '    FacturaFI05ok(oZBAPI_ABONO_CIERREDIA.vBeln, oZBAPI_ABONO_CIERREDIA.ClaCobr)
            '        'Else
            '        '    strMensaje += "FolioSAP: " & oZBAPI_ABONO_CIERREDIA.vBeln & vbCrLf
            '        '    For Each orow As DataRow In dt.Rows
            '        '        strMensaje += "Error: " & orow.Item("Message") & vbCrLf
            '        '    Next
            '        '    strMensaje += vbCrLf

            '        '    sm_GenerateFileTxtUp = "N"

            '        'End If

            '        'strResult = ""

            '    Next


            'End If

            ' ''Pagos Terminal 2
            'dvTarjetaUno.RowFilter = "CodBanco like 'T2' and CodTipoVenta='P'"

            'If dvTarjetaUno.Count > 0 Then
            '    dt = New DataTable

            '    oZBAPI_ABONO_CIERREDIA = New ZBapiAbonoCierreDia

            '    oZBAPI_ABONO_CIERREDIA.Tienda = CStr(dvTarjetaUno(0)("Tienda")).PadRight(20, " ")

            '    oZBAPI_ABONO_CIERREDIA.Cliente = oParent.ApplicationContext.ApplicationConfiguration.Almacen.PadLeft(10, "0")

            '    oZBAPI_ABONO_CIERREDIA.Detalle = "X"

            '    'oZBAPI_ABONO_CIERREDIA.Ref_Banco = "    " & FechaCierre.ToShortDateString.Replace("/", "")

            '    oZBAPI_ABONO_CIERREDIA.ClaCobr = "TARJETA 2".PadRight(9, " ")

            '    dsBanco = Me.BancoSel(oZBAPI_ABONO_CIERREDIA.Tienda, oZBAPI_ABONO_CIERREDIA.ClaCobr)
            '    If dsBanco.Tables(0).Rows.Count > 0 Then
            '        oZBAPI_ABONO_CIERREDIA.Banco = dsBanco.Tables(0).Rows(0).Item("Banco")
            '    Else
            '        oZBAPI_ABONO_CIERREDIA.Banco = ""
            '    End If

            '    oZBAPI_ABONO_CIERREDIA.i_FactDpPro = "X"

            '    oZBAPI_ABONO_CIERREDIA.i_Mode = "N"

            '    For intIndex = 0 To dvTarjetaUno.Count - 1
            '        strNumRefBBV = CStr(dvTarjetaUno(intIndex)("NoAfiliacion"))
            '        oZBAPI_ABONO_CIERREDIA.Ref_Banco = strNumRefBBV & Format(FechaRefBancos, "ddMMyy")
            '        fecha = CStr(CDate(dvTarjetaUno(intIndex)("Fecha")).ToShortDateString.Replace("/", ""))
            '        oZBAPI_ABONO_CIERREDIA.Fecha = Mid(fecha, 5, 4) & Mid(fecha, 3, 2) & Mid(fecha, 1, 2)
            '        oZBAPI_ABONO_CIERREDIA.Importe = CStr(dvTarjetaUno(intIndex)("Monto")).PadRight(16, " ")
            '        oZBAPI_ABONO_CIERREDIA.vBeln = CStr(dvTarjetaUno(intIndex)("FolioSAP")).PadLeft(10, "0")

            '        oProcesosSAPMgr = New ProcesoSAPManager(Me.oParent.ApplicationContext, Me.oParent.SAPApplicationConfig)
            '        'oZBAPI_ABONO_CIERREDIA.Fecha = "20150922"
            '        strResult = oProcesosSAPMgr.WRITE_ZBAPI_ABONO_CIERREDIA(oZBAPI_ABONO_CIERREDIA, dt)

            '        If strResult = "Y" Then
            '            'actualizar el campo FI05SAP
            '            FacturaFI05ok(oZBAPI_ABONO_CIERREDIA.vBeln, oZBAPI_ABONO_CIERREDIA.ClaCobr)
            '        Else
            '            strMensaje += "FolioSAP: " & oZBAPI_ABONO_CIERREDIA.vBeln & vbCrLf
            '            For Each orow As DataRow In dt.Rows
            '                strMensaje += "Error: " & orow.Item("Message") & vbCrLf
            '            Next
            '            strMensaje += vbCrLf

            '            sm_GenerateFileTxtUp = "N"
            '        End If

            '        strResult = ""

            '    Next


            '    'strEncabezado = "40" & "TARJETA 2".PadRight(9, " ") & CStr(dvTarjetaUno(0)("Tienda")).PadRight(20, " ") & _
            '    '                                                                  CStr(Format(dvTarjetaUno.Table.Compute("sum(Monto)", "CodBanco like 'T2'  and CodTipoVenta='P'"), "##########.#0")).PadLeft(16, " ") & _
            '    '                                                                  oParent.ApplicationContext.ApplicationConfiguration.Almacen.PadLeft(10, "0") & "    " & FechaCierre.ToShortDateString.Replace("/", "")
            '    'txtWriter.WriteLine(strEncabezado)
            '    'For intIndex = 0 To dvTarjetaUno.Count - 1
            '    '    txtWriter.WriteLine("11" & CStr(dvTarjetaUno(intIndex)("FolioSAP")).PadLeft(10, "0") & CStr(dvTarjetaUno(intIndex)("Monto")).PadRight(16, " ") & "Venta Dia " & CDate(dvTarjetaUno(intIndex)("Fecha")).ToShortDateString.Replace("/", "") & oParent.ApplicationContext.ApplicationConfiguration.Almacen.PadLeft(10, "0"))
            '    'Next

            'End If

            ' ''Pagos Terminal 3
            'dvTarjetaUno.RowFilter = "CodBanco like 'T3' and CodTipoVenta='P'"

            'If dvTarjetaUno.Count > 0 Then
            '    dt = New DataTable

            '    oZBAPI_ABONO_CIERREDIA = New ZBapiAbonoCierreDia

            '    oZBAPI_ABONO_CIERREDIA.Tienda = CStr(dvTarjetaUno(0)("Tienda")).PadRight(20, " ")

            '    oZBAPI_ABONO_CIERREDIA.Cliente = oParent.ApplicationContext.ApplicationConfiguration.Almacen.PadLeft(10, "0")

            '    oZBAPI_ABONO_CIERREDIA.Detalle = "X"

            '    'oZBAPI_ABONO_CIERREDIA.Ref_Banco = "    " & FechaCierre.ToShortDateString.Replace("/", "")

            '    oZBAPI_ABONO_CIERREDIA.ClaCobr = "TARJETA 3".PadRight(9, " ")

            '    dsBanco = Me.BancoSel(oZBAPI_ABONO_CIERREDIA.Tienda, oZBAPI_ABONO_CIERREDIA.ClaCobr)
            '    If dsBanco.Tables(0).Rows.Count > 0 Then
            '        oZBAPI_ABONO_CIERREDIA.Banco = dsBanco.Tables(0).Rows(0).Item("Banco")
            '    Else
            '        oZBAPI_ABONO_CIERREDIA.Banco = ""
            '    End If

            '    oZBAPI_ABONO_CIERREDIA.i_FactDpPro = "X"

            '    oZBAPI_ABONO_CIERREDIA.i_Mode = "N"

            '    For intIndex = 0 To dvTarjetaUno.Count - 1
            '        strNumRefBBV = CStr(dvTarjetaUno(intIndex)("NoAfiliacion"))
            '        oZBAPI_ABONO_CIERREDIA.Ref_Banco = strNumRefBBV & Format(FechaRefBancos, "ddMMyy")
            '        fecha = CStr(CDate(dvTarjetaUno(intIndex)("Fecha")).ToShortDateString.Replace("/", ""))
            '        oZBAPI_ABONO_CIERREDIA.Fecha = Mid(fecha, 5, 4) & Mid(fecha, 3, 2) & Mid(fecha, 1, 2)
            '        oZBAPI_ABONO_CIERREDIA.Importe = CStr(dvTarjetaUno(intIndex)("Monto")).PadRight(16, " ")
            '        oZBAPI_ABONO_CIERREDIA.vBeln = CStr(dvTarjetaUno(intIndex)("FolioSAP")).PadLeft(10, "0")

            '        oProcesosSAPMgr = New ProcesoSAPManager(Me.oParent.ApplicationContext, Me.oParent.SAPApplicationConfig)
            '        'oZBAPI_ABONO_CIERREDIA.Fecha = "20150922"
            '        strResult = oProcesosSAPMgr.WRITE_ZBAPI_ABONO_CIERREDIA(oZBAPI_ABONO_CIERREDIA, dt)

            '        If strResult = "Y" Then
            '            'actualizar el campo FI05SAP
            '            FacturaFI05ok(oZBAPI_ABONO_CIERREDIA.vBeln, oZBAPI_ABONO_CIERREDIA.ClaCobr)
            '        Else
            '            strMensaje += "FolioSAP: " & oZBAPI_ABONO_CIERREDIA.vBeln & vbCrLf
            '            For Each orow As DataRow In dt.Rows
            '                strMensaje += "Error: " & orow.Item("Message") & vbCrLf
            '            Next
            '            strMensaje += vbCrLf

            '            sm_GenerateFileTxtUp = "N"
            '        End If

            '        strResult = ""

            '    Next


            '    'strEncabezado = "40" & "TARJETA 3".PadRight(9, " ") & CStr(dvTarjetaUno(0)("Tienda")).PadRight(20, " ") & _
            '    '                                  CStr(Format(dvTarjetaUno.Table.Compute("sum(Monto)", "CodBanco like 'T3'  and CodTipoVenta='P'"), "##########.#0")).PadLeft(16, " ") & _
            '    '                                  oParent.ApplicationContext.ApplicationConfiguration.Almacen.PadLeft(10, "0") & "    " & FechaCierre.ToShortDateString.Replace("/", "")
            '    'txtWriter.WriteLine(strEncabezado)
            '    'For intIndex = 0 To dvTarjetaUno.Count - 1
            '    '    txtWriter.WriteLine("11" & CStr(dvTarjetaUno(intIndex)("FolioSAP")).PadLeft(10, "0") & CStr(dvTarjetaUno(intIndex)("Monto")).PadRight(16, " ") & "Venta Dia " & CDate(dvTarjetaUno(intIndex)("Fecha")).ToShortDateString.Replace("/", "") & oParent.ApplicationContext.ApplicationConfiguration.Almacen.PadLeft(10, "0"))
            '    'Next

            'End If

            ' ''Pagos Efectivo
            'dvTarjetaUno.RowFilter = "CodFormasPago like 'EFEC' and CodTipoVenta='P'"

            'If dvTarjetaUno.Count > 0 Then
            '    dt = New DataTable

            '    oZBAPI_ABONO_CIERREDIA = New ZBapiAbonoCierreDia

            '    oZBAPI_ABONO_CIERREDIA.Tienda = CStr(dvTarjetaUno(0)("Tienda")).PadRight(20, " ")

            '    oZBAPI_ABONO_CIERREDIA.Cliente = oParent.ApplicationContext.ApplicationConfiguration.Almacen.PadLeft(10, "0")

            '    oZBAPI_ABONO_CIERREDIA.Detalle = "X"

            '    oZBAPI_ABONO_CIERREDIA.Ref_Banco = strNumRef

            '    oZBAPI_ABONO_CIERREDIA.ClaCobr = "EFECTIVO".PadRight(9, " ")

            '    dsBanco = Me.BancoSel(oZBAPI_ABONO_CIERREDIA.Tienda, oZBAPI_ABONO_CIERREDIA.ClaCobr)
            '    If dsBanco.Tables(0).Rows.Count > 0 Then
            '        oZBAPI_ABONO_CIERREDIA.Banco = dsBanco.Tables(0).Rows(0).Item("Banco")
            '    Else
            '        oZBAPI_ABONO_CIERREDIA.Banco = ""
            '    End If

            '    oZBAPI_ABONO_CIERREDIA.i_FactDpPro = "X"

            '    oZBAPI_ABONO_CIERREDIA.i_Mode = "N"

            '    For intIndex = 0 To dvTarjetaUno.Count - 1
            '        fecha = CStr(CDate(dvTarjetaUno(intIndex)("Fecha")).ToShortDateString.Replace("/", ""))
            '        oZBAPI_ABONO_CIERREDIA.Fecha = Mid(fecha, 5, 4) & Mid(fecha, 3, 2) & Mid(fecha, 1, 2)
            '        oZBAPI_ABONO_CIERREDIA.Importe = CStr(dvTarjetaUno(intIndex)("Monto")).PadRight(16, " ")
            '        oZBAPI_ABONO_CIERREDIA.vBeln = CStr(dvTarjetaUno(intIndex)("FolioSAP")).PadLeft(10, "0")

            '        oProcesosSAPMgr = New ProcesoSAPManager(Me.oParent.ApplicationContext, Me.oParent.SAPApplicationConfig)
            '        'oZBAPI_ABONO_CIERREDIA.Fecha = "20150922"
            '        strResult = oProcesosSAPMgr.WRITE_ZBAPI_ABONO_CIERREDIA(oZBAPI_ABONO_CIERREDIA, dt)

            '        If strResult = "Y" Then
            '            'actualizar el campo FI05SAP
            '            FacturaFI05ok(oZBAPI_ABONO_CIERREDIA.vBeln, oZBAPI_ABONO_CIERREDIA.ClaCobr)
            '        Else
            '            strMensaje += "FolioSAP: " & oZBAPI_ABONO_CIERREDIA.vBeln & vbCrLf
            '            For Each orow As DataRow In dt.Rows
            '                strMensaje += "Error: " & orow.Item("Message") & vbCrLf
            '            Next
            '            strMensaje += vbCrLf

            '            sm_GenerateFileTxtUp = "N"
            '        End If

            '        strResult = ""

            '    Next



            '    'strEncabezado = "40" & "EFECTIVO".PadRight(9, " ") & CStr(dvTarjetaUno(0)("Tienda")).PadRight(20, " ") & _
            '    '                         CStr(Format(dvTarjetaUno.Table.Compute("sum(Monto)", "CodFormasPago like 'EFEC'  and CodTipoVenta='P'"), "##########.#0")).PadLeft(16, " ") & _
            '    '                         oParent.ApplicationContext.ApplicationConfiguration.Almacen.PadLeft(10, "0") & strNumRef
            '    'txtWriter.WriteLine(strEncabezado)
            '    'For intIndex = 0 To dvTarjetaUno.Count - 1
            '    '    txtWriter.WriteLine("11" & CStr(dvTarjetaUno(intIndex)("FolioSAP")).PadLeft(10, "0") & CStr(dvTarjetaUno(intIndex)("Monto")).PadRight(16, " ") & "Venta Dia " & CDate(dvTarjetaUno(intIndex)("Fecha")).ToShortDateString.Replace("/", "") & oParent.ApplicationContext.ApplicationConfiguration.Almacen.PadLeft(10, "0"))
            '    'Next

            'End If

            ''----------------------------------------------------------------------------------------------------------------
            '' JNAVA (18.03.2015): Generamos el TXT de los Pagos DP CARD - PG
            ''----------------------------------------------------------------------------------------------------------------
            'strCliente = oParent.ApplicationContext.ApplicationConfiguration.Almacen.PadLeft(10, "0")
            'sm_GenerateFileTxtUp = GetCobranzaDPCard(dvTarjetaUno, strCliente, "P", FechaCierre, strNumRef, strNumRefBBV, sm_GenerateFileTxtUp, strMensaje)
            ''---------------------------------------------------------------------------------------------------------------------------------
            ''RGERMAIN 15.05.2015: Subimos los pagos con DPCard Puntos a SAP en las ventas de Publico en General
            ''---------------------------------------------------------------------------------------------------------------------------------
            'strMensaje &= RegistraPagosDPCardPuntosSAP(strCliente, "DPPT", "P", dvTarjetaUno, strNumRef, sm_GenerateFileTxtUp)


            ''*********************************EMPLEADOS******************************
            ' ''Pagos Terminal 1
            'dvTarjetaUno.RowFilter = "CodBanco like 'T1' and CodTipoVenta='E'"

            'If dvTarjetaUno.Count > 0 Then
            '    dt = New DataTable

            '    oZBAPI_ABONO_CIERREDIA = New ZBapiAbonoCierreDia

            '    oZBAPI_ABONO_CIERREDIA.Tienda = CStr(dvTarjetaUno(0)("Tienda")).PadRight(20, " ")

            '    oZBAPI_ABONO_CIERREDIA.Cliente = "99999".PadLeft(10, "0")

            '    oZBAPI_ABONO_CIERREDIA.Detalle = "X"

            '    oZBAPI_ABONO_CIERREDIA.ClaCobr = "TARJETA 1".PadRight(9, " ")

            '    dsBanco = Me.BancoSel(oZBAPI_ABONO_CIERREDIA.Tienda, oZBAPI_ABONO_CIERREDIA.ClaCobr)
            '    If dsBanco.Tables(0).Rows.Count > 0 Then
            '        oZBAPI_ABONO_CIERREDIA.Banco = dsBanco.Tables(0).Rows(0).Item("Banco")
            '    Else
            '        oZBAPI_ABONO_CIERREDIA.Banco = ""
            '    End If

            '    oZBAPI_ABONO_CIERREDIA.i_FactDpPro = "X"

            '    oZBAPI_ABONO_CIERREDIA.i_Mode = "N"

            '    For intIndex = 0 To dvTarjetaUno.Count - 1

            '        If CStr(dvTarjetaUno(0)("NoAfiliacion")).Length > 6 Then
            '            strNumRefBBV = Mid(CStr(dvTarjetaUno(intIndex)("NoAfiliacion")), 2)
            '        Else
            '            strNumRefBBV = CStr(dvTarjetaUno(intIndex)("NoAfiliacion")).PadLeft(6, "0")
            '        End If

            '        oZBAPI_ABONO_CIERREDIA.Ref_Banco = strNumRefBBV & Format(FechaRefBancos, "ddMMyyyy") '& _
            '        'Mid(Format(FechaCierre, "yyyy"), 2)
            '        fecha = CStr(CDate(dvTarjetaUno(intIndex)("Fecha")).ToShortDateString.Replace("/", ""))
            '        oZBAPI_ABONO_CIERREDIA.Fecha = Mid(fecha, 5, 4) & Mid(fecha, 3, 2) & Mid(fecha, 1, 2)
            '        oZBAPI_ABONO_CIERREDIA.Importe = CStr(dvTarjetaUno(intIndex)("Monto")).PadRight(16, " ")
            '        oZBAPI_ABONO_CIERREDIA.vBeln = CStr(dvTarjetaUno(intIndex)("FolioSAP")).PadLeft(10, "0")

            '        oProcesosSAPMgr = New ProcesoSAPManager(Me.oParent.ApplicationContext, Me.oParent.SAPApplicationConfig)
            '        strResult = oProcesosSAPMgr.WRITE_ZBAPI_ABONO_CIERREDIA(oZBAPI_ABONO_CIERREDIA, dt)

            '        If strResult = "Y" Then
            '            'actualizar el campo FI05SAP
            '            FacturaFI05ok(oZBAPI_ABONO_CIERREDIA.vBeln, oZBAPI_ABONO_CIERREDIA.ClaCobr)
            '        Else
            '            strMensaje += "FolioSAP: " & oZBAPI_ABONO_CIERREDIA.vBeln & vbCrLf
            '            For Each orow As DataRow In dt.Rows
            '                strMensaje += "Error: " & orow.Item("Message") & vbCrLf
            '            Next
            '            strMensaje += vbCrLf

            '            sm_GenerateFileTxtUp = "N"

            '        End If

            '        strResult = ""

            '    Next


            'End If

            ' ''Pagos Terminal 2
            'dvTarjetaUno.RowFilter = "CodBanco like 'T2' and CodTipoVenta='E'"

            'If dvTarjetaUno.Count > 0 Then
            '    dt = New DataTable

            '    oZBAPI_ABONO_CIERREDIA = New ZBapiAbonoCierreDia

            '    oZBAPI_ABONO_CIERREDIA.Tienda = CStr(dvTarjetaUno(0)("Tienda")).PadRight(20, " ")

            '    oZBAPI_ABONO_CIERREDIA.Cliente = "99999".PadLeft(10, "0")

            '    oZBAPI_ABONO_CIERREDIA.Detalle = "X"

            '    oZBAPI_ABONO_CIERREDIA.ClaCobr = "TARJETA 2".PadRight(9, " ")

            '    dsBanco = Me.BancoSel(oZBAPI_ABONO_CIERREDIA.Tienda, oZBAPI_ABONO_CIERREDIA.ClaCobr)
            '    If dsBanco.Tables(0).Rows.Count > 0 Then
            '        oZBAPI_ABONO_CIERREDIA.Banco = dsBanco.Tables(0).Rows(0).Item("Banco")
            '    Else
            '        oZBAPI_ABONO_CIERREDIA.Banco = ""
            '    End If

            '    oZBAPI_ABONO_CIERREDIA.i_FactDpPro = "X"

            '    oZBAPI_ABONO_CIERREDIA.i_Mode = "N"

            '    For intIndex = 0 To dvTarjetaUno.Count - 1
            '        strNumRefBBV = CStr(dvTarjetaUno(intIndex)("NoAfiliacion"))
            '        oZBAPI_ABONO_CIERREDIA.Ref_Banco = strNumRefBBV & Format(FechaRefBancos, "ddMMyy")
            '        fecha = CStr(CDate(dvTarjetaUno(intIndex)("Fecha")).ToShortDateString.Replace("/", ""))
            '        oZBAPI_ABONO_CIERREDIA.Fecha = Mid(fecha, 5, 4) & Mid(fecha, 3, 2) & Mid(fecha, 1, 2)
            '        oZBAPI_ABONO_CIERREDIA.Importe = CStr(dvTarjetaUno(intIndex)("Monto")).PadRight(16, " ")
            '        oZBAPI_ABONO_CIERREDIA.vBeln = CStr(dvTarjetaUno(intIndex)("FolioSAP")).PadLeft(10, "0")

            '        oProcesosSAPMgr = New ProcesoSAPManager(Me.oParent.ApplicationContext, Me.oParent.SAPApplicationConfig)
            '        strResult = oProcesosSAPMgr.WRITE_ZBAPI_ABONO_CIERREDIA(oZBAPI_ABONO_CIERREDIA, dt)

            '        If strResult = "Y" Then
            '            'actualizar el campo FI05SAP
            '            FacturaFI05ok(oZBAPI_ABONO_CIERREDIA.vBeln, oZBAPI_ABONO_CIERREDIA.ClaCobr)
            '        Else
            '            strMensaje += "FolioSAP: " & oZBAPI_ABONO_CIERREDIA.vBeln & vbCrLf
            '            For Each orow As DataRow In dt.Rows
            '                strMensaje += "Error: " & orow.Item("Message") & vbCrLf
            '            Next
            '            strMensaje += vbCrLf

            '            sm_GenerateFileTxtUp = "N"
            '        End If

            '        strResult = ""

            '    Next

            'End If

            ' ''Pagos Terminal 3
            'dvTarjetaUno.RowFilter = "CodBanco like 'T3' and CodTipoVenta='E'"

            'If dvTarjetaUno.Count > 0 Then
            '    dt = New DataTable

            '    oZBAPI_ABONO_CIERREDIA = New ZBapiAbonoCierreDia

            '    oZBAPI_ABONO_CIERREDIA.Tienda = CStr(dvTarjetaUno(0)("Tienda")).PadRight(20, " ")

            '    oZBAPI_ABONO_CIERREDIA.Cliente = "99999".PadLeft(10, "0")

            '    oZBAPI_ABONO_CIERREDIA.Detalle = "X"

            '    oZBAPI_ABONO_CIERREDIA.ClaCobr = "TARJETA 3".PadRight(9, " ")

            '    dsBanco = Me.BancoSel(oZBAPI_ABONO_CIERREDIA.Tienda, oZBAPI_ABONO_CIERREDIA.ClaCobr)
            '    If dsBanco.Tables(0).Rows.Count > 0 Then
            '        oZBAPI_ABONO_CIERREDIA.Banco = dsBanco.Tables(0).Rows(0).Item("Banco")
            '    Else
            '        oZBAPI_ABONO_CIERREDIA.Banco = ""
            '    End If

            '    oZBAPI_ABONO_CIERREDIA.i_FactDpPro = "X"

            '    oZBAPI_ABONO_CIERREDIA.i_Mode = "N"

            '    For intIndex = 0 To dvTarjetaUno.Count - 1
            '        strNumRefBBV = CStr(dvTarjetaUno(intIndex)("NoAfiliacion"))
            '        oZBAPI_ABONO_CIERREDIA.Ref_Banco = strNumRefBBV & Format(FechaRefBancos, "ddMMyy")
            '        fecha = CStr(CDate(dvTarjetaUno(intIndex)("Fecha")).ToShortDateString.Replace("/", ""))
            '        oZBAPI_ABONO_CIERREDIA.Fecha = Mid(fecha, 5, 4) & Mid(fecha, 3, 2) & Mid(fecha, 1, 2)
            '        oZBAPI_ABONO_CIERREDIA.Importe = CStr(dvTarjetaUno(intIndex)("Monto")).PadRight(16, " ")
            '        oZBAPI_ABONO_CIERREDIA.vBeln = CStr(dvTarjetaUno(intIndex)("FolioSAP")).PadLeft(10, "0")

            '        oProcesosSAPMgr = New ProcesoSAPManager(Me.oParent.ApplicationContext, Me.oParent.SAPApplicationConfig)
            '        strResult = oProcesosSAPMgr.WRITE_ZBAPI_ABONO_CIERREDIA(oZBAPI_ABONO_CIERREDIA, dt)

            '        If strResult = "Y" Then
            '            'actualizar el campo FI05SAP
            '            FacturaFI05ok(oZBAPI_ABONO_CIERREDIA.vBeln, oZBAPI_ABONO_CIERREDIA.ClaCobr)
            '        Else
            '            strMensaje += "FolioSAP: " & oZBAPI_ABONO_CIERREDIA.vBeln & vbCrLf
            '            For Each orow As DataRow In dt.Rows
            '                strMensaje += "Error: " & orow.Item("Message") & vbCrLf
            '            Next
            '            strMensaje += vbCrLf

            '            sm_GenerateFileTxtUp = "N"
            '        End If

            '        strResult = ""

            '    Next

            'End If

            ' ''Pagos Efectivo
            'dvTarjetaUno.RowFilter = "CodFormasPago like 'EFEC' and CodTipoVenta='E'"

            'If dvTarjetaUno.Count > 0 Then
            '    dt = New DataTable

            '    oZBAPI_ABONO_CIERREDIA = New ZBapiAbonoCierreDia

            '    oZBAPI_ABONO_CIERREDIA.Tienda = CStr(dvTarjetaUno(0)("Tienda")).PadRight(20, " ")

            '    oZBAPI_ABONO_CIERREDIA.Cliente = "99999".PadLeft(10, "0")

            '    oZBAPI_ABONO_CIERREDIA.Detalle = "X"

            '    oZBAPI_ABONO_CIERREDIA.Ref_Banco = strNumRef

            '    oZBAPI_ABONO_CIERREDIA.ClaCobr = "EFECTIVO".PadRight(9, " ")

            '    dsBanco = Me.BancoSel(oZBAPI_ABONO_CIERREDIA.Tienda, oZBAPI_ABONO_CIERREDIA.ClaCobr)
            '    If dsBanco.Tables(0).Rows.Count > 0 Then
            '        oZBAPI_ABONO_CIERREDIA.Banco = dsBanco.Tables(0).Rows(0).Item("Banco")
            '    Else
            '        oZBAPI_ABONO_CIERREDIA.Banco = ""
            '    End If

            '    oZBAPI_ABONO_CIERREDIA.i_FactDpPro = "X"

            '    oZBAPI_ABONO_CIERREDIA.i_Mode = "N"

            '    For intIndex = 0 To dvTarjetaUno.Count - 1
            '        fecha = CStr(CDate(dvTarjetaUno(intIndex)("Fecha")).ToShortDateString.Replace("/", ""))
            '        oZBAPI_ABONO_CIERREDIA.Fecha = Mid(fecha, 5, 4) & Mid(fecha, 3, 2) & Mid(fecha, 1, 2)
            '        oZBAPI_ABONO_CIERREDIA.Importe = CStr(dvTarjetaUno(intIndex)("Monto")).PadRight(16, " ")
            '        oZBAPI_ABONO_CIERREDIA.vBeln = CStr(dvTarjetaUno(intIndex)("FolioSAP")).PadLeft(10, "0")

            '        oProcesosSAPMgr = New ProcesoSAPManager(Me.oParent.ApplicationContext, Me.oParent.SAPApplicationConfig)
            '        strResult = oProcesosSAPMgr.WRITE_ZBAPI_ABONO_CIERREDIA(oZBAPI_ABONO_CIERREDIA, dt)

            '        If strResult = "Y" Then
            '            'actualizar el campo FI05SAP
            '            FacturaFI05ok(oZBAPI_ABONO_CIERREDIA.vBeln, oZBAPI_ABONO_CIERREDIA.ClaCobr)
            '        Else
            '            strMensaje += "FolioSAP: " & oZBAPI_ABONO_CIERREDIA.vBeln & vbCrLf
            '            For Each orow As DataRow In dt.Rows
            '                strMensaje += "Error: " & orow.Item("Message") & vbCrLf
            '            Next
            '            strMensaje += vbCrLf

            '            sm_GenerateFileTxtUp = "N"
            '        End If

            '        strResult = ""

            '    Next

            'End If

            ''----------------------------------------------------------------------------------------------------------------
            '' JNAVA (19.03.2015): Generamos el TXT de los Pagos DP CARD - EMPLEADOS
            ''----------------------------------------------------------------------------------------------------------------
            'strCliente = "99999".PadLeft(10, "0")
            'sm_GenerateFileTxtUp = GetCobranzaDPCard(dvTarjetaUno, strCliente, "E", FechaCierre, strNumRef, strNumRefBBV, sm_GenerateFileTxtUp, strMensaje)
            ''---------------------------------------------------------------------------------------------------------------------------------
            ''RGERMAIN 15.05.2015: Subimos los pagos con DPCard Puntos a SAP en las ventas de Empleados
            ''---------------------------------------------------------------------------------------------------------------------------------
            'strMensaje &= RegistraPagosDPCardPuntosSAP(strCliente, "DPPT", "E", dvTarjetaUno, strNumRef, sm_GenerateFileTxtUp)

            ''*********************************DIPS******************************
            'dvTarjetaUno.RowFilter = "CodFormasPago like 'EFEC' and CodTipoVenta='D'"
            ''Efectivo
            'For intIndex = 0 To dvTarjetaUno.Count - 1
            '    dt = New DataTable
            '    oZBAPI_ABONO_CIERREDIA = New ZBapiAbonoCierreDia

            '    oZBAPI_ABONO_CIERREDIA.Tienda = CStr(dvTarjetaUno(intIndex)("Tienda")).PadRight(20, " ")

            '    oZBAPI_ABONO_CIERREDIA.Cliente = CStr(dvTarjetaUno(intIndex)("ClienteID")).PadLeft(10, "0")

            '    oZBAPI_ABONO_CIERREDIA.Detalle = "X"

            '    oZBAPI_ABONO_CIERREDIA.Ref_Banco = strNumRef

            '    oZBAPI_ABONO_CIERREDIA.ClaCobr = "EFECTIVO".PadRight(9, " ")

            '    dsBanco = Me.BancoSel(oZBAPI_ABONO_CIERREDIA.Tienda, oZBAPI_ABONO_CIERREDIA.ClaCobr)
            '    If dsBanco.Tables(0).Rows.Count > 0 Then
            '        oZBAPI_ABONO_CIERREDIA.Banco = dsBanco.Tables(0).Rows(0).Item("Banco")
            '    Else
            '        oZBAPI_ABONO_CIERREDIA.Banco = ""
            '    End If

            '    oZBAPI_ABONO_CIERREDIA.i_FactDpPro = "X"

            '    oZBAPI_ABONO_CIERREDIA.i_Mode = "N"


            '    fecha = CStr(CDate(dvTarjetaUno(intIndex)("Fecha")).ToShortDateString.Replace("/", ""))
            '    oZBAPI_ABONO_CIERREDIA.Fecha = Mid(fecha, 5, 4) & Mid(fecha, 3, 2) & Mid(fecha, 1, 2)
            '    oZBAPI_ABONO_CIERREDIA.Importe = CStr(dvTarjetaUno(intIndex)("Monto")).PadRight(16, " ")
            '    oZBAPI_ABONO_CIERREDIA.vBeln = CStr(dvTarjetaUno(intIndex)("FolioSAP")).PadLeft(10, "0")

            '    oProcesosSAPMgr = New ProcesoSAPManager(Me.oParent.ApplicationContext, Me.oParent.SAPApplicationConfig)
            '    strResult = oProcesosSAPMgr.WRITE_ZBAPI_ABONO_CIERREDIA(oZBAPI_ABONO_CIERREDIA, dt)

            '    If strResult = "Y" Then
            '        'actualizar el campo FI05SAP
            '        FacturaFI05ok(oZBAPI_ABONO_CIERREDIA.vBeln, oZBAPI_ABONO_CIERREDIA.ClaCobr)
            '    Else
            '        strMensaje += "FolioSAP: " & oZBAPI_ABONO_CIERREDIA.vBeln & vbCrLf
            '        For Each orow As DataRow In dt.Rows
            '            strMensaje += "Error: " & orow.Item("Message") & vbCrLf
            '        Next
            '        strMensaje += vbCrLf

            '        sm_GenerateFileTxtUp = "N"
            '    End If

            '    strResult = ""

            '    'strEncabezado = "40" & "EFECTIVO".PadRight(9, " ") & CStr(dvTarjetaUno(intIndex)("Tienda")).PadRight(20, " ") & _
            '    '                  CStr(Format(dvTarjetaUno(intIndex)("Monto"), "##########.#0")).PadLeft(16, " ") & _
            '    '                  CStr("121000002").PadLeft(10, "0") & strNumRef
            '    'txtWriter.WriteLine(strEncabezado)
            '    'txtWriter.WriteLine("11" & CStr(dvTarjetaUno(intIndex)("FolioSAP")).PadLeft(10, "0") & CStr(dvTarjetaUno(intIndex)("Monto")).PadRight(16, " ") & "Venta Dia " & CDate(dvTarjetaUno(intIndex)("Fecha")).ToShortDateString.Replace("/", "") & CStr(dvTarjetaUno(intIndex)("ClienteID")).PadLeft(10, "0"))
            'Next

            ''Tarjeta 1
            'dvTarjetaUno.RowFilter = "CodBanco like 'T1' and CodTipoVenta='D'"

            'For intIndex = 0 To dvTarjetaUno.Count - 1

            '    If CStr(dvTarjetaUno(0)("NoAfiliacion")).Length > 6 Then
            '        strNumRefBBV = Mid(CStr(dvTarjetaUno(intIndex)("NoAfiliacion")), 2)
            '    Else
            '        strNumRefBBV = CStr(dvTarjetaUno(intIndex)("NoAfiliacion")).PadLeft(6, "0")
            '    End If

            '    dt = New DataTable

            '    oZBAPI_ABONO_CIERREDIA = New ZBapiAbonoCierreDia

            '    oZBAPI_ABONO_CIERREDIA.Tienda = CStr(dvTarjetaUno(intIndex)("Tienda")).PadRight(20, " ")

            '    oZBAPI_ABONO_CIERREDIA.Cliente = CStr(dvTarjetaUno(intIndex)("ClienteID")).PadLeft(10, "0")

            '    oZBAPI_ABONO_CIERREDIA.Detalle = "X"

            '    'oZBAPI_ABONO_CIERREDIA.Ref_Banco = strNumRefBBV & FechaCierre.ToShortDateString.Replace("/", "")
            '    oZBAPI_ABONO_CIERREDIA.Ref_Banco = strNumRefBBV & Format(FechaRefBancos, "ddMMyyyy")

            '    oZBAPI_ABONO_CIERREDIA.ClaCobr = "TARJETA 1".PadRight(9, " ")

            '    dsBanco = Me.BancoSel(oZBAPI_ABONO_CIERREDIA.Tienda, oZBAPI_ABONO_CIERREDIA.ClaCobr)
            '    If dsBanco.Tables(0).Rows.Count > 0 Then
            '        oZBAPI_ABONO_CIERREDIA.Banco = dsBanco.Tables(0).Rows(0).Item("Banco")
            '    Else
            '        oZBAPI_ABONO_CIERREDIA.Banco = ""
            '    End If

            '    oZBAPI_ABONO_CIERREDIA.i_FactDpPro = "X"

            '    oZBAPI_ABONO_CIERREDIA.i_Mode = "N"


            '    fecha = CStr(CDate(dvTarjetaUno(intIndex)("Fecha")).ToShortDateString.Replace("/", ""))
            '    oZBAPI_ABONO_CIERREDIA.Fecha = Mid(fecha, 5, 4) & Mid(fecha, 3, 2) & Mid(fecha, 1, 2)
            '    oZBAPI_ABONO_CIERREDIA.Importe = CStr(dvTarjetaUno(intIndex)("Monto")).PadRight(16, " ")
            '    oZBAPI_ABONO_CIERREDIA.vBeln = CStr(dvTarjetaUno(intIndex)("FolioSAP")).PadLeft(10, "0")

            '    oProcesosSAPMgr = New ProcesoSAPManager(Me.oParent.ApplicationContext, Me.oParent.SAPApplicationConfig)
            '    strResult = oProcesosSAPMgr.WRITE_ZBAPI_ABONO_CIERREDIA(oZBAPI_ABONO_CIERREDIA, dt)

            '    If strResult = "Y" Then
            '        'actualizar el campo FI05SAP
            '        FacturaFI05ok(oZBAPI_ABONO_CIERREDIA.vBeln, oZBAPI_ABONO_CIERREDIA.ClaCobr)
            '    Else
            '        strMensaje += "FolioSAP: " & oZBAPI_ABONO_CIERREDIA.vBeln & vbCrLf
            '        For Each orow As DataRow In dt.Rows
            '            strMensaje += "Error: " & orow.Item("Message") & vbCrLf
            '        Next
            '        strMensaje += vbCrLf

            '        sm_GenerateFileTxtUp = "N"
            '    End If

            '    strResult = ""

            '    'strEncabezado = "40" & "TARJETA 1".PadRight(9, " ") & CStr(dvTarjetaUno(intIndex)("Tienda")).PadRight(20, " ") & _
            '    '                  CStr(Format(dvTarjetaUno(intIndex)("Monto"), "##########.#0")).PadLeft(16, " ") & _
            '    '                  CStr("121000002").PadLeft(10, "0") & "    " & FechaCierre.ToShortDateString.Replace("/", "")
            '    'txtWriter.WriteLine(strEncabezado)
            '    'txtWriter.WriteLine("11" & CStr(dvTarjetaUno(intIndex)("FolioSAP")).PadLeft(10, "0") & CStr(dvTarjetaUno(intIndex)("Monto")).PadRight(16, " ") & "Venta Dia " & CDate(dvTarjetaUno(intIndex)("Fecha")).ToShortDateString.Replace("/", "") & CStr(dvTarjetaUno(intIndex)("ClienteID")).PadLeft(10, "0"))

            'Next

            ''Tarjeta 2
            'dvTarjetaUno.RowFilter = "CodBanco like 'T2' and CodTipoVenta='D'"

            'For intIndex = 0 To dvTarjetaUno.Count - 1

            '    strNumRefBBV = CStr(dvTarjetaUno(intIndex)("NoAfiliacion"))

            '    dt = New DataTable
            '    oZBAPI_ABONO_CIERREDIA = New ZBapiAbonoCierreDia

            '    oZBAPI_ABONO_CIERREDIA.Tienda = CStr(dvTarjetaUno(intIndex)("Tienda")).PadRight(20, " ")

            '    oZBAPI_ABONO_CIERREDIA.Cliente = CStr(dvTarjetaUno(intIndex)("ClienteID")).PadLeft(10, "0")

            '    oZBAPI_ABONO_CIERREDIA.Detalle = "X"

            '    'oZBAPI_ABONO_CIERREDIA.Ref_Banco = "    " & FechaCierre.ToShortDateString.Replace("/", "")
            '    oZBAPI_ABONO_CIERREDIA.Ref_Banco = strNumRefBBV & Format(FechaRefBancos, "ddMMyy")

            '    oZBAPI_ABONO_CIERREDIA.ClaCobr = "TARJETA 2".PadRight(9, " ")

            '    dsBanco = Me.BancoSel(oZBAPI_ABONO_CIERREDIA.Tienda, oZBAPI_ABONO_CIERREDIA.ClaCobr)
            '    If dsBanco.Tables(0).Rows.Count > 0 Then
            '        oZBAPI_ABONO_CIERREDIA.Banco = dsBanco.Tables(0).Rows(0).Item("Banco")
            '    Else
            '        oZBAPI_ABONO_CIERREDIA.Banco = ""
            '    End If

            '    oZBAPI_ABONO_CIERREDIA.i_FactDpPro = "X"

            '    oZBAPI_ABONO_CIERREDIA.i_Mode = "N"


            '    fecha = CStr(CDate(dvTarjetaUno(intIndex)("Fecha")).ToShortDateString.Replace("/", ""))
            '    oZBAPI_ABONO_CIERREDIA.Fecha = Mid(fecha, 5, 4) & Mid(fecha, 3, 2) & Mid(fecha, 1, 2)
            '    oZBAPI_ABONO_CIERREDIA.Importe = CStr(dvTarjetaUno(intIndex)("Monto")).PadRight(16, " ")
            '    oZBAPI_ABONO_CIERREDIA.vBeln = CStr(dvTarjetaUno(intIndex)("FolioSAP")).PadLeft(10, "0")

            '    oProcesosSAPMgr = New ProcesoSAPManager(Me.oParent.ApplicationContext, Me.oParent.SAPApplicationConfig)
            '    strResult = oProcesosSAPMgr.WRITE_ZBAPI_ABONO_CIERREDIA(oZBAPI_ABONO_CIERREDIA, dt)

            '    If strResult = "Y" Then
            '        'actualizar el campo FI05SAP
            '        FacturaFI05ok(oZBAPI_ABONO_CIERREDIA.vBeln, oZBAPI_ABONO_CIERREDIA.ClaCobr)
            '    Else
            '        strMensaje += "FolioSAP: " & oZBAPI_ABONO_CIERREDIA.vBeln & vbCrLf
            '        For Each orow As DataRow In dt.Rows
            '            strMensaje += "Error: " & orow.Item("Message") & vbCrLf
            '        Next
            '        strMensaje += vbCrLf

            '        sm_GenerateFileTxtUp = "N"
            '    End If

            '    strResult = ""

            '    'strEncabezado = "40" & "TARJETA 2".PadRight(9, " ") & CStr(dvTarjetaUno(intIndex)("Tienda")).PadRight(20, " ") & _
            '    '                  CStr(Format(dvTarjetaUno(intIndex)("Monto"), "##########.#0")).PadLeft(16, " ") & _
            '    '                  CStr("121000002").PadRight(10, "0") & "    " & FechaCierre.ToShortDateString.Replace("/", "")
            '    'txtWriter.WriteLine(strEncabezado)
            '    'txtWriter.WriteLine("11" & CStr(dvTarjetaUno(intIndex)("FolioSAP")).PadLeft(10, "0") & CStr(dvTarjetaUno(intIndex)("Monto")).PadRight(16, " ") & "Venta Dia " & CDate(dvTarjetaUno(intIndex)("Fecha")).ToShortDateString.Replace("/", "") & CStr(dvTarjetaUno(intIndex)("ClienteID")).PadLeft(10, "0"))
            'Next

            ''Tarjeta 3
            'dvTarjetaUno.RowFilter = "CodBanco like 'T3' and CodTipoVenta='D'"

            'For intIndex = 0 To dvTarjetaUno.Count - 1

            '    strNumRefBBV = CStr(dvTarjetaUno(intIndex)("NoAfiliacion"))

            '    dt = New DataTable
            '    oZBAPI_ABONO_CIERREDIA = New ZBapiAbonoCierreDia

            '    oZBAPI_ABONO_CIERREDIA.Tienda = CStr(dvTarjetaUno(intIndex)("Tienda")).PadRight(20, " ")

            '    oZBAPI_ABONO_CIERREDIA.Cliente = CStr(dvTarjetaUno(intIndex)("ClienteID")).PadLeft(10, "0")

            '    oZBAPI_ABONO_CIERREDIA.Detalle = "X"

            '    'oZBAPI_ABONO_CIERREDIA.Ref_Banco = "    " & FechaCierre.ToShortDateString.Replace("/", "")
            '    oZBAPI_ABONO_CIERREDIA.Ref_Banco = strNumRefBBV & Format(FechaRefBancos, "ddMMyy")

            '    oZBAPI_ABONO_CIERREDIA.ClaCobr = "TARJETA 3".PadRight(9, " ")

            '    dsBanco = Me.BancoSel(oZBAPI_ABONO_CIERREDIA.Tienda, oZBAPI_ABONO_CIERREDIA.ClaCobr)
            '    If dsBanco.Tables(0).Rows.Count > 0 Then
            '        oZBAPI_ABONO_CIERREDIA.Banco = dsBanco.Tables(0).Rows(0).Item("Banco")
            '    Else
            '        oZBAPI_ABONO_CIERREDIA.Banco = ""
            '    End If

            '    oZBAPI_ABONO_CIERREDIA.i_FactDpPro = "X"

            '    oZBAPI_ABONO_CIERREDIA.i_Mode = "N"


            '    fecha = CStr(CDate(dvTarjetaUno(intIndex)("Fecha")).ToShortDateString.Replace("/", ""))
            '    oZBAPI_ABONO_CIERREDIA.Fecha = Mid(fecha, 5, 4) & Mid(fecha, 3, 2) & Mid(fecha, 1, 2)
            '    oZBAPI_ABONO_CIERREDIA.Importe = CStr(dvTarjetaUno(intIndex)("Monto")).PadRight(16, " ")
            '    oZBAPI_ABONO_CIERREDIA.vBeln = CStr(dvTarjetaUno(intIndex)("FolioSAP")).PadLeft(10, "0")

            '    oProcesosSAPMgr = New ProcesoSAPManager(Me.oParent.ApplicationContext, Me.oParent.SAPApplicationConfig)
            '    strResult = oProcesosSAPMgr.WRITE_ZBAPI_ABONO_CIERREDIA(oZBAPI_ABONO_CIERREDIA, dt)

            '    If strResult = "Y" Then
            '        'actualizar el campo FI05SAP
            '        FacturaFI05ok(oZBAPI_ABONO_CIERREDIA.vBeln, oZBAPI_ABONO_CIERREDIA.ClaCobr)
            '    Else
            '        strMensaje += "FolioSAP: " & oZBAPI_ABONO_CIERREDIA.vBeln & vbCrLf
            '        For Each orow As DataRow In dt.Rows
            '            strMensaje += "Error: " & orow.Item("Message") & vbCrLf
            '        Next
            '        strMensaje += vbCrLf

            '        sm_GenerateFileTxtUp = "N"
            '    End If

            '    strResult = ""

            '    'strEncabezado = "40" & "TARJETA 3".PadRight(9, " ") & CStr(dvTarjetaUno(intIndex)("Tienda")).PadRight(20, " ") & _
            '    '                  CStr(Format(dvTarjetaUno(intIndex)("Monto"), "##########.#0")).PadLeft(16, " ") & _
            '    '                    CStr("121000002").PadRight(10, "0") & "    " & FechaCierre.ToShortDateString.Replace("/", "")
            '    'txtWriter.WriteLine(strEncabezado)
            '    'txtWriter.WriteLine("11" & CStr(dvTarjetaUno(intIndex)("FolioSAP")).PadLeft(10, "0") & CStr(dvTarjetaUno(intIndex)("Monto")).PadRight(16, " ") & "Venta Dia " & CDate(dvTarjetaUno(intIndex)("Fecha")).ToShortDateString.Replace("/", "") & CStr(dvTarjetaUno(intIndex)("ClienteID")).PadLeft(10, "0"))
            'Next

            ''----------------------------------------------------------------------------------------------------------------
            '' JNAVA (19.03.2015): Generamos el TXT de los Pagos DP CARD - DIPS
            ''----------------------------------------------------------------------------------------------------------------
            'strCliente = String.Empty
            'sm_GenerateFileTxtUp = GetCobranzaDPCard(dvTarjetaUno, strCliente, "D", FechaCierre, strNumRef, strNumRefBBV, sm_GenerateFileTxtUp, strMensaje)
            ''---------------------------------------------------------------------------------------------------------------------------------
            ''RGERMAIN 15.05.2015: Subimos los pagos con DPCard Puntos a SAP en las ventas de Empleados
            ''---------------------------------------------------------------------------------------------------------------------------------
            'strMensaje &= RegistraPagosDPCardPuntosSAP(strCliente, "DPPT", "E", dvTarjetaUno, strNumRef, sm_GenerateFileTxtUp)

            ''*********************************DPVALE******************************
            ''Efectivo
            'dvTarjetaUno.RowFilter = "CodFormasPago like 'EFEC' and CodTipoVenta='V'"

            'For intIndex = 0 To dvTarjetaUno.Count - 1
            '    dt = New DataTable
            '    oZBAPI_ABONO_CIERREDIA = New ZBapiAbonoCierreDia

            '    oZBAPI_ABONO_CIERREDIA.Tienda = CStr(dvTarjetaUno(intIndex)("Tienda")).PadRight(20, " ")

            '    If Not Me.oParent.SAPApplicationConfig.DPValeSAP Then
            '        'oZBAPI_ABONO_CIERREDIA.Cliente = CStr(GetCodigoSAPAsoc(GetDpValeIDDP(CInt(dvTarjetaUno(intIndex)("FolioFactura"))))).PadRight(10, " ")
            '        oZBAPI_ABONO_CIERREDIA.Cliente = CStr(GetCodigoSAPAsoc(GetDpValeIDDP(CInt(dvTarjetaUno(intIndex)("FacturaID"))))).PadRight(10, " ")
            '    Else
            '        'Dim strDpValeIDDP As String = CStr(GetDpValeIDDP(CInt(dvTarjetaUno(intIndex)("FolioFactura"))))
            '        Dim strDpValeIDDP As String = CStr(GetDpValeIDDP(CInt(dvTarjetaUno(intIndex)("FacturaID"))))
            '        Me.oDPVale.INUMVA = strDpValeIDDP
            '        Me.oDPVale.I_RUTA = "X"
            '        oDPVale = oSAPMgr.ZBAPI_VALIDA_DPVALE(oDPVale)

            '        oZBAPI_ABONO_CIERREDIA.Cliente = CStr(oDPVale.InfoDPVALE.Rows(0).Item("KUNNR")).PadRight(10, " ")
            '    End If

            '    oZBAPI_ABONO_CIERREDIA.Detalle = "X"

            '    oZBAPI_ABONO_CIERREDIA.Ref_Banco = strNumRef

            '    oZBAPI_ABONO_CIERREDIA.ClaCobr = "EFECTIVO".PadRight(9, " ")

            '    dsBanco = Me.BancoSel(oZBAPI_ABONO_CIERREDIA.Tienda, oZBAPI_ABONO_CIERREDIA.ClaCobr)
            '    If dsBanco.Tables(0).Rows.Count > 0 Then
            '        oZBAPI_ABONO_CIERREDIA.Banco = dsBanco.Tables(0).Rows(0).Item("Banco")
            '    Else
            '        oZBAPI_ABONO_CIERREDIA.Banco = ""
            '    End If

            '    oZBAPI_ABONO_CIERREDIA.i_FactDpPro = "X"

            '    oZBAPI_ABONO_CIERREDIA.i_Mode = "N"


            '    fecha = CStr(CDate(dvTarjetaUno(intIndex)("Fecha")).ToShortDateString.Replace("/", ""))
            '    oZBAPI_ABONO_CIERREDIA.Fecha = Mid(fecha, 5, 4) & Mid(fecha, 3, 2) & Mid(fecha, 1, 2)
            '    oZBAPI_ABONO_CIERREDIA.Importe = CStr(dvTarjetaUno(intIndex)("Monto")).PadRight(16, " ")
            '    oZBAPI_ABONO_CIERREDIA.vBeln = CStr(dvTarjetaUno(intIndex)("FolioSAP")).PadLeft(10, "0")

            '    oProcesosSAPMgr = New ProcesoSAPManager(Me.oParent.ApplicationContext, Me.oParent.SAPApplicationConfig)
            '    strResult = oProcesosSAPMgr.WRITE_ZBAPI_ABONO_CIERREDIA(oZBAPI_ABONO_CIERREDIA, dt)

            '    If strResult = "Y" Then
            '        'actualizar el campo FI05SAP
            '        FacturaFI05ok(oZBAPI_ABONO_CIERREDIA.vBeln, oZBAPI_ABONO_CIERREDIA.ClaCobr)
            '    Else
            '        strMensaje += "FolioSAP: " & oZBAPI_ABONO_CIERREDIA.vBeln & vbCrLf
            '        For Each orow As DataRow In dt.Rows
            '            strMensaje += "Error: " & orow.Item("Message") & vbCrLf
            '        Next
            '        strMensaje += vbCrLf

            '        sm_GenerateFileTxtUp = "N"
            '    End If

            '    strResult = ""


            '    'strEncabezado = "40" & "EFECTIVO".PadRight(9, " ") & CStr(dvTarjetaUno(intIndex)("Tienda")).PadRight(20, " ") & _
            '    '                  CStr(Format(dvTarjetaUno(intIndex)("Monto"), "##########.#0")).PadLeft(16, " ") & _
            '    '                  CStr("122000001").PadLeft(10, "0") & strNumRef
            '    'txtWriter.WriteLine(strEncabezado)

            '    'If Not Me.oParent.SAPApplicationConfig.DPValeSAP Then
            '    '    txtWriter.WriteLine("11" & CStr(dvTarjetaUno(intIndex)("FolioSAP")).PadLeft(10, "0") & CStr(dvTarjetaUno(intIndex)("Monto")).PadRight(16, " ") & "Venta Dia " & CDate(dvTarjetaUno(intIndex)("Fecha")).ToShortDateString.Replace("/", "") & CStr(GetCodigoSAPAsoc(GetDpValeIDDP(CInt(dvTarjetaUno(intIndex)("FolioFactura"))))).PadRight(10, " "))
            '    'Else

            '    '    Dim strDpValeIDDP As String = CStr(GetDpValeIDDP(CInt(dvTarjetaUno(intIndex)("FolioFactura"))))

            '    '    Me.oDPVale.INUMVA = strDpValeIDDP
            '    '    Me.oDPVale.I_RUTA = "X"


            '    '    oDPVale = oSAPMgr.ZBAPI_VALIDA_DPVALE(oDPVale)

            '    '    txtWriter.WriteLine("11" & CStr(dvTarjetaUno(intIndex)("FolioSAP")).PadLeft(10, "0") & CStr(dvTarjetaUno(intIndex)("Monto")).PadRight(16, " ") & "Venta Dia " & CDate(dvTarjetaUno(intIndex)("Fecha")).ToShortDateString.Replace("/", "") & CStr(oDPVale.InfoDPVALE.Rows(0).Item("KUNNR")).PadRight(10, " "))
            '    'End If

            'Next



            ''Tarjeta 1
            'dvTarjetaUno.RowFilter = "CodBanco like 'T1' and CodTipoVenta='V'"

            'For intIndex = 0 To dvTarjetaUno.Count - 1
            '    dt = New DataTable

            '    oZBAPI_ABONO_CIERREDIA = New ZBapiAbonoCierreDia

            '    oZBAPI_ABONO_CIERREDIA.Tienda = CStr(dvTarjetaUno(intIndex)("Tienda")).PadRight(20, " ")

            '    If Not Me.oParent.SAPApplicationConfig.DPValeSAP Then
            '        'oZBAPI_ABONO_CIERREDIA.Cliente = CStr(GetCodigoSAPAsoc(GetDpValeIDDP(CInt(dvTarjetaUno(intIndex)("FolioFactura"))))).PadRight(10, " ")
            '        oZBAPI_ABONO_CIERREDIA.Cliente = CStr(GetCodigoSAPAsoc(GetDpValeIDDP(CInt(dvTarjetaUno(intIndex)("FacturaID"))))).PadRight(10, " ")
            '    Else
            '        'Dim strDpValeIDDP As String = CStr(GetDpValeIDDP(CInt(dvTarjetaUno(intIndex)("FolioFactura"))))
            '        Dim strDpValeIDDP As String = CStr(GetDpValeIDDP(CInt(dvTarjetaUno(intIndex)("FacturaID"))))
            '        Me.oDPVale.INUMVA = strDpValeIDDP
            '        Me.oDPVale.I_RUTA = "X"
            '        oDPVale = oSAPMgr.ZBAPI_VALIDA_DPVALE(oDPVale)

            '        oZBAPI_ABONO_CIERREDIA.Cliente = CStr(oDPVale.InfoDPVALE.Rows(0).Item("KUNNR")).PadRight(10, " ")
            '    End If

            '    oZBAPI_ABONO_CIERREDIA.Detalle = "X"

            '    'oZBAPI_ABONO_CIERREDIA.Ref_Banco = strNumRefBBV & FechaCierre.ToShortDateString.Replace("/", "")
            '    If CStr(dvTarjetaUno(0)("NoAfiliacion")).Length > 6 Then
            '        strNumRefBBV = Mid(CStr(dvTarjetaUno(intIndex)("NoAfiliacion")), 2)
            '    Else
            '        strNumRefBBV = CStr(dvTarjetaUno(intIndex)("NoAfiliacion")).PadLeft(6, "0")
            '    End If
            '    oZBAPI_ABONO_CIERREDIA.Ref_Banco = strNumRefBBV & Format(FechaRefBancos, "ddMMyyyy")

            '    oZBAPI_ABONO_CIERREDIA.ClaCobr = "TARJETA 1".PadRight(9, " ")

            '    dsBanco = Me.BancoSel(oZBAPI_ABONO_CIERREDIA.Tienda, oZBAPI_ABONO_CIERREDIA.ClaCobr)
            '    If dsBanco.Tables(0).Rows.Count > 0 Then
            '        oZBAPI_ABONO_CIERREDIA.Banco = dsBanco.Tables(0).Rows(0).Item("Banco")
            '    Else
            '        oZBAPI_ABONO_CIERREDIA.Banco = ""
            '    End If

            '    oZBAPI_ABONO_CIERREDIA.i_FactDpPro = "X"

            '    oZBAPI_ABONO_CIERREDIA.i_Mode = "N"


            '    fecha = CStr(CDate(dvTarjetaUno(intIndex)("Fecha")).ToShortDateString.Replace("/", ""))
            '    oZBAPI_ABONO_CIERREDIA.Fecha = Mid(fecha, 5, 4) & Mid(fecha, 3, 2) & Mid(fecha, 1, 2)
            '    oZBAPI_ABONO_CIERREDIA.Importe = CStr(dvTarjetaUno(intIndex)("Monto")).PadRight(16, " ")
            '    oZBAPI_ABONO_CIERREDIA.vBeln = CStr(dvTarjetaUno(intIndex)("FolioSAP")).PadLeft(10, "0")

            '    oProcesosSAPMgr = New ProcesoSAPManager(Me.oParent.ApplicationContext, Me.oParent.SAPApplicationConfig)
            '    strResult = oProcesosSAPMgr.WRITE_ZBAPI_ABONO_CIERREDIA(oZBAPI_ABONO_CIERREDIA, dt)

            '    If strResult = "Y" Then
            '        'actualizar el campo FI05SAP
            '        FacturaFI05ok(oZBAPI_ABONO_CIERREDIA.vBeln, oZBAPI_ABONO_CIERREDIA.ClaCobr)
            '    Else
            '        strMensaje += "FolioSAP: " & oZBAPI_ABONO_CIERREDIA.vBeln & vbCrLf
            '        For Each orow As DataRow In dt.Rows
            '            strMensaje += "Error: " & orow.Item("Message") & vbCrLf
            '        Next
            '        strMensaje += vbCrLf

            '        sm_GenerateFileTxtUp = "N"
            '    End If

            '    strResult = ""



            '    'strEncabezado = "40" & "TARJETA 1".PadRight(9, " ") & CStr(dvTarjetaUno(intIndex)("Tienda")).PadRight(20, " ") & _
            '    '                  CStr(Format(dvTarjetaUno(intIndex)("Monto"), "##########.#0")).PadLeft(16, " ") & _
            '    '                  CStr("122000001").PadLeft(10, "0") & "    " & FechaCierre.ToShortDateString.Replace("/", "")
            '    'txtWriter.WriteLine(strEncabezado)

            '    'If Not Me.oParent.SAPApplicationConfig.DPValeSAP Then
            '    '    txtWriter.WriteLine("11" & CStr(dvTarjetaUno(intIndex)("FolioSAP")).PadLeft(10, "0") & CStr(dvTarjetaUno(intIndex)("Monto")).PadRight(16, " ") & "Venta Dia " & CDate(dvTarjetaUno(intIndex)("Fecha")).ToShortDateString.Replace("/", "") & CStr(GetCodigoSAPAsoc(GetDpValeIDDP(CInt(dvTarjetaUno(intIndex)("FolioFactura"))))).PadRight(10, " "))
            '    'Else

            '    '    Dim strDpValeIDDP As String = CStr(GetDpValeIDDP(CInt(dvTarjetaUno(intIndex)("FolioFactura"))))

            '    '    Me.oDPVale.INUMVA = strDpValeIDDP
            '    '    Me.oDPVale.I_RUTA = "X"

            '    '    oDPVale = oSAPMgr.ZBAPI_VALIDA_DPVALE(oDPVale)

            '    '    txtWriter.WriteLine("11" & CStr(dvTarjetaUno(intIndex)("FolioSAP")).PadLeft(10, "0") & CStr(dvTarjetaUno(intIndex)("Monto")).PadRight(16, " ") & "Venta Dia " & CDate(dvTarjetaUno(intIndex)("Fecha")).ToShortDateString.Replace("/", "") & CStr(oDPVale.InfoDPVALE.Rows(0).Item("KUNNR")).PadRight(10, " "))
            '    'End If

            'Next


            ''Tarjeta 2
            'dvTarjetaUno.RowFilter = "CodBanco like 'T2' and CodTipoVenta='V'"

            'For intIndex = 0 To dvTarjetaUno.Count - 1

            '    strNumRefBBV = CStr(dvTarjetaUno(intIndex)("NoAfiliacion"))

            '    dt = New DataTable

            '    oZBAPI_ABONO_CIERREDIA = New ZBapiAbonoCierreDia

            '    oZBAPI_ABONO_CIERREDIA.Ref_Banco = strNumRefBBV & Format(FechaRefBancos, "ddMMyy")

            '    oZBAPI_ABONO_CIERREDIA.Tienda = CStr(dvTarjetaUno(intIndex)("Tienda")).PadRight(20, " ")

            '    If Not Me.oParent.SAPApplicationConfig.DPValeSAP Then
            '        'oZBAPI_ABONO_CIERREDIA.Cliente = CStr(GetCodigoSAPAsoc(GetDpValeIDDP(CInt(dvTarjetaUno(intIndex)("FolioFactura"))))).PadRight(10, " ")
            '        oZBAPI_ABONO_CIERREDIA.Cliente = CStr(GetCodigoSAPAsoc(GetDpValeIDDP(CInt(dvTarjetaUno(intIndex)("FacturaID"))))).PadRight(10, " ")
            '    Else
            '        'Dim strDpValeIDDP As String = CStr(GetDpValeIDDP(CInt(dvTarjetaUno(intIndex)("FolioFactura"))))
            '        Dim strDpValeIDDP As String = CStr(GetDpValeIDDP(CInt(dvTarjetaUno(intIndex)("FacturaID"))))
            '        Me.oDPVale.INUMVA = strDpValeIDDP
            '        Me.oDPVale.I_RUTA = "X"
            '        oDPVale = oSAPMgr.ZBAPI_VALIDA_DPVALE(oDPVale)

            '        oZBAPI_ABONO_CIERREDIA.Cliente = CStr(oDPVale.InfoDPVALE.Rows(0).Item("KUNNR")).PadRight(10, " ")
            '    End If

            '    oZBAPI_ABONO_CIERREDIA.Detalle = "X"

            '    'oZBAPI_ABONO_CIERREDIA.Ref_Banco = "    " & FechaCierre.ToShortDateString.Replace("/", "")

            '    oZBAPI_ABONO_CIERREDIA.ClaCobr = "TARJETA 2".PadRight(9, " ")

            '    dsBanco = Me.BancoSel(oZBAPI_ABONO_CIERREDIA.Tienda, oZBAPI_ABONO_CIERREDIA.ClaCobr)
            '    If dsBanco.Tables(0).Rows.Count > 0 Then
            '        oZBAPI_ABONO_CIERREDIA.Banco = dsBanco.Tables(0).Rows(0).Item("Banco")
            '    Else
            '        oZBAPI_ABONO_CIERREDIA.Banco = ""
            '    End If

            '    oZBAPI_ABONO_CIERREDIA.i_FactDpPro = "X"

            '    oZBAPI_ABONO_CIERREDIA.i_Mode = "N"


            '    fecha = CStr(CDate(dvTarjetaUno(intIndex)("Fecha")).ToShortDateString.Replace("/", ""))
            '    oZBAPI_ABONO_CIERREDIA.Fecha = Mid(fecha, 5, 4) & Mid(fecha, 3, 2) & Mid(fecha, 1, 2)
            '    oZBAPI_ABONO_CIERREDIA.Importe = CStr(dvTarjetaUno(intIndex)("Monto")).PadRight(16, " ")
            '    oZBAPI_ABONO_CIERREDIA.vBeln = CStr(dvTarjetaUno(intIndex)("FolioSAP")).PadLeft(10, "0")

            '    oProcesosSAPMgr = New ProcesoSAPManager(Me.oParent.ApplicationContext, Me.oParent.SAPApplicationConfig)
            '    strResult = oProcesosSAPMgr.WRITE_ZBAPI_ABONO_CIERREDIA(oZBAPI_ABONO_CIERREDIA, dt)

            '    If strResult = "Y" Then
            '        'actualizar el campo FI05SAP
            '        FacturaFI05ok(oZBAPI_ABONO_CIERREDIA.vBeln, oZBAPI_ABONO_CIERREDIA.ClaCobr)
            '    Else
            '        strMensaje += "FolioSAP: " & oZBAPI_ABONO_CIERREDIA.vBeln & vbCrLf
            '        For Each orow As DataRow In dt.Rows
            '            strMensaje += "Error: " & orow.Item("Message") & vbCrLf
            '        Next
            '        strMensaje += vbCrLf

            '        sm_GenerateFileTxtUp = "N"
            '    End If

            '    strResult = ""


            '    'strEncabezado = "40" & "TARJETA 2".PadRight(9, " ") & CStr(dvTarjetaUno(intIndex)("Tienda")).PadRight(20, " ") & _
            '    '                  CStr(Format(dvTarjetaUno(intIndex)("Monto"), "##########.#0")).PadLeft(16, " ") & _
            '    '                CStr("122000001").PadRight(10, "0") & "    " & FechaCierre.ToShortDateString.Replace("/", "")
            '    'txtWriter.WriteLine(strEncabezado)

            '    'If Not Me.oParent.SAPApplicationConfig.DPValeSAP Then
            '    '    txtWriter.WriteLine("11" & CStr(dvTarjetaUno(intIndex)("FolioSAP")).PadLeft(10, "0") & CStr(dvTarjetaUno(intIndex)("Monto")).PadRight(16, " ") & "Venta Dia " & CDate(dvTarjetaUno(intIndex)("Fecha")).ToShortDateString.Replace("/", "") & CStr(GetCodigoSAPAsoc(GetDpValeIDDP(CInt(dvTarjetaUno(intIndex)("FolioFactura"))))).PadRight(10, " "))
            '    'Else

            '    '    Dim strDpValeIDDP As String = CStr(GetDpValeIDDP(CInt(dvTarjetaUno(intIndex)("FolioFactura"))))

            '    '    Me.oDPVale.INUMVA = strDpValeIDDP
            '    '    Me.oDPVale.I_RUTA = "X"

            '    '    oDPVale = oSAPMgr.ZBAPI_VALIDA_DPVALE(oDPVale)

            '    '    txtWriter.WriteLine("11" & CStr(dvTarjetaUno(intIndex)("FolioSAP")).PadLeft(10, "0") & CStr(dvTarjetaUno(intIndex)("Monto")).PadRight(16, " ") & "Venta Dia " & CDate(dvTarjetaUno(intIndex)("Fecha")).ToShortDateString.Replace("/", "") & CStr(oDPVale.InfoDPVALE.Rows(0).Item("KUNNR")).PadRight(10, " "))
            '    'End If

            'Next

            ''Tarjeta 3
            'dvTarjetaUno.RowFilter = "CodBanco like 'T3' and CodTipoVenta='V'"

            'For intIndex = 0 To dvTarjetaUno.Count - 1
            '    strNumRefBBV = CStr(dvTarjetaUno(intIndex)("NoAfiliacion"))

            '    dt = New DataTable

            '    oZBAPI_ABONO_CIERREDIA = New ZBapiAbonoCierreDia

            '    oZBAPI_ABONO_CIERREDIA.Tienda = CStr(dvTarjetaUno(intIndex)("Tienda")).PadRight(20, " ")

            '    If Not Me.oParent.SAPApplicationConfig.DPValeSAP Then
            '        'oZBAPI_ABONO_CIERREDIA.Cliente = CStr(GetCodigoSAPAsoc(GetDpValeIDDP(CInt(dvTarjetaUno(intIndex)("FolioFactura"))))).PadRight(10, " ")
            '        oZBAPI_ABONO_CIERREDIA.Cliente = CStr(GetCodigoSAPAsoc(GetDpValeIDDP(CInt(dvTarjetaUno(intIndex)("FacturaID"))))).PadRight(10, " ")
            '    Else
            '        'Dim strDpValeIDDP As String = CStr(GetDpValeIDDP(CInt(dvTarjetaUno(intIndex)("FolioFactura"))))
            '        Dim strDpValeIDDP As String = CStr(GetDpValeIDDP(CInt(dvTarjetaUno(intIndex)("FacturaID"))))
            '        Me.oDPVale.INUMVA = strDpValeIDDP
            '        Me.oDPVale.I_RUTA = "X"
            '        oDPVale = oSAPMgr.ZBAPI_VALIDA_DPVALE(oDPVale)

            '        oZBAPI_ABONO_CIERREDIA.Cliente = CStr(oDPVale.InfoDPVALE.Rows(0).Item("KUNNR")).PadRight(10, " ")
            '    End If

            '    oZBAPI_ABONO_CIERREDIA.Detalle = "X"

            '    oZBAPI_ABONO_CIERREDIA.Ref_Banco = strNumRefBBV & Format(FechaRefBancos, "ddMMyy")
            '    'oZBAPI_ABONO_CIERREDIA.Ref_Banco = "    " & FechaCierre.ToShortDateString.Replace("/", "")

            '    oZBAPI_ABONO_CIERREDIA.ClaCobr = "TARJETA 3".PadRight(9, " ")

            '    dsBanco = Me.BancoSel(oZBAPI_ABONO_CIERREDIA.Tienda, oZBAPI_ABONO_CIERREDIA.ClaCobr)
            '    If dsBanco.Tables(0).Rows.Count > 0 Then
            '        oZBAPI_ABONO_CIERREDIA.Banco = dsBanco.Tables(0).Rows(0).Item("Banco")
            '    Else
            '        oZBAPI_ABONO_CIERREDIA.Banco = ""
            '    End If

            '    oZBAPI_ABONO_CIERREDIA.i_FactDpPro = "X"

            '    oZBAPI_ABONO_CIERREDIA.i_Mode = "N"


            '    fecha = CStr(CDate(dvTarjetaUno(intIndex)("Fecha")).ToShortDateString.Replace("/", ""))
            '    oZBAPI_ABONO_CIERREDIA.Fecha = Mid(fecha, 5, 4) & Mid(fecha, 3, 2) & Mid(fecha, 1, 2)
            '    oZBAPI_ABONO_CIERREDIA.Importe = CStr(dvTarjetaUno(intIndex)("Monto")).PadRight(16, " ")
            '    oZBAPI_ABONO_CIERREDIA.vBeln = CStr(dvTarjetaUno(intIndex)("FolioSAP")).PadLeft(10, "0")

            '    oProcesosSAPMgr = New ProcesoSAPManager(Me.oParent.ApplicationContext, Me.oParent.SAPApplicationConfig)
            '    strResult = oProcesosSAPMgr.WRITE_ZBAPI_ABONO_CIERREDIA(oZBAPI_ABONO_CIERREDIA, dt)

            '    If strResult = "Y" Then
            '        'actualizar el campo FI05SAP
            '        FacturaFI05ok(oZBAPI_ABONO_CIERREDIA.vBeln, oZBAPI_ABONO_CIERREDIA.ClaCobr)
            '    Else
            '        strMensaje += "FolioSAP: " & oZBAPI_ABONO_CIERREDIA.vBeln & vbCrLf
            '        For Each orow As DataRow In dt.Rows
            '            strMensaje += "Error: " & orow.Item("Message") & vbCrLf
            '        Next
            '        strMensaje += vbCrLf

            '        sm_GenerateFileTxtUp = "N"
            '    End If

            '    strResult = ""



            '    'strEncabezado = "40" & "TARJETA 3".PadRight(9, " ") & CStr(dvTarjetaUno(intIndex)("Tienda")).PadRight(20, " ") & _
            '    '                  CStr(Format(dvTarjetaUno(intIndex)("Monto"), "##########.#0")).PadLeft(16, " ") & _
            '    '                CStr("122000001").PadRight(10, "0") & "    " & FechaCierre.ToShortDateString.Replace("/", "")
            '    'txtWriter.WriteLine(strEncabezado)

            '    'If Not Me.oParent.SAPApplicationConfig.DPValeSAP Then
            '    '    txtWriter.WriteLine("11" & CStr(dvTarjetaUno(intIndex)("FolioSAP")).PadLeft(10, "0") & CStr(dvTarjetaUno(intIndex)("Monto")).PadRight(16, " ") & "Venta Dia " & CDate(dvTarjetaUno(intIndex)("Fecha")).ToShortDateString.Replace("/", "") & CStr(GetCodigoSAPAsoc(GetDpValeIDDP(CInt(dvTarjetaUno(intIndex)("FolioFactura"))))).PadRight(10, " "))
            '    'Else

            '    '    Dim strDpValeIDDP As String = CStr(GetDpValeIDDP(CInt(dvTarjetaUno(intIndex)("FolioFactura"))))

            '    '    Me.oDPVale.INUMVA = strDpValeIDDP
            '    '    Me.oDPVale.I_RUTA = "X"

            '    '    oDPVale = oSAPMgr.ZBAPI_VALIDA_DPVALE(oDPVale)

            '    '    txtWriter.WriteLine("11" & CStr(dvTarjetaUno(intIndex)("FolioSAP")).PadLeft(10, "0") & CStr(dvTarjetaUno(intIndex)("Monto")).PadRight(16, " ") & "Venta Dia " & CDate(dvTarjetaUno(intIndex)("Fecha")).ToShortDateString.Replace("/", "") & CStr(oDPVale.InfoDPVALE.Rows(0).Item("KUNNR")).PadRight(10, " "))
            '    'End If

            'Next

            ''----------------------------------------------------------------------------------------------------------------
            '' JNAVA (19.03.2015): Generamos el TXT de los Pagos DP CARD - DPVALE
            ''----------------------------------------------------------------------------------------------------------------
            'strCliente = String.Empty
            'sm_GenerateFileTxtUp = GetCobranzaDPCard(dvTarjetaUno, strCliente, "V", FechaCierre, strNumRef, strNumRefBBV, sm_GenerateFileTxtUp, strMensaje)
            ''---------------------------------------------------------------------------------------------------------------------------------
            ''RGERMAIN 15.05.2015: Subimos los pagos con DPCard Puntos a SAP en las ventas de DPVale
            ''---------------------------------------------------------------------------------------------------------------------------------
            'strMensaje &= RegistraPagosDPCardPuntosSAP(strCliente, "DPPT", "V", dvTarjetaUno, strNumRef, sm_GenerateFileTxtUp)

            ''*********************************FONACOT******************************
            ''Efectivo
            'dvTarjetaUno.RowFilter = "CodFormasPago like 'EFEC' and CodTipoVenta='F'"

            'For intIndex = 0 To dvTarjetaUno.Count - 1
            '    dt = New DataTable
            '    oZBAPI_ABONO_CIERREDIA = New ZBapiAbonoCierreDia

            '    oZBAPI_ABONO_CIERREDIA.Tienda = CStr(dvTarjetaUno(intIndex)("Tienda")).PadRight(20, " ")

            '    oZBAPI_ABONO_CIERREDIA.Cliente = CStr("260000000").PadLeft(10, "0")

            '    oZBAPI_ABONO_CIERREDIA.Detalle = "X"

            '    oZBAPI_ABONO_CIERREDIA.Ref_Banco = strNumRef

            '    oZBAPI_ABONO_CIERREDIA.ClaCobr = "EFECTIVO".PadRight(9, " ")

            '    dsBanco = Me.BancoSel(oZBAPI_ABONO_CIERREDIA.Tienda, oZBAPI_ABONO_CIERREDIA.ClaCobr)
            '    If dsBanco.Tables(0).Rows.Count > 0 Then
            '        oZBAPI_ABONO_CIERREDIA.Banco = dsBanco.Tables(0).Rows(0).Item("Banco")
            '    Else
            '        oZBAPI_ABONO_CIERREDIA.Banco = ""
            '    End If

            '    oZBAPI_ABONO_CIERREDIA.i_FactDpPro = "X"

            '    oZBAPI_ABONO_CIERREDIA.i_Mode = "N"


            '    fecha = CStr(CDate(dvTarjetaUno(intIndex)("Fecha")).ToShortDateString.Replace("/", ""))
            '    oZBAPI_ABONO_CIERREDIA.Fecha = Mid(fecha, 5, 4) & Mid(fecha, 3, 2) & Mid(fecha, 1, 2)
            '    oZBAPI_ABONO_CIERREDIA.Importe = CStr(dvTarjetaUno(intIndex)("Monto")).PadRight(16, " ")
            '    oZBAPI_ABONO_CIERREDIA.vBeln = CStr(dvTarjetaUno(intIndex)("FolioSAP")).PadLeft(10, "0")

            '    oProcesosSAPMgr = New ProcesoSAPManager(Me.oParent.ApplicationContext, Me.oParent.SAPApplicationConfig)
            '    strResult = oProcesosSAPMgr.WRITE_ZBAPI_ABONO_CIERREDIA(oZBAPI_ABONO_CIERREDIA, dt)

            '    If strResult = "Y" Then
            '        'actualizar el campo FI05SAP
            '        FacturaFI05ok(oZBAPI_ABONO_CIERREDIA.vBeln, oZBAPI_ABONO_CIERREDIA.ClaCobr)
            '    Else
            '        strMensaje += "FolioSAP: " & oZBAPI_ABONO_CIERREDIA.vBeln & vbCrLf
            '        For Each orow As DataRow In dt.Rows
            '            strMensaje += "Error: " & orow.Item("Message") & vbCrLf
            '        Next
            '        strMensaje += vbCrLf

            '        sm_GenerateFileTxtUp = "N"
            '    End If

            '    strResult = ""

            '    'strEncabezado = "40" & "EFECTIVO".PadRight(9, " ") & CStr(dvTarjetaUno(intIndex)("Tienda")).PadRight(20, " ") & _
            '    '                  CStr(Format(dvTarjetaUno(intIndex)("Monto"), "##########.#0")).PadLeft(16, " ") & _
            '    '                  CStr("121000001").PadLeft(10, "0") & strNumRef
            '    'txtWriter.WriteLine(strEncabezado)
            '    'txtWriter.WriteLine("11" & CStr(dvTarjetaUno(intIndex)("FolioSAP")).PadLeft(10, "0") & CStr(dvTarjetaUno(intIndex)("Monto")).PadRight(16, " ") & "Venta Dia " & CDate(dvTarjetaUno(intIndex)("Fecha")).ToShortDateString.Replace("/", "") & CStr("260000000").PadLeft(10, "0"))
            'Next

            ''Tarjeta 1
            'dvTarjetaUno.RowFilter = "CodBanco like 'T1' and CodTipoVenta='F'"

            'For intIndex = 0 To dvTarjetaUno.Count - 1
            '    dt = New DataTable

            '    oZBAPI_ABONO_CIERREDIA = New ZBapiAbonoCierreDia

            '    oZBAPI_ABONO_CIERREDIA.Tienda = CStr(dvTarjetaUno(intIndex)("Tienda")).PadRight(20, " ")

            '    oZBAPI_ABONO_CIERREDIA.Cliente = CStr("260000000").PadLeft(10, "0")

            '    oZBAPI_ABONO_CIERREDIA.Detalle = "X"

            '    'oZBAPI_ABONO_CIERREDIA.Ref_Banco = strNumRefBBV & FechaCierre.ToShortDateString.Replace("/", "")
            '    If CStr(dvTarjetaUno(0)("NoAfiliacion")).Length > 6 Then
            '        strNumRefBBV = Mid(CStr(dvTarjetaUno(intIndex)("NoAfiliacion")), 2)
            '    Else
            '        strNumRefBBV = CStr(dvTarjetaUno(intIndex)("NoAfiliacion")).PadLeft(6, "0")
            '    End If
            '    oZBAPI_ABONO_CIERREDIA.Ref_Banco = strNumRefBBV & Format(FechaRefBancos, "ddMMyyyy")

            '    oZBAPI_ABONO_CIERREDIA.ClaCobr = "TARJETA 1".PadRight(9, " ")

            '    dsBanco = Me.BancoSel(oZBAPI_ABONO_CIERREDIA.Tienda, oZBAPI_ABONO_CIERREDIA.ClaCobr)
            '    If dsBanco.Tables(0).Rows.Count > 0 Then
            '        oZBAPI_ABONO_CIERREDIA.Banco = dsBanco.Tables(0).Rows(0).Item("Banco")
            '    Else
            '        oZBAPI_ABONO_CIERREDIA.Banco = ""
            '    End If

            '    oZBAPI_ABONO_CIERREDIA.i_FactDpPro = "X"

            '    oZBAPI_ABONO_CIERREDIA.i_Mode = "N"


            '    fecha = CStr(CDate(dvTarjetaUno(intIndex)("Fecha")).ToShortDateString.Replace("/", ""))
            '    oZBAPI_ABONO_CIERREDIA.Fecha = Mid(fecha, 5, 4) & Mid(fecha, 3, 2) & Mid(fecha, 1, 2)
            '    oZBAPI_ABONO_CIERREDIA.Importe = CStr(dvTarjetaUno(intIndex)("Monto")).PadRight(16, " ")
            '    oZBAPI_ABONO_CIERREDIA.vBeln = CStr(dvTarjetaUno(intIndex)("FolioSAP")).PadLeft(10, "0")

            '    oProcesosSAPMgr = New ProcesoSAPManager(Me.oParent.ApplicationContext, Me.oParent.SAPApplicationConfig)
            '    strResult = oProcesosSAPMgr.WRITE_ZBAPI_ABONO_CIERREDIA(oZBAPI_ABONO_CIERREDIA, dt)

            '    If strResult = "Y" Then
            '        'actualizar el campo FI05SAP
            '        FacturaFI05ok(oZBAPI_ABONO_CIERREDIA.vBeln, oZBAPI_ABONO_CIERREDIA.ClaCobr)
            '    Else
            '        strMensaje += "FolioSAP: " & oZBAPI_ABONO_CIERREDIA.vBeln & vbCrLf
            '        For Each orow As DataRow In dt.Rows
            '            strMensaje += "Error: " & orow.Item("Message") & vbCrLf
            '        Next
            '        strMensaje += vbCrLf

            '        sm_GenerateFileTxtUp = "N"
            '    End If

            '    strResult = ""


            '    'strEncabezado = "40" & "TARJETA 1".PadRight(9, " ") & CStr(dvTarjetaUno(intIndex)("Tienda")).PadRight(20, " ") & _
            '    '                  CStr(Format(dvTarjetaUno(intIndex)("Monto"), "##########.#0")).PadLeft(16, " ") & _
            '    '                    CStr("121000001").PadLeft(10, "0") & "    " & FechaCierre.ToShortDateString.Replace("/", "")
            '    'txtWriter.WriteLine(strEncabezado)
            '    'txtWriter.WriteLine("11" & CStr(dvTarjetaUno(intIndex)("FolioSAP")).PadLeft(10, "0") & CStr(dvTarjetaUno(intIndex)("Monto")).PadRight(16, " ") & "Venta Dia " & CDate(dvTarjetaUno(intIndex)("Fecha")).ToShortDateString.Replace("/", "") & CStr("260000000").PadLeft(10, "0"))
            'Next

            ''Tarjeta 2
            'dvTarjetaUno.RowFilter = "CodBanco like 'T2' and CodTipoVenta='F'"

            'For intIndex = 0 To dvTarjetaUno.Count - 1
            '    strNumRefBBV = CStr(dvTarjetaUno(intIndex)("NoAfiliacion"))

            '    dt = New DataTable

            '    oZBAPI_ABONO_CIERREDIA = New ZBapiAbonoCierreDia

            '    oZBAPI_ABONO_CIERREDIA.Tienda = CStr(dvTarjetaUno(intIndex)("Tienda")).PadRight(20, " ")

            '    oZBAPI_ABONO_CIERREDIA.Cliente = CStr("260000000").PadLeft(10, "0")

            '    oZBAPI_ABONO_CIERREDIA.Detalle = "X"

            '    'oZBAPI_ABONO_CIERREDIA.Ref_Banco = "    " & FechaCierre.ToShortDateString.Replace("/", "")
            '    oZBAPI_ABONO_CIERREDIA.Ref_Banco = strNumRefBBV & Format(FechaRefBancos, "ddMMyy")

            '    oZBAPI_ABONO_CIERREDIA.ClaCobr = "TARJETA 2".PadRight(9, " ")

            '    dsBanco = Me.BancoSel(oZBAPI_ABONO_CIERREDIA.Tienda, oZBAPI_ABONO_CIERREDIA.ClaCobr)
            '    If dsBanco.Tables(0).Rows.Count > 0 Then
            '        oZBAPI_ABONO_CIERREDIA.Banco = dsBanco.Tables(0).Rows(0).Item("Banco")
            '    Else
            '        oZBAPI_ABONO_CIERREDIA.Banco = ""
            '    End If

            '    oZBAPI_ABONO_CIERREDIA.i_FactDpPro = "X"

            '    oZBAPI_ABONO_CIERREDIA.i_Mode = "N"


            '    fecha = CStr(CDate(dvTarjetaUno(intIndex)("Fecha")).ToShortDateString.Replace("/", ""))
            '    oZBAPI_ABONO_CIERREDIA.Fecha = Mid(fecha, 5, 4) & Mid(fecha, 3, 2) & Mid(fecha, 1, 2)
            '    oZBAPI_ABONO_CIERREDIA.Importe = CStr(dvTarjetaUno(intIndex)("Monto")).PadRight(16, " ")
            '    oZBAPI_ABONO_CIERREDIA.vBeln = CStr(dvTarjetaUno(intIndex)("FolioSAP")).PadLeft(10, "0")

            '    oProcesosSAPMgr = New ProcesoSAPManager(Me.oParent.ApplicationContext, Me.oParent.SAPApplicationConfig)
            '    strResult = oProcesosSAPMgr.WRITE_ZBAPI_ABONO_CIERREDIA(oZBAPI_ABONO_CIERREDIA, dt)

            '    If strResult = "Y" Then
            '        'actualizar el campo FI05SAP
            '        FacturaFI05ok(oZBAPI_ABONO_CIERREDIA.vBeln, oZBAPI_ABONO_CIERREDIA.ClaCobr)
            '    Else
            '        strMensaje += "FolioSAP: " & oZBAPI_ABONO_CIERREDIA.vBeln & vbCrLf
            '        For Each orow As DataRow In dt.Rows
            '            strMensaje += "Error: " & orow.Item("Message") & vbCrLf
            '        Next
            '        strMensaje += vbCrLf

            '        sm_GenerateFileTxtUp = "N"
            '    End If

            '    strResult = ""


            '    'strEncabezado = "40" & "TARJETA 2".PadRight(9, " ") & CStr(dvTarjetaUno(intIndex)("Tienda")).PadRight(20, " ") & _
            '    '                CStr(Format(dvTarjetaUno(intIndex)("Monto"), "##########.#0")).PadLeft(16, " ") & _
            '    '                CStr("121000001").PadRight(10, "0") & "    " & FechaCierre.ToShortDateString.Replace("/", "")
            '    'txtWriter.WriteLine(strEncabezado)
            '    'txtWriter.WriteLine("11" & CStr(dvTarjetaUno(intIndex)("FolioSAP")).PadLeft(10, "0") & CStr(dvTarjetaUno(intIndex)("Monto")).PadRight(16, " ") & "Venta Dia " & CDate(dvTarjetaUno(intIndex)("Fecha")).ToShortDateString.Replace("/", "") & CStr("260000000").PadLeft(10, "0"))
            'Next

            ''Tarjeta 3
            'dvTarjetaUno.RowFilter = "CodBanco like 'T3' and CodTipoVenta='F'"

            'For intIndex = 0 To dvTarjetaUno.Count - 1

            '    strNumRefBBV = CStr(dvTarjetaUno(intIndex)("NoAfiliacion"))

            '    dt = New DataTable

            '    oZBAPI_ABONO_CIERREDIA = New ZBapiAbonoCierreDia

            '    oZBAPI_ABONO_CIERREDIA.Tienda = CStr(dvTarjetaUno(intIndex)("Tienda")).PadRight(20, " ")

            '    oZBAPI_ABONO_CIERREDIA.Cliente = CStr("260000000").PadLeft(10, "0")

            '    oZBAPI_ABONO_CIERREDIA.Detalle = "X"

            '    oZBAPI_ABONO_CIERREDIA.Ref_Banco = strNumRefBBV & Format(FechaRefBancos, "ddMMyy")
            '    'oZBAPI_ABONO_CIERREDIA.Ref_Banco = "    " & FechaCierre.ToShortDateString.Replace("/", "")

            '    oZBAPI_ABONO_CIERREDIA.ClaCobr = "TARJETA 3".PadRight(9, " ")

            '    dsBanco = Me.BancoSel(oZBAPI_ABONO_CIERREDIA.Tienda, oZBAPI_ABONO_CIERREDIA.ClaCobr)
            '    If dsBanco.Tables(0).Rows.Count > 0 Then
            '        oZBAPI_ABONO_CIERREDIA.Banco = dsBanco.Tables(0).Rows(0).Item("Banco")
            '    Else
            '        oZBAPI_ABONO_CIERREDIA.Banco = ""
            '    End If

            '    oZBAPI_ABONO_CIERREDIA.i_FactDpPro = "X"

            '    oZBAPI_ABONO_CIERREDIA.i_Mode = "N"


            '    fecha = CStr(CDate(dvTarjetaUno(intIndex)("Fecha")).ToShortDateString.Replace("/", ""))
            '    oZBAPI_ABONO_CIERREDIA.Fecha = Mid(fecha, 5, 4) & Mid(fecha, 3, 2) & Mid(fecha, 1, 2)
            '    oZBAPI_ABONO_CIERREDIA.Importe = CStr(dvTarjetaUno(intIndex)("Monto")).PadRight(16, " ")
            '    oZBAPI_ABONO_CIERREDIA.vBeln = CStr(dvTarjetaUno(intIndex)("FolioSAP")).PadLeft(10, "0")

            '    oProcesosSAPMgr = New ProcesoSAPManager(Me.oParent.ApplicationContext, Me.oParent.SAPApplicationConfig)
            '    strResult = oProcesosSAPMgr.WRITE_ZBAPI_ABONO_CIERREDIA(oZBAPI_ABONO_CIERREDIA, dt)

            '    If strResult = "Y" Then
            '        'actualizar el campo FI05SAP
            '        FacturaFI05ok(oZBAPI_ABONO_CIERREDIA.vBeln, oZBAPI_ABONO_CIERREDIA.ClaCobr)
            '    Else
            '        strMensaje += "FolioSAP: " & oZBAPI_ABONO_CIERREDIA.vBeln & vbCrLf
            '        For Each orow As DataRow In dt.Rows
            '            strMensaje += "Error: " & orow.Item("Message") & vbCrLf
            '        Next
            '        strMensaje += vbCrLf

            '        sm_GenerateFileTxtUp = "N"
            '    End If

            '    strResult = ""

            '    'strEncabezado = "40" & "TARJETA 3".PadRight(9, " ") & CStr(dvTarjetaUno(intIndex)("Tienda")).PadRight(20, " ") & _
            '    '                CStr(Format(dvTarjetaUno(intIndex)("Monto"), "##########.#0")).PadLeft(16, " ") & _
            '    '                CStr("121000001").PadRight(10, "0") & "    " & FechaCierre.ToShortDateString.Replace("/", "")
            '    'txtWriter.WriteLine(strEncabezado)
            '    'txtWriter.WriteLine("11" & CStr(dvTarjetaUno(intIndex)("FolioSAP")).PadLeft(10, "0") & CStr(dvTarjetaUno(intIndex)("Monto")).PadRight(16, " ") & "Venta Dia " & CDate(dvTarjetaUno(intIndex)("Fecha")).ToShortDateString.Replace("/", "") & CStr("260000000").PadLeft(10, "0"))
            'Next

            ''----------------------------------------------------------------------------------------------------------------
            '' JNAVA (19.03.2015): Generamos el TXT de los Pagos DP CARD - FONACOT
            ''----------------------------------------------------------------------------------------------------------------
            'strCliente = CStr("260000000").PadLeft(10, "0")
            'sm_GenerateFileTxtUp = GetCobranzaDPCard(dvTarjetaUno, strCliente, "F", FechaCierre, strNumRef, strNumRefBBV, sm_GenerateFileTxtUp, strMensaje)
            ''---------------------------------------------------------------------------------------------------------------------------------
            ''RGERMAIN 15.05.2015: Subimos los pagos con DPCard Puntos a SAP en las ventas de Fonacot
            ''---------------------------------------------------------------------------------------------------------------------------------
            'strMensaje &= RegistraPagosDPCardPuntosSAP(strCliente, "DPPT", "F", dvTarjetaUno, strNumRef, sm_GenerateFileTxtUp)

            ''*********************************TARJETA FONACOT******************************
            ''Efectivo
            'dvTarjetaUno.RowFilter = "CodFormasPago like 'EFEC' and CodTipoVenta='K'"

            'For intIndex = 0 To dvTarjetaUno.Count - 1
            '    dt = New DataTable
            '    oZBAPI_ABONO_CIERREDIA = New ZBapiAbonoCierreDia

            '    oZBAPI_ABONO_CIERREDIA.Tienda = CStr(dvTarjetaUno(intIndex)("Tienda")).PadRight(20, " ")

            '    oZBAPI_ABONO_CIERREDIA.Cliente = CStr("260002268").PadLeft(10, "0")

            '    oZBAPI_ABONO_CIERREDIA.Detalle = "X"

            '    oZBAPI_ABONO_CIERREDIA.Ref_Banco = strNumRef

            '    oZBAPI_ABONO_CIERREDIA.ClaCobr = "EFECTIVO".PadRight(9, " ")

            '    dsBanco = Me.BancoSel(oZBAPI_ABONO_CIERREDIA.Tienda, oZBAPI_ABONO_CIERREDIA.ClaCobr)
            '    If dsBanco.Tables(0).Rows.Count > 0 Then
            '        oZBAPI_ABONO_CIERREDIA.Banco = dsBanco.Tables(0).Rows(0).Item("Banco")
            '    Else
            '        oZBAPI_ABONO_CIERREDIA.Banco = ""
            '    End If

            '    oZBAPI_ABONO_CIERREDIA.i_FactDpPro = "X"

            '    oZBAPI_ABONO_CIERREDIA.i_Mode = "N"


            '    fecha = CStr(CDate(dvTarjetaUno(intIndex)("Fecha")).ToShortDateString.Replace("/", ""))
            '    oZBAPI_ABONO_CIERREDIA.Fecha = Mid(fecha, 5, 4) & Mid(fecha, 3, 2) & Mid(fecha, 1, 2)
            '    oZBAPI_ABONO_CIERREDIA.Importe = CStr(dvTarjetaUno(intIndex)("Monto")).PadRight(16, " ")
            '    oZBAPI_ABONO_CIERREDIA.vBeln = CStr(dvTarjetaUno(intIndex)("FolioSAP")).PadLeft(10, "0")

            '    oProcesosSAPMgr = New ProcesoSAPManager(Me.oParent.ApplicationContext, Me.oParent.SAPApplicationConfig)
            '    strResult = oProcesosSAPMgr.WRITE_ZBAPI_ABONO_CIERREDIA(oZBAPI_ABONO_CIERREDIA, dt)

            '    If strResult = "Y" Then
            '        'actualizar el campo FI05SAP
            '        FacturaFI05ok(oZBAPI_ABONO_CIERREDIA.vBeln, oZBAPI_ABONO_CIERREDIA.ClaCobr)
            '    Else
            '        strMensaje += "FolioSAP: " & oZBAPI_ABONO_CIERREDIA.vBeln & vbCrLf
            '        For Each orow As DataRow In dt.Rows
            '            strMensaje += "Error: " & orow.Item("Message") & vbCrLf
            '        Next
            '        strMensaje += vbCrLf

            '        sm_GenerateFileTxtUp = "N"
            '    End If

            '    strResult = ""

            '    'strEncabezado = "40" & "EFECTIVO".PadRight(9, " ") & CStr(dvTarjetaUno(intIndex)("Tienda")).PadRight(20, " ") & _
            '    '                  CStr(Format(dvTarjetaUno(intIndex)("Monto"), "##########.#0")).PadLeft(16, " ") & _
            '    '                  CStr("121000001").PadLeft(10, "0") & strNumRef
            '    'txtWriter.WriteLine(strEncabezado)
            '    'txtWriter.WriteLine("11" & CStr(dvTarjetaUno(intIndex)("FolioSAP")).PadLeft(10, "0") & CStr(dvTarjetaUno(intIndex)("Monto")).PadRight(16, " ") & "Venta Dia " & CDate(dvTarjetaUno(intIndex)("Fecha")).ToShortDateString.Replace("/", "") & CStr("260002268").PadLeft(10, "0"))
            'Next

            ''Tarjeta 1
            'dvTarjetaUno.RowFilter = "CodBanco like 'T1' and CodTipoVenta='K'"

            'For intIndex = 0 To dvTarjetaUno.Count - 1
            '    dt = New DataTable
            '    oZBAPI_ABONO_CIERREDIA = New ZBapiAbonoCierreDia

            '    oZBAPI_ABONO_CIERREDIA.Tienda = CStr(dvTarjetaUno(intIndex)("Tienda")).PadRight(20, " ")

            '    oZBAPI_ABONO_CIERREDIA.Cliente = CStr("260002268").PadLeft(10, "0")

            '    oZBAPI_ABONO_CIERREDIA.Detalle = "X"

            '    'oZBAPI_ABONO_CIERREDIA.Ref_Banco = strNumRefBBV & FechaCierre.ToShortDateString.Replace("/", "")
            '    If CStr(dvTarjetaUno(0)("NoAfiliacion")).Length > 6 Then
            '        strNumRefBBV = Mid(CStr(dvTarjetaUno(intIndex)("NoAfiliacion")), 2)
            '    Else
            '        strNumRefBBV = CStr(dvTarjetaUno(intIndex)("NoAfiliacion")).PadLeft(6, "0")
            '    End If
            '    oZBAPI_ABONO_CIERREDIA.Ref_Banco = strNumRefBBV & Format(FechaRefBancos, "ddMMyyyy")

            '    oZBAPI_ABONO_CIERREDIA.ClaCobr = "TARJETA 1".PadRight(9, " ")

            '    dsBanco = Me.BancoSel(oZBAPI_ABONO_CIERREDIA.Tienda, oZBAPI_ABONO_CIERREDIA.ClaCobr)
            '    If dsBanco.Tables(0).Rows.Count > 0 Then
            '        oZBAPI_ABONO_CIERREDIA.Banco = dsBanco.Tables(0).Rows(0).Item("Banco")
            '    Else
            '        oZBAPI_ABONO_CIERREDIA.Banco = ""
            '    End If

            '    oZBAPI_ABONO_CIERREDIA.i_FactDpPro = "X"

            '    oZBAPI_ABONO_CIERREDIA.i_Mode = "N"


            '    fecha = CStr(CDate(dvTarjetaUno(intIndex)("Fecha")).ToShortDateString.Replace("/", ""))
            '    oZBAPI_ABONO_CIERREDIA.Fecha = Mid(fecha, 5, 4) & Mid(fecha, 3, 2) & Mid(fecha, 1, 2)
            '    oZBAPI_ABONO_CIERREDIA.Importe = CStr(dvTarjetaUno(intIndex)("Monto")).PadRight(16, " ")
            '    oZBAPI_ABONO_CIERREDIA.vBeln = CStr(dvTarjetaUno(intIndex)("FolioSAP")).PadLeft(10, "0")

            '    oProcesosSAPMgr = New ProcesoSAPManager(Me.oParent.ApplicationContext, Me.oParent.SAPApplicationConfig)
            '    strResult = oProcesosSAPMgr.WRITE_ZBAPI_ABONO_CIERREDIA(oZBAPI_ABONO_CIERREDIA, dt)

            '    If strResult = "Y" Then
            '        'actualizar el campo FI05SAP
            '        FacturaFI05ok(oZBAPI_ABONO_CIERREDIA.vBeln, oZBAPI_ABONO_CIERREDIA.ClaCobr)
            '    Else
            '        strMensaje += "FolioSAP: " & oZBAPI_ABONO_CIERREDIA.vBeln & vbCrLf
            '        For Each orow As DataRow In dt.Rows
            '            strMensaje += "Error: " & orow.Item("Message") & vbCrLf
            '        Next
            '        strMensaje += vbCrLf

            '        sm_GenerateFileTxtUp = "N"
            '    End If

            '    strResult = ""


            '    'strEncabezado = "40" & "TARJETA 1".PadRight(9, " ") & CStr(dvTarjetaUno(intIndex)("Tienda")).PadRight(20, " ") & _
            '    '                  CStr(Format(dvTarjetaUno(intIndex)("Monto"), "##########.#0")).PadLeft(16, " ") & _
            '    '                    CStr("121000001").PadLeft(10, "0") & "    " & FechaCierre.ToShortDateString.Replace("/", "")
            '    'txtWriter.WriteLine(strEncabezado)
            '    'txtWriter.WriteLine("11" & CStr(dvTarjetaUno(intIndex)("FolioSAP")).PadLeft(10, "0") & CStr(dvTarjetaUno(intIndex)("Monto")).PadRight(16, " ") & "Venta Dia " & CDate(dvTarjetaUno(intIndex)("Fecha")).ToShortDateString.Replace("/", "") & CStr("260002268").PadLeft(10, "0"))
            'Next

            ''Tarjeta 2
            'dvTarjetaUno.RowFilter = "CodBanco like 'T2' and CodTipoVenta='K'"

            'For intIndex = 0 To dvTarjetaUno.Count - 1

            '    strNumRefBBV = CStr(dvTarjetaUno(intIndex)("NoAfiliacion"))

            '    dt = New DataTable

            '    oZBAPI_ABONO_CIERREDIA = New ZBapiAbonoCierreDia

            '    oZBAPI_ABONO_CIERREDIA.Tienda = CStr(dvTarjetaUno(intIndex)("Tienda")).PadRight(20, " ")

            '    oZBAPI_ABONO_CIERREDIA.Cliente = CStr("260002268").PadLeft(10, "0")

            '    oZBAPI_ABONO_CIERREDIA.Detalle = "X"

            '    oZBAPI_ABONO_CIERREDIA.Ref_Banco = strNumRefBBV & Format(FechaRefBancos, "ddMMyy")
            '    'oZBAPI_ABONO_CIERREDIA.Ref_Banco = "    " & FechaCierre.ToShortDateString.Replace("/", "")

            '    oZBAPI_ABONO_CIERREDIA.ClaCobr = "TARJETA 2".PadRight(9, " ")

            '    dsBanco = Me.BancoSel(oZBAPI_ABONO_CIERREDIA.Tienda, oZBAPI_ABONO_CIERREDIA.ClaCobr)
            '    If dsBanco.Tables(0).Rows.Count > 0 Then
            '        oZBAPI_ABONO_CIERREDIA.Banco = dsBanco.Tables(0).Rows(0).Item("Banco")
            '    Else
            '        oZBAPI_ABONO_CIERREDIA.Banco = ""
            '    End If

            '    oZBAPI_ABONO_CIERREDIA.i_FactDpPro = "X"

            '    oZBAPI_ABONO_CIERREDIA.i_Mode = "N"


            '    fecha = CStr(CDate(dvTarjetaUno(intIndex)("Fecha")).ToShortDateString.Replace("/", ""))
            '    oZBAPI_ABONO_CIERREDIA.Fecha = Mid(fecha, 5, 4) & Mid(fecha, 3, 2) & Mid(fecha, 1, 2)
            '    oZBAPI_ABONO_CIERREDIA.Importe = CStr(dvTarjetaUno(intIndex)("Monto")).PadRight(16, " ")
            '    oZBAPI_ABONO_CIERREDIA.vBeln = CStr(dvTarjetaUno(intIndex)("FolioSAP")).PadLeft(10, "0")

            '    oProcesosSAPMgr = New ProcesoSAPManager(Me.oParent.ApplicationContext, Me.oParent.SAPApplicationConfig)
            '    strResult = oProcesosSAPMgr.WRITE_ZBAPI_ABONO_CIERREDIA(oZBAPI_ABONO_CIERREDIA, dt)

            '    If strResult = "Y" Then
            '        'actualizar el campo FI05SAP
            '        FacturaFI05ok(oZBAPI_ABONO_CIERREDIA.vBeln, oZBAPI_ABONO_CIERREDIA.ClaCobr)
            '    Else
            '        strMensaje += "FolioSAP: " & oZBAPI_ABONO_CIERREDIA.vBeln & vbCrLf
            '        For Each orow As DataRow In dt.Rows
            '            strMensaje += "Error: " & orow.Item("Message") & vbCrLf
            '        Next
            '        strMensaje += vbCrLf

            '        sm_GenerateFileTxtUp = "N"
            '    End If

            '    strResult = ""


            '    'strEncabezado = "40" & "TARJETA 2".PadRight(9, " ") & CStr(dvTarjetaUno(intIndex)("Tienda")).PadRight(20, " ") & _
            '    '                CStr(Format(dvTarjetaUno(intIndex)("Monto"), "##########.#0")).PadLeft(16, " ") & _
            '    '                CStr("121000001").PadRight(10, "0") & "    " & FechaCierre.ToShortDateString.Replace("/", "")
            '    'txtWriter.WriteLine(strEncabezado)
            '    'txtWriter.WriteLine("11" & CStr(dvTarjetaUno(intIndex)("FolioSAP")).PadLeft(10, "0") & CStr(dvTarjetaUno(intIndex)("Monto")).PadRight(16, " ") & "Venta Dia " & CDate(dvTarjetaUno(intIndex)("Fecha")).ToShortDateString.Replace("/", "") & CStr("260002268").PadLeft(10, "0"))
            'Next

            ''Tarjeta 3
            'dvTarjetaUno.RowFilter = "CodBanco like 'T3' and CodTipoVenta='K'"

            'For intIndex = 0 To dvTarjetaUno.Count - 1

            '    strNumRefBBV = CStr(dvTarjetaUno(intIndex)("NoAfiliacion"))

            '    dt = New DataTable

            '    oZBAPI_ABONO_CIERREDIA = New ZBapiAbonoCierreDia

            '    oZBAPI_ABONO_CIERREDIA.Tienda = CStr(dvTarjetaUno(intIndex)("Tienda")).PadRight(20, " ")

            '    oZBAPI_ABONO_CIERREDIA.Cliente = CStr("260002268").PadLeft(10, "0")

            '    oZBAPI_ABONO_CIERREDIA.Detalle = "X"

            '    oZBAPI_ABONO_CIERREDIA.Ref_Banco = strNumRefBBV & Format(FechaRefBancos, "ddMMyy")
            '    'oZBAPI_ABONO_CIERREDIA.Ref_Banco = "    " & FechaCierre.ToShortDateString.Replace("/", "")

            '    oZBAPI_ABONO_CIERREDIA.ClaCobr = "TARJETA 3".PadRight(9, " ")

            '    dsBanco = Me.BancoSel(oZBAPI_ABONO_CIERREDIA.Tienda, oZBAPI_ABONO_CIERREDIA.ClaCobr)
            '    If dsBanco.Tables(0).Rows.Count > 0 Then
            '        oZBAPI_ABONO_CIERREDIA.Banco = dsBanco.Tables(0).Rows(0).Item("Banco")
            '    Else
            '        oZBAPI_ABONO_CIERREDIA.Banco = ""
            '    End If

            '    oZBAPI_ABONO_CIERREDIA.i_FactDpPro = "X"

            '    oZBAPI_ABONO_CIERREDIA.i_Mode = "N"


            '    fecha = CStr(CDate(dvTarjetaUno(intIndex)("Fecha")).ToShortDateString.Replace("/", ""))
            '    oZBAPI_ABONO_CIERREDIA.Fecha = Mid(fecha, 5, 4) & Mid(fecha, 3, 2) & Mid(fecha, 1, 2)
            '    oZBAPI_ABONO_CIERREDIA.Importe = CStr(dvTarjetaUno(intIndex)("Monto")).PadRight(16, " ")
            '    oZBAPI_ABONO_CIERREDIA.vBeln = CStr(dvTarjetaUno(intIndex)("FolioSAP")).PadLeft(10, "0")

            '    oProcesosSAPMgr = New ProcesoSAPManager(Me.oParent.ApplicationContext, Me.oParent.SAPApplicationConfig)
            '    strResult = oProcesosSAPMgr.WRITE_ZBAPI_ABONO_CIERREDIA(oZBAPI_ABONO_CIERREDIA, dt)

            '    If strResult = "Y" Then
            '        'actualizar el campo FI05SAP
            '        FacturaFI05ok(oZBAPI_ABONO_CIERREDIA.vBeln, oZBAPI_ABONO_CIERREDIA.ClaCobr)
            '    Else
            '        strMensaje += "FolioSAP: " & oZBAPI_ABONO_CIERREDIA.vBeln & vbCrLf
            '        For Each orow As DataRow In dt.Rows
            '            strMensaje += "Error: " & orow.Item("Message") & vbCrLf
            '        Next
            '        strMensaje += vbCrLf

            '        sm_GenerateFileTxtUp = "N"
            '    End If

            '    strResult = ""



            '    'strEncabezado = "40" & "TARJETA 3".PadRight(9, " ") & CStr(dvTarjetaUno(intIndex)("Tienda")).PadRight(20, " ") & _
            '    '                CStr(Format(dvTarjetaUno(intIndex)("Monto"), "##########.#0")).PadLeft(16, " ") & _
            '    '                CStr("121000001").PadRight(10, "0") & "    " & FechaCierre.ToShortDateString.Replace("/", "")
            '    'txtWriter.WriteLine(strEncabezado)
            '    'txtWriter.WriteLine("11" & CStr(dvTarjetaUno(intIndex)("FolioSAP")).PadLeft(10, "0") & CStr(dvTarjetaUno(intIndex)("Monto")).PadRight(16, " ") & "Venta Dia " & CDate(dvTarjetaUno(intIndex)("Fecha")).ToShortDateString.Replace("/", "") & CStr("260002268").PadLeft(10, "0"))
            'Next

            ''----------------------------------------------------------------------------------------------------------------
            '' JNAVA (19.03.2015): Generamos el TXT de los Pagos DP CARD - TARJETA FONACOT
            ''----------------------------------------------------------------------------------------------------------------
            'strCliente = CStr("260002268").PadLeft(10, "0")
            'sm_GenerateFileTxtUp = GetCobranzaDPCard(dvTarjetaUno, strCliente, "K", FechaCierre, strNumRef, strNumRefBBV, sm_GenerateFileTxtUp, strMensaje)
            ''---------------------------------------------------------------------------------------------------------------------------------
            ''RGERMAIN 15.05.2015: Subimos los pagos con DPCard Puntos a SAP en las ventas de Tarjeta Fonacot
            ''---------------------------------------------------------------------------------------------------------------------------------
            'strMensaje &= RegistraPagosDPCardPuntosSAP(strCliente, "DPPT", "K", dvTarjetaUno, strNumRef, sm_GenerateFileTxtUp)

            ''*********************************FACILITO******************************
            ''Efectivo
            'dvTarjetaUno.RowFilter = "CodFormasPago like 'EFEC' and CodTipoVenta='O'"

            'For intIndex = 0 To dvTarjetaUno.Count - 1
            '    dt = New DataTable
            '    oZBAPI_ABONO_CIERREDIA = New ZBapiAbonoCierreDia

            '    oZBAPI_ABONO_CIERREDIA.Tienda = CStr(dvTarjetaUno(intIndex)("Tienda")).PadRight(20, " ")

            '    oZBAPI_ABONO_CIERREDIA.Cliente = CStr("260000001").PadLeft(10, "0")

            '    oZBAPI_ABONO_CIERREDIA.Detalle = "X"

            '    oZBAPI_ABONO_CIERREDIA.Ref_Banco = strNumRef

            '    oZBAPI_ABONO_CIERREDIA.ClaCobr = "EFECTIVO".PadRight(9, " ")

            '    dsBanco = Me.BancoSel(oZBAPI_ABONO_CIERREDIA.Tienda, oZBAPI_ABONO_CIERREDIA.ClaCobr)
            '    If dsBanco.Tables(0).Rows.Count > 0 Then
            '        oZBAPI_ABONO_CIERREDIA.Banco = dsBanco.Tables(0).Rows(0).Item("Banco")
            '    Else
            '        oZBAPI_ABONO_CIERREDIA.Banco = ""
            '    End If

            '    oZBAPI_ABONO_CIERREDIA.i_FactDpPro = "X"

            '    oZBAPI_ABONO_CIERREDIA.i_Mode = "N"


            '    fecha = CStr(CDate(dvTarjetaUno(intIndex)("Fecha")).ToShortDateString.Replace("/", ""))
            '    oZBAPI_ABONO_CIERREDIA.Fecha = Mid(fecha, 5, 4) & Mid(fecha, 3, 2) & Mid(fecha, 1, 2)
            '    oZBAPI_ABONO_CIERREDIA.Importe = CStr(dvTarjetaUno(intIndex)("Monto")).PadRight(16, " ")
            '    oZBAPI_ABONO_CIERREDIA.vBeln = CStr(dvTarjetaUno(intIndex)("FolioSAP")).PadLeft(10, "0")

            '    oProcesosSAPMgr = New ProcesoSAPManager(Me.oParent.ApplicationContext, Me.oParent.SAPApplicationConfig)
            '    strResult = oProcesosSAPMgr.WRITE_ZBAPI_ABONO_CIERREDIA(oZBAPI_ABONO_CIERREDIA, dt)

            '    If strResult = "Y" Then
            '        'actualizar el campo FI05SAP
            '        FacturaFI05ok(oZBAPI_ABONO_CIERREDIA.vBeln, oZBAPI_ABONO_CIERREDIA.ClaCobr)
            '    Else
            '        strMensaje += "FolioSAP: " & oZBAPI_ABONO_CIERREDIA.vBeln & vbCrLf
            '        For Each orow As DataRow In dt.Rows
            '            strMensaje += "Error: " & orow.Item("Message") & vbCrLf
            '        Next
            '        strMensaje += vbCrLf

            '        sm_GenerateFileTxtUp = "N"
            '    End If

            '    strResult = ""

            '    'strEncabezado = "40" & "EFECTIVO".PadRight(9, " ") & CStr(dvTarjetaUno(intIndex)("Tienda")).PadRight(20, " ") & _
            '    '                  CStr(Format(dvTarjetaUno(intIndex)("Monto"), "##########.#0")).PadLeft(16, " ") & _
            '    '                  CStr("121000001").PadLeft(10, "0") & strNumRef
            '    'txtWriter.WriteLine(strEncabezado)
            '    'txtWriter.WriteLine("11" & CStr(dvTarjetaUno(intIndex)("FolioSAP")).PadLeft(10, "0") & CStr(dvTarjetaUno(intIndex)("Monto")).PadRight(16, " ") & "Venta Dia " & CDate(dvTarjetaUno(intIndex)("Fecha")).ToShortDateString.Replace("/", "") & CStr("260000001").PadLeft(10, "0"))
            'Next

            ''Tarjeta 1
            'dvTarjetaUno.RowFilter = "CodBanco like 'T1' and CodTipoVenta='O'"

            'For intIndex = 0 To dvTarjetaUno.Count - 1
            '    dt = New DataTable
            '    oZBAPI_ABONO_CIERREDIA = New ZBapiAbonoCierreDia

            '    oZBAPI_ABONO_CIERREDIA.Tienda = CStr(dvTarjetaUno(intIndex)("Tienda")).PadRight(20, " ")

            '    oZBAPI_ABONO_CIERREDIA.Cliente = CStr("260000001").PadLeft(10, "0")

            '    oZBAPI_ABONO_CIERREDIA.Detalle = "X"

            '    'oZBAPI_ABONO_CIERREDIA.Ref_Banco = strNumRefBBV & FechaCierre.ToShortDateString.Replace("/", "")
            '    If CStr(dvTarjetaUno(0)("NoAfiliacion")).Length > 6 Then
            '        strNumRefBBV = Mid(CStr(dvTarjetaUno(intIndex)("NoAfiliacion")), 2)
            '    Else
            '        strNumRefBBV = CStr(dvTarjetaUno(intIndex)("NoAfiliacion")).PadLeft(6, "0")
            '    End If
            '    oZBAPI_ABONO_CIERREDIA.Ref_Banco = strNumRefBBV & Format(FechaRefBancos, "ddMMyyyy")

            '    oZBAPI_ABONO_CIERREDIA.ClaCobr = "TARJETA 1".PadRight(9, " ")

            '    dsBanco = Me.BancoSel(oZBAPI_ABONO_CIERREDIA.Tienda, oZBAPI_ABONO_CIERREDIA.ClaCobr)
            '    If dsBanco.Tables(0).Rows.Count > 0 Then
            '        oZBAPI_ABONO_CIERREDIA.Banco = dsBanco.Tables(0).Rows(0).Item("Banco")
            '    Else
            '        oZBAPI_ABONO_CIERREDIA.Banco = ""
            '    End If

            '    oZBAPI_ABONO_CIERREDIA.i_FactDpPro = "X"

            '    oZBAPI_ABONO_CIERREDIA.i_Mode = "N"


            '    fecha = CStr(CDate(dvTarjetaUno(intIndex)("Fecha")).ToShortDateString.Replace("/", ""))
            '    oZBAPI_ABONO_CIERREDIA.Fecha = Mid(fecha, 5, 4) & Mid(fecha, 3, 2) & Mid(fecha, 1, 2)
            '    oZBAPI_ABONO_CIERREDIA.Importe = CStr(dvTarjetaUno(intIndex)("Monto")).PadRight(16, " ")
            '    oZBAPI_ABONO_CIERREDIA.vBeln = CStr(dvTarjetaUno(intIndex)("FolioSAP")).PadLeft(10, "0")

            '    oProcesosSAPMgr = New ProcesoSAPManager(Me.oParent.ApplicationContext, Me.oParent.SAPApplicationConfig)
            '    strResult = oProcesosSAPMgr.WRITE_ZBAPI_ABONO_CIERREDIA(oZBAPI_ABONO_CIERREDIA, dt)

            '    If strResult = "Y" Then
            '        'actualizar el campo FI05SAP
            '        FacturaFI05ok(oZBAPI_ABONO_CIERREDIA.vBeln, oZBAPI_ABONO_CIERREDIA.ClaCobr)
            '    Else
            '        strMensaje += "FolioSAP: " & oZBAPI_ABONO_CIERREDIA.vBeln & vbCrLf
            '        For Each orow As DataRow In dt.Rows
            '            strMensaje += "Error: " & orow.Item("Message") & vbCrLf
            '        Next
            '        strMensaje += vbCrLf

            '        sm_GenerateFileTxtUp = "N"
            '    End If

            '    strResult = ""


            '    'strEncabezado = "40" & "TARJETA 1".PadRight(9, " ") & CStr(dvTarjetaUno(intIndex)("Tienda")).PadRight(20, " ") & _
            '    '                 CStr(Format(dvTarjetaUno(intIndex)("Monto"), "##########.#0")).PadLeft(16, " ") & _
            '    '                 CStr("121000001").PadLeft(10, "0") & "    " & FechaCierre.ToShortDateString.Replace("/", "")
            '    'txtWriter.WriteLine(strEncabezado)
            '    'txtWriter.WriteLine("11" & CStr(dvTarjetaUno(intIndex)("FolioSAP")).PadLeft(10, "0") & CStr(dvTarjetaUno(intIndex)("Monto")).PadRight(16, " ") & "Venta Dia " & CDate(dvTarjetaUno(intIndex)("Fecha")).ToShortDateString.Replace("/", "") & CStr("260000001").PadLeft(10, "0"))
            'Next

            ''Tarjeta 2
            'dvTarjetaUno.RowFilter = "CodBanco like 'T2' and CodTipoVenta='O'"

            'For intIndex = 0 To dvTarjetaUno.Count - 1

            '    strNumRefBBV = CStr(dvTarjetaUno(intIndex)("NoAfiliacion"))

            '    dt = New DataTable

            '    oZBAPI_ABONO_CIERREDIA = New ZBapiAbonoCierreDia

            '    oZBAPI_ABONO_CIERREDIA.Tienda = CStr(dvTarjetaUno(intIndex)("Tienda")).PadRight(20, " ")

            '    oZBAPI_ABONO_CIERREDIA.Cliente = CStr("260000001").PadLeft(10, "0")

            '    oZBAPI_ABONO_CIERREDIA.Detalle = "X"

            '    oZBAPI_ABONO_CIERREDIA.Ref_Banco = strNumRefBBV & Format(FechaRefBancos, "ddMMyy")
            '    'oZBAPI_ABONO_CIERREDIA.Ref_Banco = "    " & FechaCierre.ToShortDateString.Replace("/", "")

            '    oZBAPI_ABONO_CIERREDIA.ClaCobr = "TARJETA 2".PadRight(9, " ")

            '    dsBanco = Me.BancoSel(oZBAPI_ABONO_CIERREDIA.Tienda, oZBAPI_ABONO_CIERREDIA.ClaCobr)
            '    If dsBanco.Tables(0).Rows.Count > 0 Then
            '        oZBAPI_ABONO_CIERREDIA.Banco = dsBanco.Tables(0).Rows(0).Item("Banco")
            '    Else
            '        oZBAPI_ABONO_CIERREDIA.Banco = ""
            '    End If

            '    oZBAPI_ABONO_CIERREDIA.i_FactDpPro = "X"

            '    oZBAPI_ABONO_CIERREDIA.i_Mode = "N"


            '    fecha = CStr(CDate(dvTarjetaUno(intIndex)("Fecha")).ToShortDateString.Replace("/", ""))
            '    oZBAPI_ABONO_CIERREDIA.Fecha = Mid(fecha, 5, 4) & Mid(fecha, 3, 2) & Mid(fecha, 1, 2)
            '    oZBAPI_ABONO_CIERREDIA.Importe = CStr(dvTarjetaUno(intIndex)("Monto")).PadRight(16, " ")
            '    oZBAPI_ABONO_CIERREDIA.vBeln = CStr(dvTarjetaUno(intIndex)("FolioSAP")).PadLeft(10, "0")

            '    oProcesosSAPMgr = New ProcesoSAPManager(Me.oParent.ApplicationContext, Me.oParent.SAPApplicationConfig)
            '    strResult = oProcesosSAPMgr.WRITE_ZBAPI_ABONO_CIERREDIA(oZBAPI_ABONO_CIERREDIA, dt)

            '    If strResult = "Y" Then
            '        'actualizar el campo FI05SAP
            '        FacturaFI05ok(oZBAPI_ABONO_CIERREDIA.vBeln, oZBAPI_ABONO_CIERREDIA.ClaCobr)
            '    Else
            '        strMensaje += "FolioSAP: " & oZBAPI_ABONO_CIERREDIA.vBeln & vbCrLf
            '        For Each orow As DataRow In dt.Rows
            '            strMensaje += "Error: " & orow.Item("Message") & vbCrLf
            '        Next
            '        strMensaje += vbCrLf

            '        sm_GenerateFileTxtUp = "N"
            '    End If

            '    strResult = ""

            '    'strEncabezado = "40" & "TARJETA 2".PadRight(9, " ") & CStr(dvTarjetaUno(intIndex)("Tienda")).PadRight(20, " ") & _
            '    '                  CStr(Format(dvTarjetaUno(intIndex)("Monto"), "##########.#0")).PadLeft(16, " ") & _
            '    '                  CStr("121000001").PadRight(10, "0") & "    " & FechaCierre.ToShortDateString.Replace("/", "")
            '    'txtWriter.WriteLine(strEncabezado)
            '    'txtWriter.WriteLine("11" & CStr(dvTarjetaUno(intIndex)("FolioSAP")).PadLeft(10, "0") & CStr(dvTarjetaUno(intIndex)("Monto")).PadRight(16, " ") & "Venta Dia " & CDate(dvTarjetaUno(intIndex)("Fecha")).ToShortDateString.Replace("/", "") & CStr("260000001").PadLeft(10, "0"))
            'Next

            ''Tarjeta 3
            'dvTarjetaUno.RowFilter = "CodBanco like 'T3' and CodTipoVenta='O'"

            'For intIndex = 0 To dvTarjetaUno.Count - 1

            '    strNumRefBBV = CStr(dvTarjetaUno(intIndex)("NoAfiliacion"))

            '    dt = New DataTable

            '    oZBAPI_ABONO_CIERREDIA = New ZBapiAbonoCierreDia

            '    oZBAPI_ABONO_CIERREDIA.Tienda = CStr(dvTarjetaUno(intIndex)("Tienda")).PadRight(20, " ")

            '    oZBAPI_ABONO_CIERREDIA.Cliente = CStr("260000001").PadLeft(10, "0")

            '    oZBAPI_ABONO_CIERREDIA.Detalle = "X"

            '    oZBAPI_ABONO_CIERREDIA.Ref_Banco = strNumRefBBV & Format(FechaRefBancos, "ddMMyy")
            '    'oZBAPI_ABONO_CIERREDIA.Ref_Banco = "    " & FechaCierre.ToShortDateString.Replace("/", "")

            '    oZBAPI_ABONO_CIERREDIA.ClaCobr = "TARJETA 3".PadRight(9, " ")

            '    dsBanco = Me.BancoSel(oZBAPI_ABONO_CIERREDIA.Tienda, oZBAPI_ABONO_CIERREDIA.ClaCobr)
            '    If dsBanco.Tables(0).Rows.Count > 0 Then
            '        oZBAPI_ABONO_CIERREDIA.Banco = dsBanco.Tables(0).Rows(0).Item("Banco")
            '    Else
            '        oZBAPI_ABONO_CIERREDIA.Banco = ""
            '    End If

            '    oZBAPI_ABONO_CIERREDIA.i_FactDpPro = "X"

            '    oZBAPI_ABONO_CIERREDIA.i_Mode = "N"


            '    fecha = CStr(CDate(dvTarjetaUno(intIndex)("Fecha")).ToShortDateString.Replace("/", ""))
            '    oZBAPI_ABONO_CIERREDIA.Fecha = Mid(fecha, 5, 4) & Mid(fecha, 3, 2) & Mid(fecha, 1, 2)
            '    oZBAPI_ABONO_CIERREDIA.Importe = CStr(dvTarjetaUno(intIndex)("Monto")).PadRight(16, " ")
            '    oZBAPI_ABONO_CIERREDIA.vBeln = CStr(dvTarjetaUno(intIndex)("FolioSAP")).PadLeft(10, "0")

            '    oProcesosSAPMgr = New ProcesoSAPManager(Me.oParent.ApplicationContext, Me.oParent.SAPApplicationConfig)
            '    strResult = oProcesosSAPMgr.WRITE_ZBAPI_ABONO_CIERREDIA(oZBAPI_ABONO_CIERREDIA, dt)

            '    If strResult = "Y" Then
            '        'actualizar el campo FI05SAP
            '        FacturaFI05ok(oZBAPI_ABONO_CIERREDIA.vBeln, oZBAPI_ABONO_CIERREDIA.ClaCobr)
            '    Else
            '        strMensaje += "FolioSAP: " & oZBAPI_ABONO_CIERREDIA.vBeln & vbCrLf
            '        For Each orow As DataRow In dt.Rows
            '            strMensaje += "Error: " & orow.Item("Message") & vbCrLf
            '        Next
            '        strMensaje += vbCrLf

            '        sm_GenerateFileTxtUp = "N"
            '    End If

            '    strResult = ""

            '    'strEncabezado = "40" & "TARJETA 3".PadRight(9, " ") & CStr(dvTarjetaUno(intIndex)("Tienda")).PadRight(20, " ") & _
            '    '                  CStr(Format(dvTarjetaUno(intIndex)("Monto"), "##########.#0")).PadLeft(16, " ") & _
            '    '                  CStr("121000001").PadRight(10, "0") & "    " & FechaCierre.ToShortDateString.Replace("/", "")
            '    'txtWriter.WriteLine(strEncabezado)
            '    'txtWriter.WriteLine("11" & CStr(dvTarjetaUno(intIndex)("FolioSAP")).PadLeft(10, "0") & CStr(dvTarjetaUno(intIndex)("Monto")).PadRight(16, " ") & "Venta Dia " & CDate(dvTarjetaUno(intIndex)("Fecha")).ToShortDateString.Replace("/", "") & CStr("260000001").PadLeft(10, "0"))
            'Next

            ''----------------------------------------------------------------------------------------------------------------
            '' JNAVA (19.03.2015): Generamos el TXT de los Pagos DP CARD - FACILITO
            ''----------------------------------------------------------------------------------------------------------------
            'strCliente = CStr("260000001").PadLeft(10, "0")
            'sm_GenerateFileTxtUp = GetCobranzaDPCard(dvTarjetaUno, strCliente, "O", FechaCierre, strNumRef, strNumRefBBV, sm_GenerateFileTxtUp, strMensaje)
            ''---------------------------------------------------------------------------------------------------------------------------------
            ''RGERMAIN 15.05.2015: Subimos los pagos con DPCard Puntos a SAP en las ventas de Facilito
            ''---------------------------------------------------------------------------------------------------------------------------------
            'strMensaje &= RegistraPagosDPCardPuntosSAP(strCliente, "DPPT", "O", dvTarjetaUno, strNumRef, sm_GenerateFileTxtUp)

            ''*********************************SOCIOS 053******************************
            ''Efectivo
            'dvTarjetaUno.RowFilter = "CodFormasPago like 'EFEC' and CodTipoVenta='S'"

            'For intIndex = 0 To dvTarjetaUno.Count - 1
            '    dt = New DataTable
            '    oZBAPI_ABONO_CIERREDIA = New ZBapiAbonoCierreDia

            '    oZBAPI_ABONO_CIERREDIA.Tienda = CStr(dvTarjetaUno(intIndex)("Tienda")).PadRight(20, " ")

            '    oZBAPI_ABONO_CIERREDIA.Cliente = CStr(dvTarjetaUno(intIndex)("ClienteID")).PadLeft(10, "0")

            '    oZBAPI_ABONO_CIERREDIA.Detalle = "X"

            '    oZBAPI_ABONO_CIERREDIA.Ref_Banco = strNumRef

            '    oZBAPI_ABONO_CIERREDIA.ClaCobr = "EFECTIVO".PadRight(9, " ")

            '    dsBanco = Me.BancoSel(oZBAPI_ABONO_CIERREDIA.Tienda, oZBAPI_ABONO_CIERREDIA.ClaCobr)
            '    If dsBanco.Tables(0).Rows.Count > 0 Then
            '        oZBAPI_ABONO_CIERREDIA.Banco = dsBanco.Tables(0).Rows(0).Item("Banco")
            '    Else
            '        oZBAPI_ABONO_CIERREDIA.Banco = ""
            '    End If

            '    oZBAPI_ABONO_CIERREDIA.i_FactDpPro = "X"

            '    oZBAPI_ABONO_CIERREDIA.i_Mode = "N"


            '    fecha = CStr(CDate(dvTarjetaUno(intIndex)("Fecha")).ToShortDateString.Replace("/", ""))
            '    oZBAPI_ABONO_CIERREDIA.Fecha = Mid(fecha, 5, 4) & Mid(fecha, 3, 2) & Mid(fecha, 1, 2)
            '    oZBAPI_ABONO_CIERREDIA.Importe = CStr(dvTarjetaUno(intIndex)("Monto")).PadRight(16, " ")
            '    oZBAPI_ABONO_CIERREDIA.vBeln = CStr(dvTarjetaUno(intIndex)("FolioSAP")).PadLeft(10, "0")

            '    oProcesosSAPMgr = New ProcesoSAPManager(Me.oParent.ApplicationContext, Me.oParent.SAPApplicationConfig)
            '    strResult = oProcesosSAPMgr.WRITE_ZBAPI_ABONO_CIERREDIA(oZBAPI_ABONO_CIERREDIA, dt)

            '    If strResult = "Y" Then
            '        'actualizar el campo FI05SAP
            '        FacturaFI05ok(oZBAPI_ABONO_CIERREDIA.vBeln, oZBAPI_ABONO_CIERREDIA.ClaCobr)
            '    Else
            '        strMensaje += "FolioSAP: " & oZBAPI_ABONO_CIERREDIA.vBeln & vbCrLf
            '        For Each orow As DataRow In dt.Rows
            '            strMensaje += "Error: " & orow.Item("Message") & vbCrLf
            '        Next
            '        strMensaje += vbCrLf

            '        sm_GenerateFileTxtUp = "N"
            '    End If

            '    strResult = ""

            '    'strEncabezado = "40" & "EFECTIVO".PadRight(9, " ") & CStr(dvTarjetaUno(intIndex)("Tienda")).PadRight(20, " ") & _
            '    '                  CStr(Format(dvTarjetaUno(intIndex)("Monto"), "##########.#0")).PadLeft(16, " ") & _
            '    '                  CStr("121000001").PadLeft(10, "0") & strNumRef
            '    'txtWriter.WriteLine(strEncabezado)
            '    'txtWriter.WriteLine("11" & CStr(dvTarjetaUno(intIndex)("FolioSAP")).PadLeft(10, "0") & CStr(dvTarjetaUno(intIndex)("Monto")).PadRight(16, " ") & "Venta Dia " & CDate(dvTarjetaUno(intIndex)("Fecha")).ToShortDateString.Replace("/", "") & CStr(dvTarjetaUno(intIndex)("ClienteID")).PadLeft(10, "0"))
            'Next

            ''Tarjeta 1
            'dvTarjetaUno.RowFilter = "CodBanco like 'T1' and CodTipoVenta='S'"

            'For intIndex = 0 To dvTarjetaUno.Count - 1
            '    dt = New DataTable
            '    oZBAPI_ABONO_CIERREDIA = New ZBapiAbonoCierreDia

            '    oZBAPI_ABONO_CIERREDIA.Tienda = CStr(dvTarjetaUno(intIndex)("Tienda")).PadRight(20, " ")

            '    oZBAPI_ABONO_CIERREDIA.Cliente = CStr(dvTarjetaUno(intIndex)("ClienteID")).PadLeft(10, "0")

            '    oZBAPI_ABONO_CIERREDIA.Detalle = "X"

            '    'oZBAPI_ABONO_CIERREDIA.Ref_Banco = strNumRefBBV & FechaCierre.ToShortDateString.Replace("/", "")
            '    If CStr(dvTarjetaUno(0)("NoAfiliacion")).Length > 6 Then
            '        strNumRefBBV = Mid(CStr(dvTarjetaUno(intIndex)("NoAfiliacion")), 2)
            '    Else
            '        strNumRefBBV = CStr(dvTarjetaUno(intIndex)("NoAfiliacion")).PadLeft(6, "0")
            '    End If
            '    oZBAPI_ABONO_CIERREDIA.Ref_Banco = strNumRefBBV & Format(FechaRefBancos, "ddMMyyyy")

            '    oZBAPI_ABONO_CIERREDIA.ClaCobr = "TARJETA 1".PadRight(9, " ")

            '    dsBanco = Me.BancoSel(oZBAPI_ABONO_CIERREDIA.Tienda, oZBAPI_ABONO_CIERREDIA.ClaCobr)
            '    If dsBanco.Tables(0).Rows.Count > 0 Then
            '        oZBAPI_ABONO_CIERREDIA.Banco = dsBanco.Tables(0).Rows(0).Item("Banco")
            '    Else
            '        oZBAPI_ABONO_CIERREDIA.Banco = ""
            '    End If

            '    oZBAPI_ABONO_CIERREDIA.i_FactDpPro = "X"

            '    oZBAPI_ABONO_CIERREDIA.i_Mode = "N"


            '    fecha = CStr(CDate(dvTarjetaUno(intIndex)("Fecha")).ToShortDateString.Replace("/", ""))
            '    oZBAPI_ABONO_CIERREDIA.Fecha = Mid(fecha, 5, 4) & Mid(fecha, 3, 2) & Mid(fecha, 1, 2)
            '    oZBAPI_ABONO_CIERREDIA.Importe = CStr(dvTarjetaUno(intIndex)("Monto")).PadRight(16, " ")
            '    oZBAPI_ABONO_CIERREDIA.vBeln = CStr(dvTarjetaUno(intIndex)("FolioSAP")).PadLeft(10, "0")

            '    oProcesosSAPMgr = New ProcesoSAPManager(Me.oParent.ApplicationContext, Me.oParent.SAPApplicationConfig)
            '    strResult = oProcesosSAPMgr.WRITE_ZBAPI_ABONO_CIERREDIA(oZBAPI_ABONO_CIERREDIA, dt)

            '    If strResult = "Y" Then
            '        'actualizar el campo FI05SAP
            '        FacturaFI05ok(oZBAPI_ABONO_CIERREDIA.vBeln, oZBAPI_ABONO_CIERREDIA.ClaCobr)
            '    Else
            '        strMensaje += "FolioSAP: " & oZBAPI_ABONO_CIERREDIA.vBeln & vbCrLf
            '        For Each orow As DataRow In dt.Rows
            '            strMensaje += "Error: " & orow.Item("Message") & vbCrLf
            '        Next
            '        strMensaje += vbCrLf

            '        sm_GenerateFileTxtUp = "N"
            '    End If

            '    strResult = ""


            '    'strEncabezado = "40" & "TARJETA 1".PadRight(9, " ") & CStr(dvTarjetaUno(intIndex)("Tienda")).PadRight(20, " ") & _
            '    '                  CStr(Format(dvTarjetaUno(intIndex)("Monto"), "##########.#0")).PadLeft(16, " ") & _
            '    '                  CStr("121000001").PadLeft(10, "0") & "    " & FechaCierre.ToShortDateString.Replace("/", "")
            '    'txtWriter.WriteLine(strEncabezado)
            '    'txtWriter.WriteLine("11" & CStr(dvTarjetaUno(intIndex)("FolioSAP")).PadLeft(10, "0") & CStr(dvTarjetaUno(intIndex)("Monto")).PadRight(16, " ") & "Venta Dia " & CDate(dvTarjetaUno(intIndex)("Fecha")).ToShortDateString.Replace("/", "") & CStr(dvTarjetaUno(intIndex)("ClienteID")).PadLeft(10, "0"))
            'Next

            ''Tarjeta 2
            'dvTarjetaUno.RowFilter = "CodBanco like 'T2' and CodTipoVenta='S'"

            'For intIndex = 0 To dvTarjetaUno.Count - 1
            '    dt = New DataTable
            '    oZBAPI_ABONO_CIERREDIA = New ZBapiAbonoCierreDia

            '    oZBAPI_ABONO_CIERREDIA.Tienda = CStr(dvTarjetaUno(intIndex)("Tienda")).PadRight(20, " ")

            '    oZBAPI_ABONO_CIERREDIA.Cliente = CStr(dvTarjetaUno(intIndex)("ClienteID")).PadLeft(10, "0")

            '    oZBAPI_ABONO_CIERREDIA.Detalle = "X"

            '    'oZBAPI_ABONO_CIERREDIA.Ref_Banco = "    " & FechaCierre.ToShortDateString.Replace("/", "")
            '    strNumRefBBV = CStr(dvTarjetaUno(intIndex)("NoAfiliacion"))
            '    oZBAPI_ABONO_CIERREDIA.Ref_Banco = strNumRefBBV & Format(FechaRefBancos, "ddMMyy")

            '    oZBAPI_ABONO_CIERREDIA.ClaCobr = "TARJETA 2".PadRight(9, " ")

            '    dsBanco = Me.BancoSel(oZBAPI_ABONO_CIERREDIA.Tienda, oZBAPI_ABONO_CIERREDIA.ClaCobr)
            '    If dsBanco.Tables(0).Rows.Count > 0 Then
            '        oZBAPI_ABONO_CIERREDIA.Banco = dsBanco.Tables(0).Rows(0).Item("Banco")
            '    Else
            '        oZBAPI_ABONO_CIERREDIA.Banco = ""
            '    End If

            '    oZBAPI_ABONO_CIERREDIA.i_FactDpPro = "X"

            '    oZBAPI_ABONO_CIERREDIA.i_Mode = "N"


            '    fecha = CStr(CDate(dvTarjetaUno(intIndex)("Fecha")).ToShortDateString.Replace("/", ""))
            '    oZBAPI_ABONO_CIERREDIA.Fecha = Mid(fecha, 5, 4) & Mid(fecha, 3, 2) & Mid(fecha, 1, 2)
            '    oZBAPI_ABONO_CIERREDIA.Importe = CStr(dvTarjetaUno(intIndex)("Monto")).PadRight(16, " ")
            '    oZBAPI_ABONO_CIERREDIA.vBeln = CStr(dvTarjetaUno(intIndex)("FolioSAP")).PadLeft(10, "0")

            '    oProcesosSAPMgr = New ProcesoSAPManager(Me.oParent.ApplicationContext, Me.oParent.SAPApplicationConfig)
            '    strResult = oProcesosSAPMgr.WRITE_ZBAPI_ABONO_CIERREDIA(oZBAPI_ABONO_CIERREDIA, dt)

            '    If strResult = "Y" Then
            '        'actualizar el campo FI05SAP
            '        FacturaFI05ok(oZBAPI_ABONO_CIERREDIA.vBeln, oZBAPI_ABONO_CIERREDIA.ClaCobr)
            '    Else
            '        strMensaje += "FolioSAP: " & oZBAPI_ABONO_CIERREDIA.vBeln & vbCrLf
            '        For Each orow As DataRow In dt.Rows
            '            strMensaje += "Error: " & orow.Item("Message") & vbCrLf
            '        Next
            '        strMensaje += vbCrLf

            '        sm_GenerateFileTxtUp = "N"
            '    End If

            '    strResult = ""


            '    'strEncabezado = "40" & "TARJETA 2".PadRight(9, " ") & CStr(dvTarjetaUno(intIndex)("Tienda")).PadRight(20, " ") & _
            '    '                  CStr(Format(dvTarjetaUno(intIndex)("Monto"), "##########.#0")).PadLeft(16, " ") & _
            '    '                  CStr("121000001").PadRight(10, "0") & "    " & FechaCierre.ToShortDateString.Replace("/", "")
            '    'txtWriter.WriteLine(strEncabezado)
            '    'txtWriter.WriteLine("11" & CStr(dvTarjetaUno(intIndex)("FolioSAP")).PadLeft(10, "0") & CStr(dvTarjetaUno(intIndex)("Monto")).PadRight(16, " ") & "Venta Dia " & CDate(dvTarjetaUno(intIndex)("Fecha")).ToShortDateString.Replace("/", "") & CStr(dvTarjetaUno(intIndex)("ClienteID")).PadLeft(10, "0"))
            'Next

            ''Tarjeta 3
            'dvTarjetaUno.RowFilter = "CodBanco like 'T3' and CodTipoVenta='S'"

            'For intIndex = 0 To dvTarjetaUno.Count - 1
            '    dt = New DataTable
            '    oZBAPI_ABONO_CIERREDIA = New ZBapiAbonoCierreDia

            '    oZBAPI_ABONO_CIERREDIA.Tienda = CStr(dvTarjetaUno(intIndex)("Tienda")).PadRight(20, " ")

            '    oZBAPI_ABONO_CIERREDIA.Cliente = CStr(dvTarjetaUno(intIndex)("ClienteID")).PadLeft(10, "0")

            '    oZBAPI_ABONO_CIERREDIA.Detalle = "X"

            '    'oZBAPI_ABONO_CIERREDIA.Ref_Banco = "    " & FechaCierre.ToShortDateString.Replace("/", "")
            '    strNumRefBBV = CStr(dvTarjetaUno(intIndex)("NoAfiliacion"))
            '    oZBAPI_ABONO_CIERREDIA.Ref_Banco = strNumRefBBV & Format(FechaRefBancos, "ddMMyy")

            '    oZBAPI_ABONO_CIERREDIA.ClaCobr = "TARJETA 3".PadRight(9, " ")

            '    dsBanco = Me.BancoSel(oZBAPI_ABONO_CIERREDIA.Tienda, oZBAPI_ABONO_CIERREDIA.ClaCobr)
            '    If dsBanco.Tables(0).Rows.Count > 0 Then
            '        oZBAPI_ABONO_CIERREDIA.Banco = dsBanco.Tables(0).Rows(0).Item("Banco")
            '    Else
            '        oZBAPI_ABONO_CIERREDIA.Banco = ""
            '    End If

            '    oZBAPI_ABONO_CIERREDIA.i_FactDpPro = "X"

            '    oZBAPI_ABONO_CIERREDIA.i_Mode = "N"


            '    fecha = CStr(CDate(dvTarjetaUno(intIndex)("Fecha")).ToShortDateString.Replace("/", ""))
            '    oZBAPI_ABONO_CIERREDIA.Fecha = Mid(fecha, 5, 4) & Mid(fecha, 3, 2) & Mid(fecha, 1, 2)
            '    oZBAPI_ABONO_CIERREDIA.Importe = CStr(dvTarjetaUno(intIndex)("Monto")).PadRight(16, " ")
            '    oZBAPI_ABONO_CIERREDIA.vBeln = CStr(dvTarjetaUno(intIndex)("FolioSAP")).PadLeft(10, "0")

            '    oProcesosSAPMgr = New ProcesoSAPManager(Me.oParent.ApplicationContext, Me.oParent.SAPApplicationConfig)
            '    strResult = oProcesosSAPMgr.WRITE_ZBAPI_ABONO_CIERREDIA(oZBAPI_ABONO_CIERREDIA, dt)

            '    If strResult = "Y" Then
            '        'actualizar el campo FI05SAP
            '        FacturaFI05ok(oZBAPI_ABONO_CIERREDIA.vBeln, oZBAPI_ABONO_CIERREDIA.ClaCobr)
            '    Else
            '        strMensaje += "FolioSAP: " & oZBAPI_ABONO_CIERREDIA.vBeln & vbCrLf
            '        For Each orow As DataRow In dt.Rows
            '            strMensaje += "Error: " & orow.Item("Message") & vbCrLf
            '        Next
            '        strMensaje += vbCrLf

            '        sm_GenerateFileTxtUp = "N"
            '    End If

            '    strResult = ""

            '    'strEncabezado = "40" & "TARJETA 3".PadRight(9, " ") & CStr(dvTarjetaUno(intIndex)("Tienda")).PadRight(20, " ") & _
            '    '                  CStr(Format(dvTarjetaUno(intIndex)("Monto"), "##########.#0")).PadLeft(16, " ") & _
            '    '                  CStr("121000001").PadRight(10, "0") & "    " & FechaCierre.ToShortDateString.Replace("/", "")
            '    'txtWriter.WriteLine(strEncabezado)
            '    'txtWriter.WriteLine("11" & CStr(dvTarjetaUno(intIndex)("FolioSAP")).PadLeft(10, "0") & CStr(dvTarjetaUno(intIndex)("Monto")).PadRight(16, " ") & "Venta Dia " & CDate(dvTarjetaUno(intIndex)("Fecha")).ToShortDateString.Replace("/", "") & CStr(dvTarjetaUno(intIndex)("ClienteID")).PadLeft(10, "0"))
            'Next

            ''----------------------------------------------------------------------------------------------------------------
            '' JNAVA (19.03.2015): Generamos el TXT de los Pagos DP CARD - SOCIOS 053
            ''----------------------------------------------------------------------------------------------------------------
            'strCliente = String.Empty
            'sm_GenerateFileTxtUp = GetCobranzaDPCard(dvTarjetaUno, strCliente, "S", FechaCierre, strNumRef, strNumRefBBV, sm_GenerateFileTxtUp, strMensaje)
            ''---------------------------------------------------------------------------------------------------------------------------------
            ''RGERMAIN 15.05.2015: Subimos los pagos con DPCard Puntos a SAP en las ventas de Socios
            ''---------------------------------------------------------------------------------------------------------------------------------
            'strMensaje &= RegistraPagosDPCardPuntosSAP(strCliente, "DPPT", "S", dvTarjetaUno, strNumRef, sm_GenerateFileTxtUp)

            ''*********************************FACTURACION FISCAL ******************************
            ''Efectivo
            'dvTarjetaUno.RowFilter = "CodFormasPago like 'EFEC' and CodTipoVenta='I'"

            'For intIndex = 0 To dvTarjetaUno.Count - 1
            '    dt = New DataTable
            '    oZBAPI_ABONO_CIERREDIA = New ZBapiAbonoCierreDia

            '    oZBAPI_ABONO_CIERREDIA.Tienda = CStr(dvTarjetaUno(intIndex)("Tienda")).PadRight(20, " ")

            '    oZBAPI_ABONO_CIERREDIA.Cliente = CStr(dvTarjetaUno(intIndex)("ClienteID")).PadLeft(10, "0")

            '    oZBAPI_ABONO_CIERREDIA.Detalle = "X"

            '    oZBAPI_ABONO_CIERREDIA.Ref_Banco = strNumRef

            '    oZBAPI_ABONO_CIERREDIA.ClaCobr = "EFECTIVO".PadRight(9, " ")

            '    dsBanco = Me.BancoSel(oZBAPI_ABONO_CIERREDIA.Tienda, oZBAPI_ABONO_CIERREDIA.ClaCobr)
            '    If dsBanco.Tables(0).Rows.Count > 0 Then
            '        oZBAPI_ABONO_CIERREDIA.Banco = dsBanco.Tables(0).Rows(0).Item("Banco")
            '    Else
            '        oZBAPI_ABONO_CIERREDIA.Banco = ""
            '    End If

            '    oZBAPI_ABONO_CIERREDIA.i_FactDpPro = "X"

            '    oZBAPI_ABONO_CIERREDIA.i_Mode = "N"


            '    fecha = CStr(CDate(dvTarjetaUno(intIndex)("Fecha")).ToShortDateString.Replace("/", ""))
            '    oZBAPI_ABONO_CIERREDIA.Fecha = Mid(fecha, 5, 4) & Mid(fecha, 3, 2) & Mid(fecha, 1, 2)
            '    oZBAPI_ABONO_CIERREDIA.Importe = CStr(dvTarjetaUno(intIndex)("Monto")).PadRight(16, " ")
            '    oZBAPI_ABONO_CIERREDIA.vBeln = CStr(dvTarjetaUno(intIndex)("FolioSAP")).PadLeft(10, "0")

            '    oProcesosSAPMgr = New ProcesoSAPManager(Me.oParent.ApplicationContext, Me.oParent.SAPApplicationConfig)
            '    strResult = oProcesosSAPMgr.WRITE_ZBAPI_ABONO_CIERREDIA(oZBAPI_ABONO_CIERREDIA, dt)

            '    If strResult = "Y" Then
            '        'actualizar el campo FI05SAP
            '        FacturaFI05ok(oZBAPI_ABONO_CIERREDIA.vBeln, oZBAPI_ABONO_CIERREDIA.ClaCobr)
            '    Else
            '        strMensaje += "FolioSAP: " & oZBAPI_ABONO_CIERREDIA.vBeln & vbCrLf
            '        For Each orow As DataRow In dt.Rows
            '            strMensaje += "Error: " & orow.Item("Message") & vbCrLf
            '        Next
            '        strMensaje += vbCrLf

            '        sm_GenerateFileTxtUp = "N"
            '    End If

            '    strResult = ""

            '    'strEncabezado = "40" & "EFECTIVO".PadRight(9, " ") & CStr(dvTarjetaUno(intIndex)("Tienda")).PadRight(20, " ") & _
            '    '                  CStr(Format(dvTarjetaUno(intIndex)("Monto"), "##########.#0")).PadLeft(16, " ") & _
            '    '                  CStr("121000001").PadLeft(10, "0") & strNumRef
            '    'txtWriter.WriteLine(strEncabezado)
            '    'txtWriter.WriteLine("11" & CStr(dvTarjetaUno(intIndex)("FolioSAP")).PadLeft(10, "0") & CStr(dvTarjetaUno(intIndex)("Monto")).PadRight(16, " ") & "Venta Dia " & CDate(dvTarjetaUno(intIndex)("Fecha")).ToShortDateString.Replace("/", "") & CStr(dvTarjetaUno(intIndex)("ClienteID")).PadLeft(10, "0"))
            'Next

            ''Tarjeta 1
            'dvTarjetaUno.RowFilter = "CodBanco like 'T1' and CodTipoVenta='I'"

            'For intIndex = 0 To dvTarjetaUno.Count - 1
            '    dt = New DataTable
            '    oZBAPI_ABONO_CIERREDIA = New ZBapiAbonoCierreDia

            '    oZBAPI_ABONO_CIERREDIA.Tienda = CStr(dvTarjetaUno(intIndex)("Tienda")).PadRight(20, " ")

            '    oZBAPI_ABONO_CIERREDIA.Cliente = CStr(dvTarjetaUno(intIndex)("ClienteID")).PadLeft(10, "0")

            '    oZBAPI_ABONO_CIERREDIA.Detalle = "X"

            '    'oZBAPI_ABONO_CIERREDIA.Ref_Banco = strNumRefBBV & FechaCierre.ToShortDateString.Replace("/", "")
            '    If CStr(dvTarjetaUno(0)("NoAfiliacion")).Length > 6 Then
            '        strNumRefBBV = Mid(CStr(dvTarjetaUno(intIndex)("NoAfiliacion")), 2)
            '    Else
            '        strNumRefBBV = CStr(dvTarjetaUno(intIndex)("NoAfiliacion")).PadLeft(6, "0")
            '    End If
            '    oZBAPI_ABONO_CIERREDIA.Ref_Banco = strNumRefBBV & Format(FechaRefBancos, "ddMMyyyy")

            '    oZBAPI_ABONO_CIERREDIA.ClaCobr = "TARJETA 1".PadRight(9, " ")

            '    dsBanco = Me.BancoSel(oZBAPI_ABONO_CIERREDIA.Tienda, oZBAPI_ABONO_CIERREDIA.ClaCobr)
            '    If dsBanco.Tables(0).Rows.Count > 0 Then
            '        oZBAPI_ABONO_CIERREDIA.Banco = dsBanco.Tables(0).Rows(0).Item("Banco")
            '    Else
            '        oZBAPI_ABONO_CIERREDIA.Banco = ""
            '    End If

            '    oZBAPI_ABONO_CIERREDIA.i_FactDpPro = "X"

            '    oZBAPI_ABONO_CIERREDIA.i_Mode = "N"


            '    fecha = CStr(CDate(dvTarjetaUno(intIndex)("Fecha")).ToShortDateString.Replace("/", ""))
            '    oZBAPI_ABONO_CIERREDIA.Fecha = Mid(fecha, 5, 4) & Mid(fecha, 3, 2) & Mid(fecha, 1, 2)
            '    oZBAPI_ABONO_CIERREDIA.Importe = CStr(dvTarjetaUno(intIndex)("Monto")).PadRight(16, " ")
            '    oZBAPI_ABONO_CIERREDIA.vBeln = CStr(dvTarjetaUno(intIndex)("FolioSAP")).PadLeft(10, "0")

            '    oProcesosSAPMgr = New ProcesoSAPManager(Me.oParent.ApplicationContext, Me.oParent.SAPApplicationConfig)
            '    strResult = oProcesosSAPMgr.WRITE_ZBAPI_ABONO_CIERREDIA(oZBAPI_ABONO_CIERREDIA, dt)

            '    If strResult = "Y" Then
            '        'actualizar el campo FI05SAP
            '        FacturaFI05ok(oZBAPI_ABONO_CIERREDIA.vBeln, oZBAPI_ABONO_CIERREDIA.ClaCobr)
            '    Else
            '        strMensaje += "FolioSAP: " & oZBAPI_ABONO_CIERREDIA.vBeln & vbCrLf
            '        For Each orow As DataRow In dt.Rows
            '            strMensaje += "Error: " & orow.Item("Message") & vbCrLf
            '        Next
            '        strMensaje += vbCrLf

            '        sm_GenerateFileTxtUp = "N"
            '    End If

            '    strResult = ""

            '    'strEncabezado = "40" & "TARJETA 1".PadRight(9, " ") & CStr(dvTarjetaUno(intIndex)("Tienda")).PadRight(20, " ") & _
            '    '                  CStr(Format(dvTarjetaUno(intIndex)("Monto"), "##########.#0")).PadLeft(16, " ") & _
            '    '                  CStr("121000001").PadLeft(10, "0") & "    " & FechaCierre.ToShortDateString.Replace("/", "")
            '    'txtWriter.WriteLine(strEncabezado)
            '    'txtWriter.WriteLine("11" & CStr(dvTarjetaUno(intIndex)("FolioSAP")).PadLeft(10, "0") & CStr(dvTarjetaUno(intIndex)("Monto")).PadRight(16, " ") & "Venta Dia " & CDate(dvTarjetaUno(intIndex)("Fecha")).ToShortDateString.Replace("/", "") & CStr(dvTarjetaUno(intIndex)("ClienteID")).PadLeft(10, "0"))
            'Next

            ''Tarjeta 2
            'dvTarjetaUno.RowFilter = "CodBanco like 'T2' and CodTipoVenta='I'"

            'For intIndex = 0 To dvTarjetaUno.Count - 1
            '    dt = New DataTable
            '    oZBAPI_ABONO_CIERREDIA = New ZBapiAbonoCierreDia

            '    oZBAPI_ABONO_CIERREDIA.Tienda = CStr(dvTarjetaUno(intIndex)("Tienda")).PadRight(20, " ")

            '    oZBAPI_ABONO_CIERREDIA.Cliente = CStr(dvTarjetaUno(intIndex)("ClienteID")).PadLeft(10, "0")

            '    oZBAPI_ABONO_CIERREDIA.Detalle = "X"

            '    'oZBAPI_ABONO_CIERREDIA.Ref_Banco = "    " & FechaCierre.ToShortDateString.Replace("/", "")
            '    strNumRefBBV = CStr(dvTarjetaUno(intIndex)("NoAfiliacion"))
            '    oZBAPI_ABONO_CIERREDIA.Ref_Banco = strNumRefBBV & Format(FechaRefBancos, "ddMMyy")

            '    oZBAPI_ABONO_CIERREDIA.ClaCobr = "TARJETA 2".PadRight(9, " ")

            '    dsBanco = Me.BancoSel(oZBAPI_ABONO_CIERREDIA.Tienda, oZBAPI_ABONO_CIERREDIA.ClaCobr)
            '    If dsBanco.Tables(0).Rows.Count > 0 Then
            '        oZBAPI_ABONO_CIERREDIA.Banco = dsBanco.Tables(0).Rows(0).Item("Banco")
            '    Else
            '        oZBAPI_ABONO_CIERREDIA.Banco = ""
            '    End If

            '    oZBAPI_ABONO_CIERREDIA.i_FactDpPro = "X"

            '    oZBAPI_ABONO_CIERREDIA.i_Mode = "N"


            '    fecha = CStr(CDate(dvTarjetaUno(intIndex)("Fecha")).ToShortDateString.Replace("/", ""))
            '    oZBAPI_ABONO_CIERREDIA.Fecha = Mid(fecha, 5, 4) & Mid(fecha, 3, 2) & Mid(fecha, 1, 2)
            '    oZBAPI_ABONO_CIERREDIA.Importe = CStr(dvTarjetaUno(intIndex)("Monto")).PadRight(16, " ")
            '    oZBAPI_ABONO_CIERREDIA.vBeln = CStr(dvTarjetaUno(intIndex)("FolioSAP")).PadLeft(10, "0")

            '    oProcesosSAPMgr = New ProcesoSAPManager(Me.oParent.ApplicationContext, Me.oParent.SAPApplicationConfig)
            '    strResult = oProcesosSAPMgr.WRITE_ZBAPI_ABONO_CIERREDIA(oZBAPI_ABONO_CIERREDIA, dt)

            '    If strResult = "Y" Then
            '        'actualizar el campo FI05SAP
            '        FacturaFI05ok(oZBAPI_ABONO_CIERREDIA.vBeln, oZBAPI_ABONO_CIERREDIA.ClaCobr)
            '    Else
            '        strMensaje += "FolioSAP: " & oZBAPI_ABONO_CIERREDIA.vBeln & vbCrLf
            '        For Each orow As DataRow In dt.Rows
            '            strMensaje += "Error: " & orow.Item("Message") & vbCrLf
            '        Next
            '        strMensaje += vbCrLf

            '        sm_GenerateFileTxtUp = "N"
            '    End If

            '    strResult = ""

            '    'strEncabezado = "40" & "TARJETA 2".PadRight(9, " ") & CStr(dvTarjetaUno(intIndex)("Tienda")).PadRight(20, " ") & _
            '    '                  CStr(Format(dvTarjetaUno(intIndex)("Monto"), "##########.#0")).PadLeft(16, " ") & _
            '    '                  CStr("121000001").PadRight(10, "0") & "    " & FechaCierre.ToShortDateString.Replace("/", "")
            '    'txtWriter.WriteLine(strEncabezado)
            '    'txtWriter.WriteLine("11" & CStr(dvTarjetaUno(intIndex)("FolioSAP")).PadLeft(10, "0") & CStr(dvTarjetaUno(intIndex)("Monto")).PadRight(16, " ") & "Venta Dia " & CDate(dvTarjetaUno(intIndex)("Fecha")).ToShortDateString.Replace("/", "") & CStr(dvTarjetaUno(intIndex)("ClienteID")).PadLeft(10, "0"))
            'Next

            ''Tarjeta 3
            'dvTarjetaUno.RowFilter = "CodBanco like 'T3' and CodTipoVenta='I'"

            'For intIndex = 0 To dvTarjetaUno.Count - 1
            '    dt = New DataTable
            '    oZBAPI_ABONO_CIERREDIA = New ZBapiAbonoCierreDia

            '    oZBAPI_ABONO_CIERREDIA.Tienda = CStr(dvTarjetaUno(intIndex)("Tienda")).PadRight(20, " ")

            '    oZBAPI_ABONO_CIERREDIA.Cliente = CStr(dvTarjetaUno(intIndex)("ClienteID")).PadLeft(10, "0")

            '    oZBAPI_ABONO_CIERREDIA.Detalle = "X"

            '    'oZBAPI_ABONO_CIERREDIA.Ref_Banco = "    " & FechaCierre.ToShortDateString.Replace("/", "")
            '    strNumRefBBV = CStr(dvTarjetaUno(intIndex)("NoAfiliacion"))
            '    oZBAPI_ABONO_CIERREDIA.Ref_Banco = strNumRefBBV & Format(FechaRefBancos, "ddMMyy")

            '    oZBAPI_ABONO_CIERREDIA.ClaCobr = "TARJETA 3".PadRight(9, " ")

            '    dsBanco = Me.BancoSel(oZBAPI_ABONO_CIERREDIA.Tienda, oZBAPI_ABONO_CIERREDIA.ClaCobr)
            '    If dsBanco.Tables(0).Rows.Count > 0 Then
            '        oZBAPI_ABONO_CIERREDIA.Banco = dsBanco.Tables(0).Rows(0).Item("Banco")
            '    Else
            '        oZBAPI_ABONO_CIERREDIA.Banco = ""
            '    End If

            '    oZBAPI_ABONO_CIERREDIA.i_FactDpPro = "X"

            '    oZBAPI_ABONO_CIERREDIA.i_Mode = "N"


            '    fecha = CStr(CDate(dvTarjetaUno(intIndex)("Fecha")).ToShortDateString.Replace("/", ""))
            '    oZBAPI_ABONO_CIERREDIA.Fecha = Mid(fecha, 5, 4) & Mid(fecha, 3, 2) & Mid(fecha, 1, 2)
            '    oZBAPI_ABONO_CIERREDIA.Importe = CStr(dvTarjetaUno(intIndex)("Monto")).PadRight(16, " ")
            '    oZBAPI_ABONO_CIERREDIA.vBeln = CStr(dvTarjetaUno(intIndex)("FolioSAP")).PadLeft(10, "0")

            '    oProcesosSAPMgr = New ProcesoSAPManager(Me.oParent.ApplicationContext, Me.oParent.SAPApplicationConfig)
            '    strResult = oProcesosSAPMgr.WRITE_ZBAPI_ABONO_CIERREDIA(oZBAPI_ABONO_CIERREDIA, dt)

            '    If strResult = "Y" Then
            '        'actualizar el campo FI05SAP
            '        FacturaFI05ok(oZBAPI_ABONO_CIERREDIA.vBeln, oZBAPI_ABONO_CIERREDIA.ClaCobr)
            '    Else
            '        strMensaje += "FolioSAP: " & oZBAPI_ABONO_CIERREDIA.vBeln & vbCrLf
            '        For Each orow As DataRow In dt.Rows
            '            strMensaje += "Error: " & orow.Item("Message") & vbCrLf
            '        Next
            '        strMensaje += vbCrLf

            '        sm_GenerateFileTxtUp = "N"
            '    End If

            '    strResult = ""


            '    'strEncabezado = "40" & "TARJETA 3".PadRight(9, " ") & CStr(dvTarjetaUno(intIndex)("Tienda")).PadRight(20, " ") & _
            '    '                  CStr(Format(dvTarjetaUno(intIndex)("Monto"), "##########.#0")).PadLeft(16, " ") & _
            '    '                  CStr("121000001").PadRight(10, "0") & "    " & FechaCierre.ToShortDateString.Replace("/", "")
            '    'txtWriter.WriteLine(strEncabezado)
            '    'txtWriter.WriteLine("11" & CStr(dvTarjetaUno(intIndex)("FolioSAP")).PadLeft(10, "0") & CStr(dvTarjetaUno(intIndex)("Monto")).PadRight(16, " ") & "Venta Dia " & CDate(dvTarjetaUno(intIndex)("Fecha")).ToShortDateString.Replace("/", "") & CStr(dvTarjetaUno(intIndex)("ClienteID")).PadLeft(10, "0"))
            'Next

            ''----------------------------------------------------------------------------------------------------------------
            '' JNAVA (19.03.2015): Generamos el TXT de los Pagos DP CARD - Facturacion Fiscal
            ''----------------------------------------------------------------------------------------------------------------
            'strCliente = String.Empty
            'sm_GenerateFileTxtUp = GetCobranzaDPCard(dvTarjetaUno, strCliente, "I", FechaCierre, strNumRef, strNumRefBBV, sm_GenerateFileTxtUp, strMensaje)
            ''---------------------------------------------------------------------------------------------------------------------------------
            ''RGERMAIN 15.05.2015: Subimos los pagos con DPCard Puntos a SAP en las ventas de Facturacion Fiscal
            ''---------------------------------------------------------------------------------------------------------------------------------
            'strMensaje &= RegistraPagosDPCardPuntosSAP(strCliente, "DPPT", "I", dvTarjetaUno, strNumRef, sm_GenerateFileTxtUp)

            ''txtWriter.Close()


            ''txtWriter = Nothing

            'oMontarURed.Desconecta()
            'oMontarURed.Desconecta()

        Catch ex As Exception
            Throw ex
        End Try
        '        Exit Function
        'MensajeError:
        '        Throw New ApplicationException("Error en la linea " & Err.Erl & vbCrLf & Err.Description)

    End Sub

    'Funcion Vale Caja Up
    Private Function sm_GenerateFileTxtUpVC(ByVal dsVentas As DataSet, ByVal FechaCierre As Date, ByRef strMensaje As String, Optional ByVal VPN As Boolean = True) As String
        sm_GenerateFileTxtUpVC = "S"
        Dim dt As DataTable

        Dim imes As Integer = FechaCierre.Date.Month
        Dim ruta As String
        oDPVale = New cDPVale
        If VPN Then
            ruta = oParent.ConfigSaveArchivos.Ruta & "\" & Mid(oParent.ApplicationContext.ApplicationConfiguration.Almacen, 2, 2) & "\" & GetMes(imes) & "\"
        Else
            ruta = "C:\VTAS\" & GetMes(imes) & "\"
        End If

        Try
            If dsVentas.Tables(0).Rows.Count = 0 Or dsVentas Is Nothing Then
                Exit Function
            End If

            ''DataView para las ventas
            Dim dvTarjetaUno As New DataView(dsVentas.Tables(0))
            Dim intIndex As Integer
            Dim strEncabezado As String

            Dim strResult As String = ""
            Dim fecha As String = ""
            Dim strClienteDV As String = ""
            Dim strClienteVT As String = ""
            Dim strDocFI As String = ""
            Dim strDocFITS As String = ""
            Dim bFI05SAP As Boolean = False
            Dim bCompensado As Boolean = False

            If dsVentas.Tables(0).Rows.Count > 0 Then
                dt = New DataTable

                For intIndex = 0 To dsVentas.Tables(0).Rows.Count - 1
                    fecha = CStr(CDate(dsVentas.Tables(0).Rows(intIndex)("Fecha")).ToShortDateString.Replace("/", "."))

                    oProcesosSAPMgr = New ProcesoSAPManager(Me.oParent.ApplicationContext, Me.oParent.SAPApplicationConfig)
                    'Saco el Cliente de la venta
                    Select Case dsVentas.Tables(0).Rows(intIndex)("CodTipoVentaVT")
                        Case "P"
                            strClienteVT = Me.oParent.ApplicationContext.ApplicationConfiguration.Almacen.PadLeft(10, "0")
                        Case "E"
                            strClienteVT = "99999".PadLeft(10, "0")
                        Case "V"
                            If Not Me.oParent.SAPApplicationConfig.DPValeSAP Then
                                'strClienteVT = CStr(GetCodigoSAPAsoc(GetDpValeIDDP(CInt(dsVentas.Tables(0).Rows(intIndex)("FolioReferenciaVT"))))).PadRight(10, " ")
                                strClienteVT = CStr(GetCodigoSAPAsoc(GetDpValeIDDP(CInt(dsVentas.Tables(0).Rows(intIndex)("FacturaID"))))).PadRight(10, " ")
                            Else
                                'Dim strDpValeIDDP As String = CStr(GetDpValeIDDP(CInt(dsVentas.Tables(0).Rows(intIndex)("FolioReferenciaVT"))))
                                Dim strDpValeIDDP As String = CStr(GetDpValeIDDP(CInt(dsVentas.Tables(0).Rows(intIndex)("FacturaID"))))
                                Me.oDPVale.INUMVA = strDpValeIDDP
                                Me.oDPVale.I_RUTA = "X"

                                '--------------------------------------------------------------------------------------------
                                ' JNAVA (02.08.2016): Obtenemos la Info del DPVale 
                                '--------------------------------------------------------------------------------------------
                                'oDPVale = oSAPMgr.ZBAPI_VALIDA_DPVALE(oDPVale)
                                Dim S2Credit As New ProcesosS2Credit(oParent)
                                If oParent.ConfigSaveArchivos.AplicarS2Credit Then
                                    oDPVale = S2Credit.ValidaDPVale(oDPVale)
                                Else
                                    oDPVale = oSAPMgr.ZBAPI_VALIDA_DPVALE(oDPVale)
                                End If
                                '--------------------------------------------------------------------------------------------

                                strClienteVT = CStr(oDPVale.InfoDPVALE.Rows(0).Item("KUNNR")).PadRight(10, " ")
                            End If

                        Case "F"
                            strClienteVT = "0260000000"
                        Case "O"
                            strClienteVT = "0260000001"
                        Case "K"
                            strClienteVT = "0260002268"
                        Case "I", "D", "S"
                            strClienteVT = dsVentas.Tables(0).Rows(intIndex)("ClienteIDVT")
                        Case Else
                            sm_GenerateFileTxtUpVC = "N"
                            'MsgBox("Tipo de venta no Valido" & " FolioFISAP: " & dsVentas.Tables(0).Rows(intIndex)("FolioFISAP"), MsgBoxStyle.Information, "DpTienda")
                            strClienteVT = ""
                            Exit Function

                    End Select
                    'Saco el cliente de la factura devuelta
                    Select Case dsVentas.Tables(0).Rows(intIndex)("CodTipoVentaDV")
                        Case "P"
                            strClienteDV = Me.oParent.ApplicationContext.ApplicationConfiguration.Almacen.PadLeft(10, "0")
                        Case "E"
                            strClienteDV = "99999".PadLeft(10, "0")
                        Case "V"
                            If Not Me.oParent.SAPApplicationConfig.DPValeSAP Then
                                strClienteDV = CStr(GetCodigoSAPAsoc(GetDpValeIDDP(CInt(dsVentas.Tables(0).Rows(intIndex)("FacturaID"))))).PadRight(10, " ")
                            Else
                                Dim strDpValeIDDP As String = CStr(GetDpValeIDDP(CInt(dsVentas.Tables(0).Rows(intIndex)("FacturaID"))))
                                Me.oDPVale.INUMVA = strDpValeIDDP
                                Me.oDPVale.I_RUTA = "X"

                                '--------------------------------------------------------------------------------------------
                                ' JNAVA (02.08.2016): Obtenemos la Info del DPVale 
                                '--------------------------------------------------------------------------------------------
                                'oDPVale = oSAPMgr.ZBAPI_VALIDA_DPVALE(oDPVale)
                                Dim S2Credit As New ProcesosS2Credit(oParent)
                                If oParent.ConfigSaveArchivos.AplicarS2Credit Then
                                    oDPVale = S2Credit.ValidaDPVale(oDPVale)
                                Else
                                    oDPVale = oSAPMgr.ZBAPI_VALIDA_DPVALE(oDPVale)
                                End If
                                '--------------------------------------------------------------------------------------------


                                strClienteDV = CStr(oDPVale.InfoDPVALE.Rows(0).Item("KUNNR")).PadRight(10, " ")
                            End If

                        Case "F"
                            strClienteDV = "0260000000"
                        Case "O"
                            strClienteDV = "0260000001"
                        Case "K"
                            strClienteDV = "0260002268"
                        Case "I", "D", "S", "A"
                            strClienteDV = dsVentas.Tables(0).Rows(intIndex)("ClienteIDDV")
                        Case Else
                            sm_GenerateFileTxtUpVC = "N"
                            'MsgBox("Tipo de venta no Valido" & " FolioFISAP: " & dsVentas.Tables(0).Rows(intIndex)("FolioFISAP"), MsgBoxStyle.Information, "DpTienda")
                            strClienteDV = ""
                            Exit Function

                    End Select

                    strDocFI = CStr(dsVentas.Tables(0).Rows(intIndex)("FIDOCUMENT")).Trim
                    strDocFI = strDocFI.PadLeft(10, "0")

                    strDocFITS = CStr(dsVentas.Tables(0).Rows(intIndex)("FolioFITS")).Trim
                    bFI05SAP = CBool(dsVentas.Tables(0).Rows(intIndex)("FI05SAP"))
                    bCompensado = CBool(dsVentas.Tables(0).Rows(intIndex)("Compensado"))
                    '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    'Compensamos la DR contra el AB del cliente de la factura en caso de que haya habido un traslado de saldos
                    'En caso que no haya habido traslado se compensa la DG contra la DR
                    '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    If bFI05SAP = False Then
                        If strDocFITS.Trim <> "" Then
                            strResult = oProcesosSAPMgr.WRITE_ZBAPI_ABONO_CIERREDIAVC(strClienteVT, fecha, dsVentas.Tables(0).Rows(intIndex)("FolioFISAP"), strClienteVT, strDocFITS, dsVentas.Tables(0).Rows(intIndex)("Monto"), dt)
                        Else
                            '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                            'JNAVA (04/07/2013): Validamos si el registro es del tipo de documento de Si Hay (CF, CP, PI)
                            '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                            If dsVentas.Tables(0).Rows(intIndex)("TipoDocumento") = "CP" OrElse dsVentas.Tables(0).Rows(intIndex)("TipoDocumento") = "CF" OrElse dsVentas.Tables(0).Rows(intIndex)("TipoDocumento") = "PI" Then
                                strResult = oProcesosSAPMgr.WRITE_ZBAPI_ABONO_CIERREDIAVC(strClienteVT, fecha, dsVentas.Tables(0).Rows(intIndex)("FolioFISAP"), strClienteVT, strDocFI, dsVentas.Tables(0).Rows(intIndex)("Monto"), dt)
                            Else 'En caso de que no sea de Si Hay, hace lo que ya hacia antes
                                strResult = oProcesosSAPMgr.WRITE_ZBAPI_ABONO_CIERREDIAVC(strClienteVT, fecha, dsVentas.Tables(0).Rows(intIndex)("FolioFISAP"), strClienteDV, strDocFI, dsVentas.Tables(0).Rows(intIndex)("Monto"), dt)
                            End If
                        End If

                        If Not strResult = "S" Then
                            strMensaje += "FolioFISAP: " & dsVentas.Tables(0).Rows(intIndex)("FolioFISAP") & vbCrLf
                            For Each orow As DataRow In dt.Rows
                                strMensaje += "Error: " & orow.Item("Message") & vbCrLf
                            Next
                            strMensaje += vbCrLf

                            sm_GenerateFileTxtUpVC = "N"
                        Else
                            'actualizar el campo FI05SAP
                            FacturaFI05okVC(dsVentas.Tables(0).Rows(intIndex)("FolioFISAP"))
                        End If
                    End If
                    '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    'Compensamos el DG contra el AB del cliente original de la devolucion en caso de que haya habido un traslado de saldos
                    '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    If strDocFITS.Trim <> "" AndAlso bCompensado = False Then
                        '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                        'JNAVA (04/07/2013): Validamos si el registro es del tipo de documento de Si Hay (CF, CP, PI)
                        '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                        If dsVentas.Tables(0).Rows(intIndex)("TipoDocumento") = "CP" OrElse dsVentas.Tables(0).Rows(intIndex)("TipoDocumento") = "CF" OrElse dsVentas.Tables(0).Rows(intIndex)("TipoDocumento") = "IP" Then
                            strResult = oProcesosSAPMgr.WRITE_ZBAPI_ABONO_CIERREDIAVC(strClienteVT, fecha, strDocFITS, strClienteVT, strDocFI, dsVentas.Tables(0).Rows(intIndex)("Monto"), dt)
                        Else 'En caso de que no sea de Si Hay, hace lo que ya hacia antes
                            strResult = oProcesosSAPMgr.WRITE_ZBAPI_ABONO_CIERREDIAVC(strClienteDV, fecha, strDocFITS, strClienteDV, strDocFI, dsVentas.Tables(0).Rows(intIndex)("Monto"), dt)
                        End If

                        If Not strResult = "S" Then
                            strMensaje += "FolioFISAP: " & dsVentas.Tables(0).Rows(intIndex)("FolioFISAP") & vbCrLf
                            For Each orow As DataRow In dt.Rows
                                strMensaje += "Error: " & orow.Item("Message") & vbCrLf
                            Next
                            strMensaje += vbCrLf

                            sm_GenerateFileTxtUpVC = "N"
                        Else
                            'actualizar el campo Compensado
                            ValeCajaCompensadoOkVC(strDocFITS, True)
                        End If
                    End If

                    strResult = ""
                    strClienteVT = ""
                    strClienteDV = ""

                Next


            End If

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    'Funcion Vale Caja DPVL Up
    Private Function sm_GenerateFileTxtUpVCDPVL(ByVal dsVentas As DataSet, ByVal FechaCierre As Date, ByRef strMensaje As String, Optional ByVal VPN As Boolean = True) As String
        sm_GenerateFileTxtUpVCDPVL = "S"
        Dim dt As DataTable

        Dim imes As Integer = FechaCierre.Date.Month
        Dim ruta As String
        oDPVale = New cDPVale
        If VPN Then
            ruta = oParent.ConfigSaveArchivos.Ruta & "\" & Mid(oParent.ApplicationContext.ApplicationConfiguration.Almacen, 2, 2) & "\" & GetMes(imes) & "\"
        Else
            ruta = "C:\VTAS\" & GetMes(imes) & "\"
        End If

        Try
            If dsVentas.Tables(0).Rows.Count = 0 Or dsVentas Is Nothing Then
                Exit Function
            End If

            ''DataView para las ventas
            Dim dvTarjetaUno As New DataView(dsVentas.Tables(0))
            Dim intIndex As Integer
            Dim strEncabezado As String

            Dim strResult As String = ""
            Dim fecha As String = ""
            Dim strClienteDV As String = ""
            Dim strClienteVT As String = ""
            Dim strDocFI As String = ""
            Dim strDocFITS As String = ""
            Dim bFI05SAP As Boolean = False
            Dim bCompensado As Boolean = False

            If dsVentas.Tables(0).Rows.Count > 0 Then
                dt = New DataTable

                For intIndex = 0 To dsVentas.Tables(0).Rows.Count - 1
                    fecha = CStr(CDate(dsVentas.Tables(0).Rows(intIndex)("Fecha")).ToShortDateString.Replace("/", "."))

                    oProcesosSAPMgr = New ProcesoSAPManager(Me.oParent.ApplicationContext, Me.oParent.SAPApplicationConfig)
                    'Saco el Cliente de la venta
                    Select Case dsVentas.Tables(0).Rows(intIndex)("CodTipoVentaVT")
                        Case "P"
                            strClienteVT = Me.oParent.ApplicationContext.ApplicationConfiguration.Almacen.PadLeft(10, "0")
                        Case "E"
                            strClienteVT = "99999".PadLeft(10, "0")
                        Case "V"
                            If Not Me.oParent.SAPApplicationConfig.DPValeSAP Then
                                strClienteVT = CStr(GetCodigoSAPAsoc(GetDpValeIDDP(CInt(dsVentas.Tables(0).Rows(intIndex)("FacturaID"))))).PadRight(10, " ")
                            Else
                                Dim strDpValeIDDP As String = CStr(GetDpValeIDDP(CInt(dsVentas.Tables(0).Rows(intIndex)("FacturaID"))))
                                Me.oDPVale.INUMVA = strDpValeIDDP
                                Me.oDPVale.I_RUTA = "X"

                                '--------------------------------------------------------------------------------------------
                                ' JNAVA (02.08.2016): Obtenemos la Info del DPVale 
                                '--------------------------------------------------------------------------------------------
                                'oDPVale = oSAPMgr.ZBAPI_VALIDA_DPVALE(oDPVale)
                                Dim S2Credit As New ProcesosS2Credit(oParent)
                                If oParent.ConfigSaveArchivos.AplicarS2Credit Then
                                    oDPVale = S2Credit.ValidaDPVale(oDPVale)
                                Else
                                    oDPVale = oSAPMgr.ZBAPI_VALIDA_DPVALE(oDPVale)
                                End If
                                '--------------------------------------------------------------------------------------------

                                strClienteVT = CStr(oDPVale.InfoDPVALE.Rows(0).Item("KUNNR")).PadRight(10, " ")
                            End If

                        Case "F"
                            strClienteVT = "0260000000"
                        Case "O"
                            strClienteVT = "0260000001"
                        Case "K"
                            strClienteVT = "0260002268"
                        Case "I", "D", "S"
                            strClienteVT = dsVentas.Tables(0).Rows(intIndex)("ClienteIDVT")
                        Case Else
                            sm_GenerateFileTxtUpVCDPVL = "N"
                            'MsgBox("Tipo de venta no Valido" & " FolioFISAP: " & dsVentas.Tables(0).Rows(intIndex)("FolioFISAP"), MsgBoxStyle.Information, "DpTienda")
                            strClienteVT = ""
                            Exit Function

                    End Select

                    'Saco el cliente de la factura devuelta
                    strClienteDV = Me.oParent.ApplicationContext.ApplicationConfiguration.Almacen.PadLeft(10, "0")

                    strDocFI = CStr(dsVentas.Tables(0).Rows(intIndex)("FIDOCUMENT")).Trim
                    strDocFI = strDocFI.PadLeft(10, "0")
                    strDocFITS = CStr(dsVentas.Tables(0).Rows(intIndex)("FolioFITS")).Trim
                    bFI05SAP = CBool(dsVentas.Tables(0).Rows(intIndex)("FI05SAP"))
                    bCompensado = CBool(dsVentas.Tables(0).Rows(intIndex)("Compensado"))
                    '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    'Compensamos la DR contra el AB del cliente de la factura en caso de que haya habido un traslado de saldos
                    'En caso que no haya habido traslado se compensa la DG contra la DR
                    '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    If bFI05SAP = False Then
                        If strDocFITS.Trim <> "" Then
                            strResult = oProcesosSAPMgr.WRITE_ZBAPI_ABONO_CIERREDIAVC(strClienteVT, fecha, dsVentas.Tables(0).Rows(intIndex)("FolioFISAP"), strClienteVT, strDocFITS, dsVentas.Tables(0).Rows(intIndex)("Monto"), dt)
                        Else
                            strResult = oProcesosSAPMgr.WRITE_ZBAPI_ABONO_CIERREDIAVC(strClienteVT, fecha, dsVentas.Tables(0).Rows(intIndex)("FolioFISAP"), strClienteDV, strDocFI, dsVentas.Tables(0).Rows(intIndex)("Monto"), dt)
                        End If

                        If Not strResult = "S" Then
                            strMensaje += "FolioFISAP: " & dsVentas.Tables(0).Rows(intIndex)("FolioFISAP") & vbCrLf
                            For Each orow As DataRow In dt.Rows
                                strMensaje += "Error: " & orow.Item("Message") & vbCrLf
                            Next
                            strMensaje += vbCrLf

                            sm_GenerateFileTxtUpVCDPVL = "N"
                        Else
                            'actualizar el campo FI05SAP
                            FacturaFI05okVC(dsVentas.Tables(0).Rows(intIndex)("FolioFISAP"))
                        End If
                    End If
                    '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    'Compensamos el DG contra el AB del cliente original de la devolucion en caso de que haya habido un traslado de saldos
                    '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    If strDocFITS.Trim <> "" AndAlso bCompensado = False Then
                        strResult = oProcesosSAPMgr.WRITE_ZBAPI_ABONO_CIERREDIAVC(strClienteDV, fecha, strDocFITS, strClienteDV, strDocFI, dsVentas.Tables(0).Rows(intIndex)("Monto"), dt)

                        If Not strResult = "S" Then
                            strMensaje += "FolioFISAP: " & dsVentas.Tables(0).Rows(intIndex)("FolioFISAP") & vbCrLf
                            For Each orow As DataRow In dt.Rows
                                strMensaje += "Error: " & orow.Item("Message") & vbCrLf
                            Next
                            strMensaje += vbCrLf

                            sm_GenerateFileTxtUpVCDPVL = "N"
                        Else
                            'actualizar el campo FI05SAP
                            ValeCajaCompensadoOkVC(strDocFITS, True)
                        End If
                    End If

                    strResult = ""
                    strClienteVT = ""
                    strClienteDV = ""

                Next

            End If

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    'Actualiza el campo Compensado Tabla Vale Caja
    Friend Sub ValeCajaCompensadoOkVC(ByVal FolioFITS As String, ByVal Compensado As Boolean)

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                       GetConnectionString)

        Dim sccmdUpdateFactura As SqlCommand = New SqlCommand

        Try

            With sccmdUpdateFactura

                .Connection = sccnnConnection
                .CommandText = "[ValeCajaUpdCompensacion]"
                '.CommandText = "UPDATE  FacturasFormasPago SET FI05SAP = 1 " & _
                '               "FROM         dbo.FacturasFormasPago INNER JOIN " & _
                '               "Factura ON FacturasFormasPago.FacturaID =  Factura.FacturaID " & _
                '               "WHERE     ( FacturasFormasPago.CodFormasPago = 'VCJA') " & _
                '               " and (Factura.FolioFISAP = '" & strFolioFISAP & "')"

                .CommandType = CommandType.Text
                .CommandType = CommandType.StoredProcedure

                .Parameters.Add(New SqlParameter("@FolioFITS", SqlDbType.VarChar, 10))
                .Parameters.Add(New SqlParameter("@Compensado", SqlDbType.Bit, 1))

                .Parameters("@FolioFITS").Value = FolioFITS.Trim.PadLeft(10, "0")
                .Parameters("@Compensado").Value = Compensado

            End With

            sccnnConnection.Open()
            sccmdUpdateFactura.ExecuteNonQuery()
            sccnnConnection.Close()

        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                sccnnConnection.Close()
            End If

            Throw New ApplicationException("El registro no pudo ser actualizado debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                sccnnConnection.Close()
            End If

            Throw New ApplicationException("El registro no pudo ser actualizado debido a un error de aplicación.", ex)

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

    End Sub

    'Funcion Vale Caja CANCAPAR Up
    Private Function sm_GenerateFileTxtUpVCCANCAPAR(ByVal dsVentas As DataSet, ByVal FechaCierre As Date, ByRef strMensaje As String, Optional ByVal VPN As Boolean = True) As String
        sm_GenerateFileTxtUpVCCANCAPAR = "S"
        Dim dt As DataTable

        Dim imes As Integer = FechaCierre.Date.Month
        Dim ruta As String
        oDPVale = New cDPVale
        If VPN Then
            ruta = oParent.ConfigSaveArchivos.Ruta & "\" & Mid(oParent.ApplicationContext.ApplicationConfiguration.Almacen, 2, 2) & "\" & GetMes(imes) & "\"
        Else
            ruta = "C:\VTAS\" & GetMes(imes) & "\"
        End If

        Try
            If dsVentas.Tables(0).Rows.Count = 0 Or dsVentas Is Nothing Then
                Exit Function
            End If

            ''DataView para las ventas
            Dim dvTarjetaUno As New DataView(dsVentas.Tables(0))
            Dim intIndex As Integer
            Dim strEncabezado As String

            Dim strResult As String = ""
            Dim fecha As String = ""
            Dim strClienteDV As String = ""
            Dim strClienteVT As String = ""
            Dim strDocFI As String = ""
            Dim strDocFITS As String = ""
            Dim bFI05SAP As Boolean = False
            Dim bCompensado As Boolean = False

            If dsVentas.Tables(0).Rows.Count > 0 Then
                dt = New DataTable

                For intIndex = 0 To dsVentas.Tables(0).Rows.Count - 1
                    fecha = CStr(CDate(dsVentas.Tables(0).Rows(intIndex)("Fecha")).ToShortDateString.Replace("/", "."))

                    oProcesosSAPMgr = New ProcesoSAPManager(Me.oParent.ApplicationContext, Me.oParent.SAPApplicationConfig)
                    'Saco el Cliente de la venta
                    Select Case dsVentas.Tables(0).Rows(intIndex)("CodTipoVentaVT")
                        Case "P"
                            strClienteVT = Me.oParent.ApplicationContext.ApplicationConfiguration.Almacen.PadLeft(10, "0")
                        Case "E"
                            strClienteVT = "99999".PadLeft(10, "0")
                        Case "V"
                            If Not Me.oParent.SAPApplicationConfig.DPValeSAP Then
                                strClienteVT = CStr(GetCodigoSAPAsoc(GetDpValeIDDP(CInt(dsVentas.Tables(0).Rows(intIndex)("FacturaID"))))).PadRight(10, " ")
                            Else
                                Dim strDpValeIDDP As String = CStr(GetDpValeIDDP(CInt(dsVentas.Tables(0).Rows(intIndex)("FacturaID"))))
                                Me.oDPVale.INUMVA = strDpValeIDDP
                                Me.oDPVale.I_RUTA = "X"

                                '--------------------------------------------------------------------------------------------
                                ' JNAVA (02.08.2016): Obtenemos la Info del DPVale 
                                '--------------------------------------------------------------------------------------------
                                'oDPVale = oSAPMgr.ZBAPI_VALIDA_DPVALE(oDPVale)
                                Dim S2Credit As New ProcesosS2Credit(oParent)
                                If oParent.ConfigSaveArchivos.AplicarS2Credit Then
                                    oDPVale = S2Credit.ValidaDPVale(oDPVale)
                                Else
                                    oDPVale = oSAPMgr.ZBAPI_VALIDA_DPVALE(oDPVale)
                                End If
                                '--------------------------------------------------------------------------------------------

                                strClienteVT = CStr(oDPVale.InfoDPVALE.Rows(0).Item("KUNNR")).PadRight(10, " ")
                            End If

                        Case "F"
                            strClienteVT = "0260000000"
                        Case "O"
                            strClienteVT = "0260000001"
                        Case "K"
                            strClienteVT = "0260002268"
                        Case "I", "D", "S"
                            strClienteVT = dsVentas.Tables(0).Rows(intIndex)("ClienteIDVT")
                        Case Else
                            sm_GenerateFileTxtUpVCCANCAPAR = "N"
                            'MsgBox("Tipo de venta no Valido" & " FolioFISAP: " & dsVentas.Tables(0).Rows(intIndex)("FolioFISAP"), MsgBoxStyle.Information, "DpTienda")
                            strClienteVT = ""
                            Exit Function

                    End Select
                    'Saco el cliente de la factura devuelta
                    strClienteDV = Me.oParent.ApplicationContext.ApplicationConfiguration.Almacen.PadLeft(10, "0")
                    strDocFI = CStr(dsVentas.Tables(0).Rows(intIndex)("FIDOCUMENT")).Trim
                    strDocFI = strDocFI.PadLeft(10, "0")
                    strDocFITS = CStr(dsVentas.Tables(0).Rows(intIndex)("FolioFITS")).Trim
                    bFI05SAP = CBool(dsVentas.Tables(0).Rows(intIndex)("FI05SAP"))
                    bCompensado = CBool(dsVentas.Tables(0).Rows(intIndex)("Compensado"))
                    '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    'Compensamos la DR contra el AB del cliente de la factura en caso de que haya habido un traslado de saldos
                    'En caso que no haya habido traslado se compensa la DG contra la DR
                    '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    If bFI05SAP = False Then
                        If strDocFITS.Trim <> "" Then
                            strResult = oProcesosSAPMgr.WRITE_ZBAPI_ABONO_CIERREDIAVC(strClienteVT, fecha, dsVentas.Tables(0).Rows(intIndex)("FolioFISAP"), strClienteVT, strDocFITS, dsVentas.Tables(0).Rows(intIndex)("Monto"), dt)
                        Else
                            strResult = oProcesosSAPMgr.WRITE_ZBAPI_ABONO_CIERREDIAVC(strClienteVT, fecha, dsVentas.Tables(0).Rows(intIndex)("FolioFISAP"), strClienteDV, strDocFI, dsVentas.Tables(0).Rows(intIndex)("Monto"), dt)
                        End If

                        If Not strResult = "S" Then
                            strMensaje += "FolioFISAP: " & dsVentas.Tables(0).Rows(intIndex)("FolioFISAP") & vbCrLf
                            For Each orow As DataRow In dt.Rows
                                strMensaje += "Error: " & orow.Item("Message") & vbCrLf
                            Next
                            strMensaje += vbCrLf

                            sm_GenerateFileTxtUpVCCANCAPAR = "N"
                        Else
                            'actualizar el campo FI05SAP
                            FacturaFI05okVC(dsVentas.Tables(0).Rows(intIndex)("FolioFISAP"))
                        End If
                    End If
                    '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    'Compensamos el DG contra el AB del cliente original de la devolucion en caso de que haya habido un traslado de saldos
                    '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    If strDocFITS.Trim <> "" AndAlso bCompensado = False Then
                        strResult = oProcesosSAPMgr.WRITE_ZBAPI_ABONO_CIERREDIAVC(strClienteDV, fecha, strDocFITS, strClienteDV, strDocFI, dsVentas.Tables(0).Rows(intIndex)("Monto"), dt)

                        If Not strResult = "S" Then
                            strMensaje += "FolioFISAP: " & dsVentas.Tables(0).Rows(intIndex)("FolioFISAP") & vbCrLf
                            For Each orow As DataRow In dt.Rows
                                strMensaje += "Error: " & orow.Item("Message") & vbCrLf
                            Next
                            strMensaje += vbCrLf

                            sm_GenerateFileTxtUpVCCANCAPAR = "N"
                        Else
                            'actualizar el campo Compensado Vale Caja
                            ValeCajaCompensadoOkVC(strDocFITS, True)
                        End If
                    End If

                    strResult = ""
                    strClienteVT = ""
                    strClienteDV = ""

                Next


            End If

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    'Funcion Abonos Up
    Private Function sm_GenerateFileTxtUpAB(ByVal dsVentas As DataSet, ByVal dsVentasDV As DataSet, ByVal FechaCierre As Date, ByRef strMensaje As String, Optional ByVal VPN As Boolean = True) As String
        sm_GenerateFileTxtUpAB = "S"
        Dim dt As DataTable
        Dim dtDatos As DataTable

        Dim imes As Integer = FechaCierre.Date.Month
        Dim ruta As String
        oDPVale = New cDPVale
        If VPN Then
            ruta = oParent.ConfigSaveArchivos.Ruta & "\" & Mid(oParent.ApplicationContext.ApplicationConfiguration.Almacen, 2, 2) & "\" & GetMes(imes) & "\"
        Else
            ruta = "C:\VTAS\" & GetMes(imes) & "\"
        End If

        Try
            If dsVentas.Tables(0).Rows.Count = 0 Or dsVentas Is Nothing Then
                Exit Function
            End If

            ''DataView para las ventas
            Dim oDataView As New DataView(dsVentas.Tables(0))
            Dim intIndex, IntIndexDV As Integer
            Dim strEncabezado As String

            Dim strResult As String = ""
            Dim strCliente As String = ""
            Dim strFoliosFISAP As String = "" 'FoliosFI de las Facturas
            Dim strFolioFI As String = ""


            If dsVentas.Tables(0).Rows.Count > 0 And dsVentasDV.Tables(0).Rows.Count > 0 Then
                dt = New DataTable
                dtDatos = New DataTable
                dtDatos.Columns.Add("DocFI", GetType(String))
                dtDatos.AcceptChanges()

                'Ciclo para el distinct del Cliente y FolioFISAP
                For IntIndexDV = 0 To dsVentasDV.Tables(0).Rows.Count - 1

                    strFolioFI = dsVentasDV.Tables(0).Rows(IntIndexDV)("FolioFISAP")

                    If InStr(strFoliosFISAP.Trim.ToUpper, strFolioFI.Trim.ToUpper) <= 0 Then

                        strFoliosFISAP &= strFolioFI & ","

                        oDataView.RowFilter = "ClienteID= '" & dsVentasDV.Tables(0).Rows(IntIndexDV)("ClienteID") & "' and FolioFISAP='" & dsVentasDV.Tables(0).Rows(IntIndexDV)("FolioFISAP") & "'"
                        oDataView.Sort = "ClienteID"
                        oDataView.RowStateFilter = DataViewRowState.OriginalRows

                        If oDataView.Count > 0 Then
                            'Asigno el cliente a la variable
                            strCliente = dsVentasDV.Tables(0).Rows(IntIndexDV)("ClienteID")

                            'Ciclo para agregar el ducumento FI 
                            For intIndex = 0 To oDataView.Count - 1
                                'Agrego el DocumentoFI
                                Dim oNewRow As DataRow = dtDatos.NewRow()
                                oNewRow("DocFI") = oDataView(intIndex)("DocFI")
                                dtDatos.Rows.Add(oNewRow)
                                dtDatos.AcceptChanges()
                            Next

                            'Agrego el FolioFISAP
                            Dim oNewRow2 As DataRow = dtDatos.NewRow()
                            oNewRow2("DocFI") = oDataView(0)("FolioFISAP")
                            dtDatos.Rows.Add(oNewRow2)
                            dtDatos.AcceptChanges()

                            'Mando los datos a la BAPI
                            oProcesosSAPMgr = New ProcesoSAPManager(Me.oParent.ApplicationContext, Me.oParent.SAPApplicationConfig)
                            strResult = oProcesosSAPMgr.WRITE_ZBAPI_ABONO_CIERREDIAAB(strCliente, dtDatos, dt)


                            If Not strResult = "S" Then
                                strMensaje += "FolioFISAP: " & oDataView(0)("FolioFISAP") & vbCrLf
                                For Each orow As DataRow In dt.Rows
                                    strMensaje += "Error: " & orow.Item("Message") & vbCrLf
                                Next
                                strMensaje += vbCrLf

                                sm_GenerateFileTxtUpAB = "N"
                            Else
                                'actualizar el campo FI05SAP
                                FacturaFI05okAB(oDataView(0)("FolioFISAP"))
                            End If

                            strResult = ""
                            dtDatos.Clear()

                        End If

                    End If

                Next

            End If

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function EjecutarZBAPIFI05_VENTASDIA(ByVal FechaCierre As DateTime) As Boolean

        Dim oMontarURed As New MontarUnidadRed.cMontaUnidadRed(oParent.ConfigSaveArchivos.Password, oParent.ConfigSaveArchivos.Usuario, oParent.ConfigSaveArchivos.Unidad, oParent.ConfigSaveArchivos.Ruta)

        Dim imes As Integer = FechaCierre.Date.Month
        Dim strRuta = oParent.ConfigSaveArchivos.Ruta & "\" & Mid(oParent.ApplicationContext.ApplicationConfiguration.Almacen, 2, 2) & "\" & GetMes(imes) & "\"

        'Antes de Validar si existe el Archivo Conecta la Unidad de Red
        oMontarURed.Conecta()

        'Aqui Mandar LLamar la BAPI
        Dim dt As New DataTable
        Dim strResult As String = String.Empty
        If Not File.Exists(strRuta & "VTA" & oParent.ApplicationContext.ApplicationConfiguration.Almacen & FechaCierre.ToShortDateString.Replace("/", "") & ".txt") Then
            ' El archivo no existe se mande True para que no mande mensaje
            ' Y se termina sin hacer nada
            ' Solamente no se generara en casos de que no haya ventas
            Return True
        End If

        dt = oSAPMgr.ZBAPIFI05_VENTASDIA(strResult, strRuta & "VTA" & oParent.ApplicationContext.ApplicationConfiguration.Almacen & FechaCierre.ToShortDateString.Replace("/", "") & ".txt")

        'A es un error en la carga del archivo, no se cargo nada
        'B es porque en una o varias no se registro el abono
        'Nada es OK
        'desconecta la unidad de Red


        'Marcar en Dportenis Facturas los que ya se guardaron en SAP
        If strResult.Trim <> "A" Then

            If Not Directory.Exists(oParent.ConfigSaveArchivos.Ruta & "\ConcentraTiendas") Then
                Directory.CreateDirectory(oParent.ConfigSaveArchivos.Ruta & "\ConcentraTiendas")
            End If

            Dim txtWriter As New System.IO.StreamWriter(oParent.ConfigSaveArchivos.Ruta & "\ConcentraTiendas\" & oParent.ApplicationContext.ApplicationConfiguration.Almacen & FechaCierre.ToShortDateString.Replace("/", "") & ".txt", True)
            'Los que si grabaron los guardo en un archivo
            For Each erow As DataRow In dt.Rows
                txtWriter.WriteLine(CStr(erow(0)) & "," & CStr(erow(1)) & "," & CStr(erow(2)) & "," & CStr(erow(3)) & "," & CStr(erow(4)))
                If CStr(erow(3)) <> String.Empty Then
                    'FacturaFI05ok(CStr(erow(2)), CStr(erow(4)))
                End If
            Next
            txtWriter.Close()

            If strResult.Trim <> String.Empty Then
                oMontarURed.Desconecta()
                oMontarURed.Desconecta()
                Return False
            Else
                'Si esta me lo quiebro 'Borrar el archivo
                If File.Exists(strRuta & "VTA" & oParent.ApplicationContext.ApplicationConfiguration.Almacen & FechaCierre.ToShortDateString.Replace("/", "") & ".txt") Then
                    File.Delete(strRuta & "VTA" & oParent.ApplicationContext.ApplicationConfiguration.Almacen & FechaCierre.ToShortDateString.Replace("/", "") & ".txt")
                End If

                oMontarURed.Desconecta()
                oMontarURed.Desconecta()
                Return True
            End If
            oMontarURed.Desconecta()
            oMontarURed.Desconecta()
        Else
            'Error
            Return False
        End If

    End Function

    Friend Sub RespaldoBDDportenisPRO(ByVal strRuta As String)

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                               GetConnectionString)
        Dim sccmdBackupDP As SqlCommand = New SqlCommand

        Try

            With sccmdBackupDP

                .Connection = sccnnConnection

                .CommandText = " BACKUP DATABASE " & oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration.Database & " " & _
                                " TO DISK = '" & strRuta & "\" & oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration.Database & ".BAK' " & _
                                " WITH FORMAT, " & _
                                " NAME = 'Respaldo Completo de Ptventa " & Format(Date.Now, "ddMMyyyy") & "'"
                .CommandType = CommandType.Text


            End With

            sccnnConnection.Open()
            sccmdBackupDP.ExecuteNonQuery()
            sccnnConnection.Close()

        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                sccnnConnection.Close()
            End If

            Throw New ApplicationException("El registro no pudo ser leido debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                sccnnConnection.Close()
            End If

            Throw New ApplicationException("El registro no pudo ser leido debido a un error de aplicación.", ex)

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

    End Sub

    Friend Sub FacturaFI05ok(ByVal FormaPagoId As Integer)
        Dim strCodFormaPago As String = String.Empty
        Dim strTarjeta As String = String.Empty

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                               GetConnectionString)

        Dim sccmdUpdateFactura As SqlCommand = New SqlCommand

        Try

            With sccmdUpdateFactura

                .Connection = sccnnConnection
                .CommandText = "CierreDiaUpdFi05SAP"

                .CommandType = CommandType.StoredProcedure

                .Parameters.Add(New SqlParameter("@FormaPagoId", SqlDbType.Int, 11))
                .Parameters("@FormaPagoId").Value = FormaPagoId

            End With

            sccnnConnection.Open()
            sccmdUpdateFactura.ExecuteNonQuery()
            sccnnConnection.Close()

        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                sccnnConnection.Close()
            End If

            Throw New ApplicationException("El registro no pudo ser leido debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                sccnnConnection.Close()
            End If

            Throw New ApplicationException("El registro no pudo ser leido debido a un error de aplicación.", ex)

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

    End Sub

    Public Sub UpdateCompensarNotaCredito(ByVal NotaCreditoID As Integer)
        Dim conexion As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                               GetConnectionString)
        Dim command As New SqlCommand("UpdateCompesarNotaCredito", conexion)
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.AddWithValue("@NotaCreditoID", NotaCreditoID)
            command.ExecuteNonQuery()
            command.Dispose()
            conexion.Close()
        Catch sql As SqlException
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            Throw New ApplicationException(sql.Message, sql)
        Catch ex As Exception
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            Throw New ApplicationException(ex.Message, ex)
        End Try
    End Sub
    'Actualiza el campoFI05SAP Vale de Caja
    Friend Sub FacturaFI05okVC(ByVal strFolioFISAP As String)

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                       GetConnectionString)

        Dim sccmdUpdateFactura As SqlCommand = New SqlCommand

        Try

            With sccmdUpdateFactura

                .Connection = sccnnConnection

                .CommandText = "UPDATE  FacturasFormasPago SET FI05SAP = 1 " & _
                               "FROM         dbo.FacturasFormasPago INNER JOIN " & _
                               "Factura ON FacturasFormasPago.FacturaID =  Factura.FacturaID " & _
                               "WHERE     ( FacturasFormasPago.CodFormasPago = 'VCJA') " & _
                               " and (Factura.FolioFISAP = '" & strFolioFISAP & "')"

                .CommandType = CommandType.Text

            End With

            sccnnConnection.Open()
            sccmdUpdateFactura.ExecuteNonQuery()
            sccnnConnection.Close()

        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                sccnnConnection.Close()
            End If

            Throw New ApplicationException("El registro no pudo ser leido debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                sccnnConnection.Close()
            End If

            Throw New ApplicationException("El registro no pudo ser leido debido a un error de aplicación.", ex)

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

    End Sub
    'Actualiza el campoFI05SAP Abonos
    Friend Sub FacturaFI05okAB(ByVal strFolioFISAP As String)

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                       GetConnectionString)

        Dim sccmdUpdateFactura As SqlCommand = New SqlCommand

        Try

            With sccmdUpdateFactura

                .Connection = sccnnConnection

                .CommandText = "UPDATE  FacturasFormasPago SET FI05SAP = 1 " & _
                               "FROM         dbo.FacturasFormasPago INNER JOIN " & _
                               "Factura ON FacturasFormasPago.FacturaID =  Factura.FacturaID " & _
                               "WHERE     ( FacturasFormasPago.CodFormasPago = 'LIQU') " & _
                               " and (Factura.FolioFISAP = '" & strFolioFISAP & "')"

                .CommandType = CommandType.Text

            End With

            sccnnConnection.Open()
            sccmdUpdateFactura.ExecuteNonQuery()
            sccnnConnection.Close()

        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                sccnnConnection.Close()
            End If

            Throw New ApplicationException("El registro no pudo ser leido debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                sccnnConnection.Close()
            End If

            Throw New ApplicationException("El registro no pudo ser leido debido a un error de aplicación.", ex)

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

    End Sub

    Private Function CrearFolder(ByVal VPN As Boolean, ByVal FechaCierre As Date) As Boolean
        Dim oMontarURed As New MontarUnidadRed.cMontaUnidadRed(oParent.ConfigSaveArchivos.Password, oParent.ConfigSaveArchivos.Usuario, oParent.ConfigSaveArchivos.Unidad, oParent.ConfigSaveArchivos.Ruta)
        Dim strmes As String = GetMes(FechaCierre.Date.Month)
        If VPN Then
            If oMontarURed.Conecta() Then
                Dim ruta As String = oParent.ConfigSaveArchivos.Ruta & "\" & Mid(oParent.ApplicationContext.ApplicationConfiguration.Almacen, 2, 2) & "\" & strmes
                If Not Directory.Exists(ruta) Then
                    Directory.CreateDirectory(ruta)
                End If
                Return True
            Else
                'Para cuando no haya conexion a al VPN
                If Not Directory.Exists("C:\VTAS\" & strmes) Then
                    Directory.CreateDirectory("C:\VTAS\" & strmes)
                End If
                Return False
            End If
        Else
            'Para cuando no haya conexion a al VPN
            If Not Directory.Exists("C:\VTAS\" & strmes) Then
                Directory.CreateDirectory("C:\VTAS\" & strmes)
            End If
            Return False
        End If
    End Function

    Private Function GetMes(ByVal imes As Integer)

        Select Case imes
            Case 1
                Return "ENERO"
            Case 2
                Return "FEBRERO"
            Case 3
                Return "MARZO"
            Case 4
                Return "ABRIL"
            Case 5
                Return "MAYO"
            Case 6
                Return "JUNIO"
            Case 7
                Return "JULIO"
            Case 8
                Return "AGOSTO"
            Case 9
                Return "SEPTIEMBRE"
            Case 10
                Return "OCTUBRE"
            Case 11
                Return "NOVIEMBRE"
            Case 12
                Return "DICIEMBRE"
        End Select
    End Function

    Private Function Cantidad(ByVal num As Decimal) As String
        Return (Format(num, "##"))
    End Function

    Private Function Talla(ByVal str As String) As String
        If IsNumeric(str) Then
            Return (Format(CDec(str), "##.0"))
        Else
            Return str
        End If
    End Function

    Private Function Condicion(ByVal str As String) As String
        If str = "DMA" Or str = "DPE" Then
            Return "ZDP4"
        Else
            If str = "DVD" Then
                Return "ZRDV"
            Else
                If str = "DCD" Then
                    Return "ZDIP"
                End If
            End If
        End If
    End Function

    Private Function NombreTienda() As String
        If oParent.ApplicationContext.ApplicationConfiguration.Almacen = "053" Then
            GoTo Cambio_053
            'Return "C053"
        Else
Cambio_053:
            Return ("T" & oParent.ApplicationContext.ApplicationConfiguration.Almacen)
        End If
    End Function

    Public Function FacturaSelDontSaved() As DataSet

        Dim oResult As DataSet
        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[FacturaSelDontSaved]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))

        End With

        Dim oEstadosAdapter As SqlDataAdapter
        oEstadosAdapter = New SqlDataAdapter
        oEstadosAdapter.SelectCommand = sccmdSelect

        Try

            sccnnConnection.Open()

            oResult = New DataSet

            oEstadosAdapter.Fill(oResult)


        Catch ex As Exception

            Throw ex

        Finally

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

        End Try

        sccmdSelect.Dispose()
        sccmdSelect = Nothing

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return oResult

    End Function


    Public Function FacturaSelDontSavedByCaja() As DataSet

        Dim oResult As DataSet
        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[FacturaSelDontSavedByCaja]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar, 2))

            .Parameters("@CodCaja").Value = oParent.ApplicationContext.ApplicationConfiguration.NoCaja  'Codcaja

        End With

        Dim oEstadosAdapter As SqlDataAdapter
        oEstadosAdapter = New SqlDataAdapter
        oEstadosAdapter.SelectCommand = sccmdSelect

        Try

            sccnnConnection.Open()

            oResult = New DataSet

            oEstadosAdapter.Fill(oResult)


        Catch ex As Exception

            Throw ex

        Finally

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

        End Try

        sccmdSelect.Dispose()
        sccmdSelect = Nothing

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return oResult

    End Function

    Public Function FacturaCANSelDontSaved() As DataSet

        Dim oResult As DataSet
        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[FacturaCANSelDontSaved]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))

        End With

        Dim oEstadosAdapter As SqlDataAdapter
        oEstadosAdapter = New SqlDataAdapter
        oEstadosAdapter.SelectCommand = sccmdSelect

        Try

            sccnnConnection.Open()

            oResult = New DataSet

            oEstadosAdapter.Fill(oResult)


        Catch ex As Exception

            Throw ex

        Finally

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

        End Try

        sccmdSelect.Dispose()
        sccmdSelect = Nothing

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return oResult

    End Function

#End Region

#Region "SAP Objects"

    Dim oSAPMgr As ProcesoSAPManager

    'Objeto Articulo
    Dim oCatalogoArticuloMgr As CatalogoArticuloManager
    Dim oArticulo As Articulo

    'Objeto Factura
    Dim oFacturaMgr As FacturaManager

    'Objeto contrato
    Dim oContratoMngr As ContratoManager

    'Objeto Abonos Contrato
    Dim oAbonosApartadosMgr As AbonosApartadosManager

    'Objeto CancelarAbonos
    Dim oCancelaAbonosMgr As CancelacionAbonoManager

    'Objeto Distribucion Manager 
    Dim oDistribucionNCMgr As DistribucionNCManager

    'Objeto Nota de Credito Manager
    Dim oNotaCreditoMgr As NotasCreditoManager

    'Objeto AjusteTalla Manager
    Dim oAjusteMgr As AjusteGeneralTallaManager
    Dim oAjuste As AjusteGeneralTallaInfo

#End Region

#Region "SAP Methods To Save Factura"

    Public Sub SaveFacturaSAP(ByVal oFactura As Factura)

        Dim arDatosZV() As String
        Dim arDatosDPVale() As String

        Dim oVentaFacturaSAP As New VentasFacturaSAP

        With oVentaFacturaSAP
            'Se manda la Fecha Apartado.
            'Para determinar el precio. 18.10.2007
            .FechaApartado = oFactura.FechaApartado

            .FacturaDP = oFactura.CodAlmacen & oFactura.CodCaja & CStr(oFactura.FolioFactura)
            .FechaMovimiento = Date.Now.Date

            .ClasePedido = "Z" & Mid(oParent.ApplicationContext.ApplicationConfiguration.Almacen, 2, 2) & "1"

            If oParent.ApplicationContext.ApplicationConfiguration.Almacen = "053" Then
                GoTo Cambio_053
                '.OficinaVentas = "C053"
            Else
Cambio_053:
                .OficinaVentas = "T" & oParent.ApplicationContext.ApplicationConfiguration.Almacen
            End If

            .Vendedor = oFactura.CodVendedor

            If oParent.ApplicationContext.ApplicationConfiguration.Almacen = "053" Then
                'Cambio_053
                '.Centro = "C053"
                .Centro = "T053"
            Else
                .Centro = "T" & oParent.ApplicationContext.ApplicationConfiguration.Almacen
            End If

            Select Case oFactura.CodTipoVenta
                Case "P"
                    .Credito = "N"
                    .CodigoCliente = CStr(oFactura.ClienteId).PadLeft(10, "0")
                Case "E"
                    .Credito = "N"
                    .CodigoCliente = "99999".PadLeft(10, "0")
                Case "F", "O", "I", "A", "S", "K"
                    .Credito = "N"
                    .CodigoCliente = CStr(oFactura.ClienteId).PadLeft(10, "0")
                Case "V"
                    Exit Sub
                    '.Credito = "S"
                    'arDatosDPVale = GetDPValeSAP(oFactura)
                    '.CodigoCliente = arDatosDPVale(0).PadLeft(10, "0")
                    '.MontoDPVale = arDatosDPVale(1)
                    '.ClienteDistribuidor = arDatosDPVale(2).PadLeft(10, "0")
                Case "D"
                    .Credito = "S"
                    .CodigoCliente = CStr(oFactura.ClienteId).PadLeft(10, "0")
            End Select

            arDatosZV = GetZonaVentaSAP(oFactura)
            .ZonaVenta = arDatosZV(0)
            .NumeroVale = arDatosZV(1)      'DPVale o Vale de Caja

            .TipoVenta = oFactura.CodTipoVenta
            .NombreBAPI = GetNombreBAPI(.ZonaVenta, oFactura)
            .Detalle = PutCondicion(oFactura)

        End With

        '--Guardar Factura en SAP
        oSAPMgr.Write_FacturaSAP(oVentaFacturaSAP)

        '--Publicamos Folios
        oFactura.FolioSAP = oVentaFacturaSAP.FolioSAP
        oFactura.FolioFISAP = oVentaFacturaSAP.FolioFISAP
        'Actualizamos Folios
        UpdateFolioSAP(oFactura)

        oVentaFacturaSAP.Dispose()
        oVentaFacturaSAP = Nothing

    End Sub

    'Listo
    Private Function GetZonaVentaSAP(ByVal oFactura As Factura) As String()

        Dim dvZonaVenta As New DataView
        Dim oResult(2) As String
        With dvZonaVenta
            .Table = oFactura.Detalle.Tables("FacturasFormasPago")
            .AllowDelete = False
            .AllowEdit = False
            .AllowNew = False
            .Sort = "MontoPago DESC"

            If oFactura.CodTipoVenta = "F" Then
                .RowFilter = "CodFormasPago = 'FONA'"
            ElseIf oFactura.CodTipoVenta = "K" Then
                .RowFilter = "CodFormasPago = 'TFON'"
            ElseIf oFactura.CodTipoVenta = "O" Then
                .RowFilter = "CodFormasPago = 'FACI'"
            ElseIf oFactura.CodTipoVenta = "V" Then
                .RowFilter = "CodFormasPago = 'DPVL'"
            End If

        End With
        If dvZonaVenta.Count > 0 Then
            oResult(0) = dvZonaVenta.Item(0).Item("CodFormasPago")
            oResult(1) = CStr(dvZonaVenta.Item(0).Item("DPValeID")).PadLeft(10, "0")
        Else
            If oFactura.CodTipoVenta = "O" Then
                oResult(0) = "FACI"
            ElseIf oFactura.CodTipoVenta = "F" Then
                oResult(0) = "FONA"
            ElseIf oFactura.CodTipoVenta = "K" Then
                oResult(0) = "TFON"
            End If
            oResult(1) = "0"
        End If

        dvZonaVenta.Dispose()
        dvZonaVenta = Nothing

        Return oResult

    End Function

    Private Function GetDPValeSAP(ByVal ofactura As Factura) As String()

        'Dim oDvDPVale As New DataView(ofactura.Detalle.Tables("FacturasFormasPago"), "CodFormasPago='DPVL'", "FacturaID", DataViewRowState.CurrentRows)
        'Dim oResult(3) As String

        'oResult(0) = oRow!CodigoSAP
        'oResult(1) = oRow!MontoDPVale
        'oResult(2) = oRow!CodigoSAP

        'oRow = Nothing

        'Return oResult

    End Function

    'Listo
    Private Function GetNombreBAPI(ByVal strZonaVenta As String, ByVal oFactura As Factura) As String

        If oFactura.CodTipoVenta = "D" Then
            Return "ZBAPISD12_VENTADIPS"                        '--DIP's
        ElseIf oFactura.CodTipoVenta = "A" Then
            Return "ZBAPISD11_VENTAAPARTADO"
        ElseIf oFactura.CodTipoVenta = "I" Then
            Select Case UCase(strZonaVenta)
                Case "EFEC"
                    Return "ZBAPISD06_VTAEFECTIVOFACFIS"        '--Fact. Fiscal
                Case "VCJA"
                    Return "ZBAPISD09_VTAVALECAJA"              '--Fact. Fiscal
                Case "TACR"
                    Return "ZBAPISD08_VTATARJETAFACFIS"         '--Fact. Fiscal
                Case "TADB"
                    Return "ZBAPISD08_VTATARJETAFACFIS"         '--Fact. Fiscal
            End Select
        Else
            Select Case UCase(strZonaVenta)
                Case "EFEC"
                    Return "ZBAPISD05_VENTASEFECPG"             '--Pub. General
                Case "VCJA"
                    Return "ZBAPISD09_VTAVALECAJA"              '--Pub. General
                Case "TACR"
                    Return "ZBAPISD07_VENTASTARCPG"             '--Pub. General
                Case "TADB"
                    Return "ZBAPISD07_VENTASTARCPG"             '--Pub. General
                Case "FONA", "TFON"
                    Return "ZBAPISD14_VENTASFONACOT"            '--FONACOT
                Case "FACI"
                    Return "ZBAPISD15_VENTASFACILITO"           '--FACILITO
                Case "DPVL"
                    Return "ZBAPISD10_VENTADPVALE"              '--DPVALE
            End Select
        End If

    End Function

    'Listo 
    Private Function PutCondicion(ByVal oFactura As Factura) As DataTable

        Dim oData As New DataTable
        Dim oCol As DataColumn
        Dim oRow As DataRow
        Dim oCondicionVenta As Decimal
        oData = oFactura.Detalle.Tables("FacturaDetalle")

        oFactura.Detalle.Tables("FacturaDetalle").Columns("CodArticulo").ColumnName = "Codigo"
        oFactura.Detalle.Tables("FacturaDetalle").Columns("Numero").ColumnName = "Talla"
        '--Añadimos Columna Condicion
        oCol = New DataColumn
        With oCol
            .ColumnName = "Condicion"
            .DataType = Type.GetType("System.String")
            .MaxLength = 4
            .DefaultValue = ""
        End With
        oData.Columns.Add(oCol)
        oCol.Dispose()
        oCol = Nothing
        '--Fin Columna Condicion

        '--Añadimos Columna Adicional
        Dim oColAdicional As DataColumn
        oColAdicional = New DataColumn
        With oColAdicional
            .ColumnName = "Adicional"
            .DataType = Type.GetType("System.Decimal")
            .DefaultValue = 0
        End With
        oData.Columns.Add(oColAdicional)
        oColAdicional.Dispose()
        oColAdicional = Nothing
        '--Fin Columna Adicional

        For Each oRow In oData.Rows
            If oRow!Descuento > 0 Then
                'If oRow!CodTipoDescuento = "DMA" Then                   '--Descuento de Manager
                '    oRow!Condicion = "Z3AN"
                '    oRow!Adicional = oRow!Descuento
                'ElseIf oRow!CodTipoDescuento = "DVD" Then               '--Vales de Descuento
                '    oRow!Condicion = "ZRDV"
                '    oRow!Adicional = oRow!Descuento
                'ElseIf oRow!CodTipoDescuento = "DCD" Then
                '    oRow!Condicion = "ZDIP"
                '    oRow!Adicional = oRow!Descuento
                'ElseIf oRow!CodTipoDescuento = "DPO" OrElse oRow!CodTipoDescuento = "DPE" Then
                '    oRow!Condicion = "Z3AN"
                '    oRow!Adicional = oRow!Descuento
                'Else
                '    oRow!Condicion = ""
                '    oRow!Adicional = "0"
                'End If
                oRow!Condicion = oRow!CodTipoDescuento
                oRow!Adicional = oRow!Descuento
            Else
                oArticulo.ClearFields()
                oCatalogoArticuloMgr.LoadInto(oRow!Codigo, oArticulo)

                oCondicionVenta = CondicionVenta_Porcentaje(oFactura)  'Listo
                If oRow!CantDescuentoSistema > 0 And oCondicionVenta = 0 Then  '--Es un Dpesos
                    oRow!Condicion = "Z501"
                    oRow!Descuento = oRow!CantDescuentoSistema
                Else
                    oRow!Condicion = ""
                    oRow!Descuento = 0
                End If
            End If
        Next

        oRow = Nothing

        Return oData

    End Function

    'Listo
    Private Function CondicionVenta_Porcentaje(ByVal oFactura As Factura) As Decimal

        Dim oResult As Decimal
        Dim oCventa As New CondicionesVtaSAP

        Dim oTipoVenta As TipoVenta
        Dim oTipoVentaMgr As New CatalogoTipoVentaManager(oParent.ApplicationContext)
        oTipoVenta = oTipoVentaMgr.Create
        oTipoVenta = oTipoVentaMgr.Load(oFactura.CodTipoVenta)

        With oCventa
            If oParent.ApplicationContext.ApplicationConfiguration.Almacen = "053" Then
                GoTo Cambio_053
                '.OficinaVtas = "C053"
            Else
Cambio_053:
                .OficinaVtas = "T" & oFactura.CodAlmacen
            End If
            '.OficinaVtas = "T" & oFactura.CodAlmacen
            .Jerarquia = oArticulo.Jerarquia
            .CondMat = oArticulo.CodMarca
            .CondPrec = oTipoVenta.CodSAP  'strCondicionVenta
            .Material = oArticulo.CodArticulo
            .ListPrec = oTipoVenta.ListaPrecios  'strListaPrecios
        End With

        oFacturaMgr.GetCondicionVenta(oCventa)

        oResult = oCventa.DescPorcentaje

        oCventa = Nothing

        Return oResult

    End Function

    'Listo
    Private Sub UpdateFolioSAP(ByVal oFactura As Factura)

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdUpdate As SqlCommand
        sccmdUpdate = New SqlCommand

        With sccmdUpdate

            .Connection = sccnnConnection

            .CommandText = "UPDATE Factura SET FolioSAP='" & oFactura.FolioSAP & "', FolioFISAP='" & oFactura.FolioFISAP & "' WHERE FacturaID = " & oFactura.FacturaID & ""
            .CommandType = System.Data.CommandType.Text

        End With

        Try

            sccnnConnection.Open()

            With sccmdUpdate

                'Ejecutamos Comando
                .ExecuteNonQuery()

            End With

            sccnnConnection.Close()

        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                sccnnConnection.Close()
            End If

            Throw New ApplicationException("El registro no pudo ser actualizado debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                sccnnConnection.Close()
            End If

            Throw New ApplicationException("El registro no pudo ser actualizado debido a un error de aplicación.", ex)

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing



    End Sub

#End Region

#Region "Notas de Credito"

    Private Sub SaveFISDNotaCredito(ByVal intNotaCreditoID As Integer, ByVal strFI As String, ByVal strSD As String)

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                                 DataStorageConfiguration.GetConnectionString)

        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand

        With sccmdInsert

            .Connection = sccnnConnection

            .CommandText = "[NotasCreditoUpdFISD]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .CommandType = CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@NotaCreditoID", System.Data.SqlDbType.Int))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FIDOCUMENT", System.Data.SqlDbType.VarChar, 10))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@SALESDOCUMENT", System.Data.SqlDbType.VarChar, 10))

        End With

        Try

            sccnnConnection.Open()

            With sccmdInsert

                'Assign Parameters Values

                .Parameters("@NotaCreditoID").Value = intNotaCreditoID
                .Parameters("@FIDOCUMENT").Value = strFI
                .Parameters("@SALESDOCUMENT").Value = strSD

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

    Public Function ReadSQLNotasCreditoSinRegSAP() As DataTable

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaContrato As SqlDataAdapter
        Dim dsContrato As DataSet

        sccmdSelectAll = New SqlCommand
        scdaContrato = New SqlDataAdapter
        dsContrato = New DataSet("NotasCredito")

        With sccmdSelectAll

            .Connection = sccnnConnection
            .CommandText = "[NotasCreditoDontSaved]"
            .CommandType = System.Data.CommandType.StoredProcedure
        End With

        Try
            sccnnConnection.Open()

            scdaContrato.SelectCommand = sccmdSelectAll

            'Fill DataSet
            scdaContrato.Fill(dsContrato, "NotasCredito")

            sccnnConnection.Close()

        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException(oSqlException.Message, oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException(ex.Message, ex)

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return dsContrato.Tables(0)

    End Function

    Public Function ReadSQLFacturasDPVale(ByVal Fecha As Date) As DataTable

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaContrato As SqlDataAdapter
        Dim dsContrato As DataSet

        sccmdSelectAll = New SqlCommand
        scdaContrato = New SqlDataAdapter
        dsContrato = New DataSet("FacturasDPVale")

        With sccmdSelectAll

            .Connection = sccnnConnection
            .CommandText = "[FacturasDPValeSel]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New SqlParameter("@Fecha", SqlDbType.DateTime, 8))

            .Parameters("@Fecha").Value = Fecha
        End With

        Try
            sccnnConnection.Open()

            scdaContrato.SelectCommand = sccmdSelectAll

            'Fill DataSet
            scdaContrato.Fill(dsContrato, "FacturasDPVale")

            sccnnConnection.Close()

        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException(oSqlException.Message, oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException(ex.Message, ex)

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return dsContrato.Tables(0)

    End Function

    '-----------------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 22/06/2016: Carga las facturas realizas en el día, a excepción del DPVale
    '-----------------------------------------------------------------------------------------------------------------------------------------

    Public Function GetFacturasSinVale(ByVal fechaCierre As DateTime) As DataTable
        Dim conexion As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString())
        Dim command As New SqlCommand("GetFacturasSinVale", conexion)
        Dim dtFacturas As New DataTable
        Dim adapter As SqlDataAdapter = Nothing
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.AddWithValue("@FechaCierre", fechaCierre)
            'command.Parameters.AddWithValue("@FechaInicio", fechaInicio)
            'command.Parameters.AddWithValue("@FechaFin", FechaFin)
            command.Parameters.AddWithValue("@CodAlmacen", oParent.ApplicationContext.ApplicationConfiguration.Almacen)
            adapter = New SqlDataAdapter(command)
            adapter.Fill(dtFacturas)
            command.Dispose()
            conexion.Close()
        Catch sql As SqlException
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            Throw New ApplicationException(sql.Message, sql)
        Catch ex As Exception
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            Throw New ApplicationException(ex.Message, ex)
        End Try
        Return dtFacturas
    End Function

    Public Function GetFacturas(ByVal fechaInicio As DateTime, ByVal fechaFin As DateTime) As DataTable
        Dim conexion As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString())
        Dim command As New SqlCommand("GetFacturasSinVale", conexion)
        Dim dtFacturas As New DataTable
        Dim adapter As SqlDataAdapter = Nothing
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            'command.Parameters.AddWithValue("@FechaCierre", fechaCierre)
            command.Parameters.AddWithValue("@FechaInicio", fechaInicio)
            command.Parameters.AddWithValue("@FechaFin", FechaFin)
            command.Parameters.AddWithValue("@CodAlmacen", oParent.ApplicationContext.ApplicationConfiguration.Almacen)
            adapter = New SqlDataAdapter(command)
            adapter.Fill(dtFacturas)
            command.Dispose()
            conexion.Close()
        Catch sql As SqlException
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            Throw New ApplicationException(sql.Message, sql)
        Catch ex As Exception
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            Throw New ApplicationException(ex.Message, ex)
        End Try
        Return dtFacturas
    End Function

    Private Function ReadSQLNotasCreditoDetalle(ByVal intNotaCreditoID As Integer) As DataSet

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaContrato As SqlDataAdapter
        Dim dsNotaCredito As DataSet

        sccmdSelectAll = New SqlCommand
        scdaContrato = New SqlDataAdapter
        dsNotaCredito = New DataSet("NotaCreditoDetalles")

        With sccmdSelectAll

            .Connection = sccnnConnection
            .CommandText = "[NotasCreditoDetalleDontSaved]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@NotaCreditoID", System.Data.SqlDbType.Int))
            .Parameters("@NotaCreditoID").Value = intNotaCreditoID
        End With

        Try
            sccnnConnection.Open()

            scdaContrato.SelectCommand = sccmdSelectAll

            'Fill DataSet
            scdaContrato.Fill(dsNotaCredito, "NotaCreditoDetalles")

            sccnnConnection.Close()

        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException(oSqlException.Message, oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException(ex.Message, ex)

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return dsNotaCredito

    End Function

    Public Function Write_NotasCreditoSAPNoReg()
        Try
            Dim odrNotaCredito As DataRow
            Dim dtNotaCredito As DataTable
            Dim strRDocfic As String

            'La tabla de todos los que encontro
            dtNotaCredito = ReadSQLNotasCreditoSinRegSAP()

            For Each odrNotaCredito In dtNotaCredito.Rows

                Dim oNotaCredito As NotaCredito
                oNotaCredito = Nothing
                oNotaCredito = oNotaCreditoMgr.Create
                oNotaCredito = oNotaCreditoMgr.Load(odrNotaCredito("NotaCreditoID"))

                oNotaCredito.PlayerID = odrNotaCredito("CodVendedor")
                oNotaCredito.AlmacenID = odrNotaCredito("CodAlmacen")
                oNotaCredito.ClienteID = odrNotaCredito("Clienteid")
                oNotaCredito.TipoVentaID = odrNotaCredito("CodTipoVenta")

                oNotaCredito.Detalle = ReadSQLNotasCreditoDetalle(odrNotaCredito("NotaCreditoID")).Copy
                '---------------------------------------------------------------------------------------------------------
                'Registrar en la ZBAPISD17_DEV_VENTAS
                '---------------------------------------------------------------------------------------------------------
                oNotaCreditoMgr.ZBAPISD17_DEV_VENTAS(oNotaCredito, String.Empty)

                If oNotaCredito.SALESDOCUMENT <> "" And oNotaCredito.FIDOCUMENT <> "" Then
                    SaveFISDNotaCredito(odrNotaCredito("NotaCreditoID"), oNotaCredito.FIDOCUMENT, oNotaCredito.SALESDOCUMENT)
                    '---------------------------------------------------------------------------------------------------------
                    'Actualizamos el FolioSAP en el cupon de descuento en caso de que exista en la factura de la devolucion
                    '---------------------------------------------------------------------------------------------------------
                    ActualizaFolioSAPEnCupon(oNotaCredito.SALESDOCUMENT, odrNotaCredito("NotaCreditoID"))
                    '-----------------------------------------------------------------------------------------------------------------
                    'Guardamos relacion cliente - devolucion en el servidor PG
                    '-----------------------------------------------------------------------------------------------------------------
                    If oParent.ConfigSaveArchivos.UsarHuellas Then
                        Try
                            Dim oFacturaMgr As New FacturaManager(oParent.ApplicationContext)
                            Dim oFingerPMgr As New FingerPrintManager(oParent.ApplicationContext, oParent.ConfigSaveArchivos)
                            If oNotaCredito.SALESDOCUMENT.Trim <> "" AndAlso oFingerPMgr.SaveClienteDevolucion(oNotaCredito, oNotaCredito.FolioSAP) Then
                                oFacturaMgr.ActualizaStatusEnvioServerPG(oNotaCredito.SALESDOCUMENT, 3)
                            End If
                        Catch ex As Exception
                        End Try
                    End If
                End If

                oNotaCredito = Nothing

            Next

        Catch ex As Exception
            Throw New ApplicationException(ex.Message, ex)
        End Try
    End Function

    Private Sub ActualizaFolioSAPEnCupon(ByVal FolioSAP As String, ByVal NotaCreditoID As Integer)
        Dim oFacturaMgr As New FacturaManager(oParent.ApplicationContext)
        Dim strFolioCupon As String = ""

        strFolioCupon = oFacturaMgr.GetReCuponDescuento(NotaCreditoID)
        If strFolioCupon.Trim <> "" Then
            Dim RestService As New ProcesosRetail("pos/cupon", "POST", oParent.ConfigSaveArchivos, oParent.ApplicationContext, oParent.SAPApplicationConfig)
            RestService.SapZcupRecuponUtilizable(strFolioCupon, FolioSAP)
            'oSAPMgr.ZBAPI_ACTUALIZA_RECUPON(strFolioCupon, FolioSAP)
        End If

    End Sub


#End Region

#Region "1.- Mandar a SAP Apartados No Registrados"

    'Este es para el Desbloqueo de Mercancia al liquidar apartado
    Public Function ReadSQLApartadosDetallesLiquids(ByVal intApartadoID As Integer) As DataTable

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaContrato As SqlDataAdapter
        Dim dsContrato As DataSet

        sccmdSelectAll = New SqlCommand
        scdaContrato = New SqlDataAdapter
        dsContrato = New DataSet("ApartadosDetalles")

        With sccmdSelectAll

            .Connection = sccnnConnection
            .CommandText = "[ApartadosDetallesSelByFolioApartado]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ApartadoID", System.Data.SqlDbType.Int))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@fecha", System.Data.SqlDbType.DateTime))
            '-------------------------------------------------------------------------------------------------------
            'JNAVA 31.07.2014: Se agrego el parametro para filtro por caja
            '-------------------------------------------------------------------------------------------------------
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar))
            .Parameters("@CodCaja").Value = oParent.ApplicationContext.ApplicationConfiguration.NoCaja
            '-------------------------------------------------------------------------------------------------------
            .Parameters("@ApartadoID").Value = intApartadoID
            .Parameters("@fecha").Value = Date.Now
        End With

        Try
            sccnnConnection.Open()

            scdaContrato.SelectCommand = sccmdSelectAll

            'Fill DataSet
            scdaContrato.Fill(dsContrato, "ApartadosDetalles")

            sccnnConnection.Close()

        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException(oSqlException.Message, oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException(ex.Message, ex)

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return dsContrato.Tables(0)

    End Function

    Public Function ReadSQLApartadosDetalles(ByVal intApartadoID As Integer) As DataTable

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaContrato As SqlDataAdapter
        Dim dsContrato As DataSet

        sccmdSelectAll = New SqlCommand
        scdaContrato = New SqlDataAdapter
        dsContrato = New DataSet("ApartadosDetalles")

        With sccmdSelectAll

            .Connection = sccnnConnection
            .CommandText = "[ApartadosDetallesSelSAP]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ApartadoID", System.Data.SqlDbType.Int))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@fecha", System.Data.SqlDbType.DateTime))
            .Parameters("@ApartadoID").Value = intApartadoID
            .Parameters("@fecha").Value = Date.Now
        End With

        Try
            sccnnConnection.Open()

            scdaContrato.SelectCommand = sccmdSelectAll

            'Fill DataSet
            scdaContrato.Fill(dsContrato, "ApartadosDetalles")

            sccnnConnection.Close()

        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException(oSqlException.Message, oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException(ex.Message, ex)

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return dsContrato.Tables(0)

    End Function

    Public Function ReadSQLApartadosSinRegSAP() As DataTable

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaContrato As SqlDataAdapter
        Dim dsContrato As DataSet

        sccmdSelectAll = New SqlCommand
        scdaContrato = New SqlDataAdapter
        dsContrato = New DataSet("Apartados")

        With sccmdSelectAll

            .Connection = sccnnConnection
            .CommandText = "[ApartadosDocfiEmptySel]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@fecha", System.Data.SqlDbType.DateTime))
            .Parameters("@fecha").Value = Date.Now
        End With

        Try
            sccnnConnection.Open()

            scdaContrato.SelectCommand = sccmdSelectAll

            'Fill DataSet
            scdaContrato.Fill(dsContrato, "Apartados")

            sccnnConnection.Close()

        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException(oSqlException.Message, oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException(ex.Message, ex)

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return dsContrato.Tables("Apartados")

    End Function

    Private Sub CreaEstructuraNegados(ByRef dtNegados As DataTable)

        dtNegados = New DataTable("Negados")

        With dtNegados
            .Columns.Add(New DataColumn("Codigo", GetType(String)))
            .Columns.Add(New DataColumn("Talla", GetType(String)))
            .Columns.Add(New DataColumn("Cantidad", GetType(Integer)))
            .Columns.Add(New DataColumn("Negados", GetType(Integer)))
            .Columns.Add(New DataColumn("Motivo", GetType(String)))
            .Columns.Add(New DataColumn("MotivoDesc", GetType(String)))
            .Columns.Add(New DataColumn("PedidoEC", GetType(String)))
            .AcceptChanges()
        End With

    End Sub

    Private Function NegarMaterialesPedidosEC(ByVal dtMateriales As DataTable) As DataTable

        Dim oRow As DataRow
        Dim dtPed As DataTable
        Dim dtPedDet As DataTable
        'Dim dtTrasModif As DataTable
        Dim oFacturaTemp As Factura
        Dim dtNegados As DataTable
        Dim oNewRow As DataRow
        Dim Talla As String = ""
        Dim oFacturaMgr As New FacturaManager(oParent.ApplicationContext, oParent.ConfigSaveArchivos)

        dtPed = oSAPMgr.ZPOL_TRASLPEN(oSAPMgr.Read_Centros, dtPedDet) ', dtTrasModif)

        If dtPed.Rows.Count > 0 AndAlso dtPedDet.Rows.Count > 0 Then
            Dim dvPedidoDet As DataView

            CreaEstructuraNegados(dtNegados)

            For Each oRow In dtMateriales.Rows
                For Each oRowP As DataRow In dtPed.Rows
                    If CStr(oRowP!Status).Trim.ToUpper = "P" Then
                        dvPedidoDet = New DataView(dtPedDet, "Folio_Pedido = '" & CStr(oRowP!Folio_Pedido).Trim & "'", "", DataViewRowState.CurrentRows)
                        For Each oRowPD As DataRowView In dvPedidoDet
                            If CInt(oRowPD!Cant_Pendiente) <= 0 Then GoTo SiguienteMaterial
                            If IsNumeric(oRow!Numero) Then
                                Talla = Format(CDec(oRow!Numero), "#.0")
                            Else
                                Talla = CStr(oRow!Numero).Trim
                            End If
                            If CStr(oRowPD!Material).Trim.ToUpper = CStr(oRow!CodArticulo).Trim.ToUpper AndAlso CStr(oRowPD!Talla).Trim.ToUpper = Talla.Trim.ToUpper Then
                                If IsNumeric(Talla) AndAlso InStr(Talla.Trim, ".0") > 0 Then
                                    Talla = CInt(oRow!Numero)
                                Else
                                    Talla = CStr(oRow!Numero).Trim
                                End If
                                oFacturaTemp = oFacturaMgr.Create()
                                oFacturaMgr.GetExistenciaArticulo(CStr(oRow!CodArticulo).Trim, oParent.ApplicationContext.ApplicationConfiguration.Almacen, Talla.Trim, oFacturaTemp)
                                If oFacturaTemp.FacturaArticuloExistencia - oRow!Cantidad < CInt(oRowPD!Cant_Pendiente) Then
                                    oNewRow = dtNegados.NewRow
                                    With oNewRow
                                        !Codigo = CStr(oRowPD!Material).Trim
                                        !Talla = CStr(oRowPD!Talla).Trim
                                        !Cantidad = 0
                                        !Negados = CInt(oRowPD!Cant_Pendiente) - (oFacturaTemp.FacturaArticuloExistencia - oRow!Cantidad)
                                        !Motivo = "00011"
                                        !MotivoDesc = "Apartado"
                                        !PedidoEC = CStr(oRowP!Folio_Pedido).Trim
                                    End With
                                    dtNegados.Rows.Add(oNewRow)
                                End If
                                oFacturaTemp = Nothing
                                GoTo Siguiente
                            End If
SiguienteMaterial:
                        Next
                    End If
                Next
Siguiente:
            Next
        End If

        Return dtNegados

    End Function

    Private Sub ValidarCambioStatusPedido(ByVal dtNegados As DataTable, ByVal Responsable As String)

        Dim dtPed As DataTable
        Dim dtPedDet As DataTable
        'Dim dtTrasModif As DataTable
        Dim oRowN As DataRow, oRowP As DataRow
        Dim Pedidos As String = ""
        Dim dvPedDet As DataView

        dtPed = oSAPMgr.ZPOL_TRASLPEN(oSAPMgr.Read_Centros, dtPedDet) ', dtTrasModif)

        For Each oRowN In dtNegados.Rows
            If InStr(Pedidos.Trim.ToUpper, CStr(oRowN!PedidoEC).Trim.ToUpper) <= 0 Then
                Pedidos &= CStr(oRowN!PedidoEC).Trim.ToUpper & ","
                dvPedDet = New DataView(dtPedDet, "Folio_Pedido = '" & CStr(oRowN!PedidoEC).Trim & "' And (Cant_Pendiente > 0 Or Cant_Entregado > 0)", "", DataViewRowState.CurrentRows)
                'dvPedDet = New DataView(dtPedDet, "Folio_Pedido = '" & CStr(oRowN!PedidoEC).Trim & "' And Cant_Pendiente > 0", "", DataViewRowState.CurrentRows)
                If dvPedDet.Count <= 0 Then
                    oSAPMgr.ZPOL_ACTTRASL(CStr(oRowN!PedidoEC).Trim, "", "N", "", Responsable.Trim, Nothing, "")
                End If
            End If
        Next

    End Sub

    Public Function Write_ApartadosSAPNoReg()
        Try
            Dim odrApartados As DataRow
            Dim dtApartados As DataTable
            Dim strRDocfic As String
            Dim dtDetalleA As DataTable

            'La tabla de todos los que encontro
            dtApartados = ReadSQLApartadosSinRegSAP()

            For Each odrApartados In dtApartados.Rows

                'Registrar en la ZBAPIMM13
                dtDetalleA = ReadSQLApartadosDetalles(odrApartados("ApartadoID"))
                strRDocfic = oSAPMgr.Write_RegistroApartado(odrApartados("Contrato"), dtDetalleA)

                If strRDocfic.Trim <> "" Then
                    'Se actualiza el DOCFI
                    oContratoMngr.SetDocFi(odrApartados("ApartadoID"), strRDocfic, odrApartados("Contrato"))
                    '--------------------------------------------------------------------------------------------------------------------------------------------------
                    'Revisamos si hay codigos por negar a los pedidos solicitados por el Ecommerce en el detalle del apartado
                    '--------------------------------------------------------------------------------------------------------------------------------------------------
                    Dim dtNegados As DataTable
                    Dim UserNameNiega As String = ""
                    dtNegados = NegarMaterialesPedidosEC(dtDetalleA)
                    If Not dtNegados Is Nothing AndAlso dtNegados.Rows.Count > 0 Then
                        UserNameNiega = oParent.ApplicationContext.Security.CurrentUser.Name
                        '--------------------------------------------------------------------------------------------------------------------------
                        'Se niegan los codigos de los pedidos de Ecommerce en caso de ser necesario
                        '--------------------------------------------------------------------------------------------------------------------------
                        oSAPMgr.ZPOL_TRASL_NEGAR(strRDocfic, "AP", UserNameNiega, dtNegados)
                        ValidarCambioStatusPedido(dtNegados, UserNameNiega)
                    End If
                    '--------------------------------------------------------------------------------------------------------------------------------------------------
                    'Validamos si los codigos del apartado estan marcados como defectuosos para Ecommerce
                    '--------------------------------------------------------------------------------------------------------------------------------------------------
                    Dim dtDefectuososEC As DataTable

                    dtDefectuososEC = oFacturaMgr.GetCondigosBajaCalidad(odrApartados("FolioApartado"), oParent.ApplicationContext.ApplicationConfiguration.NoCaja, "CA")

                    If Not dtDefectuososEC Is Nothing AndAlso dtDefectuososEC.Rows.Count > 0 Then
                        If oSAPMgr.ZPOL_DEFECTUOSOS_INS(strRDocfic, "DD", oParent.ApplicationContext.Security.CurrentUser.Name, dtDefectuososEC).Trim = "Y" Then
                            oFacturaMgr.BorrarCodigosBajaCalidad(odrApartados("FolioApartado"), oParent.ApplicationContext.ApplicationConfiguration.NoCaja, "CA")
                        End If
                    End If

                End If

            Next

        Catch ex As Exception
            Throw New ApplicationException(ex.Message, ex)
        End Try
    End Function

#End Region

#Region "2.- Mandar a SAP Abonos Apartados no Registrados "

    Public Function Write_AbonosApartadosSAPNoReg()
        Try
            Dim odrAbonos As DataRow
            Dim dtAbanos As DataTable
            Dim strRDocfic As String
            Dim strFolioAbono As String
            Dim dblAbono As Double
            Dim strClienteId As String
            Dim strContrato As String
            Dim strTipoPago As String
            Dim strTienda As String
            Dim strDivision As String
            Dim strTipoMov As String
            Dim strNoAfil As String

            dtAbanos = ReadSQLAbonosApartadosSinRegSAP()

            For Each odrAbonos In dtAbanos.Rows

                'Tipo Movimiento Abono AB
                strFolioAbono = CStr(CInt(odrAbonos("FolioAbono"))).PadLeft(10, "0")
                dblAbono = CDbl(odrAbonos("Abono"))
                strClienteId = odrAbonos("ClienteID")
                strContrato = odrAbonos("Contrato")
                strTipoMov = odrAbonos("TipoMov")

                If odrAbonos("CodFormaPago") = "EFEC" Then
                    strTipoPago = "EFECTIVO"
                Else
                    If odrAbonos("CodBanco") = "T1" Then
                        strTipoPago = "TARJETA 1"
                    ElseIf odrAbonos("CodBanco") = "T2" Then
                        strTipoPago = "TARJETA 2"
                    ElseIf odrAbonos("CodBanco") = "T3" Then
                        strTipoPago = "TARJETA 3"
                    ElseIf odrAbonos("CodFormaPago") = "DPCA" Then 'JNAVA (13.03.2015): Agregamos datos de cuenta de DP Card para realizar los DZ correspondientes
                        strTipoPago = "TARJETA 4"
                    End If
                End If

                strTienda = oAbonosApartadosMgr.SelectNombreTienda(strTipoPago, oSAPMgr.Read_Centros)
                strDivision = oAbonosApartadosMgr.SelectDivision(strTipoPago, oSAPMgr.Read_Centros)
                strNoAfil = odrAbonos("NoAfiliacion")
                'Registrar en ZBAPIFI02
                strRDocfic = oSAPMgr.Write_Anticipoapartado(strFolioAbono, dblAbono, strClienteId, strContrato, strTipoMov, strTienda, strTipoPago, strDivision, oParent.ApplicationContext.ApplicationConfiguration.Almacen, strNoAfil)

                If strRDocfic <> "" Then
                    'Se actualiza el DOCFI
                    oAbonosApartadosMgr.ActualizaDocFI(strFolioAbono, strRDocfic)
                End If

            Next
        Catch ex As Exception
            Throw New ApplicationException(ex.Message, ex)
        End Try

    End Function

    Public Function ReadSQLAbonosApartadosSinRegSAP() As DataTable

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaContrato As SqlDataAdapter
        Dim dsContrato As DataSet

        sccmdSelectAll = New SqlCommand
        scdaContrato = New SqlDataAdapter
        dsContrato = New DataSet("Apartados")

        With sccmdSelectAll

            .Connection = sccnnConnection
            .CommandText = "[AbonosApartadosSelDocFiEmpty]"
            .CommandType = System.Data.CommandType.StoredProcedure

        End With

        Try
            sccnnConnection.Open()

            scdaContrato.SelectCommand = sccmdSelectAll

            'Fill DataSet
            scdaContrato.Fill(dsContrato, "Abonos")

            sccnnConnection.Close()

        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException(oSqlException.Message, oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException(ex.Message, ex)

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return dsContrato.Tables("Abonos")

    End Function

#End Region

    'Primero Mandar llamar este que el Abonos Cancelados
#Region "3.- Mandar a SAP Apartados Cancelados no Registrados"

    Private Function ReadSQLAbonosApartadosCancelar(ByVal intAbonoid As Integer) As DataTable

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaContrato As SqlDataAdapter
        Dim dsContrato As DataSet

        sccmdSelectAll = New SqlCommand
        scdaContrato = New SqlDataAdapter
        dsContrato = New DataSet("Abonosss")

        With sccmdSelectAll

            .Connection = sccnnConnection
            .CommandText = "[AbonosApartadosSelAparatadoId]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ApartadoID", System.Data.SqlDbType.VarChar, 4))

        End With

        Try
            sccnnConnection.Open()

            sccmdSelectAll.Parameters("@ApartadoID").Value = intAbonoid

            scdaContrato.SelectCommand = sccmdSelectAll

            'Fill DataSet
            scdaContrato.Fill(dsContrato, "Abonos")

            sccnnConnection.Close()

        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException(oSqlException.Message, oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException(ex.Message, ex)

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return dsContrato.Tables("Abonos")

    End Function

    Public Function ReadSQLApartadosCanceladosSinRegSAP() As DataTable

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaContrato As SqlDataAdapter
        Dim dsContrato As DataSet

        sccmdSelectAll = New SqlCommand
        scdaContrato = New SqlDataAdapter
        dsContrato = New DataSet("ApartadosCancel")

        With sccmdSelectAll

            .Connection = sccnnConnection
            .CommandText = "[ApartadosCancelSelDocFiCancEmpty]"
            .CommandType = System.Data.CommandType.StoredProcedure

        End With

        Try
            sccnnConnection.Open()

            scdaContrato.SelectCommand = sccmdSelectAll

            'Fill DataSet
            scdaContrato.Fill(dsContrato, "ApartadosCancel")

            sccnnConnection.Close()

        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException(oSqlException.Message, oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException(ex.Message, ex)

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return dsContrato.Tables("ApartadosCancel")

    End Function

    Public Function Write_ApartadosCanceladosSAPNoReg()
        Try
            Dim odrApartados As DataRow
            Dim odrAbonos As DataRow
            Dim dtApartadosCancelar As DataTable
            Dim dtAbonosCancelar As DataTable
            Dim band As Boolean = True
            Dim strDOCNUMFB01 As String
            Dim strArr(2) As String
            Dim decDev As Decimal
            Dim strDocFi As String
            Dim intNumReg As Integer
            'Dim strTienda As String
            Dim decPena As Decimal


            'Obtener la Tabla con los Apartados cancelados no Registrado en SAP
            dtApartadosCancelar = ReadSQLApartadosCanceladosSinRegSAP()

            For Each odrApartados In dtApartadosCancelar.Rows
                'Obtener la tabla con todos los Abonos del Apartado
                dtAbonosCancelar = ReadSQLAbonosApartadosCancelar(odrApartados("ApartadoID"))

                intNumReg = dtAbonosCancelar.Rows.Count
                decPena = Math.Round(odrApartados("Importe") * 0.1, 2)

                'Pa que puse este????
                ''strTienda = oAbonosApartadosMgr.SelectNombreTienda(odrAbonos("ClaCobr"), oSAPMgr.Read_Centros)

                For Each odrAbonos In dtAbonosCancelar.Rows
                    If odrAbonos("DocFi") = "" Then
                        MsgBox("No se Puede Cancelar este Apartado, por que algun Abono" & Chr(10) & Chr(13) & " no esta Registrado en SAP", MsgBoxStyle.Critical, "Error Registrar Cancelacion de Apartado en SAP")
                        Exit For
                        band = False
                    End If

                    strArr = Split(oDistribucionNCMgr.SelectNombreTiendaBanco(odrAbonos("ClaCobr"), oDistribucionNCMgr.SelectCentro), "#", , CompareMethod.Text)
                    decDev = Math.Abs(odrAbonos("Abono") - (Math.Round((decPena / intNumReg), 2)))
                    'Para cancelacion de abono no se cobra penalidad
                    strDOCNUMFB01 = oSAPMgr.Write_CancelaApartado(odrAbonos("ClienteID"), odrAbonos("Abono"), Math.Round((decPena / intNumReg), 2), _
                                                                    strArr(0), "X", decDev, odrAbonos("DocFi"), strArr(1), odrAbonos("ClaCobr"))
                    If strDOCNUMFB01 <> "" Then
                        oDistribucionNCMgr.ActualizaDOCNUMFB01xFolioAbono(odrAbonos("FolioAbono"), strDOCNUMFB01)
                    End If
                Next
                If band Then
                    'Guarda el contrato en sap 
                    strDocFi = oSAPMgr.Write_DesbloqueApartado(odrApartados("Contrato"), ReadSQLApartadosDetalles(odrApartados("ApartadoID")))

                    If strDocFi <> "" Then
                        oContratoMngr.SetDocFiCancelacion(odrApartados("ApartadoID"), strDocFi)
                    End If
                Else
                    'No se puede registrar
                End If
            Next
        Catch ex As Exception
            Throw New ApplicationException(ex.Message, ex)
        End Try

    End Function

#End Region

#Region "4.- Mandar a SAP Abonos Apartados Cancelados no Registrados"

    Public Function ReadSQLAbonosApartadosCanceladosSinRegSAP() As DataTable

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaContrato As SqlDataAdapter
        Dim dsContrato As DataSet

        sccmdSelectAll = New SqlCommand
        scdaContrato = New SqlDataAdapter
        dsContrato = New DataSet("AbonosCancel")

        With sccmdSelectAll

            .Connection = sccnnConnection
            .CommandText = "[AbonosApartadosCancelSelDocNumFB01Empty]"
            .CommandType = System.Data.CommandType.StoredProcedure

        End With

        Try
            sccnnConnection.Open()

            scdaContrato.SelectCommand = sccmdSelectAll

            'Fill DataSet
            scdaContrato.Fill(dsContrato, "AbonosCancel")

            sccnnConnection.Close()

        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException(oSqlException.Message, oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException(ex.Message, ex)

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return dsContrato.Tables("AbonosCancel")

    End Function

    Public Function Write_AbonosApartadosCanceladosSAPNoReg()
        Try
            Dim odrAbonos As DataRow
            Dim dtAbanosCancelados As DataTable

            dtAbanosCancelados = ReadSQLAbonosApartadosCanceladosSinRegSAP()


            For Each odrAbonos In dtAbanosCancelados.Rows


                Dim DOCNUMFB01 As String
                Dim strTienda As String
                strTienda = oAbonosApartadosMgr.SelectNombreTienda(odrAbonos("ClaCobr"), oSAPMgr.Read_Centros)
                'Para cancelacion de abono no se cobra penalidad
                DOCNUMFB01 = oSAPMgr.Write_CancelaApartado(odrAbonos("ClienteID"), odrAbonos("Abono"), 0, strTienda, "", odrAbonos("Abono"), odrAbonos("DocFi"), "", "")

                If DOCNUMFB01 <> "" Then
                    oCancelaAbonosMgr.ActualizaDOCNUMFB01(odrAbonos("FolioAbono"), DOCNUMFB01)
                End If

            Next
        Catch ex As Exception
            Throw New ApplicationException(ex.Message, ex)
        End Try

    End Function

#End Region

#Region "AbonosCDT no Registrados en SAP"

    Public Function ReadSQLAbonosCDTSinRegSAP() As DataTable

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaContrato As SqlDataAdapter
        Dim dsContrato As DataSet

        sccmdSelectAll = New SqlCommand
        scdaContrato = New SqlDataAdapter
        dsContrato = New DataSet("AbonosCDT")

        With sccmdSelectAll

            .Connection = sccnnConnection
            .CommandText = "[AbonosCDTSelSAPEmpty]"
            .CommandType = System.Data.CommandType.StoredProcedure

        End With

        Try
            sccnnConnection.Open()

            scdaContrato.SelectCommand = sccmdSelectAll

            'Fill DataSet
            scdaContrato.Fill(dsContrato, "AbonosCDT")

            sccnnConnection.Close()

        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException(oSqlException.Message, oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException(ex.Message, ex)

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return dsContrato.Tables("AbonosCDT")

    End Function

    Public Function Write_AnonosCDTSAPNoReg()
        Try
            Dim odrAbonosCDT As DataRow
            Dim dtAbonosCDT As DataTable
            Dim strRDocfic(2) As String

            '----------------Numero de Referencia---------------
            Dim numref As New NumeroReferencia.cNumReferencia
            Dim strNumRef As String = numref.getNumReferencia(oParent.ApplicationContext.ApplicationConfiguration.Almacen.PadLeft(4, "0"), CStr(Format(Date.Now.Date, "ddMMyyyy")))
            '------------------------------------------------------

            'La tabla de todos los que encontro
            dtAbonosCDT = ReadSQLAbonosCDTSinRegSAP()

            For Each odrAbonosCDT In dtAbonosCDT.Rows
                'Registra en BAPI FI06
                strRDocfic = oSAPMgr.Write_ZBAPIFI06_REG_ABONO_PAGO_VENTA(odrAbonosCDT("Tienda"), odrAbonosCDT("ClienteID"), _
                                                                            odrAbonosCDT("Abono"), odrAbonosCDT("FacturaSAP"), _
                                                                            odrAbonosCDT("ClabCobr"), odrAbonosCDT("Banco"), _
                                                                            odrAbonosCDT("FacturaDP"), " ", strNumRef)

                If strRDocfic(0) <> "" And strRDocfic(1) <> "" Then
                    'Se actualiza el DOCFI
                    UpdateAbonosCDTSAP(odrAbonosCDT("FacturaSAP"), odrAbonosCDT("ClienteID"), strRDocfic(0), strRDocfic(1), odrAbonosCDT("Abono"))
                Else
                    'No se volvio a grabar
                End If

            Next

        Catch ex As Exception
            Throw New ApplicationException(ex.Message, ex)
        End Try
    End Function

    Private Sub UpdateAbonosCDTSAP(ByVal strFacturaFI As String, ByVal strClienteID As String, ByVal strFB05 As String, ByVal strFB01 As String, ByVal dcAbono As Decimal)

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                                 DataStorageConfiguration.GetConnectionString)

        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand

        With sccmdInsert

            .Connection = sccnnConnection

            .CommandText = "[AbonosCDTUpdSAP]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .CommandType = CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ClienteID", System.Data.SqlDbType.VarChar, 10))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FacturaSAP", System.Data.SqlDbType.VarChar, 10))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@DocnumFB05", System.Data.SqlDbType.VarChar, 15))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@DocnumFB01", System.Data.SqlDbType.VarChar, 15))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Abono", System.Data.SqlDbType.Money, 8))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime, 8))

        End With

        Try

            sccnnConnection.Open()

            With sccmdInsert

                'Assign Parameters Values

                .Parameters("@ClienteID").Value = strClienteID
                .Parameters("@FacturaSAP").Value = strFacturaFI
                .Parameters("@DocnumFB05").Value = strFB05
                .Parameters("@DocnumFB01").Value = strFB01
                .Parameters("@Abono").Value = dcAbono
                .Parameters("@Fecha").Value = Format(Date.Now, "Short Date")


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


#End Region

#Region "Obtener Numero de Contrato por el Apartado ID"

    Public Function SelectContratoFromApartadoID(ByVal ID As Integer) As Integer

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        Dim FolioApartado As Integer


        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[ApartadoIDSelFromID]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ApartadoID", System.Data.SqlDbType.Int, 4))

            'OutPut :
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioApartado", System.Data.SqlDbType.Int))
            .Parameters("@FolioApartado").Direction = ParameterDirection.Output

        End With


        Try

            sccnnConnection.Open()

            With sccmdSelect

                'Assign Parameters Values
                .Parameters("@ApartadoID").Value = ID
                .Parameters("@FolioApartado").Value = 0

                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    With scdrReader

                        'Return .GetDecimal(0)
                        FolioApartado = .GetInt32(0)

                    End With

                Else

                    scdrReader.Close()
                    sccnnConnection.Close()

                    FolioApartado = 0

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


        Return FolioApartado

    End Function

#End Region

#Region " Proyecto SiHay "

    '-------------------------------------------------------------------------------------------------
    ' JNAVA (04/06/2013): Funcion para obtener las fechas de las citas segun el folio del pedido
    '-------------------------------------------------------------------------------------------------
    Public Function GetFechaCitaSiHayByFolioPedido(ByVal Pedido As String) As Date

        Dim oResult As DataSet
        Dim FechaCitaSH As Date

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)
        Dim sccmdSelect As SqlCommand
        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[ConcretarCitaSHSelByFolioPedido]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioPedido", System.Data.SqlDbType.VarChar, 10, "FolioPedido"))

            'Assign Parameters Values
            .Parameters("@FolioPedido").Value = Pedido.Trim

        End With

        Dim oPedidosAdapter As New SqlDataAdapter
        oPedidosAdapter.SelectCommand = sccmdSelect

        Try

            sccnnConnection.Open()
            oResult = New DataSet
            oPedidosAdapter.Fill(oResult, "CitasSiHay")

            If oResult.Tables(0).Rows.Count > 0 Then
                FechaCitaSH = CDate(oResult.Tables(0).Rows(0).Item("FechaCita"))
            Else
                FechaCitaSH = Date.MinValue
            End If

        Catch ex As Exception

            Throw ex

        Finally

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

        End Try

        sccmdSelect.Dispose()
        sccmdSelect = Nothing

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return FechaCitaSH

    End Function

    '-------------------------------------------------------------------------------------------------
    ' JNAVA (19/06/2013): Funcion para obtener los pedidos cancelados segun la fecha ingresada
    '-------------------------------------------------------------------------------------------------
    Public Function GetPedidosCanceladosSiHayByFecha(ByVal Fecha As DateTime) As DataTable
        Dim oResult As DataSet
        'Dim htPedidosCanceladosSH As New Hashtable

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)
        Dim sccmdSelect As SqlCommand
        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[PedidosCanceladosSelByDate]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@EnableRecords", System.Data.SqlDbType.Bit, 1, "EnableRecords"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime, 8, "Fecha"))

            'Assign Parameters Values
            .Parameters("@EnableRecords").Value = False
            .Parameters("@Fecha").Value = Fecha

        End With

        Dim oPedidosAdapter As New SqlDataAdapter
        oPedidosAdapter.SelectCommand = sccmdSelect

        Try

            sccnnConnection.Open()
            oResult = New DataSet
            oPedidosAdapter.Fill(oResult, "PedidosCanceladosSiHay")

            'If oResult.Tables(0).Rows.Count > 0 Then
            '    Dim i As Integer = 0
            '    For Each oRow As DataRow In oResult.Tables(0).Rows
            '        htPedidosCanceladosSH(i) = oRow!PedidoID
            '        i += 1
            '    Next
            'Else
            '    htPedidosCanceladosSH = Nothing
            'End If

            sccnnConnection.Close()

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw ex

        Finally

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

        End Try

        sccmdSelect.Dispose()
        sccmdSelect = Nothing

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return oResult.Tables(0)

    End Function

    Public Function GetPedidosSiHaySinFolioSAP(ByVal Fecha As DateTime) As DataTable
        Dim oResult As DataSet
        'Dim htPedidosCanceladosSH As New Hashtable

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)
        Dim sccmdSelect As SqlCommand
        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[CierreDiaPedidosSHSinFolioSAP]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime, 8, "Fecha"))

            'Assign Parameters Values
            .Parameters("@Fecha").Value = Fecha

        End With

        Dim oPedidosAdapter As New SqlDataAdapter
        oPedidosAdapter.SelectCommand = sccmdSelect

        Try

            sccnnConnection.Open()
            oResult = New DataSet
            oPedidosAdapter.Fill(oResult, "PedidosSiHaySinFolioSAP")

            sccnnConnection.Close()

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw ex

        Finally

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

        End Try

        sccmdSelect.Dispose()
        sccmdSelect = Nothing

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return oResult.Tables(0)

    End Function

    '---------------------------------------------------------------------------------------------------------------------------------------------------------
    'JNAVA (21/06/2013): FUNCION PARA COMPENSAR PEDIDOS SI HAY - ZSH_COMPENSAR()
    '---------------------------------------------------------------------------------------------------------------------------------------------------------
    Public Function CompensarPedidosSiHayOld(ByVal FechaCierre As DateTime, ByVal viewFilter As DataView, ByVal datos As Dictionary(Of String, Object)) As String
        Dim strReturn As String = ""
        Try
            'Dim RestService As New ProcesosRetail("/pos/sh", "POST", oParent.ConfigSaveArchivos, oParent.ApplicationContext, oParent.SAPApplicationConfig)
            'Dim result As Dictionary(Of String, Object)
            'result = RestService.SapZshCompensar(oSAPMgr.Read_Centros())
            'strReturn = CStr(result("E_Error"))
            strReturn = oSAPMgr.ZSH_COMPENSAR(FechaCierre, viewFilter, datos)
        Catch ex As Exception
            Throw ex
        End Try
        Return strReturn
    End Function

    '---------------------------------------------------------------------------------------------------------------------------------------------------------
    ' JNAVA (14.03.2017): FUNCION PARA COMPENSAR PEDIDOS SI HAY - ZBAPI_ABONO_CIERREDIA
    '---------------------------------------------------------------------------------------------------------------------------------------------------------
    Public Function CompensarPedidosSiHay(ByVal FechaCierre As Date, ByVal viewFilter As DataView, ByVal datos As Dictionary(Of String, Object)) As String
        Dim strMensaje As String = String.Empty
        Dim dt As New DataTable
        Try
            Dim oZBAPI_ABONO_CIERREDIA As ZBapiAbonoCierreDia
            Dim fila As DataRow = Nothing
            Dim rows() As DataRow = Nothing
            If viewFilter.Count > 0 Then
                oZBAPI_ABONO_CIERREDIA = New ZBapiAbonoCierreDia
                oZBAPI_ABONO_CIERREDIA.Tienda = CStr(datos("TIENDA"))
                oZBAPI_ABONO_CIERREDIA.MotivoPedido = CStr(datos("I_MOT_PED"))
                oZBAPI_ABONO_CIERREDIA.Fecha = FechaCierre.ToString("yyyyMMdd")
                oZBAPI_ABONO_CIERREDIA.i_Mode = "N"
                oZBAPI_ABONO_CIERREDIA.Devolucion = False
                oZBAPI_ABONO_CIERREDIA.SiHay = True
                For Each row As DataRowView In viewFilter
                    rows = oZBAPI_ABONO_CIERREDIA.Documents.Select("BSTNK='" & CStr(row("Referencia")) & "'")
                    If rows.Length = 0 Then
                        fila = oZBAPI_ABONO_CIERREDIA.Documents.NewRow()
                        fila("BSTNK") = CStr(row("Referencia"))
                        oZBAPI_ABONO_CIERREDIA.Documents.Rows.Add(fila)
                    End If
                Next
                oSAPMgr.WRITE_ZBAPI_ABONO_CIERREDIA(oZBAPI_ABONO_CIERREDIA, dt)
                Dim strError As String = ""
                For Each row As DataRow In dt.Rows
                    If dt.Columns.Contains("TYPE") Then
                        If row.IsNull("TYPE") = False Then
                            If CStr(row("TYPE")) = "E" Or CStr(row("TYPE")) = "W" Then
                                strError &= CStr(row("MESSAGE"))
                            End If
                        End If
                    End If
                Next
                If strError.Trim() <> "" Then
                    strMensaje &= strError & vbCrLf
                End If
                'For Each row As DataRow In oZBAPI_ABONO_CIERREDIA.FormasPago.Rows
                '    FacturaFI05ok(CInt(row("FPAGOID")))
                'Next
            End If

        Catch ex As Exception
            Throw ex
        End Try

        Return strMensaje

    End Function

    Public Function CompensarPedidosSiHayIndividual(ByVal FechaCierre As Date, ByVal viewFilter As DataView, ByVal datos As Dictionary(Of String, Object)) As String
        Dim ClienteId As String = ""
        Dim strMensaje As String = String.Empty
        Dim dt As New DataTable
        Try
            Dim oZBAPI_ABONO_CIERREDIA As ZBapiAbonoCierreDia
            Dim fila As DataRow = Nothing
            Dim rows() As DataRow = Nothing
            If viewFilter.Count > 0 Then
                For Each row As DataRowView In viewFilter
                    If ClienteId <> CStr(row("ClienteId")) Then
                        If ClienteId <> "" Then
                            oProcesosSAPMgr.WRITE_ZBAPI_ABONO_CIERREDIA(oZBAPI_ABONO_CIERREDIA, dt)
                            Dim strError As String = ""
                            For Each rowErr As DataRow In dt.Rows
                                If dt.Columns.Contains("TYPE") Then
                                    If rowErr.IsNull("TYPE") = False Then
                                        If CStr(rowErr("TYPE")) = "E" Or CStr(rowErr("TYPE")) = "W" Then
                                            strError &= CStr(rowErr("MESSAGE"))
                                        End If
                                    End If
                                End If
                            Next
                            If strError.Trim() <> "" Then
                                strMensaje &= strError & vbCrLf
                            End If
                            'For Each rowNota As DataRow In oZBAPI_ABONO_CIERREDIA.FormasPago.Rows
                            '    FacturaFI05ok(CInt(rowNota("FPAGOID")))
                            'Next
                        End If
                        ClienteId = CStr(row("ClienteId"))
                        oZBAPI_ABONO_CIERREDIA = New ZBapiAbonoCierreDia
                        oZBAPI_ABONO_CIERREDIA.Tienda = CStr(datos("TIENDA"))
                        oZBAPI_ABONO_CIERREDIA.MotivoPedido = CStr(datos("I_MOT_PED"))
                        oZBAPI_ABONO_CIERREDIA.Fecha = FechaCierre.ToString("yyyyMMdd")
                        oZBAPI_ABONO_CIERREDIA.i_Mode = "N"
                        oZBAPI_ABONO_CIERREDIA.Devolucion = False
                        oZBAPI_ABONO_CIERREDIA.SiHay = True
                    End If
                    rows = oZBAPI_ABONO_CIERREDIA.Documents.Select("BSTNK='" & CStr(row("Referencia")) & "'")
                    If rows.Length = 0 Then
                        fila = oZBAPI_ABONO_CIERREDIA.Documents.NewRow()
                        fila("BSTNK") = CStr(row("Referencia"))
                        oZBAPI_ABONO_CIERREDIA.Documents.Rows.Add(fila)
                    End If

                Next
                oProcesosSAPMgr.WRITE_ZBAPI_ABONO_CIERREDIA(oZBAPI_ABONO_CIERREDIA, dt)
                Dim strErr As String = ""
                For Each rowErr As DataRow In dt.Rows
                    If dt.Columns.Contains("TYPE") Then
                        If rowErr.IsNull("TYPE") = False Then
                            If CStr(rowErr("TYPE")) = "E" Or CStr(rowErr("TYPE")) = "W" Then
                                strErr &= CStr(rowErr("MESSAGE"))
                            End If
                        End If
                    End If
                Next
                If strErr.Trim() <> "" Then
                    strMensaje &= strErr & vbCrLf
                End If
                'For Each rowNota As DataRow In oZBAPI_ABONO_CIERREDIA.FormasPago.Rows
                '    FacturaFI05ok(CInt(rowNota("FPAGOID")))
                'Next
            End If

        Catch ex As Exception
            Throw ex
        End Try

        Return strMensaje

    End Function
#End Region

#Region "DPCARD"

    '----------------------------------------------------------------------------------------------------------------
    ' JNAVA (18.03.2015): Funcion para generar el TXT de los pagos DP CARD X Tipo Venta
    '----------------------------------------------------------------------------------------------------------------
    Private Function GetCobranzaDPCard(ByVal dvTarjeta As DataView, ByVal Cliente As String, ByVal CodTipoVenta As String, ByVal FechaCierre As Date, ByVal strNumRef As String, ByRef strNumRefBBV As String, ByVal strResult As String, ByRef strMensaje As String) As String

        Dim oZBAPI_ABONO_CIERREDIA As ZBapiAbonoCierreDia
        Dim dt As DataTable

        Dim FechaRefBancos As Date = FechaCierre
        Dim fecha As String = ""

        Dim intIndex As Integer
        '----------------------------------------------------------------------------------------------------------------------------------------
        'RGERMAIN 13.04.2015: Se agrego esta linea para que devuelva el valor que ya trae la funcion principal de donde se manda llamar, en caso
        '                     de no modificarse dentro de esta funcion
        '----------------------------------------------------------------------------------------------------------------------------------------
        GetCobranzaDPCard = strResult

        ''Pagos DPCA
        dvTarjeta.RowFilter = "CodFormasPago like 'DPCA' and CodTipoVenta='" & CodTipoVenta & "'"
        dvTarjeta.Sort = "FolioSAP"
        dvTarjeta.RowStateFilter = DataViewRowState.OriginalRows

        'txtWriter.WriteLine(Chr(13)) 

        If dvTarjeta.Count > 0 Then
            dt = New DataTable

            oZBAPI_ABONO_CIERREDIA = New ZBapiAbonoCierreDia

            oZBAPI_ABONO_CIERREDIA.Tienda = CStr(dvTarjeta(0)("Tienda")).PadRight(20, " ")

            oZBAPI_ABONO_CIERREDIA.Detalle = "X"

            'oZBAPI_ABONO_CIERREDIA.Ref_Banco = strNumRefBBV & FechaCierre.ToShortDateString.Replace("/", "")

            oZBAPI_ABONO_CIERREDIA.ClaCobr = "DPCARDCR".PadRight(9, " ")

            Dim dsBanco As New DataSet
            dsBanco = Me.BancoSel(oZBAPI_ABONO_CIERREDIA.Tienda, oZBAPI_ABONO_CIERREDIA.ClaCobr)
            If dsBanco.Tables(0).Rows.Count > 0 Then
                oZBAPI_ABONO_CIERREDIA.Banco = dsBanco.Tables(0).Rows(0).Item("Banco")
            Else
                oZBAPI_ABONO_CIERREDIA.Banco = ""
            End If

            oZBAPI_ABONO_CIERREDIA.i_FactDpPro = "X"

            oZBAPI_ABONO_CIERREDIA.i_Mode = "N"

            For intIndex = 0 To dvTarjeta.Count - 1
                '------------------------------------------------------------------------------------------------------
                ' JNAVA (19.03.2015): Verificamos si ya viene el cliente o no para obetenerlo segun el tipo de venta
                '------------------------------------------------------------------------------------------------------
                If CodTipoVenta = "D" Or CodTipoVenta = "S" Or CodTipoVenta = "I" Then
                    Cliente = CStr(dvTarjeta(intIndex)("ClienteID")).PadLeft(10, "0")
                ElseIf CodTipoVenta = "V" Then
                    '------------------------------------------------------------------------------------------------------
                    ' Verificamos si es DPVale para hacer obtener el cliente
                    '------------------------------------------------------------------------------------------------------
                    If Not Me.oParent.SAPApplicationConfig.DPValeSAP Then
                        Cliente = CStr(GetCodigoSAPAsoc(GetDpValeIDDP(CInt(dvTarjeta(intIndex)("FacturaID"))))).PadRight(10, " ")
                    Else
                        Dim strDpValeIDDP As String = CStr(GetDpValeIDDP(CInt(dvTarjeta(intIndex)("FacturaID"))))
                        Me.oDPVale.INUMVA = strDpValeIDDP
                        Me.oDPVale.I_RUTA = "X"

                        '--------------------------------------------------------------------------------------------
                        ' JNAVA (02.08.2016): Obtenemos la Info del DPVale 
                        '--------------------------------------------------------------------------------------------
                        'Me.oDPVale = oSAPMgr.ZBAPI_VALIDA_DPVALE(oDPVale)
                        Dim S2Credit As New ProcesosS2Credit(oParent)
                        If oParent.ConfigSaveArchivos.AplicarS2Credit Then
                            Me.oDPVale = S2Credit.ValidaDPVale(oDPVale)
                        Else
                            Me.oDPVale = oSAPMgr.ZBAPI_VALIDA_DPVALE(Me.oDPVale)
                        End If
                        '--------------------------------------------------------------------------------------------

                        Cliente = CStr(oDPVale.InfoDPVALE.Rows(0).Item("KUNNR")).PadRight(10, " ")
                    End If
                End If

                oZBAPI_ABONO_CIERREDIA.Cliente = Cliente

                'If CStr(dvTarjeta(0)("NoAfiliacion")).Length > 6 Then
                '    strNumRefBBV = Mid(CStr(dvTarjeta(intIndex)("NoAfiliacion")), 2)
                'Else
                strNumRefBBV = CStr(dvTarjeta(intIndex)("NoAfiliacion")).PadLeft(6, "0")
                'End If

                oZBAPI_ABONO_CIERREDIA.Ref_Banco = strNumRefBBV & Format(FechaRefBancos, "ddMMyyyy") '& _
                'Mid(Format(FechaCierre, "yyyy"), 2)
                fecha = CStr(CDate(dvTarjeta(intIndex)("Fecha")).ToShortDateString.Replace("/", ""))
                oZBAPI_ABONO_CIERREDIA.Fecha = Mid(fecha, 5, 4) & Mid(fecha, 3, 2) & Mid(fecha, 1, 2)
                oZBAPI_ABONO_CIERREDIA.Importe = CStr(dvTarjeta(intIndex)("Monto")).PadRight(16, " ")
                oZBAPI_ABONO_CIERREDIA.vBeln = CStr(dvTarjeta(intIndex)("FolioSAP")).PadLeft(10, "0")

                oProcesosSAPMgr = New ProcesoSAPManager(Me.oParent.ApplicationContext, Me.oParent.SAPApplicationConfig)
                strResult = oProcesosSAPMgr.WRITE_ZBAPI_ABONO_CIERREDIA(oZBAPI_ABONO_CIERREDIA, dt)

                If strResult = "Y" Then
                    'actualizar el campo FI05SAP
                    'FacturaFI05ok(oZBAPI_ABONO_CIERREDIA.vBeln, oZBAPI_ABONO_CIERREDIA.ClaCobr)
                Else
                    strMensaje += "FolioSAP: " & oZBAPI_ABONO_CIERREDIA.vBeln & vbCrLf
                    For Each orow As DataRow In dt.Rows
                        strMensaje += "Error: " & orow.Item("Message") & vbCrLf
                    Next
                    strMensaje += vbCrLf

                    GetCobranzaDPCard = "N"

                End If

                strResult = ""

            Next

        End If

    End Function

    Private Function RegistraPagosDPCardPuntosSAP(ByVal strCliente As String, ByVal CodFormaPago As String, ByVal CodTipoVenta As String, ByVal dvTarjetaUno As DataView, ByVal strNumRef As String, ByRef strResult As String) As String

        Dim oZBAPI_ABONO_CIERREDIA As ZBapiAbonoCierreDia
        Dim dt As DataTable, intIndex As Integer, fecha As String = "", strMensaje As String = "", strResultLocal As String = ""
        Dim strDpValeIDDP As String = ""

        dvTarjetaUno.RowFilter = "CodFormasPago like '" & CodFormaPago.Trim.ToUpper & "' and CodTipoVenta = '" & CodTipoVenta.Trim.ToUpper & "'"

        If dvTarjetaUno.Count > 0 Then
            dt = New DataTable

            oZBAPI_ABONO_CIERREDIA = New ZBapiAbonoCierreDia

            oZBAPI_ABONO_CIERREDIA.Tienda = CStr(dvTarjetaUno(0)("Tienda")).PadRight(20, " ")

            oZBAPI_ABONO_CIERREDIA.Cliente = strCliente.Trim.PadLeft(10, "0")

            oZBAPI_ABONO_CIERREDIA.Detalle = "X"

            oZBAPI_ABONO_CIERREDIA.Ref_Banco = strNumRef

            oZBAPI_ABONO_CIERREDIA.ClaCobr = "DPPUNTOS".PadRight(9, " ")

            Dim dsBanco As New DataSet
            dsBanco = Me.BancoSel(oZBAPI_ABONO_CIERREDIA.Tienda, oZBAPI_ABONO_CIERREDIA.ClaCobr)
            If dsBanco.Tables(0).Rows.Count > 0 Then
                oZBAPI_ABONO_CIERREDIA.Banco = dsBanco.Tables(0).Rows(0).Item("Banco")
            Else
                oZBAPI_ABONO_CIERREDIA.Banco = ""
            End If

            oZBAPI_ABONO_CIERREDIA.i_FactDpPro = "X"

            oZBAPI_ABONO_CIERREDIA.i_Mode = "N"

            oProcesosSAPMgr = New ProcesoSAPManager(Me.oParent.ApplicationContext, Me.oParent.SAPApplicationConfig)

            For intIndex = 0 To dvTarjetaUno.Count - 1
                Select Case CodTipoVenta.Trim.ToUpper
                    Case "D", "S", "I"
                        oZBAPI_ABONO_CIERREDIA.Cliente = CStr(dvTarjetaUno(intIndex)("ClienteID")).PadLeft(10, "0")
                    Case "V"
                        If Not Me.oParent.SAPApplicationConfig.DPValeSAP Then
                            oZBAPI_ABONO_CIERREDIA.Cliente = CStr(GetCodigoSAPAsoc(GetDpValeIDDP(CInt(dvTarjetaUno(intIndex)("FacturaID"))))).PadRight(10, " ")
                        Else
                            strDpValeIDDP = CStr(GetDpValeIDDP(CInt(dvTarjetaUno(intIndex)("FacturaID"))))
                            Me.oDPVale.INUMVA = strDpValeIDDP
                            Me.oDPVale.I_RUTA = "X"

                            '--------------------------------------------------------------------------------------------
                            ' JNAVA (02.08.2016): Obtenemos la Info del DPVale 
                            '--------------------------------------------------------------------------------------------
                            'oDPVale = oSAPMgr.ZBAPI_VALIDA_DPVALE(oDPVale)
                            Dim S2Credit As New ProcesosS2Credit(oParent)
                            If oParent.ConfigSaveArchivos.AplicarS2Credit Then
                                oDPVale = S2Credit.ValidaDPVale(oDPVale)
                            Else
                                oDPVale = oSAPMgr.ZBAPI_VALIDA_DPVALE(oDPVale)
                            End If
                            '--------------------------------------------------------------------------------------------

                            oZBAPI_ABONO_CIERREDIA.Cliente = CStr(oDPVale.InfoDPVALE.Rows(0).Item("KUNNR")).PadRight(10, " ")
                        End If
                End Select
                fecha = CStr(CDate(dvTarjetaUno(intIndex)("Fecha")).ToShortDateString.Replace("/", ""))
                oZBAPI_ABONO_CIERREDIA.Fecha = Mid(fecha, 5, 4) & Mid(fecha, 3, 2) & Mid(fecha, 1, 2)
                oZBAPI_ABONO_CIERREDIA.Importe = CStr(dvTarjetaUno(intIndex)("Monto")).PadRight(16, " ")
                oZBAPI_ABONO_CIERREDIA.vBeln = CStr(dvTarjetaUno(intIndex)("FolioSAP")).PadLeft(10, "0")

                strResultLocal = oProcesosSAPMgr.WRITE_ZBAPI_ABONO_CIERREDIA(oZBAPI_ABONO_CIERREDIA, dt)

                If strResultLocal = "Y" Then
                    'actualizar el campo FI05SAP
                    'FacturaFI05ok(oZBAPI_ABONO_CIERREDIA.vBeln, oZBAPI_ABONO_CIERREDIA.ClaCobr)
                Else
                    strMensaje += "FolioSAP: " & oZBAPI_ABONO_CIERREDIA.vBeln & vbCrLf
                    For Each orow As DataRow In dt.Rows
                        strMensaje += "Error: " & orow.Item("Message") & vbCrLf
                    Next
                    strMensaje += vbCrLf

                    strResult = "N"
                End If

                strResultLocal = ""

            Next

        End If

        Return strMensaje.Trim

    End Function

#End Region

#Region "Pagos DPCard"

    Private Function GetFormasPagosAbonosDPCard(ByVal Fecha As DateTime) As DataTable
        Dim conexion As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)
        Dim command As New SqlCommand("GetFormasPagoAbonosDPCard", conexion)
        Dim dtAbonos As New DataTable
        Dim adapter As SqlDataAdapter = Nothing
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@Fecha", Fecha)
            adapter = New SqlDataAdapter(command)
            adapter.Fill(dtAbonos)
            command.Dispose()
            conexion.Close()
        Catch ex As Exception
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            Throw New ApplicationException(ex.Message, ex)
        End Try
        Return dtAbonos
    End Function

    Private Sub ActualizarCompensarPagos(ByVal OtrosPagosDetalleID As Integer)
        Dim strCodFormaPago As String = String.Empty
        Dim strTarjeta As String = String.Empty

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                               GetConnectionString)

        Dim sccmdUpdateFactura As SqlCommand = New SqlCommand

        Try

            With sccmdUpdateFactura

                .Connection = sccnnConnection
                .CommandText = "CompensarOtrosPagosDetalles"

                .CommandType = CommandType.StoredProcedure

                .Parameters.Add(New SqlParameter("@OtrosPagosDetalleID", SqlDbType.Int, 11))
                .Parameters("@OtrosPagosDetalleID").Value = OtrosPagosDetalleID

            End With

            sccnnConnection.Open()
            sccmdUpdateFactura.ExecuteNonQuery()
            sccnnConnection.Close()

        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                sccnnConnection.Close()
            End If

            Throw New ApplicationException("El registro no pudo ser leido debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                sccnnConnection.Close()
            End If

            Throw New ApplicationException("El registro no pudo ser leido debido a un error de aplicación.", ex)

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

    End Sub

#End Region

#Region "Devolucion Tarjetas"

    Public Function GetDevolucionesTarjetas(ByVal CodAlmacen As String, ByVal Fecha As DateTime) As DataTable
        Dim dtTarjetas As New DataTable()
        Dim conexion As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString())
        Dim command As New SqlCommand("GetDevolucionesTarjetaByFecha", conexion)
        Dim adapter As SqlDataAdapter = Nothing
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.AddWithValue("@CodAlmacen", CodAlmacen)
            command.Parameters.AddWithValue("@Fecha", Fecha)
            adapter = New SqlDataAdapter(command)
            adapter.Fill(dtTarjetas)
            command.Dispose()
            conexion.Close()
        Catch sql As SqlException
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            Throw New ApplicationException(sql.Message, sql)
        Catch ex As Exception
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            Throw New ApplicationException(ex.Message, ex)
        End Try
        Return dtTarjetas
    End Function

    Public Sub UpdateCompensarDevolucionesTarjeta(ByVal NotaCreditoID As Integer)
        Dim conexion As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                               GetConnectionString)
        Dim command As New SqlCommand("UpdateCompesarDevolucionesTarjeta", conexion)
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.AddWithValue("@NotaCreditoID", NotaCreditoID)
            command.ExecuteNonQuery()
            command.Dispose()
            conexion.Close()
        Catch sql As SqlException
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            Throw New ApplicationException(sql.Message, sql)
        Catch ex As Exception
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            Throw New ApplicationException(ex.Message, ex)
        End Try
    End Sub

#End Region

End Class
