
Imports System.Data.SqlClient
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos
Imports DportenisPro.DPTienda.ApplicationUnits.Clientes
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU
Imports System.DBNull



Public Class ContratoDataGateway

    Private oParent As ContratoManager


#Region "Constructors / Destructors"

    Public Sub New(ByVal Parent As ContratoManager)
        oParent = Parent
    End Sub

#End Region



#Region "Properties"

    Public Property Parent() As ContratoManager
        Get
            Return oParent
        End Get
        Set(ByVal Value As ContratoManager)
            oParent = Value
        End Set
    End Property

#End Region



#Region "Métodos"

    Public Sub ActualizaDOCNUMFB01xFolioAbono(ByVal ApartadoID As Integer, ByVal DOCNUMFB01 As String)

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                                 DataStorageConfiguration.GetConnectionString)

        Dim sccmdUpdate As SqlCommand
        sccmdUpdate = New SqlCommand

        With sccmdUpdate

            .Connection = sccnnConnection
            .CommandText = "[AbonosApartadosFB01UpdXFolioAbono]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@AbonoApartadoID", System.Data.SqlDbType.Int, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@DocNumFB01", System.Data.SqlDbType.VarChar, 10))


        End With

        Try

            sccnnConnection.Open()

            With sccmdUpdate
                'Assign Parameters Values
                .Parameters("@AbonoApartadoID").Value = ApartadoID
                .Parameters("@DocNumFB01").Value = DOCNUMFB01

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


        sccmdUpdate.Dispose()
        sccmdUpdate = Nothing

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

    End Sub

    Public Function DivisionSel() As String

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[ZPP_COBRANZASSelGSBERByWerks]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Almacen", System.Data.SqlDbType.VarChar, 4))

        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect
                'Assign Parameters Values
                .Parameters("@Almacen").Value = oParent.ApplicationContext.ApplicationConfiguration.Almacen

                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    With scdrReader

                        Return .GetString(0)

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



    Public Function [SelectByID](ByVal ContratoID As Integer) As Contrato

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        Dim dsDataSet As DataSet
        dsDataSet = New DataSet("Apartados")

        Dim oContrato As New Contrato(oParent)



        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[ApartadosSelByID]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ApartadoID", System.Data.SqlDbType.Int))


        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect
                'Assign Parameters Values
                .Parameters("@ApartadoID").Value = ContratoID

                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    'Traspaso General :
                    With scdrReader

                        oContrato.ID = .GetInt32(0)
                        oContrato.FolioApartado = .GetInt32(1)
                        oContrato.PlayerID = .GetString(2)
                        oContrato.ClienteID = .GetString(3)
                        oContrato.ImporteTotal = .GetDecimal(4)
                        oContrato.Saldo = .GetDecimal(5)
                        oContrato.DescuentoTotal = .GetDecimal(6)

                        If (IsDBNull(.Item(7)) = False) Then
                            oContrato.TipoDescuentoID = .GetString(7)
                        Else
                            oContrato.TipoDescuentoID = String.Empty
                        End If

                        oContrato.IVA = .GetDecimal(8)
                        oContrato.Entregada = .GetString(9)
                        oContrato.ComentarioDesc = .GetString(10)
                        oContrato.Usuario = .GetString(11)
                        oContrato.Fecha = .GetDateTime(12)
                        oContrato.StatusRegistro = .GetBoolean(13)

                        oContrato.CodCaja = .GetString(14)
                        oContrato.ContratoSAP = .GetString(15)


                        .Close()

                    End With


                    Dim scdaAdapter As New SqlDataAdapter

                    sccmdSelect.Dispose()
                    sccmdSelect = Nothing

                    sccmdSelect = New SqlCommand

                    With sccmdSelect

                        .Connection = sccnnConnection

                        .CommandText = "[ApartadosDetalleSel]"
                        .CommandType = System.Data.CommandType.StoredProcedure

                        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
                        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ApartadoID", System.Data.SqlDbType.Int))

                        .Parameters("@ApartadoID").Value = ContratoID

                    End With

                    scdaAdapter.SelectCommand = sccmdSelect
                    scdaAdapter.Fill(dsDataSet, "ContratoDetalle")

                    oContrato.Detalle = dsDataSet

                    dsDataSet.Dispose()
                    sccmdSelect.Dispose()
                    scdaAdapter.Dispose()

                    dsDataSet = Nothing
                    sccmdSelect = Nothing
                    scdaAdapter = Nothing

                    oContrato.ResetFlagNew()
                    oContrato.ResetFlagDirty()

                Else
                    oContrato = Nothing
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

        Return oContrato

    End Function

    Public Function [Select](ByVal ContratoID As Integer) As Contrato

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        Dim dsDataSet As DataSet
        dsDataSet = New DataSet("Apartados")

        Dim oContrato As New Contrato(oParent)



        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[ApartadosSel]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ApartadoID", System.Data.SqlDbType.Int))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar, 4))

        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect
                'Assign Parameters Values
                .Parameters("@ApartadoID").Value = ContratoID
                .Parameters("@CodCaja").Value = oParent.ApplicationContext.ApplicationConfiguration.NoCaja

                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    'Traspaso General :
                    With scdrReader

                        oContrato.ID = .GetInt32(0)
                        oContrato.FolioApartado = .GetInt32(1)
                        oContrato.PlayerID = .GetString(2)
                        oContrato.ClienteID = .GetString(3)
                        oContrato.ImporteTotal = .GetDecimal(4)
                        oContrato.Saldo = .GetDecimal(5)
                        oContrato.DescuentoTotal = .GetDecimal(6)

                        If (IsDBNull(.Item(7)) = False) Then
                            oContrato.TipoDescuentoID = .GetString(7)
                        Else
                            oContrato.TipoDescuentoID = String.Empty
                        End If

                        oContrato.IVA = .GetDecimal(8)
                        oContrato.Entregada = .GetString(9)
                        oContrato.ComentarioDesc = .GetString(10)
                        oContrato.Usuario = .GetString(11)
                        oContrato.Fecha = .GetDateTime(12)
                        oContrato.StatusRegistro = CBool(scdrReader("StatusRegistro"))

                        oContrato.CodCaja = .GetString(14)
                        oContrato.ContratoSAP = .GetString(15)
                        oContrato.Referencia = CStr(scdrReader("Referencia"))


                        .Close()

                    End With


                    Dim scdaAdapter As New SqlDataAdapter

                    sccmdSelect.Dispose()
                    sccmdSelect = Nothing

                    sccmdSelect = New SqlCommand

                    With sccmdSelect

                        .Connection = sccnnConnection

                        .CommandText = "[ApartadosDetalleSel]"
                        .CommandType = System.Data.CommandType.StoredProcedure

                        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
                        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ApartadoID", System.Data.SqlDbType.Int))

                        .Parameters("@ApartadoID").Value = ContratoID

                    End With

                    scdaAdapter.SelectCommand = sccmdSelect
                    scdaAdapter.Fill(dsDataSet, "ContratoDetalle")

                    oContrato.Detalle = dsDataSet

                    dsDataSet.Dispose()
                    sccmdSelect.Dispose()
                    scdaAdapter.Dispose()

                    dsDataSet = Nothing
                    sccmdSelect = Nothing
                    scdaAdapter = Nothing

                    oContrato.ResetFlagNew()
                    oContrato.ResetFlagDirty()

                Else
                    oContrato = Nothing
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

        Return oContrato

    End Function



    Public Function [SelectFolioApartado](ByVal ContratoID As Integer) As Contrato

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        Dim dsDataSet As DataSet
        dsDataSet = New DataSet("Apartados")

        Dim oContrato As New Contrato(oParent)



        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[ApartadosSelFolioApartado]"
            .CommandType = System.Data.CommandType.StoredProcedure

            '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@ApartadoID", System.Data.SqlDbType.Int))

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioApartado", System.Data.SqlDbType.Int, 4))

        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect
                'Assign Parameters Values
                .Parameters("@FolioApartado").Value = ContratoID

                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    'Traspaso General :
                    With scdrReader

                        If (IsDBNull(.Item(0)) = False) Then
                            oContrato.ID = .GetInt32(0)
                        End If

                        If (IsDBNull(.Item(1)) = False) Then
                            oContrato.FolioApartado = .GetInt32(1)
                        End If

                        If (IsDBNull(.Item(2)) = False) Then
                            oContrato.PlayerID = .GetString(2)
                        End If

                        If (IsDBNull(.Item(3)) = False) Then
                            oContrato.ClienteID = .GetString(3)
                        End If

                        If (IsDBNull(.Item(4)) = False) Then
                            oContrato.ImporteTotal = .GetDecimal(4)
                        End If

                        If (IsDBNull(.Item(5)) = False) Then
                            oContrato.Saldo = .GetDecimal(5)
                        End If

                        If (IsDBNull(.Item(6)) = False) Then
                            oContrato.DescuentoTotal = .GetDecimal(6)
                        End If

                        If (IsDBNull(.Item(7)) = False) Then
                            oContrato.TipoDescuentoID = .GetString(7)
                        Else
                            oContrato.TipoDescuentoID = String.Empty
                        End If

                        If (IsDBNull(.Item(8)) = False) Then
                            oContrato.IVA = .GetDecimal(8)
                        End If

                        If (IsDBNull(.Item(9)) = False) Then
                            oContrato.Entregada = .GetString(9)
                        End If

                        If (IsDBNull(.Item(10)) = False) Then
                            oContrato.ComentarioDesc = .GetString(10)
                        End If

                        If (IsDBNull(.Item(11)) = False) Then
                            oContrato.Usuario = .GetString(11)
                        End If


                        If (IsDBNull(.Item(12)) = False) Then
                            oContrato.Fecha = .GetDateTime(12)
                        End If

                        If (IsDBNull(.Item(13)) = False) Then
                            oContrato.StatusRegistro = .GetBoolean(13)
                        End If

                        '-----------------------------------------------------------------------
                        ' JNAVA (12.02.2016): Se agrego la referencia por Retail
                        '-----------------------------------------------------------------------
                        If (IsDBNull(.Item(14)) = False) Then
                            oContrato.Referencia = .GetString(14)
                        End If

                        .Close()

                    End With


                    'Traspaso Corrida [GRID] :

                    Dim scdaAdapter As New SqlDataAdapter

                    sccmdSelect.Dispose()
                    sccmdSelect = Nothing

                    sccmdSelect = New SqlCommand

                    With sccmdSelect

                        .Connection = sccnnConnection

                        .CommandText = "[ApartadosDetalleSel]"
                        .CommandType = System.Data.CommandType.StoredProcedure

                        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
                        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ApartadoID", System.Data.SqlDbType.Int))

                        .Parameters("@ApartadoID").Value = oContrato.ID 'ContratoID

                    End With

                    scdaAdapter.SelectCommand = sccmdSelect
                    scdaAdapter.Fill(dsDataSet, "ContratoDetalle")

                    oContrato.Detalle = dsDataSet

                    dsDataSet.Dispose()
                    sccmdSelect.Dispose()
                    scdaAdapter.Dispose()

                    dsDataSet = Nothing
                    sccmdSelect = Nothing
                    scdaAdapter = Nothing

                    oContrato.ResetFlagNew()
                    oContrato.ResetFlagDirty()

                Else
                    oContrato = Nothing
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

        Return oContrato

    End Function



    Public Function SelectApartadoFolioCaja(ByVal ContratoID As Integer, ByVal CodCaja As String) As Contrato

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        Dim dsDataSet As DataSet
        dsDataSet = New DataSet("Apartados")

        Dim oContrato As New Contrato(oParent)



        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[ApartadosSelFolioCaja]"
            .CommandType = System.Data.CommandType.StoredProcedure

            '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@ApartadoID", System.Data.SqlDbType.Int))

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioApartado", System.Data.SqlDbType.Int, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar, 2))

        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect
                'Assign Parameters Values
                .Parameters("@FolioApartado").Value = ContratoID
                .Parameters("@CodCaja").Value = CodCaja

                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    'Traspaso General :
                    With scdrReader

                        oContrato.ID = .GetInt32(0)
                        oContrato.FolioApartado = .GetInt32(1)
                        oContrato.PlayerID = .GetString(2)
                        oContrato.ClienteID = .GetString(3)
                        oContrato.ImporteTotal = .GetDecimal(4)
                        oContrato.Saldo = .GetDecimal(5)
                        oContrato.DescuentoTotal = .GetDecimal(6)

                        If (IsDBNull(.Item(7)) = False) Then
                            oContrato.TipoDescuentoID = .GetString(7)
                        Else
                            oContrato.TipoDescuentoID = String.Empty
                        End If

                        oContrato.IVA = .GetDecimal(8)
                        oContrato.Entregada = .GetString(9)


                        If (IsDBNull(.Item(10)) = False) Then
                            oContrato.ComentarioDesc = .GetString(10)
                        Else
                            oContrato.ComentarioDesc = String.Empty
                        End If

                        oContrato.Usuario = .GetString(11)
                        oContrato.Fecha = .GetDateTime(12)
                        oContrato.StatusRegistro = .GetBoolean(13)
                        oContrato.CodCaja = .GetString(.GetOrdinal("CodCaja"))
                        oContrato.Referencia = CStr(scdrReader("Referencia"))

                        .Close()

                    End With


                    'Traspaso Corrida [GRID] :

                    Dim scdaAdapter As New SqlDataAdapter

                    sccmdSelect.Dispose()
                    sccmdSelect = Nothing

                    sccmdSelect = New SqlCommand

                    With sccmdSelect

                        .Connection = sccnnConnection

                        .CommandText = "[ApartadosDetalleSel]"
                        .CommandType = System.Data.CommandType.StoredProcedure

                        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
                        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ApartadoID", System.Data.SqlDbType.Int))

                        .Parameters("@ApartadoID").Value = oContrato.ID 'ContratoID

                    End With

                    scdaAdapter.SelectCommand = sccmdSelect
                    scdaAdapter.Fill(dsDataSet, "ContratoDetalle")

                    oContrato.Detalle = dsDataSet

                    dsDataSet.Dispose()
                    sccmdSelect.Dispose()
                    scdaAdapter.Dispose()

                    dsDataSet = Nothing
                    sccmdSelect = Nothing
                    scdaAdapter = Nothing

                    oContrato.ResetFlagNew()
                    oContrato.ResetFlagDirty()

                Else
                    oContrato = Nothing
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

        Return oContrato

    End Function



    Private Function Fm_bolValidarContrato(ByVal dsContratoDetalle As DataSet) As Boolean

        Dim odrArticulo As DataRow
        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                                 DataStorageConfiguration.GetConnectionString)

        Try
            sccnnConnection.Open()

            For Each odrArticulo In dsContratoDetalle.Tables(0).Rows

                With odrArticulo

                    If (ValidarCantidadArticulo(.Item("Cantidad"), .Item("CodArticulo"), .Item("Numero")) = False) Then

                        MsgBox("La Cantidad disponible del Artículo " & .Item("CodArticulo") & " es menor.", MsgBoxStyle.Exclamation, "DPTienda")

                        sccnnConnection.Close()
                        sccnnConnection.Dispose()
                        sccnnConnection = Nothing

                        Exit Function

                    End If

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



    Public Sub Insert(ByVal pContrato As Contrato)

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                                 DataStorageConfiguration.GetConnectionString)



        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand

        '<Validación Apartados>
        If (Fm_bolValidarContrato(pContrato.Detalle) = False) Then
            Exit Sub
        End If
        '</Validación Apartados>


        With sccmdInsert

            .Connection = sccnnConnection

            .CommandText = "[ApartadosIns]"
            .CommandType = System.Data.CommandType.StoredProcedure

            '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioApartado", System.Data.SqlDbType.Int))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodVendedor", System.Data.SqlDbType.VarChar, 12))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ClienteID", System.Data.SqlDbType.VarChar, 10))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Importe", System.Data.SqlDbType.Decimal))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Saldo", System.Data.SqlDbType.Decimal))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Descuento", System.Data.SqlDbType.Decimal))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@IVA", System.Data.SqlDbType.Decimal))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Entregada", System.Data.SqlDbType.VarChar, 1))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ComentarioDesc", System.Data.SqlDbType.VarChar))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Usuario", System.Data.SqlDbType.VarChar))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@StatusRegistro", System.Data.SqlDbType.Bit))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar, 2))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodTipoDescuento", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Referencia", System.Data.SqlDbType.VarChar, 20))


            'OutPut :
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ApartadoID", System.Data.SqlDbType.Int))
            .Parameters("@ApartadoID").Direction = ParameterDirection.Output

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime))
            .Parameters("@Fecha").Direction = ParameterDirection.Output

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioApartado", System.Data.SqlDbType.Int))
            .Parameters("@FolioApartado").Direction = ParameterDirection.Output

        End With

        Try
            sccnnConnection.Open()

            With sccmdInsert
                'Assign Parameters Values

                '.Parameters("@FolioApartado").Value = ContratoFolios() 'pContrato.FolioApartado
                .Parameters("@CodCaja").Value = oParent.ApplicationContext.ApplicationConfiguration.NoCaja
                .Parameters("@CodVendedor").Value = pContrato.PlayerID
                .Parameters("@ClienteID").Value = pContrato.ClienteID
                .Parameters("@Importe").Value = pContrato.ImporteTotal
                .Parameters("@Saldo").Value = pContrato.Saldo
                .Parameters("@Descuento").Value = pContrato.DescuentoTotal
                .Parameters("@IVA").Value = pContrato.IVA
                .Parameters("@Entregada").Value = pContrato.Entregada
                .Parameters("@ComentarioDesc").Value = pContrato.ComentarioDesc
                .Parameters("@Usuario").Value = pContrato.Usuario
                .Parameters("@StatusRegistro").Value = pContrato.StatusRegistro
                .Parameters("@CodTipoDescuento").Value = pContrato.TipoDescuentoID
                .Parameters("@Referencia").Value = pContrato.Referencia

                'Execute Command
                .ExecuteNonQuery()

                'Actualizar General Contrato.
                pContrato.ID = CType(.Parameters("@ApartadoID").Value, Integer)
                pContrato.FolioApartado = CType(.Parameters("@FolioApartado").Value, Integer)

            End With
            'pContrato.FolioApartado

            'Contrato Detalle :

            sccmdInsert.Dispose()
            sccmdInsert = Nothing

            sccmdInsert = New SqlCommand

            With sccmdInsert

                .Connection = sccnnConnection

                .CommandText = "[ApartadosDetalleIns]"
                .CommandType = System.Data.CommandType.StoredProcedure

                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ApartadoID", System.Data.SqlDbType.Int))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodArticulo", System.Data.SqlDbType.VarChar, 20))
                '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Numero", System.Data.SqlDbType.Decimal))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Cantidad", System.Data.SqlDbType.Decimal))
                '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Precio", System.Data.SqlDbType.Money))
                '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Importe", System.Data.SqlDbType.Money))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Precio", System.Data.SqlDbType.Decimal))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Importe", System.Data.SqlDbType.Decimal))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Descuento", System.Data.SqlDbType.Decimal))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Usuario", System.Data.SqlDbType.VarChar, 12))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@StatusRegistro", System.Data.SqlDbType.Bit))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Numero", System.Data.SqlDbType.VarChar, 4))

                'OutPut :
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ApartadoDetalleID", System.Data.SqlDbType.Int))
                .Parameters("@ApartadoDetalleID").Direction = ParameterDirection.Output

                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime))
                .Parameters("@Fecha").Direction = ParameterDirection.Output

            End With


            Dim odrArticulo As DataRow

            For Each odrArticulo In pContrato.Detalle.Tables("ContratoDetalleTmp" & oParent.ApplicationContext.ApplicationConfiguration.NoCaja).Rows

                With sccmdInsert
                    'Assign Parameters Values
                    .Parameters("@ApartadoID").Value = pContrato.ID
                    .Parameters("@CodArticulo").Value = odrArticulo("CodArticulo")
                    '.Parameters("@Numero").Value = odrArticulo("Numero")
                    .Parameters("@Cantidad").Value = odrArticulo("Cantidad")
                    .Parameters("@Precio").Value = odrArticulo("Precio") '("PrecioVenta")
                    .Parameters("@Importe").Value = odrArticulo("Importe")
                    .Parameters("@Descuento").Value = odrArticulo("Descuento")
                    .Parameters("@Usuario").Value = oParent.ApplicationContext.Security.CurrentUser.Name
                    .Parameters("@StatusRegistro").Value = pContrato.StatusRegistro
                    .Parameters("@Numero").Value = odrArticulo("Numero")

                    'Execute Command
                    .ExecuteNonQuery()
                End With
            Next

            'Actualizar Existencias :

            UpdateInventario(pContrato.Detalle, pContrato.FolioApartado)


            'Reset New State of Contrato Object 
            pContrato.ResetFlagNew()
            pContrato.ResetFlagDirty()

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


    Public Sub Delete(ByVal ID As Integer, ByVal usuario As String)

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                                 DataStorageConfiguration.GetConnectionString)

        Dim sccmdDelete As SqlCommand
        sccmdDelete = New SqlCommand

        With sccmdDelete

            .Connection = sccnnConnection
            .CommandText = "[ApartadosDel]"
            .CommandType = System.Data.CommandType.StoredProcedure

            '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ApartadoID", System.Data.SqlDbType.Int))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Usuario", System.Data.SqlDbType.VarChar))
        End With

        Try

            sccnnConnection.Open()

            With sccmdDelete
                'Assign Parameters Values
                .Parameters("@ApartadoID").Value = ID
                .Parameters("@Usuario").Value = usuario
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



    Public Function UpdateInventario(ByVal dsContratoDetalle As DataSet, ByVal intContratoFolio As Integer) As Boolean

        Dim odrArticulo As DataRow
        Dim oCatalogoArticuloMgr As New CatalogoArticuloManager(oParent.ApplicationContext)
        Dim oArticulo As Articulo

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                         DataStorageConfiguration.GetConnectionString)

        Dim sccmdUpdateInventario As SqlCommand
        sccmdUpdateInventario = New SqlCommand



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
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Numero", System.Data.SqlDbType.VarChar, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioSAP", System.Data.SqlDbType.VarChar, 10))


        End With

        Try
            sccnnConnection.Open()

            For Each odrArticulo In dsContratoDetalle.Tables("ContratoDetalleTmp" & oParent.ApplicationContext.ApplicationConfiguration.NoCaja).Rows

                'Extraer la Información de cada Artículo.
                oArticulo = Nothing
                oArticulo = oCatalogoArticuloMgr.Load(CType(odrArticulo("CodArticulo"), String))

                With sccmdUpdateInventario

                    'Assign Parameters Values 
                    .Parameters("@CodTipoMov").Value = 0  '202  '102
                    .Parameters("@TipoMovimiento").Value = "O"  '"E"
                    .Parameters("@StatusMov").Value = "A"
                    .Parameters("@CodAlmacen").Value = oParent.ApplicationContext.ApplicationConfiguration.Almacen
                    .Parameters("@Destino").Value = String.Empty
                    .Parameters("@Folio").Value = intContratoFolio
                    .Parameters("@FolioSAP").Value = "0"
                    .Parameters("@CodArticulo").Value = odrArticulo("CodArticulo")
                    .Parameters("@Descripcion").Value = oArticulo.Descripcion   'odrArticulo("Descripcion")
                    '.Parameters("@Numero").Value = odrArticulo("Numero")

                    .Parameters("@Total").Value = 0
                    .Parameters("@Apartados").Value = odrArticulo("Cantidad")

                    .Parameters("@Defectuosos").Value = 0
                    .Parameters("@Promocion").Value = 0
                    .Parameters("@VtasEspeciales").Value = 0
                    .Parameters("@Consignacion").Value = 0
                    .Parameters("@Transito").Value = 0

                    .Parameters("@CodLinea").Value = oArticulo.Codlinea
                    .Parameters("@CodMarca").Value = oArticulo.CodMarca
                    .Parameters("@CodFamilia").Value = oArticulo.CodFamilia
                    .Parameters("@CodUso").Value = oArticulo.CodUso.PadLeft(8, "0")
                    .Parameters("@CodCategoria").Value = Format(oArticulo.CodCategoria, "000")
                    .Parameters("@CodUnidad").Value = oArticulo.CodUnidadVta

                    .Parameters("@Usuario").Value = oParent.ApplicationContext.Security.CurrentUser.Name

                    .Parameters("@CostoUnit").Value = 0
                    .Parameters("@PrecioUnit").Value = 0

                    .Parameters("@FolioControl").Value = String.Empty  'Folio al Iniciar Dia.
                    .Parameters("@CodCaja").Value = oParent.ApplicationContext.ApplicationConfiguration.NoCaja

                    .Parameters("@Descuento").Value = odrArticulo("Descuento")
                    .Parameters("@TOTFGRAL").Value = 0
                    .Parameters("@TOTNC").Value = 0
                    .Parameters("@CostoNC").Value = 0
                    .Parameters("@VTA_DIP").Value = "N"
                    .Parameters("@Numero").Value = odrArticulo("Numero")


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


        Return True

    End Function



    Public Function SelectCatalogoCorridas() As DataSet

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim scdaContrato As SqlDataAdapter
        Dim dsContrato As DataSet



        dsContrato = New DataSet("TraspasoCorrida")

        Try
            sccnnConnection.Open()

            scdaContrato = New SqlDataAdapter("SELECT * FROM CatalogoCorridas", sccnnConnection)

            'Fill DataSet
            scdaContrato.Fill(dsContrato, "CatalogoCorridas")

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

        Return dsContrato

    End Function



    Public Function ContratoFolios() As Integer

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
            .CommandText = "[ContratoFolios]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar, 2))

            'OutPut :
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioApartado", System.Data.SqlDbType.Int))
            .Parameters("@FolioApartado").Direction = ParameterDirection.Output

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



    Public Function SelectAll(ByVal EnabledRecordsOnly As Boolean) As DataSet

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

            .CommandText = "[ApartadosSelAll]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@OnlyEnabledRecords", System.Data.SqlDbType.Bit, 1))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar, 2))

        End With

        scdaContrato.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            scdaContrato.SelectCommand.Parameters("@OnlyEnabledRecords").Value = CType(EnabledRecordsOnly, Boolean)
            scdaContrato.SelectCommand.Parameters("@CodCaja").Value = oParent.ApplicationContext.ApplicationConfiguration.NoCaja


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

        Return dsContrato

    End Function



    Public Function CalcularTotalAbonos(ByVal intApartadoID As Integer) As Decimal

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        Dim decValue As Decimal



        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[ContratoAbonosTotal]"
            .CommandType = System.Data.CommandType.StoredProcedure

            '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ApartadoID", System.Data.SqlDbType.Int))

            'OutPut :
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TotalAbonos", System.Data.SqlDbType.Money))
            .Parameters("@TotalAbonos").Direction = ParameterDirection.Output

        End With


        Try
            sccnnConnection.Open()

            With sccmdSelect

                'Assign Parameters Values

                .Parameters("@ApartadoID").Value = intApartadoID
                .Parameters("@TotalAbonos").Value = 0.0

                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) And (IsDBNull(scdrReader.Item(0)) <> True) Then

                    With scdrReader

                        decValue = .GetDecimal(0)

                    End With

                Else

                    scdrReader.Close()
                    sccnnConnection.Close()

                    sccnnConnection.Dispose()
                    sccnnConnection = Nothing

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

        Return decValue

    End Function



    Public Function CalcularTotalAbonosAnticipoClientes(ByVal intApartadoID As Integer) As Decimal

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        Dim decValue As Decimal



        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[ContratoAbonosTotalAnticipoCliente]"
            .CommandType = System.Data.CommandType.StoredProcedure

            '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ApartadoID", System.Data.SqlDbType.Int))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodFormaPago", System.Data.SqlDbType.VarChar))

            'OutPut :
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TotalAbonos", System.Data.SqlDbType.Money))
            .Parameters("@TotalAbonos").Direction = ParameterDirection.Output

        End With


        Try
            sccnnConnection.Open()

            With sccmdSelect

                'Assign Parameters Values

                .Parameters("@ApartadoID").Value = intApartadoID
                .Parameters("@CodFormaPago").Value = "TACR"
                .Parameters("@TotalAbonos").Value = 0.0

                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) And (IsDBNull(scdrReader.Item(0)) <> True) Then

                    With scdrReader

                        decValue = .GetDecimal(0)

                    End With

                Else

                    scdrReader.Close()
                    sccnnConnection.Close()

                    sccnnConnection.Dispose()
                    sccnnConnection = Nothing

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

        Return decValue

    End Function




    Private Sub ExtraerInformacionTarjeta(ByVal intFolioAbono As Integer, ByRef strCodBanco As String, _
                                          ByRef strNumeroTarjeta As String, ByRef strNumeroAutorizacion As String)

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        Dim dsDataSet As DataSet
        dsDataSet = New DataSet

        Dim decValor As Decimal



        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[ContratoExtraerInformacionTarjeta]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioAbono", System.Data.SqlDbType.Int))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodFormaPago", System.Data.SqlDbType.Char, 1))


            'OutPut :
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodBanco", System.Data.SqlDbType.VarChar, 4))
            .Parameters("@CodBanco").Direction = ParameterDirection.Output

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@NumeroTarjeta", System.Data.SqlDbType.VarChar, 20))
            .Parameters("@NumeroTarjeta").Direction = ParameterDirection.Output

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@NumeroAutorizacion", System.Data.SqlDbType.VarChar, 20))
            .Parameters("@NumeroAutorizacion").Direction = ParameterDirection.Output

        End With


        Try

            sccnnConnection.Open()

            With sccmdSelect

                'Assign Parameters Values
                .Parameters("@FolioAbono").Value = intFolioAbono
                .Parameters("@CodFormaPago").Value = "TACR"
                .Parameters("@CodBanco").Value = String.Empty
                .Parameters("@NumeroTarjeta").Value = String.Empty
                .Parameters("@NumeroAutorizacion").Value = String.Empty

                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) And (IsDBNull(scdrReader.Item(0)) <> True) Then

                    With scdrReader

                        strCodBanco = .GetString(0)
                        strNumeroTarjeta = .GetString(1)
                        strNumeroAutorizacion = .GetString(2)

                        scdrReader.Close()
                        sccnnConnection.Close()

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

    End Sub



    Private Function InsertDistribucionContrato(ByVal intContratoFolio As Integer, _
                                                   ByVal oCliente As DportenisPro.DPTienda.ApplicationUnits.Clientes.ClienteAlterno, _
                                                   ByVal decContratoTotal As Decimal, _
                                                   ByVal decPenalizacion As Decimal, _
                                                   ByVal decTotalAbonos As Decimal) _
    As Integer

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                                 DataStorageConfiguration.GetConnectionString)

        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand

        Dim intReturnValue As Integer

        Dim datReturnValue As Date



        With sccmdInsert

            .Connection = sccnnConnection

            .CommandText = "[AnticiposClientesIns]"
            .CommandType = System.Data.CommandType.StoredProcedure


            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar, 2))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Referencia", System.Data.SqlDbType.Int))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TotalAnticipoCliente", System.Data.SqlDbType.Money))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TotalTarjetaCredito", System.Data.SqlDbType.Money))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@SaldoAnticipoCliente", System.Data.SqlDbType.Money))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Usuario", System.Data.SqlDbType.VarChar, 12))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@StatusRegistro", System.Data.SqlDbType.Bit))

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ClienteID", System.Data.SqlDbType.VarChar, 10))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Nombre", System.Data.SqlDbType.VarChar))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@GeneradoPor", System.Data.SqlDbType.VarChar))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TotalAbonos", System.Data.SqlDbType.Money))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Penalizacion", System.Data.SqlDbType.Money))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@DevEfectivo", System.Data.SqlDbType.Char))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@MotivoCancelacion", System.Data.SqlDbType.VarChar))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TotalFonacotFacilito", System.Data.SqlDbType.Money))


            'OutPut :
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@AnticipoClienteID", System.Data.SqlDbType.Int))
            .Parameters("@AnticipoClienteID").Direction = ParameterDirection.Output

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime))
            .Parameters("@Fecha").Direction = ParameterDirection.Output

        End With

        Try
            sccnnConnection.Open()

            With sccmdInsert

                'Assign Parameters Values

                .Parameters("@CodAlmacen").Value = oParent.ApplicationContext.ApplicationConfiguration.Almacen
                .Parameters("@CodCaja").Value = oParent.ApplicationContext.ApplicationConfiguration.NoCaja
                .Parameters("@Referencia").Value = intContratoFolio
                .Parameters("@TotalAnticipoCliente").Value = decContratoTotal
                .Parameters("@TotalTarjetaCredito").Value = 0.0
                .Parameters("@SaldoAnticipoCliente").Value = 0.0
                .Parameters("@Usuario").Value = oParent.ApplicationContext.Security.CurrentUser.Name
                .Parameters("@StatusRegistro").Value = 1
                .Parameters("@ClienteID").Value = oCliente.CodigoAlterno


                If oCliente.CodigoAlterno <> String.Empty Then
                    If (oCliente.CodigoAlterno = 1) Then
                        .Parameters("@Nombre").Value = oCliente.Nombre
                    Else
                        .Parameters("@Nombre").Value = oCliente.ApellidoPaterno & " " & oCliente.ApellidoMaterno & " " & oCliente.Nombre
                    End If
                Else
                    .Parameters("@Nombre").Value = String.Empty
                End If

                .Parameters("@GeneradoPor").Value = "APT"
                .Parameters("@TotalAbonos").Value = decTotalAbonos
                .Parameters("@Penalizacion").Value = decPenalizacion
                .Parameters("@DevEfectivo").Value = "N"
                .Parameters("@MotivoCancelacion").Value = String.Empty
                .Parameters("@TotalFonacotFacilito").Value = 0.0


                'Execute Command
                .ExecuteNonQuery()

                'Actualizar General Contrato.
                intReturnValue = CType(.Parameters("@AnticipoClienteID").Value, Integer)
                datReturnValue = CType(.Parameters("@Fecha").Value, Date)

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

        Return intReturnValue

    End Function



    Private Sub UpdateDistribucionContratoTotales(ByVal intAnticipoID As Integer, ByVal decContratoTotal As Decimal)

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                                 DataStorageConfiguration.GetConnectionString)

        Dim sccmdUpdate As SqlCommand
        sccmdUpdate = New SqlCommand

        Dim scdaAnticipoCliente As SqlDataAdapter
        Dim sccmdSelectAll As SqlCommand
        Dim dsAnticipoClienteDetalle As DataSet

        sccmdSelectAll = New SqlCommand
        scdaAnticipoCliente = New SqlDataAdapter
        dsAnticipoClienteDetalle = New DataSet

        Dim dtContratoDetalle As DataTable
        Dim drAbono As DataRow

        Dim decMontoCancelarTarjetaCredito As Decimal
        Dim decMontoAnticipoCliente As Decimal
        'Dim decMontoDPVale As Decimal
        'Dim decMontoCDT As Decimal


        With sccmdSelectAll

            .Connection = sccnnConnection

            .CommandText = "[AnticiposClientesDetalleSel]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@AnticipoID", System.Data.SqlDbType.Int))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Modulo", System.Data.SqlDbType.VarChar, 2))

        End With


        With sccmdUpdate

            .Connection = sccnnConnection

            .CommandText = "[ContratoAnticiposClientesTotalesUpd]"  '"[NotaCreditoAnticiposClientesTotalesUpd]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@AnticipoID", System.Data.SqlDbType.Int))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TotalAnticipoCliente", System.Data.SqlDbType.Money))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TotalTarjetaCredito", System.Data.SqlDbType.Money))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@SaldoAnticipoCliente", System.Data.SqlDbType.Money))

        End With

        scdaAnticipoCliente.SelectCommand = sccmdSelectAll

        Try
            sccnnConnection.Open()


            'Calcular Total Monto Cancelar T. Credito y Anticipo Cliente.
            scdaAnticipoCliente.SelectCommand.Parameters("@AnticipoID").Value = intAnticipoID
            scdaAnticipoCliente.SelectCommand.Parameters("@Modulo").Value = "AP"

            'Fill DataSet
            scdaAnticipoCliente.Fill(dsAnticipoClienteDetalle, "AnticiposClientesDetalle")


            dtContratoDetalle = dsAnticipoClienteDetalle.Tables(0)

            For Each drAbono In dtContratoDetalle.Rows

                decMontoCancelarTarjetaCredito += CType(drAbono("MontoCanceladoTarjeta"), Decimal)
                decMontoAnticipoCliente += CType(drAbono("AnticipoCliente"), Decimal)

            Next

            dtContratoDetalle = Nothing


            With sccmdUpdate

                'Assign Parameters Values

                .Parameters("@AnticipoID").Value = intAnticipoID
                .Parameters("@TotalAnticipoCliente").Value = decContratoTotal 'decMontoAnticipoCliente + decMontoCancelarTarjetaCredito

                .Parameters("@TotalTarjetaCredito").Value = decMontoCancelarTarjetaCredito
                .Parameters("@SaldoAnticipoCliente").Value = decMontoAnticipoCliente


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



    Public Function DistribucionCancelarContrato(ByVal oContrato As Contrato) As Integer

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                                 DataStorageConfiguration.GetConnectionString)
        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand
        Dim intReturnValue As Integer
        Dim datReturnValue As Date

        Dim odrAbono As DataRow
        Dim dsContratoAbonos As New DataSet
        Dim intAnticipoID As Integer

        Dim decPenalizacion As Decimal = oContrato.ImporteTotal * oParent.ApplicationContext.ApplicationConfiguration.Penalizacion
        Dim decTotalAbonosAnticipoClientes As Decimal = CalcularTotalAbonosAnticipoClientes(oContrato.ID)
        Dim decPenalizacionRestante As Decimal

        Dim decMontoCancelarTarjetaCredito As Decimal
        Dim decMontoAnticipoCliente As Decimal

        Dim strCodBanco As String
        Dim strNumeroTarjeta As String
        Dim strNumeroAutorizacion As String

        Dim oClientesMgr As New ClientesManager(oParent.ApplicationContext)
        Dim oCliente As DportenisPro.DPTienda.ApplicationUnits.Clientes.ClienteAlterno


        oCliente = oClientesMgr.CreateAlterno
        oClientesMgr.Load(oContrato.ClienteID, oCliente, "I")

        'Anticipos Clientes General :
        intAnticipoID = InsertDistribucionContrato(oContrato.FolioApartado, oCliente, oContrato.ImporteTotal, decPenalizacion, _
                                                   CalcularTotalAbonos(oContrato.ID))

        decPenalizacionRestante = decPenalizacion

        'Apartado Abonos : 
        dsContratoAbonos = ContratoAbonosSel(oContrato.ID)


        With sccmdInsert

            .Connection = sccnnConnection

            .CommandText = "[AnticiposClientesDetalleIns]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@AnticipoID", System.Data.SqlDbType.Int))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Referencia", System.Data.SqlDbType.Int))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@DPValeID", System.Data.SqlDbType.Int))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodBanco", System.Data.SqlDbType.VarChar, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@NumeroTarjeta", System.Data.SqlDbType.VarChar, 20))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@NumeroAutorizacion", System.Data.SqlDbType.VarChar, 20))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@NumeroAutorizacionCancelacion", System.Data.SqlDbType.VarChar, 20))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@MontoCanceladoTarjeta", System.Data.SqlDbType.Money))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@MontoCanceladoDPVale", System.Data.SqlDbType.Money))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@MontoCanceladoCDT", System.Data.SqlDbType.Money))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@AnticipoCliente", System.Data.SqlDbType.Money))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@MontoAbonos", System.Data.SqlDbType.Money))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Usuario", System.Data.SqlDbType.VarChar, 12))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@StatusRegistro", System.Data.SqlDbType.Bit))

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@MontoFonacotFacilito", System.Data.SqlDbType.Money))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@MontoCanceladoCanje", System.Data.SqlDbType.Money))


            'OutPut :
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@AnticipoClienteDetalleID", System.Data.SqlDbType.Int))
            .Parameters("@AnticipoClienteDetalleID").Direction = ParameterDirection.Output

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime))
            .Parameters("@Fecha").Direction = ParameterDirection.Output

        End With


        'Anticipos Clientes Detalle :
        For Each odrAbono In dsContratoAbonos.Tables(0).Rows

            decMontoCancelarTarjetaCredito = 0
            decMontoAnticipoCliente = 0

            strCodBanco = String.Empty
            strNumeroTarjeta = String.Empty
            strNumeroAutorizacion = String.Empty


            'Calcular Monto Cancelar T. Credito y Monto Anticipo Cliente.

            '                      Total Abonos realizados en Efectivo y T. Debito.
            If (decPenalizacion <= decTotalAbonosAnticipoClientes) Then

                If (odrAbono("CodFormaPago") = "TACR" Or odrAbono("CodFormaPago") = "TADB") Then

                    decMontoCancelarTarjetaCredito = odrAbono("Abono")
                    decMontoAnticipoCliente = 0.0

                    'ExtraerInformacionTarjeta(oContrato.ID, strCodBanco, strNumeroTarjeta, strNumeroAutorizacion)

                    ExtraerInformacionTarjeta(odrAbono("FolioAbono"), strCodBanco, strNumeroTarjeta, strNumeroAutorizacion)

                Else

                    decMontoAnticipoCliente = odrAbono("Abono")
                    decMontoCancelarTarjetaCredito = 0.0

                End If

                '                     Total Abonos realizados en Efectivo y T. Debito.
            ElseIf (decPenalizacion > decTotalAbonosAnticipoClientes) Then

                If (decPenalizacionRestante = decPenalizacion) Then

                    decPenalizacionRestante -= decTotalAbonosAnticipoClientes

                End If


                If (odrAbono("CodFormaPago") = "TACR" Or odrAbono("CodFormaPago") = "TADB") Then

                    'Calcular Monto Cancelar T. Credito :

                    If (odrAbono("Abono") > decPenalizacionRestante) Then

                        decMontoCancelarTarjetaCredito = odrAbono("Abono") - decPenalizacionRestante
                        decPenalizacionRestante = 0

                    ElseIf (odrAbono("Abono") <= decPenalizacionRestante) And (decPenalizacionRestante > 0) Then

                        decMontoCancelarTarjetaCredito = 0
                        decPenalizacionRestante -= odrAbono("Abono")

                    End If

                    'ExtraerInformacionTarjeta(oContrato.ID, strCodBanco, strNumeroTarjeta, strNumeroAutorizacion)

                    ExtraerInformacionTarjeta(odrAbono("FolioAbono"), strCodBanco, strNumeroTarjeta, strNumeroAutorizacion)

                    decMontoAnticipoCliente = 0.0

                Else

                    decMontoAnticipoCliente = odrAbono("Abono")
                    decMontoCancelarTarjetaCredito = 0.0

                End If


            End If

            Try
                sccnnConnection.Open()

                With sccmdInsert

                    'Assign Parameters Values

                    .Parameters("@AnticipoID").Value = intAnticipoID
                    .Parameters("@Referencia").Value = odrAbono("FolioAbono")
                    .Parameters("@DPValeID").Value = 0
                    .Parameters("@CodBanco").Value = strCodBanco
                    .Parameters("@NumeroTarjeta").Value = strNumeroTarjeta
                    .Parameters("@NumeroAutorizacion").Value = strNumeroAutorizacion
                    .Parameters("@NumeroAutorizacionCancelacion").Value = String.Empty
                    .Parameters("@MontoCanceladoTarjeta").Value = decMontoCancelarTarjetaCredito
                    .Parameters("@MontoCanceladoDPVale").Value = 0.0
                    .Parameters("@AnticipoCliente").Value = decMontoAnticipoCliente
                    .Parameters("@MontoCanceladoCDT").Value = 0.0
                    .Parameters("@MontoAbonos").Value = odrAbono("Abono")
                    .Parameters("@Usuario").Value = oParent.ApplicationContext.Security.CurrentUser.Name
                    .Parameters("@StatusRegistro").Value = 1
                    .Parameters("@MontoCanceladoCanje").Value = 0

                    .Parameters("@MontoFonacotFacilito").Value = 0.0

                    'Execute Command
                    .ExecuteNonQuery()

                    'Actualizar General Contrato.
                    intReturnValue = CType(.Parameters("@AnticipoClienteDetalleID").Value, Integer)
                    datReturnValue = CType(.Parameters("@Fecha").Value, Date)

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

        sccmdInsert.Dispose()
        sccmdInsert = Nothing

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        dsContratoAbonos.Dispose()
        dsContratoAbonos = Nothing

        oClientesMgr = Nothing
        oCliente = Nothing


        'Actualizar TotalAnticipoCliente, TotalTarjetaCredito y SaldoAnticipoCliente.

        UpdateDistribucionContratoTotales(intAnticipoID, oContrato.ImporteTotal)

        Return intAnticipoID

    End Function

    Public Sub CancelarContrato(ByVal intApartadoID As Integer, ByVal User As String)

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                                 DataStorageConfiguration.GetConnectionString)

        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand

        Dim drAbono As DataRow


        With sccmdInsert

            .Connection = sccnnConnection

            .CommandText = "[ContratoDel]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ApartadoID", System.Data.SqlDbType.Int))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Usuario", System.Data.SqlDbType.VarChar))
        End With

        Try

            sccnnConnection.Open()

            With sccmdInsert

                'Assign Parameters Values
                .Parameters("@ApartadoID").Value = intApartadoID
                .Parameters("@Usuario").Value = User
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

    Public Sub ContratoCancelarAbonos(ByVal intApartadoID As Integer)

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                                 DataStorageConfiguration.GetConnectionString)

        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand

        Dim drAbono As DataRow


        With sccmdInsert

            .Connection = sccnnConnection

            .CommandText = "[ContratoAbonosDel]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ApartadoID", System.Data.SqlDbType.Int))

        End With

        Try

            sccnnConnection.Open()

            With sccmdInsert

                'Assign Parameters Values
                .Parameters("@ApartadoID").Value = intApartadoID

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



    Public Function ContratoCancelarUpdateInventario(ByVal dsContratoDetalle As DataSet)

        Dim odrArticulo As DataRow
        Dim oCatalogoArticuloMgr As New CatalogoArticuloManager(oParent.ApplicationContext)
        Dim oArticulo As Articulo

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                                 DataStorageConfiguration.GetConnectionString)

        Dim sccmdUpdateInventario As SqlCommand
        sccmdUpdateInventario = New SqlCommand



        With sccmdUpdateInventario

            .Connection = sccnnConnection

            .CommandText = "[ContratoCancelarInventarioUpd]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodArticulo", System.Data.SqlDbType.VarChar))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Numero", System.Data.SqlDbType.VarChar, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Cantidad", System.Data.SqlDbType.Int))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Apartados", System.Data.SqlDbType.Int))

        End With

        Try
            sccnnConnection.Open()

            For Each odrArticulo In dsContratoDetalle.Tables(0).Rows

                'Extraer Cantidad Apartados por CodAlmacen, CodArticulo, Talla.                

                With sccmdUpdateInventario

                    .Parameters("@CodAlmacen").Value = oParent.ApplicationContext.ApplicationConfiguration.Almacen
                    .Parameters("@CodArticulo").Value = odrArticulo("CodArticulo")
                    .Parameters("@Numero").Value = odrArticulo("Numero")
                    .Parameters("@Cantidad").Value = odrArticulo("Cantidad")
                    .Parameters("@Apartados").Value = 0


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

    End Function



    Public Function ContratoCancelarAnticiposClientesDel(ByVal intAnticipoID As Integer)

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                                 DataStorageConfiguration.GetConnectionString)

        Dim sccmdDelete As SqlCommand
        sccmdDelete = New SqlCommand



        With sccmdDelete

            .Connection = sccnnConnection

            .CommandText = "[ContratoCancelarAnticiposClientesDel]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@AnticipoID", System.Data.SqlDbType.Int))

        End With

        Try
            sccnnConnection.Open()


            With sccmdDelete

                .Parameters("@AnticipoID").Value = intAnticipoID

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

    End Function


