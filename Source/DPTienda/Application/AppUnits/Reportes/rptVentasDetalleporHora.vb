Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU

Public Class rptVentasDetalleporHora
Inherits DataDynamics.ActiveReports.ActiveReport

    Public Sub New(ByVal CodCaja As String, ByVal FechaDel As DateTime, ByVal FechaAl As DateTime, ByVal horade As DateTime, ByVal horaal As DateTime, ByVal dsVentasTotales As DataSet)
        MyBase.New()
        InitializeComponent()

        Try

            txtCaja.Text = CodCaja
            txtFecha.Text = Now.ToShortTimeString
            txtFechaDel.Text = FechaDel
            txtFechaAl.Text = FechaAl
            txtHoraDel.Text = horade.ToShortTimeString
            txtHoralAl.Text = horaal.ToShortTimeString
            Dim oSAPMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
            Dim oAlmacen As Almacen
            Dim oAlmacenesMgr As New CatalogoAlmacenesManager(oAppContext)
            oAlmacen = oAlmacenesMgr.Load(oSAPMgr.Read_Centros) 'oAppContext.ApplicationConfiguration.Almacen)

            If Not oAlmacen Is Nothing Then

                txtSucursal.Text = oAlmacen.ID & " " & oAlmacen.Descripcion

            Else

                txtSucursal.Text = oAppContext.ApplicationConfiguration.Almacen

            End If

            Dim n As New DataColumn("Total")
            n.Expression = "Importe-Descuento"
            n.DataType = GetType(System.Decimal)
            dsVentasTotales.Tables(0).Columns.Add(n)

            Dim cpercent As New DataColumn("Percent")
            cpercent.Expression = "pDescuento * 100"
            cpercent.DataType = GetType(System.Decimal)
            dsVentasTotales.Tables(0).Columns.Add(cpercent)

            DataSource = dsVentasTotales
            DataMember = dsVentasTotales.Tables(0).TableName

        Catch ex As Exception

            Throw ex

        End Try

    End Sub

