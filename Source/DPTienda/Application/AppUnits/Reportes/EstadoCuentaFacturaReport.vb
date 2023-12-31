Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Public Class EstadoCuentaFacturaReport

    Inherits DataDynamics.ActiveReports.ActiveReport


    Public Sub New(ByVal Data As DataSet, ByVal strNombreAsociado As String, ByVal decLimiteCredito As Decimal, Optional ByVal decSaldo As Decimal = 0, Optional ByVal decAbonos As Decimal = 0)

        MyBase.New()

        InitializeComponent()

        Dim oRow As DataRow
        oRow = Data.Tables(0).Rows(0)

        'Asignamos campos del encabezado
        Me.txtFolioFactura.Text = oRow!FolioDP
        Me.txtAsociadoID.Text = oRow!Cliente
        Me.txtNombreAsociado.Text = strNombreAsociado
        Me.txtPlazo.Text = CStr(DateDiff(DateInterval.Day, CDate(Format(oRow!Fecha, "short date")), DateAdd(DateInterval.Day, 30, oRow!Fecha))) & " dias"
        Me.txtFechaLimite.Text = Format(DateAdd(DateInterval.Day, 30, oRow!Fecha), "short date")
        Me.txtLimiteCredito.Text = Format(decLimiteCredito, "currency")
        Me.txtImporte.Text = Format(oRow!ComprasCargos, "currency")
        Me.txtSaldoActual.Text = Format(decSaldo, "currency")
        Me.txtAbonos.Text = Format(decAbonos, "currency")
        Me.DataSource = Data.Tables(0)
        Me.DataMember = Data.Tables(0).TableName

        Me.Run()

    End Sub


