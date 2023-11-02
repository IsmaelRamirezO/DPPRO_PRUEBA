Imports DportenisPro.DPTienda.Core
Imports DportenisPro.DPTienda.ApplicationUnits.Facturas
Imports DportenisPro.DPTienda.ApplicationUnits.NotasCreditoAU
Imports System.Data.SqlClient

Public Class FingerPrintDataGateWay

    Dim oParent As FingerPrintManager
    Dim m_strConnectionString As String

#Region "Constructor"

    Public Sub New(ByVal oFPMgr As FingerPrintManager)

        oParent = oFPMgr
        m_strConnectionString = "data source = " & oParent.ConfigCierreFI.ServerHuellas & "; initial catalog = " & _
                                oParent.ConfigCierreFI.BaseDatosHuellas & "; user id = " & _
                                oParent.ConfigCierreFI.UserHuellas & "; password = " & _
                                oParent.ConfigCierreFI.PassHuellas

    End Sub

#End Region

#Region "Methods"

    Public Sub GuardarCliente(ByRef oFingerP As FingerPrint, ByVal TipoVenta As String, ByVal NumDatos As Integer)

        Dim oCon As New SqlClient.SqlConnection(m_strConnectionString)
        Dim sccmdInsert As SqlClient.SqlCommand

        sccmdInsert = New SqlClient.SqlCommand

        With sccmdInsert

            .Connection = oCon
            .CommandText = "[ClientesIns]"
            .CommandType = CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ID_Cliente", System.Data.SqlDbType.VarChar, 10, "ID_Cliente"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@EsClienteSAP", System.Data.SqlDbType.Bit, 1, "Es Cliente SAP"))
            .Parameters.Add(New SqlParameter("@UserID", SqlDbType.Int, 4, "UserID"))
            .Parameters.Add(New SqlParameter("@TipoVenta", SqlDbType.VarChar, 3, "TipoVenta"))
            .Parameters.Add(New SqlParameter("@NumDatos", SqlDbType.Int, 4, "Numero de Datos"))

            .Parameters("@UserID").Direction = ParameterDirection.InputOutput

        End With

        Try

            oCon.Open()

            With sccmdInsert
                .Parameters("@UserID").Value = oFingerP.UserID
                .Parameters("@ID_Cliente").Value = oFingerP.IDCliente
                .Parameters("@EsClienteSAP").Value = oFingerP.EsClienteSAP
                .Parameters("@TipoVenta").Value = tipoventa
                .Parameters("@NumDatos").Value = numdatos

                .ExecuteNonQuery()

                oFingerP.UserID = .Parameters("@UserID").Value

                oFingerP.ResetFlagNew()

            End With

            oCon.Close()

        Catch oSQLEx As SqlClient.SqlException

            If oCon.State <> ConnectionState.Closed Then

                oCon.Close()

            End If

            Throw New ApplicationException("El Registro no pudo ser insertado debido a un error de base de datos")

        Catch ex As Exception

            If oCon.State <> ConnectionState.Closed Then

                oCon.Close()

            End If

            Throw New ApplicationException("El Registro no pudo ser insertado debido a un error de aplicación")

        End Try

    End Sub

    Public Function GuardarClienteVenta(ByVal oFactura As Factura) As Boolean

        Dim oCon As New SqlClient.SqlConnection(m_strConnectionString)
        Dim sccmdInsert As SqlClient.SqlCommand
        Dim bResult As Boolean = False

        sccmdInsert = New SqlClient.SqlCommand

        With sccmdInsert

            .Connection = oCon
            .CommandText = "[ClienteVentaIns]"
            .CommandType = CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioSAP", System.Data.SqlDbType.VarChar, 10, "FolioSAP"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ClienteID", System.Data.SqlDbType.Int, 4, "Cliente ID"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Importe", System.Data.SqlDbType.Decimal, 9, "Importe"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodVendedor", System.Data.SqlDbType.VarChar, 8, "CodVendedor"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@NombreVendedor", System.Data.SqlDbType.VarChar, 100, "Nombre Vendedor"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RegistroCliente", System.Data.SqlDbType.Bit, 4, "Se registro cliente"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@OficinaVta", System.Data.SqlDbType.VarChar, 4, "Oficina Venta"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime, 8, "Fecha"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Razon", System.Data.SqlDbType.VarChar, 250, "Razon de rechazo"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RazonID", System.Data.SqlDbType.Int, 4, "ID Razon de rechazo"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodPlaza", System.Data.SqlDbType.VarChar, 4, "CodPlaza"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioFISAP", System.Data.SqlDbType.VarChar, 10, "FolioFISAP"))

        End With

        Try
            oCon.Open()

            With sccmdInsert

                .Parameters("@FolioSAP").Value = oFactura.FolioSAP.Trim
                .Parameters("@ClienteID").Value = oFactura.ClientPGID
                .Parameters("@Importe").Value = oFactura.Total
                .Parameters("@CodVendedor").Value = oFactura.CodVendedor.Trim
                .Parameters("@NombreVendedor").Value = oFactura.Usuario.Trim
                .Parameters("@RegistroCliente").Value = IIf(oFactura.ClientPGID > 0, True, False)
                .Parameters("@OficinaVta").Value = "T" & oFactura.CodAlmacen
                .Parameters("@Fecha").Value = oFactura.Fecha
                .Parameters("@Razon").Value = oFactura.RazonRechazo
                .Parameters("@RazonID").Value = oFactura.RazonRechazoID
                .Parameters("@CodPlaza").Value = oFactura.CodPlaza.Trim
                .Parameters("@FolioFISAP").Value = oFactura.FolioFISAP.Trim

                .ExecuteNonQuery()

            End With

            oCon.Close()

            bResult = True

        Catch oSQLEx As SqlClient.SqlException

            If oCon.State <> ConnectionState.Closed Then

                oCon.Close()

            End If

            'Throw New ApplicationException("El Registro no pudo ser insertado debido a un error de base de datos")

        Catch ex As Exception

            If oCon.State <> ConnectionState.Closed Then

                oCon.Close()

            End If

            'Throw New ApplicationException("El Registro no pudo ser insertado debido a un error de aplicación")

        End Try

        Return bResult

    End Function

    Public Sub SaveAutorizacion(ByVal Usuario As String, ByVal Nombre As String, ByVal Modulo As String, ByVal Tienda As String, ByVal Caja As String)

        Dim oCon As New SqlClient.SqlConnection(m_strConnectionString)
        Dim sccmdInsert As SqlClient.SqlCommand
        Dim bResult As Boolean = False

        sccmdInsert = New SqlClient.SqlCommand

        With sccmdInsert

            .Connection = oCon
            .CommandText = "[AutorizacionesIns]"
            .CommandType = CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Usuario", System.Data.SqlDbType.VarChar, 20, "Usuario"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Nombre", System.Data.SqlDbType.VarChar, 50, "Nombre"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Modulo", System.Data.SqlDbType.VarChar, 50, "Modulo"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Tienda", System.Data.SqlDbType.VarChar, 10, "Tienda"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Caja", System.Data.SqlDbType.VarChar, 2, "Caja"))
        End With

        Try
            oCon.Open()

            With sccmdInsert

                .Parameters("@Usuario").Value = Usuario.Trim
                .Parameters("@Nombre").Value = Nombre.Trim
                .Parameters("@Modulo").Value = Modulo.Trim
                .Parameters("@Tienda").Value = Tienda.Trim
                .Parameters("@Caja").Value = Caja.Trim

                .ExecuteNonQuery()

            End With

            oCon.Close()

            bResult = True

        Catch oSQLEx As SqlClient.SqlException

            If oCon.State <> ConnectionState.Closed Then

                oCon.Close()

            End If

            Throw New ApplicationException("El Registro no pudo ser insertado debido a un error de base de datos")

        Catch ex As Exception

            If oCon.State <> ConnectionState.Closed Then

                oCon.Close()

            End If

            Throw New ApplicationException("El Registro no pudo ser insertado debido a un error de aplicación")

        End Try

    End Sub

    Public Sub GuardarHuella(ByVal oFingerP As FingerPrint)

        Dim oCon As New SqlClient.SqlConnection(m_strConnectionString)
        Dim sccmdInsert As SqlClient.SqlCommand

        sccmdInsert = New SqlClient.SqlCommand

        With sccmdInsert

            .Connection = oCon
            .CommandText = "[FingerPrintIns]"
            .CommandType = CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FingerNum", System.Data.SqlDbType.Int, 4, "@FingerNum"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@SampleNum", System.Data.SqlDbType.Int, 4, "@SampleNum"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Template", System.Data.SqlDbType.VarChar, 1000, "@Template"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@UserID", System.Data.SqlDbType.BigInt, 8, "IDUnico"))

        End With

        Try

            oCon.Open()

            With sccmdInsert

                .Parameters("@FingerNum").Value = oFingerP.FingerID
                .Parameters("@SampleNum").Value = oFingerP.SampleNum
                .Parameters("@Template").Value = oFingerP.Template
                .Parameters("@UserID").Value = oFingerP.UserID

                .ExecuteNonQuery()

            End With

            oCon.Close()

        Catch oSQLEx As SqlClient.SqlException

            If oCon.State <> ConnectionState.Closed Then

                oCon.Close()

            End If

            Throw New ApplicationException("El registro no pudo ser insertado debido a un error de base de datos")

        Catch ex As Exception

            If oCon.State <> ConnectionState.Closed Then

                oCon.Close()

            End If

            Throw New ApplicationException("El registro no pudo ser insertado debido a un error de aplicación")

        End Try

    End Sub

    Public Sub Update(ByVal oFP As FingerPrint, ByVal TipoVenta As String, ByVal NumDatos As Integer)

        Dim oCon As New System.Data.SqlClient.SqlConnection(m_strConnectionString)

        Dim sccmdUpdate As System.Data.SqlClient.SqlCommand
        sccmdUpdate = New System.Data.SqlClient.SqlCommand

        With sccmdUpdate

            .Connection = oCon

            .CommandText = "[ClientesFingerPrintUpd]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ID_Cliente", System.Data.SqlDbType.Int, 4, "ID_Cliente"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FingerNum", System.Data.SqlDbType.Int, 4, "FingerNum"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@SampleNum", System.Data.SqlDbType.Int, 4, "SampleNum"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Template", System.Data.SqlDbType.VarChar, 1000, "Template"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@EsClienteSAP", System.Data.SqlDbType.Bit, 1, "Es Cliente SAP"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@UserID", System.Data.SqlDbType.Int, 4, "UserID"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TipoVenta", System.Data.SqlDbType.VarChar, 3, "TipoVenta"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@NumDatos", System.Data.SqlDbType.Int, 4, "NumDatos"))

        End With

        Try

            oCon.Open()

            With sccmdUpdate
                'Assign Parameters Values
                .Parameters("@ID_Cliente").Value = oFP.IDCliente
                .Parameters("@FingerNum").Value = oFP.FingerID
                .Parameters("@SampleNum").Value = oFP.SampleNum
                .Parameters("@Template").Value = oFP.Template
                .Parameters("@EsClienteSAP").Value = oFP.EsClienteSAP
                .Parameters("@UserID").Value = oFP.UserID
                .Parameters("@TipoVenta").Value = TipoVenta
                .Parameters("@NumDatos").Value = NumDatos

                'Execute Command
                .ExecuteNonQuery()

            End With

            'Reset New State of Linea Object 
            'Linea.ResetStateNew()
            oFP.ResetFlagDirty()

            oCon.Close()

        Catch oSqlException As SqlClient.SqlException

            If (oCon.State <> ConnectionState.Closed) Then
                Try
                    oCon.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("El registro no pudo ser actualizado debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (oCon.State <> ConnectionState.Closed) Then
                Try
                    oCon.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("El registro no pudo ser actualizado debido a un error de aplicación.", ex)

        End Try

        oCon.Dispose()
        oCon = Nothing

    End Sub

    Public Function GuardarClienteDevolucion(ByVal oNotaCredito As NotaCredito, ByVal FolioSAP As String) As Boolean

        Dim oCon As New SqlClient.SqlConnection(m_strConnectionString)
        Dim sccmdInsert As SqlClient.SqlCommand
        Dim bResult As Boolean = False

        sccmdInsert = New SqlClient.SqlCommand

        With sccmdInsert

            .Connection = oCon
            .CommandText = "[ClienteDevolucionIns]"
            .CommandType = CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioSAP", System.Data.SqlDbType.VarChar, 10, "FolioSAP"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ClienteID", System.Data.SqlDbType.Int, 4, "Cliente ID"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Importe", System.Data.SqlDbType.Decimal, 9, "Importe"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodVendedor", System.Data.SqlDbType.VarChar, 8, "CodVendedor"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@NombreVendedor", System.Data.SqlDbType.VarChar, 100, "Nombre Vendedor"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@OficinaVta", System.Data.SqlDbType.VarChar, 4, "Oficina Venta"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime, 8, "Fecha"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioSAPDev", System.Data.SqlDbType.VarChar, 10, "FolioSAP Devolucion"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioFISAPDev", System.Data.SqlDbType.VarChar, 10, "FolioFISAP Devolucion"))
        End With

        Try

            oCon.Open()

            With sccmdInsert

                .Parameters("@FolioSAPDev").Value = oNotaCredito.SALESDOCUMENT.Trim
                .Parameters("@FolioFISAPDev").Value = oNotaCredito.FIDOCUMENT.Trim
                .Parameters("@FolioSAP").Value = FolioSAP.Trim
                .Parameters("@ClienteID").Value = oNotaCredito.ClientePGID
                .Parameters("@Importe").Value = oNotaCredito.Importe
                .Parameters("@CodVendedor").Value = oNotaCredito.PlayerID.Trim
                .Parameters("@NombreVendedor").Value = oNotaCredito.Usuario.Trim
                .Parameters("@OficinaVta").Value = "T" & oNotaCredito.AlmacenID.Trim
                .Parameters("@Fecha").Value = oNotaCredito.Fecha

                .ExecuteNonQuery()

            End With

            oCon.Close()

            bResult = True

        Catch oSQLEx As SqlClient.SqlException

            If oCon.State <> ConnectionState.Closed Then

                oCon.Close()

            End If

            'Throw New ApplicationException("El Registro no pudo ser insertado debido a un error de base de datos")

        Catch ex As Exception

            If oCon.State <> ConnectionState.Closed Then

                oCon.Close()

            End If

            'Throw New ApplicationException("El Registro no pudo ser insertado debido a un error de aplicación")

        End Try

        Return bResult

    End Function

    Public Function ClienteVentaUpdate(ByVal FolioSAP As String, ByVal FCFolioSAP As String, ByVal FCFolioFISAP As String) As Boolean

        Dim oCon As New System.Data.SqlClient.SqlConnection(m_strConnectionString)

        Dim sccmdUpdate As System.Data.SqlClient.SqlCommand
        sccmdUpdate = New System.Data.SqlClient.SqlCommand

        Dim bResult As Boolean = False

        With sccmdUpdate

            .Connection = oCon

            .CommandText = "[ClientesVentasUpdStatus]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioSAP", System.Data.SqlDbType.VarChar, 10, "FolioSAP"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FCFolioSAP", System.Data.SqlDbType.VarChar, 10, "FolioSAP"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FCFolioFISAP", System.Data.SqlDbType.VarChar, 10, "FolioFISAP"))
        End With

        Try

            oCon.Open()

            With sccmdUpdate
                'Assign Parameters Values
                .Parameters("@FolioSAP").Value = FolioSAP.Trim
                .Parameters("@FCFolioSAP").Value = FCFolioSAP.Trim
                .Parameters("@FCFolioFISAP").Value = FCFolioFISAP.Trim

                'Execute Command
                .ExecuteNonQuery()
            End With

            oCon.Close()

            bResult = True

        Catch oSqlException As SqlClient.SqlException

            If (oCon.State <> ConnectionState.Closed) Then
                Try
                    oCon.Close()
                Catch
                End Try
            End If

            'Throw New ApplicationException("El registro no pudo ser actualizado debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (oCon.State <> ConnectionState.Closed) Then
                Try
                    oCon.Close()
                Catch
                End Try
            End If

            'Throw New ApplicationException("El registro no pudo ser actualizado debido a un error de aplicación.", ex)

        End Try

        oCon.Dispose()
        oCon = Nothing

        Return bResult

    End Function

    Public Function ObtenerHuellas() As DataSet

        Dim oCon As New SqlClient.SqlConnection(m_strConnectionString)
        Dim sccmdSelAll As SqlClient.SqlCommand
        Dim scdsHuellas As DataSet
        Dim scdaHuellas As SqlClient.SqlDataAdapter

        sccmdSelAll = New SqlClient.SqlCommand
        scdsHuellas = New DataSet("Huellas")
        scdaHuellas = New SqlClient.SqlDataAdapter

        With sccmdSelAll

            .Connection = oCon
            .CommandText = "[FingerPrintSelAll]"
            .CommandType = CommandType.StoredProcedure

        End With

        scdaHuellas.SelectCommand = sccmdSelAll

        Try

            oCon.Open()

            scdaHuellas.Fill(scdsHuellas, "Huellas")

            oCon.Close()

        Catch exSQL As SqlClient.SqlException

            If oCon.State <> ConnectionState.Closed Then
                oCon.Close()
            End If

            MsgBox(exSQL)

            Throw New ApplicationException("Los registros no se pudieron obtener debido a un error de base de datos")

        Catch ex As Exception

            If oCon.State <> ConnectionState.Closed Then
                oCon.Close()
            End If

            Throw New ApplicationException("Los registros no se pudieron obtener debido a un error de aplicación")

        End Try

        oCon.Dispose()
        oCon = Nothing

        Return scdsHuellas

    End Function

    Public Function GetClienteIDs(ByVal IDUnico As Int64) As DataTable

        Dim oCon As New SqlClient.SqlConnection(m_strConnectionString)
        Dim sccmdSelAll As SqlClient.SqlCommand
        Dim scdsHuellas As DataSet
        Dim scdaHuellas As SqlClient.SqlDataAdapter

        sccmdSelAll = New SqlClient.SqlCommand
        scdsHuellas = New DataSet("Huellas")
        scdaHuellas = New SqlClient.SqlDataAdapter

        With sccmdSelAll

            .Connection = oCon
            .CommandText = "[ClienteIDsSel]"
            .CommandType = CommandType.StoredProcedure

            .Parameters.Add(New SqlParameter("@IDUnico", SqlDbType.BigInt, 8, "ID Universal"))

        End With

        scdaHuellas.SelectCommand = sccmdSelAll

        Try

            sccmdSelAll.Parameters("@IDUnico").Value = IDUnico

            oCon.Open()

            scdaHuellas.Fill(scdsHuellas, "Huellas")

            oCon.Close()

        Catch exSQL As SqlClient.SqlException

            If oCon.State <> ConnectionState.Closed Then
                oCon.Close()
            End If

            MsgBox(exSQL)

            Throw New ApplicationException("Los registros no se pudieron obtener debido a un error de base de datos")

        Catch ex As Exception

            If oCon.State <> ConnectionState.Closed Then
                oCon.Close()
            End If

            Throw New ApplicationException("Los registros no se pudieron obtener debido a un error de aplicación")

        End Try

        oCon.Dispose()
        oCon = Nothing

        Return scdsHuellas.Tables(0)

    End Function

    Public Function SelectVentasPGByClienteID(ByVal ClienteID As Integer, ByRef FolioSAP As String) As Boolean

        Dim oResult As DataSet
        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader
        Dim bResult As Boolean = True

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[ClienteVentaSelByCliente]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New SqlParameter("@ClienteID", SqlDbType.Int, 4, "ClienteID"))

            .Parameters("@ClienteID").Value = ClienteID
        End With

        Dim oFacturaAdapter As SqlDataAdapter
        oFacturaAdapter = New SqlDataAdapter
        oFacturaAdapter.SelectCommand = sccmdSelect

        Try

            sccnnConnection.Open()

            oResult = New DataSet

            oFacturaAdapter.Fill(oResult, "FacturasPG")

            sccnnConnection.Close()

            If oResult.Tables(0).Rows.Count > 0 Then
                FolioSAP = oResult.Tables(0).Rows(0)!FolioSAP
                bResult = True
            Else
                bResult = False
            End If

        Catch ex As Exception

            'Throw ex

        Finally

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

        End Try

        sccmdSelect.Dispose()
        sccmdSelect = Nothing

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return bResult

    End Function

    Public Function ObtenerHuellasHoy() As DataSet

        Dim oCon As New SqlClient.SqlConnection(m_strConnectionString)
        Dim sccmdSelAll As SqlClient.SqlCommand
        Dim scdsHuellasHoy As DataSet
        Dim scdaHuellasHoy As SqlClient.SqlDataAdapter

        sccmdSelAll = New SqlClient.SqlCommand
        scdsHuellasHoy = New DataSet("HuellasHoy")
        scdaHuellasHoy = New SqlClient.SqlDataAdapter

        With sccmdSelAll

            .Connection = oCon
            .CommandText = "[ClientesTodaySel]"
            .CommandType = CommandType.StoredProcedure

        End With

        scdaHuellasHoy.SelectCommand = sccmdSelAll

        Try

            oCon.Open()

            scdaHuellasHoy.Fill(scdsHuellasHoy, "HuellasHoy")

            oCon.Close()

        Catch exSQL As SqlClient.SqlException

            If oCon.State <> ConnectionState.Closed Then
                oCon.Close()
            End If

            MsgBox(exSQL)

            Throw New ApplicationException("Los registros no se pudieron obtener debido a un error de base de datos")

        Catch ex As Exception

            If oCon.State <> ConnectionState.Closed Then
                oCon.Close()
            End If

            Throw New ApplicationException("Los registros no se pudieron obtener debido a un error de aplicación")

        End Try

        oCon.Dispose()
        oCon = Nothing

        Return scdsHuellasHoy

    End Function

    Public Function SelectByID(ByVal UserID As Long) As FingerPrint

        Dim oCon As New System.Data.SqlClient.SqlConnection(m_strConnectionString)
        Dim sccmdSelect As System.Data.SqlClient.SqlCommand
        Dim scdrSelect As System.Data.SqlClient.SqlDataReader
        Dim oFingerPrint As FingerPrint

        sccmdSelect = New System.Data.SqlClient.SqlCommand

        oFingerPrint = oParent.Create

        With sccmdSelect

            .Connection = oCon
            .CommandText = "[ClientesSel]"
            .CommandType = CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@UserID", System.Data.SqlDbType.Int, 4, "UserID"))

        End With

        Try

            oCon.Open()

            With sccmdSelect

                .Parameters("@UserID").Value = UserID

                scdrSelect = .ExecuteReader(CommandBehavior.SingleRow And CommandBehavior.SingleResult)

                scdrSelect.Read()

                If scdrSelect.HasRows = True Then

                    With scdrSelect

                        oFingerPrint.UserID = .GetInt64(.GetOrdinal("ID_User"))
                        'oFingerPrint.IDCliente = .GetString(.GetOrdinal("ID_Cliente")).ToUpper
                        oFingerPrint.FingerID = .GetInt32(.GetOrdinal("FingerNum"))
                        oFingerPrint.SampleNum = .GetInt32(.GetOrdinal("SampleNum"))
                        oFingerPrint.Template = .GetString(.GetOrdinal("Template"))
                        'oFingerPrint.EsClienteSAP = .GetBoolean(.GetOrdinal("ClienteSAP"))

                        oFingerPrint.ResetFlagNew()
                        oFingerPrint.ResetFlagDirty()

                    End With

                Else

                    'oFingerPrint = Nothing
                    oFingerPrint.SetFlagNew()

                End If

            End With


            oCon.Close()

        Catch exSQL As SqlClient.SqlException

            If oCon.State <> ConnectionState.Closed Then

                oCon.Close()

            End If

            Throw New ApplicationException("El registro no pudo ser leido debido a un error de base de datos")

        Catch ex As Exception

            If oCon.State <> ConnectionState.Closed Then

                oCon.Close()

            End If

            Throw New ApplicationException("El registro no pudo ser leido debido a un error de base de aplicación")

        End Try

        oCon.Dispose()
        oCon = Nothing

        Return oFingerPrint

    End Function

    Public Function SelectByClienteID(ByVal ClienteID As String) As FingerPrint

        Dim oCon As New System.Data.SqlClient.SqlConnection(m_strConnectionString)
        Dim sccmdSelect As System.Data.SqlClient.SqlCommand
        Dim scdrSelect As System.Data.SqlClient.SqlDataReader
        Dim oFingerPrint As FingerPrint

        sccmdSelect = New System.Data.SqlClient.SqlCommand

        oFingerPrint = oParent.Create

        With sccmdSelect

            .Connection = oCon
            .CommandText = "[ClienteIDsSelByClienteID]"
            .CommandType = CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@IDCliente", System.Data.SqlDbType.VarChar, 10, "ClienteID"))

        End With

        Try

            oCon.Open()

            With sccmdSelect

                .Parameters("@IDCliente").Value = ClienteID.PadLeft(10, "0")

                scdrSelect = .ExecuteReader(CommandBehavior.SingleRow And CommandBehavior.SingleResult)

                scdrSelect.Read()

                If scdrSelect.HasRows = True Then

                    With scdrSelect

                        oFingerPrint = SelectByID(.GetInt64(.GetOrdinal("IDUnico")))

                        oFingerPrint.ResetFlagNew()
                        oFingerPrint.ResetFlagDirty()

                    End With

                Else

                    oFingerPrint.SetFlagNew()

                End If

            End With

            oCon.Close()

        Catch exSQL As SqlClient.SqlException

            If oCon.State <> ConnectionState.Closed Then

                oCon.Close()

            End If

            Throw New ApplicationException("El registro no pudo ser leido debido a un error de base de datos")

        Catch ex As Exception

            If oCon.State <> ConnectionState.Closed Then

                oCon.Close()

            End If

            Throw New ApplicationException("El registro no pudo ser leido debido a un error de base de aplicación")

        End Try

        oCon.Dispose()
        oCon = Nothing

        Return oFingerPrint

    End Function

    Public Function SelectUserID() As Long

        Dim oCon As New System.Data.SqlClient.SqlConnection(m_strConnectionString)
        Dim sccmdSelect As System.Data.SqlClient.SqlCommand
        'Dim scdrSelect As System.Data.SqlClient.SqlDataReader
        Dim ID As Long = 0

        sccmdSelect = New System.Data.SqlClient.SqlCommand

        With sccmdSelect

            .Connection = oCon
            .CommandText = "[ClientesSelUserID]"
            .CommandType = CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@UserID", System.Data.SqlDbType.Int, 4, "UserID"))
            '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@UserID", System.Data.SqlDbType.Int, 4, "UserID"))
            .Parameters("@UserID").Direction = ParameterDirection.Output

        End With

        Try

            oCon.Open()

            With sccmdSelect

                '.Parameters("@ID_Cliente").Value = IDCliente
                '.Parameters("@UserID").Value = UserID

                'scdrSelect = .ExecuteReader(CommandBehavior.SingleRow And CommandBehavior.SingleResult)

                .ExecuteNonQuery()

                ID = .Parameters("@UserID").Value

                'scdrSelect.Read()

                'If scdrSelect.HasRows = True Then
                '    With scdrSelect
                '        ID = CLng(.GetInt32(.GetOrdinal("UserID")))
                '    End With
                'Else
                '    ID = 0
                'End If

            End With

            oCon.Close()

        Catch exSQL As SqlClient.SqlException

            If oCon.State <> ConnectionState.Closed Then

                oCon.Close()

            End If

            Throw New ApplicationException("El registro no pudo ser leido debido a un error de base de datos")

        Catch ex As Exception

            If oCon.State <> ConnectionState.Closed Then

                oCon.Close()

            End If

            Throw New ApplicationException("El registro no pudo ser leido debido a un error de base de aplicación")

        End Try

        oCon.Dispose()
        oCon = Nothing

        Return ID

    End Function

    'Public Function SelectConfig(ByVal param As String) As String

    '    Dim oCon As New System.Data.SqlClient.SqlConnection(m_strConnectionString)
    '    Dim sccmdSelect As System.Data.SqlClient.SqlCommand
    '    Dim scdrSelect As System.Data.SqlClient.SqlDataReader
    '    Dim strValor As String = ""

    '    sccmdSelect = New System.Data.SqlClient.SqlCommand

    '    With sccmdSelect

    '        .Connection = oCon
    '        .CommandText = "[ConfigSel]"
    '        .CommandType = CommandType.StoredProcedure

    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@param", System.Data.SqlDbType.VarChar, 50, "parametro"))

    '    End With

    '    Try

    '        oCon.Open()

    '        With sccmdSelect

    '            .Parameters("@param").Value = param.Trim

    '            scdrSelect = .ExecuteReader(CommandBehavior.SingleRow And CommandBehavior.SingleResult)

    '            scdrSelect.Read()

    '            If scdrSelect.HasRows = True Then

    '                With scdrSelect

    '                    strValor = .GetString(.GetOrdinal("valor")).ToUpper

    '                End With

    '            Else

    '                strValor = ""

    '            End If

    '        End With

    '        oCon.Close()

    '    Catch exSQL As SqlClient.SqlException

    '        If oCon.State <> ConnectionState.Closed Then

    '            oCon.Close()

    '        End If

    '        'Throw New ApplicationException("El registro no pudo ser leido debido a un error de base de datos")

    '    Catch ex As Exception

    '        If oCon.State <> ConnectionState.Closed Then

    '            oCon.Close()

    '        End If

    '        'Throw New ApplicationException("El registro no pudo ser leido debido a un error de base de aplicación")

    '    End Try

    '    oCon.Dispose()
    '    oCon = Nothing

    '    Return strValor.Trim

    'End Function

    Public Function SelectByUser(ByVal IDUser As Integer) As String

        Dim oCon As New System.Data.SqlClient.SqlConnection(m_strConnectionString)
        Dim sccmdSelect As System.Data.SqlClient.SqlCommand
        Dim scdrSelect As System.Data.SqlClient.SqlDataReader
        Dim IDCliente As String

        sccmdSelect = New System.Data.SqlClient.SqlCommand

        With sccmdSelect

            .Connection = oCon
            .CommandText = "[ClientesSelByUser]"
            .CommandType = CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ID_User", System.Data.SqlDbType.Int, 4, "ID_User"))

        End With

        Try

            oCon.Open()

            With sccmdSelect

                .Parameters("@ID_User").Value = IDUser

                scdrSelect = .ExecuteReader(CommandBehavior.SingleRow And CommandBehavior.SingleResult)

                scdrSelect.Read()

                If scdrSelect.HasRows = True Then

                    With scdrSelect

                        IDCliente = .GetString(0).ToUpper

                    End With

                Else

                    IDCliente = ""

                End If

            End With


            oCon.Close()

        Catch exSQL As SqlClient.SqlException

            If oCon.State <> ConnectionState.Closed Then

                oCon.Close()

            End If

            Throw New ApplicationException("El registro no pudo ser leido debido a un error de base de datos")

        Catch ex As Exception

            If oCon.State <> ConnectionState.Closed Then

                oCon.Close()

            End If

            Throw New ApplicationException("El registro no pudo ser leido debido a un error de aplicación")

        End Try

        oCon.Dispose()
        oCon = Nothing

        Return IDCliente

    End Function

#End Region

End Class
