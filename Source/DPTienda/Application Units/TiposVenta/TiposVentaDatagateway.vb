Imports System.Data.SqlClient

Friend Class TiposVentaDatagateway

    Private oParent As TiposVentaManager

#Region "Constructors / Destructors"

    Public Sub New(ByVal Parent As TiposVentaManager)

        oParent = Parent

    End Sub

#End Region

#Region "Methods"

    Friend Function [Select]() As DataSet

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                         DataStorageConfiguration.GetConnectionString)

        Dim daSQLTipoVenta As SqlDataAdapter
        Dim dsResult As New DataSet

        'Obtenemos General
        Dim sccmdSelect As SqlCommand
        sccmdSelect = New SqlCommand

        With sccmdSelect
            .Connection = sccnnConnection
            .CommandText = "[CatalogoTipoVentaSelAll]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        End With

        daSQLTipoVenta = New SqlDataAdapter(sccmdSelect)

        Try

            daSQLTipoVenta.Fill(dsResult)

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

        daSQLTipoVenta.Dispose()
        daSQLTipoVenta = Nothing

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return dsResult

    End Function

#End Region

End Class
