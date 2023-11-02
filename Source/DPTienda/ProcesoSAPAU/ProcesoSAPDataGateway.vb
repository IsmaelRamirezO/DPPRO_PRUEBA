Imports System.Data.SqlClient
Imports DportenisPro.DPTienda.Core

Friend Class ProcesoSAPDataGateway

    Private oParent As ProcesoSAPManager
    Private m_strConnectionString As String = String.Empty

#Region "Constructors / Destructors"

    Public Sub New(ByVal Parent As ProcesoSAPManager)

        oParent = Parent
        m_strConnectionString = oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString

    End Sub

#End Region

#Region "Vendedores"

    Public Sub InsertVendedor(ByVal strCodVendedor As String, ByVal strNombre As String)

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand

        With sccmdInsert

            .Connection = sccnnConnection

            .CommandText = "[CatalogoVendedoresIns]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Connection = sccnnConnection

            '----------------------------------------------------------------------
            ' JNAVA (07.01.2016): Cambiamos CodVendedor a 12 el tamaño del campo
            '----------------------------------------------------------------------
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodVendedor", System.Data.SqlDbType.VarChar, 12))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Nombre", System.Data.SqlDbType.VarChar, 50))

        End With

        Try

            sccnnConnection.Open()

            With sccmdInsert

                'Assign Parameters Values
                .Parameters("@CodVendedor").Value = strCodVendedor
                .Parameters("@Nombre").Value = strNombre

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

