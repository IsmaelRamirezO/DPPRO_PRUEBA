Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Public Class rptDPValeFinancieroCopia
Inherits DataDynamics.ActiveReports.ActiveReport
    Public Sub New(ByVal strNoCLiente As String, ByVal strNoDist As String, ByVal strNoDocPrestamo As String, _
                   ByVal strNoDPVale As String, ByVal strNoFact As String, ByVal strNombreCli As String, _
                   ByVal strNombreDist As String, ByVal strPagoMin As String, ByVal strPlaza As String, _
                   ByVal strPlazo As String, ByVal NoIFE As String)

        MyBase.New()
        InitializeComponent()

        Me.txtNoCLiente.Text = strNoCLiente
        Me.txtNoDist.Text = strNoDist
        Me.txtNoDocContPrestamo.Text = strNoDocPrestamo
        Me.txtNoDPVale.Text = strNoDPVale
        Me.txtNoFact.Text = strNoFact
        Me.txtNombreCliente.Text = strNombreCli
        Me.txtNombreDist.Text = strNombreDist
        Me.txtPagoMin.Text = Format(strPagoMin, "Currency")
        Me.txtPlaza.Text = strPlaza
        Me.txtPlazo.Text = strPlazo
        Me.txtNoIFE.Text = NoIFE

    End Sub
