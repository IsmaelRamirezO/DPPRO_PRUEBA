Imports System.Data.SqlClient

Public Class CatalogoUPCDataGateway

    Private oParent As CatalogoUPCManager

#Region "Constructors / Destructors"
    Public Sub New(ByVal Parent As CatalogoUPCManager)
        oParent = Parent
    End Sub
#End Region


#Region "Methods"
    Public Function [Select](ByVal ID As String, Optional ByVal UPC As UPC = Nothing) As UPC
        Dim oResult As UPC
        Dim sccnnDPTienda As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                                 DataStorageConfiguration.GetConnectionString)

        Dim sccmdCatalogoUPCSel As SqlCommand
        sccmdCatalogoUPCSel = New SqlCommand

        With sccmdCatalogoUPCSel
            .CommandText = "[CatalogoUPCSel]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Connection = sccnnDPTienda
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodUPC", System.Data.SqlDbType.VarChar, 20))
            .Parameters("@CodUPC").Value = ID.PadLeft(18, "0")
        End With

        Try
            sccnnDPTienda.Open()
            Dim scsdrReader As SqlDataReader
            scsdrReader = sccmdCatalogoUPCSel.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.SingleRow)
            scsdrReader.Read()

            If (scsdrReader.HasRows) Then
                If (UPC Is Nothing) Then
                    oResult = oParent.Create
                Else
                    oResult = UPC
                End If
                With scsdrReader
                    oResult.CodUPC = .GetString(0)                  'CodUPC,
                    oResult.CodArticulo = .GetString(1)             'CodArticulo
                    oResult.Numero = .GetString(2)                  'Numero
                End With
                scsdrReader.Close()
                oResult.ResetFlagNew()
                oResult.ResetFlagDirty()
            Else
                oResult = oParent.Create
                oResult.CodUPC = String.Empty
                oResult.CodArticulo = String.Empty
                oResult.Numero = 0
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
            Throw ex
        Finally
            If (sccnnDPTienda.State <> ConnectionState.Closed) Then
                Try
                    sccnnDPTienda.Close()
                Catch
                End Try
            End If
        End Try

        sccmdCatalogoUPCSel.Dispose()
        sccmdCatalogoUPCSel = Nothing
        sccnnDPTienda.Dispose()
        sccnnDPTienda = Nothing
        Return oResult
    End Function
    Public Function [Select2](ByVal ID As String, Optional ByVal UPC As UPC = Nothing) As DataSet

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                                 DataStorageConfiguration.GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdaCatUPC As SqlDataAdapter
        Dim dsCatUPC As DataSet


        sccmdSelect = New SqlCommand
        scdaCatUPC = New SqlDataAdapter
        dsCatUPC = New DataSet '("CatalogoUPC")

        With sccmdSelect
            .Connection = sccnnConnection
            .CommandText = "[CatalogoUPCSel]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodUPC", System.Data.SqlDbType.VarChar, 20))
        End With

        scdaCatUPC.SelectCommand = sccmdSelect

        Try
            sccnnConnection.Open()
            scdaCatUPC.SelectCommand.Parameters("@CodUPC").Value = ID.PadLeft(18, "0")
            'Fill DataSet
            scdaCatUPC.Fill(dsCatUPC)
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

        Return dsCatUPC
    End Function

    Public Function IsSkuOrMaterial(ByVal Code As String) As String
        Dim conexion As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                                 DataStorageConfiguration.GetConnectionString)
        Dim command As New SqlCommand("IsSkuOrMaterial", conexion)
        Dim type As String = ""
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.AddWithValue("@Code", Code)
            type = CStr(command.ExecuteScalar())
            command.Dispose()
            conexion.Close()
        Catch ex As Exception
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            Throw New ApplicationException(ex.Message, ex)
        End Try
        Return type
    End Function


    Public Function [SelectOper](ByVal ID As String, Optional ByVal UPC As UPC = Nothing) As UPC
        Dim oResult As UPC
        'Dim conexion As String = "Server=" + oParent.SaveConfigArchivos.ServerFirma + ";Database=Separaciones;UID=sa;pwd=01012006;"
        Dim conexion As String
        With oParent.SaveConfigArchivos
            conexion = "Server=" + .ServerSeparaciones + ";Database=" + .BDSeparaciones + ";UID=" + .UserSeparaciones + ";pwd=" + .PassSeparaciones + ";"
        End With
        Dim sccnnDPTienda As New SqlConnection(conexion)

        Dim sccmdCatalogoUPCSel As SqlCommand
        sccmdCatalogoUPCSel = New SqlCommand

        With sccmdCatalogoUPCSel
            .CommandText = "[CatalogoUPCSel]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Connection = sccnnDPTienda
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodUPC", System.Data.SqlDbType.VarChar, 20))
            .Parameters("@CodUPC").Value = ID.PadLeft(18, "0")
        End With

        Try
            sccnnDPTienda.Open()
            Dim scsdrReader As SqlDataReader
            scsdrReader = sccmdCatalogoUPCSel.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.SingleRow)

            scsdrReader.Read()

            If (scsdrReader.HasRows) Then
                If (UPC Is Nothing) Then
                    oResult = oParent.Create
                Else
                    oResult = UPC
                End If
                With scsdrReader
                    oResult.CodUPC = .GetString(0)                  'CodUPC,
                    oResult.CodArticulo = .GetString(1)             'CodArticulo
                    oResult.Numero = .GetString(2)                  'Numero
                    oResult.Descripcion = .GetString(3)             'Descripcion
                End With
                scsdrReader.Close()
                oResult.ResetFlagNew()
                oResult.ResetFlagDirty()
            Else
                oResult = oParent.Create
                oResult.CodUPC = String.Empty
                oResult.CodArticulo = String.Empty
                oResult.Numero = 0
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
            Throw ex
        Finally
            If (sccnnDPTienda.State <> ConnectionState.Closed) Then
                Try
                    sccnnDPTienda.Close()
                Catch
                End Try
            End If
        End Try

        sccmdCatalogoUPCSel.Dispose()
        sccmdCatalogoUPCSel = Nothing
        sccnnDPTienda.Dispose()
        sccnnDPTienda = Nothing
        Return oResult
    End Function

    Public Function [SelectOper2](ByVal ID As String, Optional ByVal UPC As UPC = Nothing) As DataSet

        'Dim conexion As String = "Server=" + oParent.SaveConfigArchivos.ServerFirma + ";Database=Separaciones;UID=sa;pwd=01012006;"
        Dim conexion As String
        With oParent.SaveConfigArchivos
            conexion = "Server=" + .ServerSeparaciones + ";Database=" + .BDSeparaciones + ";UID=" + .UserSeparaciones + ";pwd=" + .PassSeparaciones + ";"
        End With
        Dim sccnnConnection As New SqlConnection(conexion)

        Dim sccmdSelect As SqlCommand
        Dim scdaCatUPC As SqlDataAdapter
        Dim dsCatUPC As DataSet


        sccmdSelect = New SqlCommand
        scdaCatUPC = New SqlDataAdapter
        dsCatUPC = New DataSet '("CatalogoUPC")

        With sccmdSelect
            .Connection = sccnnConnection
            .CommandText = "[CatalogoUPCSel2]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodUPC", System.Data.SqlDbType.VarChar, 20))
        End With

        scdaCatUPC.SelectCommand = sccmdSelect

        Try
            sccnnConnection.Open()
            scdaCatUPC.SelectCommand.Parameters("@CodUPC").Value = ID.PadLeft(18, "0")
            'Fill DataSet
            scdaCatUPC.Fill(dsCatUPC)
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

        Return dsCatUPC
    End Function


    Public Sub InsertarUPC_From_Separaciones(ByVal UPC As DataSet)
        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                         DataStorageConfiguration.GetConnectionString)

        Dim rowUPC As DataRow
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
            Dim strNumero As String

            For Each rowUPC In UPC.Tables(0).Rows
                If IsNumeric(rowUPC!Talla) Then
                    'es un valor Numerico
                    If InStr(CStr(rowUPC!Talla), ".5") = 0 Then
                        'La formato para que qued si es 26.0  --> 26
                        strNumero = Format(CDec(rowUPC!Talla), "###0")
                    Else
                        'Se queda Igual es .5
                        strNumero = rowUPC!Talla
                    End If
                Else
                    'Es un Numero  XXL L M S
                    strNumero = rowUPC!Talla
                End If

                With sccmdInsert
                    'Assign Parameters Values 
                    .Parameters("@CodArticulo").Value = rowUPC!CodArticulo
                    .Parameters("@Numero").Value = strNumero
                    .Parameters("@CodUPC").Value = CStr(rowUPC!CodUPC).PadLeft(18, "0")
                    .Parameters("@Descripcion").Value = rowUPC!Descripcion

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

End Class
