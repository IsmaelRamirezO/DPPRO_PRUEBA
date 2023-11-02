Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Imports DportenisPro.DPTienda.ApplicationUnits.Facturas
Imports DportenisPro.DPTienda.ApplicationUnits.FacturasCorrida
Imports DportenisPro.DPTienda.ApplicationUnits.Clientes
Imports DportenisPro.DPTienda.ApplicationUnits.AvisosFacturaAU
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes
Imports DportenisPro.DPTienda.ApplicationUnits.FacturasFormaPago
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU

Public Class rptFacturacionEC
    Inherits DataDynamics.ActiveReports.ActiveReport

    'Dim oFacturaMgr As FacturaManager
    'Dim oFactura As Factura

    'Dim oFacturaCorridaMgr As FacturaCorridaManager
    'Dim oFacturaCorrida As FacturaCorrida

    Dim oClientesMgr As ClientesManager
    Dim oCliente As Clientes

    Dim oAvisosFacturaMgr As AvisosFacturaManager
    Dim oAvisosFactura As AvisosFactura

    'Dim oReporteFormapago As ReporteDetalleFormasPago
    Dim oReporteAvisosFactura As ReporteAvisosFactura

    'Dim oFacturaFormaPago As FacturaFormaPago

    'Dim dsFactura As New DataSet
    'Dim dsFormaPago As New DataSet
    'Dim dsFormaPago2 As New DataSet
    Dim boolImprimirCedula As Boolean = True
    Friend WithEvents txtPagina As DataDynamics.ActiveReports.TextBox
    Dim IVA As Decimal = 0


    Private Sub InicializaObjetos()

        'oFacturaMgr = New FacturaManager(oAppContext)
        'oFactura = oFacturaMgr.Create

        'oFacturaCorridaMgr = New FacturaCorridaManager(oAppContext)
        'oFacturaCorrida = oFacturaCorridaMgr.Create

        oClientesMgr = New ClientesManager(oAppContext)
        oCliente = oClientesMgr.Create

        oAvisosFacturaMgr = New AvisosFacturaManager(oAppContext)
        oAvisosFactura = oAvisosFacturaMgr.Create

        'oFacturaFormaPago = New FacturaFormaPago(oAppContext)

    End Sub

    Public Sub New(ByVal dtDetalleFactura As DataTable, ByVal DatosGenerales As DataTable, ByVal oRowDes As DataRow, ByVal TipoFact As String, ByVal ImprimirCedula As Boolean, _
                   ByVal decIVA As Decimal, ByVal FolioCupon As String, Optional ByVal TipoLeyenda As String = "", Optional ByVal strQuin As Integer = 0, Optional ByVal VersionEcommerce As String = "")

        MyBase.New()
        InitializeComponent()
        InicializaObjetos()
        'oFactura.ClearFields()
        Dim dtDetalle As DataTable
        Dim oRowG As DataRow = DatosGenerales.Rows(0)

        IVA = decIVA
        If oConfigCierreFI.AplicarSurtidoDPStreet = True Then
            Me.txtLeyendaEcommerce.Visible = True
            If VersionEcommerce.Trim() = "DPT" Then
                Me.txtLeyendaEcommerce.Text = oConfigCierreFI.LeyendaDportenis
            ElseIf VersionEcommerce.Trim() = "DPS" Then
                Me.txtLeyendaEcommerce.Text = oConfigCierreFI.LeyendaDPStreet
            End If
        Else
            Me.txtLeyendaEcommerce.Visible = False
        End If
        'If TipoFact = "CANCELACIÓN DE FACTURA" Then
        '    TipoFact = "CANCELACIÓN DE NOTA DE VENTA"
        '    lblCancelacion.Visible = True
        '    Me.tbFCancelacion.Visible = True
        '    Me.lblFactura.Text = "APLICA A NOTA DE VENTA:"
        'Else
        If TipoFact = "FACTURA" Then
            TipoFact = "NOTA DE VENTA"
        ElseIf TipoFact = "COPIA DE FACTURA" Then
            TipoFact = "COPIA DE NOTA DE VENTA"
        End If
        lblCancelacion.Visible = False
        Me.tbFCancelacion.Visible = False
        Me.lblFactura.Text = "FOLIO:"
        'End If
        'oFacturaMgr.LoadInto(oDataRpt.FacturaID, oFactura)
        'oFactura.Detalle = oFacturaCorridaMgr.Load(oDataRpt.FacturaID)

        'Me.DataSource = oFactura.Detalle
        'Me.DataMember = "FacturaDetalle"
        Dim dtTemp As DataTable

        dtDetalle = FormatearTablaDetalle().Clone
        'Me.DataSource = LlenarTablaDetalle(oFactura.Detalle.Tables(0), dtDetalle).Copy
        dtTemp = LlenarTablaDetalle(dtDetalleFactura, dtDetalle).Copy

        Me.tbCantidad.DataField = "Cantidad"
        Me.tbCodigo.DataField = "CodArticulo"
        Me.tbConcepto.DataField = "Descripcion"
        Me.tbNumero.DataField = "Numero"
        Me.tbPUnitario.DataField = "PrecioOferta"
        Me.tbTotal.DataField = "Total"
        Me.tbFCancelacion.Text = "" 'oFactura.FCancelacionSD
        Me.tbDesc.DataField = "Descuento"

        Me.DataSource = SepararArticulos(dtTemp).Copy

        boolImprimirCedula = ImprimirCedula

        If TipoLeyenda <> "" Then
            If TipoLeyenda = "FACTURA" Then
                TipoLeyenda = "NOTA DE VENTA"
            ElseIf TipoLeyenda = "COPIA DE FACTURA" Then
                TipoLeyenda = "COPIA DE NOTA DE VENTA"
            End If
            LblCopia.Text = TipoLeyenda
        Else
            LblCopia.Text = TipoFact
        End If

        'If CStr(oRowG!FolioSAP).Trim = "" Then
        '    tbFactura.Text = CStr(DatosGenerales.Rows(0).Item("FolioFactura")).PadLeft(10, "0")
        '    LblCopia.Text = "NOTA DE VENTA"
        'Else
        tbFactura.Text = CStr(oRowG!FolioSAP).Trim
        'End If

        lblCaja.Text = "CAJA :" & CStr(oRowG!CodCaja).Trim

        tbTipoVenta.Text = CStr(oRowG!TipoVenta)

        Me.lblQuincenas.Visible = False
        Me.lblAPagar.Visible = False

        '--------------------------------------------------------------------------------------------------------------------------------------------
        'Datos de los clientes Solicitante y Destinatario
        '--------------------------------------------------------------------------------------------------------------------------------------------
        Dim strdt As String = ""
        tbDomicilio.Text = ""

        tbNombre.Text = CStr(oRowG!NombreCliente).Trim
        tbNombreDes.Text = CStr(oRowDes!NAME1 & " " & oRowDes!NAME2 & " " & oRowDes!NAME3).Trim
        '--------------------------------------------------------------------------------------------------------------------------------------------
        'DOMICILIO
        '--------------------------------------------------------------------------------------------------------------------------------------------
        strdt = CStr(oRowG!Domicilio).Trim
        If strdt.Trim <> "" Then
            tbDomicilio.Text = strdt & vbNewLine
        End If
        Dim Colonia As String = ""
        If InStr(CStr(oRowDes!CITY2).Trim.ToUpper, "COL") > 0 Then
            Colonia = oRowDes!CITY2
        Else
            Colonia = "Col. " & oRowDes!CITY2
        End If
        strdt = CStr(oRowDes!STREET & oRowDes!HOUSE_NUM1 & vbCrLf & Colonia & " - CP: " & oRowDes!POST_CODE1).Trim
        If strdt.Trim <> "" Then
            tbDomicilioDes.Text = strdt & vbNewLine
        End If
        '--------------------------------------------------------------------------------------------------------------------------------------------
        'CIUDAD ESTADO
        '--------------------------------------------------------------------------------------------------------------------------------------------
        strdt = Trim(oRowG!Ciudad & " " & oRowG!Estado)
        If strdt.Trim <> "" Then
            'If CStr(oRowG!CodTipoVenta).Trim = "P" Then
            '    tbDomicilio.Text = tbDomicilio.Text & strdt
            'Else
            tbDomicilio.Text = tbDomicilio.Text & strdt & vbNewLine
            'End If
        End If
        strdt = Trim(oRowDes!CITY1 & " " & oRowDes!REGION)
        If strdt.Trim <> "" Then
            tbDomicilioDes.Text = tbDomicilioDes.Text & strdt & vbNewLine
        End If
        '--------------------------------------------------------------------------------------------------------------------------------------------
        'RFC
        '--------------------------------------------------------------------------------------------------------------------------------------------
        strdt = Trim(IIf(IsDBNull(oRowG!RFC), "", oRowG!RFC))
        If strdt.Trim <> "" Then
            tbDomicilio.Text = tbDomicilio.Text & strdt & vbNewLine
        End If
        strdt = Trim(IIf(IsDBNull(oRowDes!NAME4), "", oRowDes!NAME4))
        If strdt.Trim <> "" Then
            tbDomicilio.Text = tbDomicilio.Text & strdt & vbNewLine
        End If
        '--------------------------------------------------------------------------------------------------------------------------------------------
        'TELEFONO
        '--------------------------------------------------------------------------------------------------------------------------------------------
        strdt = Trim(IIf(IsDBNull(oRowG!Telefono), "", oRowG!Telefono))
        If strdt.Trim <> "" Then
            tbDomicilio.Text = tbDomicilio.Text & strdt
        End If
        tbDomicilio.Text = tbDomicilio.Text.Trim.ToUpper
        tbDomicilioDes.Text = tbDomicilioDes.Text.Trim.ToUpper
        tbLeyendaAduana.Text = tbLeyendaAduana.Text.Trim.ToUpper
        tbNombre.Text = tbNombre.Text.Trim.ToUpper
        tbNombreDes.Text = tbNombreDes.Text.Trim.ToUpper
        '--------------------------------------------------------------------------------------------------------------------------------------------
        'Importe con letra
        '--------------------------------------------------------------------------------------------------------------------------------------------
        strdt = ""
        '----------------------------FACILITO - TEXTO LETRA
        'If Trim(CStr(DatosGenerales.Rows(0).Item("AutorizacionFacilito"))) <> String.Empty Then
        '    strdt = Trim(DatosGenerales.Rows(0).Item("AutorizacionFacilito")) & vbNewLine & vbNewLine
        'End If

        'If Trim(CStr(DatosGenerales.Rows(0).Item("LeyendaPago"))) <> String.Empty Then
        '    strdt = strdt & Trim(DatosGenerales.Rows(0).Item("LeyendaPago")) & vbNewLine & vbNewLine
        'End If
        '----------------------------FACILITO - TEXTO LETRA
        ' Autorizacion Facilito + Leyenda de Pago + Cantidad Con Letra 
        If FolioCupon.Trim <> "" Then
            tbTotalLetras.Text = "Se utilizó el cupón ".ToUpper & FolioCupon.Trim & vbCrLf & vbCrLf
        End If
        tbTotalLetras.Text &= CStr(oRowG!CantidadTexto).Trim
        '------------------------------------------------------------------------------------------------------------------------------------------------------
        'DESC. APLICADO:
        '------------------------------------------------------------------------------------------------------------------------------------------------------
        If oRowG!Descuento > 0 Then
            ' If oFactura.CodTipoVenta = "P" Or oFactura.CodTipoVenta = "V" Then
            ' tbSubTotal.Text = Format(DatosGenerales.Rows(0).Item("Descuento") * (oAppContext.ApplicationConfiguration.IVA + 1), "Currency") & vbNewLine
            'Else
            tbSubTotal.Text = Format(CDec(oRowG!Descuento), "Currency") & vbNewLine
            ' End If
            'TxtSubTotIva.Text = "DESC. APLICADO:" & vbNewLine
            TxtSubTotIva.Text = "USTED AHORRO:" & vbNewLine
        Else
            Label20.Text = ""
            TxtBxSubTotSinDescto.Text = ""
            TxtBxSubTotSinDescto.Visible = False
            Label20.Visible = False
        End If
        '------------------------------------------------------------------------------------------------------------------------------------------------------
        'DESC. APLICADO:
        'SUBTOTAL      
        '------------------------------------------------------------------------------------------------------------------------------------------------------
        If oRowG!Subtotal > 0 Then
            tbSubTotal.Text = tbSubTotal.Text & Format(CDec(oRowG!Subtotal), "$#,##0.00") & vbNewLine
            If oRowG!Descuento > 0 Then
                TxtSubTotIva.Text = TxtSubTotIva.Text & "SUBTOTAL CON DESC.:" & vbNewLine
            Else
                TxtSubTotIva.Text = TxtSubTotIva.Text & "SUBTOTAL:" & vbNewLine
            End If
        End If
        '------------------------------------------------------------------------------------------------------------------------------------------------------
        'IVA
        '------------------------------------------------------------------------------------------------------------------------------------------------------
        If oRowG!Iva > 0 Then
            tbSubTotal.Text = tbSubTotal.Text & Format(CDec(oRowG!IVA), "$#,##0.00") & vbNewLine
            TxtSubTotIva.Text = TxtSubTotIva.Text & "IVA:" & vbNewLine
        End If
        '------------------------------------------------------------------------------------------------------------------------------------------------------
        'TOTAL
        '------------------------------------------------------------------------------------------------------------------------------------------------------
        tbSubTotal.Text = tbSubTotal.Text & Format(CDec(oRowG!Total), "$#,##0.00")
        TxtSubTotIva.Text = TxtSubTotIva.Text & "TOTAL C/IVA:" & vbNewLine
        '------------------------------------------------------------------------------------------------------------------------------------------------------
        'Vendedor
        '------------------------------------------------------------------------------------------------------------------------------------------------------
        tbPlayer.Text = CStr(oRowG!CodVendedor).Trim
        '------------------------------------------------------------------------------------------------------------------------------------------------------
        'SUCURSAL
        '------------------------------------------------------------------------------------------------------------------------------------------------------
        Dim oCatalogoAlmacenesMgr As New CatalogoAlmacenesManager(oAppContext)
        Dim oAlmacen As Almacen
        Dim oSAPMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        oAlmacen = oCatalogoAlmacenesMgr.Load(oSAPMgr.REad_centros) 'oAppContext.ApplicationConfiguration.Almacen)
        Me.TxtTienda.Text = oAlmacen.Descripcion
        Me.txtDomTienda.Text = oAlmacen.DireccionCalle
        Me.LblTelefono.Text = "C.P." & oAlmacen.DireccionCP & " TEL. " & oAlmacen.TelefonoNum
        Me.LblLocaliz.Text = oAlmacen.DireccionCiudad & ", " & oAlmacen.DireccionEstado
        oCatalogoAlmacenesMgr = Nothing
        tbLugarFecha.Text = oAlmacen.DireccionCiudad & ", " & oAlmacen.DireccionEstado & ", " & UCase(Format(Now, "dd-MMM-yy hh:mm tt"))
        oAlmacen = Nothing
        Me.txtInfoSuc.Text = Me.TxtTienda.Text & vbLf & Me.txtDomTienda.Text & vbLf & Me.LblTelefono.Text & vbLf & _
                             Me.Label19.Text & vbLf & Me.LblLocaliz.Text
        '------------------------------------------------------------------------------------------------------------------------------------------------------
        'Notas
        '------------------------------------------------------------------------------------------------------------------------------------------------------
        'Dim pdsAvisos As New DataSet
        'oAvisosFacturaMgr = New AvisosFacturaManager(oAppContext)
        'pdsAvisos = oAvisosFacturaMgr.LoadEnabled("FACTURACION", True)
        'If pdsAvisos.Tables(0).Rows.Count > 0 Then
        '    For Each oRow As DataRow In pdsAvisos.Tables(0).Rows
        '        lblNotas.Text += oRow.Item("Nota") & "." & Microsoft.VisualBasic.vbCrLf
        '    Next
        'End If

        lblNotas.Text = "MERCANCIA CON EL 20% Y 40% DE DESCUENTO NO TIENE DEVOLUCION NI CAMBIO." '& vbCrLf & "SISTEMA DE APARTADO CON UN 20% DE ANTICIPO, A 45 DIAS."

        '--------------------------------------------------------------------------------------------------
        ' JNAVA (28.06.2016): Mostramos la Pagina Web de Dportenis segun la version de Ecommerce
        '--------------------------------------------------------------------------------------------------
        If VersionEcommerce.Trim() = "DPT" Then
            Me.txtPagina.Text = oConfigCierreFI.PaginaDportenis
        ElseIf VersionEcommerce.Trim() = "DPS" Then
            Me.txtPagina.Text = oConfigCierreFI.PaginaDpStreet
        End If
        '--------------------------------------------------------------------------------------------------

        'oReporteFormapago = New ReporteDetalleFormasPago(oDataRpt.FacturaID)
        'Me.SubReport1.Report = oReporteFormapago
        'Me.SubReport1.Report.DataSource = oReporteFormapago.DataSource
        'Me.SubReport1.Report.DataMember = oReporteFormapago.DataMember
        '------------------------------------------------------------------------------------------------------------------------------------------------------
        'Avisos del Sistema
        '------------------------------------------------------------------------------------------------------------------------------------------------------
        oReporteAvisosFactura = New ReporteAvisosFactura("Facturacion", True)
        Me.SubReport2.Report = oReporteAvisosFactura
        Me.SubReport2.Report.DataSource = oReporteAvisosFactura.DataSource
        Me.SubReport2.Report.DataMember = oReporteAvisosFactura.DataMember

        Me.Run()

    End Sub

    Private Function SepararArticulos(ByVal dt As DataTable) As DataTable

        Dim newDT As DataTable = dt.Clone

        For Each oRow As DataRow In dt.Rows

            Dim i As Integer

            For i = 1 To CInt(oRow!Cantidad)

                Dim oNewRow As DataRow = newDT.NewRow

                With oNewRow
                    !Cantidad = 1
                    !CodArticulo = oRow!CodArticulo
                    !Descripcion = oRow!Descripcion
                    !Numero = oRow!Numero
                    !PrecioOferta = CDec(oRow!PrecioOferta) / CInt(oRow!Cantidad)
                    !Descuento = CDec(oRow!Descuento) / CInt(oRow!Cantidad)
                    !Total = CDec(oNewRow!PrecioOferta) * CInt(oNewRow!Cantidad)
                End With

                newDT.Rows.Add(oNewRow)

            Next i

        Next

        newDT.AcceptChanges()

        Return newDT

    End Function

    Private Function FormatearTablaDetalle() As DataTable

        Dim dt As New DataTable("Detalle")

        dt.Columns.Add("Cantidad")
        dt.Columns.Add("CodArticulo")
        dt.Columns.Add("Descripcion")
        dt.Columns.Add("Numero")
        dt.Columns.Add("PrecioOferta")
        dt.Columns.Add("Descuento")
        dt.Columns.Add("Total")

        dt.AcceptChanges()

        Return dt

    End Function

    Private Function LlenarTablaDetalle(ByVal dtFacturaDetalle As DataTable, ByVal dtDetalle As DataTable) As DataTable

        Dim dtTemp As DataTable

        dtTemp = dtDetalle.Clone

        For Each oRow As DataRow In dtFacturaDetalle.Rows

            Dim oNewRow As DataRow = dtTemp.NewRow

            With oNewRow
                !Cantidad = oRow!Cantidad
                !CodArticulo = oRow!CodArticulo
                !Descripcion = oRow!Descripcion
                !Numero = "" 'oRow!Numero
                !PrecioOferta = oRow!PrecioOferta
                !Total = oRow!Total
                !Descuento = oRow!Descuento + oRow!Descuento2 + oRow!Descuento3
                '!Descuento = CDec(oRow!CantDescuentoSistema) + ((CDec(oRow!Total) - CDec(oRow!CantDescuentoSistema)) * (CDec(oRow!Descuento) / 100))
            End With
            dtTemp.Rows.Add(oNewRow)

        Next

        Return dtTemp

    End Function

    Dim intIndex As Integer = 0
    Dim bAnterior As Boolean
    Dim x As Double = 0.001
    Private Sub Detail_BeforePrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles Detail.BeforePrint
        intIndex += 1
        'If oFactura.CodTipoVenta = "P" OrElse oFactura.CodTipoVenta = "V" OrElse oFactura.CodTipoVenta = "E" Then
        Me.tbPUnitario.Text = Format((CDbl(Me.tbPUnitario.Text) * (1 + IVA)), "Currency")
        Me.tbTotal.Text = Format((CInt(tbCantidad.Text) * CDbl(tbPUnitario.Text)), "Currency")

        Me.tbDesc.Value = Math.Round((CDbl(Me.tbDesc.Text) * -1) * (1 + IVA), 2)
        Me.tbDesc.Text = Format(Me.tbDesc.Value, "Currency")
        'Me.tbDesc.Text = Format((CDbl(Me.tbDesc.Text) * (1 + oAppContext.ApplicationConfiguration.IVA)), "Currency")

        'If DirectCast(Detail.Controls("tbDesc"), TextBox).Value = 0 Then
        '    DirectCast(Detail.Controls("label34"), TextBox).Height = 0
        '    DirectCast(Detail.Controls("tbCantDesc"), TextBox).Height = 0
        '    DirectCast(Detail.Controls("tbDesc"), TextBox).Height = 0
        '    bAnterior = False
        'Else
        '    bAnterior = True
        'End If

        'If intIndex > 1 AndAlso Not bAnterior Then
        '    Me.tbPUnitario.Top = Me.tbPUnitario.Top - 0.135
        '    Me.tbConcepto.Top = Me.tbConcepto.Top - 0.135 '(0.13 + ((intIndex - 1) * 0.001)) + x
        '    Me.tbNumero.Top = Me.tbNumero.Top - 0.135 '(0.13 + ((intIndex - 1) * 0.001)) + x
        '    Me.tbTotal.Top = Me.tbTotal.Top - 0.135 '(0.13 + ((intIndex - 1) * 0.001)) + x
        '    x += 0.002
        '    'bAnterior = True
        'End If

        '    If DirectCast(Detail.Controls("tbDesc"), TextBox).Value = 0 Then
        '        '    Me.tbConcepto.Text &= vbCrLf & "AHORRO: " & Me.tbDesc.Text
        '        '    Me.tbTotal.Text &= vbCrLf & Me.tbCantDesc.Text
        '        'Me.Label34.Visible = False
        '        'Me.tbDesc.Visible = False
        '        'Me.tbCantDesc.Visible = False
        '        'DirectCast(Detail.Controls("tbTotal"), TextBox)

        '        DirectCast(Detail.Controls("label34"), TextBox).Text = ""
        '        DirectCast(Detail.Controls("tbCantDesc"), TextBox).Text = ""
        '        DirectCast(Detail.Controls("tbDesc"), TextBox).Text = ""


        '    'Me.label34.Text = ""
        '    'Me.tbDesc.Text = ""
        '    ' Me.tbCantDesc.Text = ""
        'End If
        'End If
        If DirectCast(Detail.Controls("tbDesc"), TextBox).Value > 0 Then
            'Me.tbDesc.Text = Format(Me.tbDesc.Value, "Currency") & " -"
            DirectCast(Detail.Controls("label34"), TextBox).Text = "AHORRO"
            'DirectCast(Detail.Controls("label34"), TextBox).Text.re
            DirectCast(Detail.Controls("tbDesc"), TextBox).Text = Format(DirectCast(Detail.Controls("tbDesc"), TextBox).Value, "Currency") & " -"
            DirectCast(Detail.Controls("tbCantDesc"), TextBox).Text = DirectCast(Detail.Controls("tbDesc"), TextBox).Text
            DirectCast(Detail.Controls("tbTotalConDesc"), TextBox).Text = Format(DirectCast(Detail.Controls("tbTotal"), TextBox).Value - DirectCast(Detail.Controls("tbDesc"), TextBox).Value, "Currency")
            DirectCast(Detail.Controls("label34"), TextBox).Visible = True
            DirectCast(Detail.Controls("tbDesc"), TextBox).Visible = True
            'Me.tbTotalConDesc.Text = Format((CDbl(Me.tbTotal.Text) - CDbl(Me.tbDesc.Text)), "Currency")
            'Me.tbCantDesc.Text = Me.tbDesc.Text '& " -"
            'Me.label34.Text = "AHORRO"
        Else
            DirectCast(Detail.Controls("label34"), TextBox).Visible = False
            DirectCast(Detail.Controls("tbDesc"), TextBox).Visible = False
        End If

    End Sub

    Private Sub ReportFooter_BeforePrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportFooter.BeforePrint
        'If oFactura.CodTipoVenta = "P" OrElse oFactura.CodTipoVenta = "V" OrElse oFactura.CodTipoVenta = "E" Then
        Me.TxtBxSubTotSinDescto.Value = Math.Round(CDbl(Me.TxtBxSubTotSinDescto.Text) * (1 + IVA), 2)
        Me.TxtBxSubTotSinDescto.Text = Format(Me.TxtBxSubTotSinDescto.Value, "Currency")
        'Me.TxtBxSubTotSinDescto.Text = Format((CDbl(Me.TxtBxSubTotSinDescto.Text) * (1 + oAppContext.ApplicationConfiguration.IVA)), "Currency")
        'End If
    End Sub

    'Private Sub ReporteFacturacion_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.ReportStart
    '    If Me.boolImprimirCedula = False Then

    '        'Movemos hacia la derecha los datos generales 
    '        Me.Label17.Left = 3.5
    '        Me.Label8.Left = 3.5
    '        Me.Label9.Left = 3.5
    '        Me.Label10.Left = 3.5
    '        Me.Label11.Left = 3.5
    '        Me.Label12.Left = 3.5

    '        'Ponemos invisibles los datos generales
    '        Me.Label17.Visible = False
    '        Me.Label8.Visible = False
    '        Me.Label9.Visible = False
    '        Me.Label10.Visible = False
    '        Me.Label11.Visible = False
    '        Me.Label12.Visible = False

    '        'Subimos los controles del page header
    '        Me.Label16.Top = 0.01

    '        Me.txtInfoSuc.Top = 0.167

    '        'Me.TxtTienda.Top = 0.167
    '        'Me.txtDomTienda.Top = 0.325
    '        ''Me.LblTelefono.Top = 0.482
    '        'Me.LblTelefono.Top = 0.61
    '        ''Me.Label19.Top = 0.64
    '        'Me.Label19.Top = 0.768
    '        'Me.LblLocaliz.Top = 0.926
    '        'Me.LblDomTienda.Top = 0.955

    '        'Me.LblCopia.Top = 1.2
    '        Me.LblCopia.Top = 0.4
    '        'Me.lblCancelacion.Top = 1.304
    '        'Me.tbFCancelacion.Top = 1.315
    '        Me.lblCancelacion.Top = 0.604
    '        Me.tbFCancelacion.Top = 0.615
    '        'Me.lblFactura.Top = 1.491
    '        'Me.tbFactura.Top = 1.512
    '        Me.lblFactura.Top = 0.791
    '        Me.tbFactura.Top = 0.812
    '        'Me.lblCaja.Top = 1.692
    '        Me.lblCaja.Top = 0.992
    '        'Me.tbTipoVenta.Top = 1.891
    '        Me.tbTipoVenta.Top = 1.191
    '        Me.lblQuincenas.Top = Me.tbTipoVenta.Top
    '        'Me.tbLugarFecha.Top = 2.091
    '        Me.tbLugarFecha.Top = 1.391
    '        'Me.tbNombre.Top = 2.291
    '        Me.tbNombre.Top = 1.591
    '        'Me.tbDomicilio.Top = 2.491
    '        Me.tbDomicilio.Top = 1.791
    '        'Me.lblLeyendaPago.Top = 2.728
    '        Me.lblLeyendaPago.Top = 2.028
    '        'Me.ReportHeader.Height = 3.1
    '        Me.ReportHeader.Height = 2.2

    '        'Movemos los datos fiscales hacia la derecha
    '        Me.Label26.Left = 5.17
    '        Me.Label18.Left = 5.17
    '        Me.Shape2.Left = 3.733
    '        Me.Shape1.Left = 3.733
    '        Me.Label27.Left = 3.733
    '        Me.Label23.Left = 4.176
    '        Me.Label24.Left = 4.176
    '        Me.Label25.Left = 4.177
    '        Me.Label28.Left = 3.752
    '        Me.Label29.Left = 3.674
    '        Me.Label30.Left = 3.674
    '        Me.Label31.Left = 3.674
    '        Me.Label32.Left = 3.752
    '        Me.Label33.Left = 3.91

    '        'Ponemos invisibles los datos fiscales
    '        Me.Label26.Visible = False
    '        Me.Label18.Visible = False
    '        Me.Shape2.Visible = False
    '        Me.Shape1.Visible = False
    '        Me.Label27.Visible = False
    '        Me.Label23.Visible = False
    '        Me.Label24.Visible = False
    '        Me.Label25.Visible = False
    '        Me.Label28.Visible = False
    '        Me.Label29.Visible = False
    '        Me.Label30.Visible = False
    '        Me.Label31.Visible = False
    '        Me.Label32.Visible = False
    '        Me.Label33.Visible = False

    '        'Subo el total a pagar quincenalmente
    '        Me.lblAPagar.Top = 1.878

    '        'Subo las notas
    '        If Me.lblAPagar.Visible = True Then
    '            Me.lblNotas.Top = Me.lblAPagar.Top + 0.6
    '        Else
    '            Me.lblNotas.Top = 1.878
    '        End If



    '        'Seteo el alto del ReporteFooter
    '        Me.ReportFooter.Height = 3

    '    End If
    'End Sub

