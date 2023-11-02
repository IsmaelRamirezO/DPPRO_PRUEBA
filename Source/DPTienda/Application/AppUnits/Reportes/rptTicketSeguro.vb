Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Public Class rptTicketSeguro
    Inherits DataDynamics.ActiveReports.ActiveReport
    Public Sub New(ByVal htDatosTicket As Hashtable)
        MyBase.New()
        InitializeComponent()


        txtPlaza.Text = htDatosTicket("Plaza")
        txtCiudad.Text = htDatosTicket("Ciudad")
        txtDireccion.Text = htDatosTicket("Direccion")

        txtCaja.Text = htDatosTicket("Caja")

        txtFecha.Text = Date.Now.ToShortDateString
        txtHora.Text = Format(Date.Now, "HH:mm:ss")

        txtAseguradora.Text = htDatosTicket("Aseguradora")

        txtNoCanjeante.Text = htDatosTicket("NoCanjeante")
        txtCanjeante.Text = htDatosTicket("Canjeante")

        txtRFC.Text = htDatosTicket("RFC")
        txtSexo.Text = htDatosTicket("Sexo")
        Dim leyenda As String = Me.lblLeyendaSeguro.Text.Trim()
        leyenda = leyenda.Replace("{0}", "$" & CDec(htDatosTicket("ImporteSeguroQuin")).ToString("##,##0.00"))
        leyenda = leyenda.Replace("{1}", "$" & CDec(htDatosTicket("ImporteSeguro")).ToString("##,##0.00"))
        leyenda = leyenda.Replace("{2}", "$" & CDec(htDatosTicket("MontoSeguro")).ToString("##,##0.00"))
        leyenda = leyenda.Replace("{3}", CDate(htDatosTicket("FechaInicio")).ToString("dd/MM/yyyy"))
        leyenda = leyenda.Replace("{4}", CDate(htDatosTicket("FechaFin")).ToString("dd/MM/yyyy"))
        Me.lblLeyendaSeguro.Text = leyenda
        'txtImporteFinanciamiento.Text = CStr(htDatosTicket("ImporteSeguro")) & ","
        ''txtImporteFinanciamiento.Text = htDatosTicket("ImporteFin") & ","
        'txtMontoSeguro.Text = htDatosTicket("MontoSeguro")
        'txtVigencia.Text = Format(CDate(htDatosTicket("Vigencia")), "dd/MM/yyyy") ' & "."
        txtNoPoliza.Text = htDatosTicket("NoPoliza")
        txtBeneficiarios.Text = htDatosTicket("Beneficiarios")
        txtDireccionFinanciador.Text = htDatosTicket("DireccionFinanciador")
        txtTelefonoFinanciador.Text = htDatosTicket("TelefonoFinanciador") & ","
        txtTelefonoInformacion.Text = htDatosTicket("TelefonoInformacion")
        txtAseguradora2.Text = htDatosTicket("Aseguradora2") & ","
        txtDireccionFinanciador2.Text = htDatosTicket("DireccionFinanciador")


    End Sub
