Imports DportenisPro.DPTienda.Core
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos
Imports DportenisPro.DPTienda.ApplicationUnits.Facturas
Imports DportenisPro.DPTienda.ApplicationUnits.ConfiguracionSAPAU
Imports DportenisPro.DPTienda.ApplicationUnits.ConfigSaveArchivos
Imports DportenisPro.DPTienda.ApplicationUnits.FacturasCorrida
Imports DportenisPro.DPTienda.ApplicationUnits.FacturasFormaPago
Imports DportenisPro.DPTienda.ApplicationUnits.Clientes
Imports DportenisPro.DPTienda.ApplicationUnits.ValeCaja
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU
Imports System.Collections.Generic
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoTipoVenta
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoFormasPago

Public Class NotasCreditoMasivoManager
    Inherits NotasCreditoManager

#Region "Constantes"
    Private Const SEPARADORVALORES As String = ","
#End Region

#Region "Variables"

    Private oFacturaCorridaMgr As FacturaCorridaManager
    Private oFacturaMgr As FacturaManager
    Private oFacturaFormaPago As FacturaFormaPago
    Private oArticulo As Articulo
    Private oCatalogoArticulosMgr As CatalogoArticuloManager
    Private oNotaCredito As NotaCredito
    Private oCliente As ClienteAlterno
    Private oCatalogoClientesMgr As ClientesManager
    Private oValeCaja As ValeCaja.ValeCaja
    Private oValeCajaMgr As ValeCajaManager
    Private oProcesosSAPMgr As ProcesoSAPManager
    Private oCatFormaPago As CatalogoFormasPagoManager
    Private strTablaTmp As String = "NotaCreditoMasDetalleTmp" & ApplicationContext.ApplicationConfiguration.Almacen & ApplicationContext.ApplicationConfiguration.NoCaja & ApplicationContext.Security.CurrentUser.ID

