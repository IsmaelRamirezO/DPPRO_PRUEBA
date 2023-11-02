Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU

Public Class rptApartadosVigentes
Inherits DataDynamics.ActiveReports.ActiveReport
    Public Sub New(ByVal dsDetalle As DataSet)
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
	Private txtSucursal As TextBox = Nothing
	Private txtFecha As TextBox = Nothing
	Private Label3 As Label = Nothing
	Private Label4 As Label = Nothing
	Private Label5 As Label = Nothing
	Private Label6 As Label = Nothing
	Private Label7 As Label = Nothing
	Private Label8 As Label = Nothing
	Private Label9 As Label = Nothing
	Private Label10 As Label = Nothing
	Private Label11 As Label = Nothing
	Private Label12 As Label = Nothing
	Private Label13 As Label = Nothing
	Private Shape3 As Shape = Nothing
	Private txtFolio As TextBox = Nothing
	Private TextBox2 As TextBox = Nothing
	Private txtClienteID As TextBox = Nothing
	Private txtTotal As TextBox = Nothing
	Private txtAbonos As TextBox = Nothing
	Private txtSaldo As TextBox = Nothing
	Private txtCodArticulo As TextBox = Nothing
	Private txtDescripcion As TextBox = Nothing
	Private TextBox9 As TextBox = Nothing
	Private txtCantidad As TextBox = Nothing
	Private Line10 As Line = Nothing
	Private Line13 As Line = Nothing
	Private Label14 As Label = Nothing
	Private txtImporte As TextBox = Nothing
	Private TextBox11 As TextBox = Nothing
	Private TextBox12 As TextBox = Nothing
	Private TextBox13 As TextBox = Nothing
	Private Line12 As Line = Nothing
	Private Shape2 As Shape = Nothing
	Private Line2 As Line = Nothing
	Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptApartadosVigentes))
            Me.Detail = New DataDynamics.ActiveReports.Detail()
            Me.PageHeader = New DataDynamics.ActiveReports.PageHeader()
            Me.PageFooter = New DataDynamics.ActiveReports.PageFooter()
            Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader()
            Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter()
            Me.Shape1 = New DataDynamics.ActiveReports.Shape()
            Me.Label1 = New DataDynamics.ActiveReports.Label()
            Me.Label2 = New DataDynamics.ActiveReports.Label()
            Me.txtSucursal = New DataDynamics.ActiveReports.TextBox()
            Me.txtFecha = New DataDynamics.ActiveReports.TextBox()
            Me.Label3 = New DataDynamics.ActiveReports.Label()
            Me.Label4 = New DataDynamics.ActiveReports.Label()
            Me.Label5 = New DataDynamics.ActiveReports.Label()
            Me.Label6 = New DataDynamics.ActiveReports.Label()
            Me.Label7 = New DataDynamics.ActiveReports.Label()
            Me.Label8 = New DataDynamics.ActiveReports.Label()
            Me.Label9 = New DataDynamics.ActiveReports.Label()
            Me.Label10 = New DataDynamics.ActiveReports.Label()
            Me.Label11 = New DataDynamics.ActiveReports.Label()
            Me.Label12 = New DataDynamics.ActiveReports.Label()
            Me.Label13 = New DataDynamics.ActiveReports.Label()
            Me.Shape3 = New DataDynamics.ActiveReports.Shape()
            Me.txtFolio = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox2 = New DataDynamics.ActiveReports.TextBox()
            Me.txtClienteID = New DataDynamics.ActiveReports.TextBox()
            Me.txtTotal = New DataDynamics.ActiveReports.TextBox()
            Me.txtAbonos = New DataDynamics.ActiveReports.TextBox()
            Me.txtSaldo = New DataDynamics.ActiveReports.TextBox()
            Me.txtCodArticulo = New DataDynamics.ActiveReports.TextBox()
            Me.txtDescripcion = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox9 = New DataDynamics.ActiveReports.TextBox()
            Me.txtCantidad = New DataDynamics.ActiveReports.TextBox()
            Me.Line10 = New DataDynamics.ActiveReports.Line()
            Me.Line13 = New DataDynamics.ActiveReports.Line()
            Me.Label14 = New DataDynamics.ActiveReports.Label()
            Me.txtImporte = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox11 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox12 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox13 = New DataDynamics.ActiveReports.TextBox()
            Me.Line12 = New DataDynamics.ActiveReports.Line()
            Me.Shape2 = New DataDynamics.ActiveReports.Shape()
            Me.Line2 = New DataDynamics.ActiveReports.Line()
            CType(Me.Label1,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtSucursal,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFecha,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label3,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label5,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label6,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label7,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label8,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label9,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label10,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label11,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label12,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label13,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFolio,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox2,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtClienteID,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtTotal,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtAbonos,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtSaldo,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtCodArticulo,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtDescripcion,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox9,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtCantidad,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label14,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtImporte,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox11,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox12,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox13,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
            '
            'Detail
            '
            Me.Detail.ColumnSpacing = 0!
            Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtFolio, Me.TextBox2, Me.txtClienteID, Me.txtTotal, Me.txtAbonos, Me.txtSaldo, Me.txtCodArticulo, Me.txtDescripcion, Me.TextBox9, Me.txtCantidad, Me.Line10, Me.Line13})
            Me.Detail.Height = 0.2388889!
            Me.Detail.Name = "Detail"
            '
            'PageHeader
            '
            Me.PageHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape1, Me.Label1, Me.Label2, Me.txtSucursal, Me.txtFecha})
            Me.PageHeader.Height = 0.5729167!
            Me.PageHeader.Name = "PageHeader"
            '
            'PageFooter
            '
            Me.PageFooter.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Line2})
            Me.PageFooter.Height = 0.25!
            Me.PageFooter.Name = "PageFooter"
            '
            'GroupHeader1
            '
            Me.GroupHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label3, Me.Label4, Me.Label5, Me.Label6, Me.Label7, Me.Label8, Me.Label9, Me.Label10, Me.Label11, Me.Label12, Me.Label13, Me.Shape3})
            Me.GroupHeader1.Height = 0.25!
            Me.GroupHeader1.Name = "GroupHeader1"
            '
            'GroupFooter1
            '
            Me.GroupFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label14, Me.txtImporte, Me.TextBox11, Me.TextBox12, Me.TextBox13, Me.Line12, Me.Shape2})
            Me.GroupFooter1.Height = 0.3222222!
            Me.GroupFooter1.Name = "GroupFooter1"
            '
            'Shape1
            '
            Me.Shape1.Height = 0.5905511!
            Me.Shape1.Left = 0!
            Me.Shape1.Name = "Shape1"
            Me.Shape1.RoundingRadius = 9.999999!
            Me.Shape1.Top = 0!
            Me.Shape1.Width = 7.480313!
            '
            'Label1
            '
            Me.Label1.Height = 0.2!
            Me.Label1.HyperLink = Nothing
            Me.Label1.Left = 2.288386!
            Me.Label1.Name = "Label1"
            Me.Label1.Style = "text-align: center"
            Me.Label1.Text = "REPORTE DE APARTADOS EN DETALLE"
            Me.Label1.Top = 0!
            Me.Label1.Width = 2.795276!
            '
            'Label2
            '
            Me.Label2.Height = 0.2!
            Me.Label2.HyperLink = Nothing
            Me.Label2.Left = 1.500492!
            Me.Label2.Name = "Label2"
            Me.Label2.Style = ""
            Me.Label2.Text = "Sucursal.:"
            Me.Label2.Top = 0.2755906!
            Me.Label2.Width = 0.6692913!
            '
            'txtSucursal
            '
            Me.txtSucursal.Height = 0.2!
            Me.txtSucursal.Left = 2.248524!
            Me.txtSucursal.Name = "txtSucursal"
            Me.txtSucursal.Text = "TextBox1"
            Me.txtSucursal.Top = 0.2755906!
            Me.txtSucursal.Width = 2.952756!
            '
            'txtFecha
            '
            Me.txtFecha.Height = 0.2!
            Me.txtFecha.Left = 6.141732!
            Me.txtFecha.Name = "txtFecha"
            Me.txtFecha.Top = 0.1968504!
            Me.txtFecha.Width = 1!
            '
            'Label3
            '
            Me.Label3.Height = 0.2!
            Me.Label3.HyperLink = Nothing
            Me.Label3.Left = -0.02312992!
            Me.Label3.Name = "Label3"
            Me.Label3.Style = "text-align: center"
            Me.Label3.Text = "Folio"
            Me.Label3.Top = 0!
            Me.Label3.Width = 0.488681!
            '
            'Label4
            '
            Me.Label4.Height = 0.2!
            Me.Label4.HyperLink = Nothing
            Me.Label4.Left = 0.5280511!
            Me.Label4.Name = "Label4"
            Me.Label4.Style = "text-align: center"
            Me.Label4.Text = "Fecha"
            Me.Label4.Top = 0!
            Me.Label4.Width = 0.5905511!
            '
            'Label5
            '
            Me.Label5.Height = 0.2!
            Me.Label5.HyperLink = Nothing
            Me.Label5.Left = 1.197342!
            Me.Label5.Name = "Label5"
            Me.Label5.Style = "text-align: center"
            Me.Label5.Text = "Cliente"
            Me.Label5.Top = 0!
            Me.Label5.Width = 0.5743112!
            '
            'Label6
            '
            Me.Label6.Height = 0.2!
            Me.Label6.HyperLink = Nothing
            Me.Label6.Left = 1.859744!
            Me.Label6.Name = "Label6"
            Me.Label6.Style = "text-align: center"
            Me.Label6.Text = "Importe"
            Me.Label6.Top = 0!
            Me.Label6.Width = 0.748032!
            '
            'Label7
            '
            Me.Label7.Height = 0.2!
            Me.Label7.HyperLink = Nothing
            Me.Label7.Left = 2.686516!
            Me.Label7.Name = "Label7"
            Me.Label7.Style = "text-align: center"
            Me.Label7.Text = "Abonos"
            Me.Label7.Top = 0!
            Me.Label7.Width = 0.7086618!
            '
            'Label8
            '
            Me.Label8.Height = 0.2!
            Me.Label8.HyperLink = Nothing
            Me.Label8.Left = 3.444964!
            Me.Label8.Name = "Label8"
            Me.Label8.Style = "text-align: center"
            Me.Label8.Text = "Saldo"
            Me.Label8.Top = 0!
            Me.Label8.Width = 0.6357446!
            '
            'Label9
            '
            Me.Label9.Height = 0.2!
            Me.Label9.HyperLink = Nothing
            Me.Label9.Left = 4.307579!
            Me.Label9.Name = "Label9"
            Me.Label9.Style = ""
            Me.Label9.Text = "Código"
            Me.Label9.Top = 0!
            Me.Label9.Width = 0.5118108!
            '
            'Label10
            '
            Me.Label10.Height = 0.2!
            Me.Label10.HyperLink = Nothing
            Me.Label10.Left = 5.14813!
            Me.Label10.Name = "Label10"
            Me.Label10.Style = ""
            Me.Label10.Text = "Descripcion"
            Me.Label10.Top = 0!
            Me.Label10.Width = 0.7874014!
            '
            'Label11
            '
            Me.Label11.Height = 0.2!
            Me.Label11.HyperLink = Nothing
            Me.Label11.Left = 6.234252!
            Me.Label11.Name = "Label11"
            Me.Label11.Style = "text-align: center"
            Me.Label11.Text = "Talla"
            Me.Label11.Top = 0!
            Me.Label11.Width = 0.4724407!
            '
            'Label12
            '
            Me.Label12.Height = 0.2!
            Me.Label12.HyperLink = Nothing
            Me.Label12.Left = 9.0625!
            Me.Label12.Name = "Label12"
            Me.Label12.Style = ""
            Me.Label12.Text = "Label12"
            Me.Label12.Top = 0.0625!
            Me.Label12.Width = 1!
            '
            'Label13
            '
            Me.Label13.Height = 0.2!
            Me.Label13.HyperLink = Nothing
            Me.Label13.Left = 6.859252!
            Me.Label13.Name = "Label13"
            Me.Label13.Style = "text-align: center"
            Me.Label13.Text = "Cantidad"
            Me.Label13.Top = 0!
            Me.Label13.Width = 0.5954719!
            '
            'Shape3
            '
            Me.Shape3.Height = 0.2362205!
            Me.Shape3.Left = 0!
            Me.Shape3.Name = "Shape3"
            Me.Shape3.RoundingRadius = 9.999999!
            Me.Shape3.Top = 0!
            Me.Shape3.Width = 7.480313!
            '
            'txtFolio
            '
            Me.txtFolio.DataField = "FolioApartado"
            Me.txtFolio.Height = 0.2!
            Me.txtFolio.Left = 0!
            Me.txtFolio.Name = "txtFolio"
            Me.txtFolio.Style = "text-align: center; font-size: 8.25pt"
            Me.txtFolio.Top = 7.450583E-09!
            Me.txtFolio.Width = 0.3543307!
            '
            'TextBox2
            '
            Me.TextBox2.DataField = "Fecha"
            Me.TextBox2.Height = 0.2!
            Me.TextBox2.Left = 0.4330709!
            Me.TextBox2.Name = "TextBox2"
            Me.TextBox2.OutputFormat = resources.GetString("TextBox2.OutputFormat")
            Me.TextBox2.Style = "text-align: center; font-size: 8.25pt"
            Me.TextBox2.Top = 7.450583E-09!
            Me.TextBox2.Width = 0.6648622!
            '
            'txtClienteID
            '
            Me.txtClienteID.DataField = "ClienteID"
            Me.txtClienteID.Height = 0.2!
            Me.txtClienteID.Left = 1.13189!
            Me.txtClienteID.Name = "txtClienteID"
            Me.txtClienteID.Style = "font-size: 8.25pt"
            Me.txtClienteID.Top = 7.450583E-09!
            Me.txtClienteID.Width = 0.6643701!
            '
            'txtTotal
            '
            Me.txtTotal.DataField = "Total"
            Me.txtTotal.Height = 0.2!
            Me.txtTotal.Left = 1.843504!
            Me.txtTotal.Name = "txtTotal"
            Me.txtTotal.OutputFormat = resources.GetString("txtTotal.OutputFormat")
            Me.txtTotal.Style = "font-size: 8.25pt"
            Me.txtTotal.Top = 7.450583E-09!
            Me.txtTotal.Width = 0.7165354!
            '
            'txtAbonos
            '
            Me.txtAbonos.DataField = "Abonos"
            Me.txtAbonos.Height = 0.2!
            Me.txtAbonos.Left = 2.670276!
            Me.txtAbonos.Name = "txtAbonos"
            Me.txtAbonos.OutputFormat = resources.GetString("txtAbonos.OutputFormat")
            Me.txtAbonos.Style = "text-align: center; font-size: 8.25pt"
            Me.txtAbonos.Top = 7.450583E-09!
            Me.txtAbonos.Width = 0.7480313!
            '
            'txtSaldo
            '
            Me.txtSaldo.DataField = "Saldo"
            Me.txtSaldo.Height = 0.2!
            Me.txtSaldo.Left = 3.457677!
            Me.txtSaldo.Name = "txtSaldo"
            Me.txtSaldo.OutputFormat = resources.GetString("txtSaldo.OutputFormat")
            Me.txtSaldo.Style = "text-align: center; font-size: 8.25pt"
            Me.txtSaldo.Top = 7.450583E-09!
            Me.txtSaldo.Width = 0.629921!
            '
            'txtCodArticulo
            '
            Me.txtCodArticulo.DataField = "CodArticulo"
            Me.txtCodArticulo.Height = 0.2!
            Me.txtCodArticulo.Left = 4.126969!
            Me.txtCodArticulo.Name = "txtCodArticulo"
            Me.txtCodArticulo.Style = "font-size: 8.25pt"
            Me.txtCodArticulo.Top = 7.450583E-09!
            Me.txtCodArticulo.Width = 0.9517716!
            '
            'txtDescripcion
            '
            Me.txtDescripcion.DataField = "Descripcion"
            Me.txtDescripcion.Height = 0.2!
            Me.txtDescripcion.Left = 5.11565!
            Me.txtDescripcion.Name = "txtDescripcion"
            Me.txtDescripcion.Style = "font-size: 8.25pt"
            Me.txtDescripcion.Text = "AAAAAAAAAAAAAA"
            Me.txtDescripcion.Top = 0!
            Me.txtDescripcion.Width = 1.104823!
            '
            'TextBox9
            '
            Me.TextBox9.DataField = "Numero"
            Me.TextBox9.Height = 0.2!
            Me.TextBox9.Left = 6.259842!
            Me.TextBox9.Name = "TextBox9"
            Me.TextBox9.Style = "text-align: center; font-size: 8.25pt"
            Me.TextBox9.Top = 0!
            Me.TextBox9.Width = 0.4330707!
            '
            'txtCantidad
            '
            Me.txtCantidad.DataField = "Cantidad"
            Me.txtCantidad.Height = 0.2!
            Me.txtCantidad.Left = 6.877953!
            Me.txtCantidad.Name = "txtCantidad"
            Me.txtCantidad.OutputFormat = resources.GetString("txtCantidad.OutputFormat")
            Me.txtCantidad.Style = "text-align: center; font-size: 8.25pt"
            Me.txtCantidad.Top = 7.450583E-09!
            Me.txtCantidad.Width = 0.4488187!
            '
            'Line10
            '
            Me.Line10.Height = 0.2362205!
            Me.Line10.Left = 7.480313!
            Me.Line10.LineWeight = 1!
            Me.Line10.Name = "Line10"
            Me.Line10.Top = 0!
            Me.Line10.Width = 0!
            Me.Line10.X1 = 7.480313!
            Me.Line10.X2 = 7.480313!
            Me.Line10.Y1 = 0!
            Me.Line10.Y2 = 0.2362205!
            '
            'Line13
            '
            Me.Line13.Height = 0.2362205!
            Me.Line13.Left = 0.01156283!
            Me.Line13.LineWeight = 1!
            Me.Line13.Name = "Line13"
            Me.Line13.Top = 0!
            Me.Line13.Width = 0!
            Me.Line13.X1 = 0.01156283!
            Me.Line13.X2 = 0.01156283!
            Me.Line13.Y1 = 0!
            Me.Line13.Y2 = 0.2362205!
            '
            'Label14
            '
            Me.Label14.Height = 0.2!
            Me.Label14.HyperLink = Nothing
            Me.Label14.Left = 0.0625!
            Me.Label14.Name = "Label14"
            Me.Label14.Style = ""
            Me.Label14.Text = "Totales"
            Me.Label14.Top = 0.0625!
            Me.Label14.Width = 1!
            '
            'txtImporte
            '
            Me.txtImporte.DataField = "Total"
            Me.txtImporte.Height = 0.2!
            Me.txtImporte.Left = 1.505413!
            Me.txtImporte.Name = "txtImporte"
            Me.txtImporte.OutputFormat = resources.GetString("txtImporte.OutputFormat")
            Me.txtImporte.Style = "text-align: right; font-size: 8.25pt"
            Me.txtImporte.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
            Me.txtImporte.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
            Me.txtImporte.Top = 0.07874014!
            Me.txtImporte.Width = 1!
            '
            'TextBox11
            '
            Me.TextBox11.DataField = "Abonos"
            Me.TextBox11.Height = 0.2!
            Me.TextBox11.Left = 2.607776!
            Me.TextBox11.Name = "TextBox11"
            Me.TextBox11.OutputFormat = resources.GetString("TextBox11.OutputFormat")
            Me.TextBox11.Style = "text-align: right; font-size: 8.25pt"
            Me.TextBox11.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
            Me.TextBox11.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
            Me.TextBox11.Top = 0.07874014!
            Me.TextBox11.Width = 0.7480313!
            '
            'TextBox12
            '
            Me.TextBox12.DataField = "Saldo"
            Me.TextBox12.Height = 0.2!
            Me.TextBox12.Left = 3.395177!
            Me.TextBox12.Name = "TextBox12"
            Me.TextBox12.OutputFormat = resources.GetString("TextBox12.OutputFormat")
            Me.TextBox12.Style = "text-align: right; font-size: 8.25pt"
            Me.TextBox12.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
            Me.TextBox12.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
            Me.TextBox12.Top = 0.07874014!
            Me.TextBox12.Width = 0.6692915!
            '
            'TextBox13
            '
            Me.TextBox13.DataField = "Cantidad"
            Me.TextBox13.Height = 0.2!
            Me.TextBox13.Left = 6.889764!
            Me.TextBox13.Name = "TextBox13"
            Me.TextBox13.OutputFormat = resources.GetString("TextBox13.OutputFormat")
            Me.TextBox13.Style = "text-align: center; font-size: 8.25pt"
            Me.TextBox13.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
            Me.TextBox13.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
            Me.TextBox13.Top = 0.07874014!
            Me.TextBox13.Width = 0.4315939!
            '
            'Line12
            '
            Me.Line12.Height = 0.3149606!
            Me.Line12.Left = 0.00694466!
            Me.Line12.LineWeight = 1!
            Me.Line12.Name = "Line12"
            Me.Line12.Top = 0!
            Me.Line12.Width = 0!
            Me.Line12.X1 = 0.00694466!
            Me.Line12.X2 = 0.00694466!
            Me.Line12.Y1 = 0!
            Me.Line12.Y2 = 0.3149606!
            '
            'Shape2
            '
            Me.Shape2.Height = 0.3149606!
            Me.Shape2.Left = 0!
            Me.Shape2.Name = "Shape2"
            Me.Shape2.RoundingRadius = 9.999999!
            Me.Shape2.Top = 0!
            Me.Shape2.Width = 7.480313!
            '
            'Line2
            '
            Me.Line2.Height = 0.006944444!
            Me.Line2.Left = 0!
            Me.Line2.LineWeight = 1!
            Me.Line2.Name = "Line2"
            Me.Line2.Top = 0!
            Me.Line2.Width = 7.480313!
            Me.Line2.X1 = 7.480313!
            Me.Line2.X2 = 0!
            Me.Line2.Y1 = 0!
            Me.Line2.Y2 = 0.006944444!
            '
            'ActiveReport1
            '
            Me.MasterReport = false
            Me.PageSettings.Margins.Left = 0.39375!
            Me.PageSettings.Margins.Right = 0.39375!
            Me.PageSettings.PaperHeight = 11!
            Me.PageSettings.PaperWidth = 8.5!
            Me.PrintWidth = 7.78125!
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
            CType(Me.txtSucursal,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFecha,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label3,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label5,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label6,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label7,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label8,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label9,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label10,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label11,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label12,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label13,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFolio,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox2,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtClienteID,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtTotal,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtAbonos,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtSaldo,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtCodArticulo,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtDescripcion,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox9,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtCantidad,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label14,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtImporte,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox11,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox12,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox13,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        
	End Sub

#End Region

    Private Sub GroupFooter1_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupFooter1.Format

    End Sub

    Private Sub Detail_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles Detail.Format

        If DirectCast(Me.Detail.Controls("txtDescripcion"), TextBox).Text.Length > 14 Then
            DirectCast(Me.Detail.Controls("txtDescripcion"), TextBox).Text = DirectCast(Me.Detail.Controls("txtDescripcion"), TextBox).Text.Substring(0, 13)
        End If


    End Sub
End Class
