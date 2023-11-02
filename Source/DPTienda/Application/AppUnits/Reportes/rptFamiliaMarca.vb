Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Imports DportenisPro.DPTienda.ApplicationUnits.AnalisDeVentas
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoFamilias
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoMarcas
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU

Public Class rptFamiliaMarca
    Inherits DataDynamics.ActiveReports.ActiveReport

    Public Sub New(ByVal TipoVenta As String, ByVal Familia As String, ByVal FechaDe As DateTime, ByVal FechaHasta As DateTime, ByVal OrdenarPor As String)
        MyBase.New()
        InitializeComponent()

        Dim oFamiliasMgr As New CatalogoFamiliasManager(oAppContext)
        Dim oFamilias As Familias
        oFamilias = oFamiliasMgr.Load(Familia)

        LblNombRep.Text = "REPORTE DE ANALIS DE VENTAS FAMILIA/MARCA: " & oFamilias.Descripcion

        txtFechaDe.Text = Format(FechaDe, "dd-MM-yyy")
        txtFechaA.Text = Format(FechaHasta, "dd-MM-yyy")
        txtFechaReporte.Text = Format(Now.Date, "dd-MM-yyy")

        Dim oCatalogoAlmacenMgr As New CatalogoAlmacenesManager(oAppContext)
        Dim oAlmacen As Almacen, oSAPMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig), strCentro As String = ""

        strCentro = oSAPMgr.Read_Centros
        oAlmacen = oCatalogoAlmacenMgr.Load(strCentro)

        oSAPMgr = Nothing

        txtSucursal.Text = oAlmacen.ID & Space(1) & oAlmacen.Descripcion

        Dim oAnalisisVentasMgr As New AnalisisDeVentasMgr(oAppContext)

        Me.DataSource = oAnalisisVentasMgr.GenerarAnalisisVentasFamiliaMarca(Familia, TipoVenta, FechaDe, FechaHasta, OrdenarPor)
        Me.Run()

    End Sub

