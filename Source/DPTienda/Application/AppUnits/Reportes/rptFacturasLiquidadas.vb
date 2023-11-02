Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Public Class rptFacturasLiquidadas

    Inherits DataDynamics.ActiveReports.ActiveReport

    Public Sub New(ByVal data As DataSet, ByVal daFecha As Date, ByVal Almacen As String)

        MyBase.New()

        InitializeComponent()

        Me.DataSource = data

        Me.DataMember = data.Tables(0).TableName

        Me.lblFecha.Text = Format(Date.Now, "dd-MM-yyyy")

        Me.LblFechaDE.Text = Format(daFecha, "dd-MM-yyyy")

        Me.LblFechaAL.Text = Format(daFecha, "dd-MM-yyyy")

        LblSucursal.Text = Almacen


        Me.PageSettings.Margins.Left = 0.5

    End Sub

#Region "ActiveReports Designer generated code"
    Private WithEvents ReportHeader As ReportHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents ReportFooter As ReportFooter = Nothing
    Private Shape1 As Shape = Nothing
    Private Label1 As Label = Nothing
    Private Label2 As Label = Nothing
    Private Label3 As Label = Nothing
    Private Label4 As Label = Nothing
    Private Label5 As Label = Nothing
    Private Label6 As Label = Nothing
    Private Label7 As Label = Nothing
    Private Label12 As Label = Nothing
    Private lblFecha As Label = Nothing
    Private Label11 As Label = Nothing
    Private LblSucursal As Label = Nothing
    Private Label9 As Label = Nothing
    Private LblFechaDE As Label = Nothing
    Private Label10 As Label = Nothing
    Private LblFechaAL As Label = Nothing
    Private Line1 As Line = Nothing
    Private txtFolioFactura As TextBox = Nothing
    Private txtImporte As TextBox = Nothing
    Private txtApartado As TextBox = Nothing
    Private txtAbonos As TextBox = Nothing
    Private txtUsuario As TextBox = Nothing
    Private txtFecha As TextBox = Nothing
    Private Shape2 As Shape = Nothing
    Private TextBox2 As TextBox = Nothing
    Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptFacturasLiquidadas))
            Me.Detail = New DataDynamics.ActiveReports.Detail()
            Me.ReportHeader = New DataDynamics.ActiveReports.ReportHeader()
            Me.ReportFooter = New DataDynamics.ActiveReports.ReportFooter()
            Me.Shape1 = New DataDynamics.ActiveReports.Shape()
            Me.Label1 = New DataDynamics.ActiveReports.Label()
            Me.Label2 = New DataDynamics.ActiveReports.Label()
            Me.Label3 = New DataDynamics.ActiveReports.Label()
            Me.Label4 = New DataDynamics.ActiveReports.Label()
            Me.Label5 = New DataDynamics.ActiveReports.Label()
            Me.Label6 = New DataDynamics.ActiveReports.Label()
            Me.Label7 = New DataDynamics.ActiveReports.Label()
            Me.Label12 = New DataDynamics.ActiveReports.Label()
            Me.lblFecha = New DataDynamics.ActiveReports.Label()
            Me.Label11 = New DataDynamics.ActiveReports.Label()
            Me.LblSucursal = New DataDynamics.ActiveReports.Label()
            Me.Label9 = New DataDynamics.ActiveReports.Label()
            Me.LblFechaDE = New DataDynamics.ActiveReports.Label()
            Me.Label10 = New DataDynamics.ActiveReports.Label()
            Me.LblFechaAL = New DataDynamics.ActiveReports.Label()
            Me.Line1 = New DataDynamics.ActiveReports.Line()
            Me.txtFolioFactura = New DataDynamics.ActiveReports.TextBox()
            Me.txtImporte = New DataDynamics.ActiveReports.TextBox()
            Me.txtApartado = New DataDynamics.ActiveReports.TextBox()
            Me.txtAbonos = New DataDynamics.ActiveReports.TextBox()
            Me.txtUsuario = New DataDynamics.ActiveReports.TextBox()
            Me.txtFecha = New DataDynamics.ActiveReports.TextBox()
            Me.Shape2 = New DataDynamics.ActiveReports.Shape()
            Me.TextBox2 = New DataDynamics.ActiveReports.TextBox()
            CType(Me.Label1,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label3,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label5,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label6,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label7,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label12,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblFecha,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label11,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.LblSucursal,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label9,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.LblFechaDE,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label10,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.LblFechaAL,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFolioFactura,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtImporte,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtApartado,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtAbonos,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtUsuario,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFecha,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox2,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
            '
            'Detail
            '
            Me.Detail.ColumnSpacing = 0!
            Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtFolioFactura, Me.txtImporte, Me.txtApartado, Me.txtAbonos, Me.txtUsuario, Me.txtFecha})
            Me.Detail.Height = 0.1763889!
            Me.Detail.Name = "Detail"
            '
            'ReportHeader
            '
            Me.ReportHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape1, Me.Label1, Me.Label2, Me.Label3, Me.Label4, Me.Label5, Me.Label6, Me.Label7, Me.Label12, Me.lblFecha, Me.Label11, Me.LblSucursal, Me.Label9, Me.LblFechaDE, Me.Label10, Me.LblFechaAL, Me.Line1})
            Me.ReportHeader.Height = 0.84375!
            Me.ReportHeader.Name = "ReportHeader"
            '
            'ReportFooter
            '
            Me.ReportFooter.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape2, Me.TextBox2})
            Me.ReportFooter.Height = 0.2708333!
            Me.ReportFooter.Name = "ReportFooter"
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
            'Label1
            '
            Me.Label1.Height = 0.1375!
            Me.Label1.HyperLink = Nothing
            Me.Label1.Left = 0.0625!
            Me.Label1.Name = "Label1"
            Me.Label1.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
            Me.Label1.Text = "F. Fact."
            Me.Label1.Top = 0.625!
            Me.Label1.Width = 0.5625!
            '
            'Label2
            '
            Me.Label2.Height = 0.1375!
            Me.Label2.HyperLink = Nothing
            Me.Label2.Left = 0.6875!
            Me.Label2.Name = "Label2"
            Me.Label2.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
            Me.Label2.Text = "Importe"
            Me.Label2.Top = 0.625!
            Me.Label2.Width = 0.75!
            '
            'Label3
            '
            Me.Label3.Height = 0.1375!
            Me.Label3.HyperLink = Nothing
            Me.Label3.Left = 1.5625!
            Me.Label3.Name = "Label3"
            Me.Label3.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
            Me.Label3.Text = "Fol. Apart."
            Me.Label3.Top = 0.625!
            Me.Label3.Width = 0.6875!
            '
            'Label4
            '
            Me.Label4.Height = 0.1375!
            Me.Label4.HyperLink = Nothing
            Me.Label4.Left = 2.3125!
            Me.Label4.Name = "Label4"
            Me.Label4.Style = "text-align: justify; font-weight: bold; font-size: 8.25pt"
            Me.Label4.Text = " Folio Abonos"
            Me.Label4.Top = 0.625!
            Me.Label4.Width = 2.6875!
            '
            'Label5
            '
            Me.Label5.Height = 0.1375!
            Me.Label5.HyperLink = Nothing
            Me.Label5.Left = 5.0625!
            Me.Label5.Name = "Label5"
            Me.Label5.Style = "text-align: justify; font-weight: bold; font-size: 8.25pt"
            Me.Label5.Text = " Usuario"
            Me.Label5.Top = 0.625!
            Me.Label5.Width = 0.9375!
            '
            'Label6
            '
            Me.Label6.Height = 0.1375!
            Me.Label6.HyperLink = Nothing
            Me.Label6.Left = 6.1875!
            Me.Label6.Name = "Label6"
            Me.Label6.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
            Me.Label6.Text = "Fecha"
            Me.Label6.Top = 0.625!
            Me.Label6.Width = 0.5625!
            '
            'Label7
            '
            Me.Label7.Height = 0.2!
            Me.Label7.HyperLink = Nothing
            Me.Label7.Left = 2.40625!
            Me.Label7.Name = "Label7"
            Me.Label7.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
            Me.Label7.Text = "Reporte de Liquidaciones"
            Me.Label7.Top = 0!
            Me.Label7.Width = 2.3125!
            '
            'Label12
            '
            Me.Label12.Height = 0.1875!
            Me.Label12.HyperLink = Nothing
            Me.Label12.Left = 0.0625!
            Me.Label12.Name = "Label12"
            Me.Label12.Style = "font-weight: bold; font-size: 8.25pt; font-family: Arial"
            Me.Label12.Text = "Fecha :"
            Me.Label12.Top = 0!
            Me.Label12.Width = 0.4375!
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
            'Label11
            '
            Me.Label11.Height = 0.1811025!
            Me.Label11.HyperLink = Nothing
            Me.Label11.Left = 1.4375!
            Me.Label11.Name = "Label11"
            Me.Label11.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8."& _ 
                "25pt; font-family: Arial"
            Me.Label11.Text = "Sucursal:"
            Me.Label11.Top = 0.375!
            Me.Label11.Width = 0.5625!
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
            'Label9
            '
            Me.Label9.Height = 0.1811025!
            Me.Label9.HyperLink = Nothing
            Me.Label9.Left = 2.25!
            Me.Label9.Name = "Label9"
            Me.Label9.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8."& _ 
                "25pt; font-family: Arial"
            Me.Label9.Text = "De:"
            Me.Label9.Top = 0.1875!
            Me.Label9.Width = 0.2810042!
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
            'Label10
            '
            Me.Label10.Height = 0.1811025!
            Me.Label10.HyperLink = Nothing
            Me.Label10.Left = 3.5625!
            Me.Label10.Name = "Label10"
            Me.Label10.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8."& _ 
                "25pt; font-family: Arial"
            Me.Label10.Text = "Al:"
            Me.Label10.Top = 0.1875!
            Me.Label10.Width = 0.2810042!
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
            'Line1
            '
            Me.Line1.Height = 0!
            Me.Line1.Left = 0!
            Me.Line1.LineWeight = 1!
            Me.Line1.Name = "Line1"
            Me.Line1.Top = 0.5625!
            Me.Line1.Width = 6.875!
            Me.Line1.X1 = 0!
            Me.Line1.X2 = 6.875!
            Me.Line1.Y1 = 0.5625!
            Me.Line1.Y2 = 0.5625!
            '
            'txtFolioFactura
            '
            Me.txtFolioFactura.DataField = "FolioFactura"
            Me.txtFolioFactura.Height = 0.2!
            Me.txtFolioFactura.Left = 0!
            Me.txtFolioFactura.Name = "txtFolioFactura"
            Me.txtFolioFactura.Style = "text-align: right; font-size: 8.25pt"
            Me.txtFolioFactura.Text = "Factura"
            Me.txtFolioFactura.Top = 0!
            Me.txtFolioFactura.Width = 0.625!
            '
            'txtImporte
            '
            Me.txtImporte.DataField = "Total"
            Me.txtImporte.Height = 0.2!
            Me.txtImporte.Left = 0.6875!
            Me.txtImporte.Name = "txtImporte"
            Me.txtImporte.OutputFormat = resources.GetString("txtImporte.OutputFormat")
            Me.txtImporte.Style = "text-align: right; font-size: 8.25pt"
            Me.txtImporte.Text = "Importe"
            Me.txtImporte.Top = 0!
            Me.txtImporte.Width = 0.8125!
            '
            'txtApartado
            '
            Me.txtApartado.DataField = "FolioApartado"
            Me.txtApartado.Height = 0.2!
            Me.txtApartado.Left = 1.5625!
            Me.txtApartado.Name = "txtApartado"
            Me.txtApartado.Style = "text-align: right; font-size: 8.25pt"
            Me.txtApartado.Text = "Apartado"
            Me.txtApartado.Top = 0!
            Me.txtApartado.Width = 0.6875!
            '
            'txtAbonos
            '
            Me.txtAbonos.DataField = "Abonos"
            Me.txtAbonos.Height = 0.2!
            Me.txtAbonos.Left = 2.3125!
            Me.txtAbonos.Name = "txtAbonos"
            Me.txtAbonos.Style = "font-size: 8.25pt"
            Me.txtAbonos.Text = "Abonos"
            Me.txtAbonos.Top = 0!
            Me.txtAbonos.Width = 2.6875!
            '
            'txtUsuario
            '
            Me.txtUsuario.DataField = "CodVendedor"
            Me.txtUsuario.Height = 0.2!
            Me.txtUsuario.Left = 5.0625!
            Me.txtUsuario.Name = "txtUsuario"
            Me.txtUsuario.Style = "font-size: 8.25pt"
            Me.txtUsuario.Text = "Usuario"
            Me.txtUsuario.Top = 0!
            Me.txtUsuario.Width = 1!
            '
            'txtFecha
            '
            Me.txtFecha.DataField = "Fecha"
            Me.txtFecha.Height = 0.2!
            Me.txtFecha.Left = 6.125!
            Me.txtFecha.Name = "txtFecha"
            Me.txtFecha.OutputFormat = resources.GetString("txtFecha.OutputFormat")
            Me.txtFecha.Style = "text-align: center; font-size: 8.25pt"
            Me.txtFecha.Text = "00/00/0000"
            Me.txtFecha.Top = 0!
            Me.txtFecha.Width = 0.75!
            '
            'Shape2
            '
            Me.Shape2.Height = 0.25!
            Me.Shape2.Left = 0!
            Me.Shape2.Name = "Shape2"
            Me.Shape2.RoundingRadius = 9.999999!
            Me.Shape2.Top = 0!
            Me.Shape2.Width = 6.875!
            '
            'TextBox2
            '
            Me.TextBox2.DataField = "Total"
            Me.TextBox2.Height = 0.2!
            Me.TextBox2.Left = 0.1875!
            Me.TextBox2.Name = "TextBox2"
            Me.TextBox2.OutputFormat = resources.GetString("TextBox2.OutputFormat")
            Me.TextBox2.Style = "text-align: right; font-weight: normal; font-size: 8.25pt"
            Me.TextBox2.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
            Me.TextBox2.Text = "Importe"
            Me.TextBox2.Top = 0!
            Me.TextBox2.Width = 1.3125!
            '
            'ActiveReport1
            '
            Me.MasterReport = false
            Me.PageSettings.PaperHeight = 11!
            Me.PageSettings.PaperWidth = 8.5!
            Me.PrintWidth = 7.125!
            Me.Sections.Add(Me.ReportHeader)
            Me.Sections.Add(Me.Detail)
            Me.Sections.Add(Me.ReportFooter)
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
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label5,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label6,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label7,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label12,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblFecha,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label11,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.LblSucursal,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label9,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.LblFechaDE,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label10,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.LblFechaAL,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFolioFactura,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtImporte,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtApartado,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtAbonos,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtUsuario,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFecha,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox2,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        End Sub

#End Region

End Class
