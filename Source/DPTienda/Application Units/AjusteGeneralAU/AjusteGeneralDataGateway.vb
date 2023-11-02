Imports System.Data.SqlClient
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos

Public Class AjusteGeneralDataGateway

    Private oParent As AjusteGeneralManager

#Region "Constructors / Destructors"

    Public Sub New(ByVal Parent As AjusteGeneralManager)

        oParent = Parent

    End Sub

#End Region

#Region "Methods"
    Public Sub Save(ByVal LimiteInferior As Integer, ByVal LimiteSuperior As Integer, ByVal TotalFolios As Integer, ByVal CodCaja As String)
        Dim idx As Integer = 0
        Dim cnnString As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString)
        Dim cmdSave As SqlCommand
        cmdSave = New SqlCommand

        With cmdSave
            .Connection = cnnString
            .CommandText = "FolioVentaManualIns"
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioVenta", System.Data.SqlDbType.VarChar, 10))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime, 8))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Status", System.Data.SqlDbType.Bit, 1))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Usuario", System.Data.SqlDbType.VarChar, 50))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar, 2))


        End With

        Try

            cnnString.Open()

            With cmdSave

                For idx = LimiteInferior To TotalFolios - 1

                    .Parameters("@FolioVenta").Value = idx + 1
                    .Parameters("@CodAlmacen").Value = oParent.ApplicationContext.ApplicationConfiguration.Almacen
                    .Parameters("@Fecha").Value = Date.Today.Now
                    .Parameters("@Status").Value = 0
                    .Parameters("@Usuario").Value = oParent.ApplicationContext.Security.CurrentUser.Name
                    .Parameters("@CodCaja").Value = CodCaja
                    'Execute Command
                    .ExecuteNonQuery()

                Next


            End With

            cnnString.Close()

        Catch oSqlException As SqlException

            If (cnnString.State <> ConnectionState.Closed) Then
                Try
                    cnnString.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("El registro no pudo ser insertado debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (cnnString.State <> ConnectionState.Closed) Then
                Try
                    cnnString.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("El registro no pudo ser insertado debido a un error de aplicación.", ex)

        End Try

        cnnString.Dispose()
        cnnString = Nothing

    End Sub
    Public Sub Insert(ByVal pAjusteGeneral As AjusteGeneralInfo)

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                                 DataStorageConfiguration.GetConnectionString)

        'Insertamos General
        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand

        Dim sccmdInsertDetail As SqlCommand
        sccmdInsertDetail = New SqlCommand

        With sccmdInsert
            .Connection = sccnnConnection

            If pAjusteGeneral.TipoAjuste = "E" Then
                .CommandText = "[AjustesEntradaIns]"
            Else
                .CommandText = "[AjustesSalidaIns]"
            End If

            .CommandType = System.Data.CommandType.StoredProcedure
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioSAP", System.Data.SqlDbType.VarChar, 10))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Almacen", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TotalCodigos", System.Data.SqlDbType.Int))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Usuario", System.Data.SqlDbType.VarChar, 20))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Observaciones", System.Data.SqlDbType.Text))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CostoTotal", System.Data.SqlDbType.Money))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime))
            'OutPut :
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Folio", System.Data.SqlDbType.Int))
            .Parameters("@Folio").Direction = ParameterDirection.Output

        End With

        With sccmdInsertDetail
            .Connection = sccnnConnection

            If pAjusteGeneral.TipoAjuste = "E" Then
                .CommandText = "[AjustesEntradaDetallesIns]"
            Else
                .CommandText = "[AjustesSalidaDetallesIns]"
            End If


            .CommandType = System.Data.CommandType.StoredProcedure
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioAjuste", System.Data.SqlDbType.Int))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Codigo", System.Data.SqlDbType.VarChar, 20))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Descripcion", System.Data.SqlDbType.VarChar, 50))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Talla", System.Data.SqlDbType.VarChar, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Cantidad", System.Data.SqlDbType.Int, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Importe", System.Data.SqlDbType.Money))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioSap", System.Data.SqlDbType.VarChar, 16))


            'OutPut :
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Folio", System.Data.SqlDbType.Int))
            .Parameters("@Folio").Direction = ParameterDirection.Output

        End With

        Try
            sccnnConnection.Open()
            'Insertamos Datos Generales
            With sccmdInsert
                'Assign Parameters Values
                .Parameters("@FolioSAP").Value = pAjusteGeneral.FolioSAP
                .Parameters("@Almacen").Value = oParent.ApplicationContext.ApplicationConfiguration.Almacen
                .Parameters("@TotalCodigos").Value = pAjusteGeneral.TotalCodigos
                .Parameters("@Usuario").Value = oParent.ApplicationContext.Security.CurrentUser.Name
                .Parameters("@Observaciones").Value = pAjusteGeneral.Observaciones
                .Parameters("@CostoTotal").Value = pAjusteGeneral.CostoTotal
                .Parameters("@Fecha").Value = pAjusteGeneral.FechaAjuste
                'Execute Command
                .ExecuteNonQuery()
                pAjusteGeneral.FolioAjuste = .Parameters("@Folio").Value
            End With

            'Insertamos Detalle
            With sccmdInsertDetail

                Dim dRow As DataRow

                For Each dRow In pAjusteGeneral.Detalle.Rows
                    If Trim(dRow!FolioSAp) <> String.Empty Then
                        .Parameters("@FolioAjuste").Value = pAjusteGeneral.FolioAjuste
                        .Parameters("@Codigo").Value = dRow!Codigo
                        .Parameters("@Descripcion").Value = dRow!Descripcion
                        .Parameters("@Talla").Value = dRow!Talla
                        .Parameters("@Cantidad").Value = dRow!Cantidad
                        .Parameters("@Importe").Value = dRow!Importe
                        .Parameters("@FolioSAP").Value = dRow!FolioSAp
                        .ExecuteNonQuery()
                        dRow!Folio = .Parameters("@Folio").Value
                    End If

                Next

                dRow = Nothing

            End With

            'Reset New State of Linea Object 
            pAjusteGeneral.ResetFlagNew()
            pAjusteGeneral.ResetFlagDirty()

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

    Public Sub LoadInto(ByVal intFolioAjuste As Integer, ByVal oAjusteGeneralInfo As AjusteGeneralInfo)

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                         DataStorageConfiguration.GetConnectionString)

        Dim daAjuste As SqlDataAdapter
        Dim daAjusteDetalle As SqlDataAdapter
        Dim dtAjuste As New DataTable

        'Obtenemos General
        Dim sccmdSelect As SqlCommand
        sccmdSelect = New SqlCommand

        Dim sccmdSelectDetail As SqlCommand
        sccmdSelectDetail = New SqlCommand

        With sccmdSelect
            .Connection = sccnnConnection
            If oAjusteGeneralInfo.TipoAjuste = "E" Then
                .CommandText = "[AjustesEntradaSel]"
            Else
                .CommandText = "[AjustesSalidaSel]"
            End If

            .CommandType = System.Data.CommandType.StoredProcedure
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioAjuste", System.Data.SqlDbType.Int))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.Char, 3))
            .Parameters("@FolioAjuste").Value = intFolioAjuste
            .Parameters("@CodAlmacen").Value = oParent.ApplicationContext.ApplicationConfiguration.Almacen
        End With

        With sccmdSelectDetail
            .Connection = sccnnConnection
            If oAjusteGeneralInfo.TipoAjuste = "E" Then
                .CommandText = "[AjustesEntradaDetallesSel]"
            Else
                .CommandText = "[AjustesSalidaDetallesSel]"
            End If

            .CommandType = System.Data.CommandType.StoredProcedure
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioAjuste", System.Data.SqlDbType.Int))
            .Parameters("@FolioAjuste").Value = intFolioAjuste
        End With

        daAjuste = New SqlDataAdapter(sccmdSelect)
        daAjusteDetalle = New SqlDataAdapter(sccmdSelectDetail)

        Try

            daAjuste.Fill(dtAjuste)
            If dtAjuste.Rows.Count > 0 Then

                With oAjusteGeneralInfo

                    .FolioAjuste = dtAjuste.Rows(0).Item("Folio")
                    .FolioSAP = dtAjuste.Rows(0).Item("FolioSAP")
                    .Almacen = dtAjuste.Rows(0).Item("Almacen")
                    .Observaciones = dtAjuste.Rows(0).Item("Observaciones")
                    .TotalCodigos = dtAjuste.Rows(0).Item("TotalCodigos")
                    .CostoTotal = dtAjuste.Rows(0).Item("CostoTotal")
                    .Usuario = dtAjuste.Rows(0).Item("Usuario")
                    .FechaAjuste = dtAjuste.Rows(0).Item("Fecha")

                    .ResetFlagNew()
                    .SetFlagDirty()
                End With
                oAjusteGeneralInfo.Detalle = New DataTable 'Para evitar error de columna calculada
                daAjusteDetalle.Fill(oAjusteGeneralInfo.Detalle)

            Else

                oAjusteGeneralInfo.FolioAjuste = 0
                oAjusteGeneralInfo.Detalle = New DataTable 'Para evitar error de columna calculada
                daAjusteDetalle.Fill(oAjusteGeneralInfo.Detalle)
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

        dtAjuste.Dispose()
        dtAjuste = Nothing

        daAjuste.Dispose()
        daAjusteDetalle.Dispose()

        daAjuste = Nothing
        daAjusteDetalle = Nothing

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

    End Sub

    Public Function GetFolioAjuste(ByVal strTipoMovimiento As String) As Integer

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        Dim intFolio As Integer


        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            If strTipoMovimiento = "E" Then
                .CommandText = "[AjustesEntradaFolio]"
            Else
                .CommandText = "[AjustesSalidaFolio]"
            End If

            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))

            'OutPut :
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Folio", System.Data.SqlDbType.Int))
            .Parameters("@Folio").Direction = ParameterDirection.Output

        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect
                .Parameters("@Folio").Value = 0
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)
                scdrReader.Read()
                If (scdrReader.HasRows) Then
                    intFolio = scdrReader.GetInt32(0) + 1
                Else
                    scdrReader.Close()
                    sccnnConnection.Close()
                    intFolio = 1
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

        Return intFolio

    End Function

    Public Sub InsertMovimiento(ByVal oAjusteInfo As AjusteGeneralInfo)

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                                 DataStorageConfiguration.GetConnectionString)

        Dim oArticuloMgr As New CatalogoArticuloManager(oParent.ApplicationContext)
        Dim oArticulo As Articulo
        oArticulo = oArticuloMgr.Create

        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand

        With sccmdInsert

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

            With sccmdInsert

                Dim dRow As DataRow

                For Each dRow In oAjusteInfo.Detalle.Rows

                    If dRow!foliosap <> String.Empty Then
                        'Assign Parameters Values ENTRADA
                        oArticulo.ClearFields()
                        oArticuloMgr.LoadInto(dRow!Codigo, oArticulo)

                        If oAjusteInfo.TipoAjuste = "E" Then
                            .Parameters("@CodTipoMov").Value = "105"
                            .Parameters("@TipoMovimiento").Value = "E"
                        Else
                            .Parameters("@CodTipoMov").Value = "205"
                            .Parameters("@TipoMovimiento").Value = "S"
                        End If

                        .Parameters("@StatusMov").Value = "A"

                        .Parameters("@CodAlmacen").Value = oParent.ApplicationContext.ApplicationConfiguration.Almacen
                        .Parameters("@Destino").Value = oParent.ApplicationContext.ApplicationConfiguration.Almacen
                        .Parameters("@Folio").Value = oAjusteInfo.FolioAjuste
                        .Parameters("@FolioSAP").Value = "0"
                        .Parameters("@CodArticulo").Value = dRow!Codigo
                        .Parameters("@Descripcion").Value = dRow!Descripcion
                        .Parameters("@Numero").Value = dRow!Talla
                        .Parameters("@Total").Value = dRow!Cantidad
                        .Parameters("@Apartados").Value = 0
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
                        .Parameters("@CodUnidad").Value = oArticulo.CodUnidadCom
                        .Parameters("@Usuario").Value = oParent.ApplicationContext.Security.CurrentUser.Name
                        .Parameters("@CostoUnit").Value = oArticulo.CostoProm
                        .Parameters("@PrecioUnit").Value = oArticulo.PrecioVenta
                        .Parameters("@FolioControl").Value = "" 'Folio al Iniciar Dia.
                        .Parameters("@CodCaja").Value = oParent.ApplicationContext.ApplicationConfiguration.NoCaja
                        .Parameters("@Descuento").Value = 0
                        .Parameters("@TOTFGRAL").Value = 0
                        .Parameters("@TOTNC").Value = 0
                        .Parameters("@CostoNC").Value = 0
                        .Parameters("@VTA_DIP").Value = "N"
                        '.Parameters("@VTA_DIP").Value = IIf(oArticulo.CatalogoDIP, "S", "N")

                        'Execute Command
                        .ExecuteNonQuery()
                    End If
                Next

                dRow = Nothing

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
    Public Sub FolioNotaVentaUPD(ByVal Folio As Integer)
        Dim cnnString As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString)
        Dim cmdUpdate As SqlCommand
        Dim daUpdate As SqlDataAdapter

        cmdUpdate = New SqlCommand
        daUpdate = New SqlDataAdapter

        With cmdUpdate
            .Connection = cnnString
            .CommandType = CommandType.StoredProcedure
            .CommandText = "FolioVentaManualUpd"
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Folio", System.Data.SqlDbType.Int, 8))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Usuario", System.Data.SqlDbType.VarChar, 50))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar, 2))

        End With
        Try

            cnnString.Open()

            With cmdUpdate

                .Parameters("@Folio").Value = Folio
                .Parameters("@Usuario").Value = oParent.ApplicationContext.Security.CurrentUser.Name
                .Parameters("@CodAlmacen").Value = oParent.ApplicationContext.ApplicationConfiguration.Almacen
                .Parameters("@CodCaja").Value = oParent.ApplicationContext.ApplicationConfiguration.NoCaja
                'Execute Command
                .ExecuteNonQuery()
            End With

            cnnString.Close()

        Catch oSqlException As SqlException

            If (cnnString.State <> ConnectionState.Closed) Then
                Try
                    cnnString.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("El registro no pudo ser insertado debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (cnnString.State <> ConnectionState.Closed) Then
                Try
                    cnnString.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("El registro no pudo ser insertado debido a un error de aplicación.", ex)

        End Try

        cnnString.Dispose()
        cnnString = Nothing
    End Sub

    Public Function BuscarFolio(ByVal Folio As Integer) As Integer
        Dim cnnString As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString)
        Dim cmdBuscar As SqlCommand
        Dim drBuscar As SqlDataReader
        Dim Foliofound As Integer = 0

        cmdBuscar = New SqlCommand
        With cmdBuscar
            .Connection = cnnString
            .CommandText = "BuscarFolioNotaVenta"
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioVentaManual", System.Data.SqlDbType.Int, 8))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar, 2))

            .Parameters("@CodAlmacen").Value = oParent.ApplicationContext.ApplicationConfiguration.Almacen
            .Parameters("@CodCaja").Value = oParent.ApplicationContext.ApplicationConfiguration.NoCaja
            .Parameters("@FolioVentaManual").Value = Folio
        End With
        Try
            cnnString.Open()
            'drBuscar = cmdBuscar.ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)
            drBuscar = cmdBuscar.ExecuteReader()
            drBuscar.Read()
            If (drBuscar.HasRows) Then
                Foliofound = 1
            Else
                Foliofound = 0
                drBuscar.Close()
                cnnString.Close()
            End If

        Catch oSqlException As SqlException
            If (cnnString.State <> ConnectionState.Closed) Then
                Try
                    cnnString.Close()
                Catch
                End Try
            End If
            Throw New ApplicationException("El registro no pudo ser leido debido a un error de base de datos.", oSqlException)

        Catch ex As Exception
            If (cnnString.State <> ConnectionState.Closed) Then
                Try
                    cnnString.Close()
                Catch
                End Try
            End If
            Throw New ApplicationException("El registro no pudo ser leido debido a un error de aplicación.", ex)
        End Try

        cnnString.Dispose()
        cnnString = Nothing

        Return Foliofound
    End Function
    Public Function GetLimiteInferior() As Integer
        Dim cnnString As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString)
        Dim cmdGetLimite As SqlCommand
        Dim drGetLimite As SqlDataReader
        Dim LimiteInferior As Integer

        cmdGetLimite = New SqlCommand


        With cmdGetLimite
            .Connection = cnnString
            .CommandText = "GetLastFolioNotaManual"
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar, 2))

            'Asignacion de valores a los parametros
            .Parameters("@CodAlmacen").Value = oParent.ApplicationContext.ApplicationConfiguration.Almacen
            .Parameters("@CodCaja").Value = oParent.ApplicationContext.ApplicationConfiguration.NoCaja
        End With

        Try
            cnnString.Open()
            drGetLimite = cmdGetLimite.ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)
            drGetLimite.Read()
            If (drGetLimite.HasRows) Then
                LimiteInferior = CInt(drGetLimite("FolioVentaManual"))
            Else
                LimiteInferior = 0
            End If
            drGetLimite.Close()
            cnnString.Close()

        Catch oSqlException As SqlException
            If (cnnString.State <> ConnectionState.Closed) Then
                Try
                    cnnString.Close()
                Catch
                End Try
            End If
            Throw New ApplicationException("El registro no pudo ser leido debido a un error de base de datos.", oSqlException)

        Catch ex As Exception
            If (cnnString.State <> ConnectionState.Closed) Then
                Try
                    cnnString.Close()
                Catch
                End Try
            End If
            Throw New ApplicationException("El registro no pudo ser leido debido a un error de aplicación.", ex)
        End Try

        cnnString.Dispose()
        cnnString = Nothing

        Return LimiteInferior


    End Function
    Public Function GetLimiteInferiorInicioCaja() As Integer
        Dim cnnString As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString)
        Dim cmdGetLimite As SqlCommand
        Dim drGetLimite As SqlDataReader
        Dim LimiteInferior As Integer

        cmdGetLimite = New SqlCommand


        With cmdGetLimite
            .Connection = cnnString
            .CommandText = "GetLastFolioNotaManualInicioCaja"
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar, 2))

            'Asignacion de valores a los parametros
            .Parameters("@CodAlmacen").Value = oParent.ApplicationContext.ApplicationConfiguration.Almacen
            .Parameters("@CodCaja").Value = oParent.ApplicationContext.ApplicationConfiguration.NoCaja
        End With

        Try
            cnnString.Open()
            drGetLimite = cmdGetLimite.ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)
            drGetLimite.Read()
            If (drGetLimite.HasRows) Then
                LimiteInferior = CInt(CStr(drGetLimite("FolioVentaManual")))
            Else
                LimiteInferior = 0
            End If
            drGetLimite.Close()
            cnnString.Close()

        Catch oSqlException As SqlException
            If (cnnString.State <> ConnectionState.Closed) Then
                Try
                    cnnString.Close()
                Catch
                End Try
            End If
            Throw New ApplicationException("El registro no pudo ser leido debido a un error de base de datos.", oSqlException)

        Catch ex As Exception
            If (cnnString.State <> ConnectionState.Closed) Then
                Try
                    cnnString.Close()
                Catch
                End Try
            End If
            Throw New ApplicationException("El registro no pudo ser leido debido a un error de aplicación.", ex)
        End Try

        cnnString.Dispose()
        cnnString = Nothing

        Return LimiteInferior


    End Function
    Public Function GetAll(ByVal strTipoajuste As String) As DataSet
        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                               GetConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaAjustes As SqlDataAdapter
        Dim dsAjustes As DataSet

        sccmdSelectAll = New SqlCommand
        scdaAjustes = New SqlDataAdapter
        dsAjustes = New DataSet("Ajustes")

        With sccmdSelectAll

            .Connection = sccnnConnection

            If strTipoajuste = "E" Then
                .CommandText = "[AjustesEntradaSelAll]"
            Else
                .CommandText = "[AjustesSalidaSelAll]"
            End If

            .CommandType = System.Data.CommandType.StoredProcedure

            '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@OnlyEnabledRecords", System.Data.SqlDbType.Bit, 1))

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        End With

        scdaAjustes.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            'Fill DataSet
            scdaAjustes.Fill(dsAjustes, "Ajustes")

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

        Return dsAjustes


    End Function

    Public Function GetExistencias(ByVal strCodArticulo As String, ByVal strTalla As String) As Decimal
        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        Dim decLibres As Decimal


        sccmdSelect = New SqlCommand

        With sccmdSelect
            .Connection = sccnnConnection
            .CommandText = "[ExistenciasAjustesSel]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodArticulo", System.Data.SqlDbType.VarChar, 20))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@talla", System.Data.SqlDbType.VarChar, 4))
        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect
                .Parameters("@CodArticulo").Value = strCodArticulo
                .Parameters("@Talla").Value = strTalla
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)
                scdrReader.Read()
                If (scdrReader.HasRows) Then
                    decLibres = scdrReader.GetDecimal(0)
                Else
                    scdrReader.Close()
                    sccnnConnection.Close()
                    decLibres = 0
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

        Return decLibres

    End Function
    Friend Function SelectFechaServidor() As DateTime

        Dim oResult As DateTime

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                GetConnectionString)

        Dim daFecha As SqlDataAdapter
        Dim sccmdSelect As SqlCommand
        Dim dsFecha As DataSet = New DataSet("Fecha")

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "SELECT GETDATE()AS FECHA"
            .CommandType = CommandType.Text

        End With

        daFecha = New SqlDataAdapter(sccmdSelect)

        Try

            sccnnConnection.Open()

            'Llenamos el Dataset
            daFecha.Fill(dsFecha)

            oResult = dsFecha.Tables(0).Rows(0).Item("Fecha")

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

        Return oResult

    End Function
#End Region

#Region "Reporte"

    Public Function [SelectToReporte](ByVal FechaDel As DateTime, ByVal FechaAl As DateTime) As DataSet

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                                 DataStorageConfiguration.GetConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaEstados As SqlDataAdapter
        Dim dsEstados As DataSet

        sccmdSelectAll = New SqlCommand
        scdaEstados = New SqlDataAdapter
        dsEstados = New DataSet("AjusteGeneral")

        With sccmdSelectAll

            .Connection = sccnnConnection

            .CommandText = "[ReporteAjusteGeneral]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaDel", System.Data.SqlDbType.DateTime, 8))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaAl", System.Data.SqlDbType.DateTime, 8))

        End With

        scdaEstados.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            scdaEstados.SelectCommand.Parameters("@CodAlmacen").Value = oParent.ApplicationContext.ApplicationConfiguration.Almacen
            scdaEstados.SelectCommand.Parameters("@FechaDel").Value = FechaDel
            scdaEstados.SelectCommand.Parameters("@FechaAl").Value = FechaAl
            'Fill DataSet
            scdaEstados.Fill(dsEstados, "AjusteGeneral")

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

        Return dsEstados

    End Function

#End Region


End Class