#Region "Articulos"

    Friend Sub InsertarArticulos(ByVal pAticulosSAP As ArticulosSAP)

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)
        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand
        With sccmdInsert
            .Connection = sccnnConnection
            .CommandText = "[ArticulosSAPIns]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodArticulo", System.Data.SqlDbType.VarChar, 20, "CodArticulo"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodArtProv", System.Data.SqlDbType.VarChar, 20, "CodArtProv"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Descripcion", System.Data.SqlDbType.VarChar, 50, "Descripcion"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodLinea", System.Data.SqlDbType.VarChar, 3, "CodLinea"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCorrida", System.Data.SqlDbType.VarChar, 3, "CodCorrida"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCategoria", System.Data.SqlDbType.VarChar, 3, "CodCategoria"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodFamilia", System.Data.SqlDbType.VarChar, 2, "CodFamilia"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodUso", System.Data.SqlDbType.VarChar, 8, "CodUso"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CostoProm", System.Data.SqlDbType.Money, 8, "CostoProm"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodUnidadCom", System.Data.SqlDbType.VarChar, 3, "CodUnidadCom"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodUnidadVta", System.Data.SqlDbType.VarChar, 3, "CodUnidadVta"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Jerarquia", System.Data.SqlDbType.VarChar, 18, "Jerarquia"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodigoAnterior", System.Data.SqlDbType.VarChar, 20, "CodigoAnterior"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Dips", System.Data.SqlDbType.Bit, 1, "DIP"))
        End With
        Try
            sccnnConnection.Open()
            With sccmdInsert
                'Assign Parameters Values
                .Parameters("@CodArticulo").Value = pAticulosSAP.Codarticulo
                .Parameters("@CodArtProv").Value = pAticulosSAP.Codartprov
                .Parameters("@Descripcion").Value = pAticulosSAP.Descripcion
                .Parameters("@CodLinea").Value = pAticulosSAP.Codlinea
                .Parameters("@CodCorrida").Value = pAticulosSAP.Codcorrida
                .Parameters("@CodCategoria").Value = pAticulosSAP.Codcategoria
                .Parameters("@CodFamilia").Value = pAticulosSAP.Codfamilia
                .Parameters("@CodUso").Value = pAticulosSAP.CodUso
                .Parameters("@CostoProm").Value = pAticulosSAP.Costopromedio
                .Parameters("@CodUnidadCom").Value = pAticulosSAP.Codunidadcom
                .Parameters("@CodUnidadVta").Value = pAticulosSAP.Codunidadvta
                .Parameters("@Jerarquia").Value = pAticulosSAP.Jerarquia
                .Parameters("@CodigoAnterior").Value = pAticulosSAP.CodigoAnterior
                .Parameters("@Dips").Value = pAticulosSAP.Dip
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
            'Throw New ApplicationException(oSqlException.Message, oSqlException)
            Throw New ApplicationException("El registro no pudo ser leido debido a un error de base de datos.", oSqlException)
        Catch ex As Exception
            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If
            'Throw New ApplicationException(ex.Message, ex)
            Throw New ApplicationException("El registro no pudo ser leido debido a un error de sistema.", ex)
        End Try
        sccnnConnection.Dispose()
        sccnnConnection = Nothing
    End Sub

    Friend Sub LoadDataFromSAPtoDB(ByVal strFile As String, ByVal Descarga As Integer)
        Dim sccnnConnection As New SqlConnection(m_strConnectionString)
        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand
        With sccmdInsert
            .Connection = sccnnConnection
            .CommandText = "[DescargaSAPBulk]"
            .CommandTimeout = oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration.ConnectionTimeout
            .CommandType = System.Data.CommandType.StoredProcedure
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ruta", System.Data.SqlDbType.VarChar, 255, "ruta"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@tabla", System.Data.SqlDbType.VarChar, 50, "Nombre tabla"))
        End With
        Try
            sccnnConnection.Open()
            With sccmdInsert
                'Assign Parameters Values
                .Parameters("@ruta").Value = strFile
                .Parameters("@tabla").Value = "DescargaSAPTemp"
                .ExecuteNonQuery()
            End With
            sccnnConnection.Close()

            ActualizaDatosFromSAP(Descarga)

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

    Friend Sub ActualizaDatosFromSAP(ByVal Descarga As Integer)
        Dim sccnnConnection As New SqlConnection(m_strConnectionString)
        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand
        sccmdInsert.CommandTimeout = oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration.ConnectionTimeout
        With sccmdInsert
            .Connection = sccnnConnection
            .CommandTimeout = oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration.ConnectionTimeout
            .CommandText = "[DescargaSAPInsUpMasivo]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Descarga", System.Data.SqlDbType.Int, 4, "Descarga"))
        End With
        Try
            sccnnConnection.Open()
            With sccmdInsert
                'Assign Parameters Values
                .Parameters("@Descarga").Value = Descarga
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

    Friend Sub ActualizaArticulosPrecioVta(ByVal strcodigoarticulo As String, ByVal dblprecioventa As Double)
        Dim sccnnConnection As New SqlConnection(m_strConnectionString)
        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand
        With sccmdInsert
            .Connection = sccnnConnection
            .CommandText = "[ArticulosPrecioVentaUpd]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodArticulo", System.Data.SqlDbType.VarChar, 20, "CodArticulo"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@PrecioVenta", System.Data.SqlDbType.Money, 8, "CostoProm"))
        End With
        Try
            sccnnConnection.Open()
            With sccmdInsert
                'Assign Parameters Values
                .Parameters("@CodArticulo").Value = strcodigoarticulo
                .Parameters("@PrecioVenta").Value = dblprecioventa
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

    Friend Sub ActualizaArticulosPrecioConIVA(ByVal strcodigoarticulo As String, ByVal dblprecioiva As Double)
        Dim sccnnConnection As New SqlConnection(m_strConnectionString)
        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand
        With sccmdInsert
            .Connection = sccnnConnection
            .CommandText = "[ArticulosPrecioConIVAUpd]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodArticulo", System.Data.SqlDbType.VarChar, 20, "CodArticulo"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@PrecioIva", System.Data.SqlDbType.Money, 8, "CostoProm"))
        End With
        Try
            sccnnConnection.Open()
            With sccmdInsert
                'Assign Parameters Values
                .Parameters("@CodArticulo").Value = strcodigoarticulo
                .Parameters("@PrecioIva").Value = dblprecioiva
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

    Friend Sub InsertarExistencias(ByVal oRow As DataRow)

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)
        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand
        With sccmdInsert
            .Connection = sccnnConnection
            .CommandText = "[ExistenciasSAPIns]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 4, "CodAlmacen"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodArticulo", System.Data.SqlDbType.VarChar, 20, "CodArticulo"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Numero", System.Data.SqlDbType.VarChar, 4, "Numero"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Total", System.Data.SqlDbType.Decimal, 9, "Total"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Defectuosos", System.Data.SqlDbType.Decimal, 9, "Defectuosos"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Usuario", System.Data.SqlDbType.VarChar, 12, "Usuario"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Costo", System.Data.SqlDbType.Money, 8, "Costo"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodLinea", System.Data.SqlDbType.VarChar, 3, "CodLinea"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCategoria", System.Data.SqlDbType.VarChar, 3, "CodCategoria"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodFamilia", System.Data.SqlDbType.VarChar, 2, "CodFamilia"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodUso", System.Data.SqlDbType.VarChar, 8, "CodUso"))


        End With
        Try
            sccnnConnection.Open()

            'oRow("CODARTICULO") = CStr(objtabret(iRen, "MATNR"))
            'oRow("NUMERO") = CStr(objtabret(iRen, "J_3ASIZE"))
            'oRow("TOTAL") = CDec(objtabret(iRen, "CLABS"))
            'oRow("DEFECTUOSOS") = CDec(objtabret(iRen, "CSPEM"))
            'oRow("DEFECDEV") = CDec(objtabret(iRen, "CRETM"))
            'oRow("COSTO") = CDec(objtabret(iRen, "STPRS"))
            'oRow("CODUSO") = Mid(CStr(objtabret(iRen, "PRDHA")), 11, 8)
            'oRow("CODLINEA") = Mid(CStr(objtabret(iRen, "PRDHA")), 5, 3)
            'oRow("CODFAMILIA") = Mid(CStr(objtabret(iRen, "PRDHA")), 3, 2)
            'oRow("CODCATEGORIA") = Mid(CStr(objtabret(iRen, "PRDHA")), 8, 3)
            'oRow("UPC") = CStr(objtabret(iRen, "EAN11"))

            With sccmdInsert
                'Assign Parameters Values
                Dim strNumero As String
                If IsNumeric(oRow!J_3ASIZE) Then
                    'es un valor Numerico
                    If InStr(CStr(oRow!J_3ASIZE), ".5") = 0 Then
                        'La formato para que quede si es 26.0  --> 26
                        strNumero = Format(CDec(oRow!J_3ASIZE), "###0")
                    Else
                        'Se queda Igual es .5
                        strNumero = oRow!J_3ASIZE
                    End If
                Else
                    'Es un Numero  XXL L M S
                    strNumero = oRow!J_3ASIZE
                End If
                .Parameters("@CodAlmacen").Value = oParent.ApplicationContext.ApplicationConfiguration.Almacen
                .Parameters("@CodArticulo").Value = oRow!MATNR
                .Parameters("@Numero").Value = strNumero
                .Parameters("@Total").Value = CDec(oRow!CLABS) + (CDec(oRow!CSPEM))
                .Parameters("@Defectuosos").Value = CDec(oRow!CSPEM)
                .Parameters("@Usuario").Value = oParent.ApplicationContext.Security.CurrentUser.SessionLoginName
                .Parameters("@Costo").Value = oRow!STPRS
                .Parameters("@CodLinea").Value = Mid(CStr(oRow!PRDHA), 5, 5)
                .Parameters("@CodCategoria").Value = Mid(CStr(oRow!PRDHA), 8, 3)
                .Parameters("@CodFamilia").Value = Mid(CStr(oRow!PRDHA), 3, 2)
                .Parameters("@CodUso").Value = Mid(CStr(oRow!PRDHA), 11, 8)
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

    'Friend Sub InsertarDescuentosAdicionales(ByVal oRow As DataRow)

    '    Dim sccnnConnection As New SqlConnection(m_strConnectionString)
    '    Dim sccmdInsert As SqlCommand
    '    sccmdInsert = New SqlCommand
    '    With sccmdInsert
    '        .Connection = sccnnConnection
    '        .CommandText = "[DescuentosAdicionalesIns]"
    '        .CommandType = System.Data.CommandType.StoredProcedure

    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodArticulo", System.Data.SqlDbType.VarChar, 20, "CodArticulo"))
    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Descuento", System.Data.SqlDbType.Decimal, 9, "Descuento"))
    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaIni", System.Data.SqlDbType.DateTime, 8, "FechaIni"))
    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaFin", System.Data.SqlDbType.DateTime, 8, "FechaFin"))
    '        .Parameters.Add(New SqlParameter("@PG", SqlDbType.Bit, 1, "Publico General"))
    '        .Parameters.Add(New SqlParameter("@V", SqlDbType.Bit, 1, "DPVale"))
    '        .Parameters.Add(New SqlParameter("@I", SqlDbType.Bit, 1, "Fact. Fiscal"))
    '        .Parameters.Add(New SqlParameter("@O", SqlDbType.Bit, 1, "Facilito"))
    '        .Parameters.Add(New SqlParameter("@F", SqlDbType.Bit, 1, "Fonacot"))
    '        .Parameters.Add(New SqlParameter("@K", SqlDbType.Bit, 1, "Tarjeta Fonacot"))
    '        .Parameters.Add(New SqlParameter("@S", SqlDbType.Bit, 1, "Socios"))
    '        .Parameters.Add(New SqlParameter("@D", SqlDbType.Bit, 1, "Dips"))

    '    End With
    '    Try
    '        sccnnConnection.Open()

    '        With sccmdInsert
    '            'Assign Parameters Values
    '            .Parameters("@CodArticulo").Value = oRow!MATERIAL
    '            .Parameters("@Descuento").Value = oRow!DESCUENTO
    '            If CStr(oRow!FECHASAPI) = "" Then
    '                .Parameters("@FechaIni").Value = Date.Today
    '            Else
    '                .Parameters("@FechaIni").Value = CDate(CStr(oRow!FECHASAPI).Substring(6) & "/" & CStr(oRow!FECHASAPI).Substring(4, 2) & "/" & CStr(oRow!FECHASAPI).Substring(0, 4))
    '            End If
    '            If CStr(oRow!FECHASAPF) = "" Then
    '                .Parameters("@FechaFin").Value = Date.Today
    '            Else
    '                .Parameters("@FechaFin").Value = CDate(CStr(oRow!FECHASAPF).Substring(6) & "/" & CStr(oRow!FECHASAPF).Substring(4, 2) & "/" & CStr(oRow!FECHASAPF).Substring(0, 4))
    '            End If
    '            .Parameters("@PG").Value = IIf(CStr(oRow!P).Trim = "X", True, False)
    '            .Parameters("@V").Value = IIf(CStr(oRow!V).Trim = "X", True, False)
    '            .Parameters("@I").Value = IIf(CStr(oRow!I).Trim = "X", True, False)
    '            .Parameters("@O").Value = IIf(CStr(oRow!O).Trim = "X", True, False)
    '            .Parameters("@F").Value = IIf(CStr(oRow!F).Trim = "X", True, False)
    '            .Parameters("@K").Value = IIf(CStr(oRow!K).Trim = "X", True, False)
    '            .Parameters("@S").Value = IIf(CStr(oRow!S).Trim = "X", True, False)
    '            .Parameters("@D").Value = IIf(CStr(oRow!D).Trim = "X", True, False)
    '            .ExecuteNonQuery()

    '        End With
    '        sccnnConnection.Close()

    '    Catch oSqlException As SqlException
    '        If (sccnnConnection.State <> ConnectionState.Closed) Then
    '            Try
    '                sccnnConnection.Close()
    '            Catch
    '            End Try
    '        End If
    '        Throw New ApplicationException(oSqlException.Message, oSqlException)
    '    Catch ex As Exception
    '        If (sccnnConnection.State <> ConnectionState.Closed) Then
    '            Try
    '                sccnnConnection.Close()
    '            Catch
    '            End Try
    '        End If
    '        Throw New ApplicationException(ex.Message, ex)
    '    End Try
    '    sccnnConnection.Dispose()
    '    sccnnConnection = Nothing
    'End Sub

    'Friend Sub InsertarDescuentosAdicionalesPorMarca(ByVal oRow As DataRow)

    '    Dim sccnnConnection As New SqlConnection(m_strConnectionString)
    '    Dim sccmdInsert As SqlCommand
    '    sccmdInsert = New SqlCommand
    '    With sccmdInsert
    '        .Connection = sccnnConnection
    '        .CommandText = "[DescuentosAdicionalesInsPorMarca]"
    '        .CommandType = System.Data.CommandType.StoredProcedure

    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodMarca", System.Data.SqlDbType.VarChar, 2, "CodMarca"))
    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Descuento", System.Data.SqlDbType.Decimal, 9, "Descuento"))
    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaIni", System.Data.SqlDbType.DateTime, 8, "FechaIni"))
    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaFin", System.Data.SqlDbType.DateTime, 8, "FechaFin"))
    '        .Parameters.Add(New SqlParameter("@PG", SqlDbType.Bit, 1, "Publico General"))
    '        .Parameters.Add(New SqlParameter("@V", SqlDbType.Bit, 1, "DPVale"))
    '        .Parameters.Add(New SqlParameter("@I", SqlDbType.Bit, 1, "Fact. Fiscal"))
    '        .Parameters.Add(New SqlParameter("@O", SqlDbType.Bit, 1, "Facilito"))
    '        .Parameters.Add(New SqlParameter("@F", SqlDbType.Bit, 1, "Fonacot"))
    '        .Parameters.Add(New SqlParameter("@K", SqlDbType.Bit, 1, "Tarjeta Fonacot"))
    '        .Parameters.Add(New SqlParameter("@S", SqlDbType.Bit, 1, "Socios"))
    '        .Parameters.Add(New SqlParameter("@D", SqlDbType.Bit, 1, "Dips"))

    '    End With
    '    Try
    '        sccnnConnection.Open()

    '        With sccmdInsert
    '            'Assign Parameters Values
    '            .Parameters("@CodMarca").Value = oRow!MARCA
    '            .Parameters("@Descuento").Value = oRow!DESCUENTO
    '            If CStr(oRow!FECHASAPI) = "" Then
    '                .Parameters("@FechaIni").Value = Date.Today
    '            Else
    '                .Parameters("@FechaIni").Value = CDate(CStr(oRow!FECHASAPI).Substring(6) & "/" & CStr(oRow!FECHASAPI).Substring(4, 2) & "/" & CStr(oRow!FECHASAPI).Substring(0, 4))
    '            End If
    '            If CStr(oRow!FECHASAPF) = "" Then
    '                .Parameters("@FechaFin").Value = Date.Today
    '            Else
    '                .Parameters("@FechaFin").Value = CDate(CStr(oRow!FECHASAPF).Substring(6) & "/" & CStr(oRow!FECHASAPF).Substring(4, 2) & "/" & CStr(oRow!FECHASAPF).Substring(0, 4))
    '            End If
    '            .Parameters("@PG").Value = IIf(CStr(oRow!P).Trim = "X", True, False)
    '            .Parameters("@V").Value = IIf(CStr(oRow!V).Trim = "X", True, False)
    '            .Parameters("@I").Value = IIf(CStr(oRow!I).Trim = "X", True, False)
    '            .Parameters("@O").Value = IIf(CStr(oRow!O).Trim = "X", True, False)
    '            .Parameters("@F").Value = IIf(CStr(oRow!F).Trim = "X", True, False)
    '            .Parameters("@K").Value = IIf(CStr(oRow!K).Trim = "X", True, False)
    '            .Parameters("@S").Value = IIf(CStr(oRow!S).Trim = "X", True, False)
    '            .Parameters("@D").Value = IIf(CStr(oRow!D).Trim = "X", True, False)
    '            .ExecuteNonQuery()

    '        End With
    '        sccnnConnection.Close()

    '    Catch oSqlException As SqlException
    '        If (sccnnConnection.State <> ConnectionState.Closed) Then
    '            Try
    '                sccnnConnection.Close()
    '            Catch
    '            End Try
    '        End If
    '        Throw New ApplicationException(oSqlException.Message, oSqlException)
    '    Catch ex As Exception
    '        If (sccnnConnection.State <> ConnectionState.Closed) Then
    '            Try
    '                sccnnConnection.Close()
    '            Catch
    '            End Try
    '        End If
    '        Throw New ApplicationException(ex.Message, ex)
    '    End Try
    '    sccnnConnection.Dispose()
    '    sccnnConnection = Nothing
    'End Sub

    'Friend Sub InsertarDescuentosAdicionalesGeneral(ByVal oRow As DataRow)

    '    Dim sccnnConnection As New SqlConnection(m_strConnectionString)
    '    Dim sccmdInsert As SqlCommand
    '    sccmdInsert = New SqlCommand
    '    With sccmdInsert
    '        .Connection = sccnnConnection
    '        .CommandText = "[DescuentosAdicionalesInsPorMarca]"
    '        .CommandType = System.Data.CommandType.StoredProcedure

    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodMarca", System.Data.SqlDbType.VarChar, 2, "CodMarca"))
    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Descuento", System.Data.SqlDbType.Decimal, 9, "Descuento"))
    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaIni", System.Data.SqlDbType.DateTime, 8, "FechaIni"))
    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaFin", System.Data.SqlDbType.DateTime, 8, "FechaFin"))
    '        .Parameters.Add(New SqlParameter("@PG", SqlDbType.Bit, 1, "Publico General"))
    '        .Parameters.Add(New SqlParameter("@V", SqlDbType.Bit, 1, "DPVale"))
    '        .Parameters.Add(New SqlParameter("@I", SqlDbType.Bit, 1, "Fact. Fiscal"))
    '        .Parameters.Add(New SqlParameter("@O", SqlDbType.Bit, 1, "Facilito"))
    '        .Parameters.Add(New SqlParameter("@F", SqlDbType.Bit, 1, "Fonacot"))
    '        .Parameters.Add(New SqlParameter("@K", SqlDbType.Bit, 1, "Tarjeta Fonacot"))
    '        .Parameters.Add(New SqlParameter("@S", SqlDbType.Bit, 1, "Socios"))
    '        .Parameters.Add(New SqlParameter("@D", SqlDbType.Bit, 1, "Dips"))

    '    End With
    '    Try
    '        sccnnConnection.Open()

    '        With sccmdInsert
    '            'Assign Parameters Values
    '            .Parameters("@CodMarca").Value = "@@"
    '            .Parameters("@Descuento").Value = oRow!DESCUENTO
    '            If CStr(oRow!FECHASAPI) = "" Then
    '                .Parameters("@FechaIni").Value = Date.Today
    '            Else
    '                .Parameters("@FechaIni").Value = CDate(CStr(oRow!FECHASAPI).Substring(6) & "/" & CStr(oRow!FECHASAPI).Substring(4, 2) & "/" & CStr(oRow!FECHASAPI).Substring(0, 4))
    '            End If
    '            If CStr(oRow!FECHASAPF) = "" Then
    '                .Parameters("@FechaFin").Value = Date.Today
    '            Else
    '                .Parameters("@FechaFin").Value = CDate(CStr(oRow!FECHASAPF).Substring(6) & "/" & CStr(oRow!FECHASAPF).Substring(4, 2) & "/" & CStr(oRow!FECHASAPF).Substring(0, 4))
    '            End If
    '            .Parameters("@PG").Value = IIf(CStr(oRow!P).Trim = "X", True, False)
    '            .Parameters("@V").Value = IIf(CStr(oRow!V).Trim = "X", True, False)
    '            .Parameters("@I").Value = IIf(CStr(oRow!I).Trim = "X", True, False)
    '            .Parameters("@O").Value = IIf(CStr(oRow!O).Trim = "X", True, False)
    '            .Parameters("@F").Value = IIf(CStr(oRow!F).Trim = "X", True, False)
    '            .Parameters("@K").Value = IIf(CStr(oRow!K).Trim = "X", True, False)
    '            .Parameters("@S").Value = IIf(CStr(oRow!S).Trim = "X", True, False)
    '            .Parameters("@D").Value = IIf(CStr(oRow!D).Trim = "X", True, False)
    '            .ExecuteNonQuery()

    '        End With
    '        sccnnConnection.Close()

    '    Catch oSqlException As SqlException
    '        If (sccnnConnection.State <> ConnectionState.Closed) Then
    '            Try
    '                sccnnConnection.Close()
    '            Catch
    '            End Try
    '        End If
    '        Throw New ApplicationException(oSqlException.Message, oSqlException)
    '    Catch ex As Exception
    '        If (sccnnConnection.State <> ConnectionState.Closed) Then
    '            Try
    '                sccnnConnection.Close()
    '            Catch
    '            End Try
    '        End If
    '        Throw New ApplicationException(ex.Message, ex)
    '    End Try
    '    sccnnConnection.Dispose()
    '    sccnnConnection = Nothing
    'End Sub

    Friend Sub InsertarDescuentosAdicionalesPorMarca(ByVal oRow As DataRow)

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)
        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand
        Dim parameter As New SqlParameter("@DescuentoId", SqlDbType.Int)
        parameter.Direction = ParameterDirection.Output
        With sccmdInsert
            .Connection = sccnnConnection
            .CommandText = "[DescuentosAdicionalesInsPorMarca]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodMarca", System.Data.SqlDbType.VarChar, 2, "CodMarca"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Descuento", System.Data.SqlDbType.Decimal, 9, "Descuento"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaIni", System.Data.SqlDbType.DateTime, 8, "FechaIni"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaFin", System.Data.SqlDbType.DateTime, 8, "FechaFin"))
            .Parameters.Add(New SqlParameter("@PG", SqlDbType.Bit, 1, "Publico General"))
            .Parameters.Add(New SqlParameter("@V", SqlDbType.Bit, 1, "DPVale"))
            .Parameters.Add(New SqlParameter("@I", SqlDbType.Bit, 1, "Fact. Fiscal"))
            .Parameters.Add(New SqlParameter("@O", SqlDbType.Bit, 1, "Facilito"))
            .Parameters.Add(New SqlParameter("@F", SqlDbType.Bit, 1, "Fonacot"))
            .Parameters.Add(New SqlParameter("@K", SqlDbType.Bit, 1, "Tarjeta Fonacot"))
            .Parameters.Add(New SqlParameter("@S", SqlDbType.Bit, 1, "Socios"))
            .Parameters.Add(New SqlParameter("@D", SqlDbType.Bit, 1, "Dips"))
            .Parameters.Add(parameter)
        End With
        Try
            sccnnConnection.Open()

            With sccmdInsert
                'Assign Parameters Values
                .Parameters("@CodMarca").Value = oRow!MARCA
                .Parameters("@Descuento").Value = oRow!DESCUENTO
                If CStr(oRow!FECHASAPI) = "" Then
                    .Parameters("@FechaIni").Value = Date.Today
                Else
                    .Parameters("@FechaIni").Value = CDate(CStr(oRow!FECHASAPI).Substring(6) & "/" & CStr(oRow!FECHASAPI).Substring(4, 2) & "/" & CStr(oRow!FECHASAPI).Substring(0, 4))
                End If
                If CStr(oRow!FECHASAPF) = "" Then
                    .Parameters("@FechaFin").Value = Date.Today
                Else
                    .Parameters("@FechaFin").Value = CDate(CStr(oRow!FECHASAPF).Substring(6) & "/" & CStr(oRow!FECHASAPF).Substring(4, 2) & "/" & CStr(oRow!FECHASAPF).Substring(0, 4))
                End If
                .Parameters("@PG").Value = IIf(CStr(oRow!P).Trim = "X", True, False)
                .Parameters("@V").Value = IIf(CStr(oRow!V).Trim = "X", True, False)
                .Parameters("@I").Value = IIf(CStr(oRow!I).Trim = "X", True, False)
                .Parameters("@O").Value = IIf(CStr(oRow!O).Trim = "X", True, False)
                .Parameters("@F").Value = IIf(CStr(oRow!F).Trim = "X", True, False)
                .Parameters("@K").Value = IIf(CStr(oRow!K).Trim = "X", True, False)
                .Parameters("@S").Value = IIf(CStr(oRow!S).Trim = "X", True, False)
                .Parameters("@D").Value = IIf(CStr(oRow!D).Trim = "X", True, False)
                .ExecuteNonQuery()

            End With
            If Not IsDBNull(parameter.Value) AndAlso oRow.Table.Columns.IndexOf("FPAGOS") >= 0 Then
                Dim descuentoid As Integer = 0
                descuentoid = CInt(parameter.Value)
                sccmdInsert.Dispose()
                Dim ts As SqlTransaction = Nothing
                Try
                    ts = sccnnConnection.BeginTransaction()
                    sccmdInsert.Transaction = ts
                    sccmdInsert.Parameters.Clear()
                    sccmdInsert.CommandText = "INSERT INTO DescuentosFormasPago(DescuentoAdicionalID,CodFormaPago)VALUES(@DescuentoAdicionalID,@CodFormaPago)"
                    sccmdInsert.CommandType = CommandType.Text
                    sccmdInsert.Parameters.Add(New SqlParameter("@DescuentoAdicionalID", SqlDbType.Int))
                    sccmdInsert.Parameters.Add(New SqlParameter("@CodFormaPago", SqlDbType.VarChar))
                    Dim pagos() As String = CStr(oRow!FPAGOS).Split(",")
                    For Each fila As String In pagos
                        If Not fila Is Nothing AndAlso fila.Trim <> "" Then
                            sccmdInsert.Parameters("@DescuentoAdicionalID").Value = descuentoid
                            sccmdInsert.Parameters("@CodFormaPago").Value = fila
                            sccmdInsert.ExecuteNonQuery()
                        End If
                    Next
                    ts.Commit()
                Catch sql As Exception
                    If sccnnConnection.State <> ConnectionState.Closed Then
                        ts.Rollback()
                        sccnnConnection.Close()
                    End If
                    Throw New ApplicationException(sql.Message, sql)
                End Try
            End If
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

    Friend Sub InsertarDescuentosAdicionales(ByVal oRow As DataRow)

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)
        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand
        Dim parameter As New SqlParameter("@DescuentoID", SqlDbType.Int)
        parameter.Direction = ParameterDirection.Output
        With sccmdInsert
            .Connection = sccnnConnection
            .CommandText = "[DescuentosAdicionalesIns]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodArticulo", System.Data.SqlDbType.VarChar, 20, "CodArticulo"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Descuento", System.Data.SqlDbType.Decimal, 9, "Descuento"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaIni", System.Data.SqlDbType.DateTime, 8, "FechaIni"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaFin", System.Data.SqlDbType.DateTime, 8, "FechaFin"))
            .Parameters.Add(New SqlParameter("@PG", SqlDbType.Bit, 1, "Publico General"))
            .Parameters.Add(New SqlParameter("@V", SqlDbType.Bit, 1, "DPVale"))
            .Parameters.Add(New SqlParameter("@I", SqlDbType.Bit, 1, "Fact. Fiscal"))
            .Parameters.Add(New SqlParameter("@O", SqlDbType.Bit, 1, "Facilito"))
            .Parameters.Add(New SqlParameter("@F", SqlDbType.Bit, 1, "Fonacot"))
            .Parameters.Add(New SqlParameter("@K", SqlDbType.Bit, 1, "Tarjeta Fonacot"))
            .Parameters.Add(New SqlParameter("@S", SqlDbType.Bit, 1, "Socios"))
            .Parameters.Add(New SqlParameter("@D", SqlDbType.Bit, 1, "Dips"))
            .Parameters.Add(parameter)
        End With
        Try
            sccnnConnection.Open()

            With sccmdInsert
                'Assign Parameters Values
                .Parameters("@CodArticulo").Value = oRow!MATERIAL
                .Parameters("@Descuento").Value = oRow!DESCUENTO
                If CStr(oRow!FECHASAPI) = "" Then
                    .Parameters("@FechaIni").Value = Date.Today
                Else
                    .Parameters("@FechaIni").Value = CDate(CStr(oRow!FECHASAPI).Substring(6) & "/" & CStr(oRow!FECHASAPI).Substring(4, 2) & "/" & CStr(oRow!FECHASAPI).Substring(0, 4))
                End If
                If CStr(oRow!FECHASAPF) = "" Then
                    .Parameters("@FechaFin").Value = Date.Today
                Else
                    .Parameters("@FechaFin").Value = CDate(CStr(oRow!FECHASAPF).Substring(6) & "/" & CStr(oRow!FECHASAPF).Substring(4, 2) & "/" & CStr(oRow!FECHASAPF).Substring(0, 4))
                End If
                .Parameters("@PG").Value = IIf(CStr(oRow!P).Trim = "X", True, False)
                .Parameters("@V").Value = IIf(CStr(oRow!V).Trim = "X", True, False)
                .Parameters("@I").Value = IIf(CStr(oRow!I).Trim = "X", True, False)
                .Parameters("@O").Value = IIf(CStr(oRow!O).Trim = "X", True, False)
                .Parameters("@F").Value = IIf(CStr(oRow!F).Trim = "X", True, False)
                .Parameters("@K").Value = IIf(CStr(oRow!K).Trim = "X", True, False)
                .Parameters("@S").Value = IIf(CStr(oRow!S).Trim = "X", True, False)
                .Parameters("@D").Value = IIf(CStr(oRow!D).Trim = "X", True, False)
                .ExecuteNonQuery()

            End With
            If Not IsDBNull(parameter.Value) AndAlso oRow.Table.Columns.IndexOf("FPAGOS") >= 0 Then
                Dim descuentoid As Integer = CInt(parameter.Value)
                sccmdInsert.Dispose()
                Dim ts As SqlTransaction = Nothing
                Try
                    ts = sccnnConnection.BeginTransaction()
                    sccmdInsert.Transaction = ts
                    sccmdInsert.Parameters.Clear()
                    sccmdInsert.CommandText = "INSERT INTO DescuentosFormasPago(DescuentoAdicionalID,CodFormaPago)VALUES(@DescuentoAdicionalID,@CodFormaPago)"
                    sccmdInsert.CommandType = CommandType.Text
                    sccmdInsert.Parameters.Add(New SqlParameter("@DescuentoAdicionalID", SqlDbType.Int))
                    sccmdInsert.Parameters.Add(New SqlParameter("@CodFormaPago", SqlDbType.VarChar))
                    Dim rows() As String = CStr(oRow!FPAGOS).Split(",")
                    For Each fila As String In rows
                        If Not fila Is Nothing AndAlso fila.Trim <> "" Then
                            sccmdInsert.Parameters("@DescuentoAdicionalID").Value = descuentoid
                            sccmdInsert.Parameters("@CodFormaPago").Value = fila
                            sccmdInsert.ExecuteNonQuery()
                        End If
                    Next
                    ts.Commit()
                Catch sql As Exception
                    If sccnnConnection.State <> ConnectionState.Closed Then
                        ts.Rollback()
                        sccnnConnection.Close()
                    End If
                    Throw New ApplicationException(sql.Message, sql)
                End Try
            End If
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

    Friend Sub InsertarDescuentosAdicionalesGeneral(ByVal oRow As DataRow)

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)
        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand
        Dim parameter As New SqlParameter("@DescuentoId", SqlDbType.Int)
        parameter.Direction = ParameterDirection.Output
        With sccmdInsert
            .Connection = sccnnConnection
            .CommandText = "[DescuentosAdicionalesInsPorMarca]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodMarca", System.Data.SqlDbType.VarChar, 2, "CodMarca"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Descuento", System.Data.SqlDbType.Decimal, 9, "Descuento"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaIni", System.Data.SqlDbType.DateTime, 8, "FechaIni"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaFin", System.Data.SqlDbType.DateTime, 8, "FechaFin"))
            .Parameters.Add(New SqlParameter("@PG", SqlDbType.Bit, 1, "Publico General"))
            .Parameters.Add(New SqlParameter("@V", SqlDbType.Bit, 1, "DPVale"))
            .Parameters.Add(New SqlParameter("@I", SqlDbType.Bit, 1, "Fact. Fiscal"))
            .Parameters.Add(New SqlParameter("@O", SqlDbType.Bit, 1, "Facilito"))
            .Parameters.Add(New SqlParameter("@F", SqlDbType.Bit, 1, "Fonacot"))
            .Parameters.Add(New SqlParameter("@K", SqlDbType.Bit, 1, "Tarjeta Fonacot"))
            .Parameters.Add(New SqlParameter("@S", SqlDbType.Bit, 1, "Socios"))
            .Parameters.Add(New SqlParameter("@D", SqlDbType.Bit, 1, "Dips"))
            .Parameters.Add(parameter)
        End With
        Try
            sccnnConnection.Open()

            With sccmdInsert
                'Assign Parameters Values
                .Parameters("@CodMarca").Value = "@@"
                .Parameters("@Descuento").Value = oRow!DESCUENTO
                If CStr(oRow!FECHASAPI) = "" Then
                    .Parameters("@FechaIni").Value = Date.Today
                Else
                    .Parameters("@FechaIni").Value = CDate(CStr(oRow!FECHASAPI).Substring(6) & "/" & CStr(oRow!FECHASAPI).Substring(4, 2) & "/" & CStr(oRow!FECHASAPI).Substring(0, 4))
                End If
                If CStr(oRow!FECHASAPF) = "" Then
                    .Parameters("@FechaFin").Value = Date.Today
                Else
                    .Parameters("@FechaFin").Value = CDate(CStr(oRow!FECHASAPF).Substring(6) & "/" & CStr(oRow!FECHASAPF).Substring(4, 2) & "/" & CStr(oRow!FECHASAPF).Substring(0, 4))
                End If
                .Parameters("@PG").Value = IIf(CStr(oRow!P).Trim = "X", True, False)
                .Parameters("@V").Value = IIf(CStr(oRow!V).Trim = "X", True, False)
                .Parameters("@I").Value = IIf(CStr(oRow!I).Trim = "X", True, False)
                .Parameters("@O").Value = IIf(CStr(oRow!O).Trim = "X", True, False)
                .Parameters("@F").Value = IIf(CStr(oRow!F).Trim = "X", True, False)
                .Parameters("@K").Value = IIf(CStr(oRow!K).Trim = "X", True, False)
                .Parameters("@S").Value = IIf(CStr(oRow!S).Trim = "X", True, False)
                .Parameters("@D").Value = IIf(CStr(oRow!D).Trim = "X", True, False)
                .ExecuteNonQuery()
                Dim descuentoid As Integer = 0
                If Not IsDBNull(parameter.Value) AndAlso oRow.Table.Columns.IndexOf("FPAGOS") >= 0 Then
                    descuentoid = CInt(parameter.Value)
                    sccmdInsert.Dispose()
                    Dim ts As SqlTransaction = Nothing
                    Try
                        ts = sccnnConnection.BeginTransaction()
                        sccmdInsert.Transaction = ts
                        sccmdInsert.Parameters.Clear()
                        sccmdInsert.CommandText = "INSERT INTO DescuentosFormasPago(DescuentoAdicionalID,CodFormaPago)VALUES(@DescuentoAdicionalID,@CodFormaPago)"
                        sccmdInsert.CommandType = CommandType.Text
                        sccmdInsert.Parameters.Add(New SqlParameter("@DescuentoAdicionalID", SqlDbType.Int))
                        sccmdInsert.Parameters.Add(New SqlParameter("@CodFormaPago", SqlDbType.VarChar))
                        Dim formasPago() As String = CStr(oRow!FPAGOS).Split(",")
                        For Each fila As String In formasPago
                            If Not fila Is Nothing AndAlso fila.Trim <> "" Then
                                sccmdInsert.Parameters("@DescuentoAdicionalID").Value = descuentoid
                                sccmdInsert.Parameters("@CodFormaPago").Value = fila
                                sccmdInsert.ExecuteNonQuery()
                            End If
                        Next
                        ts.Commit()
                    Catch sql As Exception
                        If sccnnConnection.State <> ConnectionState.Closed Then
                            ts.Rollback()
                            sccnnConnection.Close()
                        End If
                        Throw New ApplicationException(sql.Message, sql)
                    End Try
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
    End Sub

    'Friend Sub InsertarPromo20y30(ByVal oRow As DataRow)

    '    Dim sccnnConnection As New SqlConnection(m_strConnectionString)
    '    Dim sccmdInsert As SqlCommand
    '    sccmdInsert = New SqlCommand
    '    With sccmdInsert
    '        .Connection = sccnnConnection
    '        .CommandText = "[DescuentosAdicionalesInsPromo20y30]"
    '        .CommandType = System.Data.CommandType.StoredProcedure

    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodMarca", System.Data.SqlDbType.VarChar, 2, "CodMarca"))
    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Descuento", System.Data.SqlDbType.Decimal, 9, "Descuento"))
    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaIni", System.Data.SqlDbType.DateTime, 8, "FechaIni"))
    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaFin", System.Data.SqlDbType.DateTime, 8, "FechaFin"))
    '        .Parameters.Add(New SqlParameter("@Promo", SqlDbType.Bit, 1, "Promocion"))
    '        .Parameters.Add(New SqlParameter("@PG", SqlDbType.Bit, 1, "Publico General"))
    '        .Parameters.Add(New SqlParameter("@V", SqlDbType.Bit, 1, "DPVale"))
    '        .Parameters.Add(New SqlParameter("@I", SqlDbType.Bit, 1, "Fact. Fiscal"))
    '        .Parameters.Add(New SqlParameter("@O", SqlDbType.Bit, 1, "Facilito"))
    '        .Parameters.Add(New SqlParameter("@F", SqlDbType.Bit, 1, "Fonacot"))
    '        .Parameters.Add(New SqlParameter("@K", SqlDbType.Bit, 1, "Tarjeta Fonacot"))
    '        .Parameters.Add(New SqlParameter("@S", SqlDbType.Bit, 1, "Socios"))
    '        .Parameters.Add(New SqlParameter("@D", SqlDbType.Bit, 1, "Dips"))

    '    End With
    '    Try
    '        sccnnConnection.Open()

    '        With sccmdInsert
    '            'Assign Parameters Values
    '            .Parameters("@CodMarca").Value = "@@"
    '            .Parameters("@Descuento").Value = 0
    '            If CStr(oRow!FECHASAPI) = "" Then
    '                .Parameters("@FechaIni").Value = Date.Today
    '            Else
    '                .Parameters("@FechaIni").Value = CDate(CStr(oRow!FECHASAPI).Substring(6) & "/" & CStr(oRow!FECHASAPI).Substring(4, 2) & "/" & CStr(oRow!FECHASAPI).Substring(0, 4))
    '            End If
    '            If CStr(oRow!FECHASAPF) = "" Then
    '                .Parameters("@FechaFin").Value = Date.Today
    '            Else
    '                .Parameters("@FechaFin").Value = CDate(CStr(oRow!FECHASAPF).Substring(6) & "/" & CStr(oRow!FECHASAPF).Substring(4, 2) & "/" & CStr(oRow!FECHASAPF).Substring(0, 4))
    '            End If
    '            .Parameters("@Promo").Value = True
    '            .Parameters("@PG").Value = IIf(CStr(oRow!P).Trim = "X", True, False)
    '            .Parameters("@V").Value = IIf(CStr(oRow!V).Trim = "X", True, False)
    '            .Parameters("@I").Value = IIf(CStr(oRow!I).Trim = "X", True, False)
    '            .Parameters("@O").Value = IIf(CStr(oRow!O).Trim = "X", True, False)
    '            .Parameters("@F").Value = IIf(CStr(oRow!F).Trim = "X", True, False)
    '            .Parameters("@K").Value = IIf(CStr(oRow!K).Trim = "X", True, False)
    '            .Parameters("@S").Value = IIf(CStr(oRow!S).Trim = "X", True, False)
    '            .Parameters("@D").Value = IIf(CStr(oRow!D).Trim = "X", True, False)
    '            .ExecuteNonQuery()

    '        End With
    '        sccnnConnection.Close()

    '    Catch oSqlException As SqlException
    '        If (sccnnConnection.State <> ConnectionState.Closed) Then
    '            Try
    '                sccnnConnection.Close()
    '            Catch
    '            End Try
    '        End If
    '        Throw New ApplicationException(oSqlException.Message, oSqlException)
    '    Catch ex As Exception
    '        If (sccnnConnection.State <> ConnectionState.Closed) Then
    '            Try
    '                sccnnConnection.Close()
    '            Catch
    '            End Try
    '        End If
    '        Throw New ApplicationException(ex.Message, ex)
    '    End Try
    '    sccnnConnection.Dispose()
    '    sccnnConnection = Nothing
    'End Sub

    Friend Sub InsertarPromo20y30(ByVal oRow As DataRow)

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)
        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand
        Dim parameter As New SqlParameter("@DescuentoId", SqlDbType.Int)
        parameter.Direction = ParameterDirection.Output
        With sccmdInsert
            .Connection = sccnnConnection
            .CommandText = "[DescuentosAdicionalesInsPromo20y30]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodMarca", System.Data.SqlDbType.VarChar, 2, "CodMarca"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Descuento", System.Data.SqlDbType.Decimal, 9, "Descuento"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaIni", System.Data.SqlDbType.DateTime, 8, "FechaIni"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaFin", System.Data.SqlDbType.DateTime, 8, "FechaFin"))
            .Parameters.Add(New SqlParameter("@Promo", SqlDbType.Bit, 1, "Promocion"))
            .Parameters.Add(New SqlParameter("@PG", SqlDbType.Bit, 1, "Publico General"))
            .Parameters.Add(New SqlParameter("@V", SqlDbType.Bit, 1, "DPVale"))
            .Parameters.Add(New SqlParameter("@I", SqlDbType.Bit, 1, "Fact. Fiscal"))
            .Parameters.Add(New SqlParameter("@O", SqlDbType.Bit, 1, "Facilito"))
            .Parameters.Add(New SqlParameter("@F", SqlDbType.Bit, 1, "Fonacot"))
            .Parameters.Add(New SqlParameter("@K", SqlDbType.Bit, 1, "Tarjeta Fonacot"))
            .Parameters.Add(New SqlParameter("@S", SqlDbType.Bit, 1, "Socios"))
            .Parameters.Add(New SqlParameter("@D", SqlDbType.Bit, 1, "Dips"))
            .Parameters.Add(parameter)
        End With
        Try
            sccnnConnection.Open()

            With sccmdInsert
                'Assign Parameters Values
                .Parameters("@CodMarca").Value = "@@"
                .Parameters("@Descuento").Value = 0
                If CStr(oRow!FECHASAPI) = "" Then
                    .Parameters("@FechaIni").Value = Date.Today
                Else
                    .Parameters("@FechaIni").Value = CDate(CStr(oRow!FECHASAPI).Substring(6) & "/" & CStr(oRow!FECHASAPI).Substring(4, 2) & "/" & CStr(oRow!FECHASAPI).Substring(0, 4))
                End If
                If CStr(oRow!FECHASAPF) = "" Then
                    .Parameters("@FechaFin").Value = Date.Today
                Else
                    .Parameters("@FechaFin").Value = CDate(CStr(oRow!FECHASAPF).Substring(6) & "/" & CStr(oRow!FECHASAPF).Substring(4, 2) & "/" & CStr(oRow!FECHASAPF).Substring(0, 4))
                End If
                .Parameters("@Promo").Value = True
                .Parameters("@PG").Value = IIf(CStr(oRow!P).Trim = "X", True, False)
                .Parameters("@V").Value = IIf(CStr(oRow!V).Trim = "X", True, False)
                .Parameters("@I").Value = IIf(CStr(oRow!I).Trim = "X", True, False)
                .Parameters("@O").Value = IIf(CStr(oRow!O).Trim = "X", True, False)
                .Parameters("@F").Value = IIf(CStr(oRow!F).Trim = "X", True, False)
                .Parameters("@K").Value = IIf(CStr(oRow!K).Trim = "X", True, False)
                .Parameters("@S").Value = IIf(CStr(oRow!S).Trim = "X", True, False)
                .Parameters("@D").Value = IIf(CStr(oRow!D).Trim = "X", True, False)
                .ExecuteNonQuery()

            End With
            If Not IsDBNull(parameter.Value) AndAlso oRow.Table.Columns.IndexOf("FPAGOS") >= 0 Then
                Dim descuentoid As Integer = 0
                descuentoid = CInt(parameter.Value)
                sccmdInsert.Dispose()
                Dim ts As SqlTransaction = Nothing
                Try
                    ts = sccnnConnection.BeginTransaction()
                    sccmdInsert.Transaction = ts
                    sccmdInsert.Parameters.Clear()
                    sccmdInsert.CommandText = "INSERT INTO DescuentosFormasPago(DescuentoAdicionalID,CodFormaPago)VALUES(@DescuentoAdicionalID,@CodFormaPago)"
                    sccmdInsert.CommandType = CommandType.Text
                    sccmdInsert.Parameters.Add(New SqlParameter("@DescuentoAdicionalID", SqlDbType.Int))
                    sccmdInsert.Parameters.Add(New SqlParameter("@CodFormaPago", SqlDbType.VarChar))
                    Dim pagos() As String = CStr(oRow!FPAGOS).Split(",")
                    For Each fila As String In pagos
                        If Not fila Is Nothing AndAlso fila.Trim <> "" Then
                            sccmdInsert.Parameters("@DescuentoAdicionalID").Value = descuentoid
                            sccmdInsert.Parameters("@CodFormaPago").Value = fila
                            sccmdInsert.ExecuteNonQuery()
                        End If
                    Next
                    ts.Commit()
                Catch sql As Exception
                    If sccnnConnection.State <> ConnectionState.Closed Then
                        ts.Rollback()
                        sccnnConnection.Close()
                    End If
                    Throw New ApplicationException(sql.Message, sql)
                End Try
            End If
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

    'Friend Sub InsertarPromoDosPorUnoYMedio(ByVal oRow As DataRow)

    '    Dim sccnnConnection As New SqlConnection(m_strConnectionString)
    '    Dim sccmdInsert As SqlCommand
    '    sccmdInsert = New SqlCommand
    '    With sccmdInsert
    '        .Connection = sccnnConnection
    '        .CommandText = "[DescuentosAdicionalesInsPromo]"
    '        .CommandType = System.Data.CommandType.StoredProcedure

    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodMarca", System.Data.SqlDbType.VarChar, 2, "CodMarca"))
    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Descuento", System.Data.SqlDbType.Decimal, 9, "Descuento"))
    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaIni", System.Data.SqlDbType.DateTime, 8, "FechaIni"))
    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaFin", System.Data.SqlDbType.DateTime, 8, "FechaFin"))
    '        .Parameters.Add(New SqlParameter("@Promo", SqlDbType.Bit, 1, "Promocion"))
    '        .Parameters.Add(New SqlParameter("@PG", SqlDbType.Bit, 1, "Publico General"))
    '        .Parameters.Add(New SqlParameter("@V", SqlDbType.Bit, 1, "DPVale"))
    '        .Parameters.Add(New SqlParameter("@I", SqlDbType.Bit, 1, "Fact. Fiscal"))
    '        .Parameters.Add(New SqlParameter("@O", SqlDbType.Bit, 1, "Facilito"))
    '        .Parameters.Add(New SqlParameter("@F", SqlDbType.Bit, 1, "Fonacot"))
    '        .Parameters.Add(New SqlParameter("@K", SqlDbType.Bit, 1, "Tarjeta Fonacot"))
    '        .Parameters.Add(New SqlParameter("@S", SqlDbType.Bit, 1, "Socios"))
    '        .Parameters.Add(New SqlParameter("@D", SqlDbType.Bit, 1, "Dips"))

    '    End With
    '    Try
    '        sccnnConnection.Open()

    '        With sccmdInsert
    '            'Assign Parameters Values
    '            .Parameters("@CodMarca").Value = "@@"
    '            .Parameters("@Descuento").Value = 0
    '            If CStr(oRow!FECHASAPI) = "" Then
    '                .Parameters("@FechaIni").Value = Date.Today
    '            Else
    '                .Parameters("@FechaIni").Value = CDate(CStr(oRow!FECHASAPI).Substring(6) & "/" & CStr(oRow!FECHASAPI).Substring(4, 2) & "/" & CStr(oRow!FECHASAPI).Substring(0, 4))
    '            End If
    '            If CStr(oRow!FECHASAPF) = "" Then
    '                .Parameters("@FechaFin").Value = Date.Today
    '            Else
    '                .Parameters("@FechaFin").Value = CDate(CStr(oRow!FECHASAPF).Substring(6) & "/" & CStr(oRow!FECHASAPF).Substring(4, 2) & "/" & CStr(oRow!FECHASAPF).Substring(0, 4))
    '            End If
    '            .Parameters("@Promo").Value = True
    '            .Parameters("@PG").Value = IIf(CStr(oRow!P).Trim = "X", True, False)
    '            .Parameters("@V").Value = IIf(CStr(oRow!V).Trim = "X", True, False)
    '            .Parameters("@I").Value = IIf(CStr(oRow!I).Trim = "X", True, False)
    '            .Parameters("@O").Value = IIf(CStr(oRow!O).Trim = "X", True, False)
    '            .Parameters("@F").Value = IIf(CStr(oRow!F).Trim = "X", True, False)
    '            .Parameters("@K").Value = IIf(CStr(oRow!K).Trim = "X", True, False)
    '            .Parameters("@S").Value = IIf(CStr(oRow!S).Trim = "X", True, False)
    '            .Parameters("@D").Value = IIf(CStr(oRow!D).Trim = "X", True, False)
    '            .ExecuteNonQuery()

    '        End With
    '        sccnnConnection.Close()

    '    Catch oSqlException As SqlException
    '        If (sccnnConnection.State <> ConnectionState.Closed) Then
    '            Try
    '                sccnnConnection.Close()
    '            Catch
    '            End Try
    '        End If
    '        Throw New ApplicationException(oSqlException.Message, oSqlException)
    '    Catch ex As Exception
    '        If (sccnnConnection.State <> ConnectionState.Closed) Then
    '            Try
    '                sccnnConnection.Close()
    '            Catch
    '            End Try
    '        End If
    '        Throw New ApplicationException(ex.Message, ex)
    '    End Try
    '    sccnnConnection.Dispose()
    '    sccnnConnection = Nothing
    'End Sub

    Friend Sub InsertarPromoDosPorUnoYMedio(ByVal oRow As DataRow)

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)
        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand
        Dim parameter As New SqlParameter("@DescuentoId", SqlDbType.Int)
        parameter.Direction = ParameterDirection.Output
        With sccmdInsert
            .Connection = sccnnConnection
            .CommandText = "[DescuentosAdicionalesInsPromo]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodMarca", System.Data.SqlDbType.VarChar, 2, "CodMarca"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Descuento", System.Data.SqlDbType.Decimal, 9, "Descuento"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaIni", System.Data.SqlDbType.DateTime, 8, "FechaIni"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaFin", System.Data.SqlDbType.DateTime, 8, "FechaFin"))
            .Parameters.Add(New SqlParameter("@Promo", SqlDbType.Bit, 1, "Promocion"))
            .Parameters.Add(New SqlParameter("@PG", SqlDbType.Bit, 1, "Publico General"))
            .Parameters.Add(New SqlParameter("@V", SqlDbType.Bit, 1, "DPVale"))
            .Parameters.Add(New SqlParameter("@I", SqlDbType.Bit, 1, "Fact. Fiscal"))
            .Parameters.Add(New SqlParameter("@O", SqlDbType.Bit, 1, "Facilito"))
            .Parameters.Add(New SqlParameter("@F", SqlDbType.Bit, 1, "Fonacot"))
            .Parameters.Add(New SqlParameter("@K", SqlDbType.Bit, 1, "Tarjeta Fonacot"))
            .Parameters.Add(New SqlParameter("@S", SqlDbType.Bit, 1, "Socios"))
            .Parameters.Add(New SqlParameter("@D", SqlDbType.Bit, 1, "Dips"))
            .Parameters.Add(parameter)
        End With
        Try
            sccnnConnection.Open()

            With sccmdInsert
                'Assign Parameters Values
                .Parameters("@CodMarca").Value = "@@"
                .Parameters("@Descuento").Value = 0
                If CStr(oRow!FECHASAPI) = "" Then
                    .Parameters("@FechaIni").Value = Date.Today
                Else
                    .Parameters("@FechaIni").Value = CDate(CStr(oRow!FECHASAPI).Substring(6) & "/" & CStr(oRow!FECHASAPI).Substring(4, 2) & "/" & CStr(oRow!FECHASAPI).Substring(0, 4))
                End If
                If CStr(oRow!FECHASAPF) = "" Then
                    .Parameters("@FechaFin").Value = Date.Today
                Else
                    .Parameters("@FechaFin").Value = CDate(CStr(oRow!FECHASAPF).Substring(6) & "/" & CStr(oRow!FECHASAPF).Substring(4, 2) & "/" & CStr(oRow!FECHASAPF).Substring(0, 4))
                End If
                .Parameters("@Promo").Value = True
                .Parameters("@PG").Value = IIf(CStr(oRow!P).Trim = "X", True, False)
                .Parameters("@V").Value = IIf(CStr(oRow!V).Trim = "X", True, False)
                .Parameters("@I").Value = IIf(CStr(oRow!I).Trim = "X", True, False)
                .Parameters("@O").Value = IIf(CStr(oRow!O).Trim = "X", True, False)
                .Parameters("@F").Value = IIf(CStr(oRow!F).Trim = "X", True, False)
                .Parameters("@K").Value = IIf(CStr(oRow!K).Trim = "X", True, False)
                .Parameters("@S").Value = IIf(CStr(oRow!S).Trim = "X", True, False)
                .Parameters("@D").Value = IIf(CStr(oRow!D).Trim = "X", True, False)
                .ExecuteNonQuery()

            End With
            If Not IsDBNull(parameter.Value) AndAlso oRow.Table.Columns.IndexOf("FPAGOS") >= 0 Then
                Dim descuentoid As Integer = 0
                descuentoid = CInt(parameter.Value)
                sccmdInsert.Dispose()
                Dim ts As SqlTransaction = Nothing
                Try
                    ts = sccnnConnection.BeginTransaction()
                    sccmdInsert.Transaction = ts
                    sccmdInsert.Parameters.Clear()
                    sccmdInsert.CommandText = "INSERT INTO DescuentosFormasPago(DescuentoAdicionalID,CodFormaPago)VALUES(@DescuentoAdicionalID,@CodFormaPago)"
                    sccmdInsert.CommandType = CommandType.Text
                    sccmdInsert.Parameters.Add(New SqlParameter("@DescuentoAdicionalID", SqlDbType.Int))
                    sccmdInsert.Parameters.Add(New SqlParameter("@CodFormaPago", SqlDbType.VarChar))
                    Dim pagos() As String = CStr(oRow!FPAGOS).Split(",")
                    For Each fila As String In pagos
                        If Not fila Is Nothing AndAlso fila.Trim <> "" Then
                            sccmdInsert.Parameters("@DescuentoAdicionalID").Value = descuentoid
                            sccmdInsert.Parameters("@CodFormaPago").Value = fila
                            sccmdInsert.ExecuteNonQuery()
                        End If
                    Next
                    ts.Commit()
                Catch sql As Exception
                    If sccnnConnection.State <> ConnectionState.Closed Then
                        ts.Rollback()
                        sccnnConnection.Close()
                    End If
                    Throw New ApplicationException(sql.Message, sql)
                End Try
            End If
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

    'Friend Sub InsertarPromoDosPorUnoYMedioPorMarca(ByVal oRow As DataRow)

    '    Dim sccnnConnection As New SqlConnection(m_strConnectionString)
    '    Dim sccmdInsert As SqlCommand
    '    sccmdInsert = New SqlCommand
    '    With sccmdInsert
    '        .Connection = sccnnConnection
    '        .CommandText = "[DescuentosAdicionalesInsPromoPorMarca]"
    '        .CommandType = System.Data.CommandType.StoredProcedure

    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodMarca", System.Data.SqlDbType.VarChar, 2, "CodMarca"))
    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Descuento", System.Data.SqlDbType.Decimal, 9, "Descuento"))
    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaIni", System.Data.SqlDbType.DateTime, 8, "FechaIni"))
    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaFin", System.Data.SqlDbType.DateTime, 8, "FechaFin"))
    '        .Parameters.Add(New SqlParameter("@Promo", SqlDbType.Bit, 1, "Promocion"))
    '        .Parameters.Add(New SqlParameter("@PG", SqlDbType.Bit, 1, "Publico General"))
    '        .Parameters.Add(New SqlParameter("@V", SqlDbType.Bit, 1, "DPVale"))
    '        .Parameters.Add(New SqlParameter("@I", SqlDbType.Bit, 1, "Fact. Fiscal"))
    '        .Parameters.Add(New SqlParameter("@O", SqlDbType.Bit, 1, "Facilito"))
    '        .Parameters.Add(New SqlParameter("@F", SqlDbType.Bit, 1, "Fonacot"))
    '        .Parameters.Add(New SqlParameter("@K", SqlDbType.Bit, 1, "Tarjeta Fonacot"))
    '        .Parameters.Add(New SqlParameter("@S", SqlDbType.Bit, 1, "Socios"))
    '        .Parameters.Add(New SqlParameter("@D", SqlDbType.Bit, 1, "Dips"))

    '    End With
    '    Try
    '        sccnnConnection.Open()

    '        With sccmdInsert
    '            'Assign Parameters Values
    '            .Parameters("@CodMarca").Value = oRow!MARCA
    '            .Parameters("@Descuento").Value = 0
    '            If CStr(oRow!FECHASAPI) = "" Then
    '                .Parameters("@FechaIni").Value = Date.Today
    '            Else
    '                .Parameters("@FechaIni").Value = CDate(CStr(oRow!FECHASAPI).Substring(6) & "/" & CStr(oRow!FECHASAPI).Substring(4, 2) & "/" & CStr(oRow!FECHASAPI).Substring(0, 4))
    '            End If
    '            If CStr(oRow!FECHASAPF) = "" Then
    '                .Parameters("@FechaFin").Value = Date.Today
    '            Else
    '                .Parameters("@FechaFin").Value = CDate(CStr(oRow!FECHASAPF).Substring(6) & "/" & CStr(oRow!FECHASAPF).Substring(4, 2) & "/" & CStr(oRow!FECHASAPF).Substring(0, 4))
    '            End If
    '            .Parameters("@Promo").Value = True
    '            .Parameters("@PG").Value = IIf(CStr(oRow!P).Trim = "X", True, False)
    '            .Parameters("@V").Value = IIf(CStr(oRow!V).Trim = "X", True, False)
    '            .Parameters("@I").Value = IIf(CStr(oRow!I).Trim = "X", True, False)
    '            .Parameters("@O").Value = IIf(CStr(oRow!O).Trim = "X", True, False)
    '            .Parameters("@F").Value = IIf(CStr(oRow!F).Trim = "X", True, False)
    '            .Parameters("@K").Value = IIf(CStr(oRow!K).Trim = "X", True, False)
    '            .Parameters("@S").Value = IIf(CStr(oRow!S).Trim = "X", True, False)
    '            .Parameters("@D").Value = IIf(CStr(oRow!D).Trim = "X", True, False)
    '            .ExecuteNonQuery()

    '        End With
    '        sccnnConnection.Close()

    '    Catch oSqlException As SqlException
    '        If (sccnnConnection.State <> ConnectionState.Closed) Then
    '            Try
    '                sccnnConnection.Close()
    '            Catch
    '            End Try
    '        End If
    '        Throw New ApplicationException(oSqlException.Message, oSqlException)
    '    Catch ex As Exception
    '        If (sccnnConnection.State <> ConnectionState.Closed) Then
    '            Try
    '                sccnnConnection.Close()
    '            Catch
    '            End Try
    '        End If
    '        Throw New ApplicationException(ex.Message, ex)
    '    End Try
    '    sccnnConnection.Dispose()
    '    sccnnConnection = Nothing
    'End Sub

    Friend Sub InsertarPromoDosPorUnoYMedioPorMarca(ByVal oRow As DataRow)

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)
        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand
        Dim parameter As New SqlParameter("@DescuentoId", SqlDbType.Int)
        parameter.Direction = ParameterDirection.Output
        With sccmdInsert
            .Connection = sccnnConnection
            .CommandText = "[DescuentosAdicionalesInsPromoPorMarca]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodMarca", System.Data.SqlDbType.VarChar, 2, "CodMarca"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Descuento", System.Data.SqlDbType.Decimal, 9, "Descuento"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaIni", System.Data.SqlDbType.DateTime, 8, "FechaIni"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaFin", System.Data.SqlDbType.DateTime, 8, "FechaFin"))
            .Parameters.Add(New SqlParameter("@Promo", SqlDbType.Bit, 1, "Promocion"))
            .Parameters.Add(New SqlParameter("@PG", SqlDbType.Bit, 1, "Publico General"))
            .Parameters.Add(New SqlParameter("@V", SqlDbType.Bit, 1, "DPVale"))
            .Parameters.Add(New SqlParameter("@I", SqlDbType.Bit, 1, "Fact. Fiscal"))
            .Parameters.Add(New SqlParameter("@O", SqlDbType.Bit, 1, "Facilito"))
            .Parameters.Add(New SqlParameter("@F", SqlDbType.Bit, 1, "Fonacot"))
            .Parameters.Add(New SqlParameter("@K", SqlDbType.Bit, 1, "Tarjeta Fonacot"))
            .Parameters.Add(New SqlParameter("@S", SqlDbType.Bit, 1, "Socios"))
            .Parameters.Add(New SqlParameter("@D", SqlDbType.Bit, 1, "Dips"))
            .Parameters.Add(parameter)
        End With
        Try
            sccnnConnection.Open()

            With sccmdInsert
                'Assign Parameters Values
                .Parameters("@CodMarca").Value = oRow!MARCA
                .Parameters("@Descuento").Value = 0
                If CStr(oRow!FECHASAPI) = "" Then
                    .Parameters("@FechaIni").Value = Date.Today
                Else
                    .Parameters("@FechaIni").Value = CDate(CStr(oRow!FECHASAPI).Substring(6) & "/" & CStr(oRow!FECHASAPI).Substring(4, 2) & "/" & CStr(oRow!FECHASAPI).Substring(0, 4))
                End If
                If CStr(oRow!FECHASAPF) = "" Then
                    .Parameters("@FechaFin").Value = Date.Today
                Else
                    .Parameters("@FechaFin").Value = CDate(CStr(oRow!FECHASAPF).Substring(6) & "/" & CStr(oRow!FECHASAPF).Substring(4, 2) & "/" & CStr(oRow!FECHASAPF).Substring(0, 4))
                End If
                .Parameters("@Promo").Value = True
                .Parameters("@PG").Value = IIf(CStr(oRow!P).Trim = "X", True, False)
                .Parameters("@V").Value = IIf(CStr(oRow!V).Trim = "X", True, False)
                .Parameters("@I").Value = IIf(CStr(oRow!I).Trim = "X", True, False)
                .Parameters("@O").Value = IIf(CStr(oRow!O).Trim = "X", True, False)
                .Parameters("@F").Value = IIf(CStr(oRow!F).Trim = "X", True, False)
                .Parameters("@K").Value = IIf(CStr(oRow!K).Trim = "X", True, False)
                .Parameters("@S").Value = IIf(CStr(oRow!S).Trim = "X", True, False)
                .Parameters("@D").Value = IIf(CStr(oRow!D).Trim = "X", True, False)
                .ExecuteNonQuery()

            End With
            If Not IsDBNull(parameter.Value) AndAlso oRow.Table.Columns.IndexOf("FPAGOS") >= 0 Then
                Dim descuentoid As Integer = 0
                descuentoid = CInt(parameter.Value)
                sccmdInsert.Dispose()
                Dim ts As SqlTransaction = Nothing
                Try
                    ts = sccnnConnection.BeginTransaction()
                    sccmdInsert.Transaction = ts
                    sccmdInsert.Parameters.Clear()
                    sccmdInsert.CommandText = "INSERT INTO DescuentosFormasPago(DescuentoAdicionalID,CodFormaPago)VALUES(@DescuentoAdicionalID,@CodFormaPago)"
                    sccmdInsert.CommandType = CommandType.Text
                    sccmdInsert.Parameters.Add(New SqlParameter("@DescuentoAdicionalID", SqlDbType.Int))
                    sccmdInsert.Parameters.Add(New SqlParameter("@CodFormaPago", SqlDbType.VarChar))
                    Dim pagos() As String = CStr(oRow!FPAGOS).Split(",")
                    For Each fila As String In pagos
                        If Not fila Is Nothing AndAlso fila.Trim <> "" Then
                            sccmdInsert.Parameters("@DescuentoAdicionalID").Value = descuentoid
                            sccmdInsert.Parameters("@CodFormaPago").Value = fila
                            sccmdInsert.ExecuteNonQuery()
                        End If
                    Next
                    ts.Commit()
                Catch sql As Exception
                    If sccnnConnection.State <> ConnectionState.Closed Then
                        ts.Rollback()
                        sccnnConnection.Close()
                    End If
                    Throw New ApplicationException(sql.Message, sql)
                End Try
            End If
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

    'Friend Sub InsertarPromoDosPorUnoYMedioPorCodigo(ByVal oRow As DataRow)

    '    Dim sccnnConnection As New SqlConnection(m_strConnectionString)
    '    Dim sccmdInsert As SqlCommand
    '    sccmdInsert = New SqlCommand
    '    With sccmdInsert
    '        .Connection = sccnnConnection
    '        .CommandText = "[DescuentosAdicionalesInsPromoPorCodigo]"
    '        .CommandType = System.Data.CommandType.StoredProcedure

    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodArticulo", System.Data.SqlDbType.VarChar, 20, "CodArticulo"))
    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Descuento", System.Data.SqlDbType.Decimal, 9, "Descuento"))
    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaIni", System.Data.SqlDbType.DateTime, 8, "FechaIni"))
    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaFin", System.Data.SqlDbType.DateTime, 8, "FechaFin"))
    '        .Parameters.Add(New SqlParameter("@Promo", SqlDbType.Bit, 1, "Promocion"))
    '        .Parameters.Add(New SqlParameter("@PG", SqlDbType.Bit, 1, "Publico General"))
    '        .Parameters.Add(New SqlParameter("@V", SqlDbType.Bit, 1, "DPVale"))
    '        .Parameters.Add(New SqlParameter("@I", SqlDbType.Bit, 1, "Fact. Fiscal"))
    '        .Parameters.Add(New SqlParameter("@O", SqlDbType.Bit, 1, "Facilito"))
    '        .Parameters.Add(New SqlParameter("@F", SqlDbType.Bit, 1, "Fonacot"))
    '        .Parameters.Add(New SqlParameter("@K", SqlDbType.Bit, 1, "Tarjeta Fonacot"))
    '        .Parameters.Add(New SqlParameter("@S", SqlDbType.Bit, 1, "Socios"))
    '        .Parameters.Add(New SqlParameter("@D", SqlDbType.Bit, 1, "Dips"))

    '    End With
    '    Try
    '        sccnnConnection.Open()

    '        With sccmdInsert
    '            'Assign Parameters Values
    '            .Parameters("@CodArticulo").Value = oRow!PRODUCTO
    '            .Parameters("@Descuento").Value = 0
    '            If CStr(oRow!FECHASAPI) = "" Then
    '                .Parameters("@FechaIni").Value = Date.Today
    '            Else
    '                .Parameters("@FechaIni").Value = CDate(CStr(oRow!FECHASAPI).Substring(6) & "/" & CStr(oRow!FECHASAPI).Substring(4, 2) & "/" & CStr(oRow!FECHASAPI).Substring(0, 4))
    '            End If
    '            If CStr(oRow!FECHASAPF) = "" Then
    '                .Parameters("@FechaFin").Value = Date.Today
    '            Else
    '                .Parameters("@FechaFin").Value = CDate(CStr(oRow!FECHASAPF).Substring(6) & "/" & CStr(oRow!FECHASAPF).Substring(4, 2) & "/" & CStr(oRow!FECHASAPF).Substring(0, 4))
    '            End If
    '            .Parameters("@Promo").Value = True
    '            .Parameters("@PG").Value = IIf(CStr(oRow!P).Trim = "X", True, False)
    '            .Parameters("@V").Value = IIf(CStr(oRow!V).Trim = "X", True, False)
    '            .Parameters("@I").Value = IIf(CStr(oRow!I).Trim = "X", True, False)
    '            .Parameters("@O").Value = IIf(CStr(oRow!O).Trim = "X", True, False)
    '            .Parameters("@F").Value = IIf(CStr(oRow!F).Trim = "X", True, False)
    '            .Parameters("@K").Value = IIf(CStr(oRow!K).Trim = "X", True, False)
    '            .Parameters("@S").Value = IIf(CStr(oRow!S).Trim = "X", True, False)
    '            .Parameters("@D").Value = IIf(CStr(oRow!D).Trim = "X", True, False)
    '            .ExecuteNonQuery()

    '        End With
    '        sccnnConnection.Close()

    '    Catch oSqlException As SqlException
    '        If (sccnnConnection.State <> ConnectionState.Closed) Then
    '            Try
    '                sccnnConnection.Close()
    '            Catch
    '            End Try
    '        End If
    '        Throw New ApplicationException(oSqlException.Message, oSqlException)
    '    Catch ex As Exception
    '        If (sccnnConnection.State <> ConnectionState.Closed) Then
    '            Try
    '                sccnnConnection.Close()
    '            Catch
    '            End Try
    '        End If
    '        Throw New ApplicationException(ex.Message, ex)
    '    End Try
    '    sccnnConnection.Dispose()
    '    sccnnConnection = Nothing
    'End Sub

    Friend Sub InsertarPromoDosPorUnoYMedioPorCodigo(ByVal oRow As DataRow)

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)
        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand
        Dim parameter As New SqlParameter("@DescuentoId", SqlDbType.Int)
        parameter.Direction = ParameterDirection.Output
        With sccmdInsert
            .Connection = sccnnConnection
            .CommandText = "[DescuentosAdicionalesInsPromoPorCodigo]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodArticulo", System.Data.SqlDbType.VarChar, 20, "CodArticulo"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Descuento", System.Data.SqlDbType.Decimal, 9, "Descuento"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaIni", System.Data.SqlDbType.DateTime, 8, "FechaIni"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaFin", System.Data.SqlDbType.DateTime, 8, "FechaFin"))
            .Parameters.Add(New SqlParameter("@Promo", SqlDbType.Bit, 1, "Promocion"))
            .Parameters.Add(New SqlParameter("@PG", SqlDbType.Bit, 1, "Publico General"))
            .Parameters.Add(New SqlParameter("@V", SqlDbType.Bit, 1, "DPVale"))
            .Parameters.Add(New SqlParameter("@I", SqlDbType.Bit, 1, "Fact. Fiscal"))
            .Parameters.Add(New SqlParameter("@O", SqlDbType.Bit, 1, "Facilito"))
            .Parameters.Add(New SqlParameter("@F", SqlDbType.Bit, 1, "Fonacot"))
            .Parameters.Add(New SqlParameter("@K", SqlDbType.Bit, 1, "Tarjeta Fonacot"))
            .Parameters.Add(New SqlParameter("@S", SqlDbType.Bit, 1, "Socios"))
            .Parameters.Add(New SqlParameter("@D", SqlDbType.Bit, 1, "Dips"))
            .Parameters.Add(New SqlParameter("@Jerarquia", SqlDbType.VarChar, 12, "Jerarquia"))
            .Parameters.Add(parameter)
        End With
        Try
            sccnnConnection.Open()

            With sccmdInsert
                'Assign Parameters Values
                .Parameters("@CodArticulo").Value = oRow!PRODUCTO
                .Parameters("@Descuento").Value = 0
                If CStr(oRow!FECHASAPI) = "" Then
                    .Parameters("@FechaIni").Value = Date.Today
                Else
                    .Parameters("@FechaIni").Value = CDate(CStr(oRow!FECHASAPI).Substring(6) & "/" & CStr(oRow!FECHASAPI).Substring(4, 2) & "/" & CStr(oRow!FECHASAPI).Substring(0, 4))
                End If
                If CStr(oRow!FECHASAPF) = "" Then
                    .Parameters("@FechaFin").Value = Date.Today
                Else
                    .Parameters("@FechaFin").Value = CDate(CStr(oRow!FECHASAPF).Substring(6) & "/" & CStr(oRow!FECHASAPF).Substring(4, 2) & "/" & CStr(oRow!FECHASAPF).Substring(0, 4))
                End If

                If InStr("N,J", CStr(oRow!COMBINADO).Trim.ToUpper) > 0 Then
                    .Parameters("@Jerarquia").Value = CStr(oRow!JERARQUIA).Trim
                Else
                    .Parameters("@Jerarquia").Value = DBNull.Value
                End If

                .Parameters("@Promo").Value = True
                .Parameters("@PG").Value = IIf(CStr(oRow!P).Trim = "X", True, False)
                .Parameters("@V").Value = IIf(CStr(oRow!V).Trim = "X", True, False)
                .Parameters("@I").Value = IIf(CStr(oRow!I).Trim = "X", True, False)
                .Parameters("@O").Value = IIf(CStr(oRow!O).Trim = "X", True, False)
                .Parameters("@F").Value = IIf(CStr(oRow!F).Trim = "X", True, False)
                .Parameters("@K").Value = IIf(CStr(oRow!K).Trim = "X", True, False)
                .Parameters("@S").Value = IIf(CStr(oRow!S).Trim = "X", True, False)
                .Parameters("@D").Value = IIf(CStr(oRow!D).Trim = "X", True, False)
                .ExecuteNonQuery()

            End With
            If Not IsDBNull(parameter.Value) AndAlso oRow.Table.Columns.IndexOf("FPAGOS") >= 0 Then
                Dim descuentoid As Integer = 0
                descuentoid = CInt(parameter.Value)
                sccmdInsert.Dispose()
                Dim ts As SqlTransaction = Nothing
                Try
                    ts = sccnnConnection.BeginTransaction()
                    sccmdInsert.Transaction = ts
                    sccmdInsert.Parameters.Clear()
                    sccmdInsert.CommandText = "INSERT INTO DescuentosFormasPago(DescuentoAdicionalID,CodFormaPago)VALUES(@DescuentoAdicionalID,@CodFormaPago)"
                    sccmdInsert.CommandType = CommandType.Text
                    sccmdInsert.Parameters.Add(New SqlParameter("@DescuentoAdicionalID", SqlDbType.Int))
                    sccmdInsert.Parameters.Add(New SqlParameter("@CodFormaPago", SqlDbType.VarChar))
                    Dim pagos() As String = CStr(oRow!FPAGOS).Split(",")
                    For Each fila As String In pagos
                        If Not fila Is Nothing AndAlso fila.Trim <> "" Then
                            sccmdInsert.Parameters("@DescuentoAdicionalID").Value = descuentoid
                            sccmdInsert.Parameters("@CodFormaPago").Value = fila
                            sccmdInsert.ExecuteNonQuery()
                        End If
                    Next
                    ts.Commit()
                Catch sql As Exception
                    If sccnnConnection.State <> ConnectionState.Closed Then
                        ts.Rollback()
                        sccnnConnection.Close()
                    End If
                    Throw New ApplicationException(sql.Message, sql)
                End Try
            End If
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

    Friend Sub InsertarPromoDpaketesStreetPacks(ByVal oRow As DataRow)

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)
        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand
        With sccmdInsert
            .Connection = sccnnConnection
            .CommandText = "[DescuentosAdicionalesInsDpaketes]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Folio", System.Data.SqlDbType.VarChar, 10, "CodArticulo"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaIni", System.Data.SqlDbType.DateTime, 8, "FechaIni"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaFin", System.Data.SqlDbType.DateTime, 8, "FechaFin"))

        End With
        Try
            sccnnConnection.Open()

            With sccmdInsert
                'Assign Parameters Values
                .Parameters("@Folio").Value = oRow!Paquete
                If CStr(oRow!FECHASAPI) = "" Then
                    .Parameters("@FechaIni").Value = Date.Today
                Else
                    .Parameters("@FechaIni").Value = CDate(CStr(oRow!FECHASAPI).Substring(6) & "/" & CStr(oRow!FECHASAPI).Substring(4, 2) & "/" & CStr(oRow!FECHASAPI).Substring(0, 4))
                End If
                If CStr(oRow!FECHASAPF) = "" Then
                    .Parameters("@FechaFin").Value = Date.Today
                Else
                    .Parameters("@FechaFin").Value = CDate(CStr(oRow!FECHASAPF).Substring(6) & "/" & CStr(oRow!FECHASAPF).Substring(4, 2) & "/" & CStr(oRow!FECHASAPF).Substring(0, 4))
                End If
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

    Friend Sub InsertarPromoDpaketesStreetPacksDetalle(ByVal oRow As DataRow)

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)
        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand
        With sccmdInsert
            .Connection = sccnnConnection
            .CommandText = "[DescuentosAdicionalesInsDpaketesDetalle]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Folio", System.Data.SqlDbType.VarChar, 10, "CodArticulo"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodArticulo", System.Data.SqlDbType.VarChar, 20, "Material"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Descuento", System.Data.SqlDbType.Decimal, 9, "Descuento"))

        End With
        Try
            sccnnConnection.Open()

            With sccmdInsert
                'Assign Parameters Values
                .Parameters("@Folio").Value = oRow!Paquete
                .Parameters("@CodArticulo").Value = oRow!Matnr
                .Parameters("@Descuento").Value = oRow!Descuento

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

    Friend Sub InsertarDescuentoAdicionalFijoPorClienteDIP(ByVal oRow As DataRow)

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)
        Dim sccmdInsert As SqlCommand
        Dim Fecha As String = ""
        sccmdInsert = New SqlCommand
        With sccmdInsert
            .Connection = sccnnConnection
            .CommandText = "[DescuentosAdicionalesFijosIns]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCliente", System.Data.SqlDbType.VarChar, 20, "CodCliente"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Descuento", System.Data.SqlDbType.Decimal, 9, "Descuento"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@DipCorp", System.Data.SqlDbType.Bit, 1, "DipCorp"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime, 8, "Fecha"))

        End With
        Try
            sccnnConnection.Open()

            With sccmdInsert
                'Assign Parameters Values
                .Parameters("@CodCliente").Value = oRow!CodCliente
                .Parameters("@Descuento").Value = oRow!Descuento
                If CStr(oRow!DipCorp).Trim.ToUpper = "X" Then
                    .Parameters("@DipCorp").Value = True
                Else
                    .Parameters("@DipCorp").Value = False
                End If
                Fecha = CStr(oRow!Fecha).Trim
                Fecha = Fecha.Substring(6, 2) & "/" & Fecha.Substring(4, 2) & "/" & Fecha.Substring(0, 4)
                If IsDate(Fecha) = True Then
                    .Parameters("@Fecha").Value = CDate(Fecha)
                Else
                    .Parameters("@Fecha").Value = Now
                End If

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

    Public Sub DeleteDescuentosAdicionalesFijos()

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdDelete As SqlCommand
        sccmdDelete = New SqlCommand

        With sccmdDelete

            .Connection = sccnnConnection

            .CommandText = "[DescuentosAdicionalesFijosDel]"
            .CommandType = System.Data.CommandType.StoredProcedure

        End With

        Try

            sccnnConnection.Open()

            With sccmdDelete

                'Ejecutamos Comando
                .ExecuteNonQuery()

            End With

            sccnnConnection.Close()

        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                sccnnConnection.Close()
            End If

            Throw New ApplicationException("El registro no pudo ser eliminado debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                sccnnConnection.Close()
            End If

            Throw New ApplicationException("El registro no pudo ser eliminado debido a un error de aplicación.", ex)

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

    End Sub

    Public Sub DeleteDescuentosAdicionales(ByVal Opcion As Integer)

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdDelete As SqlCommand
        sccmdDelete = New SqlCommand

        With sccmdDelete

            .Connection = sccnnConnection

            .CommandText = "[DescuentosAdicionalesDel]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Parameters.Add(New SqlParameter("@Opcion", SqlDbType.Int, 4, "Opcion"))

            .Parameters("@Opcion").Value = Opcion
        End With

        Try

            sccnnConnection.Open()

            With sccmdDelete

                'Ejecutamos Comando
                .ExecuteNonQuery()

            End With

            sccnnConnection.Close()

        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                sccnnConnection.Close()
            End If

            Throw New ApplicationException("El registro no pudo ser eliminado debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                sccnnConnection.Close()
            End If

            Throw New ApplicationException("El registro no pudo ser eliminado debido a un error de aplicación.", ex)

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

    End Sub

    Friend Sub ActualizaArticulosPrecioSocio(ByVal strcodigoarticulo As String, ByVal dblprecioSocio As Double)
        Dim sccnnConnection As New SqlConnection(m_strConnectionString)
        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand
        With sccmdInsert
            .Connection = sccnnConnection
            .CommandText = "[ArticulosPrecioSocioUpd]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodArticulo", System.Data.SqlDbType.VarChar, 20, "CodArticulo"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@PrecioSocio", System.Data.SqlDbType.Money, 8, "CostoProm"))
        End With
        Try
            sccnnConnection.Open()
            With sccmdInsert
                'Assign Parameters Values
                .Parameters("@CodArticulo").Value = strcodigoarticulo
                .Parameters("@PrecioSocio").Value = dblprecioSocio
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

#End Region

#Region "Clientes"

    Friend Sub InsertarClientes(ByVal pClienteSAP As ClientesSAP)
        Dim sccnnConnection As New SqlConnection(m_strConnectionString)
        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand
        With sccmdInsert
            .Connection = sccnnConnection
            .CommandText = "[ClientesSAPIns]"
            .CommandType = System.Data.CommandType.StoredProcedure
            '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@clienteid", System.Data.SqlDbType.VarChar, 15, "Clienteid"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@nombre", System.Data.SqlDbType.VarChar, 100, "Nombre"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@apellidos", System.Data.SqlDbType.VarChar, 100, "Apellidos"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Sexo", System.Data.SqlDbType.Char, 1, "Sexo"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Estadocivil", System.Data.SqlDbType.VarChar, 20, "Estadocivil"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Domicilio", System.Data.SqlDbType.VarChar, 50, "Domicilio"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Estado", System.Data.SqlDbType.VarChar, 50, "Estado"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Ciudad", System.Data.SqlDbType.VarChar, 50, "Ciudad"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Colonia", System.Data.SqlDbType.VarChar, 50, "Colonia"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Cp", System.Data.SqlDbType.VarChar, 5, "Cp"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Telefono", System.Data.SqlDbType.VarChar, 30, "Telefono"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fechanac", System.Data.SqlDbType.DateTime, 8, "Fechanac"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Email", System.Data.SqlDbType.VarChar, 50, "Email"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Codalmacen", System.Data.SqlDbType.VarChar, 4, "Codalmacen"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodPlaza", System.Data.SqlDbType.VarChar, 4, "CodPlaza"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Usuario", System.Data.SqlDbType.VarChar, 8, "Usuario"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime, 8, "Fecha"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Statusregistro", System.Data.SqlDbType.Bit, 1, "Statusregistro"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RFC", System.Data.SqlDbType.VarChar, 15, "RFC"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TipoVenta", System.Data.SqlDbType.VarChar, 5, "TipoVenta"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ClaveAnterior", System.Data.SqlDbType.VarChar, 10, "ClaveAnterior"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Player", System.Data.SqlDbType.VarChar, 8, "player"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@NumExt", System.Data.SqlDbType.VarChar, 10, "Numero Exterior"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@NumInt", System.Data.SqlDbType.VarChar, 10, "Numero Interior"))
        End With
        Try
            sccnnConnection.Open()
            With sccmdInsert
                'Assign Parameters Values
                .Parameters("@clienteid").Value = pClienteSAP.Clienteid
                .Parameters("@nombre").Value = pClienteSAP.Nombre
                .Parameters("@apellidos").Value = pClienteSAP.Apellidos
                .Parameters("@sexo").Value = pClienteSAP.Sexo
                .Parameters("@estadocivil").Value = pClienteSAP.Estadocivil
                .Parameters("@domicilio").Value = pClienteSAP.Domicilio
                .Parameters("@estado").Value = pClienteSAP.Estado
                .Parameters("@ciudad").Value = pClienteSAP.Ciudad
                .Parameters("@colonia").Value = pClienteSAP.Colonia
                .Parameters("@cp").Value = pClienteSAP.Cp
                .Parameters("@telefono").Value = pClienteSAP.Telefono
                .Parameters("@fechanac").Value = pClienteSAP.Fechanac
                .Parameters("@email").Value = pClienteSAP.Email
                .Parameters("@codalmacen").Value = pClienteSAP.Codalmacen
                .Parameters("@codplaza").Value = pClienteSAP.CodPlaza
                .Parameters("@usuario").Value = pClienteSAP.Usuario
                .Parameters("@fecha").Value = pClienteSAP.Fecha
                .Parameters("@StatusRegistro").Value = pClienteSAP.Statusregistro
                .Parameters("@TipoVenta").Value = pClienteSAP.TipoVenta
                .Parameters("@RFC").Value = pClienteSAP.RFC
                .Parameters("@ClaveAnterior").Value = pClienteSAP.ClaveAnterior
                .Parameters("@Player").Value = pClienteSAP.Player
                .Parameters("@NumExt").Value = pClienteSAP.NumeroExterior
                .Parameters("@NumInt").Value = pClienteSAP.NumeroInterior
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


#End Region

#Region "Precios y CondicionesVenta"

    Friend Sub InsertarCondicionesVta(ByVal pCondicionesVtaSAP As CondicionesVtaSAP)
        Dim sccnnConnection As New SqlConnection(m_strConnectionString)
        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand
        With sccmdInsert
            .Connection = sccnnConnection
            .CommandText = "[CondicionesVentaIns]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Condicion", System.Data.SqlDbType.VarChar, 4, "Condicion"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@OrgVtas", System.Data.SqlDbType.VarChar, 4, "OrgVtas"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CanalDist", System.Data.SqlDbType.VarChar, 2, "CanalDist"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Jerarquia", System.Data.SqlDbType.VarChar, 18, "Jerarquia"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CondMat", System.Data.SqlDbType.VarChar, 2, "CondMat"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CondPrec", System.Data.SqlDbType.VarChar, 2, "CondPrec"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Material", System.Data.SqlDbType.VarChar, 18, "Material"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@OficinaVtas", System.Data.SqlDbType.VarChar, 4, "OficinaVtas"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ListPrec", System.Data.SqlDbType.VarChar, 2, "ListPrec"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaIni", System.Data.SqlDbType.DateTime, 8, "FechaIni"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaFin", System.Data.SqlDbType.DateTime, 8, "FechaFin"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@DescPorcentaje", System.Data.SqlDbType.Money, 8, "DescPorcentaje"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Descmonto", System.Data.SqlDbType.Money, 8, "Descmonto"))
        End With
        Try
            sccnnConnection.Open()
            With sccmdInsert
                'Assign Parameters Values
                .Parameters("@Condicion").Value = pCondicionesVtaSAP.Condicion
                .Parameters("@OrgVtas").Value = pCondicionesVtaSAP.OrgVtas
                .Parameters("@CanalDist").Value = pCondicionesVtaSAP.CanalDist
                .Parameters("@Jerarquia").Value = pCondicionesVtaSAP.Jerarquia
                .Parameters("@CondMat").Value = pCondicionesVtaSAP.CondMat
                .Parameters("@CondPrec").Value = pCondicionesVtaSAP.CondPrec
                .Parameters("@Material").Value = pCondicionesVtaSAP.Material
                .Parameters("@OficinaVtas").Value = pCondicionesVtaSAP.OficinaVtas
                .Parameters("@ListPrec").Value = pCondicionesVtaSAP.ListPrec
                .Parameters("@FechaIni").Value = pCondicionesVtaSAP.FechaIni
                .Parameters("@FechaFin").Value = pCondicionesVtaSAP.FechaFin
                .Parameters("@DescPorcentaje").Value = Math.Round(Math.Abs(pCondicionesVtaSAP.DescPorcentaje), 2)
                .Parameters("@Descmonto").Value = Math.Round(Math.Abs(pCondicionesVtaSAP.Descmonto), 2)
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

    Friend Sub DeleteCondicionesVta()
        Dim sccnnConnection As New SqlConnection(m_strConnectionString)
        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand
        With sccmdInsert
            .Connection = sccnnConnection
            .CommandText = "[CondicionesVentaDel]"
            .CommandType = System.Data.CommandType.StoredProcedure
        End With

        Try
            sccnnConnection.Open()
            sccmdInsert.ExecuteNonQuery()

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

