Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes
Imports DportenisPro.DPTienda.ApplicationUnits.FacturasFormaPago
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU

Public Class rptOtrosPagos
    Inherits DataDynamics.ActiveReports.ActiveReport

    Dim oReporteFormapago As ReporteDetalleFormasPago
    Dim oLetras As cImprimirFactura
    Dim oOP As OtrosPagos

    Public Sub New(ByVal sNoOrden As String, ByVal Concepto As String)

        MyBase.New()
        InitializeComponent()

        oOP = New OtrosPagos(sNoOrden.Trim, Concepto, 2)

        Me.tbNoOrden.Value = sNoOrden.Trim
        Me.tbReferencia.Value = oOP.Referencia.Trim
        Me.tbAnticipo.Value = oOP.TotalPago

        Select Case Concepto.Trim.ToUpper
            Case "EC"
                Me.LblCopia.Text = "ANTICIPO DE ECOMMERCE"
        End Select

        lblCaja.Text = "CAJA :" & CStr(oOP.CodCaja).Trim

        oLetras = New cImprimirFactura

        tbTotalLetras.Text &= oLetras.Letras(Decimal.Round(oOP.TotalPago, 2)).ToUpper

        oLetras = Nothing

        tbPlayer.Text = "AXY" 'CodVendedor.Trim

        Dim oCatalogoAlmacenesMgr As New CatalogoAlmacenesManager(oAppContext)
        Dim oAlmacen As Almacen
        Dim oSAPMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        oAlmacen = oCatalogoAlmacenesMgr.Load(oSAPMgr.Read_Centros) '"2" & oAppContext.ApplicationConfiguration.Almacen)

        tbLugarFecha.Text = oAlmacen.DireccionCiudad & ", " & oAlmacen.DireccionEstado & ", " & UCase(Format(Now, "dd-MMM-yy hh:mm tt"))

        Me.txtInfoSuc.Text = oAlmacen.Descripcion & vbLf & oAlmacen.DireccionCalle & vbLf & "C.P." & oAlmacen.DireccionCP & " TEL. " & oAlmacen.TelefonoNum & vbLf & _
                             "R.F.C. CDP-950126-9M5" & vbLf & oAlmacen.DireccionCiudad & ", " & oAlmacen.DireccionEstado
        oAlmacen = Nothing
        oCatalogoAlmacenesMgr = Nothing

        oReporteFormapago = New ReporteDetalleFormasPago(oOP.OtrosPagosID, 4)
        Me.SubReport1.Report = oReporteFormapago
        Me.SubReport1.Report.DataSource = oReporteFormapago.DataSource
        Me.SubReport1.Report.DataMember = oReporteFormapago.DataMember

        If oConfigCierreFI.NotaOtrosPagosEC.Trim <> "" Then Me.tbNotas.Value = oConfigCierreFI.NotaOtrosPagosEC.Trim

    End Sub

