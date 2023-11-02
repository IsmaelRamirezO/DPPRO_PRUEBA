Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU

Public Class rptAbonosCancelados
    Inherits DataDynamics.ActiveReports.ActiveReport

    Public Sub New(ByVal dsDetalle As DataSet, ByVal FechaDe As DateTime, ByVal FechaAl As DateTime, ByVal caja As String)
        MyBase.New()
        InitializeComponent()
        Dim oAlmacen As Almacen
        Dim oAlmacenesMgr As New CatalogoAlmacenesManager(oAppContext)
        Dim oSAPMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        oAlmacen = oAlmacenesMgr.Load(oSAPMgr.Read_Centros) 'oAppContext.ApplicationConfiguration.Almacen)

        If Not oAlmacen Is Nothing Then

            Me.txtSucursal.Text = oAlmacen.ID & " " & oAlmacen.Descripcion

        Else

            Me.txtSucursal.Text = oAppContext.ApplicationConfiguration.Almacen

        End If

        Me.DataSource = dsDetalle
        Me.DataMember = dsDetalle.Tables(0).TableName

        Me.txtFecha.Text = Now.Date.ToShortDateString

        Me.txtFechaDel.Text = FechaDe.ToLongDateString
        Me.txtFechaAl.Text = FechaAl.ToLongDateString

        Me.txtCaja.Text = caja

        
    End Sub
