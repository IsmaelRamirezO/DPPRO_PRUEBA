Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos

Public Class rptCartaReclamacionDHL

    Inherits DataDynamics.ActiveReports.ActiveReport

    Public Sub New(ByVal CodSucOrigen As String, ByVal strGuia As String, ByVal NoBultos As String, ByVal PiezasFaltantes As String, _
                    ByVal ComentariosPlayer As String, ByVal dvFaltantes As DataView, ByVal strFolioTraslado As String, _
                    ByVal strPaqueteria As String, ByVal PersonaRecibe As String, ByVal dtTraspasoSAP As DataTable, _
                    ByVal TipoPerdida As String, ByVal strDanos As String, ByVal NoReporte As String, ByVal FechaEnvio As Date, _
                    ByVal NoReporteDHL As String)

        MyBase.New()
        InitializeComponent()

        Try
1:          Dim oAlmacen As Almacen
2:          Dim oAlmacenMgr As New CatalogoAlmacenesManager(oAppContext, oConfigCierreFI)
            Dim CostoTotal As Decimal = 0
            Dim dtSource As DataTable
            Dim DireccionRemitenteDHL As String = ""

3:          Me.txtFecha.Text = Format(Today, "dd-MMM-yyyy")
4:          Me.txtFechaEnvio.Text = Format(FechaEnvio, "dd-MMM-yyyy")
5:          Me.txtNoGuia.Text = strGuia.Trim

            'oAlmacen = oAlmacenMgr.Load(CodSucOrigen)

            'If Not oAlmacen Is Nothing Then
            '    Me.txtOrigen.Text = oAlmacen.Descripcion.Trim & " " & CodSucOrigen.Trim
            'End If
            Dim oSapMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
            oAlmacen = Nothing
6:          oAlmacen = oAlmacenMgr.Load(oSapMgr.Read_Centros()) 'oAppContext.ApplicationConfiguration.Almacen.Trim)

7:          If Not oAlmacen Is Nothing Then
8:              Me.txtDestino.Text = oAlmacen.Descripcion.Trim & " " & oAppContext.ApplicationConfiguration.Almacen.Trim
            End If

            Dim CentroOrigen As String = ""
9:

            oAlmacen = Nothing
10:         oAlmacen = oAlmacenMgr.Load(oSapMgr.Read_Centros(CodSucOrigen))
11:         If Not oAlmacen Is Nothing Then
12:             CentroOrigen = oSapMgr.Read_Centros(CodSucOrigen.Trim)
13:             If InStr("1000,1001", CentroOrigen.Trim) > 0 Then
14:                 Me.txtOrigen.Text = oAlmacen.Descripcion.Trim & " " & CentroOrigen.Trim.ToUpper
15:                 DireccionRemitenteDHL = oAlmacen.DireccionCalle
                Else
16:                 Me.txtOrigen.Text = CodSucOrigen.ToUpper
                End If
            End If

17:         Me.txtContenidoDeclarado.Text = Format(CostoTotalTraslado(dtTraspasoSAP), "c")

18:         dtSource = ComplementarDetalle(dvFaltantes, CostoTotal)

19:         Me.txtMontoReclamado.Text = Format(CostoTotal, "c")

20:         Select Case TipoPerdida.Trim.ToUpper
                Case "Parcial".ToUpper
                    Me.txtPerdidaParcial.Text = "X"
                Case "Total".ToUpper
                    Me.txtPerdidaTotal.Text = "X"
                Case "Daños".ToUpper
                    Me.txtPerdidaDaños.Text = "X"
            End Select

21:         Me.txtEspecificaDaños.Text = strDanos.Trim
22:         Me.txtValorMcia.Text = Format(CostoTotal, "$#,##0.0")

            'datos del remitente se sacaran de SAP?, configurables? o fijos?

            oAlmacen = Nothing
23:         oAlmacen = oAlmacenMgr.Load("999")

24:         Me.txtRazonSocialRemitente.Text = "Comercial Dportenis S.A. de C.V."

25:         If Not oAlmacen Is Nothing Then
26:             Me.txtDireccionRemitente.Text = DireccionRemitenteDHL.Trim
27:             Me.txtTelefonoRemitente.Text = oAlmacen.TelefonoNum.Trim & " Ext " & oConfigCierreFI.ExtensionDHL.Trim
            End If

28:         Me.txtNoCuentaRemitente.Text = oConfigCierreFI.NoCuentaDHL.Trim
            'Me.txtCLABERemitente.Text = oConfigCierreFI.CuentaCLABE_DHL.Trim
            Dim i As Integer
            Dim Max As Integer = 0

29:         If oConfigCierreFI.CuentaCLABE_DHL.Length > 18 Then
30:             Max = 17
            Else
31:             Max = oConfigCierreFI.CuentaCLABE_DHL.Length - 1
            End If

32:         For i = 0 To Max
33:             CType(Me.ReportHeader.Controls("txtCLABE" & i), DataDynamics.ActiveReports.TextBox).Text = oConfigCierreFI.CuentaCLABE_DHL.Trim.Substring(i, 1)
            Next

34:         Me.txtNombreSolicitante.Text = PersonaRecibe.Trim
35:         If ComentariosPlayer.Trim.Length > 90 Then
36:             Me.txtObservaciones.Text = ComentariosPlayer.Trim.Substring(0, 89)
37:             Me.txtObservaciones2.Text = ComentariosPlayer.Trim.Substring(90)
38:             Me.txtObservaciones3.Text = "No. Reporte " & NoReporteDHL.Trim
            Else
39:             Me.txtObservaciones.Text = ComentariosPlayer.Trim
40:             Me.txtObservaciones2.Text = "No. Reporte " & NoReporteDHL.Trim
            End If

            'Me.DataSource = dtSource
        Catch ex As Exception
            EscribeLog(ex.ToString, "Error al generar reporte carta reclamacion DHL. Linea: " & Err.Erl)
        End Try

    End Sub

