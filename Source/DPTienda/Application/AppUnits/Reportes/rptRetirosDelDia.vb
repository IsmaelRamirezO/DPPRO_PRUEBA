Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Imports DportenisPro.DPTienda.ApplicationUnits.Retiros

Public Class rptRetirosDelDia
Inherits DataDynamics.ActiveReports.ActiveReport
    Public Sub New(ByVal Fecha As DateTime, ByVal strAlmacen As String)
        MyBase.New()
        InitializeComponent()

        Me.txtAlmacen.Text = strAlmacen
        Me.txtFecha.Text = Fecha.ToShortDateString
        Dim oRetirosMgr As New RetirosManager(oAppContext)
        Dim dsRetiros(3) As String
        dsRetiros = oRetirosMgr.SelectByDate(Fecha)
        txtCantidadEfec.Text = CDbl(dsRetiros(0))
        TxtBxTotalT1.Text = CDbl(dsRetiros(1))
        TxtBxTotalT2.Text = CDbl(dsRetiros(2))
        TxtBxTotalT3.Text = CDbl(dsRetiros(3))
        txtSumCantidadRetiro.Text = CDbl(dsRetiros(0)) + CDbl(dsRetiros(1)) + CDbl(dsRetiros(2)) + CDbl(dsRetiros(3))

        '----------------Numero de Referencia---------------
        Dim strNumRef As String = String.Empty
        Dim numref As New NumeroReferencia.cNumReferencia
        strNumRef = numref.getNumReferencia(oAppContext.ApplicationConfiguration.Almacen.PadLeft(4, "0"), CStr(Format(Fecha, "ddMMyyyy")))
        '------------------------------------------------------
        Me.txtReferencia.Text = strNumRef

    End Sub


