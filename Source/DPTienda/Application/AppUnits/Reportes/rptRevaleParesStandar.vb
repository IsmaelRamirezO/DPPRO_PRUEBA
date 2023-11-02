Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Imports DportenisPro.DPTienda.ApplicationUnits.FacturasFormaPago
Imports DportenisPro.DPTienda.ApplicationUnits.Clientes
Imports DportenisPro.DPTienda.ApplicationUnits.NumeroaLetras
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesosAU
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU
Imports System.IO
Imports MontarUnidadRed
Imports DportenisPro.DPTienda.ApplicationUnits.Facturas

Public Class rptRevaleParesStandar
    Inherits DataDynamics.ActiveReports.ActiveReport

    Dim oFirmaMgr As FirmaManager
    Dim byteFirma As Byte()
    Public Sub New(ByVal DPValeInfo As ControlDPValesWS.DPValeInfo, ByVal Diferencia As Integer, ByVal oLogo As Bitmap)
        MyBase.New()
        InitializeComponent()


        If oAppSAPConfig.DPValeSAP Then

            LoadInfoSAP(DPValeInfo, Diferencia)

        Else

            LoadInfo(DPValeInfo, Diferencia)

        End If

      
    End Sub

    Private Sub btnWatermark(ByVal oImagen As Image)

        Dim watermark_bm As New Bitmap(oImagen)

        DrawWatermark(watermark_bm)

        Me.pbMarca.Image = watermark_bm

        If (watermark_bm.Height > Me.pbMarca.Height) Or (watermark_bm.Width > Me.pbMarca.Width) Then
            Me.pbMarca.SizeMode = SizeModes.Zoom
        Else
            Me.pbMarca.SizeMode = SizeModes.Clip
        End If

    End Sub

    Private Sub DrawWatermark(ByRef watermark_bm As Bitmap)

        Const ALPHA As Byte = 60
        ' Set the watermark's pixels' Alpha components.

        Dim clr As Color

        For py As Integer = 0 To watermark_bm.Height - 1

            For px As Integer = 0 To watermark_bm.Width - 1

                clr = watermark_bm.GetPixel(px, py)

                watermark_bm.SetPixel(px, py, Color.FromArgb(ALPHA, clr.R, clr.G, clr.B))

            Next px

        Next py

        ' Set the watermark's transparent color.

        watermark_bm.MakeTransparent(watermark_bm.GetPixel(0, 0))



    End Sub

    Private Sub LoadInfo(ByVal DPValeInfo As ControlDPValesWS.DPValeInfo, ByVal Diferencia As Integer)
        Try

            Me.txtFolio.Text = DPValeInfo.DPValeID
            Me.barCode.Text = DPValeInfo.DPValeID
            Me.txtFecha.Text = Now.Date.ToShortDateString & " " & Format(Now, "HH:mm:ss")
            Me.txtOrigen.Text = DPValeInfo.DPValeOrigen
            Me.txtFechaExp.Text = DPValeInfo.FechaEntregado
            Me.txtFechaVigencia.Text = DateAdd(DateInterval.Day, oAppContext.ApplicationConfiguration.DiasVigenciaDPVale, DPValeInfo.FechaEntregado)

            Dim oClienteMgr As New ClientesManager(oAppContext)
            Dim oCliente As Clientes
            oCliente = oClienteMgr.Create
            oClienteMgr.LoadInto(DPValeInfo.ClienteAsociadoID, oCliente)

            If oCliente.ClienteID = 0 Then

                Me.txtClienteAsociado.Text = DPValeInfo.ClienteAsociadoID & " " & DPValeInfo.ClienteAsociado

            Else

                Me.txtClienteAsociado.Text = oCliente.ClienteID & " " & oCliente.Nombre & " " & oCliente.ApellidoPaterno & " " & oCliente.ApellidoMaterno
                Me.txtDomicilio.Text = oCliente.Domicilio
                Me.txtTelefono.Text = oCliente.Telefono

            End If

            Me.txtCantidad.Text = Diferencia

            Dim Ob As New DportenisPro.DPTienda.ApplicationUnits.NumeroaLetras.Letras

            Dim parametros() As String = CStr(Diferencia).Split(".")
            parametros(0) = parametros(0).Replace("$", "")

            Me.txtImporteLetra.Text = Ob.Letras(parametros(0)) & " Pares/Pzas."


            'Dim owsCReditoDPVale As wsCreditoDPVale.CreditoCreditosDPVale = New wsCreditoDPVale.CreditoCreditosDPVale

            If Not oAppContext.ApplicationConfiguration.WSUrl = String.Empty Then
                'owsCReditoDPVale.Url = oAppContext.ApplicationConfiguration.WSUrl.TrimEnd("/") & "/" & _
                '                      owsCReditoDPVale.strURL.TrimEnd("/")

            End If

            'Dim oCreditoDPValeInfo As wsCreditoDPVale.CreditoDPValeInfo = New wsCreditoDPVale.CreditoDPValeInfo

            'oCreditoDPValeInfo = owsCReditoDPVale.GetCreditoDPVale(DPValeInfo.CreditoDPValeID)

            'If Not oCreditoDPValeInfo.CreditoDPValeID = 0 Then

            '    Me.txtAsociado.Text = oCreditoDPValeInfo.AsociadoID

            '    If Not oCreditoDPValeInfo.FirmaDigital Is Nothing Then

            '        Dim oFirmaCredito() As Byte = CType(oCreditoDPValeInfo.FirmaDigital, Byte())
            '        Dim msFirma As New MemoryStream(oFirmaCredito)
            '        Me.pFirma.Image = Image.FromStream(msFirma)

            '    Else
            Me.pFirma.Image = Nothing
            '    End If


            'End If

            oCliente.Clear()
            oClienteMgr.LoadInto(DPValeInfo.ClienteID, oCliente)

            If oCliente.ClienteID = 0 Then

                Me.txtAsociado.Text = DPValeInfo.AsociadoID

            Else

                Me.txtAsociado.Text = DPValeInfo.AsociadoID & " " & oCliente.Nombre & " " & oCliente.ApellidoPaterno & " " & oCliente.ApellidoMaterno


            End If

            'If Not oLogo Is Nothing Then
            '    btnWatermark(oLogo)
            'End If

        Catch ex As Exception

            Throw ex

        End Try
    End Sub

    Private Sub LoadInfoSAP(ByVal DPValeInfo As ControlDPValesWS.DPValeInfo, ByVal Diferencia As Integer)
        Try

            Me.txtFolio.Text = DPValeInfo.DPValeID
            Me.barCode.Text = DPValeInfo.DPValeID
            Me.txtFecha.Text = Now.Date.ToShortDateString & " " & Format(Now, "HH:mm:ss")
            Me.txtOrigen.Text = DPValeInfo.DPValeOrigen
            Me.txtFechaExp.Text = DPValeInfo.FechaEntregado
            Me.txtFechaVigencia.Text = DateAdd(DateInterval.Day, oAppContext.ApplicationConfiguration.DiasVigenciaDPVale, DPValeInfo.FechaEntregado)


            Dim oSAPMgr As ProcesoSAPManager
            oSAPMgr = New ProcesoSAPManager(oAppContext, oAppSAPConfig)

            Dim info() As String

            info = oSAPMgr.ZBAPI_DATOS_CLIENTE(Convert.ToString(DPValeInfo.ClienteAsociadoID).PadLeft(10, "0"), 2)

            Me.txtClienteAsociado.Text = Convert.ToString(DPValeInfo.ClienteAsociadoID).PadLeft(10, "0") & " " & info(1)
            Me.txtDomicilio.Text = info(2)
            Me.txtTelefono.Text = info(3)

            Me.txtCantidad.Text = Diferencia

            Dim Ob As New DportenisPro.DPTienda.ApplicationUnits.NumeroaLetras.Letras

            Dim parametros() As String = CStr(Diferencia).Split(".")
            parametros(0) = parametros(0).Replace("$", "")

            Me.txtImporteLetra.Text = Ob.Letras(parametros(0)) & " Pares/Pzas."


            Me.txtAsociado.Text = CStr(DPValeInfo.AsociadoID).PadLeft(10, "0") & " " & oSAPMgr.ZBAPI_NOMBRE_CLIENTE(CStr(DPValeInfo.AsociadoID).PadLeft(10, "0"))

            ''Cargar Imagen del Servidor
            oFirmaMgr = New FirmaManager(oAppContext, oConfigCierreFI)

            byteFirma = Me.oFirmaMgr.GetImagenFirmaAsociado(CStr(DPValeInfo.AsociadoID).PadLeft(10, "0"))

            Dim oFirmaAsociado() As Byte = CType(byteFirma, Byte())
            Dim msFotoAsociado As New MemoryStream(oFirmaAsociado)
            If Not pFirma.Image Is Nothing Then
                pFirma.Image.Dispose()
            End If

            Me.pFirma.Image = Image.FromStream(msFotoAsociado)

            'Dim oConURed As New MontarUnidadRed.cMontaUnidadRed(oConfigCierreFI.Password, oConfigCierreFI.Usuario, oConfigCierreFI.Unidad, oConfigCierreFI.Ruta)
            'oConURed.Conecta()

            'If File.Exists(oConfigCierreFI.Ruta & "\Firmas\" & CStr(DPValeInfo.DPValeID).PadLeft(10, "0") & ".bmp") Then
            'Me.pFirma.Image = Image.FromFile(oConfigCierreFI.Ruta & "\Firmas\" & CStr(DPValeInfo.DPValeID).PadLeft(10, "0") & ".bmp")
            'End If

            'oConURed.Desconecta()
            'oConURed.Desconecta()

        Catch ex As Exception

            Throw ex

        End Try
    End Sub

