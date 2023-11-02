Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Imports DportenisPro.DPTienda.ApplicationUnits.AbonoCreditoDirectoTienda
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes


Public Class frmAbonosCreditoDirecto

    Inherits DataDynamics.ActiveReports.ActiveReport

    Public Sub New(ByVal Fecha As DateTime, ByVal Data As DataSet)

        MyBase.New()

        InitializeComponent()

        lblFecha.Text = Format(Date.Now, "dd-MM-yyyy")

        LblFechaDE.Text = Format(Fecha, "dd-MM-yyyy")

        LblFechaAL.Text = Format(Fecha, "dd-MM-yyyy")

        LblSucursal.Text = GetAlmacen()

        Me.DataSource = Data

        Me.DataMember = Data.Tables(0).TableName

    End Sub

    Private Function GetAlmacen() As String

        Dim oAlmacenMgr As New CatalogoAlmacenesManager(oAppContext)
        Dim oAlmacen As Almacen
        Dim strAlmacen As String = oAppContext.ApplicationConfiguration.Almacen
        Dim AlmacenDescripcion As String = String.Empty
        oAlmacen = oAlmacenMgr.Create
        oAlmacenMgr.LoadInto(strAlmacen, oAlmacen)

        AlmacenDescripcion = UCase(strAlmacen & " " & oAlmacen.Descripcion)

        oAlmacen = Nothing
        oAlmacenMgr = Nothing

        Return AlmacenDescripcion

    End Function

