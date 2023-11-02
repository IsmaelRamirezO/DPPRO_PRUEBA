Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Public Class CostosdeVentaDetalleReport
    Inherits DataDynamics.ActiveReports.ActiveReport

    Public Sub New(ByVal Data As DataTable, _
                    ByVal strRango As String, _
                    ByVal strCaja As String, _
                    ByVal strAlmacen As String)

        MyBase.New()

        InitializeComponent()

        Me.DataSource = Data
        Me.DataMember = Data.TableName

        Me.lblFecha.Text = Format(Date.Now, "short date")
        Me.lblCaja.Text = strCaja
        Me.lblRango.Text = strRango
        Me.lblSucursal.Text = strAlmacen

        Me.PageSettings.Margins.Top = 0.5
        Me.PageSettings.Margins.Left = 0.3

        Me.Run()

    End Sub

#Region "ActiveReports Designer generated code"
    Private WithEvents PageHeader As PageHeader = Nothing
    Private WithEvents GroupHeader1 As GroupHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents GroupFooter1 As GroupFooter = Nothing
    Private WithEvents PageFooter As PageFooter = Nothing
	Private Shape1 As Shape = Nothing
	Private Label1 As Label = Nothing
	Private lblRango As Label = Nothing
	Private lblSucursal As Label = Nothing
	Private lblFecha As Label = Nothing
	Private lblCaja As Label = Nothing
	Private Label6 As Label = Nothing
	Private TextBox1 As TextBox = Nothing
	Private Label7 As Label = Nothing
	Private Label8 As Label = Nothing
	Private Label9 As Label = Nothing
	Private Label10 As Label = Nothing
	Private Label11 As Label = Nothing
	Private Label12 As Label = Nothing
	Private Label13 As Label = Nothing
	Private Label14 As Label = Nothing
	Private Label15 As Label = Nothing
	Private Label16 As Label = Nothing
	Private Label17 As Label = Nothing
	Private Line1 As Line = Nothing
	Private Line2 As Line = Nothing
	Private Line3 As Line = Nothing
	Private Line4 As Line = Nothing
	Private Line5 As Line = Nothing
	Private Line6 As Line = Nothing
	Private Line7 As Line = Nothing
	Private Line8 As Line = Nothing
	Private Line9 As Line = Nothing
	Private Line10 As Line = Nothing
	Private Line11 As Line = Nothing
	Private detFolio As TextBox = Nothing
	Private detCodigo As TextBox = Nothing
	Private detDescrip As TextBox = Nothing
	Private detCantidad As TextBox = Nothing
	Private detTalla As TextBox = Nothing
	Private detImporte As TextBox = Nothing
	Private detTotal As TextBox = Nothing
	Private detDscto As TextBox = Nothing
	Private detCDscto As TextBox = Nothing
	Private detCostoSNC As TextBox = Nothing
	Private detCostoCNC As TextBox = Nothing
	Private lblPc As Label = Nothing
	Private Shape2 As Shape = Nothing
	Private Label18 As Label = Nothing
	Private totCantidad As TextBox = Nothing
	Private totTotal As TextBox = Nothing
	Private totDscto As TextBox = Nothing
	Private totCostoSNC As TextBox = Nothing
	Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CostosdeVentaDetalleReport))
            Me.Detail = New DataDynamics.ActiveReports.Detail()
            Me.PageHeader = New DataDynamics.ActiveReports.PageHeader()
            Me.PageFooter = New DataDynamics.ActiveReports.PageFooter()
            Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader()
            Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter()
            Me.Shape1 = New DataDynamics.ActiveReports.Shape()
            Me.Label1 = New DataDynamics.ActiveReports.Label()
            Me.lblRango = New DataDynamics.ActiveReports.Label()
            Me.lblSucursal = New DataDynamics.ActiveReports.Label()
            Me.lblFecha = New DataDynamics.ActiveReports.Label()
            Me.lblCaja = New DataDynamics.ActiveReports.Label()
            Me.Label6 = New DataDynamics.ActiveReports.Label()
            Me.TextBox1 = New DataDynamics.ActiveReports.TextBox()
            Me.Label7 = New DataDynamics.ActiveReports.Label()
            Me.Label8 = New DataDynamics.ActiveReports.Label()
            Me.Label9 = New DataDynamics.ActiveReports.Label()
            Me.Label10 = New DataDynamics.ActiveReports.Label()
            Me.Label11 = New DataDynamics.ActiveReports.Label()
            Me.Label12 = New DataDynamics.ActiveReports.Label()
            Me.Label13 = New DataDynamics.ActiveReports.Label()
            Me.Label14 = New DataDynamics.ActiveReports.Label()
            Me.Label15 = New DataDynamics.ActiveReports.Label()
            Me.Label16 = New DataDynamics.ActiveReports.Label()
            Me.Label17 = New DataDynamics.ActiveReports.Label()
            Me.Line1 = New DataDynamics.ActiveReports.Line()
            Me.Line2 = New DataDynamics.ActiveReports.Line()
            Me.Line3 = New DataDynamics.ActiveReports.Line()
            Me.Line4 = New DataDynamics.ActiveReports.Line()
            Me.Line5 = New DataDynamics.ActiveReports.Line()
            Me.Line6 = New DataDynamics.ActiveReports.Line()
            Me.Line7 = New DataDynamics.ActiveReports.Line()
            Me.Line8 = New DataDynamics.ActiveReports.Line()
            Me.Line9 = New DataDynamics.ActiveReports.Line()
            Me.Line10 = New DataDynamics.ActiveReports.Line()
            Me.Line11 = New DataDynamics.ActiveReports.Line()
            Me.detFolio = New DataDynamics.ActiveReports.TextBox()
            Me.detCodigo = New DataDynamics.ActiveReports.TextBox()
            Me.detDescrip = New DataDynamics.ActiveReports.TextBox()
            Me.detCantidad = New DataDynamics.ActiveReports.TextBox()
            Me.detTalla = New DataDynamics.ActiveReports.TextBox()
            Me.detImporte = New DataDynamics.ActiveReports.TextBox()
            Me.detTotal = New DataDynamics.ActiveReports.TextBox()
            Me.detDscto = New DataDynamics.ActiveReports.TextBox()
            Me.detCDscto = New DataDynamics.ActiveReports.TextBox()
            Me.detCostoSNC = New DataDynamics.ActiveReports.TextBox()
            Me.detCostoCNC = New DataDynamics.ActiveReports.TextBox()
            Me.lblPc = New DataDynamics.ActiveReports.Label()
            Me.Shape2 = New DataDynamics.ActiveReports.Shape()
            Me.Label18 = New DataDynamics.ActiveReports.Label()
            Me.totCantidad = New DataDynamics.ActiveReports.TextBox()
            Me.totTotal = New DataDynamics.ActiveReports.TextBox()
            Me.totDscto = New DataDynamics.ActiveReports.TextBox()
            Me.totCostoSNC = New DataDynamics.ActiveReports.TextBox()
            CType(Me.Label1,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblRango,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblSucursal,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblFecha,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblCaja,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label6,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox1,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label7,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label8,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label9,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label10,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label11,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label12,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label13,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label14,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label15,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label16,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label17,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.detFolio,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.detCodigo,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.detDescrip,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.detCantidad,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.detTalla,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.detImporte,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.detTotal,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.detDscto,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.detCDscto,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.detCostoSNC,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.detCostoCNC,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblPc,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label18,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.totCantidad,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.totTotal,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.totDscto,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.totCostoSNC,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
            '
            'Detail
            '
            Me.Detail.ColumnSpacing = 0!
            Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.detFolio, Me.detCodigo, Me.detDescrip, Me.detCantidad, Me.detTalla, Me.detImporte, Me.detTotal, Me.detDscto, Me.detCDscto, Me.detCostoSNC, Me.detCostoCNC, Me.lblPc})
            Me.Detail.Height = 0.1451389!
            Me.Detail.Name = "Detail"
            '
            'PageHeader
            '
            Me.PageHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape1, Me.Label1, Me.lblRango, Me.lblSucursal, Me.lblFecha, Me.lblCaja, Me.Label6, Me.TextBox1, Me.Label7, Me.Label8, Me.Label9, Me.Label10, Me.Label11, Me.Label12, Me.Label13, Me.Label14, Me.Label15, Me.Label16, Me.Label17, Me.Line1, Me.Line2, Me.Line3, Me.Line4, Me.Line5, Me.Line6, Me.Line7, Me.Line8, Me.Line9, Me.Line10, Me.Line11})
            Me.PageHeader.Height = 1.134722!
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
            Me.GroupFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape2, Me.Label18, Me.totCantidad, Me.totTotal, Me.totDscto, Me.totCostoSNC})
            Me.GroupFooter1.Height = 0.3333333!
            Me.GroupFooter1.Name = "GroupFooter1"
            '
            'Shape1
            '
            Me.Shape1.Height = 1.125!
            Me.Shape1.Left = 0!
            Me.Shape1.Name = "Shape1"
            Me.Shape1.RoundingRadius = 9.999999!
            Me.Shape1.Top = 0!
            Me.Shape1.Width = 7.75!
            '
            'Label1
            '
            Me.Label1.Height = 0.2!
            Me.Label1.HyperLink = Nothing
            Me.Label1.Left = 2!
            Me.Label1.Name = "Label1"
            Me.Label1.Style = "text-align: center"
            Me.Label1.Text = "REPORTE DE COSTOS DE VENTA EN DETALLE"
            Me.Label1.Top = 0.0625!
            Me.Label1.Width = 4.0625!
            '
            'lblRango
            '
            Me.lblRango.Height = 0.2!
            Me.lblRango.HyperLink = Nothing
            Me.lblRango.Left = 2!
            Me.lblRango.Name = "lblRango"
            Me.lblRango.Style = "text-align: center"
            Me.lblRango.Text = "De : 00/00/0000   Al : 0/00/0000"
            Me.lblRango.Top = 0.3125!
            Me.lblRango.Width = 4.0625!
            '
            'lblSucursal
            '
            Me.lblSucursal.Height = 0.2!
            Me.lblSucursal.HyperLink = Nothing
            Me.lblSucursal.Left = 2!
            Me.lblSucursal.Name = "lblSucursal"
            Me.lblSucursal.Style = "text-align: center"
            Me.lblSucursal.Text = "Sucursal :"
            Me.lblSucursal.Top = 0.5625!
            Me.lblSucursal.Width = 4.0625!
            '
            'lblFecha
            '
            Me.lblFecha.Height = 0.2!
            Me.lblFecha.HyperLink = Nothing
            Me.lblFecha.Left = 0.125!
            Me.lblFecha.Name = "lblFecha"
            Me.lblFecha.Style = "text-align: justify"
            Me.lblFecha.Text = "Fecha :"
            Me.lblFecha.Top = 0.3125!
            Me.lblFecha.Width = 1.1875!
            '
            'lblCaja
            '
            Me.lblCaja.Height = 0.2!
            Me.lblCaja.HyperLink = Nothing
            Me.lblCaja.Left = 0.125!
            Me.lblCaja.Name = "lblCaja"
            Me.lblCaja.Style = "text-align: justify"
            Me.lblCaja.Text = "Caja # :"
            Me.lblCaja.Top = 0.5625!
            Me.lblCaja.Width = 1.1875!
            '
            'Label6
            '
            Me.Label6.Height = 0.2!
            Me.Label6.HyperLink = Nothing
            Me.Label6.Left = 6.75!
            Me.Label6.Name = "Label6"
            Me.Label6.Style = "text-align: justify"
            Me.Label6.Text = "Pag. :"
            Me.Label6.Top = 0.3125!
            Me.Label6.Width = 0.4375!
            '
            'TextBox1
            '
            Me.TextBox1.Height = 0.2!
            Me.TextBox1.Left = 7.25!
            Me.TextBox1.Name = "TextBox1"
            Me.TextBox1.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
            Me.TextBox1.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount
            Me.TextBox1.Top = 0.3125!
            Me.TextBox1.Width = 0.4375!
            '
            'Label7
            '
            Me.Label7.Height = 0.2!
            Me.Label7.HyperLink = Nothing
            Me.Label7.Left = 0.0625!
            Me.Label7.Name = "Label7"
            Me.Label7.Style = "text-align: center; font-size: 8pt"
            Me.Label7.Text = "FOLIO"
            Me.Label7.Top = 0.875!
            Me.Label7.Width = 0.4375!
            '
            'Label8
            '
            Me.Label8.Height = 0.2!
            Me.Label8.HyperLink = Nothing
            Me.Label8.Left = 0.625!
            Me.Label8.Name = "Label8"
            Me.Label8.Style = "text-align: justify; font-size: 8pt"
            Me.Label8.Text = "CODIGO"
            Me.Label8.Top = 0.875!
            Me.Label8.Width = 1.0625!
            '
            'Label9
            '
            Me.Label9.Height = 0.2!
            Me.Label9.HyperLink = Nothing
            Me.Label9.Left = 2.0625!
            Me.Label9.Name = "Label9"
            Me.Label9.Style = "text-align: justify; font-size: 8pt"
            Me.Label9.Text = "DESCRIPCION"
            Me.Label9.Top = 0.875!
            Me.Label9.Width = 1.0625!
            '
            'Label10
            '
            Me.Label10.Height = 0.2!
            Me.Label10.HyperLink = Nothing
            Me.Label10.Left = 3.375!
            Me.Label10.Name = "Label10"
            Me.Label10.Style = "text-align: center; font-size: 8pt"
            Me.Label10.Text = "Cant."
            Me.Label10.Top = 0.875!
            Me.Label10.Width = 0.375!
            '
            'Label11
            '
            Me.Label11.Height = 0.2!
            Me.Label11.HyperLink = Nothing
            Me.Label11.Left = 3.8125!
            Me.Label11.Name = "Label11"
            Me.Label11.Style = "text-align: center; font-size: 8pt"
            Me.Label11.Text = "Talla"
            Me.Label11.Top = 0.875!
            Me.Label11.Width = 0.3125!
            '
            'Label12
            '
            Me.Label12.Height = 0.2!
            Me.Label12.HyperLink = Nothing
            Me.Label12.Left = 4.25!
            Me.Label12.Name = "Label12"
            Me.Label12.Style = "text-align: center; font-size: 8pt"
            Me.Label12.Text = "Importe"
            Me.Label12.Top = 0.875!
            Me.Label12.Width = 0.5625!
            '
            'Label13
            '
            Me.Label13.Height = 0.2!
            Me.Label13.HyperLink = Nothing
            Me.Label13.Left = 4.9375!
            Me.Label13.Name = "Label13"
            Me.Label13.Style = "text-align: center; font-size: 8pt"
            Me.Label13.Text = "TOTAL"
            Me.Label13.Top = 0.875!
            Me.Label13.Width = 0.4375!
            '
            'Label14
            '
            Me.Label14.Height = 0.2!
            Me.Label14.HyperLink = Nothing
            Me.Label14.Left = 5.4375!
            Me.Label14.Name = "Label14"
            Me.Label14.Style = "text-align: center; font-size: 8pt"
            Me.Label14.Text = "Dscto."
            Me.Label14.Top = 0.875!
            Me.Label14.Width = 0.4375!
            '
            'Label15
            '
            Me.Label15.Height = 0.2625!
            Me.Label15.HyperLink = Nothing
            Me.Label15.Left = 5.9375!
            Me.Label15.Name = "Label15"
            Me.Label15.Style = "text-align: center; font-size: 8pt"
            Me.Label15.Text = "Cant. Dscto."
            Me.Label15.Top = 0.8125!
            Me.Label15.Width = 0.5!
            '
            'Label16
            '
            Me.Label16.Height = 0.325!
            Me.Label16.HyperLink = Nothing
            Me.Label16.Left = 6.5!
            Me.Label16.Name = "Label16"
            Me.Label16.Style = "text-align: center; font-size: 8pt"
            Me.Label16.Text = "Importe Neto"
            Me.Label16.Top = 0.8125!
            Me.Label16.Width = 0.5625!
            '
            'Label17
            '
            Me.Label17.Height = 0.2625!
            Me.Label17.HyperLink = Nothing
            Me.Label17.Left = 7.125!
            Me.Label17.Name = "Label17"
            Me.Label17.Style = "text-align: center; font-size: 8pt"
            Me.Label17.Text = "Costo"
            Me.Label17.Top = 0.8125!
            Me.Label17.Width = 0.5625!
            '
            'Line1
            '
            Me.Line1.Height = 0!
            Me.Line1.Left = 0!
            Me.Line1.LineWeight = 1!
            Me.Line1.Name = "Line1"
            Me.Line1.Top = 0.8125!
            Me.Line1.Width = 7.75!
            Me.Line1.X1 = 7.75!
            Me.Line1.X2 = 0!
            Me.Line1.Y1 = 0.8125!
            Me.Line1.Y2 = 0.8125!
            '
            'Line2
            '
            Me.Line2.Height = 0.3125!
            Me.Line2.Left = 7.125!
            Me.Line2.LineWeight = 1!
            Me.Line2.Name = "Line2"
            Me.Line2.Top = 0.8125!
            Me.Line2.Width = 0!
            Me.Line2.X1 = 7.125!
            Me.Line2.X2 = 7.125!
            Me.Line2.Y1 = 0.8125!
            Me.Line2.Y2 = 1.125!
            '
            'Line3
            '
            Me.Line3.Height = 0.3125!
            Me.Line3.Left = 6.444445!
            Me.Line3.LineWeight = 1!
            Me.Line3.Name = "Line3"
            Me.Line3.Top = 0.8194444!
            Me.Line3.Width = 0!
            Me.Line3.X1 = 6.444445!
            Me.Line3.X2 = 6.444445!
            Me.Line3.Y1 = 0.8194444!
            Me.Line3.Y2 = 1.131944!
            '
            'Line4
            '
            Me.Line4.Height = 0.3125!
            Me.Line4.Left = 5.881945!
            Me.Line4.LineWeight = 1!
            Me.Line4.Name = "Line4"
            Me.Line4.Top = 0.8194444!
            Me.Line4.Width = 0!
            Me.Line4.X1 = 5.881945!
            Me.Line4.X2 = 5.881945!
            Me.Line4.Y1 = 0.8194444!
            Me.Line4.Y2 = 1.131944!
            '
            'Line5
            '
            Me.Line5.Height = 0.3125!
            Me.Line5.Left = 5.444445!
            Me.Line5.LineWeight = 1!
            Me.Line5.Name = "Line5"
            Me.Line5.Top = 0.8194444!
            Me.Line5.Width = 0!
            Me.Line5.X1 = 5.444445!
            Me.Line5.X2 = 5.444445!
            Me.Line5.Y1 = 0.8194444!
            Me.Line5.Y2 = 1.131944!
            '
            'Line6
            '
            Me.Line6.Height = 0.3125!
            Me.Line6.Left = 4.881945!
            Me.Line6.LineWeight = 1!
            Me.Line6.Name = "Line6"
            Me.Line6.Top = 0.8194444!
            Me.Line6.Width = 0!
            Me.Line6.X1 = 4.881945!
            Me.Line6.X2 = 4.881945!
            Me.Line6.Y1 = 0.8194444!
            Me.Line6.Y2 = 1.131944!
            '
            'Line7
            '
            Me.Line7.Height = 0.3125!
            Me.Line7.Left = 4.194445!
            Me.Line7.LineWeight = 1!
            Me.Line7.Name = "Line7"
            Me.Line7.Top = 0.8194444!
            Me.Line7.Width = 0!
            Me.Line7.X1 = 4.194445!
            Me.Line7.X2 = 4.194445!
            Me.Line7.Y1 = 0.8194444!
            Me.Line7.Y2 = 1.131944!
            '
            'Line8
            '
            Me.Line8.Height = 0.3125!
            Me.Line8.Left = 3.756944!
            Me.Line8.LineWeight = 1!
            Me.Line8.Name = "Line8"
            Me.Line8.Top = 0.8194444!
            Me.Line8.Width = 0!
            Me.Line8.X1 = 3.756944!
            Me.Line8.X2 = 3.756944!
            Me.Line8.Y1 = 0.8194444!
            Me.Line8.Y2 = 1.131944!
            '
            'Line9
            '
            Me.Line9.Height = 0.3125!
            Me.Line9.Left = 3.381944!
            Me.Line9.LineWeight = 1!
            Me.Line9.Name = "Line9"
            Me.Line9.Top = 0.8194444!
            Me.Line9.Width = 0!
            Me.Line9.X1 = 3.381944!
            Me.Line9.X2 = 3.381944!
            Me.Line9.Y1 = 0.8194444!
            Me.Line9.Y2 = 1.131944!
            '
            'Line10
            '
            Me.Line10.Height = 0.3125!
            Me.Line10.Left = 2.006944!
            Me.Line10.LineWeight = 1!
            Me.Line10.Name = "Line10"
            Me.Line10.Top = 0.8194444!
            Me.Line10.Width = 0!
            Me.Line10.X1 = 2.006944!
            Me.Line10.X2 = 2.006944!
            Me.Line10.Y1 = 0.8194444!
            Me.Line10.Y2 = 1.131944!
            '
            'Line11
            '
            Me.Line11.Height = 0.3125!
            Me.Line11.Left = 0.5694444!
            Me.Line11.LineWeight = 1!
            Me.Line11.Name = "Line11"
            Me.Line11.Top = 0.8194444!
            Me.Line11.Width = 0!
            Me.Line11.X1 = 0.5694444!
            Me.Line11.X2 = 0.5694444!
            Me.Line11.Y1 = 0.8194444!
            Me.Line11.Y2 = 1.131944!
            '
            'detFolio
            '
            Me.detFolio.DataField = "Folio"
            Me.detFolio.Height = 0.1375!
            Me.detFolio.Left = 0!
            Me.detFolio.Name = "detFolio"
            Me.detFolio.Style = "text-align: right; font-size: 8pt"
            Me.detFolio.Text = "Folio"
            Me.detFolio.Top = 0!
            Me.detFolio.Width = 0.5625!
            '
            'detCodigo
            '
            Me.detCodigo.CanGrow = false
            Me.detCodigo.DataField = "Codigo"
            Me.detCodigo.Height = 0.1375!
            Me.detCodigo.Left = 0.625!
            Me.detCodigo.Name = "detCodigo"
            Me.detCodigo.Style = "font-size: 8pt"
            Me.detCodigo.Text = "Codigo"
            Me.detCodigo.Top = 0!
            Me.detCodigo.Width = 1.375!
            '
            'detDescrip
            '
            Me.detDescrip.CanGrow = false
            Me.detDescrip.DataField = "Descripcion"
            Me.detDescrip.Height = 0.1375!
            Me.detDescrip.Left = 2.0625!
            Me.detDescrip.Name = "detDescrip"
            Me.detDescrip.Style = "font-size: 8pt"
            Me.detDescrip.Text = "Descripcion"
            Me.detDescrip.Top = 0!
            Me.detDescrip.Width = 1.3125!
            '
            'detCantidad
            '
            Me.detCantidad.DataField = "Cantidad"
            Me.detCantidad.Height = 0.1375!
            Me.detCantidad.Left = 3.375!
            Me.detCantidad.Name = "detCantidad"
            Me.detCantidad.OutputFormat = resources.GetString("detCantidad.OutputFormat")
            Me.detCantidad.Style = "text-align: right; font-size: 8pt"
            Me.detCantidad.Text = "Can"
            Me.detCantidad.Top = 0!
            Me.detCantidad.Width = 0.3125!
            '
            'detTalla
            '
            Me.detTalla.DataField = "Talla"
            Me.detTalla.Height = 0.1375!
            Me.detTalla.Left = 3.75!
            Me.detTalla.Name = "detTalla"
            Me.detTalla.OutputFormat = resources.GetString("detTalla.OutputFormat")
            Me.detTalla.Style = "text-align: right; font-size: 8pt"
            Me.detTalla.Text = "Talla"
            Me.detTalla.Top = 0!
            Me.detTalla.Width = 0.3125!
            '
            'detImporte
            '
            Me.detImporte.DataField = "Importe"
            Me.detImporte.Height = 0.1375!
            Me.detImporte.Left = 4.125!
            Me.detImporte.Name = "detImporte"
            Me.detImporte.OutputFormat = resources.GetString("detImporte.OutputFormat")
            Me.detImporte.Style = "text-align: right; font-size: 8pt"
            Me.detImporte.Text = "Importe"
            Me.detImporte.Top = 0!
            Me.detImporte.Width = 0.625!
            '
            'detTotal
            '
            Me.detTotal.DataField = "Total"
            Me.detTotal.Height = 0.1375!
            Me.detTotal.Left = 4.8125!
            Me.detTotal.Name = "detTotal"
            Me.detTotal.OutputFormat = resources.GetString("detTotal.OutputFormat")
            Me.detTotal.Style = "text-align: right; font-size: 8pt"
            Me.detTotal.Text = "Total"
            Me.detTotal.Top = 0!
            Me.detTotal.Width = 0.5625!
            '
            'detDscto
            '
            Me.detDscto.DataField = "Descuento"
            Me.detDscto.Height = 0.1375!
            Me.detDscto.Left = 5.4375!
            Me.detDscto.Name = "detDscto"
            Me.detDscto.OutputFormat = resources.GetString("detDscto.OutputFormat")
            Me.detDscto.Style = "text-align: right; font-size: 8pt"
            Me.detDscto.Text = "Dscto"
            Me.detDscto.Top = 0!
            Me.detDscto.Width = 0.3125!
            '
            'detCDscto
            '
            Me.detCDscto.DataField = "CantidadDescuento"
            Me.detCDscto.Height = 0.1375!
            Me.detCDscto.Left = 5.9375!
            Me.detCDscto.Name = "detCDscto"
            Me.detCDscto.OutputFormat = resources.GetString("detCDscto.OutputFormat")
            Me.detCDscto.Style = "text-align: right; font-size: 8pt"
            Me.detCDscto.Text = "CDscto"
            Me.detCDscto.Top = 0!
            Me.detCDscto.Width = 0.5625!
            '
            'detCostoSNC
            '
            Me.detCostoSNC.DataField = "CostoSNC"
            Me.detCostoSNC.Height = 0.1375!
            Me.detCostoSNC.Left = 6.5625!
            Me.detCostoSNC.Name = "detCostoSNC"
            Me.detCostoSNC.OutputFormat = resources.GetString("detCostoSNC.OutputFormat")
            Me.detCostoSNC.Style = "text-align: right; font-size: 8pt"
            Me.detCostoSNC.Text = "CostoSNC"
            Me.detCostoSNC.Top = 0!
            Me.detCostoSNC.Width = 0.5625!
            '
            'detCostoCNC
            '
            Me.detCostoCNC.DataField = "CostoCNC"
            Me.detCostoCNC.Height = 0.1375!
            Me.detCostoCNC.Left = 7.1875!
            Me.detCostoCNC.Name = "detCostoCNC"
            Me.detCostoCNC.OutputFormat = resources.GetString("detCostoCNC.OutputFormat")
            Me.detCostoCNC.Style = "text-align: right; font-size: 8pt"
            Me.detCostoCNC.Text = "CostoCNC"
            Me.detCostoCNC.Top = 0!
            Me.detCostoCNC.Width = 0.5625!
            '
            'lblPc
            '
            Me.lblPc.Height = 0.1375!
            Me.lblPc.HyperLink = Nothing
            Me.lblPc.Left = 5.75!
            Me.lblPc.Name = "lblPc"
            Me.lblPc.Style = "font-size: 8pt"
            Me.lblPc.Text = "%"
            Me.lblPc.Top = 0!
            Me.lblPc.Width = 0.125!
            '
            'Shape2
            '
            Me.Shape2.Height = 0.3125!
            Me.Shape2.Left = 0!
            Me.Shape2.Name = "Shape2"
            Me.Shape2.RoundingRadius = 9.999999!
            Me.Shape2.Top = 0!
            Me.Shape2.Width = 7.75!
            '
            'Label18
            '
            Me.Label18.Height = 0.2!
            Me.Label18.HyperLink = Nothing
            Me.Label18.Left = 0.0625!
            Me.Label18.Name = "Label18"
            Me.Label18.Style = "text-align: justify; font-size: 9pt"
            Me.Label18.Text = "TOTALES :"
            Me.Label18.Top = 0.0625!
            Me.Label18.Width = 0.75!
            '
            'totCantidad
            '
            Me.totCantidad.DataField = "Cantidad"
            Me.totCantidad.Height = 0.2!
            Me.totCantidad.Left = 3.25!
            Me.totCantidad.Name = "totCantidad"
            Me.totCantidad.Style = "text-align: right; font-size: 8.25pt"
            Me.totCantidad.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
            Me.totCantidad.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
            Me.totCantidad.Top = 0.0625!
            Me.totCantidad.Width = 0.4375!
            '
            'totTotal
            '
            Me.totTotal.DataField = "Total"
            Me.totTotal.Height = 0.2!
            Me.totTotal.Left = 4.5625!
            Me.totTotal.Name = "totTotal"
            Me.totTotal.OutputFormat = resources.GetString("totTotal.OutputFormat")
            Me.totTotal.Style = "text-align: right; font-size: 8.25pt"
            Me.totTotal.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
            Me.totTotal.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
            Me.totTotal.Top = 0.0625!
            Me.totTotal.Width = 0.8125!
            '
            'totDscto
            '
            Me.totDscto.DataField = "CantidadDescuento"
            Me.totDscto.Height = 0.2!
            Me.totDscto.Left = 5.75!
            Me.totDscto.Name = "totDscto"
            Me.totDscto.OutputFormat = resources.GetString("totDscto.OutputFormat")
            Me.totDscto.Style = "text-align: right; font-size: 8.25pt"
            Me.totDscto.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
            Me.totDscto.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
            Me.totDscto.Top = 0.0625!
            Me.totDscto.Width = 0.6875!
            '
            'totCostoSNC
            '
            Me.totCostoSNC.DataField = "CostoSNC"
            Me.totCostoSNC.Height = 0.2!
            Me.totCostoSNC.Left = 6.5625!
            Me.totCostoSNC.Name = "totCostoSNC"
            Me.totCostoSNC.OutputFormat = resources.GetString("totCostoSNC.OutputFormat")
            Me.totCostoSNC.Style = "text-align: right; font-size: 8.25pt"
            Me.totCostoSNC.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
            Me.totCostoSNC.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
            Me.totCostoSNC.Top = 0.0625!
            Me.totCostoSNC.Width = 0.5625!
            '
            'ActiveReport1
            '
            Me.MasterReport = false
            Me.PageSettings.PaperHeight = 11!
            Me.PageSettings.PaperWidth = 8.5!
            Me.PrintWidth = 7.770833!
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
            CType(Me.lblRango,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblSucursal,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblFecha,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblCaja,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label6,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox1,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label7,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label8,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label9,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label10,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label11,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label12,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label13,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label14,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label15,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label16,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label17,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.detFolio,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.detCodigo,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.detDescrip,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.detCantidad,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.detTalla,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.detImporte,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.detTotal,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.detDscto,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.detCDscto,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.detCostoSNC,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.detCostoCNC,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblPc,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label18,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.totCantidad,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.totTotal,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.totDscto,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.totCostoSNC,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        
	End Sub

#End Region

End Class
