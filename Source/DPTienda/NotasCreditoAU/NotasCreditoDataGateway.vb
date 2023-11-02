Imports System.Data.SqlClient
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos
Imports DportenisPro.DPTienda.ApplicationUnits.Asociados
'Imports DportenisPro.DPTienda.ApplicationUnits.NotasCreditoAU.wsAsociados
'Imports DportenisPro.DPTienda.ApplicationUnits.NotasCreditoAU.wsCreditoDPVale
'Imports DportenisPro.DPTienda.ApplicationUnits.NotasCreditoAU.wsEstadoCuentaAsociado
Imports DportenisPro.DPTienda.ApplicationUnits.Facturas
Imports DportenisPro.DPTienda.ApplicationUnits.TiposVenta
Imports DportenisPro.DPTienda.ApplicationUnits.Clientes
'Imports DportenisPro.DPTienda.ApplicationUnits.AbonoCreditoDirectoTienda.wsAbonoCreditoDirecto

Imports System.DBNull

'Imports SAP
Imports DportenisPro.DPTienda.ApplicationUnits.ConfiguracionSAPAU
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU

Imports System.IO
Imports System.Web.Mail
Imports System.Web.Util

Public Class NotasCreditoDataGateway
    ' AF (14-11-2016): Notas de credito masivas
    Protected oParent As NotasCreditoManager
    Protected oSapCentro As ProcesoSAPManager
    Protected oAbonoCreditoDirecto As AbonoCreditoDirectoTienda.AbonoCreditoDirectoManager
    Protected oDPVale As cDPVale
    ' AF (14-11-2016): Notas de credito masivas
    Private RestService As ProcesosRetail

#Region "Constructors / Destructors"

    Public Sub New(ByVal Parent As NotasCreditoManager)
        oParent = Parent
        oSapCentro = New ProcesoSAPManager(oParent.ApplicationContext, oParent.SAPApplicationConfig)
        oAbonoCreditoDirecto = New AbonoCreditoDirectoTienda.AbonoCreditoDirectoManager(Parent.ApplicationContext)

    End Sub

#End Region


#Region "Constants"

    'Const strTablaTmp As String = "NotaCreditoDetalleTmp" & oParent.ApplicationContext.ApplicationConfiguration.Almacen & oParent.ApplicationContext.ApplicationConfiguration.NoCaja & oParent.ApplicationContext.Security.CurrentUser.ID

#End Region


#Region "Properties"

    Public Property Parent() As NotasCreditoManager

        Get

            Return oParent

        End Get


        Set(ByVal Value As NotasCreditoManager)

            oParent = Value

        End Set

    End Property

#End Region


#Region "Methods"


    Public Sub InsertaValeCajaDPVL(ByVal ValeCajaID As Integer, ByVal DocFI As String)

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                                 DataStorageConfiguration.GetConnectionString)

        Dim sccmdUpdate As SqlCommand
        sccmdUpdate = New SqlCommand

        With sccmdUpdate

            .Connection = sccnnConnection
            .CommandText = "[ValeCajaDPVLIns]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ValeCajaID", System.Data.SqlDbType.Int, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FIDEVOLUCION", System.Data.SqlDbType.VarChar, 10))


        End With

        Try

            sccnnConnection.Open()

            With sccmdUpdate
                'Assign Parameters Values
                .Parameters("@ValeCajaID").Value = ValeCajaID
                .Parameters("@FIDEVOLUCION").Value = DocFI

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

            MsgBox(oSqlException.Message & "No pudo ser insertado el FIDOCUMENT debido a un error de base de datos", MsgBoxStyle.Information, "Dptienda")

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If
            MsgBox(ex.Message & "No pudo ser insertado el FIDOCUMENT debido a un error de aplicación", MsgBoxStyle.Information, "Dptienda")


        End Try


        sccmdUpdate.Dispose()
        sccmdUpdate = Nothing

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

    End Sub

    Public Function [Select](ByVal pNotaCreditoID As Integer) As NotaCredito

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        Dim dsDataSet As DataSet
        dsDataSet = New DataSet("Apartados")

        Dim oNotaCredito As New NotaCredito(oParent)



        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[NotasCreditoSel]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@NotaCreditoID", System.Data.SqlDbType.Int))

        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect
                'Assign Parameters Values
                .Parameters("@NotaCreditoID").Value = pNotaCreditoID

                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    'Traspaso General :
                    With scdrReader

                        oNotaCredito.ID = .GetInt32(0)
                        oNotaCredito.AlmacenID = .GetString(1)
                        oNotaCredito.CajaID = .GetString(2)
                        oNotaCredito.NotaCreditoFolio = .GetInt32(3)
                        oNotaCredito.FolioApartado = .GetString(4)
                        oNotaCredito.TipoDevolucionID = .GetString(5)
                        oNotaCredito.ClienteID = .GetString(6)

                        oNotaCredito.Importe = .GetDecimal(7)
                        oNotaCredito.IVA = .GetDecimal(8)

                        oNotaCredito.Aplicada = .GetString(9)
                        oNotaCredito.DevDinero = .GetString(10)
                        oNotaCredito.Observaciones = .GetString(11)
                        oNotaCredito.Usuario = .GetString(12)
                        oNotaCredito.Fecha = .GetDateTime(13)
                        oNotaCredito.StatusRegistro = .GetBoolean(14)

                        oNotaCredito.PlayerID = .GetString(15)

                        oNotaCredito.TipoVentaID = .GetString(16)

                        'Implementar Valores SAP
                        oNotaCredito.SALESDOCUMENT = .GetString(.GetOrdinal("SALESDOCUMENT"))
                        oNotaCredito.FIDOCUMENT = .GetString(.GetOrdinal("FIDOCUMENT"))

                        oNotaCredito.ClientePGID = .GetInt32(.GetOrdinal("ClientePGID"))
                        oNotaCredito.FolioSAP = .GetString(.GetOrdinal("FolioSAP")).Trim
                        oNotaCredito.Referencia = CStr(scdrReader("Referencia"))

                        .Close()

                    End With


                    'Nota Credito Detalle [GRID] :

                    Dim scdaAdapter As New SqlDataAdapter

                    sccmdSelect.Dispose()
                    sccmdSelect = Nothing

                    sccmdSelect = New SqlCommand

                    With sccmdSelect

                        .Connection = sccnnConnection

                        .CommandText = "[NotasCreditoDetalleSel]"
                        .CommandType = System.Data.CommandType.StoredProcedure

                        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
                        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@NotaCreditoID", System.Data.SqlDbType.Int))

                        .Parameters("@NotaCreditoID").Value = pNotaCreditoID

                    End With

                    scdaAdapter.SelectCommand = sccmdSelect
                    scdaAdapter.Fill(dsDataSet, "NotasCreditoDetalle")

                    oNotaCredito.Detalle = dsDataSet

                    dsDataSet.Dispose()
                    sccmdSelect.Dispose()
                    scdaAdapter.Dispose()

                    dsDataSet = Nothing
                    sccmdSelect = Nothing
                    scdaAdapter = Nothing

                    oNotaCredito.ResetFlagNew()
                    oNotaCredito.ResetFlagDirty()

                Else
                    oNotaCredito = Nothing
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

        Return oNotaCredito

    End Function

    Public Function [Select](ByVal FolioSAP As String) As NotaCredito

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader
        Dim dsDataSet As New DataSet("NotasCreditoDetalle")
        Dim oNotaCredito As New NotaCredito(oParent)

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[NotasCreditoSelByFolioSAP]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioSAP", System.Data.SqlDbType.VarChar, 10, "FolioSAP"))

        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect
                'Assign Parameters Values
                .Parameters("@FolioSAP").Value = FolioSAP.Trim.PadLeft(10, "0")

                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    'Traspaso General :
                    With scdrReader

                        oNotaCredito.ID = .GetInt32(0)
                        oNotaCredito.AlmacenID = .GetString(1)
                        oNotaCredito.CajaID = .GetString(2)
                        oNotaCredito.NotaCreditoFolio = .GetInt32(3)
                        oNotaCredito.FolioApartado = .GetString(4)
                        oNotaCredito.TipoDevolucionID = .GetString(5)
                        oNotaCredito.ClienteID = .GetString(6)

                        oNotaCredito.Importe = .GetDecimal(7)
                        oNotaCredito.IVA = .GetDecimal(8)

                        oNotaCredito.Aplicada = .GetString(9)
                        oNotaCredito.DevDinero = .GetString(10)
                        oNotaCredito.Observaciones = .GetString(11)
                        oNotaCredito.Usuario = .GetString(12)
                        oNotaCredito.Fecha = .GetDateTime(13)
                        oNotaCredito.StatusRegistro = .GetBoolean(14)

                        oNotaCredito.PlayerID = .GetString(15)

                        oNotaCredito.TipoVentaID = .GetString(16)

                        'Implementar Valores SAP
                        oNotaCredito.SALESDOCUMENT = .GetString(.GetOrdinal("SALESDOCUMENT"))
                        oNotaCredito.FIDOCUMENT = .GetString(.GetOrdinal("FIDOCUMENT"))

                        oNotaCredito.ClientePGID = .GetInt32(.GetOrdinal("ClientePGID"))
                        oNotaCredito.FolioSAP = .GetString(.GetOrdinal("FolioSAP")).Trim

                        .Close()

                    End With


                    'Nota Credito Detalle [GRID] :

                    Dim scdaAdapter As New SqlDataAdapter

                    sccmdSelect.Dispose()
                    sccmdSelect = Nothing

                    sccmdSelect = New SqlCommand

                    With sccmdSelect

                        .Connection = sccnnConnection

                        .CommandText = "[NotasCreditoDetalleSel]"
                        .CommandType = System.Data.CommandType.StoredProcedure

                        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
                        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@NotaCreditoID", System.Data.SqlDbType.Int))

                        .Parameters("@NotaCreditoID").Value = oNotaCredito.ID

                    End With

                    scdaAdapter.SelectCommand = sccmdSelect
                    scdaAdapter.Fill(dsDataSet, "NotasCreditoDetalle")

                    oNotaCredito.Detalle = dsDataSet

                    dsDataSet.Dispose()
                    sccmdSelect.Dispose()
                    scdaAdapter.Dispose()

                    dsDataSet = Nothing
                    sccmdSelect = Nothing
                    scdaAdapter = Nothing

                    oNotaCredito.ResetFlagNew()
                    oNotaCredito.ResetFlagDirty()

                Else
                    oNotaCredito = Nothing
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

        Return oNotaCredito

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
    Public Function SelectAll(ByVal EnabledRecordsOnly As Boolean) As DataSet

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaNotaCredito As SqlDataAdapter
        Dim dsNotaCredito As DataSet

        sccmdSelectAll = New SqlCommand
        scdaNotaCredito = New SqlDataAdapter
        dsNotaCredito = New DataSet

        With sccmdSelectAll

            .Connection = sccnnConnection

            .CommandText = "[NotasCreditoSelAll]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@OnlyEnabledRecords", System.Data.SqlDbType.Bit, 1))

        End With

        scdaNotaCredito.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            scdaNotaCredito.SelectCommand.Parameters("@OnlyEnabledRecords").Value = EnabledRecordsOnly

            'Fill DataSet
            scdaNotaCredito.Fill(dsNotaCredito, "NotasCredito")

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

        Return dsNotaCredito

    End Function

    Public Function ValidarCambiosTalla(ByVal FolioSAP As String, ByVal TallaS As String, _
                                        ByVal CodArticulo As String, ByVal CantDev As Integer) As String

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim TallaE As String
        Dim FoliosReversa As String
        Dim FoliosCant As String

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[NotaCreditoDetalleValidaCambiosTalla]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioSAP", System.Data.SqlDbType.VarChar, 10, "FolioSAP"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TallaS", System.Data.SqlDbType.VarChar, 4, "TallaS"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodArticulo", System.Data.SqlDbType.VarChar, 20, "CodArticulo"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CantDev", System.Data.SqlDbType.Int, 4, "CantDev"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TallaE", System.Data.SqlDbType.VarChar, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FoliosAjustes", System.Data.SqlDbType.VarChar, 50))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FoliosCant", System.Data.SqlDbType.VarChar, 50))

            .Parameters("@TallaE").Direction = ParameterDirection.Output
            .Parameters("@FoliosAjustes").Direction = ParameterDirection.Output
            .Parameters("@FoliosCant").Direction = ParameterDirection.Output
        End With


        Try

            sccnnConnection.Open()

            With sccmdSelect

                .Parameters("@FolioSAP").Value = FolioSAP
                .Parameters("@TallaS").Value = TallaS
                .Parameters("@CodArticulo").Value = CodArticulo
                .Parameters("@CantDev").Value = CantDev

                .ExecuteNonQuery()

                TallaE = .Parameters("@TallaE").Value
                FoliosReversa = .Parameters("@FoliosAjustes").Value
                FoliosCant = .Parameters("@FoliosCant").Value

                If TallaE <> "" Then
                    TallaE = TallaE & "°" & FoliosReversa & "°" & FoliosCant
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

        Return TallaE

    End Function

    Public Sub DesmarcarReversa_AjustarCantDevuelta(ByVal Folios As String)

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdUpdate As SqlCommand
        'Dim FoliosAjustes As String

        sccmdUpdate = New SqlCommand

        With sccmdUpdate

            .Connection = sccnnConnection

            .CommandText = "[NotaCreditoDetalleDesmarcarFolioAjuste]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Folio", System.Data.SqlDbType.Int, 4, "Folio"))

        End With

        Try
            Dim strFoliosRC() As String
            Dim strFoliosReversa() As String
            Dim strFoliosCant() As String

            strFoliosRC = Folios.Split("°")
            strFoliosCant = strFoliosRC(1).Split("_")

            If strFoliosRC(0) <> "" Then

                strFoliosReversa = strFoliosRC(0).Split("_")

                sccnnConnection.Open()

                With sccmdUpdate

                    For i As Integer = 0 To strFoliosReversa.Length - 1

                        .Parameters("@Folio").Value = CInt(strFoliosReversa(i))

                        .ExecuteNonQuery()

                    Next

                End With

                sccnnConnection.Close()

            End If

            sccmdUpdate.Dispose()
            sccmdUpdate = Nothing

            sccmdUpdate = New SqlClient.SqlCommand

            With sccmdUpdate

                .Connection = sccnnConnection

                .CommandText = "[NotaCreditoDetalleAjustarCantidadDevuelta]"
                .CommandType = CommandType.StoredProcedure

                .Parameters.Add(New SqlParameter("@Folio", System.Data.SqlDbType.Int, 4, "Folio"))
                .Parameters.Add(New SqlParameter("@Cantidad", System.Data.SqlDbType.Int, 4, "Cantidad"))

            End With

            Dim strFolioCantidad As String()

            sccnnConnection.Open()

            With sccmdUpdate

                For i As Integer = 0 To strFoliosCant.Length - 1

                    strFolioCantidad = strFoliosCant(i).Split(",")
                    .Parameters("@Folio").Value = CInt(strFolioCantidad(0))
                    .Parameters("@Cantidad").Value = CInt(strFolioCantidad(1))

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

    Public Sub SelectFolioNC(ByVal pNotaCredito As NotaCredito)


        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                                 DataStorageConfiguration.GetConnectionString)

        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand

        Dim oClientesMgr As New ClientesManager(oParent.ApplicationContext)
        Dim oCliente As DportenisPro.DPTienda.ApplicationUnits.Clientes.Clientes


        With sccmdInsert

            .Connection = sccnnConnection

            .CommandText = "[NotasCreditoSelFolioNotaCredito]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar, 2))
            'OutPut :
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioNotaCredito", System.Data.SqlDbType.Int))
            .Parameters("@FolioNotaCredito").Direction = ParameterDirection.Output


        End With

        Try
            sccnnConnection.Open()

            With sccmdInsert
                'Assign Parameters Values

                .Parameters("@CodCaja").Value = oParent.ApplicationContext.ApplicationConfiguration.NoCaja

                'Execute Command
                .ExecuteNonQuery()

                'Actualizar General Contrato.

                pNotaCredito.NotaCreditoFolio = CType(.Parameters("@FolioNotaCredito").Value, Integer)


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

    Public Sub Insert(ByVal pNotaCredito As NotaCredito, ByVal EnvioServerPG As Boolean, ByVal FolioPedido As String, Optional ByRef strError As String = "")

        SelectFolioNC(pNotaCredito)

        '***********************SAP Notas de Credito***********************************
        If pNotaCredito.NCE_RESULT <> "Y" Then

            If oParent.SAPApplicationConfig.DPValeSAP And pNotaCredito.TipoVentaID = "V" Then

                '-----------------------------------------------------------------------------------------
                ' JNAVA (19.02.2015): Validamos lo que se debe de hacer si es del SI Hay o no
                '-----------------------------------------------------------------------------------------
                If FolioPedido.Trim <> "" Then

                    '-----------------------------------------------------------------------------------------
                    ' JNAVA (19.02.2015): Creamos los Documentos en SAP para Devolucion con DPVale SH
                    '-----------------------------------------------------------------------------------------
                    SaveDPVALESAP(pNotaCredito, True, FolioPedido, strError)

                    '-----------------------------------------------------------------------------------------
                    ' JNAVA (19.02.2015): Validamos que los Documentos en SAP se crearon satisfactoriamente
                    '-----------------------------------------------------------------------------------------
                    If pNotaCredito.SALESDOCUMENT.Trim = "" Then 'OrElse pNotaCredito.FIDOCUMENT.Trim = "" Then
                        Exit Sub
                    End If

                    '-----------------------------------------------------------------------------------------
                    ' JNAVA (19.02.2015): Actualizamos DPVale para Devolucion con DPVale SH
                    '-----------------------------------------------------------------------------------------
                    'SaveDPVALESAP(pNotaCredito, True, FolioPedido.Trim, strError)

                Else

                    SaveDPVALESAP(pNotaCredito, , , strError)

                End If

            Else

                SaveSAP(pNotaCredito, strError)

            End If

        End If


        If pNotaCredito.SALESDOCUMENT.Trim = "" Then
            Exit Sub
        End If

        '***********************SAP Notas de Credito***********************************
        Dim logNotaCredito As String = ""
        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                                 DataStorageConfiguration.GetConnectionString)

        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand

        Dim oClientesMgr As New ClientesManager(oParent.ApplicationContext)
        Dim oCliente As DportenisPro.DPTienda.ApplicationUnits.Clientes.Clientes

        Dim referencia As String = ""
        Dim folio As String = "", caja As String = ""
        With sccmdInsert

            .Connection = sccnnConnection

            .CommandText = "[NotasCreditoIns]"
            .CommandType = System.Data.CommandType.StoredProcedure
            '----------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 03/03/2017: Se carga la referencia.
            '----------------------------------------------------------------------------------------------------------------
            For Each row As DataRow In pNotaCredito.Detalle.Tables(0).Rows
                caja = row!CodCaja
                folio = CStr(row("FolioReferencia")).PadLeft(10, "0")
            Next
            referencia = Me.oAbonoCreditoDirecto.GetSelectFolioFacturaSDSAP(folio, caja)
            logNotaCredito &= "CodAlmacen: " & oParent.ApplicationContext.ApplicationConfiguration.Almacen & vbCrLf
            logNotaCredito &= "CodCaja: " & oParent.ApplicationContext.ApplicationConfiguration.NoCaja & vbCrLf
            logNotaCredito &= "FolioApartado: " & CStr(pNotaCredito.FolioApartado) & vbCrLf
            logNotaCredito &= "CodTipoDevolucion: " & CStr(pNotaCredito.TipoDevolucionID) & vbCrLf
            logNotaCredito &= "ClienteID: " & CStr(pNotaCredito.ClienteID).PadLeft(10, "0") & vbCrLf
            logNotaCredito &= "Importe: " & CStr(pNotaCredito.Importe) & vbCrLf
            logNotaCredito &= "IVA: " & CStr(pNotaCredito.IVA) & vbCrLf
            logNotaCredito &= "Aplicada: " & CStr(pNotaCredito.Aplicada) & vbCrLf
            logNotaCredito &= "DevDinero: " & CStr(pNotaCredito.DevDinero) & vbCrLf
            logNotaCredito &= "Observaciones: " & CStr(pNotaCredito.Observaciones) & vbCrLf
            logNotaCredito &= "Usuario: " & CStr(pNotaCredito.Usuario) & vbCrLf
            logNotaCredito &= "StatusRegistro: " & CStr(pNotaCredito.StatusRegistro) & vbCrLf
            logNotaCredito &= "CodVendedor: " & CStr(pNotaCredito.PlayerID) & vbCrLf
            logNotaCredito &= "CodTipoVenta: " & CStr(pNotaCredito.TipoVentaID) & vbCrLf
            logNotaCredito &= "ClientePGID: " & CStr(pNotaCredito.ClientePGID) & vbCrLf
            logNotaCredito &= "FolioSAP: " & CStr(pNotaCredito.FolioSAP) & vbCrLf
            logNotaCredito &= "EnvioServerPG: " & CStr(IIf(EnvioServerPG = True, 0, 1)) & vbCrLf
            logNotaCredito &= "FIDOCUMENT: " & CStr(pNotaCredito.FIDOCUMENT) & vbCrLf
            logNotaCredito &= "SALESDOCUMENT: " & CStr(pNotaCredito.SALESDOCUMENT) & vbCrLf
            logNotaCredito &= "Referencia: " & referencia & vbCrLf
            EscribeLog(logNotaCredito, "Inserción de Notas de Credito")
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar, 2))
            '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioNotaCredito", System.Data.SqlDbType.Int))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioApartado", System.Data.SqlDbType.Char, 10))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodTipoDevolucion", System.Data.SqlDbType.Char, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ClienteID", System.Data.SqlDbType.VarChar, 10))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Importe", System.Data.SqlDbType.Money))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@IVA", System.Data.SqlDbType.Money))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Aplicada", System.Data.SqlDbType.Char, 1))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@DevDinero", System.Data.SqlDbType.Char, 1))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Observaciones", System.Data.SqlDbType.VarChar, 255))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Usuario", System.Data.SqlDbType.VarChar, 12))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@StatusRegistro", System.Data.SqlDbType.Bit))

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodVendedor", System.Data.SqlDbType.VarChar, 12))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodTipoVenta", System.Data.SqlDbType.Char, 1))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ClientePGID", System.Data.SqlDbType.Int, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioSAP", System.Data.SqlDbType.VarChar, 10))

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@EnvioServerPG", System.Data.SqlDbType.Bit, 1))


            'OutPut :
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@NotaCreditoID", System.Data.SqlDbType.Int))
            .Parameters("@NotaCreditoID").Direction = ParameterDirection.Output

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime))
            .Parameters("@Fecha").Direction = ParameterDirection.Output

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioNotaCredito", System.Data.SqlDbType.Int))
            .Parameters("@FolioNotaCredito").Direction = ParameterDirection.Output

            'Implementar Parametros SAP
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FIDOCUMENT", System.Data.SqlDbType.VarChar, 10))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@SALESDOCUMENT", System.Data.SqlDbType.VarChar, 10))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Referencia", System.Data.SqlDbType.VarChar, 20))
            'pnotacredito.FIDOCUMENT 
            'pNotaCredito.SALESDOCUMENT()

        End With

        Try
            sccnnConnection.Open()

            With sccmdInsert
                'Assign Parameters Values

                .Parameters("@CodAlmacen").Value = oParent.ApplicationContext.ApplicationConfiguration.Almacen
                .Parameters("@CodCaja").Value = oParent.ApplicationContext.ApplicationConfiguration.NoCaja
                '.Parameters("@FolioNotaCredito").Value = 
                .Parameters("@FolioApartado").Value = pNotaCredito.FolioApartado
                .Parameters("@CodTipoDevolucion").Value = pNotaCredito.TipoDevolucionID
                .Parameters("@ClienteID").Value = pNotaCredito.ClienteID.PadLeft(10, "0")
                .Parameters("@ClientePGID").Value = pNotaCredito.ClientePGID
                .Parameters("@Importe").Value = pNotaCredito.Importe
                .Parameters("@IVA").Value = pNotaCredito.IVA
                .Parameters("@Aplicada").Value = pNotaCredito.Aplicada
                .Parameters("@DevDinero").Value = pNotaCredito.DevDinero
                .Parameters("@Observaciones").Value = pNotaCredito.Observaciones
                .Parameters("@Usuario").Value = pNotaCredito.Usuario
                .Parameters("@StatusRegistro").Value = pNotaCredito.StatusRegistro

                .Parameters("@CodVendedor").Value = pNotaCredito.PlayerID
                .Parameters("@CodTipoVenta").Value = pNotaCredito.TipoVentaID

                'Implementar Parametros SAP
                .Parameters("@FIDOCUMENT").Value = pNotaCredito.FIDOCUMENT
                .Parameters("@SALESDOCUMENT").Value = pNotaCredito.SALESDOCUMENT

                .Parameters("@FolioSAP").Value = pNotaCredito.FolioSAP
                '-----------------------------------------------------------------------------------------
                ' JNAVA (23.01.2017): Validamos con un If normal
                '-----------------------------------------------------------------------------------------
                '.Parameters("@EnvioServerPG").Value = IIf(EnvioServerPG = True, 0, 1)
                If EnvioServerPG = True Then
                    .Parameters("@EnvioServerPG").Value = 0
                Else
                    .Parameters("@EnvioServerPG").Value = 1
                End If
                '-----------------------------------------------------------------------------------------

                .Parameters("@Referencia").Value = referencia

                'pnotacredito.FIDOCUMENT 
                'pNotaCredito.SALESDOCUMENT()

                'Execute Command
                .ExecuteNonQuery()

                'Actualizar General Contrato.
                pNotaCredito.ID = CType(.Parameters("@NotaCreditoID").Value, Integer)
                pNotaCredito.NotaCreditoFolio = CType(.Parameters("@FolioNotaCredito").Value, Integer)
                pNotaCredito.Fecha = CType(.Parameters("@Fecha").Value, Date)

            End With


            'Contrato Detalle :

            sccmdInsert.Dispose()
            sccmdInsert = Nothing

            sccmdInsert = New SqlCommand

            With sccmdInsert

                .Connection = sccnnConnection

                .CommandText = "[NotasCreditoDetalleIns]"
                .CommandType = System.Data.CommandType.StoredProcedure

                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@NotaCreditoID", System.Data.SqlDbType.Int))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 3))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar, 2))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacenOrigenFact", System.Data.SqlDbType.Char, 10))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioReferencia", System.Data.SqlDbType.VarChar, 10))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ClienteID", System.Data.SqlDbType.VarChar, 10))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodTipoDevolucion", System.Data.SqlDbType.Char, 3))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodArticulo", System.Data.SqlDbType.VarChar, 20))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Descripcion", System.Data.SqlDbType.VarChar, 50))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Numero", System.Data.SqlDbType.VarChar, 4))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Cantidad", System.Data.SqlDbType.Decimal))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CostoUnit", System.Data.SqlDbType.Money))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@PrecioUnit", System.Data.SqlDbType.Money))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Importe", System.Data.SqlDbType.Money))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Impresa", System.Data.SqlDbType.Bit))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Usuario", System.Data.SqlDbType.VarChar, 12))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@StatusRegistro", System.Data.SqlDbType.Bit))

            End With


            Dim odrArticulo As DataRow
            Dim intNumTalla As Integer

            For Each odrArticulo In pNotaCredito.Detalle.Tables(0).Rows

                With sccmdInsert

                    'Assign Parameters Values

                    .Parameters("@NotaCreditoID").Value = pNotaCredito.ID
                    .Parameters("@CodAlmacen").Value = oParent.ApplicationContext.ApplicationConfiguration.Almacen
                    .Parameters("@CodCaja").Value = odrArticulo("CodCaja")
                    .Parameters("@CodAlmacenOrigenFact").Value = oParent.ApplicationContext.ApplicationConfiguration.Almacen
                    .Parameters("@FolioReferencia").Value = odrArticulo("FolioReferencia")
                    .Parameters("@ClienteID").Value = CStr(odrArticulo("ClienteID")).PadLeft(10, "0")
                    .Parameters("@CodTipoDevolucion").Value = pNotaCredito.TipoDevolucionID
                    .Parameters("@CodArticulo").Value = odrArticulo("CodArticulo")
                    .Parameters("@Descripcion").Value = odrArticulo("Descripcion")
                    .Parameters("@Numero").Value = odrArticulo("Numero")
                    .Parameters("@Cantidad").Value = odrArticulo("Cantidad")
                    .Parameters("@CostoUnit").Value = odrArticulo("CostoUnit")
                    .Parameters("@PrecioUnit").Value = odrArticulo("PrecioUnit")
                    .Parameters("@Importe").Value = odrArticulo("Importe")
                    .Parameters("@Impresa").Value = 0
                    .Parameters("@Fecha").Value = pNotaCredito.Fecha
                    .Parameters("@Usuario").Value = pNotaCredito.Usuario
                    .Parameters("@StatusRegistro").Value = 1

                    'Execute Command
                    .ExecuteNonQuery()

                End With

            Next


            With pNotaCredito

                'Actualizar Existencias :

                UpdateInventario(.Detalle, .NotaCreditoFolio, .TipoDevolucionID)

            End With


            'Generar Vale de Caja en SAP





            'Reset New State of Contrato Object 
            pNotaCredito.ResetFlagNew()
            pNotaCredito.ResetFlagDirty()

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

    Public Sub Delete(ByVal NotaCreditoID As Integer)

    End Sub

    Public Sub UpdateInventario(ByVal dsNotaCreditoDetalle As DataSet, ByVal intNotaCreditoFolio As Integer, _
                                ByVal strTipoDevolucion As String)

        Dim odrFactura As DataRow
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

            'For Each odrFactura In dsNotaCreditoDetalle.Tables("NotasCreditoDetalle").Rows
            For Each odrFactura In dsNotaCreditoDetalle.Tables(0).Rows

                'Extraer la Información de cada Artículo.
                oArticulo = Nothing
                oArticulo = oCatalogoArticuloMgr.Load(CType(odrFactura("CodArticulo"), String))

                With sccmdUpdateInventario

                    'Assign Parameters Values 

                    .Parameters("@CodTipoMov").Value = 104
                    .Parameters("@TipoMovimiento").Value = "E"
                    .Parameters("@StatusMov").Value = "A"

                    .Parameters("@CodAlmacen").Value = oParent.ApplicationContext.ApplicationConfiguration.Almacen
                    .Parameters("@Destino").Value = oParent.ApplicationContext.ApplicationConfiguration.Almacen

                    .Parameters("@Folio").Value = intNotaCreditoFolio
                    .Parameters("@FolioSAP").Value = "0"
                    .Parameters("@CodArticulo").Value = odrFactura("CodArticulo")
                    .Parameters("@Descripcion").Value = oArticulo.Descripcion
                    .Parameters("@Numero").Value = odrFactura("Numero")

                    .Parameters("@Total").Value = odrFactura("Cantidad")

                    'Comparar si TipoDevolucion = DEF
                    If (strTipoDevolucion = "DEF") Then
                        'Se modifico por que el requerimiento dice que solo de podran marcar como defectuosos
                        'en el modulo correspondiente.
                        .Parameters("@Defectuosos").Value = 0 'odrFactura("Cantidad")
                    Else
                        .Parameters("@Defectuosos").Value = 0
                    End If

                    .Parameters("@Apartados").Value = 0
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

                    .Parameters("@CostoUnit").Value = odrFactura("CostoUnit")
                    .Parameters("@PrecioUnit").Value = odrFactura("CostoUnit")

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


        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Dim errorMessages As String
            Dim i As Integer

            For i = 0 To oSqlException.Errors.Count - 1
                errorMessages += "Index #" & i.ToString() & ControlChars.NewLine _
                               & "Message: " & oSqlException.Errors(i).Message & ControlChars.NewLine _
                               & "LineNumber: " & oSqlException.Errors(i).LineNumber & ControlChars.NewLine _
                               & "Source: " & oSqlException.Errors(i).Source & ControlChars.NewLine _
                               & "Procedure: " & oSqlException.Errors(i).Procedure & ControlChars.NewLine
            Next i


            Throw New ApplicationException("El registro no pudo ser insertado debido a un error de base de datos." & Microsoft.VisualBasic.vbCrLf & errorMessages & Microsoft.VisualBasic.vbCrLf, oSqlException)


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

        sccmdUpdateInventario.Dispose()
        sccmdUpdateInventario = Nothing

        oCatalogoArticuloMgr = Nothing
        oArticulo = Nothing

    End Sub

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

