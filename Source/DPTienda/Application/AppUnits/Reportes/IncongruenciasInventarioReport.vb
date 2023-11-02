Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Public Class IncongruenciasInventarioReport

    Inherits DataDynamics.ActiveReports.ActiveReport

    Public Sub New(ByVal Data As DataTable, ByVal Sucursal As String)

        MyBase.New()

        InitializeComponent()

        Me.lblSucursal.Text = Sucursal
        Me.lblFecha.Text = Format(Date.Now, "short date")

        Me.DataSource = Data
        Me.DataMember = Data.TableName

        Me.Run()

    End Sub

#Region "ActiveReports Designer generated code"
    Private WithEvents PageHeader As PageHeader = Nothing
    Private WithEvents GroupHeader1 As GroupHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents GroupFooter1 As GroupFooter = Nothing
    Private WithEvents PageFooter As PageFooter = Nothing
	Private Shape1 As Shape = Nothing
	Private Label1 As Label = Nothing
	Private Label3 As Label = Nothing
	Private Label4 As Label = Nothing
	Private Label5 As Label = Nothing
	Private Label6 As Label = Nothing
	Private lblFecha As Label = Nothing
	Private Label8 As Label = Nothing
	Private txtPag As TextBox = Nothing
	Private lblSucursal As Label = Nothing
	Private Line1 As Line = Nothing
	Private Line2 As Line = Nothing
	Private Line3 As Line = Nothing
	Private Line4 As Line = Nothing
	Private txtSucursal As TextBox = Nothing
	Private txtCodigo As TextBox = Nothing
	Private txtHistorico As TextBox = Nothing
	Private txtInventario As TextBox = Nothing
	Private Line5 As Line = Nothing
	Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(IncongruenciasInventarioReport))
            Me.Detail = New DataDynamics.ActiveReports.Detail()
            Me.PageHeader = New DataDynamics.ActiveReports.PageHeader()
            Me.PageFooter = New DataDynamics.ActiveReports.PageFooter()
            Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader()
            Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter()
            Me.Shape1 = New DataDynamics.ActiveReports.Shape()
            Me.Label1 = New DataDynamics.ActiveReports.Label()
            Me.Label3 = New DataDynamics.ActiveReports.Label()
            Me.Label4 = New DataDynamics.ActiveReports.Label()
            Me.Label5 = New DataDynamics.ActiveReports.Label()
            Me.Label6 = New DataDynamics.ActiveReports.Label()
            Me.lblFecha = New DataDynamics.ActiveReports.Label()
            Me.Label8 = New DataDynamics.ActiveReports.Label()
            Me.txtPag = New DataDynamics.ActiveReports.TextBox()
            Me.lblSucursal = New DataDynamics.ActiveReports.Label()
            Me.Line1 = New DataDynamics.ActiveReports.Line()
            Me.Line2 = New DataDynamics.ActiveReports.Line()
            Me.Line3 = New DataDynamics.ActiveReports.Line()
            Me.Line4 = New DataDynamics.ActiveReports.Line()
            Me.txtSucursal = New DataDynamics.ActiveReports.TextBox()
            Me.txtCodigo = New DataDynamics.ActiveReports.TextBox()
            Me.txtHistorico = New DataDynamics.ActiveReports.TextBox()
            Me.txtInventario = New DataDynamics.ActiveReports.TextBox()
            Me.Line5 = New DataDynamics.ActiveReports.Line()
            CType(Me.Label1,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label3,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label5,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label6,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblFecha,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label8,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtPag,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblSucursal,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtSucursal,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtCodigo,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtHistorico,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtInventario,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
            '
            'Detail
            '
            Me.Detail.ColumnSpacing = 0!
            Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtSucursal, Me.txtCodigo, Me.txtHistorico, Me.txtInventario})
            Me.Detail.Height = 0.1979167!
            Me.Detail.Name = "Detail"
            '
            'PageHeader
            '
            Me.PageHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape1, Me.Label1, Me.Label3, Me.Label4, Me.Label5, Me.Label6, Me.lblFecha, Me.Label8, Me.txtPag, Me.lblSucursal, Me.Line1, Me.Line2, Me.Line3, Me.Line4})
            Me.PageHeader.Height = 0.8229167!
            Me.PageHeader.Name = "PageHeader"
            '
            'PageFooter
            '
            Me.PageFooter.Height = 0!
            Me.PageFooter.Name = "PageFooter"
            '
            'GroupHeader1
            '
            Me.GroupHeader1.Height = 0!
            Me.GroupHeader1.Name = "GroupHeader1"
            '
            'GroupFooter1
            '
            Me.GroupFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Line5})
            Me.GroupFooter1.Height = 0.02083333!
            Me.GroupFooter1.Name = "GroupFooter1"
            '
            'Shape1
            '
            Me.Shape1.Height = 0.8125!
            Me.Shape1.Left = 0!
            Me.Shape1.Name = "Shape1"
            Me.Shape1.RoundingRadius = 9.999999!
            Me.Shape1.Top = 0!
            Me.Shape1.Width = 6.4375!
            '
            'Label1
            '
            Me.Label1.Height = 0.2!
            Me.Label1.HyperLink = Nothing
            Me.Label1.Left = 0.875!
            Me.Label1.Name = "Label1"
            Me.Label1.Style = "text-align: center"
            Me.Label1.Text = "REPORTE DE CODIGOS CON PROBLEMAS EN HISTORICO E INVENTARIO"
            Me.Label1.Top = 0.0625!
            Me.Label1.Width = 4.9375!
            '
            'Label3
            '
            Me.Label3.Height = 0.2!
            Me.Label3.HyperLink = Nothing
            Me.Label3.Left = 4.125!
            Me.Label3.Name = "Label3"
            Me.Label3.Style = "text-align: center; font-size: 8pt"
            Me.Label3.Text = "HISTORICO"
            Me.Label3.Top = 0.625!
            Me.Label3.Width = 1!
            '
            'Label4
            '
            Me.Label4.Height = 0.2!
            Me.Label4.HyperLink = Nothing
            Me.Label4.Left = 5.3125!
            Me.Label4.Name = "Label4"
            Me.Label4.Style = "text-align: center; font-size: 8pt"
            Me.Label4.Text = "INVENTARIO"
            Me.Label4.Top = 0.625!
            Me.Label4.Width = 1!
            '
            'Label5
            '
            Me.Label5.Height = 0.2!
            Me.Label5.HyperLink = Nothing
            Me.Label5.Left = 1.25!
            Me.Label5.Name = "Label5"
            Me.Label5.Style = "text-align: justify; font-size: 8pt"
            Me.Label5.Text = "CODIGO"
            Me.Label5.Top = 0.625!
            Me.Label5.Width = 1!
            '
            'Label6
            '
            Me.Label6.Height = 0.2!
            Me.Label6.HyperLink = Nothing
            Me.Label6.Left = 0.0625!
            Me.Label6.Name = "Label6"
            Me.Label6.Style = "text-align: center; font-size: 8pt"
            Me.Label6.Text = "SUCURSAL"
            Me.Label6.Top = 0.625!
            Me.Label6.Width = 0.75!
            '
            'lblFecha
            '
            Me.lblFecha.Height = 0.2!
            Me.lblFecha.HyperLink = Nothing
            Me.lblFecha.Left = 0.0625!
            Me.lblFecha.Name = "lblFecha"
            Me.lblFecha.Style = ""
            Me.lblFecha.Text = "lblFecha"
            Me.lblFecha.Top = 0.3125!
            Me.lblFecha.Width = 0.875!
            '
            'Label8
            '
            Me.Label8.Height = 0.2!
            Me.Label8.HyperLink = Nothing
            Me.Label8.Left = 5.5625!
            Me.Label8.Name = "Label8"
            Me.Label8.Style = ""
            Me.Label8.Text = "Pag. :"
            Me.Label8.Top = 0.3125!
            Me.Label8.Width = 0.375!
            '
            'txtPag
            '
            Me.txtPag.Height = 0.2!
            Me.txtPag.Left = 6!
            Me.txtPag.Name = "txtPag"
            Me.txtPag.Style = "text-align: right"
            Me.txtPag.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
            Me.txtPag.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount
            Me.txtPag.Text = "###"
            Me.txtPag.Top = 0.3125!
            Me.txtPag.Width = 0.375!
            '
            'lblSucursal
            '
            Me.lblSucursal.Height = 0.2!
            Me.lblSucursal.HyperLink = Nothing
            Me.lblSucursal.Left = 1!
            Me.lblSucursal.Name = "lblSucursal"
            Me.lblSucursal.Style = "text-align: center"
            Me.lblSucursal.Text = "Sucursal :"
            Me.lblSucursal.Top = 0.3125!
            Me.lblSucursal.Width = 4.5!
            '
            'Line1
            '
            Me.Line1.Height = 0!
            Me.Line1.Left = 0!
            Me.Line1.LineWeight = 1!
            Me.Line1.Name = "Line1"
            Me.Line1.Top = 0.625!
            Me.Line1.Width = 6.4375!
            Me.Line1.X1 = 6.4375!
            Me.Line1.X2 = 0!
            Me.Line1.Y1 = 0.625!
            Me.Line1.Y2 = 0.625!
            '
            'Line2
            '
            Me.Line2.Height = 0.1875!
            Me.Line2.Left = 5.25!
            Me.Line2.LineWeight = 1!
            Me.Line2.Name = "Line2"
            Me.Line2.Top = 0.625!
            Me.Line2.Width = 0!
            Me.Line2.X1 = 5.25!
            Me.Line2.X2 = 5.25!
            Me.Line2.Y1 = 0.625!
            Me.Line2.Y2 = 0.8125!
            '
            'Line3
            '
            Me.Line3.Height = 0.1875001!
            Me.Line3.Left = 4.006945!
            Me.Line3.LineWeight = 1!
            Me.Line3.Name = "Line3"
            Me.Line3.Top = 0.6319444!
            Me.Line3.Width = 0!
            Me.Line3.X1 = 4.006945!
            Me.Line3.X2 = 4.006945!
            Me.Line3.Y1 = 0.6319444!
            Me.Line3.Y2 = 0.8194444!
            '
            'Line4
            '
            Me.Line4.Height = 0.1875001!
            Me.Line4.Left = 0.8194444!
            Me.Line4.LineWeight = 1!
            Me.Line4.Name = "Line4"
            Me.Line4.Top = 0.6319444!
            Me.Line4.Width = 0!
            Me.Line4.X1 = 0.8194444!
            Me.Line4.X2 = 0.8194444!
            Me.Line4.Y1 = 0.6319444!
            Me.Line4.Y2 = 0.8194444!
            '
            'txtSucursal
            '
            Me.txtSucursal.DataField = "Sucursal"
            Me.txtSucursal.Height = 0.2!
            Me.txtSucursal.Left = 0.0625!
            Me.txtSucursal.Name = "txtSucursal"
            Me.txtSucursal.Style = "text-align: center"
            Me.txtSucursal.Text = "Sucursal"
            Me.txtSucursal.Top = 0!
            Me.txtSucursal.Width = 0.75!
            '
            'txtCodigo
            '
            Me.txtCodigo.DataField = "Codigo"
            Me.txtCodigo.Height = 0.2!
            Me.txtCodigo.Left = 1.1875!
            Me.txtCodigo.Name = "txtCodigo"
            Me.txtCodigo.Text = "Codigo"
            Me.txtCodigo.Top = 0!
            Me.txtCodigo.Width = 2.6875!
            '
            'txtHistorico
            '
            Me.txtHistorico.DataField = "Historico"
            Me.txtHistorico.Height = 0.2!
            Me.txtHistorico.Left = 4.125!
            Me.txtHistorico.Name = "txtHistorico"
            Me.txtHistorico.Style = "text-align: right"
            Me.txtHistorico.Text = "Historico"
            Me.txtHistorico.Top = 0!
            Me.txtHistorico.Width = 1!
            '
            'txtInventario
            '
            Me.txtInventario.DataField = "Inventario"
            Me.txtInventario.Height = 0.2!
            Me.txtInventario.Left = 5.3125!
            Me.txtInventario.Name = "txtInventario"
            Me.txtInventario.Style = "text-align: right"
            Me.txtInventario.Text = "Inventario"
            Me.txtInventario.Top = 0!
            Me.txtInventario.Width = 1!
            '
            'Line5
            '
            Me.Line5.Height = 0!
            Me.Line5.Left = 0!
            Me.Line5.LineWeight = 1!
            Me.Line5.Name = "Line5"
            Me.Line5.Top = 0!
            Me.Line5.Width = 6.4375!
            Me.Line5.X1 = 6.4375!
            Me.Line5.X2 = 0!
            Me.Line5.Y1 = 0!
            Me.Line5.Y2 = 0!
            '
            'ActiveReport1
            '
            Me.MasterReport = false
            Me.PageSettings.PaperHeight = 11!
            Me.PageSettings.PaperWidth = 8.5!
            Me.PrintWidth = 6.458333!
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
            CType(Me.Label3,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label5,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label6,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblFecha,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label8,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtPag,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblSucursal,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtSucursal,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtCodigo,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtHistorico,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtInventario,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        
	End Sub

#End Region

End Class
