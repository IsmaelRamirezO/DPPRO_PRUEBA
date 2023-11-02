Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO

Friend Class CatalogoArticuloDataGateWay

    Private oParent As CatalogoArticuloManager
    Private m_strConnectionString As String
    Private oArticulo As Articulo

#Region "Constructors"

    Public Sub New(ByVal Parent As CatalogoArticuloManager)

        oParent = Parent

        m_strConnectionString = oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString

        oArticulo = oParent.Create

    End Sub

#End Region

#Region "Methods"

    Public Sub Insert(ByVal Articulo As Articulo)
        Dim pconBase As SqlClient.SqlConnection
        Dim pcmdCat As SqlClient.SqlCommand

        pconBase = New SqlClient.SqlConnection
        pcmdCat = New SqlClient.SqlCommand

        pconBase.ConnectionString = m_strConnectionString
        pconBase.Open()
        pcmdCat.Connection = pconBase
        pcmdCat.CommandText = "[CatalogoArticulosIns]"
        pcmdCat.CommandType = CommandType.StoredProcedure
        With pcmdCat.Parameters
            .Add("@CodArticulo", SqlDbType.VarChar, 20)
            .Add("@CodArtProv", SqlDbType.VarChar, 20)
            .Add("@Descripcion", SqlDbType.VarChar, 50)
            .Add("@CodLinea", SqlDbType.VarChar, 3)
            .Add("@CodCorrida", SqlDbType.VarChar, 3)
            .Add("@CodCategoria", SqlDbType.Int)
            .Add("@CodFamilia", SqlDbType.VarChar, 2)
            .Add("@CodUso", SqlDbType.Int)
            .Add("@CodMarca", SqlDbType.VarChar, 2)
            .Add("@CostoProm", SqlDbType.Money)
            .Add("@MargenUtilidad", SqlDbType.Decimal)
            .Add("@PrecioVenta", SqlDbType.Money)
            .Add("@Descuento", SqlDbType.Decimal)
            .Add("@PrecioOferta", SqlDbType.Money)
            .Add("@FechaOferta", SqlDbType.DateTime)
            .Add("@CodUnidadCom", SqlDbType.VarChar, 3)
            .Add("@CodUnidadVta", SqlDbType.VarChar, 3)
            .Add("@CodMonedaCom", SqlDbType.Int)
            .Add("@CodMonedaVta", SqlDbType.Int)
            .Add("@ImpCodBarra", SqlDbType.Bit)
            .Add("@Imagen", SqlDbType.Image)

            .Item("@CodArticulo").Value = Articulo.CodArticulo
            .Item("@CodArtProv").Value = Articulo.CodArtProv
            .Item("@Descripcion").Value = Articulo.Descripcion
            .Item("@CodLinea").Value = Articulo.Codlinea
            .Item("@CodCorrida").Value = Articulo.CodCorrida
            .Item("@CodCategoria").Value = Articulo.CodCategoria
            .Item("@CodFamilia").Value = Articulo.CodFamilia
            .Item("@CodUso").Value = Articulo.CodUso
            .Item("@CodMarca").Value = Articulo.CodMarca
            .Item("@CostoProm").Value = Articulo.CostoProm
            .Item("@MargenUtilidad").Value = Articulo.MargenUtilidad
            .Item("@PrecioVenta").Value = Articulo.PrecioVenta
            .Item("@Descuento").Value = Articulo.Descuento
            .Item("@PrecioOferta").Value = Articulo.PrecioOferta
            .Item("@FechaOferta").Value = Articulo.FechaOferta
            .Item("@CodUnidadCom").Value = Articulo.CodUnidadCom
            .Item("@CodUnidadVta").Value = Articulo.CodUnidadVta
            .Item("@CodMonedaCom").Value = Articulo.CodMonedaCom
            .Item("@CodMonedaVta").Value = Articulo.CodMonedaVta
            .Item("@ImpCodBarra").Value = Articulo.ImpCodBarra
            .Item("@Imagen").Value = Articulo.Imagen
        End With
        pcmdCat.ExecuteNonQuery()
        pconBase.Close()
    End Sub

    Public Sub Update(ByVal Articulo As Articulo)

    End Sub

    Public Sub Delete(ByVal ID As String)

    End Sub

    Public Function SelectCondicionVenta(ByVal ID As String) As Double()
        Dim sccnnConnection As New SqlConnection(m_strConnectionString)
        Dim res(2) As Double
        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[CondicionesVentaSelConsultaExistencias]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodArticulo", System.Data.SqlDbType.VarChar, 20))

        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect
                'Asignamos Valor al Parámetro
                .Parameters("@CodArticulo").Value = ID

                'Ejecutamos Comando
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Asignamos Valores al Reader
                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    With scdrReader
                        res(0) = .GetDecimal(0)
                        res(1) = .GetDecimal(1)
                    End With
                Else

                    res(0) = 0
                    res(1) = 0
                    Exit Function

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

        Return res

    End Function

    Public Function SelectByID(ByVal ID As String) As Articulo

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[CatalogoArticulosSel]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodArticulo", System.Data.SqlDbType.VarChar, 20))

        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect
                'Asignamos Valor al Parámetro
                .Parameters("@CodArticulo").Value = ID.PadLeft(18, "0")

                'Ejecutamos Comando
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Asignamos Valores al Reader
                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    With scdrReader

                        oArticulo.CodArticulo = .GetString(0)
                        oArticulo.CodArtProv = .GetString(1)
                        oArticulo.Descripcion = .GetString(2)
                        oArticulo.Codlinea = .GetString(3)
                        oArticulo.CodCorrida = .GetString(4)
                        oArticulo.CodCategoria = CInt(.GetString(5))
                        oArticulo.CodFamilia = .GetString(6)
                        oArticulo.CodUso = .GetString(7)
                        oArticulo.CodMarca = .GetString(8)
                        oArticulo.CostoProm = .GetDecimal(9)
                        oArticulo.MargenUtilidad = .GetDecimal(10)
                        'oArticulo.PrecioVenta = .GetDecimal(11)
                        'Precio Sin IVA se cambia por precio con IVA
                        oArticulo.PrecioVenta = .GetDecimal(25)
                        oArticulo.Descuento = .GetDecimal(12)
                        oArticulo.PrecioOferta = .GetDecimal(13)
                        If .IsDBNull(14) = False Then
                            oArticulo.FechaOferta = .GetDateTime(14)
                        Else
                            oArticulo.FechaOferta = Nothing
                        End If
                        oArticulo.CodUnidadCom = .GetString(15)
                        oArticulo.CodUnidadVta = .GetString(16)
                        oArticulo.CodMonedaCom = .GetInt32(17)
                        oArticulo.CodMonedaVta = .GetInt32(18)
                        oArticulo.ImpCodBarra = .GetBoolean(19)
                        'Checamos la Imagen
                        If (.IsDBNull(20) = False) Then
                            Dim BytBlobData(.GetBytes(20, 0, Nothing, 0, Integer.MaxValue) - 1) As Byte
                            .GetBytes(20, 0, BytBlobData, 0, BytBlobData.Length)
                            oArticulo.Imagen = New MemoryStream(BytBlobData)
                            oArticulo.SetWithImage()
                        Else
                            oArticulo.ResetWithImage()
                            oArticulo.Imagen = New MemoryStream(0)
                            oArticulo.ResetWithImage()
                        End If
                        oArticulo.Jerarquia = .GetString(21)
                        oArticulo.Dip = .GetBoolean(22)
                        oArticulo.CodigoAnterior = .GetString(23)
                        oArticulo.PrecioSocio = .GetDecimal(.GetOrdinal("PrecioSocio"))

                        '----------------------------------------------
                        'JNAVA (3.12.2014): Venta de electronicos
                        '----------------------------------------------
                        oArticulo.CodElectronico = .GetString(26)

                        'Actualizamos Status del Objeto
                        oArticulo.ResetFlagNew()
                        oArticulo.ResetFlagDirty()
                        oArticulo.SetExist()

                    End With

                Else

                    oArticulo.ResetExist()
                    Exit Function

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

        Return oArticulo

    End Function

    Public Function SelectByIDDes(ByVal ID As String, ByVal BuscaCodProv As Boolean) As Articulo
        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[CatalogoArticulosSelDesc]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodArticulo", System.Data.SqlDbType.VarChar, 20))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@BuscaCodProv", System.Data.SqlDbType.Bit, 1))

        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect
                'Asignamos Valor al Parámetro
                If BuscaCodProv = False Then
                    .Parameters("@CodArticulo").Value = ID.PadLeft(18, "0")
                Else
                    .Parameters("@CodArticulo").Value = ID.Trim
                End If
                .Parameters("@BuscaCodProv").Value = BuscaCodProv

                'Ejecutamos Comando
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Asignamos Valores al Reader
                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    With scdrReader

                        oArticulo.CodArticulo = .GetString(0)
                        oArticulo.CodArtProv = .GetString(1)
                        oArticulo.Descripcion = .GetString(2)
                        oArticulo.Codlinea = .GetString(3)
                        oArticulo.CodCorrida = .GetString(4)
                        oArticulo.CodCategoria = CInt(.GetString(5))
                        oArticulo.CodFamilia = .GetString(6)
                        oArticulo.CodUso = CInt(.GetString(7))
                        oArticulo.CodMarca = .GetString(8)
                        oArticulo.CostoProm = .GetDecimal(9)
                        oArticulo.MargenUtilidad = .GetDecimal(10)
                        'oArticulo.PrecioVenta = .GetDecimal(11)
                        'Precio Sin IVA se cambia por precio con IVA
                        oArticulo.PrecioVenta = .GetDecimal(25)
                        oArticulo.Descuento = .GetDecimal(12)
                        oArticulo.PrecioOferta = .GetDecimal(13)
                        If .IsDBNull(14) = False Then
                            oArticulo.FechaOferta = .GetDateTime(14)
                        Else
                            oArticulo.FechaOferta = Nothing
                        End If
                        oArticulo.CodUnidadCom = .GetString(15)
                        oArticulo.CodUnidadVta = .GetString(16)
                        oArticulo.CodMonedaCom = .GetInt32(17)
                        oArticulo.CodMonedaVta = .GetInt32(18)
                        oArticulo.ImpCodBarra = .GetBoolean(19)
                        'Checamos la Imagen
                        If (.IsDBNull(20) = False) Then
                            Dim BytBlobData(.GetBytes(20, 0, Nothing, 0, Integer.MaxValue) - 1) As Byte
                            .GetBytes(20, 0, BytBlobData, 0, BytBlobData.Length)
                            oArticulo.Imagen = New MemoryStream(BytBlobData)
                            oArticulo.SetWithImage()
                        Else
                            oArticulo.ResetWithImage()
                            oArticulo.Imagen = New MemoryStream(0)
                            oArticulo.ResetWithImage()
                        End If
                        oArticulo.Jerarquia = .GetString(21)
                        oArticulo.Dip = .GetBoolean(22)
                        oArticulo.CodigoAnterior = .GetString(23)
                        oArticulo.PrecioSocio = .GetDecimal(.GetOrdinal("PrecioSocio"))
                        oArticulo.DescCodCategoria = .GetString(.GetOrdinal("DescCodCategoria"))
                        oArticulo.DescCodFamilia = .GetString(.GetOrdinal("DescCodFamilia"))
                        oArticulo.DescCodUso = .GetString(.GetOrdinal("DescCodUso"))
                        oArticulo.DescCodMarca = .GetString(.GetOrdinal("DescCodMarca"))
                        oArticulo.DescCodCorrida = .GetString(.GetOrdinal("DescCodCorrida"))
                        oArticulo.DescCodLinea = .GetString(.GetOrdinal("DescCodLinea"))


                        'Actualizamos Status del Objeto
                        oArticulo.ResetFlagNew()
                        oArticulo.ResetFlagDirty()
                        oArticulo.SetExist()

                    End With

                Else

                    oArticulo.ResetExist()
                    Exit Function

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

        Return oArticulo

    End Function

    Public Function SelectAll(ByVal OnlyEnabledRecords As Boolean) As DataSet

        Dim oResult As DataSet
        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[CatalogoArticulosSelAll]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@OnlyEnabledRecords", System.Data.SqlDbType.Bit, 1))
            .Parameters("@OnlyEnabledRecords").Value = OnlyEnabledRecords

        End With

        Dim oArticuloAdapter As SqlDataAdapter
        oArticuloAdapter = New SqlDataAdapter
        oArticuloAdapter.SelectCommand = sccmdSelect

        Try

            sccnnConnection.Open()

            oResult = New DataSet

            oArticuloAdapter.Fill(oResult, "CatalogoArticulos")

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

    Public Sub SelectImage(ByVal ID As String)

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "Select CodArticulo,Imagen from CatalogoArticulos Where CodArticulo='" & ID & "'"
            .CommandType = System.Data.CommandType.Text

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

                        'Checamos la Imagen
                        If (.IsDBNull(1) = False) Then
                            Dim BytBlobData(.GetBytes(1, 0, Nothing, 0, Integer.MaxValue) - 1) As Byte
                            .GetBytes(1, 0, BytBlobData, 0, BytBlobData.Length)
                            oArticulo.ImagenAlter = New MemoryStream(BytBlobData)
                            oArticulo.SetWithImageAlter()
                        Else
                            oArticulo.ImagenAlter = New MemoryStream(0)
                            oArticulo.ResetWithImageAlter()
                        End If

                        'Actualizamos Status del Objeto

                    End With

                Else
                    'No Existe el Codigo de Artículo
                    oArticulo.ImagenAlter = New MemoryStream(0)
                    oArticulo.ResetWithImageAlter()

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

    Public Sub SelectInto(ByVal ID As String, ByVal oArticulo As Articulo, Optional ByVal Last As Boolean = False)

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandType = System.Data.CommandType.StoredProcedure
            If Last Then
                .CommandText = "[CatalogoArticulosSelDesc]"
                '.CommandText = "[CatalogoArticulosSelCodigoAnterior]"
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodArticulo", System.Data.SqlDbType.VarChar, 20))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@BuscaCodProv", System.Data.SqlDbType.Bit, 1))
            Else
                .CommandText = "[CatalogoArticulosSel]"
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodArticulo", System.Data.SqlDbType.VarChar, 20))
            End If


            

        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect
                'Asignamos Valor al Parámetro
                If Last Then
                    .Parameters("@CodArticulo").Value = ID
                    .Parameters("@BuscaCodProv").Value = True
                Else
                    .Parameters("@CodArticulo").Value = ID.PadLeft(18, "0")
                End If
                'Ejecutamos Comando
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Asignamos Valores al Reader
                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    With scdrReader

                        oArticulo.CodArticulo = CStr(scdrReader("CodArticulo"))
                        oArticulo.CodArtProv = CStr(scdrReader("CodArtProv"))
                        oArticulo.Descripcion = CStr(scdrReader("Descripcion"))
                        oArticulo.Codlinea = CStr(scdrReader("CodLinea"))
                        oArticulo.CodCorrida = CStr(scdrReader("CodCorrida"))
                        'oArticulo.CodCategoria = .GetInt32(5)
                        oArticulo.CodCategoria = CStr(scdrReader("CodCategoria"))
                        oArticulo.CodFamilia = CStr(scdrReader("CodFamilia"))
                        'oArticulo.CodUso = .GetInt32(7)
                        oArticulo.CodUso = CStr(scdrReader("CodUso"))
                        oArticulo.CodMarca = CStr(scdrReader("CodMarca"))
                        oArticulo.CostoProm = CDec(scdrReader("CostoProm"))
                        oArticulo.MargenUtilidad = CDec(scdrReader("MargenUtilidad"))
                        oArticulo.PrecioVenta = CDec(scdrReader("PrecioVenta"))
                        oArticulo.Descuento = CDec(scdrReader("Descuento"))
                        oArticulo.PrecioOferta = CDec(scdrReader("PrecioOferta"))
                        oArticulo.FechaOferta = CDate(scdrReader("FechaOferta"))
                        oArticulo.CodUnidadCom = CStr(scdrReader("CodUnidadCom"))
                        oArticulo.CodUnidadVta = CStr(scdrReader("CodUnidadVta"))
                        oArticulo.CodMonedaCom = CInt(scdrReader("CodMonedaCom"))
                        oArticulo.CodMonedaVta = CInt(scdrReader("CodMonedaVta"))
                        oArticulo.ImpCodBarra = CBool(scdrReader("ImpCodBarra"))
                        'Checamos la Imagen
                        If (scdrReader.IsDBNull(20) = False) Then
                            Dim BytBlobData(.GetBytes(20, 0, Nothing, 0, Integer.MaxValue) - 1) As Byte
                            .GetBytes(20, 0, BytBlobData, 0, BytBlobData.Length)
                            oArticulo.Imagen = New MemoryStream(BytBlobData)
                            oArticulo.SetWithImage()
                        Else
                            oArticulo.ResetWithImage()
                            oArticulo.Imagen = New MemoryStream(0)
                            oArticulo.ResetWithImage()
                        End If
                        oArticulo.Jerarquia = CStr(scdrReader("Jerarquia"))
                        oArticulo.Dip = CBool(scdrReader("Dip"))
                        oArticulo.CodigoAnterior = CStr(scdrReader("CodigoAnterior"))
                        oArticulo.PrecioSocio = CDec(scdrReader("PrecioSocio"))
                        oArticulo.PrecioIva = CDec(scdrReader("PrecioIva"))

                        '----------------------------------------------
                        'JNAVA (3.12.2014): Venta de electronicos
                        '----------------------------------------------
                        oArticulo.CodElectronico = CStr(scdrReader("CodElectronico"))

                        'Actualizamos Status del Objeto
                        oArticulo.ResetFlagNew()
                        oArticulo.ResetFlagDirty()
                        oArticulo.SetExist()

                    End With

                Else

                    oArticulo.ResetExist()
                    'Exit Sub

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

