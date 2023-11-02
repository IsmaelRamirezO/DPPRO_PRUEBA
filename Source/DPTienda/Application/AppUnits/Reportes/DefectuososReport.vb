Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Imports DportenisPro.DPTienda.Reports.Inventario
Imports DportenisPro.DPTienda.Reports
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU

Public Class DefectuososReport

    Inherits DataDynamics.ActiveReports.ActiveReport

    Public Sub New(ByVal oReporter As InventarioDefectuosos, ByVal Almacen As String)

        MyBase.New()

        InitializeComponent()

        Try

            Me.DataSource = oReporter.dsArticulos
            Me.DataMember = oReporter.dsArticulos.Tables(0).TableName

            Me.lblTitulo.Text = "REPORTE DE ARTICULOS MARCADOS COMO DEFECTUOSOS"

            '----------------------------------------------------------------------
            ' JNAVA (15.03.2016): Modificacion para mostrar datos de almacen
            '----------------------------------------------------------------------
            Dim oAlmacenMgr As New CatalogoAlmacenesManager(oAppContext)
            Dim oSAPMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
            Dim oAlmacen As Almacen = oAlmacenMgr.Load(oSAPMgr.Read_Centros)
            If Not oAlmacen Is Nothing Then
                Me.TxtSucursal.Text = oAppContext.ApplicationConfiguration.Almacen & " " & oAlmacen.Descripcion
            Else
                Me.TxtSucursal.Text = Almacen
            End If
            '----------------------------------------------------------------------

            Me.txtArticulos.DataField = "Codigo"
            'Me.txtColor.DataField = "Color"
            Me.txtTotal.DataField = "TotalA"
            Me.txtDescripcion.DataField = "Descripcion"
            Me.txtFechaReporte.Text = Format(Date.Now, "dd - MMM - yyyy")

        Catch ex As Exception

            Throw ex

        End Try

    End Sub