#Region "ActiveReports Designer generated code"
    Private WithEvents ReportHeader As ReportHeader = Nothing
    Private WithEvents PageHeader As PageHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents PageFooter As PageFooter = Nothing
    Private WithEvents ReportFooter As ReportFooter = Nothing
	Private lblQuincenas As TextBox = Nothing
	Private tbNombre As TextBox = Nothing
	Private tbFactura As TextBox = Nothing
	Private tbDomicilio As TextBox = Nothing
	Private tbLugarFecha As TextBox = Nothing
	Private lblLeyendaPago As Label = Nothing
	Private tbTipoVenta As TextBox = Nothing
	Private lblCaja As Label = Nothing
	Private lblFactura As Label = Nothing
	Private LblDomTienda As Label = Nothing
	Private LblTelefono As Label = Nothing
	Private LblLocaliz As Label = Nothing
	Private Label16 As Label = Nothing
	Private Label19 As Label = Nothing
	Private LblCopia As Label = Nothing
	Private txtDomTienda As TextBox = Nothing
	Private TxtTienda As TextBox = Nothing
	Private lblCancelacion As Label = Nothing
	Private tbFCancelacion As TextBox = Nothing
	Private txtInfoSuc As TextBox = Nothing
	Private tbNombreDes As TextBox = Nothing
	Private tbDomicilioDes As TextBox = Nothing
	Private Label36 As Label = Nothing
	Private Label37 As Label = Nothing
	Private txtLeyendaEcommerce As Label = Nothing
	Private tbConcepto As TextBox = Nothing
	Private tbPUnitario As TextBox = Nothing
	Private tbTotal As TextBox = Nothing
	Private tbCantidad As TextBox = Nothing
	Private tbCodigo As TextBox = Nothing
	Private tbNumero As TextBox = Nothing
	Private tbDesc As TextBox = Nothing
	Private tbTotalConDesc As TextBox = Nothing
	Private Label35 As Label = Nothing
	Private tbCantDesc As TextBox = Nothing
	Private label34 As TextBox = Nothing
	Private tbSubTotal As TextBox = Nothing
	Private tbPlayer As TextBox = Nothing
	Private SubReport1 As SubReport = Nothing
	Private Label1 As Label = Nothing
	Private Label2 As Label = Nothing
	Private tbTotalLetras As TextBox = Nothing
	Private SubReport2 As SubReport = Nothing
	Private TxtBxSubTotSinDescto As TextBox = Nothing
	Private Label20 As Label = Nothing
	Private TxtSubTotIva As TextBox = Nothing
	Private Line3 As Line = Nothing
	Private lblAPagar As Label = Nothing
	Private tbLeyendaAduana As TextBox = Nothing
	Private lblNotas As TextBox = Nothing
	Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptFacturacionEC))
        Me.Detail = New DataDynamics.ActiveReports.Detail()
        Me.tbConcepto = New DataDynamics.ActiveReports.TextBox()
        Me.tbPUnitario = New DataDynamics.ActiveReports.TextBox()
        Me.tbTotal = New DataDynamics.ActiveReports.TextBox()
        Me.tbCantidad = New DataDynamics.ActiveReports.TextBox()
        Me.tbCodigo = New DataDynamics.ActiveReports.TextBox()
        Me.tbNumero = New DataDynamics.ActiveReports.TextBox()
        Me.tbDesc = New DataDynamics.ActiveReports.TextBox()
        Me.tbTotalConDesc = New DataDynamics.ActiveReports.TextBox()
        Me.Label35 = New DataDynamics.ActiveReports.Label()
        Me.tbCantDesc = New DataDynamics.ActiveReports.TextBox()
        Me.label34 = New DataDynamics.ActiveReports.TextBox()
        Me.ReportHeader = New DataDynamics.ActiveReports.ReportHeader()
        Me.lblQuincenas = New DataDynamics.ActiveReports.TextBox()
        Me.tbNombre = New DataDynamics.ActiveReports.TextBox()
        Me.tbFactura = New DataDynamics.ActiveReports.TextBox()
        Me.tbDomicilio = New DataDynamics.ActiveReports.TextBox()
        Me.tbLugarFecha = New DataDynamics.ActiveReports.TextBox()
        Me.lblLeyendaPago = New DataDynamics.ActiveReports.Label()
        Me.tbTipoVenta = New DataDynamics.ActiveReports.TextBox()
        Me.lblCaja = New DataDynamics.ActiveReports.Label()
        Me.lblFactura = New DataDynamics.ActiveReports.Label()
        Me.LblDomTienda = New DataDynamics.ActiveReports.Label()
        Me.LblTelefono = New DataDynamics.ActiveReports.Label()
        Me.LblLocaliz = New DataDynamics.ActiveReports.Label()
        Me.Label16 = New DataDynamics.ActiveReports.Label()
        Me.Label19 = New DataDynamics.ActiveReports.Label()
        Me.LblCopia = New DataDynamics.ActiveReports.Label()
        Me.txtDomTienda = New DataDynamics.ActiveReports.TextBox()
        Me.TxtTienda = New DataDynamics.ActiveReports.TextBox()
        Me.lblCancelacion = New DataDynamics.ActiveReports.Label()
        Me.tbFCancelacion = New DataDynamics.ActiveReports.TextBox()
        Me.txtInfoSuc = New DataDynamics.ActiveReports.TextBox()
        Me.tbNombreDes = New DataDynamics.ActiveReports.TextBox()
        Me.tbDomicilioDes = New DataDynamics.ActiveReports.TextBox()
        Me.Label36 = New DataDynamics.ActiveReports.Label()
        Me.Label37 = New DataDynamics.ActiveReports.Label()
        Me.txtLeyendaEcommerce = New DataDynamics.ActiveReports.Label()
        Me.ReportFooter = New DataDynamics.ActiveReports.ReportFooter()
        Me.tbSubTotal = New DataDynamics.ActiveReports.TextBox()
        Me.tbPlayer = New DataDynamics.ActiveReports.TextBox()
        Me.SubReport1 = New DataDynamics.ActiveReports.SubReport()
        Me.Label1 = New DataDynamics.ActiveReports.Label()
        Me.Label2 = New DataDynamics.ActiveReports.Label()
        Me.tbTotalLetras = New DataDynamics.ActiveReports.TextBox()
        Me.SubReport2 = New DataDynamics.ActiveReports.SubReport()
        Me.TxtBxSubTotSinDescto = New DataDynamics.ActiveReports.TextBox()
        Me.Label20 = New DataDynamics.ActiveReports.Label()
        Me.TxtSubTotIva = New DataDynamics.ActiveReports.TextBox()
        Me.Line3 = New DataDynamics.ActiveReports.Line()
        Me.lblAPagar = New DataDynamics.ActiveReports.Label()
        Me.tbLeyendaAduana = New DataDynamics.ActiveReports.TextBox()
        Me.lblNotas = New DataDynamics.ActiveReports.TextBox()
        Me.PageHeader = New DataDynamics.ActiveReports.PageHeader()
        Me.PageFooter = New DataDynamics.ActiveReports.PageFooter()
        Me.txtPagina = New DataDynamics.ActiveReports.TextBox()
        CType(Me.tbConcepto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbPUnitario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbCantidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbCodigo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbNumero, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbDesc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbTotalConDesc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label35, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbCantDesc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.label34, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblQuincenas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbNombre, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbFactura, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbDomicilio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbLugarFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblLeyendaPago, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbTipoVenta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblCaja, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFactura, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblDomTienda, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblTelefono, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblLocaliz, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label19, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblCopia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDomTienda, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtTienda, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblCancelacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbFCancelacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtInfoSuc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbNombreDes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbDomicilioDes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label36, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label37, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtLeyendaEcommerce, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbSubTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbPlayer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbTotalLetras, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtBxSubTotSinDescto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label20, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtSubTotIva, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblAPagar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbLeyendaAduana, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblNotas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPagina, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.CanShrink = True
        Me.Detail.ColumnSpacing = 0.0!
        Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.tbConcepto, Me.tbPUnitario, Me.tbTotal, Me.tbCantidad, Me.tbCodigo, Me.tbNumero, Me.tbDesc, Me.tbTotalConDesc, Me.Label35, Me.tbCantDesc, Me.label34})
        Me.Detail.Height = 0.40625!
        Me.Detail.KeepTogether = True
        Me.Detail.Name = "Detail"
        '
        'tbConcepto
        '
        Me.tbConcepto.Height = 0.2!
        Me.tbConcepto.Left = 0.256!
        Me.tbConcepto.MultiLine = False
        Me.tbConcepto.Name = "tbConcepto"
        Me.tbConcepto.Style = "ddo-char-set: 0; font-size: 8.25pt; font-family: Tahoma"
        Me.tbConcepto.Text = "Concepto"
        Me.tbConcepto.Top = 0.174!
        Me.tbConcepto.Width = 1.296!
        '
        'tbPUnitario
        '
        Me.tbPUnitario.Height = 0.2!
        Me.tbPUnitario.Left = 1.551673!
        Me.tbPUnitario.Name = "tbPUnitario"
        Me.tbPUnitario.OutputFormat = resources.GetString("tbPUnitario.OutputFormat")
        Me.tbPUnitario.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; font-family: Tahoma"
        Me.tbPUnitario.Text = "$5,200.31"
        Me.tbPUnitario.Top = 0.0!
        Me.tbPUnitario.Width = 0.551181!
        '
        'tbTotal
        '
        Me.tbTotal.Height = 0.2!
        Me.tbTotal.Left = 2.109744!
        Me.tbTotal.Name = "tbTotal"
        Me.tbTotal.OutputFormat = resources.GetString("tbTotal.OutputFormat")
        Me.tbTotal.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; font-family: Tahoma"
        Me.tbTotal.Text = "$99,999.00"
        Me.tbTotal.Top = 0.0!
        Me.tbTotal.Width = 0.6102362!
        '
        'tbCantidad
        '
        Me.tbCantidad.Height = 0.2!
        Me.tbCantidad.Left = 0.2559055!
        Me.tbCantidad.Name = "tbCantidad"
        Me.tbCantidad.OutputFormat = resources.GetString("tbCantidad.OutputFormat")
        Me.tbCantidad.Style = "ddo-char-set: 0; text-align: left; font-size: 8.25pt; font-family: Tahoma"
        Me.tbCantidad.Text = "99"
        Me.tbCantidad.Top = 0.0!
        Me.tbCantidad.Visible = False
        Me.tbCantidad.Width = 0.1574803!
        '
        'tbCodigo
        '
        Me.tbCodigo.CanShrink = True
        Me.tbCodigo.Height = 0.2!
        Me.tbCodigo.Left = 0.256!
        Me.tbCodigo.Name = "tbCodigo"
        Me.tbCodigo.Style = "ddo-char-set: 0; text-align: left; font-size: 8.25pt; font-family: Tahoma"
        Me.tbCodigo.Text = "KS-001289-1671"
        Me.tbCodigo.Top = 0.0!
        Me.tbCodigo.Width = 1.312!
        '
        'tbNumero
        '
        Me.tbNumero.Height = 0.2!
        Me.tbNumero.Left = 1.299705!
        Me.tbNumero.Name = "tbNumero"
        Me.tbNumero.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; font-family: Tahoma"
        Me.tbNumero.Text = "25.5"
        Me.tbNumero.Top = 0.0!
        Me.tbNumero.Width = 0.2559055!
        '
        'tbDesc
        '
        Me.tbDesc.CanShrink = True
        Me.tbDesc.Height = 0.2!
        Me.tbDesc.Left = 2.125!
        Me.tbDesc.MultiLine = False
        Me.tbDesc.Name = "tbDesc"
        Me.tbDesc.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; font-family: Tahoma"
        Me.tbDesc.Text = "$0.00 -"
        Me.tbDesc.Top = 0.174!
        Me.tbDesc.Width = 0.6190944!
        '
        'tbTotalConDesc
        '
        Me.tbTotalConDesc.CanGrow = False
        Me.tbTotalConDesc.Height = 0.1574803!
        Me.tbTotalConDesc.Left = 0.8184056!
        Me.tbTotalConDesc.MultiLine = False
        Me.tbTotalConDesc.Name = "tbTotalConDesc"
        Me.tbTotalConDesc.Style = "ddo-char-set: 0; font-size: 8.25pt; font-family: Tahoma"
        Me.tbTotalConDesc.Text = "$0.00"
        Me.tbTotalConDesc.Top = 0.6737205!
        Me.tbTotalConDesc.Width = 0.6889763!
        '
        'Label35
        '
        Me.Label35.Height = 0.1574802!
        Me.Label35.HyperLink = Nothing
        Me.Label35.Left = 0.3184056!
        Me.Label35.Name = "Label35"
        Me.Label35.Style = "text-align: left; font-size: 8.25pt; font-family: Tahoma"
        Me.Label35.Text = "TOTAL"
        Me.Label35.Top = 0.6811022!
        Me.Label35.Width = 0.4527559!
        '
        'tbCantDesc
        '
        Me.tbCantDesc.CanShrink = True
        Me.tbCantDesc.Height = 0.2!
        Me.tbCantDesc.Left = 2.125!
        Me.tbCantDesc.MultiLine = False
        Me.tbCantDesc.Name = "tbCantDesc"
        Me.tbCantDesc.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; font-family: Tahoma"
        Me.tbCantDesc.Text = "$0.00 -"
        Me.tbCantDesc.Top = 0.6112205!
        Me.tbCantDesc.Width = 0.61!
        '
        'label34
        '
        Me.label34.CanShrink = True
        Me.label34.Height = 0.2!
        Me.label34.Left = 1.5685!
        Me.label34.Name = "label34"
        Me.label34.Style = "ddo-char-set: 1; text-align: right; font-size: 8.25pt; font-family: Tahoma"
        Me.label34.Text = "AHORRO"
        Me.label34.Top = 0.174!
        Me.label34.Width = 0.563!
        '
        'ReportHeader
        '
        Me.ReportHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.lblQuincenas, Me.tbNombre, Me.tbFactura, Me.tbDomicilio, Me.tbLugarFecha, Me.lblLeyendaPago, Me.tbTipoVenta, Me.lblCaja, Me.lblFactura, Me.LblDomTienda, Me.LblTelefono, Me.LblLocaliz, Me.Label16, Me.Label19, Me.LblCopia, Me.txtDomTienda, Me.TxtTienda, Me.lblCancelacion, Me.tbFCancelacion, Me.txtInfoSuc, Me.tbNombreDes, Me.tbDomicilioDes, Me.Label36, Me.Label37, Me.txtLeyendaEcommerce})
        Me.ReportHeader.Height = 3.71875!
        Me.ReportHeader.Name = "ReportHeader"
        '
        'lblQuincenas
        '
        Me.lblQuincenas.Height = 0.15748!
        Me.lblQuincenas.Left = 1.75!
        Me.lblQuincenas.Name = "lblQuincenas"
        Me.lblQuincenas.Style = "ddo-char-set: 1; text-align: right; font-size: 10pt; font-family: Tahoma"
        Me.lblQuincenas.Text = Nothing
        Me.lblQuincenas.Top = 1.578576!
        Me.lblQuincenas.Visible = False
        Me.lblQuincenas.Width = 0.9665347!
        '
        'tbNombre
        '
        Me.tbNombre.CanShrink = True
        Me.tbNombre.Height = 0.1574803!
        Me.tbNombre.Left = 0.2559055!
        Me.tbNombre.Name = "tbNombre"
        Me.tbNombre.Style = "ddo-char-set: 0; text-align: justify; font-size: 9.75pt; font-family: Arial"
        Me.tbNombre.Text = "Nombre"
        Me.tbNombre.Top = 2.35351!
        Me.tbNombre.Width = 2.46063!
        '
        'tbFactura
        '
        Me.tbFactura.Height = 0.1574803!
        Me.tbFactura.Left = 1.64042!
        Me.tbFactura.Name = "tbFactura"
        Me.tbFactura.Style = "ddo-char-set: 0; text-align: left; font-weight: normal; font-size: 9pt; font-fami" & _
    "ly: Tahoma"
        Me.tbFactura.Text = "FACT"
        Me.tbFactura.Top = 1.199803!
        Me.tbFactura.Width = 1.076115!
        '
        'tbDomicilio
        '
        Me.tbDomicilio.CanShrink = True
        Me.tbDomicilio.Height = 0.1574802!
        Me.tbDomicilio.Left = 0.2559055!
        Me.tbDomicilio.Name = "tbDomicilio"
        Me.tbDomicilio.Style = "ddo-char-set: 0; text-align: justify; font-size: 9.75pt; font-family: Arial"
        Me.tbDomicilio.Text = "Domicilio"
        Me.tbDomicilio.Top = 2.553477!
        Me.tbDomicilio.Width = 2.431595!
        '
        'tbLugarFecha
        '
        Me.tbLugarFecha.Height = 0.15748!
        Me.tbLugarFecha.Left = 0.2559055!
        Me.tbLugarFecha.Name = "tbLugarFecha"
        Me.tbLugarFecha.Style = "ddo-char-set: 0; font-size: 9pt; font-family: Tahoma"
        Me.tbLugarFecha.Text = "Lugar Fecha"
        Me.tbLugarFecha.Top = 1.778543!
        Me.tbLugarFecha.Width = 2.46063!
        '
        'lblLeyendaPago
        '
        Me.lblLeyendaPago.Height = 0.1860237!
        Me.lblLeyendaPago.HyperLink = Nothing
        Me.lblLeyendaPago.Left = 0.2559055!
        Me.lblLeyendaPago.Name = "lblLeyendaPago"
        Me.lblLeyendaPago.Style = "text-decoration: underline; ddo-char-set: 1; text-align: center; font-weight: nor" & _
    "mal; font-size: 8.25pt; font-family: Tahoma"
        Me.lblLeyendaPago.Text = "_____Pago hecho en una sola exhibición_____"
        Me.lblLeyendaPago.Top = 3.478346!
        Me.lblLeyendaPago.Width = 2.440945!
        '
        'tbTipoVenta
        '
        Me.tbTipoVenta.Height = 0.15748!
        Me.tbTipoVenta.Left = 0.2559054!
        Me.tbTipoVenta.Name = "tbTipoVenta"
        Me.tbTipoVenta.Style = "ddo-char-set: 0; font-size: 9pt; font-family: Tahoma"
        Me.tbTipoVenta.Text = "TipoVenta"
        Me.tbTipoVenta.Top = 1.578576!
        Me.tbTipoVenta.Width = 1.5625!
        '
        'lblCaja
        '
        Me.lblCaja.Height = 0.1574798!
        Me.lblCaja.HyperLink = Nothing
        Me.lblCaja.Left = 0.2559055!
        Me.lblCaja.Name = "lblCaja"
        Me.lblCaja.Style = "ddo-char-set: 0; font-weight: normal; font-size: 9pt; font-family: Tahoma"
        Me.lblCaja.Text = "CAJA"
        Me.lblCaja.Top = 1.379921!
        Me.lblCaja.Width = 1.25!
        '
        'lblFactura
        '
        Me.lblFactura.Height = 0.1574803!
        Me.lblFactura.HyperLink = Nothing
        Me.lblFactura.Left = 0.2559054!
        Me.lblFactura.Name = "lblFactura"
        Me.lblFactura.Style = "font-size: 9pt; font-family: Tahoma"
        Me.lblFactura.Text = "APLICA A FACTURA: "
        Me.lblFactura.Top = 1.178642!
        Me.lblFactura.Width = 1.318898!
        '
        'LblDomTienda
        '
        Me.LblDomTienda.Height = 0.1574803!
        Me.LblDomTienda.HyperLink = Nothing
        Me.LblDomTienda.Left = 2.75!
        Me.LblDomTienda.Name = "LblDomTienda"
        Me.LblDomTienda.Style = "text-align: center; font-size: 8.25pt; font-family: Tahoma"
        Me.LblDomTienda.Text = "Direccion"
        Me.LblDomTienda.Top = 1.5!
        Me.LblDomTienda.Visible = False
        Me.LblDomTienda.Width = 2.362204!
        '
        'LblTelefono
        '
        Me.LblTelefono.Height = 0.1574803!
        Me.LblTelefono.HyperLink = Nothing
        Me.LblTelefono.Left = 2.75!
        Me.LblTelefono.Name = "LblTelefono"
        Me.LblTelefono.Style = "text-align: center; font-size: 8.25pt; font-family: Tahoma"
        Me.LblTelefono.Text = "Telefono"
        Me.LblTelefono.Top = 1.25!
        Me.LblTelefono.Visible = False
        Me.LblTelefono.Width = 2.362205!
        '
        'LblLocaliz
        '
        Me.LblLocaliz.Height = 0.1574803!
        Me.LblLocaliz.HyperLink = Nothing
        Me.LblLocaliz.Left = 2.75!
        Me.LblLocaliz.Name = "LblLocaliz"
        Me.LblLocaliz.Style = "text-align: center; font-size: 8.25pt; font-family: Tahoma"
        Me.LblLocaliz.Text = "Ciudad Estado"
        Me.LblLocaliz.Top = 1.25!
        Me.LblLocaliz.Visible = False
        Me.LblLocaliz.Width = 2.362204!
        '
        'Label16
        '
        Me.Label16.Height = 0.1574803!
        Me.Label16.HyperLink = Nothing
        Me.Label16.Left = 0.25!
        Me.Label16.Name = "Label16"
        Me.Label16.Style = "text-align: center; font-weight: bold; font-size: 9pt; font-family: Tahoma"
        Me.Label16.Text = "SUCURSAL:"
        Me.Label16.Top = 0.07234236!
        Me.Label16.Width = 2.43061!
        '
        'Label19
        '
        Me.Label19.Height = 0.1574803!
        Me.Label19.HyperLink = Nothing
        Me.Label19.Left = 2.75!
        Me.Label19.Name = "Label19"
        Me.Label19.Style = "text-align: center; font-size: 8.25pt; font-family: Tahoma"
        Me.Label19.Text = "R.F.C. CDP-950126-9M5"
        Me.Label19.Top = 1.25!
        Me.Label19.Visible = False
        Me.Label19.Width = 2.362204!
        '
        'LblCopia
        '
        Me.LblCopia.Height = 0.1574805!
        Me.LblCopia.HyperLink = Nothing
        Me.LblCopia.Left = 0.25!
        Me.LblCopia.Name = "LblCopia"
        Me.LblCopia.Style = "text-align: center; font-weight: bold; font-size: 8.25pt; font-family: Tahoma; ve" & _
    "rtical-align: top"
        Me.LblCopia.Text = "COPIA DE FACTURA"
        Me.LblCopia.Top = 0.4375!
        Me.LblCopia.Width = 2.431103!
        '
        'txtDomTienda
        '
        Me.txtDomTienda.Height = 0.28!
        Me.txtDomTienda.Left = 2.75!
        Me.txtDomTienda.Name = "txtDomTienda"
        Me.txtDomTienda.Style = "text-align: center; font-size: 8.25pt; font-family: Tahoma"
        Me.txtDomTienda.Text = "Direccion"
        Me.txtDomTienda.Top = 1.25!
        Me.txtDomTienda.Visible = False
        Me.txtDomTienda.Width = 2.362205!
        '
        'TxtTienda
        '
        Me.TxtTienda.Height = 0.1574803!
        Me.TxtTienda.Left = 2.75!
        Me.TxtTienda.Name = "TxtTienda"
        Me.TxtTienda.Style = "text-align: center; font-size: 8.25pt; font-family: Tahoma; vertical-align: top"
        Me.TxtTienda.Text = "Tienda"
        Me.TxtTienda.Top = 1.25!
        Me.TxtTienda.Visible = False
        Me.TxtTienda.Width = 2.362205!
        '
        'lblCancelacion
        '
        Me.lblCancelacion.Height = 0.1574803!
        Me.lblCancelacion.HyperLink = Nothing
        Me.lblCancelacion.Left = 0.2559054!
        Me.lblCancelacion.Name = "lblCancelacion"
        Me.lblCancelacion.Style = "font-size: 9pt; font-family: Tahoma"
        Me.lblCancelacion.Text = "FOLIO CANCELACION: "
        Me.lblCancelacion.Top = 0.9911417!
        Me.lblCancelacion.Width = 1.318898!
        '
        'tbFCancelacion
        '
        Me.tbFCancelacion.Height = 0.1574803!
        Me.tbFCancelacion.Left = 1.64042!
        Me.tbFCancelacion.Name = "tbFCancelacion"
        Me.tbFCancelacion.Style = "ddo-char-set: 0; text-align: left; font-weight: normal; font-size: 9pt; font-fami" & _
    "ly: Tahoma"
        Me.tbFCancelacion.Text = "FACT"
        Me.tbFCancelacion.Top = 1.002953!
        Me.tbFCancelacion.Width = 1.049869!
        '
        'txtInfoSuc
        '
        Me.txtInfoSuc.Height = 0.1875!
        Me.txtInfoSuc.Left = 0.25!
        Me.txtInfoSuc.Name = "txtInfoSuc"
        Me.txtInfoSuc.Style = "text-align: center; font-size: 8.25pt"
        Me.txtInfoSuc.Text = "InfoSuc"
        Me.txtInfoSuc.Top = 0.25!
        Me.txtInfoSuc.Width = 2.4245!
        '
        'tbNombreDes
        '
        Me.tbNombreDes.CanShrink = True
        Me.tbNombreDes.Height = 0.1574803!
        Me.tbNombreDes.Left = 0.2559055!
        Me.tbNombreDes.Name = "tbNombreDes"
        Me.tbNombreDes.Style = "ddo-char-set: 0; font-size: 9.75pt; font-family: Arial"
        Me.tbNombreDes.Text = "Nombre"
        Me.tbNombreDes.Top = 2.97851!
        Me.tbNombreDes.Width = 2.46063!
        '
        'tbDomicilioDes
        '
        Me.tbDomicilioDes.CanShrink = True
        Me.tbDomicilioDes.Height = 0.1574802!
        Me.tbDomicilioDes.Left = 0.2559055!
        Me.tbDomicilioDes.Name = "tbDomicilioDes"
        Me.tbDomicilioDes.Style = "ddo-char-set: 0; font-size: 9.75pt; font-family: Arial"
        Me.tbDomicilioDes.Text = "Domicilio"
        Me.tbDomicilioDes.Top = 3.178477!
        Me.tbDomicilioDes.Width = 2.440945!
        '
        'Label36
        '
        Me.Label36.Height = 0.1875!
        Me.Label36.HyperLink = Nothing
        Me.Label36.Left = 0.25!
        Me.Label36.Name = "Label36"
        Me.Label36.Style = "font-weight: bold; font-size: 9.75pt; font-family: Arial"
        Me.Label36.Text = "VENDIDO A"
        Me.Label36.Top = 2.125!
        Me.Label36.Width = 2.461!
        '
        'Label37
        '
        Me.Label37.Height = 0.1875!
        Me.Label37.HyperLink = Nothing
        Me.Label37.Left = 0.25!
        Me.Label37.Name = "Label37"
        Me.Label37.Style = "font-weight: bold; font-size: 9.75pt; font-family: Arial"
        Me.Label37.Text = "ENVIADO A"
        Me.Label37.Top = 2.75!
        Me.Label37.Width = 2.461!
        '
        'txtLeyendaEcommerce
        '
        Me.txtLeyendaEcommerce.Height = 0.3125!
        Me.txtLeyendaEcommerce.HyperLink = Nothing
        Me.txtLeyendaEcommerce.Left = 0.25!
        Me.txtLeyendaEcommerce.Name = "txtLeyendaEcommerce"
        Me.txtLeyendaEcommerce.Style = "text-align: center; font-weight: bold; font-size: 8.25pt; font-family: Tahoma; ve" & _
    "rtical-align: top"
        Me.txtLeyendaEcommerce.Text = ""
        Me.txtLeyendaEcommerce.Top = 0.625!
        Me.txtLeyendaEcommerce.Width = 2.431103!
        '
        'ReportFooter
        '
        Me.ReportFooter.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.tbSubTotal, Me.tbPlayer, Me.SubReport1, Me.Label1, Me.Label2, Me.tbTotalLetras, Me.SubReport2, Me.TxtBxSubTotSinDescto, Me.Label20, Me.TxtSubTotIva, Me.Line3, Me.lblAPagar, Me.tbLeyendaAduana, Me.lblNotas, Me.txtPagina})
        Me.ReportFooter.Height = 2.269154!
        Me.ReportFooter.Name = "ReportFooter"
        '
        'tbSubTotal
        '
        Me.tbSubTotal.Height = 0.178642!
        Me.tbSubTotal.Left = 1.732783!
        Me.tbSubTotal.Name = "tbSubTotal"
        Me.tbSubTotal.OutputFormat = resources.GetString("tbSubTotal.OutputFormat")
        Me.tbSubTotal.Style = "ddo-char-set: 0; text-align: right; font-size: 9pt; font-family: Arial"
        Me.tbSubTotal.Text = Nothing
        Me.tbSubTotal.Top = 0.3061021!
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
        'SubReport1
        '
        Me.SubReport1.CloseBorder = False
        Me.SubReport1.Height = 0.6924215!
        Me.SubReport1.Left = 0.8336611!
        Me.SubReport1.Name = "SubReport1"
        Me.SubReport1.Report = Nothing
        Me.SubReport1.Top = 1.017224!
        Me.SubReport1.Width = 1.6875!
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
        'Label2
        '
        Me.Label2.Height = 0.1412403!
        Me.Label2.HyperLink = Nothing
        Me.Label2.Left = 0.3622047!
        Me.Label2.Name = "Label2"
        Me.Label2.Style = "text-align: right; font-weight: normal; font-size: 8.25pt; font-family: Tahoma"
        Me.Label2.Text = "PAGO:"
        Me.Label2.Top = 1.017224!
        Me.Label2.Visible = False
        Me.Label2.Width = 0.3937007!
        '
        'tbTotalLetras
        '
        Me.tbTotalLetras.Height = 0.2!
        Me.tbTotalLetras.Left = 0.2559055!
        Me.tbTotalLetras.Name = "tbTotalLetras"
        Me.tbTotalLetras.Style = "font-weight: normal; font-size: 8.25pt; font-family: Tahoma"
        Me.tbTotalLetras.Text = Nothing
        Me.tbTotalLetras.Top = 0.534941!
        Me.tbTotalLetras.Width = 2.440945!
        '
        'SubReport2
        '
        Me.SubReport2.CanGrow = False
        Me.SubReport2.CanShrink = False
        Me.SubReport2.CloseBorder = False
        Me.SubReport2.Height = 0.3897638!
        Me.SubReport2.Left = 0.2662401!
        Me.SubReport2.Name = "SubReport2"
        Me.SubReport2.Report = Nothing
        Me.SubReport2.Top = 1.367126!
        Me.SubReport2.Visible = False
        Me.SubReport2.Width = 0.3149605!
        '
        'TxtBxSubTotSinDescto
        '
        Me.TxtBxSubTotSinDescto.DataField = "TOTAL"
        Me.TxtBxSubTotSinDescto.Height = 0.1574803!
        Me.TxtBxSubTotSinDescto.Left = 1.732783!
        Me.TxtBxSubTotSinDescto.Name = "TxtBxSubTotSinDescto"
        Me.TxtBxSubTotSinDescto.OutputFormat = resources.GetString("TxtBxSubTotSinDescto.OutputFormat")
        Me.TxtBxSubTotSinDescto.Style = "ddo-char-set: 0; text-align: right; font-size: 9pt; font-family: Arial"
        Me.TxtBxSubTotSinDescto.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
        Me.TxtBxSubTotSinDescto.Text = Nothing
        Me.TxtBxSubTotSinDescto.Top = 0.05610216!
        Me.TxtBxSubTotSinDescto.Width = 0.944882!
        '
        'Label20
        '
        Me.Label20.Height = 0.1574802!
        Me.Label20.HyperLink = Nothing
        Me.Label20.Left = 0.0625!
        Me.Label20.Name = "Label20"
        Me.Label20.Style = "text-align: right; font-size: 9pt; font-family: Arial"
        Me.Label20.Text = "SUBTOTAL SIN DESC.:"
        Me.Label20.Top = 0.05610216!
        Me.Label20.Width = 1.591044!
        '
        'TxtSubTotIva
        '
        Me.TxtSubTotIva.Height = 0.1574802!
        Me.TxtSubTotIva.Left = 0.3149606!
        Me.TxtSubTotIva.Name = "TxtSubTotIva"
        Me.TxtSubTotIva.Style = "ddo-char-set: 0; text-align: right; font-size: 9pt; font-family: Arial"
        Me.TxtSubTotIva.Text = Nothing
        Me.TxtSubTotIva.Top = 0.3061024!
        Me.TxtSubTotIva.Width = 1.338583!
        '
        'Line3
        '
        Me.Line3.Height = 0.0!
        Me.Line3.Left = 0.243165!
        Me.Line3.LineWeight = 1.0!
        Me.Line3.Name = "Line3"
        Me.Line3.Top = 0.0231846!
        Me.Line3.Width = 2.362!
        Me.Line3.X1 = 0.243165!
        Me.Line3.X2 = 2.605165!
        Me.Line3.Y1 = 0.0231846!
        Me.Line3.Y2 = 0.0231846!
        '
        'lblAPagar
        '
        Me.lblAPagar.Height = 0.4330709!
        Me.lblAPagar.HyperLink = Nothing
        Me.lblAPagar.Left = 0.266!
        Me.lblAPagar.Name = "lblAPagar"
        Me.lblAPagar.Style = "ddo-char-set: 1; text-align: justify; font-weight: bold; font-size: 8.25pt; font-" & _
    "family: Tahoma"
        Me.lblAPagar.Text = ""
        Me.lblAPagar.Top = 2.284!
        Me.lblAPagar.Width = 2.362369!
        '
        'tbLeyendaAduana
        '
        Me.tbLeyendaAduana.Height = 0.652559!
        Me.tbLeyendaAduana.Left = 0.2559055!
        Me.tbLeyendaAduana.Name = "tbLeyendaAduana"
        Me.tbLeyendaAduana.Style = "text-align: justify; font-weight: normal; font-size: 8.25pt; font-family: Tahoma"
        Me.tbLeyendaAduana.Text = "Por medio de esta nota de venta, se transporta mercancia importada que NO ES DE V" & _
    "ENTA DE PRIMERA MANO, esto conforme al Art. 29-A Código Fiscal de la Federacion," & _
    " FRACCION VII"
        Me.tbLeyendaAduana.Top = 1.034941!
        Me.tbLeyendaAduana.Width = 2.440945!
        '
        'lblNotas
        '
        Me.lblNotas.Height = 0.1574803!
        Me.lblNotas.Left = 0.2654202!
        Me.lblNotas.Name = "lblNotas"
        Me.lblNotas.Style = "ddo-char-set: 0; text-align: justify; font-weight: normal; font-size: 9pt; font-f" & _
    "amily: Tahoma"
        Me.lblNotas.Text = Nothing
        Me.lblNotas.Top = 1.752953!
        Me.lblNotas.Width = 2.362369!
        '
        'PageHeader
        '
        Me.PageHeader.CanShrink = True
        Me.PageHeader.Height = 0.0!
        Me.PageHeader.Name = "PageHeader"
        '
        'PageFooter
        '
        Me.PageFooter.Height = 0.0!
        Me.PageFooter.Name = "PageFooter"
        '
        'txtPagina
        '
        Me.txtPagina.Height = 0.2!
        Me.txtPagina.Left = 0.256!
        Me.txtPagina.Name = "txtPagina"
        Me.txtPagina.Style = "font-weight: bold; font-size: 8.25pt; font-family: Tahoma; text-align: center"
        Me.txtPagina.Text = Nothing
        Me.txtPagina.Top = 1.964!
        Me.txtPagina.Width = 2.440945!
        '
        'rptFacturacionEC
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
        Me.PrintWidth = 2.8125!
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
        CType(Me.tbConcepto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbPUnitario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbCantidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbCodigo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbNumero, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbDesc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbTotalConDesc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label35, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbCantDesc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.label34, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblQuincenas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbNombre, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbFactura, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbDomicilio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbLugarFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblLeyendaPago, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbTipoVenta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblCaja, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFactura, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblDomTienda, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblTelefono, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblLocaliz, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label19, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblCopia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDomTienda, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtTienda, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblCancelacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbFCancelacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtInfoSuc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbNombreDes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbDomicilioDes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label36, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label37, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtLeyendaEcommerce, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbSubTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbPlayer, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbTotalLetras, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtBxSubTotSinDescto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label20, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtSubTotIva, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblAPagar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbLeyendaAduana, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblNotas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPagina, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

#End Region


End Class
