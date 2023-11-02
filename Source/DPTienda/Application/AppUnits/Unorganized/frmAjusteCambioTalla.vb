Imports DportenisPro.DPTienda.ApplicationUnits.Facturas
Imports DportenisPro.DPTienda.ApplicationUnits.FacturasCorrida
Imports DportenisPro.DPTienda.ApplicationUnits.FacturasFormaPago
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoVendedores
Imports DportenisPro.DPTienda.ApplicationUnits.TiposVenta
Imports DportenisPro.DPTienda.ApplicationUnits.Clientes
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU
Imports DportenisPro.DPTienda.ApplicationUnits.NotasCreditoAU
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos
Imports DportenisPro.DPTienda.ApplicationUnits.ValeCaja
Imports DportenisPro.DpTienda.ApplicationUnits.CatalogoCajas
Imports DportenisPro.DpTienda.ApplicationUnits.CambioTallaAU
Imports System.Collections.Generic
Imports Janus.Windows.GridEX

Public Class frmAjusteCambioTalla

#Region "Variables de instancias"

    Private FacturaMgr As FacturaManager
    Private FacturaCorridaMgr As FacturaCorridaManager
    Private oFacturaCorrida As FacturaCorrida
    Private FacturaPagosMgr As FacturaFormaPago
    Private VendedorMgr As CatalogoVendedoresManager
    Private ClienteMgr As ClientesManager
    Private TipoVentaMgr As TiposVentaManager
    Private SAPMgr As ProcesoSAPManager
    Private Vendedor As Vendedor
    Private Factura As Factura
    Private oFactura As Factura
    Private Cliente As ClienteAlterno
    Private dtDetalle As DataTable
    Private dtFormasPago As DataSet
    Private dtPagos As DataTable
    Private dtTipoVenta As DataSet
    Private dtDetalleNotaCredito As DataTable
    Private dtDetalleNota As DataTable
    Private dtValeCaja As DataTable
    Private dtCambiosTalla As DataTable
    Private oNotaCredito As NotaCredito
    Private oNotasCreditoMgr As NotasCreditoManager
    Private oFacturaFormaPago As FacturaFormaPago
    Private oCambioTallaMgr As CambioTallaManager
    Private CambioDPVale As CambioTallaDPVale

#End Region

