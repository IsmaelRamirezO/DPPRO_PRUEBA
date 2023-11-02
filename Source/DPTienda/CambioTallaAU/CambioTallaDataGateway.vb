Imports System.Data.SqlClient

Public Class CambioTallaDataGateway

    Private oParent As CambioTallaManager
    Private m_strConnectionString As String
    Private oCambioTalla As CambioTalla

#Region "Constructors / Destructors"

    Public Sub New(ByVal Parent As CambioTallaManager)

        oParent = Parent

        m_strConnectionString = oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString

        oCambioTalla = oParent.Create

    End Sub

#End Region

#Region "Methods"

    Public Function Insert(ByVal pCambioTalla As CambioTalla) As Integer

        Insert = 0

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand

        With sccmdInsert

            .Connection = sccnnConnection

            .CommandText = "[CambiosDeTallaIns]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.Int, 8, System.Data.ParameterDirection.Output, False, CType(0, Byte), CType(0, Byte), "CambioTallaID", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 3, "CodAlmacen"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar, 2, "CodCaja"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FacturaID", System.Data.SqlDbType.Int, 4, "FacturaID"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodArticuloAnt", System.Data.SqlDbType.VarChar, 20, "CodArticuloAnt"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@NumeroAnt", System.Data.SqlDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(5, Byte), CType(1, Byte), "NumeroAnt", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CantidadAnt", System.Data.SqlDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(9, Byte), CType(2, Byte), "CantidadAnt", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodArticuloNvo", System.Data.SqlDbType.VarChar, 20, "CodArticuloNvo"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@NumeroNvo", System.Data.SqlDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(5, Byte), CType(1, Byte), "NumeroNvo", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CantidadNvo", System.Data.SqlDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(9, Byte), CType(2, Byte), "CantidadNvo", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Usuario", System.Data.SqlDbType.VarChar, 12, "Usuario"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Output, False, CType(0, Byte), CType(0, Byte), "Fecha", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@StatusRegistro", System.Data.SqlDbType.Bit, 1, "StatusRegistro"))

        End With

        Try

            sccnnConnection.Open()

            With sccmdInsert
                'Assign Parameters Values
                .Parameters("@CodAlmacen").Value = pCambioTalla.CodAlmacen
                .Parameters("@CodCaja").Value = pCambioTalla.CodCaja
                .Parameters("@FacturaID").Value = pCambioTalla.Factura
                .Parameters("@CodArticuloAnt").Value = pCambioTalla.CodArticuloAnt
                .Parameters("@NumeroAnt").Value = pCambioTalla.NumeroAnt
                .Parameters("@CantidadAnt").Value = pCambioTalla.CantidadAnt
                .Parameters("@CodArticuloNvo").Value = pCambioTalla.CodArticuloNvo
                .Parameters("@NumeroNvo").Value = pCambioTalla.NumeroNvo
                .Parameters("@CantidadNvo").Value = pCambioTalla.CantidadNvo
                .Parameters("@Usuario").Value = pCambioTalla.Usuario
                .Parameters("@Fecha").Value = pCambioTalla.Fecha
                .Parameters("@StatusRegistro").Value = 1

                'Execute Command
                .ExecuteNonQuery()

                Insert = .Parameters("@ID").Value

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

    Public Sub InsertMoveInOut(ByVal CodTipoMov As Integer, _
                                ByVal TipoMovimiento As String, _
                                    ByVal Numero As Decimal, _
                                        ByVal pCambioTalla As CambioTalla)

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
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Numero", System.Data.SqlDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(5, Byte), CType(1, Byte), "", System.Data.DataRowVersion.Current, Nothing))
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
                .Parameters("@CodAlmacen").Value = pCambioTalla.Movimiento.CodAlmacenMov
                .Parameters("@Destino").Value = pCambioTalla.Movimiento.CodAlmacenMov
                .Parameters("@Folio").Value = pCambioTalla.Movimiento.Folio
                .Parameters("@FolioSAP").Value = "0"
                .Parameters("@CodArticulo").Value = pCambioTalla.Movimiento.CodArticulo
                .Parameters("@Descripcion").Value = pCambioTalla.Movimiento.Descripcion
                .Parameters("@Numero").Value = Numero
                .Parameters("@Total").Value = pCambioTalla.CantidadAnt
                .Parameters("@Apartados").Value = 0
                .Parameters("@Defectuosos").Value = 0
                .Parameters("@Promocion").Value = 0
                .Parameters("@VtasEspeciales").Value = 0
                .Parameters("@Consignacion").Value = 0
                .Parameters("@Transito").Value = 0
                .Parameters("@CodLinea").Value = pCambioTalla.Movimiento.CodLinea
                .Parameters("@CodMarca").Value = pCambioTalla.Movimiento.CodMarca
                .Parameters("@CodFamilia").Value = pCambioTalla.Movimiento.CodFamilia
                .Parameters("@CodUso").Value = Format(pCambioTalla.Movimiento.CodUso, "00000000")
                .Parameters("@CodCategoria").Value = Format(pCambioTalla.Movimiento.CodCategoria, "000")
                .Parameters("@CodUnidad").Value = pCambioTalla.Movimiento.CodUnidad
                .Parameters("@Usuario").Value = oParent.ApplicationContext.Security.CurrentUser.Name
                .Parameters("@CostoUnit").Value = pCambioTalla.Movimiento.CostoUnit
                .Parameters("@PrecioUnit").Value = pCambioTalla.Movimiento.PrecioUnit
                .Parameters("@FolioControl").Value = "" 'Folio al Iniciar Dia.
                .Parameters("@CodCaja").Value = pCambioTalla.Movimiento.CodCajaMov
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

    Public Sub Update(ByVal pCambioTalla As CambioTalla)

    End Sub

    Public Sub Delete(ByVal ID As Integer)

    End Sub

    Public Function SelectByID(ByVal ID As String) As CambioTalla

    End Function

    Public Function SelectAll(ByVal EnabledRecordsOnly As Boolean) As DataSet

    End Function

    Public Function LoadDataFactura(ByVal FolioFactura As Integer, ByVal CodCaja As String) As DataSet

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim daFactura As SqlDataAdapter
        Dim sccmdSelect As SqlCommand
        Dim dsFactura As DataSet = New DataSet("DetalleFactura")

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[CambiosDeTallaFacturaSel]"
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
                                    ByVal Talla As Decimal) As Integer

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim daTallas As SqlDataAdapter
        Dim sccmdSelect As SqlCommand
        Dim dsTallas As DataSet = New DataSet("Existencia")

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "SELECT Libre FROM Existencias WHERE CodAlmacen='" & CodAlmacen & "' And " & _
                            "CodArticulo = '" & CodArticulo & "' And Numero = " & Talla & ""
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

    Public Function LoadListFactura(ByVal EnabledRecordOnly As Boolean) As DataSet

        Dim oResult As DataSet
        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "Select FacturaID as ID, CodCaja As Caja,FolioFactura as Folio, CodVendedor As Vendedor, Fecha, StatusRegistro As Habilitado " & _
                                "From Factura Order By CodCaja, FolioFactura"
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
            .CommandText = "Select FolioFactura, CodCaja From Factura Where FacturaID = " & FacturaID & ""
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


