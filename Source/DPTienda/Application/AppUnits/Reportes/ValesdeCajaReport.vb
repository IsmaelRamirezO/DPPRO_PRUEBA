Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Public Class ValesdeCajaReport

    Inherits DataDynamics.ActiveReports.ActiveReport

    Public Sub New( _
                    ByVal datDesde As DateTime, _
                    ByVal datHasta As DateTime, _
                    ByVal strSucursal As String, _
                    ByVal dtReport As DataTable, Optional ByVal Titulo As String = "")

        MyBase.New()

        InitializeComponent()

        Me.lblFecha.Text = Format(Date.Now, "dd-MM-yyyy")

        Me.LblFechaDE.Text = Format(datDesde, "dd-MM-yyyy")

        Me.LblFechaAL.Text = Format(datHasta, "dd-MM-yyyy")
        LblSucursal.Text = strSucursal

        If Titulo <> String.Empty Then
            Me.lblReporte.Text = Titulo
        End If

        Me.DataSource = dtReport
        Me.DataMember = "ValesCaja"

    End Sub

#Region "ActiveReports Designer generated code"
    Private WithEvents ReportHeader As ReportHeader = Nothing
    Private WithEvents GroupHeader1 As GroupHeader = Nothing
    Private WithEvents Detalle As Detail = Nothing
    Private WithEvents GroupFooter1 As GroupFooter = Nothing
    Private WithEvents ReportFooter As ReportFooter = Nothing
	Private Shape1 As Shape = Nothing
	Private lblReporte As Label = Nothing
	Private lblFecha As Label = Nothing
	Private Label2 As Label = Nothing
	Private Label3 As Label = Nothing
	Private Label5 As Label = Nothing
	Private Label6 As Label = Nothing
	Private Label7 As Label = Nothing
	Private Label8 As Label = Nothing
	Private Label9 As Label = Nothing
	Private LblFechaDE As Label = Nothing
	Private Label10 As Label = Nothing
	Private LblFechaAL As Label = Nothing
	Private Label11 As Label = Nothing
	Private LblSucursal As Label = Nothing
	Private Line1 As Line = Nothing
	Private Label12 As Label = Nothing
	Private txtOrigen1 As TextBox = Nothing
	Private txtOrigen2 As TextBox = Nothing
	Private txtFolioVale As TextBox = Nothing
	Private txtFecha As TextBox = Nothing
	Private txtImporte As TextBox = Nothing
	Private txtCliente As TextBox = Nothing
	Private txtCaja As TextBox = Nothing
    Private Shape2 As Shape = Nothing
    Friend WithEvents TextBox1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label1 As DataDynamics.ActiveReports.Label
	Private txtTotal As TextBox = Nothing
	Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ValesdeCajaReport))
        Me.Detalle = New DataDynamics.ActiveReports.Detail()
        Me.txtOrigen1 = New DataDynamics.ActiveReports.TextBox()
        Me.txtOrigen2 = New DataDynamics.ActiveReports.TextBox()
        Me.txtFolioVale = New DataDynamics.ActiveReports.TextBox()
        Me.txtFecha = New DataDynamics.ActiveReports.TextBox()
        Me.txtImporte = New DataDynamics.ActiveReports.TextBox()
        Me.txtCliente = New DataDynamics.ActiveReports.TextBox()
        Me.txtCaja = New DataDynamics.ActiveReports.TextBox()
        Me.ReportHeader = New DataDynamics.ActiveReports.ReportHeader()
        Me.ReportFooter = New DataDynamics.ActiveReports.ReportFooter()
        Me.Shape2 = New DataDynamics.ActiveReports.Shape()
        Me.txtTotal = New DataDynamics.ActiveReports.TextBox()
        Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader()
        Me.Shape1 = New DataDynamics.ActiveReports.Shape()
        Me.lblReporte = New DataDynamics.ActiveReports.Label()
        Me.lblFecha = New DataDynamics.ActiveReports.Label()
        Me.Label2 = New DataDynamics.ActiveReports.Label()
        Me.Label3 = New DataDynamics.ActiveReports.Label()
        Me.Label5 = New DataDynamics.ActiveReports.Label()
        Me.Label6 = New DataDynamics.ActiveReports.Label()
        Me.Label7 = New DataDynamics.ActiveReports.Label()
        Me.Label8 = New DataDynamics.ActiveReports.Label()
        Me.Label9 = New DataDynamics.ActiveReports.Label()
        Me.LblFechaDE = New DataDynamics.ActiveReports.Label()
        Me.Label10 = New DataDynamics.ActiveReports.Label()
        Me.LblFechaAL = New DataDynamics.ActiveReports.Label()
        Me.Label11 = New DataDynamics.ActiveReports.Label()
        Me.LblSucursal = New DataDynamics.ActiveReports.Label()
        Me.Line1 = New DataDynamics.ActiveReports.Line()
        Me.Label12 = New DataDynamics.ActiveReports.Label()
        Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter()
        Me.Label1 = New DataDynamics.ActiveReports.Label()
        Me.TextBox1 = New DataDynamics.ActiveReports.TextBox()
        CType(Me.txtOrigen1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtOrigen2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFolioVale, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtImporte, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCaja, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblReporte, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblFechaDE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblFechaAL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblSucursal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detalle
        '
        Me.Detalle.ColumnSpacing = 0.0!
        Me.Detalle.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtOrigen1, Me.txtOrigen2, Me.txtFolioVale, Me.txtFecha, Me.txtImporte, Me.txtCliente, Me.txtCaja, Me.TextBox1})
        Me.Detalle.Height = 0.1875!
        Me.Detalle.Name = "Detalle"
        '
        'txtOrigen1
        '
        Me.txtOrigen1.DataField = "Origen1"
        Me.txtOrigen1.Height = 0.1875!
        Me.txtOrigen1.Left = 0.0!
        Me.txtOrigen1.Name = "txtOrigen1"
        Me.txtOrigen1.OutputFormat = resources.GetString("txtOrigen1.OutputFormat")
        Me.txtOrigen1.Style = "text-align: right; font-size: 8.25pt"
        Me.txtOrigen1.Text = Nothing
        Me.txtOrigen1.Top = 0.0!
        Me.txtOrigen1.Width = 0.75!
        '
        'txtOrigen2
        '
        Me.txtOrigen2.DataField = "Origen2"
        Me.txtOrigen2.Height = 0.1875!
        Me.txtOrigen2.Left = 0.75!
        Me.txtOrigen2.Name = "txtOrigen2"
        Me.txtOrigen2.Style = "text-align: right; font-size: 8.25pt"
        Me.txtOrigen2.Text = Nothing
        Me.txtOrigen2.Top = 0.0!
        Me.txtOrigen2.Width = 0.25!
        '
        'txtFolioVale
        '
        Me.txtFolioVale.DataField = "FolioVale"
        Me.txtFolioVale.Height = 0.1875!
        Me.txtFolioVale.Left = 1.0625!
        Me.txtFolioVale.Name = "txtFolioVale"
        Me.txtFolioVale.OutputFormat = resources.GetString("txtFolioVale.OutputFormat")
        Me.txtFolioVale.Style = "text-align: center; font-size: 8.25pt"
        Me.txtFolioVale.Text = Nothing
        Me.txtFolioVale.Top = 0.0!
        Me.txtFolioVale.Width = 0.6875!
        '
        'txtFecha
        '
        Me.txtFecha.DataField = "Fecha"
        Me.txtFecha.Height = 0.1875!
        Me.txtFecha.Left = 2.269!
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.OutputFormat = resources.GetString("txtFecha.OutputFormat")
        Me.txtFecha.Style = "text-align: center; font-size: 8.25pt"
        Me.txtFecha.Text = Nothing
        Me.txtFecha.Top = 0.0!
        Me.txtFecha.Width = 0.6330001!
        '
        'txtImporte
        '
        Me.txtImporte.DataField = "Importe"
        Me.txtImporte.Height = 0.1875!
        Me.txtImporte.Left = 2.952!
        Me.txtImporte.Name = "txtImporte"
        Me.txtImporte.OutputFormat = resources.GetString("txtImporte.OutputFormat")
        Me.txtImporte.Style = "text-align: right; font-size: 8.25pt"
        Me.txtImporte.Text = Nothing
        Me.txtImporte.Top = 0.0!
        Me.txtImporte.Width = 0.9375!
        '
        'txtCliente
        '
        Me.txtCliente.CanGrow = False
        Me.txtCliente.DataField = "Cliente"
        Me.txtCliente.Height = 0.177!
        Me.txtCliente.Left = 3.994!
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.Style = "font-size: 8.25pt"
        Me.txtCliente.Text = Nothing
        Me.txtCliente.Top = 0.01!
        Me.txtCliente.Width = 1.434!
        '
        'txtCaja
        '
        Me.txtCaja.DataField = "Caja"
        Me.txtCaja.Height = 0.1875!
        Me.txtCaja.Left = 1.862!
        Me.txtCaja.Name = "txtCaja"
        Me.txtCaja.Style = "text-align: center; font-size: 8.25pt"
        Me.txtCaja.Text = Nothing
        Me.txtCaja.Top = 0.0!
        Me.txtCaja.Width = 0.263!
        '
        'ReportHeader
        '
        Me.ReportHeader.Height = 0.0!
        Me.ReportHeader.Name = "ReportHeader"
        '
        'ReportFooter
        '
        Me.ReportFooter.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape2, Me.txtTotal})
        Me.ReportFooter.Height = 0.2597222!
        Me.ReportFooter.Name = "ReportFooter"
        '
        'Shape2
        '
        Me.Shape2.Height = 0.25!
        Me.Shape2.Left = 0.0!
        Me.Shape2.Name = "Shape2"
        Me.Shape2.RoundingRadius = 9.999999!
        Me.Shape2.Top = 0.0!
        Me.Shape2.Width = 6.6875!
        '
        'txtTotal
        '
        Me.txtTotal.DataField = "Importe"
        Me.txtTotal.Height = 0.1875!
        Me.txtTotal.Left = 2.914!
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.OutputFormat = resources.GetString("txtTotal.OutputFormat")
        Me.txtTotal.Style = "text-align: right; font-size: 8.25pt"
        Me.txtTotal.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.txtTotal.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
        Me.txtTotal.Text = Nothing
        Me.txtTotal.Top = 0.072!
        Me.txtTotal.Width = 0.9375!
        '
        'GroupHeader1
        '
        Me.GroupHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape1, Me.lblReporte, Me.lblFecha, Me.Label2, Me.Label3, Me.Label5, Me.Label6, Me.Label7, Me.Label8, Me.Label9, Me.LblFechaDE, Me.Label10, Me.LblFechaAL, Me.Label11, Me.LblSucursal, Me.Line1, Me.Label12, Me.Label1})
        Me.GroupHeader1.Height = 1.075!
        Me.GroupHeader1.Name = "GroupHeader1"
        '
        'Shape1
        '
        Me.Shape1.Height = 0.8125!
        Me.Shape1.Left = 0.0!
        Me.Shape1.Name = "Shape1"
        Me.Shape1.RoundingRadius = 9.999999!
        Me.Shape1.Top = 0.0!
        Me.Shape1.Width = 6.6875!
        '
        'lblReporte
        '
        Me.lblReporte.Height = 0.2!
        Me.lblReporte.HyperLink = Nothing
        Me.lblReporte.Left = 1.9!
        Me.lblReporte.Name = "lblReporte"
        Me.lblReporte.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
        Me.lblReporte.Text = "Reporte de Vales de Caja"
        Me.lblReporte.Top = 0.0!
        Me.lblReporte.Width = 2.999344!
        '
        'lblFecha
        '
        Me.lblFecha.Height = 0.2!
        Me.lblFecha.HyperLink = Nothing
        Me.lblFecha.Left = 0.5625!
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Style = "font-size: 8.25pt"
        Me.lblFecha.Text = "Fecha"
        Me.lblFecha.Top = 0.0!
        Me.lblFecha.Width = 0.875!
        '
        'Label2
        '
        Me.Label2.Height = 0.2!
        Me.Label2.HyperLink = Nothing
        Me.Label2.Left = 0.0625!
        Me.Label2.Name = "Label2"
        Me.Label2.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
        Me.Label2.Text = "Origen"
        Me.Label2.Top = 0.625!
        Me.Label2.Width = 0.875!
        '
        'Label3
        '
        Me.Label3.Height = 0.2!
        Me.Label3.HyperLink = Nothing
        Me.Label3.Left = 1.0!
        Me.Label3.Name = "Label3"
        Me.Label3.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
        Me.Label3.Text = "Folio"
        Me.Label3.Top = 0.625!
        Me.Label3.Width = 0.75!
        '
        'Label5
        '
        Me.Label5.Height = 0.2!
        Me.Label5.HyperLink = Nothing
        Me.Label5.Left = 1.757!
        Me.Label5.Name = "Label5"
        Me.Label5.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
        Me.Label5.Text = "Caja"
        Me.Label5.Top = 0.625!
        Me.Label5.Width = 0.5!
        '
        'Label6
        '
        Me.Label6.Height = 0.2!
        Me.Label6.HyperLink = Nothing
        Me.Label6.Left = 2.309!
        Me.Label6.Name = "Label6"
        Me.Label6.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
        Me.Label6.Text = "Fecha"
        Me.Label6.Top = 0.625!
        Me.Label6.Width = 0.563!
        '
        'Label7
        '
        Me.Label7.Height = 0.2!
        Me.Label7.HyperLink = Nothing
        Me.Label7.Left = 3.014!
        Me.Label7.Name = "Label7"
        Me.Label7.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
        Me.Label7.Text = "Utilizado"
        Me.Label7.Top = 0.625!
        Me.Label7.Width = 0.875!
        '
        'Label8
        '
        Me.Label8.Height = 0.2!
        Me.Label8.HyperLink = Nothing
        Me.Label8.Left = 4.141949!
        Me.Label8.Name = "Label8"
        Me.Label8.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
        Me.Label8.Text = "Cliente"
        Me.Label8.Top = 0.625!
        Me.Label8.Width = 1.086051!
        '
        'Label9
        '
        Me.Label9.Height = 0.1811025!
        Me.Label9.HyperLink = Nothing
        Me.Label9.Left = 2.25!
        Me.Label9.Name = "Label9"
        Me.Label9.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8." & _
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
        Me.LblFechaDE.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: normal; font-size: " & _
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
        Me.Label10.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8." & _
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
        Me.LblFechaAL.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: normal; font-size: " & _
    "8.25pt; font-family: Arial"
        Me.LblFechaAL.Text = "LblFechaAL"
        Me.LblFechaAL.Top = 0.1875!
        Me.LblFechaAL.Width = 0.9685042!
        '
        'Label11
        '
        Me.Label11.Height = 0.1811025!
        Me.Label11.HyperLink = Nothing
        Me.Label11.Left = 1.4375!
        Me.Label11.Name = "Label11"
        Me.Label11.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8." & _
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
        Me.LblSucursal.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: normal; font-size: " & _
    "8.25pt; font-family: Arial"
        Me.LblSucursal.Text = "LblSucursal"
        Me.LblSucursal.Top = 0.375!
        Me.LblSucursal.Width = 3.448326!
        '
        'Line1
        '
        Me.Line1.Height = 0.0!
        Me.Line1.Left = 0.006944444!
        Me.Line1.LineWeight = 1.0!
        Me.Line1.Name = "Line1"
        Me.Line1.Top = 0.5902777!
        Me.Line1.Width = 6.6875!
        Me.Line1.X1 = 0.006944444!
        Me.Line1.X2 = 6.694445!
        Me.Line1.Y1 = 0.5902777!
        Me.Line1.Y2 = 0.5902777!
        '
        'Label12
        '
        Me.Label12.Height = 0.1875!
        Me.Label12.HyperLink = Nothing
        Me.Label12.Left = 0.0625!
        Me.Label12.Name = "Label12"
        Me.Label12.Style = "font-weight: bold; font-size: 8.25pt; font-family: Arial"
        Me.Label12.Text = "Fecha :"
        Me.Label12.Top = 0.0!
        Me.Label12.Width = 0.4375!
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Height = 0.0!
        Me.GroupFooter1.Name = "GroupFooter1"
        '
        'Label1
        '
        Me.Label1.Height = 0.2!
        Me.Label1.HyperLink = Nothing
        Me.Label1.Left = 5.63!
        Me.Label1.Name = "Label1"
        Me.Label1.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
        Me.Label1.Text = "Referencia"
        Me.Label1.Top = 0.625!
        Me.Label1.Width = 0.937!
        '
        'TextBox1
        '
        Me.TextBox1.CanGrow = False
        Me.TextBox1.DataField = "Referencia"
        Me.TextBox1.Height = 0.1875!
        Me.TextBox1.Left = 5.498!
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Style = "font-size: 8.25pt"
        Me.TextBox1.Text = Nothing
        Me.TextBox1.Top = 0.0!
        Me.TextBox1.Width = 1.189!
        '
        'ValesdeCajaReport
        '
        Me.MasterReport = False
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 6.729167!
        Me.Sections.Add(Me.ReportHeader)
        Me.Sections.Add(Me.GroupHeader1)
        Me.Sections.Add(Me.Detalle)
        Me.Sections.Add(Me.GroupFooter1)
        Me.Sections.Add(Me.ReportFooter)
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" & _
            "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei" & _
            "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" & _
            "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit", "Heading3", "Normal"))
        CType(Me.txtOrigen1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtOrigen2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFolioVale, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtImporte, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCliente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCaja, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblReporte, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblFechaDE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblFechaAL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblSucursal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

#End Region

End Class
