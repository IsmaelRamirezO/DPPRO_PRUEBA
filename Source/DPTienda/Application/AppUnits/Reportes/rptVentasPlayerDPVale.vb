Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Imports DportenisPro.DPTienda.ApplicationUnits.AnalisDeVentas
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU

Public Class rptVentasPlayerDPVale

    Inherits DataDynamics.ActiveReports.ActiveReport

    Public Sub New(ByVal TipoVenta As String, ByVal FechaDe As Date, ByVal FechaHasta As Date, ByVal OrdenarPor As String)
        MyBase.New()
        InitializeComponent()

        txtFechaDe.Text = Format(FechaDe, "dd-MM-yyy")
        txtFechaA.Text = Format(FechaHasta, "dd-MM-yyy")
        txtFechaReporte.Text = Format(Now.Date, "dd-MM-yyy")

        Dim oCatalogoAlmacenMgr As New CatalogoAlmacenesManager(oAppContext)
        Dim oAlmacen As Almacen, oSAPMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig), strCentro As String = ""

        strCentro = oSAPMgr.Read_Centros

        oAlmacen = oCatalogoAlmacenMgr.Load(strCentro)

        If Not oAlmacen Is Nothing Then
            txtSucursal.Text = oAlmacen.ID & Space(1) & oAlmacen.Descripcion
        Else
            txtSucursal.Text = strCentro
        End If

        Dim oAnalisisVentasMgr As New AnalisisDeVentasMgr(oAppContext)

        Me.DataSource = oAnalisisVentasMgr.GenerarAnalisisVentasPlayers(TipoVenta, FechaDe, FechaHasta, OrdenarPor)
        'Dim APV As Double
        'Dim PzasGlobal, FactGlobal As String
        'PzasGlobal = Me.txtPzasGlobal.Text
        'FactGlobal = Me.txtFactGlobal.Text
        'APV = PzasGlobal / FactGlobal
        Me.txtAPV.Value = Me.txtPzasGlobal.Value / Me.txtFactGlobal.Value

    End Sub

