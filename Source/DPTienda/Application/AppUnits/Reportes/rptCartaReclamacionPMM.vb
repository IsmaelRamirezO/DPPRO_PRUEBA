Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU

Public Class rptCartaReclamacionPMM
    Inherits DataDynamics.ActiveReports.ActiveReport

    Dim oAlmacenMgr As CatalogoAlmacenesManager

    Public Sub New(ByVal CodSucOrigen As String, ByVal strGuia As String, ByVal NoBultos As String, ByVal PiezasFaltantes As String, _
                    ByVal ComentariosPlayer As String, ByVal dvFaltantes As DataView, ByVal strFolioTraslado As String, ByVal strPaqueteria As String, _
                    ByVal PersonaRecibe As String, ByVal NombreChofer1 As String, ByVal NombreChofer2 As String, ByVal dtTraspasoSAP As DataTable)

        MyBase.New()
        InitializeComponent()

        Try
            Dim oAlmacenLocal As Almacen
            Dim dtSource As DataTable
            Dim CostoTotal As Decimal = 0

            Me.lblTitulo.Text = "CARTA DE RECLAMACIÓN A " & strPaqueteria.Trim.ToUpper
            If strPaqueteria.Trim.ToUpper = "DHL" Then
                Me.lblNombrePaqueteria.Visible = False
                Me.lblNoSiniestroDHL.Visible = True
            ElseIf strPaqueteria.Trim.ToUpper = "ESTAFETA" Then
                Me.lblNombrePaqueteria.Text = "ESTAFETA"
            End If

            Dim oSAPMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
2:          oAlmacenMgr = New CatalogoAlmacenesManager(oAppContext, oConfigCierreFI)

3:          oAlmacenLocal = oAlmacenMgr.Load(oSAPMgr.Read_Centros()) 'oAppContext.ApplicationConfiguration.Almacen)
4:          If Not oAlmacenLocal Is Nothing Then
5:              Me.txtCiudadyFecha.Text = "Ciudad: " & oAlmacenLocal.DireccionCiudad.Trim & " a " & Today.ToLongDateString
6:              Me.txtSucDestino.Text = oAppContext.ApplicationConfiguration.Almacen.Trim
7:              Me.txtCiudadDestino.Text = oAlmacenLocal.DireccionCiudad.Trim
            End If

            Dim oAlmacenOrigen As Almacen

            Dim CentroOrigen As String = ""
8:          oAlmacenOrigen = oAlmacenMgr.Load(oSAPMgr.Read_Centros(CodSucOrigen.Trim))
9:          If Not oAlmacenOrigen Is Nothing Then
10:             Me.txtCiudadOrigen.Text = oAlmacenOrigen.DireccionCiudad.Trim
                CentroOrigen = oSAPMgr.Read_Centros(CodSucOrigen.Trim)
                If InStr("1000,1001", CentroOrigen.Trim) > 0 Then
                    Me.txtSucOrigen.Text = CentroOrigen.Trim.ToUpper
                Else
11:                 Me.txtSucOrigen.Text = CodSucOrigen.ToUpper
                End If
            End If

            Dim TotalPiezasSAP As Integer = 0
            TotalPiezasSAP = dtTraspasoSAP.Compute("SUM(Cantidad)", "")

12:         Me.txtNoGuia.Text = strGuia.Trim
13:         Me.txtNoBultos.Text = NoBultos.Trim
14:         Me.txtTotalPiezas.Text = CStr(TotalPiezasSAP)
15:         Me.txtPiezasRecibidas.Text = CStr(TotalPiezasSAP - CInt(PiezasFaltantes)).Trim
16:         Me.txtComentariosPlayer.Text = ComentariosPlayer.Trim
17:         Me.txtPiezasFaltantes.Text = PiezasFaltantes.Trim
19:         Me.txtFolioTraslado.Text = strFolioTraslado.Trim
20:         Me.txtNombrePersonaRecibe.Text = PersonaRecibe.Trim
21:         Me.txtNombreChofer1.Text = "1.- " & NombreChofer1.Trim
22:         Me.txtNombreChofer2.Text = "2.- " & NombreChofer2.Trim

            dtSource = ComplementarDetalle(dvFaltantes, CostoTotal)

18:         Me.txtCostoTotal.Text = Format(CostoTotal, "$#,##0.0")

23:         Me.DataSource = dtSource

        Catch ex As Exception
            EscribeLog(ex.ToString, "Error al generar reporte carta reclamacion PMM del traslado " & strFolioTraslado.Trim & " Linea: " & Err.Erl)
        End Try

    End Sub

