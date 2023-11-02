Imports DportenisPro.DPTienda
Imports DportenisPro.DPTienda.Core
Imports System.Data.SqlClient

Public Class CatalogoGuiasDataGateWay

    Private oAppContext As Core.ApplicationContext

    Friend Sub New(ByVal oConfiguration As Core.ApplicationContext)
        oAppContext = oConfiguration
    End Sub

    Friend Function GetGuiaActual() As Integer

        Dim strQuery As String = _
        " Select FolioGuias From CatalogoFolios "

        Dim oResult As Integer
        Dim sccnnConnection As New SqlConnection(oAppContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString)

        Dim sccmdSelect As SqlCommand

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = strQuery
            .CommandType = System.Data.CommandType.Text

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))

        End With


        Try
            sccnnConnection.Open()
            oResult = sccmdSelect.ExecuteScalar

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

    Friend Function GetStatusGuia() As Boolean

        Dim oResult As Boolean
        Dim sccnnConnection As New SqlConnection(oAppContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString)

        Dim sccmdSelect As SqlCommand

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[GetStatusGuia]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))

        End With


        Try
            sccnnConnection.Open()
            oResult = sccmdSelect.ExecuteScalar

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

    Friend Sub UpdateGuia(ByVal NumeroGuia As Integer)

        Dim sccnnConnection As New SqlConnection(oAppContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString)
        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand
        With sccmdInsert
            .Connection = sccnnConnection
            .CommandText = "[CatalogoFoliosUpd]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioGuias", System.Data.SqlDbType.Int, 4))
            
        End With
        Try
            sccnnConnection.Open()
            With sccmdInsert
                'Assign Parameters Values
                .Parameters("@FolioGuias").Value = NumeroGuia
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
            Throw New ApplicationException("El registro no pudo ser actualizado debido a un error de sistema.", ex)
        End Try
        sccnnConnection.Dispose()
        sccnnConnection = Nothing
    End Sub

End Class
