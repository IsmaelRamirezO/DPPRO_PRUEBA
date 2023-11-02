Imports System.Data.SqlClient
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos
Imports DportenisPro.DPTienda.ApplicationUnits.Asociados
Imports DportenisPro.DPTienda.ApplicationUnits.Facturas
Imports DportenisPro.DPTienda.ApplicationUnits.TiposVenta
Imports DportenisPro.DPTienda.ApplicationUnits.Clientes

Imports System.DBNull

Imports DportenisPro.DPTienda.ApplicationUnits.ConfiguracionSAPAU
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU

Imports System.IO
Imports System.Web.Mail
Imports System.Web.Util
Imports System.Collections.Generic

Public Class NotasCreditoMasivoDataGateway
    Inherits NotasCreditoDataGateway

    ''Valores Producción
    Private Const I_MANDANTE As String = "600"
    Private Const I_KUNNR As String = "50000070"
    Private Const I_FACTURA As String = "NCAFS"

    'Valores QA
    'Private Const I_MANDANTE As String = "400"
    'Private Const I_KUNNR As String = "50000060"
    'Private Const I_FACTURA As String = "NCAFS_2"

    Public Sub New(ByVal Parent As NotasCreditoManager)
        MyBase.New(Parent)
    End Sub



    Public Overrides Sub DevolucionDPVale(ByVal pNotaCredito As NotaCredito, Optional ByVal EsSiHay As Boolean = False, Optional ByVal FolioPedido As String = "", Optional ByRef strError As String = "")
        Dim intFacturaID As Integer ' Factura DPPRO.
        Dim decDevDPVL As Decimal 'Aqui tendremos cuanto hay que descontar del credito en SAP.
        Dim decMontoNoCancelado As Decimal 'Contiene el monto disponible para la cancelacion.
        ''Primer Paso.- Validar que la forma de pago Exisa.
        'FolioReferencia<- En este campo se tiene el folio de factura DPPRO
        intFacturaID = pNotaCredito.Detalle.Tables(0).Rows(0)("FacturaID")
        If (ValidarExistenciaFormaPago(intFacturaID, "DPVL") = True) Then
            decMontoNoCancelado = ExtraerMontoNoCancelado(intFacturaID, "DPVL")
            If decMontoNoCancelado = 0 Then
                decDevDPVL = 0 'Si la forma de pago ya fue consumida por otras devoluciones entonces no descontamos saldo del credito.
            Else
                If pNotaCredito.Importe > decMontoNoCancelado Then
                    decDevDPVL = decMontoNoCancelado
                Else
                    decDevDPVL = pNotaCredito.Importe
                End If
            End If
        Else
            decDevDPVL = 0 'Si no existe la forma de pago entonces no descontamos saldo del credito.
        End If
        'TODO: Erick.-Fin Validamos Monto Devolucion Forma Pago DPortenis Vale'

        '-------------------------------------------------------------------------------------------------------------
        'JNAVA (19.02.2015): Si es Devolucion con DPVale del SI HAY, determinamos en base al pedido el MontoDPVL
        '-------------------------------------------------------------------------------------------------------------
        If EsSiHay Then
            If FolioPedido.Trim = "" Then
                decDevDPVL = 0
            End If
        End If
        Try

            Dim strCodCaja As String

            'Fin Tablas
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
                strError = "Proceso SAP: No se pudo conectar con Servidor DPVALE. Verifique Configuración."
                Exit Sub
            Else
                '*****************************************************
                'Call RFC function ZBAPI_VALIDA_DPVALE
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZBAPISD17_DEV_VENTAS_DPVL_2")
                If FolioPedido.Trim <> "" Then
                    func.Exports("I_FOLIOPEDIDO").ParamValue = FolioPedido.Trim
                End If
                func.Exports("I_MONDPVL").ParamValue = decDevDPVL
                func.Exports("CLASEPEDIDO").ParamValue = "ZDEV"
                func.Exports("OFICINAVTA").ParamValue = "T" & pNotaCredito.AlmacenID
                func.Exports("I_Fecha").ParamValue = Format(pNotaCredito.Fecha, "dd/MM/yyyy")
                func.Exports("I_AGENTE").ParamValue = pNotaCredito.PlayerID
                If oParent.ApplicationContext.ApplicationConfiguration.Almacen = "053" Then
                    func.Exports("I_WERKS").ParamValue = "T053"
                Else
                    func.Exports("I_WERKS").ParamValue = "T" & pNotaCredito.AlmacenID
                End If
                func.Exports("I_CREDITO").ParamValue = "N"
                If pNotaCredito.ClienteID.PadLeft(10, "0") = "1".PadLeft(10, "0") Then
                    'se manda vacio por que el erick ya lo agarra desde sap
                    func.Exports("I_KUNNR").ParamValue = String.Empty
                End If
                func.Exports("I_KUNNR").ParamValue = I_KUNNR
                func.Exports("I_ZONAVTA").ParamValue = "EFEC"
                Dim i As Integer = 0
                Dim T_DATOSDET As ERPConnect.RFCTable = func.Tables("DATOSDET")
                Dim R_Lines As ERPConnect.RFCStructure
                For Each row As DataRow In pNotaCredito.Detalle.Tables(0).Rows
                    i += i
                    R_Lines = T_DATOSDET.AddRow()
                    R_Lines("Folio") = "2" & oParent.ApplicationContext.ApplicationConfiguration.Almacen
                    R_Lines("MATNR") = row("CodArticulo")
                    R_Lines("Cantidad") = row("Cantidad")
                    If IsNumeric(row("Numero")) Then
                        R_Lines("TALLA") = Format(CDec(row("Numero")), "##.0")
                    Else
                        R_Lines("TALLA") = row("Numero")
                    End If

                    strCodCaja = row!CodCaja
                Next

                Dim T_CDescuentos As ERPConnect.RFCTable = func.Tables("CONDICIONES")
                i = 0
                For Each row As DataRow In pNotaCredito.Detalle.Tables(0).Rows
                    i += i
                    Dim R_CLines As ERPConnect.RFCStructure = T_CDescuentos.AddRow()
                    R_CLines("Folio") = "2" & oParent.ApplicationContext.ApplicationConfiguration.Almacen
                    R_CLines("MATNR") = row("CodArticulo")
                    R_CLines("Condicion") = "ZDP4"
                    R_CLines("Importe") = row("Descuento")
                    ''Descuento sistema
                    'Dim R_CLinesS As ERPConnect.RFCStructure = T_CDescuentos.AddRow()
                    'R_CLinesS("Folio") = "2" & oParent.ApplicationContext.ApplicationConfiguration.Almacen
                    'R_CLinesS("MATNR") = row("CodArticulo")
                    'R_CLinesS("Condicion") = "ZDP4"
                    'R_CLinesS("Importe") = row("DescuentoSistema")
                Next

                func.Exports("I_FACTURA").ParamValue = I_FACTURA
                func.Exports("I_FACDPPRO").ParamValue = pNotaCredito.Referencia '"AFS" & pNotaCredito.AlmacenID & pNotaCredito.CajaID & DateTime.Now.ToString("ssfff")
                func.Exports("I_KEYPRO").ParamValue = "T" & oParent.ApplicationContext.ApplicationConfiguration.Almacen & _
                oParent.ApplicationContext.ApplicationConfiguration.NoCaja & CStr(oAbonoCreditoDirecto.GetSelectNCByCaja(strCodCaja))
                func.Execute()
                R3.Close()
                pNotaCredito.SALESDOCUMENT = CStr(func.Imports("SALESDOCUMENT").ParamValue)
                pNotaCredito.FIDOCUMENT = CStr(func.Imports("FIDOCUMENT").ParamValue)
                Dim dtReturn As DataTable = func.Tables("RETURN").ToADOTable()
                For Each row As DataRow In dtReturn.Rows
                    If row.IsNull("MESSAGE") = False Then
                        strError &= CStr(row("MESSAGE"))
                    End If
                Next
            End If
        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try
    End Sub

    Public Overrides Sub SaveSAP(pNotaCredito As NotaCredito, Optional ByRef strError As String = "")

        '----------------------------------------------------------------------------------
        ' JNAVA (04.01.2016): Cambio de libreria para compatibilidad con SAP 6.0
        '----------------------------------------------------------------------------------
        Dim strCodCaja As String
        oDPVale = New cDPVale

        '------------------------------------------------------------------------------
        'JNAVA (09.06.2016): Parametro Inicia Transaccion DPPRO BUS
        '------------------------------------------------------------------------------
        Dim FechaInicio As DateTime
        Dim FechaFin As DateTime
        Dim Intervalo As Long
        '------------------------------------------------------------------------------

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
                strError = "Proceso SAP: No se pudo conectar con Servidor SAP. Verifique Configuración."
                Exit Sub
            Else
                '*****************************************************
                'Call RFC function  ZBAPISD17_DEV_VENTAS
                '*****************************************************
                ' Create a function object
                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZBAPISD17_DEV_VENTAS_2")

                'Asigno valores
                func.Exports("CLASEPEDIDO").ParamValue = "ZDEV" '& Mid(pNotaCredito.AlmacenID, 2, 2) & "3"

                func.Exports("OFICINAVTA").ParamValue = "T" & pNotaCredito.AlmacenID

                func.Exports("I_AGENTE").ParamValue = pNotaCredito.PlayerID
                func.Exports("I_WERKS").ParamValue = oSapCentro.Read_Centros '"T" & pNotaCredito.AlmacenID

                func.Exports("I_CREDITO").ParamValue = "N"
                func.Exports("I_KUNNR").ParamValue = I_KUNNR

                func.Exports("I_ZONAVTA").ParamValue = "EFEC"

                Dim T_CLines As ERPConnect.RFCTable = func.Tables("DATOSDET")
                Dim i As Integer = 0
                For Each row As DataRow In pNotaCredito.Detalle.Tables(0).Rows
                    i += i
                    Dim R_CLines As ERPConnect.RFCStructure = T_CLines.AddRow()
                    R_CLines("Folio") = "2" & oParent.ApplicationContext.ApplicationConfiguration.Almacen
                    R_CLines("MATNR") = row("CodArticulo")
                    R_CLines("Cantidad") = row("Cantidad")

                    strCodCaja = row!CodCaja
                    func.Exports("I_FACTURA").ParamValue = CStr(row("FolioReferencia")).PadLeft(10, "0")
                Next

                Dim T_CDescuentos As ERPConnect.RFCTable = func.Tables("CONDICIONES")
                i = 0
                For Each row As DataRow In pNotaCredito.Detalle.Tables(0).Rows
                    i += i
                    Dim R_CLines As ERPConnect.RFCStructure = T_CDescuentos.AddRow()
                    R_CLines("Folio") = "2" & oParent.ApplicationContext.ApplicationConfiguration.Almacen
                    R_CLines("MATNR") = row("CodArticulo")
                    R_CLines("Condicion") = "ZDP4"
                    R_CLines("Importe") = row("Descuento")

                    ''Descuento sistema
                    'Dim R_CLinesS As ERPConnect.RFCStructure = T_CDescuentos.AddRow()
                    'R_CLinesS("Folio") = "2" & oParent.ApplicationContext.ApplicationConfiguration.Almacen
                    'R_CLinesS("MATNR") = row("CodArticulo")
                    'R_CLinesS("Condicion") = "ZDP4"
                    'R_CLinesS("Importe") = row("DescuentoSistema")
                Next

                func.Exports("I_FACTURA").ParamValue = I_FACTURA
                func.Exports("I_FACDPPRO").ParamValue = pNotaCredito.Referencia '"AFS" & pNotaCredito.AlmacenID & pNotaCredito.CajaID & DateTime.Now.ToString("ssfff")
                func.Exports("I_KEYPRO").ParamValue = "T" & oParent.ApplicationContext.ApplicationConfiguration.Almacen & _
                oParent.ApplicationContext.ApplicationConfiguration.NoCaja & CStr(oAbonoCreditoDirecto.GetSelectNCByCaja(strCodCaja))

                If func.Exports("I_FACTURA").ParamValue = String.Empty Then
                    pNotaCredito.SALESDOCUMENT = String.Empty
                    pNotaCredito.FIDOCUMENT = String.Empty
                Else

                    '------------------------------------------------------------------------------
                    ' JNAVA (09.06.2016): Setemos inicio de Transaccion DPPRO con BUS
                    '------------------------------------------------------------------------------
                    If oParent.ConfigCierre.GenerarLogTransacciones Then
                        FechaInicio = Date.Now
                        EscribeLogTransaccionesSAP(True, FechaInicio, "ZBAPISD17_DEV_VENTAS_2")
                    End If
                    '-----------------------------------------------------------------------------

                    'Ejecutamos la RFC
                    func.Execute()

                    R3.Close()

                    '------------------------------------------------------------------------------
                    ' JNAVA (09.06.2016): Finaliza Transaccion y escribe Log BUS DPPRO
                    '------------------------------------------------------------------------------
                    If oParent.ConfigCierre.GenerarLogTransacciones Then
                        FechaFin = Date.Now
                        Intervalo = DateDiff(DateInterval.Second, FechaInicio, FechaFin)
                        EscribeLogTransaccionesSAP(False, FechaFin, "ZBAPISD17_DEV_VENTAS_2", "Transacción finalizada sin errores.", Intervalo)
                    End If
                    '------------------------------------------------------------------------------

                    'Obtenemos el Resultado4
                    If CStr(func.Imports("SALESDOCUMENT").ParamValue).Trim() = String.Empty Then
                        'Throw New ApplicationException(oRETURN.Value("message"))
                    End If

                    pNotaCredito.SALESDOCUMENT = func.Imports("SALESDOCUMENT").ParamValue
                    pNotaCredito.FIDOCUMENT = func.Imports("FIDOCUMENT").ParamValue
                    pNotaCredito.DEVANTERIOR = func.Imports("E_DEV_ANT").ParamValue
                    Dim dtReturn As DataTable = func.Tables("RETURN").ToADOTable()
                    For Each row As DataRow In dtReturn.Rows
                        If row.IsNull("MESSAGE") = False Then
                            strError &= CStr(row("MESSAGE"))
                        End If
                    Next
                End If
            End If

        Catch e1 As ERPConnect.RFCServerException
            '------------------------------------------------------------------------------
            ' JNAVA (09.06.2016): Finaliza Transaccion y escribe Log BUS DPPRO
            '------------------------------------------------------------------------------
            If oParent.ConfigCierre.GenerarLogTransacciones Then
                FechaFin = Date.Now
                Intervalo = DateDiff(DateInterval.Second, FechaInicio, FechaFin)
                EscribeLogTransaccionesSAP(False, FechaFin, "ZBAPISD17_DEV_VENTAS", e1.Message, Intervalo)
            End If
            '------------------------------------------------------------------------------
            Throw e1
        Catch e1 As ERPConnect.ERPException
            '------------------------------------------------------------------------------
            ' JNAVA (09.06.2016): Finaliza Transaccion y escribe Log BUS DPPRO
            '------------------------------------------------------------------------------
            If oParent.ConfigCierre.GenerarLogTransacciones Then
                FechaFin = Date.Now
                Intervalo = DateDiff(DateInterval.Second, FechaInicio, FechaFin)
                EscribeLogTransaccionesSAP(False, FechaFin, "ZBAPISD17_DEV_VENTAS", e1.Message, Intervalo)
            End If
            '------------------------------------------------------------------------------
            Throw e1
        End Try

    End Sub

    Public Function SapZsdProcesoCompensacion(ByRef dtDocumentos As DataTable, ByRef dtPagos As DataTable, ByRef strError As String) As DataSet
        Dim dsResultado As New DataSet
        Try

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
                strError = "Proceso SAP: No se pudo conectar con Servidor SAP. Verifique Configuración."
            Else
                '*****************************************************
                'Call RFC function  ZBAPISD17_DEV_VENTAS
                '*****************************************************
                ' Create a function object
                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("Z_MF_FYCMX1005_CIERRE_DIA")

                func.Exports("I_TIENDA").ParamValue = "T" & oParent.ApplicationContext.ApplicationConfiguration.Almacen
                func.Exports("I_MOT_PED").ParamValue = "ZFF"
                func.Exports("I_MODE").ParamValue = "N"
                func.Exports("I_FECHA").ParamValue = Format(Date.Today, "yyyyMMdd")
                func.Exports("I_DEVOLUCION").ParamValue = ""

                Dim T_CLines As ERPConnect.RFCTable = func.Tables("I_T_DOCUMENTS")

                For Each row As DataRow In dtDocumentos.Rows
                    Dim R_CLines As ERPConnect.RFCStructure = T_CLines.AddRow()
                    R_CLines("BSTNK") = row("BSTNK")
                Next

                Dim T_CDescuentos As ERPConnect.RFCTable = func.Tables("I_T_PAGOS")
                Dim i As Integer = 0
                For Each row As DataRow In dtPagos.Rows
                    i += 10
                    Dim R_CLines As ERPConnect.RFCStructure = T_CDescuentos.AddRow()
                    R_CLines("MANDT") = I_MANDANTE
                    R_CLines("VKBUR") = "T" & oParent.ApplicationContext.ApplicationConfiguration.Almacen
                    R_CLines("ID_CD") = i.ToString().PadLeft(20, "0")
                    R_CLines("POSNR") = i.ToString().PadLeft(6, "0")
                    R_CLines("TPAGO") = row("TPAGO")
                    R_CLines("CLCOB") = row("CLCOB")
                    R_CLines("BANCO") = row("BANCO")
                    R_CLines("REFBA") = row("REFBA")
                    R_CLines("MONTO") = row("MONTO")
                    R_CLines("RCAJA") = row("RCAJA")
                    R_CLines("COMPE") = row("COMPE")
                    R_CLines("PAGEN") = ""
                    R_CLines("BSTNK") = row("BSTNK")
                    R_CLines("BELNR") = ""
                Next

                func.Execute()

                R3.Close()


                Dim dtReturn As DataTable = func.Tables("I_T_RETURN").ToADOTable()
                For Each row As DataRow In dtReturn.Rows
                    If row.IsNull("MESSAGE") = False Then
                        strError &= CStr(row("MESSAGE"))
                    End If
                Next
                dsResultado.Tables.Add(func.Tables("I_T_DOCS_FI").ToADOTable())
                dsResultado.Tables.Add(func.Tables("I_T_RETURN_DOCS").ToADOTable())
            End If

        Catch e1 As ERPConnect.RFCServerException
            strError &= e1.Message
        Catch e1 As ERPConnect.ERPException
            strError &= e1.Message
        End Try
        Return dsResultado
    End Function

    Public Sub SapZsdProcesoRevale(ByRef datos As Dictionary(Of String, Object), ByRef strError As String)

        Try

            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServerDPVale, _
                     oParent.SAPApplicationConfig.SystemDPVale, _
                     oParent.SAPApplicationConfig.UserDPVale, _
                     oParent.SAPApplicationConfig.PasswordDPVale, _
                     oParent.SAPApplicationConfig.LanguageDPVale, _
                     oParent.SAPApplicationConfig.ClientDPVale)

            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                strError = "Proceso SAP: No se pudo conectar con Servidor SAP. Verifique Configuración."
            Else
                '*****************************************************
                'Call RFC function  ZBAPISD17_DEV_VENTAS
                '*****************************************************
                ' Create a function object
                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZDPVL_GRABA_MOV_DPVALE")

                For Each parametro As KeyValuePair(Of String, Object) In datos
                    func.Exports(parametro.Key).ParamValue = parametro.Value
                Next

                func.Execute()

                R3.Close()

                Dim dtReturn As DataTable = func.Tables("RETURN").ToADOTable()
                For Each row As DataRow In dtReturn.Rows
                    If row.IsNull("MESSAGE") = False Then
                        strError &= CStr(row("MESSAGE"))
                    End If
                Next

            End If

        Catch e1 As ERPConnect.RFCServerException
            strError &= e1.Message
        Catch e1 As ERPConnect.ERPException
            strError &= e1.Message
        End Try

    End Sub

    Public Function CatalogoArticulosEquivalencia() As DataTable

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaFSAP As SqlDataAdapter
        Dim dsFSAP As DataSet

        sccmdSelectAll = New SqlCommand
        scdaFSAP = New SqlDataAdapter
        dsFSAP = New DataSet

        With sccmdSelectAll

            .Connection = sccnnConnection

            .CommandText = "[CatalogoArticulosEquivalenciasSelAll]"
            .CommandType = System.Data.CommandType.StoredProcedure

        End With

        scdaFSAP.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            scdaFSAP.Fill(dsFSAP)

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

        Return dsFSAP.Tables(0)

    End Function
End Class