#Region "ActiveReports Designer generated code"
    Private WithEvents ReportHeader As ReportHeader = Nothing
    Private WithEvents GroupHeader1 As GroupHeader = Nothing
    Private WithEvents ghAbonoID As GroupHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents GroupFooter2 As GroupFooter = Nothing
    Private WithEvents GroupFooter1 As GroupFooter = Nothing
    Private WithEvents ReportFooter As ReportFooter = Nothing
	Private Shape1 As Shape = Nothing
	Private Label1 As Label = Nothing
	Private Label3 As Label = Nothing
	Private Label4 As Label = Nothing
	Private Label5 As Label = Nothing
	Private Label6 As Label = Nothing
	Private Label7 As Label = Nothing
	Private Label8 As Label = Nothing
	Private Label9 As Label = Nothing
	Private Label10 As Label = Nothing
	Private Label2 As Label = Nothing
	Private lblFecha As Label = Nothing
	Private Label11 As Label = Nothing
	Private LblFechaDE As Label = Nothing
	Private Label12 As Label = Nothing
	Private LblFechaAL As Label = Nothing
	Private LblSucursal As Label = Nothing
	Private Label13 As Label = Nothing
	Private Line1 As Line = Nothing
	Private TextBox1 As TextBox = Nothing
	Private TextBox2 As TextBox = Nothing
	Private TextBox3 As TextBox = Nothing
	Private TextBox8 As TextBox = Nothing
	Private TextBox9 As TextBox = Nothing
	Private TextBox4 As TextBox = Nothing
	Private TextBox5 As TextBox = Nothing
	Private TextBox6 As TextBox = Nothing
	Private TextBox7 As TextBox = Nothing
	Private Shape2 As Shape = Nothing
	Private txtTotal As TextBox = Nothing
	Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAbonosCreditoDirecto))
            Me.Detail = New DataDynamics.ActiveReports.Detail()
            Me.ReportHeader = New DataDynamics.ActiveReports.ReportHeader()
            Me.ReportFooter = New DataDynamics.ActiveReports.ReportFooter()
            Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader()
            Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter()
            Me.ghAbonoID = New DataDynamics.ActiveReports.GroupHeader()
            Me.GroupFooter2 = New DataDynamics.ActiveReports.GroupFooter()
            Me.Shape1 = New DataDynamics.ActiveReports.Shape()
            Me.Label1 = New DataDynamics.ActiveReports.Label()
            Me.Label3 = New DataDynamics.ActiveReports.Label()
            Me.Label4 = New DataDynamics.ActiveReports.Label()
            Me.Label5 = New DataDynamics.ActiveReports.Label()
            Me.Label6 = New DataDynamics.ActiveReports.Label()
            Me.Label7 = New DataDynamics.ActiveReports.Label()
            Me.Label8 = New DataDynamics.ActiveReports.Label()
            Me.Label9 = New DataDynamics.ActiveReports.Label()
            Me.Label10 = New DataDynamics.ActiveReports.Label()
            Me.Label2 = New DataDynamics.ActiveReports.Label()
            Me.lblFecha = New DataDynamics.ActiveReports.Label()
            Me.Label11 = New DataDynamics.ActiveReports.Label()
            Me.LblFechaDE = New DataDynamics.ActiveReports.Label()
            Me.Label12 = New DataDynamics.ActiveReports.Label()
            Me.LblFechaAL = New DataDynamics.ActiveReports.Label()
            Me.LblSucursal = New DataDynamics.ActiveReports.Label()
            Me.Label13 = New DataDynamics.ActiveReports.Label()
            Me.Line1 = New DataDynamics.ActiveReports.Line()
            Me.TextBox1 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox2 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox3 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox8 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox9 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox4 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox5 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox6 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox7 = New DataDynamics.ActiveReports.TextBox()
            Me.Shape2 = New DataDynamics.ActiveReports.Shape()
            Me.txtTotal = New DataDynamics.ActiveReports.TextBox()
            CType(Me.Label1,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label3,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label5,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label6,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label7,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label8,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label9,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label10,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblFecha,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label11,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.LblFechaDE,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label12,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.LblFechaAL,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.LblSucursal,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label13,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox1,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox2,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox3,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox8,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox9,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox4,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox5,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox6,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox7,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtTotal,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
            '
            'Detail
            '
            Me.Detail.ColumnSpacing = 0!
            Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TextBox4, Me.TextBox5, Me.TextBox6, Me.TextBox7})
            Me.Detail.Height = 0.2!
            Me.Detail.Name = "Detail"
            '
            'ReportHeader
            '
            Me.ReportHeader.Height = 0!
            Me.ReportHeader.Name = "ReportHeader"
            '
            'ReportFooter
            '
            Me.ReportFooter.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape2, Me.txtTotal})
            Me.ReportFooter.Height = 0.28125!
            Me.ReportFooter.Name = "ReportFooter"
            '
            'GroupHeader1
            '
            Me.GroupHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape1, Me.Label1, Me.Label3, Me.Label4, Me.Label5, Me.Label6, Me.Label7, Me.Label8, Me.Label9, Me.Label10, Me.Label2, Me.lblFecha, Me.Label11, Me.LblFechaDE, Me.Label12, Me.LblFechaAL, Me.LblSucursal, Me.Label13, Me.Line1})
            Me.GroupHeader1.Height = 0.9166667!
            Me.GroupHeader1.Name = "GroupHeader1"
            '
            'GroupFooter1
            '
            Me.GroupFooter1.Height = 0!
            Me.GroupFooter1.Name = "GroupFooter1"
            '
            'ghAbonoID
            '
            Me.ghAbonoID.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TextBox1, Me.TextBox2, Me.TextBox3, Me.TextBox8, Me.TextBox9})
            Me.ghAbonoID.DataField = "AbonoID"
            Me.ghAbonoID.Height = 0.2076389!
            Me.ghAbonoID.Name = "ghAbonoID"
            '
            'GroupFooter2
            '
            Me.GroupFooter2.Height = 0!
            Me.GroupFooter2.Name = "GroupFooter2"
            '
            'Shape1
            '
            Me.Shape1.Height = 0.875!
            Me.Shape1.Left = 0!
            Me.Shape1.Name = "Shape1"
            Me.Shape1.RoundingRadius = 9.999999!
            Me.Shape1.Top = 0!
            Me.Shape1.Width = 6.875!
            '
            'Label1
            '
            Me.Label1.Height = 0.2!
            Me.Label1.HyperLink = Nothing
            Me.Label1.Left = 2.5625!
            Me.Label1.Name = "Label1"
            Me.Label1.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
            Me.Label1.Text = "Abonos Credito Directo"
            Me.Label1.Top = 0!
            Me.Label1.Width = 1.875!
            '
            'Label3
            '
            Me.Label3.Height = 0.2!
            Me.Label3.HyperLink = Nothing
            Me.Label3.Left = 6.25!
            Me.Label3.Name = "Label3"
            Me.Label3.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
            Me.Label3.Text = "Usuario"
            Me.Label3.Top = 0.6875!
            Me.Label3.Width = 0.5625!
            '
            'Label4
            '
            Me.Label4.Height = 0.2!
            Me.Label4.HyperLink = Nothing
            Me.Label4.Left = 2.75!
            Me.Label4.Name = "Label4"
            Me.Label4.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
            Me.Label4.Text = "Formas de Pago"
            Me.Label4.Top = 0.6875!
            Me.Label4.Width = 1.0625!
            '
            'Label5
            '
            Me.Label5.Height = 0.2!
            Me.Label5.HyperLink = Nothing
            Me.Label5.Left = 3.875!
            Me.Label5.Name = "Label5"
            Me.Label5.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
            Me.Label5.Text = "Abono"
            Me.Label5.Top = 0.6875!
            Me.Label5.Width = 0.5625!
            '
            'Label6
            '
            Me.Label6.Height = 0.2!
            Me.Label6.HyperLink = Nothing
            Me.Label6.Left = 4.5!
            Me.Label6.Name = "Label6"
            Me.Label6.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
            Me.Label6.Text = "Folio Factura"
            Me.Label6.Top = 0.6875!
            Me.Label6.Width = 0.875!
            '
            'Label7
            '
            Me.Label7.Height = 0.2!
            Me.Label7.HyperLink = Nothing
            Me.Label7.Left = 5.4375!
            Me.Label7.Name = "Label7"
            Me.Label7.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
            Me.Label7.Text = "Saldo"
            Me.Label7.Top = 0.6875!
            Me.Label7.Width = 0.75!
            '
            'Label8
            '
            Me.Label8.Height = 0.2!
            Me.Label8.HyperLink = Nothing
            Me.Label8.Left = 0!
            Me.Label8.Name = "Label8"
            Me.Label8.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
            Me.Label8.Text = "Asociado"
            Me.Label8.Top = 0.6875!
            Me.Label8.Width = 0.75!
            '
            'Label9
            '
            Me.Label9.Height = 0.2!
            Me.Label9.HyperLink = Nothing
            Me.Label9.Left = 0.8125!
            Me.Label9.Name = "Label9"
            Me.Label9.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
            Me.Label9.Text = "Folio Abono"
            Me.Label9.Top = 0.6875!
            Me.Label9.Width = 0.8125!
            '
            'Label10
            '
            Me.Label10.Height = 0.2!
            Me.Label10.HyperLink = Nothing
            Me.Label10.Left = 1.6875!
            Me.Label10.Name = "Label10"
            Me.Label10.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
            Me.Label10.Text = "Total Abono"
            Me.Label10.Top = 0.6875!
            Me.Label10.Width = 1!
            '
            'Label2
            '
            Me.Label2.Height = 0.1875!
            Me.Label2.HyperLink = Nothing
            Me.Label2.Left = 0.0625!
            Me.Label2.Name = "Label2"
            Me.Label2.Style = "font-weight: bold; font-size: 8.25pt; font-family: Arial"
            Me.Label2.Text = "Fecha :"
            Me.Label2.Top = 0!
            Me.Label2.Width = 0.4375!
            '
            'lblFecha
            '
            Me.lblFecha.Height = 0.2!
            Me.lblFecha.HyperLink = Nothing
            Me.lblFecha.Left = 0.5625!
            Me.lblFecha.Name = "lblFecha"
            Me.lblFecha.Style = "font-size: 8.25pt"
            Me.lblFecha.Text = "Fecha"
            Me.lblFecha.Top = 0!
            Me.lblFecha.Width = 0.875!
            '
            'Label11
            '
            Me.Label11.Height = 0.1811025!
            Me.Label11.HyperLink = Nothing
            Me.Label11.Left = 2.25!
            Me.Label11.Name = "Label11"
            Me.Label11.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8."& _ 
                "25pt; font-family: Arial"
            Me.Label11.Text = "De:"
            Me.Label11.Top = 0.1875!
            Me.Label11.Width = 0.2810042!
            '
            'LblFechaDE
            '
            Me.LblFechaDE.Height = 0.1811025!
            Me.LblFechaDE.HyperLink = Nothing
            Me.LblFechaDE.Left = 2.5625!
            Me.LblFechaDE.Name = "LblFechaDE"
            Me.LblFechaDE.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: normal; font-size: "& _ 
                "8.25pt; font-family: Arial"
            Me.LblFechaDE.Text = "LblFechaDE"
            Me.LblFechaDE.Top = 0.1875!
            Me.LblFechaDE.Width = 0.9685042!
            '
            'Label12
            '
            Me.Label12.Height = 0.1811025!
            Me.Label12.HyperLink = Nothing
            Me.Label12.Left = 3.5625!
            Me.Label12.Name = "Label12"
            Me.Label12.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8."& _ 
                "25pt; font-family: Arial"
            Me.Label12.Text = "Al:"
            Me.Label12.Top = 0.1875!
            Me.Label12.Width = 0.2810042!
            '
            'LblFechaAL
            '
            Me.LblFechaAL.Height = 0.1811025!
            Me.LblFechaAL.HyperLink = Nothing
            Me.LblFechaAL.Left = 3.8125!
            Me.LblFechaAL.Name = "LblFechaAL"
            Me.LblFechaAL.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: normal; font-size: "& _ 
                "8.25pt; font-family: Arial"
            Me.LblFechaAL.Text = "LblFechaAL"
            Me.LblFechaAL.Top = 0.1875!
            Me.LblFechaAL.Width = 0.9685042!
            '
            'LblSucursal
            '
            Me.LblSucursal.Height = 0.1811025!
            Me.LblSucursal.HyperLink = Nothing
            Me.LblSucursal.Left = 2.125001!
            Me.LblSucursal.Name = "LblSucursal"
            Me.LblSucursal.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: normal; font-size: "& _ 
                "8.25pt; font-family: Arial"
            Me.LblSucursal.Text = "LblSucursal"
            Me.LblSucursal.Top = 0.375!
            Me.LblSucursal.Width = 3.448326!
            '
            'Label13
            '
            Me.Label13.Height = 0.1811025!
            Me.Label13.HyperLink = Nothing
            Me.Label13.Left = 1.4375!
            Me.Label13.Name = "Label13"
            Me.Label13.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8."& _ 
                "25pt; font-family: Arial"
            Me.Label13.Text = "Sucursal:"
            Me.Label13.Top = 0.375!
            Me.Label13.Width = 0.5625!
            '
            'Line1
            '
            Me.Line1.Height = 0!
            Me.Line1.Left = 0!
            Me.Line1.LineWeight = 1!
            Me.Line1.Name = "Line1"
            Me.Line1.Top = 0.625!
            Me.Line1.Width = 6.875!
            Me.Line1.X1 = 0!
            Me.Line1.X2 = 6.875!
            Me.Line1.Y1 = 0.625!
            Me.Line1.Y2 = 0.625!
            '
            'TextBox1
            '
            Me.TextBox1.DataField = "AsociadoID"
            Me.TextBox1.Height = 0.2!
            Me.TextBox1.Left = 0!
            Me.TextBox1.Name = "TextBox1"
            Me.TextBox1.Style = "text-align: center; font-size: 8.25pt"
            Me.TextBox1.Text = "TextBox1"
            Me.TextBox1.Top = 0!
            Me.TextBox1.Width = 0.75!
            '
            'TextBox2
            '
            Me.TextBox2.DataField = "AbonoID"
            Me.TextBox2.Height = 0.2!
            Me.TextBox2.Left = 0.8125!
            Me.TextBox2.Name = "TextBox2"
            Me.TextBox2.Style = "text-align: center; font-size: 8.25pt"
            Me.TextBox2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
            Me.TextBox2.Text = "TextBox2"
            Me.TextBox2.Top = 0!
            Me.TextBox2.Width = 0.8125!
            '
            'TextBox3
            '
            Me.TextBox3.DataField = "MontoPago"
            Me.TextBox3.Height = 0.2!
            Me.TextBox3.Left = 1.6875!
            Me.TextBox3.Name = "TextBox3"
            Me.TextBox3.OutputFormat = resources.GetString("TextBox3.OutputFormat")
            Me.TextBox3.Style = "text-align: right; font-size: 8.25pt"
            Me.TextBox3.Text = "TextBox3"
            Me.TextBox3.Top = 0!
            Me.TextBox3.Width = 0.875!
            '
            'TextBox8
            '
            Me.TextBox8.DataField = "Usuario"
            Me.TextBox8.Height = 0.2!
            Me.TextBox8.Left = 6.25!
            Me.TextBox8.Name = "TextBox8"
            Me.TextBox8.Style = "text-align: center; font-size: 8.25pt"
            Me.TextBox8.Text = "TextBox8"
            Me.TextBox8.Top = 0!
            Me.TextBox8.Width = 0.625!
            '
            'TextBox9
            '
            Me.TextBox9.CanGrow = false
            Me.TextBox9.DataField = "Nombre"
            Me.TextBox9.Height = 0.2!
            Me.TextBox9.Left = 2.875!
            Me.TextBox9.Name = "TextBox9"
            Me.TextBox9.Style = "font-size: 8.25pt"
            Me.TextBox9.Text = "TextBox9"
            Me.TextBox9.Top = 0!
            Me.TextBox9.Width = 3.25!
            '
            'TextBox4
            '
            Me.TextBox4.DataField = "CodFormaPago"
            Me.TextBox4.Height = 0.2!
            Me.TextBox4.Left = 2.9375!
            Me.TextBox4.Name = "TextBox4"
            Me.TextBox4.Style = "text-align: center; font-size: 8.25pt"
            Me.TextBox4.Text = "TextBox4"
            Me.TextBox4.Top = 0!
            Me.TextBox4.Width = 0.625!
            '
            'TextBox5
            '
            Me.TextBox5.DataField = "Monto"
            Me.TextBox5.Height = 0.2!
            Me.TextBox5.Left = 3.75!
            Me.TextBox5.Name = "TextBox5"
            Me.TextBox5.OutputFormat = resources.GetString("TextBox5.OutputFormat")
            Me.TextBox5.Style = "text-align: right; font-size: 8.25pt"
            Me.TextBox5.Text = "TextBox5"
            Me.TextBox5.Top = 0!
            Me.TextBox5.Width = 0.6875!
            '
            'TextBox6
            '
            Me.TextBox6.DataField = "FolioFactura"
            Me.TextBox6.Height = 0.2!
            Me.TextBox6.Left = 4.5!
            Me.TextBox6.Name = "TextBox6"
            Me.TextBox6.Style = "text-align: center; font-size: 8.25pt"
            Me.TextBox6.Text = "TextBox6"
            Me.TextBox6.Top = 0!
            Me.TextBox6.Width = 0.8125!
            '
            'TextBox7
            '
            Me.TextBox7.DataField = "Saldo"
            Me.TextBox7.Height = 0.2!
            Me.TextBox7.Left = 5.4375!
            Me.TextBox7.Name = "TextBox7"
            Me.TextBox7.OutputFormat = resources.GetString("TextBox7.OutputFormat")
            Me.TextBox7.Style = "text-align: right; font-size: 8.25pt"
            Me.TextBox7.Text = "TextBox7"
            Me.TextBox7.Top = 0!
            Me.TextBox7.Width = 0.6875!
            '
            'Shape2
            '
            Me.Shape2.Height = 0.25!
            Me.Shape2.Left = 0!
            Me.Shape2.Name = "Shape2"
            Me.Shape2.RoundingRadius = 9.999999!
            Me.Shape2.Top = 0!
            Me.Shape2.Width = 6.875!
            '
            'txtTotal
            '
            Me.txtTotal.DataField = "Monto"
            Me.txtTotal.Height = 0.2!
            Me.txtTotal.Left = 3.4375!
            Me.txtTotal.Name = "txtTotal"
            Me.txtTotal.OutputFormat = resources.GetString("txtTotal.OutputFormat")
            Me.txtTotal.Style = "text-align: right; font-weight: normal; font-size: 8.25pt"
            Me.txtTotal.SummaryGroup = "ghAbonoID"
            Me.txtTotal.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
            Me.txtTotal.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
            Me.txtTotal.Text = "T"
            Me.txtTotal.Top = 0!
            Me.txtTotal.Width = 1!
            '
            'ActiveReport1
            '
            Me.MasterReport = false
            Me.PageSettings.Margins.Bottom = 0.39375!
            Me.PageSettings.Margins.Left = 0.39375!
            Me.PageSettings.Margins.Right = 0.39375!
            Me.PageSettings.Margins.Top = 0.9840278!
            Me.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Portrait
            Me.PageSettings.PaperHeight = 11!
            Me.PageSettings.PaperWidth = 8.5!
            Me.PrintWidth = 6.90625!
            Me.Sections.Add(Me.ReportHeader)
            Me.Sections.Add(Me.GroupHeader1)
            Me.Sections.Add(Me.ghAbonoID)
            Me.Sections.Add(Me.Detail)
            Me.Sections.Add(Me.GroupFooter2)
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
            CType(Me.Label3,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label5,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label6,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label7,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label8,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label9,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label10,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblFecha,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label11,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.LblFechaDE,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label12,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.LblFechaAL,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.LblSucursal,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label13,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox1,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox2,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox3,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox8,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox9,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox4,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox5,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox6,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox7,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtTotal,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        
	End Sub

#End Region

End Class
