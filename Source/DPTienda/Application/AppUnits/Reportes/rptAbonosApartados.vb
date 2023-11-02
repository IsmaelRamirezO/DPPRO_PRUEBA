Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Imports DportenisPro.DPTienda.ApplicationUnits.AbonosApartadosAU
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU

Public Class rptAbonosApartados
    Inherits DataDynamics.ActiveReports.ActiveReport



    Public Function CrearTabla() As DataTable
        Dim dt As New DataTable("AbonosApartados")

        dt.Columns.Add(New DataColumn("FolioAbono", GetType(Integer)))
        dt.Columns.Add(New DataColumn("CodFormaPago", GetType(String)))
        dt.Columns.Add(New DataColumn("Abono", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("Estatus", GetType(String)))
        dt.Columns.Add(New DataColumn("SaldoNuevo", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("ApartadoID", GetType(Integer)))
        dt.Columns.Add(New DataColumn("Usuario", GetType(String)))
        dt.Columns.Add(New DataColumn("Fecha", GetType(String)))
        dt.Columns.Add(New DataColumn("StatusRegistro", GetType(Integer)))

        dt.AcceptChanges()
        Return dt

    End Function


    Public Sub AddNewRecord(ByVal oRow As DataRow, ByRef dtTable As DataTable, ByVal bAgregar As Boolean)
        Dim row As DataRow = dtTable.NewRow()

        If bAgregar Then
            row("Abono") = -1 * oRow!Abono
            row("Estatus") = "Activo"
            row("SaldoNuevo") = oRow!SaldoNuevo - (oRow!Abono * -1)
            row("StatusRegistro") = 1
        Else
            row("Abono") = oRow!Abono
            row("Estatus") = oRow!Estatus
            row("SaldoNuevo") = oRow!SaldoNuevo
            row("StatusRegistro") = oRow!StatusRegistro
        End If
        row("FolioAbono") = oRow!FolioAbono
        row("CodFormaPago") = oRow!CodFormaPago
        row("ApartadoId") = oRow!ApartadoId
        row("Fecha") = (oRow!Fecha).ToString.Substring(0, 10)
        row("Usuario") = oRow!Usuario

        dtTable.Rows.Add(row)
    End Sub

    Public Sub New(ByVal Fecha As DateTime)

        MyBase.New()
        InitializeComponent()
        Dim oSAPMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        Dim oCatalogoAlmacenMgr As New CatalogoAlmacenesManager(oAppContext)
        Dim oAlmacen As Almacen

        oAlmacen = oCatalogoAlmacenMgr.Load(oSAPMgr.Read_Centros) 'oAppContext.ApplicationConfiguration.Almacen)

        lblFecha.Text = Format(Date.Now, "dd/MM/yyyy")
        LblSucursal.Text = oAlmacen.ID & Space(1) & oAlmacen.Descripcion
        LblFechaDE.Text = Format(Fecha, "dd-MM-yyyy")
        LblFechaAL.Text = Format(Fecha, "dd-MM-yyyy")

        Dim oAbonosApartadosMgr As AbonosApartadosManager
        oAbonosApartadosMgr = New AbonosApartadosManager(oAppContext)
        Dim dsAbonosApartados As DataSet

        dsAbonosApartados = oAbonosApartadosMgr.GetByDate(Fecha).Copy
        Dim dtAllRecords As DataTable = CrearTabla()

        If Not dsAbonosApartados Is Nothing Then
            Dim dtAbonos As DataTable = dsAbonosApartados.Tables(0)
            For Each oRow As DataRow In dtAbonos.Rows
                If oRow!StatusRegistro = 0 Then
                    AddNewRecord(oRow, dtAllRecords, True)
                    AddNewRecord(oRow, dtAllRecords, False)
                Else
                    AddNewRecord(oRow, dtAllRecords, False)
                End If
            Next

        End If

        Dim ds As New DataSet

        ds.Tables.Add(dtAllRecords)


        Me.DataSource = ds 'dsAbonosApartados
        Me.DataMember = "AbonosApartados"
    End Sub

#Region "ActiveReports Designer generated code"
    Private WithEvents ReportHeader As ReportHeader = Nothing
    Private WithEvents GroupHeader1 As GroupHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents GroupFooter1 As GroupFooter = Nothing
    Private WithEvents ReportFooter As ReportFooter = Nothing
	Private Shape1 As Shape = Nothing
	Private Label3 As Label = Nothing
	Private Label4 As Label = Nothing
	Private Label5 As Label = Nothing
	Private Label6 As Label = Nothing
	Private Label7 As Label = Nothing
	Private Label8 As Label = Nothing
	Private Label9 As Label = Nothing
	Private Label1 As Label = Nothing
	Private Label2 As Label = Nothing
	Private lblFecha As Label = Nothing
	Private Label11 As Label = Nothing
	Private LblFechaDE As Label = Nothing
	Private Label12 As Label = Nothing
	Private LblFechaAL As Label = Nothing
	Private LblSucursal As Label = Nothing
	Private Label13 As Label = Nothing
	Private Line1 As Line = Nothing
	Private lblFolioAbono As Label = Nothing
	Private lblFormaPago As Label = Nothing
	Private lblFolioApartado As Label = Nothing
	Private lblUsuario As Label = Nothing
	Private TextBox1 As TextBox = Nothing
	Private TextBox2 As TextBox = Nothing
	Private TextBox3 As TextBox = Nothing
    Private Shape2 As Shape = Nothing
    Friend WithEvents lblEstatus As DataDynamics.ActiveReports.Label
    Friend WithEvents Label10 As DataDynamics.ActiveReports.Label
	Private TextBox4 As TextBox = Nothing
	Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptAbonosApartados))
        Me.Detail = New DataDynamics.ActiveReports.Detail()
        Me.lblFolioAbono = New DataDynamics.ActiveReports.Label()
        Me.lblFormaPago = New DataDynamics.ActiveReports.Label()
        Me.lblFolioApartado = New DataDynamics.ActiveReports.Label()
        Me.lblUsuario = New DataDynamics.ActiveReports.Label()
        Me.TextBox1 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox2 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox3 = New DataDynamics.ActiveReports.TextBox()
        Me.lblEstatus = New DataDynamics.ActiveReports.Label()
        Me.ReportHeader = New DataDynamics.ActiveReports.ReportHeader()
        Me.ReportFooter = New DataDynamics.ActiveReports.ReportFooter()
        Me.Shape2 = New DataDynamics.ActiveReports.Shape()
        Me.TextBox4 = New DataDynamics.ActiveReports.TextBox()
        Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader()
        Me.Shape1 = New DataDynamics.ActiveReports.Shape()
        Me.Label3 = New DataDynamics.ActiveReports.Label()
        Me.Label4 = New DataDynamics.ActiveReports.Label()
        Me.Label5 = New DataDynamics.ActiveReports.Label()
        Me.Label6 = New DataDynamics.ActiveReports.Label()
        Me.Label7 = New DataDynamics.ActiveReports.Label()
        Me.Label8 = New DataDynamics.ActiveReports.Label()
        Me.Label9 = New DataDynamics.ActiveReports.Label()
        Me.Label1 = New DataDynamics.ActiveReports.Label()
        Me.Label2 = New DataDynamics.ActiveReports.Label()
        Me.lblFecha = New DataDynamics.ActiveReports.Label()
        Me.Label11 = New DataDynamics.ActiveReports.Label()
        Me.LblFechaDE = New DataDynamics.ActiveReports.Label()
        Me.Label12 = New DataDynamics.ActiveReports.Label()
        Me.LblFechaAL = New DataDynamics.ActiveReports.Label()
        Me.LblSucursal = New DataDynamics.ActiveReports.Label()
        Me.Label13 = New DataDynamics.ActiveReports.Label()
        Me.Line1 = New DataDynamics.ActiveReports.Line()
        Me.Label10 = New DataDynamics.ActiveReports.Label()
        Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter()
        CType(Me.lblFolioAbono, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFormaPago, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFolioApartado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblUsuario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblEstatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblFechaDE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblFechaAL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblSucursal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.ColumnSpacing = 0.0!
        Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.lblFolioAbono, Me.lblFormaPago, Me.lblFolioApartado, Me.lblUsuario, Me.TextBox1, Me.TextBox2, Me.TextBox3, Me.lblEstatus})
        Me.Detail.Height = 0.2!
        Me.Detail.Name = "Detail"
        '
        'lblFolioAbono
        '
        Me.lblFolioAbono.DataField = "FolioAbono"
        Me.lblFolioAbono.Height = 0.2!
        Me.lblFolioAbono.HyperLink = Nothing
        Me.lblFolioAbono.Left = 0.0625!
        Me.lblFolioAbono.Name = "lblFolioAbono"
        Me.lblFolioAbono.Style = "text-align: center; font-size: 8.25pt"
        Me.lblFolioAbono.Text = "Label10"
        Me.lblFolioAbono.Top = 0.0!
        Me.lblFolioAbono.Width = 0.8125!
        '
        'lblFormaPago
        '
        Me.lblFormaPago.DataField = "CodFormaPago"
        Me.lblFormaPago.Height = 0.2!
        Me.lblFormaPago.HyperLink = Nothing
        Me.lblFormaPago.Left = 1.0!
        Me.lblFormaPago.Name = "lblFormaPago"
        Me.lblFormaPago.Style = "text-align: center; font-size: 8.25pt"
        Me.lblFormaPago.Text = "Label11"
        Me.lblFormaPago.Top = 0.0!
        Me.lblFormaPago.Width = 0.875!
        '
        'lblFolioApartado
        '
        Me.lblFolioApartado.DataField = "ApartadoID"
        Me.lblFolioApartado.Height = 0.2!
        Me.lblFolioApartado.HyperLink = Nothing
        Me.lblFolioApartado.Left = 2.8675!
        Me.lblFolioApartado.Name = "lblFolioApartado"
        Me.lblFolioApartado.Style = "text-align: center; font-size: 8.25pt"
        Me.lblFolioApartado.Text = "Label13"
        Me.lblFolioApartado.Top = 0.0!
        Me.lblFolioApartado.Width = 0.875!
        '
        'lblUsuario
        '
        Me.lblUsuario.DataField = "Usuario"
        Me.lblUsuario.Height = 0.2!
        Me.lblUsuario.HyperLink = Nothing
        Me.lblUsuario.Left = 4.764999!
        Me.lblUsuario.Name = "lblUsuario"
        Me.lblUsuario.Style = "text-align: center; font-size: 8.25pt"
        Me.lblUsuario.Text = "Label15"
        Me.lblUsuario.Top = 0.0!
        Me.lblUsuario.Width = 0.75!
        '
        'TextBox1
        '
        Me.TextBox1.DataField = "Abono"
        Me.TextBox1.Height = 0.2!
        Me.TextBox1.Left = 1.93!
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.OutputFormat = resources.GetString("TextBox1.OutputFormat")
        Me.TextBox1.Style = "text-align: right; font-size: 8.25pt"
        Me.TextBox1.Text = "TextBox1"
        Me.TextBox1.Top = 0.0!
        Me.TextBox1.Width = 0.8125!
        '
        'TextBox2
        '
        Me.TextBox2.DataField = "SaldoNuevo"
        Me.TextBox2.Height = 0.2!
        Me.TextBox2.Left = 3.849!
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.OutputFormat = resources.GetString("TextBox2.OutputFormat")
        Me.TextBox2.Style = "text-align: right; font-size: 8.25pt"
        Me.TextBox2.Text = "TextBox2"
        Me.TextBox2.Top = 0.0!
        Me.TextBox2.Width = 0.7710001!
        '
        'TextBox3
        '
        Me.TextBox3.DataField = "Fecha"
        Me.TextBox3.Height = 0.2!
        Me.TextBox3.Left = 5.577499!
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.OutputFormat = resources.GetString("TextBox3.OutputFormat")
        Me.TextBox3.Style = "font-size: 8.25pt"
        Me.TextBox3.Text = "TextBox3"
        Me.TextBox3.Top = 0.0!
        Me.TextBox3.Width = 0.6875!
        '
        'lblEstatus
        '
        Me.lblEstatus.DataField = "Estatus"
        Me.lblEstatus.Height = 0.2!
        Me.lblEstatus.HyperLink = Nothing
        Me.lblEstatus.Left = 6.3!
        Me.lblEstatus.Name = "lblEstatus"
        Me.lblEstatus.Style = "text-align: center; font-size: 8.25pt"
        Me.lblEstatus.Text = "Estatus"
        Me.lblEstatus.Top = 0.0!
        Me.lblEstatus.Width = 0.6170001!
        '
        'ReportHeader
        '
        Me.ReportHeader.Height = 0.0!
        Me.ReportHeader.Name = "ReportHeader"
        '
        'ReportFooter
        '
        Me.ReportFooter.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape2, Me.TextBox4})
        Me.ReportFooter.Height = 0.28125!
        Me.ReportFooter.Name = "ReportFooter"
        '
        'Shape2
        '
        Me.Shape2.Height = 0.25!
        Me.Shape2.Left = 0.0!
        Me.Shape2.Name = "Shape2"
        Me.Shape2.RoundingRadius = 9.999999!
        Me.Shape2.Top = 0.0!
        Me.Shape2.Width = 6.917!
        '
        'TextBox4
        '
        Me.TextBox4.DataField = "Abono"
        Me.TextBox4.Height = 0.2!
        Me.TextBox4.Left = 1.94!
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.OutputFormat = resources.GetString("TextBox4.OutputFormat")
        Me.TextBox4.Style = "text-align: right; font-size: 8.25pt"
        Me.TextBox4.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
        Me.TextBox4.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
        Me.TextBox4.Text = "TextBox4"
        Me.TextBox4.Top = 0.04!
        Me.TextBox4.Width = 0.8125!
        '
        'GroupHeader1
        '
        Me.GroupHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape1, Me.Label3, Me.Label4, Me.Label5, Me.Label6, Me.Label7, Me.Label8, Me.Label9, Me.Label1, Me.Label2, Me.lblFecha, Me.Label11, Me.LblFechaDE, Me.Label12, Me.LblFechaAL, Me.LblSucursal, Me.Label13, Me.Line1, Me.Label10})
        Me.GroupHeader1.Height = 1.022917!
        Me.GroupHeader1.Name = "GroupHeader1"
        '
        'Shape1
        '
        Me.Shape1.Height = 0.875!
        Me.Shape1.Left = 0.0!
        Me.Shape1.Name = "Shape1"
        Me.Shape1.RoundingRadius = 9.999999!
        Me.Shape1.Top = 0.0!
        Me.Shape1.Width = 6.917!
        '
        'Label3
        '
        Me.Label3.Height = 0.2!
        Me.Label3.HyperLink = Nothing
        Me.Label3.Left = 0.0625!
        Me.Label3.Name = "Label3"
        Me.Label3.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
        Me.Label3.Text = "Folio Abono"
        Me.Label3.Top = 0.6875!
        Me.Label3.Width = 0.8125!
        '
        'Label4
        '
        Me.Label4.Height = 0.2!
        Me.Label4.HyperLink = Nothing
        Me.Label4.Left = 0.9375!
        Me.Label4.Name = "Label4"
        Me.Label4.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
        Me.Label4.Text = "Forma de Pago"
        Me.Label4.Top = 0.6875!
        Me.Label4.Width = 1.0!
        '
        'Label5
        '
        Me.Label5.Height = 0.2!
        Me.Label5.HyperLink = Nothing
        Me.Label5.Left = 2.128!
        Me.Label5.Name = "Label5"
        Me.Label5.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
        Me.Label5.Text = "Importe"
        Me.Label5.Top = 0.6875!
        Me.Label5.Width = 0.6144998!
        '
        'Label6
        '
        Me.Label6.Height = 0.2!
        Me.Label6.HyperLink = Nothing
        Me.Label6.Left = 2.805!
        Me.Label6.Name = "Label6"
        Me.Label6.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
        Me.Label6.Text = "Folio Apartado"
        Me.Label6.Top = 0.6875!
        Me.Label6.Width = 0.9375!
        '
        'Label7
        '
        Me.Label7.Height = 0.2!
        Me.Label7.HyperLink = Nothing
        Me.Label7.Left = 4.023!
        Me.Label7.Name = "Label7"
        Me.Label7.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
        Me.Label7.Text = "Saldo"
        Me.Label7.Top = 0.687!
        Me.Label7.Width = 0.677!
        '
        'Label8
        '
        Me.Label8.Height = 0.2!
        Me.Label8.HyperLink = Nothing
        Me.Label8.Left = 5.617499!
        Me.Label8.Name = "Label8"
        Me.Label8.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
        Me.Label8.Text = "Fecha"
        Me.Label8.Top = 0.6875!
        Me.Label8.Width = 0.4895005!
        '
        'Label9
        '
        Me.Label9.Height = 0.2!
        Me.Label9.HyperLink = Nothing
        Me.Label9.Left = 4.742499!
        Me.Label9.Name = "Label9"
        Me.Label9.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
        Me.Label9.Text = "Usuario"
        Me.Label9.Top = 0.6875!
        Me.Label9.Width = 0.8125!
        '
        'Label1
        '
        Me.Label1.Height = 0.2!
        Me.Label1.HyperLink = Nothing
        Me.Label1.Left = 2.390625!
        Me.Label1.Name = "Label1"
        Me.Label1.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
        Me.Label1.Text = "Reporte de Abonos Apartados"
        Me.Label1.Top = 0.0!
        Me.Label1.Width = 1.875!
        '
        'Label2
        '
        Me.Label2.Height = 0.1875!
        Me.Label2.HyperLink = Nothing
        Me.Label2.Left = 0.0625!
        Me.Label2.Name = "Label2"
        Me.Label2.Style = "font-weight: bold; font-size: 8.25pt; font-family: Arial"
        Me.Label2.Text = "Fecha :"
        Me.Label2.Top = 0.0!
        Me.Label2.Width = 0.5!
        '
        'lblFecha
        '
        Me.lblFecha.Height = 0.2!
        Me.lblFecha.HyperLink = Nothing
        Me.lblFecha.Left = 0.5625!
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Style = "font-size: 8.25pt"
        Me.lblFecha.Text = "Fecha"
        Me.lblFecha.Top = 0.0!
        Me.lblFecha.Width = 0.875!
        '
        'Label11
        '
        Me.Label11.Height = 0.1811025!
        Me.Label11.HyperLink = Nothing
        Me.Label11.Left = 2.125!
        Me.Label11.Name = "Label11"
        Me.Label11.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8." & _
    "25pt; font-family: Arial"
        Me.Label11.Text = "De:"
        Me.Label11.Top = 0.1875!
        Me.Label11.Width = 0.2810042!
        '
        'LblFechaDE
        '
        Me.LblFechaDE.Height = 0.1811025!
        Me.LblFechaDE.HyperLink = Nothing
        Me.LblFechaDE.Left = 2.4375!
        Me.LblFechaDE.Name = "LblFechaDE"
        Me.LblFechaDE.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: normal; font-size: " & _
    "8.25pt; font-family: Arial"
        Me.LblFechaDE.Text = "LblFechaDE"
        Me.LblFechaDE.Top = 0.1875!
        Me.LblFechaDE.Width = 0.9685042!
        '
        'Label12
        '
        Me.Label12.Height = 0.1811025!
        Me.Label12.HyperLink = Nothing
        Me.Label12.Left = 3.4375!
        Me.Label12.Name = "Label12"
        Me.Label12.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8." & _
    "25pt; font-family: Arial"
        Me.Label12.Text = "Al:"
        Me.Label12.Top = 0.1875!
        Me.Label12.Width = 0.2810042!
        '
        'LblFechaAL
        '
        Me.LblFechaAL.Height = 0.1811025!
        Me.LblFechaAL.HyperLink = Nothing
        Me.LblFechaAL.Left = 3.6875!
        Me.LblFechaAL.Name = "LblFechaAL"
        Me.LblFechaAL.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: normal; font-size: " & _
    "8.25pt; font-family: Arial"
        Me.LblFechaAL.Text = "LblFechaAL"
        Me.LblFechaAL.Top = 0.1875!
        Me.LblFechaAL.Width = 0.9685042!
        '
        'LblSucursal
        '
        Me.LblSucursal.Height = 0.1811025!
        Me.LblSucursal.HyperLink = Nothing
        Me.LblSucursal.Left = 2.240501!
        Me.LblSucursal.Name = "LblSucursal"
        Me.LblSucursal.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: normal; font-size: " & _
    "8.25pt; font-family: Arial"
        Me.LblSucursal.Text = "LblSucursal"
        Me.LblSucursal.Top = 0.375!
        Me.LblSucursal.Width = 3.448326!
        '
        'Label13
        '
        Me.Label13.Height = 0.1811025!
        Me.Label13.HyperLink = Nothing
        Me.Label13.Left = 1.553!
        Me.Label13.Name = "Label13"
        Me.Label13.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8." & _
    "25pt; font-family: Arial"
        Me.Label13.Text = "Sucursal:"
        Me.Label13.Top = 0.375!
        Me.Label13.Width = 0.5625!
        '
        'Line1
        '
        Me.Line1.Height = 0.0!
        Me.Line1.Left = 0.0!
        Me.Line1.LineWeight = 1.0!
        Me.Line1.Name = "Line1"
        Me.Line1.Top = 0.625!
        Me.Line1.Width = 6.917!
        Me.Line1.X1 = 0.0!
        Me.Line1.X2 = 6.917!
        Me.Line1.Y1 = 0.625!
        Me.Line1.Y2 = 0.625!
        '
        'Label10
        '
        Me.Label10.Height = 0.1500001!
        Me.Label10.HyperLink = Nothing
        Me.Label10.Left = 6.239!
        Me.Label10.Name = "Label10"
        Me.Label10.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
        Me.Label10.Text = "Estatus"
        Me.Label10.Top = 0.687!
        Me.Label10.Width = 0.6150002!
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Height = 0.0!
        Me.GroupFooter1.Name = "GroupFooter1"
        '
        'rptAbonosApartados
        '
        Me.MasterReport = False
        Me.PageSettings.Margins.Bottom = 0.39375!
        Me.PageSettings.Margins.Left = 0.39375!
        Me.PageSettings.Margins.Right = 0.39375!
        Me.PageSettings.Margins.Top = 0.9840278!
        Me.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Portrait
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 6.96875!
        Me.Sections.Add(Me.ReportHeader)
        Me.Sections.Add(Me.GroupHeader1)
        Me.Sections.Add(Me.Detail)
        Me.Sections.Add(Me.GroupFooter1)
        Me.Sections.Add(Me.ReportFooter)
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" & _
            "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei" & _
            "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" & _
            "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit", "Heading3", "Normal"))
        CType(Me.lblFolioAbono, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFormaPago, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFolioApartado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblUsuario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblEstatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblFechaDE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblFechaAL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblSucursal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

#End Region

End Class
