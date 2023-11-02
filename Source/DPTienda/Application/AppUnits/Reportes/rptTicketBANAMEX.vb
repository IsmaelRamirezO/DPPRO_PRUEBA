Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU

Public Class rptTicketBANAMEX
Inherits DataDynamics.ActiveReports.ActiveReport
    Public Sub New(ByVal mAmount As Double, ByVal strNum As String, ByVal strVencimiento As String, _
    ByVal mAutorizacion As String, ByVal strPromocion As String, ByVal strMotivo As String, ByVal strNombre As String, _
    ByVal strPlayer As String, ByVal strmAfiliacion As String, ByVal strBancoEmisor As String, ByVal strTipoVoucher As String, _
    ByVal strFirma As String, ByVal strCriptograma As String, ByVal OnLine As Boolean, ByVal Ticket As String, ByVal Lote As String, _
    ByVal Trace As String, ByVal TerminalID As String)
        MyBase.New()
        InitializeComponent()

        Try

1:          Me.txtTipoVoucher.Text = strTipoVoucher
2:          Me.lblAfiliacion.Text = Me.lblAfiliacion.Text & " " & strmAfiliacion
3:          Me.txtBancoEmisor.Text = "BANAMEX" 'strBancoEmisor
4:          Me.TXTEMISOR.Text = strBancoEmisor
5:          Me.txtPromocion.Text = strPromocion
6:          Me.lblFecha.Text = "Fecha.- " & Now.Date.ToShortDateString
7:          Me.lblHora.Text = "Hora.- " & Now.ToShortTimeString
            'Me.lblTerminacionTarjeta.Text = "************" & strNum.Substring(12, 4)
            'If InStr(strTipoVoucher.Trim, "ORIGINAL") > 0 Then
            '    Me.lblTerminacionTarjeta.Text = strNum.Substring(0, 4) & " " & strNum.Substring(4, 4) & " " & _
            '                                    strNum.Substring(8, 4) & " " & strNum.Substring(12, 4)
            'Else
8:          Me.lblTerminacionTarjeta.Text = "**** **** **** " & strNum.Substring(12, 4)
            'End If
9:          Me.txtVencimiento.Text = "VIGENCIA: " & strVencimiento
10:         If OnLine Then
11:             Me.txtAprobacion.Text = "NO.AUT: " & mAutorizacion
            Else
13:             Me.txtAprobacion.Text = "F.DE LINEA AUTORIZACION: " & mAutorizacion
            End If
            'Me.txtAprobacion.Text = "APROBACION " & mAutorizacion
15:         Me.txtImporte.Text = Format(mAmount, "Currency")
16:         Me.txtMotivo.Text = strMotivo
17:         Me.txtNombreCliente.Text = strNombre

18:         If strMotivo = "CANCELACION" Then
                'Me.lblLeyendaPagare.Text = "HEMOS ACEPTADO EN DEVOLUCION DE LAS MERCANCIAS ANOTADAS COMPRADAS EN ESTE NEGOCIO " & _
                '                           "AFILIADO AL AMPARO DE LA TARJETA BANCARIA QUE SE INDICA POR LAS CAUSAS EXPUESTAS " & _
                '                           "AGRADECEREMOS SE SIRVAN ACREDITAR AL USUARIO LA CANTIDAD SUSCRITA EN ESTA NOTA DE DEVOLUCION"
19:             Me.lblLeyendaPagare.Text = "ACEPTAMOS LA DEVOLUCION DE MERCANCIAS AL AMPARO DE ESTA TARJETA DE CREDITO " & _
                                           "POR LO QUE ACREDITAMOS AL USUARIO LA CANTIDAD SENALADA EN  ESTA  NOTA DEVOLUCION"
            End If

21:         Dim oCatalogoAlmacenesMgr As New CatalogoAlmacenesManager(oAppContext)
22:         Dim oAlmacen As Almacen
23:         Dim oSAPMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
            oAlmacen = oCatalogoAlmacenesMgr.Load(oSAPMgr.Read_Centros) 'oAppContext.ApplicationConfiguration.Almacen)
