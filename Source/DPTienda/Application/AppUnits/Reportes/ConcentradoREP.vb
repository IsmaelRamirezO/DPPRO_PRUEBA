Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Imports DportenisPro.DPTienda.ApplicationUnits.CierreCaja
Imports DportenisPro.DPTienda.ApplicationUnits.ArqueoDeCajaAU
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoFormasPago


Public Class ConcentradoREP
    Inherits DataDynamics.ActiveReports.ActiveReport

    Private oCierreCaja As Caja

    Private oCierreCajasMgr As CierreCajaManager

    Private pagoMgr As CatalogoFormasPagoManager
    Friend WithEvents lblEcommDPVale As DataDynamics.ActiveReports.Label
    Friend WithEvents txtEcommDPVale As DataDynamics.ActiveReports.TextBox

    Private oArqueoCaja As ArqueoDeCajaManager

    Public Sub New(ByVal Fecha As Date, ByVal strAlmacen As String)
        MyBase.New()
        InitializeComponent()


        Me.txtAlmacen.Text = strAlmacen
        Me.txtFecha.Text = Fecha.ToShortDateString

        oCierreCajasMgr = New CierreCajaManager(oAppContext)

        pagoMgr = New CatalogoFormasPagoManager(oAppContext, oConfigCierreFI)
        'OJO' EL CAMPO RETIROS DEBE DE SER IGAUL AL EFECTIVO DEL DIA
        oArqueoCaja = New ArqueoDeCajaManager(oAppContext)
        Dim efectivo As Decimal = oArqueoCaja.IngresosDiaREP(Fecha, oAppContext.ApplicationConfiguration.Almacen)
        'ASIGNO EL TOTAL DE EFECTIVO AL CAMPO EBEFECTIVO 'EFECTIVO
        Me.TextBox3.Text = Format(efectivo, "C")

        'RGERMAIN 19/07/2013: Obtenemos el monto total de los pedidos SH realizados en la fecha seleccionada
        Me.txtPedidosSH.Value = Format(oCierreCajasMgr.MontoPedidosSHGET(Fecha), "C")

        'ASIGNO EL TOTAL DEL MONTO FACTURADO ''TOTAL FACTURADO
        Me.TextBox12.Text = Format(oCierreCajasMgr.MontoFacturadoGETREP(Fecha), "C")

        'ASIGNO EL TOTAL DE TARJETAS ELECTRONICAS ''TARJETA ELECTRONICA
        Me.TextBox1.Text = Format(oCierreCajasMgr.TarjetaElectronicaGETREP(Fecha), "C")

        'ASIGNO EL TOTAL DE TARJETAS ELECTRONICAS DE BANAMEX
        Me.txtBMX.Text = Format(oCierreCajasMgr.TarjetaByBancoGETREP(Fecha, "T3", "TE"), "C")

        'ASIGNO EL TOTAL DE TARJETAS ELECTRONICAS DE BANCOMER
        Me.txtBBVA.Text = Format(oCierreCajasMgr.TarjetaByBancoGETREP(Fecha, "T1", "TE"), "C")

        'ASIGNO EL TOTAL DE TARJETAS ELECTRONICAS DE SERFIN
        Me.txtSERF.Text = Format(oCierreCajasMgr.TarjetaByBancoGETREP(Fecha, "T2", "TE"), "C")

        'ASIGNO EL TOTAL DE TARJETAS MANUALES ''TARJETA MANUAL
        Me.TextBox2.Text = Format(oCierreCajasMgr.TarjetaManualGETREP(Fecha), "C")

        'ASIGNO EL TOTAL DE TARJETAS MANUALES DE BANAMEX
        Me.txtBMXTM.Text = Format(oCierreCajasMgr.TarjetaByBancoGETREP(Fecha, "T3", "TM"), "C")

        'ASIGNO EL TOTAL DE TARJETAS MANUALES DE BANCOMER
        Me.txtBBVATM.Text = Format(oCierreCajasMgr.TarjetaByBancoGETREP(Fecha, "T1", "TM"), "C")

        'ASIGNO EL TOTAL DE TARJETAS MANUALES DE SERFIN
        Me.txtSERFTM.Text = Format(oCierreCajasMgr.TarjetaByBancoGETREP(Fecha, "T2", "TM"), "C")

        'ASIGNO EL TOTAL DE TARJETAS TANTO MANUALES COMO ELECTRONICAS
        Me.tbGlobalTarjetas.Text = Format(CDbl(Me.TextBox1.Text) + CDbl(Me.TextBox2.Text), "C")

        'ASIGNO EL TOTAL DE TARJETAS TANTO MANUALES COMO ELECTRONICAS DE BANAMEX
        Me.tbBMXTotal.Text = Format(CDbl(Me.txtBMX.Text) + CDbl(Me.txtBMXTM.Text), "C")

        'ASIGNO EL TOTAL DE TARJETAS TANTO MANUALES COMO ELECTRONICAS DE BANCOMER
        Me.tbBBVATotal.Text = Format(CDbl(Me.txtBBVA.Text) + CDbl(Me.txtBBVATM.Text), "C")

        'ASIGNO EL TOTAL DE TARJETAS TANTO MANUALES COMO ELECTRONICAS DE SERFIN
        Me.tbSERFTotal.Text = Format(CDbl(Me.txtSERF.Text) + CDbl(Me.txtSERFTM.Text), "C")

        'ASIGNO EL TOTAL DE ABONOS APARTADOS ''ABONOS APARTADOS
        Me.TextBox7.Text = Format(oCierreCajasMgr.AbonosApartadosGETREP(Fecha), "C")

        'ASIGNO EL TOTAL DE ABONOS C.DIRECTO ''ABONOS C.DIRECTO
        Me.TextBox8.Text = Format(oCierreCajasMgr.CreditoDirectoGETREP(Fecha), "C")

        'ASIGNO EL TOTAL DE ABONOS ''TOTAL ABONOS
        Me.TextBox9.Text = Format(CDec(TextBox7.Text) + CDec(TextBox8.Text), "C")

        'ASIGNO EL TOTAL DE DPVALE 
        Me.TextBox4.Text = Format(oCierreCajasMgr.FormasPagoGETREP(Fecha, "CierreDeCajaDpValeMontoGETREP"), "C")

        'ASIGNO EL TOTAL DE FONACOT 
        Me.TextBox5.Text = Format(oCierreCajasMgr.FormasPagoGETREP(Fecha, "CierreDeCajaFonacotMontoGETREP"), "C")

        'ASIGNO EL TOTAL DE FACILITO
        Me.TextBox6.Text = Format(oCierreCajasMgr.FormasPagoGETREP(Fecha, "CierreDeCajaFacilitoMontoGETREP"), "C")

        'ASIGNO EL TOTAL DE VAle de Caja
        Me.TextBox10.Text = Format(oCierreCajasMgr.FormasPagoGETREP(Fecha, "CierreDeCajaValeCajaMontoGETREP"), "C")

        '----------------------------------------------------------------------------------
        'JNAVA (24.03.2015): ASIGNO EL TOTAL DE DP CARD CREDIT
        '----------------------------------------------------------------------------------
        Me.txtDPCARD.Text = Format(oCierreCajasMgr.FormasPagoGETREP(Fecha, "CierreDeCajaDPCardGETREP"), "C")

        Me.TextBox11.Text = Format(oCierreCajasMgr.CalcularTotalRetirosREP(Fecha), "C")

        Me.TextBox14.Text = Format(oCierreCajasMgr.CalcularTotalFondoCajaREP(Fecha), "C")

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

        If oConfigCierreFI.RecibirOtrosPagos = True Then
            Me.txtEcommerce.Visible = True
            Me.txtEfectivo.Visible = True
            Me.txtCreditoDebito.Visible = True
            Me.lblEcommerce.Visible = True
            Me.lblEfectivo.Visible = True
            Me.lblCredito.Visible = True
            Me.lblEcommDPVale.Visible = True
            Me.txtEcommDPVale.Visible = True
            Dim PagoEcommerce As Decimal = oCierreCajasMgr.GetTotalPagosEcommerce(oAppContext.ApplicationConfiguration.Almacen, Fecha, Fecha)
            Dim PagoEfectivoEcommerce As Decimal = oCierreCajasMgr.GetTotalFormasPagoEcommerce(1, oAppContext.ApplicationConfiguration.Almacen, Fecha, Fecha)
            Dim PagoTarjetaEcommerce As Decimal = oCierreCajasMgr.GetTotalFormasPagoEcommerce(2, oAppContext.ApplicationConfiguration.Almacen, Fecha, Fecha)
            Me.txtEcommerce.Text = Format(PagoEcommerce, "C")
            Me.txtEfectivo.Text = Format(PagoEfectivoEcommerce, "C")
            Me.txtCreditoDebito.Text = Format(PagoTarjetaEcommerce, "C")

            Dim pagoEcommDPVale As Decimal = pagoMgr.GetMontoTotalPagoEcommerceByDate(Fecha)
            Me.txtEcommDPVale.Text = Format(pagoEcommDPVale, "C")
        Else
            Me.txtEcommerce.Visible = False
            Me.txtEfectivo.Visible = False
            Me.txtCreditoDebito.Visible = False
            Me.lblEcommerce.Visible = False
            Me.lblEfectivo.Visible = False
            Me.lblCredito.Visible = False
            Me.lblEcommDPVale.Visible = False
            Me.txtEcommDPVale.Visible = False
        End If

        '---------------------------------------------------------------------------------------------------------------
        ' JNAVA (24.03.2015): Obtenemos lo correspondiente a los Abonos de DPCARd en Base a la Configuracion
        '---------------------------------------------------------------------------------------------------------------
        If oConfigCierreFI.AplicaDPCard = True Then

            '---------------------------------------------------------------------------------------------------------------
            ' Obtenemos los totales
            '---------------------------------------------------------------------------------------------------------------
            Dim PagosDPCA As Hashtable
            PagosDPCA = oCierreCajasMgr.GetPagosDPCA(oAppContext.ApplicationConfiguration.Almacen, Fecha, Fecha)

            '---------------------------------------------------------------------------------------------------------------
            ' Seteamos los totales
            '---------------------------------------------------------------------------------------------------------------
            Me.txtAbonoDPCA.Text = Format(PagosDPCA("TOTAL"), "C")
            Me.txtEfectivoDPCA.Text = Format(PagosDPCA("EFECTIVO"), "C")
            Me.txtCreditoDebitoDPCA.Text = Format(PagosDPCA("TARJETA"), "C")

            '---------------------------------------------------------------------------------------------------------------
            ' Mostramos los totales
            '---------------------------------------------------------------------------------------------------------------
            Me.Label29.Visible = True
            Me.Label30.Visible = True
            Me.Label31.Visible = True
            Me.txtAbonoDPCA.Visible = True
            Me.txtEfectivoDPCA.Visible = True
            Me.txtCreditoDebitoDPCA.Visible = True
        End If

        Dim oARReporte As New rptFoliosNC(Fecha)
        SubReport1.Report = oARReporte

        dsFacturasA = Nothing
        dsFacturasC = Nothing
        dsNC = Nothing

    End Sub




