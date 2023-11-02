
Imports System.Data.SqlClient
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos
Imports System.IO
Imports System.Data.Odbc
Imports Microsoft
Imports System
Imports System.Data

Imports DportenisPro.DPTienda.ApplicationUnits.Traspasos.TraspasosSalida
Imports System.Collections.Generic


Friend Class TraspasosEntradaDataGateway

    Private oParent As TraspasosEntradaManager
    Private oTraspasoSalidaMgr As TraspasosSalidaManager
    Dim strConnectionStringServer As String = ""
    Dim strConnectionStringSeparaciones As String = ""

#Region "Constructors / Destructors"

    Public Sub New(ByVal Parent As TraspasosEntradaManager)
        oParent = Parent
        oTraspasoSalidaMgr = New TraspasosSalidaManager(oParent.ApplicationContext)

        If Not oParent.ConfigCierreFI Is Nothing Then
            strConnectionStringServer = "data source = " & oParent.ConfigCierreFI.ServerTraspasos & "; initial catalog = " & oParent.ConfigCierreFI.BaseDatosTraspasos & _
                                        "; user id = " & oParent.ConfigCierreFI.UserTraspasos & "; password = " & _
                                        oParent.ConfigCierreFI.PasswordTraspasos

            strConnectionStringSeparaciones = "data source = " & oParent.ConfigCierreFI.ServerSeparaciones & "; initial catalog = " & _
                                        oParent.ConfigCierreFI.BDSeparaciones & "; user id = " & oParent.ConfigCierreFI.UserSeparaciones & "; password = " & _
                                        oParent.ConfigCierreFI.PassSeparaciones
        End If
    End Sub

#End Region


#Region "Properties"

    Public Property Parent() As TraspasosEntradaManager
        Get
            Return oParent
        End Get
        Set(ByVal Value As TraspasosEntradaManager)
            oParent = Value
        End Set
    End Property

#End Region


