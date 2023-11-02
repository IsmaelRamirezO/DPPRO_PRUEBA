Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Imports DportenisPro.DPTienda.Reports.Inventario
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoLineas
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoFamilias
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU

Public Class rptInventarioExistenciasLineaFamilia

    Inherits DataDynamics.ActiveReports.ActiveReport

    Public Sub New(ByVal Mes As String, ByVal CodLinea As String, ByVal CodFamilia As String, ByVal mes2 As String)

        MyBase.New()

        InitializeComponent()

        Dim oLinea As Linea
        Dim oLineaMgr As New CatalogoLineasManager(oAppContext)

        Dim oFamilia As Familias
        Dim oFamiliaMgr As New CatalogoFamiliasManager(oAppContext)

        Dim oReporter As New InventarioLineaFamilia
        Dim dsInventario As DataSet
        Dim oDataGateway As New ReporteInventarioDataGateway(oAppContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString)

        dsInventario = oDataGateway.GetInventarioLineaFamilia(Mes, CodLinea, CodFamilia, True).Copy
        CreateTable()

        For Each row As DataRow In dsInventario.Tables("Inventario").Rows
            Dim bandNewRow As Boolean = True

            For Each row2 As DataRow In dsExistencias.Tables("Existencias").Rows

                If CStr(row("CodArticulo")).Trim = row2("Articulo") Then

                    bandNewRow = False

                End If

            Next

            If bandNewRow Then

                Dim newRow As DataRow = dsExistencias.Tables("Existencias").NewRow
                Dim TVentas As Integer

                newRow("Articulo") = CStr(row("CodArticulo")).Trim
                newRow("Descripcion") = CStr(row("Descripcion")).Trim
                newRow("Color") = CStr(row("Color")).Trim
                newRow("Total") = dsInventario.Tables("Inventario").Compute("sum(TotalMes)", "CodArticulo like '" & row("CodArticulo") & "'")

                For Each row2 As DataRow In dsInventario.Tables("Inventario").Rows
                    If row2("CodArticulo") = row("CodArticulo") Then
                        Dim i As Integer = 0
                        Dim space As String = String.Empty
                        newRow("Tallas") &= " " & CStr(row2("Numero"))
                        For i = 1 To CStr(row2("Numero")).Length
                            space &= " "
                        Next
                        newRow("TotalNum") &= space & Format(row2("TotalMes"), "#####")
                    End If
                Next
                newRow("Tallas") = CStr(newRow("Tallas")).TrimStart()
                newRow("TotalNum") = CStr(newRow("TotalNum")).TrimStart

                dsExistencias.Tables("Existencias").Rows.Add(newRow)
                dsExistencias.AcceptChanges()

            End If

        Next

        Me.DataSource = dsExistencias
        Me.DataMember = "Existencias"

        Me.txtArticulos.DataField = "Articulo"
        Me.txtColor.DataField = "Color"
        Me.txtTallas.DataField = "Tallas"
        Me.txtTotal.DataField = "Total"
        Me.txtTotalNumero.DataField = "TotalNum"
        Me.txtDescripcion.DataField = "Descripcion"
        Me.txtFechaReporte.Text = Format(Date.Now, "dd - MMM - yyyy")
        Me.txtMes.Text = mes2.ToUpper

        oFamilia = oFamiliaMgr.Load(CodFamilia)
        oLinea = oLineaMgr.Load(CodLinea)
        Me.txtFiltros.Text = oLinea.Descripcion & " / " & oFamilia.Descripcion


        Dim oCatalogoAlmacenesMgr As New CatalogoAlmacenesManager(oAppContext)
        Dim oAlmacen As Almacen
        Dim oSAPMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        oAlmacen = oCatalogoAlmacenesMgr.Load(oSAPMgr.REad_centros) 'oAppContext.ApplicationConfiguration.Almacen)

        TxtSucursal.Text = oAlmacen.ID & "    " & oAlmacen.Descripcion

    End Sub
