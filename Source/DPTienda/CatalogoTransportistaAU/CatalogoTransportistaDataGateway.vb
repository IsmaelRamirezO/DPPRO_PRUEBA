
Option Explicit On 

Imports System.Data.SqlClient


Public Class CatalogoTransportistaDataGateway

    Private oParent As CatalogoTransportistaManager



#Region "Constructors / Destructors"

    Public Sub New(ByVal Parent As CatalogoTransportistaManager)

        oParent = Parent

    End Sub

#End Region



#Region "Methods"

    Public Function SelectByID(ByVal ID As String) As Transportista

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader
        Dim oTransportista As Transportista

        oTransportista = oParent.Create

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[CatalogoTransportistaSel]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodTransportista", System.Data.SqlDbType.VarChar, 3))

        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect
                'Assign Parameters Values
                .Parameters("@CodTransportista").Value = ID

                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    With scdrReader

                        oTransportista.ID = .GetString(0).ToUpper
                        oTransportista.Nombre = .GetString(1).ToUpper
                        oTransportista.Tel = .GetString(2).ToUpper
                        oTransportista.Fax = .GetString(3).ToUpper
                        oTransportista.Puntuacion = .GetDecimal(4)
                        oTransportista.RFC = .GetString(5).ToUpper
                        oTransportista.Direccion = .GetString(6).ToUpper
                        oTransportista.Estado = .GetString(7).ToUpper
                        oTransportista.Pais = .GetString(8).ToUpper
                        oTransportista.CP = .GetString(9).ToUpper
                        'oTransportista.Predeterminado = .GetBoolean(10)
                        'oTransportista.Usuario = .GetString(11).ToUpper
                        'oTransportista.Fecha = .GetDateTime(12)
                        'oTransportista.Status = .GetBoolean(13)



                        'Reset New State of Linea Object 
                        oTransportista.ResetFlagNew()
                        oTransportista.ResetFlagDirty()

                    End With

                Else
                    oTransportista = Nothing
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

        If (oTransportista Is Nothing) Then
            Throw New ApplicationException("El registro no pudo ser leido debido a que el ID de línea no existe.")
        End If

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return oTransportista

    End Function



    Public Function SelectAll(ByVal EnabledRecordsOnly As Boolean) As DataSet

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaTransportista As SqlDataAdapter
        Dim dsTransportista As DataSet

        sccmdSelectAll = New SqlCommand
        scdaTransportista = New SqlDataAdapter
        dsTransportista = New DataSet("CatalogoTransportista")

        With sccmdSelectAll

            .Connection = sccnnConnection

            .CommandText = "[CatalogoTransportistaSelAll]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@OnlyEnabledRecords", System.Data.SqlDbType.Bit, 1))

        End With

        scdaTransportista.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            scdaTransportista.SelectCommand.Parameters("@OnlyEnabledRecords").Value = EnabledRecordsOnly

            'Fill DataSet
            scdaTransportista.Fill(dsTransportista, "CatalogoTransportistas")

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

        Return dsTransportista

    End Function

#End Region

End Class
