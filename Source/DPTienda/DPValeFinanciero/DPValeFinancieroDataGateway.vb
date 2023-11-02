Imports System.Data.SqlClient
Imports System.Collections.Generic

Public Class DPValeFinancieroDataGateway

    Dim oParent As DPValeFinancieroManager
    Dim m_strConnectionString As String
    Private m_strConnectionStringDPVF As String

#Region "Constructor / Destructor"

    Public Sub New(ByVal Parent As DPValeFinancieroManager)

        oParent = Parent
        'm_strConnectionString = oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString
        m_strConnectionString = "data source = " & oParent.ConfigCierreFI.ServerHuellas & "; initial catalog = " & _
                                "DPVFinanciero; user id = " & Parent.ConfigCierreFI.UserHuellas & "; password = " & _
                                oParent.ConfigCierreFI.PassHuellas()

        '--------------------------------------------------------
        'FLIZARRAGA 25/09/2017: ConnectionString de Servidor DPVF
        '--------------------------------------------------------
        m_strConnectionStringDPVF = "Data Source=" & oParent.ConfigCierreFI.ServerDPVF & "; Initial Catalog=" & _
                                    oParent.ConfigCierreFI.BaseDatosDPVF & "; User Id=" & _
                                    oParent.ConfigCierreFI.UserDPVF & " ;Password=" & _
                                    oParent.ConfigCierreFI.PasswordDPVF & ";TimeOut=120;"

    End Sub

#End Region

#Region "Methods"

    Public Sub Insert(ByVal pDPVF As DPVFinanciero)

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand

        With sccmdInsert

            .Connection = sccnnConnection

            .CommandText = "[DatosArchivosDPVFIns]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@NoCuenta", System.Data.SqlDbType.VarChar, 20, "NoCuenta"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@IDCliente", System.Data.SqlDbType.Int, 4, "IDCliente"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Output, False, CType(0, Byte), CType(0, Byte), "Fecha", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@SecFile", System.Data.SqlDbType.Int, 4, "SecFile"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Importe", System.Data.SqlDbType.Decimal, 9, "Importe"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Intereses", System.Data.SqlDbType.Decimal, 9, "Intereses"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@DPVale", System.Data.SqlDbType.VarChar, 10, "DPVale"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Tipo", System.Data.SqlDbType.Int, 4, "Tipo"))
            .Parameters.Add(New SqlParameter("@CodAlmacen", SqlDbType.VarChar, 4, "CodAlmacen"))
            .Parameters.Add(New SqlParameter("@NumFact", SqlDbType.VarChar, 10, "NumeroFactura"))
            .Parameters.Add(New SqlParameter("@IDAsociado", SqlDbType.Int, 4, "IDAsociado"))

        End With

        Try

            sccnnConnection.Open()

            With sccmdInsert
                'Assign Parameters Values
                .Parameters("@NoCuenta").Value = pDPVF.NoCuentaAbono.ToUpper
                .Parameters("@IDCliente").Value = pDPVF.IDCliente
                .Parameters("@Fecha").Value = pDPVF.Fecha
                .Parameters("@SecFile").Value = pDPVF.SecuencialFile
                .Parameters("@Importe").Value = pDPVF.Importe
                .Parameters("@Intereses").Value = pDPVF.Intereses
                .Parameters("@DPVale").Value = pDPVF.NoDPVale
                .Parameters("@Tipo").Value = pDPVF.Tipo
                .Parameters("@CodAlmacen").Value = pDPVF.CodAlmacen
                .Parameters("@NumFact").Value = pDPVF.NumFactura
                .Parameters("@IDAsociado").Value = pDPVF.Asociado

                'Execute Command
                .ExecuteNonQuery()


                'Assign Other Values
                'pCaja.SetRecordCreatedBy("ASM")
                'pcaja.SetRecordCreatedOn(.Parameters("@Fecha").Value)
            End With

            'Reset New State of Linea Object 
            pDPVF.ResetFlagNew()
            pDPVF.ResetFlagDirty()

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

    Public Sub Delete(ByVal ID As String)

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdDelete As SqlCommand
        sccmdDelete = New SqlCommand

        With sccmdDelete

            .Connection = sccnnConnection
            .CommandText = "[DatosArchivosDPVFDel]"
            .CommandType = System.Data.CommandType.StoredProcedure

            '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@NoDPVale", System.Data.SqlDbType.VarChar, 10, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "NoDPVale", System.Data.DataRowVersion.Original, Nothing))

        End With

        Try

            sccnnConnection.Open()

            With sccmdDelete
                'Assign Parameters Values
                .Parameters("@NoDPVale").Value = ID

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

            'Throw New ApplicationException("El registro no pudo ser insertado debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            'Throw New ApplicationException("El registro no pudo ser insertado debido a un error de aplicación.", ex)

        End Try


        sccmdDelete.Dispose()
        sccmdDelete = Nothing

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

    End Sub

    Public Function SelectByID(ByVal ID As String, ByVal Tipo As Integer) As DPVFinanciero

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader
        Dim oDPValeF As DPVFinanciero

        oDPValeF = oParent.Create()

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[DatosArchivosDPVFSel]"
            .CommandType = CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@NoDPVale", System.Data.SqlDbType.VarChar, 10, "NoDPVale"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Tipo", System.Data.SqlDbType.Int, 4, "Tipo"))

        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect

                .Parameters("@NoDPVale").Value = ID
                .Parameters("@Tipo").Value = Tipo

                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                scdrReader.Read()

                If scdrReader.HasRows Then

                    With scdrReader

                        oDPValeF.ID = .GetInt32(0)
                        oDPValeF.IDCliente = .GetInt32(1)
                        oDPValeF.SecuencialFile = .GetInt32(2)
                        oDPValeF.Importe = .GetDecimal(3)
                        oDPValeF.Intereses = .GetDecimal(4)
                        oDPValeF.NoCuentaAbono = .GetString(5).ToUpper
                        oDPValeF.Fecha = .GetDateTime(6)
                        oDPValeF.NoDPVale = .GetString(7).ToUpper
                        oDPValeF.Tipo = .GetInt32(8)
                        oDPValeF.CodAlmacen = .GetString(9).ToUpper

                        oDPValeF.ResetFlagNew()
                        oDPValeF.ResetFlagDirty()

                    End With

                Else

                    oDPValeF = Nothing

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

        Return oDPValeF

    End Function

    Public Function SelectAll(Optional ByVal Fecha As String = "") As DataSet

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaDPVF As SqlDataAdapter
        Dim dsDPVF As DataSet

        sccmdSelectAll = New SqlCommand
        scdaDPVF = New SqlDataAdapter
        dsDPVF = New DataSet("DatosArchivosDPVF")

        With sccmdSelectAll

            .Connection = sccnnConnection

            .CommandText = "[DatosArchivosDPVFSelAll]"
            .CommandType = System.Data.CommandType.StoredProcedure

            '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@OnlyEnabledRecords", System.Data.SqlDbType.Bit, 1))
            .Parameters.Add(New SqlParameter("@Fecha", SqlDbType.VarChar, 10, "Fecha"))
            .Parameters.Add(New SqlParameter("@Almacen", SqlDbType.VarChar, 4, "CodAlmacen"))

        End With

        scdaDPVF.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            With scdaDPVF.SelectCommand

                .Parameters("@Fecha").Value = Fecha
                .Parameters("@Almacen").Value = oParent.ApplicationContext.ApplicationConfiguration.Almacen.Trim

            End With

            'Fill DataSet
            scdaDPVF.Fill(dsDPVF, "DatosArchivosDPVF")

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

        Return dsDPVF

    End Function

    Public Function GetLastSec(ByVal Tipo As Integer) As Integer

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader
        Dim intLastSec As Integer

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[DatosArchivosDPVFGetLastNum]"
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Tipo", System.Data.SqlDbType.Int, 4, "Tipo"))
            '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@OnlyEnabledRecords", System.Data.SqlDbType.Bit, 1))

        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect

                .Parameters("@Tipo").Value = Tipo

                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                scdrReader.Read()

                If scdrReader.HasRows Then

                    With scdrReader

                        intLastSec = .GetInt32(0)

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

        Return intLastSec

    End Function