#End Region

#Region "Centros"

    Public Sub DeleteCatalogoCentros()

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand

        With sccmdInsert

            .Connection = sccnnConnection

            .CommandText = "[CatalogoCentrosDel]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Connection = sccnnConnection

        End With

        Try

            sccnnConnection.Open()

            With sccmdInsert

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

    'Friend Function SeleccionaCentro(ByVal CodAlmacen As String, ByRef CentroFI As String) As String

    '    Dim strResult As String

    '    Dim sccnnDPTienda As New SqlConnection(m_strConnectionString)

    '    Dim sccmdCatalogoCentrosSel As SqlCommand
    '    sccmdCatalogoCentrosSel = New SqlCommand

    '    With sccmdCatalogoCentrosSel
    '        .CommandText = "[CatalogoCentrosSel]"
    '        .CommandType = System.Data.CommandType.StoredProcedure
    '        .Connection = sccnnDPTienda
    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@OficinaVtas", System.Data.SqlDbType.VarChar, 4))

    '        '.Parameters("@OficinaVtas").Value = oParent.ApplicationContext.ApplicationConfiguration.Almacen
    '        .Parameters("@OficinaVtas").Value = CodAlmacen.Trim.PadLeft(3, "0")
    '    End With

    '    Try
    '        sccnnDPTienda.Open()

    '        Dim scsdrReader As SqlDataReader

    '        scsdrReader = sccmdCatalogoCentrosSel.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.SingleRow)

    '        scsdrReader.Read()

    '        If (scsdrReader.HasRows) Then

    '            With scsdrReader
    '                strResult = .GetString(0) 'Cod Centro SAP
    '                CentroFI = .GetString(1) 'CentroFI
    '            End With
    '            scsdrReader.Close()

    '        Else

    '            strResult = String.Empty

    '        End If


    '    Catch ex As Exception

    '        Throw ex

    '    Finally

    '        If (sccnnDPTienda.State <> ConnectionState.Closed) Then
    '            Try
    '                sccnnDPTienda.Close()
    '            Catch
    '            End Try
    '        End If

    '    End Try

    '    sccmdCatalogoCentrosSel.Dispose()
    '    sccmdCatalogoCentrosSel = Nothing

    '    sccnnDPTienda.Dispose()
    '    sccnnDPTienda = Nothing

    '    Return strResult
    'End Function

    Friend Function SeleccionaCentroSAP(ByVal strCentroSap As String) As String()

        Dim strResult(3) As String

        Dim sccnnDPTienda As New SqlConnection(m_strConnectionString)

        Dim sccmdCatalogoCentrosSel As SqlCommand
        sccmdCatalogoCentrosSel = New SqlCommand

        With sccmdCatalogoCentrosSel
            .CommandText = "[CatalogoCentrosSAPSel]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Connection = sccnnDPTienda
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CentroSAP", System.Data.SqlDbType.VarChar, 4))

            .Parameters("@CentroSAP").Value = strCentroSap
        End With

        Try
            sccnnDPTienda.Open()

            Dim scsdrReader As SqlDataReader

            scsdrReader = sccmdCatalogoCentrosSel.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.SingleRow)

            scsdrReader.Read()

            If (scsdrReader.HasRows) Then

                With scsdrReader
                    strResult(0) = .GetString(0) 'Cod Centro Dp
                    strResult(1) = Trim(.GetString(1)) 'Descripcion
                    strResult(2) = CStr(scsdrReader("CentroSAP"))
                End With
                scsdrReader.Close()

            Else

                strResult(0) = String.Empty
                strResult(1) = String.Empty
                strResult(2) = String.Empty

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

    Friend Function SeleccionaCentro(ByVal CodAlmacen As String, ByRef CentroFI As String) As String

        Dim oResult As DataSet
        Dim strResult As String

        Dim sccnnDPTienda As New SqlConnection(m_strConnectionString)

        Dim sccmdCatalogoCentrosSel As SqlCommand
        sccmdCatalogoCentrosSel = New SqlCommand

        With sccmdCatalogoCentrosSel
            .CommandText = "[CatalogoCentrosSel]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Connection = sccnnDPTienda
            '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@OficinaVtas", System.Data.SqlDbType.VarChar, 4))

            '.Parameters("@OficinaVtas").Value = oParent.ApplicationContext.ApplicationConfiguration.Almacen
            .Parameters("@OficinaVtas").Value = CodAlmacen.Trim.PadLeft(3, "0")
        End With

        Dim scdaCentrosAdapter As SqlDataAdapter
        scdaCentrosAdapter = New SqlDataAdapter

        scdaCentrosAdapter.SelectCommand = sccmdCatalogoCentrosSel

        Try

            sccnnDPTienda.Open()

            oResult = New DataSet

            scdaCentrosAdapter.Fill(oResult, "CatalogoCentros")

            If oResult.Tables(0).Rows.Count > 0 Then
                strResult = oResult.Tables(0).Rows(0).Item("CentroSAP")
                CentroFI = oResult.Tables(0).Rows(0).Item("CentroFI")
            Else
                strResult = String.Empty
                CentroFI = String.Empty
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

