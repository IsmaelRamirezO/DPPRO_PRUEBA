Imports System
Imports System.Data
Imports System.data.SqlClient
Imports DportenisPro.DPTienda.Core
Imports DportenisPro.DPTienda.ApplicationUnits.Facturas
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoBancosAU

Friend Class FacturaFormaPagoDataGateway

    Private oParent As FacturaFormaPago

#Region "Constructors / Destructors"

    Public Sub New(ByVal Parent As FacturaFormaPago)

        oParent = Parent

    End Sub

#End Region


#Region "Methods"

    Public Sub Insert(ByVal Data As FacturaFormaPago)

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString)

        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand
        Dim oFacturaMgr As FacturaManager
        Dim oBancoMgr As CatalogoBancosManager
        Dim oBanco As Bancos

        With sccmdInsert

            .Connection = sccnnConnection

            .CommandText = "[FacturasFormasPagoIns]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FacturaID", System.Data.SqlDbType.Int, 4, "FacturaID"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@DPValeID", System.Data.SqlDbType.VarChar, 10, "DPValeID"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodFormasPago", System.Data.SqlDbType.VarChar, 4, "CodFormasPago"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodBanco", System.Data.SqlDbType.VarChar, 4, "CodBanco"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodTipoTarjeta", System.Data.SqlDbType.VarChar, 2, "CodTipoTarjeta"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@NumeroTarjeta", System.Data.SqlDbType.VarChar, 20, "NumeroTarjeta"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@NumeroAutorizacion", System.Data.SqlDbType.VarChar, 20, "NumeroAutorizacion"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@NotaCreditoID", System.Data.SqlDbType.Int, 4, "NotaCreditoID"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ComisionBancaria", System.Data.SqlDbType.Money, 4, "ComisionBancaria"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@IngresoComision", System.Data.SqlDbType.Money, 4, "IngresoComision"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@IVAComision", System.Data.SqlDbType.Money, 4, "IVAComision"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@MontoPago", System.Data.SqlDbType.Money, 4, "MontoPago"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Usuario", System.Data.SqlDbType.VarChar, 12, "Usuario"))
            '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Output, False, CType(0, Byte), CType(0, Byte), "Fecha", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime, 8, "Fecha"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@StatusRegistro", System.Data.SqlDbType.Bit, 1, "StatusRegistro"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@NoAfiliacion", System.Data.SqlDbType.VarChar, 10, "Afiliacion"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Id_Num_Promo", System.Data.SqlDbType.SmallInt, 2, "Promocion"))

        End With

        Try

            sccnnConnection.Open()

            With sccmdInsert
                'Assign Parameters Values
                .Parameters("@FacturaID").Value = Data.FacturaID
                .Parameters("@DPValeID").Value = Data.DPValeID
                .Parameters("@CodFormasPago").Value = Data.FormaPagoID
                .Parameters("@CodBanco").Value = Data.BancoID
                .Parameters("@CodTipoTarjeta").Value = Data.TipoTarjetaID
                .Parameters("@NumeroTarjeta").Value = Data.NumeroTarjeta
                .Parameters("@NumeroAutorizacion").Value = Data.NumeroAutorización
                .Parameters("@NotaCreditoID").Value = Data.NotaCreditoID
                .Parameters("@ComisionBancaria").Value = Data.ComisionBancaria
                .Parameters("@IngresoComision").Value = Data.IngresoComision
                .Parameters("@IVAComision").Value = Data.IVAComision
                .Parameters("@MontoPago").Value = Data.Monto
                .Parameters("@Usuario").Value = oParent.ApplicationContext.Security.CurrentUser.Name
                '.Parameters("@Fecha").Value = Date.Today
                .Parameters("@Fecha").Value = Data.RecordCreatedOn
                .Parameters("@StatusRegistro").Value = 1
                '-------------------------------------------------------------------------------------------------------------------------------------
                ' JNAVA (27.02.2015): Se agrego validacion para que si es forma de pago de DPCA (DP CARD), no obtenga la informacion de la afiliacion y el banco
                '-------------------------------------------------------------------------------------------------------------------------------------
                '-------------------------------------------------------------------------------------------------------------------------------------
                'FLIZARRAGA 24/04/2015: Se agreso a la validacion del comentario anterior la forma de pago DPPT
                '-------------------------------------------------------------------------------------------------------------------------------------
                If Data.NoAfiliacion.Trim = "" AndAlso Data.TipoTarjetaID.Trim.ToUpper = "TE" AndAlso Data.FormaPagoID <> "DPCA" AndAlso Data.FormaPagoID <> "DPPT" Then
                    oFacturaMgr = New FacturaManager(oParent.ApplicationContext)
                    oBancoMgr = New CatalogoBancosManager(oParent.ApplicationContext)
                    Dim dvBanco As New DataView(oBancoMgr.GetAll(True).Tables(0), "CodBanco = '" & Data.BancoID & "'", "CodBanco", DataViewRowState.CurrentRows)
                    Data.NoAfiliacion = oFacturaMgr.GetAfiliacion(Data.Promocion, dvBanco(0)!IDEmisor)
                End If
                .Parameters("@NoAfiliacion").Value = Data.NoAfiliacion
                .Parameters("@Id_Num_Promo").Value = Data.Promocion

                'Execute Command
                .ExecuteNonQuery()

            End With

            sccnnConnection.Close()

        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                    'EliminarFactura(Data.FacturaID)
                Catch
                End Try
            End If

            EscribeLog(oSqlException.ToString, "Error al intentar insertar las formas de pago", oSqlException)

            Throw New ApplicationException("El registro no pudo ser insertado debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                    'EliminarFactura(Data.FacturaID)
                Catch
                End Try
            End If

            EscribeLog(ex.ToString, "Error al intentar insertar las formas de pago", ex)

            Throw New ApplicationException("El registro no pudo ser insertado debido a un error de aplicación.", ex)

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

    End Sub

    Public Function EliminarFactura(ByVal FacturaID As Integer) As Boolean
        Dim valid As Boolean = False
        Dim conexion As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString)
        Dim command As New SqlCommand("EliminarOperacionFactura", conexion)
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@FacturaID", FacturaID)
            command.ExecuteNonQuery()
            valid = True
        Catch sql As SqlException
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If

            EscribeLog(sql.Message, "Error al intentar eliminar la Factura", sql)
            Throw New ApplicationException("Hubo un error en la base de datos", sql)
        Catch ex As Exception
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            EscribeLog(ex.Message, "Error al intentar eliminar la Factura", ex)
            Throw New ApplicationException("Hubo un error en la aplicación", ex)
        End Try
        Return valid
    End Function

    Public Sub EscribeLog(ByVal strError As String, ByVal Titulo As String, Optional ByVal ex As Exception = Nothing)

        Dim StreamW As New System.IO.StreamWriter(Environment.CurrentDirectory & "\ErrorLogFile.txt", True)

        StreamW.WriteLine(Now.ToString & " --> " & Titulo.ToUpper & vbCrLf)

        If Not ex Is Nothing Then
            Dim stack As New StackTrace(ex, True)
            Dim strLinea As String = stack.GetFrame(stack.FrameCount - 1).GetFileLineNumber
            Dim method As String = stack.GetFrame(stack.FrameCount - 1).GetMethod.Name
            Dim column As String = stack.GetFrame(stack.FrameCount - 1).GetFileColumnNumber
            StreamW.WriteLine("Metodo -->" & method)
            StreamW.WriteLine("Linea --> " & strLinea)
            StreamW.WriteLine("Columna -->" & column)
            StreamW.WriteLine("Detalle --> " & ex.ToString.Trim)
        Else
            StreamW.WriteLine("Detalle --> " & strError.Trim)
        End If
        StreamW.WriteLine("".PadLeft(250, "-"))
        StreamW.Close()

    End Sub

    Public Function SelectAll(ByVal FacturaID As Integer) As DataSet

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaFormasPago As SqlDataAdapter
        Dim dsFormasPago As DataSet

        sccmdSelectAll = New SqlCommand
        scdaFormasPago = New SqlDataAdapter
        dsFormasPago = New DataSet

        With sccmdSelectAll

            .Connection = sccnnConnection

            .CommandText = "[FacturasFormasPagoRPTSel]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FacturaID", System.Data.SqlDbType.Int))

        End With

        scdaFormasPago.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            scdaFormasPago.SelectCommand.Parameters("@FacturaID").Value = FacturaID

            'Fill DataSet
            scdaFormasPago.Fill(dsFormasPago, "FacturasFormasPago")

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

        Return dsFormasPago


    End Function

    Public Function SelectAllReport(ByVal FacturaID As Integer) As DataSet

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaFormasPago As SqlDataAdapter
        Dim dsFormasPago As DataSet

        sccmdSelectAll = New SqlCommand
        scdaFormasPago = New SqlDataAdapter
        dsFormasPago = New DataSet

        With sccmdSelectAll

            .Connection = sccnnConnection

            .CommandText = "[FacturasFormasPagoRPTCierreSel]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FacturaID", System.Data.SqlDbType.Int))

        End With

        scdaFormasPago.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            scdaFormasPago.SelectCommand.Parameters("@FacturaID").Value = FacturaID

            'Fill DataSet
            scdaFormasPago.Fill(dsFormasPago, "FacturasFormasPago")

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

        Return dsFormasPago


    End Function

    Public Sub Update(ByVal Data As FacturaFormaPago)
        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString)

        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand

        With sccmdInsert

            .Connection = sccnnConnection

            .CommandText = "[FacturasFormasPagoUpdTE]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FormaPagoID", System.Data.SqlDbType.Int, 4, "FormaPagoID"))
            '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@FacturaID", System.Data.SqlDbType.Int, 4, "FacturaID"))
            '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@DPValeID", System.Data.SqlDbType.Int, 4, "DPValeID"))
            '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodFormasPago", System.Data.SqlDbType.VarChar, 4, "CodFormasPago"))
            '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodBanco", System.Data.SqlDbType.VarChar, 4, "CodBanco"))
            '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodTipoTarjeta", System.Data.SqlDbType.VarChar, 2, "CodTipoTarjeta"))
            '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NumeroTarjeta", System.Data.SqlDbType.VarChar, 20, "NumeroTarjeta"))
            '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NumeroAutorizacion", System.Data.SqlDbType.VarChar, 20, "NumeroAutorizacion"))
            '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NotaCreditoID", System.Data.SqlDbType.Int, 4, "NotaCreditoID"))
            '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@ComisionBancaria", System.Data.SqlDbType.Money, 4, "ComisionBancaria"))
            '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@IngresoComision", System.Data.SqlDbType.Money, 4, "IngresoComision"))
            '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@IVAComision", System.Data.SqlDbType.Money, 4, "IVAComision"))
            '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@MontoPago", System.Data.SqlDbType.Money, 4, "MontoPago"))
            '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Usuario", System.Data.SqlDbType.VarChar, 12, "Usuario"))
            '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Output, False, CType(0, Byte), CType(0, Byte), "Fecha", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@StatusRegistro", System.Data.SqlDbType.Bit, 1, "StatusRegistro"))

        End With

        Try

            sccnnConnection.Open()

            With sccmdInsert
                'Assign Parameters Values
                .Parameters("@FormaPagoID").Value = Data.FacturaFormaPagoID
                '.Parameters("@FacturaID").Value = Data.FacturaID
                '.Parameters("@DPValeID").Value = Data.DPValeID
                '.Parameters("@CodFormasPago").Value = Data.FormaPagoID
                '.Parameters("@CodBanco").Value = Data.BancoID
                '.Parameters("@CodTipoTarjeta").Value = Data.TipoTarjetaID
                '.Parameters("@NumeroTarjeta").Value = Data.NumeroTarjeta
                '.Parameters("@NumeroAutorizacion").Value = Data.NumeroAutorización
                '.Parameters("@NotaCreditoID").Value = Data.NotaCreditoID
                '.Parameters("@ComisionBancaria").Value = Data.ComisionBancaria
                '.Parameters("@IngresoComision").Value = Data.IngresoComision
                '.Parameters("@IVAComision").Value = Data.IVAComision
                '.Parameters("@MontoPago").Value = Data.Monto
                '.Parameters("@Usuario").Value = oParent.ApplicationContext.Security.CurrentUser.Name
                '.Parameters("@Fecha").Value = Date.Today
                .Parameters("@StatusRegistro").Value = Data.RecordStatus

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

    Public Sub Delete(ByVal ID As String)

    End Sub

    Public Function [Select](ByVal ID As String, Optional ByVal Data As FacturaFormaPago = Nothing) As FacturaFormaPago

    End Function

    Public Function [Select](ByVal EnabledRecordsOnly As Boolean) As DataSet

    End Function

