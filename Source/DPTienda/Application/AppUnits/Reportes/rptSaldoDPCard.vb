Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU

Public Class rptSaldoDPCard
    Inherits DataDynamics.ActiveReports.ActiveReport
    Public Sub New(ByVal Datos As Hashtable)
        MyBase.New()
        InitializeComponent()

        '--------------------------------------------------------------
        'JNAVA (21.01.2014): Mostramos Datos para imprimir Saldo
        '--------------------------------------------------------------
        '-------------------------------------------------------------
        'FLIZARRAGA 20/02/2015: Se modifico el objeto por un Hashtable
        '-------------------------------------------------------------
        Dim fechaTicket As DateTime = CDate(Datos("Fecha"))
        Me.lblFecha.Text = "Fecha: " & fechaTicket.ToShortDateString
        Me.lblHora.Text = "Hora: " & Format(fechaTicket, "HH:mm:ss")

        '---------------------------------------------------------------------------------
        'JNAVA (01.06.2015): Datos de Tienda (Numero tienda, Nombre, Direccion y Telefono
        '---------------------------------------------------------------------------------
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

        '---------------------------------------------------------------------------
        ' JNAVA (08.04.2015): Agregamos consecutivo POS a la consulta de saldo
        '---------------------------------------------------------------------------
        Me.txtConsecutivoPOS.Text = CStr(Datos("ConsecutivoPOS"))

        Me.txtTarjeta.Text = "**** **** ****" & CStr(Datos("NoTarjeta")).Substring(12, 4)
        Me.txtNombre.Text = CStr(Datos("TarjetaHabiente"))

        Me.txtSaldoActual.Text = Format(CDec(Datos("SaldoActual")), "c")

        Me.txtPagoMinimo.Text = Format(CDec(Datos("PagoMinimo")), "c")

        Me.txtPagoVencido.Text = Format(CDec(Datos("PagoVencido")), "c")

        Me.txtPagoTotal.Text = Format(CDec(Datos("PagoTotal")), "c")
        Dim strFecha As String = CStr(Datos("FechaLimitePago"))

        Dim fecha As New DateTime(strFecha.Substring(0, 4), strFecha.Substring(4, 2), strFecha.Substring(6, 2))

        ' Me.txtFechaLimite.Text=
        If fechaTicket.Day < 7 Then
            fechaTicket = New DateTime(fechaTicket.Year, fechaTicket.Month, 1)
            fechaTicket = fechaTicket.AddDays(-1)
            If fechaTicket.Day > 30 Then
                fechaTicket = fechaTicket.AddDays(-1)
            End If
        Else
            fechaTicket = New DateTime(fechaTicket.AddMonths(1).Year, fechaTicket.AddMonths(1).Month, 1)
            fechaTicket = fechaTicket.AddDays(-1)
            If fechaTicket.Day > 30 Then
                fechaTicket = fechaTicket.AddDays(-1)
            End If
        End If
        Me.txtFechaLimite.Text = fechaTicket.Day & " de " & Format(fechaTicket, "MMMM") & " del " & fechaTicket.Year
        'Me.txtFechaLimite.Text = fecha.Day & " de " & Format(fecha, "MMMM") & " del " & fecha.Year

    End Sub