#End Region

#Region "ZPP_COBRANZAS"

    Public Sub InsertZPP_COBRANZAS(ByVal TIENDA As String, ByVal CLACOBR As String, _
                ByVal BANCO As String, ByVal HKONT As String, ByVal WERKS As String, ByVal GSBER As String)

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand

        With sccmdInsert

            .Connection = sccnnConnection

            .CommandText = "[ZPP_COBRANZASIns]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Connection = sccnnConnection

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Tienda", System.Data.SqlDbType.VarChar, 30))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Clacobr", System.Data.SqlDbType.VarChar, 9))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Banco", System.Data.SqlDbType.VarChar, 8))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Hkont", System.Data.SqlDbType.VarChar, 10))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@dpClave", System.Data.SqlDbType.VarChar, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@GSBER", System.Data.SqlDbType.VarChar, 4))


        End With

        Try

            sccnnConnection.Open()

            With sccmdInsert

                'Assign Parameters Values
                .Parameters("@Tienda").Value = TIENDA
                .Parameters("@Clacobr").Value = CLACOBR
                .Parameters("@Banco").Value = BANCO
                .Parameters("@Hkont").Value = HKONT
                .Parameters("@dpClave").Value = WERKS
                If GSBER <> "" Then
                    .Parameters("@GSBER").Value = GSBER
                Else
                    .Parameters("@GSBER").Value = Format(Mid(WERKS, 2, 3), "0000")
                End If
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

