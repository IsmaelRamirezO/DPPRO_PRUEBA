Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Public Class HistorialCrediticio
Inherits DataDynamics.ActiveReports.ActiveReport
    Public Sub New(ByVal ds As DataSet, ByVal Filtros As String)
        MyBase.New()
        InitializeComponent()

        lblFiltro.Text = Filtros
        Me.DataSource = ds.Tables(0)
    End Sub
#Region "ActiveReports Designer generated code"
    Private WithEvents ReportHeader As ReportHeader = Nothing
    Private WithEvents PageHeader As PageHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents PageFooter As PageFooter = Nothing
    Private WithEvents ReportFooter As ReportFooter = Nothing
	Private Shape1 As Shape = Nothing
	Private Label1 As Label = Nothing
	Private lblFecha As Label = Nothing
	Private lblPagina As Label = Nothing
	Private txtPag As TextBox = Nothing
	Private lblCliente As Label = Nothing
	Private lblFiltro As Label = Nothing
	Private TextBox4 As TextBox = Nothing
	Private TextBox5 As TextBox = Nothing
	Private lblFactura As Label = Nothing
	Private lblFechaFactura As Label = Nothing
	Private lblCargos As Label = Nothing
	Private Label2 As Label = Nothing
	Private Label5 As Label = Nothing
	Private Label6 As Label = Nothing
	Private Shape2 As Shape = Nothing
	Private TxtStatus As TextBox = Nothing
	Private TextBox2 As TextBox = Nothing
	Private TextBox3 As TextBox = Nothing
	Private TxtCargos As TextBox = Nothing
	Private TxtAbonos As TextBox = Nothing
	Private TxtSaldo As TextBox = Nothing
	Private TxtCargTot As TextBox = Nothing
	Private TxtAbonTot As TextBox = Nothing
	Private TxtSaldTot As TextBox = Nothing
	Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(HistorialCrediticio))
            Me.Detail = New DataDynamics.ActiveReports.Detail()
            Me.ReportHeader = New DataDynamics.ActiveReports.ReportHeader()
            Me.ReportFooter = New DataDynamics.ActiveReports.ReportFooter()
            Me.PageHeader = New DataDynamics.ActiveReports.PageHeader()
            Me.PageFooter = New DataDynamics.ActiveReports.PageFooter()
            Me.Shape1 = New DataDynamics.ActiveReports.Shape()
            Me.Label1 = New DataDynamics.ActiveReports.Label()
            Me.lblFecha = New DataDynamics.ActiveReports.Label()
            Me.lblPagina = New DataDynamics.ActiveReports.Label()
            Me.txtPag = New DataDynamics.ActiveReports.TextBox()
            Me.lblCliente = New DataDynamics.ActiveReports.Label()
            Me.lblFiltro = New DataDynamics.ActiveReports.Label()
            Me.TextBox4 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox5 = New DataDynamics.ActiveReports.TextBox()
            Me.lblFactura = New DataDynamics.ActiveReports.Label()
            Me.lblFechaFactura = New DataDynamics.ActiveReports.Label()
            Me.lblCargos = New DataDynamics.ActiveReports.Label()
            Me.Label2 = New DataDynamics.ActiveReports.Label()
            Me.Label5 = New DataDynamics.ActiveReports.Label()
            Me.Label6 = New DataDynamics.ActiveReports.Label()
            Me.Shape2 = New DataDynamics.ActiveReports.Shape()
            Me.TxtStatus = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox2 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox3 = New DataDynamics.ActiveReports.TextBox()
            Me.TxtCargos = New DataDynamics.ActiveReports.TextBox()
            Me.TxtAbonos = New DataDynamics.ActiveReports.TextBox()
            Me.TxtSaldo = New DataDynamics.ActiveReports.TextBox()
            Me.TxtCargTot = New DataDynamics.ActiveReports.TextBox()
            Me.TxtAbonTot = New DataDynamics.ActiveReports.TextBox()
            Me.TxtSaldTot = New DataDynamics.ActiveReports.TextBox()
            CType(Me.Label1,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblFecha,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblPagina,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtPag,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblCliente,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblFiltro,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox4,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox5,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblFactura,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblFechaFactura,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblCargos,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label5,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label6,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TxtStatus,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox2,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox3,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TxtCargos,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TxtAbonos,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TxtSaldo,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TxtCargTot,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TxtAbonTot,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TxtSaldTot,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
            '
            'Detail
            '
            Me.Detail.ColumnSpacing = 0!
            Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TxtStatus, Me.TextBox2, Me.TextBox3, Me.TxtCargos, Me.TxtAbonos, Me.TxtSaldo})
            Me.Detail.Height = 0.1979167!
            Me.Detail.Name = "Detail"
            '
            'ReportHeader
            '
            Me.ReportHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape1, Me.Label1, Me.lblFecha, Me.lblPagina, Me.txtPag, Me.lblCliente, Me.lblFiltro, Me.TextBox4, Me.TextBox5})
            Me.ReportHeader.Height = 0.6875!
            Me.ReportHeader.Name = "ReportHeader"
            '
            'ReportFooter
            '
            Me.ReportFooter.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TxtCargTot, Me.TxtAbonTot, Me.TxtSaldTot})
            Me.ReportFooter.Height = 0.25!
            Me.ReportFooter.Name = "ReportFooter"
            '
            'PageHeader
            '
            Me.PageHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.lblFactura, Me.lblFechaFactura, Me.lblCargos, Me.Label2, Me.Label5, Me.Label6, Me.Shape2})
            Me.PageHeader.Height = 0.1979167!
            Me.PageHeader.Name = "PageHeader"
            '
            'PageFooter
            '
            Me.PageFooter.Height = 0!
            Me.PageFooter.Name = "PageFooter"
            '
            'Shape1
            '
            Me.Shape1.Height = 0.6875!
            Me.Shape1.Left = 0!
            Me.Shape1.Name = "Shape1"
            Me.Shape1.RoundingRadius = 9.999999!
            Me.Shape1.Top = 0!
            Me.Shape1.Width = 7!
            '
            'Label1
            '
            Me.Label1.Height = 0.2!
            Me.Label1.HyperLink = Nothing
            Me.Label1.Left = 2.0625!
            Me.Label1.Name = "Label1"
            Me.Label1.Style = "text-align: center; vertical-align: middle"
            Me.Label1.Text = "HISTORIAL CREDITICIO"
            Me.Label1.Top = 0.0625!
            Me.Label1.Width = 2.9375!
            '
            'lblFecha
            '
            Me.lblFecha.Height = 0.2!
            Me.lblFecha.HyperLink = Nothing
            Me.lblFecha.Left = 0.125!
            Me.lblFecha.Name = "lblFecha"
            Me.lblFecha.Style = ""
            Me.lblFecha.Text = "Fecha"
            Me.lblFecha.Top = 0.0625!
            Me.lblFecha.Width = 0.75!
            '
            'lblPagina
            '
            Me.lblPagina.Height = 0.2!
            Me.lblPagina.HyperLink = Nothing
            Me.lblPagina.Left = 5.9375!
            Me.lblPagina.Name = "lblPagina"
            Me.lblPagina.Style = ""
            Me.lblPagina.Text = "Pag. :"
            Me.lblPagina.Top = 0.0625!
            Me.lblPagina.Width = 0.375!
            '
            'txtPag
            '
            Me.txtPag.Height = 0.2!
            Me.txtPag.Left = 6.375!
            Me.txtPag.Name = "txtPag"
            Me.txtPag.OutputFormat = resources.GetString("txtPag.OutputFormat")
            Me.txtPag.Style = "text-align: right"
            Me.txtPag.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount
            Me.txtPag.Text = "Pag"
            Me.txtPag.Top = 0.0625!
            Me.txtPag.Width = 0.5!
            '
            'lblCliente
            '
            Me.lblCliente.Height = 0.1875!
            Me.lblCliente.HyperLink = Nothing
            Me.lblCliente.Left = 0.125!
            Me.lblCliente.Name = "lblCliente"
            Me.lblCliente.Style = "text-align: left; font-size: 9pt"
            Me.lblCliente.Text = "CLIENTE:"
            Me.lblCliente.Top = 0.4375!
            Me.lblCliente.Width = 0.625!
            '
            'lblFiltro
            '
            Me.lblFiltro.Height = 0.1875!
            Me.lblFiltro.HyperLink = Nothing
            Me.lblFiltro.Left = 1.4375!
            Me.lblFiltro.Name = "lblFiltro"
            Me.lblFiltro.Style = "text-align: center; font-size: 9pt"
            Me.lblFiltro.Text = ""
            Me.lblFiltro.Top = 0.25!
            Me.lblFiltro.Width = 4.1875!
            '
            'TextBox4
            '
            Me.TextBox4.DataField = "AsociadoID"
            Me.TextBox4.Height = 0.1875!
            Me.TextBox4.Left = 0.875!
            Me.TextBox4.Name = "TextBox4"
            Me.TextBox4.Style = "text-align: center"
            Me.TextBox4.Text = "AsociadoID"
            Me.TextBox4.Top = 0.4375!
            Me.TextBox4.Width = 0.75!
            '
            'TextBox5
            '
            Me.TextBox5.DataField = "Nombre"
            Me.TextBox5.Height = 0.1875!
            Me.TextBox5.Left = 1.75!
            Me.TextBox5.Name = "TextBox5"
            Me.TextBox5.Style = "text-align: left"
            Me.TextBox5.Text = "Nombre"
            Me.TextBox5.Top = 0.4375!
            Me.TextBox5.Width = 5.125!
            '
            'lblFactura
            '
            Me.lblFactura.Height = 0.1875!
            Me.lblFactura.HyperLink = Nothing
            Me.lblFactura.Left = 0.8229167!
            Me.lblFactura.Name = "lblFactura"
            Me.lblFactura.Style = "text-align: center; font-size: 9pt"
            Me.lblFactura.Text = "FACTURA"
            Me.lblFactura.Top = 0!
            Me.lblFactura.Width = 0.875!
            '
            'lblFechaFactura
            '
            Me.lblFechaFactura.Height = 0.1875!
            Me.lblFechaFactura.HyperLink = Nothing
            Me.lblFechaFactura.Left = 1.760417!
            Me.lblFechaFactura.Name = "lblFechaFactura"
            Me.lblFechaFactura.Style = "text-align: center; font-size: 9pt"
            Me.lblFechaFactura.Text = "FECHA"
            Me.lblFechaFactura.Top = 0!
            Me.lblFechaFactura.Width = 0.8125!
            '
            'lblCargos
            '
            Me.lblCargos.Height = 0.1875!
            Me.lblCargos.HyperLink = Nothing
            Me.lblCargos.Left = 2.635417!
            Me.lblCargos.Name = "lblCargos"
            Me.lblCargos.Style = "text-align: center; font-size: 9pt"
            Me.lblCargos.Text = "CARGOS"
            Me.lblCargos.Top = 0!
            Me.lblCargos.Width = 1.239583!
            '
            'Label2
            '
            Me.Label2.Height = 0.1875!
            Me.Label2.HyperLink = Nothing
            Me.Label2.Left = 0.01041674!
            Me.Label2.Name = "Label2"
            Me.Label2.Style = "text-align: center; font-size: 9pt"
            Me.Label2.Text = "STATUS"
            Me.Label2.Top = 0!
            Me.Label2.Width = 0.75!
            '
            'Label5
            '
            Me.Label5.Height = 0.1875!
            Me.Label5.HyperLink = Nothing
            Me.Label5.Left = 4!
            Me.Label5.Name = "Label5"
            Me.Label5.Style = "text-align: center; font-size: 9pt"
            Me.Label5.Text = "ABONOS"
            Me.Label5.Top = 0!
            Me.Label5.Width = 1.25!
            '
            'Label6
            '
            Me.Label6.Height = 0.1875!
            Me.Label6.HyperLink = Nothing
            Me.Label6.Left = 5.375!
            Me.Label6.Name = "Label6"
            Me.Label6.Style = "text-align: center; font-size: 9pt"
            Me.Label6.Text = "SALDO"
            Me.Label6.Top = 0!
            Me.Label6.Width = 1.25!
            '
            'Shape2
            '
            Me.Shape2.Height = 0.1875!
            Me.Shape2.Left = 0!
            Me.Shape2.Name = "Shape2"
            Me.Shape2.RoundingRadius = 9.999999!
            Me.Shape2.Top = 0!
            Me.Shape2.Width = 7!
            '
            'TxtStatus
            '
            Me.TxtStatus.DataField = "StatusFactura"
            Me.TxtStatus.Height = 0.1875!
            Me.TxtStatus.Left = 0!
            Me.TxtStatus.Name = "TxtStatus"
            Me.TxtStatus.Style = "text-align: center"
            Me.TxtStatus.Text = "StatusFactura"
            Me.TxtStatus.Top = 0!
            Me.TxtStatus.Width = 0.75!
            '
            'TextBox2
            '
            Me.TextBox2.DataField = "FolioFactura"
            Me.TextBox2.Height = 0.1875!
            Me.TextBox2.Left = 0.8125!
            Me.TextBox2.Name = "TextBox2"
            Me.TextBox2.Style = "text-align: center"
            Me.TextBox2.Text = "FolioFactura"
            Me.TextBox2.Top = 0!
            Me.TextBox2.Width = 0.875!
            '
            'TextBox3
            '
            Me.TextBox3.DataField = "FechaFactura"
            Me.TextBox3.Height = 0.1875!
            Me.TextBox3.Left = 1.75!
            Me.TextBox3.Name = "TextBox3"
            Me.TextBox3.OutputFormat = resources.GetString("TextBox3.OutputFormat")
            Me.TextBox3.Style = "text-align: center"
            Me.TextBox3.Text = "FechaFactura"
            Me.TextBox3.Top = 0!
            Me.TextBox3.Width = 0.8125!
            '
            'TxtCargos
            '
            Me.TxtCargos.DataField = "Cargos"
            Me.TxtCargos.Height = 0.1875!
            Me.TxtCargos.Left = 2.625!
            Me.TxtCargos.Name = "TxtCargos"
            Me.TxtCargos.OutputFormat = resources.GetString("TxtCargos.OutputFormat")
            Me.TxtCargos.Style = "text-align: right"
            Me.TxtCargos.Text = "Cargos"
            Me.TxtCargos.Top = 0!
            Me.TxtCargos.Width = 1.25!
            '
            'TxtAbonos
            '
            Me.TxtAbonos.DataField = "Abonos"
            Me.TxtAbonos.Height = 0.1875!
            Me.TxtAbonos.Left = 3.989583!
            Me.TxtAbonos.Name = "TxtAbonos"
            Me.TxtAbonos.OutputFormat = resources.GetString("TxtAbonos.OutputFormat")
            Me.TxtAbonos.Style = "text-align: right"
            Me.TxtAbonos.Text = "Abonos"
            Me.TxtAbonos.Top = 0!
            Me.TxtAbonos.Width = 1.260417!
            '
            'TxtSaldo
            '
            Me.TxtSaldo.DataField = "Saldo"
            Me.TxtSaldo.Height = 0.1875!
            Me.TxtSaldo.Left = 5.385417!
            Me.TxtSaldo.Name = "TxtSaldo"
            Me.TxtSaldo.OutputFormat = resources.GetString("TxtSaldo.OutputFormat")
            Me.TxtSaldo.Style = "text-align: right"
            Me.TxtSaldo.Text = "Saldo"
            Me.TxtSaldo.Top = 0!
            Me.TxtSaldo.Width = 1.260417!
            '
            'TxtCargTot
            '
            Me.TxtCargTot.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.[Double]
            Me.TxtCargTot.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.TxtCargTot.Height = 0.1875!
            Me.TxtCargTot.Left = 2.625!
            Me.TxtCargTot.Name = "TxtCargTot"
            Me.TxtCargTot.OutputFormat = resources.GetString("TxtCargTot.OutputFormat")
            Me.TxtCargTot.Style = "text-align: right"
            Me.TxtCargTot.Text = "Cargos"
            Me.TxtCargTot.Top = 0!
            Me.TxtCargTot.Width = 1.25!
            '
            'TxtAbonTot
            '
            Me.TxtAbonTot.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.[Double]
            Me.TxtAbonTot.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.TxtAbonTot.Height = 0.1875!
            Me.TxtAbonTot.Left = 3.989583!
            Me.TxtAbonTot.Name = "TxtAbonTot"
            Me.TxtAbonTot.OutputFormat = resources.GetString("TxtAbonTot.OutputFormat")
            Me.TxtAbonTot.Style = "text-align: right"
            Me.TxtAbonTot.Text = "Abonos"
            Me.TxtAbonTot.Top = 0!
            Me.TxtAbonTot.Width = 1.260417!
            '
            'TxtSaldTot
            '
            Me.TxtSaldTot.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.[Double]
            Me.TxtSaldTot.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.TxtSaldTot.Height = 0.1875!
            Me.TxtSaldTot.Left = 5.385417!
            Me.TxtSaldTot.Name = "TxtSaldTot"
            Me.TxtSaldTot.OutputFormat = resources.GetString("TxtSaldTot.OutputFormat")
            Me.TxtSaldTot.Style = "text-align: right"
            Me.TxtSaldTot.Text = "Saldo"
            Me.TxtSaldTot.Top = 0!
            Me.TxtSaldTot.Width = 1.260417!
            '
            'ActiveReport1
            '
            Me.MasterReport = false
            Me.PageSettings.PaperHeight = 11!
            Me.PageSettings.PaperWidth = 8.5!
            Me.PrintWidth = 7.125!
            Me.Sections.Add(Me.ReportHeader)
            Me.Sections.Add(Me.PageHeader)
            Me.Sections.Add(Me.Detail)
            Me.Sections.Add(Me.PageFooter)
            Me.Sections.Add(Me.ReportFooter)
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo"& _ 
                        "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit", "Heading1", "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei"& _ 
                        "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit", "Heading2", "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo"& _ 
                        "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit", "Heading3", "Normal"))
            CType(Me.Label1,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblFecha,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblPagina,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtPag,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblCliente,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblFiltro,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox4,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox5,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblFactura,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblFechaFactura,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblCargos,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label5,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label6,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TxtStatus,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox2,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox3,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TxtCargos,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TxtAbonos,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TxtSaldo,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TxtCargTot,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TxtAbonTot,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TxtSaldTot,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        
	End Sub

#End Region

    Private Sub ReportHeader_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportHeader.Format
        lblFecha.Text = Format(Date.Now, "dd/MM/yyyy")
        TxtCargTot.Text = 0
        TxtAbonTot.Text = 0
    End Sub


    Private Sub Detail_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles Detail.Format
        If TxtStatus.Text = "GRA" Then
            TxtCargTot.Text = FormatCurrency(CDbl(TxtCargTot.Text) + CDbl(TxtCargos.Text), 2)
            TxtAbonTot.Text = FormatCurrency(CDbl(TxtAbonTot.Text) + CDbl(TxtAbonos.Text), 2)
        End If
    End Sub

    Private Sub ReportFooter_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportFooter.Format
        TxtSaldTot.Text = FormatCurrency(CDbl(TxtCargTot.Text) - CDbl(TxtAbonTot.Text), 2)
    End Sub
End Class
