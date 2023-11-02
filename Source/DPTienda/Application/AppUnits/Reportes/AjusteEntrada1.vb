Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Public Class cAjusteEntrada
    Inherits DataDynamics.ActiveReports.ActiveReport
    Public Sub New()
        MyBase.New()
        InitializeComponent()
    End Sub
#Region "ActiveReports Designer generated code"
    Private WithEvents ReportHeader As ReportHeader = Nothing
    Private WithEvents PageHeader As PageHeader = Nothing
    Private WithEvents grpFolio As GroupHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents GroupFooter1 As GroupFooter = Nothing
    Private WithEvents PageFooter As PageFooter = Nothing
    Private WithEvents ReportFooter As ReportFooter = Nothing
	Private txtTitulo As TextBox = Nothing
	Private TxtFecha As TextBox = Nothing
	Private Label2 As Label = Nothing
	Private Label3 As Label = Nothing
	Private txtDesde As TextBox = Nothing
	Private txtHasta As TextBox = Nothing
	Private Label4 As Label = Nothing
	Private txtSucursal As TextBox = Nothing
	Private txtSucursalNombre As TextBox = Nothing
	Private Label5 As Label = Nothing
	Private Line1 As Line = Nothing
	Private Label6 As Label = Nothing
	Private Label7 As Label = Nothing
	Private Label8 As Label = Nothing
	Private Label9 As Label = Nothing
	Private Label10 As Label = Nothing
	Private Label11 As Label = Nothing
	Private Line2 As Line = Nothing
	Private txtPag As TextBox = Nothing
	Private Codigo As TextBox = Nothing
	Private Fecha As TextBox = Nothing
	Private Folio As TextBox = Nothing
	Private Color As TextBox = Nothing
	Private Total As TextBox = Nothing
	Private Talla1 As TextBox = Nothing
	Private Talla2 As TextBox = Nothing
	Private Talla3 As TextBox = Nothing
	Private Talla4 As TextBox = Nothing
	Private Talla5 As TextBox = Nothing
	Private Talla6 As TextBox = Nothing
	Private Talla7 As TextBox = Nothing
	Private T8 As TextBox = Nothing
	Private T9 As TextBox = Nothing
	Private Talla10 As TextBox = Nothing
	Private Descripcion As TextBox = Nothing
	Private Label1 As Label = Nothing
	Private C1 As TextBox = Nothing
	Private C2 As TextBox = Nothing
	Private C3 As TextBox = Nothing
	Private C4 As TextBox = Nothing
	Private C5 As TextBox = Nothing
	Private C6 As TextBox = Nothing
	Private C7 As TextBox = Nothing
	Private C8 As TextBox = Nothing
	Private C9 As TextBox = Nothing
	Private C10 As TextBox = Nothing
	Private TextBox1 As TextBox = Nothing
	Private txtObservaciones As TextBox = Nothing
	Private Line3 As Line = Nothing
	Private txtTotImporte As TextBox = Nothing
	Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(cAjusteEntrada))
            Me.Detail = New DataDynamics.ActiveReports.Detail()
            Me.ReportHeader = New DataDynamics.ActiveReports.ReportHeader()
            Me.ReportFooter = New DataDynamics.ActiveReports.ReportFooter()
            Me.PageHeader = New DataDynamics.ActiveReports.PageHeader()
            Me.PageFooter = New DataDynamics.ActiveReports.PageFooter()
            Me.grpFolio = New DataDynamics.ActiveReports.GroupHeader()
            Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter()
            Me.txtTitulo = New DataDynamics.ActiveReports.TextBox()
            Me.TxtFecha = New DataDynamics.ActiveReports.TextBox()
            Me.Label2 = New DataDynamics.ActiveReports.Label()
            Me.Label3 = New DataDynamics.ActiveReports.Label()
            Me.txtDesde = New DataDynamics.ActiveReports.TextBox()
            Me.txtHasta = New DataDynamics.ActiveReports.TextBox()
            Me.Label4 = New DataDynamics.ActiveReports.Label()
            Me.txtSucursal = New DataDynamics.ActiveReports.TextBox()
            Me.txtSucursalNombre = New DataDynamics.ActiveReports.TextBox()
            Me.Label5 = New DataDynamics.ActiveReports.Label()
            Me.Line1 = New DataDynamics.ActiveReports.Line()
            Me.Label6 = New DataDynamics.ActiveReports.Label()
            Me.Label7 = New DataDynamics.ActiveReports.Label()
            Me.Label8 = New DataDynamics.ActiveReports.Label()
            Me.Label9 = New DataDynamics.ActiveReports.Label()
            Me.Label10 = New DataDynamics.ActiveReports.Label()
            Me.Label11 = New DataDynamics.ActiveReports.Label()
            Me.Line2 = New DataDynamics.ActiveReports.Line()
            Me.txtPag = New DataDynamics.ActiveReports.TextBox()
            Me.Codigo = New DataDynamics.ActiveReports.TextBox()
            Me.Fecha = New DataDynamics.ActiveReports.TextBox()
            Me.Folio = New DataDynamics.ActiveReports.TextBox()
            Me.Color = New DataDynamics.ActiveReports.TextBox()
            Me.Total = New DataDynamics.ActiveReports.TextBox()
            Me.Talla1 = New DataDynamics.ActiveReports.TextBox()
            Me.Talla2 = New DataDynamics.ActiveReports.TextBox()
            Me.Talla3 = New DataDynamics.ActiveReports.TextBox()
            Me.Talla4 = New DataDynamics.ActiveReports.TextBox()
            Me.Talla5 = New DataDynamics.ActiveReports.TextBox()
            Me.Talla6 = New DataDynamics.ActiveReports.TextBox()
            Me.Talla7 = New DataDynamics.ActiveReports.TextBox()
            Me.T8 = New DataDynamics.ActiveReports.TextBox()
            Me.T9 = New DataDynamics.ActiveReports.TextBox()
            Me.Talla10 = New DataDynamics.ActiveReports.TextBox()
            Me.Descripcion = New DataDynamics.ActiveReports.TextBox()
            Me.Label1 = New DataDynamics.ActiveReports.Label()
            Me.C1 = New DataDynamics.ActiveReports.TextBox()
            Me.C2 = New DataDynamics.ActiveReports.TextBox()
            Me.C3 = New DataDynamics.ActiveReports.TextBox()
            Me.C4 = New DataDynamics.ActiveReports.TextBox()
            Me.C5 = New DataDynamics.ActiveReports.TextBox()
            Me.C6 = New DataDynamics.ActiveReports.TextBox()
            Me.C7 = New DataDynamics.ActiveReports.TextBox()
            Me.C8 = New DataDynamics.ActiveReports.TextBox()
            Me.C9 = New DataDynamics.ActiveReports.TextBox()
            Me.C10 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox1 = New DataDynamics.ActiveReports.TextBox()
            Me.txtObservaciones = New DataDynamics.ActiveReports.TextBox()
            Me.Line3 = New DataDynamics.ActiveReports.Line()
            Me.txtTotImporte = New DataDynamics.ActiveReports.TextBox()
            CType(Me.txtTitulo,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TxtFecha,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label3,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtDesde,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtHasta,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtSucursal,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtSucursalNombre,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label5,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label6,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label7,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label8,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label9,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label10,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label11,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtPag,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Codigo,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Fecha,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Folio,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Color,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Total,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Talla1,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Talla2,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Talla3,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Talla4,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Talla5,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Talla6,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Talla7,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.T8,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.T9,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Talla10,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Descripcion,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label1,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.C1,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.C2,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.C3,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.C4,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.C5,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.C6,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.C7,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.C8,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.C9,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.C10,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox1,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtObservaciones,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtTotImporte,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
            '
            'Detail
            '
            Me.Detail.ColumnSpacing = 0!
            Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Codigo, Me.Fecha, Me.Folio, Me.Color, Me.Total, Me.Talla1, Me.Talla2, Me.Talla3, Me.Talla4, Me.Talla5, Me.Talla6, Me.Talla7, Me.T8, Me.T9, Me.Talla10, Me.Descripcion, Me.Label1, Me.C1, Me.C2, Me.C3, Me.C4, Me.C5, Me.C6, Me.C7, Me.C8, Me.C9, Me.C10})
            Me.Detail.Height = 0.3645833!
            Me.Detail.Name = "Detail"
            '
            'ReportHeader
            '
            Me.ReportHeader.Height = 0!
            Me.ReportHeader.Name = "ReportHeader"
            '
            'ReportFooter
            '
            Me.ReportFooter.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Line3, Me.txtTotImporte})
            Me.ReportFooter.Height = 0.4375!
            Me.ReportFooter.Name = "ReportFooter"
            '
            'PageHeader
            '
            Me.PageHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtTitulo, Me.TxtFecha, Me.Label2, Me.Label3, Me.txtDesde, Me.txtHasta, Me.Label4, Me.txtSucursal, Me.txtSucursalNombre, Me.Label5, Me.Line1, Me.Label6, Me.Label7, Me.Label8, Me.Label9, Me.Label10, Me.Label11, Me.Line2, Me.txtPag})
            Me.PageHeader.Height = 1.009722!
            Me.PageHeader.Name = "PageHeader"
            '
            'PageFooter
            '
            Me.PageFooter.Height = 0.01041667!
            Me.PageFooter.Name = "PageFooter"
            '
            'grpFolio
            '
            Me.grpFolio.DataField = "Folio"
            Me.grpFolio.Height = 0!
            Me.grpFolio.Name = "grpFolio"
            '
            'GroupFooter1
            '
            Me.GroupFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TextBox1, Me.txtObservaciones})
            Me.GroupFooter1.Height = 0.1666667!
            Me.GroupFooter1.Name = "GroupFooter1"
            '
            'txtTitulo
            '
            Me.txtTitulo.Height = 0.1875!
            Me.txtTitulo.Left = 2.8125!
            Me.txtTitulo.Name = "txtTitulo"
            Me.txtTitulo.Style = "font-size: 9pt; font-family: Times New Roman"
            Me.txtTitulo.Text = "REPORTE DE AJUSTES"
            Me.txtTitulo.Top = 0!
            Me.txtTitulo.Width = 2.375!
            '
            'TxtFecha
            '
            Me.TxtFecha.DataField = "=System.DateTime.Now.ToString()"
            Me.TxtFecha.Height = 0.1875!
            Me.TxtFecha.Left = 0!
            Me.TxtFecha.MultiLine = false
            Me.TxtFecha.Name = "TxtFecha"
            Me.TxtFecha.OutputFormat = resources.GetString("TxtFecha.OutputFormat")
            Me.TxtFecha.Style = "font-size: 9pt; font-family: Times New Roman"
            Me.TxtFecha.Text = "Fecha"
            Me.TxtFecha.Top = 0.01041667!
            Me.TxtFecha.Width = 0.8125!
            '
            'Label2
            '
            Me.Label2.Height = 0.1875!
            Me.Label2.HyperLink = Nothing
            Me.Label2.Left = 2.375!
            Me.Label2.Name = "Label2"
            Me.Label2.Style = "font-size: 9pt; font-family: Times New Roman"
            Me.Label2.Text = "De:"
            Me.Label2.Top = 0.25!
            Me.Label2.Width = 0.3125!
            '
            'Label3
            '
            Me.Label3.Height = 0.1875!
            Me.Label3.HyperLink = Nothing
            Me.Label3.Left = 3.75!
            Me.Label3.Name = "Label3"
            Me.Label3.Style = "font-size: 9pt; font-family: Times New Roman"
            Me.Label3.Text = "A:"
            Me.Label3.Top = 0.25!
            Me.Label3.Width = 0.3125!
            '
            'txtDesde
            '
            Me.txtDesde.Height = 0.1875!
            Me.txtDesde.Left = 2.75!
            Me.txtDesde.Name = "txtDesde"
            Me.txtDesde.OutputFormat = resources.GetString("txtDesde.OutputFormat")
            Me.txtDesde.Style = "font-size: 9pt; font-family: Times New Roman"
            Me.txtDesde.Text = "01/01/2005"
            Me.txtDesde.Top = 0.25!
            Me.txtDesde.Width = 0.8125!
            '
            'txtHasta
            '
            Me.txtHasta.Height = 0.1875!
            Me.txtHasta.Left = 4.1875!
            Me.txtHasta.Name = "txtHasta"
            Me.txtHasta.OutputFormat = resources.GetString("txtHasta.OutputFormat")
            Me.txtHasta.Style = "font-size: 9pt; font-family: Times New Roman"
            Me.txtHasta.Text = "01/01/2005"
            Me.txtHasta.Top = 0.25!
            Me.txtHasta.Width = 0.8125!
            '
            'Label4
            '
            Me.Label4.Height = 0.1875!
            Me.Label4.HyperLink = Nothing
            Me.Label4.Left = 2.1875!
            Me.Label4.Name = "Label4"
            Me.Label4.Style = "font-size: 9pt; font-family: Times New Roman"
            Me.Label4.Text = "SUCURSAL"
            Me.Label4.Top = 0.5!
            Me.Label4.Width = 0.8125!
            '
            'txtSucursal
            '
            Me.txtSucursal.Height = 0.1875!
            Me.txtSucursal.Left = 3.0625!
            Me.txtSucursal.Name = "txtSucursal"
            Me.txtSucursal.Style = "font-size: 9pt; font-family: Times New Roman"
            Me.txtSucursal.Text = "Suc"
            Me.txtSucursal.Top = 0.5!
            Me.txtSucursal.Width = 0.5!
            '
            'txtSucursalNombre
            '
            Me.txtSucursalNombre.Height = 0.1875!
            Me.txtSucursalNombre.Left = 3.625!
            Me.txtSucursalNombre.Name = "txtSucursalNombre"
            Me.txtSucursalNombre.Style = "font-size: 9pt; font-family: Times New Roman"
            Me.txtSucursalNombre.Text = "SucNomb"
            Me.txtSucursalNombre.Top = 0.5!
            Me.txtSucursalNombre.Width = 1.8125!
            '
            'Label5
            '
            Me.Label5.Height = 0.1875!
            Me.Label5.HyperLink = Nothing
            Me.Label5.Left = 6.625!
            Me.Label5.Name = "Label5"
            Me.Label5.Style = "font-size: 9pt; font-family: Times New Roman"
            Me.Label5.Text = "Pag."
            Me.Label5.Top = 0.0625!
            Me.Label5.Width = 0.4375!
            '
            'Line1
            '
            Me.Line1.Height = 0!
            Me.Line1.Left = 0!
            Me.Line1.LineWeight = 1!
            Me.Line1.Name = "Line1"
            Me.Line1.Top = 0.75!
            Me.Line1.Width = 7.4375!
            Me.Line1.X1 = 7.4375!
            Me.Line1.X2 = 0!
            Me.Line1.Y1 = 0.75!
            Me.Line1.Y2 = 0.75!
            '
            'Label6
            '
            Me.Label6.Height = 0.1875!
            Me.Label6.HyperLink = Nothing
            Me.Label6.Left = 0!
            Me.Label6.Name = "Label6"
            Me.Label6.Style = "font-size: 8.25pt; font-family: Times New Roman"
            Me.Label6.Text = "FOLIO"
            Me.Label6.Top = 0.75!
            Me.Label6.Width = 0.375!
            '
            'Label7
            '
            Me.Label7.Height = 0.1875!
            Me.Label7.HyperLink = Nothing
            Me.Label7.Left = 0.4375!
            Me.Label7.Name = "Label7"
            Me.Label7.Style = "font-size: 8.25pt; font-family: Times New Roman"
            Me.Label7.Text = "FECHA"
            Me.Label7.Top = 0.75!
            Me.Label7.Width = 0.8125!
            '
            'Label8
            '
            Me.Label8.Height = 0.1875!
            Me.Label8.HyperLink = Nothing
            Me.Label8.Left = 1.3125!
            Me.Label8.Name = "Label8"
            Me.Label8.Style = "text-align: center; font-size: 8.25pt; font-family: Times New Roman"
            Me.Label8.Text = "ARTICULOS"
            Me.Label8.Top = 0.75!
            Me.Label8.Width = 2!
            '
            'Label9
            '
            Me.Label9.Height = 0.1875!
            Me.Label9.HyperLink = Nothing
            Me.Label9.Left = 3.375!
            Me.Label9.Name = "Label9"
            Me.Label9.Style = "font-size: 8.25pt; font-family: Times New Roman"
            Me.Label9.Text = "TOT"
            Me.Label9.Top = 0.75!
            Me.Label9.Width = 0.3125!
            '
            'Label10
            '
            Me.Label10.Height = 0.1875!
            Me.Label10.HyperLink = Nothing
            Me.Label10.Left = 3.75!
            Me.Label10.Name = "Label10"
            Me.Label10.Style = "text-align: center; font-size: 8.25pt; font-family: Times New Roman"
            Me.Label10.Text = "TALLAS DESGLOSADAS"
            Me.Label10.Top = 0.75!
            Me.Label10.Width = 2.75!
            '
            'Label11
            '
            Me.Label11.Height = 0.1875!
            Me.Label11.HyperLink = Nothing
            Me.Label11.Left = 6.5625!
            Me.Label11.Name = "Label11"
            Me.Label11.Style = "text-align: right; font-size: 8.25pt; font-family: Times New Roman"
            Me.Label11.Text = "COSTO TOT."
            Me.Label11.Top = 0.75!
            Me.Label11.Width = 0.875!
            '
            'Line2
            '
            Me.Line2.Height = 0!
            Me.Line2.Left = 0!
            Me.Line2.LineWeight = 1!
            Me.Line2.Name = "Line2"
            Me.Line2.Top = 1!
            Me.Line2.Width = 7.5!
            Me.Line2.X1 = 7.5!
            Me.Line2.X2 = 0!
            Me.Line2.Y1 = 1!
            Me.Line2.Y2 = 1!
            '
            'txtPag
            '
            Me.txtPag.Height = 0.1875!
            Me.txtPag.Left = 7.0625!
            Me.txtPag.Name = "txtPag"
            Me.txtPag.Style = "font-size: 8.25pt; font-family: Times New Roman"
            Me.txtPag.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count
            Me.txtPag.Text = "0"
            Me.txtPag.Top = 0.0625!
            Me.txtPag.Width = 0.375!
            '
            'Codigo
            '
            Me.Codigo.DataField = "Codigo"
            Me.Codigo.Height = 0.1875!
            Me.Codigo.Left = 1.291667!
            Me.Codigo.MultiLine = false
            Me.Codigo.Name = "Codigo"
            Me.Codigo.Style = "font-size: 8.25pt; font-family: Times New Roman"
            Me.Codigo.Text = "Codigo"
            Me.Codigo.Top = 0!
            Me.Codigo.Width = 1.125!
            '
            'Fecha
            '
            Me.Fecha.DataField = "Fecha"
            Me.Fecha.Height = 0.1875!
            Me.Fecha.Left = 0.4791667!
            Me.Fecha.MultiLine = false
            Me.Fecha.Name = "Fecha"
            Me.Fecha.Style = "font-size: 8.25pt; font-family: Times New Roman"
            Me.Fecha.Text = "Fecha"
            Me.Fecha.Top = 0!
            Me.Fecha.Width = 0.75!
            '
            'Folio
            '
            Me.Folio.DataField = "Folio"
            Me.Folio.Height = 0.1875!
            Me.Folio.Left = 0!
            Me.Folio.Name = "Folio"
            Me.Folio.Style = "font-size: 8.25pt; font-family: Times New Roman"
            Me.Folio.Text = "Folio"
            Me.Folio.Top = 0!
            Me.Folio.Width = 0.4166667!
            '
            'Color
            '
            Me.Color.DataField = "Color"
            Me.Color.Height = 0.1875!
            Me.Color.Left = 2.479167!
            Me.Color.MultiLine = false
            Me.Color.Name = "Color"
            Me.Color.Style = "font-size: 8.25pt; font-family: Times New Roman"
            Me.Color.Text = "Color"
            Me.Color.Top = 0!
            Me.Color.Width = 0.8125!
            '
            'Total
            '
            Me.Total.DataField = "Total"
            Me.Total.Height = 0.1875!
            Me.Total.Left = 3.354167!
            Me.Total.MultiLine = false
            Me.Total.Name = "Total"
            Me.Total.Style = "font-size: 8.25pt; font-family: Times New Roman"
            Me.Total.Text = "Total"
            Me.Total.Top = 0.1875!
            Me.Total.Width = 0.3125!
            '
            'Talla1
            '
            Me.Talla1.DataField = "T1"
            Me.Talla1.Height = 0.188!
            Me.Talla1.Left = 3.729167!
            Me.Talla1.Name = "Talla1"
            Me.Talla1.Style = "text-align: right; font-size: 8.25pt; font-family: Times New Roman"
            Me.Talla1.Text = "1"
            Me.Talla1.Top = 0!
            Me.Talla1.Width = 0.313!
            '
            'Talla2
            '
            Me.Talla2.DataField = "T2"
            Me.Talla2.Height = 0.188!
            Me.Talla2.Left = 4.125!
            Me.Talla2.Name = "Talla2"
            Me.Talla2.Style = "text-align: right; font-size: 8.25pt; font-family: Times New Roman"
            Me.Talla2.Text = "2"
            Me.Talla2.Top = 0!
            Me.Talla2.Width = 0.313!
            '
            'Talla3
            '
            Me.Talla3.DataField = "T3"
            Me.Talla3.Height = 0.188!
            Me.Talla3.Left = 4.510417!
            Me.Talla3.Name = "Talla3"
            Me.Talla3.Style = "text-align: right; font-size: 8.25pt; font-family: Times New Roman"
            Me.Talla3.Text = "3"
            Me.Talla3.Top = 0!
            Me.Talla3.Width = 0.313!
            '
            'Talla4
            '
            Me.Talla4.DataField = "T4"
            Me.Talla4.Height = 0.188!
            Me.Talla4.Left = 4.875!
            Me.Talla4.Name = "Talla4"
            Me.Talla4.Style = "text-align: right; font-size: 8.25pt; font-family: Times New Roman"
            Me.Talla4.Text = "4"
            Me.Talla4.Top = 0!
            Me.Talla4.Width = 0.313!
            '
            'Talla5
            '
            Me.Talla5.DataField = "T5"
            Me.Talla5.Height = 0.188!
            Me.Talla5.Left = 5.239583!
            Me.Talla5.Name = "Talla5"
            Me.Talla5.Style = "text-align: right; font-size: 8.25pt; font-family: Times New Roman"
            Me.Talla5.Text = "5"
            Me.Talla5.Top = 0!
            Me.Talla5.Width = 0.313!
            '
            'Talla6
            '
            Me.Talla6.DataField = "T6"
            Me.Talla6.Height = 0.188!
            Me.Talla6.Left = 5.635417!
            Me.Talla6.Name = "Talla6"
            Me.Talla6.Style = "text-align: right; font-size: 8.25pt; font-family: Times New Roman"
            Me.Talla6.Text = "6"
            Me.Talla6.Top = 0!
            Me.Talla6.Width = 0.313!
            '
            'Talla7
            '
            Me.Talla7.DataField = "T7"
            Me.Talla7.Height = 0.188!
            Me.Talla7.Left = 6!
            Me.Talla7.Name = "Talla7"
            Me.Talla7.Style = "text-align: right; font-size: 8.25pt; font-family: Times New Roman"
            Me.Talla7.Text = "7"
            Me.Talla7.Top = 0!
            Me.Talla7.Width = 0.313!
            '
            'T8
            '
            Me.T8.DataField = "T8"
            Me.T8.Height = 0.188!
            Me.T8.Left = 6.375!
            Me.T8.Name = "T8"
            Me.T8.Style = "text-align: right; font-size: 8.25pt; font-family: Times New Roman"
            Me.T8.Text = "8"
            Me.T8.Top = 0!
            Me.T8.Width = 0.313!
            '
            'T9
            '
            Me.T9.DataField = "T9"
            Me.T9.Height = 0.188!
            Me.T9.Left = 6.770833!
            Me.T9.Name = "T9"
            Me.T9.Style = "text-align: right; font-size: 8.25pt; font-family: Times New Roman"
            Me.T9.Text = "9"
            Me.T9.Top = 0!
            Me.T9.Width = 0.313!
            '
            'Talla10
            '
            Me.Talla10.DataField = "T10"
            Me.Talla10.Height = 0.188!
            Me.Talla10.Left = 7.125!
            Me.Talla10.Name = "Talla10"
            Me.Talla10.Style = "text-align: right; font-size: 8.25pt; font-family: Times New Roman"
            Me.Talla10.Text = "10"
            Me.Talla10.Top = 0!
            Me.Talla10.Width = 0.313!
            '
            'Descripcion
            '
            Me.Descripcion.DataField = "Descripcion"
            Me.Descripcion.Height = 0.1875!
            Me.Descripcion.Left = 1.291667!
            Me.Descripcion.MultiLine = false
            Me.Descripcion.Name = "Descripcion"
            Me.Descripcion.Style = "font-size: 8.25pt; font-family: Times New Roman"
            Me.Descripcion.Text = "Descripcion"
            Me.Descripcion.Top = 0.1875!
            Me.Descripcion.Width = 1.9375!
            '
            'Label1
            '
            Me.Label1.Height = 0.1875!
            Me.Label1.HyperLink = Nothing
            Me.Label1.Left = 3.34375!
            Me.Label1.Name = "Label1"
            Me.Label1.Style = ""
            Me.Label1.Text = "Tot"
            Me.Label1.Top = 0!
            Me.Label1.Width = 0.3125!
            '
            'C1
            '
            Me.C1.DataField = "C1"
            Me.C1.Height = 0.188!
            Me.C1.Left = 3.729167!
            Me.C1.MultiLine = false
            Me.C1.Name = "C1"
            Me.C1.Style = "text-align: right; font-size: 8.25pt; font-family: Times New Roman"
            Me.C1.Text = "C1"
            Me.C1.Top = 0.1875!
            Me.C1.Width = 0.313!
            '
            'C2
            '
            Me.C2.DataField = "C2"
            Me.C2.Height = 0.188!
            Me.C2.Left = 4.125!
            Me.C2.MultiLine = false
            Me.C2.Name = "C2"
            Me.C2.Style = "text-align: right; font-size: 8.25pt; font-family: Times New Roman"
            Me.C2.Text = "C2"
            Me.C2.Top = 0.1875!
            Me.C2.Width = 0.313!
            '
            'C3
            '
            Me.C3.DataField = "C3"
            Me.C3.Height = 0.188!
            Me.C3.Left = 4.5!
            Me.C3.MultiLine = false
            Me.C3.Name = "C3"
            Me.C3.Style = "text-align: right; font-size: 8.25pt; font-family: Times New Roman"
            Me.C3.Text = "C3"
            Me.C3.Top = 0.1875!
            Me.C3.Width = 0.313!
            '
            'C4
            '
            Me.C4.DataField = "C4"
            Me.C4.Height = 0.188!
            Me.C4.Left = 4.875!
            Me.C4.MultiLine = false
            Me.C4.Name = "C4"
            Me.C4.Style = "text-align: right; font-size: 8.25pt; font-family: Times New Roman"
            Me.C4.Text = "C4"
            Me.C4.Top = 0.1875!
            Me.C4.Width = 0.313!
            '
            'C5
            '
            Me.C5.DataField = "C5"
            Me.C5.Height = 0.188!
            Me.C5.Left = 5.25!
            Me.C5.MultiLine = false
            Me.C5.Name = "C5"
            Me.C5.Style = "text-align: right; font-size: 8.25pt; font-family: Times New Roman"
            Me.C5.Text = "C5"
            Me.C5.Top = 0.1875!
            Me.C5.Width = 0.313!
            '
            'C6
            '
            Me.C6.DataField = "C6"
            Me.C6.Height = 0.188!
            Me.C6.Left = 5.625!
            Me.C6.MultiLine = false
            Me.C6.Name = "C6"
            Me.C6.Style = "text-align: right; font-size: 8.25pt; font-family: Times New Roman"
            Me.C6.Text = "C6"
            Me.C6.Top = 0.1875!
            Me.C6.Width = 0.313!
            '
            'C7
            '
            Me.C7.DataField = "C7"
            Me.C7.Height = 0.188!
            Me.C7.Left = 6!
            Me.C7.MultiLine = false
            Me.C7.Name = "C7"
            Me.C7.Style = "text-align: right; font-size: 8.25pt; font-family: Times New Roman"
            Me.C7.Text = "C7"
            Me.C7.Top = 0.1875!
            Me.C7.Width = 0.313!
            '
            'C8
            '
            Me.C8.DataField = "C8"
            Me.C8.Height = 0.188!
            Me.C8.Left = 6.375!
            Me.C8.MultiLine = false
            Me.C8.Name = "C8"
            Me.C8.Style = "text-align: right; font-size: 8.25pt; font-family: Times New Roman"
            Me.C8.Text = "C8"
            Me.C8.Top = 0.1875!
            Me.C8.Width = 0.313!
            '
            'C9
            '
            Me.C9.DataField = "C9"
            Me.C9.Height = 0.188!
            Me.C9.Left = 6.75!
            Me.C9.MultiLine = false
            Me.C9.Name = "C9"
            Me.C9.Style = "text-align: right; font-size: 8.25pt; font-family: Times New Roman"
            Me.C9.Text = "C9"
            Me.C9.Top = 0.1875!
            Me.C9.Width = 0.313!
            '
            'C10
            '
            Me.C10.DataField = "C10"
            Me.C10.Height = 0.188!
            Me.C10.Left = 7.125!
            Me.C10.MultiLine = false
            Me.C10.Name = "C10"
            Me.C10.Style = "text-align: right; font-size: 8.25pt; font-family: Times New Roman"
            Me.C10.Text = "C10"
            Me.C10.Top = 0.1875!
            Me.C10.Width = 0.313!
            '
            'TextBox1
            '
            Me.TextBox1.DataField = "Importe"
            Me.TextBox1.Height = 0.1875!
            Me.TextBox1.Left = 6.520833!
            Me.TextBox1.Name = "TextBox1"
            Me.TextBox1.OutputFormat = resources.GetString("TextBox1.OutputFormat")
            Me.TextBox1.Style = "text-align: right; font-size: 8.25pt; font-family: Times New Roman"
            Me.TextBox1.SummaryGroup = "grpFolio"
            Me.TextBox1.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
            Me.TextBox1.Text = "Importe"
            Me.TextBox1.Top = 0!
            Me.TextBox1.Width = 0.9375!
            '
            'txtObservaciones
            '
            Me.txtObservaciones.DataField = "Observaciones"
            Me.txtObservaciones.Height = 0.1875!
            Me.txtObservaciones.Left = 1.25!
            Me.txtObservaciones.Name = "txtObservaciones"
            Me.txtObservaciones.Style = "font-size: 8.25pt; font-family: Times New Roman"
            Me.txtObservaciones.Text = "Observaciones"
            Me.txtObservaciones.Top = 0!
            Me.txtObservaciones.Width = 2!
            '
            'Line3
            '
            Me.Line3.Height = 0!
            Me.Line3.Left = 0!
            Me.Line3.LineWeight = 1!
            Me.Line3.Name = "Line3"
            Me.Line3.Top = 0!
            Me.Line3.Width = 7.5!
            Me.Line3.X1 = 7.5!
            Me.Line3.X2 = 0!
            Me.Line3.Y1 = 0!
            Me.Line3.Y2 = 0!
            '
            'txtTotImporte
            '
            Me.txtTotImporte.DataField = "Importe"
            Me.txtTotImporte.Height = 0.1875!
            Me.txtTotImporte.Left = 6.5!
            Me.txtTotImporte.Name = "txtTotImporte"
            Me.txtTotImporte.OutputFormat = resources.GetString("txtTotImporte.OutputFormat")
            Me.txtTotImporte.Style = "text-align: right; font-size: 8.25pt; font-family: Times New Roman"
            Me.txtTotImporte.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
            Me.txtTotImporte.Text = "TotalImporte"
            Me.txtTotImporte.Top = 0!
            Me.txtTotImporte.Width = 0.9375!
            '
            'ActiveReport1
            '
            Me.MasterReport = false
            Me.PageSettings.Margins.Left = 0.5!
            Me.PageSettings.Margins.Right = 0.5!
            Me.PageSettings.PaperHeight = 11!
            Me.PageSettings.PaperWidth = 8.5!
            Me.PrintWidth = 7.5!
            Me.Sections.Add(Me.ReportHeader)
            Me.Sections.Add(Me.PageHeader)
            Me.Sections.Add(Me.grpFolio)
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
            CType(Me.txtTitulo,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TxtFecha,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label3,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtDesde,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtHasta,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtSucursal,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtSucursalNombre,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label5,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label6,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label7,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label8,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label9,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label10,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label11,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtPag,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Codigo,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Fecha,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Folio,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Color,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Total,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Talla1,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Talla2,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Talla3,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Talla4,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Talla5,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Talla6,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Talla7,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.T8,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.T9,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Talla10,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Descripcion,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label1,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.C1,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.C2,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.C3,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.C4,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.C5,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.C6,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.C7,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.C8,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.C9,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.C10,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox1,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtObservaciones,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtTotImporte,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        
	End Sub

#End Region

    Private Sub GroupFooter1_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupFooter1.Format

    End Sub

    Private Sub AjusteEntrada_PageStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.PageStart
        txtPag.Text = Str$(Val(txtPag.Text) + 1)
    End Sub
    Public Property Almacen() As String
        Get
            Almacen = txtSucursal.Text
        End Get
        Set(ByVal Value As String)
            txtSucursal.Text = Value
        End Set
    End Property
    Public Property NombreAlmacen() As String
        Get
            NombreAlmacen = txtSucursalNombre.Text
        End Get
        Set(ByVal Value As String)
            txtSucursalNombre.Text = Value
        End Set
    End Property
    Public Property Desde() As Date
        Get
            Desde = txtDesde.Value
        End Get
        Set(ByVal Value As Date)
            txtDesde.Value = Value
        End Set
    End Property
    Public Property Hasta() As Date
        Get
            Hasta = txtHasta.Value
        End Get
        Set(ByVal Value As Date)
            txtHasta.Value = Value
        End Set
    End Property
    Public Property Titulo() As String
        Get
            Titulo = txtTitulo.Text
        End Get
        Set(ByVal Value As String)
            txtTitulo.Text = Value
        End Set
    End Property
End Class