#End Region

#Region "Cambios de Talla DPVales"

    Public Function SaveCambiosTallaDPVale(ByVal CambioTalla As CambioTallaDPVale) As Boolean
        Dim valido As Boolean = False
        Dim conexion As New SqlConnection(m_strConnectionString)
        Dim command As New SqlCommand("SaveCambioTallaDPVale", conexion)
        Dim CambioTallaDPValeId As New SqlParameter("@CambiosTallaDPValeId", SqlDbType.Int)
        CambioTallaDPValeId.Direction = ParameterDirection.InputOutput
        CambioTallaDPValeId.Value = CambioTalla.CambiosTallasDPValeId
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(CambioTallaDPValeId)
            command.Parameters.AddWithValue("@RefOrigen", CambioTalla.RefOrigen)
            command.Parameters.AddWithValue("@RefPadre", CambioTalla.RefPadre)
            command.Parameters.AddWithValue("@RefGenerada", CambioTalla.RefGenerada)
            command.Parameters.AddWithValue("@ValeId", CambioTalla.ValeId)
            command.Parameters.AddWithValue("@Consecutivo", CambioTalla.Consecutivo)
            command.ExecuteNonQuery()
            If CambioTalla.CambiosTallasDPValeId = 0 Then
                CambioTalla.CambiosTallasDPValeId = CInt(CambioTallaDPValeId.Value)
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

    Public Sub LoadCambioTallaDPVale(ByVal CambioTalla As CambioTallaDPVale)
        Dim conexion As New SqlConnection(m_strConnectionString)
        Dim command As New SqlCommand("GetCambiosTallaDPValeById", conexion)
        Dim reader As SqlDataReader = Nothing
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.AddWithValue("@CambiosTallaDPValeId", CambioTalla.CambiosTallasDPValeId)
            reader = command.ExecuteReader()
            If reader.HasRows Then
                While reader.Read()
                    CambioTalla.CambiosTallasDPValeId = CInt(reader("CambiosTallaDPValeId"))
                    CambioTalla.RefOrigen = CStr(reader("RefOrigen"))
                    CambioTalla.RefPadre = CStr(reader("RefPadre"))
                    CambioTalla.RefGenerada = CStr(reader("RefGenerada"))
                    CambioTalla.ValeId = CStr(reader("ValeId"))
                    CambioTalla.Consecutivo = CStr(reader("Consecutivo"))
                    CambioTalla.Fecha = CDate(reader("Fecha"))
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

    Public Function GetCambiosTallaDPValeByRefOrigen(ByVal RefOrigen As String) As DataTable
        Dim conexion As New SqlConnection(m_strConnectionString)
        Dim command As New SqlCommand("GetCambiosTallaDPValeByReferencia", conexion)
        Dim adapter As SqlDataAdapter = Nothing
        Dim dtCambiosTallas As New DataTable()
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.AddWithValue("@RefOrigen", RefOrigen)
            adapter = New SqlDataAdapter(command)
            adapter.Fill(dtCambiosTallas)
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
        Return dtCambiosTallas
    End Function

    Public Function GetCambiosTallaByValeId(ByVal ValeId As String) As DataTable
        Dim dtCambiosTalla As New DataTable()
        Dim conexion As New SqlConnection(m_strConnectionString)
        Dim command As New SqlCommand("GetCambiosTallaByValeId", conexion)
        Dim adapter As SqlDataAdapter = Nothing
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.AddWithValue("@ValeId", ValeId)
            adapter = New SqlDataAdapter(command)
            adapter.Fill(dtCambiosTalla)
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
        Return dtCambiosTalla
    End Function

#End Region

End Class