#Region "ActiveReports Designer generated code"
    Private WithEvents ReportHeader As ReportHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents ReportFooter As ReportFooter = Nothing
    Private Label29 As Label = Nothing
    Private Shape1 As Shape = Nothing
    Private Label2 As Label = Nothing
    Private txtFecha As TextBox = Nothing
    Private Label3 As Label = Nothing
    Private txtAlmacen As TextBox = Nothing
    Private Label1 As Label = Nothing
    Private Label4 As Label = Nothing
    Private TextBox1 As TextBox = Nothing
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
    Private Label10 As Label = Nothing
    Private TextBox7 As TextBox = Nothing
    Private Label11 As Label = Nothing
    Private TextBox8 As TextBox = Nothing
    Private Label12 As Label = Nothing
    Private TextBox9 As TextBox = Nothing
    Private Label13 As Label = Nothing
    Private TextBox10 As TextBox = Nothing
    Private Label14 As Label = Nothing
    Private TextBox11 As TextBox = Nothing
    Private Label15 As Label = Nothing
    Private TextBox12 As TextBox = Nothing
    Private Line1 As Line = Nothing
    Private Label16 As Label = Nothing
    Private TextBox13 As TextBox = Nothing
    Private Label17 As Label = Nothing
    Private TextBox14 As TextBox = Nothing
    Private Label18 As Label = Nothing
    Private TextBox15 As TextBox = Nothing
    Private Label19 As Label = Nothing
    Private TextBox16 As TextBox = Nothing
    Private Line2 As Line = Nothing
    Private Label20 As Label = Nothing
    Private Label21 As Label = Nothing
    Private Label22 As Label = Nothing
    Private txtBMX As TextBox = Nothing
    Private txtSERF As TextBox = Nothing
    Private txtBBVA As TextBox = Nothing
    Private Label23 As Label = Nothing
    Private Label24 As Label = Nothing
    Private Label25 As Label = Nothing
    Private txtBMXTM As TextBox = Nothing
    Private txtSERFTM As TextBox = Nothing
    Private txtBBVATM As TextBox = Nothing
    Private Label26 As Label = Nothing
    Private SubReport1 As SubReport = Nothing
    Private Label27 As Label = Nothing
    Private tbGlobalTarjetas As TextBox = Nothing
    Private tbBMXTotal As TextBox = Nothing
    Private tbSERFTotal As TextBox = Nothing
    Private tbBBVATotal As TextBox = Nothing
    Private lblPedidosSH As Label = Nothing
    Private txtPedidosSH As TextBox = Nothing
    Private lblEcommerce As Label = Nothing
    Private txtEcommerce As TextBox = Nothing
    Private lblEfectivo As Label = Nothing
    Private txtEfectivo As TextBox = Nothing
    Private lblCredito As Label = Nothing
    Private txtCreditoDebito As TextBox = Nothing
    Private Label28 As Label = Nothing
    Private txtDPCARD As TextBox = Nothing
    Private txtAbonoDPCA As TextBox = Nothing
    Private txtEfectivoDPCA As TextBox = Nothing
    Private Label30 As Label = Nothing
    Private Label31 As Label = Nothing
    Private txtCreditoDebitoDPCA As TextBox = Nothing
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ConcentradoREP))
        Me.Detail = New DataDynamics.ActiveReports.Detail()
        Me.ReportHeader = New DataDynamics.ActiveReports.ReportHeader()
        Me.Label29 = New DataDynamics.ActiveReports.Label()
        Me.Shape1 = New DataDynamics.ActiveReports.Shape()
        Me.Label2 = New DataDynamics.ActiveReports.Label()
        Me.txtFecha = New DataDynamics.ActiveReports.TextBox()
        Me.Label3 = New DataDynamics.ActiveReports.Label()
        Me.txtAlmacen = New DataDynamics.ActiveReports.TextBox()
        Me.Label1 = New DataDynamics.ActiveReports.Label()
        Me.Label4 = New DataDynamics.ActiveReports.Label()
        Me.TextBox1 = New DataDynamics.ActiveReports.TextBox()
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
        Me.Label10 = New DataDynamics.ActiveReports.Label()
        Me.TextBox7 = New DataDynamics.ActiveReports.TextBox()
        Me.Label11 = New DataDynamics.ActiveReports.Label()
        Me.TextBox8 = New DataDynamics.ActiveReports.TextBox()
        Me.Label12 = New DataDynamics.ActiveReports.Label()
        Me.TextBox9 = New DataDynamics.ActiveReports.TextBox()
        Me.Label13 = New DataDynamics.ActiveReports.Label()
        Me.TextBox10 = New DataDynamics.ActiveReports.TextBox()
        Me.Label14 = New DataDynamics.ActiveReports.Label()
        Me.TextBox11 = New DataDynamics.ActiveReports.TextBox()
        Me.Label15 = New DataDynamics.ActiveReports.Label()
        Me.TextBox12 = New DataDynamics.ActiveReports.TextBox()
        Me.Line1 = New DataDynamics.ActiveReports.Line()
        Me.Label16 = New DataDynamics.ActiveReports.Label()
        Me.TextBox13 = New DataDynamics.ActiveReports.TextBox()
        Me.Label17 = New DataDynamics.ActiveReports.Label()
        Me.TextBox14 = New DataDynamics.ActiveReports.TextBox()
        Me.Label18 = New DataDynamics.ActiveReports.Label()
        Me.TextBox15 = New DataDynamics.ActiveReports.TextBox()
        Me.Label19 = New DataDynamics.ActiveReports.Label()
        Me.TextBox16 = New DataDynamics.ActiveReports.TextBox()
        Me.Line2 = New DataDynamics.ActiveReports.Line()
        Me.Label20 = New DataDynamics.ActiveReports.Label()
        Me.Label21 = New DataDynamics.ActiveReports.Label()
        Me.Label22 = New DataDynamics.ActiveReports.Label()
        Me.txtBMX = New DataDynamics.ActiveReports.TextBox()
        Me.txtSERF = New DataDynamics.ActiveReports.TextBox()
        Me.txtBBVA = New DataDynamics.ActiveReports.TextBox()
        Me.Label23 = New DataDynamics.ActiveReports.Label()
        Me.Label24 = New DataDynamics.ActiveReports.Label()
        Me.Label25 = New DataDynamics.ActiveReports.Label()
        Me.txtBMXTM = New DataDynamics.ActiveReports.TextBox()
        Me.txtSERFTM = New DataDynamics.ActiveReports.TextBox()
        Me.txtBBVATM = New DataDynamics.ActiveReports.TextBox()
        Me.Label26 = New DataDynamics.ActiveReports.Label()
        Me.SubReport1 = New DataDynamics.ActiveReports.SubReport()
        Me.Label27 = New DataDynamics.ActiveReports.Label()
        Me.tbGlobalTarjetas = New DataDynamics.ActiveReports.TextBox()
        Me.tbBMXTotal = New DataDynamics.ActiveReports.TextBox()
        Me.tbSERFTotal = New DataDynamics.ActiveReports.TextBox()
        Me.tbBBVATotal = New DataDynamics.ActiveReports.TextBox()
        Me.lblPedidosSH = New DataDynamics.ActiveReports.Label()
        Me.txtPedidosSH = New DataDynamics.ActiveReports.TextBox()
        Me.lblEcommerce = New DataDynamics.ActiveReports.Label()
        Me.txtEcommerce = New DataDynamics.ActiveReports.TextBox()
        Me.lblEfectivo = New DataDynamics.ActiveReports.Label()
        Me.txtEfectivo = New DataDynamics.ActiveReports.TextBox()
        Me.lblCredito = New DataDynamics.ActiveReports.Label()
        Me.txtCreditoDebito = New DataDynamics.ActiveReports.TextBox()
        Me.Label28 = New DataDynamics.ActiveReports.Label()
        Me.txtDPCARD = New DataDynamics.ActiveReports.TextBox()
        Me.txtAbonoDPCA = New DataDynamics.ActiveReports.TextBox()
        Me.txtEfectivoDPCA = New DataDynamics.ActiveReports.TextBox()
        Me.Label30 = New DataDynamics.ActiveReports.Label()
        Me.Label31 = New DataDynamics.ActiveReports.Label()
        Me.txtCreditoDebitoDPCA = New DataDynamics.ActiveReports.TextBox()
        Me.ReportFooter = New DataDynamics.ActiveReports.ReportFooter()
        Me.lblEcommDPVale = New DataDynamics.ActiveReports.Label()
        Me.txtEcommDPVale = New DataDynamics.ActiveReports.TextBox()
        CType(Me.Label29, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAlmacen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label19, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label20, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label21, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label22, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBMX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSERF, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBBVA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label23, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label24, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label25, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBMXTM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSERFTM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBBVATM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label26, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label27, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbGlobalTarjetas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbBMXTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbSERFTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbBBVATotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblPedidosSH, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPedidosSH, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblEcommerce, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEcommerce, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblEfectivo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEfectivo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblCredito, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCreditoDebito, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label28, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDPCARD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAbonoDPCA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEfectivoDPCA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label30, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label31, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCreditoDebitoDPCA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblEcommDPVale, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEcommDPVale, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.ReportHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label29, Me.Shape1, Me.Label2, Me.txtFecha, Me.Label3, Me.txtAlmacen, Me.Label1, Me.Label4, Me.TextBox1, Me.Label5, Me.TextBox2, Me.Label6, Me.TextBox3, Me.Label7, Me.TextBox4, Me.Label8, Me.TextBox5, Me.Label9, Me.TextBox6, Me.Label10, Me.TextBox7, Me.Label11, Me.TextBox8, Me.Label12, Me.TextBox9, Me.Label13, Me.TextBox10, Me.Label14, Me.TextBox11, Me.Label15, Me.TextBox12, Me.Line1, Me.Label16, Me.TextBox13, Me.Label17, Me.TextBox14, Me.Label18, Me.TextBox15, Me.Label19, Me.TextBox16, Me.Line2, Me.Label20, Me.Label21, Me.Label22, Me.txtBMX, Me.txtSERF, Me.txtBBVA, Me.Label23, Me.Label24, Me.Label25, Me.txtBMXTM, Me.txtSERFTM, Me.txtBBVATM, Me.Label26, Me.SubReport1, Me.Label27, Me.tbGlobalTarjetas, Me.tbBMXTotal, Me.tbSERFTotal, Me.tbBBVATotal, Me.lblPedidosSH, Me.txtPedidosSH, Me.lblEcommerce, Me.txtEcommerce, Me.lblEfectivo, Me.txtEfectivo, Me.lblCredito, Me.txtCreditoDebito, Me.Label28, Me.txtDPCARD, Me.txtAbonoDPCA, Me.txtEfectivoDPCA, Me.Label30, Me.Label31, Me.txtCreditoDebitoDPCA, Me.lblEcommDPVale, Me.txtEcommDPVale})
        Me.ReportHeader.Height = 6.237401!
        Me.ReportHeader.Name = "ReportHeader"
        '
        'Label29
        '
        Me.Label29.Height = 0.2!
        Me.Label29.HyperLink = Nothing
        Me.Label29.Left = 0.472!
        Me.Label29.Name = "Label29"
        Me.Label29.Style = "font-weight: bold; font-size: 8.25pt"
        Me.Label29.Text = "ABONOS DP CARD CREDIT:"
        Me.Label29.Top = 2.875!
        Me.Label29.Visible = False
        Me.Label29.Width = 1.5905!
        '
        'Shape1
        '
        Me.Shape1.Height = 0.6299213!
        Me.Shape1.Left = 0.0!
        Me.Shape1.Name = "Shape1"
        Me.Shape1.RoundingRadius = 9.999999!
        Me.Shape1.Top = 0.0!
        Me.Shape1.Width = 6.299212!
        '
        'Label2
        '
        Me.Label2.Height = 0.2!
        Me.Label2.HyperLink = Nothing
        Me.Label2.Left = 0.472441!
        Me.Label2.Name = "Label2"
        Me.Label2.Style = "font-weight: bold; font-size: 8.25pt"
        Me.Label2.Text = "Fecha:"
        Me.Label2.Top = 0.07874014!
        Me.Label2.Width = 0.5!
        '
        'txtFecha
        '
        Me.txtFecha.Height = 0.2!
        Me.txtFecha.Left = 0.972441!
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.Text = "txtFecha"
        Me.txtFecha.Top = 0.07874014!
        Me.txtFecha.Width = 1.0!
        '
        'Label3
        '
        Me.Label3.Height = 0.2!
        Me.Label3.HyperLink = Nothing
        Me.Label3.Left = 2.0!
        Me.Label3.Name = "Label3"
        Me.Label3.Style = "font-weight: bold; font-size: 8.25pt"
        Me.Label3.Text = "Sucursal:"
        Me.Label3.Top = 0.375!
        Me.Label3.Width = 0.625!
        '
        'txtAlmacen
        '
        Me.txtAlmacen.Height = 0.2!
        Me.txtAlmacen.Left = 2.6875!
        Me.txtAlmacen.Name = "txtAlmacen"
        Me.txtAlmacen.Style = "font-size: 8.25pt"
        Me.txtAlmacen.Text = "TextBox1"
        Me.txtAlmacen.Top = 0.375!
        Me.txtAlmacen.Width = 3.454233!
        '
        'Label1
        '
        Me.Label1.Height = 0.2!
        Me.Label1.HyperLink = Nothing
        Me.Label1.Left = 1.968504!
        Me.Label1.Name = "Label1"
        Me.Label1.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
        Me.Label1.Text = "Reporte Concentrador de Cierre de Caja"
        Me.Label1.Top = 0.07874014!
        Me.Label1.Width = 2.992126!
        '
        'Label4
        '
        Me.Label4.Height = 0.2!
        Me.Label4.HyperLink = Nothing
        Me.Label4.Left = 0.472441!
        Me.Label4.Name = "Label4"
        Me.Label4.Style = "font-weight: bold; font-size: 8.25pt"
        Me.Label4.Text = "TARJETA ELECTRÓNICA:"
        Me.Label4.Top = 1.849901!
        Me.Label4.Width = 1.496063!
        '
        'TextBox1
        '
        Me.TextBox1.Height = 0.2!
        Me.TextBox1.Left = 2.047244!
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.OutputFormat = resources.GetString("TextBox1.OutputFormat")
        Me.TextBox1.Style = "text-align: right"
        Me.TextBox1.Text = Nothing
        Me.TextBox1.Top = 1.849901!
        Me.TextBox1.Width = 1.181102!
        '
        'Label5
        '
        Me.Label5.Height = 0.2!
        Me.Label5.HyperLink = Nothing
        Me.Label5.Left = 0.472441!
        Me.Label5.Name = "Label5"
        Me.Label5.Style = "font-weight: bold; font-size: 8.25pt"
        Me.Label5.Text = "TARJETA MANUAL:"
        Me.Label5.Top = 2.086122!
        Me.Label5.Width = 1.496063!
        '
        'TextBox2
        '
        Me.TextBox2.Height = 0.2!
        Me.TextBox2.Left = 2.047244!
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.OutputFormat = resources.GetString("TextBox2.OutputFormat")
        Me.TextBox2.Style = "text-align: right"
        Me.TextBox2.Text = Nothing
        Me.TextBox2.Top = 2.086122!
        Me.TextBox2.Width = 1.181102!
        '
        'Label6
        '
        Me.Label6.Height = 0.2!
        Me.Label6.HyperLink = Nothing
        Me.Label6.Left = 0.472441!
        Me.Label6.Name = "Label6"
        Me.Label6.Style = "font-weight: bold; font-size: 8.25pt"
        Me.Label6.Text = "EFECTIVO:"
        Me.Label6.Top = 2.572342!
        Me.Label6.Width = 1.496063!
        '
        'TextBox3
        '
        Me.TextBox3.Height = 0.2!
        Me.TextBox3.Left = 2.047244!
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.OutputFormat = resources.GetString("TextBox3.OutputFormat")
        Me.TextBox3.Style = "text-align: right"
        Me.TextBox3.Text = Nothing
        Me.TextBox3.Top = 2.572342!
        Me.TextBox3.Width = 1.181102!
        '
        'Label7
        '
        Me.Label7.Height = 0.2!
        Me.Label7.HyperLink = Nothing
        Me.Label7.Left = 3.655!
        Me.Label7.Name = "Label7"
        Me.Label7.Style = "font-weight: bold; font-size: 8.25pt"
        Me.Label7.Text = "DPVALE:"
        Me.Label7.Top = 0.7360001!
        Me.Label7.Width = 0.944882!
        '
        'TextBox4
        '
        Me.TextBox4.Height = 0.2!
        Me.TextBox4.Left = 5.118!
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.OutputFormat = resources.GetString("TextBox4.OutputFormat")
        Me.TextBox4.Style = "text-align: right"
        Me.TextBox4.Text = Nothing
        Me.TextBox4.Top = 0.716!
        Me.TextBox4.Width = 1.0!
        '
        'Label8
        '
        Me.Label8.Height = 0.2!
        Me.Label8.HyperLink = Nothing
        Me.Label8.Left = 3.655!
        Me.Label8.Name = "Label8"
        Me.Label8.Style = "font-weight: bold; font-size: 8.25pt"
        Me.Label8.Text = "FONACOT:"
        Me.Label8.Top = 0.992!
        Me.Label8.Width = 0.944882!
        '
        'TextBox5
        '
        Me.TextBox5.Height = 0.2!
        Me.TextBox5.Left = 5.129!
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.OutputFormat = resources.GetString("TextBox5.OutputFormat")
        Me.TextBox5.Style = "text-align: right"
        Me.TextBox5.Text = Nothing
        Me.TextBox5.Top = 0.9820001!
        Me.TextBox5.Width = 1.0!
        '
        'Label9
        '
        Me.Label9.Height = 0.2!
        Me.Label9.HyperLink = Nothing
        Me.Label9.Left = 3.655!
        Me.Label9.Name = "Label9"
        Me.Label9.Style = "font-weight: bold; font-size: 8.25pt"
        Me.Label9.Text = "FACILITO:"
        Me.Label9.Top = 1.248!
        Me.Label9.Width = 0.944882!
        '
        'TextBox6
        '
        Me.TextBox6.Height = 0.2!
        Me.TextBox6.Left = 5.118!
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.OutputFormat = resources.GetString("TextBox6.OutputFormat")
        Me.TextBox6.Style = "text-align: right"
        Me.TextBox6.Text = Nothing
        Me.TextBox6.Top = 1.238!
        Me.TextBox6.Width = 1.0!
        '
        'Label10
        '
        Me.Label10.Height = 0.2!
        Me.Label10.HyperLink = Nothing
        Me.Label10.Left = 0.472441!
        Me.Label10.Name = "Label10"
        Me.Label10.Style = "font-weight: bold; font-size: 8.25pt"
        Me.Label10.Text = "ABONOS APARTADOS:"
        Me.Label10.Top = 3.718504!
        Me.Label10.Width = 1.496063!
        '
        'TextBox7
        '
        Me.TextBox7.Height = 0.2!
        Me.TextBox7.Left = 2.047244!
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.OutputFormat = resources.GetString("TextBox7.OutputFormat")
        Me.TextBox7.Style = "text-align: right"
        Me.TextBox7.Text = Nothing
        Me.TextBox7.Top = 3.718504!
        Me.TextBox7.Width = 1.181102!
        '
        'Label11
        '
        Me.Label11.Height = 0.2!
        Me.Label11.HyperLink = Nothing
        Me.Label11.Left = 0.472441!
        Me.Label11.Name = "Label11"
        Me.Label11.Style = "font-weight: bold; font-size: 8.25pt"
        Me.Label11.Text = "ABONOS C. DIRECTO:"
        Me.Label11.Top = 5.220964!
        Me.Label11.Visible = False
        Me.Label11.Width = 1.496063!
        '
        'TextBox8
        '
        Me.TextBox8.Height = 0.2!
        Me.TextBox8.Left = 2.047244!
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.OutputFormat = resources.GetString("TextBox8.OutputFormat")
        Me.TextBox8.Style = "text-align: right"
        Me.TextBox8.Text = Nothing
        Me.TextBox8.Top = 5.220964!
        Me.TextBox8.Visible = False
        Me.TextBox8.Width = 1.181102!
        '
        'Label12
        '
        Me.Label12.Height = 0.2!
        Me.Label12.HyperLink = Nothing
        Me.Label12.Left = 0.472441!
        Me.Label12.Name = "Label12"
        Me.Label12.Style = "font-weight: bold; font-size: 8.25pt"
        Me.Label12.Text = "TOTAL ABONOS:"
        Me.Label12.Top = 4.348426!
        Me.Label12.Width = 1.496063!
        '
        'TextBox9
        '
        Me.TextBox9.Height = 0.2!
        Me.TextBox9.Left = 2.047244!
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.OutputFormat = resources.GetString("TextBox9.OutputFormat")
        Me.TextBox9.Style = "text-align: right"
        Me.TextBox9.Text = Nothing
        Me.TextBox9.Top = 4.348425!
        Me.TextBox9.Width = 1.181102!
        '
        'Label13
        '
        Me.Label13.Height = 0.2!
        Me.Label13.HyperLink = Nothing
        Me.Label13.Left = 3.655!
        Me.Label13.Name = "Label13"
        Me.Label13.Style = "font-weight: bold; font-size: 8.25pt"
        Me.Label13.Text = "VALE DE CAJA:"
        Me.Label13.Top = 1.504!
        Me.Label13.Width = 0.944882!
        '
        'TextBox10
        '
        Me.TextBox10.Height = 0.2!
        Me.TextBox10.Left = 5.118!
        Me.TextBox10.Name = "TextBox10"
        Me.TextBox10.OutputFormat = resources.GetString("TextBox10.OutputFormat")
        Me.TextBox10.Style = "text-align: right"
        Me.TextBox10.Text = Nothing
        Me.TextBox10.Top = 1.473!
        Me.TextBox10.Width = 1.0!
        '
        'Label14
        '
        Me.Label14.Height = 0.2!
        Me.Label14.HyperLink = Nothing
        Me.Label14.Left = 3.779528!
        Me.Label14.Name = "Label14"
        Me.Label14.Style = "font-weight: bold; font-size: 8.25pt"
        Me.Label14.Text = "RETIROS:"
        Me.Label14.Top = 4.033464!
        Me.Label14.Width = 0.944882!
        '
        'TextBox11
        '
        Me.TextBox11.Height = 0.2!
        Me.TextBox11.Left = 5.118111!
        Me.TextBox11.Name = "TextBox11"
        Me.TextBox11.OutputFormat = resources.GetString("TextBox11.OutputFormat")
        Me.TextBox11.Style = "text-align: right"
        Me.TextBox11.Text = Nothing
        Me.TextBox11.Top = 4.033464!
        Me.TextBox11.Width = 1.0!
        '
        'Label15
        '
        Me.Label15.Height = 0.2!
        Me.Label15.HyperLink = Nothing
        Me.Label15.Left = 3.779528!
        Me.Label15.Name = "Label15"
        Me.Label15.Style = "font-weight: bold; font-size: 8.25pt"
        Me.Label15.Text = "TOTAL FACTURADO:"
        Me.Label15.Top = 4.348425!
        Me.Label15.Width = 1.259842!
        '
        'TextBox12
        '
        Me.TextBox12.Height = 0.2!
        Me.TextBox12.Left = 5.118111!
        Me.TextBox12.Name = "TextBox12"
        Me.TextBox12.OutputFormat = resources.GetString("TextBox12.OutputFormat")
        Me.TextBox12.Style = "text-align: right"
        Me.TextBox12.Text = Nothing
        Me.TextBox12.Top = 4.348425!
        Me.TextBox12.Width = 1.0!
        '
        'Line1
        '
        Me.Line1.Height = 0.006946087!
        Me.Line1.Left = 0.1319444!
        Me.Line1.LineWeight = 1.0!
        Me.Line1.Name = "Line1"
        Me.Line1.Top = 3.694444!
        Me.Line1.Width = 6.134788!
        Me.Line1.X1 = 0.1319444!
        Me.Line1.X2 = 6.266732!
        Me.Line1.Y1 = 3.70139!
        Me.Line1.Y2 = 3.694444!
        '
        'Label16
        '
        Me.Label16.Height = 0.2!
        Me.Label16.HyperLink = Nothing
        Me.Label16.Left = 3.66!
        Me.Label16.Name = "Label16"
        Me.Label16.Style = "font-weight: bold; font-size: 8.25pt"
        Me.Label16.Text = "NOTAS DE CRÉDITO:"
        Me.Label16.Top = 1.742!
        Me.Label16.Width = 1.300689!
        '
        'TextBox13
        '
        Me.TextBox13.Height = 0.2!
        Me.TextBox13.Left = 5.118!
        Me.TextBox13.Name = "TextBox13"
        Me.TextBox13.OutputFormat = resources.GetString("TextBox13.OutputFormat")
        Me.TextBox13.Style = "text-align: right"
        Me.TextBox13.Text = Nothing
        Me.TextBox13.Top = 1.723!
        Me.TextBox13.Width = 1.023622!
        '
        'Label17
        '
        Me.Label17.Height = 0.2!
        Me.Label17.HyperLink = Nothing
        Me.Label17.Left = 3.779528!
        Me.Label17.Name = "Label17"
        Me.Label17.Style = "font-weight: bold; font-size: 8.25pt"
        Me.Label17.Text = "FONDO DE CAJA:"
        Me.Label17.Top = 3.783465!
        Me.Label17.Width = 1.259842!
        '
        'TextBox14
        '
        Me.TextBox14.Height = 0.2!
        Me.TextBox14.Left = 5.118111!
        Me.TextBox14.Name = "TextBox14"
        Me.TextBox14.OutputFormat = resources.GetString("TextBox14.OutputFormat")
        Me.TextBox14.Style = "text-align: right"
        Me.TextBox14.Text = Nothing
        Me.TextBox14.Top = 3.783465!
        Me.TextBox14.Width = 1.0!
        '
        'Label18
        '
        Me.Label18.Height = 0.2!
        Me.Label18.HyperLink = Nothing
        Me.Label18.Left = 3.464567!
        Me.Label18.Name = "Label18"
        Me.Label18.Style = "font-weight: bold; font-size: 8.25pt"
        Me.Label18.Text = "FACTURAS ACTIVAS:"
        Me.Label18.Top = 4.742126!
        Me.Label18.Width = 1.574803!
        '
        'TextBox15
        '
        Me.TextBox15.Height = 0.2!
        Me.TextBox15.Left = 5.118111!
        Me.TextBox15.Name = "TextBox15"
        Me.TextBox15.OutputFormat = resources.GetString("TextBox15.OutputFormat")
        Me.TextBox15.Style = "text-align: right"
        Me.TextBox15.Text = Nothing
        Me.TextBox15.Top = 4.742126!
        Me.TextBox15.Width = 1.0!
        '
        'Label19
        '
        Me.Label19.Height = 0.2!
        Me.Label19.HyperLink = Nothing
        Me.Label19.Left = 3.464567!
        Me.Label19.Name = "Label19"
        Me.Label19.Style = "font-weight: bold; font-size: 8.25pt"
        Me.Label19.Text = "FACTURAS CANCELADAS:"
        Me.Label19.Top = 4.978346!
        Me.Label19.Width = 1.653543!
        '
        'TextBox16
        '
        Me.TextBox16.Height = 0.2!
        Me.TextBox16.Left = 5.118111!
        Me.TextBox16.Name = "TextBox16"
        Me.TextBox16.OutputFormat = resources.GetString("TextBox16.OutputFormat")
        Me.TextBox16.Style = "text-align: right"
        Me.TextBox16.Text = Nothing
        Me.TextBox16.Top = 4.978346!
        Me.TextBox16.Width = 1.0!
        '
        'Line2
        '
        Me.Line2.Height = 0.006943226!
        Me.Line2.Left = 0.1644248!
        Me.Line2.LineWeight = 1.0!
        Me.Line2.Name = "Line2"
        Me.Line2.Top = 4.663386!
        Me.Line2.Width = 6.134787!
        Me.Line2.X1 = 0.1644248!
        Me.Line2.X2 = 6.299212!
        Me.Line2.Y1 = 4.670329!
        Me.Line2.Y2 = 4.663386!
        '
        'Label20
        '
        Me.Label20.Height = 0.2!
        Me.Label20.HyperLink = Nothing
        Me.Label20.Left = 0.659941!
        Me.Label20.Name = "Label20"
        Me.Label20.Style = "font-weight: bold; font-size: 8.25pt"
        Me.Label20.Text = "BMX:"
        Me.Label20.Top = 1.162401!
        Me.Label20.Width = 1.308563!
        '
        'Label21
        '
        Me.Label21.Height = 0.2!
        Me.Label21.HyperLink = Nothing
        Me.Label21.Left = 0.659941!
        Me.Label21.Name = "Label21"
        Me.Label21.Style = "font-weight: bold; font-size: 8.25pt"
        Me.Label21.Text = "BBVA:"
        Me.Label21.Top = 1.349901!
        Me.Label21.Width = 1.308563!
        '
        'Label22
        '
        Me.Label22.Height = 0.2!
        Me.Label22.HyperLink = Nothing
        Me.Label22.Left = 0.659941!
        Me.Label22.Name = "Label22"
        Me.Label22.Style = "font-weight: bold; font-size: 8.25pt"
        Me.Label22.Text = "SERF:"
        Me.Label22.Top = 1.537401!
        Me.Label22.Width = 1.308563!
        '
        'txtBMX
        '
        Me.txtBMX.Height = 0.2!
        Me.txtBMX.Left = 2.047244!
        Me.txtBMX.Name = "txtBMX"
        Me.txtBMX.OutputFormat = resources.GetString("txtBMX.OutputFormat")
        Me.txtBMX.Style = "text-align: right"
        Me.txtBMX.Text = Nothing
        Me.txtBMX.Top = 5.349901!
        Me.txtBMX.Visible = False
        Me.txtBMX.Width = 0.8661423!
        '
        'txtSERF
        '
        Me.txtSERF.Height = 0.2!
        Me.txtSERF.Left = 2.047244!
        Me.txtSERF.Name = "txtSERF"
        Me.txtSERF.OutputFormat = resources.GetString("txtSERF.OutputFormat")
        Me.txtSERF.Style = "text-align: right"
        Me.txtSERF.Text = Nothing
        Me.txtSERF.Top = 5.724901!
        Me.txtSERF.Visible = False
        Me.txtSERF.Width = 0.8661423!
        '
        'txtBBVA
        '
        Me.txtBBVA.Height = 0.2!
        Me.txtBBVA.Left = 2.047244!
        Me.txtBBVA.Name = "txtBBVA"
        Me.txtBBVA.OutputFormat = resources.GetString("txtBBVA.OutputFormat")
        Me.txtBBVA.Style = "text-align: right"
        Me.txtBBVA.Text = Nothing
        Me.txtBBVA.Top = 5.537401!
        Me.txtBBVA.Visible = False
        Me.txtBBVA.Width = 0.8661423!
        '
        'Label23
        '
        Me.Label23.Height = 0.2!
        Me.Label23.HyperLink = Nothing
        Me.Label23.Left = 0.784941!
        Me.Label23.Name = "Label23"
        Me.Label23.Style = "font-weight: bold; font-size: 8.25pt"
        Me.Label23.Text = "BMX:"
        Me.Label23.Top = 5.662401!
        Me.Label23.Visible = False
        Me.Label23.Width = 1.308563!
        '
        'Label24
        '
        Me.Label24.Height = 0.2!
        Me.Label24.HyperLink = Nothing
        Me.Label24.Left = 0.784941!
        Me.Label24.Name = "Label24"
        Me.Label24.Style = "font-weight: bold; font-size: 8.25pt"
        Me.Label24.Text = "BBVA:"
        Me.Label24.Top = 5.849901!
        Me.Label24.Visible = False
        Me.Label24.Width = 1.308563!
        '
        'Label25
        '
        Me.Label25.Height = 0.2!
        Me.Label25.HyperLink = Nothing
        Me.Label25.Left = 0.784941!
        Me.Label25.Name = "Label25"
        Me.Label25.Style = "font-weight: bold; font-size: 8.25pt"
        Me.Label25.Text = "SERF:"
        Me.Label25.Top = 6.037401!
        Me.Label25.Visible = False
        Me.Label25.Width = 1.308563!
        '
        'txtBMXTM
        '
        Me.txtBMXTM.Height = 0.2!
        Me.txtBMXTM.Left = 2.172244!
        Me.txtBMXTM.Name = "txtBMXTM"
        Me.txtBMXTM.OutputFormat = resources.GetString("txtBMXTM.OutputFormat")
        Me.txtBMXTM.Style = "text-align: right"
        Me.txtBMXTM.Text = Nothing
        Me.txtBMXTM.Top = 5.662401!
        Me.txtBMXTM.Visible = False
        Me.txtBMXTM.Width = 0.8661423!
        '
        'txtSERFTM
        '
        Me.txtSERFTM.Height = 0.2!
        Me.txtSERFTM.Left = 2.172244!
        Me.txtSERFTM.Name = "txtSERFTM"
        Me.txtSERFTM.OutputFormat = resources.GetString("txtSERFTM.OutputFormat")
        Me.txtSERFTM.Style = "text-align: right"
        Me.txtSERFTM.Text = Nothing
        Me.txtSERFTM.Top = 6.037401!
        Me.txtSERFTM.Visible = False
        Me.txtSERFTM.Width = 0.8661423!
        '
        'txtBBVATM
        '
        Me.txtBBVATM.Height = 0.2!
        Me.txtBBVATM.Left = 2.172244!
        Me.txtBBVATM.Name = "txtBBVATM"
        Me.txtBBVATM.OutputFormat = resources.GetString("txtBBVATM.OutputFormat")
        Me.txtBBVATM.Style = "text-align: right"
        Me.txtBBVATM.Text = Nothing
        Me.txtBBVATM.Top = 5.849901!
        Me.txtBBVATM.Visible = False
        Me.txtBBVATM.Width = 0.8661423!
        '
        'Label26
        '
        Me.Label26.Height = 0.2!
        Me.Label26.HyperLink = Nothing
        Me.Label26.Left = 3.91!
        Me.Label26.Name = "Label26"
        Me.Label26.Style = "font-weight: bold; font-size: 8.25pt"
        Me.Label26.Text = "FOLIOS:"
        Me.Label26.Top = 2.973!
        Me.Label26.Visible = False
        Me.Label26.Width = 1.050689!
        '
        'SubReport1
        '
        Me.SubReport1.CloseBorder = False
        Me.SubReport1.Height = 0.7086618!
        Me.SubReport1.Left = 5.118!
        Me.SubReport1.Name = "SubReport1"
        Me.SubReport1.Report = Nothing
        Me.SubReport1.Top = 2.958!
        Me.SubReport1.Visible = False
        Me.SubReport1.Width = 1.023622!
        '
        'Label27
        '
        Me.Label27.Height = 0.2!
        Me.Label27.HyperLink = Nothing
        Me.Label27.Left = 0.472!
        Me.Label27.Name = "Label27"
        Me.Label27.Style = "font-weight: bold; font-size: 8.25pt"
        Me.Label27.Text = "GLOBAL TARJETAS:"
        Me.Label27.Top = 0.7460001!
        Me.Label27.Width = 1.496063!
        '
        'tbGlobalTarjetas
        '
        Me.tbGlobalTarjetas.Height = 0.2!
        Me.tbGlobalTarjetas.Left = 2.047!
        Me.tbGlobalTarjetas.Name = "tbGlobalTarjetas"
        Me.tbGlobalTarjetas.OutputFormat = resources.GetString("tbGlobalTarjetas.OutputFormat")
        Me.tbGlobalTarjetas.Style = "text-align: right"
        Me.tbGlobalTarjetas.Text = Nothing
        Me.tbGlobalTarjetas.Top = 0.7460001!
        Me.tbGlobalTarjetas.Width = 1.181102!
        '
        'tbBMXTotal
        '
        Me.tbBMXTotal.Height = 0.2!
        Me.tbBMXTotal.Left = 2.047244!
        Me.tbBMXTotal.Name = "tbBMXTotal"
        Me.tbBMXTotal.OutputFormat = resources.GetString("tbBMXTotal.OutputFormat")
        Me.tbBMXTotal.Style = "text-align: right"
        Me.tbBMXTotal.Text = Nothing
        Me.tbBMXTotal.Top = 1.162401!
        Me.tbBMXTotal.Width = 0.8661423!
        '
        'tbSERFTotal
        '
        Me.tbSERFTotal.Height = 0.2!
        Me.tbSERFTotal.Left = 2.047244!
        Me.tbSERFTotal.Name = "tbSERFTotal"
        Me.tbSERFTotal.OutputFormat = resources.GetString("tbSERFTotal.OutputFormat")
        Me.tbSERFTotal.Style = "text-align: right"
        Me.tbSERFTotal.Text = Nothing
        Me.tbSERFTotal.Top = 1.537401!
        Me.tbSERFTotal.Width = 0.8661423!
        '
        'tbBBVATotal
        '
        Me.tbBBVATotal.Height = 0.2!
        Me.tbBBVATotal.Left = 2.047244!
        Me.tbBBVATotal.Name = "tbBBVATotal"
        Me.tbBBVATotal.OutputFormat = resources.GetString("tbBBVATotal.OutputFormat")
        Me.tbBBVATotal.Style = "text-align: right"
        Me.tbBBVATotal.Text = Nothing
        Me.tbBBVATotal.Top = 1.349901!
        Me.tbBBVATotal.Width = 0.8661423!
        '
        'lblPedidosSH
        '
        Me.lblPedidosSH.Height = 0.2!
        Me.lblPedidosSH.HyperLink = Nothing
        Me.lblPedidosSH.Left = 0.472441!
        Me.lblPedidosSH.Name = "lblPedidosSH"
        Me.lblPedidosSH.Style = "font-weight: bold; font-size: 8.25pt"
        Me.lblPedidosSH.Text = "PEDIDOS SH:"
        Me.lblPedidosSH.Top = 4.033464!
        Me.lblPedidosSH.Width = 1.496063!
        '
        'txtPedidosSH
        '
        Me.txtPedidosSH.Height = 0.2!
        Me.txtPedidosSH.Left = 2.047244!
        Me.txtPedidosSH.Name = "txtPedidosSH"
        Me.txtPedidosSH.OutputFormat = resources.GetString("txtPedidosSH.OutputFormat")
        Me.txtPedidosSH.Style = "text-align: right"
        Me.txtPedidosSH.Text = Nothing
        Me.txtPedidosSH.Top = 4.033464!
        Me.txtPedidosSH.Width = 1.181102!
        '
        'lblEcommerce
        '
        Me.lblEcommerce.Height = 0.2!
        Me.lblEcommerce.HyperLink = Nothing
        Me.lblEcommerce.Left = 3.66!
        Me.lblEcommerce.Name = "lblEcommerce"
        Me.lblEcommerce.Style = "font-weight: bold; font-size: 8.25pt"
        Me.lblEcommerce.Text = "ECOMMERCE:"
        Me.lblEcommerce.Top = 1.982!
        Me.lblEcommerce.Width = 1.300689!
        '
        'txtEcommerce
        '
        Me.txtEcommerce.Height = 0.2!
        Me.txtEcommerce.Left = 5.118!
        Me.txtEcommerce.Name = "txtEcommerce"
        Me.txtEcommerce.OutputFormat = resources.GetString("txtEcommerce.OutputFormat")
        Me.txtEcommerce.Style = "text-align: right"
        Me.txtEcommerce.Text = Nothing
        Me.txtEcommerce.Top = 1.982!
        Me.txtEcommerce.Width = 1.023622!
        '
        'lblEfectivo
        '
        Me.lblEfectivo.Height = 0.2!
        Me.lblEfectivo.HyperLink = Nothing
        Me.lblEfectivo.Left = 4.062!
        Me.lblEfectivo.Name = "lblEfectivo"
        Me.lblEfectivo.Style = "font-weight: bold; font-size: 8.25pt"
        Me.lblEfectivo.Text = "Efectivo:"
        Me.lblEfectivo.Top = 2.232!
        Me.lblEfectivo.Width = 0.875!
        '
        'txtEfectivo
        '
        Me.txtEfectivo.Height = 0.2!
        Me.txtEfectivo.Left = 5.125!
        Me.txtEfectivo.Name = "txtEfectivo"
        Me.txtEfectivo.OutputFormat = resources.GetString("txtEfectivo.OutputFormat")
        Me.txtEfectivo.Style = "text-align: right"
        Me.txtEfectivo.Text = Nothing
        Me.txtEfectivo.Top = 2.222!
        Me.txtEfectivo.Width = 1.023622!
        '
        'lblCredito
        '
        Me.lblCredito.Height = 0.2!
        Me.lblCredito.HyperLink = Nothing
        Me.lblCredito.Left = 4.062!
        Me.lblCredito.Name = "lblCredito"
        Me.lblCredito.Style = "font-weight: bold; font-size: 8.25pt"
        Me.lblCredito.Text = "Crédito/Debito:"
        Me.lblCredito.Top = 2.733!
        Me.lblCredito.Width = 0.875!
        '
        'txtCreditoDebito
        '
        Me.txtCreditoDebito.Height = 0.2!
        Me.txtCreditoDebito.Left = 5.118!
        Me.txtCreditoDebito.Name = "txtCreditoDebito"
        Me.txtCreditoDebito.OutputFormat = resources.GetString("txtCreditoDebito.OutputFormat")
        Me.txtCreditoDebito.Style = "text-align: right"
        Me.txtCreditoDebito.Text = Nothing
        Me.txtCreditoDebito.Top = 2.713!
        Me.txtCreditoDebito.Width = 1.023622!
        '
        'Label28
        '
        Me.Label28.Height = 0.2!
        Me.Label28.HyperLink = Nothing
        Me.Label28.Left = 0.472441!
        Me.Label28.Name = "Label28"
        Me.Label28.Style = "font-weight: bold; font-size: 8.25pt"
        Me.Label28.Text = "DP CARD CREDIT:"
        Me.Label28.Top = 2.322342!
        Me.Label28.Width = 1.496063!
        '
        'txtDPCARD
        '
        Me.txtDPCARD.Height = 0.2!
        Me.txtDPCARD.Left = 2.047244!
        Me.txtDPCARD.Name = "txtDPCARD"
        Me.txtDPCARD.OutputFormat = resources.GetString("txtDPCARD.OutputFormat")
        Me.txtDPCARD.Style = "text-align: right"
        Me.txtDPCARD.Text = Nothing
        Me.txtDPCARD.Top = 2.322342!
        Me.txtDPCARD.Width = 1.181102!
        '
        'txtAbonoDPCA
        '
        Me.txtAbonoDPCA.Height = 0.2!
        Me.txtAbonoDPCA.Left = 2.0625!
        Me.txtAbonoDPCA.Name = "txtAbonoDPCA"
        Me.txtAbonoDPCA.OutputFormat = resources.GetString("txtAbonoDPCA.OutputFormat")
        Me.txtAbonoDPCA.Style = "text-align: right"
        Me.txtAbonoDPCA.Text = Nothing
        Me.txtAbonoDPCA.Top = 2.875!
        Me.txtAbonoDPCA.Visible = False
        Me.txtAbonoDPCA.Width = 1.1875!
        '
        'txtEfectivoDPCA
        '
        Me.txtEfectivoDPCA.Height = 0.2!
        Me.txtEfectivoDPCA.Left = 2.0625!
        Me.txtEfectivoDPCA.Name = "txtEfectivoDPCA"
        Me.txtEfectivoDPCA.OutputFormat = resources.GetString("txtEfectivoDPCA.OutputFormat")
        Me.txtEfectivoDPCA.Style = "text-align: right"
        Me.txtEfectivoDPCA.Text = Nothing
        Me.txtEfectivoDPCA.Top = 3.125!
        Me.txtEfectivoDPCA.Visible = False
        Me.txtEfectivoDPCA.Width = 0.875!
        '
        'Label30
        '
        Me.Label30.Height = 0.2!
        Me.Label30.HyperLink = Nothing
        Me.Label30.Left = 0.6875!
        Me.Label30.Name = "Label30"
        Me.Label30.Style = "font-weight: bold; font-size: 8.25pt"
        Me.Label30.Text = "Efectivo:"
        Me.Label30.Top = 3.125!
        Me.Label30.Visible = False
        Me.Label30.Width = 1.2775!
        '
        'Label31
        '
        Me.Label31.Height = 0.2!
        Me.Label31.HyperLink = Nothing
        Me.Label31.Left = 0.6875!
        Me.Label31.Name = "Label31"
        Me.Label31.Style = "font-weight: bold; font-size: 8.25pt"
        Me.Label31.Text = "Crédito/Debito:"
        Me.Label31.Top = 3.375!
        Me.Label31.Visible = False
        Me.Label31.Width = 1.2775!
        '
        'txtCreditoDebitoDPCA
        '
        Me.txtCreditoDebitoDPCA.Height = 0.2!
        Me.txtCreditoDebitoDPCA.Left = 2.0625!
        Me.txtCreditoDebitoDPCA.Name = "txtCreditoDebitoDPCA"
        Me.txtCreditoDebitoDPCA.OutputFormat = resources.GetString("txtCreditoDebitoDPCA.OutputFormat")
        Me.txtCreditoDebitoDPCA.Style = "text-align: right"
        Me.txtCreditoDebitoDPCA.Text = Nothing
        Me.txtCreditoDebitoDPCA.Top = 3.3755!
        Me.txtCreditoDebitoDPCA.Visible = False
        Me.txtCreditoDebitoDPCA.Width = 0.875!
        '
        'ReportFooter
        '
        Me.ReportFooter.Height = 0.0!
        Me.ReportFooter.Name = "ReportFooter"
        '
        'lblEcommDPVale
        '
        Me.lblEcommDPVale.Height = 0.2!
        Me.lblEcommDPVale.HyperLink = Nothing
        Me.lblEcommDPVale.Left = 4.062!
        Me.lblEcommDPVale.Name = "lblEcommDPVale"
        Me.lblEcommDPVale.Style = "font-weight: bold; font-size: 8.25pt"
        Me.lblEcommDPVale.Text = "DPVALE:"
        Me.lblEcommDPVale.Top = 2.4945!
        Me.lblEcommDPVale.Width = 0.875!
        '
        'txtEcommDPVale
        '
        Me.txtEcommDPVale.Height = 0.2!
        Me.txtEcommDPVale.Left = 5.115!
        Me.txtEcommDPVale.Name = "txtEcommDPVale"
        Me.txtEcommDPVale.OutputFormat = resources.GetString("txtEcommDPVale.OutputFormat")
        Me.txtEcommDPVale.Style = "text-align: right"
        Me.txtEcommDPVale.Text = Nothing
        Me.txtEcommDPVale.Top = 2.464!
        Me.txtEcommDPVale.Width = 1.023622!
        '
        'ConcentradoREP
        '
        Me.MasterReport = False
        Me.PageSettings.Margins.Left = 0.6694444!
        Me.PageSettings.Margins.Right = 0.6694444!
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 6.364583!
        Me.Sections.Add(Me.ReportHeader)
        Me.Sections.Add(Me.Detail)
        Me.Sections.Add(Me.ReportFooter)
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" & _
            "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei" & _
            "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" & _
            "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit", "Heading3", "Normal"))
        CType(Me.Label29, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAlmacen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).EndInit()
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
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label19, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label20, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label21, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label22, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBMX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSERF, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBBVA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label23, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label24, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label25, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBMXTM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSERFTM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBBVATM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label26, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label27, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbGlobalTarjetas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbBMXTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbSERFTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbBBVATotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblPedidosSH, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPedidosSH, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblEcommerce, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEcommerce, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblEfectivo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEfectivo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblCredito, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCreditoDebito, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label28, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDPCARD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAbonoDPCA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEfectivoDPCA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label30, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label31, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCreditoDebitoDPCA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblEcommDPVale, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEcommDPVale, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

#End Region
End Class
