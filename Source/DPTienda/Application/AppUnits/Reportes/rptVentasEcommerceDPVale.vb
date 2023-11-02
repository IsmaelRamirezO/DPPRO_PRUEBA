Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Imports DportenisPro.DPTienda.ApplicationUnits.FacturasFormaPago
Imports DportenisPro.DPTienda.ApplicationUnits.Facturas
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes
Imports DportenisPro.DPTienda.ApplicationUnits.Clientes
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoFormasPago
Imports System.Collections.Generic

Public Class rptVentasEcommerceDPVale
    Inherits DataDynamics.ActiveReports.ActiveReport

    Public Sub New(ByVal Fecha As DateTime)
        MyBase.New()
        InitializeComponent()

        Dim oAlmacen As Almacen
        Dim oAlmacenMgr As New CatalogoAlmacenesManager(oAppContext)
        Dim oSAPMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        Dim pagoEcomm As New CatalogoFormasPagoManager(oAppContext, oConfigCierreFI)
        Dim dtPagosDetalle As DataTable
        oAlmacen = oAlmacenMgr.Load(oSAPMgr.Read_Centros())
        If Not oAlmacen Is Nothing Then

            Me.txtSucursal.Text = oAppContext.ApplicationConfiguration.Almacen & Space(1) & oAlmacen.Descripcion

        End If

        Me.txtFecha.Text = Format(Fecha, "dd/MM/yyyy")
        dtPagosDetalle = pagoEcomm.GetDetallePagosEcommerceByDate(Fecha).Tables(0)
        Me.DataSource = dtPagosDetalle
    End Sub

