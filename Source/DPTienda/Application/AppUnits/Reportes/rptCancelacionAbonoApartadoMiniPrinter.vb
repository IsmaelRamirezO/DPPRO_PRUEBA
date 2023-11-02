Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU
Imports DportenisPro.DPTienda.ApplicationUnits.AbonosApartadosAU

Public Class rptCancelacionAbonoApartadoMiniPrinter
    Inherits DataDynamics.ActiveReports.ActiveReport
    Public Sub New(ByVal oAbono As AbonosApartados, ByVal FolioContrato As String, ByVal Cliente As String, ByVal Importe As Decimal, ByVal TotalAbonos As Decimal, Optional ByVal Reimpresion As Boolean = False)
        MyBase.New()
        InitializeComponent()
        Dim oCatalogoAlmacenesMgr As New CatalogoAlmacenesManager(oAppContext)
        Dim oAlmacen As Almacen
        Dim oSAPMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        lblReimpresion.Visible = Reimpresion
        oAlmacen = oCatalogoAlmacenesMgr.Load(oSAPMgr.Read_Centros) '"2" & oAppContext.ApplicationConfiguration.Almacen)
        Try
            'With oForm
            Me.tbSucursal.Text += " " & oAlmacen.Descripcion
            Me.tbformapago.Text += " " & oAbono.CodFormaPago
            Me.tbFolioAbono.Text = oAbono.FolioAbono.ToString.PadLeft(10, "0")

            Me.tbDesCliente.Text = Cliente
            Me.tbNumApartado.Text = FolioContrato.PadLeft(10, "0") '   
            Me.tbFecha.Text = Now
            Me.tbSaldoActual.Text = Format(Importe - (TotalAbonos + oAbono.Abono), "$ #,##0.00")
            Me.tbAbono.Text = Format(oAbono.Abono, "$ #,##0.00")
            Me.tbSaldoNuevo.Text = Format(Importe - TotalAbonos, "$ #,##0.00")

            Dim Ob As New DportenisPro.DPTienda.ApplicationUnits.NumeroaLetras.Letras

            Dim parametros() As String = oAbono.Abono.ToString.Split(".")
            parametros(0) = parametros(0).Replace("$", "")

            If parametros.Length > 1 Then
                Me.tbImporteCLetra.Text = "(" & Ob.Letras(parametros(0)) & "Pesos " & parametros(1) & "/100 M.N.)"
            Else
                Me.tbImporteCLetra.Text = "(" & Ob.Letras(parametros(0)) & "Pesos " & "00/100 M.N.)"
            End If


            'End With
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
#Region "ActiveReports Designer generated code"
    Private WithEvents ReportHeader As ReportHeader = Nothing
    Private WithEvents PageHeader As PageHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents PageFooter As PageFooter = Nothing
    Private WithEvents ReportFooter As ReportFooter = Nothing
    Private tbNumApartado As Label = Nothing
    Private tbDesCliente As Label = Nothing
    Private tbSaldoActual As Label = Nothing
    Private tbSaldoNuevo As Label = Nothing
    Private tbFecha As Label = Nothing
    Private tbImporteCLetra As Label = Nothing
    Private tbFolioAbono As Label = Nothing
    Private tbAbono As Label = Nothing
    Private Label1 As Label = Nothing
    Private Label2 As Label = Nothing
    Private Label3 As Label = Nothing
    Private Label4 As Label = Nothing
    Private Label5 As Label = Nothing
    Private Label6 As Label = Nothing
    Private Label7 As Label = Nothing
    Private Label8 As Label = Nothing
    Private Label12 As Label = Nothing
    Private Label13 As Label = Nothing
    Private tbSucursal As Label = Nothing
    Private tbformapago As Label = Nothing
    Private Line1 As Line = Nothing
    Private Label9 As Label = Nothing
    Friend WithEvents lblReimpresion As DataDynamics.ActiveReports.Label
    Private Label11 As Label = Nothing
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptCancelacionAbonoApartadoMiniPrinter))
        Me.Detail = New DataDynamics.ActiveReports.Detail()
        Me.ReportHeader = New DataDynamics.ActiveReports.ReportHeader()
        Me.ReportFooter = New DataDynamics.ActiveReports.ReportFooter()
        Me.Line1 = New DataDynamics.ActiveReports.Line()
        Me.Label9 = New DataDynamics.ActiveReports.Label()
        Me.Label11 = New DataDynamics.ActiveReports.Label()
        Me.PageHeader = New DataDynamics.ActiveReports.PageHeader()
        Me.tbNumApartado = New DataDynamics.ActiveReports.Label()
        Me.tbDesCliente = New DataDynamics.ActiveReports.Label()
        Me.tbSaldoActual = New DataDynamics.ActiveReports.Label()
        Me.tbSaldoNuevo = New DataDynamics.ActiveReports.Label()
        Me.tbFecha = New DataDynamics.ActiveReports.Label()
        Me.tbImporteCLetra = New DataDynamics.ActiveReports.Label()
        Me.tbFolioAbono = New DataDynamics.ActiveReports.Label()
        Me.tbAbono = New DataDynamics.ActiveReports.Label()
        Me.Label1 = New DataDynamics.ActiveReports.Label()
        Me.Label2 = New DataDynamics.ActiveReports.Label()
        Me.Label3 = New DataDynamics.ActiveReports.Label()
        Me.Label4 = New DataDynamics.ActiveReports.Label()
        Me.Label5 = New DataDynamics.ActiveReports.Label()
        Me.Label6 = New DataDynamics.ActiveReports.Label()
        Me.Label7 = New DataDynamics.ActiveReports.Label()
        Me.Label8 = New DataDynamics.ActiveReports.Label()
        Me.Label12 = New DataDynamics.ActiveReports.Label()
        Me.Label13 = New DataDynamics.ActiveReports.Label()
        Me.tbSucursal = New DataDynamics.ActiveReports.Label()
        Me.tbformapago = New DataDynamics.ActiveReports.Label()
        Me.lblReimpresion = New DataDynamics.ActiveReports.Label()
        Me.PageFooter = New DataDynamics.ActiveReports.PageFooter()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbNumApartado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbDesCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbSaldoActual, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbSaldoNuevo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbImporteCLetra, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbFolioAbono, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbAbono, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbSucursal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbformapago, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblReimpresion, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.ReportHeader.Height = 0.0!
        Me.ReportHeader.Name = "ReportHeader"
        '
        'ReportFooter
        '
        Me.ReportFooter.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Line1, Me.Label9, Me.Label11})
        Me.ReportFooter.Height = 0.6756945!
        Me.ReportFooter.Name = "ReportFooter"
        '
        'Line1
        '
        Me.Line1.Height = 0.0!
        Me.Line1.Left = 0.6368656!
        Me.Line1.LineWeight = 1.0!
        Me.Line1.Name = "Line1"
        Me.Line1.Top = 0.4793853!
        Me.Line1.Width = 1.496062!
        Me.Line1.X1 = 2.132928!
        Me.Line1.X2 = 0.6368656!
        Me.Line1.Y1 = 0.4793853!
        Me.Line1.Y2 = 0.4793853!
        '
        'Label9
        '
        Me.Label9.Height = 0.1574803!
        Me.Label9.HyperLink = Nothing
        Me.Label9.Left = 0.8661417!
        Me.Label9.Name = "Label9"
        Me.Label9.Style = "text-align: center; font-size: 8.25pt"
        Me.Label9.Text = "FIRMA"
        Me.Label9.Top = 7.450583E-9!
        Me.Label9.Width = 1.023622!
        '
        'Label11
        '
        Me.Label11.Height = 0.1574803!
        Me.Label11.HyperLink = Nothing
        Me.Label11.Left = 0.8661417!
        Me.Label11.Name = "Label11"
        Me.Label11.Style = "text-align: center; font-size: 8.25pt"
        Me.Label11.Text = "CAJERO(A)"
        Me.Label11.Top = 0.472441!
        Me.Label11.Width = 1.023622!
        '
        'PageHeader
        '
        Me.PageHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.tbNumApartado, Me.tbDesCliente, Me.tbSaldoActual, Me.tbSaldoNuevo, Me.tbFecha, Me.tbImporteCLetra, Me.tbFolioAbono, Me.tbAbono, Me.Label1, Me.Label2, Me.Label3, Me.Label4, Me.Label5, Me.Label6, Me.Label7, Me.Label8, Me.Label12, Me.Label13, Me.tbSucursal, Me.tbformapago, Me.lblReimpresion})
        Me.PageHeader.Height = 3.979167!
        Me.PageHeader.Name = "PageHeader"
        '
        'tbNumApartado
        '
        Me.tbNumApartado.Height = 0.1574802!
        Me.tbNumApartado.HyperLink = Nothing
        Me.tbNumApartado.Left = 1.89!
        Me.tbNumApartado.Name = "tbNumApartado"
        Me.tbNumApartado.Style = "font-size: 8.25pt; font-family: Tahoma"
        Me.tbNumApartado.Text = "0000000000"
        Me.tbNumApartado.Top = 1.805!
        Me.tbNumApartado.Width = 0.7874014!
        '
        'tbDesCliente
        '
        Me.tbDesCliente.Height = 0.1574803!
        Me.tbDesCliente.HyperLink = Nothing
        Me.tbDesCliente.Left = 0.2561417!
        Me.tbDesCliente.Name = "tbDesCliente"
        Me.tbDesCliente.Style = "font-size: 8.25pt; font-family: Tahoma"
        Me.tbDesCliente.Text = "CRISTINA AROS MARTINEZ"
        Me.tbDesCliente.Top = 1.369309!
        Me.tbDesCliente.Width = 2.440945!
        '
        'tbSaldoActual
        '
        Me.tbSaldoActual.Height = 0.2!
        Me.tbSaldoActual.HyperLink = Nothing
        Me.tbSaldoActual.Left = 1.496299!
        Me.tbSaldoActual.Name = "tbSaldoActual"
        Me.tbSaldoActual.Style = "text-align: right; font-size: 8.25pt; font-family: Tahoma"
        Me.tbSaldoActual.Text = ""
        Me.tbSaldoActual.Top = 2.472604!
        Me.tbSaldoActual.Width = 0.7874014!
        '
        'tbSaldoNuevo
        '
        Me.tbSaldoNuevo.Height = 0.2!
        Me.tbSaldoNuevo.HyperLink = Nothing
        Me.tbSaldoNuevo.Left = 1.496299!
        Me.tbSaldoNuevo.Name = "tbSaldoNuevo"
        Me.tbSaldoNuevo.Style = "text-align: right; font-size: 8.25pt; font-family: Tahoma"
        Me.tbSaldoNuevo.Text = ""
        Me.tbSaldoNuevo.Top = 2.820045!
        Me.tbSaldoNuevo.Width = 0.7874014!
        '
        'tbFecha
        '
        Me.tbFecha.Height = 0.1574802!
        Me.tbFecha.HyperLink = Nothing
        Me.tbFecha.Left = 0.7876375!
        Me.tbFecha.Name = "tbFecha"
        Me.tbFecha.Style = "font-size: 8.25pt; font-family: Tahoma"
        Me.tbFecha.Text = "05/06/2006 03:18:56 p.m."
        Me.tbFecha.Top = 2.020692!
        Me.tbFecha.Width = 1.889764!
        '
        'tbImporteCLetra
        '
        Me.tbImporteCLetra.Height = 0.472441!
        Me.tbImporteCLetra.HyperLink = Nothing
        Me.tbImporteCLetra.Left = 0.2561417!
        Me.tbImporteCLetra.Name = "tbImporteCLetra"
        Me.tbImporteCLetra.Style = "font-size: 8.25pt; font-family: Tahoma"
        Me.tbImporteCLetra.Text = ""
        Me.tbImporteCLetra.Top = 3.354985!
        Me.tbImporteCLetra.Width = 2.362205!
        '
        'tbFolioAbono
        '
        Me.tbFolioAbono.Height = 0.1550197!
        Me.tbFolioAbono.HyperLink = Nothing
        Me.tbFolioAbono.Left = 0.7876375!
        Me.tbFolioAbono.Name = "tbFolioAbono"
        Me.tbFolioAbono.Style = "font-size: 8.25pt; font-family: Tahoma"
        Me.tbFolioAbono.Text = ""
        Me.tbFolioAbono.Top = 0.5090019!
        Me.tbFolioAbono.Width = 1.07874!
        '
        'tbAbono
        '
        Me.tbAbono.Height = 0.2!
        Me.tbAbono.HyperLink = Nothing
        Me.tbAbono.Left = 1.496299!
        Me.tbAbono.Name = "tbAbono"
        Me.tbAbono.Style = "text-align: right; font-size: 8.25pt; font-family: Tahoma"
        Me.tbAbono.Text = ""
        Me.tbAbono.Top = 2.646324!
        Me.tbAbono.Width = 0.7874014!
        '
        'Label1
        '
        Me.Label1.Height = 0.2!
        Me.Label1.HyperLink = Nothing
        Me.Label1.Left = 0.473!
        Me.Label1.Name = "Label1"
        Me.Label1.Style = "text-align: right; font-size: 8.25pt; font-family: Tahoma"
        Me.Label1.Text = "Saldo Anterior"
        Me.Label1.Top = 2.472604!
        Me.Label1.Width = 0.9445587!
        '
        'Label2
        '
        Me.Label2.Height = 0.2!
        Me.Label2.HyperLink = Nothing
        Me.Label2.Left = 0.163!
        Me.Label2.Name = "Label2"
        Me.Label2.Style = "text-align: right; font-size: 8.25pt; font-family: Tahoma"
        Me.Label2.Text = "Monto cancelado"
        Me.Label2.Top = 2.646324!
        Me.Label2.Width = 1.254559!
        '
        'Label3
        '
        Me.Label3.Height = 0.2!
        Me.Label3.HyperLink = Nothing
        Me.Label3.Left = 0.4726771!
        Me.Label3.Name = "Label3"
        Me.Label3.Style = "text-align: right; font-size: 8.25pt; font-family: Tahoma"
        Me.Label3.Text = "Saldo Nuevo "
        Me.Label3.Top = 2.820045!
        Me.Label3.Width = 0.944882!
        '
        'Label4
        '
        Me.Label4.Height = 0.1574803!
        Me.Label4.HyperLink = Nothing
        Me.Label4.Left = 0.2561417!
        Me.Label4.Name = "Label4"
        Me.Label4.Style = "font-size: 8.25pt; font-family: Tahoma"
        Me.Label4.Text = "FOLIO:"
        Me.Label4.Top = 0.5065411!
        Me.Label4.Width = 0.452756!
        '
        'Label5
        '
        Me.Label5.Height = 0.1574803!
        Me.Label5.HyperLink = Nothing
        Me.Label5.Left = 0.2561417!
        Me.Label5.Name = "Label5"
        Me.Label5.Style = "font-size: 8.25pt; font-family: Tahoma"
        Me.Label5.Text = "RECIBÍ DE: "
        Me.Label5.Top = 1.153616!
        Me.Label5.Width = 0.7086611!
        '
        'Label6
        '
        Me.Label6.Height = 0.1574802!
        Me.Label6.HyperLink = Nothing
        Me.Label6.Left = 0.2561417!
        Me.Label6.Name = "Label6"
        Me.Label6.Style = "font-size: 8.25pt; font-family: Tahoma"
        Me.Label6.Text = "CONTRATO DE APARTADO:"
        Me.Label6.Top = 1.805!
        Me.Label6.Width = 1.555118!
        '
        'Label7
        '
        Me.Label7.Height = 0.1574803!
        Me.Label7.HyperLink = Nothing
        Me.Label7.Left = 0.2561417!
        Me.Label7.Name = "Label7"
        Me.Label7.Style = "font-size: 8.25pt; font-family: Tahoma"
        Me.Label7.Text = "FECHA"
        Me.Label7.Top = 2.020692!
        Me.Label7.Width = 0.4527559!
        '
        'Label8
        '
        Me.Label8.Height = 0.1574802!
        Me.Label8.HyperLink = Nothing
        Me.Label8.Left = 0.2561417!
        Me.Label8.Name = "Label8"
        Me.Label8.Style = "font-size: 8.25pt; font-family: Tahoma"
        Me.Label8.Text = "LA CANTIDAD DE:"
        Me.Label8.Top = 2.236383!
        Me.Label8.Width = 1.023622!
        '
        'Label12
        '
        Me.Label12.Height = 0.1574803!
        Me.Label12.HyperLink = Nothing
        Me.Label12.Left = 0.2561417!
        Me.Label12.Name = "Label12"
        Me.Label12.Style = "font-size: 8.25pt; font-family: Tahoma"
        Me.Label12.Text = "IMPORTE CON LETRA:"
        Me.Label12.Top = 3.135005!
        Me.Label12.Width = 1.240158!
        '
        'Label13
        '
        Me.Label13.Height = 0.424!
        Me.Label13.HyperLink = Nothing
        Me.Label13.Left = 0.473!
        Me.Label13.Name = "Label13"
        Me.Label13.Style = "text-align: center; font-weight: bold; font-size: 9.75pt; font-family: Tahoma"
        Me.Label13.Text = "CANCELACIÓN ANTICIPO A APARTADO"
        Me.Label13.Top = 0.0!
        Me.Label13.Width = 1.889764!
        '
        'tbSucursal
        '
        Me.tbSucursal.Height = 0.1574803!
        Me.tbSucursal.HyperLink = Nothing
        Me.tbSucursal.Left = 0.2364566!
        Me.tbSucursal.Name = "tbSucursal"
        Me.tbSucursal.Style = "font-size: 8.25pt; font-family: Tahoma"
        Me.tbSucursal.Text = "SUCURSAL: "
        Me.tbSucursal.Top = 0.7222331!
        Me.tbSucursal.Width = 2.362204!
        '
        'tbformapago
        '
        Me.tbformapago.Height = 0.1574803!
        Me.tbformapago.HyperLink = Nothing
        Me.tbformapago.Left = 0.2364566!
        Me.tbformapago.Name = "tbformapago"
        Me.tbformapago.Style = "font-size: 8.25pt; font-family: Tahoma"
        Me.tbformapago.Text = "FORMA DE PAGO: "
        Me.tbformapago.Top = 0.9379246!
        Me.tbformapago.Width = 2.362204!
        '
        'lblReimpresion
        '
        Me.lblReimpresion.Height = 0.2050001!
        Me.lblReimpresion.HyperLink = Nothing
        Me.lblReimpresion.Left = 0.236!
        Me.lblReimpresion.Name = "lblReimpresion"
        Me.lblReimpresion.Style = "text-align: center; font-weight: bold; font-size: 9.75pt; font-family: Tahoma"
        Me.lblReimpresion.Text = "Reimpresión"
        Me.lblReimpresion.Top = 1.527!
        Me.lblReimpresion.Width = 1.889764!
        '
        'PageFooter
        '
        Me.PageFooter.Height = 0.01041667!
        Me.PageFooter.Name = "PageFooter"
        '
        'rptCancelacionAbonoApartadoMiniPrinter
        '
        Me.MasterReport = False
        Me.PageSettings.Margins.Bottom = 0.0!
        Me.PageSettings.Margins.Left = 0.0!
        Me.PageSettings.Margins.Right = 0.0!
        Me.PageSettings.Margins.Top = 0.0!
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 2.770833!
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
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbNumApartado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbDesCliente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbSaldoActual, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbSaldoNuevo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbImporteCLetra, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbFolioAbono, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbAbono, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbSucursal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbformapago, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblReimpresion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

#End Region
End Class