#Region "ActiveReports Designer generated code"
    Private WithEvents ReportHeader As ReportHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents ReportFooter As ReportFooter = Nothing
	Private Shape1 As Shape = Nothing
	Private Label1 As Label = Nothing
	Private Label2 As Label = Nothing
	Private txtFecha As TextBox = Nothing
	Private Label3 As Label = Nothing
	Private txtAlmacen As TextBox = Nothing
	Private Label6 As Label = Nothing
	Private Label8 As Label = Nothing
	Private Label10 As Label = Nothing
	Private Line1 As Line = Nothing
	Private txtCodBanco As TextBox = Nothing
	Private txtCantidadEfec As TextBox = Nothing
	Private Line2 As Line = Nothing
	Private Line3 As Line = Nothing
	Private TextBox1 As TextBox = Nothing
	Private TxtBxTotalT1 As TextBox = Nothing
	Private TextBox4 As TextBox = Nothing
	Private TxtBxTotalT2 As TextBox = Nothing
	Private TextBox7 As TextBox = Nothing
	Private TxtBxTotalT3 As TextBox = Nothing
	Private txtReferencia As TextBox = Nothing
	Private Shape2 As Shape = Nothing
	Private txtSumCantidadRetiro As TextBox = Nothing
	Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptRetirosDelDia))
            Me.Detail = New DataDynamics.ActiveReports.Detail()
            Me.ReportHeader = New DataDynamics.ActiveReports.ReportHeader()
            Me.ReportFooter = New DataDynamics.ActiveReports.ReportFooter()
            Me.Shape1 = New DataDynamics.ActiveReports.Shape()
            Me.Label1 = New DataDynamics.ActiveReports.Label()
            Me.Label2 = New DataDynamics.ActiveReports.Label()
            Me.txtFecha = New DataDynamics.ActiveReports.TextBox()
            Me.Label3 = New DataDynamics.ActiveReports.Label()
            Me.txtAlmacen = New DataDynamics.ActiveReports.TextBox()
            Me.Label6 = New DataDynamics.ActiveReports.Label()
            Me.Label8 = New DataDynamics.ActiveReports.Label()
            Me.Label10 = New DataDynamics.ActiveReports.Label()
            Me.Line1 = New DataDynamics.ActiveReports.Line()
            Me.txtCodBanco = New DataDynamics.ActiveReports.TextBox()
            Me.txtCantidadEfec = New DataDynamics.ActiveReports.TextBox()
            Me.Line2 = New DataDynamics.ActiveReports.Line()
            Me.Line3 = New DataDynamics.ActiveReports.Line()
            Me.TextBox1 = New DataDynamics.ActiveReports.TextBox()
            Me.TxtBxTotalT1 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox4 = New DataDynamics.ActiveReports.TextBox()
            Me.TxtBxTotalT2 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox7 = New DataDynamics.ActiveReports.TextBox()
            Me.TxtBxTotalT3 = New DataDynamics.ActiveReports.TextBox()
            Me.txtReferencia = New DataDynamics.ActiveReports.TextBox()
            Me.Shape2 = New DataDynamics.ActiveReports.Shape()
            Me.txtSumCantidadRetiro = New DataDynamics.ActiveReports.TextBox()
            CType(Me.Label1,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFecha,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label3,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtAlmacen,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label6,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label8,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label10,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtCodBanco,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtCantidadEfec,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox1,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TxtBxTotalT1,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox4,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TxtBxTotalT2,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox7,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TxtBxTotalT3,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtReferencia,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtSumCantidadRetiro,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
            '
            'Detail
            '
            Me.Detail.ColumnSpacing = 0!
            Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtCodBanco, Me.txtCantidadEfec, Me.Line2, Me.Line3, Me.TextBox1, Me.TxtBxTotalT1, Me.TextBox4, Me.TxtBxTotalT2, Me.TextBox7, Me.TxtBxTotalT3, Me.txtReferencia})
            Me.Detail.Height = 0.9166667!
            Me.Detail.Name = "Detail"
            '
            'ReportHeader
            '
            Me.ReportHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape1, Me.Label1, Me.Label2, Me.txtFecha, Me.Label3, Me.txtAlmacen, Me.Label6, Me.Label8, Me.Label10, Me.Line1})
            Me.ReportHeader.Height = 0.8944445!
            Me.ReportHeader.Name = "ReportHeader"
            '
            'ReportFooter
            '
            Me.ReportFooter.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape2, Me.txtSumCantidadRetiro})
            Me.ReportFooter.Height = 0.2076389!
            Me.ReportFooter.Name = "ReportFooter"
            '
            'Shape1
            '
            Me.Shape1.Height = 0.875!
            Me.Shape1.Left = 0!
            Me.Shape1.Name = "Shape1"
            Me.Shape1.RoundingRadius = 9.999999!
            Me.Shape1.Top = 0!
            Me.Shape1.Width = 6.9375!
            '
            'Label1
            '
            Me.Label1.Height = 0.2!
            Me.Label1.HyperLink = Nothing
            Me.Label1.Left = 2.6875!
            Me.Label1.Name = "Label1"
            Me.Label1.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
            Me.Label1.Text = "Reporte de Retiros."
            Me.Label1.Top = 0.0625!
            Me.Label1.Width = 1.875!
            '
            'Label2
            '
            Me.Label2.Height = 0.2!
            Me.Label2.HyperLink = Nothing
            Me.Label2.Left = 0.0625!
            Me.Label2.Name = "Label2"
            Me.Label2.Style = "font-weight: bold; font-size: 8.25pt"
            Me.Label2.Text = "Fecha:"
            Me.Label2.Top = 0.0625!
            Me.Label2.Width = 0.5!
            '
            'txtFecha
            '
            Me.txtFecha.Height = 0.2!
            Me.txtFecha.Left = 0.5625!
            Me.txtFecha.Name = "txtFecha"
            Me.txtFecha.Text = "txtFecha"
            Me.txtFecha.Top = 0.0625!
            Me.txtFecha.Width = 1!
            '
            'Label3
            '
            Me.Label3.Height = 0.2!
            Me.Label3.HyperLink = Nothing
            Me.Label3.Left = 2!
            Me.Label3.Name = "Label3"
            Me.Label3.Style = "font-weight: bold; font-size: 8.25pt"
            Me.Label3.Text = "Sucursal:"
            Me.Label3.Top = 0.375!
            Me.Label3.Width = 0.625!
            '
            'txtAlmacen
            '
            Me.txtAlmacen.Height = 0.2!
            Me.txtAlmacen.Left = 2.6875!
            Me.txtAlmacen.Name = "txtAlmacen"
            Me.txtAlmacen.Style = "font-size: 8.25pt"
            Me.txtAlmacen.Text = "TextBox1"
            Me.txtAlmacen.Top = 0.375!
            Me.txtAlmacen.Width = 2.3125!
            '
            'Label6
            '
            Me.Label6.Height = 0.2!
            Me.Label6.HyperLink = Nothing
            Me.Label6.Left = 0.25!
            Me.Label6.Name = "Label6"
            Me.Label6.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
            Me.Label6.Text = "Cod. Banco"
            Me.Label6.Top = 0.6875!
            Me.Label6.Width = 0.875!
            '
            'Label8
            '
            Me.Label8.Height = 0.2!
            Me.Label8.HyperLink = Nothing
            Me.Label8.Left = 1.375!
            Me.Label8.Name = "Label8"
            Me.Label8.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
            Me.Label8.Text = "Referencia"
            Me.Label8.Top = 0.6875!
            Me.Label8.Width = 1!
            '
            'Label10
            '
            Me.Label10.Height = 0.2!
            Me.Label10.HyperLink = Nothing
            Me.Label10.Left = 2.5!
            Me.Label10.Name = "Label10"
            Me.Label10.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
            Me.Label10.Text = "Cantidad Retiro"
            Me.Label10.Top = 0.6875!
            Me.Label10.Width = 1!
            '
            'Line1
            '
            Me.Line1.Height = 0!
            Me.Line1.Left = 0.006944444!
            Me.Line1.LineWeight = 1!
            Me.Line1.Name = "Line1"
            Me.Line1.Top = 0.6319444!
            Me.Line1.Width = 6.9375!
            Me.Line1.X1 = 6.944445!
            Me.Line1.X2 = 0.006944444!
            Me.Line1.Y1 = 0.6319444!
            Me.Line1.Y2 = 0.6319444!
            '
            'txtCodBanco
            '
            Me.txtCodBanco.Height = 0.125!
            Me.txtCodBanco.Left = 0.5364993!
            Me.txtCodBanco.Name = "txtCodBanco"
            Me.txtCodBanco.Style = "text-align: center; font-size: 8.25pt"
            Me.txtCodBanco.Text = "EFEC"
            Me.txtCodBanco.Top = 0!
            Me.txtCodBanco.Width = 0.5634023!
            '
            'txtCantidadEfec
            '
            Me.txtCantidadEfec.Height = 0.125!
            Me.txtCantidadEfec.Left = 2.427083!
            Me.txtCantidadEfec.Name = "txtCantidadEfec"
            Me.txtCantidadEfec.OutputFormat = resources.GetString("txtCantidadEfec.OutputFormat")
            Me.txtCantidadEfec.Style = "text-align: right; font-size: 8.25pt"
            Me.txtCantidadEfec.Text = "0.00"
            Me.txtCantidadEfec.Top = 0!
            Me.txtCantidadEfec.Width = 1!
            '
            'Line2
            '
            Me.Line2.Height = 0.944882!
            Me.Line2.Left = 6.937008!
            Me.Line2.LineWeight = 1!
            Me.Line2.Name = "Line2"
            Me.Line2.Top = 0!
            Me.Line2.Width = 0.0004916191!
            Me.Line2.X1 = 6.9375!
            Me.Line2.X2 = 6.937008!
            Me.Line2.Y1 = 0!
            Me.Line2.Y2 = 0.944882!
            '
            'Line3
            '
            Me.Line3.Height = 0.944882!
            Me.Line3.Left = 0!
            Me.Line3.LineWeight = 1!
            Me.Line3.Name = "Line3"
            Me.Line3.Top = 0!
            Me.Line3.Width = 0!
            Me.Line3.X1 = 0!
            Me.Line3.X2 = 0!
            Me.Line3.Y1 = 0!
            Me.Line3.Y2 = 0.944882!
            '
            'TextBox1
            '
            Me.TextBox1.Height = 0.125!
            Me.TextBox1.Left = 0.7874014!
            Me.TextBox1.Name = "TextBox1"
            Me.TextBox1.Style = "text-align: center; font-size: 8.25pt"
            Me.TextBox1.Text = "T1"
            Me.TextBox1.Top = 0.25!
            Me.TextBox1.Width = 0.3125!
            '
            'TxtBxTotalT1
            '
            Me.TxtBxTotalT1.DataField = "CantidadRetiro"
            Me.TxtBxTotalT1.Height = 0.125!
            Me.TxtBxTotalT1.Left = 2.427083!
            Me.TxtBxTotalT1.Name = "TxtBxTotalT1"
            Me.TxtBxTotalT1.OutputFormat = resources.GetString("TxtBxTotalT1.OutputFormat")
            Me.TxtBxTotalT1.Style = "text-align: right; font-size: 8.25pt"
            Me.TxtBxTotalT1.Text = "0.00"
            Me.TxtBxTotalT1.Top = 0.25!
            Me.TxtBxTotalT1.Width = 1!
            '
            'TextBox4
            '
            Me.TextBox4.Height = 0.125!
            Me.TextBox4.Left = 0.7874014!
            Me.TextBox4.Name = "TextBox4"
            Me.TextBox4.Style = "text-align: center; font-size: 8.25pt"
            Me.TextBox4.Text = "T2"
            Me.TextBox4.Top = 0.5!
            Me.TextBox4.Width = 0.3125!
            '
            'TxtBxTotalT2
            '
            Me.TxtBxTotalT2.DataField = "CantidadRetiro"
            Me.TxtBxTotalT2.Height = 0.125!
            Me.TxtBxTotalT2.Left = 2.427083!
            Me.TxtBxTotalT2.Name = "TxtBxTotalT2"
            Me.TxtBxTotalT2.OutputFormat = resources.GetString("TxtBxTotalT2.OutputFormat")
            Me.TxtBxTotalT2.Style = "text-align: right; font-size: 8.25pt"
            Me.TxtBxTotalT2.Text = "0.00"
            Me.TxtBxTotalT2.Top = 0.5!
            Me.TxtBxTotalT2.Width = 1!
            '
            'TextBox7
            '
            Me.TextBox7.Height = 0.125!
            Me.TextBox7.Left = 0.7874014!
            Me.TextBox7.Name = "TextBox7"
            Me.TextBox7.Style = "text-align: center; font-size: 8.25pt"
            Me.TextBox7.Text = "T3"
            Me.TextBox7.Top = 0.75!
            Me.TextBox7.Width = 0.3125!
            '
            'TxtBxTotalT3
            '
            Me.TxtBxTotalT3.DataField = "CantidadRetiro"
            Me.TxtBxTotalT3.Height = 0.125!
            Me.TxtBxTotalT3.Left = 2.427083!
            Me.TxtBxTotalT3.Name = "TxtBxTotalT3"
            Me.TxtBxTotalT3.OutputFormat = resources.GetString("TxtBxTotalT3.OutputFormat")
            Me.TxtBxTotalT3.Style = "text-align: right; font-size: 8.25pt"
            Me.TxtBxTotalT3.Text = "0.00"
            Me.TxtBxTotalT3.Top = 0.75!
            Me.TxtBxTotalT3.Width = 1!
            '
            'txtReferencia
            '
            Me.txtReferencia.DataField = "Referencia"
            Me.txtReferencia.Height = 0.125!
            Me.txtReferencia.Left = 1.302083!
            Me.txtReferencia.Name = "txtReferencia"
            Me.txtReferencia.Style = "text-align: right; font-size: 8.25pt"
            Me.txtReferencia.Text = "000000"
            Me.txtReferencia.Top = 0!
            Me.txtReferencia.Width = 1!
            '
            'Shape2
            '
            Me.Shape2.Height = 0.1875!
            Me.Shape2.Left = 0!
            Me.Shape2.Name = "Shape2"
            Me.Shape2.RoundingRadius = 9.999999!
            Me.Shape2.Top = 0!
            Me.Shape2.Width = 6.9375!
            '
            'txtSumCantidadRetiro
            '
            Me.txtSumCantidadRetiro.Height = 0.125!
            Me.txtSumCantidadRetiro.Left = 2.4375!
            Me.txtSumCantidadRetiro.Name = "txtSumCantidadRetiro"
            Me.txtSumCantidadRetiro.OutputFormat = resources.GetString("txtSumCantidadRetiro.OutputFormat")
            Me.txtSumCantidadRetiro.Style = "text-align: right; font-size: 8.25pt"
            Me.txtSumCantidadRetiro.Text = "0.00"
            Me.txtSumCantidadRetiro.Top = 0!
            Me.txtSumCantidadRetiro.Width = 1!
            '
            'ActiveReport1
            '
            Me.MasterReport = false
            Me.PageSettings.PaperHeight = 11!
            Me.PageSettings.PaperWidth = 8.5!
            Me.PrintWidth = 7.010417!
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
            CType(Me.txtFecha,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label3,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtAlmacen,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label6,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label8,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label10,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtCodBanco,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtCantidadEfec,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox1,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TxtBxTotalT1,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox4,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TxtBxTotalT2,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox7,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TxtBxTotalT3,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtReferencia,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtSumCantidadRetiro,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        
	End Sub

#End Region

End Class
