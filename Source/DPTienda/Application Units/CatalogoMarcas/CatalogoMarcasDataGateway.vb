Imports System.Data.SqlClient

Public Class CatalogoMarcasDataGateway

    Private oParent As CatalogoMarcasManager

#Region "Constructors / Destructors"

    Public Sub New(ByVal Parent As CatalogoMarcasManager)
        oParent = Parent
    End Sub

  
#End Region

#Region "Methods"

    Public Function [Select](ByVal ID As String, Optional ByVal Almacen As Marca = Nothing) As Marca

        Dim oResult As Marca

        Dim sccnnDPTienda As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                                 DataStorageConfiguration.GetConnectionString)

        '(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString)

        Dim sccmdCatalogoMarcasSel As SqlCommand
        sccmdCatalogoMarcasSel = New SqlCommand

        With sccmdCatalogoMarcasSel
            .CommandText = "[CatalogoMarcasSel]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Connection = sccnnDPTienda
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodMarca", System.Data.SqlDbType.VarChar, 10))

            .Parameters("@CodMarca").Value = ID
        End With

        Try

            sccnnDPTienda.Open()

            Dim scsdrReader As SqlDataReader

            scsdrReader = sccmdCatalogoMarcasSel.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.SingleRow)

            scsdrReader.Read()

            If (scsdrReader.HasRows) Then

                If (Almacen Is Nothing) Then
                    oResult = oParent.Create
                Else
                    oResult = Almacen
                End If

                With scsdrReader

                    oResult.CodMarca = .GetString(0)                   'CodMarca,
                    oResult.Descripcion = .GetString(1)                'Descripcion,
                    oResult.CodOrigen = .GetString(2)                  'CodOrigen,


                End With

                scsdrReader.Close()

                oResult.ResetFlagNew()
                oResult.ResetFlagDirty()

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

        sccmdCatalogoMarcasSel.Dispose()
        sccmdCatalogoMarcasSel = Nothing

        sccnnDPTienda.Dispose()
        sccnnDPTienda = Nothing

        Return oResult

    End Function

    Public Function [Select](ByVal EnabledRecordsOnly As Boolean) As DataSet

        Dim oResult As DataSet

        Dim sccnnDPTienda As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString)

        Dim sccmdCatalogoMarcasSel As SqlCommand
        sccmdCatalogoMarcasSel = New SqlCommand

        With sccmdCatalogoMarcasSel
            .CommandText = "[CatalogoMarcasSelAll]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Connection = sccnnDPTienda
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@OnlyEnabledRecords", System.Data.SqlDbType.Bit, 1))

            .Parameters("@OnlyEnabledRecords").Value = EnabledRecordsOnly
        End With

        Dim scdaAlmacenesAdapter As SqlDataAdapter
        scdaAlmacenesAdapter = New SqlDataAdapter

        scdaAlmacenesAdapter.SelectCommand = sccmdCatalogoMarcasSel


        Try

            sccnnDPTienda.Open()

            oResult = New DataSet

            scdaAlmacenesAdapter.Fill(oResult, "CatalogoMarcas")

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

        sccmdCatalogoMarcasSel.Dispose()
        sccmdCatalogoMarcasSel = Nothing

        sccnnDPTienda.Dispose()
        sccnnDPTienda = Nothing

        Return oResult


    End Function

    Public Sub Insert(ByVal pMarca As Marca)

        Dim sccnnDPTienda As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString)

        Dim sccmdCatalogoMarcasIns As SqlCommand
        sccmdCatalogoMarcasIns = New SqlCommand

        With sccmdCatalogoMarcasIns

            .CommandText = "[CatalogoMarcasIns]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Connection = sccnnDPTienda

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodMarca", System.Data.SqlDbType.VarChar, 10, "CodMarca"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Descrip", System.Data.SqlDbType.VarChar, 30, "Descripcion"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodOrigen", System.Data.SqlDbType.VarChar, 1, "CodOrigen"))


            .Parameters("@CodMarca").Value = pMarca.CodMarca
            .Parameters("@Descrip").Value = pMarca.Descripcion
            .Parameters("@CodOrigen").Value = pMarca.CodOrigen

        End With

        Try
            sccnnDPTienda.Open()

            sccmdCatalogoMarcasIns.ExecuteNonQuery()

            pMarca.ResetFlagNew()
            pMarca.ResetFlagDirty()

            sccnnDPTienda.Close()

        Catch ex As Exception

            If (sccnnDPTienda.State <> ConnectionState.Closed) Then
                Try
                    sccnnDPTienda.Close()
                Catch
                End Try
            End If

            Throw ex

        Finally

            If (sccnnDPTienda.State <> ConnectionState.Closed) Then
                Try
                    sccnnDPTienda.Close()
                Catch
                End Try
            End If

        End Try

        sccmdCatalogoMarcasIns.Dispose()
        sccmdCatalogoMarcasIns = Nothing

        sccnnDPTienda.Dispose()
        sccnnDPTienda = Nothing

    End Sub

#End Region
    

End Class
