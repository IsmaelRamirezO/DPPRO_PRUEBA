Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Imports DportenisPro.DPTienda.ApplicationUnits.FacturasFormaPago
Imports DportenisPro.DPTienda.ApplicationUnits.Clientes
Imports DportenisPro.DPTienda.ApplicationUnits.NumeroaLetras
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesosAU
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU
Imports MontarUnidadRed
Imports System.IO
Imports DportenisPro.DPTienda.ApplicationUnits.Facturas


Public Class rptRevaleMiniPrinter
    Inherits DataDynamics.ActiveReports.ActiveReport

    Dim oFirmaMgr As FirmaManager
    Dim byteFirma As Byte()

#Region "Objetos S2Credit"

    '----------------------------------------------------------
    ' JNAVA (15.04.2016): Objetos para S2Credit
    '----------------------------------------------------------
    Dim oS2Credit As New ProcesosS2Credit

#End Region

    Public Sub New(ByVal DPValeInfo As DevolucionDPValeInfo, ByVal Diferencia As Decimal, ByVal NombreDistribuidor As String, ByVal FirmaDistribuidor As Image, Optional ByVal MontoOriginal As Decimal = 0, Optional ByVal MontoVenta As Decimal = 0)
        MyBase.New()
        InitializeComponent()

        LoadInfoSAP(DPValeInfo, Diferencia, MontoOriginal, MontoVenta, NombreDistribuidor, FirmaDistribuidor)

    End Sub

    Private Sub LoadInfo(ByVal DPValeInfo As ControlDPValesWS.DPValeInfo, ByVal Diferencia As Decimal)
        Try

            Me.txtFolio.Text = DPValeInfo.DPValeID
            Me.barCode.Text = DPValeInfo.DPValeID
            Me.txtFecha.Text = Now.Date.ToShortDateString & " " & Format(Now, "HH:mm:ss")
            Me.txtOrigen.Text = DPValeInfo.DPValeOrigen
            Me.txtFechaExp.Text = DPValeInfo.FechaEntregado
            Me.txtFechaVigencia.Text = DateAdd(DateInterval.Day, oAppContext.ApplicationConfiguration.DiasVigenciaDPVale, DPValeInfo.FechaEntregado)

            Dim oClienteMgr As New ClientesManager(oAppContext)
            'Dim oCliente As Clientes
            'oCliente = oClienteMgr.Create

            Dim oClienteSAP As New ClientesSAP

            '----------------------------------------------------------------------------------------
            ' JNAVA (15.07.2016): Valida DPVale en S2Credit o en SAP si esta activa la Configuracion 
            '----------------------------------------------------------------------------------------
            oClienteSAP = GetClienteDPVale(DPValeInfo.ClienteAsociadoID)
            'oClienteMgr.LoadInto(DPValeInfo.ClienteAsociadoID, oCliente)

            If oClienteSAP.Clienteid = 0 Then

                Me.txtClienteAsociado.Text = DPValeInfo.ClienteAsociadoID & " " & DPValeInfo.ClienteAsociado

            Else

                Me.txtClienteAsociado.Text = oClienteSAP.Nombre & " " & oClienteSAP.Apellidos 'oCliente.ClienteID & " " & oCliente.Nombre & " " & oCliente.ApellidoPaterno & " " & oCliente.ApellidoMaterno
                Me.txtDomicilio.Text = oClienteSAP.Domicilio 'Cliente.Domicilio
                Me.txtTelefono.Text = oClienteSAP.Telefono

            End If

            Me.txtCantidad.Text = "$" & CStr(Diferencia) '.Substring(0, CStr(Diferencia).LastIndexOf(".") + 2)

            Dim Ob As New DportenisPro.DPTienda.ApplicationUnits.NumeroaLetras.Letras

            Dim parametros() As String = CStr(Diferencia).Split(".")
            parametros(0) = parametros(0).Replace("$", "")

            If parametros.Length > 1 Then
                Me.txtImporteLetra.Text = "(" & Ob.Letras(parametros(0)) & "Pesos " & parametros(1).Substring(0, 2) & "/100 M.N.)"
            Else
                Me.txtImporteLetra.Text = "(" & Ob.Letras(parametros(0)) & "Pesos " & "00/100 M.N.)"
            End If

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

            Dim oCliente As Clientes
            oCliente = oClienteMgr.Create
            oCliente.Clear()
            oClienteMgr.LoadInto(DPValeInfo.ClienteID, oCliente)

            If oCliente.ClienteID = 0 Then

                Me.txtAsociado.Text = DPValeInfo.AsociadoID

            Else

                Me.txtAsociado.Text = "ACREDITADO" & vbCrLf & DPValeInfo.AsociadoID & " " & oCliente.Nombre & " " & oCliente.ApellidoPaterno & " " & oCliente.ApellidoMaterno


            End If

        Catch ex As Exception

            Throw ex

        End Try

    End Sub

    Private Sub LoadInfoSAP(ByVal DPValeInfo As DevolucionDPValeInfo, ByVal Diferencia As Decimal, ByVal MontoOriginal As Decimal, ByVal MontoVenta As Decimal, _
                            ByVal NombreDistribuidor As String, ByVal FirmaDistribuidor As Image)
        Try

            Me.txtFolio.Text = DPValeInfo.DPValeID
            Me.barCode.Text = DPValeInfo.DPValeID
            Me.txtFecha.Text = Now.Date.ToShortDateString & " " & Format(Now, "HH:mm:ss")
            Me.txtOrigen.Text = DPValeInfo.DPValeOrigen
            Me.txtFechaExp.Text = DPValeInfo.FechaEntregado.ToShortDateString()
            Me.txtFechaVigencia.Text = DPValeInfo.FechaEntregado.AddDays(oAppContext.ApplicationConfiguration.DiasVigenciaDPVale).ToShortDateString() ' DateAdd(DateInterval.Day, oAppContext.ApplicationConfiguration.DiasVigenciaDPVale, DPValeInfo.FechaEntregado)

            Dim oSAPMgr As ProcesoSAPManager
            oSAPMgr = New ProcesoSAPManager(oAppContext, oAppSAPConfig)

            '----------------------------------------------------------------
            ' JNAVA (02.03.2016): Comentado por cambios de retail
            '----------------------------------------------------------------
            'Dim info() As String

            'info = oSAPMgr.ZBAPI_DATOS_CLIENTE(Convert.ToString(DPValeInfo.ClienteAsociadoID).PadLeft(10, "0"), 2)

            'Me.txtClienteAsociado.Text = Convert.ToString(DPValeInfo.ClienteAsociadoID).PadLeft(10, "0") & " " & info(1)
            'Me.txtDomicilio.Text = info(2)
            'Me.txtTelefono.Text = info(3)
            '----------------------------------------------------------------

            '----------------------------------------------------------------
            ' JNAVA (02.03.2016): Modificacion por cambios de retail
            '----------------------------------------------------------------
            Dim oClienteSAP As New ClientesSAP

            '----------------------------------------------------------------------------------------
            ' JNAVA (15.07.2016): Valida DPVale en S2Credit o en SAP si esta activa la Configuracion 
            '----------------------------------------------------------------------------------------
            oClienteSAP = GetClienteDPVale(DPValeInfo.ClienteAsociadoID)
            ''oClienteMgr.LoadInto(DPValeInfo.ClienteAsociadoID, oCliente)

            If oClienteSAP Is Nothing OrElse oClienteSAP.Clienteid.Trim = "" Then
                Me.txtClienteAsociado.Text = DPValeInfo.ClienteAsociadoID & " " & DPValeInfo.ClienteAsociado
            Else
                Me.txtClienteAsociado.Text = oClienteSAP.Clienteid & " " & oClienteSAP.Nombre & " " & oClienteSAP.Apellidos
                Me.txtDomicilio.Text = oClienteSAP.Domicilio & " " & oClienteSAP.NumeroExterior & " " & oClienteSAP.Colonia
                Me.txtTelefono.Text = oClienteSAP.Telefono
            End If
            '----------------------------------------------------------------

            If MontoOriginal > 0 Then
                Me.txtMontoOriginal.Text = Format(MontoOriginal, "c")
                Me.txtMontoOriginal.Visible = True
                Me.lblMontoOriginal.Visible = True
                '----------------------------------------------
                'JNAVA (15.12.2014): Piezas de Vale
                '----------------------------------------------
                Me.txtPiezas.Visible = True
                Me.lblPiezas.Visible = True
            End If
            If MontoVenta > 0 Then
                Me.txtMontoVenta.Text = Format(MontoVenta, "c")
                Me.txtMontoVenta.Visible = True
                Me.lblMontoVenta.Visible = True
                '----------------------------------------------
                'JNAVA (15.12.2014): Piezas de Vale
                '----------------------------------------------
                Me.txtPiezas.Visible = True
                Me.lblPiezas.Visible = True
            End If
            Me.txtCantidad.Text = "$" & Diferencia.ToString("##,##0.00").Replace(",", "")

            '----------------------------------------------
            'JNAVA (15.12.2014): Piezas de Vale
            '----------------------------------------------
            If DPValeInfo.ParesPzas <> 0 Then
                Me.txtPiezas.Text = DPValeInfo.ParesPzas
            Else
                Me.txtPiezas.Text = "N/A"
            End If
            '----------------------------------------------

            Dim Ob As New DportenisPro.DPTienda.ApplicationUnits.NumeroaLetras.Letras

            Dim parametros() As String = CStr(Diferencia).Split(".")
            parametros(0) = parametros(0).Replace("$", "")

            If parametros.Length > 1 Then
                If parametros(1).Trim.Length <= 1 Then parametros(1) = parametros(1).Trim & "0"
                Me.txtImporteLetra.Text = "(" & Ob.Letras(parametros(0)) & "Pesos " & parametros(1).Substring(0, 2) & "/100 M.N.)"
            Else
                Me.txtImporteLetra.Text = "(" & Ob.Letras(parametros(0)) & "Pesos " & "00/100 M.N.)"
            End If


            'Me.txtAsociado.Text = CStr(DPValeInfo.AsociadoID).PadLeft(10, "0") & " " & oSAPMgr.ZBAPI_NOMBRE_CLIENTE(CStr(DPValeInfo.AsociadoID).PadLeft(10, "0"))

            ' ''Cargar Imagen del Servidor
            'oFirmaMgr = New FirmaManager(oAppContext, oConfigCierreFI)

            'byteFirma = Me.oFirmaMgr.GetImagenFirmaAsociado(CStr(DPValeInfo.AsociadoID).PadLeft(10, "0"))
            'If Not byteFirma Is Nothing And Not IsDBNull(byteFirma) Then
            '    Dim oFirmaAsociado() As Byte = CType(byteFirma, Byte())
            '    Dim msFotoAsociado As New MemoryStream(oFirmaAsociado)
            '    If Not pFirma.Image Is Nothing Then
            '        pFirma.Image.Dispose()
            '    End If

            '    Me.pFirma.Image = Image.FromStream(msFotoAsociado)
            'Else
            '    Me.pFirma.Image = Nothing
            'End If

            '---------------------------------------------------------------------------------------------------------------------------------------------------------
            ' JNAVA (15.07.2016): SI esta activba la config de S2credit obtenemos lso datos del distribuidor desde la validacion del vale
            '---------------------------------------------------------------------------------------------------------------------------------------------------------
            If oConfigCierreFI.AplicarS2Credit Then

                '------------------------------------------------------------------------
                ' JNAVA (15.07.2016): ID y Nombre de Distribuidor 
                '------------------------------------------------------------------------
                Me.txtAsociado.Text = CStr(DPValeInfo.AsociadoID).PadLeft(10, "0") & " " & NombreDistribuidor.TrimEnd

                '------------------------------------------------------------------------
                ' JNAVA (15.07.2016): Firma Distribuidor
                '------------------------------------------------------------------------
                Me.pFirma.Image = FirmaDistribuidor

            Else
                Me.txtAsociado.Text = CStr(DPValeInfo.AsociadoID).PadLeft(10, "0") & " " & oSAPMgr.ZBAPI_NOMBRE_CLIENTE(CStr(DPValeInfo.AsociadoID).PadLeft(10, "0"))

                ''Cargar Imagen del Servidor
                oFirmaMgr = New FirmaManager(oAppContext, oConfigCierreFI)

                byteFirma = Me.oFirmaMgr.GetImagenFirmaAsociado(CStr(DPValeInfo.AsociadoID).PadLeft(10, "0"))
                If Not byteFirma Is Nothing And Not IsDBNull(byteFirma) Then
                    Dim oFirmaAsociado() As Byte = CType(byteFirma, Byte())
                    Dim msFotoAsociado As New MemoryStream(oFirmaAsociado)
                    If Not pFirma.Image Is Nothing Then
                        pFirma.Image.Dispose()
                    End If

                    Me.pFirma.Image = Image.FromStream(msFotoAsociado)
                Else
                    Me.pFirma.Image = Nothing
                End If
            End If


            ''Cambiar por una ruta de configuración
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
    Private lblMontoOriginal As Label = Nothing
    Private txtMontoOriginal As TextBox = Nothing
    Private lblMontoVenta As Label = Nothing
    Private txtMontoVenta As TextBox = Nothing
    Private lblPiezas As Label = Nothing
    Private txtPiezas As TextBox = Nothing
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptRevaleMiniPrinter))
        Me.Detail = New DataDynamics.ActiveReports.Detail()
        Me.PageHeader = New DataDynamics.ActiveReports.PageHeader()
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
        Me.lblMontoOriginal = New DataDynamics.ActiveReports.Label()
        Me.txtMontoOriginal = New DataDynamics.ActiveReports.TextBox()
        Me.lblMontoVenta = New DataDynamics.ActiveReports.Label()
        Me.txtMontoVenta = New DataDynamics.ActiveReports.TextBox()
        Me.lblPiezas = New DataDynamics.ActiveReports.Label()
        Me.txtPiezas = New DataDynamics.ActiveReports.TextBox()
        Me.PageFooter = New DataDynamics.ActiveReports.PageFooter()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pFirma, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFolio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtOrigen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaExp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaVigencia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtClienteAsociado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDomicilio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTelefono, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCantidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtImporteLetra, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAsociado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblMontoOriginal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMontoOriginal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblMontoVenta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMontoVenta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblPiezas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPiezas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.ColumnSpacing = 0.0!
        Me.Detail.Height = 0.0!
        Me.Detail.Name = "Detail"
        '
        'PageHeader
        '
        Me.PageHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label1, Me.Label2, Me.Label3, Me.barCode, Me.pFirma, Me.Label4, Me.Label5, Me.Label6, Me.Label7, Me.Label8, Me.Label9, Me.Label10, Me.Label11, Me.Label12, Me.txtFolio, Me.txtOrigen, Me.txtFechaExp, Me.txtFechaVigencia, Me.txtClienteAsociado, Me.txtDomicilio, Me.txtTelefono, Me.txtCantidad, Me.txtImporteLetra, Me.txtAsociado, Me.txtFecha, Me.Line1, Me.lblMontoOriginal, Me.txtMontoOriginal, Me.lblMontoVenta, Me.txtMontoVenta, Me.lblPiezas, Me.txtPiezas})
        Me.PageHeader.Height = 6.456944!
        Me.PageHeader.Name = "PageHeader"
        '
        'Label1
        '
        Me.Label1.Height = 0.2!
        Me.Label1.HyperLink = Nothing
        Me.Label1.Left = 0.5127952!
        Me.Label1.Name = "Label1"
        Me.Label1.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
        Me.Label1.Text = "Dportenis Vale (Re-Vale)"
        Me.Label1.Top = 0.0!
        Me.Label1.Width = 1.588091!
        '
        'Label2
        '
        Me.Label2.Height = 0.2!
        Me.Label2.HyperLink = Nothing
        Me.Label2.Left = 1.253937!
        Me.Label2.Name = "Label2"
        Me.Label2.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
        Me.Label2.Text = "Fecha/Hora Impresión"
        Me.Label2.Top = 0.472441!
        Me.Label2.Width = 1.346063!
        '
        'Label3
        '
        Me.Label3.Height = 0.2!
        Me.Label3.HyperLink = Nothing
        Me.Label3.Left = 1.253937!
        Me.Label3.Name = "Label3"
        Me.Label3.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
        Me.Label3.Text = "Folio"
        Me.Label3.Top = 0.2755906!
        Me.Label3.Width = 0.6264768!
        '
        'barCode
        '
        Me.barCode.CheckSumEnabled = False
        Me.barCode.Font = New System.Drawing.Font("Courier New", 8.0!)
        Me.barCode.Height = 0.3149606!
        Me.barCode.Left = 0.2559055!
        Me.barCode.Name = "barCode"
        Me.barCode.Style = DataDynamics.ActiveReports.BarCodeStyle.Codabar
        Me.barCode.Text = "0"
        Me.barCode.Top = 0.2755906!
        Me.barCode.Width = 0.9842521!
        '
        'pFirma
        '
        Me.pFirma.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.pFirma.Height = 1.417323!
        Me.pFirma.ImageData = Nothing
        Me.pFirma.Left = 0.2559055!
        Me.pFirma.LineColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.pFirma.LineWeight = 0.0!
        Me.pFirma.Name = "pFirma"
        Me.pFirma.SizeMode = DataDynamics.ActiveReports.SizeModes.Stretch
        Me.pFirma.Top = 4.559547!
        Me.pFirma.Width = 2.329724!
        '
        'Label4
        '
        Me.Label4.Height = 0.2!
        Me.Label4.HyperLink = Nothing
        Me.Label4.Left = 0.2559055!
        Me.Label4.Name = "Label4"
        Me.Label4.Style = "text-align: left; font-weight: bold; font-size: 8.25pt"
        Me.Label4.Text = "Domicilio"
        Me.Label4.Top = 2.007874!
        Me.Label4.Width = 1.220472!
        '
        'Label5
        '
        Me.Label5.Height = 0.2!
        Me.Label5.HyperLink = Nothing
        Me.Label5.Left = 0.2559055!
        Me.Label5.Name = "Label5"
        Me.Label5.Style = "text-align: left; font-weight: bold; font-size: 8.25pt"
        Me.Label5.Text = "Teléfono"
        Me.Label5.Top = 2.531496!
        Me.Label5.Width = 1.220472!
        '
        'Label6
        '
        Me.Label6.Height = 0.2!
        Me.Label6.HyperLink = Nothing
        Me.Label6.Left = 0.2559055!
        Me.Label6.Name = "Label6"
        Me.Label6.Style = "text-align: left; font-weight: bold; font-size: 8.25pt"
        Me.Label6.Text = "Valido Hasta:"
        Me.Label6.Top = 1.38189!
        Me.Label6.Width = 1.220472!
        '
        'Label7
        '
        Me.Label7.Height = 0.2!
        Me.Label7.HyperLink = Nothing
        Me.Label7.Left = 0.2559055!
        Me.Label7.Name = "Label7"
        Me.Label7.Style = "text-align: left; font-weight: bold; font-size: 8.25pt"
        Me.Label7.Text = "CANJEANTE"
        Me.Label7.Top = 1.57874!
        Me.Label7.Width = 1.377953!
        '
        'Label8
        '
        Me.Label8.Height = 0.2!
        Me.Label8.HyperLink = Nothing
        Me.Label8.Left = 0.2559055!
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
        Me.Label9.Left = 0.2559055!
        Me.Label9.Name = "Label9"
        Me.Label9.Style = "text-align: left; font-weight: bold; font-size: 8.25pt"
        Me.Label9.Text = "Vale Origen:"
        Me.Label9.Top = 0.944882!
        Me.Label9.Width = 1.299212!
        '
        'Label10
        '
        Me.Label10.Height = 0.2!
        Me.Label10.HyperLink = Nothing
        Me.Label10.Left = 0.2559055!
        Me.Label10.Name = "Label10"
        Me.Label10.Style = "text-align: left; font-weight: bold; font-size: 8.25pt"
        Me.Label10.Text = "Firma del Acreditado :"
        Me.Label10.Top = 4.358759!
        Me.Label10.Width = 1.306594!
        '
        'Label11
        '
        Me.Label11.Height = 0.2!
        Me.Label11.HyperLink = Nothing
        Me.Label11.Left = 0.2559055!
        Me.Label11.Name = "Label11"
        Me.Label11.Style = "text-align: left; font-weight: bold; font-size: 8.25pt"
        Me.Label11.Text = "Con Letra:"
        Me.Label11.Top = 3.85876!
        Me.Label11.Width = 1.220472!
        '
        'Label12
        '
        Me.Label12.Height = 0.2!
        Me.Label12.HyperLink = Nothing
        Me.Label12.Left = 0.2559055!
        Me.Label12.Name = "Label12"
        Me.Label12.Style = "text-align: left; font-weight: bold; font-size: 8.25pt"
        Me.Label12.Text = "Importe Disponible:"
        Me.Label12.Top = 3.353346!
        Me.Label12.Width = 1.220472!
        '
        'txtFolio
        '
        Me.txtFolio.Height = 0.2!
        Me.txtFolio.Left = 1.919783!
        Me.txtFolio.Name = "txtFolio"
        Me.txtFolio.Style = "font-size: 8.25pt"
        Me.txtFolio.Text = "TextBox1"
        Me.txtFolio.Top = 0.2755906!
        Me.txtFolio.Width = 0.7480313!
        '
        'txtOrigen
        '
        Me.txtOrigen.Height = 0.2!
        Me.txtOrigen.Left = 1.728!
        Me.txtOrigen.Name = "txtOrigen"
        Me.txtOrigen.Style = "font-size: 8.25pt"
        Me.txtOrigen.Text = "TextBox2"
        Me.txtOrigen.Top = 0.944882!
        Me.txtOrigen.Width = 0.89!
        '
        'txtFechaExp
        '
        Me.txtFechaExp.Height = 0.2!
        Me.txtFechaExp.Left = 1.728!
        Me.txtFechaExp.Name = "txtFechaExp"
        Me.txtFechaExp.Style = "font-size: 8.25pt"
        Me.txtFechaExp.Text = "TextBox3"
        Me.txtFechaExp.Top = 1.181102!
        Me.txtFechaExp.Width = 0.89!
        '
        'txtFechaVigencia
        '
        Me.txtFechaVigencia.Height = 0.2!
        Me.txtFechaVigencia.Left = 1.728!
        Me.txtFechaVigencia.Name = "txtFechaVigencia"
        Me.txtFechaVigencia.Style = "font-size: 8.25pt"
        Me.txtFechaVigencia.Text = "TextBox4"
        Me.txtFechaVigencia.Top = 1.377953!
        Me.txtFechaVigencia.Width = 0.89!
        '
        'txtClienteAsociado
        '
        Me.txtClienteAsociado.Height = 0.2!
        Me.txtClienteAsociado.Left = 0.2559055!
        Me.txtClienteAsociado.Name = "txtClienteAsociado"
        Me.txtClienteAsociado.Style = "font-size: 8.25pt"
        Me.txtClienteAsociado.Text = "TextBox5"
        Me.txtClienteAsociado.Top = 1.771653!
        Me.txtClienteAsociado.Width = 2.362205!
        '
        'txtDomicilio
        '
        Me.txtDomicilio.Height = 0.2!
        Me.txtDomicilio.Left = 0.2559055!
        Me.txtDomicilio.Name = "txtDomicilio"
        Me.txtDomicilio.Style = "font-size: 8.25pt"
        Me.txtDomicilio.Text = "TextBox6"
        Me.txtDomicilio.Top = 2.283465!
        Me.txtDomicilio.Width = 2.362205!
        '
        'txtTelefono
        '
        Me.txtTelefono.Height = 0.2!
        Me.txtTelefono.Left = 1.581693!
        Me.txtTelefono.Name = "txtTelefono"
        Me.txtTelefono.Style = "font-size: 8.25pt"
        Me.txtTelefono.Text = "TextBox7"
        Me.txtTelefono.Top = 2.531004!
        Me.txtTelefono.Width = 1.102362!
        '
        'txtCantidad
        '
        Me.txtCantidad.Height = 0.2!
        Me.txtCantidad.Left = 1.581693!
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Style = "font-weight: bold; font-size: 9pt"
        Me.txtCantidad.Text = "TextBox8"
        Me.txtCantidad.Top = 3.352854!
        Me.txtCantidad.Width = 0.855807!
        '
        'txtImporteLetra
        '
        Me.txtImporteLetra.Height = 0.2!
        Me.txtImporteLetra.Left = 0.2559055!
        Me.txtImporteLetra.Name = "txtImporteLetra"
        Me.txtImporteLetra.Style = "font-size: 8.25pt"
        Me.txtImporteLetra.Text = "TextBox9"
        Me.txtImporteLetra.Top = 4.087106!
        Me.txtImporteLetra.Width = 2.440945!
        '
        'txtAsociado
        '
        Me.txtAsociado.Height = 0.2!
        Me.txtAsociado.Left = 0.2559055!
        Me.txtAsociado.Name = "txtAsociado"
        Me.txtAsociado.Style = "text-align: center; font-size: 8.25pt"
        Me.txtAsociado.Text = "TextBox10"
        Me.txtAsociado.Top = 6.019684!
        Me.txtAsociado.Width = 2.401575!
        '
        'txtFecha
        '
        Me.txtFecha.Height = 0.2!
        Me.txtFecha.Left = 1.306102!
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.Style = "font-size: 8.25pt"
        Me.txtFecha.Text = "TextBox1"
        Me.txtFecha.Top = 0.6299213!
        Me.txtFecha.Width = 1.243898!
        '
        'Line1
        '
        Me.Line1.Height = 0.0!
        Me.Line1.Left = 0.4793853!
        Me.Line1.LineWeight = 1.0!
        Me.Line1.Name = "Line1"
        Me.Line1.Top = 6.451334!
        Me.Line1.Width = 1.785543!
        Me.Line1.X1 = 2.264928!
        Me.Line1.X2 = 0.4793853!
        Me.Line1.Y1 = 6.451334!
        Me.Line1.Y2 = 6.451334!
        '
        'lblMontoOriginal
        '
        Me.lblMontoOriginal.Height = 0.2!
        Me.lblMontoOriginal.HyperLink = Nothing
        Me.lblMontoOriginal.Left = 0.2559055!
        Me.lblMontoOriginal.Name = "lblMontoOriginal"
        Me.lblMontoOriginal.Style = "text-align: left; font-weight: bold; font-size: 8.25pt"
        Me.lblMontoOriginal.Text = "Importe Original:"
        Me.lblMontoOriginal.Top = 2.790847!
        Me.lblMontoOriginal.Visible = False
        Me.lblMontoOriginal.Width = 1.220472!
        '
        'txtMontoOriginal
        '
        Me.txtMontoOriginal.Height = 0.2!
        Me.txtMontoOriginal.Left = 1.581693!
        Me.txtMontoOriginal.Name = "txtMontoOriginal"
        Me.txtMontoOriginal.Style = "font-size: 8.25pt"
        Me.txtMontoOriginal.Text = "TextBox8"
        Me.txtMontoOriginal.Top = 2.790354!
        Me.txtMontoOriginal.Visible = False
        Me.txtMontoOriginal.Width = 0.7293313!
        '
        'lblMontoVenta
        '
        Me.lblMontoVenta.Height = 0.2!
        Me.lblMontoVenta.HyperLink = Nothing
        Me.lblMontoVenta.Left = 0.2559055!
        Me.lblMontoVenta.Name = "lblMontoVenta"
        Me.lblMontoVenta.Style = "text-align: left; font-weight: bold; font-size: 8.25pt"
        Me.lblMontoVenta.Text = "Importe a Pagar:"
        Me.lblMontoVenta.Top = 3.040846!
        Me.lblMontoVenta.Visible = False
        Me.lblMontoVenta.Width = 1.220472!
        '
        'txtMontoVenta
        '
        Me.txtMontoVenta.Height = 0.2!
        Me.txtMontoVenta.Left = 1.581693!
        Me.txtMontoVenta.Name = "txtMontoVenta"
        Me.txtMontoVenta.Style = "font-size: 8.25pt"
        Me.txtMontoVenta.Text = "TextBox8"
        Me.txtMontoVenta.Top = 3.040354!
        Me.txtMontoVenta.Visible = False
        Me.txtMontoVenta.Width = 0.7293313!
        '
        'lblPiezas
        '
        Me.lblPiezas.Height = 0.2!
        Me.lblPiezas.HyperLink = Nothing
        Me.lblPiezas.Left = 0.25!
        Me.lblPiezas.Name = "lblPiezas"
        Me.lblPiezas.Style = "text-align: left; font-weight: bold; font-size: 8.25pt"
        Me.lblPiezas.Text = "Piezas Disponibles:"
        Me.lblPiezas.Top = 3.5625!
        Me.lblPiezas.Visible = False
        Me.lblPiezas.Width = 1.220472!
        '
        'txtPiezas
        '
        Me.txtPiezas.Height = 0.2!
        Me.txtPiezas.Left = 1.581693!
        Me.txtPiezas.Name = "txtPiezas"
        Me.txtPiezas.Style = "font-weight: bold; font-size: 9pt"
        Me.txtPiezas.Text = "TextBox8"
        Me.txtPiezas.Top = 3.540354!
        Me.txtPiezas.Visible = False
        Me.txtPiezas.Width = 0.855807!
        '
        'PageFooter
        '
        Me.PageFooter.Height = 0.01041667!
        Me.PageFooter.Name = "PageFooter"
        '
        'rptRevaleMiniPrinter
        '
        Me.MasterReport = False
        Me.PageSettings.Margins.Bottom = 0.0!
        Me.PageSettings.Margins.Left = 0.0!
        Me.PageSettings.Margins.Right = 0.0!
        Me.PageSettings.Margins.Top = 0.0!
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 2.71875!
        Me.Sections.Add(Me.PageHeader)
        Me.Sections.Add(Me.Detail)
        Me.Sections.Add(Me.PageFooter)
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" & _
            "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei" & _
            "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" & _
            "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit", "Heading3", "Normal"))
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pFirma, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFolio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtOrigen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaExp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaVigencia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtClienteAsociado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDomicilio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTelefono, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCantidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtImporteLetra, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAsociado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblMontoOriginal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMontoOriginal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblMontoVenta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMontoVenta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblPiezas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPiezas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

#End Region



End Class
