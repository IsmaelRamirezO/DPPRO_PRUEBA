Imports System.Data.SqlClient

Public Class TomadeInventarioDataGateway

    Private oParent As TomadeInventarioManager

#Region "Constructors / Destructors"

    Public Sub New(ByVal Parent As TomadeInventarioManager)

        oParent = Parent

    End Sub

#End Region

#Region "Methods"

    Public Sub Insert(ByVal pTomaInventario As TomadeInventarioInfo)

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                                 DataStorageConfiguration.GetConnectionString)

        'Insertamos General
        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand

        Dim sccmdInsertDetail As SqlCommand
        sccmdInsertDetail = New SqlCommand

        With sccmdInsert
            .Connection = sccnnConnection
            .CommandText = "[TomadeInventarioINS]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Folio", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Output, False, CType(0, Byte), CType(0, Byte), "Folio", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Sucursal", System.Data.SqlDbType.VarChar, 3, "Sucursal"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaAuditoria", System.Data.SqlDbType.DateTime, 8, "FechaAuditoria"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Administrativo", System.Data.SqlDbType.VarChar, 20, "Administrativo"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Responsable", System.Data.SqlDbType.VarChar, 20, "Responsable"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Semana", System.Data.SqlDbType.VarChar, 50, "Semana"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TotalCodigos", System.Data.SqlDbType.Int, 4, "TotalCodigos"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Usuario", System.Data.SqlDbType.VarChar, 20, "Usuario"))
        End With

        With sccmdInsertDetail
            .Connection = sccnnConnection
            .CommandText = "[TomadeInventarioDetalleINS]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Folio", System.Data.SqlDbType.Int, 4, "Folio"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Codigo", System.Data.SqlDbType.VarChar, 25, "Codigo"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Talla", System.Data.SqlDbType.VarChar, 4, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "Talla", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Sistema", System.Data.SqlDbType.Int, 4, "Sistema"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fisico", System.Data.SqlDbType.Int, 4, "Fisico"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Diferencia", System.Data.SqlDbType.Int, 4, "Diferencia"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Tipo", System.Data.SqlDbType.VarChar, 8, "Tipo"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Movimientos", System.Data.SqlDbType.VarChar, 25, "Movimientos"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioDetalle", System.Data.SqlDbType.Int, 4, "FolioDetalle"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Observaciones", System.Data.SqlDbType.VarChar, 25, "Observaciones"))

        End With

        Try
            sccnnConnection.Open()
            'Insertamos Datos Generales
            With sccmdInsert
                'Assign Parameters Values
                .Parameters("@Folio").Value = 0
                .Parameters("@Sucursal").Value = pTomaInventario.Sucursal
                .Parameters("@FechaAuditoria").Value = pTomaInventario.FechaAuditoria
                .Parameters("@Administrativo").Value = pTomaInventario.Administrativo
                .Parameters("@Responsable").Value = pTomaInventario.Responsable
                .Parameters("@Semana").Value = pTomaInventario.Semana
                .Parameters("@TotalCodigos").Value = pTomaInventario.TotalCodigos
                .Parameters("@Usuario").Value = pTomaInventario.Usuario
                'Execute Command
                .ExecuteNonQuery()
                pTomaInventario.Folio = .Parameters("@Folio").Value
            End With

            'Insertamos Detalle
            With sccmdInsertDetail

                Dim dRow As DataRow

                For Each dRow In pTomaInventario.Detalle.Rows

                    .Parameters("@Folio").Value = pTomaInventario.Folio
                    .Parameters("@Codigo").Value = dRow!Codigo
                    .Parameters("@Talla").Value = dRow!Talla
                    .Parameters("@Sistema").Value = dRow!Sistema
                    .Parameters("@Fisico").Value = dRow!Fisico
                    .Parameters("@Diferencia").Value = dRow!Diferencia
                    .Parameters("@Tipo").Value = dRow!Tipo
                    .Parameters("@Movimientos").Value = dRow!Movimientos
                    .Parameters("@FolioDetalle").Value = dRow!FolioDetalle
                    .Parameters("@Observaciones").Value = dRow!Observaciones
                    .ExecuteNonQuery()

                Next

                dRow = Nothing

            End With

            pTomaInventario.ResetFlagNew()
            pTomaInventario.ResetFlagDirty()

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

    Public Sub LoadInto(ByVal intFolio As Integer, ByVal pTomaInventario As TomadeInventarioInfo)

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                         DataStorageConfiguration.GetConnectionString)

        Dim daTomaInventario As SqlDataAdapter
        Dim daTomaInventarioDetalle As SqlDataAdapter
        Dim dtTomaInventario As New DataTable

        'Obtenemos General
        Dim sccmdSelect As SqlCommand
        sccmdSelect = New SqlCommand

        Dim sccmdSelectDetail As SqlCommand
        sccmdSelectDetail = New SqlCommand

        With sccmdSelect
            .Connection = sccnnConnection
            .CommandText = "[TomadeInventarioSel]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Folio", System.Data.SqlDbType.Int, 4))
            .Parameters("@Folio").Value = intFolio
        End With

        With sccmdSelectDetail
            .Connection = sccnnConnection
            .CommandText = "[TomadeInventarioDetalleSel]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Folio", System.Data.SqlDbType.Int, 4))
            .Parameters("@Folio").Value = intFolio
        End With

        daTomaInventario = New SqlDataAdapter(sccmdSelect)
        daTomaInventarioDetalle = New SqlDataAdapter(sccmdSelectDetail)

        Try

            daTomaInventario.Fill(dtTomaInventario)
            If dtTomaInventario.Rows.Count > 0 Then

                With pTomaInventario
                    .Folio = dtTomaInventario.Rows(0).Item("Folio")
                    .Sucursal = dtTomaInventario.Rows(0).Item("Sucursal")
                    .FechaAuditoria = dtTomaInventario.Rows(0).Item("FechaAuditoria")
                    .Administrativo = dtTomaInventario.Rows(0).Item("Administrativo")
                    .Responsable = dtTomaInventario.Rows(0).Item("Responsable")
                    .Semana = dtTomaInventario.Rows(0).Item("Semana")
                    .TotalCodigos = dtTomaInventario.Rows(0).Item("TotalCodigos")
                    .Usuario = dtTomaInventario.Rows(0).Item("Usuario")
                    .ResetFlagNew()
                    .SetFlagDirty()
                End With

                pTomaInventario.Detalle.Dispose()
                pTomaInventario.Detalle = Nothing
                pTomaInventario.Detalle = New DataTable("Detalle")
                daTomaInventarioDetalle.Fill(pTomaInventario.Detalle)

            Else

                pTomaInventario.Folio = 0

            End If

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

        dtTomaInventario.Dispose()
        dtTomaInventario = Nothing

        daTomaInventario.Dispose()
        daTomaInventarioDetalle.Dispose()

        daTomaInventario = Nothing
        daTomaInventarioDetalle = Nothing

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

    End Sub

    Friend Function GetFolioTomaInventario() As Integer

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        Dim intFolio As Integer


        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[TomadeInventarioFolioSel]"
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

    Friend Function LoadStockTotal(ByVal CodAlmacen As String, _
                            ByVal CodArticulo As String, _
                                ByVal Talla As String) As Integer

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                GetConnectionString)

        Dim daTallas As SqlDataAdapter
        Dim sccmdSelect As SqlCommand
        Dim dsTallas As DataSet = New DataSet("Existencia")

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "SELECT Total FROM Existencias WHERE CodAlmacen='" & CodAlmacen & "' And " & _
                            "CodArticulo = '" & CodArticulo & "' And Numero = '" & Talla & "'"
            .CommandType = CommandType.Text

        End With

        daTallas = New SqlDataAdapter(sccmdSelect)

        Try

            sccnnConnection.Open()

            'Llenamos el Dataset
            daTallas.Fill(dsTallas)

            If (dsTallas.Tables(0).Rows.Count > 0) Then

                LoadStockTotal = dsTallas.Tables(0).Rows(0).Item(0)

            Else

                LoadStockTotal = 0

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


    Friend Function GetUserDescription(ByVal strUser As String) As String

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        Dim strUserDescription As String


        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "SELECT Name FROM Users WHERE SessionLoginName = '" & strUser & "'"
            .CommandType = System.Data.CommandType.Text

        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)
                scdrReader.Read()
                If (scdrReader.HasRows) Then
                    strUserDescription = scdrReader.GetString(0)
                Else
                    scdrReader.Close()
                    sccnnConnection.Close()
                    strUserDescription = String.Empty
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

        Return strUserDescription

    End Function

#End Region

End Class
