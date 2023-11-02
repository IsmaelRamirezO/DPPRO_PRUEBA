Imports System
Imports System.Data
Imports System.Data.SqlClient

Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Imports DportenisPro.DPTienda.Reports.Ventas
Imports DportenisPro.DPTienda.ApplicationUnits.CierreDiaAU
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes
Imports DportenisPro.DPTienda.ApplicationUnits.Facturas
Imports DportenisPro.DPTienda.ApplicationUnits.AbonosApartadosAU
Imports DportenisPro.DPTienda.ApplicationUnits.AbonoCreditoDirectoTienda
Imports System.Collections.Generic



Public Class RptCierredeDia
    Inherits DataDynamics.ActiveReports.ActiveReport

#Region "Variables Miembros"

    Dim dlFecha As Date

    Private oCierreDiasMgr As New CierreDiaManager(oAppContext, oAppSAPConfig)

    Dim dtValeCajaReport As New DataTable("ValesCaja")
    Friend WithEvents ReporteDevolucionTarjeta As DataDynamics.ActiveReports.SubReport
    Friend WithEvents SubReport1 As DataDynamics.ActiveReports.SubReport
    Friend WithEvents ReporteVentasTotalesMicrocredito As DataDynamics.ActiveReports.SubReport

    Dim strConnectionString As String = oAppContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString

#End Region

    Public Sub New(ByVal dFecha As Date)

        MyBase.New()

        dlFecha = dFecha
        InitializeComponent()

        Sm_ActionPrintReporteVentasFacturadas()
        Sm_ActionPrintReporteNotasCredito()
        Sm_ActionPrintReporteValeCaja()
        'Sm_ActionPrintReporteFacturasLiquidadas()
        'Sm_ActionPrintReporteCancelacionApartados()
        Sm_ActionPrintReporteAbonosApartados()
        'VentasVale()
        'Sm_ActionPrintReporteAnalisisVtaPlayers()
        'Sm_ActionPrintReporteRetiros()
        Sm_ActionPrintReporteAbonosCxC()
        ActionPreviewNotasVentaManuales()
        '---------------------------------------------------------------------------------------
        'FLIZARRAGA 26/09/2014: Se agrego el detalle de pedidos facturados y no facturados del 
        '                       Si Hay y los pagos de ecommerce.
        '---------------------------------------------------------------------------------------
        Sm_ActionPrintReportePedidosFacturados()
        Sm_ActionPrintReportePedidosNoFacturados()
        '--------------------------------------------------------------------------------------
        'FLIZARRAGA 27/09/2014: Solo si esta configurada la tienda agregara el reporte de pagos
        '                       ecommerce.
        '--------------------------------------------------------------------------------------
        If oConfigCierreFI.RecibirOtrosPagos = True Then
            Me.OtrosPagos.Visible = True
            Sm_ActionPrintReportePagosEcommerce()
            '-----------------------------------------------------------------------------------------------------------------------------------
            'RGERMAIN 01.09.2015: Agregamos el reporte de abonos a los creditos DPCard
            '-----------------------------------------------------------------------------------------------------------------------------------
            If oConfigCierreFI.AplicaDPCard Then
                Sm_ActionPrintReporteAbonosDPCard()
            Else
                Me.PagosDPCard.Visible = False
                Me.SubReport14.Top = 2.75
                Me.SubReport15.Top = 3
            End If
        Else
            Me.OtrosPagos.Visible = False
        End If
        '----------------------------------------------------------------------------------------------------------------------------------------
        'RGERMAIN 26/11/2014: Solo si no esta configurada la opcion de mostrar reporte de auditoria se muestra el anterior reporte de concentrador
        '                     de cierre de caja
        '----------------------------------------------------------------------------------------------------------------------------------------
        If oConfigCierreFI.MostrarConcenAUD Then
            Me.SubReport12.Visible = False
        Else
            Me.txtNoPagina.Visible = False
            Sm_Concentrado()
        End If

        'Sm_ActionPrintReporteNotasCredito2()
        'Sm_ActionPrintReporteValeCaja2()

        '----------------------------------------------------------------------------------------------------------------------------------------
        'JNAVA (06.12.2014): Impresion de Reportes de Ventas e Inventario de Electrónicos
        '----------------------------------------------------------------------------------------------------------------------------------------
        Sm_ActionPrintReporteVentasElectronicos()
        Sm_ActionPrintReporteInventarioElectronicos()

        '-------------------------------------------------------------------------------
        'FLIZARRAGA 29/12/2017: Carga el reporte de devoluciones tarjetas
        '-------------------------------------------------------------------------------
        Sm_ActionPrintReporteDevolucionTarjetas()
        Sm_ActionPrintReporteDevolucionEfectivo()

        '-------------------------------------------------------------------------------
        'FLIZARRAGA 02/03/2018: Carga el reporte de ventas totales de microcredito
        '-------------------------------------------------------------------------------
        Sm_ActionPreviewReporteVentasTotalesMicrocredito()
        '-------------------------------------------------------------------------------
        'FLIZARRAGA 02/05/2019: Carga el reporte de pagos ecommerce dpvale
        '-------------------------------------------------------------------------------
        Sm_ActionPreviewReportePagosEcommerceDPVale()
    End Sub

