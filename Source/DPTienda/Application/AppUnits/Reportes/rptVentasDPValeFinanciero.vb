Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Imports DportenisPro.DPTienda.ApplicationUnits.DPValeFinanciero
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU

Public Class rptVentasDPValeFinanciero
    Inherits DataDynamics.ActiveReports.ActiveReport

    Dim oDPVFMgr As DPValeFinancieroManager
    Dim oAlmacenMgr As CatalogoAlmacenesManager
    Dim oAlmacen As Almacen
    Dim oSAPMgr As ProcesoSAPManager
    Dim dtDetalle As DataTable

    Public Sub New(ByVal Fecha As Date)
        MyBase.New()
        InitializeComponent()

        Me.txtFecha.Text = Format(Fecha, "dd/MM/yyyy")
        Dim oSAPMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        oAlmacenMgr = New CatalogoAlmacenesManager(oAppContext)
        oAlmacen = oAlmacenMgr.Load(oSAPMgr.Read_Centros) 'oAppContext.ApplicationConfiguration.Almacen)
        If Not oAlmacen Is Nothing Then
            Me.txtSucursal.Text = oAlmacen.ID & " " & oAlmacen.Descripcion
        End If

        oDPVFMgr = New DPValeFinancieroManager(oAppContext, oConfigCierreFI)
        dtDetalle = oDPVFMgr.GetAll(Format(Fecha, "dd/MM/yyyy")).Tables(0)

        oSAPMgr = New ProcesoSAPManager(oAppContext, oAppSAPConfig)

        ModificarDetalle()

        Me.DataSource = dtDetalle

    End Sub
