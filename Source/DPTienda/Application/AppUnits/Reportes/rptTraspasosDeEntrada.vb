Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Imports DportenisPro.DPTienda.ApplicationUnits.Traspasos.TraspasosEntrada
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU

Public Class rptTraspasosDeEntrada
    Inherits DataDynamics.ActiveReports.ActiveReport

    Public Sub New(ByVal dsTraspasoEntrada As DataSet, ByVal FechaDe As DateTime, ByVal FechaAl As DateTime)
        MyBase.New()
        InitializeComponent()

        Try
            Dim oSAPMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
            Dim oAlmacen As Almacen
            Dim oAlmacenesMgr As New CatalogoAlmacenesManager(oAppContext)
            oAlmacen = oAlmacenesMgr.Load(oSAPMgr.Read_Centros) 'oAppContext.ApplicationConfiguration.Almacen)

            If Not oAlmacen Is Nothing Then

                txtSucursal.Text = oAlmacen.ID & " " & oAlmacen.Descripcion

            Else

                txtSucursal.Text = oAppContext.ApplicationConfiguration.Almacen

            End If

            txtFecha.Text = Format(Date.Now, "dd/MM/yyyy")
            txtFechaDel.Text = Format(FechaDe, "dd/MM/yyyy")
            txtFechaAl.Text = Format(FechaAl, "dd/MM/yyyy")


            CreateTable()

            For Each row As DataRow In dsTraspasoEntrada.Tables(0).Rows
                Dim bandNewRow As Boolean = True

                For Each row2 As DataRow In dsExistencias.Tables("Traspasos").Rows

                    If (row("Referencia") = row2("Folio")) Then

                        row2("CTotal") = 0
                        If CStr(row("Codigo")).Trim = row2("Articulo") Then
                            bandNewRow = False
                        End If

                    End If

                Next

                If bandNewRow Then

                    Dim newRow As DataRow = dsExistencias.Tables("Traspasos").NewRow
                    newRow("CTotal") = row("CTotal")
                    newRow("Sucursal") = row("Almacen")
                    newRow("Folio") = row("Referencia")
                    newRow("Articulo") = CStr(row("Codigo")).Trim


                    If CStr(row("Descripcion")).Length > 20 Then
                        newRow("Descripcion") = CStr(row("Descripcion")).Substring(0, 20)
                    Else
                        newRow("Descripcion") = CStr(row("Descripcion"))
                    End If

                    'If CStr(row("Color1")).Trim.Length > 7 Then
                    '    newRow("Color") = CStr(row("Color1")).Substring(0, 7)
                    'Else
                    '    newRow("Color") = CStr(row("Color1"))
                    'End If


                    newRow("Fecha") = row("Fecha")
                    newRow("Total") = row("Cantidad")

                    Dim oTraspasoEntradaMgr As New TraspasosEntradaManager(oAppContext)
                    Dim odsCatalogoCorridas As DataSet

                    odsCatalogoCorridas = oTraspasoEntradaMgr.ExtraerCatalogoCorridas

                    Dim odrFiltro() As DataRow

                    odrFiltro = odsCatalogoCorridas.Tables("CatalogoCorridas").Select("CodCorrida = '" & row("CodCorrida") & "'")


                    Dim idx As Integer = 0
                    Dim iField As String
                    For idx = 1 To 20

                        iField = "C" + Format(idx, "00")

                        If row(iField) > 0 Then
                            Dim i As Integer = 0
                            Dim space As String = String.Empty
                            newRow("Tallas") &= " " & CStr(odrFiltro(0)(iField))
                            For i = 1 To CStr(odrFiltro(0)(iField)).Length
                                space &= " "
                            Next
                            newRow("TotalNum") &= space & Format(row(iField), "#####")

                        End If

                    Next

                    newRow("Tallas") = CStr(newRow("Tallas")).TrimStart()
                    newRow("TotalNum") = CStr(newRow("TotalNum")).TrimStart

                    dsExistencias.Tables("Traspasos").Rows.Add(newRow)
                    dsExistencias.AcceptChanges()

                End If


            Next

            Me.DataSource = dsExistencias

            Me.DataMember = "Traspasos"
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
	Private Shape4 As Shape = Nothing
	Private Label22 As Label = Nothing
	Private Label23 As Label = Nothing
	Private txtFechaDel As TextBox = Nothing
	Private Label24 As Label = Nothing
	Private txtSucursal As TextBox = Nothing
	Private Label25 As Label = Nothing
	Private txtFechaAl As TextBox = Nothing
	Private txtFecha As TextBox = Nothing
	Private TextBox18 As TextBox = Nothing
	Private TextBox19 As TextBox = Nothing
	Private Label31 As Label = Nothing
	Private Shape5 As Shape = Nothing
	Private Label32 As Label = Nothing
	Private Label33 As Label = Nothing
	Private Label34 As Label = Nothing
	Private Label35 As Label = Nothing
	Private Label36 As Label = Nothing
	Private Label37 As Label = Nothing
	Private Label39 As Label = Nothing
	Private Label40 As Label = Nothing
	Private Line6 As Line = Nothing
	Private Line9 As Line = Nothing
	Private txtTallas As TextBox = Nothing
	Private txtTotalNumero As TextBox = Nothing
	Private txtDescripcion As TextBox = Nothing
	Private txtArticulos As TextBox = Nothing
	Private TextBox12 As TextBox = Nothing
	Private txtTotal As TextBox = Nothing
	Private Label19 As Label = Nothing
	Private txtFechaTraspaso As TextBox = Nothing
	Private txtSucursalOrigen As TextBox = Nothing
	Private txtFolio As TextBox = Nothing
	Private Label41 As Label = Nothing
	Private TextBox20 As TextBox = Nothing
	Private Shape7 As Shape = Nothing
	Private Label30 As Label = Nothing
	Private TextBox22 As TextBox = Nothing
	Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptTraspasosDeEntrada))
            Me.Detail = New DataDynamics.ActiveReports.Detail()
            Me.ReportHeader = New DataDynamics.ActiveReports.ReportHeader()
            Me.ReportFooter = New DataDynamics.ActiveReports.ReportFooter()
            Me.PageHeader = New DataDynamics.ActiveReports.PageHeader()
            Me.PageFooter = New DataDynamics.ActiveReports.PageFooter()
            Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader()
            Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter()
            Me.Shape4 = New DataDynamics.ActiveReports.Shape()
            Me.Label22 = New DataDynamics.ActiveReports.Label()
            Me.Label23 = New DataDynamics.ActiveReports.Label()
            Me.txtFechaDel = New DataDynamics.ActiveReports.TextBox()
            Me.Label24 = New DataDynamics.ActiveReports.Label()
            Me.txtSucursal = New DataDynamics.ActiveReports.TextBox()
            Me.Label25 = New DataDynamics.ActiveReports.Label()
            Me.txtFechaAl = New DataDynamics.ActiveReports.TextBox()
            Me.txtFecha = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox18 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox19 = New DataDynamics.ActiveReports.TextBox()
            Me.Label31 = New DataDynamics.ActiveReports.Label()
            Me.Shape5 = New DataDynamics.ActiveReports.Shape()
            Me.Label32 = New DataDynamics.ActiveReports.Label()
            Me.Label33 = New DataDynamics.ActiveReports.Label()
            Me.Label34 = New DataDynamics.ActiveReports.Label()
            Me.Label35 = New DataDynamics.ActiveReports.Label()
            Me.Label36 = New DataDynamics.ActiveReports.Label()
            Me.Label37 = New DataDynamics.ActiveReports.Label()
            Me.Label39 = New DataDynamics.ActiveReports.Label()
            Me.Label40 = New DataDynamics.ActiveReports.Label()
            Me.Line6 = New DataDynamics.ActiveReports.Line()
            Me.Line9 = New DataDynamics.ActiveReports.Line()
            Me.txtTallas = New DataDynamics.ActiveReports.TextBox()
            Me.txtTotalNumero = New DataDynamics.ActiveReports.TextBox()
            Me.txtDescripcion = New DataDynamics.ActiveReports.TextBox()
            Me.txtArticulos = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox12 = New DataDynamics.ActiveReports.TextBox()
            Me.txtTotal = New DataDynamics.ActiveReports.TextBox()
            Me.Label19 = New DataDynamics.ActiveReports.Label()
            Me.txtFechaTraspaso = New DataDynamics.ActiveReports.TextBox()
            Me.txtSucursalOrigen = New DataDynamics.ActiveReports.TextBox()
            Me.txtFolio = New DataDynamics.ActiveReports.TextBox()
            Me.Label41 = New DataDynamics.ActiveReports.Label()
            Me.TextBox20 = New DataDynamics.ActiveReports.TextBox()
            Me.Shape7 = New DataDynamics.ActiveReports.Shape()
            Me.Label30 = New DataDynamics.ActiveReports.Label()
            Me.TextBox22 = New DataDynamics.ActiveReports.TextBox()
            CType(Me.Label22,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label23,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFechaDel,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label24,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtSucursal,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label25,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFechaAl,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFecha,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox18,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox19,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label31,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label32,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label33,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label34,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label35,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label36,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label37,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label39,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label40,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtTallas,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtTotalNumero,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtDescripcion,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtArticulos,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox12,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtTotal,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label19,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFechaTraspaso,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtSucursalOrigen,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFolio,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label41,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox20,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label30,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox22,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
            '
            'Detail
            '
            Me.Detail.ColumnSpacing = 0!
            Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtTallas, Me.txtTotalNumero, Me.txtDescripcion, Me.txtArticulos, Me.TextBox12, Me.txtTotal, Me.Label19, Me.txtFechaTraspaso, Me.txtSucursalOrigen, Me.txtFolio})
            Me.Detail.Height = 0.375!
            Me.Detail.Name = "Detail"
            '
            'ReportHeader
            '
            Me.ReportHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape4, Me.Label22, Me.Label23, Me.txtFechaDel, Me.Label24, Me.txtSucursal, Me.Label25, Me.txtFechaAl, Me.txtFecha, Me.TextBox18, Me.TextBox19, Me.Label31})
            Me.ReportHeader.Height = 0.6979167!
            Me.ReportHeader.Name = "ReportHeader"
            '
            'ReportFooter
            '
            Me.ReportFooter.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape7, Me.Label30, Me.TextBox22})
            Me.ReportFooter.Height = 0.25!
            Me.ReportFooter.Name = "ReportFooter"
            '
            'PageHeader
            '
            Me.PageHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape5, Me.Label32, Me.Label33, Me.Label34, Me.Label35, Me.Label36, Me.Label37, Me.Label39, Me.Label40})
            Me.PageHeader.Height = 0.2388889!
            Me.PageHeader.Name = "PageHeader"
            '
            'PageFooter
            '
            Me.PageFooter.Height = 0!
            Me.PageFooter.Name = "PageFooter"
            '
            'GroupHeader1
            '
            Me.GroupHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Line6, Me.Line9})
            Me.GroupHeader1.DataField = "Folio"
            Me.GroupHeader1.Height = 0!
            Me.GroupHeader1.Name = "GroupHeader1"
            '
            'GroupFooter1
            '
            Me.GroupFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label41, Me.TextBox20})
            Me.GroupFooter1.Height = 0.1979167!
            Me.GroupFooter1.Name = "GroupFooter1"
            '
            'Shape4
            '
            Me.Shape4.Height = 0.7086611!
            Me.Shape4.Left = 0!
            Me.Shape4.Name = "Shape4"
            Me.Shape4.RoundingRadius = 9.999999!
            Me.Shape4.Top = 0!
            Me.Shape4.Width = 7.637798!
            '
            'Label22
            '
            Me.Label22.Height = 0.2!
            Me.Label22.HyperLink = Nothing
            Me.Label22.Left = 2.8125!
            Me.Label22.Name = "Label22"
            Me.Label22.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt"
            Me.Label22.Text = "REPORTE DE TRASPASOS DE ENTRADA"
            Me.Label22.Top = 0.0625!
            Me.Label22.Width = 2.375!
            '
            'Label23
            '
            Me.Label23.Height = 0.2!
            Me.Label23.HyperLink = Nothing
            Me.Label23.Left = 2.75!
            Me.Label23.Name = "Label23"
            Me.Label23.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt"
            Me.Label23.Text = "De.:"
            Me.Label23.Top = 0.25!
            Me.Label23.Width = 0.2755904!
            '
            'txtFechaDel
            '
            Me.txtFechaDel.Height = 0.2!
            Me.txtFechaDel.Left = 3.06496!
            Me.txtFechaDel.Name = "txtFechaDel"
            Me.txtFechaDel.Style = "font-size: 8.25pt"
            Me.txtFechaDel.Text = "TextBox14"
            Me.txtFechaDel.Top = 0.25!
            Me.txtFechaDel.Width = 0.9089569!
            '
            'Label24
            '
            Me.Label24.Height = 0.2!
            Me.Label24.HyperLink = Nothing
            Me.Label24.Left = 2.3125!
            Me.Label24.Name = "Label24"
            Me.Label24.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt"
            Me.Label24.Text = "Sucursal.:"
            Me.Label24.Top = 0.4375!
            Me.Label24.Width = 0.6299212!
            '
            'txtSucursal
            '
            Me.txtSucursal.Height = 0.2!
            Me.txtSucursal.Left = 2.981791!
            Me.txtSucursal.Name = "txtSucursal"
            Me.txtSucursal.Style = "font-size: 8.25pt"
            Me.txtSucursal.Text = "TextBox15"
            Me.txtSucursal.Top = 0.4375!
            Me.txtSucursal.Width = 2.755905!
            '
            'Label25
            '
            Me.Label25.Height = 0.2!
            Me.Label25.HyperLink = Nothing
            Me.Label25.Left = 4.125!
            Me.Label25.Name = "Label25"
            Me.Label25.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt"
            Me.Label25.Text = "Al.:"
            Me.Label25.Top = 0.25!
            Me.Label25.Width = 0.2755904!
            '
            'txtFechaAl
            '
            Me.txtFechaAl.Height = 0.2!
            Me.txtFechaAl.Left = 4.43996!
            Me.txtFechaAl.Name = "txtFechaAl"
            Me.txtFechaAl.Style = "font-size: 8.25pt"
            Me.txtFechaAl.Text = "TextBox16"
            Me.txtFechaAl.Top = 0.25!
            Me.txtFechaAl.Width = 0.882382!
            '
            'txtFecha
            '
            Me.txtFecha.Height = 0.2!
            Me.txtFecha.Left = 0.5625!
            Me.txtFecha.Name = "txtFecha"
            Me.txtFecha.Style = "font-size: 8.25pt"
            Me.txtFecha.Text = "TextBox17"
            Me.txtFecha.Top = 0.0625!
            Me.txtFecha.Width = 0.8154528!
            '
            'TextBox18
            '
            Me.TextBox18.Height = 0.2!
            Me.TextBox18.Left = 7!
            Me.TextBox18.Name = "TextBox18"
            Me.TextBox18.Style = "font-size: 8.25pt"
            Me.TextBox18.Text = "Pág."
            Me.TextBox18.Top = 0.0625!
            Me.TextBox18.Width = 0.2987203!
            '
            'TextBox19
            '
            Me.TextBox19.Height = 0.2!
            Me.TextBox19.Left = 7.3125!
            Me.TextBox19.Name = "TextBox19"
            Me.TextBox19.Style = "font-size: 8.25pt"
            Me.TextBox19.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount
            Me.TextBox19.Text = "100"
            Me.TextBox19.Top = 0.0625!
            Me.TextBox19.Width = 0.2362203!
            '
            'Label31
            '
            Me.Label31.Height = 0.2!
            Me.Label31.HyperLink = Nothing
            Me.Label31.Left = 0.0625!
            Me.Label31.Name = "Label31"
            Me.Label31.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt"
            Me.Label31.Text = "Fecha:"
            Me.Label31.Top = 0.0625!
            Me.Label31.Width = 0.4375!
            '
            'Shape5
            '
            Me.Shape5.Height = 0.2362205!
            Me.Shape5.Left = 0!
            Me.Shape5.Name = "Shape5"
            Me.Shape5.RoundingRadius = 9.999999!
            Me.Shape5.Top = 0!
            Me.Shape5.Width = 7.637798!
            '
            'Label32
            '
            Me.Label32.Height = 0.1875!
            Me.Label32.HyperLink = Nothing
            Me.Label32.Left = 0!
            Me.Label32.Name = "Label32"
            Me.Label32.Style = "text-align: center; font-weight: normal; font-size: 8.25pt"
            Me.Label32.Text = "FOLIO"
            Me.Label32.Top = 0.0625!
            Me.Label32.Width = 0.472441!
            '
            'Label33
            '
            Me.Label33.Height = 0.1875!
            Me.Label33.HyperLink = Nothing
            Me.Label33.Left = 0.5!
            Me.Label33.Name = "Label33"
            Me.Label33.Style = "text-align: center; font-weight: normal; font-size: 8.25pt"
            Me.Label33.Text = "SUC."
            Me.Label33.Top = 0.0625!
            Me.Label33.Width = 0.3149606!
            '
            'Label34
            '
            Me.Label34.Height = 0.1875!
            Me.Label34.HyperLink = Nothing
            Me.Label34.Left = 0.875!
            Me.Label34.Name = "Label34"
            Me.Label34.Style = "text-align: center; font-weight: normal; font-size: 8.25pt"
            Me.Label34.Text = "FECHA"
            Me.Label34.Top = 0.0625!
            Me.Label34.Width = 0.511811!
            '
            'Label35
            '
            Me.Label35.Height = 0.1875!
            Me.Label35.HyperLink = Nothing
            Me.Label35.Left = 1.8125!
            Me.Label35.Name = "Label35"
            Me.Label35.Style = "text-align: center; font-weight: normal; font-size: 8.25pt"
            Me.Label35.Text = "ARTICULOS"
            Me.Label35.Top = 0.0625!
            Me.Label35.Width = 0.8267716!
            '
            'Label36
            '
            Me.Label36.Height = 0.1875!
            Me.Label36.HyperLink = Nothing
            Me.Label36.Left = 3!
            Me.Label36.Name = "Label36"
            Me.Label36.Style = "text-align: center; font-weight: normal; font-size: 8.25pt"
            Me.Label36.Text = "COLOR"
            Me.Label36.Top = 0.0625!
            Me.Label36.Width = 0.5314963!
            '
            'Label37
            '
            Me.Label37.Height = 0.1875!
            Me.Label37.HyperLink = Nothing
            Me.Label37.Left = 3.875!
            Me.Label37.Name = "Label37"
            Me.Label37.Style = "text-align: center; font-weight: normal; font-size: 8.25pt"
            Me.Label37.Text = "TALLAS"
            Me.Label37.Top = 0.0625!
            Me.Label37.Width = 3.1875!
            '
            'Label39
            '
            Me.Label39.Height = 0.1875!
            Me.Label39.HyperLink = Nothing
            Me.Label39.Left = 3.5625!
            Me.Label39.Name = "Label39"
            Me.Label39.Style = "text-align: center; font-weight: normal; font-size: 8.25pt"
            Me.Label39.Text = "Tot."
            Me.Label39.Top = 0.0625!
            Me.Label39.Width = 0.2249022!
            '
            'Label40
            '
            Me.Label40.Height = 0.1875!
            Me.Label40.HyperLink = Nothing
            Me.Label40.Left = 7.0625!
            Me.Label40.Name = "Label40"
            Me.Label40.Style = "text-align: center; font-weight: normal; font-size: 8.25pt"
            Me.Label40.Text = "C. TOT"
            Me.Label40.Top = 0.0625!
            Me.Label40.Width = 0.5314963!
            '
            'Line6
            '
            Me.Line6.Height = 0.229276!
            Me.Line6.Left = 7.401576!
            Me.Line6.LineWeight = 1!
            Me.Line6.Name = "Line6"
            Me.Line6.Top = 0.006944451!
            Me.Line6.Width = 0.006944656!
            Me.Line6.X1 = 7.408521!
            Me.Line6.X2 = 7.401576!
            Me.Line6.Y1 = 0.006944451!
            Me.Line6.Y2 = 0.2362205!
            '
            'Line9
            '
            Me.Line9.Height = 0.229276!
            Me.Line9.Left = 0.00694466!
            Me.Line9.LineWeight = 1!
            Me.Line9.Name = "Line9"
            Me.Line9.Top = 0.006944444!
            Me.Line9.Width = 0.006944653!
            Me.Line9.X1 = 0.01388931!
            Me.Line9.X2 = 0.00694466!
            Me.Line9.Y1 = 0.006944444!
            Me.Line9.Y2 = 0.2362205!
            '
            'txtTallas
            '
            Me.txtTallas.DataField = "Tallas"
            Me.txtTallas.Height = 0.2!
            Me.txtTallas.Left = 3.818898!
            Me.txtTallas.Name = "txtTallas"
            Me.txtTallas.Style = "font-size: 8.25pt; font-family: Courier New"
            Me.txtTallas.Text = "txtTallas"
            Me.txtTallas.Top = 0!
            Me.txtTallas.Width = 3.818898!
            '
            'txtTotalNumero
            '
            Me.txtTotalNumero.DataField = "TotalNum"
            Me.txtTotalNumero.Height = 0.1781496!
            Me.txtTotalNumero.Left = 3.818898!
            Me.txtTotalNumero.Name = "txtTotalNumero"
            Me.txtTotalNumero.Style = "font-size: 8.25pt; font-family: Courier New"
            Me.txtTotalNumero.Text = "TextBox4"
            Me.txtTotalNumero.Top = 0.1968504!
            Me.txtTotalNumero.Width = 3.818898!
            '
            'txtDescripcion
            '
            Me.txtDescripcion.DataField = "Descripcion"
            Me.txtDescripcion.Height = 0.1875!
            Me.txtDescripcion.Left = 1.4375!
            Me.txtDescripcion.Name = "txtDescripcion"
            Me.txtDescripcion.Style = "text-align: left; font-size: 8.25pt; font-family: Arial"
            Me.txtDescripcion.Text = "AAAAAAAAAAA"
            Me.txtDescripcion.Top = 0.1875!
            Me.txtDescripcion.Width = 1.5!
            '
            'txtArticulos
            '
            Me.txtArticulos.DataField = "Articulo"
            Me.txtArticulos.Height = 0.2!
            Me.txtArticulos.Left = 1.432496!
            Me.txtArticulos.Name = "txtArticulos"
            Me.txtArticulos.Style = "text-align: left; font-size: 8.25pt; font-family: Arial"
            Me.txtArticulos.Text = "ASDFGTRYHUJIKLOP"
            Me.txtArticulos.Top = 0!
            Me.txtArticulos.Width = 1.505004!
            '
            'TextBox12
            '
            Me.TextBox12.DataField = "Color"
            Me.TextBox12.Height = 0.2!
            Me.TextBox12.Left = 2.952756!
            Me.TextBox12.Name = "TextBox12"
            Me.TextBox12.OutputFormat = resources.GetString("TextBox12.OutputFormat")
            Me.TextBox12.Style = "text-align: right; font-size: 8.25pt; font-family: Arial"
            Me.TextBox12.Text = "AAAAAA"
            Me.TextBox12.Top = 0!
            Me.TextBox12.Width = 0.557579!
            '
            'txtTotal
            '
            Me.txtTotal.DataField = "Total"
            Me.txtTotal.Height = 0.1781496!
            Me.txtTotal.Left = 3.540846!
            Me.txtTotal.Name = "txtTotal"
            Me.txtTotal.OutputFormat = resources.GetString("txtTotal.OutputFormat")
            Me.txtTotal.Style = "text-align: center; font-size: 8.25pt; font-family: Arial"
            Me.txtTotal.Text = "txt"
            Me.txtTotal.Top = 0.1968504!
            Me.txtTotal.Width = 0.1938977!
            '
            'Label19
            '
            Me.Label19.Height = 0.2!
            Me.Label19.HyperLink = Nothing
            Me.Label19.Left = 3.501476!
            Me.Label19.Name = "Label19"
            Me.Label19.Style = "text-align: center; font-weight: normal; font-size: 8.25pt"
            Me.Label19.Text = "Tot."
            Me.Label19.Top = 0!
            Me.Label19.Width = 0.2568896!
            '
            'txtFechaTraspaso
            '
            Me.txtFechaTraspaso.DataField = "Fecha"
            Me.txtFechaTraspaso.Height = 0.2!
            Me.txtFechaTraspaso.Left = 0.875!
            Me.txtFechaTraspaso.Name = "txtFechaTraspaso"
            Me.txtFechaTraspaso.OutputFormat = resources.GetString("txtFechaTraspaso.OutputFormat")
            Me.txtFechaTraspaso.Style = "text-align: left; font-size: 8.25pt"
            Me.txtFechaTraspaso.SummaryGroup = "GroupHeader1"
            Me.txtFechaTraspaso.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
            Me.txtFechaTraspaso.Text = "31/12/99"
            Me.txtFechaTraspaso.Top = 0!
            Me.txtFechaTraspaso.Width = 0.5118114!
            '
            'txtSucursalOrigen
            '
            Me.txtSucursalOrigen.DataField = "Sucursal"
            Me.txtSucursalOrigen.Height = 0.2!
            Me.txtSucursalOrigen.Left = 0.5625!
            Me.txtSucursalOrigen.Name = "txtSucursalOrigen"
            Me.txtSucursalOrigen.Style = "text-align: center; font-size: 8.25pt"
            Me.txtSucursalOrigen.SummaryGroup = "GroupHeader1"
            Me.txtSucursalOrigen.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
            Me.txtSucursalOrigen.Text = "999"
            Me.txtSucursalOrigen.Top = 0!
            Me.txtSucursalOrigen.Width = 0.2362205!
            '
            'txtFolio
            '
            Me.txtFolio.DataField = "Folio"
            Me.txtFolio.Height = 0.2!
            Me.txtFolio.Left = 0!
            Me.txtFolio.Name = "txtFolio"
            Me.txtFolio.Style = "text-align: center; font-size: 8.25pt"
            Me.txtFolio.SummaryGroup = "GroupHeader1"
            Me.txtFolio.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
            Me.txtFolio.Text = "12345"
            Me.txtFolio.Top = 0!
            Me.txtFolio.Width = 0.4606299!
            '
            'Label41
            '
            Me.Label41.Height = 0.1875!
            Me.Label41.HyperLink = Nothing
            Me.Label41.Left = 6.102362!
            Me.Label41.Name = "Label41"
            Me.Label41.Style = "font-size: 8.25pt"
            Me.Label41.Text = "Costo Total"
            Me.Label41.Top = 0!
            Me.Label41.Width = 0.6476378!
            '
            'TextBox20
            '
            Me.TextBox20.DataField = "CTotal"
            Me.TextBox20.Height = 0.1875!
            Me.TextBox20.Left = 6.75!
            Me.TextBox20.Name = "TextBox20"
            Me.TextBox20.OutputFormat = resources.GetString("TextBox20.OutputFormat")
            Me.TextBox20.Style = "text-align: right; font-size: 8.25pt"
            Me.TextBox20.SummaryGroup = "GroupHeader1"
            Me.TextBox20.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
            Me.TextBox20.Text = "999"
            Me.TextBox20.Top = 0!
            Me.TextBox20.Width = 0.8854167!
            '
            'Shape7
            '
            Me.Shape7.Height = 0.2130906!
            Me.Shape7.Left = 0!
            Me.Shape7.Name = "Shape7"
            Me.Shape7.RoundingRadius = 9.999999!
            Me.Shape7.Top = 0!
            Me.Shape7.Width = 7.637798!
            '
            'Label30
            '
            Me.Label30.Height = 0.2!
            Me.Label30.HyperLink = Nothing
            Me.Label30.Left = 0!
            Me.Label30.Name = "Label30"
            Me.Label30.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt"
            Me.Label30.Text = "Total"
            Me.Label30.Top = 0!
            Me.Label30.Width = 0.375!
            '
            'TextBox22
            '
            Me.TextBox22.DataField = "CTotal"
            Me.TextBox22.Height = 0.2!
            Me.TextBox22.Left = 6.625!
            Me.TextBox22.Name = "TextBox22"
            Me.TextBox22.OutputFormat = resources.GetString("TextBox22.OutputFormat")
            Me.TextBox22.Style = "text-align: right; font-weight: normal; font-size: 8.25pt"
            Me.TextBox22.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
            Me.TextBox22.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
            Me.TextBox22.Text = "999"
            Me.TextBox22.Top = 0!
            Me.TextBox22.Width = 1.012876!
            '
            'ActiveReport1
            '
            Me.MasterReport = false
            Me.PageSettings.Margins.Left = 0.39375!
            Me.PageSettings.Margins.Right = 0.39375!
            Me.PageSettings.PaperHeight = 11!
            Me.PageSettings.PaperWidth = 8.5!
            Me.PrintWidth = 7.729167!
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
            CType(Me.Label22,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label23,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFechaDel,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label24,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtSucursal,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label25,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFechaAl,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFecha,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox18,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox19,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label31,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label32,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label33,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label34,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label35,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label36,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label37,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label39,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label40,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtTallas,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtTotalNumero,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtDescripcion,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtArticulos,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox12,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtTotal,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label19,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFechaTraspaso,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtSucursalOrigen,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFolio,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label41,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox20,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label30,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox22,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        
	End Sub

#End Region

    Public dsExistencias As DataSet

    Public Sub CreateTable()

        dsExistencias = New DataSet("Traspasos")
        Dim dtExistencias As New DataTable("Traspasos")


        Dim dcFolio As New DataColumn
        With dcFolio
            .ColumnName = "Folio"
            .Caption = "Folio"
            .DataType = GetType(System.Int32)
            .DefaultValue = 0
        End With


        Dim dcSucursal As New DataColumn
        With dcSucursal
            .ColumnName = "Sucursal"
            .Caption = "Sucursal"
            .DataType = GetType(System.String)
            .DefaultValue = String.Empty
        End With

        Dim dcFecha As New DataColumn
        With dcFecha
            .ColumnName = "Fecha"
            .Caption = "Fecha"
            .DataType = GetType(System.DateTime)
            .DefaultValue = Now.Date.ToShortDateString
        End With

        Dim dcColor As New DataColumn
        With dcColor
            .ColumnName = "Color"
            .Caption = "Color"
            .DataType = GetType(System.String)
            .DefaultValue = String.Empty
        End With

        Dim dcArticulo As New DataColumn
        With dcArticulo
            .ColumnName = "Articulo"
            .Caption = "Articulos"
            .DataType = GetType(System.String)
            .DefaultValue = String.Empty
        End With

        Dim dcDescripcion As New DataColumn
        With dcDescripcion
            .ColumnName = "Descripcion"
            .Caption = "Descripcion"
            .DataType = GetType(System.String)
            .DefaultValue = String.Empty
        End With

        Dim dcTotal As New DataColumn
        With dcTotal
            .ColumnName = "Total"
            .Caption = "Total"
            .DataType = GetType(System.Int32)
        End With


        Dim dcTallas As New DataColumn
        With dcTallas
            .ColumnName = "Tallas"
            .Caption = "Tallas"
            .DataType = GetType(System.String)
        End With

        Dim dcTotalNumero As New DataColumn
        With dcTotalNumero
            .ColumnName = "TotalNum"
            .Caption = "T. Numero"
            .DataType = GetType(System.String)
        End With

        Dim dcCTotal As New DataColumn
        With dcCTotal
            .ColumnName = "CTotal"
            .Caption = "Costo Total"
            .DataType = GetType(System.Decimal)
        End With


        With dtExistencias.Columns
            .Add(dcFolio)
            .Add(dcSucursal)
            .Add(dcFecha)
            .Add(dcColor)
            .Add(dcArticulo)
            .Add(dcDescripcion)
            .Add(dcTotal)
            .Add(dcTallas)
            .Add(dcTotalNumero)
            .Add(dcCTotal)
        End With

        dsExistencias.Tables.Add(dtExistencias)
        dsExistencias.AcceptChanges()

    End Sub

End Class