#Region "Etiquetas"
    Public Function SelectCorridaMaxMin(ByVal CodArticulo As String) As String()
        Dim sccnnConnection As New SqlConnection(m_strConnectionString)
        Dim res(2) As String
        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[ExistenciasTallaMaxMin]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodArticulo", System.Data.SqlDbType.VarChar, 20))

        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect
                'Asignamos Valor al Parámetro
                .Parameters("@CodArticulo").Value = CodArticulo

                'Ejecutamos Comando
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Asignamos Valores al Reader
                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    With scdrReader
                        res(0) = .GetDecimal(.GetOrdinal("NumInicio"))
                        res(1) = .GetDecimal(.GetOrdinal("NumFin"))
                    End With
                Else

                    res(0) = 0
                    res(1) = 0
                    Exit Function

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

        Return res

    End Function

    Public Function SelectCorridaMaxMinImp(ByVal CodArticulo As String, ByVal strTipo As String) As String
        Dim sccnnConnection As New SqlConnection(m_strConnectionString)
        Dim res As String
        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[ExistenciasTallaMaxMinImp]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodArticulo", System.Data.SqlDbType.VarChar, 20))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Tipo", System.Data.SqlDbType.VarChar, 20))

        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect
                'Asignamos Valor al Parámetro
                .Parameters("@CodArticulo").Value = CodArticulo
                .Parameters("@Tipo").Value = strTipo

                'Ejecutamos Comando
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Asignamos Valores al Reader
                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    With scdrReader
                        res = .GetDecimal(.GetOrdinal("Num"))
                    End With
                Else

                    res = 0

                    Exit Function

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

        Return res

    End Function

    Public Function SelectCodColor(ByVal CodArticulo As String) As String

        Dim oResult As DataSet
        Dim strResult As String

        Dim sccnnDPTienda As New SqlConnection(m_strConnectionString)

        Dim sccmdCodColor As SqlCommand
        sccmdCodColor = New SqlCommand

        With sccmdCodColor
            .CommandText = "[ExistenciasSelColor]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Connection = sccnnDPTienda
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodArticulo", System.Data.SqlDbType.VarChar, 20))
            .Parameters("@CodArticulo").Value = CodArticulo
        End With

        Dim scdaCodigoAdapter As SqlDataAdapter
        scdaCodigoAdapter = New SqlDataAdapter

        scdaCodigoAdapter.SelectCommand = sccmdCodColor

        Try

            sccnnDPTienda.Open()

            oResult = New DataSet

            scdaCodigoAdapter.Fill(oResult, "CodigoColor")

            If oResult.Tables(0).Rows.Count > 0 Then
                strResult = oResult.Tables(0).Rows(0).Item("Color1") & oResult.Tables(0).Rows(0).Item("Color2")
            Else
                strResult = "NA"
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

        sccmdCodColor.Dispose()
        sccmdCodColor = Nothing

        sccnnDPTienda.Dispose()
        sccnnDPTienda = Nothing

        Return strResult

    End Function

    Public Function SelArticulosNoLecturados(ByVal CodArticulo As String, ByVal FolioTraslado As String) As DataTable
        Dim oResult As DataSet
        Dim sccnnDPTienda As New SqlConnection(m_strConnectionString)
        Dim sccmd As SqlCommand
        sccmd = New SqlCommand

        With sccmd
            .CommandText = "[ControlArticulosNoLecturadosDetalleSel]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Connection = sccnnDPTienda
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodArticulo", System.Data.SqlDbType.VarChar, 20))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioTraslado", System.Data.SqlDbType.VarChar, 10))
            .Parameters("@CodArticulo").Value = CodArticulo
            .Parameters("@FolioTraslado").Value = FolioTraslado
        End With

        Dim scdaCodigoAdapter As SqlDataAdapter
        scdaCodigoAdapter = New SqlDataAdapter

        scdaCodigoAdapter.SelectCommand = sccmd

        Try
            sccnnDPTienda.Open()
            oResult = New DataSet
            scdaCodigoAdapter.Fill(oResult, "ArticulosNoLecturados")
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

        sccmd.Dispose()
        sccmd = Nothing
        sccnnDPTienda.Dispose()
        sccnnDPTienda = Nothing
        Return oResult.Tables(0)
    End Function


    
