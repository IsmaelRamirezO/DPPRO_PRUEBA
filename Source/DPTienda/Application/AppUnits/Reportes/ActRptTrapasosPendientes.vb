Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU

Public Class ActRptTrapasosPendientes
Inherits DataDynamics.ActiveReports.ActiveReport
    Public Sub New(ByVal tb As DataTable)
        MyBase.New()
        InitializeComponent()

        Dim oAlmacen As Almacen
        Dim oAlmacenesMgr As New CatalogoAlmacenesManager(oAppContext)
        Dim oSAPMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        oAlmacen = oAlmacenesMgr.Load(oSAPMgr.Read_Centros) 'oAppContext.ApplicationConfiguration.Almacen)

        If Not oAlmacen Is Nothing Then

            Me.txtSucursal.Text = oAlmacen.ID & " " & oAlmacen.Descripcion

        Else

            Me.txtSucursal.Text = oAppContext.ApplicationConfiguration.Almacen

        End If

        Me.DataSource = tb
        'Me.DataMember = dsDetalle.Tables(0).TableName

        'Me.txtTotal.Text = dsDetalle.Tables(0).Rows.Count
        Me.txtFechaReporte.Text = Now.Date.ToShortDateString

    End Sub
#Region "ActiveReports Designer generated code"
    Private WithEvents ReportHeader As ReportHeader = Nothing
    Private WithEvents PageHeader As PageHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents PageFooter As PageFooter = Nothing
    Private WithEvents ReportFooter As ReportFooter = Nothing
	Private Label1 As Label = Nothing
	Private Label2 As Label = Nothing
	Private txtSucursal As TextBox = Nothing
	Private txtFechaReporte As TextBox = Nothing
	Private Shape1 As Shape = Nothing
	Private Label8 As Label = Nothing
	Private Label7 As Label = Nothing
	Private Label3 As Label = Nothing
	Private Label4 As Label = Nothing
	Private Label5 As Label = Nothing
	Private Label6 As Label = Nothing
	Private Line1 As Line = Nothing
	Private Line2 As Line = Nothing
	Private Line3 As Line = Nothing
	Private Line4 As Line = Nothing
	Private Line5 As Line = Nothing
	Private Line6 As Line = Nothing
	Private Line10 As Line = Nothing
	Private Line11 As Line = Nothing
	Private TxtBxReferencia As TextBox = Nothing
	Private TxtBxStatus As TextBox = Nothing
	Private TxtBxOrigen As TextBox = Nothing
	Private TxtBxDestino As TextBox = Nothing
	Private Line7 As Line = Nothing
	Private Line8 As Line = Nothing
	Private TxtBxFecha As TextBox = Nothing
	Private TxtBxGuia As TextBox = Nothing
	Private Line9 As Line = Nothing
	Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ActRptTrapasosPendientes))
            Me.Detail = New DataDynamics.ActiveReports.Detail()
            Me.ReportHeader = New DataDynamics.ActiveReports.ReportHeader()
            Me.ReportFooter = New DataDynamics.ActiveReports.ReportFooter()
            Me.PageHeader = New DataDynamics.ActiveReports.PageHeader()
            Me.PageFooter = New DataDynamics.ActiveReports.PageFooter()
            Me.Label1 = New DataDynamics.ActiveReports.Label()
            Me.Label2 = New DataDynamics.ActiveReports.Label()
            Me.txtSucursal = New DataDynamics.ActiveReports.TextBox()
            Me.txtFechaReporte = New DataDynamics.ActiveReports.TextBox()
            Me.Shape1 = New DataDynamics.ActiveReports.Shape()
            Me.Label8 = New DataDynamics.ActiveReports.Label()
            Me.Label7 = New DataDynamics.ActiveReports.Label()
            Me.Label3 = New DataDynamics.ActiveReports.Label()
            Me.Label4 = New DataDynamics.ActiveReports.Label()
            Me.Label5 = New DataDynamics.ActiveReports.Label()
            Me.Label6 = New DataDynamics.ActiveReports.Label()
            Me.Line1 = New DataDynamics.ActiveReports.Line()
            Me.Line2 = New DataDynamics.ActiveReports.Line()
            Me.Line3 = New DataDynamics.ActiveReports.Line()
            Me.Line4 = New DataDynamics.ActiveReports.Line()
            Me.Line5 = New DataDynamics.ActiveReports.Line()
            Me.Line6 = New DataDynamics.ActiveReports.Line()
            Me.Line10 = New DataDynamics.ActiveReports.Line()
            Me.Line11 = New DataDynamics.ActiveReports.Line()
            Me.TxtBxReferencia = New DataDynamics.ActiveReports.TextBox()
            Me.TxtBxStatus = New DataDynamics.ActiveReports.TextBox()
            Me.TxtBxOrigen = New DataDynamics.ActiveReports.TextBox()
            Me.TxtBxDestino = New DataDynamics.ActiveReports.TextBox()
            Me.Line7 = New DataDynamics.ActiveReports.Line()
            Me.Line8 = New DataDynamics.ActiveReports.Line()
            Me.TxtBxFecha = New DataDynamics.ActiveReports.TextBox()
            Me.TxtBxGuia = New DataDynamics.ActiveReports.TextBox()
            Me.Line9 = New DataDynamics.ActiveReports.Line()
            CType(Me.Label1,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtSucursal,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFechaReporte,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label8,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label7,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label3,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label5,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label6,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TxtBxReferencia,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TxtBxStatus,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TxtBxOrigen,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TxtBxDestino,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TxtBxFecha,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TxtBxGuia,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
            '
            'Detail
            '
            Me.Detail.ColumnSpacing = 0!
            Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TxtBxReferencia, Me.TxtBxStatus, Me.TxtBxOrigen, Me.TxtBxDestino, Me.Line7, Me.Line8, Me.TxtBxFecha, Me.TxtBxGuia})
            Me.Detail.Height = 0.2361111!
            Me.Detail.Name = "Detail"
            '
            'ReportHeader
            '
            Me.ReportHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label1, Me.Label2, Me.txtSucursal, Me.txtFechaReporte, Me.Shape1})
            Me.ReportHeader.Height = 0.5625!
            Me.ReportHeader.Name = "ReportHeader"
            '
            'ReportFooter
            '
            Me.ReportFooter.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Line9})
            Me.ReportFooter.Height = 0.02083333!
            Me.ReportFooter.Name = "ReportFooter"
            '
            'PageHeader
            '
            Me.PageHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label8, Me.Label7, Me.Label3, Me.Label4, Me.Label5, Me.Label6, Me.Line1, Me.Line2, Me.Line3, Me.Line4, Me.Line5, Me.Line6, Me.Line10, Me.Line11})
            Me.PageHeader.Height = 0.3333333!
            Me.PageHeader.Name = "PageHeader"
            '
            'PageFooter
            '
            Me.PageFooter.Height = 0!
            Me.PageFooter.Name = "PageFooter"
            '
            'Label1
            '
            Me.Label1.Height = 0.2!
            Me.Label1.HyperLink = Nothing
            Me.Label1.Left = 1.720226!
            Me.Label1.Name = "Label1"
            Me.Label1.Style = "text-align: center; font-weight: bold; font-size: 12pt"
            Me.Label1.Text = "REPORTE DE TRASPASOS SIN GRABAR"
            Me.Label1.Top = 0!
            Me.Label1.Width = 3.622047!
            '
            'Label2
            '
            Me.Label2.Height = 0.2!
            Me.Label2.HyperLink = Nothing
            Me.Label2.Left = 0.5115651!
            Me.Label2.Name = "Label2"
            Me.Label2.Style = ""
            Me.Label2.Text = "Sucursal.:"
            Me.Label2.Top = 0.2987205!
            Me.Label2.Width = 0.6692913!
            '
            'txtSucursal
            '
            Me.txtSucursal.Height = 0.2!
            Me.txtSucursal.Left = 1.259596!
            Me.txtSucursal.Name = "txtSucursal"
            Me.txtSucursal.Text = "TextBox1"
            Me.txtSucursal.Top = 0.2987205!
            Me.txtSucursal.Width = 2.952756!
            '
            'txtFechaReporte
            '
            Me.txtFechaReporte.Height = 0.2!
            Me.txtFechaReporte.Left = 5.51181!
            Me.txtFechaReporte.Name = "txtFechaReporte"
            Me.txtFechaReporte.Top = 0.2987205!
            Me.txtFechaReporte.Width = 1!
            '
            'Shape1
            '
            Me.Shape1.Height = 0.551181!
            Me.Shape1.Left = 0!
            Me.Shape1.Name = "Shape1"
            Me.Shape1.RoundingRadius = 9.999999!
            Me.Shape1.Top = 0!
            Me.Shape1.Width = 7.007875!
            '
            'Label8
            '
            Me.Label8.Height = 0.2362205!
            Me.Label8.HyperLink = Nothing
            Me.Label8.Left = 5.948327!
            Me.Label8.Name = "Label8"
            Me.Label8.Style = ""
            Me.Label8.Text = "Guia"
            Me.Label8.Top = 0!
            Me.Label8.Width = 0.9547243!
            '
            'Label7
            '
            Me.Label7.Height = 0.2362205!
            Me.Label7.HyperLink = Nothing
            Me.Label7.Left = 4.635827!
            Me.Label7.Name = "Label7"
            Me.Label7.Style = ""
            Me.Label7.Text = "Fecha"
            Me.Label7.Top = 0!
            Me.Label7.Width = 0.9547243!
            '
            'Label3
            '
            Me.Label3.Height = 0.2362205!
            Me.Label3.HyperLink = Nothing
            Me.Label3.Left = 0.222441!
            Me.Label3.Name = "Label3"
            Me.Label3.Style = ""
            Me.Label3.Text = "Folio"
            Me.Label3.Top = 0!
            Me.Label3.Width = 0.8661417!
            '
            'Label4
            '
            Me.Label4.Height = 0.2362205!
            Me.Label4.HyperLink = Nothing
            Me.Label4.Left = 2.084646!
            Me.Label4.Name = "Label4"
            Me.Label4.Style = ""
            Me.Label4.Text = "Sucursal Almacen"
            Me.Label4.Top = 0!
            Me.Label4.Width = 1.181102!
            '
            'Label5
            '
            Me.Label5.Height = 0.2362205!
            Me.Label5.HyperLink = Nothing
            Me.Label5.Left = 3.385827!
            Me.Label5.Name = "Label5"
            Me.Label5.Style = ""
            Me.Label5.Text = "Sucursal Destino"
            Me.Label5.Top = 0!
            Me.Label5.Width = 1.102362!
            '
            'Label6
            '
            Me.Label6.Height = 0.2362205!
            Me.Label6.HyperLink = Nothing
            Me.Label6.Left = 1.308563!
            Me.Label6.Name = "Label6"
            Me.Label6.Style = ""
            Me.Label6.Text = "Estado"
            Me.Label6.Top = 0!
            Me.Label6.Width = 0.5024604!
            '
            'Line1
            '
            Me.Line1.Height = 0.2362205!
            Me.Line1.Left = 7.007875!
            Me.Line1.LineWeight = 1!
            Me.Line1.Name = "Line1"
            Me.Line1.Top = 0!
            Me.Line1.Width = 0!
            Me.Line1.X1 = 7.007875!
            Me.Line1.X2 = 7.007875!
            Me.Line1.Y1 = 0!
            Me.Line1.Y2 = 0.2362205!
            '
            'Line2
            '
            Me.Line2.Height = 0.2362205!
            Me.Line2.Left = 0!
            Me.Line2.LineWeight = 1!
            Me.Line2.Name = "Line2"
            Me.Line2.Top = 0!
            Me.Line2.Width = 0!
            Me.Line2.X1 = 0!
            Me.Line2.X2 = 0!
            Me.Line2.Y1 = 0!
            Me.Line2.Y2 = 0.2362205!
            '
            'Line3
            '
            Me.Line3.Height = 0!
            Me.Line3.Left = 0!
            Me.Line3.LineWeight = 1!
            Me.Line3.Name = "Line3"
            Me.Line3.Top = 0.2362205!
            Me.Line3.Width = 7.007875!
            Me.Line3.X1 = 7.007875!
            Me.Line3.X2 = 0!
            Me.Line3.Y1 = 0.2362205!
            Me.Line3.Y2 = 0.2362205!
            '
            'Line4
            '
            Me.Line4.Height = 0.2362205!
            Me.Line4.Left = 1.188047!
            Me.Line4.LineWeight = 1!
            Me.Line4.Name = "Line4"
            Me.Line4.Top = 0.006944444!
            Me.Line4.Width = 0!
            Me.Line4.X1 = 1.188047!
            Me.Line4.X2 = 1.188047!
            Me.Line4.Y1 = 0.2431649!
            Me.Line4.Y2 = 0.006944444!
            '
            'Line5
            '
            Me.Line5.Height = 0.2362205!
            Me.Line5.Left = 1.975449!
            Me.Line5.LineWeight = 1!
            Me.Line5.Name = "Line5"
            Me.Line5.Top = 0.006944444!
            Me.Line5.Width = 0!
            Me.Line5.X1 = 1.975449!
            Me.Line5.X2 = 1.975449!
            Me.Line5.Y1 = 0.2431649!
            Me.Line5.Y2 = 0.006944444!
            '
            'Line6
            '
            Me.Line6.Height = 0.2362205!
            Me.Line6.Left = 4.545084!
            Me.Line6.LineWeight = 1!
            Me.Line6.Name = "Line6"
            Me.Line6.Top = 0.006944444!
            Me.Line6.Width = 0!
            Me.Line6.X1 = 4.545084!
            Me.Line6.X2 = 4.545084!
            Me.Line6.Y1 = 0.2431649!
            Me.Line6.Y2 = 0.006944444!
            '
            'Line10
            '
            Me.Line10.Height = 0.2362205!
            Me.Line10.Left = 3.314031!
            Me.Line10.LineWeight = 1!
            Me.Line10.Name = "Line10"
            Me.Line10.Top = 0.006944418!
            Me.Line10.Width = 0!
            Me.Line10.X1 = 3.314031!
            Me.Line10.X2 = 3.314031!
            Me.Line10.Y1 = 0.2431649!
            Me.Line10.Y2 = 0.006944418!
            '
            'Line11
            '
            Me.Line11.Height = 0.2362205!
            Me.Line11.Left = 5.701334!
            Me.Line11.LineWeight = 1!
            Me.Line11.Name = "Line11"
            Me.Line11.Top = 0.006944444!
            Me.Line11.Width = 0!
            Me.Line11.X1 = 5.701334!
            Me.Line11.X2 = 5.701334!
            Me.Line11.Y1 = 0.2431649!
            Me.Line11.Y2 = 0.006944444!
            '
            'TxtBxReferencia
            '
            Me.TxtBxReferencia.DataField = "Referencia"
            Me.TxtBxReferencia.Height = 0.2362205!
            Me.TxtBxReferencia.Left = 0.222441!
            Me.TxtBxReferencia.Name = "TxtBxReferencia"
            Me.TxtBxReferencia.Text = "000000000"
            Me.TxtBxReferencia.Top = 0!
            Me.TxtBxReferencia.Width = 0.8550687!
            '
            'TxtBxStatus
            '
            Me.TxtBxStatus.DataField = "tatus"
            Me.TxtBxStatus.Height = 0.2362205!
            Me.TxtBxStatus.Left = 1.297244!
            Me.TxtBxStatus.Name = "TxtBxStatus"
            Me.TxtBxStatus.Text = "TRA"
            Me.TxtBxStatus.Top = 0!
            Me.TxtBxStatus.Width = 0.5137797!
            '
            'TxtBxOrigen
            '
            Me.TxtBxOrigen.DataField = "S. Almacen"
            Me.TxtBxOrigen.Height = 0.2362205!
            Me.TxtBxOrigen.Left = 2.084646!
            Me.TxtBxOrigen.Name = "TxtBxOrigen"
            Me.TxtBxOrigen.Text = "Origen"
            Me.TxtBxOrigen.Top = 0!
            Me.TxtBxOrigen.Width = 1.181102!
            '
            'TxtBxDestino
            '
            Me.TxtBxDestino.DataField = "S. Destino"
            Me.TxtBxDestino.Height = 0.2362205!
            Me.TxtBxDestino.Left = 3.36565!
            Me.TxtBxDestino.Name = "TxtBxDestino"
            Me.TxtBxDestino.Text = "Destino"
            Me.TxtBxDestino.Top = 0!
            Me.TxtBxDestino.Width = 1.102363!
            '
            'Line7
            '
            Me.Line7.Height = 0.2362205!
            Me.Line7.Left = 7.007875!
            Me.Line7.LineWeight = 1!
            Me.Line7.Name = "Line7"
            Me.Line7.Top = 0!
            Me.Line7.Width = 0!
            Me.Line7.X1 = 7.007875!
            Me.Line7.X2 = 7.007875!
            Me.Line7.Y1 = 0!
            Me.Line7.Y2 = 0.2362205!
            '
            'Line8
            '
            Me.Line8.Height = 0.2362205!
            Me.Line8.Left = 0!
            Me.Line8.LineWeight = 1!
            Me.Line8.Name = "Line8"
            Me.Line8.Top = 0!
            Me.Line8.Width = 0!
            Me.Line8.X1 = 0!
            Me.Line8.X2 = 0!
            Me.Line8.Y1 = 0!
            Me.Line8.Y2 = 0.2362205!
            '
            'TxtBxFecha
            '
            Me.TxtBxFecha.DataField = "Fecha"
            Me.TxtBxFecha.Height = 0.2362205!
            Me.TxtBxFecha.Left = 4.645669!
            Me.TxtBxFecha.Name = "TxtBxFecha"
            Me.TxtBxFecha.Text = "Fecha"
            Me.TxtBxFecha.Top = 0!
            Me.TxtBxFecha.Width = 0.944882!
            '
            'TxtBxGuia
            '
            Me.TxtBxGuia.DataField = "Guia"
            Me.TxtBxGuia.Height = 0.2362205!
            Me.TxtBxGuia.Left = 5.833169!
            Me.TxtBxGuia.Name = "TxtBxGuia"
            Me.TxtBxGuia.Text = "Guia"
            Me.TxtBxGuia.Top = 0!
            Me.TxtBxGuia.Width = 0.944882!
            '
            'Line9
            '
            Me.Line9.Height = 0!
            Me.Line9.Left = 0!
            Me.Line9.LineWeight = 1!
            Me.Line9.Name = "Line9"
            Me.Line9.Top = 0!
            Me.Line9.Width = 7.007875!
            Me.Line9.X1 = 7.007875!
            Me.Line9.X2 = 0!
            Me.Line9.Y1 = 0!
            Me.Line9.Y2 = 0!
            '
            'ActiveReport1
            '
            Me.MasterReport = false
            Me.PageSettings.Margins.Bottom = 0.7875!
            Me.PageSettings.Margins.Left = 0.5902778!
            Me.PageSettings.Margins.Right = 0.5902778!
            Me.PageSettings.Margins.Top = 0.7875!
            Me.PageSettings.PaperHeight = 11!
            Me.PageSettings.PaperWidth = 8.5!
            Me.PrintWidth = 7.052083!
            Me.Sections.Add(Me.ReportHeader)
            Me.Sections.Add(Me.PageHeader)
            Me.Sections.Add(Me.Detail)
            Me.Sections.Add(Me.PageFooter)
            Me.Sections.Add(Me.ReportFooter)
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo"& _ 
                        "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit", "Heading1", "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei"& _ 
                        "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit", "Heading2", "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo"& _ 
                        "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit", "Heading3", "Normal"))
            CType(Me.Label1,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtSucursal,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFechaReporte,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label8,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label7,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label3,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label5,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label6,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TxtBxReferencia,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TxtBxStatus,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TxtBxOrigen,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TxtBxDestino,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TxtBxFecha,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TxtBxGuia,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        
	End Sub

#End Region
End Class
