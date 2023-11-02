Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU

Public Class ActRptMasVendidos
    Inherits DataDynamics.ActiveReports.ActiveReport
    Public Sub New(ByVal intNum As Integer, ByVal datFechaini As DateTime, ByVal datFechafin As DateTime)
        MyBase.New()
        InitializeComponent()
        Me.LblTitulo.Text = "Reporte de los  " & intNum.ToString & " articulos mas Vendidos"
        Me.LblFechas.Text = "del " & datFechaini.ToString("dd-MMM-yyyy") & " al " & datFechafin.ToString("dd-MMM-yyyy")

        Dim oAlmacen As Almacen
        Dim oAlmacenesMgr As New CatalogoAlmacenesManager(oAppContext)
        Dim oSAPMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        oAlmacen = oAlmacenesMgr.Load(oSAPMgr.Read_Centros) 'oAppContext.ApplicationConfiguration.Almacen)

        If Not oAlmacen Is Nothing Then

            Me.txtSucursal.Text = "Sucursal: " & oAlmacen.ID & " " & oAlmacen.Descripcion

        Else

            Me.txtSucursal.Text = "Sucursal: " & oAppContext.ApplicationConfiguration.Almacen

        End If
    End Sub
#Region "ActiveReports Designer generated code"
    Private WithEvents ReportHeader As ReportHeader = Nothing
    Private WithEvents PageHeader As PageHeader = Nothing
    Private WithEvents GroupHeader1 As GroupHeader = Nothing
    Private WithEvents GroupHeader2 As GroupHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents GroupFooter2 As GroupFooter = Nothing
    Private WithEvents GroupFooter1 As GroupFooter = Nothing
    Private WithEvents PageFooter As PageFooter = Nothing
    Private WithEvents ReportFooter As ReportFooter = Nothing
	Public ds As DataDynamics.ActiveReports.DataSources.SqlDBDataSource = Nothing
	Private LblTitulo As Label = Nothing
	Private LblFechas As Label = Nothing
	Private Label2 As Label = Nothing
	Private Label10 As Label = Nothing
	Private Label7 As Label = Nothing
	Private txtSucursal As TextBox = Nothing
	Private TextBox4 As TextBox = Nothing
	Private Line1 As Line = Nothing
	Private TextBox5 As TextBox = Nothing
	Private Label4 As Label = Nothing
	Private Label5 As Label = Nothing
	Private Label6 As Label = Nothing
	Private Line2 As Line = Nothing
	Private TextBox1 As TextBox = Nothing
	Private TextBox6 As TextBox = Nothing
	Private TextBox8 As TextBox = Nothing
	Private TextBox10 As TextBox = Nothing
	Private TextBox12 As TextBox = Nothing
	Private TextBox14 As TextBox = Nothing
	Private TextBox16 As TextBox = Nothing
	Private TextBox18 As TextBox = Nothing
	Private TextBox20 As TextBox = Nothing
	Private TextBox22 As TextBox = Nothing
	Private TextBox24 As TextBox = Nothing
	Private TextBox27 As TextBox = Nothing
	Private TextBox29 As TextBox = Nothing
	Private TextBox31 As TextBox = Nothing
	Private TextBox33 As TextBox = Nothing
	Private TextBox35 As TextBox = Nothing
	Private TextBox37 As TextBox = Nothing
	Private TextBox39 As TextBox = Nothing
	Private TextBox41 As TextBox = Nothing
	Private TextBox43 As TextBox = Nothing
	Private TextBox45 As TextBox = Nothing
	Private TextBox48 As TextBox = Nothing
	Private TextBox49 As TextBox = Nothing
	Private TextBox50 As TextBox = Nothing
	Private TextBox52 As TextBox = Nothing
	Private TextBox53 As TextBox = Nothing
	Private TextBox54 As TextBox = Nothing
	Private TextBox55 As TextBox = Nothing
	Private TextBox56 As TextBox = Nothing
	Private TextBox57 As TextBox = Nothing
	Private TextBox58 As TextBox = Nothing
	Private TextBox59 As TextBox = Nothing
	Private TextBox60 As TextBox = Nothing
	Private TextBox61 As TextBox = Nothing
	Private TextBox62 As TextBox = Nothing
	Private TextBox63 As TextBox = Nothing
	Private TextBox64 As TextBox = Nothing
	Private TextBox65 As TextBox = Nothing
	Private TextBox66 As TextBox = Nothing
	Private TextBox67 As TextBox = Nothing
	Private TextBox51 As TextBox = Nothing
	Private Label12 As Label = Nothing
	Private Label11 As Label = Nothing
	Private TextBox46 As TextBox = Nothing
	Private TextBox44 As TextBox = Nothing
	Private TextBox42 As TextBox = Nothing
	Private TextBox40 As TextBox = Nothing
	Private TextBox38 As TextBox = Nothing
	Private TextBox36 As TextBox = Nothing
	Private TextBox34 As TextBox = Nothing
	Private TextBox32 As TextBox = Nothing
	Private TextBox30 As TextBox = Nothing
	Private TextBox28 As TextBox = Nothing
	Private TextBox25 As TextBox = Nothing
	Private TextBox23 As TextBox = Nothing
	Private TextBox21 As TextBox = Nothing
	Private TextBox19 As TextBox = Nothing
	Private TextBox17 As TextBox = Nothing
	Private TextBox15 As TextBox = Nothing
	Private TextBox13 As TextBox = Nothing
	Private TextBox11 As TextBox = Nothing
	Private TextBox9 As TextBox = Nothing
	Private TextBox7 As TextBox = Nothing
	Private Label13 As Label = Nothing
	Private TextBox68 As TextBox = Nothing
	Private TextBox69 As TextBox = Nothing
	Private TextBox70 As TextBox = Nothing
	Private TextBox71 As TextBox = Nothing
	Private TextBox72 As TextBox = Nothing
	Private TextBox73 As TextBox = Nothing
	Private TextBox74 As TextBox = Nothing
	Private TextBox75 As TextBox = Nothing
	Private TextBox76 As TextBox = Nothing
	Private TextBox77 As TextBox = Nothing
	Private TextBox78 As TextBox = Nothing
	Private TextBox79 As TextBox = Nothing
	Private TextBox80 As TextBox = Nothing
	Private TextBox81 As TextBox = Nothing
	Private TextBox82 As TextBox = Nothing
	Private TextBox83 As TextBox = Nothing
	Private TextBox84 As TextBox = Nothing
	Private TextBox85 As TextBox = Nothing
	Private TextBox86 As TextBox = Nothing
	Private TextBox87 As TextBox = Nothing
	Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ActRptMasVendidos))
            Me.Detail = New DataDynamics.ActiveReports.Detail()
            Me.ReportHeader = New DataDynamics.ActiveReports.ReportHeader()
            Me.ReportFooter = New DataDynamics.ActiveReports.ReportFooter()
            Me.PageHeader = New DataDynamics.ActiveReports.PageHeader()
            Me.PageFooter = New DataDynamics.ActiveReports.PageFooter()
            Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader()
            Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter()
            Me.GroupHeader2 = New DataDynamics.ActiveReports.GroupHeader()
            Me.GroupFooter2 = New DataDynamics.ActiveReports.GroupFooter()
            Me.LblTitulo = New DataDynamics.ActiveReports.Label()
            Me.LblFechas = New DataDynamics.ActiveReports.Label()
            Me.Label2 = New DataDynamics.ActiveReports.Label()
            Me.Label10 = New DataDynamics.ActiveReports.Label()
            Me.Label7 = New DataDynamics.ActiveReports.Label()
            Me.txtSucursal = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox4 = New DataDynamics.ActiveReports.TextBox()
            Me.Line1 = New DataDynamics.ActiveReports.Line()
            Me.TextBox5 = New DataDynamics.ActiveReports.TextBox()
            Me.Label4 = New DataDynamics.ActiveReports.Label()
            Me.Label5 = New DataDynamics.ActiveReports.Label()
            Me.Label6 = New DataDynamics.ActiveReports.Label()
            Me.Line2 = New DataDynamics.ActiveReports.Line()
            Me.TextBox1 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox6 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox8 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox10 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox12 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox14 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox16 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox18 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox20 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox22 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox24 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox27 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox29 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox31 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox33 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox35 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox37 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox39 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox41 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox43 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox45 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox48 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox49 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox50 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox52 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox53 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox54 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox55 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox56 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox57 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox58 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox59 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox60 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox61 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox62 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox63 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox64 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox65 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox66 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox67 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox51 = New DataDynamics.ActiveReports.TextBox()
            Me.Label12 = New DataDynamics.ActiveReports.Label()
            Me.Label11 = New DataDynamics.ActiveReports.Label()
            Me.TextBox46 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox44 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox42 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox40 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox38 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox36 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox34 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox32 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox30 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox28 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox25 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox23 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox21 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox19 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox17 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox15 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox13 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox11 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox9 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox7 = New DataDynamics.ActiveReports.TextBox()
            Me.Label13 = New DataDynamics.ActiveReports.Label()
            Me.TextBox68 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox69 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox70 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox71 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox72 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox73 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox74 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox75 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox76 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox77 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox78 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox79 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox80 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox81 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox82 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox83 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox84 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox85 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox86 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox87 = New DataDynamics.ActiveReports.TextBox()
            CType(Me.LblTitulo,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.LblFechas,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label10,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label7,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtSucursal,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox4,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox5,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label5,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label6,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox1,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox6,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox8,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox10,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox12,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox14,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox16,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox18,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox20,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox22,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox24,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox27,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox29,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox31,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox33,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox35,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox37,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox39,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox41,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox43,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox45,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox48,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox49,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox50,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox52,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox53,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox54,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox55,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox56,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox57,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox58,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox59,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox60,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox61,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox62,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox63,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox64,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox65,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox66,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox67,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox51,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label12,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label11,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox46,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox44,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox42,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox40,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox38,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox36,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox34,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox32,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox30,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox28,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox25,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox23,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox21,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox19,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox17,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox15,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox13,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox11,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox9,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox7,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label13,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox68,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox69,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox70,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox71,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox72,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox73,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox74,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox75,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox76,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox77,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox78,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox79,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox80,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox81,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox82,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox83,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox84,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox85,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox86,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox87,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
            '
            'Detail
            '
            Me.Detail.ColumnSpacing = 0!
            Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TextBox1, Me.TextBox6, Me.TextBox8, Me.TextBox10, Me.TextBox12, Me.TextBox14, Me.TextBox16, Me.TextBox18, Me.TextBox20, Me.TextBox22, Me.TextBox24, Me.TextBox27, Me.TextBox29, Me.TextBox31, Me.TextBox33, Me.TextBox35, Me.TextBox37, Me.TextBox39, Me.TextBox41, Me.TextBox43, Me.TextBox45, Me.TextBox48, Me.TextBox49, Me.TextBox50, Me.TextBox52, Me.TextBox53, Me.TextBox54, Me.TextBox55, Me.TextBox56, Me.TextBox57, Me.TextBox58, Me.TextBox59, Me.TextBox60, Me.TextBox61, Me.TextBox62, Me.TextBox63, Me.TextBox64, Me.TextBox65, Me.TextBox66, Me.TextBox67, Me.TextBox51, Me.Label12, Me.Label11, Me.TextBox46, Me.TextBox44, Me.TextBox42, Me.TextBox40, Me.TextBox38, Me.TextBox36, Me.TextBox34, Me.TextBox32, Me.TextBox30, Me.TextBox28, Me.TextBox25, Me.TextBox23, Me.TextBox21, Me.TextBox19, Me.TextBox17, Me.TextBox15, Me.TextBox13, Me.TextBox11, Me.TextBox9, Me.TextBox7, Me.Label13, Me.TextBox68, Me.TextBox69, Me.TextBox70, Me.TextBox71, Me.TextBox72, Me.TextBox73, Me.TextBox74, Me.TextBox75, Me.TextBox76, Me.TextBox77, Me.TextBox78, Me.TextBox79, Me.TextBox80, Me.TextBox81, Me.TextBox82, Me.TextBox83, Me.TextBox84, Me.TextBox85, Me.TextBox86, Me.TextBox87})
            Me.Detail.Height = 0.6763889!
            Me.Detail.Name = "Detail"
            '
            'ReportHeader
            '
            Me.ReportHeader.Height = 0!
            Me.ReportHeader.Name = "ReportHeader"
            '
            'ReportFooter
            '
            Me.ReportFooter.Height = 0.01041667!
            Me.ReportFooter.Name = "ReportFooter"
            '
            'PageHeader
            '
            Me.PageHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.LblTitulo, Me.LblFechas, Me.Label2, Me.Label10, Me.Label7, Me.txtSucursal})
            Me.PageHeader.Height = 1.197222!
            Me.PageHeader.Name = "PageHeader"
            '
            'PageFooter
            '
            Me.PageFooter.Height = 0!
            Me.PageFooter.Name = "PageFooter"
            '
            'GroupHeader1
            '
            Me.GroupHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TextBox4, Me.Line1})
            Me.GroupHeader1.DataField = "Familia"
            Me.GroupHeader1.Height = 0.3020833!
            Me.GroupHeader1.Name = "GroupHeader1"
            '
            'GroupFooter1
            '
            Me.GroupFooter1.Height = 0!
            Me.GroupFooter1.Name = "GroupFooter1"
            '
            'GroupHeader2
            '
            Me.GroupHeader2.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TextBox5, Me.Label4, Me.Label5, Me.Label6, Me.Line2})
            Me.GroupHeader2.DataField = "Linea"
            Me.GroupHeader2.Height = 0.2597222!
            Me.GroupHeader2.Name = "GroupHeader2"
            '
            'GroupFooter2
            '
            Me.GroupFooter2.Height = 0!
            Me.GroupFooter2.Name = "GroupFooter2"
            '
            'LblTitulo
            '
            Me.LblTitulo.Height = 0.3149606!
            Me.LblTitulo.HyperLink = Nothing
            Me.LblTitulo.Left = 0.07874014!
            Me.LblTitulo.Name = "LblTitulo"
            Me.LblTitulo.Style = "text-align: center; font-weight: bold; font-size: 14.25pt"
            Me.LblTitulo.Text = "Reporte de los  N articulos mas Vendidos"
            Me.LblTitulo.Top = 0.09498034!
            Me.LblTitulo.Width = 7.007875!
            '
            'LblFechas
            '
            Me.LblFechas.Height = 0.2362205!
            Me.LblFechas.HyperLink = Nothing
            Me.LblFechas.Left = 0.07874014!
            Me.LblFechas.Name = "LblFechas"
            Me.LblFechas.Style = "text-align: center; font-size: 12pt"
            Me.LblFechas.Text = "del  01/01/2006 al 01/02/2006"
            Me.LblFechas.Top = 0.7086611!
            Me.LblFechas.Width = 7.007875!
            '
            'Label2
            '
            Me.Label2.Height = 0.1574803!
            Me.Label2.HyperLink = Nothing
            Me.Label2.Left = 0.01624016!
            Me.Label2.Name = "Label2"
            Me.Label2.Style = ""
            Me.Label2.Text = "Familia"
            Me.Label2.Top = 1.053642!
            Me.Label2.Width = 0.5511812!
            '
            'Label10
            '
            Me.Label10.Height = 0.1574803!
            Me.Label10.HyperLink = Nothing
            Me.Label10.Left = 2.204724!
            Me.Label10.Name = "Label10"
            Me.Label10.Style = ""
            Me.Label10.Text = "TALLAS / CANTIDAD"
            Me.Label10.Top = 1.053642!
            Me.Label10.Width = 1.496063!
            '
            'Label7
            '
            Me.Label7.Height = 0.1574803!
            Me.Label7.HyperLink = Nothing
            Me.Label7.Left = 0.6299213!
            Me.Label7.Name = "Label7"
            Me.Label7.Style = ""
            Me.Label7.Text = "Linea"
            Me.Label7.Top = 1.053642!
            Me.Label7.Width = 0.6299213!
            '
            'txtSucursal
            '
            Me.txtSucursal.Height = 0.2362205!
            Me.txtSucursal.Left = 0.07874014!
            Me.txtSucursal.Name = "txtSucursal"
            Me.txtSucursal.Style = "text-align: center; font-size: 14.25pt"
            Me.txtSucursal.Text = "Almacen"
            Me.txtSucursal.Top = 0.409941!
            Me.txtSucursal.Width = 7.007875!
            '
            'TextBox4
            '
            Me.TextBox4.DataField = "Familia"
            Me.TextBox4.Height = 0.2!
            Me.TextBox4.Left = 0.01624015!
            Me.TextBox4.Name = "TextBox4"
            Me.TextBox4.Text = "Familia"
            Me.TextBox4.Top = 0!
            Me.TextBox4.Width = 2.047245!
            '
            'Line1
            '
            Me.Line1.Height = 0!
            Me.Line1.Left = 0!
            Me.Line1.LineWeight = 1!
            Me.Line1.Name = "Line1"
            Me.Line1.Top = 0.2362205!
            Me.Line1.Width = 2.047244!
            Me.Line1.X1 = 2.047244!
            Me.Line1.X2 = 0!
            Me.Line1.Y1 = 0.2362205!
            Me.Line1.Y2 = 0.2362205!
            '
            'TextBox5
            '
            Me.TextBox5.DataField = "Linea"
            Me.TextBox5.Height = 0.2!
            Me.TextBox5.Left = 0.6299213!
            Me.TextBox5.Name = "TextBox5"
            Me.TextBox5.Text = "Linea"
            Me.TextBox5.Top = 0!
            Me.TextBox5.Width = 1.496063!
            '
            'Label4
            '
            Me.Label4.Height = 5.866598E-09!
            Me.Label4.HyperLink = Nothing
            Me.Label4.Left = 1.653543!
            Me.Label4.Name = "Label4"
            Me.Label4.Style = ""
            Me.Label4.Text = "Label4"
            Me.Label4.Top = 0.2524606!
            Me.Label4.Width = 1.338583!
            '
            'Label5
            '
            Me.Label5.Height = 5.866598E-09!
            Me.Label5.HyperLink = Nothing
            Me.Label5.Left = 1.338583!
            Me.Label5.Name = "Label5"
            Me.Label5.Style = ""
            Me.Label5.Text = "Label5"
            Me.Label5.Top = 0.07874014!
            Me.Label5.Width = 1.338583!
            '
            'Label6
            '
            Me.Label6.Height = 5.866598E-09!
            Me.Label6.HyperLink = Nothing
            Me.Label6.Left = 3.385827!
            Me.Label6.Name = "Label6"
            Me.Label6.Style = ""
            Me.Label6.Text = "Label6"
            Me.Label6.Top = 0.1574803!
            Me.Label6.Width = 1.338583!
            '
            'Line2
            '
            Me.Line2.Height = 0!
            Me.Line2.Left = 0.6299213!
            Me.Line2.LineStyle = DataDynamics.ActiveReports.LineStyle.DashDotDot
            Me.Line2.LineWeight = 1!
            Me.Line2.Name = "Line2"
            Me.Line2.Top = 0.2362205!
            Me.Line2.Width = 1.496063!
            Me.Line2.X1 = 2.125984!
            Me.Line2.X2 = 0.6299213!
            Me.Line2.Y1 = 0.2362205!
            Me.Line2.Y2 = 0.2362205!
            '
            'TextBox1
            '
            Me.TextBox1.DataField = "CodArticulo"
            Me.TextBox1.Height = 0.1574803!
            Me.TextBox1.Left = 0.8661417!
            Me.TextBox1.Name = "TextBox1"
            Me.TextBox1.Style = "font-size: 8.25pt"
            Me.TextBox1.Text = "CodArticulo"
            Me.TextBox1.Top = 0!
            Me.TextBox1.Width = 1.102362!
            '
            'TextBox6
            '
            Me.TextBox6.DataField = "t01"
            Me.TextBox6.Height = 0.1574803!
            Me.TextBox6.Left = 2.000985!
            Me.TextBox6.Name = "TextBox6"
            Me.TextBox6.Style = "text-align: right; font-size: 6.75pt"
            Me.TextBox6.Top = 0!
            Me.TextBox6.Width = 0.2547012!
            '
            'TextBox8
            '
            Me.TextBox8.DataField = "t02"
            Me.TextBox8.Height = 0.1574803!
            Me.TextBox8.Left = 2.255686!
            Me.TextBox8.Name = "TextBox8"
            Me.TextBox8.Style = "text-align: right; font-size: 6.75pt"
            Me.TextBox8.Top = 0!
            Me.TextBox8.Width = 0.2547012!
            '
            'TextBox10
            '
            Me.TextBox10.DataField = "t03"
            Me.TextBox10.Height = 0.1574803!
            Me.TextBox10.Left = 2.510387!
            Me.TextBox10.Name = "TextBox10"
            Me.TextBox10.Style = "text-align: right; font-size: 6.75pt"
            Me.TextBox10.Top = 0!
            Me.TextBox10.Width = 0.2547012!
            '
            'TextBox12
            '
            Me.TextBox12.DataField = "t04"
            Me.TextBox12.Height = 0.1574803!
            Me.TextBox12.Left = 2.765088!
            Me.TextBox12.Name = "TextBox12"
            Me.TextBox12.Style = "text-align: right; font-size: 6.75pt"
            Me.TextBox12.Top = 0!
            Me.TextBox12.Width = 0.2547012!
            '
            'TextBox14
            '
            Me.TextBox14.DataField = "t05"
            Me.TextBox14.Height = 0.1574803!
            Me.TextBox14.Left = 3.01979!
            Me.TextBox14.Name = "TextBox14"
            Me.TextBox14.Style = "text-align: right; font-size: 6.75pt"
            Me.TextBox14.Top = 0!
            Me.TextBox14.Width = 0.2547012!
            '
            'TextBox16
            '
            Me.TextBox16.DataField = "t06"
            Me.TextBox16.Height = 0.1574803!
            Me.TextBox16.Left = 3.27449!
            Me.TextBox16.Name = "TextBox16"
            Me.TextBox16.Style = "text-align: right; font-size: 6.75pt"
            Me.TextBox16.Top = 0!
            Me.TextBox16.Width = 0.2547012!
            '
            'TextBox18
            '
            Me.TextBox18.DataField = "t07"
            Me.TextBox18.Height = 0.1574803!
            Me.TextBox18.Left = 3.529192!
            Me.TextBox18.Name = "TextBox18"
            Me.TextBox18.Style = "text-align: right; font-size: 6.75pt"
            Me.TextBox18.Top = 0!
            Me.TextBox18.Width = 0.2547012!
            '
            'TextBox20
            '
            Me.TextBox20.DataField = "t08"
            Me.TextBox20.Height = 0.1574803!
            Me.TextBox20.Left = 3.783892!
            Me.TextBox20.Name = "TextBox20"
            Me.TextBox20.Style = "text-align: right; font-size: 6.75pt"
            Me.TextBox20.Top = 0!
            Me.TextBox20.Width = 0.2547012!
            '
            'TextBox22
            '
            Me.TextBox22.DataField = "t09"
            Me.TextBox22.Height = 0.1574803!
            Me.TextBox22.Left = 4.038594!
            Me.TextBox22.Name = "TextBox22"
            Me.TextBox22.Style = "text-align: right; font-size: 6.75pt"
            Me.TextBox22.Top = 0!
            Me.TextBox22.Width = 0.2547012!
            '
            'TextBox24
            '
            Me.TextBox24.DataField = "t10"
            Me.TextBox24.Height = 0.1574803!
            Me.TextBox24.Left = 4.293295!
            Me.TextBox24.Name = "TextBox24"
            Me.TextBox24.Style = "text-align: right; font-size: 6.75pt"
            Me.TextBox24.Top = 0!
            Me.TextBox24.Width = 0.2547012!
            '
            'TextBox27
            '
            Me.TextBox27.DataField = "t11"
            Me.TextBox27.Height = 0.1574803!
            Me.TextBox27.Left = 4.547996!
            Me.TextBox27.Name = "TextBox27"
            Me.TextBox27.Style = "text-align: right; font-size: 6.75pt"
            Me.TextBox27.Top = 0!
            Me.TextBox27.Width = 0.2547012!
            '
            'TextBox29
            '
            Me.TextBox29.DataField = "t12"
            Me.TextBox29.Height = 0.1574803!
            Me.TextBox29.Left = 4.802697!
            Me.TextBox29.Name = "TextBox29"
            Me.TextBox29.Style = "text-align: right; font-size: 6.75pt"
            Me.TextBox29.Top = 0!
            Me.TextBox29.Width = 0.2547012!
            '
            'TextBox31
            '
            Me.TextBox31.DataField = "t13"
            Me.TextBox31.Height = 0.1574803!
            Me.TextBox31.Left = 5.057398!
            Me.TextBox31.Name = "TextBox31"
            Me.TextBox31.Style = "text-align: right; font-size: 6.75pt"
            Me.TextBox31.Top = 0!
            Me.TextBox31.Width = 0.2547012!
            '
            'TextBox33
            '
            Me.TextBox33.DataField = "t14"
            Me.TextBox33.Height = 0.1574803!
            Me.TextBox33.Left = 5.312099!
            Me.TextBox33.Name = "TextBox33"
            Me.TextBox33.Style = "text-align: right; font-size: 6.75pt"
            Me.TextBox33.Top = 0!
            Me.TextBox33.Width = 0.2547012!
            '
            'TextBox35
            '
            Me.TextBox35.DataField = "t15"
            Me.TextBox35.Height = 0.1574803!
            Me.TextBox35.Left = 5.566801!
            Me.TextBox35.Name = "TextBox35"
            Me.TextBox35.Style = "text-align: right; font-size: 6.75pt"
            Me.TextBox35.Top = 0!
            Me.TextBox35.Width = 0.2547012!
            '
            'TextBox37
            '
            Me.TextBox37.DataField = "t16"
            Me.TextBox37.Height = 0.1574803!
            Me.TextBox37.Left = 5.821502!
            Me.TextBox37.Name = "TextBox37"
            Me.TextBox37.Style = "text-align: right; font-size: 6.75pt"
            Me.TextBox37.Top = 0!
            Me.TextBox37.Width = 0.2547012!
            '
            'TextBox39
            '
            Me.TextBox39.DataField = "t17"
            Me.TextBox39.Height = 0.1574803!
            Me.TextBox39.Left = 6.076203!
            Me.TextBox39.Name = "TextBox39"
            Me.TextBox39.Style = "text-align: right; font-size: 6.75pt"
            Me.TextBox39.Top = 0!
            Me.TextBox39.Width = 0.2547012!
            '
            'TextBox41
            '
            Me.TextBox41.DataField = "t18"
            Me.TextBox41.Height = 0.1574803!
            Me.TextBox41.Left = 6.330904!
            Me.TextBox41.Name = "TextBox41"
            Me.TextBox41.Style = "text-align: right; font-size: 6.75pt"
            Me.TextBox41.Top = 0!
            Me.TextBox41.Width = 0.2547012!
            '
            'TextBox43
            '
            Me.TextBox43.DataField = "t19"
            Me.TextBox43.Height = 0.1574803!
            Me.TextBox43.Left = 6.585605!
            Me.TextBox43.Name = "TextBox43"
            Me.TextBox43.Style = "text-align: right; font-size: 6.75pt"
            Me.TextBox43.Top = 0!
            Me.TextBox43.Width = 0.2547012!
            '
            'TextBox45
            '
            Me.TextBox45.DataField = "t20"
            Me.TextBox45.Height = 0.1574803!
            Me.TextBox45.Left = 6.840306!
            Me.TextBox45.Name = "TextBox45"
            Me.TextBox45.Style = "text-align: right; font-size: 6.75pt"
            Me.TextBox45.Top = 0!
            Me.TextBox45.Width = 0.2547012!
            '
            'TextBox48
            '
            Me.TextBox48.DataField = "s14"
            Me.TextBox48.Height = 0.1574803!
            Me.TextBox48.Left = 5.311114!
            Me.TextBox48.Name = "TextBox48"
            Me.TextBox48.Style = "text-align: right; font-size: 6.75pt"
            Me.TextBox48.Top = 0.5024606!
            Me.TextBox48.Width = 0.2547012!
            '
            'TextBox49
            '
            Me.TextBox49.DataField = "s15"
            Me.TextBox49.Height = 0.1574803!
            Me.TextBox49.Left = 5.565816!
            Me.TextBox49.Name = "TextBox49"
            Me.TextBox49.Style = "text-align: right; font-size: 6.75pt"
            Me.TextBox49.Top = 0.5024606!
            Me.TextBox49.Width = 0.2547012!
            '
            'TextBox50
            '
            Me.TextBox50.DataField = "s13"
            Me.TextBox50.Height = 0.1574803!
            Me.TextBox50.Left = 5.056414!
            Me.TextBox50.Name = "TextBox50"
            Me.TextBox50.Style = "text-align: right; font-size: 6.75pt"
            Me.TextBox50.Top = 0.5024606!
            Me.TextBox50.Width = 0.2547012!
            '
            'TextBox52
            '
            Me.TextBox52.DataField = "s11"
            Me.TextBox52.Height = 0.1574803!
            Me.TextBox52.Left = 4.547011!
            Me.TextBox52.Name = "TextBox52"
            Me.TextBox52.Style = "text-align: right; font-size: 6.75pt"
            Me.TextBox52.Top = 0.5024606!
            Me.TextBox52.Width = 0.2547012!
            '
            'TextBox53
            '
            Me.TextBox53.DataField = "s12"
            Me.TextBox53.Height = 0.1574803!
            Me.TextBox53.Left = 4.801713!
            Me.TextBox53.Name = "TextBox53"
            Me.TextBox53.Style = "text-align: right; font-size: 6.75pt"
            Me.TextBox53.Top = 0.5024606!
            Me.TextBox53.Width = 0.2547012!
            '
            'TextBox54
            '
            Me.TextBox54.DataField = "s19"
            Me.TextBox54.Height = 0.1574803!
            Me.TextBox54.Left = 6.58462!
            Me.TextBox54.Name = "TextBox54"
            Me.TextBox54.Style = "text-align: right; font-size: 6.75pt"
            Me.TextBox54.Top = 0.5024606!
            Me.TextBox54.Width = 0.2547012!
            '
            'TextBox55
            '
            Me.TextBox55.DataField = "s20"
            Me.TextBox55.Height = 0.1574803!
            Me.TextBox55.Left = 6.839322!
            Me.TextBox55.Name = "TextBox55"
            Me.TextBox55.Style = "text-align: right; font-size: 6.75pt"
            Me.TextBox55.Top = 0.5024606!
            Me.TextBox55.Width = 0.2547012!
            '
            'TextBox56
            '
            Me.TextBox56.DataField = "s18"
            Me.TextBox56.Height = 0.1574803!
            Me.TextBox56.Left = 6.329919!
            Me.TextBox56.Name = "TextBox56"
            Me.TextBox56.Style = "text-align: right; font-size: 6.75pt"
            Me.TextBox56.Top = 0.5024606!
            Me.TextBox56.Width = 0.2547012!
            '
            'TextBox57
            '
            Me.TextBox57.DataField = "s16"
            Me.TextBox57.Height = 0.1574803!
            Me.TextBox57.Left = 5.820518!
            Me.TextBox57.Name = "TextBox57"
            Me.TextBox57.Style = "text-align: right; font-size: 6.75pt"
            Me.TextBox57.Top = 0.5024606!
            Me.TextBox57.Width = 0.2547012!
            '
            'TextBox58
            '
            Me.TextBox58.DataField = "s17"
            Me.TextBox58.Height = 0.1574803!
            Me.TextBox58.Left = 6.075218!
            Me.TextBox58.Name = "TextBox58"
            Me.TextBox58.Style = "text-align: right; font-size: 6.75pt"
            Me.TextBox58.Top = 0.5024606!
            Me.TextBox58.Width = 0.2547012!
            '
            'TextBox59
            '
            Me.TextBox59.DataField = "s04"
            Me.TextBox59.Height = 0.1574803!
            Me.TextBox59.Left = 2.764103!
            Me.TextBox59.Name = "TextBox59"
            Me.TextBox59.Style = "text-align: right; font-size: 6.75pt"
            Me.TextBox59.Top = 0.5024606!
            Me.TextBox59.Width = 0.2547012!
            '
            'TextBox60
            '
            Me.TextBox60.DataField = "s04"
            Me.TextBox60.Height = 0.1574803!
            Me.TextBox60.Left = 3.018805!
            Me.TextBox60.Name = "TextBox60"
            Me.TextBox60.Style = "text-align: right; font-size: 6.75pt"
            Me.TextBox60.Top = 0.5024606!
            Me.TextBox60.Width = 0.2547012!
            '
            'TextBox61
            '
            Me.TextBox61.DataField = "s03"
            Me.TextBox61.Height = 0.1574803!
            Me.TextBox61.Left = 2.509402!
            Me.TextBox61.Name = "TextBox61"
            Me.TextBox61.Style = "text-align: right; font-size: 6.75pt"
            Me.TextBox61.Top = 0.5024606!
            Me.TextBox61.Width = 0.2547012!
            '
            'TextBox62
            '
            Me.TextBox62.DataField = "S01"
            Me.TextBox62.Height = 0.1574803!
            Me.TextBox62.Left = 2!
            Me.TextBox62.Name = "TextBox62"
            Me.TextBox62.Style = "text-align: right; font-size: 6.75pt"
            Me.TextBox62.Top = 0.5024606!
            Me.TextBox62.Width = 0.2547012!
            '
            'TextBox63
            '
            Me.TextBox63.DataField = "s02"
            Me.TextBox63.Height = 0.1574803!
            Me.TextBox63.Left = 2.254701!
            Me.TextBox63.Name = "TextBox63"
            Me.TextBox63.Style = "text-align: right; font-size: 6.75pt"
            Me.TextBox63.Top = 0.5024606!
            Me.TextBox63.Width = 0.2547012!
            '
            'TextBox64
            '
            Me.TextBox64.DataField = "s09"
            Me.TextBox64.Height = 0.1574803!
            Me.TextBox64.Left = 4.037609!
            Me.TextBox64.Name = "TextBox64"
            Me.TextBox64.Style = "text-align: right; font-size: 6.75pt"
            Me.TextBox64.Top = 0.5024606!
            Me.TextBox64.Width = 0.2547012!
            '
            'TextBox65
            '
            Me.TextBox65.DataField = "s10"
            Me.TextBox65.Height = 0.1574803!
            Me.TextBox65.Left = 4.29231!
            Me.TextBox65.Name = "TextBox65"
            Me.TextBox65.Style = "text-align: right; font-size: 6.75pt"
            Me.TextBox65.Top = 0.5024606!
            Me.TextBox65.Width = 0.2547012!
            '
            'TextBox66
            '
            Me.TextBox66.DataField = "s08"
            Me.TextBox66.Height = 0.1574803!
            Me.TextBox66.Left = 3.782908!
            Me.TextBox66.Name = "TextBox66"
            Me.TextBox66.Style = "text-align: right; font-size: 6.75pt"
            Me.TextBox66.Top = 0.5024606!
            Me.TextBox66.Width = 0.2547012!
            '
            'TextBox67
            '
            Me.TextBox67.DataField = "s06"
            Me.TextBox67.Height = 0.1574803!
            Me.TextBox67.Left = 3.273506!
            Me.TextBox67.Name = "TextBox67"
            Me.TextBox67.Style = "text-align: right; font-size: 6.75pt"
            Me.TextBox67.Top = 0.5024606!
            Me.TextBox67.Width = 0.2547012!
            '
            'TextBox51
            '
            Me.TextBox51.DataField = "s07"
            Me.TextBox51.Height = 0.1574803!
            Me.TextBox51.Left = 3.528207!
            Me.TextBox51.Name = "TextBox51"
            Me.TextBox51.Style = "text-align: right; font-size: 6.75pt"
            Me.TextBox51.Top = 0.5024606!
            Me.TextBox51.Width = 0.2547012!
            '
            'Label12
            '
            Me.Label12.Height = 0.1574803!
            Me.Label12.HyperLink = Nothing
            Me.Label12.Left = 0.9699799!
            Me.Label12.Name = "Label12"
            Me.Label12.Style = "text-align: right; font-size: 8.25pt"
            Me.Label12.Text = "Alm. Resurtido"
            Me.Label12.Top = 0.5024606!
            Me.Label12.Width = 0.944882!
            '
            'Label11
            '
            Me.Label11.Height = 0.1574803!
            Me.Label11.HyperLink = Nothing
            Me.Label11.Left = 1.284941!
            Me.Label11.Name = "Label11"
            Me.Label11.Style = "text-align: right; font-size: 8.25pt"
            Me.Label11.Text = "Existencias"
            Me.Label11.Top = 0.3449804!
            Me.Label11.Width = 0.6299213!
            '
            'TextBox46
            '
            Me.TextBox46.DataField = "c20"
            Me.TextBox46.Height = 0.1574803!
            Me.TextBox46.Left = 6.840306!
            Me.TextBox46.Name = "TextBox46"
            Me.TextBox46.Style = "text-align: right; font-size: 6.75pt"
            Me.TextBox46.Top = 0.3449804!
            Me.TextBox46.Width = 0.2547012!
            '
            'TextBox44
            '
            Me.TextBox44.DataField = "c19"
            Me.TextBox44.Height = 0.1574803!
            Me.TextBox44.Left = 6.585605!
            Me.TextBox44.Name = "TextBox44"
            Me.TextBox44.Style = "text-align: right; font-size: 6.75pt"
            Me.TextBox44.Top = 0.3449804!
            Me.TextBox44.Width = 0.2547012!
            '
            'TextBox42
            '
            Me.TextBox42.DataField = "c18"
            Me.TextBox42.Height = 0.1574803!
            Me.TextBox42.Left = 6.330904!
            Me.TextBox42.Name = "TextBox42"
            Me.TextBox42.Style = "text-align: right; font-size: 6.75pt"
            Me.TextBox42.Top = 0.3449804!
            Me.TextBox42.Width = 0.2547012!
            '
            'TextBox40
            '
            Me.TextBox40.DataField = "c17"
            Me.TextBox40.Height = 0.1574803!
            Me.TextBox40.Left = 6.076202!
            Me.TextBox40.Name = "TextBox40"
            Me.TextBox40.Style = "text-align: right; font-size: 6.75pt"
            Me.TextBox40.Top = 0.3449804!
            Me.TextBox40.Width = 0.2547012!
            '
            'TextBox38
            '
            Me.TextBox38.DataField = "c16"
            Me.TextBox38.Height = 0.1574803!
            Me.TextBox38.Left = 5.821502!
            Me.TextBox38.Name = "TextBox38"
            Me.TextBox38.Style = "text-align: right; font-size: 6.75pt"
            Me.TextBox38.Top = 0.3449804!
            Me.TextBox38.Width = 0.2547012!
            '
            'TextBox36
            '
            Me.TextBox36.DataField = "c15"
            Me.TextBox36.Height = 0.1574803!
            Me.TextBox36.Left = 5.5668!
            Me.TextBox36.Name = "TextBox36"
            Me.TextBox36.Style = "text-align: right; font-size: 6.75pt"
            Me.TextBox36.Top = 0.3449804!
            Me.TextBox36.Width = 0.2547012!
            '
            'TextBox34
            '
            Me.TextBox34.DataField = "c14"
            Me.TextBox34.Height = 0.1574803!
            Me.TextBox34.Left = 5.312099!
            Me.TextBox34.Name = "TextBox34"
            Me.TextBox34.Style = "text-align: right; font-size: 6.75pt"
            Me.TextBox34.Top = 0.3449804!
            Me.TextBox34.Width = 0.2547012!
            '
            'TextBox32
            '
            Me.TextBox32.DataField = "c13"
            Me.TextBox32.Height = 0.1574803!
            Me.TextBox32.Left = 5.057398!
            Me.TextBox32.Name = "TextBox32"
            Me.TextBox32.Style = "text-align: right; font-size: 6.75pt"
            Me.TextBox32.Top = 0.3449804!
            Me.TextBox32.Width = 0.2547012!
            '
            'TextBox30
            '
            Me.TextBox30.DataField = "c12"
            Me.TextBox30.Height = 0.1574803!
            Me.TextBox30.Left = 4.802697!
            Me.TextBox30.Name = "TextBox30"
            Me.TextBox30.Style = "text-align: right; font-size: 6.75pt"
            Me.TextBox30.Top = 0.3449804!
            Me.TextBox30.Width = 0.2547012!
            '
            'TextBox28
            '
            Me.TextBox28.DataField = "c11"
            Me.TextBox28.Height = 0.1574803!
            Me.TextBox28.Left = 4.547996!
            Me.TextBox28.Name = "TextBox28"
            Me.TextBox28.Style = "text-align: right; font-size: 6.75pt"
            Me.TextBox28.Top = 0.3449804!
            Me.TextBox28.Width = 0.2547012!
            '
            'TextBox25
            '
            Me.TextBox25.DataField = "c10"
            Me.TextBox25.Height = 0.1574803!
            Me.TextBox25.Left = 4.293295!
            Me.TextBox25.Name = "TextBox25"
            Me.TextBox25.Style = "text-align: right; font-size: 6.75pt"
            Me.TextBox25.Top = 0.3449804!
            Me.TextBox25.Width = 0.2547012!
            '
            'TextBox23
            '
            Me.TextBox23.DataField = "c09"
            Me.TextBox23.Height = 0.1574803!
            Me.TextBox23.Left = 4.038593!
            Me.TextBox23.Name = "TextBox23"
            Me.TextBox23.Style = "text-align: right; font-size: 6.75pt"
            Me.TextBox23.Top = 0.3449804!
            Me.TextBox23.Width = 0.2547012!
            '
            'TextBox21
            '
            Me.TextBox21.DataField = "c08"
            Me.TextBox21.Height = 0.1574803!
            Me.TextBox21.Left = 3.783892!
            Me.TextBox21.Name = "TextBox21"
            Me.TextBox21.Style = "text-align: right; font-size: 6.75pt"
            Me.TextBox21.Top = 0.3449804!
            Me.TextBox21.Width = 0.2547012!
            '
            'TextBox19
            '
            Me.TextBox19.DataField = "c07"
            Me.TextBox19.Height = 0.1574803!
            Me.TextBox19.Left = 3.529192!
            Me.TextBox19.Name = "TextBox19"
            Me.TextBox19.Style = "text-align: right; font-size: 6.75pt"
            Me.TextBox19.Top = 0.3449804!
            Me.TextBox19.Width = 0.2547012!
            '
            'TextBox17
            '
            Me.TextBox17.DataField = "c06"
            Me.TextBox17.Height = 0.1574803!
            Me.TextBox17.Left = 3.27449!
            Me.TextBox17.Name = "TextBox17"
            Me.TextBox17.Style = "text-align: right; font-size: 6.75pt"
            Me.TextBox17.Top = 0.3449804!
            Me.TextBox17.Width = 0.2547012!
            '
            'TextBox15
            '
            Me.TextBox15.DataField = "c05"
            Me.TextBox15.Height = 0.1574803!
            Me.TextBox15.Left = 3.019789!
            Me.TextBox15.Name = "TextBox15"
            Me.TextBox15.Style = "text-align: right; font-size: 6.75pt"
            Me.TextBox15.Top = 0.3449804!
            Me.TextBox15.Width = 0.2547012!
            '
            'TextBox13
            '
            Me.TextBox13.DataField = "c04"
            Me.TextBox13.Height = 0.1574803!
            Me.TextBox13.Left = 2.765088!
            Me.TextBox13.Name = "TextBox13"
            Me.TextBox13.Style = "text-align: right; font-size: 6.75pt"
            Me.TextBox13.Top = 0.3449804!
            Me.TextBox13.Width = 0.2547012!
            '
            'TextBox11
            '
            Me.TextBox11.DataField = "c03"
            Me.TextBox11.Height = 0.1574803!
            Me.TextBox11.Left = 2.510387!
            Me.TextBox11.Name = "TextBox11"
            Me.TextBox11.Style = "text-align: right; font-size: 6.75pt"
            Me.TextBox11.Top = 0.3449804!
            Me.TextBox11.Width = 0.2547012!
            '
            'TextBox9
            '
            Me.TextBox9.DataField = "c02"
            Me.TextBox9.Height = 0.1574803!
            Me.TextBox9.Left = 2.255685!
            Me.TextBox9.Name = "TextBox9"
            Me.TextBox9.Style = "text-align: right; font-size: 6.75pt"
            Me.TextBox9.Top = 0.3449804!
            Me.TextBox9.Width = 0.2547012!
            '
            'TextBox7
            '
            Me.TextBox7.DataField = "c01"
            Me.TextBox7.Height = 0.1574803!
            Me.TextBox7.Left = 2.000984!
            Me.TextBox7.Name = "TextBox7"
            Me.TextBox7.Style = "text-align: right; font-size: 6.75pt"
            Me.TextBox7.Top = 0.3449804!
            Me.TextBox7.Width = 0.2547012!
            '
            'Label13
            '
            Me.Label13.Height = 0.1574803!
            Me.Label13.HyperLink = Nothing
            Me.Label13.Left = 1.284941!
            Me.Label13.Name = "Label13"
            Me.Label13.Style = "text-align: right; font-size: 8.25pt"
            Me.Label13.Text = "Vendidos"
            Me.Label13.Top = 0.1574803!
            Me.Label13.Width = 0.6299213!
            '
            'TextBox68
            '
            Me.TextBox68.DataField = "v20"
            Me.TextBox68.Height = 0.1574803!
            Me.TextBox68.Left = 6.840306!
            Me.TextBox68.Name = "TextBox68"
            Me.TextBox68.Style = "text-align: right; font-size: 6.75pt"
            Me.TextBox68.Top = 0.1574803!
            Me.TextBox68.Width = 0.2547012!
            '
            'TextBox69
            '
            Me.TextBox69.DataField = "v19"
            Me.TextBox69.Height = 0.1574803!
            Me.TextBox69.Left = 6.585605!
            Me.TextBox69.Name = "TextBox69"
            Me.TextBox69.Style = "text-align: right; font-size: 6.75pt"
            Me.TextBox69.Top = 0.1574803!
            Me.TextBox69.Width = 0.2547012!
            '
            'TextBox70
            '
            Me.TextBox70.DataField = "v18"
            Me.TextBox70.Height = 0.1574803!
            Me.TextBox70.Left = 6.330904!
            Me.TextBox70.Name = "TextBox70"
            Me.TextBox70.Style = "text-align: right; font-size: 6.75pt"
            Me.TextBox70.Top = 0.1574803!
            Me.TextBox70.Width = 0.2547012!
            '
            'TextBox71
            '
            Me.TextBox71.DataField = "v17"
            Me.TextBox71.Height = 0.1574803!
            Me.TextBox71.Left = 6.076202!
            Me.TextBox71.Name = "TextBox71"
            Me.TextBox71.Style = "text-align: right; font-size: 6.75pt"
            Me.TextBox71.Top = 0.1574803!
            Me.TextBox71.Width = 0.2547012!
            '
            'TextBox72
            '
            Me.TextBox72.DataField = "v16"
            Me.TextBox72.Height = 0.1574803!
            Me.TextBox72.Left = 5.821502!
            Me.TextBox72.Name = "TextBox72"
            Me.TextBox72.Style = "text-align: right; font-size: 6.75pt"
            Me.TextBox72.Top = 0.1574803!
            Me.TextBox72.Width = 0.2547012!
            '
            'TextBox73
            '
            Me.TextBox73.DataField = "v15"
            Me.TextBox73.Height = 0.1574803!
            Me.TextBox73.Left = 5.5668!
            Me.TextBox73.Name = "TextBox73"
            Me.TextBox73.Style = "text-align: right; font-size: 6.75pt"
            Me.TextBox73.Top = 0.1574803!
            Me.TextBox73.Width = 0.2547012!
            '
            'TextBox74
            '
            Me.TextBox74.DataField = "v14"
            Me.TextBox74.Height = 0.1574803!
            Me.TextBox74.Left = 5.312099!
            Me.TextBox74.Name = "TextBox74"
            Me.TextBox74.Style = "text-align: right; font-size: 6.75pt"
            Me.TextBox74.Top = 0.1574803!
            Me.TextBox74.Width = 0.2547012!
            '
            'TextBox75
            '
            Me.TextBox75.DataField = "v13"
            Me.TextBox75.Height = 0.1574803!
            Me.TextBox75.Left = 5.057398!
            Me.TextBox75.Name = "TextBox75"
            Me.TextBox75.Style = "text-align: right; font-size: 6.75pt"
            Me.TextBox75.Top = 0.1574803!
            Me.TextBox75.Width = 0.2547012!
            '
            'TextBox76
            '
            Me.TextBox76.DataField = "v12"
            Me.TextBox76.Height = 0.1574803!
            Me.TextBox76.Left = 4.802697!
            Me.TextBox76.Name = "TextBox76"
            Me.TextBox76.Style = "text-align: right; font-size: 6.75pt"
            Me.TextBox76.Top = 0.1574803!
            Me.TextBox76.Width = 0.2547012!
            '
            'TextBox77
            '
            Me.TextBox77.DataField = "v11"
            Me.TextBox77.Height = 0.1574803!
            Me.TextBox77.Left = 4.547996!
            Me.TextBox77.Name = "TextBox77"
            Me.TextBox77.Style = "text-align: right; font-size: 6.75pt"
            Me.TextBox77.Top = 0.1574803!
            Me.TextBox77.Width = 0.2547012!
            '
            'TextBox78
            '
            Me.TextBox78.DataField = "v10"
            Me.TextBox78.Height = 0.1574803!
            Me.TextBox78.Left = 4.293295!
            Me.TextBox78.Name = "TextBox78"
            Me.TextBox78.Style = "text-align: right; font-size: 6.75pt"
            Me.TextBox78.Top = 0.1574803!
            Me.TextBox78.Width = 0.2547012!
            '
            'TextBox79
            '
            Me.TextBox79.DataField = "v09"
            Me.TextBox79.Height = 0.1574803!
            Me.TextBox79.Left = 4.038593!
            Me.TextBox79.Name = "TextBox79"
            Me.TextBox79.Style = "text-align: right; font-size: 6.75pt"
            Me.TextBox79.Top = 0.1574803!
            Me.TextBox79.Width = 0.2547012!
            '
            'TextBox80
            '
            Me.TextBox80.DataField = "v08"
            Me.TextBox80.Height = 0.1574803!
            Me.TextBox80.Left = 3.783892!
            Me.TextBox80.Name = "TextBox80"
            Me.TextBox80.Style = "text-align: right; font-size: 6.75pt"
            Me.TextBox80.Top = 0.1574803!
            Me.TextBox80.Width = 0.2547012!
            '
            'TextBox81
            '
            Me.TextBox81.DataField = "v07"
            Me.TextBox81.Height = 0.1574803!
            Me.TextBox81.Left = 3.529192!
            Me.TextBox81.Name = "TextBox81"
            Me.TextBox81.Style = "text-align: right; font-size: 6.75pt"
            Me.TextBox81.Top = 0.1574803!
            Me.TextBox81.Width = 0.2547012!
            '
            'TextBox82
            '
            Me.TextBox82.DataField = "v06"
            Me.TextBox82.Height = 0.1574803!
            Me.TextBox82.Left = 3.27449!
            Me.TextBox82.Name = "TextBox82"
            Me.TextBox82.Style = "text-align: right; font-size: 6.75pt"
            Me.TextBox82.Top = 0.1574803!
            Me.TextBox82.Width = 0.2547012!
            '
            'TextBox83
            '
            Me.TextBox83.DataField = "v05"
            Me.TextBox83.Height = 0.1574803!
            Me.TextBox83.Left = 3.019789!
            Me.TextBox83.Name = "TextBox83"
            Me.TextBox83.Style = "text-align: right; font-size: 6.75pt"
            Me.TextBox83.Top = 0.1574803!
            Me.TextBox83.Width = 0.2547012!
            '
            'TextBox84
            '
            Me.TextBox84.DataField = "v04"
            Me.TextBox84.Height = 0.1574803!
            Me.TextBox84.Left = 2.765088!
            Me.TextBox84.Name = "TextBox84"
            Me.TextBox84.Style = "text-align: right; font-size: 6.75pt"
            Me.TextBox84.Top = 0.1574803!
            Me.TextBox84.Width = 0.2547012!
            '
            'TextBox85
            '
            Me.TextBox85.DataField = "v03"
            Me.TextBox85.Height = 0.1574803!
            Me.TextBox85.Left = 2.510387!
            Me.TextBox85.Name = "TextBox85"
            Me.TextBox85.Style = "text-align: right; font-size: 6.75pt"
            Me.TextBox85.Top = 0.1574803!
            Me.TextBox85.Width = 0.2547012!
            '
            'TextBox86
            '
            Me.TextBox86.DataField = "v02"
            Me.TextBox86.Height = 0.1574803!
            Me.TextBox86.Left = 2.255685!
            Me.TextBox86.Name = "TextBox86"
            Me.TextBox86.Style = "text-align: right; font-size: 6.75pt"
            Me.TextBox86.Top = 0.1574803!
            Me.TextBox86.Width = 0.2547012!
            '
            'TextBox87
            '
            Me.TextBox87.DataField = "V01"
            Me.TextBox87.Height = 0.1574803!
            Me.TextBox87.Left = 2.000984!
            Me.TextBox87.Name = "TextBox87"
            Me.TextBox87.Style = "text-align: right; font-size: 6.75pt"
            Me.TextBox87.Top = 0.1574803!
            Me.TextBox87.Width = 0.2547012!
            '
            'ActiveReport1
            '
            Me.MasterReport = false
            Me.PageSettings.Margins.Bottom = 0.7875!
            Me.PageSettings.Margins.Left = 0.5902778!
            Me.PageSettings.Margins.Right = 0.5902778!
            Me.PageSettings.Margins.Top = 0.7875!
            Me.PageSettings.PaperHeight = 11!
            Me.PageSettings.PaperWidth = 8.5!
            Me.PrintWidth = 7.135417!
            Me.Sections.Add(Me.ReportHeader)
            Me.Sections.Add(Me.PageHeader)
            Me.Sections.Add(Me.GroupHeader1)
            Me.Sections.Add(Me.GroupHeader2)
            Me.Sections.Add(Me.Detail)
            Me.Sections.Add(Me.GroupFooter2)
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
            CType(Me.LblTitulo,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.LblFechas,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label10,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label7,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtSucursal,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox4,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox5,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label5,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label6,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox1,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox6,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox8,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox10,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox12,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox14,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox16,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox18,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox20,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox22,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox24,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox27,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox29,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox31,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox33,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox35,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox37,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox39,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox41,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox43,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox45,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox48,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox49,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox50,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox52,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox53,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox54,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox55,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox56,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox57,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox58,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox59,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox60,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox61,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox62,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox63,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox64,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox65,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox66,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox67,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox51,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label12,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label11,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox46,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox44,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox42,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox40,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox38,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox36,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox34,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox32,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox30,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox28,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox25,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox23,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox21,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox19,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox17,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox15,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox13,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox11,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox9,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox7,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label13,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox68,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox69,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox70,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox71,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox72,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox73,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox74,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox75,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox76,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox77,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox78,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox79,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox80,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox81,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox82,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox83,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox84,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox85,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox86,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox87,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me,System.ComponentModel.ISupportInitialize).EndInit
            Me.ds = CType(Me.DataSource,DataDynamics.ActiveReports.DataSources.SqlDBDataSource)
        
	End Sub

#End Region
End Class
