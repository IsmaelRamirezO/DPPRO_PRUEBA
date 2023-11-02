Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Imports DportenisPro.DPTienda.ApplicationUnits.AbonoCreditoDirectoTienda

Public Class rptFacturasAbonodasCDTMiniPrinter
    Inherits DataDynamics.ActiveReports.ActiveReport
    Private oAbonoCreditoDirectoMgr As AbonoCreditoDirectoManager

    Public Sub New(ByVal dsFacturas As DataSet)
        MyBase.New()
        InitializeComponent()

        oAbonoCreditoDirectoMgr = New AbonoCreditoDirectoManager(oAppContext)


        Dim dcMonto As New DataColumn
        With dcMonto
            .ColumnName = "SaldoNuevo"
            .Caption = "SaldoNuevo"
            .Expression = "Saldo - Abono"
            .DataType = GetType(System.Decimal)
            .DefaultValue = 0
        End With

        dsFacturas.Tables(0).Columns.Add(dcMonto)
        dsFacturas.AcceptChanges()

        Dim datavie As New DataView

        Dim row As DataRow

        datavie.Table = dsFacturas.Tables(0)
        datavie.RowFilter = "Abono > 0"

        Me.DataSource = datavie
        Me.DataMember = "Facturas"

        Me.txtFolioFactura.DataField = "DpFactura"
        Me.txtAbono.DataField = "Abono"
        Me.txtSaldo.DataField = "SaldoNuevo"

    End Sub

#Region "ActiveReports Designer generated code"
    Private WithEvents PageHeader As PageHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents PageFooter As PageFooter = Nothing
	Private Label1 As Label = Nothing
	Private Label2 As Label = Nothing
	Private Label3 As Label = Nothing
	Private txtFolioFactura As TextBox = Nothing
	Private txtAbono As TextBox = Nothing
	Private txtSaldo As TextBox = Nothing
	Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptFacturasAbonodasCDTMiniPrinter))
            Me.Detail = New DataDynamics.ActiveReports.Detail()
            Me.PageHeader = New DataDynamics.ActiveReports.PageHeader()
            Me.PageFooter = New DataDynamics.ActiveReports.PageFooter()
            Me.Label1 = New DataDynamics.ActiveReports.Label()
            Me.Label2 = New DataDynamics.ActiveReports.Label()
            Me.Label3 = New DataDynamics.ActiveReports.Label()
            Me.txtFolioFactura = New DataDynamics.ActiveReports.TextBox()
            Me.txtAbono = New DataDynamics.ActiveReports.TextBox()
            Me.txtSaldo = New DataDynamics.ActiveReports.TextBox()
            CType(Me.Label1,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label3,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFolioFactura,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtAbono,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtSaldo,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
            '
            'Detail
            '
            Me.Detail.ColumnSpacing = 0!
            Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtFolioFactura, Me.txtAbono, Me.txtSaldo})
            Me.Detail.Height = 0.1763889!
            Me.Detail.Name = "Detail"
            '
            'PageHeader
            '
            Me.PageHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label1, Me.Label2, Me.Label3})
            Me.PageHeader.Height = 0.25!
            Me.PageHeader.Name = "PageHeader"
            '
            'PageFooter
            '
            Me.PageFooter.Height = 0!
            Me.PageFooter.Name = "PageFooter"
            '
            'Label1
            '
            Me.Label1.Height = 0.1574803!
            Me.Label1.HyperLink = Nothing
            Me.Label1.Left = 0.2362205!
            Me.Label1.Name = "Label1"
            Me.Label1.Style = "text-align: right; font-size: 8.25pt; font-family: Tahoma"
            Me.Label1.Text = "Factura"
            Me.Label1.Top = 0.07874014!
            Me.Label1.Width = 0.5674213!
            '
            'Label2
            '
            Me.Label2.Height = 0.1574803!
            Me.Label2.HyperLink = Nothing
            Me.Label2.Left = 0.8499014!
            Me.Label2.Name = "Label2"
            Me.Label2.Style = "font-size: 8.25pt; font-family: Tahoma"
            Me.Label2.Text = "Abono"
            Me.Label2.Top = 0.07874014!
            Me.Label2.Width = 0.6299213!
            '
            'Label3
            '
            Me.Label3.Height = 0.1574803!
            Me.Label3.HyperLink = Nothing
            Me.Label3.Left = 1.558563!
            Me.Label3.Name = "Label3"
            Me.Label3.Style = "font-size: 8.25pt; font-family: Tahoma"
            Me.Label3.Text = "Saldo"
            Me.Label3.Top = 0.07874014!
            Me.Label3.Width = 0.6299213!
            '
            'txtFolioFactura
            '
            Me.txtFolioFactura.Height = 0.1574803!
            Me.txtFolioFactura.Left = 0.0625!
            Me.txtFolioFactura.Name = "txtFolioFactura"
            Me.txtFolioFactura.Style = "text-align: right; font-size: 8.25pt; font-family: Tahoma"
            Me.txtFolioFactura.Top = 0!
            Me.txtFolioFactura.Width = 0.7480313!
            '
            'txtAbono
            '
            Me.txtAbono.Height = 0.1574803!
            Me.txtAbono.Left = 0.8499014!
            Me.txtAbono.Name = "txtAbono"
            Me.txtAbono.OutputFormat = resources.GetString("txtAbono.OutputFormat")
            Me.txtAbono.Style = "font-size: 8.25pt; font-family: Tahoma"
            Me.txtAbono.Top = 0!
            Me.txtAbono.Width = 0.6230317!
            '
            'txtSaldo
            '
            Me.txtSaldo.Height = 0.1574803!
            Me.txtSaldo.Left = 1.558563!
            Me.txtSaldo.Name = "txtSaldo"
            Me.txtSaldo.OutputFormat = resources.GetString("txtSaldo.OutputFormat")
            Me.txtSaldo.Style = "font-size: 8.25pt; font-family: Tahoma"
            Me.txtSaldo.Top = 0!
            Me.txtSaldo.Width = 0.6220472!
            '
            'ActiveReport1
            '
            Me.MasterReport = false
            Me.PageSettings.DefaultPaperSize = false
            Me.PageSettings.Margins.Bottom = 0!
            Me.PageSettings.Margins.Left = 0!
            Me.PageSettings.Margins.Right = 0!
            Me.PageSettings.Margins.Top = 0!
            Me.PageSettings.PaperHeight = 11.69028!
            Me.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Custom
            Me.PageSettings.PaperWidth = 2.990278!
            Me.PrintWidth = 2.354167!
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
            CType(Me.Label1,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label3,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFolioFactura,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtAbono,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtSaldo,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        
	End Sub

#End Region

    Private Sub Detail_BeforePrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles Detail.BeforePrint
        txtFolioFactura.Text = oAbonoCreditoDirectoMgr.GetSelectFolioFacturaSDSAP(txtFolioFactura.Text)
    End Sub
End Class