#Region "ActiveReports Designer generated code"
    Private WithEvents PageHeader As PageHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents PageFooter As PageFooter = Nothing
	Private Label36 As Label = Nothing
	Private lblFecha As Label = Nothing
	Private lblHora As Label = Nothing
	Private Label37 As Label = Nothing
	Private txtTarjeta As TextBox = Nothing
	Private Label38 As Label = Nothing
	Private txtNombre As TextBox = Nothing
	Private Label39 As Label = Nothing
	Private txtSaldoActual As TextBox = Nothing
	Private Label40 As Label = Nothing
	Private txtPagoMinimo As TextBox = Nothing
	Private Label41 As Label = Nothing
	Private txtPagoVencido As TextBox = Nothing
	Private Label42 As Label = Nothing
	Private txtPagoTotal As TextBox = Nothing
	Private Label43 As Label = Nothing
	Private txtFechaLimite As TextBox = Nothing
	Private Label44 As Label = Nothing
	Private txtConsecutivoPOS As TextBox = Nothing
	Private Label12 As Label = Nothing
	Private txtNumTienda As TextBox = Nothing
	Private txtTienda As TextBox = Nothing
	Private Label8 As Label = Nothing
	Private txtNumCaja As TextBox = Nothing
	Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptSaldoDPCard))
        Me.Detail = New DataDynamics.ActiveReports.Detail()
        Me.PageHeader = New DataDynamics.ActiveReports.PageHeader()
        Me.Label36 = New DataDynamics.ActiveReports.Label()
        Me.lblFecha = New DataDynamics.ActiveReports.Label()
        Me.lblHora = New DataDynamics.ActiveReports.Label()
        Me.Label37 = New DataDynamics.ActiveReports.Label()
        Me.txtTarjeta = New DataDynamics.ActiveReports.TextBox()
        Me.Label38 = New DataDynamics.ActiveReports.Label()
        Me.txtNombre = New DataDynamics.ActiveReports.TextBox()
        Me.Label39 = New DataDynamics.ActiveReports.Label()
        Me.txtSaldoActual = New DataDynamics.ActiveReports.TextBox()
        Me.Label40 = New DataDynamics.ActiveReports.Label()
        Me.txtPagoMinimo = New DataDynamics.ActiveReports.TextBox()
        Me.Label41 = New DataDynamics.ActiveReports.Label()
        Me.txtPagoVencido = New DataDynamics.ActiveReports.TextBox()
        Me.Label42 = New DataDynamics.ActiveReports.Label()
        Me.txtPagoTotal = New DataDynamics.ActiveReports.TextBox()
        Me.Label43 = New DataDynamics.ActiveReports.Label()
        Me.txtFechaLimite = New DataDynamics.ActiveReports.TextBox()
        Me.Label44 = New DataDynamics.ActiveReports.Label()
        Me.txtConsecutivoPOS = New DataDynamics.ActiveReports.TextBox()
        Me.Label12 = New DataDynamics.ActiveReports.Label()
        Me.txtNumTienda = New DataDynamics.ActiveReports.TextBox()
        Me.txtTienda = New DataDynamics.ActiveReports.TextBox()
        Me.Label8 = New DataDynamics.ActiveReports.Label()
        Me.txtNumCaja = New DataDynamics.ActiveReports.TextBox()
        Me.PageFooter = New DataDynamics.ActiveReports.PageFooter()
        CType(Me.Label36, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblHora, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label37, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTarjeta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label38, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNombre, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label39, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSaldoActual, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label40, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPagoMinimo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label41, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPagoVencido, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label42, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPagoTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label43, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaLimite, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label44, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtConsecutivoPOS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNumTienda, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTienda, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNumCaja, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.PageHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label36, Me.lblFecha, Me.lblHora, Me.Label37, Me.txtTarjeta, Me.Label38, Me.txtNombre, Me.Label39, Me.txtSaldoActual, Me.Label40, Me.txtPagoMinimo, Me.Label41, Me.txtPagoVencido, Me.Label42, Me.txtPagoTotal, Me.Label43, Me.txtFechaLimite, Me.Label44, Me.txtConsecutivoPOS, Me.Label12, Me.txtNumTienda, Me.txtTienda, Me.Label8, Me.txtNumCaja})
        Me.PageHeader.Height = 4.040972!
        Me.PageHeader.Name = "PageHeader"
        '
        'Label36
        '
        Me.Label36.Height = 0.2!
        Me.Label36.HyperLink = Nothing
        Me.Label36.Left = 0.6377952!
        Me.Label36.Name = "Label36"
        Me.Label36.Style = "text-align: center; font-weight: bold; font-size: 9pt"
        Me.Label36.Text = "Saldo Club DP"
        Me.Label36.Top = 0.0625!
        Me.Label36.Width = 1.588091!
        '
        'lblFecha
        '
        Me.lblFecha.Height = 0.2362205!
        Me.lblFecha.HyperLink = Nothing
        Me.lblFecha.Left = 0.233268!
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Style = "font-family: Tahoma"
        Me.lblFecha.Text = "Fecha: 25/08/2007"
        Me.lblFecha.Top = 0.3572845!
        Me.lblFecha.Width = 1.259842!
        '
        'lblHora
        '
        Me.lblHora.Height = 0.2362205!
        Me.lblHora.HyperLink = Nothing
        Me.lblHora.Left = 1.555611!
        Me.lblHora.Name = "lblHora"
        Me.lblHora.Style = "font-family: Tahoma"
        Me.lblHora.Text = "Hora: 16:43"
        Me.lblHora.Top = 0.3572845!
        Me.lblHora.Width = 1.06939!
        '
        'Label37
        '
        Me.Label37.Height = 0.1875!
        Me.Label37.HyperLink = Nothing
        Me.Label37.Left = 0.1875!
        Me.Label37.Name = "Label37"
        Me.Label37.Style = "text-align: left; font-weight: bold; font-size: 8.25pt; font-family: Tahoma"
        Me.Label37.Text = "Tarjeta:"
        Me.Label37.Top = 2.0!
        Me.Label37.Width = 1.0!
        '
        'txtTarjeta
        '
        Me.txtTarjeta.Height = 0.1875!
        Me.txtTarjeta.Left = 1.1875!
        Me.txtTarjeta.Name = "txtTarjeta"
        Me.txtTarjeta.Style = "text-align: left; font-size: 8.25pt; font-family: Arial"
        Me.txtTarjeta.Text = "Tarjeta"
        Me.txtTarjeta.Top = 2.0!
        Me.txtTarjeta.Width = 1.5!
        '
        'Label38
        '
        Me.Label38.Height = 0.3125!
        Me.Label38.HyperLink = Nothing
        Me.Label38.Left = 0.1875!
        Me.Label38.Name = "Label38"
        Me.Label38.Style = "text-align: left; font-weight: bold; font-size: 8.25pt; font-family: Tahoma"
        Me.Label38.Text = "Nombre Tarjetahabiente:"
        Me.Label38.Top = 2.25!
        Me.Label38.Width = 1.0!
        '
        'txtNombre
        '
        Me.txtNombre.Height = 0.1875!
        Me.txtNombre.Left = 1.1875!
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Style = "text-align: left; font-size: 8.25pt; font-family: Arial"
        Me.txtNombre.Text = "Nombre"
        Me.txtNombre.Top = 2.375!
        Me.txtNombre.Width = 1.5!
        '
        'Label39
        '
        Me.Label39.Height = 0.1875!
        Me.Label39.HyperLink = Nothing
        Me.Label39.Left = 0.1875!
        Me.Label39.Name = "Label39"
        Me.Label39.Style = "text-align: left; font-weight: bold; font-size: 8.25pt; font-family: Tahoma"
        Me.Label39.Text = "Saldo Actual:"
        Me.Label39.Top = 2.625!
        Me.Label39.Width = 1.0!
        '
        'txtSaldoActual
        '
        Me.txtSaldoActual.Height = 0.1875!
        Me.txtSaldoActual.Left = 1.1875!
        Me.txtSaldoActual.Name = "txtSaldoActual"
        Me.txtSaldoActual.Style = "text-align: left; font-size: 8.25pt; font-family: Arial"
        Me.txtSaldoActual.Text = "$0.00"
        Me.txtSaldoActual.Top = 2.625!
        Me.txtSaldoActual.Width = 1.5!
        '
        'Label40
        '
        Me.Label40.Height = 0.1875!
        Me.Label40.HyperLink = Nothing
        Me.Label40.Left = 0.1875!
        Me.Label40.Name = "Label40"
        Me.Label40.Style = "text-align: left; font-weight: bold; font-size: 8.25pt; font-family: Tahoma"
        Me.Label40.Text = "Pago Minimo:"
        Me.Label40.Top = 2.875!
        Me.Label40.Width = 1.0!
        '
        'txtPagoMinimo
        '
        Me.txtPagoMinimo.Height = 0.1875!
        Me.txtPagoMinimo.Left = 1.1875!
        Me.txtPagoMinimo.Name = "txtPagoMinimo"
        Me.txtPagoMinimo.Style = "text-align: left; font-size: 8.25pt; font-family: Arial"
        Me.txtPagoMinimo.Text = "$0.00"
        Me.txtPagoMinimo.Top = 2.875!
        Me.txtPagoMinimo.Width = 1.5!
        '
        'Label41
        '
        Me.Label41.Height = 0.1875!
        Me.Label41.HyperLink = Nothing
        Me.Label41.Left = 0.1875!
        Me.Label41.Name = "Label41"
        Me.Label41.Style = "text-align: left; font-weight: bold; font-size: 8.25pt; font-family: Tahoma"
        Me.Label41.Text = "Pago Vencido:"
        Me.Label41.Top = 3.125!
        Me.Label41.Width = 1.0!
        '
        'txtPagoVencido
        '
        Me.txtPagoVencido.Height = 0.1875!
        Me.txtPagoVencido.Left = 1.1875!
        Me.txtPagoVencido.Name = "txtPagoVencido"
        Me.txtPagoVencido.Style = "text-align: left; font-size: 8.25pt; font-family: Arial"
        Me.txtPagoVencido.Text = "$0.00"
        Me.txtPagoVencido.Top = 3.125!
        Me.txtPagoVencido.Width = 1.5!
        '
        'Label42
        '
        Me.Label42.Height = 0.1875!
        Me.Label42.HyperLink = Nothing
        Me.Label42.Left = 0.1875!
        Me.Label42.Name = "Label42"
        Me.Label42.Style = "text-align: left; font-weight: bold; font-size: 8.25pt; font-family: Tahoma"
        Me.Label42.Text = "Pago Total:"
        Me.Label42.Top = 3.375!
        Me.Label42.Width = 1.0!
        '
        'txtPagoTotal
        '
        Me.txtPagoTotal.Height = 0.1875!
        Me.txtPagoTotal.Left = 1.1875!
        Me.txtPagoTotal.Name = "txtPagoTotal"
        Me.txtPagoTotal.Style = "text-align: left; font-size: 8.25pt; font-family: Arial"
        Me.txtPagoTotal.Text = "$0.00"
        Me.txtPagoTotal.Top = 3.375!
        Me.txtPagoTotal.Width = 1.5!
        '
        'Label43
        '
        Me.Label43.Height = 0.3125!
        Me.Label43.HyperLink = Nothing
        Me.Label43.Left = 0.1875!
        Me.Label43.Name = "Label43"
        Me.Label43.Style = "text-align: left; font-weight: bold; font-size: 8.25pt; font-family: Tahoma; vert" & _
            "ical-align: top"
        Me.Label43.Text = "Fecha Límite de Pago:"
        Me.Label43.Top = 3.625!
        Me.Label43.Width = 1.0!
        '
        'txtFechaLimite
        '
        Me.txtFechaLimite.Height = 0.1875!
        Me.txtFechaLimite.Left = 1.1875!
        Me.txtFechaLimite.Name = "txtFechaLimite"
        Me.txtFechaLimite.Style = "text-align: left; font-size: 8.25pt; font-family: Arial"
        Me.txtFechaLimite.Text = "01 de Enero del 2015"
        Me.txtFechaLimite.Top = 3.75!
        Me.txtFechaLimite.Width = 1.5!
        '
        'Label44
        '
        Me.Label44.Height = 0.1875!
        Me.Label44.HyperLink = Nothing
        Me.Label44.Left = 1.625!
        Me.Label44.Name = "Label44"
        Me.Label44.Style = "text-align: left; font-weight: bold; font-size: 8.25pt; font-family: Tahoma"
        Me.Label44.Text = "CM:"
        Me.Label44.Top = 1.6875!
        Me.Label44.Width = 0.3125!
        '
        'txtConsecutivoPOS
        '
        Me.txtConsecutivoPOS.Height = 0.1875!
        Me.txtConsecutivoPOS.Left = 1.9375!
        Me.txtConsecutivoPOS.Name = "txtConsecutivoPOS"
        Me.txtConsecutivoPOS.Style = "text-align: left; font-size: 8.25pt; font-family: Arial"
        Me.txtConsecutivoPOS.Text = "0001"
        Me.txtConsecutivoPOS.Top = 1.6875!
        Me.txtConsecutivoPOS.Width = 0.75!
        '
        'Label12
        '
        Me.Label12.Height = 0.1875!
        Me.Label12.HyperLink = Nothing
        Me.Label12.Left = 0.1875!
        Me.Label12.Name = "Label12"
        Me.Label12.Style = "text-align: left; font-weight: bold; font-size: 8.25pt; font-family: Tahoma"
        Me.Label12.Text = "No. Tienda:"
        Me.Label12.Top = 0.6875!
        Me.Label12.Width = 1.0!
        '
        'txtNumTienda
        '
        Me.txtNumTienda.Height = 0.1875!
        Me.txtNumTienda.Left = 1.1875!
        Me.txtNumTienda.Name = "txtNumTienda"
        Me.txtNumTienda.Style = "text-align: left; font-size: 8.25pt; font-family: Arial"
        Me.txtNumTienda.Text = "01"
        Me.txtNumTienda.Top = 0.6875!
        Me.txtNumTienda.Width = 1.5!
        '
        'txtTienda
        '
        Me.txtTienda.Height = 0.7410001!
        Me.txtTienda.Left = 0.1875!
        Me.txtTienda.Name = "txtTienda"
        Me.txtTienda.Style = "text-align: center; font-size: 9.75pt; font-family: Arial"
        Me.txtTienda.Text = "000"
        Me.txtTienda.Top = 0.875!
        Me.txtTienda.Width = 2.5!
        '
        'Label8
        '
        Me.Label8.Height = 0.1875!
        Me.Label8.HyperLink = Nothing
        Me.Label8.Left = 0.1875!
        Me.Label8.Name = "Label8"
        Me.Label8.Style = "text-align: left; font-weight: bold; font-size: 8.25pt; font-family: Tahoma"
        Me.Label8.Text = "No. Caja:"
        Me.Label8.Top = 1.6875!
        Me.Label8.Width = 1.0!
        '
        'txtNumCaja
        '
        Me.txtNumCaja.Height = 0.1875!
        Me.txtNumCaja.Left = 1.1875!
        Me.txtNumCaja.Name = "txtNumCaja"
        Me.txtNumCaja.Style = "text-align: left; font-size: 8.25pt; font-family: Arial"
        Me.txtNumCaja.Text = "01"
        Me.txtNumCaja.Top = 1.6875!
        Me.txtNumCaja.Width = 0.375!
        '
        'PageFooter
        '
        Me.PageFooter.Height = 0.0!
        Me.PageFooter.Name = "PageFooter"
        '
        'rptSaldoDPCard
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
        CType(Me.Label39, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSaldoActual, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label40, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPagoMinimo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label41, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPagoVencido, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label42, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPagoTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label43, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaLimite, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label44, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtConsecutivoPOS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNumTienda, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTienda, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNumCaja, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

#End Region

End Class
