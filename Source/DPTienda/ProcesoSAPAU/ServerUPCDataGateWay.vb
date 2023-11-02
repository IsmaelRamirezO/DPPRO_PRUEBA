Imports System
Imports System.Data
Imports System.Data.SqlClient


Public Class ServerUPCDataGateWay
    Private oParent As ServerUPCManager
    Private m_strConnectionString As String
    Private m_strConnectionStringCargas As String


#Region "Constructors / Destructors"

    Public Sub New(ByVal Parent As ServerUPCManager)

        oParent = Parent

        'm_strConnectionString = "Data Source=" & oParent.FirmaConfig.ServerFirma & "; Initial Catalog=Separaciones; User Id=" & oParent.FirmaConfig.UserFirma & " ;Password=" & oParent.FirmaConfig.PassFirma & ";TimeOut=120;"
        With oParent.FirmaConfig
            m_strConnectionString = "Data Source=" & .ServerSeparaciones & "; Initial Catalog=" & .BDSeparaciones & "; User Id=" & .UserSeparaciones & " ;Password=" & .PassSeparaciones & ";TimeOut=120;"
        End With

        m_strConnectionStringCargas = "Data Source=" & oParent.FirmaConfig.ServerFirma & "; Initial Catalog=" & oParent.FirmaConfig.BaseDatosFirmas & "; User Id=" & oParent.FirmaConfig.UserFirma & " ;Password=" & oParent.FirmaConfig.PassFirma & ";TimeOut=120;"


    End Sub


#End Region

    Public Function SelectUPC() As DataSet

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaUPC As SqlDataAdapter
        Dim dsUPC As DataSet

        sccmdSelectAll = New SqlCommand
        scdaUPC = New SqlDataAdapter
        dsUPC = New DataSet

        With sccmdSelectAll

            .Connection = sccnnConnection

            .CommandText = "[UPCSel]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        End With

        scdaUPC.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            'Fill DataSet
            scdaUPC.Fill(dsUPC)

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

        Return dsUPC

    End Function

    Public Function CargasInicialesSelByTienda(ByVal strTienda As String) As DataSet

        Dim sccnnConnection As New SqlConnection(m_strConnectionStringCargas)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaCI As SqlDataAdapter
        Dim dsCI As DataSet

        sccmdSelectAll = New SqlCommand
        scdaCI = New SqlDataAdapter
        dsCI = New DataSet

        With sccmdSelectAll

            .Connection = sccnnConnection

            .CommandText = "[CargasInicialesSel]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Tienda", System.Data.SqlDbType.VarChar, 3))

            .Parameters("@Tienda").Value = strTienda
        End With

        scdaCI.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            'Fill DataSet
            scdaCI.Fill(dsCI)

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

        Return dsCI

    End Function

    Public Sub CargasInicialesUpdByCatalogo(ByVal strTienda As String, ByVal strCodigo As String, ByVal Status As String, ByVal TdaNueva As Boolean, ByVal Desc As String, ByVal Nocturna As Boolean, Optional Cierre As Boolean = False)

        Dim sccnnConnection As New SqlConnection(m_strConnectionStringCargas)

        Dim sccmdUpd As SqlCommand

        sccmdUpd = New SqlCommand


        With sccmdUpd

            .Connection = sccnnConnection

            .CommandText = "[CargasInicialesUpdByCatalogoTemp]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Tienda", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Codigo", System.Data.SqlDbType.VarChar, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Status", System.Data.SqlDbType.VarChar, 2))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TdaNueva", System.Data.SqlDbType.Bit, 1))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Desc", System.Data.SqlDbType.VarChar, 50))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Nocturna", System.Data.SqlDbType.Bit, 1))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Cierre", System.Data.SqlDbType.Bit, 1))

            .Parameters("@Tienda").Value = strTienda
            .Parameters("@Codigo").Value = strCodigo
            .Parameters("@Status").Value = Status
            .Parameters("@TdaNueva").Value = TdaNueva
            .Parameters("@Desc").Value = Desc.Trim
            .Parameters("@Nocturna").Value = Nocturna
            .Parameters("@Cierre").Value = Cierre

        End With


        Try

            sccnnConnection.Open()

            With sccmdUpd

                'Ejecutamos Comando
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


    End Sub

    Public Sub SetCargasIniciales(ByVal strAlmacen As String)

        Dim sccnnConnection As New SqlConnection(m_strConnectionStringCargas)

        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand

        With sccmdInsert

            .Connection = sccnnConnection

            .CommandText = "[CargasInicialesUpd]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Almacen", System.Data.SqlDbType.VarChar, 3, "CodAlmacen"))


        End With

        Try

            sccnnConnection.Open()

            With sccmdInsert

                'Assign Parameters Values
                .Parameters("@Almacen").Value = strAlmacen

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

            MsgBox("El registro no pudo ser insertado debido a un error de base de datos.", MsgBoxStyle.Information, "DPTIENDA")

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            MsgBox("El registro no pudo ser insertado debido a un error de aplicación.", MsgBoxStyle.Information, "DPTIENDA")

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

    End Sub

    Public Sub SetCargasInicialesDiarias(ByVal strAlmacen As String)

        Dim sccnnConnection As New SqlConnection(m_strConnectionStringCargas)

        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand

        With sccmdInsert

            .Connection = sccnnConnection

            .CommandText = "[CargasInicialesUpdDiaria]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Almacen", System.Data.SqlDbType.VarChar, 3, "CodAlmacen"))

        End With

        Try

            sccnnConnection.Open()

            With sccmdInsert

                'Assign Parameters Values
                .Parameters("@Almacen").Value = strAlmacen

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

            MsgBox("El registro no pudo ser insertado debido a un error de base de datos.", MsgBoxStyle.Information, "DPTIENDA")

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            MsgBox("El registro no pudo ser insertado debido a un error de aplicación.", MsgBoxStyle.Information, "DPTIENDA")

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

    End Sub

End Class