#Region "Contructores"

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
        oCambioTallaMgr = New CambioTallaManager(oAppContext)
        dtDetalle = New DataTable()
        dtFormasPago = New DataSet()
        dtTipoVenta = New DataSet()
        oFacturaCorrida = FacturaCorridaMgr.Create()
        oFacturaFormaPago = New FacturaFormaPago(oAppContext)
        'Objeto Factura
        FacturaMgr = New FacturaManager(oAppContext, oConfigCierreFI)
        oFactura = FacturaMgr.Create()
        '-----------------------------------------------------------------------------------
        'FLIZARRAGA 21/11/2017: Creacion de detalle de nota de credito
        '-----------------------------------------------------------------------------------
        dtDetalleNotaCredito = New DataTable()
        dtDetalleNotaCredito.Columns.Add("Codigo", GetType(String))
        dtDetalleNotaCredito.Columns.Add("OldCodigo", GetType(String))
        dtDetalleNotaCredito.Columns.Add("CodArtProv", GetType(String))
        dtDetalleNotaCredito.Columns.Add("Numero", GetType(String))
        dtDetalleNotaCredito.Columns.Add("Descripcion", GetType(String))
        dtDetalleNotaCredito.Columns.Add("Cantidad", GetType(Integer))
        dtDetalleNotaCredito.Columns.Add("Color", GetType(String))
        dtDetalleNotaCredito.Columns.Add("NuevaTalla", GetType(String))
        dtDetalleNotaCredito.Columns.Add("CodTipoDescuento", GetType(String))
        dtDetalleNotaCredito.Columns.Add("Descuento", GetType(Decimal))
        dtDetalleNotaCredito.Columns.Add("DescuentoSistema", GetType(Decimal))
        dtDetalleNotaCredito.Columns.Add("CantDescuentoSistema", GetType(Decimal))
        dtDetalleNotaCredito.Columns.Add("PrecioOferta", GetType(Decimal))
        dtDetalleNotaCredito.Columns.Add("CostoUnit", GetType(Decimal))
        dtDetalleNotaCredito.Columns.Add("Total", GetType(Decimal))
        dtDetalleNotaCredito.Columns.Add("DIP", GetType(Boolean))
        dtDetalleNotaCredito.Columns.Add("NumeroSerie", GetType(String))
        dtDetalleNotaCredito.Columns.Add("IMEI", GetType(String))
        dtDetalleNotaCredito.AcceptChanges()

        dtDetalleNota = New DataTable()
        dtDetalleNota.Columns.Add("FacturaID", GetType(String))
        dtDetalleNota.Columns.Add("CodCaja", GetType(String))
        dtDetalleNota.Columns.Add("FolioReferencia", GetType(String))
        dtDetalleNota.Columns.Add("ClienteID", GetType(String))
        dtDetalleNota.Columns.Add("CodArticulo", GetType(String))
        dtDetalleNota.Columns.Add("Descripcion", GetType(String))
        dtDetalleNota.Columns.Add("Numero", GetType(String))
        dtDetalleNota.Columns.Add("Cantidad", GetType(Integer))
        dtDetalleNota.Columns.Add("CostoUnit", GetType(Decimal))
        dtDetalleNota.Columns.Add("PrecioUnit", GetType(Decimal))
        dtDetalleNota.Columns.Add("Importe", GetType(Decimal))
        dtDetalleNota.AcceptChanges()
        CreateDataValeCaja()

        Me.gridCambioTalla.DataSource = dtDetalleNotaCredito

        dtTipoVenta = TipoVentaMgr.Load()
        cmbTipoVenta.DisplayMember = "Descripcion"
        cmbTipoVenta.ValueMember = "CodTipoVenta"
        cmbTipoVenta.DataSource = dtTipoVenta.Tables(0)
        cmbTipoVenta.Value = "P"

        Factura = Nothing
        Vendedor = Nothing
        Cliente = Nothing
    End Sub

    Private Sub LoadSearchFormFacturas()
        Dim oOpenRecordDlg As New OpenRecordDialog
        Dim oFacturaOpenRecordDialogView As New FacturaOpenRecordDialogView
        oFacturaOpenRecordDialogView.TipoVenta = ""
        oOpenRecordDlg.CurrentView = oFacturaOpenRecordDialogView
        oOpenRecordDlg.ShowDialog()
        If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then
            Nuevo()
            Dim FacturaId As Integer = CInt(oOpenRecordDlg.Record.Item("ID"))
            Me.dtFormasPago = FacturaPagosMgr.Load(FacturaId)
            Factura = FacturaMgr.Create()
            Factura.ClearFields()
            FacturaMgr.LoadInto(FacturaId, Factura)
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
            Me.dtDetalle = FacturaMgr.GetDetalleCorridaCambioTalla(FacturaId)
            Me.gridDetalle.DataSource = Nothing
            Me.gridDetalle.DataSource = dtDetalle
            Me.btnAdd.Enabled = True
            Me.btnRemove.Enabled = True
            Me.txtCodVendedor.ReadOnly = False
            Me.ToolbarCambioTalla.CommandBars("toolbar").Commands("tbCambioTalla").Enabled = Janus.Windows.UI.InheritableBoolean.True
        End If
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
        Me.txtDesctoTotal.Value = 0
        Me.txtSubtotal.Text = ""
        Me.txtIVA.Text = ""
        Me.txtImporteTotal.Text = ""
        Me.txtCodVendedor.ReadOnly = True
        Me.txtFecha.Value = DateTime.Now
        Me.gridDetalle.DataSource = Nothing
        Me.gridCambioTalla.DataSource = Nothing
        Me.oFactura.ClearFields()
        Me.Factura = Nothing
        Me.btnAdd.Enabled = False
        Me.btnRemove.Enabled = False
        Me.CambioDPVale = Nothing
        Inicializar()
        Me.ToolbarCambioTalla.CommandBars("toolbar").Commands("tbCambioTalla").Enabled = Janus.Windows.UI.InheritableBoolean.False
    End Sub

    Private Sub LoadSearchFormPlayer()
        Dim oOpenRecordDialogView As New OpenRecordDialog
        oOpenRecordDialogView.CurrentView = New CatalogoVendedoresOpenRecordDialogView
        oOpenRecordDialogView.ShowDialog()
        If (oOpenRecordDialogView.DialogResult = DialogResult.OK) Then
            If oOpenRecordDialogView.pbNombre <> String.Empty Then
                txtCodVendedor.Text = oOpenRecordDialogView.pbCodigo
                txtPlayerDescripcion.Text = oOpenRecordDialogView.pbNombre
            Else
                txtCodVendedor.Text = oOpenRecordDialogView.Record.Item("CodVendedor")
                txtPlayerDescripcion.Text = oOpenRecordDialogView.Record.Item("Nombre")
            End If
        End If
        oOpenRecordDialogView.Dispose()
        oOpenRecordDialogView = Nothing
    End Sub

    Private Sub AgregarCambioTalla(ByVal GridRow As GridEXRow, ByVal Nuevo As Boolean)
        If Not GridRow Is Nothing Then
            Dim CodArticulo As String = "", NuevoArticulo As String = "", Color As String = ""
            Dim talla As String = "", Importe As Decimal = 0, CostoUnit As Decimal = 0
            Dim PrecioUnitario As Decimal, DescSistema As Decimal = 0, Descuento As Decimal = 0
            Dim Total As Decimal = 0
            Dim Cantidad As Integer = 0, NuevaCantidad As Integer = 0
            Dim FormTalla As frmTallas
            Dim ArticuloMgr As New CatalogoArticuloManager(oAppContext)
            Dim Articulo As Articulo = ArticuloMgr.Create()
            Dim ArtExistencia As New Hashtable()
            Dim rows() As DataRow = Nothing
            Dim row As DataRowView = CType(GridRow.DataRow, DataRowView)
            If Nuevo Then
                CodArticulo = CStr(row("CodArticulo"))
            Else
                CodArticulo = CStr(row("Codigo"))
            End If

            talla = CStr(row("Numero"))
            Importe = CDec(row("PrecioOferta"))
            CostoUnit = CDec(row("CostoUnit"))
            Cantidad = CInt(row("Cantidad"))
            ArtExistencia = ArticuloMgr.GetExistenciaByCodigo(CodArticulo)
            If ArtExistencia.Count > 0 Then
                Color = CStr(ArtExistencia("Color"))
            End If
            If ValidarCantidadNotaCredito(CodArticulo, Cantidad, txtReferencia.Text.Trim()) Then
                FormTalla = New frmTallas(CodArticulo, Color)
                If FormTalla.ShowDialog() = DialogResult.OK Then
                    rows = dtDetalleNotaCredito.Select("OldCodigo='" & CodArticulo & "'")
                    Articulo.ClearFields()
                    ArticuloMgr.LoadInto(FormTalla.CodArticulo, Articulo)
                    If FormTalla.Cantidad <= Cantidad Then
                        NuevaCantidad = FormTalla.Cantidad
                    Else
                        NuevaCantidad = Cantidad
                    End If
                    If rows.Length > 0 Then
                        rows(0)("Codigo") = FormTalla.CodArticulo
                        rows(0)("CodArtProv") = FormTalla.CodArtProv
                        rows(0)("NuevaTalla") = FormTalla.Numero
                        rows(0)("Color") = FormTalla.Color
                        rows(0)("Total") = Importe * NuevaCantidad
                        rows(0)("Descuento") = row("Descuento")
                        rows(0)("DescuentoSistema") = row("DescuentoSistema")
                        rows(0)("CantDescuentoSistema") = CDec(row("CantDescuentoSistema")) / NuevaCantidad
                    Else
                        Dim fila As DataRow = dtDetalleNotaCredito.NewRow()
                        Total = Math.Round(CDec(row("Total")), 2)
                        PrecioUnitario = Total / Cantidad
                        fila("Codigo") = FormTalla.CodArticulo
                        fila("OldCodigo") = CodArticulo
                        fila("CodArtProv") = FormTalla.CodArtProv
                        fila("Numero") = talla
                        fila("Descripcion") = Articulo.Descripcion
                        fila("Cantidad") = NuevaCantidad
                        fila("Color") = FormTalla.Color
                        fila("NuevaTalla") = FormTalla.Numero
                        fila("CostoUnit") = CostoUnit
                        fila("PrecioOferta") = Importe
                        fila("Total") = Importe * NuevaCantidad
                        fila("Descuento") = row("Descuento")
                        fila("DescuentoSistema") = row("DescuentoSistema")
                        fila("CantDescuentoSistema") = (CDec(row("CantDescuentoSistema")) / Cantidad) * NuevaCantidad
                        fila("NumeroSerie") = CStr(row("NumeroSerie"))
                        fila("IMEI") = CStr(row("IMEI"))
                        dtDetalleNotaCredito.Rows.Add(fila)
                    End If
                    dtDetalleNotaCredito.AcceptChanges()
                    CalculaTotales()
                End If
            Else
                MessageBox.Show("No puede hacer cambio de talla del artículo debido a que ya se hicieron todas las cantidades de la factura ", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Else
            MessageBox.Show("No ha seleccionado ningun artículo", "Dportenis Pro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub RemoveRow(ByVal RowGrid As GridEXRow, ByVal dtDetalle As DataTable)
        If Not RowGrid Is Nothing Then
            If MessageBox.Show("¿Estas seguro de eliminar la talla a cambiar?", "Dportenis PRO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Dim row As DataRowView = CType(RowGrid.DataRow, DataRowView)
                dtDetalleNotaCredito.Rows.Remove(row.Row)
                dtDetalleNotaCredito.AcceptChanges()
                If dtDetalleNotaCredito.Rows.Count > 0 Then
                    CalculaTotales()
                End If
            End If
        End If
    End Sub

    Private Sub RemoveRowEx(ByVal RowGrid As GridEXRow, ByVal dtDetalle As DataTable)
        Dim row As DataRowView = CType(RowGrid.DataRow, DataRowView)
        dtDetalleNotaCredito.Rows.Remove(row.Row)
        dtDetalleNotaCredito.AcceptChanges()
        If dtDetalleNotaCredito.Rows.Count > 0 Then
            CalculaTotales()
        End If
    End Sub


    Private Sub CalculaTotales()
        Dim PrecioUnitario As Decimal = 0, DescSistema As Decimal = 0, Descuento As Decimal = 0
        Dim TotalArticulo As Decimal = 0, Cantidad As Integer = 0, DescSistemaTotal As Decimal = 0
        Dim subtotal As Decimal = 0, Iva As Decimal = 0, Total As Decimal = 0
        Dim descto As Decimal = 0
        For Each row As DataRow In Me.dtDetalleNotaCredito.Rows
            TotalArticulo = Math.Round(CDec(row("Total")), 2)
            Cantidad = Math.Round(CDec(row("Cantidad")), 2)
            DescSistema = Math.Round(row("CantDescuentoSistema"), 2)
            DescSistemaTotal = Math.Round(row("DescuentoSistema"), 2)
            TotalArticulo -= DescSistema
            PrecioUnitario = TotalArticulo / Cantidad
            Descuento = Math.Round(row("Descuento"), 2)
            Descuento = TotalArticulo * (Descuento / 100)
            DescSistemaTotal = TotalArticulo * (DescSistemaTotal / 100)
            PrecioUnitario = PrecioUnitario - (Descuento / Cantidad)
            descto += DescSistema + Descuento
            subtotal += PrecioUnitario * Cantidad
        Next
        Iva = Math.Round(subtotal * oAppContext.ApplicationConfiguration.IVA, 2)
        Total = subtotal + Iva
        descto = descto * (1 + oAppContext.ApplicationConfiguration.IVA)
        Me.txtSubtotal.Value = subtotal
        Me.txtDesctoTotal.Value = descto
        Me.txtIVA.Value = Iva
        Me.txtImporteTotal.Value = Total
    End Sub

    Private Function Validar() As Boolean
        Dim valido As Boolean = True
        If Factura Is Nothing Then
            MessageBox.Show("No ha cargado ninguna factura para hacer el cambio", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            valido = False
        ElseIf Me.txtCodVendedor.Text.Trim() = "" Then
            MessageBox.Show("Eliga el vendedor", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            valido = False
        ElseIf Me.gridCambioTalla.RowCount = 0 Then
            MessageBox.Show("No ha agregado ninguna talla a cambiar", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            valido = False
        End If
        Return valido
    End Function

    Private Sub CambioTalla()
        If Validar() Then
            Try
                Dim FolioPedido As String, MensajeError As String = "", ReValeID As String = ""
                Dim oS2Credit As New ProcesosS2Credit
                Dim Fecha As DateTime = SAPMgr.MSS_GET_SY_DATE_TIME()
                oNotaCredito = oNotasCreditoMgr.Create()
                oNotaCredito.FolioApartado = ""
                oNotaCredito.AlmacenID = oAppContext.ApplicationConfiguration.Almacen
                oNotaCredito.PlayerID = Me.txtCodVendedor.Text.Trim()
                oNotaCredito.ClienteID = IIf(cmbTipoVenta.Value = "P", "10000000".PadLeft(10, "0"), txtCliente.Text.Trim())
                oNotaCredito.TipoDevolucionID = "CAT"
                oNotaCredito.TipoVentaID = cmbTipoVenta.Value
                oNotaCredito.Importe = CDec(Me.txtImporteTotal.Value)
                oNotaCredito.IVA = CDec(Me.txtIVA.Value)
                oNotaCredito.Aplicada = "N"
                oNotaCredito.DevDinero = "N"
                oNotaCredito.Observaciones = "Cambio de talla"
                oNotaCredito.Usuario = oAppContext.Security.CurrentUser.SessionLoginName
                oNotaCredito.Fecha = Fecha
                oNotaCredito.StatusRegistro = True
                oNotaCredito.Referencia = Me.txtReferencia.Text.Trim()
                oNotaCredito.FolioSAP = Factura.FolioSAP
                If CStr(cmbTipoVenta.Value).Trim() = "P" Then
                    oNotaCredito.ClientePGID = Factura.ClientPGID
                End If
                Dim PedidoFactura As New Pedidos(Factura.PedidoID)
                FolioPedido = PedidoFactura.FolioSAP
                Dim dtNota As New DataTable()
                dtNota = CargarNotaCredito(dtDetalleNotaCredito)
                Dim dsDetalle As New DataSet()
                dsDetalle.Tables.Add(dtNota)
                oNotaCredito.Detalle = dsDetalle
                oNotaCredito.Save(oConfigCierreFI.UsarHuellas, FolioPedido, MensajeError)
                If oNotaCredito.SALESDOCUMENT.Trim() <> "" Then
                    Dim DPValeID As String = "", strResult As String = "", Consecutivo As Integer = 0
                    Dim dtCambiosTallas As New DataTable()
                    CambioDPVale = Nothing
                    If Factura.CodTipoVenta = "V" Then
                        If Factura.Referencia.Contains("DPVLT") = False Then
                            Dim oDPVale As New cDPVale
                            oDPVale.INUMVA = DPValeID
                            Dim rows() As DataRow = Me.dtFormasPago.Tables(0).Select("CodFormasPago='DPVL'")
                            If rows.Length > 0 Then
                                DPValeID = CStr(rows(0)!DPValeID)
                            End If
                        Else
                            DPValeID = Factura.Referencia.Split("-")(1)
                        End If
                        dtCambiosTallas = oCambioTallaMgr.GetCambiosTallaByValeId(DPValeID)
                        CambioDPVale = New CambioTallaDPVale(oCambioTallaMgr)
                        If dtCambiosTallas.Rows.Count > 0 Then
                            CambioDPVale.RefOrigen = CStr(dtCambiosTallas.Rows(0)!RefOrigen)
                            CambioDPVale.RefPadre = CStr(dtCambiosTallas.Rows(0)!RefGenerada)
                            Consecutivo = CInt(dtCambiosTallas.Rows(0)!Consecutivo) + 1
                            CambioDPVale.RefGenerada = "DPVLT" & CStr(Consecutivo) & "-" & DPValeID
                            CambioDPVale.Consecutivo = Consecutivo
                            CambioDPVale.ValeId = DPValeID
                        Else
                            CambioDPVale.RefOrigen = "DPVL-" & DPValeID
                            CambioDPVale.RefPadre = "DPVL-" & DPValeID
                            CambioDPVale.RefGenerada = "DPVLT1-" & DPValeID
                            CambioDPVale.ValeId = DPValeID
                            CambioDPVale.Consecutivo = 1
                        End If
                    End If
                    Dim oValeCaja As ValeCaja
                    Dim oValeCajaMgr As New ValeCajaManager(oAppContext)
                    Dim oCliente As ClienteAlterno
                    Dim oCatalogoClientesMgr As New ClientesManager(oAppContext)
                    oCliente = oCatalogoClientesMgr.CreateAlterno
                    If (oNotaCredito.TipoVentaID <> "P" And oNotaCredito.TipoVentaID <> "E") Then
                        oCatalogoClientesMgr.Load(oNotaCredito.ClienteID, oCliente, oNotaCredito.TipoVentaID)
                    End If
                    oValeCaja = oValeCajaMgr.Create
                    With oValeCaja
                        .Fecha = oNotaCredito.Fecha
                        'VALE CAJA
                        .Importe = CDec(Me.txtImporteTotal.Value)
                        .TipoDocumento = "NC"
                        If oNotaCredito.FolioSAP.Trim() = String.Empty Then
                            .FolioDocumento = oNotaCredito.SALESDOCUMENT
                        Else
                            '.FolioDocumento = Factura.FolioFISAP
                            .FolioDocumento = oNotaCredito.SALESDOCUMENT
                        End If
                        .DocumentoID = oNotaCredito.ID
                        .DocumentoImporte = oNotaCredito.Importe
                        .CodCliente = oNotaCredito.ClienteID
                        If oNotaCredito.TipoVentaID = "P" OrElse oNotaCredito.TipoVentaID = "E" Then
                            .Nombre = "PÚBLICO GENERAL"
                        Else
                            If oCliente.EsEmpresa Then
                                .Nombre = CStr(oCliente.Nombre & " " & oCliente.ApellidoPaterno).TrimEnd
                            Else
                                .Nombre = oCliente.ApellidoPaterno & " " & oCliente.ApellidoMaterno & " " & oCliente.Nombre
                            End If
                        End If
                        .DevEfectivo = False
                        .Motivo = "Modulo Cambio de Talla"
                        .StastusRegistro = False
                        .MontoUtilizado = oNotaCredito.Importe
                        .Usuario = Me.txtCodVendedor.Text.Trim()
                    End With
                    oValeCajaMgr.Save(oValeCaja)
                    dtPagos = GetFormasPagoNuevaFactura(Me.dtFormasPago.Tables(0), oValeCaja.Importe, oValeCaja.ValeCajaID)
                    Dim exitoso As Boolean = False
                    Try
                        exitoso = SaveFactura(Factura, DPValeID)
                    Catch ex As Exception
                        EscribeLog(ex.Message, "Error al guardar la factura")
                        FacturaMgr.ValidarFacturaExitosa(oFactura.Referencia)
                        MessageBox.Show(ex.Message, "Error factura", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End Try
                    If exitoso Then
                        If CreateOrder(Factura, oFactura.FacturaID, dtPagos) Then
                            ImprimirFactura(oFactura, DPValeID)
                            MessageBox.Show("El cambio de talla fue realizado exitosamente", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Nuevo()
                        Else
                            MessageBox.Show("Ocurrio un error al realizar el cambio de talla", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Nuevo()
                        End If
                    Else
                        MessageBox.Show("Ocurrio un error al realizar el cambio de talla", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Nuevo()
                    End If
                Else
                    MessageBox.Show("No se pudo generar la nota de credito" & vbCrLf & MensajeError, "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Nuevo()
                End If
            Catch ex As Exception
                EscribeLog(ex.Message & vbCrLf & ex.StackTrace & vbCrLf & ex.InnerException.Message, "Hubo un error al realizar el cambio de talla")
                MessageBox.Show(ex.Message & vbCrLf & ex.StackTrace & vbCrLf & ex.InnerException.Message, "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Nuevo()
            End Try
        End If
    End Sub

    Private Function CreateOrder(ByVal OldFactura As Factura, ByVal FacturaId As Integer, ByVal FormasPago As DataTable) As Boolean
        Dim valido As Boolean = False
        Dim oProcesarVenta As New Dictionary(Of String, Object)
        Dim FactMgr As New FacturaManager(oAppContext, oConfigCierreFI)
        Dim response As New Dictionary(Of String, Object)
        Try
            Dim oFactura As Factura = FactMgr.Create()
            FactMgr.LoadInto(FacturaId, oFactura)
            'El valor del serial no se grabo, así que se vuelve a generar
            'Dim serial As String = FactMgr.GetSerialByFacturaId(oFactura.FacturaID)
            Dim serial As String = oAppContext.ApplicationConfiguration.Almacen & oAppContext.ApplicationConfiguration.NoCaja & Guid.NewGuid().ToString()
            oFactura.SerialId = serial
            With oProcesarVenta
                .Add("I_FECHA_CREACION", Format(OldFactura.Fecha, "yyyy-MM-dd"))
                If oFactura.CodTipoVenta = "S" OrElse oFactura.CodTipoVenta = "D" Then
                    .Add("I_SOLICITANTE", oFactura.ClienteId)
                Else
                    .Add("I_SOLICITANTE", "")
                End If
                Dim CatalogoTipoVenta As New DportenisPro.DPTienda.ApplicationUnits.CatalogoTipoVenta.CatalogoTipoVentaManager(oAppContext)

                Dim MotivoPedido As String = ""
                .Add("I_REQUIERE_FACTURA", "")
                .Add("I_COSTO_ENVIO", 0)
                .Add("I_REFERENCIA", oFactura.Referencia)
                .Add("I_OFICINAVENTAS", "T" & oAppContext.ApplicationConfiguration.Almacen)
                If oFactura.CodTipoVenta = "A" Then
                    .Add("I_MOT_PEDIDO", "ZPG") 'ZAF 
                Else
                    MotivoPedido = CatalogoTipoVenta.GetMotivoPedidoByTipoVenta(oFactura.CodTipoVenta)
                    .Add("I_MOT_PEDIDO", MotivoPedido)
                End If
                .Add("I_CLASEDOC", "")
                .Add("I_CANAL", "10")
                .Add("I_CEBE", "")
                .Add("I_CENTRO", "")
                .Add("I_GPOVENDEDOR", "")
                .Add("I_ORGVENTAS", "")
                .Add("I_SECTOR", "")
                .Add("I_VERSION_ID", "")
                .Add("I_REP_VENTAS", oFactura.CodVendedor)
                If oFactura.CodTipoVenta = "E" Then
                    Dim valeEmpleado As ValeEmpleado
                    If OldFactura.PedidoID = 0 Then
                        valeEmpleado = FactMgr.GetValeEmpleado(OldFactura.FacturaID)
                    Else
                        valeEmpleado = FactMgr.GetValeEmpleadoByPedido(OldFactura.PedidoID)
                    End If
                    .Add("I_FOLIO", valeEmpleado.Serie & "|" & valeEmpleado.Folio)
                Else
                    .Add("I_FOLIO", "")
                End If
                .Add("I_HORA", "")
                .Add("I_USUARIO", "")
                .Add("I_PLAZA", "")
                .Add("I_MONTO_TOTAL", 0)
                .Add("I_SERIALID", oFactura.SerialId)
                ' ------------------------------------------------------------------
                ' Llenamos datos de las Formas de Pago 
                '------------------------------------------------------------------
                Dim oFormasPago As New List(Of Dictionary(Of String, Object))
                Dim ImporteSeguro As Decimal = 0
                For Each oRow As DataRow In FormasPago.Rows
                    '------------------------------------------------------------------
                    ' Seteamos datos del detalle
                    '------------------------------------------------------------------
                    Dim oPago As New Dictionary(Of String, Object)
                    With oPago
                        .Add("FORMA_PAGO", oRow!CodFormasPago)
                        .Add("IMPORTE", CDec(oRow!MontoPago).ToString("##,##0.00").Replace(",", ""))
                        .Add("REFERENCIA", "")
                        .Add("FOLIO", "")
                        .Add("PER_FINANC", "")
                        .Add("NUM_APROBACION", "")
                        'If oFactura.CodTipoVenta = "V" Then
                        '    Dim infoVale As Dictionary(Of String, Object) = FactMgr.GetInfoDetalleDPValeByFormaPago(CInt(oRow!FormaPagoID))
                        '    .Add("NUMVA", CStr(infoVale("DPValeID")).PadLeft(10, "0"))
                        '    .Add("NUMDE", CInt(infoVale("Numde")))
                        '    .Add("DISTRIB", CStr(infoVale("Distribuidor")).PadLeft(10, "0"))
                        '    .Add("CTEDIST", CStr(infoVale("Ctefinal")).PadLeft(10, "0"))
                        '    .Add("PARES_PZAS", CInt(infoVale("ParesPza")))
                        '    .Add("MONTO_UTILIZADO", CDec(infoVale("MontoUtilizado")).ToString("##,##0.00").Replace(",", ""))
                        '    .Add("MONTODPVALE", CDec(infoVale("MontoDPVale")).ToString("##,##0.00").Replace(",", ""))
                        '    .Add("FECCO", CDate(infoVale("Fecco")).ToString("yyyyMMdd"))
                        '    If CBool(infoVale("Revale")) Then
                        '        .Add("REVALE", "X")
                        '    Else
                        '        .Add("REVALE", "")
                        '    End If
                        '    .Add("RMONTODPVALE", CDec(infoVale("RMontoDPVale")).ToString("##,##0.00").Replace(",", ""))
                        '    .Add("ZSEG", "0")
                        '    .Add("IMPSEG", ImporteSeguro.ToString("##,##0.00").Replace(",", ""))
                        '    If infoVale.ContainsKey("Folseg") Then .Add("FOLSEG", CStr(infoVale("Folseg"))) Else .Add("FOLSEG", 0)
                        '    .Add("DIV", CStr(infoVale("Div")))
                        'End If
                        .Add("NTARJETA", "")
                        .Add("SIHAY", "")
                        .Add("PEDIDOSH", "")
                        .Add("STATUS", "")
                    End With
                    oFormasPago.Add(oPago)
                Next
                '------------------------------------------------------------------
                ' Metemos los datos al detalle del objeto para serializarlo a JSON
                '------------------------------------------------------------------
                .Add("T_FORMAS_PAGO", oFormasPago)
                oFactura.Detalle = FactMgr.GetFacturasById(oFactura.FacturaID)
                Dim oProductos As New List(Of Dictionary(Of String, Object))
                For Each oRow As DataRow In oFactura.Detalle.Tables(0).Rows
                    '------------------------------------------------------------------
                    ' Obtener el descuento del producto comprado originalmente
                    '------------------------------------------------------------------
                    Dim oldCodigo As String = FactMgr.GetOldProductByNewProduct(dtDetalleNotaCredito, CStr(oRow!CodArticulo).PadLeft(10, "0"))
                    Dim descuento As Decimal = FactMgr.GetDctoByIdAndProduct(OldFactura.FacturaID, oldCodigo)
                    '------------------------------------------------------------------
                    ' Seteamos datos del detalle
                    '------------------------------------------------------------------
                    Dim oCodigo As New Dictionary(Of String, Object)
                    With oCodigo
                        .Add("POSNR", "")
                        .Add("ORDERITEM_ID", "")
                        .Add("MATNR", CStr(oRow!CodArticulo).PadLeft(10, "0"))
                        .Add("CANTIDAD", CInt(oRow!Cantidad))
                        .Add("DESCUENTO", CDec(descuento).ToString("##,##0.00").Replace(",", ""))
                        .Add("CLASE_CONDICION", "ZDP4")
                        .Add("ID_PROMOCION", "")
                        .Add("ALMACEN", "")
                        .Add("MOT_RECHAZO", "")
                    End With
                    oProductos.Add(oCodigo)
                Next
                '------------------------------------------------------------------
                ' Metemos los datos al detalle del objeto para serializarlo a JSON
                '------------------------------------------------------------------
                .Add("T_PRODUCTOS", oProductos)
            End With
            If oFactura.CodTipoVenta.Trim() = "O" OrElse oFactura.CodTipoVenta = "I" OrElse oFactura.CodTipoVenta = "A" OrElse oFactura.CodTipoVenta = "K" Then
                Dim lstInterlocutor As New List(Of Dictionary(Of String, Object))
                Dim inter As New Dictionary(Of String, Object)
                inter("CLIENTE") = oFactura.ClienteId
                inter("TIPO_CLIENTE") = FactMgr.GetTipoCliente(oFactura.CodTipoVenta)
                'Factura.TipoCliente
                lstInterlocutor.Add(inter)
                oProcesarVenta("T_INTERLOCUTORES") = lstInterlocutor
            End If
            '------------------------------------------------------------------
            'Ejecutamos la Transaccion
            '------------------------------------------------------------------
            Dim oRetail As New ProcesosRetail("/pos/ventas_directas", "POST")
            oRetail.Parametros.Add("SerialID", oFactura.SerialId)
            response = oRetail.SapZsdProcesoventa(oProcesarVenta, False)
            FactMgr.SaveSerial(oFactura.SerialId, "S", oAppContext.Security.CurrentUser.ID, oFactura.FacturaID)
            valido = True
        Catch ex As Exception
            EscribeLog(ex.Message, "Error en el DPVale")
            valido = False
        End Try
        Return valido
    End Function

    Private Function CargarNotaCredito(ByVal dtDetalle As DataTable) As DataTable
        Dim PrecioUnitario As Decimal = 0, DescSistema As Decimal = 0, Descuento As Decimal = 0
        Dim TotalArticulo As Decimal = 0, Cantidad As Integer = 0, DescSistemaTotal As Decimal = 0
        Dim ArticuloMgr As New CatalogoArticuloManager(oAppContext)
        Dim Articulo As Articulo = ArticuloMgr.Create()
        Dim row As DataRow = Nothing
        Dim dtNotas As DataTable = dtDetalleNota.Clone()
        For Each fila As DataRow In dtDetalle.Rows
            TotalArticulo = Math.Round(CDec(fila("Total")), 2)
            Cantidad = Math.Round(CDec(fila("Cantidad")), 2)
            PrecioUnitario = TotalArticulo / Cantidad
            DescSistema = Math.Round(fila("CantDescuentoSistema"), 2)
            DescSistemaTotal = Math.Round(fila("DescuentoSistema"), 2)
            Descuento = Math.Round(fila("Descuento"), 2)
            Descuento = TotalArticulo * (Descuento / 100)
            DescSistemaTotal = TotalArticulo * (DescSistemaTotal / 100)
            PrecioUnitario = PrecioUnitario - (DescSistema / Cantidad) - (Descuento / Cantidad)
            Articulo.ClearFields()
            ArticuloMgr.LoadInto(CStr(fila("Codigo")), Articulo)
            row = dtNotas.NewRow()
            row("FacturaID") = Factura.FacturaID
            row("CodCaja") = Factura.CodCaja
            row("FolioReferencia") = Factura.FolioFactura
            row("ClienteID") = Factura.ClienteId
            row("CodArticulo") = CStr(fila("OldCodigo"))
            row("Descripcion") = Articulo.Descripcion
            row("Numero") = CStr(fila("Numero"))
            row("Cantidad") = CInt(fila("Cantidad"))
            row("CostoUnit") = CDec(fila("CostoUnit"))
            row("PrecioUnit") = PrecioUnitario * (1 + oAppContext.ApplicationConfiguration.IVA)
            row("Importe") = (PrecioUnitario * Cantidad) * (1 + oAppContext.ApplicationConfiguration.IVA)
            'row("PrecioUnit") = CDec(fila("PrecioOferta"))
            'row("Importe") = CDec(fila("Total"))
            dtNotas.Rows.Add(row)
        Next
        Return dtNotas
    End Function

    Private Function GetFormasPagoNuevaFactura(ByVal dtFormasPago As DataTable, ByVal Importe As Decimal, ByVal ValeCajaId As String) As DataTable
        Dim Pagos As DataTable = dtFormasPago.Clone()
        Dim fila As DataRow = Nothing
        fila = Pagos.NewRow()
        fila("FacturaID") = 0
        fila("DPValeID") = ValeCajaId
        fila("CodFormasPago") = "VCJA"
        fila("CodBanco") = ""
        fila("CodTipoTarjeta") = ""
        fila("NumeroTarjeta") = ""
        fila("NumeroAutorizacion") = ""
        fila("NotaCreditoId") = 0
        fila("ComisionBancaria") = 0
        fila("IngresoComision") = 0
        fila("IvaComision") = 0
        fila("MontoPago") = Importe
        fila("NoAfiliacion") = ""
        fila("Id_Num_Promo") = 0
        Pagos.Rows.Add(fila)
        Return Pagos
    End Function

    Private Function LoadFolioFactura() As String
        Dim FolioFactura As String = ""
        Dim oCajaMgr As CatalogoCajaManager
        Dim oCaja As Caja
        oCajaMgr = New CatalogoCajaManager(oAppContext)
        oCaja = oCajaMgr.Create
        oCaja = oCajaMgr.Load(oAppContext.ApplicationConfiguration.NoCaja)
        FolioFactura = oCaja.FolioFactura
        oCaja = Nothing
        oCajaMgr = Nothing
        Return FolioFactura
    End Function

    Private Function SaveFactura(ByVal OldFactura As Factura, Optional ByVal DPValeID As String = "") As Boolean
        Dim valido As Boolean = False
        oFactura.ClearFields()
        oFactura.CodAlmacen = OldFactura.CodAlmacen
        oFactura.CodCaja = oAppContext.ApplicationConfiguration.NoCaja
        oFactura.CodTipoVenta = CStr(cmbTipoVenta.Value)
        oFactura.ClienteId = OldFactura.ClienteId
        oFactura.FolioFactura = LoadFolioFactura()
        oFactura.Fecha = DateTime.Now
        oFactura.FechaApartado = OldFactura.FechaApartado
        oFactura.SubTotal = CDec(txtSubtotal.Value)
        oFactura.IVA = CDec(txtIVA.Value)
        oFactura.Total = CDec(txtImporteTotal.Value)
        oFactura.DescTotal = CDec(txtDesctoTotal.Value)
        oFactura.MotivoPedido = OldFactura.MotivoPedido
        oFactura.Nquincenas = OldFactura.Nquincenas
        oFactura.CodVendedor = txtCodVendedor.Text.Trim()
        oFactura.CodPlaza = OldFactura.CodPlaza
        oFactura.Impresa = OldFactura.Impresa
        oFactura.Usuario = oAppContext.Security.CurrentUser.SessionLoginName
        oFactura.RazonRechazo = OldFactura.RazonRechazo
        oFactura.StatusFactura = OldFactura.StatusFactura
        oFactura.RazonRechazo = OldFactura.RazonRechazo
        oFactura.RazonRechazoID = OldFactura.RazonRechazoID
        oFactura.DPesos = OldFactura.DPesos
        oFactura.Saldo = CDec(Me.txtImporteTotal.Value)
        oFactura.ClientPGID = OldFactura.ClientPGID
        oFactura.NumeroFacilito = OldFactura.NumeroFacilito
        oFactura.FolioNotaVentaManual = 0
        oFactura.SerialId = oAppContext.ApplicationConfiguration.Almacen & oAppContext.ApplicationConfiguration.NoCaja & Guid.NewGuid().ToString()
        If oFactura.CodTipoVenta = "V" Then
            oFactura.Referencia = CambioDPVale.RefGenerada
        Else
            oFactura.Referencia = oAppContext.ApplicationConfiguration.Almacen.PadLeft(3, "0") & oAppContext.ApplicationConfiguration.NoCaja.Remove(0, 1) & Format(DateTime.Now, "yyyyMMddHHmmss")
        End If
        oFactura.Detalle.Tables.Add(dtDetalleNotaCredito)
        FacturaMgr.Save(oFactura)
        If GuardarFacturaCorrida(oFactura.Fecha) Then
            If GuardarFormadePago(oFactura.Fecha) Then
                If oFactura.CodTipoVenta = "V" Then
                    If CambioDPVale.Save() Then
                        valido = True
                    End If
                Else
                    valido = True
                End If
            End If
        End If
        Return valido
    End Function

    Private Function GuardarFacturaCorrida(ByVal FechaSAP As DateTime) As Boolean
        GuardarFacturaCorrida = False
        Dim oArticuloMgr As New CatalogoArticuloManager(oAppContext)
        Dim oArticulo As Articulo = oArticuloMgr.Create()
        If oFactura.FacturaID > 0 Then
            'Grabamos Factura Corrida
            Dim nReg As Integer, nFil As Integer
            nReg = oFactura.Detalle.Tables(0).Rows.Count - 1
            For nFil = 0 To nReg
                With oFactura.Detalle.Tables(0).Rows(nFil)
                    If .Item("Codigo") <> "" And .Item("Cantidad") > 0 And .Item("CostoUnit") > 0 Then
                        oArticulo.ClearFields()
                        oArticuloMgr.LoadInto(.Item("Codigo"), oArticulo)
                        oFacturaCorrida.Clearfields()
                        'Asignamos Campos Corrida
                        oFacturaCorrida.FacturaID = oFactura.FacturaID
                        oFacturaCorrida.CodArticulo = .Item("Codigo")
                        oFacturaCorrida.Cantidad = .Item("Cantidad")
                        oFacturaCorrida.Numero = .Item("NuevaTalla")
                        oFacturaCorrida.CostoUnitario = oArticulo.CostoProm
                        oFacturaCorrida.PrecioUnitario = .Item("PrecioOferta")
                        oFacturaCorrida.PrecioOferta = oArticulo.PrecioOferta
                        oFacturaCorrida.Total = .Item("Total")
                        '--CodTipoDescuento (DMA, DPO, DPE, etc) y Descuento sera el Adicional
                        If .Item("Descuento") > 0 Then
                            'oFacturaCorrida.CodTipoDescuento = vCodTipoDescuento
                            oFacturaCorrida.CodTipoDescuento = "ZDP4"
                        Else
                            oFacturaCorrida.CodTipoDescuento = ""
                        End If
                        oFacturaCorrida.Descuento = .Item("Descuento")
                        oFacturaCorrida.DescuentoSistema = CondicionVenta_Porcentaje(oArticulo)
                        oFacturaCorrida.CantDescuentoSistema = .Item("CantDescuentoSistema")
                        oFacturaCorrida.Fecha = FechaSAP
                        Dim valido As Boolean = FacturaCorridaMgr.Save(oFacturaCorrida)
                        If valido = False Then
                            Return False
                        End If
                        'Guardamos Movimiento del Articulo
                        FillDataMovimiento(0, oArticulo)
                        Dim oRow As DataRow
                        Dim tMontoNC As Decimal = 0, tCostNC As Decimal = 0
                        Dim dsMultU As DataSet, drMultU As DataRow
                        tMontoNC = 0
                        tCostNC = 0
                        For Each oRow In dtPagos.Rows
                            'Si la Forma de Pago es Vale de Caja
                            If oRow!CodFormasPago = "VCJA" Then
                                tMontoNC = tMontoNC + oRow!MontoPago
                                dsMultU = FacturaCorridaMgr.CostNC(oRow!DPValeID)
                                For Each drMultU In dsMultU.Tables(0).Rows
                                    If Not IsDBNull(drMultU!CostNC) Then
                                        tCostNC = tCostNC + drMultU!CostNC
                                    End If
                                Next
                                dsMultU = Nothing
                            End If
                        Next
                        tMontoNC = tMontoNC / (1 + oAppContext.ApplicationConfiguration.IVA)
                        FacturaCorridaMgr.SaveMovimiento(oFactura.Total, oFacturaCorrida, tMontoNC, tCostNC)
                    End If
                End With
            Next
            Return True
        End If
    End Function

    Private Sub FillDataMovimiento(ByVal intApartado As Integer, ByVal oArticulo As Articulo)
        With oFacturaCorrida.Movimiento
            .ClearFieldsMovimiento()
            .Mov_CodTipoMov = 201
            .Mov_TipoMovimiento = "S"
            .Mov_Status = "A"
            .Mov_Apartados = intApartado
            .Mov_CodAlmacen = oFactura.CodAlmacen
            .Mov_Destino = oFactura.ClienteId
            .Mov_Folio = oFactura.FolioFactura
            .Mov_CodArticulo = oArticulo.CodArticulo
            .Mov_Descripcion = oArticulo.Descripcion
            .Mov_CodLinea = oArticulo.Codlinea
            .Mov_CodMarca = oArticulo.CodMarca
            .Mov_CodFamilia = oArticulo.CodFamilia
            .Mov_CodUnidad = oArticulo.CodUnidadVta
            .Mov_CodUso = oArticulo.CodUso
            .Mov_CodCategoria = oArticulo.CodCategoria
            .Mov_CostoUnit = oArticulo.CostoProm
            .Mov_PrecioUnit = oFacturaCorrida.PrecioUnitario
            .Mov_FolioControl = ""
            .Mov_CodCaja = oFactura.CodCaja
        End With
    End Sub

    Private Function CondicionVenta_Porcentaje(ByVal oArticulo As Articulo) As Decimal
        Dim oResult As Decimal
        Dim oCventa As New CondicionesVtaSAP
        With oCventa
            .OficinaVtas = "T" & oAppContext.ApplicationConfiguration.Almacen
            .Jerarquia = oArticulo.Jerarquia
            .CondMat = oArticulo.CodMarca
            .CondPrec = cmbTipoVenta.DropDownList.GetValue(2)
            .Material = oArticulo.CodArticulo
            .ListPrec = cmbTipoVenta.DropDownList.GetValue(3)
        End With
        FacturaMgr.GetCondicionVenta(oCventa)
        oResult = oCventa.DescPorcentaje
        oCventa = Nothing
        Return oResult
    End Function

    Private Function GuardarFormadePago(ByVal FechaSAP As DateTime) As Boolean
        GuardarFormadePago = False
        If oFactura.FacturaID > 0 Then
            'Grabamos Factura Forma de Pago
            Dim nReg As Integer, nFil As Integer
            Dim tMontoCredito As Decimal
            tMontoCredito = 0
            nReg = dtPagos.Rows.Count - 1
            For nFil = 0 To nReg
                With dtPagos.Rows(nFil)
                    oFacturaFormaPago.ClearFields()
                    .Item("MontoPago") = .Item("MontoPago")
                    'Asignamos Campos Forma de Pago
                    oFacturaFormaPago.FacturaID = oFactura.FacturaID
                    oFacturaFormaPago.DPValeID = .Item("DPValeID")
                    oFacturaFormaPago.FormaPagoID = .Item("CodFormasPago")
                    oFacturaFormaPago.BancoID = .Item("CodBanco")
                    oFacturaFormaPago.TipoTarjetaID = .Item("CodTipoTarjeta")
                    oFacturaFormaPago.NumeroTarjeta = .Item("NumeroTarjeta")
                    oFacturaFormaPago.NumeroAutorización = .Item("NumeroAutorizacion")
                    oFacturaFormaPago.NotaCreditoID = .Item("NotaCreditoID")
                    oFacturaFormaPago.ComisionBancaria = .Item("ComisionBancaria")
                    oFacturaFormaPago.IngresoComision = .Item("IngresoComision")
                    oFacturaFormaPago.IVAComision = .Item("IVAComision")
                    oFacturaFormaPago.Monto = .Item("MontoPago")
                    oFacturaFormaPago.NoAfiliacion = .Item("NoAfiliacion")
                    oFacturaFormaPago.Promocion = .Item("Id_Num_Promo")
                    oFacturaFormaPago.RecordCreatedOn = FechaSAP
                    oFacturaFormaPago.Save()
                End With
            Next
            Return True
        End If
    End Function

    Private Sub CreateDataValeCaja()

        dtValeCaja = New DataTable("ValeCaja")

        Dim dCol As DataColumn
        Dim dRow As DataRow

        dCol = New DataColumn
        dCol.DataType = System.Type.GetType("System.Int32")
        dCol.ColumnName = "ValeCajaID"
        dtValeCaja.Columns.Add(dCol)

        dCol = Nothing
        dCol = New DataColumn
        dCol.DataType = System.Type.GetType("System.Decimal")
        dCol.ColumnName = "MontoValeCaja"
        dtValeCaja.Columns.Add(dCol)

        dCol = Nothing
        dCol = New DataColumn
        dCol.DataType = System.Type.GetType("System.Decimal")
        dCol.ColumnName = "MontoUtilizado"
        dtValeCaja.Columns.Add(dCol)

        dCol = Nothing
        dCol = New DataColumn
        dCol.DataType = System.Type.GetType("System.String")
        dCol.ColumnName = "ClienteSAPID"
        dtValeCaja.Columns.Add(dCol)

        dCol = Nothing
        dCol = New DataColumn
        dCol.DataType = System.Type.GetType("System.String")
        dCol.ColumnName = "FolioFISAPDev"
        dtValeCaja.Columns.Add(dCol)

        dCol = Nothing
        dCol = New DataColumn
        dCol.DataType = System.Type.GetType("System.String")
        dCol.ColumnName = "FolioFISAPVta"
        dtValeCaja.Columns.Add(dCol)

        dCol = Nothing
        dCol = New DataColumn
        dCol.DataType = System.Type.GetType("System.String")
        dCol.ColumnName = "FolioFITraslado"
        dCol.DefaultValue = ""
        dtValeCaja.Columns.Add(dCol)

    End Sub

    Private Sub ImprimirFactura(ByVal oFactura As Factura, Optional ByVal DPValeID As String = "")
        Dim orptDataInfo As New rptFacturaInfo
        Dim pImprimir As cImprimirFactura
        Dim pdtGeneral As DataTable
        Dim pdtDetalles As DataTable
        Dim pdtNotas As DataTable
        Dim pdtPagos As DataTable
        Dim pdtGeneralPrintPreview As New DataTable
        Dim oDPVale As New cDPVale
        Dim oClienteSAP As ClientesSAP
        Dim NombreAsociado As String = "", NombreClienteAsociado As String = ""
        Dim oS2Credit As New ProcesosS2Credit
        Dim Quincena As Integer = 0
        Dim FechaPrimerPago As DateTime
        pImprimir = New cImprimirFactura
        pdtGeneral = New DataTable
        pdtDetalles = New DataTable
        pdtNotas = New DataTable
        pdtPagos = New DataTable

        If oFactura.CodTipoVenta = "V" Then
            oDPVale.INUMVA = DPValeID
            oDPVale.I_RUTA = "X"
            Dim FirmaDistrS2C As Image = Nothing
            Dim NombreDistrS2C As String = String.Empty
            oDPVale = oS2Credit.ValidaDPVale(oDPVale, FirmaDistrS2C, NombreDistrS2C)
            If Not oDPVale Is Nothing Then
                If Not oDPVale.InfoDPVALE Is Nothing AndAlso oDPVale.InfoDPVALE.Rows.Count > 0 Then
                    If oDPVale.InfoDPVALE.Rows(0)!NUMDE <> "" Then
                        Quincena = CInt(oDPVale.InfoDPVALE.Rows(0)!NUMDE)
                    End If
                End If
                oClienteSAP = GetClienteDPVale(oDPVale.InfoDPVALE.Rows(0)!CODCT)
                FechaPrimerPago = CDate(oDPVale.InfoDPVALE.Rows(0)!FECHAPRIMERPAGO)
                FechaPrimerPago = GetFechaFechaPrimerPago(FechaPrimerPago)
            End If
            NombreAsociado = NombreDistrS2C.TrimEnd
            NombreClienteAsociado = oClienteSAP.Nombre & " " & oClienteSAP.Apellidos

        End If
        With orptDataInfo
            .FacturaID = oFactura.FacturaID
            .ModuloID = "Facturacion"
            .Disponible = True
            .NombreAsociado = NombreAsociado
            .vNombreClienteAsociado = NombreClienteAsociado
            .DeudaFacilito = 0
            .FolioDPVale = DPValeID
        End With
        pdtGeneralPrintPreview = pdtGeneral
        pImprimir.ObtenerDatos(orptDataInfo, pdtGeneral, pdtDetalles, pdtPagos, pdtNotas)
        Try
            If oConfigCierreFI.MiniPrinter Then
                Dim oARReporte As DataDynamics.ActiveReports.ActiveReport
                oARReporte = New ReporteFacturacion(orptDataInfo, pdtGeneral, "FACTURA", oConfigCierreFI.ImprimirCedula, "", Quincena, _
                                                        False, 0, Nothing, FechaPrimerPago)
                oARReporte.Document.Name = "Reporte Facturacion"
                oARReporte.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
                oARReporte.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed
                'Dim oARViewer As New ReportViewerForm

                'oARReporte.Run()

                oARReporte.Document.Print(False, False)

                'pImprimir.ImprimirFacturaMiniPrinter("LPT1", Application.StartupPath & "\epson.drv", False, pdtGeneral, pdtDetalles, pdtPagos, pdtNotas, oFactura.FolioSAP, oFactura.CodTipoVenta)                

                'oARViewer.Report = oARReporte
                'oARViewer.Show()
                If MessageBox.Show("¿Desea volver a imprimir esta factura?", " Facturación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                    oARReporte.Document.Print(False, False)
                End If
            End If
        Catch ex As Exception
            EscribeLog(ex.Message, "Se produjó un error. La factura no pudo ser impresa")
            Throw New ApplicationException("Se produjó un error. La Factura no pudo ser impresa.", ex)
        End Try
    End Sub

    Private Function ValidarCantidadNotaCredito(ByVal CodArticulo As String, ByRef Cantidad As Integer, ByVal Referencia As String) As Boolean
        Dim valido As Boolean = True
        Dim CantidadNC As Integer = 0
        Dim dtDetalle As DataTable = FacturaMgr.GetDetallePermitidoNotaCredito(CodArticulo, Referencia)
        Dim objSum As Object = dtDetalle.Compute("SUM(Cantidad)", "CodArticulo='" & CodArticulo & "'")
        If IsDBNull(objSum) = False Then
            CantidadNC = CDec(objSum)
        Else
            CantidadNC = 0
        End If
        If Cantidad > CantidadNC Then
            valido = True
            Cantidad -= CantidadNC
        Else
            valido = False
        End If
        Return valido
    End Function

#Region "Fecha de primer Pago Vale"

    Private Function GetFechaFechaPrimerPago(ByVal Fecha As DateTime) As DateTime
        Dim FechaCobro As DateTime
        If Fecha.Day >= 1 And Fecha.Day <= 6 Then
            FechaCobro = New DateTime(Fecha.Year, Fecha.Month, 15)
        ElseIf Fecha.Day >= 7 AndAlso Fecha.Day <= 20 Then
            Dim dia As Integer = 0
            Select Case Fecha.Month
                Case 1
                    dia = 31
                Case 2
                    dia = 28
                Case 3
                    dia = 31
                Case 4
                    dia = 30
                Case 5
                    dia = 31
                Case 6
                    dia = 30
                Case 7
                    dia = 31
                Case 8
                    dia = 31
                Case 9
                    dia = 30
                Case 10
                    dia = 31
                Case 11
                    dia = 30
                Case 12
                    dia = 31
            End Select
            FechaCobro = New DateTime(Fecha.Year, Fecha.Month, dia)
        ElseIf Fecha.Day >= 21 AndAlso Fecha.Day <= 31 Then
            FechaCobro = New DateTime(Fecha.AddMonths(1).Year, Fecha.AddMonths(1).Month, 15)
        End If
        Return FechaCobro
    End Function

#End Region

#End Region

#Region "Eventos"

    Private Sub ToolbarCambioTalla_CommandClick(ByVal sender As System.Object, ByVal e As Janus.Windows.UI.CommandBars.CommandEventArgs) Handles ToolbarCambioTalla.CommandClick
        Select Case e.Command.Key
            Case "tbNuevo"
                Nuevo()
            Case "tbAbrir"
                LoadSearchFormFacturas()
            Case "tbCambioTalla"
                CambioTalla()
            Case "tbSalir"
                Me.Dispose()
        End Select
    End Sub

    Private Sub txtCodVendedor_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodVendedor.ButtonClick
        LoadSearchFormPlayer()
    End Sub

    Private Sub txtCodVendedor_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodVendedor.KeyDown
        If e.Alt And e.KeyCode = Keys.S Then
            LoadSearchFormPlayer()
            txtCodVendedor.Focus()
            txtCodVendedor.SelectAll()
        End If
    End Sub

    Private Sub txtCodVendedor_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCodVendedor.Validating
        If txtCodVendedor.Text.Trim <> "" Then
            Dim oVendedoresMgr As New CatalogoVendedoresManager(oAppContext)
            Dim oVendedor As Vendedor = oVendedoresMgr.Create()
            txtCodVendedor.Text = txtCodVendedor.Text.PadLeft(8, "0")

            oVendedor.ClearFields()
            oVendedoresMgr.LoadInto(txtCodVendedor.Text, oVendedor)

            If oVendedor.ID <> String.Empty Then
                txtPlayerDescripcion.Text = oVendedor.Nombre
            Else
                MsgBox("Código de Vendedor NO EXISTE.  ", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "  Facturación ")

                oVendedor.ClearFields()
                Me.txtPlayerDescripcion.Text = ""
                e.Cancel = True

            End If

        End If
    End Sub

    Private Sub txtCodVendedor_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodVendedor.KeyPress
        ValidarNumeros(e)
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        AgregarCambioTalla(Me.gridDetalle.GetRow(), True)
    End Sub

    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        RemoveRow(Me.gridCambioTalla.GetRow(), Me.dtDetalleNotaCredito)
    End Sub

    Private Sub frmAjusteCambioTalla_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.F2
                CambioTalla()
            Case Keys.F3
                Nuevo()
        End Select
    End Sub

#End Region

End Class