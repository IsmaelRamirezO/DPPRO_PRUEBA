Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU

Public Class rptAjusteGeneralFechas
Inherits DataDynamics.ActiveReports.ActiveReport
    Public Sub New(ByVal FechaDe As DateTime, ByVal FechaAl As DateTime, ByVal dsAjustes As DataSet)
        MyBase.New()
        InitializeComponent()
        Try

            Dim oAlmacen As Almacen
            Dim oAlmacenesMgr As New CatalogoAlmacenesManager(oAppContext)
            Dim oSAPMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
            oAlmacen = oAlmacenesMgr.Load(oSAPMgr.Read_Centros) 'oAppContext.ApplicationConfiguration.Almacen)

            If Not oAlmacen Is Nothing Then

                Me.txtSucursal.Text = oAlmacen.ID & " " & oAlmacen.Descripcion

            Else

                Me.txtSucursal.Text = oAppContext.ApplicationConfiguration.Almacen

            End If

            Me.DataSource = dsAjustes
            Me.DataMember = dsAjustes.Tables(0).TableName

            Me.txtFecha.Text = Now.Date.ToShortDateString

            Me.txtFechaDel.Text = FechaDe.ToLongDateString
            Me.txtFechaAl.Text = FechaAl.ToLongDateString


        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#Region "ActiveReports Designer generated code"
    Private WithEvents ReportHeader As ReportHeader = Nothing
    Private WithEvents PageHeader As PageHeader = Nothing
    Private WithEvents GroupHeader1 As GroupHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents GroupFooter1 As GroupFooter = Nothing
    Private WithEvents PageFooter As PageFooter = Nothing
    Private WithEvents ReportFooter As ReportFooter = Nothing
	Private Shape1 As Shape = Nothing
	Private Label1 As Label = Nothing
	Private Label2 As Label = Nothing
	Private Label3 As Label = Nothing
	Private Label4 As Label = Nothing
	Private txtFecha As TextBox = Nothing
	Private txtSucursal As TextBox = Nothing
	Private txtFechaDel As TextBox = Nothing
	Private txtFechaAl As TextBox = Nothing
	Private Label5 As Label = Nothing
	Private Label6 As Label = Nothing
	Private Label7 As Label = Nothing
	Private Label8 As Label = Nothing
	Private Label9 As Label = Nothing
	Private Label10 As Label = Nothing
	Private Label11 As Label = Nothing
	Private Label12 As Label = Nothing
	Private Label13 As Label = Nothing
	Private Label14 As Label = Nothing
	Private Label16 As Label = Nothing
	Private TextBox1 As TextBox = Nothing
	Private txtFolio As TextBox = Nothing
	Private txtFechaAjuste As TextBox = Nothing
	Private txtAE_Codigo As TextBox = Nothing
	Private txtAE_Talla As TextBox = Nothing
	Private txtAE_Cantidad As TextBox = Nothing
	Private txtAE_Costo As TextBox = Nothing
	Private txtAS_Codigo As TextBox = Nothing
	Private txtAS_Talla As TextBox = Nothing
	Private txtAS_Cantidad As TextBox = Nothing
	Private txtAS_Costo As TextBox = Nothing
	Private Label17 As Label = Nothing
	Private TextBox2 As TextBox = Nothing
	Private TextBox3 As TextBox = Nothing
	Private TextBox4 As TextBox = Nothing
	Private TextBox5 As TextBox = Nothing
	Private Label18 As Label = Nothing
	Private TextBox6 As TextBox = Nothing
	Private TextBox7 As TextBox = Nothing
	Private TextBox8 As TextBox = Nothing
	Private TextBox9 As TextBox = Nothing
	Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptAjusteGeneralFechas))
            Me.Detail = New DataDynamics.ActiveReports.Detail()
            Me.ReportHeader = New DataDynamics.ActiveReports.ReportHeader()
            Me.ReportFooter = New DataDynamics.ActiveReports.ReportFooter()
            Me.PageHeader = New DataDynamics.ActiveReports.PageHeader()
            Me.PageFooter = New DataDynamics.ActiveReports.PageFooter()
            Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader()
            Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter()
            Me.Shape1 = New DataDynamics.ActiveReports.Shape()
            Me.Label1 = New DataDynamics.ActiveReports.Label()
            Me.Label2 = New DataDynamics.ActiveReports.Label()
            Me.Label3 = New DataDynamics.ActiveReports.Label()
            Me.Label4 = New DataDynamics.ActiveReports.Label()
            Me.txtFecha = New DataDynamics.ActiveReports.TextBox()
            Me.txtSucursal = New DataDynamics.ActiveReports.TextBox()
            Me.txtFechaDel = New DataDynamics.ActiveReports.TextBox()
            Me.txtFechaAl = New DataDynamics.ActiveReports.TextBox()
            Me.Label5 = New DataDynamics.ActiveReports.Label()
            Me.Label6 = New DataDynamics.ActiveReports.Label()
            Me.Label7 = New DataDynamics.ActiveReports.Label()
            Me.Label8 = New DataDynamics.ActiveReports.Label()
            Me.Label9 = New DataDynamics.ActiveReports.Label()
            Me.Label10 = New DataDynamics.ActiveReports.Label()
            Me.Label11 = New DataDynamics.ActiveReports.Label()
            Me.Label12 = New DataDynamics.ActiveReports.Label()
            Me.Label13 = New DataDynamics.ActiveReports.Label()
            Me.Label14 = New DataDynamics.ActiveReports.Label()
            Me.Label16 = New DataDynamics.ActiveReports.Label()
            Me.TextBox1 = New DataDynamics.ActiveReports.TextBox()
            Me.txtFolio = New DataDynamics.ActiveReports.TextBox()
            Me.txtFechaAjuste = New DataDynamics.ActiveReports.TextBox()
            Me.txtAE_Codigo = New DataDynamics.ActiveReports.TextBox()
            Me.txtAE_Talla = New DataDynamics.ActiveReports.TextBox()
            Me.txtAE_Cantidad = New DataDynamics.ActiveReports.TextBox()
            Me.txtAE_Costo = New DataDynamics.ActiveReports.TextBox()
            Me.txtAS_Codigo = New DataDynamics.ActiveReports.TextBox()
            Me.txtAS_Talla = New DataDynamics.ActiveReports.TextBox()
            Me.txtAS_Cantidad = New DataDynamics.ActiveReports.TextBox()
            Me.txtAS_Costo = New DataDynamics.ActiveReports.TextBox()
            Me.Label17 = New DataDynamics.ActiveReports.Label()
            Me.TextBox2 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox3 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox4 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox5 = New DataDynamics.ActiveReports.TextBox()
            Me.Label18 = New DataDynamics.ActiveReports.Label()
            Me.TextBox6 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox7 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox8 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox9 = New DataDynamics.ActiveReports.TextBox()
            CType(Me.Label1,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label3,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFecha,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtSucursal,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFechaDel,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFechaAl,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label5,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label6,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label7,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label8,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label9,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label10,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label11,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label12,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label13,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label14,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label16,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox1,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFolio,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFechaAjuste,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtAE_Codigo,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtAE_Talla,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtAE_Cantidad,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtAE_Costo,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtAS_Codigo,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtAS_Talla,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtAS_Cantidad,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtAS_Costo,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label17,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox2,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox3,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox4,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox5,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label18,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox6,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox7,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox8,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox9,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
            '
            'Detail
            '
            Me.Detail.ColumnSpacing = 0!
            Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtFolio, Me.txtFechaAjuste, Me.txtAE_Codigo, Me.txtAE_Talla, Me.txtAE_Cantidad, Me.txtAE_Costo, Me.txtAS_Codigo, Me.txtAS_Talla, Me.txtAS_Cantidad, Me.txtAS_Costo})
            Me.Detail.Height = 0.1763889!
            Me.Detail.KeepTogether = true
            Me.Detail.Name = "Detail"
            '
            'ReportHeader
            '
            Me.ReportHeader.Height = 0!
            Me.ReportHeader.Name = "ReportHeader"
            '
            'ReportFooter
            '
            Me.ReportFooter.Height = 0!
            Me.ReportFooter.KeepTogether = true
            Me.ReportFooter.Name = "ReportFooter"
            '
            'PageHeader
            '
            Me.PageHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape1, Me.Label1, Me.Label2, Me.Label3, Me.Label4, Me.txtFecha, Me.txtSucursal, Me.txtFechaDel, Me.txtFechaAl, Me.Label5, Me.Label6, Me.Label7, Me.Label8, Me.Label9, Me.Label10, Me.Label11, Me.Label12, Me.Label13, Me.Label14, Me.Label16, Me.TextBox1})
            Me.PageHeader.Height = 1.145833!
            Me.PageHeader.Name = "PageHeader"
            '
            'PageFooter
            '
            Me.PageFooter.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label18, Me.TextBox6, Me.TextBox7, Me.TextBox8, Me.TextBox9})
            Me.PageFooter.Height = 0.1875!
            Me.PageFooter.Name = "PageFooter"
            '
            'GroupHeader1
            '
            Me.GroupHeader1.Height = 0!
            Me.GroupHeader1.KeepTogether = true
            Me.GroupHeader1.Name = "GroupHeader1"
            '
            'GroupFooter1
            '
            Me.GroupFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label17, Me.TextBox2, Me.TextBox3, Me.TextBox4, Me.TextBox5})
            Me.GroupFooter1.Height = 0.2076389!
            Me.GroupFooter1.KeepTogether = true
            Me.GroupFooter1.Name = "GroupFooter1"
            '
            'Shape1
            '
            Me.Shape1.Height = 0.9055118!
            Me.Shape1.Left = 0!
            Me.Shape1.Name = "Shape1"
            Me.Shape1.RoundingRadius = 9.999999!
            Me.Shape1.Top = 0!
            Me.Shape1.Width = 7.283465!
            '
            'Label1
            '
            Me.Label1.Height = 0.2!
            Me.Label1.HyperLink = Nothing
            Me.Label1.Left = 2.156004!
            Me.Label1.Name = "Label1"
            Me.Label1.Style = "text-align: center"
            Me.Label1.Text = "REPORTE DE AJUSTE GENERAL"
            Me.Label1.Top = 0.0625!
            Me.Label1.Width = 2.795276!
            '
            'Label2
            '
            Me.Label2.Height = 0.2!
            Me.Label2.HyperLink = Nothing
            Me.Label2.Left = 1.526083!
            Me.Label2.Name = "Label2"
            Me.Label2.Style = ""
            Me.Label2.Text = "De.:"
            Me.Label2.Top = 0.2755906!
            Me.Label2.Width = 0.2755904!
            '
            'Label3
            '
            Me.Label3.Height = 0.2!
            Me.Label3.HyperLink = Nothing
            Me.Label3.Left = 3.927658!
            Me.Label3.Name = "Label3"
            Me.Label3.Style = ""
            Me.Label3.Text = "Al.:"
            Me.Label3.Top = 0.2755906!
            Me.Label3.Width = 0.2755904!
            '
            'Label4
            '
            Me.Label4.Height = 0.2!
            Me.Label4.HyperLink = Nothing
            Me.Label4.Left = 1.526083!
            Me.Label4.Name = "Label4"
            Me.Label4.Style = ""
            Me.Label4.Text = "Sucursal.:"
            Me.Label4.Top = 0.511811!
            Me.Label4.Width = 0.6299212!
            '
            'txtFecha
            '
            Me.txtFecha.Height = 0.2!
            Me.txtFecha.Left = 0.07874014!
            Me.txtFecha.Name = "txtFecha"
            Me.txtFecha.Top = 0.03937007!
            Me.txtFecha.Width = 1.338583!
            '
            'txtSucursal
            '
            Me.txtSucursal.Height = 0.2!
            Me.txtSucursal.Left = 2.195374!
            Me.txtSucursal.Name = "txtSucursal"
            Me.txtSucursal.Top = 0.511811!
            Me.txtSucursal.Width = 2.755905!
            '
            'txtFechaDel
            '
            Me.txtFechaDel.Height = 0.2!
            Me.txtFechaDel.Left = 1.841043!
            Me.txtFechaDel.Name = "txtFechaDel"
            Me.txtFechaDel.Top = 0.2755906!
            Me.txtFechaDel.Width = 1.889764!
            '
            'txtFechaAl
            '
            Me.txtFechaAl.Height = 0.2!
            Me.txtFechaAl.Left = 4.242618!
            Me.txtFechaAl.Name = "txtFechaAl"
            Me.txtFechaAl.Top = 0.2755906!
            Me.txtFechaAl.Width = 1.889764!
            '
            'Label5
            '
            Me.Label5.Height = 0.2!
            Me.Label5.HyperLink = Nothing
            Me.Label5.Left = 0!
            Me.Label5.Name = "Label5"
            Me.Label5.Style = "text-align: center; font-size: 8.25pt"
            Me.Label5.Text = "FOLIO"
            Me.Label5.Top = 0.9270833!
            Me.Label5.Width = 0.3937007!
            '
            'Label6
            '
            Me.Label6.Height = 0.2!
            Me.Label6.HyperLink = Nothing
            Me.Label6.Left = 0.4562007!
            Me.Label6.Name = "Label6"
            Me.Label6.Style = "text-align: center; font-size: 8.25pt"
            Me.Label6.Text = "FECHA"
            Me.Label6.Top = 0.9270833!
            Me.Label6.Width = 0.6230316!
            '
            'Label7
            '
            Me.Label7.Height = 0.2!
            Me.Label7.HyperLink = Nothing
            Me.Label7.Left = 1.157972!
            Me.Label7.Name = "Label7"
            Me.Label7.Style = "text-align: center; font-size: 8.25pt"
            Me.Label7.Text = "CODIGO"
            Me.Label7.Top = 0.9270833!
            Me.Label7.Width = 1.519193!
            '
            'Label8
            '
            Me.Label8.Height = 0.2!
            Me.Label8.HyperLink = Nothing
            Me.Label8.Left = 2.797408!
            Me.Label8.Name = "Label8"
            Me.Label8.Style = "text-align: center; font-size: 8.25pt"
            Me.Label8.Text = "TALLA"
            Me.Label8.Top = 0.9270833!
            Me.Label8.Width = 0.4122376!
            '
            'Label9
            '
            Me.Label9.Height = 0.2!
            Me.Label9.HyperLink = Nothing
            Me.Label9.Left = 3.255905!
            Me.Label9.Name = "Label9"
            Me.Label9.Style = "text-align: center; font-size: 8.25pt"
            Me.Label9.Text = "PZAS."
            Me.Label9.Top = 0.9270833!
            Me.Label9.Width = 0.3661415!
            '
            'Label10
            '
            Me.Label10.Height = 0.2!
            Me.Label10.HyperLink = Nothing
            Me.Label10.Left = 3.661417!
            Me.Label10.Name = "Label10"
            Me.Label10.Style = "text-align: center; font-size: 8.25pt"
            Me.Label10.Text = "COSTO"
            Me.Label10.Top = 0.9270833!
            Me.Label10.Width = 0.6334481!
            '
            'Label11
            '
            Me.Label11.Height = 0.2!
            Me.Label11.HyperLink = Nothing
            Me.Label11.Left = 4.331774!
            Me.Label11.Name = "Label11"
            Me.Label11.Style = "text-align: center; font-size: 8.25pt"
            Me.Label11.Text = "CODIGO"
            Me.Label11.Top = 0.9270833!
            Me.Label11.Width = 1.095473!
            '
            'Label12
            '
            Me.Label12.Height = 0.2!
            Me.Label12.HyperLink = Nothing
            Me.Label12.Left = 5.818242!
            Me.Label12.Name = "Label12"
            Me.Label12.Style = "text-align: center; font-size: 8.25pt"
            Me.Label12.Text = "TALLA"
            Me.Label12.Top = 0.9270833!
            Me.Label12.Width = 0.3835301!
            '
            'Label13
            '
            Me.Label13.Height = 0.2!
            Me.Label13.HyperLink = Nothing
            Me.Label13.Left = 6.287402!
            Me.Label13.Name = "Label13"
            Me.Label13.Style = "text-align: center; font-size: 8.25pt"
            Me.Label13.Text = "PZAS."
            Me.Label13.Top = 0.9270833!
            Me.Label13.Width = 0.3661418!
            '
            'Label14
            '
            Me.Label14.Height = 0.2!
            Me.Label14.HyperLink = Nothing
            Me.Label14.Left = 6.732284!
            Me.Label14.Name = "Label14"
            Me.Label14.Style = "text-align: center; font-size: 8.25pt"
            Me.Label14.Text = "COSTO"
            Me.Label14.Top = 0.9270833!
            Me.Label14.Width = 0.5118108!
            '
            'Label16
            '
            Me.Label16.Height = 0.2!
            Me.Label16.HyperLink = Nothing
            Me.Label16.Left = 5.51181!
            Me.Label16.Name = "Label16"
            Me.Label16.Style = ""
            Me.Label16.Text = "Pág."
            Me.Label16.Top = 0.03937007!
            Me.Label16.Width = 0.3543305!
            '
            'TextBox1
            '
            Me.TextBox1.Height = 0.2!
            Me.TextBox1.Left = 5.984252!
            Me.TextBox1.Name = "TextBox1"
            Me.TextBox1.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
            Me.TextBox1.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount
            Me.TextBox1.Text = "TextBox1"
            Me.TextBox1.Top = 0.03937009!
            Me.TextBox1.Width = 1!
            '
            'txtFolio
            '
            Me.txtFolio.DataField = "FolioAjuste"
            Me.txtFolio.Height = 0.1574803!
            Me.txtFolio.Left = 0!
            Me.txtFolio.Name = "txtFolio"
            Me.txtFolio.Style = "text-align: center; font-size: 8.25pt"
            Me.txtFolio.Text = "9999"
            Me.txtFolio.Top = 0!
            Me.txtFolio.Width = 0.3543307!
            '
            'txtFechaAjuste
            '
            Me.txtFechaAjuste.DataField = "FechaAjuste"
            Me.txtFechaAjuste.Height = 0.1574803!
            Me.txtFechaAjuste.Left = 0.347441!
            Me.txtFechaAjuste.Name = "txtFechaAjuste"
            Me.txtFechaAjuste.OutputFormat = resources.GetString("txtFechaAjuste.OutputFormat")
            Me.txtFechaAjuste.Style = "font-size: 8.25pt"
            Me.txtFechaAjuste.Text = "23/09/05 23:59"
            Me.txtFechaAjuste.Top = 0!
            Me.txtFechaAjuste.Width = 0.8267716!
            '
            'txtAE_Codigo
            '
            Me.txtAE_Codigo.DataField = "AE_Codigo"
            Me.txtAE_Codigo.Height = 0.1574803!
            Me.txtAE_Codigo.Left = 1.181102!
            Me.txtAE_Codigo.Name = "txtAE_Codigo"
            Me.txtAE_Codigo.Style = "font-size: 8.25pt"
            Me.txtAE_Codigo.Text = "AAAAAAAAAAAAAAAAAAAA"
            Me.txtAE_Codigo.Top = 0!
            Me.txtAE_Codigo.Width = 1.558563!
            '
            'txtAE_Talla
            '
            Me.txtAE_Talla.DataField = "AE_Talla"
            Me.txtAE_Talla.Height = 0.1574803!
            Me.txtAE_Talla.Left = 2.795276!
            Me.txtAE_Talla.Name = "txtAE_Talla"
            Me.txtAE_Talla.Style = "text-align: center; font-size: 8.25pt"
            Me.txtAE_Talla.Text = "20"
            Me.txtAE_Talla.Top = 0!
            Me.txtAE_Talla.Width = 0.3543305!
            '
            'txtAE_Cantidad
            '
            Me.txtAE_Cantidad.DataField = "AE_Cantidad"
            Me.txtAE_Cantidad.Height = 0.1574803!
            Me.txtAE_Cantidad.Left = 3.228346!
            Me.txtAE_Cantidad.Name = "txtAE_Cantidad"
            Me.txtAE_Cantidad.Style = "text-align: center; font-size: 8.25pt"
            Me.txtAE_Cantidad.Text = "1000"
            Me.txtAE_Cantidad.Top = 0!
            Me.txtAE_Cantidad.Width = 0.354331!
            '
            'txtAE_Costo
            '
            Me.txtAE_Costo.DataField = "AE_Costo"
            Me.txtAE_Costo.Height = 0.1574803!
            Me.txtAE_Costo.Left = 3.661417!
            Me.txtAE_Costo.Name = "txtAE_Costo"
            Me.txtAE_Costo.OutputFormat = resources.GetString("txtAE_Costo.OutputFormat")
            Me.txtAE_Costo.Style = "text-align: right; font-size: 8.25pt"
            Me.txtAE_Costo.Text = "$456.34"
            Me.txtAE_Costo.Top = 0!
            Me.txtAE_Costo.Width = 0.5603678!
            '
            'txtAS_Codigo
            '
            Me.txtAS_Codigo.DataField = "AS_Codigo"
            Me.txtAS_Codigo.Height = 0.1574803!
            Me.txtAS_Codigo.Left = 4.347768!
            Me.txtAS_Codigo.Name = "txtAS_Codigo"
            Me.txtAS_Codigo.Style = "font-size: 8.25pt"
            Me.txtAS_Codigo.Text = "AAAAAAAAAAAAAAAAAAAA"
            Me.txtAS_Codigo.Top = 0!
            Me.txtAS_Codigo.Width = 1.558563!
            '
            'txtAS_Talla
            '
            Me.txtAS_Talla.DataField = "AS_Talla"
            Me.txtAS_Talla.Height = 0.1574803!
            Me.txtAS_Talla.Left = 5.941109!
            Me.txtAS_Talla.Name = "txtAS_Talla"
            Me.txtAS_Talla.Style = "text-align: center; font-size: 8.25pt"
            Me.txtAS_Talla.Text = "20"
            Me.txtAS_Talla.Top = 0!
            Me.txtAS_Talla.Width = 0.3543305!
            '
            'txtAS_Cantidad
            '
            Me.txtAS_Cantidad.DataField = "AS_Cantidad"
            Me.txtAS_Cantidad.Height = 0.1574803!
            Me.txtAS_Cantidad.Left = 6.34293!
            Me.txtAS_Cantidad.Name = "txtAS_Cantidad"
            Me.txtAS_Cantidad.Style = "text-align: center; font-size: 8.25pt"
            Me.txtAS_Cantidad.Text = "1000"
            Me.txtAS_Cantidad.Top = 0!
            Me.txtAS_Cantidad.Width = 0.3499837!
            '
            'txtAS_Costo
            '
            Me.txtAS_Costo.DataField = "AS_Costo"
            Me.txtAS_Costo.Height = 0.1574803!
            Me.txtAS_Costo.Left = 6.737861!
            Me.txtAS_Costo.Name = "txtAS_Costo"
            Me.txtAS_Costo.OutputFormat = resources.GetString("txtAS_Costo.OutputFormat")
            Me.txtAS_Costo.Style = "text-align: right; font-size: 8.25pt"
            Me.txtAS_Costo.Text = "$3562.45"
            Me.txtAS_Costo.Top = 0!
            Me.txtAS_Costo.Width = 0.5178804!
            '
            'Label17
            '
            Me.Label17.Height = 0.2!
            Me.Label17.HyperLink = Nothing
            Me.Label17.Left = 0.0625!
            Me.Label17.Name = "Label17"
            Me.Label17.Style = "font-size: 8.25pt"
            Me.Label17.Text = "Total de Articulos ==>"
            Me.Label17.Top = 0!
            Me.Label17.Width = 1.472933!
            '
            'TextBox2
            '
            Me.TextBox2.DataField = "AE_Cantidad"
            Me.TextBox2.Height = 0.2!
            Me.TextBox2.Left = 3.212106!
            Me.TextBox2.Name = "TextBox2"
            Me.TextBox2.Style = "text-align: center; font-size: 8.25pt"
            Me.TextBox2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
            Me.TextBox2.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
            Me.TextBox2.Text = "999"
            Me.TextBox2.Top = 0!
            Me.TextBox2.Width = 0.4094489!
            '
            'TextBox3
            '
            Me.TextBox3.DataField = "AE_Costo"
            Me.TextBox3.Height = 0.2!
            Me.TextBox3.Left = 3.723917!
            Me.TextBox3.Name = "TextBox3"
            Me.TextBox3.OutputFormat = resources.GetString("TextBox3.OutputFormat")
            Me.TextBox3.Style = "font-size: 8.25pt"
            Me.TextBox3.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
            Me.TextBox3.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
            Me.TextBox3.Text = "TextBox2"
            Me.TextBox3.Top = 0!
            Me.TextBox3.Width = 0.5905514!
            '
            'TextBox4
            '
            Me.TextBox4.DataField = "AS_Cantidad"
            Me.TextBox4.Height = 0.2!
            Me.TextBox4.Left = 6.338583!
            Me.TextBox4.Name = "TextBox4"
            Me.TextBox4.Style = "text-align: center; font-size: 8.25pt"
            Me.TextBox4.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
            Me.TextBox4.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
            Me.TextBox4.Text = "999"
            Me.TextBox4.Top = 0!
            Me.TextBox4.Width = 0.3543303!
            '
            'TextBox5
            '
            Me.TextBox5.DataField = "AS_Costo"
            Me.TextBox5.Height = 0.2!
            Me.TextBox5.Left = 6.794784!
            Me.TextBox5.Name = "TextBox5"
            Me.TextBox5.OutputFormat = resources.GetString("TextBox5.OutputFormat")
            Me.TextBox5.Style = "font-size: 8.25pt"
            Me.TextBox5.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
            Me.TextBox5.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
            Me.TextBox5.Text = "TextBox4"
            Me.TextBox5.Top = 0!
            Me.TextBox5.Width = 0.5882549!
            '
            'Label18
            '
            Me.Label18.Height = 0.2!
            Me.Label18.HyperLink = Nothing
            Me.Label18.Left = 0!
            Me.Label18.Name = "Label18"
            Me.Label18.Style = "font-size: 8.25pt"
            Me.Label18.Text = "Total de Articulos ==>"
            Me.Label18.Top = 0!
            Me.Label18.Width = 1.472933!
            '
            'TextBox6
            '
            Me.TextBox6.DataField = "AE_Cantidad"
            Me.TextBox6.Height = 0.2!
            Me.TextBox6.Left = 3.228346!
            Me.TextBox6.Name = "TextBox6"
            Me.TextBox6.Style = "text-align: center; font-size: 8.25pt"
            Me.TextBox6.SummaryGroup = "GroupHeader1"
            Me.TextBox6.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
            Me.TextBox6.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
            Me.TextBox6.Text = "999"
            Me.TextBox6.Top = 0!
            Me.TextBox6.Width = 0.4094489!
            '
            'TextBox7
            '
            Me.TextBox7.DataField = "AE_Costo"
            Me.TextBox7.Height = 0.2!
            Me.TextBox7.Left = 3.740158!
            Me.TextBox7.Name = "TextBox7"
            Me.TextBox7.OutputFormat = resources.GetString("TextBox7.OutputFormat")
            Me.TextBox7.Style = "font-size: 8.25pt"
            Me.TextBox7.SummaryGroup = "GroupHeader1"
            Me.TextBox7.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
            Me.TextBox7.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
            Me.TextBox7.Text = "TextBox2"
            Me.TextBox7.Top = 0!
            Me.TextBox7.Width = 0.5905514!
            '
            'TextBox8
            '
            Me.TextBox8.DataField = "AS_Cantidad"
            Me.TextBox8.Height = 0.2!
            Me.TextBox8.Left = 6.338583!
            Me.TextBox8.Name = "TextBox8"
            Me.TextBox8.Style = "text-align: center; font-size: 8.25pt"
            Me.TextBox8.SummaryGroup = "GroupHeader1"
            Me.TextBox8.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
            Me.TextBox8.SummaryType = DataDynamics.ActiveReports.SummaryType.PageTotal
            Me.TextBox8.Text = "999"
            Me.TextBox8.Top = 0!
            Me.TextBox8.Width = 0.3543303!
            '
            'TextBox9
            '
            Me.TextBox9.DataField = "AS_Costo"
            Me.TextBox9.Height = 0.2!
            Me.TextBox9.Left = 6.811023!
            Me.TextBox9.Name = "TextBox9"
            Me.TextBox9.OutputFormat = resources.GetString("TextBox9.OutputFormat")
            Me.TextBox9.Style = "font-size: 8.25pt"
            Me.TextBox9.SummaryGroup = "GroupHeader1"
            Me.TextBox9.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
            Me.TextBox9.SummaryType = DataDynamics.ActiveReports.SummaryType.PageTotal
            Me.TextBox9.Text = "TextBox4"
            Me.TextBox9.Top = 0!
            Me.TextBox9.Width = 0.5882549!
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
            Me.PrintWidth = 7.3125!
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
            CType(Me.Label1,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label3,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFecha,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtSucursal,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFechaDel,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFechaAl,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label5,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label6,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label7,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label8,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label9,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label10,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label11,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label12,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label13,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label14,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label16,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox1,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFolio,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFechaAjuste,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtAE_Codigo,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtAE_Talla,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtAE_Cantidad,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtAE_Costo,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtAS_Codigo,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtAS_Talla,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtAS_Cantidad,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtAS_Costo,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label17,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox2,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox3,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox4,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox5,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label18,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox6,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox7,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox8,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox9,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        
	End Sub

#End Region
End Class
