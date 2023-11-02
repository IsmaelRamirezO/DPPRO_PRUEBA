Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes
Imports DportenisPro.DPTienda.ApplicationUnits.FacturasFormaPago
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU

Public Class rptComprobantePagoDPCard
    Inherits DataDynamics.ActiveReports.ActiveReport

    Dim oReporteFormapago As ReporteDetalleFormasPago
    Dim oLetras As cImprimirFactura
    Dim oOP As OtrosPagos
    Dim oSAPMgr As ProcesoSAPManager

    Public Sub New(ByVal OtrosPagosID As Integer, ByVal Cliente As String, ByVal Concepto As String, ByVal EsCancelacion As Boolean, ByVal CodVendedor As String)
        MyBase.New()
        InitializeComponent()

        oOP = New OtrosPagos(OtrosPagosID, Concepto)

        Me.tbticket.Value = oOP.OtrosPagosID
        Me.txtNumTarjeta.Value = "**** **** ****" & oOP.NumOrden.Substring(12, 4)

        '---------------------------------------------------------------------------
        ' JNAVA (13.03.2015): Si es cancelacion y no viene el nombre, no mostrarlo
        '---------------------------------------------------------------------------
        If EsCancelacion Then
            If Cliente = String.Empty Then
                Me.tbNombreCliente.Visible = False
            End If
        Else
            Me.tbNombreCliente.Value = Cliente
        End If
        '---------------------------------------------------------------------------

        Me.tbAnticipo.Value = oOP.TotalPago

        Me.lblCaja.Text = "CAJA :" & CStr(oOP.CodCaja).Trim

        Select Case Concepto.Trim.ToUpper
            Case "DC"
                If Not EsCancelacion Then
                    Me.LblCopia.Text = "ABONO DE DP CARD"
                Else
                    Me.LblCopia.Text = "CANCELACIÓN DE ABONO DE DP CARD"
                End If
        End Select

        oLetras = New cImprimirFactura

        Me.tbTotalLetras.Text &= oLetras.Letras(Decimal.Round(oOP.TotalPago, 2)).ToUpper

        oLetras = Nothing

        Me.tbPlayer.Text = CodVendedor.Trim

        Dim oCatalogoAlmacenesMgr As New CatalogoAlmacenesManager(oAppContext)
        Dim oAlmacen As Almacen, strCentro As String = ""

        oSAPMgr = New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        strCentro = oSAPMgr.Read_Centros()
        oAlmacen = oCatalogoAlmacenesMgr.Load(strCentro.Trim)

        Me.tbLugarFecha.Text = oAlmacen.DireccionCiudad & ", " & oAlmacen.DireccionEstado & ", " & UCase(Format(Now, "dd-MMM-yy hh:mm tt"))

        Me.txtInfoSuc.Text = oAlmacen.Descripcion & vbLf & oAlmacen.DireccionCalle & vbLf & "C.P." & oAlmacen.DireccionCP & " TEL. " & oAlmacen.TelefonoNum & vbLf & _
                             "R.F.C. CDP-950126-9M5" & vbLf & oAlmacen.DireccionCiudad & ", " & oAlmacen.DireccionEstado
        oAlmacen = Nothing
        oCatalogoAlmacenesMgr = Nothing
        oSAPMgr = Nothing

        oReporteFormapago = New ReporteDetalleFormasPago(oOP.OtrosPagosID, 4)
        Me.SubReport1.Report = oReporteFormapago
        Me.SubReport1.Report.DataSource = oReporteFormapago.DataSource
        Me.SubReport1.Report.DataMember = oReporteFormapago.DataMember

        Me.tbNota1.Value = "REVISE QUE EL IMPORTE IMPRESO EN ESTE TICKET ES EL MISMO QUE USTED INDICO SE ABONARA A SU CREDITO."
        Me.tbNota2.Value = "CONSERVELO, ES SU COMPROBANTE DE PAGO"
        Me.txtFirma.Text = Cliente

    End Sub
