Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU

Public Class rptTicketBancomer
Inherits DataDynamics.ActiveReports.ActiveReport
    Public Sub New(ByVal mAmount As Double, ByVal strNum As String, ByVal strVencimiento As String, _
    ByVal mAutorizacion As String, ByVal strPromocion As String, ByVal strMotivo As String, ByVal strNombre As String, _
    ByVal strPlayer As String, ByVal strmAfiliacion As String, ByVal strBancoEmisor As String, ByVal strTipoVoucher As String, _
    ByVal mPosEntry As Integer, ByVal Aprobada As Boolean, ByVal Online As Boolean, ByVal Criptograma As String, _
    ByVal Firma As String)

        MyBase.New()
        InitializeComponent()

        Try

1:          Me.txtTipoVoucher.Text = strTipoVoucher
2:          Me.lblAfiliacion.Text = Me.lblAfiliacion.Text & strmAfiliacion
            'Me.txtBancoEmisor.Text = strBancoEmisor
3:          Me.TXTEMISOR.Text = strBancoEmisor
4:          Me.txtPromocion.Text = strPromocion
5:          Me.lblFecha.Text = "Fecha.- " & Now.Date.ToShortDateString
6:          Me.lblHora.Text = "Hora.- " & Now.ToShortTimeString
7:          If strTipoVoucher = "COPIA CLIENTE" Then
8:              Me.lblTerminacionTarjeta.Text = "**** **** **** " & strNum.Substring(12, 4)
            Else
10:             Me.lblTerminacionTarjeta.Text = strNum.Substring(0, 4) & " " & strNum.Substring(4, 4) & " " & _
                                                strNum.Substring(8, 4) & " " & strNum.Substring(12, 4)
            End If
12:         Me.txtVencimiento.Text = "VENC " & strVencimiento
13:         Me.txtAprobacion.Text = mAutorizacion
14:         Me.txtImporte.Text = Format(mAmount, "Currency")
15:         Me.txtMotivo.Text = strMotivo
            'Me.txtNombreCliente.Text = strNombre

            'If strMotivo = "CANCELACION" Then
            '    Me.lblLeyendaPagare.Text = "HEMOS ACEPTADO EN DEVOLUCION DE LAS MERCANCIAS ANOTADAS COMPRADAS EN ESTE NEGOCIO " & _
            '                               "AFILIADO AL AMPARO DE LA TARJETA BANCARIA QUE SE INDICA POR LAS CAUSAS EXPUESTAS " & _
            '                               "AGRADECEREMOS SE SIRVAN ACREDITAR AL USUARIO LA CANTIDAD SUSCRITA EN ESTA NOTA DE DEVOLUCION"
            'End If

            Dim oSAPMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
16:         Dim oCatalogoAlmacenesMgr As New CatalogoAlmacenesManager(oAppContext)
17:         Dim oAlmacen As Almacen
18:         oAlmacen = oCatalogoAlmacenesMgr.Load(oSAPMgr.Read_Centros) 'oAppContext.ApplicationConfiguration.Almacen)
19:         Me.txtTienda.Text = oAlmacen.Descripcion & Microsoft.VisualBasic.vbCrLf & _
                                oAlmacen.DireccionCalle & Microsoft.VisualBasic.vbCrLf & _
                                "C.P." & oAlmacen.DireccionCP & _
                                " TEL. " & oAlmacen.TelefonoNum & Microsoft.VisualBasic.vbCrLf & _
                                "R.F.C. CDP-950126-9M5" & Microsoft.VisualBasic.vbCrLf & _
                                oAlmacen.DireccionCiudad & ", " & oAlmacen.DireccionEstado

20:         If mPosEntry = 51 Then
21:             If Online Then
22:                 Me.lblFormatoTransaccion.Text = "BC I@1 000001 000001"
                Else
24:                 Me.lblFormatoTransaccion.Text = "BC I@5 000001 000001"
                End If
            Else
27:             If Online Then
28:                 Me.lblFormatoTransaccion.Text = "BC D@1 000001 000001"
                Else
30:                 Me.lblFormatoTransaccion.Text = "BC D@5 000001 000001"
                End If
            End If

33:         Me.lblCriptograma.Text = Criptograma

