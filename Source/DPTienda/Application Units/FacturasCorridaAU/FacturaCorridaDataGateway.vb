Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports DportenisPro.DPTienda.ApplicationUnits.Facturas

Public Class FacturaCorridaDataGateway

    Private oParent As FacturaCorridaManager
    Private m_strConnectionString As String

#Region "Constructors / Destructors"

    Public Sub New(ByVal Parent As FacturaCorridaManager)

        oParent = Parent

        m_strConnectionString = oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString

    End Sub

#End Region


#Region "Methods"

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

    Public Function EliminarFactura(ByVal FacturaID As Integer) As Boolean
        Dim valid As Boolean = False
        Dim conexion As New SqlConnection(m_strConnectionString)
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

    Public Function InsertCorrida(ByVal oFacturaCorrida As FacturaCorrida) As Boolean
        Dim valid As Boolean = False
        Dim sccnnConnection As New SqlConnection(m_strConnectionString)
        Dim ts As SqlTransaction = Nothing

        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand

        With sccmdInsert

            .Connection = sccnnConnection

            .CommandText = "[FacturaCorridaIns]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FacturaID", System.Data.SqlDbType.Int, 4, "FacturaID"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodArticulo", System.Data.SqlDbType.VarChar, 20, "CodArticulo"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Cantidad", System.Data.SqlDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(5, Byte), CType(1, Byte), "Cantidad", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Numero", System.Data.SqlDbType.VarChar, 4, "Numero"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CostoUnit", System.Data.SqlDbType.Money, 4, "CostoUnit"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@PrecioUnit", System.Data.SqlDbType.Money, 4, "PrecioUnit"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@PrecioOferta", System.Data.SqlDbType.Money, 4, "PrecioOferta"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Total", System.Data.SqlDbType.Money, 4, "Total"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodTipoDescuento", System.Data.SqlDbType.VarChar, 4, "CodTipoDescuento"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Descuento", System.Data.SqlDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(9, Byte), CType(2, Byte), "Descuento", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@DescuentoSistema", System.Data.SqlDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(9, Byte), CType(2, Byte), "DescuentoSistema", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CantDescuentoSistema", System.Data.SqlDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(9, Byte), CType(2, Byte), "CantDescuentoSistema", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@DIP", System.Data.SqlDbType.Bit, 1, "DIP"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Usuario", System.Data.SqlDbType.VarChar, 12, "Usuario"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime, 8, "Fecha"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@StatusRegistro", System.Data.SqlDbType.Bit, 1, "StatusRegistro"))
            '---------------------------------------------------------
            'JNAVA (05.12.2014): Datos de Venta de Electronicos
            '---------------------------------------------------------
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@NumeroSerie", System.Data.SqlDbType.VarChar, 255, "NumeroSerie"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@IMEI", System.Data.SqlDbType.VarChar, 255, "IMEI"))
        End With

        Try

            sccnnConnection.Open()
            ts = sccnnConnection.BeginTransaction()
            sccmdInsert.Transaction = ts

            With sccmdInsert
                'Assign Parameters Values
                .Parameters("@FacturaID").Value = oFacturaCorrida.FacturaID
                .Parameters("@CodArticulo").Value = oFacturaCorrida.CodArticulo
                .Parameters("@Cantidad").Value = oFacturaCorrida.Cantidad
                .Parameters("@Numero").Value = oFacturaCorrida.Numero
                .Parameters("@CostoUnit").Value = oFacturaCorrida.CostoUnitario
                .Parameters("@PrecioUnit").Value = oFacturaCorrida.PrecioUnitario
                .Parameters("@PrecioOferta").Value = oFacturaCorrida.PrecioOferta
                .Parameters("@Total").Value = oFacturaCorrida.Total
                .Parameters("@CodTipoDescuento").Value = oFacturaCorrida.CodTipoDescuento
                .Parameters("@Descuento").Value = oFacturaCorrida.Descuento
                .Parameters("@DescuentoSistema").Value = oFacturaCorrida.DescuentoSistema
                .Parameters("@CantDescuentoSistema").Value = oFacturaCorrida.CantDescuentoSistema
                .Parameters("@DIP").Value = oFacturaCorrida.Dip
                .Parameters("@Usuario").Value = oParent.ApplicationContext.Security.CurrentUser.SessionLoginName
                '.Parameters("@Fecha").Value = Date.Today
                .Parameters("@Fecha").Value = oFacturaCorrida.Fecha
                .Parameters("@StatusRegistro").Value = 1

                'Datos Electronicos
                .Parameters("@NumeroSerie").Value = oFacturaCorrida.NumeroSerie
                .Parameters("@IMEI").Value = oFacturaCorrida.IMEI

                'Execute Command
                .ExecuteNonQuery()

            End With

            ts.Commit()
            sccnnConnection.Close()
            valid = True

        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    ts.Rollback()
                    sccnnConnection.Close()
                    'EliminarFactura(oFacturaCorrida.FacturaID)
                Catch
                End Try
            End If

            EscribeLog(oSqlException.ToString, "Error al insertar un articulo en la corrida", oSqlException)

            Throw New ApplicationException("El registro no pudo ser insertado debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    ts.Rollback()
                    sccnnConnection.Close()
                    'EliminarFactura(oFacturaCorrida.FacturaID)
                Catch
                End Try
            End If

            EscribeLog(ex.ToString, "Error al insertar un articulo en la corrida", ex)

            Throw New ApplicationException("El registro no pudo ser insertado debido a un error de aplicación.", ex)

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing
        Return valid

    End Function

    Public Sub Delete(ByVal FacturaCorridaID As Integer)

    End Sub

    Public Function [SelectCorrida](ByVal FacturaID As Integer) As DataSet

        Dim oResult As DataSet
        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[FacturaCorridaDetalleSel]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FacturaID", System.Data.SqlDbType.Int, 4))
            .Parameters("@FacturaID").Value = FacturaID

        End With

        Dim oFacturaAdapter As SqlDataAdapter
        oFacturaAdapter = New SqlDataAdapter
        oFacturaAdapter.SelectCommand = sccmdSelect

        Try

            sccnnConnection.Open()

            oResult = New DataSet

            oFacturaAdapter.Fill(oResult, "FacturaDetalle")

        Catch ex As Exception

            Throw ex

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

        Return oResult

    End Function

    Public Function SelectDetalle(ByVal FacturaID As Integer, ByVal CodCaja As String) As DataSet

        Dim oResult As DataSet
        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[FacturaCorridaSel]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioFactura", System.Data.SqlDbType.Int, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar, 2))
            .Parameters("@FolioFactura").Value = FacturaID
            .Parameters("@CodCaja").Value = CodCaja

        End With

        Dim oFacturaAdapter As SqlDataAdapter
        oFacturaAdapter = New SqlDataAdapter
        oFacturaAdapter.SelectCommand = sccmdSelect

        Try

            sccnnConnection.Open()

            oResult = New DataSet

            oFacturaAdapter.Fill(oResult, "FacturaDetalle")

        Catch ex As Exception

            Throw ex

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

        Return oResult

    End Function


    Public Function SelectDetalleByPedido(ByVal FacturaID As Integer, ByVal PedidoID As Integer) As DataSet

        Dim oResult As DataSet
        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdSelect As SqlCommand
        ' Dim scdrReader As SqlDataReader

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[FacturaCorridaSelByPedidoID]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioFactura", System.Data.SqlDbType.Int, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@PedidoID", System.Data.SqlDbType.Int, 4))
            .Parameters("@FolioFactura").Value = FacturaID
            .Parameters("@PedidoID").Value = PedidoID

        End With

        Dim oFacturaAdapter As SqlDataAdapter
        oFacturaAdapter = New SqlDataAdapter
        oFacturaAdapter.SelectCommand = sccmdSelect

        Try

            sccnnConnection.Open()

            oResult = New DataSet

            oFacturaAdapter.Fill(oResult, "FacturaDetalle")

        Catch ex As Exception

            Throw ex

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

        Return oResult

    End Function


    Public Sub InsertaMovimiento(ByVal TotalFactura As Decimal, ByVal pFacturaCorrida As FacturaCorrida, ByVal TotalNc As Decimal, ByVal CostoNC As Decimal)

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand

        With sccmdInsert

            .Connection = sccnnConnection

            .CommandText = "[ExistenciasMovimientosIns]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodTipoMov", System.Data.SqlDbType.Int, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TipoMovimiento", System.Data.SqlDbType.VarChar, 1))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@StatusMov", System.Data.SqlDbType.VarChar, 1))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Destino", System.Data.SqlDbType.VarChar, 8))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Folio", System.Data.SqlDbType.Int, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodArticulo", System.Data.SqlDbType.VarChar, 20))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Descripcion", System.Data.SqlDbType.VarChar, 50))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Numero", System.Data.SqlDbType.VarChar, 4, "Numero"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Total", System.Data.SqlDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(10, Byte), CType(2, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Apartados", System.Data.SqlDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(10, Byte), CType(2, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Defectuosos", System.Data.SqlDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(10, Byte), CType(2, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Promocion", System.Data.SqlDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(10, Byte), CType(2, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@VtasEspeciales", System.Data.SqlDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(10, Byte), CType(2, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Consignacion", System.Data.SqlDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(10, Byte), CType(2, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Transito", System.Data.SqlDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(10, Byte), CType(2, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodLinea", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodMarca", System.Data.SqlDbType.VarChar, 2))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodFamilia", System.Data.SqlDbType.VarChar, 2))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodUnidad", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodUso", System.Data.SqlDbType.VarChar, 8))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCategoria", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Usuario", System.Data.SqlDbType.VarChar, 12))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CostoUnit", System.Data.SqlDbType.Money, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@PrecioUnit", System.Data.SqlDbType.Money, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioControl", System.Data.SqlDbType.VarChar, 7))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar, 2))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Descuento", System.Data.SqlDbType.Money, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TOTFGRAL", System.Data.SqlDbType.Money, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TOTNC", System.Data.SqlDbType.Money, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CostoNC", System.Data.SqlDbType.Money, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@VTA_DIP", System.Data.SqlDbType.VarChar, 1))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioSAP", System.Data.SqlDbType.VarChar, 10))

        End With

        Try

            sccnnConnection.Open()

            With sccmdInsert

                'Assign Parameters Values
                .Parameters("@CodTipoMov").Value = pFacturaCorrida.Movimiento.Mov_CodTipoMov
                .Parameters("@TipoMovimiento").Value = pFacturaCorrida.Movimiento.Mov_TipoMovimiento
                .Parameters("@StatusMov").Value = pFacturaCorrida.Movimiento.Mov_Status
                .Parameters("@CodAlmacen").Value = pFacturaCorrida.Movimiento.Mov_CodAlmacen
                .Parameters("@Destino").Value = pFacturaCorrida.Movimiento.Mov_Destino
                .Parameters("@Folio").Value = pFacturaCorrida.Movimiento.Mov_Folio
                .Parameters("@FolioSAP").Value = "0"
                .Parameters("@CodArticulo").Value = pFacturaCorrida.Movimiento.Mov_CodArticulo.PadLeft(18, "0")
                .Parameters("@Descripcion").Value = pFacturaCorrida.Movimiento.Mov_Descripcion
                .Parameters("@Numero").Value = pFacturaCorrida.Numero
                .Parameters("@Total").Value = pFacturaCorrida.Cantidad
                .Parameters("@Apartados").Value = pFacturaCorrida.Movimiento.Mov_Apartados
                .Parameters("@Defectuosos").Value = 0
                .Parameters("@Promocion").Value = 0
                .Parameters("@VtasEspeciales").Value = 0
                .Parameters("@Consignacion").Value = 0
                .Parameters("@Transito").Value = 0
                .Parameters("@CodLinea").Value = pFacturaCorrida.Movimiento.Mov_CodLinea
                .Parameters("@CodMarca").Value = pFacturaCorrida.Movimiento.Mov_CodMarca
                .Parameters("@CodFamilia").Value = pFacturaCorrida.Movimiento.Mov_CodFamilia
                .Parameters("@CodUso").Value = Format(pFacturaCorrida.Movimiento.Mov_CodUso, "00000000")
                .Parameters("@CodCategoria").Value = Format(pFacturaCorrida.Movimiento.Mov_CodCategoria, "000")
                .Parameters("@CodUnidad").Value = pFacturaCorrida.Movimiento.Mov_CodUnidad
                .Parameters("@Usuario").Value = oParent.ApplicationContext.Security.CurrentUser.Name
                .Parameters("@CostoUnit").Value = pFacturaCorrida.Movimiento.Mov_CostoUnit
                .Parameters("@PrecioUnit").Value = pFacturaCorrida.Movimiento.Mov_PrecioUnit
                .Parameters("@FolioControl").Value = "" 'Folio al Iniciar Dia.
                .Parameters("@CodCaja").Value = pFacturaCorrida.Movimiento.Mov_CodCaja
                .Parameters("@Descuento").Value = Decimal.Round((pFacturaCorrida.Total * _
                                                    (pFacturaCorrida.Descuento / 100)), 2) + pFacturaCorrida.CantDescuentoSistema
                .Parameters("@TOTFGRAL").Value = TotalFactura
                .Parameters("@TOTNC").Value = TotalNc * (((pFacturaCorrida.Cantidad * pFacturaCorrida.Movimiento.Mov_PrecioUnit) - (pFacturaCorrida.Total * (pFacturaCorrida.Descuento / 100))) / TotalFactura)
                .Parameters("@CostoNC").Value = CostoNC * (((pFacturaCorrida.Cantidad * pFacturaCorrida.Movimiento.Mov_PrecioUnit) - (pFacturaCorrida.Total * (pFacturaCorrida.Descuento / 100))) / TotalFactura)

                Dim oFacturaMgr As New Facturas.FacturaManager(oParent.ApplicationContext)
                Dim oFactura As Facturas.Factura

                oFactura = oFacturaMgr.Create
                oFacturaMgr.LoadInto(pFacturaCorrida.FacturaID, oFactura)

                If (oFactura.CodTipoVenta = "A") Then 'Asociado DIP.
                    .Parameters("@VTA_DIP").Value = "S"
                Else
                    .Parameters("@VTA_DIP").Value = "N"
                End If

                oFacturaMgr = Nothing
                oFactura = Nothing


                'Execute Command
                .ExecuteNonQuery()

            End With

            sccnnConnection.Close()

        Catch oSqlException As SqlException

            Dim errorMessages As String
            Dim i As Integer

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            For i = 0 To oSqlException.Errors.Count - 1
                errorMessages += "Index #" & i.ToString() & ControlChars.NewLine _
                               & "Message: " & oSqlException.Errors(i).Message & ControlChars.NewLine _
                               & "LineNumber: " & oSqlException.Errors(i).LineNumber & ControlChars.NewLine _
                               & "Source: " & oSqlException.Errors(i).Source & ControlChars.NewLine _
                               & "Procedure: " & oSqlException.Errors(i).Procedure & ControlChars.NewLine
            Next i

            'Throw New ApplicationException("El registro no pudo ser insertado debido a un error de base de datos.", oSqlException)

            Throw New ApplicationException("El registro no pudo ser insertado debido a un error de base de datos." & Microsoft.VisualBasic.vbCrLf & errorMessages & Microsoft.VisualBasic.vbCrLf, oSqlException)

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

    Public Function CostoNC(ByVal DPValeID As Integer) As DataSet

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaMovCont As SqlDataAdapter
        Dim dsMovCont As DataSet

        sccmdSelectAll = New SqlCommand
        scdaMovCont = New SqlDataAdapter
        dsMovCont = New DataSet

        With sccmdSelectAll

            .Connection = sccnnConnection

            .CommandText = "[FacturaCorridaCostoNC]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ValeCajaID", System.Data.SqlDbType.Int))

        End With

        scdaMovCont.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            scdaMovCont.SelectCommand.Parameters("@ValeCajaID").Value = DPValeID

            'Fill DataSet
            scdaMovCont.Fill(dsMovCont, "NotasCreditoDetalle")

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

#End Region

#Region "Facturacion SiHay"

    '-------------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 10/04/2013: Valida si el articulo se maneja en la tienda
    '-------------------------------------------------------------------------------------------------------------------------------------

    Public Function IsArticuloEnAlmacen(ByVal CodArticulo As String) As Boolean
        Dim conexion As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString())
        Dim command As New SqlCommand("EstaArticuloEnAlmacen", conexion)
        Dim reader As SqlDataReader = Nothing
        Dim valido As Boolean = False
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@CodArticulo", CodArticulo)
            command.Parameters.Add("@CodAlmacen", oParent.ApplicationContext.ApplicationConfiguration.Almacen)
            valido = CBool(command.ExecuteScalar())
            command.Dispose()
            conexion.Close()
        Catch sql As SqlException
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            EscribeLog(sql.Message, "Hubo un error al leer el registro en la base de datos", sql)
            Throw New ApplicationException("Hubo un error al leer el registro en la base de datos", sql)
        Catch ex As Exception
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            EscribeLog(ex.Message, "Hubo un error en la aplicación", ex)
            Throw New ApplicationException("Hubo un error en la aplicación", ex)
        End Try
        Return valido
    End Function
#End Region

End Class
