Imports DportenisPro.DPTienda.ApplicationUnits.Facturas
Imports DportenisPro.DPTienda.ApplicationUnits.FacturasCorrida
Imports DportenisPro.DPTienda.ApplicationUnits.FacturasFormaPago
Imports DportenisPro.DPTienda.ApplicationUnits.CancelaFacturaAU
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoVendedores
Imports DportenisPro.DPTienda.ApplicationUnits.TiposVenta
Imports DportenisPro.DPTienda.ApplicationUnits.Clientes
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU
Imports DportenisPro.DPTienda.ApplicationUnits.NotasCreditoAU
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos
Imports uPaydll
Imports System.Collections.Generic
Imports Janus.Windows.GridEX

Public Class frmDevolucionTarjetaBanamex

#Region "Variables generales"

    Private FacturaMgr As FacturaManager
    Private FacturaCorridaMgr As FacturaCorridaManager
    Private FacturaPagosMgr As FacturaFormaPago
    Private VendedorMgr As CatalogoVendedoresManager
    Private ClienteMgr As ClientesManager
    Private TipoVentaMgr As TiposVentaManager
    Private SAPMgr As ProcesoSAPManager
    Private Vendedor As Vendedor
    Private Factura As Factura
    Private Cliente As ClienteAlterno
    Private Pedido As Pedidos
    Private dtDetalle As DataTable
    Private dtFormasPago As DataSet
    Private dtTipoVenta As DataSet
    Private oNotaCredito As NotaCredito
    Private oNotasCreditoMgr As NotasCreditoManager
    Private TipoPedido As String
    Private dtDetalleNotaCredito As DataTable

#End Region

#Region "Constructores"

    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Inicializar()
    End Sub

#End Region

