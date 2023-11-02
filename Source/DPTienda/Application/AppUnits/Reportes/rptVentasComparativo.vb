Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Imports DportenisPro.DPTienda.ApplicationUnits.AnalisDeVentas
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU

Public Class rptVentasComparativo

    Inherits DataDynamics.ActiveReports.ActiveReport

    Public Sub New(ByVal TipoVenta As String, ByVal FechaDe As DateTime, ByVal FechaHasta As DateTime, ByVal OrdenarPor As String)

        MyBase.New()

        InitializeComponent()

        lblRango.Text = "DE : " & Format(FechaDe, "dd-MM-yyy") & " AL : " & Format(FechaHasta, "dd-MM-yyy")

        lblFecha.Text = Format(Now.Date, "dd-MM-yyy")

        '''Almacenes / Sucursal
        Dim oCatalogoAlmacenMgr As New CatalogoAlmacenesManager(oAppContext)

        Dim oAlmacen As Almacen, oSAPMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig), strCentro As String = ""

        strCentro = oSAPMgr.Read_Centros
        oAlmacen = oCatalogoAlmacenMgr.Load(strCentro)

        oSAPMgr = Nothing

        If (oAlmacen Is Nothing) Or (oAlmacen.ID = String.Empty) Then

            lblSucursal.Text = "SUCURSAL : " & oAppContext.ApplicationConfiguration.Almacen

        Else

            lblSucursal.Text = "SUCURSAL : " & oAlmacen.ID & Space(1) & oAlmacen.Descripcion

        End If

        oAlmacen = Nothing

        oCatalogoAlmacenMgr = Nothing

        '''Analisis Comparativo
        Dim oAnalisisVentasMgr As New AnalisisDeVentasMgr(oAppContext)

        Me.DataSource = oAnalisisVentasMgr.GenerarAnalisisComparativo(TipoVenta, FechaDe, FechaHasta, OrdenarPor)

        Me.Run()

    End Sub

