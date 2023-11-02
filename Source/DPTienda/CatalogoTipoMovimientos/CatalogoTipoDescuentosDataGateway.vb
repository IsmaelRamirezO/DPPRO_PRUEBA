
Imports System.Data.SqlClient


Public Class CatalogoTipoDescuentosDataGateway

    Private oParent As CatalogoTipoDescuentosManager



#Region "Constructors / Destructors"

    Public Sub New(ByVal Parent As CatalogoTipoDescuentosManager)

        oParent = Parent

    End Sub

#End Region



#Region "Methods"

    Public Function SelectByID(ByVal ID As String) As TipoDescuento

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader
        Dim oTipoDescuento As TipoDescuento

        oTipoDescuento = oParent.Create

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[CatalogoTipoDescuentoSel]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodTipoDescuento", System.Data.SqlDbType.VarChar, 3))

        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect
                'Assign Parameters Values
                .Parameters("@CodTipoDescuento").Value = ID

                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    With scdrReader

                        oTipoDescuento.ID = .GetString(0).ToUpper
                        oTipoDescuento.Descripcion = .GetString(1).ToUpper

                        'Reset New State of Linea Object 
                        oTipoDescuento.ResetFlagNew()
                        oTipoDescuento.ResetFlagDirty()

                    End With

                Else
                    oTipoDescuento = Nothing
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

        If (oTipoDescuento Is Nothing) Then
            Throw New ApplicationException("El registro no pudo ser leido debido a que el ID de línea no existe.")
        End If

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return oTipoDescuento

    End Function



    Public Function SelectAll(ByVal EnabledRecordsOnly As Boolean) As DataSet

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaTipoDescuento As SqlDataAdapter
        Dim dsTipoDescuento As DataSet

        sccmdSelectAll = New SqlCommand
        scdaTipoDescuento = New SqlDataAdapter
        dsTipoDescuento = New DataSet("CatalogoTipoDescuento")

        With sccmdSelectAll

            .Connection = sccnnConnection

            .CommandText = "[CatalogoTipoDescuentoSelAll]"
            .CommandType = System.Data.CommandType.StoredProcedure

        End With

        scdaTipoDescuento.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()
            'Fill DataSet
            scdaTipoDescuento.Fill(dsTipoDescuento, "CatalogoTipoDescuento")
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

        Return dsTipoDescuento

    End Function

#End Region




End Class
