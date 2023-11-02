Imports DportenisPro.DPTienda
Imports DportenisPro.DPTienda.Core
Imports System.Data.SqlClient

Public Class CatalogoUPCDataGateWay

    Private oAppContext As Core.ApplicationContext

    Friend Sub New(ByVal oConfiguration As Core.ApplicationContext)
        oAppContext = oConfiguration
    End Sub

    Friend Function ConsultaUPC(ByVal CodUPC As String) As Material



        Dim oResult As Material
        Dim sccnnConnection As New SqlConnection(oAppContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString)

        Dim sccmdSelect As SqlCommand

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[CatalogoUPCSel]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodUPC", System.Data.SqlDbType.VarChar, 20))
            .Parameters("@CodUPC").Value = CodUPC.PadLeft(18, "0")

        End With



        Try

            sccnnConnection.Open()
            Dim oDataReader As SqlDataReader
            oDataReader = sccmdSelect.ExecuteReader
            If oDataReader.HasRows Then
                If oDataReader.Read Then
                    oResult = New Material
                    oResult.CodArticulo = oDataReader.GetString(oDataReader.GetOrdinal("CodArticulo"))
                    oResult.Talla = oDataReader.GetString(oDataReader.GetOrdinal("Numero"))
                End If
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

    Friend Function ConsultaMateriales(ByVal strCodigos As String, ByVal intCargarTodo As Boolean) As DataTable

        Dim oResult As New DataTable
        Dim sccnnConnection As New SqlConnection(oAppContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString)

        Dim sccmdSelect As SqlCommand

        sccmdSelect = New SqlCommand

        With sccmdSelect
            .CommandTimeout = oAppContext.ApplicationConfiguration.DataStorageConfiguration.ConnectionTimeout
            .Connection = sccnnConnection

            .CommandText = "[ConsultaMateriales]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodArt", System.Data.SqlDbType.VarChar, 8000))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@intCargarTodo", System.Data.SqlDbType.Bit, 1))
            .Parameters("@CodArt").Value = strCodigos
            .Parameters("@intCargarTodo").Value = intCargarTodo
        End With



        Try

            sccnnConnection.Open()
            Dim oSQLDataAdapter As New SqlClient.SqlDataAdapter(sccmdSelect)
            oSQLDataAdapter.Fill(oResult)
            oResult.TableName = "Materiales"

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

    Friend Function ConsultaExistencias(ByVal strCodigos As String, ByVal intCargarTodo As Boolean) As DataTable

        Dim oResult As New DataTable
        Dim sccnnConnection As New SqlConnection(oAppContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString)

        Dim sccmdSelect As SqlCommand

        sccmdSelect = New SqlCommand

        With sccmdSelect
            .CommandTimeout = oAppContext.ApplicationConfiguration.DataStorageConfiguration.ConnectionTimeout
            .Connection = sccnnConnection

            .CommandText = "[ConsultaExistencias]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodArt", System.Data.SqlDbType.VarChar, 8000))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@intCargarTodo", System.Data.SqlDbType.Bit, 1))
            .Parameters("@CodArt").Value = strCodigos
            .Parameters("@intCargarTodo").Value = intCargarTodo

        End With



        Try

            sccnnConnection.Open()
            Dim oSQLDataAdapter As New SqlClient.SqlDataAdapter(sccmdSelect)
            oSQLDataAdapter.Fill(oResult)
            oResult.TableName = "Existencias"

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

    Friend Function ConsultaLinea(ByVal CodLinea As String) As String

        Dim oResult As String
        Dim sccnnConnection As New SqlConnection(oAppContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString)

        Dim sccmdSelect As SqlCommand

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[ConsultaLinea]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodLinea", System.Data.SqlDbType.VarChar, 10))
            .Parameters("@CodLinea").Value = CodLinea

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

    Friend Function ConsultaCorrida(ByVal CodArt As String) As String

        Dim oResult As String
        Dim sccnnConnection As New SqlConnection(oAppContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString)

        Dim sccmdSelect As SqlCommand

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[ConsultaCorrida]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodArt", System.Data.SqlDbType.VarChar, 18))
            .Parameters("@CodArt").Value = CodArt

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

    Friend Function ConsultaFamilia(ByVal CodFamilia As String) As String

        Dim oResult As String
        Dim sccnnConnection As New SqlConnection(oAppContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString)

        Dim sccmdSelect As SqlCommand

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[ConsultaFamilia]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodFamilia", System.Data.SqlDbType.VarChar, 10))
            .Parameters("@CodFamilia").Value = CodFamilia

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

    Friend Function ConsultaMarca(ByVal CodMarca As String) As String

        Dim oResult As String
        Dim sccnnConnection As New SqlConnection(oAppContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString)

        Dim sccmdSelect As SqlCommand

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[ConsultaMarca]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodMarca", System.Data.SqlDbType.VarChar, 10))
            .Parameters("@CodMarca").Value = CodMarca

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
End Class