#Region "UPC"

    Friend Sub InsertarUPC(ByVal oRow As DataRow)

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)
        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand
        With sccmdInsert
            .Connection = sccnnConnection
            .CommandText = "[CatalogoUPCInsSAP]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodUPC", System.Data.SqlDbType.VarChar, 20, "CodUPC"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodArticulo", System.Data.SqlDbType.VarChar, 20, "CodArticulo"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Numero", System.Data.SqlDbType.VarChar, 4, "Numero"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodArtProv", System.Data.SqlDbType.VarChar, 20, "CodArtPro"))

        End With
        Try
            sccnnConnection.Open()
            With sccmdInsert
                Dim strNumero As String
                If IsNumeric(oRow!J_3ASIZE) Then
                    'es un valor Numerico
                    If InStr(CStr(oRow!J_3ASIZE), ".5") = 0 Then
                        'La formato para que qued si es 26.0  --> 26
                        strNumero = Format(CDec(oRow!J_3ASIZE), "###0")
                    Else
                        'Se queda Igual es .5
                        strNumero = oRow!J_3ASIZE
                    End If
                Else
                    'Es un Numero  XXL L M S
                    strNumero = oRow!J_3ASIZE
                End If
                .Parameters("@CodArticulo").Value = oRow!MATNR
                .Parameters("@Numero").Value = strNumero
                .Parameters("@CodUPC").Value = CStr(oRow!EAN11).PadLeft(18, "0")
                .Parameters("@CodArtProv").Value = oRow!MATNR

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

    Friend Sub InsertarUPCServer(ByVal oRow As DataRow)

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)
        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand
        With sccmdInsert
            .Connection = sccnnConnection
            .CommandText = "[CatalogoUPCInsSAP]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodUPC", System.Data.SqlDbType.VarChar, 20, "CodUPC"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodArticulo", System.Data.SqlDbType.VarChar, 20, "CodArticulo"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Numero", System.Data.SqlDbType.VarChar, 4, "Numero"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodArtProv", System.Data.SqlDbType.VarChar, 20, "CodArtPro"))

        End With
        Try
            sccnnConnection.Open()
            With sccmdInsert
                Dim strNumero As String
                If IsNumeric(oRow!Talla) Then
                    'es un valor Numerico
                    If InStr(CStr(oRow!Talla), ".5") = 0 Then
                        'La formato para que qued si es 26.0  --> 26
                        strNumero = Format(CDec(oRow!Talla), "###0")
                    Else
                        'Se queda Igual es .5
                        strNumero = oRow!Talla
                    End If
                Else
                    'Es un Numero  XXL L M S
                    strNumero = oRow!Talla
                End If
                .Parameters("@CodArticulo").Value = oRow!CodArticulo
                .Parameters("@Numero").Value = strNumero
                .Parameters("@CodUPC").Value = CStr(oRow!CodUPC).PadLeft(18, "0")
                .Parameters("@CodArtProv").Value = oRow!CodArticulo

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

    Friend Sub InsertarUPC_From_Separaciones(ByVal oRow As DataRow)

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)
        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand
        With sccmdInsert
            .Connection = sccnnConnection
            .CommandText = "[UPCInsNuevo]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodUPC", System.Data.SqlDbType.VarChar, 20, "CodUPC"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodArticulo", System.Data.SqlDbType.VarChar, 20, "CodArticulo"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Numero", System.Data.SqlDbType.VarChar, 4, "Numero"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Descripcion", System.Data.SqlDbType.VarChar, 200, "Descripcion"))

        End With
        Try
            sccnnConnection.Open()
            With sccmdInsert
                Dim strNumero As String
                If IsNumeric(oRow!Talla) Then
                    'es un valor Numerico
                    If InStr(CStr(oRow!Talla), ".5") = 0 Then
                        'La formato para que qued si es 26.0  --> 26
                        strNumero = Format(CDec(oRow!Talla), "###0")
                    Else
                        'Se queda Igual es .5
                        strNumero = oRow!Talla
                    End If
                Else
                    'Es un Numero  XXL L M S
                    strNumero = oRow!Talla
                End If
                .Parameters("@CodArticulo").Value = oRow!CodArticulo
                .Parameters("@Numero").Value = strNumero
                .Parameters("@CodUPC").Value = CStr(oRow!CodUPC).PadLeft(18, "0")
                .Parameters("@Descripcion").Value = oRow!Descripcion

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

    Friend Sub InsertarUPCDirecto()

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)
        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand
        With sccmdInsert
            .Connection = sccnnConnection
            .CommandText = "[UPCSelServidor]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))

        End With
        Try
            sccnnConnection.Open()
            With sccmdInsert

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

