Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Imports DportenisPro.DPTienda.ApplicationUnits.CierreCaja
Imports DportenisPro.DPTienda.ApplicationUnits.ArqueoDeCajaAU
Imports DportenisPro.DPTienda.ApplicationUnits.DPValeFinanciero

Public Class rptConcentradoMiniPrinter
    Inherits DataDynamics.ActiveReports.ActiveReport

    Private oCierreCaja As Caja
    Private oDpvMgr As New DPValeFinancieroManager(oAppContext, oConfigCierreFI)

    Private oCierreCajasMgr As CierreCajaManager
    Friend WithEvents lblCreditosAprobados As DataDynamics.ActiveReports.Label
    Friend WithEvents txtCreditoAprobados As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblCreditosCancelados As DataDynamics.ActiveReports.Label
    Friend WithEvents txtCreditoCancelados As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Line3 As DataDynamics.ActiveReports.Line

    Private oArqueoCaja As ArqueoDeCajaManager

    Public Sub New(ByVal Fecha As Date, ByVal strAlmacen As String)
        MyBase.New()
        InitializeComponent()
        Me.txtAlmacen.Text = strAlmacen
        Me.txtFecha.Text = Fecha.ToShortDateString

        oCierreCajasMgr = New CierreCajaManager(oAppContext)

        'OJO' EL CAMPO RETIROS DEBE DE SER IGAUL AL EFECTIVO DEL DIA
        oArqueoCaja = New ArqueoDeCajaManager(oAppContext)
        Dim efectivo As Decimal = oArqueoCaja.IngresosDiaREP(Fecha, oAppContext.ApplicationConfiguration.Almacen)
        'ASIGNO EL TOTAL DE EFECTIVO AL CAMPO EBEFECTIVO 'EFECTIVO
        Me.TextBox3.Text = Format(efectivo, "C")

        'ASIGNO EL TOTAL DE TARJETAS ELECTRONICAS ''TARJETA ELECTRONICA
        Me.TextBox1.Text = Format(oCierreCajasMgr.TarjetaElectronicaGETREP(Fecha), "C")

        'ASIGNO EL TOTAL DE TARJETAS MANUALES ''TARJETA MANUAL
        Me.TextBox2.Text = Format(oCierreCajasMgr.TarjetaManualGETREP(Fecha), "C")
        'ASIGNO EL TOTAL DE ABONOS APARTADOS ''ABONOS APARTADOS
        'Me.TextBox7.Text = Format(oCierreCajasMgr.AbonosApartadosGETREP(Fecha), "C")

        'ASIGNO EL TOTAL DE ABONOS C.DIRECTO ''ABONOS C.DIRECTO
        'Me.TextBox8.Text = Format(oCierreCajasMgr.CreditoDirectoGETREP(Fecha), "C")

        'ASIGNO EL TOTAL DE ABONOS ''TOTAL ABONOS
        'Me.TextBox9.Text = Format(CDec(TextBox7.Text) + CDec(TextBox8.Text), "C")

        'ASIGNO EL TOTAL DE DPVALE 
        Me.TextBox4.Text = Format(oCierreCajasMgr.FormasPagoGETREP(Fecha, "CierreDeCajaDpValeMontoGETREP"), "C")

        'ASIGNO EL TOTAL DE FONACOT 
        Me.TextBox5.Text = Format(oCierreCajasMgr.FormasPagoGETREP(Fecha, "CierreDeCajaFonacotMontoGETREP"), "C")

        'ASIGNO EL TOTAL DE FACILITO
        Me.TextBox6.Text = Format(oCierreCajasMgr.FormasPagoGETREP(Fecha, "CierreDeCajaFacilitoMontoGETREP"), "C")

        'ASIGNO EL TOTAL DE VAle de Caja
        Me.TextBox10.Text = Format(oCierreCajasMgr.FormasPagoGETREP(Fecha, "CierreDeCajaValeCajaMontoGETREP"), "C")

        '----------------------------------------------------------------------------------
        'JNAVA (20.03.2015): ASIGNO EL TOTAL DE DP CARD CREDIT
        '----------------------------------------------------------------------------------
        Me.txtDPCA.Text = Format(oCierreCajasMgr.FormasPagoGETREP(Fecha, "CierreDeCajaDPCardGETREP"), "C")

        'Me.TextBox11.Text = Format(oCierreCajasMgr.CalcularTotalRetirosREP(Fecha), "C")

        'Me.TextBox14.Text = Format(oCierreCajasMgr.CalcularTotalFondoCajaREP(Fecha), "C")

        'ASIGNO EL TOTAL DE FACTURAS ACTIVAS
        Dim dsFacturasA As New DataSet
        Dim dsFacturasC As New DataSet
        Dim dsNC As New DataSet
        dsFacturasA = oCierreCajasMgr.TotalFacturasAGetREP(Fecha)
        If Not IsDBNull(dsFacturasA.Tables(0).Rows(0).Item("Total")) Then
            Me.TextBox15.Text = dsFacturasA.Tables(0).Rows(0).Item("Total")
        Else
            Me.TextBox15.Text = "0"
        End If


        'ASIGNO EL TOTAL DE FACTURAS CANCELADAS
        dsFacturasC = oCierreCajasMgr.TotalFacturasCGetREP(Fecha)
        If Not IsDBNull(dsFacturasC.Tables(0).Rows(0).Item("Total")) Then
            Me.TextBox16.Text = dsFacturasC.Tables(0).Rows(0).Item("Total")
        Else
            Me.TextBox16.Text = "0"
        End If


        'ASIGNO EL TOTAL DE NOTAS DE CREDITO
        dsNC = oCierreCajasMgr.NotasCreditoGETREP(Fecha)
        If Not IsDBNull(dsNC.Tables(0).Rows(0).Item("TotalNC")) Then
            Me.TextBox13.Text = Format(dsNC.Tables(0).Rows(0).Item("TotalNC"), "C")
        Else
            Me.TextBox13.Text = "$0.00"
        End If

        'ASIGNO EL TOTAL DEL MONTO FACTURADO ''TOTAL FACTURADO
        'Format(CDec(TextBox7.Text) + CDec(TextBox8.Text), "C")
        'Me.TextBox12.Text = Format(CDec(TextBox1.Text) + CDec(TextBox2.Text) + CDec(TextBox3.Text) + CDec(TextBox13.Text) + CDec(TextBox4.Text) + CDec(TextBox5.Text) + CDec(TextBox6.Text) + CDec(TextBox10.Text), "C")
        Me.TextBox12.Text = Format(CDec(TextBox1.Text) + CDec(TextBox2.Text) + CDec(TextBox3.Text) + CDec(TextBox4.Text) + CDec(TextBox5.Text) + CDec(TextBox6.Text) + CDec(TextBox10.Text), "C")
        'Me.TextBox12.Text = Format(oCierreCajasMgr.MontoFacturadoGETREP(Fecha), "C")

        dsFacturasA = Nothing
        dsFacturasC = Nothing
        dsNC = Nothing

        '-----------------------------------------------------------------------------------------------------------
        'FLIZARRAGA 19/04/2018: Se pone el total de Microcredito Aprobado y cancelado
        '-----------------------------------------------------------------------------------------------------------
        Dim MicrocreditoAprobado As Decimal = 0, MicrocreditoCancelado As Decimal = 0
        oDpvMgr.GetMontosDisposicionEfeClubDP(Fecha, MicrocreditoAprobado, MicrocreditoCancelado)
        Me.txtCreditoAprobados.Text = Format(MicrocreditoAprobado, "C")
        Me.txtCreditoCancelados.Text = Format(MicrocreditoCancelado, "C")
    End Sub
