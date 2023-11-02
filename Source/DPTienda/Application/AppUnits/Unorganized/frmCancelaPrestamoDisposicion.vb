Imports DportenisPro.DPTienda.ApplicationUnits.DPValeFinanciero
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoVendedores
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU
Imports System.Collections.Generic

Public Class frmCancelaPrestamoDisposicion

#Region "Variables de instancia"

    Private Disposicion As DisposicionEfeClubDP
    Private oDPVFMgr As DPValeFinancieroManager
    Private dtPlazos As DataTable
    Private oSAPMgr As ProcesoSAPManager
    Private NombreCliente As String = ""
    Private deslizada As Boolean = False
    Private ListaErroresBanamex As New List(Of String)() From {"02", "06", "08", "10", "11", "16", "17", "40", "79"}

#End Region

#Region "Constructores"

    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Inicializar()
    End Sub

#End Region


#Region "Eventos"

    Private Sub ToolbarCancelarPrestamo_CommandClick(ByVal sender As System.Object, ByVal e As Janus.Windows.UI.CommandBars.CommandEventArgs) Handles ToolbarCancelarPrestamo.CommandClick
        Select Case e.Command.Key
            Case "tbNuevo"
                Nuevo()
            Case "tbAbrirPrestamo"
                LoadPrestamosDisposicion()
            Case "tbCancelarPrestamo"
                CancelarDisposicionPrestamo()
            Case "tbSalirPrestamo"
                Me.Dispose()
        End Select
    End Sub

    Private Sub txtNumeroTarjeta_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNumeroTarjeta.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                If ValidacionLuhn(txtNumeroTarjeta.Text.Trim()) Then
                    deslizada = False
                End If
            Case Keys.F1
                Nuevo()
            Case Keys.F2
                LoadPrestamosDisposicion()
            Case Keys.F3
                CancelarDisposicionPrestamo()
        End Select
    End Sub

    Private Sub txtNumeroTarjeta_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumeroTarjeta.KeyPress
        ValidarNumeros(e)
    End Sub

    Private Sub txtNumeroTarjeta_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtNumeroTarjeta.Validating
        If txtNumeroTarjeta.Text.Trim() <> "" Then
            If ValidacionLuhn(txtNumeroTarjeta.Text.Trim()) Then
                deslizada = False
            End If
        End If
    End Sub

    Private Sub frmCancelaPrestamoDisposicion_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.F1
                Nuevo()
            Case Keys.F2
                LoadPrestamosDisposicion()
            Case Keys.F3
                CancelarDisposicionPrestamo()
        End Select
    End Sub

    Private Sub btnLeerTarjeta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLeerTarjeta.Click
        LeerDatosPinPad(txtNumeroTarjeta.Text)
    End Sub

    Private Sub txtNombreCliente_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNombreCliente.KeyDown
        Select Case e.KeyCode
            Case Keys.F1
                Nuevo()
            Case Keys.F2
                LoadPrestamosDisposicion()
            Case Keys.F3
                CancelarDisposicionPrestamo()
        End Select
    End Sub

    Private Sub cmbPlazo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbPlazo.KeyDown
        Select Case e.KeyCode
            Case Keys.F1
                Nuevo()
            Case Keys.F2
                LoadPrestamosDisposicion()
            Case Keys.F3
                CancelarDisposicionPrestamo()
        End Select
    End Sub

    Private Sub txtNoIfe_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNoIfe.KeyDown
        Select Case e.KeyCode
            Case Keys.F1
                Nuevo()
            Case Keys.F2
                LoadPrestamosDisposicion()
            Case Keys.F3
                CancelarDisposicionPrestamo()
        End Select
    End Sub

    Private Sub ebPlayer_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ebPlayer.KeyDown
        Select Case e.KeyCode
            Case Keys.F1
                Nuevo()
            Case Keys.F2
                LoadPrestamosDisposicion()
            Case Keys.F3
                CancelarDisposicionPrestamo()
        End Select
    End Sub

    Private Sub txtMonto_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMonto.KeyDown
        Select Case e.KeyCode
            Case Keys.F1
                Nuevo()
            Case Keys.F2
                LoadPrestamosDisposicion()
            Case Keys.F3
                CancelarDisposicionPrestamo()
        End Select
    End Sub

    Private Sub txtEstatusDisp_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtEstatusDisp.KeyDown
        Select Case e.KeyCode
            Case Keys.F1
                Nuevo()
            Case Keys.F2
                LoadPrestamosDisposicion()
            Case Keys.F3
                CancelarDisposicionPrestamo()
        End Select
    End Sub

