
Imports System.Data.SqlClient
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos
Imports System.DBNull
Imports System.IO
Imports System.Data.Odbc


Public Class TraspasosSalidaDataGateway

    Private oParent As TraspasosSalidaManager
    Dim strConnectionStringServer As String = ""

#Region "Constructors / Destructors"

    Public Sub New(ByVal Parent As TraspasosSalidaManager)
        oParent = Parent
        If Not oParent.ConfigCierreFI Is Nothing Then
            strConnectionStringServer = "data source = " & oParent.ConfigCierreFI.ServerTraspasos & "; initial catalog = " & oParent.ConfigCierreFI.BaseDatosTraspasos & _
                                        "; user id = " & oParent.ConfigCierreFI.UserTraspasos & "; password = " & _
                                        oParent.ConfigCierreFI.PasswordTraspasos
        End If
    End Sub

#End Region

#Region "Properties"

    Public Property Parent() As TraspasosSalidaManager
        Get
            Return oParent
        End Get
        Set(ByVal Value As TraspasosSalidaManager)
            oParent = Value
        End Set
    End Property

#End Region

#Region "Methods"

    Public Function [Select](ByVal TraspasoID As String, Optional ByVal TraspasoSalidaTarget As TraspasoSalida = Nothing) As TraspasoSalida

        'TODO: JHV - Implementar retorno de TraspasoSalida
        'NOTE: Si se especifica TraspasoSalidaTarget, utilizar ese en lugar de crear y devolver uno nuevo

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        Dim dsDataSet As DataSet
        dsDataSet = New DataSet("TraspasoCorrida")

        Dim oTraspasoSalida As TraspasoSalida




1:      If Not (TraspasoSalidaTarget Is Nothing) Then

2:          oTraspasoSalida = TraspasoSalidaTarget
        Else

3:          oTraspasoSalida = New TraspasoSalida(oParent)

4:      End If


5:      sccmdSelect = New SqlCommand

        With sccmdSelect

6:          .Connection = sccnnConnection
7:          .CommandText = "[TraspasoSalidaSel]"
8:          .CommandType = System.Data.CommandType.StoredProcedure

9:          .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
10:         .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TraspasoID", System.Data.SqlDbType.Int))

        End With

        Try

11:         sccnnConnection.Open()

            With sccmdSelect
                'Assign Parameters Values
12:             .Parameters("@TraspasoID").Value = TraspasoID

                'Execute Command
13:             scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
14:             scdrReader.Read()

15:             If (scdrReader.HasRows) Then

                    'Traspaso General :
                    With scdrReader

16:                     oTraspasoSalida.AlmacenDestinoID = .GetString(0).ToUpper
17:                     oTraspasoSalida.AlmacenOrigenID = .GetString(1).ToUpper

18:                     oTraspasoSalida.TransportistaID = .GetString(2)
19:                     oTraspasoSalida.TraspasoID = .GetInt32(3)
20:                     oTraspasoSalida.TraspasoCreadoEl = .GetDateTime(4)
21:                     oTraspasoSalida.MonedaID = .GetString(5).ToUpper
22:                     oTraspasoSalida.TotalBultos = .GetInt32(6)
23:                     oTraspasoSalida.Guia = .GetString(7).ToUpper
24:                     oTraspasoSalida.SubTotal = .GetDecimal(8)
25:                     oTraspasoSalida.Status = .GetString(9)

26:                     If (IsDBNull(.Item(10)) = True) Then
27:                         oTraspasoSalida.Referencia = String.Empty
                        Else
28:                         oTraspasoSalida.Referencia = .GetString(10)
                        End If

29:                     If (IsDBNull(.Item(11)) <> True) Then
30:                         oTraspasoSalida.TraspasoRecibidoEl = .GetDateTime(11)
                        End If

31:                     oTraspasoSalida.Folio = .GetString(12)
32:                     oTraspasoSalida.AutorizadoPorID = .GetString(13)

33:                     oTraspasoSalida.NumConsecutivo = .GetInt32(14)


34:                     If (IsDBNull(.Item(15)) <> True) Then
35:                         oTraspasoSalida.Observaciones = .GetString(15)
                        End If

36:                     If (IsDBNull(.Item(16)) <> True) Then
37:                         oTraspasoSalida.FolioSAP = .GetString(16)
                        End If
38:                     oTraspasoSalida.TEOrigen = .GetString(.GetOrdinal("TEOrigen")).Trim

                        If (IsDBNull(.Item(18)) <> True) Then
                            oTraspasoSalida.TraspasoConFaltante = .GetString(18)
                        End If

39:                     .Close()

                    End With


                    'Traspaso Corrida [GRID] :

                    Dim scdaAdapter As New SqlDataAdapter

40:                 sccmdSelect.Dispose()
41:                 sccmdSelect = Nothing

42:                 sccmdSelect = New SqlCommand

                    With sccmdSelect

43:                     .Connection = sccnnConnection

44:                     .CommandText = "[TraspasoCorridaSalidaSel]"
45:                     .CommandType = System.Data.CommandType.StoredProcedure

46:                     .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
47:                     .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TraspasoID", System.Data.SqlDbType.Int))

48:                     .Parameters("@TraspasoID").Value = TraspasoID

                    End With

49:                 scdaAdapter.SelectCommand = sccmdSelect
50:                 scdaAdapter.Fill(dsDataSet, "TraspasoCorrida")

51:                 oTraspasoSalida.Detalle = dsDataSet

52:                 dsDataSet.Dispose()
53:                 sccmdSelect.Dispose()
54:                 scdaAdapter.Dispose()

55:                 dsDataSet = Nothing
56:                 sccmdSelect = Nothing
57:                 scdaAdapter = Nothing

58:                 oTraspasoSalida.ResetFlagIsNew()
59:                 oTraspasoSalida.ResetFlagIsDirty()

                Else
60:                 oTraspasoSalida = Nothing
                End If

            End With