#Region "ActiveReports Designer generated code"
    Private WithEvents ReportHeader As ReportHeader = Nothing
    Private WithEvents PageHeader As PageHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents PageFooter As PageFooter = Nothing
    Private WithEvents ReportFooter As ReportFooter = Nothing
    Private Shape1 As Shape = Nothing
    Private LblNombRep As Label = Nothing
    Private Label2 As Label = Nothing
    Private Label3 As Label = Nothing
    Private txtFechaReporte As TextBox = Nothing
    Private txtFechaDe As TextBox = Nothing
    Private txtFechaA As TextBox = Nothing
    Private Label4 As Label = Nothing
    Private txtSucursal As TextBox = Nothing
    Private Label14 As Label = Nothing
    Private Shape6 As Shape = Nothing
    Private Label16 As Label = Nothing
    Private Label17 As Label = Nothing
    Private Label18 As Label = Nothing
    Private Label19 As Label = Nothing
    Private Label20 As Label = Nothing
    Private Label21 As Label = Nothing
    Private Label22 As Label = Nothing
    Private Label23 As Label = Nothing
    Private TextBox3 As TextBox = Nothing
    Private TextBox4 As TextBox = Nothing
    Private TextBox5 As TextBox = Nothing
    Private TextBox6 As TextBox = Nothing
    Private TextBox7 As TextBox = Nothing
    Private TextBox8 As TextBox = Nothing
    Private TextBox9 As TextBox = Nothing
    Private TextBox10 As TextBox = Nothing
    Private Line6 As Line = Nothing
    Private Line7 As Line = Nothing
    Private Shape4 As Shape = Nothing
    Private TextBox1 As TextBox = Nothing
    Private txtSumINeto As TextBox = Nothing
    Private txtSumPzasNC As TextBox = Nothing
    Private txtSumINC As TextBox = Nothing
    Private txtSumITotal As TextBox = Nothing
    Private Line3 As Line = Nothing
    Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptFamiliaMarca))
            Me.Detail = New DataDynamics.ActiveReports.Detail()
            Me.ReportHeader = New DataDynamics.ActiveReports.ReportHeader()
            Me.ReportFooter = New DataDynamics.ActiveReports.ReportFooter()
            Me.PageHeader = New DataDynamics.ActiveReports.PageHeader()
            Me.PageFooter = New DataDynamics.ActiveReports.PageFooter()
            Me.Shape1 = New DataDynamics.ActiveReports.Shape()
            Me.LblNombRep = New DataDynamics.ActiveReports.Label()
            Me.Label2 = New DataDynamics.ActiveReports.Label()
            Me.Label3 = New DataDynamics.ActiveReports.Label()
            Me.txtFechaReporte = New DataDynamics.ActiveReports.TextBox()
            Me.txtFechaDe = New DataDynamics.ActiveReports.TextBox()
            Me.txtFechaA = New DataDynamics.ActiveReports.TextBox()
            Me.Label4 = New DataDynamics.ActiveReports.Label()
            Me.txtSucursal = New DataDynamics.ActiveReports.TextBox()
            Me.Label14 = New DataDynamics.ActiveReports.Label()
            Me.Shape6 = New DataDynamics.ActiveReports.Shape()
            Me.Label16 = New DataDynamics.ActiveReports.Label()
            Me.Label17 = New DataDynamics.ActiveReports.Label()
            Me.Label18 = New DataDynamics.ActiveReports.Label()
            Me.Label19 = New DataDynamics.ActiveReports.Label()
            Me.Label20 = New DataDynamics.ActiveReports.Label()
            Me.Label21 = New DataDynamics.ActiveReports.Label()
            Me.Label22 = New DataDynamics.ActiveReports.Label()
            Me.Label23 = New DataDynamics.ActiveReports.Label()
            Me.TextBox3 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox4 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox5 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox6 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox7 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox8 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox9 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox10 = New DataDynamics.ActiveReports.TextBox()
            Me.Line6 = New DataDynamics.ActiveReports.Line()
            Me.Line7 = New DataDynamics.ActiveReports.Line()
            Me.Shape4 = New DataDynamics.ActiveReports.Shape()
            Me.TextBox1 = New DataDynamics.ActiveReports.TextBox()
            Me.txtSumINeto = New DataDynamics.ActiveReports.TextBox()
            Me.txtSumPzasNC = New DataDynamics.ActiveReports.TextBox()
            Me.txtSumINC = New DataDynamics.ActiveReports.TextBox()
            Me.txtSumITotal = New DataDynamics.ActiveReports.TextBox()
            Me.Line3 = New DataDynamics.ActiveReports.Line()
            CType(Me.LblNombRep,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label3,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFechaReporte,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFechaDe,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFechaA,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtSucursal,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label14,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label16,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label17,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label18,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label19,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label20,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label21,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label22,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label23,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox3,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox4,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox5,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox6,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox7,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox8,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox9,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox10,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox1,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtSumINeto,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtSumPzasNC,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtSumINC,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtSumITotal,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
            '
            'Detail
            '
            Me.Detail.ColumnSpacing = 0!
            Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TextBox3, Me.TextBox4, Me.TextBox5, Me.TextBox6, Me.TextBox7, Me.TextBox8, Me.TextBox9, Me.TextBox10, Me.Line6, Me.Line7})
            Me.Detail.Height = 0.25!
            Me.Detail.Name = "Detail"
            '
            'ReportHeader
            '
            Me.ReportHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape1, Me.LblNombRep, Me.Label2, Me.Label3, Me.txtFechaReporte, Me.txtFechaDe, Me.txtFechaA, Me.Label4, Me.txtSucursal, Me.Label14})
            Me.ReportHeader.Height = 0.6666667!
            Me.ReportHeader.Name = "ReportHeader"
            '
            'ReportFooter
            '
            Me.ReportFooter.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape4, Me.TextBox1, Me.txtSumINeto, Me.txtSumPzasNC, Me.txtSumINC, Me.txtSumITotal, Me.Line3})
            Me.ReportFooter.Height = 0.375!
            Me.ReportFooter.Name = "ReportFooter"
            '
            'PageHeader
            '
            Me.PageHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape6, Me.Label16, Me.Label17, Me.Label18, Me.Label19, Me.Label20, Me.Label21, Me.Label22, Me.Label23})
            Me.PageHeader.Height = 0.4270833!
            Me.PageHeader.Name = "PageHeader"
            '
            'PageFooter
            '
            Me.PageFooter.Height = 0!
            Me.PageFooter.Name = "PageFooter"
            '
            'Shape1
            '
            Me.Shape1.Height = 0.6875!
            Me.Shape1.Left = 0!
            Me.Shape1.LineWeight = 2!
            Me.Shape1.Name = "Shape1"
            Me.Shape1.RoundingRadius = 9.999999!
            Me.Shape1.Top = 0!
            Me.Shape1.Width = 7.0625!
            '
            'LblNombRep
            '
            Me.LblNombRep.Height = 0.2!
            Me.LblNombRep.HyperLink = Nothing
            Me.LblNombRep.Left = 1.75!
            Me.LblNombRep.Name = "LblNombRep"
            Me.LblNombRep.Style = "ddo-char-set: 1; text-align: center; font-weight: bold; font-size: 8pt"
            Me.LblNombRep.Text = "ANALISIS DE VENTAS POR FAMILIA/MARCAS"
            Me.LblNombRep.Top = 0.0625!
            Me.LblNombRep.Width = 3.8125!
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
            'Label14
            '
            Me.Label14.Height = 0.2!
            Me.Label14.HyperLink = Nothing
            Me.Label14.Left = 0.0625!
            Me.Label14.Name = "Label14"
            Me.Label14.Style = "ddo-char-set: 1; font-weight: bold; font-size: 8pt"
            Me.Label14.Text = "Fecha:"
            Me.Label14.Top = 0.0625!
            Me.Label14.Width = 0.4375!
            '
            'Shape6
            '
            Me.Shape6.Height = 0.4375!
            Me.Shape6.Left = 0!
            Me.Shape6.LineWeight = 2!
            Me.Shape6.Name = "Shape6"
            Me.Shape6.RoundingRadius = 9.999999!
            Me.Shape6.Top = 0!
            Me.Shape6.Width = 7.0625!
            '
            'Label16
            '
            Me.Label16.Height = 0.2!
            Me.Label16.HyperLink = Nothing
            Me.Label16.Left = 0.0625!
            Me.Label16.Name = "Label16"
            Me.Label16.Style = "ddo-char-set: 1; text-align: center; font-size: 8pt"
            Me.Label16.Text = "CODIGO"
            Me.Label16.Top = 0.0625!
            Me.Label16.Width = 0.6067914!
            '
            'Label17
            '
            Me.Label17.Height = 0.2!
            Me.Label17.HyperLink = Nothing
            Me.Label17.Left = 0.75!
            Me.Label17.Name = "Label17"
            Me.Label17.Style = "ddo-char-set: 1; text-align: center; font-size: 8pt"
            Me.Label17.Text = "DESCRIPCIÓN"
            Me.Label17.Top = 0.0625!
            Me.Label17.Width = 2.375!
            '
            'Label18
            '
            Me.Label18.Height = 0.2!
            Me.Label18.HyperLink = Nothing
            Me.Label18.Left = 3.25!
            Me.Label18.Name = "Label18"
            Me.Label18.Style = "ddo-char-set: 1; text-align: center; font-size: 8pt"
            Me.Label18.Text = "PZAS."
            Me.Label18.Top = 0.0625!
            Me.Label18.Width = 0.3971457!
            '
            'Label19
            '
            Me.Label19.Height = 0.3125!
            Me.Label19.HyperLink = Nothing
            Me.Label19.Left = 3.6875!
            Me.Label19.Name = "Label19"
            Me.Label19.Style = "ddo-char-set: 1; text-align: center; font-size: 8pt"
            Me.Label19.Text = "IMPORTE NETO"
            Me.Label19.Top = 0.0625!
            Me.Label19.Width = 0.75!
            '
            'Label20
            '
            Me.Label20.Height = 0.2!
            Me.Label20.HyperLink = Nothing
            Me.Label20.Left = 4.5!
            Me.Label20.Name = "Label20"
            Me.Label20.Style = "ddo-char-set: 1; text-align: center; font-size: 8pt"
            Me.Label20.Text = "% IND."
            Me.Label20.Top = 0.0625!
            Me.Label20.Width = 0.4375!
            '
            'Label21
            '
            Me.Label21.Height = 0.3125!
            Me.Label21.HyperLink = Nothing
            Me.Label21.Left = 5!
            Me.Label21.Name = "Label21"
            Me.Label21.Style = "ddo-char-set: 1; text-align: center; font-size: 8pt"
            Me.Label21.Text = "PZAS. N.C."
            Me.Label21.Top = 0.0625!
            Me.Label21.Width = 0.375!
            '
            'Label22
            '
            Me.Label22.Height = 0.3125!
            Me.Label22.HyperLink = Nothing
            Me.Label22.Left = 5.4375!
            Me.Label22.Name = "Label22"
            Me.Label22.Style = "ddo-char-set: 1; text-align: center; font-size: 8pt"
            Me.Label22.Text = "VALE CAJA"
            Me.Label22.Top = 0.0625!
            Me.Label22.Width = 0.625!
            '
            'Label23
            '
            Me.Label23.Height = 0.3125!
            Me.Label23.HyperLink = Nothing
            Me.Label23.Left = 6.125!
            Me.Label23.Name = "Label23"
            Me.Label23.Style = "ddo-char-set: 1; text-align: center; font-size: 8pt"
            Me.Label23.Text = "IMPORTE TOTAL"
            Me.Label23.Top = 0.0625!
            Me.Label23.Width = 0.875!
            '
            'TextBox3
            '
            Me.TextBox3.DataField = "CodMarca"
            Me.TextBox3.Height = 0.2!
            Me.TextBox3.Left = 0.0625!
            Me.TextBox3.Name = "TextBox3"
            Me.TextBox3.Style = "ddo-char-set: 1; text-align: center; font-size: 8pt"
            Me.TextBox3.Top = 0.006944444!
            Me.TextBox3.Width = 0.6067914!
            '
            'TextBox4
            '
            Me.TextBox4.DataField = "Descripcion"
            Me.TextBox4.Height = 0.2!
            Me.TextBox4.Left = 0.75!
            Me.TextBox4.Name = "TextBox4"
            Me.TextBox4.Style = "ddo-char-set: 1; font-size: 8pt"
            Me.TextBox4.Top = 0.006944444!
            Me.TextBox4.Width = 2.375!
            '
            'TextBox5
            '
            Me.TextBox5.DataField = "PzasTotales"
            Me.TextBox5.Height = 0.2!
            Me.TextBox5.Left = 3.25!
            Me.TextBox5.Name = "TextBox5"
            Me.TextBox5.OutputFormat = resources.GetString("TextBox5.OutputFormat")
            Me.TextBox5.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt"
            Me.TextBox5.Top = 0.006944444!
            Me.TextBox5.Width = 0.4128938!
            '
            'TextBox6
            '
            Me.TextBox6.DataField = "ImporteNeto"
            Me.TextBox6.Height = 0.2!
            Me.TextBox6.Left = 3.6875!
            Me.TextBox6.Name = "TextBox6"
            Me.TextBox6.OutputFormat = resources.GetString("TextBox6.OutputFormat")
            Me.TextBox6.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt"
            Me.TextBox6.Top = 0.006944444!
            Me.TextBox6.Width = 0.75!
            '
            'TextBox7
            '
            Me.TextBox7.DataField = "Porc"
            Me.TextBox7.Height = 0.2!
            Me.TextBox7.Left = 4.5!
            Me.TextBox7.Name = "TextBox7"
            Me.TextBox7.OutputFormat = resources.GetString("TextBox7.OutputFormat")
            Me.TextBox7.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt"
            Me.TextBox7.Top = 0.006944444!
            Me.TextBox7.Width = 0.4375!
            '
            'TextBox8
            '
            Me.TextBox8.DataField = "PzasNC"
            Me.TextBox8.Height = 0.2!
            Me.TextBox8.Left = 5!
            Me.TextBox8.Name = "TextBox8"
            Me.TextBox8.OutputFormat = resources.GetString("TextBox8.OutputFormat")
            Me.TextBox8.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt"
            Me.TextBox8.Top = 0.006944444!
            Me.TextBox8.Width = 0.375!
            '
            'TextBox9
            '
            Me.TextBox9.DataField = "ImporteNC"
            Me.TextBox9.Height = 0.2!
            Me.TextBox9.Left = 5.4375!
            Me.TextBox9.Name = "TextBox9"
            Me.TextBox9.OutputFormat = resources.GetString("TextBox9.OutputFormat")
            Me.TextBox9.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt"
            Me.TextBox9.Top = 0.006944444!
            Me.TextBox9.Width = 0.625!
            '
            'TextBox10
            '
            Me.TextBox10.DataField = "ImporteTotal"
            Me.TextBox10.Height = 0.2!
            Me.TextBox10.Left = 6.125!
            Me.TextBox10.Name = "TextBox10"
            Me.TextBox10.OutputFormat = resources.GetString("TextBox10.OutputFormat")
            Me.TextBox10.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt"
            Me.TextBox10.Top = 0.006944444!
            Me.TextBox10.Width = 0.875!
            '
            'Line6
            '
            Me.Line6.Height = 0.3069444!
            Me.Line6.Left = 7.057!
            Me.Line6.LineWeight = 1!
            Me.Line6.Name = "Line6"
            Me.Line6.Top = 0!
            Me.Line6.Width = 0!
            Me.Line6.X1 = 7.057!
            Me.Line6.X2 = 7.057!
            Me.Line6.Y1 = 0!
            Me.Line6.Y2 = 0.3069444!
            '
            'Line7
            '
            Me.Line7.Height = 0.3069444!
            Me.Line7.Left = 0.007!
            Me.Line7.LineWeight = 1!
            Me.Line7.Name = "Line7"
            Me.Line7.Top = 0!
            Me.Line7.Width = 0!
            Me.Line7.X1 = 0.007!
            Me.Line7.X2 = 0.007!
            Me.Line7.Y1 = 0!
            Me.Line7.Y2 = 0.3069444!
            '
            'Shape4
            '
            Me.Shape4.Height = 0.3125!
            Me.Shape4.Left = 0!
            Me.Shape4.LineWeight = 2!
            Me.Shape4.Name = "Shape4"
            Me.Shape4.RoundingRadius = 9.999999!
            Me.Shape4.Top = 0!
            Me.Shape4.Width = 7.0625!
            '
            'TextBox1
            '
            Me.TextBox1.DataField = "PzasTotales"
            Me.TextBox1.Height = 0.2!
            Me.TextBox1.Left = 3.25!
            Me.TextBox1.Name = "TextBox1"
            Me.TextBox1.OutputFormat = resources.GetString("TextBox1.OutputFormat")
            Me.TextBox1.Style = "text-align: right; font-size: 8.25pt"
            Me.TextBox1.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
            Me.TextBox1.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
            Me.TextBox1.Top = 0.0625!
            Me.TextBox1.Width = 0.4128936!
            '
            'txtSumINeto
            '
            Me.txtSumINeto.DataField = "ImporteNeto"
            Me.txtSumINeto.Height = 0.2!
            Me.txtSumINeto.Left = 3.6875!
            Me.txtSumINeto.Name = "txtSumINeto"
            Me.txtSumINeto.OutputFormat = resources.GetString("txtSumINeto.OutputFormat")
            Me.txtSumINeto.Style = "text-align: right; font-size: 8.25pt"
            Me.txtSumINeto.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
            Me.txtSumINeto.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
            Me.txtSumINeto.Top = 0.0625!
            Me.txtSumINeto.Width = 0.75!
            '
            'txtSumPzasNC
            '
            Me.txtSumPzasNC.DataField = "PzasNC"
            Me.txtSumPzasNC.Height = 0.2!
            Me.txtSumPzasNC.Left = 5!
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
            Me.txtSumINC.Left = 5.4375!
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
            Me.txtSumITotal.Left = 6.125!
            Me.txtSumITotal.Name = "txtSumITotal"
            Me.txtSumITotal.OutputFormat = resources.GetString("txtSumITotal.OutputFormat")
            Me.txtSumITotal.Style = "text-align: right; font-size: 8.25pt"
            Me.txtSumITotal.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
            Me.txtSumITotal.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
            Me.txtSumITotal.Top = 0.0625!
            Me.txtSumITotal.Width = 0.875!
            '
            'Line3
            '
            Me.Line3.Height = 7.450581E-09!
            Me.Line3.Left = 0.03937053!
            Me.Line3.LineWeight = 1!
            Me.Line3.Name = "Line3"
            Me.Line3.Top = -0.02312992!
            Me.Line3.Width = 6.456693!
            Me.Line3.X1 = 6.496063!
            Me.Line3.X2 = 0.03937053!
            Me.Line3.Y1 = -0.02312992!
            Me.Line3.Y2 = -0.02312992!
            '
            'ActiveReport1
            '
            Me.MasterReport = false
            Me.PageSettings.Margins.Left = 0.39375!
            Me.PageSettings.Margins.Right = 0.39375!
            Me.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Portrait
            Me.PageSettings.PaperHeight = 11!
            Me.PageSettings.PaperWidth = 8.5!
            Me.PrintWidth = 7.1875!
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
            CType(Me.LblNombRep,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label3,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFechaReporte,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFechaDe,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFechaA,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtSucursal,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label14,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label16,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label17,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label18,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label19,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label20,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label21,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label22,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label23,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox3,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox4,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox5,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox6,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox7,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox8,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox9,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox10,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox1,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtSumINeto,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtSumPzasNC,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtSumINC,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtSumITotal,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        End Sub

#End Region

End Class