#Region "ActiveReports Designer generated code"
    Private WithEvents ReportHeader As ReportHeader = Nothing
    Private WithEvents PageHeader As PageHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents PageFooter As PageFooter = Nothing
    Private WithEvents ReportFooter As ReportFooter = Nothing
	Private Label11 As Label = Nothing
	Private Label10 As Label = Nothing
	Private Shape1 As Shape = Nothing
	Private txtAlmacen As TextBox = Nothing
	Private Label3 As Label = Nothing
	Private Label4 As Label = Nothing
	Private Label2 As Label = Nothing
	Private txtFecha As TextBox = Nothing
	Private Label1 As Label = Nothing
	Private Label5 As Label = Nothing
	Private TextBox2 As TextBox = Nothing
	Private Label6 As Label = Nothing
	Private TextBox3 As TextBox = Nothing
	Private Label7 As Label = Nothing
	Private TextBox4 As TextBox = Nothing
	Private Label8 As Label = Nothing
	Private TextBox5 As TextBox = Nothing
	Private Label9 As Label = Nothing
	Private TextBox6 As TextBox = Nothing
	Private TextBox7 As TextBox = Nothing
	Private TextBox8 As TextBox = Nothing
	Private Label12 As Label = Nothing
	Private TextBox9 As TextBox = Nothing
	Private Label13 As Label = Nothing
	Private TextBox10 As TextBox = Nothing
	Private Label14 As Label = Nothing
	Private TextBox11 As TextBox = Nothing
	Private Label15 As Label = Nothing
	Private TextBox12 As TextBox = Nothing
	Private Label17 As Label = Nothing
	Private TextBox14 As TextBox = Nothing
	Private Label18 As Label = Nothing
	Private TextBox15 As TextBox = Nothing
	Private Label19 As Label = Nothing
	Private TextBox16 As TextBox = Nothing
	Private Line1 As Line = Nothing
	Private Line2 As Line = Nothing
	Private Line4 As Line = Nothing
	Private TextBox13 As TextBox = Nothing
	Private Label16 As Label = Nothing
	Private TextBox1 As TextBox = Nothing
	Private Line5 As Line = Nothing
	Private Label20 As Label = Nothing
	Private txtDPCA As TextBox = Nothing
	Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptConcentradoMiniPrinter))
        Me.Detail = New DataDynamics.ActiveReports.Detail()
        Me.ReportHeader = New DataDynamics.ActiveReports.ReportHeader()
        Me.Label11 = New DataDynamics.ActiveReports.Label()
        Me.Label10 = New DataDynamics.ActiveReports.Label()
        Me.Shape1 = New DataDynamics.ActiveReports.Shape()
        Me.txtAlmacen = New DataDynamics.ActiveReports.TextBox()
        Me.Label3 = New DataDynamics.ActiveReports.Label()
        Me.Label4 = New DataDynamics.ActiveReports.Label()
        Me.Label2 = New DataDynamics.ActiveReports.Label()
        Me.txtFecha = New DataDynamics.ActiveReports.TextBox()
        Me.Label1 = New DataDynamics.ActiveReports.Label()
        Me.Label5 = New DataDynamics.ActiveReports.Label()
        Me.TextBox2 = New DataDynamics.ActiveReports.TextBox()
        Me.Label6 = New DataDynamics.ActiveReports.Label()
        Me.TextBox3 = New DataDynamics.ActiveReports.TextBox()
        Me.Label7 = New DataDynamics.ActiveReports.Label()
        Me.TextBox4 = New DataDynamics.ActiveReports.TextBox()
        Me.Label8 = New DataDynamics.ActiveReports.Label()
        Me.TextBox5 = New DataDynamics.ActiveReports.TextBox()
        Me.Label9 = New DataDynamics.ActiveReports.Label()
        Me.TextBox6 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox7 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox8 = New DataDynamics.ActiveReports.TextBox()
        Me.Label12 = New DataDynamics.ActiveReports.Label()
        Me.TextBox9 = New DataDynamics.ActiveReports.TextBox()
        Me.Label13 = New DataDynamics.ActiveReports.Label()
        Me.TextBox10 = New DataDynamics.ActiveReports.TextBox()
        Me.Label14 = New DataDynamics.ActiveReports.Label()
        Me.TextBox11 = New DataDynamics.ActiveReports.TextBox()
        Me.Label15 = New DataDynamics.ActiveReports.Label()
        Me.TextBox12 = New DataDynamics.ActiveReports.TextBox()
        Me.Label17 = New DataDynamics.ActiveReports.Label()
        Me.TextBox14 = New DataDynamics.ActiveReports.TextBox()
        Me.Label18 = New DataDynamics.ActiveReports.Label()
        Me.TextBox15 = New DataDynamics.ActiveReports.TextBox()
        Me.Label19 = New DataDynamics.ActiveReports.Label()
        Me.TextBox16 = New DataDynamics.ActiveReports.TextBox()
        Me.Line1 = New DataDynamics.ActiveReports.Line()
        Me.Line2 = New DataDynamics.ActiveReports.Line()
        Me.Line4 = New DataDynamics.ActiveReports.Line()
        Me.TextBox13 = New DataDynamics.ActiveReports.TextBox()
        Me.Label16 = New DataDynamics.ActiveReports.Label()
        Me.TextBox1 = New DataDynamics.ActiveReports.TextBox()
        Me.Line5 = New DataDynamics.ActiveReports.Line()
        Me.Label20 = New DataDynamics.ActiveReports.Label()
        Me.txtDPCA = New DataDynamics.ActiveReports.TextBox()
        Me.lblCreditosAprobados = New DataDynamics.ActiveReports.Label()
        Me.txtCreditoAprobados = New DataDynamics.ActiveReports.TextBox()
        Me.lblCreditosCancelados = New DataDynamics.ActiveReports.Label()
        Me.txtCreditoCancelados = New DataDynamics.ActiveReports.TextBox()
        Me.ReportFooter = New DataDynamics.ActiveReports.ReportFooter()
        Me.PageHeader = New DataDynamics.ActiveReports.PageHeader()
        Me.PageFooter = New DataDynamics.ActiveReports.PageFooter()
        Me.Line3 = New DataDynamics.ActiveReports.Line()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAlmacen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label19, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label20, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDPCA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblCreditosAprobados, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCreditoAprobados, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblCreditosCancelados, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCreditoCancelados, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.ColumnSpacing = 0.0!
        Me.Detail.Height = 0.0!
        Me.Detail.Name = "Detail"
        '
        'ReportHeader
        '
        Me.ReportHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label11, Me.Label10, Me.Shape1, Me.txtAlmacen, Me.Label3, Me.Label4, Me.Label2, Me.txtFecha, Me.Label1, Me.Label5, Me.TextBox2, Me.Label6, Me.TextBox3, Me.Label7, Me.TextBox4, Me.Label8, Me.TextBox5, Me.Label9, Me.TextBox6, Me.TextBox7, Me.TextBox8, Me.Label12, Me.TextBox9, Me.Label13, Me.TextBox10, Me.Label14, Me.TextBox11, Me.Label15, Me.TextBox12, Me.Label17, Me.TextBox14, Me.Label18, Me.TextBox15, Me.Label19, Me.TextBox16, Me.Line1, Me.Line2, Me.Line4, Me.TextBox13, Me.Label16, Me.TextBox1, Me.Line5, Me.Label20, Me.txtDPCA, Me.lblCreditosAprobados, Me.txtCreditoAprobados, Me.lblCreditosCancelados, Me.txtCreditoCancelados, Me.Line3})
        Me.ReportHeader.Height = 3.988889!
        Me.ReportHeader.Name = "ReportHeader"
        '
        'Label11
        '
        Me.Label11.Height = 0.14!
        Me.Label11.HyperLink = Nothing
        Me.Label11.Left = 3.597441!
        Me.Label11.Name = "Label11"
        Me.Label11.Style = "font-weight: normal; font-size: 8.25pt"
        Me.Label11.Text = "ABONOS C. DIRECTO:"
        Me.Label11.Top = 2.533465!
        Me.Label11.Width = 1.248392!
        '
        'Label10
        '
        Me.Label10.Height = 0.14!
        Me.Label10.HyperLink = Nothing
        Me.Label10.Left = 3.597441!
        Me.Label10.Name = "Label10"
        Me.Label10.Style = "font-weight: normal; font-size: 8.25pt"
        Me.Label10.Text = "ABONOS APARTADOS:"
        Me.Label10.Top = 2.343504!
        Me.Label10.Width = 1.381726!
        '
        'Shape1
        '
        Me.Shape1.Height = 0.753!
        Me.Shape1.Left = 0.284941!
        Me.Shape1.Name = "Shape1"
        Me.Shape1.RoundingRadius = 9.999999!
        Me.Shape1.Top = 0.0!
        Me.Shape1.Width = 2.4!
        '
        'txtAlmacen
        '
        Me.txtAlmacen.Height = 0.2!
        Me.txtAlmacen.Left = 0.9!
        Me.txtAlmacen.MultiLine = False
        Me.txtAlmacen.Name = "txtAlmacen"
        Me.txtAlmacen.Style = "font-size: 9pt"
        Me.txtAlmacen.Text = "TextBox1"
        Me.txtAlmacen.Top = 0.5625!
        Me.txtAlmacen.Width = 1.7!
        '
        'Label3
        '
        Me.Label3.Height = 0.2!
        Me.Label3.HyperLink = Nothing
        Me.Label3.Left = 0.3!
        Me.Label3.Name = "Label3"
        Me.Label3.Style = "font-weight: bold; font-size: 8.25pt"
        Me.Label3.Text = "Sucursal:"
        Me.Label3.Top = 0.5625!
        Me.Label3.Width = 0.625!
        '
        'Label4
        '
        Me.Label4.Height = 0.14!
        Me.Label4.HyperLink = Nothing
        Me.Label4.Left = 0.284941!
        Me.Label4.Name = "Label4"
        Me.Label4.Style = "font-weight: normal; font-size: 8.25pt"
        Me.Label4.Text = "TARJETA ELECTRÓNICA:"
        Me.Label4.Top = 0.7874014!
        Me.Label4.Width = 1.515059!
        '
        'Label2
        '
        Me.Label2.Height = 0.15!
        Me.Label2.HyperLink = Nothing
        Me.Label2.Left = 0.7185042!
        Me.Label2.Name = "Label2"
        Me.Label2.Style = "font-weight: bold; font-size: 8.25pt"
        Me.Label2.Text = "Fecha:"
        Me.Label2.Top = 0.3975!
        Me.Label2.Width = 0.5!
        '
        'txtFecha
        '
        Me.txtFecha.Height = 0.15!
        Me.txtFecha.Left = 1.22!
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.Text = "txtFecha"
        Me.txtFecha.Top = 0.3975!
        Me.txtFecha.Width = 1.0!
        '
        'Label1
        '
        Me.Label1.Height = 0.3170932!
        Me.Label1.HyperLink = Nothing
        Me.Label1.Left = 0.6105!
        Me.Label1.Name = "Label1"
        Me.Label1.Style = "text-align: center; font-weight: bold; font-size: 9.75pt"
        Me.Label1.Text = "Reporte Concentrado de Cierre de Día"
        Me.Label1.Top = 0.01624015!
        Me.Label1.Width = 1.656167!
        '
        'Label5
        '
        Me.Label5.Height = 0.14!
        Me.Label5.HyperLink = Nothing
        Me.Label5.Left = 0.284941!
        Me.Label5.Name = "Label5"
        Me.Label5.Style = "font-weight: normal; font-size: 8.25pt"
        Me.Label5.Text = "TARJETA MANUAL:"
        Me.Label5.Top = 0.9611222!
        Me.Label5.Width = 1.381726!
        '
        'TextBox2
        '
        Me.TextBox2.Height = 0.14!
        Me.TextBox2.Left = 1.666667!
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.OutputFormat = resources.GetString("TextBox2.OutputFormat")
        Me.TextBox2.Style = "text-align: right; font-weight: normal; font-size: 9.75pt"
        Me.TextBox2.Text = Nothing
        Me.TextBox2.Top = 0.9611222!
        Me.TextBox2.Width = 0.9991792!
        '
        'Label6
        '
        Me.Label6.Height = 0.14!
        Me.Label6.HyperLink = Nothing
        Me.Label6.Left = 0.284941!
        Me.Label6.Name = "Label6"
        Me.Label6.Style = "font-weight: normal; font-size: 8.25pt"
        Me.Label6.Text = "EFECTIVO:"
        Me.Label6.Top = 1.134842!
        Me.Label6.Width = 1.248392!
        '
        'TextBox3
        '
        Me.TextBox3.Height = 0.14!
        Me.TextBox3.Left = 1.533333!
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.OutputFormat = resources.GetString("TextBox3.OutputFormat")
        Me.TextBox3.Style = "text-align: right; font-weight: normal; font-size: 9.75pt"
        Me.TextBox3.Text = Nothing
        Me.TextBox3.Top = 1.133333!
        Me.TextBox3.Width = 1.132512!
        '
        'Label7
        '
        Me.Label7.Height = 0.14!
        Me.Label7.HyperLink = Nothing
        Me.Label7.Left = 0.284941!
        Me.Label7.Name = "Label7"
        Me.Label7.Style = "font-weight: normal; font-size: 8.25pt"
        Me.Label7.Text = "DPVALE:"
        Me.Label7.Top = 1.553642!
        Me.Label7.Width = 0.944882!
        '
        'TextBox4
        '
        Me.TextBox4.Height = 0.14!
        Me.TextBox4.Left = 1.4!
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.OutputFormat = resources.GetString("TextBox4.OutputFormat")
        Me.TextBox4.Style = "text-align: right; font-weight: normal; font-size: 9.75pt"
        Me.TextBox4.Text = Nothing
        Me.TextBox4.Top = 1.553642!
        Me.TextBox4.Width = 1.265846!
        '
        'Label8
        '
        Me.Label8.Height = 0.14!
        Me.Label8.HyperLink = Nothing
        Me.Label8.Left = 0.284941!
        Me.Label8.Name = "Label8"
        Me.Label8.Style = "font-weight: normal; font-size: 8.25pt"
        Me.Label8.Text = "FONACOT:"
        Me.Label8.Top = 1.727362!
        Me.Label8.Width = 0.944882!
        '
        'TextBox5
        '
        Me.TextBox5.Height = 0.14!
        Me.TextBox5.Left = 1.4!
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.OutputFormat = resources.GetString("TextBox5.OutputFormat")
        Me.TextBox5.Style = "text-align: right; font-weight: normal; font-size: 9.75pt"
        Me.TextBox5.Text = Nothing
        Me.TextBox5.Top = 1.727362!
        Me.TextBox5.Width = 1.265846!
        '
        'Label9
        '
        Me.Label9.Height = 0.14!
        Me.Label9.HyperLink = Nothing
        Me.Label9.Left = 0.284941!
        Me.Label9.Name = "Label9"
        Me.Label9.Style = "font-weight: normal; font-size: 8.25pt"
        Me.Label9.Text = "FACILITO:"
        Me.Label9.Top = 1.901083!
        Me.Label9.Width = 0.944882!
        '
        'TextBox6
        '
        Me.TextBox6.Height = 0.14!
        Me.TextBox6.Left = 1.4!
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.OutputFormat = resources.GetString("TextBox6.OutputFormat")
        Me.TextBox6.Style = "text-align: right; font-weight: normal; font-size: 9.75pt"
        Me.TextBox6.Text = Nothing
        Me.TextBox6.Top = 1.901083!
        Me.TextBox6.Width = 1.265846!
        '
        'TextBox7
        '
        Me.TextBox7.Height = 0.14!
        Me.TextBox7.Left = 4.845833!
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.OutputFormat = resources.GetString("TextBox7.OutputFormat")
        Me.TextBox7.Style = "text-align: right; font-weight: normal; font-size: 9.75pt"
        Me.TextBox7.Text = Nothing
        Me.TextBox7.Top = 2.333333!
        Me.TextBox7.Width = 1.132512!
        '
        'TextBox8
        '
        Me.TextBox8.Height = 0.14!
        Me.TextBox8.Left = 4.779167!
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.OutputFormat = resources.GetString("TextBox8.OutputFormat")
        Me.TextBox8.Style = "text-align: right; font-weight: normal; font-size: 9.75pt"
        Me.TextBox8.Text = Nothing
        Me.TextBox8.Top = 2.533465!
        Me.TextBox8.Width = 1.199179!
        '
        'Label12
        '
        Me.Label12.Height = 0.14!
        Me.Label12.HyperLink = Nothing
        Me.Label12.Left = 3.597441!
        Me.Label12.Name = "Label12"
        Me.Label12.Style = "font-weight: normal; font-size: 8.25pt"
        Me.Label12.Text = "TOTAL ABONOS:"
        Me.Label12.Top = 2.723426!
        Me.Label12.Width = 1.115059!
        '
        'TextBox9
        '
        Me.TextBox9.Height = 0.14!
        Me.TextBox9.Left = 4.779167!
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.OutputFormat = resources.GetString("TextBox9.OutputFormat")
        Me.TextBox9.Style = "text-align: right; font-weight: normal; font-size: 9.75pt"
        Me.TextBox9.Text = Nothing
        Me.TextBox9.Top = 2.723425!
        Me.TextBox9.Width = 1.199179!
        '
        'Label13
        '
        Me.Label13.Height = 0.14!
        Me.Label13.HyperLink = Nothing
        Me.Label13.Left = 0.284941!
        Me.Label13.Name = "Label13"
        Me.Label13.Style = "font-weight: normal; font-size: 8.25pt"
        Me.Label13.Text = "VALE DE CAJA:"
        Me.Label13.Top = 2.074804!
        Me.Label13.Width = 0.944882!
        '
        'TextBox10
        '
        Me.TextBox10.Height = 0.14!
        Me.TextBox10.Left = 1.4!
        Me.TextBox10.Name = "TextBox10"
        Me.TextBox10.OutputFormat = resources.GetString("TextBox10.OutputFormat")
        Me.TextBox10.Style = "text-align: right; font-weight: normal; font-size: 9.75pt"
        Me.TextBox10.Text = Nothing
        Me.TextBox10.Top = 2.074804!
        Me.TextBox10.Width = 1.265846!
        '
        'Label14
        '
        Me.Label14.Height = 0.14!
        Me.Label14.HyperLink = Nothing
        Me.Label14.Left = 3.597441!
        Me.Label14.Name = "Label14"
        Me.Label14.Style = "font-weight: normal; font-size: 8.25pt"
        Me.Label14.Text = "RETIROS:"
        Me.Label14.Top = 3.220965!
        Me.Label14.Width = 0.944882!
        '
        'TextBox11
        '
        Me.TextBox11.Height = 0.14!
        Me.TextBox11.Left = 4.779167!
        Me.TextBox11.Name = "TextBox11"
        Me.TextBox11.OutputFormat = resources.GetString("TextBox11.OutputFormat")
        Me.TextBox11.Style = "text-align: right; font-weight: normal; font-size: 9.75pt"
        Me.TextBox11.Text = Nothing
        Me.TextBox11.Top = 3.220965!
        Me.TextBox11.Width = 1.199179!
        '
        'Label15
        '
        Me.Label15.Height = 0.14!
        Me.Label15.HyperLink = Nothing
        Me.Label15.Left = 0.284941!
        Me.Label15.Name = "Label15"
        Me.Label15.Style = "font-weight: normal; font-size: 8.25pt"
        Me.Label15.Text = "TOTAL INGRESO:"
        Me.Label15.Top = 2.535925!
        Me.Label15.Width = 1.181726!
        '
        'TextBox12
        '
        Me.TextBox12.Height = 0.14!
        Me.TextBox12.Left = 1.466667!
        Me.TextBox12.Name = "TextBox12"
        Me.TextBox12.OutputFormat = resources.GetString("TextBox12.OutputFormat")
        Me.TextBox12.Style = "text-align: right; font-weight: normal; font-size: 9.75pt"
        Me.TextBox12.Text = Nothing
        Me.TextBox12.Top = 2.535925!
        Me.TextBox12.Width = 1.199179!
        '
        'Label17
        '
        Me.Label17.Height = 0.14!
        Me.Label17.HyperLink = Nothing
        Me.Label17.Left = 3.597441!
        Me.Label17.Name = "Label17"
        Me.Label17.Style = "font-weight: normal; font-size: 8.25pt"
        Me.Label17.Text = "FONDO DE CAJA:"
        Me.Label17.Top = 3.033465!
        Me.Label17.Width = 1.015059!
        '
        'TextBox14
        '
        Me.TextBox14.Height = 0.14!
        Me.TextBox14.Left = 4.779167!
        Me.TextBox14.Name = "TextBox14"
        Me.TextBox14.OutputFormat = resources.GetString("TextBox14.OutputFormat")
        Me.TextBox14.Style = "text-align: right; font-weight: normal; font-size: 9.75pt"
        Me.TextBox14.Text = Nothing
        Me.TextBox14.Top = 3.033465!
        Me.TextBox14.Width = 1.199179!
        '
        'Label18
        '
        Me.Label18.Height = 0.14!
        Me.Label18.HyperLink = Nothing
        Me.Label18.Left = 0.284941!
        Me.Label18.Name = "Label18"
        Me.Label18.Style = "font-weight: normal; font-size: 8.25pt"
        Me.Label18.Text = "FACTURAS ACTIVAS:"
        Me.Label18.Top = 2.867126!
        Me.Label18.Width = 1.27!
        '
        'TextBox15
        '
        Me.TextBox15.Height = 0.14!
        Me.TextBox15.Left = 2.0!
        Me.TextBox15.Name = "TextBox15"
        Me.TextBox15.OutputFormat = resources.GetString("TextBox15.OutputFormat")
        Me.TextBox15.Style = "text-align: right; font-weight: normal; font-size: 9.75pt"
        Me.TextBox15.Text = Nothing
        Me.TextBox15.Top = 2.867126!
        Me.TextBox15.Width = 0.6658459!
        '
        'Label19
        '
        Me.Label19.Height = 0.14!
        Me.Label19.HyperLink = Nothing
        Me.Label19.Left = 0.284941!
        Me.Label19.Name = "Label19"
        Me.Label19.Style = "font-weight: normal; font-size: 8.25pt"
        Me.Label19.Text = "FACTURAS CANCELADAS:"
        Me.Label19.Top = 3.040846!
        Me.Label19.Width = 1.648392!
        '
        'TextBox16
        '
        Me.TextBox16.Height = 0.14!
        Me.TextBox16.Left = 2.0!
        Me.TextBox16.Name = "TextBox16"
        Me.TextBox16.OutputFormat = resources.GetString("TextBox16.OutputFormat")
        Me.TextBox16.Style = "text-align: right; font-weight: normal; font-size: 9.75pt"
        Me.TextBox16.Text = Nothing
        Me.TextBox16.Top = 3.040846!
        Me.TextBox16.Width = 0.6658459!
        '
        'Line1
        '
        Me.Line1.Height = 0.0!
        Me.Line1.Left = 0.25!
        Me.Line1.LineWeight = 1.0!
        Me.Line1.Name = "Line1"
        Me.Line1.Top = 1.473611!
        Me.Line1.Width = 2.4!
        Me.Line1.X1 = 2.65!
        Me.Line1.X2 = 0.25!
        Me.Line1.Y1 = 1.473611!
        Me.Line1.Y2 = 1.473611!
        '
        'Line2
        '
        Me.Line2.Height = 0.0!
        Me.Line2.Left = 0.25!
        Me.Line2.LineWeight = 1.0!
        Me.Line2.Name = "Line2"
        Me.Line2.Top = 2.461111!
        Me.Line2.Width = 2.4!
        Me.Line2.X1 = 2.65!
        Me.Line2.X2 = 0.25!
        Me.Line2.Y1 = 2.461111!
        Me.Line2.Y2 = 2.461111!
        '
        'Line4
        '
        Me.Line4.Height = 0.0!
        Me.Line4.Left = 0.25!
        Me.Line4.LineWeight = 1.0!
        Me.Line4.Name = "Line4"
        Me.Line4.Top = 2.781945!
        Me.Line4.Width = 2.4!
        Me.Line4.X1 = 2.65!
        Me.Line4.X2 = 0.25!
        Me.Line4.Y1 = 2.781945!
        Me.Line4.Y2 = 2.781945!
        '
        'TextBox13
        '
        Me.TextBox13.Height = 0.14!
        Me.TextBox13.Left = 1.533333!
        Me.TextBox13.Name = "TextBox13"
        Me.TextBox13.OutputFormat = resources.GetString("TextBox13.OutputFormat")
        Me.TextBox13.Style = "text-align: right; font-weight: normal; font-size: 9.75pt"
        Me.TextBox13.Text = Nothing
        Me.TextBox13.Top = 1.284613!
        Me.TextBox13.Width = 1.132512!
        '
        'Label16
        '
        Me.Label16.Height = 0.14!
        Me.Label16.HyperLink = Nothing
        Me.Label16.Left = 0.284941!
        Me.Label16.Name = "Label16"
        Me.Label16.Style = "font-weight: normal; font-size: 8.25pt"
        Me.Label16.Text = "NOTAS DE CRÉDITO:"
        Me.Label16.Top = 1.284613!
        Me.Label16.Width = 1.248392!
        '
        'TextBox1
        '
        Me.TextBox1.Height = 0.14!
        Me.TextBox1.Left = 1.666667!
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.OutputFormat = resources.GetString("TextBox1.OutputFormat")
        Me.TextBox1.Style = "text-align: right; font-weight: normal; font-size: 9.75pt"
        Me.TextBox1.Text = Nothing
        Me.TextBox1.Top = 0.7874014!
        Me.TextBox1.Width = 0.9991792!
        '
        'Line5
        '
        Me.Line5.Height = 0.0!
        Me.Line5.Left = 0.2736111!
        Me.Line5.LineWeight = 1.0!
        Me.Line5.Name = "Line5"
        Me.Line5.Top = 3.336111!
        Me.Line5.Width = 2.4!
        Me.Line5.X1 = 2.673611!
        Me.Line5.X2 = 0.2736111!
        Me.Line5.Y1 = 3.336111!
        Me.Line5.Y2 = 3.336111!
        '
        'Label20
        '
        Me.Label20.Height = 0.14!
        Me.Label20.HyperLink = Nothing
        Me.Label20.Left = 0.285!
        Me.Label20.Name = "Label20"
        Me.Label20.Style = "font-weight: normal; font-size: 8.25pt"
        Me.Label20.Text = "DP CARD:"
        Me.Label20.Top = 2.25!
        Me.Label20.Width = 0.944882!
        '
        'txtDPCA
        '
        Me.txtDPCA.Height = 0.14!
        Me.txtDPCA.Left = 1.4!
        Me.txtDPCA.Name = "txtDPCA"
        Me.txtDPCA.OutputFormat = resources.GetString("txtDPCA.OutputFormat")
        Me.txtDPCA.Style = "text-align: right; font-weight: normal; font-size: 9.75pt"
        Me.txtDPCA.Text = Nothing
        Me.txtDPCA.Top = 2.25!
        Me.txtDPCA.Width = 1.265846!
        '
        'lblCreditosAprobados
        '
        Me.lblCreditosAprobados.Height = 0.14!
        Me.lblCreditosAprobados.HyperLink = Nothing
        Me.lblCreditosAprobados.Left = 0.285!
        Me.lblCreditosAprobados.Name = "lblCreditosAprobados"
        Me.lblCreditosAprobados.Style = "font-weight: normal; font-size: 8.25pt"
        Me.lblCreditosAprobados.Text = "CREDITOS APROBADOS:"
        Me.lblCreditosAprobados.Top = 3.417!
        Me.lblCreditosAprobados.Width = 1.49!
        '
        'txtCreditoAprobados
        '
        Me.txtCreditoAprobados.Height = 0.14!
        Me.txtCreditoAprobados.Left = 1.775!
        Me.txtCreditoAprobados.Name = "txtCreditoAprobados"
        Me.txtCreditoAprobados.OutputFormat = resources.GetString("txtCreditoAprobados.OutputFormat")
        Me.txtCreditoAprobados.Style = "text-align: right; font-weight: normal; font-size: 9.75pt"
        Me.txtCreditoAprobados.Text = Nothing
        Me.txtCreditoAprobados.Top = 3.417!
        Me.txtCreditoAprobados.Width = 0.8640001!
        '
        'lblCreditosCancelados
        '
        Me.lblCreditosCancelados.Height = 0.14!
        Me.lblCreditosCancelados.HyperLink = Nothing
        Me.lblCreditosCancelados.Left = 0.285!
        Me.lblCreditosCancelados.Name = "lblCreditosCancelados"
        Me.lblCreditosCancelados.Style = "font-weight: normal; font-size: 8.25pt"
        Me.lblCreditosCancelados.Text = "CREDITOS CANCELADOS:"
        Me.lblCreditosCancelados.Top = 3.597!
        Me.lblCreditosCancelados.Width = 1.49!
        '
        'txtCreditoCancelados
        '
        Me.txtCreditoCancelados.Height = 0.14!
        Me.txtCreditoCancelados.Left = 1.796!
        Me.txtCreditoCancelados.Name = "txtCreditoCancelados"
        Me.txtCreditoCancelados.OutputFormat = resources.GetString("txtCreditoCancelados.OutputFormat")
        Me.txtCreditoCancelados.Style = "text-align: right; font-weight: normal; font-size: 9.75pt"
        Me.txtCreditoCancelados.Text = Nothing
        Me.txtCreditoCancelados.Top = 3.597!
        Me.txtCreditoCancelados.Width = 0.8430001!
        '
        'ReportFooter
        '
        Me.ReportFooter.Height = 0.0!
        Me.ReportFooter.Name = "ReportFooter"
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
        'Line3
        '
        Me.Line3.Height = 0.0!
        Me.Line3.Left = 0.2739999!
        Me.Line3.LineWeight = 1.0!
        Me.Line3.Name = "Line3"
        Me.Line3.Top = 3.854!
        Me.Line3.Width = 2.4!
        Me.Line3.X1 = 2.674!
        Me.Line3.X2 = 0.2739999!
        Me.Line3.Y1 = 3.854!
        Me.Line3.Y2 = 3.854!
        '
        'rptConcentradoMiniPrinter
        '
        Me.MasterReport = False
        Me.PageSettings.Margins.Bottom = 0.0!
        Me.PageSettings.Margins.Left = 0.0!
        Me.PageSettings.Margins.Right = 0.0!
        Me.PageSettings.Margins.Top = 0.0!
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 2.688!
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
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAlmacen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label19, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label20, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDPCA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblCreditosAprobados, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCreditoAprobados, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblCreditosCancelados, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCreditoCancelados, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

#End Region
End Class
