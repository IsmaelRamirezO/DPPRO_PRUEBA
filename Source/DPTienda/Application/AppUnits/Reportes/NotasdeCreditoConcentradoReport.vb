Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Public Class NotasdeCreditoConcentradoReport

    Inherits DataDynamics.ActiveReports.ActiveReport

    Public Sub New( _
                    ByVal nCaja As String, _
                    ByVal fDesde As Date, _
                    ByVal fHasta As Date, _
                    ByVal strSucursal As String, _
                    ByVal dtConcentrado As DataTable)

        MyBase.New()

        InitializeComponent()

        lblFechaReporte.Text = Format(Date.Now, "dd/MM/yyyy")
        lblPagina.Text = "PAG: " & Me.PageNumber
        If nCaja = "00" Then
            lblCaja.Text = "Caja #: Todas"
        Else
            lblCaja.Text = "Caja #: " & nCaja
        End If
        lblRango.Text = "De : " & Format(fDesde, "dd/MM/yyyy") & " Al : " & Format(fHasta, "dd/MM/yyyy")
        lblSucursalDescripcion.Text = "Sucursal : " & strSucursal

        Me.DataSource = dtConcentrado
        Me.DataMember = "Concentrado"
        Me.txtFolio.DataField = "FolioNotaCredito"
        Me.txtFolioSAP.DataField = "SalesDocument"
        Me.txtSucursal.DataField = "CodCaja"
        Me.txtImporte.DataField = "Importe"
        Me.txtCliente.DataField = "ClienteID"
        Me.txtReviso.DataField = "CodVendedor"
        Me.txtFecha.DataField = "Fecha"
        Me.txtTotalImporte.DataField = "Importe"

        Me.Run()

    End Sub

