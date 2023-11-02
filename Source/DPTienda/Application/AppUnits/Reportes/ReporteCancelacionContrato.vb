Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Imports DportenisPro.DPTienda.ApplicationUnits.Clientes
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos
Imports DportenisPro.DPTienda.ApplicationUnits.ContratosAU

Public Class ReporteCancelacionContrato
    Inherits DataDynamics.ActiveReports.ActiveReport

    Public Sub New(ByVal oContrato As Contrato, ByVal oFormClientes As ClienteAlterno, ByVal Detalle As DataTable, Optional ByVal Reimpresion As Boolean = False)
        MyBase.New()
        InitializeComponent()
        lblReimpresion.Visible = Reimpresion

        Dim oAlmacen As Almacen
        Dim oCatalogoAlmacenesMgr As New CatalogoAlmacenesManager(oAppContext)
        '-------------------------------------------------------------------------
        ' JNAVA (07.03.2016): Adaptacion de Retail
        '-------------------------------------------------------------------------
        Dim oSAPMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        oAlmacen = oCatalogoAlmacenesMgr.Load(oSAPMgr.Read_Centros) 'oAppContext.ApplicationConfiguration.Almacen)
        '-------------------------------------------------------------------------
        '   With oForm
        Me.tbSucursal.Text += " " & oAlmacen.Descripcion
        Me.ebCodCaja.Text += " " & oAppContext.ApplicationConfiguration.NoCaja
        tbFolio.Text = "Referencia: " & CStr(oContrato.Referencia).PadLeft(10, "0")
        tbNombre.Text = oFormClientes.Nombre & " " & oFormClientes.ApellidoPaterno & " " & oFormClientes.ApellidoMaterno
        tbDomicilio.Text = oFormClientes.Direccion
        tbCiudad.Text = oFormClientes.Ciudad
        tbRFC.Text = oFormClientes.RFC
        tbTelefono.Text = oFormClientes.Telefono
        '   Me.txtFechaActual.Text = Date.Now
        Me.txtFecha.Text = oContrato.Fecha
        tbImporteTotal.Text = oContrato.ImporteTotal
        'End With

        lblCuarta.Text = "CUARTA: <<El cliente>> acepta y se compromete a pagar la totalidad de este contrato en " & oAppContext.ApplicationConfiguration.DiasVencimientoApartados & " días después de la firma del mismo."
        lblQuinta.Text = "QUINTA: En el caso de que <<El cliente>> no cumpliera con lo establecido en la cláusula CUARTA de este contrato, se fijará una pena convencional del " & (Math.Round(oAppContext.ApplicationConfiguration.Penalizacion * 100)).ToString & "% sobre el precio público total de los productos señalados en el   presente contrato de apartado."

        '-------------------------------------------------------------------------
        ' JNAVA (07.03.2016): Obtenemos descripcion de los articulo del detalle
        '-------------------------------------------------------------------------
        Dim dtDetalle As DataTable = Detalle
        If dtDetalle.Columns.Contains("Descripcion") = False Then
            dtDetalle.Columns.Add("Descripcion", Type.GetType("System.String"))
            dtDetalle.AcceptChanges()
        End If

        Dim oArticulo As Articulo
        Dim oCatalogoArticulosMgr As New CatalogoArticuloManager(oAppContext)
        For Each oRow As DataRow In dtDetalle.Rows
            oArticulo = Nothing
            oArticulo = oCatalogoArticulosMgr.Load(oRow!CodArticulo)
            oRow!Descripcion = oArticulo.Descripcion
        Next
        Me.DataSource = dtDetalle
        '-------------------------------------------------------------------------

    End Sub


