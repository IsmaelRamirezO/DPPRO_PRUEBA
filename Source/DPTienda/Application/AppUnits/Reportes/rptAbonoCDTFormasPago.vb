Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Imports DportenisPro.DPTienda.ApplicationUnits.AbonoCreditoDirectoTienda

Public Class rptAbonoCDTFormasPago
Inherits DataDynamics.ActiveReports.ActiveReport
    Public Sub New(ByVal AbonoID As Integer)
        MyBase.New()
        InitializeComponent()
        Dim dsAbonos As DataSet
        Dim oAbonoCreditoDirectoMgr As New AbonoCreditoDirectoManager(oAppContext)
        dsAbonos = oAbonoCreditoDirectoMgr.AbonosCDTFormasPagosByIDAbonos(AbonoID)

        Me.DataSource = dsAbonos
        Me.DataMember = "AbonosCreditoDirecto"
    End Sub
#Region "ActiveReports Designer generated code"
    Private WithEvents Detail As Detail = Nothing
    Private txtFormaPago As TextBox = Nothing
    Private txtMonto As TextBox = Nothing
    Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptAbonoCDTFormasPago))
            Me.Detail = New DataDynamics.ActiveReports.Detail()
            Me.txtFormaPago = New DataDynamics.ActiveReports.TextBox()
            Me.txtMonto = New DataDynamics.ActiveReports.TextBox()
            CType(Me.txtFormaPago,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtMonto,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
            '
            'Detail
            '
            Me.Detail.ColumnSpacing = 0!
            Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtFormaPago, Me.txtMonto})
            Me.Detail.Height = 0.1451389!
            Me.Detail.Name = "Detail"
            '
            'txtFormaPago
            '
            Me.txtFormaPago.DataField = "CodFormaPago"
            Me.txtFormaPago.Height = 0.125!
            Me.txtFormaPago.Left = 0.0625!
            Me.txtFormaPago.Name = "txtFormaPago"
            Me.txtFormaPago.Style = "text-align: center; font-size: 8.25pt"
            Me.txtFormaPago.Text = "TextBox3"
            Me.txtFormaPago.Top = 0!
            Me.txtFormaPago.Width = 0.5625!
            '
            'txtMonto
            '
            Me.txtMonto.DataField = "MontoPago"
            Me.txtMonto.Height = 0.125!
            Me.txtMonto.Left = 0.8125!
            Me.txtMonto.Name = "txtMonto"
            Me.txtMonto.OutputFormat = resources.GetString("txtMonto.OutputFormat")
            Me.txtMonto.Style = "text-align: right; font-size: 8.25pt"
            Me.txtMonto.Text = "TextBox4"
            Me.txtMonto.Top = 0!
            Me.txtMonto.Width = 0.9375!
            '
            'ActiveReport1
            '
            Me.MasterReport = false
            Me.PageSettings.PaperHeight = 11!
            Me.PageSettings.PaperWidth = 8.5!
            Me.PrintWidth = 1.770833!
            Me.Sections.Add(Me.Detail)
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo"& _ 
                        "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit", "Heading1", "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei"& _ 
                        "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit", "Heading2", "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo"& _ 
                        "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit", "Heading3", "Normal"))
            CType(Me.txtFormaPago,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtMonto,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        End Sub

#End Region
End Class
