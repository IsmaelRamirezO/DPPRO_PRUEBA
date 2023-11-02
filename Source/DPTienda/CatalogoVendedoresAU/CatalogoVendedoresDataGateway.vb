
Option Explicit On 

Imports System.Data.SqlClient


Public Class CatalogoVendedoresDataGateway

    Private oParent As CatalogoVendedoresManager



#Region "Constructors / Destructors"

    Public Sub New(ByVal Parent As CatalogoVendedoresManager)

        oParent = Parent

    End Sub

#End Region



#Region "Methods"

    Public Function SelectByID(ByVal ID As String) As Vendedor

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader
        Dim oVendedor As Vendedor

        oVendedor = oParent.Create

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[CatalogoVendedoresSel]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodVendedor", System.Data.SqlDbType.VarChar, 10))

        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect
                'Assign Parameters Values
                .Parameters("@CodVendedor").Value = ID.PadLeft(8, "0")

                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    With scdrReader

                        oVendedor.ID = .GetString(0).ToUpper
                        oVendedor.Nombre = .GetString(1).ToUpper

                        'Reset New State of Linea Object 
                        oVendedor.ResetFlagNew()
                        oVendedor.ResetFlagDirty()

                    End With

                Else
                    oVendedor = Nothing
                End If

                scdrReader.Close()
            End With

            sccnnConnection.Close()

        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("El registro no pudo ser leido debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("El registro no pudo ser leido debido a un error de aplicación.", ex)

        End Try

        'If (oVendedor Is Nothing) Then
        'Throw New ApplicationException("El registro no pudo ser leido debido a que el ID de línea no existe.")
        'End If

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return oVendedor

    End Function


    Public Sub SelectInto(ByVal ID As String, ByVal oVendedor As Vendedor)

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[CatalogoVendedoresSel]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodVendedor", System.Data.SqlDbType.VarChar, 10))

        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect
                'Assign Parameters Values
                .Parameters("@CodVendedor").Value = ID.PadLeft(8, "0")

                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    With scdrReader

                        oVendedor.ID = .GetString(0).ToUpper
                        oVendedor.Nombre = .GetString(1).ToUpper

                        'Reset New State of Linea Object 
                        oVendedor.ResetFlagNew()
                        oVendedor.ResetFlagDirty()

                    End With

                End If

                scdrReader.Close()

            End With

            sccnnConnection.Close()

        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("El registro no pudo ser leido debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("El registro no pudo ser leido debido a un error de aplicación.", ex)

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

    End Sub


    Public Function SelectAll() As DataSet

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaVendedor As SqlDataAdapter
        Dim dsVendedor As DataSet

        sccmdSelectAll = New SqlCommand
        scdaVendedor = New SqlDataAdapter
        dsVendedor = New DataSet("CatalogoVendedores")

        With sccmdSelectAll

            .Connection = sccnnConnection

            .CommandText = "[CatalogoVendedoresSelAll]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))

        End With

        scdaVendedor.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            'Fill DataSet
            scdaVendedor.Fill(dsVendedor, "CatalogoVendedores")

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

        Return dsVendedor

    End Function

#End Region

End Class
