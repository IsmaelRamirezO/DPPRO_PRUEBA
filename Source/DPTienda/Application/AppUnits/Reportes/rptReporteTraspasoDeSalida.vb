Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Imports DportenisPro.DPTienda.ApplicationUnits.Traspasos.TraspasosSalida
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos
Imports DportenisPro.DPTienda.ApplicationUnits.NumeroaLetras
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU


Public Class rptReporteTraspasoDeSalida
Inherits DataDynamics.ActiveReports.ActiveReport
    Public Sub New(ByVal oTraspasoSalida As TraspasoSalida, ByVal Titulo As String)
        MyBase.New()
        InitializeComponent()

        Dim oSAPMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        Dim oTraspasoSalidaMgr As New TraspasosSalidaManager(oAppContext)
        Dim odsCatalogoCorridas As DataSet
        Dim odsDatosEmpresa As DataSet
        Dim oCatalogoAlmacenMgr As New CatalogoAlmacenesManager(oAppContext)
        Dim oAlmacen As Almacen
        Dim oLetras As New Letras

        odsDatosEmpresa = oTraspasoSalidaMgr.ExtraerDatosEmpresa

        TxtRFCOrig.Text = odsDatosEmpresa.Tables(0).Rows(0).Item("RegFed")
        TxtRFCDst.Text = odsDatosEmpresa.Tables(0).Rows(0).Item("RegFed")

        odsDatosEmpresa = Nothing

        '---------------------------------------------------------------------------------
        ' JNAVA (04.03.2016): modificacion por adecuaciones para retail
        '---------------------------------------------------------------------------------
        'If oTraspasoSalida.AlmacenOrigenID.Trim.Length > 3 Then
        '    oAlmacen = oCatalogoAlmacenMgr.Load(oTraspasoSalida.AlmacenOrigenID.Trim.Substring(1, 3))
        'Else
        oAlmacen = oCatalogoAlmacenMgr.Load(oSAPMgr.Read_Centros(oTraspasoSalida.AlmacenOrigenID))
        'End If
        'oAlmacen = oCatalogoAlmacenMgr.Load(oTraspasoSalida.AlmacenOrigenID)
        If Not oAlmacen Is Nothing Then
            LblOrigen.Text = "Suc. " & oTraspasoSalida.AlmacenOrigenID & Space(1) & oAlmacen.Descripcion
            'LblDireccionOrig.Text = oAlmacen.DireccionCalle & " # " & oAlmacen.DireccionNumExt & " Int. " & oAlmacen.DireccionNumInt & Space(1) & oAlmacen.DireccionColonia & " CP. " & oAlmacen.DireccionCP & Space(1) & oAlmacen.DireccionCiudad & ", " & oAlmacen.DireccionEstado
            TxtDireccionOrig.Text = oAlmacen.DireccionCalle & " CP. " & oAlmacen.DireccionCP & Space(1) & oAlmacen.DireccionCiudad & ", " & oAlmacen.DireccionEstado
            LblExpedidaEn.Text = oAlmacen.DireccionCiudad
        End If

        If oTraspasoSalida.AlmacenDestinoID.Trim.Length > 3 Then
            oTraspasoSalida.AlmacenDestinoID = oTraspasoSalida.AlmacenDestinoID.Trim.Substring(1, 3)
        End If
        oAlmacen = oCatalogoAlmacenMgr.Load(oSAPMgr.Read_Centros(oTraspasoSalida.AlmacenDestinoID)) 'oTraspasoSalida.AlmacenDestinoID)
        If Not oAlmacen Is Nothing Then
            lblDestino.Text = "Suc. " & oTraspasoSalida.AlmacenDestinoID & Space(1) & oAlmacen.Descripcion
            'LblDireccionDst.Text = oAlmacen.DireccionCalle & " # " & oAlmacen.DireccionNumExt & " Int. " & oAlmacen.DireccionNumInt & Space(1) & oAlmacen.DireccionColonia & " CP. " & oAlmacen.DireccionCP & Space(1) & oAlmacen.DireccionCiudad & ", " & oAlmacen.DireccionEstado
            TxtDireccionDst.Text = oAlmacen.DireccionCalle & " CP. " & oAlmacen.DireccionCP & Space(1) & oAlmacen.DireccionCiudad & ", " & oAlmacen.DireccionEstado
        End If

        oAlmacen = Nothing

        Me.lblTitulo.Text = "TRASPASO DE SALIDA" & vbCr & Titulo


        Me.LblFolioSAP.Text = "No Trasp SAP: " & oTraspasoSalida.FolioSAP
        If oTraspasoSalida.PedidoEC.Trim <> "" Then
            Select Case oTraspasoSalida.Modulo.Trim.ToUpper
                Case "EC"
                    Me.LblFolioDp.Text = "Folio Pedido EC: " & oTraspasoSalida.PedidoEC
                Case "PPSH"
                    Me.LblFolioDp.Text = "Folio Pedido SH: " & oTraspasoSalida.PedidoEC
            End Select
            Me.LblFolioDp.Visible = True
        Else
            Me.LblFolioDp.Text = "No Trasp: " & oTraspasoSalida.Folio.PadLeft(7, "0")
        End If

        LblFecha.Text = Format(Now.Date, "dd/MM/yyyy")
        LblTotBultos.Text = oTraspasoSalida.TotalBultos

        '        LblImpLet.Text = UCase(oLetras.Letras(Decimal.Round(oTraspasoSalida.SubTotal + oTraspasoSalida.Cargos, 2))) & "/100 M.N."

        LblObservaciones.Text = oTraspasoSalida.Observaciones

        odsCatalogoCorridas = oTraspasoSalidaMgr.ExtraerCatalogoCorridas

        'Crear Tabla Temporal :
        CreatTableTmp()

        Dim drRow As DataRow
        Dim intNum As Integer
        Dim oCatalogoArticuloMgr As New CatalogoArticuloManager(oAppContext)
        Dim oArticulo As Articulo

        For Each drRow In oTraspasoSalida.Detalle.Tables("TraspasoCorrida").Rows

            intNum = 0

            Dim drNewRow As DataRow
            Dim intTotalArticulos As Integer = 0
            Dim odrFiltro() As DataRow

            odrFiltro = odsCatalogoCorridas.Tables("CatalogoCorridas").Select("CodCorrida = '" & drRow("CodCorrida") & "'")

            drNewRow = dtTableTmp.NewRow
            With drNewRow
                !CodArticulo = drRow!CodArticulo
                !Descripcion = drRow!Descripcion
                oArticulo = oCatalogoArticuloMgr.Load(drRow!CodArticulo)
                '!Color = oArticulo.Color1
                !Corrida = drRow!CodCorrida
                '---------------------------------------------------------------------------------
                ' JNAVA (04.03.2016): modificacion por adecuaciones para retail
                '---------------------------------------------------------------------------------
                'If (drRow!C01 > 0) Then
                '    intNum += 1
                '    .Item("C" & intNum) = drRow!C01
                '    .Item("T" & intNum) = odrFiltro(0).Item("C01")
                '    intTotalArticulos += drRow!C01
                'End If
                'If (drRow!C02 > 0) Then
                '    intNum += 1
                '    .Item("C" & intNum) = drRow!C02
                '    .Item("T" & intNum) = odrFiltro(0).Item("C02")
                '    intTotalArticulos += drRow!C02
                'End If
                'If (drRow!C03 > 0) Then
                '    intNum += 1
                '    .Item("C" & intNum) = drRow!C03
                '    .Item("T" & intNum) = odrFiltro(0).Item("C03")
                '    intTotalArticulos += drRow!C03
                'End If
                'If (drRow!C04 > 0) Then
                '    intNum += 1
                '    .Item("C" & intNum) = drRow!C04
                '    .Item("T" & intNum) = odrFiltro(0).Item("C04")
                '    intTotalArticulos += drRow!C04
                'End If
                'If (drRow!C05 > 0) Then
                '    intNum += 1
                '    .Item("C" & intNum) = drRow!C05
                '    .Item("T" & intNum) = odrFiltro(0).Item("C05")
                '    intTotalArticulos += drRow!C05
                'End If
                'If (drRow!C06 > 0) Then
                '    intNum += 1
                '    .Item("C" & intNum) = drRow!C06
                '    .Item("T" & intNum) = odrFiltro(0).Item("C06")
                '    intTotalArticulos += drRow!C06
                'End If
                'If (drRow!C07 > 0) Then
                '    intNum += 1
                '    .Item("C" & intNum) = drRow!C07
                '    .Item("T" & intNum) = odrFiltro(0).Item("C07")
                '    intTotalArticulos += drRow!C07
                'End If
                'If (drRow!C08 > 0) Then
                '    intNum += 1
                '    .Item("C" & intNum) = drRow!C08
                '    .Item("T" & intNum) = odrFiltro(0).Item("C08")
                '    intTotalArticulos += drRow!C08
                'End If
                'If (drRow!C09 > 0) Then
                '    intNum += 1
                '    .Item("C" & intNum) = drRow!C09
                '    .Item("T" & intNum) = odrFiltro(0).Item("C09")
                '    intTotalArticulos += drRow!C09
                'End If
                'If (drRow!C10 > 0) Then
                '    intNum += 1
                '    .Item("C" & intNum) = drRow!C10
                '    .Item("T" & intNum) = odrFiltro(0).Item("C10")
                '    intTotalArticulos += drRow!C10
                'End If
                'If (drRow!C11 > 0) Then
                '    intNum += 1
                '    .Item("C" & intNum) = drRow!C11
                '    .Item("T" & intNum) = odrFiltro(0).Item("C11")
                '    intTotalArticulos += drRow!C11
                'End If
                'If (drRow!C12 > 0) Then
                '    intNum += 1
                '    .Item("C" & intNum) = drRow!C12
                '    .Item("T" & intNum) = odrFiltro(0).Item("C12")
                '    intTotalArticulos += drRow!C12
                'End If
                'If (drRow!C13 > 0) Then
                '    intNum += 1
                '    .Item("C" & intNum) = drRow!C13
                '    .Item("T" & intNum) = odrFiltro(0).Item("C13")
                '    intTotalArticulos += drRow!C13
                'End If
                'If (drRow!C14 > 0) Then
                '    intNum += 1
                '    .Item("C" & intNum) = drRow!C14
                '    .Item("T" & intNum) = odrFiltro(0).Item("C14")
                '    intTotalArticulos += drRow!C14
                'End If
                'If (drRow!C15 > 0) Then
                '    intNum += 1
                '    .Item("C" & intNum) = drRow!C15
                '    .Item("T" & intNum) = odrFiltro(0).Item("C15")
                '    intTotalArticulos += drRow!C15
                'End If
                'If (drRow!C16 > 0) Then
                '    intNum += 1
                '    .Item("C" & intNum) = drRow!C16
                '    .Item("T" & intNum) = odrFiltro(0).Item("C16")
                '    intTotalArticulos += drRow!C16
                'End If
                'If (drRow!C17 > 0) Then
                '    intNum += 1
                '    .Item("C" & intNum) = drRow!C17
                '    .Item("T" & intNum) = odrFiltro(0).Item("C17")
                '    intTotalArticulos += drRow!C17
                'End If
                'If (drRow!C18 > 0) Then
                '    intNum += 1
                '    .Item("C" & intNum) = drRow!C18
                '    .Item("T" & intNum) = odrFiltro(0).Item("C18")
                '    intTotalArticulos += drRow!C18
                'End If
                'If (drRow!C19 > 0) Then
                '    intNum += 1
                '    .Item("C" & intNum) = drRow!C19
                '    .Item("T" & intNum) = odrFiltro(0).Item("C19")
                '    intTotalArticulos += drRow!C19
                'End If
                'If (drRow!C20 > 0) Then
                '    intNum += 1
                '    .Item("C" & intNum) = drRow!C20
                '    .Item("T" & intNum) = odrFiltro(0).Item("C20")
                '    intTotalArticulos += drRow!C20
                'End If
                intTotalArticulos = drRow!Cantidad
                '---------------------------------------------------------------------------------
                !Total = intTotalArticulos
                !CostUnit = drRow!CostoTotal / intTotalArticulos
                !CostTotal = drRow!CostoTotal

            End With
            dtTableTmp.Rows.Add(drNewRow)
            odrFiltro = Nothing
        Next

        Me.DataSource = dtTableTmp
        'IIf(IsDBNull(dtTableTmp.Compute("SUM(CostTotal)", "CostTotal > 0")), 0, dtTableTmp.Compute("SUM(CostTotal)", "CostTotal > 0"))

        LblImpLet.Text = UCase(oLetras.Letras(Decimal.Round(IIf(IsDBNull(dtTableTmp.Compute("SUM(CostTotal)", "CostTotal > 0")), 0, dtTableTmp.Compute("SUM(CostTotal)", "CostTotal > 0")), 2))) & "/100 M.N."

    End Sub