#Region "ActiveReports Designer generated code"
    Private WithEvents PageHeader As PageHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents PageFooter As PageFooter = Nothing
    Private Label23 As Label = Nothing
	Private Label3 As Label = Nothing
	Private Label4 As Label = Nothing
	Private txtFecha As TextBox = Nothing
	Private Label5 As Label = Nothing
	Private txtCaja As TextBox = Nothing
	Private Label6 As Label = Nothing
	Private txtHora As TextBox = Nothing
	Private lblLeyenda1 As Label = Nothing
	Private lblLeyenda2 As Label = Nothing
	Private txtAseguradora As TextBox = Nothing
	Private Label7 As Label = Nothing
	Private txtNoCanjeante As TextBox = Nothing
	Private Label8 As Label = Nothing
	Private txtCanjeante As TextBox = Nothing
	Private Label9 As Label = Nothing
	Private txtRFC As TextBox = Nothing
	Private txtSexo As TextBox = Nothing
	Private Label10 As Label = Nothing
    Private Label18 As Label = Nothing
	Private Label19 As Label = Nothing
	Private txtNoPoliza As TextBox = Nothing
	Private Label20 As Label = Nothing
	Private txtBeneficiarios As TextBox = Nothing
	Private Label21 As Label = Nothing
	Private txtDireccionFinanciador As TextBox = Nothing
	Private Label22 As Label = Nothing
	Private txtTelefonoFinanciador As TextBox = Nothing
	Private Label25 As Label = Nothing
	Private txtTelefonoInformacion As TextBox = Nothing
	Private Label26 As Label = Nothing
	Private txtAseguradora2 As TextBox = Nothing
	Private Label34 As Label = Nothing
	Private Label33 As Label = Nothing
	Private Label32 As Label = Nothing
	Private Label31 As Label = Nothing
	Private Label30 As Label = Nothing
	Private Label29 As Label = Nothing
	Private Label28 As Label = Nothing
	Private txtDireccionFinanciador2 As TextBox = Nothing
	Private Label27 As Label = Nothing
	Private Label1 As Label = Nothing
	Private Label2 As Label = Nothing
	Private txtPlaza As TextBox = Nothing
	Private txtCiudad As TextBox = Nothing
	Private txtDireccion As TextBox = Nothing
    Private WithEvents lblLeyendaSeguro As DataDynamics.ActiveReports.Label
	Private Label35 As Label = Nothing
	Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptTicketSeguro))
        Me.Detail = New DataDynamics.ActiveReports.Detail()
        Me.Label23 = New DataDynamics.ActiveReports.Label()
        Me.Label3 = New DataDynamics.ActiveReports.Label()
        Me.Label4 = New DataDynamics.ActiveReports.Label()
        Me.txtFecha = New DataDynamics.ActiveReports.TextBox()
        Me.Label5 = New DataDynamics.ActiveReports.Label()
        Me.txtCaja = New DataDynamics.ActiveReports.TextBox()
        Me.Label6 = New DataDynamics.ActiveReports.Label()
        Me.txtHora = New DataDynamics.ActiveReports.TextBox()
        Me.lblLeyenda1 = New DataDynamics.ActiveReports.Label()
        Me.lblLeyenda2 = New DataDynamics.ActiveReports.Label()
        Me.txtAseguradora = New DataDynamics.ActiveReports.TextBox()
        Me.Label7 = New DataDynamics.ActiveReports.Label()
        Me.txtNoCanjeante = New DataDynamics.ActiveReports.TextBox()
        Me.Label8 = New DataDynamics.ActiveReports.Label()
        Me.txtCanjeante = New DataDynamics.ActiveReports.TextBox()
        Me.Label9 = New DataDynamics.ActiveReports.Label()
        Me.txtRFC = New DataDynamics.ActiveReports.TextBox()
        Me.txtSexo = New DataDynamics.ActiveReports.TextBox()
        Me.Label10 = New DataDynamics.ActiveReports.Label()
        Me.Label18 = New DataDynamics.ActiveReports.Label()
        Me.Label19 = New DataDynamics.ActiveReports.Label()
        Me.txtNoPoliza = New DataDynamics.ActiveReports.TextBox()
        Me.Label20 = New DataDynamics.ActiveReports.Label()
        Me.txtBeneficiarios = New DataDynamics.ActiveReports.TextBox()
        Me.Label21 = New DataDynamics.ActiveReports.Label()
        Me.txtDireccionFinanciador = New DataDynamics.ActiveReports.TextBox()
        Me.Label22 = New DataDynamics.ActiveReports.Label()
        Me.txtTelefonoFinanciador = New DataDynamics.ActiveReports.TextBox()
        Me.Label25 = New DataDynamics.ActiveReports.Label()
        Me.txtTelefonoInformacion = New DataDynamics.ActiveReports.TextBox()
        Me.Label26 = New DataDynamics.ActiveReports.Label()
        Me.txtAseguradora2 = New DataDynamics.ActiveReports.TextBox()
        Me.Label34 = New DataDynamics.ActiveReports.Label()
        Me.Label33 = New DataDynamics.ActiveReports.Label()
        Me.Label32 = New DataDynamics.ActiveReports.Label()
        Me.Label31 = New DataDynamics.ActiveReports.Label()
        Me.Label30 = New DataDynamics.ActiveReports.Label()
        Me.Label29 = New DataDynamics.ActiveReports.Label()
        Me.Label28 = New DataDynamics.ActiveReports.Label()
        Me.txtDireccionFinanciador2 = New DataDynamics.ActiveReports.TextBox()
        Me.Label27 = New DataDynamics.ActiveReports.Label()
        Me.Label1 = New DataDynamics.ActiveReports.Label()
        Me.Label2 = New DataDynamics.ActiveReports.Label()
        Me.txtPlaza = New DataDynamics.ActiveReports.TextBox()
        Me.txtCiudad = New DataDynamics.ActiveReports.TextBox()
        Me.txtDireccion = New DataDynamics.ActiveReports.TextBox()
        Me.Label35 = New DataDynamics.ActiveReports.Label()
        Me.lblLeyendaSeguro = New DataDynamics.ActiveReports.Label()
        Me.PageHeader = New DataDynamics.ActiveReports.PageHeader()
        Me.PageFooter = New DataDynamics.ActiveReports.PageFooter()
        CType(Me.Label23, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCaja, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtHora, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblLeyenda1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblLeyenda2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAseguradora, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNoCanjeante, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCanjeante, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRFC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSexo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label19, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNoPoliza, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label20, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBeneficiarios, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label21, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDireccionFinanciador, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label22, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTelefonoFinanciador, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label25, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTelefonoInformacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label26, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAseguradora2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label34, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label33, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label32, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label31, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label30, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label29, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label28, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDireccionFinanciador2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label27, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPlaza, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCiudad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDireccion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label35, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblLeyendaSeguro, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.ColumnSpacing = 0.0!
        Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label23, Me.Label3, Me.Label4, Me.txtFecha, Me.Label5, Me.txtCaja, Me.Label6, Me.txtHora, Me.lblLeyenda1, Me.lblLeyenda2, Me.txtAseguradora, Me.Label7, Me.txtNoCanjeante, Me.Label8, Me.txtCanjeante, Me.Label9, Me.txtRFC, Me.txtSexo, Me.Label10, Me.Label18, Me.Label19, Me.txtNoPoliza, Me.Label20, Me.txtBeneficiarios, Me.Label21, Me.txtDireccionFinanciador, Me.Label22, Me.txtTelefonoFinanciador, Me.Label25, Me.txtTelefonoInformacion, Me.Label26, Me.txtAseguradora2, Me.Label34, Me.Label33, Me.Label32, Me.Label31, Me.Label30, Me.Label29, Me.Label28, Me.txtDireccionFinanciador2, Me.Label27, Me.Label1, Me.Label2, Me.txtPlaza, Me.txtCiudad, Me.txtDireccion, Me.Label35, Me.lblLeyendaSeguro})
        Me.Detail.Height = 13.57152!
        Me.Detail.Name = "Detail"
        '
        'Label23
        '
        Me.Label23.Height = 0.375!
        Me.Label23.HyperLink = Nothing
        Me.Label23.Left = 0.062!
        Me.Label23.Name = "Label23"
        Me.Label23.Style = "text-align: justify; font-size: 9.75pt; font-family: Tahoma"
        Me.Label23.Text = "donde también podrá conocer que hacer en caso de siniestro."
        Me.Label23.Top = 7.11!
        Me.Label23.Width = 2.5!
        '
        'Label3
        '
        Me.Label3.Height = 0.2!
        Me.Label3.HyperLink = Nothing
        Me.Label3.Left = 0.5184546!
        Me.Label3.Name = "Label3"
        Me.Label3.Style = "text-align: center; font-weight: bold; font-size: 9pt"
        Me.Label3.Text = "Ticket de Venta"
        Me.Label3.Top = 0.75!
        Me.Label3.Width = 1.588091!
        '
        'Label4
        '
        Me.Label4.Height = 0.2!
        Me.Label4.HyperLink = Nothing
        Me.Label4.Left = 0.0625!
        Me.Label4.Name = "Label4"
        Me.Label4.Style = "font-size: 9.75pt; font-family: Tahoma"
        Me.Label4.Text = "Caja:"
        Me.Label4.Top = 1.0!
        Me.Label4.Width = 0.5625!
        '
        'txtFecha
        '
        Me.txtFecha.Height = 0.1875!
        Me.txtFecha.Left = 0.625!
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.Style = "font-size: 9.75pt; font-family: Tahoma"
        Me.txtFecha.Text = "99/99/9999"
        Me.txtFecha.Top = 1.25!
        Me.txtFecha.Width = 0.8125!
        '
        'Label5
        '
        Me.Label5.Height = 0.2!
        Me.Label5.HyperLink = Nothing
        Me.Label5.Left = 0.0625!
        Me.Label5.Name = "Label5"
        Me.Label5.Style = "font-size: 9.75pt; font-family: Tahoma"
        Me.Label5.Text = "Fecha:"
        Me.Label5.Top = 1.25!
        Me.Label5.Width = 0.5625!
        '
        'txtCaja
        '
        Me.txtCaja.Height = 0.1875!
        Me.txtCaja.Left = 0.625!
        Me.txtCaja.Name = "txtCaja"
        Me.txtCaja.Style = "font-size: 9.75pt; font-family: Tahoma"
        Me.txtCaja.Text = Nothing
        Me.txtCaja.Top = 1.0!
        Me.txtCaja.Width = 1.9375!
        '
        'Label6
        '
        Me.Label6.Height = 0.2!
        Me.Label6.HyperLink = Nothing
        Me.Label6.Left = 1.4375!
        Me.Label6.Name = "Label6"
        Me.Label6.Style = "font-size: 9.75pt; font-family: Tahoma"
        Me.Label6.Text = "Hora:"
        Me.Label6.Top = 1.25!
        Me.Label6.Width = 0.375!
        '
        'txtHora
        '
        Me.txtHora.Height = 0.1875!
        Me.txtHora.Left = 1.8125!
        Me.txtHora.Name = "txtHora"
        Me.txtHora.Style = "font-size: 9.75pt; font-family: Tahoma"
        Me.txtHora.Text = "00:00:00"
        Me.txtHora.Top = 1.25!
        Me.txtHora.Width = 0.75!
        '
        'lblLeyenda1
        '
        Me.lblLeyenda1.Height = 0.1875!
        Me.lblLeyenda1.HyperLink = Nothing
        Me.lblLeyenda1.Left = 0.0625!
        Me.lblLeyenda1.Name = "lblLeyenda1"
        Me.lblLeyenda1.Style = "text-align: center"
        Me.lblLeyenda1.Text = "************** ¡Felicidades! **************"
        Me.lblLeyenda1.Top = 1.5!
        Me.lblLeyenda1.Width = 2.5!
        '
        'lblLeyenda2
        '
        Me.lblLeyenda2.Height = 0.375!
        Me.lblLeyenda2.HyperLink = Nothing
        Me.lblLeyenda2.Left = 0.0625!
        Me.lblLeyenda2.Name = "lblLeyenda2"
        Me.lblLeyenda2.Style = "text-align: justify"
        Me.lblLeyenda2.Text = "Estás disfrutando del beneficio exclusivo que"
        Me.lblLeyenda2.Top = 1.6875!
        Me.lblLeyenda2.Width = 2.5!
        '
        'txtAseguradora
        '
        Me.txtAseguradora.Height = 0.375!
        Me.txtAseguradora.Left = 0.0625!
        Me.txtAseguradora.Name = "txtAseguradora"
        Me.txtAseguradora.Style = "text-align: left; font-size: 9.75pt; font-family: Tahoma"
        Me.txtAseguradora.Text = Nothing
        Me.txtAseguradora.Top = 2.0625!
        Me.txtAseguradora.Width = 2.5!
        '
        'Label7
        '
        Me.Label7.Height = 0.2!
        Me.Label7.HyperLink = Nothing
        Me.Label7.Left = 0.0625!
        Me.Label7.Name = "Label7"
        Me.Label7.Style = "font-size: 9.75pt; font-family: Tahoma"
        Me.Label7.Text = "No. Canjeante:"
        Me.Label7.Top = 2.75!
        Me.Label7.Width = 0.9375!
        '
        'txtNoCanjeante
        '
        Me.txtNoCanjeante.Height = 0.1875!
        Me.txtNoCanjeante.Left = 1.0!
        Me.txtNoCanjeante.Name = "txtNoCanjeante"
        Me.txtNoCanjeante.Style = "font-size: 9.75pt; font-family: Tahoma"
        Me.txtNoCanjeante.Text = Nothing
        Me.txtNoCanjeante.Top = 2.75!
        Me.txtNoCanjeante.Width = 1.5625!
        '
        'Label8
        '
        Me.Label8.Height = 0.2!
        Me.Label8.HyperLink = Nothing
        Me.Label8.Left = 0.0625!
        Me.Label8.Name = "Label8"
        Me.Label8.Style = "font-size: 9.75pt; font-family: Tahoma"
        Me.Label8.Text = "Canjeante:"
        Me.Label8.Top = 2.9375!
        Me.Label8.Width = 0.9375!
        '
        'txtCanjeante
        '
        Me.txtCanjeante.Height = 0.375!
        Me.txtCanjeante.Left = 1.0!
        Me.txtCanjeante.Name = "txtCanjeante"
        Me.txtCanjeante.Style = "font-size: 9.75pt; font-family: Tahoma"
        Me.txtCanjeante.Text = Nothing
        Me.txtCanjeante.Top = 2.9375!
        Me.txtCanjeante.Width = 1.5625!
        '
        'Label9
        '
        Me.Label9.Height = 0.2!
        Me.Label9.HyperLink = Nothing
        Me.Label9.Left = 0.0625!
        Me.Label9.Name = "Label9"
        Me.Label9.Style = "font-size: 9.75pt; font-family: Tahoma"
        Me.Label9.Text = "RFC:"
        Me.Label9.Top = 3.3125!
        Me.Label9.Width = 0.9375!
        '
        'txtRFC
        '
        Me.txtRFC.Height = 0.1875!
        Me.txtRFC.Left = 1.0!
        Me.txtRFC.Name = "txtRFC"
        Me.txtRFC.Style = "font-size: 9.75pt; font-family: Tahoma"
        Me.txtRFC.Text = Nothing
        Me.txtRFC.Top = 3.3125!
        Me.txtRFC.Width = 1.5625!
        '
        'txtSexo
        '
        Me.txtSexo.Height = 0.1875!
        Me.txtSexo.Left = 1.0!
        Me.txtSexo.Name = "txtSexo"
        Me.txtSexo.Style = "font-size: 9.75pt; font-family: Tahoma"
        Me.txtSexo.Text = Nothing
        Me.txtSexo.Top = 3.5!
        Me.txtSexo.Width = 1.5625!
        '
        'Label10
        '
        Me.Label10.Height = 0.2!
        Me.Label10.HyperLink = Nothing
        Me.Label10.Left = 0.0625!
        Me.Label10.Name = "Label10"
        Me.Label10.Style = "font-size: 9.75pt; font-family: Tahoma"
        Me.Label10.Text = "Sexo:"
        Me.Label10.Top = 3.5!
        Me.Label10.Width = 0.9375!
        '
        'Label18
        '
        Me.Label18.Height = 0.2!
        Me.Label18.HyperLink = Nothing
        Me.Label18.Left = 0.5179546!
        Me.Label18.Name = "Label18"
        Me.Label18.Style = "text-align: center; font-weight: bold; font-size: 9pt"
        Me.Label18.Text = "Seguro de Vida"
        Me.Label18.Top = 5.4225!
        Me.Label18.Width = 1.588091!
        '
        'Label19
        '
        Me.Label19.Height = 0.2!
        Me.Label19.HyperLink = Nothing
        Me.Label19.Left = 0.062!
        Me.Label19.Name = "Label19"
        Me.Label19.Style = "font-size: 9.75pt; font-family: Tahoma"
        Me.Label19.Text = "No. Poliza:"
        Me.Label19.Top = 5.6725!
        Me.Label19.Width = 0.9375!
        '
        'txtNoPoliza
        '
        Me.txtNoPoliza.Height = 0.1875!
        Me.txtNoPoliza.Left = 0.9995!
        Me.txtNoPoliza.Name = "txtNoPoliza"
        Me.txtNoPoliza.Style = "font-size: 9.75pt; font-family: Tahoma"
        Me.txtNoPoliza.Text = Nothing
        Me.txtNoPoliza.Top = 5.6725!
        Me.txtNoPoliza.Width = 1.5625!
        '
        'Label20
        '
        Me.Label20.Height = 0.2!
        Me.Label20.HyperLink = Nothing
        Me.Label20.Left = 0.062!
        Me.Label20.Name = "Label20"
        Me.Label20.Style = "font-size: 9.75pt; font-family: Tahoma"
        Me.Label20.Text = "Beneficiarios:"
        Me.Label20.Top = 5.86!
        Me.Label20.Width = 0.9375!
        '
        'txtBeneficiarios
        '
        Me.txtBeneficiarios.Height = 0.375!
        Me.txtBeneficiarios.Left = 0.062!
        Me.txtBeneficiarios.Name = "txtBeneficiarios"
        Me.txtBeneficiarios.Style = "font-size: 9.75pt; font-family: Tahoma"
        Me.txtBeneficiarios.Text = Nothing
        Me.txtBeneficiarios.Top = 6.0475!
        Me.txtBeneficiarios.Width = 2.5!
        '
        'Label21
        '
        Me.Label21.Height = 0.1875!
        Me.Label21.HyperLink = Nothing
        Me.Label21.Left = 0.062!
        Me.Label21.Name = "Label21"
        Me.Label21.Style = "text-align: justify; font-size: 9.75pt; font-family: Tahoma"
        Me.Label21.Text = "Consulta tus condiciones en:"
        Me.Label21.Top = 6.5475!
        Me.Label21.Width = 2.5!
        '
        'txtDireccionFinanciador
        '
        Me.txtDireccionFinanciador.Height = 0.1875!
        Me.txtDireccionFinanciador.Left = 0.062!
        Me.txtDireccionFinanciador.Name = "txtDireccionFinanciador"
        Me.txtDireccionFinanciador.Style = "text-align: center; font-weight: bold; font-size: 9.75pt; font-family: Tahoma"
        Me.txtDireccionFinanciador.Text = Nothing
        Me.txtDireccionFinanciador.Top = 6.735!
        Me.txtDireccionFinanciador.Width = 2.5!
        '
        'Label22
        '
        Me.Label22.Height = 0.2!
        Me.Label22.HyperLink = Nothing
        Me.Label22.Left = 0.062!
        Me.Label22.Name = "Label22"
        Me.Label22.Style = "font-size: 9.75pt; font-family: Tahoma"
        Me.Label22.Text = "o al"
        Me.Label22.Top = 6.933001!
        Me.Label22.Width = 0.25!
        '
        'txtTelefonoFinanciador
        '
        Me.txtTelefonoFinanciador.Height = 0.1875!
        Me.txtTelefonoFinanciador.Left = 0.312!
        Me.txtTelefonoFinanciador.Name = "txtTelefonoFinanciador"
        Me.txtTelefonoFinanciador.Style = "font-weight: bold; font-size: 9.75pt; font-family: Tahoma"
        Me.txtTelefonoFinanciador.Text = Nothing
        Me.txtTelefonoFinanciador.Top = 6.9225!
        Me.txtTelefonoFinanciador.Width = 2.25!
        '
        'Label25
        '
        Me.Label25.Height = 0.5!
        Me.Label25.HyperLink = Nothing
        Me.Label25.Left = 0.062!
        Me.Label25.Name = "Label25"
        Me.Label25.Style = "text-align: justify; font-size: 9.75pt; font-family: Tahoma"
        Me.Label25.Text = "Para mayor infomación sobre la renovación o cancelación de la póliza, favor de co" & _
    "municarse al télefono,"
        Me.Label25.Top = 7.61!
        Me.Label25.Width = 2.5!
        '
        'txtTelefonoInformacion
        '
        Me.txtTelefonoInformacion.Height = 0.1875!
        Me.txtTelefonoInformacion.Left = 0.062!
        Me.txtTelefonoInformacion.Name = "txtTelefonoInformacion"
        Me.txtTelefonoInformacion.Style = "text-align: center; font-size: 9.75pt; font-family: Tahoma"
        Me.txtTelefonoInformacion.Text = Nothing
        Me.txtTelefonoInformacion.Top = 8.110003!
        Me.txtTelefonoInformacion.Width = 2.5!
        '
        'Label26
        '
        Me.Label26.Height = 0.6875!
        Me.Label26.HyperLink = Nothing
        Me.Label26.Left = 0.062!
        Me.Label26.Name = "Label26"
        Me.Label26.Style = "text-align: justify; font-size: 9.75pt; font-family: Tahoma"
        Me.Label26.Text = "hace de su conocimiento que sus datos personales recabados se tratarán para todos" & _
    " los fines vinculados con la relación jurídica celebrada."
        Me.Label26.Top = 8.672508!
        Me.Label26.Width = 2.5!
        '
        'txtAseguradora2
        '
        Me.txtAseguradora2.Height = 0.3125!
        Me.txtAseguradora2.Left = 0.062!
        Me.txtAseguradora2.Name = "txtAseguradora2"
        Me.txtAseguradora2.Style = "text-align: justify; font-size: 9.75pt; font-family: Tahoma"
        Me.txtAseguradora2.Text = Nothing
        Me.txtAseguradora2.Top = 8.360008!
        Me.txtAseguradora2.Width = 2.5!
        '
        'Label34
        '
        Me.Label34.Height = 0.25!
        Me.Label34.HyperLink = Nothing
        Me.Label34.Left = 0.062!
        Me.Label34.Name = "Label34"
        Me.Label34.Style = "text-align: center; font-size: 9.75pt; font-family: Tahoma"
        Me.Label34.Text = "DP Seguros un producto de DP VALE"
        Me.Label34.Top = 12.67251!
        Me.Label34.Width = 2.5!
        '
        'Label33
        '
        Me.Label33.Height = 0.375!
        Me.Label33.HyperLink = Nothing
        Me.Label33.Left = 0.062!
        Me.Label33.Name = "Label33"
        Me.Label33.Style = "text-align: center; font-size: 9.75pt; font-family: Tahoma"
        Me.Label33.Text = "Visite nuestra página en www.excelenciaseguros.com"
        Me.Label33.Top = 12.17251!
        Me.Label33.Width = 2.5!
        '
        'Label32
        '
        Me.Label32.Height = 0.1875!
        Me.Label32.HyperLink = Nothing
        Me.Label32.Left = 0.062!
        Me.Label32.Name = "Label32"
        Me.Label32.Style = "text-align: center; font-size: 9.75pt; font-family: Tahoma"
        Me.Label32.Text = "Firma del Asegurado"
        Me.Label32.Top = 11.92251!
        Me.Label32.Width = 2.5!
        '
        'Label31
        '
        Me.Label31.Height = 0.1875!
        Me.Label31.HyperLink = Nothing
        Me.Label31.Left = 0.062!
        Me.Label31.Name = "Label31"
        Me.Label31.Style = "text-align: center; font-size: 9.75pt; font-family: Tahoma"
        Me.Label31.Text = "_______________________________"
        Me.Label31.Top = 11.73501!
        Me.Label31.Width = 2.5!
        '
        'Label30
        '
        Me.Label30.Height = 0.5625!
        Me.Label30.HyperLink = Nothing
        Me.Label30.Left = 0.062!
        Me.Label30.Name = "Label30"
        Me.Label30.Style = "text-align: justify; font-size: 9.75pt; font-family: Tahoma"
        Me.Label30.Text = "IFE del Fallecido, IFE del Beneficiario y el presente documento que debe estar fi" & _
    "rmado por el asegurado."
        Me.Label30.Top = 10.79751!
        Me.Label30.Width = 2.5!
        '
        'Label29
        '
        Me.Label29.Height = 0.375!
        Me.Label29.HyperLink = Nothing
        Me.Label29.Left = 0.062!
        Me.Label29.Name = "Label29"
        Me.Label29.Style = "text-align: justify; font-size: 9.75pt; font-family: Tahoma"
        Me.Label29.Text = "Certificado y Acta de defunción del asegurado."
        Me.Label29.Top = 10.36001!
        Me.Label29.Width = 2.5!
        '
        'Label28
        '
        Me.Label28.Height = 0.3125!
        Me.Label28.HyperLink = Nothing
        Me.Label28.Left = 0.062!
        Me.Label28.Name = "Label28"
        Me.Label28.Style = "text-align: justify; font-size: 9.75pt; font-family: Tahoma"
        Me.Label28.Text = "DOCUMENTACIÓN NECESARIA PARA COBRAR EL SEGURO DE VIDA:"
        Me.Label28.Top = 9.922508!
        Me.Label28.Width = 2.5!
        '
        'txtDireccionFinanciador2
        '
        Me.txtDireccionFinanciador2.Height = 0.1875!
        Me.txtDireccionFinanciador2.Left = 0.062!
        Me.txtDireccionFinanciador2.Name = "txtDireccionFinanciador2"
        Me.txtDireccionFinanciador2.Style = "text-align: center; font-size: 9.75pt; font-family: Tahoma"
        Me.txtDireccionFinanciador2.Text = Nothing
        Me.txtDireccionFinanciador2.Top = 9.610008!
        Me.txtDireccionFinanciador2.Width = 2.5!
        '
        'Label27
        '
        Me.Label27.Height = 0.1875!
        Me.Label27.HyperLink = Nothing
        Me.Label27.Left = 0.062!
        Me.Label27.Name = "Label27"
        Me.Label27.Style = "text-align: justify; font-size: 9.75pt; font-family: Tahoma"
        Me.Label27.Text = "Consulte el aviso íntegro en:"
        Me.Label27.Top = 9.422508!
        Me.Label27.Width = 2.5!
        '
        'Label1
        '
        Me.Label1.Height = 0.2!
        Me.Label1.HyperLink = Nothing
        Me.Label1.Left = 0.0625!
        Me.Label1.Name = "Label1"
        Me.Label1.Style = "font-size: 9.75pt; font-family: Tahoma"
        Me.Label1.Text = "Plaza:"
        Me.Label1.Top = 0.0625!
        Me.Label1.Width = 0.875!
        '
        'Label2
        '
        Me.Label2.Height = 0.2!
        Me.Label2.HyperLink = Nothing
        Me.Label2.Left = 0.0625!
        Me.Label2.Name = "Label2"
        Me.Label2.Style = "font-size: 9.75pt; font-family: Tahoma"
        Me.Label2.Text = "Expedido en:"
        Me.Label2.Top = 0.25!
        Me.Label2.Width = 0.875!
        '
        'txtPlaza
        '
        Me.txtPlaza.Height = 0.1875!
        Me.txtPlaza.Left = 0.9375!
        Me.txtPlaza.Name = "txtPlaza"
        Me.txtPlaza.Style = "font-weight: normal; font-size: 9.75pt; font-family: Tahoma"
        Me.txtPlaza.Text = Nothing
        Me.txtPlaza.Top = 0.0625!
        Me.txtPlaza.Width = 0.75!
        '
        'txtCiudad
        '
        Me.txtCiudad.Height = 0.1875!
        Me.txtCiudad.Left = 0.9375!
        Me.txtCiudad.Name = "txtCiudad"
        Me.txtCiudad.Style = "font-weight: normal; font-size: 9.75pt; font-family: Tahoma"
        Me.txtCiudad.Text = Nothing
        Me.txtCiudad.Top = 0.25!
        Me.txtCiudad.Width = 1.625!
        '
        'txtDireccion
        '
        Me.txtDireccion.Height = 0.1875!
        Me.txtDireccion.Left = 0.0625!
        Me.txtDireccion.Name = "txtDireccion"
        Me.txtDireccion.Style = "font-size: 9.75pt; font-family: Tahoma"
        Me.txtDireccion.Text = Nothing
        Me.txtDireccion.Top = 0.4375!
        Me.txtDireccion.Width = 2.5!
        '
        'Label35
        '
        Me.Label35.Height = 0.1875!
        Me.Label35.HyperLink = Nothing
        Me.Label35.Left = 0.0625!
        Me.Label35.Name = "Label35"
        Me.Label35.Style = "text-align: justify"
        Me.Label35.Text = "brinda a sus clientes."
        Me.Label35.Top = 2.4375!
        Me.Label35.Width = 2.5!
        '
        'lblLeyendaSeguro
        '
        Me.lblLeyendaSeguro.Height = 1.521!
        Me.lblLeyendaSeguro.HyperLink = Nothing
        Me.lblLeyendaSeguro.Left = 0.062!
        Me.lblLeyendaSeguro.Name = "lblLeyendaSeguro"
        Me.lblLeyendaSeguro.Style = "text-align: justify"
        Me.lblLeyendaSeguro.Text = resources.GetString("lblLeyendaSeguro.Text")
        Me.lblLeyendaSeguro.Top = 3.84!
        Me.lblLeyendaSeguro.Width = 2.500083!
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
        'rptTicketSeguro
        '
        Me.MasterReport = False
        Me.PageSettings.Margins.Bottom = 0.0!
        Me.PageSettings.Margins.Left = 0.3!
        Me.PageSettings.Margins.Right = 0.0!
        Me.PageSettings.Margins.Top = 0.0!
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 2.885083!
        Me.Sections.Add(Me.PageHeader)
        Me.Sections.Add(Me.Detail)
        Me.Sections.Add(Me.PageFooter)
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" & _
            "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei" & _
            "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" & _
            "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit", "Heading3", "Normal"))
        CType(Me.Label23, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCaja, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtHora, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblLeyenda1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblLeyenda2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAseguradora, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNoCanjeante, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCanjeante, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRFC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSexo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label19, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNoPoliza, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label20, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBeneficiarios, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label21, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDireccionFinanciador, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label22, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTelefonoFinanciador, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label25, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTelefonoInformacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label26, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAseguradora2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label34, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label33, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label32, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label31, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label30, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label29, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label28, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDireccionFinanciador2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label27, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPlaza, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCiudad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDireccion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label35, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblLeyendaSeguro, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

#End Region

End Class
