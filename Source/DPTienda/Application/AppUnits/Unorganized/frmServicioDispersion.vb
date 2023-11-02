Imports DportenisPro.DPTienda.ApplicationUnits.DPValeFinanciero
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU
Imports System.Collections.Generic
Imports System.Threading

Public Class frmServicioDispersion

#Region "Variables de instancias"

    Private oDpvFMgr As DPValeFinancieroManager
    Private dtBancos As DataTable
    Private dtServicios As DataTable
    Private NumCelular As String
    Private TipoPrestamo As Integer = 1
    Private m_Dispersion As DisposicionEfeClubDP
    Private oDPVF As DPVFinancieroDispersion
    Private m_VoucherInfo As Hashtable
    Private m_Reproceso As Boolean = False
    Private strFiltro As String = "Codigo in ({0})"
    Private ListaExcepciones As New List(Of String)() From {"01", "02", "03", "04", "05"}
    Private Termino As Boolean = False

#End Region

#Region "Propiedades"

    Public Property Dispersion As DisposicionEfeClubDP
        Get
            Return m_Dispersion
        End Get
        Set(ByVal value As DisposicionEfeClubDP)
            m_Dispersion = value
        End Set
    End Property

    Public Property VoucherInfo As Hashtable
        Get
            Return m_VoucherInfo
        End Get
        Set(ByVal value As Hashtable)
            m_VoucherInfo = value
        End Set
    End Property

    Public Property Reproceso As Boolean
        Get
            Return m_Reproceso
        End Get
        Set(ByVal value As Boolean)
            m_Reproceso = value
        End Set
    End Property


#End Region

#Region "Constructores"

    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()
        oDpvFMgr = New DPValeFinancieroManager(oAppContext, oConfigCierreFI)
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        FillServicios()
        FillBancos()
    End Sub

    Public Sub New(ByVal Dispersion As DisposicionEfeClubDP, Optional ByVal Reproceso As Boolean = False)
        ' Llamada necesaria para el diseñador.
        InitializeComponent()
        oDpvFMgr = New DPValeFinancieroManager(oAppContext, oConfigCierreFI)
        FillServicios()
        FillBancos()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.Dispersion = Dispersion
        Me.Reproceso = Reproceso
        Me.txtNoTarjeta.Text = "**** **** **** " & Dispersion.NoTarjeta.Substring(Dispersion.NoTarjeta.Length - 4, 4)
        Me.txtNombreCliente.Text = Dispersion.NombreCliente
        If Reproceso Then
            oDPVF = oDpvFMgr.LoadDpvFinancieroDispersion(oAppContext.ApplicationConfiguration.Almacen, Dispersion.TransactionId, Dispersion.NoTarjeta)
            SetServicioDispersion(oDPVF)
        End If
    End Sub

#End Region