#End Region

#Region "Servicios Financieros"

    '--------------------------------------------------------------------------------
    ' FLIZARRAGA 17/10/2017: Funcion para obtener Bancos de Servicios Financieros
    '--------------------------------------------------------------------------------
    Public Function GetServiciosFinancieros(ByVal Todos As Boolean) As DataTable

        Dim sccnnConnection As New SqlConnection(m_strConnectionStringDPVF)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaDPVF As SqlDataAdapter
        Dim dsDPVF As DataSet

        sccmdSelectAll = New SqlCommand
        scdaDPVF = New SqlDataAdapter
        dsDPVF = New DataSet("GetServiciosFinancieros")

        With sccmdSelectAll

            .Connection = sccnnConnection
            .CommandText = "[CatalogoServiciosSelAll]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Todos", System.Data.SqlDbType.Bit, 1, "Todos"))

        End With

        scdaDPVF.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            sccmdSelectAll.Parameters("@Todos").Value = Todos

            'Fill DataSet
            scdaDPVF.Fill(dsDPVF, "ServiciosFinancieros")

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

        Return dsDPVF.Tables(0)
    End Function

    '--------------------------------------------------------------------------------
    ' FLIZARRAGA 17/07/2017: Funcion para obtener Bancos de Servicios Financieros
    '--------------------------------------------------------------------------------
    Public Function GetBancos() As DataTable

        Dim sccnnConnection As New SqlConnection(m_strConnectionStringDPVF)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaDPVF As SqlDataAdapter
        Dim dsDPVF As DataSet

        sccmdSelectAll = New SqlCommand
        scdaDPVF = New SqlDataAdapter
        dsDPVF = New DataSet("Bancos")

        With sccmdSelectAll

            .Connection = sccnnConnection
            .CommandText = "[CatalogoBancosSelAll]"
            .CommandType = System.Data.CommandType.StoredProcedure

        End With

        scdaDPVF.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            'Fill DataSet
            scdaDPVF.Fill(dsDPVF, "Bancos")

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

        Return dsDPVF.Tables(0)
    End Function

    '--------------------------------------------------------------------------------
    ' FLIZARRAGA 17/07/2017: Funcion para obtener las compañia cel de Servicios Financieros
    '--------------------------------------------------------------------------------
    Public Function GetCompañiaCelular() As DataTable

        Dim sccnnConnection As New SqlConnection(m_strConnectionStringDPVF)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaDPVF As SqlDataAdapter
        Dim dsDPVF As DataSet

        sccmdSelectAll = New SqlCommand
        scdaDPVF = New SqlDataAdapter
        dsDPVF = New DataSet("CompañiaCelular")

        With sccmdSelectAll

            .Connection = sccnnConnection
            .CommandText = "[CatalogoCompañiaCelularSelAll]"
            .CommandType = System.Data.CommandType.StoredProcedure

        End With

        scdaDPVF.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            'Fill DataSet
            scdaDPVF.Fill(dsDPVF, "Bancos")

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

        Return dsDPVF.Tables(0)
    End Function

    '--------------------------------------------------------------------------------
    ' FLIZARRAGA 17/07/2017: Funcion para obtener las compañia cel de Servicios Financieros
    '--------------------------------------------------------------------------------
    Public Function UpdateGenerado(ByVal ID As Integer, ByVal SecFile As Integer) As String

        Dim sccnnConnection As New SqlConnection(m_strConnectionStringDPVF)

        Dim sccmdDelete As SqlCommand
        sccmdDelete = New SqlCommand
        Dim Result As String = ""

        With sccmdDelete

            .Connection = sccnnConnection
            .CommandText = "[DatosArchivosDPVFMarcaPrestamo]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.Int, 4, "ID"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@SecFile", System.Data.SqlDbType.Int, 4, "SecFile"))

        End With

        Try

            sccnnConnection.Open()

            With sccmdDelete
                'Assign Parameters Values
                .Parameters("@ID").Value = ID
                .Parameters("@SecFile").Value = SecFile

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

            Result = oSqlException.ToString
            'Throw New ApplicationException("El registro no pudo ser insertado debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Result = ex.ToString
            'Throw New ApplicationException("El registro no pudo ser insertado debido a un error de aplicación.", ex)

        End Try

        sccmdDelete.Dispose()
        sccmdDelete = Nothing

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return Result

    End Function

    '--------------------------------------------------------------------------------
    ' FLIZARRAGA 17/07/2017: Funcion para obtener el catalogo de dias inhabiles
    '--------------------------------------------------------------------------------
    Public Function GetCatalogoDiasInhabiles(ByVal Fecha As DateTime) As DataTable

        Dim sccnnConnection As New SqlConnection(m_strConnectionStringDPVF)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaDPVF As SqlDataAdapter
        Dim dsDPVF As DataSet

        sccmdSelectAll = New SqlCommand
        scdaDPVF = New SqlDataAdapter
        dsDPVF = New DataSet("CatalogoDiasInhabiles")

        With sccmdSelectAll

            .Connection = sccnnConnection

            .CommandText = "[CatalogoDiasInhabilesSelByFecha]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New SqlParameter("@Fecha", SqlDbType.DateTime, 8, "Fecha Inicio"))

        End With

        scdaDPVF.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            With scdaDPVF.SelectCommand

                .Parameters("@Fecha").Value = Fecha.ToShortDateString

            End With

            'Fill DataSet
            scdaDPVF.Fill(dsDPVF, "CatalogoDiasInhabiles")

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

        Return dsDPVF.Tables(0)

    End Function

    '--------------------------------------------------------------------------------
    ' FLIZARRAGA 17/07/2017: Funcion para obtener el Servicio por su ID
    '--------------------------------------------------------------------------------
    Public Function GetServiciosFinancierosByID(ByVal ID As String) As String

        Dim sccnnConnection As New SqlConnection(m_strConnectionStringDPVF)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader
        Dim strReturn As String

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[CatalogoServiciosSelByServicioID]"
            .CommandType = CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ServicioID", System.Data.SqlDbType.VarChar, 2, "ServicioID"))

        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect

                .Parameters("@ServicioID").Value = ID

                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                scdrReader.Read()

                If scdrReader.HasRows Then

                    With scdrReader

                        strReturn = IIf(.IsDBNull(2), String.Empty, .GetString(2))

                    End With

                Else

                    strReturn = String.Empty

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

        Return strReturn

    End Function

    '--------------------------------------------------------------------------------
    ' FLIZARRAGA 17/07/2017: Funcion para obtener la fecha completa del servidor
    '--------------------------------------------------------------------------------
    Public Function GetFechaServidor() As String

        Dim sccnnConnection As New SqlConnection(m_strConnectionStringDPVF)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader
        Dim strReturn As String

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[FechaServidorSel]"
            .CommandType = CommandType.StoredProcedure

        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect


                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                scdrReader.Read()

                If scdrReader.HasRows Then

                    With scdrReader

                        strReturn = IIf(.IsDBNull(0), String.Empty, .GetSqlDateTime(0).ToString)

                    End With

                Else

                    strReturn = String.Empty

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

        Return strReturn

    End Function

    '--------------------------------------------------------------------------------
    ' FLIZARRAGA 17/07/2017: Funcion para Activar o desactivar Servicios financieros
    '--------------------------------------------------------------------------------
    Public Function UpdateServicioActivo(ByVal ServicioID As String, ByVal Activo As Boolean, ByVal Usuario As String) As String

        Dim sccnnConnection As New SqlConnection(m_strConnectionStringDPVF)

        Dim sccmdDelete As SqlCommand
        sccmdDelete = New SqlCommand
        Dim Result As String = ""

        With sccmdDelete

            .Connection = sccnnConnection
            .CommandText = "[CatalogoServiciosUpdActivo]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ServicioID", System.Data.SqlDbType.VarChar, 2, "ServicioID"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Activo", System.Data.SqlDbType.Bit, 1, "Activo"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Usuario", System.Data.SqlDbType.VarChar, 30, "Usuario"))

        End With

        Try

            sccnnConnection.Open()

            With sccmdDelete
                'Assign Parameters Values
                .Parameters("@ServicioID").Value = ServicioID
                .Parameters("@Activo").Value = Activo
                .Parameters("@Usuario").Value = Usuario

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

            Result = oSqlException.ToString
            'Throw New ApplicationException("El registro no pudo ser insertado debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Result = ex.ToString
            'Throw New ApplicationException("El registro no pudo ser insertado debido a un error de aplicación.", ex)

        End Try

        sccmdDelete.Dispose()
        sccmdDelete = Nothing

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return Result

    End Function


    '--------------------------------------------------------------------------------
    ' FLIZARRAGA 17/07/2017: Funcion para obtener el id_prosa de CatalogoBines
    '--------------------------------------------------------------------------------
    Public Function GetBines(ByVal Bin As String, ByVal Tipo As String, ByVal Activo As String) As String

        Dim sccnnConnection As New SqlConnection(m_strConnectionStringDPVF)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader
        Dim strReturn As String

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[CatalogoBinesSelBanco]"
            .CommandType = CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Bin", System.Data.SqlDbType.VarChar, 20, "Bin"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Tipo", System.Data.SqlDbType.VarChar, 1, "Tipo"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Activo", System.Data.SqlDbType.Bit, 1, "Activo"))

        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect

                .Parameters("@Bin").Value = Bin
                .Parameters("@Tipo").Value = Tipo
                .Parameters("@Activo").Value = Activo

                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                scdrReader.Read()

                If scdrReader.HasRows Then

                    With scdrReader

                        strReturn = IIf(.IsDBNull(0), String.Empty, .GetString(0))

                    End With

                Else

                    strReturn = String.Empty

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

        Return strReturn

    End Function

    '--------------------------------------------------------------------------------
    ' FLIZARRAGA 17/07/2017: Funcion para obtener el id_prosa de CatalogoBines
    '--------------------------------------------------------------------------------
    Public Function GetBinTransfer(ByVal Bin As String, ByVal Tipo As String, ByVal Activo As String) As Boolean

        Dim sccnnConnection As New SqlConnection(m_strConnectionStringDPVF)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader
        Dim strReturn

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[CatalogoBinesSelTransfer]"
            .CommandType = CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Bin", System.Data.SqlDbType.VarChar, 20, "Bin"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Tipo", System.Data.SqlDbType.VarChar, 1, "Tipo"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Activo", System.Data.SqlDbType.Bit, 1, "Activo"))

        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect

                .Parameters("@Bin").Value = Bin
                .Parameters("@Tipo").Value = Tipo
                .Parameters("@Activo").Value = Activo

                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                scdrReader.Read()

                If scdrReader.HasRows Then

                    With scdrReader

                        strReturn = IIf(.IsDBNull(0), False, .GetBoolean(0))

                    End With

                Else

                    strReturn = False

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

        Return strReturn

    End Function

    '--------------------------------------------------------------------------------
    ' FLIZARRAGA 17/07/2017: Funcion para comparar el id_prosa con el código
    '--------------------------------------------------------------------------------
    Public Function GetCodigo(ByVal Codigo As String) As String

        Dim sccnnConnection As New SqlConnection(m_strConnectionStringDPVF)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader
        Dim strReturn As String

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[DatosArchivosDPVFSelCodigo]"
            .CommandType = CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Codigo", System.Data.SqlDbType.VarChar, 4, "Codigo"))

        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect

                .Parameters("@Codigo").Value = Codigo

                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                scdrReader.Read()

                If scdrReader.HasRows Then

                    With scdrReader

                        strReturn = IIf(.IsDBNull(0), String.Empty, .GetString(0))

                    End With

                Else

                    strReturn = String.Empty

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

        Return strReturn

    End Function

    '---------------------------------------------------------------------------------------------------
    'FLIZARRAGA 17/07/2017: Selecciona la fecha mediante el servicio
    '---------------------------------------------------------------------------------------------------
    Public Function SelectFecha(ByVal ServicioId As Integer, ByVal NoCuenta As String, ByVal Celular As String, ByVal NumeroTarjeta As String, ByVal Clabe As String) As DataSet

        Dim sccnnConnection As New SqlConnection(m_strConnectionStringDPVF)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaDPVF As SqlDataAdapter
        Dim dsDPVF As DataSet

        sccmdSelectAll = New SqlCommand
        scdaDPVF = New SqlDataAdapter
        dsDPVF = New DataSet("DatosArchivosDPVF")

        With sccmdSelectAll

            .Connection = sccnnConnection

            .CommandText = "[DatosArchivosDPVFSelFecha]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New SqlParameter("@ServicioId", SqlDbType.Int, 4, "Servicio"))
            .Parameters.Add(New SqlParameter("@NoCuenta", SqlDbType.VarChar, 20, "NoCuenta"))
            .Parameters.Add(New SqlParameter("@Celular", SqlDbType.VarChar, 10, "Celular"))
            .Parameters.Add(New SqlParameter("@NumeroTarjeta", SqlDbType.VarChar, 20, "NumeroTarjeta"))
            .Parameters.Add(New SqlParameter("@Clabe", SqlDbType.VarChar, 20, "Clabe"))

        End With

        scdaDPVF.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            With scdaDPVF.SelectCommand

                .Parameters("@ServicioId").Value = ServicioId
                .Parameters("@NoCuenta").Value = NoCuenta
                .Parameters("@Celular").Value = Celular
                .Parameters("@NumeroTarjeta").Value = NumeroTarjeta
                .Parameters("@Clabe").Value = Clabe


            End With

            'Fill DataSet
            scdaDPVF.Fill(dsDPVF, "DatosArchivosDPVF")

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

        Return dsDPVF

    End Function

    '--------------------------------------------------------------------------------
    ' FLIZARRAGA 17/07/2017: Funcion para obtener el ESTATUS por su ID
    '--------------------------------------------------------------------------------
    Public Function GetServiciosFinancierosByID_Act(ByVal ID As String) As Boolean

        Dim sccnnConnection As New SqlConnection(m_strConnectionStringDPVF)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader
        Dim strReturn As Boolean

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[CatalogoServiciosSelByServicioID]"
            .CommandType = CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ServicioID", System.Data.SqlDbType.VarChar, 2, "ServicioID"))

        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect

                .Parameters("@ServicioID").Value = ID

                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                scdrReader.Read()

                If scdrReader.HasRows Then

                    With scdrReader

                        strReturn = IIf(.IsDBNull(7), False, .GetBoolean(7))
                        'strReturn = IIf(.IsDBNull(2), False, .GetString(2))


                    End With

                Else

                    strReturn = String.Empty

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

        Return strReturn

    End Function

    '--------------------------------------------------------------------------------
    ' FLIZARRAGA 17/07/2017: Funcion para obtener el Servicio por su ID
    '--------------------------------------------------------------------------------
    Public Function GetFechaDispersion(ByVal ServicioID As String, ByVal FechaDipersion As Date, ByRef dtHorarios As DataTable) As String

        Dim sccnnConnection As New SqlConnection(m_strConnectionStringDPVF)

        Dim sccmdSelectAll As New SqlCommand
        Dim scdaDPVF As New SqlDataAdapter
        Dim dsDPVF As New DataSet("Horarios")

        Dim strReturn As String = String.Empty

        With sccmdSelectAll

            .Connection = sccnnConnection

            .CommandText = "[GetFechaDispersion]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ServicioId", System.Data.SqlDbType.VarChar, 2, "ServicioId"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime, 8, "Fecha"))

        End With

        scdaDPVF.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            With scdaDPVF.SelectCommand

                .Parameters("@ServicioId").Value = ServicioID
                .Parameters("@Fecha").Value = FechaDipersion

            End With

            'Fill DataSet
            scdaDPVF.Fill(dsDPVF, "Horarios")

            If dsDPVF Is Nothing Then
                dtHorarios = Nothing
                strReturn = String.Empty
            Else
                If dsDPVF.Tables.Count > 1 Then
                    strReturn = dsDPVF.Tables(0).Rows(0).Item(0).ToString 'Regresamos Fecha Dispersion
                    dtHorarios = dsDPVF.Tables(1) 'Regresamos horarios del servicio
                Else
                    dtHorarios = Nothing
                    strReturn = String.Empty
                End If
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

        Return strReturn

    End Function

    '--------------------------------------------------------------------------------
    ' FLIZARRAGA 17/07/2017: Guardar Vales a Confirmar de S2Credit por error
    '--------------------------------------------------------------------------------
    Public Sub ConfirmacionS2Credit(ByVal DPVale As String)

        Dim sccnnConnection As New SqlConnection(m_strConnectionStringDPVF)

        Dim sccmdDelete As SqlCommand
        sccmdDelete = New SqlCommand

        With sccmdDelete

            .Connection = sccnnConnection
            .CommandText = "[Pte_ConfirmacS2Ins]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@DPVale", System.Data.SqlDbType.VarChar, 10, "DPVale"))

        End With

        Try

            sccnnConnection.Open()

            With sccmdDelete
                'Assign Parameters Values
                .Parameters("@DPVale").Value = DPVale

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

        sccmdDelete.Dispose()
        sccmdDelete = Nothing

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

    End Sub


