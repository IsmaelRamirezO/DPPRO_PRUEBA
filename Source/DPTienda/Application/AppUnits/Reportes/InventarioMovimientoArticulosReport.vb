Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Public Class InventarioMovimientoArticuloReport
    Inherits DataDynamics.ActiveReports.ActiveReport
    Public Sub New(ByVal oForm As InventarioMovimientosArticuloReportForm)
        MyBase.New()
        InitializeComponent()
        lblReportDate.Text = Date.Now.ToString()
        With oForm
            tbArticulo.Text = .ebArticuloID.Text
            tbCorDescripcion.Text = .ebCorDescripcion.Text
            tbAlmacen.Text = .ebAlmacen.Text
            tbSaldoIni.Text = .ebSaldoIni.Text
            tbSaldoFin.Text = .ebSaldoFin.Text
            tbCorridaIni.Text = .ebCorridaIni.Text
            tbCorridaFin.Text = .ebSaldoFin.Text
            tbMes.Text = .uicbMes.Text
        End With

    End Sub
#Region "ActiveReports Designer generated code"
    Private WithEvents PageHeader As PageHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents PageFooter As PageFooter = Nothing
	Private lblReportTitle As Label = Nothing
	Private lblFieldCodigo As Label = Nothing
	Private lblFieldReferencia As Label = Nothing
	Private lblFieldFecha As Label = Nothing
	Private lblFieldDescripcion As Label = Nothing
	Private lblFieldEntrada As Label = Nothing
	Private lblFieldSalida As Label = Nothing
	Private tbSaldoIni As TextBox = Nothing
	Private tbSaldoFin As TextBox = Nothing
	Private lblReportDate As Label = Nothing
	Private tbCorridaIni As TextBox = Nothing
	Private tbCorridaFin As TextBox = Nothing
	Private tbCorDescripcion As TextBox = Nothing
	Private Label9 As Label = Nothing
	Private Label10 As Label = Nothing
	Private Label11 As Label = Nothing
	Private Label12 As Label = Nothing
	Private Label13 As Label = Nothing
	Private tbArticulo As TextBox = Nothing
	Private lbArticulo As Label = Nothing
	Private tbAlmacen As TextBox = Nothing
	Private Label14 As Label = Nothing
	Private Label15 As Label = Nothing
	Private tbMes As TextBox = Nothing
	Private Label16 As Label = Nothing
	Private tbCodAlmacen As TextBox = Nothing
	Private tbReferencia As TextBox = Nothing
	Private tbFecha As TextBox = Nothing
	Private tbDescripcion As TextBox = Nothing
	Private tbEntradas As TextBox = Nothing
	Private tbSalidas As TextBox = Nothing
	Private lneBottomTable As Line = Nothing
	Private Line1 As Line = Nothing
	Private Line2 As Line = Nothing
	Private Line3 As Line = Nothing
	Private Line6 As Line = Nothing
	Private Line7 As Line = Nothing
	Private Line8 As Line = Nothing
	Private Line9 As Line = Nothing
	Private Line10 As Line = Nothing
	Private Label4 As Label = Nothing
	Private Label2 As Label = Nothing
	Private Label5 As Label = Nothing
	Private Label6 As Label = Nothing
	Private Label7 As Label = Nothing
	Private tbPageNumber As TextBox = Nothing
	Private Label8 As Label = Nothing
	Private tbPageCount As TextBox = Nothing
	Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InventarioMovimientoArticuloReport))
            Me.Detail = New DataDynamics.ActiveReports.Detail()
            Me.PageHeader = New DataDynamics.ActiveReports.PageHeader()
            Me.PageFooter = New DataDynamics.ActiveReports.PageFooter()
            Me.lblReportTitle = New DataDynamics.ActiveReports.Label()
            Me.lblFieldCodigo = New DataDynamics.ActiveReports.Label()
            Me.lblFieldReferencia = New DataDynamics.ActiveReports.Label()
            Me.lblFieldFecha = New DataDynamics.ActiveReports.Label()
            Me.lblFieldDescripcion = New DataDynamics.ActiveReports.Label()
            Me.lblFieldEntrada = New DataDynamics.ActiveReports.Label()
            Me.lblFieldSalida = New DataDynamics.ActiveReports.Label()
            Me.tbSaldoIni = New DataDynamics.ActiveReports.TextBox()
            Me.tbSaldoFin = New DataDynamics.ActiveReports.TextBox()
            Me.lblReportDate = New DataDynamics.ActiveReports.Label()
            Me.tbCorridaIni = New DataDynamics.ActiveReports.TextBox()
            Me.tbCorridaFin = New DataDynamics.ActiveReports.TextBox()
            Me.tbCorDescripcion = New DataDynamics.ActiveReports.TextBox()
            Me.Label9 = New DataDynamics.ActiveReports.Label()
            Me.Label10 = New DataDynamics.ActiveReports.Label()
            Me.Label11 = New DataDynamics.ActiveReports.Label()
            Me.Label12 = New DataDynamics.ActiveReports.Label()
            Me.Label13 = New DataDynamics.ActiveReports.Label()
            Me.tbArticulo = New DataDynamics.ActiveReports.TextBox()
            Me.lbArticulo = New DataDynamics.ActiveReports.Label()
            Me.tbAlmacen = New DataDynamics.ActiveReports.TextBox()
            Me.Label14 = New DataDynamics.ActiveReports.Label()
            Me.Label15 = New DataDynamics.ActiveReports.Label()
            Me.tbMes = New DataDynamics.ActiveReports.TextBox()
            Me.Label16 = New DataDynamics.ActiveReports.Label()
            Me.tbCodAlmacen = New DataDynamics.ActiveReports.TextBox()
            Me.tbReferencia = New DataDynamics.ActiveReports.TextBox()
            Me.tbFecha = New DataDynamics.ActiveReports.TextBox()
            Me.tbDescripcion = New DataDynamics.ActiveReports.TextBox()
            Me.tbEntradas = New DataDynamics.ActiveReports.TextBox()
            Me.tbSalidas = New DataDynamics.ActiveReports.TextBox()
            Me.lneBottomTable = New DataDynamics.ActiveReports.Line()
            Me.Line1 = New DataDynamics.ActiveReports.Line()
            Me.Line2 = New DataDynamics.ActiveReports.Line()
            Me.Line3 = New DataDynamics.ActiveReports.Line()
            Me.Line6 = New DataDynamics.ActiveReports.Line()
            Me.Line7 = New DataDynamics.ActiveReports.Line()
            Me.Line8 = New DataDynamics.ActiveReports.Line()
            Me.Line9 = New DataDynamics.ActiveReports.Line()
            Me.Line10 = New DataDynamics.ActiveReports.Line()
            Me.Label4 = New DataDynamics.ActiveReports.Label()
            Me.Label2 = New DataDynamics.ActiveReports.Label()
            Me.Label5 = New DataDynamics.ActiveReports.Label()
            Me.Label6 = New DataDynamics.ActiveReports.Label()
            Me.Label7 = New DataDynamics.ActiveReports.Label()
            Me.tbPageNumber = New DataDynamics.ActiveReports.TextBox()
            Me.Label8 = New DataDynamics.ActiveReports.Label()
            Me.tbPageCount = New DataDynamics.ActiveReports.TextBox()
            CType(Me.lblReportTitle,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblFieldCodigo,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblFieldReferencia,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblFieldFecha,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblFieldDescripcion,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblFieldEntrada,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblFieldSalida,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbSaldoIni,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbSaldoFin,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblReportDate,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbCorridaIni,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbCorridaFin,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbCorDescripcion,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label9,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label10,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label11,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label12,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label13,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbArticulo,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lbArticulo,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbAlmacen,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label14,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label15,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbMes,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label16,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbCodAlmacen,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbReferencia,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbFecha,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbDescripcion,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbEntradas,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbSalidas,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label5,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label6,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label7,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbPageNumber,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label8,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbPageCount,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
            '
            'Detail
            '
            Me.Detail.ColumnSpacing = 0!
            Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.tbCodAlmacen, Me.tbReferencia, Me.tbFecha, Me.tbDescripcion, Me.tbEntradas, Me.tbSalidas, Me.lneBottomTable, Me.Line1, Me.Line2, Me.Line3, Me.Line6, Me.Line7, Me.Line8, Me.Line9, Me.Line10})
            Me.Detail.Height = 0.1979167!
            Me.Detail.Name = "Detail"
            '
            'PageHeader
            '
            Me.PageHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.lblReportTitle, Me.lblFieldCodigo, Me.lblFieldReferencia, Me.lblFieldFecha, Me.lblFieldDescripcion, Me.lblFieldEntrada, Me.lblFieldSalida, Me.tbSaldoIni, Me.tbSaldoFin, Me.lblReportDate, Me.tbCorridaIni, Me.tbCorridaFin, Me.tbCorDescripcion, Me.Label9, Me.Label10, Me.Label11, Me.Label12, Me.Label13, Me.tbArticulo, Me.lbArticulo, Me.tbAlmacen, Me.Label14, Me.Label15, Me.tbMes, Me.Label16})
            Me.PageHeader.Height = 2.322917!
            Me.PageHeader.Name = "PageHeader"
            '
            'PageFooter
            '
            Me.PageFooter.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label4, Me.Label2, Me.Label5, Me.Label6, Me.Label7, Me.tbPageNumber, Me.Label8, Me.tbPageCount})
            Me.PageFooter.Height = 0.53125!
            Me.PageFooter.Name = "PageFooter"
            '
            'lblReportTitle
            '
            Me.lblReportTitle.ClassName = "Heading1"
            Me.lblReportTitle.Height = 0.3937007!
            Me.lblReportTitle.HyperLink = Nothing
            Me.lblReportTitle.Left = 0.6875!
            Me.lblReportTitle.MultiLine = false
            Me.lblReportTitle.Name = "lblReportTitle"
            Me.lblReportTitle.Style = "white-space: nowrap; vertical-align: middle"
            Me.lblReportTitle.Text = "Reporte de Inventario Movimientos por Artículos"
            Me.lblReportTitle.Top = 0.0625!
            Me.lblReportTitle.Width = 5.5!
            '
            'lblFieldCodigo
            '
            Me.lblFieldCodigo.Height = 0.1968504!
            Me.lblFieldCodigo.HyperLink = Nothing
            Me.lblFieldCodigo.Left = 0!
            Me.lblFieldCodigo.Name = "lblFieldCodigo"
            Me.lblFieldCodigo.Style = "color: White; ddo-char-set: 1; text-align: center; font-weight: bold; background-"& _ 
                "color: DimGray"
            Me.lblFieldCodigo.Text = "Origen"
            Me.lblFieldCodigo.Top = 2.125!
            Me.lblFieldCodigo.Width = 1!
            '
            'lblFieldReferencia
            '
            Me.lblFieldReferencia.Height = 0.1968504!
            Me.lblFieldReferencia.HyperLink = Nothing
            Me.lblFieldReferencia.Left = 1!
            Me.lblFieldReferencia.Name = "lblFieldReferencia"
            Me.lblFieldReferencia.Style = "color: White; ddo-char-set: 1; text-align: center; font-weight: bold; background-"& _ 
                "color: DimGray"
            Me.lblFieldReferencia.Text = "Referencia"
            Me.lblFieldReferencia.Top = 2.125!
            Me.lblFieldReferencia.Width = 1!
            '
            'lblFieldFecha
            '
            Me.lblFieldFecha.Height = 0.197!
            Me.lblFieldFecha.HyperLink = Nothing
            Me.lblFieldFecha.Left = 5.9375!
            Me.lblFieldFecha.Name = "lblFieldFecha"
            Me.lblFieldFecha.Style = "color: White; ddo-char-set: 1; text-align: center; font-weight: bold; background-"& _ 
                "color: DimGray"
            Me.lblFieldFecha.Text = "Fecha"
            Me.lblFieldFecha.Top = 2.125!
            Me.lblFieldFecha.Width = 1.01!
            '
            'lblFieldDescripcion
            '
            Me.lblFieldDescripcion.Height = 0.1968504!
            Me.lblFieldDescripcion.HyperLink = Nothing
            Me.lblFieldDescripcion.Left = 2!
            Me.lblFieldDescripcion.Name = "lblFieldDescripcion"
            Me.lblFieldDescripcion.Style = "color: White; ddo-char-set: 1; text-align: center; font-weight: bold; background-"& _ 
                "color: DimGray"
            Me.lblFieldDescripcion.Text = "Descripcion"
            Me.lblFieldDescripcion.Top = 2.125!
            Me.lblFieldDescripcion.Width = 2!
            '
            'lblFieldEntrada
            '
            Me.lblFieldEntrada.Height = 0.1968504!
            Me.lblFieldEntrada.HyperLink = Nothing
            Me.lblFieldEntrada.Left = 4!
            Me.lblFieldEntrada.Name = "lblFieldEntrada"
            Me.lblFieldEntrada.Style = "color: White; ddo-char-set: 1; text-align: center; font-weight: bold; background-"& _ 
                "color: DimGray"
            Me.lblFieldEntrada.Text = "Entradas"
            Me.lblFieldEntrada.Top = 2.125!
            Me.lblFieldEntrada.Width = 0.9375!
            '
            'lblFieldSalida
            '
            Me.lblFieldSalida.Height = 0.1968504!
            Me.lblFieldSalida.HyperLink = Nothing
            Me.lblFieldSalida.Left = 4.9375!
            Me.lblFieldSalida.Name = "lblFieldSalida"
            Me.lblFieldSalida.Style = "color: White; ddo-char-set: 1; text-align: center; font-weight: bold; background-"& _ 
                "color: DimGray"
            Me.lblFieldSalida.Text = "Salidas"
            Me.lblFieldSalida.Top = 2.125!
            Me.lblFieldSalida.Width = 1!
            '
            'tbSaldoIni
            '
            Me.tbSaldoIni.Height = 0.1968504!
            Me.tbSaldoIni.Left = 4.0625!
            Me.tbSaldoIni.MultiLine = false
            Me.tbSaldoIni.Name = "tbSaldoIni"
            Me.tbSaldoIni.Top = 1!
            Me.tbSaldoIni.Width = 0.6875!
            '
            'tbSaldoFin
            '
            Me.tbSaldoFin.Height = 0.1968504!
            Me.tbSaldoFin.Left = 6!
            Me.tbSaldoFin.MultiLine = false
            Me.tbSaldoFin.Name = "tbSaldoFin"
            Me.tbSaldoFin.Top = 1!
            Me.tbSaldoFin.Width = 0.6875!
            '
            'lblReportDate
            '
            Me.lblReportDate.Height = 0.3125!
            Me.lblReportDate.HyperLink = Nothing
            Me.lblReportDate.Left = 4.8125!
            Me.lblReportDate.Name = "lblReportDate"
            Me.lblReportDate.Style = "text-align: right; vertical-align: middle"
            Me.lblReportDate.Text = "Label9"
            Me.lblReportDate.Top = 0.5!
            Me.lblReportDate.Width = 1.875!
            '
            'tbCorridaIni
            '
            Me.tbCorridaIni.Height = 0.2!
            Me.tbCorridaIni.Left = 4.0625!
            Me.tbCorridaIni.Name = "tbCorridaIni"
            Me.tbCorridaIni.Top = 1.3125!
            Me.tbCorridaIni.Width = 0.6875!
            '
            'tbCorridaFin
            '
            Me.tbCorridaFin.Height = 0.2!
            Me.tbCorridaFin.Left = 6!
            Me.tbCorridaFin.Name = "tbCorridaFin"
            Me.tbCorridaFin.Top = 1.3125!
            Me.tbCorridaFin.Width = 0.6875!
            '
            'tbCorDescripcion
            '
            Me.tbCorDescripcion.Height = 0.2!
            Me.tbCorDescripcion.Left = 1.3125!
            Me.tbCorDescripcion.Name = "tbCorDescripcion"
            Me.tbCorDescripcion.Top = 1.3125!
            Me.tbCorDescripcion.Width = 1.6875!
            '
            'Label9
            '
            Me.Label9.Height = 0.2!
            Me.Label9.HyperLink = Nothing
            Me.Label9.Left = -0.125!
            Me.Label9.Name = "Label9"
            Me.Label9.Style = "text-align: right; vertical-align: middle"
            Me.Label9.Text = "Descripción:"
            Me.Label9.Top = 1.3125!
            Me.Label9.Width = 1!
            '
            'Label10
            '
            Me.Label10.Height = 0.2!
            Me.Label10.HyperLink = Nothing
            Me.Label10.Left = 3.0625!
            Me.Label10.Name = "Label10"
            Me.Label10.Style = "text-align: right; vertical-align: middle"
            Me.Label10.Text = "Corrida Inicial:"
            Me.Label10.Top = 1.3125!
            Me.Label10.Width = 0.9375!
            '
            'Label11
            '
            Me.Label11.Height = 0.2!
            Me.Label11.HyperLink = Nothing
            Me.Label11.Left = 5.0625!
            Me.Label11.Name = "Label11"
            Me.Label11.Style = "text-align: right; vertical-align: middle"
            Me.Label11.Text = "Corrida Final:"
            Me.Label11.Top = 1.3125!
            Me.Label11.Width = 0.875!
            '
            'Label12
            '
            Me.Label12.Height = 0.2!
            Me.Label12.HyperLink = Nothing
            Me.Label12.Left = 3.0625!
            Me.Label12.Name = "Label12"
            Me.Label12.Style = "text-align: right; vertical-align: middle"
            Me.Label12.Text = "Saldo Inicial:"
            Me.Label12.Top = 1!
            Me.Label12.Width = 0.875!
            '
            'Label13
            '
            Me.Label13.Height = 0.2!
            Me.Label13.HyperLink = Nothing
            Me.Label13.Left = 5.0625!
            Me.Label13.Name = "Label13"
            Me.Label13.Style = "text-align: right; vertical-align: middle"
            Me.Label13.Text = "Saldo Final:"
            Me.Label13.Top = 1!
            Me.Label13.Width = 0.8125!
            '
            'tbArticulo
            '
            Me.tbArticulo.Height = 0.2!
            Me.tbArticulo.Left = 1.3125!
            Me.tbArticulo.Name = "tbArticulo"
            Me.tbArticulo.Top = 1!
            Me.tbArticulo.Width = 1.6875!
            '
            'lbArticulo
            '
            Me.lbArticulo.Height = 0.2!
            Me.lbArticulo.HyperLink = Nothing
            Me.lbArticulo.Left = 0.125!
            Me.lbArticulo.Name = "lbArticulo"
            Me.lbArticulo.Style = ""
            Me.lbArticulo.Text = "Código de Art.:"
            Me.lbArticulo.Top = 1!
            Me.lbArticulo.Width = 1!
            '
            'tbAlmacen
            '
            Me.tbAlmacen.Height = 0.2!
            Me.tbAlmacen.Left = 1.3125!
            Me.tbAlmacen.Name = "tbAlmacen"
            Me.tbAlmacen.Top = 1.625!
            Me.tbAlmacen.Width = 0.6875!
            '
            'Label14
            '
            Me.Label14.Height = 0.2!
            Me.Label14.HyperLink = Nothing
            Me.Label14.Left = 0.125!
            Me.Label14.Name = "Label14"
            Me.Label14.Style = ""
            Me.Label14.Text = "Almacen:"
            Me.Label14.Top = 1.625!
            Me.Label14.Width = 0.625!
            '
            'Label15
            '
            Me.Label15.Height = 0.2!
            Me.Label15.HyperLink = Nothing
            Me.Label15.Left = 3.125!
            Me.Label15.Name = "Label15"
            Me.Label15.Style = ""
            Me.Label15.Text = "Mes:"
            Me.Label15.Top = 1.625!
            Me.Label15.Width = 0.375!
            '
            'tbMes
            '
            Me.tbMes.Height = 0.2!
            Me.tbMes.Left = 4.0625!
            Me.tbMes.Name = "tbMes"
            Me.tbMes.Top = 1.625!
            Me.tbMes.Width = 0.6875!
            '
            'Label16
            '
            Me.Label16.Height = 0.2!
            Me.Label16.HyperLink = Nothing
            Me.Label16.Left = 3.625!
            Me.Label16.Name = "Label16"
            Me.Label16.Style = ""
            Me.Label16.Text = "Fecha de hoy:"
            Me.Label16.Top = 0.5625!
            Me.Label16.Width = 0.9375!
            '
            'tbCodAlmacen
            '
            Me.tbCodAlmacen.DataField = "CodAlmacen"
            Me.tbCodAlmacen.Height = 0.1968504!
            Me.tbCodAlmacen.Left = 0!
            Me.tbCodAlmacen.MultiLine = false
            Me.tbCodAlmacen.Name = "tbCodAlmacen"
            Me.tbCodAlmacen.Style = "text-align: center"
            Me.tbCodAlmacen.Text = "CodAlmacen"
            Me.tbCodAlmacen.Top = 0!
            Me.tbCodAlmacen.Width = 1!
            '
            'tbReferencia
            '
            Me.tbReferencia.DataField = "Referencia"
            Me.tbReferencia.Height = 0.1968504!
            Me.tbReferencia.Left = 1!
            Me.tbReferencia.MultiLine = false
            Me.tbReferencia.Name = "tbReferencia"
            Me.tbReferencia.Style = "text-align: center"
            Me.tbReferencia.Text = "Referencia"
            Me.tbReferencia.Top = 0!
            Me.tbReferencia.Width = 0.9375!
            '
            'tbFecha
            '
            Me.tbFecha.DataField = "Fecha"
            Me.tbFecha.Height = 0.1968504!
            Me.tbFecha.Left = 6!
            Me.tbFecha.MultiLine = false
            Me.tbFecha.Name = "tbFecha"
            Me.tbFecha.Style = "text-align: center"
            Me.tbFecha.Text = "Fecha"
            Me.tbFecha.Top = 0!
            Me.tbFecha.Width = 0.9375!
            '
            'tbDescripcion
            '
            Me.tbDescripcion.DataField = "Descripcion"
            Me.tbDescripcion.Height = 0.1968504!
            Me.tbDescripcion.Left = 2!
            Me.tbDescripcion.MultiLine = false
            Me.tbDescripcion.Name = "tbDescripcion"
            Me.tbDescripcion.Style = "text-align: center"
            Me.tbDescripcion.Text = "Descripcion"
            Me.tbDescripcion.Top = 0!
            Me.tbDescripcion.Width = 1.9375!
            '
            'tbEntradas
            '
            Me.tbEntradas.DataField = "Entradas"
            Me.tbEntradas.Height = 0.1968504!
            Me.tbEntradas.Left = 4!
            Me.tbEntradas.MultiLine = false
            Me.tbEntradas.Name = "tbEntradas"
            Me.tbEntradas.Style = "text-align: center"
            Me.tbEntradas.Text = "Entradas"
            Me.tbEntradas.Top = 0!
            Me.tbEntradas.Width = 0.9375!
            '
            'tbSalidas
            '
            Me.tbSalidas.DataField = "Salidas"
            Me.tbSalidas.Height = 0.1968504!
            Me.tbSalidas.Left = 5!
            Me.tbSalidas.MultiLine = false
            Me.tbSalidas.Name = "tbSalidas"
            Me.tbSalidas.Style = "text-align: center"
            Me.tbSalidas.Text = "Salidas"
            Me.tbSalidas.Top = 0!
            Me.tbSalidas.Width = 0.9375!
            '
            'lneBottomTable
            '
            Me.lneBottomTable.Height = 0!
            Me.lneBottomTable.Left = 0!
            Me.lneBottomTable.LineColor = System.Drawing.Color.FromArgb(CType(CType(192,Byte),Integer), CType(CType(192,Byte),Integer), CType(CType(192,Byte),Integer))
            Me.lneBottomTable.LineWeight = 1!
            Me.lneBottomTable.Name = "lneBottomTable"
            Me.lneBottomTable.Top = 0.197!
            Me.lneBottomTable.Width = 6.938001!
            Me.lneBottomTable.X1 = 0!
            Me.lneBottomTable.X2 = 6.938001!
            Me.lneBottomTable.Y1 = 0.197!
            Me.lneBottomTable.Y2 = 0.197!
            '
            'Line1
            '
            Me.Line1.Height = 0.1875!
            Me.Line1.Left = 5.006945!
            Me.Line1.LineWeight = 1!
            Me.Line1.Name = "Line1"
            Me.Line1.Top = 0.006944444!
            Me.Line1.Width = 0!
            Me.Line1.X1 = 5.006945!
            Me.Line1.X2 = 5.006945!
            Me.Line1.Y1 = 0.006944444!
            Me.Line1.Y2 = 0.1944444!
            '
            'Line2
            '
            Me.Line2.Height = 0.197!
            Me.Line2.Left = 5.006945!
            Me.Line2.LineColor = System.Drawing.Color.FromArgb(CType(CType(192,Byte),Integer), CType(CType(192,Byte),Integer), CType(CType(192,Byte),Integer))
            Me.Line2.LineWeight = 1!
            Me.Line2.Name = "Line2"
            Me.Line2.Top = 0!
            Me.Line2.Width = 0!
            Me.Line2.X1 = 5.006945!
            Me.Line2.X2 = 5.006945!
            Me.Line2.Y1 = 0!
            Me.Line2.Y2 = 0.197!
            '
            'Line3
            '
            Me.Line3.Height = 0.197!
            Me.Line3.Left = 6!
            Me.Line3.LineColor = System.Drawing.Color.FromArgb(CType(CType(192,Byte),Integer), CType(CType(192,Byte),Integer), CType(CType(192,Byte),Integer))
            Me.Line3.LineWeight = 1!
            Me.Line3.Name = "Line3"
            Me.Line3.Top = 0!
            Me.Line3.Width = 0!
            Me.Line3.X1 = 6!
            Me.Line3.X2 = 6!
            Me.Line3.Y1 = 0!
            Me.Line3.Y2 = 0.197!
            '
            'Line6
            '
            Me.Line6.Height = 0.197!
            Me.Line6.Left = 4.006945!
            Me.Line6.LineColor = System.Drawing.Color.FromArgb(CType(CType(192,Byte),Integer), CType(CType(192,Byte),Integer), CType(CType(192,Byte),Integer))
            Me.Line6.LineWeight = 1!
            Me.Line6.Name = "Line6"
            Me.Line6.Top = 0!
            Me.Line6.Width = 0.003471851!
            Me.Line6.X1 = 4.010417!
            Me.Line6.X2 = 4.006945!
            Me.Line6.Y1 = 0!
            Me.Line6.Y2 = 0.197!
            '
            'Line7
            '
            Me.Line7.Height = 0.197!
            Me.Line7.Left = 2.006944!
            Me.Line7.LineColor = System.Drawing.Color.FromArgb(CType(CType(192,Byte),Integer), CType(CType(192,Byte),Integer), CType(CType(192,Byte),Integer))
            Me.Line7.LineWeight = 1!
            Me.Line7.Name = "Line7"
            Me.Line7.Top = 0!
            Me.Line7.Width = 0!
            Me.Line7.X1 = 2.006944!
            Me.Line7.X2 = 2.006944!
            Me.Line7.Y1 = 0!
            Me.Line7.Y2 = 0.197!
            '
            'Line8
            '
            Me.Line8.Height = 0.197!
            Me.Line8.Left = 1!
            Me.Line8.LineColor = System.Drawing.Color.FromArgb(CType(CType(192,Byte),Integer), CType(CType(192,Byte),Integer), CType(CType(192,Byte),Integer))
            Me.Line8.LineWeight = 1!
            Me.Line8.Name = "Line8"
            Me.Line8.Top = 0!
            Me.Line8.Width = 0.006944418!
            Me.Line8.X1 = 1.006944!
            Me.Line8.X2 = 1!
            Me.Line8.Y1 = 0!
            Me.Line8.Y2 = 0.197!
            '
            'Line9
            '
            Me.Line9.Height = 0.197!
            Me.Line9.Left = 6.938001!
            Me.Line9.LineColor = System.Drawing.Color.FromArgb(CType(CType(192,Byte),Integer), CType(CType(192,Byte),Integer), CType(CType(192,Byte),Integer))
            Me.Line9.LineWeight = 1!
            Me.Line9.Name = "Line9"
            Me.Line9.Top = 0!
            Me.Line9.Width = 0!
            Me.Line9.X1 = 6.938001!
            Me.Line9.X2 = 6.938001!
            Me.Line9.Y1 = 0!
            Me.Line9.Y2 = 0.197!
            '
            'Line10
            '
            Me.Line10.Height = 0.197!
            Me.Line10.Left = 0.006944444!
            Me.Line10.LineColor = System.Drawing.Color.FromArgb(CType(CType(192,Byte),Integer), CType(CType(192,Byte),Integer), CType(CType(192,Byte),Integer))
            Me.Line10.LineWeight = 1!
            Me.Line10.Name = "Line10"
            Me.Line10.Top = 0!
            Me.Line10.Width = 0!
            Me.Line10.X1 = 0.006944444!
            Me.Line10.X2 = 0.006944444!
            Me.Line10.Y1 = 0!
            Me.Line10.Y2 = 0.197!
            '
            'Label4
            '
            Me.Label4.Height = 0.1968504!
            Me.Label4.HyperLink = Nothing
            Me.Label4.Left = 0.125!
            Me.Label4.Name = "Label4"
            Me.Label4.Style = ""
            Me.Label4.Text = "Comercial Dportenis, S.A. de C.V."
            Me.Label4.Top = 0.1968504!
            Me.Label4.Width = 2.362205!
            '
            'Label2
            '
            Me.Label2.Height = 0.2!
            Me.Label2.HyperLink = Nothing
            Me.Label2.Left = 8.4375!
            Me.Label2.Name = "Label2"
            Me.Label2.Style = "vertical-align: middle"
            Me.Label2.Text = "Página"
            Me.Label2.Top = 0.1875!
            Me.Label2.Width = 0.5078735!
            '
            'Label5
            '
            Me.Label5.Height = 0.2!
            Me.Label5.HyperLink = Nothing
            Me.Label5.Left = 8.4375!
            Me.Label5.Name = "Label5"
            Me.Label5.Style = "vertical-align: middle"
            Me.Label5.Text = "Página"
            Me.Label5.Top = 0.1875!
            Me.Label5.Width = 0.5078735!
            '
            'Label6
            '
            Me.Label6.Height = 0.2!
            Me.Label6.HyperLink = Nothing
            Me.Label6.Left = 8.4375!
            Me.Label6.Name = "Label6"
            Me.Label6.Style = "vertical-align: middle"
            Me.Label6.Text = "Página"
            Me.Label6.Top = 0.1875!
            Me.Label6.Width = 0.5078735!
            '
            'Label7
            '
            Me.Label7.Height = 0.2!
            Me.Label7.HyperLink = Nothing
            Me.Label7.Left = 5.3125!
            Me.Label7.Name = "Label7"
            Me.Label7.Style = ""
            Me.Label7.Text = "Página"
            Me.Label7.Top = 0.25!
            Me.Label7.Width = 0.5!
            '
            'tbPageNumber
            '
            Me.tbPageNumber.Height = 0.2!
            Me.tbPageNumber.Left = 5.8125!
            Me.tbPageNumber.Name = "tbPageNumber"
            Me.tbPageNumber.Style = "text-align: center; vertical-align: middle"
            Me.tbPageNumber.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
            Me.tbPageNumber.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount
            Me.tbPageNumber.Text = "####"
            Me.tbPageNumber.Top = 0.25!
            Me.tbPageNumber.Width = 0.375!
            '
            'Label8
            '
            Me.Label8.Height = 0.2!
            Me.Label8.HyperLink = Nothing
            Me.Label8.Left = 6.1875!
            Me.Label8.Name = "Label8"
            Me.Label8.Style = ""
            Me.Label8.Text = "de"
            Me.Label8.Top = 0.25!
            Me.Label8.Width = 0.1875!
            '
            'tbPageCount
            '
            Me.tbPageCount.Height = 0.2!
            Me.tbPageCount.Left = 6.375!
            Me.tbPageCount.Name = "tbPageCount"
            Me.tbPageCount.Style = "text-align: center; vertical-align: middle"
            Me.tbPageCount.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount
            Me.tbPageCount.Text = "####"
            Me.tbPageCount.Top = 0.25!
            Me.tbPageCount.Width = 0.375!
            '
            'ActiveReport1
            '
            Me.MasterReport = false
            Me.PageSettings.PaperHeight = 11!
            Me.PageSettings.PaperWidth = 8.5!
            Me.PrintWidth = 6.989583!
            Me.Sections.Add(Me.PageHeader)
            Me.Sections.Add(Me.Detail)
            Me.Sections.Add(Me.PageFooter)
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo"& _ 
                        "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit", "Heading1", "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei"& _ 
                        "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit", "Heading2", "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo"& _ 
                        "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit", "Heading3", "Normal"))
            CType(Me.lblReportTitle,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblFieldCodigo,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblFieldReferencia,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblFieldFecha,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblFieldDescripcion,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblFieldEntrada,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblFieldSalida,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbSaldoIni,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbSaldoFin,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblReportDate,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbCorridaIni,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbCorridaFin,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbCorDescripcion,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label9,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label10,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label11,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label12,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label13,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbArticulo,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lbArticulo,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbAlmacen,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label14,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label15,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbMes,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label16,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbCodAlmacen,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbReferencia,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbFecha,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbDescripcion,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbEntradas,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbSalidas,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label5,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label6,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label7,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbPageNumber,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label8,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbPageCount,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        
	End Sub

#End Region
    Private Sub Detail_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles Detail.Format

        Detail.AddBookmark("Reporte de Movimiento de Articulos\Pagína " & Me.PageNumber.ToString & "\")

    End Sub
End Class