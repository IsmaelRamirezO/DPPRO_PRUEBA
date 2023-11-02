Imports System.Data.SqlClient

Public Class ValeCajaDataGateway

    Private oParent As ValeCajaManager

#Region "Constructors / Destructors"

    Public Sub New(ByVal Parent As ValeCajaManager)

        oParent = Parent

    End Sub

#End Region

#Region "Methods"

    Public Sub Insert(ByVal pValeCaja As ValeCaja)



        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                                 DataStorageConfiguration.GetConnectionString)

        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand

        With sccmdInsert

            .Connection = sccnnConnection

            .CommandText = "[ValeCajaIns]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TipoDocumento", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioDocumento", System.Data.SqlDbType.VarChar, 10))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@DocumentoID", System.Data.SqlDbType.Int))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCliente", System.Data.SqlDbType.VarChar, 10))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Nombre", System.Data.SqlDbType.VarChar, 30))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Importe", System.Data.SqlDbType.Money, 8))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@MontoUtilizado", System.Data.SqlDbType.Money))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ValeGenerado", System.Data.SqlDbType.Int))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@DevEfectivo", System.Data.SqlDbType.Bit))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Motivo", System.Data.SqlDbType.VarChar, 255))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Usuario", System.Data.SqlDbType.VarChar, 12))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@StatusRegistro", System.Data.SqlDbType.Bit))

            'OutPut :
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ValeCajaID", System.Data.SqlDbType.Int))
            .Parameters("@ValeCajaID").Direction = ParameterDirection.Output

        End With

        Try

            sccnnConnection.Open()

            With sccmdInsert

                'Assign Parameters Values
                .Parameters("@TipoDocumento").Value = pValeCaja.TipoDocumento
                .Parameters("@DocumentoID").Value = pValeCaja.DocumentoID
                .Parameters("@FolioDocumento").Value = pValeCaja.FolioDocumento
                .Parameters("@CodCliente").Value = pValeCaja.CodCliente.PadLeft(10, "0")
                .Parameters("@Nombre").Value = pValeCaja.Nombre
                .Parameters("@Importe").Value = pValeCaja.Importe
                .Parameters("@MontoUtilizado").Value = pValeCaja.MontoUtilizado
                .Parameters("@ValeGenerado").Value = pValeCaja.ValeGenerado
                .Parameters("@DevEfectivo").Value = pValeCaja.DevEfectivo
                .Parameters("@Motivo").Value = pValeCaja.Motivo
                .Parameters("@Fecha").Value = pValeCaja.Fecha
                .Parameters("@Usuario").Value = pValeCaja.Usuario
                .Parameters("@StatusRegistro").Value = pValeCaja.StastusRegistro

                'Execute Command
                .ExecuteNonQuery()

                pValeCaja.ValeCajaID = .Parameters("@ValeCajaID").Value

            End With

            'Reset New State of Linea Object 
            pValeCaja.ResetFlagNew()
            pValeCaja.ResetFlagDirty()

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

    Public Function Folios() As Integer

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        Dim intFolio As Integer


        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[ValeCajaFolios]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            

            'OutPut :
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Folio", System.Data.SqlDbType.Int))
            .Parameters("@Folio").Direction = ParameterDirection.Output

        End With


        Try

            sccnnConnection.Open()

            With sccmdSelect

                'Assign Parameters Values                
                .Parameters("@Folio").Value = 0

                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    With scdrReader

                        'Return .GetDecimal(0)
                        intFolio = .GetInt32(0)

                    End With

                Else

                    scdrReader.Close()
                    sccnnConnection.Close()

                    intFolio = 0

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


        Return intFolio

    End Function

    Public Function SelectByID(ByVal ID As Integer) As ValeCaja

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader
        Dim oValeCaja As ValeCaja

        oValeCaja = oParent.Create

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[ValeCajaSel]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ValeCajaID", System.Data.SqlDbType.Int, 4))


        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect
                'Assign Parameters Values
                .Parameters("@ValeCajaID").Value = ID

                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    With scdrReader

                        oValeCaja.ValeCajaID = .GetInt32(.GetOrdinal("ValeCajaID"))
                        oValeCaja.TipoDocumento = .GetString(.GetOrdinal("TipoDocumento"))
                        oValeCaja.FolioDocumento = .GetString(.GetOrdinal("FolioDocumento"))
                        oValeCaja.DocumentoID = .GetInt32(.GetOrdinal("DocumentoID"))
                        oValeCaja.CodCliente = .GetString(.GetOrdinal("CodCliente"))
                        oValeCaja.ValeCajaID = .GetInt32(.GetOrdinal("ValeCajaID"))
                        oValeCaja.Nombre = .GetString(.GetOrdinal("Nombre"))
                        oValeCaja.Importe = .GetDecimal(.GetOrdinal("Importe"))
                        oValeCaja.MontoUtilizado = .GetDecimal(.GetOrdinal("MontoUtilizado"))
                        oValeCaja.ValeGenerado = .GetInt32(.GetOrdinal("ValeGenerado"))
                        oValeCaja.DevEfectivo = .GetBoolean(.GetOrdinal("DevEfectivo"))
                        oValeCaja.Motivo = .GetString(.GetOrdinal("Motivo"))
                        oValeCaja.Fecha = .GetDateTime(.GetOrdinal("Fecha"))
                        oValeCaja.Usuario = .GetString(.GetOrdinal("Usuario"))
                        oValeCaja.StastusRegistro = .GetBoolean(.GetOrdinal("StatusRegistro"))
                        oValeCaja.FolioFITrasladoSaldo = .GetString(.GetOrdinal("FolioFITS"))
                        If .IsDBNull(.GetOrdinal("FolioFISAP")) = False Then
                            oValeCaja.FolioFISAP = .GetString(.GetOrdinal("FolioFISAP"))
                        Else
                            oValeCaja.FolioFISAP = ""
                        End If

                        'Reset New State of Linea Object 
                        oValeCaja.ResetFlagNew()
                        oValeCaja.ResetFlagDirty()

                    End With

                Else
                    oValeCaja = Nothing
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

        If (oValeCaja Is Nothing) Then
            'Throw New ApplicationException("El registro no pudo ser leido debido a que el ID de línea no existe.")
        End If

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return oValeCaja

    End Function

    Public Function SelectFolioFI(ByVal TipoDoc As String, ByVal Folio As String, ByRef FolioFIVta As String) As String

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader
        Dim strFolioFI As String = ""

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[ValeCajaSelFolioFI]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TipoDoc", System.Data.SqlDbType.VarChar, 2))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Folio", System.Data.SqlDbType.VarChar, 10))

        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect
                'Assign Parameters Values
                .Parameters("@TipoDoc").Value = TipoDoc.Trim.ToUpper
                .Parameters("@Folio").Value = Folio.Trim.PadLeft(10, "0")

                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    With scdrReader

                        strFolioFI = .GetString(.GetOrdinal("FolioFIDev"))
                        FolioFIVta = .GetString(.GetOrdinal("FolioFIVta"))
                        strFolioFI = strFolioFI.Trim.PadLeft(10, "0")
                        FolioFIVta = FolioFIVta.Trim.PadLeft(10, "0")

                    End With

                Else
                    strFolioFI = ""
                    FolioFIVta = ""
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

        Return strFolioFI

    End Function

    Public Sub Update(ByVal oValeCaja As ValeCaja)

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                                 DataStorageConfiguration.GetConnectionString)

        Dim sccmdUpdate As SqlCommand
        sccmdUpdate = New SqlCommand

        With sccmdUpdate

            .Connection = sccnnConnection

            .CommandText = "[ValeCajaUpd]"
            .CommandType = System.Data.CommandType.StoredProcedure

            '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ValeCajaID", System.Data.SqlDbType.Int, 4, "ValeCajaID"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TipoDocumento", System.Data.SqlDbType.VarChar, 3, "TipoDocumento"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioDocumento", System.Data.SqlDbType.VarChar, 10, "FolioDocumento"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@DocumentoID", System.Data.SqlDbType.Int, 4, "DocumentoID"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCliente", System.Data.SqlDbType.VarChar, 10, "CodCliente"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Nombre", System.Data.SqlDbType.VarChar, 30, "Nombre"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Importe", System.Data.SqlDbType.Money, 8, "Importe"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@MontoUtilizado", System.Data.SqlDbType.Money, 8, "MontoUtilizado"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ValeGenerado", System.Data.SqlDbType.Int, 4, "ValeGenerado"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@DevEfectivo", System.Data.SqlDbType.Bit, 1, "DevEfectivo"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Motivo", System.Data.SqlDbType.VarChar, 255, "Motivo"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime, 8, "Fecha"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Usuario", System.Data.SqlDbType.VarChar, 12, "Usuario"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@StatusRegistro", System.Data.SqlDbType.Bit, 1, "StatusRegistro"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioFITS", System.Data.SqlDbType.VarChar, 10, "FolioFI Traslado"))

        End With

        Try

            sccnnConnection.Open()

            With sccmdUpdate
                'Assign Parameters Values
                .Parameters("@ValeCajaID").Value = oValeCaja.ValeCajaID
                .Parameters("@TipoDocumento").Value = oValeCaja.TipoDocumento
                .Parameters("@FolioDocumento").Value = oValeCaja.FolioDocumento
                .Parameters("@DocumentoID").Value = oValeCaja.DocumentoID
                .Parameters("@CodCliente").Value = oValeCaja.CodCliente.PadLeft(10, "0")
                .Parameters("@Nombre").Value = oValeCaja.Nombre
                .Parameters("@Importe").Value = oValeCaja.Importe
                .Parameters("@MontoUtilizado").Value = oValeCaja.MontoUtilizado
                .Parameters("@ValeGenerado").Value = oValeCaja.ValeGenerado
                .Parameters("@DevEfectivo").Value = oValeCaja.DevEfectivo
                .Parameters("@Motivo").Value = oValeCaja.Motivo
                .Parameters("@Fecha").Value = oValeCaja.Fecha
                .Parameters("@Usuario").Value = oValeCaja.Usuario
                .Parameters("@StatusRegistro").Value = oValeCaja.StastusRegistro
                .Parameters("@FolioFITS").Value = IIf(oValeCaja.FolioFITrasladoSaldo.Trim = "", "", oValeCaja.FolioFITrasladoSaldo.Trim.PadLeft(10, "0"))

                'Execute Command
                .ExecuteNonQuery()

                'Assign Other Values
            End With

            'Reset New State of Linea Object 
            'Linea.ResetStateNew()
            oValeCaja.ResetFlagDirty()

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

            Throw New ApplicationException("El registro no pudo ser actualizado debido a un error de aplicación.", ex)

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

    End Sub

    Public Function SelectAll(ByVal EnabledRecordsOnly As Boolean) As DataSet

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaValeCaja As SqlDataAdapter
        Dim dsValeCaja As DataSet

        sccmdSelectAll = New SqlCommand
        scdaValeCaja = New SqlDataAdapter
        dsValeCaja = New DataSet("CatalogoCajas")

        With sccmdSelectAll

            .Connection = sccnnConnection

            .CommandText = "[ValeCajaSelAll]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@OnlyEnabledRecords", System.Data.SqlDbType.Bit, 1))

        End With

        scdaValeCaja.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            scdaValeCaja.SelectCommand.Parameters("@OnlyEnabledRecords").Value = EnabledRecordsOnly

            'Fill DataSet
            scdaValeCaja.Fill(dsValeCaja, "ValesCajas")

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

        Return dsValeCaja

    End Function

    'Public Function SelectByFolioDocumento(ByVal FolioDocumento As Integer) As DataSet ', ByVal TipoDocumento As String) As DataSet

    '    Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
    '                                             GetConnectionString)

    '    Dim sccmdSelectAll As SqlCommand
    '    Dim scdaValeCaja As SqlDataAdapter
    '    Dim dsValeCaja As DataSet

    '    sccmdSelectAll = New SqlCommand
    '    scdaValeCaja = New SqlDataAdapter
    '    dsValeCaja = New DataSet("ValesCajas")

    '    With sccmdSelectAll

    '        .Connection = sccnnConnection

    '        .CommandText = "[ValeCajaSelByFolioDocumento]"
    '        .CommandType = System.Data.CommandType.StoredProcedure

    '        '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioDocumento", System.Data.SqlDbType.VarChar, 10))
    '        '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@TipoDocumento", System.Data.SqlDbType.VarChar, 2))

    '    End With

    '    scdaValeCaja.SelectCommand = sccmdSelectAll

    '    Try

    '        sccnnConnection.Open()

    '        scdaValeCaja.SelectCommand.Parameters("@FolioDocumento").Value = FolioDocumento
    '        'scdaValeCaja.SelectCommand.Parameters("@TipoDocumento").Value = TipoDocumento

    '        'Fill DataSet
    '        scdaValeCaja.Fill(dsValeCaja, "ValesCajas")

    '        sccnnConnection.Close()

    '    Catch oSqlException As SqlException

    '        If (sccnnConnection.State <> ConnectionState.Closed) Then
    '            Try
    '                sccnnConnection.Close()
    '            Catch
    '            End Try
    '        End If

    '        Throw New ApplicationException("Los registros no pudieron ser leidos debido a un error de base de datos.", oSqlException)

    '    Catch ex As Exception

    '        If (sccnnConnection.State <> ConnectionState.Closed) Then
    '            Try
    '                sccnnConnection.Close()
    '            Catch
    '            End Try
    '        End If

    '        Throw New ApplicationException("Los registros no pudieron ser leidos debido a un error de aplicación.", ex)

    '    End Try

    '    sccnnConnection.Dispose()
    '    sccnnConnection = Nothing

    '    Return dsValeCaja

    'End Function

    Public Function SelectByFolioDocumento(ByVal FolioDocumento As String) As ValeCaja

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader
        Dim oValeCaja As ValeCaja

        oValeCaja = oParent.Create

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[ValeCajaSelByFolioDocumento]"
            .CommandType = System.Data.CommandType.StoredProcedure

            '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioDocumento", System.Data.SqlDbType.VarChar, 10))

        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect
                'Assign Parameters Values
                .Parameters("@FolioDocumento").Value = FolioDocumento.Trim.PadLeft(10, "0")

                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    With scdrReader

                        oValeCaja.ValeCajaID = .GetInt32(.GetOrdinal("ValeCajaID"))
                        oValeCaja.TipoDocumento = .GetString(.GetOrdinal("TipoDocumento"))
                        oValeCaja.FolioDocumento = .GetString(.GetOrdinal("FolioDocumento"))
                        oValeCaja.DocumentoID = .GetInt32(.GetOrdinal("DocumentoID"))
                        oValeCaja.CodCliente = .GetString(.GetOrdinal("CodCliente"))
                        oValeCaja.ValeCajaID = .GetInt32(.GetOrdinal("ValeCajaID"))
                        oValeCaja.Nombre = .GetString(.GetOrdinal("Nombre"))
                        oValeCaja.Importe = .GetDecimal(.GetOrdinal("Importe"))
                        oValeCaja.MontoUtilizado = .GetDecimal(.GetOrdinal("MontoUtilizado"))
                        oValeCaja.ValeGenerado = .GetInt32(.GetOrdinal("ValeGenerado"))
                        oValeCaja.DevEfectivo = .GetBoolean(.GetOrdinal("DevEfectivo"))
                        oValeCaja.Motivo = .GetString(.GetOrdinal("Motivo"))
                        oValeCaja.Fecha = .GetDateTime(.GetOrdinal("Fecha"))
                        oValeCaja.Usuario = .GetString(.GetOrdinal("Usuario"))
                        oValeCaja.StastusRegistro = .GetBoolean(.GetOrdinal("StatusRegistro"))
                        If .IsDBNull(.GetOrdinal("FolioFISAP")) = False Then
                            oValeCaja.FolioFISAP = .GetString(.GetOrdinal("FolioFISAP"))
                        Else
                            oValeCaja.FolioFISAP = ""
                        End If


                        'Reset New State of Linea Object 
                        oValeCaja.ResetFlagNew()
                        oValeCaja.ResetFlagDirty()

                    End With

                Else
                    oValeCaja = Nothing
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

        Return oValeCaja

    End Function

    Public Function GetByValeCajaId(ByVal ValeCajaId As Integer) As ValeCaja
        Dim conexion As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)
        Dim command As New SqlCommand("GetValeCajaById", conexion)
        Dim reader As SqlDataReader = Nothing
        Dim oValeCaja As ValeCaja = oParent.Create
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.AddWithValue("@ValeCajaId", ValeCajaId)
            reader = command.ExecuteReader()
            If reader.HasRows Then
                While reader.Read
                    With reader
                        oValeCaja.ValeCajaID = CInt(reader("ValeCajaID"))
                        oValeCaja.TipoDocumento = CStr(reader("TipoDocumento"))
                        oValeCaja.FolioDocumento = CStr(reader("FolioDocumento"))
                        oValeCaja.DocumentoID = CInt(reader("DocumentoID"))
                        oValeCaja.CodCliente = CStr(reader("CodCliente"))
                        oValeCaja.Nombre = CStr(reader("Nombre"))
                        oValeCaja.Importe = CDec(reader("Importe"))
                        oValeCaja.MontoUtilizado = CDec(reader("MontoUtilizado"))
                        oValeCaja.ValeGenerado = CInt(reader("ValeGenerado"))
                        oValeCaja.DevEfectivo = CBool(reader("DevEfectivo"))
                        oValeCaja.Motivo = CStr(reader("Motivo"))
                        oValeCaja.Fecha = CDate(reader("Fecha"))
                        oValeCaja.Usuario = CStr(reader("Usuario"))
                        oValeCaja.StastusRegistro = CBool(reader("StatusRegistro"))
                        If .IsDBNull(.GetOrdinal("FolioFISAP")) = False Then
                            oValeCaja.FolioFISAP = CStr(reader("FolioFISAP"))
                        Else
                            oValeCaja.FolioFISAP = ""
                        End If
                    End With
                End While
                
                'Reset New State of Linea Object 
                oValeCaja.ResetFlagNew()
                oValeCaja.ResetFlagDirty()
            End If
        Catch sql As SqlException
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            Throw New ApplicationException(sql.Message, sql)
        Catch ex As Exception
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            Throw New ApplicationException(ex.Message, ex)
        End Try
        Return oValeCaja
    End Function

    Public Sub Delete(ByVal ValeCajaID As Integer, ByVal TipoDocumento As String)
        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                                DataStorageConfiguration.GetConnectionString)

        Dim sccmdUpdate As SqlCommand
        sccmdUpdate = New SqlCommand

        With sccmdUpdate

            .Connection = sccnnConnection

            .CommandText = "[ValeCajaDel]"
            .CommandType = System.Data.CommandType.StoredProcedure

            '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ValeCajaID", System.Data.SqlDbType.Int, 4, "ValeCajaID"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TipoDocumento", System.Data.SqlDbType.VarChar, 2, "TipoDocumento"))


        End With

        Try

            sccnnConnection.Open()

            With sccmdUpdate
                'Assign Parameters Values
                .Parameters("@ValeCajaID").Value = ValeCajaID
                .Parameters("@TipoDocumento").Value = TipoDocumento

                'Execute Command
                .ExecuteNonQuery()

                'Assign Other Values


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

            Throw New ApplicationException("El registro no pudo ser actualizado debido a un error de aplicación.", ex)

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing


    End Sub

    Public Sub UpdateMontoToCero(ByVal ValeCajaID As Integer, ByVal TipoDocumento As String)

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                                 DataStorageConfiguration.GetConnectionString)

        Dim sccmdUpdate As SqlCommand
        sccmdUpdate = New SqlCommand

        With sccmdUpdate

            .Connection = sccnnConnection

            .CommandText = "[ValeCajaUpdMontoToCero]"
            .CommandType = System.Data.CommandType.StoredProcedure

            '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ValeCajaID", System.Data.SqlDbType.Int, 4, "ValeCajaID"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TipoDocumento", System.Data.SqlDbType.VarChar, 2, "TipoDocumento"))


        End With

        Try

            sccnnConnection.Open()

            With sccmdUpdate
                'Assign Parameters Values
                .Parameters("@ValeCajaID").Value = ValeCajaID
                .Parameters("@TipoDocumento").Value = TipoDocumento

                'Execute Command
                .ExecuteNonQuery()

                'Assign Other Values


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

            Throw New ApplicationException("El registro no pudo ser actualizado debido a un error de aplicación.", ex)

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

    End Sub

    Public Sub UpdateFolioFITS(ByVal ValeCajaID As Integer, ByVal FolioFITS As String)

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                                 DataStorageConfiguration.GetConnectionString)

        Dim sccmdUpdate As SqlCommand
        sccmdUpdate = New SqlCommand

        With sccmdUpdate

            .Connection = sccnnConnection

            .CommandText = "[ValeCajaUpdFolioFITS]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ValeCajaID", System.Data.SqlDbType.Int, 4, "ValeCajaID"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioFI", System.Data.SqlDbType.VarChar, 10, "FolioFI TS"))

        End With

        Try

            sccnnConnection.Open()

            With sccmdUpdate
                'Assign Parameters Values
                .Parameters("@ValeCajaID").Value = ValeCajaID
                .Parameters("@FolioFI").Value = FolioFITS.Trim.PadLeft(10, "0")

                'Execute Command
                .ExecuteNonQuery()

                'Assign Other Values

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

            Throw New ApplicationException("El registro no pudo ser actualizado debido a un error de aplicación.", ex)

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

    End Sub

    Public Function DevEfvoVal(ByVal strComandSQL As String, ByVal strTabla As String) As DataSet

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                                 DataStorageConfiguration.GetConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaMovCont As SqlDataAdapter
        Dim dsMovCont As DataSet

        sccmdSelectAll = New SqlCommand
        scdaMovCont = New SqlDataAdapter
        dsMovCont = New DataSet

        With sccmdSelectAll

            .Connection = sccnnConnection

            .CommandText = "[ValeCajaValidaDevEfvo]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ComandSQL", System.Data.SqlDbType.Text))

        End With

        scdaMovCont.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            scdaMovCont.SelectCommand.Parameters("@ComandSQL").Value = strComandSQL

            'Fill DataSet
            scdaMovCont.Fill(dsMovCont, strTabla)

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

        Return dsMovCont

    End Function

    Public Function SelectNCID(ByVal intFolioID As Integer) As String


        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                                 DataStorageConfiguration.GetConnectionString)

        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand

        With sccmdInsert

            .Connection = sccnnConnection

            .CommandText = "[SelFolioSAPByNCID]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@NCID", System.Data.SqlDbType.Int, 4))


        End With

        Try

            sccnnConnection.Open()

            With sccmdInsert
                'Assign Parameters Values
                .Parameters("@NCID").Value = intFolioID

                Dim scdrReader As SqlDataReader
                'Execute Reader
                scdrReader = .ExecuteReader
                scdrReader.Read()
                If scdrReader.HasRows Then
                    Return scdrReader.GetString(scdrReader.GetOrdinal("FolioSAP")).Trim
                Else
                    Return 0
                End If
                'Assign Other Values

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

        ' Return ""



    End Function

#End Region

#Region "Facturacion SiHay"

    Public Function ActualizarDocumentoFIValeCaja(ByVal ValeCajaID As Integer, ByVal DocFI As String)
        Dim conexion As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString())
        Dim command As New SqlCommand("ActualizarValeCajaFolioFISAP", conexion)
        Try
            If DocFI Is Nothing Then DocFI = ""

            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@ValeCajaID", ValeCajaID)
            command.Parameters.Add("@FolioFISAP", DocFI)
            command.ExecuteScalar()
            command.Dispose()
            conexion.Close()
        Catch oSqlException As SqlException
            If (conexion.State <> ConnectionState.Closed) Then
                Try
                    conexion.Close()
                Catch
                End Try
            End If
            Throw New ApplicationException("El registro no pudo ser insertado debido a un error de base de datos.", oSqlException)
        Catch ex As Exception
            If (conexion.State <> ConnectionState.Closed) Then
                Try
                    conexion.Close()
                Catch
                End Try
            End If
            Throw New ApplicationException("El registro no pudo ser insertado debido a un error de aplicación.", ex)
        End Try
    End Function
#End Region

End Class
