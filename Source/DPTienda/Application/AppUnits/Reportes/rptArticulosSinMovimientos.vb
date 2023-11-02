Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Imports DportenisPro.DPTienda.Reports.Inventario
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoLineas
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoFamilias
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoMarcas
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes
Imports DportenisPro.DPTienda.Reports
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU


Public Class rptArticulosSinMovimientos
Inherits DataDynamics.ActiveReports.ActiveReport
    Public Sub New(ByVal oReporter As ArticulosSinMovimientos)
        MyBase.New()
        InitializeComponent()

        Try
            Dim dsExistencias As New DataSet

            dsExistencias = oReporter.FormatToReport.Copy

            Me.txtDias.Text = oReporter.Dias

            Me.DataSource = dsExistencias
            Me.DataMember = "Existencias"

            Me.txtArticulos.DataField = "Articulo"
            Me.txtColor.DataField = "Color"
            Me.txtTallas.DataField = "Tallas"
            Me.txtTotal.DataField = "Total"
            Me.txtTotalNumero.DataField = "TotalNum"
            Me.txtDescripcion.DataField = "Descripcion"
            Me.txtFechaReporte.Text = Format(Date.Now, "dd - MMM - yyyy")

            Dim oCatalogoAlmacenesMgr As New CatalogoAlmacenesManager(oAppContext)
            Dim oAlmacen As Almacen
            Dim oSAPMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
            oAlmacen = oCatalogoAlmacenesMgr.Load(oSAPMgr.Read_Centros) 'oAppContext.ApplicationConfiguration.Almacen)

            TxtSucursal.Text = oAlmacen.ID & "    " & oAlmacen.Descripcion


            If Not oReporter.CodMarca = "" Then
                Dim oMarcas As Marca
                Dim oMarcasMgr As New CatalogoMarcasManager(oAppContext)
                oMarcas = oMarcasMgr.Create
                oMarcas = oMarcasMgr.Load(oReporter.CodMarca)
                Me.txtMarca.Text = oReporter.CodMarca & " " & oMarcas.Descripcion
            Else
                Me.txtMarca.Visible = False
                Me.lblMarca.Visible = False
            End If

            If Not oReporter.CodLinea = "" Then
                Dim oLineas As Linea
                Dim olineasMgr As New CatalogoLineasManager(oAppContext)
                oLineas = olineasMgr.Create
                oLineas = olineasMgr.Load(oReporter.CodLinea)
                Me.txtLinea.Text = oReporter.CodLinea & " " & oLineas.Descripcion
            Else
                Me.txtLinea.Visible = False
                Me.lblLinea.Visible = False
            End If

            If Not oReporter.CodFamilia = "" Then
                Dim oFamilias As Familias
                Dim oFamiliasMgr As New CatalogoFamiliasManager(oAppContext)
                oFamilias = oFamiliasMgr.Create
                oFamilias = oFamiliasMgr.Load(oReporter.CodFamilia)
                Me.txtFamilia.Text = oReporter.CodFamilia & " " & oFamilias.Descripcion
            Else
                Me.txtFamilia.Visible = False
                Me.lblFamilia.Visible = False
            End If
        Catch ex As Exception

            Throw ex


        End Try

       


    End Sub
