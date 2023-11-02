Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Public Class rptFacturasAbonodasCDT
Inherits DataDynamics.ActiveReports.ActiveReport
    Public Sub New(ByVal dsFacturas As DataSet)
        MyBase.New()
        InitializeComponent()


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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptFacturasAbonodasCDT))
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
            Me.Detail.Height = 0.21875!
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
            Me.Label1.Height = 0.2!
            Me.Label1.HyperLink = Nothing
            Me.Label1.Left = 0.0625!
            Me.Label1.Name = "Label1"
            Me.Label1.Style = ""
            Me.Label1.Text = "Factura"
            Me.Label1.Top = 0.0625!
            Me.Label1.Width = 1!
            '
            'Label2
            '
            Me.Label2.Height = 0.2!
            Me.Label2.HyperLink = Nothing
            Me.Label2.Left = 1.338583!
            Me.Label2.Name = "Label2"
            Me.Label2.Style = ""
            Me.Label2.Text = "Abono"
            Me.Label2.Top = 0.03937007!
            Me.Label2.Width = 1!
            '
            'Label3
            '
            Me.Label3.Height = 0.2!
            Me.Label3.HyperLink = Nothing
            Me.Label3.Left = 2.480315!
            Me.Label3.Name = "Label3"
            Me.Label3.Style = ""
            Me.Label3.Text = "Saldo"
            Me.Label3.Top = 0.03937007!
            Me.Label3.Width = 1!
            '
            'txtFolioFactura
            '
            Me.txtFolioFactura.Height = 0.2!
            Me.txtFolioFactura.Left = 0.03937007!
            Me.txtFolioFactura.Name = "txtFolioFactura"
            Me.txtFolioFactura.Style = "text-align: right; font-size: 9pt; font-family: Arial"
            Me.txtFolioFactura.Text = "TextBox1"
            Me.txtFolioFactura.Top = 0!
            Me.txtFolioFactura.Width = 1!
            '
            'txtAbono
            '
            Me.txtAbono.Height = 0.2!
            Me.txtAbono.Left = 1.345472!
            Me.txtAbono.Name = "txtAbono"
            Me.txtAbono.OutputFormat = resources.GetString("txtAbono.OutputFormat")
            Me.txtAbono.Style = "font-size: 9pt; font-family: Arial"
            Me.txtAbono.Text = "TextBox2"
            Me.txtAbono.Top = 0!
            Me.txtAbono.Width = 1!
            '
            'txtSaldo
            '
            Me.txtSaldo.Height = 0.2!
            Me.txtSaldo.Left = 2.487205!
            Me.txtSaldo.Name = "txtSaldo"
            Me.txtSaldo.OutputFormat = resources.GetString("txtSaldo.OutputFormat")
            Me.txtSaldo.Style = "font-size: 9pt; font-family: Arial"
            Me.txtSaldo.Text = "TextBox3"
            Me.txtSaldo.Top = 0!
            Me.txtSaldo.Width = 1!
            '
            'ActiveReport1
            '
            Me.MasterReport = false
            Me.PageSettings.DefaultPaperSize = false
            Me.PageSettings.PaperHeight = 11!
            Me.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Custom
            Me.PageSettings.PaperWidth = 4.724306!
            Me.PrintWidth = 3.625!
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

End Class