#Region "ActiveReports Designer generated code"
    Private WithEvents ReportHeader As ReportHeader = Nothing
    Private WithEvents PageHeader As PageHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents PageFooter As PageFooter = Nothing
    Private WithEvents ReportFooter As ReportFooter = Nothing
    Private lblTitulo As Label = Nothing
    Private Line45 As Line = Nothing
    Private Label26 As Label = Nothing
    Private Label28 As Label = Nothing
    Private Label30 As Label = Nothing
    Private Label31 As Label = Nothing
    Private Label29 As Label = Nothing
    Private Line46 As Line = Nothing
    Private Line47 As Line = Nothing
    Private TxtDireccionDst As TextBox = Nothing
    Private TxtDireccionOrig As TextBox = Nothing
    Private LblTotBultos As Label = Nothing
    Private LblExpedidaEn As Label = Nothing
    Private LblFecha As Label = Nothing
    Private Label22 As Label = Nothing
    Private Label21 As Label = Nothing
    Private Label20 As Label = Nothing
    Private LblFolioSAP As Label = Nothing
    Private Label17 As Label = Nothing
    Private Label18 As Label = Nothing
    Private lblDestino As Label = Nothing
    Private LblOrigen As Label = Nothing
    Private TxtRFCOrig As TextBox = Nothing
    Private TxtRFCDst As TextBox = Nothing
    Private LblFolioDp As Label = Nothing
    Private txtArticulos As TextBox = Nothing
    Private txtDescripcion As TextBox = Nothing
    Private txtTotal As TextBox = Nothing
    Private TxtCostUnit As TextBox = Nothing
    Private TxtCostoTotal As TextBox = Nothing
    Private Label36 As Label = Nothing
    Private Label33 As Label = Nothing
    Private TextBox3 As TextBox = Nothing
    Private TextBox4 As TextBox = Nothing
    Private LblImpLet As Label = Nothing
    Private LblObservaciones As Label = Nothing
    Private Line32 As Line = Nothing
    Private Line44 As Line = Nothing
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptReporteTraspasoDeSalida))
        Me.Detail = New DataDynamics.ActiveReports.Detail()
        Me.txtArticulos = New DataDynamics.ActiveReports.TextBox()
        Me.txtDescripcion = New DataDynamics.ActiveReports.TextBox()
        Me.txtTotal = New DataDynamics.ActiveReports.TextBox()
        Me.TxtCostUnit = New DataDynamics.ActiveReports.TextBox()
        Me.TxtCostoTotal = New DataDynamics.ActiveReports.TextBox()
        Me.ReportHeader = New DataDynamics.ActiveReports.ReportHeader()
        Me.lblTitulo = New DataDynamics.ActiveReports.Label()
        Me.Line45 = New DataDynamics.ActiveReports.Line()
        Me.ReportFooter = New DataDynamics.ActiveReports.ReportFooter()
        Me.Label36 = New DataDynamics.ActiveReports.Label()
        Me.Label33 = New DataDynamics.ActiveReports.Label()
        Me.TextBox3 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox4 = New DataDynamics.ActiveReports.TextBox()
        Me.LblImpLet = New DataDynamics.ActiveReports.Label()
        Me.LblObservaciones = New DataDynamics.ActiveReports.Label()
        Me.Line32 = New DataDynamics.ActiveReports.Line()
        Me.Line44 = New DataDynamics.ActiveReports.Line()
        Me.PageHeader = New DataDynamics.ActiveReports.PageHeader()
        Me.Label26 = New DataDynamics.ActiveReports.Label()
        Me.Label28 = New DataDynamics.ActiveReports.Label()
        Me.Label30 = New DataDynamics.ActiveReports.Label()
        Me.Label31 = New DataDynamics.ActiveReports.Label()
        Me.Label29 = New DataDynamics.ActiveReports.Label()
        Me.Line46 = New DataDynamics.ActiveReports.Line()
        Me.Line47 = New DataDynamics.ActiveReports.Line()
        Me.TxtDireccionDst = New DataDynamics.ActiveReports.TextBox()
        Me.TxtDireccionOrig = New DataDynamics.ActiveReports.TextBox()
        Me.LblTotBultos = New DataDynamics.ActiveReports.Label()
        Me.LblExpedidaEn = New DataDynamics.ActiveReports.Label()
        Me.LblFecha = New DataDynamics.ActiveReports.Label()
        Me.Label22 = New DataDynamics.ActiveReports.Label()
        Me.Label21 = New DataDynamics.ActiveReports.Label()
        Me.Label20 = New DataDynamics.ActiveReports.Label()
        Me.LblFolioSAP = New DataDynamics.ActiveReports.Label()
        Me.Label17 = New DataDynamics.ActiveReports.Label()
        Me.Label18 = New DataDynamics.ActiveReports.Label()
        Me.lblDestino = New DataDynamics.ActiveReports.Label()
        Me.LblOrigen = New DataDynamics.ActiveReports.Label()
        Me.TxtRFCOrig = New DataDynamics.ActiveReports.TextBox()
        Me.TxtRFCDst = New DataDynamics.ActiveReports.TextBox()
        Me.LblFolioDp = New DataDynamics.ActiveReports.Label()
        Me.PageFooter = New DataDynamics.ActiveReports.PageFooter()
        CType(Me.txtArticulos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDescripcion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtCostUnit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtCostoTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label36, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label33, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblImpLet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblObservaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label26, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label28, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label30, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label31, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label29, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtDireccionDst, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtDireccionOrig, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblTotBultos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblExpedidaEn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label22, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label21, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label20, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblFolioSAP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblDestino, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblOrigen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtRFCOrig, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtRFCDst, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblFolioDp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.ColumnSpacing = 0.0!
        Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtArticulos, Me.txtDescripcion, Me.txtTotal, Me.TxtCostUnit, Me.TxtCostoTotal})
        Me.Detail.Height = 0.2604167!
        Me.Detail.Name = "Detail"
        '
        'txtArticulos
        '
        Me.txtArticulos.DataField = "CodArticulo"
        Me.txtArticulos.Height = 0.152!
        Me.txtArticulos.Left = 0.0625!
        Me.txtArticulos.Name = "txtArticulos"
        Me.txtArticulos.Style = "ddo-char-set: 0; font-size: 8.25pt; font-family: Times New Roman"
        Me.txtArticulos.Text = "Articulos"
        Me.txtArticulos.Top = 0.0!
        Me.txtArticulos.Width = 2.0525!
        '
        'txtDescripcion
        '
        Me.txtDescripcion.DataField = "Descripcion"
        Me.txtDescripcion.Height = 0.152!
        Me.txtDescripcion.Left = 2.189!
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Style = "ddo-char-set: 0; font-size: 8.25pt; font-family: Times New Roman"
        Me.txtDescripcion.Text = "Descripcion"
        Me.txtDescripcion.Top = 0.0!
        Me.txtDescripcion.Width = 3.832!
        '
        'txtTotal
        '
        Me.txtTotal.DataField = "Total"
        Me.txtTotal.Height = 0.188!
        Me.txtTotal.Left = 6.021!
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.OutputFormat = resources.GetString("txtTotal.OutputFormat")
        Me.txtTotal.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; font-family: Times New Ro" & _
    "man"
        Me.txtTotal.Text = "Cant"
        Me.txtTotal.Top = 0.0!
        Me.txtTotal.Width = 0.5619998!
        '
        'TxtCostUnit
        '
        Me.TxtCostUnit.DataField = "CostUnit"
        Me.TxtCostUnit.Height = 0.188!
        Me.TxtCostUnit.Left = 6.583!
        Me.TxtCostUnit.Name = "TxtCostUnit"
        Me.TxtCostUnit.OutputFormat = resources.GetString("TxtCostUnit.OutputFormat")
        Me.TxtCostUnit.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; font-family: Times New Rom" & _
    "an"
        Me.TxtCostUnit.Text = "Costo Unit."
        Me.TxtCostUnit.Top = 0.0!
        Me.TxtCostUnit.Width = 0.7814999!
        '
        'TxtCostoTotal
        '
        Me.TxtCostoTotal.DataField = "CostTotal"
        Me.TxtCostoTotal.Height = 0.188!
        Me.TxtCostoTotal.Left = 7.375!
        Me.TxtCostoTotal.Name = "TxtCostoTotal"
        Me.TxtCostoTotal.OutputFormat = resources.GetString("TxtCostoTotal.OutputFormat")
        Me.TxtCostoTotal.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; font-family: Times New Rom" & _
    "an"
        Me.TxtCostoTotal.Text = "CostoTotal"
        Me.TxtCostoTotal.Top = 0.0!
        Me.TxtCostoTotal.Width = 0.5777559!
        '
        'ReportHeader
        '
        Me.ReportHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.lblTitulo, Me.Line45})
        Me.ReportHeader.Height = 0.4583334!
        Me.ReportHeader.Name = "ReportHeader"
        '
        'lblTitulo
        '
        Me.lblTitulo.Height = 0.3850001!
        Me.lblTitulo.HyperLink = Nothing
        Me.lblTitulo.Left = 0.125!
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt; font-f" & _
    "amily: Times New Roman"
        Me.lblTitulo.Text = "TRASPASO DE SALIDA"
        Me.lblTitulo.Top = 0.02!
        Me.lblTitulo.Width = 7.875!
        '
        'Line45
        '
        Me.Line45.Height = 0.0!
        Me.Line45.Left = 0.06200027!
        Me.Line45.LineWeight = 1.0!
        Me.Line45.Name = "Line45"
        Me.Line45.Top = 0.378!
        Me.Line45.Width = 7.95!
        Me.Line45.X1 = 8.012!
        Me.Line45.X2 = 0.06200027!
        Me.Line45.Y1 = 0.378!
        Me.Line45.Y2 = 0.378!
        '
        'ReportFooter
        '
        Me.ReportFooter.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label36, Me.Label33, Me.TextBox3, Me.TextBox4, Me.LblImpLet, Me.LblObservaciones, Me.Line32, Me.Line44})
        Me.ReportFooter.Height = 0.9166667!
        Me.ReportFooter.Name = "ReportFooter"
        '
        'Label36
        '
        Me.Label36.Height = 0.4375!
        Me.Label36.HyperLink = Nothing
        Me.Label36.Left = 0.062!
        Me.Label36.Name = "Label36"
        Me.Label36.Style = "text-align: justify; font-weight: normal; font-size: 9pt; font-family: Times New " & _
    "Roman"
        Me.Label36.Text = resources.GetString("Label36.Text")
        Me.Label36.Top = 0.437!
        Me.Label36.Width = 7.9375!
        '
        'Label33
        '
        Me.Label33.Height = 0.1875!
        Me.Label33.HyperLink = Nothing
        Me.Label33.Left = 0.0625!
        Me.Label33.Name = "Label33"
        Me.Label33.Style = "font-weight: normal; font-size: 8.25pt; font-family: Times New Roman"
        Me.Label33.Text = "Observaciones:"
        Me.Label33.Top = 0.25!
        Me.Label33.Width = 0.875!
        '
        'TextBox3
        '
        Me.TextBox3.DataField = "Total"
        Me.TextBox3.Height = 0.1875!
        Me.TextBox3.Left = 6.021!
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.OutputFormat = resources.GetString("TextBox3.OutputFormat")
        Me.TextBox3.Style = "ddo-char-set: 0; text-align: center; font-weight: normal; font-size: 9pt; font-fa" & _
    "mily: Times New Roman"
        Me.TextBox3.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
        Me.TextBox3.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
        Me.TextBox3.Text = "Total"
        Me.TextBox3.Top = 0.0625!
        Me.TextBox3.Width = 0.5619998!
        '
        'TextBox4
        '
        Me.TextBox4.DataField = "CostTotal"
        Me.TextBox4.Height = 0.1875!
        Me.TextBox4.Left = 6.8125!
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.OutputFormat = resources.GetString("TextBox4.OutputFormat")
        Me.TextBox4.Style = "ddo-char-set: 0; text-align: right; font-weight: normal; font-size: 9pt; font-fam" & _
    "ily: Times New Roman"
        Me.TextBox4.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
        Me.TextBox4.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
        Me.TextBox4.Text = "CostoTotal"
        Me.TextBox4.Top = 0.0625!
        Me.TextBox4.Width = 1.140256!
        '
        'LblImpLet
        '
        Me.LblImpLet.Height = 0.1875!
        Me.LblImpLet.HyperLink = Nothing
        Me.LblImpLet.Left = 0.0625!
        Me.LblImpLet.Name = "LblImpLet"
        Me.LblImpLet.Style = "font-weight: normal; font-size: 8.25pt; font-family: Times New Roman"
        Me.LblImpLet.Text = "Importe con letra"
        Me.LblImpLet.Top = 0.0625!
        Me.LblImpLet.Width = 5.125!
        '
        'LblObservaciones
        '
        Me.LblObservaciones.Height = 0.1875!
        Me.LblObservaciones.HyperLink = Nothing
        Me.LblObservaciones.Left = 0.9375!
        Me.LblObservaciones.Name = "LblObservaciones"
        Me.LblObservaciones.Style = "font-weight: normal; font-size: 8.25pt; font-family: Times New Roman"
        Me.LblObservaciones.Text = "Observaciones"
        Me.LblObservaciones.Top = 0.25!
        Me.LblObservaciones.Width = 6.375!
        '
        'Line32
        '
        Me.Line32.Height = 0.0!
        Me.Line32.Left = 0.0!
        Me.Line32.LineWeight = 1.0!
        Me.Line32.Name = "Line32"
        Me.Line32.Top = 0.0!
        Me.Line32.Width = 7.95!
        Me.Line32.X1 = 0.0!
        Me.Line32.X2 = 7.95!
        Me.Line32.Y1 = 0.0!
        Me.Line32.Y2 = 0.0!
        '
        'Line44
        '
        Me.Line44.Height = 0.0!
        Me.Line44.Left = 0.0!
        Me.Line44.LineWeight = 1.0!
        Me.Line44.Name = "Line44"
        Me.Line44.Top = 0.4375!
        Me.Line44.Width = 7.95!
        Me.Line44.X1 = 0.0!
        Me.Line44.X2 = 7.95!
        Me.Line44.Y1 = 0.4375!
        Me.Line44.Y2 = 0.4375!
        '
        'PageHeader
        '
        Me.PageHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label26, Me.Label28, Me.Label30, Me.Label31, Me.Label29, Me.Line46, Me.Line47, Me.TxtDireccionDst, Me.TxtDireccionOrig, Me.LblTotBultos, Me.LblExpedidaEn, Me.LblFecha, Me.Label22, Me.Label21, Me.Label20, Me.LblFolioSAP, Me.Label17, Me.Label18, Me.lblDestino, Me.LblOrigen, Me.TxtRFCOrig, Me.TxtRFCDst, Me.LblFolioDp})
        Me.PageHeader.Height = 1.416667!
        Me.PageHeader.Name = "PageHeader"
        '
        'Label26
        '
        Me.Label26.Height = 0.1875!
        Me.Label26.HyperLink = Nothing
        Me.Label26.Left = 0.062!
        Me.Label26.Name = "Label26"
        Me.Label26.Style = "text-align: left; font-weight: normal; font-size: 8.25pt; font-family: Times New " & _
    "Roman"
        Me.Label26.Text = "Código"
        Me.Label26.Top = 1.187!
        Me.Label26.Width = 2.053!
        '
        'Label28
        '
        Me.Label28.Height = 0.1875!
        Me.Label28.HyperLink = Nothing
        Me.Label28.Left = 2.189!
        Me.Label28.Name = "Label28"
        Me.Label28.Style = "text-align: left; font-weight: normal; font-size: 8.25pt; font-family: Times New " & _
    "Roman"
        Me.Label28.Text = "Descripción"
        Me.Label28.Top = 1.187!
        Me.Label28.Width = 3.832!
        '
        'Label30
        '
        Me.Label30.Height = 0.1865001!
        Me.Label30.HyperLink = Nothing
        Me.Label30.Left = 6.583!
        Me.Label30.Name = "Label30"
        Me.Label30.Style = "text-align: center; font-weight: normal; font-size: 8.25pt; font-family: Times Ne" & _
    "w Roman"
        Me.Label30.Text = "Costo Unitario"
        Me.Label30.Top = 1.1875!
        Me.Label30.Width = 0.7815833!
        '
        'Label31
        '
        Me.Label31.Height = 0.1875!
        Me.Label31.HyperLink = Nothing
        Me.Label31.Left = 7.375!
        Me.Label31.Name = "Label31"
        Me.Label31.Style = "text-align: center; font-weight: normal; font-size: 8.25pt; font-family: Times Ne" & _
    "w Roman"
        Me.Label31.Text = "Costo Total"
        Me.Label31.Top = 1.1875!
        Me.Label31.Width = 0.5777563!
        '
        'Label29
        '
        Me.Label29.Height = 0.1875!
        Me.Label29.HyperLink = Nothing
        Me.Label29.Left = 6.021!
        Me.Label29.Name = "Label29"
        Me.Label29.Style = "text-align: center; font-weight: normal; font-size: 8.25pt; font-family: Times Ne" & _
    "w Roman"
        Me.Label29.Text = "Cant."
        Me.Label29.Top = 1.187!
        Me.Label29.Width = 0.5619998!
        '
        'Line46
        '
        Me.Line46.Height = 0.0!
        Me.Line46.Left = 0.08568458!
        Me.Line46.LineWeight = 1.0!
        Me.Line46.Name = "Line46"
        Me.Line46.Top = 1.109306!
        Me.Line46.Width = 7.950003!
        Me.Line46.X1 = 8.035687!
        Me.Line46.X2 = 0.08568458!
        Me.Line46.Y1 = 1.109306!
        Me.Line46.Y2 = 1.109306!
        '
        'Line47
        '
        Me.Line47.Height = 0.0!
        Me.Line47.Left = 0.06299976!
        Me.Line47.LineWeight = 1.0!
        Me.Line47.Name = "Line47"
        Me.Line47.Top = 1.394!
        Me.Line47.Width = 7.95!
        Me.Line47.X1 = 8.013!
        Me.Line47.X2 = 0.06299976!
        Me.Line47.Y1 = 1.394!
        Me.Line47.Y2 = 1.394!
        '
        'TxtDireccionDst
        '
        Me.TxtDireccionDst.Height = 0.4237206!
        Me.TxtDireccionDst.Left = 3.062992!
        Me.TxtDireccionDst.Name = "TxtDireccionDst"
        Me.TxtDireccionDst.Style = "ddo-char-set: 1; font-size: 8.25pt; font-family: Times New Roman"
        Me.TxtDireccionDst.Text = "Direccion Origen"
        Me.TxtDireccionDst.Top = 0.5999014!
        Me.TxtDireccionDst.Width = 2.430556!
        '
        'TxtDireccionOrig
        '
        Me.TxtDireccionOrig.Height = 0.4251968!
        Me.TxtDireccionOrig.Left = 0.1338583!
        Me.TxtDireccionOrig.Name = "TxtDireccionOrig"
        Me.TxtDireccionOrig.Style = "ddo-char-set: 1; font-size: 8.25pt; font-family: Times New Roman"
        Me.TxtDireccionOrig.Text = "Direccion Destino"
        Me.TxtDireccionOrig.Top = 0.5984252!
        Me.TxtDireccionOrig.Width = 2.472441!
        '
        'LblTotBultos
        '
        Me.LblTotBultos.Height = 0.1875!
        Me.LblTotBultos.HyperLink = Nothing
        Me.LblTotBultos.Left = 6.8125!
        Me.LblTotBultos.Name = "LblTotBultos"
        Me.LblTotBultos.Style = "text-align: center; font-weight: normal; font-size: 8.25pt; font-family: Times Ne" & _
    "w Roman"
        Me.LblTotBultos.Text = "Bultos"
        Me.LblTotBultos.Top = 0.6875!
        Me.LblTotBultos.Width = 1.0625!
        '
        'LblExpedidaEn
        '
        Me.LblExpedidaEn.Height = 0.1875!
        Me.LblExpedidaEn.HyperLink = Nothing
        Me.LblExpedidaEn.Left = 6.75!
        Me.LblExpedidaEn.Name = "LblExpedidaEn"
        Me.LblExpedidaEn.Style = "text-align: center; font-weight: normal; font-size: 8.25pt; font-family: Times Ne" & _
    "w Roman"
        Me.LblExpedidaEn.Text = "Ciudad Orig"
        Me.LblExpedidaEn.Top = 0.5!
        Me.LblExpedidaEn.Width = 1.125!
        '
        'LblFecha
        '
        Me.LblFecha.Height = 0.1875!
        Me.LblFecha.HyperLink = Nothing
        Me.LblFecha.Left = 7.180555!
        Me.LblFecha.Name = "LblFecha"
        Me.LblFecha.Style = "text-align: center; font-weight: normal; font-size: 8.25pt; font-family: Times Ne" & _
    "w Roman"
        Me.LblFecha.Text = "dd/MM/yyyy"
        Me.LblFecha.Top = 0.3125!
        Me.LblFecha.Width = 0.7430556!
        '
        'Label22
        '
        Me.Label22.Height = 0.1875!
        Me.Label22.HyperLink = Nothing
        Me.Label22.Left = 5.9375!
        Me.Label22.Name = "Label22"
        Me.Label22.Style = "font-weight: normal; font-size: 8.25pt; font-family: Times New Roman"
        Me.Label22.Text = "No. de Bultos:"
        Me.Label22.Top = 0.6737201!
        Me.Label22.Width = 0.875!
        '
        'Label21
        '
        Me.Label21.Height = 0.1875!
        Me.Label21.HyperLink = Nothing
        Me.Label21.Left = 5.9375!
        Me.Label21.Name = "Label21"
        Me.Label21.Style = "font-weight: normal; font-size: 8.25pt; font-family: Times New Roman"
        Me.Label21.Text = "Expedida en:"
        Me.Label21.Top = 0.4862205!
        Me.Label21.Width = 0.8125!
        '
        'Label20
        '
        Me.Label20.Height = 0.1875!
        Me.Label20.HyperLink = Nothing
        Me.Label20.Left = 5.9375!
        Me.Label20.Name = "Label20"
        Me.Label20.Style = "font-weight: normal; font-size: 8.25pt; font-family: Times New Roman"
        Me.Label20.Text = "Fecha de Expedición:"
        Me.Label20.Top = 0.2987205!
        Me.Label20.Width = 1.25!
        '
        'LblFolioSAP
        '
        Me.LblFolioSAP.Height = 0.1875!
        Me.LblFolioSAP.HyperLink = Nothing
        Me.LblFolioSAP.Left = 5.9375!
        Me.LblFolioSAP.Name = "LblFolioSAP"
        Me.LblFolioSAP.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8.25pt; font-fam" & _
    "ily: Times New Roman"
        Me.LblFolioSAP.Text = "Folio"
        Me.LblFolioSAP.Top = 0.04872048!
        Me.LblFolioSAP.Width = 2.015256!
        '
        'Label17
        '
        Me.Label17.Height = 0.1875!
        Me.Label17.HyperLink = Nothing
        Me.Label17.Left = 0.1338582!
        Me.Label17.Name = "Label17"
        Me.Label17.Style = "text-align: center; font-weight: normal; font-size: 8.25pt; font-family: Times Ne" & _
    "w Roman"
        Me.Label17.Text = "Origen"
        Me.Label17.Top = 0.03740144!
        Me.Label17.Width = 2.429133!
        '
        'Label18
        '
        Me.Label18.Height = 0.1875!
        Me.Label18.HyperLink = Nothing
        Me.Label18.Left = 3.0625!
        Me.Label18.Name = "Label18"
        Me.Label18.Style = "text-align: center; font-weight: normal; font-size: 8.25pt; font-family: Times Ne" & _
    "w Roman"
        Me.Label18.Text = "Destino"
        Me.Label18.Top = 0.03543307!
        Me.Label18.Width = 2.464567!
        '
        'lblDestino
        '
        Me.lblDestino.Height = 0.1875!
        Me.lblDestino.HyperLink = Nothing
        Me.lblDestino.Left = 3.0625!
        Me.lblDestino.Name = "lblDestino"
        Me.lblDestino.Style = "font-weight: normal; font-size: 8.25pt; font-family: Times New Roman"
        Me.lblDestino.Text = "Nombre"
        Me.lblDestino.Top = 0.2249015!
        Me.lblDestino.Width = 2.4375!
        '
        'LblOrigen
        '
        Me.LblOrigen.Height = 0.1875!
        Me.LblOrigen.HyperLink = Nothing
        Me.LblOrigen.Left = 0.1338583!
        Me.LblOrigen.Name = "LblOrigen"
        Me.LblOrigen.Style = "font-weight: normal; font-size: 8.25pt; font-family: Times New Roman"
        Me.LblOrigen.Text = "Nombre"
        Me.LblOrigen.Top = 0.2244094!
        Me.LblOrigen.Width = 2.46648!
        '
        'TxtRFCOrig
        '
        Me.TxtRFCOrig.Height = 0.1875!
        Me.TxtRFCOrig.Left = 0.1338583!
        Me.TxtRFCOrig.Name = "TxtRFCOrig"
        Me.TxtRFCOrig.Style = "ddo-char-set: 1; font-size: 8.25pt; font-family: Times New Roman"
        Me.TxtRFCOrig.Text = "RFC"
        Me.TxtRFCOrig.Top = 0.4133858!
        Me.TxtRFCOrig.Width = 1.5!
        '
        'TxtRFCDst
        '
        Me.TxtRFCDst.Height = 0.1875!
        Me.TxtRFCDst.Left = 3.062992!
        Me.TxtRFCDst.Name = "TxtRFCDst"
        Me.TxtRFCDst.Style = "ddo-char-set: 1; font-size: 8.25pt; font-family: Times New Roman"
        Me.TxtRFCDst.Text = "RFC"
        Me.TxtRFCDst.Top = 0.4124015!
        Me.TxtRFCDst.Width = 1.5!
        '
        'LblFolioDp
        '
        Me.LblFolioDp.Height = 0.1875!
        Me.LblFolioDp.HyperLink = Nothing
        Me.LblFolioDp.Left = 5.9375!
        Me.LblFolioDp.Name = "LblFolioDp"
        Me.LblFolioDp.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8.25pt; font-fam" & _
    "ily: Times New Roman"
        Me.LblFolioDp.Text = "Folio"
        Me.LblFolioDp.Top = 0.8612201!
        Me.LblFolioDp.Visible = False
        Me.LblFolioDp.Width = 2.015256!
        '
        'PageFooter
        '
        Me.PageFooter.Height = 0.0!
        Me.PageFooter.Name = "PageFooter"
        '
        'rptReporteTraspasoDeSalida
        '
        Me.MasterReport = False
        Me.PageSettings.Margins.Bottom = 0.1965278!
        Me.PageSettings.Margins.Left = 0.2!
        Me.PageSettings.Margins.Right = 0.2!
        Me.PageSettings.Margins.Top = 0.2!
        Me.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Portrait
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 8.010417!
        Me.Sections.Add(Me.ReportHeader)
        Me.Sections.Add(Me.PageHeader)
        Me.Sections.Add(Me.Detail)
        Me.Sections.Add(Me.PageFooter)
        Me.Sections.Add(Me.ReportFooter)
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" & _
            "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei" & _
            "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" & _
            "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit", "Heading3", "Normal"))
        CType(Me.txtArticulos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDescripcion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtCostUnit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtCostoTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label36, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label33, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblImpLet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblObservaciones, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label26, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label28, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label30, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label31, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label29, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtDireccionDst, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtDireccionOrig, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblTotBultos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblExpedidaEn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label22, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label21, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label20, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblFolioSAP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblDestino, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblOrigen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtRFCOrig, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtRFCDst, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblFolioDp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

#End Region

    Public dtTableTmp As DataTable

    Public Sub CreatTableTmp()

        dtTableTmp = New DataTable("TraspasoDetalle")

        Dim dcCodArticulo As New DataColumn
        With dcCodArticulo
            .ColumnName = "CodArticulo"
            .DataType = GetType(String)
            .DefaultValue = String.Empty
        End With

        Dim dcDescripcion As New DataColumn
        With dcDescripcion
            .ColumnName = "Descripcion"
            .DataType = GetType(String)
            .DefaultValue = String.Empty
        End With

        Dim dcColor As New DataColumn
        With dcColor
            .ColumnName = "Color"
            .DataType = GetType(String)
            .DefaultValue = String.Empty
        End With

        Dim dcCorrida As New DataColumn
        With dcCorrida
            .ColumnName = "Corrida"
            .DataType = GetType(String)
            .DefaultValue = String.Empty
        End With

        Dim dcC1 As New DataColumn
        With dcC1
            .ColumnName = "C1"
            .DataType = GetType(Integer)
            .DefaultValue = 0
        End With

        Dim dcT1 As New DataColumn
        With dcT1
            .ColumnName = "T1"
            .DataType = GetType(String)
            .DefaultValue = 0
        End With

        Dim dcC2 As New DataColumn
        With dcC2
            .ColumnName = "C2"
            .DataType = GetType(Integer)
            .DefaultValue = 0
        End With

        Dim dcT2 As New DataColumn
        With dcT2
            .ColumnName = "T2"
            .DataType = GetType(String)
            .DefaultValue = 0
        End With

        Dim dcC3 As New DataColumn
        With dcC3
            .ColumnName = "C3"
            .DataType = GetType(Integer)
            .DefaultValue = 0
        End With

        Dim dcT3 As New DataColumn
        With dcT3
            .ColumnName = "T3"
            .DataType = GetType(String)
            .DefaultValue = 0
        End With

        Dim dcC4 As New DataColumn
        With dcC4
            .ColumnName = "C4"
            .DataType = GetType(Integer)
            .DefaultValue = 0
        End With

        Dim dcT4 As New DataColumn
        With dcT4
            .ColumnName = "T4"
            .DataType = GetType(String)
            .DefaultValue = 0
        End With

        Dim dcC5 As New DataColumn
        With dcC5
            .ColumnName = "C5"
            .DataType = GetType(Integer)
            .DefaultValue = 0
        End With

        Dim dcT5 As New DataColumn
        With dcT5
            .ColumnName = "T5"
            .DataType = GetType(String)
            .DefaultValue = 0
        End With

        Dim dcC6 As New DataColumn
        With dcC6
            .ColumnName = "C6"
            .DataType = GetType(Integer)
            .DefaultValue = 0
        End With

        Dim dcT6 As New DataColumn
        With dcT6
            .ColumnName = "T6"
            .DataType = GetType(String)
            .DefaultValue = 0
        End With

        Dim dcC7 As New DataColumn
        With dcC7
            .ColumnName = "C7"
            .DataType = GetType(Integer)
            .DefaultValue = 0
        End With

        Dim dcT7 As New DataColumn
        With dcT7
            .ColumnName = "T7"
            .DataType = GetType(String)
            .DefaultValue = 0
        End With

        Dim dcC8 As New DataColumn
        With dcC8
            .ColumnName = "C8"
            .DataType = GetType(Integer)
            .DefaultValue = 0
        End With

        Dim dcT8 As New DataColumn
        With dcT8
            .ColumnName = "T8"
            .DataType = GetType(String)
            .DefaultValue = 0
        End With

        Dim dcC9 As New DataColumn
        With dcC9
            .ColumnName = "C9"
            .DataType = GetType(Integer)
            .DefaultValue = 0
        End With

        Dim dcT9 As New DataColumn
        With dcT9
            .ColumnName = "T9"
            .DataType = GetType(String)
            .DefaultValue = 0
        End With

        Dim dcC10 As New DataColumn
        With dcC10
            .ColumnName = "C10"
            .DataType = GetType(Integer)
            .DefaultValue = 0
        End With

        Dim dcT10 As New DataColumn
        With dcT10
            .ColumnName = "T10"
            .DataType = GetType(String)
            .DefaultValue = 0
        End With

        Dim dcC11 As New DataColumn
        With dcC11
            .ColumnName = "C11"
            .DataType = GetType(Integer)
            .DefaultValue = 0
        End With

        Dim dcT11 As New DataColumn
        With dcT11
            .ColumnName = "T11"
            .DataType = GetType(String)
            .DefaultValue = 0
        End With

        Dim dcC12 As New DataColumn
        With dcC12
            .ColumnName = "C12"
            .DataType = GetType(Integer)
            .DefaultValue = 0
        End With

        Dim dcT12 As New DataColumn
        With dcT12
            .ColumnName = "T12"
            .DataType = GetType(String)
            .DefaultValue = 0
        End With

        Dim dcC13 As New DataColumn
        With dcC13
            .ColumnName = "C13"
            .DataType = GetType(Integer)
            .DefaultValue = 0
        End With

        Dim dcT13 As New DataColumn
        With dcT13
            .ColumnName = "T13"
            .DataType = GetType(String)
            .DefaultValue = 0
        End With

        Dim dcC14 As New DataColumn
        With dcC14
            .ColumnName = "C14"
            .DataType = GetType(Integer)
            .DefaultValue = 0
        End With

        Dim dcT14 As New DataColumn
        With dcT14
            .ColumnName = "T14"
            .DataType = GetType(String)
            .DefaultValue = 0
        End With

        Dim dcC15 As New DataColumn
        With dcC15
            .ColumnName = "C15"
            .DataType = GetType(Integer)
            .DefaultValue = 0
        End With

        Dim dcT15 As New DataColumn
        With dcT15
            .ColumnName = "T15"
            .DataType = GetType(String)
            .DefaultValue = 0
        End With

        Dim dcC16 As New DataColumn
        With dcC16
            .ColumnName = "C16"
            .DataType = GetType(Integer)
            .DefaultValue = 0
        End With

        Dim dcT16 As New DataColumn
        With dcT16
            .ColumnName = "T16"
            .DataType = GetType(String)
            .DefaultValue = 0
        End With

        Dim dcC17 As New DataColumn
        With dcC17
            .ColumnName = "C17"
            .DataType = GetType(Integer)
            .DefaultValue = 0
        End With

        Dim dcT17 As New DataColumn
        With dcT17
            .ColumnName = "T17"
            .DataType = GetType(String)
            .DefaultValue = 0
        End With

        Dim dcC18 As New DataColumn
        With dcC18
            .ColumnName = "C18"
            .DataType = GetType(Integer)
            .DefaultValue = 0
        End With

        Dim dcT18 As New DataColumn
        With dcT18
            .ColumnName = "T18"
            .DataType = GetType(String)
            .DefaultValue = 0
        End With

        Dim dcC19 As New DataColumn
        With dcC19
            .ColumnName = "C19"
            .DataType = GetType(Integer)
            .DefaultValue = 0
        End With

        Dim dcT19 As New DataColumn
        With dcT19
            .ColumnName = "T19"
            .DataType = GetType(String)
            .DefaultValue = 0
        End With

        Dim dcC20 As New DataColumn
        With dcC20
            .ColumnName = "C20"
            .DataType = GetType(Integer)
            .DefaultValue = 0
        End With

        Dim dcT20 As New DataColumn
        With dcT20
            .ColumnName = "T20"
            .DataType = GetType(String)
            .DefaultValue = 0
        End With

        Dim dcTotal As New DataColumn
        With dcTotal
            .ColumnName = "Total"
            .DataType = GetType(Integer)
            .DefaultValue = 0
        End With

        Dim dcCostUnit As New DataColumn
        With dcCostUnit
            .ColumnName = "CostUnit"
            .DataType = GetType(Double)
            .DefaultValue = 0
        End With

        Dim dcCostTotal As New DataColumn
        With dcCostTotal
            .ColumnName = "CostTotal"
            .DataType = GetType(Double)
            .DefaultValue = 0
        End With

        With dtTableTmp.Columns

            .Add(dcCodArticulo)
            .Add(dcDescripcion)
            .Add(dcColor)
            .Add(dcCorrida)
            .Add(dcC1)
            .Add(dcT1)
            .Add(dcC2)
            .Add(dcT2)
            .Add(dcC3)
            .Add(dcT3)
            .Add(dcC4)
            .Add(dcT4)
            .Add(dcC5)
            .Add(dcT5)
            .Add(dcC6)
            .Add(dcT6)
            .Add(dcC7)
            .Add(dcT7)
            .Add(dcC8)
            .Add(dcT8)
            .Add(dcC9)
            .Add(dcT9)
            .Add(dcC10)
            .Add(dcT10)
            .Add(dcC11)
            .Add(dcT11)
            .Add(dcC12)
            .Add(dcT12)
            .Add(dcC13)
            .Add(dcT13)
            .Add(dcC14)
            .Add(dcT14)
            .Add(dcC15)
            .Add(dcT15)
            .Add(dcC16)
            .Add(dcT16)
            .Add(dcC17)
            .Add(dcT17)
            .Add(dcC18)
            .Add(dcT18)
            .Add(dcC19)
            .Add(dcT19)
            .Add(dcC20)
            .Add(dcT20)
            .Add(dcTotal)
            .Add(dcCostUnit)
            .Add(dcCostTotal)
        End With

    End Sub

    'Private Sub Detail_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles Detail.Format

    '    C1.Visible = True
    '    N1.Visible = True
    '    C2.Visible = True
    '    N2.Visible = True
    '    C3.Visible = True
    '    N3.Visible = True
    '    C4.Visible = True
    '    N4.Visible = True
    '    C5.Visible = True
    '    N5.Visible = True
    '    C6.Visible = True
    '    N6.Visible = True
    '    C7.Visible = True
    '    N7.Visible = True
    '    C8.Visible = True
    '    N8.Visible = True
    '    C9.Visible = True
    '    N9.Visible = True
    '    C10.Visible = True
    '    N10.Visible = True
    '    C11.Visible = True
    '    N11.Visible = True
    '    C12.Visible = True
    '    N12.Visible = True
    '    C13.Visible = True
    '    N13.Visible = True
    '    C14.Visible = True
    '    N14.Visible = True
    '    C15.Visible = True
    '    N15.Visible = True
    '    C16.Visible = True
    '    N16.Visible = True
    '    C17.Visible = True
    '    N17.Visible = True
    '    C18.Visible = True
    '    N18.Visible = True
    '    C19.Visible = True
    '    N19.Visible = True
    '    C20.Visible = True
    '    N20.Visible = True

    '    If (N1.Text = 0) Then
    '        C1.Visible = False
    '        N1.Visible = False
    '    End If

    '    If (N2.Text = 0) Then
    '        C2.Visible = False
    '        N2.Visible = False
    '    End If

    '    If (N3.Text = 0) Then
    '        C3.Visible = False
    '        N3.Visible = False
    '    End If

    '    If (N4.Text = 0) Then
    '        C4.Visible = False
    '        N4.Visible = False
    '    End If

    '    If (N5.Text = 0) Then
    '        C5.Visible = False
    '        N5.Visible = False
    '    End If

    '    If (N6.Text = 0) Then
    '        C6.Visible = False
    '        N6.Visible = False
    '    End If

    '    If (N7.Text = 0) Then
    '        C7.Visible = False
    '        N7.Visible = False
    '    End If

    '    If (N8.Text = 0) Then
    '        C8.Visible = False
    '        N8.Visible = False
    '    End If

    '    If (N9.Text = 0) Then
    '        C9.Visible = False
    '        N9.Visible = False
    '    End If

    '    If (N10.Text = 0) Then
    '        C10.Visible = False
    '        N10.Visible = False
    '    End If

    '    If (N11.Text = 0) Then
    '        C11.Visible = False
    '        N11.Visible = False
    '    End If

    '    If (N12.Text = 0) Then
    '        C12.Visible = False
    '        N12.Visible = False
    '    End If

    '    If (N13.Text = 0) Then
    '        C13.Visible = False
    '        N13.Visible = False
    '    End If

    '    If (N14.Text = 0) Then
    '        C14.Visible = False
    '        N14.Visible = False
    '    End If

    '    If (N15.Text = 0) Then
    '        C15.Visible = False
    '        N15.Visible = False
    '    End If

    '    If (N16.Text = 0) Then
    '        C16.Visible = False
    '        N16.Visible = False
    '    End If

    '    If (N17.Text = 0) Then
    '        C17.Visible = False
    '        N17.Visible = False
    '    End If

    '    If (N18.Text = 0) Then
    '        C18.Visible = False
    '        N18.Visible = False
    '    End If

    '    If (N19.Text = 0) Then
    '        C19.Visible = False
    '        N19.Visible = False
    '    End If

    '    If (N20.Text = 0) Then
    '        C20.Visible = False
    '        N20.Visible = False
    '    End If

    'End Sub


    Private Sub ReportFooter_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportFooter.Format

    End Sub

    Private Sub PageHeader_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles PageHeader.Format

    End Sub
End Class