#Region "Methods"

    Public Function [Select](ByVal TraspasoID As Integer, Optional ByVal TraspasoEntradaTarget As TraspasoEntrada = Nothing) As TraspasoEntrada

        'TODO: JHV - Implementar retorno de TraspasoEntrada
        'NOTE: Si se especifica TraspasoEntradaTarget, utilizar ese en lugar de crear y devolver uno nuevo

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        Dim dsDataSet As DataSet
        dsDataSet = New DataSet("TraspasoCorrida")

        Dim oTraspasoEntrada As TraspasoEntrada




        If Not (TraspasoEntradaTarget Is Nothing) Then

            oTraspasoEntrada = TraspasoEntradaTarget
        Else

            oTraspasoEntrada = New TraspasoEntrada(oParent)

        End If


        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            ''.CommandText = "[TraspasoSel]"
            .CommandText = "[TraspasoEntradaSel]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@IdTraspaso", System.Data.SqlDbType.Int))

        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect
                'Assign Parameters Values
                .Parameters("@IdTraspaso").Value = TraspasoID

                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    'Traspaso General :
                    With scdrReader


                        oTraspasoEntrada.AlmacenOrigenID = .GetString(2).ToUpper '.GetString(0).ToUpper
                        oTraspasoEntrada.AlmacenDestinoID = .GetString(3).ToUpper '.GetString(1).ToUpper
                        oTraspasoEntrada.TransportistaID = .GetString(4) '.GetString(2)
                        oTraspasoEntrada.TraspasoID = .GetInt32(0) '.GetInt32(3)
                        oTraspasoEntrada.TraspasoCreadoEl = .GetDateTime(5) '.GetDateTime(4)
                        oTraspasoEntrada.MonedaID = "1" '.GetString(5).ToUpper
                        oTraspasoEntrada.TotalBultos = .GetInt32(6)
                        oTraspasoEntrada.Guia = .GetString(7).ToUpper
                        oTraspasoEntrada.SubTotal = 0 '.GetDecimal(8)
                        oTraspasoEntrada.Status = "GRA" '.GetString(9)

                        oTraspasoEntrada.FolioSAP = .GetString(1) '.GetString(10)
                        If (IsDBNull(.Item(1)) = False) Then
                            oTraspasoEntrada.Referencia = .GetString(1) '.GetString(10)
                        End If

                        If (IsDBNull(.Item(10)) = False) Then
                            oTraspasoEntrada.TraspasoRecibidoEl = .GetDateTime(10) '.GetDateTime(11)
                        End If

                        If (IsDBNull(.Item(1)) = False) Then
                            oTraspasoEntrada.Folio = .GetString(1) '.GetString(12)
                        End If

                        If (IsDBNull(.Item(9)) = False) Then
                            oTraspasoEntrada.AutorizadoPorID = .GetString(9) '.GetString(13)
                        End If
                        'If Not .IsDBNull(14) Then
                        '    oTraspasoEntrada.Observaciones = .GetString(14)
                        'End If
                        'oTraspasoEntrada.ResetFlagIsNew()
                        'oTraspasoEntrada.ResetFlagIsDirty()

                        .Close()

                    End With


                    'Traspaso Corrida [GRID] :

                    Dim scdaAdapter As New SqlDataAdapter

                    sccmdSelect.Dispose()
                    sccmdSelect = Nothing

                    sccmdSelect = New SqlCommand

                    With sccmdSelect

                        .Connection = sccnnConnection

                        .CommandText = "[TraspasoEntradaCorridaSel]"
                        .CommandType = System.Data.CommandType.StoredProcedure

                        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
                        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@IDTraspaso", System.Data.SqlDbType.Int))

                        .Parameters("@IDTraspaso").Value = TraspasoID

                    End With

                    scdaAdapter.SelectCommand = sccmdSelect
                    scdaAdapter.Fill(dsDataSet, "TraspasoCorrida")

                    oTraspasoEntrada.Detalle = dsDataSet

                    dsDataSet.Dispose()
                    sccmdSelect.Dispose()
                    scdaAdapter.Dispose()

                    dsDataSet = Nothing
                    sccmdSelect = Nothing
                    scdaAdapter = Nothing


                Else
                    oTraspasoEntrada = Nothing
                End If

            End With

            oTraspasoEntrada.ResetFlagIsNew()
            oTraspasoEntrada.ResetFlagIsDirty()

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

        Return oTraspasoEntrada

    End Function

    Public Function SelectByFolioSAP(ByVal TrasladoOrigenSAP As String) As TraspasoEntrada

        'TODO: JHV - Implementar retorno de TraspasoEntrada
        'NOTE: Si se especifica TraspasoEntradaTarget, utilizar ese en lugar de crear y devolver uno nuevo

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        Dim dsDataSet As DataSet
        dsDataSet = New DataSet("TraspasoCorrida")

        Dim oTraspasoEntrada As TraspasoEntrada

        oTraspasoEntrada = New TraspasoEntrada(oParent)

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            ''.CommandText = "[TraspasoSel]"
            .CommandText = "[TraspasoEntradaSelByFolioSAP]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioTraspasoSAP", System.Data.SqlDbType.VarChar, 10))

        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect
                'Assign Parameters Values
                .Parameters("@FolioTraspasoSAP").Value = TrasladoOrigenSAP.Trim.PadLeft(10, Convert.ToChar("0"))

                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    'Traspaso General :
                    With scdrReader

                        oTraspasoEntrada.AlmacenOrigenID = .GetString(2).ToUpper '.GetString(0).ToUpper
                        oTraspasoEntrada.AlmacenDestinoID = .GetString(3).ToUpper '.GetString(1).ToUpper
                        oTraspasoEntrada.TransportistaID = .GetString(4) '.GetString(2)
                        oTraspasoEntrada.TraspasoID = .GetInt32(0) '.GetInt32(3)
                        oTraspasoEntrada.TraspasoCreadoEl = .GetDateTime(5) '.GetDateTime(4)
                        oTraspasoEntrada.MonedaID = "1" '.GetString(5).ToUpper
                        oTraspasoEntrada.TotalBultos = .GetInt32(6)
                        oTraspasoEntrada.Guia = .GetString(7).ToUpper
                        oTraspasoEntrada.SubTotal = 0 '.GetDecimal(8)
                        oTraspasoEntrada.Status = "GRA" '.GetString(9)

                        oTraspasoEntrada.FolioSAP = .GetString(1) '.GetString(10)
                        If (IsDBNull(.Item(1)) = False) Then
                            oTraspasoEntrada.Referencia = .GetString(1) '.GetString(10)
                        End If

                        If (IsDBNull(.Item(10)) = False) Then
                            oTraspasoEntrada.TraspasoRecibidoEl = .GetDateTime(10) '.GetDateTime(11)
                        End If

                        If (IsDBNull(.Item(1)) = False) Then
                            oTraspasoEntrada.Folio = .GetString(1) '.GetString(12)
                        End If

                        If (IsDBNull(.Item(9)) = False) Then
                            oTraspasoEntrada.AutorizadoPorID = .GetString(9) '.GetString(13)
                        End If
                        'If Not .IsDBNull(14) Then
                        '    oTraspasoEntrada.Observaciones = .GetString(14)
                        'End If
                        'oTraspasoEntrada.ResetFlagIsNew()
                        'oTraspasoEntrada.ResetFlagIsDirty()

                        .Close()

                    End With

                    'Traspaso Corrida [GRID] :

                    Dim scdaAdapter As New SqlDataAdapter

                    sccmdSelect.Dispose()
                    sccmdSelect = Nothing

                    sccmdSelect = New SqlCommand

                    With sccmdSelect

                        .Connection = sccnnConnection

                        .CommandText = "[TraspasoEntradaCorridaSel]"
                        .CommandType = System.Data.CommandType.StoredProcedure

                        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
                        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@IDTraspaso", System.Data.SqlDbType.Int))

                        .Parameters("@IDTraspaso").Value = oTraspasoEntrada.TraspasoID

                    End With

                    scdaAdapter.SelectCommand = sccmdSelect
                    scdaAdapter.Fill(dsDataSet, "TraspasoCorrida")

                    oTraspasoEntrada.Detalle = dsDataSet

                    dsDataSet.Dispose()
                    sccmdSelect.Dispose()
                    scdaAdapter.Dispose()

                    dsDataSet = Nothing
                    sccmdSelect = Nothing
                    scdaAdapter = Nothing


                Else
                    oTraspasoEntrada = Nothing
                End If

            End With

            If Not oTraspasoEntrada Is Nothing Then
                oTraspasoEntrada.ResetFlagIsNew()
                oTraspasoEntrada.ResetFlagIsDirty()
            End If

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

        Return oTraspasoEntrada

    End Function

    Public Function SelectAll(ByVal AlmacenOrigenID As String, ByVal AlmacenDestinoID As String, _
                              ByVal FromDate As Date, ByVal ToDate As Date, ByVal strStatus As String) As DataSet

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

            .CommandText = "[TraspasoSelAllTest]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@AlmacenOrigenID", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@AlmacenDestinoID", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FromDate", System.Data.SqlDbType.DateTime))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ToDate", System.Data.SqlDbType.DateTime))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Status", System.Data.SqlDbType.VarChar, 3))

        End With

        scdaTraspasoEntrada.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            'Almacen que Envia :
            scdaTraspasoEntrada.SelectCommand.Parameters("@AlmacendestinoID").Value = AlmacenDestinoID

            'Almacen que Recibe :
            scdaTraspasoEntrada.SelectCommand.Parameters("@AlmacenOrigenID").Value = AlmacenOrigenID

            scdaTraspasoEntrada.SelectCommand.Parameters("@FromDate").Value = Format(FromDate, "Short Date")
            scdaTraspasoEntrada.SelectCommand.Parameters("@ToDate").Value = Format(ToDate, "Short Date")
            scdaTraspasoEntrada.SelectCommand.Parameters("@Status").Value = strStatus

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



    Public Function TraspasoEntradaPendientesSelectAll() As DataSet

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

            .CommandText = "[TraspasoEntradaPendientesSelAll]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@AlmacenOrigenID", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Status", System.Data.SqlDbType.VarChar, 3))

        End With

        scdaTraspasoEntrada.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            scdaTraspasoEntrada.SelectCommand.Parameters("@AlmacenOrigenID").Value = oParent.ApplicationContext.ApplicationConfiguration.Almacen
            scdaTraspasoEntrada.SelectCommand.Parameters("@Status").Value = "TRA"

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


    Public Sub InsertArtNoLecturados(ByVal strOrigen As String, ByVal strOrigenDesc As String, _
    ByVal strDestino As String, ByVal strDestinoDesc As String, ByVal strFolioTraslado As String, _
    ByVal strResponsable As String, ByVal strTipoMovto As String, ByVal dvDetalle As DataView)

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand

        With sccmdInsert
            .Connection = sccnnConnection
            .CommandText = "[ArtNoLecturadosIns]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Origen", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@OrigenDesc", System.Data.SqlDbType.VarChar, 200))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Destino", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@DestinoDesc", System.Data.SqlDbType.VarChar, 200))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioTraslado", System.Data.SqlDbType.VarChar, 10))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Responsable", System.Data.SqlDbType.VarChar, 150))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TipoMovto", System.Data.SqlDbType.VarChar, 5))

        End With

        Try

            sccnnConnection.Open()

            With sccmdInsert
                'Assign Parameters Values
                .Parameters("@Origen").Value = strOrigen
                .Parameters("@OrigenDesc").Value = strOrigenDesc
                .Parameters("@Destino").Value = strDestino
                .Parameters("@DestinoDesc").Value = strDestinoDesc
                .Parameters("@FolioTraslado").Value = strFolioTraslado
                .Parameters("@Responsable").Value = strResponsable
                .Parameters("@TipoMovto").Value = strTipoMovto

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

        ''Inserto el Detalle
        For Each oDRVIEW As DataRowView In dvDetalle


            sccmdInsert = New SqlCommand

            With sccmdInsert
                .Connection = sccnnConnection
                .CommandText = "[ArtNoLecturadosInsDetalle]"
                .CommandType = System.Data.CommandType.StoredProcedure

                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodArticulo", System.Data.SqlDbType.VarChar, 30))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Descripcion", System.Data.SqlDbType.VarChar, 200))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Talla", System.Data.SqlDbType.VarChar, 10))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Cantidad", System.Data.SqlDbType.Int, 4))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Tipo", System.Data.SqlDbType.VarChar, 10))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioTraslado", System.Data.SqlDbType.VarChar, 10))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Agregado", System.Data.SqlDbType.Int, 4))

            End With

            Try

                sccnnConnection.Open()

                With sccmdInsert
                    'Assign Parameters Values
                    .Parameters("@CodArticulo").Value = oDRVIEW("codigo")
                    .Parameters("@Descripcion").Value = oDRVIEW("descripcion")
                    .Parameters("@Talla").Value = oDRVIEW("talla")
                    .Parameters("@Cantidad").Value = CInt(oDRVIEW("cantidad")) - CInt(oDRVIEW("lecturado"))
                    .Parameters("@Tipo").Value = oDRVIEW("tipo")
                    .Parameters("@FolioTraslado").Value = strFolioTraslado.Trim
                    .Parameters("@Agregado").Value = CBool(oDRVIEW("Agregado"))

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

        Next


        sccnnConnection.Dispose()
        sccnnConnection = Nothing

    End Sub


    Public Sub InserArtAclaracion(ByVal strFolio As String, ByVal dtDetalle As DataTable)

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)
        Dim bLecturado As Boolean = False
        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand


        If dtDetalle.Columns.Contains("MATERIAL") Then
            dtDetalle.Columns("MATERIAL").ColumnName = "Codigo"
        End If

        If dtDetalle.Columns.Contains("MOTIVO") Then
            dtDetalle.Columns("MOTIVO").ColumnName = "DescMotivo"
        End If

        If dtDetalle.Columns.Contains("lecturado") Then
            bLecturado = True
        End If




        sccmdInsert = New SqlCommand

        With sccmdInsert
            .Connection = sccnnConnection
            .CommandText = "[ArtAclaracionIns]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodArticulo", System.Data.SqlDbType.VarChar, 20))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@IDMotivo", System.Data.SqlDbType.VarChar, 2))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Talla", System.Data.SqlDbType.VarChar, 10))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@DescMotivo", System.Data.SqlDbType.VarChar, 50))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Cantidad", System.Data.SqlDbType.Int, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CantAclarada", System.Data.SqlDbType.Int, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Traspaso", System.Data.SqlDbType.VarChar, 10))

        End With

        Try

            sccnnConnection.Open()

            For Each oRow As DataRow In dtDetalle.Rows
                If CStr(oRow("Tipo")) = "FALTANTE" Then
                    With sccmdInsert
                        'Assign Parameters Values
                        .Parameters("@CodArticulo").Value = oRow("Codigo")
                        .Parameters("@Talla").Value = oRow("Talla")
                        .Parameters("@DescMotivo").Value = oRow("Tipo")
                        .Parameters("@IDMotivo").Value = "01"
                        If bLecturado Then
                            .Parameters("@Cantidad").Value = CInt(oRow("cantidad")) - CInt(oRow("lecturado"))
                        Else
                            .Parameters("@Cantidad").Value = CInt(oRow("cantidad"))
                        End If
                        .Parameters("@CantAclarada").Value = 0
                        If strFolio <> "" Then
                            .Parameters("@Traspaso").Value = strFolio.Trim
                        Else
                            .Parameters("@Traspaso").Value = oRow("Traspaso")
                        End If

                        'Execute Command
                        .ExecuteNonQuery()

                    End With
                End If

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


    Public Sub CargaInicialArticulosAclaracion(ByVal dtDetalle As DataTable)

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)
        Dim bLecturado As Boolean = False
        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand



        sccmdInsert = New SqlCommand

        With sccmdInsert
            .Connection = sccnnConnection
            .CommandText = "[ArtAclaracionIns]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodArticulo", System.Data.SqlDbType.VarChar, 20))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Talla", System.Data.SqlDbType.VarChar, 10))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@IDMotivo", System.Data.SqlDbType.VarChar, 2))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@DescMotivo", System.Data.SqlDbType.VarChar, 50))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Cantidad", System.Data.SqlDbType.Int, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CantAclarada", System.Data.SqlDbType.Int, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Traspaso", System.Data.SqlDbType.VarChar, 10))

        End With

        Try

            sccnnConnection.Open()

            For Each oRow As DataRow In dtDetalle.Rows


                If dtDetalle.Columns.Contains("MATNR") AndAlso dtDetalle.Columns.Contains("MENGE") Then
                    With sccmdInsert
                        'Assign Parameters Values
                        .Parameters("@CodArticulo").Value = oRow("MATNR")
                        .Parameters("@Talla").Value = ""
                        .Parameters("@IDMotivo").Value = "01"

                        If dtDetalle.Columns.Contains("ABGRU") Then
                            .Parameters("@DescMotivo").Value = oRow("ABGRU")
                        Else
                            .Parameters("@DescMotivo").Value = ""
                        End If

                        .Parameters("@Cantidad").Value = CInt(oRow("MENGE"))
                        .Parameters("@CantAclarada").Value = 0

                        If dtDetalle.Columns.Contains("VBELN") Then
                            .Parameters("@Traspaso").Value = oRow("VBELN")
                        Else
                            .Parameters("@Traspaso").Value = ""
                        End If

                        'Execute Command
                        .ExecuteNonQuery()

                    End With
                End If

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


    Public Sub CargaInicialBajaCalidad(ByVal dtDetalle As DataTable)

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)
        Dim bLecturado As Boolean = False
        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand



        sccmdInsert = New SqlCommand

        With sccmdInsert
            .Connection = sccnnConnection
            .CommandText = "[BajaCalidadIns]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Codigo", System.Data.SqlDbType.VarChar, 20))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Talla", System.Data.SqlDbType.VarChar, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Cantidad", System.Data.SqlDbType.Int, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Motivo", System.Data.SqlDbType.VarChar, 50))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@IDMotivo", System.Data.SqlDbType.VarChar, 2))

        End With

        Try

            sccnnConnection.Open()

            For Each oRow As DataRow In dtDetalle.Rows

                With sccmdInsert
                    'Assign Parameters Values
                    .Parameters("@Codigo").Value = oRow("MATNR")
                    .Parameters("@Talla").Value = ""
                    .Parameters("@Cantidad").Value = CInt(oRow("MENGE"))
                    .Parameters("@Motivo").Value = ""
                    .Parameters("@IDMotivo").Value = oRow("ABGRU")

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


    Public Sub CargaInicialDefectuosos(ByVal dtDetalle As DataTable)

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)
        Dim bLecturado As Boolean = False
        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand



        sccmdInsert = New SqlCommand

        With sccmdInsert

            .Connection = sccnnConnection

            .CommandText = "[DefectuososIns]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Connection = sccnnConnection

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Output, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar, 2))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FacturaID", System.Data.SqlDbType.Int, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodArticulo", System.Data.SqlDbType.VarChar, 20))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Numero", System.Data.SqlDbType.VarChar, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Cantidad", System.Data.SqlDbType.TinyInt, 1, System.Data.ParameterDirection.Input, False, CType(5, Byte), CType(1, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@DefectoNota", System.Data.SqlDbType.VarChar, 200))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Autorizo", System.Data.SqlDbType.VarChar, 12))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Usuario", System.Data.SqlDbType.VarChar, 12))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Output, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@StatusRegistro", System.Data.SqlDbType.Bit, 1))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Costo", System.Data.SqlDbType.Money))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha_Desm", System.Data.SqlDbType.DateTime, 8))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Folio_Tras", System.Data.SqlDbType.VarChar, 8))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha_Tras", System.Data.SqlDbType.DateTime, 8))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioMovimiento", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Output, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FIDOCUMENT", System.Data.SqlDbType.VarChar, 10))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@BloqueoEcommerce", System.Data.SqlDbType.Bit, 1))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@BloqueoSiHay", System.Data.SqlDbType.Bit, 1))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Observaciones", System.Data.SqlDbType.VarChar, 200))

        End With



        Try

            sccnnConnection.Open()

            For Each oRow As DataRow In dtDetalle.Rows

                With sccmdInsert
                    'Assign Parameters Values

                    'Assign Parameters Values
                    .Parameters("@CodAlmacen").Value = oParent.ApplicationContext.ApplicationConfiguration.Almacen
                    .Parameters("@CodCaja").Value = oParent.ApplicationContext.ApplicationConfiguration.NoCaja
                    .Parameters("@FacturaID").Value = 0
                    .Parameters("@CodArticulo").Value = oRow("MATNR")
                    .Parameters("@Numero").Value = oRow("TALLA")
                    .Parameters("@Cantidad").Value = CInt(oRow("MENGE"))
                    .Parameters("@DefectoNota").Value = ""
                    .Parameters("@Autorizo").Value = "SAP"
                    .Parameters("@Usuario").Value = "SAP"
                    .Parameters("@Fecha").Value = Date.Now
                    .Parameters("@StatusRegistro").Value = 1
                    .Parameters("@Costo").Value = 0
                    .Parameters("@Fecha_Desm").Value = System.DBNull.Value
                    .Parameters("@Folio_Tras").Value = 0
                    .Parameters("@Fecha_Tras").Value = System.DBNull.Value
                    .Parameters("@FIDOCUMENT").Value = ""
                    .Parameters("@BloqueoEcommerce").Value = 0
                    .Parameters("@BloqueoSiHay").Value = 0
                    .Parameters("@Observaciones").Value = ""
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



    Public Sub EliminaRegistros(ByVal Tabla As String)

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)
        Dim bLecturado As Boolean = False
        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand



        sccmdInsert = New SqlCommand

        With sccmdInsert
            .Connection = sccnnConnection
            .CommandText = "[EliminaRegistrosTabla]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Tabla", System.Data.SqlDbType.VarChar, 30))
           

        End With

        Try

            sccnnConnection.Open()



            With sccmdInsert
                'Assign Parameters Values
                .Parameters("@Tabla").Value = Tabla
                
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




    Public Sub UpdateArtAclaracion(ByVal Folio As String, ByVal Codigo As String, ByVal CantAclarada As Integer)

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand

        With sccmdInsert
            .Connection = sccnnConnection
            .CommandText = "[ArtAclaracionUpd]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodArticulo", System.Data.SqlDbType.VarChar, 20))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CantAclarada", System.Data.SqlDbType.Int, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Traspaso", System.Data.SqlDbType.VarChar, 10))

        End With

        Try

            sccnnConnection.Open()

            With sccmdInsert
                'Assign Parameters Values
                .Parameters("@CodArticulo").Value = Codigo
                .Parameters("@CantAclarada").Value = CantAclarada
                .Parameters("@Traspaso").Value = Folio

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


    Public Function SelectArticulosAclaracionByFolio(ByVal Traspaso As String) As DataTable

        Dim oResult As DataSet
        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                              GetConnectionString)

        Dim sccmdSelect As SqlCommand
        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[ArtAclaracionSelByTrapaso]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Traspaso", System.Data.SqlDbType.VarChar, 10))
            .Parameters("@Traspaso").Value = Traspaso

        End With

        Dim oConfigAdapter As New SqlDataAdapter
        oConfigAdapter.SelectCommand = sccmdSelect

        Try
            sccnnConnection.Open()

            oResult = New DataSet

            oConfigAdapter.Fill(oResult, "Codigos")

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

        Return oResult.Tables(0)
    End Function


    Public Sub InsertArtNoLecturadosInServer(ByVal strOrigen As String, ByVal strOrigenDesc As String, _
   ByVal strDestino As String, ByVal strDestinoDesc As String, ByVal strFolioTraslado As String, _
   ByVal strResponsable As String, ByVal strTipoMovto As String, ByVal dvDetalle As DataView)

        Dim sccnnConnection As New SqlConnection(strConnectionStringServer)

        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand

        With sccmdInsert
            .Connection = sccnnConnection
            .CommandText = "[ArtNoLecturadosIns]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Origen", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@OrigenDesc", System.Data.SqlDbType.VarChar, 200))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Destino", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@DestinoDesc", System.Data.SqlDbType.VarChar, 200))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioTraslado", System.Data.SqlDbType.VarChar, 10))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Responsable", System.Data.SqlDbType.VarChar, 150))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TipoMovto", System.Data.SqlDbType.VarChar, 5))

        End With

        Try

            sccnnConnection.Open()

            With sccmdInsert
                'Assign Parameters Values
                .Parameters("@Origen").Value = strOrigen
                .Parameters("@OrigenDesc").Value = strOrigenDesc
                .Parameters("@Destino").Value = strDestino
                .Parameters("@DestinoDesc").Value = strDestinoDesc
                .Parameters("@FolioTraslado").Value = strFolioTraslado
                .Parameters("@Responsable").Value = strResponsable
                .Parameters("@TipoMovto").Value = strTipoMovto

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

        ''Inserto el Detalle
        For Each oDRVIEW As DataRowView In dvDetalle


            sccmdInsert = New SqlCommand

            With sccmdInsert
                .Connection = sccnnConnection
                .CommandText = "[ArtNoLecturadosInsDetalle]"
                .CommandType = System.Data.CommandType.StoredProcedure

                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodArticulo", System.Data.SqlDbType.VarChar, 30))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Descripcion", System.Data.SqlDbType.VarChar, 200))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Talla", System.Data.SqlDbType.VarChar, 10))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Cantidad", System.Data.SqlDbType.Int, 4))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Tipo", System.Data.SqlDbType.VarChar, 10))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioTraslado", System.Data.SqlDbType.VarChar, 10))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Agregado", System.Data.SqlDbType.Int, 4))

            End With

            Try

                sccnnConnection.Open()

                With sccmdInsert
                    'Assign Parameters Values
                    .Parameters("@CodArticulo").Value = oDRVIEW("codigo")
                    .Parameters("@Descripcion").Value = oDRVIEW("descripcion")
                    .Parameters("@Talla").Value = oDRVIEW("talla")
                    .Parameters("@Cantidad").Value = CInt(oDRVIEW("cantidad")) - CInt(oDRVIEW("lecturado"))
                    .Parameters("@Tipo").Value = oDRVIEW("tipo")
                    .Parameters("@FolioTraslado").Value = strFolioTraslado.Trim
                    .Parameters("@Agregado").Value = CBool(oDRVIEW("Agregado"))

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

        Next


        sccnnConnection.Dispose()
        sccnnConnection = Nothing

    End Sub

    Public Function SelectAll(ByVal strAlmacenDestinoID As String) As DataSet

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

            '.CommandText = "[TraspasoEntradaSelAll]"

            .CommandText = "[TraspasoEntradaSelAllNew]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))

        End With

        scdaTraspasoEntrada.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            'Almacen que Envia :

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

    Public Function SelectDetalleByBultosSeparaciones(ByVal strFolioTrasladoSAP As String, ByVal NumBulto As Integer, ByRef Tratado As Boolean) As DataTable

        Dim sccnnConnection As New SqlConnection(strConnectionStringSeparaciones)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaTraspasoEntrada As SqlDataAdapter
        Dim dsTraspasoEntrada As DataSet

        sccmdSelectAll = New SqlCommand
        scdaTraspasoEntrada = New SqlDataAdapter
        dsTraspasoEntrada = New DataSet("Traspaso")

        With sccmdSelectAll

            .Connection = sccnnConnection

            '.CommandText = "[TraspasoEntradaSelAll]"

            .CommandText = "[BultosSelByFolioTraslado]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New SqlParameter("@FolioTraspaso", SqlDbType.VarChar, 10))
            .Parameters.Add(New SqlParameter("@Bulto", SqlDbType.Int, 4))
            .Parameters.Add(New SqlParameter("@Tratado", SqlDbType.Bit, 1))

            .Parameters("@FolioTraspaso").Value = strFolioTrasladoSAP.Trim
            .Parameters("@Bulto").Value = NumBulto

            .Parameters("@Tratado").Direction = ParameterDirection.Output

        End With

        scdaTraspasoEntrada.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            'Fill DataSet
            scdaTraspasoEntrada.Fill(dsTraspasoEntrada, "Traspaso")

            Tratado = CBool(sccmdSelectAll.Parameters("@Tratado").Value)

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

    Public Function SelectDetalleByBultosServer(ByVal strFolioTrasladoSAP As String, ByVal NumBulto As Integer) As Boolean

        Dim sccnnConnection As New SqlConnection(strConnectionStringServer)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaTraspasoEntrada As SqlDataAdapter
        Dim dsTraspasoEntrada As DataSet
        Dim bRes As Boolean = True

        sccmdSelectAll = New SqlCommand
        scdaTraspasoEntrada = New SqlDataAdapter
        dsTraspasoEntrada = New DataSet("Traspaso")

        With sccmdSelectAll

            .Connection = sccnnConnection

            .CommandText = "[TraspasoEntradaSelByBulto]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New SqlParameter("@FolioTraspaso", SqlDbType.VarChar, 10))
            .Parameters.Add(New SqlParameter("@Bulto", SqlDbType.Int, 4))

            .Parameters("@FolioTraspaso").Value = strFolioTrasladoSAP.Trim
            .Parameters("@Bulto").Value = NumBulto

        End With

        scdaTraspasoEntrada.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            'Fill DataSet
            scdaTraspasoEntrada.Fill(dsTraspasoEntrada, "Traspaso")

            sccnnConnection.Close()

            If dsTraspasoEntrada.Tables(0).Rows.Count > 0 Then
                bRes = True
            Else
                bRes = False
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

        Return bRes

    End Function

    Public Function SelectDetalleByBultos(ByVal strFolioTrasladoSAP As String, ByVal NumBulto As Integer) As Boolean

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaTraspasoEntrada As SqlDataAdapter
        Dim dsTraspasoEntrada As DataSet
        Dim bRes As Boolean = True

        sccmdSelectAll = New SqlCommand
        scdaTraspasoEntrada = New SqlDataAdapter
        dsTraspasoEntrada = New DataSet("Traspaso")

        With sccmdSelectAll

            .Connection = sccnnConnection

            .CommandText = "[TraspasoEntradaSelByBulto]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New SqlParameter("@FolioTraspaso", SqlDbType.VarChar, 10))
            .Parameters.Add(New SqlParameter("@Bulto", SqlDbType.Int, 4))

            .Parameters("@FolioTraspaso").Value = strFolioTrasladoSAP.Trim
            .Parameters("@Bulto").Value = NumBulto

        End With

        scdaTraspasoEntrada.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            'Fill DataSet
            scdaTraspasoEntrada.Fill(dsTraspasoEntrada, "Traspaso")

            sccnnConnection.Close()

            If dsTraspasoEntrada.Tables(0).Rows.Count > 0 Then
                bRes = True
            Else
                bRes = False
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

        Return bRes

    End Function

    Public Function SelectReporteDiferencias(ByVal Desde As Date, ByVal Hasta As Date) As DataSet

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaTraspasoEntrada As SqlDataAdapter
        Dim dsTraspasoEntrada As DataSet

        sccmdSelectAll = New SqlCommand
        scdaTraspasoEntrada = New SqlDataAdapter
        dsTraspasoEntrada = New DataSet("Diferencias")

        With sccmdSelectAll

            .Connection = sccnnConnection

            .CommandText = "[ReporteDiferenciasTraspasos]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New SqlParameter("@Desde", SqlDbType.DateTime, 8))
            .Parameters.Add(New SqlParameter("@Hasta", SqlDbType.DateTime, 8))

            .Parameters("@Desde").Value = Desde
            .Parameters("@Hasta").Value = Hasta

        End With

        scdaTraspasoEntrada.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            'Fill DataSet
            scdaTraspasoEntrada.Fill(dsTraspasoEntrada, "Diferencias")

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

    Public Sub Update(ByVal Traspaso As TraspasoEntrada, ByVal userSession As String, ByVal userName As String)

        'TODO: JHV - Implementar actualizacion de Traspaso
        'NOTE: Aqui actualizar el general del traspaso

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)
        Dim sccmdInsert As SqlCommand



        sccmdInsert = New SqlCommand

        With sccmdInsert

            .Connection = sccnnConnection

            .CommandText = "[TraspasoEntradaUpd]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.DateTime, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TraspasoID", System.Data.SqlDbType.VarChar, 6))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@UsuarioRecibe", System.Data.SqlDbType.VarChar, 12))

            'OutPut Parameter :
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaRecibe", SqlDbType.DateTime))
            .Parameters("@FechaRecibe").Direction = ParameterDirection.Output

        End With


        Try
            sccnnConnection.Open()

            With sccmdInsert
                'Assign Parameters Values
                .Parameters("@TraspasoID").Value = Traspaso.TraspasoID
                .Parameters("@UsuarioRecibe").Value = UCase(userSession)

                'Execute Command
                .ExecuteNonQuery()

                'Actualizar General Traspaso.
                Traspaso.TraspasoRecibidoEl = CType(.Parameters("@FechaRecibe").Value, Date)
                Traspaso.Status = "REC"
                Traspaso.AutorizadoPorID = UCase(userName)

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

    Public Sub UpdateArtNoLecturados(ByVal strFolioTraslado As String, ByVal dtDetalle As DataTable)

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                         GetConnectionString)
        Dim sccmdInsert As SqlCommand

        sccmdInsert = New SqlCommand

        With sccmdInsert

            .Connection = sccnnConnection

            .CommandText = "[ArtNoLecturadosDetalleUpd]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioTraslado", System.Data.SqlDbType.VarChar, 10))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodArticulo", System.Data.SqlDbType.VarChar, 30))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Talla", System.Data.SqlDbType.VarChar, 10))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Cantidad", System.Data.SqlDbType.Int, 4))

        End With


        Try
            Dim oRow As DataRow

            sccnnConnection.Open()

            With sccmdInsert

                For Each oRow In dtDetalle.Rows
                    'Assign Parameters Values
                    .Parameters("@FolioTraslado").Value = strFolioTraslado.Trim
                    .Parameters("@CodArticulo").Value = CStr(oRow!CodArticulo).Trim
                    .Parameters("@Talla").Value = CStr(oRow!Talla).Trim
                    .Parameters("@Cantidad").Value = CInt(oRow!Cantidad)

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

    End Sub

    Public Function UpdateFolioArtNoLecturados(ByVal strFolioTraslado As String, ByVal dtDetalle As DataTable) As String
        Dim respuesta As String = String.Empty
        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                         GetConnectionString)
        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand
        With sccmdInsert
            .Connection = sccnnConnection
            .CommandText = "[ControlArticulosNoLecturadosDetalleUpd]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioTraslado", System.Data.SqlDbType.VarChar, 10))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodArticulo", System.Data.SqlDbType.VarChar, 30))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodigoSAP", System.Data.SqlDbType.VarChar, 20))
        End With


        Try
            Dim oRow As DataRow

            sccnnConnection.Open()

            With sccmdInsert

                For Each oRow In dtDetalle.Rows
                    If (oRow!IDMENSAJE).ToString = "200" Then
                        'Assign Parameters Values
                        .Parameters("@FolioTraslado").Value = strFolioTraslado.Trim
                        .Parameters("@CodArticulo").Value = CStr(oRow!Material).Trim
                        .Parameters("@CodigoSAP").Value = CStr(oRow!ID_PR_AC).Trim

                        'Execute Command
                        .ExecuteNonQuery()
                    Else
                        respuesta += "Producto: " & CStr(oRow!MATERIAL).Trim & " no fue actualizado en SAP, Error: " & CStr(oRow!DESCRIPCION) & vbCrLf
                    End If

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
        Return respuesta
    End Function



    Public Sub UpdateArtNoLecturadosServer(ByVal strFolioTraslado As String, ByVal dtDetalle As DataTable)

        Dim sccnnConnection As New SqlConnection(strConnectionStringServer)
        Dim sccmdInsert As SqlCommand

        sccmdInsert = New SqlCommand

        With sccmdInsert

            .Connection = sccnnConnection

            .CommandText = "[ArtNoLecturadosDetalleUpd]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioTraslado", System.Data.SqlDbType.VarChar, 10))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodArticulo", System.Data.SqlDbType.VarChar, 30))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Talla", System.Data.SqlDbType.VarChar, 10))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Cantidad", System.Data.SqlDbType.Int, 4))

        End With


        Try
            Dim oRow As DataRow

            sccnnConnection.Open()

            With sccmdInsert

                For Each oRow In dtDetalle.Rows
                    'Assign Parameters Values
                    .Parameters("@FolioTraslado").Value = strFolioTraslado.Trim
                    .Parameters("@CodArticulo").Value = CStr(oRow!CodArticulo).Trim
                    .Parameters("@Talla").Value = CStr(oRow!Talla).Trim
                    .Parameters("@Cantidad").Value = CInt(oRow!Cantidad)

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

    End Sub

    'Public Sub UpdateInventario(ByVal TraspasoDetalle As DataSet, ByVal CodAlmacen As String)

    Public Function UpdateInventario(ByVal TraspasoTarget As TraspasoEntrada, ByVal TraspasoID As Integer, ByVal CanceladoECM As Boolean, ByVal EsConsignacion As Boolean) As Boolean

        'TODO: JHV - Implementar actualizacion de inventario aqui
        'NOTE: Aqui meter los articulos recibidos a inventario

        Dim odrArticulo As DataRow
        Dim oCatalogoArticuloMgr As New CatalogoArticuloManager(oParent.ApplicationContext)
        Dim oArticulo As Articulo

        Dim oTraspasoEntradaMgr As New TraspasosEntradaManager(oParent.ApplicationContext)
        'Dim oTraspasoEntrada As TraspasoEntrada

        Dim odsCatalogoCorridas As New DataSet
        Dim odrFiltroCorrida() As DataRow

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                                 DataStorageConfiguration.GetConnectionString)

        Dim sccmdUpdateInventario As SqlCommand
        sccmdUpdateInventario = New SqlCommand

        'oTraspasoEntrada = oTraspasoEntradaMgr.Load(TraspasoID)

        With sccmdUpdateInventario

            .Connection = sccnnConnection

            .CommandText = "[ExistenciasMovimientosIns]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodTipoMov", System.Data.SqlDbType.Int, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TipoMovimiento", System.Data.SqlDbType.VarChar, 1))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@StatusMov", System.Data.SqlDbType.VarChar, 1))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Destino", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Folio", System.Data.SqlDbType.Int, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodArticulo", System.Data.SqlDbType.VarChar, 20))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Descripcion", System.Data.SqlDbType.VarChar, 50))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Numero", System.Data.SqlDbType.VarChar, 10))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Total", System.Data.SqlDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(10, Byte), CType(2, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Apartados", System.Data.SqlDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(10, Byte), CType(2, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Defectuosos", System.Data.SqlDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(10, Byte), CType(2, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Promocion", System.Data.SqlDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(10, Byte), CType(2, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@VtasEspeciales", System.Data.SqlDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(10, Byte), CType(2, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Consignacion", System.Data.SqlDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(10, Byte), CType(2, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Transito", System.Data.SqlDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(10, Byte), CType(2, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodLinea", System.Data.SqlDbType.VarChar, 10))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodMarca", System.Data.SqlDbType.VarChar, 10))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodFamilia", System.Data.SqlDbType.VarChar, 10))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodUnidad", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodUso", System.Data.SqlDbType.VarChar, 8))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCategoria", System.Data.SqlDbType.VarChar, 10))
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


            For Each odrArticulo In TraspasoTarget.Detalle.Tables(0).Rows

                'Extraer la Información de cada Artículo.
                oArticulo = Nothing
                oArticulo = oCatalogoArticuloMgr.Load(CType(odrArticulo("Codigo"), String))

                'Obtener la corrida de cada Artículo.
                ''odrFiltroCorrida = odsCatalogoCorridas.Tables("CatalogoCorridas").Select("CodCorrida = '" & CType(odrArticulo("Corrida"), String) & "'")  '.GetType.ToString & "'")

                'Guardar en Existencias cada Artículo con sus respectivas corridas.
                Dim intNumTalla As Integer
                Dim intCantidadPorTalla As Integer

                ''For intNumTalla = 1 To 20

                ''intCantidadPorTalla = CType(odrArticulo("C" & Format(intNumTalla, "00")), Integer)
                intCantidadPorTalla = CType(odrArticulo("Cantidad"), Integer)

                If (intCantidadPorTalla > 0) Then

                    With sccmdUpdateInventario

                        'If (ValidarCantidad(intCantidadPorTalla, odrArticulo("Codigo"), CType(odrFiltroCorrida(0).Item("C" & Format(intNumTalla, "00")), Decimal)) = False) Then
                        '    MsgBox("La Cantidad disponible es Menor.", MsgBoxStyle.Exclamation, "DPTienda")
                        '    ebCantidad.Focus()
                        '    Exit Function
                        'End If

                        'Assign Parameters Values 
                        If CanceladoECM Then
                            .Parameters("@CodTipoMov").Value = 352
                        Else
                            .Parameters("@CodTipoMov").Value = 102
                        End If
                        .Parameters("@TipoMovimiento").Value = "E"
                        .Parameters("@StatusMov").Value = "A"

                        '.Parameters("@CodAlmacen").Value = oTraspasoEntrada.AlmacenDestinoID
                        '.Parameters("@Destino").Value = oTraspasoEntrada.AlmacenOrigenID

                        ''.Parameters("@CodAlmacen").Value = oTraspasoEntrada.AlmacenOrigenID
                        ''.Parameters("@Destino").Value = oTraspasoEntrada.AlmacenDestinoID

                        ''Revisar que voy a poner aqui
                        .Parameters("@Folio").Value = 0 '''TraspasoTarget.Folio
                        .Parameters("@FolioSAP").Value = "0"
                        '.Parameters("@CodAlmacen").Value = TraspasoTarget.AlmacenOrigenID
                        '.Parameters("@Destino").Value = TraspasoTarget.AlmacenDestinoID

                        .Parameters("@CodAlmacen").Value = TraspasoTarget.AlmacenDestinoID
                        .Parameters("@Destino").Value = TraspasoTarget.AlmacenOrigenID

                        .Parameters("@CodArticulo").Value = odrArticulo("Codigo")
                        .Parameters("@Descripcion").Value = odrArticulo("Descripcion")

                        ''.Parameters("@Numero").Value = CType(odrFiltroCorrida(0).Item("C" & Format(intNumTalla, "00")), Decimal)
                        .Parameters("@Numero").Value = CType(odrArticulo("TALLA"), String)

                        .Parameters("@Total").Value = intCantidadPorTalla
                        If EsConsignacion = False Then
                            .Parameters("@Consignacion").Value = 0
                        Else
                            .Parameters("@Consignacion").Value = intCantidadPorTalla
                        End If

                        .Parameters("@Apartados").Value = 0
                        .Parameters("@Defectuosos").Value = 0
                        .Parameters("@Promocion").Value = 0
                        .Parameters("@VtasEspeciales").Value = 0
                        '.Parameters("@Consignacion").Value = 0
                        .Parameters("@Transito").Value = 0

                        .Parameters("@CodLinea").Value = oArticulo.Codlinea
                        .Parameters("@CodMarca").Value = oArticulo.CodMarca
                        .Parameters("@CodFamilia").Value = oArticulo.CodFamilia
                        .Parameters("@CodUso").Value = oArticulo.CodUso
                        .Parameters("@CodCategoria").Value = Format(oArticulo.CodCategoria, "000")
                        .Parameters("@CodUnidad").Value = oArticulo.CodUnidadVta

                        '.Parameters("@Usuario").Value = oParent.ApplicationContext.Security.CurrentUser.Name
                        .Parameters("@Usuario").Value = Left(oParent.ApplicationContext.Security.CurrentUser.SessionLoginName.ToUpper, 12)

                        'Revisar que voy a poner aqui
                        .Parameters("@CostoUnit").Value = 0 '''odrArticulo("CostoUnit")
                        .Parameters("@PrecioUnit").Value = 0 '''odrArticulo("CostoUnit")

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

                End If
                ''Next

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

        sccmdUpdateInventario.Dispose()
        sccmdUpdateInventario = Nothing

        oCatalogoArticuloMgr = Nothing
        oArticulo = Nothing

        'oTraspasoEntrada = Nothing
        oTraspasoEntradaMgr = Nothing

        Return True

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

    Public Sub Sm_TraspasoEntradaDBF()

        Dim strPath As String = oParent.ApplicationContext.ApplicationConfiguration.RutaTraspasoEntrada


        If (Directory.Exists(strPath)) = False Then

            MsgBox("El Directorio " & strPath & " no Existe.", MsgBoxStyle.Exclamation, "DPTienda")
            Return

        End If


        ' Create a reference to the current directory.
        Dim Vl_objDirectory As New DirectoryInfo(strPath)

        ' Create an array representing the files in the current directory.
        Dim Al_objFiles As FileInfo() = Vl_objDirectory.GetFiles()

        ' Print out the names of the files in the current directory.
        Dim Vl_File As FileInfo
        Dim Vl_cnnODBC As New OdbcConnection("MaxBufferSize=2048;DSN=dBASE Files;PageTimeout=5;DefaultDir=" & strPath & ";" & _
                                             "DBQ=" & strPath & ";DriverId=533")
        Dim da As New OdbcDataAdapter
        Dim daDetalle As New OdbcDataAdapter
        Dim ds As New DataSet
        Dim pbNoProc As Boolean
        Dim oArticulo As Articulo
        Dim oCatalogoArticuloMgr As New CatalogoArticuloManager(oParent.ApplicationContext)
        Dim dsTraspasoCorrida As New DataSet
        Dim oTraspasoSalida As TraspasoSalida
        Dim dr As DataRow
        Dim drDetalle() As DataRow
        Dim drTmp As DataRow
        Dim pbEncCod As Boolean
        'Dim iCatProd As webproductos.Producto
        Dim pdsProd As DataSet

        pdsProd = New DataSet
        'iCatProd = New webproductos.Producto
        If Not oParent.ApplicationContext.ApplicationConfiguration.WSUrl = String.Empty Then
            'iCatProd.Url = oParent.ApplicationContext.ApplicationConfiguration.WSUrl.TrimEnd(CType("/", Char)) & "/Credito/Producto.asmx"
        End If
        da.SelectCommand = Vl_cnnODBC.CreateCommand
        daDetalle.SelectCommand = Vl_cnnODBC.CreateCommand

        For Each Vl_File In Al_objFiles

            If (VisualBasic.InStr(Vl_File.Name, "TRAG") > 0) Then

                'Verificar :
                Dim intDatePosition As Integer = Microsoft.VisualBasic.InStr(Vl_File.Name, "G") + 1
                Dim strDateTRA As String = Microsoft.VisualBasic.Mid(Vl_File.Name, intDatePosition, 4)
                Dim intPointPosition As Integer = Microsoft.VisualBasic.InStr(Vl_File.Name, ".")
                Dim strFileFormat As String = Microsoft.VisualBasic.Mid(Vl_File.Name, intPointPosition, 4)

                If File.Exists(strPath & "\" & "TRAD" & strDateTRA & strFileFormat) Then
                    File.Move(strPath & "\" & Vl_File.Name, strPath & "\TRAG" & strDateTRA & ".DBF")
                    File.Move(strPath & "\" & "TRAD" & strDateTRA & strFileFormat, strPath & "\TRAD" & strDateTRA & ".DBF")
                    Vl_cnnODBC.Open()

                    ds.Clear()

                    'Obtener los Registros del Archivo DBF.

                    'TRAG.

                    With da.SelectCommand
                        .CommandText = "SELECT * FROM TRAG" & strDateTRA
                        .CommandType = CommandType.Text
                    End With

                    da.Fill(ds, "TRAG" & strDateTRA)

                    'TRAD.

                    With daDetalle.SelectCommand
                        .CommandText = "SELECT * FROM TRAD" & strDateTRA & " ORDER BY Codigo,Talla;"
                        .CommandType = CommandType.Text
                    End With

                    daDetalle.Fill(ds, "TRAD" & strDateTRA)


                    With ds
                        .Relations.Add("TRAG_TRAD", .Tables("TRAG" & strDateTRA).Columns("Folio"), _
                                       .Tables("TRAD" & strDateTRA).Columns("Folio"))
                    End With



                    'Traspaso [General], Recorre TRAG.
                    For Each dr In ds.Tables("TRAG" & strDateTRA).Rows
                        If GetFolioPorRef(CType(dr.Item("FOLIO"), String), Format$(CType(dr.Item("SUC_ORIG"), Integer), "000"), Format$(CType(dr.Item("SUC_DST"), Integer), "000")) = 0 Then
                            drDetalle = dr.GetChildRows("TRAG_TRAD")

                            'Crear Tabla Temporal.
                            oTraspasoSalidaMgr.CrearTablaTmp()

                            'Traspaso [Detalle], Recorrer TRAD.


                            For Each drTmp In drDetalle

                                '1.- Introducir en Tabla Temporal.      

                                'Extraer la Información de cada Artículo.
                                oArticulo = Nothing
                                oArticulo = oCatalogoArticuloMgr.Load(CType(drTmp("Codigo"), String))
                                pbEncCod = True
                                If oArticulo Is Nothing Then
                                    Try
                                        'pdsProd = iCatProd.GetDetalle(CType(drTmp("Codigo"), String))
                                        'If pdsProd.Tables(0).Rows.Count = 0 Then
                                        '    pbEncCod = False
                                        'Else
                                        oArticulo = oCatalogoArticuloMgr.Create()
                                        With pdsProd.Tables(0).Rows(0)
                                            oArticulo.CodArticulo = CType(.Item("codigo"), String)
                                            oArticulo.CodArtProv = Right$(oArticulo.CodArticulo, oArticulo.CodArticulo.Length - 3)
                                            oArticulo.Descripcion = CType(.Item("descripcion"), String)
                                            'oArticulo.Color1 = CType(.Item("color"), String)
                                            'oArticulo.Color2 = CType(.Item("color"), String)
                                            'oArticulo.Color3 = CType(.Item("color"), String)
                                            oArticulo.Codlinea = CType(.Item("linea"), String)
                                            oArticulo.CodCorrida = CType(.Item("corrida"), String)
                                            oArticulo.CodCategoria = 1
                                            'oArticulo.CodPublicacion = "S5"
                                            oArticulo.CodFamilia = CType(.Item("familia"), String)
                                            oArticulo.CodUso = CType(.Item("uso"), String)
                                            oArticulo.CodMarca = CType(.Item("marca"), String)
                                            'oArticulo.CodStatusArticulo = CType(.Item("statuscomer"), String)
                                            'oArticulo.FecUltTemp = Now()
                                            'oArticulo.FecUltTempDip = Now()
                                            oArticulo.CostoProm = CType(.Item("costoprom"), Decimal)
                                            oArticulo.MargenUtilidad = CType(.Item("margenutilidad"), Decimal)
                                            oArticulo.PrecioVenta = CType(.Item("precioventa"), Decimal)
                                            oArticulo.Descuento = CType(.Item("descuento"), Decimal)
                                            oArticulo.PrecioOferta = CType(.Item("preciooferta"), Decimal)
                                            oArticulo.FechaOferta = Now.Today
                                            'oArticulo.FUO = Now.Today
                                            'oArticulo.FUC = Now.Today
                                            'oArticulo.CodProveedor1 = CType(.Item("codprov"), Integer)
                                            'If Not IsDBNull(.Item("codprov2")) Then
                                            'If CType(.Item("codprov2"), String) <> "" Then
                                            'oArticulo.CodProveedor2 = CType(.Item("codprov2"), Integer)
                                            'Else
                                            '    oArticulo.CodProveedor2 = CType(.Item("codprov"), Integer)
                                            'End If
                                            'End If
                                            oArticulo.CodUnidadCom = CType(.Item("unidadcompra"), String)
                                            oArticulo.CodUnidadVta = CType(.Item("unidadventa"), String)
                                            oArticulo.CodMonedaCom = CType(.Item("monedacompra"), Integer)
                                            oArticulo.CodMonedaVta = CType(.Item("monedaventa"), Integer)
                                            oArticulo.ImpCodBarra = CType(.Item("imprimeprecio"), Boolean)
                                            'oArticulo.Importado = CType(.Item("importado"), Boolean)
                                            'oArticulo.Ordenable = CType(.Item("ordenable"), Boolean)
                                            'oArticulo.CatalogoDIP = CType(.Item("DIP"), Boolean)
                                            'oArticulo.Usuario = CType(.Item("usuario"), String)
                                            'oArticulo.Fecha = CType(.Item("fecha"), Date)
                                            'oArticulo.StatusRegistro = True
                                            'oArticulo.CodNumTemporada = 2
                                            'oArticulo.Ano = Format$(oArticulo.Fecha.Year, "0000")
                                            oCatalogoArticuloMgr.Save(oArticulo)
                                        End With
                                        'End If
                                    Catch ex As Exception
                                        pbEncCod = False
                                    End Try
                                    If Not pbEncCod Then Exit For
                                End If
                                oTraspasoSalidaMgr.AgregarArticulo(oArticulo, CType(drTmp!Talla, String), CType(drTmp!Cantidad, Integer), (oArticulo.CostoProm * CType(drTmp!Cantidad, Integer)), CType(drTmp!Folio, Integer))
                            Next
                            If Not pbEncCod Then Exit For
                            '2.- Generar Corrida.
                            dsTraspasoCorrida = Nothing

                            dsTraspasoCorrida = oTraspasoSalidaMgr.GenerarTraspasoCorridaDBF("[RefCruzTraspasoDBF]")


                            '3.- Guardar Traspaso.

                            oTraspasoSalida = Nothing
                            oTraspasoSalida = oTraspasoSalidaMgr.Create

                            oTraspasoSalida.Referencia = CType(dr!Folio, String)

                            oTraspasoSalida.Observaciones = String.Empty

                            If IsDBNull(dr!Guia) = False Then
                                oTraspasoSalida.Guia = CType(dr!Guia, String)
                            Else
                                oTraspasoSalida.Guia = String.Empty
                            End If

                            oTraspasoSalida.Cargos = 0

                            oTraspasoSalida.SubTotal = CType(dr!Importe, Decimal)

                            oTraspasoSalida.TraspasoCreadoEl = CType(dr!Fecha, Date)

                            oTraspasoSalida.Status = "TRA"

                            oTraspasoSalida.AlmacenDestinoID = Format(CType(dr!Suc_Dst, Integer), "000")

                            oTraspasoSalida.AlmacenOrigenID = Format(CType(dr!Suc_Orig, Integer), "000")

                            oTraspasoSalida.TraspasoID = 0

                            oTraspasoSalida.Folio = String.Empty

                            oTraspasoSalida.Detalle = dsTraspasoCorrida


                            oTraspasoSalida.Save()
                        End If
                    Next
                    ds.Relations.Remove("TRAG_TRAD")
                    Vl_cnnODBC.Close()
                    If pbEncCod Then
                        'Eliminar Archivos.
                        File.Delete(strPath & "\TRAG" & strDateTRA & ".DBF")
                        File.Delete(strPath & "\TRAD" & strDateTRA & ".DBF")
                    Else
                        File.Move(strPath & "\" & "TRAG" & strDateTRA & ".DBF", strPath & "\TRAG" & strDateTRA & strFileFormat)
                        File.Move(strPath & "\" & "TRAD" & strDateTRA & ".dbf", strPath & "\TRAD" & strDateTRA & strFileFormat)
                    End If
                End If
            End If
        Next
        Al_objFiles = Vl_objDirectory.GetFiles("TRA*.*")
        If Al_objFiles.Length > 0 Then
            MsgBox("No se procesaron algunos archivos debido a que no se recibieron completos" & _
                    vbLf & ", existen folios repetidos o algunos artículos no se encuentran en el catálogo y no se pudieron actualizar", MsgBoxStyle.Information, "Obtener traspasos")

        End If

        ' Delte Files without process
        '</Delete>
        DeleteAllFiles()
        '<Delete/>

        da.Dispose()
        daDetalle.Dispose()
        dsTraspasoCorrida.Dispose()

        da = Nothing
        daDetalle = Nothing
        dsTraspasoCorrida = Nothing
        oArticulo = Nothing
        oCatalogoArticuloMgr = Nothing
        oTraspasoSalida = Nothing
        Vl_objDirectory = Nothing

    End Sub

    Private Sub DeleteAllFiles()

        ' Creamos referencia al directorio
        Dim objDirectory As New DirectoryInfo(oParent.ApplicationContext.ApplicationConfiguration.RutaTraspasoEntrada)

        ' Creamos arreglo para los archivos del directorio
        Dim objFiles As FileInfo() = objDirectory.GetFiles()

        ' Verificamos si existen archivos

        If objFiles.Length > 0 Then

            ' Archivo
            Dim oFile As FileInfo

            For Each oFile In objFiles

                oFile.Delete()

            Next

            oFile = Nothing

        End If

        objFiles = Nothing

        objDirectory = Nothing

    End Sub

#End Region

    Public Function SelectNombreAlmacen(ByVal strNombre As String) As String
        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)
        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader
        sccmdSelect = New SqlCommand
        Dim strDescrip As String

        With sccmdSelect
            .Connection = sccnnConnection
            .CommandText = "[TraspasoSel]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Almacen", System.Data.SqlDbType.VarChar, 4))
        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect
                'Assign Parameters Values
                .Parameters("@Almacen").Value = strNombre

                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    'Traspaso General :
                    With scdrReader

                        'oTraspasoEntrada.AlmacenOrigenID = .GetString(0).ToUpper
                        'oTraspasoEntrada.AlmacenDestinoID = .GetString(1).ToUpper
                        'oTraspasoEntrada.TransportistaID = .GetString(2)
                        'oTraspasoEntrada.TraspasoID = .GetInt32(3)
                        'oTraspasoEntrada.TraspasoCreadoEl = .GetDateTime(4)
                        'oTraspasoEntrada.MonedaID = .GetString(5).ToUpper
                        'oTraspasoEntrada.TotalBultos = .GetInt32(6)
                        'oTraspasoEntrada.Guia = .GetString(7).ToUpper
                        'oTraspasoEntrada.SubTotal = .GetDecimal(8)
                        'oTraspasoEntrada.Status = .GetString(9)
                        .Close()

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

        Return strDescrip

    End Function


    Public Function SelectAllPendientes() As DataSet

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

            .CommandText = "[TraspasoSelPendiente]"
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

    Public Function SelectDescripcion(ByVal strArticulo As String) As String


        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdrTraspasoEntrada As SqlDataReader
        Dim dsTraspasoEntrada As DataSet



        sccmdSelectAll = New SqlCommand


        With sccmdSelectAll

            .Connection = sccnnConnection

            .CommandText = "[TraspasoSelDescripcion]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodArticulo", System.Data.SqlDbType.VarChar, 18))

            .Parameters("@CodArticulo").Value = strArticulo

        End With


        Try

            sccnnConnection.Open()

            With sccmdSelectAll
                'Execute Command
                scdrTraspasoEntrada = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrTraspasoEntrada.Read()

                If (scdrTraspasoEntrada.HasRows) Then

                    'Traspaso General :
                    With scdrTraspasoEntrada

                        Return .GetString(0).ToUpper

                        .Close()

                    End With
                Else
                    Return ""
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

        'Return dsTraspasoEntrada

    End Function

    Public Function SelectInfoAjuste(ByVal strFolio As String) As DataSet

        'TODO: JHV - Implementar retorno de dataset con todos los traspasos.

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaAjusteTE As SqlDataAdapter
        Dim dsAjusteTE As DataSet



        sccmdSelectAll = New SqlCommand
        scdaAjusteTE = New SqlDataAdapter
        dsAjusteTE = New DataSet

        With sccmdSelectAll

            .Connection = sccnnConnection

            .CommandText = "[AjusteInfoTESel]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Folio", System.Data.SqlDbType.VarChar, 10))
            
            .Parameters("@Folio").Value = strFolio

        End With

        scdaAjusteTE.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            'Fill DataSet
            scdaAjusteTE.Fill(dsAjusteTE)

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

        Return dsAjusteTE

    End Function

    Public Function SelectTraspasosEntradasByDate(ByVal FechaDe As DateTime, ByVal FechaAl As DateTime) As DataSet
        Dim conexion As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString())
        Dim command As New SqlCommand("TraspasosEntradasInventarios", conexion)
        Dim adapter As SqlDataAdapter = Nothing
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

            .CommandText = "[TraspasoEntradaReporte]"
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

    Public Function GetFolioPorRef(ByVal Referencia As String, ByVal Almacen As String, ByVal Origen As String) As Long
        Dim pconBase As SqlClient.SqlConnection
        Dim pcmdTrasp As SqlClient.SqlCommand
        Dim drTrasp As SqlClient.SqlDataReader

        pconBase = New SqlClient.SqlConnection
        pcmdTrasp = New SqlClient.SqlCommand

        pconBase.ConnectionString = oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString()
        pconBase.Open()
        pcmdTrasp.Connection = pconBase
        pcmdTrasp.CommandType = CommandType.StoredProcedure

        pcmdTrasp.CommandText = "TraspasoSelxRef"
        pcmdTrasp.Parameters.Add("@Referencia", SqlDbType.VarChar, 6)
        pcmdTrasp.Parameters.Add("@Almacen", SqlDbType.VarChar, 3)
        pcmdTrasp.Parameters.Add("@Origen", SqlDbType.VarChar, 3)

        pcmdTrasp.Parameters("@Referencia").Value = Referencia
        pcmdTrasp.Parameters("@Almacen").Value = Almacen
        pcmdTrasp.Parameters("@Origen").Value = Origen

        drTrasp = pcmdTrasp.ExecuteReader(CommandBehavior.SingleRow)
        If drTrasp.HasRows Then
            drTrasp.Read()
            GetFolioPorRef = CType(drTrasp.GetValue(0), Long)
        Else
            GetFolioPorRef = 0
        End If
    End Function

    Public Function InsertarTraspaso(ByVal Traspaso As TraspasoEntrada, ByVal Responsable As String, ByVal NombreResponsable As String) As Integer

        Dim myTransaction As SqlClient.SqlTransaction
        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString())
        Dim Folio As Integer
        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand

        With sccmdInsert

            .Connection = sccnnConnection

            .CommandText = "[TraspasoEntradaIns]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Connection = sccnnConnection

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@IdTraspaso", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Output, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioSAP", System.Data.SqlDbType.VarChar, 10))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Origen", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Destino", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Trasportista", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime, 8))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Bultos", System.Data.SqlDbType.Int, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Guia", System.Data.SqlDbType.VarChar, 15))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TotalPiezas", System.Data.SqlDbType.Int, 1))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Responsable", System.Data.SqlDbType.VarChar, 20))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Recibido", System.Data.SqlDbType.DateTime, 8))


        End With

        Try

            sccnnConnection.Open()
            myTransaction = sccnnConnection.BeginTransaction()

            With sccmdInsert
                'Assign Parameters Values

                .Parameters("@FolioSAP").Value = Traspaso.FolioSAP
                .Parameters("@Origen").Value = Traspaso.AlmacenOrigenID
                .Parameters("@Destino").Value = Traspaso.AlmacenDestinoID
                .Parameters("@Trasportista").Value = Traspaso.TransportistaID
                .Parameters("@Fecha").Value = Traspaso.TraspasoCreadoEl
                .Parameters("@Bultos").Value = Traspaso.TotalBultos
                .Parameters("@Guia").Value = Traspaso.Guia
                '------------------------------------------------
                ' JNAVA (15.02.2016): Adatpacion para retail
                '------------------------------------------------
                Dim SumCantidad As Integer = 0
                For Each oRow As DataRow In Traspaso.Detalle.Tables(0).Rows
                    SumCantidad += CInt(oRow!Cantidad)
                Next
                .Parameters("@TotalPiezas").Value = SumCantidad 'CInt(Traspaso.Detalle.Tables(0).Compute("SUM(Cantidad)", "Cantidad > 0"))
                .Parameters("@Responsable").Value = Traspaso.AutorizadoPorID
                .Parameters("@Recibido").Value = Traspaso.TraspasoRecibidoEl

                'Execute Command
                sccmdInsert.Transaction = myTransaction

                .ExecuteNonQuery()


                Traspaso.Folio = CStr(.Parameters("@IdTraspaso").Value)

                'Posteriormente se recorre la tabla DefectuososD (Detalle) para hacer el insertado en la misma, 
                'recordar usar una transaion por si marca error los cambios no tenga efecto
                'Assign Other Values

            End With

            'Reset New State of Linea Object 

            'Insertando Detalle

            With sccmdInsert

                .Connection = sccnnConnection

                .CommandText = "[TraspasoEntradaDetalleIns]"
                .CommandType = System.Data.CommandType.StoredProcedure
                .Connection = sccnnConnection
                .Parameters.Clear()

                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@IdTraspaso", System.Data.SqlDbType.Int, 4))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodArticulo", System.Data.SqlDbType.VarChar, 20))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Descripcion", System.Data.SqlDbType.VarChar, 50))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Numero", System.Data.SqlDbType.VarChar, 4))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Cantidad", System.Data.SqlDbType.Int, 4))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Bulto", System.Data.SqlDbType.Int, 4))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioSAPMB01", System.Data.SqlDbType.VarChar, 10))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Responsable", System.Data.SqlDbType.VarChar, 20))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@NombreResp", System.Data.SqlDbType.VarChar, 50))

            End With

            'sccnnConnection.Open()
            With sccmdInsert
                'Assign Parameters Values

                For Each row As DataRow In Traspaso.Detalle.Tables(0).Rows
                    .Parameters("@IdTraspaso").Value = CInt(Traspaso.Folio)
                    .Parameters("@CodArticulo").Value = row("codigo")
                    .Parameters("@Descripcion").Value = row("descripcion")
                    .Parameters("@Numero").Value = row("Talla")
                    .Parameters("@Cantidad").Value = row("Cantidad")
                    .Parameters("@Bulto").Value = row("Bulto")
                    .Parameters("@FolioSAPMB01").Value = Traspaso.Referencia.Trim.PadLeft(10, Convert.ToChar("0"))
                    .Parameters("@Responsable").Value = Responsable.Trim
                    .Parameters("@NombreResp").Value = NombreResponsable.Trim
                    'Execute Command
                    .ExecuteNonQuery()
                Next

                'recordar usar una transaion por si marca error los cambios no tenga efecto

                myTransaction.Commit()

            End With

            sccnnConnection.Close()

            Return Folio

        Catch oSqlException As SqlException

            If sccnnConnection.State <> ConnectionState.Closed Then
                myTransaction.Rollback()
            End If


            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("El registro no pudo ser insertado debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If sccnnConnection.State <> ConnectionState.Closed Then
                myTransaction.Rollback()
            End If

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


    End Function

    Public Function InsertarTraspasoEntradaInServer(ByVal Traspaso As TraspasoEntrada, ByVal CodResponsable As String, ByVal NombreResponsable As String) As Integer

        Dim myTransaction As SqlClient.SqlTransaction
        Dim sccnnConnection As New SqlConnection(strConnectionStringServer)
        Dim Folio As Integer = 0
        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand

        With sccmdInsert

            .Connection = sccnnConnection

            .CommandText = "[TraspasoEntradaIns]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Connection = sccnnConnection

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@IdTraspaso", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Output, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioSAP", System.Data.SqlDbType.VarChar, 10))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Origen", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Destino", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Trasportista", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime, 8))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Bultos", System.Data.SqlDbType.Int, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Guia", System.Data.SqlDbType.VarChar, 15))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TotalPiezas", System.Data.SqlDbType.Int, 1))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Responsable", System.Data.SqlDbType.VarChar, 20))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@NombreResponsable", System.Data.SqlDbType.VarChar, 50))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Recibido", System.Data.SqlDbType.DateTime, 8))

        End With

        Try

            sccnnConnection.Open()
            myTransaction = sccnnConnection.BeginTransaction()

            With sccmdInsert
                'Assign Parameters Values

                .Parameters("@FolioSAP").Value = Traspaso.FolioSAP
                .Parameters("@Origen").Value = Traspaso.AlmacenOrigenID
                .Parameters("@Destino").Value = Traspaso.AlmacenDestinoID
                .Parameters("@Trasportista").Value = Traspaso.TransportistaID
                .Parameters("@Fecha").Value = Traspaso.TraspasoCreadoEl
                .Parameters("@Bultos").Value = Traspaso.TotalBultos
                .Parameters("@Guia").Value = Traspaso.Guia
                .Parameters("@TotalPiezas").Value = CInt(Traspaso.Detalle.Tables(0).Compute("SUM(Cantidad)", "Cantidad > 0"))
                .Parameters("@Responsable").Value = CodResponsable.Trim
                .Parameters("@NombreResponsable").Value = NombreResponsable.Trim
                .Parameters("@Recibido").Value = Traspaso.TraspasoRecibidoEl

                'Execute Command
                sccmdInsert.Transaction = myTransaction

                .ExecuteNonQuery()

                Traspaso.Folio = CStr(.Parameters("@IdTraspaso").Value)

                'Posteriormente se recorre la tabla DefectuososD (Detalle) para hacer el insertado en la misma, 
                'recordar usar una transaion por si marca error los cambios no tenga efecto
                'Assign Other Values

            End With

            'Reset New State of Linea Object 

            'Insertando Detalle

            With sccmdInsert

                .Connection = sccnnConnection

                .CommandText = "[TraspasoEntradaDetalleIns]"
                .CommandType = System.Data.CommandType.StoredProcedure
                .Connection = sccnnConnection
                .Parameters.Clear()

                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@IdTraspaso", System.Data.SqlDbType.Int, 4))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodArticulo", System.Data.SqlDbType.VarChar, 20))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Descripcion", System.Data.SqlDbType.VarChar, 50))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Numero", System.Data.SqlDbType.VarChar, 4))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Cantidad", System.Data.SqlDbType.Int, 4))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Bulto", System.Data.SqlDbType.Int, 4))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioSAPMB01", System.Data.SqlDbType.VarChar, 10))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Responsable", System.Data.SqlDbType.VarChar, 20))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@NombreResp", System.Data.SqlDbType.VarChar, 50))

            End With

            'sccnnConnection.Open()
            With sccmdInsert
                'Assign Parameters Values

                For Each row As DataRow In Traspaso.Detalle.Tables(0).Rows

                    .Parameters("@IdTraspaso").Value = CInt(Traspaso.Folio)
                    .Parameters("@CodArticulo").Value = row("codigo")
                    .Parameters("@Descripcion").Value = row("descripcion")
                    .Parameters("@Numero").Value = row("Talla")
                    .Parameters("@Cantidad").Value = row("Cantidad")
                    .Parameters("@Bulto").Value = row("Bulto")
                    .Parameters("@FolioSAPMB01").Value = Traspaso.Referencia.Trim.PadLeft(10, Convert.ToChar("0"))
                    .Parameters("@Responsable").Value = CodResponsable.Trim
                    .Parameters("@NombreResp").Value = NombreResponsable.Trim
                    'Execute Command
                    .ExecuteNonQuery()
                Next

                'recordar usar una transaion por si marca error los cambios no tenga efecto

                myTransaction.Commit()

            End With

            sccnnConnection.Close()

            Return Folio

        Catch oSqlException As SqlException

            If sccnnConnection.State <> ConnectionState.Closed Then
                myTransaction.Rollback()
            End If


            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("El registro no pudo ser insertado debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If sccnnConnection.State <> ConnectionState.Closed Then
                myTransaction.Rollback()
            End If

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


    End Function

#Region "Traspaso Entrada Virtual"

    Public Function GetTraspasosVirtual(ByVal Origen As String) As DataTable
        Dim dtTraspasos As New DataTable("Traspaso")
        Dim conexion As New SqlConnection(strConnectionStringServer)
        Dim command As New SqlCommand("TraspasoEntradaVirtualSelAll", conexion)
        Dim adapter As SqlDataAdapter = Nothing
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@Destino", Origen)
            adapter = New SqlDataAdapter(command)
            adapter.Fill(dtTraspasos)
            command.Dispose()
            conexion.Close()
        Catch ex As Exception
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            Throw New ApplicationException(ex.Message, ex)
        End Try
        Return dtTraspasos
    End Function

    Public Function NextFolioTraspasoEntradaVirtual(ByVal Destino As String) As Integer
        Dim folio As Integer
        Dim conexion As New SqlConnection(strConnectionStringServer)
        Dim command As New SqlCommand("NextFolioTraspasoEntradaVirtual", conexion)
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@Destino", Destino)
            folio = CInt(command.ExecuteScalar())
            command.Dispose()
            conexion.Close()
        Catch ex As Exception
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            Throw New ApplicationException(ex.Message, ex)
        End Try
        Return folio
    End Function

    Public Sub InsertarTraspasoEntradaVirtual(ByRef Traspaso As TraspasoEntrada, ByVal dtDetalle As DataTable)
        Dim conexion As New SqlConnection(strConnectionStringServer)
        Dim command As New SqlCommand("TranspasoEntradaVirtualIns", conexion)
        Dim ts As SqlTransaction = Nothing
        Dim traspasoid As SqlParameter = Nothing
        Try
            conexion.Open()
            ts = conexion.BeginTransaction()
            command.Transaction = ts
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@Origen", Traspaso.AlmacenOrigenID)
            command.Parameters.Add("@Destino", Traspaso.AlmacenDestinoID)
            command.Parameters.Add("@Usuario", Traspaso.AutorizadoPorID)
            command.Parameters.Add("@Observaciones", Traspaso.Observaciones)
            command.Parameters.Add("@Folio", Traspaso.Folio)
            command.Parameters.Add("@MovID", Traspaso.NumConsecutivo)
            traspasoid = New SqlParameter("@MovEntID", Traspaso.TraspasoID)
            traspasoid.Direction = ParameterDirection.InputOutput
            command.Parameters.Add(traspasoid)
            command.ExecuteNonQuery()
            Traspaso.TraspasoID = CInt(traspasoid.Value)
            command.Dispose()
            command.CommandText = "TraspasoEntradaDetalleVirtualIns"
            command.Transaction = ts
            command.Parameters.Clear()
            With command
                .Parameters.Add(New SqlParameter("@MovEntID", SqlDbType.Int))
                .Parameters.Add(New SqlParameter("@CajaID", SqlDbType.Int))
                .Parameters.Add(New SqlParameter("@Material", SqlDbType.VarChar))
                .Parameters.Add(New SqlParameter("@Descripcion", SqlDbType.VarChar))
                .Parameters.Add(New SqlParameter("@Talla", SqlDbType.VarChar))
                .Parameters.Add(New SqlParameter("@Cantidad", SqlDbType.Int))
                .Parameters.Add(New SqlParameter("@Costo", SqlDbType.Decimal))
            End With
            For Each row As DataRow In dtDetalle.Rows
                With command
                    .Parameters("@MovEntID").Value = Traspaso.TraspasoID
                    .Parameters("@CajaID").Value = CInt(row("CajaID"))
                    .Parameters("@Material").Value = CStr(row("Codigo"))
                    .Parameters("@Descripcion").Value = CStr(row("Descripcion"))
                    .Parameters("@Talla").Value = CStr(row("Talla"))
                    .Parameters("@Cantidad").Value = CInt(row("Lecturado"))
                    .Parameters("@Costo").Value = CDec(row("Costo"))
                    .ExecuteNonQuery()
                End With
            Next
            ts.Commit()
            command.Dispose()
            conexion.Close()
        Catch ex As Exception
            If conexion.State <> ConnectionState.Closed Then
                ts.Rollback()
                conexion.Close()
            End If
            Throw New ApplicationException(ex.Message, ex)
        End Try
    End Sub

    Public Function GetTraspasoEntradaSel(ByVal Folio As String) As TraspasoEntrada
        Dim ds As New DataSet
        Dim conexion As New SqlConnection(strConnectionStringServer)
        Dim command As New SqlCommand("TraspasoEntradaVirtualSel", conexion)
        Dim adapter As SqlDataAdapter = Nothing
        Dim oTraspasoE As New TraspasoEntrada(oParent)
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@Folio", Folio)
            adapter = New SqlDataAdapter(command)
            adapter.Fill(ds)
            For Each row As DataRow In ds.Tables(0).Rows
                With oTraspasoE
                    .TraspasoID = CInt(row("MovEntID"))
                    .AlmacenDestinoID = CStr(row("Destino"))
                    .AlmacenOrigenID = CStr(row("Origen"))
                    .TraspasoRecibidoEl = CDate(row("Fecha"))
                    .Observaciones = CStr(row("Observaciones"))
                    .Folio = CStr(row("FolioTraspaso"))
                    .FolioSAP = CStr(row("FolioSalida"))
                    .AutorizadoPorID = CStr(row("Usuario"))
                End With
            Next
            oTraspasoE.Detalle = ds
            command.Dispose()
            conexion.Close()
        Catch ex As Exception
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            Throw New ApplicationException(ex.Message, ex)
        End Try
        Return oTraspasoE
    End Function

    Public Function ExisteCajaTraspasoEntrada(ByVal folio As Integer, ByVal cajaID As Integer) As Integer
        Dim count As Integer = 0
        Dim conexion As New SqlConnection(strConnectionStringServer)
        Dim command As New SqlCommand("ExisteEnTraspasoEntrada", conexion)
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@Folio", folio)
            command.Parameters.Add("@CajaID", cajaID)
            count = CInt(command.ExecuteScalar())
            command.Dispose()
            conexion.Close()
        Catch ex As Exception
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            Throw New ApplicationException(ex.Message, ex)
        End Try
        Return count
    End Function

#End Region

#Region "Entrega y Recepcion de Mercancias"

    Public Function InsertarResguardo(ByVal AlmacenOrigen As String, ByVal AlmacenDestino As String, ByVal dtResguardo As DataTable) As Boolean
        Dim valido As Boolean = False
        Dim ts As SqlClient.SqlTransaction
        Dim conexion As New SqlConnection(strConnectionStringServer)
        Dim command As New SqlCommand("InsertarResguardo", conexion)
        Try
            conexion.Open()
            ts = conexion.BeginTransaction()
            command.Transaction = ts
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(New SqlParameter("@ResguardoID", SqlDbType.Int))
            command.Parameters.Add(New SqlParameter("@Origen", SqlDbType.VarChar))
            command.Parameters.Add(New SqlParameter("@Destino", SqlDbType.VarChar))
            command.Parameters.Add(New SqlParameter("@Codigo", SqlDbType.VarChar))
            command.Parameters.Add(New SqlParameter("@Numero", SqlDbType.VarChar))
            command.Parameters.Add(New SqlParameter("@Cantidad", SqlDbType.Decimal))
            command.Parameters.Add(New SqlParameter("@Orden", SqlDbType.VarChar))
            command.Parameters.Add(New SqlParameter("@Tipo", SqlDbType.VarChar))
            command.Parameters.Add(New SqlParameter("@FechaCreacion", SqlDbType.DateTime))
            command.Parameters.Add(New SqlParameter("@UsuarioCreacion", SqlDbType.VarChar))
            command.Parameters.Add(New SqlParameter("@UsuarioRegistro", SqlDbType.Int))
            command.Parameters.Add(New SqlParameter("@FechaAlta", SqlDbType.DateTime))
            command.Parameters.Add(New SqlParameter("@UsuarioModifico", SqlDbType.Int))
            command.Parameters.Add(New SqlParameter("@FechaModificacion", SqlDbType.DateTime))
            command.Parameters.Add(New SqlParameter("@Status", SqlDbType.Int))
            Dim strFecha As String = ""
            For Each row As DataRow In dtResguardo.Rows
                strFecha = CStr(row("AEDAT"))
                command.Parameters("@Origen").Value = AlmacenOrigen
                command.Parameters("@Destino").Value = AlmacenDestino
                command.Parameters("@Codigo").Value = CStr(row("MATNR"))
                command.Parameters("@Numero").Value = CStr(row("J_3ASIZE"))
                command.Parameters("@Cantidad").Value = CDec(row("QUANTITY"))
                command.Parameters("@Orden").Value = CStr(row("EBELN"))
                command.Parameters("@Tipo").Value = CStr(row("Tipo"))
                command.Parameters("@FechaCreacion").Value = New DateTime(CInt(strFecha.Substring(0, 4)), CInt(strFecha.Substring(4, 2)), CInt(strFecha.Substring(6, 2)))
                command.Parameters("@UsuarioCreacion").Value = CStr(row("ERNAM"))
                command.Parameters("@UsuarioRegistro").Value = oParent.ApplicationContext.Security.CurrentUser.ID
                command.Parameters("@FechaAlta").Value = CDate(row("FechaAlta"))
                command.Parameters("@UsuarioModifico").Value = Nothing
                command.Parameters("@FechaModificacion").Value = Nothing
                command.Parameters("@Status").Value = "1"
                command.ExecuteNonQuery()
            Next
            ts.Commit()
            command.Dispose()
            conexion.Close()
            valido = True
        Catch sql As SqlException
            If conexion.State <> ConnectionState.Closed Then
                ts.Rollback()
                conexion.Close()
            End If
            Throw New ApplicationException(sql.Message, sql)
        Catch ex As Exception
            If conexion.State <> ConnectionState.Closed Then
                ts.Rollback()
                conexion.Close()
            End If
            Throw New ApplicationException(ex.Message, ex)
        End Try
        Return valido
    End Function

    '------------------------------------------------------------------------------------------------------
    ' JNAVA (05.08.2015): Funcion para Obtener Resguardo por Orden de Compra
    '------------------------------------------------------------------------------------------------------
    Public Function ObtenerResguardosByOrdenCompra(ByVal OrdenCompra As String, ByVal Centro As String) As DataTable

        Dim sccnnConnection As New SqlConnection(strConnectionStringServer)
        Dim sccmdSelectAll As SqlCommand
        Dim scdaResguardo As SqlDataAdapter
        Dim dsResguardo As DataSet
        Dim dtResguardo As DataTable
        Dim bRes As Boolean = True

        sccmdSelectAll = New SqlCommand
        scdaResguardo = New SqlDataAdapter
        dsResguardo = New DataSet("Resguardo")

        With sccmdSelectAll

            .Connection = sccnnConnection

            .CommandText = "[GetResguardosByOrdenCompra]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New SqlParameter("@OrdenCompra", SqlDbType.VarChar, 10))
            .Parameters.Add(New SqlParameter("@Centro", SqlDbType.VarChar, 4))

            .Parameters("@OrdenCompra").Value = OrdenCompra
            .Parameters("@Centro").Value = Centro

        End With

        scdaResguardo.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            'Fill DataSet
            scdaResguardo.Fill(dsResguardo, "Resguardo")
            sccnnConnection.Close()

            dtResguardo = dsResguardo.Tables(0)

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

        Return dtResguardo

    End Function

    '------------------------------------------------------------------------------------------------------
    ' JNAVA (07.08.2015): Funcion para actualizar registros de Modificacion de Resguardo por Orden de Compra
    '------------------------------------------------------------------------------------------------------
    Public Function ActualizarResguardosByOrdenCompra(ByVal OrdenCompra As String) As DataTable

        Dim sccnnConnection As New SqlConnection(strConnectionStringServer)
        Dim sccmdUpdate As New SqlCommand
        Dim scdaResguardo As New SqlDataAdapter

        With sccmdUpdate

            .Connection = sccnnConnection

            .CommandText = "[UpdateResguardosByOrdenCompra]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New SqlParameter("@OrdenCompra", SqlDbType.VarChar, 10))
            .Parameters.Add(New SqlParameter("@UsuarioModifico", SqlDbType.Int))
            .Parameters.Add(New SqlParameter("@FechaModificacion", SqlDbType.DateTime))
            .Parameters.Add(New SqlParameter("@Status", SqlDbType.Int))

            .Parameters("@OrdenCompra").Value = OrdenCompra
            .Parameters("@UsuarioModifico").Value = oParent.ApplicationContext.Security.CurrentUser.ID
            .Parameters("@FechaModificacion").Value = Date.Now
            .Parameters("@Status").Value = "0"

        End With

        Try
            sccnnConnection.Open()

            With sccmdUpdate

                'Assign Parameters Values
                .Parameters("@OrdenCompra").Value = OrdenCompra

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

            Throw New ApplicationException(ex.Message, ex)

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

    End Function

    '------------------------------------------------------------------------------------------------------
    ' JNAVA (10.08.2015): Funcion para Obtener Resguardo para reporte general
    '------------------------------------------------------------------------------------------------------
    Public Function ObtenerReporteResguardos(ByVal Centro As String) As DataTable

        Dim sccnnConnection As New SqlConnection(strConnectionStringServer)
        Dim sccmdSelectAll As SqlCommand
        Dim scdaResguardo As SqlDataAdapter
        Dim dsResguardo As DataSet
        Dim dtResguardo As DataTable
        Dim bRes As Boolean = True

        sccmdSelectAll = New SqlCommand
        scdaResguardo = New SqlDataAdapter
        dsResguardo = New DataSet("Resguardo")

        With sccmdSelectAll

            .Connection = sccnnConnection

            .CommandText = "[GetResguardosByStatus]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New SqlParameter("@Centro", SqlDbType.VarChar, 4))
            .Parameters.Add(New SqlParameter("@Status", SqlDbType.Int))

            .Parameters("@Centro").Value = Centro
            .Parameters("@Status").Value = "1" 'Todos los activos
        End With

        scdaResguardo.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            'Fill DataSet
            scdaResguardo.Fill(dsResguardo, "Resguardo")
            sccnnConnection.Close()

            dtResguardo = dsResguardo.Tables(0)

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

        Return dtResguardo

    End Function

#End Region

#Region "Consignacion"

    Public Function SaveZdproPedido(ByVal zdppro As ZdproPedidos) As Boolean
        Dim valido As Boolean = False
        Dim conexion As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)
        Dim command As New SqlCommand("SaveDproPedidos", conexion)
        Dim IdPedido As New SqlParameter("@IdPedido", SqlDbType.Int)
        IdPedido.Direction = ParameterDirection.InputOutput
        IdPedido.Value = zdppro.IdPedido
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(IdPedido)
            command.Parameters.AddWithValue("@DocMaterial", zdppro.DocMaterial)
            command.Parameters.AddWithValue("@PedidoSAP", zdppro.PedidoSAP)
            command.Parameters.AddWithValue("@Proveedor", zdppro.Proveedor)
            command.Parameters.AddWithValue("@ProveedorDesc", zdppro.ProveedorDesc)
            command.Parameters.AddWithValue("@CodAlmacen", zdppro.CodAlmacen)
            command.Parameters.AddWithValue("@AlmacenDesc", zdppro.AlmacenDesc)
            command.Parameters.AddWithValue("@CodArticulo", zdppro.CodArticulo)
            command.Parameters.AddWithValue("@ArticuloDesc", zdppro.ArticuloDesc)
            command.Parameters.AddWithValue("@TipoArticulo", zdppro.TipoArticulo)
            command.Parameters.AddWithValue("@CantidadRecibida", zdppro.CantidadRecibida)
            command.Parameters.AddWithValue("@CantidadLecturada", zdppro.CantidadLecturada)
            command.Parameters.AddWithValue("@CodUpc", zdppro.CodUpc)
            command.Parameters.AddWithValue("@CodVendedor", zdppro.CodVendedor)
            command.Parameters.AddWithValue("@Responsable", zdppro.Responsable)
            command.Parameters.AddWithValue("@Referencia", zdppro.Referencia)
            command.Parameters.AddWithValue("@Serie", zdppro.Serie)
            command.Parameters.AddWithValue("@TotalPedido", zdppro.TotalPedido)
            command.Parameters.AddWithValue("@TotalRecibido", zdppro.TotalRecibido)
            command.Parameters.AddWithValue("@Fecha", zdppro.Fecha)
            command.Parameters.AddWithValue("@Tipo", zdppro.Tipo)
            command.ExecuteNonQuery()
            If zdppro.IdPedido = 0 Then
                zdppro.IdPedido = CInt(IdPedido.Value)
            End If
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

    Public Function SaveZdproPedido(ByVal lstZdpro As List(Of ZdproPedidos)) As Boolean
        Dim valido As Boolean = False
        Dim conexion As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)
        Dim command As New SqlCommand("SaveDproPedidos", conexion)
        Dim IdPedido As SqlParameter = Nothing
        Dim ts As System.Data.SqlClient.SqlTransaction = Nothing
        Try
            conexion.Open()
            ts = conexion.BeginTransaction()
            command.CommandType = CommandType.StoredProcedure
            command.Transaction = ts
            IdPedido = New SqlParameter("@IdPedido", SqlDbType.Int)
            IdPedido.Direction = ParameterDirection.InputOutput
            command.Parameters.Add(IdPedido)
            command.Parameters.Add(New SqlParameter("@Identificador", SqlDbType.VarChar))
            command.Parameters.Add(New SqlParameter("@DocMaterial", SqlDbType.VarChar))
            command.Parameters.Add(New SqlParameter("@PedidoSAP", SqlDbType.VarChar))
            command.Parameters.Add(New SqlParameter("@Proveedor", SqlDbType.VarChar))
            command.Parameters.Add(New SqlParameter("@ProveedorDesc", SqlDbType.VarChar))
            command.Parameters.Add(New SqlParameter("@CodAlmacen", SqlDbType.VarChar))
            command.Parameters.Add(New SqlParameter("@AlmacenDesc", SqlDbType.VarChar))
            command.Parameters.Add(New SqlParameter("@CodArticulo", SqlDbType.VarChar))
            command.Parameters.Add(New SqlParameter("@ArticuloDesc", SqlDbType.VarChar))
            command.Parameters.Add(New SqlParameter("@TipoArticulo", SqlDbType.VarChar))
            command.Parameters.Add(New SqlParameter("@CantidadRecibida", SqlDbType.Int))
            command.Parameters.Add(New SqlParameter("@CantidadLecturada", SqlDbType.Int))
            command.Parameters.Add(New SqlParameter("@CodUpc", SqlDbType.VarChar))
            command.Parameters.Add(New SqlParameter("@CodVendedor", SqlDbType.VarChar))
            command.Parameters.Add(New SqlParameter("@Responsable", SqlDbType.VarChar))
            command.Parameters.Add(New SqlParameter("@Referencia", SqlDbType.VarChar))
            command.Parameters.Add(New SqlParameter("@Serie", SqlDbType.VarChar))
            command.Parameters.Add(New SqlParameter("@TotalPedido", SqlDbType.Int))
            command.Parameters.Add(New SqlParameter("@TotalRecibido", SqlDbType.Int))
            command.Parameters.Add(New SqlParameter("@Sobrante", SqlDbType.Int))
            command.Parameters.Add(New SqlParameter("@Fecha", SqlDbType.DateTime))
            command.Parameters.Add(New SqlParameter("@Tipo", SqlDbType.VarChar))
            For Each zdpro As ZdproPedidos In lstZdpro
                IdPedido.Value = zdpro.IdPedido
                command.Parameters("@Identificador").Value = zdpro.Identificador
                command.Parameters("@DocMaterial").Value = zdpro.DocMaterial
                command.Parameters("@PedidoSAP").Value = zdpro.PedidoSAP
                command.Parameters("@Proveedor").Value = zdpro.Proveedor
                command.Parameters("@ProveedorDesc").Value = zdpro.ProveedorDesc
                command.Parameters("@CodAlmacen").Value = zdpro.CodAlmacen
                command.Parameters("@AlmacenDesc").Value = zdpro.AlmacenDesc
                command.Parameters("@CodArticulo").Value = zdpro.CodArticulo
                command.Parameters("@ArticuloDesc").Value = zdpro.ArticuloDesc
                command.Parameters("@TipoArticulo").Value = zdpro.TipoArticulo
                command.Parameters("@CantidadRecibida").Value = zdpro.CantidadRecibida
                command.Parameters("@CantidadLecturada").Value = zdpro.CantidadLecturada
                command.Parameters("@CodUpc").Value = zdpro.CodUpc
                command.Parameters("@CodVendedor").Value = zdpro.CodVendedor
                command.Parameters("@Responsable").Value = zdpro.Responsable
                command.Parameters("@Referencia").Value = zdpro.Referencia
                command.Parameters("@Serie").Value = zdpro.Serie
                command.Parameters("@TotalPedido").Value = zdpro.TotalPedido
                command.Parameters("@TotalRecibido").Value = zdpro.TotalRecibido
                command.Parameters("@Sobrante").Value = zdpro.Sobrante
                command.Parameters("@Fecha").Value = zdpro.Fecha
                command.Parameters("@Tipo").Value = zdpro.Tipo
                command.ExecuteNonQuery()
                zdpro.IdPedido = CInt(IdPedido.Value)
            Next
            ts.Commit()
            valido = True
        Catch sql As SqlException
            If conexion.State <> ConnectionState.Closed Then
                ts.Rollback()
                conexion.Close()
            End If
            Throw New ApplicationException(sql.Message, sql)
        Catch ex As Exception
            If conexion.State <> ConnectionState.Closed Then
                ts.Rollback()
                conexion.Close()
            End If
            Throw New ApplicationException(ex.Message, ex)
        End Try
        Return valido
    End Function

    Public Sub GetZdpproPedidoById(ByVal zdppro As ZdproPedidos)
        Dim conexion As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)
        Dim command As New SqlCommand("GetZdproPedidoById", conexion)
        Dim reader As SqlDataReader = Nothing
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.AddWithValue("GetZdproPedidoById", zdppro.IdPedido)
            reader = command.ExecuteReader()
            If reader.HasRows Then
                While reader.Read()
                    zdppro.DocMaterial = CStr(reader("DocMaterial"))
                    zdppro.PedidoSAP = CStr(reader("PedidoSAP"))
                    zdppro.Proveedor = CStr(reader("Proveedor"))
                    zdppro.ProveedorDesc = CStr(reader("ProveedorDesc"))
                    zdppro.CodAlmacen = CStr(reader("CodAlmacen"))
                    zdppro.AlmacenDesc = CStr(reader("AlmacenDesc"))
                    zdppro.CodArticulo = CStr(reader("CodArticulo"))
                    zdppro.ArticuloDesc = CStr(reader("ArticuloDesc"))
                    zdppro.TipoArticulo = CStr(reader("TipoArticulo"))
                    zdppro.CantidadRecibida = CInt(reader("CantidadRecibida"))
                    zdppro.CantidadLecturada = CInt(reader("CantidadLecturada"))
                    zdppro.CodUpc = CStr(reader("CodUpc"))
                    zdppro.CodVendedor = CStr(reader("CodVendedor"))
                    zdppro.Responsable = CStr(reader("Responsable"))
                    zdppro.Referencia = CStr(reader("Referencia"))
                    zdppro.Serie = CStr(reader("Serie"))
                    zdppro.TotalPedido = CInt(reader("TotalPedido"))
                    zdppro.TotalRecibido = CInt(reader("TotalRecibido"))
                    zdppro.Fecha = CDate(reader("Fecha"))
                    zdppro.Tipo = CStr(reader("Tipo"))
                End While
            End If
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

    Public Function SaveZequi(ByVal zequi As Zequi) As Boolean
        Dim valido As Boolean = False
        Dim conexion As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)
        Dim command As New SqlCommand("SaveZequi", conexion)
        Dim IdZequi As New SqlParameter("@IdZequi", SqlDbType.Int)
        IdZequi.Direction = ParameterDirection.InputOutput
        IdZequi.Value = zequi.IdZequi
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(IdZequi)
            command.Parameters.AddWithValue("@CodArticulo", zequi.CodArticulo)
            command.Parameters.AddWithValue("@Serie", zequi.Serie)
            command.Parameters.AddWithValue("@NoPedido", zequi.NoPedido)
            command.Parameters.AddWithValue("@CentroOrigen", zequi.CentroOrigen)
            command.Parameters.AddWithValue("@CentroDestino", zequi.CentroDestino)
            command.Parameters.AddWithValue("@Proveedor", zequi.Proveedor)
            command.Parameters.AddWithValue("@DocMaterial", zequi.DocMaterial)
            command.Parameters.AddWithValue("@ClaseMovimiento", zequi.ClaseMovimiento)
            command.Parameters.AddWithValue("@SOBKZ", zequi.SOBKZ)
            command.Parameters.AddWithValue("@SHKZG", zequi.SHKZG)
            command.Parameters.AddWithValue("@BEWTP", zequi.BEWTP)
            command.ExecuteNonQuery()
            If zequi.IdZequi = 0 Then
                zequi.IdZequi = CInt(IdZequi.Value)
            End If
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

    Public Function SaveZequi(ByVal lstZequi As List(Of Zequi)) As Boolean
        Dim valido As Boolean = False
        Dim conexion As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                            GetConnectionString)
        Dim command As New SqlCommand("SaveZequi", conexion)
        Dim ts As System.Data.SqlClient.SqlTransaction = Nothing
        Dim IdZequi As New SqlParameter("@IdZequi", SqlDbType.Int)
        IdZequi.Direction = ParameterDirection.InputOutput
        Try
            conexion.Open()
            ts = conexion.BeginTransaction()
            command.CommandType = CommandType.StoredProcedure
            command.Transaction = ts
            command.Parameters.Add(IdZequi)
            command.Parameters.Add(New SqlParameter("@CodArticulo", SqlDbType.VarChar))
            command.Parameters.Add(New SqlParameter("@Serie", SqlDbType.VarChar))
            command.Parameters.Add(New SqlParameter("@NoPedido", SqlDbType.VarChar))
            command.Parameters.Add(New SqlParameter("@CentroOrigen", SqlDbType.VarChar))
            command.Parameters.Add(New SqlParameter("@CentroDestino", SqlDbType.VarChar))
            command.Parameters.Add(New SqlParameter("@Proveedor", SqlDbType.VarChar))
            command.Parameters.Add(New SqlParameter("@DocMaterial", SqlDbType.VarChar))
            command.Parameters.Add(New SqlParameter("@ClaseMovimiento", SqlDbType.VarChar))
            command.Parameters.Add(New SqlParameter("@SOBKZ", SqlDbType.VarChar))
            command.Parameters.Add(New SqlParameter("@SHKZG", SqlDbType.VarChar))
            command.Parameters.Add(New SqlParameter("@BEWTP", SqlDbType.VarChar))
            For Each zequi As Zequi In lstZequi
                IdZequi.Value = zequi.IdZequi
                command.Parameters("@CodArticulo").Value = zequi.CodArticulo
                command.Parameters("@Serie").Value = zequi.Serie
                command.Parameters("@NoPedido").Value = zequi.NoPedido
                command.Parameters("@CentroOrigen").Value = zequi.CentroOrigen
                command.Parameters("@CentroDestino").Value = zequi.CentroDestino
                command.Parameters("@Proveedor").Value = zequi.Proveedor
                command.Parameters("@DocMaterial").Value = zequi.DocMaterial
                command.Parameters("@ClaseMovimiento").Value = zequi.ClaseMovimiento
                command.Parameters("@SOBKZ").Value = zequi.SOBKZ
                command.Parameters("@SHKZG").Value = zequi.SHKZG
                command.Parameters("@BEWTP").Value = zequi.BEWTP
                command.ExecuteNonQuery()
                'zequi.IdZequi = CInt(IdZequi.Value)
            Next
            ts.Commit()
            command.Dispose()
            conexion.Close()
            valido = True
        Catch sql As SqlException
            If conexion.State <> ConnectionState.Closed Then
                ts.Rollback()
                conexion.Close()
            End If
            Throw New ApplicationException(sql.Message, sql)
        Catch ex As Exception
            If conexion.State <> ConnectionState.Closed Then
                ts.Rollback()
                conexion.Close()
            End If
            Throw New ApplicationException(ex.Message, ex)
        End Try
        Return valido
    End Function

    Public Sub GetZequiById(ByVal zequi As Zequi)
        Dim conexion As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)
        Dim command As New SqlCommand("GetZequiById", conexion)
        Dim reader As SqlDataReader = Nothing
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.AddWithValue("@IdZequi", zequi.IdZequi)
            reader = command.ExecuteReader()
            If reader.HasRows Then
                While reader.Read()
                    zequi.IdZequi = CInt(reader("IdZequi"))
                    zequi.CodArticulo = CStr(reader("CodArticulo"))
                    zequi.Serie = CStr(reader("Serie"))
                    zequi.NoPedido = CStr(reader("NoPedido"))
                    zequi.CentroOrigen = CStr(reader("CentroOrigen"))
                    zequi.CentroDestino = CStr(reader("CentroDestino"))
                    zequi.Proveedor = CStr(reader("Proveedor"))
                    zequi.DocMaterial = CStr(reader("DocMaterial"))
                    zequi.ClaseMovimiento = CStr(reader("ClaseMovimiento"))
                    zequi.SOBKZ = CStr(reader("SOBKZ"))
                    zequi.SHKZG = CStr(reader("SHKZG"))
                    zequi.BEWTP = CStr(reader("BEWTP"))
                End While
            End If
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

    Public Function GetZequiByOption(ByVal Opcion As Integer, ByVal Valor As String) As DataTable
        Dim dtZequi As New DataTable()
        Dim conexion As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)
        Dim command As New SqlCommand("GetZequiByOption", conexion)
        Dim adapter As SqlDataAdapter = Nothing
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.AddWithValue("@Option", Opcion)
            command.Parameters.AddWithValue("@Valor", Valor)
            adapter = New SqlDataAdapter(command)
            adapter.Fill(dtZequi)
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
        Return dtZequi
    End Function

    Public Function GetZequi(ByVal CodArticulo As String, ByVal Serie As String) As Zequi
        Dim zequi As New Zequi(Me.oParent)
        Dim conexion As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)
        Dim command As New SqlCommand("GetZequi", conexion)
        Dim reader As SqlDataReader = Nothing
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.AddWithValue("@CodArticulo", CodArticulo)
            command.Parameters.AddWithValue("@Serie", Serie)
            reader = command.ExecuteReader()
            If reader.HasRows Then
                While reader.Read()
                    zequi.IdZequi = CInt(reader("IdZequi"))
                    zequi.CodArticulo = CStr(reader("CodArticulo"))
                    zequi.Serie = CStr(reader("Serie"))
                    zequi.NoPedido = CStr(reader("NoPedido"))
                    zequi.CentroOrigen = CStr(reader("CentroOrigen"))
                    zequi.CentroDestino = CStr(reader("CentroDestino"))
                    zequi.Proveedor = CStr(reader("Proveedor"))
                    zequi.DocMaterial = CStr(reader("DocMaterial"))
                    zequi.ClaseMovimiento = CStr(reader("ClaseMovimiento"))
                    zequi.SOBKZ = CStr(reader("SOBKZ"))
                    zequi.SHKZG = CStr(reader("SHKZG"))
                    zequi.BEWTP = CStr(reader("BEWTP"))
                End While
            End If
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
        Return zequi
    End Function

    Public Function GetZdproPedido(ByVal Tipo As String) As DataTable
        Dim dtZdppro As New DataTable
        Dim conexion As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)
        Dim command As New SqlCommand("GetZdpproPedido", conexion)
        Dim adapter As SqlDataAdapter = Nothing
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.AddWithValue("@Tipo", Tipo)
            adapter = New SqlDataAdapter(command)
            adapter.Fill(dtZdppro)
            command.Dispose()
            conexion.Close()
            Dim Identificador As String = ""
            For i As Integer = dtZdppro.Rows.Count - 1 To 0 Step -1
                If IsDBNull(dtZdppro.Rows(i)("Identificador")) = False Then
                    If CStr(dtZdppro.Rows(i)("Identificador")) <> Identificador Then
                        Identificador = CStr(dtZdppro.Rows(i)("Identificador"))
                    Else
                        dtZdppro.Rows.RemoveAt(i)
                        dtZdppro.AcceptChanges()
                    End If
                End If
            Next
            'For Each row As DataRow In dtZdppro.Rows
            '    If CStr(row("Identificador")).Trim() <> Identificador Then
            '        Identificador = CStr(row("Identificador"))
            '    Else

            '    End If
            'Next
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
        Return dtZdppro
    End Function

    Public Function GetZdpproPedidoByPedidoSAP(ByVal PedidoSAP As String, ByVal Identificador As String) As DataTable
        Dim dtZdpro As New DataTable()
        Dim conexion As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)
        Dim command As New SqlCommand("GetZdproPedidoByPedidoSAP", conexion)
        Dim adapter As SqlDataAdapter = Nothing
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.AddWithValue("@PedidoSAP", PedidoSAP)
            command.Parameters.AddWithValue("@Identificador", Identificador)
            adapter = New SqlDataAdapter(command)
            adapter.Fill(dtZdpro)
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
        Return dtZdpro
    End Function

    Public Function ActualizarDocumentoEntradaMercancia(ByVal TraspasoId As Integer, ByVal Mblnr As String) As Boolean
        Dim valido As Boolean = False
        Dim conexion As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)
        Dim command As New SqlCommand("UpdateFolioTraspasoEntrada", conexion)
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