24:         Me.txtTienda.Text = oAlmacen.Descripcion & Microsoft.VisualBasic.vbCrLf & _
                                oAlmacen.DireccionCalle & Microsoft.VisualBasic.vbCrLf & _
                                "C.P." & oAlmacen.DireccionCP & _
                                " TEL. " & oAlmacen.TelefonoNum & Microsoft.VisualBasic.vbCrLf & _
                                "R.F.C. CDP-950126-9M5" & Microsoft.VisualBasic.vbCrLf & _
                                oAlmacen.DireccionCiudad & ", " & oAlmacen.DireccionEstado


25:         Me.lblTienda.Text = lblTienda.Text & " " & oAlmacen.ID
26:         If OnLine Then
27:             Me.lblTerminal.Text = lblTerminal.Text & " " & TerminalID 'oAppContext.ApplicationConfiguration.NoCaja
            Else
29:             Me.lblTerminal.Text = lblTerminal.Text & " " & oAppContext.ApplicationConfiguration.NoCaja
            End If
31:         Me.lblNumeroOperador.Text = lblNumeroOperador.Text & " " & strPlayer
32:         Me.lblFirma.Text = strFirma
33:         Me.lblCriptograma.Text = strCriptograma
34:         Me.lblTicket.Text = CStr(CInt(Ticket)).Trim.PadLeft(6, "0")
35:         Me.lblTrace.Text = CStr(CInt(Trace)).Trim.PadLeft(6, "0")
36:         Me.lblLote.Text = CStr(CInt(Lote)).Trim.PadLeft(6, "0")

37:         oCatalogoAlmacenesMgr = Nothing
38:         oAlmacen = Nothing

        Catch ex As Exception
            EscribeLog(ex.ToString, "Error al imprimir voucher banamex: Linea " & Err.Erl)
        End Try

    End Sub