#End Region

    Public Sub SaveDownloadBackground(ByVal oConfigCierreFI As ConfigSaveArchivos.SaveConfigArchivos, ByVal CodAlmacen As String, ByVal CodCaja As String)
        Dim connectionString As String = ""
        connectionString = "data source = " & oConfigCierreFI.ServerHuellas & "; initial catalog = " & _
                                oConfigCierreFI.BaseDatosHuellas & "; user id = " & _
                                oConfigCierreFI.UserHuellas & "; password = " & _
                                oConfigCierreFI.PassHuellas()
        Dim conexion As New SqlClient.SqlConnection(connectionString)
        Dim command As New SqlClient.SqlCommand '("UPDATE Download SET Download=@Download WHERE Sucursal=@Sucursal AND Caja=@Caja", conexion)
        command.CommandType = CommandType.StoredProcedure
        command.CommandText = "[DownloadIns]"
        command.Connection = conexion
        Try
            conexion.Open()
            command.Parameters.Add("@Download", True)
            command.Parameters.Add("@Sucursal", CodAlmacen.Trim)
            command.Parameters.Add("@Caja", CodCaja.Trim)
            command.ExecuteNonQuery()
            command.Dispose()
            conexion.Close()
        Catch sql As SqlClient.SqlException
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            'EscribeLog(sql.Message, "Error al insertar datos", sql)
            Throw New ApplicationException("Error al insertar datos", sql)
        Catch ex As Exception
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            'EscribeLog(ex.Message, "Error en aplicacion", ex)
            Throw New ApplicationException("Error en aplicación", ex)
        End Try
    End Sub

    Public Function IsDownloadBackground(ByVal oConfigCierreFI As ConfigSaveArchivos.SaveConfigArchivos, ByVal CodAlmacen As String, ByVal CodCaja As String) As Boolean
        Dim valido As Boolean = False
        Dim count As Integer = 0
        Dim connectionString As String = ""
        Dim reader As SqlClient.SqlDataReader = Nothing
        connectionString = "data source = " & oConfigCierreFI.ServerHuellas & "; initial catalog = " & _
                                oConfigCierreFI.BaseDatosHuellas & "; user id = " & _
                                oConfigCierreFI.UserHuellas & "; password = " & _
                                oConfigCierreFI.PassHuellas()
        Dim conexion As New SqlClient.SqlConnection(connectionString)
        Dim command As New SqlClient.SqlCommand '("SELECT Download FROM DownLoad WHERE Sucursal=@Sucursal AND Caja=@Caja", conexion)
        command.CommandType = CommandType.StoredProcedure
        command.CommandText = "[DownloadSel]"
        command.Connection = conexion
        Try
            conexion.Open()
            command.Parameters.Add("@Sucursal", CodAlmacen.Trim)
            command.Parameters.Add("@Caja", CodCaja.Trim)
            reader = command.ExecuteReader()
            While (reader.Read())
                valido = CBool(reader!Download)
            End While
            command.Dispose()
            conexion.Close()
        Catch sql As SqlClient.SqlException
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            'EscribeLog(sql.Message, "Error al descargar Imagen en descarga de datos", sql)
            Throw New ApplicationException("Error al descargar Imagen en descarga de datos", sql)
        Catch ex As Exception
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            'EscribeLog(ex.Message, "Error descargar imagen en aplicación", ex)
            Throw New ApplicationException("Error descargar imagen en aplicación", ex)
        End Try
        Return valido
    End Function

    Public Function IsDownloadAuditoria(ByVal CodAlmacen As String, ByVal Caja As String, ByVal fecha As Date) As Boolean
        Dim conexion As New SqlConnection(m_strConnectionString)
        Dim command As New SqlCommand("SELECT COUNT(*) FROM DescargasAuditoria WHERE CodAlmacen=@CodAlmacen AND Caja=@Caja AND Fecha=@Fecha", conexion)
        Dim count As Integer = 0
        Try
            conexion.Open()
            command.Parameters.Add("@CodAlmacen", CodAlmacen)
            command.Parameters.Add("@Caja", Caja)
            command.Parameters.Add("@Fecha", fecha.Today)
            count = CInt(command.ExecuteScalar())
            command.Dispose()
            conexion.Close()
        Catch sql As Exception
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            Throw New ApplicationException("Hubo un error en la base de datos", sql)
        Catch ex As Exception
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            Throw New ApplicationException("Hubo un error en la aplicación", ex)
        End Try
        Return IIf(count > 0, True, False)
    End Function

    Public Function InsertarDescargaAuditoria(ByVal CodAlmacen As String, ByVal Caja As String)
        Dim conexion As New SqlConnection(m_strConnectionString)
        Dim command As New SqlCommand("InsertarDescargaAuditoria", conexion)
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@CodAlmacen", CodAlmacen)
            command.Parameters.Add("@Caja", Caja)
            command.Parameters.Add("@Fecha", Date.Today)
            command.ExecuteNonQuery()
            command.Dispose()
            conexion.Close()
        Catch sql As SqlException
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            Throw New ApplicationException("Hubo un error en la base de datos", sql)
        Catch ex As Exception
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            Throw New ApplicationException("Hubo un error en la aplicación", ex)
        End Try
    End Function

    Public Sub InsertarPromoBonificacionDescuento(ByVal oRow As DataRow)
        Dim conexion As New SqlConnection(m_strConnectionString)
        Dim command As New SqlCommand("DescuentosAdicionalesInsBonificacionDescuento", conexion)
        Dim tipoventa As String = CStr(oRow!TiposDeVenta)
        Dim parameter As New SqlParameter("@DescuentoId", SqlDbType.Int)
        parameter.Direction = ParameterDirection.Output
        Try
            command.CommandType = CommandType.StoredProcedure
            conexion.Open()

            With command
                .Parameters.Add("@CodArticulo", CStr("BON"))
                .Parameters.Add("@FechaInicio", CDate(oRow!FechaInicio))
                .Parameters.Add("@FechaFin", CDate(oRow!FechaFin))
                .Parameters.Add("@Descuento", CDec(oRow!PorcentajeDescuento))
                .Parameters.Add(New SqlParameter("@P", SqlDbType.Bit))
                .Parameters.Add(New SqlParameter("@V", SqlDbType.Bit))
                .Parameters.Add(New SqlParameter("@I", SqlDbType.Bit))
                .Parameters.Add(New SqlParameter("@O", SqlDbType.Bit))
                .Parameters.Add(New SqlParameter("@F", SqlDbType.Bit))
                .Parameters.Add(New SqlParameter("@K", SqlDbType.Bit))
                .Parameters.Add(New SqlParameter("@S", SqlDbType.Bit))
                .Parameters.Add(New SqlParameter("@D", SqlDbType.Bit))
                .Parameters("@P").Value = IIf(tipoventa.IndexOf("P") <> -1, True, False)
                .Parameters("@V").Value = IIf(tipoventa.IndexOf("V") <> -1, True, False)
                .Parameters("@I").Value = IIf(tipoventa.IndexOf("I") <> -1, True, False)
                .Parameters("@O").Value = IIf(tipoventa.IndexOf("O") <> -1, True, False)
                .Parameters("@F").Value = IIf(tipoventa.IndexOf("F") <> -1, True, False)
                .Parameters("@K").Value = IIf(tipoventa.IndexOf("K") <> -1, True, False)
                .Parameters("@S").Value = IIf(tipoventa.IndexOf("S") <> -1, True, False)
                .Parameters("@D").Value = IIf(tipoventa.IndexOf("D") <> -1, True, False)
                .Parameters.Add(parameter)
                .ExecuteNonQuery()
            End With
            If Not IsDBNull(parameter.Value) Then
                Dim descuentoid As Integer = CInt(parameter.Value)
                With command
                    .Dispose()
                    .Parameters.Clear()
                    .CommandText = "InsertarDescuentoFormaPago"
                    .CommandType = CommandType.StoredProcedure
                    .Parameters.Add(New SqlParameter("@DescuentoId", SqlDbType.Int))
                    .Parameters.Add(New SqlParameter("@CodFormaPago", SqlDbType.VarChar))
                    Dim pagos() As String = CStr(oRow!FormasPago).Split(",")
                    For Each pago As String In pagos
                        If Not pago Is Nothing AndAlso pago.Trim <> "" Then
                            .Parameters("@DescuentoId").Value = descuentoid
                            .Parameters("@CodFormaPago").Value = pago
                            .ExecuteNonQuery()
                        End If
                    Next
                End With
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

    Public Function Read_promocionBonificacionDescuento(ByVal oConfigCierreFI As ConfigSaveArchivos.SaveConfigArchivos) As DataTable
        Dim connectionString As String = ""
        connectionString = "data source = " & oConfigCierreFI.ServerHuellas & "; initial catalog = " & _
                                oConfigCierreFI.BaseDatosHuellas & "; user id = " & _
                                oConfigCierreFI.UserHuellas & "; password = " & _
                                oConfigCierreFI.PassHuellas()
        Dim conexion As New SqlClient.SqlConnection(connectionString)
        Dim command As New SqlClient.SqlCommand("ReadDescuentoBonificacion", conexion)
        Dim adapter As SqlClient.SqlDataAdapter = Nothing
        Dim dtDescuentos As New DataTable
        Try
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@Tienda", oParent.ApplicationContext.ApplicationConfiguration.Almacen)
            conexion.Open()
            adapter = New SqlClient.SqlDataAdapter(command)
            adapter.Fill(dtDescuentos)
            command.Dispose()
            conexion.Close()
        Catch sql As Exception
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            Throw sql
        End Try
        Return dtDescuentos
    End Function

    Friend Sub InsertarRazonesRechazo(ByVal RazonID As Integer, ByVal Razon As String, ByVal Modulo As String)
        Dim sccnnConnection As New SqlConnection(m_strConnectionString)
        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand
        With sccmdInsert
            .Connection = sccnnConnection
            .CommandText = "[CatalogoRazonesIns]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RazonID", System.Data.SqlDbType.Int, 4, "RazonId"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Razon", System.Data.SqlDbType.VarChar, 250, "Razon"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Modulo", System.Data.SqlDbType.VarChar, 2, "Modulo"))

        End With
        Try
            sccnnConnection.Open()
            With sccmdInsert
                'Assign Parameters Values
                .Parameters("@RazonID").Value = RazonID
                .Parameters("@Razon").Value = Razon.Trim
                .Parameters("@Modulo").Value = Modulo.Trim.ToUpper

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

    Friend Sub InsertarCodigosPostales(ByVal oRow As DataRow)
        Dim sccnnConnection As New SqlConnection(m_strConnectionString)
        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand
        With sccmdInsert
            .Connection = sccnnConnection
            .CommandText = "[CatalogoCodigosPostalesIns]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.Int, 4, "ID"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CP", System.Data.SqlDbType.VarChar, 6, "CP"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Asentamiento", System.Data.SqlDbType.VarChar, 200, "Asentamiento"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TipoAsen", System.Data.SqlDbType.VarChar, 20, "TipoAsentamiento"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Municipio", System.Data.SqlDbType.VarChar, 50, "Municipio"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Estado", System.Data.SqlDbType.VarChar, 50, "Estado"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Ciudad", System.Data.SqlDbType.VarChar, 50, "Ciudad"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodEstado", System.Data.SqlDbType.Int, 6, "CodEstado"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodMun", System.Data.SqlDbType.Int, 4, "CodMunicipio"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Zona", System.Data.SqlDbType.VarChar, 50, "Zona"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCiudad", System.Data.SqlDbType.Int, 4, "CodCiudad"))
        End With
        Try
            sccnnConnection.Open()
            With sccmdInsert
                'Assign Parameters Values
                .Parameters("@ID").Value = oRow!ID
                .Parameters("@CP").Value = oRow!CP
                .Parameters("@Asentamiento").Value = oRow!Asentamiento
                .Parameters("@TipoAsen").Value = oRow!TipoAsentamiento
                .Parameters("@Municipio").Value = oRow!Municipio
                .Parameters("@Estado").Value = oRow!Estado
                .Parameters("@Ciudad").Value = oRow!Ciudad
                .Parameters("@CodEstado").Value = oRow!CodEstado
                .Parameters("@CodMun").Value = oRow!CodMunicipio
                .Parameters("@Zona").Value = oRow!Zona
                .Parameters("@CodCiudad").Value = oRow!CodCiudad

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

    Public Sub DeleteCatalogo(ByVal strCatalogo As String)

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand

        With sccmdInsert

            .Connection = sccnnConnection

            .CommandText = "Delete From " & strCatalogo
            .CommandType = System.Data.CommandType.Text
            .Connection = sccnnConnection

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))

        End With

        Try

            sccnnConnection.Open()

            With sccmdInsert

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

    Public Sub DeleteTotalesExistencia(Optional ByVal CodArticulo As String = "")

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand

        With sccmdInsert

            .Connection = sccnnConnection

            .CommandText = "[ExistenciasUpdBorraTotales]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Connection = sccnnConnection

            .Parameters.Add(New SqlParameter("@Codigo", SqlDbType.VarChar, 20, "CodArticulo"))

            .Parameters("@Codigo").Value = CodArticulo.Trim.ToUpper
        End With

        Try

            sccnnConnection.Open()

            With sccmdInsert

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

    Public Function SelectExistenciasAll(Optional ByVal CodArticulo As String = "") As DataTable

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaArticulos As SqlDataAdapter
        Dim dsArticulos As DataSet

        sccmdSelectAll = New SqlCommand
        scdaArticulos = New SqlDataAdapter
        dsArticulos = New DataSet("ExistenciaArticulos")

        With sccmdSelectAll

            .Connection = sccnnConnection
            .CommandText = "[ExistenciasSelAll]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New SqlParameter("@Codigo", SqlDbType.VarChar, 20, "CodArticulo"))

            .Parameters("@Codigo").Value = CodArticulo.Trim.ToUpper
        End With

        scdaArticulos.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            'Fill DataSet
            scdaArticulos.Fill(dsArticulos, "ExistenciaArticulos")

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

        Return dsArticulos.Tables(0)

    End Function

    Public Function SelectFoliosPickUp(ByVal Paqueteria As String, ByVal oConfigCierreFI As ConfigSaveArchivos.SaveConfigArchivos) As DataTable

        Dim m_strConnectionString As String = "Data Source = " & oConfigCierreFI.ServerSQLBroker & ";Initial Catalog = " & oConfigCierreFI.BaseDatosBroker & ";User ID = " & _
                                          oConfigCierreFI.UserBroker & ";Password = " & oConfigCierreFI.PasswordBroker & ";"

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaArticulos As SqlDataAdapter
        Dim dsFolios As DataSet

        sccmdSelectAll = New SqlCommand
        scdaArticulos = New SqlDataAdapter
        dsFolios = New DataSet("FoliosPickUp")

        With sccmdSelectAll

            .Connection = sccnnConnection
            .CommandText = "[PickUpSel]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New SqlParameter("@Paqueteria", SqlDbType.VarChar, 50))
            .Parameters.Add(New SqlParameter("@Tienda", SqlDbType.NChar, 10))

            .Parameters("@Tienda").Value = "T" & oParent.ApplicationContext.ApplicationConfiguration.Almacen
            .Parameters("@Paqueteria").Value = Paqueteria.Trim
        End With

        scdaArticulos.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            'Fill DataSet
            scdaArticulos.Fill(dsFolios, "FoliosPickUp")

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

        Return dsFolios.Tables(0)

    End Function


    Public Sub UpdateExistenciaSAPCAR(ByVal CodArticulo As String, ByVal Total As Decimal, ByVal Apartados As Decimal, ByVal Defectuosos As Decimal, ByVal Consignacion As Decimal, ByVal Transito As Decimal)
        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand

        With sccmdInsert

            .Connection = sccnnConnection

            .CommandText = "[ExistenciasUpdFromSAPCAR]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Connection = sccnnConnection

            .Parameters.Add(New SqlParameter("@CodAlmacen", SqlDbType.VarChar, 3, "CodAlmacen"))
            .Parameters.Add(New SqlParameter("@CodArticulo", SqlDbType.VarChar, 20, "CodArticulo"))
            .Parameters.Add(New SqlParameter("@Total", SqlDbType.Decimal, 9, "Total"))
            .Parameters.Add(New SqlParameter("@Apartados", SqlDbType.Decimal, 9, "Apartados"))
            .Parameters.Add(New SqlParameter("@Defectuosos", SqlDbType.Decimal, 9, "Defectuosos"))
            .Parameters.Add(New SqlParameter("@Consignacion", SqlDbType.Decimal, 9, "Consignacion"))
            .Parameters.Add(New SqlParameter("@Transito", SqlDbType.Decimal, 9, "Transito"))


            .Parameters("@CodAlmacen").Value = oParent.ApplicationContext.ApplicationConfiguration.Almacen
            .Parameters("@CodArticulo").Value = CodArticulo
            .Parameters("@Total").Value = Total + Apartados + Defectuosos + Consignacion
            .Parameters("@Apartados").Value = Apartados
            .Parameters("@Defectuosos").Value = Defectuosos
            .Parameters("@Consignacion").Value = Consignacion
            .Parameters("@Transito").Value = Transito


            Try

                sccnnConnection.Open()

                With sccmdInsert

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



        End With
    End Sub


    Public Sub UpdateExistenciaSAP(ByVal CodArticulo As String, ByVal Total As Decimal, ByVal Apartados As Decimal, ByVal Defectuosos As Decimal, ByVal Numero As String)
        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand

        With sccmdInsert

            .Connection = sccnnConnection

            .CommandText = "[ExistenciasUpdFromSAP]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Connection = sccnnConnection

            .Parameters.Add(New SqlParameter("@CodAlmacen", SqlDbType.VarChar, 3, "CodAlmacen"))
            .Parameters.Add(New SqlParameter("@CodArticulo", SqlDbType.VarChar, 20, "CodArticulo"))
            .Parameters.Add(New SqlParameter("@Total", SqlDbType.Decimal, 9, "Total"))
            .Parameters.Add(New SqlParameter("@Apartados", SqlDbType.Decimal, 9, "Apartados"))
            .Parameters.Add(New SqlParameter("@Defectuosos", SqlDbType.Decimal, 9, "Defectuosos"))
            .Parameters.Add(New SqlParameter("@Numero", SqlDbType.VarChar, 10, "Numero"))

            .Parameters("@CodAlmacen").Value = oParent.ApplicationContext.ApplicationConfiguration.Almacen
            .Parameters("@CodArticulo").Value = CodArticulo
            .Parameters("@Total").Value = Total
            .Parameters("@Apartados").Value = Apartados
            .Parameters("@Defectuosos").Value = Defectuosos
            .Parameters("@Numero").Value = Numero


            Try

                sccnnConnection.Open()

                With sccmdInsert

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

        End With
    End Sub


    Public Sub UpdateInsertExistencias(ByVal oRow As DataRow)
        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand

        With sccmdInsert

            .Connection = sccnnConnection

            .CommandText = "[ExistenciasUpdIns]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Connection = sccnnConnection

            .Parameters.Add(New SqlParameter("@CodAlmacen", SqlDbType.VarChar, 3, "CodAlmacen"))
            .Parameters.Add(New SqlParameter("@CodArticulo", SqlDbType.VarChar, 20, "CodArticulo"))
            .Parameters.Add(New SqlParameter("@Total", SqlDbType.Decimal, 10, "Total"))
            .Parameters.Add(New SqlParameter("@Apartados", SqlDbType.Decimal, 10, "Apartados"))
            .Parameters.Add(New SqlParameter("@Defectuosos", SqlDbType.Decimal, 10, "Defectuosos"))
            .Parameters.Add(New SqlParameter("@Numero", SqlDbType.VarChar, 10, "Numero"))
            .Parameters.Add(New SqlParameter("@Promocion", SqlDbType.Decimal, 10, "Promocion"))
            .Parameters.Add(New SqlParameter("@VtasEspeciales", SqlDbType.Decimal, 10, "VtasEspeciales"))
            .Parameters.Add(New SqlParameter("@Consignacion", SqlDbType.Decimal, 10, "Consignacion"))
            .Parameters.Add(New SqlParameter("@Transito", SqlDbType.Decimal, 10, "Transito"))
            .Parameters.Add(New SqlParameter("@Saldo_1", SqlDbType.Decimal, 10, "Saldo_1"))
            .Parameters.Add(New SqlParameter("@Entro_1", SqlDbType.Decimal, 10, "Entro_1"))
            .Parameters.Add(New SqlParameter("@Salio_1", SqlDbType.Decimal, 10, "Salio_1"))
            .Parameters.Add(New SqlParameter("@Saldo_2", SqlDbType.Decimal, 10, "Saldo_2"))
            .Parameters.Add(New SqlParameter("@Entro_2", SqlDbType.Decimal, 10, "Entro_2"))
            .Parameters.Add(New SqlParameter("@Salio_2", SqlDbType.Decimal, 10, "Salio_2"))
            .Parameters.Add(New SqlParameter("@Saldo_3", SqlDbType.Decimal, 10, "Saldo_3"))
            .Parameters.Add(New SqlParameter("@Entro_3", SqlDbType.Decimal, 10, "Entro_3"))
            .Parameters.Add(New SqlParameter("@Salio_3", SqlDbType.Decimal, 10, "Salio_3"))
            .Parameters.Add(New SqlParameter("@Saldo_4", SqlDbType.Decimal, 10, "Saldo_4"))
            .Parameters.Add(New SqlParameter("@Entro_4", SqlDbType.Decimal, 10, "Entro_4"))
            .Parameters.Add(New SqlParameter("@Salio_4", SqlDbType.Decimal, 10, "Salio_4"))
            .Parameters.Add(New SqlParameter("@Saldo_5", SqlDbType.Decimal, 10, "Saldo_5"))
            .Parameters.Add(New SqlParameter("@Entro_5", SqlDbType.Decimal, 10, "Entro_5"))
            .Parameters.Add(New SqlParameter("@Salio_5", SqlDbType.Decimal, 10, "Salio_5"))
            .Parameters.Add(New SqlParameter("@Saldo_6", SqlDbType.Decimal, 10, "Saldo_6"))
            .Parameters.Add(New SqlParameter("@Entro_6", SqlDbType.Decimal, 10, "Entro_6"))
            .Parameters.Add(New SqlParameter("@Salio_6", SqlDbType.Decimal, 10, "Salio_6"))
            .Parameters.Add(New SqlParameter("@Saldo_7", SqlDbType.Decimal, 10, "Saldo_7"))
            .Parameters.Add(New SqlParameter("@Entro_7", SqlDbType.Decimal, 10, "Entro_7"))
            .Parameters.Add(New SqlParameter("@Salio_7", SqlDbType.Decimal, 10, "Salio_7"))
            .Parameters.Add(New SqlParameter("@Saldo_8", SqlDbType.Decimal, 10, "Saldo_8"))
            .Parameters.Add(New SqlParameter("@Entro_8", SqlDbType.Decimal, 10, "Entro_8"))
            .Parameters.Add(New SqlParameter("@Salio_8", SqlDbType.Decimal, 10, "Salio_8"))
            .Parameters.Add(New SqlParameter("@Saldo_9", SqlDbType.Decimal, 10, "Saldo_9"))
            .Parameters.Add(New SqlParameter("@Entro_9", SqlDbType.Decimal, 10, "Entro_9"))
            .Parameters.Add(New SqlParameter("@Salio_9", SqlDbType.Decimal, 10, "Salio_9"))
            .Parameters.Add(New SqlParameter("@Saldo_10", SqlDbType.Decimal, 10, "Saldo_10"))
            .Parameters.Add(New SqlParameter("@Entro_10", SqlDbType.Decimal, 10, "Entro_10"))
            .Parameters.Add(New SqlParameter("@Salio_10", SqlDbType.Decimal, 10, "Salio_10"))
            .Parameters.Add(New SqlParameter("@Saldo_11", SqlDbType.Decimal, 10, "Saldo_11"))
            .Parameters.Add(New SqlParameter("@Entro_11", SqlDbType.Decimal, 10, "Entro_11"))
            .Parameters.Add(New SqlParameter("@Salio_11", SqlDbType.Decimal, 10, "Salio_11"))
            .Parameters.Add(New SqlParameter("@Saldo_12", SqlDbType.Decimal, 10, "Saldo_12"))
            .Parameters.Add(New SqlParameter("@Entro_12", SqlDbType.Decimal, 10, "Entro_12"))
            .Parameters.Add(New SqlParameter("@Salio_12", SqlDbType.Decimal, 10, "Salio_12"))
            .Parameters.Add(New SqlParameter("@CodLinea", SqlDbType.VarChar, 2, "CodLinea"))
            .Parameters.Add(New SqlParameter("@CodMarca", SqlDbType.VarChar, 2, "CodMarca"))
            .Parameters.Add(New SqlParameter("@CodFamilia", SqlDbType.VarChar, 2, "CodFamilia"))
            .Parameters.Add(New SqlParameter("@CodUso", SqlDbType.VarChar, 8, "CodUso"))
            .Parameters.Add(New SqlParameter("@CodCategoria", SqlDbType.VarChar, 10, "CodCategoria"))
            .Parameters.Add(New SqlParameter("@Costo", SqlDbType.Money, 8, "Costo"))
            .Parameters.Add(New SqlParameter("@FUC", SqlDbType.DateTime, 8, "FUC"))
            .Parameters.Add(New SqlParameter("@FUM", SqlDbType.DateTime, 8, "FUM"))
            .Parameters.Add(New SqlParameter("@FUT", SqlDbType.DateTime, 8, "FUT"))
            .Parameters.Add(New SqlParameter("@Usuario", SqlDbType.VarChar, 12, "Usuario"))
            .Parameters.Add(New SqlParameter("@StatusRegistro", SqlDbType.Bit, 1, "StatusRegistro"))
            .Parameters.Add(New SqlParameter("@ID_DPPRO", SqlDbType.VarChar, 62, "ID_DPPRO"))
            .Parameters.Add(New SqlParameter("@Color", SqlDbType.VarChar, 62, "Color"))
            .Parameters.Add(New SqlParameter("@G_Mercancia", SqlDbType.Int, 4, "g_mercancia"))


            Dim strNumero As String


            If IsNumeric(oRow!J_3ASIZE) Then
                If InStr(CStr(oRow!J_3ASIZE), ".5") = 0 Then
                    strNumero = Format(CDec(oRow!J_3ASIZE), "###0")
                Else
                    strNumero = oRow!J_3ASIZE
                End If
            Else
                strNumero = oRow!J_3ASIZE
            End If
            Dim G_merc As String = ""
            Dim ArrayID() As String
            ArrayID = Split(oRow!ID_MATR, "-")
            Dim valStr As String
            valStr = oRow!ID_MATR
            If valStr.Length > 0 Then
                valStr = Microsoft.VisualBasic.Right(oRow!ID_MATR, 1)
            End If
            If valStr <> "-" Then
                If ArrayID.Length >= 3 Then
                    G_merc = ArrayID(ArrayID.Length - 1)
                End If
            End If

            'strLinea = oRow!MATNR & ";" & CDec(oRow!LABST) + CDec(oRow!DEFECTUOSO) + CDec(oRow!APARTADO) + CDec(oRow!KLABS) & ";" & oApplicationContext.ApplicationConfiguration.Almacen & ";" & _
            '                oApplicationContext.Security.CurrentUser.SessionLoginName & ";" & Mid(CStr(oRow!PRDHA), 5, 4) & _
            '                ";" & CStr(oRow!KLABS).Trim & ";" & Mid(CStr(oRow!PRDHA), 13, 6) & ";" & Mid(CStr(oRow!PRDHA), 1, 4) & ";;" & oRow!STPRS & _
            '                ";;;" & CDec(oRow!APARTADO) & ";;" & strNumero & ";" & CDec(oRow!DEFECTUOSO) & ";;;;" & oRow!MATKL & ";" &
            '                  oRow!ID_MATR & ";" & oRow!COLORES & ";" & G_merc  ' SF EAHM 13/06/2016

            .Parameters("@CodAlmacen").Value = oParent.ApplicationContext.ApplicationConfiguration.Almacen
            .Parameters("@CodArticulo").Value = oRow!MATNR
            .Parameters("@Total").Value = CDec(oRow!LABST) + CDec(oRow!DEFECTUOSO) + CDec(oRow!APARTADO) + CDec(oRow!KLABS)
            .Parameters("@Apartados").Value = oRow!APARTADO
            .Parameters("@Defectuosos").Value = oRow!DEFECTUOSO
            .Parameters("@Numero").Value = strNumero
            .Parameters("@Promocion").Value = 0
            .Parameters("@VtasEspeciales").Value = 0
            .Parameters("@Consignacion").Value = 0
            .Parameters("@Transito").Value = 0

            .Parameters("@Saldo_1").Value = CDec(oRow!LABST) + CDec(oRow!DEFECTUOSO) + CDec(oRow!APARTADO) + CDec(oRow!KLABS)
            .Parameters("@Entro_1").Value = 0
            .Parameters("@Salio_1").Value = 0
            .Parameters("@Saldo_2").Value = CDec(oRow!LABST) + CDec(oRow!DEFECTUOSO) + CDec(oRow!APARTADO) + CDec(oRow!KLABS)
            .Parameters("@Entro_2").Value = 0
            .Parameters("@Salio_2").Value = 0
            .Parameters("@Saldo_3").Value = CDec(oRow!LABST) + CDec(oRow!DEFECTUOSO) + CDec(oRow!APARTADO) + CDec(oRow!KLABS)
            .Parameters("@Entro_3").Value = 0
            .Parameters("@Salio_3").Value = 0
            .Parameters("@Saldo_4").Value = CDec(oRow!LABST) + CDec(oRow!DEFECTUOSO) + CDec(oRow!APARTADO) + CDec(oRow!KLABS)
            .Parameters("@Entro_4").Value = 0
            .Parameters("@Salio_4").Value = 0
            .Parameters("@Saldo_5").Value = CDec(oRow!LABST) + CDec(oRow!DEFECTUOSO) + CDec(oRow!APARTADO) + CDec(oRow!KLABS)
            .Parameters("@Entro_5").Value = 0
            .Parameters("@Salio_5").Value = 0
            .Parameters("@Saldo_6").Value = CDec(oRow!LABST) + CDec(oRow!DEFECTUOSO) + CDec(oRow!APARTADO) + CDec(oRow!KLABS)
            .Parameters("@Entro_6").Value = 0
            .Parameters("@Salio_6").Value = 0
            .Parameters("@Saldo_7").Value = CDec(oRow!LABST) + CDec(oRow!DEFECTUOSO) + CDec(oRow!APARTADO) + CDec(oRow!KLABS)
            .Parameters("@Entro_7").Value = 0
            .Parameters("@Salio_7").Value = 0
            .Parameters("@Saldo_8").Value = CDec(oRow!LABST) + CDec(oRow!DEFECTUOSO) + CDec(oRow!APARTADO) + CDec(oRow!KLABS)
            .Parameters("@Entro_8").Value = 0
            .Parameters("@Salio_8").Value = 0
            .Parameters("@Saldo_9").Value = CDec(oRow!LABST) + CDec(oRow!DEFECTUOSO) + CDec(oRow!APARTADO) + CDec(oRow!KLABS)
            .Parameters("@Entro_9").Value = 0
            .Parameters("@Salio_9").Value = 0
            .Parameters("@Saldo_10").Value = CDec(oRow!LABST) + CDec(oRow!DEFECTUOSO) + CDec(oRow!APARTADO) + CDec(oRow!KLABS)
            .Parameters("@Entro_10").Value = 0
            .Parameters("@Salio_10").Value = 0
            .Parameters("@Saldo_11").Value = CDec(oRow!LABST) + CDec(oRow!DEFECTUOSO) + CDec(oRow!APARTADO) + CDec(oRow!KLABS)
            .Parameters("@Entro_11").Value = 0
            .Parameters("@Salio_11").Value = 0
            .Parameters("@Saldo_12").Value = CDec(oRow!LABST) + CDec(oRow!DEFECTUOSO) + CDec(oRow!APARTADO) + CDec(oRow!KLABS)
            .Parameters("@Entro_12").Value = 0
            .Parameters("@Salio_12").Value = 0

            .Parameters("@CodLinea").Value = Mid(CStr(oRow!PRDHA), 5, 4)
            .Parameters("@CodMarca").Value = oRow!MATKL   'CStr(oRow!KLABS).Trim
            .Parameters("@CodFamilia").Value = Mid(CStr(oRow!PRDHA), 1, 4)
            .Parameters("@CodUso").Value = ""
            .Parameters("@Costo").Value = oRow!STPRS
            .Parameters("@CodCategoria").Value = Mid(CStr(oRow!PRDHA), 13, 6)

            .Parameters("@FUC").Value = DBNull.Value
            .Parameters("@FUM").Value = DBNull.Value
            .Parameters("@FUT").Value = DBNull.Value
            .Parameters("@Usuario").Value = oParent.ApplicationContext.ApplicationConfiguration.Usuario
            .Parameters("@StatusRegistro").Value = 1

            .Parameters("@ID_DPPRO").Value = oRow!ID_MATR
            .Parameters("@Color").Value = oRow!COLORES
            .Parameters("@G_Mercancia").Value = G_merc



            Try

                sccnnConnection.Open()

                With sccmdInsert

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

        End With
    End Sub


    Public Sub UpdateCostoPromedio(ByVal dtArticulos As DataTable, ByVal Opcion As Integer)
        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand

        With sccmdInsert

            .Connection = sccnnConnection

            .CommandText = "[CatalogoArticulosCostoPromUpd]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Connection = sccnnConnection

            .Parameters.Add(New SqlParameter("@CodArticulo", SqlDbType.VarChar, 20, "CodArticulo"))
            .Parameters.Add(New SqlParameter("@Costo", SqlDbType.Decimal, 9, "Costo"))
            .Parameters.Add(New SqlParameter("@Opcion", SqlDbType.Int, 4, "Opcion"))


            Try

                sccnnConnection.Open()

                With sccmdInsert

                    For Each oRow As DataRow In dtArticulos.Rows
                        .Parameters("@CodArticulo").Value = oRow!Material
                        .Parameters("@Costo").Value = oRow!Importe
                        .Parameters("@Opcion").Value = Opcion
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

        End With
    End Sub


    Public Sub UpdateCondicionesVenta(ByVal dtArticulos As DataTable)
        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand

        With sccmdInsert

            .Connection = sccnnConnection

            .CommandText = "[CondicionesVentaInsUpd]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Connection = sccnnConnection

            .Parameters.Add(New SqlParameter("@Condicion", SqlDbType.VarChar, 4, "Condicion"))
            .Parameters.Add(New SqlParameter("@OrgVtas", SqlDbType.VarChar, 4, "OrgVtas"))
            .Parameters.Add(New SqlParameter("@CanalDist", SqlDbType.VarChar, 2, "CanalDist"))
            .Parameters.Add(New SqlParameter("@Jerarquia", SqlDbType.VarChar, 18, "Jerarquia"))
            .Parameters.Add(New SqlParameter("@CondMat", SqlDbType.VarChar, 2, "CondMat"))
            .Parameters.Add(New SqlParameter("@CondPrec", SqlDbType.VarChar, 2, "CondPrec"))
            .Parameters.Add(New SqlParameter("@Material", SqlDbType.VarChar, 18, "Material"))
            .Parameters.Add(New SqlParameter("@OficinaVtas", SqlDbType.VarChar, 4, "OficinVtas"))
            .Parameters.Add(New SqlParameter("@ListPrec", SqlDbType.VarChar, 4, "@ListPrec"))
            .Parameters.Add(New SqlParameter("@FechaIni", SqlDbType.DateTime, 8, "FechaIni"))
            .Parameters.Add(New SqlParameter("@FechaFin", SqlDbType.DateTime, 8, "FechaFin"))
            .Parameters.Add(New SqlParameter("@DescPorcentaje", SqlDbType.Decimal, 9, "DescPorcentaje"))
            .Parameters.Add(New SqlParameter("@Descmonto", SqlDbType.Decimal, 9, "Descmonto"))


            Try

                sccnnConnection.Open()

                With sccmdInsert
                    Dim DescPorc As Decimal = 0, DescMonto As Decimal = 0, strCondVta = ""
                    For Each oRow As DataRow In dtArticulos.Rows

                        strCondVta = oRow!CondVta
                        If strCondVta = "Z501" Then
                            DescPorc = 0
                            DescMonto = Math.Round(Math.Abs(oRow!Importe), 2)
                        Else
                            If strCondVta = "ZDP1" OrElse strCondVta = "Z522" Then
                                DescPorc = Math.Round(Math.Abs(CDec(oRow!Importe) / 10), 2)
                                DescMonto = 0
                            End If
                        End If


                        .Parameters("@Condicion").Value = strCondVta
                        .Parameters("@OrgVtas").Value = "CDPT"
                        .Parameters("@CanalDist").Value = "T1"
                        .Parameters("@Jerarquia").Value = IIf(CStr(oRow!Jerarquia.Trim Is DBNull.Value), "", oRow!Jerarquia)

                        .Parameters("@CondMat").Value = IIf(CStr(oRow!GpoMater.Trim Is DBNull.Value), "", oRow!GpoMater)
                        .Parameters("@CondPrec").Value = IIf(CStr(oRow!GpoPrecios.Trim Is DBNull.Value), "", oRow!GpoPrecios)
                        .Parameters("@Material").Value = oRow!Material
                        .Parameters("@OficinaVtas").Value = IIf(CStr(oRow!OficinaVentas.Trim Is DBNull.Value), "", oRow!OficinaVentas)
                        .Parameters("@ListPrec").Value = IIf(CStr(oRow!ListaPrecios.Trim Is DBNull.Value), "", oRow!ListaPrecios)
                        .Parameters("@FechaIni").Value = Format(oRow!FechaIni, "yyyy-MM-dd")
                        .Parameters("@FechaFin").Value = Format(oRow!FechaFin, "yyyy-MM-dd")
                        .Parameters("@DescPorcentaje").Value = DescPorc
                        .Parameters("@Descmonto").Value = DescMonto
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

        End With
    End Sub




    Public Sub InsertUpdCatalogoArticulos(ByVal dtArticulos As DataTable)
        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand

        With sccmdInsert

            .Connection = sccnnConnection

            .CommandText = "[CatalogoArticulosInsUpd]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Connection = sccnnConnection

            .Parameters.Add(New SqlParameter("@CodArticulo", SqlDbType.VarChar, 20, "CodArticulo"))
            .Parameters.Add(New SqlParameter("@CodArtProv", SqlDbType.VarChar, 50, "CodArtProv"))
            .Parameters.Add(New SqlParameter("@Descripcion", SqlDbType.VarChar, 100, "Descripcion"))
            .Parameters.Add(New SqlParameter("@CodLinea", SqlDbType.VarChar, 10, "CodLinea"))
            .Parameters.Add(New SqlParameter("@CodCorrida", SqlDbType.VarChar, 25, "CodCorrida"))
            .Parameters.Add(New SqlParameter("@CodCategoria", SqlDbType.VarChar, 10, "CodCategoria"))
            .Parameters.Add(New SqlParameter("@CodFamilia", SqlDbType.VarChar, 10, "CodFamilia"))
            .Parameters.Add(New SqlParameter("@CodUso", SqlDbType.VarChar, 8, "CodUso"))
            .Parameters.Add(New SqlParameter("@CodMarca", SqlDbType.VarChar, 10, "CodMarca"))
            .Parameters.Add(New SqlParameter("@CostoProm", SqlDbType.Decimal, 9, "CostoProm"))
            .Parameters.Add(New SqlParameter("@MargenUtilidad", SqlDbType.Decimal, 9, "MargenUtilidad"))
            .Parameters.Add(New SqlParameter("@PrecioVenta", SqlDbType.Decimal, 9, "PrecioVenta"))
            .Parameters.Add(New SqlParameter("@Descuento", SqlDbType.Decimal, 9, "Descuento"))
            .Parameters.Add(New SqlParameter("@PrecioOferta", SqlDbType.Decimal, 9, "PrecioOferta"))
            .Parameters.Add(New SqlParameter("@CodUnidadCom", SqlDbType.VarChar, 3, "CodUnidadCom"))
            .Parameters.Add(New SqlParameter("@CodUnidadVta", SqlDbType.VarChar, 3, "CodUnidadVta"))
            .Parameters.Add(New SqlParameter("@CodMonedaCom", SqlDbType.Int, 4, "CodMonedaCom"))
            .Parameters.Add(New SqlParameter("@CodMonedaVta", SqlDbType.Int, 4, "CodMonedaVta"))
            .Parameters.Add(New SqlParameter("@ImpCodBarra", SqlDbType.Bit, 1, "ImpCodBarra"))
            .Parameters.Add(New SqlParameter("@Jerarquia", SqlDbType.VarChar, 18, "Jerarquia"))
            .Parameters.Add(New SqlParameter("@PrecioIva", SqlDbType.Decimal, 9, "PrecioIva"))
            .Parameters.Add(New SqlParameter("@Dip", SqlDbType.Bit, 1, "Dip"))
            .Parameters.Add(New SqlParameter("@CodigoAnterior", SqlDbType.VarChar, 35, "CodigoAnterior"))
            .Parameters.Add(New SqlParameter("@PrecioSocio", SqlDbType.Decimal, 9, "PrecioSocio"))
            .Parameters.Add(New SqlParameter("@CodElectronico", SqlDbType.VarChar, 2, "CodElectronico"))

            Try
                sccnnConnection.Open()

                With sccmdInsert
                    Dim strCodCat As String = "", Dip As Integer = 0, gpomcia As String = ""

                    For Each oRow As DataRow In dtArticulos.Rows

                        If Mid(CStr(oRow!PRDHA), 13, 6) = "" Then
                            strCodCat = "0"
                        Else
                            strCodCat = Mid(CStr(oRow!PRDHA), 13, 6)
                        End If

                        If CStr(oRow!FORMT).Trim <> "" Then
                            If IsNumeric(CStr(oRow!FORMT).Trim) AndAlso CInt(CStr(oRow!FORMT).Trim) = 1 Then
                                Dip = 1
                            End If
                        Else
                            Dip = 0
                        End If
                        If CStr(oRow!WGLIF).Trim() <> "" Then
                            If IsNumeric(oRow!WGLIF) Then
                                If CInt(oRow!WGLIF) > 0 Then
                                    gpomcia = "-" & CStr(oRow!WGLIF)
                                Else
                                    gpomcia = ""
                                End If
                            Else
                                gpomcia = "-" & CStr(oRow!WGLIF)
                            End If
                        Else
                            gpomcia = ""
                        End If

                        Dim productName As String = CStr(oRow!MAKTX).Trim
                        Dim product1 As String = productName.Trim.Replace(",", " ")
                        Dim product2 As String = product1.Trim.Replace("'", "")

                        .Parameters("@CodArticulo").Value = oRow!MATNR
                        .Parameters("@CodArtProv").Value = oRow!IDNLF & gpomcia
                        .Parameters("@Descripcion").Value = product2
                        .Parameters("@CodLinea").Value = Mid(CStr(oRow!PRDHA), 5, 4)
                        .Parameters("@CodCorrida").Value = oRow!J_3APGNR
                        .Parameters("@CodCategoria").Value = strCodCat
                        .Parameters("@CodFamilia").Value = Mid(CStr(oRow!PRDHA), 1, 4)
                        .Parameters("@CodUso").Value = Mid(CStr(oRow!PRDHA), 9, 4)
                        .Parameters("@CodMarca").Value = oRow!MATKL
                        .Parameters("@CostoProm").Value = oRow!STPRS
                        .Parameters("@MargenUtilidad").Value = 0
                        .Parameters("@PrecioVenta").Value = oRow!STPRS
                        .Parameters("@Descuento").Value = 0
                        .Parameters("@PrecioOferta").Value = 0
                        .Parameters("@CodUnidadCom").Value = oRow!MEINS
                        .Parameters("@CodUnidadVta").Value = oRow!MEINS
                        .Parameters("@CodMonedaCom").Value = 0
                        .Parameters("@CodMonedaVta").Value = 0
                        .Parameters("@ImpCodBarra").Value = 0
                        .Parameters("@Jerarquia").Value = oRow!PRDHA
                        .Parameters("@PrecioIva").Value = 0
                        .Parameters("@Dip").Value = Dip
                        .Parameters("@CodigoAnterior").Value = oRow!IDNLF & gpomcia
                        .Parameters("@PrecioSocio").Value = 0
                        .Parameters("@CodElectronico").Value = 0
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

        End With
    End Sub


    Public Sub InsertUpdCatalogoUPC(ByVal dtArticulos As DataTable)
        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand

        With sccmdInsert

            .Connection = sccnnConnection

            .CommandText = "[CatalogUPCInsUpd]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Connection = sccnnConnection


            .Parameters.Add(New SqlParameter("@CodUPC", SqlDbType.VarChar, 20, "CodUPC"))
            .Parameters.Add(New SqlParameter("@CodArticulo", SqlDbType.VarChar, 20, "CodArticulo"))
            .Parameters.Add(New SqlParameter("@Numero", SqlDbType.VarChar, 10, "Numero"))
            .Parameters.Add(New SqlParameter("@CodArtProv", SqlDbType.VarChar, 20, "CodArtProv"))
            .Parameters.Add(New SqlParameter("@Descripcion", SqlDbType.VarChar, 200, "Descripcion"))
           
            Try
                sccnnConnection.Open()

                With sccmdInsert
                
                    For Each oRow As DataRow In dtArticulos.Rows
                        Dim folio As String = ""

                        If oRow!EAN11 <> "" Then
                            folio = oRow!EAN11
                            .Parameters("@CodUPC").Value = folio.PadLeft(18, "0")
                        End If

                        .Parameters("@CodArticulo").Value = oRow!MATNR
                        .Parameters("@Numero").Value = oRow!TALLA
                        .Parameters("@CodArtProv").Value = oRow!MATNR
                        .Parameters("@Descripcion").Value = oRow!MAKTX
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

        End With
    End Sub


    Public Sub UpdateSaldosExistencia(ByVal Mes As Integer)

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand

        With sccmdInsert

            .Connection = sccnnConnection

            .CommandText = "[ExistenciasUpdSaldos]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Connection = sccnnConnection

            .Parameters.Add(New SqlParameter("@Mes", SqlDbType.VarChar, 2, "Mes Actual"))

            .Parameters("@Mes").Value = CStr(Mes)
        End With

        Try

            sccnnConnection.Open()

            With sccmdInsert

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

    Public Sub UpdateSaldosExistenciaByCodigo(ByVal CodArticulo As String, ByVal Numero As String, ByVal Mes As Integer)

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand

        With sccmdInsert

            .Connection = sccnnConnection

            .CommandText = "[ExistenciasUpdSaldosByCodigo]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Connection = sccnnConnection

            .Parameters.Add(New SqlParameter("@Codigo", SqlDbType.VarChar, 20, "CodArticulo"))
            .Parameters.Add(New SqlParameter("@Numero", SqlDbType.VarChar, 4, "Talla"))
            .Parameters.Add(New SqlParameter("@Mes", SqlDbType.VarChar, 2, "Mes Actual"))

            .Parameters("@Codigo").Value = CodArticulo.Trim.ToUpper
            .Parameters("@Numero").Value = Numero.ToUpper.Trim
            .Parameters("@Mes").Value = CStr(Mes)
        End With

        Try

            sccnnConnection.Open()

            With sccmdInsert

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

    Public Sub UpdateFechasDescuentoSistema(ByVal CodArticulo As String)

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand

        With sccmdInsert

            .Connection = sccnnConnection

            .CommandText = "[CondicionesVentaUpdFechas]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Connection = sccnnConnection

            .Parameters.Add(New SqlParameter("@Codigo", SqlDbType.VarChar, 20, "CodArticulo"))

            .Parameters("@Codigo").Value = CodArticulo.Trim.ToUpper
        End With

        Try

            sccnnConnection.Open()

            With sccmdInsert

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

    Public Function ApartadosDefectuosos() As DataSet

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim scReporteInventarioAdapter As New SqlDataAdapter
        Dim dsResult As New DataSet

        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand
        scReporteInventarioAdapter.SelectCommand = sccmdInsert

        With sccmdInsert
            .Connection = sccnnConnection
            .CommandText = "[ValidarDefecApart]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Connection = sccnnConnection
        End With

        Try

            sccnnConnection.Open()

            scReporteInventarioAdapter.Fill(dsResult)

            Return dsResult


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
        Return Nothing

    End Function