#Region "ActiveReports Designer generated code"
    Private WithEvents ReportHeader As ReportHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents ReportFooter As ReportFooter = Nothing
    Private Shape2 As Shape = Nothing
    Private Shape1 As Shape = Nothing
    Private lblTitulo As Label = Nothing
    Private lblNombrePaqueteria As Label = Nothing
    Private Label7 As Label = Nothing
    Private Label8 As Label = Nothing
    Private txtCiudadyFecha As TextBox = Nothing
    Private txtNombrePersonaRecibe As TextBox = Nothing
    Private Label37 As Label = Nothing
    Private Label38 As Label = Nothing
    Private Label39 As Label = Nothing
    Private Label40 As Label = Nothing
    Private Label41 As Label = Nothing
    Private Label42 As Label = Nothing
    Private txtFecha As TextBox = Nothing
    Private Label43 As Label = Nothing
    Private Picture1 As Picture = Nothing
    Private Label44 As Label = Nothing
    Private txtNoGuia As TextBox = Nothing
    Private Label45 As Label = Nothing
    Private txtOrigen As TextBox = Nothing
    Private Label46 As Label = Nothing
    Private Label47 As Label = Nothing
    Private txtFechaEnvio As TextBox = Nothing
    Private Label48 As Label = Nothing
    Private txtDestino As TextBox = Nothing
    Private Label49 As Label = Nothing
    Private txtMontoReclamado As TextBox = Nothing
    Private Shape4 As Shape = Nothing
    Private Label50 As Label = Nothing
    Private Picture2 As Picture = Nothing
    Private Label51 As Label = Nothing
    Private txtPerdidaParcial As TextBox = Nothing
    Private Label52 As Label = Nothing
    Private txtPerdidaTotal As TextBox = Nothing
    Private Label53 As Label = Nothing
    Private txtEspecificaDaños As TextBox = Nothing
    Private Label56 As Label = Nothing
    Private txtValorMcia As TextBox = Nothing
    Private Label57 As Label = Nothing
    Private Label58 As Label = Nothing
    Private Label59 As Label = Nothing
    Private Label60 As Label = Nothing
    Private Shape5 As Shape = Nothing
    Private Label69 As Label = Nothing
    Private Picture3 As Picture = Nothing
    Private Label70 As Label = Nothing
    Private txtRazonSocialRemitente As TextBox = Nothing
    Private Label71 As Label = Nothing
    Private txtDireccionRemitente As TextBox = Nothing
    Private Label72 As Label = Nothing
    Private txtNoCuentaRemitente As TextBox = Nothing
    Private Label73 As Label = Nothing
    Private Label75 As Label = Nothing
    Private Label77 As Label = Nothing
    Private Label78 As Label = Nothing
    Private txtTelefonoRemitente As TextBox = Nothing
    Private Label79 As Label = Nothing
    Private Label80 As Label = Nothing
    Private txtNombreSolicitante As TextBox = Nothing
    Private Label81 As Label = Nothing
    Private Label82 As Label = Nothing
    Private Label83 As Label = Nothing
    Private Label84 As Label = Nothing
    Private TextBox19 As TextBox = Nothing
    Private Label85 As Label = Nothing
    Private Label86 As Label = Nothing
    Private Label87 As Label = Nothing
    Private Label88 As Label = Nothing
    Private Label89 As Label = Nothing
    Private Label90 As Label = Nothing
    Private Shape6 As Shape = Nothing
    Private Label91 As Label = Nothing
    Private Picture4 As Picture = Nothing
    Private txtObservaciones As TextBox = Nothing
    Private txtFirmaSolicitante As TextBox = Nothing
    Private Label92 As Label = Nothing
    Private txtPerdidaDaños As TextBox = Nothing
    Private txtContenidoDeclarado As TextBox = Nothing
    Private TextBox20 As TextBox = Nothing
    Private TextBox21 As TextBox = Nothing
    Private txtObservaciones2 As TextBox = Nothing
    Private txtObservaciones3 As TextBox = Nothing
    Private TextBox24 As TextBox = Nothing
    Private txtCLABE0 As TextBox = Nothing
    Private txtCLABE1 As TextBox = Nothing
    Private txtCLABE2 As TextBox = Nothing
    Private txtCLABE3 As TextBox = Nothing
    Private txtCLABE4 As TextBox = Nothing
    Private txtCLABE5 As TextBox = Nothing
    Private txtCLABE6 As TextBox = Nothing
    Private txtCLABE7 As TextBox = Nothing
    Private txtCLABE8 As TextBox = Nothing
    Private txtCLABE9 As TextBox = Nothing
    Private txtCLABE10 As TextBox = Nothing
    Private txtCLABE11 As TextBox = Nothing
    Private txtCLABE12 As TextBox = Nothing
    Private txtCLABE13 As TextBox = Nothing
    Private txtCLABE14 As TextBox = Nothing
    Private txtCLABE15 As TextBox = Nothing
    Private txtCLABE16 As TextBox = Nothing
    Private txtCLABE17 As TextBox = Nothing
    Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptCartaReclamacionDHL))
            Me.Detail = New DataDynamics.ActiveReports.Detail()
            Me.ReportHeader = New DataDynamics.ActiveReports.ReportHeader()
            Me.ReportFooter = New DataDynamics.ActiveReports.ReportFooter()
            Me.Shape2 = New DataDynamics.ActiveReports.Shape()
            Me.Shape1 = New DataDynamics.ActiveReports.Shape()
            Me.lblTitulo = New DataDynamics.ActiveReports.Label()
            Me.lblNombrePaqueteria = New DataDynamics.ActiveReports.Label()
            Me.Label7 = New DataDynamics.ActiveReports.Label()
            Me.Label8 = New DataDynamics.ActiveReports.Label()
            Me.txtCiudadyFecha = New DataDynamics.ActiveReports.TextBox()
            Me.txtNombrePersonaRecibe = New DataDynamics.ActiveReports.TextBox()
            Me.Label37 = New DataDynamics.ActiveReports.Label()
            Me.Label38 = New DataDynamics.ActiveReports.Label()
            Me.Label39 = New DataDynamics.ActiveReports.Label()
            Me.Label40 = New DataDynamics.ActiveReports.Label()
            Me.Label41 = New DataDynamics.ActiveReports.Label()
            Me.Label42 = New DataDynamics.ActiveReports.Label()
            Me.txtFecha = New DataDynamics.ActiveReports.TextBox()
            Me.Label43 = New DataDynamics.ActiveReports.Label()
            Me.Picture1 = New DataDynamics.ActiveReports.Picture()
            Me.Label44 = New DataDynamics.ActiveReports.Label()
            Me.txtNoGuia = New DataDynamics.ActiveReports.TextBox()
            Me.Label45 = New DataDynamics.ActiveReports.Label()
            Me.txtOrigen = New DataDynamics.ActiveReports.TextBox()
            Me.Label46 = New DataDynamics.ActiveReports.Label()
            Me.Label47 = New DataDynamics.ActiveReports.Label()
            Me.txtFechaEnvio = New DataDynamics.ActiveReports.TextBox()
            Me.Label48 = New DataDynamics.ActiveReports.Label()
            Me.txtDestino = New DataDynamics.ActiveReports.TextBox()
            Me.Label49 = New DataDynamics.ActiveReports.Label()
            Me.txtMontoReclamado = New DataDynamics.ActiveReports.TextBox()
            Me.Shape4 = New DataDynamics.ActiveReports.Shape()
            Me.Label50 = New DataDynamics.ActiveReports.Label()
            Me.Picture2 = New DataDynamics.ActiveReports.Picture()
            Me.Label51 = New DataDynamics.ActiveReports.Label()
            Me.txtPerdidaParcial = New DataDynamics.ActiveReports.TextBox()
            Me.Label52 = New DataDynamics.ActiveReports.Label()
            Me.txtPerdidaTotal = New DataDynamics.ActiveReports.TextBox()
            Me.Label53 = New DataDynamics.ActiveReports.Label()
            Me.txtEspecificaDaños = New DataDynamics.ActiveReports.TextBox()
            Me.Label56 = New DataDynamics.ActiveReports.Label()
            Me.txtValorMcia = New DataDynamics.ActiveReports.TextBox()
            Me.Label57 = New DataDynamics.ActiveReports.Label()
            Me.Label58 = New DataDynamics.ActiveReports.Label()
            Me.Label59 = New DataDynamics.ActiveReports.Label()
            Me.Label60 = New DataDynamics.ActiveReports.Label()
            Me.Shape5 = New DataDynamics.ActiveReports.Shape()
            Me.Label69 = New DataDynamics.ActiveReports.Label()
            Me.Picture3 = New DataDynamics.ActiveReports.Picture()
            Me.Label70 = New DataDynamics.ActiveReports.Label()
            Me.txtRazonSocialRemitente = New DataDynamics.ActiveReports.TextBox()
            Me.Label71 = New DataDynamics.ActiveReports.Label()
            Me.txtDireccionRemitente = New DataDynamics.ActiveReports.TextBox()
            Me.Label72 = New DataDynamics.ActiveReports.Label()
            Me.txtNoCuentaRemitente = New DataDynamics.ActiveReports.TextBox()
            Me.Label73 = New DataDynamics.ActiveReports.Label()
            Me.Label75 = New DataDynamics.ActiveReports.Label()
            Me.Label77 = New DataDynamics.ActiveReports.Label()
            Me.Label78 = New DataDynamics.ActiveReports.Label()
            Me.txtTelefonoRemitente = New DataDynamics.ActiveReports.TextBox()
            Me.Label79 = New DataDynamics.ActiveReports.Label()
            Me.Label80 = New DataDynamics.ActiveReports.Label()
            Me.txtNombreSolicitante = New DataDynamics.ActiveReports.TextBox()
            Me.Label81 = New DataDynamics.ActiveReports.Label()
            Me.Label82 = New DataDynamics.ActiveReports.Label()
            Me.Label83 = New DataDynamics.ActiveReports.Label()
            Me.Label84 = New DataDynamics.ActiveReports.Label()
            Me.TextBox19 = New DataDynamics.ActiveReports.TextBox()
            Me.Label85 = New DataDynamics.ActiveReports.Label()
            Me.Label86 = New DataDynamics.ActiveReports.Label()
            Me.Label87 = New DataDynamics.ActiveReports.Label()
            Me.Label88 = New DataDynamics.ActiveReports.Label()
            Me.Label89 = New DataDynamics.ActiveReports.Label()
            Me.Label90 = New DataDynamics.ActiveReports.Label()
            Me.Shape6 = New DataDynamics.ActiveReports.Shape()
            Me.Label91 = New DataDynamics.ActiveReports.Label()
            Me.Picture4 = New DataDynamics.ActiveReports.Picture()
            Me.txtObservaciones = New DataDynamics.ActiveReports.TextBox()
            Me.txtFirmaSolicitante = New DataDynamics.ActiveReports.TextBox()
            Me.Label92 = New DataDynamics.ActiveReports.Label()
            Me.txtPerdidaDaños = New DataDynamics.ActiveReports.TextBox()
            Me.txtContenidoDeclarado = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox20 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox21 = New DataDynamics.ActiveReports.TextBox()
            Me.txtObservaciones2 = New DataDynamics.ActiveReports.TextBox()
            Me.txtObservaciones3 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox24 = New DataDynamics.ActiveReports.TextBox()
            Me.txtCLABE0 = New DataDynamics.ActiveReports.TextBox()
            Me.txtCLABE1 = New DataDynamics.ActiveReports.TextBox()
            Me.txtCLABE2 = New DataDynamics.ActiveReports.TextBox()
            Me.txtCLABE3 = New DataDynamics.ActiveReports.TextBox()
            Me.txtCLABE4 = New DataDynamics.ActiveReports.TextBox()
            Me.txtCLABE5 = New DataDynamics.ActiveReports.TextBox()
            Me.txtCLABE6 = New DataDynamics.ActiveReports.TextBox()
            Me.txtCLABE7 = New DataDynamics.ActiveReports.TextBox()
            Me.txtCLABE8 = New DataDynamics.ActiveReports.TextBox()
            Me.txtCLABE9 = New DataDynamics.ActiveReports.TextBox()
            Me.txtCLABE10 = New DataDynamics.ActiveReports.TextBox()
            Me.txtCLABE11 = New DataDynamics.ActiveReports.TextBox()
            Me.txtCLABE12 = New DataDynamics.ActiveReports.TextBox()
            Me.txtCLABE13 = New DataDynamics.ActiveReports.TextBox()
            Me.txtCLABE14 = New DataDynamics.ActiveReports.TextBox()
            Me.txtCLABE15 = New DataDynamics.ActiveReports.TextBox()
            Me.txtCLABE16 = New DataDynamics.ActiveReports.TextBox()
            Me.txtCLABE17 = New DataDynamics.ActiveReports.TextBox()
            CType(Me.lblTitulo,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblNombrePaqueteria,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label7,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label8,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtCiudadyFecha,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtNombrePersonaRecibe,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label37,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label38,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label39,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label40,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label41,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label42,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFecha,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label43,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Picture1,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label44,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtNoGuia,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label45,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtOrigen,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label46,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label47,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFechaEnvio,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label48,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtDestino,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label49,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtMontoReclamado,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label50,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Picture2,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label51,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtPerdidaParcial,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label52,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtPerdidaTotal,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label53,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtEspecificaDaños,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label56,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtValorMcia,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label57,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label58,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label59,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label60,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label69,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Picture3,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label70,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtRazonSocialRemitente,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label71,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtDireccionRemitente,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label72,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtNoCuentaRemitente,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label73,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label75,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label77,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label78,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtTelefonoRemitente,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label79,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label80,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtNombreSolicitante,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label81,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label82,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label83,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label84,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox19,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label85,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label86,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label87,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label88,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label89,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label90,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label91,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Picture4,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtObservaciones,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFirmaSolicitante,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label92,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtPerdidaDaños,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtContenidoDeclarado,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox20,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox21,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtObservaciones2,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtObservaciones3,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox24,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtCLABE0,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtCLABE1,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtCLABE2,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtCLABE3,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtCLABE4,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtCLABE5,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtCLABE6,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtCLABE7,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtCLABE8,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtCLABE9,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtCLABE10,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtCLABE11,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtCLABE12,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtCLABE13,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtCLABE14,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtCLABE15,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtCLABE16,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtCLABE17,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
            '
            'Detail
            '
            Me.Detail.BackColor = System.Drawing.Color.FromArgb(CType(CType(139,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer))
            Me.Detail.ColumnSpacing = 0!
            Me.Detail.Height = 0!
            Me.Detail.Name = "Detail"
            '
            'ReportHeader
            '
            Me.ReportHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(139,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer))
            Me.ReportHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape2, Me.Shape1, Me.lblTitulo, Me.lblNombrePaqueteria, Me.Label7, Me.Label8, Me.txtCiudadyFecha, Me.txtNombrePersonaRecibe, Me.Label37, Me.Label38, Me.Label39, Me.Label40, Me.Label41, Me.Label42, Me.txtFecha, Me.Label43, Me.Picture1, Me.Label44, Me.txtNoGuia, Me.Label45, Me.txtOrigen, Me.Label46, Me.Label47, Me.txtFechaEnvio, Me.Label48, Me.txtDestino, Me.Label49, Me.txtMontoReclamado, Me.Shape4, Me.Label50, Me.Picture2, Me.Label51, Me.txtPerdidaParcial, Me.Label52, Me.txtPerdidaTotal, Me.Label53, Me.txtEspecificaDaños, Me.Label56, Me.txtValorMcia, Me.Label57, Me.Label58, Me.Label59, Me.Label60, Me.Shape5, Me.Label69, Me.Picture3, Me.Label70, Me.txtRazonSocialRemitente, Me.Label71, Me.txtDireccionRemitente, Me.Label72, Me.txtNoCuentaRemitente, Me.Label73, Me.Label75, Me.Label77, Me.Label78, Me.txtTelefonoRemitente, Me.Label79, Me.Label80, Me.txtNombreSolicitante, Me.Label81, Me.Label82, Me.Label83, Me.Label84, Me.TextBox19, Me.Label85, Me.Label86, Me.Label87, Me.Label88, Me.Label89, Me.Label90, Me.Shape6, Me.Label91, Me.Picture4, Me.txtObservaciones, Me.txtFirmaSolicitante, Me.Label92, Me.txtPerdidaDaños, Me.txtContenidoDeclarado, Me.TextBox20, Me.TextBox21, Me.txtObservaciones2, Me.txtObservaciones3, Me.TextBox24, Me.txtCLABE0, Me.txtCLABE1, Me.txtCLABE2, Me.txtCLABE3, Me.txtCLABE4, Me.txtCLABE5, Me.txtCLABE6, Me.txtCLABE7, Me.txtCLABE8, Me.txtCLABE9, Me.txtCLABE10, Me.txtCLABE11, Me.txtCLABE12, Me.txtCLABE13, Me.txtCLABE14, Me.txtCLABE15, Me.txtCLABE16, Me.txtCLABE17})
            Me.ReportHeader.Height = 10.375!
            Me.ReportHeader.Name = "ReportHeader"
            '
            'ReportFooter
            '
            Me.ReportFooter.BackColor = System.Drawing.Color.FromArgb(CType(CType(139,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer))
            Me.ReportFooter.Height = 0!
            Me.ReportFooter.Name = "ReportFooter"
            '
            'Shape2
            '
            Me.Shape2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(215,Byte),Integer), CType(CType(0,Byte),Integer))
            Me.Shape2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Shape2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Shape2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Shape2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Shape2.Height = 0.8125!
            Me.Shape2.Left = 0.125!
            Me.Shape2.LineColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(255,Byte),Integer), CType(CType(255,Byte),Integer))
            Me.Shape2.Name = "Shape2"
            Me.Shape2.RoundingRadius = 9.999999!
            Me.Shape2.Top = 0.0625!
            Me.Shape2.Width = 7.0625!
            '
            'Shape1
            '
            Me.Shape1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(215,Byte),Integer), CType(CType(0,Byte),Integer))
            Me.Shape1.Height = 1.6875!
            Me.Shape1.Left = 0.125!
            Me.Shape1.Name = "Shape1"
            Me.Shape1.RoundingRadius = 9.999999!
            Me.Shape1.Top = 0.9375!
            Me.Shape1.Width = 7.0625!
            '
            'lblTitulo
            '
            Me.lblTitulo.Height = 0.3125!
            Me.lblTitulo.HyperLink = Nothing
            Me.lblTitulo.Left = 0.25!
            Me.lblTitulo.Name = "lblTitulo"
            Me.lblTitulo.Style = "text-align: left; font-weight: bold; font-size: 15.75pt"
            Me.lblTitulo.Text = "FORMATO DE RECLAMACIÓN"
            Me.lblTitulo.Top = 0.125!
            Me.lblTitulo.Width = 6.8125!
            '
            'lblNombrePaqueteria
            '
            Me.lblNombrePaqueteria.Height = 0.25!
            Me.lblNombrePaqueteria.HyperLink = Nothing
            Me.lblNombrePaqueteria.Left = 0.3125!
            Me.lblNombrePaqueteria.Name = "lblNombrePaqueteria"
            Me.lblNombrePaqueteria.Style = "font-weight: bold; font-size: 9.75pt"
            Me.lblNombrePaqueteria.Text = "I. DATOS DEL ENVÍO (GUÍA)"
            Me.lblNombrePaqueteria.Top = 1.0625!
            Me.lblNombrePaqueteria.Width = 1.9375!
            '
            'Label7
            '
            Me.Label7.Height = 0.25!
            Me.Label7.HyperLink = Nothing
            Me.Label7.Left = 0.125!
            Me.Label7.Name = "Label7"
            Me.Label7.Style = "font-weight: normal; font-size: 12pt"
            Me.Label7.Text = "Nombre de la persona que recibió la mercancía: "
            Me.Label7.Top = 2.875!
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
            Me.Label8.Top = 3.1875!
            Me.Label8.Width = 7.0625!
            '
            'txtCiudadyFecha
            '
            Me.txtCiudadyFecha.Height = 0.25!
            Me.txtCiudadyFecha.Left = 4.4375!
            Me.txtCiudadyFecha.Name = "txtCiudadyFecha"
            Me.txtCiudadyFecha.Style = "text-align: left; font-weight: normal; font-size: 8.25pt"
            Me.txtCiudadyFecha.Text = "FECHA DE EXPEDICIÓN"
            Me.txtCiudadyFecha.Top = 0.4375!
            Me.txtCiudadyFecha.Width = 1.8125!
            '
            'txtNombrePersonaRecibe
            '
            Me.txtNombrePersonaRecibe.Height = 0.25!
            Me.txtNombrePersonaRecibe.Left = 3.75!
            Me.txtNombrePersonaRecibe.Name = "txtNombrePersonaRecibe"
            Me.txtNombrePersonaRecibe.Style = "text-align: justify; font-weight: bold; font-size: 12pt"
            Me.txtNombrePersonaRecibe.Text = "Grabiel Quintero"
            Me.txtNombrePersonaRecibe.Top = 2.875!
            Me.txtNombrePersonaRecibe.Width = 3.4375!
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
            Me.Label37.Top = 3.4375!
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
            Me.Label38.Top = 3.4375!
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
            Me.Label39.Top = 3.4375!
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
            Me.Label40.Top = 3.4375!
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
            Me.Label41.Top = 3.4375!
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
            Me.Label42.Top = 3.4375!
            Me.Label42.Width = 0.8125!
            '
            'txtFecha
            '
            Me.txtFecha.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtFecha.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtFecha.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtFecha.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtFecha.Height = 0.1875!
            Me.txtFecha.Left = 5.8125!
            Me.txtFecha.Name = "txtFecha"
            Me.txtFecha.Style = "text-align: center; font-weight: normal; background-color: window; font-size: 9pt"& _ 
                ""
            Me.txtFecha.Text = "20-mar-2012"
            Me.txtFecha.Top = 0.4375!
            Me.txtFecha.Width = 1.25!
            '
            'Label43
            '
            Me.Label43.Height = 0.1875!
            Me.Label43.HyperLink = Nothing
            Me.Label43.Left = 0.25!
            Me.Label43.Name = "Label43"
            Me.Label43.Style = "font-weight: normal; font-size: 6.75pt; font-family: Arial; vertical-align: top"
            Me.Label43.Text = "Nota: Suplicamos regresar este formato firmado en ambos recuadros antes de 3 días"& _ 
                " hábiles, ya que pasado este lapso, cerraremos el expediente."
            Me.Label43.Top = 0.6875!
            Me.Label43.Width = 6.8125!
            '
            'Picture1
            '
            Me.Picture1.Height = 0.3125!
            Me.Picture1.ImageData = CType(resources.GetObject("Picture1.ImageData"),System.IO.Stream)
            Me.Picture1.Left = 5.8125!
            Me.Picture1.LineColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(255,Byte),Integer), CType(CType(255,Byte),Integer))
            Me.Picture1.LineWeight = 0!
            Me.Picture1.Name = "Picture1"
            Me.Picture1.SizeMode = DataDynamics.ActiveReports.SizeModes.Stretch
            Me.Picture1.Top = 1!
            Me.Picture1.Width = 1.25!
            '
            'Label44
            '
            Me.Label44.Height = 0.25!
            Me.Label44.HyperLink = Nothing
            Me.Label44.Left = 0.3125!
            Me.Label44.Name = "Label44"
            Me.Label44.Style = "text-align: right; font-weight: bold; font-size: 8.25pt"
            Me.Label44.Text = "N° DE GUÍA:"
            Me.Label44.Top = 1.375!
            Me.Label44.Width = 1.375!
            '
            'txtNoGuia
            '
            Me.txtNoGuia.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtNoGuia.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtNoGuia.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtNoGuia.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtNoGuia.Height = 0.1875!
            Me.txtNoGuia.Left = 1.75!
            Me.txtNoGuia.Name = "txtNoGuia"
            Me.txtNoGuia.Style = "text-align: center; font-weight: normal; background-color: window; font-size: 9pt"& _ 
                ""
            Me.txtNoGuia.Text = "12345"
            Me.txtNoGuia.Top = 1.375!
            Me.txtNoGuia.Width = 1.375!
            '
            'Label45
            '
            Me.Label45.Height = 0.25!
            Me.Label45.HyperLink = Nothing
            Me.Label45.Left = 0.3125!
            Me.Label45.Name = "Label45"
            Me.Label45.Style = "text-align: right; font-weight: bold; font-size: 8.25pt"
            Me.Label45.Text = "ORIGEN:"
            Me.Label45.Top = 1.625!
            Me.Label45.Width = 1.375!
            '
            'txtOrigen
            '
            Me.txtOrigen.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtOrigen.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtOrigen.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtOrigen.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtOrigen.Height = 0.1875!
            Me.txtOrigen.Left = 1.75!
            Me.txtOrigen.Name = "txtOrigen"
            Me.txtOrigen.Style = "text-align: center; font-weight: normal; background-color: window; font-size: 6.7"& _ 
                "5pt"
            Me.txtOrigen.Text = "A001"
            Me.txtOrigen.Top = 1.625!
            Me.txtOrigen.Width = 1.375!
            '
            'Label46
            '
            Me.Label46.Height = 0.25!
            Me.Label46.HyperLink = Nothing
            Me.Label46.Left = 0.125!
            Me.Label46.Name = "Label46"
            Me.Label46.Style = "text-align: right; font-weight: bold; font-size: 8.25pt"
            Me.Label46.Text = "CONTENIDO DECLARADO:"
            Me.Label46.Top = 1.875!
            Me.Label46.Width = 1.5625!
            '
            'Label47
            '
            Me.Label47.Height = 0.25!
            Me.Label47.HyperLink = Nothing
            Me.Label47.Left = 3.5625!
            Me.Label47.Name = "Label47"
            Me.Label47.Style = "text-align: right; font-weight: bold; font-size: 8.25pt"
            Me.Label47.Text = "FECHA DE SALIDA DEL ENVÍO:"
            Me.Label47.Top = 1.375!
            Me.Label47.Width = 2.0625!
            '
            'txtFechaEnvio
            '
            Me.txtFechaEnvio.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtFechaEnvio.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtFechaEnvio.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtFechaEnvio.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtFechaEnvio.Height = 0.1875!
            Me.txtFechaEnvio.Left = 5.6875!
            Me.txtFechaEnvio.Name = "txtFechaEnvio"
            Me.txtFechaEnvio.Style = "text-align: center; font-weight: normal; background-color: window; font-size: 9pt"& _ 
                ""
            Me.txtFechaEnvio.Text = "20-mar-2012"
            Me.txtFechaEnvio.Top = 1.375!
            Me.txtFechaEnvio.Width = 1.375!
            '
            'Label48
            '
            Me.Label48.Height = 0.25!
            Me.Label48.HyperLink = Nothing
            Me.Label48.Left = 4.875!
            Me.Label48.Name = "Label48"
            Me.Label48.Style = "text-align: right; font-weight: bold; font-size: 8.25pt"
            Me.Label48.Text = "DESTINO:"
            Me.Label48.Top = 1.625!
            Me.Label48.Width = 0.75!
            '
            'txtDestino
            '
            Me.txtDestino.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtDestino.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtDestino.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtDestino.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtDestino.Height = 0.1875!
            Me.txtDestino.Left = 5.6875!
            Me.txtDestino.Name = "txtDestino"
            Me.txtDestino.Style = "text-align: center; font-weight: normal; background-color: window; font-size: 6.7"& _ 
                "5pt"
            Me.txtDestino.Text = "B053"
            Me.txtDestino.Top = 1.625!
            Me.txtDestino.Width = 1.375!
            '
            'Label49
            '
            Me.Label49.Height = 0.25!
            Me.Label49.HyperLink = Nothing
            Me.Label49.Left = 4.3125!
            Me.Label49.Name = "Label49"
            Me.Label49.Style = "text-align: right; font-weight: bold; font-size: 8.25pt"
            Me.Label49.Text = "MONTO RECLAMADO:"
            Me.Label49.Top = 2.375!
            Me.Label49.Width = 1.3125!
            '
            'txtMontoReclamado
            '
            Me.txtMontoReclamado.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtMontoReclamado.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtMontoReclamado.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtMontoReclamado.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtMontoReclamado.Height = 0.1875!
            Me.txtMontoReclamado.Left = 5.6875!
            Me.txtMontoReclamado.Name = "txtMontoReclamado"
            Me.txtMontoReclamado.Style = "text-align: center; font-weight: normal; background-color: window; font-size: 9.7"& _ 
                "5pt"
            Me.txtMontoReclamado.Text = "$ 1525.00"
            Me.txtMontoReclamado.Top = 2.375!
            Me.txtMontoReclamado.Width = 1.375!
            '
            'Shape4
            '
            Me.Shape4.BackColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(215,Byte),Integer), CType(CType(0,Byte),Integer))
            Me.Shape4.Height = 2.9375!
            Me.Shape4.Left = 0.125!
            Me.Shape4.Name = "Shape4"
            Me.Shape4.RoundingRadius = 9.999999!
            Me.Shape4.Top = 2.6875!
            Me.Shape4.Width = 7.0625!
            '
            'Label50
            '
            Me.Label50.Height = 0.25!
            Me.Label50.HyperLink = Nothing
            Me.Label50.Left = 0.3125!
            Me.Label50.Name = "Label50"
            Me.Label50.Style = "font-weight: bold; font-size: 9.75pt"
            Me.Label50.Text = "II. DATOS DEL INCIDENTE O SINIESTRO"
            Me.Label50.Top = 2.8125!
            Me.Label50.Width = 3.25!
            '
            'Picture2
            '
            Me.Picture2.Height = 0.375!
            Me.Picture2.ImageData = CType(resources.GetObject("Picture2.ImageData"),System.IO.Stream)
            Me.Picture2.Left = 5.8125!
            Me.Picture2.LineColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(255,Byte),Integer), CType(CType(255,Byte),Integer))
            Me.Picture2.LineWeight = 0!
            Me.Picture2.Name = "Picture2"
            Me.Picture2.SizeMode = DataDynamics.ActiveReports.SizeModes.Stretch
            Me.Picture2.Top = 2.8125!
            Me.Picture2.Width = 1.25!
            '
            'Label51
            '
            Me.Label51.Height = 0.25!
            Me.Label51.HyperLink = Nothing
            Me.Label51.Left = 0.3125!
            Me.Label51.Name = "Label51"
            Me.Label51.Style = "text-align: right; font-weight: bold; font-size: 8.25pt"
            Me.Label51.Text = "PÉRDIDA PARCIAL:"
            Me.Label51.Top = 3.1875!
            Me.Label51.Width = 1.375!
            '
            'txtPerdidaParcial
            '
            Me.txtPerdidaParcial.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtPerdidaParcial.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtPerdidaParcial.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtPerdidaParcial.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtPerdidaParcial.Height = 0.1875!
            Me.txtPerdidaParcial.Left = 1.75!
            Me.txtPerdidaParcial.Name = "txtPerdidaParcial"
            Me.txtPerdidaParcial.Style = "text-align: center; font-weight: normal; background-color: window; font-size: 9pt"& _ 
                ""
            Me.txtPerdidaParcial.Top = 3.1875!
            Me.txtPerdidaParcial.Width = 0.9375!
            '
            'Label52
            '
            Me.Label52.Height = 0.25!
            Me.Label52.HyperLink = Nothing
            Me.Label52.Left = 0.3125!
            Me.Label52.Name = "Label52"
            Me.Label52.Style = "text-align: right; font-weight: bold; font-size: 8.25pt"
            Me.Label52.Text = "PÉRDIDA TOTAL:"
            Me.Label52.Top = 3.4375!
            Me.Label52.Width = 1.375!
            '
            'txtPerdidaTotal
            '
            Me.txtPerdidaTotal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtPerdidaTotal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtPerdidaTotal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtPerdidaTotal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtPerdidaTotal.Height = 0.1875!
            Me.txtPerdidaTotal.Left = 1.75!
            Me.txtPerdidaTotal.Name = "txtPerdidaTotal"
            Me.txtPerdidaTotal.Style = "text-align: center; font-weight: normal; background-color: window; font-size: 9pt"& _ 
                ""
            Me.txtPerdidaTotal.Top = 3.4375!
            Me.txtPerdidaTotal.Width = 0.9375!
            '
            'Label53
            '
            Me.Label53.Height = 0.25!
            Me.Label53.HyperLink = Nothing
            Me.Label53.Left = 0.125!
            Me.Label53.Name = "Label53"
            Me.Label53.Style = "text-align: right; font-weight: bold; font-size: 8.25pt"
            Me.Label53.Text = "EN CASO DE DAÑO ESPECIFICAR:"
            Me.Label53.Top = 3.9375!
            Me.Label53.Width = 2.0625!
            '
            'txtEspecificaDaños
            '
            Me.txtEspecificaDaños.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtEspecificaDaños.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtEspecificaDaños.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtEspecificaDaños.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtEspecificaDaños.Height = 0.1875!
            Me.txtEspecificaDaños.Left = 2.25!
            Me.txtEspecificaDaños.Name = "txtEspecificaDaños"
            Me.txtEspecificaDaños.Style = "text-align: left; font-weight: normal; background-color: window; font-size: 9pt"
            Me.txtEspecificaDaños.Top = 3.9375!
            Me.txtEspecificaDaños.Width = 4.8125!
            '
            'Label56
            '
            Me.Label56.Height = 0.25!
            Me.Label56.HyperLink = Nothing
            Me.Label56.Left = 2.25!
            Me.Label56.Name = "Label56"
            Me.Label56.Style = "text-align: right; font-weight: bold; font-size: 8.25pt"
            Me.Label56.Text = "VALOR COMPROBABLE DE LA MERCANCÍA:"
            Me.Label56.Top = 4.4375!
            Me.Label56.Width = 3.375!
            '
            'txtValorMcia
            '
            Me.txtValorMcia.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtValorMcia.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtValorMcia.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtValorMcia.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtValorMcia.Height = 0.1875!
            Me.txtValorMcia.Left = 5.6875!
            Me.txtValorMcia.Name = "txtValorMcia"
            Me.txtValorMcia.Style = "text-align: center; font-weight: normal; background-color: window; font-size: 9pt"& _ 
                ""
            Me.txtValorMcia.Text = " "
            Me.txtValorMcia.Top = 4.4375!
            Me.txtValorMcia.Width = 1.375!
            '
            'Label57
            '
            Me.Label57.Height = 0.25!
            Me.Label57.HyperLink = Nothing
            Me.Label57.Left = 0.25!
            Me.Label57.Name = "Label57"
            Me.Label57.Style = "text-align: left; font-weight: bold; font-size: 8.25pt"
            Me.Label57.Text = "Anexar al presente los siguientes documentos:"
            Me.Label57.Top = 4.75!
            Me.Label57.Width = 4.75!
            '
            'Label58
            '
            Me.Label58.Height = 0.1875!
            Me.Label58.HyperLink = Nothing
            Me.Label58.Left = 0.25!
            Me.Label58.Name = "Label58"
            Me.Label58.Style = "text-align: left; font-weight: bold; font-size: 8.25pt"
            Me.Label58.Text = "1.- Guía"
            Me.Label58.Top = 5!
            Me.Label58.Width = 4.75!
            '
            'Label59
            '
            Me.Label59.Height = 0.1875!
            Me.Label59.HyperLink = Nothing
            Me.Label59.Left = 0.25!
            Me.Label59.Name = "Label59"
            Me.Label59.Style = "text-align: left; font-weight: bold; font-size: 8.25pt"
            Me.Label59.Text = "2.- Factura de mercancía"
            Me.Label59.Top = 5.1875!
            Me.Label59.Width = 4.75!
            '
            'Label60
            '
            Me.Label60.Height = 0.1875!
            Me.Label60.HyperLink = Nothing
            Me.Label60.Left = 0.25!
            Me.Label60.Name = "Label60"
            Me.Label60.Style = "text-align: left; font-weight: bold; font-size: 8.25pt"
            Me.Label60.Text = "3.- Copia del estado de cuenta con información legible (Número de cuenta y Clabe "& _ 
                "interbancaria)"
            Me.Label60.Top = 5.375!
            Me.Label60.Width = 6.8125!
            '
            'Shape5
            '
            Me.Shape5.BackColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(215,Byte),Integer), CType(CType(0,Byte),Integer))
            Me.Shape5.Height = 3.1875!
            Me.Shape5.Left = 0.125!
            Me.Shape5.Name = "Shape5"
            Me.Shape5.RoundingRadius = 9.999999!
            Me.Shape5.Top = 5.6875!
            Me.Shape5.Width = 7.0625!
            '
            'Label69
            '
            Me.Label69.Height = 0.25!
            Me.Label69.HyperLink = Nothing
            Me.Label69.Left = 0.3125!
            Me.Label69.Name = "Label69"
            Me.Label69.Style = "font-weight: bold; font-size: 9.75pt"
            Me.Label69.Text = "III. DATOS DEL REMITENTE"
            Me.Label69.Top = 5.8125!
            Me.Label69.Width = 3.25!
            '
            'Picture3
            '
            Me.Picture3.Height = 0.375!
            Me.Picture3.ImageData = CType(resources.GetObject("Picture3.ImageData"),System.IO.Stream)
            Me.Picture3.Left = 5.8125!
            Me.Picture3.LineColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(255,Byte),Integer), CType(CType(255,Byte),Integer))
            Me.Picture3.LineWeight = 0!
            Me.Picture3.Name = "Picture3"
            Me.Picture3.SizeMode = DataDynamics.ActiveReports.SizeModes.Stretch
            Me.Picture3.Top = 5.75!
            Me.Picture3.Width = 1.25!
            '
            'Label70
            '
            Me.Label70.Height = 0.25!
            Me.Label70.HyperLink = Nothing
            Me.Label70.Left = 0.125!
            Me.Label70.Name = "Label70"
            Me.Label70.Style = "text-align: right; font-weight: bold; font-size: 8.25pt"
            Me.Label70.Text = "NOMBRE Y/O RAZÓN SOCIAL"
            Me.Label70.Top = 6.1875!
            Me.Label70.Width = 1.6875!
            '
            'txtRazonSocialRemitente
            '
            Me.txtRazonSocialRemitente.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtRazonSocialRemitente.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtRazonSocialRemitente.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtRazonSocialRemitente.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtRazonSocialRemitente.Height = 0.1875!
            Me.txtRazonSocialRemitente.Left = 1.875!
            Me.txtRazonSocialRemitente.Name = "txtRazonSocialRemitente"
            Me.txtRazonSocialRemitente.Style = "text-align: center; font-weight: normal; background-color: window; font-size: 9pt"& _ 
                ""
            Me.txtRazonSocialRemitente.Top = 6.1875!
            Me.txtRazonSocialRemitente.Width = 5.1875!
            '
            'Label71
            '
            Me.Label71.Height = 0.25!
            Me.Label71.HyperLink = Nothing
            Me.Label71.Left = 0.4375!
            Me.Label71.Name = "Label71"
            Me.Label71.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
            Me.Label71.Text = "DIRECCIÓN"
            Me.Label71.Top = 6.4375!
            Me.Label71.Width = 1.375!
            '
            'txtDireccionRemitente
            '
            Me.txtDireccionRemitente.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtDireccionRemitente.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtDireccionRemitente.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtDireccionRemitente.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtDireccionRemitente.Height = 0.1875!
            Me.txtDireccionRemitente.Left = 1.875!
            Me.txtDireccionRemitente.Name = "txtDireccionRemitente"
            Me.txtDireccionRemitente.Style = "text-align: left; font-weight: normal; background-color: window; font-size: 6.75p"& _ 
                "t"
            Me.txtDireccionRemitente.Text = "Carretera Mazatlán Aeropuerto KM-274 mas 700 No. L-1 Y 2, Parque industrial, Loca"& _ 
                "lidad La Urraca Nueva"
            Me.txtDireccionRemitente.Top = 6.4375!
            Me.txtDireccionRemitente.Width = 5.1875!
            '
            'Label72
            '
            Me.Label72.Height = 0.25!
            Me.Label72.HyperLink = Nothing
            Me.Label72.Left = 0.3125!
            Me.Label72.Name = "Label72"
            Me.Label72.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
            Me.Label72.Text = "TELÉFONO"
            Me.Label72.Top = 6.6875!
            Me.Label72.Width = 1.5!
            '
            'txtNoCuentaRemitente
            '
            Me.txtNoCuentaRemitente.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtNoCuentaRemitente.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtNoCuentaRemitente.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtNoCuentaRemitente.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtNoCuentaRemitente.Height = 0.1875!
            Me.txtNoCuentaRemitente.Left = 5.5625!
            Me.txtNoCuentaRemitente.Name = "txtNoCuentaRemitente"
            Me.txtNoCuentaRemitente.Style = "text-align: left; font-weight: normal; background-color: window; font-size: 9pt"
            Me.txtNoCuentaRemitente.Top = 6.6875!
            Me.txtNoCuentaRemitente.Width = 1.5!
            '
            'Label73
            '
            Me.Label73.Height = 0.25!
            Me.Label73.HyperLink = Nothing
            Me.Label73.Left = 0.375!
            Me.Label73.Name = "Label73"
            Me.Label73.Style = "text-align: left; font-weight: bold; font-size: 8.25pt"
            Me.Label73.Text = "Transferencia electrónica"
            Me.Label73.Top = 7.25!
            Me.Label73.Width = 1.5!
            '
            'Label75
            '
            Me.Label75.Height = 0.25!
            Me.Label75.HyperLink = Nothing
            Me.Label75.Left = 0.25!
            Me.Label75.Name = "Label75"
            Me.Label75.Style = "text-align: left; font-weight: bold; font-size: 8.25pt"
            Me.Label75.Text = "NOMBRE"
            Me.Label75.Top = 7.8125!
            Me.Label75.Width = 1!
            '
            'Label77
            '
            Me.Label77.Height = 0.75!
            Me.Label77.HyperLink = Nothing
            Me.Label77.Left = 0.25!
            Me.Label77.Name = "Label77"
            Me.Label77.Style = "text-align: justify; font-weight: bold; font-size: 8.25pt"
            Me.Label77.Text = resources.GetString("Label77.Text")
            Me.Label77.Top = 8.125!
            Me.Label77.Width = 6.8125!
            '
            'Label78
            '
            Me.Label78.Height = 0.25!
            Me.Label78.HyperLink = Nothing
            Me.Label78.Left = 4!
            Me.Label78.Name = "Label78"
            Me.Label78.Style = "text-align: right; font-weight: bold; font-size: 8.25pt"
            Me.Label78.Text = "N° DE CUENTA"
            Me.Label78.Top = 6.6875!
            Me.Label78.Width = 1.5!
            '
            'txtTelefonoRemitente
            '
            Me.txtTelefonoRemitente.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtTelefonoRemitente.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtTelefonoRemitente.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtTelefonoRemitente.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtTelefonoRemitente.Height = 0.1875!
            Me.txtTelefonoRemitente.Left = 1.875!
            Me.txtTelefonoRemitente.Name = "txtTelefonoRemitente"
            Me.txtTelefonoRemitente.Style = "text-align: left; font-weight: normal; background-color: window; font-size: 9pt"
            Me.txtTelefonoRemitente.Top = 6.6875!
            Me.txtTelefonoRemitente.Width = 2.625!
            '
            'Label79
            '
            Me.Label79.Height = 0.25!
            Me.Label79.HyperLink = Nothing
            Me.Label79.Left = 0.3125!
            Me.Label79.Name = "Label79"
            Me.Label79.Style = "font-weight: bold; font-size: 9.75pt"
            Me.Label79.Text = "IV. FORMA DE PAGO"
            Me.Label79.Top = 7!
            Me.Label79.Width = 3.25!
            '
            'Label80
            '
            Me.Label80.Height = 0.25!
            Me.Label80.HyperLink = Nothing
            Me.Label80.Left = 0.0625!
            Me.Label80.Name = "Label80"
            Me.Label80.Style = "text-align: right; font-weight: bold; font-size: 8.25pt"
            Me.Label80.Text = "Cuenta CLABE (18 dígitos)"
            Me.Label80.Top = 7.5!
            Me.Label80.Width = 1.8125!
            '
            'txtNombreSolicitante
            '
            Me.txtNombreSolicitante.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtNombreSolicitante.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtNombreSolicitante.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtNombreSolicitante.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtNombreSolicitante.Height = 0.1875!
            Me.txtNombreSolicitante.Left = 1.25!
            Me.txtNombreSolicitante.Name = "txtNombreSolicitante"
            Me.txtNombreSolicitante.Style = "text-align: left; font-weight: normal; background-color: window; font-size: 9pt"
            Me.txtNombreSolicitante.Top = 7.8125!
            Me.txtNombreSolicitante.Width = 3.4375!
            '
            'Label81
            '
            Me.Label81.Height = 0.25!
            Me.Label81.HyperLink = Nothing
            Me.Label81.Left = 4.9375!
            Me.Label81.Name = "Label81"
            Me.Label81.Style = "text-align: left; font-weight: bold; font-size: 8.25pt"
            Me.Label81.Text = "FIRMA"
            Me.Label81.Top = 7.8125!
            Me.Label81.Width = 1!
            '
            'Label82
            '
            Me.Label82.Height = 0.25!
            Me.Label82.HyperLink = Nothing
            Me.Label82.Left = 5.3125!
            Me.Label82.Name = "Label82"
            Me.Label82.Style = "text-align: left; font-weight: bold; font-size: 8.25pt"
            Me.Label82.Text = "Firma De Cliente"
            Me.Label82.Top = 7.5625!
            Me.Label82.Width = 1!
            '
            'Label83
            '
            Me.Label83.Height = 0.25!
            Me.Label83.HyperLink = Nothing
            Me.Label83.Left = 0.125!
            Me.Label83.Name = "Label83"
            Me.Label83.Style = "font-weight: normal; font-size: 12pt"
            Me.Label83.Text = "Nombre de la persona que recibió la mercancía: "
            Me.Label83.Top = 8.9375!
            Me.Label83.Width = 3.625!
            '
            'Label84
            '
            Me.Label84.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label84.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label84.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label84.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label84.Height = 0.25!
            Me.Label84.HyperLink = Nothing
            Me.Label84.Left = 0.125!
            Me.Label84.Name = "Label84"
            Me.Label84.Style = "color: window; text-align: center; font-weight: bold; background-color: backgroun"& _ 
                "d; font-size: 12pt; vertical-align: middle"
            Me.Label84.Text = "DESCRIPCION DE MERCANCÍA FALTANTE O DAÑADA"
            Me.Label84.Top = 9.25!
            Me.Label84.Width = 7.0625!
            '
            'TextBox19
            '
            Me.TextBox19.Height = 0.25!
            Me.TextBox19.Left = 3.75!
            Me.TextBox19.Name = "TextBox19"
            Me.TextBox19.Style = "text-align: justify; font-weight: bold; font-size: 12pt"
            Me.TextBox19.Text = "Grabiel Quintero"
            Me.TextBox19.Top = 9.0625!
            Me.TextBox19.Width = 3.4375!
            '
            'Label85
            '
            Me.Label85.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label85.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label85.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label85.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label85.Height = 0.1875!
            Me.Label85.HyperLink = Nothing
            Me.Label85.Left = 0.125!
            Me.Label85.Name = "Label85"
            Me.Label85.Style = "color: window; text-align: center; font-weight: bold; background-color: backgroun"& _ 
                "d; font-size: 12pt; vertical-align: middle"
            Me.Label85.Text = "Código"
            Me.Label85.Top = 9.625!
            Me.Label85.Width = 1.25!
            '
            'Label86
            '
            Me.Label86.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label86.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label86.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label86.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label86.Height = 0.1875!
            Me.Label86.HyperLink = Nothing
            Me.Label86.Left = 1.375!
            Me.Label86.Name = "Label86"
            Me.Label86.Style = "color: window; text-align: center; font-weight: bold; background-color: backgroun"& _ 
                "d; font-size: 12pt; vertical-align: middle"
            Me.Label86.Text = "Descripción"
            Me.Label86.Top = 9.625!
            Me.Label86.Width = 3.0625!
            '
            'Label87
            '
            Me.Label87.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label87.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label87.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label87.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label87.Height = 0.1875!
            Me.Label87.HyperLink = Nothing
            Me.Label87.Left = 4.4375!
            Me.Label87.Name = "Label87"
            Me.Label87.Style = "color: window; text-align: center; font-weight: bold; background-color: backgroun"& _ 
                "d; font-size: 12pt; vertical-align: middle"
            Me.Label87.Text = "Talla"
            Me.Label87.Top = 9.625!
            Me.Label87.Width = 0.5!
            '
            'Label88
            '
            Me.Label88.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label88.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label88.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label88.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label88.Height = 0.1875!
            Me.Label88.HyperLink = Nothing
            Me.Label88.Left = 4.9375!
            Me.Label88.Name = "Label88"
            Me.Label88.Style = "color: window; text-align: center; font-weight: bold; background-color: backgroun"& _ 
                "d; font-size: 12pt; vertical-align: middle"
            Me.Label88.Text = "Cant"
            Me.Label88.Top = 9.625!
            Me.Label88.Width = 0.625!
            '
            'Label89
            '
            Me.Label89.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label89.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label89.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label89.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label89.Height = 0.1875!
            Me.Label89.HyperLink = Nothing
            Me.Label89.Left = 5.5625!
            Me.Label89.Name = "Label89"
            Me.Label89.Style = "color: window; text-align: center; font-weight: bold; background-color: backgroun"& _ 
                "d; font-size: 12pt; vertical-align: middle"
            Me.Label89.Text = "Costo U."
            Me.Label89.Top = 9.625!
            Me.Label89.Width = 0.8125!
            '
            'Label90
            '
            Me.Label90.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label90.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label90.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label90.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label90.Height = 0.1875!
            Me.Label90.HyperLink = Nothing
            Me.Label90.Left = 6.375!
            Me.Label90.Name = "Label90"
            Me.Label90.Style = "color: window; text-align: center; font-weight: bold; background-color: backgroun"& _ 
                "d; font-size: 12pt; vertical-align: middle"
            Me.Label90.Text = "Costo T."
            Me.Label90.Top = 9.625!
            Me.Label90.Width = 0.8125!
            '
            'Shape6
            '
            Me.Shape6.BackColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(215,Byte),Integer), CType(CType(0,Byte),Integer))
            Me.Shape6.Height = 1.375!
            Me.Shape6.Left = 0.125!
            Me.Shape6.Name = "Shape6"
            Me.Shape6.RoundingRadius = 9.999999!
            Me.Shape6.Top = 8.9375!
            Me.Shape6.Width = 7.0625!
            '
            'Label91
            '
            Me.Label91.Height = 0.25!
            Me.Label91.HyperLink = Nothing
            Me.Label91.Left = 0.3125!
            Me.Label91.Name = "Label91"
            Me.Label91.Style = "font-weight: bold; font-size: 9.75pt"
            Me.Label91.Text = "OBSERVACIONES"
            Me.Label91.Top = 9!
            Me.Label91.Width = 3.25!
            '
            'Picture4
            '
            Me.Picture4.Height = 0.25!
            Me.Picture4.ImageData = CType(resources.GetObject("Picture4.ImageData"),System.IO.Stream)
            Me.Picture4.Left = 6!
            Me.Picture4.LineColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(255,Byte),Integer), CType(CType(255,Byte),Integer))
            Me.Picture4.LineWeight = 0!
            Me.Picture4.Name = "Picture4"
            Me.Picture4.SizeMode = DataDynamics.ActiveReports.SizeModes.Stretch
            Me.Picture4.Top = 9!
            Me.Picture4.Width = 1.0625!
            '
            'txtObservaciones
            '
            Me.txtObservaciones.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtObservaciones.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtObservaciones.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtObservaciones.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtObservaciones.Height = 0.1875!
            Me.txtObservaciones.Left = 0.3125!
            Me.txtObservaciones.Name = "txtObservaciones"
            Me.txtObservaciones.Style = "text-align: left; font-weight: normal; background-color: window; font-size: 9pt"
            Me.txtObservaciones.Top = 9.3125!
            Me.txtObservaciones.Width = 6.75!
            '
            'txtFirmaSolicitante
            '
            Me.txtFirmaSolicitante.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtFirmaSolicitante.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtFirmaSolicitante.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtFirmaSolicitante.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtFirmaSolicitante.Height = 0.1875!
            Me.txtFirmaSolicitante.Left = 5.5!
            Me.txtFirmaSolicitante.Name = "txtFirmaSolicitante"
            Me.txtFirmaSolicitante.Style = "text-align: center; font-weight: normal; background-color: window; font-size: 9pt"& _ 
                ""
            Me.txtFirmaSolicitante.Top = 7.8125!
            Me.txtFirmaSolicitante.Width = 1.5!
            '
            'Label92
            '
            Me.Label92.Height = 0.25!
            Me.Label92.HyperLink = Nothing
            Me.Label92.Left = 0.3125!
            Me.Label92.Name = "Label92"
            Me.Label92.Style = "text-align: right; font-weight: bold; font-size: 8.25pt"
            Me.Label92.Text = "DAÑOS:"
            Me.Label92.Top = 3.6875!
            Me.Label92.Width = 1.375!
            '
            'txtPerdidaDaños
            '
            Me.txtPerdidaDaños.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtPerdidaDaños.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtPerdidaDaños.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtPerdidaDaños.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtPerdidaDaños.Height = 0.1875!
            Me.txtPerdidaDaños.Left = 1.75!
            Me.txtPerdidaDaños.Name = "txtPerdidaDaños"
            Me.txtPerdidaDaños.Style = "text-align: center; font-weight: normal; background-color: window; font-size: 9pt"& _ 
                ""
            Me.txtPerdidaDaños.Top = 3.6875!
            Me.txtPerdidaDaños.Width = 0.9375!
            '
            'txtContenidoDeclarado
            '
            Me.txtContenidoDeclarado.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtContenidoDeclarado.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtContenidoDeclarado.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtContenidoDeclarado.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtContenidoDeclarado.Height = 0.1875!
            Me.txtContenidoDeclarado.Left = 1.75!
            Me.txtContenidoDeclarado.Name = "txtContenidoDeclarado"
            Me.txtContenidoDeclarado.Style = "text-align: left; font-weight: normal; background-color: window; font-size: 9pt"
            Me.txtContenidoDeclarado.Top = 1.875!
            Me.txtContenidoDeclarado.Width = 5.3125!
            '
            'TextBox20
            '
            Me.TextBox20.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.TextBox20.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.TextBox20.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.TextBox20.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.TextBox20.Height = 0.1875!
            Me.TextBox20.Left = 1.75!
            Me.TextBox20.Name = "TextBox20"
            Me.TextBox20.Style = "text-align: left; font-weight: normal; background-color: window; font-size: 9pt"
            Me.TextBox20.Top = 2.125!
            Me.TextBox20.Width = 5.3125!
            '
            'TextBox21
            '
            Me.TextBox21.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.TextBox21.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.TextBox21.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.TextBox21.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.TextBox21.Height = 0.1875!
            Me.TextBox21.Left = 2.25!
            Me.TextBox21.Name = "TextBox21"
            Me.TextBox21.Style = "text-align: left; font-weight: normal; background-color: window; font-size: 9pt"
            Me.TextBox21.Text = " "
            Me.TextBox21.Top = 4.1875!
            Me.TextBox21.Width = 4.8125!
            '
            'txtObservaciones2
            '
            Me.txtObservaciones2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtObservaciones2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtObservaciones2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtObservaciones2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtObservaciones2.Height = 0.1875!
            Me.txtObservaciones2.Left = 0.3125!
            Me.txtObservaciones2.Name = "txtObservaciones2"
            Me.txtObservaciones2.Style = "text-align: left; font-weight: normal; background-color: window; font-size: 9pt"
            Me.txtObservaciones2.Top = 9.5625!
            Me.txtObservaciones2.Width = 6.75!
            '
            'txtObservaciones3
            '
            Me.txtObservaciones3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtObservaciones3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtObservaciones3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtObservaciones3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtObservaciones3.Height = 0.1875!
            Me.txtObservaciones3.Left = 0.3125!
            Me.txtObservaciones3.Name = "txtObservaciones3"
            Me.txtObservaciones3.Style = "text-align: left; font-weight: normal; background-color: window; font-size: 9pt"
            Me.txtObservaciones3.Top = 9.8125!
            Me.txtObservaciones3.Width = 6.75!
            '
            'TextBox24
            '
            Me.TextBox24.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.TextBox24.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.TextBox24.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.TextBox24.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.TextBox24.Height = 0.1875!
            Me.TextBox24.Left = 0.3125!
            Me.TextBox24.Name = "TextBox24"
            Me.TextBox24.Style = "text-align: left; font-weight: normal; background-color: window; font-size: 9pt"
            Me.TextBox24.Top = 10.0625!
            Me.TextBox24.Width = 6.75!
            '
            'txtCLABE0
            '
            Me.txtCLABE0.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtCLABE0.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtCLABE0.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtCLABE0.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtCLABE0.Height = 0.1875!
            Me.txtCLABE0.Left = 2.0625!
            Me.txtCLABE0.Name = "txtCLABE0"
            Me.txtCLABE0.Style = "text-align: center; font-weight: normal; background-color: window; font-size: 9pt"& _ 
                ""
            Me.txtCLABE0.Text = "1"
            Me.txtCLABE0.Top = 7.5!
            Me.txtCLABE0.Width = 0.125!
            '
            'txtCLABE1
            '
            Me.txtCLABE1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtCLABE1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtCLABE1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtCLABE1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtCLABE1.Height = 0.1875!
            Me.txtCLABE1.Left = 2.1875!
            Me.txtCLABE1.Name = "txtCLABE1"
            Me.txtCLABE1.Style = "text-align: center; font-weight: normal; background-color: window; font-size: 9pt"& _ 
                "; vertical-align: top"
            Me.txtCLABE1.Text = "0"
            Me.txtCLABE1.Top = 7.5!
            Me.txtCLABE1.Width = 0.125!
            '
            'txtCLABE2
            '
            Me.txtCLABE2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtCLABE2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtCLABE2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtCLABE2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtCLABE2.Height = 0.1875!
            Me.txtCLABE2.Left = 2.3125!
            Me.txtCLABE2.Name = "txtCLABE2"
            Me.txtCLABE2.Style = "text-align: center; font-weight: normal; background-color: window; font-size: 9pt"& _ 
                ""
            Me.txtCLABE2.Text = "4"
            Me.txtCLABE2.Top = 7.5!
            Me.txtCLABE2.Width = 0.125!
            '
            'txtCLABE3
            '
            Me.txtCLABE3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtCLABE3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtCLABE3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtCLABE3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtCLABE3.Height = 0.1875!
            Me.txtCLABE3.Left = 2.4375!
            Me.txtCLABE3.Name = "txtCLABE3"
            Me.txtCLABE3.Style = "text-align: center; font-weight: normal; background-color: window; font-size: 9pt"& _ 
                ""
            Me.txtCLABE3.Text = "2"
            Me.txtCLABE3.Top = 7.5!
            Me.txtCLABE3.Width = 0.125!
            '
            'txtCLABE4
            '
            Me.txtCLABE4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtCLABE4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtCLABE4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtCLABE4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtCLABE4.Height = 0.1875!
            Me.txtCLABE4.Left = 2.5625!
            Me.txtCLABE4.Name = "txtCLABE4"
            Me.txtCLABE4.Style = "text-align: center; font-weight: normal; background-color: window; font-size: 9pt"& _ 
                ""
            Me.txtCLABE4.Text = "5"
            Me.txtCLABE4.Top = 7.5!
            Me.txtCLABE4.Width = 0.125!
            '
            'txtCLABE5
            '
            Me.txtCLABE5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtCLABE5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtCLABE5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtCLABE5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtCLABE5.Height = 0.1875!
            Me.txtCLABE5.Left = 2.6875!
            Me.txtCLABE5.Name = "txtCLABE5"
            Me.txtCLABE5.Style = "text-align: center; font-weight: normal; background-color: window; font-size: 9pt"& _ 
                ""
            Me.txtCLABE5.Text = "7"
            Me.txtCLABE5.Top = 7.5!
            Me.txtCLABE5.Width = 0.125!
            '
            'txtCLABE6
            '
            Me.txtCLABE6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtCLABE6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtCLABE6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtCLABE6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtCLABE6.Height = 0.1875!
            Me.txtCLABE6.Left = 2.8125!
            Me.txtCLABE6.Name = "txtCLABE6"
            Me.txtCLABE6.Style = "text-align: center; font-weight: normal; background-color: window; font-size: 9pt"& _ 
                ""
            Me.txtCLABE6.Text = "3"
            Me.txtCLABE6.Top = 7.5!
            Me.txtCLABE6.Width = 0.125!
            '
            'txtCLABE7
            '
            Me.txtCLABE7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtCLABE7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtCLABE7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtCLABE7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtCLABE7.Height = 0.1875!
            Me.txtCLABE7.Left = 2.9375!
            Me.txtCLABE7.Name = "txtCLABE7"
            Me.txtCLABE7.Style = "text-align: center; font-weight: normal; background-color: window; font-size: 9pt"& _ 
                ""
            Me.txtCLABE7.Text = "8"
            Me.txtCLABE7.Top = 7.5!
            Me.txtCLABE7.Width = 0.125!
            '
            'txtCLABE8
            '
            Me.txtCLABE8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtCLABE8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtCLABE8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtCLABE8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtCLABE8.Height = 0.1875!
            Me.txtCLABE8.Left = 3.0625!
            Me.txtCLABE8.Name = "txtCLABE8"
            Me.txtCLABE8.Style = "text-align: center; font-weight: normal; background-color: window; font-size: 9pt"& _ 
                ""
            Me.txtCLABE8.Text = "9"
            Me.txtCLABE8.Top = 7.5!
            Me.txtCLABE8.Width = 0.125!
            '
            'txtCLABE9
            '
            Me.txtCLABE9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtCLABE9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtCLABE9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtCLABE9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtCLABE9.Height = 0.1875!
            Me.txtCLABE9.Left = 3.1875!
            Me.txtCLABE9.Name = "txtCLABE9"
            Me.txtCLABE9.Style = "text-align: center; font-weight: normal; background-color: window; font-size: 9pt"& _ 
                ""
            Me.txtCLABE9.Text = "2"
            Me.txtCLABE9.Top = 7.5!
            Me.txtCLABE9.Width = 0.125!
            '
            'txtCLABE10
            '
            Me.txtCLABE10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtCLABE10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtCLABE10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtCLABE10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtCLABE10.Height = 0.1875!
            Me.txtCLABE10.Left = 3.3125!
            Me.txtCLABE10.Name = "txtCLABE10"
            Me.txtCLABE10.Style = "text-align: center; font-weight: normal; background-color: window; font-size: 9pt"& _ 
                ""
            Me.txtCLABE10.Text = "5"
            Me.txtCLABE10.Top = 7.5!
            Me.txtCLABE10.Width = 0.125!
            '
            'txtCLABE11
            '
            Me.txtCLABE11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtCLABE11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtCLABE11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtCLABE11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtCLABE11.Height = 0.1875!
            Me.txtCLABE11.Left = 3.4375!
            Me.txtCLABE11.Name = "txtCLABE11"
            Me.txtCLABE11.Style = "text-align: center; font-weight: normal; background-color: window; font-size: 9pt"& _ 
                ""
            Me.txtCLABE11.Text = "0"
            Me.txtCLABE11.Top = 7.5!
            Me.txtCLABE11.Width = 0.125!
            '
            'txtCLABE12
            '
            Me.txtCLABE12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtCLABE12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtCLABE12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtCLABE12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtCLABE12.Height = 0.1875!
            Me.txtCLABE12.Left = 3.5625!
            Me.txtCLABE12.Name = "txtCLABE12"
            Me.txtCLABE12.Style = "text-align: center; font-weight: normal; background-color: window; font-size: 9pt"& _ 
                ""
            Me.txtCLABE12.Text = "1"
            Me.txtCLABE12.Top = 7.5!
            Me.txtCLABE12.Width = 0.125!
            '
            'txtCLABE13
            '
            Me.txtCLABE13.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtCLABE13.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtCLABE13.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtCLABE13.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtCLABE13.Height = 0.1875!
            Me.txtCLABE13.Left = 3.6875!
            Me.txtCLABE13.Name = "txtCLABE13"
            Me.txtCLABE13.Style = "text-align: center; font-weight: normal; background-color: window; font-size: 9pt"& _ 
                ""
            Me.txtCLABE13.Text = "6"
            Me.txtCLABE13.Top = 7.5!
            Me.txtCLABE13.Width = 0.125!
            '
            'txtCLABE14
            '
            Me.txtCLABE14.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtCLABE14.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtCLABE14.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtCLABE14.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtCLABE14.Height = 0.1875!
            Me.txtCLABE14.Left = 3.8125!
            Me.txtCLABE14.Name = "txtCLABE14"
            Me.txtCLABE14.Style = "text-align: center; font-weight: normal; background-color: window; font-size: 9pt"& _ 
                ""
            Me.txtCLABE14.Text = "2"
            Me.txtCLABE14.Top = 7.5!
            Me.txtCLABE14.Width = 0.125!
            '
            'txtCLABE15
            '
            Me.txtCLABE15.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtCLABE15.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtCLABE15.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtCLABE15.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtCLABE15.Height = 0.1875!
            Me.txtCLABE15.Left = 3.9375!
            Me.txtCLABE15.Name = "txtCLABE15"
            Me.txtCLABE15.Style = "text-align: center; font-weight: normal; background-color: window; font-size: 9pt"& _ 
                ""
            Me.txtCLABE15.Text = "2"
            Me.txtCLABE15.Top = 7.5!
            Me.txtCLABE15.Width = 0.125!
            '
            'txtCLABE16
            '
            Me.txtCLABE16.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtCLABE16.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtCLABE16.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtCLABE16.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtCLABE16.Height = 0.1875!
            Me.txtCLABE16.Left = 4.0625!
            Me.txtCLABE16.Name = "txtCLABE16"
            Me.txtCLABE16.Style = "text-align: center; font-weight: normal; background-color: window; font-size: 9pt"& _ 
                ""
            Me.txtCLABE16.Text = "1"
            Me.txtCLABE16.Top = 7.5!
            Me.txtCLABE16.Width = 0.125!
            '
            'txtCLABE17
            '
            Me.txtCLABE17.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtCLABE17.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtCLABE17.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtCLABE17.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtCLABE17.Height = 0.1875!
            Me.txtCLABE17.Left = 4.1875!
            Me.txtCLABE17.Name = "txtCLABE17"
            Me.txtCLABE17.Style = "text-align: center; font-weight: normal; background-color: window; font-size: 9pt"& _ 
                ""
            Me.txtCLABE17.Text = "6"
            Me.txtCLABE17.Top = 7.5!
            Me.txtCLABE17.Width = 0.125!
            '
            'ActiveReport1
            '
            Me.MasterReport = false
            Me.PageSettings.DefaultPaperSize = false
            Me.PageSettings.Margins.Bottom = 0.2!
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
            CType(Me.lblTitulo,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblNombrePaqueteria,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label7,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label8,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtCiudadyFecha,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtNombrePersonaRecibe,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label37,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label38,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label39,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label40,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label41,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label42,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFecha,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label43,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Picture1,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label44,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtNoGuia,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label45,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtOrigen,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label46,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label47,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFechaEnvio,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label48,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtDestino,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label49,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtMontoReclamado,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label50,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Picture2,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label51,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtPerdidaParcial,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label52,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtPerdidaTotal,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label53,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtEspecificaDaños,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label56,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtValorMcia,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label57,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label58,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label59,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label60,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label69,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Picture3,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label70,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtRazonSocialRemitente,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label71,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtDireccionRemitente,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label72,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtNoCuentaRemitente,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label73,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label75,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label77,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label78,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtTelefonoRemitente,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label79,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label80,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtNombreSolicitante,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label81,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label82,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label83,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label84,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox19,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label85,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label86,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label87,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label88,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label89,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label90,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label91,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Picture4,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtObservaciones,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFirmaSolicitante,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label92,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtPerdidaDaños,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtContenidoDeclarado,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox20,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox21,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtObservaciones2,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtObservaciones3,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox24,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtCLABE0,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtCLABE1,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtCLABE2,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtCLABE3,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtCLABE4,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtCLABE5,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtCLABE6,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtCLABE7,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtCLABE8,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtCLABE9,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtCLABE10,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtCLABE11,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtCLABE12,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtCLABE13,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtCLABE14,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtCLABE15,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtCLABE16,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtCLABE17,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        End Sub

#End Region

    Private Function CostoTotalTraslado(ByVal dtTemp As DataTable) As Decimal

        Dim CostoTotal As Decimal = 0

        Try
            Dim oArticulo As Articulo
            Dim oRow As DataRow
1:          Dim oArticuloMgr As New CatalogoArticuloManager(oAppContext)

2:          For Each oRow In dtTemp.Rows
3:              oArticulo = Nothing
4:              oArticulo = oArticuloMgr.Load(CStr(oRow!Codigo).Trim)
5:              If Not oArticulo Is Nothing Then
6:                  CostoTotal += CInt(oRow!Cantidad) * oArticulo.CostoProm
                End If
            Next

        Catch ex As Exception
            EscribeLog(ex.ToString, "Error al calcular el costo total del traspaso. Linea: " & Err.Erl)
        End Try

        Return CostoTotal

    End Function

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

8:          For Each oRow In dtTemp.Rows
9:              oArticulo = Nothing
10:             oArticulo = oArticuloMgr.Load(CStr(oRow!Codigo).Trim)
                If Not oArticulo Is Nothing Then
11:                 oRow!CostoUnit = oArticulo.CostoProm
12:                 oRow!Cantidad = CInt(oRow!Cantidad - oRow!Lecturado)
13:                 oRow!CostoTotal = oRow!CostoUnit * oRow!Cantidad
14:                 Costo += oRow!CostoTotal
                End If
            Next
15:         dtTemp.AcceptChanges()
        Catch ex As Exception
            EscribeLog(ex.ToString, "Error al complementar el detalle en la impresion de los faltantes. Linea: " & Err.Erl)
        End Try

        Return dtTemp

    End Function

End Class