#Region "ActiveReports Designer generated code"
    Private WithEvents PageHeader As PageHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents PageFooter As PageFooter = Nothing
	Private Label2 As Label = Nothing
	Private SubReport1 As SubReport = Nothing
	Private tbNota1 As TextBox = Nothing
	Private tbNota2 As TextBox = Nothing
	Private tbNombreCliente As TextBox = Nothing
	Private tbLugarFecha As TextBox = Nothing
	Private tbTipoVenta As TextBox = Nothing
	Private lblCaja As Label = Nothing
	Private lblTicket As Label = Nothing
	Private tbticket As TextBox = Nothing
	Private Label36 As Label = Nothing
	Private Label39 As Label = Nothing
	Private Label38 As Label = Nothing
	Private Label17 As Label = Nothing
	Private txtNumTarjeta As TextBox = Nothing
	Private txtInfoSuc As TextBox = Nothing
	Private Label37 As Label = Nothing
	Private tbAnticipo As TextBox = Nothing
	Private tbTotalLetras As TextBox = Nothing
	Private Label1 As Label = Nothing
	Private tbPlayer As TextBox = Nothing
	Private LblCopia As Label = Nothing
	Private Line1 As Line = Nothing
	Private txtFirma As TextBox = Nothing
	Private txtOperacion As TextBox = Nothing
	Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptComprobantePagoDPCard))
        Me.Detail = New DataDynamics.ActiveReports.Detail()
        Me.Label2 = New DataDynamics.ActiveReports.Label()
        Me.SubReport1 = New DataDynamics.ActiveReports.SubReport()
        Me.tbNota1 = New DataDynamics.ActiveReports.TextBox()
        Me.tbNota2 = New DataDynamics.ActiveReports.TextBox()
        Me.tbNombreCliente = New DataDynamics.ActiveReports.TextBox()
        Me.tbLugarFecha = New DataDynamics.ActiveReports.TextBox()
        Me.tbTipoVenta = New DataDynamics.ActiveReports.TextBox()
        Me.lblCaja = New DataDynamics.ActiveReports.Label()
        Me.lblTicket = New DataDynamics.ActiveReports.Label()
        Me.tbticket = New DataDynamics.ActiveReports.TextBox()
        Me.Label36 = New DataDynamics.ActiveReports.Label()
        Me.Label39 = New DataDynamics.ActiveReports.Label()
        Me.Label38 = New DataDynamics.ActiveReports.Label()
        Me.Label17 = New DataDynamics.ActiveReports.Label()
        Me.txtNumTarjeta = New DataDynamics.ActiveReports.TextBox()
        Me.txtInfoSuc = New DataDynamics.ActiveReports.TextBox()
        Me.Label37 = New DataDynamics.ActiveReports.Label()
        Me.tbAnticipo = New DataDynamics.ActiveReports.TextBox()
        Me.tbTotalLetras = New DataDynamics.ActiveReports.TextBox()
        Me.Label1 = New DataDynamics.ActiveReports.Label()
        Me.tbPlayer = New DataDynamics.ActiveReports.TextBox()
        Me.LblCopia = New DataDynamics.ActiveReports.Label()
        Me.Line1 = New DataDynamics.ActiveReports.Line()
        Me.txtFirma = New DataDynamics.ActiveReports.TextBox()
        Me.txtOperacion = New DataDynamics.ActiveReports.TextBox()
        Me.PageHeader = New DataDynamics.ActiveReports.PageHeader()
        Me.PageFooter = New DataDynamics.ActiveReports.PageFooter()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbNota1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbNota2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbNombreCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbLugarFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbTipoVenta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblCaja, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTicket, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbticket, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label36, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label39, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label38, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNumTarjeta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtInfoSuc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label37, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbAnticipo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbTotalLetras, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbPlayer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblCopia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFirma, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtOperacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.ColumnSpacing = 0.0!
        Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label2, Me.SubReport1, Me.tbNota1, Me.tbNota2, Me.tbNombreCliente, Me.tbLugarFecha, Me.tbTipoVenta, Me.lblCaja, Me.lblTicket, Me.tbticket, Me.Label36, Me.Label39, Me.Label38, Me.Label17, Me.txtNumTarjeta, Me.txtInfoSuc, Me.Label37, Me.tbAnticipo, Me.tbTotalLetras, Me.Label1, Me.tbPlayer, Me.LblCopia, Me.Line1, Me.txtFirma, Me.txtOperacion})
        Me.Detail.Height = 7.8125!
        Me.Detail.Name = "Detail"
        '
        'Label2
        '
        Me.Label2.Height = 0.1412403!
        Me.Label2.HyperLink = Nothing
        Me.Label2.Left = 0.0625!
        Me.Label2.Name = "Label2"
        Me.Label2.Style = "text-align: left; font-weight: normal; font-size: 8.25pt; font-family: Tahoma"
        Me.Label2.Text = "F. PAGO:"
        Me.Label2.Top = 4.0!
        Me.Label2.Visible = False
        Me.Label2.Width = 0.5!
        '
        'SubReport1
        '
        Me.SubReport1.CloseBorder = False
        Me.SubReport1.Height = 0.6924215!
        Me.SubReport1.Left = 0.6875!
        Me.SubReport1.Name = "SubReport1"
        Me.SubReport1.Report = Nothing
        Me.SubReport1.Top = 4.0!
        Me.SubReport1.Width = 1.6875!
        '
        'tbNota1
        '
        Me.tbNota1.CanShrink = True
        Me.tbNota1.Height = 0.4025593!
        Me.tbNota1.Left = 0.0625!
        Me.tbNota1.Name = "tbNota1"
        Me.tbNota1.Style = "text-align: center; font-weight: normal; font-size: 8.25pt; font-family: Tahoma"
        Me.tbNota1.Text = Nothing
        Me.tbNota1.Top = 4.78494!
        Me.tbNota1.Width = 2.4375!
        '
        'tbNota2
        '
        Me.tbNota2.CanShrink = True
        Me.tbNota2.Height = 0.1875!
        Me.tbNota2.Left = 0.0625!
        Me.tbNota2.Name = "tbNota2"
        Me.tbNota2.Style = "text-align: center; font-weight: normal; font-size: 8.25pt; font-family: Tahoma"
        Me.tbNota2.Text = Nothing
        Me.tbNota2.Top = 5.25!
        Me.tbNota2.Width = 2.4375!
        '
        'tbNombreCliente
        '
        Me.tbNombreCliente.CanShrink = True
        Me.tbNombreCliente.Height = 0.1875!
        Me.tbNombreCliente.Left = 0.0625!
        Me.tbNombreCliente.Name = "tbNombreCliente"
        Me.tbNombreCliente.Style = "ddo-char-set: 0; text-align: left; font-weight: normal; font-size: 9.75pt; font-f" & _
    "amily: Arial"
        Me.tbNombreCliente.Text = "Nombre Cliente"
        Me.tbNombreCliente.Top = 2.625!
        Me.tbNombreCliente.Width = 2.5!
        '
        'tbLugarFecha
        '
        Me.tbLugarFecha.Height = 0.15748!
        Me.tbLugarFecha.Left = 0.06840548!
        Me.tbLugarFecha.Name = "tbLugarFecha"
        Me.tbLugarFecha.Style = "ddo-char-set: 0; font-size: 9pt; font-family: Tahoma"
        Me.tbLugarFecha.Text = "Lugar Fecha"
        Me.tbLugarFecha.Top = 2.091043!
        Me.tbLugarFecha.Width = 2.46063!
        '
        'tbTipoVenta
        '
        Me.tbTipoVenta.Height = 0.15748!
        Me.tbTipoVenta.Left = 0.06840542!
        Me.tbTipoVenta.Name = "tbTipoVenta"
        Me.tbTipoVenta.Style = "ddo-char-set: 0; font-size: 9pt; font-family: Tahoma"
        Me.tbTipoVenta.Text = "OTROS PAGOS"
        Me.tbTipoVenta.Top = 1.891076!
        Me.tbTipoVenta.Width = 1.5625!
        '
        'lblCaja
        '
        Me.lblCaja.Height = 0.1574798!
        Me.lblCaja.HyperLink = Nothing
        Me.lblCaja.Left = 0.06840548!
        Me.lblCaja.Name = "lblCaja"
        Me.lblCaja.Style = "ddo-char-set: 0; font-weight: normal; font-size: 9pt; font-family: Tahoma"
        Me.lblCaja.Text = "CAJA"
        Me.lblCaja.Top = 1.692421!
        Me.lblCaja.Width = 1.25!
        '
        'lblTicket
        '
        Me.lblTicket.Height = 0.1574803!
        Me.lblTicket.HyperLink = Nothing
        Me.lblTicket.Left = 0.06840542!
        Me.lblTicket.Name = "lblTicket"
        Me.lblTicket.Style = "font-weight: bold; font-size: 9pt; font-family: Tahoma"
        Me.lblTicket.Text = "Ticket:"
        Me.lblTicket.Top = 1.491142!
        Me.lblTicket.Width = 1.318898!
        '
        'tbticket
        '
        Me.tbticket.Height = 0.1574803!
        Me.tbticket.Left = 1.45292!
        Me.tbticket.Name = "tbticket"
        Me.tbticket.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 9pt; font-fami" & _
    "ly: Tahoma"
        Me.tbticket.Text = "256321"
        Me.tbticket.Top = 1.502953!
        Me.tbticket.Width = 1.049869!
        '
        'Label36
        '
        Me.Label36.Height = 0.1875!
        Me.Label36.HyperLink = Nothing
        Me.Label36.Left = 0.0625!
        Me.Label36.Name = "Label36"
        Me.Label36.Style = "font-weight: bold; font-size: 9.75pt; font-family: Arial"
        Me.Label36.Text = "CLIENTE:"
        Me.Label36.Top = 2.4375!
        Me.Label36.Width = 0.6875!
        '
        'Label39
        '
        Me.Label39.Height = 0.4050198!
        Me.Label39.HyperLink = Nothing
        Me.Label39.Left = 0.0625!
        Me.Label39.Name = "Label39"
        Me.Label39.Style = "text-align: center; font-size: 9pt; font-family: Tahoma"
        Me.Label39.Text = "Matriz: Melchor Ocampo #1005 Centro     Mazatlán, Sin."
        Me.Label39.Top = 0.2824802!
        Me.Label39.Width = 2.41437!
        '
        'Label38
        '
        Me.Label38.Height = 0.1574803!
        Me.Label38.HyperLink = Nothing
        Me.Label38.Left = 0.0625!
        Me.Label38.Name = "Label38"
        Me.Label38.Style = "text-align: center; font-weight: bold; font-size: 9pt; font-family: Tahoma"
        Me.Label38.Text = "COMERCIAL D'PORTENIS, S.A. DE C.V."
        Me.Label38.Top = 0.125!
        Me.Label38.Width = 2.4375!
        '
        'Label17
        '
        Me.Label17.Height = 0.1574803!
        Me.Label17.HyperLink = Nothing
        Me.Label17.Left = 0.0625!
        Me.Label17.Name = "Label17"
        Me.Label17.Style = "text-align: center; font-weight: bold; font-size: 9pt; font-family: Tahoma"
        Me.Label17.Text = "SUCURSAL:"
        Me.Label17.Top = 0.6973423!
        Me.Label17.Width = 2.43061!
        '
        'txtNumTarjeta
        '
        Me.txtNumTarjeta.CanShrink = True
        Me.txtNumTarjeta.Height = 0.1875!
        Me.txtNumTarjeta.Left = 0.75!
        Me.txtNumTarjeta.Name = "txtNumTarjeta"
        Me.txtNumTarjeta.Style = "ddo-char-set: 0; text-align: left; font-weight: normal; font-size: 11.25pt; font-" & _
    "family: Arial"
        Me.txtNumTarjeta.Text = "NumTarjeta"
        Me.txtNumTarjeta.Top = 2.4375!
        Me.txtNumTarjeta.Width = 1.8125!
        '
        'txtInfoSuc
        '
        Me.txtInfoSuc.Height = 0.1875!
        Me.txtInfoSuc.Left = 0.0625!
        Me.txtInfoSuc.Name = "txtInfoSuc"
        Me.txtInfoSuc.Style = "text-align: center; font-size: 8.25pt"
        Me.txtInfoSuc.Text = "InfoSuc"
        Me.txtInfoSuc.Top = 0.875!
        Me.txtInfoSuc.Width = 2.4245!
        '
        'Label37
        '
        Me.Label37.Height = 0.1875!
        Me.Label37.HyperLink = Nothing
        Me.Label37.Left = 0.0625!
        Me.Label37.Name = "Label37"
        Me.Label37.Style = "font-weight: bold; font-size: 9.75pt; font-family: Arial"
        Me.Label37.Text = "IMPORTE:"
        Me.Label37.Top = 3.0!
        Me.Label37.Width = 1.0!
        '
        'tbAnticipo
        '
        Me.tbAnticipo.Height = 0.1875!
        Me.tbAnticipo.Left = 1.5625!
        Me.tbAnticipo.Name = "tbAnticipo"
        Me.tbAnticipo.OutputFormat = resources.GetString("tbAnticipo.OutputFormat")
        Me.tbAnticipo.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 9pt; font-famil" & _
    "y: Arial"
        Me.tbAnticipo.Text = "$ 599.00"
        Me.tbAnticipo.Top = 3.0!
        Me.tbAnticipo.Width = 0.944882!
        '
        'tbTotalLetras
        '
        Me.tbTotalLetras.Height = 0.2!
        Me.tbTotalLetras.Left = 0.06840548!
        Me.tbTotalLetras.Name = "tbTotalLetras"
        Me.tbTotalLetras.Style = "font-weight: normal; font-size: 8.25pt; font-family: Tahoma"
        Me.tbTotalLetras.Text = Nothing
        Me.tbTotalLetras.Top = 3.28494!
        Me.tbTotalLetras.Width = 2.494095!
        '
        'Label1
        '
        Me.Label1.Height = 0.1786415!
        Me.Label1.HyperLink = Nothing
        Me.Label1.Left = 0.0625!
        Me.Label1.Name = "Label1"
        Me.Label1.Style = "text-align: right; font-weight: normal; font-size: 8.25pt; font-family: Tahoma"
        Me.Label1.Text = "PLAYER:"
        Me.Label1.Top = 3.625!
        Me.Label1.Width = 0.5!
        '
        'tbPlayer
        '
        Me.tbPlayer.Height = 0.2!
        Me.tbPlayer.Left = 0.6875!
        Me.tbPlayer.Name = "tbPlayer"
        Me.tbPlayer.Style = "ddo-char-set: 0; text-align: left; font-weight: normal; font-size: 8.25pt; font-f" & _
    "amily: Tahoma"
        Me.tbPlayer.Text = Nothing
        Me.tbPlayer.Top = 3.625!
        Me.tbPlayer.Width = 0.5625!
        '
        'LblCopia
        '
        Me.LblCopia.Height = 0.1574805!
        Me.LblCopia.HyperLink = Nothing
        Me.LblCopia.Left = 0.0625!
        Me.LblCopia.Name = "LblCopia"
        Me.LblCopia.Style = "text-align: center; font-weight: bold; font-size: 8.25pt; font-family: Tahoma; ve" & _
    "rtical-align: top"
        Me.LblCopia.Text = "COPIA DE FACTURA"
        Me.LblCopia.Top = 1.158465!
        Me.LblCopia.Width = 2.431103!
        '
        'Line1
        '
        Me.Line1.Height = 0.0!
        Me.Line1.Left = 0.25!
        Me.Line1.LineWeight = 1.0!
        Me.Line1.Name = "Line1"
        Me.Line1.Top = 5.631945!
        Me.Line1.Width = 2.125!
        Me.Line1.X1 = 2.375!
        Me.Line1.X2 = 0.25!
        Me.Line1.Y1 = 5.631945!
        Me.Line1.Y2 = 5.631945!
        '
        'txtFirma
        '
        Me.txtFirma.Height = 0.1875!
        Me.txtFirma.Left = 0.25!
        Me.txtFirma.Name = "txtFirma"
        Me.txtFirma.Style = "ddo-char-set: 1; text-align: center; font-size: 9.75pt; font-family: Arial"
        Me.txtFirma.Text = "Nombre"
        Me.txtFirma.Top = 5.694445!
        Me.txtFirma.Width = 2.125!
        '
        'txtOperacion
        '
        Me.txtOperacion.Height = 1.75!
        Me.txtOperacion.Left = 0.0625!
        Me.txtOperacion.Name = "txtOperacion"
        Me.txtOperacion.Style = "ddo-char-set: 1; text-align: justify; font-size: 9.75pt; font-family: Arial"
        Me.txtOperacion.Text = resources.GetString("txtOperacion.Text")
        Me.txtOperacion.Top = 6.0!
        Me.txtOperacion.Width = 2.5!
        '
        'PageHeader
        '
        Me.PageHeader.Height = 0.0!
        Me.PageHeader.Name = "PageHeader"
        '
        'PageFooter
        '
        Me.PageFooter.Height = 0.0!
        Me.PageFooter.Name = "PageFooter"
        '
        'rptComprobantePagoDPCard
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
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbNota1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbNota2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbNombreCliente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbLugarFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbTipoVenta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblCaja, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTicket, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbticket, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label36, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label39, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label38, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNumTarjeta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtInfoSuc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label37, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbAnticipo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbTotalLetras, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbPlayer, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblCopia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFirma, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtOperacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

#End Region
End Class