#Region "ActiveReports Designer generated code"
    Private WithEvents ReportHeader As ReportHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents ReportFooter As ReportFooter = Nothing
	Private Picture1 As Picture = Nothing
	Private lblTitulo As Label = Nothing
	Private lblNombrePaqueteria As Label = Nothing
	Private Label4 As Label = Nothing
	Private lblDetalle As Label = Nothing
	Private Label6 As Label = Nothing
	Private Label7 As Label = Nothing
	Private Label8 As Label = Nothing
	Private txtCiudadyFecha As TextBox = Nothing
	Private Label20 As Label = Nothing
	Private Label21 As Label = Nothing
	Private txtCiudadOrigen As TextBox = Nothing
	Private Label23 As Label = Nothing
	Private txtSucOrigen As TextBox = Nothing
	Private txtSucDestino As TextBox = Nothing
	Private Label24 As Label = Nothing
	Private txtCiudadDestino As TextBox = Nothing
	Private Label25 As Label = Nothing
	Private txtNoGuia As TextBox = Nothing
	Private Label26 As Label = Nothing
	Private txtNoBultos As TextBox = Nothing
	Private Label27 As Label = Nothing
	Private txtTotalPiezas As TextBox = Nothing
	Private Label28 As Label = Nothing
	Private txtPiezasRecibidas As TextBox = Nothing
	Private Label29 As Label = Nothing
	Private txtComentariosPlayer As TextBox = Nothing
	Private txtNombrePersonaRecibe As TextBox = Nothing
	Private Label32 As Label = Nothing
	Private txtPiezasFaltantes As TextBox = Nothing
	Private Label33 As Label = Nothing
	Private txtCostoTotal As TextBox = Nothing
	Private Label34 As Label = Nothing
	Private Label35 As Label = Nothing
	Private txtFolioTraslado As TextBox = Nothing
	Private Label36 As Label = Nothing
	Private lblNoSiniestroDHL As Label = Nothing
	Private Label37 As Label = Nothing
	Private Label38 As Label = Nothing
	Private Label39 As Label = Nothing
	Private Label40 As Label = Nothing
	Private Label41 As Label = Nothing
	Private Label42 As Label = Nothing
	Private txtCodArticulo As TextBox = Nothing
	Private txtDescripcion As TextBox = Nothing
	Private txtTalla As TextBox = Nothing
	Private txtCantidad As TextBox = Nothing
	Private txtCostoUnit As TextBox = Nothing
	Private txtCostoTotalPieza As TextBox = Nothing
	Private Label9 As Label = Nothing
	Private Label12 As Label = Nothing
	Private Label13 As Label = Nothing
	Private Label14 As Label = Nothing
	Private Label15 As Label = Nothing
	Private Label16 As Label = Nothing
	Private Label17 As Label = Nothing
	Private Label18 As Label = Nothing
	Private txtNombreChofer1 As TextBox = Nothing
	Private txtNombreChofer2 As TextBox = Nothing
	Private Label30 As Label = Nothing
	Private Label31 As Label = Nothing
	Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptCartaReclamacionPMM))
            Me.Detail = New DataDynamics.ActiveReports.Detail()
            Me.ReportHeader = New DataDynamics.ActiveReports.ReportHeader()
            Me.ReportFooter = New DataDynamics.ActiveReports.ReportFooter()
            Me.Picture1 = New DataDynamics.ActiveReports.Picture()
            Me.lblTitulo = New DataDynamics.ActiveReports.Label()
            Me.lblNombrePaqueteria = New DataDynamics.ActiveReports.Label()
            Me.Label4 = New DataDynamics.ActiveReports.Label()
            Me.lblDetalle = New DataDynamics.ActiveReports.Label()
            Me.Label6 = New DataDynamics.ActiveReports.Label()
            Me.Label7 = New DataDynamics.ActiveReports.Label()
            Me.Label8 = New DataDynamics.ActiveReports.Label()
            Me.txtCiudadyFecha = New DataDynamics.ActiveReports.TextBox()
            Me.Label20 = New DataDynamics.ActiveReports.Label()
            Me.Label21 = New DataDynamics.ActiveReports.Label()
            Me.txtCiudadOrigen = New DataDynamics.ActiveReports.TextBox()
            Me.Label23 = New DataDynamics.ActiveReports.Label()
            Me.txtSucOrigen = New DataDynamics.ActiveReports.TextBox()
            Me.txtSucDestino = New DataDynamics.ActiveReports.TextBox()
            Me.Label24 = New DataDynamics.ActiveReports.Label()
            Me.txtCiudadDestino = New DataDynamics.ActiveReports.TextBox()
            Me.Label25 = New DataDynamics.ActiveReports.Label()
            Me.txtNoGuia = New DataDynamics.ActiveReports.TextBox()
            Me.Label26 = New DataDynamics.ActiveReports.Label()
            Me.txtNoBultos = New DataDynamics.ActiveReports.TextBox()
            Me.Label27 = New DataDynamics.ActiveReports.Label()
            Me.txtTotalPiezas = New DataDynamics.ActiveReports.TextBox()
            Me.Label28 = New DataDynamics.ActiveReports.Label()
            Me.txtPiezasRecibidas = New DataDynamics.ActiveReports.TextBox()
            Me.Label29 = New DataDynamics.ActiveReports.Label()
            Me.txtComentariosPlayer = New DataDynamics.ActiveReports.TextBox()
            Me.txtNombrePersonaRecibe = New DataDynamics.ActiveReports.TextBox()
            Me.Label32 = New DataDynamics.ActiveReports.Label()
            Me.txtPiezasFaltantes = New DataDynamics.ActiveReports.TextBox()
            Me.Label33 = New DataDynamics.ActiveReports.Label()
            Me.txtCostoTotal = New DataDynamics.ActiveReports.TextBox()
            Me.Label34 = New DataDynamics.ActiveReports.Label()
            Me.Label35 = New DataDynamics.ActiveReports.Label()
            Me.txtFolioTraslado = New DataDynamics.ActiveReports.TextBox()
            Me.Label36 = New DataDynamics.ActiveReports.Label()
            Me.lblNoSiniestroDHL = New DataDynamics.ActiveReports.Label()
            Me.Label37 = New DataDynamics.ActiveReports.Label()
            Me.Label38 = New DataDynamics.ActiveReports.Label()
            Me.Label39 = New DataDynamics.ActiveReports.Label()
            Me.Label40 = New DataDynamics.ActiveReports.Label()
            Me.Label41 = New DataDynamics.ActiveReports.Label()
            Me.Label42 = New DataDynamics.ActiveReports.Label()
            Me.txtCodArticulo = New DataDynamics.ActiveReports.TextBox()
            Me.txtDescripcion = New DataDynamics.ActiveReports.TextBox()
            Me.txtTalla = New DataDynamics.ActiveReports.TextBox()
            Me.txtCantidad = New DataDynamics.ActiveReports.TextBox()
            Me.txtCostoUnit = New DataDynamics.ActiveReports.TextBox()
            Me.txtCostoTotalPieza = New DataDynamics.ActiveReports.TextBox()
            Me.Label9 = New DataDynamics.ActiveReports.Label()
            Me.Label12 = New DataDynamics.ActiveReports.Label()
            Me.Label13 = New DataDynamics.ActiveReports.Label()
            Me.Label14 = New DataDynamics.ActiveReports.Label()
            Me.Label15 = New DataDynamics.ActiveReports.Label()
            Me.Label16 = New DataDynamics.ActiveReports.Label()
            Me.Label17 = New DataDynamics.ActiveReports.Label()
            Me.Label18 = New DataDynamics.ActiveReports.Label()
            Me.txtNombreChofer1 = New DataDynamics.ActiveReports.TextBox()
            Me.txtNombreChofer2 = New DataDynamics.ActiveReports.TextBox()
            Me.Label30 = New DataDynamics.ActiveReports.Label()
            Me.Label31 = New DataDynamics.ActiveReports.Label()
            CType(Me.Picture1,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblTitulo,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblNombrePaqueteria,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblDetalle,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label6,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label7,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label8,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtCiudadyFecha,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label20,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label21,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtCiudadOrigen,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label23,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtSucOrigen,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtSucDestino,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label24,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtCiudadDestino,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label25,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtNoGuia,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label26,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtNoBultos,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label27,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtTotalPiezas,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label28,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtPiezasRecibidas,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label29,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtComentariosPlayer,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtNombrePersonaRecibe,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label32,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtPiezasFaltantes,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label33,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtCostoTotal,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label34,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label35,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFolioTraslado,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label36,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblNoSiniestroDHL,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label37,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label38,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label39,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label40,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label41,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label42,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtCodArticulo,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtDescripcion,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtTalla,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtCantidad,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtCostoUnit,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtCostoTotalPieza,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label9,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label12,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label13,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label14,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label15,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label16,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label17,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label18,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtNombreChofer1,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtNombreChofer2,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label30,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label31,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
            '
            'Detail
            '
            Me.Detail.ColumnSpacing = 0!
            Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtCodArticulo, Me.txtDescripcion, Me.txtTalla, Me.txtCantidad, Me.txtCostoUnit, Me.txtCostoTotalPieza})
            Me.Detail.Height = 0.1979167!
            Me.Detail.Name = "Detail"
            '
            'ReportHeader
            '
            Me.ReportHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Picture1, Me.lblTitulo, Me.lblNombrePaqueteria, Me.Label4, Me.lblDetalle, Me.Label6, Me.Label7, Me.Label8, Me.txtCiudadyFecha, Me.Label20, Me.Label21, Me.txtCiudadOrigen, Me.Label23, Me.txtSucOrigen, Me.txtSucDestino, Me.Label24, Me.txtCiudadDestino, Me.Label25, Me.txtNoGuia, Me.Label26, Me.txtNoBultos, Me.Label27, Me.txtTotalPiezas, Me.Label28, Me.txtPiezasRecibidas, Me.Label29, Me.txtComentariosPlayer, Me.txtNombrePersonaRecibe, Me.Label32, Me.txtPiezasFaltantes, Me.Label33, Me.txtCostoTotal, Me.Label34, Me.Label35, Me.txtFolioTraslado, Me.Label36, Me.lblNoSiniestroDHL, Me.Label37, Me.Label38, Me.Label39, Me.Label40, Me.Label41, Me.Label42})
            Me.ReportHeader.Height = 5.625!
            Me.ReportHeader.Name = "ReportHeader"
            '
            'ReportFooter
            '
            Me.ReportFooter.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label9, Me.Label12, Me.Label13, Me.Label14, Me.Label15, Me.Label16, Me.Label17, Me.Label18, Me.txtNombreChofer1, Me.txtNombreChofer2, Me.Label30, Me.Label31})
            Me.ReportFooter.Height = 3.697917!
            Me.ReportFooter.Name = "ReportFooter"
            '
            'Picture1
            '
            Me.Picture1.Height = 0.6875!
            Me.Picture1.ImageData = CType(resources.GetObject("Picture1.ImageData"),System.IO.Stream)
            Me.Picture1.Left = 0.125!
            Me.Picture1.LineColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(255,Byte),Integer), CType(CType(255,Byte),Integer))
            Me.Picture1.LineWeight = 0!
            Me.Picture1.Name = "Picture1"
            Me.Picture1.Top = 0.125!
            Me.Picture1.Width = 2.5625!
            '
            'lblTitulo
            '
            Me.lblTitulo.Height = 0.3125!
            Me.lblTitulo.HyperLink = Nothing
            Me.lblTitulo.Left = 2.75!
            Me.lblTitulo.Name = "lblTitulo"
            Me.lblTitulo.Style = "text-align: right; font-weight: bold; font-size: 15.75pt"
            Me.lblTitulo.Text = "CARTA DE RECLAMACIÓN A P. M. M."
            Me.lblTitulo.Top = 0.125!
            Me.lblTitulo.Width = 4.4375!
            '
            'lblNombrePaqueteria
            '
            Me.lblNombrePaqueteria.Height = 0.25!
            Me.lblNombrePaqueteria.HyperLink = Nothing
            Me.lblNombrePaqueteria.Left = 0.125!
            Me.lblNombrePaqueteria.Name = "lblNombrePaqueteria"
            Me.lblNombrePaqueteria.Style = "font-weight: bold; font-size: 12pt"
            Me.lblNombrePaqueteria.Text = "PAQUETERÍA Y MENSAJERÍA EN MOVIMIENTO, S. A. DE C. V."
            Me.lblNombrePaqueteria.Top = 1!
            Me.lblNombrePaqueteria.Width = 7.0625!
            '
            'Label4
            '
            Me.Label4.Height = 0.25!
            Me.Label4.HyperLink = Nothing
            Me.Label4.Left = 0.125!
            Me.Label4.Name = "Label4"
            Me.Label4.Style = "font-weight: normal; font-size: 11.25pt"
            Me.Label4.Text = "Presente.-"
            Me.Label4.Top = 1.4375!
            Me.Label4.Width = 7.0625!
            '
            'lblDetalle
            '
            Me.lblDetalle.Height = 0.25!
            Me.lblDetalle.HyperLink = Nothing
            Me.lblDetalle.Left = 0.125!
            Me.lblDetalle.Name = "lblDetalle"
            Me.lblDetalle.Style = "font-weight: normal; font-size: 11.25pt; vertical-align: top"
            Me.lblDetalle.Text = "A través del presente realizo la siguiente reclamación relacionada con el envío y"& _ 
                " recepción de"
            Me.lblDetalle.Top = 1.75!
            Me.lblDetalle.Width = 7.0625!
            '
            'Label6
            '
            Me.Label6.Height = 0.25!
            Me.Label6.HyperLink = Nothing
            Me.Label6.Left = 0.125!
            Me.Label6.Name = "Label6"
            Me.Label6.Style = "text-align: center; font-weight: bold; font-size: 12pt"
            Me.Label6.Text = "A continuación describo a detalle los siguientes datos:"
            Me.Label6.Top = 4.5625!
            Me.Label6.Width = 7.0625!
            '
            'Label7
            '
            Me.Label7.Height = 0.25!
            Me.Label7.HyperLink = Nothing
            Me.Label7.Left = 0.125!
            Me.Label7.Name = "Label7"
            Me.Label7.Style = "font-weight: normal; font-size: 12pt"
            Me.Label7.Text = "Nombre de la persona que recibió la mercancía: "
            Me.Label7.Top = 4.875!
            Me.Label7.Width = 3.625!
            '
            'Label8
            '
            Me.Label8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label8.Height = 0.25!
            Me.Label8.HyperLink = Nothing
            Me.Label8.Left = 0.125!
            Me.Label8.Name = "Label8"
            Me.Label8.Style = "color: window; text-align: center; font-weight: bold; background-color: backgroun"& _ 
                "d; font-size: 12pt; vertical-align: middle"
            Me.Label8.Text = "DESCRIPCION DE MERCANCÍA FALTANTE O DAÑADA"
            Me.Label8.Top = 5.1875!
            Me.Label8.Width = 7.0625!
            '
            'txtCiudadyFecha
            '
            Me.txtCiudadyFecha.Height = 0.25!
            Me.txtCiudadyFecha.Left = 2.875!
            Me.txtCiudadyFecha.Name = "txtCiudadyFecha"
            Me.txtCiudadyFecha.Style = "text-align: right; font-weight: normal; font-size: 11.25pt"
            Me.txtCiudadyFecha.Text = "Ciudad: ________________ a __ de ________ de  2011."
            Me.txtCiudadyFecha.Top = 0.4375!
            Me.txtCiudadyFecha.Width = 4.3125!
            '
            'Label20
            '
            Me.Label20.Height = 0.25!
            Me.Label20.HyperLink = Nothing
            Me.Label20.Left = 0.125!
            Me.Label20.Name = "Label20"
            Me.Label20.Style = "font-weight: normal; font-size: 11.25pt; vertical-align: top"
            Me.Label20.Text = "respectivamente a nombre de Comercial D’portenis, S. A. de C. V., Suc."
            Me.Label20.Top = 2.25!
            Me.Label20.Width = 5.375!
            '
            'Label21
            '
            Me.Label21.Height = 0.25!
            Me.Label21.HyperLink = Nothing
            Me.Label21.Left = 0.125!
            Me.Label21.Name = "Label21"
            Me.Label21.Style = "font-weight: normal; font-size: 11.25pt; vertical-align: top"
            Me.Label21.Text = "un envío remitido de la ciudad de "
            Me.Label21.Top = 2!
            Me.Label21.Width = 2.5!
            '
            'txtCiudadOrigen
            '
            Me.txtCiudadOrigen.Height = 0.25!
            Me.txtCiudadOrigen.Left = 2.625!
            Me.txtCiudadOrigen.Name = "txtCiudadOrigen"
            Me.txtCiudadOrigen.Style = "text-align: center; font-weight: bold; font-size: 11.25pt"
            Me.txtCiudadOrigen.Text = "Mazatlán"
            Me.txtCiudadOrigen.Top = 2!
            Me.txtCiudadOrigen.Width = 1.4375!
            '
            'Label23
            '
            Me.Label23.Height = 0.25!
            Me.Label23.HyperLink = Nothing
            Me.Label23.Left = 4.0625!
            Me.Label23.Name = "Label23"
            Me.Label23.Style = "font-weight: normal; font-size: 11.25pt; vertical-align: top"
            Me.Label23.Text = ", en la sucursal no."
            Me.Label23.Top = 2!
            Me.Label23.Width = 1.4375!
            '
            'txtSucOrigen
            '
            Me.txtSucOrigen.Height = 0.25!
            Me.txtSucOrigen.Left = 5.5!
            Me.txtSucOrigen.Name = "txtSucOrigen"
            Me.txtSucOrigen.Style = "text-align: center; font-weight: bold; font-size: 11.25pt"
            Me.txtSucOrigen.Text = "105"
            Me.txtSucOrigen.Top = 2!
            Me.txtSucOrigen.Width = 0.5625!
            '
            'txtSucDestino
            '
            Me.txtSucDestino.Height = 0.25!
            Me.txtSucDestino.Left = 5.5!
            Me.txtSucDestino.Name = "txtSucDestino"
            Me.txtSucDestino.Style = "text-align: center; font-weight: bold; font-size: 11.25pt"
            Me.txtSucDestino.Text = "105"
            Me.txtSucDestino.Top = 2.25!
            Me.txtSucDestino.Width = 0.5625!
            '
            'Label24
            '
            Me.Label24.Height = 0.25!
            Me.Label24.HyperLink = Nothing
            Me.Label24.Left = 6.0625!
            Me.Label24.Name = "Label24"
            Me.Label24.Style = "font-weight: normal; font-size: 11.25pt; vertical-align: top"
            Me.Label24.Text = "   Ciudad"
            Me.Label24.Top = 2.25!
            Me.Label24.Width = 1.125!
            '
            'txtCiudadDestino
            '
            Me.txtCiudadDestino.Height = 0.25!
            Me.txtCiudadDestino.Left = 0.125!
            Me.txtCiudadDestino.Name = "txtCiudadDestino"
            Me.txtCiudadDestino.Style = "text-align: left; font-weight: bold; font-size: 11.25pt"
            Me.txtCiudadDestino.Text = "Mazatlán"
            Me.txtCiudadDestino.Top = 2.5!
            Me.txtCiudadDestino.Width = 1.4375!
            '
            'Label25
            '
            Me.Label25.Height = 0.25!
            Me.Label25.HyperLink = Nothing
            Me.Label25.Left = 1.5625!
            Me.Label25.Name = "Label25"
            Me.Label25.Style = "font-weight: normal; font-size: 11.25pt; vertical-align: top"
            Me.Label25.Text = "con el numero de guía "
            Me.Label25.Top = 2.5!
            Me.Label25.Width = 1.6875!
            '
            'txtNoGuia
            '
            Me.txtNoGuia.Height = 0.25!
            Me.txtNoGuia.Left = 3.25!
            Me.txtNoGuia.Name = "txtNoGuia"
            Me.txtNoGuia.Style = "text-align: center; font-weight: bold; font-size: 11.25pt; vertical-align: middle"& _ 
                ""
            Me.txtNoGuia.Text = "1234567890"
            Me.txtNoGuia.Top = 2.5!
            Me.txtNoGuia.Width = 1.5625!
            '
            'Label26
            '
            Me.Label26.Height = 0.25!
            Me.Label26.HyperLink = Nothing
            Me.Label26.Left = 4.8125!
            Me.Label26.Name = "Label26"
            Me.Label26.Style = "font-weight: normal; font-size: 11.25pt; vertical-align: top"
            Me.Label26.Text = "; En dicho envío se depositaron"
            Me.Label26.Top = 2.5!
            Me.Label26.Width = 2.375!
            '
            'txtNoBultos
            '
            Me.txtNoBultos.Height = 0.25!
            Me.txtNoBultos.Left = 0.125!
            Me.txtNoBultos.Name = "txtNoBultos"
            Me.txtNoBultos.Style = "text-align: center; font-weight: bold; font-size: 11.25pt"
            Me.txtNoBultos.Text = "3"
            Me.txtNoBultos.Top = 2.75!
            Me.txtNoBultos.Width = 0.5625!
            '
            'Label27
            '
            Me.Label27.Height = 0.25!
            Me.Label27.HyperLink = Nothing
            Me.Label27.Left = 0.6875!
            Me.Label27.Name = "Label27"
            Me.Label27.Style = "font-weight: normal; font-size: 11.25pt; vertical-align: top"
            Me.Label27.Text = "cajas, para un total de"
            Me.Label27.Top = 2.75!
            Me.Label27.Width = 1.6875!
            '
            'txtTotalPiezas
            '
            Me.txtTotalPiezas.Height = 0.25!
            Me.txtTotalPiezas.Left = 2.375!
            Me.txtTotalPiezas.Name = "txtTotalPiezas"
            Me.txtTotalPiezas.Style = "text-align: center; font-weight: bold; font-size: 11.25pt"
            Me.txtTotalPiezas.Text = "15"
            Me.txtTotalPiezas.Top = 2.75!
            Me.txtTotalPiezas.Width = 0.5625!
            '
            'Label28
            '
            Me.Label28.Height = 0.25!
            Me.Label28.HyperLink = Nothing
            Me.Label28.Left = 2.9375!
            Me.Label28.Name = "Label28"
            Me.Label28.Style = "font-weight: normal; font-size: 11.25pt; vertical-align: top"
            Me.Label28.Text = "p/p, una vez que se recibió el envío contenía únicamente "
            Me.Label28.Top = 2.75!
            Me.Label28.Width = 4.25!
            '
            'txtPiezasRecibidas
            '
            Me.txtPiezasRecibidas.Height = 0.25!
            Me.txtPiezasRecibidas.Left = 0.125!
            Me.txtPiezasRecibidas.Name = "txtPiezasRecibidas"
            Me.txtPiezasRecibidas.Style = "text-align: center; font-weight: bold; font-size: 11.25pt"
            Me.txtPiezasRecibidas.Text = "10"
            Me.txtPiezasRecibidas.Top = 3!
            Me.txtPiezasRecibidas.Width = 0.5625!
            '
            'Label29
            '
            Me.Label29.Height = 0.25!
            Me.Label29.HyperLink = Nothing
            Me.Label29.Left = 0.6875!
            Me.Label29.Name = "Label29"
            Me.Label29.Style = "font-weight: normal; font-size: 11.25pt; vertical-align: top"
            Me.Label29.Text = "piezas, las cajas se encontraban:"
            Me.Label29.Top = 3!
            Me.Label29.Width = 2.5!
            '
            'txtComentariosPlayer
            '
            Me.txtComentariosPlayer.Height = 0.25!
            Me.txtComentariosPlayer.Left = 0.125!
            Me.txtComentariosPlayer.Name = "txtComentariosPlayer"
            Me.txtComentariosPlayer.Style = "text-align: justify; font-weight: bold; font-size: 11.25pt"
            Me.txtComentariosPlayer.Text = "La caja estaba violada"
            Me.txtComentariosPlayer.Top = 3.3125!
            Me.txtComentariosPlayer.Width = 7.0625!
            '
            'txtNombrePersonaRecibe
            '
            Me.txtNombrePersonaRecibe.Height = 0.25!
            Me.txtNombrePersonaRecibe.Left = 3.75!
            Me.txtNombrePersonaRecibe.Name = "txtNombrePersonaRecibe"
            Me.txtNombrePersonaRecibe.Style = "text-align: justify; font-weight: bold; font-size: 12pt"
            Me.txtNombrePersonaRecibe.Text = "Grabiel Quintero"
            Me.txtNombrePersonaRecibe.Top = 4.875!
            Me.txtNombrePersonaRecibe.Width = 3.4375!
            '
            'Label32
            '
            Me.Label32.Height = 0.25!
            Me.Label32.HyperLink = Nothing
            Me.Label32.Left = 0.125!
            Me.Label32.Name = "Label32"
            Me.Label32.Style = "font-weight: normal; font-size: 11.25pt; vertical-align: top"
            Me.Label32.Text = "en total haciendo falta "
            Me.Label32.Top = 3.625!
            Me.Label32.Width = 1.6875!
            '
            'txtPiezasFaltantes
            '
            Me.txtPiezasFaltantes.Height = 0.25!
            Me.txtPiezasFaltantes.Left = 1.8125!
            Me.txtPiezasFaltantes.Name = "txtPiezasFaltantes"
            Me.txtPiezasFaltantes.Style = "text-align: center; font-weight: bold; font-size: 11.25pt"
            Me.txtPiezasFaltantes.Text = "5"
            Me.txtPiezasFaltantes.Top = 3.625!
            Me.txtPiezasFaltantes.Width = 0.5625!
            '
            'Label33
            '
            Me.Label33.Height = 0.25!
            Me.Label33.HyperLink = Nothing
            Me.Label33.Left = 2.375!
            Me.Label33.Name = "Label33"
            Me.Label33.Style = "font-weight: normal; font-size: 11.25pt; vertical-align: top"
            Me.Label33.Text = "piezas, dando un total en costo de "
            Me.Label33.Top = 3.625!
            Me.Label33.Width = 2.625!
            '
            'txtCostoTotal
            '
            Me.txtCostoTotal.Height = 0.25!
            Me.txtCostoTotal.Left = 5!
            Me.txtCostoTotal.Name = "txtCostoTotal"
            Me.txtCostoTotal.Style = "text-align: center; font-weight: bold; font-size: 11.25pt"
            Me.txtCostoTotal.Text = "$ 99,999.00"
            Me.txtCostoTotal.Top = 3.625!
            Me.txtCostoTotal.Width = 1.0625!
            '
            'Label34
            '
            Me.Label34.Height = 0.25!
            Me.Label34.HyperLink = Nothing
            Me.Label34.Left = 6.0625!
            Me.Label34.Name = "Label34"
            Me.Label34.Style = "font-weight: normal; font-size: 11.25pt; vertical-align: top"
            Me.Label34.Text = "    según copia "
            Me.Label34.Top = 3.625!
            Me.Label34.Width = 1.125!
            '
            'Label35
            '
            Me.Label35.Height = 0.25!
            Me.Label35.HyperLink = Nothing
            Me.Label35.Left = 0.125!
            Me.Label35.Name = "Label35"
            Me.Label35.Style = "font-weight: normal; font-size: 11.25pt; vertical-align: top"
            Me.Label35.Text = "de traslado No. "
            Me.Label35.Top = 3.875!
            Me.Label35.Width = 1.1875!
            '
            'txtFolioTraslado
            '
            Me.txtFolioTraslado.Height = 0.25!
            Me.txtFolioTraslado.Left = 1.3125!
            Me.txtFolioTraslado.Name = "txtFolioTraslado"
            Me.txtFolioTraslado.Style = "text-align: center; font-weight: bold; font-size: 11.25pt"
            Me.txtFolioTraslado.Text = "4300399387"
            Me.txtFolioTraslado.Top = 3.875!
            Me.txtFolioTraslado.Width = 1.25!
            '
            'Label36
            '
            Me.Label36.Height = 0.25!
            Me.Label36.HyperLink = Nothing
            Me.Label36.Left = 2.5625!
            Me.Label36.Name = "Label36"
            Me.Label36.Style = "font-weight: normal; font-size: 11.25pt; vertical-align: top"
            Me.Label36.Text = "   anexo."
            Me.Label36.Top = 3.875!
            Me.Label36.Width = 0.75!
            '
            'lblNoSiniestroDHL
            '
            Me.lblNoSiniestroDHL.Height = 0.25!
            Me.lblNoSiniestroDHL.HyperLink = Nothing
            Me.lblNoSiniestroDHL.Left = 0.125!
            Me.lblNoSiniestroDHL.Name = "lblNoSiniestroDHL"
            Me.lblNoSiniestroDHL.Style = "font-weight: normal; font-size: 11.25pt; vertical-align: top"
            Me.lblNoSiniestroDHL.Text = "No. de Siniestro: ____________________________"
            Me.lblNoSiniestroDHL.Top = 4.125!
            Me.lblNoSiniestroDHL.Visible = false
            Me.lblNoSiniestroDHL.Width = 4.375!
            '
            'Label37
            '
            Me.Label37.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label37.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label37.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label37.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label37.Height = 0.1875!
            Me.Label37.HyperLink = Nothing
            Me.Label37.Left = 0.125!
            Me.Label37.Name = "Label37"
            Me.Label37.Style = "color: window; text-align: center; font-weight: bold; background-color: backgroun"& _ 
                "d; font-size: 12pt; vertical-align: middle"
            Me.Label37.Text = "Código"
            Me.Label37.Top = 5.4375!
            Me.Label37.Width = 1.25!
            '
            'Label38
            '
            Me.Label38.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label38.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label38.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label38.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label38.Height = 0.1875!
            Me.Label38.HyperLink = Nothing
            Me.Label38.Left = 1.375!
            Me.Label38.Name = "Label38"
            Me.Label38.Style = "color: window; text-align: center; font-weight: bold; background-color: backgroun"& _ 
                "d; font-size: 12pt; vertical-align: middle"
            Me.Label38.Text = "Descripción"
            Me.Label38.Top = 5.4375!
            Me.Label38.Width = 3.0625!
            '
            'Label39
            '
            Me.Label39.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label39.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label39.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label39.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label39.Height = 0.1875!
            Me.Label39.HyperLink = Nothing
            Me.Label39.Left = 4.4375!
            Me.Label39.Name = "Label39"
            Me.Label39.Style = "color: window; text-align: center; font-weight: bold; background-color: backgroun"& _ 
                "d; font-size: 12pt; vertical-align: middle"
            Me.Label39.Text = "Talla"
            Me.Label39.Top = 5.4375!
            Me.Label39.Width = 0.5!
            '
            'Label40
            '
            Me.Label40.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label40.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label40.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label40.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label40.Height = 0.1875!
            Me.Label40.HyperLink = Nothing
            Me.Label40.Left = 4.9375!
            Me.Label40.Name = "Label40"
            Me.Label40.Style = "color: window; text-align: center; font-weight: bold; background-color: backgroun"& _ 
                "d; font-size: 12pt; vertical-align: middle"
            Me.Label40.Text = "Cant"
            Me.Label40.Top = 5.4375!
            Me.Label40.Width = 0.625!
            '
            'Label41
            '
            Me.Label41.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label41.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label41.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label41.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label41.Height = 0.1875!
            Me.Label41.HyperLink = Nothing
            Me.Label41.Left = 5.5625!
            Me.Label41.Name = "Label41"
            Me.Label41.Style = "color: window; text-align: center; font-weight: bold; background-color: backgroun"& _ 
                "d; font-size: 12pt; vertical-align: middle"
            Me.Label41.Text = "Costo U."
            Me.Label41.Top = 5.4375!
            Me.Label41.Width = 0.8125!
            '
            'Label42
            '
            Me.Label42.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label42.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label42.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label42.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label42.Height = 0.1875!
            Me.Label42.HyperLink = Nothing
            Me.Label42.Left = 6.375!
            Me.Label42.Name = "Label42"
            Me.Label42.Style = "color: window; text-align: center; font-weight: bold; background-color: backgroun"& _ 
                "d; font-size: 12pt; vertical-align: middle"
            Me.Label42.Text = "Costo T."
            Me.Label42.Top = 5.4375!
            Me.Label42.Width = 0.8125!
            '
            'txtCodArticulo
            '
            Me.txtCodArticulo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtCodArticulo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtCodArticulo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtCodArticulo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtCodArticulo.DataField = "Codigo"
            Me.txtCodArticulo.Height = 0.1875!
            Me.txtCodArticulo.Left = 0.125!
            Me.txtCodArticulo.Name = "txtCodArticulo"
            Me.txtCodArticulo.Style = "font-size: 9pt"
            Me.txtCodArticulo.Text = "NK-385747-1011"
            Me.txtCodArticulo.Top = 0!
            Me.txtCodArticulo.Width = 1.25!
            '
            'txtDescripcion
            '
            Me.txtDescripcion.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtDescripcion.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtDescripcion.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtDescripcion.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtDescripcion.DataField = "Descripcion"
            Me.txtDescripcion.Height = 0.1875!
            Me.txtDescripcion.Left = 1.375!
            Me.txtDescripcion.Name = "txtDescripcion"
            Me.txtDescripcion.Style = "font-size: 9pt"
            Me.txtDescripcion.Text = "NK-385747-1011"
            Me.txtDescripcion.Top = 0!
            Me.txtDescripcion.Width = 3.0625!
            '
            'txtTalla
            '
            Me.txtTalla.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtTalla.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtTalla.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtTalla.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtTalla.DataField = "Talla"
            Me.txtTalla.Height = 0.1875!
            Me.txtTalla.Left = 4.4375!
            Me.txtTalla.Name = "txtTalla"
            Me.txtTalla.Style = "text-align: center; font-size: 9pt"
            Me.txtTalla.Text = "10.0"
            Me.txtTalla.Top = 0!
            Me.txtTalla.Width = 0.5!
            '
            'txtCantidad
            '
            Me.txtCantidad.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtCantidad.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtCantidad.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtCantidad.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtCantidad.DataField = "Cantidad"
            Me.txtCantidad.Height = 0.1875!
            Me.txtCantidad.Left = 4.9375!
            Me.txtCantidad.Name = "txtCantidad"
            Me.txtCantidad.Style = "text-align: center; font-size: 9pt"
            Me.txtCantidad.Text = "5"
            Me.txtCantidad.Top = 0!
            Me.txtCantidad.Width = 0.625!
            '
            'txtCostoUnit
            '
            Me.txtCostoUnit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtCostoUnit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtCostoUnit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtCostoUnit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtCostoUnit.DataField = "CostoUnit"
            Me.txtCostoUnit.Height = 0.1875!
            Me.txtCostoUnit.Left = 5.5625!
            Me.txtCostoUnit.Name = "txtCostoUnit"
            Me.txtCostoUnit.Style = "text-align: center; font-size: 9pt"
            Me.txtCostoUnit.Text = "$ 125.2"
            Me.txtCostoUnit.Top = 0!
            Me.txtCostoUnit.Width = 0.8125!
            '
            'txtCostoTotalPieza
            '
            Me.txtCostoTotalPieza.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtCostoTotalPieza.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtCostoTotalPieza.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtCostoTotalPieza.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtCostoTotalPieza.DataField = "CostoTotal"
            Me.txtCostoTotalPieza.Height = 0.1875!
            Me.txtCostoTotalPieza.Left = 6.375!
            Me.txtCostoTotalPieza.Name = "txtCostoTotalPieza"
            Me.txtCostoTotalPieza.Style = "text-align: center; font-size: 9pt"
            Me.txtCostoTotalPieza.Text = "$ 125.2"
            Me.txtCostoTotalPieza.Top = 0!
            Me.txtCostoTotalPieza.Width = 0.8125!
            '
            'Label9
            '
            Me.Label9.Height = 0.25!
            Me.Label9.HyperLink = Nothing
            Me.Label9.Left = 0.125!
            Me.Label9.Name = "Label9"
            Me.Label9.Style = "font-weight: normal; font-size: 12pt"
            Me.Label9.Text = "Nombre de los chóferes que entregaron el envío:"
            Me.Label9.Top = 0.125!
            Me.Label9.Width = 7.0625!
            '
            'Label12
            '
            Me.Label12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label12.Height = 0.25!
            Me.Label12.HyperLink = Nothing
            Me.Label12.Left = 0.125!
            Me.Label12.Name = "Label12"
            Me.Label12.Style = "color: window; text-align: center; font-weight: bold; background-color: backgroun"& _ 
                "d; font-size: 12pt; vertical-align: middle"
            Me.Label12.Text = "COMENTARIOS DE LOS CHÓFERES"
            Me.Label12.Top = 0.75!
            Me.Label12.Width = 7.0625!
            '
            'Label13
            '
            Me.Label13.Height = 0.25!
            Me.Label13.HyperLink = Nothing
            Me.Label13.Left = 0.125!
            Me.Label13.Name = "Label13"
            Me.Label13.Style = "font-weight: normal; font-size: 12pt"
            Me.Label13.Text = "Sin más por el momento quedo de usted para cualquier duda o aclaración."
            Me.Label13.Top = 1.8125!
            Me.Label13.Width = 7.0625!
            '
            'Label14
            '
            Me.Label14.Height = 0.25!
            Me.Label14.HyperLink = Nothing
            Me.Label14.Left = 0.125!
            Me.Label14.Name = "Label14"
            Me.Label14.Style = "text-align: center; font-weight: bold; font-size: 12pt"
            Me.Label14.Text = "ATENTAMENTE"
            Me.Label14.Top = 2.125!
            Me.Label14.Width = 7.0625!
            '
            'Label15
            '
            Me.Label15.Height = 0.25!
            Me.Label15.HyperLink = Nothing
            Me.Label15.Left = 0.125!
            Me.Label15.Name = "Label15"
            Me.Label15.Style = "text-align: center; font-weight: normal; font-size: 12pt; vertical-align: top"
            Me.Label15.Text = "_______________________________________"
            Me.Label15.Top = 2.75!
            Me.Label15.Width = 7.0625!
            '
            'Label16
            '
            Me.Label16.Height = 0.25!
            Me.Label16.HyperLink = Nothing
            Me.Label16.Left = 0.125!
            Me.Label16.Name = "Label16"
            Me.Label16.Style = "text-align: center; font-weight: normal; font-size: 9.75pt; vertical-align: top"
            Me.Label16.Text = "Nombre y Firma por Comercial D’portenis"
            Me.Label16.Top = 3!
            Me.Label16.Width = 7.0625!
            '
            'Label17
            '
            Me.Label17.Height = 0.25!
            Me.Label17.HyperLink = Nothing
            Me.Label17.Left = 0.0625!
            Me.Label17.Name = "Label17"
            Me.Label17.Style = "text-align: center; font-weight: normal; font-size: 9.75pt; vertical-align: top"
            Me.Label17.Text = "Comercial D’portenis, S. A. de C. V. "
            Me.Label17.Top = 3.375!
            Me.Label17.Width = 3.25!
            '
            'Label18
            '
            Me.Label18.Height = 0.25!
            Me.Label18.HyperLink = Nothing
            Me.Label18.Left = 3.9375!
            Me.Label18.Name = "Label18"
            Me.Label18.Style = "text-align: center; font-weight: normal; font-size: 9.75pt; vertical-align: top"
            Me.Label18.Text = "Confidencial"
            Me.Label18.Top = 3.375!
            Me.Label18.Width = 3.25!
            '
            'txtNombreChofer1
            '
            Me.txtNombreChofer1.Height = 0.25!
            Me.txtNombreChofer1.Left = 0.125!
            Me.txtNombreChofer1.Name = "txtNombreChofer1"
            Me.txtNombreChofer1.Style = "font-weight: bold; font-size: 11.25pt"
            Me.txtNombreChofer1.Text = "1.- __________________________________   "
            Me.txtNombreChofer1.Top = 0.4375!
            Me.txtNombreChofer1.Width = 3.375!
            '
            'txtNombreChofer2
            '
            Me.txtNombreChofer2.Height = 0.25!
            Me.txtNombreChofer2.Left = 3.5!
            Me.txtNombreChofer2.Name = "txtNombreChofer2"
            Me.txtNombreChofer2.Style = "font-weight: bold; font-size: 11.25pt"
            Me.txtNombreChofer2.Text = "2.- __________________________________   "
            Me.txtNombreChofer2.Top = 0.4375!
            Me.txtNombreChofer2.Width = 3.6875!
            '
            'Label30
            '
            Me.Label30.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label30.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label30.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label30.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label30.Height = 0.375!
            Me.Label30.HyperLink = Nothing
            Me.Label30.Left = 0.125!
            Me.Label30.Name = "Label30"
            Me.Label30.Style = "font-weight: normal; font-size: 12pt"
            Me.Label30.Text = ""
            Me.Label30.Top = 1!
            Me.Label30.Width = 7.0625!
            '
            'Label31
            '
            Me.Label31.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label31.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label31.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label31.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label31.Height = 0.375!
            Me.Label31.HyperLink = Nothing
            Me.Label31.Left = 0.125!
            Me.Label31.Name = "Label31"
            Me.Label31.Style = "font-weight: normal; font-size: 12pt"
            Me.Label31.Text = ""
            Me.Label31.Top = 1.375!
            Me.Label31.Width = 7.0625!
            '
            'ActiveReport1
            '
            Me.MasterReport = false
            Me.PageSettings.Margins.Bottom = 0.3!
            Me.PageSettings.Margins.Left = 0.3!
            Me.PageSettings.Margins.Right = 0.5!
            Me.PageSettings.Margins.Top = 0.3!
            Me.PageSettings.PaperHeight = 11!
            Me.PageSettings.PaperWidth = 8.5!
            Me.PrintWidth = 7.333333!
            Me.Sections.Add(Me.ReportHeader)
            Me.Sections.Add(Me.Detail)
            Me.Sections.Add(Me.ReportFooter)
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo"& _ 
                        "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit", "Heading1", "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei"& _ 
                        "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit", "Heading2", "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo"& _ 
                        "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit", "Heading3", "Normal"))
            CType(Me.Picture1,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblTitulo,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblNombrePaqueteria,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblDetalle,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label6,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label7,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label8,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtCiudadyFecha,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label20,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label21,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtCiudadOrigen,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label23,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtSucOrigen,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtSucDestino,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label24,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtCiudadDestino,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label25,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtNoGuia,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label26,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtNoBultos,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label27,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtTotalPiezas,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label28,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtPiezasRecibidas,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label29,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtComentariosPlayer,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtNombrePersonaRecibe,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label32,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtPiezasFaltantes,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label33,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtCostoTotal,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label34,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label35,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFolioTraslado,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label36,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblNoSiniestroDHL,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label37,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label38,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label39,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label40,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label41,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label42,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtCodArticulo,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtDescripcion,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtTalla,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtCantidad,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtCostoUnit,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtCostoTotalPieza,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label9,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label12,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label13,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label14,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label15,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label16,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label17,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label18,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtNombreChofer1,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtNombreChofer2,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label30,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label31,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        
	End Sub

#End Region

    Private Function ComplementarDetalle(ByVal dvFal As DataView, ByRef Costo As Decimal) As DataTable

        Dim dtTemp As DataTable = dvFal.Table.Clone

        Try
            Dim oArticulo As Articulo
            Dim oRowV As DataRowView
            Dim oRow As DataRow
1:          Dim oArticuloMgr As New CatalogoArticuloManager(oAppContext)

2:          For Each oRowV In dvFal
3:              dtTemp.ImportRow(oRowV.Row)
            Next
4:          dtTemp.AcceptChanges()

5:          dtTemp.Columns.Add("CostoUnit", GetType(Decimal))
6:          dtTemp.Columns.Add("CostoTotal", GetType(Decimal))
7:          dtTemp.AcceptChanges()

            For Each oRow In dtTemp.Rows
8:              oArticulo = Nothing
9:              oArticulo = oArticuloMgr.Load(CStr(oRow!Codigo).Trim)
10:             If Not oArticulo Is Nothing Then
11:                 oRow!CostoUnit = oArticulo.CostoProm
12:                 oRow!Cantidad = CInt(oRow!Cantidad - oRow!Lecturado)
13:                 oRow!CostoTotal = oRow!CostoUnit * oRow!Cantidad
14:                 Costo += oRow!CostoTotal
                End If
            Next
15:         dtTemp.AcceptChanges()
        Catch ex As Exception
            EscribeLog(ex.ToString, "Error al complementar el detalle de los faltantes. Linea: " & Err.Erl)
        End Try

        Return dtTemp

    End Function

    Private Function CalcularCosto(ByVal dvFal As DataView) As Decimal

        Dim Costo As Decimal = 0

        Try
            Dim oArticulo As Articulo
            Dim oRowV As DataRowView
1:          Dim oArticuloMgr As New CatalogoArticuloManager(oAppContext)

2:          For Each oRowV In dvFal
3:              oArticulo = Nothing
4:              oArticulo = oArticuloMgr.Load(CStr(oRowV!Codigo).Trim)
5:              If Not oArticulo Is Nothing Then
6:                  Costo += oArticulo.CostoProm * CInt(oRowV!Cantidad - oRowV!Lecturado)
                End If
            Next
        Catch ex As Exception
            EscribeLog(ex.ToString, "Error al calcular el costo total de los faltantes. Linea: " & Err.Erl)
        End Try

        Return Costo

    End Function

    Private Sub Detail_BeforePrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles Detail.BeforePrint
        Me.txtCostoUnit.Text = Format(CDec(Me.txtCostoUnit.Text), "$#,##0.00")
        Me.txtCostoTotalPieza.Text = Format(CDec(Me.txtCostoTotalPieza.Text), "$#,##0.00")
    End Sub
End Class
