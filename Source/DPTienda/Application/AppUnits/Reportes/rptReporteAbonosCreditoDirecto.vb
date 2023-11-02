Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Imports DportenisPro.DPTienda.ApplicationUnits.AbonoCreditoDirectoTienda

Public Class rptReporteAbonosCreditoDirecto
Inherits DataDynamics.ActiveReports.ActiveReport
    Public Sub New(ByVal Fecha As DateTime, ByVal strAlmacen As String)
        MyBase.New()
        InitializeComponent()
        Me.txtFecha.Text = Fecha.ToShortDateString
        Me.txtAlmacen.Text = strAlmacen
        Dim dsAbonos As DataSet
        Dim oAbonoCreditoDirectoMgr As New AbonoCreditoDirectoManager(oAppContext)
        dsAbonos = oAbonoCreditoDirectoMgr.AbonosCreditoDirectoSelByDate(Fecha)

        Me.DataSource = dsAbonos
        Me.DataMember = "AbonosCreditoDirecto"

    End Sub
#Region "ActiveReports Designer generated code"
    Private WithEvents ReportHeader As ReportHeader = Nothing
    Private WithEvents GroupHeader1 As GroupHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents GroupFooter1 As GroupFooter = Nothing
    Private WithEvents ReportFooter As ReportFooter = Nothing
	Private Shape1 As Shape = Nothing
	Private Label1 As Label = Nothing
	Private Label2 As Label = Nothing
	Private txtFecha As TextBox = Nothing
	Private Label3 As Label = Nothing
	Private txtAlmacen As TextBox = Nothing
	Private Label4 As Label = Nothing
	Private Label7 As Label = Nothing
	Private Line1 As Line = Nothing
	Private Label15 As Label = Nothing
	Private Label16 As Label = Nothing
	Private Label18 As Label = Nothing
	Private txtFolioAbono As TextBox = Nothing
	Private txtCodCaja As TextBox = Nothing
	Private txtAbono As TextBox = Nothing
	Private Label6 As Label = Nothing
	Private Label13 As Label = Nothing
	Private Label14 As Label = Nothing
	Private Label10 As Label = Nothing
	Private Label11 As Label = Nothing
	Private txtClienteID As TextBox = Nothing
	Private txtNombre As TextBox = Nothing
	Private Label17 As Label = Nothing
	Private Label19 As Label = Nothing
	Private SubReport1 As SubReport = Nothing
	Private SubReport2 As SubReport = Nothing
	Private Shape2 As Shape = Nothing
	Private txtSAbono As TextBox = Nothing
	Private Label12 As Label = Nothing
	Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptReporteAbonosCreditoDirecto))
            Me.Detail = New DataDynamics.ActiveReports.Detail()
            Me.ReportHeader = New DataDynamics.ActiveReports.ReportHeader()
            Me.ReportFooter = New DataDynamics.ActiveReports.ReportFooter()
            Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader()
            Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter()
            Me.Shape1 = New DataDynamics.ActiveReports.Shape()
            Me.Label1 = New DataDynamics.ActiveReports.Label()
            Me.Label2 = New DataDynamics.ActiveReports.Label()
            Me.txtFecha = New DataDynamics.ActiveReports.TextBox()
            Me.Label3 = New DataDynamics.ActiveReports.Label()
            Me.txtAlmacen = New DataDynamics.ActiveReports.TextBox()
            Me.Label4 = New DataDynamics.ActiveReports.Label()
            Me.Label7 = New DataDynamics.ActiveReports.Label()
            Me.Line1 = New DataDynamics.ActiveReports.Line()
            Me.Label15 = New DataDynamics.ActiveReports.Label()
            Me.Label16 = New DataDynamics.ActiveReports.Label()
            Me.Label18 = New DataDynamics.ActiveReports.Label()
            Me.txtFolioAbono = New DataDynamics.ActiveReports.TextBox()
            Me.txtCodCaja = New DataDynamics.ActiveReports.TextBox()
            Me.txtAbono = New DataDynamics.ActiveReports.TextBox()
            Me.Label6 = New DataDynamics.ActiveReports.Label()
            Me.Label13 = New DataDynamics.ActiveReports.Label()
            Me.Label14 = New DataDynamics.ActiveReports.Label()
            Me.Label10 = New DataDynamics.ActiveReports.Label()
            Me.Label11 = New DataDynamics.ActiveReports.Label()
            Me.txtClienteID = New DataDynamics.ActiveReports.TextBox()
            Me.txtNombre = New DataDynamics.ActiveReports.TextBox()
            Me.Label17 = New DataDynamics.ActiveReports.Label()
            Me.Label19 = New DataDynamics.ActiveReports.Label()
            Me.SubReport1 = New DataDynamics.ActiveReports.SubReport()
            Me.SubReport2 = New DataDynamics.ActiveReports.SubReport()
            Me.Shape2 = New DataDynamics.ActiveReports.Shape()
            Me.txtSAbono = New DataDynamics.ActiveReports.TextBox()
            Me.Label12 = New DataDynamics.ActiveReports.Label()
            CType(Me.Label1,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFecha,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label3,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtAlmacen,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label7,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label15,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label16,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label18,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFolioAbono,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtCodCaja,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtAbono,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label6,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label13,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label14,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label10,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label11,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtClienteID,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtNombre,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label17,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label19,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtSAbono,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label12,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
            '
            'Detail
            '
            Me.Detail.ColumnSpacing = 0!
            Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.SubReport1, Me.SubReport2})
            Me.Detail.Height = 0.1451389!
            Me.Detail.Name = "Detail"
            '
            'ReportHeader
            '
            Me.ReportHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape1, Me.Label1, Me.Label2, Me.txtFecha, Me.Label3, Me.txtAlmacen, Me.Label4, Me.Label7, Me.Line1, Me.Label15, Me.Label16, Me.Label18})
            Me.ReportHeader.Height = 1.072222!
            Me.ReportHeader.Name = "ReportHeader"
            '
            'ReportFooter
            '
            Me.ReportFooter.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape2, Me.txtSAbono, Me.Label12})
            Me.ReportFooter.Height = 0.3333333!
            Me.ReportFooter.Name = "ReportFooter"
            '
            'GroupHeader1
            '
            Me.GroupHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtFolioAbono, Me.txtCodCaja, Me.txtAbono, Me.Label6, Me.Label13, Me.Label14, Me.Label10, Me.Label11, Me.txtClienteID, Me.txtNombre, Me.Label17, Me.Label19})
            Me.GroupHeader1.DataField = "AbonoID"
            Me.GroupHeader1.Height = 0.3333333!
            Me.GroupHeader1.Name = "GroupHeader1"
            '
            'GroupFooter1
            '
            Me.GroupFooter1.Height = 0!
            Me.GroupFooter1.Name = "GroupFooter1"
            '
            'Shape1
            '
            Me.Shape1.Height = 1.0625!
            Me.Shape1.Left = 0!
            Me.Shape1.Name = "Shape1"
            Me.Shape1.RoundingRadius = 9.999999!
            Me.Shape1.Top = 0!
            Me.Shape1.Width = 6.5!
            '
            'Label1
            '
            Me.Label1.Height = 0.2!
            Me.Label1.HyperLink = Nothing
            Me.Label1.Left = 0.0625!
            Me.Label1.Name = "Label1"
            Me.Label1.Style = "font-weight: bold; font-size: 8.25pt"
            Me.Label1.Text = "Fecha:"
            Me.Label1.Top = 0.0625!
            Me.Label1.Width = 0.4375!
            '
            'Label2
            '
            Me.Label2.Height = 0.2!
            Me.Label2.HyperLink = Nothing
            Me.Label2.Left = 2!
            Me.Label2.Name = "Label2"
            Me.Label2.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
            Me.Label2.Text = "Abonos Credito Directo"
            Me.Label2.Top = 0.0625!
            Me.Label2.Width = 2!
            '
            'txtFecha
            '
            Me.txtFecha.Height = 0.2!
            Me.txtFecha.Left = 0.5!
            Me.txtFecha.Name = "txtFecha"
            Me.txtFecha.Style = "font-size: 8.25pt"
            Me.txtFecha.Text = "TextBox1"
            Me.txtFecha.Top = 0.0625!
            Me.txtFecha.Width = 1!
            '
            'Label3
            '
            Me.Label3.Height = 0.2!
            Me.Label3.HyperLink = Nothing
            Me.Label3.Left = 1.6875!
            Me.Label3.Name = "Label3"
            Me.Label3.Style = "font-weight: bold; font-size: 8.25pt"
            Me.Label3.Text = "Almacen.-"
            Me.Label3.Top = 0.4375!
            Me.Label3.Width = 0.625!
            '
            'txtAlmacen
            '
            Me.txtAlmacen.Height = 0.2!
            Me.txtAlmacen.Left = 2.3125!
            Me.txtAlmacen.Name = "txtAlmacen"
            Me.txtAlmacen.Style = "font-size: 8.25pt"
            Me.txtAlmacen.Text = "TextBox1"
            Me.txtAlmacen.Top = 0.4375!
            Me.txtAlmacen.Width = 2!
            '
            'Label4
            '
            Me.Label4.Height = 0.2!
            Me.Label4.HyperLink = Nothing
            Me.Label4.Left = 1.5!
            Me.Label4.Name = "Label4"
            Me.Label4.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
            Me.Label4.Text = "Importe Total"
            Me.Label4.Top = 0.8125!
            Me.Label4.Width = 1!
            '
            'Label7
            '
            Me.Label7.Height = 0.2!
            Me.Label7.HyperLink = Nothing
            Me.Label7.Left = 0.0625!
            Me.Label7.Name = "Label7"
            Me.Label7.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
            Me.Label7.Text = "Folio Abono"
            Me.Label7.Top = 0.8125!
            Me.Label7.Width = 0.75!
            '
            'Line1
            '
            Me.Line1.Height = 0!
            Me.Line1.Left = 0!
            Me.Line1.LineWeight = 1!
            Me.Line1.Name = "Line1"
            Me.Line1.Top = 0.75!
            Me.Line1.Width = 6.5!
            Me.Line1.X1 = 6.5!
            Me.Line1.X2 = 0!
            Me.Line1.Y1 = 0.75!
            Me.Line1.Y2 = 0.75!
            '
            'Label15
            '
            Me.Label15.Height = 0.2!
            Me.Label15.HyperLink = Nothing
            Me.Label15.Left = 2.625!
            Me.Label15.Name = "Label15"
            Me.Label15.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
            Me.Label15.Text = "Folio Cliente"
            Me.Label15.Top = 0.8125!
            Me.Label15.Width = 1!
            '
            'Label16
            '
            Me.Label16.Height = 0.2!
            Me.Label16.HyperLink = Nothing
            Me.Label16.Left = 3.75!
            Me.Label16.Name = "Label16"
            Me.Label16.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
            Me.Label16.Text = "Nombre"
            Me.Label16.Top = 0.8125!
            Me.Label16.Width = 2.5625!
            '
            'Label18
            '
            Me.Label18.Height = 0.2!
            Me.Label18.HyperLink = Nothing
            Me.Label18.Left = 0.875!
            Me.Label18.Name = "Label18"
            Me.Label18.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
            Me.Label18.Text = "Cod. Caja"
            Me.Label18.Top = 0.8125!
            Me.Label18.Width = 0.5625!
            '
            'txtFolioAbono
            '
            Me.txtFolioAbono.DataField = "AbonoID"
            Me.txtFolioAbono.Height = 0.125!
            Me.txtFolioAbono.Left = 0.0625!
            Me.txtFolioAbono.Name = "txtFolioAbono"
            Me.txtFolioAbono.Style = "text-align: right; font-size: 8.25pt"
            Me.txtFolioAbono.Text = "FolioAbono"
            Me.txtFolioAbono.Top = 0!
            Me.txtFolioAbono.Width = 0.6875!
            '
            'txtCodCaja
            '
            Me.txtCodCaja.DataField = "CodCaja"
            Me.txtCodCaja.Height = 0.125!
            Me.txtCodCaja.Left = 0.875!
            Me.txtCodCaja.Name = "txtCodCaja"
            Me.txtCodCaja.Style = "text-align: center; font-size: 8.25pt"
            Me.txtCodCaja.Text = "CodCaja"
            Me.txtCodCaja.Top = 0!
            Me.txtCodCaja.Width = 0.5!
            '
            'txtAbono
            '
            Me.txtAbono.DataField = "Monto"
            Me.txtAbono.Height = 0.125!
            Me.txtAbono.Left = 1.5!
            Me.txtAbono.Name = "txtAbono"
            Me.txtAbono.OutputFormat = resources.GetString("txtAbono.OutputFormat")
            Me.txtAbono.Style = "text-align: right; font-size: 8.25pt"
            Me.txtAbono.Text = "TextBox4"
            Me.txtAbono.Top = 0!
            Me.txtAbono.Width = 1!
            '
            'Label6
            '
            Me.Label6.Height = 0.125!
            Me.Label6.HyperLink = Nothing
            Me.Label6.Left = 0.5625!
            Me.Label6.Name = "Label6"
            Me.Label6.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
            Me.Label6.Text = "Factura DP"
            Me.Label6.Top = 0.1875!
            Me.Label6.Width = 0.6875!
            '
            'Label13
            '
            Me.Label13.Height = 0.125!
            Me.Label13.HyperLink = Nothing
            Me.Label13.Left = 2.75!
            Me.Label13.Name = "Label13"
            Me.Label13.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
            Me.Label13.Text = "Abono / F."
            Me.Label13.Top = 0.1875!
            Me.Label13.Width = 0.875!
            '
            'Label14
            '
            Me.Label14.Height = 0.125!
            Me.Label14.HyperLink = Nothing
            Me.Label14.Left = 3.625!
            Me.Label14.Name = "Label14"
            Me.Label14.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
            Me.Label14.Text = "Saldo"
            Me.Label14.Top = 0.1875!
            Me.Label14.Width = 0.6875!
            '
            'Label10
            '
            Me.Label10.Height = 0.125!
            Me.Label10.HyperLink = Nothing
            Me.Label10.Left = 4.4375!
            Me.Label10.Name = "Label10"
            Me.Label10.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
            Me.Label10.Text = "Formas de Pago"
            Me.Label10.Top = 0.1875!
            Me.Label10.Width = 0.9375!
            '
            'Label11
            '
            Me.Label11.Height = 0.125!
            Me.Label11.HyperLink = Nothing
            Me.Label11.Left = 5.4375!
            Me.Label11.Name = "Label11"
            Me.Label11.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
            Me.Label11.Text = "Monto"
            Me.Label11.Top = 0.1875!
            Me.Label11.Width = 0.875!
            '
            'txtClienteID
            '
            Me.txtClienteID.DataField = "ClienteID"
            Me.txtClienteID.Height = 0.125!
            Me.txtClienteID.Left = 2.625!
            Me.txtClienteID.Name = "txtClienteID"
            Me.txtClienteID.OutputFormat = resources.GetString("txtClienteID.OutputFormat")
            Me.txtClienteID.Style = "text-align: right; font-size: 8.25pt"
            Me.txtClienteID.Text = "TextBox4"
            Me.txtClienteID.Top = 0!
            Me.txtClienteID.Width = 1!
            '
            'txtNombre
            '
            Me.txtNombre.DataField = "NombreCliente"
            Me.txtNombre.Height = 0.125!
            Me.txtNombre.Left = 3.8125!
            Me.txtNombre.Name = "txtNombre"
            Me.txtNombre.OutputFormat = resources.GetString("txtNombre.OutputFormat")
            Me.txtNombre.Style = "text-align: right; font-size: 8.25pt"
            Me.txtNombre.Text = "TextBox4"
            Me.txtNombre.Top = 0!
            Me.txtNombre.Width = 2.5!
            '
            'Label17
            '
            Me.Label17.Height = 0.125!
            Me.Label17.HyperLink = Nothing
            Me.Label17.Left = 2!
            Me.Label17.Name = "Label17"
            Me.Label17.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
            Me.Label17.Text = "Folio FI"
            Me.Label17.Top = 0.1875!
            Me.Label17.Width = 0.6875!
            '
            'Label19
            '
            Me.Label19.Height = 0.125!
            Me.Label19.HyperLink = Nothing
            Me.Label19.Left = 1.25!
            Me.Label19.Name = "Label19"
            Me.Label19.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
            Me.Label19.Text = "Folio SAP"
            Me.Label19.Top = 0.1875!
            Me.Label19.Width = 0.6875!
            '
            'SubReport1
            '
            Me.SubReport1.CloseBorder = false
            Me.SubReport1.Height = 0.1259842!
            Me.SubReport1.Left = 0.5!
            Me.SubReport1.Name = "SubReport1"
            Me.SubReport1.Report = Nothing
            Me.SubReport1.Top = 0!
            Me.SubReport1.Width = 3.937008!
            '
            'SubReport2
            '
            Me.SubReport2.CloseBorder = false
            Me.SubReport2.Height = 0.125!
            Me.SubReport2.Left = 4.4375!
            Me.SubReport2.Name = "SubReport2"
            Me.SubReport2.Report = Nothing
            Me.SubReport2.Top = 0!
            Me.SubReport2.Width = 1.885417!
            '
            'Shape2
            '
            Me.Shape2.Height = 0.3125!
            Me.Shape2.Left = 0!
            Me.Shape2.Name = "Shape2"
            Me.Shape2.RoundingRadius = 9.999999!
            Me.Shape2.Top = 0!
            Me.Shape2.Width = 6.5!
            '
            'txtSAbono
            '
            Me.txtSAbono.DataField = "Monto"
            Me.txtSAbono.Height = 0.125!
            Me.txtSAbono.Left = 1.5!
            Me.txtSAbono.Name = "txtSAbono"
            Me.txtSAbono.OutputFormat = resources.GetString("txtSAbono.OutputFormat")
            Me.txtSAbono.Style = "text-align: right; font-size: 8.25pt"
            Me.txtSAbono.SummaryGroup = "GroupHeader1"
            Me.txtSAbono.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
            Me.txtSAbono.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
            Me.txtSAbono.Text = "TextBox2"
            Me.txtSAbono.Top = 0.0625!
            Me.txtSAbono.Width = 1!
            '
            'Label12
            '
            Me.Label12.Height = 0.125!
            Me.Label12.HyperLink = Nothing
            Me.Label12.Left = 0.0625!
            Me.Label12.Name = "Label12"
            Me.Label12.Style = "font-weight: bold; font-size: 8.25pt"
            Me.Label12.Text = "Total Abonos.-"
            Me.Label12.Top = 0.0625!
            Me.Label12.Width = 1!
            '
            'ActiveReport1
            '
            Me.MasterReport = false
            Me.PageSettings.PaperHeight = 11!
            Me.PageSettings.PaperWidth = 8.5!
            Me.PrintWidth = 6.541667!
            Me.Sections.Add(Me.ReportHeader)
            Me.Sections.Add(Me.GroupHeader1)
            Me.Sections.Add(Me.Detail)
            Me.Sections.Add(Me.GroupFooter1)
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
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label7,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label15,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label16,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label18,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFolioAbono,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtCodCaja,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtAbono,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label6,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label13,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label14,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label10,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label11,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtClienteID,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtNombre,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label17,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label19,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtSAbono,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label12,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        
	End Sub

