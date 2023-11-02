Imports System.Data.SqlClient
Public Class AbonoDPValeDataGateWay2


    Private oParent As AbonosDPValeManager

    'Private wsEstadoDeCuentaAsociado As New wsEstadoDeCuentaAsociado.EstadodeCuentaAsociado
    'Private wsMovimientoInfo As New wsEstadoDeCuentaAsociado.MovimientosInfo
    'Private wsAbonoDPVale As New wsAbonoDPVale.AbonosDportenisVale
    'Private wsAbonoDPValeInfo As New wsAbonoDPVale.AbonoDPValeInfo





#Region "Constructors / Destructors"

    Public Sub New(ByVal Parent As AbonosDPValeManager)

        oParent = Parent

        'If Not oParent.ApplicationContext.ApplicationConfiguration.WSUrl = String.Empty Then
        '    wsEstadoDeCuentaAsociado.Url = oParent.ApplicationContext.ApplicationConfiguration.WSUrl.TrimEnd("/") _
        '            & "/" & wsEstadoDeCuentaAsociado.strURL.TrimStart("/")

        '    wsAbonoDPVale.Url = oParent.ApplicationContext.ApplicationConfiguration.WSUrl.TrimEnd("/") _
        '    & "/" & wsAbonoDPVale.strURL.TrimStart("/")
        'End If

    End Sub

#End Region

