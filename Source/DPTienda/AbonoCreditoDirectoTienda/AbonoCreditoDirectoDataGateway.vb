Imports System.Data.SqlClient
Imports DportenisPro.DPTienda.ApplicationUnits.AbonosDPVale



Public Class AbonoCreditoDirectoDataGateway

    Private oParent As AbonoCreditoDirectoManager
    Private m_strConnectionString As String
    'Private wsEstadoDeCuentaAsociado As New wsEstadoDeCuentaAsociado.EstadodeCuentaAsociado
    'Private wsMovimientoInfo As New wsEstadoDeCuentaAsociado.MovimientosInfo

    'Private wsAbonoCreditoX As New wsAbonoCreditoDirecto.AbonoCreditoDirectoX
    'Private wsAbonoCreditoInfo As New wsAbonoCreditoDirecto.AbonoCreditoDirectoInfo
    'Public wsAbonoDPValeInfo As New wsAbonoCreditoDirecto.AbonoDPValeInfo


#Region "Constructors / Destructors"

    Public Sub New(ByVal Parent As AbonoCreditoDirectoManager)

        oParent = Parent
        m_strConnectionString = oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString

        'If Not oParent.ApplicationContext.ApplicationConfiguration.WSUrl = String.Empty Then
        '    wsEstadoDeCuentaAsociado.Url = oParent.ApplicationContext.ApplicationConfiguration.WSUrl.TrimEnd("/") _
        '            & "/" & wsEstadoDeCuentaAsociado.strURL.TrimStart("/")

        '    wsAbonoCreditoX.Url = oParent.ApplicationContext.ApplicationConfiguration.WSUrl.TrimEnd("/") _
        '    & "/" & wsAbonoCreditoX.strURL.TrimStart("/")
        'End If
        


    End Sub

#End Region

