Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU

Public Class CancelaFacturaDataGateway

    Private oParent As CancelaFacturaManager
    Private m_strConnectionString As String
    Private oSAPMgr As ProcesoSAPManager
    Public oDPVale As cDPVale


#Region "Constructors / Destructors"

    Public Sub New(ByVal Parent As CancelaFacturaManager)

        oParent = Parent

        m_strConnectionString = oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString

    End Sub

#End Region

#Region "Methods"

    Friend Function SelectFechaServidor() As DateTime

        Dim oResult As DateTime

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim daFecha As SqlDataAdapter
        Dim sccmdSelect As SqlCommand
        Dim dsFecha As DataSet = New DataSet("Fecha")

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "SELECT GETDATE()AS FECHA"
            .CommandType = CommandType.Text

        End With

        daFecha = New SqlDataAdapter(sccmdSelect)

        Try

            sccnnConnection.Open()

            'Llenamos el Dataset
            daFecha.Fill(dsFecha)

            oResult = dsFecha.Tables(0).Rows(0).Item("Fecha")

            sccnnConnection.Close()

        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                sccnnConnection.Close()
            End If

            Throw New ApplicationException("El registro no pudo ser leido debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                sccnnConnection.Close()
            End If

            Throw New ApplicationException("El registro no pudo ser leido debido a un error de aplicación.", ex)

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return oResult

    End Function

    Friend Function SelectDiaCierre(ByVal dFechaFactura As DateTime) As Boolean

        Dim oResult As Boolean
        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim daFecha As SqlDataAdapter
        Dim sccmdSelect As SqlCommand
        Dim dsFecha As DataSet = New DataSet("Fecha")
        sccmdSelect = New SqlCommand
        With sccmdSelect
            .Connection = sccnnConnection
            .CommandText = "SELECT * FROM CierreDia WHERE convert(varchar(10),Fecha,101) = convert(varchar(10),'" & Format(dFechaFactura, "yyyy-MM-dd") & "',101)"
            .CommandType = CommandType.Text
        End With
        daFecha = New SqlDataAdapter(sccmdSelect)

        Try

            sccnnConnection.Open()

            'Llenamos el Dataset
            daFecha.Fill(dsFecha)
            If dsFecha.Tables(0).Rows.Count > 0 Then

                oResult = True

            Else

                oResult = False

            End If

            sccnnConnection.Close()

        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                sccnnConnection.Close()
            End If

            Throw New ApplicationException("El registro no pudo ser leido debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                sccnnConnection.Close()
            End If

            Throw New ApplicationException("El registro no pudo ser leido debido a un error de aplicación.", ex)

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return oResult

    End Function

    Friend Sub UpdateStatusFactura(ByVal FacturaID As Integer, ByVal strFolioSAP As String, ByVal CodVendedor As String, ByVal CodAlmacen As String, ByRef strFIDOCUMENT As String, ByRef strSALESDOCUMENT As String)

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdUpdateFactura As SqlCommand = New SqlCommand

        Try

            With sccmdUpdateFactura

                .Connection = sccnnConnection
                .CommandText = "UPDATE Factura SET Status = 'CAN', StatusRegistro = 0 WHERE FacturaID = " & FacturaID & ""
                .CommandText &= ";UPDATE FacturaCorrida SET StatusRegistro = 0 WHERE FacturaID = " & FacturaID & ""
                .CommandText &= ";UPDATE FacturasFormasPago SET StatusRegistro = 0 WHERE FacturaID = " & FacturaID & ""
                .CommandType = CommandType.Text

            End With

            sccnnConnection.Open()

            Try

                'Cancelar En SAP
                If strFIDOCUMENT = String.Empty AndAlso strSALESDOCUMENT = String.Empty Then
                    SaveSAP(strFolioSAP, strSALESDOCUMENT, strFIDOCUMENT, CodVendedor, CodAlmacen, False)
                End If


                With sccmdUpdateFactura
                    .CommandText &= ";UPDATE Factura SET FCFolioSAP = '" & strSALESDOCUMENT & "', FCFolioFISap = '" & strFIDOCUMENT & "' WHERE FacturaID = " & FacturaID & ""
                End With

            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

            sccmdUpdateFactura.ExecuteNonQuery()
            sccnnConnection.Close()

        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                sccnnConnection.Close()
            End If

            Throw New ApplicationException("El registro no pudo ser leido debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                sccnnConnection.Close()
            End If

            Throw New ApplicationException("El registro no pudo ser leido debido a un error de aplicación.", ex)

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

    End Sub

    Friend Sub UpdateStatusFacturaRetail(ByVal FacturaID As Integer, ByVal strFolioSAP As String, ByVal CodVendedor As String, ByVal CodAlmacen As String, ByRef strFIDOCUMENT As String, ByRef strSALESDOCUMENT As String)

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdUpdateFactura As SqlCommand = New SqlCommand

        Try

            With sccmdUpdateFactura

                .Connection = sccnnConnection
                .CommandText = "UPDATE Factura SET Status = 'CAN', StatusRegistro = 0 WHERE FacturaID = " & FacturaID & ""
                .CommandText &= ";UPDATE FacturaCorrida SET StatusRegistro = 0 WHERE FacturaID = " & FacturaID & ""
                .CommandText &= ";UPDATE FacturasFormasPago SET StatusRegistro = 0 WHERE FacturaID = " & FacturaID & ""
                .CommandType = CommandType.Text

            End With

            sccnnConnection.Open()

            Try

                'Cancelar En SAP
                'If strFIDOCUMENT = String.Empty AndAlso strSALESDOCUMENT = String.Empty Then
                '    SaveSAP(strFolioSAP, strSALESDOCUMENT, strFIDOCUMENT, CodVendedor, CodAlmacen, False)
                'End If


                With sccmdUpdateFactura
                    .CommandText &= ";UPDATE Factura SET FCFolioSAP = '" & strSALESDOCUMENT & "', FCFolioFISap = '" & strFIDOCUMENT & "' WHERE FacturaID = " & FacturaID & ""
                End With

            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

            sccmdUpdateFactura.ExecuteNonQuery()
            sccnnConnection.Close()

        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                sccnnConnection.Close()
            End If

            Throw New ApplicationException("El registro no pudo ser leido debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                sccnnConnection.Close()
            End If

            Throw New ApplicationException("El registro no pudo ser leido debido a un error de aplicación.", ex)

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

    End Sub

    Friend Sub DeleteValeEmpleado(ByVal FacturaID As Integer)

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdUpdateFactura As SqlCommand = New SqlCommand

        Try

            With sccmdUpdateFactura

                .Connection = sccnnConnection
                .CommandText = "ValeEmpleadoDel"
                .CommandType = CommandType.StoredProcedure

                .Parameters.Add(New SqlParameter("@FacturaID", SqlDbType.Int, 4))

                .Parameters("@FacturaID").Value = FacturaID

            End With

            sccnnConnection.Open()

            sccmdUpdateFactura.ExecuteNonQuery()

            sccnnConnection.Close()

        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                sccnnConnection.Close()
            End If

            Throw New ApplicationException("El registro no pudo ser leido debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                sccnnConnection.Close()
            End If

            Throw New ApplicationException("El registro no pudo ser leido debido a un error de aplicación.", ex)

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

    End Sub

    '-------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 18/07/2017: Revive Vale de empleado del pedido.
    '-------------------------------------------------------------------------------------------------------------------------

    Public Sub DeleteValeEmpleadoByPedidoId(ByVal PedidoId As Integer)
        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdUpdateFactura As SqlCommand = New SqlCommand

        Try

            With sccmdUpdateFactura

                .Connection = sccnnConnection
                .CommandText = "ValeEmpleadoDelByPedidoId"
                .CommandType = CommandType.StoredProcedure

                .Parameters.Add(New SqlParameter("@PedidoID", SqlDbType.Int, 4))

                .Parameters("@PedidoID").Value = PedidoId

            End With

            sccnnConnection.Open()

            sccmdUpdateFactura.ExecuteNonQuery()

            sccnnConnection.Close()

        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                sccnnConnection.Close()
            End If

            Throw New ApplicationException("El registro no pudo ser leido debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                sccnnConnection.Close()
            End If

            Throw New ApplicationException("El registro no pudo ser leido debido a un error de aplicación.", ex)

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing
    End Sub

    Friend Function ValidaFolioPRO(ByVal FolioSap As String, ByVal ClienteId As String, ByRef strFIDOCUMENT As String, ByRef strSALESDOCUMENT As String) As String
        oSAPMgr = New ProcesoSAPManager(oParent.ApplicationContext, oParent.SAPApplicationConfig)

        Return oSAPMgr.ZBAPI_VALIDA_FOLIO_PRO(FolioSap, ClienteId, strFIDOCUMENT, strSALESDOCUMENT)
    End Function

    Friend Sub UpdateStatusFacturaDPValeRetail(ByVal FacturaID As Integer, ByVal CodVendedor As String, ByVal CodAlmacen As String, ByVal strFIDOCUMENT As String, ByVal strSALESDOCUMENT As String, Optional ByVal FolioFISAP As String = "")

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdUpdateFactura As SqlCommand = New SqlCommand

        Try

            With sccmdUpdateFactura

                .Connection = sccnnConnection
                .CommandText = "UPDATE Factura SET Status = 'CAN', StatusRegistro = 0 WHERE FacturaID = " & FacturaID & ""
                .CommandText &= ";UPDATE FacturaCorrida SET StatusRegistro = 0 WHERE FacturaID = " & FacturaID & ""
                .CommandText &= ";UPDATE FacturasFormasPago SET StatusRegistro = 0 WHERE FacturaID = " & FacturaID & ""
                .CommandType = CommandType.Text

            End With

            sccnnConnection.Open()

            Try

                'If strFIDOCUMENT = "" AndAlso strSALESDOCUMENT = "" Then
                '    SaveSAP(strFolioSAP, strSALESDOCUMENT, strFIDOCUMENT, CodVendedor, CodAlmacen, True, FolioFISAP)
                'End If

                With sccmdUpdateFactura
                    .CommandText &= ";UPDATE Factura SET FCFolioSAP = '" & strSALESDOCUMENT & "', FCFolioFISap = '" & strFIDOCUMENT & "' WHERE FacturaID = " & FacturaID & ""
                End With

            Catch ex As Exception
                Throw New ApplicationException("Por el momento no puede cancelar Facturas DPortenis Vale." & ex.ToString)
            End Try

            sccmdUpdateFactura.ExecuteNonQuery()
            sccnnConnection.Close()

        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                sccnnConnection.Close()
            End If

            Throw New ApplicationException("El registro no pudo ser leido debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                sccnnConnection.Close()
            End If

            Throw New ApplicationException("El registro no pudo ser leido debido a un error de aplicación.", ex)

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

    End Sub

    Public Sub SaveSAPRetail(ByVal strFolioSAP As String, ByRef strSALESDOCUMENT As String, ByRef strFIDOCUMENT As String, ByVal CodVendedor As String, ByVal CodAlmacen As String _
                        , ByVal bolDPVale As Boolean, Optional ByVal FolioFISAP As String = "")


    End Sub

    Friend Sub UpdateStatusFacturaDPVale(ByVal FacturaID As Integer, ByVal strFolioSAP As String, ByVal CodVendedor As String, ByVal CodAlmacen As String, ByVal strFIDOCUMENT As String, ByVal strSALESDOCUMENT As String, Optional ByVal FolioFISAP As String = "")

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdUpdateFactura As SqlCommand = New SqlCommand

        Try

            With sccmdUpdateFactura

                .Connection = sccnnConnection
                .CommandText = "UPDATE Factura SET Status = 'CAN', StatusRegistro = 0 WHERE FacturaID = " & FacturaID & ""
                .CommandText &= ";UPDATE FacturaCorrida SET StatusRegistro = 0 WHERE FacturaID = " & FacturaID & ""
                .CommandText &= ";UPDATE FacturasFormasPago SET StatusRegistro = 0 WHERE FacturaID = " & FacturaID & ""
                .CommandType = CommandType.Text

            End With

            sccnnConnection.Open()

            Try

                If strFIDOCUMENT = "" AndAlso strSALESDOCUMENT = "" Then
                    SaveSAP(strFolioSAP, strSALESDOCUMENT, strFIDOCUMENT, CodVendedor, CodAlmacen, True, FolioFISAP)
                End If

                With sccmdUpdateFactura
                    .CommandText &= ";UPDATE Factura SET FCFolioSAP = '" & strSALESDOCUMENT & "', FCFolioFISap = '" & strFIDOCUMENT & "' WHERE FacturaID = " & FacturaID & ""
                End With

            Catch ex As Exception
                Throw New ApplicationException("Por el momento no puede cancelar Facturas DPortenis Vale." & ex.ToString)
            End Try

            sccmdUpdateFactura.ExecuteNonQuery()
            sccnnConnection.Close()

        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                sccnnConnection.Close()
            End If

            Throw New ApplicationException("El registro no pudo ser leido debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                sccnnConnection.Close()
            End If

            Throw New ApplicationException("El registro no pudo ser leido debido a un error de aplicación.", ex)

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

    End Sub

    Friend Sub UpdateStatusFacturaCierreDia(ByVal FacturaID As Integer, ByVal strFolioSAP As String, ByVal CodVendedor As String, ByVal CodAlmacen As String, Optional ByRef strFIDOC As String = "", Optional ByRef strSALESDOC As String = "")

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdUpdateFactura As SqlCommand = New SqlCommand

        Try

            With sccmdUpdateFactura

                .Connection = sccnnConnection
                .CommandType = CommandType.Text

            End With

            sccnnConnection.Open()

            Try
                Dim strFIDOCUMENT, strSALESDOCUMENT As String

                'SaveSAP(strFolioSAP, strSALESDOCUMENT, strFIDOCUMENT, CodVendedor, CodAlmacen, False)

                With sccmdUpdateFactura
                    .CommandText &= "UPDATE Factura SET FCFolioSAP = '" & strSALESDOCUMENT & "', FCFolioFISap = '" & strFIDOCUMENT & "' WHERE FacturaID = " & FacturaID & ""
                End With

                strFIDOC = strFIDOCUMENT
                strSALESDOC = strSALESDOCUMENT

            Catch ex As Exception
                Exit Sub
            End Try

            sccmdUpdateFactura.ExecuteNonQuery()
            sccnnConnection.Close()

        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                sccnnConnection.Close()
            End If

            Throw New ApplicationException("El registro no pudo ser leido debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                sccnnConnection.Close()
            End If

            Throw New ApplicationException("El registro no pudo ser leido debido a un error de aplicación.", ex)

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

    End Sub


    Friend Sub UpdateStatusFacturaCierreDiaRetail(ByVal FacturaID As Integer, ByVal strFolioSAP As String, ByVal CodVendedor As String, ByVal CodAlmacen As String, Optional ByRef strFIDOC As String = "", Optional ByRef strSALESDOC As String = "")

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdUpdateFactura As SqlCommand = New SqlCommand

        Try

            With sccmdUpdateFactura

                .Connection = sccnnConnection
                .CommandType = CommandType.Text

            End With

            sccnnConnection.Open()

            Try
                Dim strFIDOCUMENT, strSALESDOCUMENT As String

                'SaveSAP(strFolioSAP, strSALESDOCUMENT, strFIDOCUMENT, CodVendedor, CodAlmacen, False)

                With sccmdUpdateFactura
                    .CommandText &= "UPDATE Factura SET FCFolioSAP = '" & strSALESDOCUMENT & "', FCFolioFISap = '" & strFIDOCUMENT & "' WHERE FacturaID = " & FacturaID & ""
                End With

                strFIDOC = strFIDOCUMENT
                strSALESDOC = strSALESDOCUMENT

            Catch ex As Exception
                Exit Sub
            End Try

            sccmdUpdateFactura.ExecuteNonQuery()
            sccnnConnection.Close()

        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                sccnnConnection.Close()
            End If

            Throw New ApplicationException("El registro no pudo ser leido debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                sccnnConnection.Close()
            End If

            Throw New ApplicationException("El registro no pudo ser leido debido a un error de aplicación.", ex)

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

    End Sub

    Friend Sub UpdateStatusValeCaja(ByVal FacturaID As Integer)

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdUpdateValeCaja As SqlCommand = New SqlCommand

        With sccmdUpdateValeCaja

            .Connection = sccnnConnection

            .CommandText = "[ValeCajaCancelar]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FacturaID", System.Data.SqlDbType.Int))

        End With

        Try

            sccnnConnection.Open()

            With sccmdUpdateValeCaja

                'Assign Parameters Values
                .Parameters("@FacturaID").Value = FacturaID

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

    Friend Sub UpdateStatusValeCajaSH(ByVal PedidoID As Integer)

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdUpdateValeCaja As SqlCommand = New SqlCommand

        With sccmdUpdateValeCaja

            .Connection = sccnnConnection

            .CommandText = "[ValeCajaCancelarSH]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@PedidoID", System.Data.SqlDbType.Int))

        End With

        Try

            sccnnConnection.Open()

            With sccmdUpdateValeCaja

                'Assign Parameters Values
                .Parameters("@PedidoID").Value = PedidoID

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


    Public Function FacturasDelDia(ByVal strNoCaja As String, ByVal strAlmacen As String, ByVal FechaCierre As Date) As DataSet

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim sqlAdapter As SqlDataAdapter
        Dim dsFacturas As New DataSet

        Dim decFondoCaja As Decimal


        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[FacturasByDateCancel]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar))


        End With


        Try

            sccnnConnection.Open()
            sqlAdapter = New SqlDataAdapter(sccmdSelect)
            With sccmdSelect

                'Assign Parameters Values
                .Parameters("@CodCaja").Value = strNoCaja
                .Parameters("@Fecha").Value = Format(FechaCierre, "Short Date")
                .Parameters("@CodAlmacen").Value = strAlmacen

                'Execute Command
                sqlAdapter.Fill(dsFacturas, "Facturas")

                'Assign Other Values


                Return dsFacturas

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

    Public Function FacturaDPvaleIdSel(ByVal FacturaID As Integer) As String

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[FacturaDpValeIDSel]"
            .CommandType = System.Data.CommandType.StoredProcedure

            '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioFactura", System.Data.SqlDbType.Int, 4))
            .Parameters("@FolioFactura").Value = FacturaID

        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect

                'Ejecutamos Comando
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Asignamos Valores al Reader
                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    With scdrReader

                        Return CStr(scdrReader("DPValeID"))

                    End With
                Else

                    Return ""

                End If

                scdrReader.Close()

            End With

            sccnnConnection.Close()

        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                sccnnConnection.Close()
            End If

            Throw New ApplicationException("El registro no pudo ser leido debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                sccnnConnection.Close()
            End If

            Throw New ApplicationException("El registro no pudo ser leido debido a un error de aplicación.", ex)

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

    End Function

#End Region

#Region "Procesos SAP"

    'Public Sub SaveSAP(ByVal strFolioSAP As String, ByRef strSALESDOCUMENT As String, ByRef strFIDOCUMENT As String, ByVal CodVendedor As String, ByVal CodAlmacen As String _
    '                    , ByVal bolDPVale As Boolean, Optional ByVal FolioFISAP As String = "")
    '    Try

    '        Dim objR3 As New SAPFunctionsOCX.SAPFunctions
    '        Dim objFunc As SAPFunctionsOCX.Function

    '        'Parametros Exports
    '        Dim CLASEPEDIDO As SAPFunctionsOCX.Parameter    '   Clase de documento de ventas
    '        Dim I_FACTURA As SAPFunctionsOCX.Parameter      '   FACTURA
    '        Dim I_AGENTE As SAPFunctionsOCX.Parameter       '   Grupo de vendedores
    '        Dim I_WERKS As SAPFunctionsOCX.Parameter        '   Centro
    '        'Fin Parametros Exports

    '        'Parametros Imports
    '        Dim FIDOCUMENT As SAPFunctionsOCX.Parameter     '   Número de un Documento Contable
    '        Dim SALESDOCUMENT As SAPFunctionsOCX.Parameter  '   Documento de ventas
    '        'Dim I_FECHAFACT As SAPFunctionsOCX.Parameter    '   Fecha Movimiento

    '        'Fin parametros Imports

    '        'Tablas
    '        Dim oRETURN As Object
    '        Dim MESSTAB As Object
    '        'Fin Tablas

    '        With objR3.Connection
    '            .ApplicationServer = oParent.SAPApplicationConfig.ApplicationServer
    '            .GroupName = oParent.SAPApplicationConfig.GroupName
    '            .System = oParent.SAPApplicationConfig.System
    '            .Client = oParent.SAPApplicationConfig.Client
    '            .User = oParent.SAPApplicationConfig.User
    '            .Password = oParent.SAPApplicationConfig.Password
    '            .language = oParent.SAPApplicationConfig.Language
    '            .SystemNumber = oParent.SAPApplicationConfig.System
    '        End With

    '        If objR3.Connection.logon(0, True) <> True Then
    '            Throw New ApplicationException("No se pudo establecer la conexión con SAP.")
    '        End If

    '        If oParent.SAPApplicationConfig.DPValeSAP And bolDPVale Then

    '            If oParent.SaveConfigArchivos.MiniPrinter = True Then
    '                objFunc = objR3.Add("ZBAPISD29_CANCELACION_DPVL_AUT")
    '            Else
    '                objFunc = objR3.Add("ZBAPISD29_CANCELACION_DPVL")
    '            End If

    '        Else

    '            If oParent.SaveConfigArchivos.MiniPrinter = True Then
    '                objFunc = objR3.Add("ZBAPISD29_CANCELACIONFACT_AUTO")
    '            Else
    '                objFunc = objR3.Add("ZBAPISD29_CANCELACIONFACT")
    '            End If


    '        End If

    '        'Exports
    '        I_FACTURA = objFunc.Exports("I_FACTURA")
    '        CLASEPEDIDO = objFunc.Exports("CLASEPEDIDO")
    '        I_AGENTE = objFunc.Exports("I_AGENTE")
    '        I_WERKS = objFunc.Exports("I_WERKS")
    '        'Fin Exports

    '        'Tablas
    '        oRETURN = objFunc.Tables("RETURN")
    '        MESSTAB = objFunc.Tables("MESSTAB")
    '        'Fin Tablas

    '        'Imports
    '        SALESDOCUMENT = objFunc.Imports("SALESDOCUMENT")
    '        FIDOCUMENT = objFunc.Imports("FIDOCUMENT")
    '        'Fin Imports

    '        'Captura de Info

    '        CLASEPEDIDO.Value = "Z" & Mid(oParent.ApplicationContext.ApplicationConfiguration.Almacen, 2, 2) & "2"

    '        I_FACTURA.Value = strFolioSAP
    '        I_AGENTE.Value = CodVendedor

    '        If CodAlmacen = "053" Then
    '            'Cambio_053
    '            'I_WERKS.Value = "C053"
    '            I_WERKS.Value = "T053"
    '        Else
    '            I_WERKS.Value = "T" & CodAlmacen
    '        End If

    '        '----------------------------------------------------------------------------------------------
    '        ' JNAVA (07.11.2014): Validamos si es factura del si hay para enviar parametro correspondiente
    '        '----------------------------------------------------------------------------------------------
    '        If oParent.SAPApplicationConfig.DPValeSAP And bolDPVale Then
    '            If oParent.SaveConfigArchivos.MiniPrinter = True Then
    '                If FolioFISAP <> "" Then
    '                    Dim I_FACT_SH As SAPFunctionsOCX.Parameter      '   Factura FISAP (Para Facturas del Si HAY)
    '                    I_FACT_SH = objFunc.Exports("I_FACT_SH") 'EXPORT
    '                    I_FACT_SH.Value = FolioFISAP
    '                End If
    '            End If
    '        End If
    '        '----------------------------------------------------------------------------------------------

    '        'I_FECHAFACT.Value = Format(Date.Now.Date, "dd/MM/yyyy")

    '        objFunc.Call()


    '        If FIDOCUMENT.Value = String.Empty OrElse SALESDOCUMENT.Value = String.Empty OrElse FIDOCUMENT.Value = 0 OrElse SALESDOCUMENT.Value = 0 Then

    '            If oParent.SAPApplicationConfig.DPValeSAP AndAlso oParent.SaveConfigArchivos.MiniPrinter = True Then
    '                Dim iRen As Integer
    '                Dim strError As String
    '                strError = String.Empty
    '                For iRen = 1 To oRETURN.ROWCOUNT
    '                    strError = strError & Microsoft.VisualBasic.vbCrLf & CStr(oRETURN(iRen, "message"))
    '                Next iRen

    '                MsgBox(strError, MsgBoxStyle.Information, "Error")
    '            End If


    '            Throw New ApplicationException("Error al Procesar Cancelación en SAP")

    '        End If

    '        objR3.Connection.LogOff()
    '        strSALESDOCUMENT = CStr(SALESDOCUMENT.Value())
    '        strFIDOCUMENT = CStr(FIDOCUMENT.Value())

    '    Catch ex As Exception
    '        Throw ex
    '    End Try

    'End Sub

    Public Sub SaveSAP(ByVal strFolioSAP As String, ByRef strSALESDOCUMENT As String, ByRef strFIDOCUMENT As String, ByVal CodVendedor As String, ByVal CodAlmacen As String _
                     , ByVal bolDPVale As Boolean, Optional ByVal FolioFISAP As String = "")

        '----------------------------------------------------------------------------------
        ' JNAVA (04.01.2016): Cambio de libreria para compatibilidad con SAP 6.0
        '----------------------------------------------------------------------------------
        Dim dtReturn As New DataTable
        Dim dtMessTab As New DataTable
        Try
            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)

            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Sub
            Else

                '*****************************************************
                'Call RFC function  ZSH_COMPENSAR
                '*****************************************************
                Dim func As ERPConnect.RFCFunction
                If oParent.SAPApplicationConfig.DPValeSAP And bolDPVale Then
                    If oParent.SaveConfigArchivos.MiniPrinter = True Then
                        func = R3.CreateFunction("ZBAPISD29_CANCELACION_DPVL_AUT")
                    Else
                        func = R3.CreateFunction("ZBAPISD29_CANCELACION_DPVL")
                    End If
                Else
                    If oParent.SaveConfigArchivos.MiniPrinter = True Then
                        func = R3.CreateFunction("ZBAPISD29_CANCELACIONFACT_AUTO")
                    Else
                        func = R3.CreateFunction("ZBAPISD29_CANCELACIONFACT")
                    End If
                End If


                'Asigno valores
                func.Exports("CLASEPEDIDO").ParamValue = "Z" & Mid(oParent.ApplicationContext.ApplicationConfiguration.Almacen, 2, 2) & "2"

                func.Exports("I_FACTURA").ParamValue = strFolioSAP
                func.Exports("I_AGENTE").ParamValue = CodVendedor

                If CodAlmacen = "053" Then
                    'Cambio_053
                    'I_WERKS.Value = "C053"
                    func.Exports("I_WERKS").ParamValue = "T053"
                Else
                    func.Exports("I_WERKS").ParamValue = "T" & CodAlmacen
                End If

                '----------------------------------------------------------------------------------------------
                ' JNAVA (07.11.2014): Validamos si es factura del si hay para enviar parametro correspondiente
                '----------------------------------------------------------------------------------------------
                If oParent.SAPApplicationConfig.DPValeSAP And bolDPVale Then
                    If oParent.SaveConfigArchivos.MiniPrinter = True Then
                        If FolioFISAP <> "" Then
                            func.Exports("I_FACT_SH").ParamValue = FolioFISAP
                        End If
                    End If
                End If
                '----------------------------------------------------------------------------------------------

                'I_FECHAFACT.Value = Format(Date.Now.Date, "dd/MM/yyyy")

                'Ejecutamos la RFC
                func.Execute()

                'Obtenemos infomación
                dtReturn = func.Tables("RETURN").ToADOTable()
                dtMessTab = func.Tables("MESSTAB").ToADOTable()

                If func.Imports("FIDOCUMENT").ParamValue = String.Empty OrElse func.Imports("SALESDOCUMENT").ParamValue = String.Empty OrElse func.Imports("FIDOCUMENT").ParamValue = 0 OrElse func.Imports("SALESDOCUMENT").ParamValue = 0 Then

                    If oParent.SAPApplicationConfig.DPValeSAP AndAlso oParent.SaveConfigArchivos.MiniPrinter = True Then
                        Dim strError As String
                        strError = String.Empty

                        For Each row As DataRow In dtReturn.Rows
                            strError = strError & Microsoft.VisualBasic.vbCrLf & CStr(row("MESSAGE")) & vbCrLf
                        Next

                        MsgBox(strError, MsgBoxStyle.Information, "Error")
                    End If

                    Throw New ApplicationException("Error al Procesar Cancelación en SAP")

                End If

                R3.Close()

                strSALESDOCUMENT = CStr(func.Imports("SALESDOCUMENT").ParamValue)
                strFIDOCUMENT = CStr(func.Imports("FIDOCUMENT").ParamValue)

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

    End Sub

    Public Function GetDPvaleInfoSap(ByVal strDPVAleID As String) As cDPVale

        oDPVale = New cDPVale
        oDPVale.I_RUTA = "X"
        oDPVale.INUMVA = strDPVAleID

        oSAPMgr = New ProcesoSAPManager(oParent.ApplicationContext, oParent.SAPApplicationConfig)

        Return oSAPMgr.ZBAPI_VALIDA_DPVALE(oDPVale)

    End Function

    Public Function GetNombreClienteSAP(ByVal strCLiente As String) As String

        oSAPMgr = New ProcesoSAPManager(oParent.ApplicationContext, oParent.SAPApplicationConfig)

        Return oSAPMgr.ZBAPI_NOMBRE_CLIENTE(strCLiente)

    End Function

#End Region

End Class
