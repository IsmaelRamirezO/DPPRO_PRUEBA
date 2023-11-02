Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU
Imports System.Collections.Generic

Public Class rptVoucherBanamex
    Inherits DataDynamics.ActiveReports.ActiveReport

    Public Sub New(ByVal Datos As Dictionary(Of String, Object), ByVal EsCopia As Boolean, Optional ByVal IsVenta As Boolean = True)
        MyBase.New()
        InitializeComponent()

        Dim oCatalogoAlmacenesMgr As New CatalogoAlmacenesManager(oAppContext)
        Dim oAlmacen As Almacen
        Dim oSAPMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        oAlmacen = oCatalogoAlmacenesMgr.Load(oSAPMgr.Read_Centros)
        Me.txtTienda.Text = oAlmacen.Descripcion & vbCrLf & _
                            oAlmacen.DireccionCalle & vbCrLf & _
                            "C.P." & oAlmacen.DireccionCP & _
                            " TEL. " & oAlmacen.TelefonoNum & vbCrLf & _
                            "R.F.C. CDP-950126-9M5" & vbCrLf & _
                            oAlmacen.DireccionCiudad & ", " & oAlmacen.DireccionEstado
        txtNoAfilicacion.Text = CStr(Datos("trn_external_mer_id"))
        txtTerminal.Text = CStr(Datos("trn_internal_ter_id"))
        lblFecha.Text = "Fecha: " & CStr(Datos("trn_fechaTrans"))
        Me.txtTarjeta.Text = CStr(Datos("trn_card_number")).Substring(12, 4)
        txtCodigoAutorizacion.Text = CStr(Datos("trn_auth_code"))
        txtNoLote.Text = CStr(Datos("trn_bat_number_external"))
        txtNoTerminal.Text = CStr(Datos("trn_external_ter_id"))

        If EsCopia Then
            txtCopia.Text = "COPIA"
        Else
            txtCopia.Text = "ORIGINAL"
        End If
        If IsVenta Then
            Me.txtTotal.Text = Format(CDec(Datos("trn_amount")), "c")
            lblVenta.Text = "VENTA"
        Else
            Me.txtTotal.Text = Format(CDec(Datos("trn_amount")) * -1, "c")
            lblVenta.Text = "CANCELACION DE VENTA"
        End If
    End Sub