#End Region



#Region "Métodos [Contrato Detalle]"

    Public Sub CreatTable()

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)
        Dim sccmdCreatTable As SqlCommand



        sccmdCreatTable = New SqlCommand

        With sccmdCreatTable

            .Connection = sccnnConnection

            .CommandText = "[ContratoDetalleCrearTMP]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@NombreTabla", System.Data.SqlDbType.VarChar, 30))

        End With


        Try
            sccnnConnection.Open()

            With sccmdCreatTable
                'Assign Parameters Values
                .Parameters("@NombreTabla").Value = "ContratoDetalleTmp" & oParent.ApplicationContext.ApplicationConfiguration.NoCaja

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



    Public Sub DeleteTable()

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)
        Dim sccmdDeleteTable As SqlCommand



        sccmdDeleteTable = New SqlCommand

        With sccmdDeleteTable

            .Connection = sccnnConnection

            .CommandText = "[ContratoDetalleEliminarTMP]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@NombreTabla", System.Data.SqlDbType.VarChar, 30))

        End With


        Try
            sccnnConnection.Open()

            With sccmdDeleteTable
                'Assign Parameters Values
                .Parameters("@NombreTabla").Value = "ContratoDetalleTmp" & oParent.ApplicationContext.ApplicationConfiguration.NoCaja

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



    Public Sub InsertArticulo(ByVal intApartadoID As Integer, ByVal oArticulo As Articulo, ByVal strTalla As String, _
                           ByVal intCantidad As Integer, ByVal decDescuento As Decimal, ByVal strUsuario As String)

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                                 DataStorageConfiguration.GetConnectionString)

        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand

        With sccmdInsert

            .Connection = sccnnConnection

            .CommandText = "[ContratoDetalleArticuloIns]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .CommandType = CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@NombreTabla", System.Data.SqlDbType.VarChar, 30))

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ApartadoID", System.Data.SqlDbType.Int))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodArticulo", System.Data.SqlDbType.VarChar, 20))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Descripcion", System.Data.SqlDbType.VarChar, 50))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Numero", System.Data.SqlDbType.VarChar, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Cantidad", System.Data.SqlDbType.Decimal))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@PrecioVenta", System.Data.SqlDbType.Decimal))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Importe", System.Data.SqlDbType.Decimal))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Descuento", System.Data.SqlDbType.Decimal))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Usuario", System.Data.SqlDbType.VarChar, 12))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@PrecioOferta", System.Data.SqlDbType.Decimal))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@DescuentoMonto", System.Data.SqlDbType.Decimal))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ImporteOferta", System.Data.SqlDbType.Decimal))

            'Ramiro


        End With

        Try

            sccnnConnection.Open()

            With sccmdInsert

                'Assign Parameters Values
                .Parameters("@NombreTabla").Value = "ContratoDetalleTmp" & oParent.ApplicationContext.ApplicationConfiguration.NoCaja

                Dim decDescuentoMonto As Decimal = oArticulo.PrecioVenta * (decDescuento / 100)
                Dim decPrecioOferta As Decimal = oArticulo.PrecioVenta - decDescuentoMonto

                .Parameters("@ApartadoID").Value = intApartadoID
                .Parameters("@CodArticulo").Value = oArticulo.CodArticulo
                .Parameters("@Descripcion").Value = oArticulo.Descripcion
                .Parameters("@Cantidad").Value = intCantidad
                .Parameters("@PrecioVenta").Value = oArticulo.PrecioVenta  'oArticulo.PrecioOferta
                .Parameters("@Importe").Value = (oArticulo.PrecioVenta - decDescuentoMonto) * intCantidad
                .Parameters("@Descuento").Value = decDescuento
                .Parameters("@Usuario").Value = strUsuario

                .Parameters("@PrecioOferta").Value = decPrecioOferta
                .Parameters("@ImporteOferta").Value = intCantidad * decPrecioOferta
                .Parameters("@DescuentoMonto").Value = intCantidad * decDescuentoMonto
                '.Parameters("@Numero").Value = strTalla
                .Parameters("@Numero").Value = ""


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



    Public Sub UpdateDocFiContrato(ByVal intApartadoID As Integer, ByVal strDocfi As String, ByVal strContrato As String)

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                                 DataStorageConfiguration.GetConnectionString)

        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand

        With sccmdInsert

            .Connection = sccnnConnection

            .CommandText = "[ApartadosDocFiUp]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .CommandType = CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ApartadoID", System.Data.SqlDbType.Int))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@DocFi", System.Data.SqlDbType.VarChar, 10))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Contrato", System.Data.SqlDbType.VarChar, 10))


        End With

        Try

            sccnnConnection.Open()

            With sccmdInsert

                'Assign Parameters Values

                .Parameters("@ApartadoID").Value = intApartadoID
                .Parameters("@DocFi").Value = strDocfi
                .Parameters("@Contrato").Value = strContrato

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



    Public Sub UpdateDocFiCancelacion(ByVal intApartadoID As Integer, ByVal strDocfi As String)

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                                 DataStorageConfiguration.GetConnectionString)

        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand

        With sccmdInsert

            .Connection = sccnnConnection

            .CommandText = "[ApartadosDocFiCanUpd]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .CommandType = CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ApartadoID", System.Data.SqlDbType.Int))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@DocFiCanc", System.Data.SqlDbType.VarChar, 10))

        End With

        Try

            sccnnConnection.Open()

            With sccmdInsert

                'Assign Parameters Values

                .Parameters("@ApartadoID").Value = intApartadoID
                .Parameters("@DocFiCanc").Value = strDocfi

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

    End Sub



    Public Sub DeleteArticulo(ByVal strCodArticulo As String, ByVal strTalla As String)

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                                 DataStorageConfiguration.GetConnectionString)

        Dim sccmdDelete As SqlCommand
        sccmdDelete = New SqlCommand

        With sccmdDelete

            .Connection = sccnnConnection
            .CommandText = "[ContratoDetalleArticuloDel]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@NombreTabla", System.Data.SqlDbType.VarChar, 40))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodArticulo", System.Data.SqlDbType.VarChar, 20))
            '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Numero", System.Data.SqlDbType.Decimal))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Talla", System.Data.SqlDbType.VarChar, 4))

        End With

        Try

            sccnnConnection.Open()

            With sccmdDelete
                'Assign Parameters Values
                .Parameters("@NombreTabla").Value = "ContratoDetalleTmp" & oParent.ApplicationContext.ApplicationConfiguration.NoCaja
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


        sccmdDelete.Dispose()
        sccmdDelete = Nothing

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

    End Sub


    'Se Utiliza extraer el mismo Porcentaje de Descuento de un Artículo previamente capturado.
    Public Function BuscarArticuloTmp(ByVal strCodArticuloD As String, ByVal strTalla As String) As Decimal

        'TODO: JHV - Implementar retorno de TraspasoEntrada
        'NOTE: Si se especifica TraspasoEntradaTarget, utilizar ese en lugar de crear y devolver uno nuevo

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        Dim decValorRetorno As Decimal

        'Dim dsDataSet As DataSet
        'dsDataSet = New DataSet


        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[ContratoDetalleArticuloSel]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@NombreTabla", System.Data.SqlDbType.VarChar, 30))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodArticulo", System.Data.SqlDbType.VarChar, 20))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Numero", System.Data.SqlDbType.VarChar, 4))

        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect
                'Assign Parameters Values
                .Parameters("@NombreTabla").Value = "ContratoDetalleTmp" & oParent.ApplicationContext.ApplicationConfiguration.NoCaja
                .Parameters("@CodArticulo").Value = strCodArticuloD
                .Parameters("@Numero").Value = strTalla

                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    'Traspaso General :
                    With scdrReader

                        decValorRetorno = .GetDecimal(10)

                        .Close()

                    End With

                Else
                    decValorRetorno = 0
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

        Return decValorRetorno

    End Function



    Public Function FillDataSet(ByVal strStoredProcedure As String, ByVal strTabla As String) As DataSet

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                GetConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaContrato As SqlDataAdapter
        Dim dsContrato As DataSet



        sccmdSelectAll = New SqlCommand
        scdaContrato = New SqlDataAdapter
        dsContrato = New DataSet(strTabla)

        With sccmdSelectAll

            .Connection = sccnnConnection

            .CommandText = strStoredProcedure    '"[TraspasoSelAll]"
            .CommandType = System.Data.CommandType.StoredProcedure

            '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@NombreTabla", System.Data.SqlDbType.VarChar, 40))

        End With

        scdaContrato.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            scdaContrato.SelectCommand.Parameters("@NombreTabla").Value = strTabla

            'Fill DataSet
            scdaContrato.Fill(dsContrato, strTabla)

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

        Return dsContrato

    End Function



    Public Function ContratoAbonosSel(ByVal intApartadoID As Integer) As DataSet

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                GetConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaContrato As SqlDataAdapter
        Dim dsContrato As DataSet



        sccmdSelectAll = New SqlCommand
        scdaContrato = New SqlDataAdapter
        dsContrato = New DataSet("AbonosApartados")

        With sccmdSelectAll

            .Connection = sccnnConnection

            .CommandText = "[ContratoAbonosSel]"
            .CommandType = System.Data.CommandType.StoredProcedure

            '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ApartadoID", System.Data.SqlDbType.Int))

        End With

        scdaContrato.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            scdaContrato.SelectCommand.Parameters("@ApartadoID").Value = intApartadoID

            'Fill DataSet
            scdaContrato.Fill(dsContrato, "AbonosApartados")

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

        Return dsContrato

    End Function



    Public Sub LlenarTablaContratoDetalleTmp(ByVal dsTraspasoDetalle As DataSet)

        Dim odrArticulo As DataRow

        Dim odsCatalogoCorridas As New DataSet
        Dim odrFiltroCorrida() As DataRow

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                                 DataStorageConfiguration.GetConnectionString)

        Dim sccmdTraspasoSalida As SqlCommand
        sccmdTraspasoSalida = New SqlCommand


        With sccmdTraspasoSalida

            .Connection = sccnnConnection

            .CommandText = "[ContratoDetalleArticuloIns]"
            .CommandType = System.Data.CommandType.StoredProcedure


            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@NombreTabla", System.Data.SqlDbType.VarChar, 30))

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ContratoID", System.Data.SqlDbType.Int))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Codigo", System.Data.SqlDbType.VarChar, 20))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Descripcion", System.Data.SqlDbType.VarChar, 50))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Total", System.Data.SqlDbType.Decimal))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Importe", System.Data.SqlDbType.Decimal))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Descuento", System.Data.SqlDbType.Decimal))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Cantidad", System.Data.SqlDbType.Int))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Talla", System.Data.SqlDbType.Decimal))

        End With

        Try
            sccnnConnection.Open()

            For Each odrArticulo In dsTraspasoDetalle.Tables(0).Rows

                With sccmdTraspasoSalida

                    'Assign Parameters Values 
                    .Parameters("@NombreTabla").Value = "TraspasoDetalleTmp" & oParent.ApplicationContext.ApplicationConfiguration.NoCaja

                    .Parameters("@ContratoID").Value = odrArticulo("ContratoID")
                    .Parameters("@Codigo").Value = odrArticulo("Codigo")
                    .Parameters("@Descripcion").Value = odrArticulo("Descripcion")
                    .Parameters("@Total").Value = odrArticulo("Total")
                    .Parameters("@Importe").Value = odrArticulo("Importe")
                    .Parameters("@Descuento").Value = odrArticulo("Descuento")
                    .Parameters("@Cantidad").Value = odrArticulo("Cantidad")
                    .Parameters("@Talla").Value = odrArticulo("Talla")


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
            Exit Sub

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("El registro no pudo ser insertado debido a un error de aplicación.", ex)
            Exit Sub

        End Try


        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        sccmdTraspasoSalida.Dispose()
        sccmdTraspasoSalida = Nothing

    End Sub



    Public Function ValidarCantidadArticulo(ByVal intCantidadArticulo As Integer, ByVal strCodArticulo As String, _
                                            ByVal strTalla As String) As Boolean

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        Dim dsDataSet As DataSet
        dsDataSet = New DataSet '("TraspasoCorrida")




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
                .Parameters("@CodAlmacenDestino").Value = ""
                .Parameters("@CodArticulo").Value = strCodArticulo.PadLeft(18, "0")
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

        Return True

    End Function



    Public Function ValidarTallaArticulo(ByVal strTallaArticulo As String, ByVal strCodCorrida As String) As Boolean

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        Dim dsDataSet As DataSet
        dsDataSet = New DataSet("TraspasoCorrida")




        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            '.CommandText = "[TraspasoDetalleValidarTalla]"
            .CommandText = "[validarTallaCatalogoCorridaS]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCorrida", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Talla", System.Data.SqlDbType.VarChar, 5))

        End With


        Try

            sccnnConnection.Open()

            With sccmdSelect
                'Assign Parameters Values
                .Parameters("@CodCorrida").Value = strCodCorrida
                .Parameters("@Talla").Value = strTallaArticulo
                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    With scdrReader
                        'si es cero la tala no pertenece a la corrida
                        If .GetInt32(0) = 0 Then
                            Return False
                        Else
                            Return True
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



    Public Function ExtraerCantLibreArticulo(ByVal strCodArticulo As String, ByVal strTalla As String) As Decimal

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        Dim dsDataSet As DataSet
        dsDataSet = New DataSet

        Dim decRetornarValor As Decimal



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
                .Parameters("@CodAlmacenDestino").Value = ""
                .Parameters("@CodArticulo").Value = strCodArticulo
                .Parameters("@Numero").Value = strTalla

                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) And (IsDBNull(scdrReader.Item(0)) <> True) Then

                    With scdrReader

                        decRetornarValor = .GetDecimal(0)

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