61:         sccnnConnection.Close()

        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            oParent.EscribeLog(oSqlException.ToString, "Error al leer el traspaso de salida: Linea " & Err.Erl)
            Throw New ApplicationException("El registro no pudo ser leido debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            oParent.EscribeLog(ex.ToString, "Error al leer el traspaso de salida: Linea " & Err.Erl)
            Throw New ApplicationException("El registro no pudo ser leido debido a un error de aplicación.", ex)

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return oTraspasoSalida

    End Function

    Public Function SelectTFByFolio(ByVal TraspasoID As Integer) As TraspasoSalida

        Dim sccnnConnection As New SqlConnection(Me.strConnectionStringServer)

        Dim sccmdSelect As SqlCommand
        Dim scdaAdapter As New SqlDataAdapter
        Dim oRow As DataRow

        Dim dsDataSet As New DataSet("TraspasoFisico")

        Dim oTraspasoSalida As New TraspasoSalida(oParent)

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[TraspasoFisicoSel]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Folio", System.Data.SqlDbType.Int))

        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect
                'Assign Parameters Values
                .Parameters("@Folio").Value = TraspasoID

                'Execute Command
                scdaAdapter.SelectCommand = sccmdSelect
                scdaAdapter.Fill(dsDataSet)

                'Traspaso General :
                For Each oRow In dsDataSet.Tables(0).Rows
                    With oRow
                        oTraspasoSalida.AlmacenDestinoID = !Destino
                        oTraspasoSalida.AlmacenOrigenID = !Origen
                        oTraspasoSalida.Folio = !FolioTraspaso
                        oTraspasoSalida.AutorizadoPorID = !Usuario
                        oTraspasoSalida.Observaciones = !Observaciones
                        oTraspasoSalida.TraspasoCreadoEl = !Fecha
                        oTraspasoSalida.TraspasoID = !MovID
                    End With
                Next

                oTraspasoSalida.Detalle = dsDataSet

                dsDataSet.Dispose()
                sccmdSelect.Dispose()
                scdaAdapter.Dispose()

                dsDataSet = Nothing
                sccmdSelect = Nothing
                scdaAdapter = Nothing

                oTraspasoSalida.ResetFlagIsNew()
                oTraspasoSalida.ResetFlagIsDirty()

            End With

            sccnnConnection.Close()

        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            oParent.EscribeLog(oSqlException.ToString, "Error al leer el traspaso de salida: Linea " & Err.Erl)
            Throw New ApplicationException("El registro no pudo ser leido debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            oParent.EscribeLog(ex.ToString, "Error al leer el traspaso de salida: Linea " & Err.Erl)
            Throw New ApplicationException("El registro no pudo ser leido debido a un error de aplicación.", ex)

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return oTraspasoSalida

    End Function

    Public Function SelectTFSelAll(ByVal Origen As String) As DataSet

        Dim sccnnConnection As New SqlConnection(Me.strConnectionStringServer)

        Dim sccmdSelect As SqlCommand
        Dim scdaAdapter As New SqlDataAdapter

        Dim dsDataSet As New DataSet("TraspasosFisicos")

        Dim oTraspasoSalida As TraspasoSalida

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[TraspasoFisicoSelAll]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Parameters.Add(New SqlParameter("@Origen", SqlDbType.NChar, 5))

        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect
                'Assign Parameters Values
                .Parameters("@Origen").Value = Origen.Trim.PadLeft(3, "0")

                'Execute Command
                scdaAdapter.SelectCommand = sccmdSelect
                scdaAdapter.Fill(dsDataSet, "TraspasosFisicos")

                sccmdSelect.Dispose()
                scdaAdapter.Dispose()

                sccmdSelect = Nothing
                scdaAdapter = Nothing

            End With

            sccnnConnection.Close()

        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            oParent.EscribeLog(oSqlException.ToString, "Error al leer el traspaso de salida: Linea " & Err.Erl)
            Throw New ApplicationException("El registro no pudo ser leido debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            oParent.EscribeLog(ex.ToString, "Error al leer el traspaso de salida: Linea " & Err.Erl)
            Throw New ApplicationException("El registro no pudo ser leido debido a un error de aplicación.", ex)

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return dsDataSet

    End Function

    Public Function SelectTFNextFolio() As Integer
        Dim sccnnConnection As New SqlConnection(strConnectionStringServer)
        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader
        Dim folio As Integer = 0
        sccmdSelect = New SqlCommand
        With sccmdSelect
            .Connection = sccnnConnection
            .CommandText = "[TraspasoFisicoSelFolio]"
            .CommandType = System.Data.CommandType.StoredProcedure
        End With
        Try
            sccnnConnection.Open()
            folio = CInt(sccmdSelect.ExecuteScalar())
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
        Return folio
    End Function

    Public Function SelectTFNextCaja(ByVal movId As Integer) As Integer
        Dim conexion As New SqlConnection(strConnectionStringServer)
        Dim command As New SqlCommand("TraspasoFisicoSelCajaID", conexion)
        Dim folio As Integer = 0
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@MovID", movId)
            folio = CInt(command.ExecuteScalar())
            command.Dispose()
            conexion.Close()
            conexion.Dispose()
        Catch ex As Exception
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
                conexion.Dispose()
            End If
            Throw New ApplicationException("El registro no pudo ser leido debido a un error en la aplicación", ex)
        End Try
        Return folio
    End Function

    Public Function SelectByFolioSAP(ByVal FolioSAP As String) As TraspasoSalida

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                         GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        Dim dsDataSet As DataSet
        dsDataSet = New DataSet("TraspasoCorrida")

        Dim oTraspasoSalida As TraspasoSalida

        oTraspasoSalida = New TraspasoSalida(oParent)

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[TraspasoSalidaSelByFolioSAP]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioSAP", System.Data.SqlDbType.VarChar, 10))

        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect
                'Assign Parameters Values
                .Parameters("@FolioSAP").Value = FolioSAP.Trim

                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    'Traspaso General :
                    With scdrReader

                        oTraspasoSalida.AlmacenDestinoID = .GetString(0).ToUpper
                        oTraspasoSalida.AlmacenOrigenID = .GetString(1).ToUpper

                        oTraspasoSalida.TransportistaID = .GetString(2)
                        oTraspasoSalida.TraspasoID = .GetInt32(3)
                        oTraspasoSalida.TraspasoCreadoEl = .GetDateTime(4)
                        oTraspasoSalida.MonedaID = .GetString(5).ToUpper
                        oTraspasoSalida.TotalBultos = .GetInt32(6)
                        oTraspasoSalida.Guia = .GetString(7).ToUpper
                        oTraspasoSalida.SubTotal = .GetDecimal(8)
                        oTraspasoSalida.Status = .GetString(9)

                        If (IsDBNull(.Item(10)) = True) Then
                            oTraspasoSalida.Referencia = String.Empty
                        Else
                            oTraspasoSalida.Referencia = .GetString(10)
                        End If

                        If (IsDBNull(.Item(11)) <> True) Then
                            oTraspasoSalida.TraspasoRecibidoEl = .GetDateTime(11)
                        End If

                        oTraspasoSalida.Folio = .GetString(12)
                        oTraspasoSalida.AutorizadoPorID = .GetString(13)

                        oTraspasoSalida.NumConsecutivo = .GetInt32(14)


                        If (IsDBNull(.Item(15)) <> True) Then
                            oTraspasoSalida.Observaciones = .GetString(15)
                        End If

                        If (IsDBNull(.Item(16)) <> True) Then
                            oTraspasoSalida.FolioSAP = .GetString(16)
                        End If
                        oTraspasoSalida.TEOrigen = .GetString(.GetOrdinal("TEOrigen")).Trim

                        .Close()

                    End With


                    'Traspaso Corrida [GRID] :

                    Dim scdaAdapter As New SqlDataAdapter

                    sccmdSelect.Dispose()
                    sccmdSelect = Nothing

                    sccmdSelect = New SqlCommand

                    With sccmdSelect

                        .Connection = sccnnConnection

                        .CommandText = "[TraspasoCorridaSalidaSel]"
                        .CommandType = System.Data.CommandType.StoredProcedure

                        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
                        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TraspasoID", System.Data.SqlDbType.Int))

                        .Parameters("@TraspasoID").Value = oTraspasoSalida.TraspasoID

                    End With

                    scdaAdapter.SelectCommand = sccmdSelect
                    scdaAdapter.Fill(dsDataSet, "TraspasoCorrida")

                    oTraspasoSalida.Detalle = dsDataSet

                    dsDataSet.Dispose()
                    sccmdSelect.Dispose()
                    scdaAdapter.Dispose()

                    dsDataSet = Nothing
                    sccmdSelect = Nothing
                    scdaAdapter = Nothing

                    oTraspasoSalida.ResetFlagIsNew()
                    oTraspasoSalida.ResetFlagIsDirty()
                Else
                    oTraspasoSalida = Nothing
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

        Return oTraspasoSalida

    End Function

    Public Function SelectByEntrega(ByVal Entrega As String) As TraspasoSalida

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                         GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        Dim dsDataSet As DataSet
        dsDataSet = New DataSet("TraspasoCorrida")

        Dim oTraspasoSalida As TraspasoSalida

        oTraspasoSalida = New TraspasoSalida(oParent)

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[TraspasoSalidaSelByEntrega]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Entrega", System.Data.SqlDbType.VarChar, 10))

        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect
                'Assign Parameters Values
                .Parameters("@Entrega").Value = Entrega.Trim

                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    'Traspaso General :
                    With scdrReader

                        oTraspasoSalida.AlmacenDestinoID = .GetString(0).ToUpper
                        oTraspasoSalida.AlmacenOrigenID = .GetString(1).ToUpper

                        oTraspasoSalida.TransportistaID = .GetString(2)
                        oTraspasoSalida.TraspasoID = .GetInt32(3)
                        oTraspasoSalida.TraspasoCreadoEl = .GetDateTime(4)
                        oTraspasoSalida.MonedaID = .GetString(5).ToUpper
                        oTraspasoSalida.TotalBultos = .GetInt32(6)
                        oTraspasoSalida.Guia = .GetString(7).ToUpper
                        oTraspasoSalida.SubTotal = .GetDecimal(8)
                        oTraspasoSalida.Status = .GetString(9)

                        If (IsDBNull(.Item(10)) = True) Then
                            oTraspasoSalida.Referencia = String.Empty
                        Else
                            oTraspasoSalida.Referencia = .GetString(10)
                        End If

                        If (IsDBNull(.Item(11)) <> True) Then
                            oTraspasoSalida.TraspasoRecibidoEl = .GetDateTime(11)
                        End If

                        oTraspasoSalida.Folio = .GetString(12)
                        oTraspasoSalida.AutorizadoPorID = .GetString(13)

                        oTraspasoSalida.NumConsecutivo = .GetInt32(14)


                        If (IsDBNull(.Item(15)) <> True) Then
                            oTraspasoSalida.Observaciones = .GetString(15)
                        End If

                        If (IsDBNull(.Item(16)) <> True) Then
                            oTraspasoSalida.FolioSAP = .GetString(16)
                        End If
                        oTraspasoSalida.TEOrigen = .GetString(.GetOrdinal("TEOrigen")).Trim
                        oTraspasoSalida.Entrega = CStr(scdrReader("Entrega"))
                        .Close()

                    End With


                    'Traspaso Corrida [GRID] :

                    Dim scdaAdapter As New SqlDataAdapter

                    sccmdSelect.Dispose()
                    sccmdSelect = Nothing

                    sccmdSelect = New SqlCommand

                    With sccmdSelect

                        .Connection = sccnnConnection

                        .CommandText = "[TraspasoCorridaSalidaSel]"
                        .CommandType = System.Data.CommandType.StoredProcedure

                        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
                        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TraspasoID", System.Data.SqlDbType.Int))

                        .Parameters("@TraspasoID").Value = oTraspasoSalida.TraspasoID

                    End With

                    scdaAdapter.SelectCommand = sccmdSelect
                    scdaAdapter.Fill(dsDataSet, "TraspasoCorrida")

                    oTraspasoSalida.Detalle = dsDataSet

                    dsDataSet.Dispose()
                    sccmdSelect.Dispose()
                    scdaAdapter.Dispose()

                    dsDataSet = Nothing
                    sccmdSelect = Nothing
                    scdaAdapter = Nothing

                    oTraspasoSalida.ResetFlagIsNew()
                    oTraspasoSalida.ResetFlagIsDirty()
                Else
                    oTraspasoSalida = Nothing
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

        Return oTraspasoSalida

    End Function





    'Traspasos Pendientes por Aplicar :
    Public Function SelectAll(ByVal AlmacenOrigenID As String, ByVal AlmacenDestinoID As String, _
                              ByVal FromDate As Date, ByVal ToDate As Date) As DataSet

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                         GetConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaTraspasoEntrada As SqlDataAdapter
        Dim dsTraspasoEntrada As DataSet



        sccmdSelectAll = New SqlCommand
        scdaTraspasoEntrada = New SqlDataAdapter
        dsTraspasoEntrada = New DataSet("Traspaso")

        With sccmdSelectAll

            .Connection = sccnnConnection

            .CommandText = "[TraspasoSelAll]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@AlmacenOrigenID", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@AlmacenDestinoID", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FromDate", System.Data.SqlDbType.DateTime))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ToDate", System.Data.SqlDbType.DateTime))

        End With

        scdaTraspasoEntrada.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            scdaTraspasoEntrada.SelectCommand.Parameters("@AlmacenOrigenID").Value = AlmacenOrigenID
            scdaTraspasoEntrada.SelectCommand.Parameters("@AlmacendestinoID").Value = AlmacenDestinoID
            scdaTraspasoEntrada.SelectCommand.Parameters("@FromDate").Value = FromDate
            scdaTraspasoEntrada.SelectCommand.Parameters("@ToDate").Value = ToDate

            'Fill DataSet
            scdaTraspasoEntrada.Fill(dsTraspasoEntrada, "Traspaso")

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

        Return dsTraspasoEntrada

    End Function

    Public Function SelectAll(ByVal strAlmacenID As String) As DataSet

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaTraspasoSalida As SqlDataAdapter
        Dim dsTraspasoSalida As DataSet



        sccmdSelectAll = New SqlCommand
        scdaTraspasoSalida = New SqlDataAdapter
        dsTraspasoSalida = New DataSet("Traspaso")

        With sccmdSelectAll

            .Connection = sccnnConnection

            .CommandText = "[TraspasoSalidaSelAll]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 3))

        End With

        scdaTraspasoSalida.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            scdaTraspasoSalida.SelectCommand.Parameters("@CodAlmacen").Value = strAlmacenID

            'Fill DataSet
            scdaTraspasoSalida.Fill(dsTraspasoSalida, "Traspaso")

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

        Return dsTraspasoSalida

    End Function


    Public Function SelectAllTraspasosPendientes() As DataSet

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                         GetConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaTraspasoEntrada As SqlDataAdapter
        Dim dsTraspasoEntrada As DataSet

        sccmdSelectAll = New SqlCommand
        scdaTraspasoEntrada = New SqlDataAdapter
        dsTraspasoEntrada = New DataSet("TraspasosPendientes")

        With sccmdSelectAll

            .Connection = sccnnConnection

            .CommandText = "[TraspasosPendientesSelAll]"
            .CommandType = System.Data.CommandType.StoredProcedure

        End With

        scdaTraspasoEntrada.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            'Fill DataSet
            scdaTraspasoEntrada.Fill(dsTraspasoEntrada, "TraspasosPendientes")

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

        Return dsTraspasoEntrada

    End Function

    Public Function SelectDataDetail(ByVal CodArticulo As String) As DataRowCollection

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaDefectuoso As SqlDataAdapter
        Dim dsDefectuoso As DataSet

        sccmdSelectAll = New SqlCommand
        scdaDefectuoso = New SqlDataAdapter
        dsDefectuoso = New DataSet("Defectuosos")

        With sccmdSelectAll

            .Connection = sccnnConnection

            .CommandText = "[DefectuososSelDatosDetalle]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodArticulo", System.Data.SqlDbType.VarChar, 20))

        End With

        scdaDefectuoso.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            scdaDefectuoso.SelectCommand.Parameters("@CodArticulo").Value = CodArticulo

            'Fill DataSet
            scdaDefectuoso.Fill(dsDefectuoso, "Defectuosos")

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

        If dsDefectuoso.Tables("Defectuosos").Rows.Count >= 1 Then
            Return dsDefectuoso.Tables("Defectuosos").Rows
        End If

    End Function


    Public Function SelectDataGeneral(ByVal CodArticulo As String) As DataRow

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaDefectuoso As SqlDataAdapter
        Dim dsDefectuoso As DataSet

        sccmdSelectAll = New SqlCommand
        scdaDefectuoso = New SqlDataAdapter
        dsDefectuoso = New DataSet("Defectuosos")

        With sccmdSelectAll

            .Connection = sccnnConnection

            .CommandText = "[DefectuososSelDataGrales]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodArticulo", System.Data.SqlDbType.VarChar, 20))

        End With

        scdaDefectuoso.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            scdaDefectuoso.SelectCommand.Parameters("@CodArticulo").Value = CodArticulo

            'Fill DataSet
            scdaDefectuoso.Fill(dsDefectuoso, "Defectuosos")

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

        If dsDefectuoso.Tables("Defectuosos").Rows.Count >= 1 Then
            Return dsDefectuoso.Tables("Defectuosos").Rows(0)
        End If

    End Function

    Public Function SelectMaterialTalla(ByVal strCodUPC As String) As DataSet


        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaTraspasoEntrada As SqlDataAdapter
        Dim dsTraspasoEntrada As DataSet



        sccmdSelectAll = New SqlCommand
        scdaTraspasoEntrada = New SqlDataAdapter
        dsTraspasoEntrada = New DataSet

        With sccmdSelectAll

            .Connection = sccnnConnection

            .CommandText = "[TraspasoSelMaterialTalla]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodUPC", System.Data.SqlDbType.VarChar, 18))

            .Parameters("@CodUPC").Value = strCodUPC

        End With

        scdaTraspasoEntrada.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            'Fill DataSet
            scdaTraspasoEntrada.Fill(dsTraspasoEntrada)

            sccnnConnection.Close()


        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("Los registros no pudieron ser leidos debido a un error de base de datos." & oSqlException.Message, oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("Los registros no pudieron ser leidos debido a un error de aplicación. " & ex.Message, ex)

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return dsTraspasoEntrada

    End Function
    Private Function Fm_bolValidarTraspasoSalida(ByVal TraspasoDetalle As DataSet, ByVal Destino As String) As Boolean

        Dim odrArticulo As DataRow
        Dim odsCatalogoCorridas As New DataSet
        Dim odrFiltroCorrida() As DataRow

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                                 DataStorageConfiguration.GetConnectionString)

        Try
            sccnnConnection.Open()

            'Extaer Catálogo Corridas.
            odsCatalogoCorridas = SelectCatalogoCorridas()


            For Each odrArticulo In TraspasoDetalle.Tables(0).Rows

                'Obtener la corrida de cada Artículo.
                odrFiltroCorrida = odsCatalogoCorridas.Tables("CatalogoCorridas").Select("CodCorrida = '" & CType(odrArticulo("CodCorrida"), String) & "'")  '.GetType.ToString & "'")

                Dim intNumTalla As Integer
                Dim intCantidadPorTalla As Integer

                For intNumTalla = 1 To 20

                    intCantidadPorTalla = CType(odrArticulo("C" & Format(intNumTalla, "00")), Integer)

                    If (intCantidadPorTalla > 0) Then

                        If (ValidarCantidadArticulo(intCantidadPorTalla, odrArticulo("CodArticulo"), CType(odrFiltroCorrida(0).Item("C" & Format(intNumTalla, "00")), String), Destino) = False) Then

                            MsgBox("La Cantidad disponible del Artículo " & odrArticulo("CodArticulo") & "- " & odrArticulo("Descripcion") & " es menor.", MsgBoxStyle.Exclamation, "DPTienda")

                            sccnnConnection.Close()
                            sccnnConnection.Dispose()
                            sccnnConnection = Nothing

                            Exit Function

                        End If

                    End If

                Next

            Next

            sccnnConnection.Close()


        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("El registro no pudo ser insertado debido a un error de base de datos.", oSqlException)
            Exit Function

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("El registro no pudo ser insertado debido a un error de aplicación.", ex)
            Exit Function

        End Try


        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return True

    End Function

    Public Sub UpdateGeneral(ByVal pTraspasoSalida As TraspasoSalida)

        'TODO: JHV - Implementar actualizacion de Traspaso
        'NOTE: Aqui actualizar el general del traspaso

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                                 DataStorageConfiguration.GetConnectionString)

        Dim sccmdUpdate As SqlCommand
        sccmdUpdate = New SqlCommand

        Dim sccmdDelete As SqlCommand
        sccmdDelete = New SqlCommand

        With sccmdUpdate

            .Connection = sccnnConnection

            .CommandText = "[TraspasoUpd]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TraspasoID", System.Data.SqlDbType.Int))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Almacen", System.Data.SqlDbType.VarChar, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Origen", System.Data.SqlDbType.VarChar, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Status", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Transportista", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Moneda", System.Data.SqlDbType.VarChar, 2))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Paridad", System.Data.SqlDbType.Money))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@SubTotal", System.Data.SqlDbType.Money))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Cargos", System.Data.SqlDbType.Money))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Autoriza", System.Data.SqlDbType.VarChar, 12))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Bultos", System.Data.SqlDbType.Int))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Guia", System.Data.SqlDbType.VarChar, 15))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Observaciones", System.Data.SqlDbType.Text))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Usuario", System.Data.SqlDbType.VarChar, 12))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TraspasoConFaltante", System.Data.SqlDbType.VarChar, 10))            

            'OutPut :
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime))
            .Parameters("@Fecha").Direction = ParameterDirection.Output

        End With

        Try

            sccnnConnection.Open()

            With sccmdUpdate
                'Assign Parameters Values
                .Parameters("@TraspasoID").Value = pTraspasoSalida.TraspasoID
                .Parameters("@Almacen").Value = pTraspasoSalida.AlmacenOrigenID
                .Parameters("@Origen").Value = pTraspasoSalida.AlmacenDestinoID
                .Parameters("@Status").Value = pTraspasoSalida.Status
                .Parameters("@Transportista").Value = pTraspasoSalida.TransportistaID
                .Parameters("@Moneda").Value = pTraspasoSalida.MonedaID
                .Parameters("@Paridad").Value = pTraspasoSalida.ParidadMonetaria = 0
                .Parameters("@SubTotal").Value = pTraspasoSalida.SubTotal
                .Parameters("@Cargos").Value = pTraspasoSalida.Cargos
                .Parameters("@Autoriza").Value = pTraspasoSalida.AutorizadoPorID
                .Parameters("@Bultos").Value = pTraspasoSalida.TotalBultos
                .Parameters("@Guia").Value = pTraspasoSalida.Guia
                .Parameters("@Observaciones").Value = pTraspasoSalida.Observaciones
                .Parameters("@Usuario").Value = pTraspasoSalida.AutorizadoPorID
                .Parameters("@TraspasoConFaltante").Value = pTraspasoSalida.TraspasoConFaltante

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

    Public Sub UpdateTraspasoPendienteStatus(ByVal TraspasoID As Integer, ByVal UserCancela As String, ByVal Status As String)

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                         DataStorageConfiguration.GetConnectionString)

        Dim sccmdUpdate As SqlCommand
        sccmdUpdate = New SqlCommand

        Dim sccmdDelete As SqlCommand
        sccmdDelete = New SqlCommand

        With sccmdUpdate

            .Connection = sccnnConnection

            .CommandText = "[TraspasosPendientesUpdStatus]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TraspasoID", System.Data.SqlDbType.Int))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@User", System.Data.SqlDbType.VarChar, 12, "Usuario Cancela"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Status", System.Data.SqlDbType.VarChar, 2))

        End With

        Try

            sccnnConnection.Open()

            With sccmdUpdate
                'Assign Parameters Values
                .Parameters("@TraspasoID").Value = TraspasoID
                .Parameters("@User").Value = UserCancela.Trim
                .Parameters("@Status").Value = Status

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

    Public Function UpdateInventario(ByVal TraspasoDetalle As DataSet, ByVal TraspasoID As Integer, ByVal Destino As String) As Boolean

        'TODO: JHV - Implementar actualizacion de inventario aqui
        'NOTE: Aqui meter los articulos recibidos a inventario

        Dim odrArticulo As DataRow
        Dim oCatalogoArticuloMgr As New CatalogoArticuloManager(oParent.ApplicationContext)
        Dim oArticulo As Articulo

        Dim oTraspasoSalidaMgr As New TraspasosSalidaManager(oParent.ApplicationContext)
        Dim oTraspasoSalida As TraspasoSalida

        Dim odsCatalogoCorridas As New DataSet
        Dim odrFiltroCorrida() As DataRow

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                                 DataStorageConfiguration.GetConnectionString)

        Dim sccmdUpdateInventario As SqlCommand
        sccmdUpdateInventario = New SqlCommand



        '1:      If (Fm_bolValidarTraspasoSalida(TraspasoDetalle, Destino) = False) Then
        '            Exit Function
        '2:      End If


        oTraspasoSalida = oTraspasoSalidaMgr.Load(TraspasoID)

        With sccmdUpdateInventario

            .Connection = sccnnConnection

            .CommandText = "[ExistenciasMovimientosIns]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodTipoMov", System.Data.SqlDbType.Int, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TipoMovimiento", System.Data.SqlDbType.VarChar, 1))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@StatusMov", System.Data.SqlDbType.VarChar, 1))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Destino", System.Data.SqlDbType.VarChar, 8))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Folio", System.Data.SqlDbType.Int, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodArticulo", System.Data.SqlDbType.VarChar, 20))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Descripcion", System.Data.SqlDbType.VarChar, 50))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Numero", System.Data.SqlDbType.VarChar, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Total", System.Data.SqlDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(10, Byte), CType(2, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Apartados", System.Data.SqlDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(10, Byte), CType(2, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Defectuosos", System.Data.SqlDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(10, Byte), CType(2, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Promocion", System.Data.SqlDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(10, Byte), CType(2, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@VtasEspeciales", System.Data.SqlDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(10, Byte), CType(2, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Consignacion", System.Data.SqlDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(10, Byte), CType(2, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Transito", System.Data.SqlDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(10, Byte), CType(2, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodLinea", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodMarca", System.Data.SqlDbType.VarChar, 2))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodFamilia", System.Data.SqlDbType.VarChar, 2))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodUnidad", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodUso", System.Data.SqlDbType.VarChar, 8))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCategoria", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Usuario", System.Data.SqlDbType.VarChar, 12))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CostoUnit", System.Data.SqlDbType.Money, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@PrecioUnit", System.Data.SqlDbType.Money, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioControl", System.Data.SqlDbType.VarChar, 7))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar, 2))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Descuento", System.Data.SqlDbType.Money, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TOTFGRAL", System.Data.SqlDbType.Money, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TOTNC", System.Data.SqlDbType.Money, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CostoNC", System.Data.SqlDbType.Money, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@VTA_DIP", System.Data.SqlDbType.VarChar, 1))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioSAP", System.Data.SqlDbType.VarChar, 10))

        End With

        Try
            sccnnConnection.Open()

            'Extaer Catálogo Corridas.
            odsCatalogoCorridas = SelectCatalogoCorridas()

            'Guardar en Existencias cada Artículo con sus respectivas corridas.
            For Each odrArticulo In TraspasoDetalle.Tables(0).Rows

                'Extraer la Información de cada Artículo.
                oArticulo = Nothing
                oArticulo = oCatalogoArticuloMgr.Load(CType(odrArticulo("CodArticulo"), String))

                'Obtener la corrida de cada Artículo.
                odrFiltroCorrida = odsCatalogoCorridas.Tables("CatalogoCorridas").Select("CodCorrida = '" & CType(odrArticulo("CodCorrida"), String) & "'")  '.GetType.ToString & "'")
                With sccmdUpdateInventario
                    .Parameters("@CodTipoMov").Value = 202  '102
                    .Parameters("@TipoMovimiento").Value = "S"  '"E"
                    .Parameters("@StatusMov").Value = "A"
                    .Parameters("@CodAlmacen").Value = oTraspasoSalida.AlmacenOrigenID
                    .Parameters("@Destino").Value = oTraspasoSalida.AlmacenDestinoID
                    .Parameters("@Folio").Value = oTraspasoSalida.Folio
                    .Parameters("@FolioSAP").Value = oTraspasoSalida.FolioSAP
                    .Parameters("@CodArticulo").Value = odrArticulo("CodArticulo")
                    .Parameters("@Descripcion").Value = odrArticulo("Descripcion")
                    .Parameters("@Numero").Value = ""
                    ' .Parameters("@Numero").Value = CType(odrFiltroCorrida(0).Item("C" & Format(intNumTalla, "00")), String)

                    .Parameters("@Total").Value = odrArticulo("Cantidad")
                    .Parameters("@Apartados").Value = 0

                    If oTraspasoSalida.AlmacenDestinoID = "997" Then
                        .Parameters("@Defectuosos").Value = (CInt(odrArticulo("Cantidad")) * -1)  '*-1 para que reste al campo defectuosos
                    Else
                        .Parameters("@Defectuosos").Value = 0
                    End If

                    .Parameters("@Promocion").Value = 0
                    .Parameters("@VtasEspeciales").Value = 0
                    .Parameters("@Consignacion").Value = 0
                    .Parameters("@Transito").Value = 0 'Se quita nomas de Inventario  no se manda a Transito

                    .Parameters("@CodLinea").Value = oArticulo.Codlinea
                    .Parameters("@CodMarca").Value = oArticulo.CodMarca
                    .Parameters("@CodFamilia").Value = oArticulo.CodFamilia
                    .Parameters("@CodUso").Value = oArticulo.CodUso
                    .Parameters("@CodCategoria").Value = Format(oArticulo.CodCategoria, "000")
                    .Parameters("@CodUnidad").Value = oArticulo.CodUnidadVta

                    .Parameters("@Usuario").Value = Left(oParent.ApplicationContext.Security.CurrentUser.SessionLoginName.ToUpper, 12)

                    .Parameters("@CostoUnit").Value = odrArticulo("CostoUnit")
                    .Parameters("@PrecioUnit").Value = odrArticulo("CostoUnit")

                    .Parameters("@FolioControl").Value = "" 'Folio al Iniciar Dia.
                    .Parameters("@CodCaja").Value = oParent.ApplicationContext.ApplicationConfiguration.NoCaja

                    .Parameters("@Descuento").Value = 0
                    .Parameters("@TOTFGRAL").Value = 0
                    .Parameters("@TOTNC").Value = 0
                    .Parameters("@CostoNC").Value = 0
                    .Parameters("@VTA_DIP").Value = "N"


                    'Execute Command
                    .ExecuteNonQuery()

                End With

            Next

            sccnnConnection.Close()


            'Generar Archivo DBF.
            'Sm_TraspasoSalidaDBF(oTraspasoSalida)


        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            oParent.EscribeLog(oSqlException.ToString, "Error al actualizar el inventario por TS " & TraspasoID & ": Linea " & Err.Erl)
            Throw New ApplicationException("El registro no pudo ser insertado debido a un error de base de datos.", oSqlException)
            Exit Function

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            oParent.EscribeLog(ex.ToString, "Error al actualizar el inventario por TS " & TraspasoID & ": Linea " & Err.Erl)
            Throw New ApplicationException("El registro no pudo ser insertado debido a un error de aplicación.", ex)
            Exit Function

        End Try


        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        sccmdUpdateInventario.Dispose()
        sccmdUpdateInventario = Nothing

        oCatalogoArticuloMgr = Nothing
        oArticulo = Nothing

        oTraspasoSalida = Nothing
        oTraspasoSalidaMgr = Nothing

        Return True

    End Function

    Public Function GetArticulosDefectuosos(ByVal strAlmacen As String) As DataSet

        Dim scConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)
        Dim scReporteInventarioAdapter As New SqlDataAdapter
        Dim scRepInvDefectuosos As New SqlCommand
        Dim dsResult As DataSet


        scReporteInventarioAdapter.SelectCommand = scRepInvDefectuosos

        With scRepInvDefectuosos

            .CommandText = "ReporteInventarioDefectuososSel"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Connection = scConnection

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 3))

            .Parameters("@CodAlmacen").Value = strAlmacen

        End With

        Try

            scConnection.Open()

            dsResult = New DataSet


            scReporteInventarioAdapter.Fill(dsResult, "Defectuosos")

            If dsResult.Tables(0).Rows.Count = 0 Then
                dsResult = Nothing
                Exit Function
            End If


        Catch ex As Exception

            Throw ex

        Finally

            If (scConnection.State <> ConnectionState.Closed) Then
                Try
                    scConnection.Close()
                Catch
                End Try
            End If

        End Try

        Return dsResult

    End Function

    Public Function SelectCatalogoCorridas() As DataSet

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim scdaTraspasoCorrida As SqlDataAdapter
        Dim dsTraspasoCorrida As DataSet



        dsTraspasoCorrida = New DataSet("TraspasoCorrida")

        Try
            sccnnConnection.Open()

            scdaTraspasoCorrida = New SqlDataAdapter("SELECT * FROM CatalogoCorridas", sccnnConnection)

            'Fill DataSet
            scdaTraspasoCorrida.Fill(dsTraspasoCorrida, "CatalogoCorridas")

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

        Return dsTraspasoCorrida

    End Function

    Public Sub InsertCorrida(ByVal pTraspasoSalida As TraspasoSalida)

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                                DataStorageConfiguration.GetConnectionString)

        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand

        'Traspaso Corrida :

        sccmdInsert.Dispose()
        sccmdInsert = Nothing

        sccmdInsert = New SqlCommand

        With sccmdInsert

            .Connection = sccnnConnection

            .CommandText = "[TraspasoCorridaIns]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TraspasoID", System.Data.SqlDbType.Int))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Folio", System.Data.SqlDbType.VarChar, 6))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Almacen", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Codigo", System.Data.SqlDbType.VarChar, 20))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Descripcion", System.Data.SqlDbType.VarChar, 40))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Corrida", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CostoUnit", System.Data.SqlDbType.Money))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Cantidad", System.Data.SqlDbType.Decimal))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Importe", System.Data.SqlDbType.Money))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Unidad", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Factor", System.Data.SqlDbType.Real))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@C01", System.Data.SqlDbType.Real))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@C02", System.Data.SqlDbType.Real))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@C03", System.Data.SqlDbType.Real))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@C04", System.Data.SqlDbType.Real))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@C05", System.Data.SqlDbType.Real))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@C06", System.Data.SqlDbType.Real))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@C07", System.Data.SqlDbType.Real))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@C08", System.Data.SqlDbType.Real))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@C09", System.Data.SqlDbType.Real))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@C10", System.Data.SqlDbType.Real))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@C11", System.Data.SqlDbType.Real))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@C12", System.Data.SqlDbType.Real))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@C13", System.Data.SqlDbType.Real))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@C14", System.Data.SqlDbType.Real))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@C15", System.Data.SqlDbType.Real))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@C16", System.Data.SqlDbType.Real))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@C17", System.Data.SqlDbType.Real))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@C18", System.Data.SqlDbType.Real))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@C19", System.Data.SqlDbType.Real))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@C20", System.Data.SqlDbType.Real))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Multiplica", System.Data.SqlDbType.Real))

        End With

        Try

            Dim odrArticulo As DataRow
            Dim intNumTalla As Integer

            sccnnConnection.Open()

            For Each odrArticulo In pTraspasoSalida.Detalle.Tables(0).Rows

                With sccmdInsert

                    'Assign Parameters Values
                    .Parameters("@TraspasoID").Value = pTraspasoSalida.TraspasoID
                    .Parameters("@Folio").Value = pTraspasoSalida.TraspasoID
                    .Parameters("@Almacen").Value = pTraspasoSalida.AlmacenOrigenID
                    .Parameters("@Codigo").Value = odrArticulo("CodArticulo")
                    .Parameters("@Descripcion").Value = odrArticulo("Descripcion")
                    .Parameters("@Corrida").Value = odrArticulo("CodCorrida")
                    .Parameters("@CostoUnit").Value = odrArticulo("CostoUnit")
                    .Parameters("@Cantidad").Value = odrArticulo("Cantidad")
                    .Parameters("@Importe").Value = odrArticulo("CostoTotal")
                    .Parameters("@Unidad").Value = odrArticulo("CodUnidad")
                    .Parameters("@Factor").Value = 1
                    .Parameters("@C01").Value = odrArticulo("C01")
                    .Parameters("@C02").Value = odrArticulo("C02")
                    .Parameters("@C03").Value = odrArticulo("C03")
                    .Parameters("@C04").Value = odrArticulo("C04")
                    .Parameters("@C05").Value = odrArticulo("C05")
                    .Parameters("@C06").Value = odrArticulo("C06")
                    .Parameters("@C07").Value = odrArticulo("C07")
                    .Parameters("@C08").Value = odrArticulo("C08")
                    .Parameters("@C09").Value = odrArticulo("C09")
                    .Parameters("@C10").Value = odrArticulo("C10")
                    .Parameters("@C11").Value = odrArticulo("C11")
                    .Parameters("@C12").Value = odrArticulo("C12")
                    .Parameters("@C13").Value = odrArticulo("C13")
                    .Parameters("@C14").Value = odrArticulo("C14")
                    .Parameters("@C15").Value = odrArticulo("C15")
                    .Parameters("@C16").Value = odrArticulo("C16")
                    .Parameters("@C17").Value = odrArticulo("C17")
                    .Parameters("@C18").Value = odrArticulo("C18")
                    .Parameters("@C19").Value = odrArticulo("C19")
                    .Parameters("@C20").Value = odrArticulo("C20")
                    .Parameters("@Multiplica").Value = 1


                    'Execute Command
                    .ExecuteNonQuery()

                End With

            Next

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

    Public Sub Insert(ByVal pTraspasoSalida As TraspasoSalida)

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                                 DataStorageConfiguration.GetConnectionString)

        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand

        With sccmdInsert

            .Connection = sccnnConnection

            .CommandText = "[TraspasoIns]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Almacen", System.Data.SqlDbType.VarChar, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Origen", System.Data.SqlDbType.VarChar, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Status", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Transportista", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Moneda", System.Data.SqlDbType.VarChar, 2))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Paridad", System.Data.SqlDbType.Money))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@SubTotal", System.Data.SqlDbType.Money))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Cargos", System.Data.SqlDbType.Money))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Autoriza", System.Data.SqlDbType.VarChar, 12))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Bultos", System.Data.SqlDbType.Int))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Guia", System.Data.SqlDbType.VarChar, 15))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Observaciones", System.Data.SqlDbType.VarChar, 255))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Usuario", System.Data.SqlDbType.VarChar, 12))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioSAP", System.Data.SqlDbType.VarChar, 10))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TEOrigen", System.Data.SqlDbType.VarChar, 10))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Modulo", System.Data.SqlDbType.VarChar, 2))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TraspasoConFaltante", System.Data.SqlDbType.VarChar, 10))

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Referencia", System.Data.SqlDbType.VarChar, 6))


            'OutPut :
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TraspasoID", System.Data.SqlDbType.Int))
            .Parameters("@TraspasoID").Direction = ParameterDirection.Output

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime))
            .Parameters("@Fecha").Direction = ParameterDirection.Output

        End With

        Try
            sccnnConnection.Open()

            With sccmdInsert
                'Assign Parameters Values

                .Parameters("@Almacen").Value = pTraspasoSalida.AlmacenOrigenID  'pTraspasoSalida.AlmacenDestinoID
                .Parameters("@Origen").Value = pTraspasoSalida.AlmacenDestinoID  'pTraspasoSalida.AlmacenOrigenID

                .Parameters("@Status").Value = pTraspasoSalida.Status
                .Parameters("@Transportista").Value = pTraspasoSalida.TransportistaID
                .Parameters("@Moneda").Value = pTraspasoSalida.MonedaID
                .Parameters("@Paridad").Value = 1  'Preguntar ???
                .Parameters("@SubTotal").Value = pTraspasoSalida.SubTotal
                '.Parameters("@Cargos").Value = pTraspasoSalida.Cargos
                .Parameters("@Autoriza").Value = pTraspasoSalida.AutorizadoPorID
                .Parameters("@Bultos").Value = pTraspasoSalida.TotalBultos
                .Parameters("@Guia").Value = pTraspasoSalida.Guia
                .Parameters("@Observaciones").Value = pTraspasoSalida.Observaciones
                .Parameters("@Usuario").Value = pTraspasoSalida.AutorizadoPorID

                .Parameters("@Referencia").Value = pTraspasoSalida.Referencia
                .Parameters("@FolioSAP").Value = pTraspasoSalida.FolioSAP.Trim.PadLeft(10, "0")
                .Parameters("@TEOrigen").Value = pTraspasoSalida.TEOrigen.Trim.PadLeft(10, "0")
                .Parameters("@Modulo").Value = pTraspasoSalida.Modulo.Trim.ToUpper
                .Parameters("@TraspasoConFaltante").Value = pTraspasoSalida.TraspasoConFaltante

                'Execute Command
                .ExecuteNonQuery()

                'Actualizar General Traspaso.
                pTraspasoSalida.TraspasoCreadoEl = CType(.Parameters("@Fecha").Value, Date)
                pTraspasoSalida.Folio = CType(.Parameters("@TraspasoID").Value, Integer)
                pTraspasoSalida.TraspasoID = CType(.Parameters("@TraspasoID").Value, Integer)


            End With


            'Traspaso Corrida :

            sccmdInsert.Dispose()
            sccmdInsert = Nothing

            sccmdInsert = New SqlCommand

            With sccmdInsert

                .Connection = sccnnConnection

                .CommandText = "[TraspasoCorridaIns]"
                .CommandType = System.Data.CommandType.StoredProcedure

                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TraspasoID", System.Data.SqlDbType.Int))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Folio", System.Data.SqlDbType.VarChar, 6))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Almacen", System.Data.SqlDbType.VarChar, 3))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Codigo", System.Data.SqlDbType.VarChar, 20))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Descripcion", System.Data.SqlDbType.VarChar, 40))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Corrida", System.Data.SqlDbType.VarChar, 3))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CostoUnit", System.Data.SqlDbType.Money))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Cantidad", System.Data.SqlDbType.Decimal))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Importe", System.Data.SqlDbType.Money))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Unidad", System.Data.SqlDbType.VarChar, 3))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Factor", System.Data.SqlDbType.Real))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@C01", System.Data.SqlDbType.Real))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@C02", System.Data.SqlDbType.Real))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@C03", System.Data.SqlDbType.Real))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@C04", System.Data.SqlDbType.Real))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@C05", System.Data.SqlDbType.Real))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@C06", System.Data.SqlDbType.Real))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@C07", System.Data.SqlDbType.Real))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@C08", System.Data.SqlDbType.Real))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@C09", System.Data.SqlDbType.Real))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@C10", System.Data.SqlDbType.Real))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@C11", System.Data.SqlDbType.Real))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@C12", System.Data.SqlDbType.Real))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@C13", System.Data.SqlDbType.Real))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@C14", System.Data.SqlDbType.Real))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@C15", System.Data.SqlDbType.Real))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@C16", System.Data.SqlDbType.Real))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@C17", System.Data.SqlDbType.Real))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@C18", System.Data.SqlDbType.Real))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@C19", System.Data.SqlDbType.Real))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@C20", System.Data.SqlDbType.Real))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Multiplica", System.Data.SqlDbType.Real))

            End With


            Dim odrArticulo As DataRow
            Dim intNumTalla As Integer

            'For Each odrArticulo In pTraspasoSalida.Detalle.Tables("TraspasoDetalleTmp" & oParent.ApplicationContext.ApplicationConfiguration.NoCaja & ", CatalogoArticulos, CatalogoCorridas").Rows
            For Each odrArticulo In pTraspasoSalida.Detalle.Tables(0).Rows

                With sccmdInsert

                    'Assign Parameters Values

                    .Parameters("@TraspasoID").Value = pTraspasoSalida.TraspasoID
                    .Parameters("@Folio").Value = pTraspasoSalida.TraspasoID
                    .Parameters("@Almacen").Value = pTraspasoSalida.AlmacenOrigenID
                    .Parameters("@Codigo").Value = odrArticulo("CodArticulo")
                    .Parameters("@Descripcion").Value = odrArticulo("Descripcion")
                    .Parameters("@Corrida").Value = "" 'odrArticulo("CodCorrida")
                    .Parameters("@CostoUnit").Value = odrArticulo("CostoUnit")
                    .Parameters("@Cantidad").Value = odrArticulo("Cantidad")
                    .Parameters("@Importe").Value = odrArticulo("CostoTotal")
                    .Parameters("@Unidad").Value = "" 'odrArticulo("CodUnidad")
                    .Parameters("@Factor").Value = 1
                    .Parameters("@C01").Value = 0 'odrArticulo("C01")
                    .Parameters("@C02").Value = 0 'odrArticulo("C02")
                    .Parameters("@C03").Value = 0 'odrArticulo("C03")
                    .Parameters("@C04").Value = 0 'odrArticulo("C04")
                    .Parameters("@C05").Value = 0 'odrArticulo("C05")
                    .Parameters("@C06").Value = 0 'odrArticulo("C06")
                    .Parameters("@C07").Value = 0 'odrArticulo("C07")
                    .Parameters("@C08").Value = 0 'odrArticulo("C08")
                    .Parameters("@C09").Value = 0 'odrArticulo("C09")
                    .Parameters("@C10").Value = 0 'odrArticulo("C10")
                    .Parameters("@C11").Value = 0 'odrArticulo("C11")
                    .Parameters("@C12").Value = 0 'odrArticulo("C12")
                    .Parameters("@C13").Value = 0 'odrArticulo("C13")
                    .Parameters("@C14").Value = 0 'odrArticulo("C14")
                    .Parameters("@C15").Value = 0 'odrArticulo("C15")
                    .Parameters("@C16").Value = 0 'odrArticulo("C16")
                    .Parameters("@C17").Value = 0 'odrArticulo("C17")
                    .Parameters("@C18").Value = 0 'odrArticulo("C18")
                    .Parameters("@C19").Value = 0 'odrArticulo("C19")
                    .Parameters("@C20").Value = 0 'odrArticulo("C20")
                    .Parameters("@Multiplica").Value = 1


                    'Execute Command
                    .ExecuteNonQuery()

                End With

            Next


            'Reset New State of Linea Object 
            pTraspasoSalida.ResetFlagIsNew()
            pTraspasoSalida.ResetFlagIsDirty()

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

    Public Sub InsertTraspasosPedientes(ByVal pTraspasoSalida As TraspasoSalida, ByVal dtDetalle As DataTable)

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                                 DataStorageConfiguration.GetConnectionString)

        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand

        With sccmdInsert

            .Connection = sccnnConnection

            .CommandText = "[TraspasosPendientesIns]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Destino", System.Data.SqlDbType.VarChar, 5))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Origen", System.Data.SqlDbType.VarChar, 5))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Transportista", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@SubTotal", System.Data.SqlDbType.Money))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Bultos", System.Data.SqlDbType.Int))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Guia", System.Data.SqlDbType.VarChar, 15))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Reclamacion", System.Data.SqlDbType.Bit, 1))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Usuario", System.Data.SqlDbType.VarChar, 12))
            '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioSAP", System.Data.SqlDbType.VarChar, 10))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TEOrigen", System.Data.SqlDbType.VarChar, 10))

            'OutPut :
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TraspasoID", System.Data.SqlDbType.Int))
            .Parameters("@TraspasoID").Direction = ParameterDirection.Output
        End With

        Try
            With sccmdInsert
                'Assign Parameters Values

                .Parameters("@Origen").Value = pTraspasoSalida.AlmacenOrigenID
                .Parameters("@Destino").Value = pTraspasoSalida.AlmacenDestinoID
                .Parameters("@Transportista").Value = pTraspasoSalida.TransportistaID
                .Parameters("@SubTotal").Value = pTraspasoSalida.SubTotal
                .Parameters("@Bultos").Value = pTraspasoSalida.TotalBultos
                .Parameters("@Guia").Value = pTraspasoSalida.Guia
                .Parameters("@Reclamacion").Value = CBool(pTraspasoSalida.Observaciones.Trim)
                .Parameters("@Usuario").Value = pTraspasoSalida.AutorizadoPorID
                .Parameters("@TEOrigen").Value = pTraspasoSalida.TEOrigen.Trim.PadLeft(10, "0")

                sccnnConnection.Open()

                'Execute Command
                .ExecuteNonQuery()

                sccnnConnection.Close()

                'Actualizar General Traspaso.
                pTraspasoSalida.TraspasoID = CType(.Parameters("@TraspasoID").Value, Integer)

            End With

            'Traspaso Pedniente Detalle :

            sccmdInsert.Dispose()
            sccmdInsert = Nothing

            sccmdInsert = New SqlCommand

            With sccmdInsert

                .Connection = sccnnConnection

                .CommandText = "[TraspasosPendientesDetalleIns]"
                .CommandType = System.Data.CommandType.StoredProcedure

                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TraspasoPendID", System.Data.SqlDbType.Int))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodArticulo", System.Data.SqlDbType.VarChar, 20))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Talla", System.Data.SqlDbType.VarChar, 5))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Costo", System.Data.SqlDbType.Money))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Cantidad", System.Data.SqlDbType.Int))
            End With

            Dim odrArticulo As DataRow

            sccnnConnection.Open()

            For Each odrArticulo In dtDetalle.Rows

                With sccmdInsert

                    'Assign Parameters Values
                    .Parameters("@TraspasoPendID").Value = pTraspasoSalida.TraspasoID
                    .Parameters("@CodArticulo").Value = odrArticulo("Codigo")
                    .Parameters("@Costo").Value = odrArticulo("Costo")
                    .Parameters("@Cantidad").Value = odrArticulo("Cantidad")
                    .Parameters("@Talla").Value = odrArticulo("Talla")

                    'Execute Command
                    .ExecuteNonQuery()

                End With

            Next

            sccnnConnection.Close()

            'Reset New State of Linea Object 
            pTraspasoSalida.ResetFlagIsNew()
            pTraspasoSalida.ResetFlagIsDirty()

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

    Public Sub InsertInServer(ByVal pTraspasoSalida As TraspasoSalida, ByVal dtDetalle As DataTable)

        Dim sccnnConnection As New SqlConnection(strConnectionStringServer)
        Dim TraspasoID As Integer = 0

        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand

        With sccmdInsert

            .Connection = sccnnConnection

            .CommandText = "[TraspasoSalidaIns]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Almacen", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Origen", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Status", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Transportista", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Moneda", System.Data.SqlDbType.VarChar, 2))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Paridad", System.Data.SqlDbType.Money))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@SubTotal", System.Data.SqlDbType.Money))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Cargos", System.Data.SqlDbType.Money))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Autoriza", System.Data.SqlDbType.VarChar, 12))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Bultos", System.Data.SqlDbType.Int))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Guia", System.Data.SqlDbType.VarChar, 15))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Observaciones", System.Data.SqlDbType.VarChar, 255))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Usuario", System.Data.SqlDbType.VarChar, 12))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioSAP", System.Data.SqlDbType.VarChar, 10))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TEOrigen", System.Data.SqlDbType.VarChar, 10))

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Referencia", System.Data.SqlDbType.VarChar, 6))


            'OutPut :
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TraspasoID", System.Data.SqlDbType.Int))
            .Parameters("@TraspasoID").Direction = ParameterDirection.Output

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime))
            .Parameters("@Fecha").Direction = ParameterDirection.Output

        End With

        Try
            sccnnConnection.Open()

            With sccmdInsert
                'Assign Parameters Values

                .Parameters("@Almacen").Value = pTraspasoSalida.AlmacenOrigenID  'pTraspasoSalida.AlmacenDestinoID
                .Parameters("@Origen").Value = pTraspasoSalida.AlmacenDestinoID  'pTraspasoSalida.AlmacenOrigenID

                .Parameters("@Status").Value = pTraspasoSalida.Status
                .Parameters("@Transportista").Value = pTraspasoSalida.TransportistaID
                .Parameters("@Moneda").Value = pTraspasoSalida.MonedaID
                .Parameters("@Paridad").Value = 1  'Preguntar ???
                .Parameters("@SubTotal").Value = pTraspasoSalida.SubTotal
                '.Parameters("@Cargos").Value = pTraspasoSalida.Cargos
                .Parameters("@Autoriza").Value = pTraspasoSalida.AutorizadoPorID
                .Parameters("@Bultos").Value = pTraspasoSalida.TotalBultos
                .Parameters("@Guia").Value = pTraspasoSalida.Guia
                .Parameters("@Observaciones").Value = pTraspasoSalida.Observaciones
                .Parameters("@Usuario").Value = pTraspasoSalida.AutorizadoPorID

                .Parameters("@Referencia").Value = pTraspasoSalida.Referencia
                .Parameters("@FolioSAP").Value = pTraspasoSalida.FolioSAP.Trim.PadLeft(10, "0")
                .Parameters("@TEOrigen").Value = pTraspasoSalida.TEOrigen.Trim.PadLeft(10, "0")

                'Execute Command
                .ExecuteNonQuery()

                'Actualizar General Traspaso.
                pTraspasoSalida.TraspasoCreadoEl = CType(.Parameters("@Fecha").Value, Date)
                'pTraspasoSalida.Folio = CType(.Parameters("@TraspasoID").Value, Integer)
                'pTraspasoSalida.TraspasoID = CType(.Parameters("@TraspasoID").Value, Integer)
                TraspasoID = CType(.Parameters("@TraspasoID").Value, Integer)
            End With
            '----------------------------------------------------------------------------------------------------------------------------------------------------------------
            'Traspaso Corrida
            '----------------------------------------------------------------------------------------------------------------------------------------------------------------
            sccmdInsert.Dispose()
            sccmdInsert = Nothing

            sccmdInsert = New SqlCommand

            With sccmdInsert

                .Connection = sccnnConnection

                .CommandText = "[TraspasoSalidaCorridaIns]"
                .CommandType = System.Data.CommandType.StoredProcedure

                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TraspasoID", System.Data.SqlDbType.Int))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Codigo", System.Data.SqlDbType.VarChar, 20))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Descripcion", System.Data.SqlDbType.VarChar, 40))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Numero", System.Data.SqlDbType.VarChar, 4))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Cantidad", System.Data.SqlDbType.Decimal))
            End With

            Dim odrArticulo As DataRow

            For Each odrArticulo In dtDetalle.Rows

                With sccmdInsert

                    'Assign Parameters Values
                    '.Parameters("@TraspasoID").Value = pTraspasoSalida.TraspasoID
                    .Parameters("@TraspasoID").Value = TraspasoID
                    .Parameters("@Codigo").Value = odrArticulo("CodArticulo")
                    .Parameters("@Descripcion").Value = odrArticulo("Descripcion")
                    .Parameters("@Numero").Value = odrArticulo("Talla")
                    .Parameters("@Cantidad").Value = odrArticulo("Cantidad")

                    'Execute Command
                    .ExecuteNonQuery()

                End With

            Next

            'Reset New State of Linea Object 
            pTraspasoSalida.ResetFlagIsNew()
            pTraspasoSalida.ResetFlagIsDirty()

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

    Public Sub InsertTF(ByRef pTraspasoSalida As TraspasoSalida, ByVal dtDetalle As DataTable)
        Dim ts As System.Data.SqlClient.SqlTransaction = Nothing
        Dim sccnnConnection As New SqlConnection(strConnectionStringServer)
        Dim TraspasoID As Integer = 0

        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand

        With sccmdInsert

            .Connection = sccnnConnection

            .CommandText = "[TraspasoFisicoIns]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Origen", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Destino", System.Data.SqlDbType.VarChar, 255))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Observaciones", System.Data.SqlDbType.VarChar, 255))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Usuario", System.Data.SqlDbType.VarChar, 20))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Folio", SqlDbType.Int))

            'OutPut :
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@MovID", System.Data.SqlDbType.Int))
            .Parameters("@MovID").Direction = ParameterDirection.InputOutput

        End With

        Try
            sccnnConnection.Open()
            ts = sccnnConnection.BeginTransaction()
            sccmdInsert.Transaction = ts
            With sccmdInsert
                'Assign Parameters Values
                .Parameters("@MovID").Value = pTraspasoSalida.TraspasoID
                .Parameters("@Origen").Value = pTraspasoSalida.AlmacenOrigenID  'pTraspasoSalida.AlmacenDestinoID
                .Parameters("@Destino").Value = pTraspasoSalida.AlmacenDestinoID
                .Parameters("@Observaciones").Value = pTraspasoSalida.Observaciones
                .Parameters("@Usuario").Value = pTraspasoSalida.AutorizadoPorID
                .Parameters("@Folio").Value = pTraspasoSalida.Folio
                'Execute Command
                .ExecuteNonQuery()

                TraspasoID = CType(.Parameters("@MovID").Value, Integer)
                pTraspasoSalida.TraspasoID = TraspasoID
            End With
            '-------------------------------------------------------------------------------------------------------------------------------------
            'Traspaso Fisico Detalle
            '-------------------------------------------------------------------------------------------------------------------------------------
            sccmdInsert.Dispose()
            sccmdInsert = Nothing

            sccmdInsert = New SqlCommand

            With sccmdInsert

                .Connection = sccnnConnection
                .Transaction = ts
                .CommandText = "[TraspasoFisicoDetalleIns]"
                .CommandType = System.Data.CommandType.StoredProcedure

                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@MovID", System.Data.SqlDbType.Int))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CajaID", System.Data.SqlDbType.Int))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Material", System.Data.SqlDbType.VarChar, 20))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Descripcion", System.Data.SqlDbType.VarChar, 50))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Talla", System.Data.SqlDbType.NChar, 5))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Cantidad", System.Data.SqlDbType.Int))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Costo", System.Data.SqlDbType.Decimal))
            End With

            Dim odrArticulo As DataRow

            For Each odrArticulo In dtDetalle.Rows

                With sccmdInsert

                    'Assign Parameters Values
                    '.Parameters("@TraspasoID").Value = pTraspasoSalida.TraspasoID
                    .Parameters("@MovID").Value = TraspasoID
                    .Parameters("@CajaID").Value = odrArticulo("CajaID")
                    .Parameters("@Material").Value = odrArticulo("Codigo")
                    .Parameters("@Descripcion").Value = odrArticulo("Descripcion")
                    .Parameters("@Talla").Value = odrArticulo("Talla")
                    .Parameters("@Cantidad").Value = odrArticulo("Cantidad")
                    .Parameters("@Costo").Value = odrArticulo("Costo")

                    'Execute Command
                    .ExecuteNonQuery()

                End With

            Next
            ts.Commit()
            'Reset New State of Linea Object 
            pTraspasoSalida.ResetFlagIsNew()
            pTraspasoSalida.ResetFlagIsDirty()

            sccnnConnection.Close()

        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    ts.Rollback()
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("El registro no pudo ser insertado debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    ts.Rollback()
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("El registro no pudo ser insertado debido a un error de aplicación.", ex)

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

    End Sub

    Public Function GetTraspasoSalidaDetalleVirtual(ByVal Origen As String) As DataTable
        Dim dtTraspaso As New DataTable("Traspaso")
        Dim conexion As New SqlConnection(strConnectionStringServer)
        Dim command As New SqlCommand("GetTraspasoEntradaDetalleVirtualSel", conexion)
        Dim adapter As SqlDataAdapter = Nothing
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@Origen", Origen)
            adapter = New SqlDataAdapter(command)
            adapter.Fill(dtTraspaso)
            command.Dispose()
            conexion.Close()
        Catch ex As Exception
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            Throw New ApplicationException(ex.Message, ex)
        End Try
        Return dtTraspaso
    End Function

    Public Sub Sm_TraspasoSalidaDBF(ByRef Vp_objTraspasoSalida As TraspasoSalida, Optional ByVal bolMensaje As Boolean = False)

        Dim Vl_strFileNameTRAG As String

        Dim Vl_strFileNameTRAD As String



        Sm_CreateDirectory(Vp_objTraspasoSalida.AlmacenDestinoID, Vl_strFileNameTRAG, Vl_strFileNameTRAD)


        'Traspaso [TRAG, TRAD]

        If (Fm_bolCreateFileTRA(Vl_strFileNameTRAG, Vl_strFileNameTRAD) = False) Then

            Return

        End If


        If (Sm_bolInsertFileTRA(Vp_objTraspasoSalida, Vl_strFileNameTRAG, Vl_strFileNameTRAD) = False) Then

            Return

        End If


        'Renombrar Archivos DBF

        With oParent.ApplicationContext.ApplicationConfiguration

            '<TRAG>

            If File.Exists(.RutaTraspasoSalida & "\" & Vl_strFileNameTRAG & _
                      "." & Right(Vp_objTraspasoSalida.AlmacenOrigenID, 2) & _
                      Fm_strGenerarNumeroConsecutivo(Vp_objTraspasoSalida.NumConsecutivo)) Then

                File.Delete(.RutaTraspasoSalida & "\" & Vl_strFileNameTRAG & _
                      "." & Right(Vp_objTraspasoSalida.AlmacenOrigenID, 2) & _
                      Fm_strGenerarNumeroConsecutivo(Vp_objTraspasoSalida.NumConsecutivo))

            End If

            'Renombrar


            File.Move(.RutaTraspasoSalida & "\" & Vl_strFileNameTRAG & ".DBF", .RutaTraspasoSalida & "\" & Vl_strFileNameTRAG & _
            "." & Right(Vp_objTraspasoSalida.AlmacenOrigenID, 2) & _
            Fm_strGenerarNumeroConsecutivo(Vp_objTraspasoSalida.NumConsecutivo))

            '<TRAG>

            '<TRAD>

            If File.Exists(.RutaTraspasoSalida & "\" & Vl_strFileNameTRAD & _
                      "." & Right(Vp_objTraspasoSalida.AlmacenOrigenID, 2) & _
                      Fm_strGenerarNumeroConsecutivo(Vp_objTraspasoSalida.NumConsecutivo)) Then

                File.Delete(.RutaTraspasoSalida & "\" & Vl_strFileNameTRAD & _
                      "." & Right(Vp_objTraspasoSalida.AlmacenOrigenID, 2) & _
                      Fm_strGenerarNumeroConsecutivo(Vp_objTraspasoSalida.NumConsecutivo))

            End If

            'Renombrar

            File.Move(.RutaTraspasoSalida & "\" & Vl_strFileNameTRAD & ".DBF", .RutaTraspasoSalida & "\" & Vl_strFileNameTRAD & _
                      "." & Right(Vp_objTraspasoSalida.AlmacenOrigenID, 2) & _
                      Fm_strGenerarNumeroConsecutivo(Vp_objTraspasoSalida.NumConsecutivo))

            '<TRAD/>

        End With

        If (bolMensaje = True) Then
            MsgBox("Los Archivos se han creado satisfactoriamente, puede transmitir el Traspaso", MsgBoxStyle.Information, "DPTienda")
        End If

    End Sub



    Private Function Fm_strGenerarNumeroConsecutivo(ByVal intNumConsecutivo As Integer) As String

        Select Case intNumConsecutivo

            Case 0
                Return "0"

            Case 1
                Return "1"

            Case 2
                Return "2"

            Case 3
                Return "3"

            Case 4
                Return "4"

            Case 5
                Return "5"

            Case 6
                Return "6"

            Case 7
                Return "7"

            Case 8
                Return "8"

            Case 9
                Return "9"

            Case 10
                Return "A"

            Case 11
                Return "B"

            Case 12
                Return "C"

            Case 13
                Return "D"

            Case 13
                Return "E"

            Case 14
                Return "F"

            Case 15
                Return "G"

            Case 16
                Return "H"

            Case 17
                Return "I"

            Case 18
                Return "J"

            Case 19
                Return "K"

            Case 20
                Return "L"

            Case 21
                Return "M"

            Case 22
                Return "N"

            Case 23
                Return "Ñ"

            Case 24
                Return "O"

            Case 25
                Return "P"

            Case 26
                Return "Q"

            Case 27
                Return "R"

            Case 28
                Return "S"

            Case 29
                Return "T"

            Case 30
                Return "U"

            Case 31
                Return "V"

            Case 32
                Return "W"

            Case 33
                Return "X"

            Case 34
                Return "Y"

            Case 35
                Return "Z"

        End Select

    End Function



    Private Sub Sm_CreateDirectory(ByVal Vp_strAlmacenDestino As String, ByRef Vp_strFileNameTRAG As String, ByRef Vp_strFileNameTRAD As String)

        Dim Vl_objDirectory As DirectoryInfo

        Dim Vl_strFileDate As String = Format(Date.Today.Day, "00") & Format(Date.Today.Month, "00")



        'Si no Existe el Directorio, se Crea.

        If Directory.Exists(oParent.ApplicationContext.ApplicationConfiguration.RutaTraspasoSalida) = False Then

            Vl_objDirectory = Directory.CreateDirectory(oParent.ApplicationContext.ApplicationConfiguration.RutaTraspasoSalida)

        End If

        'Validar si Existe el Archivo

        If Vp_strAlmacenDestino = "000" Then

            Vp_strFileNameTRAG = New String("TG90" & Vl_strFileDate, 0, 8)

        Else

            Vp_strFileNameTRAG = New String("TG" & Right(Vp_strAlmacenDestino, 2) & Vl_strFileDate, 0, 8)

        End If


        If File.Exists(oParent.ApplicationContext.ApplicationConfiguration.RutaTraspasoSalida & "\" & Vp_strFileNameTRAG & ".DBF") Then

            File.Delete(oParent.ApplicationContext.ApplicationConfiguration.RutaTraspasoSalida & "\" & Vp_strFileNameTRAG & ".DBF")

        End If

        If Vp_strAlmacenDestino = "000" Then

            Vp_strFileNameTRAD = New String("TD90" & Vl_strFileDate, 0, 8)

        Else

            Vp_strFileNameTRAD = New String("TD" & Right(Vp_strAlmacenDestino, 2) & Vl_strFileDate, 0, 8)

        End If


        If File.Exists(oParent.ApplicationContext.ApplicationConfiguration.RutaTraspasoSalida & "\" & Vp_strFileNameTRAD & ".DBF") Then

            File.Delete(oParent.ApplicationContext.ApplicationConfiguration.RutaTraspasoSalida & "\" & Vp_strFileNameTRAD & ".DBF")

        End If

    End Sub



    Private Function Fm_bolCreateFileTRA(ByVal Vp_strFileNameTRAG As String, ByVal Vp_strFileNameTRAD As String) As Boolean

        Dim Vl_cnnTraspaso As New OdbcConnection("MaxBufferSize=2048;DSN=dBASE Files;PageTimeout=5;DefaultDir=" & oParent.ApplicationContext.ApplicationConfiguration.RutaTraspasoSalida & ";" & _
                                                 "DBQ=" & oParent.ApplicationContext.ApplicationConfiguration.RutaTraspasoSalida & ";DriverId=533")

        Dim Vl_cmdTraspaso As OdbcCommand



        Try

            Vl_cnnTraspaso.Open()

            Vl_cmdTraspaso = Vl_cnnTraspaso.CreateCommand

            With Vl_cmdTraspaso

                'TRAG.

                .CommandText = "CREATE TABLE " & Vp_strFileNameTRAG & " " & _
                               "(FOLIOCTRL varchar(7), FOLIO int, FECHA datetime, HORA varchar(8), SUC_ORIG varchar(2), " & _
                               "SUC_DST varchar(2), USUARIO varchar(6), CANTIDAD int, IMPORTE int, FOLIOREC int, " & _
                               "FECHAREC datetime, HORAREC varchar(8), USUARIOREC varchar(5), GUIA varchar(15), " & _
                               "NOTA1 varchar(60), NOTA2 varchar(60), NOTA3 varchar(60), NOTA4 varchar(60))"

                .ExecuteNonQuery()


                'TRAD.

                .CommandText = "CREATE TABLE " & Vp_strFileNameTRAD & " " & _
                               "(FOLIOCTRL varchar(7), FOLIO int, SUC_ORIG varchar(2), CODIGO varchar(50), TALLA double, " & _
                               "CANTIDAD int, COSTUNIT money, IMPORTE money)"

                .ExecuteNonQuery()

            End With

        Catch e As Exception

            MsgBox("No se ha podido Crear el Archivo DBF")

            Return False

        End Try

        Vl_cmdTraspaso.Dispose()
        Vl_cmdTraspaso = Nothing

        Vl_cnnTraspaso.Close()
        Vl_cnnTraspaso.Dispose()
        Vl_cnnTraspaso = Nothing


        Return True

    End Function



    Private Function Sm_bolInsertFileTRA(ByRef Vp_objTraspaso As TraspasoSalida, ByVal Vp_strFileNameTRAG As String, ByVal Vp_strFileNameTRAD As String) As Boolean

        Dim Vl_cnnTraspaso As New OdbcConnection("MaxBufferSize=2048;DSN=dBASE Files;PageTimeout=5;DefaultDir=" & oParent.ApplicationContext.ApplicationConfiguration.RutaTraspasoSalida & ";" & _
                                                 "DBQ=" & oParent.ApplicationContext.ApplicationConfiguration.RutaTraspasoSalida & ";DriverId=533")

        'Dim Vl_cnnTraspaso As New OdbcConnection("MaxBufferSize=2048;DSN=dBASE Files;PageTimeout=5;DefaultDir=C:\TraspasoSource;" & _
        '                                         "DBQ=C:\TraspasoSource;DriverId=533")

        Dim Vl_cmdTraspaso As OdbcCommand

        Try

            Vl_cnnTraspaso.Open()

            Vl_cmdTraspaso = Vl_cnnTraspaso.CreateCommand

            'Calcular Total de Articulos.
            Dim intNumTalla As Integer
            Dim odrArticulo As DataRow

            Dim intTotalArticulos As Integer

            For Each odrArticulo In Vp_objTraspaso.Detalle.Tables("TraspasoCorrida").Rows

                intTotalArticulos += odrArticulo!Cantidad

            Next


            With Vl_cmdTraspaso

                'TRAG.

                .CommandText = "INSERT INTO " & Vp_strFileNameTRAG & " (FOLIOCTRL, FOLIO, FECHA, HORA, SUC_ORIG, SUC_DST, USUARIO, CANTIDAD, IMPORTE, " & _
                               "FOLIOREC, FECHAREC, HORAREC, USUARIOREC, GUIA, NOTA1, NOTA2, NOTA3, NOTA4) values (" & _
                               "''," & Fix(Vp_objTraspaso.TraspasoID) & ", '" & Format(Vp_objTraspaso.TraspasoCreadoEl, "Short Date") & "', '', '" & _
                                Right(Vp_objTraspaso.AlmacenOrigenID, 2) & "', '" & Right(Vp_objTraspaso.AlmacenDestinoID, 2) & "', '" & Left(Vp_objTraspaso.AutorizadoPorID, 5) & _
                                "', " & intTotalArticulos & ", " & Format(Vp_objTraspaso.SubTotal, "#.00") & ",0,'" & Format(Date.Today, "Short Date") & "','','','" & Vp_objTraspaso.Guia & "', '','','','')"

                .ExecuteNonQuery()



                '.CommandText = "INSERT INTO GENERAL (FOLIOCTRL, FOLIO, FECHA, HORA, SUC_ORIG, SUC_DST, USUARIO, CANTIDAD, IMPORTE, " & _
                '               "FOLIOREC, FECHAREC, HORAREC, USUARIOREC, GUIA, NOTA1, NOTA2, NOTA3, NOTA4) values (" & _
                '               "' '," & Fix(Vp_objTraspaso.TraspasoID) & ", '" & Format(Vp_objTraspaso.TraspasoCreadoEl, "Short Date") & "', ' ', '" & _
                '                Right(Vp_objTraspaso.AlmacenOrigenID, 2) & "', '" & Right(Vp_objTraspaso.AlmacenDestinoID, 2) & "', 'hol'" & _
                '                ", " & intTotalArticulos & ", " & Format(Vp_objTraspaso.SubTotal, "#.00") & _
                '                ",0,'" & Format(Date.Today, "Short Date") & "',' ',' ','" & Vp_objTraspaso.Guia & "', ' ',' ',' ',' ')"


                '.ExecuteNonQuery()


                'TRAD.                

                Dim odsCatalogoCorridas As New DataSet
                Dim odrFiltroCorrida() As DataRow

                'Extaer Catálogo Corridas.
                odsCatalogoCorridas = SelectCatalogoCorridas()


                For Each odrArticulo In Vp_objTraspaso.Detalle.Tables("TraspasoCorrida").Rows

                    'Obtener la corrida de cada Artículo.
                    odrFiltroCorrida = odsCatalogoCorridas.Tables("CatalogoCorridas").Select("CodCorrida = '" & CType(odrArticulo("CodCorrida"), String) & "'")  '.GetType.ToString & "'")

                    'Guardar en Existencias cada Artículo con sus respectivas corridas.
                    'Dim intNumTalla As Integer
                    Dim intCantidadPorTalla As Integer

                    For intNumTalla = 1 To 20

                        intCantidadPorTalla = CType(odrArticulo("C" & Format(intNumTalla, "00")), Integer)

                        If (intCantidadPorTalla > 0) Then

                            .CommandText = "INSERT INTO " & Vp_strFileNameTRAD & "(FOLIOCTRL, FOLIO, SUC_ORIG, CODIGO, TALLA, CANTIDAD, COSTUNIT, " & _
                                           "IMPORTE) VALUES (''," & Fix(odrArticulo!TraspasoID) & ", '" & Right(Vp_objTraspaso.AlmacenOrigenID, 2) & _
                                           "', '" & odrArticulo!CodArticulo & "', " & CType(odrFiltroCorrida(0).Item("C" & _
                                           Format(intNumTalla, "00")), Decimal) & ", " & intCantidadPorTalla & _
                                           ", " & Format(odrArticulo!CostoUnit, "#.00") & ", " & Format(odrArticulo!CostoUnit * intCantidadPorTalla, "#.00") & ")"

                            .ExecuteNonQuery()

                        End If

                    Next

                Next


            End With

        Catch e As Exception

            MsgBox("No se ha podido Guardar el Archivo DBF")
            MsgBox(e.Message)

            Return False

        End Try

        Vl_cmdTraspaso.Dispose()
        Vl_cmdTraspaso = Nothing

        Vl_cnnTraspaso.Close()
        Vl_cnnTraspaso.Dispose()
        Vl_cnnTraspaso = Nothing


        Return True

    End Function



    Public Sub Update(ByVal pTraspasoSalida As TraspasoSalida)

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                                 DataStorageConfiguration.GetConnectionString)

        Dim sccmdUpdate As SqlCommand
        sccmdUpdate = New SqlCommand

        Dim sccmdDelete As SqlCommand
        sccmdDelete = New SqlCommand

        With sccmdUpdate

            .Connection = sccnnConnection

            .CommandText = "[TraspasoUpd]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TraspasoID", System.Data.SqlDbType.Int))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Almacen", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Origen", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Status", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Transportista", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Moneda", System.Data.SqlDbType.VarChar, 2))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Paridad", System.Data.SqlDbType.Money))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@SubTotal", System.Data.SqlDbType.Money))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Cargos", System.Data.SqlDbType.Money))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Autoriza", System.Data.SqlDbType.VarChar, 12))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Bultos", System.Data.SqlDbType.Int))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Guia", System.Data.SqlDbType.VarChar, 15))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Observaciones", System.Data.SqlDbType.Text))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Usuario", System.Data.SqlDbType.VarChar, 12))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TraspasoConFaltante", System.Data.SqlDbType.VarChar, 10))

            'OutPut :
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime))
            .Parameters("@Fecha").Direction = ParameterDirection.Output

        End With

        Try

            sccnnConnection.Open()

            With sccmdUpdate
                'Assign Parameters Values
                .Parameters("@TraspasoID").Value = pTraspasoSalida.TraspasoID
                .Parameters("@Almacen").Value = pTraspasoSalida.AlmacenOrigenID
                .Parameters("@Origen").Value = pTraspasoSalida.AlmacenDestinoID
                .Parameters("@Status").Value = pTraspasoSalida.Status
                .Parameters("@Transportista").Value = pTraspasoSalida.TransportistaID
                .Parameters("@Moneda").Value = pTraspasoSalida.MonedaID
                .Parameters("@Paridad").Value = pTraspasoSalida.ParidadMonetaria = 0
                .Parameters("@SubTotal").Value = pTraspasoSalida.SubTotal
                .Parameters("@Cargos").Value = pTraspasoSalida.Cargos
                .Parameters("@Autoriza").Value = pTraspasoSalida.AutorizadoPorID
                .Parameters("@Bultos").Value = pTraspasoSalida.TotalBultos
                .Parameters("@Guia").Value = pTraspasoSalida.Guia
                .Parameters("@Observaciones").Value = pTraspasoSalida.Observaciones
                .Parameters("@Usuario").Value = pTraspasoSalida.AutorizadoPorID
                .Parameters("@TraspasoConFaltante").Value = pTraspasoSalida.TraspasoConFaltante

                'Execute Command
                .ExecuteNonQuery()


                'Actualizar General Traspaso.
                pTraspasoSalida.TraspasoCreadoEl = CType(.Parameters("@Fecha").Value, Date)

            End With


            'Traspaso Corrida :

            'Eliminar los Registros Tabla TraspasoCorrida.

            With sccmdDelete

                .Connection = sccnnConnection

                .CommandText = "[TraspasoCorridaDel]"
                .CommandType = System.Data.CommandType.StoredProcedure

                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TraspasoID", System.Data.SqlDbType.Int))

                'Assign Parameters Values
                .Parameters("@TraspasoID").Value = pTraspasoSalida.TraspasoID

                .ExecuteNonQuery()

            End With



            sccmdUpdate.Dispose()
            sccmdUpdate = Nothing

            sccmdUpdate = New SqlCommand

            With sccmdUpdate

                .Connection = sccnnConnection

                .CommandText = "[TraspasoCorridaIns]"
                .CommandType = System.Data.CommandType.StoredProcedure

                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TraspasoID", System.Data.SqlDbType.Int))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Folio", System.Data.SqlDbType.VarChar, 6))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Almacen", System.Data.SqlDbType.VarChar, 3))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Codigo", System.Data.SqlDbType.VarChar, 20))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Descripcion", System.Data.SqlDbType.VarChar, 40))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Corrida", System.Data.SqlDbType.VarChar, 3))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CostoUnit", System.Data.SqlDbType.Money))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Cantidad", System.Data.SqlDbType.Decimal))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Importe", System.Data.SqlDbType.Money))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Unidad", System.Data.SqlDbType.VarChar, 3))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Factor", System.Data.SqlDbType.Real))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@C01", System.Data.SqlDbType.Real))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@C02", System.Data.SqlDbType.Real))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@C03", System.Data.SqlDbType.Real))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@C04", System.Data.SqlDbType.Real))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@C05", System.Data.SqlDbType.Real))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@C06", System.Data.SqlDbType.Real))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@C07", System.Data.SqlDbType.Real))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@C08", System.Data.SqlDbType.Real))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@C09", System.Data.SqlDbType.Real))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@C10", System.Data.SqlDbType.Real))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@C11", System.Data.SqlDbType.Real))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@C12", System.Data.SqlDbType.Real))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@C13", System.Data.SqlDbType.Real))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@C14", System.Data.SqlDbType.Real))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@C15", System.Data.SqlDbType.Real))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@C16", System.Data.SqlDbType.Real))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@C17", System.Data.SqlDbType.Real))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@C18", System.Data.SqlDbType.Real))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@C19", System.Data.SqlDbType.Real))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@C20", System.Data.SqlDbType.Real))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Multiplica", System.Data.SqlDbType.Real))

            End With


            Dim odrArticulo As DataRow
            Dim intNumTalla As Integer

            For Each odrArticulo In pTraspasoSalida.Detalle.Tables(0).Rows

                With sccmdUpdate

                    'Assign Parameters Values
                    .Parameters("@TraspasoID").Value = pTraspasoSalida.TraspasoID
                    .Parameters("@Folio").Value = pTraspasoSalida.TraspasoID
                    .Parameters("@Almacen").Value = odrArticulo("CodAlmacen")
                    .Parameters("@Codigo").Value = odrArticulo("CodArticulo")
                    .Parameters("@Descripcion").Value = odrArticulo("Descripcion")
                    .Parameters("@Corrida").Value = odrArticulo("CodCorrida")
                    .Parameters("@CostoUnit").Value = odrArticulo("CostoUnit")
                    .Parameters("@Cantidad").Value = odrArticulo("Cantidad")

                    .Parameters("@Importe").Value = odrArticulo("CostoTotal")

                    .Parameters("@Unidad").Value = odrArticulo("CodUnidad")
                    .Parameters("@Factor").Value = 1.0
                    .Parameters("@C01").Value = odrArticulo("C01")
                    .Parameters("@C02").Value = odrArticulo("C02")
                    .Parameters("@C03").Value = odrArticulo("C03")
                    .Parameters("@C04").Value = odrArticulo("C04")
                    .Parameters("@C05").Value = odrArticulo("C05")
                    .Parameters("@C06").Value = odrArticulo("C06")
                    .Parameters("@C07").Value = odrArticulo("C07")
                    .Parameters("@C08").Value = odrArticulo("C08")
                    .Parameters("@C09").Value = odrArticulo("C09")
                    .Parameters("@C10").Value = odrArticulo("C10")
                    .Parameters("@C11").Value = odrArticulo("C11")
                    .Parameters("@C12").Value = odrArticulo("C12")
                    .Parameters("@C13").Value = odrArticulo("C13")
                    .Parameters("@C14").Value = odrArticulo("C14")
                    .Parameters("@C15").Value = odrArticulo("C15")
                    .Parameters("@C16").Value = odrArticulo("C16")
                    .Parameters("@C17").Value = odrArticulo("C17")
                    .Parameters("@C18").Value = odrArticulo("C18")
                    .Parameters("@C19").Value = odrArticulo("C19")
                    .Parameters("@C20").Value = odrArticulo("C20")

                    .Parameters("@Multiplica").Value = 1.0


                    'Execute Command
                    .ExecuteNonQuery()

                End With

            Next


            'Reset New State of Linea Object 
            'Linea.ResetStateNew()
            pTraspasoSalida.ResetFlagIsDirty()

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



    Public Sub InsertDBF(ByVal pTraspasoSalida As TraspasoSalida)

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                                 DataStorageConfiguration.GetConnectionString)

        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand

        With sccmdInsert

            .Connection = sccnnConnection

            .CommandText = "[TraspasoInsDBF]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Almacen", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Origen", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Status", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Transportista", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Moneda", System.Data.SqlDbType.VarChar, 2))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Paridad", System.Data.SqlDbType.Money))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@SubTotal", System.Data.SqlDbType.Money))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Cargos", System.Data.SqlDbType.Money))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Autoriza", System.Data.SqlDbType.VarChar, 12))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Bultos", System.Data.SqlDbType.Int))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Guia", System.Data.SqlDbType.VarChar, 15))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Observaciones", System.Data.SqlDbType.Text))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Usuario", System.Data.SqlDbType.VarChar, 12))


            'OutPut :
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TraspasoID", System.Data.SqlDbType.Int))
            .Parameters("@TraspasoID").Direction = ParameterDirection.Output

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime))
            '.Parameters("@Fecha").Direction = ParameterDirection.Output

        End With

        Try
            sccnnConnection.Open()

            With sccmdInsert
                'Assign Parameters Values

                .Parameters("@Almacen").Value = pTraspasoSalida.AlmacenOrigenID  'pTraspasoSalida.AlmacenDestinoID
                .Parameters("@Origen").Value = pTraspasoSalida.AlmacenDestinoID  'pTraspasoSalida.AlmacenOrigenID

                .Parameters("@Status").Value = pTraspasoSalida.Status
                .Parameters("@Transportista").Value = pTraspasoSalida.TransportistaID
                .Parameters("@Moneda").Value = pTraspasoSalida.MonedaID
                .Parameters("@Paridad").Value = 1  'Preguntar ???
                .Parameters("@SubTotal").Value = pTraspasoSalida.SubTotal
                '.Parameters("@Cargos").Value = pTraspasoSalida.Cargos
                .Parameters("@Autoriza").Value = pTraspasoSalida.AutorizadoPorID
                .Parameters("@Bultos").Value = pTraspasoSalida.TotalBultos
                .Parameters("@Guia").Value = pTraspasoSalida.Guia
                .Parameters("@Observaciones").Value = pTraspasoSalida.Observaciones
                .Parameters("@Usuario").Value = pTraspasoSalida.AutorizadoPorID
                .Parameters("@Fecha").Value = Format(pTraspasoSalida.TraspasoCreadoEl, "Short Date")


                'Execute Command
                .ExecuteNonQuery()

                'Actualizar General Traspaso.
                'pTraspasoSalida.TraspasoCreadoEl = CType(.Parameters("@Fecha").Value, Date)
                pTraspasoSalida.Folio = CType(.Parameters("@TraspasoID").Value, Integer)
                pTraspasoSalida.TraspasoID = CType(.Parameters("@TraspasoID").Value, Integer)


            End With


            'Traspaso Corrida :

            sccmdInsert.Dispose()
            sccmdInsert = Nothing

            sccmdInsert = New SqlCommand

            With sccmdInsert

                .Connection = sccnnConnection

                .CommandText = "[TraspasoCorridaIns]"
                .CommandType = System.Data.CommandType.StoredProcedure

                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TraspasoID", System.Data.SqlDbType.Int))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Folio", System.Data.SqlDbType.VarChar, 6))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Almacen", System.Data.SqlDbType.VarChar, 3))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Codigo", System.Data.SqlDbType.VarChar, 20))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Descripcion", System.Data.SqlDbType.VarChar, 40))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Corrida", System.Data.SqlDbType.VarChar, 3))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CostoUnit", System.Data.SqlDbType.Money))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Cantidad", System.Data.SqlDbType.Decimal))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Importe", System.Data.SqlDbType.Money))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Unidad", System.Data.SqlDbType.VarChar, 3))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Factor", System.Data.SqlDbType.Real))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@C01", System.Data.SqlDbType.Real))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@C02", System.Data.SqlDbType.Real))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@C03", System.Data.SqlDbType.Real))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@C04", System.Data.SqlDbType.Real))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@C05", System.Data.SqlDbType.Real))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@C06", System.Data.SqlDbType.Real))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@C07", System.Data.SqlDbType.Real))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@C08", System.Data.SqlDbType.Real))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@C09", System.Data.SqlDbType.Real))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@C10", System.Data.SqlDbType.Real))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@C11", System.Data.SqlDbType.Real))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@C12", System.Data.SqlDbType.Real))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@C13", System.Data.SqlDbType.Real))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@C14", System.Data.SqlDbType.Real))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@C15", System.Data.SqlDbType.Real))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@C16", System.Data.SqlDbType.Real))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@C17", System.Data.SqlDbType.Real))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@C18", System.Data.SqlDbType.Real))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@C19", System.Data.SqlDbType.Real))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@C20", System.Data.SqlDbType.Real))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Multiplica", System.Data.SqlDbType.Real))

            End With


            Dim odrArticulo As DataRow
            Dim intNumTalla As Integer

            'For Each odrArticulo In pTraspasoSalida.Detalle.Tables("TraspasoDetalleTmp" & oParent.ApplicationContext.ApplicationConfiguration.NoCaja & ", CatalogoArticulos, CatalogoCorridas").Rows
            For Each odrArticulo In pTraspasoSalida.Detalle.Tables(0).Rows

                With sccmdInsert

                    'Assign Parameters Values

                    .Parameters("@TraspasoID").Value = pTraspasoSalida.TraspasoID
                    .Parameters("@Folio").Value = pTraspasoSalida.TraspasoID
                    .Parameters("@Almacen").Value = pTraspasoSalida.AlmacenOrigenID
                    .Parameters("@Codigo").Value = odrArticulo("CodArticulo")
                    .Parameters("@Descripcion").Value = odrArticulo("Descripcion")
                    .Parameters("@Corrida").Value = odrArticulo("CodCorrida")
                    .Parameters("@CostoUnit").Value = odrArticulo("CostoUnit")
                    .Parameters("@Cantidad").Value = odrArticulo("Cantidad")
                    .Parameters("@Importe").Value = odrArticulo("CostoTotal")
                    .Parameters("@Unidad").Value = odrArticulo("CodUnidad")
                    .Parameters("@Factor").Value = 1
                    .Parameters("@C01").Value = odrArticulo("C01")
                    .Parameters("@C02").Value = odrArticulo("C02")
                    .Parameters("@C03").Value = odrArticulo("C03")
                    .Parameters("@C04").Value = odrArticulo("C04")
                    .Parameters("@C05").Value = odrArticulo("C05")
                    .Parameters("@C06").Value = odrArticulo("C06")
                    .Parameters("@C07").Value = odrArticulo("C07")
                    .Parameters("@C08").Value = odrArticulo("C08")
                    .Parameters("@C09").Value = odrArticulo("C09")
                    .Parameters("@C10").Value = odrArticulo("C10")
                    .Parameters("@C11").Value = odrArticulo("C11")
                    .Parameters("@C12").Value = odrArticulo("C12")
                    .Parameters("@C13").Value = odrArticulo("C13")
                    .Parameters("@C14").Value = odrArticulo("C14")
                    .Parameters("@C15").Value = odrArticulo("C15")
                    .Parameters("@C16").Value = odrArticulo("C16")
                    .Parameters("@C17").Value = odrArticulo("C17")
                    .Parameters("@C18").Value = odrArticulo("C18")
                    .Parameters("@C19").Value = odrArticulo("C19")
                    .Parameters("@C20").Value = odrArticulo("C20")
                    .Parameters("@Multiplica").Value = 1


                    'Execute Command
                    .ExecuteNonQuery()

                End With

            Next


            'Reset New State of Linea Object 
            pTraspasoSalida.ResetFlagIsNew()
            pTraspasoSalida.ResetFlagIsDirty()

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



    Public Sub Delete(ByVal ID As Integer)

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                                 DataStorageConfiguration.GetConnectionString)

        Dim sccmdDelete As SqlCommand
        sccmdDelete = New SqlCommand

        With sccmdDelete

            .Connection = sccnnConnection

            .CommandText = "[TraspasoDel]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TraspasoID", System.Data.SqlDbType.Int))

        End With

        Try

            sccnnConnection.Open()

            With sccmdDelete
                'Assign Parameters Values
                .Parameters("@TraspasoID").Value = ID

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

            'Throw New ApplicationException("El registro no pudo ser insertado debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            'Throw New ApplicationException("El registro no pudo ser insertado debido a un error de aplicación.", ex)

        End Try


        sccmdDelete.Dispose()
        sccmdDelete = Nothing

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

    End Sub

    Public Sub ActualizarLecturado(ByVal Codigo As String, ByVal strTalla As String, ByVal intLecturado As Integer, ByVal intCant As Integer)


        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                                 DataStorageConfiguration.GetConnectionString)

        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand

        With sccmdInsert

            .Connection = sccnnConnection

            .CommandText = "[TraspasoDetalleActualizaLecturado]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .CommandType = CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@NombreTabla", System.Data.SqlDbType.VarChar, 30))

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodArticulo", System.Data.SqlDbType.VarChar, 20))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Talla", System.Data.SqlDbType.VarChar, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Lecturado", System.Data.SqlDbType.Int))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Cantidad", System.Data.SqlDbType.Int))

        End With

        Try

            sccnnConnection.Open()

            With sccmdInsert

                'Assign Parameters Values
                .Parameters("@NombreTabla").Value = "TraspasoDetalleTmp" & oParent.ApplicationContext.ApplicationConfiguration.Almacen & oParent.ApplicationContext.ApplicationConfiguration.NoCaja & oParent.ApplicationContext.Security.CurrentUser.ID


                .Parameters("@CodArticulo").Value = UCase$(Codigo)
                .Parameters("@Talla").Value = strTalla
                .Parameters("@Lecturado").Value = intLecturado
                .Parameters("@Cantidad").Value = intCant
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
            Throw New ApplicationException(oSqlException.Message, oSqlException)
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

    Public Sub ActualizarLecturado2(ByVal dsTraspasoDetalle As DataSet)


        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                            DataStorageConfiguration.GetConnectionString)


        Dim odrArticulo As DataRow
        Dim odsCatalogoCorridas As New DataSet
        Dim odrFiltroCorrida() As DataRow

        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand

        With sccmdInsert

            .Connection = sccnnConnection

            .CommandText = "[TraspasoDetalleActualizaLecturado]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .CommandType = CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@NombreTabla", System.Data.SqlDbType.VarChar, 30))

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodArticulo", System.Data.SqlDbType.VarChar, 20))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Talla", System.Data.SqlDbType.VarChar, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Lecturado", System.Data.SqlDbType.Int))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Cantidad", System.Data.SqlDbType.Int))

        End With

        Try

            sccnnConnection.Open()

            ''''''''''''''''''''''''


            'Extaer Catálogo Corridas.
            odsCatalogoCorridas = SelectCatalogoCorridas()

            For Each odrArticulo In dsTraspasoDetalle.Tables(0).Rows

                'odrFiltroCorrida = odsCatalogoCorridas.Tables("CatalogoCorridas").Select("CodCorrida = '" & CType(odrArticulo("CodCorrida"), String) & "'")

                ''Guardar en Tabla Temporal [TraspasoDetalleTmp] cada Artículo con sus respectivas Tallas.
                'Dim intNumTalla As Integer
                'Dim intCantidadPorTalla As Integer

                'For intNumTalla = 1 To 20
                '    Dim strCampo As String = "C" & Format(intNumTalla, "00")
                '    intCantidadPorTalla = CType(odrArticulo(strCampo), Integer)

                '    If (intCantidadPorTalla > 0) Then
                With sccmdInsert

                    'Assign Parameters Values
                    .Parameters("@NombreTabla").Value = "TraspasoDetalleTmp" & oParent.ApplicationContext.ApplicationConfiguration.Almacen & oParent.ApplicationContext.ApplicationConfiguration.NoCaja & oParent.ApplicationContext.Security.CurrentUser.ID

                    .Parameters("@CodArticulo").Value = odrArticulo("CodArticulo")
                    .Parameters("@Talla").Value = ""  'CType(odrFiltroCorrida(0).Item("C" & Format(intNumTalla, "00")), String)
                    .Parameters("@Lecturado").Value = odrArticulo("Lecturado")
                    .Parameters("@Cantidad").Value = 0
                    'Execute Command
                    .ExecuteNonQuery()

                End With

                'End If

                'Next

            Next


            ''''''''''''''''''''''''

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
            Throw New ApplicationException("El registro no pudo ser insertado debido a un error de aplicación.", ex)
        End Try
        sccnnConnection.Dispose()
        sccnnConnection = Nothing
    End Sub

    Public Sub InsertArticulo(ByVal oArticulo As Articulo, ByVal strTalla As String, ByVal decCantidad As Integer, _
                              ByVal decCostoTotal As Decimal, ByVal intTraspasoID As Integer, Optional ByVal Serie As String = "")
        InsertArticulo(oArticulo.CodArticulo, oArticulo.Descripcion, oArticulo.CodCorrida, strTalla, decCantidad, decCostoTotal, intTraspasoID, Serie)
    End Sub

    Public Sub InsertArticulo(ByVal Codigo As String, ByVal Descripcion As String, ByVal Corrida As String, ByVal strTalla As String, ByVal decCantidad As Integer, _
                              ByVal decCostoTotal As Decimal, ByVal intTraspasoID As Integer, Optional ByVal Serie As String = "")
        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                                 DataStorageConfiguration.GetConnectionString)

        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand

        With sccmdInsert

            .Connection = sccnnConnection

            .CommandText = "[TraspasoDetalleArticuloIns]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .CommandType = CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@NombreTabla", System.Data.SqlDbType.VarChar, 30))

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TraspasoID", System.Data.SqlDbType.Int))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Folio", System.Data.SqlDbType.VarChar, 6))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodArticulo", System.Data.SqlDbType.VarChar, 20))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Serie", System.Data.SqlDbType.VarChar, 18))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Descripcion", System.Data.SqlDbType.VarChar, 50))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCorrida", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Talla", System.Data.SqlDbType.VarChar, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Cantidad", System.Data.SqlDbType.Decimal))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CostoTotal", System.Data.SqlDbType.Decimal))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Lecturado", System.Data.SqlDbType.Int))

        End With

        Try

            sccnnConnection.Open()

            With sccmdInsert

                'Assign Parameters Values
                .Parameters("@NombreTabla").Value = "TraspasoDetalleTmp" & oParent.ApplicationContext.ApplicationConfiguration.Almacen & oParent.ApplicationContext.ApplicationConfiguration.NoCaja & oParent.ApplicationContext.Security.CurrentUser.ID

                .Parameters("@TraspasoID").Value = intTraspasoID
                .Parameters("@Folio").Value = intTraspasoID
                .Parameters("@CodAlmacen").Value = oParent.ApplicationContext.ApplicationConfiguration.Almacen

                .Parameters("@CodArticulo").Value = UCase$(Codigo)
                .Parameters("@Serie").Value = UCase$(Serie)
                .Parameters("@Descripcion").Value = UCase$(Descripcion)
                .Parameters("@CodCorrida").Value = UCase$(Corrida)

                .Parameters("@Talla").Value = strTalla
                .Parameters("@Cantidad").Value = decCantidad
                .Parameters("@CostoTotal").Value = decCostoTotal
                .Parameters("@Lecturado").Value = 0
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
            Throw New ApplicationException(oSqlException.Message, oSqlException)
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

    Public Sub DeleteArticuloNoLecturado()

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                                 DataStorageConfiguration.GetConnectionString)

        Dim sccmdDelete As SqlCommand
        sccmdDelete = New SqlCommand

        With sccmdDelete

            .Connection = sccnnConnection
            .CommandText = "[TraspasoTMPDelNoLecturado]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@NombreTabla", System.Data.SqlDbType.VarChar, 40))

        End With

        Try

            sccnnConnection.Open()

            With sccmdDelete
                'Assign Parameters Values
                .Parameters("@NombreTabla").Value = "TraspasoDetalleTmp" & oParent.ApplicationContext.ApplicationConfiguration.Almacen & oParent.ApplicationContext.ApplicationConfiguration.NoCaja & oParent.ApplicationContext.Security.CurrentUser.ID

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

            'Throw New ApplicationException("El registro no pudo ser insertado debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            'Throw New ApplicationException("El registro no pudo ser insertado debido a un error de aplicación.", ex)

        End Try


        sccmdDelete.Dispose()
        sccmdDelete = Nothing

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

    End Sub
    Public Sub DeleteArticulo(ByVal strCodArticulo As String, ByVal strTalla As String)

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                                 DataStorageConfiguration.GetConnectionString)

        Dim sccmdDelete As SqlCommand
        sccmdDelete = New SqlCommand

        With sccmdDelete

            .Connection = sccnnConnection
            .CommandText = "[TraspasoDetalleArticuloDel]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@NombreTabla", System.Data.SqlDbType.VarChar, 40))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodArticulo", System.Data.SqlDbType.VarChar, 20))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Talla", System.Data.SqlDbType.VarChar, 4))

        End With

        Try

            sccnnConnection.Open()

            With sccmdDelete
                'Assign Parameters Values
                .Parameters("@NombreTabla").Value = "TraspasoDetalleTmp" & oParent.ApplicationContext.ApplicationConfiguration.Almacen & oParent.ApplicationContext.ApplicationConfiguration.NoCaja & oParent.ApplicationContext.Security.CurrentUser.ID
                .Parameters("@CodArticulo").Value = strCodArticulo
                .Parameters("@Talla").Value = strTalla

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

            'Throw New ApplicationException("El registro no pudo ser insertado debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            'Throw New ApplicationException("El registro no pudo ser insertado debido a un error de aplicación.", ex)

        End Try


        sccmdDelete.Dispose()
        sccmdDelete = Nothing

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

    End Sub



    Public Sub CreatTable()

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)
        Dim sccmdCreatTable As SqlCommand



        sccmdCreatTable = New SqlCommand

        With sccmdCreatTable

            .Connection = sccnnConnection

            .CommandText = "[TraspasoDetalleCrearTMP]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@NombreTabla", System.Data.SqlDbType.VarChar, 30))

        End With


        Try
            sccnnConnection.Open()

            With sccmdCreatTable
                'Assign Parameters Values
                .Parameters("@NombreTabla").Value = "TraspasoDetalleTmp" & oParent.ApplicationContext.ApplicationConfiguration.Almacen & oParent.ApplicationContext.ApplicationConfiguration.NoCaja & oParent.ApplicationContext.Security.CurrentUser.ID

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

            Throw New ApplicationException("La Tabla Temporal no pudo ser Creada debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("La Tabla Temporal no pudo ser Creada debido a un error de base de datos.", ex)

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

    End Sub

    Public Sub CancelaTraspasoEC(ByVal FolioSAP As String, ByVal FCFolioSAP As String, ByVal User As String)

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)
        Dim sccmdDeleteTable As SqlCommand

        sccmdDeleteTable = New SqlCommand

        With sccmdDeleteTable

            .Connection = sccnnConnection

            .CommandText = "[TraspasoSalidaCancel]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioSAP", System.Data.SqlDbType.VarChar, 10))
            .Parameters.Add(New SqlParameter("@FCFolioSAP", SqlDbType.VarChar, 10))
            .Parameters.Add(New SqlParameter("@Usuario", SqlDbType.VarChar, 12))

        End With


        Try
            sccnnConnection.Open()

            With sccmdDeleteTable
                'Assign Parameters Values
                .Parameters("@FolioSAP").Value = FolioSAP.Trim
                .Parameters("@FCFolioSAP").Value = FCFolioSAP.Trim
                .Parameters("@Usuario").Value = User.Trim

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

            Throw New ApplicationException("La Tabla Temporal no pudo ser Eliminada debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("La Tabla Temporal no pudo ser Eliminada debido a un error de base de datos.", ex)

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

    End Sub

    Public Sub DeleteTable()

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)
        Dim sccmdDeleteTable As SqlCommand



        sccmdDeleteTable = New SqlCommand

        With sccmdDeleteTable

            .Connection = sccnnConnection

            .CommandText = "[TraspasoDetalleEliminarTMP]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@NombreTabla", System.Data.SqlDbType.VarChar, 30))

        End With


        Try
            sccnnConnection.Open()

            With sccmdDeleteTable
                'Assign Parameters Values
                .Parameters("@NombreTabla").Value = "TraspasoDetalleTmp" & oParent.ApplicationContext.ApplicationConfiguration.NoCaja

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

            Throw New ApplicationException("La Tabla Temporal no pudo ser Eliminada debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("La Tabla Temporal no pudo ser Eliminada debido a un error de base de datos.", ex)

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

    End Sub



    Public Function FillDataSet(ByVal strStoredProcedure As String, ByVal strTabla As String) As DataSet

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                GetConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaTraspasoSalida As SqlDataAdapter
        Dim dsTraspasoSalida As DataSet

        sccmdSelectAll = New SqlCommand
        scdaTraspasoSalida = New SqlDataAdapter
        dsTraspasoSalida = New DataSet(strTabla)

        With sccmdSelectAll

            .Connection = sccnnConnection

            .CommandText = strStoredProcedure    '"[TraspasoSelAll]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@NombreTabla", System.Data.SqlDbType.VarChar, 40))

        End With

        scdaTraspasoSalida.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            scdaTraspasoSalida.SelectCommand.Parameters("@NombreTabla").Value = strTabla

            'Fill DataSet
            scdaTraspasoSalida.Fill(dsTraspasoSalida, strTabla)

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

        Return dsTraspasoSalida

    End Function



    Public Function FillDataSetTraspasoCorrida(ByVal strStoredProcedure As String, ByVal strTabla As String, ByVal strTablas As String) As DataSet

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                GetConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaTraspasoSalida As SqlDataAdapter
        Dim dsTraspasoSalida As DataSet



        sccmdSelectAll = New SqlCommand
        scdaTraspasoSalida = New SqlDataAdapter
        dsTraspasoSalida = New DataSet(strTabla)

        With sccmdSelectAll

            .Connection = sccnnConnection

            .CommandText = strStoredProcedure    '"[TraspasoSelAll]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@NombreTabla", System.Data.SqlDbType.VarChar, 40))

        End With

        scdaTraspasoSalida.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            scdaTraspasoSalida.SelectCommand.Parameters("@NombreTabla").Value = strTabla

            'Fill DataSet
            scdaTraspasoSalida.Fill(dsTraspasoSalida, strTablas)

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

            Throw New ApplicationException("Los registros no pudieron ser leidos debido a un error de aplicación.", ex)

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return dsTraspasoSalida

    End Function



    Public Sub FillDataSetTraspasoDetalleCaptura(ByVal dsTraspasoDetalle As DataSet)

        Dim odrArticulo As DataRow

        Dim odsCatalogoCorridas As New DataSet
        Dim odrFiltroCorrida() As DataRow

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                                 DataStorageConfiguration.GetConnectionString)

        Dim sccmdTraspasoSalida As SqlCommand
        sccmdTraspasoSalida = New SqlCommand


        With sccmdTraspasoSalida

            .Connection = sccnnConnection

            .CommandText = "[TraspasoDetalleArticuloIns]"  '???
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@NombreTabla", System.Data.SqlDbType.VarChar, 30))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TraspasoID", System.Data.SqlDbType.Int))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Folio", System.Data.SqlDbType.VarChar, 6))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodArticulo", System.Data.SqlDbType.VarChar, 20))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Descripcion", System.Data.SqlDbType.VarChar, 50))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCorrida", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CostoTotal", System.Data.SqlDbType.Decimal))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Cantidad", System.Data.SqlDbType.Decimal))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Talla", System.Data.SqlDbType.VarChar, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Lecturado", System.Data.SqlDbType.Int))

        End With

        Try
            sccnnConnection.Open()

            'Extaer Catálogo Corridas.
            odsCatalogoCorridas = SelectCatalogoCorridas()

            For Each odrArticulo In dsTraspasoDetalle.Tables(0).Rows

                odrFiltroCorrida = odsCatalogoCorridas.Tables("CatalogoCorridas").Select("CodCorrida = '" & CType(odrArticulo("CodCorrida"), String) & "'")

                'Guardar en Tabla Temporal [TraspasoDetalleTmp] cada Artículo con sus respectivas Tallas.
                'Dim intNumTalla As Integer
                'Dim intCantidadPorTalla As Integer

                'For intNumTalla = 1 To 20
                'Dim strCampo As String = "C" & Format(intNumTalla, "00")
                'intCantidadPorTalla = CType(odrArticulo(strCampo), Integer)

                'If (intCantidadPorTalla > 0) Then

                With sccmdTraspasoSalida

                    'Assign Parameters Values 
                    .Parameters("@NombreTabla").Value = "TraspasoDetalleTmp" & oParent.ApplicationContext.ApplicationConfiguration.Almacen & oParent.ApplicationContext.ApplicationConfiguration.NoCaja & oParent.ApplicationContext.Security.CurrentUser.ID
                    .Parameters("@TraspasoID").Value = odrArticulo("TraspasoID")
                    .Parameters("@Folio").Value = odrArticulo("TraspasoID")

                    .Parameters("@CodArticulo").Value = odrArticulo("CodArticulo")
                    .Parameters("@CodCorrida").Value = odrArticulo("CodCorrida")
                    .Parameters("@CodAlmacen").Value = odrArticulo("CodAlmacen")

                    .Parameters("@Descripcion").Value = odrArticulo("Descripcion")
                    'Ramiro Alcaraz Flores
                    '.Parameters("@CostoTotal").Value = odrArticulo("CostoTotal")
                    .Parameters("@CostoTotal").Value = odrArticulo("CostoUnit") * odrArticulo("Cantidad") 'intCantidadPorTalla
                    '.Parameters("@Cantidad").Value = odrArticulo("Cantidad")
                    .Parameters("@Cantidad").Value = odrArticulo("Cantidad")
                    .Parameters("@Talla").Value = ""
                    '.Parameters("@Cantidad").Value = 0
                    .Parameters("@Lecturado").Value = odrArticulo("Lecturado")
                    'Execute Command
                    .ExecuteNonQuery()

                End With
                'End If

                'Next

            Next

            sccnnConnection.Close()


        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException(oSqlException.Message, oSqlException)
            Exit Sub

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException(ex.Message, ex)
            Exit Sub

        End Try


        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        sccmdTraspasoSalida.Dispose()
        sccmdTraspasoSalida = Nothing

    End Sub


    'Ramiro Alcaraz Flores
    Public Function LlenaTablaConDetalleTraspaso() As DataTable


        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                GetConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaTraspasoSalida As SqlDataAdapter
        Dim dsTraspasoSalida As DataSet



        sccmdSelectAll = New SqlCommand
        scdaTraspasoSalida = New SqlDataAdapter
        dsTraspasoSalida = New DataSet("TMP")

        With sccmdSelectAll

            .Connection = sccnnConnection

            .CommandText = "[TraspasoTMPSelAllSAP]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@NombreTabla", System.Data.SqlDbType.VarChar, 40))

        End With

        scdaTraspasoSalida.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            scdaTraspasoSalida.SelectCommand.Parameters("@NombreTabla").Value = "TraspasoDetalleTmp" & oParent.ApplicationContext.ApplicationConfiguration.Almacen & oParent.ApplicationContext.ApplicationConfiguration.NoCaja & oParent.ApplicationContext.Security.CurrentUser.ID

            'Fill DataSet
            scdaTraspasoSalida.Fill(dsTraspasoSalida, "X")

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

            Throw New ApplicationException("Los registros no pudieron ser leidos debido a un error de aplicación.", ex)

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing
        'dsTraspasoSalida.Tables("X").Columns.Add("DefectoNota")
        Return dsTraspasoSalida.Tables("X")

    End Function


    Public Function ValidarCantidadArticulo(ByVal intCantidadArticulo As Integer, ByVal strCodArticulo As String, _
                                             ByVal strTalla As String, ByVal Destino As String) As Boolean

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        Dim dsDataSet As DataSet
        dsDataSet = New DataSet("TraspasoCorrida")

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[TraspasoDetalleValidarCantidad]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacenDestino", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodArticulo", System.Data.SqlDbType.VarChar, 20))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Numero", System.Data.SqlDbType.VarChar, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Libre", System.Data.SqlDbType.Decimal))

            .Parameters("@Libre").Direction = ParameterDirection.Output

        End With


        Try

            sccnnConnection.Open()

            With sccmdSelect
                'Assign Parameters Values
                .Parameters("@CodAlmacen").Value = oParent.ApplicationContext.ApplicationConfiguration.Almacen
                .Parameters("@CodAlmacenDestino").Value = Destino
                .Parameters("@CodArticulo").Value = strCodArticulo
                .Parameters("@Numero").Value = strTalla

                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) And (IsDBNull(scdrReader.Item(0)) <> True) Then

                    With scdrReader

                        If (.GetDecimal(0) < intCantidadArticulo) Then
                            .Close()
                            sccnnConnection.Close()
                            Return False
                        End If

                    End With

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

        Return True

    End Function



    Public Function ValidarTallaArticulo(ByVal decTallaArticulo As Decimal, ByVal strCodCorrida As String) As Boolean

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        Dim dsDataSet As DataSet
        dsDataSet = New DataSet("TraspasoCorrida")




        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[TraspasoDetalleValidarTalla]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCorrida", System.Data.SqlDbType.VarChar, 3))

        End With


        Try

            sccnnConnection.Open()

            With sccmdSelect
                'Assign Parameters Values
                .Parameters("@CodCorrida").Value = strCodCorrida


                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    With scdrReader

                        Dim decInicio As Decimal
                        Dim decFin As Decimal
                        Dim decSalto As Decimal
                        Dim intTalla As Integer
                        Dim bolFlag As Boolean


                        Dim decNum As Decimal


                        decSalto = .GetDecimal(0)
                        decInicio = .GetDecimal(21)
                        decFin = .GetDecimal(22)


                        '<Validaciónn>
                        'En caso de ser Accesorio.

                        If (decInicio = 0) And (decFin = 0) And (decTallaArticulo > 0) Then
                            scdrReader.Close()
                            sccnnConnection.Close()
                            Return False
                        ElseIf (decInicio = 0) And (decFin = 0) And (decTallaArticulo = 0) Then
                            scdrReader.Close()
                            GoTo SaltoLinea
                        End If
                        '<Validaciónn>


                        'Se recorre el Numero de Tallas que tiene un Articulo.

                        For decNum = decInicio To decFin Step decSalto

                            intTalla += 1

                            'Se compara con la Corrida del Articulo si se encuentra la Talla.
                            If (.GetDecimal(intTalla) = decTallaArticulo) Then
                                scdrReader.Close()
                                GoTo SaltoLinea
                            Else
                                bolFlag = False
                            End If

                        Next

                        If (bolFlag = False) Then
                            scdrReader.Close()
                            sccnnConnection.Close()

                            Return False
                        End If

                    End With

                Else

                    scdrReader.Close()
                    sccnnConnection.Close()

                    Return False

                End If

            End With