#Region "Web Services"

    'Private Sub LoadObjetosWS(ByVal oAbonoCreditoDirecto As AbonoCreditoDirecto, ByVal AbonoDPVale As AbonoDPVale)
    '    wsAbonoCreditoInfo.AApellidoMaterno = oAbonoCreditoDirecto.AApellidoMaterno
    '    wsAbonoCreditoInfo.AApellidoPaterno = oAbonoCreditoDirecto.AApellidoPaterno
    '    wsAbonoCreditoInfo.ACiudad = oAbonoCreditoDirecto.ACiudad
    '    wsAbonoCreditoInfo.AColonia = oAbonoCreditoDirecto.AColonia
    '    wsAbonoCreditoInfo.ACP = oAbonoCreditoDirecto.ACP
    '    wsAbonoCreditoInfo.ADomicilio = oAbonoCreditoDirecto.ADomicilio
    '    wsAbonoCreditoInfo.AEMail = oAbonoCreditoDirecto.AEMail
    '    wsAbonoCreditoInfo.AEstado = oAbonoCreditoDirecto.AEstado
    '    wsAbonoCreditoInfo.ANombre = oAbonoCreditoDirecto.ANombre
    '    wsAbonoCreditoInfo.ASexo = oAbonoCreditoDirecto.ASexo
    '    wsAbonoCreditoInfo.AsociadoID = oAbonoCreditoDirecto.AsociadoID
    '    wsAbonoCreditoInfo.ATelefono = oAbonoCreditoDirecto.ATelefono
    '    wsAbonoCreditoInfo.Banco = oAbonoCreditoDirecto.Banco
    '    wsAbonoCreditoInfo.ClienteID = oAbonoCreditoDirecto.ClienteID
    '    wsAbonoCreditoInfo.CreditoDirectoID = oAbonoCreditoDirecto.CreditoDirectoID
    '    wsAbonoCreditoInfo.CuentaContable = oAbonoCreditoDirecto.CuentaContable
    '    wsAbonoCreditoInfo.Facturas = oAbonoCreditoDirecto.Facturas
    '    wsAbonoCreditoInfo.Fecha = oAbonoCreditoDirecto.Fecha
    '    wsAbonoCreditoInfo.FechaExpiracion = oAbonoCreditoDirecto.FechaExpiracion
    '    wsAbonoCreditoInfo.FirmaDigital = oAbonoCreditoDirecto.FirmaDigital
    '    wsAbonoCreditoInfo.FormasDePago = oAbonoCreditoDirecto.FormasDePago
    '    wsAbonoCreditoInfo.LimCredBanco = oAbonoCreditoDirecto.LimCredBanco
    '    wsAbonoCreditoInfo.LimiteCredito = oAbonoCreditoDirecto.LimiteCredito
    '    wsAbonoCreditoInfo.Plazo = oAbonoCreditoDirecto.Plazo
    '    wsAbonoCreditoInfo.Saldo = oAbonoCreditoDirecto.Saldo
    '    wsAbonoCreditoInfo.SaldoVencido = oAbonoCreditoDirecto.SaldoVencido
    '    wsAbonoCreditoInfo.StatusRegistro = oAbonoCreditoDirecto.StatusRegistro
    '    wsAbonoCreditoInfo.Usuario = oAbonoCreditoDirecto.Usuario


    '    wsAbonoDPValeInfo.AsociadoID = AbonoDPVale.AsociadoID
    '    wsAbonoDPValeInfo.CodAlmacen = AbonoDPVale.CodAlmacen
    '    wsAbonoDPValeInfo.CodCaja = AbonoDPVale.CodCaja
    '    wsAbonoDPValeInfo.CodSegCred = AbonoDPVale.CodSegCred
    '    wsAbonoDPValeInfo.CodTipAbono = AbonoDPVale.CodTipAbono
    '    wsAbonoDPValeInfo.Detalle = AbonoDPVale.Detalle
    '    wsAbonoDPValeInfo.Fecha = AbonoDPVale.Fecha
    '    wsAbonoDPValeInfo.IDAbono = AbonoDPVale.IDAbono
    '    wsAbonoDPValeInfo.IDCliente = AbonoDPVale.IDCliente
    '    wsAbonoDPValeInfo.MontoPago = AbonoDPVale.MontoPago
    '    wsAbonoDPValeInfo.PagoMin = AbonoDPVale.PagoMin
    '    wsAbonoDPValeInfo.PlazaConsecutivo = AbonoDPVale.PlazaConsecutivo
    '    wsAbonoDPValeInfo.Referencia = AbonoDPVale.Referencia
    '    wsAbonoDPValeInfo.SaldNuevo = AbonoDPVale.SaldNuevo
    '    wsAbonoDPValeInfo.SaldoAnt = AbonoDPVale.SaldoAnt
    '    wsAbonoDPValeInfo.SaldoDPVale = AbonoDPVale.SaldoDPVale
    '    wsAbonoDPValeInfo.StatusRegistro = AbonoDPVale.StatusRegistro
    '    wsAbonoDPValeInfo.Usuario = AbonoDPVale.Usuario


    'End Sub

    'Public Function Insert(ByVal oAbonoCreditoDirecto As AbonoCreditoDirecto, ByVal AbonoDPVale As AbonoDPVale)

    '    Try

    '        LoadObjetosWS(oAbonoCreditoDirecto, AbonoDPVale)

    '        wsAbonoDPValeInfo = wsAbonoCreditoX.InsertAbono(wsAbonoCreditoInfo, wsAbonoDPValeInfo, oParent.ApplicationContext.ApplicationConfiguration.IVA)
    '        AbonoDPVale.Fecha = wsAbonoDPValeInfo.Fecha
    '        AbonoDPVale.IDAbono = wsAbonoDPValeInfo.IDAbono

    '    Catch oSqlException As SqlException

    '        Throw New ApplicationException("El registro no pudo ser insertado debido a un error de base de datos.", oSqlException)

    '    Catch ex As Exception

    '        Throw New ApplicationException("El registro no pudo ser insertado debido a un error de aplicación.", ex)

    '    End Try



    '    'Dim m_strConnectionString As String = "packet size=4096;user id=sa;password=sa;data source=OPERACIONES;persist security info=False;initial catalog=CreditoDP"


    '    'Dim sccnnConnection As New SqlConnection(m_strConnectionString)

    '    'Dim sccmdInsert As SqlCommand
    '    'sccmdInsert = New SqlCommand

    '    'With sccmdInsert

    '    '    .Connection = sccnnConnection

    '    '    .CommandText = "[AbonosIns]"
    '    '    .CommandType = System.Data.CommandType.StoredProcedure

    '    '    'OutPut :
    '    '    .Parameters.Add(New System.Data.SqlClient.SqlParameter("@AbonoID", System.Data.SqlDbType.Int, 4))
    '    '    .Parameters("@AbonoID").Direction = ParameterDirection.Output

    '    '    .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 3))
    '    '    .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar, 2))
    '    '    .Parameters.Add(New System.Data.SqlClient.SqlParameter("@AsociadoID", System.Data.SqlDbType.Int, 4))
    '    '    .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ClienteID", System.Data.SqlDbType.Int, 4))
    '    '    .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodSegmentoCredito", System.Data.SqlDbType.VarChar, 3))
    '    '    .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodTipoAbono", System.Data.SqlDbType.Int, 4))
    '    '    .Parameters.Add(New System.Data.SqlClient.SqlParameter("@SaldoAnterior", System.Data.SqlDbType.Money, 4))
    '    '    .Parameters.Add(New System.Data.SqlClient.SqlParameter("@PagoMinimo", System.Data.SqlDbType.Money, 4))
    '    '    .Parameters.Add(New System.Data.SqlClient.SqlParameter("@MontoPago", System.Data.SqlDbType.Money, 4))
    '    '    .Parameters.Add(New System.Data.SqlClient.SqlParameter("@SaldoNuevo", System.Data.SqlDbType.Money, 4))
    '    '    .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Usuario", System.Data.SqlDbType.VarChar, 12))
    '    '    .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime, 8))
    '    '    .Parameters("@Fecha").Direction = ParameterDirection.Output
    '    '    .Parameters.Add(New System.Data.SqlClient.SqlParameter("@StatusRegistro", System.Data.SqlDbType.Bit, 1))
    '    '    .Parameters.Add(New System.Data.SqlClient.SqlParameter("@PlazaConsecutivo", System.Data.SqlDbType.VarChar, 30))
    '    '    .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Referencia", System.Data.SqlDbType.VarChar, 15))



    '    'End With

    '    'Try

    '    '    sccnnConnection.Open()

    '    '    With sccmdInsert
    '    '        'Assign Parameters Values
    '    '        .Parameters("@CodAlmacen").Value = AbonoDPVale.CodAlmacen 'oParent.ApplicationContext.ApplicationConfiguration.Almacen
    '    '        .Parameters("@CodCaja").Value = AbonoDPVale.CodCaja 'oParent.ApplicationContext.ApplicationConfiguration.NoCaja
    '    '        .Parameters("@AsociadoID").Value = AbonoDPVale.AsociadoID
    '    '        .Parameters("@ClienteID").Value = AbonoDPVale.IDCliente
    '    '        .Parameters("@CodSegmentoCredito").Value = AbonoDPVale.CodSegCred
    '    '        .Parameters("@CodTipoAbono").Value = AbonoDPVale.CodTipAbono
    '    '        .Parameters("@SaldoAnterior").Value = AbonoDPVale.SaldoAnt
    '    '        .Parameters("@PagoMinimo").Value = AbonoDPVale.PagoMin
    '    '        .Parameters("@MontoPago").Value = AbonoDPVale.MontoPago
    '    '        .Parameters("@SaldoNuevo").Value = AbonoDPVale.SaldNuevo
    '    '        .Parameters("@Usuario").Value = AbonoDPVale.Usuario 'oParent.ApplicationContext.Security.CurrentUser.Name
    '    '        .Parameters("@Fecha").Value = Date.Today
    '    '        .Parameters("@StatusRegistro").Value = AbonoDPVale.StatusRegistro
    '    '        .Parameters("@PlazaConsecutivo").Value = ""
    '    '        .Parameters("@Referencia").Value = ""

    '    '        'Execute Command
    '    '        .ExecuteNonQuery()

    '    '        'Actualizar.
    '    '        AbonoDPVale.IDAbono = .Parameters("@AbonoID").Value
    '    '        AbonoDPVale.Fecha = .Parameters("@Fecha").Value


    '    '    End With


    '    '    ' Forma de Pago :

    '    '    sccmdInsert.Dispose()
    '    '    sccmdInsert = Nothing

    '    '    sccmdInsert = New SqlCommand

    '    '    With sccmdInsert
    '    '        .Connection = sccnnConnection

    '    '        .CommandText = "[AbonosFormasPagoIns]"
    '    '        .CommandType = System.Data.CommandType.StoredProcedure

    '    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@AbonoFormaPagoID", System.Data.SqlDbType.Int))
    '    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@AbonoID", System.Data.SqlDbType.Int, 4))
    '    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodFormaPago", System.Data.SqlDbType.VarChar, 1))
    '    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Monto", System.Data.SqlDbType.Money, 4))
    '    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodTipoTarjeta", System.Data.SqlDbType.VarChar, 2))
    '    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodBanco", System.Data.SqlDbType.VarChar, 4))
    '    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@NumeroAutorizacion", System.Data.SqlDbType.VarChar, 20))
    '    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@NumeroTarjeta", System.Data.SqlDbType.VarChar, 20))
    '    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ComisionBancaria", System.Data.SqlDbType.Money, 4))
    '    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Ingreso", System.Data.SqlDbType.Money, 4))
    '    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@IVA", System.Data.SqlDbType.Money, 4))
    '    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Usuario", System.Data.SqlDbType.VarChar, 12))
    '    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime, 8))
    '    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@StatusRegistro", System.Data.SqlDbType.Bit, 1))
    '    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@SaldoDPVale", System.Data.SqlDbType.Money, 8))
    '    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@AsociadoID", System.Data.SqlDbType.Int, 4))

    '    '    End With

    '    '    Dim odrFormaPagp As DataRow
    '    '    Dim bonificacion As Double
    '    '    For Each odrFormaPagp In oAbonoCreditoDirecto.FormasDePago.Tables(0).Rows
    '    '        If odrFormaPagp("IDFormaPago") = "B" Then
    '    '            bonificacion += odrFormaPagp("Monto")
    '    '        End If
    '    '        With sccmdInsert
    '    '            .Parameters("@AbonoFormaPagoID").Value = AbonoDPVale.IDAbono
    '    '            .Parameters("@AbonoID").Value = AbonoDPVale.IDAbono
    '    '            .Parameters("@CodFormaPago").Value = odrFormaPagp("IDFormaPago")
    '    '            .Parameters("@Monto").Value = odrFormaPagp("Monto")
    '    '            .Parameters("@CodTipoTarjeta").Value = odrFormaPagp("IDTipoTarjeta")
    '    '            .Parameters("@CodBanco").Value = odrFormaPagp("IDBanco")
    '    '            .Parameters("@NumeroAutorizacion").Value = odrFormaPagp("NumAutorizacion")
    '    '            .Parameters("@NumeroTarjeta").Value = odrFormaPagp("NumTarjeta")
    '    '            .Parameters("@ComisionBancaria").Value = odrFormaPagp("Comision")
    '    '            .Parameters("@Ingreso").Value = odrFormaPagp("Total")
    '    '            .Parameters("@IVA").Value = odrFormaPagp("Monto") - (odrFormaPagp("Monto") / (1 + oParent.ApplicationContext.ApplicationConfiguration.IVA))
    '    '            .Parameters("@Usuario").Value = AbonoDPVale.Usuario 'oParent.ApplicationContext.Security.CurrentUser.Name
    '    '            .Parameters("@Fecha").Value = Date.Today
    '    '            .Parameters("@StatusRegistro").Value = AbonoDPVale.StatusRegistro
    '    '            .Parameters("@SaldoDPVale").Value = AbonoDPVale.SaldoDPVale
    '    '            .Parameters("@AsociadoID").Value = AbonoDPVale.AsociadoID

    '    '            .ExecuteNonQuery()

    '    '        End With

    '    '    Next

    '    '    ' PagosCreditoDirecto

    '    '    sccmdInsert.Dispose()
    '    '    sccmdInsert = Nothing

    '    '    sccmdInsert = New SqlCommand

    '    '    With sccmdInsert
    '    '        .Connection = sccnnConnection

    '    '        .CommandText = "[PagosCDirectoUpd]"
    '    '        .CommandType = System.Data.CommandType.StoredProcedure

    '    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 3))
    '    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar, 2))
    '    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@AsociadoID", System.Data.SqlDbType.Int, 4))
    '    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ClienteID", System.Data.SqlDbType.Int, 4))
    '    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Saldo", System.Data.SqlDbType.Money, 8))
    '    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@DescuentoProntoPago", System.Data.SqlDbType.Money, 8))
    '    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RecargoMoroso", System.Data.SqlDbType.Money, 8))
    '    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioFactura", System.Data.SqlDbType.Int, 4))
    '    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@SaldoAnterior", System.Data.SqlDbType.Money, 8))
    '    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RelacionAbonos", System.Data.SqlDbType.VarChar, 100))


    '    '    End With


    '    '    For Each odrFormaPagp In oAbonoCreditoDirecto.Facturas.Tables("Facturas").Rows
    '    '        If odrFormaPagp("Abono") Is DBNull.Value Then
    '    '            odrFormaPagp("Abono") = 0.0
    '    '        End If
    '    '        If odrFormaPagp("Abono") > 0.0 Then
    '    '            With sccmdInsert
    '    '                .Parameters("@CodAlmacen").Value = odrFormaPagp("CodAlmacen")
    '    '                .Parameters("@CodCaja").Value = odrFormaPagp("CodCaja")
    '    '                .Parameters("@AsociadoID").Value = odrFormaPagp("AsociadoID")
    '    '                .Parameters("@ClienteID").Value = odrFormaPagp("ClienteID")
    '    '                .Parameters("@Saldo").Value = odrFormaPagp("Saldo") - odrFormaPagp("Abono")
    '    '                .Parameters("@DescuentoProntoPago").Value = 0 'odrFormaPagp("Bonificacion")
    '    '                .Parameters("@RecargoMoroso").Value = odrFormaPagp("RecargoMoroso")
    '    '                .Parameters("@FolioFactura").Value = odrFormaPagp("FolioFactura")
    '    '                .Parameters("@SaldoAnterior").Value = odrFormaPagp("Saldo")
    '    '                .Parameters("@RelacionAbonos").Value = CStr(odrFormaPagp("RelacionAbonos") & "," & CStr(AbonoDPVale.IDAbono)).TrimStart(",")
    '    '                .ExecuteNonQuery()

    '    '            End With

    '    '        End If
    '    '    Next



    '    '    ' AbonosCreditoDirecto

    '    '    sccmdInsert.Dispose()
    '    '    sccmdInsert = Nothing

    '    '    sccmdInsert = New SqlCommand

    '    '    With sccmdInsert
    '    '        .Connection = sccnnConnection

    '    '        .CommandText = "[AbonosCreditoDirectoIns]"
    '    '        .CommandType = System.Data.CommandType.StoredProcedure

    '    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@AbonoID", System.Data.SqlDbType.Int, 4))
    '    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioFactura", System.Data.SqlDbType.Int, 4))
    '    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 3))
    '    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar, 2))
    '    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Monto", System.Data.SqlDbType.Money, 8))
    '    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Usuario", System.Data.SqlDbType.VarChar, 12))
    '    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime, 8))
    '    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@StatusRegistro", System.Data.SqlDbType.Bit, 1))

    '    '    End With


    '    '    For Each odrFormaPagp In oAbonoCreditoDirecto.Facturas.Tables("Facturas").Rows
    '    '        If odrFormaPagp("Abono") Is DBNull.Value Then
    '    '            odrFormaPagp("Abono") = 0.0
    '    '        End If
    '    '        If odrFormaPagp("Abono") > 0.0 Then
    '    '            With sccmdInsert
    '    '                .Parameters("@AbonoID").Value = AbonoDPVale.IDAbono
    '    '                .Parameters("@FolioFactura").Value = odrFormaPagp("FolioFactura")
    '    '                .Parameters("@CodAlmacen").Value = AbonoDPVale.CodAlmacen
    '    '                .Parameters("@CodCaja").Value = AbonoDPVale.CodCaja
    '    '                .Parameters("@Monto").Value = odrFormaPagp("Abono")
    '    '                .Parameters("@Usuario").Value = AbonoDPVale.Usuario
    '    '                .Parameters("@Fecha").Value = AbonoDPVale.Fecha.Date
    '    '                .Parameters("@StatusRegistro").Value = 1
    '    '                .ExecuteNonQuery()

    '    '            End With

    '    '        End If
    '    '    Next

    '    '    sccnnConnection.Close()

    '    '    '''Cambios Cristina
    '    '    wsMovimientoInfo.Abono = AbonoDPVale.MontoPago - bonificacion
    '    '    wsMovimientoInfo.AsociadoID = AbonoDPVale.AsociadoID
    '    '    wsMovimientoInfo.Año = AbonoDPVale.Fecha.Year
    '    '    wsMovimientoInfo.Cargo = 0
    '    '    wsMovimientoInfo.CodigoAlmacen = AbonoDPVale.CodAlmacen
    '    '    wsMovimientoInfo.CodigoCaja = AbonoDPVale.CodCaja
    '    '    wsMovimientoInfo.FechaMovimiento = AbonoDPVale.Fecha
    '    '    wsMovimientoInfo.FolioMovimiento = AbonoDPVale.IDAbono
    '    '    wsMovimientoInfo.Mes = AbonoDPVale.Fecha.Month
    '    '    wsMovimientoInfo.StatusRegistro = True
    '    '    wsMovimientoInfo.TipoDocumento = "ABONO"
    '    '    wsMovimientoInfo.Usuario = AbonoDPVale.Usuario
    '    '    wsEstadoDeCuentaAsociado.InsertMovimiento("c", wsMovimientoInfo)

    '    '    If bonificacion > 0 Then
    '    '        wsMovimientoInfo.Abono = bonificacion
    '    '        wsMovimientoInfo.AsociadoID = AbonoDPVale.AsociadoID
    '    '        wsMovimientoInfo.Año = AbonoDPVale.Fecha.Year
    '    '        wsMovimientoInfo.Cargo = 0
    '    '        wsMovimientoInfo.CodigoAlmacen = AbonoDPVale.CodAlmacen
    '    '        wsMovimientoInfo.CodigoCaja = AbonoDPVale.CodCaja
    '    '        wsMovimientoInfo.FechaMovimiento = AbonoDPVale.Fecha
    '    '        wsMovimientoInfo.FolioMovimiento = AbonoDPVale.IDAbono
    '    '        wsMovimientoInfo.Mes = AbonoDPVale.Fecha.Month
    '    '        wsMovimientoInfo.StatusRegistro = True
    '    '        wsMovimientoInfo.TipoDocumento = "BONIFICACION"
    '    '        wsMovimientoInfo.Usuario = AbonoDPVale.Usuario
    '    '        wsEstadoDeCuentaAsociado.InsertMovimiento("c", wsMovimientoInfo)
    '    '    End If

    '    '    'wsSaldosInfo.AsociadoID = AbonoDPVale.AsociadoID
    '    '    'wsSaldosInfo.Abono = AbonoDPVale.MontoPago


    '    '    'wsEstadoDeCuentaAsociado.InsertSaldo("dpvale", wsSaldosInfo)
    '    '    '''Cambios Cristina


    '    'Catch oSqlException As SqlException

    '    '    If (sccnnConnection.State <> ConnectionState.Closed) Then
    '    '        Try
    '    '            sccnnConnection.Close()
    '    '        Catch
    '    '        End Try
    '    '    End If

    '    '    Throw New ApplicationException("El registro no pudo ser insertado debido a un error de base de datos.", oSqlException)

    '    'Catch ex As Exception

    '    '    If (sccnnConnection.State <> ConnectionState.Closed) Then
    '    '        Try
    '    '            sccnnConnection.Close()
    '    '        Catch
    '    '        End Try
    '    '    End If

    '    '    Throw New ApplicationException("El registro no pudo ser insertado debido a un error de aplicación.", ex)

    '    'End Try

    '    'sccnnConnection.Dispose()
    '    'sccnnConnection = Nothing

    'End Function

    'Public Function Delete(ByVal oAbonoCreditoDirecto As AbonoCreditoDirecto, ByVal oAbonoDPVale As AbonoDPVale)

    '    Try

    '        LoadObjetosWS(oAbonoCreditoDirecto, oAbonoDPVale)
    '        wsAbonoCreditoX.DeleteAbono(wsAbonoCreditoInfo, wsAbonoDPValeInfo)

    '    Catch ex As Exception

    '    End Try




    '    'Dim m_strConnectionString As String = "packet size=4096;user id=sa;password=sa;data source=OPERACIONES;persist security info=False;initial catalog=CreditoDP"

    '    'Dim sccnnConnection As New SqlConnection(m_strConnectionString)

    '    'Dim sccmdDelete As SqlCommand
    '    'sccmdDelete = New SqlCommand

    '    'With sccmdDelete

    '    '    .Connection = sccnnConnection
    '    '    .CommandText = "[AbonosDel]"

    '    '    .CommandType = System.Data.CommandType.StoredProcedure

    '    '    .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
    '    '    .Parameters.Add(New System.Data.SqlClient.SqlParameter("@AbonoID", System.Data.SqlDbType.Int, 4))
    '    '    .Parameters.Add(New System.Data.SqlClient.SqlParameter("@SaldoNuevo", System.Data.SqlDbType.Money, 8))
    '    '    .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodSegmentoCredito", System.Data.SqlDbType.VarChar, 3))
    '    '    .Parameters.Add(New System.Data.SqlClient.SqlParameter("@AsociadoID", System.Data.SqlDbType.Int, 4))
    '    'End With

    '    'Try

    '    '    sccnnConnection.Open()

    '    '    With sccmdDelete
    '    '        'Assign Parameters Values
    '    '        .Parameters("@AbonoID").Value = oAbonoDPVale.IDAbono
    '    '        .Parameters("@SaldoNuevo").Value = oAbonoDPVale.SaldoAnt
    '    '        .Parameters("@CodSegmentoCredito").Value = oAbonoDPVale.CodSegCred
    '    '        .Parameters("@AsociadoID").Value = oAbonoCreditoDirecto.AsociadoID


    '    '        'Execute Command
    '    '        .ExecuteNonQuery()

    '    '    End With

    '    '    ' PagosCreditoDirecto

    '    '    sccmdDelete.Dispose()
    '    '    sccmdDelete = Nothing

    '    '    sccmdDelete = New SqlCommand

    '    '    With sccmdDelete
    '    '        .Connection = sccnnConnection

    '    '        .CommandText = "[PagosCDirectoUpd]"
    '    '        .CommandType = System.Data.CommandType.StoredProcedure

    '    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 3))
    '    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar, 2))
    '    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@AsociadoID", System.Data.SqlDbType.Int, 4))
    '    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ClienteID", System.Data.SqlDbType.Int, 4))
    '    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Saldo", System.Data.SqlDbType.Money, 8))
    '    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@DescuentoProntoPago", System.Data.SqlDbType.Money, 8))
    '    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RecargoMoroso", System.Data.SqlDbType.Money, 8))
    '    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioFactura", System.Data.SqlDbType.Int, 4))
    '    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@SaldoAnterior", System.Data.SqlDbType.Money, 8))
    '    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RelacionAbonos", System.Data.SqlDbType.VarChar, 100))

    '    '    End With

    '    '    Dim bonificacion As Double = 0
    '    '    Dim odrFormaPagp As DataRow
    '    '    For Each odrFormaPagp In oAbonoCreditoDirecto.Facturas.Tables("Facturas").Rows

    '    '        With sccmdDelete
    '    '            If CStr(odrFormaPagp("RelacionAbonos")).IndexOf(oAbonoDPVale.IDAbono) >= 0 Then
    '    '                bonificacion += odrFormaPagp("DescuentoProntoPago")
    '    '                .Parameters("@CodAlmacen").Value = odrFormaPagp("CodAlmacen")
    '    '                .Parameters("@CodCaja").Value = odrFormaPagp("CodCaja")
    '    '                .Parameters("@AsociadoID").Value = odrFormaPagp("AsociadoID")
    '    '                .Parameters("@ClienteID").Value = odrFormaPagp("ClienteID")
    '    '                .Parameters("@Saldo").Value = odrFormaPagp("Saldo") + odrFormaPagp("Abono")
    '    '                .Parameters("@SaldoAnterior").Value = odrFormaPagp("Saldo")
    '    '                .Parameters("@DescuentoProntoPago").Value = 0
    '    '                .Parameters("@RecargoMoroso").Value = 0
    '    '                .Parameters("@RelacionAbonos").Value = odrFormaPagp("RelacionAbonos")
    '    '                .Parameters("@FolioFactura").Value = odrFormaPagp("FolioFactura")
    '    '                .ExecuteNonQuery()

    '    '            End If


    '    '        End With

    '    '    Next

    '    '    ' AbonosCreditoDirecto

    '    '    sccmdDelete.Dispose()
    '    '    sccmdDelete = Nothing

    '    '    sccmdDelete = New SqlCommand

    '    '    With sccmdDelete
    '    '        .Connection = sccnnConnection

    '    '        .CommandText = "[AbonosCreditoDirectoUpd]"
    '    '        .CommandType = System.Data.CommandType.StoredProcedure

    '    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@AbonoID", System.Data.SqlDbType.Int, 4))
    '    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioFactura", System.Data.SqlDbType.Int, 4))
    '    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 3))
    '    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar, 2))
    '    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Monto", System.Data.SqlDbType.Money, 8))
    '    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Usuario", System.Data.SqlDbType.VarChar, 12))
    '    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime, 8))
    '    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@StatusRegistro", System.Data.SqlDbType.Bit, 1))

    '    '    End With


    '    '    For Each odrFormaPagp In oAbonoCreditoDirecto.Facturas.Tables("Facturas").Rows
    '    '        If odrFormaPagp("Abono") Is DBNull.Value Then
    '    '            odrFormaPagp("Abono") = 0.0
    '    '        End If
    '    '        If odrFormaPagp("Abono") > 0.0 Then
    '    '            With sccmdDelete
    '    '                .Parameters("@AbonoID").Value = oAbonoDPVale.IDAbono
    '    '                .Parameters("@FolioFactura").Value = odrFormaPagp("FolioFactura")
    '    '                .Parameters("@CodAlmacen").Value = oAbonoDPVale.CodAlmacen
    '    '                .Parameters("@CodCaja").Value = oAbonoDPVale.CodCaja
    '    '                .Parameters("@Monto").Value = odrFormaPagp("Abono")
    '    '                .Parameters("@Usuario").Value = oAbonoDPVale.Usuario
    '    '                .Parameters("@Fecha").Value = oAbonoDPVale.Fecha.Date
    '    '                .Parameters("@StatusRegistro").Value = 0
    '    '                .ExecuteNonQuery()

    '    '            End With

    '    '        End If
    '    '    Next

    '    '    sccnnConnection.Close()

    '    '    '''Cambios Cristina
    '    '    wsMovimientoInfo.Abono = 0
    '    '    wsMovimientoInfo.AsociadoID = oAbonoDPVale.AsociadoID
    '    '    wsMovimientoInfo.Año = oAbonoDPVale.Fecha.Year
    '    '    wsMovimientoInfo.Cargo = oAbonoDPVale.MontoPago - bonificacion
    '    '    wsMovimientoInfo.CodigoAlmacen = oAbonoDPVale.CodAlmacen
    '    '    wsMovimientoInfo.CodigoCaja = oAbonoDPVale.CodCaja
    '    '    wsMovimientoInfo.FechaMovimiento = oAbonoDPVale.Fecha
    '    '    wsMovimientoInfo.FolioMovimiento = oAbonoDPVale.IDAbono
    '    '    wsMovimientoInfo.Mes = oAbonoDPVale.Fecha.Month
    '    '    wsMovimientoInfo.StatusRegistro = True
    '    '    wsMovimientoInfo.TipoDocumento = "CANC ABONO"
    '    '    wsMovimientoInfo.Usuario = oAbonoDPVale.Usuario
    '    '    wsEstadoDeCuentaAsociado.InsertMovimiento("c", wsMovimientoInfo)

    '    '    If bonificacion > 0 Then
    '    '        wsMovimientoInfo.Abono = 0
    '    '        wsMovimientoInfo.AsociadoID = oAbonoDPVale.AsociadoID
    '    '        wsMovimientoInfo.Año = oAbonoDPVale.Fecha.Year
    '    '        wsMovimientoInfo.Cargo = bonificacion
    '    '        wsMovimientoInfo.CodigoAlmacen = oAbonoDPVale.CodAlmacen
    '    '        wsMovimientoInfo.CodigoCaja = oAbonoDPVale.CodCaja
    '    '        wsMovimientoInfo.FechaMovimiento = oAbonoDPVale.Fecha
    '    '        wsMovimientoInfo.FolioMovimiento = oAbonoDPVale.IDAbono
    '    '        wsMovimientoInfo.Mes = oAbonoDPVale.Fecha.Month
    '    '        wsMovimientoInfo.StatusRegistro = True
    '    '        wsMovimientoInfo.TipoDocumento = "CANC BONIFICACION"
    '    '        wsMovimientoInfo.Usuario = oAbonoDPVale.Usuario
    '    '        wsEstadoDeCuentaAsociado.InsertMovimiento("c", wsMovimientoInfo)
    '    '    End If

    '    '    'wsSaldosInfo.AsociadoID = AbonoDPVale.AsociadoID
    '    '    'wsSaldosInfo.Abono = AbonoDPVale.MontoPago


    '    '    'wsEstadoDeCuentaAsociado.InsertSaldo("dpvale", wsSaldosInfo)
    '    '    '''Cambios Cristina

    '    'Catch oSqlException As SqlException

    '    '    MsgBox(oSqlException.ToString)

    '    '    If (sccnnConnection.State <> ConnectionState.Closed) Then
    '    '        Try
    '    '            sccnnConnection.Close()
    '    '        Catch
    '    '        End Try
    '    '    End If

    '    '    'Throw New ApplicationException("El registro no pudo ser insertado debido a un error de base de datos.", oSqlException)

    '    'Catch ex As Exception

    '    '    MsgBox(ex.ToString)

    '    '    If (sccnnConnection.State <> ConnectionState.Closed) Then
    '    '        Try
    '    '            sccnnConnection.Close()
    '    '        Catch
    '    '        End Try
    '    '    End If

    '    '    'Throw New ApplicationException("El registro no pudo ser insertado debido a un error de aplicación.", ex)

    '    'End Try


    '    'sccmdDelete.Dispose()
    '    'sccmdDelete = Nothing

    '    'sccnnConnection.Dispose()
    '    'sccnnConnection = Nothing
    'End Function

    'Public Function SelectCreditoDirectoAll(ByVal OnlyEnabledRecords As Boolean) As DataSet


    '    Try

    '        Return wsAbonoCreditoX.SelectCreditoDirectoAll(OnlyEnabledRecords)

    '    Catch ex As Exception

    '    End Try

    '    'Dim m_strConnectionString As String = "packet size=4096;user id=sa;password=sa;data source=OPERACIONES;persist security info=False;initial catalog=CreditoDP"

    '    'Dim sccnnConnection As New SqlConnection(m_strConnectionString)

    '    'Dim sccmdSelectAll As SqlCommand
    '    'Dim scdaCiudades As SqlDataAdapter
    '    'Dim dsAsociados As DataSet

    '    'sccmdSelectAll = New SqlCommand
    '    'scdaCiudades = New SqlDataAdapter
    '    'dsAsociados = New DataSet("Creditos")

    '    'With sccmdSelectAll

    '    '    .Connection = sccnnConnection

    '    '    .CommandText = "[CreditoDirectoEnTiendaSelAll]"
    '    '    .CommandType = System.Data.CommandType.StoredProcedure
    '    'End With

    '    'scdaCiudades.SelectCommand = sccmdSelectAll

    '    'Try

    '    '    sccnnConnection.Open()

    '    '    'Fill DataSet
    '    '    scdaCiudades.Fill(dsAsociados, "Creditos")

    '    '    sccnnConnection.Close()

    '    'Catch oSqlException As SqlException

    '    '    If (sccnnConnection.State <> ConnectionState.Closed) Then
    '    '        Try
    '    '            sccnnConnection.Close()
    '    '        Catch
    '    '        End Try
    '    '    End If

    '    '    Throw New ApplicationException("Los registros no pudieron ser leidos debido a un error de base de datos.", oSqlException)

    '    'Catch ex As Exception

    '    '    If (sccnnConnection.State <> ConnectionState.Closed) Then
    '    '        Try
    '    '            sccnnConnection.Close()
    '    '        Catch
    '    '        End Try
    '    '    End If

    '    '    Throw New ApplicationException("Los registros no pudieron ser leidos debido a un error de aplicación.", ex)

    '    'End Try

    '    'sccnnConnection.Dispose()
    '    'sccnnConnection = Nothing

    '    'Return dsAsociados
    'End Function

    'Public Function SelectCreditoDirectoByID(ByVal AsociadoID As Integer) As AbonoCreditoDirecto

    '    Try
    '        Dim oAbonoCreditoDirecto As New AbonoCreditoDirecto(oParent)
    '        wsAbonoCreditoInfo = wsAbonoCreditoX.SelectCreditoDirectoByID(AsociadoID)

    '        If Not wsAbonoCreditoInfo Is Nothing Then

    '            oAbonoCreditoDirecto.AApellidoMaterno = wsAbonoCreditoInfo.AApellidoMaterno
    '            oAbonoCreditoDirecto.AApellidoPaterno = wsAbonoCreditoInfo.AApellidoPaterno
    '            oAbonoCreditoDirecto.ACiudad = wsAbonoCreditoInfo.ACiudad
    '            oAbonoCreditoDirecto.AColonia = wsAbonoCreditoInfo.AColonia
    '            oAbonoCreditoDirecto.ACP = wsAbonoCreditoInfo.ACP
    '            oAbonoCreditoDirecto.ADomicilio = wsAbonoCreditoInfo.ADomicilio
    '            oAbonoCreditoDirecto.AEMail = wsAbonoCreditoInfo.AEMail
    '            oAbonoCreditoDirecto.AEstado = wsAbonoCreditoInfo.AEstado
    '            oAbonoCreditoDirecto.ANombre = wsAbonoCreditoInfo.ANombre
    '            oAbonoCreditoDirecto.ASexo = wsAbonoCreditoInfo.ASexo
    '            oAbonoCreditoDirecto.AsociadoID = wsAbonoCreditoInfo.AsociadoID
    '            oAbonoCreditoDirecto.ATelefono = wsAbonoCreditoInfo.ATelefono
    '            oAbonoCreditoDirecto.Banco = wsAbonoCreditoInfo.Banco
    '            oAbonoCreditoDirecto.ClienteID = wsAbonoCreditoInfo.ClienteID
    '            oAbonoCreditoDirecto.CreditoDirectoID = wsAbonoCreditoInfo.CreditoDirectoID
    '            oAbonoCreditoDirecto.CuentaContable = wsAbonoCreditoInfo.CuentaContable
    '            oAbonoCreditoDirecto.Facturas = wsAbonoCreditoInfo.Facturas
    '            oAbonoCreditoDirecto.Fecha = wsAbonoCreditoInfo.Fecha
    '            oAbonoCreditoDirecto.FechaExpiracion = wsAbonoCreditoInfo.FechaExpiracion
    '            oAbonoCreditoDirecto.FirmaDigital = wsAbonoCreditoInfo.FirmaDigital
    '            oAbonoCreditoDirecto.FormasDePago = wsAbonoCreditoInfo.FormasDePago
    '            oAbonoCreditoDirecto.LimCredBanco = wsAbonoCreditoInfo.LimCredBanco
    '            oAbonoCreditoDirecto.LimiteCredito = wsAbonoCreditoInfo.LimiteCredito
    '            oAbonoCreditoDirecto.Plazo = wsAbonoCreditoInfo.Plazo
    '            oAbonoCreditoDirecto.Saldo = wsAbonoCreditoInfo.Saldo
    '            oAbonoCreditoDirecto.SaldoVencido = wsAbonoCreditoInfo.SaldoVencido
    '            oAbonoCreditoDirecto.StatusRegistro = wsAbonoCreditoInfo.StatusRegistro
    '            oAbonoCreditoDirecto.Usuario = wsAbonoCreditoInfo.Usuario

    '        End If

    '        Return oAbonoCreditoDirecto

    '    Catch ex As Exception

    '    End Try





    '    'Dim m_strConnectionString As String = "packet size=4096;user id=sa;password=sa;data source=OPERACIONES;persist security info=False;initial catalog=CreditoDP"

    '    'Dim sccnnConnection As New SqlConnection(m_strConnectionString)

    '    'Dim sccmdSelect As SqlCommand
    '    'Dim scdrReader As SqlDataReader

    '    'sccmdSelect = New SqlCommand

    '    'Dim oResult As New AbonoCreditoDirecto(oParent)

    '    'With sccmdSelect

    '    '    .Connection = sccnnConnection

    '    '    .CommandText = "[CreditoDirectoEnTiendaSel]"
    '    '    .CommandType = System.Data.CommandType.StoredProcedure

    '    '    .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
    '    '    .Parameters.Add(New System.Data.SqlClient.SqlParameter("@AsociadoID", System.Data.SqlDbType.VarChar, 20))

    '    'End With

    '    'Try

    '    '    sccnnConnection.Open()

    '    '    With sccmdSelect
    '    '        'Asignamos Valor al Parámetro
    '    '        .Parameters("@AsociadoID").Value = AsociadoID

    '    '        'Ejecutamos Comando
    '    '        scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

    '    '        'Asignamos Valores al Reader
    '    '        scdrReader.Read()

    '    '        If (scdrReader.HasRows) Then

    '    '            With scdrReader

    '    '                oResult.AApellidoMaterno = .GetString(.GetOrdinal("AApellidoMaterno"))
    '    '                oResult.AApellidoPaterno = .GetString(.GetOrdinal("AApellidoPaterno"))
    '    '                oResult.ACiudad = .GetString(.GetOrdinal("ACiudad"))
    '    '                oResult.AColonia = .GetString(.GetOrdinal("AColonia"))
    '    '                oResult.ACP = .GetString(.GetOrdinal("ACP"))
    '    '                oResult.ADomicilio = .GetString(.GetOrdinal("ADomicilio"))
    '    '                oResult.AEMail = .GetString(.GetOrdinal("AEMail"))
    '    '                oResult.AEstado = .GetString(.GetOrdinal("AEstado"))
    '    '                oResult.ANombre = .GetString(.GetOrdinal("ANombre"))
    '    '                oResult.ASexo = .GetString(.GetOrdinal("ASexo"))
    '    '                oResult.AsociadoID = .GetInt32(.GetOrdinal("AsociadoID"))
    '    '                oResult.ATelefono = .GetString(.GetOrdinal("ATelefono"))
    '    '                oResult.Banco = .GetString(.GetOrdinal("Banco"))
    '    '                oResult.ClienteID = .GetInt32(.GetOrdinal("ClienteID"))
    '    '                oResult.CreditoDirectoID = .GetInt32(.GetOrdinal("CreditoDirectoID"))
    '    '                oResult.CuentaContable = .GetString(.GetOrdinal("CuentaContable"))
    '    '                oResult.Fecha = .GetDateTime(.GetOrdinal("Fecha"))
    '    '                oResult.FechaExpiracion = .GetDateTime(.GetOrdinal("FechaExpiracion"))
    '    '                'oResult.FirmaDigital = .GetString(.GetOrdinal("FirmaDigital"))
    '    '                oResult.LimCredBanco = .GetDecimal(.GetOrdinal("LimCredBanco"))
    '    '                oResult.LimiteCredito = .GetDecimal(.GetOrdinal("LimiteCredito"))
    '    '                oResult.Plazo = .GetInt32(.GetOrdinal("Plazo"))
    '    '                oResult.Saldo = .GetDecimal(.GetOrdinal("Saldo"))
    '    '                oResult.SaldoVencido = .GetDecimal(.GetOrdinal("SaldoVencido"))
    '    '                oResult.StatusRegistro = .GetBoolean(.GetOrdinal("StatusRegistro"))
    '    '                oResult.Usuario = .GetString(.GetOrdinal("Usuario"))


    '    '                'Actualizamos Status del Objeto
    '    '                oResult.ResetStateNew()
    '    '                oResult.SetStateDirty()

    '    '                'Seleccionamos Facturas
    '    '                oResult.Facturas = SelectFacturasByID(oResult.AsociadoID)

    '    '            End With

    '    '        Else


    '    '            Exit Function

    '    '        End If

    '    '        scdrReader.Close()

    '    '    End With

    '    '    sccnnConnection.Close()

    '    'Catch oSqlException As SqlException

    '    '    If (sccnnConnection.State <> ConnectionState.Closed) Then
    '    '        sccnnConnection.Close()
    '    '    End If

    '    '    Throw New ApplicationException("El registro no pudo ser leido debido a un error de base de datos.", oSqlException)

    '    'Catch ex As Exception

    '    '    If (sccnnConnection.State <> ConnectionState.Closed) Then
    '    '        sccnnConnection.Close()
    '    '    End If

    '    '    Throw New ApplicationException("El registro no pudo ser leido debido a un error de aplicación.", ex)

    '    'End Try

    '    'sccnnConnection.Dispose()
    '    'sccnnConnection = Nothing

    '    'Return oResult
    'End Function

    Public Function SelectFacturasByID(ByVal AsociadoID As Integer) As DataSet

        Try
            'wsAbonoCreditoX = New wsAbonoCreditoDirecto.AbonoCreditoDirectoX

            If Not oParent.ApplicationContext.ApplicationConfiguration.WSUrl = String.Empty Then

                '            wsAbonoCreditoX.Url = oParent.ApplicationContext.ApplicationConfiguration.WSUrl.TrimEnd("/") _
                '& "/" & wsAbonoCreditoX.strURL.TrimStart("/")

            End If

            'Return wsAbonoCreditoX.SelectFacturasByID(AsociadoID)
            '
        Catch ex As Exception

        End Try


        'Dim m_strConnectionString As String = "packet size=4096;user id=sa;password=sa;data source=OPERACIONES;persist security info=False;initial catalog=CreditoDP"

        'Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        'Dim sccmdSelectAll As SqlCommand
        'Dim scdaFacturas As SqlDataAdapter
        'Dim dsFacturas As DataSet

        'sccmdSelectAll = New SqlCommand
        'scdaFacturas = New SqlDataAdapter
        'dsFacturas = New DataSet("Facturas")

        'With sccmdSelectAll

        '    .Connection = sccnnConnection

        '    .CommandText = "[PagosCreditoDirectoSel]"
        '    .CommandType = System.Data.CommandType.StoredProcedure

        '    .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        '    .Parameters.Add(New System.Data.SqlClient.SqlParameter("@AsociadoID", System.Data.SqlDbType.VarChar, 20))

        '    .Parameters("@AsociadoID").Value = AsociadoID
        'End With

        'scdaFacturas.SelectCommand = sccmdSelectAll

        'Try

        '    sccnnConnection.Open()

        '    'Fill DataSet
        '    scdaFacturas.Fill(dsFacturas, "Facturas")

        '    sccnnConnection.Close()

        'Catch oSqlException As SqlException

        '    If (sccnnConnection.State <> ConnectionState.Closed) Then
        '        Try
        '            sccnnConnection.Close()
        '        Catch
        '        End Try
        '    End If

        '    Throw New ApplicationException("Los registros no pudieron ser leidos debido a un error de base de datos.", oSqlException)

        'Catch ex As Exception

        '    If (sccnnConnection.State <> ConnectionState.Closed) Then
        '        Try
        '            sccnnConnection.Close()
        '        Catch
        '        End Try
        '    End If

        '    Throw New ApplicationException("Los registros no pudieron ser leidos debido a un error de aplicación.", ex)

        'End Try

        'sccnnConnection.Dispose()
        'sccnnConnection = Nothing

        'Return dsFacturas
    End Function

    'Public Function SelectByDate(ByVal Fecha As DateTime, ByVal Almacen As String) As DataSet

    '    Try

    '        wsAbonoCreditoX = New wsAbonoCreditoDirecto.AbonoCreditoDirectoX

    '        If Not oParent.ApplicationContext.ApplicationConfiguration.WSUrl = String.Empty Then

    '            wsAbonoCreditoX.Url = oParent.ApplicationContext.ApplicationConfiguration.WSUrl.TrimEnd("/") _
    '& "/" & wsAbonoCreditoX.strURL.TrimStart("/")

    '        End If

    '        Return wsAbonoCreditoX.SelectByDate(Fecha, Almacen)

    '    Catch ex As Exception

    '    End Try

    'Dim m_strConnectionString As String = "packet size=4096;user id=sa;password=sa;data source=OPERACIONES;persist security info=False;initial catalog=CreditoDP"

    'Dim sccnnConnection As New SqlConnection(m_strConnectionString)

    'Dim sccmdSelectAll As SqlCommand
    'Dim scdaAbonosApartados As SqlDataAdapter
    'Dim dsAbonosApartados As DataSet

    'sccmdSelectAll = New SqlCommand
    'scdaAbonosApartados = New SqlDataAdapter
    'dsAbonosApartados = New DataSet("AbonosCreditoDirecto")

    'With sccmdSelectAll

    '    .Connection = sccnnConnection

    '    .CommandText = "[AbonosCreditoDirectoSelByDate]"
    '    .CommandType = System.Data.CommandType.StoredProcedure

    '    .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
    '    .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime, 8))
    'End With

    'scdaAbonosApartados.SelectCommand = sccmdSelectAll

    'Try

    '    sccnnConnection.Open()

    '    scdaAbonosApartados.SelectCommand.Parameters("@Fecha").Value = Fecha

    '    'Fill DataSet
    '    scdaAbonosApartados.Fill(dsAbonosApartados, "AbonosCreditoDirecto")

    '    sccnnConnection.Close()

    'Catch oSqlException As SqlException

    '    If (sccnnConnection.State <> ConnectionState.Closed) Then
    '        Try
    '            sccnnConnection.Close()
    '        Catch
    '        End Try
    '    End If

    '    Throw New ApplicationException("Los registros no pudieron ser leidos debido a un error de base de datos.", oSqlException)

    'Catch ex As Exception

    '    If (sccnnConnection.State <> ConnectionState.Closed) Then
    '        Try
    '            sccnnConnection.Close()
    '        Catch
    '        End Try
    '    End If

    '    Throw New ApplicationException("Los registros no pudieron ser leidos debido a un error de aplicación.", ex)

    'End Try

    'sccnnConnection.Dispose()
    'sccnnConnection = Nothing

    'Return dsAbonosApartados

    'End Function

    'Public Function SelectAbonosFacturas(ByVal AbonoID As Integer, ByVal CodAlmacen As String, ByVal CodCaja As String, ByVal Fecha As DateTime) As DataSet

    '    Try

    '        If Not oParent.ApplicationContext.ApplicationConfiguration.WSUrl = String.Empty Then

    '            wsAbonoCreditoX.Url = oParent.ApplicationContext.ApplicationConfiguration.WSUrl.TrimEnd("/") _
    '& "/" & wsAbonoCreditoX.strURL.TrimStart("/")

    '        End If

    '        Return wsAbonoCreditoX.SelectAbonosFacturas(AbonoID, CodAlmacen, CodCaja, Fecha)

    '    Catch ex As Exception

    '    End Try


    '    'Dim m_strConnectionString As String = "packet size=4096;user id=sa;password=sa;data source=OPERACIONES;persist security info=False;initial catalog=CreditoDP"

    '    'Dim sccnnConnection As New SqlConnection(m_strConnectionString)

    '    'Dim sccmdSelectAll As SqlCommand
    '    'Dim scdaAbonosApartados As SqlDataAdapter
    '    'Dim dsAbonosApartados As DataSet

    '    'sccmdSelectAll = New SqlCommand
    '    'scdaAbonosApartados = New SqlDataAdapter
    '    'dsAbonosApartados = New DataSet("AbonosCreditoDirecto")

    '    'With sccmdSelectAll

    '    '    .Connection = sccnnConnection

    '    '    .CommandText = "[AbonosCreditoDirectoSel]"
    '    '    .CommandType = System.Data.CommandType.StoredProcedure

    '    '    .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
    '    '    .Parameters.Add(New System.Data.SqlClient.SqlParameter("@AbonoID", System.Data.SqlDbType.TinyInt, 4))
    '    '    .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 3))
    '    '    .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar, 2))
    '    '    .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime, 8))
    '    'End With

    '    'scdaAbonosApartados.SelectCommand = sccmdSelectAll

    '    'Try

    '    '    sccnnConnection.Open()

    '    '    scdaAbonosApartados.SelectCommand.Parameters("@AbonoID").Value = AbonoID
    '    '    scdaAbonosApartados.SelectCommand.Parameters("@CodAlmacen").Value = CodAlmacen
    '    '    scdaAbonosApartados.SelectCommand.Parameters("@CodCaja").Value = CodCaja
    '    '    scdaAbonosApartados.SelectCommand.Parameters("@Fecha").Value = Fecha

    '    '    'Fill DataSet
    '    '    scdaAbonosApartados.Fill(dsAbonosApartados, "AbonosCreditoDirecto")

    '    '    sccnnConnection.Close()

    '    'Catch oSqlException As SqlException

    '    '    If (sccnnConnection.State <> ConnectionState.Closed) Then
    '    '        Try
    '    '            sccnnConnection.Close()
    '    '        Catch
    '    '        End Try
    '    '    End If

    '    '    Throw New ApplicationException("Los registros no pudieron ser leidos debido a un error de base de datos.", oSqlException)

    '    'Catch ex As Exception

    '    '    If (sccnnConnection.State <> ConnectionState.Closed) Then
    '    '        Try
    '    '            sccnnConnection.Close()
    '    '        Catch
    '    '        End Try
    '    '    End If

    '    '    Throw New ApplicationException("Los registros no pudieron ser leidos debido a un error de aplicación.", ex)

    '    'End Try

    '    'sccnnConnection.Dispose()
    '    'sccnnConnection = Nothing

    '    'Return dsAbonosApartados

    'End Function

    Public Function GetUltimoAbono(ByVal CodSegmentoCredito As String, ByVal AsociadoId As Integer) As AbonoDPVale

        Try

            Dim oAbonoDPValemgr As New AbonosDPValeManager(oParent.ApplicationContext)
            Dim abonodpvale As AbonoDPVale
            abonodpvale = oAbonoDPValemgr.Create  'New AbonosDPVale.AbonoDPVale(oParent)

            If Not oParent.ApplicationContext.ApplicationConfiguration.WSUrl = String.Empty Then

                '            wsAbonoCreditoX.Url = oParent.ApplicationContext.ApplicationConfiguration.WSUrl.TrimEnd("/") _
                '& "/" & wsAbonoCreditoX.strURL.TrimStart("/")

            End If

            'wsAbonoDPValeInfo = New wsAbonoCreditoDirecto.AbonoDPValeInfo
            'wsAbonoDPValeInfo = wsAbonoCreditoX.GetUltimoAbono(CodSegmentoCredito, AsociadoId)

            'If Not wsAbonoDPValeInfo Is Nothing Then

            '    If wsAbonoDPValeInfo.IDAbono > 0 Then

            '        abonodpvale.AsociadoID = wsAbonoDPValeInfo.AsociadoID
            '        abonodpvale.SetCodAlmacen(wsAbonoDPValeInfo.CodAlmacen)
            '        abonodpvale.SetCodCaja(wsAbonoDPValeInfo.CodCaja)
            '        abonodpvale.CodSegCred = wsAbonoDPValeInfo.CodSegCred
            '        abonodpvale.CodTipAbono = wsAbonoDPValeInfo.CodTipAbono
            '        abonodpvale.Detalle = wsAbonoDPValeInfo.Detalle
            '        abonodpvale.Fecha = wsAbonoDPValeInfo.Fecha
            '        abonodpvale.IDAbono = wsAbonoDPValeInfo.IDAbono
            '        abonodpvale.IDCliente = wsAbonoDPValeInfo.IDCliente
            '        abonodpvale.MontoPago = wsAbonoDPValeInfo.MontoPago
            '        abonodpvale.PagoMin = wsAbonoDPValeInfo.PagoMin
            '        abonodpvale.PlazaConsecutivo = wsAbonoDPValeInfo.PlazaConsecutivo
            '        abonodpvale.Referencia = wsAbonoDPValeInfo.Referencia
            '        abonodpvale.SaldNuevo = wsAbonoDPValeInfo.SaldNuevo
            '        abonodpvale.SaldoAnt = wsAbonoDPValeInfo.SaldoAnt
            '        abonodpvale.SaldoDPVale = wsAbonoDPValeInfo.SaldoDPVale
            '        abonodpvale.StatusRegistro = wsAbonoDPValeInfo.StatusRegistro
            '        abonodpvale.SetFecha(wsAbonoDPValeInfo.Fecha)
            '        abonodpvale.Bonificacion = wsAbonoDPValeInfo.Bonificacion

            '    End If

            'End If


            Return abonodpvale

        Catch ex As Exception

        End Try
    End Function