#End Region


    Dim Diferencia As Integer
    Dim TipoDiferencia As String
    Dim intContador As Integer



    Private Sub GroupHeader1_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupHeader1.Format
        Sm_ActionPrintReporteAbonosCxC(DirectCast(GroupHeader1.Controls("txtFolioAbono"), TextBox).Text)
        Dim oAbonoCreditoDirectoMgr As New AbonoCreditoDirectoManager(oAppContext)
        Dim dsFoliosGET As DataSet = oAbonoCreditoDirectoMgr.AbonosCreditoDirectoFoliosGET(DirectCast(GroupHeader1.Controls("txtFolioAbono"), TextBox).Text)
        If dsFoliosGET.Tables(0).Rows.Count > 0 Then
            Dim dsFoliosGETFB05 As DataSet = oAbonoCreditoDirectoMgr.AbonosCreditoDirectoFoliosGETFB05(dsFoliosGET.Tables(0).Rows(0).Item("FolioSAP"), dsFoliosGET.Tables(0).Rows(0).Item("FolioFactura"), dsFoliosGET.Tables(0).Rows(0).Item("MontoAbono"))
            If dsFoliosGETFB05.Tables(0).Rows.Count > 0 Then
                txtFolioAbono.Text = dsFoliosGETFB05.Tables(0).Rows(0).Item("DocnumFB05")
            End If
        End If
    End Sub

    Private Sub Sm_ActionPrintReporteAbonosCxC(ByVal AbonoID As Integer)

        Dim oARReporte As New rptAbonoCDTDetalle(AbonoID)
        SubReport1.Report = oARReporte
        SubReport1.Report.DataSource = oARReporte.DataSource
        SubReport1.Report.DataMember = oARReporte.DataMember

        Dim oARReporteFP As New rptAbonoCDTFormasPago(AbonoID)
        SubReport2.Report = oARReporteFP
        SubReport2.Report.DataSource = oARReporteFP.DataSource
        SubReport2.Report.DataMember = oARReporteFP.DataMember

    End Sub
End Class