#Region "ActiveReports Designer generated code"
    Private WithEvents Detail As Detail = Nothing
	Private lblDist As Label = Nothing
	Private lblPlaza As Label = Nothing
	Private lblCli As Label = Nothing
	Private lblNoDPVale As Label = Nothing
	Private lblLeyenda As Label = Nothing
	Private lblLeyenda2 As Label = Nothing
	Private lblQuincenas As Label = Nothing
	Private txtNombreDist As TextBox = Nothing
	Private txtNoDist As TextBox = Nothing
	Private txtPlaza As TextBox = Nothing
	Private txtNombreCliente As TextBox = Nothing
	Private txtNoCLiente As TextBox = Nothing
	Private txtNoDPVale As TextBox = Nothing
	Private txtPagoMin As TextBox = Nothing
	Private txtPlazo As TextBox = Nothing
	Private txtNoFact As TextBox = Nothing
	Private txtNoDocContPrestamo As TextBox = Nothing
	Private lblNoFact As Label = Nothing
	Private lblNoDocContPrest As Label = Nothing
	Private txtNoIFE As TextBox = Nothing
	Private lblIFE As Label = Nothing
	Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptDPValeFinancieroCopia))
            Me.Detail = New DataDynamics.ActiveReports.Detail()
            Me.lblDist = New DataDynamics.ActiveReports.Label()
            Me.lblPlaza = New DataDynamics.ActiveReports.Label()
            Me.lblCli = New DataDynamics.ActiveReports.Label()
            Me.lblNoDPVale = New DataDynamics.ActiveReports.Label()
            Me.lblLeyenda = New DataDynamics.ActiveReports.Label()
            Me.lblLeyenda2 = New DataDynamics.ActiveReports.Label()
            Me.lblQuincenas = New DataDynamics.ActiveReports.Label()
            Me.txtNombreDist = New DataDynamics.ActiveReports.TextBox()
            Me.txtNoDist = New DataDynamics.ActiveReports.TextBox()
            Me.txtPlaza = New DataDynamics.ActiveReports.TextBox()
            Me.txtNombreCliente = New DataDynamics.ActiveReports.TextBox()
            Me.txtNoCLiente = New DataDynamics.ActiveReports.TextBox()
            Me.txtNoDPVale = New DataDynamics.ActiveReports.TextBox()
            Me.txtPagoMin = New DataDynamics.ActiveReports.TextBox()
            Me.txtPlazo = New DataDynamics.ActiveReports.TextBox()
            Me.txtNoFact = New DataDynamics.ActiveReports.TextBox()
            Me.txtNoDocContPrestamo = New DataDynamics.ActiveReports.TextBox()
            Me.lblNoFact = New DataDynamics.ActiveReports.Label()
            Me.lblNoDocContPrest = New DataDynamics.ActiveReports.Label()
            Me.txtNoIFE = New DataDynamics.ActiveReports.TextBox()
            Me.lblIFE = New DataDynamics.ActiveReports.Label()
            CType(Me.lblDist,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblPlaza,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblCli,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblNoDPVale,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblLeyenda,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblLeyenda2,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblQuincenas,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtNombreDist,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtNoDist,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtPlaza,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtNombreCliente,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtNoCLiente,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtNoDPVale,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtPagoMin,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtPlazo,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtNoFact,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtNoDocContPrestamo,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblNoFact,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblNoDocContPrest,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtNoIFE,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblIFE,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
            '
            'Detail
            '
            Me.Detail.ColumnSpacing = 0!
            Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.lblDist, Me.lblPlaza, Me.lblCli, Me.lblNoDPVale, Me.lblLeyenda, Me.lblLeyenda2, Me.lblQuincenas, Me.txtNombreDist, Me.txtNoDist, Me.txtPlaza, Me.txtNombreCliente, Me.txtNoCLiente, Me.txtNoDPVale, Me.txtPagoMin, Me.txtPlazo, Me.txtNoFact, Me.txtNoDocContPrestamo, Me.lblNoFact, Me.lblNoDocContPrest, Me.txtNoIFE, Me.lblIFE})
            Me.Detail.Height = 3.645139!
            Me.Detail.Name = "Detail"
            '
            'lblDist
            '
            Me.lblDist.Height = 0.2362205!
            Me.lblDist.HyperLink = Nothing
            Me.lblDist.Left = 0!
            Me.lblDist.Name = "lblDist"
            Me.lblDist.Style = "font-size: 9.75pt; font-family: Courier New"
            Me.lblDist.Text = "Distribuidor:"
            Me.lblDist.Top = 0.2362205!
            Me.lblDist.Width = 1.181102!
            '
            'lblPlaza
            '
            Me.lblPlaza.Height = 0.2362205!
            Me.lblPlaza.HyperLink = Nothing
            Me.lblPlaza.Left = 0!
            Me.lblPlaza.Name = "lblPlaza"
            Me.lblPlaza.Style = "font-size: 9.75pt; font-family: Courier New"
            Me.lblPlaza.Text = "Plaza:"
            Me.lblPlaza.Top = 0.7711611!
            Me.lblPlaza.Width = 0.6299213!
            '
            'lblCli
            '
            Me.lblCli.Height = 0.2362205!
            Me.lblCli.HyperLink = Nothing
            Me.lblCli.Left = 0!
            Me.lblCli.Name = "lblCli"
            Me.lblCli.Style = "font-size: 9.75pt; font-family: Courier New"
            Me.lblCli.Text = "Cliente:"
            Me.lblCli.Top = 1.104823!
            Me.lblCli.Width = 0.7874014!
            '
            'lblNoDPVale
            '
            Me.lblNoDPVale.Height = 0.2362205!
            Me.lblNoDPVale.HyperLink = Nothing
            Me.lblNoDPVale.Left = 0!
            Me.lblNoDPVale.Name = "lblNoDPVale"
            Me.lblNoDPVale.Style = "font-size: 9.75pt; font-family: Courier New"
            Me.lblNoDPVale.Text = "# DPVale:"
            Me.lblNoDPVale.Top = 1.737205!
            Me.lblNoDPVale.Width = 0.8661417!
            '
            'lblLeyenda
            '
            Me.lblLeyenda.Height = 0.2362203!
            Me.lblLeyenda.HyperLink = Nothing
            Me.lblLeyenda.Left = 0!
            Me.lblLeyenda.Name = "lblLeyenda"
            Me.lblLeyenda.Style = "font-size: 9.75pt; font-family: Courier New"
            Me.lblLeyenda.Text = "Usted pagará"
            Me.lblLeyenda.Top = 2.967028!
            Me.lblLeyenda.Width = 1.496063!
            '
            'lblLeyenda2
            '
            Me.lblLeyenda2.Height = 0.2362199!
            Me.lblLeyenda2.HyperLink = Nothing
            Me.lblLeyenda2.Left = 0!
            Me.lblLeyenda2.Name = "lblLeyenda2"
            Me.lblLeyenda2.Style = "font-size: 9.75pt; font-family: Courier New"
            Me.lblLeyenda2.Text = "durante"
            Me.lblLeyenda2.Top = 3.203247!
            Me.lblLeyenda2.Width = 0.8661417!
            '
            'lblQuincenas
            '
            Me.lblQuincenas.Height = 0.2362204!
            Me.lblQuincenas.HyperLink = Nothing
            Me.lblQuincenas.Left = 1.259842!
            Me.lblQuincenas.Name = "lblQuincenas"
            Me.lblQuincenas.Style = "font-size: 9.75pt; font-family: Courier New"
            Me.lblQuincenas.Text = "quincenas."
            Me.lblQuincenas.Top = 3.203247!
            Me.lblQuincenas.Width = 1.181102!
            '
            'txtNombreDist
            '
            Me.txtNombreDist.Height = 0.2362205!
            Me.txtNombreDist.Left = 0!
            Me.txtNombreDist.Name = "txtNombreDist"
            Me.txtNombreDist.Style = "font-size: 9.75pt; font-family: Courier New"
            Me.txtNombreDist.Text = "TextBox1"
            Me.txtNombreDist.Top = 0.472441!
            Me.txtNombreDist.Width = 2.440945!
            '
            'txtNoDist
            '
            Me.txtNoDist.Height = 0.2362205!
            Me.txtNoDist.Left = 1.181102!
            Me.txtNoDist.Name = "txtNoDist"
            Me.txtNoDist.Style = "font-size: 9.75pt; font-family: Courier New"
            Me.txtNoDist.Text = "TextBox1"
            Me.txtNoDist.Top = 0.2362205!
            Me.txtNoDist.Width = 1.259843!
            '
            'txtPlaza
            '
            Me.txtPlaza.Height = 0.2362205!
            Me.txtPlaza.Left = 0.6186024!
            Me.txtPlaza.Name = "txtPlaza"
            Me.txtPlaza.Style = "font-size: 9.75pt; font-family: Courier New"
            Me.txtPlaza.Text = "TextBox1"
            Me.txtPlaza.Top = 0.7716535!
            Me.txtPlaza.Width = 1.822342!
            '
            'txtNombreCliente
            '
            Me.txtNombreCliente.Height = 0.2362205!
            Me.txtNombreCliente.Left = 0!
            Me.txtNombreCliente.Name = "txtNombreCliente"
            Me.txtNombreCliente.Style = "font-size: 9.75pt; font-family: Courier New"
            Me.txtNombreCliente.Text = "TextBox1"
            Me.txtNombreCliente.Top = 1.341043!
            Me.txtNombreCliente.Width = 2.440945!
            '
            'txtNoCLiente
            '
            Me.txtNoCLiente.Height = 0.2362205!
            Me.txtNoCLiente.Left = 0.7874014!
            Me.txtNoCLiente.Name = "txtNoCLiente"
            Me.txtNoCLiente.Style = "font-size: 9.75pt; font-family: Courier New"
            Me.txtNoCLiente.Text = "TextBox1"
            Me.txtNoCLiente.Top = 1.103839!
            Me.txtNoCLiente.Width = 1.653544!
            '
            'txtNoDPVale
            '
            Me.txtNoDPVale.Height = 0.2362205!
            Me.txtNoDPVale.Left = 0.944882!
            Me.txtNoDPVale.Name = "txtNoDPVale"
            Me.txtNoDPVale.Style = "font-size: 9.75pt; font-family: Courier New"
            Me.txtNoDPVale.Text = "TextBox1"
            Me.txtNoDPVale.Top = 1.73622!
            Me.txtNoDPVale.Width = 1.504921!
            '
            'txtPagoMin
            '
            Me.txtPagoMin.Height = 0.2362203!
            Me.txtPagoMin.Left = 1.496063!
            Me.txtPagoMin.Name = "txtPagoMin"
            Me.txtPagoMin.Style = "font-size: 9.75pt; font-family: Courier New"
            Me.txtPagoMin.Text = "TextBox1"
            Me.txtPagoMin.Top = 2.967028!
            Me.txtPagoMin.Width = 0.944882!
            '
            'txtPlazo
            '
            Me.txtPlazo.Height = 0.2362205!
            Me.txtPlazo.Left = 0.8661417!
            Me.txtPlazo.Name = "txtPlazo"
            Me.txtPlazo.Style = "font-size: 9.75pt; font-family: Courier New"
            Me.txtPlazo.Text = "TextBox2"
            Me.txtPlazo.Top = 3.203247!
            Me.txtPlazo.Width = 0.3937007!
            '
            'txtNoFact
            '
            Me.txtNoFact.Height = 0.2362205!
            Me.txtNoFact.Left = 0.944882!
            Me.txtNoFact.Name = "txtNoFact"
            Me.txtNoFact.Style = "font-size: 9.75pt; font-family: Courier New"
            Me.txtNoFact.Text = "TextBox1"
            Me.txtNoFact.Top = 1.992126!
            Me.txtNoFact.Width = 1.488681!
            '
            'txtNoDocContPrestamo
            '
            Me.txtNoDocContPrestamo.Height = 0.2362205!
            Me.txtNoDocContPrestamo.Left = 0.944882!
            Me.txtNoDocContPrestamo.Name = "txtNoDocContPrestamo"
            Me.txtNoDocContPrestamo.Style = "font-size: 9.75pt; font-family: Courier New"
            Me.txtNoDocContPrestamo.Text = "TextBox1"
            Me.txtNoDocContPrestamo.Top = 2.260827!
            Me.txtNoDocContPrestamo.Width = 1.479823!
            '
            'lblNoFact
            '
            Me.lblNoFact.Height = 0.2411415!
            Me.lblNoFact.HyperLink = Nothing
            Me.lblNoFact.Left = 0!
            Me.lblNoFact.Name = "lblNoFact"
            Me.lblNoFact.Style = "font-size: 9.75pt; font-family: Courier New"
            Me.lblNoFact.Text = "Factura:"
            Me.lblNoFact.Top = 1.987205!
            Me.lblNoFact.Width = 0.8661417!
            '
            'lblNoDocContPrest
            '
            Me.lblNoDocContPrest.Height = 0.2362202!
            Me.lblNoDocContPrest.HyperLink = Nothing
            Me.lblNoDocContPrest.Left = 0!
            Me.lblNoDocContPrest.Name = "lblNoDocContPrest"
            Me.lblNoDocContPrest.Style = "font-size: 9.75pt; font-family: Courier New"
            Me.lblNoDocContPrest.Text = "# Prestamo:"
            Me.lblNoDocContPrest.Top = 2.260827!
            Me.lblNoDocContPrest.Width = 0.944882!
            '
            'txtNoIFE
            '
            Me.txtNoIFE.Height = 0.2362205!
            Me.txtNoIFE.Left = 0.944882!
            Me.txtNoIFE.Name = "txtNoIFE"
            Me.txtNoIFE.Style = "font-size: 9.75pt; font-family: Courier New"
            Me.txtNoIFE.Text = "TextBox1"
            Me.txtNoIFE.Top = 2.510827!
            Me.txtNoIFE.Width = 1.479823!
            '
            'lblIFE
            '
            Me.lblIFE.Height = 0.2362202!
            Me.lblIFE.HyperLink = Nothing
            Me.lblIFE.Left = 0!
            Me.lblIFE.Name = "lblIFE"
            Me.lblIFE.Style = "font-size: 9.75pt; font-family: Courier New"
            Me.lblIFE.Text = "No. IFE:"
            Me.lblIFE.Top = 2.510827!
            Me.lblIFE.Width = 0.7874014!
            '
            'ActiveReport1
            '
            Me.MasterReport = false
            Me.PageSettings.Margins.Top = 0.39375!
            Me.PageSettings.PaperHeight = 11!
            Me.PageSettings.PaperWidth = 8.5!
            Me.PrintWidth = 2.552083!
            Me.Sections.Add(Me.Detail)
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo"& _ 
                        "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit", "Heading1", "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei"& _ 
                        "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit", "Heading2", "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo"& _ 
                        "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit", "Heading3", "Normal"))
            CType(Me.lblDist,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblPlaza,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblCli,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblNoDPVale,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblLeyenda,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblLeyenda2,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblQuincenas,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtNombreDist,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtNoDist,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtPlaza,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtNombreCliente,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtNoCLiente,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtNoDPVale,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtPagoMin,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtPlazo,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtNoFact,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtNoDocContPrestamo,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblNoFact,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblNoDocContPrest,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtNoIFE,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblIFE,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        
	End Sub

#End Region

End Class
