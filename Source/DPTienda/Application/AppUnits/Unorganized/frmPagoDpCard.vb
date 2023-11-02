Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoVendedores
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoTipoVenta
Imports DportenisPro.DPTienda.ApplicationUnits.TiposVenta

Public Class frmPagoDpCard

    Dim htDatosDPC As Hashtable
    Dim ClienteDPC As String = String.Empty
    Private deslizada As Boolean = False
    Private dtMateriales As DataTable

    Private Sub btnLeerTarjeta_Click(sender As System.Object, e As System.EventArgs) Handles btnLeerTarjeta.Click
        Me.btnLeerTarjeta.Enabled = False
        AutorizarCargoTarjeta()
        Me.btnLeerTarjeta.Enabled = True
    End Sub

    Private Sub AutorizarCargoTarjeta()
        Dim Band As Boolean = True
        Dim oApp As Process
        Dim oProcesos() As Process
        Dim pagoTarj As Decimal = 0
        LeerDPCard()
    End Sub

    Private Sub LeerDPCard()
        Try

            'Leemos el numero de la tarjeta DP Card
            Dim oOtrosPagos As New OtrosPagos
            If oOtrosPagos.LeerDatosDPCard(Me.ebNumTarj.Text, Me.ClienteDPC) Then
                'Cargamos las promociones de DP Card
                deslizada = True
                FillDPCardPromociones(CInt(ebNumTarj.Text.Substring(0, 6)), CDec(Me.ebImporte.Value))
                Me.cmbPromocion.Text = ""
            End If

        Catch ex As Exception
            MessageBox.Show("No se pudo leer la Tarjeta DP Card. Surgio un error", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            EscribeLog(ex.ToString, "No se pudo leer la Tarjeta DP Card")
        End Try
    End Sub


    Private Sub FillDPCardPromociones(ByVal Bin As Integer, ByVal Importe As Decimal)
        Dim dtPromociones As DataTable
        Dim oFacturaMgr As New DportenisPro.DPTienda.ApplicationUnits.Facturas.FacturaManager(oAppContext, oConfigCierreFI)

        dtPromociones = oFacturaMgr.GetPromocionesDPCardByBIN(Bin, Importe, cmbTipoVenta.Value)

        Me.cmbPromocion.DataSource = dtPromociones
        Me.cmbPromocion.DropDownList.Columns("CodPromo").DataMember = "Promocion"
        Me.cmbPromocion.DropDownList.Columns("Descripcion").DataMember = "Descripcion"
        Me.cmbPromocion.DropDownList.Columns("Descripcion").Width = 150

        Me.cmbPromocion.DisplayMember = "Descripcion"
        Me.cmbPromocion.ValueMember = "Promocion"
        Me.cmbPromocion.DropDownList.Columns("CodPromo").Visible = False
        Me.cmbPromocion.Refresh()
        Me.cmbPromocion.Enabled = True
    End Sub


    Private Sub ebNumTarj_Validating(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles ebNumTarj.Validating
        If ebNumTarj.Text <> "" Then
            FillDPCardPromociones(CInt(ebNumTarj.Text.Substring(0, 6)), CDec(Me.ebImporte.Value))
            Me.cmbPromocion.Text = ""
            Me.cmbPromocion.Focus()
            deslizada = False
        End If
    End Sub

    Private Sub ebNumTarj_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles ebNumTarj.KeyDown
        If e.KeyCode = Keys.Enter Then
            FillDPCardPromociones(CInt(ebNumTarj.Text.Substring(0, 6)), CDec(Me.ebImporte.Value))
            Me.cmbPromocion.Text = ""
            Me.cmbPromocion.Focus()
            deslizada = False
        End If
    End Sub

    Private Sub btnGenerarPago_Click(sender As System.Object, e As System.EventArgs) Handles btnGenerarPago.Click
        If Validar() Then
            GenerarPago()
        End If
    End Sub

    Private Function Validar() As Boolean
        Dim valido As Boolean = True
        If Me.ebNumTarj.Text.Trim = "" Then
            MessageBox.Show("No se ha deslizado el DP Card. Favor de Verificar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        End If

        '-----------------------------------------------------------------------------
        'FLIZARRAGA 04/04/2015: Se Valida que no supere el monto
        '-----------------------------------------------------------------------------

        If CDec(ebImporte.Text.Trim()) <= 0 Then
            MsgBox("Monto DPCard debe ser mayor a cero. ", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "  Forma de Pago")
            Return False
        End If

        If ebCodVendedor.Text.Trim() = "" Then
            MessageBox.Show("No se ha elegido el código vendedor", "Dportenis PRO", MessageBoxButtons.OK)
            Return False
        End If

        If cmbTipoVenta.SelectedItem Is Nothing Then
            MessageBox.Show("No se eligio tipo de venta", "Dportenis PRO", MessageBoxButtons.OK)
            Return False
        End If

        If cmbTipoPago.SelectedItem Is Nothing Then
            MessageBox.Show("No se eligio Tipo Pago", "Dportenis PRO", MessageBoxButtons.OK)
            Return False
        End If
        '-----------------------------------------------------------------------------
        'JNAVA (02.03.2015): Verificamos que se haya seleccionado la promocion
        '-----------------------------------------------------------------------------
        If Me.cmbPromocion.Text = "" Then
            MessageBox.Show("No se ha seleccionado la Promoción. Favor de Verificar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        End If
        Return valido
    End Function

    Private Sub GenerarPago()
        If AutorizaCargoDPCard() Then

            Dim Pago As Decimal = 0
            Dim NumT As String = ""

            Pago = Me.ebImporte.Value
            NumT = Me.ebNumTarj.Text

            '-----------------------------------------------------------------------------
            ' FLIZARRAGA (25.02.2015): Imprimimos Vouchers de cancelacion de ventas
            '-----------------------------------------------------------------------------
            Dim oOtrosPagos As New OtrosPagos
            oOtrosPagos.ImprimirVoucherDPCard(htDatosDPC, "VTA") 'COPIA P/TIENDA
            oOtrosPagos.ImprimirVoucherDPCard(htDatosDPC, "VTA", True) 'COPIA P/CLIENTE
            Nuevo()
        End If
    End Sub

    '-----------------------------------------------------------------------------
    'JNAVA (30.01.2015): Autorizar pagos con tarjeta DPCard
    '-----------------------------------------------------------------------------
    Private Function AutorizaCargoDPCard() As Boolean

        Dim bResp As Boolean = True
        Dim MontoPago As Decimal = 0.0
        Dim resultado As New Hashtable()
        '----------------------------------------------------------------------------------------------------------------------
        'FLIZARRAGA 25/02/2015: Se invoca el Metodo Purchase del Webservice de Karum para realizar la venta
        '----------------------------------------------------------------------------------------------------------------------
        Dim ws As New WSBroker("WS_KARUM", True)
        Dim param As New Hashtable
        Dim codeTran As String
        codeTran = CStr(cmbTipoPago.Value)
        param("NoTarjeta") = ebNumTarj.Text.Trim()
        MontoPago = ebImporte.Value
        param("Monto") = ebImporte.Value
        param("Promocion") = Me.cmbPromocion.Value
        'param("Promocion") = "00"
        param("Fecha") = DateTime.Now.ToString("yyyyMMddHHmmss")
        param("ConsecutivoPOS") = oConfigCierreFI.ConsecutivoPOS
        param("IDTransaccion") = "4120"
        param("IDPOS") = oAppContext.ApplicationConfiguration.NoCaja.PadLeft(4, "0")
        'param("IDTienda")="D3" &oAppContext.ApplicationConfiguration.Almacen.PadLeft(5,"0")
        param("IDTienda") = "D3" & oConfigCierreFI.IDTienda.PadLeft(5, "0")

        '--------------------------------------------------------------------------------------------------------
        'FLIZARRAGA 19/11/2015: Se carga el player que realizo la factura.
        '--------------------------------------------------------------------------------------------------------
        Dim VendedorMgr As New CatalogoVendedoresManager(oAppContext)
        Dim vendedor As Vendedor = VendedorMgr.Create()
        VendedorMgr.LoadInto(ebCodVendedor.Text.Trim(), vendedor)

        If deslizada = True Then
            param("Tipo") = "00"
        Else
            param("Tipo") = "01"
        End If
        Dim row As DataRow = Nothing
        Select Case CStr(cmbTipoPago.Value)
            Case "4120"
                row = dtMateriales.NewRow()
                row("Codigo") = "000100020001000006"
                row("Cantidad") = 1
                row("Total") = CDec(ebImporte.Value)
                row("Descuento") = 0
                row("Adicional") = 0
                row("Importe") = CDec(ebImporte.Value)
                dtMateriales.Rows.Add(row)
            Case "7026"
                row = dtMateriales.NewRow()
                row("Codigo") = "000100020001000006"
                row("Cantidad") = 1
                row("Total") = CDec(ebImporte.Value)
                row("Descuento") = 0
                row("Adicional") = 0
                row("Importe") = CDec(ebImporte.Value)
                dtMateriales.Rows.Add(row)
Preguntar:
                Dim strRest As String = InputBox("Introduce el total de la factura", "Dportenis PRO")
                Dim resto As Decimal = CDec(strRest) - CDec(ebImporte.Value)
                If resto < 0 Then
                    MessageBox.Show("El monto de la factura no puede ser menos al pago creado por Karum." & vbCrLf & " Capture nuevamente", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    GoTo Preguntar
                End If
                row = dtMateriales.NewRow()
                row("Codigo") = "000100010002000003"
                row("Cantidad") = 1
                row("Total") = CDec(ebImporte.Value)
                row("Descuento") = 0
                row("Adicional") = 0
                row("Importe") = resto
                dtMateriales.Rows.Add(row)
        End Select


        param("Detalles") = dtMateriales
        resultado = ws.PurchaseVirtual(param)
        If resultado.Count > 0 Then
            If resultado.ContainsKey("Success") Then
                If CBool(resultado("Success")) = True Then
                    ebNumAutorizacion.Text = CStr(resultado("Autorizacion"))

                    '-------------------------------------------------------------------------------------------------------
                    'FLIZARRAGA 26/11/2015: Cual la tarjeta es tecleada manualmente toma el nombre del WebService
                    '-------------------------------------------------------------------------------------------------------
                    If deslizada = False Then
                        Me.ClienteDPC = CStr(resultado("TarjetaHabiente"))
                    End If
                    bResp = True

                    '-----------------------------------------------------------------------------
                    ' JNAVA (26.02.2015): Obtenemos datos de KARUM (para ticket y registros)
                    '-----------------------------------------------------------------------------
                    htDatosDPC = resultado
                    '''PRUEBAS
                    'htDatosDPC("Transaccion") = CStr(resultado("Transaccion"))
                    'htDatosDPC("Autorizacion") = CStr(resultado("Autorizacion"))
                    '''PRUEBAS

                    '-----------------------------------------------------------------------------
                    ' JNAVA (08.04.2015): El número de la tienda debe ser el de KARUM
                    '-----------------------------------------------------------------------------
                    htDatosDPC("NoTienda") = "D3" & oConfigCierreFI.IDTienda.PadLeft(5, "0")
                    htDatosDPC("NoCaja") = oAppContext.ApplicationConfiguration.NoCaja
                    htDatosDPC("Tarjeta") = Me.ebNumTarj.Text.Trim()
                    htDatosDPC("TarjetaHabiente") = Me.ClienteDPC
                    'htDatosDPC("Monto") = MontoPago
                    htDatosDPC("Vendedor") = vendedor.ID & " " & vendedor.Nombre
                    If deslizada = True Then
                        htDatosDPC("Linea") = "DESLIZADA"
                    Else
                        htDatosDPC("Linea") = "DIGITADA"
                    End If

                    '-----------------------------------------------------------
                    'JNAVA (12.03.2015): Consecutivo POS
                    '-----------------------------------------------------------
                    htDatosDPC("ConsecutivoPOS") = CStr(oConfigCierreFI.ConsecutivoPOS - 1).PadLeft(4, "0")

                    '-----------------------------------------------------------
                    'JNAVA (24.03.2015): Consecutivo POS
                    '-----------------------------------------------------------
                    If Me.cmbPromocion.Value <> "00" Then
                        htDatosDPC("Promocion") = Me.cmbPromocion.Text
                        '------------------------------------------------------------------------------------------------------
                        'FLIZARRAGA 20/11/2015: Valida si es que tiene meses sin intereses
                        '------------------------------------------------------------------------------------------------------
                        Dim meses As Integer, strMeses As String = cmbPromocion.Text.Substring(0, 1)
                        If IsNumeric(strMeses) = True Then
                            meses = CInt(strMeses)
                        Else
                            meses = 0
                        End If
                        htDatosDPC("Meses") = CStr(meses)
                    Else
                        htDatosDPC("Promocion") = ""
                        htDatosDPC("Meses") = "0"
                    End If
                    '-------------------------------------------------------------------------------------------------------------------
                    'RGERMAIN 08.07.2015: Determinamos si es la primera compra con esta tarjeta de karum
                    '-------------------------------------------------------------------------------------------------------------------
                    'If CInt(htDatosDPC("Transaccion")) = 1 Then bPrimeraCompraKarum = True
                    '----------------------------------------------------------------------------
                    'Saldo Disponible
                    '----------------------------------------------------------------------------
                    MessageBox.Show("El nuevo saldo disponible para el Tarjetahabiente " & Me.ClienteDPC & " es de " & CDec(resultado("SaldoDisponible")).ToString("C"), "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    EscribeLog(CStr(resultado("Mensaje")), "Error al tratar de efectuar la compra con Karum")
                    MessageBox.Show(CStr(resultado("Mensaje")), "Dportenis", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    bResp = False
                End If
            End If
        Else
            EscribeLog("No hubo respuesta por parte del Webservice", "Error al tratar de efectuar la compra con Karum")
            MessageBox.Show("No hubo respuesta de Credit Card", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            bResp = False
        End If


        Return bResp

    End Function

    Private Sub LoadSearchFormPlayer()
        Dim oVendedoresMgr As New CatalogoVendedoresManager(oAppContext)
        Dim oVendedor As Vendedor
        Dim oOpenRecordDialogView As New OpenRecordDialog
        oOpenRecordDialogView.CurrentView = New CatalogoVendedoresOpenRecordDialogView

        oOpenRecordDialogView.ShowDialog()

        If (oOpenRecordDialogView.DialogResult = DialogResult.OK) Then
            If oOpenRecordDialogView.Record.Item("CodVendedor") Is Nothing Then
                Exit Sub
            End If
            oVendedor = oVendedoresMgr.Create()
            oVendedor.ClearFields()
            oVendedoresMgr.LoadInto(oOpenRecordDialogView.Record.Item("CodVendedor"), oVendedor)
            '------------------------------------------------------------------------------------------------------------------------------------
            'RGERMAIN 18.02.2016: Ya no se necesita validar si el vendedor esta asignado a alguna oficina de venta
            '------------------------------------------------------------------------------------------------------------------------------------
            'Dim strRes As String = oSAPMgr.ZBAPI_VALIDA_VENDEDOR(oVendedor.ID)
            'Select Case strRes
            '    Case "0"
            '        MsgBox("Código de Vendedor NO EXISTE.  ", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "  Facturación ")
            '        oOpenRecordDialogView.Dispose()
            '        oOpenRecordDialogView = Nothing
            '        Exit Sub
            '    Case "2"
            '        MessageBox.Show("El Vendedor " & oVendedor.ID & " no está asignado a la oficina de venta: T" & oAppContext.ApplicationConfiguration.Almacen, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '        oOpenRecordDialogView.Dispose()
            '        oOpenRecordDialogView = Nothing
            '        Exit Sub
            '    Case "1"
            If oOpenRecordDialogView.pbNombre <> String.Empty Then
                ebCodVendedor.Text = oOpenRecordDialogView.pbCodigo
                ebPlayerDescripcion.Text = oOpenRecordDialogView.pbNombre

            Else
                ebCodVendedor.Text = oOpenRecordDialogView.Record.Item("CodVendedor")
                ebPlayerDescripcion.Text = oOpenRecordDialogView.Record.Item("Nombre")
            End If
            'End Select


        End If

        oOpenRecordDialogView.Dispose()

        oOpenRecordDialogView = Nothing

    End Sub

    Private Sub ebCodVendedor_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles ebCodVendedor.KeyDown
        If e.Alt And e.KeyCode = Keys.S Then

            LoadSearchFormPlayer()
            ebCodVendedor.Focus()
            ebCodVendedor.SelectAll()

        End If
    End Sub

    Private Sub ebCodVendedor_ButtonClick(sender As System.Object, e As System.EventArgs) Handles ebCodVendedor.ButtonClick
        LoadSearchFormPlayer()
    End Sub

    Private Sub ebCodVendedor_Validating(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles ebCodVendedor.Validating
        If oConfigCierreFI.ShowManagerPC AndAlso ebCodVendedor.Text.Trim = "" Then

            ebCodVendedor.Focus()
            Return

        End If

        If ebCodVendedor.Text.Trim <> "" Then 'AndAlso ebCodVendedor.Text.Trim <> oFactura.CodVendedor.Trim Then
            Dim oVendedoresMgr As New CatalogoVendedoresManager(oAppContext)
            Dim oVendedor As Vendedor = Nothing
            oVendedor = oVendedoresMgr.Create()
            oVendedor.ClearFields()

            oVendedoresMgr.LoadInto(ebCodVendedor.Text, oVendedor)

            If oVendedor.ID <> String.Empty Then
                '------------------------------------------------------------------------------------------------------------------------------------
                'RGERMAIN 18.02.2016: Ya no se necesita validar si el vendedor esta asignado a alguna oficina de venta
                '------------------------------------------------------------------------------------------------------------------------------------
                'Dim strRes As String = oSAPMgr.ZBAPI_VALIDA_VENDEDOR(oVendedor.ID)

                'If strRes.Trim = "0" Then
                '    GoTo NoExiste
                'ElseIf strRes.Trim = "2" Then
                '    MessageBox.Show("El Vendedor " & oVendedor.ID & " no está asignado a la oficina de venta: T" & oAppContext.ApplicationConfiguration.Almacen, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                '    oVendedor.ClearFields()
                '    Me.ebPlayerDescripcion.Text = ""
                '    e.Cancel = True
                'Else
                ebPlayerDescripcion.Text = oVendedor.Nombre
                ebCodVendedor.Text = oVendedor.ID
                '----------------------------------------------------------------------------------------------------------------------
                'Empezamos a correr el cronómetro
                '----------------------------------------------------------------------------------------------------------------------
                'If Me.ebTipoVenta.Value <> "" AndAlso oConfigCierreFI.ShowManagerPC Then EjecutarCronometro(True)
                'End If
            Else
                MsgBox("Código de Vendedor NO EXISTE.  ", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "  Facturación ")

                ebCodVendedor.Text = "" 'oFactura.CodVendedor
                oVendedor.ClearFields()
                Me.ebPlayerDescripcion.Text = ""
                e.Cancel = True

            End If

        End If
    End Sub

    Private Sub Inicializar()
        Dim TipoPago As New DataTable()
        Dim row As DataRow = Nothing
        TipoPago.Columns.Add("CodTipoPago", GetType(String))
        TipoPago.Columns.Add("NombrePago", GetType(String))
        TipoPago.AcceptChanges()
        row = TipoPago.NewRow()
        row("CodTipoPago") = "4120"
        row("NombrePago") = "Pago Completo"
        TipoPago.Rows.Add(row)
        row = TipoPago.NewRow()
        row("CodTipoPago") = "7026"
        row("NombrePago") = "Pago Parcial"
        TipoPago.Rows.Add(row)
        cmbTipoPago.DataSource = TipoPago
        cmbTipoPago.ValueMember = "CodTipoPago"
        cmbTipoPago.DisplayMember = "NombrePago"
        cmbTipoPago.Refresh()
        Dim oTipoVentaMgr As New TiposVentaManager(oAppContext)
        Dim dtTipoVenta As DataTable
        dtTipoVenta = oTipoVentaMgr.Load().Tables(0)
        cmbTipoVenta.DataSource = New DataView(dtTipoVenta, "", "CodTipoVenta", DataViewRowState.CurrentRows)
        cmbTipoVenta.DisplayMember = "Descripcion"
        cmbTipoVenta.ValueMember = "CodTipoVenta"
        cmbTipoVenta.Refresh()
        dtMateriales = New DataTable()
        dtMateriales.Columns.Add("Codigo", GetType(String))
        dtMateriales.Columns.Add("Cantidad", GetType(Decimal))
        dtMateriales.Columns.Add("Total", GetType(Decimal))
        dtMateriales.Columns.Add("Descuento", GetType(Decimal))
        dtMateriales.Columns.Add("Adicional", GetType(Decimal))
        dtMateriales.Columns.Add("Importe", GetType(Decimal))
        dtMateriales.AcceptChanges()
    End Sub

    Private Sub Nuevo()
        Me.ebCodVendedor.Text = ""
        Me.ebPlayerDescripcion.Text = ""
        Me.cmbTipoPago.Value = "4120"
        Me.cmbTipoVenta.Value = "P"
        Me.ebImporte.Value = 0
        Me.ebNumTarj.Text = ""
        Me.cmbPromocion.Text = ""
        Me.ebNumAutorizacion.Text = ""
        Me.cmbPromocion.Enabled = False
    End Sub

    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()
        Inicializar()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub btnNuevo_Click(sender As System.Object, e As System.EventArgs) Handles btnNuevo.Click
        Nuevo()
    End Sub

    Private Sub btnSalir_Click(sender As System.Object, e As System.EventArgs) Handles btnSalir.Click
        Me.Dispose()
    End Sub
End Class