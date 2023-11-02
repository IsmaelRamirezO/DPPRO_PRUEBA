Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Public Class AuditoriaRetirosReport

    Inherits DataDynamics.ActiveReports.ActiveReport

    Public Sub New( _
                    ByVal nCaja As String, _
                    ByVal Almacen As String, _
                    ByVal Desde As Date, _
                    ByVal Hasta As Date, _
                    ByVal dtRetiros As DataTable)

        MyBase.New()

        InitializeComponent()


        lblFecha.Text = Format(Date.Now, "short date")
        lblPagina.Text = "Pag. :" & Me.PageNumber
        lbltitulo.Text = Trim(lbltitulo.Text) & " " & nCaja
        lblRango.Text = "Del : " & Format(Desde, "short date") & " Al : " & Format(Hasta, "short date")
        lblSucursal.Text = "SUCURSAL  :  " & Almacen
        txtTotalRetiros.Text = Trim(txtTotalRetiros.Text) & " " & dtRetiros.Rows.Count
        Me.DataSource = dtRetiros
        Me.DataMember = "Retiros"

        Me.Run()

    End Sub

#Region "ActiveReports Designer generated code"
    Private WithEvents PageHeader As PageHeader = Nothing
    Private WithEvents GroupHeader1 As GroupHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents GroupFooter1 As GroupFooter = Nothing
    Private WithEvents PageFooter As PageFooter = Nothing
	Private Shape1 As Shape = Nothing
	Private lbltitulo As Label = Nothing
	Private lblRango As Label = Nothing
	Private lblFecha As Label = Nothing
	Private lblPagina As Label = Nothing
	Private Label6 As Label = Nothing
	Private Label7 As Label = Nothing
	Private Label8 As Label = Nothing
	Private Label9 As Label = Nothing
	Private Label10 As Label = Nothing
	Private Label11 As Label = Nothing
	Private lblSucursal As Label = Nothing
	Private Line1 As Line = Nothing
	Private Line3 As Line = Nothing
	Private Line4 As Line = Nothing
	Private Line5 As Line = Nothing
	Private Line6 As Line = Nothing
	Private Line7 As Line = Nothing
	Private txtFecha As TextBox = Nothing
	Private txtFicha As TextBox = Nothing
	Private txtFolio As TextBox = Nothing
	Private txtCantidad As TextBox = Nothing
	Private txtUsuario As TextBox = Nothing
	Private txtHora As TextBox = Nothing
	Private Shape2 As Shape = Nothing
	Private txtTotalRetiros As Label = Nothing
	Private TextBox1 As TextBox = Nothing
	Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AuditoriaRetirosReport))
            Me.Detail = New DataDynamics.ActiveReports.Detail()
            Me.PageHeader = New DataDynamics.ActiveReports.PageHeader()
            Me.PageFooter = New DataDynamics.ActiveReports.PageFooter()
            Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader()
            Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter()
            Me.Shape1 = New DataDynamics.ActiveReports.Shape()
            Me.lbltitulo = New DataDynamics.ActiveReports.Label()
            Me.lblRango = New DataDynamics.ActiveReports.Label()
            Me.lblFecha = New DataDynamics.ActiveReports.Label()
            Me.lblPagina = New DataDynamics.ActiveReports.Label()
            Me.Label6 = New DataDynamics.ActiveReports.Label()
            Me.Label7 = New DataDynamics.ActiveReports.Label()
            Me.Label8 = New DataDynamics.ActiveReports.Label()
            Me.Label9 = New DataDynamics.ActiveReports.Label()
            Me.Label10 = New DataDynamics.ActiveReports.Label()
            Me.Label11 = New DataDynamics.ActiveReports.Label()
            Me.lblSucursal = New DataDynamics.ActiveReports.Label()
            Me.Line1 = New DataDynamics.ActiveReports.Line()
            Me.Line3 = New DataDynamics.ActiveReports.Line()
            Me.Line4 = New DataDynamics.ActiveReports.Line()
            Me.Line5 = New DataDynamics.ActiveReports.Line()
            Me.Line6 = New DataDynamics.ActiveReports.Line()
            Me.Line7 = New DataDynamics.ActiveReports.Line()
            Me.txtFecha = New DataDynamics.ActiveReports.TextBox()
            Me.txtFicha = New DataDynamics.ActiveReports.TextBox()
            Me.txtFolio = New DataDynamics.ActiveReports.TextBox()
            Me.txtCantidad = New DataDynamics.ActiveReports.TextBox()
            Me.txtUsuario = New DataDynamics.ActiveReports.TextBox()
            Me.txtHora = New DataDynamics.ActiveReports.TextBox()
            Me.Shape2 = New DataDynamics.ActiveReports.Shape()
            Me.txtTotalRetiros = New DataDynamics.ActiveReports.Label()
            Me.TextBox1 = New DataDynamics.ActiveReports.TextBox()
            CType(Me.lbltitulo,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblRango,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblFecha,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblPagina,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label6,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label7,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label8,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label9,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label10,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label11,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblSucursal,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFecha,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFicha,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFolio,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtCantidad,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtUsuario,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtHora,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtTotalRetiros,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox1,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
            '
            'Detail
            '
            Me.Detail.ColumnSpacing = 0!
            Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtFecha, Me.txtFicha, Me.txtFolio, Me.txtCantidad, Me.txtUsuario, Me.txtHora})
            Me.Detail.Height = 0.2076389!
            Me.Detail.Name = "Detail"
            '
            'PageHeader
            '
            Me.PageHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape1, Me.lbltitulo, Me.lblRango, Me.lblFecha, Me.lblPagina, Me.Label6, Me.Label7, Me.Label8, Me.Label9, Me.Label10, Me.Label11, Me.lblSucursal, Me.Line1, Me.Line3, Me.Line4, Me.Line5, Me.Line6, Me.Line7})
            Me.PageHeader.Height = 1.072222!
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
            Me.GroupFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape2, Me.txtTotalRetiros, Me.TextBox1})
            Me.GroupFooter1.Height = 0.2708333!
            Me.GroupFooter1.Name = "GroupFooter1"
            '
            'Shape1
            '
            Me.Shape1.Height = 1.0625!
            Me.Shape1.Left = 0!
            Me.Shape1.Name = "Shape1"
            Me.Shape1.RoundingRadius = 9.999999!
            Me.Shape1.Top = 0!
            Me.Shape1.Width = 6.5625!
            '
            'lbltitulo
            '
            Me.lbltitulo.Height = 0.2!
            Me.lbltitulo.HyperLink = Nothing
            Me.lbltitulo.Left = 1.0625!
            Me.lbltitulo.Name = "lbltitulo"
            Me.lbltitulo.Style = "text-align: center"
            Me.lbltitulo.Text = "AUDITORIA DE RETIROS DE LA CAJA : "
            Me.lbltitulo.Top = 0.0625!
            Me.lbltitulo.Width = 4.5!
            '
            'lblRango
            '
            Me.lblRango.Height = 0.2!
            Me.lblRango.HyperLink = Nothing
            Me.lblRango.Left = 0.0625!
            Me.lblRango.Name = "lblRango"
            Me.lblRango.Style = "text-align: center"
            Me.lblRango.Text = "Del : dd/MM/yyyy Al : dd/MM/yyyy"
            Me.lblRango.Top = 0.3125!
            Me.lblRango.Width = 6.4375!
            '
            'lblFecha
            '
            Me.lblFecha.Height = 0.2!
            Me.lblFecha.HyperLink = Nothing
            Me.lblFecha.Left = 0.0625!
            Me.lblFecha.Name = "lblFecha"
            Me.lblFecha.Style = "text-align: center"
            Me.lblFecha.Text = "Fecha"
            Me.lblFecha.Top = 0.0625!
            Me.lblFecha.Width = 0.875!
            '
            'lblPagina
            '
            Me.lblPagina.Height = 0.2!
            Me.lblPagina.HyperLink = Nothing
            Me.lblPagina.Left = 5.625!
            Me.lblPagina.Name = "lblPagina"
            Me.lblPagina.Style = "text-align: center"
            Me.lblPagina.Text = "Pag.:"
            Me.lblPagina.Top = 0.0625!
            Me.lblPagina.Width = 0.875!
            '
            'Label6
            '
            Me.Label6.Height = 0.2!
            Me.Label6.HyperLink = Nothing
            Me.Label6.Left = 0.125!
            Me.Label6.Name = "Label6"
            Me.Label6.Style = "text-align: center"
            Me.Label6.Text = "Fecha"
            Me.Label6.Top = 0.875!
            Me.Label6.Width = 0.5!
            '
            'Label7
            '
            Me.Label7.Height = 0.2!
            Me.Label7.HyperLink = Nothing
            Me.Label7.Left = 0.8125!
            Me.Label7.Name = "Label7"
            Me.Label7.Style = "text-align: center"
            Me.Label7.Text = "Ficha"
            Me.Label7.Top = 0.875!
            Me.Label7.Width = 1.8125!
            '
            'Label8
            '
            Me.Label8.Height = 0.2!
            Me.Label8.HyperLink = Nothing
            Me.Label8.Left = 2.6875!
            Me.Label8.Name = "Label8"
            Me.Label8.Style = "text-align: center"
            Me.Label8.Text = "Folio"
            Me.Label8.Top = 0.875!
            Me.Label8.Width = 0.8125!
            '
            'Label9
            '
            Me.Label9.Height = 0.2!
            Me.Label9.HyperLink = Nothing
            Me.Label9.Left = 3.5625!
            Me.Label9.Name = "Label9"
            Me.Label9.Style = "text-align: center"
            Me.Label9.Text = "Cantidad"
            Me.Label9.Top = 0.875!
            Me.Label9.Width = 1.1875!
            '
            'Label10
            '
            Me.Label10.Height = 0.2!
            Me.Label10.HyperLink = Nothing
            Me.Label10.Left = 4.8125!
            Me.Label10.Name = "Label10"
            Me.Label10.Style = "text-align: center"
            Me.Label10.Text = "Usuario"
            Me.Label10.Top = 0.875!
            Me.Label10.Width = 1!
            '
            'Label11
            '
            Me.Label11.Height = 0.2!
            Me.Label11.HyperLink = Nothing
            Me.Label11.Left = 6!
            Me.Label11.Name = "Label11"
            Me.Label11.Style = "text-align: center"
            Me.Label11.Text = "Hora"
            Me.Label11.Top = 0.875!
            Me.Label11.Width = 0.5!
            '
            'lblSucursal
            '
            Me.lblSucursal.Height = 0.2!
            Me.lblSucursal.HyperLink = Nothing
            Me.lblSucursal.Left = 0.0625!
            Me.lblSucursal.Name = "lblSucursal"
            Me.lblSucursal.Style = "text-align: center"
            Me.lblSucursal.Text = "Sucursal :"
            Me.lblSucursal.Top = 0.5625!
            Me.lblSucursal.Width = 6.4375!
            '
            'Line1
            '
            Me.Line1.Height = 0!
            Me.Line1.Left = 0!
            Me.Line1.LineWeight = 1!
            Me.Line1.Name = "Line1"
            Me.Line1.Top = 0.8125!
            Me.Line1.Width = 6.5625!
            Me.Line1.X1 = 6.5625!
            Me.Line1.X2 = 0!
            Me.Line1.Y1 = 0.8125!
            Me.Line1.Y2 = 0.8125!
            '
            'Line3
            '
            Me.Line3.Height = 0.25!
            Me.Line3.Left = 4.756945!
            Me.Line3.LineWeight = 1!
            Me.Line3.Name = "Line3"
            Me.Line3.Top = 0.8194444!
            Me.Line3.Width = 0!
            Me.Line3.X1 = 4.756945!
            Me.Line3.X2 = 4.756945!
            Me.Line3.Y1 = 0.8194444!
            Me.Line3.Y2 = 1.069444!
            '
            'Line4
            '
            Me.Line4.Height = 0.25!
            Me.Line4.Left = 3.569444!
            Me.Line4.LineWeight = 1!
            Me.Line4.Name = "Line4"
            Me.Line4.Top = 0.8194444!
            Me.Line4.Width = 0!
            Me.Line4.X1 = 3.569444!
            Me.Line4.X2 = 3.569444!
            Me.Line4.Y1 = 0.8194444!
            Me.Line4.Y2 = 1.069444!
            '
            'Line5
            '
            Me.Line5.Height = 0.25!
            Me.Line5.Left = 2.631944!
            Me.Line5.LineWeight = 1!
            Me.Line5.Name = "Line5"
            Me.Line5.Top = 0.8194444!
            Me.Line5.Width = 0!
            Me.Line5.X1 = 2.631944!
            Me.Line5.X2 = 2.631944!
            Me.Line5.Y1 = 0.8194444!
            Me.Line5.Y2 = 1.069444!
            '
            'Line6
            '
            Me.Line6.Height = 0.25!
            Me.Line6.Left = 0.7569444!
            Me.Line6.LineWeight = 1!
            Me.Line6.Name = "Line6"
            Me.Line6.Top = 0.8194444!
            Me.Line6.Width = 0!
            Me.Line6.X1 = 0.7569444!
            Me.Line6.X2 = 0.7569444!
            Me.Line6.Y1 = 0.8194444!
            Me.Line6.Y2 = 1.069444!
            '
            'Line7
            '
            Me.Line7.Height = 0.25!
            Me.Line7.Left = 5.881945!
            Me.Line7.LineWeight = 1!
            Me.Line7.Name = "Line7"
            Me.Line7.Top = 0.8194444!
            Me.Line7.Width = 0!
            Me.Line7.X1 = 5.881945!
            Me.Line7.X2 = 5.881945!
            Me.Line7.Y1 = 0.8194444!
            Me.Line7.Y2 = 1.069444!
            '
            'txtFecha
            '
            Me.txtFecha.DataField = "Fecha"
            Me.txtFecha.Height = 0.2!
            Me.txtFecha.Left = 0!
            Me.txtFecha.Name = "txtFecha"
            Me.txtFecha.OutputFormat = resources.GetString("txtFecha.OutputFormat")
            Me.txtFecha.Style = "text-align: center"
            Me.txtFecha.Text = "00/00/0000"
            Me.txtFecha.Top = 0!
            Me.txtFecha.Width = 0.75!
            '
            'txtFicha
            '
            Me.txtFicha.DataField = "Ficha"
            Me.txtFicha.Height = 0.2!
            Me.txtFicha.Left = 0.8125!
            Me.txtFicha.Name = "txtFicha"
            Me.txtFicha.Style = "text-align: right"
            Me.txtFicha.Text = "Ficha"
            Me.txtFicha.Top = 0!
            Me.txtFicha.Width = 1.8125!
            '
            'txtFolio
            '
            Me.txtFolio.DataField = "Folio"
            Me.txtFolio.Height = 0.2!
            Me.txtFolio.Left = 2.6875!
            Me.txtFolio.Name = "txtFolio"
            Me.txtFolio.Style = "text-align: right"
            Me.txtFolio.Text = "Folio"
            Me.txtFolio.Top = 0!
            Me.txtFolio.Width = 0.875!
            '
            'txtCantidad
            '
            Me.txtCantidad.DataField = "Cantidad"
            Me.txtCantidad.Height = 0.2!
            Me.txtCantidad.Left = 3.625!
            Me.txtCantidad.Name = "txtCantidad"
            Me.txtCantidad.OutputFormat = resources.GetString("txtCantidad.OutputFormat")
            Me.txtCantidad.Style = "text-align: right"
            Me.txtCantidad.Text = "Cantidad"
            Me.txtCantidad.Top = 0!
            Me.txtCantidad.Width = 1.0625!
            '
            'txtUsuario
            '
            Me.txtUsuario.CanGrow = false
            Me.txtUsuario.DataField = "Usuario"
            Me.txtUsuario.Height = 0.2!
            Me.txtUsuario.Left = 4.8125!
            Me.txtUsuario.Name = "txtUsuario"
            Me.txtUsuario.Text = "Usuario"
            Me.txtUsuario.Top = 0!
            Me.txtUsuario.Width = 1.0625!
            '
            'txtHora
            '
            Me.txtHora.DataField = "Fecha"
            Me.txtHora.Height = 0.2!
            Me.txtHora.Left = 5.9375!
            Me.txtHora.Name = "txtHora"
            Me.txtHora.OutputFormat = resources.GetString("txtHora.OutputFormat")
            Me.txtHora.Style = "text-align: center"
            Me.txtHora.Text = "00:00:00"
            Me.txtHora.Top = 0!
            Me.txtHora.Width = 0.625!
            '
            'Shape2
            '
            Me.Shape2.Height = 0.25!
            Me.Shape2.Left = 0!
            Me.Shape2.Name = "Shape2"
            Me.Shape2.RoundingRadius = 9.999999!
            Me.Shape2.Top = 0!
            Me.Shape2.Width = 6.5625!
            '
            'txtTotalRetiros
            '
            Me.txtTotalRetiros.Height = 0.2!
            Me.txtTotalRetiros.HyperLink = Nothing
            Me.txtTotalRetiros.Left = 0.0625!
            Me.txtTotalRetiros.Name = "txtTotalRetiros"
            Me.txtTotalRetiros.Style = ""
            Me.txtTotalRetiros.Text = "TOTAL RETIROS     :"
            Me.txtTotalRetiros.Top = 0.0625!
            Me.txtTotalRetiros.Width = 2.6875!
            '
            'TextBox1
            '
            Me.TextBox1.DataField = "Cantidad"
            Me.TextBox1.Height = 0.2!
            Me.TextBox1.Left = 3.625!
            Me.TextBox1.Name = "TextBox1"
            Me.TextBox1.OutputFormat = resources.GetString("TextBox1.OutputFormat")
            Me.TextBox1.Style = "text-align: right"
            Me.TextBox1.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
            Me.TextBox1.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
            Me.TextBox1.Text = "Total"
            Me.TextBox1.Top = 0.0625!
            Me.TextBox1.Width = 1.0625!
            '
            'ActiveReport1
            '
            Me.MasterReport = false
            Me.PageSettings.PaperHeight = 11!
            Me.PageSettings.PaperWidth = 8.5!
            Me.PrintWidth = 6.572917!
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
            CType(Me.lbltitulo,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblRango,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblFecha,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblPagina,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label6,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label7,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label8,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label9,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label10,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label11,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblSucursal,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFecha,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFicha,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFolio,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtCantidad,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtUsuario,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtHora,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtTotalRetiros,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox1,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        
	End Sub

#End Region

End Class
