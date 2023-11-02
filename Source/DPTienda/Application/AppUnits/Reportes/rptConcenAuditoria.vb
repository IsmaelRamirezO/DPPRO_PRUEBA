Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Imports DportenisPro.DPTienda.ApplicationUnits.CierreCaja

Public Class rptConcenAuditoria
    Inherits DataDynamics.ActiveReports.ActiveReport

    Private oCierreCajasMgr As CierreCajaManager

    Public Sub New(ByVal Fecha As Date, ByVal strAlmacen As String)

        MyBase.New()
        InitializeComponent()

        Dim dsIngresos As DataSet, dsFacturasC As DataSet, dsFacturasA As DataSet

        Me.txtAlmacen.Text = strAlmacen
        Me.txtFecha.Text = Fecha.ToShortDateString
        Me.txtFechaHora.Text = Now.ToString

        oCierreCajasMgr = New CierreCajaManager(oAppContext)

        dsIngresos = oCierreCajasMgr.GetTotalIngresos(Fecha)
        'Efectivo
        With dsIngresos.Tables(0).Rows(0)
            Me.txtGlobalEfectivo.Value = !TotalEfectivo
            Me.txtEfecAbonos.Value = !Abonos
            Me.txtEfecDips.Value = !DIPs
            Me.txtEfecDPVL.Value = !DPVL
            Me.txtEfecEMP.Value = !EMP
            Me.txtEfecFACI.Value = !FACI
            Me.txtEfecFF.Value = !FF
            Me.txtEfecFONA.Value = !FONA
            Me.txtEfecPGral.Value = !PG
            Me.txtEfecVtaAsis.Value = !OP
            Me.txtEfecVtaSH.Value = !SH
        End With
        'Tarjeta
        With dsIngresos.Tables(1).Rows(0)
            Me.txtGlobalTarjeta.Value = !TotalTarjeta
            Me.txtTarjAbonos.Value = !Abonos
            Me.txtTarjDips.Value = !DIPs
            Me.txtTarjDPVL.Value = !DPVL
            Me.txtTarjEMP.Value = !EMP
            Me.txtTarjFACI.Value = !FACI
            Me.txtTarjFF.Value = !FF
            Me.txtTarjFONA.Value = !FONA
            Me.txtTarjPGral.Value = !PG
            Me.txtTarjVtaAsis.Value = !OP
            Me.txtTarjVtaSH.Value = !SH
        End With
        'Vale de Caja
        With dsIngresos.Tables(3).Rows(0)
            Me.txtGlobalValeCaja.Value = !TotalValeCaja
            Me.txtVcjaDips.Value = !DIPs
            Me.txtVcjaDPVL.Value = !DPVL
            Me.txtVcjaEMP.Value = !EMP
            Me.txtVcjaFACI.Value = !FACI
            Me.txtVcjaFF.Value = !FF
            Me.txtVcjaFONA.Value = !FONA
            Me.txtVcjaPG.Value = !PG
            Me.txtVcjaVtaAsis.Value = !OP
            Me.txtVtaSH.Value = !SH
        End With
        'Fonacot
        With dsIngresos.Tables(2).Rows(0)
            Me.txtGlobalFonacot.Value = !TotalFonacot
            Me.txtFonacot.Value = !FONA
        End With
        'DPVale
        With dsIngresos.Tables(4).Rows(0)
            Me.txtGlobalDPVale.Value = !TotalDPVale
            Me.txtDpvlDPVL.Value = !DPVL
            Me.txtDpvlSH.Value = !SH
        End With
        'Facilito
        With dsIngresos.Tables(5).Rows(0)
            Me.txtGlobalFacilito.Value = !TotalFacilito
            Me.txtFacilito.Value = !FACI
        End With

        '---------------------------------------------------------------
        'JNAVA (20.03.2015): DP CARC CREDIT
        '---------------------------------------------------------------
        With dsIngresos.Tables(6).Rows(0)
            Me.txtGlobalDPCA.Value = !TotalDPCA
            Me.txtDPCAAbonos.Value = !Abonos
            Me.txtDPCADips.Value = !DIPs
            Me.txtDPCADPVL.Value = !DPVL
            Me.txtDPCAEMP.Value = !EMP
            Me.txtDPCAFACI.Value = !FACI
            Me.txtDPCAFF.Value = !FF
            Me.txtDPCAFONA.Value = !FONA
            Me.txtDPCAPGral.Value = !PG
            Me.txtDPCAVtaAsis.Value = !OP
            Me.txtDPCAVtaSH.Value = !SH
        End With

        Me.txtRetiros.Value = oCierreCajasMgr.CalcularTotalRetirosREP(Fecha)
        Me.txtTotalFacturado.Value = oCierreCajasMgr.MontoFacturadoGETREP(Fecha)

        dsFacturasA = oCierreCajasMgr.TotalFacturasAGetREP(Fecha)
        If Not IsDBNull(dsFacturasA.Tables(0).Rows(0).Item("Total")) Then
            Me.txtFacturasActivas.Value = dsFacturasA.Tables(0).Rows(0).Item("Total")
        Else
            Me.txtFacturasActivas.Value = 0
        End If

        dsFacturasC = oCierreCajasMgr.TotalFacturasCGetREP(Fecha)
        If Not IsDBNull(dsFacturasC.Tables(0).Rows(0).Item("Total")) Then
            Me.txtFacturasCanceladas.Value = dsFacturasC.Tables(0).Rows(0).Item("Total")
        Else
            Me.txtFacturasCanceladas.Value = 0
        End If
    End Sub

