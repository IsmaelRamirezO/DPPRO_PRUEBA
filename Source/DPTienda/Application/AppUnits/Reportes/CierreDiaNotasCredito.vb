
Imports System
Imports System.Data.SqlClient
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Public Class CierreDiaNotasCredito
Inherits DataDynamics.ActiveReports.ActiveReport

	#Region "ActiveReports Designer generated code"
    Private WithEvents ReportHeader As ReportHeader = Nothing
    Private WithEvents GroupHeader1 As GroupHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents GroupFooter1 As GroupFooter = Nothing
    Private WithEvents ReportFooter As ReportFooter = Nothing
	Private Shape1 As Shape = Nothing
	Private Label10 As Label = Nothing
	Private Label9 As Label = Nothing
	Private Label3 As Label = Nothing
	Private Label4 As Label = Nothing
	Private Label5 As Label = Nothing
	Private Label6 As Label = Nothing
	Private Label7 As Label = Nothing
	Private Label8 As Label = Nothing
	Private Label2 As Label = Nothing
	Private Label1 As Label = Nothing
	Private Line1 As Line = Nothing
	Private Label11 As Label = Nothing
	Private LblFechaDE As Label = Nothing
	Private Label12 As Label = Nothing
	Private LblFechaAL As Label = Nothing
	Private LblSucursal As Label = Nothing
	Private Label13 As Label = Nothing
	Private lblFecha As Label = Nothing
	Private tbFolio As TextBox = Nothing
	Private tbFecha As TextBox = Nothing
	Private tbImporte As TextBox = Nothing
	Private tbSaldo As TextBox = Nothing
	Private tbReviso As TextBox = Nothing
	Private tbCliente As TextBox = Nothing
	Private tbFactOrig As TextBox = Nothing
	Private tbFactAplic As TextBox = Nothing
	Private Shape2 As Shape = Nothing
	Private tbTotalImporte As TextBox = Nothing
	Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CierreDiaNotasCredito))
            Me.Detail = New DataDynamics.ActiveReports.Detail()
            Me.ReportHeader = New DataDynamics.ActiveReports.ReportHeader()
            Me.ReportFooter = New DataDynamics.ActiveReports.ReportFooter()
            Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader()
            Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter()
            Me.Shape1 = New DataDynamics.ActiveReports.Shape()
            Me.Label10 = New DataDynamics.ActiveReports.Label()
            Me.Label9 = New DataDynamics.ActiveReports.Label()
            Me.Label3 = New DataDynamics.ActiveReports.Label()
            Me.Label4 = New DataDynamics.ActiveReports.Label()
            Me.Label5 = New DataDynamics.ActiveReports.Label()
            Me.Label6 = New DataDynamics.ActiveReports.Label()
            Me.Label7 = New DataDynamics.ActiveReports.Label()
            Me.Label8 = New DataDynamics.ActiveReports.Label()
            Me.Label2 = New DataDynamics.ActiveReports.Label()
            Me.Label1 = New DataDynamics.ActiveReports.Label()
            Me.Line1 = New DataDynamics.ActiveReports.Line()
            Me.Label11 = New DataDynamics.ActiveReports.Label()
            Me.LblFechaDE = New DataDynamics.ActiveReports.Label()
            Me.Label12 = New DataDynamics.ActiveReports.Label()
            Me.LblFechaAL = New DataDynamics.ActiveReports.Label()
            Me.LblSucursal = New DataDynamics.ActiveReports.Label()
            Me.Label13 = New DataDynamics.ActiveReports.Label()
            Me.lblFecha = New DataDynamics.ActiveReports.Label()
            Me.tbFolio = New DataDynamics.ActiveReports.TextBox()
            Me.tbFecha = New DataDynamics.ActiveReports.TextBox()
            Me.tbImporte = New DataDynamics.ActiveReports.TextBox()
            Me.tbSaldo = New DataDynamics.ActiveReports.TextBox()
            Me.tbReviso = New DataDynamics.ActiveReports.TextBox()
            Me.tbCliente = New DataDynamics.ActiveReports.TextBox()
            Me.tbFactOrig = New DataDynamics.ActiveReports.TextBox()
            Me.tbFactAplic = New DataDynamics.ActiveReports.TextBox()
            Me.Shape2 = New DataDynamics.ActiveReports.Shape()
            Me.tbTotalImporte = New DataDynamics.ActiveReports.TextBox()
            CType(Me.Label10,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label9,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label3,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label5,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label6,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label7,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label8,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label1,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label11,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.LblFechaDE,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label12,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.LblFechaAL,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.LblSucursal,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label13,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblFecha,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbFolio,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbFecha,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbImporte,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbSaldo,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbReviso,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbCliente,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbFactOrig,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbFactAplic,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbTotalImporte,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
            '
            'Detail
            '
            Me.Detail.ColumnSpacing = 0!
            Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.tbFolio, Me.tbFecha, Me.tbImporte, Me.tbSaldo, Me.tbReviso, Me.tbCliente, Me.tbFactOrig, Me.tbFactAplic})
            Me.Detail.Height = 0.1979167!
            Me.Detail.Name = "Detail"
            '
            'ReportHeader
            '
            Me.ReportHeader.Height = 0!
            Me.ReportHeader.Name = "ReportHeader"
            Me.ReportHeader.Visible = false
            '
            'ReportFooter
            '
            Me.ReportFooter.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape2, Me.tbTotalImporte})
            Me.ReportFooter.Height = 0.1979167!
            Me.ReportFooter.Name = "ReportFooter"
            '
            'GroupHeader1
            '
            Me.GroupHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape1, Me.Label10, Me.Label9, Me.Label3, Me.Label4, Me.Label5, Me.Label6, Me.Label7, Me.Label8, Me.Label2, Me.Label1, Me.Line1, Me.Label11, Me.LblFechaDE, Me.Label12, Me.LblFechaAL, Me.LblSucursal, Me.Label13, Me.lblFecha})
            Me.GroupHeader1.Height = 0.8541667!
            Me.GroupHeader1.Name = "GroupHeader1"
            '
            'GroupFooter1
            '
            Me.GroupFooter1.Height = 0!
            Me.GroupFooter1.Name = "GroupFooter1"
            '
            'Shape1
            '
            Me.Shape1.Height = 0.8125!
            Me.Shape1.Left = 0!
            Me.Shape1.Name = "Shape1"
            Me.Shape1.RoundingRadius = 9.999999!
            Me.Shape1.Top = 0!
            Me.Shape1.Width = 6.875!
            '
            'Label10
            '
            Me.Label10.Height = 0.1875!
            Me.Label10.HyperLink = Nothing
            Me.Label10.Left = 2.444444!
            Me.Label10.Name = "Label10"
            Me.Label10.Style = "text-align: center; font-weight: bold; font-size: 8.25pt; font-family: Arial"
            Me.Label10.Text = "Factura Aplicada"
            Me.Label10.Top = 0.6319444!
            Me.Label10.Width = 1.0625!
            '
            'Label9
            '
            Me.Label9.Height = 0.1875!
            Me.Label9.HyperLink = Nothing
            Me.Label9.Left = 1.506944!
            Me.Label9.Name = "Label9"
            Me.Label9.Style = "text-align: center; font-weight: bold; font-size: 8.25pt; font-family: Arial"
            Me.Label9.Text = "Factura Origen"
            Me.Label9.Top = 0.6319444!
            Me.Label9.Width = 0.9375!
            '
            'Label3
            '
            Me.Label3.Height = 0.1875!
            Me.Label3.HyperLink = Nothing
            Me.Label3.Left = 0.1944444!
            Me.Label3.Name = "Label3"
            Me.Label3.Style = "text-align: center; font-weight: bold; font-size: 8.25pt; font-family: Arial"
            Me.Label3.Text = "Folio"
            Me.Label3.Top = 0.6319444!
            Me.Label3.Width = 0.375!
            '
            'Label4
            '
            Me.Label4.Height = 0.1875!
            Me.Label4.HyperLink = Nothing
            Me.Label4.Left = 0.9131944!
            Me.Label4.Name = "Label4"
            Me.Label4.Style = "text-align: center; font-weight: bold; font-size: 8.25pt; font-family: Arial"
            Me.Label4.Text = "Fecha"
            Me.Label4.Top = 0.6319444!
            Me.Label4.Width = 0.4375!
            '
            'Label5
            '
            Me.Label5.Height = 0.1875!
            Me.Label5.HyperLink = Nothing
            Me.Label5.Left = 3.725694!
            Me.Label5.Name = "Label5"
            Me.Label5.Style = "text-align: center; font-weight: bold; font-size: 8.25pt; font-family: Arial"
            Me.Label5.Text = "Importe"
            Me.Label5.Top = 0.6319444!
            Me.Label5.Width = 0.5625!
            '
            'Label6
            '
            Me.Label6.Height = 0.1875!
            Me.Label6.HyperLink = Nothing
            Me.Label6.Left = 4.43165!
            Me.Label6.Name = "Label6"
            Me.Label6.Style = "text-align: center; font-weight: bold; font-size: 8.25pt; font-family: Arial"
            Me.Label6.Text = "Vale de Caja"
            Me.Label6.Top = 0.6319444!
            Me.Label6.Width = 0.7755902!
            '
            'Label7
            '
            Me.Label7.Height = 0.1875!
            Me.Label7.HyperLink = Nothing
            Me.Label7.Left = 5.256945!
            Me.Label7.Name = "Label7"
            Me.Label7.Style = "text-align: center; font-weight: bold; font-size: 8.25pt; font-family: Arial"
            Me.Label7.Text = "Revisó"
            Me.Label7.Top = 0.6319444!
            Me.Label7.Width = 0.75!
            '
            'Label8
            '
            Me.Label8.Height = 0.1875!
            Me.Label8.HyperLink = Nothing
            Me.Label8.Left = 6.069445!
            Me.Label8.Name = "Label8"
            Me.Label8.Style = "text-align: center; font-weight: bold; font-size: 8.25pt; font-family: Arial"
            Me.Label8.Text = "Cliente"
            Me.Label8.Top = 0.6319444!
            Me.Label8.Width = 0.75!
            '
            'Label2
            '
            Me.Label2.Height = 0.1875!
            Me.Label2.HyperLink = Nothing
            Me.Label2.Left = 0.0625!
            Me.Label2.Name = "Label2"
            Me.Label2.Style = "font-weight: bold; font-size: 8.25pt; font-family: Arial"
            Me.Label2.Text = "Fecha :"
            Me.Label2.Top = 0!
            Me.Label2.Width = 0.4375!
            '
            'Label1
            '
            Me.Label1.Height = 0.1875!
            Me.Label1.HyperLink = Nothing
            Me.Label1.Left = 2.5625!
            Me.Label1.Name = "Label1"
            Me.Label1.Style = "text-align: center; font-weight: bold; font-size: 8.25pt; font-family: Arial"
            Me.Label1.Text = "Reporte de Notas de Crédito"
            Me.Label1.Top = 0!
            Me.Label1.Width = 1.9375!
            '
            'Line1
            '
            Me.Line1.Height = 0!
            Me.Line1.Left = 0.006944444!
            Me.Line1.LineWeight = 1!
            Me.Line1.Name = "Line1"
            Me.Line1.Top = 0.5694444!
            Me.Line1.Width = 6.875!
            Me.Line1.X1 = 0.006944444!
            Me.Line1.X2 = 6.881945!
            Me.Line1.Y1 = 0.5694444!
            Me.Line1.Y2 = 0.5694444!
            '
            'Label11
            '
            Me.Label11.Height = 0.1811025!
            Me.Label11.HyperLink = Nothing
            Me.Label11.Left = 2.25!
            Me.Label11.Name = "Label11"
            Me.Label11.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8."& _ 
                "25pt; font-family: Arial"
            Me.Label11.Text = "De:"
            Me.Label11.Top = 0.1875!
            Me.Label11.Width = 0.2810042!
            '
            'LblFechaDE
            '
            Me.LblFechaDE.Height = 0.1811025!
            Me.LblFechaDE.HyperLink = Nothing
            Me.LblFechaDE.Left = 2.5625!
            Me.LblFechaDE.Name = "LblFechaDE"
            Me.LblFechaDE.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: normal; font-size: "& _ 
                "8.25pt; font-family: Arial"
            Me.LblFechaDE.Text = "LblFechaDE"
            Me.LblFechaDE.Top = 0.1875!
            Me.LblFechaDE.Width = 0.9685042!
            '
            'Label12
            '
            Me.Label12.Height = 0.1811025!
            Me.Label12.HyperLink = Nothing
            Me.Label12.Left = 3.5625!
            Me.Label12.Name = "Label12"
            Me.Label12.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8."& _ 
                "25pt; font-family: Arial"
            Me.Label12.Text = "Al:"
            Me.Label12.Top = 0.1875!
            Me.Label12.Width = 0.2810042!
            '
            'LblFechaAL
            '
            Me.LblFechaAL.Height = 0.1811025!
            Me.LblFechaAL.HyperLink = Nothing
            Me.LblFechaAL.Left = 3.8125!
            Me.LblFechaAL.Name = "LblFechaAL"
            Me.LblFechaAL.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: normal; font-size: "& _ 
                "8.25pt; font-family: Arial"
            Me.LblFechaAL.Text = "LblFechaAL"
            Me.LblFechaAL.Top = 0.1875!
            Me.LblFechaAL.Width = 0.9685042!
            '
            'LblSucursal
            '
            Me.LblSucursal.Height = 0.1811025!
            Me.LblSucursal.HyperLink = Nothing
            Me.LblSucursal.Left = 2.125001!
            Me.LblSucursal.Name = "LblSucursal"
            Me.LblSucursal.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: normal; font-size: "& _ 
                "8.25pt; font-family: Arial"
            Me.LblSucursal.Text = "LblSucursal"
            Me.LblSucursal.Top = 0.375!
            Me.LblSucursal.Width = 3.448326!
            '
            'Label13
            '
            Me.Label13.Height = 0.1811025!
            Me.Label13.HyperLink = Nothing
            Me.Label13.Left = 1.4375!
            Me.Label13.Name = "Label13"
            Me.Label13.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8."& _ 
                "25pt; font-family: Arial"
            Me.Label13.Text = "Sucursal:"
            Me.Label13.Top = 0.375!
            Me.Label13.Width = 0.5625!
            '
            'lblFecha
            '
            Me.lblFecha.Height = 0.2!
            Me.lblFecha.HyperLink = Nothing
            Me.lblFecha.Left = 0.5625!
            Me.lblFecha.Name = "lblFecha"
            Me.lblFecha.Style = "font-size: 8.25pt"
            Me.lblFecha.Text = "Fecha"
            Me.lblFecha.Top = 0!
            Me.lblFecha.Width = 0.875!
            '
            'tbFolio
            '
            Me.tbFolio.Height = 0.1875!
            Me.tbFolio.Left = 0!
            Me.tbFolio.Name = "tbFolio"
            Me.tbFolio.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; font-family: Arial"
            Me.tbFolio.Top = 0!
            Me.tbFolio.Width = 0.75!
            '
            'tbFecha
            '
            Me.tbFecha.Height = 0.1875!
            Me.tbFecha.Left = 0.75!
            Me.tbFecha.Name = "tbFecha"
            Me.tbFecha.OutputFormat = resources.GetString("tbFecha.OutputFormat")
            Me.tbFecha.Style = "ddo-char-set: 0; font-size: 8.25pt; font-family: Arial"
            Me.tbFecha.Top = 0!
            Me.tbFecha.Width = 0.75!
            '
            'tbImporte
            '
            Me.tbImporte.Height = 0.1875!
            Me.tbImporte.Left = 3.5625!
            Me.tbImporte.Name = "tbImporte"
            Me.tbImporte.OutputFormat = resources.GetString("tbImporte.OutputFormat")
            Me.tbImporte.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; font-family: Arial"
            Me.tbImporte.Top = 0!
            Me.tbImporte.Width = 0.875!
            '
            'tbSaldo
            '
            Me.tbSaldo.Height = 0.1875!
            Me.tbSaldo.Left = 4.4375!
            Me.tbSaldo.Name = "tbSaldo"
            Me.tbSaldo.OutputFormat = resources.GetString("tbSaldo.OutputFormat")
            Me.tbSaldo.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; font-family: Arial"
            Me.tbSaldo.Top = 0!
            Me.tbSaldo.Width = 0.75!
            '
            'tbReviso
            '
            Me.tbReviso.Height = 0.1875!
            Me.tbReviso.Left = 6.057292!
            Me.tbReviso.Name = "tbReviso"
            Me.tbReviso.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; font-family: Arial"
            Me.tbReviso.Top = 0!
            Me.tbReviso.Width = 0.7604167!
            '
            'tbCliente
            '
            Me.tbCliente.Height = 0.1875!
            Me.tbCliente.Left = 5.25!
            Me.tbCliente.Name = "tbCliente"
            Me.tbCliente.Style = "ddo-char-set: 0; font-size: 8.25pt; font-family: Arial"
            Me.tbCliente.Top = 0!
            Me.tbCliente.Width = 0.75!
            '
            'tbFactOrig
            '
            Me.tbFactOrig.Height = 0.1875!
            Me.tbFactOrig.Left = 1.510417!
            Me.tbFactOrig.Name = "tbFactOrig"
            Me.tbFactOrig.OutputFormat = resources.GetString("tbFactOrig.OutputFormat")
            Me.tbFactOrig.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; font-family: Arial"
            Me.tbFactOrig.Top = 0!
            Me.tbFactOrig.Width = 0.9270833!
            '
            'tbFactAplic
            '
            Me.tbFactAplic.Height = 0.1875!
            Me.tbFactAplic.Left = 2.447917!
            Me.tbFactAplic.Name = "tbFactAplic"
            Me.tbFactAplic.OutputFormat = resources.GetString("tbFactAplic.OutputFormat")
            Me.tbFactAplic.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; font-family: Arial"
            Me.tbFactAplic.Top = 0!
            Me.tbFactAplic.Width = 1.052083!
            '
            'Shape2
            '
            Me.Shape2.Height = 0.1875!
            Me.Shape2.Left = 0!
            Me.Shape2.Name = "Shape2"
            Me.Shape2.RoundingRadius = 9.999999!
            Me.Shape2.Top = 0!
            Me.Shape2.Width = 6.875!
            '
            'tbTotalImporte
            '
            Me.tbTotalImporte.Height = 0.1875!
            Me.tbTotalImporte.Left = 3.5625!
            Me.tbTotalImporte.Name = "tbTotalImporte"
            Me.tbTotalImporte.OutputFormat = resources.GetString("tbTotalImporte.OutputFormat")
            Me.tbTotalImporte.Style = "ddo-char-set: 0; text-align: right; font-weight: normal; font-size: 8.25pt; font-"& _ 
                "family: Arial"
            Me.tbTotalImporte.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
            Me.tbTotalImporte.Top = 0!
            Me.tbTotalImporte.Width = 0.875!
            '
            'ActiveReport1
            '
            Me.MasterReport = false
            Me.PageSettings.Margins.Bottom = 0.39375!
            Me.PageSettings.Margins.Left = 0.39375!
            Me.PageSettings.Margins.Right = 0.39375!
            Me.PageSettings.Margins.Top = 0.9840278!
            Me.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Portrait
            Me.PageSettings.PaperHeight = 11!
            Me.PageSettings.PaperWidth = 8.5!
            Me.PrintWidth = 6.895833!
            Me.Sections.Add(Me.ReportHeader)
            Me.Sections.Add(Me.GroupHeader1)
            Me.Sections.Add(Me.Detail)
            Me.Sections.Add(Me.GroupFooter1)
            Me.Sections.Add(Me.ReportFooter)
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo"& _ 
                        "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit", "Heading1", "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei"& _ 
                        "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit", "Heading2", "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo"& _ 
                        "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit", "Heading3", "Normal"))
            CType(Me.Label10,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label9,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label3,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label5,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label6,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label7,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label8,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label1,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label11,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.LblFechaDE,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label12,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.LblFechaAL,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.LblSucursal,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label13,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblFecha,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbFolio,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbFecha,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbImporte,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbSaldo,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbReviso,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbCliente,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbFactOrig,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbFactAplic,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbTotalImporte,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        
	End Sub

#End Region



#Region "Constructores"

    Public Sub New(ByVal datFechaCierre As Date, ByVal strSucursal As String)

        MyBase.New()
        InitializeComponent()

        lblFecha.Text = Format(Date.Now, "dd-MM-yyyy")

        LblFechaDE.Text = Format(datFechaCierre, "dd-MM-yyyy")

        LblFechaAL.Text = Format(datFechaCierre, "dd-MM-yyyy")

        LblSucursal.Text = strSucursal

        Sm_CreatDataSet(datFechaCierre)

        Sm_MostrarInformacion(datFechaCierre)

    End Sub

#End Region



#Region "Variables Miembros"

    Private dsNotasCredito As New DataSet

#End Region



#Region "Métodos Miembros"

    Private Sub Sm_CreatDataSet(ByVal datFechaCierre As Date)

        Dim sccnnConnection As New SqlConnection(oAppContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdDataSet As SqlCommand
        Dim scdaDataSet As SqlDataAdapter


        sccmdDataSet = New SqlCommand
        scdaDataSet = New SqlDataAdapter


        With sccmdDataSet

            .Connection = sccnnConnection

            .CommandText = "[CierreDiaReporteNotasCredito]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime))


        End With

        scdaDataSet.SelectCommand = sccmdDataSet

        Try
            With sccmdDataSet

                sccnnConnection.Open()

                .Parameters("@Fecha").Value = Format(datFechaCierre, "Short Date")

                'Fill DataSet
                scdaDataSet.Fill(dsNotasCredito, "NotasCredito")

                sccnnConnection.Close()

                If Not dsNotasCredito Is Nothing Then

                    If dsNotasCredito.Tables(0).Rows.Count > 0 Then

                        Sm_FormatGrid()

                    End If

                End If

            End With


        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("Los registros no pudieron ser leidos debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("Los registros no pudieron ser leidos debido a un error de aplicación.", ex)

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

    End Sub

    Private Sub Sm_FormatGrid()

        Dim oRow As DataRow
        Dim intFolioNC As Integer = 0

        For Each oRow In dsNotasCredito.Tables(0).Rows

            If intFolioNC <> oRow!FolioNotaCredito Then

                intFolioNC = oRow!FolioNotaCredito

            Else

                oRow!Importe = 0

            End If

        Next

        oRow = Nothing

    End Sub

    Private Sub Sm_MostrarInformacion(ByVal datFechaCierre As Date)

        Me.DataSource = dsNotasCredito.Tables(0)

        Me.tbFolio.DataField = "FolioNotaCredito"
        Me.tbFecha.DataField = "Fecha"
        tbFactOrig.DataField = "FolioReferencia"
        tbFactAplic.DataField = "FolioFactura"
        Me.tbImporte.DataField = "Importe"
        Me.tbSaldo.DataField = "ValeCajaID"
        Me.tbReviso.DataField = "CodVendedor"
        Me.tbCliente.DataField = "ClienteID"
        Me.tbTotalImporte.DataField = "Importe"

    End Sub

#End Region

End Class