#Region "ActiveReports Designer generated code"
    Private WithEvents ReportHeader As ReportHeader = Nothing
    Private WithEvents PageHeader As PageHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents PageFooter As PageFooter = Nothing
    Private WithEvents ReportFooter As ReportFooter = Nothing
	Private Shape1 As Shape = Nothing
	Private Label1 As Label = Nothing
	Private Label2 As Label = Nothing
	Private txtCaja As TextBox = Nothing
	Private txtFecha As TextBox = Nothing
	Private Label3 As Label = Nothing
	Private Label4 As Label = Nothing
	Private Label5 As Label = Nothing
	Private Label6 As Label = Nothing
	Private txtFechaDel As TextBox = Nothing
	Private txtFechaAl As TextBox = Nothing
	Private txtHoraDel As TextBox = Nothing
	Private txtHoralAl As TextBox = Nothing
	Private Label7 As Label = Nothing
	Private txtSucursal As TextBox = Nothing
	Private txtPagina As TextBox = Nothing
	Private Label8 As Label = Nothing
	Private lblFieldTipoVenta As Label = Nothing
	Private lblFieldFolio As Label = Nothing
	Private lblFieldArticulo As Label = Nothing
	Private lblFieldImporte As Label = Nothing
	Private lblFieldDescuento As Label = Nothing
	Private lblFieldFormaPago As Label = Nothing
	Private lblFieldPago As Label = Nothing
	Private lblFieldVendedor As Label = Nothing
	Private lblFieldCliente As Label = Nothing
	Private Label9 As Label = Nothing
	Private Line2 As Line = Nothing
	Private Line3 As Line = Nothing
    Private Line5 As Line = Nothing
	Private Line6 As Line = Nothing
	Private Line7 As Line = Nothing
	Private Line8 As Line = Nothing
	Private Line9 As Line = Nothing
	Private Line10 As Line = Nothing
	Private Line11 As Line = Nothing
	Private tbFolio As TextBox = Nothing
	Private tbCantidad As TextBox = Nothing
	Private tbTalla As TextBox = Nothing
	Private tbImporte As TextBox = Nothing
	Private tbTotal As TextBox = Nothing
	Private tbDescuento As TextBox = Nothing
	Private tbCantDescuento As TextBox = Nothing
	Private tbDescripcion As TextBox = Nothing
	Private tbArticuloID As TextBox = Nothing
	Private TextBox4 As TextBox = Nothing
	Private TextBox1 As TextBox = Nothing
	Private TextBox2 As TextBox = Nothing
	Private TextBox3 As TextBox = Nothing
	Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptVentasDetalleporHora))
        Me.Detail = New DataDynamics.ActiveReports.Detail()
        Me.Line2 = New DataDynamics.ActiveReports.Line()
        Me.Line3 = New DataDynamics.ActiveReports.Line()
        Me.Line5 = New DataDynamics.ActiveReports.Line()
        Me.Line6 = New DataDynamics.ActiveReports.Line()
        Me.Line7 = New DataDynamics.ActiveReports.Line()
        Me.Line8 = New DataDynamics.ActiveReports.Line()
        Me.Line9 = New DataDynamics.ActiveReports.Line()
        Me.Line10 = New DataDynamics.ActiveReports.Line()
        Me.Line11 = New DataDynamics.ActiveReports.Line()
        Me.tbFolio = New DataDynamics.ActiveReports.TextBox()
        Me.tbCantidad = New DataDynamics.ActiveReports.TextBox()
        Me.tbTalla = New DataDynamics.ActiveReports.TextBox()
        Me.tbImporte = New DataDynamics.ActiveReports.TextBox()
        Me.tbTotal = New DataDynamics.ActiveReports.TextBox()
        Me.tbDescuento = New DataDynamics.ActiveReports.TextBox()
        Me.tbCantDescuento = New DataDynamics.ActiveReports.TextBox()
        Me.tbDescripcion = New DataDynamics.ActiveReports.TextBox()
        Me.tbArticuloID = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox4 = New DataDynamics.ActiveReports.TextBox()
        Me.ReportHeader = New DataDynamics.ActiveReports.ReportHeader()
        Me.Shape1 = New DataDynamics.ActiveReports.Shape()
        Me.Label1 = New DataDynamics.ActiveReports.Label()
        Me.Label2 = New DataDynamics.ActiveReports.Label()
        Me.txtCaja = New DataDynamics.ActiveReports.TextBox()
        Me.txtFecha = New DataDynamics.ActiveReports.TextBox()
        Me.Label3 = New DataDynamics.ActiveReports.Label()
        Me.Label4 = New DataDynamics.ActiveReports.Label()
        Me.Label5 = New DataDynamics.ActiveReports.Label()
        Me.Label6 = New DataDynamics.ActiveReports.Label()
        Me.txtFechaDel = New DataDynamics.ActiveReports.TextBox()
        Me.txtFechaAl = New DataDynamics.ActiveReports.TextBox()
        Me.txtHoraDel = New DataDynamics.ActiveReports.TextBox()
        Me.txtHoralAl = New DataDynamics.ActiveReports.TextBox()
        Me.Label7 = New DataDynamics.ActiveReports.Label()
        Me.txtSucursal = New DataDynamics.ActiveReports.TextBox()
        Me.txtPagina = New DataDynamics.ActiveReports.TextBox()
        Me.Label8 = New DataDynamics.ActiveReports.Label()
        Me.ReportFooter = New DataDynamics.ActiveReports.ReportFooter()
        Me.TextBox1 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox2 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox3 = New DataDynamics.ActiveReports.TextBox()
        Me.PageHeader = New DataDynamics.ActiveReports.PageHeader()
        Me.lblFieldTipoVenta = New DataDynamics.ActiveReports.Label()
        Me.lblFieldFolio = New DataDynamics.ActiveReports.Label()
        Me.lblFieldArticulo = New DataDynamics.ActiveReports.Label()
        Me.lblFieldImporte = New DataDynamics.ActiveReports.Label()
        Me.lblFieldDescuento = New DataDynamics.ActiveReports.Label()
        Me.lblFieldFormaPago = New DataDynamics.ActiveReports.Label()
        Me.lblFieldPago = New DataDynamics.ActiveReports.Label()
        Me.lblFieldVendedor = New DataDynamics.ActiveReports.Label()
        Me.lblFieldCliente = New DataDynamics.ActiveReports.Label()
        Me.Label9 = New DataDynamics.ActiveReports.Label()
        Me.PageFooter = New DataDynamics.ActiveReports.PageFooter()
        CType(Me.tbFolio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbCantidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbTalla, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbImporte, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbDescuento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbCantDescuento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbDescripcion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbArticuloID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCaja, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaDel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaAl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtHoraDel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtHoralAl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSucursal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPagina, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFieldTipoVenta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFieldFolio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFieldArticulo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFieldImporte, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFieldDescuento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFieldFormaPago, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFieldPago, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFieldVendedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFieldCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.ColumnSpacing = 0.0!
        Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Line2, Me.Line3, Me.Line5, Me.Line6, Me.Line7, Me.Line8, Me.Line9, Me.Line10, Me.Line11, Me.tbFolio, Me.tbCantidad, Me.tbTalla, Me.tbImporte, Me.tbTotal, Me.tbDescuento, Me.tbCantDescuento, Me.tbDescripcion, Me.tbArticuloID, Me.TextBox4})
        Me.Detail.Height = 0.2284722!
        Me.Detail.Name = "Detail"
        '
        'Line2
        '
        Me.Line2.Height = 0.1875!
        Me.Line2.Left = 0.0!
        Me.Line2.LineColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Line2.LineWeight = 1.0!
        Me.Line2.Name = "Line2"
        Me.Line2.Top = 0.0!
        Me.Line2.Width = 0.0!
        Me.Line2.X1 = 0.0!
        Me.Line2.X2 = 0.0!
        Me.Line2.Y1 = 0.0!
        Me.Line2.Y2 = 0.1875!
        '
        'Line3
        '
        Me.Line3.Height = 0.1875!
        Me.Line3.Left = 0.9450001!
        Me.Line3.LineColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Line3.LineWeight = 1.0!
        Me.Line3.Name = "Line3"
        Me.Line3.Top = 0.0!
        Me.Line3.Width = 0.0!
        Me.Line3.X1 = 0.9450001!
        Me.Line3.X2 = 0.9450001!
        Me.Line3.Y1 = 0.0!
        Me.Line3.Y2 = 0.1875!
        '
        'Line5
        '
        Me.Line5.Height = 0.1875!
        Me.Line5.Left = 5.819445!
        Me.Line5.LineColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Line5.LineWeight = 1.0!
        Me.Line5.Name = "Line5"
        Me.Line5.Top = 0.006944444!
        Me.Line5.Width = 0.0!
        Me.Line5.X1 = 5.819445!
        Me.Line5.X2 = 5.819445!
        Me.Line5.Y1 = 0.1944444!
        Me.Line5.Y2 = 0.006944444!
        '
        'Line6
        '
        Me.Line6.Height = 0.1875!
        Me.Line6.Left = 6.506945!
        Me.Line6.LineColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Line6.LineWeight = 1.0!
        Me.Line6.Name = "Line6"
        Me.Line6.Top = 0.006944444!
        Me.Line6.Width = 0.0!
        Me.Line6.X1 = 6.506945!
        Me.Line6.X2 = 6.506945!
        Me.Line6.Y1 = 0.1944444!
        Me.Line6.Y2 = 0.006944444!
        '
        'Line7
        '
        Me.Line7.Height = 0.1875!
        Me.Line7.Left = 6.944445!
        Me.Line7.LineColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Line7.LineWeight = 1.0!
        Me.Line7.Name = "Line7"
        Me.Line7.Top = 0.006944444!
        Me.Line7.Width = 0.0!
        Me.Line7.X1 = 6.944445!
        Me.Line7.X2 = 6.944445!
        Me.Line7.Y1 = 0.1944444!
        Me.Line7.Y2 = 0.006944444!
        '
        'Line8
        '
        Me.Line8.Height = 0.1875!
        Me.Line8.Left = 7.756945!
        Me.Line8.LineColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Line8.LineWeight = 1.0!
        Me.Line8.Name = "Line8"
        Me.Line8.Top = 0.006944444!
        Me.Line8.Width = 0.0!
        Me.Line8.X1 = 7.756945!
        Me.Line8.X2 = 7.756945!
        Me.Line8.Y1 = 0.006944444!
        Me.Line8.Y2 = 0.1944444!
        '
        'Line9
        '
        Me.Line9.Height = 0.1875!
        Me.Line9.Left = 8.569445!
        Me.Line9.LineColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Line9.LineWeight = 1.0!
        Me.Line9.Name = "Line9"
        Me.Line9.Top = 0.006944444!
        Me.Line9.Width = 0.0!
        Me.Line9.X1 = 8.569445!
        Me.Line9.X2 = 8.569445!
        Me.Line9.Y1 = 0.006944444!
        Me.Line9.Y2 = 0.1944444!
        '
        'Line10
        '
        Me.Line10.Height = 0.1875!
        Me.Line10.Left = 9.944445!
        Me.Line10.LineColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Line10.LineWeight = 1.0!
        Me.Line10.Name = "Line10"
        Me.Line10.Top = 0.006944444!
        Me.Line10.Width = 0.0!
        Me.Line10.X1 = 9.944445!
        Me.Line10.X2 = 9.944445!
        Me.Line10.Y1 = 0.006944444!
        Me.Line10.Y2 = 0.1944444!
        '
        'Line11
        '
        Me.Line11.Height = 0.1875!
        Me.Line11.Left = 9.131945!
        Me.Line11.LineColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Line11.LineWeight = 1.0!
        Me.Line11.Name = "Line11"
        Me.Line11.Top = 0.006944444!
        Me.Line11.Width = 0.0!
        Me.Line11.X1 = 9.131945!
        Me.Line11.X2 = 9.131945!
        Me.Line11.Y1 = 0.006944444!
        Me.Line11.Y2 = 0.1944444!
        '
        'tbFolio
        '
        Me.tbFolio.DataField = "Folio"
        Me.tbFolio.Height = 0.2!
        Me.tbFolio.Left = 0.0625!
        Me.tbFolio.Name = "tbFolio"
        Me.tbFolio.Style = "ddo-char-set: 1; text-align: center; font-size: 10pt"
        Me.tbFolio.Text = Nothing
        Me.tbFolio.Top = 0.0!
        Me.tbFolio.Width = 0.882382!
        '
        'tbCantidad
        '
        Me.tbCantidad.DataField = "Cantidad"
        Me.tbCantidad.Height = 0.2!
        Me.tbCantidad.Left = 5.8125!
        Me.tbCantidad.Name = "tbCantidad"
        Me.tbCantidad.Style = "ddo-char-set: 1; text-align: center; font-size: 10pt"
        Me.tbCantidad.Text = Nothing
        Me.tbCantidad.Top = 0.0!
        Me.tbCantidad.Width = 0.6875!
        '
        'tbTalla
        '
        Me.tbTalla.DataField = "Numero"
        Me.tbTalla.Height = 0.2!
        Me.tbTalla.Left = 6.5!
        Me.tbTalla.Name = "tbTalla"
        Me.tbTalla.Style = "text-align: center"
        Me.tbTalla.Text = Nothing
        Me.tbTalla.Top = 0.0!
        Me.tbTalla.Width = 0.4375!
        '
        'tbImporte
        '
        Me.tbImporte.DataField = "Importe"
        Me.tbImporte.Height = 0.2!
        Me.tbImporte.Left = 6.9375!
        Me.tbImporte.Name = "tbImporte"
        Me.tbImporte.OutputFormat = resources.GetString("tbImporte.OutputFormat")
        Me.tbImporte.Style = "text-align: center"
        Me.tbImporte.Text = Nothing
        Me.tbImporte.Top = 0.0!
        Me.tbImporte.Width = 0.8125!
        '
        'tbTotal
        '
        Me.tbTotal.DataField = "Total"
        Me.tbTotal.Height = 0.2!
        Me.tbTotal.Left = 7.75!
        Me.tbTotal.Name = "tbTotal"
        Me.tbTotal.OutputFormat = resources.GetString("tbTotal.OutputFormat")
        Me.tbTotal.Style = "text-align: center"
        Me.tbTotal.Text = Nothing
        Me.tbTotal.Top = 0.0!
        Me.tbTotal.Width = 0.8125!
        '
        'tbDescuento
        '
        Me.tbDescuento.DataField = "Percent"
        Me.tbDescuento.Height = 0.2!
        Me.tbDescuento.Left = 8.5625!
        Me.tbDescuento.Name = "tbDescuento"
        Me.tbDescuento.Style = "text-align: center"
        Me.tbDescuento.Text = Nothing
        Me.tbDescuento.Top = 0.0!
        Me.tbDescuento.Width = 0.5625!
        '
        'tbCantDescuento
        '
        Me.tbCantDescuento.DataField = "Descuento"
        Me.tbCantDescuento.Height = 0.2!
        Me.tbCantDescuento.Left = 9.125!
        Me.tbCantDescuento.Name = "tbCantDescuento"
        Me.tbCantDescuento.OutputFormat = resources.GetString("tbCantDescuento.OutputFormat")
        Me.tbCantDescuento.Style = "text-align: center"
        Me.tbCantDescuento.Text = Nothing
        Me.tbCantDescuento.Top = 0.0!
        Me.tbCantDescuento.Width = 0.8125!
        '
        'tbDescripcion
        '
        Me.tbDescripcion.DataField = "Descripcion"
        Me.tbDescripcion.Height = 0.2!
        Me.tbDescripcion.Left = 3.386!
        Me.tbDescripcion.Name = "tbDescripcion"
        Me.tbDescripcion.Style = "ddo-char-set: 1; text-align: left; font-size: 10pt"
        Me.tbDescripcion.Text = Nothing
        Me.tbDescripcion.Top = 0.0!
        Me.tbDescripcion.Width = 2.489173!
        '
        'tbArticuloID
        '
        Me.tbArticuloID.DataField = "CodArticulo"
        Me.tbArticuloID.Height = 0.2!
        Me.tbArticuloID.Left = 2.18061!
        Me.tbArticuloID.Name = "tbArticuloID"
        Me.tbArticuloID.Style = "ddo-char-set: 1; text-align: left; font-size: 10pt"
        Me.tbArticuloID.Text = Nothing
        Me.tbArticuloID.Top = 0.0!
        Me.tbArticuloID.Width = 1.205217!
        '
        'TextBox4
        '
        Me.TextBox4.DataField = "Referencia"
        Me.TextBox4.Height = 0.2!
        Me.TextBox4.Left = 0.9620001!
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Style = "ddo-char-set: 1; text-align: center; font-size: 10pt"
        Me.TextBox4.Text = Nothing
        Me.TextBox4.Top = 0.0!
        Me.TextBox4.Width = 1.218997!
        '
        'ReportHeader
        '
        Me.ReportHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape1, Me.Label1, Me.Label2, Me.txtCaja, Me.txtFecha, Me.Label3, Me.Label4, Me.Label5, Me.Label6, Me.txtFechaDel, Me.txtFechaAl, Me.txtHoraDel, Me.txtHoralAl, Me.Label7, Me.txtSucursal, Me.txtPagina, Me.Label8})
        Me.ReportHeader.Height = 0.8229167!
        Me.ReportHeader.Name = "ReportHeader"
        '
        'Shape1
        '
        Me.Shape1.Height = 0.8125!
        Me.Shape1.Left = 0.0625!
        Me.Shape1.Name = "Shape1"
        Me.Shape1.RoundingRadius = 9.999999!
        Me.Shape1.Top = 0.0!
        Me.Shape1.Width = 9.875!
        '
        'Label1
        '
        Me.Label1.Height = 0.2!
        Me.Label1.HyperLink = Nothing
        Me.Label1.Left = 3.789944!
        Me.Label1.Name = "Label1"
        Me.Label1.Style = "text-align: center"
        Me.Label1.Text = "REPORTE DE VENTAS DETALLE"
        Me.Label1.Top = 0.0625!
        Me.Label1.Width = 2.440945!
        '
        'Label2
        '
        Me.Label2.Height = 0.2!
        Me.Label2.HyperLink = Nothing
        Me.Label2.Left = 1.6875!
        Me.Label2.Name = "Label2"
        Me.Label2.Style = ""
        Me.Label2.Text = "Caja.:"
        Me.Label2.Top = 0.3125!
        Me.Label2.Width = 0.4330709!
        '
        'txtCaja
        '
        Me.txtCaja.Height = 0.2!
        Me.txtCaja.Left = 2.18061!
        Me.txtCaja.Name = "txtCaja"
        Me.txtCaja.Text = "txtCaja"
        Me.txtCaja.Top = 0.3125!
        Me.txtCaja.Width = 0.472441!
        '
        'txtFecha
        '
        Me.txtFecha.Height = 0.2!
        Me.txtFecha.Left = 0.1412401!
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.Text = "txtFecha"
        Me.txtFecha.Top = 0.03937007!
        Me.txtFecha.Width = 1.0!
        '
        'Label3
        '
        Me.Label3.Height = 0.2!
        Me.Label3.HyperLink = Nothing
        Me.Label3.Left = 2.782973!
        Me.Label3.Name = "Label3"
        Me.Label3.Style = ""
        Me.Label3.Text = "De.:"
        Me.Label3.Top = 0.3125!
        Me.Label3.Width = 0.2918307!
        '
        'Label4
        '
        Me.Label4.Height = 0.2!
        Me.Label4.HyperLink = Nothing
        Me.Label4.Left = 3.964075!
        Me.Label4.Name = "Label4"
        Me.Label4.Style = ""
        Me.Label4.Text = "Al.:"
        Me.Label4.Top = 0.3125!
        Me.Label4.Width = 0.2760828!
        '
        'Label5
        '
        Me.Label5.Height = 0.2!
        Me.Label5.HyperLink = Nothing
        Me.Label5.Left = 5.050198!
        Me.Label5.Name = "Label5"
        Me.Label5.Style = ""
        Me.Label5.Text = "en el Transcurso De.:"
        Me.Label5.Top = 0.3149606!
        Me.Label5.Width = 1.377953!
        '
        'Label6
        '
        Me.Label6.Height = 0.2!
        Me.Label6.HyperLink = Nothing
        Me.Label6.Left = 7.176181!
        Me.Label6.Name = "Label6"
        Me.Label6.Style = ""
        Me.Label6.Text = "A las.:"
        Me.Label6.Top = 0.3149606!
        Me.Label6.Width = 0.4808071!
        '
        'txtFechaDel
        '
        Me.txtFechaDel.Height = 0.2!
        Me.txtFechaDel.Left = 3.097933!
        Me.txtFechaDel.Name = "txtFechaDel"
        Me.txtFechaDel.OutputFormat = resources.GetString("txtFechaDel.OutputFormat")
        Me.txtFechaDel.Text = "15/02/2005"
        Me.txtFechaDel.Top = 0.3125!
        Me.txtFechaDel.Width = 0.7480313!
        '
        'txtFechaAl
        '
        Me.txtFechaAl.Height = 0.2!
        Me.txtFechaAl.Left = 4.25!
        Me.txtFechaAl.Name = "txtFechaAl"
        Me.txtFechaAl.OutputFormat = resources.GetString("txtFechaAl.OutputFormat")
        Me.txtFechaAl.Text = "01/03/2005"
        Me.txtFechaAl.Top = 0.3125!
        Me.txtFechaAl.Width = 0.748032!
        '
        'txtHoraDel
        '
        Me.txtHoraDel.Height = 0.2!
        Me.txtHoraDel.Left = 6.42815!
        Me.txtHoraDel.Name = "txtHoraDel"
        Me.txtHoraDel.Text = "10:43:42"
        Me.txtHoraDel.Top = 0.3149606!
        Me.txtHoraDel.Width = 0.7086618!
        '
        'txtHoralAl
        '
        Me.txtHoralAl.Height = 0.2!
        Me.txtHoralAl.Left = 7.653049!
        Me.txtHoralAl.Name = "txtHoralAl"
        Me.txtHoralAl.Text = "10:43:42"
        Me.txtHoralAl.Top = 0.3149606!
        Me.txtHoralAl.Width = 0.7086618!
        '
        'Label7
        '
        Me.Label7.Height = 0.2!
        Me.Label7.HyperLink = Nothing
        Me.Label7.Left = 3.3125!
        Me.Label7.Name = "Label7"
        Me.Label7.Style = ""
        Me.Label7.Text = "Sucursal.:"
        Me.Label7.Top = 0.5625!
        Me.Label7.Width = 0.6692913!
        '
        'txtSucursal
        '
        Me.txtSucursal.Height = 0.2!
        Me.txtSucursal.Left = 4.021161!
        Me.txtSucursal.Name = "txtSucursal"
        Me.txtSucursal.Text = "05 TENIENTE AZUETA"
        Me.txtSucursal.Top = 0.5625!
        Me.txtSucursal.Width = 2.480315!
        '
        'txtPagina
        '
        Me.txtPagina.Height = 0.2!
        Me.txtPagina.Left = 9.25!
        Me.txtPagina.Name = "txtPagina"
        Me.txtPagina.Style = "text-align: right"
        Me.txtPagina.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.txtPagina.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount
        Me.txtPagina.Text = "1"
        Me.txtPagina.Top = 0.0625!
        Me.txtPagina.Width = 0.629921!
        '
        'Label8
        '
        Me.Label8.Height = 0.2!
        Me.Label8.HyperLink = Nothing
        Me.Label8.Left = 8.875!
        Me.Label8.Name = "Label8"
        Me.Label8.Style = ""
        Me.Label8.Text = "Pág."
        Me.Label8.Top = 0.0625!
        Me.Label8.Width = 0.3543305!
        '
        'ReportFooter
        '
        Me.ReportFooter.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TextBox1, Me.TextBox2, Me.TextBox3})
        Me.ReportFooter.Height = 0.25!
        Me.ReportFooter.Name = "ReportFooter"
        '
        'TextBox1
        '
        Me.TextBox1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.[Double]
        Me.TextBox1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox1.DataField = "Cantidad"
        Me.TextBox1.Height = 0.2!
        Me.TextBox1.Left = 5.8125!
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Style = "ddo-char-set: 1; text-align: center; font-size: 10pt"
        Me.TextBox1.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
        Me.TextBox1.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
        Me.TextBox1.Text = Nothing
        Me.TextBox1.Top = 0.0!
        Me.TextBox1.Width = 0.6875!
        '
        'TextBox2
        '
        Me.TextBox2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.[Double]
        Me.TextBox2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox2.DataField = "Total"
        Me.TextBox2.Height = 0.2!
        Me.TextBox2.Left = 7.75!
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.OutputFormat = resources.GetString("TextBox2.OutputFormat")
        Me.TextBox2.Style = "text-align: center"
        Me.TextBox2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
        Me.TextBox2.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
        Me.TextBox2.Text = Nothing
        Me.TextBox2.Top = 0.0!
        Me.TextBox2.Width = 0.8125!
        '
        'TextBox3
        '
        Me.TextBox3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.[Double]
        Me.TextBox3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox3.DataField = "Descuento"
        Me.TextBox3.Height = 0.2!
        Me.TextBox3.Left = 9.125!
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.OutputFormat = resources.GetString("TextBox3.OutputFormat")
        Me.TextBox3.Style = "text-align: center"
        Me.TextBox3.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
        Me.TextBox3.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
        Me.TextBox3.Text = Nothing
        Me.TextBox3.Top = 0.0!
        Me.TextBox3.Width = 0.8125!
        '
        'PageHeader
        '
        Me.PageHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.lblFieldTipoVenta, Me.lblFieldFolio, Me.lblFieldArticulo, Me.lblFieldImporte, Me.lblFieldDescuento, Me.lblFieldFormaPago, Me.lblFieldPago, Me.lblFieldVendedor, Me.lblFieldCliente, Me.Label9})
        Me.PageHeader.Height = 0.1875!
        Me.PageHeader.Name = "PageHeader"
        '
        'lblFieldTipoVenta
        '
        Me.lblFieldTipoVenta.Height = 0.1811025!
        Me.lblFieldTipoVenta.HyperLink = Nothing
        Me.lblFieldTipoVenta.Left = 0.0625!
        Me.lblFieldTipoVenta.Name = "lblFieldTipoVenta"
        Me.lblFieldTipoVenta.Style = "color: Black; ddo-char-set: 0; text-align: center; font-weight: normal; font-size" & _
    ": 9.75pt"
        Me.lblFieldTipoVenta.Text = "Folio"
        Me.lblFieldTipoVenta.Top = 0.0!
        Me.lblFieldTipoVenta.Width = 0.882382!
        '
        'lblFieldFolio
        '
        Me.lblFieldFolio.Height = 0.181!
        Me.lblFieldFolio.HyperLink = Nothing
        Me.lblFieldFolio.Left = 2.18061!
        Me.lblFieldFolio.Name = "lblFieldFolio"
        Me.lblFieldFolio.Style = "color: Black; ddo-char-set: 0; text-align: center; font-weight: normal; font-size" & _
    ": 9.75pt"
        Me.lblFieldFolio.Text = "Artículos"
        Me.lblFieldFolio.Top = 0.0!
        Me.lblFieldFolio.Width = 1.205217!
        '
        'lblFieldArticulo
        '
        Me.lblFieldArticulo.Height = 0.1811025!
        Me.lblFieldArticulo.HyperLink = Nothing
        Me.lblFieldArticulo.Left = 3.385827!
        Me.lblFieldArticulo.Name = "lblFieldArticulo"
        Me.lblFieldArticulo.Style = "color: Black; ddo-char-set: 0; text-align: center; font-weight: normal; font-size" & _
    ": 9.75pt"
        Me.lblFieldArticulo.Text = "Descripción"
        Me.lblFieldArticulo.Top = 0.0!
        Me.lblFieldArticulo.Width = 2.489173!
        '
        'lblFieldImporte
        '
        Me.lblFieldImporte.Height = 0.1811025!
        Me.lblFieldImporte.HyperLink = Nothing
        Me.lblFieldImporte.Left = 5.875!
        Me.lblFieldImporte.Name = "lblFieldImporte"
        Me.lblFieldImporte.Style = "color: Black; ddo-char-set: 0; text-align: center; font-weight: normal; font-size" & _
    ": 9.75pt"
        Me.lblFieldImporte.Text = "Cantidad"
        Me.lblFieldImporte.Top = 0.0!
        Me.lblFieldImporte.Width = 0.6875!
        '
        'lblFieldDescuento
        '
        Me.lblFieldDescuento.Height = 0.1811025!
        Me.lblFieldDescuento.HyperLink = Nothing
        Me.lblFieldDescuento.Left = 6.5625!
        Me.lblFieldDescuento.Name = "lblFieldDescuento"
        Me.lblFieldDescuento.Style = "color: Black; ddo-char-set: 0; text-align: center; font-weight: normal; font-size" & _
    ": 9.75pt"
        Me.lblFieldDescuento.Text = "Talla"
        Me.lblFieldDescuento.Top = 0.0!
        Me.lblFieldDescuento.Width = 0.4375!
        '
        'lblFieldFormaPago
        '
        Me.lblFieldFormaPago.Height = 0.1811025!
        Me.lblFieldFormaPago.HyperLink = Nothing
        Me.lblFieldFormaPago.Left = 7.0!
        Me.lblFieldFormaPago.Name = "lblFieldFormaPago"
        Me.lblFieldFormaPago.Style = "color: Black; ddo-char-set: 0; text-align: center; font-weight: normal; font-size" & _
    ": 9.75pt"
        Me.lblFieldFormaPago.Text = "Importe"
        Me.lblFieldFormaPago.Top = 0.0!
        Me.lblFieldFormaPago.Width = 0.8125!
        '
        'lblFieldPago
        '
        Me.lblFieldPago.Height = 0.1811025!
        Me.lblFieldPago.HyperLink = Nothing
        Me.lblFieldPago.Left = 7.8125!
        Me.lblFieldPago.Name = "lblFieldPago"
        Me.lblFieldPago.Style = "color: Black; ddo-char-set: 0; text-align: center; font-weight: normal; font-size" & _
    ": 9.75pt"
        Me.lblFieldPago.Text = "Total"
        Me.lblFieldPago.Top = 0.0!
        Me.lblFieldPago.Width = 0.8125!
        '
        'lblFieldVendedor
        '
        Me.lblFieldVendedor.Height = 0.1811025!
        Me.lblFieldVendedor.HyperLink = Nothing
        Me.lblFieldVendedor.Left = 8.625!
        Me.lblFieldVendedor.Name = "lblFieldVendedor"
        Me.lblFieldVendedor.Style = "color: Black; ddo-char-set: 0; text-align: center; font-weight: normal; font-size" & _
    ": 9.75pt"
        Me.lblFieldVendedor.Text = "Descto."
        Me.lblFieldVendedor.Top = 0.0!
        Me.lblFieldVendedor.Width = 0.5625!
        '
        'lblFieldCliente
        '
        Me.lblFieldCliente.Height = 0.1811025!
        Me.lblFieldCliente.HyperLink = Nothing
        Me.lblFieldCliente.Left = 9.1875!
        Me.lblFieldCliente.Name = "lblFieldCliente"
        Me.lblFieldCliente.Style = "color: Black; ddo-char-set: 0; text-align: center; font-weight: normal; font-size" & _
    ": 9.75pt"
        Me.lblFieldCliente.Text = "Cant Desc."
        Me.lblFieldCliente.Top = 0.0!
        Me.lblFieldCliente.Width = 0.8125!
        '
        'Label9
        '
        Me.Label9.Height = 0.1811024!
        Me.Label9.HyperLink = Nothing
        Me.Label9.Left = 0.944882!
        Me.Label9.Name = "Label9"
        Me.Label9.Style = "color: Black; ddo-char-set: 0; text-align: center; font-weight: normal; font-size" & _
    ": 9.75pt"
        Me.Label9.Text = "Folio SAP"
        Me.Label9.Top = 0.0!
        Me.Label9.Width = 1.218997!
        '
        'PageFooter
        '
        Me.PageFooter.Height = 0.0!
        Me.PageFooter.Name = "PageFooter"
        Me.PageFooter.Visible = False
        '
        'rptVentasDetalleporHora
        '
        Me.MasterReport = False
        Me.PageSettings.Margins.Bottom = 0.39375!
        Me.PageSettings.Margins.Left = 0.39375!
        Me.PageSettings.Margins.Right = 0.39375!
        Me.PageSettings.Margins.Top = 0.39375!
        Me.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Landscape
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 10.02083!
        Me.Sections.Add(Me.ReportHeader)
        Me.Sections.Add(Me.PageHeader)
        Me.Sections.Add(Me.Detail)
        Me.Sections.Add(Me.PageFooter)
        Me.Sections.Add(Me.ReportFooter)
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" & _
            "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei" & _
            "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" & _
            "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit", "Heading3", "Normal"))
        CType(Me.tbFolio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbCantidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbTalla, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbImporte, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbDescuento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbCantDescuento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbDescripcion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbArticuloID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCaja, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaDel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaAl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtHoraDel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtHoralAl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSucursal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPagina, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFieldTipoVenta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFieldFolio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFieldArticulo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFieldImporte, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFieldDescuento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFieldFormaPago, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFieldPago, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFieldVendedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFieldCliente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

#End Region

End Class