#Region "ActiveReports Designer generated code"
    Private WithEvents PageHeader As PageHeader = Nothing
    Private WithEvents GroupHeader1 As GroupHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents GroupFooter1 As GroupFooter = Nothing
    Private WithEvents PageFooter As PageFooter = Nothing
    Private lblTitulo As Label = Nothing
    Private lblRango As Label = Nothing
    Private lblFecha As Label = Nothing
    Private Label17 As Label = Nothing
    Private TextBox1 As TextBox = Nothing
    Private lblSucursal As Label = Nothing
    Private Label2 As Label = Nothing
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
    Private Label14 As Label = Nothing
    Private Label15 As Label = Nothing
    Private Label16 As Label = Nothing
    Private Line1 As Line = Nothing
    Private Line2 As Line = Nothing
    Private Line3 As Line = Nothing
    Private Line4 As Line = Nothing
    Private Line5 As Line = Nothing
    Private Line6 As Line = Nothing
    Private Line7 As Line = Nothing
    Private Line8 As Line = Nothing
    Private Line9 As Line = Nothing
    Private Line10 As Line = Nothing
    Private Line11 As Line = Nothing
    Private Line12 As Line = Nothing
    Private Line13 As Line = Nothing
    Private Line14 As Line = Nothing
    Private Shape1 As Shape = Nothing
    Private txtCodigo As TextBox = Nothing
    Private txtNombre As TextBox = Nothing
    Private txtTenis As TextBox = Nothing
    Private txtImporteTenis As TextBox = Nothing
    Private txtTextil As TextBox = Nothing
    Private txtImporteTextil As TextBox = Nothing
    Private txtAccesorio As TextBox = Nothing
    Private txtImporteAccesorio As TextBox = Nothing
    Private txtCalzado As TextBox = Nothing
    Private txtImporteCalzado As TextBox = Nothing
    Private txtSandalias As TextBox = Nothing
    Private txtImporteSandalias As TextBox = Nothing
    Private txtPiezas As TextBox = Nothing
    Private txtImporteNeto As TextBox = Nothing
    Private txtIndicador As TextBox = Nothing
    Private TextBox2 As TextBox = Nothing
    Private TextBox3 As TextBox = Nothing
    Private TextBox4 As TextBox = Nothing
    Private TextBox5 As TextBox = Nothing
    Private TextBox6 As TextBox = Nothing
    Private TextBox7 As TextBox = Nothing
    Private TextBox8 As TextBox = Nothing
    Private TextBox9 As TextBox = Nothing
    Private TextBox10 As TextBox = Nothing
    Private TextBox11 As TextBox = Nothing
    Private TextBox12 As TextBox = Nothing
    Private TextBox13 As TextBox = Nothing
    Private Label18 As Label = Nothing
    Private Line15 As Line = Nothing
    Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptVentasComparativo))
            Me.Detail = New DataDynamics.ActiveReports.Detail()
            Me.PageHeader = New DataDynamics.ActiveReports.PageHeader()
            Me.PageFooter = New DataDynamics.ActiveReports.PageFooter()
            Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader()
            Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter()
            Me.lblTitulo = New DataDynamics.ActiveReports.Label()
            Me.lblRango = New DataDynamics.ActiveReports.Label()
            Me.lblFecha = New DataDynamics.ActiveReports.Label()
            Me.Label17 = New DataDynamics.ActiveReports.Label()
            Me.TextBox1 = New DataDynamics.ActiveReports.TextBox()
            Me.lblSucursal = New DataDynamics.ActiveReports.Label()
            Me.Label2 = New DataDynamics.ActiveReports.Label()
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
            Me.Label14 = New DataDynamics.ActiveReports.Label()
            Me.Label15 = New DataDynamics.ActiveReports.Label()
            Me.Label16 = New DataDynamics.ActiveReports.Label()
            Me.Line1 = New DataDynamics.ActiveReports.Line()
            Me.Line2 = New DataDynamics.ActiveReports.Line()
            Me.Line3 = New DataDynamics.ActiveReports.Line()
            Me.Line4 = New DataDynamics.ActiveReports.Line()
            Me.Line5 = New DataDynamics.ActiveReports.Line()
            Me.Line6 = New DataDynamics.ActiveReports.Line()
            Me.Line7 = New DataDynamics.ActiveReports.Line()
            Me.Line8 = New DataDynamics.ActiveReports.Line()
            Me.Line9 = New DataDynamics.ActiveReports.Line()
            Me.Line10 = New DataDynamics.ActiveReports.Line()
            Me.Line11 = New DataDynamics.ActiveReports.Line()
            Me.Line12 = New DataDynamics.ActiveReports.Line()
            Me.Line13 = New DataDynamics.ActiveReports.Line()
            Me.Line14 = New DataDynamics.ActiveReports.Line()
            Me.Shape1 = New DataDynamics.ActiveReports.Shape()
            Me.txtCodigo = New DataDynamics.ActiveReports.TextBox()
            Me.txtNombre = New DataDynamics.ActiveReports.TextBox()
            Me.txtTenis = New DataDynamics.ActiveReports.TextBox()
            Me.txtImporteTenis = New DataDynamics.ActiveReports.TextBox()
            Me.txtTextil = New DataDynamics.ActiveReports.TextBox()
            Me.txtImporteTextil = New DataDynamics.ActiveReports.TextBox()
            Me.txtAccesorio = New DataDynamics.ActiveReports.TextBox()
            Me.txtImporteAccesorio = New DataDynamics.ActiveReports.TextBox()
            Me.txtCalzado = New DataDynamics.ActiveReports.TextBox()
            Me.txtImporteCalzado = New DataDynamics.ActiveReports.TextBox()
            Me.txtSandalias = New DataDynamics.ActiveReports.TextBox()
            Me.txtImporteSandalias = New DataDynamics.ActiveReports.TextBox()
            Me.txtPiezas = New DataDynamics.ActiveReports.TextBox()
            Me.txtImporteNeto = New DataDynamics.ActiveReports.TextBox()
            Me.txtIndicador = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox2 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox3 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox4 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox5 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox6 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox7 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox8 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox9 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox10 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox11 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox12 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox13 = New DataDynamics.ActiveReports.TextBox()
            Me.Label18 = New DataDynamics.ActiveReports.Label()
            Me.Line15 = New DataDynamics.ActiveReports.Line()
            CType(Me.lblTitulo,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblRango,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblFecha,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label17,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox1,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblSucursal,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).BeginInit
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
            CType(Me.Label14,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label15,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label16,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtCodigo,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtNombre,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtTenis,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtImporteTenis,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtTextil,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtImporteTextil,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtAccesorio,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtImporteAccesorio,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtCalzado,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtImporteCalzado,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtSandalias,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtImporteSandalias,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtPiezas,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtImporteNeto,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtIndicador,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox2,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox3,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox4,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox5,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox6,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox7,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox8,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox9,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox10,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox11,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox12,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox13,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label18,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
            '
            'Detail
            '
            Me.Detail.ColumnSpacing = 0!
            Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtCodigo, Me.txtNombre, Me.txtTenis, Me.txtImporteTenis, Me.txtTextil, Me.txtImporteTextil, Me.txtAccesorio, Me.txtImporteAccesorio, Me.txtCalzado, Me.txtImporteCalzado, Me.txtSandalias, Me.txtImporteSandalias, Me.txtPiezas, Me.txtImporteNeto, Me.txtIndicador})
            Me.Detail.Height = 0.1763889!
            Me.Detail.Name = "Detail"
            '
            'PageHeader
            '
            Me.PageHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.lblTitulo, Me.lblRango, Me.lblFecha, Me.Label17, Me.TextBox1, Me.lblSucursal, Me.Label2, Me.Label3, Me.Label4, Me.Label5, Me.Label6, Me.Label7, Me.Label8, Me.Label9, Me.Label10, Me.Label11, Me.Label12, Me.Label13, Me.Label14, Me.Label15, Me.Label16, Me.Line1, Me.Line2, Me.Line3, Me.Line4, Me.Line5, Me.Line6, Me.Line7, Me.Line8, Me.Line9, Me.Line10, Me.Line11, Me.Line12, Me.Line13, Me.Line14, Me.Shape1})
            Me.PageHeader.Height = 0.8854167!
            Me.PageHeader.Name = "PageHeader"
            '
            'PageFooter
            '
            Me.PageFooter.Height = 0!
            Me.PageFooter.Name = "PageFooter"
            '
            'GroupHeader1
            '
            Me.GroupHeader1.Height = 0!
            Me.GroupHeader1.Name = "GroupHeader1"
            '
            'GroupFooter1
            '
            Me.GroupFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TextBox2, Me.TextBox3, Me.TextBox4, Me.TextBox5, Me.TextBox6, Me.TextBox7, Me.TextBox8, Me.TextBox9, Me.TextBox10, Me.TextBox11, Me.TextBox12, Me.TextBox13, Me.Label18, Me.Line15})
            Me.GroupFooter1.Height = 0.34375!
            Me.GroupFooter1.Name = "GroupFooter1"
            '
            'lblTitulo
            '
            Me.lblTitulo.Height = 0.1875!
            Me.lblTitulo.HyperLink = Nothing
            Me.lblTitulo.Left = 2.21875!
            Me.lblTitulo.Name = "lblTitulo"
            Me.lblTitulo.Style = "text-align: center; font-size: 9pt"
            Me.lblTitulo.Text = "ANALISIS COMPARATIVO POR PLAYER CON DESGLOCE DE FAMILIAS"
            Me.lblTitulo.Top = 0.0625!
            Me.lblTitulo.Width = 5.6875!
            '
            'lblRango
            '
            Me.lblRango.Height = 0.1875!
            Me.lblRango.HyperLink = Nothing
            Me.lblRango.Left = 2.21875!
            Me.lblRango.Name = "lblRango"
            Me.lblRango.Style = "text-align: center; font-size: 9pt"
            Me.lblRango.Text = "DE : 00/00/0000 AL : 00/00/0000"
            Me.lblRango.Top = 0.25!
            Me.lblRango.Width = 5.6875!
            '
            'lblFecha
            '
            Me.lblFecha.Height = 0.2!
            Me.lblFecha.HyperLink = Nothing
            Me.lblFecha.Left = 0.0625!
            Me.lblFecha.Name = "lblFecha"
            Me.lblFecha.Style = "font-size: 9pt"
            Me.lblFecha.Text = "00/00/0000"
            Me.lblFecha.Top = 0.0625!
            Me.lblFecha.Width = 0.8125!
            '
            'Label17
            '
            Me.Label17.Height = 0.2!
            Me.Label17.HyperLink = Nothing
            Me.Label17.Left = 8.8125!
            Me.Label17.Name = "Label17"
            Me.Label17.Style = "font-size: 9pt"
            Me.Label17.Text = "PAG.:"
            Me.Label17.Top = 0.0625!
            Me.Label17.Width = 0.4375!
            '
            'TextBox1
            '
            Me.TextBox1.Height = 0.2!
            Me.TextBox1.Left = 9.3125!
            Me.TextBox1.Name = "TextBox1"
            Me.TextBox1.Style = "font-size: 9pt"
            Me.TextBox1.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
            Me.TextBox1.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount
            Me.TextBox1.Text = "000"
            Me.TextBox1.Top = 0.0625!
            Me.TextBox1.Width = 0.3125!
            '
            'lblSucursal
            '
            Me.lblSucursal.Height = 0.1875!
            Me.lblSucursal.HyperLink = Nothing
            Me.lblSucursal.Left = 2.21875!
            Me.lblSucursal.Name = "lblSucursal"
            Me.lblSucursal.Style = "text-align: center; font-size: 9pt"
            Me.lblSucursal.Text = "SUCURSAL : 000 xxxxxxxxxxxxxxxxx"
            Me.lblSucursal.Top = 0.4375!
            Me.lblSucursal.Width = 5.6875!
            '
            'Label2
            '
            Me.Label2.Height = 0.1875!
            Me.Label2.HyperLink = Nothing
            Me.Label2.Left = 0!
            Me.Label2.Name = "Label2"
            Me.Label2.Style = "text-align: center; font-size: 9pt"
            Me.Label2.Text = "COD."
            Me.Label2.Top = 0.6875!
            Me.Label2.Width = 0.5!
            '
            'Label3
            '
            Me.Label3.Height = 0.1875!
            Me.Label3.HyperLink = Nothing
            Me.Label3.Left = 0.5!
            Me.Label3.Name = "Label3"
            Me.Label3.Style = "text-align: center; font-size: 9pt"
            Me.Label3.Text = "NOMBRE"
            Me.Label3.Top = 0.6875!
            Me.Label3.Width = 1.1875!
            '
            'Label4
            '
            Me.Label4.Height = 0.1875!
            Me.Label4.HyperLink = Nothing
            Me.Label4.Left = 1.75!
            Me.Label4.Name = "Label4"
            Me.Label4.Style = "text-align: right; font-size: 9pt"
            Me.Label4.Text = "TENIS"
            Me.Label4.Top = 0.6875!
            Me.Label4.Width = 0.4375!
            '
            'Label5
            '
            Me.Label5.Height = 0.1875!
            Me.Label5.HyperLink = Nothing
            Me.Label5.Left = 2.25!
            Me.Label5.Name = "Label5"
            Me.Label5.Style = "text-align: right; font-size: 9pt"
            Me.Label5.Text = "IMPORTE"
            Me.Label5.Top = 0.6875!
            Me.Label5.Width = 0.625!
            '
            'Label6
            '
            Me.Label6.Height = 0.1875!
            Me.Label6.HyperLink = Nothing
            Me.Label6.Left = 2.9375!
            Me.Label6.Name = "Label6"
            Me.Label6.Style = "text-align: right; font-size: 9pt"
            Me.Label6.Text = "TEXT"
            Me.Label6.Top = 0.6875!
            Me.Label6.Width = 0.4375!
            '
            'Label7
            '
            Me.Label7.Height = 0.1875!
            Me.Label7.HyperLink = Nothing
            Me.Label7.Left = 3.4375!
            Me.Label7.Name = "Label7"
            Me.Label7.Style = "text-align: right; font-size: 9pt"
            Me.Label7.Text = "IMPORTE"
            Me.Label7.Top = 0.6875!
            Me.Label7.Width = 0.625!
            '
            'Label8
            '
            Me.Label8.Height = 0.1875!
            Me.Label8.HyperLink = Nothing
            Me.Label8.Left = 4.125!
            Me.Label8.Name = "Label8"
            Me.Label8.Style = "text-align: right; font-size: 9pt"
            Me.Label8.Text = "ACC"
            Me.Label8.Top = 0.6875!
            Me.Label8.Width = 0.4375!
            '
            'Label9
            '
            Me.Label9.Height = 0.1875!
            Me.Label9.HyperLink = Nothing
            Me.Label9.Left = 4.625!
            Me.Label9.Name = "Label9"
            Me.Label9.Style = "text-align: right; font-size: 9pt"
            Me.Label9.Text = "IMPORTE"
            Me.Label9.Top = 0.6875!
            Me.Label9.Width = 0.625!
            '
            'Label10
            '
            Me.Label10.Height = 0.1875!
            Me.Label10.HyperLink = Nothing
            Me.Label10.Left = 5.3125!
            Me.Label10.Name = "Label10"
            Me.Label10.Style = "text-align: right; font-size: 9pt"
            Me.Label10.Text = "CALZ."
            Me.Label10.Top = 0.6875!
            Me.Label10.Width = 0.4375!
            '
            'Label11
            '
            Me.Label11.Height = 0.1875!
            Me.Label11.HyperLink = Nothing
            Me.Label11.Left = 5.8125!
            Me.Label11.Name = "Label11"
            Me.Label11.Style = "text-align: right; font-size: 9pt"
            Me.Label11.Text = "IMPORTE"
            Me.Label11.Top = 0.6875!
            Me.Label11.Width = 0.625!
            '
            'Label12
            '
            Me.Label12.Height = 0.1875!
            Me.Label12.HyperLink = Nothing
            Me.Label12.Left = 6.5!
            Me.Label12.Name = "Label12"
            Me.Label12.Style = "text-align: right; font-size: 9pt"
            Me.Label12.Text = "SAND."
            Me.Label12.Top = 0.6875!
            Me.Label12.Width = 0.4375!
            '
            'Label13
            '
            Me.Label13.Height = 0.1875!
            Me.Label13.HyperLink = Nothing
            Me.Label13.Left = 7!
            Me.Label13.Name = "Label13"
            Me.Label13.Style = "text-align: right; font-size: 9pt"
            Me.Label13.Text = "IMPORTE"
            Me.Label13.Top = 0.6875!
            Me.Label13.Width = 0.625!
            '
            'Label14
            '
            Me.Label14.Height = 0.1875!
            Me.Label14.HyperLink = Nothing
            Me.Label14.Left = 7.6875!
            Me.Label14.Name = "Label14"
            Me.Label14.Style = "text-align: right; font-size: 9pt"
            Me.Label14.Text = "PZAS."
            Me.Label14.Top = 0.6875!
            Me.Label14.Width = 0.5!
            '
            'Label15
            '
            Me.Label15.Height = 0.1875!
            Me.Label15.HyperLink = Nothing
            Me.Label15.Left = 8.25!
            Me.Label15.Name = "Label15"
            Me.Label15.Style = "text-align: center; font-size: 9pt"
            Me.Label15.Text = "IMPORTE"
            Me.Label15.Top = 0.6875!
            Me.Label15.Width = 0.9375!
            '
            'Label16
            '
            Me.Label16.Height = 0.1875!
            Me.Label16.HyperLink = Nothing
            Me.Label16.Left = 9.25!
            Me.Label16.Name = "Label16"
            Me.Label16.Style = "text-align: center; font-size: 9pt"
            Me.Label16.Text = "% IND."
            Me.Label16.Top = 0.6875!
            Me.Label16.Width = 0.4375!
            '
            'Line1
            '
            Me.Line1.Height = 0!
            Me.Line1.Left = 0!
            Me.Line1.LineWeight = 1!
            Me.Line1.Name = "Line1"
            Me.Line1.Top = 0.6875!
            Me.Line1.Width = 9.6875!
            Me.Line1.X1 = 9.6875!
            Me.Line1.X2 = 0!
            Me.Line1.Y1 = 0.6875!
            Me.Line1.Y2 = 0.6875!
            '
            'Line2
            '
            Me.Line2.Height = 0.1875!
            Me.Line2.Left = 9.1875!
            Me.Line2.LineWeight = 1!
            Me.Line2.Name = "Line2"
            Me.Line2.Top = 0.6875!
            Me.Line2.Width = 0!
            Me.Line2.X1 = 9.1875!
            Me.Line2.X2 = 9.1875!
            Me.Line2.Y1 = 0.6875!
            Me.Line2.Y2 = 0.875!
            '
            'Line3
            '
            Me.Line3.Height = 0.1875!
            Me.Line3.Left = 8.25!
            Me.Line3.LineWeight = 1!
            Me.Line3.Name = "Line3"
            Me.Line3.Top = 0.6875!
            Me.Line3.Width = 0!
            Me.Line3.X1 = 8.25!
            Me.Line3.X2 = 8.25!
            Me.Line3.Y1 = 0.6875!
            Me.Line3.Y2 = 0.875!
            '
            'Line4
            '
            Me.Line4.Height = 0.1875!
            Me.Line4.Left = 2.9375!
            Me.Line4.LineWeight = 1!
            Me.Line4.Name = "Line4"
            Me.Line4.Top = 0.6875!
            Me.Line4.Width = 0!
            Me.Line4.X1 = 2.9375!
            Me.Line4.X2 = 2.9375!
            Me.Line4.Y1 = 0.6875!
            Me.Line4.Y2 = 0.875!
            '
            'Line5
            '
            Me.Line5.Height = 0.1875!
            Me.Line5.Left = 3.4375!
            Me.Line5.LineWeight = 1!
            Me.Line5.Name = "Line5"
            Me.Line5.Top = 0.6875!
            Me.Line5.Width = 0!
            Me.Line5.X1 = 3.4375!
            Me.Line5.X2 = 3.4375!
            Me.Line5.Y1 = 0.6875!
            Me.Line5.Y2 = 0.875!
            '
            'Line6
            '
            Me.Line6.Height = 0.1875!
            Me.Line6.Left = 4.125!
            Me.Line6.LineWeight = 1!
            Me.Line6.Name = "Line6"
            Me.Line6.Top = 0.6875!
            Me.Line6.Width = 0!
            Me.Line6.X1 = 4.125!
            Me.Line6.X2 = 4.125!
            Me.Line6.Y1 = 0.6875!
            Me.Line6.Y2 = 0.875!
            '
            'Line7
            '
            Me.Line7.Height = 0.1875!
            Me.Line7.Left = 2.25!
            Me.Line7.LineWeight = 1!
            Me.Line7.Name = "Line7"
            Me.Line7.Top = 0.6875!
            Me.Line7.Width = 0!
            Me.Line7.X1 = 2.25!
            Me.Line7.X2 = 2.25!
            Me.Line7.Y1 = 0.6875!
            Me.Line7.Y2 = 0.875!
            '
            'Line8
            '
            Me.Line8.Height = 0.1875!
            Me.Line8.Left = 1.75!
            Me.Line8.LineWeight = 1!
            Me.Line8.Name = "Line8"
            Me.Line8.Top = 0.6875!
            Me.Line8.Width = 0!
            Me.Line8.X1 = 1.75!
            Me.Line8.X2 = 1.75!
            Me.Line8.Y1 = 0.6875!
            Me.Line8.Y2 = 0.875!
            '
            'Line9
            '
            Me.Line9.Height = 0.1875!
            Me.Line9.Left = 4.625!
            Me.Line9.LineWeight = 1!
            Me.Line9.Name = "Line9"
            Me.Line9.Top = 0.6875!
            Me.Line9.Width = 0!
            Me.Line9.X1 = 4.625!
            Me.Line9.X2 = 4.625!
            Me.Line9.Y1 = 0.6875!
            Me.Line9.Y2 = 0.875!
            '
            'Line10
            '
            Me.Line10.Height = 0.1875!
            Me.Line10.Left = 5.3125!
            Me.Line10.LineWeight = 1!
            Me.Line10.Name = "Line10"
            Me.Line10.Top = 0.6875!
            Me.Line10.Width = 0!
            Me.Line10.X1 = 5.3125!
            Me.Line10.X2 = 5.3125!
            Me.Line10.Y1 = 0.6875!
            Me.Line10.Y2 = 0.875!
            '
            'Line11
            '
            Me.Line11.Height = 0.1875!
            Me.Line11.Left = 5.8125!
            Me.Line11.LineWeight = 1!
            Me.Line11.Name = "Line11"
            Me.Line11.Top = 0.6875!
            Me.Line11.Width = 0!
            Me.Line11.X1 = 5.8125!
            Me.Line11.X2 = 5.8125!
            Me.Line11.Y1 = 0.6875!
            Me.Line11.Y2 = 0.875!
            '
            'Line12
            '
            Me.Line12.Height = 0.1875!
            Me.Line12.Left = 6.5!
            Me.Line12.LineWeight = 1!
            Me.Line12.Name = "Line12"
            Me.Line12.Top = 0.6875!
            Me.Line12.Width = 0!
            Me.Line12.X1 = 6.5!
            Me.Line12.X2 = 6.5!
            Me.Line12.Y1 = 0.6875!
            Me.Line12.Y2 = 0.875!
            '
            'Line13
            '
            Me.Line13.Height = 0.1875!
            Me.Line13.Left = 7!
            Me.Line13.LineWeight = 1!
            Me.Line13.Name = "Line13"
            Me.Line13.Top = 0.6875!
            Me.Line13.Width = 0!
            Me.Line13.X1 = 7!
            Me.Line13.X2 = 7!
            Me.Line13.Y1 = 0.6875!
            Me.Line13.Y2 = 0.875!
            '
            'Line14
            '
            Me.Line14.Height = 0.1875!
            Me.Line14.Left = 7.6875!
            Me.Line14.LineWeight = 1!
            Me.Line14.Name = "Line14"
            Me.Line14.Top = 0.6875!
            Me.Line14.Width = 0!
            Me.Line14.X1 = 7.6875!
            Me.Line14.X2 = 7.6875!
            Me.Line14.Y1 = 0.6875!
            Me.Line14.Y2 = 0.875!
            '
            'Shape1
            '
            Me.Shape1.Height = 0.875!
            Me.Shape1.Left = 0!
            Me.Shape1.Name = "Shape1"
            Me.Shape1.RoundingRadius = 9.999999!
            Me.Shape1.Top = 0!
            Me.Shape1.Width = 9.6875!
            '
            'txtCodigo
            '
            Me.txtCodigo.DataField = "Codigo"
            Me.txtCodigo.Height = 0.16!
            Me.txtCodigo.Left = 0!
            Me.txtCodigo.Name = "txtCodigo"
            Me.txtCodigo.Style = "text-align: right; font-size: 9pt"
            Me.txtCodigo.Text = "000000"
            Me.txtCodigo.Top = 0!
            Me.txtCodigo.Width = 0.4375!
            '
            'txtNombre
            '
            Me.txtNombre.CanGrow = false
            Me.txtNombre.DataField = "Nombre"
            Me.txtNombre.Height = 0.16!
            Me.txtNombre.Left = 0.5!
            Me.txtNombre.Name = "txtNombre"
            Me.txtNombre.Style = "font-size: 8pt"
            Me.txtNombre.Text = "NOMBRE "
            Me.txtNombre.Top = 0!
            Me.txtNombre.Width = 1.1875!
            '
            'txtTenis
            '
            Me.txtTenis.DataField = "Tenis"
            Me.txtTenis.Height = 0.16!
            Me.txtTenis.Left = 1.75!
            Me.txtTenis.Name = "txtTenis"
            Me.txtTenis.OutputFormat = resources.GetString("txtTenis.OutputFormat")
            Me.txtTenis.Style = "text-align: right; font-size: 9pt"
            Me.txtTenis.Text = "99999"
            Me.txtTenis.Top = 0!
            Me.txtTenis.Width = 0.4375!
            '
            'txtImporteTenis
            '
            Me.txtImporteTenis.DataField = "ImporteTenis"
            Me.txtImporteTenis.Height = 0.16!
            Me.txtImporteTenis.Left = 2.25!
            Me.txtImporteTenis.Name = "txtImporteTenis"
            Me.txtImporteTenis.OutputFormat = resources.GetString("txtImporteTenis.OutputFormat")
            Me.txtImporteTenis.Style = "text-align: right; font-size: 9pt"
            Me.txtImporteTenis.Text = "000,000.00"
            Me.txtImporteTenis.Top = 0!
            Me.txtImporteTenis.Width = 0.625!
            '
            'txtTextil
            '
            Me.txtTextil.DataField = "Textil"
            Me.txtTextil.Height = 0.16!
            Me.txtTextil.Left = 2.9375!
            Me.txtTextil.Name = "txtTextil"
            Me.txtTextil.OutputFormat = resources.GetString("txtTextil.OutputFormat")
            Me.txtTextil.Style = "text-align: right; font-size: 9pt"
            Me.txtTextil.Text = "99999"
            Me.txtTextil.Top = 0!
            Me.txtTextil.Width = 0.4375!
            '
            'txtImporteTextil
            '
            Me.txtImporteTextil.DataField = "ImporteTextil"
            Me.txtImporteTextil.Height = 0.16!
            Me.txtImporteTextil.Left = 3.4375!
            Me.txtImporteTextil.Name = "txtImporteTextil"
            Me.txtImporteTextil.OutputFormat = resources.GetString("txtImporteTextil.OutputFormat")
            Me.txtImporteTextil.Style = "text-align: right; font-size: 9pt"
            Me.txtImporteTextil.Text = "000,000.00"
            Me.txtImporteTextil.Top = 0!
            Me.txtImporteTextil.Width = 0.625!
            '
            'txtAccesorio
            '
            Me.txtAccesorio.DataField = "Accesorio"
            Me.txtAccesorio.Height = 0.16!
            Me.txtAccesorio.Left = 4.125!
            Me.txtAccesorio.Name = "txtAccesorio"
            Me.txtAccesorio.OutputFormat = resources.GetString("txtAccesorio.OutputFormat")
            Me.txtAccesorio.Style = "text-align: right; font-size: 9pt"
            Me.txtAccesorio.Text = "99999"
            Me.txtAccesorio.Top = 0!
            Me.txtAccesorio.Width = 0.4375!
            '
            'txtImporteAccesorio
            '
            Me.txtImporteAccesorio.DataField = "ImporteAccesorio"
            Me.txtImporteAccesorio.Height = 0.16!
            Me.txtImporteAccesorio.Left = 4.625!
            Me.txtImporteAccesorio.Name = "txtImporteAccesorio"
            Me.txtImporteAccesorio.OutputFormat = resources.GetString("txtImporteAccesorio.OutputFormat")
            Me.txtImporteAccesorio.Style = "text-align: right; font-size: 9pt"
            Me.txtImporteAccesorio.Text = "000,000.00"
            Me.txtImporteAccesorio.Top = 0!
            Me.txtImporteAccesorio.Width = 0.625!
            '
            'txtCalzado
            '
            Me.txtCalzado.DataField = "Calzado"
            Me.txtCalzado.Height = 0.16!
            Me.txtCalzado.Left = 5.3125!
            Me.txtCalzado.Name = "txtCalzado"
            Me.txtCalzado.OutputFormat = resources.GetString("txtCalzado.OutputFormat")
            Me.txtCalzado.Style = "text-align: right; font-size: 9pt"
            Me.txtCalzado.Text = "99999"
            Me.txtCalzado.Top = 0!
            Me.txtCalzado.Width = 0.4375!
            '
            'txtImporteCalzado
            '
            Me.txtImporteCalzado.DataField = "ImporteCalzado"
            Me.txtImporteCalzado.Height = 0.16!
            Me.txtImporteCalzado.Left = 5.8125!
            Me.txtImporteCalzado.Name = "txtImporteCalzado"
            Me.txtImporteCalzado.OutputFormat = resources.GetString("txtImporteCalzado.OutputFormat")
            Me.txtImporteCalzado.Style = "text-align: right; font-size: 9pt"
            Me.txtImporteCalzado.Text = "000,000.00"
            Me.txtImporteCalzado.Top = 0!
            Me.txtImporteCalzado.Width = 0.625!
            '
            'txtSandalias
            '
            Me.txtSandalias.DataField = "Sandalias"
            Me.txtSandalias.Height = 0.16!
            Me.txtSandalias.Left = 6.5!
            Me.txtSandalias.Name = "txtSandalias"
            Me.txtSandalias.OutputFormat = resources.GetString("txtSandalias.OutputFormat")
            Me.txtSandalias.Style = "text-align: right; font-size: 9pt"
            Me.txtSandalias.Text = "99999"
            Me.txtSandalias.Top = 0!
            Me.txtSandalias.Width = 0.4375!
            '
            'txtImporteSandalias
            '
            Me.txtImporteSandalias.DataField = "ImporteSandalias"
            Me.txtImporteSandalias.Height = 0.16!
            Me.txtImporteSandalias.Left = 7!
            Me.txtImporteSandalias.Name = "txtImporteSandalias"
            Me.txtImporteSandalias.OutputFormat = resources.GetString("txtImporteSandalias.OutputFormat")
            Me.txtImporteSandalias.Style = "text-align: right; font-size: 9pt"
            Me.txtImporteSandalias.Text = "000,000.00"
            Me.txtImporteSandalias.Top = 0!
            Me.txtImporteSandalias.Width = 0.625!
            '
            'txtPiezas
            '
            Me.txtPiezas.DataField = "Piezas"
            Me.txtPiezas.Height = 0.16!
            Me.txtPiezas.Left = 7.6875!
            Me.txtPiezas.Name = "txtPiezas"
            Me.txtPiezas.OutputFormat = resources.GetString("txtPiezas.OutputFormat")
            Me.txtPiezas.Style = "text-align: right; font-size: 9pt"
            Me.txtPiezas.Text = "99999"
            Me.txtPiezas.Top = 0!
            Me.txtPiezas.Width = 0.5!
            '
            'txtImporteNeto
            '
            Me.txtImporteNeto.DataField = "ImporteNeto"
            Me.txtImporteNeto.Height = 0.16!
            Me.txtImporteNeto.Left = 8.25!
            Me.txtImporteNeto.Name = "txtImporteNeto"
            Me.txtImporteNeto.OutputFormat = resources.GetString("txtImporteNeto.OutputFormat")
            Me.txtImporteNeto.Style = "text-align: right; font-size: 9pt"
            Me.txtImporteNeto.Text = "000,000.00"
            Me.txtImporteNeto.Top = 0!
            Me.txtImporteNeto.Width = 0.9375!
            '
            'txtIndicador
            '
            Me.txtIndicador.DataField = "Indicador"
            Me.txtIndicador.Height = 0.16!
            Me.txtIndicador.Left = 9.3125!
            Me.txtIndicador.Name = "txtIndicador"
            Me.txtIndicador.OutputFormat = resources.GetString("txtIndicador.OutputFormat")
            Me.txtIndicador.Style = "text-align: right; font-size: 9pt"
            Me.txtIndicador.Text = "100.00"
            Me.txtIndicador.Top = 0!
            Me.txtIndicador.Width = 0.375!
            '
            'TextBox2
            '
            Me.TextBox2.DataField = "Tenis"
            Me.TextBox2.Height = 0.16!
            Me.TextBox2.Left = 1.75!
            Me.TextBox2.Name = "TextBox2"
            Me.TextBox2.OutputFormat = resources.GetString("TextBox2.OutputFormat")
            Me.TextBox2.Style = "text-align: right; font-size: 9pt"
            Me.TextBox2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
            Me.TextBox2.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
            Me.TextBox2.Text = "99999"
            Me.TextBox2.Top = 0.0625!
            Me.TextBox2.Width = 0.4375!
            '
            'TextBox3
            '
            Me.TextBox3.DataField = "ImporteTenis"
            Me.TextBox3.Height = 0.16!
            Me.TextBox3.Left = 2.25!
            Me.TextBox3.Name = "TextBox3"
            Me.TextBox3.OutputFormat = resources.GetString("TextBox3.OutputFormat")
            Me.TextBox3.Style = "text-align: right; font-size: 9pt"
            Me.TextBox3.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
            Me.TextBox3.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
            Me.TextBox3.Text = "000,000.00"
            Me.TextBox3.Top = 0.0625!
            Me.TextBox3.Width = 0.625!
            '
            'TextBox4
            '
            Me.TextBox4.DataField = "Textil"
            Me.TextBox4.Height = 0.16!
            Me.TextBox4.Left = 2.9375!
            Me.TextBox4.Name = "TextBox4"
            Me.TextBox4.OutputFormat = resources.GetString("TextBox4.OutputFormat")
            Me.TextBox4.Style = "text-align: right; font-size: 9pt"
            Me.TextBox4.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
            Me.TextBox4.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
            Me.TextBox4.Text = "99999"
            Me.TextBox4.Top = 0.0625!
            Me.TextBox4.Width = 0.4375!
            '
            'TextBox5
            '
            Me.TextBox5.DataField = "ImporteTextil"
            Me.TextBox5.Height = 0.16!
            Me.TextBox5.Left = 3.4375!
            Me.TextBox5.Name = "TextBox5"
            Me.TextBox5.OutputFormat = resources.GetString("TextBox5.OutputFormat")
            Me.TextBox5.Style = "text-align: right; font-size: 9pt"
            Me.TextBox5.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
            Me.TextBox5.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
            Me.TextBox5.Text = "000,000.00"
            Me.TextBox5.Top = 0.0625!
            Me.TextBox5.Width = 0.625!
            '
            'TextBox6
            '
            Me.TextBox6.DataField = "Accesorio"
            Me.TextBox6.Height = 0.16!
            Me.TextBox6.Left = 4.125!
            Me.TextBox6.Name = "TextBox6"
            Me.TextBox6.OutputFormat = resources.GetString("TextBox6.OutputFormat")
            Me.TextBox6.Style = "text-align: right; font-size: 9pt"
            Me.TextBox6.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
            Me.TextBox6.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
            Me.TextBox6.Text = "99999"
            Me.TextBox6.Top = 0.0625!
            Me.TextBox6.Width = 0.4375!
            '
            'TextBox7
            '
            Me.TextBox7.DataField = "ImporteAccesorio"
            Me.TextBox7.Height = 0.16!
            Me.TextBox7.Left = 4.625!
            Me.TextBox7.Name = "TextBox7"
            Me.TextBox7.OutputFormat = resources.GetString("TextBox7.OutputFormat")
            Me.TextBox7.Style = "text-align: right; font-size: 9pt"
            Me.TextBox7.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
            Me.TextBox7.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
            Me.TextBox7.Text = "000,000.00"
            Me.TextBox7.Top = 0.0625!
            Me.TextBox7.Width = 0.625!
            '
            'TextBox8
            '
            Me.TextBox8.DataField = "Calzado"
            Me.TextBox8.Height = 0.16!
            Me.TextBox8.Left = 5.3125!
            Me.TextBox8.Name = "TextBox8"
            Me.TextBox8.OutputFormat = resources.GetString("TextBox8.OutputFormat")
            Me.TextBox8.Style = "text-align: right; font-size: 9pt"
            Me.TextBox8.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
            Me.TextBox8.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
            Me.TextBox8.Text = "99999"
            Me.TextBox8.Top = 0.0625!
            Me.TextBox8.Width = 0.4375!
            '
            'TextBox9
            '
            Me.TextBox9.DataField = "ImporteCalzado"
            Me.TextBox9.Height = 0.16!
            Me.TextBox9.Left = 5.8125!
            Me.TextBox9.Name = "TextBox9"
            Me.TextBox9.OutputFormat = resources.GetString("TextBox9.OutputFormat")
            Me.TextBox9.Style = "text-align: right; font-size: 9pt"
            Me.TextBox9.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
            Me.TextBox9.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
            Me.TextBox9.Text = "000,000.00"
            Me.TextBox9.Top = 0.0625!
            Me.TextBox9.Width = 0.625!
            '
            'TextBox10
            '
            Me.TextBox10.DataField = "Sandalias"
            Me.TextBox10.Height = 0.16!
            Me.TextBox10.Left = 6.5!
            Me.TextBox10.Name = "TextBox10"
            Me.TextBox10.OutputFormat = resources.GetString("TextBox10.OutputFormat")
            Me.TextBox10.Style = "text-align: right; font-size: 9pt"
            Me.TextBox10.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
            Me.TextBox10.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
            Me.TextBox10.Text = "99999"
            Me.TextBox10.Top = 0.0625!
            Me.TextBox10.Width = 0.4375!
            '
            'TextBox11
            '
            Me.TextBox11.DataField = "ImporteSandalias"
            Me.TextBox11.Height = 0.16!
            Me.TextBox11.Left = 7!
            Me.TextBox11.Name = "TextBox11"
            Me.TextBox11.OutputFormat = resources.GetString("TextBox11.OutputFormat")
            Me.TextBox11.Style = "text-align: right; font-size: 9pt"
            Me.TextBox11.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
            Me.TextBox11.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
            Me.TextBox11.Text = "000,000.00"
            Me.TextBox11.Top = 0.0625!
            Me.TextBox11.Width = 0.625!
            '
            'TextBox12
            '
            Me.TextBox12.DataField = "Piezas"
            Me.TextBox12.Height = 0.16!
            Me.TextBox12.Left = 7.6875!
            Me.TextBox12.Name = "TextBox12"
            Me.TextBox12.OutputFormat = resources.GetString("TextBox12.OutputFormat")
            Me.TextBox12.Style = "text-align: right; font-size: 9pt"
            Me.TextBox12.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
            Me.TextBox12.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
            Me.TextBox12.Text = "99999"
            Me.TextBox12.Top = 0.0625!
            Me.TextBox12.Width = 0.5!
            '
            'TextBox13
            '
            Me.TextBox13.DataField = "ImporteNeto"
            Me.TextBox13.Height = 0.16!
            Me.TextBox13.Left = 8.25!
            Me.TextBox13.Name = "TextBox13"
            Me.TextBox13.OutputFormat = resources.GetString("TextBox13.OutputFormat")
            Me.TextBox13.Style = "text-align: right; font-size: 9pt"
            Me.TextBox13.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
            Me.TextBox13.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
            Me.TextBox13.Text = "000,000.00"
            Me.TextBox13.Top = 0.0625!
            Me.TextBox13.Width = 0.9375!
            '
            'Label18
            '
            Me.Label18.Height = 0.2!
            Me.Label18.HyperLink = Nothing
            Me.Label18.Left = 0.0625!
            Me.Label18.Name = "Label18"
            Me.Label18.Style = ""
            Me.Label18.Text = "TOTALES ..."
            Me.Label18.Top = 0.0625!
            Me.Label18.Width = 1!
            '
            'Line15
            '
            Me.Line15.Height = 0!
            Me.Line15.Left = 0!
            Me.Line15.LineWeight = 1!
            Me.Line15.Name = "Line15"
            Me.Line15.Top = 0!
            Me.Line15.Width = 9.6875!
            Me.Line15.X1 = 9.6875!
            Me.Line15.X2 = 0!
            Me.Line15.Y1 = 0!
            Me.Line15.Y2 = 0!
            '
            'ActiveReport1
            '
            Me.MasterReport = false
            Me.PageSettings.Margins.Left = 0.39375!
            Me.PageSettings.Margins.Right = 0.39375!
            Me.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Landscape
            Me.PageSettings.PaperHeight = 11!
            Me.PageSettings.PaperWidth = 8.5!
            Me.PrintWidth = 10.125!
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
            CType(Me.lblTitulo,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblRango,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblFecha,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label17,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox1,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblSucursal,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).EndInit
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
            CType(Me.Label14,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label15,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label16,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtCodigo,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtNombre,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtTenis,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtImporteTenis,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtTextil,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtImporteTextil,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtAccesorio,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtImporteAccesorio,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtCalzado,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtImporteCalzado,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtSandalias,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtImporteSandalias,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtPiezas,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtImporteNeto,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtIndicador,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox2,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox3,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox4,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox5,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox6,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox7,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox8,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox9,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox10,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox11,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox12,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox13,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label18,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        End Sub

#End Region

End Class