#Region "ActiveReports Designer generated code"
    Private WithEvents PageHeader As PageHeader = Nothing
    Private WithEvents GroupHeader1 As GroupHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents GroupFooter1 As GroupFooter = Nothing
    Private WithEvents PageFooter As PageFooter = Nothing
    Private Shape1 As Shape = Nothing
    Private Label1 As Label = Nothing
    Private lblFolio As Label = Nothing
    Private lblAsociado As Label = Nothing
    Private lblDiasPlazo As Label = Nothing
    Private lblFechaLimite As Label = Nothing
    Private lblLimiteCredito As Label = Nothing
    Private lblAbono As Label = Nothing
    Private lblSaldoActual As Label = Nothing
    Private txtFolioFactura As TextBox = Nothing
    Private txtAsociadoID As TextBox = Nothing
    Private txtNombreAsociado As TextBox = Nothing
    Private txtPlazo As TextBox = Nothing
    Private txtAbonos As TextBox = Nothing
    Private txtSaldoActual As TextBox = Nothing
    Private txtLimiteCredito As TextBox = Nothing
    Private txtFechaLimite As Label = Nothing
    Private hdFecha As Label = Nothing
    Private hdSucursal As Label = Nothing
    Private hdfolio As Label = Nothing
    Private hdDetalles As Label = Nothing
    Private hdCompras As Label = Nothing
    Private hdAbonos As Label = Nothing
    Private Line1 As Line = Nothing
    Private Line2 As Line = Nothing
    Private Line3 As Line = Nothing
    Private Line4 As Line = Nothing
    Private Line5 As Line = Nothing
    Private Line6 As Line = Nothing
    Private lblImporte As Label = Nothing
    Private txtImporte As TextBox = Nothing
    Private Fecha As TextBox = Nothing
    Private Sucursal As TextBox = Nothing
    Private FolioAbono As TextBox = Nothing
    Private Detalles As TextBox = Nothing
    Private TextBox3 As TextBox = Nothing
    Private TextBox4 As TextBox = Nothing
    Private Line7 As Line = Nothing
    Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EstadoCuentaFacturaReport))
            Me.Detail = New DataDynamics.ActiveReports.Detail()
            Me.PageHeader = New DataDynamics.ActiveReports.PageHeader()
            Me.PageFooter = New DataDynamics.ActiveReports.PageFooter()
            Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader()
            Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter()
            Me.Shape1 = New DataDynamics.ActiveReports.Shape()
            Me.Label1 = New DataDynamics.ActiveReports.Label()
            Me.lblFolio = New DataDynamics.ActiveReports.Label()
            Me.lblAsociado = New DataDynamics.ActiveReports.Label()
            Me.lblDiasPlazo = New DataDynamics.ActiveReports.Label()
            Me.lblFechaLimite = New DataDynamics.ActiveReports.Label()
            Me.lblLimiteCredito = New DataDynamics.ActiveReports.Label()
            Me.lblAbono = New DataDynamics.ActiveReports.Label()
            Me.lblSaldoActual = New DataDynamics.ActiveReports.Label()
            Me.txtFolioFactura = New DataDynamics.ActiveReports.TextBox()
            Me.txtAsociadoID = New DataDynamics.ActiveReports.TextBox()
            Me.txtNombreAsociado = New DataDynamics.ActiveReports.TextBox()
            Me.txtPlazo = New DataDynamics.ActiveReports.TextBox()
            Me.txtAbonos = New DataDynamics.ActiveReports.TextBox()
            Me.txtSaldoActual = New DataDynamics.ActiveReports.TextBox()
            Me.txtLimiteCredito = New DataDynamics.ActiveReports.TextBox()
            Me.txtFechaLimite = New DataDynamics.ActiveReports.Label()
            Me.hdFecha = New DataDynamics.ActiveReports.Label()
            Me.hdSucursal = New DataDynamics.ActiveReports.Label()
            Me.hdfolio = New DataDynamics.ActiveReports.Label()
            Me.hdDetalles = New DataDynamics.ActiveReports.Label()
            Me.hdCompras = New DataDynamics.ActiveReports.Label()
            Me.hdAbonos = New DataDynamics.ActiveReports.Label()
            Me.Line1 = New DataDynamics.ActiveReports.Line()
            Me.Line2 = New DataDynamics.ActiveReports.Line()
            Me.Line3 = New DataDynamics.ActiveReports.Line()
            Me.Line4 = New DataDynamics.ActiveReports.Line()
            Me.Line5 = New DataDynamics.ActiveReports.Line()
            Me.Line6 = New DataDynamics.ActiveReports.Line()
            Me.lblImporte = New DataDynamics.ActiveReports.Label()
            Me.txtImporte = New DataDynamics.ActiveReports.TextBox()
            Me.Fecha = New DataDynamics.ActiveReports.TextBox()
            Me.Sucursal = New DataDynamics.ActiveReports.TextBox()
            Me.FolioAbono = New DataDynamics.ActiveReports.TextBox()
            Me.Detalles = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox3 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox4 = New DataDynamics.ActiveReports.TextBox()
            Me.Line7 = New DataDynamics.ActiveReports.Line()
            CType(Me.Label1,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblFolio,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblAsociado,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblDiasPlazo,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblFechaLimite,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblLimiteCredito,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblAbono,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblSaldoActual,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFolioFactura,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtAsociadoID,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtNombreAsociado,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtPlazo,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtAbonos,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtSaldoActual,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtLimiteCredito,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFechaLimite,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.hdFecha,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.hdSucursal,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.hdfolio,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.hdDetalles,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.hdCompras,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.hdAbonos,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblImporte,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtImporte,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Fecha,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Sucursal,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.FolioAbono,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Detalles,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox3,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox4,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
            '
            'Detail
            '
            Me.Detail.ColumnSpacing = 0!
            Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Fecha, Me.Sucursal, Me.FolioAbono, Me.Detalles, Me.TextBox3, Me.TextBox4})
            Me.Detail.Height = 0.2076389!
            Me.Detail.Name = "Detail"
            '
            'PageHeader
            '
            Me.PageHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape1, Me.Label1, Me.lblFolio, Me.lblAsociado, Me.lblDiasPlazo, Me.lblFechaLimite, Me.lblLimiteCredito, Me.lblAbono, Me.lblSaldoActual, Me.txtFolioFactura, Me.txtAsociadoID, Me.txtNombreAsociado, Me.txtPlazo, Me.txtAbonos, Me.txtSaldoActual, Me.txtLimiteCredito, Me.txtFechaLimite, Me.hdFecha, Me.hdSucursal, Me.hdfolio, Me.hdDetalles, Me.hdCompras, Me.hdAbonos, Me.Line1, Me.Line2, Me.Line3, Me.Line4, Me.Line5, Me.Line6, Me.lblImporte, Me.txtImporte})
            Me.PageHeader.Height = 1.45!
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
            Me.GroupFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Line7})
            Me.GroupFooter1.Height = 0.0625!
            Me.GroupFooter1.Name = "GroupFooter1"
            '
            'Shape1
            '
            Me.Shape1.Height = 1.375!
            Me.Shape1.Left = 0!
            Me.Shape1.Name = "Shape1"
            Me.Shape1.RoundingRadius = 9.999999!
            Me.Shape1.Top = 0.0625!
            Me.Shape1.Width = 6.5!
            '
            'Label1
            '
            Me.Label1.Height = 0.2!
            Me.Label1.HyperLink = Nothing
            Me.Label1.Left = 0.125!
            Me.Label1.Name = "Label1"
            Me.Label1.Style = "text-align: center"
            Me.Label1.Text = "ESTADO DE CUENTA POR DOCUMENTO"
            Me.Label1.Top = 0.125!
            Me.Label1.Width = 6.1875!
            '
            'lblFolio
            '
            Me.lblFolio.Height = 0.2!
            Me.lblFolio.HyperLink = Nothing
            Me.lblFolio.Left = 0.0625!
            Me.lblFolio.Name = "lblFolio"
            Me.lblFolio.Style = "font-size: 9pt"
            Me.lblFolio.Text = "Folio de Factura :"
            Me.lblFolio.Top = 0.375!
            Me.lblFolio.Width = 1.1875!
            '
            'lblAsociado
            '
            Me.lblAsociado.Height = 0.2!
            Me.lblAsociado.HyperLink = Nothing
            Me.lblAsociado.Left = 0.0625!
            Me.lblAsociado.Name = "lblAsociado"
            Me.lblAsociado.Style = "font-size: 9pt"
            Me.lblAsociado.Text = "Asociado :"
            Me.lblAsociado.Top = 0.625!
            Me.lblAsociado.Width = 0.625!
            '
            'lblDiasPlazo
            '
            Me.lblDiasPlazo.Height = 0.2!
            Me.lblDiasPlazo.HyperLink = Nothing
            Me.lblDiasPlazo.Left = 2.3125!
            Me.lblDiasPlazo.Name = "lblDiasPlazo"
            Me.lblDiasPlazo.Style = "font-size: 9pt"
            Me.lblDiasPlazo.Text = "Dias de Plazo :"
            Me.lblDiasPlazo.Top = 0.375!
            Me.lblDiasPlazo.Width = 0.875!
            '
            'lblFechaLimite
            '
            Me.lblFechaLimite.Height = 0.2!
            Me.lblFechaLimite.HyperLink = Nothing
            Me.lblFechaLimite.Left = 4!
            Me.lblFechaLimite.Name = "lblFechaLimite"
            Me.lblFechaLimite.Style = "font-size: 9pt"
            Me.lblFechaLimite.Text = "Fecha L�mite de Pago :"
            Me.lblFechaLimite.Top = 0.375!
            Me.lblFechaLimite.Width = 1.375!
            '
            'lblLimiteCredito
            '
            Me.lblLimiteCredito.Height = 0.2!
            Me.lblLimiteCredito.HyperLink = Nothing
            Me.lblLimiteCredito.Left = 4!
            Me.lblLimiteCredito.Name = "lblLimiteCredito"
            Me.lblLimiteCredito.Style = "font-size: 9pt"
            Me.lblLimiteCredito.Text = "L�mite de Cr�dito :"
            Me.lblLimiteCredito.Top = 0.625!
            Me.lblLimiteCredito.Width = 1.375!
            '
            'lblAbono
            '
            Me.lblAbono.Height = 0.2!
            Me.lblAbono.HyperLink = Nothing
            Me.lblAbono.Left = 2.375!
            Me.lblAbono.Name = "lblAbono"
            Me.lblAbono.Style = "font-size: 9pt"
            Me.lblAbono.Text = "Abonos :"
            Me.lblAbono.Top = 0.875!
            Me.lblAbono.Width = 0.625!
            '
            'lblSaldoActual
            '
            Me.lblSaldoActual.Height = 0.2!
            Me.lblSaldoActual.HyperLink = Nothing
            Me.lblSaldoActual.Left = 4.125!
            Me.lblSaldoActual.Name = "lblSaldoActual"
            Me.lblSaldoActual.Style = "font-size: 9pt"
            Me.lblSaldoActual.Text = "Saldo Actual :"
            Me.lblSaldoActual.Top = 0.875!
            Me.lblSaldoActual.Width = 1!
            '
            'txtFolioFactura
            '
            Me.txtFolioFactura.Height = 0.2!
            Me.txtFolioFactura.Left = 1.3125!
            Me.txtFolioFactura.Name = "txtFolioFactura"
            Me.txtFolioFactura.Style = "font-size: 9pt"
            Me.txtFolioFactura.Text = "Folio"
            Me.txtFolioFactura.Top = 0.375!
            Me.txtFolioFactura.Width = 0.9375!
            '
            'txtAsociadoID
            '
            Me.txtAsociadoID.Height = 0.2!
            Me.txtAsociadoID.Left = 0.6875!
            Me.txtAsociadoID.Name = "txtAsociadoID"
            Me.txtAsociadoID.Style = "font-weight: bold; font-size: 9pt"
            Me.txtAsociadoID.Text = "Asociado"
            Me.txtAsociadoID.Top = 0.625!
            Me.txtAsociadoID.Width = 0.8125!
            '
            'txtNombreAsociado
            '
            Me.txtNombreAsociado.Height = 0.2!
            Me.txtNombreAsociado.Left = 1.5!
            Me.txtNombreAsociado.Name = "txtNombreAsociado"
            Me.txtNombreAsociado.Style = "font-size: 9pt"
            Me.txtNombreAsociado.Text = "Nombre Asociado"
            Me.txtNombreAsociado.Top = 0.625!
            Me.txtNombreAsociado.Width = 2.4375!
            '
            'txtPlazo
            '
            Me.txtPlazo.Height = 0.2!
            Me.txtPlazo.Left = 3.25!
            Me.txtPlazo.Name = "txtPlazo"
            Me.txtPlazo.Style = "font-size: 9pt"
            Me.txtPlazo.Text = "30 Dias"
            Me.txtPlazo.Top = 0.375!
            Me.txtPlazo.Width = 0.625!
            '
            'txtAbonos
            '
            Me.txtAbonos.Height = 0.2!
            Me.txtAbonos.Left = 3.0625!
            Me.txtAbonos.Name = "txtAbonos"
            Me.txtAbonos.OutputFormat = resources.GetString("txtAbonos.OutputFormat")
            Me.txtAbonos.Style = "font-weight: bold; font-size: 9pt"
            Me.txtAbonos.SummaryGroup = "GroupHeader1"
            Me.txtAbonos.Text = "0"
            Me.txtAbonos.Top = 0.875!
            Me.txtAbonos.Width = 1!
            '
            'txtSaldoActual
            '
            Me.txtSaldoActual.Height = 0.2!
            Me.txtSaldoActual.Left = 5.125!
            Me.txtSaldoActual.Name = "txtSaldoActual"
            Me.txtSaldoActual.OutputFormat = resources.GetString("txtSaldoActual.OutputFormat")
            Me.txtSaldoActual.Style = "font-weight: bold; font-size: 9pt"
            Me.txtSaldoActual.Text = "0"
            Me.txtSaldoActual.Top = 0.875!
            Me.txtSaldoActual.Width = 1!
            '
            'txtLimiteCredito
            '
            Me.txtLimiteCredito.Height = 0.2!
            Me.txtLimiteCredito.Left = 5.4375!
            Me.txtLimiteCredito.Name = "txtLimiteCredito"
            Me.txtLimiteCredito.OutputFormat = resources.GetString("txtLimiteCredito.OutputFormat")
            Me.txtLimiteCredito.Style = "font-weight: normal; font-size: 9pt"
            Me.txtLimiteCredito.Text = "0"
            Me.txtLimiteCredito.Top = 0.625!
            Me.txtLimiteCredito.Width = 0.9375!
            '
            'txtFechaLimite
            '
            Me.txtFechaLimite.Height = 0.2!
            Me.txtFechaLimite.HyperLink = Nothing
            Me.txtFechaLimite.Left = 5.4375!
            Me.txtFechaLimite.Name = "txtFechaLimite"
            Me.txtFechaLimite.Style = "text-align: center; font-weight: normal; font-size: 9pt"
            Me.txtFechaLimite.Text = "00/00/0000"
            Me.txtFechaLimite.Top = 0.375!
            Me.txtFechaLimite.Width = 0.9375!
            '
            'hdFecha
            '
            Me.hdFecha.Height = 0.2!
            Me.hdFecha.HyperLink = Nothing
            Me.hdFecha.Left = 0.0625!
            Me.hdFecha.Name = "hdFecha"
            Me.hdFecha.Style = "text-align: center; font-size: 9pt"
            Me.hdFecha.Text = "Fecha"
            Me.hdFecha.Top = 1.1875!
            Me.hdFecha.Width = 0.625!
            '
            'hdSucursal
            '
            Me.hdSucursal.Height = 0.2!
            Me.hdSucursal.HyperLink = Nothing
            Me.hdSucursal.Left = 0.75!
            Me.hdSucursal.Name = "hdSucursal"
            Me.hdSucursal.Style = "text-align: center; font-size: 9pt"
            Me.hdSucursal.Text = "Sucursal"
            Me.hdSucursal.Top = 1.1875!
            Me.hdSucursal.Width = 0.625!
            '
            'hdfolio
            '
            Me.hdfolio.Height = 0.2!
            Me.hdfolio.HyperLink = Nothing
            Me.hdfolio.Left = 1.4375!
            Me.hdfolio.Name = "hdfolio"
            Me.hdfolio.Style = "text-align: center; font-size: 9pt"
            Me.hdfolio.Text = "Folio"
            Me.hdfolio.Top = 1.1875!
            Me.hdfolio.Width = 0.9375!
            '
            'hdDetalles
            '
            Me.hdDetalles.Height = 0.2!
            Me.hdDetalles.HyperLink = Nothing
            Me.hdDetalles.Left = 2.4375!
            Me.hdDetalles.Name = "hdDetalles"
            Me.hdDetalles.Style = "font-size: 9pt"
            Me.hdDetalles.Text = "Detalles"
            Me.hdDetalles.Top = 1.1875!
            Me.hdDetalles.Width = 2.125!
            '
            'hdCompras
            '
            Me.hdCompras.Height = 0.2!
            Me.hdCompras.HyperLink = Nothing
            Me.hdCompras.Left = 4.6875!
            Me.hdCompras.Name = "hdCompras"
            Me.hdCompras.Style = "text-align: center; font-size: 9pt"
            Me.hdCompras.Text = "Compras"
            Me.hdCompras.Top = 1.1875!
            Me.hdCompras.Width = 0.875!
            '
            'hdAbonos
            '
            Me.hdAbonos.Height = 0.2!
            Me.hdAbonos.HyperLink = Nothing
            Me.hdAbonos.Left = 5.5625!
            Me.hdAbonos.Name = "hdAbonos"
            Me.hdAbonos.Style = "text-align: center; font-size: 9pt"
            Me.hdAbonos.Text = "Abonos"
            Me.hdAbonos.Top = 1.1875!
            Me.hdAbonos.Width = 0.875!
            '
            'Line1
            '
            Me.Line1.Height = 0!
            Me.Line1.Left = 0!
            Me.Line1.LineWeight = 1!
            Me.Line1.Name = "Line1"
            Me.Line1.Top = 1.125!
            Me.Line1.Width = 6.5!
            Me.Line1.X1 = 6.5!
            Me.Line1.X2 = 0!
            Me.Line1.Y1 = 1.125!
            Me.Line1.Y2 = 1.125!
            '
            'Line2
            '
            Me.Line2.Height = 0.3125!
            Me.Line2.Left = 5.569445!
            Me.Line2.LineWeight = 1!
            Me.Line2.Name = "Line2"
            Me.Line2.Top = 1.131944!
            Me.Line2.Width = 0!
            Me.Line2.X1 = 5.569445!
            Me.Line2.X2 = 5.569445!
            Me.Line2.Y1 = 1.131944!
            Me.Line2.Y2 = 1.444444!
            '
            'Line3
            '
            Me.Line3.Height = 0.3125!
            Me.Line3.Left = 4.694445!
            Me.Line3.LineWeight = 1!
            Me.Line3.Name = "Line3"
            Me.Line3.Top = 1.131944!
            Me.Line3.Width = 0!
            Me.Line3.X1 = 4.694445!
            Me.Line3.X2 = 4.694445!
            Me.Line3.Y1 = 1.131944!
            Me.Line3.Y2 = 1.444444!
            '
            'Line4
            '
            Me.Line4.Height = 0.3125!
            Me.Line4.Left = 2.381944!
            Me.Line4.LineWeight = 1!
            Me.Line4.Name = "Line4"
            Me.Line4.Top = 1.131944!
            Me.Line4.Width = 0!
            Me.Line4.X1 = 2.381944!
            Me.Line4.X2 = 2.381944!
            Me.Line4.Y1 = 1.131944!
            Me.Line4.Y2 = 1.444444!
            '
            'Line5
            '
            Me.Line5.Height = 0.3125!
            Me.Line5.Left = 1.381944!
            Me.Line5.LineWeight = 1!
            Me.Line5.Name = "Line5"
            Me.Line5.Top = 1.131944!
            Me.Line5.Width = 0!
            Me.Line5.X1 = 1.381944!
            Me.Line5.X2 = 1.381944!
            Me.Line5.Y1 = 1.131944!
            Me.Line5.Y2 = 1.444444!
            '
            'Line6
            '
            Me.Line6.Height = 0.3125!
            Me.Line6.Left = 0.7569444!
            Me.Line6.LineWeight = 1!
            Me.Line6.Name = "Line6"
            Me.Line6.Top = 1.131944!
            Me.Line6.Width = 0!
            Me.Line6.X1 = 0.7569444!
            Me.Line6.X2 = 0.7569444!
            Me.Line6.Y1 = 1.131944!
            Me.Line6.Y2 = 1.444444!
            '
            'lblImporte
            '
            Me.lblImporte.Height = 0.2!
            Me.lblImporte.HyperLink = Nothing
            Me.lblImporte.Left = 0.5625!
            Me.lblImporte.Name = "lblImporte"
            Me.lblImporte.Style = "font-size: 9pt"
            Me.lblImporte.Text = "Importe :"
            Me.lblImporte.Top = 0.875!
            Me.lblImporte.Width = 0.625!
            '
            'txtImporte
            '
            Me.txtImporte.Height = 0.2!
            Me.txtImporte.Left = 1.25!
            Me.txtImporte.Name = "txtImporte"
            Me.txtImporte.OutputFormat = resources.GetString("txtImporte.OutputFormat")
            Me.txtImporte.Style = "font-weight: bold; font-size: 9pt"
            Me.txtImporte.Text = "0"
            Me.txtImporte.Top = 0.875!
            Me.txtImporte.Width = 1!
            '
            'Fecha
            '
            Me.Fecha.DataField = "Fecha"
            Me.Fecha.Height = 0.2!
            Me.Fecha.Left = 0!
            Me.Fecha.Name = "Fecha"
            Me.Fecha.OutputFormat = resources.GetString("Fecha.OutputFormat")
            Me.Fecha.Style = "text-align: center; font-size: 9pt"
            Me.Fecha.Text = "00/00/0000"
            Me.Fecha.Top = 0!
            Me.Fecha.Width = 0.75!
            '
            'Sucursal
            '
            Me.Sucursal.DataField = "Sucursal"
            Me.Sucursal.Height = 0.2!
            Me.Sucursal.Left = 0.8125!
            Me.Sucursal.Name = "Sucursal"
            Me.Sucursal.Style = "text-align: center; font-size: 9pt"
            Me.Sucursal.Text = "000"
            Me.Sucursal.Top = 0!
            Me.Sucursal.Width = 0.4375!
            '
            'FolioAbono
            '
            Me.FolioAbono.DataField = "Folio"
            Me.FolioAbono.Height = 0.2!
            Me.FolioAbono.Left = 1.4375!
            Me.FolioAbono.Name = "FolioAbono"
            Me.FolioAbono.Style = "text-align: right; font-size: 9pt"
            Me.FolioAbono.Text = "FolioAbono"
            Me.FolioAbono.Top = 0!
            Me.FolioAbono.Width = 0.9375!
            '
            'Detalles
            '
            Me.Detalles.DataField = "Detalle"
            Me.Detalles.Height = 0.2!
            Me.Detalles.Left = 2.4375!
            Me.Detalles.Name = "Detalles"
            Me.Detalles.Style = "font-size: 9pt"
            Me.Detalles.Text = "Detalles"
            Me.Detalles.Top = 0!
            Me.Detalles.Width = 2.25!
            '
            'TextBox3
            '
            Me.TextBox3.DataField = "ComprasCargos"
            Me.TextBox3.Height = 0.2!
            Me.TextBox3.Left = 4.6875!
            Me.TextBox3.Name = "TextBox3"
            Me.TextBox3.OutputFormat = resources.GetString("TextBox3.OutputFormat")
            Me.TextBox3.Style = "text-align: right; font-size: 9pt"
            Me.TextBox3.Text = "Compras"
            Me.TextBox3.Top = 0!
            Me.TextBox3.Width = 0.875!
            '
            'TextBox4
            '
            Me.TextBox4.DataField = "PagosAbonos"
            Me.TextBox4.Height = 0.2!
            Me.TextBox4.Left = 5.625!
            Me.TextBox4.Name = "TextBox4"
            Me.TextBox4.OutputFormat = resources.GetString("TextBox4.OutputFormat")
            Me.TextBox4.Style = "text-align: right; font-size: 9pt"
            Me.TextBox4.Text = "Abonos"
            Me.TextBox4.Top = 0!
            Me.TextBox4.Width = 0.875!
            '
            'Line7
            '
            Me.Line7.Height = 0!
            Me.Line7.Left = 0.006944444!
            Me.Line7.LineWeight = 1!
            Me.Line7.Name = "Line7"
            Me.Line7.Top = 0.006944444!
            Me.Line7.Width = 6.5!
            Me.Line7.X1 = 6.506945!
            Me.Line7.X2 = 0.006944444!
            Me.Line7.Y1 = 0.006944444!
            Me.Line7.Y2 = 0.006944444!
            '
            'ActiveReport1
            '
            Me.MasterReport = false
            Me.PageSettings.PaperHeight = 11!
            Me.PageSettings.PaperWidth = 8.5!
            Me.PrintWidth = 6.520833!
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
            CType(Me.Label1,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblFolio,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblAsociado,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblDiasPlazo,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblFechaLimite,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblLimiteCredito,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblAbono,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblSaldoActual,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFolioFactura,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtAsociadoID,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtNombreAsociado,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtPlazo,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtAbonos,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtSaldoActual,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtLimiteCredito,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFechaLimite,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.hdFecha,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.hdSucursal,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.hdfolio,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.hdDetalles,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.hdCompras,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.hdAbonos,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblImporte,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtImporte,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Fecha,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Sucursal,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.FolioAbono,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Detalles,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox3,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox4,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        End Sub

#End Region


    Private Sub EstadoCuentaFacturaReport_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.ReportStart

    End Sub
End Class