#Region "ActiveReports Designer generated code"
    Private WithEvents PageHeader As PageHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents PageFooter As PageFooter = Nothing
    Private SubReport3 As SubReport = Nothing
    Private ReporteDevolucionEfectivo As SubReport = Nothing
    Private SubReport2 As SubReport = Nothing
    Private SubReport4 As SubReport = Nothing
    Private SubReport5 As SubReport = Nothing
    Private SubReport6 As SubReport = Nothing
    Private SubReport7 As SubReport = Nothing
    Private SubReport8 As SubReport = Nothing
    Private SubReport9 As SubReport = Nothing
    Private SubReport10 As SubReport = Nothing
    Private SubReport11 As SubReport = Nothing
    Private SubReport12 As SubReport = Nothing
    Private SubReport13 As SubReport = Nothing
    Private OtrosPagos As SubReport = Nothing
    Private PedidosFacturados As SubReport = Nothing
    Private PedidosNoFacturados As SubReport = Nothing
    Private SubReport14 As SubReport = Nothing
    Private SubReport15 As SubReport = Nothing
    Private PagosDPCard As SubReport = Nothing
    Private txtNoPagina As TextBox = Nothing
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RptCierredeDia))
        Me.Detail = New DataDynamics.ActiveReports.Detail()
        Me.SubReport3 = New DataDynamics.ActiveReports.SubReport()
        Me.ReporteDevolucionEfectivo = New DataDynamics.ActiveReports.SubReport()
        Me.SubReport2 = New DataDynamics.ActiveReports.SubReport()
        Me.SubReport4 = New DataDynamics.ActiveReports.SubReport()
        Me.SubReport5 = New DataDynamics.ActiveReports.SubReport()
        Me.SubReport6 = New DataDynamics.ActiveReports.SubReport()
        Me.SubReport7 = New DataDynamics.ActiveReports.SubReport()
        Me.SubReport8 = New DataDynamics.ActiveReports.SubReport()
        Me.SubReport9 = New DataDynamics.ActiveReports.SubReport()
        Me.SubReport10 = New DataDynamics.ActiveReports.SubReport()
        Me.SubReport11 = New DataDynamics.ActiveReports.SubReport()
        Me.SubReport12 = New DataDynamics.ActiveReports.SubReport()
        Me.SubReport13 = New DataDynamics.ActiveReports.SubReport()
        Me.OtrosPagos = New DataDynamics.ActiveReports.SubReport()
        Me.PedidosFacturados = New DataDynamics.ActiveReports.SubReport()
        Me.PedidosNoFacturados = New DataDynamics.ActiveReports.SubReport()
        Me.SubReport14 = New DataDynamics.ActiveReports.SubReport()
        Me.SubReport15 = New DataDynamics.ActiveReports.SubReport()
        Me.PagosDPCard = New DataDynamics.ActiveReports.SubReport()
        Me.ReporteDevolucionTarjeta = New DataDynamics.ActiveReports.SubReport()
        Me.SubReport1 = New DataDynamics.ActiveReports.SubReport()
        Me.ReporteVentasTotalesMicrocredito = New DataDynamics.ActiveReports.SubReport()
        Me.PageHeader = New DataDynamics.ActiveReports.PageHeader()
        Me.PageFooter = New DataDynamics.ActiveReports.PageFooter()
        Me.txtNoPagina = New DataDynamics.ActiveReports.TextBox()
        CType(Me.txtNoPagina, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.ColumnSpacing = 0.0!
        Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.SubReport3, Me.ReporteDevolucionEfectivo, Me.SubReport2, Me.SubReport4, Me.SubReport5, Me.SubReport6, Me.SubReport7, Me.SubReport8, Me.SubReport9, Me.SubReport10, Me.SubReport11, Me.SubReport12, Me.SubReport13, Me.OtrosPagos, Me.PedidosFacturados, Me.PedidosNoFacturados, Me.SubReport14, Me.SubReport15, Me.PagosDPCard, Me.ReporteDevolucionTarjeta, Me.SubReport1, Me.ReporteVentasTotalesMicrocredito})
        Me.Detail.Height = 6.40666!
        Me.Detail.Name = "Detail"
        '
        'SubReport3
        '
        Me.SubReport3.CloseBorder = False
        Me.SubReport3.Height = 0.1875!
        Me.SubReport3.Left = 0.049!
        Me.SubReport3.Name = "SubReport3"
        Me.SubReport3.Report = Nothing
        Me.SubReport3.Top = 2.145!
        Me.SubReport3.Width = 7.210001!
        '
        'ReporteDevolucionEfectivo
        '
        Me.ReporteDevolucionEfectivo.CloseBorder = False
        Me.ReporteDevolucionEfectivo.Height = 0.1875!
        Me.ReporteDevolucionEfectivo.Left = 0.079!
        Me.ReporteDevolucionEfectivo.Name = "ReporteDevolucionEfectivo"
        Me.ReporteDevolucionEfectivo.Report = Nothing
        Me.ReporteDevolucionEfectivo.Top = 1.303!
        Me.ReporteDevolucionEfectivo.Width = 7.18!
        '
        'SubReport2
        '
        Me.SubReport2.CloseBorder = False
        Me.SubReport2.Height = 0.1875!
        Me.SubReport2.Left = 0.062!
        Me.SubReport2.Name = "SubReport2"
        Me.SubReport2.Report = Nothing
        Me.SubReport2.Top = 1.875!
        Me.SubReport2.Width = 7.196713!
        '
        'SubReport4
        '
        Me.SubReport4.CloseBorder = False
        Me.SubReport4.Height = 0.1875!
        Me.SubReport4.Left = 0.062!
        Me.SubReport4.Name = "SubReport4"
        Me.SubReport4.Report = Nothing
        Me.SubReport4.Top = 4.963!
        Me.SubReport4.Visible = False
        Me.SubReport4.Width = 7.197001!
        '
        'SubReport5
        '
        Me.SubReport5.CloseBorder = False
        Me.SubReport5.Height = 0.1875!
        Me.SubReport5.Left = 0.062!
        Me.SubReport5.Name = "SubReport5"
        Me.SubReport5.Report = Nothing
        Me.SubReport5.Top = 5.257!
        Me.SubReport5.Visible = False
        Me.SubReport5.Width = 7.196973!
        '
        'SubReport6
        '
        Me.SubReport6.CloseBorder = False
        Me.SubReport6.Height = 0.1875!
        Me.SubReport6.Left = 0.07874014!
        Me.SubReport6.Name = "SubReport6"
        Me.SubReport6.Report = Nothing
        Me.SubReport6.Top = 0.4749015!
        Me.SubReport6.Width = 7.180118!
        '
        'SubReport7
        '
        Me.SubReport7.CloseBorder = False
        Me.SubReport7.Height = 0.1875!
        Me.SubReport7.Left = 0.062!
        Me.SubReport7.Name = "SubReport7"
        Me.SubReport7.Report = Nothing
        Me.SubReport7.Top = 5.538!
        Me.SubReport7.Visible = False
        Me.SubReport7.Width = 7.196973!
        '
        'SubReport8
        '
        Me.SubReport8.CloseBorder = False
        Me.SubReport8.Height = 0.1875!
        Me.SubReport8.Left = 0.062!
        Me.SubReport8.Name = "SubReport8"
        Me.SubReport8.Report = Nothing
        Me.SubReport8.Top = 5.832!
        Me.SubReport8.Visible = False
        Me.SubReport8.Width = 7.196973!
        '
        'SubReport9
        '
        Me.SubReport9.CloseBorder = False
        Me.SubReport9.Height = 0.1875!
        Me.SubReport9.Left = 0.062!
        Me.SubReport9.Name = "SubReport9"
        Me.SubReport9.Report = Nothing
        Me.SubReport9.Top = 6.124!
        Me.SubReport9.Visible = False
        Me.SubReport9.Width = 7.196973!
        '
        'SubReport10
        '
        Me.SubReport10.CloseBorder = False
        Me.SubReport10.Height = 0.1875!
        Me.SubReport10.Left = 0.064!
        Me.SubReport10.Name = "SubReport10"
        Me.SubReport10.Report = Nothing
        Me.SubReport10.Top = 4.651!
        Me.SubReport10.Visible = False
        Me.SubReport10.Width = 7.195!
        '
        'SubReport11
        '
        Me.SubReport11.CloseBorder = False
        Me.SubReport11.Height = 0.1875!
        Me.SubReport11.Left = 0.079!
        Me.SubReport11.Name = "SubReport11"
        Me.SubReport11.Report = Nothing
        Me.SubReport11.Top = 1.589!
        Me.SubReport11.Width = 7.18!
        '
        'SubReport12
        '
        Me.SubReport12.CloseBorder = False
        Me.SubReport12.Height = 0.1875!
        Me.SubReport12.Left = 0.062!
        Me.SubReport12.Name = "SubReport12"
        Me.SubReport12.Report = Nothing
        Me.SubReport12.Top = 4.371!
        Me.SubReport12.Width = 7.185041!
        '
        'SubReport13
        '
        Me.SubReport13.CloseBorder = False
        Me.SubReport13.Height = 0.1968504!
        Me.SubReport13.Left = 0.049!
        Me.SubReport13.Name = "SubReport13"
        Me.SubReport13.Report = Nothing
        Me.SubReport13.Top = 2.429!
        Me.SubReport13.Width = 7.210001!
        '
        'OtrosPagos
        '
        Me.OtrosPagos.CloseBorder = False
        Me.OtrosPagos.Height = 0.1875!
        Me.OtrosPagos.Left = 0.062!
        Me.OtrosPagos.Name = "OtrosPagos"
        Me.OtrosPagos.Report = Nothing
        Me.OtrosPagos.Top = 3.291!
        Me.OtrosPagos.Width = 7.196713!
        '
        'PedidosFacturados
        '
        Me.PedidosFacturados.CloseBorder = False
        Me.PedidosFacturados.Height = 0.1875!
        Me.PedidosFacturados.Left = 0.062!
        Me.PedidosFacturados.Name = "PedidosFacturados"
        Me.PedidosFacturados.Report = Nothing
        Me.PedidosFacturados.Top = 2.718!
        Me.PedidosFacturados.Width = 7.1875!
        '
        'PedidosNoFacturados
        '
        Me.PedidosNoFacturados.CloseBorder = False
        Me.PedidosNoFacturados.Height = 0.1875!
        Me.PedidosNoFacturados.Left = 0.062!
        Me.PedidosNoFacturados.Name = "PedidosNoFacturados"
        Me.PedidosNoFacturados.Report = Nothing
        Me.PedidosNoFacturados.Top = 3.01!
        Me.PedidosNoFacturados.Width = 7.1875!
        '
        'SubReport14
        '
        Me.SubReport14.CloseBorder = False
        Me.SubReport14.Height = 0.1875!
        Me.SubReport14.Left = 0.062!
        Me.SubReport14.Name = "SubReport14"
        Me.SubReport14.Report = Nothing
        Me.SubReport14.Top = 3.551!
        Me.SubReport14.Width = 7.196973!
        '
        'SubReport15
        '
        Me.SubReport15.CloseBorder = False
        Me.SubReport15.Height = 0.1875!
        Me.SubReport15.Left = 0.062!
        Me.SubReport15.Name = "SubReport15"
        Me.SubReport15.Report = Nothing
        Me.SubReport15.Top = 4.091!
        Me.SubReport15.Width = 7.185041!
        '
        'PagosDPCard
        '
        Me.PagosDPCard.CloseBorder = False
        Me.PagosDPCard.Height = 0.1875!
        Me.PagosDPCard.Left = 0.07!
        Me.PagosDPCard.Name = "PagosDPCard"
        Me.PagosDPCard.Report = Nothing
        Me.PagosDPCard.Top = 3.821!
        Me.PagosDPCard.Width = 7.185041!
        '
        'ReporteDevolucionTarjeta
        '
        Me.ReporteDevolucionTarjeta.CloseBorder = False
        Me.ReporteDevolucionTarjeta.Height = 0.1875!
        Me.ReporteDevolucionTarjeta.Left = 0.079!
        Me.ReporteDevolucionTarjeta.Name = "ReporteDevolucionTarjeta"
        Me.ReporteDevolucionTarjeta.Report = Nothing
        Me.ReporteDevolucionTarjeta.Top = 0.7450001!
        Me.ReporteDevolucionTarjeta.Width = 7.180118!
        '
        'SubReport1
        '
        Me.SubReport1.CloseBorder = False
        Me.SubReport1.Height = 0.1875!
        Me.SubReport1.Left = 0.07!
        Me.SubReport1.Name = "SubReport1"
        Me.SubReport1.Report = Nothing
        Me.SubReport1.Top = 0.146!
        Me.SubReport1.Width = 7.18!
        '
        'ReporteVentasTotalesMicrocredito
        '
        Me.ReporteVentasTotalesMicrocredito.CloseBorder = False
        Me.ReporteVentasTotalesMicrocredito.Height = 0.1875!
        Me.ReporteVentasTotalesMicrocredito.Left = 0.079!
        Me.ReporteVentasTotalesMicrocredito.Name = "ReporteVentasTotalesMicrocredito"
        Me.ReporteVentasTotalesMicrocredito.Report = Nothing
        Me.ReporteVentasTotalesMicrocredito.Top = 1.032!
        Me.ReporteVentasTotalesMicrocredito.Width = 7.180118!
        '
        'PageHeader
        '
        Me.PageHeader.Height = 0.0!
        Me.PageHeader.Name = "PageHeader"
        '
        'PageFooter
        '
        Me.PageFooter.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtNoPagina})
        Me.PageFooter.Height = 0.1979167!
        Me.PageFooter.Name = "PageFooter"
        '
        'txtNoPagina
        '
        Me.txtNoPagina.Height = 0.1875!
        Me.txtNoPagina.Left = 6.8125!
        Me.txtNoPagina.Name = "txtNoPagina"
        Me.txtNoPagina.Style = "text-align: right"
        Me.txtNoPagina.Text = "Pag. 2"
        Me.txtNoPagina.Top = 0.0!
        Me.txtNoPagina.Width = 0.4375!
        '
        'RptCierredeDia
        '
        Me.MasterReport = False
        Me.PageSettings.Margins.Bottom = 0.39375!
        Me.PageSettings.Margins.Left = 0.29375!
        Me.PageSettings.Margins.Right = 0.29375!
        Me.PageSettings.Margins.Top = 0.39375!
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 7.354167!
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
        CType(Me.txtNoPagina, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

#End Region

#Region "Generación de los reportes"

    Private Sub Sm_Concentrado()

        Dim oARReporte As New ConcentradoREP(dlFecha, GetAlmacen())
        SubReport12.Report = oARReporte
        'SubReport12.Report.DataSource = oARReporte.DataSource
        'SubReport12.Report.DataMember = oARReporte.DataMember

    End Sub

    Private Sub Sm_ActionPrintReporteRetiros()

        Dim oARReporte As New rptRetirosDelDia(dlFecha, GetAlmacen())
        SubReport10.Report = oARReporte
        SubReport10.Report.DataSource = oARReporte.DataSource
        SubReport10.Report.DataMember = oARReporte.DataMember

    End Sub

    Private Sub Sm_ActionPrintReporteAbonosCxC()

        Dim oARReporte As New rptReporteAbonosCreditoDirecto(dlFecha, GetAlmacen())
        SubReport11.Report = oARReporte
        SubReport11.Report.DataSource = oARReporte.DataSource
        SubReport11.Report.DataMember = oARReporte.DataMember

    End Sub

    Private Sub Sm_ActionPrintReporteVentasFacturadas()

        Dim oReport As New VentasReport
        Dim oReporter As New VentasTotalesReporter(oAppContext)
        Dim ds As New DataSet

        oReporter.ConnectionString = oAppContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString()
        oReport.CurrentReporter = oReporter

        oReporter.FechaIni = dlFecha
        oReporter.FechaFin = dlFecha
        oReporter.CodCaja = "AL" ' oAppContext.ApplicationConfiguration.NoCaja 'El reporte se genera por almacen y no por caja.
        oReporter.Almacen = oAppContext.ApplicationConfiguration.Almacen

        ds = oReport.GenerateNewPreview

        Dim oARReporte As New VentasTotales(ds, dlFecha, dlFecha)
        'Dim oARReporte As New ConcentradoREP(dlFecha, GetAlmacen())
        SubReport1.Report = oARReporte
        SubReport1.Report.DataSource = oARReporte.DataSource
        SubReport1.Report.DataMember = oARReporte.DataMember

    End Sub

    Private Sub Sm_ActionPrintReporteNotasCredito()

        'If (oCierreDiasMgr.ValidarReporteNotasCredito(dlFecha) = False) Then
        '    Return
        'End If

        Dim oARReporte As New CierreDiaNotasCredito(dlFecha, GetAlmacen())

        SubReport2.Report = oARReporte
        SubReport2.Report.DataSource = oARReporte.DataSource
        SubReport2.Report.DataMember = oARReporte.DataMember

    End Sub

    Private Sub Sm_ActionPrintReporteNotasCredito2()

        'If (oCierreDiasMgr.ValidarReporteNotasCredito(dlFecha) = False) Then
        '    Return
        'End If

        Dim oARReporte As New CierreDiaNotasCredito(dlFecha, GetAlmacen())
        Dim oARViewer As New ReportViewerForm

        oARReporte.Document.Name = "Reporte de Notas de Crédito"
        oARReporte.Run()

        oARReporte.Document.Print(False, False)
        'oARViewer.Report = oARReporte
        'oARViewer.Show()

    End Sub

    Private Function GetAlmacen() As String

        Dim oAlmacenMgr As New CatalogoAlmacenesManager(oAppContext)
        Dim oAlmacen As Almacen
        Dim strAlmacen As String = oAppContext.ApplicationConfiguration.Almacen
        Dim AlmacenDescripcion As String = String.Empty
        oAlmacen = oAlmacenMgr.Create
        oAlmacenMgr.LoadInto(strAlmacen, oAlmacen)

        AlmacenDescripcion = strAlmacen & " " & oAlmacen.Descripcion

        oAlmacen = Nothing
        oAlmacenMgr = Nothing

        Return AlmacenDescripcion

    End Function

    Private Sub Sm_ActionPrintReporteValeCaja()

        dtValeCajaReport = SelectValeCajaReport()

        Dim oARReporte As New ValesdeCajaReport(dlFecha, _
                                                dlFecha, _
                                                GetAlmacen(), _
                                                dtValeCajaReport)

        SubReport3.Report = oARReporte
        SubReport3.Report.DataSource = oARReporte.DataSource
        SubReport3.Report.DataMember = oARReporte.DataMember

    End Sub

    Private Sub Sm_ActionPrintReporteValeCaja2()

        dtValeCajaReport = SelectValeCajaReport()

        Dim oARReporte As New ValesdeCajaReport(dlFecha, _
                                                dlFecha, _
                                                GetAlmacen(), _
                                                dtValeCajaReport)
        Dim oARViewer As New ReportViewerForm

        oARReporte.Document.Name = "Reporte de Vales de Caja"
        oARReporte.Run()

        oARReporte.Document.Print(False, False)
        'oARViewer.Report = oARReporte
        'oARViewer.Show()

    End Sub

    Private Sub Sm_ActionPreviewReportePagosEcommerceDPVale()
        Dim oARReporte As New rptPagueTiendaEcommerceDPVale(dlFecha)
        oARReporte.Document.Name = "Reportes de Ventas a Credito DPVale"
        oARReporte.Run()
        Try
            oARReporte.Document.Print(False, False)
            'Dim lstVales As List(Of String), lstClientes As List(Of String)
            'lstVales = oARReporte.GetValesInexistentes()
            'lstClientes = oARReporte.GetClientesErroneos()
            'Dim strVales As String = "", strClientes As String = ""
            'If lstVales.Count > 0 Then
            '    strVales = String.Join(vbCrLf, lstVales)
            '    MessageBox.Show("La venta con vale no se almaceno correctamente:" & vbCrLf & strVales, "Vales inexistentes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            'End If
            'If lstClientes.Count > 0 Then
            '    strClientes = String.Join(vbCrLf, lstClientes)
            '    MessageBox.Show(strClientes, "Clientes Vacios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            'End If
        Catch ex As Exception

            EscribeLog(ex.Message, "Error impresion cierre día pagos ecommerce dpvale")

        End Try

        'Dim oARReporte As New rptVentasEcommerceDPVale(dlFecha)
        'Dim oReportViewer As New ReportViewerForm
        'oARReporte.Document.Name = "Reporte de Pagos Ecommerce Vale"
        ''oReportViewer.Report = oARReporte

        'oARReporte.Run()

        'oARReporte.Document.Print(False, False)
        'oARReporte.Run()
        'oReportViewer.Show()

    End Sub

    Private Sub Sm_ActionPrintReporteFacturasLiquidadas()

        Dim dsLiquidadas As DataSet

        dsLiquidadas = SelectFacturasLiquidadas()

        'If (dsLiquidadas Is Nothing) Or (dsLiquidadas.Tables(0).Rows.Count = 0) Then

        '    dsLiquidadas = Nothing

        '    Exit Sub

        'End If

        Dim oARReporte As New rptFacturasLiquidadas(dsLiquidadas, dlFecha, GetAlmacen())

        SubReport4.Report = oARReporte
        SubReport4.Report.DataSource = oARReporte.DataSource
        SubReport4.Report.DataMember = oARReporte.DataMember

    End Sub

    Private Sub Sm_ActionPrintReporteCancelacionApartados()

        'If (oCierreDiasMgr.ValidarReporteCancelacionApartados(dlFecha) = False) Then
        '    Return
        'End If

        Dim oARReporte As New CierreDiaCancelacionApartados(dlFecha, GetAlmacen)

        SubReport5.Report = oARReporte
        SubReport5.Report.DataSource = oARReporte.DataSource
        SubReport5.Report.DataMember = oARReporte.DataMember

    End Sub

    Private Sub Sm_ActionPrintReporteAbonosApartados()

        Dim oAbonosApartadosMgr As New AbonosApartadosManager(oAppContext)

        'If (oAbonosApartadosMgr.GetByDate(dlFecha).Tables(0).Rows.Count = 0) Then
        '    Return
        'End If

        Dim oARReporte As New rptAbonosApartados(dlFecha)

        SubReport6.Report = oARReporte
        SubReport6.Report.DataSource = oARReporte.DataSource
        SubReport6.Report.DataMember = oARReporte.DataMember

    End Sub

    Private Sub Sm_ActionPrintReporteAbonosDPCard()

        Dim oARReporte As New rptAbonosDPCard(dlFecha)

        PagosDPCard.Report = oARReporte
        PagosDPCard.Report.DataSource = oARReporte.DataSource
        PagosDPCard.Report.DataMember = oARReporte.DataMember

    End Sub

    Private Sub Sm_ActionPrintReporteAbonosCreditoDirecto()

        Dim oAbonoCreditoDirectoMgr As New AbonoCreditoDirectoManager(oAppContext)

        Dim dsAbonosCreditoDT As New DataSet

        'dsAbonosCreditoDT = oAbonoCreditoDirectoMgr.GetByDate(dlFecha, oAppContext.ApplicationConfiguration.Almacen)

        'If dsAbonosCreditoDT Is Nothing Or (dsAbonosCreditoDT.Tables(0).Rows.Count = 0) Then

        '    If Not dsAbonosCreditoDT Is Nothing Then

        '        dsAbonosCreditoDT.Dispose()
        '        dsAbonosCreditoDT = Nothing

        '        oAbonoCreditoDirectoMgr = Nothing

        '    End If

        '    Return

        'End If

        Dim oARReporte As New frmAbonosCreditoDirecto(dlFecha, dsAbonosCreditoDT)

        SubReport7.Report = oARReporte
        SubReport7.Report.DataSource = oARReporte.DataSource
        SubReport7.Report.DataMember = oARReporte.DataMember

    End Sub

    Private Sub VentasVale()
        'Dim oFacturasMgr As New FacturaManager(oAppContext)
        'Dim dsVentasPTVenta As New DataSet

        'dsVentasPTVenta = oFacturasMgr.VentasDPValeDelDia(dlFecha).Copy

        'If dsVentasPTVenta.Tables(0).Rows.Count > 0 Then

        Dim oARReporte As New rptVentasCreditoDPVale(dlFecha)

        SubReport8.Report = oARReporte
        SubReport8.Report.DataSource = oARReporte.DataSource
        SubReport8.Report.DataMember = oARReporte.DataMember

        'End If

    End Sub

    Private Sub Sm_ActionPrintReporteAnalisisVtaPlayers()

        Dim oARReporte As New rptVentasPlayerDPVale("T", dlFecha, dlFecha, "Codigo")

        SubReport9.Report = oARReporte
        SubReport9.Report.DataSource = oARReporte.DataSource
        SubReport9.Report.DataMember = oARReporte.DataMember

    End Sub
    Private Sub ActionPreviewNotasVentaManuales()
        Dim oAReport As New rptCancelacionNotasVentaManuales(dlFecha)
        SubReport13.Report = oAReport
        SubReport13.Report.DataSource = oAReport.DataSource
        SubReport13.Report.DataMember = oAReport.DataMember
    End Sub
#End Region

#Region "SQL Methods"

    Private Function SelectValeCajaReport() As DataTable

        Dim sccnnConnection As New SqlConnection(strConnectionString)

        Dim daValesCaja As SqlDataAdapter
        Dim dtValesCaja As New DataTable("ValesCaja")

        Dim sccmdSelect As SqlCommand
        sccmdSelect = New SqlCommand

        With sccmdSelect
            .Connection = sccnnConnection
            .CommandText = "[ValesdeCajaReporteSel]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaInicial", System.Data.SqlDbType.DateTime, 8))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaFinal", System.Data.SqlDbType.DateTime, 8))

            .Parameters("@FechaInicial").Value = dlFecha
            .Parameters("@FechaFinal").Value = dlFecha

        End With

        daValesCaja = New SqlDataAdapter(sccmdSelect)

        Try

            daValesCaja.Fill(dtValesCaja)

            sccnnConnection.Close()

        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("El registro no pudo ser seleccionado debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("El registro no pudo ser seleccionado debido a un error de aplicación.", ex)

        End Try

        daValesCaja.Dispose()
        daValesCaja = Nothing

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return dtValesCaja

    End Function

    Private Function SelectFacturasLiquidadas() As DataSet

        Dim oFacturaMgrTemp As New FacturaManager(oAppContext)
        Dim dsFacturas As DataSet

        dsFacturas = oFacturaMgrTemp.GetFacturasLiquidadas(dlFecha, dlFecha)

        oFacturaMgrTemp = Nothing

        Return dsFacturas

    End Function

#End Region

#Region "Facturación Si Hay"

    '--------------------------------------------------------------------------------------------
    'FLIZARRAGA 25/09/2014: Se Agrego los detalles de los pedidos facturados y los que no
    '--------------------------------------------------------------------------------------------

    Private Sub Sm_ActionPrintReportePedidosFacturados()
        Dim rptVentas As New ReporteVentasDataGateWay(oAppContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString(), oAppContext)
        Dim dsPedidos As DataSet = rptVentas.GetReportePedidosFacturados(oAppContext.ApplicationConfiguration.Almacen, dlFecha, dlFecha)

        Dim oARReporte As New rptPedidosTotales(dsPedidos, oAppContext.ApplicationConfiguration.Almacen, dlFecha, dlFecha)
        'Dim oARReporte As New ConcentradoREP(dlFecha, GetAlmacen())
        PedidosFacturados.Report = oARReporte
        'PedidosFacturados.Report.DataSource = oARReporte.DataSource
        'PedidosFacturados.Report.DataMember = oARReporte.DataMember
    End Sub

    Private Sub Sm_ActionPrintReportePedidosNoFacturados()
        Dim rptVentas As New ReporteVentasDataGateWay(oAppContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString(), oAppContext)
        Dim dsPedidos As DataSet = rptVentas.GetPedidosNoFacturados(oAppContext.ApplicationConfiguration.Almacen, dlFecha, dlFecha)

        Dim oARReporte As New rptPedidosSinFacturarTotales(dsPedidos, oAppContext.ApplicationConfiguration.Almacen, dlFecha, dlFecha)

        PedidosNoFacturados.Report = oARReporte

    End Sub

    '-------------------------------------------------------------------------------------------
    'FLIZARRAGA 26/09/2014: Se agrego el reporte de pagos Ecommerce
    '-------------------------------------------------------------------------------------------

    Private Sub Sm_ActionPrintReportePagosEcommerce()
        Dim rptVentas As New ReporteVentasDataGateWay(oAppContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString(), oAppContext)
        Dim dsPagos As DataSet = rptVentas.GetPagosEcommerce(oAppContext.ApplicationConfiguration.Almacen, dlFecha, dlFecha)

        Dim oARReporte As New rptPagosTotalesEcommerce(dsPagos, oAppContext.ApplicationConfiguration.Almacen, dlFecha, dlFecha)

        OtrosPagos.Report = oARReporte
    End Sub

#End Region

    Private Sub PageFooter_BeforePrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles PageFooter.BeforePrint
        If oConfigCierreFI.MostrarConcenAUD Then
            Me.txtNoPagina.Text = "Pag. " & Me.PageNumber + 1
        End If
    End Sub

#Region "Venta de Electronicos"


    '----------------------------------------------------------------------------------------------------------------------------------------
    'JNAVA (06.12.2014): Impresion de Reportes de Ventas de Electrónicos
    '----------------------------------------------------------------------------------------------------------------------------------------
    Private Sub Sm_ActionPrintReporteVentasElectronicos()

        Dim oARReporte As New rptVentasElectronicos(dlFecha)

        SubReport14.Report = oARReporte
        SubReport14.Report.DataSource = oARReporte.DataSource
        'SubReport14.Report.DataMember = oARReporte.DataMember

    End Sub

    '----------------------------------------------------------------------------------------------------------------------------------------
    'JNAVA (06.12.2014): Impresion de Reportes de Inventario Actual de Electrónicos
    '----------------------------------------------------------------------------------------------------------------------------------------
    Private Sub Sm_ActionPrintReporteInventarioElectronicos()

        Dim oARReporte As New RptInventarioElectronicos

        SubReport15.Report = oARReporte
        SubReport15.Report.DataSource = oARReporte.DataSource
        'SubReport15.Report.DataMember = oARReporte.DataMember

    End Sub

#End Region

#Region "Devolución Tarjetas"

    Private Sub Sm_ActionPrintReporteDevolucionTarjetas()

        'If (oCierreDiasMgr.ValidarReporteNotasCredito(dlFecha) = False) Then
        '    Return
        'End If

        Dim oARReporte As New CierreDiaDevolucionTarjeta(dlFecha, GetAlmacen(), True)

        ReporteDevolucionTarjeta.Report = oARReporte
        ReporteDevolucionTarjeta.Report.DataSource = oARReporte.DataSource
        ReporteDevolucionTarjeta.Report.DataMember = oARReporte.DataMember

    End Sub

    Private Sub Sm_ActionPrintReporteDevolucionEfectivo()

        'If (oCierreDiasMgr.ValidarReporteNotasCredito(dlFecha) = False) Then
        '    Return
        'End If

        Dim oARReporte As New CierreDiaDevolucionTarjeta(dlFecha, GetAlmacen(), False)

        ReporteDevolucionEfectivo.Report = oARReporte
        ReporteDevolucionEfectivo.Report.DataSource = oARReporte.DataSource
        ReporteDevolucionEfectivo.Report.DataMember = oARReporte.DataMember

    End Sub

#End Region

#Region "Mejoras Microcredito"

    Private Sub Sm_ActionPreviewReporteVentasTotalesMicrocredito()

        Dim oARReporte As New CierreDiaVentasTotalesMicrocreditos(dlFecha, GetAlmacen)
        ReporteVentasTotalesMicrocredito.Report = oARReporte
        ReporteVentasTotalesMicrocredito.Report.DataSource = oARReporte.DataSource
        ReporteVentasTotalesMicrocredito.Report.DataMember = oARReporte.DataMember

    End Sub

#End Region

End Class