SaltoLinea:

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

        Return True

    End Function



    Public Function GenerarArticuloCorrida(ByVal strCodArticulo As String, ByVal strAlmacenDestino As String) As DataSet

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdCorrida As SqlCommand
        Dim scdaCorrida As SqlDataAdapter
        Dim dsCorrida As DataSet



        sccmdCorrida = New SqlCommand
        scdaCorrida = New SqlDataAdapter
        dsCorrida = New DataSet("Existencias")

        With sccmdCorrida

            .Connection = sccnnConnection

            .CommandText = "[TraspasoSalidaGenerarArticuloCorrida]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodArticulo", System.Data.SqlDbType.VarChar, 20))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacenDestino", System.Data.SqlDbType.VarChar, 3))

        End With

        scdaCorrida.SelectCommand = sccmdCorrida

        Try

            sccnnConnection.Open()

            scdaCorrida.SelectCommand.Parameters("@CodAlmacen").Value = oParent.ApplicationContext.ApplicationConfiguration.Almacen
            scdaCorrida.SelectCommand.Parameters("@CodArticulo").Value = strCodArticulo
            scdaCorrida.SelectCommand.Parameters("@CodAlmacenDestino").Value = strAlmacenDestino

            'Fill DataSet
            scdaCorrida.Fill(dsCorrida, "Existencias")

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

        Return dsCorrida

    End Function

    Public Function SelectCodUPC(ByVal srtArticulo As String, ByVal strTalla As String) As String

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        sccmdSelect = New SqlCommand
        Dim strDescrip As String

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[CodUPCSel]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodArticulo", System.Data.SqlDbType.VarChar, 20))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Talla", System.Data.SqlDbType.VarChar, 5))

        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect
                'Assign Parameters Values
                .Parameters("@CodArticulo").Value = srtArticulo
                .Parameters("@Talla").Value = strTalla

                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    'Traspaso General :
                    With scdrReader

                        strDescrip = .GetString(0)

                        .Close()

                    End With
                Else
                    strDescrip = String.Empty
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

        Return strDescrip

    End Function

    Public Sub InsertMotivo(ByVal strFacturaID As Integer, ByVal strTienda As String, ByVal strArticulo As String, _
           ByVal strTalla As String, ByVal intIdMotivo As Integer, ByVal strTipoMovto As String)

        Dim strCodUPC As String = String.Empty
        strCodUPC = SelectCodUPC(strArticulo, strTalla)

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand

        With sccmdInsert

            .Connection = sccnnConnection

            .CommandText = "[MotivosFacIns]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FacturaID", System.Data.SqlDbType.Int, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Tienda", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Articulo", System.Data.SqlDbType.VarChar, 30))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Talla", System.Data.SqlDbType.VarChar, 10))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@IdMotivo", System.Data.SqlDbType.Int, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime, 8))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TipoMovto", System.Data.SqlDbType.VarChar, 5))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodUpc", System.Data.SqlDbType.VarChar, 18))

        End With

        Try

            sccnnConnection.Open()

            With sccmdInsert
                'Assign Parameters Values
                .Parameters("@FacturaID").Value = strFacturaID
                .Parameters("@Tienda").Value = strTienda
                .Parameters("@Articulo").Value = strArticulo
                .Parameters("@Talla").Value = strTalla
                .Parameters("@IdMotivo").Value = intIdMotivo
                .Parameters("@Fecha").Value = Now.Date.ToShortDateString
                .Parameters("@TipoMovto").Value = strTipoMovto
                .Parameters("@CodUpc").Value = strCodUPC

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

    Public Function SelectTraspasosByDate(ByVal Fecha As Date, ByVal Modulo As String) As DataTable

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                         GetConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaTraspasoEntrada As SqlDataAdapter
        Dim dsTraspasoEntrada As DataSet



        sccmdSelectAll = New SqlCommand
        scdaTraspasoEntrada = New SqlDataAdapter
        dsTraspasoEntrada = New DataSet("Traspaso")

        With sccmdSelectAll

            .Connection = sccnnConnection

            .CommandText = "[TraspasoSalidaByFecha]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime, 8))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Modulo", System.Data.SqlDbType.VarChar, 2))

            .Parameters("@CodAlmacen").Value = oParent.ApplicationContext.ApplicationConfiguration.Almacen
            .Parameters("@Fecha").Value = Fecha
            .Parameters("@Modulo").Value = Modulo.Trim.ToUpper

        End With

        scdaTraspasoEntrada.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            'Fill DataSet
            scdaTraspasoEntrada.Fill(dsTraspasoEntrada, "Traspaso")

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

        Return dsTraspasoEntrada.Tables(0)

    End Function

    Public Function SelectTraspasoSalidaByDate(ByVal FechaDe As DateTime, ByVal FechaAl As DateTime) As DataSet
        Dim conexion As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString())
        Dim command As New SqlCommand("TraspasosSalidaInventario", conexion)
        Dim adapter As SqlDataAdapter
        Dim result As New DataSet
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@FechaInicio", FechaDe)
            command.Parameters.Add("@FechaFin", FechaAl)
            adapter = New SqlDataAdapter(command)
            adapter.Fill(result)
            command.Dispose()
            conexion.Close()
        Catch sql As Exception
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            'EscribeLog(sql.ToString(), "Los registros no pudieron ser leidos debido a un error de base de datos.", sql)
            Throw New ApplicationException("Los registros no pudieron ser leidos debido a un error de base de datos.", sql)
        Catch ex As Exception
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            'EscribeLog(ex.ToString(), "Los registros no pudieron ser leidos debido a un error de aplicación.", ex)
            Throw New ApplicationException("Los registros no pudieron ser leidos debido a un error de aplicación.", ex)
        End Try
        Return result
    End Function

    Public Function SelectAllByDate(ByVal FechaDe As DateTime, ByVal FechaAl As DateTime) As DataSet

        'TODO: JHV - Implementar retorno de dataset con todos los traspasos.

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaTraspasoEntrada As SqlDataAdapter
        Dim dsTraspasoEntrada As DataSet



        sccmdSelectAll = New SqlCommand
        scdaTraspasoEntrada = New SqlDataAdapter
        dsTraspasoEntrada = New DataSet("Traspaso")

        With sccmdSelectAll

            .Connection = sccnnConnection

            .CommandText = "[TraspasoSalidaReporte]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Origen", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaDe", System.Data.SqlDbType.DateTime))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaAl", System.Data.SqlDbType.DateTime))

            .Parameters("@Origen").Value = oParent.ApplicationContext.ApplicationConfiguration.Almacen
            .Parameters("@FechaDe").Value = FechaDe
            .Parameters("@FechaAl").Value = FechaAl

        End With

        scdaTraspasoEntrada.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            'Fill DataSet
            scdaTraspasoEntrada.Fill(dsTraspasoEntrada, "Traspaso")

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

        Return dsTraspasoEntrada

    End Function

    Friend Function SeleccionaCentro(ByVal strcentrodes As String) As String

        Dim strResult As String
        Dim sccnnDPTienda As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdCatalogoCentrosSel As SqlCommand
        sccmdCatalogoCentrosSel = New SqlCommand

        With sccmdCatalogoCentrosSel
            .CommandText = "[CatalogoCentrosSel]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Connection = sccnnDPTienda
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@OficinaVtas", System.Data.SqlDbType.VarChar, 4))

            .Parameters("@OficinaVtas").Value = strcentrodes
        End With

        Try
            sccnnDPTienda.Open()

            Dim scsdrReader As SqlDataReader

            scsdrReader = sccmdCatalogoCentrosSel.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.SingleRow)

            scsdrReader.Read()

            If (scsdrReader.HasRows) Then

                With scsdrReader
                    strResult = .GetString(0) 'Cod Centro SAP
                End With
                scsdrReader.Close()

            Else

                strResult = String.Empty

            End If


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

        sccmdCatalogoCentrosSel.Dispose()
        sccmdCatalogoCentrosSel = Nothing

        sccnnDPTienda.Dispose()
        sccnnDPTienda = Nothing

        Return strResult
    End Function

    Public Function DefectuososSelectAll() As DataSet

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaTraspasoEntrada As SqlDataAdapter
        Dim dsTraspasoEntrada As DataSet



        sccmdSelectAll = New SqlCommand
        scdaTraspasoEntrada = New SqlDataAdapter
        dsTraspasoEntrada = New DataSet("Traspaso")

        With sccmdSelectAll

            .Connection = sccnnConnection

            .CommandText = "[TraspasoSalidaDefectuososSelAll]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 3))

            .Parameters("@CodAlmacen").Value = oParent.ApplicationContext.ApplicationConfiguration.Almacen

        End With

        scdaTraspasoEntrada.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            'Fill DataSet
            scdaTraspasoEntrada.Fill(dsTraspasoEntrada, "Traspaso")

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

        Return dsTraspasoEntrada

    End Function


    Public Function DatosEmpresaSel() As DataSet

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaDatEmp As SqlDataAdapter
        Dim dsDatEmp As DataSet



        sccmdSelectAll = New SqlCommand
        scdaDatEmp = New SqlDataAdapter
        dsDatEmp = New DataSet("DatosEmpresa")

        With sccmdSelectAll

            .Connection = sccnnConnection

            .CommandText = "[DatosEmpresaSel]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))

        End With

        scdaDatEmp.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            'Fill DataSet
            scdaDatEmp.Fill(dsDatEmp, "DatosEmpresa")

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

        Return dsDatEmp

    End Function

#End Region

#Region "Consignacion"

    Public Function ActualizaDocumentoDevProveedor(ByVal TraspasoId As Integer, ByVal Mblnr As String) As Boolean
        Dim valido As Boolean = False
        Dim conexion As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)
        Dim command As New SqlCommand("UpdateFolioTraspasoSalida", conexion)
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.AddWithValue("@TraspasoId", TraspasoId)
            command.Parameters.AddWithValue("@Mblnr", Mblnr)
            command.ExecuteNonQuery()
            command.Dispose()
            conexion.Close()
            valido = True
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
        Return valido
    End Function

#End Region

End Class
