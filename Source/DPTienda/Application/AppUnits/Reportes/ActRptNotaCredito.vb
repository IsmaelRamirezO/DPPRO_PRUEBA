Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Imports DportenisPro.DPTienda.ApplicationUnits.NotasCreditoAU
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes
Imports DportenisPro.DPTienda.ApplicationUnits.Clientes
Imports DportenisPro.DPTienda.ApplicationUnits.Facturas
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU


Public Class ActRptNotaCredito
    Inherits DataDynamics.ActiveReports.ActiveReport
    Dim boolImprimirCedula As Boolean = True

    Public Sub New(ByVal oNC As NotaCredito, Optional ByVal ImprimirCedula As Boolean = True, Optional ByVal Reimpresion As Boolean = False)
        MyBase.New()
        InitializeComponent()
        Dim oClientesMgr As ClientesManager
        Dim oCliente As ClienteAlterno
        oClientesMgr = New ClientesManager(oAppContext)
        oCliente = oClientesMgr.CreateAlterno

        boolImprimirCedula = ImprimirCedula

        Me.tbCantidad.DataField = "Cantidad"
        Me.tbCodigo.DataField = "CodArticulo"
        Me.tbConcepto.DataField = "Descripcion"
        Me.tbNumero.DataField = "Numero"
        Me.tbPUnitario.DataField = "importe"
        Me.tbTotal.DataField = "importe"
        'Me.tbFactura.DataField = "FolioReferencia"

        Dim oFacturaMGR As New FacturaManager(oAppContext)
        Dim oFactura As Factura
        oFactura = oFacturaMGR.Create()
        If Reimpresion = False Then
            oFacturaMGR.LoadInto(oNC.Detalle.Tables(0).Rows(0)("FacturaID"), oFactura)
            Me.tbFactura.Text = oFactura.Referencia
        Else
            Me.tbFactura.Text = oNC.Referencia
        End If
        
        
        'oNotaCredito.Detalle.Tables(0)



        '*******************************************************************
        '------------------------------DESC. APLICADO:
        'If DatosGenerales.Rows(0).Item("Descuento") <> 0 Then
        '    ' If oFactura.CodTipoVenta = "P" Or oFactura.CodTipoVenta = "V" Then
        '    ' tbSubTotal.Text = Format(DatosGenerales.Rows(0).Item("Descuento") * (oAppContext.ApplicationConfiguration.IVA + 1), "Currency") & vbNewLine
        '    'Else
        '    tbSubTotal.Text = Format(DatosGenerales.Rows(0).Item("Descuento"), "Currency") & vbNewLine
        '    ' End If
        '    TxtSubTotIva.Text = "DESC. APLICADO:" & vbNewLine
        'Else
        '    Label20.Text = String.Empty
        '    TxtBxSubTotSinDescto.Text = String.Empty
        '    TxtBxSubTotSinDescto.Visible = False
        '    Label20.Visible = False
        'End If
        '------------------------------DESC. APLICADO:
        '----------------------------SUBTOTAL      
        If oNC.IVA <> 0 Then
            tbSubTotal.Text = tbSubTotal.Text & Format(CDbl(oNC.Importe) - CDbl(oNC.IVA), "$#,##0.00") & vbNewLine
            TxtSubTotIva.Text = TxtSubTotIva.Text & "SUBTOTAL:" & vbNewLine
            'End If
            '----------------------------SUBTOTAL
            '----------------------------IVA
            'If oNC.IVA <> 0 Then
            tbSubTotal.Text = tbSubTotal.Text & Format(CDbl(oNC.IVA), "$#,##0.00") & vbNewLine
            TxtSubTotIva.Text = TxtSubTotIva.Text & "IVA:" & vbNewLine
        End If
        '----------------------------IVA
        '----------------------------TOTAL
        tbSubTotal.Text = tbSubTotal.Text & Format(CDbl(oNC.Importe), "$#,##0.00")
        TxtSubTotIva.Text = TxtSubTotIva.Text & "TOTAL:" & vbNewLine
        '----------------------------TOTAL
        '*******************************************************************

        TxtBxNCFolio.Text = oNC.SALESDOCUMENT
        'tbFactura.Text=
        'tbFactura.Text = CStr().PadLeft(10, "0")

        '----------------------------------------------------------------------
        tbNombre.Text = oNC.ClienteID
        If oNC.ClienteID <> "10000000".PadLeft(10, "0") Then
            If oNC.TipoVentaID = "A" Then
                oClientesMgr.Load(CStr(oNC.ClienteID).PadLeft(10, "0"), oCliente, "I")
            Else
                oClientesMgr.Load(CStr(oNC.ClienteID).PadLeft(10, "0"), oCliente, oNC.TipoVentaID)
            End If
        End If

        Dim strdt As String = String.Empty
        If (oNC.ClienteID <> "10000000".PadLeft(10, "0")) Then
            tbNombre.Text = oCliente.Nombre & " " & oCliente.ApellidoPaterno & " " & oCliente.ApellidoMaterno
            tbDomicilio.Text = String.Empty
            '------------------------DOMICILIO
            strdt = Trim(oCliente.Direccion & " " & oCliente.Colonia)
            If strdt <> String.Empty Then
                tbDomicilio.Text = strdt & vbNewLine
            End If
            '------------------------CIUDAD ESTADO
            strdt = Trim(oCliente.Ciudad & " " & oCliente.Estado & " " & oCliente.CP)
            If strdt <> String.Empty Then
                If oNC.TipoVentaID = "P" Then
                    tbDomicilio.Text = tbDomicilio.Text & strdt
                Else
                    tbDomicilio.Text = tbDomicilio.Text & strdt & vbNewLine
                End If
            End If
            '------------------------RFC
            strdt = Trim(IIf(IsDBNull(oCliente.RFC), "", oCliente.RFC))
            If strdt <> String.Empty Then
                tbDomicilio.Text = tbDomicilio.Text & strdt & vbNewLine
            End If
            '------------------------TELEFONO
            strdt = Trim(IIf(IsDBNull(oCliente.Telefono), "", oCliente.Telefono))
            If strdt <> String.Empty Then
                tbDomicilio.Text = tbDomicilio.Text & strdt
            End If
        Else
            tbNombre.Text = "PÚBLICO GENERAL"
            tbDomicilio.Text = oCliente.Ciudad & " " & oCliente.Estado
        End If
        '----------------------------------------------------------------------

        lblCaja.Text = "CAJA :" & oNC.CajaID
        Select Case oNC.TipoVentaID
            Case "P"
                tbTipoVenta.Text = "PISO DE VENTA"
            Case "V"
                tbTipoVenta.Text = "DPVALE"
            Case "D"
                tbTipoVenta.Text = "ASOCIADO (DIP'S)"
            Case "S"
                tbTipoVenta.Text = "DPSOCIO"
            Case "F", "K"
                tbTipoVenta.Text = "CRÉDITO FONACOT"
            Case "O"
                tbTipoVenta.Text = "CRÉDITO FACILITO"
            Case "M"
                tbTipoVenta.Text = "MAYOREO"
            Case "I"
                tbTipoVenta.Text = "FACTURACIÓN FISCAL"
            Case "A"
                tbTipoVenta.Text = "APARTADO"
        End Select

        tbPlayer.Text = oNC.PlayerID
        '------------------------SUCURSAL
        Dim oCatalogoAlmacenesMgr As New CatalogoAlmacenesManager(oAppContext)
        Dim oAlmacen As Almacen
        Dim oSAPMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        oAlmacen = oCatalogoAlmacenesMgr.Load(oSAPMgr.Read_Centros) '"2" & oAppContext.ApplicationConfiguration.Almacen)
        Me.TxtTienda.Text = oAlmacen.Descripcion
        Me.txtDomTienda.Text = oAlmacen.DireccionCalle
        Me.LblTelefono.Text = "C.P." & oAlmacen.DireccionCP & " TEL. " & oAlmacen.TelefonoNum
        Me.LblLocaliz.Text = oAlmacen.DireccionCiudad & ", " & oAlmacen.DireccionEstado
        oCatalogoAlmacenesMgr = Nothing
        tbLugarFecha.Text = oAlmacen.DireccionCiudad & ", " & oAlmacen.DireccionEstado & ", " & UCase(Format(Now, "dd-MMM-yyyy hh:mm"))
        oAlmacen = Nothing
        Me.txtInfoSuc.Text = Me.TxtTienda.Text & vbCrLf & Me.txtDomTienda.Text & vbCrLf & Me.LblTelefono.Text & _
                             Me.Label19.Text & vbCrLf & Me.LblLocaliz.Text
        '-------------------------SUCURSAL
        tbTotalLetras.Text = Letras(CStr(oNC.Importe))

    End Sub