#Region "ActiveReports Designer generated code"
    Private WithEvents ReportHeader As ReportHeader = Nothing
    Private WithEvents GroupHeader1 As GroupHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents GroupFooter1 As GroupFooter = Nothing
    Private WithEvents ReportFooter As ReportFooter = Nothing
	Private Shape1 As Shape = Nothing
	Private Label1 As Label = Nothing
	Private Label2 As Label = Nothing
	Private Label3 As Label = Nothing
	Private txtFechaReporte As TextBox = Nothing
	Private txtFechaDe As TextBox = Nothing
	Private txtFechaA As TextBox = Nothing
	Private Label4 As Label = Nothing
	Private txtSucursal As TextBox = Nothing
	Private Label13 As Label = Nothing
	Private Label5 As Label = Nothing
	Private Label6 As Label = Nothing
	Private Label12 As Label = Nothing
	Private Label7 As Label = Nothing
	Private Label8 As Label = Nothing
	Private Label11 As Label = Nothing
	Private Label9 As Label = Nothing
	Private Label10 As Label = Nothing
	Private Label15 As Label = Nothing
	Private Line6 As Line = Nothing
	Private txtCodigo As TextBox = Nothing
	Private txtNombre As TextBox = Nothing
	Private txtPzasF As TextBox = Nothing
	Private txtINeto As TextBox = Nothing
	Private txtPInd As TextBox = Nothing
	Private txtPzasNC As TextBox = Nothing
	Private txtINC As TextBox = Nothing
	Private txtITotal As TextBox = Nothing
	Private TextBox2 As TextBox = Nothing
	Private Line7 As Line = Nothing
	Private Line8 As Line = Nothing
	Private Shape4 As Shape = Nothing
	Private txtPzasGlobal As TextBox = Nothing
	Private txtSumINeto As TextBox = Nothing
	Private txtSumPzasNC As TextBox = Nothing
	Private txtSumINC As TextBox = Nothing
	Private txtSumITotal As TextBox = Nothing
	Private txtFactGlobal As TextBox = Nothing
	Private lblAPV As Label = Nothing
	Private txtAPV As TextBox = Nothing
	Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptVentasPlayerDPVale))
            Me.Detail = New DataDynamics.ActiveReports.Detail()
            Me.ReportHeader = New DataDynamics.ActiveReports.ReportHeader()
            Me.ReportFooter = New DataDynamics.ActiveReports.ReportFooter()
            Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader()
            Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter()
            Me.Shape1 = New DataDynamics.ActiveReports.Shape()
            Me.Label1 = New DataDynamics.ActiveReports.Label()
            Me.Label2 = New DataDynamics.ActiveReports.Label()
            Me.Label3 = New DataDynamics.ActiveReports.Label()
            Me.txtFechaReporte = New DataDynamics.ActiveReports.TextBox()
            Me.txtFechaDe = New DataDynamics.ActiveReports.TextBox()
            Me.txtFechaA = New DataDynamics.ActiveReports.TextBox()
            Me.Label4 = New DataDynamics.ActiveReports.Label()
            Me.txtSucursal = New DataDynamics.ActiveReports.TextBox()
            Me.Label13 = New DataDynamics.ActiveReports.Label()
            Me.Label5 = New DataDynamics.ActiveReports.Label()
            Me.Label6 = New DataDynamics.ActiveReports.Label()
            Me.Label12 = New DataDynamics.ActiveReports.Label()
            Me.Label7 = New DataDynamics.ActiveReports.Label()
            Me.Label8 = New DataDynamics.ActiveReports.Label()
            Me.Label11 = New DataDynamics.ActiveReports.Label()
            Me.Label9 = New DataDynamics.ActiveReports.Label()
            Me.Label10 = New DataDynamics.ActiveReports.Label()
            Me.Label15 = New DataDynamics.ActiveReports.Label()
            Me.Line6 = New DataDynamics.ActiveReports.Line()
            Me.txtCodigo = New DataDynamics.ActiveReports.TextBox()
            Me.txtNombre = New DataDynamics.ActiveReports.TextBox()
            Me.txtPzasF = New DataDynamics.ActiveReports.TextBox()
            Me.txtINeto = New DataDynamics.ActiveReports.TextBox()
            Me.txtPInd = New DataDynamics.ActiveReports.TextBox()
            Me.txtPzasNC = New DataDynamics.ActiveReports.TextBox()
            Me.txtINC = New DataDynamics.ActiveReports.TextBox()
            Me.txtITotal = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox2 = New DataDynamics.ActiveReports.TextBox()
            Me.Line7 = New DataDynamics.ActiveReports.Line()
            Me.Line8 = New DataDynamics.ActiveReports.Line()
            Me.Shape4 = New DataDynamics.ActiveReports.Shape()
            Me.txtPzasGlobal = New DataDynamics.ActiveReports.TextBox()
            Me.txtSumINeto = New DataDynamics.ActiveReports.TextBox()
            Me.txtSumPzasNC = New DataDynamics.ActiveReports.TextBox()
            Me.txtSumINC = New DataDynamics.ActiveReports.TextBox()
            Me.txtSumITotal = New DataDynamics.ActiveReports.TextBox()
            Me.txtFactGlobal = New DataDynamics.ActiveReports.TextBox()
            Me.lblAPV = New DataDynamics.ActiveReports.Label()
            Me.txtAPV = New DataDynamics.ActiveReports.TextBox()
            CType(Me.Label1,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label3,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFechaReporte,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFechaDe,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFechaA,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtSucursal,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label13,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label5,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label6,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label12,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label7,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label8,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label11,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label9,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label10,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label15,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtCodigo,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtNombre,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtPzasF,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtINeto,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtPInd,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtPzasNC,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtINC,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtITotal,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox2,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtPzasGlobal,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtSumINeto,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtSumPzasNC,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtSumINC,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtSumITotal,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFactGlobal,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblAPV,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtAPV,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
            '
            'Detail
            '
            Me.Detail.ColumnSpacing = 0!
            Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtCodigo, Me.txtNombre, Me.txtPzasF, Me.txtINeto, Me.txtPInd, Me.txtPzasNC, Me.txtINC, Me.txtITotal, Me.TextBox2, Me.Line7, Me.Line8})
            Me.Detail.Height = 0.1875!
            Me.Detail.Name = "Detail"
            '
            'ReportHeader
            '
            Me.ReportHeader.Height = 0!
            Me.ReportHeader.Name = "ReportHeader"
            '
            'ReportFooter
            '
            Me.ReportFooter.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape4, Me.txtPzasGlobal, Me.txtSumINeto, Me.txtSumPzasNC, Me.txtSumINC, Me.txtSumITotal, Me.txtFactGlobal, Me.lblAPV, Me.txtAPV})
            Me.ReportFooter.Height = 0.3333333!
            Me.ReportFooter.Name = "ReportFooter"
            '
            'GroupHeader1
            '
            Me.GroupHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape1, Me.Label1, Me.Label2, Me.Label3, Me.txtFechaReporte, Me.txtFechaDe, Me.txtFechaA, Me.Label4, Me.txtSucursal, Me.Label13, Me.Label5, Me.Label6, Me.Label12, Me.Label7, Me.Label8, Me.Label11, Me.Label9, Me.Label10, Me.Label15, Me.Line6})
            Me.GroupHeader1.Height = 1!
            Me.GroupHeader1.Name = "GroupHeader1"
            '
            'GroupFooter1
            '
            Me.GroupFooter1.Height = 0!
            Me.GroupFooter1.Name = "GroupFooter1"
            '
            'Shape1
            '
            Me.Shape1.Height = 1!
            Me.Shape1.Left = 0!
            Me.Shape1.LineWeight = 2!
            Me.Shape1.Name = "Shape1"
            Me.Shape1.RoundingRadius = 9.999999!
            Me.Shape1.Top = 0!
            Me.Shape1.Width = 6.9375!
            '
            'Label1
            '
            Me.Label1.Height = 0.2!
            Me.Label1.HyperLink = Nothing
            Me.Label1.Left = 2.432292!
            Me.Label1.Name = "Label1"
            Me.Label1.Style = "ddo-char-set: 1; text-align: center; font-weight: bold; font-size: 8pt"
            Me.Label1.Text = "ANALISIS DE VENTAS POR PLAYERS"
            Me.Label1.Top = 0.0625!
            Me.Label1.Width = 2.25!
            '
            'Label2
            '
            Me.Label2.Height = 0.2!
            Me.Label2.HyperLink = Nothing
            Me.Label2.Left = 2.1875!
            Me.Label2.Name = "Label2"
            Me.Label2.Style = "ddo-char-set: 1; font-weight: bold; font-size: 8pt"
            Me.Label2.Text = "De:"
            Me.Label2.Top = 0.25!
            Me.Label2.Width = 0.25!
            '
            'Label3
            '
            Me.Label3.Height = 0.2!
            Me.Label3.HyperLink = Nothing
            Me.Label3.Left = 3.625!
            Me.Label3.Name = "Label3"
            Me.Label3.Style = "ddo-char-set: 1; font-weight: bold; font-size: 8pt"
            Me.Label3.Text = "A:"
            Me.Label3.Top = 0.25!
            Me.Label3.Width = 0.2101376!
            '
            'txtFechaReporte
            '
            Me.txtFechaReporte.Height = 0.2!
            Me.txtFechaReporte.Left = 0.5!
            Me.txtFechaReporte.Name = "txtFechaReporte"
            Me.txtFechaReporte.OutputFormat = resources.GetString("txtFechaReporte.OutputFormat")
            Me.txtFechaReporte.Style = "ddo-char-set: 1; font-size: 8pt"
            Me.txtFechaReporte.Text = "TextBox1"
            Me.txtFechaReporte.Top = 0.0625!
            Me.txtFechaReporte.Width = 1.125!
            '
            'txtFechaDe
            '
            Me.txtFechaDe.Height = 0.2!
            Me.txtFechaDe.Left = 2.5!
            Me.txtFechaDe.Name = "txtFechaDe"
            Me.txtFechaDe.OutputFormat = resources.GetString("txtFechaDe.OutputFormat")
            Me.txtFechaDe.Style = "ddo-char-set: 1; font-size: 8pt"
            Me.txtFechaDe.Text = "TextBox1"
            Me.txtFechaDe.Top = 0.25!
            Me.txtFechaDe.Width = 1!
            '
            'txtFechaA
            '
            Me.txtFechaA.Height = 0.2!
            Me.txtFechaA.Left = 3.9375!
            Me.txtFechaA.Name = "txtFechaA"
            Me.txtFechaA.OutputFormat = resources.GetString("txtFechaA.OutputFormat")
            Me.txtFechaA.Style = "ddo-char-set: 1; font-size: 8pt"
            Me.txtFechaA.Text = "TextBox2"
            Me.txtFechaA.Top = 0.25!
            Me.txtFechaA.Width = 1!
            '
            'Label4
            '
            Me.Label4.Height = 0.2!
            Me.Label4.HyperLink = Nothing
            Me.Label4.Left = 1.9375!
            Me.Label4.Name = "Label4"
            Me.Label4.Style = "ddo-char-set: 1; font-weight: bold; font-size: 8pt"
            Me.Label4.Text = "Sucursal:"
            Me.Label4.Top = 0.4375!
            Me.Label4.Width = 0.6491144!
            '
            'txtSucursal
            '
            Me.txtSucursal.Height = 0.2!
            Me.txtSucursal.Left = 2.625!
            Me.txtSucursal.Name = "txtSucursal"
            Me.txtSucursal.Style = "ddo-char-set: 1; font-size: 8pt"
            Me.txtSucursal.Text = "TextBox1"
            Me.txtSucursal.Top = 0.4375!
            Me.txtSucursal.Width = 2.5625!
            '
            'Label13
            '
            Me.Label13.Height = 0.2!
            Me.Label13.HyperLink = Nothing
            Me.Label13.Left = 0.0625!
            Me.Label13.Name = "Label13"
            Me.Label13.Style = "ddo-char-set: 1; font-weight: bold; font-size: 8pt"
            Me.Label13.Text = "Fecha:"
            Me.Label13.Top = 0.0625!
            Me.Label13.Width = 0.4375!
            '
            'Label5
            '
            Me.Label5.Height = 0.2!
            Me.Label5.HyperLink = Nothing
            Me.Label5.Left = 0.0625!
            Me.Label5.Name = "Label5"
            Me.Label5.Style = "ddo-char-set: 1; text-align: center; font-size: 8pt"
            Me.Label5.Text = "CODIGO"
            Me.Label5.Top = 0.6875!
            Me.Label5.Width = 0.6067914!
            '
            'Label6
            '
            Me.Label6.Height = 0.2!
            Me.Label6.HyperLink = Nothing
            Me.Label6.Left = 0.6875!
            Me.Label6.Name = "Label6"
            Me.Label6.Style = "ddo-char-set: 1; text-align: center; font-size: 8pt"
            Me.Label6.Text = "NOMBRE"
            Me.Label6.Top = 0.6875!
            Me.Label6.Width = 1.6875!
            '
            'Label12
            '
            Me.Label12.Height = 0.2!
            Me.Label12.HyperLink = Nothing
            Me.Label12.Left = 2.4375!
            Me.Label12.Name = "Label12"
            Me.Label12.Style = "ddo-char-set: 1; text-align: center; font-size: 8pt"
            Me.Label12.Text = "PZAS."
            Me.Label12.Top = 0.6875!
            Me.Label12.Width = 0.3971457!
            '
            'Label7
            '
            Me.Label7.Height = 0.3125!
            Me.Label7.HyperLink = Nothing
            Me.Label7.Left = 2.875!
            Me.Label7.Name = "Label7"
            Me.Label7.Style = "ddo-char-set: 1; text-align: center; font-size: 8pt"
            Me.Label7.Text = "IMPORTE NETO"
            Me.Label7.Top = 0.6875!
            Me.Label7.Width = 0.75!
            '
            'Label8
            '
            Me.Label8.Height = 0.2!
            Me.Label8.HyperLink = Nothing
            Me.Label8.Left = 3.6875!
            Me.Label8.Name = "Label8"
            Me.Label8.Style = "ddo-char-set: 1; text-align: center; font-size: 8pt"
            Me.Label8.Text = "% IND."
            Me.Label8.Top = 0.6875!
            Me.Label8.Width = 0.4375!
            '
            'Label11
            '
            Me.Label11.Height = 0.3125!
            Me.Label11.HyperLink = Nothing
            Me.Label11.Left = 4.1875!
            Me.Label11.Name = "Label11"
            Me.Label11.Style = "ddo-char-set: 1; text-align: center; font-size: 8pt"
            Me.Label11.Text = "PZAS. N.C."
            Me.Label11.Top = 0.6875!
            Me.Label11.Width = 0.375!
            '
            'Label9
            '
            Me.Label9.Height = 0.3125!
            Me.Label9.HyperLink = Nothing
            Me.Label9.Left = 4.625!
            Me.Label9.Name = "Label9"
            Me.Label9.Style = "ddo-char-set: 1; text-align: center; font-size: 8pt"
            Me.Label9.Text = "IMPORTE NC"
            Me.Label9.Top = 0.6875!
            Me.Label9.Width = 0.625!
            '
            'Label10
            '
            Me.Label10.Height = 0.3125!
            Me.Label10.HyperLink = Nothing
            Me.Label10.Left = 5.3125!
            Me.Label10.Name = "Label10"
            Me.Label10.Style = "ddo-char-set: 1; text-align: center; font-size: 8pt"
            Me.Label10.Text = "IMPORTE TOTAL"
            Me.Label10.Top = 0.6875!
            Me.Label10.Width = 0.875!
            '
            'Label15
            '
            Me.Label15.Height = 0.3125!
            Me.Label15.HyperLink = Nothing
            Me.Label15.Left = 6.25!
            Me.Label15.Name = "Label15"
            Me.Label15.Style = "text-align: center; font-size: 8.25pt"
            Me.Label15.Text = "NUM. FACTURAS"
            Me.Label15.Top = 0.6875!
            Me.Label15.Width = 0.6875!
            '
            'Line6
            '
            Me.Line6.Height = 0!
            Me.Line6.Left = 0!
            Me.Line6.LineWeight = 1!
            Me.Line6.Name = "Line6"
            Me.Line6.Top = 0.6875!
            Me.Line6.Width = 6.9375!
            Me.Line6.X1 = 0!
            Me.Line6.X2 = 6.9375!
            Me.Line6.Y1 = 0.6875!
            Me.Line6.Y2 = 0.6875!
            '
            'txtCodigo
            '
            Me.txtCodigo.DataField = "CodVendedor"
            Me.txtCodigo.Height = 0.1875!
            Me.txtCodigo.Left = 0.0625!
            Me.txtCodigo.Name = "txtCodigo"
            Me.txtCodigo.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt"
            Me.txtCodigo.Top = 0!
            Me.txtCodigo.Width = 0.6067914!
            '
            'txtNombre
            '
            Me.txtNombre.DataField = "Nombre"
            Me.txtNombre.Height = 0.1875!
            Me.txtNombre.Left = 0.6875!
            Me.txtNombre.Name = "txtNombre"
            Me.txtNombre.Style = "ddo-char-set: 1; font-size: 8pt"
            Me.txtNombre.Top = 0!
            Me.txtNombre.Width = 1.6875!
            '
            'txtPzasF
            '
            Me.txtPzasF.DataField = "PzasTotales"
            Me.txtPzasF.Height = 0.1875!
            Me.txtPzasF.Left = 2.4375!
            Me.txtPzasF.Name = "txtPzasF"
            Me.txtPzasF.OutputFormat = resources.GetString("txtPzasF.OutputFormat")
            Me.txtPzasF.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt"
            Me.txtPzasF.Top = 0!
            Me.txtPzasF.Width = 0.4128938!
            '
            'txtINeto
            '
            Me.txtINeto.DataField = "ImporteNeto"
            Me.txtINeto.Height = 0.1875!
            Me.txtINeto.Left = 2.875!
            Me.txtINeto.Name = "txtINeto"
            Me.txtINeto.OutputFormat = resources.GetString("txtINeto.OutputFormat")
            Me.txtINeto.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt"
            Me.txtINeto.Top = 0!
            Me.txtINeto.Width = 0.75!
            '
            'txtPInd
            '
            Me.txtPInd.DataField = "Porc"
            Me.txtPInd.Height = 0.1875!
            Me.txtPInd.Left = 3.6875!
            Me.txtPInd.Name = "txtPInd"
            Me.txtPInd.OutputFormat = resources.GetString("txtPInd.OutputFormat")
            Me.txtPInd.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt"
            Me.txtPInd.Top = 0!
            Me.txtPInd.Width = 0.4375!
            '
            'txtPzasNC
            '
            Me.txtPzasNC.DataField = "PzasNC"
            Me.txtPzasNC.Height = 0.1875!
            Me.txtPzasNC.Left = 4.1875!
            Me.txtPzasNC.Name = "txtPzasNC"
            Me.txtPzasNC.OutputFormat = resources.GetString("txtPzasNC.OutputFormat")
            Me.txtPzasNC.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt"
            Me.txtPzasNC.Top = 0!
            Me.txtPzasNC.Width = 0.375!
            '
            'txtINC
            '
            Me.txtINC.DataField = "ImporteNC"
            Me.txtINC.Height = 0.1875!
            Me.txtINC.Left = 4.625!
            Me.txtINC.Name = "txtINC"
            Me.txtINC.OutputFormat = resources.GetString("txtINC.OutputFormat")
            Me.txtINC.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt"
            Me.txtINC.Top = 0!
            Me.txtINC.Width = 0.625!
            '
            'txtITotal
            '
            Me.txtITotal.DataField = "ImporteTotal"
            Me.txtITotal.Height = 0.1875!
            Me.txtITotal.Left = 5.3125!
            Me.txtITotal.Name = "txtITotal"
            Me.txtITotal.OutputFormat = resources.GetString("txtITotal.OutputFormat")
            Me.txtITotal.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt"
            Me.txtITotal.Top = 0!
            Me.txtITotal.Width = 0.875!
            '
            'TextBox2
            '
            Me.TextBox2.DataField = "NumFact"
            Me.TextBox2.Height = 0.1875!
            Me.TextBox2.Left = 6.25!
            Me.TextBox2.Name = "TextBox2"
            Me.TextBox2.OutputFormat = resources.GetString("TextBox2.OutputFormat")
            Me.TextBox2.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt"
            Me.TextBox2.Top = 0!
            Me.TextBox2.Width = 0.625!
            '
            'Line7
            '
            Me.Line7.Height = 0.3!
            Me.Line7.Left = 0.01!
            Me.Line7.LineWeight = 1!
            Me.Line7.Name = "Line7"
            Me.Line7.Top = 0!
            Me.Line7.Width = 0!
            Me.Line7.X1 = 0.01!
            Me.Line7.X2 = 0.01!
            Me.Line7.Y1 = 0!
            Me.Line7.Y2 = 0.3!
            '
            'Line8
            '
            Me.Line8.Height = 0.3!
            Me.Line8.Left = 6.93!
            Me.Line8.LineWeight = 1!
            Me.Line8.Name = "Line8"
            Me.Line8.Top = 0!
            Me.Line8.Width = 0!
            Me.Line8.X1 = 6.93!
            Me.Line8.X2 = 6.93!
            Me.Line8.Y1 = 0!
            Me.Line8.Y2 = 0.3!
            '
            'Shape4
            '
            Me.Shape4.Height = 0.3125!
            Me.Shape4.Left = 0!
            Me.Shape4.LineWeight = 2!
            Me.Shape4.Name = "Shape4"
            Me.Shape4.RoundingRadius = 9.999999!
            Me.Shape4.Top = 0!
            Me.Shape4.Width = 6.9375!
            '
            'txtPzasGlobal
            '
            Me.txtPzasGlobal.DataField = "PzasTotales"
            Me.txtPzasGlobal.Height = 0.2!
            Me.txtPzasGlobal.Left = 2.4375!
            Me.txtPzasGlobal.Name = "txtPzasGlobal"
            Me.txtPzasGlobal.OutputFormat = resources.GetString("txtPzasGlobal.OutputFormat")
            Me.txtPzasGlobal.Style = "text-align: right; font-size: 8.25pt"
            Me.txtPzasGlobal.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
            Me.txtPzasGlobal.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
            Me.txtPzasGlobal.Top = 0.0625!
            Me.txtPzasGlobal.Width = 0.4128936!
            '
            'txtSumINeto
            '
            Me.txtSumINeto.DataField = "ImporteNeto"
            Me.txtSumINeto.Height = 0.2!
            Me.txtSumINeto.Left = 2.875!
            Me.txtSumINeto.Name = "txtSumINeto"
            Me.txtSumINeto.OutputFormat = resources.GetString("txtSumINeto.OutputFormat")
            Me.txtSumINeto.Style = "text-align: right; font-size: 8.25pt"
            Me.txtSumINeto.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
            Me.txtSumINeto.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
            Me.txtSumINeto.Top = 0.0625!
            Me.txtSumINeto.Width = 0.7470472!
            '
            'txtSumPzasNC
            '
            Me.txtSumPzasNC.DataField = "PzasNC"
            Me.txtSumPzasNC.Height = 0.2!
            Me.txtSumPzasNC.Left = 4.1875!
            Me.txtSumPzasNC.Name = "txtSumPzasNC"
            Me.txtSumPzasNC.OutputFormat = resources.GetString("txtSumPzasNC.OutputFormat")
            Me.txtSumPzasNC.Style = "text-align: right; font-size: 8.25pt"
            Me.txtSumPzasNC.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
            Me.txtSumPzasNC.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
            Me.txtSumPzasNC.Top = 0.0625!
            Me.txtSumPzasNC.Width = 0.375!
            '
            'txtSumINC
            '
            Me.txtSumINC.DataField = "ImporteNC"
            Me.txtSumINC.Height = 0.2!
            Me.txtSumINC.Left = 4.625!
            Me.txtSumINC.Name = "txtSumINC"
            Me.txtSumINC.OutputFormat = resources.GetString("txtSumINC.OutputFormat")
            Me.txtSumINC.Style = "text-align: right; font-size: 8.25pt"
            Me.txtSumINC.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
            Me.txtSumINC.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
            Me.txtSumINC.Top = 0.0625!
            Me.txtSumINC.Width = 0.625!
            '
            'txtSumITotal
            '
            Me.txtSumITotal.DataField = "ImporteTotal"
            Me.txtSumITotal.Height = 0.2!
            Me.txtSumITotal.Left = 5.3125!
            Me.txtSumITotal.Name = "txtSumITotal"
            Me.txtSumITotal.OutputFormat = resources.GetString("txtSumITotal.OutputFormat")
            Me.txtSumITotal.Style = "text-align: right; font-size: 8.25pt"
            Me.txtSumITotal.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
            Me.txtSumITotal.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
            Me.txtSumITotal.Top = 0.0625!
            Me.txtSumITotal.Width = 0.9079729!
            '
            'txtFactGlobal
            '
            Me.txtFactGlobal.DataField = "NumFact"
            Me.txtFactGlobal.Height = 0.1875!
            Me.txtFactGlobal.Left = 6.25!
            Me.txtFactGlobal.Name = "txtFactGlobal"
            Me.txtFactGlobal.OutputFormat = resources.GetString("txtFactGlobal.OutputFormat")
            Me.txtFactGlobal.Style = "text-align: right; font-size: 8.25pt"
            Me.txtFactGlobal.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
            Me.txtFactGlobal.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
            Me.txtFactGlobal.Top = 0.0625!
            Me.txtFactGlobal.Width = 0.625!
            '
            'lblAPV
            '
            Me.lblAPV.Height = 0.1875!
            Me.lblAPV.HyperLink = Nothing
            Me.lblAPV.Left = 0.125!
            Me.lblAPV.Name = "lblAPV"
            Me.lblAPV.Style = "ddo-char-set: 1; font-size: 8pt"
            Me.lblAPV.Text = "APV del dia:"
            Me.lblAPV.Top = 0.0625!
            Me.lblAPV.Visible = false
            Me.lblAPV.Width = 0.6875!
            '
            'txtAPV
            '
            Me.txtAPV.Height = 0.1875!
            Me.txtAPV.Left = 0.875!
            Me.txtAPV.Name = "txtAPV"
            Me.txtAPV.OutputFormat = resources.GetString("txtAPV.OutputFormat")
            Me.txtAPV.Style = "text-align: right; font-size: 8.25pt"
            Me.txtAPV.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.DStdDevP
            Me.txtAPV.Top = 0.0625!
            Me.txtAPV.Visible = false
            Me.txtAPV.Width = 0.6875!
            '
            'ActiveReport1
            '
            Me.MasterReport = false
            Me.PageSettings.DefaultPaperSize = false
            Me.PageSettings.Margins.Left = 0.4902778!
            Me.PageSettings.Margins.Right = 0.4902778!
            Me.PageSettings.Margins.Top = 0.5!
            Me.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Portrait
            Me.PageSettings.PaperHeight = 11.69306!
            Me.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4
            Me.PageSettings.PaperWidth = 8.268056!
            Me.PrintWidth = 6.979167!
            Me.Sections.Add(Me.ReportHeader)
            Me.Sections.Add(Me.GroupHeader1)
            Me.Sections.Add(Me.Detail)
            Me.Sections.Add(Me.GroupFooter1)
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
            CType(Me.Label3,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFechaReporte,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFechaDe,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFechaA,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtSucursal,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label13,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label5,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label6,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label12,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label7,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label8,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label11,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label9,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label10,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label15,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtCodigo,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtNombre,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtPzasF,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtINeto,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtPInd,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtPzasNC,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtINC,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtITotal,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox2,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtPzasGlobal,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtSumINeto,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtSumPzasNC,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtSumINC,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtSumITotal,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFactGlobal,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblAPV,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtAPV,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        
	End Sub

#End Region


    Private Sub GroupHeader1_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupHeader1.Format

    End Sub

    Private Sub ReportHeader_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportHeader.Format

    End Sub
End Class