#Region "ActiveReports Designer generated code"
    Private WithEvents PageHeader As PageHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents PageFooter As PageFooter = Nothing
	Private Shape1 As Shape = Nothing
	Private Label2 As Label = Nothing
	Private txtFecha As TextBox = Nothing
	Private Label3 As Label = Nothing
	Private txtAlmacen As TextBox = Nothing
	Private Label1 As Label = Nothing
	Private Label4 As Label = Nothing
	Private txtRetiros As TextBox = Nothing
	Private Label5 As Label = Nothing
	Private txtTotalFacturado As TextBox = Nothing
	Private Label6 As Label = Nothing
	Private txtFacturasActivas As TextBox = Nothing
	Private Label20 As Label = Nothing
	Private Label21 As Label = Nothing
	Private Label22 As Label = Nothing
	Private Label27 As Label = Nothing
	Private txtGlobalEfectivo As TextBox = Nothing
	Private txtEfecPGral As TextBox = Nothing
	Private txtEfecVtaSH As TextBox = Nothing
	Private txtEfecVtaAsis As TextBox = Nothing
	Private Label28 As Label = Nothing
	Private Label29 As Label = Nothing
	Private Label30 As Label = Nothing
	Private txtEfecDips As TextBox = Nothing
	Private txtEfecFF As TextBox = Nothing
	Private txtEfecAbonos As TextBox = Nothing
	Private Label31 As Label = Nothing
	Private Label32 As Label = Nothing
	Private Label33 As Label = Nothing
	Private Label34 As Label = Nothing
	Private txtGlobalTarjeta As TextBox = Nothing
	Private txtTarjPGral As TextBox = Nothing
	Private txtTarjVtaSH As TextBox = Nothing
	Private txtTarjVtaAsis As TextBox = Nothing
	Private Label35 As Label = Nothing
	Private Label36 As Label = Nothing
	Private Label37 As Label = Nothing
	Private txtTarjDips As TextBox = Nothing
	Private txtTarjFF As TextBox = Nothing
	Private txtTarjAbonos As TextBox = Nothing
	Private Label38 As Label = Nothing
	Private Label41 As Label = Nothing
	Private txtGlobalFonacot As TextBox = Nothing
	Private txtFonacot As TextBox = Nothing
	Private Label45 As Label = Nothing
	Private Label46 As Label = Nothing
	Private Label47 As Label = Nothing
	Private Label48 As Label = Nothing
	Private txtGlobalValeCaja As TextBox = Nothing
	Private txtVcjaPG As TextBox = Nothing
	Private txtVtaSH As TextBox = Nothing
	Private txtVcjaVtaAsis As TextBox = Nothing
	Private Label49 As Label = Nothing
	Private Label51 As Label = Nothing
	Private txtVcjaDips As TextBox = Nothing
	Private txtVcjaFF As TextBox = Nothing
	Private Label52 As Label = Nothing
	Private Label54 As Label = Nothing
	Private Label55 As Label = Nothing
	Private txtGlobalDPVale As TextBox = Nothing
	Private txtDpvlDPVL As TextBox = Nothing
	Private txtDpvlSH As TextBox = Nothing
	Private Label56 As Label = Nothing
	Private Label58 As Label = Nothing
	Private txtGlobalFacilito As TextBox = Nothing
	Private txtFacilito As TextBox = Nothing
	Private Label59 As Label = Nothing
	Private txtFacturasCanceladas As TextBox = Nothing
	Private Label60 As Label = Nothing
	Private txtEfecFONA As TextBox = Nothing
	Private Label61 As Label = Nothing
	Private txtEfecFACI As TextBox = Nothing
	Private Label62 As Label = Nothing
	Private txtEfecDPVL As TextBox = Nothing
	Private Label63 As Label = Nothing
	Private txtEfecEMP As TextBox = Nothing
	Private Label64 As Label = Nothing
	Private txtTarjFONA As TextBox = Nothing
	Private Label65 As Label = Nothing
	Private txtTarjFACI As TextBox = Nothing
	Private Label66 As Label = Nothing
	Private txtTarjDPVL As TextBox = Nothing
	Private Label67 As Label = Nothing
	Private txtTarjEMP As TextBox = Nothing
	Private Label68 As Label = Nothing
	Private txtVcjaFONA As TextBox = Nothing
	Private Label69 As Label = Nothing
	Private txtVcjaFACI As TextBox = Nothing
	Private Label70 As Label = Nothing
	Private txtVcjaDPVL As TextBox = Nothing
	Private Label71 As Label = Nothing
	Private txtVcjaEMP As TextBox = Nothing
	Private txtFechaHora As TextBox = Nothing
	Private Label72 As Label = Nothing
	Private Label73 As Label = Nothing
	Private Label74 As Label = Nothing
	Private Label75 As Label = Nothing
	Private txtGlobalDPCA As TextBox = Nothing
	Private txtDPCAPGral As TextBox = Nothing
	Private txtDPCAVtaSH As TextBox = Nothing
	Private txtDPCAVtaAsis As TextBox = Nothing
	Private Label76 As Label = Nothing
	Private Label77 As Label = Nothing
	Private Label78 As Label = Nothing
	Private txtDPCADips As TextBox = Nothing
	Private txtDPCAFF As TextBox = Nothing
	Private txtDPCAAbonos As TextBox = Nothing
	Private Label79 As Label = Nothing
	Private txtDPCAFONA As TextBox = Nothing
	Private Label80 As Label = Nothing
	Private txtDPCAFACI As TextBox = Nothing
	Private Label81 As Label = Nothing
	Private txtDPCADPVL As TextBox = Nothing
	Private Label82 As Label = Nothing
	Private txtDPCAEMP As TextBox = Nothing
	Private txtNoPag As TextBox = Nothing
	Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptConcenAuditoria))
            Me.Detail = New DataDynamics.ActiveReports.Detail()
            Me.PageHeader = New DataDynamics.ActiveReports.PageHeader()
            Me.PageFooter = New DataDynamics.ActiveReports.PageFooter()
            Me.Shape1 = New DataDynamics.ActiveReports.Shape()
            Me.Label2 = New DataDynamics.ActiveReports.Label()
            Me.txtFecha = New DataDynamics.ActiveReports.TextBox()
            Me.Label3 = New DataDynamics.ActiveReports.Label()
            Me.txtAlmacen = New DataDynamics.ActiveReports.TextBox()
            Me.Label1 = New DataDynamics.ActiveReports.Label()
            Me.Label4 = New DataDynamics.ActiveReports.Label()
            Me.txtRetiros = New DataDynamics.ActiveReports.TextBox()
            Me.Label5 = New DataDynamics.ActiveReports.Label()
            Me.txtTotalFacturado = New DataDynamics.ActiveReports.TextBox()
            Me.Label6 = New DataDynamics.ActiveReports.Label()
            Me.txtFacturasActivas = New DataDynamics.ActiveReports.TextBox()
            Me.Label20 = New DataDynamics.ActiveReports.Label()
            Me.Label21 = New DataDynamics.ActiveReports.Label()
            Me.Label22 = New DataDynamics.ActiveReports.Label()
            Me.Label27 = New DataDynamics.ActiveReports.Label()
            Me.txtGlobalEfectivo = New DataDynamics.ActiveReports.TextBox()
            Me.txtEfecPGral = New DataDynamics.ActiveReports.TextBox()
            Me.txtEfecVtaSH = New DataDynamics.ActiveReports.TextBox()
            Me.txtEfecVtaAsis = New DataDynamics.ActiveReports.TextBox()
            Me.Label28 = New DataDynamics.ActiveReports.Label()
            Me.Label29 = New DataDynamics.ActiveReports.Label()
            Me.Label30 = New DataDynamics.ActiveReports.Label()
            Me.txtEfecDips = New DataDynamics.ActiveReports.TextBox()
            Me.txtEfecFF = New DataDynamics.ActiveReports.TextBox()
            Me.txtEfecAbonos = New DataDynamics.ActiveReports.TextBox()
            Me.Label31 = New DataDynamics.ActiveReports.Label()
            Me.Label32 = New DataDynamics.ActiveReports.Label()
            Me.Label33 = New DataDynamics.ActiveReports.Label()
            Me.Label34 = New DataDynamics.ActiveReports.Label()
            Me.txtGlobalTarjeta = New DataDynamics.ActiveReports.TextBox()
            Me.txtTarjPGral = New DataDynamics.ActiveReports.TextBox()
            Me.txtTarjVtaSH = New DataDynamics.ActiveReports.TextBox()
            Me.txtTarjVtaAsis = New DataDynamics.ActiveReports.TextBox()
            Me.Label35 = New DataDynamics.ActiveReports.Label()
            Me.Label36 = New DataDynamics.ActiveReports.Label()
            Me.Label37 = New DataDynamics.ActiveReports.Label()
            Me.txtTarjDips = New DataDynamics.ActiveReports.TextBox()
            Me.txtTarjFF = New DataDynamics.ActiveReports.TextBox()
            Me.txtTarjAbonos = New DataDynamics.ActiveReports.TextBox()
            Me.Label38 = New DataDynamics.ActiveReports.Label()
            Me.Label41 = New DataDynamics.ActiveReports.Label()
            Me.txtGlobalFonacot = New DataDynamics.ActiveReports.TextBox()
            Me.txtFonacot = New DataDynamics.ActiveReports.TextBox()
            Me.Label45 = New DataDynamics.ActiveReports.Label()
            Me.Label46 = New DataDynamics.ActiveReports.Label()
            Me.Label47 = New DataDynamics.ActiveReports.Label()
            Me.Label48 = New DataDynamics.ActiveReports.Label()
            Me.txtGlobalValeCaja = New DataDynamics.ActiveReports.TextBox()
            Me.txtVcjaPG = New DataDynamics.ActiveReports.TextBox()
            Me.txtVtaSH = New DataDynamics.ActiveReports.TextBox()
            Me.txtVcjaVtaAsis = New DataDynamics.ActiveReports.TextBox()
            Me.Label49 = New DataDynamics.ActiveReports.Label()
            Me.Label51 = New DataDynamics.ActiveReports.Label()
            Me.txtVcjaDips = New DataDynamics.ActiveReports.TextBox()
            Me.txtVcjaFF = New DataDynamics.ActiveReports.TextBox()
            Me.Label52 = New DataDynamics.ActiveReports.Label()
            Me.Label54 = New DataDynamics.ActiveReports.Label()
            Me.Label55 = New DataDynamics.ActiveReports.Label()
            Me.txtGlobalDPVale = New DataDynamics.ActiveReports.TextBox()
            Me.txtDpvlDPVL = New DataDynamics.ActiveReports.TextBox()
            Me.txtDpvlSH = New DataDynamics.ActiveReports.TextBox()
            Me.Label56 = New DataDynamics.ActiveReports.Label()
            Me.Label58 = New DataDynamics.ActiveReports.Label()
            Me.txtGlobalFacilito = New DataDynamics.ActiveReports.TextBox()
            Me.txtFacilito = New DataDynamics.ActiveReports.TextBox()
            Me.Label59 = New DataDynamics.ActiveReports.Label()
            Me.txtFacturasCanceladas = New DataDynamics.ActiveReports.TextBox()
            Me.Label60 = New DataDynamics.ActiveReports.Label()
            Me.txtEfecFONA = New DataDynamics.ActiveReports.TextBox()
            Me.Label61 = New DataDynamics.ActiveReports.Label()
            Me.txtEfecFACI = New DataDynamics.ActiveReports.TextBox()
            Me.Label62 = New DataDynamics.ActiveReports.Label()
            Me.txtEfecDPVL = New DataDynamics.ActiveReports.TextBox()
            Me.Label63 = New DataDynamics.ActiveReports.Label()
            Me.txtEfecEMP = New DataDynamics.ActiveReports.TextBox()
            Me.Label64 = New DataDynamics.ActiveReports.Label()
            Me.txtTarjFONA = New DataDynamics.ActiveReports.TextBox()
            Me.Label65 = New DataDynamics.ActiveReports.Label()
            Me.txtTarjFACI = New DataDynamics.ActiveReports.TextBox()
            Me.Label66 = New DataDynamics.ActiveReports.Label()
            Me.txtTarjDPVL = New DataDynamics.ActiveReports.TextBox()
            Me.Label67 = New DataDynamics.ActiveReports.Label()
            Me.txtTarjEMP = New DataDynamics.ActiveReports.TextBox()
            Me.Label68 = New DataDynamics.ActiveReports.Label()
            Me.txtVcjaFONA = New DataDynamics.ActiveReports.TextBox()
            Me.Label69 = New DataDynamics.ActiveReports.Label()
            Me.txtVcjaFACI = New DataDynamics.ActiveReports.TextBox()
            Me.Label70 = New DataDynamics.ActiveReports.Label()
            Me.txtVcjaDPVL = New DataDynamics.ActiveReports.TextBox()
            Me.Label71 = New DataDynamics.ActiveReports.Label()
            Me.txtVcjaEMP = New DataDynamics.ActiveReports.TextBox()
            Me.txtFechaHora = New DataDynamics.ActiveReports.TextBox()
            Me.Label72 = New DataDynamics.ActiveReports.Label()
            Me.Label73 = New DataDynamics.ActiveReports.Label()
            Me.Label74 = New DataDynamics.ActiveReports.Label()
            Me.Label75 = New DataDynamics.ActiveReports.Label()
            Me.txtGlobalDPCA = New DataDynamics.ActiveReports.TextBox()
            Me.txtDPCAPGral = New DataDynamics.ActiveReports.TextBox()
            Me.txtDPCAVtaSH = New DataDynamics.ActiveReports.TextBox()
            Me.txtDPCAVtaAsis = New DataDynamics.ActiveReports.TextBox()
            Me.Label76 = New DataDynamics.ActiveReports.Label()
            Me.Label77 = New DataDynamics.ActiveReports.Label()
            Me.Label78 = New DataDynamics.ActiveReports.Label()
            Me.txtDPCADips = New DataDynamics.ActiveReports.TextBox()
            Me.txtDPCAFF = New DataDynamics.ActiveReports.TextBox()
            Me.txtDPCAAbonos = New DataDynamics.ActiveReports.TextBox()
            Me.Label79 = New DataDynamics.ActiveReports.Label()
            Me.txtDPCAFONA = New DataDynamics.ActiveReports.TextBox()
            Me.Label80 = New DataDynamics.ActiveReports.Label()
            Me.txtDPCAFACI = New DataDynamics.ActiveReports.TextBox()
            Me.Label81 = New DataDynamics.ActiveReports.Label()
            Me.txtDPCADPVL = New DataDynamics.ActiveReports.TextBox()
            Me.Label82 = New DataDynamics.ActiveReports.Label()
            Me.txtDPCAEMP = New DataDynamics.ActiveReports.TextBox()
            Me.txtNoPag = New DataDynamics.ActiveReports.TextBox()
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFecha,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label3,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtAlmacen,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label1,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtRetiros,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label5,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtTotalFacturado,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label6,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFacturasActivas,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label20,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label21,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label22,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label27,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtGlobalEfectivo,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtEfecPGral,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtEfecVtaSH,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtEfecVtaAsis,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label28,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label29,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label30,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtEfecDips,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtEfecFF,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtEfecAbonos,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label31,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label32,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label33,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label34,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtGlobalTarjeta,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtTarjPGral,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtTarjVtaSH,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtTarjVtaAsis,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label35,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label36,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label37,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtTarjDips,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtTarjFF,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtTarjAbonos,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label38,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label41,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtGlobalFonacot,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFonacot,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label45,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label46,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label47,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label48,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtGlobalValeCaja,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtVcjaPG,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtVtaSH,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtVcjaVtaAsis,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label49,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label51,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtVcjaDips,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtVcjaFF,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label52,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label54,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label55,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtGlobalDPVale,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtDpvlDPVL,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtDpvlSH,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label56,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label58,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtGlobalFacilito,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFacilito,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label59,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFacturasCanceladas,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label60,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtEfecFONA,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label61,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtEfecFACI,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label62,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtEfecDPVL,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label63,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtEfecEMP,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label64,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtTarjFONA,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label65,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtTarjFACI,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label66,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtTarjDPVL,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label67,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtTarjEMP,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label68,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtVcjaFONA,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label69,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtVcjaFACI,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label70,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtVcjaDPVL,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label71,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtVcjaEMP,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFechaHora,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label72,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label73,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label74,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label75,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtGlobalDPCA,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtDPCAPGral,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtDPCAVtaSH,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtDPCAVtaAsis,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label76,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label77,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label78,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtDPCADips,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtDPCAFF,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtDPCAAbonos,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label79,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtDPCAFONA,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label80,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtDPCAFACI,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label81,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtDPCADPVL,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label82,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtDPCAEMP,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtNoPag,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
            '
            'Detail
            '
            Me.Detail.ColumnSpacing = 0!
            Me.Detail.Height = 0!
            Me.Detail.Name = "Detail"
            '
            'PageHeader
            '
            Me.PageHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape1, Me.Label2, Me.txtFecha, Me.Label3, Me.txtAlmacen, Me.Label1, Me.Label4, Me.txtRetiros, Me.Label5, Me.txtTotalFacturado, Me.Label6, Me.txtFacturasActivas, Me.Label20, Me.Label21, Me.Label22, Me.Label27, Me.txtGlobalEfectivo, Me.txtEfecPGral, Me.txtEfecVtaSH, Me.txtEfecVtaAsis, Me.Label28, Me.Label29, Me.Label30, Me.txtEfecDips, Me.txtEfecFF, Me.txtEfecAbonos, Me.Label31, Me.Label32, Me.Label33, Me.Label34, Me.txtGlobalTarjeta, Me.txtTarjPGral, Me.txtTarjVtaSH, Me.txtTarjVtaAsis, Me.Label35, Me.Label36, Me.Label37, Me.txtTarjDips, Me.txtTarjFF, Me.txtTarjAbonos, Me.Label38, Me.Label41, Me.txtGlobalFonacot, Me.txtFonacot, Me.Label45, Me.Label46, Me.Label47, Me.Label48, Me.txtGlobalValeCaja, Me.txtVcjaPG, Me.txtVtaSH, Me.txtVcjaVtaAsis, Me.Label49, Me.Label51, Me.txtVcjaDips, Me.txtVcjaFF, Me.Label52, Me.Label54, Me.Label55, Me.txtGlobalDPVale, Me.txtDpvlDPVL, Me.txtDpvlSH, Me.Label56, Me.Label58, Me.txtGlobalFacilito, Me.txtFacilito, Me.Label59, Me.txtFacturasCanceladas, Me.Label60, Me.txtEfecFONA, Me.Label61, Me.txtEfecFACI, Me.Label62, Me.txtEfecDPVL, Me.Label63, Me.txtEfecEMP, Me.Label64, Me.txtTarjFONA, Me.Label65, Me.txtTarjFACI, Me.Label66, Me.txtTarjDPVL, Me.Label67, Me.txtTarjEMP, Me.Label68, Me.txtVcjaFONA, Me.Label69, Me.txtVcjaFACI, Me.Label70, Me.txtVcjaDPVL, Me.Label71, Me.txtVcjaEMP, Me.txtFechaHora, Me.Label72, Me.Label73, Me.Label74, Me.Label75, Me.txtGlobalDPCA, Me.txtDPCAPGral, Me.txtDPCAVtaSH, Me.txtDPCAVtaAsis, Me.Label76, Me.Label77, Me.Label78, Me.txtDPCADips, Me.txtDPCAFF, Me.txtDPCAAbonos, Me.Label79, Me.txtDPCAFONA, Me.Label80, Me.txtDPCAFACI, Me.Label81, Me.txtDPCADPVL, Me.Label82, Me.txtDPCAEMP})
            Me.PageHeader.Height = 6.103472!
            Me.PageHeader.Name = "PageHeader"
            '
            'PageFooter
            '
            Me.PageFooter.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtNoPag})
            Me.PageFooter.Height = 0.1979167!
            Me.PageFooter.Name = "PageFooter"
            '
            'Shape1
            '
            Me.Shape1.Height = 0.6299213!
            Me.Shape1.Left = 0!
            Me.Shape1.Name = "Shape1"
            Me.Shape1.RoundingRadius = 9.999999!
            Me.Shape1.Top = 0!
            Me.Shape1.Width = 6.625!
            '
            'Label2
            '
            Me.Label2.Height = 0.2!
            Me.Label2.HyperLink = Nothing
            Me.Label2.Left = 0.125!
            Me.Label2.Name = "Label2"
            Me.Label2.Style = "font-weight: bold; font-size: 8.25pt"
            Me.Label2.Text = "Fecha:"
            Me.Label2.Top = 0.2037401!
            Me.Label2.Width = 0.5349411!
            '
            'txtFecha
            '
            Me.txtFecha.Height = 0.2!
            Me.txtFecha.Left = 0.659941!
            Me.txtFecha.Name = "txtFecha"
            Me.txtFecha.Text = "txtFecha"
            Me.txtFecha.Top = 0.2037401!
            Me.txtFecha.Width = 1!
            '
            'Label3
            '
            Me.Label3.Height = 0.2!
            Me.Label3.HyperLink = Nothing
            Me.Label3.Left = 0.125!
            Me.Label3.Name = "Label3"
            Me.Label3.Style = "font-weight: bold; font-size: 8.25pt"
            Me.Label3.Text = "Sucursal:"
            Me.Label3.Top = 0.4375!
            Me.Label3.Width = 0.625!
            '
            'txtAlmacen
            '
            Me.txtAlmacen.Height = 0.2!
            Me.txtAlmacen.Left = 0.75!
            Me.txtAlmacen.Name = "txtAlmacen"
            Me.txtAlmacen.Style = "font-size: 8.25pt"
            Me.txtAlmacen.Text = "TextBox1"
            Me.txtAlmacen.Top = 0.4375!
            Me.txtAlmacen.Width = 3.454233!
            '
            'Label1
            '
            Me.Label1.Height = 0.2!
            Me.Label1.HyperLink = Nothing
            Me.Label1.Left = 0!
            Me.Label1.Name = "Label1"
            Me.Label1.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
            Me.Label1.Text = "Reporte Concentrado de Cierre de Caja (Auditoria)"
            Me.Label1.Top = 0.07874014!
            Me.Label1.Width = 6.625!
            '
            'Label4
            '
            Me.Label4.Height = 0.2!
            Me.Label4.HyperLink = Nothing
            Me.Label4.Left = 3.875!
            Me.Label4.Name = "Label4"
            Me.Label4.Style = "font-weight: bold; font-size: 8.25pt"
            Me.Label4.Text = "RETIROS:"
            Me.Label4.Top = 5.125!
            Me.Label4.Width = 1.496063!
            '
            'txtRetiros
            '
            Me.txtRetiros.Height = 0.2!
            Me.txtRetiros.Left = 5.449802!
            Me.txtRetiros.Name = "txtRetiros"
            Me.txtRetiros.OutputFormat = resources.GetString("txtRetiros.OutputFormat")
            Me.txtRetiros.Style = "text-align: center; font-weight: bold; font-size: 9.75pt"
            Me.txtRetiros.Text = "$ 21,625.08"
            Me.txtRetiros.Top = 5.125!
            Me.txtRetiros.Width = 1.181102!
            '
            'Label5
            '
            Me.Label5.Height = 0.2!
            Me.Label5.HyperLink = Nothing
            Me.Label5.Left = 3.875!
            Me.Label5.Name = "Label5"
            Me.Label5.Style = "font-weight: bold; font-size: 8.25pt"
            Me.Label5.Text = "TOTAL FACTURADO:"
            Me.Label5.Top = 5.361222!
            Me.Label5.Width = 1.496063!
            '
            'txtTotalFacturado
            '
            Me.txtTotalFacturado.Height = 0.2!
            Me.txtTotalFacturado.Left = 5.449802!
            Me.txtTotalFacturado.Name = "txtTotalFacturado"
            Me.txtTotalFacturado.OutputFormat = resources.GetString("txtTotalFacturado.OutputFormat")
            Me.txtTotalFacturado.Style = "text-align: center; font-weight: bold; font-size: 9.75pt"
            Me.txtTotalFacturado.Text = "$ 42,466.10"
            Me.txtTotalFacturado.Top = 5.361222!
            Me.txtTotalFacturado.Width = 1.181102!
            '
            'Label6
            '
            Me.Label6.Height = 0.2!
            Me.Label6.HyperLink = Nothing
            Me.Label6.Left = 3.875!
            Me.Label6.Name = "Label6"
            Me.Label6.Style = "font-weight: bold; font-size: 8.25pt"
            Me.Label6.Text = "FACTURAS ACTIVAS:"
            Me.Label6.Top = 5.59744!
            Me.Label6.Width = 1.496063!
            '
            'txtFacturasActivas
            '
            Me.txtFacturasActivas.Height = 0.2!
            Me.txtFacturasActivas.Left = 5.449802!
            Me.txtFacturasActivas.Name = "txtFacturasActivas"
            Me.txtFacturasActivas.OutputFormat = resources.GetString("txtFacturasActivas.OutputFormat")
            Me.txtFacturasActivas.Style = "text-align: center; font-weight: bold; font-size: 9.75pt"
            Me.txtFacturasActivas.Text = "42"
            Me.txtFacturasActivas.Top = 5.59744!
            Me.txtFacturasActivas.Width = 1.181102!
            '
            'Label20
            '
            Me.Label20.Height = 0.2!
            Me.Label20.HyperLink = Nothing
            Me.Label20.Left = 0.03494096!
            Me.Label20.Name = "Label20"
            Me.Label20.Style = "text-decoration: none; font-weight: normal; font-size: 8.25pt"
            Me.Label20.Text = "Público en General"
            Me.Label20.Top = 1.099901!
            Me.Label20.Width = 1.152559!
            '
            'Label21
            '
            Me.Label21.Height = 0.2!
            Me.Label21.HyperLink = Nothing
            Me.Label21.Left = 0.03494096!
            Me.Label21.Name = "Label21"
            Me.Label21.Style = "text-decoration: none; font-weight: normal; font-size: 8.25pt"
            Me.Label21.Text = "Venta Asistida"
            Me.Label21.Top = 1.287401!
            Me.Label21.Width = 1.152559!
            '
            'Label22
            '
            Me.Label22.Height = 0.2!
            Me.Label22.HyperLink = Nothing
            Me.Label22.Left = 0.03494096!
            Me.Label22.Name = "Label22"
            Me.Label22.Style = "text-decoration: none; font-weight: normal; font-size: 8.25pt"
            Me.Label22.Text = "Venta Si Hay"
            Me.Label22.Top = 1.474901!
            Me.Label22.Width = 1.152559!
            '
            'Label27
            '
            Me.Label27.Height = 0.2!
            Me.Label27.HyperLink = Nothing
            Me.Label27.Left = 0.03494099!
            Me.Label27.Name = "Label27"
            Me.Label27.Style = "text-decoration: underline; font-weight: bold; font-style: normal; font-size: 8.2"& _ 
                "5pt"
            Me.Label27.Text = "GLOBAL EFECTIVO"
            Me.Label27.Top = 0.8660001!
            Me.Label27.Width = 1.152559!
            '
            'txtGlobalEfectivo
            '
            Me.txtGlobalEfectivo.Height = 0.2!
            Me.txtGlobalEfectivo.Left = 1.172244!
            Me.txtGlobalEfectivo.Name = "txtGlobalEfectivo"
            Me.txtGlobalEfectivo.OutputFormat = resources.GetString("txtGlobalEfectivo.OutputFormat")
            Me.txtGlobalEfectivo.Style = "text-align: right; font-weight: bold; font-size: 9pt"
            Me.txtGlobalEfectivo.Text = "$ 1,568,623.85"
            Me.txtGlobalEfectivo.Top = 0.8660001!
            Me.txtGlobalEfectivo.Width = 0.8902562!
            '
            'txtEfecPGral
            '
            Me.txtEfecPGral.Height = 0.2!
            Me.txtEfecPGral.Left = 1.172244!
            Me.txtEfecPGral.Name = "txtEfecPGral"
            Me.txtEfecPGral.OutputFormat = resources.GetString("txtEfecPGral.OutputFormat")
            Me.txtEfecPGral.Style = "text-decoration: none; text-align: right; font-weight: normal; font-size: 8.25pt"
            Me.txtEfecPGral.Text = "$ 0.00"
            Me.txtEfecPGral.Top = 1.099901!
            Me.txtEfecPGral.Width = 0.7652562!
            '
            'txtEfecVtaSH
            '
            Me.txtEfecVtaSH.Height = 0.2!
            Me.txtEfecVtaSH.Left = 1.172244!
            Me.txtEfecVtaSH.Name = "txtEfecVtaSH"
            Me.txtEfecVtaSH.OutputFormat = resources.GetString("txtEfecVtaSH.OutputFormat")
            Me.txtEfecVtaSH.Style = "text-decoration: none; text-align: right; font-weight: normal; font-size: 8.25pt"
            Me.txtEfecVtaSH.Text = "$ 0.00"
            Me.txtEfecVtaSH.Top = 1.474901!
            Me.txtEfecVtaSH.Width = 0.7652562!
            '
            'txtEfecVtaAsis
            '
            Me.txtEfecVtaAsis.Height = 0.2!
            Me.txtEfecVtaAsis.Left = 1.172244!
            Me.txtEfecVtaAsis.Name = "txtEfecVtaAsis"
            Me.txtEfecVtaAsis.OutputFormat = resources.GetString("txtEfecVtaAsis.OutputFormat")
            Me.txtEfecVtaAsis.Style = "text-decoration: none; text-align: right; font-weight: normal; font-size: 8.25pt"
            Me.txtEfecVtaAsis.Text = "$ 0.00"
            Me.txtEfecVtaAsis.Top = 1.287401!
            Me.txtEfecVtaAsis.Width = 0.7652562!
            '
            'Label28
            '
            Me.Label28.Height = 0.2!
            Me.Label28.HyperLink = Nothing
            Me.Label28.Left = 0.03494096!
            Me.Label28.Name = "Label28"
            Me.Label28.Style = "text-decoration: none; font-weight: normal; font-size: 8.25pt"
            Me.Label28.Text = "Dips"
            Me.Label28.Top = 1.662401!
            Me.Label28.Width = 1.152559!
            '
            'Label29
            '
            Me.Label29.Height = 0.2!
            Me.Label29.HyperLink = Nothing
            Me.Label29.Left = 0.03494096!
            Me.Label29.Name = "Label29"
            Me.Label29.Style = "text-decoration: none; font-weight: normal; font-size: 8.25pt"
            Me.Label29.Text = "Abonos de Apartado"
            Me.Label29.Top = 1.849901!
            Me.Label29.Width = 1.152559!
            '
            'Label30
            '
            Me.Label30.Height = 0.2!
            Me.Label30.HyperLink = Nothing
            Me.Label30.Left = 0.03494096!
            Me.Label30.Name = "Label30"
            Me.Label30.Style = "text-decoration: none; font-weight: normal; font-size: 8.25pt"
            Me.Label30.Text = "Facturacion Fiscal"
            Me.Label30.Top = 2.037401!
            Me.Label30.Width = 1.152559!
            '
            'txtEfecDips
            '
            Me.txtEfecDips.Height = 0.2!
            Me.txtEfecDips.Left = 1.172244!
            Me.txtEfecDips.Name = "txtEfecDips"
            Me.txtEfecDips.OutputFormat = resources.GetString("txtEfecDips.OutputFormat")
            Me.txtEfecDips.Style = "text-decoration: none; text-align: right; font-weight: normal; font-size: 8.25pt"
            Me.txtEfecDips.Text = "$ 100,883.25"
            Me.txtEfecDips.Top = 1.662401!
            Me.txtEfecDips.Width = 0.7652562!
            '
            'txtEfecFF
            '
            Me.txtEfecFF.Height = 0.2!
            Me.txtEfecFF.Left = 1.172244!
            Me.txtEfecFF.Name = "txtEfecFF"
            Me.txtEfecFF.OutputFormat = resources.GetString("txtEfecFF.OutputFormat")
            Me.txtEfecFF.Style = "text-decoration: none; text-align: right; font-weight: normal; font-size: 8.25pt"
            Me.txtEfecFF.Text = "$ 0.00"
            Me.txtEfecFF.Top = 2.037401!
            Me.txtEfecFF.Width = 0.7652562!
            '
            'txtEfecAbonos
            '
            Me.txtEfecAbonos.Height = 0.2!
            Me.txtEfecAbonos.Left = 1.172244!
            Me.txtEfecAbonos.Name = "txtEfecAbonos"
            Me.txtEfecAbonos.OutputFormat = resources.GetString("txtEfecAbonos.OutputFormat")
            Me.txtEfecAbonos.Style = "text-decoration: none; text-align: right; font-weight: normal; font-size: 8.25pt"
            Me.txtEfecAbonos.Text = "$ 0.00"
            Me.txtEfecAbonos.Top = 1.849901!
            Me.txtEfecAbonos.Width = 0.7652562!
            '
            'Label31
            '
            Me.Label31.Height = 0.2!
            Me.Label31.HyperLink = Nothing
            Me.Label31.Left = 2.284941!
            Me.Label31.Name = "Label31"
            Me.Label31.Style = "text-decoration: none; font-weight: normal; font-size: 8.25pt"
            Me.Label31.Text = "Público en General"
            Me.Label31.Top = 1.099901!
            Me.Label31.Width = 1.152559!
            '
            'Label32
            '
            Me.Label32.Height = 0.2!
            Me.Label32.HyperLink = Nothing
            Me.Label32.Left = 2.284941!
            Me.Label32.Name = "Label32"
            Me.Label32.Style = "text-decoration: none; font-weight: normal; font-size: 8.25pt"
            Me.Label32.Text = "Venta Asistida"
            Me.Label32.Top = 1.287401!
            Me.Label32.Width = 1.152559!
            '
            'Label33
            '
            Me.Label33.Height = 0.2!
            Me.Label33.HyperLink = Nothing
            Me.Label33.Left = 2.284941!
            Me.Label33.Name = "Label33"
            Me.Label33.Style = "text-decoration: none; font-weight: normal; font-size: 8.25pt"
            Me.Label33.Text = "Venta Si Hay"
            Me.Label33.Top = 1.474901!
            Me.Label33.Width = 1.152559!
            '
            'Label34
            '
            Me.Label34.Height = 0.2!
            Me.Label34.HyperLink = Nothing
            Me.Label34.Left = 2.284941!
            Me.Label34.Name = "Label34"
            Me.Label34.Style = "text-decoration: underline; font-weight: bold; font-style: normal; font-size: 8.2"& _ 
                "5pt"
            Me.Label34.Text = "GLOBAL TARJETA"
            Me.Label34.Top = 0.8660001!
            Me.Label34.Width = 1.153!
            '
            'txtGlobalTarjeta
            '
            Me.txtGlobalTarjeta.Height = 0.2!
            Me.txtGlobalTarjeta.Left = 3.422244!
            Me.txtGlobalTarjeta.Name = "txtGlobalTarjeta"
            Me.txtGlobalTarjeta.OutputFormat = resources.GetString("txtGlobalTarjeta.OutputFormat")
            Me.txtGlobalTarjeta.Style = "text-align: right; font-weight: bold; font-size: 9pt"
            Me.txtGlobalTarjeta.Text = "$ 0.00"
            Me.txtGlobalTarjeta.Top = 0.8660001!
            Me.txtGlobalTarjeta.Width = 0.89!
            '
            'txtTarjPGral
            '
            Me.txtTarjPGral.Height = 0.2!
            Me.txtTarjPGral.Left = 3.422244!
            Me.txtTarjPGral.Name = "txtTarjPGral"
            Me.txtTarjPGral.OutputFormat = resources.GetString("txtTarjPGral.OutputFormat")
            Me.txtTarjPGral.Style = "text-decoration: none; text-align: right; font-weight: normal; font-size: 8.25pt"
            Me.txtTarjPGral.Text = "$ 0.00"
            Me.txtTarjPGral.Top = 1.099901!
            Me.txtTarjPGral.Width = 0.765!
            '
            'txtTarjVtaSH
            '
            Me.txtTarjVtaSH.Height = 0.2!
            Me.txtTarjVtaSH.Left = 3.422244!
            Me.txtTarjVtaSH.Name = "txtTarjVtaSH"
            Me.txtTarjVtaSH.OutputFormat = resources.GetString("txtTarjVtaSH.OutputFormat")
            Me.txtTarjVtaSH.Style = "text-decoration: none; text-align: right; font-weight: normal; font-size: 8.25pt"
            Me.txtTarjVtaSH.Text = "$ 0.00"
            Me.txtTarjVtaSH.Top = 1.474901!
            Me.txtTarjVtaSH.Width = 0.765!
            '
            'txtTarjVtaAsis
            '
            Me.txtTarjVtaAsis.Height = 0.2!
            Me.txtTarjVtaAsis.Left = 3.422244!
            Me.txtTarjVtaAsis.Name = "txtTarjVtaAsis"
            Me.txtTarjVtaAsis.OutputFormat = resources.GetString("txtTarjVtaAsis.OutputFormat")
            Me.txtTarjVtaAsis.Style = "text-decoration: none; text-align: right; font-weight: normal; font-size: 8.25pt"
            Me.txtTarjVtaAsis.Text = "$ 0.00"
            Me.txtTarjVtaAsis.Top = 1.287401!
            Me.txtTarjVtaAsis.Width = 0.765!
            '
            'Label35
            '
            Me.Label35.Height = 0.2!
            Me.Label35.HyperLink = Nothing
            Me.Label35.Left = 2.284941!
            Me.Label35.Name = "Label35"
            Me.Label35.Style = "text-decoration: none; font-weight: normal; font-size: 8.25pt"
            Me.Label35.Text = "Dips"
            Me.Label35.Top = 1.662401!
            Me.Label35.Width = 1.152559!
            '
            'Label36
            '
            Me.Label36.Height = 0.2!
            Me.Label36.HyperLink = Nothing
            Me.Label36.Left = 2.284941!
            Me.Label36.Name = "Label36"
            Me.Label36.Style = "text-decoration: none; font-weight: normal; font-size: 8.25pt"
            Me.Label36.Text = "Abonos de Apartado"
            Me.Label36.Top = 1.849901!
            Me.Label36.Width = 1.152559!
            '
            'Label37
            '
            Me.Label37.Height = 0.2!
            Me.Label37.HyperLink = Nothing
            Me.Label37.Left = 2.284941!
            Me.Label37.Name = "Label37"
            Me.Label37.Style = "text-decoration: none; font-weight: normal; font-size: 8.25pt"
            Me.Label37.Text = "Facturacion Fiscal"
            Me.Label37.Top = 2.037401!
            Me.Label37.Width = 1.152559!
            '
            'txtTarjDips
            '
            Me.txtTarjDips.Height = 0.2!
            Me.txtTarjDips.Left = 3.422244!
            Me.txtTarjDips.Name = "txtTarjDips"
            Me.txtTarjDips.OutputFormat = resources.GetString("txtTarjDips.OutputFormat")
            Me.txtTarjDips.Style = "text-decoration: none; text-align: right; font-weight: normal; font-size: 8.25pt"
            Me.txtTarjDips.Text = "$ 0.00"
            Me.txtTarjDips.Top = 1.662401!
            Me.txtTarjDips.Width = 0.765!
            '
            'txtTarjFF
            '
            Me.txtTarjFF.Height = 0.2!
            Me.txtTarjFF.Left = 3.4375!
            Me.txtTarjFF.Name = "txtTarjFF"
            Me.txtTarjFF.OutputFormat = resources.GetString("txtTarjFF.OutputFormat")
            Me.txtTarjFF.Style = "text-decoration: none; text-align: right; font-weight: normal; font-size: 8.25pt"
            Me.txtTarjFF.Text = "$ 0.00"
            Me.txtTarjFF.Top = 2.037!
            Me.txtTarjFF.Width = 0.765!
            '
            'txtTarjAbonos
            '
            Me.txtTarjAbonos.Height = 0.2!
            Me.txtTarjAbonos.Left = 3.422244!
            Me.txtTarjAbonos.Name = "txtTarjAbonos"
            Me.txtTarjAbonos.OutputFormat = resources.GetString("txtTarjAbonos.OutputFormat")
            Me.txtTarjAbonos.Style = "text-decoration: none; text-align: right; font-weight: normal; font-size: 8.25pt"
            Me.txtTarjAbonos.Text = "$ 0.00"
            Me.txtTarjAbonos.Top = 1.849901!
            Me.txtTarjAbonos.Width = 0.765!
            '
            'Label38
            '
            Me.Label38.Height = 0.2!
            Me.Label38.HyperLink = Nothing
            Me.Label38.Left = 0.035!
            Me.Label38.Name = "Label38"
            Me.Label38.Style = "text-decoration: none; font-weight: normal; font-size: 8.25pt"
            Me.Label38.Text = "Fonacot"
            Me.Label38.Top = 3.421401!
            Me.Label38.Width = 1.152559!
            '
            'Label41
            '
            Me.Label41.Height = 0.2!
            Me.Label41.HyperLink = Nothing
            Me.Label41.Left = 0.035!
            Me.Label41.Name = "Label41"
            Me.Label41.Style = "text-decoration: underline; font-weight: bold; font-style: normal; font-size: 8.2"& _ 
                "5pt"
            Me.Label41.Text = "GLOBAL FONACOT"
            Me.Label41.Top = 3.1875!
            Me.Label41.Width = 1.153!
            '
            'txtGlobalFonacot
            '
            Me.txtGlobalFonacot.Height = 0.2!
            Me.txtGlobalFonacot.Left = 1.199803!
            Me.txtGlobalFonacot.Name = "txtGlobalFonacot"
            Me.txtGlobalFonacot.OutputFormat = resources.GetString("txtGlobalFonacot.OutputFormat")
            Me.txtGlobalFonacot.Style = "text-align: right; font-weight: bold; font-size: 9pt"
            Me.txtGlobalFonacot.Text = "$ 0.00"
            Me.txtGlobalFonacot.Top = 3.1875!
            Me.txtGlobalFonacot.Width = 0.89!
            '
            'txtFonacot
            '
            Me.txtFonacot.Height = 0.2125985!
            Me.txtFonacot.Left = 1.199803!
            Me.txtFonacot.Name = "txtFonacot"
            Me.txtFonacot.OutputFormat = resources.GetString("txtFonacot.OutputFormat")
            Me.txtFonacot.Style = "text-decoration: none; text-align: right; font-weight: normal; font-size: 8.25pt"
            Me.txtFonacot.Text = "$ 0.00"
            Me.txtFonacot.Top = 3.421401!
            Me.txtFonacot.Width = 0.7652562!
            '
            'Label45
            '
            Me.Label45.Height = 0.2!
            Me.Label45.HyperLink = Nothing
            Me.Label45.Left = 4.5625!
            Me.Label45.Name = "Label45"
            Me.Label45.Style = "text-decoration: none; font-weight: normal; font-size: 8.25pt"
            Me.Label45.Text = "Público en General"
            Me.Label45.Top = 1.171401!
            Me.Label45.Width = 1.152559!
            '
            'Label46
            '
            Me.Label46.Height = 0.2!
            Me.Label46.HyperLink = Nothing
            Me.Label46.Left = 4.5625!
            Me.Label46.Name = "Label46"
            Me.Label46.Style = "text-decoration: none; font-weight: normal; font-size: 8.25pt"
            Me.Label46.Text = "Venta Asistida"
            Me.Label46.Top = 1.358901!
            Me.Label46.Width = 1.152559!
            '
            'Label47
            '
            Me.Label47.Height = 0.2!
            Me.Label47.HyperLink = Nothing
            Me.Label47.Left = 4.5625!
            Me.Label47.Name = "Label47"
            Me.Label47.Style = "text-decoration: none; font-weight: normal; font-size: 8.25pt"
            Me.Label47.Text = "Venta Si Hay"
            Me.Label47.Top = 1.546402!
            Me.Label47.Width = 1.152559!
            '
            'Label48
            '
            Me.Label48.Height = 0.3214998!
            Me.Label48.HyperLink = Nothing
            Me.Label48.Left = 4.5625!
            Me.Label48.Name = "Label48"
            Me.Label48.Style = "text-decoration: underline; font-weight: bold; font-style: normal; font-size: 8.2"& _ 
                "5pt"
            Me.Label48.Text = "GLOBAL VALE DE CAJA"
            Me.Label48.Top = 0.875!
            Me.Label48.Width = 1.152559!
            '
            'txtGlobalValeCaja
            '
            Me.txtGlobalValeCaja.Height = 0.2!
            Me.txtGlobalValeCaja.Left = 5.699803!
            Me.txtGlobalValeCaja.Name = "txtGlobalValeCaja"
            Me.txtGlobalValeCaja.OutputFormat = resources.GetString("txtGlobalValeCaja.OutputFormat")
            Me.txtGlobalValeCaja.Style = "text-align: right; font-weight: bold; font-size: 9pt"
            Me.txtGlobalValeCaja.Text = "$ 1,568,623.85"
            Me.txtGlobalValeCaja.Top = 0.875!
            Me.txtGlobalValeCaja.Width = 0.8902562!
            '
            'txtVcjaPG
            '
            Me.txtVcjaPG.Height = 0.2!
            Me.txtVcjaPG.Left = 5.699803!
            Me.txtVcjaPG.Name = "txtVcjaPG"
            Me.txtVcjaPG.OutputFormat = resources.GetString("txtVcjaPG.OutputFormat")
            Me.txtVcjaPG.Style = "text-decoration: none; text-align: right; font-weight: normal; font-size: 8.25pt"
            Me.txtVcjaPG.Text = "$ 0.00"
            Me.txtVcjaPG.Top = 1.171401!
            Me.txtVcjaPG.Width = 0.7652562!
            '
            'txtVtaSH
            '
            Me.txtVtaSH.Height = 0.2!
            Me.txtVtaSH.Left = 5.699803!
            Me.txtVtaSH.Name = "txtVtaSH"
            Me.txtVtaSH.OutputFormat = resources.GetString("txtVtaSH.OutputFormat")
            Me.txtVtaSH.Style = "text-decoration: none; text-align: right; font-weight: normal; font-size: 8.25pt"
            Me.txtVtaSH.Text = "$ 0.00"
            Me.txtVtaSH.Top = 1.546402!
            Me.txtVtaSH.Width = 0.7652562!
            '
            'txtVcjaVtaAsis
            '
            Me.txtVcjaVtaAsis.Height = 0.2!
            Me.txtVcjaVtaAsis.Left = 5.699803!
            Me.txtVcjaVtaAsis.Name = "txtVcjaVtaAsis"
            Me.txtVcjaVtaAsis.OutputFormat = resources.GetString("txtVcjaVtaAsis.OutputFormat")
            Me.txtVcjaVtaAsis.Style = "text-decoration: none; text-align: right; font-weight: normal; font-size: 8.25pt"
            Me.txtVcjaVtaAsis.Text = "$ 0.00"
            Me.txtVcjaVtaAsis.Top = 1.358901!
            Me.txtVcjaVtaAsis.Width = 0.7652562!
            '
            'Label49
            '
            Me.Label49.Height = 0.2!
            Me.Label49.HyperLink = Nothing
            Me.Label49.Left = 4.5625!
            Me.Label49.Name = "Label49"
            Me.Label49.Style = "text-decoration: none; font-weight: normal; font-size: 8.25pt"
            Me.Label49.Text = "Dips"
            Me.Label49.Top = 1.733902!
            Me.Label49.Width = 1.152559!
            '
            'Label51
            '
            Me.Label51.Height = 0.2!
            Me.Label51.HyperLink = Nothing
            Me.Label51.Left = 4.5625!
            Me.Label51.Name = "Label51"
            Me.Label51.Style = "text-decoration: none; font-weight: normal; font-size: 8.25pt"
            Me.Label51.Text = "Facturacion Fiscal"
            Me.Label51.Top = 1.921402!
            Me.Label51.Width = 1.152559!
            '
            'txtVcjaDips
            '
            Me.txtVcjaDips.Height = 0.2!
            Me.txtVcjaDips.Left = 5.699803!
            Me.txtVcjaDips.Name = "txtVcjaDips"
            Me.txtVcjaDips.OutputFormat = resources.GetString("txtVcjaDips.OutputFormat")
            Me.txtVcjaDips.Style = "text-decoration: none; text-align: right; font-weight: normal; font-size: 8.25pt"
            Me.txtVcjaDips.Text = "$ 100,883.25"
            Me.txtVcjaDips.Top = 1.733902!
            Me.txtVcjaDips.Width = 0.7652562!
            '
            'txtVcjaFF
            '
            Me.txtVcjaFF.Height = 0.2!
            Me.txtVcjaFF.Left = 5.7!
            Me.txtVcjaFF.Name = "txtVcjaFF"
            Me.txtVcjaFF.OutputFormat = resources.GetString("txtVcjaFF.OutputFormat")
            Me.txtVcjaFF.Style = "text-decoration: none; text-align: right; font-weight: normal; font-size: 8.25pt"
            Me.txtVcjaFF.Text = "$ 0.00"
            Me.txtVcjaFF.Top = 1.9215!
            Me.txtVcjaFF.Width = 0.7652562!
            '
            'Label52
            '
            Me.Label52.Height = 0.2!
            Me.Label52.HyperLink = Nothing
            Me.Label52.Left = 2.284941!
            Me.Label52.Name = "Label52"
            Me.Label52.Style = "text-decoration: none; font-weight: normal; font-size: 8.25pt"
            Me.Label52.Text = "DPVale"
            Me.Label52.Top = 3.412401!
            Me.Label52.Width = 1.152559!
            '
            'Label54
            '
            Me.Label54.Height = 0.2!
            Me.Label54.HyperLink = Nothing
            Me.Label54.Left = 2.284941!
            Me.Label54.Name = "Label54"
            Me.Label54.Style = "text-decoration: none; font-weight: normal; font-size: 8.25pt"
            Me.Label54.Text = "Venta Si Hay"
            Me.Label54.Top = 3.599901!
            Me.Label54.Width = 1.152559!
            '
            'Label55
            '
            Me.Label55.Height = 0.2!
            Me.Label55.HyperLink = Nothing
            Me.Label55.Left = 2.284941!
            Me.Label55.Name = "Label55"
            Me.Label55.Style = "text-decoration: underline; font-weight: bold; font-style: normal; font-size: 8.2"& _ 
                "5pt"
            Me.Label55.Text = "GLOBAL DPVALE"
            Me.Label55.Top = 3.1785!
            Me.Label55.Width = 1.152559!
            '
            'txtGlobalDPVale
            '
            Me.txtGlobalDPVale.Height = 0.2!
            Me.txtGlobalDPVale.Left = 3.422244!
            Me.txtGlobalDPVale.Name = "txtGlobalDPVale"
            Me.txtGlobalDPVale.OutputFormat = resources.GetString("txtGlobalDPVale.OutputFormat")
            Me.txtGlobalDPVale.Style = "text-align: right; font-weight: bold; font-size: 9pt"
            Me.txtGlobalDPVale.Text = "$ 1,568,623.85"
            Me.txtGlobalDPVale.Top = 3.1785!
            Me.txtGlobalDPVale.Width = 0.8902562!
            '
            'txtDpvlDPVL
            '
            Me.txtDpvlDPVL.Height = 0.2!
            Me.txtDpvlDPVL.Left = 3.422244!
            Me.txtDpvlDPVL.Name = "txtDpvlDPVL"
            Me.txtDpvlDPVL.OutputFormat = resources.GetString("txtDpvlDPVL.OutputFormat")
            Me.txtDpvlDPVL.Style = "text-decoration: none; text-align: right; font-weight: normal; font-size: 8.25pt"
            Me.txtDpvlDPVL.Text = "$ 0.00"
            Me.txtDpvlDPVL.Top = 3.412401!
            Me.txtDpvlDPVL.Width = 0.7652562!
            '
            'txtDpvlSH
            '
            Me.txtDpvlSH.Height = 0.2!
            Me.txtDpvlSH.Left = 3.422244!
            Me.txtDpvlSH.Name = "txtDpvlSH"
            Me.txtDpvlSH.OutputFormat = resources.GetString("txtDpvlSH.OutputFormat")
            Me.txtDpvlSH.Style = "text-decoration: none; text-align: right; font-weight: normal; font-size: 8.25pt"
            Me.txtDpvlSH.Text = "$ 0.00"
            Me.txtDpvlSH.Top = 3.599901!
            Me.txtDpvlSH.Width = 0.7652562!
            '
            'Label56
            '
            Me.Label56.Height = 0.2!
            Me.Label56.HyperLink = Nothing
            Me.Label56.Left = 4.53494!
            Me.Label56.Name = "Label56"
            Me.Label56.Style = "text-decoration: none; font-weight: normal; font-size: 8.25pt"
            Me.Label56.Text = "Facilito"
            Me.Label56.Top = 3.412401!
            Me.Label56.Width = 1.152559!
            '
            'Label58
            '
            Me.Label58.Height = 0.2!
            Me.Label58.HyperLink = Nothing
            Me.Label58.Left = 4.53494!
            Me.Label58.Name = "Label58"
            Me.Label58.Style = "text-decoration: underline; font-weight: bold; font-style: normal; font-size: 8.2"& _ 
                "5pt"
            Me.Label58.Text = "GLOBAL FACILITO"
            Me.Label58.Top = 3.1785!
            Me.Label58.Width = 1.152559!
            '
            'txtGlobalFacilito
            '
            Me.txtGlobalFacilito.Height = 0.2!
            Me.txtGlobalFacilito.Left = 5.672244!
            Me.txtGlobalFacilito.Name = "txtGlobalFacilito"
            Me.txtGlobalFacilito.OutputFormat = resources.GetString("txtGlobalFacilito.OutputFormat")
            Me.txtGlobalFacilito.Style = "text-align: right; font-weight: bold; font-size: 9pt"
            Me.txtGlobalFacilito.Text = "$ 1,568,623.85"
            Me.txtGlobalFacilito.Top = 3.1785!
            Me.txtGlobalFacilito.Width = 0.8902562!
            '
            'txtFacilito
            '
            Me.txtFacilito.Height = 0.2!
            Me.txtFacilito.Left = 5.672244!
            Me.txtFacilito.Name = "txtFacilito"
            Me.txtFacilito.OutputFormat = resources.GetString("txtFacilito.OutputFormat")
            Me.txtFacilito.Style = "text-decoration: none; text-align: right; font-weight: normal; font-size: 8.25pt"
            Me.txtFacilito.Text = "$ 0.00"
            Me.txtFacilito.Top = 3.412401!
            Me.txtFacilito.Width = 0.7652562!
            '
            'Label59
            '
            Me.Label59.Height = 0.2!
            Me.Label59.HyperLink = Nothing
            Me.Label59.Left = 3.875!
            Me.Label59.Name = "Label59"
            Me.Label59.Style = "font-weight: bold; font-size: 8.25pt"
            Me.Label59.Text = "FACTURAS CANCELADAS:"
            Me.Label59.Top = 5.847441!
            Me.Label59.Width = 1.590059!
            '
            'txtFacturasCanceladas
            '
            Me.txtFacturasCanceladas.Height = 0.2!
            Me.txtFacturasCanceladas.Left = 5.449802!
            Me.txtFacturasCanceladas.Name = "txtFacturasCanceladas"
            Me.txtFacturasCanceladas.OutputFormat = resources.GetString("txtFacturasCanceladas.OutputFormat")
            Me.txtFacturasCanceladas.Style = "text-align: center; font-weight: bold; font-size: 9.75pt"
            Me.txtFacturasCanceladas.Text = "0"
            Me.txtFacturasCanceladas.Top = 5.847441!
            Me.txtFacturasCanceladas.Width = 1.181102!
            '
            'Label60
            '
            Me.Label60.Height = 0.2!
            Me.Label60.HyperLink = Nothing
            Me.Label60.Left = 0.03494096!
            Me.Label60.Name = "Label60"
            Me.Label60.Style = "text-decoration: none; font-weight: normal; font-size: 8.25pt"
            Me.Label60.Text = "Fonacot"
            Me.Label60.Top = 2.224901!
            Me.Label60.Width = 1.152559!
            '
            'txtEfecFONA
            '
            Me.txtEfecFONA.Height = 0.2!
            Me.txtEfecFONA.Left = 1.172244!
            Me.txtEfecFONA.Name = "txtEfecFONA"
            Me.txtEfecFONA.OutputFormat = resources.GetString("txtEfecFONA.OutputFormat")
            Me.txtEfecFONA.Style = "text-decoration: none; text-align: right; font-weight: normal; font-size: 8.25pt"
            Me.txtEfecFONA.Text = "$ 0.00"
            Me.txtEfecFONA.Top = 2.224901!
            Me.txtEfecFONA.Width = 0.7652562!
            '
            'Label61
            '
            Me.Label61.Height = 0.2!
            Me.Label61.HyperLink = Nothing
            Me.Label61.Left = 0.03494096!
            Me.Label61.Name = "Label61"
            Me.Label61.Style = "text-decoration: none; font-weight: normal; font-size: 8.25pt"
            Me.Label61.Text = "Facilito"
            Me.Label61.Top = 2.412401!
            Me.Label61.Width = 1.152559!
            '
            'txtEfecFACI
            '
            Me.txtEfecFACI.Height = 0.2!
            Me.txtEfecFACI.Left = 1.172244!
            Me.txtEfecFACI.Name = "txtEfecFACI"
            Me.txtEfecFACI.OutputFormat = resources.GetString("txtEfecFACI.OutputFormat")
            Me.txtEfecFACI.Style = "text-decoration: none; text-align: right; font-weight: normal; font-size: 8.25pt"
            Me.txtEfecFACI.Text = "$ 0.00"
            Me.txtEfecFACI.Top = 2.412401!
            Me.txtEfecFACI.Width = 0.7652562!
            '
            'Label62
            '
            Me.Label62.Height = 0.2!
            Me.Label62.HyperLink = Nothing
            Me.Label62.Left = 0.03494096!
            Me.Label62.Name = "Label62"
            Me.Label62.Style = "text-decoration: none; font-weight: normal; font-size: 8.25pt"
            Me.Label62.Text = "DPVale"
            Me.Label62.Top = 2.599901!
            Me.Label62.Width = 1.152559!
            '
            'txtEfecDPVL
            '
            Me.txtEfecDPVL.Height = 0.2!
            Me.txtEfecDPVL.Left = 1.172244!
            Me.txtEfecDPVL.Name = "txtEfecDPVL"
            Me.txtEfecDPVL.OutputFormat = resources.GetString("txtEfecDPVL.OutputFormat")
            Me.txtEfecDPVL.Style = "text-decoration: none; text-align: right; font-weight: normal; font-size: 8.25pt"
            Me.txtEfecDPVL.Text = "$ 0.00"
            Me.txtEfecDPVL.Top = 2.599901!
            Me.txtEfecDPVL.Width = 0.7652562!
            '
            'Label63
            '
            Me.Label63.Height = 0.2!
            Me.Label63.HyperLink = Nothing
            Me.Label63.Left = 0.03494096!
            Me.Label63.Name = "Label63"
            Me.Label63.Style = "text-decoration: none; font-weight: normal; font-size: 8.25pt"
            Me.Label63.Text = "Empleado"
            Me.Label63.Top = 2.787401!
            Me.Label63.Width = 1.152559!
            '
            'txtEfecEMP
            '
            Me.txtEfecEMP.Height = 0.2!
            Me.txtEfecEMP.Left = 1.172244!
            Me.txtEfecEMP.Name = "txtEfecEMP"
            Me.txtEfecEMP.OutputFormat = resources.GetString("txtEfecEMP.OutputFormat")
            Me.txtEfecEMP.Style = "text-decoration: none; text-align: right; font-weight: normal; font-size: 8.25pt"
            Me.txtEfecEMP.Text = "$ 0.00"
            Me.txtEfecEMP.Top = 2.787401!
            Me.txtEfecEMP.Width = 0.7652562!
            '
            'Label64
            '
            Me.Label64.Height = 0.2!
            Me.Label64.HyperLink = Nothing
            Me.Label64.Left = 2.284941!
            Me.Label64.Name = "Label64"
            Me.Label64.Style = "text-decoration: none; font-weight: normal; font-size: 8.25pt"
            Me.Label64.Text = "Fonacot"
            Me.Label64.Top = 2.224901!
            Me.Label64.Width = 1.152559!
            '
            'txtTarjFONA
            '
            Me.txtTarjFONA.Height = 0.2!
            Me.txtTarjFONA.Left = 3.438!
            Me.txtTarjFONA.Name = "txtTarjFONA"
            Me.txtTarjFONA.OutputFormat = resources.GetString("txtTarjFONA.OutputFormat")
            Me.txtTarjFONA.Style = "text-decoration: none; text-align: right; font-weight: normal; font-size: 8.25pt"
            Me.txtTarjFONA.Text = "$ 0.00"
            Me.txtTarjFONA.Top = 2.225!
            Me.txtTarjFONA.Width = 0.765!
            '
            'Label65
            '
            Me.Label65.Height = 0.2!
            Me.Label65.HyperLink = Nothing
            Me.Label65.Left = 2.284941!
            Me.Label65.Name = "Label65"
            Me.Label65.Style = "text-decoration: none; font-weight: normal; font-size: 8.25pt"
            Me.Label65.Text = "Facilito"
            Me.Label65.Top = 2.412401!
            Me.Label65.Width = 1.152559!
            '
            'txtTarjFACI
            '
            Me.txtTarjFACI.Height = 0.2!
            Me.txtTarjFACI.Left = 3.4375!
            Me.txtTarjFACI.Name = "txtTarjFACI"
            Me.txtTarjFACI.OutputFormat = resources.GetString("txtTarjFACI.OutputFormat")
            Me.txtTarjFACI.Style = "text-decoration: none; text-align: right; font-weight: normal; font-size: 8.25pt"
            Me.txtTarjFACI.Text = "$ 0.00"
            Me.txtTarjFACI.Top = 2.412401!
            Me.txtTarjFACI.Width = 0.765!
            '
            'Label66
            '
            Me.Label66.Height = 0.2!
            Me.Label66.HyperLink = Nothing
            Me.Label66.Left = 2.284941!
            Me.Label66.Name = "Label66"
            Me.Label66.Style = "text-decoration: none; font-weight: normal; font-size: 8.25pt"
            Me.Label66.Text = "DPVale"
            Me.Label66.Top = 2.599901!
            Me.Label66.Width = 1.152559!
            '
            'txtTarjDPVL
            '
            Me.txtTarjDPVL.Height = 0.2!
            Me.txtTarjDPVL.Left = 3.4375!
            Me.txtTarjDPVL.Name = "txtTarjDPVL"
            Me.txtTarjDPVL.OutputFormat = resources.GetString("txtTarjDPVL.OutputFormat")
            Me.txtTarjDPVL.Style = "text-decoration: none; text-align: right; font-weight: normal; font-size: 8.25pt"
            Me.txtTarjDPVL.Text = "$ 0.00"
            Me.txtTarjDPVL.Top = 2.599901!
            Me.txtTarjDPVL.Width = 0.765!
            '
            'Label67
            '
            Me.Label67.Height = 0.2!
            Me.Label67.HyperLink = Nothing
            Me.Label67.Left = 2.284941!
            Me.Label67.Name = "Label67"
            Me.Label67.Style = "text-decoration: none; font-weight: normal; font-size: 8.25pt"
            Me.Label67.Text = "Empleado"
            Me.Label67.Top = 2.787401!
            Me.Label67.Width = 1.152559!
            '
            'txtTarjEMP
            '
            Me.txtTarjEMP.Height = 0.2!
            Me.txtTarjEMP.Left = 3.4375!
            Me.txtTarjEMP.Name = "txtTarjEMP"
            Me.txtTarjEMP.OutputFormat = resources.GetString("txtTarjEMP.OutputFormat")
            Me.txtTarjEMP.Style = "text-decoration: none; text-align: right; font-weight: normal; font-size: 8.25pt"
            Me.txtTarjEMP.Text = "$ 0.00"
            Me.txtTarjEMP.Top = 2.787401!
            Me.txtTarjEMP.Width = 0.765!
            '
            'Label68
            '
            Me.Label68.Height = 0.2!
            Me.Label68.HyperLink = Nothing
            Me.Label68.Left = 4.5625!
            Me.Label68.Name = "Label68"
            Me.Label68.Style = "text-decoration: none; font-weight: normal; font-size: 8.25pt"
            Me.Label68.Text = "Fonacot"
            Me.Label68.Top = 2.108902!
            Me.Label68.Width = 1.152559!
            '
            'txtVcjaFONA
            '
            Me.txtVcjaFONA.Height = 0.2!
            Me.txtVcjaFONA.Left = 5.7!
            Me.txtVcjaFONA.Name = "txtVcjaFONA"
            Me.txtVcjaFONA.OutputFormat = resources.GetString("txtVcjaFONA.OutputFormat")
            Me.txtVcjaFONA.Style = "text-decoration: none; text-align: right; font-weight: normal; font-size: 8.25pt"
            Me.txtVcjaFONA.Text = "$ 0.00"
            Me.txtVcjaFONA.Top = 2.1085!
            Me.txtVcjaFONA.Width = 0.7652562!
            '
            'Label69
            '
            Me.Label69.Height = 0.2!
            Me.Label69.HyperLink = Nothing
            Me.Label69.Left = 4.5625!
            Me.Label69.Name = "Label69"
            Me.Label69.Style = "text-decoration: none; font-weight: normal; font-size: 8.25pt"
            Me.Label69.Text = "Facilito"
            Me.Label69.Top = 2.296402!
            Me.Label69.Width = 1.152559!
            '
            'txtVcjaFACI
            '
            Me.txtVcjaFACI.Height = 0.2!
            Me.txtVcjaFACI.Left = 5.699803!
            Me.txtVcjaFACI.Name = "txtVcjaFACI"
            Me.txtVcjaFACI.OutputFormat = resources.GetString("txtVcjaFACI.OutputFormat")
            Me.txtVcjaFACI.Style = "text-decoration: none; text-align: right; font-weight: normal; font-size: 8.25pt"
            Me.txtVcjaFACI.Text = "$ 0.00"
            Me.txtVcjaFACI.Top = 2.296402!
            Me.txtVcjaFACI.Width = 0.7652562!
            '
            'Label70
            '
            Me.Label70.Height = 0.2!
            Me.Label70.HyperLink = Nothing
            Me.Label70.Left = 4.5625!
            Me.Label70.Name = "Label70"
            Me.Label70.Style = "text-decoration: none; font-weight: normal; font-size: 8.25pt"
            Me.Label70.Text = "DPVale"
            Me.Label70.Top = 2.483902!
            Me.Label70.Width = 1.152559!
            '
            'txtVcjaDPVL
            '
            Me.txtVcjaDPVL.Height = 0.2!
            Me.txtVcjaDPVL.Left = 5.699803!
            Me.txtVcjaDPVL.Name = "txtVcjaDPVL"
            Me.txtVcjaDPVL.OutputFormat = resources.GetString("txtVcjaDPVL.OutputFormat")
            Me.txtVcjaDPVL.Style = "text-decoration: none; text-align: right; font-weight: normal; font-size: 8.25pt"
            Me.txtVcjaDPVL.Text = "$ 0.00"
            Me.txtVcjaDPVL.Top = 2.483902!
            Me.txtVcjaDPVL.Width = 0.7652562!
            '
            'Label71
            '
            Me.Label71.Height = 0.2!
            Me.Label71.HyperLink = Nothing
            Me.Label71.Left = 4.5625!
            Me.Label71.Name = "Label71"
            Me.Label71.Style = "text-decoration: none; font-weight: normal; font-size: 8.25pt"
            Me.Label71.Text = "Empleado"
            Me.Label71.Top = 2.671402!
            Me.Label71.Width = 1.152559!
            '
            'txtVcjaEMP
            '
            Me.txtVcjaEMP.Height = 0.2!
            Me.txtVcjaEMP.Left = 5.699803!
            Me.txtVcjaEMP.Name = "txtVcjaEMP"
            Me.txtVcjaEMP.OutputFormat = resources.GetString("txtVcjaEMP.OutputFormat")
            Me.txtVcjaEMP.Style = "text-decoration: none; text-align: right; font-weight: normal; font-size: 8.25pt"
            Me.txtVcjaEMP.Text = "$ 0.00"
            Me.txtVcjaEMP.Top = 2.671402!
            Me.txtVcjaEMP.Width = 0.7652562!
            '
            'txtFechaHora
            '
            Me.txtFechaHora.Height = 0.2!
            Me.txtFechaHora.Left = 5.25!
            Me.txtFechaHora.Name = "txtFechaHora"
            Me.txtFechaHora.Style = "text-align: right; font-size: 8.25pt"
            Me.txtFechaHora.Text = "TextBox1"
            Me.txtFechaHora.Top = 0.07874014!
            Me.txtFechaHora.Width = 1.375!
            '
            'Label72
            '
            Me.Label72.Height = 0.2!
            Me.Label72.HyperLink = Nothing
            Me.Label72.Left = 0.0625!
            Me.Label72.Name = "Label72"
            Me.Label72.Style = "text-decoration: none; font-weight: normal; font-size: 8.25pt"
            Me.Label72.Text = "Público en General"
            Me.Label72.Top = 4.171401!
            Me.Label72.Width = 1.152559!
            '
            'Label73
            '
            Me.Label73.Height = 0.2!
            Me.Label73.HyperLink = Nothing
            Me.Label73.Left = 0.0625!
            Me.Label73.Name = "Label73"
            Me.Label73.Style = "text-decoration: none; font-weight: normal; font-size: 8.25pt"
            Me.Label73.Text = "Venta Asistida"
            Me.Label73.Top = 4.358901!
            Me.Label73.Width = 1.152559!
            '
            'Label74
            '
            Me.Label74.Height = 0.2!
            Me.Label74.HyperLink = Nothing
            Me.Label74.Left = 0.0625!
            Me.Label74.Name = "Label74"
            Me.Label74.Style = "text-decoration: none; font-weight: normal; font-size: 8.25pt"
            Me.Label74.Text = "Venta Si Hay"
            Me.Label74.Top = 4.546401!
            Me.Label74.Width = 1.152559!
            '
            'Label75
            '
            Me.Label75.Height = 0.2!
            Me.Label75.HyperLink = Nothing
            Me.Label75.Left = 0.0625!
            Me.Label75.Name = "Label75"
            Me.Label75.Style = "text-decoration: underline; font-weight: bold; font-style: normal; font-size: 8.2"& _ 
                "5pt"
            Me.Label75.Text = "GLOBAL DPCARD"
            Me.Label75.Top = 3.9375!
            Me.Label75.Width = 1.153!
            '
            'txtGlobalDPCA
            '
            Me.txtGlobalDPCA.Height = 0.2!
            Me.txtGlobalDPCA.Left = 1.1875!
            Me.txtGlobalDPCA.Name = "txtGlobalDPCA"
            Me.txtGlobalDPCA.OutputFormat = resources.GetString("txtGlobalDPCA.OutputFormat")
            Me.txtGlobalDPCA.Style = "text-align: right; font-weight: bold; font-size: 9pt"
            Me.txtGlobalDPCA.Text = "$ 0.00"
            Me.txtGlobalDPCA.Top = 3.9375!
            Me.txtGlobalDPCA.Width = 0.89!
            '
            'txtDPCAPGral
            '
            Me.txtDPCAPGral.Height = 0.2!
            Me.txtDPCAPGral.Left = 1.199803!
            Me.txtDPCAPGral.Name = "txtDPCAPGral"
            Me.txtDPCAPGral.OutputFormat = resources.GetString("txtDPCAPGral.OutputFormat")
            Me.txtDPCAPGral.Style = "text-decoration: none; text-align: right; font-weight: normal; font-size: 8.25pt"
            Me.txtDPCAPGral.Text = "$ 0.00"
            Me.txtDPCAPGral.Top = 4.171401!
            Me.txtDPCAPGral.Width = 0.765!
            '
            'txtDPCAVtaSH
            '
            Me.txtDPCAVtaSH.Height = 0.2!
            Me.txtDPCAVtaSH.Left = 1.199803!
            Me.txtDPCAVtaSH.Name = "txtDPCAVtaSH"
            Me.txtDPCAVtaSH.OutputFormat = resources.GetString("txtDPCAVtaSH.OutputFormat")
            Me.txtDPCAVtaSH.Style = "text-decoration: none; text-align: right; font-weight: normal; font-size: 8.25pt"
            Me.txtDPCAVtaSH.Text = "$ 0.00"
            Me.txtDPCAVtaSH.Top = 4.546401!
            Me.txtDPCAVtaSH.Width = 0.765!
            '
            'txtDPCAVtaAsis
            '
            Me.txtDPCAVtaAsis.Height = 0.2!
            Me.txtDPCAVtaAsis.Left = 1.199803!
            Me.txtDPCAVtaAsis.Name = "txtDPCAVtaAsis"
            Me.txtDPCAVtaAsis.OutputFormat = resources.GetString("txtDPCAVtaAsis.OutputFormat")
            Me.txtDPCAVtaAsis.Style = "text-decoration: none; text-align: right; font-weight: normal; font-size: 8.25pt"
            Me.txtDPCAVtaAsis.Text = "$ 0.00"
            Me.txtDPCAVtaAsis.Top = 4.358901!
            Me.txtDPCAVtaAsis.Width = 0.765!
            '
            'Label76
            '
            Me.Label76.Height = 0.2!
            Me.Label76.HyperLink = Nothing
            Me.Label76.Left = 0.0625!
            Me.Label76.Name = "Label76"
            Me.Label76.Style = "text-decoration: none; font-weight: normal; font-size: 8.25pt"
            Me.Label76.Text = "Dips"
            Me.Label76.Top = 4.733901!
            Me.Label76.Width = 1.152559!
            '
            'Label77
            '
            Me.Label77.Height = 0.2!
            Me.Label77.HyperLink = Nothing
            Me.Label77.Left = 0.0625!
            Me.Label77.Name = "Label77"
            Me.Label77.Style = "text-decoration: none; font-weight: normal; font-size: 8.25pt"
            Me.Label77.Text = "Abonos de Apartado"
            Me.Label77.Top = 4.921401!
            Me.Label77.Width = 1.152559!
            '
            'Label78
            '
            Me.Label78.Height = 0.2!
            Me.Label78.HyperLink = Nothing
            Me.Label78.Left = 0.0625!
            Me.Label78.Name = "Label78"
            Me.Label78.Style = "text-decoration: none; font-weight: normal; font-size: 8.25pt"
            Me.Label78.Text = "Facturacion Fiscal"
            Me.Label78.Top = 5.108901!
            Me.Label78.Width = 1.152559!
            '
            'txtDPCADips
            '
            Me.txtDPCADips.Height = 0.2!
            Me.txtDPCADips.Left = 1.199803!
            Me.txtDPCADips.Name = "txtDPCADips"
            Me.txtDPCADips.OutputFormat = resources.GetString("txtDPCADips.OutputFormat")
            Me.txtDPCADips.Style = "text-decoration: none; text-align: right; font-weight: normal; font-size: 8.25pt"
            Me.txtDPCADips.Text = "$ 0.00"
            Me.txtDPCADips.Top = 4.733901!
            Me.txtDPCADips.Width = 0.765!
            '
            'txtDPCAFF
            '
            Me.txtDPCAFF.Height = 0.2!
            Me.txtDPCAFF.Left = 1.215059!
            Me.txtDPCAFF.Name = "txtDPCAFF"
            Me.txtDPCAFF.OutputFormat = resources.GetString("txtDPCAFF.OutputFormat")
            Me.txtDPCAFF.Style = "text-decoration: none; text-align: right; font-weight: normal; font-size: 8.25pt"
            Me.txtDPCAFF.Text = "$ 0.00"
            Me.txtDPCAFF.Top = 5.108499!
            Me.txtDPCAFF.Width = 0.765!
            '
            'txtDPCAAbonos
            '
            Me.txtDPCAAbonos.Height = 0.2!
            Me.txtDPCAAbonos.Left = 1.199803!
            Me.txtDPCAAbonos.Name = "txtDPCAAbonos"
            Me.txtDPCAAbonos.OutputFormat = resources.GetString("txtDPCAAbonos.OutputFormat")
            Me.txtDPCAAbonos.Style = "text-decoration: none; text-align: right; font-weight: normal; font-size: 8.25pt"
            Me.txtDPCAAbonos.Text = "$ 0.00"
            Me.txtDPCAAbonos.Top = 4.921401!
            Me.txtDPCAAbonos.Width = 0.765!
            '
            'Label79
            '
            Me.Label79.Height = 0.2!
            Me.Label79.HyperLink = Nothing
            Me.Label79.Left = 0.0625!
            Me.Label79.Name = "Label79"
            Me.Label79.Style = "text-decoration: none; font-weight: normal; font-size: 8.25pt"
            Me.Label79.Text = "Fonacot"
            Me.Label79.Top = 5.296401!
            Me.Label79.Width = 1.152559!
            '
            'txtDPCAFONA
            '
            Me.txtDPCAFONA.Height = 0.2!
            Me.txtDPCAFONA.Left = 1.215559!
            Me.txtDPCAFONA.Name = "txtDPCAFONA"
            Me.txtDPCAFONA.OutputFormat = resources.GetString("txtDPCAFONA.OutputFormat")
            Me.txtDPCAFONA.Style = "text-decoration: none; text-align: right; font-weight: normal; font-size: 8.25pt"
            Me.txtDPCAFONA.Text = "$ 0.00"
            Me.txtDPCAFONA.Top = 5.296499!
            Me.txtDPCAFONA.Width = 0.765!
            '
            'Label80
            '
            Me.Label80.Height = 0.2!
            Me.Label80.HyperLink = Nothing
            Me.Label80.Left = 0.0625!
            Me.Label80.Name = "Label80"
            Me.Label80.Style = "text-decoration: none; font-weight: normal; font-size: 8.25pt"
            Me.Label80.Text = "Facilito"
            Me.Label80.Top = 5.483901!
            Me.Label80.Width = 1.152559!
            '
            'txtDPCAFACI
            '
            Me.txtDPCAFACI.Height = 0.2!
            Me.txtDPCAFACI.Left = 1.215059!
            Me.txtDPCAFACI.Name = "txtDPCAFACI"
            Me.txtDPCAFACI.OutputFormat = resources.GetString("txtDPCAFACI.OutputFormat")
            Me.txtDPCAFACI.Style = "text-decoration: none; text-align: right; font-weight: normal; font-size: 8.25pt"
            Me.txtDPCAFACI.Text = "$ 0.00"
            Me.txtDPCAFACI.Top = 5.483901!
            Me.txtDPCAFACI.Width = 0.765!
            '
            'Label81
            '
            Me.Label81.Height = 0.2!
            Me.Label81.HyperLink = Nothing
            Me.Label81.Left = 0.0625!
            Me.Label81.Name = "Label81"
            Me.Label81.Style = "text-decoration: none; font-weight: normal; font-size: 8.25pt"
            Me.Label81.Text = "DPVale"
            Me.Label81.Top = 5.671401!
            Me.Label81.Width = 1.152559!
            '
            'txtDPCADPVL
            '
            Me.txtDPCADPVL.Height = 0.2!
            Me.txtDPCADPVL.Left = 1.215059!
            Me.txtDPCADPVL.Name = "txtDPCADPVL"
            Me.txtDPCADPVL.OutputFormat = resources.GetString("txtDPCADPVL.OutputFormat")
            Me.txtDPCADPVL.Style = "text-decoration: none; text-align: right; font-weight: normal; font-size: 8.25pt"
            Me.txtDPCADPVL.Text = "$ 0.00"
            Me.txtDPCADPVL.Top = 5.671401!
            Me.txtDPCADPVL.Width = 0.765!
            '
            'Label82
            '
            Me.Label82.Height = 0.2!
            Me.Label82.HyperLink = Nothing
            Me.Label82.Left = 0.0625!
            Me.Label82.Name = "Label82"
            Me.Label82.Style = "text-decoration: none; font-weight: normal; font-size: 8.25pt"
            Me.Label82.Text = "Empleado"
            Me.Label82.Top = 5.858901!
            Me.Label82.Width = 1.152559!
            '
            'txtDPCAEMP
            '
            Me.txtDPCAEMP.Height = 0.2!
            Me.txtDPCAEMP.Left = 1.215059!
            Me.txtDPCAEMP.Name = "txtDPCAEMP"
            Me.txtDPCAEMP.OutputFormat = resources.GetString("txtDPCAEMP.OutputFormat")
            Me.txtDPCAEMP.Style = "text-decoration: none; text-align: right; font-weight: normal; font-size: 8.25pt"
            Me.txtDPCAEMP.Text = "$ 0.00"
            Me.txtDPCAEMP.Top = 5.858901!
            Me.txtDPCAEMP.Width = 0.765!
            '
            'txtNoPag
            '
            Me.txtNoPag.Height = 0.1875!
            Me.txtNoPag.Left = 6.125!
            Me.txtNoPag.Name = "txtNoPag"
            Me.txtNoPag.Style = "text-align: right"
            Me.txtNoPag.Text = "Pag. 1"
            Me.txtNoPag.Top = 0!
            Me.txtNoPag.Width = 0.5!
            '
            'ActiveReport1
            '
            Me.MasterReport = false
            Me.PageSettings.PaperHeight = 11!
            Me.PageSettings.PaperWidth = 8.5!
            Me.PrintWidth = 6.708333!
            Me.Sections.Add(Me.PageHeader)
            Me.Sections.Add(Me.Detail)
            Me.Sections.Add(Me.PageFooter)
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo"& _ 
                        "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit", "Heading1", "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei"& _ 
                        "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit", "Heading2", "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo"& _ 
                        "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit", "Heading3", "Normal"))
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFecha,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label3,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtAlmacen,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label1,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtRetiros,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label5,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtTotalFacturado,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label6,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFacturasActivas,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label20,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label21,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label22,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label27,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtGlobalEfectivo,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtEfecPGral,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtEfecVtaSH,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtEfecVtaAsis,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label28,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label29,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label30,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtEfecDips,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtEfecFF,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtEfecAbonos,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label31,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label32,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label33,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label34,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtGlobalTarjeta,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtTarjPGral,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtTarjVtaSH,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtTarjVtaAsis,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label35,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label36,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label37,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtTarjDips,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtTarjFF,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtTarjAbonos,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label38,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label41,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtGlobalFonacot,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFonacot,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label45,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label46,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label47,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label48,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtGlobalValeCaja,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtVcjaPG,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtVtaSH,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtVcjaVtaAsis,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label49,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label51,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtVcjaDips,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtVcjaFF,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label52,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label54,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label55,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtGlobalDPVale,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtDpvlDPVL,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtDpvlSH,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label56,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label58,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtGlobalFacilito,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFacilito,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label59,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFacturasCanceladas,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label60,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtEfecFONA,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label61,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtEfecFACI,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label62,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtEfecDPVL,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label63,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtEfecEMP,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label64,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtTarjFONA,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label65,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtTarjFACI,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label66,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtTarjDPVL,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label67,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtTarjEMP,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label68,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtVcjaFONA,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label69,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtVcjaFACI,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label70,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtVcjaDPVL,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label71,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtVcjaEMP,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFechaHora,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label72,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label73,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label74,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label75,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtGlobalDPCA,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtDPCAPGral,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtDPCAVtaSH,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtDPCAVtaAsis,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label76,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label77,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label78,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtDPCADips,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtDPCAFF,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtDPCAAbonos,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label79,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtDPCAFONA,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label80,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtDPCAFACI,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label81,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtDPCADPVL,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label82,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtDPCAEMP,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtNoPag,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        
	End Sub

#End Region

    Private Sub PageFooter_BeforePrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles PageFooter.BeforePrint
        Me.txtNoPag.Text = "Pag. " & Me.PageNumber
    End Sub

End Class
