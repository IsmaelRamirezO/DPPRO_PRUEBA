Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU

Public Class rptSaldoDPCardPuntosKarum
    Inherits DataDynamics.ActiveReports.ActiveReport
    Public Sub New(ByVal Datos As Hashtable)
        MyBase.New()
        InitializeComponent()

        
        '-------------------------------------------------------------
        'FLIZARRAGA 24/08/2016: Se modifico el objeto por un Hashtable
        '-------------------------------------------------------------
        Dim fechaTicket As DateTime = CDate(Datos("Fecha"))
        Me.lblFecha.Text = "Fecha: " & fechaTicket.ToShortDateString
        Me.lblHora.Text = "Hora: " & Format(fechaTicket, "HH:mm:ss")

        
        Me.txtNumTienda.Text = CStr(Datos("IDTienda"))
        Dim oCatalogoAlmacenesMgr As New CatalogoAlmacenesManager(oAppContext)
        Dim oAlmacen As Almacen
        Dim oSAPMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        oAlmacen = oCatalogoAlmacenesMgr.Load(oSAPMgr.Read_Centros) '"2" & oAppContext.ApplicationConfiguration.Almacen)
        Me.txtTienda.Text = oAlmacen.Descripcion & vbCrLf & _
                            oAlmacen.DireccionCalle & vbCrLf & _
                            "C.P." & oAlmacen.DireccionCP & _
                            " TEL. " & oAlmacen.TelefonoNum & vbCrLf & _
                            "R.F.C. CDP-950126-9M5" & vbCrLf & _
                            oAlmacen.DireccionCiudad & ", " & oAlmacen.DireccionEstado
        '---------------------------------------------------------------------------------
        Me.txtNumCaja.Text = oAppContext.ApplicationConfiguration.NoCaja.Trim

        If Datos("NoTarjeta").Trim().Length = 16 Then
            Me.txtTarjeta.Text = "**** **** ****" & CStr(Datos("NoTarjeta")).Substring(12, 4)
        ElseIf Datos("NoTarjeta").Trim().Length = 13 Then
            Me.txtTarjeta.Text = "**** **** ****" & CStr(Datos("NoTarjeta")).Substring(9, 4)
        Else
            Me.txtTarjeta.Text = CStr(Datos("NoTarjeta"))
        End If

        'If Datos("NoTarjeta").Trim().Length = 16 Then
        '    Me.txtTarjeta.Text = "**** **** ****" & CStr(Datos("NoTarjeta")).Substring(12, 4)
        'Else
        '    Me.txtTarjeta.Text = CStr(Datos("NoTarjeta"))
        'End If

        If oConfigCierreFI.ServiciosBlueBonificacion = "True" Then
            Me.txtConsecutivoPOS.Text = CStr(Datos("ResultID"))
            'Me.txtSaldoActual.Text = Format(CDec(Datos("BalancePoints")), "c")
            Me.lblSaldoActual.Visible = False
            Me.txtSaldoPuntos.Text = CDec(Datos("BalancePoints")).ToString("##,##0.00")
            Me.txtEstatusTarjeta.Text = CStr(Datos("StatusDescription"))
            'Me.txtSaldoPuntos.Text = Format(CDec(Datos("BalanceAmount")), "c")
            Me.lblEstatusTarjeta.Top = Me.lblEstatusTarjeta.Top - 0.213
            Me.txtEstatusTarjeta.Top = Me.txtEstatusTarjeta.Top - 0.213
        Else
            Me.txtConsecutivoPOS.Text = CStr(Datos("ConsecutivoPOS"))
            Me.txtSaldoPuntos.Text = CDec(Datos("BalancePoints")).ToString("##,##0.00")
            'Me.txtSaldoActual.Text = Format(CDec(Datos("SaldoDinero")), "c"
            Me.lblSaldoActual.Visible = False
            Me.txtEstatusTarjeta.Text = CStr(Datos("StatusDescription"))
            Me.lblEstatusTarjeta.Top = Me.lblEstatusTarjeta.Top - 0.213
            Me.txtEstatusTarjeta.Top = Me.txtEstatusTarjeta.Top - 0.213
        End If



        Me.txtNombre.Text = CStr(Datos("CustomerName"))


    End Sub

