Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU

Public Class rptVoucherClubDP
    Inherits DataDynamics.ActiveReports.ActiveReport
    Public Sub New(ByVal Datos As Hashtable, ByVal TipoVoucher As String, ByVal EsCopia As Boolean, ByVal EsCancelacion As Boolean)
        MyBase.New()
        InitializeComponent()

        Me.lblFecha.Text = "Fecha: " & Date.Today.ToShortDateString
        Me.lblHora.Text = "Hora: " & Format(Date.Now, "HH:mm:ss")

        Me.txtNumTienda.Text = CStr(Datos("NoTienda")).Replace("D3", "")
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
        Me.txtNumCaja.Text = CStr(Datos("NoCaja")).Trim
        Me.txtVendedor.Text = CStr(Datos("Vendedor"))
        Me.txtTarjeta.Text = "**** **** ****" & CStr(Datos("Tarjeta")).Substring(12, 4)
        Me.txtNombre.Text = CStr(Datos("TarjetaHabiente"))
        If EsCancelacion Then
            If CStr(Datos("TarjetaHabiente")) = String.Empty Then
                Me.lblNombre.Visible = False
                Me.txtNombre.Visible = False
            End If
            Me.txtMonto.Text = "-" & Format(CDec(Datos("Monto")), "c")
        Else
            Me.txtMonto.Text = Format(CDec(Datos("Monto")), "c")
        End If

        Me.txtlinea.Text = CStr(Datos("Linea"))

        Me.txtConsecutivoPOS.Text = CStr(Datos("ConsecutivoPOS"))

        If TipoVoucher = "PGO" Then
            
            If Not EsCancelacion Then
                Me.lblTitulo.Text = "Comprobante de disposición"
            Else
                Me.lblTitulo.Text = "Cancelación de disposición"
            End If
            Me.lblPagare0.Visible = False
            Me.lblPagare1.Visible = False
            Me.txtOrdenDe.Visible = False
            Me.lblPagare2.Visible = False
            Me.txtTarjetaCred.Visible = False
            Me.lblPagare3.Visible = False
            Me.lblOriginalCopia.Visible = False
            Me.lblIFE.Visible = False
            Me.txtIFE.Visible = False

        ElseIf TipoVoucher = "VTA" Then

            '---------------------------------------------------------------------------------------------
            'FLIZARRAGA 19/11/2015: Valida si el voucher es copia para poner el texto de original o copia
            '---------------------------------------------------------------------------------------------
            Dim montoMensual As Decimal = CDec(Datos("Monto"))
            Dim meses As Integer = CInt(Datos("Meses"))
            If meses > 0 Then
                montoMensual = montoMensual / meses
            End If
            Me.lblOriginalCopia.Visible = True
            If EsCopia Then
                Me.lblOriginalCopia.Text = "COPIA"
            Else
                Me.lblOriginalCopia.Text = "ORIGINAL"
            End If
            Me.txtTarjetaDebito.Text = CStr(Datos("NoTarjeta"))
            Me.txtBanco.Text = CStr(Datos("Banco"))


            If Not EsCancelacion Then
                Me.lblTitulo.Text = "Comprobante de disposición"
                If Datos.ContainsKey("Reimpresa") Then
                    If CBool(Datos("Reimpresa")) Then
                        lblReimpresa.Visible = True
                        txtReimpresa.Visible = True
                        txtReimpresa.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")
                    Else
                        lblReimpresa.Visible = False
                        txtReimpresa.Visible = False
                        txtReimpresa.Text = ""
                    End If
                Else
                    lblReimpresa.Visible = False
                    txtReimpresa.Visible = False
                    txtReimpresa.Text = ""
                End If
                Me.txtPlazo.Text = CStr(Datos("Promocion"))
                Me.txtPlazo.Visible = True
                Me.txtIFE.Visible = True
                If Not Datos("HoraDispersion") Is Nothing Then
                    Me.txtHora.Text = "La transferencia a su servicio estara disponible a partir de las " & CDate(Datos("HoraDispersion")).ToString("HH:mm") & " del día de hoy, en caso de no presentar problema la cuenta"
                    Me.txtHora.Visible = True
                Else
                    Me.txtHora.Visible = False
                End If
            Else

                Me.lblTitulo.Text = "Cancelación de disposición"
                Me.lblPagare0.Visible = False
                Me.lblPagare1.Visible = False
                Me.txtOrdenDe.Visible = False
                Me.lblPagare2.Visible = False
                Me.txtTarjetaCred.Visible = False
                Me.lblPagare3.Visible = False
                Me.lblIFE.Visible = False
                Me.txtIFE.Visible = False
                Me.txtReimpresa.Visible = False
                Me.lblReimpresa.Visible = False
                Me.txtHora.Visible = False
                Me.txtPlazo.Text = CStr(Datos("PM"))
            End If
            Me.txtOrdenDe.Text = "FUTURO ABC S.A.P.I. DE C.V. SOFOM ENR"
            Me.txtTarjetaCred.Text = "TARJETA DE CREDITO CLUB DP"
        End If
        Me.txtIFE.Text = CStr(Datos("IFE"))
        Me.txtFirma.Text = Me.txtNombre.Text
        Me.lblTasaInteres.Visible = False
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
    Private Label11 As Label = Nothing
    Private txtConsecutivoPOS As TextBox = Nothing
    Private Label12 As Label = Nothing
    Private txtNumTienda As TextBox = Nothing
    Friend WithEvents lblOriginalCopia As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Line2 As DataDynamics.ActiveReports.Line
    Friend WithEvents lblDisposicion As DataDynamics.ActiveReports.Label
    Friend WithEvents txtTarjetaDebito As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtBanco As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblPlazo As DataDynamics.ActiveReports.Label
    Friend WithEvents txtPlazo As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblIFE As DataDynamics.ActiveReports.Label
    Friend WithEvents txtIFE As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblReimpresa As DataDynamics.ActiveReports.Label
    Friend WithEvents txtReimpresa As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtHora As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblTasaInteres As DataDynamics.ActiveReports.Label
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptVoucherClubDP))
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
        Me.Label11 = New DataDynamics.ActiveReports.Label()
        Me.txtConsecutivoPOS = New DataDynamics.ActiveReports.TextBox()
        Me.Label12 = New DataDynamics.ActiveReports.Label()
        Me.txtNumTienda = New DataDynamics.ActiveReports.TextBox()
        Me.lblOriginalCopia = New DataDynamics.ActiveReports.TextBox()
        Me.Line2 = New DataDynamics.ActiveReports.Line()
        Me.lblDisposicion = New DataDynamics.ActiveReports.Label()
        Me.txtTarjetaDebito = New DataDynamics.ActiveReports.TextBox()
        Me.txtBanco = New DataDynamics.ActiveReports.TextBox()
        Me.lblPlazo = New DataDynamics.ActiveReports.Label()
        Me.txtPlazo = New DataDynamics.ActiveReports.TextBox()
        Me.lblTasaInteres = New DataDynamics.ActiveReports.Label()
        Me.lblIFE = New DataDynamics.ActiveReports.Label()
        Me.txtIFE = New DataDynamics.ActiveReports.TextBox()
        Me.lblReimpresa = New DataDynamics.ActiveReports.Label()
        Me.txtReimpresa = New DataDynamics.ActiveReports.TextBox()
        Me.txtHora = New DataDynamics.ActiveReports.TextBox()
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
        CType(Me.lblOriginalCopia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblDisposicion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTarjetaDebito, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBanco, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblPlazo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPlazo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTasaInteres, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblIFE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtIFE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblReimpresa, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtReimpresa, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtHora, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.PageHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtFirma, Me.lblHora, Me.lblFecha, Me.lblTitulo, Me.lblNombre, Me.Label4, Me.txtMonto, Me.txtlinea, Me.txtTienda, Me.txtNumCaja, Me.Label8, Me.Label9, Me.txtVendedor, Me.txtTarjeta, Me.Label10, Me.lblPagare0, Me.lblPagare1, Me.txtOrdenDe, Me.lblPagare2, Me.txtTarjetaCred, Me.lblPagare3, Me.txtNombre, Me.Label11, Me.txtConsecutivoPOS, Me.Label12, Me.txtNumTienda, Me.lblOriginalCopia, Me.Line2, Me.lblDisposicion, Me.txtTarjetaDebito, Me.txtBanco, Me.lblPlazo, Me.txtPlazo, Me.lblTasaInteres, Me.lblIFE, Me.txtIFE, Me.lblReimpresa, Me.txtReimpresa, Me.txtHora})
        Me.PageHeader.Height = 9.551835!
        Me.PageHeader.Name = "PageHeader"
        '
        'txtFirma
        '
        Me.txtFirma.Height = 0.1875!
        Me.txtFirma.Left = 0.25!
        Me.txtFirma.Name = "txtFirma"
        Me.txtFirma.Style = "text-align: center; font-size: 8.25pt; font-family: Arial"
        Me.txtFirma.Text = "Firma de conformidad del tarjetahabiente"
        Me.txtFirma.Top = 5.43!
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
        Me.lblTitulo.Text = "Comprobante de disposición"
        Me.lblTitulo.Top = 0.0!
        Me.lblTitulo.Width = 2.5!
        '
        'lblNombre
        '
        Me.lblNombre.Height = 0.1875!
        Me.lblNombre.HyperLink = Nothing
        Me.lblNombre.Left = 0.062!
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Style = "text-align: left; font-weight: bold; font-size: 8.25pt; font-family: Tahoma"
        Me.lblNombre.Text = "Tarjetahabiente:"
        Me.lblNombre.Top = 2.252!
        Me.lblNombre.Width = 1.0!
        '
        'Label4
        '
        Me.Label4.Height = 0.1875!
        Me.Label4.HyperLink = Nothing
        Me.Label4.Left = 0.062!
        Me.Label4.Name = "Label4"
        Me.Label4.Style = "text-align: left; font-weight: bold; font-size: 8.25pt; font-family: Tahoma"
        Me.Label4.Text = "Monto:"
        Me.Label4.Top = 3.513!
        Me.Label4.Width = 1.0!
        '
        'txtMonto
        '
        Me.txtMonto.Height = 0.1875!
        Me.txtMonto.Left = 1.062!
        Me.txtMonto.Name = "txtMonto"
        Me.txtMonto.Style = "text-align: left; font-size: 8.25pt; font-family: Arial"
        Me.txtMonto.Text = "$0.00"
        Me.txtMonto.Top = 3.513!
        Me.txtMonto.Width = 1.5!
        '
        'txtlinea
        '
        Me.txtlinea.Height = 0.1875!
        Me.txtlinea.Left = 0.063!
        Me.txtlinea.Name = "txtlinea"
        Me.txtlinea.Style = "text-align: left; font-size: 8.25pt; font-family: Arial"
        Me.txtlinea.Text = "EN LINEA"
        Me.txtlinea.Top = 4.333552!
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
        Me.lblPagare0.Top = 6.047559!
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
        Me.lblPagare1.Top = 6.235059!
        Me.lblPagare1.Width = 2.5!
        '
        'txtOrdenDe
        '
        Me.txtOrdenDe.Height = 0.1875!
        Me.txtOrdenDe.Left = 0.062!
        Me.txtOrdenDe.Name = "txtOrdenDe"
        Me.txtOrdenDe.Style = "text-align: center; font-size: 8.25pt; font-family: Tahoma"
        Me.txtOrdenDe.Text = "-"
        Me.txtOrdenDe.Top = 6.547559!
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
        Me.lblPagare2.Top = 6.735059!
        Me.lblPagare2.Width = 2.5!
        '
        'txtTarjetaCred
        '
        Me.txtTarjetaCred.Height = 0.1875!
        Me.txtTarjetaCred.Left = 0.062!
        Me.txtTarjetaCred.Name = "txtTarjetaCred"
        Me.txtTarjetaCred.Style = "text-align: center; font-size: 8.25pt; font-family: Tahoma"
        Me.txtTarjetaCred.Text = "TARJETA DE CREDITO CLUB DP"
        Me.txtTarjetaCred.Top = 7.360059!
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
        Me.lblPagare3.Top = 7.547559!
        Me.lblPagare3.Width = 2.5!
        '
        'txtNombre
        '
        Me.txtNombre.Height = 0.1875!
        Me.txtNombre.Left = 1.062!
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Style = "text-align: left; font-size: 8.25pt; font-family: Arial"
        Me.txtNombre.Text = "Nombre"
        Me.txtNombre.Top = 2.252!
        Me.txtNombre.Width = 1.5!
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
        'lblOriginalCopia
        '
        Me.lblOriginalCopia.Height = 0.188!
        Me.lblOriginalCopia.Left = 0.115!
        Me.lblOriginalCopia.Name = "lblOriginalCopia"
        Me.lblOriginalCopia.Style = "text-align: center; font-size: 8.25pt; font-family: Arial"
        Me.lblOriginalCopia.Text = "Original"
        Me.lblOriginalCopia.Top = 5.798561!
        Me.lblOriginalCopia.Width = 2.438!
        '
        'Line2
        '
        Me.Line2.Height = 0.0!
        Me.Line2.Left = 0.25!
        Me.Line2.LineWeight = 1.0!
        Me.Line2.Name = "Line2"
        Me.Line2.Top = 5.429998!
        Me.Line2.Width = 2.125!
        Me.Line2.X1 = 2.375!
        Me.Line2.X2 = 0.25!
        Me.Line2.Y1 = 5.429998!
        Me.Line2.Y2 = 5.429998!
        '
        'lblDisposicion
        '
        Me.lblDisposicion.Height = 0.3440001!
        Me.lblDisposicion.HyperLink = Nothing
        Me.lblDisposicion.Left = 0.063!
        Me.lblDisposicion.Name = "lblDisposicion"
        Me.lblDisposicion.Style = "text-align: center; font-weight: bold; font-size: 8.25pt; font-family: Tahoma"
        Me.lblDisposicion.Text = "Disposición con abono a  tarjeta de  Débito"
        Me.lblDisposicion.Top = 2.714!
        Me.lblDisposicion.Width = 2.487!
        '
        'txtTarjetaDebito
        '
        Me.txtTarjetaDebito.Height = 0.1875!
        Me.txtTarjetaDebito.Left = 0.06299999!
        Me.txtTarjetaDebito.Name = "txtTarjetaDebito"
        Me.txtTarjetaDebito.Style = "text-align: center; font-size: 8.25pt; font-family: Arial"
        Me.txtTarjetaDebito.Text = "-"
        Me.txtTarjetaDebito.Top = 3.058!
        Me.txtTarjetaDebito.Width = 2.487!
        '
        'txtBanco
        '
        Me.txtBanco.Height = 0.1875!
        Me.txtBanco.Left = 0.06299999!
        Me.txtBanco.Name = "txtBanco"
        Me.txtBanco.Style = "text-align: center; font-size: 8.25pt; font-family: Arial"
        Me.txtBanco.Text = "-"
        Me.txtBanco.Top = 3.246!
        Me.txtBanco.Width = 2.49!
        '
        'lblPlazo
        '
        Me.lblPlazo.Height = 0.1875!
        Me.lblPlazo.HyperLink = Nothing
        Me.lblPlazo.Left = 0.062!
        Me.lblPlazo.Name = "lblPlazo"
        Me.lblPlazo.Style = "text-align: left; font-weight: bold; font-size: 8.25pt; font-family: Tahoma"
        Me.lblPlazo.Text = "Plazo:"
        Me.lblPlazo.Top = 3.777!
        Me.lblPlazo.Width = 1.0!
        '
        'txtPlazo
        '
        Me.txtPlazo.Height = 0.1875!
        Me.txtPlazo.Left = 1.062!
        Me.txtPlazo.Name = "txtPlazo"
        Me.txtPlazo.Style = "text-align: left; font-size: 8.25pt; font-family: Arial"
        Me.txtPlazo.Text = "-"
        Me.txtPlazo.Top = 3.777!
        Me.txtPlazo.Width = 1.5!
        '
        'lblTasaInteres
        '
        Me.lblTasaInteres.Height = 0.1875!
        Me.lblTasaInteres.HyperLink = Nothing
        Me.lblTasaInteres.Left = 0.062!
        Me.lblTasaInteres.Name = "lblTasaInteres"
        Me.lblTasaInteres.Style = "text-align: center; font-weight: bold; font-size: 8.25pt; font-family: Tahoma"
        Me.lblTasaInteres.Text = "Tasa de interés Anual Fija: 120%"
        Me.lblTasaInteres.Top = 4.027!
        Me.lblTasaInteres.Visible = False
        Me.lblTasaInteres.Width = 2.488!
        '
        'lblIFE
        '
        Me.lblIFE.Height = 0.1875!
        Me.lblIFE.HyperLink = Nothing
        Me.lblIFE.Left = 0.063!
        Me.lblIFE.Name = "lblIFE"
        Me.lblIFE.Style = "text-align: left; font-weight: bold; font-size: 8.25pt; font-family: Tahoma"
        Me.lblIFE.Text = "No ID:"
        Me.lblIFE.Top = 4.609!
        Me.lblIFE.Width = 1.0!
        '
        'txtIFE
        '
        Me.txtIFE.Height = 0.1875!
        Me.txtIFE.Left = 1.063!
        Me.txtIFE.Name = "txtIFE"
        Me.txtIFE.Style = "text-align: left; font-size: 8.25pt; font-family: Arial"
        Me.txtIFE.Text = "-"
        Me.txtIFE.Top = 4.609!
        Me.txtIFE.Width = 1.5!
        '
        'lblReimpresa
        '
        Me.lblReimpresa.Height = 0.1875!
        Me.lblReimpresa.HyperLink = Nothing
        Me.lblReimpresa.Left = 0.05850001!
        Me.lblReimpresa.Name = "lblReimpresa"
        Me.lblReimpresa.Style = "text-align: left; font-weight: bold; font-size: 8.25pt; font-family: Tahoma"
        Me.lblReimpresa.Text = "Reimpresa:"
        Me.lblReimpresa.Top = 2.4395!
        Me.lblReimpresa.Width = 1.0!
        '
        'txtReimpresa
        '
        Me.txtReimpresa.Height = 0.1875!
        Me.txtReimpresa.Left = 1.0595!
        Me.txtReimpresa.Name = "txtReimpresa"
        Me.txtReimpresa.Style = "text-align: left; font-size: 8.25pt; font-family: Arial"
        Me.txtReimpresa.Text = "-"
        Me.txtReimpresa.Top = 2.4395!
        Me.txtReimpresa.Width = 1.5!
        '
        'txtHora
        '
        Me.txtHora.Height = 0.3230004!
        Me.txtHora.Left = 0.06300002!
        Me.txtHora.Name = "txtHora"
        Me.txtHora.Style = "text-align: justify; font-size: 8.25pt; font-family: Arial"
        Me.txtHora.Text = "-"
        Me.txtHora.Top = 4.796!
        Me.txtHora.Width = 2.5!
        '
        'PageFooter
        '
        Me.PageFooter.Height = 0.0!
        Me.PageFooter.Name = "PageFooter"
        '
        'rptVoucherClubDP
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
        CType(Me.lblOriginalCopia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblDisposicion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTarjetaDebito, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBanco, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblPlazo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPlazo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTasaInteres, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblIFE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtIFE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblReimpresa, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtReimpresa, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtHora, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

#End Region

End Class
