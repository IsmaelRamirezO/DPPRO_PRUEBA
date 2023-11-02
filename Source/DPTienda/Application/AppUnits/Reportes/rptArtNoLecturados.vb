Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Public Class rptArtNoLecturados
Inherits DataDynamics.ActiveReports.ActiveReport
    Public Sub New(ByVal stralmacen As String, ByVal strTipoMovto As String, ByVal strOrigen As String, _
    ByVal strOrigenDes As String, ByVal strDestino As String, ByVal strDestinoDes As String, _
    ByVal strFolioTraslado As String, ByVal strResponsable As String)
        MyBase.New()
        InitializeComponent()
        Me.txtFechaReporte.Text = Now.Date.ToShortDateString : Me.txtSucursal.Text = stralmacen
        Me.txtTipoMovto.Text = strTipoMovto : Me.txtOrigen.Text = strOrigen
        Me.txtOrigenDes.Text = strOrigenDes : Me.txtDestino.Text = strDestino
        Me.txtDestinoDes.Text = strDestinoDes : Me.txtFolioTraslado.Text = strFolioTraslado
        Me.txtResponsable.Text = strResponsable
    End Sub
#Region "ActiveReports Designer generated code"
    Private WithEvents ReportHeader As ReportHeader = Nothing
    Private WithEvents PageHeader As PageHeader = Nothing
    Private WithEvents GroupHeader1 As GroupHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents GroupFooter1 As GroupFooter = Nothing
    Private WithEvents PageFooter As PageFooter = Nothing
    Private WithEvents ReportFooter As ReportFooter = Nothing
	Private Label16 As Label = Nothing
	Private Label1 As Label = Nothing
	Private Label2 As Label = Nothing
	Private txtSucursal As TextBox = Nothing
	Private Label7 As Label = Nothing
	Private Label11 As Label = Nothing
	Private Label12 As Label = Nothing
	Private Label13 As Label = Nothing
	Private txtResponsable As TextBox = Nothing
	Private Label17 As Label = Nothing
	Private txtTipoMovto As TextBox = Nothing
	Private Label18 As Label = Nothing
	Private txtOrigen As TextBox = Nothing
	Private txtOrigenDes As TextBox = Nothing
	Private Label19 As Label = Nothing
	Private txtDestino As TextBox = Nothing
	Private txtDestinoDes As TextBox = Nothing
	Private Label20 As Label = Nothing
	Private txtFolioTraslado As TextBox = Nothing
	Private Label3 As Label = Nothing
	Private txtFechaReporte As TextBox = Nothing
	Private Label22 As Label = Nothing
	Private TextBox8 As TextBox = Nothing
	Private TextBox7 As TextBox = Nothing
	Private TextBox2 As TextBox = Nothing
	Private TextBox3 As TextBox = Nothing
	Private TextBox5 As TextBox = Nothing
	Private TextBox6 As TextBox = Nothing
	Private TextBox9 As TextBox = Nothing
	Private Label14 As Label = Nothing
	Private tbPageNumber As TextBox = Nothing
	Private Label15 As Label = Nothing
	Private tbPageCount As TextBox = Nothing
	Private Label21 As Label = Nothing
	Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptArtNoLecturados))
        Me.Detail = New DataDynamics.ActiveReports.Detail()
        Me.TextBox2 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox3 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox5 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox6 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox9 = New DataDynamics.ActiveReports.TextBox()
        Me.ReportHeader = New DataDynamics.ActiveReports.ReportHeader()
        Me.Label16 = New DataDynamics.ActiveReports.Label()
        Me.Label1 = New DataDynamics.ActiveReports.Label()
        Me.Label2 = New DataDynamics.ActiveReports.Label()
        Me.txtSucursal = New DataDynamics.ActiveReports.TextBox()
        Me.Label7 = New DataDynamics.ActiveReports.Label()
        Me.Label11 = New DataDynamics.ActiveReports.Label()
        Me.Label12 = New DataDynamics.ActiveReports.Label()
        Me.Label13 = New DataDynamics.ActiveReports.Label()
        Me.txtResponsable = New DataDynamics.ActiveReports.TextBox()
        Me.Label17 = New DataDynamics.ActiveReports.Label()
        Me.txtTipoMovto = New DataDynamics.ActiveReports.TextBox()
        Me.Label18 = New DataDynamics.ActiveReports.Label()
        Me.txtOrigen = New DataDynamics.ActiveReports.TextBox()
        Me.txtOrigenDes = New DataDynamics.ActiveReports.TextBox()
        Me.Label19 = New DataDynamics.ActiveReports.Label()
        Me.txtDestino = New DataDynamics.ActiveReports.TextBox()
        Me.txtDestinoDes = New DataDynamics.ActiveReports.TextBox()
        Me.Label20 = New DataDynamics.ActiveReports.Label()
        Me.txtFolioTraslado = New DataDynamics.ActiveReports.TextBox()
        Me.Label3 = New DataDynamics.ActiveReports.Label()
        Me.txtFechaReporte = New DataDynamics.ActiveReports.TextBox()
        Me.Label22 = New DataDynamics.ActiveReports.Label()
        Me.ReportFooter = New DataDynamics.ActiveReports.ReportFooter()
        Me.PageHeader = New DataDynamics.ActiveReports.PageHeader()
        Me.PageFooter = New DataDynamics.ActiveReports.PageFooter()
        Me.Label14 = New DataDynamics.ActiveReports.Label()
        Me.tbPageNumber = New DataDynamics.ActiveReports.TextBox()
        Me.Label15 = New DataDynamics.ActiveReports.Label()
        Me.tbPageCount = New DataDynamics.ActiveReports.TextBox()
        Me.Label21 = New DataDynamics.ActiveReports.Label()
        Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader()
        Me.TextBox8 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox7 = New DataDynamics.ActiveReports.TextBox()
        Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter()
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSucursal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtResponsable, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTipoMovto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtOrigen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtOrigenDes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label19, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDestino, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDestinoDes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label20, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFolioTraslado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaReporte, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label22, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbPageNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbPageCount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label21, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.ColumnSpacing = 0.0!
        Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TextBox2, Me.TextBox3, Me.TextBox5, Me.TextBox6, Me.TextBox9})
        Me.Detail.Height = 0.1666667!
        Me.Detail.Name = "Detail"
        '
        'TextBox2
        '
        Me.TextBox2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox2.DataField = "Codigo"
        Me.TextBox2.Height = 0.1653543!
        Me.TextBox2.Left = 0.125!
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Style = "text-align: center; font-weight: normal; font-size: 8.25pt; vertical-align: top"
        Me.TextBox2.Text = Nothing
        Me.TextBox2.Top = 0.0!
        Me.TextBox2.Width = 1.387303!
        '
        'TextBox3
        '
        Me.TextBox3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox3.DataField = "Talla"
        Me.TextBox3.Height = 0.1653543!
        Me.TextBox3.Left = 4.66191!
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Style = "text-align: center; font-weight: normal; font-size: 8.25pt"
        Me.TextBox3.Text = Nothing
        Me.TextBox3.Top = 0.0!
        Me.TextBox3.Visible = False
        Me.TextBox3.Width = 0.5999014!
        '
        'TextBox5
        '
        Me.TextBox5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox5.DataField = "Descripcion"
        Me.TextBox5.Height = 0.1653543!
        Me.TextBox5.Left = 1.512303!
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Style = "font-weight: normal; font-size: 8.25pt"
        Me.TextBox5.Text = Nothing
        Me.TextBox5.Top = 0.0!
        Me.TextBox5.Width = 3.749697!
        '
        'TextBox6
        '
        Me.TextBox6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox6.DataField = "Restante"
        Me.TextBox6.Height = 0.1653543!
        Me.TextBox6.Left = 5.25!
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Style = "text-align: center; font-weight: normal; font-size: 8.25pt"
        Me.TextBox6.Text = Nothing
        Me.TextBox6.Top = 0.0!
        Me.TextBox6.Width = 0.7229334!
        '
        'TextBox9
        '
        Me.TextBox9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox9.DataField = "FolioSAP"
        Me.TextBox9.Height = 0.1653543!
        Me.TextBox9.Left = 5.988189!
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.Style = "text-align: center; font-weight: normal; font-size: 8.25pt"
        Me.TextBox9.Text = Nothing
        Me.TextBox9.Top = 0.0!
        Me.TextBox9.Width = 1.062992!
        '
        'ReportHeader
        '
        Me.ReportHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label16, Me.Label1, Me.Label2, Me.txtSucursal, Me.Label7, Me.Label11, Me.Label12, Me.Label13, Me.txtResponsable, Me.Label17, Me.txtTipoMovto, Me.Label18, Me.txtOrigen, Me.txtOrigenDes, Me.Label19, Me.txtDestino, Me.txtDestinoDes, Me.Label20, Me.txtFolioTraslado, Me.Label3, Me.txtFechaReporte, Me.Label22})
        Me.ReportHeader.Height = 1.4375!
        Me.ReportHeader.Name = "ReportHeader"
        '
        'Label16
        '
        Me.Label16.Height = 0.2!
        Me.Label16.HyperLink = Nothing
        Me.Label16.Left = 0.125!
        Me.Label16.Name = "Label16"
        Me.Label16.Style = "ddo-char-set: 1; font-weight: bold"
        Me.Label16.Text = "Responsable:"
        Me.Label16.Top = 0.784941!
        Me.Label16.Width = 0.9862201!
        '
        'Label1
        '
        Me.Label1.Height = 0.1999672!
        Me.Label1.HyperLink = Nothing
        Me.Label1.Left = 0.06348401!
        Me.Label1.Name = "Label1"
        Me.Label1.Style = "text-align: center; font-weight: bold; font-size: 12pt"
        Me.Label1.Text = "Reporte de Faltantes / Sobrantes"
        Me.Label1.Top = 0.0!
        Me.Label1.Width = 6.860728!
        '
        'Label2
        '
        Me.Label2.Height = 0.2!
        Me.Label2.HyperLink = Nothing
        Me.Label2.Left = 0.125!
        Me.Label2.Name = "Label2"
        Me.Label2.Style = "ddo-char-set: 1; font-weight: bold"
        Me.Label2.Text = "Sucursal:"
        Me.Label2.Top = 0.3380906!
        Me.Label2.Width = 0.7217847!
        '
        'txtSucursal
        '
        Me.txtSucursal.Height = 0.2!
        Me.txtSucursal.Left = 0.863025!
        Me.txtSucursal.Name = "txtSucursal"
        Me.txtSucursal.Text = Nothing
        Me.txtSucursal.Top = 0.3380906!
        Me.txtSucursal.Width = 2.802822!
        '
        'Label7
        '
        Me.Label7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label7.Height = 0.3574803!
        Me.Label7.HyperLink = Nothing
        Me.Label7.Left = 4.66191!
        Me.Label7.Name = "Label7"
        Me.Label7.Style = "ddo-char-set: 1; text-align: center; font-weight: bold; vertical-align: middle"
        Me.Label7.Text = "Talla"
        Me.Label7.Top = 1.068898!
        Me.Label7.Visible = False
        Me.Label7.Width = 0.5999014!
        '
        'Label11
        '
        Me.Label11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label11.Height = 0.3574803!
        Me.Label11.HyperLink = Nothing
        Me.Label11.Left = 1.512303!
        Me.Label11.Name = "Label11"
        Me.Label11.Style = "ddo-char-set: 1; text-align: center; font-weight: bold; vertical-align: middle"
        Me.Label11.Text = "Descripción"
        Me.Label11.Top = 1.068898!
        Me.Label11.Width = 3.749697!
        '
        'Label12
        '
        Me.Label12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label12.Height = 0.3574803!
        Me.Label12.HyperLink = Nothing
        Me.Label12.Left = 5.26181!
        Me.Label12.Name = "Label12"
        Me.Label12.Style = "ddo-char-set: 1; text-align: center; font-weight: bold; vertical-align: middle"
        Me.Label12.Text = "Cantidad"
        Me.Label12.Top = 1.068898!
        Me.Label12.Width = 0.7229334!
        '
        'Label13
        '
        Me.Label13.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label13.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label13.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label13.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label13.Height = 0.3574803!
        Me.Label13.HyperLink = Nothing
        Me.Label13.Left = 0.125!
        Me.Label13.Name = "Label13"
        Me.Label13.Style = "ddo-char-set: 1; text-align: center; font-weight: bold; vertical-align: middle"
        Me.Label13.Text = "Articulo"
        Me.Label13.Top = 1.068898!
        Me.Label13.Width = 1.387303!
        '
        'txtResponsable
        '
        Me.txtResponsable.Height = 0.2!
        Me.txtResponsable.Left = 1.089075!
        Me.txtResponsable.Name = "txtResponsable"
        Me.txtResponsable.Text = Nothing
        Me.txtResponsable.Top = 0.784941!
        Me.txtResponsable.Width = 2.394685!
        '
        'Label17
        '
        Me.Label17.Height = 0.2!
        Me.Label17.HyperLink = Nothing
        Me.Label17.Left = 3.6875!
        Me.Label17.Name = "Label17"
        Me.Label17.Style = "ddo-char-set: 1; font-weight: bold"
        Me.Label17.Text = "Tipo Movto:"
        Me.Label17.Top = 0.784941!
        Me.Label17.Width = 0.8612201!
        '
        'txtTipoMovto
        '
        Me.txtTipoMovto.Height = 0.2!
        Me.txtTipoMovto.Left = 4.499508!
        Me.txtTipoMovto.Name = "txtTipoMovto"
        Me.txtTipoMovto.Text = Nothing
        Me.txtTipoMovto.Top = 0.784941!
        Me.txtTipoMovto.Width = 2.519685!
        '
        'Label18
        '
        Me.Label18.Height = 0.2!
        Me.Label18.HyperLink = Nothing
        Me.Label18.Left = 3.6875!
        Me.Label18.Name = "Label18"
        Me.Label18.Style = "ddo-char-set: 1; font-weight: bold"
        Me.Label18.Text = "Origen:"
        Me.Label18.Top = 0.3380906!
        Me.Label18.Width = 0.7217847!
        '
        'txtOrigen
        '
        Me.txtOrigen.Height = 0.2!
        Me.txtOrigen.Left = 4.437008!
        Me.txtOrigen.Name = "txtOrigen"
        Me.txtOrigen.Text = Nothing
        Me.txtOrigen.Top = 0.3380906!
        Me.txtOrigen.Width = 0.4015745!
        '
        'txtOrigenDes
        '
        Me.txtOrigenDes.Height = 0.2!
        Me.txtOrigenDes.Left = 4.874508!
        Me.txtOrigenDes.Name = "txtOrigenDes"
        Me.txtOrigenDes.Text = Nothing
        Me.txtOrigenDes.Top = 0.3380906!
        Me.txtOrigenDes.Width = 2.151574!
        '
        'Label19
        '
        Me.Label19.Height = 0.2!
        Me.Label19.HyperLink = Nothing
        Me.Label19.Left = 3.6875!
        Me.Label19.Name = "Label19"
        Me.Label19.Style = "ddo-char-set: 1; font-weight: bold"
        Me.Label19.Text = "Destino:"
        Me.Label19.Top = 0.534941!
        Me.Label19.Width = 0.7217847!
        '
        'txtDestino
        '
        Me.txtDestino.Height = 0.2!
        Me.txtDestino.Left = 4.437008!
        Me.txtDestino.Name = "txtDestino"
        Me.txtDestino.Text = Nothing
        Me.txtDestino.Top = 0.534941!
        Me.txtDestino.Width = 0.4015745!
        '
        'txtDestinoDes
        '
        Me.txtDestinoDes.Height = 0.2!
        Me.txtDestinoDes.Left = 4.874508!
        Me.txtDestinoDes.Name = "txtDestinoDes"
        Me.txtDestinoDes.Text = Nothing
        Me.txtDestinoDes.Top = 0.534941!
        Me.txtDestinoDes.Width = 2.151574!
        '
        'Label20
        '
        Me.Label20.Height = 0.2!
        Me.Label20.HyperLink = Nothing
        Me.Label20.Left = 0.125!
        Me.Label20.Name = "Label20"
        Me.Label20.Style = "ddo-char-set: 1; font-weight: bold"
        Me.Label20.Text = "Folio Traslado:"
        Me.Label20.Top = 0.534941!
        Me.Label20.Width = 1.04872!
        '
        'txtFolioTraslado
        '
        Me.txtFolioTraslado.Height = 0.2!
        Me.txtFolioTraslado.Left = 1.187008!
        Me.txtFolioTraslado.Name = "txtFolioTraslado"
        Me.txtFolioTraslado.Text = Nothing
        Me.txtFolioTraslado.Top = 0.534941!
        Me.txtFolioTraslado.Width = 2.269685!
        '
        'Label3
        '
        Me.Label3.Height = 0.2!
        Me.Label3.HyperLink = Nothing
        Me.Label3.Left = 5.47441!
        Me.Label3.Name = "Label3"
        Me.Label3.Style = "ddo-char-set: 1; font-weight: bold"
        Me.Label3.Text = "Fecha:"
        Me.Label3.Top = 0.02559057!
        Me.Label3.Width = 0.6299215!
        '
        'txtFechaReporte
        '
        Me.txtFechaReporte.Height = 0.2!
        Me.txtFechaReporte.Left = 6.104331!
        Me.txtFechaReporte.Name = "txtFechaReporte"
        Me.txtFechaReporte.Text = Nothing
        Me.txtFechaReporte.Top = 0.02559057!
        Me.txtFechaReporte.Width = 0.9571854!
        '
        'Label22
        '
        Me.Label22.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label22.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label22.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label22.Height = 0.3582677!
        Me.Label22.HyperLink = Nothing
        Me.Label22.Left = 5.988189!
        Me.Label22.Name = "Label22"
        Me.Label22.Style = "ddo-char-set: 1; text-align: center; font-weight: bold; vertical-align: middle"
        Me.Label22.Text = "Folio Ajuste "
        Me.Label22.Top = 1.068898!
        Me.Label22.Width = 1.062992!
        '
        'ReportFooter
        '
        Me.ReportFooter.Height = 0.07222223!
        Me.ReportFooter.Name = "ReportFooter"
        '
        'PageHeader
        '
        Me.PageHeader.Height = 0.0!
        Me.PageHeader.Name = "PageHeader"
        '
        'PageFooter
        '
        Me.PageFooter.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label14, Me.tbPageNumber, Me.Label15, Me.tbPageCount, Me.Label21})
        Me.PageFooter.Height = 0.28125!
        Me.PageFooter.Name = "PageFooter"
        '
        'Label14
        '
        Me.Label14.Height = 0.2!
        Me.Label14.HyperLink = Nothing
        Me.Label14.Left = 5.125!
        Me.Label14.Name = "Label14"
        Me.Label14.Style = "ddo-char-set: 1; font-size: 8pt; vertical-align: middle"
        Me.Label14.Text = "Página"
        Me.Label14.Top = 0.0625!
        Me.Label14.Width = 0.5078735!
        '
        'tbPageNumber
        '
        Me.tbPageNumber.Height = 0.2!
        Me.tbPageNumber.Left = 5.679626!
        Me.tbPageNumber.Name = "tbPageNumber"
        Me.tbPageNumber.Style = "ddo-char-set: 1; text-align: center; font-size: 8pt; vertical-align: middle"
        Me.tbPageNumber.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
        Me.tbPageNumber.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount
        Me.tbPageNumber.Text = "####"
        Me.tbPageNumber.Top = 0.0625!
        Me.tbPageNumber.Width = 0.492126!
        '
        'Label15
        '
        Me.Label15.Height = 0.2!
        Me.Label15.HyperLink = Nothing
        Me.Label15.Left = 6.17175!
        Me.Label15.Name = "Label15"
        Me.Label15.Style = "ddo-char-set: 1; text-align: center; font-size: 8pt; vertical-align: middle"
        Me.Label15.Text = "de"
        Me.Label15.Top = 0.0625!
        Me.Label15.Width = 0.2952757!
        '
        'tbPageCount
        '
        Me.tbPageCount.Height = 0.2!
        Me.tbPageCount.Left = 6.529528!
        Me.tbPageCount.Name = "tbPageCount"
        Me.tbPageCount.Style = "ddo-char-set: 1; text-align: center; font-size: 8pt; vertical-align: middle"
        Me.tbPageCount.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount
        Me.tbPageCount.Text = "####"
        Me.tbPageCount.Top = 0.0625!
        Me.tbPageCount.Width = 0.492126!
        '
        'Label21
        '
        Me.Label21.Height = 0.2!
        Me.Label21.HyperLink = Nothing
        Me.Label21.Left = 0.1875!
        Me.Label21.Name = "Label21"
        Me.Label21.Style = "ddo-char-set: 1; font-size: 8pt; vertical-align: middle"
        Me.Label21.Text = "Comercial D´Portenis SA de CV"
        Me.Label21.Top = 0.0625!
        Me.Label21.Width = 3.570374!
        '
        'GroupHeader1
        '
        Me.GroupHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TextBox8, Me.TextBox7})
        Me.GroupHeader1.DataField = "Tipo"
        Me.GroupHeader1.Height = 0.2388889!
        Me.GroupHeader1.Name = "GroupHeader1"
        '
        'TextBox8
        '
        Me.TextBox8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox8.Height = 0.1653543!
        Me.TextBox8.Left = 0.125!
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.Style = "text-align: center; font-weight: normal; font-size: 8.25pt; vertical-align: top"
        Me.TextBox8.Text = Nothing
        Me.TextBox8.Top = 0.0625!
        Me.TextBox8.Width = 6.92126!
        '
        'TextBox7
        '
        Me.TextBox7.DataField = "Tipo"
        Me.TextBox7.Height = 0.1653543!
        Me.TextBox7.Left = 0.07874014!
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.Style = "text-align: center; font-weight: normal; font-size: 8.25pt; vertical-align: top"
        Me.TextBox7.Text = Nothing
        Me.TextBox7.Top = 0.0!
        Me.TextBox7.Width = 1.387303!
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Height = 0.0!
        Me.GroupFooter1.Name = "GroupFooter1"
        '
        'rptArtNoLecturados
        '
        Me.MasterReport = False
        Me.PageSettings.Margins.Bottom = 0.39375!
        Me.PageSettings.Margins.Left = 0.39375!
        Me.PageSettings.Margins.Right = 0.39375!
        Me.PageSettings.Margins.Top = 0.39375!
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 7.083333!
        Me.Sections.Add(Me.ReportHeader)
        Me.Sections.Add(Me.PageHeader)
        Me.Sections.Add(Me.GroupHeader1)
        Me.Sections.Add(Me.Detail)
        Me.Sections.Add(Me.GroupFooter1)
        Me.Sections.Add(Me.PageFooter)
        Me.Sections.Add(Me.ReportFooter)
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" & _
            "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei" & _
            "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" & _
            "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit", "Heading3", "Normal"))
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSucursal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtResponsable, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTipoMovto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtOrigen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtOrigenDes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label19, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDestino, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDestinoDes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label20, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFolioTraslado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaReporte, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label22, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbPageNumber, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbPageCount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label21, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

#End Region

    Private Sub Detail_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles Detail.Format
        If Me.TextBox6.Value < 0 Then
            Me.TextBox6.Text = CStr(Me.TextBox6.Value * -1)
        Else
            Me.TextBox9.Text = ""
        End If



    End Sub
End Class
