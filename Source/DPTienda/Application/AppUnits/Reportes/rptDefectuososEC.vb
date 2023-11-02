Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU

Public Class rptDefectuososEC

    Inherits DataDynamics.ActiveReports.ActiveReport
    Public Sub New(ByVal dtSource As DataTable)

        MyBase.New()
        InitializeComponent()

        Dim oAlmacen As Almacen
        Dim oAlmacenMgr As New CatalogoAlmacenesManager(oAppContext, oConfigCierreFI)

        Me.txtFecha.Text = Format(Today, "dd/MM/yyyy")

        Dim oSAPMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        oAlmacen = oAlmacenMgr.Load(oSAPMgr.read_centros) 'oAppContext.ApplicationConfiguration.Almacen.Trim)
        If Not oAlmacen Is Nothing Then
            Me.txtSucursal.Text = oAppContext.ApplicationConfiguration.Almacen.Trim & " " & oAlmacen.Descripcion.Trim
        End If

        Me.DataSource = dtSource

    End Sub

#Region "ActiveReports Designer generated code"
    Private WithEvents ReportHeader As ReportHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents ReportFooter As ReportFooter = Nothing
	Private Label1 As Label = Nothing
	Private Label2 As Label = Nothing
	Private txtFecha As TextBox = Nothing
	Private Label3 As Label = Nothing
	Private Label4 As Label = Nothing
	Private Label5 As Label = Nothing
	Private Label6 As Label = Nothing
	Private Label7 As Label = Nothing
	Private Label8 As Label = Nothing
	Private txtSucursal As TextBox = Nothing
	Private lblFecha As Label = Nothing
	Private lblHora As Label = Nothing
	Private lblResponsable As Label = Nothing
	Private txtCodigo As TextBox = Nothing
	Private txtDescripcion As TextBox = Nothing
	Private txtTalla As TextBox = Nothing
	Private txtMotivo As TextBox = Nothing
	Private txtCantidad As TextBox = Nothing
	Private txtFechaR As TextBox = Nothing
	Private txtHora As TextBox = Nothing
	Private txtResponsable As TextBox = Nothing
	Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptDefectuososEC))
            Me.Detail = New DataDynamics.ActiveReports.Detail()
            Me.ReportHeader = New DataDynamics.ActiveReports.ReportHeader()
            Me.ReportFooter = New DataDynamics.ActiveReports.ReportFooter()
            Me.Label1 = New DataDynamics.ActiveReports.Label()
            Me.Label2 = New DataDynamics.ActiveReports.Label()
            Me.txtFecha = New DataDynamics.ActiveReports.TextBox()
            Me.Label3 = New DataDynamics.ActiveReports.Label()
            Me.Label4 = New DataDynamics.ActiveReports.Label()
            Me.Label5 = New DataDynamics.ActiveReports.Label()
            Me.Label6 = New DataDynamics.ActiveReports.Label()
            Me.Label7 = New DataDynamics.ActiveReports.Label()
            Me.Label8 = New DataDynamics.ActiveReports.Label()
            Me.txtSucursal = New DataDynamics.ActiveReports.TextBox()
            Me.lblFecha = New DataDynamics.ActiveReports.Label()
            Me.lblHora = New DataDynamics.ActiveReports.Label()
            Me.lblResponsable = New DataDynamics.ActiveReports.Label()
            Me.txtCodigo = New DataDynamics.ActiveReports.TextBox()
            Me.txtDescripcion = New DataDynamics.ActiveReports.TextBox()
            Me.txtTalla = New DataDynamics.ActiveReports.TextBox()
            Me.txtMotivo = New DataDynamics.ActiveReports.TextBox()
            Me.txtCantidad = New DataDynamics.ActiveReports.TextBox()
            Me.txtFechaR = New DataDynamics.ActiveReports.TextBox()
            Me.txtHora = New DataDynamics.ActiveReports.TextBox()
            Me.txtResponsable = New DataDynamics.ActiveReports.TextBox()
            CType(Me.Label1,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFecha,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label3,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label5,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label6,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label7,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label8,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtSucursal,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblFecha,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblHora,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblResponsable,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtCodigo,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtDescripcion,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtTalla,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtMotivo,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtCantidad,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFechaR,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtHora,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtResponsable,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
            '
            'Detail
            '
            Me.Detail.ColumnSpacing = 0!
            Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtCodigo, Me.txtDescripcion, Me.txtTalla, Me.txtMotivo, Me.txtCantidad, Me.txtFechaR, Me.txtHora, Me.txtResponsable})
            Me.Detail.Height = 0.25!
            Me.Detail.Name = "Detail"
            '
            'ReportHeader
            '
            Me.ReportHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label1, Me.Label2, Me.txtFecha, Me.Label3, Me.Label4, Me.Label5, Me.Label6, Me.Label7, Me.Label8, Me.txtSucursal, Me.lblFecha, Me.lblHora, Me.lblResponsable})
            Me.ReportHeader.Height = 1.125!
            Me.ReportHeader.Name = "ReportHeader"
            '
            'ReportFooter
            '
            Me.ReportFooter.Height = 0!
            Me.ReportFooter.Name = "ReportFooter"
            '
            'Label1
            '
            Me.Label1.Height = 0.25!
            Me.Label1.HyperLink = Nothing
            Me.Label1.Left = 0.0625!
            Me.Label1.Name = "Label1"
            Me.Label1.Style = "text-align: center; font-weight: bold; font-size: 12pt; font-family: Tahoma"
            Me.Label1.Text = "Reporte de Marcados Como Baja Calidad Para Ecommerce"
            Me.Label1.Top = 0.125!
            Me.Label1.Width = 7.375!
            '
            'Label2
            '
            Me.Label2.Height = 0.25!
            Me.Label2.HyperLink = Nothing
            Me.Label2.Left = 5.5625!
            Me.Label2.Name = "Label2"
            Me.Label2.Style = "text-align: center; font-weight: normal; font-size: 9.75pt; font-family: Tahoma"
            Me.Label2.Text = "Fecha:"
            Me.Label2.Top = 0.5!
            Me.Label2.Width = 0.75!
            '
            'txtFecha
            '
            Me.txtFecha.Height = 0.25!
            Me.txtFecha.Left = 6.3125!
            Me.txtFecha.Name = "txtFecha"
            Me.txtFecha.Style = "text-align: center; font-size: 9.75pt; font-family: Tahoma"
            Me.txtFecha.Text = "TextBox1"
            Me.txtFecha.Top = 0.5!
            Me.txtFecha.Width = 0.9375!
            '
            'Label3
            '
            Me.Label3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label3.Height = 0.25!
            Me.Label3.HyperLink = Nothing
            Me.Label3.Left = 0.0625!
            Me.Label3.Name = "Label3"
            Me.Label3.Style = "text-align: center; font-weight: bold; background-color: LightGrey; font-size: 9."& _ 
                "75pt; font-family: Tahoma; vertical-align: middle"
            Me.Label3.Text = "Código"
            Me.Label3.Top = 0.875!
            Me.Label3.Width = 1!
            '
            'Label4
            '
            Me.Label4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label4.Height = 0.25!
            Me.Label4.HyperLink = Nothing
            Me.Label4.Left = 1.0625!
            Me.Label4.Name = "Label4"
            Me.Label4.Style = "text-align: center; font-weight: bold; background-color: LightGrey; font-size: 9."& _ 
                "75pt; font-family: Tahoma; vertical-align: middle"
            Me.Label4.Text = "Descripción"
            Me.Label4.Top = 0.875!
            Me.Label4.Width = 1.875!
            '
            'Label5
            '
            Me.Label5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label5.Height = 0.25!
            Me.Label5.HyperLink = Nothing
            Me.Label5.Left = 2.9375!
            Me.Label5.Name = "Label5"
            Me.Label5.Style = "text-align: center; font-weight: bold; background-color: LightGrey; font-size: 9."& _ 
                "75pt; font-family: Tahoma; vertical-align: middle"
            Me.Label5.Text = "Talla"
            Me.Label5.Top = 0.875!
            Me.Label5.Width = 0.4375!
            '
            'Label6
            '
            Me.Label6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label6.Height = 0.25!
            Me.Label6.HyperLink = Nothing
            Me.Label6.Left = 3.375!
            Me.Label6.Name = "Label6"
            Me.Label6.Style = "text-align: center; font-weight: bold; background-color: LightGrey; font-size: 9."& _ 
                "75pt; font-family: Tahoma; vertical-align: middle"
            Me.Label6.Text = "Motivo"
            Me.Label6.Top = 0.875!
            Me.Label6.Width = 1.3125!
            '
            'Label7
            '
            Me.Label7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label7.Height = 0.25!
            Me.Label7.HyperLink = Nothing
            Me.Label7.Left = 4.6875!
            Me.Label7.Name = "Label7"
            Me.Label7.Style = "text-align: center; font-weight: bold; background-color: LightGrey; font-size: 9."& _ 
                "75pt; font-family: Tahoma; vertical-align: middle"
            Me.Label7.Text = "Cant"
            Me.Label7.Top = 0.875!
            Me.Label7.Width = 0.4375!
            '
            'Label8
            '
            Me.Label8.Height = 0.25!
            Me.Label8.HyperLink = Nothing
            Me.Label8.Left = 0.0625!
            Me.Label8.Name = "Label8"
            Me.Label8.Style = "text-align: center; font-weight: normal; font-size: 9.75pt; font-family: Tahoma"
            Me.Label8.Text = "Sucursal:"
            Me.Label8.Top = 0.5!
            Me.Label8.Width = 0.75!
            '
            'txtSucursal
            '
            Me.txtSucursal.Height = 0.25!
            Me.txtSucursal.Left = 0.8125!
            Me.txtSucursal.Name = "txtSucursal"
            Me.txtSucursal.Style = "text-align: center; font-size: 9.75pt; font-family: Tahoma"
            Me.txtSucursal.Text = "TextBox1"
            Me.txtSucursal.Top = 0.5!
            Me.txtSucursal.Width = 2.3125!
            '
            'lblFecha
            '
            Me.lblFecha.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblFecha.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblFecha.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblFecha.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblFecha.Height = 0.25!
            Me.lblFecha.HyperLink = Nothing
            Me.lblFecha.Left = 5.125!
            Me.lblFecha.Name = "lblFecha"
            Me.lblFecha.Style = "text-align: center; font-weight: bold; background-color: LightGrey; font-size: 9."& _ 
                "75pt; font-family: Tahoma; vertical-align: middle"
            Me.lblFecha.Text = "Fecha"
            Me.lblFecha.Top = 0.875!
            Me.lblFecha.Width = 0.6875!
            '
            'lblHora
            '
            Me.lblHora.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblHora.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblHora.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblHora.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblHora.Height = 0.25!
            Me.lblHora.HyperLink = Nothing
            Me.lblHora.Left = 5.8125!
            Me.lblHora.Name = "lblHora"
            Me.lblHora.Style = "text-align: center; font-weight: bold; background-color: LightGrey; font-size: 9."& _ 
                "75pt; font-family: Tahoma; vertical-align: middle"
            Me.lblHora.Text = "Hora"
            Me.lblHora.Top = 0.875!
            Me.lblHora.Width = 0.625!
            '
            'lblResponsable
            '
            Me.lblResponsable.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblResponsable.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblResponsable.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblResponsable.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblResponsable.Height = 0.25!
            Me.lblResponsable.HyperLink = Nothing
            Me.lblResponsable.Left = 6.4375!
            Me.lblResponsable.Name = "lblResponsable"
            Me.lblResponsable.Style = "text-align: center; font-weight: bold; background-color: LightGrey; font-size: 9."& _ 
                "75pt; font-family: Tahoma; vertical-align: middle"
            Me.lblResponsable.Text = "Responsable"
            Me.lblResponsable.Top = 0.875!
            Me.lblResponsable.Width = 0.9375!
            '
            'txtCodigo
            '
            Me.txtCodigo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtCodigo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtCodigo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtCodigo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtCodigo.DataField = "Material"
            Me.txtCodigo.Height = 0.25!
            Me.txtCodigo.Left = 0.0625!
            Me.txtCodigo.Name = "txtCodigo"
            Me.txtCodigo.Style = "text-align: center; font-size: 8.25pt; font-family: Tahoma; vertical-align: middl"& _ 
                "e"
            Me.txtCodigo.Text = "TextBox1"
            Me.txtCodigo.Top = 0!
            Me.txtCodigo.Width = 1!
            '
            'txtDescripcion
            '
            Me.txtDescripcion.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtDescripcion.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtDescripcion.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtDescripcion.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtDescripcion.DataField = "Descripcion"
            Me.txtDescripcion.Height = 0.25!
            Me.txtDescripcion.Left = 1.0625!
            Me.txtDescripcion.Name = "txtDescripcion"
            Me.txtDescripcion.Style = "text-align: center; font-size: 8.25pt; font-family: Tahoma; vertical-align: middl"& _ 
                "e"
            Me.txtDescripcion.Text = "TextBox2"
            Me.txtDescripcion.Top = 0!
            Me.txtDescripcion.Width = 1.875!
            '
            'txtTalla
            '
            Me.txtTalla.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtTalla.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtTalla.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtTalla.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtTalla.DataField = "Talla"
            Me.txtTalla.Height = 0.25!
            Me.txtTalla.Left = 2.9375!
            Me.txtTalla.Name = "txtTalla"
            Me.txtTalla.Style = "text-align: center; font-size: 8.25pt; font-family: Tahoma; vertical-align: middl"& _ 
                "e"
            Me.txtTalla.Text = "TextBox3"
            Me.txtTalla.Top = 0!
            Me.txtTalla.Width = 0.438!
            '
            'txtMotivo
            '
            Me.txtMotivo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtMotivo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtMotivo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtMotivo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtMotivo.DataField = "Motivo"
            Me.txtMotivo.Height = 0.25!
            Me.txtMotivo.Left = 3.375!
            Me.txtMotivo.Name = "txtMotivo"
            Me.txtMotivo.Style = "text-align: center; font-size: 8.25pt; font-family: Tahoma; vertical-align: middl"& _ 
                "e"
            Me.txtMotivo.Text = "TextBox4"
            Me.txtMotivo.Top = 0!
            Me.txtMotivo.Width = 1.3125!
            '
            'txtCantidad
            '
            Me.txtCantidad.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtCantidad.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtCantidad.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtCantidad.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtCantidad.DataField = "Cantidad"
            Me.txtCantidad.Height = 0.25!
            Me.txtCantidad.Left = 4.6875!
            Me.txtCantidad.Name = "txtCantidad"
            Me.txtCantidad.Style = "text-align: center; font-size: 8.25pt; font-family: Tahoma; vertical-align: middl"& _ 
                "e"
            Me.txtCantidad.Text = "TextBox5"
            Me.txtCantidad.Top = 0!
            Me.txtCantidad.Width = 0.4375!
            '
            'txtFechaR
            '
            Me.txtFechaR.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtFechaR.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtFechaR.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtFechaR.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtFechaR.DataField = "Fecha"
            Me.txtFechaR.Height = 0.25!
            Me.txtFechaR.Left = 5.125!
            Me.txtFechaR.Name = "txtFechaR"
            Me.txtFechaR.OutputFormat = resources.GetString("txtFechaR.OutputFormat")
            Me.txtFechaR.Style = "text-align: center; font-size: 8.25pt; font-family: Tahoma; vertical-align: middl"& _ 
                "e"
            Me.txtFechaR.Top = 0!
            Me.txtFechaR.Width = 0.688!
            '
            'txtHora
            '
            Me.txtHora.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtHora.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtHora.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtHora.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtHora.DataField = "Hora"
            Me.txtHora.Height = 0.25!
            Me.txtHora.Left = 5.8125!
            Me.txtHora.Name = "txtHora"
            Me.txtHora.OutputFormat = resources.GetString("txtHora.OutputFormat")
            Me.txtHora.Style = "text-align: center; font-size: 8.25pt; font-family: Tahoma; vertical-align: middl"& _ 
                "e"
            Me.txtHora.Top = 0!
            Me.txtHora.Width = 0.625!
            '
            'txtResponsable
            '
            Me.txtResponsable.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtResponsable.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtResponsable.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtResponsable.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtResponsable.DataField = "Responsable"
            Me.txtResponsable.Height = 0.25!
            Me.txtResponsable.Left = 6.4375!
            Me.txtResponsable.Name = "txtResponsable"
            Me.txtResponsable.Style = "text-align: center; font-size: 8.25pt; font-family: Tahoma; vertical-align: middl"& _ 
                "e"
            Me.txtResponsable.Top = 0!
            Me.txtResponsable.Width = 0.938!
            '
            'ActiveReport1
            '
            Me.MasterReport = false
            Me.PageSettings.Margins.Bottom = 0.5!
            Me.PageSettings.Margins.Left = 0.7!
            Me.PageSettings.Margins.Right = 0.3!
            Me.PageSettings.Margins.Top = 0.5!
            Me.PageSettings.PaperHeight = 11!
            Me.PageSettings.PaperWidth = 8.5!
            Me.PrintWidth = 7.447917!
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
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label5,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label6,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label7,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label8,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtSucursal,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblFecha,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblHora,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblResponsable,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtCodigo,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtDescripcion,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtTalla,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtMotivo,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtCantidad,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFechaR,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtHora,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtResponsable,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        
	End Sub

#End Region


End Class