#End Region

#Region "SAP Retail"
    Public Function GetMotivosDefectuosos() As DataTable
        Dim conexion As New SqlConnection(m_strConnectionString)
        Dim command As New SqlCommand("GetMotivosDefectuosos", conexion)
        Dim adapter As SqlDataAdapter = Nothing
        Dim dtDefectuosos As New DataTable()
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            adapter = New SqlDataAdapter(command)
            adapter.Fill(dtDefectuosos)
            command.Dispose()
            conexion.Close()
        Catch ex As Exception
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            Throw New Exception(ex.Message, ex)
        End Try
        Return dtDefectuosos
    End Function

    Public Function GetCodMoTivoDefectuoso(ByVal Description As String) As String
        Dim conexion As New SqlConnection(m_strConnectionString)
        Dim command As New SqlCommand("GetMotivoDefectuosoByDescription", conexion)
        Dim reader As SqlDataReader = Nothing
        Dim codMotivoDefectuoso As String = ""
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.AddWithValue("@Description", Description)
            codMotivoDefectuoso = CStr(command.ExecuteScalar())
            command.Dispose()
            conexion.Close()
        Catch ex As Exception
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            Throw New Exception(ex.Message, ex)
        End Try
        Return codMotivoDefectuoso
    End Function

    Public Function GetDetalleArticuloDefectuosos(ByVal CodArticulo As String) As DataTable
        Dim conexion As New SqlConnection(m_strConnectionString)
        Dim command As New SqlCommand("GetDetailDefectuoso", conexion)
        Dim adapter As SqlDataAdapter = Nothing
        Dim dtResult As DataTable = New DataTable
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.AddWithValue("@CodArticulo", CodArticulo)
            adapter = New SqlDataAdapter(command)
            adapter.Fill(dtResult)
            command.Dispose()
            conexion.Close()
        Catch sql As SqlException
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            Throw New Exception(sql.Message, sql)
        Catch ex As Exception
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            Throw New Exception(ex.Message, ex)
        End Try
        Return dtResult
    End Function

    Public Function ValidaCodigoProveedor(ByVal CodProveedor As String) As String
        Dim conexion As New SqlConnection(m_strConnectionString)
        Dim codPadre As String = ""
        Dim command As New SqlCommand("ValidaCodigoProveedor", conexion)
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.AddWithValue("@CodProveedor", codProveedor)
            codPadre = CStr(command.ExecuteScalar())
            command.Dispose()
            conexion.Close()
        Catch sql As SqlException
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            Throw New ApplicationException(sql.Message, sql)
        Catch ex As Exception
            If conexion.State < ConnectionState.Closed Then
                conexion.Close()
            End If
            Throw New ApplicationException(ex.Message, ex)
        End Try
        Return codPadre
    End Function

    Public Function GetTallaByCodigo(ByVal CodArticulo As String) As String
        Dim Numero As String = ""
        Dim conexion As New SqlConnection(m_strConnectionString)
        Dim command As New SqlCommand("GetExistenciaByCodigo", conexion)
        Dim reader As SqlDataReader = Nothing
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.AddWithValue("@CodArticulo", CodArticulo)
            reader = command.ExecuteReader()
            If reader.HasRows Then
                While reader.Read
                    Numero = CStr(reader("Numero"))
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
            If conexion.State < ConnectionState.Closed Then
                conexion.Close()
            End If
            Throw New ApplicationException(ex.Message, ex)
        End Try
        Return Numero
    End Function

    '---------------------------------------------------------------------------------------------
    ' JANVA (04.03.2017): Obtiene la info del articulo con el CodPadre
    '---------------------------------------------------------------------------------------------
    Public Function LoadIntoByCodPadre(ByVal CodPadre As String) As DataTable
        Dim items As New DataTable
        Dim conexion As New SqlConnection(m_strConnectionString)
        Dim command As New SqlCommand("[CatalogoArticulosSelByCodPadre]", conexion)
        Dim adapter As SqlDataAdapter = Nothing
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.AddWithValue("@CodPadre", CodPadre)
            adapter = New SqlDataAdapter(command)
            adapter.Fill(items)
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
        Return items
    End Function
