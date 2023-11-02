Imports System.Data.SqlClient
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos

Public Class AjusteGeneralDataGateway

    Private oParent As AjusteGeneralManager
    Dim strConnectionStringServer As String = ""

#Region "Constructors / Destructors"

    Public Sub New(ByVal Parent As AjusteGeneralManager)

        oParent = Parent

        If Not oParent.ConfigCierreFI Is Nothing Then
            strConnectionStringServer = "data source = " & oParent.ConfigCierreFI.ServerTraspasos & "; initial catalog = " & oParent.ConfigCierreFI.BaseDatosTraspasos & _
                                        "; user id = " & oParent.ConfigCierreFI.UserTraspasos & "; password = " & _
                                        oParent.ConfigCierreFI.PasswordTraspasos
        End If

    End Sub

#End Region

#Region "Methods"

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
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TEOrigen", System.Data.SqlDbType.VarChar, 10))
            End If

            .CommandType = System.Data.CommandType.StoredProcedure
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioSAP", System.Data.SqlDbType.VarChar, 10))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Almacen", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TotalCodigos", System.Data.SqlDbType.Int))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Usuario", System.Data.SqlDbType.VarChar, 20))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Observaciones", System.Data.SqlDbType.Text))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CostoTotal", System.Data.SqlDbType.Money))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodMov", System.Data.SqlDbType.NChar, 10))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodMot", System.Data.SqlDbType.NChar, 10))

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
            '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Talla", System.Data.SqlDbType.VarChar, 4))
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
                .Parameters("@CodMov").Value = pAjusteGeneral.ClaseMov
                .Parameters("@CodMot").Value = pAjusteGeneral.Motivo

                If pAjusteGeneral.TipoAjuste <> "E" Then
                    .Parameters("@TEOrigen").Value = pAjusteGeneral.TEOrigen.Trim.PadLeft(10, "0")
                End If
                'Execute Command
                .ExecuteNonQuery()
                pAjusteGeneral.FolioAjuste = .Parameters("@Folio").Value
            End With

            'Insertamos Detalle
            With sccmdInsertDetail

                Dim dRow As DataRow

                For Each dRow In pAjusteGeneral.Detalle.Rows
                    'If Trim(dRow!FolioSAp) <> String.Empty Then
                    .Parameters("@FolioAjuste").Value = pAjusteGeneral.FolioAjuste
                    .Parameters("@Codigo").Value = dRow!Codigo
                    .Parameters("@Descripcion").Value = dRow!Descripcion
                    '.Parameters("@Talla").Value = dRow!Talla
                    .Parameters("@Cantidad").Value = dRow!Cantidad
                    .Parameters("@Importe").Value = dRow!Importe
                    .Parameters("@FolioSAP").Value = dRow!FolioSAP
                    .ExecuteNonQuery()
                    dRow!Folio = .Parameters("@Folio").Value
                    'End If

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

    Public Sub InsertInServer(ByVal pAjusteGeneral As AjusteGeneralInfo)

        Dim sccnnConnection As New SqlConnection(strConnectionStringServer)

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
            '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Talla", System.Data.SqlDbType.VarChar, 4))
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
                    'If Trim(dRow!FolioSAp) <> String.Empty Then
                    .Parameters("@FolioAjuste").Value = pAjusteGeneral.FolioAjuste
                    .Parameters("@Codigo").Value = dRow!Codigo
                    .Parameters("@Descripcion").Value = dRow!Descripcion
                    '.Parameters("@Talla").Value = dRow!Talla
                    .Parameters("@Cantidad").Value = dRow!Cantidad
                    .Parameters("@Importe").Value = dRow!Importe
                    .Parameters("@FolioSAP").Value = dRow!FolioSAP
                    .ExecuteNonQuery()
                    dRow!Folio = .Parameters("@Folio").Value
                    'End If

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

    Public Function InsertESNuevo(ByVal intFolioAJS As Integer, ByVal intFolioAJE As Integer, ByVal strEstado As String, ByVal strObservaciones As String, ByVal datFecha As DateTime, ByVal strUsuario As String) As Integer


        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                                 DataStorageConfiguration.GetConnectionString)

        'Insertamos General
        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand

        Dim sccmdInsertDetail As SqlCommand
        sccmdInsertDetail = New SqlCommand

        With sccmdInsert
            .Connection = sccnnConnection
            .CommandText = "[AjustesESNuevoIns]"

            .CommandType = System.Data.CommandType.StoredProcedure
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioAJS", System.Data.SqlDbType.Int))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioAJE", System.Data.SqlDbType.Int))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Estado", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Observaciones", System.Data.SqlDbType.VarChar, 255))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Usuario", System.Data.SqlDbType.VarChar, 20))
            'OutPut :
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioAjuste", System.Data.SqlDbType.Int))
            .Parameters("@FolioAjuste").Direction = ParameterDirection.Output

        End With
        Try
            sccnnConnection.Open()
            'Insertamos Datos Generales
            With sccmdInsert
                'Assign Parameters Values
                .Parameters("@FolioAJS").Value = intFolioAJS
                .Parameters("@FolioAJE").Value = intFolioAJE
                .Parameters("@Estado").Value = strEstado
                .Parameters("@Observaciones").Value = strObservaciones
                .Parameters("@Fecha").Value = datFecha
                .Parameters("@Usuario").Value = strUsuario
                'Execute Command
                .ExecuteNonQuery()
                Return .Parameters("@FolioAjuste").Value
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

    End Function

    Public Sub UpdateESNuevoEstado(ByVal intFolio As Integer, ByVal strEstado As String)


        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                                 DataStorageConfiguration.GetConnectionString)

        'Insertamos General
        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand

        Dim sccmdInsertDetail As SqlCommand
        sccmdInsertDetail = New SqlCommand

        With sccmdInsert
            .Connection = sccnnConnection
            .CommandText = "[AjustesESNuevoUpdEstado]"

            .CommandType = System.Data.CommandType.StoredProcedure
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioAjuste", System.Data.SqlDbType.Int))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Estado", System.Data.SqlDbType.VarChar, 3))

        End With
        Try
            sccnnConnection.Open()
            'Insertamos Datos Generales
            With sccmdInsert
                'Assign Parameters Values
                .Parameters("@FolioAjuste").Value = intFolio
                .Parameters("@Estado").Value = strEstado
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

    Public Sub UpdateESNuevoDettalleFolioSAP(ByVal intFolio As Integer, ByVal strFolioSAP As String, ByVal strTipoAjuste As String)


        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                                 DataStorageConfiguration.GetConnectionString)

        'Insertamos General
        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand

        Dim sccmdInsertDetail As SqlCommand
        sccmdInsertDetail = New SqlCommand

        With sccmdInsert
            .Connection = sccnnConnection
            .CommandText = "[AjustesESNuevoUpdDetalleFOLIOSAP]"

            .CommandType = System.Data.CommandType.StoredProcedure
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Folio", System.Data.SqlDbType.Int))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioSAP", System.Data.SqlDbType.VarChar, 16))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@EoS", System.Data.SqlDbType.VarChar, 1))

        End With
        Try
            sccnnConnection.Open()
            'Insertamos Datos Generales
            With sccmdInsert
                'Assign Parameters Values
                .Parameters("@Folio").Value = intFolio
                .Parameters("@FolioSAP").Value = strFolioSAP
                .Parameters("@EoS").Value = strTipoAjuste
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
                    .ClaseMov = dtAjuste.Rows(0).Item("CodMov")
                    .Motivo = dtAjuste.Rows(0).Item("CodMot")

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

    Public Function AjusteESNuevoSel(ByVal intFolioAjuste As Integer, ByVal strEstado As String) As DataTable


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
            .CommandText = "[AjustesESNuevoSel]"

            .CommandType = System.Data.CommandType.StoredProcedure
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioAjuste", System.Data.SqlDbType.Int))
            .Parameters("@FolioAjuste").Value = intFolioAjuste

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Estado", System.Data.SqlDbType.VarChar))
            .Parameters("@Estado").Value = strEstado
        End With

        Try
            daAjuste = New SqlDataAdapter(sccmdSelect)

            daAjuste.Fill(dtAjuste)

            Return dtAjuste

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

    End Function

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

    Public Function GetFolioAjusteESNuevo() As Integer

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        Dim intFolio As Integer


        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[AjustesESNuevoFolio]"
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
                        .Parameters("@Numero").Value = "" 'dRow!Talla
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

    Public Function GetAllESNuevo(ByVal strTipoConsulta As String) As DataSet
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

            If strTipoConsulta = "GRA" Then
                .CommandText = "[AjustesESNuevoSellAllGRA]"
            Else
                .CommandText = "[AjustesESNuevoSellAllAUT]"
            End If

            .CommandType = System.Data.CommandType.StoredProcedure

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

    '-----------------------------------------------------------------------------
    ' JNAVA (18.02.2016): Conetado por adecuaciones de Retail
    '-----------------------------------------------------------------------------
    Public Function GetExistencias(ByVal strCodArticulo As String) As Decimal
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
            '-----------------------------------------------------------------------------
            ' JNAVA (18.02.2016): Conetado por adecuaciones de Retail
            '-----------------------------------------------------------------------------
            '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@talla", System.Data.SqlDbType.VarChar, 4))
        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect
                .Parameters("@CodArticulo").Value = strCodArticulo
                '-----------------------------------------------------------------------------
                ' JNAVA (18.02.2016): Conetado por adecuaciones de Retail
                '-----------------------------------------------------------------------------
                '.Parameters("@Talla").Value = strTalla
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



    Public Sub UpdateCantAJS(ByVal intFolioAjuste As Integer, ByVal strCodigo As String, ByVal intCantidad As Integer)
        '-----------------------------------------------------------------------------
        ' JNAVA (18.02.2016): modificado por adecuaciones de Retail
        '-----------------------------------------------------------------------------

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                                 DataStorageConfiguration.GetConnectionString)

        'Insertamos General
        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand

        Dim sccmdInsertDetail As SqlCommand
        sccmdInsertDetail = New SqlCommand

        With sccmdInsert
            .Connection = sccnnConnection
            .CommandText = "[AjustesESNuevoUpdCantidadAJS]"

            .CommandType = System.Data.CommandType.StoredProcedure
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioAjuste", System.Data.SqlDbType.Int))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Codigo", System.Data.SqlDbType.VarChar, 20))
            '-----------------------------------------------------------------------------
            ' JNAVA (18.02.2016): Comentado por adecuaciones de Retail
            '-----------------------------------------------------------------------------
            '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Talla", System.Data.SqlDbType.VarChar, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Cantidad", System.Data.SqlDbType.Int))
        End With
        Try
            sccnnConnection.Open()
            'Insertamos Datos Generales
            With sccmdInsert
                'Assign Parameters Values
                .Parameters("@FolioAjuste").Value = intFolioAjuste
                .Parameters("@Codigo").Value = strCodigo
                '-----------------------------------------------------------------------------
                ' JNAVA (18.02.2016): Comentado por adecuaciones de Retail
                '-----------------------------------------------------------------------------
                '.Parameters("@Talla").Value = strTalla
                .Parameters("@Cantidad").Value = intCantidad
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

    Public Sub DeleteCodigoAJS(ByVal intFolioAjuste As Integer, ByVal strCodigo As String) ', ByVal strTalla As String)

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                                 DataStorageConfiguration.GetConnectionString)

        'Insertamos General
        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand

        Dim sccmdInsertDetail As SqlCommand
        sccmdInsertDetail = New SqlCommand

        With sccmdInsert
            .Connection = sccnnConnection
            .CommandText = "[AjustesESNuevoDelCodigoAJS]"

            .CommandType = System.Data.CommandType.StoredProcedure
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioAjuste", System.Data.SqlDbType.Int))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Codigo", System.Data.SqlDbType.VarChar, 20))
            '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Talla", System.Data.SqlDbType.VarChar, 4))
        End With
        Try
            sccnnConnection.Open()
            'Insertamos Datos Generales
            With sccmdInsert
                'Assign Parameters Values
                .Parameters("@FolioAjuste").Value = intFolioAjuste
                .Parameters("@Codigo").Value = strCodigo
                '.Parameters("@Talla").Value = strTalla
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
