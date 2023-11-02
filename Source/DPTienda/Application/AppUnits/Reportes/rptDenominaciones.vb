Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Imports DportenisPro.DPTienda.ApplicationUnits.ArqueoDeCajaAU

Public Class rptDenominaciones
Inherits DataDynamics.ActiveReports.ActiveReport
    Public Sub New(ByVal Ingreso As Decimal, ByVal TotalConteo As Decimal, ByVal bandera As Int32)
        MyBase.New()
        InitializeComponent()

        Me.txtIngresos.Text = Format(Ingreso, "c")

        Dim sobrante, Faltante As Decimal

        sobrante = Math.Max(TotalConteo - Ingreso, 0)
        Faltante = Math.Abs(Math.Min(TotalConteo - Ingreso, 0))
        Me.txtSobrante.Text = Format(sobrante, "c")
        Me.txtFaltante.Text = Format(Faltante, "c")

        If bandera = 1 Then
            Me.Label6.Text = "FONDO DE CAJA"
        ElseIf bandera = 3 Then
            Me.Label6.Text = "CAJA CHICA"
        End If

    End Sub
#Region "ActiveReports Designer generated code"
    Private WithEvents PageHeader As PageHeader = Nothing
    Private WithEvents GroupHeader1 As GroupHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents GroupFooter1 As GroupFooter = Nothing
    Private WithEvents PageFooter As PageFooter = Nothing
    Private Label1 As Label = Nothing
    Private Label2 As Label = Nothing
    Private Label3 As Label = Nothing
    Private txtDenominacion As TextBox = Nothing
    Private txtCantidad As TextBox = Nothing
    Private txtTotal As TextBox = Nothing
    Private txtTotalConteo As TextBox = Nothing
    Private txtIngresos As TextBox = Nothing
    Private txtSobrante As TextBox = Nothing
    Private txtFaltante As TextBox = Nothing
    Private Label4 As Label = Nothing
    Private Label5 As Label = Nothing
    Private Label6 As Label = Nothing
    Private Label7 As Label = Nothing
    Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptDenominaciones))
            Me.Detail = New DataDynamics.ActiveReports.Detail()
            Me.PageHeader = New DataDynamics.ActiveReports.PageHeader()
            Me.PageFooter = New DataDynamics.ActiveReports.PageFooter()
            Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader()
            Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter()
            Me.Label1 = New DataDynamics.ActiveReports.Label()
            Me.Label2 = New DataDynamics.ActiveReports.Label()
            Me.Label3 = New DataDynamics.ActiveReports.Label()
            Me.txtDenominacion = New DataDynamics.ActiveReports.TextBox()
            Me.txtCantidad = New DataDynamics.ActiveReports.TextBox()
            Me.txtTotal = New DataDynamics.ActiveReports.TextBox()
            Me.txtTotalConteo = New DataDynamics.ActiveReports.TextBox()
            Me.txtIngresos = New DataDynamics.ActiveReports.TextBox()
            Me.txtSobrante = New DataDynamics.ActiveReports.TextBox()
            Me.txtFaltante = New DataDynamics.ActiveReports.TextBox()
            Me.Label4 = New DataDynamics.ActiveReports.Label()
            Me.Label5 = New DataDynamics.ActiveReports.Label()
            Me.Label6 = New DataDynamics.ActiveReports.Label()
            Me.Label7 = New DataDynamics.ActiveReports.Label()
            CType(Me.Label1,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label3,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtDenominacion,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtCantidad,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtTotal,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtTotalConteo,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtIngresos,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtSobrante,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFaltante,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label5,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label6,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label7,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
            '
            'Detail
            '
            Me.Detail.ColumnSpacing = 0!
            Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtDenominacion, Me.txtCantidad, Me.txtTotal})
            Me.Detail.Height = 0.21875!
            Me.Detail.Name = "Detail"
            '
            'PageHeader
            '
            Me.PageHeader.Height = 0!
            Me.PageHeader.Name = "PageHeader"
            '
            'PageFooter
            '
            Me.PageFooter.Height = 0.25!
            Me.PageFooter.Name = "PageFooter"
            '
            'GroupHeader1
            '
            Me.GroupHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label1, Me.Label2, Me.Label3})
            Me.GroupHeader1.Height = 0.2291667!
            Me.GroupHeader1.Name = "GroupHeader1"
            '
            'GroupFooter1
            '
            Me.GroupFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtTotalConteo, Me.txtIngresos, Me.txtSobrante, Me.txtFaltante, Me.Label4, Me.Label5, Me.Label6, Me.Label7})
            Me.GroupFooter1.Height = 0.8229167!
            Me.GroupFooter1.Name = "GroupFooter1"
            '
            'Label1
            '
            Me.Label1.Height = 0.2!
            Me.Label1.HyperLink = Nothing
            Me.Label1.Left = 0!
            Me.Label1.Name = "Label1"
            Me.Label1.Style = "text-align: center; font-size: 8.25pt"
            Me.Label1.Text = "DENOMINACION"
            Me.Label1.Top = 0!
            Me.Label1.Width = 0.944882!
            '
            'Label2
            '
            Me.Label2.Height = 0.2!
            Me.Label2.HyperLink = Nothing
            Me.Label2.Left = 1.01624!
            Me.Label2.Name = "Label2"
            Me.Label2.Style = "text-align: center; font-size: 8.25pt"
            Me.Label2.Text = "CANTIDAD"
            Me.Label2.Top = 0!
            Me.Label2.Width = 0.6210629!
            '
            'Label3
            '
            Me.Label3.Height = 0.2!
            Me.Label3.HyperLink = Nothing
            Me.Label3.Left = 1.834153!
            Me.Label3.Name = "Label3"
            Me.Label3.Style = "text-align: center; font-size: 8.25pt"
            Me.Label3.Text = "TOTAL"
            Me.Label3.Top = 0!
            Me.Label3.Width = 0.4168309!
            '
            'txtDenominacion
            '
            Me.txtDenominacion.DataField = "Denominacion"
            Me.txtDenominacion.Height = 0.2!
            Me.txtDenominacion.Left = 0.125!
            Me.txtDenominacion.Name = "txtDenominacion"
            Me.txtDenominacion.OutputFormat = resources.GetString("txtDenominacion.OutputFormat")
            Me.txtDenominacion.Style = "text-align: right; font-size: 8.25pt"
            Me.txtDenominacion.Text = "$500.00"
            Me.txtDenominacion.Top = 0!
            Me.txtDenominacion.Width = 0.4817914!
            '
            'txtCantidad
            '
            Me.txtCantidad.DataField = "Cantidad"
            Me.txtCantidad.Height = 0.2!
            Me.txtCantidad.Left = 1.000492!
            Me.txtCantidad.Name = "txtCantidad"
            Me.txtCantidad.OutputFormat = resources.GetString("txtCantidad.OutputFormat")
            Me.txtCantidad.Style = "text-align: right; font-size: 8.25pt"
            Me.txtCantidad.Text = "100"
            Me.txtCantidad.Top = 0!
            Me.txtCantidad.Width = 0.3705707!
            '
            'txtTotal
            '
            Me.txtTotal.DataField = "Total"
            Me.txtTotal.Height = 0.2!
            Me.txtTotal.Left = 1.422244!
            Me.txtTotal.Name = "txtTotal"
            Me.txtTotal.OutputFormat = resources.GetString("txtTotal.OutputFormat")
            Me.txtTotal.Style = "text-align: right; font-size: 8.25pt"
            Me.txtTotal.Text = "TextBox3"
            Me.txtTotal.Top = 0!
            Me.txtTotal.Width = 0.8946847!
            '
            'txtTotalConteo
            '
            Me.txtTotalConteo.DataField = "Total"
            Me.txtTotalConteo.Height = 0.2!
            Me.txtTotalConteo.Left = 1.574803!
            Me.txtTotalConteo.Name = "txtTotalConteo"
            Me.txtTotalConteo.OutputFormat = resources.GetString("txtTotalConteo.OutputFormat")
            Me.txtTotalConteo.Style = "text-align: right; font-size: 8.25pt"
            Me.txtTotalConteo.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
            Me.txtTotalConteo.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
            Me.txtTotalConteo.Text = "TextBox4"
            Me.txtTotalConteo.Top = 0!
            Me.txtTotalConteo.Width = 0.7805125!
            '
            'txtIngresos
            '
            Me.txtIngresos.Height = 0.2!
            Me.txtIngresos.Left = 1.574803!
            Me.txtIngresos.Name = "txtIngresos"
            Me.txtIngresos.OutputFormat = resources.GetString("txtIngresos.OutputFormat")
            Me.txtIngresos.Style = "text-align: right; font-size: 8.25pt"
            Me.txtIngresos.Text = "TextBox5"
            Me.txtIngresos.Top = 0.1968504!
            Me.txtIngresos.Width = 0.7805125!
            '
            'txtSobrante
            '
            Me.txtSobrante.Height = 0.2!
            Me.txtSobrante.Left = 1.574803!
            Me.txtSobrante.Name = "txtSobrante"
            Me.txtSobrante.OutputFormat = resources.GetString("txtSobrante.OutputFormat")
            Me.txtSobrante.Style = "text-align: right; font-size: 8.25pt"
            Me.txtSobrante.Text = "TextBox6"
            Me.txtSobrante.Top = 0.3937007!
            Me.txtSobrante.Width = 0.7805125!
            '
            'txtFaltante
            '
            Me.txtFaltante.Height = 0.2!
            Me.txtFaltante.Left = 1.574803!
            Me.txtFaltante.Name = "txtFaltante"
            Me.txtFaltante.OutputFormat = resources.GetString("txtFaltante.OutputFormat")
            Me.txtFaltante.Style = "text-align: right; font-size: 8.25pt"
            Me.txtFaltante.Text = "TextBox7"
            Me.txtFaltante.Top = 0.5905511!
            Me.txtFaltante.Width = 0.7731299!
            '
            'Label4
            '
            Me.Label4.Height = 0.2!
            Me.Label4.HyperLink = Nothing
            Me.Label4.Left = 0.472441!
            Me.Label4.Name = "Label4"
            Me.Label4.Style = "font-size: 8.25pt"
            Me.Label4.Text = "TOTAL CONTEO"
            Me.Label4.Top = 0!
            Me.Label4.Width = 1.125492!
            '
            'Label5
            '
            Me.Label5.Height = 0.2!
            Me.Label5.HyperLink = Nothing
            Me.Label5.Left = 0.472441!
            Me.Label5.Name = "Label5"
            Me.Label5.Style = "font-size: 8.25pt"
            Me.Label5.Text = "SOBRANTE"
            Me.Label5.Top = 0.375!
            Me.Label5.Width = 1.125492!
            '
            'Label6
            '
            Me.Label6.Height = 0.2!
            Me.Label6.HyperLink = Nothing
            Me.Label6.Left = 0.472441!
            Me.Label6.Name = "Label6"
            Me.Label6.Style = "font-size: 8.25pt"
            Me.Label6.Text = "INGRESO"
            Me.Label6.Top = 0.1875!
            Me.Label6.Width = 1.125492!
            '
            'Label7
            '
            Me.Label7.Height = 0.2!
            Me.Label7.HyperLink = Nothing
            Me.Label7.Left = 0.472441!
            Me.Label7.Name = "Label7"
            Me.Label7.Style = "font-size: 8.25pt"
            Me.Label7.Text = "FALTANTE"
            Me.Label7.Top = 0.5625!
            Me.Label7.Width = 1.125492!
            '
            'ActiveReport1
            '
            Me.MasterReport = false
            Me.PageSettings.PaperHeight = 11!
            Me.PageSettings.PaperWidth = 8.5!
            Me.PrintWidth = 2.364583!
            Me.Sections.Add(Me.PageHeader)
            Me.Sections.Add(Me.GroupHeader1)
            Me.Sections.Add(Me.Detail)
            Me.Sections.Add(Me.GroupFooter1)
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
            CType(Me.txtDenominacion,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtCantidad,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtTotal,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtTotalConteo,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtIngresos,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtSobrante,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFaltante,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label5,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label6,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label7,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        End Sub

#End Region
End Class