#End Region

#Region "Cambio de talla"

    Public Function GetExistenciaByCodigo(ByVal CodArticulo As String) As Hashtable
        Dim resultado As New Hashtable()
        Dim conexion As New SqlConnection(m_strConnectionString)
        Dim command As New SqlCommand("GetExistenciaByCodigo", conexion)
        Dim reader As SqlDataReader = Nothing
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.AddWithValue("@CodArticulo", CodArticulo)
            reader = command.ExecuteReader()
            If reader.HasRows Then
                While reader.Read
                    resultado("ID") = CInt(reader("ID"))
                    resultado("CodAlmacen") = CStr(reader("CodAlmacen"))
                    resultado("CodArticulo") = CStr(reader("CodArticulo"))
                    resultado("Numero") = CStr(reader("Numero"))
                    resultado("Total") = CDec(reader("Total"))
                    resultado("Libre") = CDec(reader("Libre"))
                    resultado("Apartados") = CDec(reader("Apartados"))
                    resultado("Defectuosos") = CDec(reader("Defectuosos"))
                    resultado("Promocion") = CDec(reader("Promocion"))
                    resultado("VtasEspeciales") = CDec(reader("VtasEspeciales"))
                    resultado("Consignacion") = CDec(reader("Consignacion"))
                    resultado("Transito") = CDec(reader("Transito"))
                    resultado("CodUso") = CStr(reader("CodUso"))
                    resultado("CodLinea") = CStr(reader("CodLinea"))
                    resultado("CodMarca") = CStr(reader("CodMarca"))
                    resultado("CodFamilia") = CStr(reader("CodFamilia"))
                    resultado("CodCategoria") = CStr(reader("CodCategoria"))
                    If IsDBNull(reader("ID_DPPRO")) = False Then
                        resultado("ID_DPPRO") = CStr(reader("ID_DPPRO"))
                    Else
                        resultado("ID_DPPRO") = ""
                    End If
                    If IsDBNull(reader("Color")) = False Then
                        resultado("Color") = CStr(reader("Color"))
                    Else
                        resultado("Color") = ""
                    End If
                    If IsDBNull(reader("g_mercancia")) = False Then
                        resultado("g_mercancia") = CStr(reader("g_mercancia"))
                    Else
                        resultado("g_mercancia") = ""
                    End If
                    'resultado("ID_DPPRO") = CStr(reader("ID_DPPRO"))
                    'resultado("Color") = CStr(reader("Color"))
                    'resultado("g_mercancia") = CStr(reader("g_mercancia"))
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
            If conexion.State < ConnectionState.Closed Then
                conexion.Close()
            End If
            Throw New ApplicationException(ex.Message, ex)
        End Try
        Return resultado
    End Function
#End Region

End Class
