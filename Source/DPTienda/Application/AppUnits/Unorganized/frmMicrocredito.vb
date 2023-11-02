Imports System.Collections.Generic
Imports DportenisPro.DPTienda.ApplicationUnits.Facturas
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoVendedores
Imports DportenisPro.DPTienda.ApplicationUnits.DPValeFinanciero

Public Class frmMicrocredito

#Region "Variables de instancia"

    Private dtPlazos As DataTable, dtBancos As DataTable
    Private oSAPMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
    Private oDPVMgr As New DPValeFinancieroManager(oAppContext, oConfigCierreFI)
    Private deslizada As Boolean = False
    Private Disposicion As DisposicionEfeClubDP
    Private VoucherInfo As Hashtable

    '-----------------------------------------------------------------------------------------
    'FLIZARRAGA 14/09/2017: Se agrega la lista de errores de la pinpad
    '-----------------------------------------------------------------------------------------
    Private ListaErroresBanamex As New List(Of String)() From {"02", "06", "08", "10", "11", "16", "17", "40", "79"}

#End Region

#Region "Constructores"

    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        dtBancos = oDPVMgr.GetBancos()
        FillPlazos()
        txtNumeroTarjeta.Focus()
    End Sub

#End Region

#Region "Metodos y funciones"

    Private Sub Nuevo()
        EnableControls(True)
        Me.txtNumeroTarjeta.Text = ""
        Me.txtTarjetaHabiente.Text = ""
        Me.cmbPlazo.SelectedValue = Nothing
        Me.txtNoIfe.Text = ""
        Me.ebPlayer.Text = ""
        Me.ebNombrePlayer.Text = ""
        Me.lblAviso.Text = ""
        Me.txtMonto.Value = 0
        Me.lblAviso.Visible = False
        Me.txtNumeroTarjeta.Focus()
        Me.ToolbarDisposicionEfectivo.CommandBars("Toolbar").Commands("MnuGenerarPrestamo").Enabled = Janus.Windows.UI.InheritableBoolean.True
        Me.ToolbarDisposicionEfectivo.CommandBars("Toolbar").Commands("MnuImpresion").Enabled = Janus.Windows.UI.InheritableBoolean.False
    End Sub

    Private Sub FillPlazos()
        dtPlazos = oDPVMgr.GetPlazos(oAppContext.ApplicationConfiguration.Almacen, oSAPMgr.MSS_GET_SY_DATE_TIME())
        cmbPlazo.DisplayMember = "PlazoMicroCreditoDesc"
        cmbPlazo.ValueMember = "PlanCode"
        cmbPlazo.DataSource = dtPlazos
        If dtPlazos.Rows.Count > 0 Then
            cmbPlazo.SelectedValue = dtPlazos.Rows(0)("PlanCode")
        End If
    End Sub

    Private Function LeerDatosPinPad(ByRef texto As String) As Boolean
        Dim valido As Boolean = False
        '------------------------------------------------------------------------------------------------------------------------
        'FLIZARRAGA 17/10/2017: Leemos datos de DPCard Puntos con la Pinpad
        '------------------------------------------------------------------------------------------------------------------------
        '--------------------------------------------------------------------------------------------------------------------------
        'FLIZARRAGA 17/10/2017: Se valida si son pagos banamex para lecturarlos por su pinpad si no la de Bancomer
        '--------------------------------------------------------------------------------------------------------------------------
        If oConfigCierreFI.PagosBanamex = True Then
            Dim pinpad As New Pinpad.Pinpad()
            Dim bin As String = ""
            Dim code As String = pinpad.LeerTarjeta(CDec(1).ToString("##,##0.00").Replace(",", ""), "0.00", "0", "00")
            If ListaErroresBanamex.Contains(code.Trim()) = False Then
                Dim Name As String = pinpad.getName(code)
                bin = pinpad.getCardNumber(code)
                texto = bin
                '----------------------------------------------------------------------------------------------------------------
                'FLIZARRAGA 17/10/2017: Enviamos mensaje de transacción exitosa a la pinpad
                '----------------------------------------------------------------------------------------------------------------
                pinpad.Respuesta("0", "", "")
                pinpad.ClosePort()
                pinpad.sp.Dispose()
                '------------------------------------------------------------------------------------
                'FLIZARRAGA 17/10/2017: Validacion de Luhn para corroborar si la tarjeta es correcta
                '------------------------------------------------------------------------------------
                If ValidacionLuhn(texto) Then
                    valido = True
                    deslizada = True
                    txtTarjetaHabiente.Text = Name
                End If
            Else
                MessageBox.Show("Hubo un error al lecturar la tarjeta", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                '----------------------------------------------------------------------------------------------------------------
                'FLIZARRAGA 17/10/2017: Enviamos mensaje de transacción exitosa a la pinpad
                '----------------------------------------------------------------------------------------------------------------
                If code.Trim() = "10" Or code.Trim() = "40" Then
                    pinpad.Respuesta("0", "", "")
                End If
                pinpad.ClosePort()
                pinpad.sp.Dispose()
            End If
        Else
            Dim oOtrosPagos As New OtrosPagos
            valido = oOtrosPagos.LeerDatosDPCard(texto, txtTarjetaHabiente.Text)
            If valido Then
                '------------------------------------------------------------------------------------
                'FLIZARRAGA 17/10/2017: Validacion de Luhn para corroborar si la tarjeta es correcta
                '------------------------------------------------------------------------------------
                If ValidacionLuhn(texto) Then
                    valido = True
                    deslizada = True
                End If
            Else
                Me.DialogResult = DialogResult.Cancel
                MessageBox.Show("Hubo un error al lecturar la tarjeta DPCard Puntos", "DPPRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
        Return valido
    End Function

    Private Function ValidarCampos() As Boolean
        Dim valido As Boolean = True
        Dim mensaje As String = ""
        If txtNumeroTarjeta.Text.Trim() = "" Then
            mensaje &= "El número de tarjeta" & vbCrLf
            valido = False
        End If
        If txtTarjetaHabiente.Text.Trim() = "" Then
            mensaje &= "El tarjeta habiente" & vbCrLf
            valido = False
        End If
        If cmbPlazo.Text.Trim() = "" Then
            mensaje &= "El plazo" & vbCrLf
            valido = False
        End If
        If txtNoIfe.Text.Trim() = "" Then
            mensaje &= "La tarjeta de elector" & vbCrLf
            valido = False
        End If
        If ebPlayer.Text.Trim() = "" Then
            mensaje &= "El código de vendedor" & vbCrLf
            valido = False
        End If
        If CDec(txtMonto.Value) <= 0 Then
            mensaje &= "El monto debe ser mayor a cero"
            valido = False
        End If
        If ValidacionLuhn(txtNumeroTarjeta.Text.Trim()) = False Then
            mensaje &= "El número de tarjeta no es valido" & vbCrLf
            valido = False
        End If
        If oDPVMgr.ValidarMontoMinimo(oAppContext.ApplicationConfiguration.Almacen, CStr(cmbPlazo.SelectedValue), txtMonto.Value) <= 0 Then
            mensaje &= "El monto no cumple con los montos minimos y maximos" & vbCrLf
            valido = False
        End If
        If oDPVMgr.GetDisposicionEfeClubDPBCount(txtNoIfe.Text.Trim(), oSAPMgr.MSS_GET_SY_DATE_TIME()) > 0 Then
            mensaje &= "Ya tiene una disposion de efectivo del día de hoy, que está en proceso"
            valido = False
            Nuevo()
        End If
        
        If mensaje.Trim() <> "" Then
            MessageBox.Show(mensaje, "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
        Return valido
    End Function

    Private Sub Prestamo()
        If ValidarCampos() Then
            '----------------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 17/10/2017: Se invoca el Metodo Purchase del Webservice de Karum para realizar la venta
            '----------------------------------------------------------------------------------------------------------------------
            Dim VendedorMgr As New CatalogoVendedoresManager(oAppContext)
            Dim vendedor As Vendedor = VendedorMgr.Create()
            Dim ws As New WSBroker("WS_KARUM", True)
            Dim param As New Hashtable()
            Dim resultado As New Hashtable()
            param("NoTarjeta") = txtNumeroTarjeta.Text.Trim()
            param("Monto") = txtMonto.Value
            param("Promocion") = CStr(cmbPlazo.SelectedValue)
            param("Fecha") = oSAPMgr.MSS_GET_SY_DATE_TIME().ToString("yyyyMMddHHmmss")
            param("ConsecutivoPOS") = ""
            param("IDTransaccion") = "4120"
            param("IDPOS") = oAppContext.ApplicationConfiguration.NoCaja.PadLeft(4, "0")
            param("IDTienda") = "D3" & oConfigCierreFI.IDTienda.PadLeft(5, "0")
            If deslizada = True Then
                param("Tipo") = "00"
            Else
                param("Tipo") = "01"
            End If
            Dim rows() As DataRow = dtPlazos.Select("PlanCode='" & CStr(cmbPlazo.SelectedValue) & "'")
            Dim sku As String = CStr(rows(0)("SKU"))
            param("SKU") = sku
            '--------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 17/10/2017: Se carga el player que realizo la factura.
            '--------------------------------------------------------------------------------------------------------
            VendedorMgr.LoadInto(ebPlayer.Text.Trim(), vendedor)
            resultado = ws.PurchasePrestamo(param)
            If resultado.Count > 0 Then
                If resultado.ContainsKey("Success") Then
                    If CBool(resultado("Success")) = True Then
                        Dim autorizacion As String = CStr(resultado("Autorizacion"))
                        Dim TarjetaHabiente As String
                        Dim VoucherInfo As New Hashtable
                        VoucherInfo = resultado

                        VoucherInfo("Transaccion") = CStr(resultado("Transaccion"))
                        VoucherInfo("Autorizacion") = CStr(resultado("Autorizacion"))
                        VoucherInfo("NoTienda") = "D3" & oConfigCierreFI.IDTienda.PadLeft(5, "0")
                        VoucherInfo("NoCaja") = oAppContext.ApplicationConfiguration.NoCaja
                        VoucherInfo("Tarjeta") = Me.txtNumeroTarjeta.Text.Trim()
                        VoucherInfo("TarjetaHabiente") = Me.txtTarjetaHabiente.Text.Trim()
                        VoucherInfo("Vendedor") = vendedor.ID & " " & vendedor.Nombre
                        If deslizada = True Then
                            VoucherInfo("Linea") = "DESLIZADA"
                        Else
                            VoucherInfo("Linea") = "DIGITADA"
                        End If
                        VoucherInfo("ConsecutivoPOS") = CStr(resultado("ConsecutivoPOS"))
                        VoucherInfo("Promocion") = Me.cmbPlazo.Text.Trim()
                        VoucherInfo("IFE") = txtNoIfe.Text.Trim()
                        Dim meses As Integer, strMeses As String = Me.cmbPlazo.Text.Substring(0, 1)
                        If IsNumeric(strMeses) = True Then
                            meses = CInt(strMeses)
                        Else
                            meses = 0
                        End If
                        VoucherInfo("Meses") = CStr(meses)
                        VoucherInfo("Reimpresa") = False
                        '-------------------------------------------------------------------------------------------------------
                        'FLIZARRAGA 17/10/2017: Cual la tarjeta es tecleada manualmente toma el nombre del WebService
                        '-------------------------------------------------------------------------------------------------------
                        'If deslizada = False Then
                        '    TarjetaHabiente = CStr(resultado("TarjetaHabiente"))
                        '    txtTarjetaHabiente.Text = TarjetaHabiente
                        'End If
                        Dim disp As New DisposicionEfeClubDP(oDPVMgr)
                        disp.NoTarjeta = txtNumeroTarjeta.Text.Trim()
                        disp.IFE = txtNoIfe.Text.Trim()
                        disp.AccountNumber = CStr(resultado("AccountNumber"))
                        disp.CodPlaza = oAppSAPConfig.Plaza
                        disp.CodAlmacen = oAppContext.ApplicationConfiguration.Almacen
                        disp.TransactionSequenceNumber = CStr(resultado("ConsecutivoPOS"))
                        disp.EstatusDisp = "Iniciado"
                        disp.CodVendedor = CInt(ebPlayer.Text.Trim()).ToString()
                        disp.NombreCliente = txtTarjetaHabiente.Text.Trim()
                        disp.Monto = CDec(Me.txtMonto.Value)
                        disp.PlazoDisp = CStr(rows(0)("PlazoMicroCredito"))
                        disp.Caja = oAppContext.ApplicationConfiguration.NoCaja
                        disp.PaymentPlan = CStr(cmbPlazo.SelectedValue)
                        disp.SKU = sku
                        disp.Generado = False
                        disp.Deslizada = deslizada
                        If disp.Save() Then
                            Dim frmDispersion As New frmServicioDispersion(disp)
                            frmDispersion.VoucherInfo = VoucherInfo
                            If frmDispersion.ShowDialog() = DialogResult.OK Then
                                '----------------------------------------------------------------------------
                                'FLIZARRAGA 17/10/2017: Saldo Disponible
                                '----------------------------------------------------------------------------
                                lblAviso.Text = "Felicidades, Su crédito fue aprobado"
                                lblAviso.Visible = True
                                MessageBox.Show("El nuevo saldo disponible para el Tarjetahabiente " & txtTarjetaHabiente.Text.Trim() & " es de " & CDec(resultado("SaldoDisponible")).ToString("C"), "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Else
                                MessageBox.Show("Se cancelo la dispersion, para corregir este problema vaya a Reproceso de prestamos", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            End If
                            EnableControls(False)
                        End If
                    Else
                        lblAviso.Text = "Favor de comunicar 01 800 8903 198 de Credit Center para revisar su disponible, para disposición de efectivo " & vbCrLf & CStr(resultado("Mensaje"))
                        lblAviso.Visible = True
                        MessageBox.Show(CStr(resultado("Mensaje")), "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Else
                    lblAviso.Text = "Favor de comunicar 01 800 8903 198 de Credit Center para revisar su disponible, para disposición de efectivo"
                    lblAviso.Visible = True
                End If
            End If
        End If
    End Sub

    Private Sub LoadSearchFormPlayer()

        Dim oOpenRecordDialogView As New OpenRecordDialog
        oOpenRecordDialogView.CurrentView = New CatalogoVendedoresOpenRecordDialogView

        oOpenRecordDialogView.ShowDialog()

        If (oOpenRecordDialogView.DialogResult = DialogResult.OK) Then

            If oOpenRecordDialogView.pbNombre <> String.Empty Then

                ebPlayer.Text = oOpenRecordDialogView.pbCodigo
                ebNombrePlayer.Text = oOpenRecordDialogView.pbNombre

            Else

                ebPlayer.Text = oOpenRecordDialogView.Record.Item("CodVendedor")
                ebNombrePlayer.Text = oOpenRecordDialogView.Record.Item("Nombre")

            End If

        End If

        oOpenRecordDialogView.Dispose()

        oOpenRecordDialogView = Nothing

    End Sub

    Private Sub LoadPrestamosDisposicion()
        Dim oOpenRecordDlg As New OpenRecordDialog
        oOpenRecordDlg.CurrentView = New DisposicionPrestamosImpresionOpenRecordDialogView()

        oOpenRecordDlg.ShowDialog()
        If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then
            Disposicion = New DisposicionEfeClubDP(oDPVMgr, CInt(oOpenRecordDlg.Record.Item("TransactionId")))
            Dim VendedorMgr As New CatalogoVendedoresManager(oAppContext)
            Dim Plazo As String = ""
            Dim vendedor As Vendedor = VendedorMgr.Create()
            Dim rows() As DataRow
            VoucherInfo = New Hashtable()
            VendedorMgr.LoadInto(Disposicion.CodVendedor, vendedor)
            Me.txtNumeroTarjeta.Text = Disposicion.NoTarjeta
            Me.txtTarjetaHabiente.Text = Disposicion.NombreCliente
            Me.cmbPlazo.SelectedValue = Disposicion.PaymentPlan
            Me.txtNoIfe.Text = Disposicion.IFE
            Me.ebPlayer.Text = Disposicion.CodVendedor
            Me.ebNombrePlayer.Text = vendedor.Nombre
            Me.txtMonto.Value = Disposicion.Monto
            VoucherInfo("NoTienda") = "D3" & oConfigCierreFI.IDTienda.PadLeft(5, "0")
            VoucherInfo("NoCaja") = Disposicion.Caja
            VoucherInfo("Tarjeta") = Disposicion.NoTarjeta
            VoucherInfo("TarjetaHabiente") = Disposicion.NombreCliente
            VoucherInfo("Vendedor") = vendedor.ID & " " & vendedor.Nombre
            VoucherInfo("Monto") = Disposicion.Monto
            If Disposicion.Deslizada = True Then
                VoucherInfo("Linea") = "DESLIZADA"
            Else
                VoucherInfo("Linea") = "DIGITADA"
            End If
            VoucherInfo("ConsecutivoPOS") = Disposicion.TransactionSequenceNumber
            rows = dtPlazos.Select("PlanCode='" & Disposicion.PaymentPlan & "'")
            If rows.Length > 0 Then
                Plazo = rows(0)!PlazoMicroCreditoDesc
            End If
            VoucherInfo("Promocion") = Plazo
            Dim meses As Integer, strMeses As String = Plazo.Substring(0, 1)
            If IsNumeric(strMeses) = True Then
                meses = CInt(strMeses)
            Else
                meses = 0
            End If
            VoucherInfo("Meses") = CStr(meses)
            VoucherInfo("NoTarjeta") = Disposicion.NoServicio
            rows = Nothing
            rows = dtBancos.Select("Codigo='" & Disposicion.Banco & "'")
            If rows.Length > 0 Then
                VoucherInfo("Banco") = CStr(rows(0)!Banco)
            Else
                VoucherInfo("Banco") = ""
            End If
            VoucherInfo("IFE") = Disposicion.IFE
            VoucherInfo("Reimpresa") = True
            EnableControls(False)
            Me.ToolbarDisposicionEfectivo.CommandBars("Toolbar").Commands("MnuImpresion").Enabled = Janus.Windows.UI.InheritableBoolean.True
            Me.ToolbarDisposicionEfectivo.CommandBars("Toolbar").Commands("MnuGenerarPrestamo").Enabled = Janus.Windows.UI.InheritableBoolean.False
        End If
    End Sub

    Private Sub PrintDisposicion()
        If Not Me.Disposicion Is Nothing AndAlso Not VoucherInfo Is Nothing Then
            Dim oOtrosPagos As New OtrosPagos
            oOtrosPagos.ImprimirVoucherMicrocredito(VoucherInfo, "VTA", False, False)
            oOtrosPagos.ImprimirVoucherMicrocredito(VoucherInfo, "VTA", True, False)
            If MessageBox.Show("¿Deseas Reimprimir el ticket?", "Dportenis PRO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                oOtrosPagos.ImprimirVoucherMicrocredito(VoucherInfo, "VTA", False, False)
                oOtrosPagos.ImprimirVoucherMicrocredito(VoucherInfo, "VTA", True, False)
            End If
        End If
    End Sub

    Private Sub EnableControls(ByVal valor As Boolean)
        Me.txtNumeroTarjeta.Enabled = valor
        Me.txtTarjetaHabiente.Enabled = valor
        Me.cmbPlazo.Enabled = valor
        Me.txtNoIfe.Enabled = valor
        Me.ebPlayer.Enabled = valor
        Me.ebNombrePlayer.Enabled = valor
        Me.btnLeerTarjeta.Enabled = valor
        Me.txtMonto.Enabled = valor
        If valor Then
            Me.ToolbarDisposicionEfectivo.CommandBars("Toolbar").Commands("MnuGenerarPrestamo").Enabled = Janus.Windows.UI.InheritableBoolean.True
        Else
            Me.ToolbarDisposicionEfectivo.CommandBars("Toolbar").Commands("MnuGenerarPrestamo").Enabled = Janus.Windows.UI.InheritableBoolean.False
        End If
    End Sub

    Private Sub SolicitarNombre()
        Dim frmCliente As New frmTarjetaHabiente()
        If frmCliente.ShowDialog() = DialogResult.OK Then
            txtTarjetaHabiente.Text = frmCliente.NombreCliente
            cmbPlazo.Focus()
        End If
    End Sub

#End Region

#Region "Eventos"

    Private Sub ToolbarDisposicionEfectivo_CommandClick(ByVal sender As System.Object, ByVal e As Janus.Windows.UI.CommandBars.CommandEventArgs) Handles ToolbarDisposicionEfectivo.CommandClick
        Select Case e.Command.Key
            Case "MnuNuevo"
                Nuevo()
            Case "MnuAbrirDisposicion"
                LoadPrestamosDisposicion()
            Case "MnuImpresion"
                PrintDisposicion()
            Case "MnuGenerarPrestamo"
                Prestamo()
            Case "MnuSalir"
                Me.Dispose()
        End Select
    End Sub

    Private Sub btnLeerTarjeta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLeerTarjeta.Click
        LeerDatosPinPad(txtNumeroTarjeta.Text)
    End Sub

    Private Sub ebPlayer_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebPlayer.ButtonClick
        LoadSearchFormPlayer()
    End Sub

    Private Sub ebPlayer_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ebPlayer.KeyDown
        If e.Alt And e.KeyCode = Keys.S Then

            LoadSearchFormPlayer()
            ebPlayer.Focus()
            ebPlayer.SelectAll()
        Else
            Select Case e.KeyCode
                Case Keys.F2
                    Prestamo()
                Case Keys.F3
                    Nuevo()
            End Select
        End If
    End Sub

    Private Sub ebPlayer_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebPlayer.Validating
        If ebPlayer.Text.Trim <> "" Then
            Dim oVendedoresMgr As New CatalogoVendedoresManager(oAppContext)
            Dim oVendedor As Vendedor = oVendedoresMgr.Create()
            ebPlayer.Text = ebPlayer.Text.PadLeft(8, "0")

            oVendedor.ClearFields()
            oVendedoresMgr.LoadInto(ebPlayer.Text, oVendedor)

            If oVendedor.ID <> String.Empty Then
                ebNombrePlayer.Text = oVendedor.Nombre
            Else
                MsgBox("Código de Vendedor NO EXISTE.  ", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "  Facturación ")

                oVendedor.ClearFields()
                Me.ebNombrePlayer.Text = ""
                e.Cancel = True

            End If

        End If
    End Sub

    Private Sub txtNumeroTarjeta_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumeroTarjeta.KeyPress
        ValidarNumeros(e)
    End Sub

    Private Sub txtNumeroTarjeta_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNumeroTarjeta.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                If ValidacionLuhn(txtNumeroTarjeta.Text.Trim()) Then
                    deslizada = False
                    SolicitarNombre()
                End If
            Case Keys.F2
                Prestamo()
            Case Keys.F3
                Nuevo()
        End Select
    End Sub

    Private Sub txtNumeroTarjeta_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtNumeroTarjeta.Validating
        If txtNumeroTarjeta.Text <> "" Then
            If ValidacionLuhn(txtNumeroTarjeta.Text.Trim()) Then
                deslizada = False
                'SolicitarNombre()
            End If
        End If
    End Sub

    Private Sub frmMicrocredito_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.F2
                Prestamo()
            Case Keys.F3
                Nuevo()
        End Select
    End Sub

    Private Sub cmbPlazo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbPlazo.KeyDown
        Select Case e.KeyCode
            Case Keys.F2
                Prestamo()
            Case Keys.F3
                Nuevo()
        End Select
    End Sub

    Private Sub txtNoIfe_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNoIfe.KeyDown
        Select Case e.KeyCode
            Case Keys.F2
                Prestamo()
            Case Keys.F3
                Nuevo()
        End Select
    End Sub

    Private Sub txtMonto_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMonto.KeyDown
        Select Case e.KeyCode
            Case Keys.F2
                Prestamo()
            Case Keys.F3
                Nuevo()
        End Select
    End Sub

    Private Sub ebPlayer_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ebPlayer.KeyPress
        ValidarNumeros(e)
    End Sub

#End Region


End Class