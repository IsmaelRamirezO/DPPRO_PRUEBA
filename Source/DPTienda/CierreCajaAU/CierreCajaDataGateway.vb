
Option Explicit On 

Imports System.Data.SqlClient
'Imports DportenisPro.DPTienda.ApplicationUnits.CierreCaja.wsCierreCaja
Imports DportenisPro.DPTienda.ApplicationUnits.ArqueoDeCajaAU





Public Class CierreCajaDataGateway

    Private oParent As CierreCajaManager
    Private oArqueoMgr As ArqueoDeCajaManager
    'Dim wsCierre As New wsCierreCaja.CierreCaja
    Dim strCaja As String = String.Empty



#Region "Constructors / Destructors"

    Public Sub New(ByVal Parent As CierreCajaManager)

        oParent = Parent

        strCaja = oParent.ApplicationContext.ApplicationConfiguration.NoCaja

        oArqueoMgr = New ArqueoDeCajaManager(oParent.ApplicationContext)

        'If Not oParent.ApplicationContext.ApplicationConfiguration.WSUrl = Nothing Then

        '    wsCierre.Url = oParent.ApplicationContext.ApplicationConfiguration.WSUrl.TrimStart("/") & "/" & _
        '    wsCierre.strURL.TrimEnd("/")

        'End If

    End Sub

#End Region