#Region "ActiveReports Designer generated code"
    Private WithEvents PageHeader As PageHeader = Nothing
    Private WithEvents GroupHeader1 As GroupHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents GroupFooter1 As GroupFooter = Nothing
    Private WithEvents PageFooter As PageFooter = Nothing
	Private Label1 As Label = Nothing
	Private Label2 As Label = Nothing
	Private Label3 As Label = Nothing
	Private txtSucursal As TextBox = Nothing
	Private txtFecha As TextBox = Nothing
	Private Label4 As Label = Nothing
	Private Label5 As Label = Nothing
	Private Label6 As Label = Nothing
	Private Label7 As Label = Nothing
	Private Label8 As Label = Nothing
	Private Label9 As Label = Nothing
	Private Shape1 As Shape = Nothing
	Private txtFolio As TextBox = Nothing
	Private txtCliente As TextBox = Nothing
	Private txtIFactura As TextBox = Nothing
	Private txtIntereses As TextBox = Nothing
	Private txtNDPV As TextBox = Nothing
	Private txtAsociado As TextBox = Nothing
	Private Shape5 As Shape = Nothing
	Private txtImporteTotal As TextBox = Nothing
	Private txtInteresesTotal As TextBox = Nothing
	Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptVentasDPValeFinanciero))
        Me.Detail = New DataDynamics.ActiveReports.Detail()
        Me.txtFolio = New DataDynamics.ActiveReports.TextBox()
        Me.txtCliente = New DataDynamics.ActiveReports.TextBox()
        Me.txtIFactura = New DataDynamics.ActiveReports.TextBox()
        Me.txtIntereses = New DataDynamics.ActiveReports.TextBox()
        Me.txtNDPV = New DataDynamics.ActiveReports.TextBox()
        Me.txtAsociado = New DataDynamics.ActiveReports.TextBox()
        Me.PageHeader = New DataDynamics.ActiveReports.PageHeader()
        Me.PageFooter = New DataDynamics.ActiveReports.PageFooter()
        Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader()
        Me.Label1 = New DataDynamics.ActiveReports.Label()
        Me.Label2 = New DataDynamics.ActiveReports.Label()
        Me.Label3 = New DataDynamics.ActiveReports.Label()
        Me.txtSucursal = New DataDynamics.ActiveReports.TextBox()
        Me.txtFecha = New DataDynamics.ActiveReports.TextBox()
        Me.Label4 = New DataDynamics.ActiveReports.Label()
        Me.Label5 = New DataDynamics.ActiveReports.Label()
        Me.Label6 = New DataDynamics.ActiveReports.Label()
        Me.Label7 = New DataDynamics.ActiveReports.Label()
        Me.Label8 = New DataDynamics.ActiveReports.Label()
        Me.Label9 = New DataDynamics.ActiveReports.Label()
        Me.Shape1 = New DataDynamics.ActiveReports.Shape()
        Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter()
        Me.Shape5 = New DataDynamics.ActiveReports.Shape()
        Me.txtImporteTotal = New DataDynamics.ActiveReports.TextBox()
        Me.txtInteresesTotal = New DataDynamics.ActiveReports.TextBox()
        CType(Me.txtFolio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtIFactura, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtIntereses, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNDPV, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAsociado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSucursal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtImporteTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtInteresesTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.ColumnSpacing = 0.0!
        Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtFolio, Me.txtCliente, Me.txtIFactura, Me.txtIntereses, Me.txtNDPV, Me.txtAsociado})
        Me.Detail.Height = 0.2076389!
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
        Me.txtFolio.Width = 0.8125!
        '
        'txtCliente
        '
        Me.txtCliente.DataField = "Cliente"
        Me.txtCliente.Height = 0.1574803!
        Me.txtCliente.Left = 0.8125!
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.Style = "font-size: 8.25pt"
        Me.txtCliente.Text = Nothing
        Me.txtCliente.Top = 0.0!
        Me.txtCliente.Width = 2.75!
        '
        'txtIFactura
        '
        Me.txtIFactura.DataField = "Importe"
        Me.txtIFactura.Height = 0.1574803!
        Me.txtIFactura.Left = 3.576525!
        Me.txtIFactura.Name = "txtIFactura"
        Me.txtIFactura.OutputFormat = resources.GetString("txtIFactura.OutputFormat")
        Me.txtIFactura.Style = "text-align: right; font-size: 8.25pt"
        Me.txtIFactura.Text = Nothing
        Me.txtIFactura.Top = 0.0!
        Me.txtIFactura.Width = 0.7359743!
        '
        'txtIntereses
        '
        Me.txtIntereses.DataField = "Intereses"
        Me.txtIntereses.Height = 0.1574803!
        Me.txtIntereses.Left = 4.3125!
        Me.txtIntereses.Name = "txtIntereses"
        Me.txtIntereses.OutputFormat = resources.GetString("txtIntereses.OutputFormat")
        Me.txtIntereses.Style = "text-align: right; font-size: 8.25pt"
        Me.txtIntereses.Text = Nothing
        Me.txtIntereses.Top = 0.0!
        Me.txtIntereses.Width = 0.6875!
        '
        'txtNDPV
        '
        Me.txtNDPV.DataField = "DPVale"
        Me.txtNDPV.Height = 0.1574803!
        Me.txtNDPV.Left = 5.0!
        Me.txtNDPV.Name = "txtNDPV"
        Me.txtNDPV.Style = "text-align: center; font-size: 8.25pt"
        Me.txtNDPV.Text = Nothing
        Me.txtNDPV.Top = 0.0!
        Me.txtNDPV.Width = 0.6875!
        '
        'txtAsociado
        '
        Me.txtAsociado.DataField = "IDAsociado"
        Me.txtAsociado.Height = 0.1574803!
        Me.txtAsociado.Left = 5.710466!
        Me.txtAsociado.Name = "txtAsociado"
        Me.txtAsociado.Style = "text-align: center; font-size: 8.25pt"
        Me.txtAsociado.Text = Nothing
        Me.txtAsociado.Top = 0.0!
        Me.txtAsociado.Width = 0.6020341!
        '
        'PageHeader
        '
        Me.PageHeader.Height = 0.0!
        Me.PageHeader.Name = "PageHeader"
        '
        'PageFooter
        '
        Me.PageFooter.Height = 0.0!
        Me.PageFooter.Name = "PageFooter"
        '
        'GroupHeader1
        '
        Me.GroupHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label1, Me.Label2, Me.Label3, Me.txtSucursal, Me.txtFecha, Me.Label4, Me.Label5, Me.Label6, Me.Label7, Me.Label8, Me.Label9, Me.Shape1})
        Me.GroupHeader1.Height = 1.0!
        Me.GroupHeader1.Name = "GroupHeader1"
        '
        'Label1
        '
        Me.Label1.Height = 0.2!
        Me.Label1.HyperLink = Nothing
        Me.Label1.Left = 1.8125!
        Me.Label1.Name = "Label1"
        Me.Label1.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
        Me.Label1.Text = "Reporte de Ventas del día Credito DPortenis Vale Financiero"
        Me.Label1.Top = 0.0!
        Me.Label1.Width = 3.375!
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
        Me.Label4.Top = 0.8125!
        Me.Label4.Width = 0.8125!
        '
        'Label5
        '
        Me.Label5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label5.Height = 0.1875!
        Me.Label5.HyperLink = Nothing
        Me.Label5.Left = 0.8125!
        Me.Label5.Name = "Label5"
        Me.Label5.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
        Me.Label5.Text = "Cliente"
        Me.Label5.Top = 0.813!
        Me.Label5.Width = 2.75!
        '
        'Label6
        '
        Me.Label6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label6.Height = 0.1875!
        Me.Label6.HyperLink = Nothing
        Me.Label6.Left = 3.5625!
        Me.Label6.Name = "Label6"
        Me.Label6.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
        Me.Label6.Text = "Imp. Factura"
        Me.Label6.Top = 0.8125!
        Me.Label6.Width = 0.748032!
        '
        'Label7
        '
        Me.Label7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label7.Height = 0.1875!
        Me.Label7.HyperLink = Nothing
        Me.Label7.Left = 4.3125!
        Me.Label7.Name = "Label7"
        Me.Label7.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
        Me.Label7.Text = "Intereses"
        Me.Label7.Top = 0.8125!
        Me.Label7.Width = 0.6875!
        '
        'Label8
        '
        Me.Label8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label8.Height = 0.1875!
        Me.Label8.HyperLink = Nothing
        Me.Label8.Left = 5.0!
        Me.Label8.Name = "Label8"
        Me.Label8.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
        Me.Label8.Text = "No. DPV"
        Me.Label8.Top = 0.8125!
        Me.Label8.Width = 0.6875!
        '
        'Label9
        '
        Me.Label9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label9.Height = 0.1875!
        Me.Label9.HyperLink = Nothing
        Me.Label9.Left = 5.6875!
        Me.Label9.Name = "Label9"
        Me.Label9.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
        Me.Label9.Text = "Asociado"
        Me.Label9.Top = 0.8125!
        Me.Label9.Width = 0.625!
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
        Me.GroupFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape5, Me.txtImporteTotal, Me.txtInteresesTotal})
        Me.GroupFooter1.Height = 0.2909722!
        Me.GroupFooter1.Name = "GroupFooter1"
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
        'txtImporteTotal
        '
        Me.txtImporteTotal.DataField = "Importe"
        Me.txtImporteTotal.Height = 0.2!
        Me.txtImporteTotal.Left = 3.572917!
        Me.txtImporteTotal.Name = "txtImporteTotal"
        Me.txtImporteTotal.OutputFormat = resources.GetString("txtImporteTotal.OutputFormat")
        Me.txtImporteTotal.Style = "text-align: right; font-size: 8.25pt"
        Me.txtImporteTotal.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
        Me.txtImporteTotal.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
        Me.txtImporteTotal.Text = "TextBox9"
        Me.txtImporteTotal.Top = 0.0!
        Me.txtImporteTotal.Width = 0.75!
        '
        'txtInteresesTotal
        '
        Me.txtInteresesTotal.DataField = "Intereses"
        Me.txtInteresesTotal.Height = 0.2!
        Me.txtInteresesTotal.Left = 4.313!
        Me.txtInteresesTotal.Name = "txtInteresesTotal"
        Me.txtInteresesTotal.OutputFormat = resources.GetString("txtInteresesTotal.OutputFormat")
        Me.txtInteresesTotal.Style = "text-align: right; font-size: 8.25pt"
        Me.txtInteresesTotal.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
        Me.txtInteresesTotal.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
        Me.txtInteresesTotal.Text = "TextBox10"
        Me.txtInteresesTotal.Top = 0.0!
        Me.txtInteresesTotal.Width = 0.7217847!
        '
        'rptVentasDPValeFinanciero
        '
        Me.MasterReport = False
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 6.979167!
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
        CType(Me.txtFolio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCliente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtIFactura, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtIntereses, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNDPV, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAsociado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSucursal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtImporteTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtInteresesTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

#End Region

    Private Sub ModificarDetalle()

        Dim oCol As New DataColumn

        oCol.Caption = "Cliente"
        oCol.ColumnName = "Cliente"

        dtDetalle.Columns.Add(oCol)
        dtDetalle.AcceptChanges()

        For Each oRow As DataRow In dtDetalle.Rows

            With oRow
                !Cliente = oSAPMgr.ZBAPI_NOMBRE_CLIENTE(!IDCLiente)
            End With

        Next

    End Sub

End Class