#End Region

    Public Function ContratoDetalleSel(ByVal FechaDe As DateTime, ByVal FechaHasta As DateTime, ByVal CodCaja As String) As DataSet

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

            .CommandText = "[ApartadosSelDetalles]"
            .CommandType = System.Data.CommandType.StoredProcedure

            '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaDe", System.Data.SqlDbType.DateTime))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaHasta", System.Data.SqlDbType.DateTime))

        End With

        scdaContrato.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            scdaContrato.SelectCommand.Parameters("@CodCaja").Value = CodCaja
            scdaContrato.SelectCommand.Parameters("@FechaDe").Value = FechaDe
            scdaContrato.SelectCommand.Parameters("@FechaHasta").Value = FechaHasta

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

        Return dsContrato

    End Function

    Public Function ContratoTotalesSel(ByVal FechaDe As DateTime, ByVal FechaHasta As DateTime, ByVal CodCaja As String) As DataSet

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

            .CommandText = "[ApartadosSelTotales]"
            .CommandType = System.Data.CommandType.StoredProcedure

            '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaDe", System.Data.SqlDbType.DateTime))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaHasta", System.Data.SqlDbType.DateTime))

        End With

        scdaContrato.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            scdaContrato.SelectCommand.Parameters("@CodCaja").Value = CodCaja
            scdaContrato.SelectCommand.Parameters("@FechaDe").Value = FechaDe
            scdaContrato.SelectCommand.Parameters("@FechaHasta").Value = FechaHasta

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

        Return dsContrato

    End Function

    Public Function ContratoCanceladosSel(ByVal FechaDe As DateTime, ByVal FechaHasta As DateTime, ByVal CodCaja As String) As DataSet

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

            .CommandText = "[ApartadosSelCancelados]"
            .CommandType = System.Data.CommandType.StoredProcedure

            '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaDe", System.Data.SqlDbType.DateTime))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaHasta", System.Data.SqlDbType.DateTime))

        End With

        scdaContrato.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            scdaContrato.SelectCommand.Parameters("@CodCaja").Value = CodCaja
            scdaContrato.SelectCommand.Parameters("@FechaDe").Value = FechaDe
            scdaContrato.SelectCommand.Parameters("@FechaHasta").Value = FechaHasta

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

        Return dsContrato

    End Function

    Public Function AbonosApartadosSel(ByVal AnticipoID As Integer) As DataSet

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                GetConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaAbonos As SqlDataAdapter
        Dim dsAbonos As DataSet



        sccmdSelectAll = New SqlCommand
        scdaAbonos = New SqlDataAdapter
        dsAbonos = New DataSet

        With sccmdSelectAll

            .Connection = sccnnConnection

            .CommandText = "[AbonosApartadosDetalleSel]"
            .CommandType = System.Data.CommandType.StoredProcedure

            '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@AnticipoID", System.Data.SqlDbType.Int))


        End With

        scdaAbonos.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            scdaAbonos.SelectCommand.Parameters("@AnticipoID").Value = AnticipoID


            'Fill DataSet
            scdaAbonos.Fill(dsAbonos)

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

        Return dsAbonos

    End Function

    Public Function ContratoVegentesSel() As DataSet

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

            .CommandText = "[ApartadosSelVigentes]"
            .CommandType = System.Data.CommandType.StoredProcedure

            '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))

        End With

        scdaContrato.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

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

        Return dsContrato

    End Function

    Public Function GetContratosVencidos() As DataSet

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                GetConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaContrato As SqlDataAdapter
        Dim dsContrato As DataSet



        sccmdSelectAll = New SqlCommand
        scdaContrato = New SqlDataAdapter
        dsContrato = New DataSet("Vencidos")

        With sccmdSelectAll

            .Connection = sccnnConnection

            .CommandText = "[ApartadosVencidosSel]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@DiasVigenciaApartado", System.Data.SqlDbType.Int, 4))

            '''Asignamos valor al parametro
            .Parameters("@DiasVigenciaApartado").Value = oParent.ApplicationContext.ApplicationConfiguration.DiasVencimientoApartados

        End With

        scdaContrato.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            'Fill DataSet
            scdaContrato.Fill(dsContrato, "Vencidos")

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

        Return dsContrato

    End Function

#Region "SAP Retail"

    Public Function GetApartadoSaldado(ByVal FacturaId As Integer) As Decimal
        Dim conexion As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                GetConnectionString)

        Dim command As New SqlCommand("GetSaldoApartado", conexion)
        Dim saldo As Decimal = 0
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.AddWithValue("@FacturaId", FacturaId)
            saldo = CDec(command.ExecuteScalar())
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
        Return saldo
    End Function

    Public Function GetAnticiposByApartadoId(ByVal ApartadoId As Integer) As DataTable
        Dim conexion As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString())
        Dim command As New SqlCommand("GetAnticiposByApartadoId", conexion)
        Dim adapter As SqlDataAdapter = Nothing
        Dim dtAnticipos As New DataTable
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.AddWithValue("@ApartadoId", ApartadoId)
            adapter = New SqlDataAdapter(command)
            adapter.Fill(dtAnticipos)
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
        Return dtAnticipos
    End Function


    Public Function GetImporteAbonosByApartadoId(ByVal ApartadoId As Integer) As DataTable
        Dim conexion As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString())
        Dim command As New SqlCommand("ApartadosSumActivos", conexion)
        Dim adapter As SqlDataAdapter = Nothing
        Dim dtTotal As New DataTable
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.AddWithValue("@ApartadoId", ApartadoId)
            adapter = New SqlDataAdapter(command)
            adapter.Fill(dtTotal)
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
        Return dtTotal
    End Function


#End Region

End Class