#Region "Methods"

    Public Sub Insert(ByVal pCierreCaja As Caja, ByVal decMontoCajaUser As Decimal)

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                                 DataStorageConfiguration.GetConnectionString)

        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand


        Dim decFaltante As Decimal = 0

        Dim decSobrante As Decimal = 0

        Dim decTotalRetiros_FondoCaja As Decimal

        Dim datFechaCierre As Date

        Dim intReturnValue As Integer


        With pCierreCaja

            datFechaCierre = Format(.FechaCierre, "Short Date")

            decTotalRetiros_FondoCaja = .Fondo + .Retiros

        End With

        'DefinirConceptoDiferencia(datFechaCierre, decTotalRetiros_FondoCaja, decMontoCajaUser, decFaltante, decSobrante)


        With sccmdInsert

            .Connection = sccnnConnection

            .CommandText = "[CierreCajaIns]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@InicioCajaID", System.Data.SqlDbType.Int))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar, 2))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioFacturaInicial", System.Data.SqlDbType.Int))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioFacturaFinal", System.Data.SqlDbType.Int))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Retiros", System.Data.SqlDbType.Decimal))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TarjetaManual", System.Data.SqlDbType.Decimal))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TarjetaElectronica", System.Data.SqlDbType.Decimal))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Facturacion", System.Data.SqlDbType.Decimal))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@AbonosApartados", System.Data.SqlDbType.Decimal))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fondo", System.Data.SqlDbType.Decimal))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@AbonosCreditoDirecto", System.Data.SqlDbType.Decimal))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Sobrante", System.Data.SqlDbType.Decimal))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Faltante", System.Data.SqlDbType.Decimal))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaCierre", System.Data.SqlDbType.DateTime))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Usuario", System.Data.SqlDbType.VarChar, 12))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@StatusRegistro", System.Data.SqlDbType.Bit))

            'Out Put :
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CierreCajaID", System.Data.SqlDbType.Int))
            .Parameters("@CierreCajaID").Direction = ParameterDirection.Output

        End With

        Try

            sccnnConnection.Open()

            With sccmdInsert

                'Assign Parameters Values

                .Parameters("@InicioCajaID").Value = ExtraerInicioCajaID(datFechaCierre)
                .Parameters("@CodCaja").Value = oParent.ApplicationContext.ApplicationConfiguration.NoCaja
                .Parameters("@FolioFacturaInicial").Value = ExtraerFolioFacturaInicial(datFechaCierre)
                .Parameters("@FolioFacturaFinal").Value = ExtraerFolioFacturaFinal(datFechaCierre)
                .Parameters("@Retiros").Value = pCierreCaja.Retiros
                .Parameters("@TarjetaManual").Value = pCierreCaja.TarjetaManual
                .Parameters("@TarjetaElectronica").Value = pCierreCaja.TarjetaElectronica
                .Parameters("@Facturacion").Value = pCierreCaja.Facturacion
                .Parameters("@AbonosApartados").Value = pCierreCaja.AbonosApartados
                .Parameters("@Fondo").Value = pCierreCaja.Fondo
                .Parameters("@AbonosCreditoDirecto").Value = pCierreCaja.AbonosCreditoDirecto
                .Parameters("@Sobrante").Value = pCierreCaja.Sobrante
                .Parameters("@Faltante").Value = pCierreCaja.Faltante
                .Parameters("@FechaCierre").Value = datFechaCierre
                .Parameters("@Usuario").Value = oParent.ApplicationContext.Security.CurrentUser.Name
                .Parameters("@Fecha").Value = Date.Now
                .Parameters("@StatusRegistro").Value = 1


                'Execute Command
                .ExecuteNonQuery()

                pCierreCaja.CierreCajaID = .Parameters("@CierreCajaID").Value

            End With

            'Reset New State of Linea Object 
            pCierreCaja.ResetFlagNew()
            pCierreCaja.ResetFlagDirty()

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



    Public Function SelectByID(ByVal ID As Integer) As Caja


    End Function



    Public Function SelectByFechaCierre(ByVal FechaCierre As Date) As Caja

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader
        Dim oCaja As Caja

        oCaja = oParent.Create

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[CierreCajaSelByFecha]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaCierre", System.Data.SqlDbType.DateTime))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar, 2))

        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect
                'Assign Parameters Values
                .Parameters("@FechaCierre").Value = FechaCierre
                .Parameters("@CodCaja").Value = oParent.ApplicationContext.ApplicationConfiguration.NoCaja

                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    With scdrReader

                        oCaja.CierreCajaID = .GetInt32(0)
                        oCaja.InicioCajaID = .GetInt32(1)
                        oCaja.CodCaja = .GetString(2)
                        oCaja.FolioFacturaInicial = .GetInt32(3)
                        oCaja.FolioFacturaFinal = .GetInt32(4)
                        oCaja.Retiros = .GetDecimal(5)
                        oCaja.TarjetaManual = .GetDecimal(6)
                        oCaja.TarjetaElectronica = .GetDecimal(7)
                        oCaja.Facturacion = .GetDecimal(8)
                        oCaja.AbonosApartados = .GetDecimal(9)
                        oCaja.Fondo = .GetDecimal(10)
                        oCaja.AbonosCreditoDirecto = .GetDecimal(11)
                        oCaja.Sobrante = .GetDecimal(12)
                        oCaja.Faltante = .GetDecimal(13)
                        oCaja.FechaCierre = .GetDateTime(14)
                        oCaja.Usuario = .GetString(15)
                        oCaja.Fecha = .GetDateTime(16)
                        oCaja.StatusRegistro = .GetBoolean(17)


                        'Reset New State of Linea Object 
                        oCaja.ResetFlagNew()
                        oCaja.ResetFlagDirty()

                    End With

                Else
                    oCaja = Nothing
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

        If (oCaja Is Nothing) Then
            'Throw New ApplicationException("El registro no pudo ser leido debido a que el ID de línea no existe.")
        End If

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return oCaja

    End Function



    Public Function ValidarFecha(ByVal FechaCierreUser As Date) As Boolean

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        Dim bolReturnValue As Boolean


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

                        'intFolioFacturaInicial = .GetDecimal(0)

                        If (Format(FechaCierreUser, "Short Date") = Format(.GetDateTime(0), "Short Date")) Then

                            bolReturnValue = True

                        Else

                            bolReturnValue = False

                        End If

                    End With

                Else

                    scdrReader.Close()
                    sccnnConnection.Close()

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



    Public Function ValidarInicioCaja(ByVal FechaCierreUser As Date) As Boolean

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
            .CommandText = "[CierreCajaValidarInicioCaja]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar, 2))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime))

        End With


        Try

            sccnnConnection.Open()

            With sccmdSelect
                'Assign Parameters Values
                .Parameters("@CodCaja").Value = oParent.ApplicationContext.ApplicationConfiguration.NoCaja
                .Parameters("@Fecha").Value = Format(FechaCierreUser, "Short Date") 'Date.Now

                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If Not (scdrReader.HasRows) Then

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


    Public Function ValidarCierreCaja(ByVal FechaCierreUser As Date) As Boolean

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
            .CommandText = "[CierreCajaValidarCierreCaja]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar, 2))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime))

        End With


        Try

            sccnnConnection.Open()

            With sccmdSelect

                'Assign Parameters Values
                .Parameters("@CodCaja").Value = oParent.ApplicationContext.ApplicationConfiguration.NoCaja
                .Parameters("@Fecha").Value = Format(FechaCierreUser, "Short Date")

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



    Public Function ValidarFacturaFolioInicial(ByVal intFacturaFolioUser As Integer, ByVal FechaCierre As Date) As Boolean

        Dim intFacturaFolioDB As Integer = ExtraerFolioFacturaInicial(FechaCierre)


        If (intFacturaFolioUser = intFacturaFolioDB) Then

            Return True

        End If

    End Function



    Public Function ValidarFacturaFolioFinal(ByVal intFacturaFolioUser As Integer, ByVal datFechaCierre As Date) As Boolean

        Dim intFacturaFolioDB As Integer = ExtraerFolioFacturaFinal(datFechaCierre)


        If (intFacturaFolioUser = intFacturaFolioDB) Then

            Return True

        End If

    End Function



    Public Function ValidarMontoTarjetaElectronica(ByVal decMontoTElectronicaUser As Decimal, ByVal FechaCierre As Date) As Boolean

        Dim decMontoTarjetaElectronica As Decimal

        Dim strCaja As String = oParent.ApplicationContext.ApplicationConfiguration.NoCaja

        Dim strAlmacen As String = oParent.ApplicationContext.ApplicationConfiguration.Almacen

        'If Not oParent.ApplicationContext.ApplicationConfiguration.WSUrl = String.Empty Then

        '    wsCierre.Url = oParent.ApplicationContext.ApplicationConfiguration.WSUrl.TrimEnd("/") + "/" + _
        '    wsCierre.strURL

        'End If


        'decMontoTarjetaElectronica = CalcularTotalFacturasApartadosTE(FechaCierre) + wsCierre.CalcularTotalDPValeCreditoDirectoTE(FechaCierre, strCaja, strAlmacen)
        decMontoTarjetaElectronica = CalcularTotalFacturasApartadosTE(FechaCierre)

        If (decMontoTElectronicaUser = decMontoTarjetaElectronica) Then

            Return True

        Else

            Return False

        End If

    End Function



    Public Function ValidarMontoTarjetaManual(ByVal decMontoTManualUser As Decimal, ByVal FechaCierre As Date) As Boolean

        Dim decMontoTarjetaManual As Decimal

        Dim strCaja As String = oParent.ApplicationContext.ApplicationConfiguration.NoCaja

        Dim strAlmacen As String = oParent.ApplicationContext.ApplicationConfiguration.Almacen

        'If Not oParent.ApplicationContext.ApplicationConfiguration.WSUrl = String.Empty Then

        '    wsCierre.Url = oParent.ApplicationContext.ApplicationConfiguration.WSUrl.TrimEnd("/") + "/" + _
        '    wsCierre.strURL

        'End If

        'decMontoTarjetaManual = CalcularTotalFacturasApartadosTM(FechaCierre) + wsCierre.CalcularTotalDPValeCreditoDirectoTM(FechaCierre, strCaja, strAlmacen)
        decMontoTarjetaManual = CalcularTotalFacturasApartadosTM(FechaCierre)

        If (decMontoTManualUser = decMontoTarjetaManual) Then

            Return True

        Else

            Return False

        End If

    End Function


    Public Function ValidarMontoFacturado(ByVal decMontoFacturadoUser As Decimal, ByVal FechaCierre As Date) As Boolean

        'Dim decMontoFacturado As Decimal = CalcularTotalMontoFacturado(FechaCierre)

        Dim decMontoFacturado As Decimal


        decMontoFacturado = CalcularTotalMontoFacturado(FechaCierre)

        If (decMontoFacturadoUser = decMontoFacturado) Then

            Return True

        Else

            'MsgBox("Monto Facturado Sistema : " & Format(decMontoFacturado, "$ ###,##0.00"))

            Return False

        End If

    End Function


    Public Function ValidarMontoAbonosApartados(ByVal decMontoAbonosUser As Decimal, ByVal FechaCierre As Date) As Boolean

        Dim decMontoAbonosApartados As Decimal

        decMontoAbonosApartados = CalcularTotalMontoAbonosApartados(FechaCierre)

        If (decMontoAbonosUser = decMontoAbonosApartados) Then

            Return True

        Else

            'MsgBox("Monto Abonos Apartados Sistema : " & Format(decMontoAbonosApartados, "$ ###,##0.00"))

            Return False

        End If

    End Function



    Public Function ValidarMontoCreditoDirecto(ByVal decMontoCreditoDirectoUser As Decimal, ByVal FechaCierre As Date) As Boolean

        Dim decMontoCreditoDirecto As Decimal

        'If Not oParent.ApplicationContext.ApplicationConfiguration.WSUrl = String.Empty Then

        '    wsCierre.Url = oParent.ApplicationContext.ApplicationConfiguration.WSUrl.TrimEnd("/") + "/" + _
        '    wsCierre.strURL

        'End If

        'decMontoCreditoDirecto = wsCierre.CalcularTotalCreditoDirecto(FechaCierre, strCaja, strAlmacen)
        decMontoCreditoDirecto = CalcularTotalMontoApartadosCDT(FechaCierre)
        If (decMontoCreditoDirectoUser = decMontoCreditoDirecto) Then

            Return True

        Else

            'MsgBox("Monto Abonos Credito Directo Sistema : " & Format(decMontoCreditoDirecto, "$ ###,##0.00"))

            Return False

        End If

    End Function



    Public Function CalcularMontoCajaDiferencias(ByVal datFechaCierre As Date, ByVal decMontoCajaUser As Decimal) As Decimal


        ''NOTA : 
        ''       Calcular en INSERT

        'Dim decFaltante As Decimal = 0

        'Dim decSobrante As Decimal = 0


        'DefinirConceptoDiferencia(datFechaCierre, decMontoCajaUser, decFaltante, decSobrante)


        'If (decFaltante > 0) Then    'El Concepto de Diferencia de Caja fue por Faltante de Efectivo.



        'ElseIf (decSobrante > 0) Then   'El Concepto de Diferencia de Caja fue por Faltante de Efectivo. 



        'End If

    End Function








    Public Sub DefinirConceptoDiferencia(ByVal datFechaCierre As Date, ByVal decTotalRetiros_FondoCaja As Decimal, _
                                         ByVal decMontoCajaUser As Decimal, ByRef decFaltante As Decimal, _
                                         ByRef decSobrante As Decimal)

        Dim decMontoCaja As Decimal

        Dim strCajaID As String = oParent.ApplicationContext.ApplicationConfiguration.NoCaja
        Dim strAlmacen As String = oParent.ApplicationContext.ApplicationConfiguration.Almacen

        If Not oParent.ApplicationContext.ApplicationConfiguration.WSUrl = String.Empty Then

            'wsCierre.Url = oParent.ApplicationContext.ApplicationConfiguration.WSUrl.TrimEnd("/") + "/" + _
            'wsCierre.strURL

        End If


        'decMontoCaja = decTotalRetiros_FondoCaja + wsCierre.CalcularTotalCreditoDirecto(datFechaCierre, strCajaID, oParent.ApplicationContext.ApplicationConfiguration.Almacen) + _
        '               CalcularTotalMontoAbonosApartados(datFechaCierre) + CalcularTotalMontoFacturado(datFechaCierre) + _
        '               CalcularTotalFacturasApartadosTM(datFechaCierre) + CalcularTotalFacturasApartadosTE(datFechaCierre) + _
        '               wsCierre.CalcularTotalDPValeCreditoDirectoTM(datFechaCierre, strCajaID, strAlmacen) + _
        '               wsCierre.CalcularTotalDPValeCreditoDirectoTE(datFechaCierre, strCajaID, strAlmacen)


        'SOBRANTE :
        If (decMontoCaja > decMontoCajaUser) Then

            decSobrante = decMontoCaja - decMontoCajaUser
            decFaltante = 0

            'FALTANTE :
        ElseIf (decMontoCaja < decMontoCajaUser) Then

            decFaltante = decMontoCajaUser - decMontoCaja
            decSobrante = 0

        End If



    End Sub



    Public Function ExtraerInicioCajaID(ByVal FechaCierre As Date) As Decimal

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        Dim intInicioCajaID As Integer


        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[CierreCajaExtraerInicioCajaID]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime))

            'OutPut :
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@InicioCajaID", System.Data.SqlDbType.Int))
            .Parameters("@InicioCajaID").Direction = ParameterDirection.Output

        End With


        Try

            sccnnConnection.Open()

            With sccmdSelect

                'Assign Parameters Values
                .Parameters("@CodCaja").Value = oParent.ApplicationContext.ApplicationConfiguration.NoCaja
                .Parameters("@Fecha").Value = Format(FechaCierre, "Short Date")
                .Parameters("@InicioCajaID").Value = 0

                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    With scdrReader

                        'Return .GetDecimal(0)
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



    Public Function ExtraerFolioFacturaInicial(ByVal FechaCierre As Date) As Decimal

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        Dim intFolioFacturaInicial As Integer


        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[CierreCajaExtraerFolioFacturaInicial]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime))

            'OutPut :
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioFactura", System.Data.SqlDbType.Int))
            .Parameters("@FolioFactura").Direction = ParameterDirection.Output

        End With


        Try

            sccnnConnection.Open()

            With sccmdSelect

                'Assign Parameters Values
                .Parameters("@CodCaja").Value = oParent.ApplicationContext.ApplicationConfiguration.NoCaja
                .Parameters("@Fecha").Value = Format(FechaCierre, "Short Date")
                .Parameters("@FolioFactura").Value = 0

                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    With scdrReader

                        'Return .GetDecimal(0)
                        intFolioFacturaInicial = .GetInt32(0)

                    End With

                Else

                    scdrReader.Close()
                    sccnnConnection.Close()

                    intFolioFacturaInicial = 0

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


        Return intFolioFacturaInicial

    End Function



    Public Function ExtraerFolioFacturaFinal(ByVal FechaCierre As Date) As Decimal

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        Dim intFolioFacturaFinal As Integer



        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[CierreCajaExtraerFolioFacturaFinal]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime))


            'OutPut :
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioFactura", System.Data.SqlDbType.Int))
            .Parameters("@FolioFactura").Direction = ParameterDirection.Output

        End With


        Try

            sccnnConnection.Open()

            With sccmdSelect

                'Assign Parameters Values
                .Parameters("@CodCaja").Value = oParent.ApplicationContext.ApplicationConfiguration.NoCaja
                .Parameters("@Fecha").Value = Format(FechaCierre, "Short Date")
                .Parameters("@FolioFactura").Value = 0

                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    With scdrReader

                        'Return .GetDecimal(0)
                        intFolioFacturaFinal = .GetInt32(0)

                    End With

                Else

                    scdrReader.Close()
                    sccnnConnection.Close()

                    intFolioFacturaFinal = 0

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

        Return intFolioFacturaFinal

    End Function



    Public Function CalcularTotalRetiros(ByVal FechaCierre As Date) As Decimal

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        Dim decTotalRetiros As Decimal


        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[CierreCajaExtraerTotalRetiros]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime))

            'OutPut :
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TotalRetiros", System.Data.SqlDbType.Decimal))
            .Parameters("@TotalRetiros").Direction = ParameterDirection.Output

        End With


        Try

            sccnnConnection.Open()

            With sccmdSelect

                'Assign Parameters Values
                .Parameters("@CodCaja").Value = oParent.ApplicationContext.ApplicationConfiguration.NoCaja
                .Parameters("@Fecha").Value = Format(FechaCierre, "Short Date")
                .Parameters("@TotalRetiros").Value = 0

                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    With scdrReader

                        If .IsDBNull(0) = False Then

                            decTotalRetiros = .GetDecimal(0)

                        Else

                            scdrReader.Close()
                            sccnnConnection.Close()

                            decTotalRetiros = 0

                        End If

                    End With

                Else

                    scdrReader.Close()
                    sccnnConnection.Close()

                    decTotalRetiros = 0

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


        Return decTotalRetiros

    End Function
    Public Function CalcularTotalRetirosREP(ByVal FechaCierre As Date) As Decimal

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        Dim decTotalRetiros As Decimal


        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[CierreCajaExtraerTotalRetirosREP]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime))

            'OutPut :
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TotalRetiros", System.Data.SqlDbType.Decimal))
            .Parameters("@TotalRetiros").Direction = ParameterDirection.Output

        End With


        Try

            sccnnConnection.Open()

            With sccmdSelect

                'Assign Parameters Values
                .Parameters("@Fecha").Value = Format(FechaCierre, "Short Date")
                .Parameters("@TotalRetiros").Value = 0

                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    With scdrReader

                        If .IsDBNull(0) = False Then

                            decTotalRetiros = .GetDecimal(0)

                        Else

                            scdrReader.Close()
                            sccnnConnection.Close()

                            decTotalRetiros = 0

                        End If

                    End With

                Else

                    scdrReader.Close()
                    sccnnConnection.Close()

                    decTotalRetiros = 0

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


        Return decTotalRetiros

    End Function


    Public Function CalcularTotalFondoCaja(ByVal FechaCierre As Date) As Decimal

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        Dim decFondoCaja As Decimal


        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[CierreCajaExtraerFondo]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime))

            'OutPut :
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fondo", System.Data.SqlDbType.Decimal))
            .Parameters("@Fondo").Direction = ParameterDirection.Output

        End With


        Try

            sccnnConnection.Open()

            With sccmdSelect

                'Assign Parameters Values
                .Parameters("@CodCaja").Value = oParent.ApplicationContext.ApplicationConfiguration.NoCaja
                .Parameters("@Fecha").Value = Format(FechaCierre, "Short Date")
                .Parameters("@Fondo").Value = 0

                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    With scdrReader

                        If .IsDBNull(0) = False Then

                            decFondoCaja = .GetDecimal(0)

                        Else

                            scdrReader.Close()
                            sccnnConnection.Close()

                            decFondoCaja = 0

                        End If

                    End With

                Else

                    scdrReader.Close()
                    sccnnConnection.Close()

                    decFondoCaja = 0

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


        Return decFondoCaja

    End Function
    Public Function CalcularTotalFondoCajaREP(ByVal FechaCierre As Date) As Decimal

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        Dim decFondoCaja As Decimal


        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[CierreCajaExtraerFondoREP]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime))

            'OutPut :
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fondo", System.Data.SqlDbType.Decimal))
            .Parameters("@Fondo").Direction = ParameterDirection.Output

        End With


        Try

            sccnnConnection.Open()

            With sccmdSelect

                'Assign Parameters Values
                .Parameters("@Fecha").Value = Format(FechaCierre, "Short Date")
                .Parameters("@Fondo").Value = 0

                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    With scdrReader

                        If .IsDBNull(0) = False Then

                            decFondoCaja = .GetDecimal(0)

                        Else

                            scdrReader.Close()
                            sccnnConnection.Close()

                            decFondoCaja = 0

                        End If

                    End With

                Else

                    scdrReader.Close()
                    sccnnConnection.Close()

                    decFondoCaja = 0

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


        Return decFondoCaja

    End Function
    'Private Function wsLoad(ByVal Fecha As DateTime) As DataSet

    '    Dim ds As DataSet

    '    ds = wsCierre.Load(Fecha)

    '    Return ds

    'End Function



    Public Function CalcularTotalFacturasApartadosTE(ByVal FechaCierre As Date) As Decimal

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                         GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        Dim decTotalFacturasApartados As Decimal


        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[CierreCajaTotalFacturasAbonosApartadosTE]"
            .CommandType = System.Data.CommandType.StoredProcedure

            '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar, 2))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@StatusFactura", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TotalFacturaTE", System.Data.SqlDbType.Decimal))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TotalFacturaTD", System.Data.SqlDbType.Decimal))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TotalApartadoTE", System.Data.SqlDbType.Decimal))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TotalApartadoTD", System.Data.SqlDbType.Decimal))


            'OutPut :
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TotalFacturasAbonosApartados", System.Data.SqlDbType.Decimal))
            .Parameters("@TotalFacturasAbonosApartados").Direction = ParameterDirection.Output

        End With


        Try

            sccnnConnection.Open()

            With sccmdSelect

                'Assign Parameters Values
                .Parameters("@Fecha").Value = Format(FechaCierre, "Short Date")
                .Parameters("@CodCaja").Value = oParent.ApplicationContext.ApplicationConfiguration.NoCaja
                .Parameters("@StatusFactura").Value = "GRA"
                .Parameters("@TotalFacturaTE").Value = 0.0
                .Parameters("@TotalFacturaTD").Value = 0.0
                .Parameters("@TotalApartadoTE").Value = 0.0
                .Parameters("@TotalApartadoTD").Value = 0.0
                .Parameters("@TotalFacturasAbonosApartados").Value = 0


                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    With scdrReader

                        If (.IsDBNull(0) = False) Then

                            'Return .GetDecimal(0)
                            decTotalFacturasApartados = .GetDecimal(0)

                        Else

                            scdrReader.Close()
                            sccnnConnection.Close()

                            decTotalFacturasApartados = 0

                        End If

                    End With

                Else

                    scdrReader.Close()
                    sccnnConnection.Close()

                    decTotalFacturasApartados = 0

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


        Return decTotalFacturasApartados

    End Function
    Public Function CalcularTotalFacturasApartadosTEREP(ByVal FechaCierre As Date) As Decimal

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                         GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        Dim decTotalFacturasApartados As Decimal


        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[CierreCajaTotalFacturasAbonosApartadosTEREP]"
            .CommandType = System.Data.CommandType.StoredProcedure

            '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@StatusFactura", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TotalFacturaTE", System.Data.SqlDbType.Decimal))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TotalFacturaTD", System.Data.SqlDbType.Decimal))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TotalApartadoTE", System.Data.SqlDbType.Decimal))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TotalApartadoTD", System.Data.SqlDbType.Decimal))


            'OutPut :
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TotalFacturasAbonosApartados", System.Data.SqlDbType.Decimal))
            .Parameters("@TotalFacturasAbonosApartados").Direction = ParameterDirection.Output

        End With


        Try

            sccnnConnection.Open()

            With sccmdSelect

                'Assign Parameters Values
                .Parameters("@Fecha").Value = Format(FechaCierre, "Short Date")
                .Parameters("@StatusFactura").Value = "GRA"
                .Parameters("@TotalFacturaTE").Value = 0.0
                .Parameters("@TotalFacturaTD").Value = 0.0
                .Parameters("@TotalApartadoTE").Value = 0.0
                .Parameters("@TotalApartadoTD").Value = 0.0
                .Parameters("@TotalFacturasAbonosApartados").Value = 0


                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    With scdrReader

                        If (.IsDBNull(0) = False) Then

                            'Return .GetDecimal(0)
                            decTotalFacturasApartados = .GetDecimal(0)

                        Else

                            scdrReader.Close()
                            sccnnConnection.Close()

                            decTotalFacturasApartados = 0

                        End If

                    End With

                Else

                    scdrReader.Close()
                    sccnnConnection.Close()

                    decTotalFacturasApartados = 0

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


        Return decTotalFacturasApartados

    End Function

    Public Function CalcularTotalByBanco(ByVal FechaCierre As Date, ByVal CodBanco As String, ByVal TipoTarjeta As String) As Decimal

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                         GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        Dim decTotalTE As Decimal


        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[CierreCajaTotalTEByBancoREP]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodBanco", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TipoTarjeta", System.Data.SqlDbType.VarChar, 2))

        End With


        Try

            sccnnConnection.Open()

            With sccmdSelect

                'Assign Parameters Values
                .Parameters("@Fecha").Value = Format(FechaCierre, "Short Date")
                .Parameters("@CodBanco").Value = CodBanco
                .Parameters("@TipoTarjeta").Value = TipoTarjeta

                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    With scdrReader

                        If (.IsDBNull(0) = False) Then

                            'Return .GetDecimal(0)
                            decTotalTE = .GetDecimal(0)

                        Else

                            scdrReader.Close()
                            sccnnConnection.Close()

                            decTotalTE = 0

                        End If

                    End With

                Else

                    scdrReader.Close()
                    sccnnConnection.Close()

                    decTotalTE = 0

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


        Return decTotalTE

    End Function


    Public Function CalcularTotalFacturasApartadosTM(ByVal FechaCierre As Date) As Decimal

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        Dim decTotalFacturasApartados As Decimal


        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[CierreCajaTotalFacturasAbonosApartadosTM]"
            .CommandType = System.Data.CommandType.StoredProcedure

            '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar, 2))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@StatusFactura", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TotalFacturaTE", System.Data.SqlDbType.Decimal))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TotalApartadoTE", System.Data.SqlDbType.Decimal))


            'OutPut :
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TotalFacturasAbonosApartadosTM", System.Data.SqlDbType.Decimal))
            .Parameters("@TotalFacturasAbonosApartadosTM").Direction = ParameterDirection.Output

        End With


        Try

            sccnnConnection.Open()

            With sccmdSelect

                'Assign Parameters Values
                .Parameters("@Fecha").Value = Format(FechaCierre, "Short Date")
                .Parameters("@CodCaja").Value = oParent.ApplicationContext.ApplicationConfiguration.NoCaja
                .Parameters("@StatusFactura").Value = "GRA"
                .Parameters("@TotalFacturaTE").Value = 0.0
                .Parameters("@TotalApartadoTE").Value = 0.0
                .Parameters("@TotalFacturasAbonosApartadosTM").Value = 0


                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    With scdrReader

                        If (.IsDBNull(0) = False) Then

                            'Return .GetDecimal(0)
                            decTotalFacturasApartados = .GetDecimal(0)

                        Else

                            scdrReader.Close()
                            sccnnConnection.Close()

                            decTotalFacturasApartados = 0

                        End If

                    End With

                Else

                    scdrReader.Close()
                    sccnnConnection.Close()

                    decTotalFacturasApartados = 0

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


        Return decTotalFacturasApartados

    End Function
    Public Function CalcularTotalFacturasApartadosTMREP(ByVal FechaCierre As Date) As Decimal

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        Dim decTotalFacturasApartados As Decimal


        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[CierreCajaTotalFacturasAbonosApartadosTMREP]"
            .CommandType = System.Data.CommandType.StoredProcedure

            '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@StatusFactura", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TotalFacturaTE", System.Data.SqlDbType.Decimal))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TotalApartadoTE", System.Data.SqlDbType.Decimal))


            'OutPut :
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TotalFacturasAbonosApartadosTM", System.Data.SqlDbType.Decimal))
            .Parameters("@TotalFacturasAbonosApartadosTM").Direction = ParameterDirection.Output

        End With


        Try

            sccnnConnection.Open()

            With sccmdSelect

                'Assign Parameters Values
                .Parameters("@Fecha").Value = Format(FechaCierre, "Short Date")
                .Parameters("@StatusFactura").Value = "GRA"
                .Parameters("@TotalFacturaTE").Value = 0.0
                .Parameters("@TotalApartadoTE").Value = 0.0
                .Parameters("@TotalFacturasAbonosApartadosTM").Value = 0


                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    With scdrReader

                        If (.IsDBNull(0) = False) Then

                            'Return .GetDecimal(0)
                            decTotalFacturasApartados = .GetDecimal(0)

                        Else

                            scdrReader.Close()
                            sccnnConnection.Close()

                            decTotalFacturasApartados = 0

                        End If

                    End With

                Else

                    scdrReader.Close()
                    sccnnConnection.Close()

                    decTotalFacturasApartados = 0

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


        Return decTotalFacturasApartados

    End Function


    Public Function CalcularTotalMontoFacturado(ByVal FechaCierre As Date) As Decimal

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        Dim decTotalMontoFacturado As Decimal


        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[CierreCajaTotalMontoFacturado]"
            .CommandType = System.Data.CommandType.StoredProcedure

            '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@StatusFactura", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar, 2))

            'OutPut :
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TotalMontoFacturado", System.Data.SqlDbType.Decimal))
            .Parameters("@TotalMontoFacturado").Direction = ParameterDirection.Output

        End With


        Try

            sccnnConnection.Open()

            With sccmdSelect

                'Assign Parameters Values
                .Parameters("@Fecha").Value = Format(FechaCierre, "Short Date")
                .Parameters("@StatusFactura").Value = "GRA"
                .Parameters("@TotalMontoFacturado").Value = 0
                .Parameters("@CodCaja").Value = oParent.ApplicationContext.ApplicationConfiguration.NoCaja


                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    With scdrReader

                        If (.IsDBNull(0) = False) Then

                            'Return .GetDecimal(0)
                            decTotalMontoFacturado = .GetDecimal(0)

                        Else

                            scdrReader.Close()
                            sccnnConnection.Close()

                            decTotalMontoFacturado = 0

                        End If

                    End With

                Else

                    scdrReader.Close()
                    sccnnConnection.Close()

                    decTotalMontoFacturado = 0

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


        Return decTotalMontoFacturado

    End Function

    Public Function CalcularTotalMontoPedidosSH(ByVal FechaCierre As Date) As Decimal

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        Dim decTotalMontoFacturado As Decimal


        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[CierreCajaTotalMontoPedidoSH]"
            .CommandType = System.Data.CommandType.StoredProcedure

            '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime))
            '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@StatusFactura", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar, 2))

            'OutPut :
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TotalMontoPedidos", System.Data.SqlDbType.Decimal))
            .Parameters("@TotalMontoPedidos").Direction = ParameterDirection.Output

        End With


        Try

            sccnnConnection.Open()

            With sccmdSelect

                'Assign Parameters Values
                .Parameters("@Fecha").Value = FechaCierre
                .Parameters("@TotalMontoPedidos").Value = 0
                .Parameters("@CodCaja").Value = oParent.ApplicationContext.ApplicationConfiguration.NoCaja


                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    With scdrReader

                        If (.IsDBNull(.GetOrdinal("TotalMontoPedidos")) = False) Then

                            'Return .GetDecimal(0)
                            decTotalMontoFacturado = .GetDecimal(.GetOrdinal("TotalMontoPedidos"))

                        Else

                            scdrReader.Close()
                            sccnnConnection.Close()

                            decTotalMontoFacturado = 0

                        End If

                    End With

                Else

                    scdrReader.Close()
                    sccnnConnection.Close()

                    decTotalMontoFacturado = 0

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


        Return decTotalMontoFacturado

    End Function

    Public Function CalcularTotalMontoFacturadoREP(ByVal FechaCierre As Date) As Decimal

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        Dim decTotalMontoFacturado As Decimal


        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[CierreCajaTotalMontoFacturadoREP]"
            .CommandType = System.Data.CommandType.StoredProcedure

            '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@StatusFactura", System.Data.SqlDbType.VarChar, 3))


            'OutPut :
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TotalMontoFacturado", System.Data.SqlDbType.Decimal))
            .Parameters("@TotalMontoFacturado").Direction = ParameterDirection.Output

        End With


        Try

            sccnnConnection.Open()

            With sccmdSelect

                'Assign Parameters Values
                .Parameters("@Fecha").Value = Format(FechaCierre, "Short Date")
                .Parameters("@StatusFactura").Value = "GRA"
                .Parameters("@TotalMontoFacturado").Value = 0



                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    With scdrReader

                        If (.IsDBNull(0) = False) Then

                            'Return .GetDecimal(0)
                            decTotalMontoFacturado = .GetDecimal(0)

                        Else

                            scdrReader.Close()
                            sccnnConnection.Close()

                            decTotalMontoFacturado = 0

                        End If

                    End With

                Else

                    scdrReader.Close()
                    sccnnConnection.Close()

                    decTotalMontoFacturado = 0

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


        Return decTotalMontoFacturado

    End Function


    Public Function CalcularTotalMontoAbonosApartados(ByVal FechaCierre As Date) As Decimal

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        Dim decTotalMontoAbonos As Decimal


        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[CierreCajaTotalMontoAbonosApartados]"
            .CommandType = System.Data.CommandType.StoredProcedure

            '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar, 2))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime))

            'OutPut :
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TotalMontoAbonosApartados", System.Data.SqlDbType.Decimal))
            .Parameters("@TotalMontoAbonosApartados").Direction = ParameterDirection.Output

        End With


        Try

            sccnnConnection.Open()

            With sccmdSelect

                'Assign Parameters Values
                .Parameters("@CodCaja").Value = oParent.ApplicationContext.ApplicationConfiguration.NoCaja
                .Parameters("@Fecha").Value = Format(FechaCierre, "Short Date")
                .Parameters("@TotalMontoAbonosApartados").Value = 0


                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    With scdrReader

                        If (.IsDBNull(0) = False) Then

                            'Return .GetDecimal(0)
                            decTotalMontoAbonos = .GetDecimal(0)

                        Else

                            scdrReader.Close()
                            sccnnConnection.Close()

                            decTotalMontoAbonos = 0

                        End If

                    End With

                Else

                    scdrReader.Close()
                    sccnnConnection.Close()

                    decTotalMontoAbonos = 0

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


        Return decTotalMontoAbonos

    End Function
    Public Function CalcularTotalMontoAbonosApartadosREP(ByVal FechaCierre As Date) As Decimal

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        Dim decTotalMontoAbonos As Decimal


        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[CierreCajaTotalMontoAbonosApartadosREP]"
            .CommandType = System.Data.CommandType.StoredProcedure

            '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime))

            'OutPut :
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TotalMontoAbonosApartados", System.Data.SqlDbType.Decimal))
            .Parameters("@TotalMontoAbonosApartados").Direction = ParameterDirection.Output

        End With


        Try

            sccnnConnection.Open()

            With sccmdSelect

                'Assign Parameters Values

                .Parameters("@Fecha").Value = Format(FechaCierre, "Short Date")
                .Parameters("@TotalMontoAbonosApartados").Value = 0


                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    With scdrReader

                        If (.IsDBNull(0) = False) Then

                            'Return .GetDecimal(0)
                            decTotalMontoAbonos = .GetDecimal(0)

                        Else

                            scdrReader.Close()
                            sccnnConnection.Close()

                            decTotalMontoAbonos = 0

                        End If

                    End With

                Else

                    scdrReader.Close()
                    sccnnConnection.Close()

                    decTotalMontoAbonos = 0

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


        Return decTotalMontoAbonos

    End Function
    Public Function SelByInicioCajaID(ByVal InicioCajaID As Integer) As Boolean

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
            .CommandText = "[CierreCajaSelByInicioDiaID]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@InicioCajaId", System.Data.SqlDbType.Int, 4))


        End With


        Try

            sccnnConnection.Open()

            With sccmdSelect
                'Assign Parameters Values
                .Parameters("@InicioCajaID").Value = InicioCajaID

                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If Not (scdrReader.HasRows) Then

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


    Public Function FacturasDelDia(ByVal FechaCierre As Date) As Boolean

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        Dim decFondoCaja As Decimal


        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[FacturasCountByDate]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar))


        End With


        Try

            sccnnConnection.Open()

            With sccmdSelect

                'Assign Parameters Values
                .Parameters("@CodCaja").Value = oParent.ApplicationContext.ApplicationConfiguration.NoCaja
                .Parameters("@Fecha").Value = Format(FechaCierre, "Short Date")
                .Parameters("@CodAlmacen").Value = oParent.ApplicationContext.ApplicationConfiguration.Almacen

                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    scdrReader.Close()
                    sccnnConnection.Close()

                    Return True

                Else

                    scdrReader.Close()
                    sccnnConnection.Close()

                    Return False

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


    End Function


    Public Function ValidarFoliosFacturas(ByVal intFacturaFolioInicio As Integer, _
                                          ByVal intFacturaFolioFin As Integer, ByRef intFolioNoGuardado As Integer _
                                          ) As Boolean

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                         GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        Dim bolResult As Boolean


        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[CierreCajaValidarFolioFacturas]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar, 2))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioFactura", System.Data.SqlDbType.Int))

        End With


        Dim intFolio As Integer

        For intFolio = intFacturaFolioInicio To intFacturaFolioFin

            Try

                sccnnConnection.Open()

                With sccmdSelect

                    'Assign Parameters Values
                    .Parameters("@CodCaja").Value = oParent.ApplicationContext.ApplicationConfiguration.NoCaja
                    .Parameters("@CodAlmacen").Value = oParent.ApplicationContext.ApplicationConfiguration.Almacen
                    .Parameters("@FolioFactura").Value = intFolio

                    'Execute Command
                    scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                    'Assign Other Values
                    scdrReader.Read()

                    If Not (scdrReader.HasRows) Then

                        'El Folio no se encuentra Guardado.
                        intFolioNoGuardado = intFolio
                        bolResult = True
                        Exit For

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

        Next

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return bolResult

    End Function


    Public Function CalcularTotalMontoApartadosCDT(ByVal FechaCierre As Date) As Decimal

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        Dim decTotalMontoApartadosCDT As Decimal


        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[CierreCajaTotalMontoAbonosCDT]"
            .CommandType = System.Data.CommandType.StoredProcedure

            '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar, 2))

            'OutPut :
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TotalMontoAbonosCDT", System.Data.SqlDbType.Decimal))
            .Parameters("@TotalMontoAbonosCDT").Direction = ParameterDirection.Output

        End With


        Try

            sccnnConnection.Open()

            With sccmdSelect

                'Assign Parameters Values
                .Parameters("@Fecha").Value = Format(FechaCierre, "Short Date")
                .Parameters("@TotalMontoAbonosCDT").Value = 0
                .Parameters("@CodCaja").Value = oParent.ApplicationContext.ApplicationConfiguration.NoCaja


                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    With scdrReader

                        If (.IsDBNull(0) = False) Then

                            'Return .GetDecimal(0)
                            decTotalMontoApartadosCDT = .GetDecimal(0)

                        Else

                            scdrReader.Close()
                            sccnnConnection.Close()

                            decTotalMontoApartadosCDT = 0

                        End If

                    End With

                Else

                    scdrReader.Close()
                    sccnnConnection.Close()

                    decTotalMontoApartadosCDT = 0

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


        Return decTotalMontoApartadosCDT

    End Function
    Public Function CalcularTotalMontoApartadosCDTREP(ByVal FechaCierre As Date) As Decimal

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        Dim decTotalMontoApartadosCDT As Decimal


        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[CierreCajaTotalMontoAbonosCDTREP]"
            .CommandType = System.Data.CommandType.StoredProcedure

            '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime))


            'OutPut :
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TotalMontoAbonosCDT", System.Data.SqlDbType.Decimal))
            .Parameters("@TotalMontoAbonosCDT").Direction = ParameterDirection.Output

        End With


        Try

            sccnnConnection.Open()

            With sccmdSelect

                'Assign Parameters Values
                .Parameters("@Fecha").Value = Format(FechaCierre, "Short Date")
                .Parameters("@TotalMontoAbonosCDT").Value = 0


                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    With scdrReader

                        If (.IsDBNull(0) = False) Then

                            'Return .GetDecimal(0)
                            decTotalMontoApartadosCDT = .GetDecimal(0)

                        Else

                            scdrReader.Close()
                            sccnnConnection.Close()

                            decTotalMontoApartadosCDT = 0

                        End If

                    End With

                Else

                    scdrReader.Close()
                    sccnnConnection.Close()

                    decTotalMontoApartadosCDT = 0

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


        Return decTotalMontoApartadosCDT

    End Function
    Public Function CalcularTotalNotasCredito(ByVal FechaCierre As Date) As DataSet

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                         GetConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaNC As SqlDataAdapter
        Dim dsNC As DataSet

        sccmdSelectAll = New SqlCommand
        scdaNC = New SqlDataAdapter
        dsNC = New DataSet

        With sccmdSelectAll

            .Connection = sccnnConnection

            .CommandText = "[NotasDeCreditoTotalGET]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar, 2))

            .Parameters("@Fecha").Value = Format(FechaCierre, "Short Date")
            .Parameters("@CodCaja").Value = oParent.ApplicationContext.ApplicationConfiguration.NoCaja
        End With

        scdaNC.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            'Fill DataSet
            scdaNC.Fill(dsNC)

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

        Return dsNC

    End Function
    Public Function CalcularTotalNotasCreditoREP(ByVal FechaCierre As Date) As DataSet

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                         GetConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaNC As SqlDataAdapter
        Dim dsNC As DataSet

        sccmdSelectAll = New SqlCommand
        scdaNC = New SqlDataAdapter
        dsNC = New DataSet

        With sccmdSelectAll

            .Connection = sccnnConnection

            .CommandText = "[NotasDeCreditoTotalGETREP]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime))


            .Parameters("@Fecha").Value = Format(FechaCierre, "Short Date")

        End With

        scdaNC.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            'Fill DataSet
            scdaNC.Fill(dsNC)

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

        Return dsNC

    End Function

    Public Function GetTotalPagosEcommerce(ByVal CodAlmacen As String, ByVal FechaInicio As DateTime, ByVal FechaFin As DateTime) As Decimal
        Dim conexion As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                         GetConnectionString)
        Dim command As New SqlCommand("GetTotalFormasPago", conexion)
        Dim total As Decimal = 0
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@CodAlmacen", CodAlmacen)
            command.Parameters.Add("@FechaInicial", FechaInicio)
            command.Parameters.Add("@FechaFinal", FechaFin)
            total = CDec(command.ExecuteScalar())
            command.Dispose()
            conexion.Close()
        Catch Sql As SqlException
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            Throw New ApplicationException("Hubo un error al obtener el total de pagos ecommerce", Sql)
        Catch ex As Exception
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            Throw New ApplicationException("Hubo un error en la aplicación", ex)
        End Try
        Return total
    End Function

    Public Function GetTotalFormasPagoEcommerce(ByVal FormaPago As Integer, ByVal CodAlmacen As String, ByVal FechaInicio As DateTime, ByVal FechaFin As DateTime) As Decimal
        Dim conexion As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                         GetConnectionString())
        Dim command As New SqlCommand("GetTotalFormasPagoEcommerce", conexion)
        Dim total As Decimal = 0
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@CodAlmacen", CodAlmacen)
            command.Parameters.Add("@FechaInicial", FechaInicio)
            command.Parameters.Add("@FechaFinal", FechaFin)
            command.Parameters.Add("@FormaPago", FormaPago)
            total = CDec(command.ExecuteScalar())
            command.Dispose()
            conexion.Close()
        Catch sql As SqlException
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            Throw New ApplicationException("Hubo un error al obtener el total de las formas de Pago", sql)
        Catch ex As Exception
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            Throw New ApplicationException("Hubo un error en la aplicación", ex)
        End Try
        Return total
    End Function

    Public Function NotasCreditoFoliosGetREP(ByVal FechaCierre As Date) As DataSet

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                         GetConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaNC As SqlDataAdapter
        Dim dsNC As DataSet

        sccmdSelectAll = New SqlCommand
        scdaNC = New SqlDataAdapter
        dsNC = New DataSet

        With sccmdSelectAll

            .Connection = sccnnConnection

            .CommandText = "[NotasDeCreditoFoliosGETREP]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime))


            .Parameters("@Fecha").Value = Format(FechaCierre, "Short Date")

        End With

        scdaNC.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            'Fill DataSet
            scdaNC.Fill(dsNC)

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

        Return dsNC

    End Function

    Public Function CalcularTotalFormasPago(ByVal FechaCierre As Date, ByVal sp As String) As Decimal

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                         GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        Dim decTotalFacturasApartados As Decimal


        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[" & sp & "]"
            .CommandType = System.Data.CommandType.StoredProcedure

            '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar, 2))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@StatusFactura", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TotalFacturaTE", System.Data.SqlDbType.Decimal))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TotalFacturaTD", System.Data.SqlDbType.Decimal))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TotalApartadoTE", System.Data.SqlDbType.Decimal))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TotalApartadoTD", System.Data.SqlDbType.Decimal))


            'OutPut :
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TotalFacturasAbonosApartados", System.Data.SqlDbType.Decimal))
            .Parameters("@TotalFacturasAbonosApartados").Direction = ParameterDirection.Output

        End With


        Try

            sccnnConnection.Open()

            With sccmdSelect

                'Assign Parameters Values
                .Parameters("@Fecha").Value = Format(FechaCierre, "Short Date")
                .Parameters("@CodCaja").Value = oParent.ApplicationContext.ApplicationConfiguration.NoCaja
                .Parameters("@StatusFactura").Value = "GRA"
                .Parameters("@TotalFacturaTE").Value = 0.0
                .Parameters("@TotalFacturaTD").Value = 0.0
                .Parameters("@TotalApartadoTE").Value = 0.0
                .Parameters("@TotalApartadoTD").Value = 0.0
                .Parameters("@TotalFacturasAbonosApartados").Value = 0


                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    With scdrReader

                        If (.IsDBNull(0) = False) Then

                            'Return .GetDecimal(0)
                            decTotalFacturasApartados = .GetDecimal(0)

                        Else

                            scdrReader.Close()
                            sccnnConnection.Close()

                            decTotalFacturasApartados = 0

                        End If

                    End With

                Else

                    scdrReader.Close()
                    sccnnConnection.Close()

                    decTotalFacturasApartados = 0

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


        Return decTotalFacturasApartados

    End Function
    Public Function CalcularTotalFormasPagoREP(ByVal FechaCierre As Date, ByVal sp As String) As Decimal

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                         GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        Dim decTotalFacturasApartados As Decimal


        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[" & sp & "]"
            .CommandType = System.Data.CommandType.StoredProcedure

            '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@StatusFactura", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TotalFacturaTE", System.Data.SqlDbType.Decimal))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TotalFacturaTD", System.Data.SqlDbType.Decimal))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TotalApartadoTE", System.Data.SqlDbType.Decimal))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TotalApartadoTD", System.Data.SqlDbType.Decimal))


            'OutPut :
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TotalFacturasAbonosApartados", System.Data.SqlDbType.Decimal))
            .Parameters("@TotalFacturasAbonosApartados").Direction = ParameterDirection.Output

        End With


        Try

            sccnnConnection.Open()

            With sccmdSelect

                'Assign Parameters Values
                .Parameters("@Fecha").Value = Format(FechaCierre, "Short Date")
                .Parameters("@StatusFactura").Value = "GRA"
                .Parameters("@TotalFacturaTE").Value = 0.0
                .Parameters("@TotalFacturaTD").Value = 0.0
                .Parameters("@TotalApartadoTE").Value = 0.0
                .Parameters("@TotalApartadoTD").Value = 0.0
                .Parameters("@TotalFacturasAbonosApartados").Value = 0


                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    With scdrReader

                        If (.IsDBNull(0) = False) Then

                            'Return .GetDecimal(0)
                            decTotalFacturasApartados = .GetDecimal(0)

                        Else

                            scdrReader.Close()
                            sccnnConnection.Close()

                            decTotalFacturasApartados = 0

                        End If

                    End With

                Else

                    scdrReader.Close()
                    sccnnConnection.Close()

                    decTotalFacturasApartados = 0

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


        Return decTotalFacturasApartados

    End Function
    Public Function TotalFacturasASel(ByVal FechaCierre As Date) As DataSet

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                         GetConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaFacturasA As SqlDataAdapter
        Dim dsFacturasA As DataSet

        sccmdSelectAll = New SqlCommand
        scdaFacturasA = New SqlDataAdapter
        dsFacturasA = New DataSet

        With sccmdSelectAll

            .Connection = sccnnConnection

            .CommandText = "[CierreDeCajaTotalFacturasAGET]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar, 2))

            .Parameters("@Fecha").Value = Format(FechaCierre, "Short Date")
            .Parameters("@CodCaja").Value = oParent.ApplicationContext.ApplicationConfiguration.NoCaja
        End With

        scdaFacturasA.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            'Fill DataSet
            scdaFacturasA.Fill(dsFacturasA)

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

        Return dsFacturasA

    End Function

    Public Function GetTotalFacturasASel(ByVal FechaCierre As Date) As DataSet

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                         GetConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaFacturasA As SqlDataAdapter
        Dim dsFacturasA As DataSet

        sccmdSelectAll = New SqlCommand
        scdaFacturasA = New SqlDataAdapter
        dsFacturasA = New DataSet

        With sccmdSelectAll

            .Connection = sccnnConnection

            .CommandText = "[CierreDeCajaTotalFacturasAGET]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar, 2))

            .Parameters("@Fecha").Value = Format(FechaCierre, "Short Date")
            .Parameters("@CodCaja").Value = oParent.ApplicationContext.ApplicationConfiguration.NoCaja
        End With

        scdaFacturasA.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            'Fill DataSet
            scdaFacturasA.Fill(dsFacturasA)

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

        Return dsFacturasA

    End Function

    Public Function GetTotalIngresosSel(ByVal FechaCierre As Date) As DataSet

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                         GetConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaIngresos As SqlDataAdapter
        Dim dsIngresos As DataSet

        sccmdSelectAll = New SqlCommand
        scdaIngresos = New SqlDataAdapter
        dsIngresos = New DataSet

        With sccmdSelectAll

            .Connection = sccnnConnection

            .CommandText = "[CierreDiaReporteAuditoria]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime))

            .Parameters("@Fecha").Value = Format(FechaCierre, "Short Date")
        End With

        scdaIngresos.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            'Fill DataSet
            scdaIngresos.Fill(dsIngresos)

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

    Public Function TotalFacturasASelREP(ByVal FechaCierre As Date) As DataSet

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                         GetConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaFacturasA As SqlDataAdapter
        Dim dsFacturasA As DataSet

        sccmdSelectAll = New SqlCommand
        scdaFacturasA = New SqlDataAdapter
        dsFacturasA = New DataSet

        With sccmdSelectAll

            .Connection = sccnnConnection

            .CommandText = "[CierreDeCajaTotalFacturasAGETREP]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime))


            .Parameters("@Fecha").Value = Format(FechaCierre, "Short Date")

        End With

        scdaFacturasA.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            'Fill DataSet
            scdaFacturasA.Fill(dsFacturasA)

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

        Return dsFacturasA

    End Function
    Public Function TotalFacturasCSel(ByVal FechaCierre As Date) As DataSet

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                         GetConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaFacturasC As SqlDataAdapter
        Dim dsFacturasC As DataSet

        sccmdSelectAll = New SqlCommand
        scdaFacturasC = New SqlDataAdapter
        dsFacturasC = New DataSet

        With sccmdSelectAll

            .Connection = sccnnConnection

            .CommandText = "[CierreDeCajaTotalFacturasCGET]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar, 2))

            .Parameters("@Fecha").Value = Format(FechaCierre, "Short Date")
            .Parameters("@CodCaja").Value = oParent.ApplicationContext.ApplicationConfiguration.NoCaja
        End With

        scdaFacturasC.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            'Fill DataSet
            scdaFacturasC.Fill(dsFacturasC)

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

        Return dsFacturasC

    End Function
    Public Function TotalFacturasCSelREP(ByVal FechaCierre As Date) As DataSet

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                         GetConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaFacturasC As SqlDataAdapter
        Dim dsFacturasC As DataSet

        sccmdSelectAll = New SqlCommand
        scdaFacturasC = New SqlDataAdapter
        dsFacturasC = New DataSet

        With sccmdSelectAll

            .Connection = sccnnConnection

            .CommandText = "[CierreDeCajaTotalFacturasCGETREP]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime))

            .Parameters("@Fecha").Value = Format(FechaCierre, "Short Date")

        End With

        scdaFacturasC.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            'Fill DataSet
            scdaFacturasC.Fill(dsFacturasC)

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

        Return dsFacturasC

    End Function