#Region "ActiveReports Designer generated code"
    Private WithEvents ReportHeader As ReportHeader = Nothing
    Private WithEvents PageHeader As PageHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents PageFooter As PageFooter = Nothing
    Private WithEvents ReportFooter As ReportFooter = Nothing
    Private tbFolio As TextBox = Nothing
    Private tbNombre As TextBox = Nothing
    Private tbDomicilio As TextBox = Nothing
    Private tbCiudad As TextBox = Nothing
    Private tbRFC As TextBox = Nothing
    Private tbTelefono As TextBox = Nothing
    Private ebCodCaja As TextBox = Nothing
    Private txtFecha As TextBox = Nothing
    Private TxtBxDocFi As TextBox = Nothing
    Private Label1 As Label = Nothing
    Private Label2 As Label = Nothing
    Private Label3 As Label = Nothing
    Private Label4 As Label = Nothing
    Private Label5 As Label = Nothing
    Private Label6 As Label = Nothing
    Private TextBox14 As TextBox = Nothing
    Private tbSucursal As TextBox = Nothing
    Private TextBox7 As TextBox = Nothing
    Private TextBox8 As TextBox = Nothing
    Private TextBox10 As TextBox = Nothing
    Private TextBox11 As TextBox = Nothing
    Private TextBox12 As TextBox = Nothing
    Private TextBox13 As TextBox = Nothing
    Private tbImporteTotal As TextBox = Nothing
    Private Label7 As Label = Nothing
    Private Label9 As Label = Nothing
    Private Label11 As Label = Nothing
    Private Label12 As Label = Nothing
    Private Label13 As Label = Nothing
    Private Label16 As Label = Nothing
    Private Label17 As Label = Nothing
    Private Label18 As Label = Nothing
    Private Label19 As Label = Nothing
    Private Label20 As Label = Nothing
    Private lblCuarta As Label = Nothing
    Private lblQuinta As Label = Nothing
    Private Label24 As Label = Nothing
    Private Label25 As Label = Nothing
    Private Line1 As Line = Nothing
    Friend WithEvents txtDescripcion As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblReimpresion As DataDynamics.ActiveReports.Label
    Friend WithEvents Label10 As DataDynamics.ActiveReports.Label
    Private Line2 As Line = Nothing
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReporteCancelacionContrato))
        Me.Detail = New DataDynamics.ActiveReports.Detail()
        Me.TextBox7 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox8 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox10 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox11 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox12 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox13 = New DataDynamics.ActiveReports.TextBox()
        Me.txtDescripcion = New DataDynamics.ActiveReports.TextBox()
        Me.ReportHeader = New DataDynamics.ActiveReports.ReportHeader()
        Me.ReportFooter = New DataDynamics.ActiveReports.ReportFooter()
        Me.tbImporteTotal = New DataDynamics.ActiveReports.TextBox()
        Me.Label7 = New DataDynamics.ActiveReports.Label()
        Me.Label9 = New DataDynamics.ActiveReports.Label()
        Me.Label11 = New DataDynamics.ActiveReports.Label()
        Me.Label12 = New DataDynamics.ActiveReports.Label()
        Me.Label13 = New DataDynamics.ActiveReports.Label()
        Me.Label16 = New DataDynamics.ActiveReports.Label()
        Me.Label17 = New DataDynamics.ActiveReports.Label()
        Me.Label18 = New DataDynamics.ActiveReports.Label()
        Me.Label19 = New DataDynamics.ActiveReports.Label()
        Me.Label20 = New DataDynamics.ActiveReports.Label()
        Me.lblCuarta = New DataDynamics.ActiveReports.Label()
        Me.lblQuinta = New DataDynamics.ActiveReports.Label()
        Me.Label24 = New DataDynamics.ActiveReports.Label()
        Me.Label25 = New DataDynamics.ActiveReports.Label()
        Me.Line1 = New DataDynamics.ActiveReports.Line()
        Me.Line2 = New DataDynamics.ActiveReports.Line()
        Me.Label10 = New DataDynamics.ActiveReports.Label()
        Me.PageHeader = New DataDynamics.ActiveReports.PageHeader()
        Me.tbFolio = New DataDynamics.ActiveReports.TextBox()
        Me.tbNombre = New DataDynamics.ActiveReports.TextBox()
        Me.tbDomicilio = New DataDynamics.ActiveReports.TextBox()
        Me.tbCiudad = New DataDynamics.ActiveReports.TextBox()
        Me.tbRFC = New DataDynamics.ActiveReports.TextBox()
        Me.tbTelefono = New DataDynamics.ActiveReports.TextBox()
        Me.ebCodCaja = New DataDynamics.ActiveReports.TextBox()
        Me.txtFecha = New DataDynamics.ActiveReports.TextBox()
        Me.TxtBxDocFi = New DataDynamics.ActiveReports.TextBox()
        Me.Label1 = New DataDynamics.ActiveReports.Label()
        Me.Label2 = New DataDynamics.ActiveReports.Label()
        Me.Label3 = New DataDynamics.ActiveReports.Label()
        Me.Label4 = New DataDynamics.ActiveReports.Label()
        Me.Label5 = New DataDynamics.ActiveReports.Label()
        Me.Label6 = New DataDynamics.ActiveReports.Label()
        Me.TextBox14 = New DataDynamics.ActiveReports.TextBox()
        Me.tbSucursal = New DataDynamics.ActiveReports.TextBox()
        Me.lblReimpresion = New DataDynamics.ActiveReports.Label()
        Me.PageFooter = New DataDynamics.ActiveReports.PageFooter()
        CType(Me.TextBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDescripcion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbImporteTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label19, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label20, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblCuarta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblQuinta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label24, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label25, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbFolio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbNombre, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbDomicilio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbCiudad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbRFC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbTelefono, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ebCodCaja, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtBxDocFi, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbSucursal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblReimpresion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.ColumnSpacing = 0.0!
        Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TextBox7, Me.TextBox8, Me.TextBox10, Me.TextBox11, Me.TextBox12, Me.TextBox13, Me.txtDescripcion})
        Me.Detail.Height = 0.5!
        Me.Detail.Name = "Detail"
        '
        'TextBox7
        '
        Me.TextBox7.DataField = "Cantidad"
        Me.TextBox7.Height = 0.1574803!
        Me.TextBox7.Left = 0.2559055!
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.Style = "font-style: normal; font-size: 8.25pt; font-family: Tahoma"
        Me.TextBox7.Text = Nothing
        Me.TextBox7.Top = 0.0!
        Me.TextBox7.Width = 0.2559055!
        '
        'TextBox8
        '
        Me.TextBox8.DataField = "CodArticulo"
        Me.TextBox8.Height = 0.1574803!
        Me.TextBox8.Left = 0.551181!
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.Style = "font-style: normal; font-size: 8.25pt; font-family: Tahoma"
        Me.TextBox8.Text = Nothing
        Me.TextBox8.Top = 0.0!
        Me.TextBox8.Width = 2.125819!
        '
        'TextBox10
        '
        Me.TextBox10.DataField = "Numero"
        Me.TextBox10.Height = 0.1574803!
        Me.TextBox10.Left = 0.236!
        Me.TextBox10.Name = "TextBox10"
        Me.TextBox10.Style = "text-align: right; font-style: normal; font-size: 8.25pt; font-family: Tahoma"
        Me.TextBox10.Text = Nothing
        Me.TextBox10.Top = 0.157!
        Me.TextBox10.Visible = False
        Me.TextBox10.Width = 0.3149606!
        '
        'TextBox11
        '
        Me.TextBox11.DataField = "Precio"
        Me.TextBox11.Height = 0.157!
        Me.TextBox11.Left = 1.177!
        Me.TextBox11.Name = "TextBox11"
        Me.TextBox11.OutputFormat = resources.GetString("TextBox11.OutputFormat")
        Me.TextBox11.Style = "text-align: right; font-style: normal; font-size: 8.25pt; font-family: Tahoma"
        Me.TextBox11.Text = Nothing
        Me.TextBox11.Top = 0.314!
        Me.TextBox11.Width = 0.626!
        '
        'TextBox12
        '
        Me.TextBox12.DataField = "Importe"
        Me.TextBox12.Height = 0.1574803!
        Me.TextBox12.Left = 2.051!
        Me.TextBox12.Name = "TextBox12"
        Me.TextBox12.OutputFormat = resources.GetString("TextBox12.OutputFormat")
        Me.TextBox12.Style = "text-align: right; font-weight: normal; font-style: normal; font-size: 8.25pt; fo" & _
    "nt-family: Tahoma"
        Me.TextBox12.Text = Nothing
        Me.TextBox12.Top = 0.314!
        Me.TextBox12.Width = 0.6259843!
        '
        'TextBox13
        '
        Me.TextBox13.DataField = "Descuento"
        Me.TextBox13.Height = 0.157!
        Me.TextBox13.Left = 0.549!
        Me.TextBox13.Name = "TextBox13"
        Me.TextBox13.Style = "ddo-char-set: 0; font-style: normal; font-size: 8.25pt; font-family: Tahoma"
        Me.TextBox13.Text = Nothing
        Me.TextBox13.Top = 0.314!
        Me.TextBox13.Visible = False
        Me.TextBox13.Width = 0.626!
        '
        'txtDescripcion
        '
        Me.txtDescripcion.DataField = "Descripcion"
        Me.txtDescripcion.Height = 0.1574803!
        Me.txtDescripcion.Left = 0.551!
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Style = "font-style: normal; font-size: 8.25pt; font-family: Tahoma"
        Me.txtDescripcion.Text = Nothing
        Me.txtDescripcion.Top = 0.157!
        Me.txtDescripcion.Width = 2.126!
        '
        'ReportHeader
        '
        Me.ReportHeader.Height = 0.0!
        Me.ReportHeader.Name = "ReportHeader"
        '
        'ReportFooter
        '
        Me.ReportFooter.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.tbImporteTotal, Me.Label7, Me.Label9, Me.Label11, Me.Label12, Me.Label13, Me.Label16, Me.Label17, Me.Label18, Me.Label19, Me.Label20, Me.lblCuarta, Me.lblQuinta, Me.Label24, Me.Label25, Me.Line1, Me.Line2, Me.Label10})
        Me.ReportFooter.Height = 7.603472!
        Me.ReportFooter.Name = "ReportFooter"
        '
        'tbImporteTotal
        '
        Me.tbImporteTotal.Height = 0.1574803!
        Me.tbImporteTotal.Left = 1.889764!
        Me.tbImporteTotal.Name = "tbImporteTotal"
        Me.tbImporteTotal.Style = "text-align: right; font-weight: normal; font-size: 8.25pt; font-family: Tahoma"
        Me.tbImporteTotal.Text = Nothing
        Me.tbImporteTotal.Top = 0.02362174!
        Me.tbImporteTotal.Width = 0.7874014!
        '
        'Label7
        '
        Me.Label7.Height = 0.1574803!
        Me.Label7.HyperLink = Nothing
        Me.Label7.Left = 1.194882!
        Me.Label7.Name = "Label7"
        Me.Label7.Style = "text-align: right; font-weight: normal; font-size: 8.25pt; font-family: Tahoma"
        Me.Label7.Text = "TOTAL:"
        Me.Label7.Top = 0.02362174!
        Me.Label7.Width = 0.6299212!
        '
        'Label9
        '
        Me.Label9.Height = 0.1574803!
        Me.Label9.HyperLink = Nothing
        Me.Label9.Left = 0.256!
        Me.Label9.Name = "Label9"
        Me.Label9.Style = "text-align: center; font-size: 8.25pt; font-family: Tahoma"
        Me.Label9.Text = "CLIENTE"
        Me.Label9.Top = 6.835001!
        Me.Label9.Width = 1.023622!
        '
        'Label11
        '
        Me.Label11.Height = 0.1574803!
        Me.Label11.HyperLink = Nothing
        Me.Label11.Left = 0.256!
        Me.Label11.Name = "Label11"
        Me.Label11.Style = "text-align: center; font-size: 8.25pt; font-family: Tahoma"
        Me.Label11.Text = "FIRMA"
        Me.Label11.Top = 7.229686!
        Me.Label11.Width = 1.023622!
        '
        'Label12
        '
        Me.Label12.Height = 0.1574803!
        Me.Label12.HyperLink = Nothing
        Me.Label12.Left = 1.574898!
        Me.Label12.Name = "Label12"
        Me.Label12.Style = "text-align: center; font-size: 8.25pt; font-family: Tahoma"
        Me.Label12.Text = "AUTORIZO"
        Me.Label12.Top = 6.835001!
        Me.Label12.Width = 1.023622!
        '
        'Label13
        '
        Me.Label13.Height = 0.1574803!
        Me.Label13.HyperLink = Nothing
        Me.Label13.Left = 1.496158!
        Me.Label13.Name = "Label13"
        Me.Label13.Style = "text-align: center; font-size: 8.25pt; font-family: Tahoma"
        Me.Label13.Text = "NOMBRE Y FIRMA"
        Me.Label13.Top = 7.231163!
        Me.Label13.Width = 1.181103!
        '
        'Label16
        '
        Me.Label16.Height = 0.1574803!
        Me.Label16.HyperLink = Nothing
        Me.Label16.Left = 0.2559055!
        Me.Label16.Name = "Label16"
        Me.Label16.Style = "text-align: center; font-weight: bold; font-size: 8.25pt; font-family: Tahoma"
        Me.Label16.Text = "CONTRATO DE APARTADO"
        Me.Label16.Top = 0.3917303!
        Me.Label16.Width = 2.42126!
        '
        'Label17
        '
        Me.Label17.Height = 0.6948826!
        Me.Label17.HyperLink = Nothing
        Me.Label17.Left = 0.2559055!
        Me.Label17.Name = "Label17"
        Me.Label17.Style = "text-align: justify; font-weight: normal; font-size: 8.25pt; font-family: Tahoma"
        Me.Label17.Text = resources.GetString("Label17.Text")
        Me.Label17.Top = 0.5492106!
        Me.Label17.Width = 2.42126!
        '
        'Label18
        '
        Me.Label18.Height = 0.1574803!
        Me.Label18.HyperLink = Nothing
        Me.Label18.Left = 0.2559055!
        Me.Label18.Name = "Label18"
        Me.Label18.Style = "text-align: center; font-weight: bold; font-size: 8.25pt; font-family: Tahoma"
        Me.Label18.Text = "CLAUSULAS:"
        Me.Label18.Top = 1.244093!
        Me.Label18.Width = 2.42126!
        '
        'Label19
        '
        Me.Label19.Height = 0.551181!
        Me.Label19.HyperLink = Nothing
        Me.Label19.Left = 0.2559055!
        Me.Label19.Name = "Label19"
        Me.Label19.Style = "text-align: justify; font-weight: normal; font-size: 8.25pt; font-family: Tahoma"
        Me.Label19.Text = "PRIMERA: <<La empresa>> manifiesta que <<El cliente>> desea adquirir los producto" & _
    "s anteriormente descritos por medio de un apartado."
        Me.Label19.Top = 1.401574!
        Me.Label19.Width = 2.42126!
        '
        'Label20
        '
        Me.Label20.Height = 0.9292452!
        Me.Label20.HyperLink = Nothing
        Me.Label20.Left = 0.2559055!
        Me.Label20.Name = "Label20"
        Me.Label20.Style = "text-align: justify; font-weight: normal; font-size: 8.25pt; font-family: Tahoma"
        Me.Label20.Text = resources.GetString("Label20.Text")
        Me.Label20.Top = 1.952755!
        Me.Label20.Width = 2.42126!
        '
        'lblCuarta
        '
        Me.lblCuarta.Height = 0.5511813!
        Me.lblCuarta.HyperLink = Nothing
        Me.lblCuarta.Left = 0.256!
        Me.lblCuarta.Name = "lblCuarta"
        Me.lblCuarta.Style = "text-align: justify; font-weight: normal; font-size: 8.25pt; font-family: Tahoma"
        Me.lblCuarta.Text = "CUARTA: <<El cliente>> acepta y se compromete a pagar la totalidad de este contra" & _
    "to en 45 días después de la firma del mismo."
        Me.lblCuarta.Top = 3.868!
        Me.lblCuarta.Width = 2.42126!
        '
        'lblQuinta
        '
        Me.lblQuinta.Height = 0.8726313!
        Me.lblQuinta.HyperLink = Nothing
        Me.lblQuinta.Left = 0.256!
        Me.lblQuinta.Name = "lblQuinta"
        Me.lblQuinta.Style = "text-align: justify; font-weight: normal; font-size: 8.25pt; font-family: Tahoma"
        Me.lblQuinta.Text = resources.GetString("lblQuinta.Text")
        Me.lblQuinta.Top = 4.469439!
        Me.lblQuinta.Width = 2.42126!
        '
        'Label24
        '
        Me.Label24.Height = 0.7510004!
        Me.Label24.HyperLink = Nothing
        Me.Label24.Left = 0.256!
        Me.Label24.Name = "Label24"
        Me.Label24.Style = "text-align: justify; font-weight: normal; font-size: 8.25pt; font-family: Tahoma"
        Me.Label24.Text = resources.GetString("Label24.Text")
        Me.Label24.Top = 5.417!
        Me.Label24.Width = 2.42126!
        '
        'Label25
        '
        Me.Label25.Height = 0.5536418!
        Me.Label25.HyperLink = Nothing
        Me.Label25.Left = 0.256!
        Me.Label25.Name = "Label25"
        Me.Label25.Style = "text-align: justify; font-weight: normal; font-size: 8.25pt; font-family: Tahoma"
        Me.Label25.Text = "SEPTIMA: Serán competentes para cualquier controversia surgida de este contrato, " & _
    "los tribunales radicados en la ciudad de Mazatlán, Sinaloa."
        Me.Label25.Top = 6.168!
        Me.Label25.Width = 2.42126!
        '
        'Line1
        '
        Me.Line1.Height = 0.0!
        Me.Line1.Left = 1.496158!
        Me.Line1.LineWeight = 1.0!
        Me.Line1.Name = "Line1"
        Me.Line1.Top = 7.115513!
        Me.Line1.Width = 1.181101!
        Me.Line1.X1 = 2.677259!
        Me.Line1.X2 = 1.496158!
        Me.Line1.Y1 = 7.115513!
        Me.Line1.Y2 = 7.115513!
        '
        'Line2
        '
        Me.Line2.Height = 0.0!
        Me.Line2.Left = 0.236315!
        Me.Line2.LineWeight = 1.0!
        Me.Line2.Name = "Line2"
        Me.Line2.Top = 7.115513!
        Me.Line2.Width = 1.023622!
        Me.Line2.X1 = 1.259937!
        Me.Line2.X2 = 0.236315!
        Me.Line2.Y1 = 7.115513!
        Me.Line2.Y2 = 7.115513!
        '
        'Label10
        '
        Me.Label10.Height = 0.9842521!
        Me.Label10.HyperLink = Nothing
        Me.Label10.Left = 0.256!
        Me.Label10.Name = "Label10"
        Me.Label10.Style = "text-align: justify; font-weight: normal; font-size: 8.25pt; font-family: Tahoma"
        Me.Label10.Text = resources.GetString("Label10.Text")
        Me.Label10.Top = 2.874!
        Me.Label10.Width = 2.42126!
        '
        'PageHeader
        '
        Me.PageHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.tbFolio, Me.tbNombre, Me.tbDomicilio, Me.tbCiudad, Me.tbRFC, Me.tbTelefono, Me.ebCodCaja, Me.txtFecha, Me.TxtBxDocFi, Me.Label1, Me.Label2, Me.Label3, Me.Label4, Me.Label5, Me.Label6, Me.TextBox14, Me.tbSucursal, Me.lblReimpresion})
        Me.PageHeader.Height = 3.46875!
        Me.PageHeader.Name = "PageHeader"
        '
        'tbFolio
        '
        Me.tbFolio.Height = 0.1761812!
        Me.tbFolio.Left = 0.256!
        Me.tbFolio.Name = "tbFolio"
        Me.tbFolio.Style = "font-weight: normal; font-size: 8.25pt; font-family: Tahoma"
        Me.tbFolio.Text = "FOLIO: 000000000"
        Me.tbFolio.Top = 0.712!
        Me.tbFolio.Width = 1.240158!
        '
        'tbNombre
        '
        Me.tbNombre.Height = 0.2!
        Me.tbNombre.Left = 0.2360945!
        Me.tbNombre.Name = "tbNombre"
        Me.tbNombre.Style = "font-size: 8.25pt; font-family: Tahoma"
        Me.tbNombre.Text = Nothing
        Me.tbNombre.Top = 1.93976!
        Me.tbNombre.Width = 2.440945!
        '
        'tbDomicilio
        '
        Me.tbDomicilio.Height = 0.1948816!
        Me.tbDomicilio.Left = 0.2557795!
        Me.tbDomicilio.Name = "tbDomicilio"
        Me.tbDomicilio.Style = "font-size: 8.25pt; font-family: Tahoma"
        Me.tbDomicilio.Text = Nothing
        Me.tbDomicilio.Top = 2.39104!
        Me.tbDomicilio.Width = 2.42126!
        '
        'tbCiudad
        '
        Me.tbCiudad.Height = 0.2!
        Me.tbCiudad.Left = 0.2557795!
        Me.tbCiudad.Name = "tbCiudad"
        Me.tbCiudad.Style = "font-size: 8.25pt; font-family: Tahoma"
        Me.tbCiudad.Text = Nothing
        Me.tbCiudad.Top = 2.81968!
        Me.tbCiudad.Width = 2.42126!
        '
        'tbRFC
        '
        Me.tbRFC.Height = 0.1574802!
        Me.tbRFC.Left = 1.102237!
        Me.tbRFC.Name = "tbRFC"
        Me.tbRFC.Style = "font-size: 8.25pt; font-family: Tahoma"
        Me.tbRFC.Text = "WWWW-123141-WWW"
        Me.tbRFC.Top = 3.233558!
        Me.tbRFC.Width = 1.574803!
        '
        'tbTelefono
        '
        Me.tbTelefono.Height = 0.1574805!
        Me.tbTelefono.Left = 1.102237!
        Me.tbTelefono.Name = "tbTelefono"
        Me.tbTelefono.Style = "font-size: 8.25pt; font-family: Tahoma"
        Me.tbTelefono.Text = "01(669)9408239"
        Me.tbTelefono.Top = 3.046058!
        Me.tbTelefono.Width = 1.574803!
        '
        'ebCodCaja
        '
        Me.ebCodCaja.Height = 0.2!
        Me.ebCodCaja.Left = 0.2557795!
        Me.ebCodCaja.Name = "ebCodCaja"
        Me.ebCodCaja.Style = "font-size: 8.25pt; font-family: Tahoma"
        Me.ebCodCaja.Text = "CAJA: "
        Me.ebCodCaja.Top = 1.386118!
        Me.ebCodCaja.Width = 1.082677!
        '
        'txtFecha
        '
        Me.txtFecha.Height = 0.2!
        Me.txtFecha.Left = 1.102237!
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.Style = "font-size: 8.25pt; font-family: Tahoma"
        Me.txtFecha.Text = Nothing
        Me.txtFecha.Top = 1.573618!
        Me.txtFecha.Width = 1.555118!
        '
        'TxtBxDocFi
        '
        Me.TxtBxDocFi.Height = 0.1761812!
        Me.TxtBxDocFi.Left = 1.575!
        Me.TxtBxDocFi.Name = "TxtBxDocFi"
        Me.TxtBxDocFi.Style = "font-size: 8.25pt; font-family: Tahoma"
        Me.TxtBxDocFi.Text = "NOSE USA"
        Me.TxtBxDocFi.Top = 0.712!
        Me.TxtBxDocFi.Visible = False
        Me.TxtBxDocFi.Width = 1.102363!
        '
        'Label1
        '
        Me.Label1.Height = 0.1574803!
        Me.Label1.HyperLink = Nothing
        Me.Label1.Left = 0.2557795!
        Me.Label1.Name = "Label1"
        Me.Label1.Style = "font-size: 8.25pt; font-family: Tahoma"
        Me.Label1.Text = "NOMBRE:"
        Me.Label1.Top = 1.796059!
        Me.Label1.Width = 0.531496!
        '
        'Label2
        '
        Me.Label2.Height = 0.1574803!
        Me.Label2.HyperLink = Nothing
        Me.Label2.Left = 0.2557795!
        Me.Label2.Name = "Label2"
        Me.Label2.Style = "font-size: 8.25pt; font-family: Tahoma"
        Me.Label2.Text = "DOMICILIO:"
        Me.Label2.Top = 2.233559!
        Me.Label2.Width = 0.7874014!
        '
        'Label3
        '
        Me.Label3.Height = 0.1574803!
        Me.Label3.HyperLink = Nothing
        Me.Label3.Left = 0.2557795!
        Me.Label3.Name = "Label3"
        Me.Label3.Style = "font-size: 8.25pt; font-family: Tahoma"
        Me.Label3.Text = "CIUDAD:"
        Me.Label3.Top = 2.671058!
        Me.Label3.Width = 0.7874014!
        '
        'Label4
        '
        Me.Label4.Height = 0.1574803!
        Me.Label4.HyperLink = Nothing
        Me.Label4.Left = 0.2557795!
        Me.Label4.Name = "Label4"
        Me.Label4.Style = "font-size: 8.25pt; font-family: Tahoma"
        Me.Label4.Text = "TELEFONO:"
        Me.Label4.Top = 3.046058!
        Me.Label4.Width = 0.7874014!
        '
        'Label5
        '
        Me.Label5.Height = 0.1574803!
        Me.Label5.HyperLink = Nothing
        Me.Label5.Left = 0.2557795!
        Me.Label5.Name = "Label5"
        Me.Label5.Style = "font-size: 8.25pt; font-family: Tahoma"
        Me.Label5.Text = "RFC:"
        Me.Label5.Top = 3.233558!
        Me.Label5.Width = 0.7874014!
        '
        'Label6
        '
        Me.Label6.Height = 0.355!
        Me.Label6.HyperLink = Nothing
        Me.Label6.Left = 0.256!
        Me.Label6.Name = "Label6"
        Me.Label6.Style = "text-align: center; font-weight: bold; font-size: 9.75pt; font-family: Tahoma"
        Me.Label6.Text = "CANCELACION CONTRATO DE APARTADO"
        Me.Label6.Top = 0.022!
        Me.Label6.Width = 2.263504!
        '
        'TextBox14
        '
        Me.TextBox14.Height = 0.2!
        Me.TextBox14.Left = 0.2557795!
        Me.TextBox14.Name = "TextBox14"
        Me.TextBox14.Style = "font-size: 8.25pt; font-family: Tahoma"
        Me.TextBox14.Text = "FECHA: "
        Me.TextBox14.Top = 1.573618!
        Me.TextBox14.Width = 0.7677166!
        '
        'tbSucursal
        '
        Me.tbSucursal.Height = 0.2!
        Me.tbSucursal.Left = 0.236315!
        Me.tbSucursal.Name = "tbSucursal"
        Me.tbSucursal.Style = "font-size: 8.25pt; font-family: Tahoma"
        Me.tbSucursal.Text = "SUCURSAL: "
        Me.tbSucursal.Top = 0.8881811!
        Me.tbSucursal.Width = 2.440945!
        '
        'lblReimpresion
        '
        Me.lblReimpresion.Height = 0.208!
        Me.lblReimpresion.HyperLink = Nothing
        Me.lblReimpresion.Left = 0.2360945!
        Me.lblReimpresion.Name = "lblReimpresion"
        Me.lblReimpresion.Style = "text-align: center; font-weight: bold; font-size: 9.75pt; font-family: Tahoma"
        Me.lblReimpresion.Text = "Reimpresión"
        Me.lblReimpresion.Top = 1.08776!
        Me.lblReimpresion.Width = 1.968504!
        '
        'PageFooter
        '
        Me.PageFooter.Height = 0.0!
        Me.PageFooter.Name = "PageFooter"
        '
        'ReporteCancelacionContrato
        '
        Me.MasterReport = False
        Me.PageSettings.Margins.Bottom = 0.0!
        Me.PageSettings.Margins.Left = 0.0!
        Me.PageSettings.Margins.Right = 0.0!
        Me.PageSettings.Margins.Top = 0.0!
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 2.8125!
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
        CType(Me.TextBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDescripcion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbImporteTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label19, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label20, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblCuarta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblQuinta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label24, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label25, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbFolio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbNombre, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbDomicilio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbCiudad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbRFC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbTelefono, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ebCodCaja, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtBxDocFi, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbSucursal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblReimpresion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

#End Region


    Private Sub Detail_BeforePrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles Detail.BeforePrint
        Me.TextBox11.Text = Format((CDbl(Me.TextBox11.Text) * (1 + oAppContext.ApplicationConfiguration.IVA)), "Currency")
        Me.TextBox12.Text = Format((CDbl(Me.TextBox12.Text) * (1 + oAppContext.ApplicationConfiguration.IVA)), "Currency")
    End Sub
End Class
