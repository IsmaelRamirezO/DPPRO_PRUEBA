Imports DportenisPro.DPTienda
Imports DportenisPro.DPTienda.Core
Imports System.Data.SqlClient

Friend Class CatalogoCentrosDataGateWay

    Private oAppContext As Core.ApplicationContext

    Friend Sub New(ByVal oConfiguration As Core.ApplicationContext)
        oAppContext = oConfiguration
    End Sub

    Friend Function GetCataCentros() As DataSet

        Dim strQuery As String = _
        " Select * From CatalogoCentros "

        Dim oResult As DataSet
        Dim sccnnConnection As New SqlConnection(oAppContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString)

        Dim sccmdSelect As SqlCommand

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = strQuery
            .CommandType = System.Data.CommandType.Text

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))

        End With

        Dim oCatalogoCentrosAdapter As SqlDataAdapter
        oCatalogoCentrosAdapter = New SqlDataAdapter
        oCatalogoCentrosAdapter.SelectCommand = sccmdSelect

        Try

            sccnnConnection.Open()

            oResult = New DataSet

            oCatalogoCentrosAdapter.Fill(oResult, "CatalogoCentros")

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

    Friend Function GetCentro(ByVal strCentro As String) As String

        Dim oResult As String
        Dim sccnnConnection As New SqlConnection(oAppContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString)

        Dim sccmdSelect As SqlCommand

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[GetCentroByCentro]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CENTRO", System.Data.SqlDbType.VarChar, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Descripcion", System.Data.SqlDbType.VarChar, 35))
            .Parameters("@Descripcion").Direction = ParameterDirection.Output
            .Parameters("@Centro").Value = strCentro
            .Parameters("@Descripcion").Value = ""

        End With

        Try

            sccnnConnection.Open()
            With sccmdSelect
                .ExecuteNonQuery()
                oResult = .Parameters("@Descripcion").Value
            End With


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

    Function GetCatalogoAlmacen() As DataSet

        Dim strQuery As String = _
        " Select * From CatalogoAlmacenes "

        Dim oResult As DataSet
        Dim sccnnConnection As New SqlConnection(oAppContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString)

        Dim sccmdSelect As SqlCommand

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = strQuery
            .CommandType = System.Data.CommandType.Text

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))

        End With

        Dim oCatalogoAlmacenesAdapter As SqlDataAdapter
        oCatalogoAlmacenesAdapter = New SqlDataAdapter
        oCatalogoAlmacenesAdapter.SelectCommand = sccmdSelect

        Try

            sccnnConnection.Open()

            oResult = New DataSet

            oCatalogoAlmacenesAdapter.Fill(oResult, "CatalogoAlmacenes")

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



End Class