#Region "Metodos y funciones"

    Private Sub Inicializar()
        FacturaMgr = New FacturaManager(oAppContext, oConfigCierreFI)
        FacturaCorridaMgr = New FacturaCorridaManager(oAppContext)
        FacturaPagosMgr = New FacturaFormaPago(oAppContext)
        VendedorMgr = New CatalogoVendedoresManager(oAppContext)
        ClienteMgr = New ClientesManager(oAppContext)
        TipoVentaMgr = New TiposVentaManager(oAppContext)
        SAPMgr = New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        oNotasCreditoMgr = New NotasCreditoManager(oAppContext, oAppSAPConfig, oConfigCierreFI)
        dtDetalle = New DataTable()
        dtFormasPago = New DataSet()
        dtTipoVenta = New DataSet()
        '-----------------------------------------------------------------------------------
        'FLIZARRAGA 02/11/2017: Creacion de detalle de nota de credito
        '-----------------------------------------------------------------------------------
        dtDetalleNotaCredito = New DataTable()
        dtDetalleNotaCredito.Columns.Add("FacturaID", GetType(String))
        dtDetalleNotaCredito.Columns.Add("CodCaja", GetType(String))
        dtDetalleNotaCredito.Columns.Add("FolioReferencia", GetType(String))
        dtDetalleNotaCredito.Columns.Add("ClienteID", GetType(String))
        dtDetalleNotaCredito.Columns.Add("CodArticulo", GetType(String))
        dtDetalleNotaCredito.Columns.Add("Descripcion", GetType(String))
        dtDetalleNotaCredito.Columns.Add("Numero", GetType(String))
        dtDetalleNotaCredito.Columns.Add("Cantidad", GetType(Integer))
        dtDetalleNotaCredito.Columns.Add("CostoUnit", GetType(Decimal))
        dtDetalleNotaCredito.Columns.Add("PrecioUnit", GetType(Decimal))
        dtDetalleNotaCredito.Columns.Add("Importe", GetType(Decimal))
        dtDetalle.AcceptChanges()

        dtTipoVenta = TipoVentaMgr.Load()
        cmbTipoVenta.DisplayMember = "Descripcion"
        cmbTipoVenta.ValueMember = "CodTipoVenta"
        cmbTipoVenta.DataSource = dtTipoVenta.Tables(0)
        cmbTipoVenta.Value = "P"


        Factura = Nothing
        Pedido = Nothing
        Vendedor = Nothing
        Cliente = Nothing
        TipoPedido = ""
    End Sub

    Private Sub Nuevo()
        Me.txtFolio.Text = ""
        Me.txtReferencia.Text = ""
        Me.txtCliente.Text = ""
        Me.txtClienteDescripcion.Text = ""
        Me.txtCodVendedor.Text = ""
        Me.txtPlayerDescripcion.Text = ""
        Me.cmbTipoVenta.Value = "P"
        Me.txtStatus.Text = ""
        Me.txtSubtotal.Text = ""
        Me.txtIVA.Text = ""
        Me.txtImporteTotal.Text = ""
        Me.txtFecha.Value = DateTime.Now
        Me.gridDetalle.DataSource = Nothing
        Me.gridFormasPago.DataSource = Nothing
        Me.ToolbarDevolucionesTarjetas.CommandBars("toolbar").Commands("tbDevolucion").Enabled = Janus.Windows.UI.InheritableBoolean.False
    End Sub

    Private Sub LoadSearchFormFacturas()
        Dim oOpenRecordDlg As New OpenRecordDialog
        Dim OpenView As New DevTarjetaBanamexOpenRecordDialogView()
        OpenView.TipoPedidos = 1
        oOpenRecordDlg.CurrentView = OpenView

        oOpenRecordDlg.ShowDialog()

        If oOpenRecordDlg.DialogResult = DialogResult.OK Then
            Dim FacturaId As Integer = CInt(oOpenRecordDlg.Record.Item("FacturaId"))
            Me.dtFormasPago = FacturaPagosMgr.Load(FacturaId)
            If Me.dtFormasPago.Tables(0).Columns.Contains("Cancelado") = False Then
                Me.dtFormasPago.Tables(0).Columns.Add("Cancelado", GetType(Boolean))
                SetValueRowToDataTable("Cancelado", False, dtFormasPago.Tables(0))
            End If
            Factura = FacturaMgr.Create()
            Factura.ClearFields()
            FacturaMgr.LoadInto(FacturaId, Factura)
            If Validar(Factura.Fecha) Then
                Me.txtFolio.Text = Factura.FolioFactura
                Me.txtReferencia.Text = Factura.Referencia
                Me.txtFecha.Value = Factura.Fecha
                Me.cmbTipoVenta.Value = Factura.CodTipoVenta
                Me.txtStatus.Text = Factura.StatusFactura
                Cliente = ClienteMgr.CreateAlterno()
                Cliente.Clear()
                ClienteMgr.Load(Me.Factura.ClienteId.ToString().PadLeft(10, "0"), Cliente)
                Me.txtCliente.Text = Factura.ClienteId
                If Me.Factura.CodTipoVenta = "E" Then
                    Me.txtClienteDescripcion.Text = "EMPLEADO"
                Else
                    Me.txtClienteDescripcion.Text = Cliente.Nombre & " " & Cliente.ApellidoPaterno & " " & Cliente.ApellidoMaterno
                End If
                Vendedor = VendedorMgr.Create()
                Vendedor.ClearFields()
                VendedorMgr.LoadInto(Factura.CodVendedor, Vendedor)
                Me.txtCodVendedor.Text = Factura.CodVendedor
                Me.txtPlayerDescripcion.Text = Vendedor.Nombre
                Me.txtSubtotal.Value = Factura.SubTotal
                Me.txtIVA.Value = Factura.IVA
                Me.txtImporteTotal.Value = Factura.Total
                Me.dtDetalle = FacturaCorridaMgr.Load(Factura.FacturaID).Tables(0)
                Me.gridDetalle.DataSource = Nothing
                Me.gridDetalle.DataSource = dtDetalle
                Me.gridFormasPago.DataSource = Nothing
                Me.gridFormasPago.DataSource = dtFormasPago.Tables(0)
                Me.ToolbarDevolucionesTarjetas.CommandBars("toolbar").Commands("tbDevolucion").Enabled = Janus.Windows.UI.InheritableBoolean.True
                TipoPedido = "FACTURA"
                CargarNotaCredito(dtDetalle)
            End If
        End If
    End Sub

    Private Sub LoadSearchFormPedidos()
        Dim oOpenRecordDlg As New OpenRecordDialog
        Dim OpenView As New DevTarjetaBanamexOpenRecordDialogView()
        OpenView.TipoPedidos = 2
        oOpenRecordDlg.CurrentView = OpenView

        oOpenRecordDlg.ShowDialog()

        If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then
            Me.Pedido = New Pedidos(oOpenRecordDlg.Record.Item("Referencia"), 3)
            Me.dtFormasPago = New DataSet()
            Me.dtFormasPago.Tables.Add(Me.Pedido.FormasPago)
            If Validar(Me.Pedido.Fecha) Then
                Me.txtFolio.Text = Me.Pedido.FolioPedido
                Me.txtReferencia.Text = Me.Pedido.Referencia
                Me.txtFecha.Value = Me.Pedido.Fecha
                Me.cmbTipoVenta.Value = Me.Pedido.CodTipoVenta
                Me.txtStatus.Text = Me.Pedido.Status
                If Me.Pedido.CodTipoVenta = "E" Then
                    Me.txtCliente.Text = Me.Pedido.ClienteID
                    Me.txtClienteDescripcion.Text = "EMPLEADO"
                Else
                    If Me.Pedido.CodTipoVenta.Trim() = "P" Then
                        Me.txtCliente.Text = Me.Pedido.ClientePGID
                        ClienteMgr.Load(CStr(Me.Pedido.ClientePGID).PadLeft(10, "0"), Cliente)
                    Else
                        Me.txtCliente.Text = Me.Pedido.ClienteID
                        ClienteMgr.Load(Me.Pedido.ClienteID.PadLeft(10, "0"), Cliente)
                    End If
                    Me.txtClienteDescripcion.Text = Cliente.Nombre & " " & Cliente.ApellidoPaterno & " " & Cliente.ApellidoMaterno
                End If
                Vendedor = VendedorMgr.Create()
                Vendedor.ClearFields()
                VendedorMgr.LoadInto(Me.Pedido.CodVendedor, Vendedor)
                Me.txtCodVendedor.Text = Me.Pedido.CodVendedor
                Me.txtPlayerDescripcion.Text = Vendedor.Nombre
                Me.txtSubtotal.Value = Me.Pedido.SubTotal
                Me.txtIVA.Value = Me.Pedido.IVA
                Me.txtImporteTotal.Value = Me.Pedido.Total
                Me.dtDetalle = PedidoDetalles.GetPedidoDetallesDataTableByPedidoID(Me.Pedido.PedidoID)
                Me.gridDetalle.DataSource = Nothing
                Me.gridDetalle.DataSource = dtDetalle
                Me.gridFormasPago.DataSource = Nothing
                Me.gridFormasPago.DataSource = dtFormasPago
                Me.ToolbarDevolucionesTarjetas.CommandBars("toolbar").Commands("tbDevolucion").Enabled = Janus.Windows.UI.InheritableBoolean.True
                TipoPedido = "PEDIDO"
                CargarNotaCredito(dtDetalle)
            End If
        End If
    End Sub

    Private Sub Devolucion()
        If Not dtFormasPago Is Nothing Then
            If ValidarDevolucion() Then
                Try
                    Dim row As DataRow = Nothing
                    Dim oCancelaFacturaMgr As New CancelaFacturaManager(oAppContext, oAppSAPConfig, oConfigCierreFI)
                    Dim NumSeguimiento As String, CodFormasPago As String, ImporteEfec As Decimal = 0
                    Dim DatosDevEfectivo As New Dictionary(Of String, Object)
                    Dim devolucion As DevolucionTarjeta
                    Dim Fecha As DateTime = SAPMgr.MSS_GET_SY_DATE_TIME()
                    Dim pay As uPaydll.upaydll = Nothing
                    Dim response As String = "", mensaje As String = "", FolioPedido As String = "", MensajeError As String = ""
                    Dim dsDetalle As New DataSet()
                    dsDetalle.Tables.Add(dtDetalleNotaCredito)
                    oNotaCredito = oNotasCreditoMgr.Create()
                    oNotaCredito.FolioApartado = ""
                    oNotaCredito.AlmacenID = oAppContext.ApplicationConfiguration.Almacen
                    oNotaCredito.PlayerID = Me.txtCodVendedor.Text.Trim()
                    oNotaCredito.ClienteID = IIf(cmbTipoVenta.Value = "P", "10000000".PadLeft(10, "0"), txtCliente.Text.Trim())
                    'oNotaCredito.ClientePGID = IIf(cmbTipoVenta.Value = "P", 10000000, CInt(txtCliente.Text.Trim()))
                    oNotaCredito.ClientePGID = 0
                    oNotaCredito.TipoDevolucionID = "EST"
                    oNotaCredito.TipoVentaID = cmbTipoVenta.Value
                    oNotaCredito.Importe = CDec(Me.txtImporteTotal.Value)
                    oNotaCredito.IVA = CDec(Me.txtIVA.Value)
                    oNotaCredito.Aplicada = "N"
                    oNotaCredito.DevDinero = "N"
                    oNotaCredito.Observaciones = "Devolución de tarjeta"
                    oNotaCredito.Usuario = Me.txtCodVendedor.Text.Trim()
                    oNotaCredito.Fecha = Fecha
                    oNotaCredito.StatusRegistro = True
                    oNotaCredito.Referencia = Me.txtReferencia.Text.Trim()
                    If TipoPedido = "FACTURA" Then
                        oNotaCredito.FolioSAP = Factura.FolioSAP
                        Dim PedidoFactura As New Pedidos(Factura.PedidoID)
                        FolioPedido = PedidoFactura.FolioSAP
                    Else
                        oNotaCredito.FolioSAP = Pedido.FolioSAP
                        FolioPedido = Pedido.FolioSAP
                    End If
                    oNotaCredito.Detalle = dsDetalle
                    oNotaCredito.Save(oConfigCierreFI.UsarHuellas, FolioPedido, MensajeError)
                    If oNotaCredito.SALESDOCUMENT.Trim() <> "" Then
                        oCancelaFacturaMgr.UpdateStatusFacturaDPValeRetail(Factura.FacturaID, Me.txtCodVendedor.Text.Trim(), oAppContext.ApplicationConfiguration.Almacen, "", oNotaCredito.SALESDOCUMENT, Factura.FolioFISAP)
                        ImprimirNotacredito(oNotaCredito)
                        For Each row In dtFormasPago.Tables(0).Rows
                            devolucion = New DevolucionTarjeta(FacturaMgr)
                            CodFormasPago = CStr(row("CodFormasPago"))
                            NumSeguimiento = CStr(row("DPValeID"))
                            devolucion.NotaCreditoID = oNotaCredito.ID
                            devolucion.FormaPagoID = CInt(row("FormaPagoID"))
                            devolucion.CodAlmacen = oAppContext.ApplicationConfiguration.Almacen
                            devolucion.CodCaja = oAppContext.ApplicationConfiguration.NoCaja
                            devolucion.CodTipoVenta = CStr(cmbTipoVenta.Value)
                            devolucion.CodFormasPago = CodFormasPago
                            devolucion.CodTipoTarjeta = CStr(row("CodTipoTarjeta"))
                            devolucion.CodVendedor = txtCodVendedor.Text.Trim()
                            devolucion.CodBanco = CStr(row("CodBanco"))
                            devolucion.NumeroTarjeta = CStr(row("NumeroTarjeta"))
                            devolucion.NumeroAutorizacion = CStr(row("NumeroAutorizacion"))
                            devolucion.NoAfiliacion = CStr(row("NoAfiliacion"))
                            devolucion.MontoPago = CDec(row("MontoPago"))
                            devolucion.Fecha = Fecha
                            devolucion.Referencia = Me.txtReferencia.Text.Trim()
                            devolucion.FacturaId = CInt(row("FacturaID"))
                            If row.IsNull("PedidoId") = False Then
                                devolucion.PedidoId = CInt(row("PedidoId"))
                            Else
                                devolucion.PedidoId = 0
                            End If
                            If devolucion.CodFormasPago = "EFEC" Then
                                DatosDevEfectivo("Referencia") = devolucion.Referencia
                                If DatosDevEfectivo.ContainsKey("Importe") Then
                                    ImporteEfec = CDec(DatosDevEfectivo("Importe"))
                                End If
                                DatosDevEfectivo("Importe") = ImporteEfec + devolucion.MontoPago
                                DatosDevEfectivo("Fecha") = Fecha
                                DatosDevEfectivo("Cliente") = Me.txtClienteDescripcion.Text.Trim()
                            End If
                            devolucion.Save()
                        Next
                        If DatosDevEfectivo.Count > 0 Then
                            PrintComprobanteEfectivo(DatosDevEfectivo)
                        End If
                        MessageBox.Show("La devolución fue realizada con exito", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Nuevo()
                    Else
                        MessageBox.Show("No fue posible realizar la Nota de Crédito en SAP." & vbCrLf & MensajeError & vbCrLf & "Favor de llamar a Soporte.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If
                Catch ex As Exception
                    EscribeLog(ex.Message, "Hubo un error al realizar las devoluciones de tarjeta")
                    MessageBox.Show(ex.Message, "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End If
    End Sub

    Private Function Validar(ByVal Fecha As DateTime) As Boolean
        Dim valido As Boolean = True
        Dim view As New DataView(dtFormasPago.Tables(0))
        view.RowFilter = "CodFormasPago IN ('TACR','TADB','EFEC')"
        Dim FechaActual As DateTime = SAPMgr.MSS_GET_SY_DATE_TIME()
        Dim dtNotasCred As DataTable = FacturaMgr.GetNotasCreditoByFactura(Factura.Referencia)
        If Fecha.Date = FechaActual.Date Then
            MessageBox.Show("No se pueden hacer devoluciones del mismo día, vaya a modulo de cancelar factura", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        End If
        If view.Count <= 0 Then
            MessageBox.Show("No se pueden hacer devoluciones con formas de pago diferente a efectivo", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        End If
        If dtNotasCred.Rows.Count > 0 Then
            MessageBox.Show("No se pueden realizar la devolución ya que cuenta con notas de credito", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        End If
        view.RowFilter = "CodFormasPago IN ('DPCA','VCJA')"
        If view.Count > 0 Then
            MessageBox.Show("No se aceptan formas de pago Vale de Caja y  Club DP", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        End If
        Return valido
    End Function

    Private Function GetResponse(ByVal response As String) As Dictionary(Of String, Object)
        Dim resultado As New Dictionary(Of String, Object)
        If response.Trim() <> "" Then
            Dim responses() As String = response.Split("|")
            Dim values() As String
            For Each answer As String In responses
                values = answer.Split("=")
                If values(0).Trim() <> "" Then
                    resultado(CStr(values(0)).Trim()) = values(1)
                End If
            Next
        End If
        Return resultado
    End Function

    Private Sub CargarNotaCredito(ByVal dtDetalle As DataTable)
        Dim PrecioUnitario As Decimal = 0, DescSistema As Decimal = 0, Descuento As Decimal = 0
        Dim TotalArticulo As Decimal = 0, Cantidad As Integer = 0, DescSistemaTotal As Decimal = 0
        Dim ArticuloMgr As New CatalogoArticuloManager(oAppContext)
        Dim Articulo As Articulo = ArticuloMgr.Create()
        Dim row As DataRow = Nothing
        For Each fila As DataRow In dtDetalle.Rows
            Articulo.ClearFields()
            ArticuloMgr.LoadInto(CStr(fila("CodArticulo")), Articulo)
            row = dtDetalleNotaCredito.NewRow()
            If TipoPedido = "FACTURA" Then
                row("FacturaID") = Factura.FacturaID
                row("CodCaja") = Factura.CodCaja
                row("FolioReferencia") = Factura.FolioFactura
                row("ClienteID") = Factura.ClienteId
            Else
                row("FacturaID") = 0
                row("CodCaja") = Pedido.CodCaja
                row("FolioReferencia") = Pedido.FolioPedido
                row("ClienteID") = Pedido.ClienteID
            End If
            TotalArticulo = Math.Round(CDec(fila("Total")), 2)
            Cantidad = Math.Round(CDec(fila("Cantidad")), 2)
            PrecioUnitario = TotalArticulo / Cantidad
            DescSistema = Math.Round(fila("CantDescuentoSistema"), 2)
            DescSistemaTotal = Math.Round(fila("DescuentoSistema"), 2)
            Descuento = Math.Round(fila("Descuento"), 2)
            Descuento = TotalArticulo * (Descuento / 100)
            DescSistemaTotal = TotalArticulo * (DescSistemaTotal / 100)
            PrecioUnitario = PrecioUnitario - (DescSistema / Cantidad) - (Descuento / Cantidad)
            row("CodArticulo") = CStr(fila("CodArticulo"))
            row("Descripcion") = Articulo.Descripcion
            row("Numero") = CStr(fila("Numero"))
            row("Cantidad") = CInt(fila("Cantidad"))
            row("CostoUnit") = CDec(fila("CostoUnit"))
            row("PrecioUnit") = PrecioUnitario * (1 + oAppContext.ApplicationConfiguration.IVA)
            row("Importe") = (PrecioUnitario * Cantidad) * (1 + oAppContext.ApplicationConfiguration.IVA)
            dtDetalleNotaCredito.Rows.Add(row)
        Next
    End Sub

    Private Sub ImprimirNotacredito(ByVal oNotaCredito As NotaCredito)
        Try
            Dim oRpt As New ActRptNotaCreditoDevTarjeta(oNotaCredito, oConfigCierreFI.ImprimirCedula)
            oRpt.Document.Name = "Nota de Credito"
            oRpt.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
            oRpt.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed
            oRpt.DataSource = oNotaCredito.Detalle.Tables(0) 'oFactura.Detalle
            oRpt.Run()
            oRpt.Document.Print(False, False)
        Catch ex As Exception
            EscribeLog(ex.ToString, "Error al imprimir la nota de credito")
        End Try
    End Sub

    Private Sub CancelarPago(ByVal row As GridEXRow)
        If Not row Is Nothing Then
            Dim fila As DataRowView = CType(row.DataRow, DataRowView)
            If CStr(fila("CodFormasPago")).Trim() = "TACR" OrElse CStr(fila("CodFormasPago")).Trim() = "TADB" Then
                If CBool(fila("Cancelado")) = False Then
                    Dim NumSeg As String = CStr(fila("DPValeID")).Trim()
                    If NumSeg <> "" AndAlso NumSeg <> "0" Then
                        Dim pay As uPaydll.upaydll = Nothing
                        Dim response As String = "", mensaje As String = ""
                        Dim NumeroAutorizacion As String, MontoPago As Decimal = 0
                        NumeroAutorizacion = CStr(fila("NumeroAutorizacion"))
                        MontoPago = CDec(fila("MontoPago"))
                        pay = New uPaydll.upaydll()
                        response = pay.devolucion(oConfigCierreFI.UserBanamex, oConfigCierreFI.PasswordBanamex, NumSeg, NumeroAutorizacion, MontoPago)
                        If response.Trim() <> "" Then
                            Dim lstResponse As Dictionary(Of String, Object) = GetResponse(response)
                            '--------------------------------------------------------------------------------
                            'FLIZARRAGA 18/01/2017: Se valida si paso la tarjeta
                            '--------------------------------------------------------------------------------
                            If CInt(lstResponse("trn_internal_respcode")) = -1 Then
                                fila("Cancelado") = True
                                dtFormasPago.Tables(0).AcceptChanges()
                                MessageBox.Show("El cargo fue cancelado exitosamente", "Cancelar Tarjeta", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Else
                                mensaje = CStr(lstResponse("trn_msg_host"))
                                MessageBox.Show(mensaje, "Cancelar Tarjeta", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End If
                        End If
                    Else
                        MessageBox.Show("La forma de pago pertenece a tarjeta de credito o debito", "Cancelar Tarjeta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If
                Else
                    MessageBox.Show("El pago ya fue cancelado", "Cancelar Tarjeta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            Else
                MessageBox.Show("La forma de pago no es tarjeta de credito o debito", "Cancelar Tarjeta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
            
        Else
            MessageBox.Show("No ha seleccionado ningun pago a cancelar", "Cancelar tarjeta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Function ValidarDevolucion() As Boolean
        Dim valido As Boolean = True
        Dim mensaje As String = "", NumTarjeta As String
        For Each row As DataRow In dtFormasPago.Tables(0).Rows
            If CStr(row("CodFormasPago")).Trim() = "TACR" OrElse CStr(row("CodFormasPago")).Trim() = "TADB" Then
                If CBool(row("Cancelado")) = False Then
                    valido = False
                    NumTarjeta = CStr(row("NumeroTarjeta"))
                    mensaje &= "La tarjeta " & NumTarjeta & " no ha sido cancelada" & vbCrLf
                End If
            End If
        Next
        If mensaje.Trim() <> "" Then
            MessageBox.Show(mensaje, "Cancelar venta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
        Return valido
    End Function

    Private Sub SetValueRowToDataTable(ByVal column As String, ByVal valor As Object, ByVal dtData As DataTable)
        For Each row As DataRow In dtData.Rows
            row(column) = valor
            row.AcceptChanges()
        Next
        dtData.AcceptChanges()
    End Sub

    Private Sub PrintComprobanteEfectivo(ByVal Datos As Dictionary(Of String, Object))
        Dim oARReporte As DevTarjetaEfectivoMiniPrinter
        oARReporte = New DevTarjetaEfectivoMiniPrinter(Datos)
        oARReporte.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
        oARReporte.Run()
        Try

            'Dim RepView As New ReportViewerForm
            'RepView.Report = oARReporte
            'RepView.Show()

            'Imprimir Directo :
            oARReporte.Document.Print(False, False)
            oARReporte.Document.Print(False, False)
        Catch ex As Exception
            Throw New ApplicationException("Se produjó un error al Imprimir.", ex)
        End Try
        oARReporte = Nothing
    End Sub

#End Region

#Region "Eventos"

    Private Sub ToolbarDevolucionesTarjetas_CommandClick(ByVal sender As System.Object, ByVal e As Janus.Windows.UI.CommandBars.CommandEventArgs) Handles ToolbarDevolucionesTarjetas.CommandClick
        Select Case e.Command.Key
            Case "tbNuevo"
                Nuevo()
            Case "tbAbrirFactura"
                LoadSearchFormFacturas()
            Case "tbAbrirPedido"
                LoadSearchFormPedidos()
            Case "tbDevolucion"
                Devolucion()
            Case "tbSalir"
                Me.Dispose()
        End Select
    End Sub

    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        CancelarPago(gridFormasPago.GetRow())
    End Sub

#End Region

End Class