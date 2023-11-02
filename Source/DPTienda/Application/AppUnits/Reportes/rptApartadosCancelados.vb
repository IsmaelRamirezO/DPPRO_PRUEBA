Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU

Public Class rptApartadosCancelados
Inherits DataDynamics.ActiveReports.ActiveReport
    Public Sub New(ByVal dsDetalle As DataSet, ByVal FechaDe As DateTime, ByVal FechaAl As DateTime)
        MyBase.New()
        InitializeComponent()
        Dim oAlmacen As Almacen
        Dim oAlmacenesMgr As New CatalogoAlmacenesManager(oAppContext)
        Dim oSAPMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        oAlmacen = oAlmacenesMgr.Load(oSAPMgr.read_centros) 'oAppContext.ApplicationConfiguration.Almacen)

        If Not oAlmacen Is Nothing Then

            Me.txtSucursal.Text = oAlmacen.ID & " " & oAlmacen.Descripcion

        Else

            Me.txtSucursal.Text = oAppContext.ApplicationConfiguration.Almacen

        End If

        Me.DataSource = dsDetalle
        Me.DataMember = dsDetalle.Tables(0).TableName

        Me.txtFecha.Text = Now.Date.ToShortDateString

        Me.txtFechaDel.Text = FechaDe.ToLongDateString
        Me.txtFechaAl.Text = FechaAl.ToLongDateString

        Me.txtCaja.Text = oAppContext.ApplicationConfiguration.NoCaja
    End Sub
