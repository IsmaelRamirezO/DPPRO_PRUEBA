Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU


Public Class rptReporteTraspasosPendientes
Inherits DataDynamics.ActiveReports.ActiveReport
    Public Sub New(ByVal dsDetalle As DataTable)
        MyBase.New()
        InitializeComponent()
        Dim oSAPMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        Dim oAlmacen As Almacen
        Dim oAlmacenesMgr As New CatalogoAlmacenesManager(oAppContext)
        oAlmacen = oAlmacenesMgr.Load(oSAPMgr.read_centros) 'oAppContext.ApplicationConfiguration.Almacen)

        If Not oAlmacen Is Nothing Then

            Me.txtSucursal.Text = "Sucursal: " & oAlmacen.ID & " " & oAlmacen.Descripcion

        Else

            Me.txtSucursal.Text = "Sucursal: " & oAppContext.ApplicationConfiguration.Almacen

        End If

        Me.DataSource = dsDetalle
        Me.DataMember = dsDetalle.TableName

        Me.txtTotal.Text = dsDetalle.Rows.Count
        Me.txtFechaReporte.Text = Now.Date.ToShortDateString

    End Sub
#Region "ActiveReports Designer generated code"
    Private WithEvents PageHeader As PageHeader = Nothing
    Private WithEvents GroupHeader1 As GroupHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents GroupFooter1 As GroupFooter = Nothing
    Private WithEvents PageFooter As PageFooter = Nothing
	Private Shape9 As Shape = Nothing
	Private Label1 As Label = Nothing
	Private txtSucursal As TextBox = Nothing
	Private txtFechaReporte As TextBox = Nothing
	Private Shape5 As Shape = Nothing
	Private Shape4 As Shape = Nothing
	Private Shape3 As Shape = Nothing
	Private Shape2 As Shape = Nothing
	Private Label4 As Label = Nothing
	Private Label5 As Label = Nothing
	Private Label6 As Label = Nothing
	Private Label9 As Label = Nothing
	Private Shape8 As Shape = Nothing
	Private Label12 As Label = Nothing
	Private txtOrigen As TextBox = Nothing
	Private txtDestino As TextBox = Nothing
	Private txtFecha As TextBox = Nothing
	Private txtGuia As TextBox = Nothing
	Private Line1 As Line = Nothing
	Private Line8 As Line = Nothing
	Private TxtBxReferencia As TextBox = Nothing
	Private Label11 As Label = Nothing
	Private txtTotal As TextBox = Nothing
	Private Shape10 As Shape = Nothing
	Private Line12 As Line = Nothing
	Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptReporteTraspasosPendientes))
            Me.Detail = New DataDynamics.ActiveReports.Detail()
            Me.PageHeader = New DataDynamics.ActiveReports.PageHeader()
            Me.PageFooter = New DataDynamics.ActiveReports.PageFooter()
            Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader()
            Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter()
            Me.Shape9 = New DataDynamics.ActiveReports.Shape()
            Me.Label1 = New DataDynamics.ActiveReports.Label()
            Me.txtSucursal = New DataDynamics.ActiveReports.TextBox()
            Me.txtFechaReporte = New DataDynamics.ActiveReports.TextBox()
            Me.Shape5 = New DataDynamics.ActiveReports.Shape()
            Me.Shape4 = New DataDynamics.ActiveReports.Shape()
            Me.Shape3 = New DataDynamics.ActiveReports.Shape()
            Me.Shape2 = New DataDynamics.ActiveReports.Shape()
            Me.Label4 = New DataDynamics.ActiveReports.Label()
            Me.Label5 = New DataDynamics.ActiveReports.Label()
            Me.Label6 = New DataDynamics.ActiveReports.Label()
            Me.Label9 = New DataDynamics.ActiveReports.Label()
            Me.Shape8 = New DataDynamics.ActiveReports.Shape()
            Me.Label12 = New DataDynamics.ActiveReports.Label()
            Me.txtOrigen = New DataDynamics.ActiveReports.TextBox()
            Me.txtDestino = New DataDynamics.ActiveReports.TextBox()
            Me.txtFecha = New DataDynamics.ActiveReports.TextBox()
            Me.txtGuia = New DataDynamics.ActiveReports.TextBox()
            Me.Line1 = New DataDynamics.ActiveReports.Line()
            Me.Line8 = New DataDynamics.ActiveReports.Line()
            Me.TxtBxReferencia = New DataDynamics.ActiveReports.TextBox()
            Me.Label11 = New DataDynamics.ActiveReports.Label()
            Me.txtTotal = New DataDynamics.ActiveReports.TextBox()
            Me.Shape10 = New DataDynamics.ActiveReports.Shape()
            Me.Line12 = New DataDynamics.ActiveReports.Line()
            CType(Me.Label1,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtSucursal,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFechaReporte,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label5,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label6,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label9,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label12,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtOrigen,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtDestino,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFecha,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtGuia,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TxtBxReferencia,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label11,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtTotal,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
            '
            'Detail
            '
            Me.Detail.ColumnSpacing = 0!
            Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtOrigen, Me.txtDestino, Me.txtFecha, Me.txtGuia, Me.Line1, Me.Line8, Me.TxtBxReferencia})
            Me.Detail.Height = 0.1763889!
            Me.Detail.Name = "Detail"
            '
            'PageHeader
            '
            Me.PageHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape9, Me.Label1, Me.txtSucursal, Me.txtFechaReporte})
            Me.PageHeader.Height = 0.9256945!
            Me.PageHeader.Name = "PageHeader"
            '
            'PageFooter
            '
            Me.PageFooter.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Line12})
            Me.PageFooter.Height = 0.02083333!
            Me.PageFooter.Name = "PageFooter"
            '
            'GroupHeader1
            '
            Me.GroupHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape5, Me.Shape4, Me.Shape3, Me.Shape2, Me.Label4, Me.Label5, Me.Label6, Me.Label9, Me.Shape8, Me.Label12})
            Me.GroupHeader1.Height = 0.2708333!
            Me.GroupHeader1.Name = "GroupHeader1"
            '
            'GroupFooter1
            '
            Me.GroupFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label11, Me.txtTotal, Me.Shape10})
            Me.GroupFooter1.Height = 0.4159722!
            Me.GroupFooter1.Name = "GroupFooter1"
            '
            'Shape9
            '
            Me.Shape9.Height = 0.8661417!
            Me.Shape9.Left = 0!
            Me.Shape9.Name = "Shape9"
            Me.Shape9.RoundingRadius = 9.999999!
            Me.Shape9.Top = 0!
            Me.Shape9.Width = 5.27559!
            '
            'Label1
            '
            Me.Label1.Height = 0.2!
            Me.Label1.HyperLink = Nothing
            Me.Label1.Left = 0.07874014!
            Me.Label1.Name = "Label1"
            Me.Label1.Style = "text-align: center"
            Me.Label1.Text = "REPORTE DE TRASPASOS SIN GRABAR"
            Me.Label1.Top = 0.0625!
            Me.Label1.Width = 5.03937!
            '
            'txtSucursal
            '
            Me.txtSucursal.Height = 0.2!
            Me.txtSucursal.Left = 0.07874014!
            Me.txtSucursal.Name = "txtSucursal"
            Me.txtSucursal.Style = "text-align: center"
            Me.txtSucursal.Text = "Sucursal"
            Me.txtSucursal.Top = 0.3380906!
            Me.txtSucursal.Width = 5.11811!
            '
            'txtFechaReporte
            '
            Me.txtFechaReporte.Height = 0.2!
            Me.txtFechaReporte.Left = 2.003445!
            Me.txtFechaReporte.Name = "txtFechaReporte"
            Me.txtFechaReporte.Top = 0.613681!
            Me.txtFechaReporte.Width = 1!
            '
            'Shape5
            '
            Me.Shape5.Height = 0.2755906!
            Me.Shape5.Left = 3.920767!
            Me.Shape5.Name = "Shape5"
            Me.Shape5.RoundingRadius = 9.999999!
            Me.Shape5.Top = 0!
            Me.Shape5.Width = 1.354823!
            '
            'Shape4
            '
            Me.Shape4.Height = 0.2755906!
            Me.Shape4.Left = 2.74311!
            Me.Shape4.Name = "Shape4"
            Me.Shape4.RoundingRadius = 9.999999!
            Me.Shape4.Top = 0!
            Me.Shape4.Width = 1.177657!
            '
            'Shape3
            '
            Me.Shape3.Height = 0.2755906!
            Me.Shape3.Left = 1.97441!
            Me.Shape3.Name = "Shape3"
            Me.Shape3.RoundingRadius = 9.999999!
            Me.Shape3.Top = 0!
            Me.Shape3.Width = 0.7687007!
            '
            'Shape2
            '
            Me.Shape2.Height = 0.2755906!
            Me.Shape2.Left = 1.070374!
            Me.Shape2.Name = "Shape2"
            Me.Shape2.RoundingRadius = 9.999999!
            Me.Shape2.Top = 0!
            Me.Shape2.Width = 0.9040354!
            '
            'Label4
            '
            Me.Label4.Height = 0.2!
            Me.Label4.HyperLink = Nothing
            Me.Label4.Left = 1.259842!
            Me.Label4.Name = "Label4"
            Me.Label4.Style = "text-align: center"
            Me.Label4.Text = "ORG."
            Me.Label4.Top = 0!
            Me.Label4.Width = 0.5565948!
            '
            'Label5
            '
            Me.Label5.Height = 0.2!
            Me.Label5.HyperLink = Nothing
            Me.Label5.Left = 2.204724!
            Me.Label5.Name = "Label5"
            Me.Label5.Style = "text-align: center"
            Me.Label5.Text = "DEST."
            Me.Label5.Top = 0!
            Me.Label5.Width = 0.472441!
            '
            'Label6
            '
            Me.Label6.Height = 0.2!
            Me.Label6.HyperLink = Nothing
            Me.Label6.Left = 2.913386!
            Me.Label6.Name = "Label6"
            Me.Label6.Style = "text-align: center"
            Me.Label6.Text = "FECHA"
            Me.Label6.Top = 0!
            Me.Label6.Width = 0.8341535!
            '
            'Label9
            '
            Me.Label9.Height = 0.2!
            Me.Label9.HyperLink = Nothing
            Me.Label9.Left = 4.173229!
            Me.Label9.Name = "Label9"
            Me.Label9.Style = "text-align: center"
            Me.Label9.Text = "GUIA"
            Me.Label9.Top = 0!
            Me.Label9.Width = 0.8341535!
            '
            'Shape8
            '
            Me.Shape8.Height = 0.2755906!
            Me.Shape8.Left = 0!
            Me.Shape8.Name = "Shape8"
            Me.Shape8.RoundingRadius = 9.999999!
            Me.Shape8.Top = 0!
            Me.Shape8.Width = 1.070374!
            '
            'Label12
            '
            Me.Label12.Height = 0.2!
            Me.Label12.HyperLink = Nothing
            Me.Label12.Left = 0.03937007!
            Me.Label12.Name = "Label12"
            Me.Label12.Style = "text-align: center"
            Me.Label12.Text = "REFERENCIA"
            Me.Label12.Top = 0!
            Me.Label12.Width = 1.000492!
            '
            'txtOrigen
            '
            Me.txtOrigen.DataField = "S. Almacen"
            Me.txtOrigen.Height = 0.1574803!
            Me.txtOrigen.Left = 1.259842!
            Me.txtOrigen.Name = "txtOrigen"
            Me.txtOrigen.OutputFormat = resources.GetString("txtOrigen.OutputFormat")
            Me.txtOrigen.Style = "text-align: center; font-size: 8.25pt"
            Me.txtOrigen.Top = 0!
            Me.txtOrigen.Width = 0.5152559!
            '
            'txtDestino
            '
            Me.txtDestino.DataField = "S. Destino"
            Me.txtDestino.Height = 0.1574803!
            Me.txtDestino.Left = 2.125984!
            Me.txtDestino.Name = "txtDestino"
            Me.txtDestino.OutputFormat = resources.GetString("txtDestino.OutputFormat")
            Me.txtDestino.Style = "text-align: center; font-size: 8.25pt"
            Me.txtDestino.Top = 0!
            Me.txtDestino.Width = 0.5669293!
            '
            'txtFecha
            '
            Me.txtFecha.DataField = "Fecha"
            Me.txtFecha.Height = 0.1574803!
            Me.txtFecha.Left = 2.913386!
            Me.txtFecha.Name = "txtFecha"
            Me.txtFecha.OutputFormat = resources.GetString("txtFecha.OutputFormat")
            Me.txtFecha.Style = "text-align: center; font-size: 8.25pt"
            Me.txtFecha.Top = 0!
            Me.txtFecha.Width = 0.9055118!
            '
            'txtGuia
            '
            Me.txtGuia.DataField = "Guia"
            Me.txtGuia.Height = 0.1574803!
            Me.txtGuia.Left = 4.094488!
            Me.txtGuia.Name = "txtGuia"
            Me.txtGuia.OutputFormat = resources.GetString("txtGuia.OutputFormat")
            Me.txtGuia.Style = "text-align: center; font-size: 8.25pt"
            Me.txtGuia.Top = 0!
            Me.txtGuia.Width = 1.053642!
            '
            'Line1
            '
            Me.Line1.Height = 0.2037949!
            Me.Line1.Left = 5.27559!
            Me.Line1.LineWeight = 1!
            Me.Line1.Name = "Line1"
            Me.Line1.Top = 5.866598E-09!
            Me.Line1.Width = 0!
            Me.Line1.X1 = 5.27559!
            Me.Line1.X2 = 5.27559!
            Me.Line1.Y1 = 5.866598E-09!
            Me.Line1.Y2 = 0.2037949!
            '
            'Line8
            '
            Me.Line8.Height = 0.1968504!
            Me.Line8.Left = 0.00694466!
            Me.Line8.LineWeight = 1!
            Me.Line8.Name = "Line8"
            Me.Line8.Top = 0!
            Me.Line8.Width = 0!
            Me.Line8.X1 = 0.00694466!
            Me.Line8.X2 = 0.00694466!
            Me.Line8.Y1 = 0!
            Me.Line8.Y2 = 0.1968504!
            '
            'TxtBxReferencia
            '
            Me.TxtBxReferencia.DataField = "Referencia"
            Me.TxtBxReferencia.Height = 0.1574803!
            Me.TxtBxReferencia.Left = 0.1181103!
            Me.TxtBxReferencia.Name = "TxtBxReferencia"
            Me.TxtBxReferencia.OutputFormat = resources.GetString("TxtBxReferencia.OutputFormat")
            Me.TxtBxReferencia.Style = "text-align: center; font-size: 8.25pt"
            Me.TxtBxReferencia.Top = 0!
            Me.TxtBxReferencia.Width = 0.9842521!
            '
            'Label11
            '
            Me.Label11.Height = 0.2!
            Me.Label11.HyperLink = Nothing
            Me.Label11.Left = 0.07874014!
            Me.Label11.Name = "Label11"
            Me.Label11.Style = ""
            Me.Label11.Text = "Total de Traspasos.:"
            Me.Label11.Top = 0.07874014!
            Me.Label11.Width = 1.433563!
            '
            'txtTotal
            '
            Me.txtTotal.Height = 0.2!
            Me.txtTotal.Left = 1.739173!
            Me.txtTotal.Name = "txtTotal"
            Me.txtTotal.OutputFormat = resources.GetString("txtTotal.OutputFormat")
            Me.txtTotal.Style = "text-align: right; font-size: 8.25pt"
            Me.txtTotal.Top = 0.07874014!
            Me.txtTotal.Width = 1!
            '
            'Shape10
            '
            Me.Shape10.Height = 0.3937007!
            Me.Shape10.Left = 0!
            Me.Shape10.Name = "Shape10"
            Me.Shape10.RoundingRadius = 9.999999!
            Me.Shape10.Top = 0!
            Me.Shape10.Width = 5.27559!
            '
            'Line12
            '
            Me.Line12.Height = 0!
            Me.Line12.Left = 0!
            Me.Line12.LineWeight = 1!
            Me.Line12.Name = "Line12"
            Me.Line12.Top = 0!
            Me.Line12.Width = 5.27559!
            Me.Line12.X1 = 5.27559!
            Me.Line12.X2 = 0!
            Me.Line12.Y1 = 0!
            Me.Line12.Y2 = 0!
            '
            'ActiveReport1
            '
            Me.MasterReport = false
            Me.PageSettings.Margins.Left = 0.39375!
            Me.PageSettings.Margins.Right = 0.39375!
            Me.PageSettings.PaperHeight = 11!
            Me.PageSettings.PaperWidth = 8.5!
            Me.PrintWidth = 5.333333!
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
            CType(Me.Label1,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtSucursal,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFechaReporte,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label5,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label6,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label9,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label12,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtOrigen,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtDestino,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFecha,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtGuia,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TxtBxReferencia,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label11,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtTotal,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        
	End Sub

#End Region


End Class
