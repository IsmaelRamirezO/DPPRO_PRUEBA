
Imports System.Data.SqlClient
Imports DportenisPro.DPTienda.Core


Public Class CambiarFolioFacturaDataGateway

    Private oApplicationContext As ApplicationContext


#Region "Constructors / Destructors"

    Public Sub New(ByVal ApplicationContext As ApplicationContext)

        oApplicationContext = ApplicationContext

    End Sub

#End Region



#Region "Pubic Methods"


    Public Function MostrarFolioActual() As Integer

        Dim sccnnConnection As New SqlConnection(oApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                         GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        Dim intResult As Integer


        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[CambiarFolioFacturaMostrarFolioActual]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar, 2))

            'OutPut.
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioActual", System.Data.SqlDbType.Int))
            .Parameters("@FolioActual").Direction = ParameterDirection.Output

        End With


        Try

            sccnnConnection.Open()

            With sccmdSelect

                'Assign Parameters Values
                .Parameters("@CodCaja").Value = oApplicationContext.ApplicationConfiguration.NoCaja
                .Parameters("@FolioActual").Value = 0


                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    With scdrReader
                        intResult = .GetInt32(0)
                    End With


                End If

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

        Return intResult

    End Function


    Public Function ValidarFolio(ByVal intFolioNuevo As Integer) As Boolean

        Dim sccnnConnection As New SqlConnection(oApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        Dim bolResult As Boolean


        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[CambiarFolioFacturaValidarFolio]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar, 2))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioFactura", System.Data.SqlDbType.Int))

        End With


        Try

            sccnnConnection.Open()

            With sccmdSelect

                'Assign Parameters Values
                .Parameters("@CodCaja").Value = oApplicationContext.ApplicationConfiguration.NoCaja
                .Parameters("@CodAlmacen").Value = oApplicationContext.ApplicationConfiguration.Almacen
                .Parameters("@FolioFactura").Value = intFolioNuevo


                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    'El Folio se encuentre usado.
                    bolResult = True

                End If

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

        Return bolResult

    End Function


    Public Function ValidarFolioInicial(ByVal intFolioNuevo As Integer) As Boolean

        Dim intFolioInicial As Integer = ExtraerFolioFacturaInicial(Format(Date.Now, "Short Date"))

        If (intFolioNuevo < intFolioInicial) Then

            Return True

        End If

    End Function


    Public Sub Update(ByVal intFolioNuevo As Integer)

        Dim sccnnConnection As New SqlConnection(oApplicationContext.ApplicationConfiguration. _
                                                 DataStorageConfiguration.GetConnectionString)

        Dim sccmdUpdate As SqlCommand
        sccmdUpdate = New SqlCommand


        With sccmdUpdate

            .Connection = sccnnConnection

            .CommandText = "[CambiarFolioFacturaUpd]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioFactura", System.Data.SqlDbType.Int))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar, 2))

        End With

        Try

            sccnnConnection.Open()

            With sccmdUpdate

                'Assign Parameters Values

                .Parameters("@FolioFactura").Value = intFolioNuevo
                .Parameters("@CodCaja").Value = oApplicationContext.ApplicationConfiguration.NoCaja

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

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

    End Sub

#End Region



#Region "Private Methods"

    Public Function ExtraerFolioFacturaInicial(ByVal FechaCierre As Date) As Decimal

        Dim sccnnConnection As New SqlConnection(oApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        Dim intFolioFacturaInicial As Integer


        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            '.CommandText = "[CierreCajaExtraerFolioFacturaInicial]"
            .CommandText = "[CambiarFolioFacturaValidarFolioInicial]"
            .CommandType = System.Data.CommandType.StoredProcedure

            '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar))
            '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime))

            'OutPut :
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioFactura", System.Data.SqlDbType.Int))
            .Parameters("@FolioFactura").Direction = ParameterDirection.Output

        End With


        Try

            sccnnConnection.Open()

            With sccmdSelect

                'Assign Parameters Values
                .Parameters("@CodCaja").Value = oApplicationContext.ApplicationConfiguration.NoCaja
                '.Parameters("@Fecha").Value = Format(FechaCierre, "Short Date")
                .Parameters("@FolioFactura").Value = 0

                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    With scdrReader

                        'Return .GetDecimal(0)
                        intFolioFacturaInicial = .GetInt32(0)

                    End With

                Else

                    scdrReader.Close()
                    sccnnConnection.Close()

                    intFolioFacturaInicial = 0

                End If

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


        Return intFolioFacturaInicial

    End Function

#End Region

End Class