#Region "ActiveReports Designer generated code"
    Private WithEvents PageHeader As PageHeader = Nothing
    Private WithEvents GroupHeader1 As GroupHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents GroupFooter1 As GroupFooter = Nothing
    Private WithEvents PageFooter As PageFooter = Nothing
	Private Shape1 As Shape = Nothing
	Private Label4 As Label = Nothing
	Private Label3 As Label = Nothing
	Private Label2 As Label = Nothing
	Private lblTitulo As Label = Nothing
	Private txtFechaReporte As TextBox = Nothing
	Private TxtSucursal As TextBox = Nothing
	Private txtPag As TextBox = Nothing
	Private TextBox5 As TextBox = Nothing
	Private Line37 As Line = Nothing
	Private Line40 As Line = Nothing
	Private Line41 As Line = Nothing
	Private txtArticulos As TextBox = Nothing
	Private txtTotal As TextBox = Nothing
	Private txtDescripcion As TextBox = Nothing
    Private Shape2 As Shape = Nothing
	Private txtTotGral As TextBox = Nothing
	Private TextBox8 As TextBox = Nothing
	Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DefectuososReport))
        Me.Detail = New DataDynamics.ActiveReports.Detail()
        Me.txtArticulos = New DataDynamics.ActiveReports.TextBox()
        Me.txtTotal = New DataDynamics.ActiveReports.TextBox()
        Me.txtDescripcion = New DataDynamics.ActiveReports.TextBox()
        Me.PageHeader = New DataDynamics.ActiveReports.PageHeader()
        Me.Shape1 = New DataDynamics.ActiveReports.Shape()
        Me.Label4 = New DataDynamics.ActiveReports.Label()
        Me.Label3 = New DataDynamics.ActiveReports.Label()
        Me.Label2 = New DataDynamics.ActiveReports.Label()
        Me.lblTitulo = New DataDynamics.ActiveReports.Label()
        Me.txtFechaReporte = New DataDynamics.ActiveReports.TextBox()
        Me.TxtSucursal = New DataDynamics.ActiveReports.TextBox()
        Me.txtPag = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox5 = New DataDynamics.ActiveReports.TextBox()
        Me.Line37 = New DataDynamics.ActiveReports.Line()
        Me.Line40 = New DataDynamics.ActiveReports.Line()
        Me.Line41 = New DataDynamics.ActiveReports.Line()
        Me.PageFooter = New DataDynamics.ActiveReports.PageFooter()
        Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader()
        Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter()
        Me.Shape2 = New DataDynamics.ActiveReports.Shape()
        Me.txtTotGral = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox8 = New DataDynamics.ActiveReports.TextBox()
        CType(Me.txtArticulos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDescripcion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaReporte, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtSucursal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPag, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotGral, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.ColumnSpacing = 0.0!
        Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtArticulos, Me.txtTotal, Me.txtDescripcion})
        Me.Detail.Height = 0.1979167!
        Me.Detail.Name = "Detail"
        '
        'txtArticulos
        '
        Me.txtArticulos.Height = 0.2!
        Me.txtArticulos.Left = 0.1!
        Me.txtArticulos.Name = "txtArticulos"
        Me.txtArticulos.Style = "ddo-char-set: 1; font-size: 8pt"
        Me.txtArticulos.Text = "txtarticulo"
        Me.txtArticulos.Top = 0.0!
        Me.txtArticulos.Width = 2.421!
        '
        'txtTotal
        '
        Me.txtTotal.Height = 0.2!
        Me.txtTotal.Left = 6.686!
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.OutputFormat = resources.GetString("txtTotal.OutputFormat")
        Me.txtTotal.Style = "ddo-char-set: 1; text-align: center; font-size: 8pt; vertical-align: middle"
        Me.txtTotal.Text = "txtTotal"
        Me.txtTotal.Top = 0.0!
        Me.txtTotal.Width = 0.6871772!
        '
        'txtDescripcion
        '
        Me.txtDescripcion.CanGrow = False
        Me.txtDescripcion.Height = 0.2!
        Me.txtDescripcion.Left = 2.58!
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Style = "ddo-char-set: 1; font-size: 8pt"
        Me.txtDescripcion.Text = "txtDescripcion"
        Me.txtDescripcion.Top = 0.0!
        Me.txtDescripcion.Width = 4.106001!
        '
        'PageHeader
        '
        Me.PageHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label3, Me.Shape1, Me.Label4, Me.Label2, Me.lblTitulo, Me.txtFechaReporte, Me.TxtSucursal, Me.txtPag, Me.TextBox5, Me.Line37, Me.Line40, Me.Line41})
        Me.PageHeader.Height = 0.8354167!
        Me.PageHeader.Name = "PageHeader"
        '
        'Shape1
        '
        Me.Shape1.Height = 0.8356299!
        Me.Shape1.Left = 0.0!
        Me.Shape1.LineWeight = 2.0!
        Me.Shape1.Name = "Shape1"
        Me.Shape1.RoundingRadius = 9.999999!
        Me.Shape1.Top = 0.0!
        Me.Shape1.Width = 7.401576!
        '
        'Label4
        '
        Me.Label4.Height = 0.2!
        Me.Label4.HyperLink = Nothing
        Me.Label4.Left = 2.58!
        Me.Label4.Name = "Label4"
        Me.Label4.Style = "ddo-char-set: 1; text-align: center; font-weight: bold; font-size: 8pt; vertical-" & _
    "align: middle"
        Me.Label4.Text = "DESCRIPCIÓN"
        Me.Label4.Top = 0.625!
        Me.Label4.Width = 4.106!
        '
        'Label3
        '
        Me.Label3.Height = 0.2!
        Me.Label3.HyperLink = Nothing
        Me.Label3.Left = 6.686!
        Me.Label3.Name = "Label3"
        Me.Label3.Style = "ddo-char-set: 1; text-align: center; font-weight: bold; font-size: 8pt; vertical-" & _
    "align: middle"
        Me.Label3.Text = "TOTAL"
        Me.Label3.Top = 0.6350001!
        Me.Label3.Width = 0.7140002!
        '
        'Label2
        '
        Me.Label2.Height = 0.2!
        Me.Label2.HyperLink = Nothing
        Me.Label2.Left = 0.1!
        Me.Label2.Name = "Label2"
        Me.Label2.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; vertical-al" & _
    "ign: middle"
        Me.Label2.Text = "ARTICULOS"
        Me.Label2.Top = 0.625!
        Me.Label2.Width = 2.421!
        '
        'lblTitulo
        '
        Me.lblTitulo.Height = 0.2!
        Me.lblTitulo.HyperLink = Nothing
        Me.lblTitulo.Left = 1.1875!
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Style = "ddo-char-set: 1; text-align: center; font-weight: bold; font-size: 8.5pt; vertica" & _
    "l-align: middle"
        Me.lblTitulo.Text = "REPORTE DE ARTICULOS MARCADOS COMO DEFECTUOSOS"
        Me.lblTitulo.Top = 0.0625!
        Me.lblTitulo.Width = 5.151577!
        '
        'txtFechaReporte
        '
        Me.txtFechaReporte.Height = 0.2!
        Me.txtFechaReporte.Left = 0.1230315!
        Me.txtFechaReporte.Name = "txtFechaReporte"
        Me.txtFechaReporte.Style = "ddo-char-set: 1; font-weight: bold; font-size: 8pt; vertical-align: middle"
        Me.txtFechaReporte.Text = "txtFecha"
        Me.txtFechaReporte.Top = 0.02460632!
        Me.txtFechaReporte.Width = 1.0!
        '
        'TxtSucursal
        '
        Me.TxtSucursal.Height = 0.1968504!
        Me.TxtSucursal.Left = 1.3125!
        Me.TxtSucursal.Name = "TxtSucursal"
        Me.TxtSucursal.Style = "ddo-char-set: 1; text-align: center; font-size: 8pt; vertical-align: middle"
        Me.TxtSucursal.Text = "TxtSucursal"
        Me.TxtSucursal.Top = 0.3125!
        Me.TxtSucursal.Width = 4.716043!
        '
        'txtPag
        '
        Me.txtPag.Height = 0.2!
        Me.txtPag.Left = 6.8125!
        Me.txtPag.Name = "txtPag"
        Me.txtPag.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; vertical-a" & _
    "lign: middle"
        Me.txtPag.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.txtPag.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount
        Me.txtPag.Text = "Pagina"
        Me.txtPag.Top = 0.02460632!
        Me.txtPag.Width = 0.5605316!
        '
        'TextBox5
        '
        Me.TextBox5.Height = 0.2!
        Me.TextBox5.Left = 6.435532!
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Style = "ddo-char-set: 1; font-weight: normal; font-size: 8pt; vertical-align: middle"
        Me.TextBox5.Text = "Pag.:"
        Me.TextBox5.Top = 0.02460632!
        Me.TextBox5.Width = 0.3125!
        '
        'Line37
        '
        Me.Line37.Height = 0.0005000234!
        Me.Line37.Left = 0.0!
        Me.Line37.LineWeight = 1.0!
        Me.Line37.Name = "Line37"
        Me.Line37.Top = 0.625!
        Me.Line37.Width = 7.4!
        Me.Line37.X1 = 7.4!
        Me.Line37.X2 = 0.0!
        Me.Line37.Y1 = 0.6255!
        Me.Line37.Y2 = 0.625!
        '
        'Line40
        '
        Me.Line40.Height = 0.1875!
        Me.Line40.Left = 6.686!
        Me.Line40.LineWeight = 1.0!
        Me.Line40.Name = "Line40"
        Me.Line40.Top = 0.625!
        Me.Line40.Width = 0.0!
        Me.Line40.X1 = 6.686!
        Me.Line40.X2 = 6.686!
        Me.Line40.Y1 = 0.625!
        Me.Line40.Y2 = 0.8125!
        '
        'Line41
        '
        Me.Line41.Height = 0.1875!
        Me.Line41.Left = 2.569444!
        Me.Line41.LineWeight = 1.0!
        Me.Line41.Name = "Line41"
        Me.Line41.Top = 0.6319444!
        Me.Line41.Width = 0.0!
        Me.Line41.X1 = 2.569444!
        Me.Line41.X2 = 2.569444!
        Me.Line41.Y1 = 0.6319444!
        Me.Line41.Y2 = 0.8194444!
        '
        'PageFooter
        '
        Me.PageFooter.Height = 0.0!
        Me.PageFooter.Name = "PageFooter"
        '
        'GroupHeader1
        '
        Me.GroupHeader1.Height = 0.0!
        Me.GroupHeader1.Name = "GroupHeader1"
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape2, Me.txtTotGral, Me.TextBox8})
        Me.GroupFooter1.Height = 0.28125!
        Me.GroupFooter1.Name = "GroupFooter1"
        '
        'Shape2
        '
        Me.Shape2.Height = 0.2731299!
        Me.Shape2.Left = 0.0!
        Me.Shape2.LineWeight = 2.0!
        Me.Shape2.Name = "Shape2"
        Me.Shape2.RoundingRadius = 9.999999!
        Me.Shape2.Top = 0.0!
        Me.Shape2.Width = 7.401576!
        '
        'txtTotGral
        '
        Me.txtTotGral.DataField = "TotalA"
        Me.txtTotGral.Height = 0.1875!
        Me.txtTotGral.Left = 6.686!
        Me.txtTotGral.Name = "txtTotGral"
        Me.txtTotGral.OutputFormat = resources.GetString("txtTotGral.OutputFormat")
        Me.txtTotGral.Style = "text-align: center; font-weight: bold"
        Me.txtTotGral.Text = "Total"
        Me.txtTotGral.Top = 0.037!
        Me.txtTotGral.Width = 0.6875!
        '
        'TextBox8
        '
        Me.TextBox8.Height = 0.188!
        Me.TextBox8.Left = 5.309!
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.Style = "ddo-char-set: 1; font-weight: bold; font-size: 8pt; vertical-align: middle"
        Me.TextBox8.Text = "TOTAL ARTICULOS"
        Me.TextBox8.Top = 0.037!
        Me.TextBox8.Width = 1.377!
        '
        'DefectuososReport
        '
        Me.MasterReport = False
        Me.PageSettings.Margins.Left = 0.4097222!
        Me.PageSettings.Margins.Right = 0.4097222!
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 7.416667!
        Me.Sections.Add(Me.PageHeader)
        Me.Sections.Add(Me.GroupHeader1)
        Me.Sections.Add(Me.Detail)
        Me.Sections.Add(Me.GroupFooter1)
        Me.Sections.Add(Me.PageFooter)
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" & _
            "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei" & _
            "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" & _
            "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit", "Heading3", "Normal"))
        CType(Me.txtArticulos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDescripcion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaReporte, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtSucursal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPag, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotGral, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

#End Region

End Class