#Region "ActiveReports Designer generated code"
    Private WithEvents PageHeader As PageHeader = Nothing
    Private WithEvents GroupHeader1 As GroupHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents GroupFooter1 As GroupFooter = Nothing
    Private WithEvents PageFooter As PageFooter = Nothing
	Private Shape1 As Shape = Nothing
	Private lblFolio As Label = Nothing
	Private lblSucursal As Label = Nothing
	Private lblFecha As Label = Nothing
	Private lblImporte As Label = Nothing
	Private lblCliente As Label = Nothing
	Private lblReviso As Label = Nothing
	Private lblTitulo As Label = Nothing
	Private lblRango As Label = Nothing
	Private lblFechaReporte As Label = Nothing
	Private lblPagina As Label = Nothing
	Private lblSucursalDescripcion As Label = Nothing
	Private Line1 As Line = Nothing
	Private Line2 As Line = Nothing
	Private Line3 As Line = Nothing
	Private Line4 As Line = Nothing
	Private Line5 As Line = Nothing
	Private Line6 As Line = Nothing
	Private lblCaja As Label = Nothing
	Private Label2 As Label = Nothing
	Private Line7 As Line = Nothing
	Private txtSucursal As TextBox = Nothing
	Private txtFolio As TextBox = Nothing
	Private txtFecha As TextBox = Nothing
	Private txtImporte As TextBox = Nothing
	Private txtCliente As TextBox = Nothing
	Private txtReviso As TextBox = Nothing
	Private txtFolioSAP As TextBox = Nothing
	Private Shape2 As Shape = Nothing
	Private txtTotalImporte As TextBox = Nothing
	Private Label1 As Label = Nothing
	Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NotasdeCreditoConcentradoReport))
            Me.Detail = New DataDynamics.ActiveReports.Detail()
            Me.PageHeader = New DataDynamics.ActiveReports.PageHeader()
            Me.PageFooter = New DataDynamics.ActiveReports.PageFooter()
            Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader()
            Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter()
            Me.Shape1 = New DataDynamics.ActiveReports.Shape()
            Me.lblFolio = New DataDynamics.ActiveReports.Label()
            Me.lblSucursal = New DataDynamics.ActiveReports.Label()
            Me.lblFecha = New DataDynamics.ActiveReports.Label()
            Me.lblImporte = New DataDynamics.ActiveReports.Label()
            Me.lblCliente = New DataDynamics.ActiveReports.Label()
            Me.lblReviso = New DataDynamics.ActiveReports.Label()
            Me.lblTitulo = New DataDynamics.ActiveReports.Label()
            Me.lblRango = New DataDynamics.ActiveReports.Label()
            Me.lblFechaReporte = New DataDynamics.ActiveReports.Label()
            Me.lblPagina = New DataDynamics.ActiveReports.Label()
            Me.lblSucursalDescripcion = New DataDynamics.ActiveReports.Label()
            Me.Line1 = New DataDynamics.ActiveReports.Line()
            Me.Line2 = New DataDynamics.ActiveReports.Line()
            Me.Line3 = New DataDynamics.ActiveReports.Line()
            Me.Line4 = New DataDynamics.ActiveReports.Line()
            Me.Line5 = New DataDynamics.ActiveReports.Line()
            Me.Line6 = New DataDynamics.ActiveReports.Line()
            Me.lblCaja = New DataDynamics.ActiveReports.Label()
            Me.Label2 = New DataDynamics.ActiveReports.Label()
            Me.Line7 = New DataDynamics.ActiveReports.Line()
            Me.txtSucursal = New DataDynamics.ActiveReports.TextBox()
            Me.txtFolio = New DataDynamics.ActiveReports.TextBox()
            Me.txtFecha = New DataDynamics.ActiveReports.TextBox()
            Me.txtImporte = New DataDynamics.ActiveReports.TextBox()
            Me.txtCliente = New DataDynamics.ActiveReports.TextBox()
            Me.txtReviso = New DataDynamics.ActiveReports.TextBox()
            Me.txtFolioSAP = New DataDynamics.ActiveReports.TextBox()
            Me.Shape2 = New DataDynamics.ActiveReports.Shape()
            Me.txtTotalImporte = New DataDynamics.ActiveReports.TextBox()
            Me.Label1 = New DataDynamics.ActiveReports.Label()
            CType(Me.lblFolio,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblSucursal,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblFecha,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblImporte,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblCliente,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblReviso,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblTitulo,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblRango,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblFechaReporte,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblPagina,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblSucursalDescripcion,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblCaja,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtSucursal,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFolio,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFecha,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtImporte,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtCliente,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtReviso,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFolioSAP,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtTotalImporte,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label1,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
            '
            'Detail
            '
            Me.Detail.ColumnSpacing = 0!
            Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtSucursal, Me.txtFolio, Me.txtFecha, Me.txtImporte, Me.txtCliente, Me.txtReviso, Me.txtFolioSAP})
            Me.Detail.Height = 0.2!
            Me.Detail.Name = "Detail"
            '
            'PageHeader
            '
            Me.PageHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape1, Me.lblFolio, Me.lblSucursal, Me.lblFecha, Me.lblImporte, Me.lblCliente, Me.lblReviso, Me.lblTitulo, Me.lblRango, Me.lblFechaReporte, Me.lblPagina, Me.lblSucursalDescripcion, Me.Line1, Me.Line2, Me.Line3, Me.Line4, Me.Line5, Me.Line6, Me.lblCaja, Me.Label2, Me.Line7})
            Me.PageHeader.Height = 1.008333!
            Me.PageHeader.Name = "PageHeader"
            '
            'PageFooter
            '
            Me.PageFooter.Height = 0!
            Me.PageFooter.Name = "PageFooter"
            '
            'GroupHeader1
            '
            Me.GroupHeader1.Height = 0!
            Me.GroupHeader1.Name = "GroupHeader1"
            '
            'GroupFooter1
            '
            Me.GroupFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape2, Me.txtTotalImporte, Me.Label1})
            Me.GroupFooter1.Height = 0.2597222!
            Me.GroupFooter1.Name = "GroupFooter1"
            '
            'Shape1
            '
            Me.Shape1.Height = 1!
            Me.Shape1.Left = 0!
            Me.Shape1.Name = "Shape1"
            Me.Shape1.RoundingRadius = 9.999999!
            Me.Shape1.Top = 0!
            Me.Shape1.Width = 6.850394!
            '
            'lblFolio
            '
            Me.lblFolio.Height = 0.2!
            Me.lblFolio.HyperLink = Nothing
            Me.lblFolio.Left = 0.06299999!
            Me.lblFolio.Name = "lblFolio"
            Me.lblFolio.Style = "text-align: center"
            Me.lblFolio.Text = "Folio"
            Me.lblFolio.Top = 0.78!
            Me.lblFolio.Width = 0.6456615!
            '
            'lblSucursal
            '
            Me.lblSucursal.Height = 0.2!
            Me.lblSucursal.HyperLink = Nothing
            Me.lblSucursal.Left = 1.711122!
            Me.lblSucursal.Name = "lblSucursal"
            Me.lblSucursal.Style = "text-align: center"
            Me.lblSucursal.Text = "CAJA"
            Me.lblSucursal.Top = 0.7874014!
            Me.lblSucursal.Width = 0.8125!
            '
            'lblFecha
            '
            Me.lblFecha.Height = 0.2!
            Me.lblFecha.HyperLink = Nothing
            Me.lblFecha.Left = 2.6875!
            Me.lblFecha.Name = "lblFecha"
            Me.lblFecha.Style = "text-align: center"
            Me.lblFecha.Text = "Fecha"
            Me.lblFecha.Top = 0.78!
            Me.lblFecha.Width = 0.875!
            '
            'lblImporte
            '
            Me.lblImporte.Height = 0.2!
            Me.lblImporte.HyperLink = Nothing
            Me.lblImporte.Left = 3.6875!
            Me.lblImporte.Name = "lblImporte"
            Me.lblImporte.Style = "text-align: center"
            Me.lblImporte.Text = "Importe"
            Me.lblImporte.Top = 0.78!
            Me.lblImporte.Width = 0.875!
            '
            'lblCliente
            '
            Me.lblCliente.Height = 0.2!
            Me.lblCliente.HyperLink = Nothing
            Me.lblCliente.Left = 4.75!
            Me.lblCliente.Name = "lblCliente"
            Me.lblCliente.Style = "text-align: center"
            Me.lblCliente.Text = "Cliente"
            Me.lblCliente.Top = 0.78!
            Me.lblCliente.Width = 0.9899937!
            '
            'lblReviso
            '
            Me.lblReviso.Height = 0.2!
            Me.lblReviso.HyperLink = Nothing
            Me.lblReviso.Left = 5.905513!
            Me.lblReviso.Name = "lblReviso"
            Me.lblReviso.Style = "text-align: center"
            Me.lblReviso.Text = "Reviso"
            Me.lblReviso.Top = 0.78!
            Me.lblReviso.Width = 0.8444882!
            '
            'lblTitulo
            '
            Me.lblTitulo.Height = 0.2!
            Me.lblTitulo.HyperLink = Nothing
            Me.lblTitulo.Left = 1.5625!
            Me.lblTitulo.Name = "lblTitulo"
            Me.lblTitulo.Style = "text-align: center"
            Me.lblTitulo.Text = "REPORTE DE NOTAS DE CREDITO TOTALES"
            Me.lblTitulo.Top = 0.0625!
            Me.lblTitulo.Width = 3.4375!
            '
            'lblRango
            '
            Me.lblRango.Height = 0.2!
            Me.lblRango.HyperLink = Nothing
            Me.lblRango.Left = 1.8125!
            Me.lblRango.Name = "lblRango"
            Me.lblRango.Style = "text-align: center"
            Me.lblRango.Text = "Desde : Hasta:"
            Me.lblRango.Top = 0.3125!
            Me.lblRango.Width = 2.9375!
            '
            'lblFechaReporte
            '
            Me.lblFechaReporte.Height = 0.2!
            Me.lblFechaReporte.HyperLink = Nothing
            Me.lblFechaReporte.Left = 0.0625!
            Me.lblFechaReporte.Name = "lblFechaReporte"
            Me.lblFechaReporte.Style = "text-align: left"
            Me.lblFechaReporte.Text = "FechaReporte"
            Me.lblFechaReporte.Top = 0.0625!
            Me.lblFechaReporte.Width = 0.9375!
            '
            'lblPagina
            '
            Me.lblPagina.Height = 0.2!
            Me.lblPagina.HyperLink = Nothing
            Me.lblPagina.Left = 5.4375!
            Me.lblPagina.Name = "lblPagina"
            Me.lblPagina.Style = "text-align: right"
            Me.lblPagina.Text = "Pagina"
            Me.lblPagina.Top = 0.0625!
            Me.lblPagina.Width = 0.9375!
            '
            'lblSucursalDescripcion
            '
            Me.lblSucursalDescripcion.Height = 0.2!
            Me.lblSucursalDescripcion.HyperLink = Nothing
            Me.lblSucursalDescripcion.Left = 0.0625!
            Me.lblSucursalDescripcion.Name = "lblSucursalDescripcion"
            Me.lblSucursalDescripcion.Style = "text-align: center"
            Me.lblSucursalDescripcion.Text = "Sucursal :"
            Me.lblSucursalDescripcion.Top = 0.5625!
            Me.lblSucursalDescripcion.Width = 6.375!
            '
            'Line1
            '
            Me.Line1.Height = 0!
            Me.Line1.Left = 0!
            Me.Line1.LineWeight = 1!
            Me.Line1.Name = "Line1"
            Me.Line1.Top = 0.75!
            Me.Line1.Width = 6.850394!
            Me.Line1.X1 = 6.850394!
            Me.Line1.X2 = 0!
            Me.Line1.Y1 = 0.75!
            Me.Line1.Y2 = 0.75!
            '
            'Line2
            '
            Me.Line2.Height = 0.25!
            Me.Line2.Left = 2.605369!
            Me.Line2.LineWeight = 1!
            Me.Line2.Name = "Line2"
            Me.Line2.Top = 0.7519687!
            Me.Line2.Width = 0!
            Me.Line2.X1 = 2.605369!
            Me.Line2.X2 = 2.605369!
            Me.Line2.Y1 = 0.7519687!
            Me.Line2.Y2 = 1.001969!
            '
            'Line3
            '
            Me.Line3.Height = 0.25!
            Me.Line3.Left = 0.7943459!
            Me.Line3.LineWeight = 1!
            Me.Line3.Name = "Line3"
            Me.Line3.Top = 0.7519687!
            Me.Line3.Width = 0!
            Me.Line3.X1 = 0.7943459!
            Me.Line3.X2 = 0.7943459!
            Me.Line3.Y1 = 0.7519687!
            Me.Line3.Y2 = 1.001969!
            '
            'Line4
            '
            Me.Line4.Height = 0.25!
            Me.Line4.Left = 3.628992!
            Me.Line4.LineWeight = 1!
            Me.Line4.Name = "Line4"
            Me.Line4.Top = 0.7519687!
            Me.Line4.Width = 0!
            Me.Line4.X1 = 3.628992!
            Me.Line4.X2 = 3.628992!
            Me.Line4.Y1 = 0.7519687!
            Me.Line4.Y2 = 1.001969!
            '
            'Line5
            '
            Me.Line5.Height = 0.25!
            Me.Line5.Left = 4.652614!
            Me.Line5.LineWeight = 1!
            Me.Line5.Name = "Line5"
            Me.Line5.Top = 0.7519687!
            Me.Line5.Width = 0!
            Me.Line5.X1 = 4.652614!
            Me.Line5.X2 = 4.652614!
            Me.Line5.Y1 = 0.7519687!
            Me.Line5.Y2 = 1.001969!
            '
            'Line6
            '
            Me.Line6.Height = 0.25!
            Me.Line6.Left = 5.833716!
            Me.Line6.LineWeight = 1!
            Me.Line6.Name = "Line6"
            Me.Line6.Top = 0.7519687!
            Me.Line6.Width = 0!
            Me.Line6.X1 = 5.833716!
            Me.Line6.X2 = 5.833716!
            Me.Line6.Y1 = 0.7519687!
            Me.Line6.Y2 = 1.001969!
            '
            'lblCaja
            '
            Me.lblCaja.Height = 0.2!
            Me.lblCaja.HyperLink = Nothing
            Me.lblCaja.Left = 0.0625!
            Me.lblCaja.Name = "lblCaja"
            Me.lblCaja.Style = "text-align: left"
            Me.lblCaja.Text = "Caja"
            Me.lblCaja.Top = 0.3125!
            Me.lblCaja.Width = 1!
            '
            'Label2
            '
            Me.Label2.Height = 0.2!
            Me.Label2.HyperLink = Nothing
            Me.Label2.Left = 0.813!
            Me.Label2.Name = "Label2"
            Me.Label2.Style = "text-align: left"
            Me.Label2.Text = "Folio SAP"
            Me.Label2.Top = 0.78!
            Me.Label2.Width = 0.875!
            '
            'Line7
            '
            Me.Line7.Height = 0.25!
            Me.Line7.Left = 1.739228!
            Me.Line7.LineWeight = 1!
            Me.Line7.Name = "Line7"
            Me.Line7.Top = 0.7519687!
            Me.Line7.Width = 0!
            Me.Line7.X1 = 1.739228!
            Me.Line7.X2 = 1.739228!
            Me.Line7.Y1 = 0.7519687!
            Me.Line7.Y2 = 1.001969!
            '
            'txtSucursal
            '
            Me.txtSucursal.Height = 0.2!
            Me.txtSucursal.Left = 1.711122!
            Me.txtSucursal.Name = "txtSucursal"
            Me.txtSucursal.Style = "text-align: center"
            Me.txtSucursal.Text = "003"
            Me.txtSucursal.Top = 0!
            Me.txtSucursal.Width = 0.8125!
            '
            'txtFolio
            '
            Me.txtFolio.Height = 0.2!
            Me.txtFolio.Left = 0.06299999!
            Me.txtFolio.Name = "txtFolio"
            Me.txtFolio.Style = "text-align: right"
            Me.txtFolio.Text = "Folio"
            Me.txtFolio.Top = 0!
            Me.txtFolio.Width = 0.6456615!
            '
            'txtFecha
            '
            Me.txtFecha.Height = 0.2!
            Me.txtFecha.Left = 2.75!
            Me.txtFecha.Name = "txtFecha"
            Me.txtFecha.OutputFormat = resources.GetString("txtFecha.OutputFormat")
            Me.txtFecha.Style = "text-align: center"
            Me.txtFecha.Text = "08/06/2005"
            Me.txtFecha.Top = 0!
            Me.txtFecha.Width = 0.75!
            '
            'txtImporte
            '
            Me.txtImporte.Height = 0.2!
            Me.txtImporte.Left = 3.6875!
            Me.txtImporte.Name = "txtImporte"
            Me.txtImporte.OutputFormat = resources.GetString("txtImporte.OutputFormat")
            Me.txtImporte.Style = "text-align: right"
            Me.txtImporte.Text = "Importe"
            Me.txtImporte.Top = 0!
            Me.txtImporte.Width = 0.875!
            '
            'txtCliente
            '
            Me.txtCliente.Height = 0.2!
            Me.txtCliente.Left = 4.690125!
            Me.txtCliente.Name = "txtCliente"
            Me.txtCliente.Style = "text-align: right"
            Me.txtCliente.Text = "Cliente"
            Me.txtCliente.Top = 0!
            Me.txtCliente.Width = 1.049869!
            '
            'txtReviso
            '
            Me.txtReviso.Height = 0.2!
            Me.txtReviso.Left = 5.905513!
            Me.txtReviso.Name = "txtReviso"
            Me.txtReviso.Text = "Reviso"
            Me.txtReviso.Top = 0!
            Me.txtReviso.Width = 0.8444882!
            '
            'txtFolioSAP
            '
            Me.txtFolioSAP.Height = 0.2!
            Me.txtFolioSAP.Left = 0.813!
            Me.txtFolioSAP.Name = "txtFolioSAP"
            Me.txtFolioSAP.Style = "text-align: center"
            Me.txtFolioSAP.Text = "FolioSAP"
            Me.txtFolioSAP.Top = 0!
            Me.txtFolioSAP.Width = 0.875!
            '
            'Shape2
            '
            Me.Shape2.Height = 0.25!
            Me.Shape2.Left = 0!
            Me.Shape2.Name = "Shape2"
            Me.Shape2.RoundingRadius = 9.999999!
            Me.Shape2.Top = 0!
            Me.Shape2.Width = 6.5!
            '
            'txtTotalImporte
            '
            Me.txtTotalImporte.Height = 0.1875!
            Me.txtTotalImporte.Left = 2.5!
            Me.txtTotalImporte.Name = "txtTotalImporte"
            Me.txtTotalImporte.OutputFormat = resources.GetString("txtTotalImporte.OutputFormat")
            Me.txtTotalImporte.Style = "text-align: right"
            Me.txtTotalImporte.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
            Me.txtTotalImporte.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
            Me.txtTotalImporte.Text = "Total"
            Me.txtTotalImporte.Top = 0.04!
            Me.txtTotalImporte.Width = 1.4375!
            '
            'Label1
            '
            Me.Label1.Height = 0.2!
            Me.Label1.HyperLink = Nothing
            Me.Label1.Left = 1.0625!
            Me.Label1.Name = "Label1"
            Me.Label1.Style = "text-align: center"
            Me.Label1.Text = "TOTALES   :"
            Me.Label1.Top = 0.04!
            Me.Label1.Width = 0.9375!
            '
            'ActiveReport1
            '
            Me.MasterReport = false
            Me.PageSettings.Margins.Left = 0.7875!
            Me.PageSettings.Margins.Right = 0.7875!
            Me.PageSettings.PaperHeight = 11!
            Me.PageSettings.PaperWidth = 8.5!
            Me.PrintWidth = 6.885417!
            Me.Sections.Add(Me.PageHeader)
            Me.Sections.Add(Me.GroupHeader1)
            Me.Sections.Add(Me.Detail)
            Me.Sections.Add(Me.GroupFooter1)
            Me.Sections.Add(Me.PageFooter)
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo"& _ 
                        "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit", "Heading1", "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei"& _ 
                        "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit", "Heading2", "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo"& _ 
                        "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit", "Heading3", "Normal"))
            CType(Me.lblFolio,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblSucursal,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblFecha,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblImporte,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblCliente,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblReviso,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblTitulo,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblRango,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblFechaReporte,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblPagina,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblSucursalDescripcion,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblCaja,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtSucursal,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFolio,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFecha,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtImporte,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtCliente,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtReviso,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFolioSAP,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtTotalImporte,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label1,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        
	End Sub

#End Region

End Class
