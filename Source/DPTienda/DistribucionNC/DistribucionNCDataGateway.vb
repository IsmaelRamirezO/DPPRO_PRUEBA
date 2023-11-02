
Imports System.Data.SqlClient
Imports DportenisPro.DPTienda.ApplicationUnits.NotasCreditoAU
Imports DportenisPro.DPTienda.ApplicationUnits.ContratosAU


Public Class DistribucionNCDataGateway

    Private oParent As DistribucionNCManager



#Region "Constructors / Destructors"

    Public Sub New(ByVal Parent As DistribucionNCManager)
        oParent = Parent
    End Sub

#End Region



#Region "Properties"

    Public Property Parent() As DistribucionNCManager

        Get

            Return oParent

        End Get


        Set(ByVal Value As DistribucionNCManager)

            oParent = Value

        End Set

    End Property

#End Region



#Region "Methods"

    Public Sub ActualizaDOCNUMFB01xFolioAbono(ByVal ApartadoID As Integer, ByVal DOCNUMFB01 As String)

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                                 DataStorageConfiguration.GetConnectionString)

        Dim sccmdUpdate As SqlCommand
        sccmdUpdate = New SqlCommand

        With sccmdUpdate

            .Connection = sccnnConnection
            .CommandText = "[AbonosApartadosFB01UpdXFolioAbono]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@AbonoApartadoID", System.Data.SqlDbType.Int, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@DocNumFB01", System.Data.SqlDbType.VarChar, 10))


        End With

        Try

            sccnnConnection.Open()

            With sccmdUpdate
                'Assign Parameters Values
                .Parameters("@AbonoApartadoID").Value = ApartadoID
                .Parameters("@DocNumFB01").Value = DOCNUMFB01

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


        sccmdUpdate.Dispose()
        sccmdUpdate = Nothing

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

    End Sub

    Public Sub InsertaValeCajaDPVL(ByVal ValeCajaID As Integer, ByVal DocFI As String)

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                                 DataStorageConfiguration.GetConnectionString)

        Dim sccmdUpdate As SqlCommand
        sccmdUpdate = New SqlCommand

        With sccmdUpdate

            .Connection = sccnnConnection
            .CommandText = "[ValeCajaDPVLIns]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ValeCajaID", System.Data.SqlDbType.Int, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FIDEVOLUCION", System.Data.SqlDbType.VarChar, 10))


        End With

        Try

            sccnnConnection.Open()

            With sccmdUpdate
                'Assign Parameters Values
                .Parameters("@ValeCajaID").Value = ValeCajaID
                .Parameters("@FIDEVOLUCION").Value = DocFI

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

            MsgBox(oSqlException.Message & "No pudo ser insertado el FIDOCUMENT debido a un error de base de datos", MsgBoxStyle.Information, "Dptienda")

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If
            MsgBox(ex.Message & "No pudo ser insertado el FIDOCUMENT debido a un error de aplicación", MsgBoxStyle.Information, "Dptienda")


        End Try


        sccmdUpdate.Dispose()
        sccmdUpdate = Nothing

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

    End Sub

    Friend Function GetDpValeIDDP(ByVal FolioFactura As Integer) As String

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                                DataStorageConfiguration.GetConnectionString)


        Dim sccmdSelect As SqlCommand = New SqlCommand
        Dim scdrReader As SqlDataReader
        Dim DPValeID As String = ""

        Try

            With sccmdSelect

                .Connection = sccnnConnection
                '.CommandText = " SELECT FacturasFormasPago.DPValeID " & _
                '                " FROM  Factura INNER JOIN FacturasFormasPago ON " & _
                '                " Factura.FacturaID = FacturasFormasPago.FacturaID " & _
                '                " WHERE Factura.FolioFactura  = " & FolioFactura & _
                '                " ORDER by FacturasFormasPago.DPValeID DESC"
                .CommandText = "[FacturasGetDPValeID]"
                '.CommandType = CommandType.Text
                .CommandType = CommandType.StoredProcedure

                .Parameters.Add(New SqlParameter("@FacturaID", SqlDbType.Int, 4))

                .Parameters("@FacturaID").Value = FolioFactura
            End With
            sccnnConnection.Open()

            'Execute Command
            scdrReader = sccmdSelect.ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

            'Assign Other Values
            scdrReader.Read()
            If (scdrReader.HasRows) Then

                With scdrReader

                    'Return .GetInt32(0)
                    DPValeID = CStr(scdrReader("DPValeID"))

                End With

            End If

            scdrReader.Close()

            sccnnConnection.Close()

            'sccnnConnection.Dispose()
            'sccnnConnection = Nothing

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

        Return DPValeID

    End Function

    Friend Function GetDpVale(ByVal FolioFactura As Integer) As String

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                                DataStorageConfiguration.GetConnectionString)
        Dim sccmdSelect As SqlCommand = New SqlCommand
        Dim scdrReader As SqlDataReader
        Dim DPValeID As String = ""

        Try
            With sccmdSelect
                .Connection = sccnnConnection
                .CommandText = "[FacturasGetDPValeID]"                
                .CommandType = CommandType.StoredProcedure
                .Parameters.Add(New SqlParameter("@FacturaID", SqlDbType.Int, 4))
                .Parameters("@FacturaID").Value = FolioFactura
            End With
            sccnnConnection.Open()

            'Execute Command
            scdrReader = sccmdSelect.ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

            'Assign Other Values
            scdrReader.Read()
            If (scdrReader.HasRows) Then

                With scdrReader
                    'Return .GetInt32(0)
                    DPValeID = CStr(scdrReader("Referencia"))

                End With

            End If

            scdrReader.Close()

            sccnnConnection.Close()

            'sccnnConnection.Dispose()
            'sccnnConnection = Nothing

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

        Return DPValeID

    End Function



    Friend Function GetFacturaByNCID(ByVal ID As Integer) As String

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                                DataStorageConfiguration.GetConnectionString)


        Dim sccmdSelect As SqlCommand = New SqlCommand
        Dim scdrReader As SqlDataReader
        Dim intFacturaID As Integer = 0

        Try

            With sccmdSelect

                .Connection = sccnnConnection
                '.CommandText = " SELECT FolioReferencia " & _
                '                " FROM  NotasCreditoDetalle " & _
                '                " WHERE NotaCreditoID  = " & ID & _
                '                " "
                .CommandText = "[SelectFacturaID]"
                '.CommandType = CommandType.Text
                .CommandType = CommandType.StoredProcedure

                .Parameters.Add(New SqlParameter("@ID", SqlDbType.Int, 4))
                .Parameters.Add(New SqlParameter("@CodCaja", SqlDbType.VarChar, 3))

                .Parameters("@ID").Value = ID
                .Parameters("@CodCaja").Value = oParent.ApplicationContext.ApplicationConfiguration.NoCaja
            End With
            sccnnConnection.Open()

            'Execute Command
            scdrReader = sccmdSelect.ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

            'Assign Other Values
            scdrReader.Read()
            If (scdrReader.HasRows) Then

                With scdrReader

                    'Return .GetString(0)
                    intFacturaID = .GetInt32(.GetOrdinal("FacturaID"))

                End With

            End If

            scdrReader.Close()

            sccnnConnection.Close()

            'sccnnConnection.Dispose()
            'sccnnConnection = Nothing

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

        Return intFacturaID

    End Function

    Public Function DivisionSel() As String

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[ZPP_COBRANZASSelGSBERByWerks]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Almacen", System.Data.SqlDbType.VarChar, 4))

        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect
                'Assign Parameters Values
                .Parameters("@Almacen").Value = oParent.ApplicationContext.ApplicationConfiguration.Almacen

                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    With scdrReader

                        Return .GetString(0)

                        .Close()

                    End With


                Else
                    Return ""
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



    End Function


    Public Function SeleccionaCentro() As String

        Dim strResult As String

        Dim sccnnDPTienda As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdCatalogoCentrosSel As SqlCommand
        sccmdCatalogoCentrosSel = New SqlCommand

        With sccmdCatalogoCentrosSel
            .CommandText = "[CatalogoCentrosSel]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Connection = sccnnDPTienda
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@OficinaVtas", System.Data.SqlDbType.VarChar, 4))

            .Parameters("@OficinaVtas").Value = oParent.ApplicationContext.ApplicationConfiguration.Almacen
        End With

        Try
            sccnnDPTienda.Open()

            Dim scsdrReader As SqlDataReader

            scsdrReader = sccmdCatalogoCentrosSel.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.SingleRow)

            scsdrReader.Read()

            If (scsdrReader.HasRows) Then

                With scsdrReader
                    strResult = .GetString(0) 'Cod Centro SAP
                End With
                scsdrReader.Close()

            Else

                strResult = String.Empty

            End If


        Catch ex As Exception

            Throw ex

        Finally

            If (sccnnDPTienda.State <> ConnectionState.Closed) Then
                Try
                    sccnnDPTienda.Close()
                Catch
                End Try
            End If

        End Try

        sccmdCatalogoCentrosSel.Dispose()
        sccmdCatalogoCentrosSel = Nothing

        sccnnDPTienda.Dispose()
        sccnnDPTienda = Nothing

        Return strResult
    End Function



    Public Function SelectNombreTienda(ByVal strTipoPago As String, ByVal strCentro As String) As String

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)


        Dim strResult As String
        Dim sccmdSelectAll As SqlCommand
        sccmdSelectAll = New SqlCommand


        With sccmdSelectAll

            .Connection = sccnnConnection

            .CommandText = "[ZPP_COBRANZASSel]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@DPCLAVE", System.Data.SqlDbType.VarChar, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Clacobr", System.Data.SqlDbType.VarChar, 9))

            .Parameters("@DPCLAVE").Value = strCentro
            .Parameters("@Clacobr").Value = strTipoPago

        End With


        Try

            sccnnConnection.Open()

            Dim scsdrReader As SqlDataReader

            scsdrReader = sccmdSelectAll.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.SingleRow)

            scsdrReader.Read()

            If (scsdrReader.HasRows) Then

                With scsdrReader
                    strResult = .GetString(0) & "#" & .GetString(1)
                End With
                scsdrReader.Close()

            Else

                strResult = String.Empty

            End If


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

        Return strResult

    End Function



    Public Sub NotaCreditoAnticipoClienteNoCancelacionUpd(ByVal dsNotaCreditoDetalle As DataSet)

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                                 DataStorageConfiguration.GetConnectionString)

        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand

        Dim drFactura As DataRow


        With sccmdInsert

            .Connection = sccnnConnection

            .CommandText = "[NotaCreditoAnticiposClientesNoCancelacionUpd]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@AnticipoDetalleID", System.Data.SqlDbType.Int))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@NumCancelacion", System.Data.SqlDbType.VarChar, 20))

        End With

        Try

            sccnnConnection.Open()


            For Each drFactura In dsNotaCreditoDetalle.Tables("AnticiposClientesDetalle").Rows

                If (drFactura("NumeroTarjeta") <> String.Empty) Then

                    With sccmdInsert

                        'Assign Parameters Values

                        .Parameters("@AnticipoDetalleID").Value = drFactura("AnticipoDetalleID")
                        .Parameters("@NumCancelacion").Value = drFactura("NumeroAutorizacionCancelacion")


                        'Execute Command
                        .ExecuteNonQuery()

                    End With

                End If

            Next


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



    Private Function DPValeCalcularTotal(ByVal intAnticipoID As Integer) As Decimal

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        Dim dsDataSet As DataSet
        dsDataSet = New DataSet

        Dim decValor As Decimal



        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[NotaCreditoAnticiposClientesDPValeCalcularTotal]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@AnticipoID", System.Data.SqlDbType.Int))


            'OutPut :
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@MontoCancelarDPVale", System.Data.SqlDbType.Int))
            .Parameters("@MontoCancelarDPVale").Direction = ParameterDirection.Output

        End With


        Try

            sccnnConnection.Open()

            With sccmdSelect

                'Assign Parameters Values
                .Parameters("@AnticipoID").Value = intAnticipoID
                .Parameters("@MontoCancelarDPVale").Value = 0

                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) And (IsDBNull(scdrReader.Item(0)) <> True) Then

                    With scdrReader

                        decValor = .GetDecimal(0)

                        scdrReader.Close()
                        sccnnConnection.Close()

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

        Return decValor

    End Function



    Private Function CDTCalcularTotal(ByVal intAnticipoID As Integer) As Decimal

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        Dim dsDataSet As DataSet
        dsDataSet = New DataSet

        Dim decValor As Decimal



        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "NotaCreditoAnticiposClientesCDTCalcularTotal"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@AnticipoID", System.Data.SqlDbType.Int))


            'OutPut :
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@MontoCancelarCDT", System.Data.SqlDbType.Int))
            .Parameters("@MontoCancelarCDT").Direction = ParameterDirection.Output

        End With


        Try

            sccnnConnection.Open()

            With sccmdSelect

                'Assign Parameters Values
                .Parameters("@AnticipoID").Value = intAnticipoID
                .Parameters("@MontoCancelarCDT").Value = 0

                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) And (IsDBNull(scdrReader.Item(0)) <> True) Then

                    With scdrReader

                        decValor = .GetDecimal(0)

                        scdrReader.Close()
                        sccnnConnection.Close()

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

        Return decValor

    End Function


    Private Function FonacotFacilitoCalcularTotal(ByVal intAnticipoID As Integer) As Decimal

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        Dim dsDataSet As DataSet
        dsDataSet = New DataSet

        Dim decValor As Decimal



        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "NotaCreditoAnticiposClientesFonacotFacilitoCalcularTotal"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@AnticipoID", System.Data.SqlDbType.Int))


            'OutPut :
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@MontoCanceladoFonacotFacilito", System.Data.SqlDbType.Int))
            .Parameters("@MontoCanceladoFonacotFacilito").Direction = ParameterDirection.Output

        End With


        Try

            sccnnConnection.Open()

            With sccmdSelect

                'Assign Parameters Values
                .Parameters("@AnticipoID").Value = intAnticipoID
                .Parameters("@MontoCanceladoFonacotFacilito").Value = 0

                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) And (IsDBNull(scdrReader.Item(0)) <> True) Then

                    With scdrReader

                        decValor = .GetDecimal(0)

                        scdrReader.Close()
                        sccnnConnection.Close()

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

        Return decValor

    End Function

    Public Function ContratoAnticipoClienteSelect(ByVal intAnticipoID As Integer, ByVal strModulo As String) As DistribucionNC

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        Dim dsDataSet As DataSet
        dsDataSet = New DataSet("Apartados")

        Dim oDistribucionNC As New DistribucionNC(oParent)

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[ContratoAnticipoClienteSel]" '"[NotaCreditoAnticipoClienteSel]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@AnticipoID", System.Data.SqlDbType.Int))

        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect

                'Assign Parameters Values
                .Parameters("@AnticipoID").Value = intAnticipoID

                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    'Traspaso General :
                    With scdrReader

                        oDistribucionNC.ID = .GetInt32(.GetOrdinal("AnticipoID"))
                        oDistribucionNC.AlmacenID = .GetString(.GetOrdinal("CodAlmacen"))
                        oDistribucionNC.CajaID = .GetString(.GetOrdinal("CodCaja"))
                        oDistribucionNC.Referencia = .GetInt32(.GetOrdinal("Referencia"))
                        oDistribucionNC.ClienteID = .GetString(.GetOrdinal("ClienteID"))
                        oDistribucionNC.Nombre = .GetString(.GetOrdinal("Nombre"))
                        oDistribucionNC.GeneradoPor = .GetString(.GetOrdinal("GeneradoPor"))
                        oDistribucionNC.TotalAnticipoCliente = .GetDecimal(.GetOrdinal("TotalAnticipoCliente"))
                        oDistribucionNC.TotalTarjetaCredito = .GetDecimal(.GetOrdinal("TotalTarjetaCredito"))
                        oDistribucionNC.SaldoAnticipoCliente = .GetDecimal(.GetOrdinal("SaldoAnticipoCliente"))
                        oDistribucionNC.TotalAbonos = .GetDecimal(.GetOrdinal("TotalAbonos"))
                        oDistribucionNC.Penalizacion = .GetDecimal(.GetOrdinal("Penalizacion"))
                        oDistribucionNC.DevEfectivo = .GetString(.GetOrdinal("DevEfectivo"))
                        oDistribucionNC.MotivoCancelacion = .GetString(.GetOrdinal("MotivoCancelacion"))
                        oDistribucionNC.Usuario = .GetString(.GetOrdinal("Usuario"))
                        oDistribucionNC.Fecha = .GetDateTime(.GetOrdinal("Fecha"))
                        oDistribucionNC.StatusRegistro = .GetBoolean(.GetOrdinal("StatusRegistro"))
                        oDistribucionNC.TotalDPVale = DPValeCalcularTotal(oDistribucionNC.ID)
                        oDistribucionNC.TotalCDT = CDTCalcularTotal(oDistribucionNC.ID)
                        oDistribucionNC.TotalFonacotFacilito = FonacotFacilitoCalcularTotal(oDistribucionNC.ID)
                        '----------------------------------------------------------------------------------------
                        'FLIZARRAGA 18/09/2018: Obtenemos el total del canje
                        '----------------------------------------------------------------------------------------
                        oDistribucionNC.TotalCanje = CanjeCalcularTotal(oDistribucionNC.ID)
                        .Close()

                    End With


                    'Anticipo Detalle [GRID] :

                    Dim scdaAdapter As New SqlDataAdapter

                    sccmdSelect.Dispose()
                    sccmdSelect = Nothing

                    sccmdSelect = New SqlCommand

                    With sccmdSelect

                        .Connection = sccnnConnection

                        .CommandText = "[AnticiposClientesDetalleSel]"
                        .CommandType = System.Data.CommandType.StoredProcedure

                        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
                        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@AnticipoID", System.Data.SqlDbType.Int))
                        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Modulo", System.Data.SqlDbType.VarChar, 2))

                        .Parameters("@AnticipoID").Value = oDistribucionNC.ID
                        .Parameters("@Modulo").Value = strModulo

                    End With

                    scdaAdapter.SelectCommand = sccmdSelect
                    scdaAdapter.Fill(dsDataSet, "AnticiposClientesDetalle")

                    oDistribucionNC.Detalle = dsDataSet

                    dsDataSet.Dispose()
                    sccmdSelect.Dispose()
                    scdaAdapter.Dispose()

                    dsDataSet = Nothing
                    sccmdSelect = Nothing
                    scdaAdapter = Nothing

                    oDistribucionNC.ResetFlagNew()
                    oDistribucionNC.ResetFlagDirty()

                Else
                    oDistribucionNC = Nothing
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

        Return oDistribucionNC

    End Function

    Public Function ContratoAnticipoClienteSelectByRef(ByVal FolioRef As Integer, ByVal CodCaja As String, ByVal strModulo As String) As DistribucionNC

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        Dim dsDataSet As DataSet
        dsDataSet = New DataSet("Apartados")

        Dim oDistribucionNC As New DistribucionNC(oParent)

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[ContratoAnticipoClienteSelByRef]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioRef", System.Data.SqlDbType.Int))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar, 3))

        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect

                'Assign Parameters Values
                .Parameters("@FolioRef").Value = FolioRef
                .Parameters("@CodCaja").Value = CodCaja.Trim.PadLeft(2, "0")

                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    'Traspaso General :
                    With scdrReader

                        oDistribucionNC.ID = .GetInt32(.GetOrdinal("AnticipoID"))
                        oDistribucionNC.AlmacenID = .GetString(.GetOrdinal("CodAlmacen"))
                        oDistribucionNC.CajaID = .GetString(.GetOrdinal("CodCaja"))
                        oDistribucionNC.Referencia = .GetInt32(.GetOrdinal("Referencia"))
                        oDistribucionNC.ClienteID = .GetString(.GetOrdinal("ClienteID"))
                        oDistribucionNC.Nombre = .GetString(.GetOrdinal("Nombre"))
                        oDistribucionNC.GeneradoPor = .GetString(.GetOrdinal("GeneradoPor"))
                        oDistribucionNC.TotalAnticipoCliente = .GetDecimal(.GetOrdinal("TotalAnticipoCliente"))
                        oDistribucionNC.TotalTarjetaCredito = .GetDecimal(.GetOrdinal("TotalTarjetaCredito"))
                        oDistribucionNC.SaldoAnticipoCliente = .GetDecimal(.GetOrdinal("SaldoAnticipoCliente"))
                        oDistribucionNC.TotalAbonos = .GetDecimal(.GetOrdinal("TotalAbonos"))
                        oDistribucionNC.Penalizacion = .GetDecimal(.GetOrdinal("Penalizacion"))
                        oDistribucionNC.DevEfectivo = .GetString(.GetOrdinal("DevEfectivo"))
                        oDistribucionNC.MotivoCancelacion = .GetString(.GetOrdinal("MotivoCancelacion"))
                        oDistribucionNC.Usuario = .GetString(.GetOrdinal("Usuario"))
                        oDistribucionNC.Fecha = .GetDateTime(.GetOrdinal("Fecha"))
                        oDistribucionNC.StatusRegistro = .GetBoolean(.GetOrdinal("StatusRegistro"))
                        oDistribucionNC.TotalDPVale = DPValeCalcularTotal(oDistribucionNC.ID)
                        oDistribucionNC.TotalCDT = CDTCalcularTotal(oDistribucionNC.ID)
                        oDistribucionNC.TotalFonacotFacilito = FonacotFacilitoCalcularTotal(oDistribucionNC.ID)
                        .Close()

                    End With


                    'Anticipo Detalle [GRID] :

                    Dim scdaAdapter As New SqlDataAdapter

                    sccmdSelect.Dispose()
                    sccmdSelect = Nothing

                    sccmdSelect = New SqlCommand

                    With sccmdSelect

                        .Connection = sccnnConnection

                        .CommandText = "[AnticiposClientesDetalleSel]"
                        .CommandType = System.Data.CommandType.StoredProcedure

                        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
                        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@AnticipoID", System.Data.SqlDbType.Int))
                        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Modulo", System.Data.SqlDbType.VarChar, 2))

                        .Parameters("@AnticipoID").Value = oDistribucionNC.ID
                        .Parameters("@Modulo").Value = strModulo

                    End With

                    scdaAdapter.SelectCommand = sccmdSelect
                    scdaAdapter.Fill(dsDataSet, "AnticiposClientesDetalle")

                    oDistribucionNC.Detalle = dsDataSet

                    dsDataSet.Dispose()
                    sccmdSelect.Dispose()
                    scdaAdapter.Dispose()

                    dsDataSet = Nothing
                    sccmdSelect = Nothing
                    scdaAdapter = Nothing

                    oDistribucionNC.ResetFlagNew()
                    oDistribucionNC.ResetFlagDirty()

                Else
                    oDistribucionNC = Nothing
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

        Return oDistribucionNC

    End Function



    Public Sub ContratoAnticipoClienteNoCancelacionUpd(ByVal dsNotaCreditoDetalle As DataSet)

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                                 DataStorageConfiguration.GetConnectionString)

        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand

        Dim drAbono As DataRow


        With sccmdInsert

            .Connection = sccnnConnection

            .CommandText = "[ContratoAnticiposClientesNoCancelacionUpd]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@AnticipoDetalleID", System.Data.SqlDbType.Int))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@NumCancelacion", System.Data.SqlDbType.VarChar, 20))

        End With

        Try

            sccnnConnection.Open()


            For Each drAbono In dsNotaCreditoDetalle.Tables("AnticiposClientesDetalle").Rows

                If (drAbono("NumeroTarjeta") <> String.Empty) And (drAbono("MontoCanceladoTarjeta") > 0) Then

                    With sccmdInsert

                        'Assign Parameters Values

                        .Parameters("@AnticipoDetalleID").Value = drAbono("AnticipoDetalleID")
                        .Parameters("@NumCancelacion").Value = drAbono("NumeroAutorizacionCancelacion")


                        'Execute Command
                        .ExecuteNonQuery()

                    End With

                End If

            Next


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



    Public Sub ContratoMotivoCancelacionUpd(ByVal intAnticipoID As Integer, ByVal strMotivoCancelacion As String)

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                                 DataStorageConfiguration.GetConnectionString)

        Dim sccmdUpdate As SqlCommand
        sccmdUpdate = New SqlCommand


        With sccmdUpdate

            .Connection = sccnnConnection

            .CommandText = "[ContratoAnticiposClientesMotivoUpd]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@AnticipoID", System.Data.SqlDbType.Int))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@MotivoCancelacion", System.Data.SqlDbType.VarChar))

        End With


        Try
            sccnnConnection.Open()

            With sccmdUpdate

                'Assign Parameters Values

                .Parameters("@AnticipoID").Value = intAnticipoID
                .Parameters("@MotivoCancelacion").Value = strMotivoCancelacion

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

#Region "Mejoras Lealtad"

    Private Function CanjeCalcularTotal(ByVal intAnticipoID As Integer) As Decimal

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        Dim dsDataSet As DataSet
        dsDataSet = New DataSet

        Dim decValor As Decimal



        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[NotaCreditoAnticiposClientesCanje]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@AnticipoID", System.Data.SqlDbType.Int))


            'OutPut :
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@MontoCancelarCanje", System.Data.SqlDbType.Int))
            .Parameters("@MontoCancelarCanje").Direction = ParameterDirection.Output

        End With


        Try

            sccnnConnection.Open()

            With sccmdSelect

                'Assign Parameters Values
                .Parameters("@AnticipoID").Value = intAnticipoID
                .Parameters("@MontoCancelarCanje").Value = 0

                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) And (IsDBNull(scdrReader.Item(0)) <> True) Then

                    With scdrReader

                        decValor = .GetDecimal(0)

                        scdrReader.Close()
                        sccnnConnection.Close()

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

        Return decValor

    End Function

#End Region

End Class
