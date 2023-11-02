Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Public Class Poliza
Inherits DataDynamics.ActiveReports.ActiveReport

#Region "ActiveReports Designer generated code"
    Private WithEvents ReportHeader As ReportHeader = Nothing
    Private WithEvents PageHeader As PageHeader = Nothing
    Private WithEvents GroupHeader1 As GroupHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents GroupFooter1 As GroupFooter = Nothing
    Private WithEvents PageFooter As PageFooter = Nothing
    Private WithEvents ReportFooter As ReportFooter = Nothing
	Private LblEmpresa As Label = Nothing
	Private Picture1 As Picture = Nothing
	Private Label3 As Label = Nothing
	Private LblDireccion As Label = Nothing
	Private Label5 As Label = Nothing
	Private LblRegFed As Label = Nothing
	Private Label6 As Label = Nothing
	Private Label7 As Label = Nothing
	Private Label8 As Label = Nothing
	Private LblCP As Label = Nothing
	Private LblRegEst As Label = Nothing
	Private LblRegCam As Label = Nothing
	Private Label26 As Label = Nothing
	Private LblFechaH As Label = Nothing
	Private Line1 As Line = Nothing
	Private Line2 As Line = Nothing
	Private Label9 As Label = Nothing
	Private Label10 As Label = Nothing
	Private Label11 As Label = Nothing
	Private Label12 As Label = Nothing
	Private Label13 As Label = Nothing
	Private Label14 As Label = Nothing
	Private Label15 As Label = Nothing
	Private Label16 As Label = Nothing
	Private Label17 As Label = Nothing
	Private Label18 As Label = Nothing
	Private Label19 As Label = Nothing
	Private TextBox5 As TextBox = Nothing
	Private TextBox6 As TextBox = Nothing
	Private TextBox7 As TextBox = Nothing
	Private TextBox8 As TextBox = Nothing
	Private TxtReferencia As TextBox = Nothing
	Private TextBox1 As TextBox = Nothing
	Private TextBox2 As TextBox = Nothing
	Private TxtCargo As TextBox = Nothing
	Private TxtAbono As TextBox = Nothing
	Private TextBox11 As TextBox = Nothing
	Private TextBox9 As TextBox = Nothing
	Private TextBox10 As TextBox = Nothing
	Private Label27 As Label = Nothing
	Private Label2 As Label = Nothing
	Private TxtPagina As TextBox = Nothing
	Private Label25 As Label = Nothing
	Private TxtPagAll As TextBox = Nothing
	Private Line5 As Line = Nothing
	Private Label20 As Label = Nothing
	Private LblFecha As Label = Nothing
	Private Label21 As Label = Nothing
	Private Label22 As Label = Nothing
	Private Label23 As Label = Nothing
	Private Label24 As Label = Nothing
	Private Line3 As Line = Nothing
	Private Line4 As Line = Nothing
	Private LblFondoCaja As Label = Nothing
	Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Poliza))
            Me.Detail = New DataDynamics.ActiveReports.Detail()
            Me.ReportHeader = New DataDynamics.ActiveReports.ReportHeader()
            Me.ReportFooter = New DataDynamics.ActiveReports.ReportFooter()
            Me.PageHeader = New DataDynamics.ActiveReports.PageHeader()
            Me.PageFooter = New DataDynamics.ActiveReports.PageFooter()
            Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader()
            Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter()
            Me.LblEmpresa = New DataDynamics.ActiveReports.Label()
            Me.Picture1 = New DataDynamics.ActiveReports.Picture()
            Me.Label3 = New DataDynamics.ActiveReports.Label()
            Me.LblDireccion = New DataDynamics.ActiveReports.Label()
            Me.Label5 = New DataDynamics.ActiveReports.Label()
            Me.LblRegFed = New DataDynamics.ActiveReports.Label()
            Me.Label6 = New DataDynamics.ActiveReports.Label()
            Me.Label7 = New DataDynamics.ActiveReports.Label()
            Me.Label8 = New DataDynamics.ActiveReports.Label()
            Me.LblCP = New DataDynamics.ActiveReports.Label()
            Me.LblRegEst = New DataDynamics.ActiveReports.Label()
            Me.LblRegCam = New DataDynamics.ActiveReports.Label()
            Me.Label26 = New DataDynamics.ActiveReports.Label()
            Me.LblFechaH = New DataDynamics.ActiveReports.Label()
            Me.Line1 = New DataDynamics.ActiveReports.Line()
            Me.Line2 = New DataDynamics.ActiveReports.Line()
            Me.Label9 = New DataDynamics.ActiveReports.Label()
            Me.Label10 = New DataDynamics.ActiveReports.Label()
            Me.Label11 = New DataDynamics.ActiveReports.Label()
            Me.Label12 = New DataDynamics.ActiveReports.Label()
            Me.Label13 = New DataDynamics.ActiveReports.Label()
            Me.Label14 = New DataDynamics.ActiveReports.Label()
            Me.Label15 = New DataDynamics.ActiveReports.Label()
            Me.Label16 = New DataDynamics.ActiveReports.Label()
            Me.Label17 = New DataDynamics.ActiveReports.Label()
            Me.Label18 = New DataDynamics.ActiveReports.Label()
            Me.Label19 = New DataDynamics.ActiveReports.Label()
            Me.TextBox5 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox6 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox7 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox8 = New DataDynamics.ActiveReports.TextBox()
            Me.TxtReferencia = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox1 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox2 = New DataDynamics.ActiveReports.TextBox()
            Me.TxtCargo = New DataDynamics.ActiveReports.TextBox()
            Me.TxtAbono = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox11 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox9 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox10 = New DataDynamics.ActiveReports.TextBox()
            Me.Label27 = New DataDynamics.ActiveReports.Label()
            Me.Label2 = New DataDynamics.ActiveReports.Label()
            Me.TxtPagina = New DataDynamics.ActiveReports.TextBox()
            Me.Label25 = New DataDynamics.ActiveReports.Label()
            Me.TxtPagAll = New DataDynamics.ActiveReports.TextBox()
            Me.Line5 = New DataDynamics.ActiveReports.Line()
            Me.Label20 = New DataDynamics.ActiveReports.Label()
            Me.LblFecha = New DataDynamics.ActiveReports.Label()
            Me.Label21 = New DataDynamics.ActiveReports.Label()
            Me.Label22 = New DataDynamics.ActiveReports.Label()
            Me.Label23 = New DataDynamics.ActiveReports.Label()
            Me.Label24 = New DataDynamics.ActiveReports.Label()
            Me.Line3 = New DataDynamics.ActiveReports.Line()
            Me.Line4 = New DataDynamics.ActiveReports.Line()
            Me.LblFondoCaja = New DataDynamics.ActiveReports.Label()
            CType(Me.LblEmpresa,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Picture1,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label3,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.LblDireccion,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label5,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.LblRegFed,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label6,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label7,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label8,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.LblCP,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.LblRegEst,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.LblRegCam,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label26,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.LblFechaH,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label9,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label10,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label11,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label12,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label13,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label14,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label15,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label16,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label17,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label18,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label19,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox5,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox6,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox7,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox8,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TxtReferencia,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox1,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox2,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TxtCargo,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TxtAbono,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox11,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox9,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox10,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label27,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TxtPagina,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label25,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TxtPagAll,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label20,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.LblFecha,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label21,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label22,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label23,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label24,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.LblFondoCaja,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
            '
            'Detail
            '
            Me.Detail.ColumnSpacing = 0!
            Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TxtReferencia, Me.TextBox1, Me.TextBox2, Me.TxtCargo, Me.TxtAbono, Me.TextBox11})
            Me.Detail.Height = 0.375!
            Me.Detail.Name = "Detail"
            '
            'ReportHeader
            '
            Me.ReportHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.LblEmpresa, Me.Picture1, Me.Label3, Me.LblDireccion, Me.Label5, Me.LblRegFed, Me.Label6, Me.Label7, Me.Label8, Me.LblCP, Me.LblRegEst, Me.LblRegCam, Me.Label26, Me.LblFechaH})
            Me.ReportHeader.Height = 0.625!
            Me.ReportHeader.Name = "ReportHeader"
            '
            'ReportFooter
            '
            Me.ReportFooter.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label20, Me.LblFecha, Me.Label21, Me.Label22, Me.Label23, Me.Label24, Me.Line3, Me.Line4, Me.LblFondoCaja})
            Me.ReportFooter.Height = 1.040972!
            Me.ReportFooter.Name = "ReportFooter"
            '
            'PageHeader
            '
            Me.PageHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Line1, Me.Line2, Me.Label9, Me.Label10, Me.Label11, Me.Label12, Me.Label13, Me.Label14, Me.Label15, Me.Label16, Me.Label17, Me.Label18, Me.Label19})
            Me.PageHeader.Height = 0.4375!
            Me.PageHeader.Name = "PageHeader"
            '
            'PageFooter
            '
            Me.PageFooter.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label2, Me.TxtPagina, Me.Label25, Me.TxtPagAll, Me.Line5})
            Me.PageFooter.Height = 0.21875!
            Me.PageFooter.Name = "PageFooter"
            '
            'GroupHeader1
            '
            Me.GroupHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TextBox5, Me.TextBox6, Me.TextBox7, Me.TextBox8})
            Me.GroupHeader1.DataField = "Fecha"
            Me.GroupHeader1.Height = 0.25!
            Me.GroupHeader1.Name = "GroupHeader1"
            '
            'GroupFooter1
            '
            Me.GroupFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TextBox9, Me.TextBox10, Me.Label27})
            Me.GroupFooter1.Height = 0.25!
            Me.GroupFooter1.Name = "GroupFooter1"
            '
            'LblEmpresa
            '
            Me.LblEmpresa.Height = 0.1875!
            Me.LblEmpresa.HyperLink = Nothing
            Me.LblEmpresa.Left = 0.875!
            Me.LblEmpresa.Name = "LblEmpresa"
            Me.LblEmpresa.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
            Me.LblEmpresa.Text = "COMERCIAL DPORTENIS, S.A. DE C.V."
            Me.LblEmpresa.Top = 0!
            Me.LblEmpresa.Width = 5.3125!
            '
            'Picture1
            '
            Me.Picture1.Height = 0.5625!
            Me.Picture1.ImageData = CType(resources.GetObject("Picture1.ImageData"),System.IO.Stream)
            Me.Picture1.Left = 0!
            Me.Picture1.LineColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(255,Byte),Integer), CType(CType(255,Byte),Integer))
            Me.Picture1.LineWeight = 0!
            Me.Picture1.Name = "Picture1"
            Me.Picture1.SizeMode = DataDynamics.ActiveReports.SizeModes.Stretch
            Me.Picture1.Top = 0!
            Me.Picture1.Width = 0.75!
            '
            'Label3
            '
            Me.Label3.Height = 0.1875!
            Me.Label3.HyperLink = Nothing
            Me.Label3.Left = 0.875!
            Me.Label3.Name = "Label3"
            Me.Label3.Style = "font-size: 8.25pt"
            Me.Label3.Text = "Dirección:"
            Me.Label3.Top = 0.1875!
            Me.Label3.Width = 0.625!
            '
            'LblDireccion
            '
            Me.LblDireccion.Height = 0.1875!
            Me.LblDireccion.HyperLink = Nothing
            Me.LblDireccion.Left = 1.5!
            Me.LblDireccion.Name = "LblDireccion"
            Me.LblDireccion.Style = "font-size: 8.25pt"
            Me.LblDireccion.Text = "Dirección"
            Me.LblDireccion.Top = 0.1875!
            Me.LblDireccion.Width = 2.0625!
            '
            'Label5
            '
            Me.Label5.Height = 0.1875!
            Me.Label5.HyperLink = Nothing
            Me.Label5.Left = 0.875!
            Me.Label5.Name = "Label5"
            Me.Label5.Style = "font-size: 8.25pt"
            Me.Label5.Text = "Reg. Fed.:"
            Me.Label5.Top = 0.375!
            Me.Label5.Width = 0.625!
            '
            'LblRegFed
            '
            Me.LblRegFed.Height = 0.1875!
            Me.LblRegFed.HyperLink = Nothing
            Me.LblRegFed.Left = 1.5!
            Me.LblRegFed.Name = "LblRegFed"
            Me.LblRegFed.Style = "font-size: 8.25pt"
            Me.LblRegFed.Text = "Registro Federal"
            Me.LblRegFed.Top = 0.375!
            Me.LblRegFed.Width = 1.375!
            '
            'Label6
            '
            Me.Label6.Height = 0.1875!
            Me.Label6.HyperLink = Nothing
            Me.Label6.Left = 3.822917!
            Me.Label6.Name = "Label6"
            Me.Label6.Style = "font-size: 8.25pt"
            Me.Label6.Text = "Código Postal:"
            Me.Label6.Top = 0.1875!
            Me.Label6.Width = 0.8125!
            '
            'Label7
            '
            Me.Label7.Height = 0.1875!
            Me.Label7.HyperLink = Nothing
            Me.Label7.Left = 5.447917!
            Me.Label7.Name = "Label7"
            Me.Label7.Style = "font-size: 8.25pt"
            Me.Label7.Text = "Reg. Camara:"
            Me.Label7.Top = 0.1875!
            Me.Label7.Width = 0.75!
            '
            'Label8
            '
            Me.Label8.Height = 0.1875!
            Me.Label8.HyperLink = Nothing
            Me.Label8.Left = 3.822917!
            Me.Label8.Name = "Label8"
            Me.Label8.Style = "font-size: 8.25pt"
            Me.Label8.Text = "Reg. Estatal:"
            Me.Label8.Top = 0.375!
            Me.Label8.Width = 0.75!
            '
            'LblCP
            '
            Me.LblCP.Height = 0.1875!
            Me.LblCP.HyperLink = Nothing
            Me.LblCP.Left = 4.635417!
            Me.LblCP.Name = "LblCP"
            Me.LblCP.Style = "font-size: 8.25pt"
            Me.LblCP.Text = "Código Postal"
            Me.LblCP.Top = 0.1875!
            Me.LblCP.Width = 0.8125!
            '
            'LblRegEst
            '
            Me.LblRegEst.Height = 0.1875!
            Me.LblRegEst.HyperLink = Nothing
            Me.LblRegEst.Left = 4.635417!
            Me.LblRegEst.Name = "LblRegEst"
            Me.LblRegEst.Style = "font-size: 8.25pt"
            Me.LblRegEst.Text = "Reg. Estatal"
            Me.LblRegEst.Top = 0.375!
            Me.LblRegEst.Width = 0.8125!
            '
            'LblRegCam
            '
            Me.LblRegCam.Height = 0.1875!
            Me.LblRegCam.HyperLink = Nothing
            Me.LblRegCam.Left = 6.197917!
            Me.LblRegCam.Name = "LblRegCam"
            Me.LblRegCam.Style = "font-size: 8.25pt"
            Me.LblRegCam.Text = "Reg. Camara"
            Me.LblRegCam.Top = 0.1875!
            Me.LblRegCam.Width = 0.875!
            '
            'Label26
            '
            Me.Label26.Height = 0.1875!
            Me.Label26.HyperLink = Nothing
            Me.Label26.Left = 5.9375!
            Me.Label26.Name = "Label26"
            Me.Label26.Style = "font-size: 8.25pt"
            Me.Label26.Text = "Fecha:"
            Me.Label26.Top = 0!
            Me.Label26.Width = 0.40625!
            '
            'LblFechaH
            '
            Me.LblFechaH.Height = 0.1875!
            Me.LblFechaH.HyperLink = Nothing
            Me.LblFechaH.Left = 6.385417!
            Me.LblFechaH.Name = "LblFechaH"
            Me.LblFechaH.Style = "font-size: 8.25pt"
            Me.LblFechaH.Text = "Fecha"
            Me.LblFechaH.Top = 0!
            Me.LblFechaH.Width = 0.6875!
            '
            'Line1
            '
            Me.Line1.Height = 0!
            Me.Line1.Left = 0.0625!
            Me.Line1.LineWeight = 1!
            Me.Line1.Name = "Line1"
            Me.Line1.Top = 0!
            Me.Line1.Width = 7.0625!
            Me.Line1.X1 = 0.0625!
            Me.Line1.X2 = 7.125!
            Me.Line1.Y1 = 0!
            Me.Line1.Y2 = 0!
            '
            'Line2
            '
            Me.Line2.Height = 0.01388898!
            Me.Line2.Left = 0.06944445!
            Me.Line2.LineWeight = 1!
            Me.Line2.Name = "Line2"
            Me.Line2.Top = 0.375!
            Me.Line2.Width = 7.055555!
            Me.Line2.X1 = 0.06944445!
            Me.Line2.X2 = 7.125!
            Me.Line2.Y1 = 0.388889!
            Me.Line2.Y2 = 0.375!
            '
            'Label9
            '
            Me.Label9.Height = 0.1875!
            Me.Label9.HyperLink = Nothing
            Me.Label9.Left = 0.0625!
            Me.Label9.Name = "Label9"
            Me.Label9.Style = "font-size: 8.25pt"
            Me.Label9.Text = "Fecha"
            Me.Label9.Top = 0!
            Me.Label9.Width = 0.4375!
            '
            'Label10
            '
            Me.Label10.Height = 0.1875!
            Me.Label10.HyperLink = Nothing
            Me.Label10.Left = 0.0625!
            Me.Label10.Name = "Label10"
            Me.Label10.Style = "font-size: 8.25pt"
            Me.Label10.Text = "No. Refer."
            Me.Label10.Top = 0.1875!
            Me.Label10.Width = 0.5625!
            '
            'Label11
            '
            Me.Label11.Height = 0.1875!
            Me.Label11.HyperLink = Nothing
            Me.Label11.Left = 0.75!
            Me.Label11.Name = "Label11"
            Me.Label11.Style = "font-size: 8.25pt"
            Me.Label11.Text = "Tipo"
            Me.Label11.Top = 0!
            Me.Label11.Width = 0.3125!
            '
            'Label12
            '
            Me.Label12.Height = 0.1875!
            Me.Label12.HyperLink = Nothing
            Me.Label12.Left = 1.0625!
            Me.Label12.Name = "Label12"
            Me.Label12.Style = "font-size: 8.25pt"
            Me.Label12.Text = "Cuenta"
            Me.Label12.Top = 0.1875!
            Me.Label12.Width = 0.9375!
            '
            'Label13
            '
            Me.Label13.Height = 0.1875!
            Me.Label13.HyperLink = Nothing
            Me.Label13.Left = 1.8125!
            Me.Label13.Name = "Label13"
            Me.Label13.Style = "font-size: 8.25pt"
            Me.Label13.Text = "Número"
            Me.Label13.Top = 0!
            Me.Label13.Width = 0.4375!
            '
            'Label14
            '
            Me.Label14.Height = 0.1875!
            Me.Label14.HyperLink = Nothing
            Me.Label14.Left = 2.5625!
            Me.Label14.Name = "Label14"
            Me.Label14.Style = "font-size: 8.25pt"
            Me.Label14.Text = "Concepto"
            Me.Label14.Top = 0!
            Me.Label14.Width = 0.65625!
            '
            'Label15
            '
            Me.Label15.Height = 0.1875!
            Me.Label15.HyperLink = Nothing
            Me.Label15.Left = 4.25!
            Me.Label15.Name = "Label15"
            Me.Label15.Style = "font-size: 8.25pt"
            Me.Label15.Text = "Nombre"
            Me.Label15.Top = 0.1875!
            Me.Label15.Width = 0.5!
            '
            'Label16
            '
            Me.Label16.Height = 0.1875!
            Me.Label16.HyperLink = Nothing
            Me.Label16.Left = 4.75!
            Me.Label16.Name = "Label16"
            Me.Label16.Style = "text-align: center; font-size: 8.25pt"
            Me.Label16.Text = "Diario"
            Me.Label16.Top = 0.1875!
            Me.Label16.Width = 0.4375!
            '
            'Label17
            '
            Me.Label17.Height = 0.1875!
            Me.Label17.HyperLink = Nothing
            Me.Label17.Left = 5.239583!
            Me.Label17.Name = "Label17"
            Me.Label17.Style = "text-align: center; font-size: 8.25pt"
            Me.Label17.Text = "Clase Diario"
            Me.Label17.Top = 0!
            Me.Label17.Width = 1.875!
            '
            'Label18
            '
            Me.Label18.Height = 0.1875!
            Me.Label18.HyperLink = Nothing
            Me.Label18.Left = 5.25!
            Me.Label18.Name = "Label18"
            Me.Label18.Style = "text-align: center; font-size: 8.25pt"
            Me.Label18.Text = "Cargos"
            Me.Label18.Top = 0.1875!
            Me.Label18.Width = 0.90625!
            '
            'Label19
            '
            Me.Label19.Height = 0.1875!
            Me.Label19.HyperLink = Nothing
            Me.Label19.Left = 6.1875!
            Me.Label19.Name = "Label19"
            Me.Label19.Style = "text-align: center; font-size: 8.25pt"
            Me.Label19.Text = "Abonos"
            Me.Label19.Top = 0.1875!
            Me.Label19.Width = 0.90625!
            '
            'TextBox5
            '
            Me.TextBox5.DataField = "Fecha"
            Me.TextBox5.Height = 0.1875!
            Me.TextBox5.Left = 0.0625!
            Me.TextBox5.Name = "TextBox5"
            Me.TextBox5.OutputFormat = resources.GetString("TextBox5.OutputFormat")
            Me.TextBox5.Style = "font-size: 8.25pt"
            Me.TextBox5.Top = 0!
            Me.TextBox5.Width = 0.6875!
            '
            'TextBox6
            '
            Me.TextBox6.DataField = "Tipo"
            Me.TextBox6.Height = 0.1875!
            Me.TextBox6.Left = 0.7708333!
            Me.TextBox6.Name = "TextBox6"
            Me.TextBox6.Style = "font-size: 8.25pt"
            Me.TextBox6.Top = 0!
            Me.TextBox6.Width = 0.9791667!
            '
            'TextBox7
            '
            Me.TextBox7.DataField = "Numero"
            Me.TextBox7.Height = 0.1875!
            Me.TextBox7.Left = 1.8125!
            Me.TextBox7.Name = "TextBox7"
            Me.TextBox7.Style = "font-size: 8.25pt"
            Me.TextBox7.Top = 0!
            Me.TextBox7.Width = 0.6875!
            '
            'TextBox8
            '
            Me.TextBox8.DataField = "Concepto"
            Me.TextBox8.Height = 0.1875!
            Me.TextBox8.Left = 2.5625!
            Me.TextBox8.Name = "TextBox8"
            Me.TextBox8.Style = "font-size: 8.25pt"
            Me.TextBox8.Top = 0!
            Me.TextBox8.Width = 3!
            '
            'TxtReferencia
            '
            Me.TxtReferencia.Height = 0.1875!
            Me.TxtReferencia.Left = 0.07874014!
            Me.TxtReferencia.Name = "TxtReferencia"
            Me.TxtReferencia.Style = "font-size: 8.25pt"
            Me.TxtReferencia.Top = 0!
            Me.TxtReferencia.Width = 0.375!
            '
            'TextBox1
            '
            Me.TextBox1.DataField = "Cuenta"
            Me.TextBox1.Height = 0.1875!
            Me.TextBox1.Left = 1.0625!
            Me.TextBox1.Name = "TextBox1"
            Me.TextBox1.Style = "font-size: 8.25pt"
            Me.TextBox1.Top = 0!
            Me.TextBox1.Width = 1.4375!
            '
            'TextBox2
            '
            Me.TextBox2.DataField = "ConceptoU"
            Me.TextBox2.Height = 0.1875!
            Me.TextBox2.Left = 2.5625!
            Me.TextBox2.Name = "TextBox2"
            Me.TextBox2.Style = "font-size: 8.25pt"
            Me.TextBox2.Top = 0!
            Me.TextBox2.Width = 2.3125!
            '
            'TxtCargo
            '
            Me.TxtCargo.DataField = "Cargo"
            Me.TxtCargo.Height = 0.1875!
            Me.TxtCargo.Left = 5.25!
            Me.TxtCargo.Name = "TxtCargo"
            Me.TxtCargo.OutputFormat = resources.GetString("TxtCargo.OutputFormat")
            Me.TxtCargo.Style = "text-align: right; font-size: 8.25pt"
            Me.TxtCargo.Text = "$0.00"
            Me.TxtCargo.Top = 0!
            Me.TxtCargo.Width = 0.875!
            '
            'TxtAbono
            '
            Me.TxtAbono.DataField = "Abono"
            Me.TxtAbono.Height = 0.1875!
            Me.TxtAbono.Left = 6.1875!
            Me.TxtAbono.Name = "TxtAbono"
            Me.TxtAbono.OutputFormat = resources.GetString("TxtAbono.OutputFormat")
            Me.TxtAbono.Style = "text-align: right; font-size: 8.25pt"
            Me.TxtAbono.Text = "$0.00"
            Me.TxtAbono.Top = 0!
            Me.TxtAbono.Width = 0.875!
            '
            'TextBox11
            '
            Me.TextBox11.DataField = "ConceptoM"
            Me.TextBox11.Height = 0.1875!
            Me.TextBox11.Left = 2.5625!
            Me.TextBox11.Name = "TextBox11"
            Me.TextBox11.Style = "font-size: 8.25pt"
            Me.TextBox11.Top = 0.1875!
            Me.TextBox11.Width = 2.3125!
            '
            'TextBox9
            '
            Me.TextBox9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.[Double]
            Me.TextBox9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.TextBox9.DataField = "Cargo"
            Me.TextBox9.Height = 0.1875!
            Me.TextBox9.Left = 5.239583!
            Me.TextBox9.Name = "TextBox9"
            Me.TextBox9.OutputFormat = resources.GetString("TextBox9.OutputFormat")
            Me.TextBox9.Style = "text-align: right; font-size: 8.25pt"
            Me.TextBox9.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
            Me.TextBox9.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
            Me.TextBox9.Top = 0!
            Me.TextBox9.Width = 0.875!
            '
            'TextBox10
            '
            Me.TextBox10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.[Double]
            Me.TextBox10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.TextBox10.DataField = "Abono"
            Me.TextBox10.Height = 0.1875!
            Me.TextBox10.Left = 6.1875!
            Me.TextBox10.Name = "TextBox10"
            Me.TextBox10.OutputFormat = resources.GetString("TextBox10.OutputFormat")
            Me.TextBox10.Style = "text-align: right; font-size: 8.25pt"
            Me.TextBox10.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
            Me.TextBox10.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
            Me.TextBox10.Top = 0!
            Me.TextBox10.Width = 0.875!
            '
            'Label27
            '
            Me.Label27.Height = 0.1875!
            Me.Label27.HyperLink = Nothing
            Me.Label27.Left = 4.302083!
            Me.Label27.Name = "Label27"
            Me.Label27.Style = "font-size: 8.25pt"
            Me.Label27.Text = "Total Poliza:"
            Me.Label27.Top = 0!
            Me.Label27.Width = 0.6875!
            '
            'Label2
            '
            Me.Label2.Height = 0.1875!
            Me.Label2.HyperLink = Nothing
            Me.Label2.Left = 5.625!
            Me.Label2.Name = "Label2"
            Me.Label2.Style = "font-size: 8.25pt"
            Me.Label2.Text = "Hoja:"
            Me.Label2.Top = 0!
            Me.Label2.Width = 0.2916665!
            '
            'TxtPagina
            '
            Me.TxtPagina.Height = 0.1875!
            Me.TxtPagina.Left = 5.9375!
            Me.TxtPagina.Name = "TxtPagina"
            Me.TxtPagina.Style = "text-align: right; font-size: 8.25pt"
            Me.TxtPagina.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
            Me.TxtPagina.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount
            Me.TxtPagina.Text = "Pagina"
            Me.TxtPagina.Top = 0!
            Me.TxtPagina.Width = 0.40625!
            '
            'Label25
            '
            Me.Label25.Height = 0.1875!
            Me.Label25.HyperLink = Nothing
            Me.Label25.Left = 6.375!
            Me.Label25.Name = "Label25"
            Me.Label25.Style = "font-size: 8.25pt"
            Me.Label25.Text = "de:"
            Me.Label25.Top = 0!
            Me.Label25.Width = 0.1875!
            '
            'TxtPagAll
            '
            Me.TxtPagAll.Height = 0.1875!
            Me.TxtPagAll.Left = 6.5625!
            Me.TxtPagAll.Name = "TxtPagAll"
            Me.TxtPagAll.Style = "text-align: right; font-size: 8.25pt"
            Me.TxtPagAll.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
            Me.TxtPagAll.SummaryType = DataDynamics.ActiveReports.SummaryType.PageTotal
            Me.TxtPagAll.Text = "Pagina"
            Me.TxtPagAll.Top = 0!
            Me.TxtPagAll.Width = 0.4375!
            '
            'Line5
            '
            Me.Line5.Height = 0!
            Me.Line5.Left = 0.0625!
            Me.Line5.LineWeight = 1!
            Me.Line5.Name = "Line5"
            Me.Line5.Top = 0!
            Me.Line5.Width = 7!
            Me.Line5.X1 = 0.0625!
            Me.Line5.X2 = 7.0625!
            Me.Line5.Y1 = 0!
            Me.Line5.Y2 = 0!
            '
            'Label20
            '
            Me.Label20.Height = 0.1875!
            Me.Label20.HyperLink = Nothing
            Me.Label20.Left = 0.125!
            Me.Label20.Name = "Label20"
            Me.Label20.Style = "text-align: justify; font-size: 8.25pt"
            Me.Label20.Text = "La información aqui presentada es real, generada de la operación del día de hoy"
            Me.Label20.Top = 0!
            Me.Label20.Width = 4.125!
            '
            'LblFecha
            '
            Me.LblFecha.Height = 0.1875!
            Me.LblFecha.HyperLink = Nothing
            Me.LblFecha.Left = 4.1875!
            Me.LblFecha.Name = "LblFecha"
            Me.LblFecha.Style = "text-align: center; font-size: 8.25pt"
            Me.LblFecha.Text = "Fecha"
            Me.LblFecha.Top = 0!
            Me.LblFecha.Width = 0.6875!
            '
            'Label21
            '
            Me.Label21.Height = 0.1875!
            Me.Label21.HyperLink = Nothing
            Me.Label21.Left = 4.875!
            Me.Label21.Name = "Label21"
            Me.Label21.Style = "text-align: justify; font-size: 8.25pt"
            Me.Label21.Text = ", realizada con el DPTienda. Por lo que de"
            Me.Label21.Top = 0!
            Me.Label21.Width = 2.1875!
            '
            'Label22
            '
            Me.Label22.Height = 0.3125!
            Me.Label22.HyperLink = Nothing
            Me.Label22.Left = 0.125!
            Me.Label22.Name = "Label22"
            Me.Label22.Style = "text-align: justify; font-size: 8.25pt"
            Me.Label22.Text = "existir diferencias a cargos en los ingresos reportados acepto cubrir la cantidad"& _ 
                " mencionada en la cuenta contable diferencias. El Fondo de Caja cerro con"
            Me.Label22.Top = 0.125!
            Me.Label22.Width = 6.9375!
            '
            'Label23
            '
            Me.Label23.Height = 0.1875!
            Me.Label23.HyperLink = Nothing
            Me.Label23.Left = 0.125!
            Me.Label23.Name = "Label23"
            Me.Label23.Style = "font-size: 8.25pt"
            Me.Label23.Text = "Responsable:"
            Me.Label23.Top = 0.625!
            Me.Label23.Width = 0.75!
            '
            'Label24
            '
            Me.Label24.Height = 0.1875!
            Me.Label24.HyperLink = Nothing
            Me.Label24.Left = 0.125!
            Me.Label24.Name = "Label24"
            Me.Label24.Style = "font-size: 8.25pt"
            Me.Label24.Text = "Reviso:"
            Me.Label24.Top = 0.8125!
            Me.Label24.Width = 0.75!
            '
            'Line3
            '
            Me.Line3.Height = 0!
            Me.Line3.Left = 0.9444444!
            Me.Line3.LineWeight = 1!
            Me.Line3.Name = "Line3"
            Me.Line3.Top = 0.7569444!
            Me.Line3.Width = 2.4375!
            Me.Line3.X1 = 0.9444444!
            Me.Line3.X2 = 3.381944!
            Me.Line3.Y1 = 0.7569444!
            Me.Line3.Y2 = 0.7569444!
            '
            'Line4
            '
            Me.Line4.Height = 0!
            Me.Line4.Left = 0.9444444!
            Me.Line4.LineWeight = 1!
            Me.Line4.Name = "Line4"
            Me.Line4.Top = 0.9444444!
            Me.Line4.Width = 2.4375!
            Me.Line4.X1 = 0.9444444!
            Me.Line4.X2 = 3.381944!
            Me.Line4.Y1 = 0.9444444!
            Me.Line4.Y2 = 0.9444444!
            '
            'LblFondoCaja
            '
            Me.LblFondoCaja.Height = 0.1875!
            Me.LblFondoCaja.HyperLink = Nothing
            Me.LblFondoCaja.Left = 1.0625!
            Me.LblFondoCaja.Name = "LblFondoCaja"
            Me.LblFondoCaja.Style = "font-size: 8.25pt"
            Me.LblFondoCaja.Text = "Fondo Caja"
            Me.LblFondoCaja.Top = 0.25!
            Me.LblFondoCaja.Width = 0.75!
            '
            'ActiveReport1
            '
            Me.MasterReport = false
            Me.PageSettings.Margins.Bottom = 0.39375!
            Me.PageSettings.Margins.Left = 0.39375!
            Me.PageSettings.Margins.Right = 0.39375!
            Me.PageSettings.Margins.Top = 0.39375!
            Me.PageSettings.PaperHeight = 11!
            Me.PageSettings.PaperWidth = 8.5!
            Me.PrintWidth = 7.166667!
            Me.Sections.Add(Me.ReportHeader)
            Me.Sections.Add(Me.PageHeader)
            Me.Sections.Add(Me.GroupHeader1)
            Me.Sections.Add(Me.Detail)
            Me.Sections.Add(Me.GroupFooter1)
            Me.Sections.Add(Me.PageFooter)
            Me.Sections.Add(Me.ReportFooter)
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo"& _ 
                        "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit", "Heading1", "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei"& _ 
                        "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit", "Heading2", "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo"& _ 
                        "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit", "Heading3", "Normal"))
            CType(Me.LblEmpresa,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Picture1,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label3,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.LblDireccion,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label5,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.LblRegFed,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label6,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label7,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label8,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.LblCP,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.LblRegEst,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.LblRegCam,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label26,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.LblFechaH,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label9,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label10,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label11,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label12,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label13,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label14,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label15,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label16,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label17,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label18,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label19,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox5,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox6,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox7,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox8,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TxtReferencia,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox1,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox2,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TxtCargo,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TxtAbono,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox11,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox9,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox10,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label27,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TxtPagina,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label25,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TxtPagAll,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label20,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.LblFecha,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label21,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label22,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label23,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label24,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.LblFondoCaja,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        
	End Sub

#End Region

#Region "Variables Miembros"
    Private vlConsecutivo As Integer
#End Region

#Region "Constructores"

    Public Sub New(ByVal strEmpresa As String, ByVal datFecha As Date, ByVal strDireccion As String, ByVal strRegFed As String, ByVal strCP As String, ByVal strRegEst As String, ByVal strRegCam As String, ByVal ds As DataSet, ByVal decFondo As Decimal)

        MyBase.New()
        InitializeComponent()

        Dim dvTabla As DataView = New DataView(ds.Tables(0), "Orden>=0", "Orden", DataViewRowState.CurrentRows)

        Me.DataSource = dvTabla

        Me.LblEmpresa.Text = strEmpresa
        Me.LblFechaH.Text = datFecha
        Me.LblDireccion.Text = strDireccion
        Me.LblRegFed.Text = strRegFed
        Me.LblCP.Text = strCP
        Me.LblRegEst.Text = strRegEst
        Me.LblRegCam.Text = strRegCam
        Me.LblFecha.Text = datFecha
        Me.LblFondoCaja.Text = FormatCurrency(decFondo, 2)
    End Sub

#End Region

    Private Sub Detail_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles Detail.Format
        TxtCargo.Visible = (TxtCargo.Text <> "$0.00")
        TxtAbono.Visible = (TxtAbono.Text <> "$0.00")
        TxtReferencia.Text = vlConsecutivo
        vlConsecutivo += 1
    End Sub

    Private Sub ReportHeader_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportHeader.Format

        vlConsecutivo = 1

    End Sub
End Class