#Region "Descuentos Diarios"

    Public Function SeleccionaArticulos(ByVal group As Boolean, Optional ByVal bolaccText As Boolean = False) As DataSet

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaArticulos As SqlDataAdapter
        Dim dsArticulos As DataSet



        sccmdSelectAll = New SqlCommand
        scdaArticulos = New SqlDataAdapter
        dsArticulos = New DataSet("Articulos")

        With sccmdSelectAll

            .Connection = sccnnConnection
            If bolaccText Then
                .CommandText = "[ArticulosConDescuentoSINTEXTACCSel]"
            Else
                If group Then
                    .CommandText = "[ArticulosConDescuentoSelGrupos]"
                Else
                    .CommandText = "[ArticulosConDescuentoSel]"
                End If
            End If
            .CommandType = System.Data.CommandType.StoredProcedure
        End With

        scdaArticulos.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            'Fill DataSet
            scdaArticulos.Fill(dsArticulos, "Articulos")

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

        Return dsArticulos

    End Function

    Public Sub SelectCondicionVenta(ByVal oCondicionVenta As CondicionesVtaSAP)

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[CondicionesVentaFacturaSel]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@OficinaVtas", System.Data.SqlDbType.VarChar, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Jerarquia", System.Data.SqlDbType.VarChar, 18))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CondMat", System.Data.SqlDbType.VarChar, 2))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CondPrec", System.Data.SqlDbType.VarChar, 2))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Material", System.Data.SqlDbType.VarChar, 18))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ListPrec", System.Data.SqlDbType.VarChar, 2))

            .Parameters("@OficinaVtas").Value = oCondicionVenta.OficinaVtas
            .Parameters("@Jerarquia").Value = oCondicionVenta.Jerarquia
            .Parameters("@CondMat").Value = oCondicionVenta.CondMat
            .Parameters("@CondPrec").Value = oCondicionVenta.CondPrec
            .Parameters("@Material").Value = oCondicionVenta.Material
            .Parameters("@ListPrec").Value = oCondicionVenta.ListPrec

        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect

                'Ejecutamos Comando
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Asignamos Valores al Reader
                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    With scdrReader

                        'Actualizamos Status del Objeto
                        oCondicionVenta.Condicion = .GetString(0)
                        oCondicionVenta.OrgVtas = .GetString(1)
                        oCondicionVenta.CanalDist = .GetString(2)
                        oCondicionVenta.Jerarquia = .GetString(3)
                        oCondicionVenta.CondMat = .GetString(4)
                        oCondicionVenta.CondPrec = .GetString(5)
                        oCondicionVenta.Material = .GetString(6)
                        oCondicionVenta.OficinaVtas = .GetString(7)
                        oCondicionVenta.ListPrec = .GetString(8)
                        oCondicionVenta.FechaIni = .GetDateTime(9)
                        oCondicionVenta.FechaFin = .GetDateTime(10)
                        oCondicionVenta.DescPorcentaje = .GetDecimal(11)
                        oCondicionVenta.Descmonto = .GetDecimal(12)

                    End With

                Else

                    oCondicionVenta.Clear()

                End If

                scdrReader.Close()

            End With

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

    End Sub