#End Region


#Region "SQL"

    Public Function SelectNombreBanco(ByVal strTipoPago As String, ByVal strCentro As String) As String()

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)


        Dim strResult(2) As String
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
                    strResult(0) = .GetString(0)
                    strResult(1) = .GetString(1)
                End With
                scsdrReader.Close()

            Else

                strResult(0) = String.Empty
                strResult(1) = String.Empty

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

    Public Function SeleccionaFolioFacturaDPBySDSAP(ByVal strCliente As String, ByVal strFolioSap As String) As String

        Dim strResult As String

        Dim sccnnDPTienda As New SqlConnection(m_strConnectionString)

        Dim sccmdFacturaFolioSel As SqlCommand
        sccmdFacturaFolioSel = New SqlCommand

        With sccmdFacturaFolioSel
            .CommandText = "[FacturaFolioSel]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Connection = sccnnDPTienda
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ClienteID", System.Data.SqlDbType.VarChar, 10))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioSAp", System.Data.SqlDbType.VarChar, 10))

            .Parameters("@ClienteID").Value = strCliente
            .Parameters("@FolioSAp").Value = strFolioSap
        End With

        Try
            sccnnDPTienda.Open()

            Dim scsdrReader As SqlDataReader

            scsdrReader = sccmdFacturaFolioSel.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.SingleRow)

            scsdrReader.Read()

            If (scsdrReader.HasRows) Then

                With scsdrReader
                    strResult = .GetInt32(0) 'FolioFacturaDP
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

        sccmdFacturaFolioSel.Dispose()
        sccmdFacturaFolioSel = Nothing

        sccnnDPTienda.Dispose()
        sccnnDPTienda = Nothing

        Return strResult
    End Function

    Public Function SeleccionaFolioFacturaDPBySDSAP(ByVal strFolioSap As String) As String

        Dim strResult As String

        Dim sccnnDPTienda As New SqlConnection(m_strConnectionString)

        Dim sccmdFacturaFolioSel As SqlCommand
        sccmdFacturaFolioSel = New SqlCommand

        With sccmdFacturaFolioSel
            .CommandText = "[FacturaFolioSelBYSD]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Connection = sccnnDPTienda
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioSAP", System.Data.SqlDbType.VarChar, 10))
            .Parameters("@FolioSAp").Value = strFolioSap
        End With

        Try
            sccnnDPTienda.Open()

            Dim scsdrReader As SqlDataReader

            scsdrReader = sccmdFacturaFolioSel.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.SingleRow)

            scsdrReader.Read()

            If (scsdrReader.HasRows) Then

                With scsdrReader
                    strResult = .GetInt32(0) 'FolioFacturaDP
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

        sccmdFacturaFolioSel.Dispose()
        sccmdFacturaFolioSel = Nothing

        sccnnDPTienda.Dispose()
        sccnnDPTienda = Nothing

        Return strResult
    End Function

    Public Function SeleccionaFolioFacturaDPByFISAP(ByVal strCliente As String, ByVal strFolioSap As String) As String

        Dim strResult As String

        Dim sccnnDPTienda As New SqlConnection(m_strConnectionString)

        Dim sccmdFacturaFolioSel As SqlCommand
        sccmdFacturaFolioSel = New SqlCommand

        With sccmdFacturaFolioSel
            .CommandText = "[FacturaFolioSelByFISAP]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Connection = sccnnDPTienda
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ClienteID", System.Data.SqlDbType.VarChar, 10))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioSAp", System.Data.SqlDbType.VarChar, 10))

            .Parameters("@ClienteID").Value = strCliente
            .Parameters("@FolioSAp").Value = strFolioSap
        End With

        Try
            sccnnDPTienda.Open()

            Dim scsdrReader As SqlDataReader

            scsdrReader = sccmdFacturaFolioSel.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.SingleRow)

            scsdrReader.Read()

            If (scsdrReader.HasRows) Then

                With scsdrReader
                    strResult = .GetInt32(0) 'FolioFacturaDP
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

        sccmdFacturaFolioSel.Dispose()
        sccmdFacturaFolioSel = Nothing

        sccnnDPTienda.Dispose()
        sccnnDPTienda = Nothing

        Return strResult
    End Function


    Public Function SeleccionaFolioSDSAPFactura(ByVal intFolioDp As Integer) As String

        Dim strResult As String

        Dim sccnnDPTienda As New SqlConnection(m_strConnectionString)

        Dim sccmdFacturaFolioSel As SqlCommand
        sccmdFacturaFolioSel = New SqlCommand

        With sccmdFacturaFolioSel
            .CommandText = "[FacturaFolioSAPSel]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Connection = sccnnDPTienda
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioFactura", System.Data.SqlDbType.Int, 4))

            .Parameters("@FolioFactura").Value = intFolioDp
        End With

        Try
            sccnnDPTienda.Open()

            Dim scsdrReader As SqlDataReader

            scsdrReader = sccmdFacturaFolioSel.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.SingleRow)

            scsdrReader.Read()

            If (scsdrReader.HasRows) Then

                With scsdrReader
                    strResult = .GetString(0) 'FolioFacturaSAP
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

        sccmdFacturaFolioSel.Dispose()
        sccmdFacturaFolioSel = Nothing

        sccnnDPTienda.Dispose()
        sccnnDPTienda = Nothing

        Return strResult
    End Function


    Public Function SeleccionaFolioSDSAPFactura(ByVal intFolioDp As Integer, ByVal CodCaja As String) As String

        Dim strResult As String

        Dim sccnnDPTienda As New SqlConnection(m_strConnectionString)

        Dim sccmdFacturaFolioSel As SqlCommand
        sccmdFacturaFolioSel = New SqlCommand

        With sccmdFacturaFolioSel
            .CommandText = "[FacturaFolioSAPSelByCaja]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Connection = sccnnDPTienda
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioFactura", System.Data.SqlDbType.Int, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Codcaja", System.Data.SqlDbType.VarChar, 2))

            .Parameters("@FolioFactura").Value = intFolioDp
            .Parameters("@CodCaja").Value = CodCaja
        End With

        Try
            sccnnDPTienda.Open()

            Dim scsdrReader As SqlDataReader

            scsdrReader = sccmdFacturaFolioSel.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.SingleRow)

            scsdrReader.Read()

            If (scsdrReader.HasRows) Then

                With scsdrReader
                    strResult = .GetString(0) 'FolioFacturaFISAP
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

        sccmdFacturaFolioSel.Dispose()
        sccmdFacturaFolioSel = Nothing

        sccnnDPTienda.Dispose()
        sccnnDPTienda = Nothing

        Return strResult
    End Function

    Public Function SeleccionaFolioNCByCaja(ByVal CodCaja As String) As Integer

        Dim strResult As Integer

        Dim sccnnDPTienda As New SqlConnection(m_strConnectionString)

        Dim sccmdFacturaFolioSel As SqlCommand
        sccmdFacturaFolioSel = New SqlCommand

        With sccmdFacturaFolioSel
            .CommandText = "[FolioNCByCaja]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Connection = sccnnDPTienda

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Codcaja", System.Data.SqlDbType.VarChar, 2))

            .Parameters("@CodCaja").Value = CodCaja
        End With

        Try
            sccnnDPTienda.Open()

            Dim scsdrReader As SqlDataReader

            scsdrReader = sccmdFacturaFolioSel.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.SingleRow)

            scsdrReader.Read()

            If (scsdrReader.HasRows) Then

                With scsdrReader
                    strResult = .GetValue(0) 'FolioNotaCredito
                End With
                scsdrReader.Close()

            Else

                strResult = 0

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

        sccmdFacturaFolioSel.Dispose()
        sccmdFacturaFolioSel = Nothing

        sccnnDPTienda.Dispose()
        sccnnDPTienda = Nothing

        Return strResult
    End Function


    Public Function SeleccionaFolioFISAPFactura(ByVal intFolioDp As Integer) As String

        Dim strResult As String

        Dim sccnnDPTienda As New SqlConnection(m_strConnectionString)

        Dim sccmdFacturaFolioSel As SqlCommand
        sccmdFacturaFolioSel = New SqlCommand

        With sccmdFacturaFolioSel
            .CommandText = "[FacturaFolioFISAPSel]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Connection = sccnnDPTienda
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioFactura", System.Data.SqlDbType.Int, 4))

            .Parameters("@FolioFactura").Value = intFolioDp
        End With

        Try
            sccnnDPTienda.Open()

            Dim scsdrReader As SqlDataReader

            scsdrReader = sccmdFacturaFolioSel.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.SingleRow)

            scsdrReader.Read()

            If (scsdrReader.HasRows) Then

                With scsdrReader
                    strResult = .GetString(0) 'FolioFacturaFISAP
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

        sccmdFacturaFolioSel.Dispose()
        sccmdFacturaFolioSel = Nothing

        sccnnDPTienda.Dispose()
        sccnnDPTienda = Nothing

        Return strResult
    End Function


    Public Sub UpdateCatalogoCajasAbonoCDT(ByVal dblAbono As Double, ByVal strOpc As String)

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                                 DataStorageConfiguration.GetConnectionString)

        Dim sccmdUpdate As SqlCommand
        sccmdUpdate = New SqlCommand

        With sccmdUpdate

            .Connection = sccnnConnection

            .CommandText = "[CatalogoCajasAbonoCDTUpd]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar, 2))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@AbonoCDT", System.Data.SqlDbType.Money, 8))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Opc", System.Data.SqlDbType.VarChar, 1))

        End With

        Try

            sccnnConnection.Open()

            With sccmdUpdate
                'Assign Parameters Values
                .Parameters("@CodCaja").Value = oParent.ApplicationContext.ApplicationConfiguration.NoCaja
                .Parameters("@AbonoCDT").Value = dblAbono
                .Parameters("@Opc").Value = strOpc

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

            Throw New ApplicationException("El Campo AbonoCDT [CatalogoCajas] no pudo ser actualizado debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("El Campo AbonoCDT [CatalogoCajas]no pudo ser Actualizado debido a un error de aplicación.", ex)

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

    End Sub


    Public Sub InsertAbonoCDT(ByVal strTienda As String, ByVal strCliente As String, ByVal dblImporte As Double, _
                                 ByVal strFacturaFI As String, ByVal strClaCobr As String, ByVal strBanco As String, _
                                ByVal strFactDpPro As String, ByVal strDocnumFB01 As String, ByVal strDocnumFB05 As String)

        Dim strResult As String

        Dim sccnnDPTienda As New SqlConnection(m_strConnectionString)

        Dim sccmdAbonoCDT As SqlCommand
        sccmdAbonoCDT = New SqlCommand

        With sccmdAbonoCDT
            .CommandText = "[AbonosCDTIns]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Connection = sccnnDPTienda

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ClienteID", System.Data.SqlDbType.VarChar, 10))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime, 8))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FacturaSAP", System.Data.SqlDbType.VarChar, 10))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FacturaDP", System.Data.SqlDbType.VarChar, 10))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Abono", System.Data.SqlDbType.Money, 8))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@DocnumFB01", System.Data.SqlDbType.VarChar, 15))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@DocnumFB05", System.Data.SqlDbType.VarChar, 15))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Banco", System.Data.SqlDbType.VarChar, 20))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Tienda", System.Data.SqlDbType.VarChar, 20))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ClabCobr", System.Data.SqlDbType.VarChar, 20))

            .Parameters("@ClienteID").Value = strCliente
            .Parameters("@Fecha").Value = Date.Now
            .Parameters("@FacturaSAP").Value = strFacturaFI
            .Parameters("@FacturaDP").Value = strFactDpPro
            .Parameters("@Abono").Value = dblImporte
            .Parameters("@DocnumFB01").Value = strDocnumFB01
            .Parameters("@DocnumFB05").Value = strDocnumFB05
            .Parameters("@Banco").Value = strBanco
            .Parameters("@Tienda").Value = strTienda
            .Parameters("@ClabCobr").Value = strClaCobr

        End With

        Try
            sccnnDPTienda.Open()

            sccmdAbonoCDT.ExecuteNonQuery()


        Catch oSqlException As SqlException

            If (sccnnDPTienda.State <> ConnectionState.Closed) Then
                Try
                    sccnnDPTienda.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("El Registro No pudo ser Insertado debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnDPTienda.State <> ConnectionState.Closed) Then
                Try
                    sccnnDPTienda.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("El Registro No pudo ser Insertado debido a un error de aplicación.", ex)

        End Try

        sccmdAbonoCDT.Dispose()
        sccmdAbonoCDT = Nothing

        sccnnDPTienda.Dispose()
        sccnnDPTienda = Nothing

    End Sub


    Public Sub InsertAbonoCDTDetalles(ByVal strAsociado As String, ByVal strTipoPago As String, ByVal strTerminal As String, ByVal dblMonto As Decimal, ByVal strTipoTarj As String, _
                                        ByVal strNumTar As String, ByVal strNumAutoriz As String, ByVal strFolioValeCaja As String)

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                                 DataStorageConfiguration.GetConnectionString)

        Dim sccmdUpdate As SqlCommand
        sccmdUpdate = New SqlCommand

        With sccmdUpdate

            .Connection = sccnnConnection

            .CommandText = "[AbonosCDTDetalleIns]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ClienteID", System.Data.SqlDbType.VarChar, 10))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TipoPago", System.Data.SqlDbType.VarChar, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Terminal", System.Data.SqlDbType.VarChar, 2))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Monto", System.Data.SqlDbType.Money, 8))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TipoTarjeta", System.Data.SqlDbType.VarChar, 2))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@NumTarjeta", System.Data.SqlDbType.VarChar, 20))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@NumAutorizacion", System.Data.SqlDbType.VarChar, 20))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioValecaja", System.Data.SqlDbType.VarChar, 20))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime, 8))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar, 2))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 4))


        End With

        Try

            sccnnConnection.Open()

            With sccmdUpdate
                'Assign Parameters Values
                .Parameters("@ClienteID").Value = strAsociado
                .Parameters("@TipoPago").Value = strTipoPago
                .Parameters("@Terminal").Value = strTerminal
                .Parameters("@Monto").Value = dblMonto
                .Parameters("@TipoTarjeta").Value = strTipoTarj
                .Parameters("@NumTarjeta").Value = strNumTar
                .Parameters("@NumAutorizacion").Value = strNumAutoriz
                .Parameters("@FolioValecaja").Value = strFolioValeCaja
                .Parameters("@Fecha").Value = Date.Now
                .Parameters("@CodCaja").Value = oParent.ApplicationContext.ApplicationConfiguration.NoCaja
                .Parameters("@CodAlmacen").Value = oParent.ApplicationContext.ApplicationConfiguration.Almacen
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

            Throw New ApplicationException("Registro no pudo ser insertado debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("Registro no pudo ser insertado debido a un error de aplicación.", ex)

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

    End Sub



    ''' <summary>
    '''     To Report
    ''' </summary>

    Public Function InsertAbonoCDTGeneral(ByVal strCliente As String, ByVal decAbono As Double, ByVal strNombre As String) As Integer

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                                      DataStorageConfiguration.GetConnectionString)

        Dim intAbonoID As Integer
        Dim sccmdUpdate As SqlCommand
        sccmdUpdate = New SqlCommand

        With sccmdUpdate

            .Connection = sccnnConnection

            .CommandText = "[AbonoCreditoDirectoIns]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@AbonoID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Output, False, CType(0, Byte), CType(0, Byte), "AbonoID", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar, 2))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ClienteID", System.Data.SqlDbType.VarChar, 10))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Nombre", System.Data.SqlDbType.VarChar, 50))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Monto", System.Data.SqlDbType.Decimal, 8))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime, 8))

        End With

        Try

            sccnnConnection.Open()

            With sccmdUpdate
                'Assign Parameters Values
                .Parameters("@CodCaja").Value = oParent.ApplicationContext.ApplicationConfiguration.NoCaja
                .Parameters("@CodAlmacen").Value = oParent.ApplicationContext.ApplicationConfiguration.Almacen
                .Parameters("@ClienteID").Value = strCliente
                .Parameters("@Nombre").Value = strNombre
                .Parameters("@Monto").Value = decAbono
                .Parameters("@Fecha").Value = Date.Now.ToShortDateString
                'Execute Command
                .ExecuteNonQuery()

                intAbonoID = .Parameters("@AbonoID").Value()
                Return intAbonoID
            End With

            sccnnConnection.Close()

        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("Registro no pudo ser insertado debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("Registro no pudo ser insertado debido a un error de aplicación.", ex)

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing
    End Function

    Public Sub InsertAbonoCDTDetalles(ByVal intAbonoID As Integer, ByVal strTipoPago As String, ByVal dblMonto As Double)

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                                 DataStorageConfiguration.GetConnectionString)

        Dim sccmdUpdate As SqlCommand
        sccmdUpdate = New SqlCommand

        With sccmdUpdate

            .Connection = sccnnConnection

            .CommandText = "[AbonoCDTFormasPagoIns]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@AbonoID", System.Data.SqlDbType.Int, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodFormaPago", System.Data.SqlDbType.VarChar, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@MontoPago", System.Data.SqlDbType.Money, 8))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime, 8))

        End With

        Try

            sccnnConnection.Open()

            With sccmdUpdate
                'Assign Parameters Values
                .Parameters("@AbonoID").Value = intAbonoID
                .Parameters("@CodFormaPago").Value = strTipoPago
                .Parameters("@MontoPago").Value = dblMonto
                .Parameters("@Fecha").Value = Date.Now.ToShortDateString
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

            Throw New ApplicationException("Registro no pudo ser insertado debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("Registro no pudo ser insertado debido a un error de aplicación.", ex)

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

    End Sub

    Public Sub InsertAbonoCDT(ByVal intAbonoID As Integer, ByVal intFactDpPro As Integer, ByVal strFolioSAP As String, ByVal decSaldo As Decimal, ByVal dblImporte As Double)

        Dim strResult As String

        Dim sccnnDPTienda As New SqlConnection(m_strConnectionString)

        Dim sccmdAbonoCDT As SqlCommand
        sccmdAbonoCDT = New SqlCommand

        With sccmdAbonoCDT
            .CommandText = "[AbonoCDTFacturasIns]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Connection = sccnnDPTienda

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@AbonoID", System.Data.SqlDbType.Int, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Foliofactura", System.Data.SqlDbType.Int, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioSAP", System.Data.SqlDbType.VarChar, 10))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@MontoAbono", System.Data.SqlDbType.Decimal, 8))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Saldo", System.Data.SqlDbType.Decimal, 8))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime, 8))


            .Parameters("@AbonoID").Value = intAbonoID
            .Parameters("@FolioFactura").Value = intFactDpPro
            .Parameters("@FolioSAP").Value = strFolioSAP
            .Parameters("@MontoAbono").Value = dblImporte
            .Parameters("@Saldo").Value = decSaldo - dblImporte
            .Parameters("@Fecha").Value = Date.Now.ToShortDateString


        End With

        Try
            sccnnDPTienda.Open()

            sccmdAbonoCDT.ExecuteNonQuery()


        Catch oSqlException As SqlException

            If (sccnnDPTienda.State <> ConnectionState.Closed) Then
                Try
                    sccnnDPTienda.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("El Registro No pudo ser Insertado debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnDPTienda.State <> ConnectionState.Closed) Then
                Try
                    sccnnDPTienda.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("El Registro No pudo ser Insertado debido a un error de aplicación.", ex)

        End Try

        sccmdAbonoCDT.Dispose()
        sccmdAbonoCDT = Nothing

        sccnnDPTienda.Dispose()
        sccnnDPTienda = Nothing

    End Sub

    Public Function AbonosCreditoDirectoSelByDate(ByVal Fecha As Date) As DataSet


        Dim scConnection As New SqlConnection(m_strConnectionString)
        Dim scReporteInventarioAdapter As New SqlDataAdapter
        Dim scRepVentasGeneral As New SqlCommand
        Dim dsResult As DataSet
        Dim dsFormatedResult As DataSet

        scReporteInventarioAdapter.SelectCommand = scRepVentasGeneral

        With scRepVentasGeneral


            .CommandText = "[AbonosCreditoDirectoSelByDate]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Connection = scConnection
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime, 8))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 3))

            .Parameters("@CodAlmacen").Value = oParent.ApplicationContext.ApplicationConfiguration.Almacen
            .Parameters("@Fecha").Value = Format(Fecha, "Short Date")




        End With

        Try

            scConnection.Open()

            dsResult = New DataSet
            dsFormatedResult = New DataSet

            scReporteInventarioAdapter.Fill(dsResult, "AbonosCreditoDirecto")

            dsFormatedResult = dsResult

        Catch ex As Exception

            Throw ex

        Finally

            If (scConnection.State <> ConnectionState.Closed) Then
                Try
                    scConnection.Close()
                Catch
                End Try
            End If

        End Try

        Return dsFormatedResult


    End Function

    Public Function AbonosCreditoDirectoFoliosGETDGW(ByVal AbonoID As Integer) As DataSet


        Dim scConnection As New SqlConnection(m_strConnectionString)
        Dim scReporteInventarioAdapter As New SqlDataAdapter
        Dim scRepVentasGeneral As New SqlCommand
        Dim dsResult As DataSet
        Dim dsFormatedResult As DataSet

        scReporteInventarioAdapter.SelectCommand = scRepVentasGeneral

        With scRepVentasGeneral


            .CommandText = "[AbonosCreditoDirectoFoliosGET]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Connection = scConnection
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@AbonoID", System.Data.SqlDbType.Int, 4))

            .Parameters("@AbonoID").Value = AbonoID
        End With

        Try

            scConnection.Open()

            dsResult = New DataSet
            dsFormatedResult = New DataSet

            scReporteInventarioAdapter.Fill(dsResult, "AbonosCreditoDirecto")

            dsFormatedResult = dsResult

        Catch ex As Exception

            Throw ex

        Finally

            If (scConnection.State <> ConnectionState.Closed) Then
                Try
                    scConnection.Close()
                Catch
                End Try
            End If

        End Try

        Return dsFormatedResult


    End Function
    Public Function AbonosCreditoDirectoFoliosGETDGWFB05(ByVal FolioSAP As String, ByVal FolioFactura As String, ByVal Monto As Decimal) As DataSet


        Dim scConnection As New SqlConnection(m_strConnectionString)
        Dim scReporteInventarioAdapter As New SqlDataAdapter
        Dim scRepVentasGeneral As New SqlCommand
        Dim dsResult As DataSet
        Dim dsFormatedResult As DataSet

        scReporteInventarioAdapter.SelectCommand = scRepVentasGeneral

        With scRepVentasGeneral


            .CommandText = "[AbonosCreditoDirectoFoliosGETFB05]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Connection = scConnection
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioSAP", System.Data.SqlDbType.VarChar, 10))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioFactura", System.Data.SqlDbType.VarChar, 10))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Monto", System.Data.SqlDbType.Decimal, 9))

            .Parameters("@FolioSAP").Value = FolioSAP
            .Parameters("@FolioFactura").Value = FolioFactura
            .Parameters("@Monto").Value = Monto
        End With

        Try

            scConnection.Open()

            dsResult = New DataSet
            dsFormatedResult = New DataSet

            scReporteInventarioAdapter.Fill(dsResult, "AbonosCreditoDirecto")

            dsFormatedResult = dsResult

        Catch ex As Exception

            Throw ex

        Finally

            If (scConnection.State <> ConnectionState.Closed) Then
                Try
                    scConnection.Close()
                Catch
                End Try
            End If

        End Try

        Return dsFormatedResult


    End Function
    Public Function AbonosCDTFacturasByIDAbonos(ByVal AbonoID As Integer) As DataSet


        Dim scConnection As New SqlConnection(m_strConnectionString)
        Dim scReporteInventarioAdapter As New SqlDataAdapter
        Dim scRepVentasGeneral As New SqlCommand
        Dim dsResult As DataSet
        Dim dsFormatedResult As DataSet

        scReporteInventarioAdapter.SelectCommand = scRepVentasGeneral

        With scRepVentasGeneral


            .CommandText = "[AbonosCDTFacturasSelByIDAbono]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Connection = scConnection
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@AbonoID", System.Data.SqlDbType.Int, 4))
            .Parameters("@AbonoID").Value = AbonoID





        End With

        Try

            scConnection.Open()

            dsResult = New DataSet
            dsFormatedResult = New DataSet

            scReporteInventarioAdapter.Fill(dsResult, "AbonosCreditoDirecto")

            dsFormatedResult = dsResult

        Catch ex As Exception

            Throw ex

        Finally

            If (scConnection.State <> ConnectionState.Closed) Then
                Try
                    scConnection.Close()
                Catch
                End Try
            End If

        End Try

        Return dsFormatedResult


    End Function
    Public Function FolioSAPGET(ByVal FolioFactura As String, ByVal CodCaja As String) As DataSet


        Dim scConnection As New SqlConnection(m_strConnectionString)
        Dim scReporteInventarioAdapter As New SqlDataAdapter
        Dim scRepVentasGeneral As New SqlCommand
        Dim dsResult As DataSet
        Dim dsFormatedResult As DataSet

        scReporteInventarioAdapter.SelectCommand = scRepVentasGeneral

        With scRepVentasGeneral


            .CommandText = "[FacturaFolioSAPGET]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Connection = scConnection
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioFactura", System.Data.SqlDbType.VarChar, 10))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar, 2))

            .Parameters("@FolioFactura").Value = FolioFactura
            .Parameters("@CodCaja").Value = CodCaja

        End With

        Try

            scConnection.Open()

            dsResult = New DataSet
            dsFormatedResult = New DataSet

            scReporteInventarioAdapter.Fill(dsResult)

            dsFormatedResult = dsResult

        Catch ex As Exception

            Throw ex

        Finally

            If (scConnection.State <> ConnectionState.Closed) Then
                Try
                    scConnection.Close()
                Catch
                End Try
            End If

        End Try

        Return dsFormatedResult


    End Function

    Public Function AbonosCDTFormasPagoByIDAbonos(ByVal AbonoID As Integer) As DataSet


        Dim scConnection As New SqlConnection(m_strConnectionString)
        Dim scReporteInventarioAdapter As New SqlDataAdapter
        Dim scRepVentasGeneral As New SqlCommand
        Dim dsResult As DataSet
        Dim dsFormatedResult As DataSet

        scReporteInventarioAdapter.SelectCommand = scRepVentasGeneral

        With scRepVentasGeneral


            .CommandText = "[AbonosCDTFormasPagoSelByIDAbono]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Connection = scConnection
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@AbonoID", System.Data.SqlDbType.Int, 4))
            .Parameters("@AbonoID").Value = AbonoID





        End With

        Try

            scConnection.Open()

            dsResult = New DataSet
            dsFormatedResult = New DataSet

            scReporteInventarioAdapter.Fill(dsResult, "AbonosCreditoDirecto")

            dsFormatedResult = dsResult

        Catch ex As Exception

            Throw ex

        Finally

            If (scConnection.State <> ConnectionState.Closed) Then
                Try
                    scConnection.Close()
                Catch
                End Try
            End If

        End Try

        Return dsFormatedResult


    End Function

#End Region

End Class
