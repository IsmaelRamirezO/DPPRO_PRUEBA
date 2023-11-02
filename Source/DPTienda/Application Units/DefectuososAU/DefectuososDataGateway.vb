
Option Explicit On 

Imports System.Data.SqlClient
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos
Imports System.Windows.Forms
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU


Public Class DefectuososDataGateway

    Private oParent As DefectuososManager

    Private m_strConnectionString As String

    Private oDefectuoso As Defectuoso

    Private oArticulosMgr As CatalogoArticuloManager
    Private oArticulo As Articulo
    Private oSapCentro As ProcesoSAPManager


#Region "Constructors / Destructors"

    Public Sub New(ByVal Parent As DefectuososManager)

        oParent = Parent

        m_strConnectionString = oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString

        oDefectuoso = oParent.Create

        oSapCentro = New ProcesoSAPManager(oParent.ApplicationContext, oParent.SAPApplicationConfig)

    End Sub

#End Region


#Region "Methods"



    Public Function Insert(ByVal pDefectuoso As Defectuoso) As Integer

        'TODO EARAGON Descomentar inserccion SAP
        SaveSAP(pDefectuoso)


        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdInsert As SqlCommand
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

            With sccmdInsert
                'Assign Parameters Values
                .Parameters("@CodAlmacen").Value = pDefectuoso.CodAlmacen.ToUpper
                .Parameters("@CodCaja").Value = pDefectuoso.CodCaja.ToUpper
                .Parameters("@FacturaID").Value = pDefectuoso.FacturaID
                .Parameters("@CodArticulo").Value = pDefectuoso.CodArticulo.ToUpper
                .Parameters("@Numero").Value = pDefectuoso.Numero
                .Parameters("@Cantidad").Value = pDefectuoso.Cantidad
                .Parameters("@DefectoNota").Value = pDefectuoso.DefectoNota
                .Parameters("@Autorizo").Value = pDefectuoso.Autorizo.ToUpper
                .Parameters("@Usuario").Value = pDefectuoso.Usuario.ToUpper
                .Parameters("@Fecha").Value = pDefectuoso.Fecha
                .Parameters("@StatusRegistro").Value = pDefectuoso.Status
                .Parameters("@Costo").Value = pDefectuoso.CostoUnit
                .Parameters("@Fecha_Desm").Value = System.DBNull.Value
                .Parameters("@Folio_Tras").Value = 0
                .Parameters("@Fecha_Tras").Value = System.DBNull.Value
                .Parameters("@FIDOCUMENT").Value = pDefectuoso.FIDOCUMENT
                .Parameters("@BloqueoEcommerce").Value = pDefectuoso.BloqueadoEcommerce
                .Parameters("@BloqueoSiHay").Value = pDefectuoso.BloqueadoSiHay
                .Parameters("@Observaciones").Value = pDefectuoso.Observaciones
                'Execute Command
                .ExecuteNonQuery()


                'Assign Other Values
                pDefectuoso.FolioMovimiento = .Parameters("@FolioMovimiento").Value
                pDefectuoso.Fecha = .Parameters("@Fecha").Value

            End With

            'Reset New State of Linea Object 
            pDefectuoso.ResetFlagNew()
            pDefectuoso.ResetFlagDirty()

            sccnnConnection.Close()

            Return pDefectuoso.FolioMovimiento

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


    Public Sub Update(ByVal pDefectuoso As Defectuoso)

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdUpdate As SqlCommand
        sccmdUpdate = New SqlCommand

        With sccmdUpdate

            .Connection = sccnnConnection

            .CommandText = "dbo.[DefectuososUpd]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@DefectuosoID", System.Data.SqlDbType.Int, 4))
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
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioMovimiento", System.Data.SqlDbType.Int, 4))

        End With

        Try

            sccnnConnection.Open()

            With sccmdUpdate
                'Assign Parameters Values
                .Parameters("@CodAlmacen").Value = pDefectuoso.CodAlmacen.ToUpper
                .Parameters("@CodCaja").Value = pDefectuoso.CodCaja.ToUpper
                .Parameters("@FacturaID").Value = pDefectuoso.FacturaID
                .Parameters("@CodArticulo").Value = pDefectuoso.CodArticulo.ToUpper
                .Parameters("@Numero").Value = pDefectuoso.Numero
                .Parameters("@Cantidad").Value = pDefectuoso.Numero
                .Parameters("@DefectoNota").Value = pDefectuoso.DefectoNota
                .Parameters("@Autorizo").Value = pDefectuoso.Autorizo.ToUpper
                .Parameters("@Usuario").Value = pDefectuoso.Usuario.ToUpper
                .Parameters("@StatusRegistro").Value = pDefectuoso.Status
                .Parameters("@Costo").Value = pDefectuoso.CostoUnit
                .Parameters("@Fecha_Desm").Value = pDefectuoso.Fecha_Desm
                .Parameters("@Folio_Tras").Value = pDefectuoso.Folio_Tras
                .Parameters("@Fecha_Tras").Value = pDefectuoso.Fecha_Tras
                .Parameters("@FolioMovimiento").Value = pDefectuoso.FolioMovimiento

                'Execute Command
                .ExecuteNonQuery()

                'Assign Other Values
                pDefectuoso.Fecha = .Parameters("@Fecha").Value

            End With

            'Reset New State of Linea Object 
            pDefectuoso.ResetFlagDirty()

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


    Public Sub Delete(ByVal ID As Integer)

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdDelete As SqlCommand
        sccmdDelete = New SqlCommand

        With sccmdDelete

            .Connection = sccnnConnection
            .CommandText = "[DefectuososDel]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@DefectuosoID", System.Data.SqlDbType.Int, 4))

        End With

        Try

            sccnnConnection.Open()

            With sccmdDelete
                'Assign Parameters Values
                .Parameters("@DefectuosoID").Value = ID

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


    Public Function SelectByID(ByVal ID As Integer, Optional ByVal Target As Defectuoso = Nothing) As Defectuoso

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        If Target Is Nothing Then
            oDefectuoso = oParent.Create
        Else
            oDefectuoso = Target
        End If

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[DefectuososSel]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@DefectuosoID", System.Data.SqlDbType.Int, 4))

        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect
                'Assign Parameters Values
                .Parameters("@DefectuosoID").Value = ID

                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    With scdrReader

                        oDefectuoso.ID = .GetInt32(.GetOrdinal("DefectuosoID"))
                        oDefectuoso.CodAlmacen = .GetString(.GetOrdinal("CodAlmacen")).ToUpper
                        oDefectuoso.CodCaja = .GetString(.GetOrdinal("CodCaja")).ToUpper
                        oDefectuoso.FacturaID = .GetInt32(.GetOrdinal("FacturaID"))
                        oDefectuoso.CodArticulo = .GetString(.GetOrdinal("CodArticulo")).ToUpper
                        oDefectuoso.Numero = .GetString(.GetOrdinal("Numero"))
                        oDefectuoso.Cantidad = .GetInt32(.GetOrdinal("Cantidad"))
                        oDefectuoso.DefectoNota = .GetString(.GetOrdinal("DefectoNota"))
                        oDefectuoso.Autorizo = .GetString(.GetOrdinal("Autorizo")).ToUpper
                        oDefectuoso.Fecha = .GetDateTime(.GetOrdinal("Fecha"))
                        oDefectuoso.Status = .GetBoolean(.GetOrdinal("StatusRegistro")).ToString.ToUpper
                        oDefectuoso.CostoUnit = .GetDecimal(.GetOrdinal("Costo"))
                        oDefectuoso.Fecha_Desm = .GetDateTime(.GetOrdinal("Fecha_Desm"))
                        oDefectuoso.Folio_Tras = .GetString(.GetOrdinal("Folio_Tras"))
                        oDefectuoso.Fecha_Tras = .GetDateTime(.GetOrdinal("Fecha_Tras"))
                        oDefectuoso.FolioMovimiento = .GetInt32(.GetOrdinal("FolioMovimiento"))
                        oDefectuoso.UsuarioMov = .GetString(.GetOrdinal("Usuario")).ToUpper

                        Dim dsFactura As New DataSet

                        dsFactura = LoadFacturaByID(oDefectuoso.FacturaID)

                        If Not dsFactura Is Nothing Then
                            oDefectuoso.FolioFactura = dsFactura.Tables(0).Rows(0).Item("FolioFactura")

                            dsFactura.Dispose()
                            dsFactura = Nothing
                        End If

                        'Reset New State of Linea Object 
                        oDefectuoso.ResetFlagNew()
                        oDefectuoso.ResetFlagDirty()

                    End With

                Else
                    oDefectuoso = Nothing
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

        'If (oDefectuoso Is Nothing) Then
        '    Throw New ApplicationException("El registro no pudo ser leido debido a que el ID de línea no existe.")
        'End If

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return oDefectuoso

    End Function


    Public Function SelectAll(ByVal EnabledRecordsOnly As Boolean) As DataSet

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaDefectuoso As SqlDataAdapter
        Dim dsDefectuoso As DataSet

        sccmdSelectAll = New SqlCommand
        scdaDefectuoso = New SqlDataAdapter
        dsDefectuoso = New DataSet("Defectuosos")

        With sccmdSelectAll

            .Connection = sccnnConnection

            .CommandText = "[DefectuososSelAll]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@OnlyEnabledRecords", System.Data.SqlDbType.Bit, 1))

        End With

        scdaDefectuoso.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            scdaDefectuoso.SelectCommand.Parameters("@OnlyEnabledRecords").Value = EnabledRecordsOnly

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

        Return dsDefectuoso

    End Function


    Public Function SelectAllCodigos(ByVal EnabledRecordsOnly As Boolean) As DataSet

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaDefectuoso As SqlDataAdapter
        Dim dsDefectuoso As DataSet

        sccmdSelectAll = New SqlCommand
        scdaDefectuoso = New SqlDataAdapter
        dsDefectuoso = New DataSet("Defectuosos")

        With sccmdSelectAll

            .Connection = sccnnConnection

            .CommandText = "[DefectuososSelAllCodigos]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@OnlyEnabledRecords", System.Data.SqlDbType.Bit, 1))

        End With

        scdaDefectuoso.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            scdaDefectuoso.SelectCommand.Parameters("@OnlyEnabledRecords").Value = EnabledRecordsOnly

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

        Return dsDefectuoso

    End Function

    Public Function SelectDataGeneral(ByVal CodArticulo As String) As DataRow

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaDefectuoso As SqlDataAdapter
        Dim dsDefectuoso As DataSet

        sccmdSelectAll = New SqlCommand
        scdaDefectuoso = New SqlDataAdapter
        dsDefectuoso = New DataSet("Defectuosos")

        With sccmdSelectAll

            .Connection = sccnnConnection

            .CommandText = "[DefectuososSelDatosGenerales]"
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

    Public Function SelectDataDetail(ByVal CodArticulo As String) As DataRowCollection

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

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

    Public Sub InsertMoveInOut(ByVal CodTipoMov As Integer, _
                                 ByVal TipoMovimiento As String, _
                                     ByVal Numero As String, _
                                         ByVal pDefectuoso As Defectuoso)

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

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

                'Assign Parameters Values
                .Parameters("@CodTipoMov").Value = CodTipoMov
                .Parameters("@TipoMovimiento").Value = TipoMovimiento
                .Parameters("@StatusMov").Value = "A"
                .Parameters("@CodAlmacen").Value = pDefectuoso.Movimiento.CodAlmacenMov
                .Parameters("@Destino").Value = pDefectuoso.Movimiento.CodAlmacenMov
                .Parameters("@Folio").Value = pDefectuoso.Movimiento.Folio
                .Parameters("@FolioSAP").Value = "0"
                .Parameters("@CodArticulo").Value = pDefectuoso.Movimiento.CodArticuloMov
                .Parameters("@Descripcion").Value = pDefectuoso.Movimiento.Descripcion
                .Parameters("@Numero").Value = Numero
                .Parameters("@Total").Value = 0
                .Parameters("@Apartados").Value = 0
                .Parameters("@Defectuosos").Value = pDefectuoso.Cantidad
                .Parameters("@Promocion").Value = 0
                .Parameters("@VtasEspeciales").Value = 0
                .Parameters("@Consignacion").Value = 0
                .Parameters("@Transito").Value = 0
                .Parameters("@CodLinea").Value = pDefectuoso.Movimiento.CodLinea
                .Parameters("@CodMarca").Value = pDefectuoso.Movimiento.CodMarca
                .Parameters("@CodFamilia").Value = pDefectuoso.Movimiento.CodFamilia
                .Parameters("@CodUso").Value = Format(pDefectuoso.Movimiento.CodUso, "00000000")
                .Parameters("@CodCategoria").Value = Format(pDefectuoso.Movimiento.CodCategoria, "000")
                .Parameters("@CodUnidad").Value = pDefectuoso.Movimiento.CodUnidad
                .Parameters("@Usuario").Value = oParent.ApplicationContext.Security.CurrentUser.Name
                .Parameters("@CostoUnit").Value = pDefectuoso.Movimiento.CostoUnit
                .Parameters("@PrecioUnit").Value = pDefectuoso.Movimiento.PrecioUnit
                .Parameters("@FolioControl").Value = "" 'Folio al Iniciar Dia.
                .Parameters("@CodCaja").Value = pDefectuoso.Movimiento.CodCajaMov
                .Parameters("@Descuento").Value = 0
                .Parameters("@TOTFGRAL").Value = 0
                .Parameters("@TOTNC").Value = 0
                .Parameters("@CostoNC").Value = 0
                .Parameters("@VTA_DIP").Value = "N"

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

    Public Function LoadDataFactura(ByVal FolioFactura As Integer, ByVal CodCaja As String) As DataSet

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim daFactura As SqlDataAdapter
        Dim sccmdSelect As SqlCommand
        Dim dsFactura As DataSet = New DataSet("DetalleFactura")

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[DefectuososFacturaCorridaSel]"
            .CommandType = CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar, 2, "CodCaja"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioFactura", System.Data.SqlDbType.Int, 4, "FolioFactura"))

            .Parameters("@CodCaja").Value = CodCaja
            .Parameters("@FolioFactura").Value = FolioFactura

        End With

        daFactura = New SqlDataAdapter(sccmdSelect)

        Try

            sccnnConnection.Open()

            'Llenamos el Dataset
            daFactura.Fill(dsFactura)

            If (dsFactura.Tables(0).Rows.Count > 0) Then

                LoadDataFactura = dsFactura

            Else

                LoadDataFactura = Nothing

            End If


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

    End Function


    Public Function LoadDataTallas(ByVal IDCorrida As String) As DataSet

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim daTallas As SqlDataAdapter
        Dim sccmdSelect As SqlCommand
        Dim dsTallas As DataSet = New DataSet("Tallas")

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "SELECT C01,C02,C03,C04,C05,C06,C07,C08,C09,C10,C11,C12,C13,C14,C15,C16,C17,C18,C19,C20 " & _
                            "FROM CatalogoCorridas WHERE CodCorrida='" & IDCorrida & "'"
            .CommandType = CommandType.Text

        End With

        daTallas = New SqlDataAdapter(sccmdSelect)

        Try

            sccnnConnection.Open()

            'Llenamos el Dataset
            daTallas.Fill(dsTallas)

            If (dsTallas.Tables(0).Rows.Count > 0) Then

                LoadDataTallas = dsTallas

            Else

                LoadDataTallas = Nothing

            End If

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

    End Function


    Public Function LoadStock(ByVal CodAlmacen As String, _
                                ByVal CodArticulo As String, _
                                    ByVal Talla As String) As Integer

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim daTallas As SqlDataAdapter
        Dim sccmdSelect As SqlCommand
        Dim dsTallas As DataSet = New DataSet("Existencia")

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "SELECT Libre FROM Existencias WHERE CodAlmacen='" & CodAlmacen & "' And " & _
                            "CodArticulo = '" & CodArticulo & "' And Numero = '" & Talla & "'"
            .CommandType = CommandType.Text

        End With

        daTallas = New SqlDataAdapter(sccmdSelect)

        Try

            sccnnConnection.Open()

            'Llenamos el Dataset
            daTallas.Fill(dsTallas)

            If (dsTallas.Tables(0).Rows.Count > 0) Then

                LoadStock = dsTallas.Tables(0).Rows(0).Item(0)

            Else

                LoadStock = 0

            End If

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

    End Function

    Public Function LoadListFactura(ByVal EnabledRecordOnly As Boolean, Optional ByVal strTipoVenta As String = "") As DataSet

        Dim oResult As DataSet
        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection


            If EnabledRecordOnly = True Then

                Dim strAddCondicion As String = IIf(strTipoVenta = String.Empty, "", " and CodTipoVenta='" & strTipoVenta & "' and (Referencia<>'' OR Fecha < '01/01/2006')")

                .CommandText = "SELECT FacturaID AS ID, CodCaja AS Caja, FolioFactura as Folio, Referencia,FolioSAP , CodVendedor As Vendedor, Fecha, StatusRegistro As Habilitado " & _
                                    "FROM Factura WHERE StatusRegistro = 1 " & strAddCondicion & " ORDER BY CodCaja, FolioFactura"

            Else
                Dim strAddCondicion As String = IIf(strTipoVenta = String.Empty, "", "Where CodTipoVenta='" & strTipoVenta & "' and (Referencia<>'' OR Fecha < '01/01/2006')")

                .CommandText = "SELECT FacturaID AS ID, CodCaja AS Caja, FolioFactura as Folio, Referencia,FolioSAP, CodVendedor As Vendedor, Fecha, StatusRegistro As Habilitado " & _
                                    "FROM Factura " & strAddCondicion & " ORDER BY CodCaja, FolioFactura"



            End If

            .CommandType = System.Data.CommandType.Text

        End With

        Dim oFacturaAdapter As SqlDataAdapter
        oFacturaAdapter = New SqlDataAdapter
        oFacturaAdapter.SelectCommand = sccmdSelect

        Try

            sccnnConnection.Open()

            oResult = New DataSet

            oFacturaAdapter.Fill(oResult, "Facturas")

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


    Public Function LoadFacturaByID(ByVal FacturaID As Integer) As DataSet

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim daFactura As SqlDataAdapter
        Dim sccmdSelect As SqlCommand
        Dim dsFactura As DataSet = New DataSet("FacturaGeneral")

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "Select FolioFactura, CodCaja, FolioSap,Referencia From Factura Where FacturaID = " & FacturaID & ""
            .CommandType = CommandType.Text

        End With

        daFactura = New SqlDataAdapter(sccmdSelect)

        Try

            sccnnConnection.Open()

            'Llenamos el Dataset
            daFactura.Fill(dsFactura)

            If (dsFactura.Tables(0).Rows.Count > 0) Then

                LoadFacturaByID = dsFactura

            Else

                LoadFacturaByID = Nothing

            End If


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

    End Function


    '-------------------------------------------------------------------------------------------------------------------
    'MLVARGAS 30/05/2022: Rutina para desmarcar productos defectuosos
    '-------------------------------------------------------------------------------------------------------------------

    Public Sub ActualizarDesmarcado(ByVal dsDefectuosos As DataSet)
        Dim sccnnConnection As New SqlConnection(m_strConnectionString)
        Dim sccmdUpdate As SqlCommand
        sccmdUpdate = New SqlCommand

        With sccmdUpdate

            .Connection = sccnnConnection
            .CommandText = "[DefectuososDesmarcar]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Connection = sccnnConnection

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodArticulo", System.Data.SqlDbType.VarChar, 20))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Cantidad", System.Data.SqlDbType.VarChar, 3))

        End With

        Try
            sccnnConnection.Open()
            With sccmdUpdate
                'Assign Parameters Values

                For Each row As DataRow In dsDefectuosos.Tables("DefectuososD").Rows
                    If CInt(row("Desmarcar")) > 0 Then

                        .Parameters("@CodAlmacen").Value = oParent.ApplicationContext.ApplicationConfiguration.Almacen
                        .Parameters("@CodArticulo").Value = row("CodArticulo")
                        .Parameters("@Cantidad").Value = CInt(row("Desmarcar"))
                        .ExecuteNonQuery()
                    End If
                Next


            End With

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



    '-------------------------------------------------------------------------------------------------------------------
    'MLVARGAS 15/05/2018: Rutina para editar campos de fecha desmarcado y StatusRegistro de tabla Defectuosos
    '-------------------------------------------------------------------------------------------------------------------

    'Public Sub ActualizarDesmarcado(ByVal dsDefectuosos As DataSet)
    '    Dim sccnnConnection As New SqlConnection(m_strConnectionString)
    '    Dim sccmdUpdate As SqlCommand
    '    sccmdUpdate = New SqlCommand

    '    With sccmdUpdate

    '        .Connection = sccnnConnection
    '        .CommandText = "[DefectuososUpdEstatus]"
    '        .CommandType = System.Data.CommandType.StoredProcedure
    '        .Connection = sccnnConnection

    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 3))
    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodArticulo", System.Data.SqlDbType.VarChar, 20))

    '    End With

    '    Try
    '        sccnnConnection.Open()
    '        With sccmdUpdate
    '            'Assign Parameters Values

    '            For Each row As DataRow In dsDefectuosos.Tables("DefectuososD").Rows
    '                If CInt(row("Desmarcar")) > 0 Then
    '                    .Parameters("@CodAlmacen").Value = oParent.ApplicationContext.ApplicationConfiguration.Almacen
    '                    .Parameters("@CodArticulo").Value = row("CodArticulo")
    '                    .ExecuteNonQuery()
    '                End If
    '            Next
    '        End With

    '    Catch oSqlException As SqlException
    '        If (sccnnConnection.State <> ConnectionState.Closed) Then
    '            Try
    '                sccnnConnection.Close()
    '            Catch
    '            End Try
    '        End If

    '        Throw New ApplicationException("El registro no pudo ser insertado debido a un error de base de datos.", oSqlException)

    '    Catch ex As Exception
    '        If (sccnnConnection.State <> ConnectionState.Closed) Then
    '            Try
    '                sccnnConnection.Close()
    '            Catch
    '            End Try
    '        End If

    '        Throw New ApplicationException("El registro no pudo ser insertado debido a un error de aplicación.", ex)
    '    End Try

    '    sccnnConnection.Dispose()
    '    sccnnConnection = Nothing
    'End Sub


    Public Function DesmarcarDefectuosos(ByVal dsDefectuosos As DataSet, ByVal Cantidad As Integer, _
                                        ByVal strUser As String, ByVal bolDesmarcar As Boolean, ByVal motivo As String, _
                                        ByVal bDesmarcarEnSAP As Boolean, ByVal bajaCalidad As Boolean) As Integer

        dsDefectuosos.AcceptChanges()

        oArticulosMgr = New CatalogoArticuloManager(oParent.ApplicationContext)
        Dim myTransaction As SqlClient.SqlTransaction
        Dim sccnnConnection As New SqlConnection(m_strConnectionString)
        Dim Folio As Integer
        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand



        With sccmdInsert

            .Connection = sccnnConnection

            .CommandText = "[DesDefectuososGIns]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Connection = sccnnConnection

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Folio", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Output, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime, 8))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Usuario", System.Data.SqlDbType.VarChar, 12))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Cantidad", System.Data.SqlDbType.TinyInt, 1))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Importe", System.Data.SqlDbType.Decimal))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Status", System.Data.SqlDbType.Bit, 1))

        End With

        Try

            sccnnConnection.Open()
            myTransaction = sccnnConnection.BeginTransaction()

            With sccmdInsert
                'Assign Parameters Values

                .Parameters("@CodAlmacen").Value = oParent.ApplicationContext.ApplicationConfiguration.Almacen
                .Parameters("@Fecha").Value = Now
                .Parameters("@Usuario").Value = strUser
                .Parameters("@Cantidad").Value = Cantidad
                .Parameters("@Importe").Value = dsDefectuosos.Tables("DefectuososD").Compute("sum(Total)", "Total>=0")
                .Parameters("@Status").Value = True

                'Execute Command
                sccmdInsert.Transaction = myTransaction
                .ExecuteNonQuery()

                Folio = .Parameters("@Folio").Value


                'Posteriormente se recorre la tabla DefectuososD (Detalle) para hacer el insertado en la misma, 
                'recordar usar una transaion por si marca error los cambios no tenga efecto

                'Assign Other Values


            End With

            'Reset New State of Linea Object 


            'Insertado Detalle

            With sccmdInsert

                .Connection = sccnnConnection

                .CommandText = "[DesDefectuososDIns]"
                .CommandType = System.Data.CommandType.StoredProcedure
                .Connection = sccnnConnection
                .Parameters.Clear()

                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Folio", System.Data.SqlDbType.Int, 4))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodArticulo", System.Data.SqlDbType.VarChar, 20))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Talla", System.Data.SqlDbType.VarChar, 4))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Cantidad", System.Data.SqlDbType.TinyInt, 1))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@PrecioUnit", System.Data.SqlDbType.Decimal))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Status", System.Data.SqlDbType.Bit, 1))

            End With


            'sccnnConnection.Open()
            With sccmdInsert
                'Assign Parameters Values


                For Each row As DataRow In dsDefectuosos.Tables("DefectuososD").Rows

                    If CInt(row("Desmarcar")) > 0 Then
                        .Parameters("@Folio").Value = Folio
                        .Parameters("@CodArticulo").Value = row("CodArticulo")
                        .Parameters("@Talla").Value = "" 'row("Numero")
                        .Parameters("@Cantidad").Value = row("Desmarcar")
                        .Parameters("@PrecioUnit").Value = row("PrecioUni")
                        .Parameters("@Fecha").Value = Now
                        .Parameters("@Status").Value = True
                        If bajaCalidad = True Then
                            .Parameters.Add("@BloqueoEcommerce", True)
                            .Parameters.Add("@BloqueoSiHay", False)
                        End If

                        'Execute Command
                        .ExecuteNonQuery()

                        If bolDesmarcar = True Then

                            'Complemento el objeto de Defectuoso con los valores necesario para efectuar la operación de marcado
                            FillDataMovimiento(Folio, row)

                            'Guardamos de Existencia en el inventario
                            oParent.SaveMoveInOut(0, "O", "", oDefectuoso)

                        End If

                    End If

                Next



                'Posteriormente se recorre la tabla DefectuososD (Detalle) para hacer el insertado en la misma, 
                'recordar usar una transaion por si marca error los cambios no tenga efecto

                'Assign Other Values

                myTransaction.Commit()

            End With



            sccnnConnection.Close()



            '-----------------------------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 26/03/2014: Se comento porque ya se realiza en una funcion aparte en el traslado de Defectuoso
            '-----------------------------------------------------------------------------------------------------------------------------------
            'RGERMAIN 20.06.2014: Se agrego un parametro para saber si se necesita desmarcar en SAP o no porque en los traspasos por defectuosos
            '                     ya no se necesita
            '-----------------------------------------------------------------------------------------------------------------------------------
            If bDesmarcarEnSAP Then DesbloquearSAP(Folio, dsDefectuosos, motivo)

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

    Private Sub FillDataMovimiento(ByVal ID As Integer, ByVal row As DataRow)

        oArticulo = oArticulosMgr.Load(row("CodArticulo"))
        oDefectuoso.Cantidad = row("Desmarcar") * -1

        With oDefectuoso.Movimiento

            .CodTipoMov = 0
            .TipoMovimiento = ""
            .StatusMov = "A"
            .CodAlmacenMov = oParent.ApplicationContext.ApplicationConfiguration.Almacen
            .Destino = oParent.ApplicationContext.ApplicationConfiguration.Almacen
            .Folio = ID
            .CodArticuloMov = row("CodArticulo")
            .Descripcion = oArticulo.Descripcion
            .NumeroMov = 0
            .Total = 0
            .Apartados = 0
            .Defectuosos = 0
            .Promocion = 0
            .VtasEspeciales = 0
            .Consignacion = 0
            .Transito = 0
            .CodLinea = oArticulo.Codlinea
            .CodMarca = oArticulo.CodMarca
            .CodFamilia = oArticulo.CodFamilia
            .CodUnidad = oArticulo.CodUnidadVta
            .CodUso = oArticulo.CodUso
            .CodCategoria = oArticulo.CodCategoria

            .UsuarioMov = oDefectuoso.Usuario
            .CostoUnit = row("PrecioUni")
            .PrecioUnit = row("PrecioUni")
            .FolioControl = ""
            .CodCajaMov = oDefectuoso.CodCaja

        End With
    End Sub

    Public Function SelectAllDefectuososG(ByVal EnabledRecordsOnly As Boolean) As DataSet

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaDefectuoso As SqlDataAdapter
        Dim dsDefectuoso As DataSet

        sccmdSelectAll = New SqlCommand
        scdaDefectuoso = New SqlDataAdapter
        dsDefectuoso = New DataSet("DefectuososG")

        With sccmdSelectAll

            .Connection = sccnnConnection

            .CommandText = "[DesDefectuososSelAllG]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@OnlyEnabledRecords", System.Data.SqlDbType.Bit, 1))

        End With

        scdaDefectuoso.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            scdaDefectuoso.SelectCommand.Parameters("@OnlyEnabledRecords").Value = EnabledRecordsOnly

            'Fill DataSet
            scdaDefectuoso.Fill(dsDefectuoso, "DefectuososG")

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

        Return dsDefectuoso

    End Function

    Public Function SelectAllDesmarcadosD(ByVal Folio As Integer) As DataRowCollection

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaDefectuoso As SqlDataAdapter
        Dim dsDefectuoso As DataSet

        sccmdSelectAll = New SqlCommand
        scdaDefectuoso = New SqlDataAdapter
        dsDefectuoso = New DataSet("DefectuososD")

        With sccmdSelectAll

            .Connection = sccnnConnection

            .CommandText = "[DesDefectuososDSelByFolio]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Folio", System.Data.SqlDbType.Int, 4))

        End With

        scdaDefectuoso.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            scdaDefectuoso.SelectCommand.Parameters("@Folio").Value = Folio

            'Fill DataSet
            scdaDefectuoso.Fill(dsDefectuoso, "DefectuososD")

            If dsDefectuoso.Tables("DefectuososD").Rows.Count > 0 Then
                Return dsDefectuoso.Tables("DefectuososD").Rows
            End If

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


    End Function


    Public Function SelectAllDesmarcadosG(ByVal Folio As Integer) As DataRowCollection

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaDefectuoso As SqlDataAdapter
        Dim dsDefectuoso As DataSet

        sccmdSelectAll = New SqlCommand
        scdaDefectuoso = New SqlDataAdapter
        dsDefectuoso = New DataSet("DefectuososG")

        With sccmdSelectAll

            .Connection = sccnnConnection

            .CommandText = "[DesDefectuososGSelByFolio]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Folio", System.Data.SqlDbType.Int, 4))

        End With

        scdaDefectuoso.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            scdaDefectuoso.SelectCommand.Parameters("@Folio").Value = Folio

            'Fill DataSet
            scdaDefectuoso.Fill(dsDefectuoso, "DefectuososG")

            If dsDefectuoso.Tables("DefectuososG").Rows.Count > 0 Then
                Return dsDefectuoso.Tables("DefectuososG").Rows
            End If

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


    End Function


    Public Function [SelectFolio]() As Integer

        Dim oResult As Integer

        Dim sccnnDPTienda As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                                 DataStorageConfiguration.GetConnectionString)

        '(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString)

        Dim sccmdRetirosSel As SqlCommand
        sccmdRetirosSel = New SqlCommand

        With sccmdRetirosSel
            .CommandText = "[DefectuosoSelFolio]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Connection = sccnnDPTienda

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))

        End With

        Try

            sccnnDPTienda.Open()

            Dim scsdrReader As SqlDataReader

            scsdrReader = sccmdRetirosSel.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.SingleRow)

            scsdrReader.Read()

            If (scsdrReader.HasRows) Then


                With scsdrReader

                    oResult = .GetInt32(0)

                End With

                scsdrReader.Close()

            Else
                MessageBox.Show("Código no existe", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If


        Catch ex As Exception

            MessageBox.Show(ex.ToString)

        Finally

            If (sccnnDPTienda.State <> ConnectionState.Closed) Then
                Try
                    sccnnDPTienda.Close()
                Catch
                End Try
            End If

        End Try

        sccmdRetirosSel.Dispose()
        sccmdRetirosSel = Nothing

        sccnnDPTienda.Dispose()
        sccnnDPTienda = Nothing

        Return oResult

    End Function

    Public Function [SelectFolioDesmarcado]() As Integer

        Dim oResult As Integer

        Dim sccnnDPTienda As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                                 DataStorageConfiguration.GetConnectionString)

        '(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString)

        Dim sccmdRetirosSel As SqlCommand
        sccmdRetirosSel = New SqlCommand

        With sccmdRetirosSel
            .CommandText = "[DesDefectuosoGSelFolio]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Connection = sccnnDPTienda

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))

        End With

        Try

            sccnnDPTienda.Open()

            Dim scsdrReader As SqlDataReader

            scsdrReader = sccmdRetirosSel.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.SingleRow)

            scsdrReader.Read()

            If (scsdrReader.HasRows) Then


                With scsdrReader

                    oResult = .GetInt32(0)

                End With

                scsdrReader.Close()

            Else
                MessageBox.Show("Código no existe", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If


        Catch ex As Exception

            MessageBox.Show(ex.ToString)

        Finally

            If (sccnnDPTienda.State <> ConnectionState.Closed) Then
                Try
                    sccnnDPTienda.Close()
                Catch
                End Try
            End If

        End Try

        sccmdRetirosSel.Dispose()
        sccmdRetirosSel = Nothing

        sccnnDPTienda.Dispose()
        sccnnDPTienda = Nothing

        Return oResult

    End Function

    Public Sub UpdateDesmarcado(ByVal Folio As Integer, ByVal FIDOCUMENT As String)

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdUpdate As SqlCommand
        sccmdUpdate = New SqlCommand

        With sccmdUpdate

            .Connection = sccnnConnection

            .CommandText = "dbo.[DesDefectuososGUpd]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Folio", System.Data.SqlDbType.Int, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FIDOCUMENT", System.Data.SqlDbType.VarChar, 10))

        End With

        Try

            sccnnConnection.Open()

            With sccmdUpdate
                'Assign Parameters Values
                .Parameters("@Folio").Value = Folio
                .Parameters("@FIDOCUMENT").Value = FIDOCUMENT

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

#End Region

#Region "Metodos SAP"

    'Private Sub SaveSAP(ByVal pDefectuoso As Defectuoso)
    '    Try

    '        Dim objR3 As New SAPFunctionsOCX.SAPFunctions
    '        Dim objFunc As SAPFunctionsOCX.Function

    '        'Parametros Exports
    '        Dim CENTRO As SAPFunctionsOCX.Parameter     'CENTRO
    '        Dim ALMACEN As SAPFunctionsOCX.Parameter    'ALMACEN
    '        Dim MOTIVO As SAPFunctionsOCX.Parameter     'MOTIVO
    '        Dim I_FECHA As SAPFunctionsOCX.Parameter    'Fecha Movimiento
    '        'Fin Parametros Exports

    '        'Estructura AUX
    '        Dim oStructureSAP As Object
    '        'Fin Estructura AUX

    '        'Parametros Imports
    '        Dim FIDOCUMENT As SAPFunctionsOCX.Parameter 'Número de un Documento Contable
    '        Dim oRETURN As Object
    '        'Fin parametros Imports

    '        'Tablas
    '        Dim ZTABLA_APARTADO As SAPTableFactoryCtrl.Table 'Tabla de control de articulos MARCADOS
    '        'Fin Tablas

    '        With objR3.Connection
    '            .ApplicationServer = oParent.SAPApplicationConfig.ApplicationServer
    '            .GroupName = oParent.SAPApplicationConfig.GroupName
    '            .System = oParent.SAPApplicationConfig.System
    '            .Client = oParent.SAPApplicationConfig.Client
    '            .User = oParent.SAPApplicationConfig.User
    '            .Password = oParent.SAPApplicationConfig.Password
    '            .language = oParent.SAPApplicationConfig.Language
    '            .SystemNumber = oParent.SAPApplicationConfig.System
    '        End With

    '        If objR3.Connection.logon(0, True) <> True Then
    '            Throw New ApplicationException("No se pudo establecer la conexión con SAP.")
    '        End If

    '        objFunc = objR3.Add("ZBAPIMM12_BLOQUEDEMATERIAL")

    '        'Exports
    '        CENTRO = objFunc.Exports("CENTRO")
    '        ALMACEN = objFunc.Exports("ALMACEN")
    '        MOTIVO = objFunc.Exports("MOTIVO")
    '        I_FECHA = objFunc.Exports("I_FECHA")
    '        'Fin Exports



    '        'Tablas
    '        ZTABLA_APARTADO = objFunc.Tables("ZTABLA_APARTADO")
    '        'Fin Tablas

    '        'Imports
    '        FIDOCUMENT = objFunc.Imports("DOCFI")
    '        oRETURN = objFunc.Imports("RETURN")
    '        'Fin Imports

    '        'Captura de Info

    '        CENTRO.Value = Me.oSapCentro.Read_Centros
    '        ALMACEN.Value = "A001"
    '        MOTIVO.Value = "0004"
    '        I_FECHA.Value = CStr(Format(Date.Now.Date, "dd/MM/yyyy"))

    '        oStructureSAP = ZTABLA_APARTADO.AppendRow()
    '        oStructureSAP.Value("CENTRO") = "A001"
    '        oStructureSAP.Value("MATNR") = pDefectuoso.CodArticulo
    '        oStructureSAP.Value("Cantidad") = pDefectuoso.Cantidad

    '        If IsNumeric(pDefectuoso.Numero) Then
    '            oStructureSAP.Value("TALLA") = Format(CDec(pDefectuoso.Numero), "##.0")
    '        Else
    '            oStructureSAP.Value("TALLA") = pDefectuoso.Numero
    '        End If

    '        'Fin Captura de Info
    '        '        MsgBox(oTableSAP.RowCount)

    '        objFunc.Call()

    '        If FIDOCUMENT.Value = String.Empty Then
    '            Throw New ApplicationException("Error al Guardar Defectuoso SAP ") 'oRETURN.Value("message"))
    '        End If

    '        objR3.Connection.LogOff()

    '        pDefectuoso.FIDOCUMENT = FIDOCUMENT.Value


    '    Catch ex As Exception
    '        Throw ex
    '    End Try

    'End Sub

    'Ok

    'Ok

    'Private Sub SaveSAP(ByVal pDefectuoso As Defectuoso)
    '    '----------------------------------------------------------------------------------
    '    ' JNAVA (04.01.2016): Cambio de libreria para compatibilidad con SAP 6.0
    '    '----------------------------------------------------------------------------------
    '    Try
    '        ''Set Licenses.
    '        Dim Lic As ERPConnectLIC.Lic
    '        Lic.SetLic()

    '        Dim R3 As New ERPConnect.R3Connection( _
    '                 oParent.SAPApplicationConfig.ApplicationServer, _
    '                 oParent.SAPApplicationConfig.System, _
    '                 oParent.SAPApplicationConfig.User, _
    '                 oParent.SAPApplicationConfig.Password, _
    '                 oParent.SAPApplicationConfig.Language, _
    '                 oParent.SAPApplicationConfig.Client)

    '        ' Si no se logro conectar con éxito, entonces sale de la rutina
    '        R3.Open()
    '        If R3.Ping = False Then
    '            MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Proceso SAP")
    '            Exit Sub
    '        Else
    '            '*****************************************************
    '            'Call RFC function  ZBAPIMM12_BLOQUEDEMATERIAL
    '            '*****************************************************
    '            ' Create a function object
    '            Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZBAPIMM12_BLOQUEDEMATERIAL")

    '            '-----------------------------------------------------------------------------
    '            ' JNAVA (13.02.2016): Se manda centro SAP y se manda el almacen nuevo M001
    '            '-----------------------------------------------------------------------------
    '            Dim CentroSAP As String = Me.oSapCentro.Read_Centros
    '            'Asigno valores
    '            func.Exports("CENTRO").ParamValue = CentroSAP
    '            func.Exports("ALMACEN").ParamValue = "M001"
    '            '-----------------------------------------------------------------------------

    '            func.Exports("MOTIVO").ParamValue = "0004"
    '            func.Exports("I_FECHA").ParamValue = CStr(Format(Date.Now.Date, "dd/MM/yyyy"))

    '            Dim T_CLines As ERPConnect.RFCTable = func.Tables("ZTABLA_APARTADO")
    '            Dim R_CLines As ERPConnect.RFCStructure = T_CLines.AddRow()

    '            '-----------------------------------------------------------------------------
    '            ' JNAVA (13.02.2016): Centro SAP es enviado en el centro de la tabla
    '            '-----------------------------------------------------------------------------
    '            R_CLines("CENTRO") = CentroSAP '"A001
    '            '-----------------------------------------------------------------------------

    '            R_CLines("MATNR") = pDefectuoso.CodArticulo
    '            R_CLines("CANTIDAD") = pDefectuoso.Cantidad
    '            If IsNumeric(pDefectuoso.Numero) Then
    '                R_CLines("TALLA") = Format(CDec(pDefectuoso.Numero), "##.0")
    '            Else
    '                R_CLines("TALLA") = pDefectuoso.Numero
    '            End If

    '            'Ejecutamos la RFC
    '            func.Execute()

    '            'Obtenemos el Resultado
    '            If CStr(func.Imports("E_PEDIDO").ParamValue) = String.Empty Then
    '                Throw New ApplicationException("Error al Guardar Defectuoso SAP ") 'oRETURN.Value("message"))
    '            End If

    '            R3.Close()

    '            pDefectuoso.FIDOCUMENT = CStr(func.Imports("E_PEDIDO").ParamValue)

    '        End If

    '    Catch e1 As ERPConnect.RFCServerException
    '        Throw e1
    '    Catch e1 As ERPConnect.ERPException
    '        Throw e1
    '    End Try

    'End Sub

    Private Sub SaveSAP(ByVal pDefectuoso As Defectuoso)
        '----------------------------------------------------------------------------------
        ' JNAVA (13.01.2016): Modificado para para compatibilidad con SAP 6.0
        '----------------------------------------------------------------------------------
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
                'Call RFC function  Z_FM_COMMXMM_MOV_APARTADOS
                '*****************************************************
                ' Create a function object
                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("Z_FM_COMMXMM_MOV_APARTADOS")
                Dim CentroSAP As String = Me.oSapCentro.Read_Centros

                'Asigno valores
                func.Exports("I_CENTRO").ParamValue = CentroSAP.Trim
                func.Exports("I_ALMACEN").ParamValue = "M001"
                func.Exports("I_CONTRATO").ParamValue = ""
                func.Exports("I_BLOCK").ParamValue = ""
                func.Exports("I_DEFECTUOSO").ParamValue = "X"

                Dim T_CLines As ERPConnect.RFCTable = func.Tables("TABLA_APARTADO")
                Dim R_CLines As ERPConnect.RFCStructure = T_CLines.AddRow()
                R_CLines("CENTRO") = CentroSAP '"A001
                R_CLines("MATNR") = pDefectuoso.CodArticulo
                R_CLines("CANTIDAD") = pDefectuoso.Cantidad
                'If IsNumeric(pDefectuoso.Numero) Then
                '    R_CLines("TALLA") = Format(CDec(pDefectuoso.Numero), "##.0")
                'Else
                '    R_CLines("TALLA") = pDefectuoso.Numero
                'End If
                R_CLines("LGORT") = "M009" 'ALmacen Default

                'Ejecutamos la RFC
                func.Execute()

                R3.Close()

                'Obtenemos el Resultado
                Dim DocFi As String = CStr(func.Imports("O_MAT_DOC").ParamValue).Trim

                '----------------------------------------------------------------------------------------
                'JNAVA (15.03.2016): se obtiene mensaje de sap en caso de presentarse un error
                '----------------------------------------------------------------------------------------
                Dim dtReturn As DataTable = func.Tables("RETURN").ToADOTable
                Dim strError As String = String.Empty
                If DocFi = String.Empty Then
                    dtReturn = func.Tables("RETURN").ToADOTable
                    For Each oRow As DataRow In dtReturn.Rows
                        strError &= CStr(oRow!MESSAGE) & vbCrLf
                    Next

                    Dim ex As New System.ApplicationException("Error al Guardar Defectuoso SAP. " & vbCrLf & strError) 'oRETURN.Value("message"))
                    Throw ex

                End If
                '----------------------------------------------------------------------------------------

                pDefectuoso.FIDOCUMENT = DocFi

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

    End Sub




    'Public Sub DesbloquearSAP(ByVal strContrato As String, ByVal dsDefectuosos As DataSet, Optional ByVal motivo As String = "0008")
    '    Try
    '        Dim R3 As New SAPFunctionsOCX.SAPFunctions
    '        Dim myFunc As SAPFunctionsOCX.Function
    '        Dim Result As Boolean

    '        ' Se definen los parámetros TABLE            
    '        Dim objtabretTABLA_APARTADO As Object 'SAPTableFactoryCtrl.Table
    '        Dim objtabretReturn As Object

    '        With R3.Connection
    '            .ApplicationServer = oParent.SAPApplicationConfig.ApplicationServer
    '            .GroupName = oParent.SAPApplicationConfig.GroupName
    '            .System = oParent.SAPApplicationConfig.System
    '            .Client = oParent.SAPApplicationConfig.Client
    '            .User = oParent.SAPApplicationConfig.User
    '            .Password = oParent.SAPApplicationConfig.Password
    '            .Language = oParent.SAPApplicationConfig.Language
    '            .SystemNumber = oParent.SAPApplicationConfig.System
    '        End With

    '        ' Si no se logro conectar con éxito, entonces sale de la rutina
    '        If R3.Connection.logon(0, True) <> True Then
    '            Throw New ApplicationException("No se pudo establecer la conexión con SAP.")
    '        Else

    '            ' Definición de los parámetros para el IMPORT de la función SAP
    '            Dim CENTRO As SAPFunctionsOCX.Parameter    'MSEG-WERKS  CENTRO
    '            Dim ALMACEN As SAPFunctionsOCX.Parameter   'MSEG-LGORT  Almacén
    '            Dim CONTRATO As SAPFunctionsOCX.Parameter
    '            Dim DOCFI As SAPFunctionsOCX.Parameter
    '            Dim I_FECHA As SAPFunctionsOCX.Parameter
    '            Dim I_MOTIVO As SAPFunctionsOCX.Parameter
    '            Dim strMaterial, strTalla, strCantidad As String
    '            '********************************************************
    '            'Call RFC function ZBAPIMM14_DESBLOQUEOART  ***Emanuel
    '            '********************************************************
    '            myFunc = R3.Add("ZBAPIMM14_DESBLOQUEOART")
    '            ' Ajusta los parámetros de delimitación de entrada
    '            'Exports
    '            CENTRO = myFunc.Exports("CENTRO")
    '            ALMACEN = myFunc.Exports("ALMACEN")
    '            CONTRATO = myFunc.Exports("CONTRATO")
    '            I_FECHA = myFunc.Exports("I_FECHA")
    '            I_MOTIVO = myFunc.Exports("I_MOTIVO")
    '            'Imports
    '            DOCFI = myFunc.Imports("DOCFI")


    '            ' Cargar la tabla con los datos que vamos a enviar - TABLES.
    '            objtabretTABLA_APARTADO = myFunc.Tables("ZTABLA_APARTADO")
    '            objtabretReturn = myFunc.Tables("RETURN")

    '            Dim strCentro As String = Me.oSapCentro.Read_Centros

    '            For Each row As DataRow In dsDefectuosos.Tables("DefectuososD").Rows
    '                Dim oArticulos As Object
    '                oArticulos = objtabretTABLA_APARTADO.AppendRow()
    '                oArticulos.Value("CENTRO") = strCentro
    '                oArticulos.Value("CONTRATO") = strContrato
    '                oArticulos.Value("MATNR") = row("CodArticulo")
    '                oArticulos.Value("CANTIDAD") = row("Desmarcar")
    '                strMaterial = row("CodArticulo")

    '                strCantidad = row("Desmarcar")
    '                If IsNumeric(row("Numero")) Then
    '                    oArticulos.Value("TALLA") = Format(CDec(row("Numero")), "##.0")
    '                    strTalla = Format(CDec(row("Numero")), "##.0")
    '                Else
    '                    oArticulos.Value("TALLA") = row("Numero")
    '                    strTalla = row("Numero")
    '                End If

    '            Next

    '            '****** Asigno valores a los objetos
    '            CENTRO.Value = strCentro
    '            ALMACEN.Value = strCentro
    '            CONTRATO.Value = strContrato
    '            I_FECHA.Value = CStr(Format(Date.Now.Date, "dd/MM/yyyy"))
    '            I_MOTIVO.Value = motivo

    '            ' Ejecuta función en R/3
    '            Result = myFunc.Call
    '            'Cierra la Conexion
    '            R3.Connection.LOGOFF()

    '            Dim iren As Integer
    '            If DOCFI.Value <> String.Empty Then 'me traigo los campos

    '                UpdateDesmarcado(strContrato, DOCFI.Value)

    '            Else

    '                'MsgBox("TCODE.- " & objtabretReturn(1, 1) & Microsoft.VisualBasic.vbCrLf & "DYNAME.- " & objtabretReturn(1, 2) _
    '                '& Microsoft.VisualBasic.vbCrLf & "DYNUMB.- " & objtabretReturn(1, 3) & Microsoft.VisualBasic.vbCrLf & "MSGTYP.- " & objtabretReturn(1, 4) _
    '                '& Microsoft.VisualBasic.vbCrLf & "MSGSPRA.- " & objtabretReturn(1, 5) & Microsoft.VisualBasic.vbCrLf & "MSGID.- " & objtabretReturn(1, 6) _
    '                '& Microsoft.VisualBasic.vbCrLf & "MSGNR.- " & objtabretReturn(1, 7) & Microsoft.VisualBasic.vbCrLf & "MSGV1.- " & objtabretReturn(1, 8))

    '                MessageBox.Show("Error al Desmarcar en SAP. Producto .- " & _
    '                Microsoft.VisualBasic.vbCrLf & strMaterial, "Desmarcar Defectuosos", MessageBoxButtons.OK, MessageBoxIcon.Error)

    '                'Throw New ApplicationException(objtabretReturn(1, 3))

    '            End If
    '        End If


    '    Catch ex As Exception
    '        Throw New ApplicationException(ex.Message, ex)
    '    End Try
    'End Sub

    'Ok
    'Public Sub DesbloquearSAP(ByVal strContrato As String, ByVal dsDefectuosos As DataSet, Optional ByVal motivo As String = "0008")
    '    '----------------------------------------------------------------------------------
    '    ' JNAVA (04.01.2016): Cambio de libreria para compatibilidad con SAP 6.0
    '    '----------------------------------------------------------------------------------
    '    Dim strMaterial, strTalla, strCantidad As String

    '    Try
    '        ''Set Licenses.
    '        Dim Lic As ERPConnectLIC.Lic
    '        Lic.SetLic()

    '        Dim R3 As New ERPConnect.R3Connection( _
    '                 oParent.SAPApplicationConfig.ApplicationServer, _
    '                 oParent.SAPApplicationConfig.System, _
    '                 oParent.SAPApplicationConfig.User, _
    '                 oParent.SAPApplicationConfig.Password, _
    '                 oParent.SAPApplicationConfig.Language, _
    '                 oParent.SAPApplicationConfig.Client)

    '        ' Si no se logro conectar con éxito, entonces sale de la rutina
    '        R3.Open()
    '        If R3.Ping = False Then
    '            MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Proceso SAP")
    '            Exit Sub
    '        Else
    '            '*****************************************************
    '            'Call RFC function  ZBAPIMM14_DESBLOQUEOART
    '            '*****************************************************
    '            ' Create a function object
    '            Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZBAPIMM14_DESBLOQUEOART")

    '            'Asigno valores
    '            Dim strCentro As String = Me.oSapCentro.Read_Centros
    '            func.Exports("CENTRO").ParamValue = strCentro
    '            func.Exports("ALMACEN").ParamValue = strCentro
    '            func.Exports("CONTRATO").ParamValue = strContrato
    '            func.Exports("MOTIVO").ParamValue = motivo
    '            func.Exports("I_FECHA").ParamValue = CStr(Format(Date.Now.Date, "dd/MM/yyyy"))

    '            Dim T_CLines As ERPConnect.RFCTable = func.Tables("ZTABLA_APARTADO")
    '            For Each row As DataRow In dsDefectuosos.Tables("DefectuososD").Rows
    '                Dim R_CLines As ERPConnect.RFCStructure = T_CLines.AddRow()

    '                R_CLines("CENTRO") = strCentro
    '                R_CLines("CONTRATO") = strContrato
    '                R_CLines("MATNR") = row("CodArticulo")
    '                R_CLines("CANTIDAD") = row("Desmarcar")
    '                strMaterial = row("CodArticulo")
    '                strCantidad = row("Desmarcar")
    '                'If IsNumeric(row("Numero")) Then
    '                '    R_CLines("TALLA") = Format(CDec(row("Numero")), "##.0")
    '                '    strTalla = Format(CDec(row("Numero")), "##.0")
    '                'Else
    '                '    R_CLines("TALLA") = row("Numero")
    '                '    strTalla = row("Numero")
    '                'End If
    '            Next


    '            'Ejecutamos la RFC
    '            func.Execute()

    '            'Obtenemos el Resultado
    '            If func.Imports("DOCFI").ParamValue <> String.Empty Then 'me traigo los campos
    '                UpdateDesmarcado(strContrato, func.Imports("DOCFI").ParamValue)
    '            Else

    '                'MsgBox("TCODE.- " & objtabretReturn(1, 1) & Microsoft.VisualBasic.vbCrLf & "DYNAME.- " & objtabretReturn(1, 2) _
    '                '& Microsoft.VisualBasic.vbCrLf & "DYNUMB.- " & objtabretReturn(1, 3) & Microsoft.VisualBasic.vbCrLf & "MSGTYP.- " & objtabretReturn(1, 4) _
    '                '& Microsoft.VisualBasic.vbCrLf & "MSGSPRA.- " & objtabretReturn(1, 5) & Microsoft.VisualBasic.vbCrLf & "MSGID.- " & objtabretReturn(1, 6) _
    '                '& Microsoft.VisualBasic.vbCrLf & "MSGNR.- " & objtabretReturn(1, 7) & Microsoft.VisualBasic.vbCrLf & "MSGV1.- " & objtabretReturn(1, 8))

    '                MessageBox.Show("Error al Desmarcar en SAP. Producto .- " & _
    '                Microsoft.VisualBasic.vbCrLf & strMaterial, "Desmarcar Defectuosos", MessageBoxButtons.OK, MessageBoxIcon.Error)

    '                'Throw New ApplicationException(objtabretReturn(1, 3))

    '            End If

    '            R3.Close()


    '        End If

    '    Catch e1 As ERPConnect.RFCServerException
    '        Throw e1
    '    Catch e1 As ERPConnect.ERPException
    '        Throw e1
    '    End Try

    'End Sub


    Public Sub DesbloquearSAP(ByVal strContrato As String, ByVal dsDefectuosos As DataSet, Optional ByVal motivo As String = "0008")
        '----------------------------------------------------------------------------------
        ' JNAVA (16.02.2016): Adecuacion para Retail
        '----------------------------------------------------------------------------------
        Dim strMaterial, strCantidad As String

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
                'Call RFC function  Z_FM_COMMXMM_MOV_APARTADOS
                '*****************************************************
                ' Create a function object
                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("Z_FM_COMMXMM_MOV_APARTADOS")
                Dim CentroSAP As String = Me.oSapCentro.Read_Centros

                'Asigno valores
                func.Exports("I_CENTRO").ParamValue = CentroSAP.Trim
                func.Exports("I_ALMACEN").ParamValue = "M009"
                func.Exports("I_CONTRATO").ParamValue = ""
                func.Exports("I_BLOCK").ParamValue = ""
                func.Exports("I_DEFECTUOSO").ParamValue = "X"

                Dim T_CLines As ERPConnect.RFCTable = func.Tables("TABLA_APARTADO")
                For Each row As DataRow In dsDefectuosos.Tables("DefectuososD").Rows
                    Dim R_CLines As ERPConnect.RFCStructure = T_CLines.AddRow()
                    R_CLines("CENTRO") = CentroSAP
                    'R_CLines("CONTRATO") = strContrato
                    R_CLines("MATNR") = CStr(row("CodArticulo")).Trim
                    R_CLines("CANTIDAD") = CDec(row("Desmarcar"))
                    R_CLines("LGORT") = "M001"
                    strMaterial = CStr(row("CodArticulo")).TrimStart("0")
                Next

                'Ejecutamos la RFC
                func.Execute()
                R3.Close()

                'Obtenemos el Resultado
                Dim DocFi As String = CStr(func.Imports("O_MAT_DOC").ParamValue)
                If DocFi.Trim <> String.Empty Then 'me traigo los campos
                    UpdateDesmarcado(strContrato, DocFi)
                Else

                    '----------------------------------------------------------------------------------------
                    'JNAVA (15.03.2016): se obtiene mensaje de sap en caso de presentarse un error
                    '----------------------------------------------------------------------------------------
                    Dim dtReturn As DataTable = func.Tables("RETURN").ToADOTable
                    Dim strError As String = String.Empty
                    dtReturn = func.Tables("RETURN").ToADOTable
                    For Each oRow As DataRow In dtReturn.Rows
                        strError &= CStr(oRow!MESSAGE) & vbCrLf
                    Next

                    MessageBox.Show("Error al Desmarcar en SAP. Producto: " & vbCrLf & strMaterial & vbCrLf & vbCrLf & strError, "Desmarcar Defectuosos", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    '----------------------------------------------------------------------------------------
                End If

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

    End Sub


#End Region

#Region "Bloqueados de Baja Calidad"


    '--------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 16/05/2015: Devuelve los bloqueados de baja calidad que se realizaron al surtir por ecommerce o si hay
    '--------------------------------------------------------------------------------------------------------------------------
    Public Function GetBloqueadosECSiHay(ByVal CodArticulo As String) As DataTable
        Dim conexion As New SqlConnection(m_strConnectionString)
        Dim command As New SqlCommand("GetBloqueadosECSiHay", conexion)
        Dim adapter As SqlDataAdapter = Nothing
        Dim dtBloqueados As New DataTable
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@CodAlmacen", oParent.ApplicationContext.ApplicationConfiguration.Almacen)
            command.Parameters.Add("@CodArticulo", CodArticulo)
            adapter = New SqlDataAdapter(command)
            adapter.Fill(dtBloqueados)
            command.Dispose()
            conexion.Close()
        Catch sql As SqlException
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            Throw New ApplicationException("El registro no pudo ser actualizado debido a un error de base de datos.", sql)
        Catch ex As Exception
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            Throw New ApplicationException("El registro no pudo ser actualizado debido a un error de aplicación.", ex)
        End Try
        Return dtBloqueados
    End Function

#End Region

End Class