#Region "ActiveReports Designer generated code"
    Private WithEvents Detail As Detail = Nothing
	Private txtBancoEmisor As TextBox = Nothing
	Private txtTienda As TextBox = Nothing
	Private lblFecha As Label = Nothing
	Private lblHora As Label = Nothing
	Private lblTerminacionTarjeta As Label = Nothing
	Private txtVencimiento As TextBox = Nothing
	Private TXTEMISOR As TextBox = Nothing
	Private txtMotivo As TextBox = Nothing
	Private Label3 As Label = Nothing
	Private txtImporte As TextBox = Nothing
	Private txtAprobacion As TextBox = Nothing
	Private txtTipoVoucher As TextBox = Nothing
	Private lblFirma As Label = Nothing
	Private txtNombreCliente As TextBox = Nothing
	Private lblLeyendaPagare As Label = Nothing
	Private Line1 As Line = Nothing
	Private txtPromocion As TextBox = Nothing
	Private lblAfiliacion As Label = Nothing
	Private lblTienda As Label = Nothing
	Private lblTerminal As Label = Nothing
	Private lblNumeroOperador As Label = Nothing
	Private TextBox1 As TextBox = Nothing
	Private lblCriptograma As Label = Nothing
	Private lblTicket As Label = Nothing
	Private lblLote As Label = Nothing
	Private lblTrace As Label = Nothing
	Private Label4 As Label = Nothing
	Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptTicketBANAMEX))
            Me.Detail = New DataDynamics.ActiveReports.Detail()
            Me.txtBancoEmisor = New DataDynamics.ActiveReports.TextBox()
            Me.txtTienda = New DataDynamics.ActiveReports.TextBox()
            Me.lblFecha = New DataDynamics.ActiveReports.Label()
            Me.lblHora = New DataDynamics.ActiveReports.Label()
            Me.lblTerminacionTarjeta = New DataDynamics.ActiveReports.Label()
            Me.txtVencimiento = New DataDynamics.ActiveReports.TextBox()
            Me.TXTEMISOR = New DataDynamics.ActiveReports.TextBox()
            Me.txtMotivo = New DataDynamics.ActiveReports.TextBox()
            Me.Label3 = New DataDynamics.ActiveReports.Label()
            Me.txtImporte = New DataDynamics.ActiveReports.TextBox()
            Me.txtAprobacion = New DataDynamics.ActiveReports.TextBox()
            Me.txtTipoVoucher = New DataDynamics.ActiveReports.TextBox()
            Me.lblFirma = New DataDynamics.ActiveReports.Label()
            Me.txtNombreCliente = New DataDynamics.ActiveReports.TextBox()
            Me.lblLeyendaPagare = New DataDynamics.ActiveReports.Label()
            Me.Line1 = New DataDynamics.ActiveReports.Line()
            Me.txtPromocion = New DataDynamics.ActiveReports.TextBox()
            Me.lblAfiliacion = New DataDynamics.ActiveReports.Label()
            Me.lblTienda = New DataDynamics.ActiveReports.Label()
            Me.lblTerminal = New DataDynamics.ActiveReports.Label()
            Me.lblNumeroOperador = New DataDynamics.ActiveReports.Label()
            Me.TextBox1 = New DataDynamics.ActiveReports.TextBox()
            Me.lblCriptograma = New DataDynamics.ActiveReports.Label()
            Me.lblTicket = New DataDynamics.ActiveReports.Label()
            Me.lblLote = New DataDynamics.ActiveReports.Label()
            Me.lblTrace = New DataDynamics.ActiveReports.Label()
            Me.Label4 = New DataDynamics.ActiveReports.Label()
            CType(Me.txtBancoEmisor,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtTienda,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblFecha,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblHora,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblTerminacionTarjeta,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtVencimiento,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TXTEMISOR,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtMotivo,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label3,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtImporte,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtAprobacion,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtTipoVoucher,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblFirma,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtNombreCliente,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblLeyendaPagare,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtPromocion,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblAfiliacion,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblTienda,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblTerminal,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblNumeroOperador,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox1,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblCriptograma,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblTicket,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblLote,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblTrace,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
            '
            'Detail
            '
            Me.Detail.ColumnSpacing = 0!
            Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtBancoEmisor, Me.txtTienda, Me.lblFecha, Me.lblHora, Me.lblTerminacionTarjeta, Me.txtVencimiento, Me.TXTEMISOR, Me.txtMotivo, Me.Label3, Me.txtImporte, Me.txtAprobacion, Me.txtTipoVoucher, Me.lblFirma, Me.txtNombreCliente, Me.lblLeyendaPagare, Me.Line1, Me.txtPromocion, Me.lblAfiliacion, Me.lblTienda, Me.lblTerminal, Me.lblNumeroOperador, Me.TextBox1, Me.lblCriptograma, Me.lblTicket, Me.lblLote, Me.lblTrace, Me.Label4})
            Me.Detail.Height = 8.363889!
            Me.Detail.Name = "Detail"
            '
            'txtBancoEmisor
            '
            Me.txtBancoEmisor.Height = 0.1574803!
            Me.txtBancoEmisor.Left = 0!
            Me.txtBancoEmisor.Name = "txtBancoEmisor"
            Me.txtBancoEmisor.Style = "text-align: center; font-family: Tahoma"
            Me.txtBancoEmisor.Text = "BANAMEX"
            Me.txtBancoEmisor.Top = 0.3125!
            Me.txtBancoEmisor.Width = 2.283465!
            '
            'txtTienda
            '
            Me.txtTienda.Height = 0.8661417!
            Me.txtTienda.Left = 0!
            Me.txtTienda.Name = "txtTienda"
            Me.txtTienda.Style = "text-align: center; font-size: 9pt; font-family: Tahoma"
            Me.txtTienda.Text = "21 Plaza Obregon"
            Me.txtTienda.Top = 0.4699804!
            Me.txtTienda.Width = 2.283465!
            '
            'lblFecha
            '
            Me.lblFecha.Height = 0.2362205!
            Me.lblFecha.HyperLink = Nothing
            Me.lblFecha.Left = 0!
            Me.lblFecha.Name = "lblFecha"
            Me.lblFecha.Style = "font-family: Tahoma"
            Me.lblFecha.Text = "Fecha: 25/08/2007"
            Me.lblFecha.Top = 2.044783!
            Me.lblFecha.Width = 1.259842!
            '
            'lblHora
            '
            Me.lblHora.Height = 0.2362205!
            Me.lblHora.HyperLink = Nothing
            Me.lblHora.Left = 1.259842!
            Me.lblHora.Name = "lblHora"
            Me.lblHora.Style = "font-family: Tahoma"
            Me.lblHora.Text = "Hora: 16:43"
            Me.lblHora.Top = 2.044783!
            Me.lblHora.Width = 1.023622!
            '
            'lblTerminacionTarjeta
            '
            Me.lblTerminacionTarjeta.Height = 0.2362205!
            Me.lblTerminacionTarjeta.HyperLink = Nothing
            Me.lblTerminacionTarjeta.Left = 0!
            Me.lblTerminacionTarjeta.Name = "lblTerminacionTarjeta"
            Me.lblTerminacionTarjeta.Style = "font-weight: bold; font-size: 9.75pt; font-family: Tahoma"
            Me.lblTerminacionTarjeta.Text = "************6608"
            Me.lblTerminacionTarjeta.Top = 3.289862!
            Me.lblTerminacionTarjeta.Width = 1.574803!
            '
            'txtVencimiento
            '
            Me.txtVencimiento.Height = 0.2362205!
            Me.txtVencimiento.Left = 0!
            Me.txtVencimiento.Name = "txtVencimiento"
            Me.txtVencimiento.Style = "font-weight: bold; font-size: 8pt; font-family: Tahoma"
            Me.txtVencimiento.Text = "VENC 01/10"
            Me.txtVencimiento.Top = 3.526083!
            Me.txtVencimiento.Width = 1.574803!
            '
            'TXTEMISOR
            '
            Me.TXTEMISOR.Height = 0.1574803!
            Me.TXTEMISOR.Left = 0.9936021!
            Me.TXTEMISOR.Name = "TXTEMISOR"
            Me.TXTEMISOR.Style = "text-align: left; font-size: 9pt; font-family: Tahoma"
            Me.TXTEMISOR.Text = "Bancomer"
            Me.TXTEMISOR.Top = 2.927166!
            Me.TXTEMISOR.Width = 1.102362!
            '
            'txtMotivo
            '
            Me.txtMotivo.Height = 0.2362205!
            Me.txtMotivo.Left = 0!
            Me.txtMotivo.Name = "txtMotivo"
            Me.txtMotivo.Style = "text-align: center; font-weight: bold; font-family: Tahoma"
            Me.txtMotivo.Text = "NOTA DE VENTA PAGARE "
            Me.txtMotivo.Top = 1.336122!
            Me.txtMotivo.Width = 2.283465!
            '
            'Label3
            '
            Me.Label3.Height = 0.1574802!
            Me.Label3.HyperLink = Nothing
            Me.Label3.Left = 0!
            Me.Label3.Name = "Label3"
            Me.Label3.Style = "font-family: Tahoma"
            Me.Label3.Text = "IMPORTE"
            Me.Label3.Top = 4.404528!
            Me.Label3.Width = 0.6299213!
            '
            'txtImporte
            '
            Me.txtImporte.Height = 0.1574803!
            Me.txtImporte.Left = 0.6299213!
            Me.txtImporte.Name = "txtImporte"
            Me.txtImporte.Style = "text-align: right; font-family: Tahoma"
            Me.txtImporte.Text = "$ 105.00"
            Me.txtImporte.Top = 4.404528!
            Me.txtImporte.Width = 1.338583!
            '
            'txtAprobacion
            '
            Me.txtAprobacion.Height = 0.1574805!
            Me.txtAprobacion.Left = 0!
            Me.txtAprobacion.Name = "txtAprobacion"
            Me.txtAprobacion.Style = "font-weight: bold; font-size: 9pt; font-family: Tahoma"
            Me.txtAprobacion.Text = "APROBACION: 697300"
            Me.txtAprobacion.Top = 3.835547!
            Me.txtAprobacion.Width = 2.3125!
            '
            'txtTipoVoucher
            '
            Me.txtTipoVoucher.Height = 0.2362205!
            Me.txtTipoVoucher.Left = 0.3149606!
            Me.txtTipoVoucher.Name = "txtTipoVoucher"
            Me.txtTipoVoucher.Style = "text-align: center; font-size: 8pt; font-family: Tahoma"
            Me.txtTipoVoucher.Text = "ORIGINAL BANCO"
            Me.txtTipoVoucher.Top = 7.850396!
            Me.txtTipoVoucher.Width = 1.417323!
            '
            'lblFirma
            '
            Me.lblFirma.Height = 0.8125!
            Me.lblFirma.HyperLink = Nothing
            Me.lblFirma.Left = 0!
            Me.lblFirma.Name = "lblFirma"
            Me.lblFirma.Style = "ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8.25pt; font-fam"& _ 
                "ily: Tahoma"
            Me.lblFirma.Text = "FIRMA DEL TITULAR"
            Me.lblFirma.Top = 6.9375!
            Me.lblFirma.Width = 2.3125!
            '
            'txtNombreCliente
            '
            Me.txtNombreCliente.Height = 0.1574805!
            Me.txtNombreCliente.Left = 0!
            Me.txtNombreCliente.Name = "txtNombreCliente"
            Me.txtNombreCliente.Style = "text-align: left; font-weight: bold; font-size: 6.75pt; font-family: Tahoma"
            Me.txtNombreCliente.Text = "ARAGON ZEPEDA/ ERICK"
            Me.txtNombreCliente.Top = 6.227853!
            Me.txtNombreCliente.Visible = false
            Me.txtNombreCliente.Width = 2.204724!
            '
            'lblLeyendaPagare
            '
            Me.lblLeyendaPagare.Height = 1.088745!
            Me.lblLeyendaPagare.HyperLink = Nothing
            Me.lblLeyendaPagare.Left = 0!
            Me.lblLeyendaPagare.Name = "lblLeyendaPagare"
            Me.lblLeyendaPagare.Style = "text-align: justify; font-size: 9pt; font-family: Tahoma"
            Me.lblLeyendaPagare.Text = "CUBRIRE INCONDICIONALMENTE  EL TOTAL DE ESTE PAGARE A LA ORDEN DEL EMISOR SEGUN C"& _ 
                "ONTRATO DE DONDE DERIVA ESTA TARJETA Y DICHO PAGARE."
            Me.lblLeyendaPagare.Top = 4.723755!
            Me.lblLeyendaPagare.Width = 1.9375!
            '
            'Line1
            '
            Me.Line1.Height = 0!
            Me.Line1.Left = 0.006944444!
            Me.Line1.LineWeight = 1!
            Me.Line1.Name = "Line1"
            Me.Line1.Top = 8.657042!
            Me.Line1.Visible = false
            Me.Line1.Width = 2.283465!
            Me.Line1.X1 = 2.290409!
            Me.Line1.X2 = 0.006944444!
            Me.Line1.Y1 = 8.657042!
            Me.Line1.Y2 = 8.657042!
            '
            'txtPromocion
            '
            Me.txtPromocion.Height = 0.1574803!
            Me.txtPromocion.Left = 0!
            Me.txtPromocion.Name = "txtPromocion"
            Me.txtPromocion.Style = "text-align: center; font-weight: bold; font-family: Tahoma"
            Me.txtPromocion.Text = "3 Meses sin intereses"
            Me.txtPromocion.Top = 1.586122!
            Me.txtPromocion.Width = 2.283465!
            '
            'lblAfiliacion
            '
            Me.lblAfiliacion.Height = 0.2!
            Me.lblAfiliacion.HyperLink = Nothing
            Me.lblAfiliacion.Left = 0!
            Me.lblAfiliacion.Name = "lblAfiliacion"
            Me.lblAfiliacion.Style = "font-size: 9.75pt; font-family: Tahoma"
            Me.lblAfiliacion.Text = "AFILIACION: "
            Me.lblAfiliacion.Top = 1.808563!
            Me.lblAfiliacion.Width = 1.968504!
            '
            'lblTienda
            '
            Me.lblTienda.Height = 0.2!
            Me.lblTienda.HyperLink = Nothing
            Me.lblTienda.Left = 0!
            Me.lblTienda.Name = "lblTienda"
            Me.lblTienda.Style = "font-size: 9.75pt; font-family: Tahoma"
            Me.lblTienda.Text = "NUMERO DE TIENDA:"
            Me.lblTienda.Top = 2.359744!
            Me.lblTienda.Width = 2.283465!
            '
            'lblTerminal
            '
            Me.lblTerminal.Height = 0.2!
            Me.lblTerminal.HyperLink = Nothing
            Me.lblTerminal.Left = 0!
            Me.lblTerminal.Name = "lblTerminal"
            Me.lblTerminal.Style = "font-size: 9.75pt; font-family: Tahoma"
            Me.lblTerminal.Text = "TERMINAL:"
            Me.lblTerminal.Top = 2.579724!
            Me.lblTerminal.Width = 2.25!
            '
            'lblNumeroOperador
            '
            Me.lblNumeroOperador.Height = 0.2!
            Me.lblNumeroOperador.HyperLink = Nothing
            Me.lblNumeroOperador.Left = 0!
            Me.lblNumeroOperador.Name = "lblNumeroOperador"
            Me.lblNumeroOperador.Style = "font-size: 9.75pt; font-family: Tahoma"
            Me.lblNumeroOperador.Text = "NUMERO DE OPERADOR:"
            Me.lblNumeroOperador.Top = 2.734744!
            Me.lblNumeroOperador.Width = 2.283465!
            '
            'TextBox1
            '
            Me.TextBox1.Height = 0.1574803!
            Me.TextBox1.Left = 0!
            Me.TextBox1.Name = "TextBox1"
            Me.TextBox1.Style = "text-align: center; font-family: Tahoma"
            Me.TextBox1.Text = "Comercial DPortenis S.A. de C.V."
            Me.TextBox1.Top = 0.0625!
            Me.TextBox1.Width = 2.283465!
            '
            'lblCriptograma
            '
            Me.lblCriptograma.Height = 0.2381897!
            Me.lblCriptograma.HyperLink = Nothing
            Me.lblCriptograma.Left = 0.07874014!
            Me.lblCriptograma.Name = "lblCriptograma"
            Me.lblCriptograma.Style = "text-align: center; font-weight: bold; font-size: 9.75pt; font-family: Tahoma"
            Me.lblCriptograma.Text = "ARQC: 90A2206DE3885E7C"
            Me.lblCriptograma.Top = 8.074312!
            Me.lblCriptograma.Width = 2.047245!
            '
            'lblTicket
            '
            Me.lblTicket.Height = 0.1574802!
            Me.lblTicket.HyperLink = Nothing
            Me.lblTicket.Left = 1.6875!
            Me.lblTicket.Name = "lblTicket"
            Me.lblTicket.Style = "text-align: center; font-family: Tahoma"
            Me.lblTicket.Text = "000958"
            Me.lblTicket.Top = 4.092028!
            Me.lblTicket.Width = 0.6299213!
            '
            'lblLote
            '
            Me.lblLote.Height = 0.1574802!
            Me.lblLote.HyperLink = Nothing
            Me.lblLote.Left = 0!
            Me.lblLote.Name = "lblLote"
            Me.lblLote.Style = "text-align: center; font-family: Tahoma"
            Me.lblLote.Text = "000151"
            Me.lblLote.Top = 4.092028!
            Me.lblLote.Width = 0.6299213!
            '
            'lblTrace
            '
            Me.lblTrace.Height = 0.1574802!
            Me.lblTrace.HyperLink = Nothing
            Me.lblTrace.Left = 0.875!
            Me.lblTrace.Name = "lblTrace"
            Me.lblTrace.Style = "text-align: center; font-family: Tahoma"
            Me.lblTrace.Text = "000009"
            Me.lblTrace.Top = 4.092028!
            Me.lblTrace.Width = 0.6299213!
            '
            'Label4
            '
            Me.Label4.Height = 0.3125!
            Me.Label4.HyperLink = Nothing
            Me.Label4.Left = 0!
            Me.Label4.Name = "Label4"
            Me.Label4.Style = "text-align: justify; font-size: 9pt; font-family: Tahoma"
            Me.Label4.Text = "Negociable unicamente con Instituciones Bancarias"
            Me.Label4.Top = 5.8125!
            Me.Label4.Width = 1.9375!
            '
            'ActiveReport1
            '
            Me.MasterReport = false
            Me.PageSettings.Margins.Bottom = 0.39375!
            Me.PageSettings.Margins.Left = 0.39375!
            Me.PageSettings.Margins.Right = 0.39375!
            Me.PageSettings.Margins.Top = 0!
            Me.PageSettings.PaperHeight = 11!
            Me.PageSettings.PaperWidth = 8.5!
            Me.PrintWidth = 2.3125!
            Me.Sections.Add(Me.Detail)
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo"& _ 
                        "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit", "Heading1", "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei"& _ 
                        "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit", "Heading2", "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo"& _ 
                        "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit", "Heading3", "Normal"))
            CType(Me.txtBancoEmisor,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtTienda,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblFecha,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblHora,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblTerminacionTarjeta,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtVencimiento,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TXTEMISOR,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtMotivo,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label3,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtImporte,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtAprobacion,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtTipoVoucher,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblFirma,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtNombreCliente,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblLeyendaPagare,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtPromocion,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblAfiliacion,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblTienda,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblTerminal,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblNumeroOperador,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox1,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblCriptograma,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblTicket,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblLote,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblTrace,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        
	End Sub

#End Region
End Class