#Region "ActiveReports Designer generated code"
    Private WithEvents PageHeader As PageHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Friend WithEvents Label36 As DataDynamics.ActiveReports.Label
    Friend WithEvents lblFecha As DataDynamics.ActiveReports.Label
    Friend WithEvents lblHora As DataDynamics.ActiveReports.Label
    Friend WithEvents Label37 As DataDynamics.ActiveReports.Label
    Friend WithEvents txtTarjeta As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label38 As DataDynamics.ActiveReports.Label
    Friend WithEvents txtNombre As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblSaldoActual As DataDynamics.ActiveReports.Label
    Friend WithEvents txtSaldoActual As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label44 As DataDynamics.ActiveReports.Label
    Friend WithEvents txtConsecutivoPOS As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label12 As DataDynamics.ActiveReports.Label
    Friend WithEvents txtNumTienda As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtTienda As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label8 As DataDynamics.ActiveReports.Label
    Friend WithEvents txtNumCaja As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblSaldoPuntos As DataDynamics.ActiveReports.Label
    Friend WithEvents txtSaldoPuntos As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblTerminosYCondiciones As DataDynamics.ActiveReports.Label
    Friend WithEvents txtTerminosYCondiciones As DataDynamics.ActiveReports.Label
    Friend WithEvents lblEstatusTarjeta As DataDynamics.ActiveReports.Label
    Friend WithEvents txtEstatusTarjeta As DataDynamics.ActiveReports.TextBox
    Private WithEvents PageFooter As PageFooter = Nothing
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptSaldoDPCardPuntosKarum))
        Me.Detail = New DataDynamics.ActiveReports.Detail()
        Me.PageHeader = New DataDynamics.ActiveReports.PageHeader()
        Me.Label36 = New DataDynamics.ActiveReports.Label()
        Me.lblFecha = New DataDynamics.ActiveReports.Label()
        Me.lblHora = New DataDynamics.ActiveReports.Label()
        Me.Label37 = New DataDynamics.ActiveReports.Label()
        Me.txtTarjeta = New DataDynamics.ActiveReports.TextBox()
        Me.Label38 = New DataDynamics.ActiveReports.Label()
        Me.txtNombre = New DataDynamics.ActiveReports.TextBox()
        Me.lblSaldoActual = New DataDynamics.ActiveReports.Label()
        Me.txtSaldoActual = New DataDynamics.ActiveReports.TextBox()
        Me.Label44 = New DataDynamics.ActiveReports.Label()
        Me.txtConsecutivoPOS = New DataDynamics.ActiveReports.TextBox()
        Me.Label12 = New DataDynamics.ActiveReports.Label()
        Me.txtNumTienda = New DataDynamics.ActiveReports.TextBox()
        Me.txtTienda = New DataDynamics.ActiveReports.TextBox()
        Me.Label8 = New DataDynamics.ActiveReports.Label()
        Me.txtNumCaja = New DataDynamics.ActiveReports.TextBox()
        Me.lblSaldoPuntos = New DataDynamics.ActiveReports.Label()
        Me.txtSaldoPuntos = New DataDynamics.ActiveReports.TextBox()
        Me.PageFooter = New DataDynamics.ActiveReports.PageFooter()
        Me.lblTerminosYCondiciones = New DataDynamics.ActiveReports.Label()
        Me.txtTerminosYCondiciones = New DataDynamics.ActiveReports.Label()
        Me.lblEstatusTarjeta = New DataDynamics.ActiveReports.Label()
        Me.txtEstatusTarjeta = New DataDynamics.ActiveReports.TextBox()
        CType(Me.Label36, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblHora, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label37, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTarjeta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label38, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNombre, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblSaldoActual, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSaldoActual, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label44, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtConsecutivoPOS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNumTienda, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTienda, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNumCaja, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblSaldoPuntos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSaldoPuntos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTerminosYCondiciones, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTerminosYCondiciones, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblEstatusTarjeta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEstatusTarjeta, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.PageHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label36, Me.lblFecha, Me.lblHora, Me.Label37, Me.txtTarjeta, Me.Label38, Me.txtNombre, Me.lblSaldoActual, Me.txtSaldoActual, Me.Label44, Me.txtConsecutivoPOS, Me.Label12, Me.txtNumTienda, Me.txtTienda, Me.Label8, Me.txtNumCaja, Me.lblSaldoPuntos, Me.txtSaldoPuntos, Me.lblTerminosYCondiciones, Me.txtTerminosYCondiciones, Me.lblEstatusTarjeta, Me.txtEstatusTarjeta})
        Me.PageHeader.Height = 3.6185!
        Me.PageHeader.Name = "PageHeader"
        '
        'Label36
        '
        Me.Label36.Height = 0.2!
        Me.Label36.HyperLink = Nothing
        Me.Label36.Left = 0.24!
        Me.Label36.Name = "Label36"
        Me.Label36.Style = "text-align: center; font-weight: bold; font-size: 9pt"
        Me.Label36.Text = "Consulta de Saldo de puntos"
        Me.Label36.Top = 0.0000001192093!
        Me.Label36.Width = 2.5!
        '
        'lblFecha
        '
        Me.lblFecha.Height = 0.2362205!
        Me.lblFecha.HyperLink = Nothing
        Me.lblFecha.Left = 0.2857682!
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Style = "font-family: Tahoma"
        Me.lblFecha.Text = "Fecha: 25/08/2007"
        Me.lblFecha.Top = 0.2947846!
        Me.lblFecha.Width = 1.259842!
        '
        'lblHora
        '
        Me.lblHora.Height = 0.2362205!
        Me.lblHora.HyperLink = Nothing
        Me.lblHora.Left = 1.608111!
        Me.lblHora.Name = "lblHora"
        Me.lblHora.Style = "font-family: Tahoma"
        Me.lblHora.Text = "Hora: 16:43"
        Me.lblHora.Top = 0.2947846!
        Me.lblHora.Width = 1.06939!
        '
        'Label37
        '
        Me.Label37.Height = 0.1875!
        Me.Label37.HyperLink = Nothing
        Me.Label37.Left = 0.2400002!
        Me.Label37.Name = "Label37"
        Me.Label37.Style = "text-align: left; font-weight: bold; font-size: 8.25pt; font-family: Tahoma"
        Me.Label37.Text = "Tarjeta:"
        Me.Label37.Top = 1.9375!
        Me.Label37.Width = 1.0!
        '
        'txtTarjeta
        '
        Me.txtTarjeta.Height = 0.1875!
        Me.txtTarjeta.Left = 1.24!
        Me.txtTarjeta.Name = "txtTarjeta"
        Me.txtTarjeta.Style = "text-align: left; font-size: 8.25pt; font-family: Arial"
        Me.txtTarjeta.Text = "Tarjeta"
        Me.txtTarjeta.Top = 1.9375!
        Me.txtTarjeta.Width = 1.5!
        '
        'Label38
        '
        Me.Label38.Height = 0.188!
        Me.Label38.HyperLink = Nothing
        Me.Label38.Left = 0.24!
        Me.Label38.Name = "Label38"
        Me.Label38.Style = "text-align: left; font-weight: bold; font-size: 8.25pt; font-family: Tahoma"
        Me.Label38.Text = "Client CLUB DP:"
        Me.Label38.Top = 2.238!
        Me.Label38.Width = 1.0!
        '
        'txtNombre
        '
        Me.txtNombre.Height = 0.1875!
        Me.txtNombre.Left = 1.24!
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Style = "text-align: left; font-size: 8.25pt; font-family: Arial"
        Me.txtNombre.Text = "Nombre"
        Me.txtNombre.Top = 2.242!
        Me.txtNombre.Width = 1.5!
        '
        'lblSaldoActual
        '
        Me.lblSaldoActual.Height = 0.1875!
        Me.lblSaldoActual.HyperLink = Nothing
        Me.lblSaldoActual.Left = 0.2400002!
        Me.lblSaldoActual.Name = "lblSaldoActual"
        Me.lblSaldoActual.Style = "text-align: left; font-weight: bold; font-size: 8.25pt; font-family: Tahoma"
        Me.lblSaldoActual.Text = "Saldo Dinero:"
        Me.lblSaldoActual.Top = 2.713!
        Me.lblSaldoActual.Width = 1.0!
        '
        'txtSaldoActual
        '
        Me.txtSaldoActual.Height = 0.1875!
        Me.txtSaldoActual.Left = 1.24!
        Me.txtSaldoActual.Name = "txtSaldoActual"
        Me.txtSaldoActual.Style = "text-align: left; font-size: 8.25pt; font-family: Arial"
        Me.txtSaldoActual.Top = 2.713!
        Me.txtSaldoActual.Width = 1.5!
        '
        'Label44
        '
        Me.Label44.Height = 0.1875!
        Me.Label44.HyperLink = Nothing
        Me.Label44.Left = 1.6775!
        Me.Label44.Name = "Label44"
        Me.Label44.Style = "text-align: left; font-weight: bold; font-size: 8.25pt; font-family: Tahoma"
        Me.Label44.Text = "CM:"
        Me.Label44.Top = 1.625!
        Me.Label44.Width = 0.3125!
        '
        'txtConsecutivoPOS
        '
        Me.txtConsecutivoPOS.Height = 0.1875!
        Me.txtConsecutivoPOS.Left = 1.99!
        Me.txtConsecutivoPOS.Name = "txtConsecutivoPOS"
        Me.txtConsecutivoPOS.Style = "text-align: left; font-size: 8.25pt; font-family: Arial"
        Me.txtConsecutivoPOS.Text = "0001"
        Me.txtConsecutivoPOS.Top = 1.625!
        Me.txtConsecutivoPOS.Width = 0.75!
        '
        'Label12
        '
        Me.Label12.Height = 0.1875!
        Me.Label12.HyperLink = Nothing
        Me.Label12.Left = 0.2400002!
        Me.Label12.Name = "Label12"
        Me.Label12.Style = "text-align: left; font-weight: bold; font-size: 8.25pt; font-family: Tahoma"
        Me.Label12.Text = "No. Tienda:"
        Me.Label12.Top = 0.6250001!
        Me.Label12.Width = 1.0!
        '
        'txtNumTienda
        '
        Me.txtNumTienda.Height = 0.1875!
        Me.txtNumTienda.Left = 1.24!
        Me.txtNumTienda.Name = "txtNumTienda"
        Me.txtNumTienda.Style = "text-align: left; font-size: 8.25pt; font-family: Arial"
        Me.txtNumTienda.Text = "01"
        Me.txtNumTienda.Top = 0.6250001!
        Me.txtNumTienda.Width = 1.5!
        '
        'txtTienda
        '
        Me.txtTienda.Height = 0.7410001!
        Me.txtTienda.Left = 0.2400002!
        Me.txtTienda.Name = "txtTienda"
        Me.txtTienda.Style = "text-align: center; font-size: 9.75pt; font-family: Arial"
        Me.txtTienda.Text = "000"
        Me.txtTienda.Top = 0.8125001!
        Me.txtTienda.Width = 2.5!
        '
        'Label8
        '
        Me.Label8.Height = 0.1875!
        Me.Label8.HyperLink = Nothing
        Me.Label8.Left = 0.2400002!
        Me.Label8.Name = "Label8"
        Me.Label8.Style = "text-align: left; font-weight: bold; font-size: 8.25pt; font-family: Tahoma"
        Me.Label8.Text = "No. Caja:"
        Me.Label8.Top = 1.625!
        Me.Label8.Width = 1.0!
        '
        'txtNumCaja
        '
        Me.txtNumCaja.Height = 0.1875!
        Me.txtNumCaja.Left = 1.24!
        Me.txtNumCaja.Name = "txtNumCaja"
        Me.txtNumCaja.Style = "text-align: left; font-size: 8.25pt; font-family: Arial"
        Me.txtNumCaja.Text = "01"
        Me.txtNumCaja.Top = 1.625!
        Me.txtNumCaja.Width = 0.375!
        '
        'lblSaldoPuntos
        '
        Me.lblSaldoPuntos.Height = 0.1875!
        Me.lblSaldoPuntos.HyperLink = Nothing
        Me.lblSaldoPuntos.Left = 0.2400002!
        Me.lblSaldoPuntos.Name = "lblSaldoPuntos"
        Me.lblSaldoPuntos.Style = "text-align: left; font-weight: bold; font-size: 8.25pt; font-family: Tahoma"
        Me.lblSaldoPuntos.Text = "Saldo Puntos:"
        Me.lblSaldoPuntos.Top = 2.5!
        Me.lblSaldoPuntos.Width = 1.0!
        '
        'txtSaldoPuntos
        '
        Me.txtSaldoPuntos.Height = 0.1875!
        Me.txtSaldoPuntos.Left = 1.24!
        Me.txtSaldoPuntos.Name = "txtSaldoPuntos"
        Me.txtSaldoPuntos.Style = "text-align: left; font-size: 8.25pt; font-family: Arial"
        Me.txtSaldoPuntos.Top = 2.5!
        Me.txtSaldoPuntos.Width = 1.5!
        '
        'PageFooter
        '
        Me.PageFooter.Height = 0.0!
        Me.PageFooter.Name = "PageFooter"
        '
        'lblTerminosYCondiciones
        '
        Me.lblTerminosYCondiciones.Height = 0.2!
        Me.lblTerminosYCondiciones.HyperLink = Nothing
        Me.lblTerminosYCondiciones.Left = 0.24!
        Me.lblTerminosYCondiciones.Name = "lblTerminosYCondiciones"
        Me.lblTerminosYCondiciones.Style = "font-weight: normal; font-size: 8.5pt; ddo-char-set: 1"
        Me.lblTerminosYCondiciones.Text = "Consulta términos y condiciones en"
        Me.lblTerminosYCondiciones.Top = 3.156!
        Me.lblTerminosYCondiciones.Width = 2.5!
        '
        'txtTerminosYCondiciones
        '
        Me.txtTerminosYCondiciones.Height = 0.2!
        Me.txtTerminosYCondiciones.HyperLink = Nothing
        Me.txtTerminosYCondiciones.Left = 0.24!
        Me.txtTerminosYCondiciones.Name = "txtTerminosYCondiciones"
        Me.txtTerminosYCondiciones.Style = "font-weight: normal; font-size: 8.5pt; text-decoration: underline; ddo-char-set: " & _
    "1"
        Me.txtTerminosYCondiciones.Text = "www.clubdp.mx"
        Me.txtTerminosYCondiciones.Top = 3.308!
        Me.txtTerminosYCondiciones.Width = 2.5!
        '
        'lblEstatusTarjeta
        '
        Me.lblEstatusTarjeta.Height = 0.1875!
        Me.lblEstatusTarjeta.HyperLink = Nothing
        Me.lblEstatusTarjeta.Left = 0.2400002!
        Me.lblEstatusTarjeta.Name = "lblEstatusTarjeta"
        Me.lblEstatusTarjeta.Style = "text-align: left; font-weight: bold; font-size: 8.25pt; font-family: Tahoma"
        Me.lblEstatusTarjeta.Text = "Estatus de Tarjeta:"
        Me.lblEstatusTarjeta.Top = 2.963!
        Me.lblEstatusTarjeta.Width = 1.208!
        '
        'txtEstatusTarjeta
        '
        Me.txtEstatusTarjeta.Height = 0.1875!
        Me.txtEstatusTarjeta.Left = 1.375!
        Me.txtEstatusTarjeta.Name = "txtEstatusTarjeta"
        Me.txtEstatusTarjeta.Style = "text-align: left; font-size: 8.25pt; font-family: Arial"
        Me.txtEstatusTarjeta.Text = "Estatus Tarjeta"
        Me.txtEstatusTarjeta.Top = 2.962!
        Me.txtEstatusTarjeta.Width = 1.365!
        '
        'rptSaldoDPCardPuntosKarum
        '
        Me.MasterReport = False
        Me.PageSettings.DefaultPaperSize = False
        Me.PageSettings.Margins.Bottom = 0.0!
        Me.PageSettings.Margins.Left = 0.0!
        Me.PageSettings.Margins.Right = 0.3!
        Me.PageSettings.Margins.Top = 0.0!
        Me.PageSettings.PaperHeight = 39.34028!
        Me.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Custom
        Me.PageSettings.PaperWidth = 2.95!
        Me.PrintWidth = 2.813!
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
        CType(Me.Label36, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblHora, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label37, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTarjeta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label38, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNombre, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblSaldoActual, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSaldoActual, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label44, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtConsecutivoPOS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNumTienda, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTienda, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNumCaja, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblSaldoPuntos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSaldoPuntos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTerminosYCondiciones, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTerminosYCondiciones, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblEstatusTarjeta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEstatusTarjeta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

#End Region

End Class