#Region "ActiveReports Designer generated code"
    Private WithEvents PageHeader As PageHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents PageFooter As PageFooter = Nothing
	Private Label1 As Label = Nothing
	Private Label2 As Label = Nothing
	Private Label3 As Label = Nothing
	Private barCode As Barcode = Nothing
	Private pFirma As Picture = Nothing
	Private Label4 As Label = Nothing
	Private Label5 As Label = Nothing
	Private Label6 As Label = Nothing
	Private Label7 As Label = Nothing
	Private Label8 As Label = Nothing
	Private Label9 As Label = Nothing
	Private Label10 As Label = Nothing
	Private Label11 As Label = Nothing
	Private Label12 As Label = Nothing
	Private txtFolio As TextBox = Nothing
	Private txtOrigen As TextBox = Nothing
	Private txtFechaExp As TextBox = Nothing
	Private txtFechaVigencia As TextBox = Nothing
	Private txtClienteAsociado As TextBox = Nothing
	Private txtDomicilio As TextBox = Nothing
	Private txtTelefono As TextBox = Nothing
	Private txtCantidad As TextBox = Nothing
	Private txtImporteLetra As TextBox = Nothing
	Private txtAsociado As TextBox = Nothing
	Private txtFecha As TextBox = Nothing
	Private Line1 As Line = Nothing
	Private pbMarca As Picture = Nothing
	Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptRevaleParesStandar))
            Me.Detail = New DataDynamics.ActiveReports.Detail()
            Me.PageHeader = New DataDynamics.ActiveReports.PageHeader()
            Me.PageFooter = New DataDynamics.ActiveReports.PageFooter()
            Me.Label1 = New DataDynamics.ActiveReports.Label()
            Me.Label2 = New DataDynamics.ActiveReports.Label()
            Me.Label3 = New DataDynamics.ActiveReports.Label()
            Me.barCode = New DataDynamics.ActiveReports.Barcode()
            Me.pFirma = New DataDynamics.ActiveReports.Picture()
            Me.Label4 = New DataDynamics.ActiveReports.Label()
            Me.Label5 = New DataDynamics.ActiveReports.Label()
            Me.Label6 = New DataDynamics.ActiveReports.Label()
            Me.Label7 = New DataDynamics.ActiveReports.Label()
            Me.Label8 = New DataDynamics.ActiveReports.Label()
            Me.Label9 = New DataDynamics.ActiveReports.Label()
            Me.Label10 = New DataDynamics.ActiveReports.Label()
            Me.Label11 = New DataDynamics.ActiveReports.Label()
            Me.Label12 = New DataDynamics.ActiveReports.Label()
            Me.txtFolio = New DataDynamics.ActiveReports.TextBox()
            Me.txtOrigen = New DataDynamics.ActiveReports.TextBox()
            Me.txtFechaExp = New DataDynamics.ActiveReports.TextBox()
            Me.txtFechaVigencia = New DataDynamics.ActiveReports.TextBox()
            Me.txtClienteAsociado = New DataDynamics.ActiveReports.TextBox()
            Me.txtDomicilio = New DataDynamics.ActiveReports.TextBox()
            Me.txtTelefono = New DataDynamics.ActiveReports.TextBox()
            Me.txtCantidad = New DataDynamics.ActiveReports.TextBox()
            Me.txtImporteLetra = New DataDynamics.ActiveReports.TextBox()
            Me.txtAsociado = New DataDynamics.ActiveReports.TextBox()
            Me.txtFecha = New DataDynamics.ActiveReports.TextBox()
            Me.Line1 = New DataDynamics.ActiveReports.Line()
            Me.pbMarca = New DataDynamics.ActiveReports.Picture()
            CType(Me.Label1,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label3,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.pFirma,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label5,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label6,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label7,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label8,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label9,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label10,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label11,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label12,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFolio,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtOrigen,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFechaExp,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFechaVigencia,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtClienteAsociado,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtDomicilio,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtTelefono,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtCantidad,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtImporteLetra,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtAsociado,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFecha,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.pbMarca,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
            '
            'Detail
            '
            Me.Detail.ColumnSpacing = 0!
            Me.Detail.Height = 0.02083333!
            Me.Detail.Name = "Detail"
            '
            'PageHeader
            '
            Me.PageHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label1, Me.Label2, Me.Label3, Me.barCode, Me.pFirma, Me.Label4, Me.Label5, Me.Label6, Me.Label7, Me.Label8, Me.Label9, Me.Label10, Me.Label11, Me.Label12, Me.txtFolio, Me.txtOrigen, Me.txtFechaExp, Me.txtFechaVigencia, Me.txtClienteAsociado, Me.txtDomicilio, Me.txtTelefono, Me.txtCantidad, Me.txtImporteLetra, Me.txtAsociado, Me.txtFecha, Me.Line1, Me.pbMarca})
            Me.PageHeader.Height = 4.634722!
            Me.PageHeader.Name = "PageHeader"
            '
            'PageFooter
            '
            Me.PageFooter.Height = 0!
            Me.PageFooter.Name = "PageFooter"
            '
            'Label1
            '
            Me.Label1.Height = 0.2!
            Me.Label1.HyperLink = Nothing
            Me.Label1.Left = 0.6692917!
            Me.Label1.Name = "Label1"
            Me.Label1.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
            Me.Label1.Text = "DPortenis Vale (Re-Vale)"
            Me.Label1.Top = 0!
            Me.Label1.Width = 1.535433!
            '
            'Label2
            '
            Me.Label2.Height = 0.2!
            Me.Label2.HyperLink = Nothing
            Me.Label2.Left = 0.9414368!
            Me.Label2.Name = "Label2"
            Me.Label2.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
            Me.Label2.Text = "Fecha/Hora Impresión"
            Me.Label2.Top = 0.472441!
            Me.Label2.Width = 1.75!
            '
            'Label3
            '
            Me.Label3.Height = 0.2!
            Me.Label3.HyperLink = Nothing
            Me.Label3.Left = 0.9414368!
            Me.Label3.Name = "Label3"
            Me.Label3.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
            Me.Label3.Text = "Folio"
            Me.Label3.Top = 0.2755906!
            Me.Label3.Width = 1!
            '
            'barCode
            '
            Me.barCode.CheckSumEnabled = false
            Me.barCode.Font = New System.Drawing.Font("Courier New", 8!)
            Me.barCode.Height = 0.3149606!
            Me.barCode.Left = 0.03937012!
            Me.barCode.Name = "barCode"
            Me.barCode.Text = "0"
            Me.barCode.Top = 0.2755906!
            Me.barCode.Width = 0.8661417!
            '
            'pFirma
            '
            Me.pFirma.BackColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(255,Byte),Integer), CType(CType(255,Byte),Integer))
            Me.pFirma.Height = 0.8661417!
            Me.pFirma.ImageData = Nothing
            Me.pFirma.Left = 0.4542326!
            Me.pFirma.LineColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(255,Byte),Integer), CType(CType(255,Byte),Integer))
            Me.pFirma.LineWeight = 0!
            Me.pFirma.Name = "pFirma"
            Me.pFirma.SizeMode = DataDynamics.ActiveReports.SizeModes.Stretch
            Me.pFirma.Top = 3.383366!
            Me.pFirma.Width = 1.535433!
            '
            'Label4
            '
            Me.Label4.Height = 0.2!
            Me.Label4.HyperLink = Nothing
            Me.Label4.Left = 0.07874021!
            Me.Label4.Name = "Label4"
            Me.Label4.Style = "text-align: left; font-weight: bold; font-size: 8.25pt"
            Me.Label4.Text = "Domicilio"
            Me.Label4.Top = 2.021653!
            Me.Label4.Width = 1.220472!
            '
            'Label5
            '
            Me.Label5.Height = 0.2!
            Me.Label5.HyperLink = Nothing
            Me.Label5.Left = 0.07874021!
            Me.Label5.Name = "Label5"
            Me.Label5.Style = "text-align: left; font-weight: bold; font-size: 8.25pt"
            Me.Label5.Text = "Teléfono"
            Me.Label5.Top = 2.468504!
            Me.Label5.Width = 1.220472!
            '
            'Label6
            '
            Me.Label6.Height = 0.2!
            Me.Label6.HyperLink = Nothing
            Me.Label6.Left = 0.07874021!
            Me.Label6.Name = "Label6"
            Me.Label6.Style = "text-align: left; font-weight: bold; font-size: 8.25pt"
            Me.Label6.Text = "Valido Hasta:"
            Me.Label6.Top = 1.382381!
            Me.Label6.Width = 1.220472!
            '
            'Label7
            '
            Me.Label7.Height = 0.2!
            Me.Label7.HyperLink = Nothing
            Me.Label7.Left = 0.07874021!
            Me.Label7.Name = "Label7"
            Me.Label7.Style = "text-align: left; font-weight: bold; font-size: 8.25pt"
            Me.Label7.Text = "Súrtase por este Vale a:"
            Me.Label7.Top = 1.579232!
            Me.Label7.Width = 1.338583!
            '
            'Label8
            '
            Me.Label8.Height = 0.2!
            Me.Label8.HyperLink = Nothing
            Me.Label8.Left = 0.07874021!
            Me.Label8.Name = "Label8"
            Me.Label8.Style = "text-align: left; font-weight: bold; font-size: 8.25pt"
            Me.Label8.Text = "Fecha exp."
            Me.Label8.Top = 1.141733!
            Me.Label8.Width = 1.220472!
            '
            'Label9
            '
            Me.Label9.Height = 0.2!
            Me.Label9.HyperLink = Nothing
            Me.Label9.Left = 0.07874021!
            Me.Label9.Name = "Label9"
            Me.Label9.Style = "text-align: left; font-weight: bold; font-size: 8.25pt"
            Me.Label9.Text = "Vale Origen:"
            Me.Label9.Top = 0.944882!
            Me.Label9.Width = 1.220472!
            '
            'Label10
            '
            Me.Label10.Height = 0.2!
            Me.Label10.HyperLink = Nothing
            Me.Label10.Left = 0.1181104!
            Me.Label10.Name = "Label10"
            Me.Label10.Style = "text-align: left; font-weight: bold; font-size: 8.25pt"
            Me.Label10.Text = "Fimar del Asociado:"
            Me.Label10.Top = 3.172737!
            Me.Label10.Width = 1.181102!
            '
            'Label11
            '
            Me.Label11.Height = 0.2!
            Me.Label11.HyperLink = Nothing
            Me.Label11.Left = 0.07874021!
            Me.Label11.Name = "Label11"
            Me.Label11.Style = "text-align: left; font-weight: bold; font-size: 8.25pt"
            Me.Label11.Text = "Con Letra:"
            Me.Label11.Top = 2.857775!
            Me.Label11.Width = 1.220472!
            '
            'Label12
            '
            Me.Label12.Height = 0.2!
            Me.Label12.HyperLink = Nothing
            Me.Label12.Left = 0.07874021!
            Me.Label12.Name = "Label12"
            Me.Label12.Style = "text-align: left; font-weight: bold; font-size: 8.25pt; vertical-align: top"
            Me.Label12.Text = "Pares/Pieza:"
            Me.Label12.Top = 2.665354!
            Me.Label12.Width = 1.220472!
            '
            'txtFolio
            '
            Me.txtFolio.Height = 0.2!
            Me.txtFolio.Left = 1.937008!
            Me.txtFolio.Name = "txtFolio"
            Me.txtFolio.Style = "font-size: 8.25pt"
            Me.txtFolio.Text = "TextBox1"
            Me.txtFolio.Top = 0.2755906!
            Me.txtFolio.Width = 0.7480313!
            '
            'txtOrigen
            '
            Me.txtOrigen.Height = 0.2!
            Me.txtOrigen.Left = 1.419783!
            Me.txtOrigen.Name = "txtOrigen"
            Me.txtOrigen.Style = "font-size: 8.25pt"
            Me.txtOrigen.Text = "TextBox2"
            Me.txtOrigen.Top = 0.944882!
            Me.txtOrigen.Width = 0.784941!
            '
            'txtFechaExp
            '
            Me.txtFechaExp.Height = 0.2!
            Me.txtFechaExp.Left = 1.419783!
            Me.txtFechaExp.Name = "txtFechaExp"
            Me.txtFechaExp.Style = "font-size: 8.25pt"
            Me.txtFechaExp.Text = "TextBox3"
            Me.txtFechaExp.Top = 1.181102!
            Me.txtFechaExp.Width = 0.784941!
            '
            'txtFechaVigencia
            '
            Me.txtFechaVigencia.Height = 0.2!
            Me.txtFechaVigencia.Left = 1.419783!
            Me.txtFechaVigencia.Name = "txtFechaVigencia"
            Me.txtFechaVigencia.Style = "font-size: 8.25pt"
            Me.txtFechaVigencia.Text = "TextBox4"
            Me.txtFechaVigencia.Top = 1.377953!
            Me.txtFechaVigencia.Width = 0.784941!
            '
            'txtClienteAsociado
            '
            Me.txtClienteAsociado.Height = 0.2!
            Me.txtClienteAsociado.Left = 0.07874021!
            Me.txtClienteAsociado.Name = "txtClienteAsociado"
            Me.txtClienteAsociado.Style = "font-size: 8.25pt"
            Me.txtClienteAsociado.Text = "TextBox5"
            Me.txtClienteAsociado.Top = 1.811024!
            Me.txtClienteAsociado.Width = 2.559055!
            '
            'txtDomicilio
            '
            Me.txtDomicilio.Height = 0.2!
            Me.txtDomicilio.Left = 0.07874021!
            Me.txtDomicilio.Name = "txtDomicilio"
            Me.txtDomicilio.Style = "font-size: 8.25pt"
            Me.txtDomicilio.Text = "TextBox6"
            Me.txtDomicilio.Top = 2.244095!
            Me.txtDomicilio.Width = 2.559055!
            '
            'txtTelefono
            '
            Me.txtTelefono.Height = 0.2!
            Me.txtTelefono.Left = 1.419783!
            Me.txtTelefono.Name = "txtTelefono"
            Me.txtTelefono.Style = "font-size: 8.25pt"
            Me.txtTelefono.Text = "TextBox7"
            Me.txtTelefono.Top = 2.468504!
            Me.txtTelefono.Width = 1.178642!
            '
            'txtCantidad
            '
            Me.txtCantidad.Height = 0.2!
            Me.txtCantidad.Left = 1.419783!
            Me.txtCantidad.Name = "txtCantidad"
            Me.txtCantidad.Style = "font-size: 8.25pt"
            Me.txtCantidad.Text = "TextBox8"
            Me.txtCantidad.Top = 2.665354!
            Me.txtCantidad.Width = 0.784941!
            '
            'txtImporteLetra
            '
            Me.txtImporteLetra.Height = 0.2!
            Me.txtImporteLetra.Left = 1.419783!
            Me.txtImporteLetra.Name = "txtImporteLetra"
            Me.txtImporteLetra.Style = "font-size: 8.25pt"
            Me.txtImporteLetra.Text = "TextBox9"
            Me.txtImporteLetra.Top = 2.862205!
            Me.txtImporteLetra.Width = 1.218012!
            '
            'txtAsociado
            '
            Me.txtAsociado.Height = 0.2!
            Me.txtAsociado.Left = 0.07874021!
            Me.txtAsociado.Name = "txtAsociado"
            Me.txtAsociado.Style = "text-align: center; font-size: 8.25pt"
            Me.txtAsociado.Text = "TextBox10"
            Me.txtAsociado.Top = 4.305118!
            Me.txtAsociado.Width = 2.595965!
            '
            'txtFecha
            '
            Me.txtFecha.Height = 0.2!
            Me.txtFecha.Left = 0.9370083!
            Me.txtFecha.Name = "txtFecha"
            Me.txtFecha.Style = "font-size: 8.25pt"
            Me.txtFecha.Text = "TextBox1"
            Me.txtFecha.Top = 0.659941!
            Me.txtFecha.Width = 1.748031!
            '
            'Line1
            '
            Me.Line1.Height = 0!
            Me.Line1.Left = 1.811024!
            Me.Line1.LineWeight = 1!
            Me.Line1.Name = "Line1"
            Me.Line1.Top = 4.606299!
            Me.Line1.Width = 0.8267716!
            Me.Line1.X1 = 2.637795!
            Me.Line1.X2 = 1.811024!
            Me.Line1.Y1 = 4.606299!
            Me.Line1.Y2 = 4.606299!
            '
            'pbMarca
            '
            Me.pbMarca.Height = 1.850394!
            Me.pbMarca.ImageData = Nothing
            Me.pbMarca.Left = 0.472441!
            Me.pbMarca.LineColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(255,Byte),Integer), CType(CType(255,Byte),Integer))
            Me.pbMarca.LineWeight = 0!
            Me.pbMarca.Name = "pbMarca"
            Me.pbMarca.Top = 0.9148618!
            Me.pbMarca.Width = 2.047244!
            '
            'ActiveReport1
            '
            Me.MasterReport = false
            Me.PageSettings.Margins.Bottom = 0.03958333!
            Me.PageSettings.Margins.Left = 0.03958333!
            Me.PageSettings.Margins.Right = 0.03958333!
            Me.PageSettings.Margins.Top = 0.03958333!
            Me.PageSettings.PaperHeight = 11!
            Me.PageSettings.PaperWidth = 8.5!
            Me.PrintWidth = 2.760417!
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
            CType(Me.Label1,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label3,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.pFirma,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label5,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label6,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label7,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label8,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label9,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label10,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label11,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label12,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFolio,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtOrigen,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFechaExp,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFechaVigencia,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtClienteAsociado,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtDomicilio,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtTelefono,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtCantidad,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtImporteLetra,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtAsociado,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFecha,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.pbMarca,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        
	End Sub

#End Region
End Class