#End Region

#Region "Dispersión Expres"

    '----------------------------------------------------------------------------------------------------
    ' JNAVA (22.06.2017): Funcion que valida si el cliente cuenta con un prestamo anterior
    '----------------------------------------------------------------------------------------------------
    Public Function getPrestamoAnterior(ByVal NombreCliente As String, ByVal ServicioID As String, ByVal Valor As String) As Boolean

        Dim sccnnConnection As New SqlConnection(m_strConnectionStringDPVF)

        Dim sccmdSelect As SqlCommand
        Dim bResult As Boolean
        Dim ReturnValue As New SqlParameter

        sccmdSelect = New SqlCommand

        With sccmdSelect

            ReturnValue.Direction = Data.ParameterDirection.ReturnValue
            ReturnValue.ParameterName = "ReturnValue"

            .Connection = sccnnConnection
            .CommandText = "[getPrestamoAnterior]"
            .CommandType = CommandType.StoredProcedure

            .Parameters.Add(ReturnValue)
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@NombreCliente", System.Data.SqlDbType.VarChar, 55, "NombreCliente"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ServicioID", System.Data.SqlDbType.VarChar, 2, "ServicioID"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Valor", System.Data.SqlDbType.VarChar, 20, "Valor"))

        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect

                .Parameters("@NombreCliente").Value = NombreCliente
                .Parameters("@ServicioID").Value = ServicioID.Trim
                .Parameters("@Valor").Value = Valor

                .ExecuteNonQuery()

                bResult = CBool(.Parameters("ReturnValue").Value)

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

        Return bResult

    End Function

    '----------------------------------------------------------------------------------------------------
    ' FLIZARRAGA 09/11/2017: Funcion que valida si el cliente cuenta con un prestamo anterior
    '----------------------------------------------------------------------------------------------------
    Public Function getPrestamoAnteriorIFE(ByVal IFE As String, ByVal ServicioID As String, ByVal Valor As String) As Boolean

        Dim sccnnConnection As New SqlConnection(m_strConnectionStringDPVF)

        Dim sccmdSelect As SqlCommand
        Dim bResult As Boolean
        Dim ReturnValue As New SqlParameter

        sccmdSelect = New SqlCommand

        With sccmdSelect

            ReturnValue.Direction = Data.ParameterDirection.ReturnValue
            ReturnValue.ParameterName = "ReturnValue"

            .Connection = sccnnConnection
            .CommandText = "[GetPrestamoAnteriorIFE]"
            .CommandType = CommandType.StoredProcedure

            .Parameters.Add(ReturnValue)
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@IFE", System.Data.SqlDbType.VarChar, 15, "IFE"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ServicioID", System.Data.SqlDbType.VarChar, 2, "ServicioID"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Valor", System.Data.SqlDbType.VarChar, 20, "Valor"))

        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect

                .Parameters("@IFE").Value = IFE
                .Parameters("@ServicioID").Value = ServicioID.Trim
                .Parameters("@Valor").Value = Valor

                .ExecuteNonQuery()

                bResult = CBool(.Parameters("ReturnValue").Value)

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

        Return bResult

    End Function

    '--------------------------------------------------------------------------------
    ' JNAVA (23.06.2017): Funcion para obtener los mensajes de la dispersion expres
    '--------------------------------------------------------------------------------
    Public Function GetMensajesCredExpres(ByVal TipoMensaje As Integer) As DataTable

        Dim sccnnConnection As New SqlConnection(m_strConnectionStringDPVF)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaDPVF As SqlDataAdapter
        Dim dsDPVF As DataSet

        sccmdSelectAll = New SqlCommand
        scdaDPVF = New SqlDataAdapter
        dsDPVF = New DataSet("MensajesCredExpres")

        With sccmdSelectAll

            .Connection = sccnnConnection
            .CommandText = "[getMensajesCredExpres]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Tipo", System.Data.SqlDbType.Int, 4, "Tipo"))

        End With

        scdaDPVF.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            sccmdSelectAll.Parameters("@Tipo").Value = TipoMensaje

            'Fill DataSet
            scdaDPVF.Fill(dsDPVF, "MensajesCredExpres")

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

        Return dsDPVF.Tables(0)
    End Function

    '--------------------------------------------------------------------------------
    ' JNAVA (11.09.2017): Funcion para la fecha de dispersion express
    '--------------------------------------------------------------------------------
    Public Function GetFechaDispersionExpres(ByVal ServicioID As String, ByVal FechaDipersion As Date, ByRef dtHorarios As DataTable) As String

        Dim sccnnConnection As New SqlConnection(m_strConnectionStringDPVF)

        Dim sccmdSelectAll As New SqlCommand
        Dim scdaDPVF As New SqlDataAdapter
        Dim dsDPVF As New DataSet("Horarios")

        Dim strReturn As String = String.Empty

        With sccmdSelectAll

            .Connection = sccnnConnection

            .CommandText = "[GetFechaDispersionExp]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ServicioId", System.Data.SqlDbType.VarChar, 2, "ServicioId"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime, 8, "Fecha"))

        End With

        scdaDPVF.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            With scdaDPVF.SelectCommand

                .Parameters("@ServicioId").Value = ServicioID
                .Parameters("@Fecha").Value = FechaDipersion

            End With

            'Fill DataSet
            scdaDPVF.Fill(dsDPVF, "Horarios")

            If dsDPVF Is Nothing Then
                dtHorarios = Nothing
                strReturn = String.Empty
            Else
                If dsDPVF.Tables.Count > 1 Then
                    strReturn = dsDPVF.Tables(0).Rows(0).Item(0).ToString 'Regresamos Fecha Dispersion
                    dtHorarios = dsDPVF.Tables(1) 'Regresamos horarios del servicio
                Else
                    dtHorarios = Nothing
                    strReturn = String.Empty
                End If
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

        Return strReturn

    End Function