#Region "Metodos y Funciones"

    Private Sub FillServicios()
        'Dim dtServicios As DataTable = oDpvFMgr.GetServiciosFinancieros()
        '------------------------------------------------------------------------------------------------
        'FLIZARRAGA 25/07/2018: Activacion de servicios por plaza
        '------------------------------------------------------------------------------------------------
        Dim dtServicios As DataTable = oDpvFMgr.GetCatalogoServiciosByPlaza(2, oAppSAPConfig.Plaza)

        cmbServicio.DisplayMember = "Servicio"
        cmbServicio.ValueMember = "ServicioID"
        cmbServicio.DataSource = dtServicios
        cmbServicio.SelectedValue = dtServicios.Rows(0)!ServicioID
    End Sub

    Private Function FillServiciosByCodigoBanco(ByVal ServicioID As String) As DataTable
        Dim dtServicios As New DataTable()
        dtServicios = oDpvFMgr.GetServicioByCodigoBanco(ServicioID)
        Return dtServicios
    End Function

    '------------------------------------------------------------------------------
    ' FLIZARRAGA 17/10/2017: Funcion para limpiar los controles de los servicios
    '------------------------------------------------------------------------------
    Private Sub LimpiarServicios()

        '------------------------------------------------------------------------------
        'FLIZARRAGA 17/10/2017: Limpiamos los bancos para cargar solo los necesarios 
        '                     segun el servicio (SOLO TARJ. INTERBANCARIA)
        '------------------------------------------------------------------------------
        Me.cmbBanco.DataSource = Nothing
        FillBancos()
        '------------------------------------------------------------------------------
        Me.cmbBanco.Text = String.Empty
        Me.cmbBanco.SelectedValue = Nothing
        Me.cmbBanco.Enabled = False

        Me.txtCuenta.Text = String.Empty
        Me.txtCuenta.Enabled = False

        Me.txtClabe.Text = String.Empty
        Me.txtClabe.Enabled = False

        Me.txtNumTarjeta.Text = String.Empty
        Me.txtNumTarjeta.Enabled = False

        Me.txtCelular.Text = String.Empty
        'Me.txtCelular.Mask = "!(###) 000-0000"
        Me.txtCelular.Enabled = False

        Me.chkTransfer.Checked = False
        Me.chkTransfer.Enabled = False

        Me.cmbCompania.Text = String.Empty
        Me.cmbCompania.SelectedValue = Nothing
        Me.cmbCompania.Enabled = False

        Me.NumCelular = String.Empty

    End Sub

    '------------------------------------------------------------------------------
    ' FLIZARRAGA 17/10/2017: Funcion para mostrar o no los controles segun servicio
    '------------------------------------------------------------------------------
    Private Sub HabilitarCamposServicios(ByVal Habilitar As Boolean, Optional ByVal ServicioID As String = "")

        '------------------------------------------------------------------------------
        ' Deshabilitamos y limpiamos todos los servicios
        '------------------------------------------------------------------------------
        LimpiarServicios()

        '------------------------------------------------------------------------------
        ' Habilitamos los campos de servicios segun el servicio seleccionado
        '------------------------------------------------------------------------------
        If Habilitar Then
            Select Case ServicioID.Trim
                Case "01" ' CUENTA
                    '-------------------------------------------------------------------------------
                    'FLIZARRAGA 17/10/2017: MISMO BANCO
                    '-------------------------------------------------------------------------------
                    Me.cmbBanco.Enabled = True
                    Me.chkTransfer.Enabled = True
                    Me.txtCelular.Enabled = True
                    Me.txtCuenta.Enabled = True
                    Me.txtClabe.Enabled = False
                    Me.txtNumTarjeta.Enabled = False
                    Me.cmbCompania.Enabled = False
                    Me.cmbBanco.SelectedValue = CStr(dtBancos.Rows(0)!Codigo)
                    Me.cmbBanco.Focus()

                Case "02" 'CELULAR Transfer
                    Me.txtCelular.Enabled = True
                    Me.chkTransfer.Checked = True
                    Me.chkTransfer.Enabled = False
                    Me.cmbCompania.SelectedValue = "03"
                    Me.txtCuenta.Enabled = False
                    Me.txtClabe.Enabled = False
                    Me.txtCuenta.Focus()
                Case "03" 'TARJETA
                    '-------------------------------------------------------------------------------
                    'FLIZARRAGA 17/10/2017: MISMO BANCO
                    '-------------------------------------------------------------------------------
                    Me.chkTransfer.Enabled = False
                    Me.txtCelular.Enabled = True
                    Me.txtCuenta.Enabled = False
                    Me.txtClabe.Enabled = False
                    Me.cmbCompania.Enabled = False
                    Me.cmbBanco.SelectedValue = BancoDefault()
                    Me.cmbBanco.Enabled = False
                    Me.txtNumTarjeta.Enabled = True
                    Me.txtNumTarjeta.Focus()
                Case "04" 'TARJETA Interbancaria
                    Me.cmbBanco.Enabled = True
                    Me.txtNumTarjeta.Enabled = True
                    Me.chkTransfer.Checked = False
                    Me.chkTransfer.Enabled = False
                    Me.txtCelular.Enabled = True 'FLIZARRAGA 17/10/2017: MISMO BANCO
                    dtBancos = FiltrarBanco("9973", dtBancos)
                    Me.cmbBanco.DataSource = dtBancos
                    Me.cmbBanco.SelectedValue = CStr(dtBancos.Rows(0)!Codigo)
                    Me.cmbBanco.Focus()
                    Me.txtCuenta.Enabled = False
                    Me.txtClabe.Enabled = False
                    Me.cmbCompania.Enabled = False
                Case ("05") 'CLABE 
                    Me.cmbBanco.Enabled = True
                    Me.txtClabe.Enabled = True
                    Me.txtCelular.Enabled = True
                    Me.txtCuenta.Enabled = False
                    Me.txtNoTarjeta.Enabled = False
                    Me.cmbCompania.Enabled = False
                    Me.txtNumTarjeta.Enabled = False
                    Me.chkTransfer.Enabled = True
                    Me.cmbBanco.Focus()
                Case "06" 'CELULAR
                    Me.txtCelular.Enabled = True
                    Me.cmbCompania.Enabled = True
                    Me.chkTransfer.Enabled = False
                    Me.cmbCompania.Focus()
                Case "07" 'FLIZARRAGA 17/10/2017: ORDEN DE PAGO
                    Me.cmbBanco.Enabled = False
                    Me.cmbBanco.SelectedValue = BancoDefault()
                    Me.chkTransfer.Enabled = False
                    Me.cmbBanco.Focus()
                Case "09" 'FLIZARRAGA 17/10/2017: TOKA
                    Me.cmbBanco.SelectedValue = BancoDefault()
                    Me.cmbBanco.Enabled = False
                    Me.txtNumTarjeta.Enabled = True
                    Me.txtCelular.Enabled = True
                    Me.txtCuenta.Enabled = False
                    Me.txtClabe.Enabled = False
                    Me.cmbCompania.Enabled = False
                    Me.txtNumTarjeta.Focus()
                Case Else
                    '------------------------------------------------------------------------------
                    ' Deshabilitamos todos los servicios
                    '------------------------------------------------------------------------------
                    LimpiarServicios()
            End Select
        Else
            '------------------------------------------------------------------------------
            ' Deshabilitamos todos los servicios
            '------------------------------------------------------------------------------
            Me.cmbServicio.DataSource = Nothing
            FillServicios()
            Me.cmbServicio.Text = String.Empty
        End If

    End Sub

    '---------------------------------------------------------------------
    ' FLIZARRAGA 17/10/2017: Funcion para cargar los servicios financieros
    '---------------------------------------------------------------------
    Private Sub FillBancos()

        dtBancos = oDpvFMgr.GetBancos()

        'Dim strFiltro As String = String.Empty

        If Me.cmbServicio.SelectedValue = "01" Then
            If servicioActivo("01") And servicioActivo("10") Then
                dtBancos = FiltrarBanco("0002", dtBancos)
                dtBancos = FiltrarBanco("0012", dtBancos)
                'strFiltro = "Codigo IN ('0002','0012')"
            ElseIf servicioActivo("01") Then
                dtBancos = FiltrarBanco("0002", dtBancos)
                'strFiltro = "Codigo IN ('0002')"
            Else
                dtBancos = FiltrarBanco("0012", dtBancos)
                'strFiltro = "Codigo IN ('0012')"
            End If
        End If

        '-----------------------------------------------------------------------------

        'Dim dvBancos As New DataView(dtBancos, strFiltro, "Codigo", DataViewRowState.CurrentRows)
        With cmbBanco
            .DataSource = dtBancos

            .DisplayMember = "Banco"
            .ValueMember = "Codigo"

            .Refresh()

        End With

    End Sub

    Private Function servicioActivo(ByVal id As String) As Boolean
        Return oDpvFMgr.GetServiciosFinancierosByID_Act(id)
    End Function

    '------------------------------------------------------------------------------
    ' FLIZARRAGA 17/10/2017: Funcion para mostrar el Banco del Servicio
    '------------------------------------------------------------------------------
    Private Function BancoDefault(Optional ByRef InstitucionFinanciera As String = "") As String
        'Dim dtServicio As DataTable = Me.cmbServicio.DataSource
        Dim dtServicio As DataTable = oDpvFMgr.GetServiciosFinancieros(True)

        Dim oRow() As DataRow = dtServicio.Select("ServicioID='" & CStr(cmbServicio.SelectedValue) & "'")
        '------------------------------------------------------------------------------
        ' FLIZARRAGA 20/10/2017: Obtenemos el Nombre del Banco
        '------------------------------------------------------------------------------
        InstitucionFinanciera = CStr(oRow(0)("InstitucionFinanciera"))
        '------------------------------------------------------------------------------
        Return CStr(oRow(0)("CodigoBanco"))
    End Function

    Private Sub Dispersar()
        Try
            '--------------------------------------------------------------------------------------
            ' FLIZARRAGA 17/10/2017 Obtenemos la fecha actual del servidor centralizado
            '--------------------------------------------------------------------------------------
            Dim FechaDispersion As Date = CDate(oDpvFMgr.GetFechaServidor()) 'Date.Now
            If ValidaCampos() Then
                '--------------------------------------------------------------------------------------
                ' FLIZARRAGA 20/10/2017: Validamos hora y fecha de dispersion para servicio interbancario
                '--------------------------------------------------------------------------------------
                If Not ValidaDispersionInterbancaria(Me.cmbServicio.SelectedValue, Me.cmbServicio.Text.Trim(), Me.cmbBanco.SelectedValue, FechaDispersion) Then
                    Exit Try
                End If
                '--------------------------------------------------------------------------------------
                ' FLIZARRAGA 20/10/2017: Primero realizamos la dispersion en TOK. Si marca error no continua
                '--------------------------------------------------------------------------------------
                If Not DispersionTOKA(Me.Dispersion.AccountNumber, Me.Dispersion.NombreCliente, Me.txtNumTarjeta.Text.Trim(), Me.Dispersion.Monto) Then
                    Exit Sub
                End If
                If oDpvFMgr.ValidarServicioDispersion(CStr(cmbServicio.SelectedValue).Trim(), txtNumTarjeta.Text.Trim()) > 0 Then
                    TipoPrestamo = 5
                End If
                If GuardarDatosArchivo(0, txtCuenta.Text.Trim(), FechaDispersion, Dispersion.Monto, TipoPrestamo, True, _
                                    Dispersion.IFE, cmbBanco.Text.Trim(), txtCelular.UnmaskedText.Trim(), _
                                    cmbCompania.Text.Trim(), txtClabe.Text.Trim(), Me.chkTransfer.Checked, _
                                    txtNumTarjeta.Text.Trim(), CStr(cmbServicio.SelectedValue).Trim(), Dispersion.NombreCliente, CStr(cmbBanco.SelectedValue).Trim()) Then
                    MessageBox.Show("La solicitud de dispersión de efectivo se actualizado", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ClearFields()
                    Me.Termino = True
                    Me.DialogResult = DialogResult.OK
                Else
                    Me.DialogResult = DialogResult.Cancel
                End If
            End If
        Catch ex As Exception
            Dispersion.EstatusDisp = "Rechazado"
            Dispersion.Save()
            EscribeLog(ex.Message, "Error al dispersar el prestamo")
            MessageBox.Show(ex.Message, "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.DialogResult = DialogResult.Cancel
        End Try
    End Sub

    Private Function ValidaCampos() As Boolean
        Dim valido As Boolean = True

        '-----------------------------------------------------------------------------------------------------------
        ' FLIZARRAGA 17/10/2017: Validamos los campos del Servicios Financieros
        '-----------------------------------------------------------------------------------------------------------
        If Not ValidaCamposServicios() Then
            Return False
        End If

        '--------------------------------------------------------------------------------------
        ' FLIZARRAGA 17/10/2017: Validar que no haya dispersiones en un lapso de 7 meses
        '--------------------------------------------------------------------------------------
        '---------------------------------------------------------------------------------------------------------------------
        ' FLIZARRAGA 20/10/2017: Validamos si ya cuenta con un prestamo anterior (no aplica TOKA) para determinar si es expres
        '---------------------------------------------------------------------------------------------------------------------
        If Reproceso = False Then
            If ValidaPrestamoAnterior() Then
                TipoPrestamo = 5 'Cambiamos el tipo a 5 (Prestamo a Cliente final Expres)
            Else
                '--------------------------------------------------------------------------------------
                ' FLIZARRAGA 20/10/2017: Validar que no haya dispersiones en un lapso de 7 meses
                '--------------------------------------------------------------------------------------
                If Me.ListaExcepciones.Contains(cmbServicio.SelectedValue) = False Then
                    If Not ValidaMeses(CDate(oDpvFMgr.GetFechaServidor())) Then
                        Return False
                    End If
                End If
                '--------------------------------------------------------------------------------------
            End If
        End If
        If MessageBox.Show("El préstamo se realizará por un monto de " & Format(Me.Dispersion.Monto, "$ #0.0") & " a un plazo de " & Me.Dispersion.PlazoDisp & " meses." & vbCrLf & vbCrLf & _
        "¿Es correcta esta información?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
            Return False
        End If
        Return valido
    End Function

    '------------------------------------------------------------------------------
    ' FLIZARRAGA 20/10/2017: Funcion para mostrar el Banco del Servicio
    '------------------------------------------------------------------------------
    Private Function ValidaCamposServicios() As Boolean

        Dim bResp As Boolean = True
        Dim DatoAConfirmar As String = ""

        '------------------------------------------------------------------------------
        ' FLIZARRAGA 17/10/2017: Un solo servicio de tarjetas
        '------------------------------------------------------------------------------
        Select Case Me.cmbServicio.SelectedValue

            '------------------------------------------------------------------------------
            ' FLIZARRAGA 17/10/2017: Un solo servicio de tarjetas
            '------------------------------------------------------------------------------
            'Select Case ServicioValues
            '------------------------------------------------------------------------------
            '------------------------------------------------------------------------------
            'Case "01" ' CUENTA
            Case "01", "10" ' FLIZARRAGA 17/10/2017: Un solo servicio

                '--------------------------------------------------------------------
                ' VALIDAMOS QUE HAYA SELECCIONADO EL BANCO
                '--------------------------------------------------------------------
                If Me.cmbBanco.Text.Trim = String.Empty Then
                    MessageBox.Show("Es necesario seleccionar el Banco.", "Servicio Financiero", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Me.cmbBanco.Focus()
                    bResp = False
                    Exit Function
                End If

                '--------------------------------------------------------------------
                ' VALIDAMOS QUE HAYA CAPTURADO LA CUENTA
                '--------------------------------------------------------------------
                If Me.txtCuenta.Text.Trim() = String.Empty Then
                    MessageBox.Show("Es necesario capturar el Número de Cuenta.", "Servicio Financiero", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Me.txtCuenta.Focus()
                    bResp = False
                    Exit Function
                End If

                '--------------------------------------------------------------------
                ' FLIZARRAGA 17/10/2017: VALIDAMOS QUE LA CUENTA TENGA LA LONGITUD CORRECTA
                '--------------------------------------------------------------------
                If Me.txtCuenta.Text.Trim.Length < 11 OrElse Me.txtCuenta.Text.Trim.Length > 11 Then
                    MessageBox.Show("El Número de Cuenta es incorrecta. Favor de verificar.", "Servicio Financiero", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Me.txtCuenta.Focus()
                    bResp = False
                    Exit Function
                End If

                '--------------------------------------------------------------------
                ' FLIZARRAGA 17/10/2017: VALIDAMOS QUE EL CEL TENGA LA LONGITUD CORRECTA
                '--------------------------------------------------------------------
                If Me.txtCelular.UnmaskedText.Trim.Length <> 10 Then
                    MessageBox.Show("El número de Celular es incorrecto. Favor de verificar.", "Servicio Financiero", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Me.txtCelular.Focus()
                    bResp = False
                    Exit Function
                End If


                '--------------------------------------------------------------------
                ' FLIZARRAGA 17/10/2017: Obtenemos el dato a confirmar
                '--------------------------------------------------------------------
                DatoAConfirmar = Me.txtCuenta.Text.Trim

            Case "02", "06" 'CELULAR (Con o sin Transfer)

                '--------------------------------------------------------------------
                ' VALIDAMOS LA COMPAÑIA
                '--------------------------------------------------------------------
                If Me.cmbCompania.Text.Trim() = String.Empty Then
                    MessageBox.Show("Es necesario seleccionar la Compañia Celular.", "Servicio Financiero", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Me.cmbCompania.Focus()
                    bResp = False
                    Exit Function
                End If

                '--------------------------------------------------------------------
                ' VALIDAMOS QUE EL CELULAR
                '--------------------------------------------------------------------
                If Me.txtCelular.UnmaskedText.Trim() = String.Empty Then
                    MessageBox.Show("Es necesario capturar el Número de Celular.", "Servicio Financiero", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Me.txtCelular.Focus()
                    bResp = False
                    Exit Function
                End If

                '--------------------------------------------------------------------
                ' FLIZARRAGA 17/10/2017: VALIDAMOS QUE EL CEL TENGA LA LONGITUD CORRECTA
                '--------------------------------------------------------------------
                If Me.txtCelular.UnmaskedText.Trim().Length <> 10 Then
                    MessageBox.Show("El número de Celular es incorrecto. Favor de verificar.", "Servicio Financiero", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Me.txtCelular.Focus()
                    bResp = False
                    Exit Function
                End If

                '-----------------------------------------------------------------------------------
                ' FLIZARRAGA 17/10/2017: Obtenemos el dato a confirmar
                '-----------------------------------------------------------------------------------
                DatoAConfirmar = Me.txtCelular.UnmaskedText.Trim()

                'Case "03", "04" 'TARJETA / TARJETA INTERBANCARIA
            Case "03", "04", "11", "12" 'FLIZARRAGA 17/10/2017: UN SOLO SERVICIO DE TARJETAS

                '--------------------------------------------------------------------
                ' VALIDAMOS QUE HAYA SELECCIONADO EL BANCO
                '--------------------------------------------------------------------
                If Me.cmbBanco.Text.Trim = String.Empty Then
                    MessageBox.Show("Es necesario seleccionar el Banco.", "Servicio Financiero", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Me.cmbBanco.Focus()
                    bResp = False
                    Exit Function
                End If

                '--------------------------------------------------------------------
                ' VALIDAMOS QUE HAYA SELECCIONADO EL NUM DE TARJETA
                '--------------------------------------------------------------------
                If Me.txtNumTarjeta.Text.Trim() = String.Empty Then
                    MessageBox.Show("Es necesario capturar el Número de Tarjeta.", "Servicio Financiero", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Me.txtNumTarjeta.Focus()
                    bResp = False
                    Exit Function
                End If

                '---------------------------------------------------------------------------
                ' FLIZARRAGA 17/10/2017: VALIDAMOS QUE LA TARJETA TENGA LA LONGITUD CORRECTA
                '---------------------------------------------------------------------------
                If Me.txtNumTarjeta.Text.Trim().Length <> 16 Then
                    MessageBox.Show("El número de Tarjeta es incorrecto. Favor de verificar.", "Servicio Financiero", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Me.txtNumTarjeta.Focus()
                    bResp = False
                    Exit Function
                End If

                '--------------------------------------------------------------------
                ' FLIZARRAGA 17/10/2017: VALIDAMOS QUE EL CEL TENGA LA LONGITUD CORRECTA
                '--------------------------------------------------------------------
                If Me.txtCelular.UnmaskedText.Trim().Length <> 10 Then
                    MessageBox.Show("El número de Celular es incorrecto. Favor de verificar.", "Servicio Financiero", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Me.txtCelular.Focus()
                    bResp = False
                    Exit Function
                End If


                '--------------------------------------------------------------------
                ' FLIZARRAGA 17/10/2017: Obtenemos el dato a confirmar
                '--------------------------------------------------------------------
                DatoAConfirmar = Me.txtNumTarjeta.Text.Trim

            Case "05" 'CLABE 

                '--------------------------------------------------------------------
                ' VALIDAMOS QUE HAYA SELECCIONADO EL BANCO
                '--------------------------------------------------------------------
                If Me.cmbBanco.Text.Trim = String.Empty Then
                    MessageBox.Show("Es necesario seleccionar el Banco.", "Servicio Financiero", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Me.cmbBanco.Focus()
                    bResp = False
                    Exit Function
                End If

                '--------------------------------------------------------------------
                ' VALIDAMOS QUE HAYA CAPUTRADO LA CUENTA CLABE
                '--------------------------------------------------------------------
                If Me.txtClabe.Text.Trim = String.Empty Then
                    MessageBox.Show("Es necesario capturar la Cuenta CLABE.", "Servicio Financiero", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Me.txtClabe.Focus()
                    bResp = False
                    Exit Function
                End If

                '---------------------------------------------------------------------------
                ' FLIZARRAGA 17/10/2017: VALIDAMOS QUE LA CLABE TENGA LA LONGITUD CORRECTA
                '---------------------------------------------------------------------------
                If Me.txtClabe.Text.Trim().Length <> 18 Then
                    MessageBox.Show("La Cuenta CLABE es incorrecta. Favor de verificar.", "Servicio Financiero", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Me.txtClabe.Focus()
                    bResp = False
                    Exit Function
                End If

                '--------------------------------------------------------------------
                ' FLIZARRAGA 17/10/2017: Obtenemos el dato a confirmar
                '--------------------------------------------------------------------
                DatoAConfirmar = Me.txtClabe.Text.Trim()

            Case "07" 'FLIZARRAGA 17/10/2017: ORDEN DE PAGO

                '--------------------------------------------------------------------
                ' FLIZARRAGA 17/10/2017: VALIDAMOS QUE HAYA SELECCIONADO EL BANCO
                '--------------------------------------------------------------------
                If Me.cmbBanco.Text.Trim = String.Empty Then
                    MessageBox.Show("Es necesario seleccionar el Banco.", "Servicio Financiero", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Me.cmbBanco.Focus()
                    bResp = False
                    Exit Function
                End If

                '--------------------------------------------------------------------
                ' FLIZARRAGA 17/10/2017: Obtenemos el dato a confirmar
                '--------------------------------------------------------------------
                DatoAConfirmar = Me.txtClabe.Text.Trim()

            Case "09" 'FLIZARRAGA 17/10/2017:TOKA
                '--------------------------------------------------------------------
                ' VALIDAMOS QUE HAYA SELECCIONADO EL BANCO
                '--------------------------------------------------------------------
                If Me.cmbBanco.Text.Trim = String.Empty Then
                    MessageBox.Show("Es necesario seleccionar el Banco.", "Servicio Financiero", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Me.cmbBanco.Focus()
                    bResp = False
                    Exit Function
                End If

                '--------------------------------------------------------------------
                ' VALIDAMOS QUE HAYA SELECCIONADO EL NUM DE TARJETA
                '--------------------------------------------------------------------
                If Me.txtNumTarjeta.Text.Trim() = String.Empty Then
                    MessageBox.Show("Es necesario capturar el Número de Tarjeta.", "Servicio Financiero", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Me.txtNumTarjeta.Focus()
                    bResp = False
                    Exit Function
                End If

                '---------------------------------------------------------------------------
                ' VALIDAMOS QUE LA TARJETA TENGA LA LONGITUD CORRECTA
                '---------------------------------------------------------------------------
                If Me.txtNumTarjeta.Text.Trim.Length <> 16 Then
                    MessageBox.Show("El número de Tarjeta es incorrecto. Favor de verificar.", "Servicio Financiero", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Me.txtNumTarjeta.Focus()
                    bResp = False
                    Exit Function
                End If

                '--------------------------------------------------------------------
                ' Obtenemos el dato a confirmar
                '--------------------------------------------------------------------
                DatoAConfirmar = Me.txtNumTarjeta.Text.Trim()


            Case Else 'No se selecciono Servicio

                MsgBox("Es necesario Seleccionar un Servicio Financiero.", MsgBoxStyle.Exclamation, "Servicios Financieros")
                Me.cmbServicio.Focus()
                bResp = False
                Exit Function

        End Select

        '------------------------------------------------------------------------------
        ' FLIZARRAGA 17/10/2017: Funcion para confirmar datos de servicio
        '------------------------------------------------------------------------------
        If Not ConfirmaDatosServicio(Me.cmbServicio.SelectedValue, DatoAConfirmar) Then
            '------------------------------------------------------------------------------
            ' FLIZARRAGA 20/10/2017: Un solo servicio de tarjetas
            '------------------------------------------------------------------------------
            'If Not ConfirmaDatosSerivicio(ServicioValues, DatoAConfirmar) Then
            '------------------------------------------------------------------------------
            MessageBox.Show("Se encontraron diferencias. Favor de verificar.", "Servicios Financieros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            bResp = False
            Exit Function
        End If


        Return bResp

    End Function

    '------------------------------------------------------------------------------
    ' FLIZARRAGA 17/10/2017: Funcion para confirmar datos de servicio
    '------------------------------------------------------------------------------
    Private Function ConfirmaDatosServicio(ByVal ServicioID As String, ByVal DatoConfirmacion As String) As Boolean

        Dim bResp As Boolean = True

        Dim strMensaje As String = ""
        Select Case ServicioID
            Case "01", "10" ' CUENTA
                strMensaje = "el Número de Cuenta."
            Case "02", "06" 'CELULAR (Con o sin Transfer)
                strMensaje = "el Celular."
            Case "03", "12" 'TARJETA
                strMensaje = "el Número de Tarjeta."
            Case "04", "11" 'TARJETA Interbancaria
                strMensaje = "el Número de Tarjeta Interbancaria."
            Case "05" 'CLABE 
                strMensaje = "la Cuenta CLABE."
            Case "07" ' FLIZARRAGA 17/10/2017: ORDEN DE PAGO
                DatoConfirmacion = String.Empty
                strMensaje = "La Orden de Pago se va a realizar a nombre de " & Me.Dispersion.NombreCliente & "." & vbCrLf & "Favor de dar click en Aceptar para generarlo o en Cancelar para anular la operación."
            Case "09" 'FLIZARRAGA 17/10/2017: TOKA
                'strMensaje = "el Número de Tarjeta TOKA."
                strMensaje = "el Número de Tarjeta Club DP."
            Case Else 'No se selecciono Servicio
                MsgBox("Es necesario Seleccionar un Servicio Financiero.", MsgBoxStyle.Exclamation, "Servicios Finanacieros")
                Me.cmbServicio.Focus()
                Return False
        End Select

        '-------------------------------------------------------------------------------------------
        ' FLIZARRAGA 17/10/2017: Validamos el dato a confirmar para saber el tipo de confirmacion
        '-------------------------------------------------------------------------------------------
        If DatoConfirmacion.Trim <> String.Empty Then
            If InputBox("Favor de Confirmar " & strMensaje, "Servicios Finanacieros").Trim = DatoConfirmacion.Trim Then
                If ServicioID.Trim() <> "09" Then
                    bResp = ConfirmarCelularCliente(ServicioID)
                End If
            Else
                bResp = False
            End If
        Else
            If MessageBox.Show(strMensaje, "Servicios Financieros", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = DialogResult.OK Then
                If ServicioID.Trim() <> "09" Then
                    bResp = ConfirmarCelularCliente(ServicioID)
                End If
            Else
                bResp = False
            End If
        End If

        Return bResp

    End Function

    '---------------------------------------------------------------------------------------------
    ' FLIZARRAGA 17/10/2017: Funcion para confirmar el celular del cliente
    '---------------------------------------------------------------------------------------------
    Private Function ConfirmarCelularCliente(ByVal ServicioID As String) As Boolean

        Dim bResp As Boolean

        '-----------------------------------------------------------------------------------------
        ' Confirmamos el Celular de contacto del cliente y si no,lo ingresa, que no deje avanzar
        '-----------------------------------------------------------------------------------------
        'FLIZARRAGA 17/10/2017: MISMO BANCO
        If ServicioID <> "02" AndAlso ServicioID <> "06" And ServicioID <> "01" And ServicioID <> "03" And ServicioID <> "04" And ServicioID <> "11" And ServicioID <> "12" Then
            Me.NumCelular = String.Empty
            Me.NumCelular = InputBox("Favor de proporcionar un Número de Celular del Cliente.", "Servicios Finanacieros").Trim
            If Me.NumCelular.Trim <> String.Empty Then
                If Me.NumCelular.Trim.Length = 10 Then
                    bResp = True
                Else
                    MsgBox("Número de Celular del Cliente Invalido. El Número debe ser de 10 digitos.", MsgBoxStyle.Exclamation, "Servicios Finanacieros")
                    bResp = False
                End If
            Else
                MsgBox("Es necesario proporcionar un Número de Celular del Cliente.", MsgBoxStyle.Exclamation, "Servicios Finanacieros")
                bResp = False
            End If
        Else
            bResp = True
        End If

        Return bResp

    End Function

    '----------------------------------------------------------------------------------------------------------------------
    ' FLIZARRAGA 17/10/2017 - Función para validar que no se repita dispersión en 7 meses
    '----------------------------------------------------------------------------------------------------------------------
    Private Function ValidaMeses(ByVal fecha_actual As Date) As Boolean
        Dim data As DataSet

        Dim servicioId As Integer = Me.cmbServicio.SelectedValue 'Integer.Parse(ServicioValues)

        data = oDpvFMgr.GetByFecha(servicioId, txtCuenta.Text, txtCelular.UnmaskedText, txtNumTarjeta.Text, txtClabe.Text)
        'data = oDPVFMgr.GetByFecha(1, "12312312312", ebCelular.Text, ebNumTarjeta.Text, ebCLABE.Text)
        Dim dtTemp As DataTable

        If data.Tables.Count > 0 Then
            dtTemp = data.Tables(0).Copy
        End If

        Dim fecha As Date
        Dim meses As Integer = -6
        Dim fecha_seis As Date = fecha_actual.AddMonths(meses)
        Dim repite As Boolean = True

        Dim i As Integer
        If Not dtTemp Is Nothing Then
            For i = 0 To (dtTemp.Rows.Count - 1)
                fecha = dtTemp.Rows(i).Item("Fecha")
                Dim res As Integer = DateTime.Compare(fecha_seis, fecha)
                If res < 0 Then
                    repite = False
                End If
            Next i
        End If

        If repite = False Then
            Dim NombreServicio As String
            Select Case servicioId
                Case "01"
                    NombreServicio = "Cuenta"
                Case "02"
                    NombreServicio = "Celular Transfer"
                Case "03"
                    NombreServicio = "Tarjeta"
                Case "04"
                    NombreServicio = "Tarjeta Interbancaria"
                Case "05"
                    NombreServicio = "Clabe"
                Case "06"
                    NombreServicio = "Celular"
                Case "09"
                    'NombreServicio = "Tarjeta TOKA"
                    NombreServicio = "Tarjeta Club DP"
            End Select

            If servicioId = "02" Or servicioId = "06" Then
                MsgBox("El " + NombreServicio + " que esta ingresando ya esta registrado para otro prestamo, favor de ingresar un " + NombreServicio + " nuevo", MsgBoxStyle.Exclamation, "Dportenis Vale Financiero")
            Else
                MsgBox("La " + NombreServicio + " que esta ingresando ya esta registrada para otro prestamo, favor de ingresar una " + NombreServicio + " nueva", MsgBoxStyle.Exclamation, "Dportenis Vale Financiero")
            End If

            Me.cmbServicio.Focus()

        End If
        Return repite

    End Function

    '----------------------------------------------------------------------------------------------------------
    ' FLIZARRAGA 20/10/2017:Funcion para obtener mensaje de dispersion interbancaria
    '----------------------------------------------------------------------------------------------------------
    Public Function ValidaDispersionInterbancaria(ByVal ServicioID As String, ByVal NombreServicio As String, ByVal Banco As String, ByRef FechaDispersion As Date) As Boolean

        Dim bResp As Boolean = True
        Dim Mensaje As String = String.Empty
        Dim Confirmar As Boolean = False
        Dim HorariosDispersion As DataTable
        Dim strFecha As String = String.Empty
        Dim FechaActual As DateTime = FechaDispersion

        '--------------------------------------------------------------------------------------
        ' FLIZARRAGA 20/10/2017: Validamos que sea un servicio interbancario
        '--------------------------------------------------------------------------------------
        If Not (ServicioID = "05" Or ServicioID = "04" Or ServicioID = "06" Or ServicioID = "07") OrElse ServicioID = "05" AndAlso Banco = "0002" Then
            Return bResp
        End If
        '--------------------------------------------------------------------------------------

        Try

            '--------------------------------------------------------------------------------------
            ' FLIZARRAGA 20/10/2017: Obtenemos la fecha desde Store de SQL
            '--------------------------------------------------------------------------------------
            strFecha = oDpvFMgr.GetFechaDispersion(ServicioID, FechaDispersion, HorariosDispersion)
            If strFecha = String.Empty OrElse HorariosDispersion Is Nothing Then
                MessageBox.Show("No se encontrarón los horarios correspondientes al Servicio de " & NombreServicio & ". Favor de comunicarse con soporte.", "Servicios Financieros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return bResp
            Else
                FechaDispersion = CDate(strFecha)
            End If
            '--------------------------------------------------------------------------------------

            '--------------------------------------------------------------------------------------
            ' Validamos si la fecha de dispersion es igual a la actual o no
            '--------------------------------------------------------------------------------------
            If FechaDispersion.ToShortDateString <= FechaActual.ToShortDateString Then
                Return bResp
            Else
                Confirmar = True
            End If
            '--------------------------------------------------------------------------------------

            '----------------------------------------------------------------------------
            ' FLIZARRAGA 20/10/2017: Obtenemos el mensaje Correspondiente
            '----------------------------------------------------------------------------
            Dim strHorarios As String = String.Empty
            For Each oRow As DataRow In HorariosDispersion.Rows
                strHorarios &= " - " & oRow.Item("Dia").ToString & ": De " & CDate(oRow.Item("HoraInicio").ToString).ToShortTimeString & " a " & CDate(oRow.Item("HoraFin").ToString).ToShortTimeString & vbCrLf
            Next
            'Mensaje = "Te recordamos que nuestro Horarios con " & NombreServicio & " son:" & vbCrLf & vbCrLf & _
            '          strHorarios & " - (Horarios del Centro del País)" & vbCrLf & vbCrLf & _
            '          "Por lo que el Prestamo se reflejará hasta el próximo día hábil bancario (" & FechaDispersion.ToShortDateString & ")."
            Mensaje = "Favor de consultar tu tabla de horarios e informar al cliente del día y la hora en que recibirá su transferencia" & vbCrLf

            '-----------------------------------------------------------------------------------------------------------
            ' SI NO CONFIRMA LA FECHA DE DISPERSION, NO GENERA EL PRESTAMO
            '-----------------------------------------------------------------------------------------------------------
            If Not ConfirmarFechaDispersion(Mensaje) Then
                bResp = False
                Return bResp
                'Exit Function
            End If
        Catch ex As Exception
            EscribeLog(ex.ToString, "Ocurrio un error al Validar los horarios de los servicios de dispersión interbancaria.")
            Throw ex
        End Try

        Return bResp

    End Function

    '----------------------------------------------------------------------------------------------------------
    ' FLIZARRAGA 17/10/2017: Funcion para confirmar la fecha de prestamo
    '----------------------------------------------------------------------------------------------------------
    Private Function ConfirmarFechaDispersion(ByVal Mensaje As String) As Boolean

        Dim bResp As Boolean = True

        '----------------------------------------------------------------------------
        ' MOSTRAMOS EL MENSAJE OBTENIDO
        '----------------------------------------------------------------------------
        If MessageBox.Show(Mensaje & " ¿Desea continuar con el tramite?", "Serivicios Financieros", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then

            MessageBox.Show("No se Genero el Prestamo.", "Servicios Financieros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            bResp = False

        End If

        Return bResp

    End Function

#End Region

#Region "Eventos"
    Private Sub cmbServicio_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbServicio.SelectedValueChanged
        If Not cmbServicio.SelectedValue Is Nothing Then
            HabilitarCamposServicios(True, Me.cmbServicio.SelectedValue)
        End If
    End Sub

    Private Sub cmbBanco_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBanco.SelectedValueChanged
        If Not cmbBanco.SelectedValue Is Nothing Then
            If cmbServicio.SelectedValue = "01" Or cmbServicio.SelectedValue = "01" Then
                If cmbBanco.SelectedValue = "0002" Then
                    Me.chkTransfer.Enabled = True
                    Me.txtCuenta.Text = "" 'FLIZARRAGA 17/10/2017
                    Me.txtCuenta.MaxLength = 11
                ElseIf cmbBanco.SelectedValue = "0012" Then
                    Me.chkTransfer.Enabled = False
                    Me.txtCuenta.Text = "" 'FLIZARRAGA 17/10/2017
                    Me.txtCuenta.MaxLength = 10
                End If
            End If
        End If
    End Sub

    Private Sub btnDispersar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDispersar.Click
        Dispersar()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        If MessageBox.Show("¿Esta seguro de cancelar la operación de dispersión?", "Dportenis PRO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Dispersion.EstatusDisp = "Rechazado"
            Dispersion.Save()
            Me.Termino = True
            Me.DialogResult = DialogResult.Cancel
            Me.Dispose()
        End If
    End Sub

    Private Sub txtNumTarjeta_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtNumTarjeta.Validating
        Try
            If Me.txtNumTarjeta.Text.Trim = "" Then
                Me.txtNumTarjeta.Text = "Deslize Tarjeta ..."
                Exit Sub
            End If

            If Me.txtNumTarjeta.Text.Trim.Length > 16 Then
                Dim strTrack() As String = Me.txtNumTarjeta.Text.Split(";")
                Dim strNoTarjeta() As String = strTrack(1).Split("=")
                Me.txtNumTarjeta.Text = strNoTarjeta(0).Trim
            End If
            'RSANCHEZ 24.10.2016
            '1.1.1	Validación banco emisor y tipo de tarjeta. 

            If Me.txtNumTarjeta.Text.Trim.Length = 16 Then
                'ValidaMeses(Date.Now)
                Dim id_prosa As String = ""
                Select Case Me.cmbServicio.SelectedValue
                    Case "03"   'TARJETA
                        Dim bin = txtNumTarjeta.Text.Trim.Substring(0, 6)
                        If bin = "476684" Or bin = "476687" Then
                            id_prosa = oDpvFMgr.GetBinesCod(bin, "d", True)
                            Me.chkTransfer().Checked = oDpvFMgr.GetBinTransfer(bin, "d", True)
                            If Me.chkTransfer.Checked Then
                                Me.chkTransfer.Enabled = False
                            End If
                        Else
                            id_prosa = oDpvFMgr.GetBinesCod(bin, "d", True)
                            Me.chkTransfer.Checked = False
                            'If Me.Reproceso = False Then
                            '    id_prosa = oDpvFMgr.GetBinesCod(bin, "d", True)
                            '    Me.chkTransfer.Checked = False
                            'Else
                            '    MessageBox.Show("El bin de la tarjeta no pertenece a tarjetas Banamex", "Dportenis Pro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            '    Me.txtNumTarjeta.Text = ""
                            '    Me.txtNumTarjeta.Focus()
                            '    Exit Sub
                            'End If

                        End If
                    Case "04"   'TARJETA INTERBANCARIA
                        Dim bin = txtNumTarjeta.Text.Trim.Substring(0, 6)
                        id_prosa = oDpvFMgr.GetBinesCod(bin, "d", True)
                    Case "09"   'TOKA
                        Dim bin = txtNumTarjeta.Text.Trim.Substring(0, 6)
                        If bin = "506302" Or bin = "637480" Or bin = "511765" Then
                            id_prosa = oDpvFMgr.GetBinesCod(bin, "d", True)
                        Else
                            If Me.Reproceso = False Then
                                id_prosa = oDpvFMgr.GetBinesCod(bin, "d", True)
                                Me.chkTransfer.Checked = False
                            Else
                                MessageBox.Show("El bin no pertenece a Club DP Debito", "Dportenis Pro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                Me.txtNumTarjeta.Text = ""
                                Me.txtNumTarjeta.Focus()
                                Exit Sub
                            End If

                        End If

                    Case Else
                        id_prosa = "0"
                End Select

                '1.1.2	Algoritmo que verifica que el número de tarjeta sea correcta.
                Dim pares(7) As Integer
                Dim impar(7) As Integer
                Dim i As Integer
                Dim suma As Integer = 0
                Dim suma2 As Integer = 0

                For i = 0 To 7
                    impar(i) = (Integer.Parse(txtNumTarjeta.Text.Substring((i * 2) + 1, 1)))
                    pares(i) = Integer.Parse(txtNumTarjeta.Text.Substring(i * 2, 1)) * 2
                    If (pares(i) > 9) Then
                        pares(i) = pares(i) - 9
                    End If
                    suma += pares(i) + impar(i)
                Next i

                suma2 = suma - impar(7)
                suma2 = suma2 * 9
                Dim dig_v As String
                dig_v = suma2.ToString()
                dig_v = dig_v.Substring(dig_v.Length - 1, 1)



                If (id_prosa.Trim.Length < 1) Then
                    'MsgBox("Tarjeta bancaria no permitida. Favor de ingresar otra", MsgBoxStyle.Exclamation, "Dportenis Vale Financiero")
                    MsgBox("Favor de ingresar otro numero de tarjeta. El sistema no reconoce la tarjeta ingresada como tarjeta de Debito", MsgBoxStyle.Exclamation, "Dportenis Vale Financiero")
                    Me.txtNumTarjeta.Focus()
                Else
                    If (suma Mod 10 <> 0) Or (Not dig_v.Equals(txtNumTarjeta.Text.Substring(15))) Then
                        MsgBox("Número de Tarjeta Incorrecto. Favor de ingresar otra", MsgBoxStyle.Exclamation, "Dportenis Vale Financiero")
                        Me.txtNumTarjeta.Focus()
                    Else
                        If id_prosa = "0002" Or id_prosa = "0012" Then
                            If Me.cmbServicio.SelectedValue = "03" Then
                                'Me.cmbBancos.Value = id_prosa
                                If id_prosa = "0002" Then
                                    'If servicioActivo("03") Then
                                    Me.cmbBanco.SelectedValue = id_prosa
                                    'Else
                                    'MsgBox("El servicio de dispersión para Banamex no está activo", MsgBoxStyle.Exclamation, "Dportenis Vale Financiero")
                                    'Me.ebNumTarjeta.Focus()
                                    'End If
                                Else
                                    Dim v_tarjeta As String = Me.txtNumTarjeta.Text
                                    Me.cmbServicio.SelectedValue = "04"
                                    'If servicioActivo("12") Then
                                    Me.cmbBanco.SelectedValue = id_prosa
                                    Me.txtNumTarjeta.Text = v_tarjeta
                                    'Else
                                    '   MsgBox("El servicio de dispersión para Bancomer no está activo", MsgBoxStyle.Exclamation, "Dportenis Vale Financiero")
                                    '  Me.ebNumTarjeta.Focus()
                                    'End If
                                End If
                            Else
                                Dim v_tarjeta As String = Me.txtNumTarjeta.Text
                                If id_prosa = "0002" Then
                                    Me.cmbServicio.SelectedValue = "03"
                                Else
                                    Me.cmbServicio.SelectedValue = "04"
                                End If
                                'Me.cmbBancos.Value = "Banamex"
                                Me.cmbBanco.SelectedValue = id_prosa
                                Me.txtNumTarjeta.Text = v_tarjeta
                                'ebNumTarjeta_Validating(sender, e)
                            End If
                        ElseIf id_prosa = "9973" Or id_prosa = "09973" Then
                            If Me.cmbServicio.SelectedValue = "09" Then
                                Me.cmbBanco.SelectedValue = id_prosa
                            Else
                                Dim v_tarjeta As String = Me.txtNumTarjeta.Text
                                Me.cmbServicio.SelectedValue = "09"
                                'Me.cmbServicio.Value = "03"
                                Me.cmbBanco.SelectedValue = id_prosa
                                Me.txtNumTarjeta.Text = v_tarjeta
                                'ebNumTarjeta_Validating(sender, e)
                            End If
                        Else
                            If Me.cmbServicio.SelectedValue = "04" Then
                                Me.cmbBanco.SelectedValue = id_prosa
                            Else
                                Dim v_tarjeta As String = Me.txtNumTarjeta.Text
                                Me.cmbServicio.SelectedValue = "04"
                                'Me.cmbServicio.Value = "03"
                                Me.cmbBanco.SelectedValue = id_prosa
                                Me.txtNumTarjeta.Text = v_tarjeta
                                'ebNumTarjeta_Validating(sender, e)
                            End If
                        End If
                    End If
                End If

            End If

        Catch ex As Exception
        End Try

        'Me.txtCelular.Focus()
    End Sub

    Private Sub txtNumTarjeta_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumTarjeta.KeyPress
        ValidarNumeros(e)
    End Sub

    Private Sub txtCuenta_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCuenta.KeyPress
        ValidarNumeros(e)
    End Sub

    Private Sub txtCelular_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        ValidarNumeros(e)
    End Sub

    Private Sub frmServicioDispersion_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Enter

    End Sub

    Private Sub frmServicioDispersion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmServicioDispersion_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If Me.Termino = False Then
            If MessageBox.Show("¿Esta seguro de cancelar la operación de dispersión?", "Dportenis PRO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Dispersion.EstatusDisp = "Rechazado"
                Dispersion.Save()
                Me.DialogResult = DialogResult.Cancel
            Else
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub txtNumTarjeta_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNumTarjeta.KeyDown

    End Sub

#End Region

#Region "Servicios TOKA"

    Private Function DispersionTOKA(ByVal DPVale As String, ByVal NombreCliente As String, ByVal NumTarjeta As String, ByVal Monto As Decimal) As Boolean

        Dim bResult As Boolean = False

        Try

            '-------------------------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 20/10/2017: Validamos si está activa la config de automatizacion de TOKA y que sera servicio TOKA
            '-------------------------------------------------------------------------------------------------------------------------------
            If oConfigCierreFI.ActivarToka AndAlso Me.cmbServicio.SelectedValue = "09" Then
                '-------------------------------------------------------------------------------------------------------------------------------

                'llamado a web service toka
                Dim oToka As New ProcesosToka()
                Dim responses As Dictionary(Of String, Object)
                Dim clientNombres() As String = NombreCliente.Split(" ")
                '---------------------------------------------------------------------------------------------------------------------
                ' FLIZARRAGA 20/10/2017: Enviamos en el ID del servicio asignar el Folio de DPVale
                '---------------------------------------------------------------------------------------------------------------------
                responses = oToka.Asignar(NumTarjeta, clientNombres(2), clientNombres(0), clientNombres(1), DPVale) 'Me.DistribuidorID)
                '---------------------------------------------------------------------------------------------------------------------
                If Not responses Is Nothing Then
                    'Dim result As Dictionary(Of String, Object)
                    'result = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(responses("Result").ToString)
                    'Dim response As Dictionary(Of String, Object)
                    'response = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(result("Data").ToString)
                    TransaccionLogToka(Date.Now.ToString("dd/MM/yyyy") & "," & NumTarjeta & "," & NombreCliente &
                                               "," & DPVale & "," & Monto & "," & oAppContext.Security.CurrentUser.Name & "," & oAppContext.ApplicationConfiguration.Plaza &
                                               "," & oAppContext.ApplicationConfiguration.Almacen & ",Asignacion," & responses("Result"))

                    Select Case responses("Result")

                        Case "OK"
                            Dim responses2 As Dictionary(Of String, Object)
                            responses2 = oToka.Dispersar(NumTarjeta, Monto) 'CDbl(Me.cmbMonto.Text))

                            If Not responses2 Is Nothing Then
                                'Dim results As Dictionary(Of String, Object)
                                'results = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(responses2("Result").ToString)
                                'Dim response2 As Dictionary(Of String, Object)
                                'response2 = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(results("Data").ToString)

                                TransaccionLogToka(Date.Now.ToString("dd/MM/yyyy") & "," & NumTarjeta & "," & NombreCliente &
                                               "," & DPVale & "," & Monto & "," & oAppContext.Security.CurrentUser.Name & "," & oAppContext.ApplicationConfiguration.Plaza &
                                               "," & oAppContext.ApplicationConfiguration.Almacen & ",Dispersion," & responses2("Result"))

                                Select Case responses2("Result")
                                    Case "OK"
                                        'MessageBox.Show("El movimiento se ha realizado con éxito.", "DPVale Financiero", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                        bResult = True
                                    Case "-1"
                                        MessageBox.Show("La tarjeta no se encuentra activa.", "DPVale Financiero", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                        bResult = False
                                    Case "-2"
                                        MessageBox.Show("Error comunicación SQL en los servicios de Club DP. Contacte a soporte.", "DPVale Financiero", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                        bResult = False
                                    Case "-3"
                                        MessageBox.Show("El monto a dispersar es mayor a 5,100, contacte a soporte.", "DPVale Financiero", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                        bResult = False
                                    Case "-4"
                                        MessageBox.Show("No se puede dispersar más de una vez a la misma tarjeta.", "DPVale Financiero", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                        bResult = False
                                    Case "-5"
                                        MessageBox.Show("La tarjeta no existe. Contacte a soporte", "DPVale Financiero", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                        bResult = False
                                    Case "-10"
                                        MessageBox.Show("Error de autenticación en los servicios de Club DP. Contacte a soporte.", "DPVale Financiero", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                        bResult = False
                                    Case "-20"
                                        MessageBox.Show("Error de comunicación con los servicios de Club DP. Contacte a soporte.", "DPVale Financiero", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                        bResult = False
                                    Case Else
                                        MessageBox.Show("Error desconocido con los servicios de Club BP. Contacte a soporte.", "DPVale Financiero", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                        bResult = False
                                End Select
                            End If
                        Case "-1"
                            MessageBox.Show("La tarjeta no se encuentra activa. Contacte a soporte.", "DPVale Financiero", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            bResult = False
                        Case "-2"
                            MessageBox.Show("Error en la Actualización en los servicios de Club DP. Contacte a soporte.", "DPVale Financiero", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            bResult = False
                        Case "-5"
                            MessageBox.Show("La tarjeta no existe. Contacte a soporte.", "DPVale Financiero", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            bResult = False
                        Case "-10"
                            MessageBox.Show("'Error de autenticación con los servicios de Club DP. Contacte a soporte.", "DPVale Financiero", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            bResult = False
                        Case "-20"
                            MessageBox.Show("Error de comunicación con los servicios de Club DP. Contacte a soporte.", "DPVale Financiero", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            bResult = False
                        Case Else
                            MessageBox.Show("Error desconocido con los servicios de Club BP. Contacte a soporte.", "DPVale Financiero", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            bResult = False
                    End Select
                Else
                    MessageBox.Show("Error de comunicación con los servicios de Club DP. Contacte a soporte.", "DPVale Financiero", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    bResult = False
                End If
            Else
                bResult = True
            End If

        Catch ex As Exception
            MessageBox.Show("Ocurrio un error al dispersar el Prestamo en Club DP. Contacte a soporte.", "DPVale Financiero", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            EscribeLog(ex.ToString, "Ocurrio un error al asignar/dispersar el prestamo en los servicios de TOKA.")
            bResult = False
        End Try

        Return bResult

    End Function

#End Region

#Region "Dispersion Expres"

    '---------------------------------------------------------------------------------------------------------------------
    ' FLIZARRAGA 20/10/2017: Funcion que valida si ya cuenta con un prestamo anterior (no aplica TOKA) para determinar si es expres
    '---------------------------------------------------------------------------------------------------------------------
    Private Function ValidaPrestamoAnterior() As Boolean

        Dim Result As Boolean = False
        Dim Valor As String = String.Empty

        '---------------------------------------------------------------------------------------------------------------------
        ' Obtenemos el valor a buscar en base a los servicios
        '---------------------------------------------------------------------------------------------------------------------
        Select Case Me.cmbServicio.SelectedValue
            Case "01", "10" ' Cuenta (ServicioId 01 de Banamex y ServicioId 10 de Bancomer)
                Valor = Me.txtCuenta.Text
            Case "02" ' Celular (ServicioId 02 de Banamex)
                Valor = Me.txtCelular.UnmaskedText.Trim()
            Case "03", "12", "04", "11" ' Tarjeta (ServicioId 03 de Banamex y ServicioId 12 de Bancomer) y Tarjeta Interbancaria (ServicioId 04 de Banamex y ServicioId 11 de Bancomer
                Valor = Me.txtNumTarjeta.Text
            Case "05" ' Clabe (ServicioId 05 de Banamex)
                Valor = Me.txtClabe.Text
            Case Else ' NO APLICA PARA OTROS SERVICIOS
                Return False
                Exit Function
        End Select

        '---------------------------------------------------------------------------------------------------------------------
        ' Ejecutamos el SP que realiza la validacion en la BD
        '---------------------------------------------------------------------------------------------------------------------
        If oDpvFMgr.ValidaPrestamoAnteriorIFE(Me.Dispersion.IFE, Me.cmbServicio.SelectedValue, Valor) Then
            'If oDpvFMgr.ValidaPrestamoAnterior(NombreClienteDispersion(Me.Dispersion.NombreCliente), Me.cmbServicio.SelectedValue, Valor) Then
            Result = True
        End If

        Return Result

    End Function

    '----------------------------------------------------------------------------------------------------------
    ' FLIZARRAGA 20/10/2017: Formatea el nombre del cliente para los datos del archivo de dispersion
    '----------------------------------------------------------------------------------------------------------
    Private Function NombreClienteDispersion(ByVal NombreSAP As String) As String
        Dim Nombres() As String = NombreSAP.Split(" ")
        Dim ApellidoP, ApellidoM As String
        Dim NombreSA As String
        If Nombres.Length > 1 Then
            ApellidoP = ""
            ApellidoM = ""
            For Each Nombre As String In Nombres
                If ApellidoP Is String.Empty Then
                    ApellidoP = Nombre.TrimEnd
                ElseIf ApellidoM Is String.Empty Then
                    ApellidoM = Nombre.TrimEnd
                Else
                    NombreSA &= Nombre.TrimEnd
                End If
            Next

            '--------------------------------------------------------------------
            ' FLIZARRAGA 20/10/2017: Quitamos signos de puntuacion.
            '--------------------------------------------------------------------
            Return QuitarSignos(NombreSA.TrimEnd & "," & ApellidoP & "/" & ApellidoM)
        Else

            '--------------------------------------------------------------------
            ' FLIZARRAGA 20/10/2017: Quitamos signos de puntuacion.
            '--------------------------------------------------------------------
            Return QuitarSignos(NombreSAP)
        End If
    End Function

    '--------------------------------------------------------------------
    ' FLIZARRAGA 20/10/2017: Funcion para quitar signos de puntuacion.
    '--------------------------------------------------------------------
    Private Function QuitarSignos(ByVal texto As String) As String
        Dim consignos As String = "áàäéèëíìïóòöúùuñÁÀÄÉÈËÍÌÏÓÒÖÚÙÜÑçÇ|"
        Dim sinsignos As String = "aaaeeeiiiooouuunAAAEEEIIIOOOUUUNcC|"
        For v As Integer = 0 To sinsignos.Length - 1
            Dim i As String = consignos.Substring(v, 1)
            Dim j As String = sinsignos.Substring(v, 1)
            texto = texto.Replace(i, j)
        Next
        Return texto
    End Function

    Private Function GuardarDatosArchivo(ByVal SecFile As Integer, ByVal NoCuenta As String, _
                                  ByVal Fecha As Date, ByVal Importe As Decimal, ByVal Tipo As Integer, _
                                  ByVal AltaTarjeta As Boolean, ByVal NoIFE As String, ByVal Banco As String, _
                                  ByVal Celular As String, ByVal CompañiaCelular As String, ByVal CLABE As String, ByVal Transfer As Boolean, _
                                  ByVal NumeroTarjeta As String, ByVal ServicioID As String, ByVal NombreCliente As String, ByVal Codigo As String, Optional ByVal benef As String = "") As Boolean
        Dim valido As Boolean = False
        Dim strRegError As String
        If Me.Reproceso = False Then
            oDPVF = oDpvFMgr.CreateDispersion()
            oDPVF.FechaRegistro = DateTime.Now
        Else
            oDPVF = oDpvFMgr.LoadDpvFinancieroDispersion(oAppContext.ApplicationConfiguration.Almacen, Dispersion.TransactionId, Dispersion.NoTarjeta)
        End If

        oDPVF.SecuencialFile = SecFile
        oDPVF.NoCuentaAbono = NoCuenta
        oDPVF.CodPlaza = oAppSAPConfig.Plaza
        oDPVF.Fecha = Fecha
        oDPVF.Importe = Importe
        oDPVF.Tipo = Tipo
        oDPVF.CodAlmacen = oAppContext.ApplicationConfiguration.Almacen
        oDPVF.AltaTarjeta = AltaTarjeta
        oDPVF.NumeroIFE = NoIFE
        '-------------------------------------------------------------------------------------------------------------------------------
        'FLIZARRAGA 23/10/2017: Validamos si está activa la config de automatizacion de TOKA y que sera servicio TOKA
        '-------------------------------------------------------------------------------------------------------------------------------
        If oConfigCierreFI.ActivarToka Then
            If CStr(Me.cmbServicio.SelectedValue).Trim() = "09" Then
                oDPVF.Dispersion = 1
            Else
                oDPVF.Dispersion = 0
            End If
        Else
            oDPVF.Dispersion = 0
        End If

        '-----------------------------------------------------------------------------------
        ' FLIZARRAGA 23/10/2017: Campos nuevos para Servicios Financieros
        '-----------------------------------------------------------------------------------
        If Banco = String.Empty Then
            Me.BancoDefault(Banco)
        End If
        oDPVF.Banco = Banco

        '-----------------------------------------------------------------------------------
        ' FLIZARRAGA 23/10/2017: Validamos que si no es servicio de celular (transfer o no),
        '                     ponga el numero de celular de confirmacion del cliente
        '-----------------------------------------------------------------------------------
        If Celular.Trim = String.Empty Then
            Celular = Me.NumCelular.Trim
        End If
        '-----------------------------------------------------------------------------------
        oDPVF.Celular = Celular
        oDPVF.CompañiaCelular = CompañiaCelular
        oDPVF.CLABE = CLABE
        oDPVF.Transfer = Transfer
        oDPVF.NumeroTarjeta = NumeroTarjeta
        oDPVF.ServicioID = ServicioID
        oDPVF.NombreCliente = NombreCliente.ToUpper()
        'oDPVF.NombreCliente = NombreClienteDispersion(NombreCliente.ToUpper)
        oDPVF.AccountNumber = Dispersion.AccountNumber
        oDPVF.NoColaborador = Dispersion.CodVendedor
        oDPVF.Microcredito = True
        oDPVF.PlazoMicrocredito = Dispersion.PlazoDisp
        oDPVF.ClubDP = Dispersion.NoTarjeta
        oDPVF.TransactionId = Dispersion.TransactionId
        If Me.Reproceso Then
            oDPVF.Fecha = Fecha
            oDPVF.FechaDispersion = Fecha
            oDPVF.Dispersion = 0
        End If
        '-----------------------------------------------------------------------------------
        ' FLIZARRAGA 23/10/2017: Si es Orden de pago, no se pone el codigo del banco
        '-----------------------------------------------------------------------------------
        If CStr(Me.cmbServicio.SelectedValue).Trim() <> "07" Then
            oDPVF.Codigo = Codigo
        End If

        '-----------------------------------------------------------------------------------
        ' FLIZARRAGA 23/10/2017: Campo CodigoSeguridad nuevo para Servicio de Celular
        '-----------------------------------------------------------------------------------
        oDPVF.CodigoSeguridad = GenerarCodigoSeguridad()
        oDPVF.Alta = False

        '-----------------------------------------------------------------------------------
        ' FLIZARRAGA 23/10/2017: Cachamos el error para mostrarlo y guardarlo
        '-----------------------------------------------------------------------------------
        Try
            valido = oDpvFMgr.SaveDPVFinancieroDispersion(oDPVF)
        Catch ex As Exception
            Try
                '-----------------------------------------------------------------------------------
                ' FLIZARRAGA 23/10/2017 Reintentamos, si marca error de nuevo, ahora si lo guardamos
                '-----------------------------------------------------------------------------------
                Thread.Sleep(5000) 'Esperamos 5 segundos
                valido = oDpvFMgr.SaveDPVFinancieroDispersion(oDPVF)
            Catch ex1 As Exception
                Dispersion.EstatusDisp = "Rechazado"
                Dispersion.Save()
                strRegError = ObtenerRegistroError(oDPVF)
                valido = False
                Throw ex1
            End Try
        End Try
        Dispersion.ServicioId = ServicioID
        Dispersion.Banco = Banco
        Dispersion.EstatusDisp = "Solicitado"
        Dispersion.NoServicio = GetNoServicioDispersion()
        If Me.Reproceso Then
            Dispersion.FechaRep = Fecha
            Dispersion.FechaDispConf = Fecha
            Dispersion.UsuarioRep = Dispersion.CodVendedor
            Dispersion.IPReproceso = System.Net.Dns.GetHostByName(System.Net.Dns.GetHostName()).AddressList(0).ToString()
            Dispersion.Save()
            Dispersion.SaveHistorial()
        Else
            Dispersion.Save()
        End If
        Me.VoucherInfo("NoTarjeta") = Dispersion.NoServicio
        Me.VoucherInfo("Banco") = CStr(cmbBanco.Text.Trim())
        Me.VoucherInfo("HoraDispersion") = GetHoraDisposicion(oDPVF.FechaRegistro, oDPVF.Fecha, oDPVF.Tipo)
        Dim oOtrosPagos As New OtrosPagos
        oOtrosPagos.ImprimirVoucherMicrocredito(Me.VoucherInfo, "VTA", False, False)
        oOtrosPagos.ImprimirVoucherMicrocredito(Me.VoucherInfo, "VTA", True, False)
        If MessageBox.Show("¿Deseas Reimprimir el ticket?", "Dportenis PRO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            oOtrosPagos.ImprimirVoucherMicrocredito(Me.VoucherInfo, "VTA", False, False)
            oOtrosPagos.ImprimirVoucherMicrocredito(Me.VoucherInfo, "VTA", True, False)
        End If
        oDPVF = Nothing
        Return valido
    End Function

    '----------------------------------------------------------------------------------------------------------
    ' FLIZARRAGA 23/10/2017: Funcion para generar el codigo de seguridad del servicio de celular
    '----------------------------------------------------------------------------------------------------------
    Private Function GenerarCodigoSeguridad() As String
        Dim Codigo As String = "0"

        '----------------------------------------------------------------------------------------------------------
        ' Si el servicio es de Celular(06), calculamos el codigo de seguridad
        '----------------------------------------------------------------------------------------------------------
        If CStr(Me.cmbServicio.SelectedValue).Trim() = "06" Then
            Codigo = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 4)
        End If
        Return Codigo.ToString
    End Function

    '-----------------------------------------------------------------------------------
    ' JNAVA (13.09.2016): Funcion para obtener el registro que marcó error en SQL
    '-----------------------------------------------------------------------------------
    Private Function ObtenerRegistroError(ByVal oDPFV As DPVFinancieroDispersion) As String
        Dim strReturn As String = String.Empty

        strReturn = "Registro que presentó el error: " & vbCrLf & vbCrLf & _
                    "IDCliente: " & oDPVF.IDCliente & vbCrLf & _
                    "SecFile: " & oDPVF.SecuencialFile & vbCrLf & _
                    "Importe: " & oDPVF.Importe & vbCrLf & _
                    "Intereses: " & oDPVF.Intereses & vbCrLf & _
                    "NoCuenta: " & oDPVF.NoCuentaAbono & vbCrLf & _
                    "Fecha: " & oDPVF.Fecha & vbCrLf & _
                    "DPVale: " & oDPVF.NoDPVale & vbCrLf & _
                    "Tipo: " & oDPVF.Tipo & vbCrLf & _
                    "CodAlmacen: " & oDPVF.CodAlmacen & vbCrLf & _
                    "FolioSAP: " & oDPVF.NumFactura & vbCrLf & _
                    "IDAsociado: " & oDPVF.Asociado & vbCrLf & _
                    "CodPlaza: " & oDPVF.CodPlaza & vbCrLf & _
                    "Oficina: " & oDPVF.Oficina & vbCrLf & _
                    "AltaTarjeta: " & oDPVF.AltaTarjeta & vbCrLf & _
                    "NoIFE: " & oDPVF.NumeroIFE & vbCrLf & _
                    "FolioFISAPInt: " & oDPVF.FolioFISAPIntereses & vbCrLf & _
                    "FolioFISAPMonto: " & oDPVF.FolioFISAPMonto & vbCrLf & _
                    "Usuario: " & oAppContext.Security.CurrentUser.Name & vbCrLf & _
                    "Banco: " & oDPVF.Banco & vbCrLf & _
                    "Celular: " & oDPVF.Celular & vbCrLf & _
                    "CompañiaCelular: " & oDPVF.CompañiaCelular & vbCrLf & _
                    "Clabe: " & oDPVF.CLABE & vbCrLf & _
                    "Transfer: " & oDPVF.Transfer & vbCrLf & _
                    "NumeroTarjeta: " & oDPVF.NumeroTarjeta & vbCrLf & _
                    "ServicioId: " & oDPVF.ServicioID & vbCrLf & _
                    "Codigo: " & oDPVF.Codigo & vbCrLf & _
                    "NombreCliente: " & oDPVF.NombreCliente & vbCrLf & _
                    "CodigoSeguridad: " & oDPVF.CodigoSeguridad

        Return strReturn
    End Function

    Public Function GetNoServicioDispersion() As String
        Dim NoServicio As String = ""
        Select Case CStr(Me.cmbServicio.SelectedValue)
            Case "01" ' CUENTA
                '-------------------------------------------------------------------------------
                'FLIZARRAGA 17/10/2017: MISMO BANCO
                '-------------------------------------------------------------------------------
                NoServicio = txtCuenta.Text.Trim()
            Case "02" 'CELULAR Transfer
                NoServicio = txtCelular.Text.Trim()
            Case "03" 'TARJETA
                '-------------------------------------------------------------------------------
                'FLIZARRAGA 17/10/2017: MISMO BANCO
                '-------------------------------------------------------------------------------
                NoServicio = txtNumTarjeta.Text.Trim()
            Case "04" 'TARJETA Interbancaria
                NoServicio = txtNumTarjeta.Text.Trim()
            Case "05" 'CLABE 
                NoServicio = txtClabe.Text.Trim()
            Case "06" 'CELULAR
                NoServicio = txtCelular.Text.Trim()
            Case "07" 'FLIZARRAGA 17/10/2017: ORDEN DE PAGO
                NoServicio = ""
            Case "09" 'FLIZARRAGA 17/10/2017: TOKA 
                NoServicio = txtNumTarjeta.Text.Trim()
        End Select
        Return NoServicio
    End Function

    Private Sub SetServicioDispersion(ByVal oDPVF As DPVFinancieroDispersion)
        Me.cmbServicio.SelectedValue = oDPVF.ServicioID
        Me.cmbBanco.SelectedValue = oDPVF.Banco
        Me.txtCuenta.Text = oDPVF.NoCuentaAbono
        Me.txtClabe.Text = oDPVF.CLABE
        Me.txtNumTarjeta.Text = oDPVF.NumeroTarjeta
        Me.cmbCompania.SelectedValue = oDPVF.CompañiaCelular
        Me.txtCelular.Text = oDPVF.Celular
        Me.chkTransfer.Checked = oDPVF.Transfer
        If Not oDPVF.ServicioID Is Nothing Then
            If oDPVF.ServicioID.Trim() <> "" Then
                'cmbServicio.Enabled = False
                dtServicios = FillServiciosByCodigoBanco(oDPVF.ServicioID)
                Me.cmbServicio.DataSource = dtServicios
                If oDPVF.ServicioID.Trim() = "04" Then
                    dtBancos = FiltrarBanco("9973", dtBancos)
                    Me.cmbBanco.DataSource = dtBancos
                End If
            End If
        End If
        If Not oDPVF.Banco Is Nothing Then
            If oDPVF.Banco.Trim() <> "" Then
                Dim rows() As DataRow = dtBancos.Select("Banco='" & oDPVF.Banco & "'")
                If rows.Length > 0 Then
                    cmbBanco.SelectedValue = rows(0)("Codigo")
                End If
            End If
        End If
    End Sub

    Public Sub ClearFields()
        Me.cmbServicio.Text = String.Empty
        Me.cmbServicio.SelectedValue = Nothing
        HabilitarCamposServicios(False)
        TipoPrestamo = 1
    End Sub

#End Region

#Region "Mejoras Microcredito"

    Private Function FiltrarBanco(ByVal strBanco As String, ByVal dtFP As DataTable) As DataTable
        Dim dtTemp As DataTable = dtFP.Clone
        Dim oRow As DataRow

        For Each oRow In dtFP.Rows
            If InStr(strBanco.Trim.ToUpper, CStr(oRow!Codigo).Trim.ToUpper) <= 0 Then
                dtTemp.ImportRow(oRow)
            End If
        Next

        Return dtTemp

    End Function

    Public Function GetHoraDisposicion(ByVal Fecha As DateTime, ByVal FechaDispersion As DateTime, ByVal Tipo As String) As Nullable(Of Date)
        Dim hora As Nullable(Of DateTime)
        'Dim hora As DateTime = Nothing
        If Fecha.Date = FechaDispersion.Date Then
            Select Case Tipo.Trim()
                Case "1"
                    hora = Fecha.AddHours(3)
                Case "5"
                    hora = Fecha.AddMinutes(30)
            End Select
        End If
        Return hora
    End Function

#End Region

End Class