Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU

Public Class rptVoucherDPCard
    Inherits DataDynamics.ActiveReports.ActiveReport
    Public Sub New(ByVal Datos As Hashtable, ByVal TipoVoucher As String, ByVal EsCopia As Boolean, ByVal EsCancelacion As Boolean)
        MyBase.New()
        InitializeComponent()

        '-----------------------------------------------------------
        'JNAVA (22.01.2015): Mostramos Fecha y hora
        '-----------------------------------------------------------
        Me.lblFecha.Text = "Fecha: " & Date.Today.ToShortDateString
        Me.lblHora.Text = "Hora: " & Format(Date.Now, "HH:mm:ss")

        '---------------------------------------------------------------------------------
        'JNAVA (20.02.2015): Mostramos datos Principales
        '---------------------------------------------------------------------------------
        'JNAVA (18.02.2015): Datos de Tienda (Numero tienda, Nombre, Direccion y Telefono
        '---------------------------------------------------------------------------------
        Me.txtNumTienda.Text = CStr(Datos("NoTienda")).Replace("D3", "")
        If (Me.txtNumTienda.Text.Trim.Length > 3) Then
            Dim tienda As String = Me.txtNumTienda.Text.Trim
            Me.txtNumTienda.Text = tienda.Substring(tienda.Length - 3)
        End If
        Dim oCatalogoAlmacenesMgr As New CatalogoAlmacenesManager(oAppContext)
        Dim oAlmacen As Almacen
        Dim oSAPMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        oAlmacen = oCatalogoAlmacenesMgr.Load(oSAPMgr.REad_centros) '"2" & oAppContext.ApplicationConfiguration.Almacen)
        Me.txtTienda.Text = oAlmacen.Descripcion & vbCrLf & _
                            oAlmacen.DireccionCalle & vbCrLf & _
                            "C.P." & oAlmacen.DireccionCP & _
                            " TEL. " & oAlmacen.TelefonoNum & vbCrLf & _
                            "R.F.C. CDP-950126-9M5" & vbCrLf & _
                            oAlmacen.DireccionCiudad & ", " & oAlmacen.DireccionEstado
        '---------------------------------------------------------------------------------
        Me.txtNumCaja.Text = CStr(Datos("NoCaja")).Trim
        Me.txtVendedor.Text = CStr(Datos("Vendedor"))
        Me.txtTarjeta.Text = "**** **** ****" & CStr(Datos("Tarjeta")).Substring(12, 4)
        Me.txtNombre.Text = CStr(Datos("TarjetaHabiente"))
        '---------------------------------------------------------------------------------

        '-----------------------------------------------------------
        'JNAVA (12.03.2015): Si es cancelacion monto en Negativo
        '-----------------------------------------------------------
        If EsCancelacion Then
            '---------------------------------------------------------------------------
            ' JNAVA (13.03.2015): Si es cancelacion y no viene el nombre, no mostrarlo
            '---------------------------------------------------------------------------
            If CStr(Datos("TarjetaHabiente")) = String.Empty Then
                Me.lblNombre.Visible = False
                Me.txtNombre.Visible = False
            End If
            '---------------------------------------------------------------------------
            Me.txtMonto.Text = "-" & Format(CDec(Datos("Monto")), "c")
        Else
            Me.txtMonto.Text = Format(CDec(Datos("Monto")), "c")
        End If

        Me.txtlinea.Text = CStr(Datos("Linea"))

        '-----------------------------------------------------------
        'JNAVA (12.03.2015): Consecutivo POS
        '-----------------------------------------------------------
        Me.txtConsecutivoPOS.Text = CStr(Datos("ConsecutivoPOS"))

        '---------------------------------------------------------------------------------
        'JNAVA (22.01.2015): Si NO es Voucher de Venta no muestra la leyenda del pagare
        '----------------------------------------------------------------------------------
        If TipoVoucher = "PGO" Then
            '----------------------------------------------------------------------------------
            'JNAVA (24.02.2015): Si es Cancelacion Cambiamos la leyenda
            '----------------------------------------------------------------------------------
            If Not EsCancelacion Then
                Me.lblTitulo.Text = "Recibo de Pago"
            Else
                Me.lblTitulo.Text = "Recibo de Cancelación de Pago"
            End If
            Me.lblPagare0.Visible = False
            Me.lblPagare1.Visible = False
            Me.txtOrdenDe.Visible = False
            Me.lblPagare2.Visible = False
            Me.txtTarjetaCred.Visible = False
            Me.lblPagare3.Visible = False
            Me.lblOriginalCopia.Visible = False
            Me.lblMontoMensual.Visible = False
            Me.txtMontoMensual.Visible = False
            'Me.txtFirma.Visible = False
            'Me.Line1.Visible = False

        ElseIf TipoVoucher = "VTA" Then

            '---------------------------------------------------------------------------------------------
            'FLIZARRAGA 19/11/2015: Valida si el voucher es copia para poner el texto de original o copia
            '---------------------------------------------------------------------------------------------
            Dim montoMensual As Decimal = CDec(Datos("Monto"))
            Dim meses As Integer = CInt(Datos("Meses"))
            If meses > 0 Then
                montoMensual = montoMensual / meses
            End If
            Me.txtMontoMensual.Text = Format(montoMensual, "c")
            Me.lblOriginalCopia.Visible = True
            If meses <> 0 Then
                Me.lblMontoMensual.Visible = False
                Me.txtMontoMensual.Visible = False
                'Me.lblMontoMensual.Visible = True
                'Me.txtMontoMensual.Visible = True
            Else
                Me.lblMontoMensual.Visible = False
                Me.txtMontoMensual.Visible = False
            End If
            If EsCopia Then
                Me.lblOriginalCopia.Text = "COPIA"
            Else
                Me.lblOriginalCopia.Text = "ORIGINAL"
            End If

            '----------------------------------------------------------------------------------
            'JNAVA (24.02.2015): Si es Cancelacion Cambiamos la leyenda
            '----------------------------------------------------------------------------------
            If Not EsCancelacion Then
                Me.lblTitulo.Text = "Recibo de Compra"
                '----------------------------------------------------------------------------------
                'JNAVA (23.06.2015): Mostramos la promocion de DPCARD Credit solo si es de venta
                '----------------------------------------------------------------------------------
                Me.txtPromocion.Text = CStr(Datos("Promocion"))
                Me.txtPromocion.Visible = True
            Else

                Me.lblTitulo.Text = "Recibo de Cancelación de Compra"
                '-----------------------------------------------------------
                'JNAVA (12.03.2015): Si es cancelacion no se muestra leyenda
                '-----------------------------------------------------------
                Me.lblPagare0.Visible = False
                Me.lblPagare1.Visible = False
                Me.txtOrdenDe.Visible = False
                Me.lblPagare2.Visible = False
                Me.txtTarjetaCred.Visible = False
                Me.lblPagare3.Visible = False

                '-------------------------------------------------------------------------------------------------
                'JNAVA (01.06.2015): Se comento por que pidieron que no se mostara nunca ese dato
                '-------------------------------------------------------------------------------------------------
                ''-------------------------------------------------------------------------------------------------
                ''JNAVA (18.02.2015): Mostramos y seteamos el campo de promocion (PM) para la cancelacion de venta
                ''-------------------------------------------------------------------------------------------------
                'If Datos.Contains("PM") Then
                '    txtPM.Text = CStr(Datos("PM"))
                '    Me.lblPM.Visible = True
                '    Me.txtPM.Visible = True
                'End If

            End If
            'Me.txtOrdenDe.Text = "Comercial DPortenis S.A. de C.V."
            Me.txtOrdenDe.Text = "FUTURO ABC S.A.P.I. DE C.V. SOFOM ENR"
            Me.txtTarjetaCred.Text = "TARJETA DE CREDITO DPCARD"
            'Me.txtTarjetaCred.Text = "DP CARD"
        End If

        '---------------------------------------------------------------------------------
        'JNAVA (18.02.2015): Firma y Tarjetahabiente
        '---------------------------------------------------------------------------------
        Me.txtFirma.Text = Me.txtNombre.Text

    End Sub