#Region "ActiveReports Designer generated code"
    Private WithEvents PageHeader As PageHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents PageFooter As PageFooter = Nothing
    Private txtFirma As TextBox = Nothing
    Private txtCodigoAutorizacion As TextBox = Nothing
    Private txtTienda As TextBox = Nothing
    Private txtNoAfilicacion As TextBox = Nothing
    Private lblNegocio As Label = Nothing
    Private lblTerminal As Label = Nothing
    Private txtTerminal As TextBox = Nothing
    Private lblVenta As Label = Nothing
    Private txtUsuario As TextBox = Nothing
    Private Line1 As Line = Nothing
    Friend WithEvents lblTotal As DataDynamics.ActiveReports.Label
    Friend WithEvents txtTotal As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblFecha As DataDynamics.ActiveReports.Label
    Friend WithEvents txtEmisor As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtTarjeta As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtFechaVencimiento As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtNoTerminal As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtNoTurno As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtNoSeguimiento As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblPagare As DataDynamics.ActiveReports.Label
    Friend WithEvents lblPagare2 As DataDynamics.ActiveReports.Label
    Friend WithEvents txtCopia As DataDynamics.ActiveReports.Label
    Private txtNoLote As TextBox = Nothing
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptVoucherBanamex))
        Me.Detail = New DataDynamics.ActiveReports.Detail()
        Me.PageHeader = New DataDynamics.ActiveReports.PageHeader()
        Me.txtFirma = New DataDynamics.ActiveReports.TextBox()
        Me.txtCodigoAutorizacion = New DataDynamics.ActiveReports.TextBox()
        Me.txtTienda = New DataDynamics.ActiveReports.TextBox()
        Me.txtNoAfilicacion = New DataDynamics.ActiveReports.TextBox()
        Me.lblNegocio = New DataDynamics.ActiveReports.Label()
        Me.lblTerminal = New DataDynamics.ActiveReports.Label()
        Me.txtTerminal = New DataDynamics.ActiveReports.TextBox()
        Me.lblVenta = New DataDynamics.ActiveReports.Label()
        Me.txtUsuario = New DataDynamics.ActiveReports.TextBox()
        Me.Line1 = New DataDynamics.ActiveReports.Line()
        Me.txtNoLote = New DataDynamics.ActiveReports.TextBox()
        Me.lblTotal = New DataDynamics.ActiveReports.Label()
        Me.txtTotal = New DataDynamics.ActiveReports.TextBox()
        Me.lblFecha = New DataDynamics.ActiveReports.Label()
        Me.txtEmisor = New DataDynamics.ActiveReports.TextBox()
        Me.txtTarjeta = New DataDynamics.ActiveReports.TextBox()
        Me.txtFechaVencimiento = New DataDynamics.ActiveReports.TextBox()
        Me.txtNoTerminal = New DataDynamics.ActiveReports.TextBox()
        Me.txtNoTurno = New DataDynamics.ActiveReports.TextBox()
        Me.txtNoSeguimiento = New DataDynamics.ActiveReports.TextBox()
        Me.lblPagare = New DataDynamics.ActiveReports.Label()
        Me.PageFooter = New DataDynamics.ActiveReports.PageFooter()
        Me.lblPagare2 = New DataDynamics.ActiveReports.Label()
        Me.txtCopia = New DataDynamics.ActiveReports.Label()
        CType(Me.txtFirma, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCodigoAutorizacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTienda, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNoAfilicacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblNegocio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTerminal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTerminal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblVenta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtUsuario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNoLote, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEmisor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTarjeta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaVencimiento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNoTerminal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNoTurno, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNoSeguimiento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblPagare, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblPagare2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCopia, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.PageHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtFirma, Me.txtCodigoAutorizacion, Me.txtTienda, Me.txtNoAfilicacion, Me.lblNegocio, Me.lblTerminal, Me.txtTerminal, Me.lblVenta, Me.txtUsuario, Me.Line1, Me.txtNoLote, Me.lblTotal, Me.txtTotal, Me.lblFecha, Me.txtEmisor, Me.txtTarjeta, Me.txtFechaVencimiento, Me.txtNoTerminal, Me.txtNoTurno, Me.txtNoSeguimiento, Me.lblPagare, Me.lblPagare2, Me.txtCopia})
        Me.PageHeader.Height = 5.375!
        Me.PageHeader.Name = "PageHeader"
        '
        'txtFirma
        '
        Me.txtFirma.Height = 0.1875!
        Me.txtFirma.Left = 0.197!
        Me.txtFirma.Name = "txtFirma"
        Me.txtFirma.Style = "text-align: center; font-size: 8.25pt; font-family: Arial"
        Me.txtFirma.Text = "Firma"
        Me.txtFirma.Top = 3.39!
        Me.txtFirma.Width = 0.771!
        '
        'txtCodigoAutorizacion
        '
        Me.txtCodigoAutorizacion.Height = 0.1875!
        Me.txtCodigoAutorizacion.Left = 1.272!
        Me.txtCodigoAutorizacion.Name = "txtCodigoAutorizacion"
        Me.txtCodigoAutorizacion.Style = "text-align: left; font-size: 8.25pt; font-family: Arial"
        Me.txtCodigoAutorizacion.Top = 2.304!
        Me.txtCodigoAutorizacion.Width = 1.3015!
        '
        'txtTienda
        '
        Me.txtTienda.Height = 0.7410001!
        Me.txtTienda.Left = 0.062!
        Me.txtTienda.Name = "txtTienda"
        Me.txtTienda.Style = "text-align: center; font-size: 9.75pt; font-family: Arial"
        Me.txtTienda.Text = "000"
        Me.txtTienda.Top = 0.0!
        Me.txtTienda.Width = 2.5!
        '
        'txtNoAfilicacion
        '
        Me.txtNoAfilicacion.Height = 0.1875!
        Me.txtNoAfilicacion.Left = 1.0625!
        Me.txtNoAfilicacion.Name = "txtNoAfilicacion"
        Me.txtNoAfilicacion.Style = "text-align: right; font-size: 8.25pt; font-family: Arial"
        Me.txtNoAfilicacion.Text = "01"
        Me.txtNoAfilicacion.Top = 0.8520563!
        Me.txtNoAfilicacion.Width = 1.4905!
        '
        'lblNegocio
        '
        Me.lblNegocio.Height = 0.1875!
        Me.lblNegocio.HyperLink = Nothing
        Me.lblNegocio.Left = 0.0625!
        Me.lblNegocio.Name = "lblNegocio"
        Me.lblNegocio.Style = "text-align: left; font-weight: bold; font-size: 8.25pt; font-family: Tahoma"
        Me.lblNegocio.Text = "Negocio:"
        Me.lblNegocio.Top = 0.8520563!
        Me.lblNegocio.Width = 1.0!
        '
        'lblTerminal
        '
        Me.lblTerminal.Height = 0.1875!
        Me.lblTerminal.HyperLink = Nothing
        Me.lblTerminal.Left = 0.0625!
        Me.lblTerminal.Name = "lblTerminal"
        Me.lblTerminal.Style = "text-align: left; font-weight: bold; font-size: 8.25pt; font-family: Tahoma"
        Me.lblTerminal.Text = "Terminal:"
        Me.lblTerminal.Top = 1.102056!
        Me.lblTerminal.Width = 1.0!
        '
        'txtTerminal
        '
        Me.txtTerminal.Height = 0.1875!
        Me.txtTerminal.Left = 1.0625!
        Me.txtTerminal.Name = "txtTerminal"
        Me.txtTerminal.Style = "text-align: left; font-size: 8.25pt; font-family: Arial"
        Me.txtTerminal.Text = Nothing
        Me.txtTerminal.Top = 1.102056!
        Me.txtTerminal.Width = 1.5!
        '
        'lblVenta
        '
        Me.lblVenta.Height = 0.1875!
        Me.lblVenta.HyperLink = Nothing
        Me.lblVenta.Left = 0.06199998!
        Me.lblVenta.Name = "lblVenta"
        Me.lblVenta.Style = "text-align: center; font-weight: bold; font-size: 8.25pt; font-family: Tahoma"
        Me.lblVenta.Text = "VENTA"
        Me.lblVenta.Top = 1.593!
        Me.lblVenta.Width = 2.49!
        '
        'txtUsuario
        '
        Me.txtUsuario.Height = 0.1875!
        Me.txtUsuario.Left = 1.208!
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.Style = "text-align: center; font-size: 8.25pt; font-family: Arial"
        Me.txtUsuario.Text = "RETAIL"
        Me.txtUsuario.Top = 1.842509!
        Me.txtUsuario.Width = 1.3535!
        '
        'Line1
        '
        Me.Line1.Height = 0.0004999638!
        Me.Line1.Left = 0.726!
        Me.Line1.LineWeight = 1.0!
        Me.Line1.Name = "Line1"
        Me.Line1.Top = 3.5765!
        Me.Line1.Width = 1.458!
        Me.Line1.X1 = 2.184!
        Me.Line1.X2 = 0.726!
        Me.Line1.Y1 = 3.577!
        Me.Line1.Y2 = 3.5765!
        '
        'txtNoLote
        '
        Me.txtNoLote.Height = 0.1875!
        Me.txtNoLote.Left = 0.06150001!
        Me.txtNoLote.Name = "txtNoLote"
        Me.txtNoLote.Style = "ddo-char-set: 1; text-align: center; font-weight: bold; font-size: 8.25pt; font-f" & _
    "amily: Tahoma"
        Me.txtNoLote.Text = Nothing
        Me.txtNoLote.Top = 2.573056!
        Me.txtNoLote.Visible = False
        Me.txtNoLote.Width = 2.5!
        '
        'lblTotal
        '
        Me.lblTotal.Height = 0.1875!
        Me.lblTotal.HyperLink = Nothing
        Me.lblTotal.Left = 0.062!
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Style = "text-align: left; font-weight: bold; font-size: 8.25pt; font-family: Tahoma"
        Me.lblTotal.Text = "Total:"
        Me.lblTotal.Top = 2.823556!
        Me.lblTotal.Width = 1.0!
        '
        'txtTotal
        '
        Me.txtTotal.Height = 0.1875!
        Me.txtTotal.Left = 1.062!
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Style = "text-align: left; font-size: 8.25pt; font-family: Arial"
        Me.txtTotal.Text = "$0.00"
        Me.txtTotal.Top = 2.823556!
        Me.txtTotal.Width = 1.5!
        '
        'lblFecha
        '
        Me.lblFecha.Height = 0.2362205!
        Me.lblFecha.HyperLink = Nothing
        Me.lblFecha.Left = 0.062!
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Style = "font-family: Tahoma; font-weight: bold; font-size: 8.25pt; text-align: center"
        Me.lblFecha.Text = ""
        Me.lblFecha.Top = 1.32!
        Me.lblFecha.Width = 2.49!
        '
        'txtEmisor
        '
        Me.txtEmisor.Height = 0.1875!
        Me.txtEmisor.Left = 0.062!
        Me.txtEmisor.Name = "txtEmisor"
        Me.txtEmisor.Style = "text-align: center; font-size: 8.25pt; font-family: Arial"
        Me.txtEmisor.Text = "VISA"
        Me.txtEmisor.Top = 1.843!
        Me.txtEmisor.Width = 1.146!
        '
        'txtTarjeta
        '
        Me.txtTarjeta.Height = 0.1875!
        Me.txtTarjeta.Left = 0.06200004!
        Me.txtTarjeta.Name = "txtTarjeta"
        Me.txtTarjeta.Style = "text-align: left; font-size: 8.25pt; font-family: Arial"
        Me.txtTarjeta.Text = Nothing
        Me.txtTarjeta.Top = 2.116!
        Me.txtTarjeta.Width = 2.501!
        '
        'txtFechaVencimiento
        '
        Me.txtFechaVencimiento.Height = 0.1875!
        Me.txtFechaVencimiento.Left = 0.062!
        Me.txtFechaVencimiento.Name = "txtFechaVencimiento"
        Me.txtFechaVencimiento.Style = "text-align: left; font-size: 8.25pt; font-family: Arial"
        Me.txtFechaVencimiento.Top = 2.304!
        Me.txtFechaVencimiento.Width = 1.208!
        '
        'txtNoTerminal
        '
        Me.txtNoTerminal.Height = 0.188!
        Me.txtNoTerminal.Left = 0.157!
        Me.txtNoTerminal.Name = "txtNoTerminal"
        Me.txtNoTerminal.Style = "text-align: left; font-size: 8.25pt; font-family: Arial"
        Me.txtNoTerminal.Text = Nothing
        Me.txtNoTerminal.Top = 3.71!
        Me.txtNoTerminal.Width = 0.733!
        '
        'txtNoTurno
        '
        Me.txtNoTurno.Height = 0.188!
        Me.txtNoTurno.Left = 0.88!
        Me.txtNoTurno.Name = "txtNoTurno"
        Me.txtNoTurno.Style = "text-align: left; font-size: 8.25pt; font-family: Arial"
        Me.txtNoTurno.Text = Nothing
        Me.txtNoTurno.Top = 3.71!
        Me.txtNoTurno.Width = 0.733!
        '
        'txtNoSeguimiento
        '
        Me.txtNoSeguimiento.Height = 0.188!
        Me.txtNoSeguimiento.Left = 1.627!
        Me.txtNoSeguimiento.Name = "txtNoSeguimiento"
        Me.txtNoSeguimiento.Style = "text-align: left; font-size: 8.25pt; font-family: Arial"
        Me.txtNoSeguimiento.Text = Nothing
        Me.txtNoSeguimiento.Top = 3.71!
        Me.txtNoSeguimiento.Width = 0.733!
        '
        'lblPagare
        '
        Me.lblPagare.Height = 0.625!
        Me.lblPagare.HyperLink = Nothing
        Me.lblPagare.Left = 0.052!
        Me.lblPagare.Name = "lblPagare"
        Me.lblPagare.Style = "text-align: center; font-weight: normal; font-size: 8.25pt; font-family: Tahoma"
        Me.lblPagare.Text = "CUBRIRE INCONDICIONALMENTE EL TOTAL DE ESTE PAGARE A LA ORDEN DEL EMISOR SEGÚN CO" & _
    "NTRATO DE DONDE DERIVA ESTA TARJETA Y DICHO PAGARE"
        Me.lblPagare.Top = 4.0!
        Me.lblPagare.Width = 2.5!
        '
        'PageFooter
        '
        Me.PageFooter.Height = 0.0!
        Me.PageFooter.Name = "PageFooter"
        '
        'lblPagare2
        '
        Me.lblPagare2.Height = 0.3439999!
        Me.lblPagare2.HyperLink = Nothing
        Me.lblPagare2.Left = 0.052!
        Me.lblPagare2.Name = "lblPagare2"
        Me.lblPagare2.Style = "text-align: center; font-weight: normal; font-size: 8.25pt; font-family: Tahoma"
        Me.lblPagare2.Text = "Negociable y unicamente con Instituciones Bancarias"
        Me.lblPagare2.Top = 4.687!
        Me.lblPagare2.Width = 2.5!
        '
        'txtCopia
        '
        Me.txtCopia.Height = 0.2399998!
        Me.txtCopia.HyperLink = Nothing
        Me.txtCopia.Left = 0.062!
        Me.txtCopia.Name = "txtCopia"
        Me.txtCopia.Style = "text-align: center; font-weight: normal; font-size: 8.25pt; font-family: Tahoma"
        Me.txtCopia.Text = "Original"
        Me.txtCopia.Top = 5.135!
        Me.txtCopia.Width = 2.5!
        '
        'rptVoucherBanamex
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
        CType(Me.txtCodigoAutorizacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTienda, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNoAfilicacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblNegocio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTerminal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTerminal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblVenta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtUsuario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNoLote, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEmisor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTarjeta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaVencimiento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNoTerminal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNoTurno, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNoSeguimiento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblPagare, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblPagare2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCopia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

#End Region

    Private Sub PageHeader_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles PageHeader.Format

    End Sub
End Class
