Option Explicit On 

Imports System.Data.SqlClient


Public Class PolizaDataGateWay

    Private oParent As PolizaManager

#Region "Constructors / Destructors"

    Public Sub New(ByVal Parent As PolizaManager)

        oParent = Parent

    End Sub

#End Region


    Public Function GetRetiros(ByVal CodCaja As String, ByVal Fecha As DateTime) As DataSet

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaRetiros As SqlDataAdapter
        Dim dsRetiros As DataSet

        sccmdSelectAll = New SqlCommand
        scdaRetiros = New SqlDataAdapter
        dsRetiros = New DataSet("Retiros")

        With sccmdSelectAll

            .Connection = sccnnConnection


            .CommandText = "[RetirosSelBydateAndCodCaja]"

            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar, 2))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime, 8))


        End With

        scdaRetiros.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()


            scdaRetiros.SelectCommand.Parameters("@CodCaja").Value = CodCaja
            scdaRetiros.SelectCommand.Parameters("@Fecha").Value = Fecha


            'Fill DataSet
            scdaRetiros.Fill(dsRetiros, "Retiros")
            Dim n As Integer = dsRetiros.Tables("Retiros").Rows.Count

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

        Return dsRetiros



    End Function

    Public Function GetVentasTotales(ByVal CodCaja As String, ByVal Fecha As DateTime) As DataSet

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaRetiros As SqlDataAdapter
        Dim dsRetiros As DataSet

        sccmdSelectAll = New SqlCommand
        scdaRetiros = New SqlDataAdapter
        dsRetiros = New DataSet("Ventas")

        With sccmdSelectAll

            .Connection = sccnnConnection


            .CommandText = "[PolizaVentasTotales]"

            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar, 2))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime, 8))


        End With

        scdaRetiros.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()


            scdaRetiros.SelectCommand.Parameters("@CodCaja").Value = CodCaja
            scdaRetiros.SelectCommand.Parameters("@Fecha").Value = Fecha


            'Fill DataSet
            scdaRetiros.Fill(dsRetiros, "Ventas")


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

        Return dsRetiros



    End Function

    Public Function GetVentasTarjetas(ByVal CodCaja As String, ByVal Fecha As DateTime) As DataSet

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaRetiros As SqlDataAdapter
        Dim dsRetiros As DataSet

        sccmdSelectAll = New SqlCommand
        scdaRetiros = New SqlDataAdapter
        dsRetiros = New DataSet("Ventas")

        With sccmdSelectAll

            .Connection = sccnnConnection


            .CommandText = "[PolizaVentasTarjetas]"

            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar, 2))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime, 8))


        End With

        scdaRetiros.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()


            scdaRetiros.SelectCommand.Parameters("@CodCaja").Value = CodCaja
            scdaRetiros.SelectCommand.Parameters("@Fecha").Value = Fecha


            'Fill DataSet
            scdaRetiros.Fill(dsRetiros, "Ventas")


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

        Return dsRetiros



    End Function

End Class