#End Region


#Region "Métodos [Nota Credito Detalle]"

    Public Sub CreatTable(ByVal strNombreTabla As String)

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)
        Dim sccmdCreatTable As SqlCommand



        sccmdCreatTable = New SqlCommand

        With sccmdCreatTable

            .Connection = sccnnConnection

            .CommandText = "[NotaCreditoDetalleCrearTMP]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@NombreTabla", System.Data.SqlDbType.VarChar, 30))

        End With


        Try
            sccnnConnection.Open()

            With sccmdCreatTable
                'Assign Parameters Values

                '.Parameters("@NombreTabla").Value = "NotaCreditoDetalleTmp" & oParent.ApplicationContext.ApplicationConfiguration.Almacen & oParent.ApplicationContext.ApplicationConfiguration.NoCaja & oParent.ApplicationContext.Security.CurrentUser.ID
                .Parameters("@NombreTabla").Value = strNombreTabla

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



    Public Sub DeleteTable(ByVal strTablaTmp As String)

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)
        Dim sccmdDeleteTable As SqlCommand



        sccmdDeleteTable = New SqlCommand

        With sccmdDeleteTable

            .Connection = sccnnConnection

            .CommandText = "[NotaCreditoDetalleEliminarTMP]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@NombreTabla", System.Data.SqlDbType.VarChar, 30))

        End With


        Try
            sccnnConnection.Open()

            With sccmdDeleteTable
                'Assign Parameters Values
                '.Parameters("@NombreTabla").Value = "NotaCreditoDetalleTmp" & oParent.ApplicationContext.ApplicationConfiguration.Almacen & oParent.ApplicationContext.ApplicationConfiguration.NoCaja & oParent.ApplicationContext.Security.CurrentUser.ID
                .Parameters("@NombreTabla").Value = strTablaTmp
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



    Public Sub InsertArticulo(ByVal intNotaCreditoID As Integer, ByVal oArticulo As Articulo, ByVal decNumero As String, _
                              ByVal intCantidad As Integer, ByVal oFactura As Factura, ByVal strTablaTmp As String)

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                         DataStorageConfiguration.GetConnectionString)

        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand

        Dim decPrecioOferta As Decimal
        Dim decCostoUnit As Decimal


        With sccmdInsert

            .Connection = sccnnConnection

            .CommandText = "[NotaCreditoDetalleArticuloIns]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .CommandType = CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@NombreTabla", System.Data.SqlDbType.VarChar, 30))

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@NotaCreditoID", System.Data.SqlDbType.Int))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar, 2))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacenOrigenFact", System.Data.SqlDbType.Char, 10))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioReferencia", System.Data.SqlDbType.VarChar, 10))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ClienteID", System.Data.SqlDbType.VarChar, 10))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodTipoDevolucion", System.Data.SqlDbType.Char, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodArticulo", System.Data.SqlDbType.VarChar, 20))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Numero", System.Data.SqlDbType.VarChar, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Cantidad", System.Data.SqlDbType.Decimal))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Descripcion", System.Data.SqlDbType.VarChar, 50))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CostoUnit", System.Data.SqlDbType.Decimal))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@PrecioUnit", System.Data.SqlDbType.Decimal))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Importe", System.Data.SqlDbType.Decimal))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Impresa", System.Data.SqlDbType.Bit))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Usuario", System.Data.SqlDbType.VarChar, 12))

            '''Folio Referencia Meter el de SAP
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FacturaID", System.Data.SqlDbType.VarChar, 10))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodTipoVenta", System.Data.SqlDbType.Char, 1))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioSAP", System.Data.SqlDbType.VarChar, 20))

        End With

        Try

            sccnnConnection.Open()

            With sccmdInsert

                'Assign Parameters Values
                '.Parameters("@NombreTabla").Value = "NotaCreditoDetalleTmp" & oParent.ApplicationContext.ApplicationConfiguration.Almacen & oParent.ApplicationContext.ApplicationConfiguration.NoCaja & oParent.ApplicationContext.Security.CurrentUser.ID
                .Parameters("@NombreTabla").Value = strTablaTmp

                .Parameters("@NotaCreditoID").Value = intNotaCreditoID
                .Parameters("@CodAlmacen").Value = oParent.ApplicationContext.ApplicationConfiguration.Almacen
                .Parameters("@CodCaja").Value = oFactura.CodCaja
                .Parameters("@CodAlmacenOrigenFact").Value = oFactura.CodAlmacen
                .Parameters("@FolioReferencia").Value = oFactura.FolioFactura
                .Parameters("@ClienteID").Value = CStr(oFactura.ClienteId).PadLeft(10, "0")
                .Parameters("@CodTipoDevolucion").Value = String.Empty
                .Parameters("@CodArticulo").Value = oArticulo.CodArticulo
                .Parameters("@Numero").Value = decNumero
                .Parameters("@Cantidad").Value = intCantidad
                .Parameters("@Descripcion").Value = oArticulo.Descripcion

                decCostoUnit = ExtraerCostoUnit(oFactura.FacturaID, oArticulo.CodArticulo, decNumero)
                .Parameters("@CostoUnit").Value = decCostoUnit

                decPrecioOferta = Decimal.Round(ExtraerPrecioUnit(oFactura.FacturaID, oArticulo.CodArticulo, decNumero), 4)
                If DateDiff(DateInterval.Day, oFactura.Fecha, CDate("31/12/2005")) >= 0 Then
                    .Parameters("@PrecioUnit").Value = decPrecioOferta
                Else
                    '.Parameters("@PrecioUnit").Value = decPrecioOferta + (decPrecioOferta * oParent.ApplicationContext.ApplicationConfiguration.IVA)
                    '-----------------------------------------------------------------------------------------------------------------------------------------
                    'JNAVA 24.06.2014: Se redondeo el valor obtenido ya que marcaba desbordamiento con valores (0.0000000000000000) en SQL server 2012
                    '-----------------------------------------------------------------------------------------------------------------------------------------
                    .Parameters("@PrecioUnit").Value = Decimal.Round(decPrecioOferta + (decPrecioOferta * ((oFactura.IVA * 100 / oFactura.SubTotal) / 100)), 2)
                End If


                '.Parameters("@PrecioUnit").Value = oFactura.Detalle.Tables(0).Rows.Item(0)

                .Parameters("@Importe").Value = Math.Round((intCantidad * .Parameters("@PrecioUnit").Value), 2) 'decPrecioOferta


                .Parameters("@Impresa").Value = 0
                .Parameters("@Usuario").Value = oParent.ApplicationContext.Security.CurrentUser.Name

                .Parameters("@FacturaID").Value = oFactura.FacturaID
                .Parameters("@CodTipoVenta").Value = oFactura.CodTipoVenta
                .Parameters("@Fecha").Value = Format(oFactura.Fecha, "short date")
                .Parameters("@FolioSAP").Value = oFactura.Referencia
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

            Dim errorMessages As String
            Dim i As Integer

            For i = 0 To oSqlException.Errors.Count - 1
                errorMessages += "Index #" & i.ToString() & ControlChars.NewLine _
                               & "Message: " & oSqlException.Errors(i).Message & ControlChars.NewLine _
                               & "LineNumber: " & oSqlException.Errors(i).LineNumber & ControlChars.NewLine _
                               & "Source: " & oSqlException.Errors(i).Source & ControlChars.NewLine _
                               & "Procedure: " & oSqlException.Errors(i).Procedure & ControlChars.NewLine
            Next i


            Throw New ApplicationException("El registro no pudo ser insertado debido a un error de base de datos." & Microsoft.VisualBasic.vbCrLf & errorMessages & Microsoft.VisualBasic.vbCrLf, oSqlException)

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



    Public Sub DeleteArticulo(ByVal strFacturaFolio As String, ByVal strCodArticulo As String, ByVal decTalla As String, ByVal strTablaTmp As String)

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                                 DataStorageConfiguration.GetConnectionString)

        Dim sccmdDelete As SqlCommand
        sccmdDelete = New SqlCommand

        With sccmdDelete

            .Connection = sccnnConnection
            .CommandText = "[NotaCreditoDetalleArticuloDel]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@NombreTabla", System.Data.SqlDbType.VarChar, 40))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioReferencia", System.Data.SqlDbType.VarChar, 10))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodArticulo", System.Data.SqlDbType.VarChar, 20))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Numero", System.Data.SqlDbType.VarChar, 4))

        End With

        Try

            sccnnConnection.Open()

            With sccmdDelete

                'Assign Parameters Values
                '.Parameters("@NombreTabla").Value = "NotaCreditoDetalleTmp" & oParent.ApplicationContext.ApplicationConfiguration.Almacen & oParent.ApplicationContext.ApplicationConfiguration.NoCaja & oParent.ApplicationContext.Security.CurrentUser.ID
                .Parameters("@NombreTabla").Value = strTablaTmp
                .Parameters("@FolioReferencia").Value = strFacturaFolio
                .Parameters("@CodArticulo").Value = strCodArticulo
                .Parameters("@Numero").Value = decTalla

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

            'Throw New ApplicationException("El registro no pudo ser insertado debido a un error de aplicación.", ex)

        End Try


        sccmdDelete.Dispose()
        sccmdDelete = Nothing

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

    End Sub



    Private Function InsertDistribucionNotaCredito(ByVal intNotaCreditoFolio As Integer, _
                                                   ByVal oCliente As DportenisPro.DPTienda.ApplicationUnits.Clientes.ClienteAlterno) _
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
                .Parameters("@Referencia").Value = intNotaCreditoFolio
                .Parameters("@TotalAnticipoCliente").Value = 0.0
                .Parameters("@TotalTarjetaCredito").Value = 0.0
                .Parameters("@SaldoAnticipoCliente").Value = 0.0
                .Parameters("@Usuario").Value = oParent.ApplicationContext.Security.CurrentUser.Name
                .Parameters("@StatusRegistro").Value = 1

                .Parameters("@ClienteID").Value = oCliente.CodigoAlterno
                .Parameters("@Nombre").Value = oCliente.ApellidoPaterno & " " & oCliente.ApellidoMaterno & " " & oCliente.Nombre
                .Parameters("@GeneradoPor").Value = "NC"
                .Parameters("@TotalAbonos").Value = 0.0
                .Parameters("@Penalizacion").Value = 0.0
                .Parameters("@DevEfectivo").Value = "N"
                .Parameters("@MotivoCancelacion").Value = String.Empty 'PENDIENTE !!!
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

        Return intReturnValue

    End Function



    Private Sub UpdateDistribucionNotaCreditoTotales(ByVal intAnticipoID As Integer, ByVal strModulo As String)

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

        Dim dtNotaCreditoDetalle As DataTable
        Dim drFactura As DataRow

        Dim decMontoCancelarTarjetaCredito As Decimal
        Dim decMontoAnticipoCliente As Decimal
        Dim decMontoDPVale As Decimal
        Dim decMontoCDT As Decimal


        With sccmdSelectAll

            .Connection = sccnnConnection

            .CommandText = "[AnticiposClientesDetalleSel]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@AnticipoID", System.Data.SqlDbType.Int))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Modulo", System.Data.SqlDbType.VarChar, 4))

        End With


        With sccmdUpdate

            .Connection = sccnnConnection

            .CommandText = "[NotaCreditoAnticiposClientesTotalesUpd]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@AnticipoID", System.Data.SqlDbType.Int))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TotalAnticipoCliente", System.Data.SqlDbType.Money))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TotalTarjetaCredito", System.Data.SqlDbType.Money))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@SaldoAnticipoCliente", System.Data.SqlDbType.Money))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TotalAbonos", System.Data.SqlDbType.Money))

        End With

        scdaAnticipoCliente.SelectCommand = sccmdSelectAll

        Try
            sccnnConnection.Open()


            'Calcular Total Monto Cancelar T. Credito y Anticipo Cliente.
            scdaAnticipoCliente.SelectCommand.Parameters("@AnticipoID").Value = intAnticipoID
            scdaAnticipoCliente.SelectCommand.Parameters("@Modulo").Value = strModulo

            'Fill DataSet
            scdaAnticipoCliente.Fill(dsAnticipoClienteDetalle, "AnticiposClientesDetalle")


            dtNotaCreditoDetalle = dsAnticipoClienteDetalle.Tables(0)

            For Each drFactura In dtNotaCreditoDetalle.Rows

                decMontoCancelarTarjetaCredito += CType(drFactura("MontoCanceladoTarjeta"), Decimal)
                decMontoAnticipoCliente += CType(drFactura("AnticipoCliente"), Decimal)
                decMontoDPVale += CType(drFactura("MontoCanceladoDPVale"), Decimal)
                decMontoCDT += CType(drFactura("MontoCanceladoCDT"), Decimal)

            Next

            dtNotaCreditoDetalle = Nothing


            With sccmdUpdate

                'Assign Parameters Values

                .Parameters("@AnticipoID").Value = intAnticipoID
                .Parameters("@TotalAnticipoCliente").Value = decMontoAnticipoCliente + decMontoCancelarTarjetaCredito _
                                                             + decMontoDPVale + decMontoCDT

                .Parameters("@TotalTarjetaCredito").Value = decMontoCancelarTarjetaCredito
                .Parameters("@SaldoAnticipoCliente").Value = decMontoAnticipoCliente
                .Parameters("@TotalAbonos").Value = 0.0

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



    'Private Sub DistribucionNotaCredito(ByVal intNotaCreditoFolio As Integer, ByVal strTipoDevolucion As String, _
    '                                    ByVal oCliente As DportenisPro.DPTienda.ApplicationUnits.Clientes.Clientes)

    Public Function DistribucionNotaCredito(ByVal intNotaCreditoFolio As Integer, ByVal strTipoDevolucion As String, _
                                        ByVal oCliente As DportenisPro.DPTienda.ApplicationUnits.Clientes.ClienteAlterno, ByVal strModulo As String, ByVal strTablaTmp As String) As Integer

        Dim odrArticulo As DataRow

        Dim dsNotaCreditoDetalle As New DataSet

        Dim intAnticipoID As Integer



        'Anticipos Clientes General :
        intAnticipoID = InsertDistribucionNotaCredito(intNotaCreditoFolio, oCliente)


        'Anticipos Clientes Detalle :

        With oParent.ApplicationContext

            'Agrupar Totales por Factura.

            dsNotaCreditoDetalle = FillDataSet("[NotaCreditoDistribucionSel]", strTablaTmp) '"NotaCreditoDetalleTmp" & .ApplicationConfiguration.Almacen & .ApplicationConfiguration.NoCaja & .Security.CurrentUser.ID)

        End With


        For Each odrArticulo In dsNotaCreditoDetalle.Tables(0).Rows

            'Tipo Venta :
            DistribucionNotaCreditoPublicoGral(intAnticipoID, strTipoDevolucion, odrArticulo("FacturaID"), UCase(odrArticulo("CodTipoVenta")), odrArticulo("Importe"), odrArticulo("FolioReferencia"))

        Next

        dsNotaCreditoDetalle.Dispose()
        dsNotaCreditoDetalle = Nothing


        'Actualizar TotalAnticipoCliente, TotalTarjetaCredito y SaldoAnticipoCliente.

        UpdateDistribucionNotaCreditoTotales(intAnticipoID, strModulo)

        Return intAnticipoID

    End Function



    Private Sub DistribucionNotaCreditoPublicoGral(ByVal intAnticipoID As Integer, ByVal strTipoDevolucion As String, _
                                                   ByVal intFacturaID As Integer, ByVal strTipoVentaID As String, _
                                                   ByVal decImporteDevFactura As Decimal, ByVal intFolioReferencia As Integer)

        'Tipo Devolución :

        DistribucionNotaCreditoPublicoGralEST(intAnticipoID, intFacturaID, strTipoVentaID, decImporteDevFactura, intFolioReferencia)

    End Sub



    Private Sub DistribucionNotaCreditoPublicoGralEST(ByVal intAnticipoID As Integer, ByVal intFacturaID As Integer, _
                                                      ByVal strTipoVentaID As String, ByVal decImporteDevFactura As Decimal, _
                                                      ByVal intFolioReferencia As Integer)

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                         DataStorageConfiguration.GetConnectionString)

        Dim decMontoNoCancelado As Decimal
        Dim decMontoCancelarTarjetaCredito As Decimal
        Dim decMontoFonacotFacilito As Decimal
        Dim decMontoDPVale As Decimal
        Dim decMontoAnticipoCliente As Decimal
        Dim decMontoCreditoDirecto As Decimal
        Dim decMontoCanje As Decimal
        Dim strCodBanco As String
        Dim strNumeroTarjeta As String
        Dim strNumeroAutorizacion As String
        Dim intDPValeID As String

        decMontoNoCancelado = 0
        decMontoCancelarTarjetaCredito = 0
        decMontoAnticipoCliente = 0
        decMontoDPVale = 0
        decMontoCreditoDirecto = 0
        decMontoFonacotFacilito = 0

        strCodBanco = String.Empty
        strNumeroTarjeta = String.Empty
        strNumeroAutorizacion = String.Empty


        intDPValeID = ""

        

        'Tipo Venta [Asociado Credito] :

        If (strTipoVentaID = "D") Then

            'Forma Pago [Credito Directo] :
            If (ValidarExistenciaFormaPago(intFacturaID, "CRED") = True) Then

                decMontoNoCancelado = ExtraerMontoNoCancelado(intFacturaID, "CRED")

                'Credito Directo cubre ImporteDevFactura :
                If (decMontoNoCancelado >= decImporteDevFactura) Then

                    'Credito cubre todo el Importe Devolución :
                    decMontoCreditoDirecto = decImporteDevFactura
                    decMontoCancelarTarjetaCredito = 0
                    decMontoAnticipoCliente = 0

                    'Actualizar Monto Cancelado Credito Directo :
                    MontoCanceladoUpd(intFacturaID, "CRED", decMontoCreditoDirecto)
                    decImporteDevFactura = 0


                    'Credito Directo cubre una parte del ImporteDevFactura :
                ElseIf (decMontoNoCancelado < decImporteDevFactura) And (decMontoNoCancelado > 0) Then

                    'Se liquida el saldo Monto Cancelado Credito Directo :
                    decMontoCreditoDirecto = decMontoNoCancelado

                    'Actualizar Monto Cancelado Credito Directo :
                    MontoCanceladoUpd(intFacturaID, "CRED", decMontoCreditoDirecto)
                    decImporteDevFactura -= decMontoCreditoDirecto

                Else

                    'El Saldo Credito Directo se encuentra liquidado.
                    decMontoCreditoDirecto = 0

                End If '<Credito Directo > importe factura>

            Else

                'T. Crédito y Anticipo Cliente cubren Importe Devolucion
                decMontoCreditoDirecto = 0

            End If '<ExistenciaFormaPago>

        End If '<Credito Directo = C>

        '/****************** FACILITO Y FONACOT
        If (strTipoVentaID = "F") Or (strTipoVentaID = "K") Or (strTipoVentaID = "O") Then

            'Forma Pago [Fonacot/Facilito] :
            'Dim strFormaPago As String = IIf(strTipoVentaID = "F", "FONA", "FACI")
            Dim strFormaPago As String = String.Empty
            Select Case strTipoVentaID
                Case "F"
                    strFormaPago = "FONA"
                Case "O"
                    strFormaPago = "FACI"
                Case "K"
                    strFormaPago = "TFON"
            End Select

            If (ValidarExistenciaFormaPago(intFacturaID, strFormaPago) = True) Then

                decMontoNoCancelado = ExtraerMontoNoCancelado(intFacturaID, strFormaPago)

                'Facilito/Fonacot cubre ImporteDevFactura :
                If (decMontoNoCancelado >= decImporteDevFactura) Then

                    'Facilito/Fonacot cubre todo el Importe Devolución :

                    decMontoFonacotFacilito = decImporteDevFactura
                    decMontoCancelarTarjetaCredito = 0
                    decMontoAnticipoCliente = 0

                    'Actualizar Monto Cancelado Credito Directo :
                    MontoCanceladoUpd(intFacturaID, strFormaPago, decMontoFonacotFacilito)
                    decImporteDevFactura = 0

                    'Credito Directo cubre una parte del ImporteDevFactura :
                ElseIf (decMontoNoCancelado < decImporteDevFactura) And (decMontoNoCancelado > 0) Then

                    'Se liquida el saldo Monto Cancelado Credito Directo :
                    decMontoFonacotFacilito = decMontoNoCancelado

                    'Actualizar Monto Cancelado Credito Directo :
                    MontoCanceladoUpd(intFacturaID, strFormaPago, decMontoFonacotFacilito)
                    decImporteDevFactura -= decMontoFonacotFacilito

                Else

                    'El Saldo Credito Directo se encuentra liquidado.
                    decMontoFonacotFacilito = 0

                End If '<Credito Directo > importe factura>

            Else

                'T. Crédito y Anticipo Cliente cubren Importe Devolucion
                decMontoFonacotFacilito = 0

            End If '<ExistenciaFormaPago>

        End If '<Fonacot Facilito Tarjeta Fonacot= F/O/T>

        '/*******************************************


        'Tipo Venta [DP Vale] :

        If (strTipoVentaID = "V") Then

            'Forma Pago [DP Vale] :
            If (ValidarExistenciaFormaPago(intFacturaID, "DPVL") = True) Then

                decMontoNoCancelado = ExtraerMontoNoCancelado(intFacturaID, "DPVL")

                'DP Vale cubre ImporteDevFactura :
                If (decMontoNoCancelado >= decImporteDevFactura) Then

                    'Extraer ID DP Vale :
                    intDPValeID = ExtraerDPValeID(intFacturaID)

                    'DP Vale cubre todo el Importe Devolución :
                    decMontoDPVale = decImporteDevFactura
                    decMontoCancelarTarjetaCredito = 0
                    decMontoAnticipoCliente = 0

                    'Actualizar Monto Cancelado DP Vale :
                    MontoCanceladoUpd(intFacturaID, "DPVL", decMontoDPVale)
                    decImporteDevFactura = 0

                    'DP Vale cubre una parte del ImporteDevFactura :
                ElseIf (decMontoNoCancelado < decImporteDevFactura) And (decMontoNoCancelado > 0) Then

                    'Extraer ID DP Vale :
                    intDPValeID = ExtraerDPValeID(intFacturaID)

                    'Se liquida el saldo Monto Cancelado DP Vale :
                    decMontoDPVale = decMontoNoCancelado

                    'Actualizar Monto Cancelado DP Vale :
                    MontoCanceladoUpd(intFacturaID, "DPVL", decMontoDPVale)
                    decImporteDevFactura -= decMontoDPVale

                Else

                    'El Saldo DP Vale se encuentra liquidado.
                    decMontoDPVale = 0

                End If '<Dpvale > importe factura>

            Else

                'T. Crédito y Anticipo Cliente cubren Importe Devolucion
                decMontoDPVale = 0

            End If '<ExistenciaFormaPago>


            If (decMontoDPVale = 0) Then
                GoTo SaltoLineaDPVale
            End If

        End If '<TipoVenta = V>



SaltoLineaDPVale:

        'Actualizar Monto Cancelado de las Formas de Pago restantes [T. Crédito y AnticipoCliente] :

        If (decImporteDevFactura = 0) Then
            GoTo SaltoLinea
        End If

        '------------------------------------------------------------------------------------
        ' FLIZARRAGA 18/09/2018: Forma Pago ClubDP Puntos
        '------------------------------------------------------------------------------------
        If (ValidarExistenciaFormaPago(intFacturaID, "DPPT") = True) Then
            decMontoNoCancelado = ExtraerMontoNoCancelado(intFacturaID, "DPPT")
            If (decMontoNoCancelado >= decImporteDevFactura) Then
                'Credito cubre todo el Importe Devolución :
                decMontoCanje = decImporteDevFactura

                'Actualizar Monto Cancelado Credito Directo :
                MontoCanceladoUpd(intFacturaID, "DPPT", decMontoCanje)
                decImporteDevFactura = 0
                'Credito Directo cubre una parte del ImporteDevFactura :
            ElseIf (decMontoNoCancelado < decImporteDevFactura) And (decMontoNoCancelado > 0) Then
                'Se liquida el saldo Monto Cancelado Credito Directo :
                decMontoCanje = decMontoNoCancelado

                'Actualizar Monto Cancelado Credito Directo :
                MontoCanceladoUpd(intFacturaID, "DPPT", decMontoCanje)
                decImporteDevFactura -= decMontoCanje
            End If
        End If

        If (decImporteDevFactura = 0) Then
            GoTo SaltoLinea
        End If


        If (strTipoVentaID = "V") Or (strTipoVentaID = "D") Or (strTipoVentaID = "K") Or (strTipoVentaID = "F") Or (strTipoVentaID = "O") Then     '<CHARLES | Agrega Facilit(O) y (F)onacot>

            'Forma Pago [T. Crédito] :
            If (ValidarExistenciaFormaPago(intFacturaID, "TACR") = True) Then

                Dim dsTACR As DataSet
                dsTACR = New DataSet
                dsTACR = ExtraerMontoNoCanceladoVCJA(intFacturaID, "TACR")

                If dsTACR.Tables(0).Rows.Count > 0 Then

                    For Each oRow As DataRow In dsTACR.Tables(0).Rows
                        'decMontoNoCancelado = ExtraerMontoNoCancelado(intFacturaID, "TACR")

                        'T. Crédito cubre ImporteDevFactura :
                        If (oRow.Item("MontoNoCancelado") >= decImporteDevFactura) Then

                            'Extraer de Factura : No. Autorización, No. Tarjeta 
                            ExtraerInformacionTarjetaTADB(intFacturaID, strCodBanco, strNumeroTarjeta, strNumeroAutorizacion, "TACR", oRow.Item("FormaPagoID"))
                            MontoCanceladoUpdVCJA(intFacturaID, "TACR", decImporteDevFactura, oRow.Item("FormaPagoID"))
                            decMontoCancelarTarjetaCredito += decImporteDevFactura 'decMontoNoCancelado
                            decMontoAnticipoCliente = 0
                            decImporteDevFactura = 0

                            'T. Credito cubre una parte del ImporteDevFactura :
                        ElseIf (oRow.Item("MontoNoCancelado") < decImporteDevFactura) And (oRow.Item("MontoNoCancelado") > 0) Then

                            'Extraer de Factura : No. Autorización, No. Tarjeta 
                            ExtraerInformacionTarjetaTADB(intFacturaID, strCodBanco, strNumeroTarjeta, strNumeroAutorizacion, "TACR", oRow.Item("FormaPagoID"))

                            'Actualizar Monto Cancelado T. Crédito :
                            MontoCanceladoUpdVCJA(intFacturaID, "TACR", oRow.Item("MontoNoCancelado"), oRow.Item("FormaPagoID"))
                            decMontoCancelarTarjetaCredito += oRow.Item("MontoNoCancelado")
                            'decMontoAnticipoCliente = decImporteDevFactura - decMontoCancelarTarjetaCredito
                            decImporteDevFactura -= oRow.Item("MontoNoCancelado")

                        Else

                            'El Saldo de Terjeta Credito se encuentra liquidado.
                            decMontoCancelarTarjetaCredito = 0

                            'Anticipo Cliente cubre el ImporteDevFactura.
                            'decMontoAnticipoCliente = decImporteDevFactura

                        End If '<T.Credito > importe factura>


                        If decImporteDevFactura = 0 Then
                            Exit For
                        End If

                    Next


                End If




            Else

                'AnticipoCliente cubre Importe Devolucion.
                decMontoCancelarTarjetaCredito = 0
                'decMontoAnticipoCliente = decImporteDevFactura

            End If '<Existencia T.Credito>

        End If



        'Tipo Venta [Público Gral]

        If (strTipoVentaID = "P") OrElse (strTipoVentaID = "E") OrElse (strTipoVentaID = "A") OrElse strTipoVentaID = "I" OrElse strTipoVentaID = "S" Then

            'Forma Pago [Tarjeta Credito] :
            If (ValidarExistenciaFormaPago(intFacturaID, "TACR") = True) Then
                Dim dsTACR As DataSet
                dsTACR = New DataSet
                dsTACR = ExtraerMontoNoCanceladoVCJA(intFacturaID, "TACR")

                If dsTACR.Tables(0).Rows.Count > 0 Then

                    For Each oRow As DataRow In dsTACR.Tables(0).Rows
                        'decMontoNoCancelado

                        'T. Credito cubre ImporteDevFactura :
                        If (oRow.Item("MontoNoCancelado") >= decImporteDevFactura) Then

                            'Extraer de Factura : No. Autorización, No. Tarjeta 
                            ExtraerInformacionTarjetaTADB(intFacturaID, strCodBanco, strNumeroTarjeta, strNumeroAutorizacion, "TACR", oRow.Item("FormaPagoID"))

                            'Tarjeta de Credito cubre todo el Importe Devolución :
                            decMontoCancelarTarjetaCredito += decImporteDevFactura
                            decMontoAnticipoCliente = 0

                            'Actualizar Monto Cancelado T. Credito :
                            MontoCanceladoUpdVCJA(intFacturaID, "TACR", decImporteDevFactura, oRow.Item("FormaPagoID"))
                            decImporteDevFactura = 0

                            'T. Credito cubre una parte del ImporteDevFactura :
                        ElseIf (oRow.Item("MontoNoCancelado") < decImporteDevFactura) And (oRow.Item("MontoNoCancelado") > 0) Then

                            'Extraer de Factura : No. Autorización, No. Tarjeta 
                            ExtraerInformacionTarjetaTADB(intFacturaID, strCodBanco, strNumeroTarjeta, strNumeroAutorizacion, "TACR", oRow.Item("FormaPagoID"))

                            'Se liquida el saldo Monto Cancelado T. Credito :
                            decMontoCancelarTarjetaCredito += oRow.Item("MontoNoCancelado")

                            'Actualizar Monto Cancelado T. Credito :
                            MontoCanceladoUpdVCJA(intFacturaID, "TACR", oRow.Item("MontoNoCancelado"), oRow.Item("FormaPagoID"))

                            'El Resto del Importe de la devolución se convierte en un Anticipo a Cliente.    
                            decImporteDevFactura = decImporteDevFactura - oRow.Item("MontoNoCancelado")

                        Else

                            'El Saldo de Terjeta Credito se encuentra liquidado.
                            decMontoCancelarTarjetaCredito = 0

                            'Anticipo Cliente cubre el ImporteDevFactura.

                        End If
                        ''aki
                        If decImporteDevFactura = 0 Then
                            Exit For
                        End If
                    Next

                End If



                'Anticipo a Cliente : [Efectivo, Tarjeta Debito y/o Anticipo Cliente].
            Else

                'Anticipo Cliente cubre el ImporteDevFactura.
                decMontoCancelarTarjetaCredito = 0

            End If

        End If


        'Actualizar Monto Cancelado de las Formas de Pago restantes [Efectivo, Tarjeta Debito y/o Anticipo Cliente] :

        If (decImporteDevFactura = 0) Then
            GoTo SaltoLinea
        End If


        'Forma Pago [Efectivo] :
        If (ValidarExistenciaFormaPago(intFacturaID, "EFEC") = True) Then

            decMontoNoCancelado = ExtraerMontoNoCancelado(intFacturaID, "EFEC")

            'Efectivo cubre ImporteDevFactura :
            If (decMontoNoCancelado >= decImporteDevFactura) Then

                MontoCanceladoUpd(intFacturaID, "EFEC", decImporteDevFactura)
                decMontoAnticipoCliente = decImporteDevFactura 'decMontoNoCancelado
                decImporteDevFactura = 0

                'Efectivo cubre una parte del ImporteDevFactura :
            ElseIf (decMontoNoCancelado < decImporteDevFactura) And (decMontoNoCancelado > 0) Then

                'Actualizar Monto Cancelado Efectivo :
                MontoCanceladoUpd(intFacturaID, "EFEC", decMontoNoCancelado)
                decImporteDevFactura = decImporteDevFactura - decMontoNoCancelado
                decMontoAnticipoCliente = decMontoNoCancelado
            End If

        End If

        If (decImporteDevFactura = 0) Then

            GoTo SaltoLinea

        End If

        'Forma Pago [LIQU] :
        ''***************************Pruebaaaaaaaaaaaaaaaaa************************
        If (ValidarExistenciaFormaPago(intFacturaID, "LIQU") = True) Then

            decMontoNoCancelado = ExtraerMontoNoCancelado(intFacturaID, "LIQU")

            'Liquidacion cubre ImporteDevFactura :
            If (decMontoNoCancelado >= decImporteDevFactura) Then

                MontoCanceladoUpd(intFacturaID, "LIQU", decImporteDevFactura)
                decMontoAnticipoCliente = decImporteDevFactura 'decMontoNoCancelado
                decImporteDevFactura = 0

                'La Liquidacion cubre una parte del ImporteDevFactura :
            ElseIf (decMontoNoCancelado < decImporteDevFactura) And (decMontoNoCancelado > 0) Then

                'Actualizar Monto Cancelado Liquidación :
                MontoCanceladoUpd(intFacturaID, "LIQU", decMontoNoCancelado)
                decImporteDevFactura = decImporteDevFactura - decMontoNoCancelado
                decMontoAnticipoCliente = decMontoNoCancelado
            End If
        End If

        If (decImporteDevFactura = 0) Then

            GoTo SaltoLinea

        End If
        ''***************************Pruebaaaaaaaaaaaaaaaaa************************

        'Forma Pago [Tarjeta Debito] :
        If (ValidarExistenciaFormaPago(intFacturaID, "TADB") = True) Then
            Dim dsTADB As DataSet
            dsTADB = New DataSet
            dsTADB = ExtraerMontoNoCanceladoVCJA(intFacturaID, "TADB")

            If dsTADB.Tables(0).Rows.Count > 0 Then

                For Each oRow As DataRow In dsTADB.Tables(0).Rows

                    'T. Debito cubre ImporteDevFactura :
                    If (oRow.Item("MontoNoCancelado") >= decImporteDevFactura) Then

                        'Extraer de Factura : No. Autorización, No. Tarjeta 
                        ExtraerInformacionTarjetaTADB(intFacturaID, strCodBanco, strNumeroTarjeta, strNumeroAutorizacion, "TADB", oRow.Item("FormaPagoID"))

                        'Tarjeta de Credito cubre todo el Importe Devolución :
                        decMontoCancelarTarjetaCredito += decImporteDevFactura
                        MontoCanceladoUpdVCJA(intFacturaID, "TADB", decImporteDevFactura, oRow.Item("FormaPagoID"))
                        decImporteDevFactura = 0

                        'T. Debito cubre una parte del ImporteDevFactura :
                    ElseIf (oRow.Item("MontoNoCancelado") < decImporteDevFactura) And (oRow.Item("MontoNoCancelado") > 0) Then


                        'Extraer de Factura : No. Autorización, No. Tarjeta 
                        ExtraerInformacionTarjetaTADB(intFacturaID, strCodBanco, strNumeroTarjeta, strNumeroAutorizacion, "TADB", oRow.Item("FormaPagoID"))

                        'Se liquida el saldo Monto Cancelado T. Credito :
                        decMontoCancelarTarjetaCredito += oRow.Item("MontoNoCancelado")

                        'Actualizar Monto Cancelado T. Debito :
                        MontoCanceladoUpdVCJA(intFacturaID, "TADB", oRow.Item("MontoNoCancelado"), oRow.Item("FormaPagoID"))
                        decImporteDevFactura = decImporteDevFactura - oRow.Item("MontoNoCancelado")

                    End If

                    If decImporteDevFactura = 0 Then
                        Exit For
                    End If

                Next


            End If



        End If


        If (decImporteDevFactura = 0) Then

            GoTo SaltoLinea

        End If

        'Forma Pago [Vale Caja] :
        If (ValidarExistenciaFormaPago(intFacturaID, "VCJA") = True) Then

            Dim dsVCJA As DataSet
            dsVCJA = New DataSet
            dsVCJA = ExtraerMontoNoCanceladoVCJA(intFacturaID, "VCJA")

            If dsVCJA.Tables(0).Rows.Count > 0 Then

                For Each oRow As DataRow In dsVCJA.Tables(0).Rows
                    'Anticipo Cliente cubre ImporteDevFactura :
                    If (oRow.Item("MontoNoCancelado") >= decImporteDevFactura) Then

                        MontoCanceladoUpdVCJA(intFacturaID, "VCJA", decImporteDevFactura, oRow.Item("FormaPagoID"))
                        decMontoAnticipoCliente += decImporteDevFactura
                        decImporteDevFactura = 0

                        'Anticipo Cliente cubre una parte del ImporteDevFactura :
                    ElseIf (oRow.Item("MontoNoCancelado") < decImporteDevFactura) And (oRow.Item("MontoNoCancelado") > 0) Then

                        'Actualizar Monto Cancelado Anticipo Cliente :
                        MontoCanceladoUpdVCJA(intFacturaID, "VCJA", oRow.Item("MontoNoCancelado"), oRow.Item("FormaPagoID"))
                        decMontoAnticipoCliente += oRow.Item("MontoNoCancelado")
                        decImporteDevFactura -= oRow.Item("MontoNoCancelado")

                    End If

                    If decImporteDevFactura = 0 Then
                        Exit For
                    End If

                Next

            End If

        End If

        '------------------------------------------------------------------------------------
        ' JNAVA (18.09.2015): Forma Pago [DPCard Puntos] :
        '------------------------------------------------------------------------------------
        If (decImporteDevFactura = 0) Then

            GoTo SaltoLinea

        End If

        If (ValidarExistenciaFormaPago(intFacturaID, "DPPT") = True) Then

            decMontoNoCancelado = ExtraerMontoNoCancelado(intFacturaID, "DPPT")

            'DPCard Puntos cubre ImporteDevFactura :
            If (decMontoNoCancelado >= decImporteDevFactura) Then

                MontoCanceladoUpd(intFacturaID, "DPPT", decImporteDevFactura)
                decMontoAnticipoCliente += decImporteDevFactura
                decImporteDevFactura = 0

                'DPCard Puntos cubre una parte del ImporteDevFactura :
            ElseIf (decMontoNoCancelado < decImporteDevFactura) And (decMontoNoCancelado > 0) Then

                'Actualizar Monto Cancelado DPCard Puntos :
                MontoCanceladoUpd(intFacturaID, "DPPT", decMontoNoCancelado)
                decMontoAnticipoCliente += decMontoNoCancelado
                decImporteDevFactura -= decMontoNoCancelado
            End If

        End If
        If (decImporteDevFactura = 0) Then

            GoTo SaltoLinea

        End If

        '------------------------------------------------------------------------------------
        ' FLIZARRAGA 26/10/2015: Forma Pago DPCard Credit :
        '------------------------------------------------------------------------------------
        If (ValidarExistenciaFormaPago(intFacturaID, "DPCA") = True) Then
            decMontoNoCancelado = ExtraerMontoNoCancelado(intFacturaID, "DPCA")

            'FLIZARRAGA 26/10/2015: DPCard Credit cubre ImporteDevFactura :
            If (decMontoNoCancelado >= decImporteDevFactura) Then
                MontoCanceladoUpd(intFacturaID, "DPCA", decImporteDevFactura)
                decMontoAnticipoCliente += decImporteDevFactura
                decImporteDevFactura = 0

                'DPCard Credit cubre una parte del ImporteDevFactura :
            ElseIf (decMontoNoCancelado < decImporteDevFactura) And (decMontoNoCancelado > 0) Then

                'Actualizar Monto Cancelado DPCard Puntos :
                MontoCanceladoUpd(intFacturaID, "DPCA", decMontoNoCancelado)
                decMontoAnticipoCliente += decMontoNoCancelado
                decImporteDevFactura -= decMontoNoCancelado
            End If
        End If

SaltoLinea:


        If (strCodBanco <> String.Empty) Then

            'Guardar Registro. (decMontoCancelarTarjetaCredito, MontoAnticipoCliente)

            AgregarRegistroDistribucionNotaCreditoDetalle(intAnticipoID, decMontoCancelarTarjetaCredito, decMontoAnticipoCliente, _
                                                          decMontoDPVale, decMontoCreditoDirecto, decMontoFonacotFacilito, decMontoCanje, intFolioReferencia, strCodBanco, strNumeroTarjeta, _
                                                          strNumeroAutorizacion, intDPValeID)

        Else

            AgregarRegistroDistribucionNotaCreditoDetalle(intAnticipoID, decMontoCancelarTarjetaCredito, decMontoAnticipoCliente, _
                                                          decMontoDPVale, decMontoCreditoDirecto, decMontoFonacotFacilito, decMontoCanje, intFolioReferencia, , , , intDPValeID)

        End If

    End Sub



    Private Sub AgregarRegistroDistribucionNotaCreditoDetalle(ByVal intAnticipoID As Integer, _
                                                              ByVal decMontoCancelarTarjetaCredito As Decimal, _
                                                              ByVal decMontoAnticipoCliente As Decimal, _
                                                              ByVal decMontoDPVale As Decimal, _
                                                              ByVal decMontoCreditoDirecto As Decimal, _
                                                              ByVal decMontoFonacotFacilito As Decimal, _
                                                              ByVal decMontoCanje As Decimal, _
                                                              ByVal intFolioReferencia As Integer, _
                                                              Optional ByVal strCodBanco As String = "", _
                                                              Optional ByVal strNumeroTarjeta As String = "", _
                                                              Optional ByVal strNumeroAutorizacion As String = "", _
                                                              Optional ByVal intDPValeID As String = "")

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                         DataStorageConfiguration.GetConnectionString)

        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand

        Dim intReturnValue As Integer

        Dim datReturnValue As Date



        With sccmdInsert

            .Connection = sccnnConnection

            .CommandText = "[AnticiposClientesDetalleIns]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@AnticipoID", System.Data.SqlDbType.Int))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Referencia", System.Data.SqlDbType.Int))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@DPValeID", System.Data.SqlDbType.VarChar, 10))
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


            'OutPut :
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@AnticipoClienteDetalleID", System.Data.SqlDbType.Int))
            .Parameters("@AnticipoClienteDetalleID").Direction = ParameterDirection.Output

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime))
            .Parameters("@Fecha").Direction = ParameterDirection.Output

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@MontoCanceladoCanje", System.Data.SqlDbType.Money))

        End With

        Try
            sccnnConnection.Open()

            With sccmdInsert

                'Assign Parameters Values

                .Parameters("@AnticipoID").Value = intAnticipoID
                .Parameters("@Referencia").Value = intFolioReferencia
                .Parameters("@DPValeID").Value = intDPValeID
                .Parameters("@CodBanco").Value = strCodBanco
                .Parameters("@NumeroTarjeta").Value = strNumeroTarjeta
                .Parameters("@NumeroAutorizacion").Value = strNumeroAutorizacion
                .Parameters("@NumeroAutorizacionCancelacion").Value = String.Empty
                .Parameters("@MontoCanceladoTarjeta").Value = decMontoCancelarTarjetaCredito
                .Parameters("@MontoCanceladoDPVale").Value = decMontoDPVale
                .Parameters("@AnticipoCliente").Value = decMontoAnticipoCliente
                .Parameters("@MontoCanceladoCDT").Value = decMontoCreditoDirecto
                .Parameters("@MontoAbonos").Value = 0.0
                .Parameters("@Usuario").Value = oParent.ApplicationContext.Security.CurrentUser.Name
                .Parameters("@StatusRegistro").Value = 1
                .Parameters("@MontoFonacotFacilito").Value = decMontoFonacotFacilito
                .Parameters("@MontoCanceladoCanje").Value = decMontoCanje

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

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

    End Sub



    Public Function ValidarCantidadArticulo(ByVal intCantidadArticulo As Integer, ByVal strCodArticulo As String, _
                                            ByVal strTalla As String, ByVal intFacturaID As Integer) As Boolean

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        Dim dsDataSet As DataSet
        dsDataSet = New DataSet



        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[NotaCreditoDetalleValidarCantidad]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FacturaID", System.Data.SqlDbType.Int))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodArticulo", System.Data.SqlDbType.VarChar, 20))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Talla", System.Data.SqlDbType.VarChar, 4))


            'OutPut :
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Cantidad", System.Data.SqlDbType.Decimal))
            .Parameters("@Cantidad").Direction = ParameterDirection.Output

        End With


        Try

            sccnnConnection.Open()

            With sccmdSelect
                'Assign Parameters Values
                .Parameters("@FacturaID").Value = intFacturaID
                .Parameters("@CodArticulo").Value = strCodArticulo
                .Parameters("@Talla").Value = strTalla

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



    Public Function ValidarCantidadDevueltaArticulo(ByVal oFactura As Factura, ByVal strCodArticulo As String, _
                                                    ByVal decTalla As String, ByVal intCantidadUser As Integer) As Boolean

        Dim intCantidadArticuloDisponible As Integer = ExtraerCantidadArticulo(strCodArticulo, decTalla, oFactura.FacturaID) - _
                                                       ExtraerCantidadDevueltaArticulo(strCodArticulo, decTalla, oFactura.FolioFactura)


        If (intCantidadArticuloDisponible >= intCantidadUser) Then

            Return True

        End If

    End Function



    Public Function ExtraerCantidadArticulo(ByVal strCodArticulo As String, ByVal strTalla As String, _
                                            ByVal intFacturaID As Integer) As Integer

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        Dim dsDataSet As DataSet
        dsDataSet = New DataSet

        Dim intReturnValue As Integer


        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[NotaCreditoDetalleValidarCantidad]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FacturaID", System.Data.SqlDbType.Int))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodArticulo", System.Data.SqlDbType.VarChar, 20))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Talla", System.Data.SqlDbType.VarChar, 4))


            'OutPut :
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Cantidad", System.Data.SqlDbType.Decimal))
            .Parameters("@Cantidad").Direction = ParameterDirection.Output

        End With


        Try

            sccnnConnection.Open()

            With sccmdSelect
                'Assign Parameters Values
                .Parameters("@FacturaID").Value = intFacturaID
                .Parameters("@CodArticulo").Value = strCodArticulo
                .Parameters("@Talla").Value = strTalla

                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) And (IsDBNull(scdrReader.Item(0)) <> True) Then

                    With scdrReader

                        intReturnValue = .GetDecimal(0)

                        'If (.GetDecimal(0) < intCantidadArticulo) Then
                        '    .Close()
                        '    sccnnConnection.Close()
                        '    Return False
                        'End If

                    End With

                Else

                    scdrReader.Close()
                    sccnnConnection.Close()

                    intReturnValue = 0

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

        Return intReturnValue

    End Function



    Public Function ExtraerCantidadDevueltaArticulo(ByVal strCodArticulo As String, ByVal strTalla As String, _
                                                    ByVal intFacturaFolio As String) As Integer

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        Dim dsDataSet As DataSet
        dsDataSet = New DataSet


        Dim intReturnValue As Integer



        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[NotaCreditoDetalleValidarCantidadDevuelta]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FacturaFolio", System.Data.SqlDbType.VarChar, 10))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodArticulo", System.Data.SqlDbType.VarChar, 20))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Talla", System.Data.SqlDbType.VarChar, 4))



            'OutPut :
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CantidadDevuelta", System.Data.SqlDbType.Int))
            .Parameters("@CantidadDevuelta").Direction = ParameterDirection.Output

        End With


        Try

            sccnnConnection.Open()

            With sccmdSelect
                'Assign Parameters Values
                .Parameters("@FacturaFolio").Value = intFacturaFolio
                .Parameters("@CodArticulo").Value = strCodArticulo
                .Parameters("@Talla").Value = strTalla
                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) And (scdrReader.IsDBNull(0) <> True) Then

                    With scdrReader

                        intReturnValue = .GetInt32(0)

                        'If (.GetDecimal(0) < intCantidadArticulo) Then
                        '    .Close()
                        '    sccnnConnection.Close()
                        '    Return False
                        'End If

                    End With

                Else

                    scdrReader.Close()
                    sccnnConnection.Close()

                    intReturnValue = 0

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

        Return intReturnValue

    End Function



    Public Function ValidarExistenciaFormaPago(ByVal intFacturaID As Integer, ByVal strFormaPagoID As String) As Boolean

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                              GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        Dim dsDataSet As DataSet
        dsDataSet = New DataSet



        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[NotaCreditoDetalleValidarExistenciaFormaPago]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FacturaID", System.Data.SqlDbType.Int))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodFormasPago", System.Data.SqlDbType.VarChar, 4))

        End With


        Try

            sccnnConnection.Open()

            With sccmdSelect
                'Assign Parameters Values
                .Parameters("@FacturaID").Value = intFacturaID
                .Parameters("@CodFormasPago").Value = strFormaPagoID

                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                'If (scdrReader.HasRows) And (IsDBNull(scdrReader.Item(0)) <> True) Then
                If Not (scdrReader.HasRows) Then

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



    Public Function ValidarFacturaTipoVenta(ByVal intFacturaID As Integer, ByVal strTipoVentaID As String, ByVal strTablaTmp As String) As Boolean

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        Dim dsDataSet As DataSet
        dsDataSet = New DataSet



        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[NotaCreditoDetalleValidarTipoVenta]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FacturaID", System.Data.SqlDbType.Int))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodTipoVenta", System.Data.SqlDbType.Char, 1))

        End With


        Try

            sccnnConnection.Open()

            With sccmdSelect

                'Assign Parameters Values
                .Parameters("@FacturaID").Value = intFacturaID
                .Parameters("@CodTipoVenta").Value = strTipoVentaID

                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()


                If Not (scdrReader.HasRows) Then

                    scdrReader.Close()
                    sccnnConnection.Close()

                    Return False

                Else

                    Dim dsValidarTipoVenta As DataSet

                    dsValidarTipoVenta = FillDataSet("NotaCreditoDetalleTmpSel", strTablaTmp) ' "NotaCreditoDetalleTmp" & oParent.ApplicationContext.ApplicationConfiguration.Almacen & oParent.ApplicationContext.ApplicationConfiguration.NoCaja & oParent.ApplicationContext.Security.CurrentUser.ID)

                    'Registros posteriores.
                    If (dsValidarTipoVenta.Tables(0).Rows.Count > 0) Then

                        'Compara el TipoVenta del Primer Registro con el Registro Actual [Deben coincidir].
                        If strTipoVentaID = "A" And (dsValidarTipoVenta.Tables(0).Rows.Item(0).Item("CodTipoVenta") = "A" Or dsValidarTipoVenta.Tables(0).Rows.Item(0).Item("CodTipoVenta") = "D") Then

                            'No hacemos nada... damos como correcta la validación

                        Else

                            If (dsValidarTipoVenta.Tables(0).Rows.Item(0).Item("CodTipoVenta") <> strTipoVentaID) Then

                                dsValidarTipoVenta.Dispose()

                                dsValidarTipoVenta = Nothing

                                scdrReader.Close()
                                sccnnConnection.Close()

                                Return False

                            End If

                        End If


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

        Return True

    End Function



    Public Function ValidarFacturaDPVale(ByVal intFacturaID As Integer, ByVal strTablaTmp As String) As Boolean

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Try

            sccnnConnection.Open()

            Dim dsValidarFacturaDPVale As DataSet

            dsValidarFacturaDPVale = FillDataSet("NotaCreditoDetalleTmpSel", strTablaTmp) '"NotaCreditoDetalleTmp" & oParent.ApplicationContext.ApplicationConfiguration.Almacen & oParent.ApplicationContext.ApplicationConfiguration.NoCaja & oParent.ApplicationContext.Security.CurrentUser.ID)

            'Registros posteriores.
            If (dsValidarFacturaDPVale.Tables(0).Rows.Count > 0) Then

                'Compara el TipoVenta del Primer Registro con el Registro Actual [Deben coincidir].

                If (dsValidarFacturaDPVale.Tables(0).Rows.Item(0).Item("FacturaID") <> intFacturaID) Then

                    dsValidarFacturaDPVale.Dispose()

                    dsValidarFacturaDPVale = Nothing

                    Return False

                End If

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

        Return True

    End Function



    Friend Function ExtraerMontoNoCancelado(ByVal intFacturaID As Integer, ByVal strFormaPagoID As String) As Decimal


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
            .CommandText = "[NotaCreditoMontoNoCanceladoExtraer]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FacturaID", System.Data.SqlDbType.Int))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodFormasPago", System.Data.SqlDbType.VarChar, 4))


            'OutPut :
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@MontoNoCancelado", System.Data.SqlDbType.Decimal))
            .Parameters("@MontoNoCancelado").Direction = ParameterDirection.Output

        End With


        Try

            sccnnConnection.Open()

            With sccmdSelect
                'Assign Parameters Values
                .Parameters("@FacturaID").Value = intFacturaID
                .Parameters("@CodFormasPago").Value = strFormaPagoID

                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) And (IsDBNull(scdrReader.Item(0)) <> True) Then

                    With scdrReader

                        decValor = .GetDecimal(0)

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

        Return decValor

    End Function

    Private Function ExtraerMontoNoCanceladoVCJA(ByVal intFacturaID As Integer, ByVal strFormaPagoID As String) As DataSet

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdaAdapter As New SqlDataAdapter

        Dim dsDataSet As DataSet
        dsDataSet = New DataSet


        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[NotaCreditoMontoNoCanceladoExtraerVCJA]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FacturaID", System.Data.SqlDbType.Int))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodFormasPago", System.Data.SqlDbType.VarChar, 4))


            'OutPut :
            '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@MontoNoCancelado", System.Data.SqlDbType.Decimal))
            '.Parameters("@MontoNoCancelado").Direction = ParameterDirection.Output

        End With


        Try

            sccnnConnection.Open()

            With sccmdSelect
                'Assign Parameters Values
                .Parameters("@FacturaID").Value = intFacturaID
                .Parameters("@CodFormasPago").Value = strFormaPagoID

                scdaAdapter.SelectCommand = sccmdSelect

                scdaAdapter.Fill(dsDataSet)


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

        sccmdSelect.Dispose()
        sccmdSelect = Nothing

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return dsDataSet

    End Function


    Private Sub ExtraerInformacionTarjeta(ByVal intFacturaID As Integer, ByRef strCodBanco As String, _
                                          ByRef strNumeroTarjeta As String, ByRef strNumeroAutorizacion As String, ByVal CodFormaPago As String)

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
            .CommandText = "[NotaCreditoExtraerInformacionTarjeta]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FacturaID", System.Data.SqlDbType.Int))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodFormasPago", System.Data.SqlDbType.VarChar, 4))


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
                .Parameters("@FacturaID").Value = intFacturaID
                .Parameters("@CodFormasPago").Value = CodFormaPago
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

    Private Function ExtraerInformacionTarjetaTADB(ByVal intFacturaID As Integer, ByRef strCodBanco As String, _
                                          ByRef strNumeroTarjeta As String, ByRef strNumeroAutorizacion As String, ByVal CodFormaPago As String, ByVal FormaPagoId As Integer)

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
            .CommandText = "[NotaCreditoExtraerInformacionTarjetaTADB]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FacturaID", System.Data.SqlDbType.Int))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodFormasPago", System.Data.SqlDbType.VarChar, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FormaPagoID", System.Data.SqlDbType.Int))


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
                .Parameters("@FacturaID").Value = intFacturaID
                .Parameters("@CodFormasPago").Value = CodFormaPago
                .Parameters("@FormaPagoID").Value = FormaPagoId
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

    End Function


    Private Function ExtraerDPValeID(ByVal intFacturaID As Integer) As String

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                         GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        Dim dsDataSet As DataSet
        dsDataSet = New DataSet

        Dim intValor As String = ""



        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[NotaCreditoExtraerDPValeID]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FacturaID", System.Data.SqlDbType.Int))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodFormasPago", System.Data.SqlDbType.VarChar, 4))


            'OutPut :
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@DPValeID", System.Data.SqlDbType.VarChar, 10))
            .Parameters("@DPValeID").Direction = ParameterDirection.Output

        End With


        Try

            sccnnConnection.Open()

            With sccmdSelect

                'Assign Parameters Values
                .Parameters("@FacturaID").Value = intFacturaID
                .Parameters("@CodFormasPago").Value = "DPVL"
                .Parameters("@DPValeID").Value = 0

                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) And (IsDBNull(scdrReader.Item(0)) <> True) Then

                    With scdrReader

                        intValor = CStr(scdrReader("DPValeID"))

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

        Return intValor

    End Function


    Private Function ExtraerDPValeIDByFolioSAP(ByVal strFacturaID As String) As Integer

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                         GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        Dim dsDataSet As DataSet
        dsDataSet = New DataSet

        Dim intValor As Integer



        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[NotaCreditoExtraerDPValeIDByFolioSAP]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioSAP", System.Data.SqlDbType.VarChar, 10))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodFormasPago", System.Data.SqlDbType.VarChar, 4))


            'OutPut :
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@DPValeID", System.Data.SqlDbType.Int))
            .Parameters("@DPValeID").Direction = ParameterDirection.Output

        End With


        Try

            sccnnConnection.Open()

            With sccmdSelect

                'Assign Parameters Values
                .Parameters("@FolioSAP").Value = strFacturaID
                .Parameters("@CodFormasPago").Value = "DPVL"
                .Parameters("@DPValeID").Value = 0

                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) And (IsDBNull(scdrReader.Item(0)) <> True) Then

                    With scdrReader

                        intValor = .GetInt32(0)

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

        Return intValor

    End Function

    Private Function ExtraerClienteID(ByVal intFacturaID As Integer) As Integer

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        Dim dsDataSet As DataSet
        dsDataSet = New DataSet

        Dim intValor As Integer



        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[NotaCreditoExtraerClienteID]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FacturaID", System.Data.SqlDbType.Int))


            'OutPut :
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ClienteID", System.Data.SqlDbType.Int))
            .Parameters("@ClienteID").Direction = ParameterDirection.Output

        End With


        Try

            sccnnConnection.Open()

            With sccmdSelect

                'Assign Parameters Values
                .Parameters("@FacturaID").Value = intFacturaID
                .Parameters("@ClienteID").Value = 0

                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) And (IsDBNull(scdrReader.Item(0)) <> True) Then

                    With scdrReader

                        intValor = .GetInt32(0)

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

        Return intValor

    End Function




    Private Sub MontoCanceladoUpd(ByVal intFacturaID As Integer, ByVal strFormaPagoID As String, ByVal decMontoCancelado As Decimal)

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                                 DataStorageConfiguration.GetConnectionString)

        Dim sccmdUpdate As SqlCommand
        sccmdUpdate = New SqlCommand

        With sccmdUpdate

            .Connection = sccnnConnection

            .CommandText = "[NotaCreditoMontoCanceladoUpd]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FacturaID", System.Data.SqlDbType.Int))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodFormasPago", System.Data.SqlDbType.VarChar, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@MontoCancelado", System.Data.SqlDbType.Money))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@MontoCanceladoActual", System.Data.SqlDbType.Decimal))

        End With

        Try

            sccnnConnection.Open()

            With sccmdUpdate

                'Assign Parameters Values
                .Parameters("@FacturaID").Value = intFacturaID
                .Parameters("@CodFormasPago").Value = strFormaPagoID
                .Parameters("@MontoCancelado").Value = decMontoCancelado
                .Parameters("@MontoCanceladoActual").Value = 0

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

    Private Sub MontoCanceladoUpdVCJA(ByVal intFacturaID As Integer, ByVal strFormaPagoID As String, ByVal decMontoCancelado As Decimal, ByVal FormaPagoID As Integer)

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                                 DataStorageConfiguration.GetConnectionString)

        Dim sccmdUpdate As SqlCommand
        sccmdUpdate = New SqlCommand

        With sccmdUpdate

            .Connection = sccnnConnection

            .CommandText = "[NotaCreditoMontoCanceladoUpdVCJA]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FacturaID", System.Data.SqlDbType.Int))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodFormasPago", System.Data.SqlDbType.VarChar, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@MontoCancelado", System.Data.SqlDbType.Money))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@MontoCanceladoActual", System.Data.SqlDbType.Decimal))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FormaPagoID", System.Data.SqlDbType.Int))

        End With

        Try

            sccnnConnection.Open()

            With sccmdUpdate

                'Assign Parameters Values
                .Parameters("@FacturaID").Value = intFacturaID
                .Parameters("@CodFormasPago").Value = strFormaPagoID
                .Parameters("@MontoCancelado").Value = decMontoCancelado
                .Parameters("@MontoCanceladoActual").Value = 0
                .Parameters("@FormaPagoID").Value = FormaPagoID

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



    Public Function ValidarExistenciaArticulo(ByVal strCodArticulo As String, ByVal strTalla As String, _
                                              ByVal intFacturaID As Integer) As Boolean

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                              GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        Dim dsDataSet As DataSet
        dsDataSet = New DataSet



        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[NotaCreditoDetalleValidarExistenciaArticulo]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FacturaID", System.Data.SqlDbType.Int, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodArticulo", System.Data.SqlDbType.VarChar, 20))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Talla", System.Data.SqlDbType.VarChar, 4))

        End With


        Try

            sccnnConnection.Open()

            With sccmdSelect
                'Assign Parameters Values
                .Parameters("@FacturaID").Value = intFacturaID
                .Parameters("@CodArticulo").Value = strCodArticulo
                .Parameters("@Talla").Value = strTalla

                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                'If (scdrReader.HasRows) And (IsDBNull(scdrReader.Item(0)) <> True) Then
                If Not (scdrReader.HasRows) Then

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



    Public Function ValidarFactura(ByVal intFacturaID As Integer, ByVal strCodCaja As String, ByVal strClienteID As String, ByVal ValidaPG As Boolean) As Boolean

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                              GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        Dim dsDataSet As DataSet
        dsDataSet = New DataSet



        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[NotaCreditoDetalleValidarFactura]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FacturaID", System.Data.SqlDbType.Int))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ClienteID", System.Data.SqlDbType.VarChar, 10))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CajaID", System.Data.SqlDbType.VarChar, 2))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ValidaPG", System.Data.SqlDbType.Bit, 1))

        End With


        Try

            sccnnConnection.Open()

            With sccmdSelect
                'Assign Parameters Values
                .Parameters("@FacturaID").Value = intFacturaID
                .Parameters("@ClienteID").Value = strClienteID.PadLeft(10, "0")
                .Parameters("@CajaID").Value = strCodCaja
                .Parameters("@ValidaPG").Value = ValidaPG



                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                'If (scdrReader.HasRows) And (IsDBNull(scdrReader.Item(0)) <> True) Then
                If Not (scdrReader.HasRows) Then

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



    Public Function ExtraerCostoUnit(ByVal intFacturaID As Integer, ByVal strCodArticulo As String, ByVal strTalla As String) As Decimal

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        Dim dsDataSet As DataSet
        dsDataSet = New DataSet

        Dim decCostoUnit As Decimal



        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[NotaCreditoDetalleExtraerCostoUnit]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FacturaID", System.Data.SqlDbType.Int))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodArticulo", System.Data.SqlDbType.VarChar, 20))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Talla", System.Data.SqlDbType.VarChar, 4))

            'OutPut :
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CostoUnit", System.Data.SqlDbType.Decimal))
            .Parameters("@CostoUnit").Direction = ParameterDirection.Output

        End With


        Try

            sccnnConnection.Open()

            With sccmdSelect
                'Assign Parameters Values
                .Parameters("@FacturaID").Value = intFacturaID
                .Parameters("@CodArticulo").Value = strCodArticulo
                .Parameters("@Talla").Value = strTalla

                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    With scdrReader

                        'Return .GetDecimal(0)
                        decCostoUnit = .GetDecimal(0)

                    End With

                Else

                    scdrReader.Close()
                    sccnnConnection.Close()

                    decCostoUnit = 0

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

        Return decCostoUnit

    End Function



    Public Function ExtraerPrecioUnit(ByVal intFacturaID As Integer, ByVal strCodArticulo As String, ByVal strTalla As String) As Decimal

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        Dim dsDataSet As DataSet
        dsDataSet = New DataSet

        Dim decPrecioOferta As Decimal



        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[NotaCreditoDetalleExtraerPrecioOferta]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FacturaID", System.Data.SqlDbType.Int))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodArticulo", System.Data.SqlDbType.VarChar, 20))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Talla", System.Data.SqlDbType.VarChar, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Descuento", System.Data.SqlDbType.Decimal))

            'OutPut :
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@PrecioOferta", System.Data.SqlDbType.Decimal))
            .Parameters("@PrecioOferta").Direction = ParameterDirection.Output

        End With


        Try

            sccnnConnection.Open()

            With sccmdSelect
                'Assign Parameters Values
                .Parameters("@FacturaID").Value = intFacturaID
                .Parameters("@CodArticulo").Value = strCodArticulo
                .Parameters("@Talla").Value = strTalla
                .Parameters("@Descuento").Value = 0

                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    With scdrReader

                        'Return .GetDecimal(0)
                        decPrecioOferta = .GetDecimal(0)

                    End With

                Else

                    scdrReader.Close()
                    sccnnConnection.Close()

                    decPrecioOferta = 0

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

        Return decPrecioOferta

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

            .CommandText = strStoredProcedure
            .CommandType = System.Data.CommandType.StoredProcedure

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
    Public Function FolioProSel(ByVal FolioSAP As String) As DataSet

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                GetConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaFPSel As SqlDataAdapter
        Dim dsFPSel As DataSet



        sccmdSelectAll = New SqlCommand
        scdaFPSel = New SqlDataAdapter
        dsFPSel = New DataSet

        With sccmdSelectAll

            .Connection = sccnnConnection

            .CommandText = "[FacturaFolioCajaGet]"
            .CommandType = System.Data.CommandType.StoredProcedure

            '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NombreTabla", System.Data.SqlDbType.VarChar, 40))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Referencia", System.Data.SqlDbType.VarChar, 20, "Referencia"))
            '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioSAP", System.Data.SqlDbType.Int, 4, "FolioFactura"))

            .Parameters("@Referencia").Value = FolioSAP
        End With

        scdaFPSel.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()



            'Fill DataSet
            scdaFPSel.Fill(dsFPSel)

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

        Return dsFPSel

    End Function




    Public Function NotaCreditoFolios() As Integer

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
            .CommandText = "[NotaCreditoFolios]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar, 2))

            'OutPut :
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioNotaCredito", System.Data.SqlDbType.Int))
            .Parameters("@FolioNotaCredito").Direction = ParameterDirection.Output

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



    Public Function SelectUPC(ByVal CodUPC As String) As DataTable

        Dim oResult As DataSet
        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[CatalogoUPCSel]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodUPC", System.Data.SqlDbType.VarChar, 20, "CodUPC"))
            .Parameters("@CodUPC").Value = CodUPC

        End With

        Dim oUPCAdapter As SqlDataAdapter
        oUPCAdapter = New SqlDataAdapter
        oUPCAdapter.SelectCommand = sccmdSelect

        Try

            sccnnConnection.Open()

            oResult = New DataSet

            oUPCAdapter.Fill(oResult, "UPC")

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

#End Region

#Region "Credito Directo"

    ''Funcion para Abono Credito Directo
    Public Function GetIDAsociado(ByVal IDCliente As Integer) As Integer

        ' Dim wsAsociado As New wsAsociados.CreditoAsociados

        If Not oParent.ApplicationContext.ApplicationConfiguration.WSUrl = String.Empty Then

            'wsAsociado.Url = oParent.ApplicationContext.ApplicationConfiguration.WSUrl.TrimEnd(CChar("/")) _
            '                   & "/" & wsAsociado.strURL.TrimStart(CChar("/"))

        End If

        ' Dim oAsociado As New AsociadoInfo

        'oAsociado = wsAsociado.GetAsociadoByClienteID(IDCliente)
        'Return oAsociado.AsociadoID

    End Function

    Public Function FacturasPorLiquidar(ByVal IDAsociado As Integer) As DataSet

        'Dim wsFactPorLiq As New AbonoCreditoDirectoX

        If Not oParent.ApplicationContext.ApplicationConfiguration.WSUrl = String.Empty Then

            'wsFactPorLiq.Url = oParent.ApplicationContext.ApplicationConfiguration.WSUrl.TrimEnd(CChar("/")) _
            ' & "/" & wsFactPorLiq.strURL.TrimStart(CChar("/"))

        End If

        'FacturasPorLiquidar = wsFactPorLiq.SelectFacturasByID(IDAsociado)

        Return FacturasPorLiquidar

    End Function

#End Region

#Region "Comunicación SAP"

    '    Public Sub SaveSAP(ByVal pNotaCredito As NotaCredito)
    '        Try

    '            Dim strCodCaja As String
    '            oDPVale = New cDPVale

    '            Dim objR3 As New SAPFunctionsOCX.SAPFunctions
    '            Dim objFunc As SAPFunctionsOCX.Function

    '            'Parametros Exports
    '            Dim CLASEPEDIDO As SAPFunctionsOCX.Parameter    'Clase Pedido
    '            Dim OFICINAVTA As SAPFunctionsOCX.Parameter     'Oficina de Ventas
    '            Dim I_AGENTE As SAPFunctionsOCX.Parameter       'Grupo de Vendedores
    '            Dim I_WERKS As SAPFunctionsOCX.Parameter        'Centro
    '            Dim I_CREDITO As SAPFunctionsOCX.Parameter      'Indicador de una posicion
    '            Dim I_KUNNR As SAPFunctionsOCX.Parameter        'Número de Cliente
    '            Dim I_ZONAVTA As SAPFunctionsOCX.Parameter      'Zona de Ventas
    '            Dim I_FACTURA As SAPFunctionsOCX.Parameter      'Folio Factura
    '            Dim I_KEYPRO As SAPFunctionsOCX.Parameter      'Llave del DPPRO--T+Almacen+Caja+FolioNotaCredito
    '            'Dim I_FECHAFACT As SAPFunctionsOCX.Parameter    'Fecha Movimiento
    '            Dim oStructureSAP As Object
    '            'Fin Parametros Exports

    '            'Parametros Imports
    '            Dim SALESDOCUMENT As SAPFunctionsOCX.Parameter 'Documento de Ventas
    '            Dim FIDOCUMENT As SAPFunctionsOCX.Parameter 'Número de un Documento Contable
    '            'Dim E_IMPORTE As SAPFunctionsOCX.Parameter 'Importe de la devolucion en SAP
    '            'Dim E_IVA As SAPFunctionsOCX.Parameter 'IVA de la devolucion en SAP
    '            'Fin parametros Imports

    '            'Tablas
    '            Dim oTableSAP As SAPTableFactoryCtrl.Table
    '            Dim oRETURN As Object
    '            'Fin Tablas

    '            With objR3.Connection
    '                .ApplicationServer = oParent.SAPApplicationConfig.ApplicationServer
    '                .GroupName = oParent.SAPApplicationConfig.GroupName
    '                .System = oParent.SAPApplicationConfig.System
    '                .Client = oParent.SAPApplicationConfig.Client
    '                .User = oParent.SAPApplicationConfig.User
    '                .Password = oParent.SAPApplicationConfig.Password
    '                .language = oParent.SAPApplicationConfig.Language
    '                .SystemNumber = oParent.SAPApplicationConfig.System
    '            End With

    '            If objR3.Connection.logon(0, True) <> True Then
    '                Throw New ApplicationException("No se pudo establecer la conexión con SAP.")
    '            End If

    '            objFunc = objR3.Add("ZBAPISD17_DEV_VENTAS")

    '            'Exports
    '            CLASEPEDIDO = objFunc.Exports("CLASEPEDIDO")
    '            OFICINAVTA = objFunc.Exports("OFICINAVTA")
    '            I_AGENTE = objFunc.Exports("I_AGENTE")
    '            I_WERKS = objFunc.Exports("I_WERKS")
    '            I_CREDITO = objFunc.Exports("I_CREDITO")
    '            I_KUNNR = objFunc.Exports("I_KUNNR")
    '            I_ZONAVTA = objFunc.Exports("I_ZONAVTA")
    '            I_FACTURA = objFunc.Exports("I_FACTURA")
    '            I_KEYPRO = objFunc.Exports("I_KEYPRO")
    '            'I_FECHAFACT = objFunc.Exports("I_FECHAFACT")
    '            'Fin Exports

    '            'Tablas
    '            oTableSAP = objFunc.Tables("DATOSDET")
    '            'Fin Tablas

    '            'Imports
    '            SALESDOCUMENT = objFunc.Imports("SALESDOCUMENT")
    '            FIDOCUMENT = objFunc.Imports("FIDOCUMENT")
    '            oRETURN = objFunc.Imports("RETURN")
    '            'E_IMPORTE = objFunc.Imports("E_IMPORTE")
    '            'E_IVA = objFunc.Imports("E_IVA")
    '            'Fin Imports

    '            'Captura de Info
    '            CLASEPEDIDO.Value = "Z" & Mid(pNotaCredito.AlmacenID, 2, 2) & "3"

    '            If oParent.ApplicationContext.ApplicationConfiguration.Almacen = "053" Then
    '                GoTo Cambio_053
    '                'OFICINAVTA.Value = "C053"
    '            Else
    'Cambio_053:
    '                OFICINAVTA.Value = "T" & pNotaCredito.AlmacenID
    '            End If

    '            I_AGENTE.Value = pNotaCredito.PlayerID
    '            If oParent.ApplicationContext.ApplicationConfiguration.Almacen = "053" Then
    '                'Cambio_053
    '                'I_WERKS.Value = "C053"
    '                I_WERKS.Value = "T053"
    '            Else
    '                I_WERKS.Value = "T" & pNotaCredito.AlmacenID
    '            End If

    '            I_CREDITO.Value = "N"
    '            If pNotaCredito.ClienteID.PadLeft(10, "0") = "1".PadLeft(10, "0") Then

    '                If pNotaCredito.TipoVentaID = "V" Then

    '                    If Not Me.oParent.SAPApplicationConfig.DPValeSAP Then
    '                        I_KUNNR.Value = "" & _
    '                                            GetFolioSAPByDPVale(ExtraerDPValeIDByFolioSAP(pNotaCredito.Detalle.Tables(0).Rows(0)("FolioReferencia"))).PadLeft(10, "0")
    '                    Else
    '                        Dim strDpValeIDDP As String = CStr(ExtraerDPValeIDByFolioSAP(pNotaCredito.Detalle.Tables(0).Rows(0)("FolioReferencia"))).PadLeft(10, "0")
    '                        Me.oDPVale.INUMVA = strDpValeIDDP
    '                        Me.oDPVale.I_RUTA = "X"
    '                        oDPVale = oSapCentro.ZBAPI_VALIDA_DPVALE(oDPVale)

    '                        I_KUNNR.Value = CStr(oDPVale.InfoDPVALE.Rows(0).Item("KUNNR")).PadRight(10, " ")
    '                    End If

    '                Else
    '                    I_KUNNR.Value = pNotaCredito.AlmacenID.PadLeft(10, "0")
    '                End If
    '            Else
    '                I_KUNNR.Value = pNotaCredito.ClienteID.PadLeft(10, "0")
    '            End If

    '            I_ZONAVTA.Value = "EFEC"
    '            'I_FECHAFACT.Value = Format(Date.Now.Date, "dd/MM/yyyy")

    '            Dim i As Integer = 0
    '            For Each row As DataRow In pNotaCredito.Detalle.Tables(0).Rows
    '                i += i
    '                oStructureSAP = oTableSAP.AppendRow()
    '                oStructureSAP.Value("Folio") = i
    '                oStructureSAP.Value("MATNR") = row("CodArticulo")
    '                oStructureSAP.Value("Cantidad") = row("Cantidad")

    '                If IsNumeric(row("Numero")) Then
    '                    oStructureSAP.Value("TALLA") = Format(CDec(row("Numero")), "##.0")
    '                Else
    '                    oStructureSAP.Value("TALLA") = row("Numero")
    '                End If

    '                strCodCaja = row!CodCaja
    '                I_FACTURA.Value = CStr(row("FolioReferencia")).PadLeft(10, "0")
    '            Next

    '            I_FACTURA.Value = Me.oAbonoCreditoDirecto.GetSelectFolioFacturaSDSAP(I_FACTURA.Value, strCodCaja)
    '            I_KEYPRO.Value = "T" & oParent.ApplicationContext.ApplicationConfiguration.Almacen & _
    '                        oParent.ApplicationContext.ApplicationConfiguration.NoCaja & pNotaCredito.NotaCreditoFolio
    '            'Fin Captura de Info

    '            If I_FACTURA.Value = String.Empty Then
    '                pNotaCredito.SALESDOCUMENT = String.Empty
    '                pNotaCredito.FIDOCUMENT = String.Empty
    '            Else

    '                objFunc.Call()

    '                If SALESDOCUMENT.Value = String.Empty Then
    '                    'Throw New ApplicationException(oRETURN.Value("message"))
    '                End If

    '                pNotaCredito.SALESDOCUMENT = SALESDOCUMENT.Value
    '                pNotaCredito.FIDOCUMENT = FIDOCUMENT.Value
    '                'pNotaCredito.Importe = E_IMPORTE.Value
    '                'pNotaCredito.IVA = E_IVA.Value

    '            End If

    '            objR3.Connection.LogOff()
    '        Catch ex As Exception
    '            Throw ex
    '        End Try

    '    End Sub

    'Ok
    Public Overridable Sub SaveSAP(ByVal pNotaCredito As NotaCredito, Optional ByRef strError As String = "")

        '----------------------------------------------------------------------------------
        ' JNAVA (04.01.2016): Cambio de libreria para compatibilidad con SAP 6.0
        '----------------------------------------------------------------------------------
        Dim strCodCaja As String
        oDPVale = New cDPVale

        '------------------------------------------------------------------------------
        'JNAVA (09.06.2016): Parametro Inicia Transaccion DPPRO BUS
        '------------------------------------------------------------------------------
        Dim FechaInicio As DateTime
        Dim FechaFin As DateTime
        Dim Intervalo As Long
        '------------------------------------------------------------------------------

        Try
            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)

            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Sub
            Else
                '*****************************************************
                'Call RFC function  ZBAPISD17_DEV_VENTAS
                '*****************************************************
                ' Create a function object
                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZBAPISD17_DEV_VENTAS")

                'Asigno valores
                func.Exports("CLASEPEDIDO").ParamValue = "ZDEV" '& Mid(pNotaCredito.AlmacenID, 2, 2) & "3"

                If oParent.ApplicationContext.ApplicationConfiguration.Almacen = "053" Then
                    GoTo Cambio_053
                    'OFICINAVTA.Value = "C053"
                Else
Cambio_053:
                    func.Exports("OFICINAVTA").ParamValue = "T" & pNotaCredito.AlmacenID
                End If

                func.Exports("I_AGENTE").ParamValue = pNotaCredito.PlayerID
                'If oParent.ApplicationContext.ApplicationConfiguration.Almacen = "053" Then
                '    'Cambio_053
                '    'I_WERKS.Value = "C053"
                '    func.Exports("I_WERKS").ParamValue = "T053"
                'Else
                func.Exports("I_WERKS").ParamValue = oSapCentro.Read_Centros '"T" & pNotaCredito.AlmacenID
                'End If

                func.Exports("I_CREDITO").ParamValue = "N"
                If pNotaCredito.ClienteID.PadLeft(10, "0") = "10000000".PadLeft(10, "0") Then

                    If pNotaCredito.TipoVentaID = "V" Then

                        If Not Me.oParent.SAPApplicationConfig.DPValeSAP Then
                            func.Exports("I_KUNNR").ParamValue = "" & _
                            GetFolioSAPByDPVale(ExtraerDPValeIDByFolioSAP(pNotaCredito.Detalle.Tables(0).Rows(0)("FolioReferencia"))).PadLeft(10, "0")
                        Else
                            Dim strDpValeIDDP As String = CStr(ExtraerDPValeIDByFolioSAP(pNotaCredito.Detalle.Tables(0).Rows(0)("FolioReferencia"))).PadLeft(10, "0")
                            Me.oDPVale.INUMVA = strDpValeIDDP
                            Me.oDPVale.I_RUTA = "X"
                            oDPVale = oSapCentro.ZBAPI_VALIDA_DPVALE(oDPVale)

                            func.Exports("I_KUNNR").ParamValue = CStr(oDPVale.InfoDPVALE.Rows(0).Item("KUNNR")).PadRight(10, " ")
                        End If

                    Else
                        func.Exports("I_KUNNR").ParamValue = pNotaCredito.AlmacenID.PadLeft(10, "0")
                    End If
                Else
                    func.Exports("I_KUNNR").ParamValue = pNotaCredito.ClienteID.PadLeft(10, "0")
                End If

                func.Exports("I_ZONAVTA").ParamValue = "EFEC"
                'I_FECHAFACT.Value = Format(Date.Now.Date, "dd/MM/yyyy")

                Dim T_CLines As ERPConnect.RFCTable = func.Tables("DATOSDET")
                Dim i As Integer = 0
                For Each row As DataRow In pNotaCredito.Detalle.Tables(0).Rows
                    i += i
                    Dim R_CLines As ERPConnect.RFCStructure = T_CLines.AddRow()
                    R_CLines("Folio") = i
                    R_CLines("MATNR") = row("CodArticulo")
                    R_CLines("Cantidad") = row("Cantidad")

                    'If IsNumeric(row("Numero")) Then
                    '    R_CLines("TALLA") = Format(CDec(row("Numero")), "##.0")
                    'Else
                    '    R_CLines("TALLA") = row("Numero")
                    'End If

                    strCodCaja = row!CodCaja
                    func.Exports("I_FACTURA").ParamValue = CStr(row("FolioReferencia")).PadLeft(10, "0")
                Next

                func.Exports("I_FACTURA").ParamValue = Me.oAbonoCreditoDirecto.GetSelectFolioFacturaSDSAP(func.Exports("I_FACTURA").ParamValue, strCodCaja)
                func.Exports("I_FACDPPRO").ParamValue = func.Exports("I_FACTURA").ParamValue
                func.Exports("I_KEYPRO").ParamValue = "T" & oParent.ApplicationContext.ApplicationConfiguration.Almacen & _
                            oParent.ApplicationContext.ApplicationConfiguration.NoCaja & pNotaCredito.NotaCreditoFolio
                'Fin Asigno valores


                If func.Exports("I_FACTURA").ParamValue = String.Empty Then
                    pNotaCredito.SALESDOCUMENT = String.Empty
                    pNotaCredito.FIDOCUMENT = String.Empty
                Else

                    '------------------------------------------------------------------------------
                    ' JNAVA (09.06.2016): Setemos inicio de Transaccion DPPRO con BUS
                    '------------------------------------------------------------------------------
                    If oParent.ConfigCierre.GenerarLogTransacciones Then
                        FechaInicio = Date.Now
                        EscribeLogTransaccionesSAP(True, FechaInicio, "ZBAPISD17_DEV_VENTAS")
                    End If
                    '-----------------------------------------------------------------------------

                    'Ejecutamos la RFC
                    func.Execute()

                    R3.Close()

                    '------------------------------------------------------------------------------
                    ' JNAVA (09.06.2016): Finaliza Transaccion y escribe Log BUS DPPRO
                    '------------------------------------------------------------------------------
                    If oParent.ConfigCierre.GenerarLogTransacciones Then
                        FechaFin = Date.Now
                        Intervalo = DateDiff(DateInterval.Second, FechaInicio, FechaFin)
                        EscribeLogTransaccionesSAP(False, FechaFin, "ZBAPISD17_DEV_VENTAS", "Transacción finalizada sin errores.", Intervalo)
                    End If
                    '------------------------------------------------------------------------------

                    'Obtenemos el Resultado4
                    If CStr(func.Imports("SALESDOCUMENT").ParamValue).Trim() = String.Empty Then
                        'Throw New ApplicationException(oRETURN.Value("message"))
                    End If


                    '------------------------------------------------------------------------------
                    ' MLVARGAS (11.03.2022): Validar que existe el parámetro de Devolución Anterior
                    '------------------------------------------------------------------------------
                    pNotaCredito.DEVANTERIOR = ""

                    For Each sapItem As ERPConnect.RFCParameter In func.Imports()
                        If sapItem.Name = "E_DEV_ANTERIOR" Then
                            pNotaCredito.DEVANTERIOR = sapItem.ParamValue
                            Exit For
                        End If
                    Next

                    pNotaCredito.SALESDOCUMENT = func.Imports("SALESDOCUMENT").ParamValue
                    pNotaCredito.FIDOCUMENT = func.Imports("FIDOCUMENT").ParamValue

                    Dim dtReturn As DataTable = func.Tables("RETURN").ToADOTable()
                    For Each row As DataRow In dtReturn.Rows
                        If row.IsNull("MESSAGE") = False Then
                            strError &= CStr(row("MESSAGE"))
                        End If
                    Next
                    'pNotaCredito.Importe = E_IMPORTE.Value
                    'pNotaCredito.IVA = E_IVA.Value

                End If

            End If

        Catch e1 As ERPConnect.RFCServerException
            '------------------------------------------------------------------------------
            ' JNAVA (09.06.2016): Finaliza Transaccion y escribe Log BUS DPPRO
            '------------------------------------------------------------------------------
            If oParent.ConfigCierre.GenerarLogTransacciones Then
                FechaFin = Date.Now
                Intervalo = DateDiff(DateInterval.Second, FechaInicio, FechaFin)
                EscribeLogTransaccionesSAP(False, FechaFin, "ZBAPISD17_DEV_VENTAS", e1.Message, Intervalo)
            End If
            '------------------------------------------------------------------------------
            Throw e1
        Catch e1 As ERPConnect.ERPException
            '------------------------------------------------------------------------------
            ' JNAVA (09.06.2016): Finaliza Transaccion y escribe Log BUS DPPRO
            '------------------------------------------------------------------------------
            If oParent.ConfigCierre.GenerarLogTransacciones Then
                FechaFin = Date.Now
                Intervalo = DateDiff(DateInterval.Second, FechaInicio, FechaFin)
                EscribeLogTransaccionesSAP(False, FechaFin, "ZBAPISD17_DEV_VENTAS", e1.Message, Intervalo)
            End If
            '------------------------------------------------------------------------------
            Throw e1
        End Try

    End Sub

    Public Sub SaveDPVALESAP(ByVal pNotaCredito As NotaCredito, Optional ByVal EsSiHay As Boolean = False, Optional ByVal FolioPedido As String = "", Optional ByRef strError As String = "")
        Try

            'TODO: Erick.-Inicio Validamos Monto Devolucion Forma Pago DPortenis Vale'
            Dim intFacturaID As Integer ' Factura DPPRO.
            Dim decDevDPVL As Decimal 'Aqui tendremos cuanto hay que descontar del credito en SAP.
            Dim decMontoNoCancelado As Decimal 'Contiene el monto disponible para la cancelacion.
            ''Primer Paso.- Validar que la forma de pago Exisa.
            'FolioReferencia<- En este campo se tiene el folio de factura DPPRO
            intFacturaID = pNotaCredito.Detalle.Tables(0).Rows(0)("FacturaID")
            If (ValidarExistenciaFormaPago(intFacturaID, "DPVL") = True) Then
                decMontoNoCancelado = ExtraerMontoNoCancelado(intFacturaID, "DPVL")
                If decMontoNoCancelado = 0 Then
                    decDevDPVL = 0 'Si la forma de pago ya fue consumida por otras devoluciones entonces no descontamos saldo del credito.
                Else
                    If pNotaCredito.Importe > decMontoNoCancelado Then
                        decDevDPVL = decMontoNoCancelado
                    Else
                        decDevDPVL = pNotaCredito.Importe
                    End If
                End If
            Else
                decDevDPVL = 0 'Si no existe la forma de pago entonces no descontamos saldo del credito.
            End If
            'TODO: Erick.-Fin Validamos Monto Devolucion Forma Pago DPortenis Vale'

            '-------------------------------------------------------------------------------------------------------------
            'JNAVA (19.02.2015): Si es Devolucion con DPVale del SI HAY, determinamos en base al pedido el MontoDPVL
            '-------------------------------------------------------------------------------------------------------------
            If EsSiHay Then
                If FolioPedido.Trim = "" Then
                    decDevDPVL = 0
                End If
            End If
            RestService = New ProcesosRetail("/pos/ventas", "POST", oParent.ConfigCierre, oParent.ApplicationContext, oParent.SAPApplicationConfig)
            RestService.Metodo = "/pos/ventas"
            'RestService.SapZbapisd17_dev_ventas_Dpvl(pNotaCredito, oAbonoCreditoDirecto, FolioPedido, decDevDPVL)
            DevolucionDPVale(pNotaCredito, EsSiHay, FolioPedido, strError)
            If Not oParent.ConfigCierre.AplicarS2Credit Then
                '--------------------------------------------------------------------------------------------------
                ' JNAVA (23.01.2017): Si marca error en la nota de credito, no se ejecuta la devolucion en AFS
                '--------------------------------------------------------------------------------------------------
                If pNotaCredito.SALESDOCUMENT.Trim <> "" Then 'OrElse pNotaCredito.FIDOCUMENT.Trim = "" Then
                    DevolucionDPValeAFS(pNotaCredito, EsSiHay, FolioPedido)
                End If
            End If

            
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Function GetFolioSAPByDPVale(ByVal intDPValeID As Integer) As String

        Dim owsDPValeInfo As DportenisPro.DPTienda.ApplicationUnits.ProcesosAU.ControlDPValesWS.DPValeInfo
        Dim owsValidaDPVale As New DportenisPro.DPTienda.ApplicationUnits.ProcesosAU.ControlDPValesWS.ControlDPVales
        ' Dim oWsSAP As New DportenisPro.DPTienda.ApplicationUnits.FacturasFormaPago.wsSAP.CreditoSAP
        owsDPValeInfo = New DportenisPro.DPTienda.ApplicationUnits.ProcesosAU.ControlDPValesWS.DPValeInfo

        If Not oParent.ApplicationContext.ApplicationConfiguration.WSUrl = String.Empty Then
            'oWsSAP.Url = oParent.ApplicationContext.ApplicationConfiguration.WSUrl.TrimEnd("/") & "/" & _
            'oWsSAP.strUrl.TrimStart("/")

            owsValidaDPVale.Url = oParent.ApplicationContext.ApplicationConfiguration.WSUrl.TrimEnd("/") & "/" & _
            owsValidaDPVale.strURL.TrimStart("/")
        End If


        owsDPValeInfo = owsValidaDPVale.GetDPVale(intDPValeID)

        Dim oResult As String = String.Empty
        'oResult = oWsSAP.GetDistribuidorSAP(owsDPValeInfo.AsociadoID)

        'oWsSAP.Dispose()

        'oWsSAP = Nothing

        Return oResult

    End Function



    Public Function GetDPValeInfo(ByVal intDPValeID As Integer) As String()
        Dim strres(3) As String

        Dim owsDPValeInfo As DportenisPro.DPTienda.ApplicationUnits.ProcesosAU.ControlDPValesWS.DPValeInfo
        Dim owsValidaDPVale As New DportenisPro.DPTienda.ApplicationUnits.ProcesosAU.ControlDPValesWS.ControlDPVales
        'Dim oWsSAP As New DportenisPro.DPTienda.ApplicationUnits.FacturasFormaPago.wsSAP.CreditoSAP
        owsDPValeInfo = New DportenisPro.DPTienda.ApplicationUnits.ProcesosAU.ControlDPValesWS.DPValeInfo

        If Not oParent.ApplicationContext.ApplicationConfiguration.WSUrl = String.Empty Then
            owsValidaDPVale.Url = oParent.ApplicationContext.ApplicationConfiguration.WSUrl.TrimEnd("/") & "/" & _
            owsValidaDPVale.strURL.TrimStart("/")
        End If

        owsDPValeInfo = owsValidaDPVale.GetDPVale(intDPValeID)

        strres(0) = owsDPValeInfo.ClienteAsociado
        strres(1) = owsDPValeInfo.ClienteAsociadoID
        strres(2) = owsDPValeInfo.ClienteID
        strres(3) = owsDPValeInfo.AsociadoID

        Return strres

    End Function

#End Region

    Public Function SeleccionaFolioNCByCaja(ByVal CodCaja As String) As Integer

        Dim strResult As Integer

        Dim sccnnDPTienda As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdFacturaFolioSel As SqlCommand
        sccmdFacturaFolioSel = New SqlCommand

        With sccmdFacturaFolioSel
            .CommandText = "[FolioNCByCaja]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Connection = sccnnDPTienda

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Codcaja", System.Data.SqlDbType.VarChar, 2))

            .Parameters("@CodCaja").Value = CodCaja
        End With

        Try
            sccnnDPTienda.Open()

            Dim scsdrReader As SqlDataReader

            scsdrReader = sccmdFacturaFolioSel.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.SingleRow)

            scsdrReader.Read()

            If (scsdrReader.HasRows) Then

                With scsdrReader
                    strResult = .GetValue(0) 'FolioNotaCredito
                End With
                scsdrReader.Close()

            Else

                strResult = 0

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

        sccmdFacturaFolioSel.Dispose()
        sccmdFacturaFolioSel = Nothing

        sccnnDPTienda.Dispose()
        sccnnDPTienda = Nothing

        Return strResult
    End Function

    Public Function GetDatosNCSAP(ByVal strI_KEYPRO As String, ByRef dt As DataTable) As String

        Dim strResult As String

        strResult = oSapCentro.ZBAPI_VALIDAR_DEVOLUCION(strI_KEYPRO, dt)

        Return strResult
    End Function

#Region "Operacionales"
    Friend Function ReporteOperacionalMarcas(ByVal CodAlmacen As String, ByVal FechaIni As Date, ByVal Fechafin As Date, ByVal Filtro As Integer, ByVal IVA As Decimal) As DataSet
        Dim oResultado As DataSet
        Dim cnnString As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString)
        Dim cmdOperacionalMarcas As SqlCommand
        cmdOperacionalMarcas = New SqlCommand
        Dim daOperacionalMarcas As SqlDataAdapter
        daOperacionalMarcas = New SqlDataAdapter
        With cmdOperacionalMarcas
            .Connection = cnnString
            .CommandText = "ReporteOperacionalMarca"
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaIni", System.Data.SqlDbType.DateTime))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaFin", System.Data.SqlDbType.DateTime))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Filtro", System.Data.SqlDbType.VarChar, 1))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@IVA", System.Data.SqlDbType.Decimal))
            'Asignacion de valores a parametros
            .Parameters("@CodAlmacen").Value = oParent.ApplicationContext.ApplicationConfiguration.Almacen
            .Parameters("@FechaIni").Value = Format(FechaIni, "dd/MM/yyyy")
            .Parameters("@fechaFin").Value = Format(Fechafin, "dd/MM/yyyy")
            .Parameters("@Filtro").Value = Filtro
            .Parameters("@IVA").Value = IVA

        End With
        daOperacionalMarcas.SelectCommand = cmdOperacionalMarcas
        Try
            cnnString.Open()
            oResultado = New DataSet
            daOperacionalMarcas.Fill(oResultado, "OperacionalMarcas")

        Catch ex As Exception
            Throw ex
        Finally
            If (cnnString.State <> ConnectionState.Closed) Then
                Try
                    cnnString.Close()
                Catch
                End Try
            End If
        End Try

        cnnString.Dispose()
        cnnString = Nothing
        cmdOperacionalMarcas.Dispose()
        cmdOperacionalMarcas = Nothing
        Return oResultado
    End Function
    Friend Function ReporteOperacionalMaterial(ByVal CodAlmacen As String, ByVal FechaIni As Date, ByVal FechaFin As Date, ByVal Filtro As Integer, ByVal Year As String, ByVal YearNow As String, ByVal IVA As Decimal) As DataSet
        Dim oResultMaterial As DataSet


        Dim sccnnDPTienda As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString)

        Dim cmdOperacionalMaterial As SqlCommand
        cmdOperacionalMaterial = New SqlCommand
        Dim scdaAlmacenesAdapter As SqlDataAdapter
        scdaAlmacenesAdapter = New SqlDataAdapter

        With cmdOperacionalMaterial
            .CommandText = "[ReporteOperacionalMaterial]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Connection = sccnnDPTienda
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaIni", System.Data.SqlDbType.DateTime))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaFin", System.Data.SqlDbType.DateTime))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@IVA", System.Data.SqlDbType.Decimal))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Year", System.Data.SqlDbType.VarChar, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@YearN", System.Data.SqlDbType.VarChar, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TipoFiltro", System.Data.SqlDbType.VarChar, 1))

            .Parameters("@CodAlmacen").Value = oParent.ApplicationContext.ApplicationConfiguration.Almacen
            .Parameters("@FechaIni").Value = Format(FechaIni, "dd/MM/yyyy")
            .Parameters("@FechaFin").Value = Format(FechaFin, "dd/MM/yyyy")
            .Parameters("@IVA").Value = IVA
            .Parameters("@TipoFiltro").Value = Filtro
            .Parameters("@Year").Value = Year
            .Parameters("@YearN").Value = YearNow

        End With
        scdaAlmacenesAdapter.SelectCommand = cmdOperacionalMaterial
        Try
            sccnnDPTienda.Open()

            oResultMaterial = New DataSet

            scdaAlmacenesAdapter.Fill(oResultMaterial, "OperacionalMaterial")

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

        cmdOperacionalMaterial.Dispose()
        cmdOperacionalMaterial = Nothing

        sccnnDPTienda.Dispose()
        sccnnDPTienda = Nothing

        Return oResultMaterial
    End Function
    Friend Function Articulos_globales(ByVal Mes As Integer, ByVal TipoReporte As Integer) As Double
        Dim oResultGlobal As Double
        Dim oSumResult As Double
        Dim CnnString As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString)
        Dim cmdArtGlobales As SqlCommand
        cmdArtGlobales = New SqlCommand
        Dim daArtGlobales As SqlDataAdapter
        daArtGlobales = New SqlDataAdapter
        Dim drArtGlobales As SqlDataReader

        With cmdArtGlobales
            .CommandText = "ReportesGlobalesInventarioSel"
            .Connection = CnnString
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Mes", System.Data.SqlDbType.Int, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodMarca", System.Data.SqlDbType.VarChar, 2))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodLinea", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodFamilia", System.Data.SqlDbType.VarChar, 2))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Sucursal", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TipoReporte", System.Data.SqlDbType.Int, 4))

            .Parameters("@Mes").Value = Mes
            .Parameters("@CodMarca").Value = ""
            .Parameters("@CodLinea").Value = ""
            .Parameters("@CodFamilia").Value = ""
            .Parameters("@Sucursal").Value = oParent.ApplicationContext.ApplicationConfiguration.Almacen
            .Parameters("@TipoReporte").Value = TipoReporte
        End With
        daArtGlobales.SelectCommand = cmdArtGlobales
        Try
            CnnString.Open()
            drArtGlobales = cmdArtGlobales.ExecuteReader
            drArtGlobales.Read()

            If drArtGlobales.HasRows Then
                oResultGlobal = drArtGlobales.Item("Cantidad")
            Else
                oResultGlobal = 0
            End If

        Catch ex As Exception
            Throw ex
        Finally
            If (CnnString.State <> ConnectionState.Closed) Then
                Try
                    CnnString.Close()
                Catch
                End Try
            End If
        End Try

        cmdArtGlobales.Dispose()
        cmdArtGlobales = Nothing
        CnnString.Dispose()
        CnnString = Nothing
        Return oResultGlobal
    End Function
    Friend Function OperacionalMarcas_InventarioInicial(ByVal CodAlmacen As String, ByVal CodArticulo As String, ByVal MesIni As Integer, ByVal FechaIni As Date, ByVal FechaInicio As Date, ByVal fechaFin As Date) As Double
        Dim oresult As Double
        Dim oSumResult As Double
        Dim cnnString As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString)
        Dim cmdInventarioInicialMarcas As SqlCommand
        cmdInventarioInicialMarcas = New SqlCommand
        Dim daInventarioInicialMarcas As SqlDataAdapter
        daInventarioInicialMarcas = New SqlDataAdapter
        Dim drInventarioInicialMarcas As SqlDataAdapter
        With cmdInventarioInicialMarcas
            .Connection = cnnString
            .CommandText = "InventarioInicialMesOperacional"
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodArticulo", System.Data.SqlDbType.VarChar, 20))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@MesIni", System.Data.SqlDbType.VarChar, 2))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaIni", System.Data.SqlDbType.DateTime))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaInicio", System.Data.SqlDbType.DateTime))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaFin", System.Data.SqlDbType.DateTime))
            'Asignacion de valores a los parametros
            .Parameters("@CodAlmacen").Value = oParent.ApplicationContext.ApplicationConfiguration.Almacen
            .Parameters("@CodArticulo").Value = CodArticulo
            .Parameters("@MesIni").Value = MesIni
            .Parameters("@FechaIni").Value = Format(FechaIni, "dd/MM/yyyy")
            .Parameters("@FechaInicio").Value = Format(FechaInicio, "dd/MM/yyyy")
            .Parameters("@FechaFin").Value = Format(fechaFin, "dd/MM/yyyy")
        End With
        daInventarioInicialMarcas.SelectCommand = cmdInventarioInicialMarcas
        Try
            cnnString.Open()
            Dim scsdrReader As SqlDataReader
            'scsdrReader = cmdInventario.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.SingleRow)
            scsdrReader = cmdInventarioInicialMarcas.ExecuteReader()
            scsdrReader.Read()


            If scsdrReader.HasRows Then
                'oResult = scsdrReader.GetDecimal(0)
                oresult = (scsdrReader.Item("Total") + scsdrReader.Item("Ingresos") - scsdrReader.Item("Egresos"))
            Else

                oresult = 0
            End If

        Catch ex As Exception
            Throw ex
        Finally
            If (cnnString.State <> ConnectionState.Closed) Then
                Try
                    cnnString.Close()
                Catch
                End Try
            End If
        End Try

        cmdInventarioInicialMarcas.Dispose()
        cmdInventarioInicialMarcas = Nothing

        cnnString.Dispose()
        cnnString = Nothing

        Return oresult
    End Function
    Friend Function OperacionalMarcas_InventarioFinal(ByVal CodAlmacen As String, ByVal CodArticulo As String, ByVal MesFin As Integer, ByVal FechaIni As Date, ByVal fechaFin As Date) As Double
        Dim oresult As Double
        Dim oSumResult As Double
        Dim cnnString As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString)
        Dim cmdInventarioFinalMarcas As SqlCommand
        cmdInventarioFinalMarcas = New SqlCommand
        Dim daInventarioFinalMarcas As SqlDataAdapter
        daInventarioFinalMarcas = New SqlDataAdapter
        Dim drInventariofinalMarcas As SqlDataAdapter
        With cmdInventarioFinalMarcas
            .Connection = cnnString
            .CommandText = "InventarioFinalMesOperacional"
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodArticulo", System.Data.SqlDbType.VarChar, 20))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@MesFin", System.Data.SqlDbType.VarChar, 2))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaIni", System.Data.SqlDbType.DateTime))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaFin", System.Data.SqlDbType.DateTime))
            'Asignacion de valores a los parametros
            .Parameters("@CodAlmacen").Value = oParent.ApplicationContext.ApplicationConfiguration.Almacen
            .Parameters("@CodArticulo").Value = CodArticulo
            .Parameters("@MesFin").Value = MesFin
            .Parameters("@FechaIni").Value = Format(FechaIni, "dd/MM/yyyy")
            .Parameters("@FechaFin").Value = Format(fechaFin, "dd/MM/yyyy")
        End With
        daInventarioFinalMarcas.SelectCommand = cmdInventarioFinalMarcas
        Try
            cnnString.Open()
            Dim scsdrReader As SqlDataReader
            'scsdrReader = cmdInventario.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.SingleRow)
            scsdrReader = cmdInventarioFinalMarcas.ExecuteReader()
            scsdrReader.Read()


            If scsdrReader.HasRows Then
                'oResult = scsdrReader.GetDecimal(0)
                oresult = (scsdrReader.Item("Total") + scsdrReader.Item("Ingresos") - scsdrReader.Item("Egresos"))
            Else

                oresult = 0
            End If

        Catch ex As Exception
            Throw ex
        Finally
            If (cnnString.State <> ConnectionState.Closed) Then
                Try
                    cnnString.Close()
                Catch
                End Try
            End If
        End Try

        cmdInventarioFinalMarcas.Dispose()
        cmdInventarioFinalMarcas = Nothing

        cnnString.Dispose()
        cnnString = Nothing

        Return oresult
    End Function
    Friend Function Inventario_Final(ByVal CodAlmacen As String, ByVal CodArticulo As String, ByVal MesFin As Integer, ByVal FechaIni As Date, ByVal FechaFin As Date) As Double
        Dim oresult As Double
        Dim oSumResult As Double
        Dim cnnString As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString)
        Dim cmdInventarioFinal As SqlCommand
        cmdInventarioFinal = New SqlCommand
        Dim daInventario As SqlDataAdapter
        daInventario = New SqlDataAdapter
        Dim drInventario As SqlDataReader

        With cmdInventarioFinal
            .CommandText = "InventarioFinalMesOperacional"
            .CommandType = CommandType.StoredProcedure
            .Connection = cnnString
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodArticulo", System.Data.SqlDbType.VarChar, 20))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@MesFin", System.Data.SqlDbType.VarChar, 2))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaIni", System.Data.SqlDbType.DateTime))

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaFin", System.Data.SqlDbType.DateTime))
            'Asignacion de valores a los parametros
            .Parameters("@CodAlmacen").Value = oParent.ApplicationContext.ApplicationConfiguration.Almacen
            .Parameters("@CodArticulo").Value = CodArticulo
            .Parameters("@MesFin").Value = MesFin
            .Parameters("@FechaIni").Value = Format(FechaIni, "dd/MM/yyyy")

            .Parameters("@FechaFin").Value = Format(FechaFin, "dd/MM/yyyy")
        End With
        daInventario.SelectCommand = cmdInventarioFinal
        Try
            cnnString.Open()
            drInventario = cmdInventarioFinal.ExecuteReader
            drInventario.Read()
            If drInventario.HasRows Then
                'Inventario inicial + Ingresos - egresos
                oresult = (drInventario.Item(1) + drInventario.Item(2) - drInventario.Item(3))
            Else
                'Si no regresa datos el SP e ntonces se asigna un Cero a oResult
                oresult = 0
            End If
        Catch ex As Exception
            Throw ex
        Finally
            If (cnnString.State <> ConnectionState.Closed) Then
                Try
                    cnnString.Close()
                Catch
                End Try
            End If
        End Try

        cnnString.Dispose()
        cnnString = Nothing

        cmdInventarioFinal.Dispose()
        cmdInventarioFinal = Nothing
        Return oresult
    End Function
    Friend Function Inventario_Inicial(ByVal CodAlmacen As String, ByVal CodArticulo As String, ByVal MesIni As Integer, ByVal FechaIni As Date, ByVal FechaInicio As Date, ByVal FechaFin As Date) As Double

        Dim oResult As Double
        Dim oSumResult As Double
        Dim CnnString As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString)
        Dim cmdInventario As SqlCommand
        cmdInventario = New SqlCommand


        Dim daInventarioIni As SqlDataAdapter
        daInventarioIni = New SqlDataAdapter

        With cmdInventario
            .CommandText = "InventarioInicialMesOperacional"
            .CommandType = CommandType.StoredProcedure
            .Connection = CnnString
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodArticulo", System.Data.SqlDbType.VarChar, 20))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@MesIni", System.Data.SqlDbType.VarChar, 2))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaIni", System.Data.SqlDbType.DateTime))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaInicio", System.Data.SqlDbType.DateTime))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaFin", System.Data.SqlDbType.DateTime))


            .Parameters("@CodAlmacen").Value = oParent.ApplicationContext.ApplicationConfiguration.Almacen
            .Parameters("@CodArticulo").Value = CodArticulo
            .Parameters("@MesIni").Value = MesIni
            .Parameters("@FechaIni").Value = Format(FechaIni, "dd/MM/yyyy")
            .Parameters("@FechaInicio").Value = Format(FechaInicio, "dd/MM/yyyy")
            .Parameters("@FechaFin").Value = Format(FechaFin, "dd/MM/yyyy")


        End With
        daInventarioIni.SelectCommand = cmdInventario
        Try
            CnnString.Open()
            Dim scsdrReader As SqlDataReader
            'scsdrReader = cmdInventario.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.SingleRow)
            scsdrReader = cmdInventario.ExecuteReader()
            scsdrReader.Read()


            If scsdrReader.HasRows Then
                'oResult = scsdrReader.GetDecimal(0)
                oResult = (scsdrReader.Item(1) + scsdrReader.Item(2) - scsdrReader.Item(3))
            Else
                oResult = 0
            End If

        Catch ex As Exception
            Throw ex
        Finally
            If (CnnString.State <> ConnectionState.Closed) Then
                Try
                    CnnString.Close()
                Catch
                End Try
            End If
        End Try

        cmdInventario.Dispose()
        cmdInventario = Nothing

        CnnString.Dispose()
        CnnString = Nothing

        Return oResult
    End Function
    Friend Function Inventario_InicialCruzado(ByVal CodAlmacen As String, ByVal CodArticulo As String, ByVal MesIni As Integer, ByVal FechaIni As Date, ByVal FechaInicio As Date, ByVal FechaFin As Date, ByVal FechaFinal As Date) As Double

        Dim oResult As Double
        Dim oSumResult As Double
        Dim CnnString As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString)
        Dim cmdInventarioCruzado As SqlCommand
        cmdInventarioCruzado = New SqlCommand


        Dim daInventarioIni As SqlDataAdapter
        daInventarioIni = New SqlDataAdapter

        With cmdInventarioCruzado
            .CommandText = "InventarioInicialMesOperacionalCruzado"
            .CommandType = CommandType.StoredProcedure
            .Connection = CnnString
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodArticulo", System.Data.SqlDbType.VarChar, 20))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@MesIni", System.Data.SqlDbType.VarChar, 2))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaIni", System.Data.SqlDbType.DateTime))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaInicio", System.Data.SqlDbType.DateTime))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaFin", System.Data.SqlDbType.DateTime))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaFinal", System.Data.SqlDbType.DateTime))


            .Parameters("@CodAlmacen").Value = oParent.ApplicationContext.ApplicationConfiguration.Almacen
            .Parameters("@CodArticulo").Value = CodArticulo
            .Parameters("@MesIni").Value = MesIni
            .Parameters("@FechaIni").Value = Format(FechaIni, "dd/MM/yyyy")
            .Parameters("@FechaInicio").Value = Format(FechaInicio, "dd/MM/yyyy")
            .Parameters("@FechaFin").Value = Format(FechaFin, "dd/MM/yyyy")
            .Parameters("@FechaFinal").Value = Format(FechaFinal, "dd/MM/yyyy")

        End With
        daInventarioIni.SelectCommand = cmdInventarioCruzado
        Try
            CnnString.Open()
            Dim scsdrReader As SqlDataReader
            'scsdrReader = cmdInventario.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.SingleRow)
            scsdrReader = cmdInventarioCruzado.ExecuteReader()
            scsdrReader.Read()


            If scsdrReader.HasRows Then
                'oResult = scsdrReader.GetDecimal(0)
                oResult = (scsdrReader.Item(1) + scsdrReader.Item(2) - scsdrReader.Item(3))
            Else
                oResult = 0
            End If

        Catch ex As Exception
            Throw ex
        Finally
            If (CnnString.State <> ConnectionState.Closed) Then
                Try
                    CnnString.Close()
                Catch
                End Try
            End If
        End Try

        cmdInventarioCruzado.Dispose()
        cmdInventarioCruzado = Nothing

        CnnString.Dispose()
        CnnString = Nothing

        Return oResult
    End Function
#End Region

#Region "Validar Tallas que existan y Facturas ya Canceladas"

    Public Function ValidarTallaArticulo(ByVal strCodarticulo As String, ByVal strTalla As String) As Integer

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                              GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader
        Dim intNumart As Integer = 0

        Dim dsDataSet As DataSet
        dsDataSet = New DataSet




        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[ArticulosvalidarTalla]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodArticulo", System.Data.SqlDbType.VarChar, 20))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Talla", System.Data.SqlDbType.VarChar, 20))

        End With


        Try

            sccnnConnection.Open()

            With sccmdSelect
                'Assign Parameters Values
                .Parameters("@CodArticulo").Value = strCodarticulo
                .Parameters("@Talla").Value = strTalla

                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) And (IsDBNull(scdrReader.Item(0)) <> True) Then

                    With scdrReader

                        intNumart = .GetInt32(0)

                    End With

                Else

                    scdrReader.Close()
                    sccnnConnection.Close()

                    intNumart = 0

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

        Return intNumart

    End Function

    Public Function FacturaValidarNotaCreditoPasadasCanceladas(ByVal intfolioFact As Integer) As Integer

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                            GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader
        Dim intNumres As Integer = 0

        Dim dsDataSet As DataSet
        dsDataSet = New DataSet

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[FacturaValidarNotaCreditoPasadasCanceladas]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioFactura", System.Data.SqlDbType.Int, 4))

        End With


        Try

            sccnnConnection.Open()

            With sccmdSelect
                'Assign Parameters Values
                .Parameters("@FolioFactura").Value = intfolioFact


                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) And (IsDBNull(scdrReader.Item(0)) <> True) Then

                    With scdrReader

                        intNumres = .GetInt32(0)

                    End With

                Else

                    scdrReader.Close()
                    sccnnConnection.Close()

                    intNumres = 0

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

        Return intNumres

    End Function

#End Region

#Region "DPVale AFS"

    Public Sub DevolucionDPValeAFS(ByVal pNotaCredito As NotaCredito, Optional ByVal EsSiHay As Boolean = False, Optional ByVal FolioPedido As String = "")
        Dim intFacturaID As Integer ' Factura DPPRO.
        Dim decDevDPVL As Decimal 'Aqui tendremos cuanto hay que descontar del credito en SAP.
        Dim decMontoNoCancelado As Decimal 'Contiene el monto disponible para la cancelacion.
        ''Primer Paso.- Validar que la forma de pago Exisa.
        'FolioReferencia<- En este campo se tiene el folio de factura DPPRO
        intFacturaID = pNotaCredito.Detalle.Tables(0).Rows(0)("FacturaID")
        If (ValidarExistenciaFormaPago(intFacturaID, "DPVL") = True) Then
            decMontoNoCancelado = ExtraerMontoNoCancelado(intFacturaID, "DPVL")
            If decMontoNoCancelado = 0 Then
                decDevDPVL = 0 'Si la forma de pago ya fue consumida por otras devoluciones entonces no descontamos saldo del credito.
            Else
                If pNotaCredito.Importe > decMontoNoCancelado Then
                    decDevDPVL = decMontoNoCancelado
                Else
                    decDevDPVL = pNotaCredito.Importe
                End If
            End If
        Else
            decDevDPVL = 0 'Si no existe la forma de pago entonces no descontamos saldo del credito.
        End If
        'TODO: Erick.-Fin Validamos Monto Devolucion Forma Pago DPortenis Vale'

        '-------------------------------------------------------------------------------------------------------------
        'JNAVA (19.02.2015): Si es Devolucion con DPVale del SI HAY, determinamos en base al pedido el MontoDPVL
        '-------------------------------------------------------------------------------------------------------------
        If EsSiHay Then
            If FolioPedido.Trim = "" Then
                decDevDPVL = 0
            End If
        End If
        Try

            Dim strCodCaja As String

            'Fin Tablas
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServerDPVale, _
                     oParent.SAPApplicationConfig.SystemDPVale, _
                     oParent.SAPApplicationConfig.UserDPVale, _
                     oParent.SAPApplicationConfig.PasswordDPVale, _
                     oParent.SAPApplicationConfig.LanguageDPVale, _
                     oParent.SAPApplicationConfig.ClientDPVale)

            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Sub
            Else
                '*****************************************************
                'Call RFC function ZBAPI_VALIDA_DPVALE
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZBAPISD17_DEV_VENTAS_DPVL")
                'If FolioPedido.Trim <> "" Then
                '    func.Exports("I_FOLIOPEDIDO").ParamValue = FolioPedido.Trim
                'End If
                func.Exports("I_MONDPVL").ParamValue = decDevDPVL
                func.Exports("CLASEPEDIDO").ParamValue = "Z" & Mid(pNotaCredito.AlmacenID, 2, 2) & "3"
                func.Exports("OFICINAVTA").ParamValue = "T" & pNotaCredito.AlmacenID
                func.Exports("I_Fecha").ParamValue = Format(pNotaCredito.Fecha, "dd/MM/yyyy")
                func.Exports("I_AGENTE").ParamValue = pNotaCredito.PlayerID
                If oParent.ApplicationContext.ApplicationConfiguration.Almacen = "053" Then
                    func.Exports("I_WERKS").ParamValue = "T053"
                Else
                    func.Exports("I_WERKS").ParamValue = "T" & pNotaCredito.AlmacenID
                End If
                func.Exports("I_CREDITO").ParamValue = "N"
                If pNotaCredito.ClienteID.PadLeft(10, "0") = "1".PadLeft(10, "0") Then
                    'se manda vacio por que el erick ya lo agarra desde sap
                    func.Exports("I_KUNNR").ParamValue = String.Empty
                    'GetFolioSAPByDPVale(ExtraerDPValeIDByFolioSAP(pNotaCredito.Detalle.Tables(0).Rows(0)("FolioReferencia"))).PadLeft(10, "0")
                End If
                func.Exports("I_ZONAVTA").ParamValue = "EFEC"
                Dim i As Integer = 0
                Dim T_DATOSDET As ERPConnect.RFCTable = func.Tables("DATOSDET")
                Dim R_Lines As ERPConnect.RFCStructure
                For Each row As DataRow In pNotaCredito.Detalle.Tables(0).Rows
                    i += i
                    R_Lines = T_DATOSDET.AddRow()
                    R_Lines("Folio") = i
                    R_Lines("MATNR") = row("CodArticulo")
                    R_Lines("Cantidad") = row("Cantidad")
                    If IsNumeric(row("Numero")) Then
                        R_Lines("TALLA") = Format(CDec(row("Numero")), "##.0")
                    Else
                        R_Lines("TALLA") = row("Numero")
                    End If

                    strCodCaja = row!CodCaja
                    func.Exports("I_FACTURA").ParamValue = CStr(row("FolioReferencia")).PadLeft(10, "0")
                Next
                func.Exports("I_FACTURA").ParamValue = Me.oAbonoCreditoDirecto.GetSelectFolioFacturaSDSAP(func.Exports("I_FACTURA").ParamValue, strCodCaja)
                'If FolioPedido.Trim <> "" Then
                '    func.Exports("I_FACTURA").ParamValue = pNotaCredito.FIDOCUMENT.Trim
                'Else
                '    func.Exports("I_FACTURA").ParamValue = Me.oAbonoCreditoDirecto.GetSelectFolioFacturaSDSAP(func.Exports("I_FACTURA").ParamValue, strCodCaja)
                'End If
                func.Exports("I_KEYPRO").ParamValue = "T" & oParent.ApplicationContext.ApplicationConfiguration.Almacen & _
                oParent.ApplicationContext.ApplicationConfiguration.NoCaja & CStr(oAbonoCreditoDirecto.GetSelectNCByCaja(strCodCaja))
                func.Execute()
                'pNotaCredito.DEVANTERIOR = CStr(func.Imports("E_DEV_ANT").ParamValue)
                'pNotaCredito.SALESDOCUMENT = CStr(func.Imports("SALESDOCUMENT").ParamValue)
                'pNotaCredito.FIDOCUMENT = CStr(func.Imports("FIDOCUMENT").ParamValue)
                R3.Close()
            End If
        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try
    End Sub

    Public Overridable Sub DevolucionDPVale(ByVal pNotaCredito As NotaCredito, Optional ByVal EsSiHay As Boolean = False, Optional ByVal FolioPedido As String = "", Optional ByRef strError As String = "")
        Dim intFacturaID As Integer ' Factura DPPRO.
        Dim decDevDPVL As Decimal 'Aqui tendremos cuanto hay que descontar del credito en SAP.
        Dim decMontoNoCancelado As Decimal 'Contiene el monto disponible para la cancelacion.
        ''Primer Paso.- Validar que la forma de pago Exisa.
        'FolioReferencia<- En este campo se tiene el folio de factura DPPRO
        intFacturaID = pNotaCredito.Detalle.Tables(0).Rows(0)("FacturaID")
        If (ValidarExistenciaFormaPago(intFacturaID, "DPVL") = True) Then
            decMontoNoCancelado = ExtraerMontoNoCancelado(intFacturaID, "DPVL")
            If decMontoNoCancelado = 0 Then
                decDevDPVL = 0 'Si la forma de pago ya fue consumida por otras devoluciones entonces no descontamos saldo del credito.
            Else
                If pNotaCredito.Importe > decMontoNoCancelado Then
                    decDevDPVL = decMontoNoCancelado
                Else
                    decDevDPVL = pNotaCredito.Importe
                End If
            End If
        Else
            decDevDPVL = 0 'Si no existe la forma de pago entonces no descontamos saldo del credito.
        End If
        'TODO: Erick.-Fin Validamos Monto Devolucion Forma Pago DPortenis Vale'

        '-------------------------------------------------------------------------------------------------------------
        'JNAVA (19.02.2015): Si es Devolucion con DPVale del SI HAY, determinamos en base al pedido el MontoDPVL
        '-------------------------------------------------------------------------------------------------------------
        If EsSiHay Then
            If FolioPedido.Trim = "" Then
                decDevDPVL = 0
            End If
        End If
        Try

            Dim strCodCaja As String

            'Fin Tablas
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)

            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Sub
            Else
                '*****************************************************
                'Call RFC function ZBAPI_VALIDA_DPVALE
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZBAPISD17_DEV_VENTAS_DPVL")
                'If FolioPedido.Trim <> "" Then
                '    func.Exports("I_FOLIOPEDIDO").ParamValue = FolioPedido.Trim
                'End If
                func.Exports("I_MONDPVL").ParamValue = decDevDPVL
                func.Exports("CLASEPEDIDO").ParamValue = "ZDEV"
                func.Exports("OFICINAVTA").ParamValue = "T" & pNotaCredito.AlmacenID
                func.Exports("I_Fecha").ParamValue = Format(pNotaCredito.Fecha, "dd/MM/yyyy")
                func.Exports("I_AGENTE").ParamValue = pNotaCredito.PlayerID
                If oParent.ApplicationContext.ApplicationConfiguration.Almacen = "053" Then
                    func.Exports("I_WERKS").ParamValue = "T053"
                Else
                    func.Exports("I_WERKS").ParamValue = "T" & pNotaCredito.AlmacenID
                End If
                func.Exports("I_CREDITO").ParamValue = "N"
                If pNotaCredito.ClienteID.PadLeft(10, "0") = "1".PadLeft(10, "0") Then
                    'se manda vacio por que el erick ya lo agarra desde sap
                    func.Exports("I_KUNNR").ParamValue = String.Empty
                    'GetFolioSAPByDPVale(ExtraerDPValeIDByFolioSAP(pNotaCredito.Detalle.Tables(0).Rows(0)("FolioReferencia"))).PadLeft(10, "0")
                End If
                func.Exports("I_ZONAVTA").ParamValue = "EFEC"
                Dim i As Integer = 0
                Dim T_DATOSDET As ERPConnect.RFCTable = func.Tables("DATOSDET")
                Dim R_Lines As ERPConnect.RFCStructure
                For Each row As DataRow In pNotaCredito.Detalle.Tables(0).Rows
                    i += i
                    R_Lines = T_DATOSDET.AddRow()
                    R_Lines("Folio") = i
                    R_Lines("MATNR") = row("CodArticulo")
                    R_Lines("Cantidad") = row("Cantidad")
                    If IsNumeric(row("Numero")) Then
                        R_Lines("TALLA") = Format(CDec(row("Numero")), "##.0")
                    Else
                        R_Lines("TALLA") = row("Numero")
                    End If

                    strCodCaja = row!CodCaja
                    func.Exports("I_FACTURA").ParamValue = CStr(row("FolioReferencia")).PadLeft(10, "0")
                Next
                'If FolioPedido.Trim <> "" Then
                '    func.Exports("I_FACTURA").ParamValue = pNotaCredito.FIDOCUMENT.Trim
                'Else
                '    func.Exports("I_FACTURA").ParamValue = Me.oAbonoCreditoDirecto.GetSelectFolioFacturaSDSAP(func.Exports("I_FACTURA").ParamValue, strCodCaja)
                'End If
                func.Exports("I_FACTURA").ParamValue = Me.oAbonoCreditoDirecto.GetSelectFolioFacturaSDSAP(func.Exports("I_FACTURA").ParamValue, strCodCaja)
                func.Exports("I_KEYPRO").ParamValue = "T" & oParent.ApplicationContext.ApplicationConfiguration.Almacen & _
                oParent.ApplicationContext.ApplicationConfiguration.NoCaja & CStr(oAbonoCreditoDirecto.GetSelectNCByCaja(strCodCaja))
                func.Execute()
                R3.Close()

                '------------------------------------------------------------------------------
                ' MLVARGAS (11.03.2022): Validar que existe el parámetro de Devolución Anterior
                '------------------------------------------------------------------------------
                pNotaCredito.DEVANTERIOR = ""

                For Each sapItem As ERPConnect.RFCParameter In func.Imports()
                    If sapItem.Name = "E_DEV_ANTERIOR" Then
                        pNotaCredito.DEVANTERIOR = sapItem.ParamValue
                        Exit For
                    End If
                Next

                pNotaCredito.SALESDOCUMENT = CStr(func.Imports("SALESDOCUMENT").ParamValue)
                pNotaCredito.FIDOCUMENT = CStr(func.Imports("FIDOCUMENT").ParamValue)

                Dim dtReturn As DataTable = func.Tables("RETURN").ToADOTable()
                For Each row As DataRow In dtReturn.Rows
                    If row.IsNull("MESSAGE") = False Then
                        strError &= CStr(row("MESSAGE"))
                    End If
                Next
            End If
        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try
    End Sub

#End Region

#Region "Timeouts"

    '-------------------------------------------------------------------------------------------------
    ' JNAVA (09.06.2016): Escribe log con tiempos por de transacciones de DPPRO a BUS/SAP y Viceversa
    '-------------------------------------------------------------------------------------------------
    Public Sub EscribeLogTransaccionesSAP(ByVal EsInicio As Boolean, _
                                          ByVal Fecha As DateTime, _
                                          ByVal NombreBAPI As String, _
                                          Optional ByVal Mensaje As String = "", _
                                          Optional ByVal TotalTiempo As Long = 0)


        Dim NombreArchivo As String = "\TransaccionesSAPLogFile.txt"
        Dim StreamW As New StreamWriter(My.Application.Info.DirectoryPath & NombreArchivo, True)
        If EsInicio Then
            StreamW.WriteLine("".PadLeft(150, "*"))
            StreamW.WriteLine()
            StreamW.WriteLine("--------> " & NombreBAPI)
            StreamW.WriteLine("INICIO -> " & Fecha)
        Else
            StreamW.WriteLine("FIN ----> " & Fecha)
            StreamW.WriteLine("INFO ---> " & Mensaje)
            StreamW.WriteLine("--------> Tiempo Total de Espera: " & TotalTiempo & " Seg.")
            StreamW.WriteLine()
        End If

        StreamW.Close()

    End Sub

    Public Sub EscribeLog(ByVal strError As String, ByVal Titulo As String)

        Dim StreamW As New StreamWriter(My.Application.Info.DirectoryPath & "\ErrorLogFile.txt", True)

        StreamW.WriteLine(Now.ToString & " --> " & Titulo.ToUpper & vbCrLf)
        StreamW.WriteLine("Detalle --> " & strError)
        StreamW.WriteLine("".PadLeft(250, "-"))

        StreamW.Close()

    End Sub


#End Region

End Class