#Region "ActiveReports Designer generated code"
    Private WithEvents ReportHeader As ReportHeader = Nothing
    Private WithEvents GroupHeader1 As GroupHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents GroupFooter1 As GroupFooter = Nothing
    Private WithEvents ReportFooter As ReportFooter = Nothing
    Private Label1 As Label = Nothing
    Private Label2 As Label = Nothing
    Private Label3 As Label = Nothing
    Private txtSucursal As TextBox = Nothing
    Private txtFecha As TextBox = Nothing
    Private Label11 As Label = Nothing
    Private Label4 As Label = Nothing
    Private Label6 As Label = Nothing
    Private Label7 As Label = Nothing
    Private Label8 As Label = Nothing
    Private Label9 As Label = Nothing
    Private Label16 As Label = Nothing
    Private Shape1 As Shape = Nothing
    Private txtFolio As TextBox = Nothing
    Private txtIFactura As TextBox = Nothing
    Private txtPDPV As TextBox = Nothing
    Private txtNDPV As TextBox = Nothing
    Private TextBox6 As TextBox = Nothing
    Private txtIVale As TextBox = Nothing
    Private Shape5 As Shape = Nothing
    Private TextBox9 As TextBox = Nothing
    Private TextBox10 As TextBox = Nothing
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptVentasEcommerceDPVale))
        Me.Detail = New DataDynamics.ActiveReports.Detail()
        Me.txtFolio = New DataDynamics.ActiveReports.TextBox()
        Me.txtIFactura = New DataDynamics.ActiveReports.TextBox()
        Me.txtPDPV = New DataDynamics.ActiveReports.TextBox()
        Me.txtNDPV = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox6 = New DataDynamics.ActiveReports.TextBox()
        Me.txtIVale = New DataDynamics.ActiveReports.TextBox()
        Me.ReportHeader = New DataDynamics.ActiveReports.ReportHeader()
        Me.ReportFooter = New DataDynamics.ActiveReports.ReportFooter()
        Me.Shape5 = New DataDynamics.ActiveReports.Shape()
        Me.TextBox9 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox10 = New DataDynamics.ActiveReports.TextBox()
        Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader()
        Me.Label1 = New DataDynamics.ActiveReports.Label()
        Me.Label2 = New DataDynamics.ActiveReports.Label()
        Me.Label3 = New DataDynamics.ActiveReports.Label()
        Me.txtSucursal = New DataDynamics.ActiveReports.TextBox()
        Me.txtFecha = New DataDynamics.ActiveReports.TextBox()
        Me.Label11 = New DataDynamics.ActiveReports.Label()
        Me.Label4 = New DataDynamics.ActiveReports.Label()
        Me.Label6 = New DataDynamics.ActiveReports.Label()
        Me.Label7 = New DataDynamics.ActiveReports.Label()
        Me.Label8 = New DataDynamics.ActiveReports.Label()
        Me.Label9 = New DataDynamics.ActiveReports.Label()
        Me.Label16 = New DataDynamics.ActiveReports.Label()
        Me.Shape1 = New DataDynamics.ActiveReports.Shape()
        Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter()
        CType(Me.txtFolio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtIFactura, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPDPV, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNDPV, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtIVale, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSucursal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.ColumnSpacing = 0.0!
        Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtFolio, Me.txtIFactura, Me.txtPDPV, Me.txtNDPV, Me.TextBox6, Me.txtIVale})
        Me.Detail.Height = 0.1666667!
        Me.Detail.Name = "Detail"
        '
        'txtFolio
        '
        Me.txtFolio.DataField = "NumOrden"
        Me.txtFolio.Height = 0.1574803!
        Me.txtFolio.Left = 0.0!
        Me.txtFolio.Name = "txtFolio"
        Me.txtFolio.Style = "text-align: center; font-size: 8.25pt"
        Me.txtFolio.Text = Nothing
        Me.txtFolio.Top = 0.0!
        Me.txtFolio.Width = 1.341!
        '
        'txtIFactura
        '
        Me.txtIFactura.DataField = "TotalPago"
        Me.txtIFactura.Height = 0.1574803!
        Me.txtIFactura.Left = 1.341!
        Me.txtIFactura.Name = "txtIFactura"
        Me.txtIFactura.OutputFormat = resources.GetString("txtIFactura.OutputFormat")
        Me.txtIFactura.Style = "text-align: right; font-size: 8.25pt"
        Me.txtIFactura.Text = Nothing
        Me.txtIFactura.Top = 0.0!
        Me.txtIFactura.Width = 1.164!
        '
        'txtPDPV
        '
        Me.txtPDPV.DataField = "TotalPago"
        Me.txtPDPV.Height = 0.1574803!
        Me.txtPDPV.Left = 2.505!
        Me.txtPDPV.Name = "txtPDPV"
        Me.txtPDPV.OutputFormat = resources.GetString("txtPDPV.OutputFormat")
        Me.txtPDPV.Style = "text-align: right; font-size: 8.25pt"
        Me.txtPDPV.Text = Nothing
        Me.txtPDPV.Top = 0.009000001!
        Me.txtPDPV.Width = 1.292!
        '
        'txtNDPV
        '
        Me.txtNDPV.DataField = "CodVale"
        Me.txtNDPV.Height = 0.1574803!
        Me.txtNDPV.Left = 3.797!
        Me.txtNDPV.Name = "txtNDPV"
        Me.txtNDPV.Style = "text-align: center; font-size: 8.25pt"
        Me.txtNDPV.Text = Nothing
        Me.txtNDPV.Top = 0.009000001!
        Me.txtNDPV.Width = 1.078!
        '
        'TextBox6
        '
        Me.TextBox6.DataField = "CodVendedor"
        Me.TextBox6.Height = 0.1574803!
        Me.TextBox6.Left = 4.875!
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.OutputFormat = resources.GetString("TextBox6.OutputFormat")
        Me.TextBox6.Style = "text-align: center; font-size: 8.25pt"
        Me.TextBox6.Text = Nothing
        Me.TextBox6.Top = 0.009000001!
        Me.TextBox6.Width = 1.041!
        '
        'txtIVale
        '
        Me.txtIVale.DataField = "TotalPago"
        Me.txtIVale.Height = 0.1574803!
        Me.txtIVale.Left = 5.916!
        Me.txtIVale.Name = "txtIVale"
        Me.txtIVale.OutputFormat = resources.GetString("txtIVale.OutputFormat")
        Me.txtIVale.Style = "text-align: right; font-size: 8.25pt"
        Me.txtIVale.Text = Nothing
        Me.txtIVale.Top = 0.009000001!
        Me.txtIVale.Width = 1.0205!
        '
        'ReportHeader
        '
        Me.ReportHeader.Height = 0.0!
        Me.ReportHeader.Name = "ReportHeader"
        '
        'ReportFooter
        '
        Me.ReportFooter.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape5, Me.TextBox9, Me.TextBox10})
        Me.ReportFooter.Height = 0.2909722!
        Me.ReportFooter.Name = "ReportFooter"
        '
        'Shape5
        '
        Me.Shape5.Height = 0.25!
        Me.Shape5.Left = 0.0!
        Me.Shape5.Name = "Shape5"
        Me.Shape5.RoundingRadius = 9.999999!
        Me.Shape5.Top = 0.0!
        Me.Shape5.Width = 6.9375!
        '
        'TextBox9
        '
        Me.TextBox9.DataField = "TotalPago"
        Me.TextBox9.Height = 0.2!
        Me.TextBox9.Left = 1.341!
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.OutputFormat = resources.GetString("TextBox9.OutputFormat")
        Me.TextBox9.Style = "text-align: right; font-size: 8.25pt"
        Me.TextBox9.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
        Me.TextBox9.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
        Me.TextBox9.Text = "TextBox9"
        Me.TextBox9.Top = 0.0!
        Me.TextBox9.Width = 1.164!
        '
        'TextBox10
        '
        Me.TextBox10.DataField = "TotalPago"
        Me.TextBox10.Height = 0.2!
        Me.TextBox10.Left = 2.505!
        Me.TextBox10.Name = "TextBox10"
        Me.TextBox10.OutputFormat = resources.GetString("TextBox10.OutputFormat")
        Me.TextBox10.Style = "text-align: right; font-size: 8.25pt"
        Me.TextBox10.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
        Me.TextBox10.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
        Me.TextBox10.Text = "TextBox10"
        Me.TextBox10.Top = 0.0!
        Me.TextBox10.Width = 1.292!
        '
        'GroupHeader1
        '
        Me.GroupHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label1, Me.Label2, Me.Label3, Me.txtSucursal, Me.txtFecha, Me.Label11, Me.Label4, Me.Label6, Me.Label7, Me.Label8, Me.Label9, Me.Label16, Me.Shape1})
        Me.GroupHeader1.Height = 1.020833!
        Me.GroupHeader1.Name = "GroupHeader1"
        '
        'Label1
        '
        Me.Label1.Height = 0.2!
        Me.Label1.HyperLink = Nothing
        Me.Label1.Left = 2.0625!
        Me.Label1.Name = "Label1"
        Me.Label1.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
        Me.Label1.Text = "Reporte de Pagos Ecommerce Vale"
        Me.Label1.Top = 0.0!
        Me.Label1.Width = 2.8125!
        '
        'Label2
        '
        Me.Label2.Height = 0.2!
        Me.Label2.HyperLink = Nothing
        Me.Label2.Left = 2.0!
        Me.Label2.Name = "Label2"
        Me.Label2.Style = "font-weight: bold; font-size: 8.25pt"
        Me.Label2.Text = "Sucursal:"
        Me.Label2.Top = 0.375!
        Me.Label2.Width = 0.5826772!
        '
        'Label3
        '
        Me.Label3.Height = 0.2!
        Me.Label3.HyperLink = Nothing
        Me.Label3.Left = 3.0!
        Me.Label3.Name = "Label3"
        Me.Label3.Style = "font-weight: bold; font-size: 8.25pt"
        Me.Label3.Text = "Fecha:"
        Me.Label3.Top = 0.1875!
        Me.Label3.Width = 0.4576772!
        '
        'txtSucursal
        '
        Me.txtSucursal.Height = 0.2!
        Me.txtSucursal.Left = 2.625!
        Me.txtSucursal.Name = "txtSucursal"
        Me.txtSucursal.Style = "font-size: 8.25pt"
        Me.txtSucursal.Text = "TextBox7"
        Me.txtSucursal.Top = 0.375!
        Me.txtSucursal.Width = 2.413878!
        '
        'txtFecha
        '
        Me.txtFecha.Height = 0.2!
        Me.txtFecha.Left = 3.5!
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.Style = "font-size: 8.25pt"
        Me.txtFecha.Text = "TextBox8"
        Me.txtFecha.Top = 0.1875!
        Me.txtFecha.Width = 0.75!
        '
        'Label11
        '
        Me.Label11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label11.Height = 0.1875!
        Me.Label11.HyperLink = Nothing
        Me.Label11.Left = 5.916!
        Me.Label11.Name = "Label11"
        Me.Label11.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
        Me.Label11.Text = "DPV Emitido"
        Me.Label11.Top = 0.625!
        Me.Label11.Width = 1.021!
        '
        'Label4
        '
        Me.Label4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label4.Height = 0.1875!
        Me.Label4.HyperLink = Nothing
        Me.Label4.Left = 0.0!
        Me.Label4.Name = "Label4"
        Me.Label4.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
        Me.Label4.Text = "Folio"
        Me.Label4.Top = 0.8330001!
        Me.Label4.Width = 1.341!
        '
        'Label6
        '
        Me.Label6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label6.Height = 0.1875!
        Me.Label6.HyperLink = Nothing
        Me.Label6.Left = 1.341!
        Me.Label6.Name = "Label6"
        Me.Label6.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
        Me.Label6.Text = "Imp. Factura"
        Me.Label6.Top = 0.8330001!
        Me.Label6.Width = 1.164!
        '
        'Label7
        '
        Me.Label7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label7.Height = 0.1875!
        Me.Label7.HyperLink = Nothing
        Me.Label7.Left = 2.505!
        Me.Label7.Name = "Label7"
        Me.Label7.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
        Me.Label7.Text = "Pago DPV"
        Me.Label7.Top = 0.8330001!
        Me.Label7.Width = 1.292!
        '
        'Label8
        '
        Me.Label8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label8.Height = 0.1875!
        Me.Label8.HyperLink = Nothing
        Me.Label8.Left = 3.797!
        Me.Label8.Name = "Label8"
        Me.Label8.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
        Me.Label8.Text = "No. DPV"
        Me.Label8.Top = 0.8330001!
        Me.Label8.Width = 1.078!
        '
        'Label9
        '
        Me.Label9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label9.Height = 0.1875!
        Me.Label9.HyperLink = Nothing
        Me.Label9.Left = 4.875!
        Me.Label9.Name = "Label9"
        Me.Label9.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
        Me.Label9.Text = "Asociado"
        Me.Label9.Top = 0.8330001!
        Me.Label9.Width = 1.041!
        '
        'Label16
        '
        Me.Label16.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label16.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label16.Height = 0.1875!
        Me.Label16.HyperLink = Nothing
        Me.Label16.Left = 5.916!
        Me.Label16.Name = "Label16"
        Me.Label16.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
        Me.Label16.Text = "Importe"
        Me.Label16.Top = 0.8330001!
        Me.Label16.Width = 1.0205!
        '
        'Shape1
        '
        Me.Shape1.Height = 1.0!
        Me.Shape1.Left = 0.0!
        Me.Shape1.Name = "Shape1"
        Me.Shape1.RoundingRadius = 9.999999!
        Me.Shape1.Top = 0.0!
        Me.Shape1.Width = 6.9375!
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Height = 0.0!
        Me.GroupFooter1.Name = "GroupFooter1"
        '
        'rptVentasEcommerceDPVale
        '
        Me.MasterReport = False
        Me.PageSettings.Margins.Bottom = 0.7875!
        Me.PageSettings.Margins.Left = 0.39375!
        Me.PageSettings.Margins.Right = 0.39375!
        Me.PageSettings.Margins.Top = 0.7875!
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 6.989583!
        Me.Sections.Add(Me.ReportHeader)
        Me.Sections.Add(Me.GroupHeader1)
        Me.Sections.Add(Me.Detail)
        Me.Sections.Add(Me.GroupFooter1)
        Me.Sections.Add(Me.ReportFooter)
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" & _
            "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei" & _
            "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" & _
            "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit", "Heading3", "Normal"))
        CType(Me.txtFolio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtIFactura, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPDPV, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNDPV, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtIVale, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSucursal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

#End Region

End Class