#Region "Metodos"

    'Public Sub LoadwsAbonoDPValeInfo(ByVal AbonoDPVale As AbonoDPVale)

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
    '    wsAbonoDPValeInfo.Bonificacion = AbonoDPVale.Bonificacion


    'End Sub

    'Public Sub Insert(ByVal AbonoDPVale As AbonoDPVale)

    '    Try

    '        LoadwsAbonoDPValeInfo(AbonoDPVale)
    '        wsAbonoDPValeInfo = wsAbonoDPVale.Insert(wsAbonoDPValeInfo, oParent.ApplicationContext.ApplicationConfiguration.IVA)

    '        AbonoDPVale.IDAbono = wsAbonoDPValeInfo.IDAbono
    '        AbonoDPVale.Fecha = wsAbonoDPValeInfo.Fecha

    '    Catch ex As Exception

    '        Throw New ApplicationException("El registro no pudo ser insertado debido a un error de aplicación.", ex)

    '    Catch oSqlException As SqlException

    '        Throw New ApplicationException("El registro no pudo ser insertado debido a un error de base de datos.", oSqlException)

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
    '    '        .Parameters("@PlazaConsecutivo").Value = AbonoDPVale.PlazaConsecutivo
    '    '        .Parameters("@Referencia").Value = AbonoDPVale.Referencia

    '    '        'Execute Command
    '    '        .ExecuteNonQuery()

    '    '        'Actualizar.
    '    '        AbonoDPVale.IDAbono = .Parameters("@AbonoID").Value
    '    '        AbonoDPVale.ResetStateNew()

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


    '    '    For Each odrFormaPagp In AbonoDPVale.Detalle.Tables(0).Rows



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


    '    '    'Reset New State of Estado Object 
    '    '    AbonoDPVale.ResetStateNew()
    '    '    AbonoDPVale.ResetStateDirty()

    '    '    sccnnConnection.Close()

    '    '    '''Cambios Cristina
    '    '    wsMovimientoInfo.Abono = AbonoDPVale.MontoPago - AbonoDPVale.Bonificacion
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
    '    '    wsEstadoDeCuentaAsociado.InsertMovimiento("v", wsMovimientoInfo)

    '    '    If AbonoDPVale.Bonificacion > 0 Then
    '    '        wsMovimientoInfo.Abono = AbonoDPVale.Bonificacion
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
    '    '        wsEstadoDeCuentaAsociado.InsertMovimiento("v", wsMovimientoInfo)
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

    'End Sub

    'Public Sub Update(ByVal AbonoDPVale As AbonoDPVale)

    '    Dim m_strConnectionString As String = _
    '    "packet size=4096;user id=sa;password=sa;data source=OPERACIONES;persist security info=False;initial catalog=CreditoDP"


    '    Dim sccnnConnection As New SqlConnection(m_strConnectionString)

    '    Dim sccmdUpdate As SqlCommand
    '    sccmdUpdate = New SqlCommand

    '    Dim sccmdDelete As SqlCommand
    '    sccmdDelete = New SqlCommand

    '    With sccmdUpdate

    '        .Connection = sccnnConnection

    '        .CommandText = "[AbonosUpd]"
    '        .CommandType = System.Data.CommandType.StoredProcedure



    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@AbonoID", System.Data.SqlDbType.Int, 4))
    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 3))
    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar, 2))
    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@AsociadoID", System.Data.SqlDbType.Int, 4))
    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ClienteID", System.Data.SqlDbType.Int, 4))
    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodSegmentoCredito", System.Data.SqlDbType.VarChar, 3))
    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodTipoAbono", System.Data.SqlDbType.Int, 4))
    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@SaldoAnterior", System.Data.SqlDbType.Money, 4))
    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@PagoMinimo", System.Data.SqlDbType.Money, 4))
    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@MontoPago", System.Data.SqlDbType.Money, 4))
    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@SaldoNuevo", System.Data.SqlDbType.Money, 4))
    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Usuario", System.Data.SqlDbType.VarChar, 12))
    '        'OutPut :
    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime))
    '        .Parameters("@Fecha").Direction = ParameterDirection.Output
    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@StatusRegistro", System.Data.SqlDbType.Bit, 1))
    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@PlazaConsecutivo", System.Data.SqlDbType.VarChar, 30))
    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Referencia", System.Data.SqlDbType.VarChar, 15))


    '    End With

    '    Try

    '        sccnnConnection.Open()

    '        With sccmdUpdate
    '            'Assign Parameters Values
    '            .Parameters("@AbonoID").Value = AbonoDPVale.IDAbono
    '            .Parameters("@CodAlmacen").Value = AbonoDPVale.CodAlmacen
    '            .Parameters("@CodCaja").Value = AbonoDPVale.CodCaja
    '            .Parameters("@AsociadoID").Value = AbonoDPVale.AsociadoID
    '            .Parameters("@ClienteID").Value = AbonoDPVale.IDCliente
    '            .Parameters("@CodSegmentoCredito").Value = AbonoDPVale.CodSegCred
    '            .Parameters("@CodTipoAbono").Value = AbonoDPVale.CodTipAbono
    '            .Parameters("@SaldoAnterior").Value = AbonoDPVale.SaldoAnt
    '            .Parameters("@PagoMinimo").Value = AbonoDPVale.PagoMin
    '            .Parameters("@MontoPago").Value = AbonoDPVale.MontoPago
    '            .Parameters("@SaldoNuevo").Value = AbonoDPVale.SaldNuevo
    '            .Parameters("@Usuario").Value = AbonoDPVale.Usuario
    '            .Parameters("@Fecha").Value = Date.Today
    '            .Parameters("@StatusRegistro").Value = AbonoDPVale.StatusRegistro
    '            .Parameters("@PlazaConsecutivo").Value = AbonoDPVale.PlazaConsecutivo
    '            .Parameters("@Referencia").Value = AbonoDPVale.Referencia
    '            'Execute Command
    '            .ExecuteNonQuery()

    '            'Assign Other Values
    '            AbonoDPVale.SetFecha(.Parameters("@Fecha").Value)

    '        End With

    '        'Forma de Pago :

    '        'Eliminar los Registros Tabla AbonosFormasPago

    '        With sccmdDelete

    '            .Connection = sccnnConnection

    '            .CommandText = "[AbonosFormasPagoDel]"
    '            .CommandType = System.Data.CommandType.StoredProcedure

    '            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@AbonoFormaPagoID", System.Data.SqlDbType.Int, 4))
    '            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@SaldoDPVale", System.Data.SqlDbType.Money, 8))
    '            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@AsociadoID", System.Data.SqlDbType.Int, 4))

    '            'Assign Parameters Values
    '            .Parameters("@AbonoFormaPagoID").Value = AbonoDPVale.IDAbono
    '            .Parameters("@SaldoDPVale").Value = AbonoDPVale.SaldoDPVale
    '            .Parameters("@AsociadoID").Value = AbonoDPVale.AsociadoID

    '            .ExecuteNonQuery()

    '        End With

    '        sccmdUpdate.Dispose()
    '        sccmdUpdate = Nothing

    '        sccmdUpdate = New SqlCommand

    '        With sccmdUpdate

    '            .Connection = sccnnConnection

    '            .CommandText = "[AbonosFormasPagoIns]"
    '            .CommandType = System.Data.CommandType.StoredProcedure

    '            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@AbonoFormaPagoID", System.Data.SqlDbType.Int))
    '            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@AbonoID", System.Data.SqlDbType.Int, 4))
    '            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodFormaPago", System.Data.SqlDbType.VarChar, 1))
    '            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Monto", System.Data.SqlDbType.Money, 4))
    '            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodTipoTarjeta", System.Data.SqlDbType.VarChar, 2))
    '            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodBanco", System.Data.SqlDbType.VarChar, 4))
    '            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@NumeroAutorizacion", System.Data.SqlDbType.VarChar, 20))
    '            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@NumeroTarjeta", System.Data.SqlDbType.VarChar, 20))
    '            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ComisionBancaria", System.Data.SqlDbType.Money, 4))
    '            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Ingreso", System.Data.SqlDbType.Money, 4))
    '            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@IVA", System.Data.SqlDbType.Money, 4))
    '            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Usuario", System.Data.SqlDbType.VarChar, 12))
    '            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime, 8))
    '            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@StatusRegistro", System.Data.SqlDbType.Bit, 1))
    '            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@SaldoDPVale", System.Data.SqlDbType.Money, 8))
    '            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@AsociadoID", System.Data.SqlDbType.Int, 4))

    '        End With

    '        Dim odrFormaPagp As DataRow

    '        For Each odrFormaPagp In AbonoDPVale.Detalle.Tables(0).Rows

    '            With sccmdUpdate
    '                .Parameters("@AbonoFormaPagoID").Value = AbonoDPVale.IDAbono
    '                .Parameters("@AbonoID").Value = AbonoDPVale.IDAbono
    '                .Parameters("@CodFormaPago").Value = odrFormaPagp("IDFormaPago")
    '                .Parameters("@Monto").Value = odrFormaPagp("Monto")
    '                .Parameters("@CodTipoTarjeta").Value = odrFormaPagp("IDTipoTarjeta")
    '                .Parameters("@CodBanco").Value = odrFormaPagp("IDBanco")
    '                .Parameters("@NumeroAutorizacion").Value = odrFormaPagp("NumAutorizacion")
    '                .Parameters("@NumeroTarjeta").Value = odrFormaPagp("NumTarjeta")
    '                .Parameters("@ComisionBancaria").Value = odrFormaPagp("Comision")
    '                .Parameters("@Ingreso").Value = odrFormaPagp("Total")
    '                .Parameters("@IVA").Value = 0
    '                .Parameters("@Usuario").Value = AbonoDPVale.Usuario 'oParent.ApplicationContext.Security.CurrentUser.Name
    '                .Parameters("@Fecha").Value = Date.Today
    '                .Parameters("@StatusRegistro").Value = AbonoDPVale.StatusRegistro
    '                .Parameters("@SaldoDPVale").Value = AbonoDPVale.SaldoDPVale
    '                .Parameters("@AsociadoID").Value = AbonoDPVale.AsociadoID

    '                .ExecuteNonQuery()

    '            End With

    '        Next

    '        'Reset New State of Estado Object 
    '        AbonoDPVale.ResetStateDirty()

    '        sccnnConnection.Close()

    '    Catch oSqlException As SqlException

    '        If (sccnnConnection.State <> ConnectionState.Closed) Then
    '            Try
    '                sccnnConnection.Close()
    '            Catch
    '            End Try
    '        End If

    '        Throw New ApplicationException("El registro no pudo ser actualizado debido a un error de base de datos.", oSqlException)

    '    Catch ex As Exception

    '        If (sccnnConnection.State <> ConnectionState.Closed) Then
    '            Try
    '                sccnnConnection.Close()
    '            Catch
    '            End Try
    '        End If

    '        Throw New ApplicationException("El registro no pudo ser actualizado debido a un error de aplicación.", ex)

    '    End Try

    '    sccnnConnection.Dispose()
    '    sccnnConnection = Nothing

    'End Sub

    'Public Sub Delete(ByVal oAbonoDPVale As AbonoDPVale)

    '    Try

    '        LoadwsAbonoDPValeInfo(oAbonoDPVale)
    '        wsAbonoDPVale.Delete(wsAbonoDPValeInfo)

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
    '    '        .Parameters("@AsociadoID").Value = oAbonoDPVale.AsociadoID


    '    '        'Execute Command
    '    '        .ExecuteNonQuery()


    '    '        '''Cambios Cristina
    '    '        wsMovimientoInfo.Abono = 0
    '    '        wsMovimientoInfo.AsociadoID = oAbonoDPVale.AsociadoID
    '    '        wsMovimientoInfo.Año = oAbonoDPVale.Fecha.Year
    '    '        wsMovimientoInfo.Cargo = oAbonoDPVale.MontoPago - oAbonoDPVale.Bonificacion
    '    '        wsMovimientoInfo.CodigoAlmacen = oAbonoDPVale.CodAlmacen
    '    '        wsMovimientoInfo.CodigoCaja = oAbonoDPVale.CodCaja
    '    '        wsMovimientoInfo.FechaMovimiento = oAbonoDPVale.Fecha
    '    '        wsMovimientoInfo.FolioMovimiento = oAbonoDPVale.IDAbono
    '    '        wsMovimientoInfo.Mes = oAbonoDPVale.Fecha.Month
    '    '        wsMovimientoInfo.StatusRegistro = True
    '    '        wsMovimientoInfo.TipoDocumento = "CANC ABONO"
    '    '        wsMovimientoInfo.Usuario = oAbonoDPVale.Usuario
    '    '        wsEstadoDeCuentaAsociado.InsertMovimiento("v", wsMovimientoInfo)

    '    '        If oAbonoDPVale.Bonificacion > 0 Then
    '    '            wsMovimientoInfo.Abono = 0
    '    '            wsMovimientoInfo.AsociadoID = oAbonoDPVale.AsociadoID
    '    '            wsMovimientoInfo.Año = oAbonoDPVale.Fecha.Year
    '    '            wsMovimientoInfo.Cargo = oAbonoDPVale.Bonificacion
    '    '            wsMovimientoInfo.CodigoAlmacen = oAbonoDPVale.CodAlmacen
    '    '            wsMovimientoInfo.CodigoCaja = oAbonoDPVale.CodCaja
    '    '            wsMovimientoInfo.FechaMovimiento = oAbonoDPVale.Fecha
    '    '            wsMovimientoInfo.FolioMovimiento = oAbonoDPVale.IDAbono
    '    '            wsMovimientoInfo.Mes = oAbonoDPVale.Fecha.Month
    '    '            wsMovimientoInfo.StatusRegistro = True
    '    '            wsMovimientoInfo.TipoDocumento = "CANC BONIFICACION"
    '    '            wsMovimientoInfo.Usuario = oAbonoDPVale.Usuario
    '    '            wsEstadoDeCuentaAsociado.InsertMovimiento("v", wsMovimientoInfo)
    '    '        End If

    '    '        'wsSaldosInfo.AsociadoID = AbonoDPVale.AsociadoID
    '    '        'wsSaldosInfo.Abono = AbonoDPVale.MontoPago


    '    '        'wsEstadoDeCuentaAsociado.InsertSaldo("dpvale", wsSaldosInfo)
    '    '        '''Cambios Cristina
    '    '    End With

    '    '    sccnnConnection.Close()

    '    'Catch oSqlException As SqlException

    '    '    If (sccnnConnection.State <> ConnectionState.Closed) Then
    '    '        Try
    '    '            sccnnConnection.Close()
    '    '        Catch
    '    '        End Try
    '    '    End If

    '    '    'Throw New ApplicationException("El registro no pudo ser insertado debido a un error de base de datos.", oSqlException)

    '    'Catch ex As Exception

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

    'End Sub

    'Public Function SelectCreditoDPValeAll(ByVal OnlyEnabledRecords As Boolean) As DataSet

    '    Try

    '        Return wsAbonoDPVale.SelectCreditoDPValeAll(OnlyEnabledRecords)

    '    Catch oSqlException As SqlException



    '        Throw New ApplicationException("El registro no pudo ser leido debido a un error de base de datos.", oSqlException)

    '    Catch ex As Exception



    '        Throw New ApplicationException("El registro no pudo ser leído debido a un error de aplicación.", ex)

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

    '    '    .CommandText = "[CreditoDPValeSelAll]"
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
#End Region

    'Public Function GetUltimoAbono(ByVal CodSegmentoCredito As String, ByVal AsociadoId As Integer) As AbonoDPVale

    '    Try

    '        Dim AbonoDPVale As New AbonoDPVale(oParent)
    '        wsAbonoDPValeInfo = wsAbonoDPVale.GetUltimoAbono(CodSegmentoCredito, AsociadoId)

    '        If Not wsAbonoDPVale Is Nothing Then

    '            AbonoDPVale.AsociadoID = wsAbonoDPValeInfo.AsociadoID
    '            AbonoDPVale.SetCodAlmacen(wsAbonoDPValeInfo.CodAlmacen)
    '            AbonoDPVale.SetCodCaja(wsAbonoDPValeInfo.CodCaja)
    '            AbonoDPVale.CodSegCred = wsAbonoDPValeInfo.CodSegCred
    '            AbonoDPVale.CodTipAbono = wsAbonoDPValeInfo.CodTipAbono
    '            AbonoDPVale.Detalle = wsAbonoDPValeInfo.Detalle
    '            AbonoDPVale.Fecha = wsAbonoDPValeInfo.Fecha
    '            AbonoDPVale.IDAbono = wsAbonoDPValeInfo.IDAbono
    '            AbonoDPVale.IDCliente = wsAbonoDPValeInfo.IDCliente
    '            AbonoDPVale.MontoPago = wsAbonoDPValeInfo.MontoPago
    '            AbonoDPVale.PagoMin = wsAbonoDPValeInfo.PagoMin
    '            AbonoDPVale.PlazaConsecutivo = wsAbonoDPValeInfo.PlazaConsecutivo
    '            AbonoDPVale.Referencia = wsAbonoDPValeInfo.Referencia
    '            AbonoDPVale.SaldNuevo = wsAbonoDPValeInfo.SaldNuevo
    '            AbonoDPVale.SaldoAnt = wsAbonoDPValeInfo.SaldoAnt
    '            AbonoDPVale.SaldoDPVale = wsAbonoDPValeInfo.SaldoDPVale
    '            AbonoDPVale.StatusRegistro = wsAbonoDPValeInfo.StatusRegistro
    '            AbonoDPVale.SetFecha(wsAbonoDPValeInfo.Fecha)
    '            AbonoDPVale.Bonificacion = wsAbonoDPValeInfo.Bonificacion

    '        End If


    '        Return AbonoDPVale

    '    Catch ex As Exception

    '    End Try


    '    'Dim m_strConnectionString As String = "packet size=4096;user id=sa;password=sa;data source=OPERACIONES;persist security info=False;initial catalog=CreditoDP"

    '    'Dim sccnnConnection As New SqlConnection(m_strConnectionString)

    '    'Dim sccmdSelect As SqlCommand
    '    'Dim scdrReader As SqlDataReader

    '    'sccmdSelect = New SqlCommand

    '    'Dim oResult As New AbonoDPVale(oParent)

    '    'With sccmdSelect

    '    '    .Connection = sccnnConnection

    '    '    .CommandText = "[UltimoAbonoSel]"
    '    '    .CommandType = System.Data.CommandType.StoredProcedure

    '    '    .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
    '    '    .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodSegmentoCredito", System.Data.SqlDbType.VarChar, 3))
    '    '    .Parameters.Add(New System.Data.SqlClient.SqlParameter("@AsociadoID", System.Data.SqlDbType.Int, 4))

    '    'End With

    '    'Try

    '    '    sccnnConnection.Open()

    '    '    With sccmdSelect
    '    '        'Asignamos Valor al Parámetro
    '    '        .Parameters("@CodSegmentoCredito").Value = CodSegmentoCredito
    '    '        .Parameters("@AsociadoID").Value = AsociadoId

    '    '        'Ejecutamos Comando
    '    '        scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

    '    '        'Asignamos Valores al Reader
    '    '        scdrReader.Read()

    '    '        If (scdrReader.HasRows) Then

    '    '            With scdrReader


    '    '                oResult.IDAbono = .GetInt32(.GetOrdinal("AbonoID"))
    '    '                oResult.SetCodAlmacen(.GetString(.GetOrdinal("CodAlmacen")))
    '    '                oResult.SetCodCaja(.GetString(.GetOrdinal("CodCaja")))
    '    '                oResult.AsociadoID = .GetInt32(.GetOrdinal("AsociadoID"))
    '    '                oResult.CodSegCred = .GetString(.GetOrdinal("CodSegmentoCredito"))
    '    '                oResult.CodTipAbono = .GetInt32(.GetOrdinal("CodTipoAbono"))
    '    '                oResult.SaldoAnt = .GetDecimal(.GetOrdinal("SaldoAnterior"))
    '    '                oResult.PagoMin = .GetDecimal(.GetOrdinal("PagoMinimo"))
    '    '                oResult.MontoPago = .GetDecimal(.GetOrdinal("MontoPago"))
    '    '                oResult.SaldNuevo = .GetDecimal(.GetOrdinal("SaldoNuevo"))
    '    '                oResult.SetUsuario(.GetString(.GetOrdinal("Usuario")))
    '    '                oResult.SetFecha(.GetDateTime(.GetOrdinal("Fecha")))
    '    '                oResult.StatusRegistro = .GetBoolean(.GetOrdinal("StatusRegistro"))
    '    '                oResult.Referencia = .GetString(.GetOrdinal("Referencia"))
    '    '                oResult.PlazaConsecutivo = .GetString(.GetOrdinal("PlazaConsecutivo"))

    '    '                'Actualizamos Status del Objeto
    '    '                oResult.ResetStateNew()
    '    '                oResult.SetStateDirty()

    '    '                'Seleccionamos Facturas
    '    '                oResult.Detalle = SelectDetalleByID(oResult.IDAbono)

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

    'Private Function SelectDetalleByID(ByVal AbonoID As Integer) As DataSet



    '    'Dim m_strConnectionString As String = "packet size=4096;user id=sa;password=sa;data source=OPERACIONES;persist security info=False;initial catalog=CreditoDP"

    '    'Dim sccnnConnection As New SqlConnection(m_strConnectionString)

    '    'Dim sccmdSelectAll As SqlCommand
    '    'Dim scdaFacturas As SqlDataAdapter
    '    'Dim dsDetalle As DataSet

    '    'sccmdSelectAll = New SqlCommand
    '    'scdaFacturas = New SqlDataAdapter
    '    'dsDetalle = New DataSet("FormasPago")

    '    'With sccmdSelectAll

    '    '    .Connection = sccnnConnection

    '    '    .CommandText = "[AbonosFormasPagoSelByID]"
    '    '    .CommandType = System.Data.CommandType.StoredProcedure

    '    '    .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
    '    '    .Parameters.Add(New System.Data.SqlClient.SqlParameter("@AbonoID", System.Data.SqlDbType.Int, 3))

    '    '    .Parameters("@AbonoID").Value = AbonoID
    '    'End With

    '    'scdaFacturas.SelectCommand = sccmdSelectAll

    '    'Try

    '    '    sccnnConnection.Open()

    '    '    'Fill DataSet
    '    '    scdaFacturas.Fill(dsDetalle, "FormasPago")

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

    '    'Return dsDetalle

    'End Function


End Class