#End Region


    Public Sub New(ByVal ApplicationContext As ApplicationContext, Optional ByVal SAPConfiguration As SAPApplicationConfig = Nothing, Optional ByVal ConfigCierre As SaveConfigArchivos = Nothing)
        MyBase.New(ApplicationContext, SAPConfiguration, ConfigCierre)
    End Sub

    Public Overrides Sub Save(pNotaCredito As NotaCredito, EnvioServerPG As Boolean, FolioPedido As String, Optional ByRef strError As String = "")
        Dim oNotasCreditoDG As New NotasCreditoMasivoDataGateway(Me)


        If (pNotaCredito Is Nothing) Then
            Throw New ArgumentNullException("El parámetro Nota Credito no puede ser nulo.")
        End If

        If (pNotaCredito.IsNew) Then
            oNotasCreditoDG.Insert(pNotaCredito, EnvioServerPG, FolioPedido, strError)
        End If

        oNotasCreditoDG = Nothing
    End Sub

    ''' <summary>
    ''' Función para crear el esquema de la tabla necesaria para la validacion de notas de crédito y facturas
    ''' </summary>
    ''' <returns>Objeto datatable vacía con la estructura requerida</returns>
    ''' <remarks></remarks>
    Private Function CreaEstructuraDatos() As DataTable
        Dim DatosFuente As DataTable
        DatosFuente = New DataTable()

        DatosFuente.Columns.Add("Seleccionado", Type.GetType("System.Boolean"))
        DatosFuente.Columns.Add("CodAlmacen")
        DatosFuente.Columns.Add("TipoVenta")
        DatosFuente.Columns.Add("CodCliente")
        DatosFuente.Columns.Add("FolioDPPRO")
        DatosFuente.Columns.Add("FolioSAP")
        DatosFuente.Columns.Add("CodArticulo")
        DatosFuente.Columns.Add("Talla")
        DatosFuente.Columns.Add("Cantidad")
        DatosFuente.Columns.Add("PrecioUnit")
        DatosFuente.Columns.Add("Descuento")
        DatosFuente.Columns.Add("PrecioFinal")
        DatosFuente.Columns.Add("CodFormaPago")
        DatosFuente.Columns.Add("Importe")
        DatosFuente.Columns.Add("DPValeID")
        DatosFuente.Columns.Add("FolioDist")
        DatosFuente.Columns.Add("Mensaje")
        DatosFuente.Columns.Add("FacturaId")
        DatosFuente.Columns.Add("Registro")
        DatosFuente.Columns.Add("FolioNotaCredito")
        DatosFuente.Columns.Add("FolioValeCaja")
        DatosFuente.Columns.Add("MontoValeCaja")
        DatosFuente.Columns.Add("NotaCreditoID")

        'datos de la nueva factura
        DatosFuente.Columns.Add("FTipoVenta")
        DatosFuente.Columns.Add("FCodCliente")
        DatosFuente.Columns.Add("FFolioDPPRO")
        DatosFuente.Columns.Add("FFolioSAP")
        DatosFuente.Columns.Add("FCodArticulo")
        DatosFuente.Columns.Add("FTalla")
        DatosFuente.Columns.Add("FCantidad")
        DatosFuente.Columns.Add("FPrecioUnit")
        DatosFuente.Columns.Add("FDescuento")
        DatosFuente.Columns.Add("FPrecioFinal")
        DatosFuente.Columns.Add("FFolioValeCaja")
        DatosFuente.Columns.Add("FMontoValeCaja")
        DatosFuente.Columns.Add("FDiferenciaPago")
        DatosFuente.Columns.Add("FCodFormaPago")
        DatosFuente.Columns.Add("FImporte")
        DatosFuente.Columns.Add("FDPValeID")
        DatosFuente.Columns.Add("FFolioDist")
        DatosFuente.Columns.Add("FMensaje")
        DatosFuente.Columns.Add("FFacturaId")
        DatosFuente.Columns.Add("FIDocument")
        DatosFuente.Columns.Add("FReferencia")
        DatosFuente.Columns.Add("Estatus")
        DatosFuente.Columns.Add("FSerialId")

        'TipoVenta, 
        DatosFuente.Columns.Add("ColumnasCambiadas")
        Return DatosFuente
    End Function

    ''' <summary>
    ''' Función para validar el contenido de un archivo y regresar la tabla con el resultado de la validación de cada registro
    ''' </summary>
    ''' <param name="NombreArchivo">Path completo al archivo a cargar</param>
    ''' <returns>Object datatable </returns>
    ''' <remarks>
    ''' La función viene como resultado de un FileDialog por lo que se intuye que existe y es del formato requerido
    ''' </remarks>
    Public Function ValidaArchivo(ByVal NombreArchivo As String, ByRef strError As String) As DataTable
        Dim DatosFuente As DataTable = CreaEstructuraDatos()
        Try
            Dim sr As New System.IO.StreamReader(NombreArchivo)
            Dim oNotasCreditoDG As New NotasCreditoMasivoDataGateway(Me)

            oFacturaMgr = New FacturaManager(ApplicationContext, ConfigCierre)
            oFacturaCorridaMgr = New FacturaCorridaManager(ApplicationContext)
            oFacturaFormaPago = New FacturaFormaPago(ApplicationContext)
            oFacturaFormaPago = New FacturaFormaPago(ApplicationContext)
            oCatalogoArticulosMgr = New CatalogoArticuloManager(ApplicationContext)
            oCatalogoClientesMgr = New ClientesManager(ApplicationContext)
            oValeCajaMgr = New ValeCajaManager(ApplicationContext)
            oProcesosSAPMgr = New ProcesoSAPManager(ApplicationContext, SAPApplicationConfig)
            oCatFormaPago = New CatalogoFormasPagoManager(ApplicationContext)

            Dim registrosExistentes As DataTable = oFacturaMgr.SelectFacturasNotasCreditoMasivo()
            Dim catalogoEquivalencias As DataTable = oNotasCreditoDG.CatalogoArticulosEquivalencia()
            Do While sr.Peek() >= 0
                Dim registro As DataRow = DatosFuente.NewRow()
                Try
                    ValidaCaptura(sr.ReadLine(), registro, registrosExistentes, catalogoEquivalencias)
                Catch ex As Exception
                    registro("Mensaje") += ex.Message
                End Try
                DatosFuente.Rows.InsertAt(registro, DatosFuente.Rows.Count)
            Loop
            sr.Close()

        Catch ex As Exception
            strError = "Error al procesar el archivo: " & ex.Message
        End Try
        Return DatosFuente
    End Function

    ''' <summary>
    ''' Función que valida un registro de nota de crédito, para captura masiva
    ''' </summary>
    ''' <param name="RegistroTexto">texto separado por comas con los valores de la nota de crédito</param>
    ''' <remarks></remarks>
    Private Sub ValidaCaptura(ByVal RegistroTexto As String, ByRef Registro As DataRow, ByRef RegistrosExistentes As DataTable, ByRef CatalogoEquivalencias As DataTable)

        Dim valores() As String
        valores = RegistroTexto.Split(vbTab)
        '41 columnas obligatorias, las demas se van a ignorar (excel agrega tabs extras al epxportar)
        If valores.Length < 41 OrElse RegistroTexto.Trim().Length = 0 Then
            Registro("Mensaje") = "El registro no cuenta con el formato correcto " & RegistroTexto
        Else
            'Carga los valores
            Registro("Seleccionado") = False
            Registro("Registro") = RegistroTexto
            Registro("Mensaje") = ""
            Registro("CodAlmacen") = ObtenerDato(valores(0).Trim())
            Registro("TipoVenta") = ObtenerDato(valores(2).Trim())
            Registro("CodCliente") = ObtenerDato(valores(3).Trim())
            Registro("FolioDPPRO") = ObtenerDato(valores(5).Trim())
            Registro("FolioSAP") = ObtenerDato(valores(6).Trim())
            Registro("CodArticulo") = ObtenerDato(valores(7).Trim())
            Registro("Talla") = ObtenerDato(valores(8).Trim())
            Registro("Cantidad") = ObtenerDato(valores(9).Trim())
            Registro("PrecioUnit") = ObtenerDato(valores(11).Trim())
            Registro("Descuento") = ObtenerDato(valores(12).Trim())
            Registro("PrecioFinal") = ObtenerDato(valores(13).Trim())
            Registro("CodFormaPago") = valores(14).Trim()
            Registro("Importe") = ObtenerDato(valores(15).Trim())
            Registro("DPValeID") = ObtenerDato(valores(16).Trim())
            Registro("FolioDist") = ObtenerDato(valores(17).Trim())
            Registro("FacturaId") = 0

            'datos de la nueva factura
            Registro("FTipoVenta") = ObtenerDato(valores(22).Trim())
            Registro("FCodCliente") = ObtenerDato(valores(23).Trim())
            Registro("FFolioDPPRO") = ObtenerDato(valores(25).Trim())
            Registro("FFolioSAP") = ObtenerDato(valores(26).Trim())
            Registro("FCodArticulo") = ObtenerDato(valores(27).Trim())
            Registro("FTalla") = ObtenerDato(valores(28).Trim())
            Registro("FCantidad") = ObtenerDato(valores(29).Trim())
            Registro("FPrecioUnit") = ObtenerDato(valores(31).Trim())
            Registro("FDescuento") = ObtenerDato(valores(32).Trim())
            Registro("FPrecioFinal") = ObtenerDato(valores(33).Trim())
            Registro("FFolioValeCaja") = ObtenerDato(valores(34).Trim())
            Registro("FMontoValeCaja") = ObtenerDato(valores(35).Trim())
            Registro("FDiferenciaPago") = ObtenerDato(valores(36).Trim())
            Registro("FCodFormaPago") = ObtenerDato(valores(37).Trim())
            Registro("FImporte") = ObtenerDato(valores(38).Trim())
            Registro("FDPValeID") = ObtenerDato(valores(39).Trim())
            Registro("FFolioDist") = ObtenerDato(valores(40).Trim())
            Registro("FMensaje") = ""
            Registro("FFacturaId") = 0


            'Validamos que venga completo el registro
            Dim registroEncontrado() As DataRow = RegistrosExistentes.Select("Registro = '" & RegistroTexto & "'")
            If registroEncontrado.Length > 0 AndAlso registroEncontrado(0)("Estatus").ToString() = "2" Then
                Registro("Mensaje") = "El registro ya fué procesado anteriormente "
            Else
                If registroEncontrado.Length > 0 Then
                    Registro("Estatus") = registroEncontrado(0)("Estatus").ToString()
                Else
                    Registro("Estatus") = 0
                End If
                Try
                    ValidaValoresNota(Registro, CatalogoEquivalencias)
                Catch ex As Exception
                    Registro("mensaje") = ex.Message
                End Try
                Try
                    ValidaValoresFactura(Registro)
                Catch ex As Exception
                    Registro("Fmensaje") = ex.Message
                End Try

            End If
        End If
    End Sub

    ''' <summary>
    ''' Funnción para realizar las validaciones de los registros del archivo
    ''' </summary>
    ''' <param name="Registro">Datarow con los datos del registro leido</param>
    ''' <param name="Prefijo">vacio o F para los datos que son de la sección de facturación</param>
    ''' <remarks></remarks>
    Private Sub ValidaValoresNota(ByRef Registro As DataRow, ByRef CatalogoEquivalencias As DataTable, Optional ByVal Prefijo As String = "")
        Dim oFactura As Factura
        Dim montoACancelar As Decimal = 0
        'Iniciamos las validaciones de los datos
        oFactura = oFacturaMgr.Create
        oFactura.ClearFields()
        Dim columnasCambiadas As String() = New String(4) {"0", "0", "0", "0", "0"}

        'Validaciones de campos requeridos y tipos de datos
        Dim dummy As Integer
        If Registro("CodAlmacen").ToString() = String.Empty Then
            Registro("Mensaje") = "La sucursal no es válida"
        ElseIf (Registro("CodCliente").ToString() <> String.Empty AndAlso Not Integer.TryParse(Registro("CodCliente").ToString(), dummy)) Then
            Registro("Mensaje") = "El código del cliente no es válido"
        ElseIf Registro("CodFormaPago").ToString() = String.Empty Then
            Registro("Mensaje") = "La forma de pago no es válida"
        ElseIf Registro("CodAlmacen").ToString() = String.Empty Then
            Registro("Mensaje") = "El sucursal no es válida"
        End If

        'validaciones de seguridad
        If Registro("CodAlmacen").ToString() <> ApplicationContext.ApplicationConfiguration.Almacen Then
            Registro("Mensaje") = "El almacen no corresponde a la tienda actual"

        ElseIf Prefijo = String.Empty Then
            If Registro("FolioDPPRO").ToString() = String.Empty Then
                Registro("Mensaje") = "No se cuenta con valor del Folio DPPRO ó Referencia para validar"
            ElseIf Registro("FolioDPPRO").ToString() <> String.Empty Then
                'En la columna folioDPPRo debe venir el valor para buscar
                'Primero se busca por folio SAP,
                'Segundo criterio es folio dppro
                'Tercer criterio es referencia

                Dim folio As Integer = 0
                oFacturaMgr.LoadInto(Registro("FolioDPPRO").ToString().PadLeft(10, "0"), oFactura) 'Por Folio SAP
                If oFactura.FacturaID = 0 AndAlso Integer.TryParse(Registro("FolioDPPRO").ToString(), folio) Then 'por folio dppro
                    oFacturaMgr.Load(folio, ApplicationContext.ApplicationConfiguration.NoCaja, oFactura)
                End If
                If oFactura.FacturaID = 0 Then 'Si no se encuentra por folio hay que buscarlo como Referencia
                    oFacturaMgr.SelectByReferencia(Registro("FolioDPPRO").ToString(), ApplicationContext.ApplicationConfiguration.NoCaja, oFactura)
                End If
                If oFactura.FacturaID = 0 Then
                    Registro("Mensaje") = "El Folio DPPRO o Referencia no es válido"
                End If
            End If
        End If

        'Validamos la factura
        If oFactura.FacturaID = 0 Then
            Registro("Mensaje") += "La factura no existe"
        End If
        If oFactura.CodAlmacen <> ApplicationContext.ApplicationConfiguration.Almacen Then
            Registro("Mensaje") += "El almacen de la factura no corresponde al registro"
        End If
        If Registro("TipoVenta").ToString() <> oFactura.CodTipoVenta Then
            Registro("TipoVenta") = oFactura.CodTipoVenta
            columnasCambiadas(0) = "1"
        End If
        If Registro("CodCliente").ToString() <> String.Empty AndAlso Integer.Parse(Registro("CodCliente").ToString()) <> oFactura.ClienteId Then
            Registro("Mensaje") = "El codigo de cliente de la factura no corresponde al registro"
        End If

        'Valida el detalle
        If Registro("Mensaje").ToString() = String.Empty Then
            Registro("FacturaId") = oFactura.FacturaID
            oFactura.Detalle = oFacturaCorridaMgr.Load(oFactura.FacturaID)
            If oFactura.Detalle.Tables.Count = 0 OrElse oFactura.Detalle.Tables(0).Rows.Count = 0 Then
                Registro("Mensaje") = "La factura no cuenta con artículos"
            Else

                Dim productos As String() = Registro("CodArticulo").ToString().Split(SEPARADORVALORES)
                Dim tallas As String() = Registro("Talla").ToString().Split(SEPARADORVALORES)
                Dim cantidades As String() = Registro("Cantidad").ToString().Split(SEPARADORVALORES)
                Dim precios As String() = Registro("PrecioUnit").ToString().Split(SEPARADORVALORES)
                Dim descuentos As String() = Registro("Descuento").ToString().Split(SEPARADORVALORES)
                Dim preciosFinales As String() = Registro("PrecioFinal").ToString().Split(SEPARADORVALORES)

                If productos.Length = 0 Then
                    Registro("Mensaje") = "El valor de la columna Productos no puede ser vacío. "
                ElseIf cantidades.Length = 0 Then
                    Registro("Mensaje") = "El valor de la columna cantidades no puede ser vacío. "
                ElseIf precios.Length = 0 Then
                    Registro("Mensaje") = "El valor de la columna precios no puede ser vacío. "
                ElseIf descuentos.Length = 0 Then
                    Registro("Mensaje") = "El valor de la columna descuentos no puede ser vacío. "
                ElseIf preciosFinales.Length = 0 Then
                    Registro("Mensaje") = "El valor de la columna preciosFinales no puede ser vacío. "
                ElseIf productos.Length <> tallas.Length Then
                    Registro("Mensaje") = String.Format("La cantidad de productos ({0}) no concuerda con el número de tallas especificadas ({1}). ", productos.Length, tallas.Length)
                ElseIf productos.Length <> cantidades.Length Then
                    Registro("Mensaje") = String.Format("La cantidad de productos ({0}) no concuerda con el número de cantidades especificadas ({1}). ", productos.Length, cantidades.Length)
                ElseIf productos.Length <> precios.Length Then
                    Registro("Mensaje") = String.Format("La cantidad de productos ({0}) no concuerda con el número de cantidades especificadas ({1}). ", productos.Length, precios.Length)
                ElseIf productos.Length <> descuentos.Length Then
                    Registro("Mensaje") = String.Format("La cantidad de productos ({0}) no concuerda con el número de descuentos especificados ({1}). ", productos.Length, descuentos.Length)
                ElseIf productos.Length <> preciosFinales.Length Then
                    Registro("Mensaje") = String.Format("La cantidad de productos ({0}) no concuerda con el número de precios finales especificados ({1}). ", productos.Length, preciosFinales.Length)
                Else
                    For contador As Integer = 0 To productos.Length - 1
                        Dim codigoArticulo As String = productos(contador)

                        If oFactura.Detalle.Tables(0).Select("CodArticulo = '" & codigoArticulo & "'").Length = 0 Then
                            'si no encuentra, lo buscamos por un like
                            If oFactura.Detalle.Tables(0).Select("CodArticulo like '%" & codigoArticulo & "'").Length = 0 Then
                                'si no lo encuentra lo buscamos por el código alterno
                                If CatalogoEquivalencias.Select("CodArticulo like '%" & codigoArticulo & "'").Length > 0 Then
                                    codigoArticulo = CatalogoEquivalencias.Select("CodArticulo like '%" & codigoArticulo & "'")(0)("CodArticuloAnterior")
                                    productos(contador) = CatalogoEquivalencias.Select("CodArticulo like '%" & codigoArticulo & "'")(0)("CodArticulo")
                                    columnasCambiadas(1) = "1"
                                Else
                                    Registro("Mensaje") += String.Format("El artículo {0} no se encuentra en la table de equivalencias de códigos", codigoArticulo)
                                End If
                            Else
                                codigoArticulo = oFactura.Detalle.Tables(0).Select("CodArticulo like '%" & codigoArticulo & "'")(0)("CodArticulo") 'actualizamos el valor correcto
                                productos(contador) = codigoArticulo
                                columnasCambiadas(1) = "1"
                            End If
                        End If


                        If oFactura.Detalle.Tables(0).Select("CodArticulo = '" & codigoArticulo & "'").Length = 0 Then
                            Registro("Mensaje") += String.Format("El artículo {0} no se encuentra en la factura original", codigoArticulo)
                        Else
                            'Validamos los datos del artículo encontrado
                            Dim registroFactura As DataRow = oFactura.Detalle.Tables(0).Select("CodArticulo = '" & codigoArticulo & "'")(0)
                            If registroFactura("Numero") <> tallas(contador) Then
                                Registro("Mensaje") += String.Format("La talla del artículo {0} no corresponde al registro. ", productos(contador))
                            ElseIf registroFactura("Cantidad") < cantidades(contador) Then
                                Registro("Mensaje") += String.Format("La Cantidad del artículo {0} no corresponde al registro. ", productos(contador))
                            Else
                                If registroFactura("PrecioOferta") <> Convert.ToDecimal(precios(contador)) Then
                                    precios(contador) = registroFactura("PrecioOferta")
                                    columnasCambiadas(2) = "1"
                                End If
                                If registroFactura("Descuento") + registroFactura("DescuentoSistema") <> Convert.ToDecimal(descuentos(contador)) Then
                                    descuentos(contador) = registroFactura("Descuento") + registroFactura("DescuentoSistema")
                                    columnasCambiadas(3) = "1"
                                End If
                                If registroFactura("PrecioOferta") - (registroFactura("PrecioOferta") * ((registroFactura("Descuento") + registroFactura("DescuentoSistema")) / 100)) <> Convert.ToDecimal(preciosFinales(contador)) Then
                                    preciosFinales(contador) = registroFactura("PrecioOferta") - (registroFactura("PrecioOferta") * ((registroFactura("Descuento") + registroFactura("DescuentoSistema")) / 100))
                                    columnasCambiadas(4) = "1"
                                Else
                                    montoACancelar += Convert.ToDecimal(preciosFinales(contador))
                                End If
                            End If
                        End If
                    Next
                    'Actualizamos la lista de productos por si se actualizó con el formato correcto
                    Registro("CodArticulo") = String.Join(SEPARADORVALORES, productos)
                    Registro("PrecioUnit") = String.Join(SEPARADORVALORES, precios)
                    Registro("Descuento") = String.Join(SEPARADORVALORES, descuentos)
                    Registro("PrecioFinal") = String.Join(SEPARADORVALORES, preciosFinales)
                End If
            End If
        End If

        'Validamos las formas de pago
        If Registro("Mensaje").ToString() = String.Empty Then

            Dim formasPago() As String = Registro("CodFormaPago").ToString().Split(SEPARADORVALORES)
            Dim montosFormasPago() As String = Registro("Importe").ToString().Split(SEPARADORVALORES)
            Dim dsFormaPago As DataSet = oFacturaFormaPago.Load(oFactura.FacturaID)
            Dim dummy2 As Decimal
            If formasPago.Length = 0 Then
                Registro("Mensaje") = "El valor de la columna Formas de pago no puede ser vacío. "
            ElseIf montosFormasPago.Length = 0 Then
                Registro("Mensaje") = "El valor de la columna Montos de pago no puede ser vacío. "
            ElseIf dsFormaPago.Tables.Count = 0 OrElse dsFormaPago.Tables(0).Rows.Count = 0 Then
                Registro("Mensaje") = "La factura no cuenta con formas de pago"
            ElseIf formasPago.Length <> montosFormasPago.Length Then
                Registro("Mensaje") = String.Format("La cantidad de formas de pago ({0}) no concuerda con el número de montos de forma de pago especificados ({1}). ", formasPago.Length, montosFormasPago.Length)
            Else
                For contador As Integer = 0 To formasPago.Length - 1
                    If formasPago(contador).Trim.Length = 0 Then
                        Registro("Mensaje") += "El valor del campo forma de pago no puede ser vacío. "
                    ElseIf montosFormasPago(contador).Trim.Length = 0 Then
                        Registro("Mensaje") += "El valor del campo monto de pago no puede ser vacío. "
                    ElseIf formasPago(contador).Trim <> "" AndAlso dsFormaPago.Tables(0).Select("codFormasPago = '" & formasPago(contador).Trim & "'").Length = 0 Then
                        Registro("Mensaje") += String.Format("La forma de pago {0} no no se encuentra en la factura. ", formasPago(contador))
                    ElseIf formasPago(contador) = "DPVL" AndAlso String.Empty = Registro("DPValeID") Then
                        Registro("Mensaje") += "La forma de pago DPVALE requiere del valor en la columna Folio DPVALE. "
                    ElseIf formasPago(contador) = "DPVL" AndAlso dsFormaPago.Tables(0).Select("codFormasPago = '" & formasPago(contador).Trim & "'").Length > 0 AndAlso dsFormaPago.Tables(0).Select("codFormasPago = '" & formasPago(contador).Trim & "'")(0)("DPValeID") <> Registro("DPValeID") Then
                        Registro("Mensaje") += "El ValeId de la factura no corresponde registro. "
                    ElseIf Not Decimal.TryParse(montosFormasPago(contador), dummy2) Then
                        Registro("Mensaje") += "El monto de la forma de pago no es válido. "
                    End If
                Next
                If Registro("Mensaje") = String.Empty Then
                    Dim montoDisponible As Decimal = dsFormaPago.Tables(0).Compute("sum(MontoPago)-SUM(MontoCancelado)", "")
                    If montoDisponible <= montoACancelar Then
                        Registro("Mensaje") += "El monto disponible de la factura es menor que el monto a cancelar. "
                    End If
                End If
            End If
        End If
        Registro("ColumnasCambiadas") = String.Join(",", columnasCambiadas)
    End Sub

    ''' <summary>
    ''' Funnción para realizar las validaciones de los registros del archivo
    ''' </summary>
    ''' <param name="Registro">Datarow con los datos del registro leido</param>
    ''' <param name="Prefijo">vacio o F para los datos que son de la sección de facturación</param>
    ''' <remarks></remarks>
    Private Sub ValidaValoresFactura(ByRef Registro As DataRow, Optional ByVal Prefijo As String = "")
        Dim oArticulo As Articulo
        Dim oFactura As Factura
        oFactura = oFacturaMgr.Create
        oArticulo = oCatalogoArticulosMgr.Create

        'Validaciones de campos requeridos y tipos de datos
        Dim dummy As Integer
        If Registro("CodAlmacen").ToString() = String.Empty Then
            Registro("FMensaje") = "La sucursal no es válida. "
        ElseIf (Registro("FCodCliente").ToString() <> String.Empty AndAlso Not Integer.TryParse(Registro("FCodCliente").ToString(), dummy)) Then
            Registro("FMensaje") = "El código del cliente no es válido. "
        ElseIf Registro("CodAlmacen").ToString() = String.Empty Then
            Registro("FMensaje") = "El sucursal no es válida. "
        ElseIf Registro("CodAlmacen").ToString() <> ApplicationContext.ApplicationConfiguration.Almacen Then
            Registro("FMensaje") = "El almacen no corresponde a la tienda actual. "
        End If

        'Valida el detalle
        If Registro("FMensaje").ToString() = String.Empty Then

            Dim productos As String() = Registro("FCodArticulo").ToString().Split(SEPARADORVALORES)
            Dim tallas As String() = Registro("FTalla").ToString().Split(SEPARADORVALORES)
            Dim cantidades As String() = Registro("FCantidad").ToString().Split(SEPARADORVALORES)
            Dim precios As String() = Registro("FPrecioUnit").ToString().Split(SEPARADORVALORES)
            Dim descuentos As String() = Registro("FDescuento").ToString().Split(SEPARADORVALORES)
            Dim preciosFinales As String() = Registro("FPrecioFinal").ToString().Split(SEPARADORVALORES)

            If productos.Length = 0 Then
                Registro("FMensaje") = "El valor de la columna Productos no puede ser vacío. "
            ElseIf cantidades.Length = 0 Then
                Registro("FMensaje") = "El valor de la columna cantidades no puede ser vacío. "
            ElseIf precios.Length = 0 Then
                Registro("FMensaje") = "El valor de la columna precios no puede ser vacío. "
            ElseIf descuentos.Length = 0 Then
                Registro("FMensaje") = "El valor de la columna descuentos no puede ser vacío. "
            ElseIf preciosFinales.Length = 0 Then
                Registro("FMensaje") = "El valor de la columna preciosFinales no puede ser vacío. "
            ElseIf productos.Length <> tallas.Length Then
                Registro("FMensaje") = String.Format("La cantidad de productos ({0}) no concuerda con el número de tallas especificadas ({1}). ", productos.Length, tallas.Length)
            ElseIf productos.Length <> cantidades.Length Then
                Registro("FMensaje") = String.Format("La cantidad de productos ({0}) no concuerda con el número de cantidades especificadas ({1}). ", productos.Length, cantidades.Length)
            ElseIf productos.Length <> precios.Length Then
                Registro("FMensaje") = String.Format("La cantidad de productos ({0}) no concuerda con el número de cantidades especificadas ({1}). ", productos.Length, precios.Length)
            ElseIf productos.Length <> descuentos.Length Then
                Registro("FMensaje") = String.Format("La cantidad de productos ({0}) no concuerda con el número de descuentos especificados ({1}). ", productos.Length, descuentos.Length)
            ElseIf productos.Length <> preciosFinales.Length Then
                Registro("FMensaje") = String.Format("La cantidad de productos ({0}) no concuerda con el número de precios finales especificados ({1}). ", productos.Length, preciosFinales.Length)
            Else
                For contador As Integer = 0 To productos.Length - 1
                    If productos(contador).Trim.Length = 0 Then
                        Registro("FMensaje") += "El valor del campo artículo no puede ser vacío. "
                    ElseIf tallas(contador).Trim.Length = 0 Then
                        Registro("FMensaje") += "El valor del campo talla no puede ser vacío. "
                    ElseIf cantidades(contador).Trim.Length = 0 Then
                        Registro("FMensaje") += "El valor del campo cantidades no puede ser vacío. "
                    ElseIf precios(contador).Trim.Length = 0 Then
                        Registro("FMensaje") += "El valor del campo precios no puede ser vacío. "
                    ElseIf descuentos(contador).Trim.Length = 0 Then
                        Registro("FMensaje") += "El valor del campo descuentos no puede ser vacío. "
                    ElseIf preciosFinales(contador).Trim.Length = 0 Then
                        Registro("FMensaje") += "El valor del campo precios finales no puede ser vacío. "
                    Else
                        oArticulo.ClearFields()
                        oCatalogoArticulosMgr.LoadInto(productos(contador), oArticulo)

                        If Not oArticulo.Exist() Then
                            Registro("FMensaje") += String.Format("El artículo {0} no existe en el catálogo de artículos", productos(contador))
                        Else
                            oFactura.ClearFields()
                            oFacturaMgr.GetExistenciaArticulo(oArticulo.CodArticulo, ApplicationContext.ApplicationConfiguration.Almacen, tallas(contador), oFactura, "0")

                            'Validamos los datos del artículo encontrado
                            If oFactura.FacturaArticuloExistencia = 0 Then
                                Registro("FMensaje") += String.Format("El artículo {0} no cuenta con existencias. ", productos(contador))
                            ElseIf oFactura.FacturaArticuloExistencia < Convert.ToDecimal(cantidades(contador)) Then
                                Registro("FMensaje") += String.Format("El artículo {0} no cuenta con existencias para la cantidad solicitada. ", productos(contador))
                            End If
                        End If
                    End If
                Next
            End If
        End If

        If Registro("FDiferenciaPago").ToString <> String.Empty Then
            'Validamos las formas de pago
            Dim formasPago() As String = Registro("FCodFormaPago").ToString().Split(SEPARADORVALORES)
            Dim montosFormasPago() As String = Registro("FImporte").ToString().Split(SEPARADORVALORES)
            Dim dtFormasPago As DataTable = oCatFormaPago.GetAll(Registro("FTipoVenta").ToString()).Tables(0)
            Dim dummy2 As Decimal
            If formasPago.Length = 0 Then
                Registro("FMensaje") = "El valor de la columna Formas de pago no puede ser vacío. "
            ElseIf montosFormasPago.Length = 0 Then
                Registro("FMensaje") = "El valor de la columna Montos de pago no puede ser vacío. "
            ElseIf formasPago.Length <> montosFormasPago.Length Then
                Registro("FMensaje") = String.Format("La cantidad de formas de pago ({0}) no concuerda con el número de montos de forma de pago especificados ({1}). ", formasPago.Length, montosFormasPago.Length)
            Else
                For contador As Integer = 0 To formasPago.Length - 1
                    If formasPago(contador).Trim.Length = 0 Then
                        Registro("FMensaje") += "El valor del campo forma de pago no puede ser vacío. "
                    ElseIf montosFormasPago(contador).Trim.Length = 0 Then
                        Registro("FMensaje") += "El valor del campo monto de pago no puede ser vacío. "
                    ElseIf dtFormasPago.Select("codFormasPago = '" & formasPago(contador).Trim & "'").Length = 0 Then
                        Registro("FMensaje") += String.Format("La forma de pago {0} no no se encuentra en el catálogo. ", formasPago(contador))
                    ElseIf formasPago(contador) = "DPVL" AndAlso Registro("FDPValeID") = String.Empty Then
                        Registro("FMensaje") += "El ValeId de la factura no puede ser vacío. "
                    ElseIf Not Decimal.TryParse(montosFormasPago(contador), dummy2) Then
                        Registro("FMensaje") += "El monto de la forma de pago no es válido. "
                    End If
                Next
            End If
        End If
    End Sub

    ''' <summary>
    ''' Transforma el valor de una columna en un valor removiendo el formato
    ''' elimina " , $
    ''' </summary>
    ''' <param name="Valor">Valor a procesar</param>
    ''' <returns>Lista de valores procesados</returns>
    ''' <remarks></remarks>
    Private Function ObtenerDato(ByVal Valor As String) As String
        Dim nuevoValor As String = String.Empty
        Valor = Valor.Replace("$", "").Replace("""", "")
        nuevoValor = Valor
        Return nuevoValor
    End Function

    Public Function SapZsdProcesoCompensacion(ByRef dtDocumentos As DataTable, ByRef dtPagos As DataTable, ByRef strError As String) As DataSet
        Dim oNotasCreditoDG As New NotasCreditoMasivoDataGateway(Me)

        Return oNotasCreditoDG.SapZsdProcesoCompensacion(dtDocumentos, dtPagos, strError)

        oNotasCreditoDG = Nothing
    End Function

    Public Sub SapZsdProcesoRevale(ByRef datos As Dictionary(Of String, Object), ByRef strError As String)
        Dim oNotasCreditoDG As New NotasCreditoMasivoDataGateway(Me)

        oNotasCreditoDG.SapZsdProcesoRevale(datos, strError)

        oNotasCreditoDG = Nothing
    End Sub

End Class