#Region "ActiveReports Designer generated code"
    Private WithEvents PageHeader As PageHeader = Nothing
    Private WithEvents GroupHeader1 As GroupHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents GroupFooter1 As GroupFooter = Nothing
    Private WithEvents PageFooter As PageFooter = Nothing
	Private Shape1 As Shape = Nothing
	Private Label9 As Label = Nothing
	Private Label7 As Label = Nothing
	Private Label6 As Label = Nothing
	Private Label5 As Label = Nothing
	Private Label4 As Label = Nothing
	Private Label3 As Label = Nothing
	Private Label1 As Label = Nothing
	Private Label12 As Label = Nothing
	Private Label2 As Label = Nothing
	Private txtFechaDel As TextBox = Nothing
	Private Label13 As Label = Nothing
	Private txtSucursal As TextBox = Nothing
	Private Label14 As Label = Nothing
	Private txtFechaAl As TextBox = Nothing
	Private txtFecha As TextBox = Nothing
	Private txtCaja As TextBox = Nothing
	Private Line1 As Line = Nothing
	Private TextBox10 As TextBox = Nothing
	Private TextBox11 As TextBox = Nothing
	Private Label16 As Label = Nothing
	Private txtFolioAbono As TextBox = Nothing
	Private txtFolioApartado As TextBox = Nothing
	Private txtPlayer As TextBox = Nothing
	Private txtFormaPago As TextBox = Nothing
	Private txtImporte As TextBox = Nothing
	Private txtSaldo As TextBox = Nothing
	Private txtFechaAbono As TextBox = Nothing
	Private Line6 As Line = Nothing
	Private Line7 As Line = Nothing
	Private Shape2 As Shape = Nothing
	Private Label15 As Label = Nothing
	Private txtImporteGT As TextBox = Nothing
	Private txtSaldoGT As TextBox = Nothing
	Private Shape3 As Shape = Nothing
	Private Label10 As Label = Nothing
	Private txtImportePagina As TextBox = Nothing
	Private TextBox6 As TextBox = Nothing
	Private TextBox9 As TextBox = Nothing
	Private txtSaldoPagina As TextBox = Nothing
	Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptAbonosCancelados))
            Me.Detail = New DataDynamics.ActiveReports.Detail()
            Me.PageHeader = New DataDynamics.ActiveReports.PageHeader()
            Me.PageFooter = New DataDynamics.ActiveReports.PageFooter()
            Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader()
            Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter()
            Me.Shape1 = New DataDynamics.ActiveReports.Shape()
            Me.Label9 = New DataDynamics.ActiveReports.Label()
            Me.Label7 = New DataDynamics.ActiveReports.Label()
            Me.Label6 = New DataDynamics.ActiveReports.Label()
            Me.Label5 = New DataDynamics.ActiveReports.Label()
            Me.Label4 = New DataDynamics.ActiveReports.Label()
            Me.Label3 = New DataDynamics.ActiveReports.Label()
            Me.Label1 = New DataDynamics.ActiveReports.Label()
            Me.Label12 = New DataDynamics.ActiveReports.Label()
            Me.Label2 = New DataDynamics.ActiveReports.Label()
            Me.txtFechaDel = New DataDynamics.ActiveReports.TextBox()
            Me.Label13 = New DataDynamics.ActiveReports.Label()
            Me.txtSucursal = New DataDynamics.ActiveReports.TextBox()
            Me.Label14 = New DataDynamics.ActiveReports.Label()
            Me.txtFechaAl = New DataDynamics.ActiveReports.TextBox()
            Me.txtFecha = New DataDynamics.ActiveReports.TextBox()
            Me.txtCaja = New DataDynamics.ActiveReports.TextBox()
            Me.Line1 = New DataDynamics.ActiveReports.Line()
            Me.TextBox10 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox11 = New DataDynamics.ActiveReports.TextBox()
            Me.Label16 = New DataDynamics.ActiveReports.Label()
            Me.txtFolioAbono = New DataDynamics.ActiveReports.TextBox()
            Me.txtFolioApartado = New DataDynamics.ActiveReports.TextBox()
            Me.txtPlayer = New DataDynamics.ActiveReports.TextBox()
            Me.txtFormaPago = New DataDynamics.ActiveReports.TextBox()
            Me.txtImporte = New DataDynamics.ActiveReports.TextBox()
            Me.txtSaldo = New DataDynamics.ActiveReports.TextBox()
            Me.txtFechaAbono = New DataDynamics.ActiveReports.TextBox()
            Me.Line6 = New DataDynamics.ActiveReports.Line()
            Me.Line7 = New DataDynamics.ActiveReports.Line()
            Me.Shape2 = New DataDynamics.ActiveReports.Shape()
            Me.Label15 = New DataDynamics.ActiveReports.Label()
            Me.txtImporteGT = New DataDynamics.ActiveReports.TextBox()
            Me.txtSaldoGT = New DataDynamics.ActiveReports.TextBox()
            Me.Shape3 = New DataDynamics.ActiveReports.Shape()
            Me.Label10 = New DataDynamics.ActiveReports.Label()
            Me.txtImportePagina = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox6 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox9 = New DataDynamics.ActiveReports.TextBox()
            Me.txtSaldoPagina = New DataDynamics.ActiveReports.TextBox()
            CType(Me.Label9,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label7,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label6,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label5,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label3,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label1,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label12,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFechaDel,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label13,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtSucursal,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label14,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFechaAl,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFecha,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtCaja,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox10,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox11,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label16,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFolioAbono,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFolioApartado,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtPlayer,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFormaPago,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtImporte,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtSaldo,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFechaAbono,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label15,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtImporteGT,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtSaldoGT,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label10,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtImportePagina,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox6,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox9,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtSaldoPagina,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
            '
            'Detail
            '
            Me.Detail.ColumnSpacing = 0!
            Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtFolioAbono, Me.txtFolioApartado, Me.txtPlayer, Me.txtFormaPago, Me.txtImporte, Me.txtSaldo, Me.txtFechaAbono, Me.Line6, Me.Line7})
            Me.Detail.Height = 0.2076389!
            Me.Detail.Name = "Detail"
            '
            'PageHeader
            '
            Me.PageHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape1, Me.Label9, Me.Label7, Me.Label6, Me.Label5, Me.Label4, Me.Label3, Me.Label1, Me.Label12, Me.Label2, Me.txtFechaDel, Me.Label13, Me.txtSucursal, Me.Label14, Me.txtFechaAl, Me.txtFecha, Me.txtCaja, Me.Line1, Me.TextBox10, Me.TextBox11, Me.Label16})
            Me.PageHeader.Height = 1.022917!
            Me.PageHeader.Name = "PageHeader"
            '
            'PageFooter
            '
            Me.PageFooter.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape3, Me.Label10, Me.txtImportePagina, Me.TextBox6, Me.TextBox9, Me.txtSaldoPagina})
            Me.PageFooter.Height = 0.25!
            Me.PageFooter.Name = "PageFooter"
            '
            'GroupHeader1
            '
            Me.GroupHeader1.Height = 0!
            Me.GroupHeader1.Name = "GroupHeader1"
            '
            'GroupFooter1
            '
            Me.GroupFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape2, Me.Label15, Me.txtImporteGT, Me.txtSaldoGT})
            Me.GroupFooter1.Height = 0.25!
            Me.GroupFooter1.Name = "GroupFooter1"
            '
            'Shape1
            '
            Me.Shape1.Height = 1.023622!
            Me.Shape1.Left = 0!
            Me.Shape1.Name = "Shape1"
            Me.Shape1.RoundingRadius = 9.999999!
            Me.Shape1.Top = 0!
            Me.Shape1.Width = 6.771654!
            '
            'Label9
            '
            Me.Label9.Height = 0.2!
            Me.Label9.HyperLink = Nothing
            Me.Label9.Left = 3.040354!
            Me.Label9.Name = "Label9"
            Me.Label9.Style = "text-align: center; font-weight: normal; font-size: 8.25pt"
            Me.Label9.Text = "PLAYER"
            Me.Label9.Top = 0.7642716!
            Me.Label9.Width = 0.8125!
            '
            'Label7
            '
            Me.Label7.Height = 0.2!
            Me.Label7.HyperLink = Nothing
            Me.Label7.Left = 5.835629!
            Me.Label7.Name = "Label7"
            Me.Label7.Style = "text-align: center; font-weight: normal; font-size: 8.25pt"
            Me.Label7.Text = "SALDO"
            Me.Label7.Top = 0.7642716!
            Me.Label7.Width = 0.875!
            '
            'Label6
            '
            Me.Label6.Height = 0.2!
            Me.Label6.HyperLink = Nothing
            Me.Label6.Left = 1.898622!
            Me.Label6.Name = "Label6"
            Me.Label6.Style = "text-align: center; font-weight: normal; font-size: 8.25pt; vertical-align: top"
            Me.Label6.Text = "FOLIO APARTADO"
            Me.Label6.Top = 0.7642716!
            Me.Label6.Width = 1.05561!
            '
            'Label5
            '
            Me.Label5.Height = 0.2!
            Me.Label5.HyperLink = Nothing
            Me.Label5.Left = 4.969488!
            Me.Label5.Name = "Label5"
            Me.Label5.Style = "text-align: center; font-weight: normal; font-size: 8.25pt"
            Me.Label5.Text = "IMPORTE"
            Me.Label5.Top = 0.7642716!
            Me.Label5.Width = 0.8125!
            '
            'Label4
            '
            Me.Label4.Height = 0.2!
            Me.Label4.HyperLink = Nothing
            Me.Label4.Left = 3.906496!
            Me.Label4.Name = "Label4"
            Me.Label4.Style = "text-align: center; font-weight: normal; font-size: 8.25pt"
            Me.Label4.Text = "FORMA DE PAGO"
            Me.Label4.Top = 0.7642716!
            Me.Label4.Width = 1!
            '
            'Label3
            '
            Me.Label3.Height = 0.2!
            Me.Label3.HyperLink = Nothing
            Me.Label3.Left = 0.0625!
            Me.Label3.Name = "Label3"
            Me.Label3.Style = "text-align: center; font-weight: normal; font-size: 8.25pt"
            Me.Label3.Text = "FOLIO ABONO"
            Me.Label3.Top = 0.7642716!
            Me.Label3.Width = 0.8267716!
            '
            'Label1
            '
            Me.Label1.Height = 0.2!
            Me.Label1.HyperLink = Nothing
            Me.Label1.Left = 1.811024!
            Me.Label1.Name = "Label1"
            Me.Label1.Style = ""
            Me.Label1.Text = "REPORTE DE ABONOS Y ANTICIPOS CANCELADOS"
            Me.Label1.Top = 0.03937007!
            Me.Label1.Width = 3.582677!
            '
            'Label12
            '
            Me.Label12.Height = 0.2!
            Me.Label12.HyperLink = Nothing
            Me.Label12.Left = 0.07874014!
            Me.Label12.Name = "Label12"
            Me.Label12.Style = ""
            Me.Label12.Text = "Caja.:"
            Me.Label12.Top = 0.2755906!
            Me.Label12.Width = 0.4330709!
            '
            'Label2
            '
            Me.Label2.Height = 0.2!
            Me.Label2.HyperLink = Nothing
            Me.Label2.Left = 1.338583!
            Me.Label2.Name = "Label2"
            Me.Label2.Style = ""
            Me.Label2.Text = "De.:"
            Me.Label2.Top = 0.2755906!
            Me.Label2.Width = 0.2755904!
            '
            'txtFechaDel
            '
            Me.txtFechaDel.Height = 0.2!
            Me.txtFechaDel.Left = 1.653543!
            Me.txtFechaDel.Name = "txtFechaDel"
            Me.txtFechaDel.Top = 0.2755906!
            Me.txtFechaDel.Width = 2.204725!
            '
            'Label13
            '
            Me.Label13.Height = 0.2!
            Me.Label13.HyperLink = Nothing
            Me.Label13.Left = 1.338583!
            Me.Label13.Name = "Label13"
            Me.Label13.Style = ""
            Me.Label13.Text = "Sucursal.:"
            Me.Label13.Top = 0.511811!
            Me.Label13.Width = 0.6299212!
            '
            'txtSucursal
            '
            Me.txtSucursal.Height = 0.2!
            Me.txtSucursal.Left = 2.007874!
            Me.txtSucursal.Name = "txtSucursal"
            Me.txtSucursal.Top = 0.511811!
            Me.txtSucursal.Width = 2.755905!
            '
            'Label14
            '
            Me.Label14.Height = 0.2!
            Me.Label14.HyperLink = Nothing
            Me.Label14.Left = 3.865158!
            Me.Label14.Name = "Label14"
            Me.Label14.Style = ""
            Me.Label14.Text = "Al.:"
            Me.Label14.Top = 0.2755906!
            Me.Label14.Width = 0.2755904!
            '
            'txtFechaAl
            '
            Me.txtFechaAl.Height = 0.2!
            Me.txtFechaAl.Left = 4.180118!
            Me.txtFechaAl.Name = "txtFechaAl"
            Me.txtFechaAl.Top = 0.2755906!
            Me.txtFechaAl.Width = 2.047244!
            '
            'txtFecha
            '
            Me.txtFecha.Height = 0.2!
            Me.txtFecha.Left = 0.03937006!
            Me.txtFecha.Name = "txtFecha"
            Me.txtFecha.Top = 0.03937007!
            Me.txtFecha.Width = 1.338583!
            '
            'txtCaja
            '
            Me.txtCaja.Height = 0.2!
            Me.txtCaja.Left = 0.07874021!
            Me.txtCaja.Name = "txtCaja"
            Me.txtCaja.Top = 0.511811!
            Me.txtCaja.Width = 1.220472!
            '
            'Line1
            '
            Me.Line1.Height = 0!
            Me.Line1.Left = 0!
            Me.Line1.LineWeight = 1!
            Me.Line1.Name = "Line1"
            Me.Line1.Top = 0.7086611!
            Me.Line1.Width = 6.771654!
            Me.Line1.X1 = 6.771654!
            Me.Line1.X2 = 0!
            Me.Line1.Y1 = 0.7086611!
            Me.Line1.Y2 = 0.7086611!
            '
            'TextBox10
            '
            Me.TextBox10.Height = 0.2!
            Me.TextBox10.Left = 5.618602!
            Me.TextBox10.Name = "TextBox10"
            Me.TextBox10.Style = "font-size: 8.25pt"
            Me.TextBox10.Text = "Pág."
            Me.TextBox10.Top = 0.03937007!
            Me.TextBox10.Width = 0.2987203!
            '
            'TextBox11
            '
            Me.TextBox11.Height = 0.2!
            Me.TextBox11.Left = 5.931102!
            Me.TextBox11.Name = "TextBox11"
            Me.TextBox11.Style = "font-size: 8.25pt"
            Me.TextBox11.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
            Me.TextBox11.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount
            Me.TextBox11.Text = "100"
            Me.TextBox11.Top = 0.03937007!
            Me.TextBox11.Width = 0.2362203!
            '
            'Label16
            '
            Me.Label16.Height = 0.2!
            Me.Label16.HyperLink = Nothing
            Me.Label16.Left = 0.8986222!
            Me.Label16.Name = "Label16"
            Me.Label16.Style = "text-align: center; font-weight: normal; font-size: 8.25pt; vertical-align: top"
            Me.Label16.Text = "FECHA ABONO"
            Me.Label16.Top = 0.7642716!
            Me.Label16.Width = 1.05561!
            '
            'txtFolioAbono
            '
            Me.txtFolioAbono.DataField = "FolioAbono"
            Me.txtFolioAbono.Height = 0.2!
            Me.txtFolioAbono.Left = 0!
            Me.txtFolioAbono.Name = "txtFolioAbono"
            Me.txtFolioAbono.Style = "text-align: center; font-size: 9pt"
            Me.txtFolioAbono.Text = "TextBox5"
            Me.txtFolioAbono.Top = 0!
            Me.txtFolioAbono.Width = 0.7480313!
            '
            'txtFolioApartado
            '
            Me.txtFolioApartado.DataField = "ApartadoID"
            Me.txtFolioApartado.Height = 0.2!
            Me.txtFolioApartado.Left = 1.875!
            Me.txtFolioApartado.Name = "txtFolioApartado"
            Me.txtFolioApartado.Style = "text-align: center; font-size: 9pt"
            Me.txtFolioApartado.Text = "TextBox6"
            Me.txtFolioApartado.Top = 0!
            Me.txtFolioApartado.Width = 1!
            '
            'txtPlayer
            '
            Me.txtPlayer.DataField = "CodVendedor"
            Me.txtPlayer.Height = 0.2!
            Me.txtPlayer.Left = 2.875!
            Me.txtPlayer.Name = "txtPlayer"
            Me.txtPlayer.Style = "text-align: center; font-size: 9pt"
            Me.txtPlayer.Text = "TextBox7"
            Me.txtPlayer.Top = 0!
            Me.txtPlayer.Width = 1!
            '
            'txtFormaPago
            '
            Me.txtFormaPago.DataField = "CodFormaPago"
            Me.txtFormaPago.Height = 0.2!
            Me.txtFormaPago.Left = 3.875!
            Me.txtFormaPago.Name = "txtFormaPago"
            Me.txtFormaPago.Style = "text-align: center; font-size: 9pt"
            Me.txtFormaPago.Text = "TextBox8"
            Me.txtFormaPago.Top = 0!
            Me.txtFormaPago.Width = 1!
            '
            'txtImporte
            '
            Me.txtImporte.DataField = "Abono"
            Me.txtImporte.Height = 0.2!
            Me.txtImporte.Left = 4.875!
            Me.txtImporte.Name = "txtImporte"
            Me.txtImporte.OutputFormat = resources.GetString("txtImporte.OutputFormat")
            Me.txtImporte.Style = "text-align: right; font-size: 9pt"
            Me.txtImporte.Text = "0"
            Me.txtImporte.Top = 0!
            Me.txtImporte.Width = 0.8425201!
            '
            'txtSaldo
            '
            Me.txtSaldo.DataField = "SaldoNuevo"
            Me.txtSaldo.Height = 0.2!
            Me.txtSaldo.Left = 5.875!
            Me.txtSaldo.Name = "txtSaldo"
            Me.txtSaldo.OutputFormat = resources.GetString("txtSaldo.OutputFormat")
            Me.txtSaldo.Style = "text-align: right; font-size: 9pt"
            Me.txtSaldo.Text = "0"
            Me.txtSaldo.Top = 0!
            Me.txtSaldo.Width = 0.7874014!
            '
            'txtFechaAbono
            '
            Me.txtFechaAbono.DataField = "Fecha"
            Me.txtFechaAbono.Height = 0.2!
            Me.txtFechaAbono.Left = 0.8125!
            Me.txtFechaAbono.Name = "txtFechaAbono"
            Me.txtFechaAbono.OutputFormat = resources.GetString("txtFechaAbono.OutputFormat")
            Me.txtFechaAbono.Style = "text-align: center; font-size: 9pt"
            Me.txtFechaAbono.Text = "TextBox6"
            Me.txtFechaAbono.Top = 0!
            Me.txtFechaAbono.Width = 1!
            '
            'Line6
            '
            Me.Line6.Height = 0.1968504!
            Me.Line6.Left = 6.771654!
            Me.Line6.LineWeight = 1!
            Me.Line6.Name = "Line6"
            Me.Line6.Top = 0!
            Me.Line6.Width = 0!
            Me.Line6.X1 = 6.771654!
            Me.Line6.X2 = 6.771654!
            Me.Line6.Y1 = 0!
            Me.Line6.Y2 = 0.1968504!
            '
            'Line7
            '
            Me.Line7.Height = 0.1968504!
            Me.Line7.Left = 0.00694466!
            Me.Line7.LineWeight = 1!
            Me.Line7.Name = "Line7"
            Me.Line7.Top = 0!
            Me.Line7.Width = 0!
            Me.Line7.X1 = 0.00694466!
            Me.Line7.X2 = 0.00694466!
            Me.Line7.Y1 = 0!
            Me.Line7.Y2 = 0.1968504!
            '
            'Shape2
            '
            Me.Shape2.Height = 0.2362205!
            Me.Shape2.Left = 0!
            Me.Shape2.Name = "Shape2"
            Me.Shape2.RoundingRadius = 9.999999!
            Me.Shape2.Top = 0!
            Me.Shape2.Width = 6.771654!
            '
            'Label15
            '
            Me.Label15.Height = 0.2!
            Me.Label15.HyperLink = Nothing
            Me.Label15.Left = 0.0625!
            Me.Label15.Name = "Label15"
            Me.Label15.Style = "font-weight: bold; font-size: 8.25pt"
            Me.Label15.Text = "Total"
            Me.Label15.Top = 0!
            Me.Label15.Width = 1!
            '
            'txtImporteGT
            '
            Me.txtImporteGT.DataField = "Abono"
            Me.txtImporteGT.Height = 0.2!
            Me.txtImporteGT.Left = 4.885417!
            Me.txtImporteGT.Name = "txtImporteGT"
            Me.txtImporteGT.OutputFormat = resources.GetString("txtImporteGT.OutputFormat")
            Me.txtImporteGT.Style = "text-align: right; font-size: 8.25pt"
            Me.txtImporteGT.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
            Me.txtImporteGT.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
            Me.txtImporteGT.Text = "Tabono"
            Me.txtImporteGT.Top = 0!
            Me.txtImporteGT.Width = 0.8125!
            '
            'txtSaldoGT
            '
            Me.txtSaldoGT.DataField = "SaldoNuevo"
            Me.txtSaldoGT.Height = 0.2!
            Me.txtSaldoGT.Left = 5.947917!
            Me.txtSaldoGT.Name = "txtSaldoGT"
            Me.txtSaldoGT.OutputFormat = resources.GetString("txtSaldoGT.OutputFormat")
            Me.txtSaldoGT.Style = "text-align: right; font-size: 8.25pt"
            Me.txtSaldoGT.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
            Me.txtSaldoGT.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
            Me.txtSaldoGT.Text = "Tabono"
            Me.txtSaldoGT.Top = 0!
            Me.txtSaldoGT.Width = 0.7144854!
            '
            'Shape3
            '
            Me.Shape3.Height = 0.2362205!
            Me.Shape3.Left = 0!
            Me.Shape3.Name = "Shape3"
            Me.Shape3.RoundingRadius = 9.999999!
            Me.Shape3.Top = 0!
            Me.Shape3.Visible = false
            Me.Shape3.Width = 6.771654!
            '
            'Label10
            '
            Me.Label10.Height = 0.2!
            Me.Label10.HyperLink = Nothing
            Me.Label10.Left = 0.0625!
            Me.Label10.Name = "Label10"
            Me.Label10.Style = "font-weight: bold; font-size: 8.25pt"
            Me.Label10.Text = "Total Pág."
            Me.Label10.Top = 0!
            Me.Label10.Visible = false
            Me.Label10.Width = 1!
            '
            'txtImportePagina
            '
            Me.txtImportePagina.DataField = "Abono"
            Me.txtImportePagina.Height = 0.2!
            Me.txtImportePagina.Left = 4.812008!
            Me.txtImportePagina.Name = "txtImportePagina"
            Me.txtImportePagina.OutputFormat = resources.GetString("txtImportePagina.OutputFormat")
            Me.txtImportePagina.Style = "text-align: right; font-size: 8.25pt"
            Me.txtImportePagina.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
            Me.txtImportePagina.SummaryType = DataDynamics.ActiveReports.SummaryType.PageTotal
            Me.txtImportePagina.Text = "Tabono"
            Me.txtImportePagina.Top = 0!
            Me.txtImportePagina.Visible = false
            Me.txtImportePagina.Width = 0.8125!
            '
            'TextBox6
            '
            Me.TextBox6.Height = 0.2!
            Me.TextBox6.Left = 4.037401!
            Me.TextBox6.Name = "TextBox6"
            Me.TextBox6.Style = "font-size: 8.25pt"
            Me.TextBox6.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
            Me.TextBox6.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount
            Me.TextBox6.Text = "100"
            Me.TextBox6.Top = 0!
            Me.TextBox6.Visible = false
            Me.TextBox6.Width = 0.2362203!
            '
            'TextBox9
            '
            Me.TextBox9.Height = 0.2!
            Me.TextBox9.Left = 3.724901!
            Me.TextBox9.Name = "TextBox9"
            Me.TextBox9.Style = "font-size: 8.25pt"
            Me.TextBox9.Text = "Pág."
            Me.TextBox9.Top = 0!
            Me.TextBox9.Visible = false
            Me.TextBox9.Width = 0.2987203!
            '
            'txtSaldoPagina
            '
            Me.txtSaldoPagina.DataField = "SaldoNuevo"
            Me.txtSaldoPagina.Height = 0.2!
            Me.txtSaldoPagina.Left = 5.760417!
            Me.txtSaldoPagina.Name = "txtSaldoPagina"
            Me.txtSaldoPagina.OutputFormat = resources.GetString("txtSaldoPagina.OutputFormat")
            Me.txtSaldoPagina.Style = "text-align: right; font-size: 8.25pt"
            Me.txtSaldoPagina.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
            Me.txtSaldoPagina.SummaryType = DataDynamics.ActiveReports.SummaryType.PageTotal
            Me.txtSaldoPagina.Text = "Tabono"
            Me.txtSaldoPagina.Top = 0!
            Me.txtSaldoPagina.Visible = false
            Me.txtSaldoPagina.Width = 0.8125!
            '
            'ActiveReport1
            '
            Me.MasterReport = false
            Me.PageSettings.Margins.Left = 0.7875!
            Me.PageSettings.Margins.Right = 0.7875!
            Me.PageSettings.PaperHeight = 11!
            Me.PageSettings.PaperWidth = 8.5!
            Me.PrintWidth = 6.822917!
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
            CType(Me.Label9,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label7,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label6,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label5,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label3,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label1,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label12,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFechaDel,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label13,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtSucursal,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label14,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFechaAl,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFecha,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtCaja,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox10,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox11,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label16,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFolioAbono,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFolioApartado,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtPlayer,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFormaPago,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtImporte,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtSaldo,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFechaAbono,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label15,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtImporteGT,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtSaldoGT,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label10,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtImportePagina,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox6,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox9,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtSaldoPagina,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        
	End Sub

#End Region

   

End Class