#End Region

#Region "Microcreditos"

    Public Function GetPlazos(ByVal CodAlmacen As String, ByVal Fecha As DateTime) As DataTable
        Dim dtPlazos As New DataTable
        Dim conexion As New SqlConnection(m_strConnectionStringDPVF)
        Dim command As New SqlCommand("GetPlazosByTienda", conexion)
        Dim adapter As SqlDataAdapter = Nothing
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.AddWithValue("@CodAlmacen", CodAlmacen)
            command.Parameters.AddWithValue("@Fecha", Fecha)
            adapter = New SqlDataAdapter(command)
            adapter.Fill(dtPlazos)
            command.Dispose()
            conexion.Close()
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
        Return dtPlazos
    End Function

    Public Function Save(ByRef Disposicion As DisposicionEfeClubDP) As Boolean
        Dim valido As Boolean = False
        Dim conexion As New SqlConnection(m_strConnectionStringDPVF)
        Dim command As New SqlCommand("InsertDisposicionEfeClubDP", conexion)
        Dim TransactionId As SqlParameter = Nothing
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            TransactionId = New SqlParameter("@TransactionId", SqlDbType.Int)
            TransactionId.Direction = ParameterDirection.InputOutput
            TransactionId.Value = Disposicion.TransactionId
            command.Parameters.Add(TransactionId)
            command.Parameters.AddWithValue("@CodAlmacen", Disposicion.CodAlmacen)
            command.Parameters.AddWithValue("@CodPlaza", Disposicion.CodPlaza)
            command.Parameters.AddWithValue("@Caja", Disposicion.Caja)
            command.Parameters.AddWithValue("@CodVendedor", Disposicion.CodVendedor)
            command.Parameters.AddWithValue("@NombreCliente", Disposicion.NombreCliente)
            command.Parameters.AddWithValue("@NoServicio", Disposicion.NoServicio)
            command.Parameters.AddWithValue("@NoTarjeta", Disposicion.NoTarjeta)
            command.Parameters.AddWithValue("@AccountNumber", Disposicion.AccountNumber)
            command.Parameters.AddWithValue("@FechaKarum", Disposicion.FechaKarum)
            command.Parameters.AddWithValue("@IFE", Disposicion.IFE)
            command.Parameters.AddWithValue("@TransactionSequenceNumber", Disposicion.TransactionSequenceNumber)
            command.Parameters.AddWithValue("@ServicioId", Disposicion.ServicioId)
            command.Parameters.AddWithValue("@Banco", Disposicion.Banco)
            command.Parameters.AddWithValue("@Monto", Disposicion.Monto)
            command.Parameters.AddWithValue("@EstatusDisp", Disposicion.EstatusDisp)
            command.Parameters.AddWithValue("@FechaDispConf", Disposicion.FechaDispConf)
            command.Parameters.AddWithValue("@PlazoDisp", Disposicion.PlazoDisp)
            command.Parameters.AddWithValue("@UsuarioRep", Disposicion.UsuarioRep)
            command.Parameters.AddWithValue("@FechaRep", Disposicion.FechaRep)
            command.Parameters.AddWithValue("@PaymentPlan", Disposicion.PaymentPlan)
            command.Parameters.AddWithValue("@SKU", Disposicion.SKU)
            command.Parameters.AddWithValue("@IPReproceso", Disposicion.IPReproceso)
            command.Parameters.AddWithValue("@MontoSeguro", Disposicion.MontoSeguro)
            command.Parameters.AddWithValue("@CMSeguro", Disposicion.CMSeguro)
            command.Parameters.AddWithValue("@TicketSeguro", Disposicion.TicketSeguro)
            command.Parameters.AddWithValue("@Generado", Disposicion.Generado)
            command.Parameters.AddWithValue("@Deslizada", Disposicion.Deslizada)
            command.ExecuteNonQuery()
            If Disposicion.TransactionId = 0 Then
                Disposicion.TransactionId = CInt(TransactionId.Value)
            End If
            command.Dispose()
            conexion.Close()
            valido = True
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
        Return valido
    End Function

    Public Function SaveHistorial(ByRef Disposicion As DisposicionEfeClubDP) As Boolean
        Dim valido As Boolean = False
        Dim conexion As New SqlConnection(m_strConnectionStringDPVF)
        Dim command As New SqlCommand("InsertMicrocreditoHistorial", conexion)
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.AddWithValue("@TransactionId", Disposicion.TransactionId)
            command.Parameters.AddWithValue("@CodAlmacen", Disposicion.CodAlmacen)
            command.Parameters.AddWithValue("@CodPlaza", Disposicion.CodPlaza)
            command.Parameters.AddWithValue("@Caja", Disposicion.Caja)
            command.Parameters.AddWithValue("@CodVendedor", Disposicion.CodVendedor)
            command.Parameters.AddWithValue("@NombreCliente", Disposicion.NombreCliente)
            command.Parameters.AddWithValue("@NoServicio", Disposicion.NoServicio)
            command.Parameters.AddWithValue("@NoTarjeta", Disposicion.NoTarjeta)
            command.Parameters.AddWithValue("@AccountNumber", Disposicion.AccountNumber)
            command.Parameters.AddWithValue("@FechaKarum", Disposicion.FechaKarum)
            command.Parameters.AddWithValue("@IFE", Disposicion.IFE)
            command.Parameters.AddWithValue("@TransactionSequenceNumber", Disposicion.TransactionSequenceNumber)
            command.Parameters.AddWithValue("@ServicioId", Disposicion.ServicioId)
            command.Parameters.AddWithValue("@Banco", Disposicion.Banco)
            command.Parameters.AddWithValue("@Monto", Disposicion.Monto)
            command.Parameters.AddWithValue("@EstatusDisp", Disposicion.EstatusDisp)
            command.Parameters.AddWithValue("@FechaDispConf", Disposicion.FechaDispConf)
            command.Parameters.AddWithValue("@PlazoDisp", Disposicion.PlazoDisp)
            command.Parameters.AddWithValue("@UsuarioRep", Disposicion.UsuarioRep)
            command.Parameters.AddWithValue("@FechaRep", Disposicion.FechaRep)
            command.Parameters.AddWithValue("@PaymentPlan", Disposicion.PaymentPlan)
            command.Parameters.AddWithValue("@SKU", Disposicion.SKU)
            command.Parameters.AddWithValue("@IPReproceso", Disposicion.IPReproceso)
            command.Parameters.AddWithValue("@MontoSeguro", Disposicion.MontoSeguro)
            command.Parameters.AddWithValue("@CMSeguro", Disposicion.CMSeguro)
            command.Parameters.AddWithValue("@TicketSeguro", Disposicion.TicketSeguro)
            command.Parameters.AddWithValue("@Generado", Disposicion.Generado)
            command.Parameters.AddWithValue("@Deslizada", Disposicion.Deslizada)
            command.ExecuteNonQuery()
            command.Dispose()
            conexion.Close()
            valido = True
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
        Return valido
    End Function

    Public Function LoadDispersion(ByVal TransactionId As Integer) As Dictionary(Of String, Object)
        Dim dispersion As New Dictionary(Of String, Object)
        Dim conexion As New SqlConnection(m_strConnectionStringDPVF)
        Dim command As New SqlCommand("GetDisposicionEfeClubDPById", conexion)
        Dim reader As SqlDataReader = Nothing
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.AddWithValue("@TransactionId", TransactionId)
            reader = command.ExecuteReader()
            If reader.HasRows Then
                While reader.Read()
                    dispersion("TransactionId") = CInt(reader("TransactionId"))
                    dispersion("CodAlmacen") = CStr(reader("CodAlmacen"))
                    dispersion("CodPlaza") = CStr(reader("CodPlaza"))
                    dispersion("Caja") = CStr(reader("Caja"))
                    dispersion("NoServicio") = CStr(reader("NoServicio"))
                    dispersion("CodVendedor") = CStr(reader("CodVendedor"))
                    dispersion("NombreCliente") = CStr(reader("NombreCliente"))
                    dispersion("NoServicio") = CStr(reader("NoServicio"))
                    dispersion("NoTarjeta") = CStr(reader("NoTarjeta"))
                    dispersion("AccountNumber") = CStr(reader("AccountNumber"))
                    dispersion("IFE") = CStr(reader("IFE"))
                    dispersion("FechaKarum") = CDate(reader("FechaKarum"))
                    dispersion("TransactionSequenceNumber") = CStr(reader("TransactionSequenceNumber"))
                    dispersion("ServicioId") = CStr(reader("ServicioId"))
                    dispersion("Banco") = CStr(reader("Banco"))
                    dispersion("Monto") = CDec(reader("Monto"))
                    dispersion("EstatusDisp") = CStr(reader("EstatusDisp"))
                    dispersion("FechaDispConf") = CDate(reader("FechaDispConf"))
                    dispersion("PlazoDisp") = CStr(reader("PlazoDisp"))
                    dispersion("UsuarioRep") = CStr(reader("UsuarioRep"))
                    dispersion("FechaRep") = CDate(reader("FechaRep"))
                    dispersion("PaymentPlan") = CStr(reader("PaymentPlan"))
                    dispersion("SKU") = CStr(reader("SKU"))
                    dispersion("IPReproceso") = CStr(reader("IPReproceso"))
                    dispersion("MontoSeguro") = CDec(reader("MontoSeguro"))
                    dispersion("CMSeguro") = CInt(reader("CMSeguro"))
                    dispersion("TicketSeguro") = CInt(reader("TicketSeguro"))
                    dispersion("Generado") = CBool(reader("Generado"))
                    dispersion("Deslizada") = CBool(reader("Deslizada"))
                End While
            End If
            command.Dispose()
            conexion.Close()
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
        Return dispersion
    End Function

    Public Function GetDisposicionEfeClubDPByAlmacen(ByVal CodAlmacen As String) As DataTable
        Dim dtDisposicion As New DataTable()
        Dim conexion As New SqlConnection(m_strConnectionStringDPVF)
        Dim command As New SqlCommand("GetDisposicionEfeClubDPByAlmacen", conexion)
        Dim adapter As SqlDataAdapter = Nothing
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.AddWithValue("@CodAlmacen", CodAlmacen)
            adapter = New SqlDataAdapter(command)
            adapter.Fill(dtDisposicion)
            command.Dispose()
            conexion.Close()
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
        Return dtDisposicion
    End Function

    Public Function GetDisposicionEfeClubDPSolicitado(ByVal CodAlmacen As String) As DataTable
        Dim dtDisposicion As New DataTable
        Dim conexion As New SqlConnection(m_strConnectionStringDPVF)
        Dim command As New SqlCommand("GetDisposicionEfeClubDPSolicitado", conexion)
        Dim adapter As SqlDataAdapter = Nothing
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.AddWithValue("@CodAlmacen", CodAlmacen)
            adapter = New SqlDataAdapter(command)
            adapter.Fill(dtDisposicion)
            command.Dispose()
            conexion.Close()
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
        Return dtDisposicion
    End Function

    Public Function InsertDispersion(ByVal pDPVF As DPVFinancieroDispersion, Optional ByVal benef As String = "") As Boolean
        Dim valido As Boolean = False
        Dim sccnnConnection As New SqlConnection(m_strConnectionStringDPVF)

        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand

        With sccmdInsert

            .Connection = sccnnConnection

            .CommandText = "[DatosArchivosDPVFInsPrestamosKarum]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Parameters.Add(New SqlParameter("@ID", SqlDbType.Int, 9, "ID"))
            .Parameters.Add(New SqlParameter("@NoCuenta", System.Data.SqlDbType.VarChar, 20, "NoCuenta"))
            .Parameters.Add(New SqlParameter("@IDCliente", System.Data.SqlDbType.Int, 4, "IDCliente"))
            .Parameters.Add(New SqlParameter("@Fecha", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Output, False, CType(0, Byte), CType(0, Byte), "Fecha", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New SqlParameter("@SecFile", System.Data.SqlDbType.Int, 4, "SecFile"))
            .Parameters.Add(New SqlParameter("@Importe", System.Data.SqlDbType.Decimal, 9, "Importe"))
            .Parameters.Add(New SqlParameter("@Intereses", System.Data.SqlDbType.Decimal, 9, "Intereses"))
            .Parameters.Add(New SqlParameter("@DPVale", System.Data.SqlDbType.VarChar, 10, "DPVale"))
            .Parameters.Add(New SqlParameter("@Tipo", System.Data.SqlDbType.Int, 4, "Tipo"))
            .Parameters.Add(New SqlParameter("@CodAlmacen", SqlDbType.VarChar, 4, "CodAlmacen"))
            .Parameters.Add(New SqlParameter("@NumFact", SqlDbType.VarChar, 10, "NumeroFactura"))
            .Parameters.Add(New SqlParameter("@IDAsociado", SqlDbType.Int, 4, "IDAsociado"))
            .Parameters.Add(New SqlParameter("@CodPlaza", SqlDbType.VarChar, 3, "CodPlaza"))
            .Parameters.Add(New SqlParameter("@Oficina", SqlDbType.VarChar, 2, "Oficina"))
            .Parameters.Add(New SqlParameter("@Tarjeta", SqlDbType.Bit, 1, "Alta Tarjeta"))
            .Parameters.Add(New SqlParameter("@NoIFE", SqlDbType.VarChar, 13, "Numero IFE"))
            .Parameters.Add(New SqlParameter("@FolioFIIntereses", SqlDbType.VarChar, 10, "FolioFISAP Intereses"))
            .Parameters.Add(New SqlParameter("@FolioFIMonto", SqlDbType.VarChar, 10, "FolioFISAP Monto PRestamo"))
            .Parameters.Add(New SqlParameter("@Usuario", SqlDbType.VarChar, 25, "Usuario"))
            .Parameters.Add(New SqlParameter("@Benef", SqlDbType.VarChar, 40, "Benef"))

            .Parameters.Add(New SqlParameter("@Banco", SqlDbType.VarChar, 20, "Banco"))
            .Parameters.Add(New SqlParameter("@Celular", SqlDbType.VarChar, 10, "Celular"))
            .Parameters.Add(New SqlParameter("@CompañiaCelular", SqlDbType.VarChar, 20, "CompañiaCelular"))
            .Parameters.Add(New SqlParameter("@CLABE", SqlDbType.VarChar, 20, "CLABE"))
            .Parameters.Add(New SqlParameter("@Transfer", SqlDbType.Bit, 1, "Transfer"))
            .Parameters.Add(New SqlParameter("@NumeroTarjeta", SqlDbType.VarChar, 20, "NumeroTarjeta"))
            .Parameters.Add(New SqlParameter("@ServicioID", SqlDbType.VarChar, 2, "ServicioID"))
            .Parameters.Add(New SqlParameter("@Codigo", SqlDbType.VarChar, 4, "Codigo"))
            .Parameters.Add(New SqlParameter("@NombreCliente", SqlDbType.VarChar, 55, "NombreCliente"))
            .Parameters.Add(New SqlParameter("@Generado", SqlDbType.Bit, 1, "Generado"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaDispersion", System.Data.SqlDbType.DateTime, 8, "FechaDispersion"))
            .Parameters.Add(New SqlParameter("@CodigoSeguridad", SqlDbType.VarChar, 4, "CodigoSeguridad"))
            .Parameters.Add(New SqlParameter("@RFC", SqlDbType.VarChar, 14, "RFC"))
            .Parameters.Add(New SqlParameter("@FechNac", SqlDbType.DateTime, 8, "FechNac"))
            .Parameters.Add(New SqlParameter("@Dispersion", SqlDbType.Int, 4, "Dispersion"))
            .Parameters.Add(New SqlParameter("@NoColaborador", SqlDbType.VarChar, 8, "NoColaborador"))
            .Parameters.Add(New SqlParameter("@Alta", SqlDbType.Bit, 1, "Alta"))
            .Parameters.Add(New SqlParameter("@AccountNumber", SqlDbType.VarChar, 12, "AccountNumber"))
            .Parameters.Add(New SqlParameter("@Microcredito", SqlDbType.Bit))
            .Parameters.Add(New SqlParameter("@PlazoMicrocredito", SqlDbType.VarChar, 2, "PlazoMicrocredito"))
            .Parameters.Add(New SqlParameter("@ClubDP", SqlDbType.VarChar, 20, "ClubDP"))
            .Parameters.Add(New SqlParameter("@TransactionId", SqlDbType.Int, 4, "TransactionId"))

        End With

        Try

            sccnnConnection.Open()

            With sccmdInsert
                'Assign Parameters Values
                .Parameters("@ID").Value = pDPVF.ID
                .Parameters("@NoCuenta").Value = pDPVF.NoCuentaAbono.ToUpper
                .Parameters("@IDCliente").Value = pDPVF.IDCliente
                .Parameters("@Fecha").Value = pDPVF.Fecha
                .Parameters("@SecFile").Value = "0" 'pDPVF.SecuencialFile
                .Parameters("@Importe").Value = pDPVF.Importe
                .Parameters("@Intereses").Value = pDPVF.Intereses
                .Parameters("@DPVale").Value = pDPVF.NoDPVale
                .Parameters("@Tipo").Value = pDPVF.Tipo
                .Parameters("@CodAlmacen").Value = pDPVF.CodAlmacen
                .Parameters("@NumFact").Value = pDPVF.NumFactura
                .Parameters("@IDAsociado").Value = pDPVF.Asociado
                .Parameters("@CodPlaza").Value = pDPVF.CodPlaza
                .Parameters("@Oficina").Value = pDPVF.Oficina
                .Parameters("@Tarjeta").Value = pDPVF.AltaTarjeta
                .Parameters("@NoIFE").Value = pDPVF.NumeroIFE
                .Parameters("@FolioFIIntereses").Value = pDPVF.FolioFISAPIntereses
                .Parameters("@FolioFIMonto").Value = pDPVF.FolioFISAPMonto
                .Parameters("@Usuario").Value = oParent.ApplicationContext.Security.CurrentUser.Name
                .Parameters("@Benef").Value = benef
                .Parameters("@Banco").Value = pDPVF.Banco
                .Parameters("@Celular").Value = pDPVF.Celular
                .Parameters("@CompañiaCelular").Value = pDPVF.CompañiaCelular
                .Parameters("@CLABE").Value = pDPVF.CLABE
                .Parameters("@Transfer").Value = pDPVF.Transfer
                .Parameters("@NumeroTarjeta").Value = pDPVF.NumeroTarjeta
                .Parameters("@ServicioID").Value = pDPVF.ServicioID
                .Parameters("@Codigo").Value = pDPVF.Codigo
                .Parameters("@NombreCliente").Value = pDPVF.NombreCliente
                .Parameters("@Generado").Value = 1
                .Parameters("@FechaDispersion").Value = pDPVF.Fecha
                .Parameters("@CodigoSeguridad").Value = pDPVF.CodigoSeguridad
                .Parameters("@RFC").Value = pDPVF.RFC
                .Parameters("@FechNac").Value = pDPVF.FechNac
                .Parameters("@Dispersion").Value = pDPVF.Dispersion
                .Parameters("@NoColaborador").Value = pDPVF.NoColaborador
                .Parameters("@Alta").Value = pDPVF.Alta
                '-----------------------------------------------------------------------------------
                .Parameters("@AccountNumber").Value = pDPVF.AccountNumber
                .Parameters("@Microcredito").Value = pDPVF.Microcredito
                .Parameters("@PlazoMicrocredito").Value = pDPVF.PlazoMicrocredito
                .Parameters("@ClubDP").Value = pDPVF.ClubDP
                .Parameters("@TransactionId").Value = pDPVF.TransactionId

                'Execute Command
                .ExecuteNonQuery()


                'Assign Other Values
                'pCaja.SetRecordCreatedBy("ASM")
                'pcaja.SetRecordCreatedOn(.Parameters("@Fecha").Value)
            End With

            'Reset New State of Linea Object 
            pDPVF.ResetFlagNew()
            pDPVF.ResetFlagDirty()

            sccnnConnection.Close()
            valido = True
        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("El proceso de disposición fue interrumpido por problemas de conexión.  Favor de ingresar a la opción de Re proceso para continuar con la operación", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("El proceso de disposición fue interrumpido por problemas de conexión.  Favor de ingresar a la opción de Re proceso para continuar con la operación", ex)

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing
        Return valido
    End Function

    Public Function GetDisposicionEfeClubDPBCount(ByVal INE As String, ByVal Fecha As DateTime) As Integer
        Dim count As Integer = 0
        Dim conexion As New SqlConnection(m_strConnectionStringDPVF)
        Dim command As New SqlCommand("GetPrestamosByCliente", conexion)
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.AddWithValue("@IFE", INE)
            command.Parameters.AddWithValue("@Fecha", Fecha)
            count = CInt(command.ExecuteScalar())
            command.Dispose()
            conexion.Close()
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
        Return count
    End Function

    Public Function SelectDPVFinancieroDispersion(ByVal CodAlmacen As String, ByVal TransactionId As Integer, ByVal ClubDP As String) As DPVFinancieroDispersion
        Dim oDpvf As New DPVFinancieroDispersion(oParent)
        Dim conexion As New SqlConnection(m_strConnectionStringDPVF)
        Dim command As New SqlCommand("GetDispesionDatosArchivosDPVF", conexion)
        Dim reader As SqlDataReader = Nothing
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.AddWithValue("@CodAlmacen", CodAlmacen)
            command.Parameters.AddWithValue("@TransactionId", TransactionId)
            command.Parameters.AddWithValue("@ClubDP", ClubDP)
            reader = command.ExecuteReader()
            If reader.HasRows Then
                While reader.Read()
                    oDpvf.ID = CInt(reader("ID_DatosArchivos"))
                    oDpvf.IDCliente = CInt(reader("IDCliente"))
                    oDpvf.SecuencialFile = CInt(reader("SecFile"))
                    oDpvf.Importe = CDec(reader("Importe"))
                    oDpvf.Intereses = CDec(reader("Intereses"))
                    oDpvf.NoCuentaAbono = CStr(reader("NoCuenta"))
                    oDpvf.Fecha = CDate(reader("FechaDispersion"))
                    oDpvf.FechaRegistro = CDate(reader("Fecha"))
                    oDpvf.NoDPVale = CStr(reader("DPVale"))
                    oDpvf.Tipo = CInt(reader("Tipo"))
                    oDpvf.CodAlmacen = CStr(reader("CodAlmacen"))
                    oDpvf.NumFactura = CStr(reader("FolioSAP"))
                    oDpvf.Asociado = CInt(reader("IDAsociado"))
                    oDpvf.CodPlaza = CStr(reader("CodPlaza"))
                    oDpvf.Oficina = CStr(reader("Oficina"))
                    oDpvf.AltaTarjeta = CBool(reader("AltaTarjeta"))
                    oDpvf.NumeroIFE = CStr(reader("NoIFE"))
                    oDpvf.FolioFISAPIntereses = CStr(reader("FolioFISAPInt"))
                    oDpvf.FolioFISAPMonto = CStr(reader("FolioFISAPMonto"))
                    oDpvf.Banco = CStr(reader("Banco"))
                    oDpvf.Celular = CStr(reader("Celular"))
                    oDpvf.CompañiaCelular = CStr(reader("CompañiaCelular"))
                    oDpvf.CLABE = CStr(reader("Clabe"))
                    oDpvf.Transfer = CBool(reader("Transfer"))
                    oDpvf.NumeroTarjeta = CStr(reader("NumeroTarjeta"))
                    oDpvf.Codigo = CStr(reader("Codigo"))
                    oDpvf.NombreCliente = CStr(reader("NombreCliente"))
                    oDpvf.Dispersion = CBool(reader("Dispersion"))
                    oDpvf.CodigoSeguridad = CStr(reader("CodigoSeguridad"))
                    oDpvf.FechNac = CDate(reader("FecNac"))
                    oDpvf.ServicioID = CStr(reader("ServicioId"))
                    oDpvf.FechaDispersion = CDate(reader("FechaDispersion"))
                    oDpvf.NoColaborador = CStr(reader("NoColaborador"))
                    oDpvf.AccountNumber = CStr(reader("AccountNumber"))
                    oDpvf.Microcredito = CBool(reader("Microcredito"))
                    oDpvf.PlazoMicrocredito = CStr(reader("PlazoMicrocredito"))
                    oDpvf.ClubDP = CStr(reader("ClubDP"))
                    oDpvf.TransactionId = CInt(reader("TransactionId"))
                End While
            End If
            command.Dispose()
            conexion.Close()
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
        Return oDpvf
    End Function

    Public Function GetDisposiciones(ByVal CodAlmacen As String, ByVal Fecha As DateTime) As DataTable
        Dim dtDisposiones As New DataTable()
        Dim conexion As New SqlConnection(m_strConnectionStringDPVF)
        Dim command As New SqlCommand("GetDisposicionSolicitadoByAlmacen", conexion)
        Dim adapter As SqlDataAdapter = Nothing
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.AddWithValue("@CodAlmacen", CodAlmacen)
            command.Parameters.AddWithValue("@Fecha", Fecha)
            adapter = New SqlDataAdapter(command)
            adapter.Fill(dtDisposiones)
            command.Dispose()
            conexion.Close()
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
        Return dtDisposiones
    End Function

    Public Function ValidarMontoMinimo(ByVal CodAlmacen As String, ByVal PlanCode As String, ByVal Monto As Decimal) As Integer
        Dim conexion As New SqlConnection(m_strConnectionStringDPVF)
        Dim command As New SqlCommand("ValidarMontoMinimo", conexion)
        Dim count As Integer = 0
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.AddWithValue("@CodAlmacen", CodAlmacen)
            command.Parameters.AddWithValue("@PlanCode", PlanCode)
            command.Parameters.AddWithValue("@Monto", Monto)
            count = CInt(command.ExecuteScalar())
            command.Dispose()
            conexion.Close()
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
        Return count
    End Function

    Public Function GetServicioByCodigoBanco(ByVal ServicioID As String) As DataTable
        Dim dtServicios As New DataTable()
        Dim conexion As New SqlConnection(m_strConnectionStringDPVF)
        Dim command As New SqlCommand("GetServicioByCodigoBanco", conexion)
        Dim adapter As SqlDataAdapter = Nothing
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.AddWithValue("@ServicioID", ServicioID)
            adapter = New SqlDataAdapter(command)
            adapter.Fill(dtServicios)
            command.Dispose()
            conexion.Close()
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
        Return dtServicios
    End Function

    Public Sub GetMontosDisposicionEfeClubDP(ByVal Fecha As DateTime, ByRef MontoAprobado As Decimal, ByRef MontoCancelado As Decimal)
        Dim conexion As New SqlConnection(m_strConnectionStringDPVF)
        Dim command As New SqlCommand("GetMontosDisposicionEfeClubDP", conexion)
        Try
            Dim ParameterAprobado As New SqlParameter("@Aprobado", SqlDbType.Decimal)
            Dim ParameterCancelado As New SqlParameter("@Cancelado", SqlDbType.Decimal)
            ParameterAprobado.Direction = ParameterDirection.InputOutput
            ParameterCancelado.Direction = ParameterDirection.InputOutput
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.AddWithValue("@CodAlmacen", oParent.ApplicationContext.ApplicationConfiguration.Almacen)
            command.Parameters.AddWithValue("@Fecha", Fecha)
            command.Parameters.Add(ParameterAprobado)
            command.Parameters.Add(ParameterCancelado)
            command.ExecuteNonQuery()
            If IsDBNull(ParameterAprobado.Value) = False Then
                MontoAprobado = CDec(ParameterAprobado.Value)
            End If
            If IsDBNull(ParameterCancelado.Value) = False Then
                MontoCancelado = CDec(ParameterCancelado.Value)
            End If
            command.Dispose()
            conexion.Close()
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
    End Sub

#End Region

#Region "Mejoras de Rendimiento"

    Public Function ValidarServicioDispersion(ByVal Servicio As String, ByVal NumTarjeta As String) As Integer
        Dim count As Integer = 0
        Dim conexion As New SqlConnection(m_strConnectionStringDPVF)
        Dim command As New SqlCommand("ValidarServicioBancario", conexion)
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.AddWithValue("@Servicio", Servicio)
            command.Parameters.AddWithValue("@NumTarjeta", NumTarjeta)
            count = CInt(command.ExecuteScalar())
            command.Dispose()
            conexion.Close()
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
        Return count
    End Function

#End Region

#Region "Activacion por plaza"

    Public Function GetCatalogoServiciosByPlaza(ByVal Opcion As Integer, ByVal CodPlaza As String) As DataTable
        Dim dtCatalogoServicio As New DataTable()
        Dim conexion As New SqlConnection(m_strConnectionStringDPVF)
        Dim command As New SqlCommand("GetCatalogoServiciosByPlaza", conexion)
        Dim adapter As SqlDataAdapter = Nothing
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.AddWithValue("@Opcion", Opcion)
            command.Parameters.AddWithValue("@CodPlaza", CodPlaza)
            adapter = New SqlDataAdapter(command)
            adapter.Fill(dtCatalogoServicio)
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
        Return dtCatalogoServicio
    End Function

#End Region

End Class