#Region "ActiveReports Designer generated code"
    Private WithEvents ReportHeader As ReportHeader = Nothing
    Private WithEvents PageHeader As PageHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents PageFooter As PageFooter = Nothing
    Private WithEvents ReportFooter As ReportFooter = Nothing
	Private tbNombre As TextBox = Nothing
	Private tbFactura As TextBox = Nothing
	Private tbDomicilio As TextBox = Nothing
	Private tbLugarFecha As TextBox = Nothing
	Private lblLeyendaPago As Label = Nothing
	Private tbTipoVenta As TextBox = Nothing
	Private lblCaja As Label = Nothing
	Private Label13 As Label = Nothing
	Private LblDomTienda As Label = Nothing
	Private LblTelefono As Label = Nothing
	Private LblLocaliz As Label = Nothing
	Private Label16 As Label = Nothing
	Private Label8 As Label = Nothing
	Private Label9 As Label = Nothing
	Private Label10 As Label = Nothing
	Private Label11 As Label = Nothing
	Private Label12 As Label = Nothing
	Private Label17 As Label = Nothing
	Private Label19 As Label = Nothing
	Private LblCopia As Label = Nothing
	Private txtDomTienda As TextBox = Nothing
	Private TxtTienda As TextBox = Nothing
	Private TxtBxNCFolio As TextBox = Nothing
	Private Label35 As Label = Nothing
	Private txtInfoSuc As TextBox = Nothing
	Private tbCodigo As TextBox = Nothing
	Private tbNumero As TextBox = Nothing
	Private tbConcepto As TextBox = Nothing
	Private tbPUnitario As TextBox = Nothing
	Private tbTotal As TextBox = Nothing
	Private tbCantidad As TextBox = Nothing
	Private Label27 As Label = Nothing
	Private Label29 As Label = Nothing
	Private Label25 As Label = Nothing
	Private Label24 As Label = Nothing
	Private Label23 As Label = Nothing
	Private Shape2 As Shape = Nothing
	Private tbSubTotal As TextBox = Nothing
	Private tbPlayer As TextBox = Nothing
	Private Label1 As Label = Nothing
	Private tbTotalLetras As TextBox = Nothing
	Private Label18 As Label = Nothing
	Private Label22 As Label = Nothing
	Private TxtSubTotIva As TextBox = Nothing
	Private Label26 As Label = Nothing
	Private Label28 As Label = Nothing
	Private Label30 As Label = Nothing
	Private Label31 As Label = Nothing
	Private Label32 As Label = Nothing
	Private Label33 As Label = Nothing
	Private Label34 As Label = Nothing
	Private Line1 As Line = Nothing
	Private Shape1 As Shape = Nothing
	Private TextBox1 As TextBox = Nothing
	Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ActRptNotaCredito))
        Me.Detail = New DataDynamics.ActiveReports.Detail()
        Me.tbCodigo = New DataDynamics.ActiveReports.TextBox()
        Me.tbNumero = New DataDynamics.ActiveReports.TextBox()
        Me.tbConcepto = New DataDynamics.ActiveReports.TextBox()
        Me.tbPUnitario = New DataDynamics.ActiveReports.TextBox()
        Me.tbTotal = New DataDynamics.ActiveReports.TextBox()
        Me.tbCantidad = New DataDynamics.ActiveReports.TextBox()
        Me.ReportHeader = New DataDynamics.ActiveReports.ReportHeader()
        Me.tbNombre = New DataDynamics.ActiveReports.TextBox()
        Me.tbFactura = New DataDynamics.ActiveReports.TextBox()
        Me.tbDomicilio = New DataDynamics.ActiveReports.TextBox()
        Me.tbLugarFecha = New DataDynamics.ActiveReports.TextBox()
        Me.lblLeyendaPago = New DataDynamics.ActiveReports.Label()
        Me.tbTipoVenta = New DataDynamics.ActiveReports.TextBox()
        Me.lblCaja = New DataDynamics.ActiveReports.Label()
        Me.Label13 = New DataDynamics.ActiveReports.Label()
        Me.LblDomTienda = New DataDynamics.ActiveReports.Label()
        Me.LblTelefono = New DataDynamics.ActiveReports.Label()
        Me.LblLocaliz = New DataDynamics.ActiveReports.Label()
        Me.Label16 = New DataDynamics.ActiveReports.Label()
        Me.Label8 = New DataDynamics.ActiveReports.Label()
        Me.Label9 = New DataDynamics.ActiveReports.Label()
        Me.Label10 = New DataDynamics.ActiveReports.Label()
        Me.Label11 = New DataDynamics.ActiveReports.Label()
        Me.Label12 = New DataDynamics.ActiveReports.Label()
        Me.Label17 = New DataDynamics.ActiveReports.Label()
        Me.Label19 = New DataDynamics.ActiveReports.Label()
        Me.LblCopia = New DataDynamics.ActiveReports.Label()
        Me.txtDomTienda = New DataDynamics.ActiveReports.TextBox()
        Me.TxtTienda = New DataDynamics.ActiveReports.TextBox()
        Me.TxtBxNCFolio = New DataDynamics.ActiveReports.TextBox()
        Me.Label35 = New DataDynamics.ActiveReports.Label()
        Me.txtInfoSuc = New DataDynamics.ActiveReports.TextBox()
        Me.ReportFooter = New DataDynamics.ActiveReports.ReportFooter()
        Me.Label27 = New DataDynamics.ActiveReports.Label()
        Me.Label29 = New DataDynamics.ActiveReports.Label()
        Me.Label25 = New DataDynamics.ActiveReports.Label()
        Me.Label24 = New DataDynamics.ActiveReports.Label()
        Me.Label23 = New DataDynamics.ActiveReports.Label()
        Me.Shape2 = New DataDynamics.ActiveReports.Shape()
        Me.tbSubTotal = New DataDynamics.ActiveReports.TextBox()
        Me.tbPlayer = New DataDynamics.ActiveReports.TextBox()
        Me.Label1 = New DataDynamics.ActiveReports.Label()
        Me.tbTotalLetras = New DataDynamics.ActiveReports.TextBox()
        Me.Label18 = New DataDynamics.ActiveReports.Label()
        Me.Label22 = New DataDynamics.ActiveReports.Label()
        Me.TxtSubTotIva = New DataDynamics.ActiveReports.TextBox()
        Me.Label26 = New DataDynamics.ActiveReports.Label()
        Me.Label28 = New DataDynamics.ActiveReports.Label()
        Me.Label30 = New DataDynamics.ActiveReports.Label()
        Me.Label31 = New DataDynamics.ActiveReports.Label()
        Me.Label32 = New DataDynamics.ActiveReports.Label()
        Me.Label33 = New DataDynamics.ActiveReports.Label()
        Me.Label34 = New DataDynamics.ActiveReports.Label()
        Me.Line1 = New DataDynamics.ActiveReports.Line()
        Me.Shape1 = New DataDynamics.ActiveReports.Shape()
        Me.TextBox1 = New DataDynamics.ActiveReports.TextBox()
        Me.PageHeader = New DataDynamics.ActiveReports.PageHeader()
        Me.PageFooter = New DataDynamics.ActiveReports.PageFooter()
        CType(Me.tbCodigo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbNumero, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbConcepto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbPUnitario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbCantidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbNombre, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbFactura, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbDomicilio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbLugarFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblLeyendaPago, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbTipoVenta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblCaja, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblDomTienda, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblTelefono, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblLocaliz, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label19, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblCopia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDomTienda, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtTienda, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtBxNCFolio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label35, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtInfoSuc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label27, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label29, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label25, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label24, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label23, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbSubTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbPlayer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbTotalLetras, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label22, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtSubTotIva, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label26, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label28, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label30, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label31, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label32, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label33, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label34, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.ColumnSpacing = 0.0!
        Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.tbCodigo, Me.tbNumero, Me.tbConcepto, Me.tbPUnitario, Me.tbTotal, Me.tbCantidad})
        Me.Detail.Height = 0.1875!
        Me.Detail.Name = "Detail"
        '
        'tbCodigo
        '
        Me.tbCodigo.CanShrink = True
        Me.tbCodigo.Height = 0.2!
        Me.tbCodigo.Left = 0.4330709!
        Me.tbCodigo.Name = "tbCodigo"
        Me.tbCodigo.Style = "ddo-char-set: 0; text-align: left; font-size: 6.75pt; font-family: Tahoma"
        Me.tbCodigo.Text = "KS-001253-2791"
        Me.tbCodigo.Top = 0.0!
        Me.tbCodigo.Width = 0.87!
        '
        'tbNumero
        '
        Me.tbNumero.Height = 0.2!
        Me.tbNumero.Left = 1.308!
        Me.tbNumero.Name = "tbNumero"
        Me.tbNumero.Style = "ddo-char-set: 1; font-size: 7pt; font-family: Tahoma"
        Me.tbNumero.Text = "25.5"
        Me.tbNumero.Top = 0.0!
        Me.tbNumero.Width = 0.2559055!
        '
        'tbConcepto
        '
        Me.tbConcepto.CanGrow = False
        Me.tbConcepto.Height = 0.1574803!
        Me.tbConcepto.Left = 0.2559055!
        Me.tbConcepto.MultiLine = False
        Me.tbConcepto.Name = "tbConcepto"
        Me.tbConcepto.Style = "ddo-char-set: 0; font-size: 8.25pt; font-family: Tahoma"
        Me.tbConcepto.Text = "Concepto"
        Me.tbConcepto.Top = 0.2987205!
        Me.tbConcepto.Visible = False
        Me.tbConcepto.Width = 1.712599!
        '
        'tbPUnitario
        '
        Me.tbPUnitario.Height = 0.2!
        Me.tbPUnitario.Left = 1.574803!
        Me.tbPUnitario.Name = "tbPUnitario"
        Me.tbPUnitario.OutputFormat = resources.GetString("tbPUnitario.OutputFormat")
        Me.tbPUnitario.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; font-family: Tahoma"
        Me.tbPUnitario.Text = "$99,999"
        Me.tbPUnitario.Top = 0.0!
        Me.tbPUnitario.Width = 0.511811!
        '
        'tbTotal
        '
        Me.tbTotal.Height = 0.2!
        Me.tbTotal.Left = 2.125984!
        Me.tbTotal.Name = "tbTotal"
        Me.tbTotal.OutputFormat = resources.GetString("tbTotal.OutputFormat")
        Me.tbTotal.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; font-family: Tahoma"
        Me.tbTotal.Text = "$999,999"
        Me.tbTotal.Top = 0.002460629!
        Me.tbTotal.Width = 0.6299213!
        '
        'tbCantidad
        '
        Me.tbCantidad.Height = 0.2!
        Me.tbCantidad.Left = 0.2559055!
        Me.tbCantidad.Name = "tbCantidad"
        Me.tbCantidad.OutputFormat = resources.GetString("tbCantidad.OutputFormat")
        Me.tbCantidad.Style = "ddo-char-set: 1; text-align: left; font-size: 7pt; font-family: Tahoma"
        Me.tbCantidad.Text = "99"
        Me.tbCantidad.Top = 0.0!
        Me.tbCantidad.Width = 0.1574803!
        '
        'ReportHeader
        '
        Me.ReportHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.tbNombre, Me.tbFactura, Me.tbDomicilio, Me.tbLugarFecha, Me.lblLeyendaPago, Me.tbTipoVenta, Me.lblCaja, Me.Label13, Me.LblDomTienda, Me.LblTelefono, Me.LblLocaliz, Me.Label16, Me.Label8, Me.Label9, Me.Label10, Me.Label11, Me.Label12, Me.Label17, Me.Label19, Me.LblCopia, Me.txtDomTienda, Me.TxtTienda, Me.TxtBxNCFolio, Me.Label35, Me.txtInfoSuc})
        Me.ReportHeader.Height = 4.177083!
        Me.ReportHeader.Name = "ReportHeader"
        '
        'tbNombre
        '
        Me.tbNombre.Height = 0.1574803!
        Me.tbNombre.Left = 0.2559055!
        Me.tbNombre.Name = "tbNombre"
        Me.tbNombre.Style = "ddo-char-set: 0; font-weight: bold; font-size: 9pt; font-family: Tahoma"
        Me.tbNombre.Text = "Nombre"
        Me.tbNombre.Top = 3.54101!
        Me.tbNombre.Width = 2.46063!
        '
        'tbFactura
        '
        Me.tbFactura.Height = 0.1574803!
        Me.tbFactura.Left = 1.574803!
        Me.tbFactura.Name = "tbFactura"
        Me.tbFactura.Style = "ddo-char-set: 0; text-align: left; font-weight: normal; font-size: 6.75pt; font-f" & _
    "amily: Tahoma; vertical-align: middle"
        Me.tbFactura.Text = "FACT"
        Me.tbFactura.Top = 2.678642!
        Me.tbFactura.Width = 1.102362!
        '
        'tbDomicilio
        '
        Me.tbDomicilio.Height = 0.1574802!
        Me.tbDomicilio.Left = 0.2559055!
        Me.tbDomicilio.Name = "tbDomicilio"
        Me.tbDomicilio.Style = "ddo-char-set: 0; font-size: 9pt; font-family: Tahoma"
        Me.tbDomicilio.Text = "Domicilio"
        Me.tbDomicilio.Top = 3.740977!
        Me.tbDomicilio.Width = 2.440945!
        '
        'tbLugarFecha
        '
        Me.tbLugarFecha.Height = 0.15748!
        Me.tbLugarFecha.Left = 0.2559055!
        Me.tbLugarFecha.Name = "tbLugarFecha"
        Me.tbLugarFecha.Style = "ddo-char-set: 0; font-size: 9pt; font-family: Tahoma"
        Me.tbLugarFecha.Text = "Lugar Fecha"
        Me.tbLugarFecha.Top = 3.341043!
        Me.tbLugarFecha.Width = 2.46063!
        '
        'lblLeyendaPago
        '
        Me.lblLeyendaPago.Height = 0.1860237!
        Me.lblLeyendaPago.HyperLink = Nothing
        Me.lblLeyendaPago.Left = 0.25!
        Me.lblLeyendaPago.Name = "lblLeyendaPago"
        Me.lblLeyendaPago.Style = "ddo-char-set: 1; text-decoration: underline; text-align: center; font-weight: nor" & _
    "mal; font-size: 8.25pt; font-family: Tahoma"
        Me.lblLeyendaPago.Text = "_____Pago hecho en una sola exhibición_____"
        Me.lblLeyendaPago.Top = 3.9875!
        Me.lblLeyendaPago.Width = 2.440945!
        '
        'tbTipoVenta
        '
        Me.tbTipoVenta.Height = 0.15748!
        Me.tbTipoVenta.Left = 0.2559054!
        Me.tbTipoVenta.Name = "tbTipoVenta"
        Me.tbTipoVenta.Style = "ddo-char-set: 0; font-size: 9pt; font-family: Tahoma"
        Me.tbTipoVenta.Text = "TipoVenta"
        Me.tbTipoVenta.Top = 3.141076!
        Me.tbTipoVenta.Width = 1.5625!
        '
        'lblCaja
        '
        Me.lblCaja.Height = 0.2450793!
        Me.lblCaja.HyperLink = Nothing
        Me.lblCaja.Left = 0.2559055!
        Me.lblCaja.Name = "lblCaja"
        Me.lblCaja.Style = "ddo-char-set: 0; font-weight: normal; font-size: 9pt; font-family: Tahoma; vertic" & _
    "al-align: middle"
        Me.lblCaja.Text = "CAJA"
        Me.lblCaja.Top = 2.879921!
        Me.lblCaja.Width = 1.25!
        '
        'Label13
        '
        Me.Label13.Height = 0.3213585!
        Me.Label13.HyperLink = Nothing
        Me.Label13.Left = 0.2559054!
        Me.Label13.Name = "Label13"
        Me.Label13.Style = "font-size: 9pt; font-family: Tahoma"
        Me.Label13.Text = "APLICA A NOTA DE VENTA: "
        Me.Label13.Top = 2.553642!
        Me.Label13.Width = 1.240158!
        '
        'LblDomTienda
        '
        Me.LblDomTienda.Height = 0.1574803!
        Me.LblDomTienda.HyperLink = Nothing
        Me.LblDomTienda.Left = 2.693898!
        Me.LblDomTienda.Name = "LblDomTienda"
        Me.LblDomTienda.Style = "text-align: center; font-size: 8.25pt; font-family: Tahoma"
        Me.LblDomTienda.Text = "Direccion"
        Me.LblDomTienda.Top = 1.954724!
        Me.LblDomTienda.Visible = False
        Me.LblDomTienda.Width = 2.362204!
        '
        'LblTelefono
        '
        Me.LblTelefono.Height = 0.1574803!
        Me.LblTelefono.HyperLink = Nothing
        Me.LblTelefono.Left = 2.693405!
        Me.LblTelefono.Name = "LblTelefono"
        Me.LblTelefono.Style = "text-align: center; font-size: 8.25pt; font-family: Tahoma"
        Me.LblTelefono.Text = "Telefono"
        Me.LblTelefono.Top = 1.482283!
        Me.LblTelefono.Visible = False
        Me.LblTelefono.Width = 2.362205!
        '
        'LblLocaliz
        '
        Me.LblLocaliz.Height = 0.1574803!
        Me.LblLocaliz.HyperLink = Nothing
        Me.LblLocaliz.Left = 2.693898!
        Me.LblLocaliz.Name = "LblLocaliz"
        Me.LblLocaliz.Style = "text-align: center; font-size: 8.25pt; font-family: Tahoma"
        Me.LblLocaliz.Text = "Ciudad Estado"
        Me.LblLocaliz.Top = 1.797244!
        Me.LblLocaliz.Visible = False
        Me.LblLocaliz.Width = 2.362204!
        '
        'Label16
        '
        Me.Label16.Height = 0.1574803!
        Me.Label16.HyperLink = Nothing
        Me.Label16.Left = 0.3184055!
        Me.Label16.Name = "Label16"
        Me.Label16.Style = "text-align: center; font-weight: bold; font-size: 9pt; font-family: Tahoma"
        Me.Label16.Text = "SUCURSAL:"
        Me.Label16.Top = 1.009842!
        Me.Label16.Width = 2.362205!
        '
        'Label8
        '
        Me.Label8.Height = 0.1574803!
        Me.Label8.HyperLink = Nothing
        Me.Label8.Left = 0.3809055!
        Me.Label8.Name = "Label8"
        Me.Label8.Style = "text-align: center; font-size: 9pt; font-family: Tahoma"
        Me.Label8.Text = "COMERCIAL D'PORTENIS, S.A. DE C.V."
        Me.Label8.Top = 0.1358267!
        Me.Label8.Width = 2.283465!
        '
        'Label9
        '
        Me.Label9.Height = 0.1437008!
        Me.Label9.HyperLink = Nothing
        Me.Label9.Left = 0.3809055!
        Me.Label9.Name = "Label9"
        Me.Label9.Style = "text-align: center; font-size: 9pt; font-family: Tahoma"
        Me.Label9.Text = "M. OCAMPO 1005 CENTRO"
        Me.Label9.Top = 0.293307!
        Me.Label9.Width = 2.283465!
        '
        'Label10
        '
        Me.Label10.Height = 0.1437008!
        Me.Label10.HyperLink = Nothing
        Me.Label10.Left = 0.3809055!
        Me.Label10.Name = "Label10"
        Me.Label10.Style = "text-align: center; font-size: 9pt; font-family: Tahoma"
        Me.Label10.Text = "C.P. 82000 TEL. 6699155300"
        Me.Label10.Top = 0.4370076!
        Me.Label10.Width = 2.283465!
        '
        'Label11
        '
        Me.Label11.Height = 0.1437008!
        Me.Label11.HyperLink = Nothing
        Me.Label11.Left = 0.3809055!
        Me.Label11.Name = "Label11"
        Me.Label11.Style = "text-align: center; font-size: 9pt; font-family: Tahoma"
        Me.Label11.Text = "R.F.C. CDP-950126-9M5"
        Me.Label11.Top = 0.5807083!
        Me.Label11.Width = 2.283465!
        '
        'Label12
        '
        Me.Label12.Height = 0.1437008!
        Me.Label12.HyperLink = Nothing
        Me.Label12.Left = 0.3809055!
        Me.Label12.Name = "Label12"
        Me.Label12.Style = "text-align: center; font-size: 9pt; font-family: Tahoma"
        Me.Label12.Text = "MAZATLAN, SINALOA, MEXICO"
        Me.Label12.Top = 0.7244098!
        Me.Label12.Width = 2.283465!
        '
        'Label17
        '
        Me.Label17.Height = 0.1574803!
        Me.Label17.HyperLink = Nothing
        Me.Label17.Left = 0.3809055!
        Me.Label17.Name = "Label17"
        Me.Label17.Style = "text-align: center; font-weight: bold; font-size: 9pt; font-family: Tahoma"
        Me.Label17.Text = "MATRIZ:"
        Me.Label17.Top = -0.02165353!
        Me.Label17.Width = 2.283465!
        '
        'Label19
        '
        Me.Label19.Height = 0.1574803!
        Me.Label19.HyperLink = Nothing
        Me.Label19.Left = 2.693405!
        Me.Label19.Name = "Label19"
        Me.Label19.Style = "text-align: center; font-size: 8.25pt; font-family: Tahoma"
        Me.Label19.Text = "R.F.C. CDP-950126-9M5"
        Me.Label19.Top = 1.639764!
        Me.Label19.Visible = False
        Me.Label19.Width = 2.362204!
        '
        'LblCopia
        '
        Me.LblCopia.Height = 0.1574805!
        Me.LblCopia.HyperLink = Nothing
        Me.LblCopia.Left = 0.2559054!
        Me.LblCopia.Name = "LblCopia"
        Me.LblCopia.Style = "text-align: center; font-size: 8.25pt; font-family: Tahoma; vertical-align: top"
        Me.LblCopia.Text = "FOLIO:"
        Me.LblCopia.Top = 2.345965!
        Me.LblCopia.Width = 1.098425!
        '
        'txtDomTienda
        '
        Me.txtDomTienda.Height = 0.1574803!
        Me.txtDomTienda.Left = 2.693898!
        Me.txtDomTienda.Name = "txtDomTienda"
        Me.txtDomTienda.Style = "text-align: center; font-size: 8.25pt; font-family: Tahoma"
        Me.txtDomTienda.Text = "Direccion"
        Me.txtDomTienda.Top = 1.324803!
        Me.txtDomTienda.Visible = False
        Me.txtDomTienda.Width = 2.362205!
        '
        'TxtTienda
        '
        Me.TxtTienda.Height = 0.1574803!
        Me.TxtTienda.Left = 2.693898!
        Me.TxtTienda.Name = "TxtTienda"
        Me.TxtTienda.Style = "text-align: center; font-size: 8.25pt; font-family: Tahoma; vertical-align: top"
        Me.TxtTienda.Text = "Tienda"
        Me.TxtTienda.Top = 1.167323!
        Me.TxtTienda.Visible = False
        Me.TxtTienda.Width = 2.362205!
        '
        'TxtBxNCFolio
        '
        Me.TxtBxNCFolio.Height = 0.1574803!
        Me.TxtBxNCFolio.Left = 1.5625!
        Me.TxtBxNCFolio.Name = "TxtBxNCFolio"
        Me.TxtBxNCFolio.Style = "ddo-char-set: 0; text-align: left; font-weight: normal; font-size: 9pt; font-fami" & _
    "ly: Tahoma"
        Me.TxtBxNCFolio.Text = "NC"
        Me.TxtBxNCFolio.Top = 2.375!
        Me.TxtBxNCFolio.Width = 1.102363!
        '
        'Label35
        '
        Me.Label35.Height = 0.2116142!
        Me.Label35.HyperLink = Nothing
        Me.Label35.Left = 0.4!
        Me.Label35.Name = "Label35"
        Me.Label35.Style = "text-align: center; font-weight: bold; font-size: 12pt; font-family: Tahoma"
        Me.Label35.Text = "NOTA DE CREDITO"
        Me.Label35.Top = 2.1!
        Me.Label35.Width = 2.283465!
        '
        'txtInfoSuc
        '
        Me.txtInfoSuc.Height = 0.157!
        Me.txtInfoSuc.Left = 0.318!
        Me.txtInfoSuc.Name = "txtInfoSuc"
        Me.txtInfoSuc.Style = "ddo-char-set: 1; text-align: center; font-size: 8.25pt; font-family: Tahoma"
        Me.txtInfoSuc.Text = "InfoSuc"
        Me.txtInfoSuc.Top = 1.25!
        Me.txtInfoSuc.Width = 2.362!
        '
        'ReportFooter
        '
        Me.ReportFooter.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label27, Me.Label29, Me.Label25, Me.Label24, Me.Label23, Me.Shape2, Me.tbSubTotal, Me.tbPlayer, Me.Label1, Me.tbTotalLetras, Me.Label18, Me.Label22, Me.TxtSubTotIva, Me.Label26, Me.Label28, Me.Label30, Me.Label31, Me.Label32, Me.Label33, Me.Label34, Me.Line1, Me.Shape1, Me.TextBox1})
        Me.ReportFooter.Height = 4.958333!
        Me.ReportFooter.Name = "ReportFooter"
        '
        'Label27
        '
        Me.Label27.Height = 0.3937008!
        Me.Label27.HyperLink = Nothing
        Me.Label27.Left = 0.3149605!
        Me.Label27.Name = "Label27"
        Me.Label27.Style = "font-weight: bold; font-size: 12pt; font-family: Arial"
        Me.Label27.Text = "S H C P"
        Me.Label27.Top = 1.938484!
        Me.Label27.Width = 0.3937007!
        '
        'Label29
        '
        Me.Label29.Height = 0.3149607!
        Me.Label29.HyperLink = Nothing
        Me.Label29.Left = 0.2362203!
        Me.Label29.Name = "Label29"
        Me.Label29.Style = "text-align: center; font-size: 9pt; font-family: Tahoma"
        Me.Label29.Text = "SUBSECRETARIA DE INGRESOS"
        Me.Label29.Top = 2.929626!
        Me.Label29.Width = 1.496063!
        '
        'Label25
        '
        Me.Label25.Height = 0.1574802!
        Me.Label25.HyperLink = Nothing
        Me.Label25.Left = 0.7391729!
        Me.Label25.Name = "Label25"
        Me.Label25.Style = "text-align: center; font-size: 8.25pt; font-family: Tahoma"
        Me.Label25.Text = "C4907687"
        Me.Label25.Top = 2.269685!
        Me.Label25.Width = 0.7874014!
        '
        'Label24
        '
        Me.Label24.Height = 0.1574807!
        Me.Label24.HyperLink = Nothing
        Me.Label24.Left = 0.7386813!
        Me.Label24.Name = "Label24"
        Me.Label24.Style = "text-align: center; font-size: 8.25pt; font-family: Tahoma"
        Me.Label24.Text = "D1559715"
        Me.Label24.Top = 2.112204!
        Me.Label24.Width = 0.7874014!
        '
        'Label23
        '
        Me.Label23.Height = 0.1574798!
        Me.Label23.HyperLink = Nothing
        Me.Label23.Left = 0.7386813!
        Me.Label23.Name = "Label23"
        Me.Label23.Style = "text-align: center; font-size: 8.25pt; font-family: Tahoma"
        Me.Label23.Text = "FOLIO"
        Me.Label23.Top = 1.954724!
        Me.Label23.Width = 0.7874014!
        '
        'Shape2
        '
        Me.Shape2.Height = 0.3937007!
        Me.Shape2.Left = 0.2677169!
        Me.Shape2.Name = "Shape2"
        Me.Shape2.RoundingRadius = 9.999999!
        Me.Shape2.Top = 1.938484!
        Me.Shape2.Width = 0.3937007!
        '
        'tbSubTotal
        '
        Me.tbSubTotal.Height = 0.178642!
        Me.tbSubTotal.Left = 1.732783!
        Me.tbSubTotal.Name = "tbSubTotal"
        Me.tbSubTotal.OutputFormat = resources.GetString("tbSubTotal.OutputFormat")
        Me.tbSubTotal.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; font-family: Tahoma"
        Me.tbSubTotal.Text = Nothing
        Me.tbSubTotal.Top = 0.493602!
        Me.tbSubTotal.Width = 0.944382!
        '
        'tbPlayer
        '
        Me.tbPlayer.Height = 0.2!
        Me.tbPlayer.Left = 0.9330708!
        Me.tbPlayer.Name = "tbPlayer"
        Me.tbPlayer.Style = "ddo-char-set: 0; text-align: left; font-weight: normal; font-size: 8.25pt; font-f" & _
    "amily: Tahoma"
        Me.tbPlayer.Text = Nothing
        Me.tbPlayer.Top = 0.7810042!
        Me.tbPlayer.Width = 0.5625!
        '
        'Label1
        '
        Me.Label1.Height = 0.1786415!
        Me.Label1.HyperLink = Nothing
        Me.Label1.Left = 0.2559055!
        Me.Label1.Name = "Label1"
        Me.Label1.Style = "text-align: right; font-weight: normal; font-size: 8.25pt; font-family: Tahoma"
        Me.Label1.Text = "PLAYER:"
        Me.Label1.Top = 0.7819882!
        Me.Label1.Width = 0.5!
        '
        'tbTotalLetras
        '
        Me.tbTotalLetras.Height = 0.2!
        Me.tbTotalLetras.Left = 0.2559055!
        Me.tbTotalLetras.Name = "tbTotalLetras"
        Me.tbTotalLetras.Style = "font-weight: normal; font-size: 8.25pt; font-family: Tahoma"
        Me.tbTotalLetras.Text = Nothing
        Me.tbTotalLetras.Top = 0.222441!
        Me.tbTotalLetras.Width = 2.440945!
        '
        'Label18
        '
        Me.Label18.Height = 0.9286423!
        Me.Label18.HyperLink = Nothing
        Me.Label18.Left = 1.732283!
        Me.Label18.Name = "Label18"
        Me.Label18.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; font-family: Tahoma"
        Me.Label18.Text = "CONTRIBUYENTE AUTORIZADO A IMPRIMIR SUS PROPIOS COM- PROBANTES FISCALES"
        Me.Label18.Top = 3.434547!
        Me.Label18.Width = 1.023622!
        '
        'Label22
        '
        Me.Label22.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label22.Height = 0.03149606!
        Me.Label22.HyperLink = Nothing
        Me.Label22.Left = 0.2559055!
        Me.Label22.Name = "Label22"
        Me.Label22.Style = "font-size: 9.75pt; font-family: Tahoma"
        Me.Label22.Text = ""
        Me.Label22.Top = 0.01968504!
        Me.Label22.Width = 2.5!
        '
        'TxtSubTotIva
        '
        Me.TxtSubTotIva.Height = 0.1574802!
        Me.TxtSubTotIva.Left = 0.3149606!
        Me.TxtSubTotIva.Name = "TxtSubTotIva"
        Me.TxtSubTotIva.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; font-family: Tahoma"
        Me.TxtSubTotIva.Text = Nothing
        Me.TxtSubTotIva.Top = 0.4936024!
        Me.TxtSubTotIva.Width = 1.338583!
        '
        'Label26
        '
        Me.Label26.Height = 1.259842!
        Me.Label26.HyperLink = Nothing
        Me.Label26.Left = 1.732283!
        Me.Label26.Name = "Label26"
        Me.Label26.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; font-family: Tahoma"
        Me.Label26.Text = "LA REPRODUCION NO AUTORIZADA DE ESTE COMPRO- BANTE CONSTITU- YE UN DELITO EN LOS " & _
    "TERMINOS DE LAS DISPOSICIO- NES FISCALES"
        Me.Label26.Top = 1.938484!
        Me.Label26.Width = 1.023622!
        '
        'Label28
        '
        Me.Label28.Height = 0.4724407!
        Me.Label28.HyperLink = Nothing
        Me.Label28.Left = 0.2716537!
        Me.Label28.Name = "Label28"
        Me.Label28.Style = "text-align: center; font-size: 9pt; font-family: Tahoma"
        Me.Label28.Text = "SECRETARIA DE HACIENDA Y CREDITO PUBLICO"
        Me.Label28.Top = 2.438484!
        Me.Label28.Width = 1.512303!
        '
        'Label30
        '
        Me.Label30.Height = 0.3149607!
        Me.Label30.HyperLink = Nothing
        Me.Label30.Left = 0.2362203!
        Me.Label30.Name = "Label30"
        Me.Label30.Style = "text-align: center; font-size: 9pt; font-family: Tahoma"
        Me.Label30.Text = "CEDULA DE IDEN- TIFICACION FISCAL"
        Me.Label30.Top = 3.244587!
        Me.Label30.Width = 1.496063!
        '
        'Label31
        '
        Me.Label31.Height = 0.1437008!
        Me.Label31.HyperLink = Nothing
        Me.Label31.Left = 0.2362203!
        Me.Label31.Name = "Label31"
        Me.Label31.Style = "text-align: center; font-size: 9pt; font-family: Tahoma"
        Me.Label31.Text = "CDP-950126-9M5"
        Me.Label31.Top = 3.559547!
        Me.Label31.Width = 1.496063!
        '
        'Label32
        '
        Me.Label32.Height = 0.314961!
        Me.Label32.HyperLink = Nothing
        Me.Label32.Left = 0.3149605!
        Me.Label32.Name = "Label32"
        Me.Label32.Style = "text-align: center; font-size: 9pt; font-family: Tahoma"
        Me.Label32.Text = "COMERCIAL D PORTENIS, S.A. DE C.V."
        Me.Label32.Top = 3.717028!
        Me.Label32.Width = 1.417323!
        '
        'Label33
        '
        Me.Label33.Height = 0.3149605!
        Me.Label33.HyperLink = Nothing
        Me.Label33.Left = 0.4724403!
        Me.Label33.Name = "Label33"
        Me.Label33.Style = "text-align: center; font-size: 9pt; font-family: Tahoma"
        Me.Label33.Text = "22/03/95 vhjm8hjL2H"
        Me.Label33.Top = 4.064468!
        Me.Label33.Width = 1.023622!
        '
        'Label34
        '
        Me.Label34.Height = 0.1574802!
        Me.Label34.HyperLink = Nothing
        Me.Label34.Left = 1.254484!
        Me.Label34.Name = "Label34"
        Me.Label34.Style = "font-size: 11.25pt"
        Me.Label34.Text = "Firma"
        Me.Label34.Top = 1.671807!
        Me.Label34.Width = 0.472441!
        '
        'Line1
        '
        Me.Line1.Height = 0.0!
        Me.Line1.Left = 0.3069444!
        Me.Line1.LineWeight = 1.0!
        Me.Line1.Name = "Line1"
        Me.Line1.Top = 1.531944!
        Me.Line1.Width = 2.358!
        Me.Line1.X1 = 2.664944!
        Me.Line1.X2 = 0.3069444!
        Me.Line1.Y1 = 1.531944!
        Me.Line1.Y2 = 1.531944!
        '
        'Shape1
        '
        Me.Shape1.Height = 2.480315!
        Me.Shape1.Left = 0.2677169!
        Me.Shape1.Name = "Shape1"
        Me.Shape1.RoundingRadius = 9.999999!
        Me.Shape1.Top = 1.938484!
        Me.Shape1.Width = 1.437008!
        '
        'TextBox1
        '
        Me.TextBox1.Height = 0.15748!
        Me.TextBox1.Left = 0.3809055!
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Style = "ddo-char-set: 0; text-align: center; font-size: 11.25pt; font-family: Tahoma; ver" & _
    "tical-align: top"
        Me.TextBox1.Text = "DEVOLUCIÓN DE MERCANCIA"
        Me.TextBox1.Top = 0.02854299!
        Me.TextBox1.Width = 2.21063!
        '
        'PageHeader
        '
        Me.PageHeader.Height = 0.0!
        Me.PageHeader.Name = "PageHeader"
        '
        'PageFooter
        '
        Me.PageFooter.Height = 0.0!
        Me.PageFooter.Name = "PageFooter"
        '
        'ActRptNotaCredito
        '
        Me.MasterReport = False
        Me.PageSettings.DefaultPaperSize = False
        Me.PageSettings.Margins.Bottom = 0.0!
        Me.PageSettings.Margins.Left = 0.0!
        Me.PageSettings.Margins.Right = 0.0!
        Me.PageSettings.Margins.Top = 0.0!
        Me.PageSettings.PaperHeight = 11.69028!
        Me.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Custom
        Me.PageSettings.PaperName = "Custom paper"
        Me.PageSettings.PaperWidth = 2.979861!
        Me.PrintWidth = 2.77!
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
        CType(Me.tbCodigo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbNumero, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbConcepto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbPUnitario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbCantidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbNombre, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbFactura, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbDomicilio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbLugarFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblLeyendaPago, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbTipoVenta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblCaja, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblDomTienda, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblTelefono, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblLocaliz, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label19, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblCopia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDomTienda, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtTienda, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtBxNCFolio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label35, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtInfoSuc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label27, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label29, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label25, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label24, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label23, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbSubTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbPlayer, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbTotalLetras, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label22, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtSubTotIva, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label26, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label28, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label30, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label31, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label32, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label33, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label34, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

#End Region

    Private Function Letras(ByVal numero As String) As String
        '********Declara variables de tipo cadena************
        Dim palabras, entero, dec, flag As String

        '********Declara variables de tipo entero***********
        Dim num, x, y As Integer

        flag = "N"

        '**********Número Negativo***********
        If Mid(numero, 1, 1) = "-" Then
            numero = Mid(numero, 2, numero.ToString.Length - 1).ToString
            palabras = "menos "
        End If

        '**********Si tiene ceros a la izquierda*************
        For x = 1 To numero.ToString.Length
            If Mid(numero, 1, 1) = "0" Then
                numero = Trim(Mid(numero, 2, numero.ToString.Length).ToString)
                If Trim(numero.ToString.Length) = 0 Then palabras = ""
            Else
                Exit For
            End If
        Next

        '*********Dividir parte entera y decimal************
        For y = 1 To Len(numero)
            If Mid(numero, y, 1) = "." Then
                flag = "S"
            Else
                If flag = "N" Then
                    entero = entero + Mid(numero, y, 1)
                Else
                    dec = dec + Mid(numero, y, 1)
                End If
            End If
        Next y

        If Len(dec) = 1 Then dec = dec & "0"

        '**********proceso de conversión***********
        flag = "N"

        If Val(numero) <= 999999999 Then
            For y = Len(entero) To 1 Step -1
                num = Len(entero) - (y - 1)
                Select Case y
                    Case 3, 6, 9
                        '**********Asigna las palabras para las centenas***********
                        Select Case Mid(entero, num, 1)
                            Case "1"
                                If Mid(entero, num + 1, 1) = "0" And Mid(entero, num + 2, 1) = "0" Then
                                    palabras = palabras & "cien "
                                Else
                                    palabras = palabras & "ciento "
                                End If
                            Case "2"
                                palabras = palabras & "doscientos "
                            Case "3"
                                palabras = palabras & "trescientos "
                            Case "4"
                                palabras = palabras & "cuatrocientos "
                            Case "5"
                                palabras = palabras & "quinientos "
                            Case "6"
                                palabras = palabras & "seiscientos "
                            Case "7"
                                palabras = palabras & "setecientos "
                            Case "8"
                                palabras = palabras & "ochocientos "
                            Case "9"
                                palabras = palabras & "novecientos "
                        End Select
                    Case 2, 5, 8
                        '*********Asigna las palabras para las decenas************
                        Select Case Mid(entero, num, 1)
                            Case "1"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    flag = "S"
                                    palabras = palabras & "diez "
                                End If
                                If Mid(entero, num + 1, 1) = "1" Then
                                    flag = "S"
                                    palabras = palabras & "once "
                                End If
                                If Mid(entero, num + 1, 1) = "2" Then
                                    flag = "S"
                                    palabras = palabras & "doce "
                                End If
                                If Mid(entero, num + 1, 1) = "3" Then
                                    flag = "S"
                                    palabras = palabras & "trece "
                                End If
                                If Mid(entero, num + 1, 1) = "4" Then
                                    flag = "S"
                                    palabras = palabras & "catorce "
                                End If
                                If Mid(entero, num + 1, 1) = "5" Then
                                    flag = "S"
                                    palabras = palabras & "quince "
                                End If
                                If Mid(entero, num + 1, 1) > "5" Then
                                    flag = "N"
                                    palabras = palabras & "dieci"
                                End If
                            Case "2"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "veinte "
                                    flag = "S"
                                Else
                                    palabras = palabras & "veinti"
                                    flag = "N"
                                End If
                            Case "3"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "treinta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "treinta y "
                                    flag = "N"
                                End If
                            Case "4"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "cuarenta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "cuarenta y "
                                    flag = "N"
                                End If
                            Case "5"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "cincuenta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "cincuenta y "
                                    flag = "N"
                                End If
                            Case "6"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "sesenta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "sesenta y "
                                    flag = "N"
                                End If
                            Case "7"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "setenta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "setenta y "
                                    flag = "N"
                                End If
                            Case "8"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "ochenta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "ochenta y "
                                    flag = "N"
                                End If
                            Case "9"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "noventa "
                                    flag = "S"
                                Else
                                    palabras = palabras & "noventa y "
                                    flag = "N"
                                End If
                        End Select
                    Case 1, 4, 7
                        '*********Asigna las palabras para las unidades*********
                        Select Case Mid(entero, num, 1)
                            Case "1"
                                If flag = "N" Then
                                    If y = 1 Then
                                        palabras = palabras & "uno "
                                    Else
                                        palabras = palabras & "un "
                                    End If
                                End If
                            Case "2"
                                If flag = "N" Then palabras = palabras & "dos "
                            Case "3"
                                If flag = "N" Then palabras = palabras & "tres "
                            Case "4"
                                If flag = "N" Then palabras = palabras & "cuatro "
                            Case "5"
                                If flag = "N" Then palabras = palabras & "cinco "
                            Case "6"
                                If flag = "N" Then palabras = palabras & "seis "
                            Case "7"
                                If flag = "N" Then palabras = palabras & "siete "
                            Case "8"
                                If flag = "N" Then palabras = palabras & "ocho "
                            Case "9"
                                If flag = "N" Then palabras = palabras & "nueve "
                        End Select
                End Select

                '***********Asigna la palabra mil***************
                If y = 4 Then
                    If Mid(entero, 6, 1) <> "0" Or Mid(entero, 5, 1) <> "0" Or Mid(entero, 4, 1) <> "0" Or _
                    (Mid(entero, 6, 1) = "0" And Mid(entero, 5, 1) = "0" And Mid(entero, 4, 1) = "0" And _
                    Len(entero) <= 6) Then palabras = palabras & "mil "
                End If

                '**********Asigna la palabra millón*************
                If y = 7 Then
                    If Len(entero) = 7 And Mid(entero, 1, 1) = "1" Then
                        palabras = palabras & "millón "
                    Else
                        palabras = palabras & "millones "
                    End If
                End If
            Next y

            '**********Une la parte entera y la parte decimal*************
            If dec <> "" Then
                Letras = palabras & " pesos con " & dec & "/100 M.N."
            Else
                Letras = palabras
            End If
        Else
            Letras = ""
        End If
    End Function

    Private Sub ActRptNotaCredito_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.ReportStart
        If Me.boolImprimirCedula = False Then

            'Movemos hacia la derecha los datos generales 
            Me.Label17.Left = 3.5
            Me.Label8.Left = 3.5
            Me.Label9.Left = 3.5
            Me.Label10.Left = 3.5
            Me.Label11.Left = 3.5
            Me.Label12.Left = 3.5

            'Ponemos invisibles los datos generales
            Me.Label17.Visible = False
            Me.Label8.Visible = False
            Me.Label9.Visible = False
            Me.Label10.Visible = False
            Me.Label11.Visible = False
            Me.Label12.Visible = False

            'Subimos los controles del page header
            Me.Label16.Top = 0.01
            'Me.TxtTienda.Top = 0.167
            'Me.txtDomTienda.Top = 0.325
            'Me.LblTelefono.Top = 0.482
            'Me.Label19.Top = 0.64
            'Me.LblLocaliz.Top = 0.797
            'Me.LblDomTienda.Top = 0.955
            'Me.LblCopia.Top = 1.346
            'Me.Label35.Top = 1.1
            'Me.TxtBxNCFolio.Top = 1.366
            'Me.Label13.Top = 1.554
            'Me.tbFactura.Top = 1.512
            'Me.lblCaja.Top = 1.755
            'Me.tbTipoVenta.Top = 1.954
            'Me.tbLugarFecha.Top = 2.154
            'Me.tbNombre.Top = 2.354
            'Me.tbDomicilio.Top = 2.553
            'Me.lblLeyendaPago.Top = 2.8
            'Me.ReportHeader.Height = 3.021
            Me.txtInfoSuc.Top = 0.167
            Me.LblCopia.Top = 0.746
            Me.Label35.Top = 0.5
            Me.TxtBxNCFolio.Top = 0.766
            Me.Label13.Top = 0.954
            Me.tbFactura.Top = 0.912
            Me.lblCaja.Top = 1.155
            Me.tbTipoVenta.Top = 1.354
            Me.tbLugarFecha.Top = 1.554
            Me.tbNombre.Top = 1.754
            Me.tbDomicilio.Top = 1.953
            Me.lblLeyendaPago.Top = 2.2
            Me.ReportHeader.Height = 2.421

            'Movemos los datos fiscales hacia la derecha
            Me.Label26.Left = 5.17
            Me.Label18.Left = 5.17
            Me.Shape2.Left = 3.733
            Me.Shape1.Left = 3.733
            Me.Label27.Left = 3.733
            Me.Label23.Left = 4.176
            Me.Label24.Left = 4.176
            Me.Label25.Left = 4.177
            Me.Label28.Left = 3.752
            Me.Label29.Left = 3.674
            Me.Label30.Left = 3.674
            Me.Label31.Left = 3.674
            Me.Label32.Left = 3.752
            Me.Label33.Left = 3.91

            'Ponemos invisibles los datos fiscales
            Me.Label26.Visible = False
            Me.Label18.Visible = False
            Me.Shape2.Visible = False
            Me.Shape1.Visible = False
            Me.Label27.Visible = False
            Me.Label23.Visible = False
            Me.Label24.Visible = False
            Me.Label25.Visible = False
            Me.Label28.Visible = False
            Me.Label29.Visible = False
            Me.Label30.Visible = False
            Me.Label31.Visible = False
            Me.Label32.Visible = False
            Me.Label33.Visible = False

            'Seteo el alto del ReporteFooter
            Me.ReportFooter.Height = 2

        End If
    End Sub

    Private Sub Detail_Format(sender As Object, e As System.EventArgs) Handles Detail.Format
        tbCodigo.Text = CStr(CLng(tbCodigo.Text.Trim()))
    End Sub
End Class
