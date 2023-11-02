Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU

Public Class rptDescuentosSAP
    Inherits DataDynamics.ActiveReports.ActiveReport
    Dim strSucursal As String

    Public Sub New(ByVal dsArticulos As DataSet)
        MyBase.New()
        InitializeComponent()



        Me.LblFecha.Text = Format(Date.Now, "Long Date")

        Dim oAlmacen As Almacen
        Dim oAlmacenesMgr As New CatalogoAlmacenesManager(oAppContext)
        Dim oSAPMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        oAlmacen = oAlmacenesMgr.Load(oSAPMgr.Read_Centros) 'oAppContext.ApplicationConfiguration.Almacen)

        If Not oAlmacen Is Nothing Then

            Me.LblTitulo.Text = Me.LblTitulo.Text & " " & oAlmacen.ID & " " & oAlmacen.Descripcion

        Else

            Me.LblTitulo.Text = Me.LblTitulo.Text & " " & oAppContext.ApplicationConfiguration.Almacen

        End If



        Dim firstView As DataView = New DataView(dsArticulos.Tables(0))
        firstView.Sort = "Descuento ASC"

        Me.DataSource = firstView
        Me.DataMember = dsArticulos.Tables(0).TableName
    End Sub


#Region "ActiveReports Designer generated code"
    Private WithEvents PageHeader As PageHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents PageFooter As PageFooter = Nothing
	Private LblTitulo As Label = Nothing
	Private LblFecha As Label = Nothing
	Private Label2 As Label = Nothing
	Private Label3 As Label = Nothing
	Private Label4 As Label = Nothing
	Private Label5 As Label = Nothing
	Private Label6 As Label = Nothing
	Private Line1 As Line = Nothing
	Private Line2 As Line = Nothing
	Private Line3 As Line = Nothing
	Private Line4 As Line = Nothing
	Private Line5 As Line = Nothing
	Private Line7 As Line = Nothing
	Private Line8 As Line = Nothing
	Private Line9 As Line = Nothing
	Private Line10 As Line = Nothing
	Private TxtBxMaterial As TextBox = Nothing
	Private TxtBxDescr As TextBox = Nothing
	Private TxtBxPrecioNormal As TextBox = Nothing
	Private TxtBxDescuento As TextBox = Nothing
	Private TxtBxPrecioOferta As TextBox = Nothing
	Private Line6 As Line = Nothing
	Private txtNumPag As TextBox = Nothing
	Private lblPag As Label = Nothing
	Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptDescuentosSAP))
            Me.Detail = New DataDynamics.ActiveReports.Detail()
            Me.PageHeader = New DataDynamics.ActiveReports.PageHeader()
            Me.PageFooter = New DataDynamics.ActiveReports.PageFooter()
            Me.LblTitulo = New DataDynamics.ActiveReports.Label()
            Me.LblFecha = New DataDynamics.ActiveReports.Label()
            Me.Label2 = New DataDynamics.ActiveReports.Label()
            Me.Label3 = New DataDynamics.ActiveReports.Label()
            Me.Label4 = New DataDynamics.ActiveReports.Label()
            Me.Label5 = New DataDynamics.ActiveReports.Label()
            Me.Label6 = New DataDynamics.ActiveReports.Label()
            Me.Line1 = New DataDynamics.ActiveReports.Line()
            Me.Line2 = New DataDynamics.ActiveReports.Line()
            Me.Line3 = New DataDynamics.ActiveReports.Line()
            Me.Line4 = New DataDynamics.ActiveReports.Line()
            Me.Line5 = New DataDynamics.ActiveReports.Line()
            Me.Line7 = New DataDynamics.ActiveReports.Line()
            Me.Line8 = New DataDynamics.ActiveReports.Line()
            Me.Line9 = New DataDynamics.ActiveReports.Line()
            Me.Line10 = New DataDynamics.ActiveReports.Line()
            Me.TxtBxMaterial = New DataDynamics.ActiveReports.TextBox()
            Me.TxtBxDescr = New DataDynamics.ActiveReports.TextBox()
            Me.TxtBxPrecioNormal = New DataDynamics.ActiveReports.TextBox()
            Me.TxtBxDescuento = New DataDynamics.ActiveReports.TextBox()
            Me.TxtBxPrecioOferta = New DataDynamics.ActiveReports.TextBox()
            Me.Line6 = New DataDynamics.ActiveReports.Line()
            Me.txtNumPag = New DataDynamics.ActiveReports.TextBox()
            Me.lblPag = New DataDynamics.ActiveReports.Label()
            CType(Me.LblTitulo,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.LblFecha,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label3,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label5,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label6,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TxtBxMaterial,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TxtBxDescr,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TxtBxPrecioNormal,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TxtBxDescuento,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TxtBxPrecioOferta,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtNumPag,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblPag,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
            '
            'Detail
            '
            Me.Detail.ColumnSpacing = 0!
            Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TxtBxMaterial, Me.TxtBxDescr, Me.TxtBxPrecioNormal, Me.TxtBxDescuento, Me.TxtBxPrecioOferta})
            Me.Detail.Height = 0.1875!
            Me.Detail.Name = "Detail"
            '
            'PageHeader
            '
            Me.PageHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.LblTitulo, Me.LblFecha, Me.Label2, Me.Label3, Me.Label4, Me.Label5, Me.Label6, Me.Line1, Me.Line2, Me.Line3, Me.Line4, Me.Line5, Me.Line7, Me.Line8, Me.Line9, Me.Line10})
            Me.PageHeader.Height = 0.8541667!
            Me.PageHeader.Name = "PageHeader"
            '
            'PageFooter
            '
            Me.PageFooter.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Line6, Me.txtNumPag, Me.lblPag})
            Me.PageFooter.Height = 0.1666667!
            Me.PageFooter.Name = "PageFooter"
            '
            'LblTitulo
            '
            Me.LblTitulo.Height = 0.25!
            Me.LblTitulo.HyperLink = Nothing
            Me.LblTitulo.Left = 0.0615771!
            Me.LblTitulo.Name = "LblTitulo"
            Me.LblTitulo.Style = "text-align: center; font-size: 15.75pt"
            Me.LblTitulo.Text = "Reporte de Desctos. Sucursal: "
            Me.LblTitulo.Top = 0.07874014!
            Me.LblTitulo.Width = 6.637263!
            '
            'LblFecha
            '
            Me.LblFecha.Height = 0.1875!
            Me.LblFecha.HyperLink = Nothing
            Me.LblFecha.Left = 0.05565119!
            Me.LblFecha.Name = "LblFecha"
            Me.LblFecha.Style = "text-align: center"
            Me.LblFecha.Text = "Fecha"
            Me.LblFecha.Top = 0.375!
            Me.LblFecha.Width = 6.637263!
            '
            'Label2
            '
            Me.Label2.Height = 0.1875!
            Me.Label2.HyperLink = Nothing
            Me.Label2.Left = 0.05565119!
            Me.Label2.Name = "Label2"
            Me.Label2.Style = "font-size: 9pt"
            Me.Label2.Text = "Codigo"
            Me.Label2.Top = 0.625!
            Me.Label2.Width = 0.882382!
            '
            'Label3
            '
            Me.Label3.Height = 0.1875!
            Me.Label3.HyperLink = Nothing
            Me.Label3.Left = 1.259842!
            Me.Label3.Name = "Label3"
            Me.Label3.Style = "font-size: 9pt"
            Me.Label3.Text = "Descripción"
            Me.Label3.Top = 0.625!
            Me.Label3.Width = 2.834646!
            '
            'Label4
            '
            Me.Label4.Height = 0.1875!
            Me.Label4.HyperLink = Nothing
            Me.Label4.Left = 4.173229!
            Me.Label4.Name = "Label4"
            Me.Label4.Style = "text-align: right; font-size: 9pt"
            Me.Label4.Text = "Precio Normal"
            Me.Label4.Top = 0.6299213!
            Me.Label4.Width = 0.8661417!
            '
            'Label5
            '
            Me.Label5.Height = 0.1875!
            Me.Label5.HyperLink = Nothing
            Me.Label5.Left = 5.118111!
            Me.Label5.Name = "Label5"
            Me.Label5.Style = "text-align: right; font-size: 9pt"
            Me.Label5.Text = "Descuento"
            Me.Label5.Top = 0.6299213!
            Me.Label5.Width = 0.75!
            '
            'Label6
            '
            Me.Label6.Height = 0.1875!
            Me.Label6.HyperLink = Nothing
            Me.Label6.Left = 5.905513!
            Me.Label6.Name = "Label6"
            Me.Label6.Style = "text-align: right; font-size: 9pt"
            Me.Label6.Text = "Precio Oferta"
            Me.Label6.Top = 0.6299213!
            Me.Label6.Width = 0.7874014!
            '
            'Line1
            '
            Me.Line1.Height = 0.7874014!
            Me.Line1.Left = 6.699858!
            Me.Line1.LineWeight = 1!
            Me.Line1.Name = "Line1"
            Me.Line1.Top = 0.006944451!
            Me.Line1.Width = 0!
            Me.Line1.X1 = 6.699858!
            Me.Line1.X2 = 6.699858!
            Me.Line1.Y1 = 0.006944451!
            Me.Line1.Y2 = 0.7943459!
            '
            'Line2
            '
            Me.Line2.Height = 0.004921436!
            Me.Line2.Left = 0.006944451!
            Me.Line2.LineWeight = 1!
            Me.Line2.Name = "Line2"
            Me.Line2.Top = 0.7874014!
            Me.Line2.Width = 6.685969!
            Me.Line2.X1 = 6.692914!
            Me.Line2.X2 = 0.006944451!
            Me.Line2.Y1 = 0.7874014!
            Me.Line2.Y2 = 0.7923229!
            '
            'Line3
            '
            Me.Line3.Height = 0!
            Me.Line3.Left = 5.866598E-09!
            Me.Line3.LineWeight = 1!
            Me.Line3.Name = "Line3"
            Me.Line3.Top = 0!
            Me.Line3.Width = 6.692914!
            Me.Line3.X1 = 6.692914!
            Me.Line3.X2 = 5.866598E-09!
            Me.Line3.Y1 = 0!
            Me.Line3.Y2 = 0!
            '
            'Line4
            '
            Me.Line4.Height = 0.7874014!
            Me.Line4.Left = 0.006944444!
            Me.Line4.LineWeight = 1!
            Me.Line4.Name = "Line4"
            Me.Line4.Top = 0.006944451!
            Me.Line4.Width = 0!
            Me.Line4.X1 = 0.006944444!
            Me.Line4.X2 = 0.006944444!
            Me.Line4.Y1 = 0.006944451!
            Me.Line4.Y2 = 0.7943459!
            '
            'Line5
            '
            Me.Line5.Height = 0!
            Me.Line5.Left = 0!
            Me.Line5.LineWeight = 1!
            Me.Line5.Name = "Line5"
            Me.Line5.Top = 0.551181!
            Me.Line5.Width = 6.692914!
            Me.Line5.X1 = 6.692914!
            Me.Line5.X2 = 0!
            Me.Line5.Y1 = 0.551181!
            Me.Line5.Y2 = 0.551181!
            '
            'Line7
            '
            Me.Line7.Height = 0.2362204!
            Me.Line7.Left = 4.101433!
            Me.Line7.LineWeight = 1!
            Me.Line7.Name = "Line7"
            Me.Line7.Top = 0.5581255!
            Me.Line7.Width = 0!
            Me.Line7.X1 = 4.101433!
            Me.Line7.X2 = 4.101433!
            Me.Line7.Y1 = 0.5581255!
            Me.Line7.Y2 = 0.7943459!
            '
            'Line8
            '
            Me.Line8.Height = 0.2362204!
            Me.Line8.Left = 5.125055!
            Me.Line8.LineWeight = 1!
            Me.Line8.Name = "Line8"
            Me.Line8.Top = 0.5581255!
            Me.Line8.Width = 0!
            Me.Line8.X1 = 5.125055!
            Me.Line8.X2 = 5.125055!
            Me.Line8.Y1 = 0.5581255!
            Me.Line8.Y2 = 0.7943459!
            '
            'Line9
            '
            Me.Line9.Height = 0.2362204!
            Me.Line9.Left = 5.912457!
            Me.Line9.LineWeight = 1!
            Me.Line9.Name = "Line9"
            Me.Line9.Top = 0.5581255!
            Me.Line9.Width = 0!
            Me.Line9.X1 = 5.912457!
            Me.Line9.X2 = 5.912457!
            Me.Line9.Y1 = 0.5581255!
            Me.Line9.Y2 = 0.7943459!
            '
            'Line10
            '
            Me.Line10.Height = 0.2362204!
            Me.Line10.Left = 1.259842!
            Me.Line10.LineWeight = 1!
            Me.Line10.Name = "Line10"
            Me.Line10.Top = 0.551181!
            Me.Line10.Width = 0!
            Me.Line10.X1 = 1.259842!
            Me.Line10.X2 = 1.259842!
            Me.Line10.Y1 = 0.551181!
            Me.Line10.Y2 = 0.7874014!
            '
            'TxtBxMaterial
            '
            Me.TxtBxMaterial.DataField = "CodArticulo"
            Me.TxtBxMaterial.Height = 0.1875!
            Me.TxtBxMaterial.Left = 0.05565119!
            Me.TxtBxMaterial.Name = "TxtBxMaterial"
            Me.TxtBxMaterial.Style = "font-size: 9pt"
            Me.TxtBxMaterial.Top = 0!
            Me.TxtBxMaterial.Width = 1.102363!
            '
            'TxtBxDescr
            '
            Me.TxtBxDescr.DataField = "Descripcion"
            Me.TxtBxDescr.Height = 0.1875!
            Me.TxtBxDescr.Left = 1.259842!
            Me.TxtBxDescr.Name = "TxtBxDescr"
            Me.TxtBxDescr.Style = "font-size: 9pt"
            Me.TxtBxDescr.Top = 0!
            Me.TxtBxDescr.Width = 2.834646!
            '
            'TxtBxPrecioNormal
            '
            Me.TxtBxPrecioNormal.DataField = "PrecioIva"
            Me.TxtBxPrecioNormal.Height = 0.1875!
            Me.TxtBxPrecioNormal.Left = 4.330709!
            Me.TxtBxPrecioNormal.Name = "TxtBxPrecioNormal"
            Me.TxtBxPrecioNormal.OutputFormat = resources.GetString("TxtBxPrecioNormal.OutputFormat")
            Me.TxtBxPrecioNormal.Style = "text-align: right; font-size: 9pt"
            Me.TxtBxPrecioNormal.Text = "$0,000.00"
            Me.TxtBxPrecioNormal.Top = 0!
            Me.TxtBxPrecioNormal.Width = 0.7086618!
            '
            'TxtBxDescuento
            '
            Me.TxtBxDescuento.DataField = "Descuento"
            Me.TxtBxDescuento.Height = 0.1875!
            Me.TxtBxDescuento.Left = 5.118111!
            Me.TxtBxDescuento.Name = "TxtBxDescuento"
            Me.TxtBxDescuento.Style = "text-align: right; font-size: 9pt"
            Me.TxtBxDescuento.Text = "00.00"
            Me.TxtBxDescuento.Top = 0!
            Me.TxtBxDescuento.Width = 0.75!
            '
            'TxtBxPrecioOferta
            '
            Me.TxtBxPrecioOferta.DataField = "PrecioDescuento"
            Me.TxtBxPrecioOferta.Height = 0.1875!
            Me.TxtBxPrecioOferta.Left = 5.905513!
            Me.TxtBxPrecioOferta.Name = "TxtBxPrecioOferta"
            Me.TxtBxPrecioOferta.OutputFormat = resources.GetString("TxtBxPrecioOferta.OutputFormat")
            Me.TxtBxPrecioOferta.Style = "text-align: right; font-size: 9pt"
            Me.TxtBxPrecioOferta.Text = "$0,000.00"
            Me.TxtBxPrecioOferta.Top = 0!
            Me.TxtBxPrecioOferta.Width = 0.7874014!
            '
            'Line6
            '
            Me.Line6.Height = 0!
            Me.Line6.Left = 0.006944444!
            Me.Line6.LineWeight = 1!
            Me.Line6.Name = "Line6"
            Me.Line6.Top = 0.006944444!
            Me.Line6.Width = 6.692914!
            Me.Line6.X1 = 6.699859!
            Me.Line6.X2 = 0.006944444!
            Me.Line6.Y1 = 0.006944444!
            Me.Line6.Y2 = 0.006944444!
            '
            'txtNumPag
            '
            Me.txtNumPag.Height = 0.1574803!
            Me.txtNumPag.Left = 6.329232!
            Me.txtNumPag.Name = "txtNumPag"
            Me.txtNumPag.Style = "text-align: right; font-size: 8.25pt"
            Me.txtNumPag.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
            Me.txtNumPag.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount
            Me.txtNumPag.Text = "0000"
            Me.txtNumPag.Top = 0!
            Me.txtNumPag.Width = 0.3479333!
            '
            'lblPag
            '
            Me.lblPag.Height = 0.1574803!
            Me.lblPag.HyperLink = Nothing
            Me.lblPag.Left = 6.093013!
            Me.lblPag.Name = "lblPag"
            Me.lblPag.Style = "font-size: 8.25pt"
            Me.lblPag.Text = "Pag."
            Me.lblPag.Top = 0!
            Me.lblPag.Width = 0.2362203!
            '
            'ActiveReport1
            '
            Me.MasterReport = false
            Me.PageSettings.DefaultPaperSize = false
            Me.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Portrait
            Me.PageSettings.PaperHeight = 11!
            Me.PageSettings.PaperWidth = 8.5!
            Me.PrintWidth = 6.760417!
            Me.Sections.Add(Me.PageHeader)
            Me.Sections.Add(Me.Detail)
            Me.Sections.Add(Me.PageFooter)
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo"& _ 
                        "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit", "Heading1", "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei"& _ 
                        "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit", "Heading2", "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo"& _ 
                        "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit", "Heading3", "Normal"))
            CType(Me.LblTitulo,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.LblFecha,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label3,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label5,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label6,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TxtBxMaterial,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TxtBxDescr,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TxtBxPrecioNormal,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TxtBxDescuento,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TxtBxPrecioOferta,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtNumPag,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblPag,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        
	End Sub

#End Region


End Class
