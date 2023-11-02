Imports System.Data.SqlClient
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos

Public Class AjusteGeneralTallaGateway

    Private oParent As AjusteGeneralTallaManager

#Region "Constructors / Destructors"

    Public Sub New(ByVal Parent As AjusteGeneralTallaManager)

        oParent = Parent

    End Sub

#End Region

#Region "Methods"

    Public Sub Insert(ByVal pAjusteGeneral As AjusteGeneralTallaInfo, Optional ByVal NotaCreditoID As Integer = 0, _
        Optional ByVal bolMenuUtilerias As Boolean = False)

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                                 DataStorageConfiguration.GetConnectionString)

        'Insertamos General
        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand

        Dim sccmdInsertDetail As SqlCommand
        sccmdInsertDetail = New SqlCommand

        Dim dtAjustesTallaPend As DataTable
        dtAjustesTallaPend = New DataTable("AjustesPendientes")

        If NotaCreditoID <> 0 Then
            dtAjustesTallaPend.Columns.Add("CodArticulo")
            dtAjustesTallaPend.Columns.Add("TallaReal")
            dtAjustesTallaPend.Columns.Add("TallaFactura")
            dtAjustesTallaPend.Columns.Add("Descripcion")
            dtAjustesTallaPend.Columns.Add("FacturaSAP")
            dtAjustesTallaPend.Columns.Add("Cantidad")
        End If

        With sccmdInsert
            .Connection = sccnnConnection
            .CommandText = "[AjusteTallaIns]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Almacen", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TotalCodigos", System.Data.SqlDbType.Int))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Usuario", System.Data.SqlDbType.VarChar, 20))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Observaciones", System.Data.SqlDbType.Text))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioFacturaSAP", System.Data.SqlDbType.VarChar, 10))

            'OutPut :
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Folio", System.Data.SqlDbType.Int))
            .Parameters("@Folio").Direction = ParameterDirection.Output

        End With

        With sccmdInsertDetail
            .Connection = sccnnConnection

            .CommandText = "[AjusteTallaDetalleIns]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioAjuste", System.Data.SqlDbType.Int))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Codigo", System.Data.SqlDbType.VarChar, 20))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Descripcion", System.Data.SqlDbType.VarChar, 50))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TallaS", System.Data.SqlDbType.VarChar, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TallaE", System.Data.SqlDbType.VarChar, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioSap", System.Data.SqlDbType.VarChar, 16))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Cantidad", System.Data.SqlDbType.Int, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Reversa", System.Data.SqlDbType.Bit, 1))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Tipo", System.Data.SqlDbType.VarChar, 2))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CantDev", System.Data.SqlDbType.Int, 4))

            'OutPut :
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Folio", System.Data.SqlDbType.Int))
            .Parameters("@Folio").Direction = ParameterDirection.Output

        End With

        Try
            sccnnConnection.Open()
            'Insertamos Datos Generales
            With sccmdInsert
                'Assign Parameters Values
                .Parameters("@Almacen").Value = oParent.ApplicationContext.ApplicationConfiguration.Almacen
                .Parameters("@TotalCodigos").Value = pAjusteGeneral.TotalCodigos
                .Parameters("@Usuario").Value = oParent.ApplicationContext.Security.CurrentUser.Name
                .Parameters("@Observaciones").Value = pAjusteGeneral.Observaciones
                .Parameters("@FolioFacturaSAP").Value = pAjusteGeneral.FolioFacturaSAP
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
                        .Parameters("@TallaS").Value = dRow!TallaS
                        .Parameters("@TallaE").Value = dRow!TallaE
                        .Parameters("@FolioSAP").Value = dRow!FolioSAp
                        .Parameters("@Cantidad").Value = dRow!Cantidad
                        .Parameters("@Reversa").Value = dRow!Reversa
                        .Parameters("@Tipo").Value = dRow!Tipo
                        .Parameters("@CantDev").Value = CInt(dRow!CantDevuelta)
                        .ExecuteNonQuery()
                        dRow!Folio = .Parameters("@Folio").Value
                        If bolMenuUtilerias = True Then
                            oParent.UpdateStatusAjustesAutomaticosPendientes(dRow!Codigo, dRow!TallaE)
                        End If
                    ElseIf NotaCreditoID <> 0 Then
                        Dim oRow As DataRow = dtAjustesTallaPend.NewRow
                        oRow!CodArticulo = dRow!Codigo
                        oRow!TallaReal = dRow!TallaE
                        oRow!TallaFactura = dRow!TallaS
                        oRow!Descripcion = dRow!Descripcion
                        oRow!FacturaSAP = pAjusteGeneral.FolioFacturaSAP
                        oRow!Cantidad = dRow!Cantidad
                        dtAjustesTallaPend.Rows.Add(oRow)
                    End If
                Next

                If NotaCreditoID <> 0 Then
                    oParent.SaveAjustesAutomaticosPendientes(dtAjustesTallaPend, NotaCreditoID)
                End If

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

    Public Sub LoadInto(ByVal intFolioAjuste As Integer, ByVal oAjusteGeneralInfo As AjusteGeneralTallaInfo)

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                         DataStorageConfiguration.GetConnectionString)

        Dim daAjuste As SqlDataAdapter
        Dim daAjusteDetalleTalla As SqlDataAdapter
        Dim dtAjuste As New DataTable

        'Obtenemos General
        Dim sccmdSelect As SqlCommand
        sccmdSelect = New SqlCommand

        Dim sccmdSelectDetail As SqlCommand
        sccmdSelectDetail = New SqlCommand

        With sccmdSelect
            .Connection = sccnnConnection
            .CommandText = "[AjusteTallaSel]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioAjuste", System.Data.SqlDbType.Int))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.Char, 3))
            .Parameters("@FolioAjuste").Value = intFolioAjuste
            .Parameters("@CodAlmacen").Value = oParent.ApplicationContext.ApplicationConfiguration.Almacen
        End With

        With sccmdSelectDetail
            .Connection = sccnnConnection
            .CommandText = "[AjusteTallaDetallesSel]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioAjuste", System.Data.SqlDbType.Int))
            .Parameters("@FolioAjuste").Value = intFolioAjuste
        End With

        daAjuste = New SqlDataAdapter(sccmdSelect)
        daAjusteDetalleTalla = New SqlDataAdapter(sccmdSelectDetail)

        Try

            daAjuste.Fill(dtAjuste)
            If dtAjuste.Rows.Count > 0 Then

                With oAjusteGeneralInfo

                    .FolioAjuste = dtAjuste.Rows(0).Item("Folio")
                    .Almacen = dtAjuste.Rows(0).Item("Almacen")
                    .Observaciones = dtAjuste.Rows(0).Item("Observaciones")
                    .TotalCodigos = dtAjuste.Rows(0).Item("TotalCodigos")
                    .Usuario = dtAjuste.Rows(0).Item("Usuario")
                    .FechaAjuste = dtAjuste.Rows(0).Item("Fecha")

                    .ResetFlagNew()
                    .SetFlagDirty()
                End With
                oAjusteGeneralInfo.Detalle = New DataTable 'Para evitar error de columna calculada
                daAjusteDetalleTalla.Fill(oAjusteGeneralInfo.Detalle)

            Else

                oAjusteGeneralInfo.FolioAjuste = 0
                oAjusteGeneralInfo.Detalle = New DataTable 'Para evitar error de columna calculada
                daAjusteDetalleTalla.Fill(oAjusteGeneralInfo.Detalle)
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
        daAjusteDetalleTalla.Dispose()

        daAjuste = Nothing
        daAjusteDetalleTalla = Nothing

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

    End Sub

    Public Function GetFolioAjuste() As Integer

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        Dim intFolio As Integer


        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[AjusteTallaFolio]"

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

    Public Sub InsertMovimiento(ByVal oAjusteInfo As AjusteGeneralTallaInfo, ByVal strMov As String)

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
                        '107	ENT AJUSTE CAMBIO TALLA	E
                        '207	SAL AJUSTE CAMBIO TALLA	S
                        If strMov = "E" Then
                            .Parameters("@CodTipoMov").Value = "107"
                            .Parameters("@TipoMovimiento").Value = "E"
                        Else
                            .Parameters("@CodTipoMov").Value = "207"
                            .Parameters("@TipoMovimiento").Value = "S"
                        End If

                        .Parameters("@StatusMov").Value = "A"

                        .Parameters("@CodAlmacen").Value = oParent.ApplicationContext.ApplicationConfiguration.Almacen
                        .Parameters("@Destino").Value = oParent.ApplicationContext.ApplicationConfiguration.Almacen
                        .Parameters("@Folio").Value = oAjusteInfo.FolioAjuste
                        .Parameters("@FolioSAP").Value = "0"
                        .Parameters("@CodArticulo").Value = dRow!Codigo
                        .Parameters("@Descripcion").Value = dRow!Descripcion
                        If strMov = "E" Then
                            .Parameters("@Numero").Value = dRow!TallaE
                        Else
                            .Parameters("@Numero").Value = dRow!TallaS
                        End If
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

    Public Function GetAll() As DataSet
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
            .CommandText = "[AjusteTallaSelAll]"
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

    Public Function ValidarExistenciasCambiosTalla(ByVal FolioSAP As String, ByVal TallaS As String, ByVal CodArticulo As String, _
                                                   ByVal CantDev As Integer) As Boolean

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim Exis As Boolean

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[AjusteTallaDetalleValidarExistenciasCambioTallas]"
            .CommandType = System.Data.CommandType.StoredProcedure

            '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Talla", System.Data.SqlDbType.VarChar, 4, "TallaS"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioSAP", System.Data.SqlDbType.VarChar, 10, "FolioSAP"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodArticulo", System.Data.SqlDbType.VarChar, 20, "CodArticulo"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Cantidad", System.Data.SqlDbType.VarChar, 20, "CodArticulo"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CantSuficientes", System.Data.SqlDbType.Bit, 1))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Exis", System.Data.SqlDbType.Bit, 1))

            .Parameters("@Exis").Direction = ParameterDirection.Output
            .Parameters("@CantSuficientes").Direction = ParameterDirection.Output

        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect

                .Parameters("@Talla").Value = TallaS
                .Parameters("@FolioSAP").Value = FolioSAP
                .Parameters("@CodArticulo").Value = CodArticulo
                .Parameters("@Cantidad").Value = CantDev

                .ExecuteNonQuery()

                If .Parameters("@Exis").Value = True Then
                    If .Parameters("@CantSuficientes").Value = True Then
                        Exis = True
                    Else
                        MsgBox("No hay existencias suficientes para el codigo " & CodArticulo & " en la talla " & TallaS, MsgBoxStyle.Exclamation, "Dportenis Pro")
                        Exis = False
                    End If
                Else
                    MsgBox("El codigo " & CodArticulo & " en la talla " & TallaS & " no existe en la factura " & FolioSAP, MsgBoxStyle.Exclamation, "Dportenis Pro")
                    Exis = False
                End If

                'Fill DataSet
                'scdaNotaCredito.Fill(dsNotaCredito, "NotasCreditoCambioTalla")

            End With

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

        Return Exis

    End Function

    Public Sub SaveAjustesAutomaticosPendientes(ByVal dtAjustesPendientes As DataTable, ByVal NotaCreditoID As Integer)

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                                 DataStorageConfiguration.GetConnectionString)

        Dim sccmdInsertDetail As SqlCommand
        sccmdInsertDetail = New SqlCommand

        With sccmdInsertDetail
            .Connection = sccnnConnection

            .CommandText = "[AjustesTallaAutomaticosPendientesIns]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodArticulo", System.Data.SqlDbType.VarChar, 20))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Descripcion", System.Data.SqlDbType.VarChar, 50))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TallaReal", System.Data.SqlDbType.VarChar, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TallaFactura", System.Data.SqlDbType.VarChar, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FacturaSAP", System.Data.SqlDbType.VarChar, 10))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Cantidad", System.Data.SqlDbType.Int, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@NotaCreditoID", System.Data.SqlDbType.Int, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Status", System.Data.SqlDbType.Bit, 1))

            'OutPut :
            '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Folio", System.Data.SqlDbType.Int))
            '.Parameters("@Folio").Direction = ParameterDirection.Output

        End With

        Try
            sccnnConnection.Open()

            'Insertamos
            With sccmdInsertDetail

                Dim dRow As DataRow

                For Each dRow In dtAjustesPendientes.Rows
                    .Parameters("@CodArticulo").Value = dRow!CodArticulo
                    .Parameters("@Descripcion").Value = dRow!Descripcion
                    .Parameters("@TallaReal").Value = dRow!TallaReal
                    .Parameters("@TallaFactura").Value = dRow!TallaFactura
                    .Parameters("@FacturaSAP").Value = dRow!FacturaSAP
                    .Parameters("@Cantidad").Value = dRow!Cantidad
                    .Parameters("@NotaCreditoID").Value = NotaCreditoID
                    .Parameters("@Status").Value = True

                    .ExecuteNonQuery()

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

    Public Function SelectAjustesPendNCAll() As DataTable

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                         DataStorageConfiguration.GetConnectionString)

        Dim daAjusteDetalleTalla As SqlDataAdapter
        Dim dtAjustesTallaPend As New DataTable

        Dim sccmdSelectDetail As SqlCommand
        sccmdSelectDetail = New SqlCommand

        With sccmdSelectDetail
            .Connection = sccnnConnection
            .CommandText = "[AjustesTallaAutomaticosPendientesSelNCAll]"
            .CommandType = System.Data.CommandType.StoredProcedure
            '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NotaCreditoID", System.Data.SqlDbType.Int, 4))

        End With

        daAjusteDetalleTalla = New SqlDataAdapter(sccmdSelectDetail)

        Try

            sccnnConnection.Open()

            daAjusteDetalleTalla.Fill(dtAjustesTallaPend)

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

        daAjusteDetalleTalla.Dispose()
        daAjusteDetalleTalla = Nothing

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return dtAjustesTallaPend

    End Function

    Public Function SelectAjustesPendByNCID_All(ByVal NotaCreditoID As Integer) As DataTable

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                         DataStorageConfiguration.GetConnectionString)

        Dim daAjusteDetalleTalla As SqlDataAdapter
        Dim dtAjustesTallaPend As New DataTable

        Dim sccmdSelectDetail As SqlCommand
        sccmdSelectDetail = New SqlCommand

        With sccmdSelectDetail
            .Connection = sccnnConnection
            .CommandText = "[AjustesTallaAutomaticosPendientesSelByNCID_All]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@NotaCreditoID", System.Data.SqlDbType.Int, 4))

        End With

        daAjusteDetalleTalla = New SqlDataAdapter(sccmdSelectDetail)

        Try

            sccnnConnection.Open()

            sccmdSelectDetail.Parameters("@NotaCreditoID").Value = NotaCreditoID

            daAjusteDetalleTalla.Fill(dtAjustesTallaPend)

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

        daAjusteDetalleTalla.Dispose()
        daAjusteDetalleTalla = Nothing

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return dtAjustesTallaPend

    End Function

    Public Sub UpdateStatusAjustesAutomaticosPendientes(ByVal CodArticulo As String, ByVal TallaReal As String)

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                                 DataStorageConfiguration.GetConnectionString)

        Dim sccmdUpdate As SqlCommand
        sccmdUpdate = New SqlCommand

        With sccmdUpdate
            .Connection = sccnnConnection

            .CommandText = "[AjustesTallaAutomaticosPendientesUpdStatus]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodArticulo", System.Data.SqlDbType.VarChar, 20, "CodArticulo"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TallaReal", System.Data.SqlDbType.VarChar, 4, "TallaReal"))

        End With

        Try
            sccnnConnection.Open()

            'Borramos
            With sccmdUpdate

                .Parameters("@CodArticulo").Value = CodArticulo
                .Parameters("@TallaReal").Value = TallaReal

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

            Throw New ApplicationException("El registro no pudo ser eliminado debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("El registro no pudo ser eliminado debido a un error de aplicación.", ex)

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

    End Sub

#End Region

End Class
