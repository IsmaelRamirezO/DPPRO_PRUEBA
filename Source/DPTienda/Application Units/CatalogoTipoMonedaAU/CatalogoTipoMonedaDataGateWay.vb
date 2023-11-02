
Option Explicit On 

Imports System.Data.SqlClient


Public Class CatalogoTipoMonedaDataGateWay

    Private oParent As CatalogoTipoMonedaManager



#Region "Constructors / Destructors"

    Public Sub New(ByVal Parent As CatalogoTipoMonedaManager)

        oParent = Parent

    End Sub

#End Region



#Region "Methods"

    Public Function SelectByID(ByVal ID As String) As TipoMoneda

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader
        Dim oTipoMoneda As TipoMoneda

        oTipoMoneda = oParent.Create

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[CatalogoTipoMonedaSel]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodMoneda", System.Data.SqlDbType.Int, 4))

        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect
                'Assign Parameters Values
                .Parameters("@CodMoneda").Value = ID

                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    With scdrReader

                        oTipoMoneda.ID = .GetInt32(0)
                        oTipoMoneda.Descripcion = .GetString(1).ToUpper

                        'Reset New State of Linea Object 
                        oTipoMoneda.ResetFlagNew()
                        oTipoMoneda.ResetFlagDirty()

                    End With

                Else
                    oTipoMoneda = Nothing
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

        If (oTipoMoneda Is Nothing) Then
            Throw New ApplicationException("El registro no pudo ser leido debido a que el ID de Moneda no existe.")
        End If

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return oTipoMoneda

    End Function



    Public Function SelectAll(ByVal EnabledRecordsOnly As Boolean) As DataSet

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaTipoMoneda As SqlDataAdapter
        Dim dsTipoMoneda As DataSet

        sccmdSelectAll = New SqlCommand
        scdaTipoMoneda = New SqlDataAdapter
        dsTipoMoneda = New DataSet("CatalogoTipoMoneda")

        With sccmdSelectAll

            .Connection = sccnnConnection

            .CommandText = "[CatalogoTipoMonedaSelAll]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@OnlyEnabledRecords", System.Data.SqlDbType.Bit, 1))
        End With

        scdaTipoMoneda.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            scdaTipoMoneda.SelectCommand.Parameters("@OnlyEnabledRecords").Value = EnabledRecordsOnly

            'Fill DataSet
            scdaTipoMoneda.Fill(dsTipoMoneda, "CatalogoTipoMoneda")

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

        Return dsTipoMoneda

    End Function

#End Region

End Class