#Region "ActiveReports Designer generated code"
    Private WithEvents PageHeader As PageHeader = Nothing
    Private WithEvents GroupHeader1 As GroupHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents GroupFooter1 As GroupFooter = Nothing
    Private WithEvents PageFooter As PageFooter = Nothing
	Private Shape2 As Shape = Nothing
	Private Shape1 As Shape = Nothing
	Private Label1 As Label = Nothing
	Private txtFiltros As TextBox = Nothing
	Private txtFechaReporte As TextBox = Nothing
	Private txtMes As TextBox = Nothing
	Private Label10 As Label = Nothing
	Private Label2 As Label = Nothing
	Private Label6 As Label = Nothing
	Private Label3 As Label = Nothing
	Private Label4 As Label = Nothing
	Private Label11 As Label = Nothing
	Private TxtSucursal As TextBox = Nothing
	Private txtArticulos As TextBox = Nothing
	Private txtTotal As TextBox = Nothing
	Private txtTallas As TextBox = Nothing
	Private txtColor As TextBox = Nothing
	Private txtDescripcion As TextBox = Nothing
	Private txtTotalNumero As TextBox = Nothing
	Private Label12 As Label = Nothing
	Private txtSumTotal As TextBox = Nothing
	Private Label7 As Label = Nothing
	Private txtSumTotalP As TextBox = Nothing
	Private Label5 As Label = Nothing
	Private Label8 As Label = Nothing
	Private TextBox1 As TextBox = Nothing
	Private Label9 As Label = Nothing
	Private TextBox2 As TextBox = Nothing
	Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptInventarioExistenciasLineaFamilia))
            Me.Detail = New DataDynamics.ActiveReports.Detail()
            Me.PageHeader = New DataDynamics.ActiveReports.PageHeader()
            Me.PageFooter = New DataDynamics.ActiveReports.PageFooter()
            Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader()
            Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter()
            Me.Shape2 = New DataDynamics.ActiveReports.Shape()
            Me.Shape1 = New DataDynamics.ActiveReports.Shape()
            Me.Label1 = New DataDynamics.ActiveReports.Label()
            Me.txtFiltros = New DataDynamics.ActiveReports.TextBox()
            Me.txtFechaReporte = New DataDynamics.ActiveReports.TextBox()
            Me.txtMes = New DataDynamics.ActiveReports.TextBox()
            Me.Label10 = New DataDynamics.ActiveReports.Label()
            Me.Label2 = New DataDynamics.ActiveReports.Label()
            Me.Label6 = New DataDynamics.ActiveReports.Label()
            Me.Label3 = New DataDynamics.ActiveReports.Label()
            Me.Label4 = New DataDynamics.ActiveReports.Label()
            Me.Label11 = New DataDynamics.ActiveReports.Label()
            Me.TxtSucursal = New DataDynamics.ActiveReports.TextBox()
            Me.txtArticulos = New DataDynamics.ActiveReports.TextBox()
            Me.txtTotal = New DataDynamics.ActiveReports.TextBox()
            Me.txtTallas = New DataDynamics.ActiveReports.TextBox()
            Me.txtColor = New DataDynamics.ActiveReports.TextBox()
            Me.txtDescripcion = New DataDynamics.ActiveReports.TextBox()
            Me.txtTotalNumero = New DataDynamics.ActiveReports.TextBox()
            Me.Label12 = New DataDynamics.ActiveReports.Label()
            Me.txtSumTotal = New DataDynamics.ActiveReports.TextBox()
            Me.Label7 = New DataDynamics.ActiveReports.Label()
            Me.txtSumTotalP = New DataDynamics.ActiveReports.TextBox()
            Me.Label5 = New DataDynamics.ActiveReports.Label()
            Me.Label8 = New DataDynamics.ActiveReports.Label()
            Me.TextBox1 = New DataDynamics.ActiveReports.TextBox()
            Me.Label9 = New DataDynamics.ActiveReports.Label()
            Me.TextBox2 = New DataDynamics.ActiveReports.TextBox()
            CType(Me.Label1,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFiltros,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFechaReporte,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtMes,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label10,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label6,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label3,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label11,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TxtSucursal,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtArticulos,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtTotal,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtTallas,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtColor,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtDescripcion,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtTotalNumero,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label12,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtSumTotal,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label7,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtSumTotalP,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label5,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label8,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox1,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label9,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox2,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
            '
            'Detail
            '
            Me.Detail.ColumnSpacing = 0!
            Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtArticulos, Me.txtTotal, Me.txtTallas, Me.txtColor, Me.txtDescripcion, Me.txtTotalNumero, Me.Label12})
            Me.Detail.Height = 0.40625!
            Me.Detail.Name = "Detail"
            '
            'PageHeader
            '
            Me.PageHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape2, Me.Shape1, Me.Label1, Me.txtFiltros, Me.txtFechaReporte, Me.txtMes, Me.Label10, Me.Label2, Me.Label6, Me.Label3, Me.Label4, Me.Label11, Me.TxtSucursal})
            Me.PageHeader.Height = 1.020833!
            Me.PageHeader.Name = "PageHeader"
            '
            'PageFooter
            '
            Me.PageFooter.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtSumTotalP, Me.Label5, Me.Label8, Me.TextBox1, Me.Label9, Me.TextBox2})
            Me.PageFooter.Height = 0.1763889!
            Me.PageFooter.Name = "PageFooter"
            '
            'GroupHeader1
            '
            Me.GroupHeader1.Height = 0!
            Me.GroupHeader1.Name = "GroupHeader1"
            '
            'GroupFooter1
            '
            Me.GroupFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtSumTotal, Me.Label7})
            Me.GroupFooter1.Height = 0.15625!
            Me.GroupFooter1.Name = "GroupFooter1"
            '
            'Shape2
            '
            Me.Shape2.Height = 0.2475394!
            Me.Shape2.Left = 0!
            Me.Shape2.LineWeight = 2!
            Me.Shape2.Name = "Shape2"
            Me.Shape2.RoundingRadius = 9.999999!
            Me.Shape2.Top = 0.7121062!
            Me.Shape2.Width = 7.258861!
            '
            'Shape1
            '
            Me.Shape1.Height = 0.6850394!
            Me.Shape1.Left = 0!
            Me.Shape1.LineWeight = 2!
            Me.Shape1.Name = "Shape1"
            Me.Shape1.RoundingRadius = 9.999999!
            Me.Shape1.Top = 0.0246063!
            Me.Shape1.Width = 7.258861!
            '
            'Label1
            '
            Me.Label1.Height = 0.2!
            Me.Label1.HyperLink = Nothing
            Me.Label1.Left = 2.116633!
            Me.Label1.Name = "Label1"
            Me.Label1.Style = "ddo-char-set: 1; font-weight: bold; font-size: 8pt"
            Me.Label1.Text = "REPORTE DE EXISTENCIAS :"
            Me.Label1.Top = 0.08710632!
            Me.Label1.Width = 1.633859!
            '
            'txtFiltros
            '
            Me.txtFiltros.Height = 0.1968504!
            Me.txtFiltros.Left = 3.721457!
            Me.txtFiltros.Name = "txtFiltros"
            Me.txtFiltros.Style = "ddo-char-set: 1; font-weight: bold; font-size: 8pt"
            Me.txtFiltros.Text = "txtFiltros"
            Me.txtFiltros.Top = 0.1018701!
            Me.txtFiltros.Width = 2.086614!
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
            'txtMes
            '
            Me.txtMes.Height = 0.2!
            Me.txtMes.Left = 6.43996!
            Me.txtMes.Name = "txtMes"
            Me.txtMes.OutputFormat = resources.GetString("txtMes.OutputFormat")
            Me.txtMes.Style = "ddo-char-set: 1; font-size: 8pt"
            Me.txtMes.Text = "txtMes"
            Me.txtMes.Top = 0.1043307!
            Me.txtMes.Width = 0.75!
            '
            'Label10
            '
            Me.Label10.Height = 0.2!
            Me.Label10.HyperLink = Nothing
            Me.Label10.Left = 5.90994!
            Me.Label10.Name = "Label10"
            Me.Label10.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt"
            Me.Label10.Text = "Mes:"
            Me.Label10.Top = 0.1043307!
            Me.Label10.Width = 0.370079!
            '
            'Label2
            '
            Me.Label2.Height = 0.2!
            Me.Label2.HyperLink = Nothing
            Me.Label2.Left = 0.07874014!
            Me.Label2.Name = "Label2"
            Me.Label2.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt"
            Me.Label2.Text = "ARTICULOS"
            Me.Label2.Top = 0.75!
            Me.Label2.Width = 1!
            '
            'Label6
            '
            Me.Label6.Height = 0.2!
            Me.Label6.HyperLink = Nothing
            Me.Label6.Left = 1.57874!
            Me.Label6.Name = "Label6"
            Me.Label6.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt"
            Me.Label6.Text = "COLOR"
            Me.Label6.Top = 0.75!
            Me.Label6.Width = 1!
            '
            'Label3
            '
            Me.Label3.Height = 0.2!
            Me.Label3.HyperLink = Nothing
            Me.Label3.Left = 2.89124!
            Me.Label3.Name = "Label3"
            Me.Label3.Style = "ddo-char-set: 1; text-align: center; font-weight: bold; font-size: 8pt"
            Me.Label3.Text = "TOTAL"
            Me.Label3.Top = 0.75!
            Me.Label3.Width = 1!
            '
            'Label4
            '
            Me.Label4.Height = 0.2!
            Me.Label4.HyperLink = Nothing
            Me.Label4.Left = 4.061516!
            Me.Label4.Name = "Label4"
            Me.Label4.Style = "ddo-char-set: 1; text-align: center; font-weight: bold; font-size: 8pt"
            Me.Label4.Text = "TALLAS / EXISTENCIAS"
            Me.Label4.Top = 0.7662402!
            Me.Label4.Width = 2.647637!
            '
            'Label11
            '
            Me.Label11.Height = 0.1722441!
            Me.Label11.HyperLink = Nothing
            Me.Label11.Left = 2.140748!
            Me.Label11.Name = "Label11"
            Me.Label11.Style = "ddo-char-set: 1; font-weight: bold; font-size: 8pt"
            Me.Label11.Text = "Sucursal:"
            Me.Label11.Top = 0.4069882!
            Me.Label11.Width = 0.5620079!
            '
            'TxtSucursal
            '
            Me.TxtSucursal.Height = 0.1968504!
            Me.TxtSucursal.Left = 2.767224!
            Me.TxtSucursal.Name = "TxtSucursal"
            Me.TxtSucursal.Style = "ddo-char-set: 1; font-size: 8pt"
            Me.TxtSucursal.Text = "TxtSucursal"
            Me.TxtSucursal.Top = 0.4315945!
            Me.TxtSucursal.Width = 2.903543!
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
            'txtSumTotal
            '
            Me.txtSumTotal.DataField = "Total"
            Me.txtSumTotal.Height = 0.2!
            Me.txtSumTotal.Left = 2.864173!
            Me.txtSumTotal.Name = "txtSumTotal"
            Me.txtSumTotal.OutputFormat = resources.GetString("txtSumTotal.OutputFormat")
            Me.txtSumTotal.Style = "text-align: right; font-size: 8.25pt"
            Me.txtSumTotal.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
            Me.txtSumTotal.Text = "TextBox1"
            Me.txtSumTotal.Top = 0!
            Me.txtSumTotal.Width = 0.7578743!
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
            'txtSumTotalP
            '
            Me.txtSumTotalP.DataField = "Total"
            Me.txtSumTotalP.Height = 0.2!
            Me.txtSumTotalP.Left = 2.864173!
            Me.txtSumTotalP.Name = "txtSumTotalP"
            Me.txtSumTotalP.OutputFormat = resources.GetString("txtSumTotalP.OutputFormat")
            Me.txtSumTotalP.Style = "text-align: right; font-size: 8.25pt"
            Me.txtSumTotalP.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
            Me.txtSumTotalP.SummaryType = DataDynamics.ActiveReports.SummaryType.PageTotal
            Me.txtSumTotalP.Text = "txtSumTotal"
            Me.txtSumTotalP.Top = 0!
            Me.txtSumTotalP.Width = 0.7578743!
            '
            'Label5
            '
            Me.Label5.Height = 0.2!
            Me.Label5.HyperLink = Nothing
            Me.Label5.Left = 0.03937007!
            Me.Label5.Name = "Label5"
            Me.Label5.Style = "font-size: 8.25pt"
            Me.Label5.Text = "Total Página"
            Me.Label5.Top = 0!
            Me.Label5.Width = 1!
            '
            'Label8
            '
            Me.Label8.Height = 0.2!
            Me.Label8.HyperLink = Nothing
            Me.Label8.Left = 5.510417!
            Me.Label8.Name = "Label8"
            Me.Label8.Style = "font-size: 8.25pt"
            Me.Label8.Text = "Página:"
            Me.Label8.Top = 0!
            Me.Label8.Width = 0.5118113!
            '
            'TextBox1
            '
            Me.TextBox1.Height = 0.2!
            Me.TextBox1.Left = 6.061598!
            Me.TextBox1.Name = "TextBox1"
            Me.TextBox1.Style = "font-size: 8.25pt"
            Me.TextBox1.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
            Me.TextBox1.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount
            Me.TextBox1.Top = 0!
            Me.TextBox1.Width = 0.5113187!
            '
            'Label9
            '
            Me.Label9.Height = 0.2!
            Me.Label9.HyperLink = Nothing
            Me.Label9.Left = 6.612779!
            Me.Label9.Name = "Label9"
            Me.Label9.Style = "font-size: 8.25pt"
            Me.Label9.Text = "De:"
            Me.Label9.Top = 0!
            Me.Label9.Width = 0.3218507!
            '
            'TextBox2
            '
            Me.TextBox2.Height = 0.2!
            Me.TextBox2.Left = 6.971375!
            Me.TextBox2.Name = "TextBox2"
            Me.TextBox2.Style = "font-size: 8.25pt"
            Me.TextBox2.SummaryType = DataDynamics.ActiveReports.SummaryType.PageTotal
            Me.TextBox2.Top = 0!
            Me.TextBox2.Width = 0.4288058!
            '
            'ActiveReport1
            '
            Me.MasterReport = false
            Me.PageSettings.Margins.Bottom = 0.7875!
            Me.PageSettings.Margins.Left = 0.1965278!
            Me.PageSettings.Margins.Right = 0.1965278!
            Me.PageSettings.Margins.Top = 0.7875!
            Me.PageSettings.PaperHeight = 11!
            Me.PageSettings.PaperWidth = 8.5!
            Me.PrintWidth = 7.479167!
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
            CType(Me.txtFiltros,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFechaReporte,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtMes,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label10,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label6,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label3,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label11,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TxtSucursal,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtArticulos,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtTotal,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtTallas,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtColor,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtDescripcion,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtTotalNumero,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label12,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtSumTotal,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label7,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtSumTotalP,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label5,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label8,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox1,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label9,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox2,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        
	End Sub

#End Region

    Public dsExistencias As DataSet

    Public Sub CreateTable()

        dsExistencias = New DataSet("Existencias")
        Dim dtExistencias As New DataTable("Existencias")

        Dim dcArticulo As New DataColumn
        With dcArticulo
            .ColumnName = "Articulo"
            .Caption = "Articulos"
            .DataType = GetType(System.String)
            .DefaultValue = String.Empty
        End With

        Dim dcDescripcion As New DataColumn
        With dcDescripcion
            .ColumnName = "Descripcion"
            .Caption = "Descripcion"
            .DataType = GetType(System.String)
            .DefaultValue = String.Empty
        End With

        Dim dcTotal As New DataColumn
        With dcTotal
            .ColumnName = "Total"
            .Caption = "Total"
            .DataType = GetType(System.Int32)
        End With


        Dim dcTallas As New DataColumn
        With dcTallas
            .ColumnName = "Tallas"
            .Caption = "Tallas"
            .DataType = GetType(System.String)
        End With

        Dim dcTotalNumero As New DataColumn
        With dcTotalNumero
            .ColumnName = "TotalNum"
            .Caption = "T. Numero"
            .DataType = GetType(System.String)
        End With

        Dim dcColor As New DataColumn
        With dcColor
            .ColumnName = "Color"
            .Caption = "Color"
            .DataType = GetType(System.String)
        End With

        With dtExistencias.Columns
            .Add(dcArticulo)
            .Add(dcDescripcion)
            .Add(dcTotal)
            .Add(dcTallas)
            .Add(dcTotalNumero)
            .Add(dcColor)
        End With

        dsExistencias.Tables.Add(dtExistencias)
        dsExistencias.AcceptChanges()

    End Sub
End Class