#End Region

#Region "Metodos y funciones"

    Private Sub Inicializar()
        oDPVFMgr = New DPValeFinancieroManager(oAppContext, oConfigCierreFI)
        oSAPMgr = New ProcesoSAPManager(oAppContext, oAppSAPConfig)

        dtPlazos = oDPVFMgr.GetPlazos(oAppContext.ApplicationConfiguration.Almacen, oSAPMgr.MSS_GET_SY_DATE_TIME())
        cmbPlazo.DisplayMember = "PlazoMicroCreditoDesc"
        cmbPlazo.ValueMember = "PlanCode"
        cmbPlazo.DataSource = dtPlazos
    End Sub

    Private Sub LoadPrestamosDisposicion()
        Dim oOpenRecordDlg As New OpenRecordDialog
        oOpenRecordDlg.CurrentView = New DisposicionPrestamosOpenRecordDialogView()

        oOpenRecordDlg.ShowDialog()
        If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then
            Dim VendedorMgr As New CatalogoVendedoresManager(oAppContext)
            Dim Vendedor As Vendedor = VendedorMgr.Create()
            Disposicion = New DisposicionEfeClubDP(oDPVFMgr, CInt(oOpenRecordDlg.Record.Item("TransactionId")))
            If ValidaEstatus() Then
                Me.txtNombreCliente.Text = Disposicion.NombreCliente
                Me.txtNoIfe.Text = Disposicion.IFE
                Me.cmbPlazo.SelectedValue = Disposicion.PaymentPlan
                Me.ebPlayer.Text = Disposicion.CodVendedor
                Vendedor.ClearFields()
                VendedorMgr.LoadInto(Disposicion.CodVendedor, Vendedor)
                Me.ebNombrePlayer.Text = Vendedor.Nombre
                Me.txtMonto.Value = Disposicion.Monto
                Me.txtEstatusDisp.Text = Disposicion.EstatusDisp
                Me.ToolbarCancelarPrestamo.CommandBars("tbCancelar").Commands("tbCancelarPrestamo").Enabled = Janus.Windows.UI.InheritableBoolean.True
                Me.btnLeerTarjeta.Enabled = True
                Me.txtNumeroTarjeta.ReadOnly = False
                Me.txtNumeroTarjeta.Focus()
            End If
        End If
    End Sub

    Private Sub Nuevo()
        Disposicion = Nothing
        Me.txtNumeroTarjeta.Text = ""
        Me.txtNombreCliente.Text = ""
        Me.cmbPlazo.SelectedValue = Nothing
        Me.txtNoIfe.Text = ""
        Me.ebPlayer.Text = ""
        Me.ebNombrePlayer.Text = ""
        Me.txtMonto.Value = 0
        Me.txtEstatusDisp.Text = ""
        Me.NombreCliente = ""
        Me.btnLeerTarjeta.Enabled = False
        Me.txtNumeroTarjeta.ReadOnly = True
        Me.deslizada = False
        Me.ToolbarCancelarPrestamo.CommandBars("tbCancelar").Commands("tbCancelarPrestamo").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.txtNumeroTarjeta.Focus()
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
                Dim Name As String = pinpad.getAppLabel()
                bin = pinpad.getCardNumber(code)
                texto = bin
                NombreCliente = Name
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
                    Me.txtNombreCliente.Text = Name
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
            valido = oOtrosPagos.LeerDatosDPCard(texto, Me.txtNombreCliente.Text)
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

    Private Function ValidaEstatus() As Boolean
        Dim valido As Boolean = True
        Dim FechaSistemas As DateTime = oSAPMgr.MSS_GET_SY_DATE_TIME()
        If Disposicion.FechaKarum.Date = FechaSistemas.Date Then
            If Disposicion.EstatusDisp.ToUpper() = "APLICADO" OrElse Disposicion.EstatusDisp.ToUpper() = "SOLICITADO" OrElse Disposicion.EstatusDisp.ToUpper() = "CERRADO" Then
                valido = False
                MessageBox.Show("Favor de enviar un correo a aclaracionesfinancierobajioysureste@dportenis.com.mx para atender tu solicitud", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Else
            If Disposicion.EstatusDisp.ToUpper() = "APLICADO" OrElse Disposicion.EstatusDisp.ToUpper() = "SOLICITADO" OrElse Disposicion.EstatusDisp.ToUpper() = "CERRADO" Then
                valido = False
                MessageBox.Show("Favor de enviar un correo a aclaracionesfinancierobajioysureste@dportenis.com.mx para atender tu solicitud", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        End If
        Return valido
    End Function

    Private Function ValidaCampos() As Boolean
        Dim valido As Boolean = True
        Dim mensaje As String = ""
        If Disposicion Is Nothing Then
            valido = False
            mensaje &= "No se abrio un prestamo a cancelar" & vbCrLf
        ElseIf txtNumeroTarjeta.Text.Trim() <> Disposicion.NoTarjeta.Trim() Then
            valido = False
            mensaje &= "No coincide el número de tarjeta con la del prestamo realizado" & vbCrLf
        End If
        If txtNumeroTarjeta.Text.Trim() = "" OrElse cmbPlazo.Text.Trim() = "" OrElse txtNoIfe.Text.Trim() = "" OrElse ebPlayer.Text.Trim() = "" OrElse txtMonto.Text.Trim() = "" OrElse txtEstatusDisp.Text.Trim() = "" Then
            valido = False
            mensaje &= "Dato vacio. Revise sus datos" & vbCrLf
        End If
        If ValidacionLuhn(txtNumeroTarjeta.Text.Trim()) = False Then
            valido = False
            mensaje &= "Número de tarjeta invalida" & vbCrLf
        End If
        If mensaje.Trim() <> "" Then
            MessageBox.Show(mensaje, "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
        Return valido
    End Function

    Private Sub CancelarDisposicionPrestamo()
        If ValidaCampos() Then
            Dim ws As New WSBroker("WS_KARUM", True)
            Dim param As New Hashtable
            Dim resultado As Hashtable
            Try
                param("NoTarjeta") = txtNumeroTarjeta.Text.Trim()
                param("Monto") = txtMonto.Value
                Dim promo As Integer = CInt(cmbPlazo.SelectedValue)
                If promo < 10 Then
                    param("Promocion") = CStr(cmbPlazo.SelectedValue).PadLeft(2, "0")
                Else
                    param("Promocion") = CStr(cmbPlazo.SelectedValue)
                End If
                param("Fecha") = oSAPMgr.MSS_GET_SY_DATE_TIME().ToString("yyyyMMddHHmmss")
                param("ConsecutivoPOS") = ""
                param("IDPOS") = oAppContext.ApplicationConfiguration.NoCaja.PadLeft(4, "0")
                param("IDTienda") = "D3" & oConfigCierreFI.IDTienda.PadLeft(5, "0")
                If deslizada = True Then
                    param("Tipo") = "00"
                Else
                    param("Tipo") = "01"
                End If
                Dim filas() As DataRow = dtPlazos.Select("PlanCode='" & CStr(cmbPlazo.SelectedValue) & "'")
                Dim sku As String = CStr(filas(0)("SKU"))
                param("SKU") = sku
                resultado = ws.PurchaseVoidPrestamo(param)
                '-----------------------------------------------------------------------
                ' FLIZARRAGA 20/10/2017:  Validamos si se realizo la cancelacion o no
                '-----------------------------------------------------------------------
                Dim mensaje As String = ""
                If resultado.Count > 0 Then
                    If resultado.ContainsKey("Success") = True Then
                        If CBool(resultado("Success")) = True Then
                            '-----------------------------------------------------------------------------
                            ' FLIZARRAGA 20/10/2017: Obtenemos datos de KARUM (para ticket y registros)
                            '-----------------------------------------------------------------------------
                            Dim htDatosDPC As Hashtable
                            htDatosDPC = resultado

                            '-----------------------------------------------------------------------------
                            ' FLIZARRAGA 20/10/2017:  El número de la tienda debe ser el de KARUM
                            '-----------------------------------------------------------------------------
                            htDatosDPC("NoTienda") = "D3" & oConfigCierreFI.IDTienda.PadLeft(5, "0")
                            htDatosDPC("NoCaja") = oAppContext.ApplicationConfiguration.NoCaja
                            htDatosDPC("Tarjeta") = txtNumeroTarjeta.Text
                            htDatosDPC("Monto") = txtMonto.Value
                            htDatosDPC("Vendedor") = ebNombrePlayer.Text.Trim() 'Vendedor
                            '-----------------------------------------------------------------------------
                            ' FLIZARRAGA 20/10/2017:  Incluimos la promocion (Payment Plan)
                            '-----------------------------------------------------------------------------
                            htDatosDPC("PM") = CStr(cmbPlazo.Text.Trim())
                            htDatosDPC("TarjetaHabiente") = Me.txtNombreCliente.Text.Trim()
                            '---------------------------------------------------------------------------------------
                            'FLIZARRAGA 20/10/2017:  Especificamos si fue deslizada o Digitada para determinar nombre
                            '---------------------------------------------------------------------------------------
                            If deslizada = True Then
                                htDatosDPC("Linea") = "DESLIZADA"
                            Else

                                htDatosDPC("Linea") = "DIGITADA"
                            End If

                            '-----------------------------------------------------------
                            'FLIZARRAGA 20/10/2017: Consecutivo POS
                            '-----------------------------------------------------------
                            Dim dtBancos As DataTable = oDPVFMgr.GetBancos()
                            Dim rows() As DataRow = dtBancos.Select("Codigo='" & Disposicion.Banco & "'")
                            htDatosDPC("ConsecutivoPOS") = CStr(resultado("ConsecutivoPOS")).PadLeft(4, "0")
                            If rows.Length > 0 Then
                                htDatosDPC("NoTarjeta") = Disposicion.NoServicio
                                htDatosDPC("Banco") = CStr(rows(0)!Banco)
                            Else
                                htDatosDPC("NoTarjeta") = ""
                                htDatosDPC("Banco") = ""
                            End If
                            
                            '-----------------------------------------------------------------------------
                            'FLIZARRAGA 25/10/2017: Se actualiza el estatus.
                            '-----------------------------------------------------------------------------

                            Disposicion.EstatusDisp = "Cancelado"
                            Disposicion.Save()
                            '-----------------------------------------------------------------------------
                            ' FLIZARRAGA 20/10/2017:  Imprimimos Vouchers de cancelacion de ventas
                            '-----------------------------------------------------------------------------
                            
                            Dim oOtrosPagos As New OtrosPagos
                            oOtrosPagos.ImprimirVoucherMicrocredito(htDatosDPC, "VTA", False, True)
                            oOtrosPagos.ImprimirVoucherMicrocredito(htDatosDPC, "VTA", True, True)
                            If MessageBox.Show("¿Deseas Reimprimir el ticket?", "Dportenis PRO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                                oOtrosPagos.ImprimirVoucherMicrocredito(htDatosDPC, "VTA", False, True)
                                oOtrosPagos.ImprimirVoucherMicrocredito(htDatosDPC, "VTA", True, True)
                            End If
                            Nuevo()
                        Else
                            EscribeLog(CStr(resultado("Mensaje")), "Cancelacion Prestamo Club DP")
                            MessageBox.Show(CStr(resultado("Mensaje")), "Dportenis", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        End If
                    End If
                Else
                    EscribeLog("El Webservice no envio respuesta", "Cancelación Prestamo Club DP")
                    MessageBox.Show("El WebService no envio respuesta", "Dportenis", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Catch ex As Exception
                EscribeLog(ex.Message, "Cancelación Prestamo Club DP")
                MessageBox.Show(ex.Message, "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

#End Region

End Class