#End Region

#Region "Facturacion SiHay"

    '--------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 29/04/2013: Selecciona todas las formas de pago mediante el PedidoID
    '--------------------------------------------------------------------------------------------------------------------------------

    Public Function SelectAllByPedidoID(ByVal PedidoID As Integer) As DataSet

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaFormasPago As SqlDataAdapter
        Dim dsFormasPago As DataSet

        sccmdSelectAll = New SqlCommand
        scdaFormasPago = New SqlDataAdapter
        dsFormasPago = New DataSet

        With sccmdSelectAll

            .Connection = sccnnConnection

            .CommandText = "[PedidoFormasPago]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@PedidoID", System.Data.SqlDbType.Int))

        End With

        scdaFormasPago.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            scdaFormasPago.SelectCommand.Parameters("@PedidoID").Value = PedidoID

            'Fill DataSet
            scdaFormasPago.Fill(dsFormasPago, "FacturasFormasPago")

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

        Return dsFormasPago


    End Function

    Public Function SelectAllReportByPedidoID(ByVal PedidoID As Integer) As DataSet

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaFormasPago As SqlDataAdapter
        Dim dsFormasPago As DataSet

        sccmdSelectAll = New SqlCommand
        scdaFormasPago = New SqlDataAdapter
        dsFormasPago = New DataSet

        With sccmdSelectAll

            .Connection = sccnnConnection

            .CommandText = "[FacturasFormasPagoPedidoRptCierreSel]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@PedidoID", System.Data.SqlDbType.Int))

        End With

        scdaFormasPago.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            scdaFormasPago.SelectCommand.Parameters("@PedidoID").Value = PedidoID

            'Fill DataSet
            scdaFormasPago.Fill(dsFormasPago, "FacturasFormasPago")

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

        Return dsFormasPago


    End Function

    '---------------------------------------------------------------------------------------------
    'FLIZARRAGA 25/09/2014: Se seleccionan los pedidos facturados y los no facturados
    '---------------------------------------------------------------------------------------------

    Public Function SelectPedidosFacturadosByPedidoID(ByVal PedidoID As Integer) As DataSet
        Dim conexion As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)
        Dim command As New SqlCommand("SelectPedidosFacturadosByPedidoID", conexion)
        Dim adapter As SqlDataAdapter
        Dim datos As New DataSet
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@PedidoID", PedidoID)
            adapter = New SqlDataAdapter(command)
            adapter.Fill(datos, "FacturasFormasPago")
            command.Dispose()
            conexion.Close()
        Catch sql As SqlException
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            Throw New ApplicationException("Los registros no pudieron ser leidos debido a un error de SQL", sql)
        Catch ex As SqlException
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            Throw New ApplicationException("Los registros no pudieron ser leidos debido a un error en la aplicación", ex)
        End Try
        Return datos
    End Function

    Public Function SelectPedidosNoFacturadosByPedidoID(ByVal PedidoID As Integer) As DataSet
        Dim conexion As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)
        Dim command As New SqlCommand("SelectPedidosNoFacturadosByPedidoID", conexion)
        Dim adapter As SqlDataAdapter
        Dim datos As New DataSet
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@PedidoID", PedidoID)
            adapter = New SqlDataAdapter(command)
            adapter.Fill(datos, "FacturasFormasPago")
            command.Dispose()
            conexion.Close()
        Catch sql As SqlException
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            Throw New ApplicationException("Los registros no pudieron ser leidos debido a un error en SQL", sql)
        Catch ex As Exception
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            Throw New ApplicationException("Los registros no pudieron ser leidos debido a un error en la aplicación", ex)
        End Try
        Return datos
    End Function

    Public Function SelectFormasPagosEcommerce(ByVal OtrosPagosID As Integer) As DataSet
        Dim conexion As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)
        Dim command As New SqlCommand("GetFormasPagoEcommerce", conexion)
        Dim adapter As SqlDataAdapter
        Dim datos As New DataSet
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@OtrosPagosID", OtrosPagosID)
            adapter = New SqlDataAdapter(command)
            adapter.Fill(datos, "FacturasFormasPago")
            command.Dispose()
            conexion.Close()
        Catch sql As SqlException
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            Throw New ApplicationException("Hubo un error al obtener las formas de pago", sql)
        Catch ex As Exception
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            Throw New ApplicationException("Hubo un error en la aplicación", ex)
        End Try
        Return datos
    End Function

    Public Sub InsertFormaPagoPedidoSH(ByVal Data As FacturaFormaPago)

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString)

        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand
        Dim oFacturaMgr As FacturaManager
        Dim oBancoMgr As CatalogoBancosManager
        Dim oBanco As Bancos

        With sccmdInsert

            .Connection = sccnnConnection

            .CommandText = "[FacturasFormasPagoPedidoIns]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FacturaID", System.Data.SqlDbType.Int, 4, "FacturaID"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@PedidoID", System.Data.SqlDbType.Int, 4, "PedidoID"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@DPValeID", System.Data.SqlDbType.VarChar, 10, "DPValeID"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodFormasPago", System.Data.SqlDbType.VarChar, 4, "CodFormasPago"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodBanco", System.Data.SqlDbType.VarChar, 4, "CodBanco"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodTipoTarjeta", System.Data.SqlDbType.VarChar, 2, "CodTipoTarjeta"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@NumeroTarjeta", System.Data.SqlDbType.VarChar, 20, "NumeroTarjeta"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@NumeroAutorizacion", System.Data.SqlDbType.VarChar, 20, "NumeroAutorizacion"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@NotaCreditoID", System.Data.SqlDbType.Int, 4, "NotaCreditoID"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ComisionBancaria", System.Data.SqlDbType.Money, 4, "ComisionBancaria"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@IngresoComision", System.Data.SqlDbType.Money, 4, "IngresoComision"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@IVAComision", System.Data.SqlDbType.Money, 4, "IVAComision"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@MontoPago", System.Data.SqlDbType.Money, 4, "MontoPago"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Usuario", System.Data.SqlDbType.VarChar, 12, "Usuario"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Output, False, CType(0, Byte), CType(0, Byte), "Fecha", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@StatusRegistro", System.Data.SqlDbType.Bit, 1, "StatusRegistro"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@NoAfiliacion", System.Data.SqlDbType.VarChar, 10, "Afiliacion"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Id_Num_Promo", System.Data.SqlDbType.SmallInt, 2, "Promocion"))

        End With

        Try

            sccnnConnection.Open()

            With sccmdInsert
                'Assign Parameters Values
                .Parameters("@FacturaID").Value = Data.FacturaID
                .Parameters("@PedidoID").Value = Data.PedidoID
                .Parameters("@DPValeID").Value = Data.DPValeID
                .Parameters("@CodFormasPago").Value = Data.FormaPagoID
                .Parameters("@CodBanco").Value = Data.BancoID
                .Parameters("@CodTipoTarjeta").Value = Data.TipoTarjetaID
                .Parameters("@NumeroTarjeta").Value = Data.NumeroTarjeta
                .Parameters("@NumeroAutorizacion").Value = Data.NumeroAutorización
                .Parameters("@NotaCreditoID").Value = Data.NotaCreditoID
                .Parameters("@ComisionBancaria").Value = Data.ComisionBancaria
                .Parameters("@IngresoComision").Value = Data.IngresoComision
                .Parameters("@IVAComision").Value = Data.IVAComision
                .Parameters("@MontoPago").Value = Data.Monto
                .Parameters("@Usuario").Value = oParent.ApplicationContext.Security.CurrentUser.Name
                .Parameters("@Fecha").Value = Date.Today
                .Parameters("@StatusRegistro").Value = 1
                '-------------------------------------------------------------------------------------------------------------------------------------
                ' JNAVA (27.02.2015): Se agrego validacion para que si es forma de pago de DPCA (DP CARD), no obtenga la informacion de la afiliacion y el banco
                '-------------------------------------------------------------------------------------------------------------------------------------
                If Data.NoAfiliacion.Trim = "" AndAlso Data.TipoTarjetaID.Trim.ToUpper = "TE" AndAlso Data.FormaPagoID <> "DPCA" Then
                    oFacturaMgr = New FacturaManager(oParent.ApplicationContext)
                    oBancoMgr = New CatalogoBancosManager(oParent.ApplicationContext)
                    Dim dvBanco As New DataView(oBancoMgr.GetAll(True).Tables(0), "CodBanco = '" & Data.BancoID & "'", "CodBanco", DataViewRowState.CurrentRows)
                    Data.NoAfiliacion = oFacturaMgr.GetAfiliacion(Data.Promocion, dvBanco(0)!IDEmisor)
                End If
                .Parameters("@NoAfiliacion").Value = Data.NoAfiliacion
                .Parameters("@Id_Num_Promo").Value = Data.Promocion

                'Execute Command
                .ExecuteNonQuery()

            End With

            sccnnConnection.Close()

        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                    EliminarFactura(Data.FacturaID)
                Catch
                End Try
            End If

            EscribeLog(oSqlException.ToString, "Error al intentar insertar las formas de pago", oSqlException)

            Throw New ApplicationException("El registro no pudo ser insertado debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                    EliminarFactura(Data.FacturaID)
                Catch
                End Try
            End If

            EscribeLog(ex.ToString, "Error al intentar insertar las formas de pago", ex)

            Throw New ApplicationException("El registro no pudo ser insertado debido a un error de aplicación.", ex)

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

    End Sub

#End Region

End Class