#Region "ActiveReports Designer generated code"
    Private WithEvents ReportHeader As ReportHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents ReportFooter As ReportFooter = Nothing
	Private tbReferencia As TextBox = Nothing
	Private tbLugarFecha As TextBox = Nothing
	Private tbTipoVenta As TextBox = Nothing
	Private lblCaja As Label = Nothing
	Private Label16 As Label = Nothing
	Private LblCopia As Label = Nothing
	Private lblCancelacion As Label = Nothing
	Private tbNoOrden As TextBox = Nothing
	Private txtInfoSuc As TextBox = Nothing
	Private Label36 As Label = Nothing
	Private Label37 As Label = Nothing
	Private tbAnticipo As TextBox = Nothing
	Private tbTotalLetras As TextBox = Nothing
	Private Label1 As Label = Nothing
	Private tbPlayer As TextBox = Nothing
	Private Label2 As Label = Nothing
	Private SubReport1 As SubReport = Nothing
	Private tbNotas As TextBox = Nothing
	Private Label8 As Label = Nothing
	Private Label9 As Label = Nothing
	Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptOtrosPagos))
            Me.Detail = New DataDynamics.ActiveReports.Detail()
            Me.ReportHeader = New DataDynamics.ActiveReports.ReportHeader()
            Me.ReportFooter = New DataDynamics.ActiveReports.ReportFooter()
            Me.tbReferencia = New DataDynamics.ActiveReports.TextBox()
            Me.tbLugarFecha = New DataDynamics.ActiveReports.TextBox()
            Me.tbTipoVenta = New DataDynamics.ActiveReports.TextBox()
            Me.lblCaja = New DataDynamics.ActiveReports.Label()
            Me.Label16 = New DataDynamics.ActiveReports.Label()
            Me.LblCopia = New DataDynamics.ActiveReports.Label()
            Me.lblCancelacion = New DataDynamics.ActiveReports.Label()
            Me.tbNoOrden = New DataDynamics.ActiveReports.TextBox()
            Me.txtInfoSuc = New DataDynamics.ActiveReports.TextBox()
            Me.Label36 = New DataDynamics.ActiveReports.Label()
            Me.Label37 = New DataDynamics.ActiveReports.Label()
            Me.tbAnticipo = New DataDynamics.ActiveReports.TextBox()
            Me.tbTotalLetras = New DataDynamics.ActiveReports.TextBox()
            Me.Label1 = New DataDynamics.ActiveReports.Label()
            Me.tbPlayer = New DataDynamics.ActiveReports.TextBox()
            Me.Label2 = New DataDynamics.ActiveReports.Label()
            Me.SubReport1 = New DataDynamics.ActiveReports.SubReport()
            Me.tbNotas = New DataDynamics.ActiveReports.TextBox()
            Me.Label8 = New DataDynamics.ActiveReports.Label()
            Me.Label9 = New DataDynamics.ActiveReports.Label()
            CType(Me.tbReferencia,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbLugarFecha,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbTipoVenta,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblCaja,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label16,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.LblCopia,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblCancelacion,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbNoOrden,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtInfoSuc,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label36,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label37,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbAnticipo,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbTotalLetras,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label1,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbPlayer,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbNotas,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label8,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label9,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
            '
            'Detail
            '
            Me.Detail.CanShrink = true
            Me.Detail.ColumnSpacing = 0!
            Me.Detail.Height = 0!
            Me.Detail.KeepTogether = true
            Me.Detail.Name = "Detail"
            '
            'ReportHeader
            '
            Me.ReportHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.tbReferencia, Me.tbLugarFecha, Me.tbTipoVenta, Me.lblCaja, Me.Label16, Me.LblCopia, Me.lblCancelacion, Me.tbNoOrden, Me.txtInfoSuc, Me.Label36, Me.Label37, Me.tbAnticipo, Me.tbTotalLetras, Me.Label1, Me.tbPlayer, Me.Label2, Me.SubReport1, Me.tbNotas, Me.Label8, Me.Label9})
            Me.ReportHeader.Height = 5.874306!
            Me.ReportHeader.Name = "ReportHeader"
            '
            'ReportFooter
            '
            Me.ReportFooter.Height = 0!
            Me.ReportFooter.Name = "ReportFooter"
            '
            'tbReferencia
            '
            Me.tbReferencia.CanShrink = true
            Me.tbReferencia.Height = 0.1574802!
            Me.tbReferencia.Left = 0.2559055!
            Me.tbReferencia.Name = "tbReferencia"
            Me.tbReferencia.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 9.75pt; font-fa"& _ 
                "mily: Arial"
            Me.tbReferencia.Text = "Referencia"
            Me.tbReferencia.Top = 2.928477!
            Me.tbReferencia.Width = 2.431595!
            '
            'tbLugarFecha
            '
            Me.tbLugarFecha.Height = 0.15748!
            Me.tbLugarFecha.Left = 0.2559055!
            Me.tbLugarFecha.Name = "tbLugarFecha"
            Me.tbLugarFecha.Style = "ddo-char-set: 0; font-size: 9pt; font-family: Tahoma"
            Me.tbLugarFecha.Text = "Lugar Fecha"
            Me.tbLugarFecha.Top = 2.153543!
            Me.tbLugarFecha.Width = 2.46063!
            '
            'tbTipoVenta
            '
            Me.tbTipoVenta.Height = 0.15748!
            Me.tbTipoVenta.Left = 0.2559054!
            Me.tbTipoVenta.Name = "tbTipoVenta"
            Me.tbTipoVenta.Style = "ddo-char-set: 0; font-size: 9pt; font-family: Tahoma"
            Me.tbTipoVenta.Text = "OTROS PAGOS"
            Me.tbTipoVenta.Top = 1.953576!
            Me.tbTipoVenta.Width = 1.5625!
            '
            'lblCaja
            '
            Me.lblCaja.Height = 0.1574798!
            Me.lblCaja.HyperLink = Nothing
            Me.lblCaja.Left = 0.2559055!
            Me.lblCaja.Name = "lblCaja"
            Me.lblCaja.Style = "ddo-char-set: 0; font-weight: normal; font-size: 9pt; font-family: Tahoma"
            Me.lblCaja.Text = "CAJA"
            Me.lblCaja.Top = 1.754921!
            Me.lblCaja.Width = 1.25!
            '
            'Label16
            '
            Me.Label16.Height = 0.1574803!
            Me.Label16.HyperLink = Nothing
            Me.Label16.Left = 0.25!
            Me.Label16.Name = "Label16"
            Me.Label16.Style = "text-align: center; font-weight: bold; font-size: 9pt; font-family: Tahoma"
            Me.Label16.Text = "SUCURSAL:"
            Me.Label16.Top = 0.6973423!
            Me.Label16.Width = 2.43061!
            '
            'LblCopia
            '
            Me.LblCopia.Height = 0.1574805!
            Me.LblCopia.HyperLink = Nothing
            Me.LblCopia.Left = 0.25!
            Me.LblCopia.Name = "LblCopia"
            Me.LblCopia.Style = "text-align: center; font-weight: bold; font-size: 8.25pt; font-family: Tahoma; ve"& _ 
                "rtical-align: top"
            Me.LblCopia.Text = "COPIA DE FACTURA"
            Me.LblCopia.Top = 1.158465!
            Me.LblCopia.Width = 2.431103!
            '
            'lblCancelacion
            '
            Me.lblCancelacion.Height = 0.1574803!
            Me.lblCancelacion.HyperLink = Nothing
            Me.lblCancelacion.Left = 0.2559054!
            Me.lblCancelacion.Name = "lblCancelacion"
            Me.lblCancelacion.Style = "font-weight: bold; font-size: 9pt; font-family: Tahoma"
            Me.lblCancelacion.Text = "No. Orden:"
            Me.lblCancelacion.Top = 1.553642!
            Me.lblCancelacion.Width = 1.318898!
            '
            'tbNoOrden
            '
            Me.tbNoOrden.Height = 0.1574803!
            Me.tbNoOrden.Left = 1.64042!
            Me.tbNoOrden.Name = "tbNoOrden"
            Me.tbNoOrden.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 9pt; font-fami"& _ 
                "ly: Tahoma"
            Me.tbNoOrden.Text = "256321"
            Me.tbNoOrden.Top = 1.565453!
            Me.tbNoOrden.Width = 1.049869!
            '
            'txtInfoSuc
            '
            Me.txtInfoSuc.Height = 0.1875!
            Me.txtInfoSuc.Left = 0.25!
            Me.txtInfoSuc.Name = "txtInfoSuc"
            Me.txtInfoSuc.Style = "text-align: center; font-size: 8.25pt"
            Me.txtInfoSuc.Text = "InfoSuc"
            Me.txtInfoSuc.Top = 0.875!
            Me.txtInfoSuc.Width = 2.4245!
            '
            'Label36
            '
            Me.Label36.Height = 0.1875!
            Me.Label36.HyperLink = Nothing
            Me.Label36.Left = 0.25!
            Me.Label36.Name = "Label36"
            Me.Label36.Style = "font-weight: bold; font-size: 9.75pt; font-family: Arial"
            Me.Label36.Text = "REFERENCIA:"
            Me.Label36.Top = 2.5!
            Me.Label36.Width = 2.461!
            '
            'Label37
            '
            Me.Label37.Height = 0.1875!
            Me.Label37.HyperLink = Nothing
            Me.Label37.Left = 0.25!
            Me.Label37.Name = "Label37"
            Me.Label37.Style = "font-weight: bold; font-size: 9.75pt; font-family: Arial"
            Me.Label37.Text = "ANTICIPO:"
            Me.Label37.Top = 3.375!
            Me.Label37.Width = 1!
            '
            'tbAnticipo
            '
            Me.tbAnticipo.Height = 0.1875!
            Me.tbAnticipo.Left = 1.75!
            Me.tbAnticipo.Name = "tbAnticipo"
            Me.tbAnticipo.OutputFormat = resources.GetString("tbAnticipo.OutputFormat")
            Me.tbAnticipo.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 9pt; font-famil"& _ 
                "y: Arial"
            Me.tbAnticipo.Text = "$ 599.00"
            Me.tbAnticipo.Top = 3.375!
            Me.tbAnticipo.Width = 0.944882!
            '
            'tbTotalLetras
            '
            Me.tbTotalLetras.Height = 0.2!
            Me.tbTotalLetras.Left = 0.2559055!
            Me.tbTotalLetras.Name = "tbTotalLetras"
            Me.tbTotalLetras.Style = "font-weight: normal; font-size: 8.25pt; font-family: Tahoma"
            Me.tbTotalLetras.Top = 3.90994!
            Me.tbTotalLetras.Width = 2.440945!
            '
            'Label1
            '
            Me.Label1.Height = 0.1786415!
            Me.Label1.HyperLink = Nothing
            Me.Label1.Left = 0.25!
            Me.Label1.Name = "Label1"
            Me.Label1.Style = "text-align: right; font-weight: normal; font-size: 8.25pt; font-family: Tahoma"
            Me.Label1.Text = "PLAYER:"
            Me.Label1.Top = 4.1875!
            Me.Label1.Width = 0.5!
            '
            'tbPlayer
            '
            Me.tbPlayer.Height = 0.2!
            Me.tbPlayer.Left = 0.875!
            Me.tbPlayer.Name = "tbPlayer"
            Me.tbPlayer.Style = "ddo-char-set: 0; text-align: left; font-weight: normal; font-size: 8.25pt; font-f"& _ 
                "amily: Tahoma"
            Me.tbPlayer.Top = 4.1875!
            Me.tbPlayer.Width = 0.5625!
            '
            'Label2
            '
            Me.Label2.Height = 0.1412403!
            Me.Label2.HyperLink = Nothing
            Me.Label2.Left = 0.25!
            Me.Label2.Name = "Label2"
            Me.Label2.Style = "text-align: right; font-weight: normal; font-size: 8.25pt; font-family: Tahoma"
            Me.Label2.Text = "PAGO:"
            Me.Label2.Top = 4.5!
            Me.Label2.Visible = false
            Me.Label2.Width = 0.3937007!
            '
            'SubReport1
            '
            Me.SubReport1.CloseBorder = false
            Me.SubReport1.Height = 0.6924215!
            Me.SubReport1.Left = 0.875!
            Me.SubReport1.Name = "SubReport1"
            Me.SubReport1.Report = Nothing
            Me.SubReport1.Top = 4.5!
            Me.SubReport1.Width = 1.6875!
            '
            'tbNotas
            '
            Me.tbNotas.CanShrink = true
            Me.tbNotas.Height = 0.4025593!
            Me.tbNotas.Left = 0.2559055!
            Me.tbNotas.Name = "tbNotas"
            Me.tbNotas.Style = "text-align: center; font-weight: normal; font-size: 8.25pt; font-family: Tahoma"
            Me.tbNotas.Text = "La entrega de mercancía quedará a disponibilidad de producto."
            Me.tbNotas.Top = 5.34744!
            Me.tbNotas.Width = 2.440945!
            '
            'Label8
            '
            Me.Label8.Height = 0.1574803!
            Me.Label8.HyperLink = Nothing
            Me.Label8.Left = 0.25!
            Me.Label8.Name = "Label8"
            Me.Label8.Style = "text-align: center; font-weight: bold; font-size: 9pt; font-family: Tahoma"
            Me.Label8.Text = "COMERCIAL D'PORTENIS, S.A. DE C.V."
            Me.Label8.Top = 0.125!
            Me.Label8.Width = 2.4375!
            '
            'Label9
            '
            Me.Label9.Height = 0.4050198!
            Me.Label9.HyperLink = Nothing
            Me.Label9.Left = 0.25!
            Me.Label9.Name = "Label9"
            Me.Label9.Style = "text-align: center; font-size: 9pt; font-family: Tahoma"
            Me.Label9.Text = "Matriz: Melchor Ocampo #1005 Centro     Mazatlán, Sin."
            Me.Label9.Top = 0.2824802!
            Me.Label9.Width = 2.41437!
            '
            'ActiveReport1
            '
            Me.MasterReport = false
            Me.PageSettings.DefaultPaperSize = false
            Me.PageSettings.Margins.Bottom = 0!
            Me.PageSettings.Margins.Left = 0!
            Me.PageSettings.Margins.Right = 0!
            Me.PageSettings.Margins.Top = 0!
            Me.PageSettings.PaperHeight = 11.69028!
            Me.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Custom
            Me.PageSettings.PaperName = "Custom paper"
            Me.PageSettings.PaperWidth = 2.979861!
            Me.PrintWidth = 2.8125!
            Me.Sections.Add(Me.ReportHeader)
            Me.Sections.Add(Me.Detail)
            Me.Sections.Add(Me.ReportFooter)
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo"& _ 
                        "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit", "Heading1", "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei"& _ 
                        "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit", "Heading2", "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo"& _ 
                        "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit", "Heading3", "Normal"))
            CType(Me.tbReferencia,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbLugarFecha,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbTipoVenta,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblCaja,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label16,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.LblCopia,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblCancelacion,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbNoOrden,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtInfoSuc,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label36,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label37,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbAnticipo,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbTotalLetras,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label1,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbPlayer,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbNotas,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label8,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label9,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        
	End Sub

#End Region

End Class