#End Region

#Region "FolioDpPro"
    Friend Function SelFolioSAPByFolioFI(ByVal strFolioFI As String) As String

        Dim oResult As String = ""
        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[FacturaFolioSAPSelByFolioFI]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioFI", System.Data.SqlDbType.VarChar, 10))
            .Parameters("@FolioFI").Value = strFolioFI
        End With

        'Dim oAlmacenesAdapter As SqlDataAdapter
        'oAlmacenesAdapter = New SqlDataAdapter
        'oAlmacenesAdapter.SelectCommand = sccmdSelect

        Try

            sccnnConnection.Open()

            scdrReader = sccmdSelect.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.SingleRow)

            scdrReader.Read()

            If scdrReader.HasRows Then

                oResult = scdrReader.GetString(0)

            Else

                oResult = ""

            End If


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

    Friend Function SelFolioDelMov(ByVal BWART As String, ByVal FolioSAP As String, ByVal FolioTras As String) As String

        Dim strResult As String

        Dim sccnnDPTienda As New SqlConnection(m_strConnectionString)

        Dim sccmdFolioDpProSel As SqlCommand
        sccmdFolioDpProSel = New SqlCommand

        With sccmdFolioDpProSel
            .CommandText = "[SelFolioDpPro]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Connection = sccnnDPTienda
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@BWART", System.Data.SqlDbType.VarChar, 10))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioSAP", System.Data.SqlDbType.VarChar, 10))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioTras", System.Data.SqlDbType.VarChar, 10))

            .Parameters("@BWART").Value = BWART
            .Parameters("@FolioSAP").Value = FolioSAP
            .Parameters("@FolioTras").Value = FolioTras
        End With

        Try
            sccnnDPTienda.Open()

            Dim scsdrReader As SqlDataReader

            scsdrReader = sccmdFolioDpProSel.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.SingleRow)

            scsdrReader.Read()

            If (scsdrReader.HasRows) Then
                With scsdrReader
                    strResult = CType(.GetValue(0), String).ToString  'FolioDpPro
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

        sccmdFolioDpProSel.Dispose()
        sccmdFolioDpProSel = Nothing

        sccnnDPTienda.Dispose()
        sccnnDPTienda = Nothing

        Return strResult
    End Function
#End Region

#Region "Descuento Proxima Compra"
    '-----------------------------------------------------------------------------------------------------------------------------------------
    'JNAVA 07/11/2013: Guardar Descuentos Proxima Compra SQL
    '-----------------------------------------------------------------------------------------------------------------------------------------
    Friend Sub InsertarDescuentoProximaCompra(ByVal oRow As DataRow)
        Dim sccnnConnection As New SqlConnection(m_strConnectionString)
        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand
        Dim parameter As New SqlParameter("@DescuentoId", SqlDbType.Int)
        parameter.Direction = ParameterDirection.Output
        With sccmdInsert
            .Connection = sccnnConnection
            .CommandText = "[DescuentosAdicionalesInsPorMarca]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodMarca", System.Data.SqlDbType.VarChar, 2, "CodMarca"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Descuento", System.Data.SqlDbType.Decimal, 9, "Descuento"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaIni", System.Data.SqlDbType.DateTime, 8, "FechaIni"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaFin", System.Data.SqlDbType.DateTime, 8, "FechaFin"))
            .Parameters.Add(New SqlParameter("@PG", SqlDbType.Bit, 1, "Publico General"))
            .Parameters.Add(New SqlParameter("@V", SqlDbType.Bit, 1, "DPVale"))
            .Parameters.Add(New SqlParameter("@I", SqlDbType.Bit, 1, "Fact. Fiscal"))
            .Parameters.Add(New SqlParameter("@O", SqlDbType.Bit, 1, "Facilito"))
            .Parameters.Add(New SqlParameter("@F", SqlDbType.Bit, 1, "Fonacot"))
            .Parameters.Add(New SqlParameter("@K", SqlDbType.Bit, 1, "Tarjeta Fonacot"))
            .Parameters.Add(New SqlParameter("@S", SqlDbType.Bit, 1, "Socios"))
            .Parameters.Add(New SqlParameter("@D", SqlDbType.Bit, 1, "Dips"))
            .Parameters.Add(parameter)
        End With
        Try
            sccnnConnection.Open()

            With sccmdInsert
                'Assign Parameters Values
                .Parameters("@CodMarca").Value = "PC"
                .Parameters("@Descuento").Value = oRow!DESCUENTO
                If CStr(oRow!FECHASAPI) = "" Then
                    .Parameters("@FechaIni").Value = Date.Today
                Else
                    .Parameters("@FechaIni").Value = CDate(CStr(oRow!FECHASAPI).Substring(6) & "/" & CStr(oRow!FECHASAPI).Substring(4, 2) & "/" & CStr(oRow!FECHASAPI).Substring(0, 4))
                End If
                If CStr(oRow!FECHASAPF) = "" Then
                    .Parameters("@FechaFin").Value = Date.Today
                Else
                    .Parameters("@FechaFin").Value = CDate(CStr(oRow!FECHASAPF).Substring(6) & "/" & CStr(oRow!FECHASAPF).Substring(4, 2) & "/" & CStr(oRow!FECHASAPF).Substring(0, 4))
                End If
                .Parameters("@PG").Value = IIf(CStr(oRow!P).Trim = "X", True, False)
                .Parameters("@V").Value = IIf(CStr(oRow!V).Trim = "X", True, False)
                .Parameters("@I").Value = IIf(CStr(oRow!I).Trim = "X", True, False)
                .Parameters("@O").Value = IIf(CStr(oRow!O).Trim = "X", True, False)
                .Parameters("@F").Value = IIf(CStr(oRow!F).Trim = "X", True, False)
                .Parameters("@K").Value = IIf(CStr(oRow!K).Trim = "X", True, False)
                .Parameters("@S").Value = IIf(CStr(oRow!S).Trim = "X", True, False)
                .Parameters("@D").Value = IIf(CStr(oRow!D).Trim = "X", True, False)
                .ExecuteNonQuery()
                Dim descuentoid As Integer = 0
                If Not IsDBNull(parameter.Value) AndAlso oRow.Table.Columns.IndexOf("FPAGOS") >= 0 Then
                    descuentoid = CInt(parameter.Value)
                    sccmdInsert.Dispose()
                    Dim ts As SqlTransaction = Nothing
                    Try
                        ts = sccnnConnection.BeginTransaction()
                        sccmdInsert.Transaction = ts
                        sccmdInsert.Parameters.Clear()
                        sccmdInsert.CommandText = "INSERT INTO DescuentosFormasPago(DescuentoAdicionalID,CodFormaPago)VALUES(@DescuentoAdicionalID,@CodFormaPago)"
                        sccmdInsert.CommandType = CommandType.Text
                        sccmdInsert.Parameters.Add(New SqlParameter("@DescuentoAdicionalID", SqlDbType.Int))
                        sccmdInsert.Parameters.Add(New SqlParameter("@CodFormaPago", SqlDbType.VarChar))
                        Dim formasPago() As String = CStr(oRow!FPAGOS).Split(",")
                        For Each fila As String In formasPago
                            If Not fila Is Nothing AndAlso fila.Trim <> "" Then
                                sccmdInsert.Parameters("@DescuentoAdicionalID").Value = descuentoid
                                sccmdInsert.Parameters("@CodFormaPago").Value = fila
                                sccmdInsert.ExecuteNonQuery()
                            End If
                        Next
                        ts.Commit()
                    Catch sql As Exception
                        If sccnnConnection.State <> ConnectionState.Closed Then
                            ts.Rollback()
                            sccnnConnection.Close()
                        End If
                        Throw New ApplicationException(sql.Message, sql)
                    End Try
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
    End Sub

#End Region

#Region "Facturación Si Hay"

    Public Function GetFacturasSiHay(ByVal FechaCierre As Date) As DataTable
        Dim conexion As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString())
        Dim command As New SqlCommand("CierreDiaFacturasSiHay", conexion)
        Dim adapter As SqlDataAdapter = Nothing
        Dim dtFacturas As New DataTable
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.AddWithValue("@FechaCierre", FechaCierre)
            command.Parameters.AddWithValue("@CodAlmacen", oParent.ApplicationContext.ApplicationConfiguration.Almacen)
            adapter = New SqlDataAdapter(command)
            adapter.Fill(dtFacturas)
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
        Return dtFacturas
    End Function

#End Region

End Class