#Region "ActiveReports Designer generated code"
    Private WithEvents ReportHeader As ReportHeader = Nothing
    Private WithEvents PageHeader As PageHeader = Nothing
    Private WithEvents GroupHeader1 As GroupHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents GroupFooter1 As GroupFooter = Nothing
    Private WithEvents PageFooter As PageFooter = Nothing
    Private WithEvents ReportFooter As ReportFooter = Nothing
	Private Shape1 As Shape = Nothing
	Private Label1 As Label = Nothing
	Private txtFechaReporte As TextBox = Nothing
	Private Label11 As Label = Nothing
	Private TxtSucursal As TextBox = Nothing
	Private lblLinea As Label = Nothing
	Private lblFamilia As Label = Nothing
	Private lblMarca As Label = Nothing
	Private txtMarca As TextBox = Nothing
	Private txtLinea As TextBox = Nothing
	Private txtFamilia As TextBox = Nothing
	Private Label17 As Label = Nothing
	Private txtDias As TextBox = Nothing
	Private Label4 As Label = Nothing
	Private Label3 As Label = Nothing
	Private Label6 As Label = Nothing
	Private Label2 As Label = Nothing
	Private txtArticulos As TextBox = Nothing
	Private txtTotal As TextBox = Nothing
	Private txtTallas As TextBox = Nothing
	Private txtColor As TextBox = Nothing
	Private txtDescripcion As TextBox = Nothing
	Private txtTotalNumero As TextBox = Nothing
	Private Label12 As Label = Nothing
	Private Label16 As Label = Nothing
	Private TextBox4 As TextBox = Nothing
	Private Label7 As Label = Nothing
	Private txtSumTotal As TextBox = Nothing
	Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptArticulosSinMovimientos))
            Me.Detail = New DataDynamics.ActiveReports.Detail()
            Me.ReportHeader = New DataDynamics.ActiveReports.ReportHeader()
            Me.ReportFooter = New DataDynamics.ActiveReports.ReportFooter()
            Me.PageHeader = New DataDynamics.ActiveReports.PageHeader()
            Me.PageFooter = New DataDynamics.ActiveReports.PageFooter()
            Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader()
            Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter()
            Me.Shape1 = New DataDynamics.ActiveReports.Shape()
            Me.Label1 = New DataDynamics.ActiveReports.Label()
            Me.txtFechaReporte = New DataDynamics.ActiveReports.TextBox()
            Me.Label11 = New DataDynamics.ActiveReports.Label()
            Me.TxtSucursal = New DataDynamics.ActiveReports.TextBox()
            Me.lblLinea = New DataDynamics.ActiveReports.Label()
            Me.lblFamilia = New DataDynamics.ActiveReports.Label()
            Me.lblMarca = New DataDynamics.ActiveReports.Label()
            Me.txtMarca = New DataDynamics.ActiveReports.TextBox()
            Me.txtLinea = New DataDynamics.ActiveReports.TextBox()
            Me.txtFamilia = New DataDynamics.ActiveReports.TextBox()
            Me.Label17 = New DataDynamics.ActiveReports.Label()
            Me.txtDias = New DataDynamics.ActiveReports.TextBox()
            Me.Label4 = New DataDynamics.ActiveReports.Label()
            Me.Label3 = New DataDynamics.ActiveReports.Label()
            Me.Label6 = New DataDynamics.ActiveReports.Label()
            Me.Label2 = New DataDynamics.ActiveReports.Label()
            Me.txtArticulos = New DataDynamics.ActiveReports.TextBox()
            Me.txtTotal = New DataDynamics.ActiveReports.TextBox()
            Me.txtTallas = New DataDynamics.ActiveReports.TextBox()
            Me.txtColor = New DataDynamics.ActiveReports.TextBox()
            Me.txtDescripcion = New DataDynamics.ActiveReports.TextBox()
            Me.txtTotalNumero = New DataDynamics.ActiveReports.TextBox()
            Me.Label12 = New DataDynamics.ActiveReports.Label()
            Me.Label16 = New DataDynamics.ActiveReports.Label()
            Me.TextBox4 = New DataDynamics.ActiveReports.TextBox()
            Me.Label7 = New DataDynamics.ActiveReports.Label()
            Me.txtSumTotal = New DataDynamics.ActiveReports.TextBox()
            CType(Me.Label1,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFechaReporte,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label11,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TxtSucursal,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblLinea,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblFamilia,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblMarca,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtMarca,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtLinea,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFamilia,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label17,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtDias,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label3,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label6,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtArticulos,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtTotal,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtTallas,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtColor,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtDescripcion,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtTotalNumero,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label12,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label16,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox4,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label7,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtSumTotal,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
            '
            'Detail
            '
            Me.Detail.ColumnSpacing = 0!
            Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtArticulos, Me.txtTotal, Me.txtTallas, Me.txtColor, Me.txtDescripcion, Me.txtTotalNumero, Me.Label12})
            Me.Detail.Height = 0.40625!
            Me.Detail.Name = "Detail"
            '
            'ReportHeader
            '
            Me.ReportHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape1, Me.Label1, Me.txtFechaReporte, Me.Label11, Me.TxtSucursal, Me.lblLinea, Me.lblFamilia, Me.lblMarca, Me.txtMarca, Me.txtLinea, Me.txtFamilia, Me.Label17, Me.txtDias})
            Me.ReportHeader.Height = 0.9375!
            Me.ReportHeader.Name = "ReportHeader"
            '
            'ReportFooter
            '
            Me.ReportFooter.Height = 0.25!
            Me.ReportFooter.Name = "ReportFooter"
            '
            'PageHeader
            '
            Me.PageHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label4, Me.Label3, Me.Label6, Me.Label2})
            Me.PageHeader.Height = 0.2291667!
            Me.PageHeader.Name = "PageHeader"
            '
            'PageFooter
            '
            Me.PageFooter.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label16, Me.TextBox4, Me.Label7, Me.txtSumTotal})
            Me.PageFooter.Height = 0.2076389!
            Me.PageFooter.Name = "PageFooter"
            '
            'GroupHeader1
            '
            Me.GroupHeader1.Height = 0!
            Me.GroupHeader1.Name = "GroupHeader1"
            '
            'GroupFooter1
            '
            Me.GroupFooter1.Height = 0.25!
            Me.GroupFooter1.Name = "GroupFooter1"
            '
            'Shape1
            '
            Me.Shape1.Height = 0.8661417!
            Me.Shape1.Left = 0.03937007!
            Me.Shape1.LineWeight = 2!
            Me.Shape1.Name = "Shape1"
            Me.Shape1.RoundingRadius = 9.999999!
            Me.Shape1.Top = 0.03937007!
            Me.Shape1.Width = 7.401576!
            '
            'Label1
            '
            Me.Label1.Height = 0.2!
            Me.Label1.HyperLink = Nothing
            Me.Label1.Left = 2.711615!
            Me.Label1.Name = "Label1"
            Me.Label1.Style = "ddo-char-set: 1; font-weight: bold; font-size: 8pt"
            Me.Label1.Text = "REPORTE DE ARTÍCULOS SIN MOVIMIENTO"
            Me.Label1.Top = 0.07874014!
            Me.Label1.Width = 2.401574!
            '
            'txtFechaReporte
            '
            Me.txtFechaReporte.Height = 0.2!
            Me.txtFechaReporte.Left = 0.1230315!
            Me.txtFechaReporte.Name = "txtFechaReporte"
            Me.txtFechaReporte.Style = "ddo-char-set: 1; font-weight: bold; font-size: 8pt"
            Me.txtFechaReporte.Text = "txtFecha"
            Me.txtFechaReporte.Top = 0.08710632!
            Me.txtFechaReporte.Width = 1!
            '
            'Label11
            '
            Me.Label11.Height = 0.1722441!
            Me.Label11.HyperLink = Nothing
            Me.Label11.Left = 3.229331!
            Me.Label11.Name = "Label11"
            Me.Label11.Style = "ddo-char-set: 1; font-weight: bold; font-size: 8pt"
            Me.Label11.Text = "Sucursal.:"
            Me.Label11.Top = 0.3444882!
            Me.Label11.Width = 0.5984252!
            '
            'TxtSucursal
            '
            Me.TxtSucursal.Height = 0.1968504!
            Me.TxtSucursal.Left = 3.892225!
            Me.TxtSucursal.Name = "TxtSucursal"
            Me.TxtSucursal.Style = "ddo-char-set: 1; font-size: 8pt"
            Me.TxtSucursal.Text = "TxtSucursal"
            Me.TxtSucursal.Top = 0.3690945!
            Me.TxtSucursal.Width = 2.903543!
            '
            'lblLinea
            '
            Me.lblLinea.Height = 0.1722441!
            Me.lblLinea.HyperLink = Nothing
            Me.lblLinea.Left = 3.031496!
            Me.lblLinea.Name = "lblLinea"
            Me.lblLinea.Style = "ddo-char-set: 1; font-weight: bold; font-size: 8pt"
            Me.lblLinea.Text = "Linea.:"
            Me.lblLinea.Top = 0.6692914!
            Me.lblLinea.Width = 0.4330704!
            '
            'lblFamilia
            '
            Me.lblFamilia.Height = 0.1722441!
            Me.lblFamilia.HyperLink = Nothing
            Me.lblFamilia.Left = 5.433072!
            Me.lblFamilia.Name = "lblFamilia"
            Me.lblFamilia.Style = "ddo-char-set: 1; font-weight: bold; font-size: 8pt"
            Me.lblFamilia.Text = "Familia.:"
            Me.lblFamilia.Top = 0.6692914!
            Me.lblFamilia.Width = 0.5118113!
            '
            'lblMarca
            '
            Me.lblMarca.Height = 0.1722441!
            Me.lblMarca.HyperLink = Nothing
            Me.lblMarca.Left = 0.1968504!
            Me.lblMarca.Name = "lblMarca"
            Me.lblMarca.Style = "ddo-char-set: 1; font-weight: bold; font-size: 8pt"
            Me.lblMarca.Text = "Marca.:"
            Me.lblMarca.Top = 0.6692914!
            Me.lblMarca.Width = 0.4330704!
            '
            'txtMarca
            '
            Me.txtMarca.Height = 0.1968504!
            Me.txtMarca.Left = 0.7874014!
            Me.txtMarca.Name = "txtMarca"
            Me.txtMarca.Style = "ddo-char-set: 1; font-size: 8pt"
            Me.txtMarca.Text = "TextBox1"
            Me.txtMarca.Top = 0.6692914!
            Me.txtMarca.Width = 1.579724!
            '
            'txtLinea
            '
            Me.txtLinea.Height = 0.1968504!
            Me.txtLinea.Left = 3.543307!
            Me.txtLinea.Name = "txtLinea"
            Me.txtLinea.Style = "ddo-char-set: 1; font-size: 8pt"
            Me.txtLinea.Text = "TextBox2"
            Me.txtLinea.Top = 0.6692914!
            Me.txtLinea.Width = 1.574803!
            '
            'txtFamilia
            '
            Me.txtFamilia.Height = 0.1968504!
            Me.txtFamilia.Left = 5.944882!
            Me.txtFamilia.Name = "txtFamilia"
            Me.txtFamilia.Style = "ddo-char-set: 1; font-size: 8pt"
            Me.txtFamilia.Text = "TextBox3"
            Me.txtFamilia.Top = 0.6692914!
            Me.txtFamilia.Width = 1.458661!
            '
            'Label17
            '
            Me.Label17.Height = 0.1722441!
            Me.Label17.HyperLink = Nothing
            Me.Label17.Left = 0.551181!
            Me.Label17.Name = "Label17"
            Me.Label17.Style = "ddo-char-set: 1; font-weight: bold; font-size: 8pt"
            Me.Label17.Text = "Días sin Movimientos..:"
            Me.Label17.Top = 0.3567914!
            Me.Label17.Width = 1.338583!
            '
            'txtDias
            '
            Me.txtDias.Height = 0.1968504!
            Me.txtDias.Left = 1.966043!
            Me.txtDias.Name = "txtDias"
            Me.txtDias.Style = "ddo-char-set: 1; font-size: 8pt"
            Me.txtDias.Text = "TextBox1"
            Me.txtDias.Top = 0.3543307!
            Me.txtDias.Width = 0.5280511!
            '
            'Label4
            '
            Me.Label4.Height = 0.2!
            Me.Label4.HyperLink = Nothing
            Me.Label4.Left = 3.982775!
            Me.Label4.Name = "Label4"
            Me.Label4.Style = "ddo-char-set: 1; text-align: center; font-weight: bold; font-size: 8pt"
            Me.Label4.Text = "TALLAS / EXISTENCIAS"
            Me.Label4.Top = 0.01624024!
            Me.Label4.Width = 2.647637!
            '
            'Label3
            '
            Me.Label3.Height = 0.2!
            Me.Label3.HyperLink = Nothing
            Me.Label3.Left = 2.8125!
            Me.Label3.Name = "Label3"
            Me.Label3.Style = "ddo-char-set: 1; text-align: center; font-weight: bold; font-size: 8pt"
            Me.Label3.Text = "TOTAL"
            Me.Label3.Top = 0!
            Me.Label3.Width = 1!
            '
            'Label6
            '
            Me.Label6.Height = 0.2!
            Me.Label6.HyperLink = Nothing
            Me.Label6.Left = 1.5!
            Me.Label6.Name = "Label6"
            Me.Label6.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt"
            Me.Label6.Text = "COLOR"
            Me.Label6.Top = 0!
            Me.Label6.Width = 1!
            '
            'Label2
            '
            Me.Label2.Height = 0.2!
            Me.Label2.HyperLink = Nothing
            Me.Label2.Left = 0!
            Me.Label2.Name = "Label2"
            Me.Label2.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt"
            Me.Label2.Text = "ARTICULOS"
            Me.Label2.Top = 0!
            Me.Label2.Width = 1!
            '
            'txtArticulos
            '
            Me.txtArticulos.Height = 0.2!
            Me.txtArticulos.Left = 0.1018701!
            Me.txtArticulos.Name = "txtArticulos"
            Me.txtArticulos.Style = "ddo-char-set: 1; font-size: 8pt"
            Me.txtArticulos.Text = "txtArticulos"
            Me.txtArticulos.Top = 0!
            Me.txtArticulos.Width = 1.394193!
            '
            'txtTotal
            '
            Me.txtTotal.Height = 0.1456693!
            Me.txtTotal.Left = 2.91437!
            Me.txtTotal.Name = "txtTotal"
            Me.txtTotal.OutputFormat = resources.GetString("txtTotal.OutputFormat")
            Me.txtTotal.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt"
            Me.txtTotal.Text = "txtTotal"
            Me.txtTotal.Top = 0.1875!
            Me.txtTotal.Width = 0.7076771!
            '
            'txtTallas
            '
            Me.txtTallas.Height = 0.2!
            Me.txtTallas.Left = 4.075952!
            Me.txtTallas.Name = "txtTallas"
            Me.txtTallas.Style = "font-size: 8.25pt; font-family: Courier New"
            Me.txtTallas.Text = "txtTallas"
            Me.txtTallas.Top = 0!
            Me.txtTallas.Width = 3.364993!
            '
            'txtColor
            '
            Me.txtColor.Height = 0.2!
            Me.txtColor.Left = 1.574803!
            Me.txtColor.Name = "txtColor"
            Me.txtColor.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt"
            Me.txtColor.Text = "txtColor"
            Me.txtColor.Top = 0!
            Me.txtColor.Width = 1!
            '
            'txtDescripcion
            '
            Me.txtDescripcion.Height = 0.2!
            Me.txtDescripcion.Left = 0.07874014!
            Me.txtDescripcion.Name = "txtDescripcion"
            Me.txtDescripcion.Style = "ddo-char-set: 1; font-size: 8pt"
            Me.txtDescripcion.Text = "TextBox1"
            Me.txtDescripcion.Top = 0.1968504!
            Me.txtDescripcion.Width = 1.417323!
            '
            'txtTotalNumero
            '
            Me.txtTotalNumero.Height = 0.2!
            Me.txtTotalNumero.Left = 4.055118!
            Me.txtTotalNumero.Name = "txtTotalNumero"
            Me.txtTotalNumero.Style = "font-size: 8.25pt; font-family: Courier New"
            Me.txtTotalNumero.Text = "TextBox4"
            Me.txtTotalNumero.Top = 0.1968504!
            Me.txtTotalNumero.Width = 3.385826!
            '
            'Label12
            '
            Me.Label12.Height = 0.2!
            Me.Label12.HyperLink = Nothing
            Me.Label12.Left = 3.32874!
            Me.Label12.Name = "Label12"
            Me.Label12.Style = "ddo-char-set: 1; text-align: left; font-weight: normal; font-size: 8pt"
            Me.Label12.Text = "Total"
            Me.Label12.Top = 0!
            Me.Label12.Width = 0.3567913!
            '
            'Label16
            '
            Me.Label16.Height = 0.1722441!
            Me.Label16.HyperLink = Nothing
            Me.Label16.Left = 6.338583!
            Me.Label16.Name = "Label16"
            Me.Label16.Style = "ddo-char-set: 1; font-weight: bold; font-size: 8pt"
            Me.Label16.Text = "Pág.:"
            Me.Label16.Top = 0!
            Me.Label16.Width = 0.3543305!
            '
            'TextBox4
            '
            Me.TextBox4.Height = 0.1968504!
            Me.TextBox4.Left = 6.850393!
            Me.TextBox4.Name = "TextBox4"
            Me.TextBox4.Style = "ddo-char-set: 1; font-size: 8pt"
            Me.TextBox4.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
            Me.TextBox4.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount
            Me.TextBox4.Top = 0!
            Me.TextBox4.Width = 0.5511823!
            '
            'Label7
            '
            Me.Label7.Height = 0.2!
            Me.Label7.HyperLink = Nothing
            Me.Label7.Left = 0.03937007!
            Me.Label7.Name = "Label7"
            Me.Label7.Style = "font-size: 8.25pt"
            Me.Label7.Text = "Total Articulos"
            Me.Label7.Top = 0!
            Me.Label7.Width = 1!
            '
            'txtSumTotal
            '
            Me.txtSumTotal.DataField = "Total"
            Me.txtSumTotal.Height = 0.2!
            Me.txtSumTotal.Left = 2.864173!
            Me.txtSumTotal.Name = "txtSumTotal"
            Me.txtSumTotal.OutputFormat = resources.GetString("txtSumTotal.OutputFormat")
            Me.txtSumTotal.Style = "text-align: right; font-size: 8.25pt"
            Me.txtSumTotal.SummaryGroup = "GroupHeader1"
            Me.txtSumTotal.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
            Me.txtSumTotal.SummaryType = DataDynamics.ActiveReports.SummaryType.PageTotal
            Me.txtSumTotal.Text = "TextBox1"
            Me.txtSumTotal.Top = 0!
            Me.txtSumTotal.Width = 0.7578743!
            '
            'ActiveReport1
            '
            Me.MasterReport = false
            Me.PageSettings.Margins.Bottom = 0.7875!
            Me.PageSettings.Margins.Left = 0.39375!
            Me.PageSettings.Margins.Right = 0.39375!
            Me.PageSettings.Margins.Top = 0.7875!
            Me.PageSettings.PaperHeight = 11!
            Me.PageSettings.PaperWidth = 8.5!
            Me.PrintWidth = 7.479167!
            Me.Sections.Add(Me.ReportHeader)
            Me.Sections.Add(Me.PageHeader)
            Me.Sections.Add(Me.GroupHeader1)
            Me.Sections.Add(Me.Detail)
            Me.Sections.Add(Me.GroupFooter1)
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
            CType(Me.txtFechaReporte,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label11,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TxtSucursal,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblLinea,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblFamilia,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblMarca,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtMarca,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtLinea,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFamilia,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label17,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtDias,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label3,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label6,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtArticulos,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtTotal,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtTallas,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtColor,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtDescripcion,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtTotalNumero,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label12,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label16,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox4,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label7,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtSumTotal,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        
	End Sub

#End Region


End Class