#End Region

#Region "DP CARD"

    '---------------------------------------------------------------------------------------------------------------
    ' JNAVA (24.03.2015): Obtenemos lo correspondiente a los Abonos de DPCARD
    '---------------------------------------------------------------------------------------------------------------
    Public Function GetTotalPagosDPCA(ByVal CodAlmacen As String, ByVal FechaInicio As DateTime, ByVal FechaFin As DateTime) As Hashtable

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                         GetConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaDPCA As SqlDataAdapter
        Dim dsDPCA As DataSet
        Dim PagosDPCA As New Hashtable

        sccmdSelectAll = New SqlCommand
        scdaDPCA = New SqlDataAdapter
        dsDPCA = New DataSet

        With sccmdSelectAll

            .Connection = sccnnConnection

            .CommandText = "[GetTotalPagosDPCA]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaInicial", System.Data.SqlDbType.DateTime))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaFinal", System.Data.SqlDbType.DateTime))

            .Parameters("@CodAlmacen").Value = CodAlmacen
            .Parameters("@FechaInicial").Value = FechaInicio
            .Parameters("@FechaFinal").Value = FechaFin

        End With

        scdaDPCA.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()
            'Fill DataSet
            scdaDPCA.Fill(dsDPCA)
            sccnnConnection.Close()

            If dsDPCA.Tables.Count > 0 Then
                PagosDPCA("TOTAL") = dsDPCA.Tables(0).Rows(0).Item("Total")
                PagosDPCA("EFECTIVO") = dsDPCA.Tables(1).Rows(0).Item("Efectivo")
                PagosDPCA("TARJETA") = dsDPCA.Tables(2).Rows(0).Item("Tarjeta")
            Else
                PagosDPCA("TOTAL") = 0
                PagosDPCA("EFECTIVO") = 0
                PagosDPCA("TARJETA") = 0
            End If

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

        Return PagosDPCA

    End Function

#End Region


End Class
