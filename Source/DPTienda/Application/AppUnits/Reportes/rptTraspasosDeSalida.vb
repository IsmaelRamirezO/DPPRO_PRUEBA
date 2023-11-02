Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Imports DportenisPro.DPTienda.ApplicationUnits.Traspasos.TraspasosSalida
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU

Public Class rptTraspasosDeSalida
Inherits DataDynamics.ActiveReports.ActiveReport
    Public Sub New(ByVal dsTraspasoSalida As DataSet, ByVal FechaDe As DateTime, ByVal FechaAl As DateTime)
        MyBase.New()
        InitializeComponent()
        Dim oSAPMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        Dim oAlmacen As Almacen
        Dim oAlmacenesMgr As New CatalogoAlmacenesManager(oAppContext)
        oAlmacen = oAlmacenesMgr.Load(oSAPMgr.read_centros) 'oAppContext.ApplicationConfiguration.Almacen)

        If Not oAlmacen Is Nothing Then

            txtSucursal.Text = oAlmacen.ID & " " & oAlmacen.Descripcion

        Else

            txtSucursal.Text = oAppContext.ApplicationConfiguration.Almacen

        End If

        txtFecha.Text = Format(Date.Now, "dd/MM/yyyy")
        txtFechaDel.Text = Format(FechaDe, "dd/MM/yyyy")
        txtFechaAl.Text = Format(FechaAl, "dd/MM/yyyy")

        CreateTable()

        For Each row As DataRow In dsTraspasoSalida.Tables(0).Rows
            Dim bandNewRow As Boolean = True

            For Each row2 As DataRow In dsExistencias.Tables("Traspasos").Rows

                If (row("Folio") = row2("Folio")) Then

                    row2("CTotal") = 0
                    If CStr(row("Codigo")).Trim = row2("Articulo") Then
                        bandNewRow = False
                    End If

                End If

            Next

            If bandNewRow Then

                Dim newRow As DataRow = dsExistencias.Tables("Traspasos").NewRow
                newRow("CTotal") = row("CTotal")
                newRow("Sucursal") = row("Origen")
                newRow("Folio") = row("Folio")
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
                newRow("Recibe") = row("FechaRecibe")
                newRow("Total") = row("Cantidad")

                Dim oTraspasoSalidaMgr As New TraspasosSalidaManager(oAppContext)
                Dim odsCatalogoCorridas As DataSet

                odsCatalogoCorridas = oTraspasoSalidaMgr.ExtraerCatalogoCorridas

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
	Private txtFechaDel As TextBox = Nothing
	Private Label13 As Label = Nothing
	Private txtSucursal As TextBox = Nothing
	Private Label14 As Label = Nothing
	Private txtFechaAl As TextBox = Nothing
	Private txtFecha As TextBox = Nothing
	Private TextBox10 As TextBox = Nothing
	Private TextBox11 As TextBox = Nothing
	Private Label31 As Label = Nothing
	Private Shape3 As Shape = Nothing
	Private Label3 As Label = Nothing
	Private Label15 As Label = Nothing
	Private Label16 As Label = Nothing
	Private Label17 As Label = Nothing
	Private Label18 As Label = Nothing
	Private Label20 As Label = Nothing
	Private Label21 As Label = Nothing
	Private Label22 As Label = Nothing
	Private Label23 As Label = Nothing
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
	Private TextBox13 As TextBox = Nothing
	Private Label24 As Label = Nothing
	Private TextBox14 As TextBox = Nothing
	Private Shape5 As Shape = Nothing
	Private Label30 As Label = Nothing
	Private TextBox22 As TextBox = Nothing
	Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptTraspasosDeSalida))
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
            Me.txtFechaDel = New DataDynamics.ActiveReports.TextBox()
            Me.Label13 = New DataDynamics.ActiveReports.Label()
            Me.txtSucursal = New DataDynamics.ActiveReports.TextBox()
            Me.Label14 = New DataDynamics.ActiveReports.Label()
            Me.txtFechaAl = New DataDynamics.ActiveReports.TextBox()
            Me.txtFecha = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox10 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox11 = New DataDynamics.ActiveReports.TextBox()
            Me.Label31 = New DataDynamics.ActiveReports.Label()
            Me.Shape3 = New DataDynamics.ActiveReports.Shape()
            Me.Label3 = New DataDynamics.ActiveReports.Label()
            Me.Label15 = New DataDynamics.ActiveReports.Label()
            Me.Label16 = New DataDynamics.ActiveReports.Label()
            Me.Label17 = New DataDynamics.ActiveReports.Label()
            Me.Label18 = New DataDynamics.ActiveReports.Label()
            Me.Label20 = New DataDynamics.ActiveReports.Label()
            Me.Label21 = New DataDynamics.ActiveReports.Label()
            Me.Label22 = New DataDynamics.ActiveReports.Label()
            Me.Label23 = New DataDynamics.ActiveReports.Label()
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
            Me.TextBox13 = New DataDynamics.ActiveReports.TextBox()
            Me.Label24 = New DataDynamics.ActiveReports.Label()
            Me.TextBox14 = New DataDynamics.ActiveReports.TextBox()
            Me.Shape5 = New DataDynamics.ActiveReports.Shape()
            Me.Label30 = New DataDynamics.ActiveReports.Label()
            Me.TextBox22 = New DataDynamics.ActiveReports.TextBox()
            CType(Me.Label1,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFechaDel,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label13,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtSucursal,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label14,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFechaAl,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFecha,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox10,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox11,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label31,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label3,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label15,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label16,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label17,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label18,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label20,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label21,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label22,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label23,System.ComponentModel.ISupportInitialize).BeginInit
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
            CType(Me.TextBox13,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label24,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox14,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label30,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox22,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
            '
            'Detail
            '
            Me.Detail.ColumnSpacing = 0!
            Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtTallas, Me.txtTotalNumero, Me.txtDescripcion, Me.txtArticulos, Me.TextBox12, Me.txtTotal, Me.Label19, Me.txtFechaTraspaso, Me.txtSucursalOrigen, Me.txtFolio, Me.TextBox13})
            Me.Detail.Height = 0.4159722!
            Me.Detail.Name = "Detail"
            '
            'ReportHeader
            '
            Me.ReportHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape1, Me.Label1, Me.Label2, Me.txtFechaDel, Me.Label13, Me.txtSucursal, Me.Label14, Me.txtFechaAl, Me.txtFecha, Me.TextBox10, Me.TextBox11, Me.Label31})
            Me.ReportHeader.Height = 0.71875!
            Me.ReportHeader.Name = "ReportHeader"
            '
            'ReportFooter
            '
            Me.ReportFooter.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape5, Me.Label30, Me.TextBox22})
            Me.ReportFooter.Height = 0.25!
            Me.ReportFooter.Name = "ReportFooter"
            '
            'PageHeader
            '
            Me.PageHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape3, Me.Label3, Me.Label15, Me.Label16, Me.Label17, Me.Label18, Me.Label20, Me.Label21, Me.Label22, Me.Label23})
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
            Me.GroupHeader1.DataField = "Folio"
            Me.GroupHeader1.Height = 0!
            Me.GroupHeader1.Name = "GroupHeader1"
            '
            'GroupFooter1
            '
            Me.GroupFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label24, Me.TextBox14})
            Me.GroupFooter1.Height = 0.1666667!
            Me.GroupFooter1.Name = "GroupFooter1"
            '
            'Shape1
            '
            Me.Shape1.Height = 0.7086611!
            Me.Shape1.Left = 0!
            Me.Shape1.Name = "Shape1"
            Me.Shape1.RoundingRadius = 9.999999!
            Me.Shape1.Top = 0!
            Me.Shape1.Width = 7.637798!
            '
            'Label1
            '
            Me.Label1.Height = 0.2!
            Me.Label1.HyperLink = Nothing
            Me.Label1.Left = 2.875!
            Me.Label1.Name = "Label1"
            Me.Label1.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt"
            Me.Label1.Text = "REPORTE DE TRASPASOS DE SALIDA"
            Me.Label1.Top = 0.0625!
            Me.Label1.Width = 2.218996!
            '
            'Label2
            '
            Me.Label2.Height = 0.2!
            Me.Label2.HyperLink = Nothing
            Me.Label2.Left = 2.75!
            Me.Label2.Name = "Label2"
            Me.Label2.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt"
            Me.Label2.Text = "De.:"
            Me.Label2.Top = 0.25!
            Me.Label2.Width = 0.2755904!
            '
            'txtFechaDel
            '
            Me.txtFechaDel.Height = 0.2!
            Me.txtFechaDel.Left = 3.06496!
            Me.txtFechaDel.Name = "txtFechaDel"
            Me.txtFechaDel.Style = "font-size: 8.25pt"
            Me.txtFechaDel.Top = 0.25!
            Me.txtFechaDel.Width = 0.9089569!
            '
            'Label13
            '
            Me.Label13.Height = 0.2!
            Me.Label13.HyperLink = Nothing
            Me.Label13.Left = 2.3125!
            Me.Label13.Name = "Label13"
            Me.Label13.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt"
            Me.Label13.Text = "Sucursal.:"
            Me.Label13.Top = 0.4375!
            Me.Label13.Width = 0.6299212!
            '
            'txtSucursal
            '
            Me.txtSucursal.Height = 0.2!
            Me.txtSucursal.Left = 2.981791!
            Me.txtSucursal.Name = "txtSucursal"
            Me.txtSucursal.Style = "font-size: 8.25pt"
            Me.txtSucursal.Top = 0.4375!
            Me.txtSucursal.Width = 2.755905!
            '
            'Label14
            '
            Me.Label14.Height = 0.2!
            Me.Label14.HyperLink = Nothing
            Me.Label14.Left = 4.125!
            Me.Label14.Name = "Label14"
            Me.Label14.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt"
            Me.Label14.Text = "Al.:"
            Me.Label14.Top = 0.25!
            Me.Label14.Width = 0.2755904!
            '
            'txtFechaAl
            '
            Me.txtFechaAl.Height = 0.2!
            Me.txtFechaAl.Left = 4.43996!
            Me.txtFechaAl.Name = "txtFechaAl"
            Me.txtFechaAl.Style = "font-size: 8.25pt"
            Me.txtFechaAl.Top = 0.25!
            Me.txtFechaAl.Width = 0.882382!
            '
            'txtFecha
            '
            Me.txtFecha.Height = 0.2!
            Me.txtFecha.Left = 0.5625!
            Me.txtFecha.Name = "txtFecha"
            Me.txtFecha.Style = "font-size: 8.25pt"
            Me.txtFecha.Top = 0.0625!
            Me.txtFecha.Width = 0.8154528!
            '
            'TextBox10
            '
            Me.TextBox10.Height = 0.2!
            Me.TextBox10.Left = 7!
            Me.TextBox10.Name = "TextBox10"
            Me.TextBox10.Style = "font-size: 8.25pt"
            Me.TextBox10.Text = "Pág."
            Me.TextBox10.Top = 0.0625!
            Me.TextBox10.Width = 0.2987203!
            '
            'TextBox11
            '
            Me.TextBox11.Height = 0.2!
            Me.TextBox11.Left = 7.3125!
            Me.TextBox11.Name = "TextBox11"
            Me.TextBox11.Style = "font-size: 8.25pt"
            Me.TextBox11.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount
            Me.TextBox11.Text = "100"
            Me.TextBox11.Top = 0.0625!
            Me.TextBox11.Width = 0.2362203!
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
            'Shape3
            '
            Me.Shape3.Height = 0.2362205!
            Me.Shape3.Left = 0!
            Me.Shape3.Name = "Shape3"
            Me.Shape3.RoundingRadius = 9.999999!
            Me.Shape3.Top = 0!
            Me.Shape3.Width = 7.637798!
            '
            'Label3
            '
            Me.Label3.Height = 0.169543!
            Me.Label3.HyperLink = Nothing
            Me.Label3.Left = 0!
            Me.Label3.Name = "Label3"
            Me.Label3.Style = "text-align: center; font-weight: normal; font-size: 8.25pt"
            Me.Label3.Text = "FOLIO"
            Me.Label3.Top = 0.0625!
            Me.Label3.Width = 0.4375!
            '
            'Label15
            '
            Me.Label15.Height = 0.1838147!
            Me.Label15.HyperLink = Nothing
            Me.Label15.Left = 0.9375!
            Me.Label15.Name = "Label15"
            Me.Label15.Style = "text-align: center; font-weight: normal; font-size: 8.25pt"
            Me.Label15.Text = "DST."
            Me.Label15.Top = 0.0625!
            Me.Label15.Width = 0.2657479!
            '
            'Label16
            '
            Me.Label16.Height = 0.1838147!
            Me.Label16.HyperLink = Nothing
            Me.Label16.Left = 0.4375!
            Me.Label16.Name = "Label16"
            Me.Label16.Style = "text-align: center; font-weight: normal; font-size: 8.25pt"
            Me.Label16.Text = "FECHA"
            Me.Label16.Top = 0.0625!
            Me.Label16.Width = 0.4375!
            '
            'Label17
            '
            Me.Label17.Height = 0.1875!
            Me.Label17.HyperLink = Nothing
            Me.Label17.Left = 1.9375!
            Me.Label17.Name = "Label17"
            Me.Label17.Style = "text-align: center; font-weight: normal; font-size: 8.25pt"
            Me.Label17.Text = "ARTICULOS"
            Me.Label17.Top = 0.0625!
            Me.Label17.Width = 0.8267716!
            '
            'Label18
            '
            Me.Label18.Height = 0.1875!
            Me.Label18.HyperLink = Nothing
            Me.Label18.Left = 3.031496!
            Me.Label18.Name = "Label18"
            Me.Label18.Style = "text-align: center; font-weight: normal; font-size: 8.25pt"
            Me.Label18.Text = "COLOR"
            Me.Label18.Top = 0.0625!
            Me.Label18.Width = 0.5314963!
            '
            'Label20
            '
            Me.Label20.Height = 0.1875!
            Me.Label20.HyperLink = Nothing
            Me.Label20.Left = 3.875!
            Me.Label20.Name = "Label20"
            Me.Label20.Style = "text-align: center; font-weight: normal; font-size: 8.25pt"
            Me.Label20.Text = "TALLAS"
            Me.Label20.Top = 0.0625!
            Me.Label20.Width = 3.228346!
            '
            'Label21
            '
            Me.Label21.Height = 0.1838146!
            Me.Label21.HyperLink = Nothing
            Me.Label21.Left = 1.1875!
            Me.Label21.Name = "Label21"
            Me.Label21.Style = "text-align: center; font-weight: normal; font-size: 8.25pt"
            Me.Label21.Text = "F. REC."
            Me.Label21.Top = 0.0625!
            Me.Label21.Width = 0.511811!
            '
            'Label22
            '
            Me.Label22.Height = 0.1875!
            Me.Label22.HyperLink = Nothing
            Me.Label22.Left = 3.543307!
            Me.Label22.Name = "Label22"
            Me.Label22.Style = "text-align: center; font-weight: normal; font-size: 8.25pt"
            Me.Label22.Text = "Tot."
            Me.Label22.Top = 0.0625!
            Me.Label22.Width = 0.2249022!
            '
            'Label23
            '
            Me.Label23.Height = 0.1875!
            Me.Label23.HyperLink = Nothing
            Me.Label23.Left = 7.125!
            Me.Label23.Name = "Label23"
            Me.Label23.Style = "text-align: center; font-weight: normal; font-size: 8.25pt"
            Me.Label23.Text = "C. TOT"
            Me.Label23.Top = 0.0625!
            Me.Label23.Width = 0.5314963!
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
            Me.txtTotalNumero.Height = 0.2007874!
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
            Me.txtDescripcion.Height = 0.2!
            Me.txtDescripcion.Left = 1.75!
            Me.txtDescripcion.Name = "txtDescripcion"
            Me.txtDescripcion.Style = "text-align: left; font-size: 8.25pt; font-family: Arial"
            Me.txtDescripcion.Text = "AAAAAAAAAAA"
            Me.txtDescripcion.Top = 0.1875!
            Me.txtDescripcion.Width = 1.25!
            '
            'txtArticulos
            '
            Me.txtArticulos.DataField = "Articulo"
            Me.txtArticulos.Height = 0.2!
            Me.txtArticulos.Left = 1.75!
            Me.txtArticulos.Name = "txtArticulos"
            Me.txtArticulos.Style = "text-align: left; font-size: 8.25pt; font-family: Arial"
            Me.txtArticulos.Text = "ASDFGTRYHUJIKLOP"
            Me.txtArticulos.Top = 0!
            Me.txtArticulos.Width = 1.242126!
            '
            'TextBox12
            '
            Me.TextBox12.DataField = "Color"
            Me.TextBox12.Height = 0.2!
            Me.TextBox12.Left = 3!
            Me.TextBox12.Name = "TextBox12"
            Me.TextBox12.OutputFormat = resources.GetString("TextBox12.OutputFormat")
            Me.TextBox12.Style = "text-align: right; font-size: 8.25pt; font-family: Arial"
            Me.TextBox12.Text = "AAAAAA"
            Me.TextBox12.Top = 0!
            Me.TextBox12.Width = 0.5103355!
            '
            'txtTotal
            '
            Me.txtTotal.DataField = "Total"
            Me.txtTotal.Height = 0.2!
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
            Me.txtFechaTraspaso.Left = 0.4375!
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
            Me.txtSucursalOrigen.Left = 0.96875!
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
            Me.txtFolio.Left = 0.03937007!
            Me.txtFolio.Name = "txtFolio"
            Me.txtFolio.Style = "text-align: center; font-size: 8.25pt"
            Me.txtFolio.SummaryGroup = "GroupHeader1"
            Me.txtFolio.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
            Me.txtFolio.Text = "12345"
            Me.txtFolio.Top = 0!
            Me.txtFolio.Width = 0.3543307!
            '
            'TextBox13
            '
            Me.TextBox13.DataField = "Recibe"
            Me.TextBox13.Height = 0.2!
            Me.TextBox13.Left = 1.239583!
            Me.TextBox13.Name = "TextBox13"
            Me.TextBox13.OutputFormat = resources.GetString("TextBox13.OutputFormat")
            Me.TextBox13.Style = "text-align: left; font-size: 8.25pt"
            Me.TextBox13.SummaryGroup = "GroupHeader1"
            Me.TextBox13.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
            Me.TextBox13.Text = "31/12/99"
            Me.TextBox13.Top = 0!
            Me.TextBox13.Width = 0.5118114!
            '
            'Label24
            '
            Me.Label24.Height = 0.2!
            Me.Label24.HyperLink = Nothing
            Me.Label24.Left = 6.102362!
            Me.Label24.Name = "Label24"
            Me.Label24.Style = "font-size: 8.25pt"
            Me.Label24.Text = "Costo Total"
            Me.Label24.Top = 0!
            Me.Label24.Width = 0.6476378!
            '
            'TextBox14
            '
            Me.TextBox14.DataField = "CTotal"
            Me.TextBox14.Height = 0.2!
            Me.TextBox14.Left = 7!
            Me.TextBox14.Name = "TextBox14"
            Me.TextBox14.OutputFormat = resources.GetString("TextBox14.OutputFormat")
            Me.TextBox14.Style = "text-align: right; font-size: 8.25pt"
            Me.TextBox14.SummaryGroup = "GroupHeader1"
            Me.TextBox14.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
            Me.TextBox14.Text = "999"
            Me.TextBox14.Top = 0!
            Me.TextBox14.Width = 0.5905509!
            '
            'Shape5
            '
            Me.Shape5.Height = 0.2130906!
            Me.Shape5.Left = 0!
            Me.Shape5.Name = "Shape5"
            Me.Shape5.RoundingRadius = 9.999999!
            Me.Shape5.Top = 0!
            Me.Shape5.Width = 7.637798!
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
            Me.TextBox22.Left = 6.25!
            Me.TextBox22.Name = "TextBox22"
            Me.TextBox22.OutputFormat = resources.GetString("TextBox22.OutputFormat")
            Me.TextBox22.Style = "text-align: right; font-weight: normal; font-size: 8.25pt"
            Me.TextBox22.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
            Me.TextBox22.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
            Me.TextBox22.Text = "999"
            Me.TextBox22.Top = 0!
            Me.TextBox22.Width = 1.34621!
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
            Me.PrintWidth = 7.75!
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
            CType(Me.txtFechaDel,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label13,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtSucursal,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label14,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFechaAl,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFecha,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox10,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox11,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label31,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label3,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label15,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label16,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label17,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label18,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label20,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label21,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label22,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label23,System.ComponentModel.ISupportInitialize).EndInit
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
            CType(Me.TextBox13,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label24,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox14,System.ComponentModel.ISupportInitialize).EndInit
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

        Dim dcFechaRecibe As New DataColumn
        With dcFechaRecibe
            .ColumnName = "Recibe"
            .Caption = "Fecha Recibe"
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
            .Add(dcFechaRecibe)
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