34:         If Aprobada Then
35:             Me.lblAprobacion.Text = "APROBACION:"
            Else
37:             Me.lblAprobacion.Text = "DECLINADA"
38:             Me.txtAprobacion.Visible = False
            End If

40:         Me.txtFirma.Text = Firma
            'Me.lblTienda.Text = lblTienda.Text & " " & oAlmacen.ID
            'Me.lblTerminal.Text = lblTerminal.Text & " " & oAppContext.ApplicationConfiguration.NoCaja
            'Me.lblNumeroOperador.Text = lblNumeroOperador.Text & " " & strPlayer

41:         oCatalogoAlmacenesMgr = Nothing
42:         oAlmacen = Nothing
        Catch ex As Exception
            EscribeLog(ex.ToString, "Error al imprimir voucher bancomer: Linea " & Err.Erl)
        End Try


    End Sub

#Region "ActiveReports Designer generated code"
    Private WithEvents Detail As Detail = Nothing
	Private txtBancoEmisor As TextBox = Nothing
	Private txtTienda As TextBox = Nothing
	Private lblTerminacionTarjeta As Label = Nothing
	Private txtVencimiento As TextBox = Nothing
	Private TXTEMISOR As TextBox = Nothing
	Private txtMotivo As TextBox = Nothing
	Private Label3 As Label = Nothing
	Private txtImporte As TextBox = Nothing
	Private txtAprobacion As TextBox = Nothing
	Private txtTipoVoucher As TextBox = Nothing
	Private lblLeyendaPagare As Label = Nothing
	Private txtPromocion As TextBox = Nothing
	Private lblAfiliacion As Label = Nothing
	Private lblLeyenda1 As Label = Nothing
	Private TextBox1 As TextBox = Nothing
	Private lblFecha As Label = Nothing
	Private lblHora As Label = Nothing
	Private lblFormatoTransaccion As Label = Nothing
	Private lblAprobacion As Label = Nothing
	Private lblVersion As Label = Nothing
	Private lblCriptograma As Label = Nothing
	Private txtFirma As TextBox = Nothing
	Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptTicketBancomer))
            Me.Detail = New DataDynamics.ActiveReports.Detail()
            Me.txtBancoEmisor = New DataDynamics.ActiveReports.TextBox()
            Me.txtTienda = New DataDynamics.ActiveReports.TextBox()
            Me.lblTerminacionTarjeta = New DataDynamics.ActiveReports.Label()
            Me.txtVencimiento = New DataDynamics.ActiveReports.TextBox()
            Me.TXTEMISOR = New DataDynamics.ActiveReports.TextBox()
            Me.txtMotivo = New DataDynamics.ActiveReports.TextBox()
            Me.Label3 = New DataDynamics.ActiveReports.Label()
            Me.txtImporte = New DataDynamics.ActiveReports.TextBox()
            Me.txtAprobacion = New DataDynamics.ActiveReports.TextBox()
            Me.txtTipoVoucher = New DataDynamics.ActiveReports.TextBox()
            Me.lblLeyendaPagare = New DataDynamics.ActiveReports.Label()
            Me.txtPromocion = New DataDynamics.ActiveReports.TextBox()
            Me.lblAfiliacion = New DataDynamics.ActiveReports.Label()
            Me.lblLeyenda1 = New DataDynamics.ActiveReports.Label()
            Me.TextBox1 = New DataDynamics.ActiveReports.TextBox()
            Me.lblFecha = New DataDynamics.ActiveReports.Label()
            Me.lblHora = New DataDynamics.ActiveReports.Label()
            Me.lblFormatoTransaccion = New DataDynamics.ActiveReports.Label()
            Me.lblAprobacion = New DataDynamics.ActiveReports.Label()
            Me.lblVersion = New DataDynamics.ActiveReports.Label()
            Me.lblCriptograma = New DataDynamics.ActiveReports.Label()
            Me.txtFirma = New DataDynamics.ActiveReports.TextBox()
            CType(Me.txtBancoEmisor,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtTienda,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblTerminacionTarjeta,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtVencimiento,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TXTEMISOR,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtMotivo,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label3,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtImporte,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtAprobacion,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtTipoVoucher,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblLeyendaPagare,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtPromocion,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblAfiliacion,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblLeyenda1,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox1,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblFecha,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblHora,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblFormatoTransaccion,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblAprobacion,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblVersion,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblCriptograma,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFirma,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
            '
            'Detail
            '
            Me.Detail.ColumnSpacing = 0!
            Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtBancoEmisor, Me.txtTienda, Me.lblTerminacionTarjeta, Me.txtVencimiento, Me.TXTEMISOR, Me.txtMotivo, Me.Label3, Me.txtImporte, Me.txtAprobacion, Me.txtTipoVoucher, Me.lblLeyendaPagare, Me.txtPromocion, Me.lblAfiliacion, Me.lblLeyenda1, Me.TextBox1, Me.lblFecha, Me.lblHora, Me.lblFormatoTransaccion, Me.lblAprobacion, Me.lblVersion, Me.lblCriptograma, Me.txtFirma})
            Me.Detail.Height = 8.2625!
            Me.Detail.Name = "Detail"
            '
            'txtBancoEmisor
            '
            Me.txtBancoEmisor.Height = 0.1574803!
            Me.txtBancoEmisor.Left = 0!
            Me.txtBancoEmisor.Name = "txtBancoEmisor"
            Me.txtBancoEmisor.Style = "text-align: center; font-family: Tahoma"
            Me.txtBancoEmisor.Text = "BBVA Bancomer"
            Me.txtBancoEmisor.Top = 0.0625!
            Me.txtBancoEmisor.Width = 2.283465!
            '
            'txtTienda
            '
            Me.txtTienda.Height = 0.8661417!
            Me.txtTienda.Left = 0!
            Me.txtTienda.Name = "txtTienda"
            Me.txtTienda.Style = "text-align: center; font-size: 9pt; font-family: Tahoma"
            Me.txtTienda.Text = "21 Plaza Obregon"
            Me.txtTienda.Top = 0.6887302!
            Me.txtTienda.Width = 2.283465!
            '
            'lblTerminacionTarjeta
            '
            Me.lblTerminacionTarjeta.Height = 0.2362205!
            Me.lblTerminacionTarjeta.HyperLink = Nothing
            Me.lblTerminacionTarjeta.Left = 0.01624016!
            Me.lblTerminacionTarjeta.Name = "lblTerminacionTarjeta"
            Me.lblTerminacionTarjeta.Style = "text-align: center; font-weight: bold; font-size: 13pt; font-family: Tahoma"
            Me.lblTerminacionTarjeta.Text = "************6608"
            Me.lblTerminacionTarjeta.Top = 2.424705!
            Me.lblTerminacionTarjeta.Width = 2.267224!
            '
            'txtVencimiento
            '
            Me.txtVencimiento.Height = 0.2362205!
            Me.txtVencimiento.Left = 0.01624016!
            Me.txtVencimiento.Name = "txtVencimiento"
            Me.txtVencimiento.Style = "font-weight: normal; font-size: 8pt; font-family: Tahoma"
            Me.txtVencimiento.Text = "VENC 01/10"
            Me.txtVencimiento.Top = 2.772146!
            Me.txtVencimiento.Width = 1.102363!
            '
            'TXTEMISOR
            '
            Me.TXTEMISOR.Height = 0.2362203!
            Me.TXTEMISOR.Left = 1.181102!
            Me.TXTEMISOR.Name = "TXTEMISOR"
            Me.TXTEMISOR.Style = "text-align: left; font-size: 9pt; font-family: Tahoma"
            Me.TXTEMISOR.Text = "Bancomer"
            Me.TXTEMISOR.Top = 2.755905!
            Me.TXTEMISOR.Width = 1.102362!
            '
            'txtMotivo
            '
            Me.txtMotivo.Height = 0.2362205!
            Me.txtMotivo.Left = 0!
            Me.txtMotivo.Name = "txtMotivo"
            Me.txtMotivo.Style = "text-align: left; font-weight: normal; font-family: Tahoma"
            Me.txtMotivo.Text = "NOTA DE VENTA PAGARE "
            Me.txtMotivo.Top = 3.149606!
            Me.txtMotivo.Width = 2.283465!
            '
            'Label3
            '
            Me.Label3.Height = 0.1574802!
            Me.Label3.HyperLink = Nothing
            Me.Label3.Left = 0!
            Me.Label3.Name = "Label3"
            Me.Label3.Style = "font-family: Tahoma"
            Me.Label3.Text = "TOTAL M.N."
            Me.Label3.Top = 3.793307!
            Me.Label3.Width = 0.7874014!
            '
            'txtImporte
            '
            Me.txtImporte.Height = 0.1574803!
            Me.txtImporte.Left = 0.7874014!
            Me.txtImporte.Name = "txtImporte"
            Me.txtImporte.Style = "text-align: right; font-family: Tahoma"
            Me.txtImporte.Text = "$ 105.00"
            Me.txtImporte.Top = 3.793307!
            Me.txtImporte.Width = 1.181102!
            '
            'txtAprobacion
            '
            Me.txtAprobacion.Height = 0.1574805!
            Me.txtAprobacion.Left = 0.9936021!
            Me.txtAprobacion.Name = "txtAprobacion"
            Me.txtAprobacion.Style = "font-weight: bold; font-size: 9pt; font-family: Tahoma"
            Me.txtAprobacion.Text = "697300"
            Me.txtAprobacion.Top = 4.642225!
            Me.txtAprobacion.Width = 0.8661417!
            '
            'txtTipoVoucher
            '
            Me.txtTipoVoucher.Height = 0.2362205!
            Me.txtTipoVoucher.Left = 0.01624016!
            Me.txtTipoVoucher.Name = "txtTipoVoucher"
            Me.txtTipoVoucher.Style = "text-align: center; font-size: 8pt; font-family: Tahoma"
            Me.txtTipoVoucher.Text = "ORIGINAL BANCO"
            Me.txtTipoVoucher.Top = 8.026576!
            Me.txtTipoVoucher.Width = 2.267224!
            '
            'lblLeyendaPagare
            '
            Me.lblLeyendaPagare.Height = 1.390828!
            Me.lblLeyendaPagare.HyperLink = Nothing
            Me.lblLeyendaPagare.Left = 0!
            Me.lblLeyendaPagare.Name = "lblLeyendaPagare"
            Me.lblLeyendaPagare.Style = "text-align: justify; font-size: 9pt; font-family: Tahoma"
            Me.lblLeyendaPagare.Text = resources.GetString("lblLeyendaPagare.Text")
            Me.lblLeyendaPagare.Top = 6.625!
            Me.lblLeyendaPagare.Width = 2.283465!
            '
            'txtPromocion
            '
            Me.txtPromocion.Height = 0.1574803!
            Me.txtPromocion.Left = 0!
            Me.txtPromocion.Name = "txtPromocion"
            Me.txtPromocion.Style = "text-align: center; font-weight: bold; font-family: Tahoma"
            Me.txtPromocion.Text = "3 Meses sin intereses"
            Me.txtPromocion.Top = 3.49065!
            Me.txtPromocion.Width = 2.283465!
            '
            'lblAfiliacion
            '
            Me.lblAfiliacion.Height = 0.2!
            Me.lblAfiliacion.HyperLink = Nothing
            Me.lblAfiliacion.Left = 0.01624016!
            Me.lblAfiliacion.Name = "lblAfiliacion"
            Me.lblAfiliacion.Style = "text-align: center; font-size: 9.75pt; font-family: Tahoma"
            Me.lblAfiliacion.Text = "AFILIACION-"
            Me.lblAfiliacion.Top = 1.621063!
            Me.lblAfiliacion.Width = 2.267224!
            '
            'lblLeyenda1
            '
            Me.lblLeyenda1.Height = 0.3686843!
            Me.lblLeyenda1.HyperLink = Nothing
            Me.lblLeyenda1.Left = 0!
            Me.lblLeyenda1.Name = "lblLeyenda1"
            Me.lblLeyenda1.Style = "font-size: 9.75pt; font-family: Tahoma"
            Me.lblLeyenda1.Text = "PAGARE NEGOCIABLE UNICAMENTE CON INSTITUCIONES DE CREDITO"
            Me.lblLeyenda1.Top = 6.153051!
            Me.lblLeyenda1.Width = 2.283465!
            '
            'TextBox1
            '
            Me.TextBox1.Height = 0.176181!
            Me.TextBox1.Left = 0!
            Me.TextBox1.Name = "TextBox1"
            Me.TextBox1.Style = "text-align: center; font-family: Tahoma"
            Me.TextBox1.Text = "Comercial DPortenis S.A. de C.V."
            Me.TextBox1.Top = 0.375!
            Me.TextBox1.Width = 2.283465!
            '
            'lblFecha
            '
            Me.lblFecha.Height = 0.2362205!
            Me.lblFecha.HyperLink = Nothing
            Me.lblFecha.Left = 0!
            Me.lblFecha.Name = "lblFecha"
            Me.lblFecha.Style = "font-family: Tahoma"
            Me.lblFecha.Text = "Fecha: 25/08/2007"
            Me.lblFecha.Top = 1.898951!
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
            Me.lblHora.Top = 1.898951!
            Me.lblHora.Width = 1.023622!
            '
            'lblFormatoTransaccion
            '
            Me.lblFormatoTransaccion.Height = 0.2362203!
            Me.lblFormatoTransaccion.HyperLink = Nothing
            Me.lblFormatoTransaccion.Left = 0!
            Me.lblFormatoTransaccion.Name = "lblFormatoTransaccion"
            Me.lblFormatoTransaccion.Style = "font-size: 9.75pt; font-family: Tahoma"
            Me.lblFormatoTransaccion.Text = "BC D@1 000001 000001"
            Me.lblFormatoTransaccion.Top = 4.124508!
            Me.lblFormatoTransaccion.Width = 2.267224!
            '
            'lblAprobacion
            '
            Me.lblAprobacion.Height = 0.1574802!
            Me.lblAprobacion.HyperLink = Nothing
            Me.lblAprobacion.Left = 0!
            Me.lblAprobacion.Name = "lblAprobacion"
            Me.lblAprobacion.Style = "font-size: 9.75pt; font-family: Tahoma"
            Me.lblAprobacion.Text = "APROBACION: "
            Me.lblAprobacion.Top = 4.643209!
            Me.lblAprobacion.Width = 0.944882!
            '
            'lblVersion
            '
            Me.lblVersion.Height = 0.1574805!
            Me.lblVersion.HyperLink = Nothing
            Me.lblVersion.Left = 0!
            Me.lblVersion.Name = "lblVersion"
            Me.lblVersion.Style = "font-size: 9.75pt; font-family: Tahoma"
            Me.lblVersion.Text = "Version"
            Me.lblVersion.Top = 2.142224!
            Me.lblVersion.Width = 1.496063!
            '
            'lblCriptograma
            '
            Me.lblCriptograma.Height = 0.2362203!
            Me.lblCriptograma.HyperLink = Nothing
            Me.lblCriptograma.Left = 0!
            Me.lblCriptograma.Name = "lblCriptograma"
            Me.lblCriptograma.Style = "font-size: 9.75pt; font-family: Tahoma"
            Me.lblCriptograma.Text = "ARQC: AE435F63AB73AC54"
            Me.lblCriptograma.Top = 4.384999!
            Me.lblCriptograma.Width = 2.267224!
            '
            'txtFirma
            '
            Me.txtFirma.Height = 0.5!
            Me.txtFirma.Left = 0!
            Me.txtFirma.Name = "txtFirma"
            Me.txtFirma.Style = "text-align: left; font-weight: normal; font-size: 10pt; font-family: Tahoma"
            Me.txtFirma.Text = "FIRMA _______________________"
            Me.txtFirma.Top = 5.5625!
            Me.txtFirma.Width = 2.4375!
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
            Me.PrintWidth = 2.4375!
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
            CType(Me.lblTerminacionTarjeta,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtVencimiento,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TXTEMISOR,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtMotivo,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label3,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtImporte,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtAprobacion,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtTipoVoucher,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblLeyendaPagare,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtPromocion,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblAfiliacion,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblLeyenda1,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox1,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblFecha,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblHora,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblFormatoTransaccion,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblAprobacion,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblVersion,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblCriptograma,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFirma,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        
	End Sub

#End Region

End Class