#Region "ActiveReports Designer generated code"
    Private WithEvents PageHeader As PageHeader = Nothing
    Private WithEvents GroupHeader1 As GroupHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents GroupFooter1 As GroupFooter = Nothing
    Private WithEvents PageFooter As PageFooter = Nothing
	Private Shape1 As Shape = Nothing
	Private Label1 As Label = Nothing
	Private Label2 As Label = Nothing
	Private Label3 As Label = Nothing
	Private Label4 As Label = Nothing
	Private txtFecha As TextBox = Nothing
	Private Label5 As Label = Nothing
	Private txtCaja As TextBox = Nothing
	Private txtSucursal As TextBox = Nothing
	Private txtFechaDel As TextBox = Nothing
	Private txtFechaAl As TextBox = Nothing
	Private Shape2 As Shape = Nothing
	Private Label10 As Label = Nothing
	Private Label9 As Label = Nothing
	Private Label8 As Label = Nothing
	Private Label7 As Label = Nothing
	Private Label6 As Label = Nothing
	Private Line1 As Line = Nothing
	Private txtFolio As TextBox = Nothing
	Private txtCantidad As TextBox = Nothing
	Private txtImporte As TextBox = Nothing
	Private txtDescuento As TextBox = Nothing
	Private txtEntregada As TextBox = Nothing
	Private Line2 As Line = Nothing
	Private Shape3 As Shape = Nothing
	Private Label11 As Label = Nothing
	Private TextBox1 As TextBox = Nothing
	Private TextBox2 As TextBox = Nothing
	Private TextBox3 As TextBox = Nothing
	Private Line3 As Line = Nothing
	Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptApartadosCancelados))
            Me.Detail = New DataDynamics.ActiveReports.Detail()
            Me.PageHeader = New DataDynamics.ActiveReports.PageHeader()
            Me.PageFooter = New DataDynamics.ActiveReports.PageFooter()
            Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader()
            Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter()
            Me.Shape1 = New DataDynamics.ActiveReports.Shape()
            Me.Label1 = New DataDynamics.ActiveReports.Label()
            Me.Label2 = New DataDynamics.ActiveReports.Label()
            Me.Label3 = New DataDynamics.ActiveReports.Label()
            Me.Label4 = New DataDynamics.ActiveReports.Label()
            Me.txtFecha = New DataDynamics.ActiveReports.TextBox()
            Me.Label5 = New DataDynamics.ActiveReports.Label()
            Me.txtCaja = New DataDynamics.ActiveReports.TextBox()
            Me.txtSucursal = New DataDynamics.ActiveReports.TextBox()
            Me.txtFechaDel = New DataDynamics.ActiveReports.TextBox()
            Me.txtFechaAl = New DataDynamics.ActiveReports.TextBox()
            Me.Shape2 = New DataDynamics.ActiveReports.Shape()
            Me.Label10 = New DataDynamics.ActiveReports.Label()
            Me.Label9 = New DataDynamics.ActiveReports.Label()
            Me.Label8 = New DataDynamics.ActiveReports.Label()
            Me.Label7 = New DataDynamics.ActiveReports.Label()
            Me.Label6 = New DataDynamics.ActiveReports.Label()
            Me.Line1 = New DataDynamics.ActiveReports.Line()
            Me.txtFolio = New DataDynamics.ActiveReports.TextBox()
            Me.txtCantidad = New DataDynamics.ActiveReports.TextBox()
            Me.txtImporte = New DataDynamics.ActiveReports.TextBox()
            Me.txtDescuento = New DataDynamics.ActiveReports.TextBox()
            Me.txtEntregada = New DataDynamics.ActiveReports.TextBox()
            Me.Line2 = New DataDynamics.ActiveReports.Line()
            Me.Shape3 = New DataDynamics.ActiveReports.Shape()
            Me.Label11 = New DataDynamics.ActiveReports.Label()
            Me.TextBox1 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox2 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox3 = New DataDynamics.ActiveReports.TextBox()
            Me.Line3 = New DataDynamics.ActiveReports.Line()
            CType(Me.Label1,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label3,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFecha,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label5,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtCaja,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtSucursal,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFechaDel,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFechaAl,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label10,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label9,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label8,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label7,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label6,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFolio,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtCantidad,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtImporte,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtDescuento,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtEntregada,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label11,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox1,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox2,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox3,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
            '
            'Detail
            '
            Me.Detail.ColumnSpacing = 0!
            Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Line1, Me.txtFolio, Me.txtCantidad, Me.txtImporte, Me.txtDescuento, Me.txtEntregada, Me.Line2})
            Me.Detail.Height = 0.1979167!
            Me.Detail.Name = "Detail"
            '
            'PageHeader
            '
            Me.PageHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape1, Me.Label1, Me.Label2, Me.Label3, Me.Label4, Me.txtFecha, Me.Label5, Me.txtCaja, Me.txtSucursal, Me.txtFechaDel, Me.txtFechaAl})
            Me.PageHeader.Height = 0.9048611!
            Me.PageHeader.Name = "PageHeader"
            '
            'PageFooter
            '
            Me.PageFooter.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Line3})
            Me.PageFooter.Height = 0.25!
            Me.PageFooter.Name = "PageFooter"
            '
            'GroupHeader1
            '
            Me.GroupHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape2, Me.Label10, Me.Label9, Me.Label8, Me.Label7, Me.Label6})
            Me.GroupHeader1.Height = 0.275!
            Me.GroupHeader1.Name = "GroupHeader1"
            '
            'GroupFooter1
            '
            Me.GroupFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape3, Me.Label11, Me.TextBox1, Me.TextBox2, Me.TextBox3})
            Me.GroupFooter1.Height = 0.3145833!
            Me.GroupFooter1.Name = "GroupFooter1"
            '
            'Shape1
            '
            Me.Shape1.Height = 0.9055118!
            Me.Shape1.Left = 0!
            Me.Shape1.Name = "Shape1"
            Me.Shape1.RoundingRadius = 9.999999!
            Me.Shape1.Top = 0!
            Me.Shape1.Width = 6.692914!
            '
            'Label1
            '
            Me.Label1.Height = 0.2!
            Me.Label1.HyperLink = Nothing
            Me.Label1.Left = 1.968504!
            Me.Label1.Name = "Label1"
            Me.Label1.Style = ""
            Me.Label1.Text = "REPORTE DE APARTADOS EN TOTALES"
            Me.Label1.Top = 0!
            Me.Label1.Width = 2.795276!
            '
            'Label2
            '
            Me.Label2.Height = 0.2!
            Me.Label2.HyperLink = Nothing
            Me.Label2.Left = 1.338583!
            Me.Label2.Name = "Label2"
            Me.Label2.Style = ""
            Me.Label2.Text = "De.:"
            Me.Label2.Top = 0.2755906!
            Me.Label2.Width = 0.2755904!
            '
            'Label3
            '
            Me.Label3.Height = 0.2!
            Me.Label3.HyperLink = Nothing
            Me.Label3.Left = 3.740158!
            Me.Label3.Name = "Label3"
            Me.Label3.Style = ""
            Me.Label3.Text = "Al.:"
            Me.Label3.Top = 0.2755906!
            Me.Label3.Width = 0.2755904!
            '
            'Label4
            '
            Me.Label4.Height = 0.2!
            Me.Label4.HyperLink = Nothing
            Me.Label4.Left = 1.338583!
            Me.Label4.Name = "Label4"
            Me.Label4.Style = ""
            Me.Label4.Text = "Sucursal.:"
            Me.Label4.Top = 0.511811!
            Me.Label4.Width = 0.6299212!
            '
            'txtFecha
            '
            Me.txtFecha.Height = 0.2!
            Me.txtFecha.Left = 5.118111!
            Me.txtFecha.Name = "txtFecha"
            Me.txtFecha.Top = 0!
            Me.txtFecha.Width = 1.338583!
            '
            'Label5
            '
            Me.Label5.Height = 0.2!
            Me.Label5.HyperLink = Nothing
            Me.Label5.Left = 0.07874014!
            Me.Label5.Name = "Label5"
            Me.Label5.Style = ""
            Me.Label5.Text = "Caja.:"
            Me.Label5.Top = 0.2755906!
            Me.Label5.Width = 0.4330709!
            '
            'txtCaja
            '
            Me.txtCaja.Height = 0.2!
            Me.txtCaja.Left = 0.551181!
            Me.txtCaja.Name = "txtCaja"
            Me.txtCaja.Top = 0.2755906!
            Me.txtCaja.Width = 0.3149606!
            '
            'txtSucursal
            '
            Me.txtSucursal.Height = 0.2!
            Me.txtSucursal.Left = 2.007874!
            Me.txtSucursal.Name = "txtSucursal"
            Me.txtSucursal.Top = 0.511811!
            Me.txtSucursal.Width = 2.755905!
            '
            'txtFechaDel
            '
            Me.txtFechaDel.Height = 0.2!
            Me.txtFechaDel.Left = 1.653543!
            Me.txtFechaDel.Name = "txtFechaDel"
            Me.txtFechaDel.Top = 0.2755906!
            Me.txtFechaDel.Width = 1.889764!
            '
            'txtFechaAl
            '
            Me.txtFechaAl.Height = 0.2!
            Me.txtFechaAl.Left = 4.055118!
            Me.txtFechaAl.Name = "txtFechaAl"
            Me.txtFechaAl.Top = 0.2755906!
            Me.txtFechaAl.Width = 1.889764!
            '
            'Shape2
            '
            Me.Shape2.Height = 0.2755906!
            Me.Shape2.Left = 0!
            Me.Shape2.Name = "Shape2"
            Me.Shape2.RoundingRadius = 9.999999!
            Me.Shape2.Top = 0!
            Me.Shape2.Width = 6.692914!
            '
            'Label10
            '
            Me.Label10.Height = 0.2!
            Me.Label10.HyperLink = Nothing
            Me.Label10.Left = 4.881889!
            Me.Label10.Name = "Label10"
            Me.Label10.Style = "text-align: center"
            Me.Label10.Text = "FECHA"
            Me.Label10.Top = 0.0625!
            Me.Label10.Width = 1!
            '
            'Label9
            '
            Me.Label9.Height = 0.2!
            Me.Label9.HyperLink = Nothing
            Me.Label9.Left = 3.543307!
            Me.Label9.Name = "Label9"
            Me.Label9.Style = "text-align: center"
            Me.Label9.Text = "DESCUENTO"
            Me.Label9.Top = 0.0625!
            Me.Label9.Width = 0.944882!
            '
            'Label8
            '
            Me.Label8.Height = 0.2!
            Me.Label8.HyperLink = Nothing
            Me.Label8.Left = 2.362205!
            Me.Label8.Name = "Label8"
            Me.Label8.Style = "text-align: center"
            Me.Label8.Text = "IMPORTE"
            Me.Label8.Top = 0.0625!
            Me.Label8.Width = 0.8267716!
            '
            'Label7
            '
            Me.Label7.Height = 0.2!
            Me.Label7.HyperLink = Nothing
            Me.Label7.Left = 1.181102!
            Me.Label7.Name = "Label7"
            Me.Label7.Style = "text-align: center"
            Me.Label7.Text = "CANTIDAD"
            Me.Label7.Top = 0.0625!
            Me.Label7.Width = 0.7874014!
            '
            'Label6
            '
            Me.Label6.Height = 0.2!
            Me.Label6.HyperLink = Nothing
            Me.Label6.Left = 0!
            Me.Label6.Name = "Label6"
            Me.Label6.Style = "text-align: center"
            Me.Label6.Text = "FOLIO"
            Me.Label6.Top = 0.0625!
            Me.Label6.Width = 0.7874014!
            '
            'Line1
            '
            Me.Line1.Height = 0.189906!
            Me.Line1.Left = 6.692914!
            Me.Line1.LineWeight = 1!
            Me.Line1.Name = "Line1"
            Me.Line1.Top = 0.006944444!
            Me.Line1.Width = 0.00694418!
            Me.Line1.X1 = 6.699858!
            Me.Line1.X2 = 6.692914!
            Me.Line1.Y1 = 0.006944444!
            Me.Line1.Y2 = 0.1968504!
            '
            'txtFolio
            '
            Me.txtFolio.DataField = "FolioApartado"
            Me.txtFolio.Height = 0.2!
            Me.txtFolio.Left = 0.07874014!
            Me.txtFolio.Name = "txtFolio"
            Me.txtFolio.Style = "text-align: center; font-size: 9pt"
            Me.txtFolio.Top = 0!
            Me.txtFolio.Width = 0.7086611!
            '
            'txtCantidad
            '
            Me.txtCantidad.DataField = "Cantidad"
            Me.txtCantidad.Height = 0.2!
            Me.txtCantidad.Left = 1.181102!
            Me.txtCantidad.Name = "txtCantidad"
            Me.txtCantidad.Style = "text-align: center; font-size: 9pt"
            Me.txtCantidad.Top = 0!
            Me.txtCantidad.Width = 0.7874014!
            '
            'txtImporte
            '
            Me.txtImporte.DataField = "Importe"
            Me.txtImporte.Height = 0.2!
            Me.txtImporte.Left = 2.362205!
            Me.txtImporte.Name = "txtImporte"
            Me.txtImporte.OutputFormat = resources.GetString("txtImporte.OutputFormat")
            Me.txtImporte.Style = "text-align: right; font-size: 9pt"
            Me.txtImporte.Top = 0!
            Me.txtImporte.Width = 0.7874014!
            '
            'txtDescuento
            '
            Me.txtDescuento.DataField = "DescuentoTotal"
            Me.txtDescuento.Height = 0.2!
            Me.txtDescuento.Left = 3.543307!
            Me.txtDescuento.Name = "txtDescuento"
            Me.txtDescuento.OutputFormat = resources.GetString("txtDescuento.OutputFormat")
            Me.txtDescuento.Style = "text-align: right; font-size: 9pt"
            Me.txtDescuento.Top = 0!
            Me.txtDescuento.Width = 1!
            '
            'txtEntregada
            '
            Me.txtEntregada.DataField = "Fecha"
            Me.txtEntregada.Height = 0.2!
            Me.txtEntregada.Left = 4.881889!
            Me.txtEntregada.Name = "txtEntregada"
            Me.txtEntregada.OutputFormat = resources.GetString("txtEntregada.OutputFormat")
            Me.txtEntregada.Style = "text-align: center; font-size: 9pt"
            Me.txtEntregada.Top = 0!
            Me.txtEntregada.Width = 1!
            '
            'Line2
            '
            Me.Line2.Height = 0.189906!
            Me.Line2.Left = 0!
            Me.Line2.LineWeight = 1!
            Me.Line2.Name = "Line2"
            Me.Line2.Top = 0.006944444!
            Me.Line2.Width = 0.00694466!
            Me.Line2.X1 = 0.00694466!
            Me.Line2.X2 = 0!
            Me.Line2.Y1 = 0.006944444!
            Me.Line2.Y2 = 0.1968504!
            '
            'Shape3
            '
            Me.Shape3.Height = 0.3149606!
            Me.Shape3.Left = 0!
            Me.Shape3.Name = "Shape3"
            Me.Shape3.RoundingRadius = 9.999999!
            Me.Shape3.Top = 0!
            Me.Shape3.Width = 6.692914!
            '
            'Label11
            '
            Me.Label11.Height = 0.2!
            Me.Label11.HyperLink = Nothing
            Me.Label11.Left = 0.03937007!
            Me.Label11.Name = "Label11"
            Me.Label11.Style = ""
            Me.Label11.Text = "Totales.:"
            Me.Label11.Top = 0.0625!
            Me.Label11.Width = 0.5674213!
            '
            'TextBox1
            '
            Me.TextBox1.DataField = "Cantidad"
            Me.TextBox1.Height = 0.2!
            Me.TextBox1.Left = 1.03937!
            Me.TextBox1.Name = "TextBox1"
            Me.TextBox1.OutputFormat = resources.GetString("TextBox1.OutputFormat")
            Me.TextBox1.Style = "text-align: right"
            Me.TextBox1.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
            Me.TextBox1.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
            Me.TextBox1.Text = "TextBox1"
            Me.TextBox1.Top = 0.0625!
            Me.TextBox1.Width = 1!
            '
            'TextBox2
            '
            Me.TextBox2.DataField = "Importe"
            Me.TextBox2.Height = 0.2!
            Me.TextBox2.Left = 2.176592!
            Me.TextBox2.Name = "TextBox2"
            Me.TextBox2.OutputFormat = resources.GetString("TextBox2.OutputFormat")
            Me.TextBox2.Style = "text-align: right"
            Me.TextBox2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
            Me.TextBox2.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
            Me.TextBox2.Text = "TextBox2"
            Me.TextBox2.Top = 0.0625!
            Me.TextBox2.Width = 1!
            '
            'TextBox3
            '
            Me.TextBox3.DataField = "DescuentoTotal"
            Me.TextBox3.Height = 0.2!
            Me.TextBox3.Left = 3.551591!
            Me.TextBox3.Name = "TextBox3"
            Me.TextBox3.OutputFormat = resources.GetString("TextBox3.OutputFormat")
            Me.TextBox3.Style = "text-align: right"
            Me.TextBox3.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
            Me.TextBox3.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
            Me.TextBox3.Text = "TextBox3"
            Me.TextBox3.Top = 0.0625!
            Me.TextBox3.Width = 1!
            '
            'Line3
            '
            Me.Line3.Height = 5.866598E-09!
            Me.Line3.Left = 0!
            Me.Line3.LineWeight = 1!
            Me.Line3.Name = "Line3"
            Me.Line3.Top = 0!
            Me.Line3.Width = 6.692914!
            Me.Line3.X1 = 6.692914!
            Me.Line3.X2 = 0!
            Me.Line3.Y1 = 0!
            Me.Line3.Y2 = 5.866598E-09!
            '
            'ActiveReport1
            '
            Me.MasterReport = false
            Me.PageSettings.PaperHeight = 11!
            Me.PageSettings.PaperWidth = 8.5!
            Me.PrintWidth = 6.78125!
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
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label3,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFecha,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label5,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtCaja,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtSucursal,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFechaDel,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFechaAl,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label10,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label9,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label8,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label7,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label6,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFolio,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtCantidad,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtImporte,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtDescuento,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtEntregada,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label11,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox1,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox2,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox3,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        
	End Sub

#End Region
End Class
