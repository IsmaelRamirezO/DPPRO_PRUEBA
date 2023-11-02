Imports DportenisPro.DPTienda.ApplicationUnits.Facturas
Imports DportenisPro.DPTienda.ApplicationUnits.Clientes
Imports DportenisPro.DPTienda.ApplicationUnits.FacturasCorrida
Imports DportenisPro.DPTienda.ApplicationUnits.FacturasFormaPago
Imports DportenisPro.DPTienda.ApplicationUnits.TiposVenta
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes
Imports DportenisPro.DPTienda.ApplicationUnits.AvisosFacturaAU
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU

Public Class cImprimirFactura
    Public Sub ObtenerDatos(ByRef DataInfo As rptFacturaInfo, ByRef General As DataTable, ByRef Detalles As DataTable, ByRef FormaPago As DataTable, ByRef Notas As DataTable)
        Dim piImp As RepAjustesESEng.cImpresionFactura
        Dim oFacturaMgr As FacturaManager
        Dim oFactura As Factura
        Dim oFacturaCorridaMgr As FacturaCorridaManager
        Dim oFacturaCorrida As FacturaCorrida
        Dim oClientesMgr As ClientesManager
        Dim oCliente As ClienteAlterno
        Dim oAvisosFacturaMgr As AvisosFacturaManager
        Dim pdsAvisos As DataSet
        Dim oCatalogoAlmacenesMgr As New CatalogoAlmacenesManager(oAppContext)
        Dim oAlmacen As Almacen
        Dim oFacturaFormaPago As FacturaFormaPago
        Dim dsFormaPago As DataSet
        Dim psTipoVenta As String
        Dim psLeyendaPago As String
        Dim psDeudaAbonoFacilito As String
        Dim psAutorizaFacilito As String
        Dim prTmp As Data.DataRow
        Dim i As Integer


        piImp = New RepAjustesESEng.cImpresionFactura
        piImp.CrearDG(General)
        piImp = Nothing
        oFacturaMgr = New FacturaManager(oAppContext)
        oFactura = oFacturaMgr.Create
        oFacturaCorridaMgr = New FacturaCorridaManager(oAppContext)
        oFacturaCorrida = oFacturaCorridaMgr.Create
        oClientesMgr = New ClientesManager(oAppContext, Nothing, oConfigCierreFI) ' JNAVA (08.08.2016): Agregamos configuracion de Cierre FI para S2Credit
        oCliente = oClientesMgr.CreateAlterno
        oAvisosFacturaMgr = New AvisosFacturaManager(oAppContext)
        pdsAvisos = oAvisosFacturaMgr.LoadEnabled("FACTURACION", True)
        oFacturaFormaPago = New FacturaFormaPago(oAppContext)
        dsFormaPago = New DataSet

        oFactura.ClearFields()
        oFacturaMgr.LoadInto(DataInfo.FacturaID, oFactura)
        oFactura.Detalle = oFacturaCorridaMgr.Load(DataInfo.FacturaID)
        If oFactura.CodTipoVenta.Trim = "P" AndAlso oFactura.ClienteId <= 0 Then oFactura.ClienteId = 10000000
        '-------------------------------------------------------------------------------------------------------------------------------------------------
        ' JNAVA (03.03.2016): Obtenemos el cliente de SAP y grabamos en BD local en caso de no existir
        '-------------------------------------------------------------------------------------------------------------------------------------------------
        'If oFactura.ClienteId <> 1 AndAlso oFactura.ClienteId <> 99999 Then
        If oFactura.CodTipoVenta <> "P" AndAlso oFactura.CodTipoVenta <> "E" Then
            'If oFactura.CodTipoVenta = "A" Then
            '    oClientesMgr.Load(CStr(oFactura.ClienteId).PadLeft(10, "0"), oCliente, "I")
            'Else
            '    oClientesMgr.Load(CStr(oFactura.ClienteId).PadLeft(10, "0"), oCliente, oFactura.CodTipoVenta)
            'End If
            GetCliente(CStr(oFactura.ClienteId).PadLeft(10, "0"), oFactura.CodTipoVenta.Trim)
            oClientesMgr.Load(CStr(oFactura.ClienteId).PadLeft(10, "0"), oCliente)
        End If
        '-------------------------------------------------------------------------------------------------------------------------------------------------
        ' JNAVA (03.03.2016): Obtenemos el almacen en base al centro SAP 
        '-------------------------------------------------------------------------------------------------------------------------------------------------
        Dim oSAPMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        oAlmacen = oCatalogoAlmacenesMgr.Load(oSAPMgr.Read_Centros) 'oAppContext.ApplicationConfiguration.Almacen)
        '-------------------------------------------------------------------------------------------------------------------------------------------------
        Select Case oFactura.CodTipoVenta
            Case "P"
                psTipoVenta = "PISO DE VENTA"
            Case "V"
                psTipoVenta = "DPVALE" & " (" & CStr(DataInfo.FolioDPVale).PadLeft(10, "0") & ")"
            Case "D"
                psTipoVenta = "ASOCIADO (DIP'S)"
            Case "S"
                psTipoVenta = "DPSOCIO"
            Case "F", "K"
                psTipoVenta = "CRÉDITO FONACOT"
            Case "O"
                psTipoVenta = "CRÉDITO FACILITO"
            Case "M"
                psTipoVenta = "MAYOREO"
            Case "I"
                psTipoVenta = "FACTURACIÓN FISCAL"
            Case "A"
                psTipoVenta = "APARTADO"
            Case "E"
                psTipoVenta = "EMPLEADO"
        End Select
        If oFactura.CodTipoVenta = "O" Or oFactura.CodTipoVenta = "F" Or oFactura.CodTipoVenta = "K" Then
            psLeyendaPago = "Pago hecho en una sola exhibición"
            If oFactura.CodTipoVenta = "O" Then
                psAutorizaFacilito = "Autorización Facilito : " & oFactura.NumeroFacilito.ToString
                If DataInfo.DeudaFacilito < oFactura.Total Then
                    psDeudaAbonoFacilito = "Su Abono: " & Format(oFactura.Total - DataInfo.DeudaFacilito, "Currency") & " Ud. Debe a Facilito:" & Format(DataInfo.DeudaFacilito, "Currency")
                Else
                    psDeudaAbonoFacilito = "Ud. Debe a Facilito:" & Format(DataInfo.DeudaFacilito, "Currency")
                End If
            End If
        Else
            psLeyendaPago = "Pago hecho en una sola exhibición"
        End If
        Dim column = New DataColumn()
        column.DataType = Type.GetType("System.String")
        column.ColumnName = "ClienteID"
        General.Columns.Add(column)
        prTmp = General.NewRow()
        prTmp.Item("FolioFactura") = oFactura.FolioFactura
        prTmp.Item("CodCaja") = oFactura.CodCaja
        prTmp.Item("Fecha") = Format(oFactura.Fecha, "dd/MM/yy") & " " & Format(Now, "hh:mm:ss")

        prTmp.Item("ClienteID") = oCliente.CodigoAlterno

        '-------------------------------------------------------------------------------------------------------------------------------------------------
        ' JNAVA (03.03.2016): realizamos las validacion en base al tipo de venta
        '-------------------------------------------------------------------------------------------------------------------------------------------------
        'If (oFactura.ClienteId <> 1 AndAlso oFactura.ClienteId <> 99999) Then
        If oFactura.CodTipoVenta <> "P" AndAlso oFactura.CodTipoVenta <> "E" Then
            prTmp.Item("NombreCliente") = oCliente.Nombre & " " & oCliente.ApellidoPaterno & " " & oCliente.ApellidoMaterno
            prTmp.Item("Domicilio") = CStr(oCliente.Direccion & " " & oCliente.Colonia & " " & oCliente.NumExt & " " & oCliente.NumInt).TrimEnd
            prTmp.Item("Ciudad") = oCliente.Ciudad
            prTmp.Item("RFC") = oCliente.RFC
            prTmp.Item("Telefono") = oCliente.Telefono
            'If InStr("D,S", oFactura.CodTipoVenta) > 0 AndAlso oConfigCierreFI.AplicaNewDescuentosDIPs Then
            '    prTmp.Item("Iva") = 0
            '    prTmp.Item("Subtotal") = 0
            'Else
            prTmp.Item("Iva") = oFactura.IVA
            prTmp.Item("Subtotal") = oFactura.SubTotal
            'End If
            If CStr(oCliente.CP) = "" Then
                prTmp.Item("Estado") = oCliente.Estado
            Else
                prTmp.Item("Estado") = oCliente.Estado & " " & oCliente.CP
            End If
            '-------------------------------------------------------------------------------------------------------------------------------------------------
            ' JNAVA (03.03.2016): realizamos la validacion en base al tipo de venta de EMpleado
            '-------------------------------------------------------------------------------------------------------------------------------------------------
            'ElseIf oFactura.ClienteId = 99999 Then
        ElseIf oFactura.CodTipoVenta = "E" Then
            prTmp.Item("NombreCliente") = "EMPLEADO"
            prTmp.Item("Ciudad") = oAlmacen.DireccionCiudad
            prTmp.Item("Estado") = oAlmacen.DireccionEstado
            prTmp.Item("Domicilio") = ""
            prTmp.Item("RFC") = ""
            prTmp.Item("Telefono") = ""
            prTmp.Item("Subtotal") = 0
            prTmp.Item("Iva") = 0
        Else
            'prTmp.Item("NombreCliente") = "PÚBLICO GENERAL"
            prTmp.Item("Ciudad") = oAlmacen.DireccionCiudad
            prTmp.Item("Estado") = oAlmacen.DireccionEstado
            prTmp.Item("Domicilio") = ""
            prTmp.Item("RFC") = ""
            prTmp.Item("Telefono") = ""
            prTmp.Item("Subtotal") = 0
            prTmp.Item("Iva") = 0

            If oFactura.ClienteId = 10000000 Then
                prTmp.Item("NombreCliente") = "PÚBLICO GENERAL"
            Else
                oClientesMgr.Load(oFactura.ClienteId.ToString(), oCliente)
                If oCliente.CodigoAlterno <> "" Then
                    prTmp.Item("NombreCliente") = oCliente.Nombre & " " & oCliente.ApellidoPaterno & " " & oCliente.ApellidoMaterno
                    prTmp.Item("Domicilio") = CStr(oCliente.Direccion & " " & oCliente.Colonia & " " & oCliente.NumExt & " " & oCliente.NumInt).TrimEnd
                    prTmp.Item("Ciudad") = oCliente.Ciudad
                    prTmp.Item("Telefono") = oCliente.Telefono
                    If CStr(oCliente.CP) = "" Then
                        prTmp.Item("Estado") = oCliente.Estado & vbCrLf
                    Else
                        prTmp.Item("Estado") = oCliente.Estado & " " & oCliente.CP & vbCrLf
                    End If
                Else
                    prTmp.Item("NombreCliente") = "PÚBLICO GENERAL"
                End If
            End If
        End If
        '-------------------------------------------------------------------------------------------------------------------------------------------------
        '-------------------------------------------------------------------------------------------------------------------------------------------------
        'RGERMAIN 19.12.2014: Se agregaron titulos a los nombres de clientes y distribuidores por temas fiscales solicitado en mail de Lety 19.12.2014
        '-------------------------------------------------------------------------------------------------------------------------------------------------
        If DataInfo.NombreAsociado <> "" Then
            prTmp.Item("NombreCliente") = "ACREDITADO" & vbCrLf & DataInfo.NombreAsociado
        End If
        If DataInfo.vNombreClienteAsociado <> "" Then
            prTmp.Item("Domicilio") = "CANJEANTE" & vbCrLf & DataInfo.vNombreClienteAsociado
        End If
        prTmp.Item("FormaPago") = psLeyendaPago
        prTmp.Item("TipoVenta") = psTipoVenta
        prTmp.Item("AutorizacionFacilito") = " " & psAutorizaFacilito
        prTmp.Item("LeyendaPago") = " " & psDeudaAbonoFacilito
        '-------------------------------------------------------------------------------------------------------------------------------------------------
        'JNAVA (23.07.2015): Se descomento esta validacion ya que con clientes DIPS no cuadraba el descuento total con la suma del detalle en el ticket
        '-------------------------------------------------------------------------------------------------------------------------------------------------
        If InStr("D,S", oFactura.CodTipoVenta) > 0 AndAlso oConfigCierreFI.AplicaNewDescuentosDIPs Then
            prTmp.Item("Descuento") = oFactura.DescTotal * (1 + (oFactura.IVA / oFactura.SubTotal))
        Else
            prTmp.Item("Descuento") = oFactura.DescTotal 'ESTO YA ESTABA DESCOMENTADO
        End If
        '-------------------------------------------------------------------------------------------------------------------------------------------------
        prTmp.Item("Total") = oFactura.Total
        prTmp.Item("CantidadTexto") = UCase(Letras(Decimal.Round(oFactura.Total, 2)))
        prTmp.Item("CodVendedor") = oFactura.CodVendedor
        General.Rows.Add(prTmp)

        Detalles = oFactura.Detalle.Tables("FacturaDetalle").Copy()
        Notas = pdsAvisos.Tables(0).Copy()
        dsFormaPago = oFacturaFormaPago.Load(DataInfo.FacturaID)
        FormaPago = dsFormaPago.Tables("FacturasFormasPago").Copy()
        oCatalogoAlmacenesMgr = Nothing
        oAlmacen = Nothing
    End Sub

    Public Sub ImprimirFactura(ByVal Puerto As String, _
                                    ByVal Driver As String, _
                                    ByVal Copia As Boolean, _
                                    ByRef DatosGenerales As DataTable, _
                                    ByRef Detalles As DataTable, _
                                    ByRef FormaPago As DataTable, _
                                    ByRef Notas As DataTable, _
                                    ByVal FolioSAP As String, _
                                    ByVal CodTipoVenta As String, _
                                    ByVal Cancelacion As Boolean)
        Dim piString As RepAjustesESEng.cString
        Dim piImprimir As RepAjustesESEng.cImpresion
        Dim psLinea As String
        Dim psCant1 As String
        Dim psCant2 As String
        Dim pvValores(5) As Object
        Dim psFormatos(5) As String
        Dim psgLongitudes(5) As Single
        Dim pnAlineaciones(5) As Integer
        Dim pnCarac As Integer
        Dim pnPos As Integer
        Dim i As Integer

        piString = New RepAjustesESEng.cString
        piImprimir = New RepAjustesESEng.cImpresion(Driver)
        If piImprimir.OpenPort(Puerto) < 1 Then
            MsgBox("No se pudo abrir el puerto", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "Error al imprimir")
            Exit Sub
        End If
        piImprimir.Inicializa()
        piImprimir.AvanzaMargenSup()
        If Copia Then
            'piImprimir.PrintLine(5.5, "Copia de Factura", "", 5.5, RepAjustesESEng.cImpresion.ImpAlineacion.Izquierda)
            piImprimir.PrintLine(5.5, "Copia de Nota de Venta", "", 5.5, RepAjustesESEng.cImpresion.ImpAlineacion.Izquierda)
        Else
            If Cancelacion Then
                'piImprimir.PrintLine(5.5, "Cancelación de Factura", "", 5.5, RepAjustesESEng.cImpresion.ImpAlineacion.Izquierda)
                piImprimir.PrintLine(5.5, "Cancelación de Nota de Venta", "", 5.5, RepAjustesESEng.cImpresion.ImpAlineacion.Izquierda)
            Else

                piImprimir.PrintLine("")
            End If
        End If
        If FolioSAP <> "" Then
            FolioSAP = " - " & FolioSAP
        End If
        psLinea = Chr(27) + Chr(69) + CStr(DatosGenerales.Rows(0).Item("FolioFactura")) & FolioSAP + Chr(27) + Chr(70)
        piImprimir.PrintLine(3.0, psLinea, "", 3, piImprimir.ImpAlineacion.Izquierda)
        '''piImprimir.PrintLine(5.4, psLinea, "", 3, piImprimir.ImpAlineacion.Izquierda)
        piImprimir.PrintLine("")
        psLinea = "Caja : " & DatosGenerales.Rows(0).Item("CodCaja")
        piImprimir.PrintLine(4.0, psLinea, "", 2.5, piImprimir.ImpAlineacion.Izquierda)
        piImprimir.PrintLine("")
        pvValores(0) = DatosGenerales.Rows(0).Item("TipoVenta")
        psFormatos(0) = ""
        psgLongitudes(0) = 5.0
        pnAlineaciones(0) = piImprimir.ImpAlineacion.Izquierda
        pvValores(1) = DatosGenerales.Rows(0).Item("Fecha")
        psFormatos(1) = "dd/MM/yyyy hh:mm:ss"
        psgLongitudes(1) = 4.0
        pnAlineaciones(1) = piImprimir.ImpAlineacion.Derecha
        psLinea = piImprimir.FormatoLinea(pvValores, psFormatos, psgLongitudes, pnAlineaciones, 2, 4)
        piImprimir.PrintLine(psLinea)
        piImprimir.PrintLine("")
        psLinea = DatosGenerales.Rows(0).Item("NombreCliente")
        piImprimir.PrintLine(1.8, psLinea, "", 9, piImprimir.ImpAlineacion.Izquierda)
        psLinea = DatosGenerales.Rows(0).Item("Domicilio")
        piImprimir.PrintLine(1.8, psLinea, "", 9, piImprimir.ImpAlineacion.Izquierda)
        psLinea = DatosGenerales.Rows(0).Item("Ciudad") & " " & DatosGenerales.Rows(0).Item("Estado")
        piImprimir.PrintLine(1.8, psLinea, "", 9, piImprimir.ImpAlineacion.Izquierda)
        psLinea = IIf(IsDBNull(DatosGenerales.Rows(0).Item("RFC")), "", DatosGenerales.Rows(0).Item("RFC"))
        piImprimir.Print(1.8, psLinea, "", 3.2, piImprimir.ImpAlineacion.Izquierda)
        psLinea = IIf(IsDBNull(DatosGenerales.Rows(0).Item("Telefono")), "", DatosGenerales.Rows(0).Item("Telefono"))
        piImprimir.PrintLine(2.3, psLinea, "", 3, piImprimir.ImpAlineacion.Izquierda)
        piImprimir.PrintLine(4, "Pago hecho en una sola exhibición", "", 7, piImprimir.ImpAlineacion.Izquierda)
        For i = 1 To 2
            piImprimir.PrintLine("")
        Next
        'psgLongitudes(0) = 0.5
        'psFormatos(0) = "0"
        'pnAlineaciones(0) = piImprimir.ImpAlineacion.Derecha
        'psgLongitudes(1) = 2.5
        'psFormatos(1) = ""
        'pnAlineaciones(1) = piImprimir.ImpAlineacion.Izquierda
        psgLongitudes(2) = 2.1
        psFormatos(2) = ""
        pnAlineaciones(2) = piImprimir.ImpAlineacion.Izquierda
        psgLongitudes(3) = 0.5
        'psFormatos(3) = "0.0"
        psFormatos(3) = ""
        pnAlineaciones(3) = piImprimir.ImpAlineacion.Derecha
        psgLongitudes(4) = 2.2
        psFormatos(4) = "$#,##0.00"
        pnAlineaciones(4) = piImprimir.ImpAlineacion.Derecha
        psgLongitudes(5) = 2.2
        psFormatos(5) = "$#,##0.00"
        pnAlineaciones(5) = piImprimir.ImpAlineacion.Derecha
        For i = 0 To Detalles.Rows.Count - 1
            psgLongitudes(0) = 0.5
            psFormatos(0) = "0"
            pnAlineaciones(0) = piImprimir.ImpAlineacion.Derecha
            psgLongitudes(1) = 2.5
            psFormatos(1) = ""
            pnAlineaciones(1) = piImprimir.ImpAlineacion.Izquierda
            pvValores(0) = Detalles.Rows(i).Item("Cantidad")
            pvValores(1) = Detalles.Rows(i).Item("CodArticulo")
            pvValores(2) = Detalles.Rows(i).Item("Descripcion")
            pvValores(3) = Detalles.Rows(i).Item("Numero")

            If CodTipoVenta = "P" Or CodTipoVenta = "V" Then
                pvValores(4) = Detalles.Rows(i).Item("PrecioOferta") * (1 + oAppContext.ApplicationConfiguration.IVA)
                pvValores(5) = Detalles.Rows(i).Item("Cantidad") * (Detalles.Rows(i).Item("PrecioOferta") * (1 + oAppContext.ApplicationConfiguration.IVA))
            Else
                pvValores(4) = Detalles.Rows(i).Item("PrecioOferta")
                pvValores(5) = Detalles.Rows(i).Item("Cantidad") * Detalles.Rows(i).Item("PrecioOferta")
            End If

            psLinea = piImprimir.FormatoLinea(pvValores, psFormatos, psgLongitudes, pnAlineaciones, 6, 1)
            psLinea = "   " & psLinea
            piImprimir.PrintLine(psLinea)

            psgLongitudes(0) = 2.5
            psFormatos(0) = ""
            pnAlineaciones(0) = piImprimir.ImpAlineacion.Izquierda
            psgLongitudes(1) = 2.2
            psFormatos(1) = "$#,##0.00"
            pnAlineaciones(1) = piImprimir.ImpAlineacion.Derecha

            pvValores(0) = "Desc. "
            pvValores(1) = Detalles.Rows(i).Item("CantDescuentoSistema") + ((CDec(pvValores(5)) - Detalles.Rows(i).Item("CantDescuentoSistema")) * Detalles.Rows(i).Item("Descuento"))
            If CodTipoVenta = "P" Or CodTipoVenta = "V" Then
                pvValores(1) = CDec(pvValores(1)) * (1 + oAppContext.ApplicationConfiguration.IVA)
            End If
            psLinea = piImprimir.FormatoLinea(pvValores, psFormatos, psgLongitudes, pnAlineaciones, 2, 1)
            psLinea = "   " & psLinea
            piImprimir.PrintLine(psLinea)
        Next
        For i = Detalles.Rows.Count To 11
            piImprimir.PrintLine("")
        Next
        pvValores(0) = DatosGenerales.Rows(0).Item("AutorizacionFacilito")
        psFormatos(0) = ""
        psgLongitudes(0) = 6
        pnAlineaciones(0) = piImprimir.ImpAlineacion.Izquierda
        pvValores(1) = "Desc. Aplicado:"
        psFormatos(1) = ""
        psgLongitudes(2) = 2.2
        pnAlineaciones(2) = piImprimir.ImpAlineacion.Izquierda

        'If CodTipoVenta = "P" Or CodTipoVenta = "V" Then
        'pvValores(2) = DatosGenerales.Rows(0).Item("Descuento") * (oAppContext.ApplicationConfiguration.IVA + 1)
        'Else
        pvValores(2) = DatosGenerales.Rows(0).Item("Descuento")
        'End If

        psFormatos(2) = "$#,##0.00"
        psgLongitudes(2) = 2.3
        pnAlineaciones(2) = piImprimir.ImpAlineacion.Derecha
        If pvValores(2) <> 0 Then
            psLinea = piImprimir.FormatoLinea(pvValores, psFormatos, psgLongitudes, pnAlineaciones, 3, 1)
        Else
            psLinea = piImprimir.FormatoLinea(pvValores, psFormatos, psgLongitudes, pnAlineaciones, 1, 1)
        End If
        piImprimir.PrintLine(psLinea)
        psLinea = DatosGenerales.Rows(0).Item("AutorizacionFacilito")
        piImprimir.PrintLine(0.4, psLinea, "", 10.6, piImprimir.ImpAlineacion.Izquierda)
        psLinea = DatosGenerales.Rows(0).Item("LeyendaPago")
        piImprimir.PrintLine(0.4, psLinea, "", 10.6, piImprimir.ImpAlineacion.Izquierda)
        If DatosGenerales.Rows(0).Item("Subtotal") = 0 Then
            piImprimir.PrintLine("")
        Else
            piImprimir.PrintLine(8.6, CDbl(DatosGenerales.Rows(0).Item("Subtotal")), "$#,##0.00", 2.2, piImprimir.ImpAlineacion.Derecha)
        End If
        psLinea = DatosGenerales.Rows(0).Item("CantidadTexto")
        pnCarac = piImprimir.CentimetrosACaracteres(6.5)
        If pnCarac >= Len(psLinea) Then
            psCant1 = psLinea
        Else
            pnPos = piString.BuscarCaracter(psLinea, " ", pnCarac, piString.strDireccion.Izquierda)
            If pnPos = 0 Then
                psCant1 = Microsoft.VisualBasic.Left$(psLinea, pnCarac)
                psCant2 = Microsoft.VisualBasic.Right$(psLinea, Len(psLinea) - pnCarac)
            Else
                psCant1 = Microsoft.VisualBasic.Left$(psLinea, pnPos - 1)
                psCant2 = Microsoft.VisualBasic.Right$(psLinea, Len(psLinea) - pnPos)
            End If
        End If
        pvValores(0) = psCant1
        psFormatos(0) = ""
        psgLongitudes(0) = 7.0
        pnAlineaciones(0) = piImprimir.ImpAlineacion.Izquierda
        If DatosGenerales.Rows(0).Item("Iva") = 0 Then
            pvValores(1) = ""
            psFormatos(1) = ""
        Else
            pvValores(1) = CDbl(DatosGenerales.Rows(0).Item("Iva"))
            psFormatos(1) = "$#,##0.00"
        End If
        psgLongitudes(1) = 2.2
        pnAlineaciones(1) = piImprimir.ImpAlineacion.Derecha
        psLinea = piImprimir.FormatoLinea(pvValores, psFormatos, psgLongitudes, pnAlineaciones, 2, 13)
        piImprimir.PrintLine(psLinea)
        pvValores(0) = psCant2
        pvValores(1) = CDbl(DatosGenerales.Rows(0).Item("Total"))
        psFormatos(1) = "$#,##0.00"
        psLinea = piImprimir.FormatoLinea(pvValores, psFormatos, psgLongitudes, pnAlineaciones, 2, 13)
        piImprimir.PrintLine(psLinea)
        psLinea = "  Player : " & DatosGenerales.Rows(0).Item("CodVendedor")
        piImprimir.PrintLine(psLinea)
        psFormatos(0) = ""
        psgLongitudes(0) = 2.0
        pnAlineaciones(0) = piImprimir.ImpAlineacion.Izquierda
        psFormatos(1) = ""
        psgLongitudes(1) = 1
        pnAlineaciones(1) = piImprimir.ImpAlineacion.Derecha
        psFormatos(2) = "$#,##0.00"
        psgLongitudes(2) = 3
        pnAlineaciones(2) = piImprimir.ImpAlineacion.Derecha
        For i = 0 To FormaPago.Rows.Count - 1
            If i = 0 Then
                pvValores(0) = "Pago:"
            Else
                pvValores(0) = ""
            End If
            pvValores(1) = FormaPago.Rows(i).Item("CodFormasPago")
            pvValores(2) = FormaPago.Rows(i).Item("MontoPago")
            psLinea = "  " & piImprimir.FormatoLinea(pvValores, psFormatos, psgLongitudes, pnAlineaciones, 3, 1)
            piImprimir.PrintLine(psLinea)
        Next
        For i = 0 To Notas.Rows.Count - 1
            psLinea = Notas.Rows(i).Item("Nota")
            piImprimir.PrintLine(0.4, psLinea, "", 10.5, piImprimir.ImpAlineacion.Centro)
        Next
        piImprimir.AvanzaPagina()
        piImprimir.ClosePort()
    End Sub

    Public Sub ImprimirFacturaMiniPrinter(ByVal Puerto As String, _
                            ByVal Driver As String, _
                            ByVal Copia As Boolean, _
                            ByRef DatosGenerales As DataTable, _
                            ByRef Detalles As DataTable, _
                            ByRef FormaPago As DataTable, _
                            ByRef Notas As DataTable, _
                            ByVal FolioSAP As String, _
                            ByVal CodTipoVenta As String)
        Try
            Dim piString As RepAjustesESEng.cString
            Dim piImprimir As RepAjustesESEng.cImpresion
            Dim psLinea As String
            Dim psCant1 As String
            Dim psCant2 As String
            Dim pvValores(5) As Object
            Dim psFormatos(5) As String
            Dim psgLongitudes(5) As Single
            Dim pnAlineaciones(5) As Integer
            Dim pnCarac As Integer
            Dim pnPos As Integer
            Dim i As Integer

            piString = New RepAjustesESEng.cString
            piImprimir = New RepAjustesESEng.cImpresion(Driver)
            If piImprimir.OpenPort(Puerto) < 1 Then
                MsgBox("No se pudo abrir el puerto", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "Error al imprimir")
                Exit Sub
            End If
            piImprimir.Inicializa()
            'piImprimir.AvanzaMargenSup()
            If Copia Then
                '--------------5.5
                piImprimir.PrintLine(0, "Copia de Factura", "", 3, RepAjustesESEng.cImpresion.ImpAlineacion.Centro)
            Else
                'piImprimir.PrintLine("")
            End If
            '//----------------Folios de Factura
            If FolioSAP <> "" Then
                FolioSAP = " - " & FolioSAP
            End If
            psLinea = "Folio: " & CStr(DatosGenerales.Rows(0).Item("FolioFactura")) & FolioSAP
            'psLinea = Chr(27) + Chr(69) + CStr(DatosGenerales.Rows(0).Item("FolioFactura")) & FolioSAP + Chr(27) + Chr(70)
            '--------------------3.0  
            piImprimir.PrintLine(0, psLinea, "", 4, piImprimir.ImpAlineacion.Centro)
            '//----------------Folios de Factura

            'piImprimir.PrintLine("")
            '//--------------------Letrero de Caja ver que mas pone aqui
            psLinea = "Caja: " & DatosGenerales.Rows(0).Item("CodCaja")
            '----4.0
            piImprimir.PrintLine(0, psLinea, "", 2.5, piImprimir.ImpAlineacion.Izquierda)
            'piImprimir.PrintLine("")
            '//-------------------- Letrero de Caja ver que mas pone aqui
            '//-------------------- Tipo de Venta
            psLinea = DatosGenerales.Rows(0).Item("TipoVenta")
            piImprimir.PrintLine(0, psLinea, "", 4, piImprimir.ImpAlineacion.Izquierda)
            '//-------------------- Tipo de Venta

            '//-------------------- Fecha
            psLinea = Format(DatosGenerales.Rows(0).Item("Fecha"), "dd/MM/yyyy hh:mm:ss")
            piImprimir.PrintLine(0, psLinea, "", 4, piImprimir.ImpAlineacion.Izquierda)
            '//-------------------- Fecha

            piImprimir.PrintLine("")

            '//--------------------Nombre de Cliente
            psLinea = DatosGenerales.Rows(0).Item("NombreCliente")
            '---------------------1.8 ----------9
            piImprimir.PrintLine(0, psLinea, "", 6.0, piImprimir.ImpAlineacion.Izquierda)
            '//--------------------Nombre de Cliente

            '//--------------------Domicilio Si no hay no Mandar Imprimir
            If DatosGenerales.Rows(0).Item("Domicilio") <> String.Empty Then
                psLinea = DatosGenerales.Rows(0).Item("Domicilio")
                '---------------------1.8 ----------9
                piImprimir.PrintLine(0, psLinea, "", 6.0, piImprimir.ImpAlineacion.Izquierda)
            End If
            '//--------------------Domicilio Si no hay no Mandar Imprimir

            '//--------------------Aqui Imprime Ciudad y Estado y CP
            psLinea = DatosGenerales.Rows(0).Item("Ciudad") & " " & DatosGenerales.Rows(0).Item("Estado")
            '---------------------1.8 ----------9
            piImprimir.PrintLine(0, psLinea, "", 6.0, piImprimir.ImpAlineacion.Izquierda)
            '//--------------------Aqui Imprime Ciudad y Estado  y CP

            '//--------------------Aqui se imprime RFC si no es Null
            psLinea = IIf(IsDBNull(DatosGenerales.Rows(0).Item("RFC")), "", DatosGenerales.Rows(0).Item("RFC"))
            If psLinea <> String.Empty Then piImprimir.PrintLine(0, Trim(psLinea), "", 2.5, piImprimir.ImpAlineacion.Izquierda)
            '//--------------------Aqui se imprime RFC si no es Null

            '//-*-------------------Aqui el Telefono si no es Null
            psLinea = IIf(IsDBNull(DatosGenerales.Rows(0).Item("Telefono")), "", DatosGenerales.Rows(0).Item("Telefono"))
            If psLinea <> String.Empty Then piImprimir.PrintLine(0, Trim(psLinea), "", 2.5, piImprimir.ImpAlineacion.Izquierda)
            '//--------------------Aqui el Telefono

            piImprimir.PrintLine("")

            piImprimir.PrintLine(0, "Pago hecho en una sola exhibición", "", 5.3, piImprimir.ImpAlineacion.Izquierda)

            piImprimir.PrintLine("")

            psgLongitudes(0) = 0.5 'Cantidad
            psFormatos(0) = "0"
            pnAlineaciones(0) = piImprimir.ImpAlineacion.Izquierda
            '-----------------------------------
            psgLongitudes(1) = 2.5 'CodArticulo
            psFormatos(1) = ""
            pnAlineaciones(1) = piImprimir.ImpAlineacion.Izquierda
            '-----------------------------------
            psgLongitudes(2) = 2.0 'Precio Unitario
            psFormatos(2) = "$#,##0.00"
            pnAlineaciones(2) = piImprimir.ImpAlineacion.Izquierda
            '-----------------------------------
            psgLongitudes(3) = 0.7 'Talla
            psFormatos(3) = ""
            pnAlineaciones(3) = piImprimir.ImpAlineacion.Izquierda
            '-----------------------------------
            psgLongitudes(4) = 2.0 'Descripcion
            psFormatos(4) = ""
            pnAlineaciones(4) = piImprimir.ImpAlineacion.Izquierda
            '-----------------------------------
            psgLongitudes(5) = 2 ' Total
            psFormatos(5) = "$#,##0.00"
            pnAlineaciones(5) = piImprimir.ImpAlineacion.Derecha
            '-----------------------------------
            For i = 0 To Detalles.Rows.Count - 1
                pvValores(0) = Detalles.Rows(i).Item("Cantidad")
                pvValores(1) = Trim(CStr(Detalles.Rows(i).Item("CodArticulo")))
                pvValores(3) = Trim(CStr(Detalles.Rows(i).Item("Numero")))
                If Trim(Detalles.Rows(i).Item("Descripcion")) <> String.Empty And CStr(Detalles.Rows(i).Item("Descripcion")).Length > 16 Then
                    pvValores(4) = Trim(CStr(Detalles.Rows(i).Item("Descripcion")).Substring(0, 16))
                Else
                    pvValores(4) = Trim(CStr(Detalles.Rows(i).Item("Descripcion")))
                End If
                If CodTipoVenta = "P" Or CodTipoVenta = "V" Then
                    pvValores(2) = Detalles.Rows(i).Item("PrecioOferta") * (1 + oAppContext.ApplicationConfiguration.IVA)
                    pvValores(5) = Detalles.Rows(i).Item("Cantidad") * (Detalles.Rows(i).Item("PrecioOferta") * (1 + oAppContext.ApplicationConfiguration.IVA))
                Else
                    pvValores(2) = Detalles.Rows(i).Item("PrecioOferta")
                    pvValores(5) = Detalles.Rows(i).Item("Cantidad") * Detalles.Rows(i).Item("PrecioOferta")
                End If

                psLinea = piImprimir.FormatoLinea(pvValores, psFormatos, psgLongitudes, pnAlineaciones, 6, 0.05)

                piImprimir.PrintLine(psLinea)
            Next


            '----------------------------FACILITO
            If Trim(CStr(DatosGenerales.Rows(0).Item("AutorizacionFacilito"))) <> String.Empty Then
                psLinea = DatosGenerales.Rows(0).Item("AutorizacionFacilito")
                piImprimir.PrintLine(0, psLinea, "", 5.5, piImprimir.ImpAlineacion.Izquierda)
            End If
            If Trim(CStr(DatosGenerales.Rows(0).Item("LeyendaPago"))) <> String.Empty Then
                psLinea = DatosGenerales.Rows(0).Item("LeyendaPago")
                piImprimir.PrintLine(0, psLinea, "", 5.5, piImprimir.ImpAlineacion.Izquierda)
            End If
            '----------------------------FACILITO
            piImprimir.PrintLine("")

            '--------------Total en Letra
            psLinea = DatosGenerales.Rows(0).Item("CantidadTexto")
            piImprimir.PrintLine(0, psLinea, "", 7.5, piImprimir.ImpAlineacion.Izquierda)
            '--------------Total en Letra

            piImprimir.PrintLine("")

            '---------------------Descuentos
            pvValores(0) = "Desc. Aplicado:"
            psFormatos(0) = ""
            psgLongitudes(0) = 2.3
            pnAlineaciones(0) = piImprimir.ImpAlineacion.Izquierda

            'If CodTipoVenta = "P" Or CodTipoVenta = "V" Then
            'pvValores(1) = DatosGenerales.Rows(0).Item("Descuento") * (oAppContext.ApplicationConfiguration.IVA + 1)
            'Else
            pvValores(1) = DatosGenerales.Rows(0).Item("Descuento")
            'End If
            psFormatos(1) = "$#,##0.00"
            psgLongitudes(1) = 2.3
            pnAlineaciones(1) = piImprimir.ImpAlineacion.Izquierda
            If pvValores(1) <> 0 Then
                psLinea = piImprimir.FormatoLinea(pvValores, psFormatos, psgLongitudes, pnAlineaciones, 2, 0.1)
                piImprimir.PrintLine(psLinea)
            End If
            '---------------------Descuentos
            piImprimir.PrintLine("")

            '----------------------------SUBTOTAL
            If DatosGenerales.Rows(0).Item("Subtotal") <> 0 Then
                psLinea = "SUBTOTAL : " & Format(CDbl(DatosGenerales.Rows(0).Item("Subtotal")), "$#,##0.00")
                piImprimir.PrintLine(1.5, psLinea, "", 3.5, piImprimir.ImpAlineacion.Izquierda)
            End If
            '----------------------------SUBTOTAL

            '----------------------------IVA
            If DatosGenerales.Rows(0).Item("Iva") <> 0 Then
                psLinea = "     IVA : " & Format(CDbl(DatosGenerales.Rows(0).Item("IVA")), "$#,##0.00")
                piImprimir.PrintLine(1.5, psLinea, "", 3.5, piImprimir.ImpAlineacion.Izquierda)
            End If
            '----------------------------IVA

            '----------------------------TOTAL
            psLinea = "   TOTAL : " & Format(CDbl(DatosGenerales.Rows(0).Item("Total")), "$#,##0.00")
            piImprimir.PrintLine(1.5, psLinea, "", 3.5, piImprimir.ImpAlineacion.Izquierda)
            '----------------------------TOTAL

            '----------Player Informacion
            psLinea = "Player : " & DatosGenerales.Rows(0).Item("CodVendedor")
            piImprimir.PrintLine(psLinea)
            '----------Player Informacion

            psFormatos(0) = ""
            psgLongitudes(0) = 2.0
            pnAlineaciones(0) = piImprimir.ImpAlineacion.Izquierda
            psFormatos(1) = ""
            psgLongitudes(1) = 0.9
            pnAlineaciones(1) = piImprimir.ImpAlineacion.Izquierda
            psFormatos(2) = "$#,##0.00"
            psgLongitudes(2) = 2.4
            pnAlineaciones(2) = piImprimir.ImpAlineacion.Izquierda
            For i = 0 To FormaPago.Rows.Count - 1
                If i = 0 Then
                    pvValores(0) = "Pago:"
                Else
                    pvValores(0) = ""
                End If
                pvValores(1) = FormaPago.Rows(i).Item("CodFormasPago")
                pvValores(2) = FormaPago.Rows(i).Item("MontoPago")
                psLinea = piImprimir.FormatoLinea(pvValores, psFormatos, psgLongitudes, pnAlineaciones, 3, 0.1)
                piImprimir.PrintLine(psLinea)
            Next

            ''--------Letreros de Aviso de sistemas
            'For i = 0 To Notas.Rows.Count - 1
            '    psLinea = Notas.Rows(i).Item("Nota")
            '    piImprimir.PrintLine(0, psLinea, "", 10.5, piImprimir.ImpAlineacion.Izquierda)
            'Next
            ''---------------------------------------
            piImprimir.PrintLine("")
            piImprimir.PrintLine("")
            piImprimir.PrintLine("")
            piImprimir.PrintLine("")
            piImprimir.PrintLine("")
            piImprimir.PrintLine("")
            piImprimir.PrintLine("")
            '            piImprimir.AvanzaPagina()

            piImprimir.PrintLine(Chr(27) & Chr(105)) 'Para Cortar la Hoja

            piImprimir.ClosePort()
        Catch ex As Exception

            MsgBox(ex.ToString)   ' Show friendly error message.       

        End Try


    End Sub


    Public Function Letras(ByVal numero As String) As String
        '********Declara variables de tipo cadena************
        Dim palabras, entero, dec, flag As String

        '********Declara variables de tipo entero***********
        Dim num, x, y As Integer

        flag = "N"

        '**********Número Negativo***********
        If Mid(numero, 1, 1) = "-" Then
            numero = Mid(numero, 2, numero.ToString.Length - 1).ToString
            palabras = "menos "
        End If

        '**********Si tiene ceros a la izquierda*************
        For x = 1 To numero.ToString.Length
            If Mid(numero, 1, 1) = "0" Then
                numero = Trim(Mid(numero, 2, numero.ToString.Length).ToString)
                If Trim(numero.ToString.Length) = 0 Then palabras = ""
            Else
                Exit For
            End If
        Next

        '*********Dividir parte entera y decimal************
        For y = 1 To Len(numero)
            If Mid(numero, y, 1) = "." Then
                flag = "S"
            Else
                If flag = "N" Then
                    entero = entero + Mid(numero, y, 1)
                Else
                    dec = dec + Mid(numero, y, 1)
                End If
            End If
        Next y

        If Len(dec) = 1 Then dec = dec & "0"

        '**********proceso de conversión***********
        flag = "N"

        If Val(numero) <= 999999999 Then
            For y = Len(entero) To 1 Step -1
                num = Len(entero) - (y - 1)
                Select Case y
                    Case 3, 6, 9
                        '**********Asigna las palabras para las centenas***********
                        Select Case Mid(entero, num, 1)
                            Case "1"
                                If Mid(entero, num + 1, 1) = "0" And Mid(entero, num + 2, 1) = "0" Then
                                    palabras = palabras & "cien "
                                Else
                                    palabras = palabras & "ciento "
                                End If
                            Case "2"
                                palabras = palabras & "doscientos "
                            Case "3"
                                palabras = palabras & "trescientos "
                            Case "4"
                                palabras = palabras & "cuatrocientos "
                            Case "5"
                                palabras = palabras & "quinientos "
                            Case "6"
                                palabras = palabras & "seiscientos "
                            Case "7"
                                palabras = palabras & "setecientos "
                            Case "8"
                                palabras = palabras & "ochocientos "
                            Case "9"
                                palabras = palabras & "novecientos "
                        End Select
                    Case 2, 5, 8
                        '*********Asigna las palabras para las decenas************
                        Select Case Mid(entero, num, 1)
                            Case "1"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    flag = "S"
                                    palabras = palabras & "diez "
                                End If
                                If Mid(entero, num + 1, 1) = "1" Then
                                    flag = "S"
                                    palabras = palabras & "once "
                                End If
                                If Mid(entero, num + 1, 1) = "2" Then
                                    flag = "S"
                                    palabras = palabras & "doce "
                                End If
                                If Mid(entero, num + 1, 1) = "3" Then
                                    flag = "S"
                                    palabras = palabras & "trece "
                                End If
                                If Mid(entero, num + 1, 1) = "4" Then
                                    flag = "S"
                                    palabras = palabras & "catorce "
                                End If
                                If Mid(entero, num + 1, 1) = "5" Then
                                    flag = "S"
                                    palabras = palabras & "quince "
                                End If
                                If Mid(entero, num + 1, 1) > "5" Then
                                    flag = "N"
                                    palabras = palabras & "dieci"
                                End If
                            Case "2"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "veinte "
                                    flag = "S"
                                Else
                                    palabras = palabras & "veinti"
                                    flag = "N"
                                End If
                            Case "3"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "treinta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "treinta y "
                                    flag = "N"
                                End If
                            Case "4"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "cuarenta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "cuarenta y "
                                    flag = "N"
                                End If
                            Case "5"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "cincuenta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "cincuenta y "
                                    flag = "N"
                                End If
                            Case "6"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "sesenta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "sesenta y "
                                    flag = "N"
                                End If
                            Case "7"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "setenta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "setenta y "
                                    flag = "N"
                                End If
                            Case "8"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "ochenta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "ochenta y "
                                    flag = "N"
                                End If
                            Case "9"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "noventa "
                                    flag = "S"
                                Else
                                    palabras = palabras & "noventa y "
                                    flag = "N"
                                End If
                        End Select
                    Case 1, 4, 7
                        '*********Asigna las palabras para las unidades*********
                        Select Case Mid(entero, num, 1)
                            Case "1"
                                If flag = "N" Then
                                    If y = 1 Then
                                        palabras = palabras & "uno "
                                    Else
                                        palabras = palabras & "un "
                                    End If
                                End If
                            Case "2"
                                If flag = "N" Then palabras = palabras & "dos "
                            Case "3"
                                If flag = "N" Then palabras = palabras & "tres "
                            Case "4"
                                If flag = "N" Then palabras = palabras & "cuatro "
                            Case "5"
                                If flag = "N" Then palabras = palabras & "cinco "
                            Case "6"
                                If flag = "N" Then palabras = palabras & "seis "
                            Case "7"
                                If flag = "N" Then palabras = palabras & "siete "
                            Case "8"
                                If flag = "N" Then palabras = palabras & "ocho "
                            Case "9"
                                If flag = "N" Then palabras = palabras & "nueve "
                        End Select
                End Select

                '***********Asigna la palabra mil***************
                If y = 4 Then
                    If Mid(entero, 6, 1) <> "0" Or Mid(entero, 5, 1) <> "0" Or Mid(entero, 4, 1) <> "0" Or _
                    (Mid(entero, 6, 1) = "0" And Mid(entero, 5, 1) = "0" And Mid(entero, 4, 1) = "0" And _
                    Len(entero) <= 6) Then palabras = palabras & "mil "
                End If

                '**********Asigna la palabra millón*************
                If y = 7 Then
                    If Len(entero) = 7 And Mid(entero, 1, 1) = "1" Then
                        palabras = palabras & "millón "
                    Else
                        palabras = palabras & "millones "
                    End If
                End If
            Next y

            '**********Une la parte entera y la parte decimal*************
            If dec <> "" Then
                Letras = palabras & " pesos con " & dec & "/100 M.N."
            Else
                Letras = palabras
            End If
        Else
            Letras = ""
        End If
    End Function

#Region "Facturacion SiHay"

    '---------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 29/04/2013: Obtiene los datos que se imprimiran en el voucher para los tickets de Pedidos
    '---------------------------------------------------------------------------------------------------------------------------------

    Public Sub ObtenerDatosPedidoSH(ByRef DataInfo As rptFacturaInfo, ByRef General As DataTable, ByRef FormaPago As DataTable, ByRef Notas As DataTable)
        Dim piImp As RepAjustesESEng.cImpresionFactura
        Dim pedido As Pedidos
        Dim oClientesMgr As ClientesManager
        Dim oCliente As ClienteAlterno
        Dim oAvisosFacturaMgr As AvisosFacturaManager
        Dim pdsAvisos As DataSet
        Dim oCatalogoAlmacenesMgr As New CatalogoAlmacenesManager(oAppContext)
        Dim oAlmacen As Almacen
        Dim oFacturaFormaPago As FacturaFormaPago
        Dim dsFormaPago As DataSet
        Dim psTipoVenta As String
        Dim psLeyendaPago As String
        Dim psDeudaAbonoFacilito As String
        Dim psAutorizaFacilito As String
        Dim prTmp As Data.DataRow
        Dim i As Integer


        piImp = New RepAjustesESEng.cImpresionFactura
        piImp.CrearDG(General)
        piImp = Nothing
        oClientesMgr = New ClientesManager(oAppContext)
        oCliente = oClientesMgr.CreateAlterno
        oAvisosFacturaMgr = New AvisosFacturaManager(oAppContext)
        pdsAvisos = oAvisosFacturaMgr.LoadEnabled("FACTURACION", True)
        oFacturaFormaPago = New FacturaFormaPago(oAppContext)
        dsFormaPago = New DataSet
        pedido = New Pedidos(DataInfo.PedidoID)
        If pedido.CodTipoVenta.Trim = "P" AndAlso pedido.ClienteID <= 0 Then pedido.ClienteID = "1"

        '-------------------------------------------------------------------------------------------------------------------------------------------------
        ' JNAVA (03.03.2016): realizamos las validacio en base al tipo de venta
        '-------------------------------------------------------------------------------------------------------------------------------------------------
        'If pedido.ClienteID <> "1" AndAlso pedido.ClienteID <> "99999" Then
        If pedido.CodTipoVenta <> "P" AndAlso pedido.CodTipoVenta <> "E" Then
            'If pedido.CodTipoVenta = "A" Then
            '    oClientesMgr.Load(CStr(pedido.ClienteID).PadLeft(10, "0"), oCliente, "I")
            'Else
            '    oClientesMgr.Load(CStr(pedido.ClienteID).PadLeft(10, "0"), oCliente, pedido.CodTipoVenta)
            'End If
            GetCliente(CStr(pedido.ClienteID).PadLeft(10, "0"), pedido.CodTipoVenta.Trim)
            oClientesMgr.Load(CStr(pedido.ClienteID).PadLeft(10, "0"), oCliente)
        Else
            oClientesMgr.Load(CStr(pedido.ClientePGID).PadLeft(10, "0"), oCliente)
        End If
        '-------------------------------------------------------------------------------------------------------------------------------------------------
        ' JNAVA (03.03.2016): Obtenemos el almacen en base al centro SAP 
        '-------------------------------------------------------------------------------------------------------------------------------------------------
        Dim oSAPMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        oAlmacen = oCatalogoAlmacenesMgr.Load(oSAPMgr.Read_Centros) 'oAppContext.ApplicationConfiguration.Almacen)
        '-------------------------------------------------------------------------------------------------------------------------------------------------
        Select Case pedido.CodTipoVenta
            Case "P"
                psTipoVenta = "PISO DE VENTA"
            Case "V"
                psTipoVenta = "DPVALE" & " (" & CStr(DataInfo.FolioDPVale).PadLeft(10, "0") & ")"
            Case "D"
                psTipoVenta = "ASOCIADO (DIP'S)"
            Case "S"
                psTipoVenta = "DPSOCIO"
            Case "F", "K"
                psTipoVenta = "CRÉDITO FONACOT"
            Case "O"
                psTipoVenta = "CRÉDITO FACILITO"
            Case "M"
                psTipoVenta = "MAYOREO"
            Case "I"
                psTipoVenta = "FACTURACIÓN FISCAL"
            Case "A"
                psTipoVenta = "APARTADO"
            Case "E"
                psTipoVenta = "EMPLEADO"
        End Select
        If pedido.CodTipoVenta = "O" Or pedido.CodTipoVenta = "F" Or pedido.CodTipoVenta = "K" Then
            psLeyendaPago = "Pago hecho en una sola exhibición"
            If pedido.CodTipoVenta = "O" Then
                psAutorizaFacilito = "Autorización Facilito : " & pedido.NumeroFacilito.ToString
                If DataInfo.DeudaFacilito < pedido.Total Then
                    psDeudaAbonoFacilito = "Su Abono: " & Format(pedido.Total - DataInfo.DeudaFacilito, "Currency") & " Ud. Debe a Facilito:" & Format(DataInfo.DeudaFacilito, "Currency")
                Else
                    psDeudaAbonoFacilito = "Ud. Debe a Facilito:" & Format(DataInfo.DeudaFacilito, "Currency")
                End If
            End If
        Else
            psLeyendaPago = "Pago hecho en una sola exhibición"
        End If
        Dim column = New DataColumn()
        column.DataType = Type.GetType("System.String")
        column.ColumnName = "ClienteID"
        General.Columns.Add(column)
        prTmp = General.NewRow()
        prTmp.Item("ClienteID") = oCliente.CodigoAlterno
        prTmp.Item("FolioFactura") = pedido.FolioPedido
        prTmp.Item("CodCaja") = pedido.CodCaja
        prTmp.Item("Fecha") = Format$(pedido.Fecha, "dd/MM/yy") & " " & Format$(Now, "hh:mm:ss")
        '-------------------------------------------------------------------------------------------------------------------------------------------------
        ' JNAVA (03.03.2016): realizamos las validacio en base al tipo de venta
        '-------------------------------------------------------------------------------------------------------------------------------------------------
        'If (pedido.ClienteID <> "1" AndAlso pedido.ClienteID <> "99999") Then
        If pedido.CodTipoVenta <> "P" AndAlso pedido.CodTipoVenta <> "E" Then
            prTmp.Item("NombreCliente") = oCliente.Nombre & " " & oCliente.ApellidoPaterno & " " & oCliente.ApellidoMaterno
            prTmp.Item("Domicilio") = CStr(oCliente.Direccion & " " & oCliente.Colonia & " " & oCliente.NumExt & " " & oCliente.NumInt).TrimEnd
            prTmp.Item("Ciudad") = oCliente.Ciudad
            prTmp.Item("RFC") = oCliente.RFC
            prTmp.Item("Telefono") = oCliente.Telefono
            'If InStr("D,S", oFactura.CodTipoVenta) > 0 AndAlso oConfigCierreFI.AplicaNewDescuentosDIPs Then
            '    prTmp.Item("Iva") = 0
            '    prTmp.Item("Subtotal") = 0
            'Else
            prTmp.Item("Iva") = pedido.IVA
            prTmp.Item("Subtotal") = pedido.SubTotal
            'End If
            If CStr(oCliente.CP) = "" Then
                prTmp.Item("Estado") = oCliente.Estado
            Else
                prTmp.Item("Estado") = oCliente.Estado & " " & oCliente.CP
            End If
            '-------------------------------------------------------------------------------------------------------------------------------------------------
            ' JNAVA (03.03.2016): realizamos las validacio en base al tipo de venta
            '-------------------------------------------------------------------------------------------------------------------------------------------------
            'ElseIf pedido.ClienteID = "99999" Then
        ElseIf pedido.CodTipoVenta = "E" Then
            prTmp.Item("NombreCliente") = "EMPLEADO"
            prTmp.Item("Ciudad") = oAlmacen.DireccionCiudad
            prTmp.Item("Estado") = oAlmacen.DireccionEstado
            prTmp.Item("Domicilio") = ""
            prTmp.Item("RFC") = ""
            prTmp.Item("Telefono") = ""
            prTmp.Item("Subtotal") = 0
            prTmp.Item("Iva") = 0
        Else
            'prTmp.Item("NombreCliente") = "PÚBLICO GENERAL"
            prTmp.Item("Ciudad") = oAlmacen.DireccionCiudad
            prTmp.Item("Estado") = oAlmacen.DireccionEstado
            prTmp.Item("Domicilio") = ""
            prTmp.Item("RFC") = ""
            prTmp.Item("Telefono") = ""
            prTmp.Item("Subtotal") = 0
            prTmp.Item("Iva") = 0
            If pedido.ClientePGID <= 0 Then
                prTmp.Item("NombreCliente") = "PÚBLICO GENERAL"
            Else
                oClientesMgr.Load(pedido.ClientePGID, oCliente)
                If oCliente.CodigoAlterno.Trim() <> "" Then
                    prTmp.Item("NombreCliente") = oCliente.Nombre & " " & oCliente.ApellidoPaterno & " " & oCliente.ApellidoMaterno
                    prTmp.Item("Domicilio") = CStr(oCliente.Direccion & " " & oCliente.Colonia & " " & oCliente.NumExt & " " & oCliente.NumInt).TrimEnd
                    prTmp.Item("Ciudad") = oCliente.Ciudad
                    prTmp.Item("Telefono") = oCliente.Telefono
                    If CStr(oCliente.CP) = "" Then
                        prTmp.Item("Estado") = oCliente.Estado & vbCrLf
                    Else
                        prTmp.Item("Estado") = oCliente.Estado & " " & oCliente.CP & vbCrLf
                    End If
                Else
                    prTmp.Item("NombreCliente") = "PÚBLICO GENERAL"
                End If
            End If
        End If

        '-------------------------------------------------------------------------------------------------------------------------------------------------
        'JNAVA 22.12.2014: Se agregaron titulos a los nombres de clientes y distribuidores por temas fiscales solicitado en mail de Lety 19.12.2014
        '-------------------------------------------------------------------------------------------------------------------------------------------------
        If DataInfo.NombreAsociado <> "" Then
            prTmp.Item("NombreCliente") = "ACREDITADO" & vbCrLf & DataInfo.NombreAsociado
        End If
        If DataInfo.vNombreClienteAsociado <> "" Then
            prTmp.Item("Domicilio") = "CANJEANTE" & vbCrLf & DataInfo.vNombreClienteAsociado
        End If
        'If DataInfo.NombreAsociado <> "" Then
        '    prTmp.Item("NombreCliente") = DataInfo.NombreAsociado
        'End If
        'If DataInfo.vNombreClienteAsociado <> "" Then
        '    prTmp.Item("Domicilio") = DataInfo.vNombreClienteAsociado
        'End If
        prTmp.Item("FormaPago") = psLeyendaPago
        prTmp.Item("TipoVenta") = psTipoVenta
        prTmp.Item("AutorizacionFacilito") = " " & psAutorizaFacilito
        prTmp.Item("LeyendaPago") = " " & psDeudaAbonoFacilito
        'If InStr("D,S", oFactura.CodTipoVenta) > 0 AndAlso oConfigCierreFI.AplicaNewDescuentosDIPs Then
        'prTmp.Item("Descuento") = oFactura.DescTotal * (1 + (oFactura.IVA / oFactura.SubTotal))
        'Else
        prTmp.Item("Descuento") = pedido.DescTotal
        'End If
        prTmp.Item("Total") = pedido.Total
        prTmp.Item("CantidadTexto") = UCase(Letras(Decimal.Round(pedido.Total, 2)))
        prTmp.Item("CodVendedor") = pedido.CodVendedor
        General.Rows.Add(prTmp)

        Notas = pdsAvisos.Tables(0).Copy()
        dsFormaPago = oFacturaFormaPago.Load(DataInfo.FacturaID)
        FormaPago = dsFormaPago.Tables("FacturasFormasPago").Copy()
        oCatalogoAlmacenesMgr = Nothing
        oAlmacen = Nothing
    End Sub
#End Region

    Public Sub New()

    End Sub

End Class
