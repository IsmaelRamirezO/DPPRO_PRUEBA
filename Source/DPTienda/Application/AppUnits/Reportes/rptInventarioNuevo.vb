Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Imports DportenisPro.DPTienda.Reports.Inventario
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU

Public Class rptInventarioNuevo
    Inherits DataDynamics.ActiveReports.ActiveReport
    Dim oCatalogoAlmacenesMgr As New CatalogoAlmacenesManager(oAppContext)

    Public Sub New(ByVal oReporter As InventarioReport, ByVal strMes As String, ByVal strTipoReporte As String)
        MyBase.New()
        InitializeComponent()

        Try
            Dim dsExistencias As New DataSet

            dsExistencias = oReporter.FormatToReport.Copy

            Dim firstView As DataView = New DataView(dsExistencias.Tables("Existencias"))
            firstView.Sort = "CodCategoria ASC"


            Me.DataSource = firstView
            Me.DataMember = "Existencias"

            Me.txtArticulos.DataField = "Articulo"
            Me.txtColor.DataField = "Color"
            Me.txtTallas.DataField = "Tallas"
            Me.txtTotal.DataField = "Total"
            Me.txtTotalNumero.DataField = "TotalNum"
            Me.txtDescripcion.DataField = "Descripcion"
            Me.TxtCodigoAnterior.DataField = "CodigoAnterior"
            Me.TxtBxCodCategoria.DataField = "CodCategoria"
            Me.TxtBxNombreCat.DataField = "NombreCat"
            Me.txtCodMarca.DataField = "CodMarca"
            Me.txtFechaReporte.Text = Format(Date.Now, "dd - MMM - yyyy")
            Me.txtMes.Text = strMes
            Me.txtFiltro.Text = strTipoReporte


            Dim oAlmacen As Almacen
            Dim oSAPMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
            oAlmacen = oCatalogoAlmacenesMgr.Load(oSAPMgr.Read_Centros) 'oAppContext.ApplicationConfiguration.Almacen)

            TxtSucursal.Text = oAlmacen.ID & "    " & oAlmacen.Descripcion

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
    Private lblTitulo As Label = Nothing
    Private txtFechaReporte As TextBox = Nothing
    Private TxtSucursal As TextBox = Nothing
    Private TextBox6 As TextBox = Nothing
    Private txtMes As TextBox = Nothing
    Private txtFiltro As TextBox = Nothing
    Private Label7 As Label = Nothing
    Private Label8 As Label = Nothing
    Private Label17 As Label = Nothing
    Private Label9 As Label = Nothing
    Private Label10 As Label = Nothing
    Private TxtBxNombreCat As TextBox = Nothing
    Private TxtBxCodCategoria As TextBox = Nothing
    Private Line1 As Line = Nothing
    Private txtArticulos As TextBox = Nothing
    Private txtTotal As TextBox = Nothing
    Private txtTallas As TextBox = Nothing
    Private txtColor As TextBox = Nothing
    Private txtDescripcion As TextBox = Nothing
    Private txtTotalNumero As TextBox = Nothing
    Private TxtCodigoAnterior As TextBox = Nothing
    Private Label13 As Label = Nothing
    Private txtSumTotal As TextBox = Nothing
    Private Label16 As Label = Nothing
    Friend WithEvents txtCodMarca As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label1 As DataDynamics.ActiveReports.Label
    Private WithEvents Line2 As DataDynamics.ActiveReports.Line
    Private WithEvents Line3 As DataDynamics.ActiveReports.Line
    Private WithEvents Line4 As DataDynamics.ActiveReports.Line
    Private WithEvents lblDesc As DataDynamics.ActiveReports.Label
    Friend WithEvents lbl_separar As DataDynamics.ActiveReports.Label
    Friend WithEvents txtTotalHojas As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label3 As DataDynamics.ActiveReports.Label
    Private WithEvents rptInfopaginas As DataDynamics.ActiveReports.ReportInfo
    Friend WithEvents TextBox2 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label2 As DataDynamics.ActiveReports.Label
    Private TextBox4 As TextBox = Nothing
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptInventarioNuevo))
        Me.Detail = New DataDynamics.ActiveReports.Detail()
        Me.txtArticulos = New DataDynamics.ActiveReports.TextBox()
        Me.txtTotal = New DataDynamics.ActiveReports.TextBox()
        Me.txtTallas = New DataDynamics.ActiveReports.TextBox()
        Me.txtColor = New DataDynamics.ActiveReports.TextBox()
        Me.txtDescripcion = New DataDynamics.ActiveReports.TextBox()
        Me.txtTotalNumero = New DataDynamics.ActiveReports.TextBox()
        Me.TxtCodigoAnterior = New DataDynamics.ActiveReports.TextBox()
        Me.txtCodMarca = New DataDynamics.ActiveReports.TextBox()
        Me.Line3 = New DataDynamics.ActiveReports.Line()
        Me.Line4 = New DataDynamics.ActiveReports.Line()
        Me.ReportHeader = New DataDynamics.ActiveReports.ReportHeader()
        Me.Shape1 = New DataDynamics.ActiveReports.Shape()
        Me.lblTitulo = New DataDynamics.ActiveReports.Label()
        Me.txtFechaReporte = New DataDynamics.ActiveReports.TextBox()
        Me.TxtSucursal = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox6 = New DataDynamics.ActiveReports.TextBox()
        Me.txtMes = New DataDynamics.ActiveReports.TextBox()
        Me.txtFiltro = New DataDynamics.ActiveReports.TextBox()
        Me.ReportFooter = New DataDynamics.ActiveReports.ReportFooter()
        Me.PageHeader = New DataDynamics.ActiveReports.PageHeader()
        Me.Label7 = New DataDynamics.ActiveReports.Label()
        Me.Label8 = New DataDynamics.ActiveReports.Label()
        Me.Label17 = New DataDynamics.ActiveReports.Label()
        Me.Label9 = New DataDynamics.ActiveReports.Label()
        Me.Label10 = New DataDynamics.ActiveReports.Label()
        Me.Label1 = New DataDynamics.ActiveReports.Label()
        Me.Line2 = New DataDynamics.ActiveReports.Line()
        Me.lblDesc = New DataDynamics.ActiveReports.Label()
        Me.PageFooter = New DataDynamics.ActiveReports.PageFooter()
        Me.Label13 = New DataDynamics.ActiveReports.Label()
        Me.txtSumTotal = New DataDynamics.ActiveReports.TextBox()
        Me.Label16 = New DataDynamics.ActiveReports.Label()
        Me.TextBox4 = New DataDynamics.ActiveReports.TextBox()
        Me.lbl_separar = New DataDynamics.ActiveReports.Label()
        Me.txtTotalHojas = New DataDynamics.ActiveReports.TextBox()
        Me.Label3 = New DataDynamics.ActiveReports.Label()
        Me.rptInfopaginas = New DataDynamics.ActiveReports.ReportInfo()
        Me.TextBox2 = New DataDynamics.ActiveReports.TextBox()
        Me.Label2 = New DataDynamics.ActiveReports.Label()
        Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader()
        Me.TxtBxNombreCat = New DataDynamics.ActiveReports.TextBox()
        Me.TxtBxCodCategoria = New DataDynamics.ActiveReports.TextBox()
        Me.Line1 = New DataDynamics.ActiveReports.Line()
        Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter()
        CType(Me.txtArticulos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTallas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtColor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDescripcion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalNumero, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtCodigoAnterior, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCodMarca, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaReporte, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtSucursal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFiltro, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblDesc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSumTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lbl_separar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalHojas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rptInfopaginas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtBxNombreCat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtBxCodCategoria, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.ColumnSpacing = 0.0!
        Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtArticulos, Me.txtTotal, Me.txtTallas, Me.txtColor, Me.txtDescripcion, Me.txtTotalNumero, Me.TxtCodigoAnterior, Me.txtCodMarca, Me.Line3, Me.Line4})
        Me.Detail.Height = 0.4768611!
        Me.Detail.Name = "Detail"
        '
        'txtArticulos
        '
        Me.txtArticulos.Height = 0.194!
        Me.txtArticulos.Left = 0.1018701!
        Me.txtArticulos.Name = "txtArticulos"
        Me.txtArticulos.Style = "ddo-char-set: 0; font-size: 6pt"
        Me.txtArticulos.Text = "txtArticulos"
        Me.txtArticulos.Top = 0.0!
        Me.txtArticulos.Width = 1.34013!
        '
        'txtTotal
        '
        Me.txtTotal.Height = 0.194!
        Me.txtTotal.Left = 1.632!
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.OutputFormat = resources.GetString("txtTotal.OutputFormat")
        Me.txtTotal.Style = "ddo-char-set: 0; text-align: right; font-size: 6pt"
        Me.txtTotal.Text = "txtTotal"
        Me.txtTotal.Top = 0.268!
        Me.txtTotal.Width = 0.5300002!
        '
        'txtTallas
        '
        Me.txtTallas.Height = 0.204!
        Me.txtTallas.Left = 2.262!
        Me.txtTallas.Name = "txtTallas"
        Me.txtTallas.Style = "font-size: 6.75pt; font-family: Courier New; text-decoration: underline"
        Me.txtTallas.Text = "txtTallas"
        Me.txtTallas.Top = 0.0!
        Me.txtTallas.Width = 5.415!
        '
        'txtColor
        '
        Me.txtColor.Height = 0.194!
        Me.txtColor.Left = 0.098!
        Me.txtColor.Name = "txtColor"
        Me.txtColor.Style = "ddo-char-set: 0; text-align: left; font-size: 6pt"
        Me.txtColor.Text = "txtColor"
        Me.txtColor.Top = 0.144!
        Me.txtColor.Width = 1.534!
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Height = 0.1880788!
        Me.txtDescripcion.Left = 0.067!
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Style = "ddo-char-set: 0; font-size: 6pt"
        Me.txtDescripcion.Text = "TextBox1"
        Me.txtDescripcion.Top = 0.268!
        Me.txtDescripcion.Width = 1.565!
        '
        'txtTotalNumero
        '
        Me.txtTotalNumero.Height = 0.204!
        Me.txtTotalNumero.Left = 2.262!
        Me.txtTotalNumero.Name = "txtTotalNumero"
        Me.txtTotalNumero.Style = "font-size: 6.75pt; font-family: Courier New; text-decoration: underline"
        Me.txtTotalNumero.Text = "TextBox4"
        Me.txtTotalNumero.Top = 0.228!
        Me.txtTotalNumero.Width = 5.415!
        '
        'TxtCodigoAnterior
        '
        Me.TxtCodigoAnterior.Height = 0.194!
        Me.TxtCodigoAnterior.Left = 1.442!
        Me.TxtCodigoAnterior.Name = "TxtCodigoAnterior"
        Me.TxtCodigoAnterior.Style = "font-size: 6pt; text-align: right"
        Me.TxtCodigoAnterior.Text = "TxtCodigoAnterior"
        Me.TxtCodigoAnterior.Top = 0.0!
        Me.TxtCodigoAnterior.Width = 0.7200003!
        '
        'txtCodMarca
        '
        Me.txtCodMarca.Height = 0.194!
        Me.txtCodMarca.Left = 1.642!
        Me.txtCodMarca.Name = "txtCodMarca"
        Me.txtCodMarca.Style = "ddo-char-set: 0; text-align: right; font-size: 6pt"
        Me.txtCodMarca.Text = "txtMarca"
        Me.txtCodMarca.Top = 0.124!
        Me.txtCodMarca.Width = 0.5259999!
        '
        'Line3
        '
        Me.Line3.Height = 0.0005000234!
        Me.Line3.Left = 0.094!
        Me.Line3.LineWeight = 1.0!
        Me.Line3.Name = "Line3"
        Me.Line3.Top = 0.457!
        Me.Line3.Width = 7.46725!
        Me.Line3.X1 = 0.094!
        Me.Line3.X2 = 7.56125!
        Me.Line3.Y1 = 0.457!
        Me.Line3.Y2 = 0.4575!
        '
        'Line4
        '
        Me.Line4.Height = 0.39!
        Me.Line4.Left = 2.205!
        Me.Line4.LineWeight = 1.0!
        Me.Line4.Name = "Line4"
        Me.Line4.Top = 0.04!
        Me.Line4.Width = 0.0!
        Me.Line4.X1 = 2.205!
        Me.Line4.X2 = 2.205!
        Me.Line4.Y1 = 0.04!
        Me.Line4.Y2 = 0.43!
        '
        'ReportHeader
        '
        Me.ReportHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape1, Me.lblTitulo, Me.txtFechaReporte, Me.TxtSucursal, Me.TextBox6, Me.txtMes, Me.txtFiltro})
        Me.ReportHeader.Height = 0.7291667!
        Me.ReportHeader.Name = "ReportHeader"
        '
        'Shape1
        '
        Me.Shape1.Height = 0.7217847!
        Me.Shape1.Left = 0.0!
        Me.Shape1.LineWeight = 2.0!
        Me.Shape1.Name = "Shape1"
        Me.Shape1.RoundingRadius = 9.999999!
        Me.Shape1.Top = 0.0!
        Me.Shape1.Width = 7.414701!
        '
        'lblTitulo
        '
        Me.lblTitulo.Height = 0.2!
        Me.lblTitulo.HyperLink = Nothing
        Me.lblTitulo.Left = 1.1875!
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Style = "ddo-char-set: 0; text-align: center; font-weight: normal; font-size: 8.25pt; font" & _
    "-family: Arial; vertical-align: middle"
        Me.lblTitulo.Text = "REPORTE DE EXISTENCIAS:"
        Me.lblTitulo.Top = 0.0!
        Me.lblTitulo.Width = 5.111712!
        '
        'txtFechaReporte
        '
        Me.txtFechaReporte.Height = 0.2!
        Me.txtFechaReporte.Left = 0.1230315!
        Me.txtFechaReporte.Name = "txtFechaReporte"
        Me.txtFechaReporte.Style = "ddo-char-set: 0; font-weight: normal; font-size: 8.25pt; font-family: Arial; vert" & _
    "ical-align: middle"
        Me.txtFechaReporte.Text = "txtFecha"
        Me.txtFechaReporte.Top = 0.02460632!
        Me.txtFechaReporte.Width = 1.0!
        '
        'TxtSucursal
        '
        Me.TxtSucursal.Height = 0.1968504!
        Me.TxtSucursal.Left = 1.574803!
        Me.TxtSucursal.Name = "TxtSucursal"
        Me.TxtSucursal.Style = "ddo-char-set: 1; text-align: center; font-size: 8pt; vertical-align: middle"
        Me.TxtSucursal.Text = "TxtSucursal"
        Me.TxtSucursal.Top = 0.1968504!
        Me.TxtSucursal.Width = 3.424377!
        '
        'TextBox6
        '
        Me.TextBox6.Height = 0.2!
        Me.TextBox6.Left = 5.123032!
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Style = "ddo-char-set: 1; font-weight: normal; font-size: 8pt; vertical-align: middle"
        Me.TextBox6.Text = "MES :"
        Me.TextBox6.Top = 0.2121064!
        Me.TextBox6.Width = 0.375!
        '
        'txtMes
        '
        Me.txtMes.Height = 0.2!
        Me.txtMes.Left = 5.498032!
        Me.txtMes.Name = "txtMes"
        Me.txtMes.Style = "ddo-char-set: 0; text-align: left; font-weight: normal; font-size: 8.25pt; font-f" & _
    "amily: Arial; vertical-align: middle"
        Me.txtMes.Text = "txtMes"
        Me.txtMes.Top = 0.2121064!
        Me.txtMes.Width = 0.9375!
        '
        'txtFiltro
        '
        Me.txtFiltro.Height = 0.1968504!
        Me.txtFiltro.Left = 0.1312336!
        Me.txtFiltro.Name = "txtFiltro"
        Me.txtFiltro.Style = "ddo-char-set: 1; text-align: center; font-size: 8pt; vertical-align: middle"
        Me.txtFiltro.Text = Nothing
        Me.txtFiltro.Top = 0.4468504!
        Me.txtFiltro.Width = 7.217847!
        '
        'ReportFooter
        '
        Me.ReportFooter.Height = 0.01041667!
        Me.ReportFooter.Name = "ReportFooter"
        '
        'PageHeader
        '
        Me.PageHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label7, Me.Label8, Me.Label17, Me.Label9, Me.Label10, Me.Label1, Me.Line2, Me.lblDesc})
        Me.PageHeader.Height = 0.4395505!
        Me.PageHeader.Name = "PageHeader"
        '
        'Label7
        '
        Me.Label7.Height = 0.1312336!
        Me.Label7.HyperLink = Nothing
        Me.Label7.Left = 0.05!
        Me.Label7.Name = "Label7"
        Me.Label7.Style = "ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8.25pt"
        Me.Label7.Text = "Cod. Proveedor" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.Label7.Top = 0.0!
        Me.Label7.Width = 1.039!
        '
        'Label8
        '
        Me.Label8.Height = 0.1312336!
        Me.Label8.HyperLink = Nothing
        Me.Label8.Left = 0.039!
        Me.Label8.Name = "Label8"
        Me.Label8.Style = "ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8.25pt"
        Me.Label8.Text = "Color" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.Label8.Top = 0.112!
        Me.Label8.Width = 0.4030001!
        '
        'Label17
        '
        Me.Label17.Height = 0.1312336!
        Me.Label17.HyperLink = Nothing
        Me.Label17.Left = 1.642!
        Me.Label17.Name = "Label17"
        Me.Label17.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 8.25pt"
        Me.Label17.Text = "Artículo" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.Label17.Top = 0.003!
        Me.Label17.Width = 0.529!
        '
        'Label9
        '
        Me.Label9.Height = 0.1312336!
        Me.Label9.HyperLink = Nothing
        Me.Label9.Left = 1.69!
        Me.Label9.Name = "Label9"
        Me.Label9.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 8.25pt"
        Me.Label9.Text = "Total" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.Label9.Top = 0.26!
        Me.Label9.Width = 0.4724407!
        '
        'Label10
        '
        Me.Label10.Height = 0.1299212!
        Me.Label10.HyperLink = Nothing
        Me.Label10.Left = 2.262!
        Me.Label10.Name = "Label10"
        Me.Label10.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt"
        Me.Label10.Text = "Tallas/Existencias" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.Label10.Top = 0.003!
        Me.Label10.Width = 5.087386!
        '
        'Label1
        '
        Me.Label1.Height = 0.1312336!
        Me.Label1.HyperLink = Nothing
        Me.Label1.Left = 1.765!
        Me.Label1.Name = "Label1"
        Me.Label1.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 8.25pt"
        Me.Label1.Text = "Marca" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.Label1.Top = 0.131!
        Me.Label1.Width = 0.397!
        '
        'Line2
        '
        Me.Line2.Height = 0.000166595!
        Me.Line2.Left = 0.042!
        Me.Line2.LineWeight = 1.0!
        Me.Line2.Name = "Line2"
        Me.Line2.Top = 0.4208334!
        Me.Line2.Width = 7.519334!
        Me.Line2.X1 = 0.042!
        Me.Line2.X2 = 7.561334!
        Me.Line2.Y1 = 0.421!
        Me.Line2.Y2 = 0.4208334!
        '
        'lblDesc
        '
        Me.lblDesc.Height = 0.177!
        Me.lblDesc.HyperLink = Nothing
        Me.lblDesc.Left = 0.043!
        Me.lblDesc.Name = "lblDesc"
        Me.lblDesc.Style = "font-weight: bold; font-size: 8.25pt"
        Me.lblDesc.Text = "Descripción"
        Me.lblDesc.Top = 0.243!
        Me.lblDesc.Width = 1.0!
        '
        'PageFooter
        '
        Me.PageFooter.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label13, Me.txtSumTotal, Me.Label16, Me.TextBox4, Me.lbl_separar, Me.txtTotalHojas, Me.Label3, Me.rptInfopaginas, Me.TextBox2, Me.Label2})
        Me.PageFooter.Height = 0.162!
        Me.PageFooter.Name = "PageFooter"
        '
        'Label13
        '
        Me.Label13.Height = 0.1312336!
        Me.Label13.HyperLink = Nothing
        Me.Label13.Left = 0.03937007!
        Me.Label13.Name = "Label13"
        Me.Label13.Style = "font-size: 8.25pt"
        Me.Label13.Text = "Total Articulos-->"
        Me.Label13.Top = 0.0!
        Me.Label13.Width = 1.0!
        '
        'txtSumTotal
        '
        Me.txtSumTotal.DataField = "Total"
        Me.txtSumTotal.Height = 0.1312336!
        Me.txtSumTotal.Left = 4.915!
        Me.txtSumTotal.Name = "txtSumTotal"
        Me.txtSumTotal.OutputFormat = resources.GetString("txtSumTotal.OutputFormat")
        Me.txtSumTotal.Style = "text-align: left; font-size: 8.25pt"
        Me.txtSumTotal.SummaryGroup = "GroupHeader1"
        Me.txtSumTotal.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
        Me.txtSumTotal.SummaryType = DataDynamics.ActiveReports.SummaryType.PageTotal
        Me.txtSumTotal.Text = "TextBox1"
        Me.txtSumTotal.Top = 0.005!
        Me.txtSumTotal.Width = 0.7578743!
        '
        'Label16
        '
        Me.Label16.Height = 0.1312336!
        Me.Label16.HyperLink = Nothing
        Me.Label16.Left = 6.482!
        Me.Label16.Name = "Label16"
        Me.Label16.Style = "ddo-char-set: 0; font-weight: bold; font-size: 6.75pt"
        Me.Label16.Text = "Pág.:"
        Me.Label16.Top = 0.0!
        Me.Label16.Visible = False
        Me.Label16.Width = 0.3543305!
        '
        'TextBox4
        '
        Me.TextBox4.Height = 0.1312336!
        Me.TextBox4.Left = 6.836!
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Style = "ddo-char-set: 1; font-size: 8pt; text-align: right"
        Me.TextBox4.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
        Me.TextBox4.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount
        Me.TextBox4.Text = Nothing
        Me.TextBox4.Top = 0.0!
        Me.TextBox4.Visible = False
        Me.TextBox4.Width = 0.3330002!
        '
        'lbl_separar
        '
        Me.lbl_separar.Height = 0.1312336!
        Me.lbl_separar.HyperLink = Nothing
        Me.lbl_separar.Left = 7.179!
        Me.lbl_separar.Name = "lbl_separar"
        Me.lbl_separar.Style = "ddo-char-set: 1; font-weight: bold; font-size: 8pt"
        Me.lbl_separar.Text = "/"
        Me.lbl_separar.Top = 0.0!
        Me.lbl_separar.Visible = False
        Me.lbl_separar.Width = 0.07299989!
        '
        'txtTotalHojas
        '
        Me.txtTotalHojas.Height = 0.1312336!
        Me.txtTotalHojas.Left = 7.349!
        Me.txtTotalHojas.Name = "txtTotalHojas"
        Me.txtTotalHojas.Style = "ddo-char-set: 1; font-size: 8pt; text-align: left"
        Me.txtTotalHojas.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
        Me.txtTotalHojas.SummaryType = DataDynamics.ActiveReports.SummaryType.PageTotal
        Me.txtTotalHojas.Text = Nothing
        Me.txtTotalHojas.Top = 0.0!
        Me.txtTotalHojas.Visible = False
        Me.txtTotalHojas.Width = 0.3120003!
        '
        'Label3
        '
        Me.Label3.Height = 0.1312336!
        Me.Label3.HyperLink = Nothing
        Me.Label3.Left = 3.946!
        Me.Label3.Name = "Label3"
        Me.Label3.Style = "font-size: 8.25pt; text-align: right"
        Me.Label3.Text = "Total acumulado:"
        Me.Label3.Top = 0.005!
        Me.Label3.Width = 0.9380002!
        '
        'rptInfopaginas
        '
        Me.rptInfopaginas.FormatString = "Pág.: {PageNumber} / {PageCount}"
        Me.rptInfopaginas.Height = 0.157!
        Me.rptInfopaginas.Left = 6.486001!
        Me.rptInfopaginas.Name = "rptInfopaginas"
        Me.rptInfopaginas.Style = "font-size: 8.25pt"
        Me.rptInfopaginas.Top = 0.005!
        Me.rptInfopaginas.Width = 1.191!
        '
        'TextBox2
        '
        Me.TextBox2.DataField = "Total"
        Me.TextBox2.Height = 0.1312336!
        Me.TextBox2.Left = 2.684!
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.OutputFormat = resources.GetString("TextBox2.OutputFormat")
        Me.TextBox2.Style = "text-align: left; font-size: 8.25pt"
        Me.TextBox2.SummaryGroup = "GroupHeader1"
        Me.TextBox2.SummaryType = DataDynamics.ActiveReports.SummaryType.PageTotal
        Me.TextBox2.Text = "TextBox1"
        Me.TextBox2.Top = 0.0!
        Me.TextBox2.Width = 0.7578743!
        '
        'Label2
        '
        Me.Label2.Height = 0.162!
        Me.Label2.HyperLink = Nothing
        Me.Label2.Left = 1.716!
        Me.Label2.Name = "Label2"
        Me.Label2.Style = "font-size: 8.25pt; text-align: right"
        Me.Label2.Text = "Total por hoja:"
        Me.Label2.Top = 0.0!
        Me.Label2.Width = 0.938!
        '
        'GroupHeader1
        '
        Me.GroupHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TxtBxNombreCat, Me.TxtBxCodCategoria, Me.Line1})
        Me.GroupHeader1.DataField = "CodCategoria"
        Me.GroupHeader1.Height = 0.2702303!
        Me.GroupHeader1.Name = "GroupHeader1"
        '
        'TxtBxNombreCat
        '
        Me.TxtBxNombreCat.DataField = "NombreCat"
        Me.TxtBxNombreCat.Height = 0.21!
        Me.TxtBxNombreCat.Left = 1.181!
        Me.TxtBxNombreCat.Name = "TxtBxNombreCat"
        Me.TxtBxNombreCat.Style = "font-style: italic; font-size: 9.75pt"
        Me.TxtBxNombreCat.Text = "NombreCat"
        Me.TxtBxNombreCat.Top = 0.06!
        Me.TxtBxNombreCat.Width = 6.220472!
        '
        'TxtBxCodCategoria
        '
        Me.TxtBxCodCategoria.DataField = "CodCategoria"
        Me.TxtBxCodCategoria.Height = 0.189!
        Me.TxtBxCodCategoria.Left = 0.257!
        Me.TxtBxCodCategoria.Name = "TxtBxCodCategoria"
        Me.TxtBxCodCategoria.Style = "font-size: 9.75pt"
        Me.TxtBxCodCategoria.Text = "CodCatgeroria"
        Me.TxtBxCodCategoria.Top = 0.019!
        Me.TxtBxCodCategoria.Width = 0.8661417!
        '
        'Line1
        '
        Me.Line1.Height = 0.0!
        Me.Line1.Left = 0.164904!
        Me.Line1.LineWeight = 1.0!
        Me.Line1.Name = "Line1"
        Me.Line1.Top = 0.064!
        Me.Line1.Width = 7.244096!
        Me.Line1.X1 = 7.409!
        Me.Line1.X2 = 0.164904!
        Me.Line1.Y1 = 0.064!
        Me.Line1.Y2 = 0.064!
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Height = 0.0!
        Me.GroupFooter1.Name = "GroupFooter1"
        '
        'rptInventarioNuevo
        '
        Me.MasterReport = False
        Me.PageSettings.Margins.Bottom = 0.39375!
        Me.PageSettings.Margins.Left = 0.39375!
        Me.PageSettings.Margins.Right = 0.39375!
        Me.PageSettings.Margins.Top = 0.39375!
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 7.65!
        Me.Sections.Add(Me.ReportHeader)
        Me.Sections.Add(Me.PageHeader)
        Me.Sections.Add(Me.GroupHeader1)
        Me.Sections.Add(Me.Detail)
        Me.Sections.Add(Me.GroupFooter1)
        Me.Sections.Add(Me.PageFooter)
        Me.Sections.Add(Me.ReportFooter)
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" & _
            "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei" & _
            "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" & _
            "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit", "Heading3", "Normal"))
        CType(Me.txtArticulos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTallas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtColor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDescripcion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalNumero, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtCodigoAnterior, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCodMarca, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaReporte, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtSucursal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFiltro, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblDesc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSumTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lbl_separar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalHojas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rptInfopaginas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtBxNombreCat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtBxCodCategoria, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

#End Region

    Private Sub Detail_BeforePrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles Detail.BeforePrint
        'Me.txtColor.Text = oCatalogoAlmacenesMgr.SeleccionaColor(Mid(Me.txtArticulos.Text, 11, 1)) 'oResultado.Color  ' SF EAHM 13 06 2016
    End Sub


    Private Sub GroupHeader1_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupHeader1.Format

    End Sub
End Class