#Region "ActiveReports Designer generated code"
    Private WithEvents PageHeader As PageHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents PageFooter As PageFooter = Nothing
	Private txtFirma As TextBox = Nothing
	Private lblHora As Label = Nothing
	Private lblFecha As Label = Nothing
	Private lblTitulo As Label = Nothing
	Private lblNombre As Label = Nothing
	Private Label4 As Label = Nothing
	Private txtMonto As TextBox = Nothing
	Private txtlinea As TextBox = Nothing
	Private txtTienda As TextBox = Nothing
	Private txtNumCaja As TextBox = Nothing
	Private Label8 As Label = Nothing
	Private Label9 As Label = Nothing
	Private txtVendedor As TextBox = Nothing
	Private txtTarjeta As TextBox = Nothing
	Private Label10 As Label = Nothing
	Private lblPagare0 As Label = Nothing
	Private lblPagare1 As Label = Nothing
	Private txtOrdenDe As TextBox = Nothing
	Private lblPagare2 As Label = Nothing
	Private txtTarjetaCred As TextBox = Nothing
	Private lblPagare3 As Label = Nothing
	Private txtNombre As TextBox = Nothing
	Private Line1 As Line = Nothing
	Private Label11 As Label = Nothing
	Private txtConsecutivoPOS As TextBox = Nothing
	Private Label12 As Label = Nothing
    Private txtNumTienda As TextBox = Nothing
    Friend WithEvents lblOriginalCopia As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblMontoMensual As DataDynamics.ActiveReports.Label
    Friend WithEvents txtMontoMensual As DataDynamics.ActiveReports.TextBox
	Private txtPromocion As TextBox = Nothing
	Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptVoucherDPCard))
        Me.Detail = New DataDynamics.ActiveReports.Detail()
        Me.PageHeader = New DataDynamics.ActiveReports.PageHeader()
        Me.txtFirma = New DataDynamics.ActiveReports.TextBox()
        Me.lblHora = New DataDynamics.ActiveReports.Label()
        Me.lblFecha = New DataDynamics.ActiveReports.Label()
        Me.lblTitulo = New DataDynamics.ActiveReports.Label()
        Me.lblNombre = New DataDynamics.ActiveReports.Label()
        Me.Label4 = New DataDynamics.ActiveReports.Label()
        Me.txtMonto = New DataDynamics.ActiveReports.TextBox()
        Me.txtlinea = New DataDynamics.ActiveReports.TextBox()
        Me.txtTienda = New DataDynamics.ActiveReports.TextBox()
        Me.txtNumCaja = New DataDynamics.ActiveReports.TextBox()
        Me.Label8 = New DataDynamics.ActiveReports.Label()
        Me.Label9 = New DataDynamics.ActiveReports.Label()
        Me.txtVendedor = New DataDynamics.ActiveReports.TextBox()
        Me.txtTarjeta = New DataDynamics.ActiveReports.TextBox()
        Me.Label10 = New DataDynamics.ActiveReports.Label()
        Me.lblPagare0 = New DataDynamics.ActiveReports.Label()
        Me.lblPagare1 = New DataDynamics.ActiveReports.Label()
        Me.txtOrdenDe = New DataDynamics.ActiveReports.TextBox()
        Me.lblPagare2 = New DataDynamics.ActiveReports.Label()
        Me.txtTarjetaCred = New DataDynamics.ActiveReports.TextBox()
        Me.lblPagare3 = New DataDynamics.ActiveReports.Label()
        Me.txtNombre = New DataDynamics.ActiveReports.TextBox()
        Me.Line1 = New DataDynamics.ActiveReports.Line()
        Me.Label11 = New DataDynamics.ActiveReports.Label()
        Me.txtConsecutivoPOS = New DataDynamics.ActiveReports.TextBox()
        Me.Label12 = New DataDynamics.ActiveReports.Label()
        Me.txtNumTienda = New DataDynamics.ActiveReports.TextBox()
        Me.txtPromocion = New DataDynamics.ActiveReports.TextBox()
        Me.lblOriginalCopia = New DataDynamics.ActiveReports.TextBox()
        Me.lblMontoMensual = New DataDynamics.ActiveReports.Label()
        Me.txtMontoMensual = New DataDynamics.ActiveReports.TextBox()
        Me.PageFooter = New DataDynamics.ActiveReports.PageFooter()
        CType(Me.txtFirma, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblHora, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblNombre, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMonto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtlinea, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTienda, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNumCaja, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtVendedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTarjeta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblPagare0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblPagare1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtOrdenDe, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblPagare2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTarjetaCred, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblPagare3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNombre, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtConsecutivoPOS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNumTienda, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPromocion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblOriginalCopia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblMontoMensual, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMontoMensual, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.ColumnSpacing = 0.0!
        Me.Detail.Height = 0.0!
        Me.Detail.Name = "Detail"
        '
        'PageHeader
        '
        Me.PageHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtFirma, Me.lblHora, Me.lblFecha, Me.lblTitulo, Me.lblNombre, Me.Label4, Me.txtMonto, Me.txtlinea, Me.txtTienda, Me.txtNumCaja, Me.Label8, Me.Label9, Me.txtVendedor, Me.txtTarjeta, Me.Label10, Me.lblPagare0, Me.lblPagare1, Me.txtOrdenDe, Me.lblPagare2, Me.txtTarjetaCred, Me.lblPagare3, Me.txtNombre, Me.Line1, Me.Label11, Me.txtConsecutivoPOS, Me.Label12, Me.txtNumTienda, Me.txtPromocion, Me.lblOriginalCopia, Me.lblMontoMensual, Me.txtMontoMensual})
        Me.PageHeader.Height = 7.906!
        Me.PageHeader.Name = "PageHeader"
        '
        'txtFirma
        '
        Me.txtFirma.Height = 0.1875!
        Me.txtFirma.Left = 0.25!
        Me.txtFirma.Name = "txtFirma"
        Me.txtFirma.Style = "text-align: center; font-size: 8.25pt; font-family: Arial"
        Me.txtFirma.Text = "Nombre"
        Me.txtFirma.Top = 3.819444!
        Me.txtFirma.Width = 2.125!
        '
        'lblHora
        '
        Me.lblHora.Height = 0.2362205!
        Me.lblHora.HyperLink = Nothing
        Me.lblHora.Left = 1.430611!
        Me.lblHora.Name = "lblHora"
        Me.lblHora.Style = "font-family: Tahoma"
        Me.lblHora.Text = "Hora: 16:43"
        Me.lblHora.Top = 0.2947833!
        Me.lblHora.Width = 1.023622!
        '
        'lblFecha
        '
        Me.lblFecha.Height = 0.2362205!
        Me.lblFecha.HyperLink = Nothing
        Me.lblFecha.Left = 0.170768!
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Style = "font-family: Tahoma"
        Me.lblFecha.Text = "Fecha: 25/08/2007"
        Me.lblFecha.Top = 0.2947833!
        Me.lblFecha.Width = 1.259842!
        '
        'lblTitulo
        '
        Me.lblTitulo.Height = 0.2!
        Me.lblTitulo.HyperLink = Nothing
        Me.lblTitulo.Left = 0.0625!
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Style = "text-align: center; font-weight: bold; font-size: 9pt"
        Me.lblTitulo.Text = "Recibo de Compra"
        Me.lblTitulo.Top = 0.0!
        Me.lblTitulo.Width = 2.5!
        '
        'lblNombre
        '
        Me.lblNombre.Height = 0.1875!
        Me.lblNombre.HyperLink = Nothing
        Me.lblNombre.Left = 0.0625!
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Style = "text-align: left; font-weight: bold; font-size: 8.25pt; font-family: Tahoma"
        Me.lblNombre.Text = "Tarjetahabiente:"
        Me.lblNombre.Top = 2.3125!
        Me.lblNombre.Width = 1.0!
        '
        'Label4
        '
        Me.Label4.Height = 0.1875!
        Me.Label4.HyperLink = Nothing
        Me.Label4.Left = 0.0625!
        Me.Label4.Name = "Label4"
        Me.Label4.Style = "text-align: left; font-weight: bold; font-size: 8.25pt; font-family: Tahoma"
        Me.Label4.Text = "Monto:"
        Me.Label4.Top = 2.5625!
        Me.Label4.Width = 1.0!
        '
        'txtMonto
        '
        Me.txtMonto.Height = 0.1875!
        Me.txtMonto.Left = 1.0625!
        Me.txtMonto.Name = "txtMonto"
        Me.txtMonto.Style = "text-align: left; font-size: 8.25pt; font-family: Arial"
        Me.txtMonto.Text = "$0.00"
        Me.txtMonto.Top = 2.5625!
        Me.txtMonto.Width = 1.5!
        '
        'txtlinea
        '
        Me.txtlinea.Height = 0.1875!
        Me.txtlinea.Left = 0.063!
        Me.txtlinea.Name = "txtlinea"
        Me.txtlinea.Style = "text-align: left; font-size: 8.25pt; font-family: Arial"
        Me.txtlinea.Text = "EN LINEA"
        Me.txtlinea.Top = 3.313!
        Me.txtlinea.Width = 2.5!
        '
        'txtTienda
        '
        Me.txtTienda.Height = 0.7410001!
        Me.txtTienda.Left = 0.0625!
        Me.txtTienda.Name = "txtTienda"
        Me.txtTienda.Style = "text-align: center; font-size: 9.75pt; font-family: Arial"
        Me.txtTienda.Text = "000"
        Me.txtTienda.Top = 0.75!
        Me.txtTienda.Width = 2.5!
        '
        'txtNumCaja
        '
        Me.txtNumCaja.Height = 0.1875!
        Me.txtNumCaja.Left = 1.0625!
        Me.txtNumCaja.Name = "txtNumCaja"
        Me.txtNumCaja.Style = "text-align: left; font-size: 8.25pt; font-family: Arial"
        Me.txtNumCaja.Text = "01"
        Me.txtNumCaja.Top = 1.5625!
        Me.txtNumCaja.Width = 0.375!
        '
        'Label8
        '
        Me.Label8.Height = 0.1875!
        Me.Label8.HyperLink = Nothing
        Me.Label8.Left = 0.0625!
        Me.Label8.Name = "Label8"
        Me.Label8.Style = "text-align: left; font-weight: bold; font-size: 8.25pt; font-family: Tahoma"
        Me.Label8.Text = "No. Caja:"
        Me.Label8.Top = 1.5625!
        Me.Label8.Width = 1.0!
        '
        'Label9
        '
        Me.Label9.Height = 0.1875!
        Me.Label9.HyperLink = Nothing
        Me.Label9.Left = 0.0625!
        Me.Label9.Name = "Label9"
        Me.Label9.Style = "text-align: left; font-weight: bold; font-size: 8.25pt; font-family: Tahoma"
        Me.Label9.Text = "Vendedor:"
        Me.Label9.Top = 1.8125!
        Me.Label9.Width = 1.0!
        '
        'txtVendedor
        '
        Me.txtVendedor.Height = 0.1875!
        Me.txtVendedor.Left = 1.0625!
        Me.txtVendedor.Name = "txtVendedor"
        Me.txtVendedor.Style = "text-align: left; font-size: 8.25pt; font-family: Arial"
        Me.txtVendedor.Text = "-"
        Me.txtVendedor.Top = 1.8125!
        Me.txtVendedor.Width = 1.5!
        '
        'txtTarjeta
        '
        Me.txtTarjeta.Height = 0.1875!
        Me.txtTarjeta.Left = 1.0625!
        Me.txtTarjeta.Name = "txtTarjeta"
        Me.txtTarjeta.Style = "text-align: left; font-size: 8.25pt; font-family: Arial"
        Me.txtTarjeta.Text = "-"
        Me.txtTarjeta.Top = 2.0625!
        Me.txtTarjeta.Width = 1.5!
        '
        'Label10
        '
        Me.Label10.Height = 0.1875!
        Me.Label10.HyperLink = Nothing
        Me.Label10.Left = 0.0625!
        Me.Label10.Name = "Label10"
        Me.Label10.Style = "text-align: left; font-weight: bold; font-size: 8.25pt; font-family: Tahoma"
        Me.Label10.Text = "Tarjeta:"
        Me.Label10.Top = 2.0625!
        Me.Label10.Width = 1.0!
        '
        'lblPagare0
        '
        Me.lblPagare0.Height = 0.1875!
        Me.lblPagare0.HyperLink = Nothing
        Me.lblPagare0.Left = 0.062!
        Me.lblPagare0.Name = "lblPagare0"
        Me.lblPagare0.Style = "text-align: center; font-weight: normal; font-size: 8.25pt; font-family: Tahoma"
        Me.lblPagare0.Text = "PAGARE"
        Me.lblPagare0.Top = 4.437!
        Me.lblPagare0.Width = 2.5!
        '
        'lblPagare1
        '
        Me.lblPagare1.Height = 0.3125!
        Me.lblPagare1.HyperLink = Nothing
        Me.lblPagare1.Left = 0.062!
        Me.lblPagare1.Name = "lblPagare1"
        Me.lblPagare1.Style = "text-align: center; font-weight: normal; font-size: 8.25pt; font-family: Tahoma"
        Me.lblPagare1.Text = "Por este pagare me obligo a pagar incondicionalmente a la orden de:"
        Me.lblPagare1.Top = 4.6245!
        Me.lblPagare1.Width = 2.5!
        '
        'txtOrdenDe
        '
        Me.txtOrdenDe.Height = 0.1875!
        Me.txtOrdenDe.Left = 0.062!
        Me.txtOrdenDe.Name = "txtOrdenDe"
        Me.txtOrdenDe.Style = "text-align: center; font-size: 8.25pt; font-family: Tahoma"
        Me.txtOrdenDe.Text = "-"
        Me.txtOrdenDe.Top = 4.937!
        Me.txtOrdenDe.Width = 2.5!
        '
        'lblPagare2
        '
        Me.lblPagare2.Height = 0.625!
        Me.lblPagare2.HyperLink = Nothing
        Me.lblPagare2.Left = 0.062!
        Me.lblPagare2.Name = "lblPagare2"
        Me.lblPagare2.Style = "text-align: center; font-weight: normal; font-size: 8.25pt; font-family: Tahoma"
        Me.lblPagare2.Text = "o sus cesionarios autorizados en sus oficinas o en cualquier otro lugar que se me" & _
    " requiera la cantidad que aparece en el total de este título de disposición, den" & _
    "ominado en la forma de pago "
        Me.lblPagare2.Top = 5.1245!
        Me.lblPagare2.Width = 2.5!
        '
        'txtTarjetaCred
        '
        Me.txtTarjetaCred.Height = 0.1875!
        Me.txtTarjetaCred.Left = 0.062!
        Me.txtTarjetaCred.Name = "txtTarjetaCred"
        Me.txtTarjetaCred.Style = "text-align: center; font-size: 8.25pt; font-family: Tahoma"
        Me.txtTarjetaCred.Text = "TARJETA DE CREDITO -"
        Me.txtTarjetaCred.Top = 5.7495!
        Me.txtTarjetaCred.Width = 2.5!
        '
        'lblPagare3
        '
        Me.lblPagare3.Height = 1.8125!
        Me.lblPagare3.HyperLink = Nothing
        Me.lblPagare3.Left = 0.062!
        Me.lblPagare3.Name = "lblPagare3"
        Me.lblPagare3.Style = "text-align: center; font-weight: normal; font-size: 8.25pt; font-family: Tahoma"
        Me.lblPagare3.Text = resources.GetString("lblPagare3.Text")
        Me.lblPagare3.Top = 5.937!
        Me.lblPagare3.Width = 2.5!
        '
        'txtNombre
        '
        Me.txtNombre.Height = 0.1875!
        Me.txtNombre.Left = 1.0625!
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Style = "text-align: left; font-size: 8.25pt; font-family: Arial"
        Me.txtNombre.Text = "Nombre"
        Me.txtNombre.Top = 2.3125!
        Me.txtNombre.Width = 1.5!
        '
        'Line1
        '
        Me.Line1.Height = 0.0!
        Me.Line1.Left = 0.25!
        Me.Line1.LineWeight = 1.0!
        Me.Line1.Name = "Line1"
        Me.Line1.Top = 3.756944!
        Me.Line1.Width = 2.125!
        Me.Line1.X1 = 2.375!
        Me.Line1.X2 = 0.25!
        Me.Line1.Y1 = 3.756944!
        Me.Line1.Y2 = 3.756944!
        '
        'Label11
        '
        Me.Label11.Height = 0.1875!
        Me.Label11.HyperLink = Nothing
        Me.Label11.Left = 1.5!
        Me.Label11.Name = "Label11"
        Me.Label11.Style = "text-align: left; font-weight: bold; font-size: 8.25pt; font-family: Tahoma"
        Me.Label11.Text = "CM:"
        Me.Label11.Top = 1.5625!
        Me.Label11.Width = 0.3125!
        '
        'txtConsecutivoPOS
        '
        Me.txtConsecutivoPOS.Height = 0.1875!
        Me.txtConsecutivoPOS.Left = 1.8125!
        Me.txtConsecutivoPOS.Name = "txtConsecutivoPOS"
        Me.txtConsecutivoPOS.Style = "text-align: left; font-size: 8.25pt; font-family: Arial"
        Me.txtConsecutivoPOS.Text = "0001"
        Me.txtConsecutivoPOS.Top = 1.5625!
        Me.txtConsecutivoPOS.Width = 0.75!
        '
        'Label12
        '
        Me.Label12.Height = 0.1875!
        Me.Label12.HyperLink = Nothing
        Me.Label12.Left = 0.0625!
        Me.Label12.Name = "Label12"
        Me.Label12.Style = "text-align: left; font-weight: bold; font-size: 8.25pt; font-family: Tahoma"
        Me.Label12.Text = "No. Tienda:"
        Me.Label12.Top = 0.5625!
        Me.Label12.Width = 1.0!
        '
        'txtNumTienda
        '
        Me.txtNumTienda.Height = 0.1875!
        Me.txtNumTienda.Left = 1.0625!
        Me.txtNumTienda.Name = "txtNumTienda"
        Me.txtNumTienda.Style = "text-align: left; font-size: 8.25pt; font-family: Arial"
        Me.txtNumTienda.Text = "01"
        Me.txtNumTienda.Top = 0.5625!
        Me.txtNumTienda.Width = 1.5!
        '
        'txtPromocion
        '
        Me.txtPromocion.Height = 0.1875!
        Me.txtPromocion.Left = 0.0625!
        Me.txtPromocion.Name = "txtPromocion"
        Me.txtPromocion.Style = "ddo-char-set: 1; text-align: center; font-weight: bold; font-size: 8.25pt; font-f" & _
    "amily: Tahoma"
        Me.txtPromocion.Text = "3 Meses sin intereses"
        Me.txtPromocion.Top = 2.8125!
        Me.txtPromocion.Visible = False
        Me.txtPromocion.Width = 2.5!
        '
        'lblOriginalCopia
        '
        Me.lblOriginalCopia.Height = 0.188!
        Me.lblOriginalCopia.Left = 0.115!
        Me.lblOriginalCopia.Name = "lblOriginalCopia"
        Me.lblOriginalCopia.Style = "text-align: center; font-size: 8.25pt; font-family: Arial"
        Me.lblOriginalCopia.Text = "Original"
        Me.lblOriginalCopia.Top = 4.188!
        Me.lblOriginalCopia.Width = 2.438!
        '
        'lblMontoMensual
        '
        Me.lblMontoMensual.Height = 0.1875!
        Me.lblMontoMensual.HyperLink = Nothing
        Me.lblMontoMensual.Left = 0.063!
        Me.lblMontoMensual.Name = "lblMontoMensual"
        Me.lblMontoMensual.Style = "text-align: left; font-weight: bold; font-size: 8.25pt; font-family: Tahoma"
        Me.lblMontoMensual.Text = "Monto:"
        Me.lblMontoMensual.Top = 3.063!
        Me.lblMontoMensual.Width = 1.0!
        '
        'txtMontoMensual
        '
        Me.txtMontoMensual.Height = 0.1875!
        Me.txtMontoMensual.Left = 1.063!
        Me.txtMontoMensual.Name = "txtMontoMensual"
        Me.txtMontoMensual.Style = "text-align: left; font-size: 8.25pt; font-family: Arial"
        Me.txtMontoMensual.Text = "$0.00"
        Me.txtMontoMensual.Top = 3.063!
        Me.txtMontoMensual.Width = 1.5!
        '
        'PageFooter
        '
        Me.PageFooter.Height = 0.0!
        Me.PageFooter.Name = "PageFooter"
        '
        'rptVoucherDPCard
        '
        Me.MasterReport = False
        Me.PageSettings.Margins.Bottom = 0.0!
        Me.PageSettings.Margins.Left = 0.3!
        Me.PageSettings.Margins.Right = 0.0!
        Me.PageSettings.Margins.Top = 0.1!
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 2.625!
        Me.Sections.Add(Me.PageHeader)
        Me.Sections.Add(Me.Detail)
        Me.Sections.Add(Me.PageFooter)
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" & _
            "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei" & _
            "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" & _
            "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit", "Heading3", "Normal"))
        CType(Me.txtFirma, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblHora, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblNombre, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMonto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtlinea, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTienda, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNumCaja, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtVendedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTarjeta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblPagare0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblPagare1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtOrdenDe, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblPagare2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTarjetaCred, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblPagare3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNombre, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtConsecutivoPOS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNumTienda, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPromocion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblOriginalCopia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblMontoMensual, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMontoMensual, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

#End Region

    Private Sub PageHeader_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles PageHeader.Format

    End Sub
End Class
