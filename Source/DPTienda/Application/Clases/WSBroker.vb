'Imports MSXML2
Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Collections.Generic
Imports Newtonsoft.Json
Public Class WSBroker

#Region "Variables"
    Private URL As String
    Private Puerto As String
    Private Method As String
    Private CallMethod As String
    Private request As String
    Private oRest As ServiciosREST
    Private htParametros As Hashtable
    Private Satelite As String
#End Region

#Region "Constructores"

    Public Sub New()
        Me.URL = oConfigCierreFI.ServerBroker
        Me.Puerto = oConfigCierreFI.PuertoBroker
        Me.request = ""
       
    End Sub

    Public Sub New(ByVal Metodo As String)
        Me.URL = oConfigCierreFI.ServerBroker
        Me.Puerto = oConfigCierreFI.PuertoBroker
        Me.Method = Metodo
        Me.CallMethod = Me.URL & ":" & Me.Puerto & "/" & Me.Method & "?wsdl"
        Me.request = ""
    End Sub

    Public Sub New(ByVal Metodo As String, ByVal NuevoBroker As Boolean)
        Me.URL = oConfigCierreFI.ServerBrokerNew
        Me.Puerto = oConfigCierreFI.PuertoBrokerNew
        Me.Method = Metodo
        Me.CallMethod = Me.URL & ":" & Me.Puerto & "/" & Me.Method & "?wsdl"
        Me.request = ""
        
    End Sub
    'ASANCHEZ 30/03/2021 Metodo del Ws de blue el nuevo
    Public Sub New(ByVal Metodo As String, ByVal servicio As String)
        Me.URL = oConfigCierreFI.ServerLealtad
        Me.Puerto = oConfigCierreFI.PuertoLealtad
        Me.Method = Metodo
        Me.CallMethod = Me.URL & ":" & Me.Puerto & "/" & Me.Method & "/" & servicio
        Me.request = ""
        Me.Satelite = "DPPRO"
        Me.oRest = New ServiciosREST(Me.URL)
        Me.htParametros = New Hashtable
    End Sub
#End Region

#Region "Metodos de Webservices"

    Public Function GetMetasDiasPlayer(ByVal Tienda As String, ByVal FechaInicio As DateTime, ByVal FechaFin As DateTime) As DataTable
        Dim dtResponse As New DataTable
        Me.request &= "<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:met=""http://tempuri.org/METAS_MS"">"
        Me.request &= "<soapenv:Header/>"
        Me.request &= "<soapenv:Body>"
        Me.request &= "<met:METAS_MESSAGE>"
        Me.request &= "<TIENDA>" & Tienda & "</TIENDA>"
        Me.request &= "<FECHAINICIO>" & FechaInicio.ToString("yyyy-MM-dd") & "</FECHAINICIO>"
        Me.request &= "<FECHAFIN>" & FechaFin.ToString("yyyy-MM-dd") & "</FECHAFIN>"
        Me.request &= "</met:METAS_MESSAGE>"
        Me.request &= "</soapenv:Body>"
        Me.request &= "</soapenv:Envelope>"
        Dim dsResponse As DataSet = ConsumeXML(Me.CallMethod, Me.request)
        'Dim dsResponse As DataSet = ConsumeWSBroker(Me.CallMethod, Me.request)
        If Not dsResponse Is Nothing Then
            If dsResponse.Tables.Contains("TABLE") = True Then
                dtResponse = dsResponse.Tables("TABLE").Copy()
                dtResponse = ValidarColumna("CODALMACEN", dtResponse)
                dtResponse = ValidarColumna("ALMACEN", dtResponse)
                dtResponse = ValidarColumna("METAEMPLEADO", dtResponse)
                dtResponse = ValidarColumna("CODEMPLEADO", dtResponse)
                dtResponse = ValidarColumna("PUESTO", dtResponse)
                dtResponse = ValidarColumna("METATIENDA", dtResponse)
            End If
        End If
        Return dtResponse
    End Function

    '------------------------------------------------------------------------------------------------
    'FLIZARRAGA 20/02/2015: Invoca WebService que Realiza la venta con Karum
    '------------------------------------------------------------------------------------------------

    Public Function Purchase(ByVal parameter As Hashtable) As Hashtable
        Dim dsResultado As New DataSet
        Dim resultado As New Hashtable
        Dim ArticuloMgr As New DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos.CatalogoArticuloManager(oAppContext)
        Dim articulo As DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos.Articulo
        Dim total As Decimal = 0, descSistema As Decimal = 0, descuento As Decimal = 0, unitPrice As Decimal = 0
        Dim cantidad As Decimal = 0, totalMonto As Decimal = 0
        Dim dtDetalle As DataTable = CType(parameter("Detalles"), DataTable)
        Dim totalTruncada As Decimal, montoKarum As Decimal
        montoKarum = CDec(parameter("Monto"))
        Me.request = "<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:ws=""http://WS_KARUM"">"
        Me.request &= "<soapenv:Header/>"
        Me.request &= "<soapenv:Body>"
        Me.request &= "<ws:DPT_Purchase>"
        Me.request &= "<NoTarjeta>" & CStr(parameter("NoTarjeta")) & "</NoTarjeta>"
        'For Each row As DataRow In dtDetalle.Rows
        '    articulo = ArticuloMgr.Load(CStr(row("Codigo")))
        '    total = 0
        '    descSistema = 0
        '    descuento = 0
        '    unitPrice = 0
        '    cantidad = 0
        '    cantidad = Decimal.Round(CDec(row("Cantidad")), 2)
        '    total = Decimal.Round(CDec(row("Total")), 2)
        '    descSistema = Decimal.Round(CDec(row("Descuento")), 2)
        '    total = total - descSistema
        '    descuento = Decimal.Round(CDec(row("Adicional")), 2)
        '    descuento = total * (descuento / 100)
        '    total -= descuento
        '    total = Truncar(total * (1 + oAppContext.ApplicationConfiguration.IVA), 2)
        '    unitPrice = Truncar(total / cantidad, 2)
        '    'unitPrice = Truncar(unitPrice, 2)
        '    total = Truncar(unitPrice * cantidad, 2)
        '    totalMonto += total
        'Next
        'If montoKarum < totalMonto Then
        '    totalMonto = montoKarum
        'End If
        totalMonto = montoKarum
        Me.request &= "<Monto>" & totalMonto.ToString("##,##0.00").Replace(",", "") & "</Monto>"
        Me.request &= "<Promocion>" & CStr(parameter("Promocion")).PadLeft(2, "0") & "</Promocion>"
        Me.request &= "<Fecha>" & CStr(parameter("Fecha")) & "</Fecha>"
        'Me.request &= "<ConsecutivoPOS>" & CStr(parameter("ConsecutivoPOS")) & "</ConsecutivoPOS>"
        Me.request &= "<ConsecutivoPOS></ConsecutivoPOS>"
        Me.request &= "<IDPOS>" & CStr(parameter("IDPOS")) & "</IDPOS>"
        Me.request &= "<IDTienda>" & CStr(parameter("IDTienda")) & "</IDTienda>"
        Me.request &= "<Tipo>" & CStr(parameter("Tipo")) & "</Tipo>"
        Me.request &= "<IDTransaccion>" & CStr(parameter("IDTransaccion")) & "</IDTransaccion>"
        'Quedo pendiente agregar los detalles
        For Each row As DataRow In dtDetalle.Rows
            articulo = ArticuloMgr.Load(CStr(row("Codigo")))
            total = 0
            descSistema = 0
            descuento = 0
            unitPrice = 0
            cantidad = 0
            Me.request &= "<Detalles>"
            Me.request &= "<SkuUpcCode>" & articulo.Jerarquia.Remove(0, 1) & "</SkuUpcCode>"
            Me.request &= "<Quantity>" & CStr(row("Cantidad")) & "</Quantity>"
            cantidad = Decimal.Round(CDec(row("Cantidad")), 2)
            'total = Decimal.Round(CDec(row("Total")), 2)
            total = row("Total")
            'descSistema = Decimal.Round(CDec(row("Descuento")), 2)
            descSistema = row("Descuento")
            total = total - descSistema
            'descuento = Decimal.Round(CDec(row("Adicional")), 2)
            descuento = row("Adicional")
            descuento = total * (descuento / 100)

            unitPrice = row("Importe") - (descSistema / cantidad) - (descuento / cantidad)
            unitPrice = Decimal.Round(unitPrice * (1 + oAppContext.ApplicationConfiguration.IVA), 2)

            'total -= descuento
            'total = Truncar(total * (1 + oAppContext.ApplicationConfiguration.IVA), 2)
            'unitPrice = Truncar((total / cantidad), 2)

            '******esta ya estaba comentada******
            'unitPrice = Truncar(unitPrice, 2)

            'total = Truncar(unitPrice * cantidad, 2)
            total = unitPrice * cantidad
            Me.request &= "<UnitPrice>" & unitPrice.ToString("##,##0.00").Replace(",", "") & "</UnitPrice>"
            'Me.request &= "<Amount>" & TruncarTotales(total).ToString("##,##0.00").Replace(",", "") & "</Amount>"
            Me.request &= "<Amount>" & total.ToString("##,##0.00").Replace(",", "") & "</Amount>"

            '**** ya estaba comentado *****
            'Me.request &= "<UnitPrice>" & CStr(Math.Round(unitPrice * (1 + oAppContext.ApplicationConfiguration.IVA), 2)) & "</UnitPrice>"
            'Me.request &= "<Amount>" & TruncarTotales(Math.Round(total * (1 + oAppContext.ApplicationConfiguration.IVA), 2)).ToString("##,##0.00").Replace(",", "") & "</Amount>"
            Me.request &= "</Detalles>"
        Next
        Me.request &= "</ws:DPT_Purchase>"
        Me.request &= "</soapenv:Body>"
        Me.request &= "</soapenv:Envelope>"
        dsResultado = ConsumeXML(Me.CallMethod, Me.request)
        'dsResultado = ConsumeWSBroker(Me.CallMethod, Me.request)
        'ActualizarConsecutivoPOS()
        If Not dsResultado Is Nothing Then
            If dsResultado.Tables.Contains("DPT_PurchaseResponse") = True Then
                resultado("Monto") = totalMonto
                Dim table As DataTable = dsResultado.Tables("DPT_PurchaseResponse")
                For Each row As DataRow In table.Rows
                    For Each column As DataColumn In table.Columns
                        If row.IsNull(column.ColumnName) = False Then
                            resultado(column.ColumnName) = row(column.ColumnName)
                        End If
                    Next
                Next
            ElseIf dsResultado.Tables.Contains("Message") = True Then
                Dim table As DataTable = dsResultado.Tables("Message")
                For Each row As DataRow In table.Rows
                    For Each column As DataColumn In table.Columns
                        If row.IsNull(column.ColumnName) = False Then
                            resultado(column.ColumnName) = row(column.ColumnName)
                        End If
                    Next
                Next
            End If
        End If
        Return resultado
    End Function

    '------------------------------------------------------------------------------------------------
    'FLIZARRAGA 17/10/2017: Invoca WebService que Realiza el prestamo de dinero
    '------------------------------------------------------------------------------------------------

    Public Function PurchasePrestamo(ByVal parameter As Hashtable) As Hashtable
        Dim dsResultado As New DataSet
        Dim resultado As New Hashtable
        Dim ArticuloMgr As New DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos.CatalogoArticuloManager(oAppContext)
        Dim articulo As DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos.Articulo
        Dim total As Decimal = 0, descSistema As Decimal = 0, descuento As Decimal = 0, unitPrice As Decimal = 0
        Dim cantidad As Decimal = 0, totalMonto As Decimal = 0
        Dim dtDetalle As DataTable = CType(parameter("Detalles"), DataTable)
        Dim totalTruncada As Decimal, montoKarum As Decimal
        montoKarum = CDec(parameter("Monto"))
        Me.request = "<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:ws=""http://WS_KARUM"">"
        Me.request &= "<soapenv:Header/>"
        Me.request &= "<soapenv:Body>"
        Me.request &= "<ws:DPT_Purchase>"
        Me.request &= "<NoTarjeta>" & CStr(parameter("NoTarjeta")) & "</NoTarjeta>"
        totalMonto = montoKarum
        Me.request &= "<Monto>" & totalMonto.ToString("##,##0.00").Replace(",", "") & "</Monto>"
        Me.request &= "<Promocion>" & CStr(parameter("Promocion")).PadLeft(2, "0") & "</Promocion>"
        Me.request &= "<Fecha>" & CStr(parameter("Fecha")) & "</Fecha>"
        Me.request &= "<ConsecutivoPOS></ConsecutivoPOS>"
        Me.request &= "<IDPOS>" & CStr(parameter("IDPOS")) & "</IDPOS>"
        Me.request &= "<IDTienda>" & CStr(parameter("IDTienda")) & "</IDTienda>"
        Me.request &= "<Tipo>" & CStr(parameter("Tipo")) & "</Tipo>"
        Me.request &= "<IDTransaccion>" & CStr(parameter("IDTransaccion")) & "</IDTransaccion>"
        Me.request &= "<Detalles>"
        Me.request &= "<SkuUpcCode>" & CStr(parameter("SKU")) & "</SkuUpcCode>"
        Me.request &= "<Quantity>1</Quantity>"
        Me.request &= "<UnitPrice>" & totalMonto.ToString("##,##0.00").Replace(",", "") & "</UnitPrice>"
        Me.request &= "<Amount>" & totalMonto.ToString("##,##0.00").Replace(",", "") & "</Amount>"
        Me.request &= "</Detalles>"
        Me.request &= "</ws:DPT_Purchase>"
        Me.request &= "</soapenv:Body>"
        Me.request &= "</soapenv:Envelope>"
        dsResultado = ConsumeXML(Me.CallMethod, Me.request)
        If Not dsResultado Is Nothing Then
            If dsResultado.Tables.Contains("DPT_PurchaseResponse") = True Then
                resultado("Monto") = totalMonto
                Dim table As DataTable = dsResultado.Tables("DPT_PurchaseResponse")
                For Each row As DataRow In table.Rows
                    For Each column As DataColumn In table.Columns
                        If row.IsNull(column.ColumnName) = False Then
                            resultado(column.ColumnName) = row(column.ColumnName)
                        End If
                    Next
                Next
            ElseIf dsResultado.Tables.Contains("Message") = True Then
                Dim table As DataTable = dsResultado.Tables("Message")
                For Each row As DataRow In table.Rows
                    For Each column As DataColumn In table.Columns
                        If row.IsNull(column.ColumnName) = False Then
                            resultado(column.ColumnName) = row(column.ColumnName)
                        End If
                    Next
                Next
            End If
        End If
        Return resultado
    End Function

    Public Function PurchaseVirtual(ByVal parameter As Hashtable) As Hashtable
        Dim dsResultado As New DataSet
        Dim resultado As New Hashtable
        Dim ArticuloMgr As New DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos.CatalogoArticuloManager(oAppContext)
        Dim articulo As DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos.Articulo
        Dim total As Decimal = 0, descSistema As Decimal = 0, descuento As Decimal = 0, unitPrice As Decimal = 0
        Dim cantidad As Decimal = 0, totalMonto As Decimal = 0
        Dim dtDetalle As DataTable = CType(parameter("Detalles"), DataTable)
        Dim totalTruncada As Decimal, montoKarum As Decimal
        montoKarum = CDec(parameter("Monto"))
        Me.request = "<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:ws=""http://WS_KARUM"">"
        Me.request &= "<soapenv:Header/>"
        Me.request &= "<soapenv:Body>"
        Me.request &= "<ws:DPT_Purchase>"
        Me.request &= "<NoTarjeta>" & CStr(parameter("NoTarjeta")) & "</NoTarjeta>"
        'For Each row As DataRow In dtDetalle.Rows
        '    articulo = ArticuloMgr.Load(CStr(row("Codigo")))
        '    total = 0
        '    descSistema = 0
        '    descuento = 0
        '    unitPrice = 0
        '    cantidad = 0
        '    cantidad = Decimal.Round(CDec(row("Cantidad")), 2)
        '    total = Decimal.Round(CDec(row("Total")), 2)
        '    descSistema = Decimal.Round(CDec(row("Descuento")), 2)
        '    total = total - descSistema
        '    descuento = Decimal.Round(CDec(row("Adicional")), 2)
        '    descuento = total * (descuento / 100)
        '    total -= descuento
        '    total = Truncar(total * (1 + oAppContext.ApplicationConfiguration.IVA), 2)
        '    unitPrice = Truncar(total / cantidad, 2)
        '    'unitPrice = Truncar(unitPrice, 2)
        '    total = Truncar(unitPrice * cantidad, 2)
        '    totalMonto += total
        'Next
        'If montoKarum < totalMonto Then
        '    totalMonto = montoKarum
        'End If
        totalMonto = montoKarum
        Me.request &= "<Monto>" & totalMonto.ToString("##,##0.00").Replace(",", "") & "</Monto>"
        Me.request &= "<Promocion>" & CStr(parameter("Promocion")).PadLeft(2, "0") & "</Promocion>"
        Me.request &= "<Fecha>" & CStr(parameter("Fecha")) & "</Fecha>"
        'Me.request &= "<ConsecutivoPOS>" & CStr(parameter("ConsecutivoPOS")) & "</ConsecutivoPOS>"
        Me.request &= "<ConsecutivoPOS></ConsecutivoPOS>"
        Me.request &= "<IDPOS>" & CStr(parameter("IDPOS")) & "</IDPOS>"
        Me.request &= "<IDTienda>" & CStr(parameter("IDTienda")) & "</IDTienda>"
        Me.request &= "<Tipo>" & CStr(parameter("Tipo")) & "</Tipo>"
        Me.request &= "<IDTransaccion>" & CStr(parameter("IDTransaccion")) & "</IDTransaccion>"
        'Quedo pendiente agregar los detalles
        For Each row As DataRow In dtDetalle.Rows
            total = 0
            descSistema = 0
            descuento = 0
            unitPrice = 0
            cantidad = 0
            Me.request &= "<Detalles>"
            Me.request &= "<SkuUpcCode>" & CStr(row("Codigo")) & "</SkuUpcCode>"
            Me.request &= "<Quantity>" & CStr(row("Cantidad")) & "</Quantity>"
            cantidad = Decimal.Round(CDec(row("Cantidad")), 2)
            'total = Decimal.Round(CDec(row("Total")), 2)
            total = row("Total")
            'descSistema = Decimal.Round(CDec(row("Descuento")), 2)
            descSistema = row("Descuento")
            total = total - descSistema
            'descuento = Decimal.Round(CDec(row("Adicional")), 2)
            descuento = row("Adicional")
            descuento = total * (descuento / 100)

            unitPrice = row("Importe") - (descSistema / cantidad) - (descuento / cantidad)
            unitPrice = Decimal.Round(unitPrice * (1 + oAppContext.ApplicationConfiguration.IVA), 2)

            'total -= descuento
            'total = Truncar(total * (1 + oAppContext.ApplicationConfiguration.IVA), 2)
            'unitPrice = Truncar((total / cantidad), 2)

            '******esta ya estaba comentada******
            'unitPrice = Truncar(unitPrice, 2)

            'total = Truncar(unitPrice * cantidad, 2)
            total = unitPrice * cantidad
            Me.request &= "<UnitPrice>" & unitPrice.ToString("##,##0.00").Replace(",", "") & "</UnitPrice>"
            'Me.request &= "<Amount>" & TruncarTotales(total).ToString("##,##0.00").Replace(",", "") & "</Amount>"
            Me.request &= "<Amount>" & total.ToString("##,##0.00").Replace(",", "") & "</Amount>"

            '**** ya estaba comentado *****
            'Me.request &= "<UnitPrice>" & CStr(Math.Round(unitPrice * (1 + oAppContext.ApplicationConfiguration.IVA), 2)) & "</UnitPrice>"
            'Me.request &= "<Amount>" & TruncarTotales(Math.Round(total * (1 + oAppContext.ApplicationConfiguration.IVA), 2)).ToString("##,##0.00").Replace(",", "") & "</Amount>"
            Me.request &= "</Detalles>"
        Next
        Me.request &= "</ws:DPT_Purchase>"
        Me.request &= "</soapenv:Body>"
        Me.request &= "</soapenv:Envelope>"
        dsResultado = ConsumeXML(Me.CallMethod, Me.request)
        'dsResultado = ConsumeWSBroker(Me.CallMethod, Me.request)
        'ActualizarConsecutivoPOS()
        If Not dsResultado Is Nothing Then
            If dsResultado.Tables.Contains("DPT_PurchaseResponse") = True Then
                resultado("Monto") = totalMonto
                Dim table As DataTable = dsResultado.Tables("DPT_PurchaseResponse")
                For Each row As DataRow In table.Rows
                    For Each column As DataColumn In table.Columns
                        If row.IsNull(column.ColumnName) = False Then
                            resultado(column.ColumnName) = row(column.ColumnName)
                        End If
                    Next
                Next
            ElseIf dsResultado.Tables.Contains("Message") = True Then
                Dim table As DataTable = dsResultado.Tables("Message")
                For Each row As DataRow In table.Rows
                    For Each column As DataColumn In table.Columns
                        If row.IsNull(column.ColumnName) = False Then
                            resultado(column.ColumnName) = row(column.ColumnName)
                        End If
                    Next
                Next
            End If
        End If
        Return resultado
    End Function

    '------------------------------------------------------------------------------------------------
    'FLIZARRAGA 20/02/2015: Invoca WebService de Pago con Karum
    '------------------------------------------------------------------------------------------------

    Public Function Payment(ByVal parameter As Hashtable) As Hashtable
        Dim dsResultado As New DataSet
        Dim resultado As New Hashtable
        Me.request = "<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:ws=""http://WS_KARUM"">"
        Me.request &= "<soapenv:Header/>"
        Me.request &= "<soapenv:Body>"
        Me.request &= "<ws:DPT_Payment>"
        Me.request &= "<NoTarjeta>" & CStr(parameter("NoTarjeta")) & "</NoTarjeta>"
        Me.request &= "<Monto>" & CStr(parameter("Monto")) & "</Monto>"
        Me.request &= "<Fecha>" & CStr(parameter("Fecha")) & "</Fecha>"
        'Me.request &= "<ConsecutivoPOS>" & CStr(parameter("ConsecutivoPOS")) & "</ConsecutivoPOS>"
        Me.request &= "<ConsecutivoPOS></ConsecutivoPOS>"
        Me.request &= "<IDPOS>" & CStr(parameter("IDPOS")) & "</IDPOS>"
        Me.request &= "<IDTienda>" & CStr(parameter("IDTienda")) & "</IDTienda>"
        Me.request &= "<Tipo>" & CStr(parameter("Tipo")) & "</Tipo>"
        Me.request &= "<Promocion>" & CStr(parameter("Promocion")) & "</Promocion>"
        Me.request &= "</ws:DPT_Payment>"
        Me.request &= "</soapenv:Body>"
        Me.request &= "</soapenv:Envelope>"
        dsResultado = ConsumeXML(Me.CallMethod, Me.request)
        'dsResultado = ConsumeWSBroker(Me.CallMethod, Me.request)
        'ActualizarConsecutivoPOS()
        If Not dsResultado Is Nothing Then
            If dsResultado.Tables.Contains("DPT_PaymentResponse") = True Then
                Dim table As DataTable = dsResultado.Tables("DPT_PaymentResponse")
                For Each row As DataRow In table.Rows
                    For Each column As DataColumn In table.Columns
                        If row.IsNull(column.ColumnName) = False Then
                            resultado(column.ColumnName) = row(column.ColumnName)
                        End If
                    Next
                Next
            ElseIf dsResultado.Tables.Contains("Message") = True Then
                Dim table As DataTable = dsResultado.Tables("Message")
                For Each row As DataRow In table.Rows
                    For Each column As DataColumn In table.Columns
                        If row.IsNull(column.ColumnName) = False Then
                            resultado(column.ColumnName) = row(column.ColumnName)
                        End If
                    Next
                Next
            End If
        End If
        Return resultado
    End Function

    '------------------------------------------------------------------------------------------------
    'FLIZARRAGA 20/02/2015: Invoca WebService para conocer el historial crediticio con Karum
    '------------------------------------------------------------------------------------------------

    Public Function AccountStatus(ByVal parameter As Hashtable) As Hashtable
        Dim dsResultado As New DataSet
        Dim resultado As New Hashtable
        Me.request = "<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:ws=""http://WS_KARUM"">"
        Me.request &= "<soapenv:Header/>"
        Me.request &= "<soapenv:Body>"
        Me.request &= "<ws:DPT_AccountStatus>"
        Me.request &= "<NoTarjeta>" & CStr(parameter("NoTarjeta")) & "</NoTarjeta>"
        Me.request &= "<Fecha>" & CStr(parameter("Fecha")) & "</Fecha>"
        'Me.request &= "<ConsecutivoPOS>" & CStr(parameter("ConsecutivoPOS")) & "</ConsecutivoPOS>"
        Me.request &= "<ConsecutivoPOS></ConsecutivoPOS>"
        Me.request &= "<IDPOS>" & CStr(parameter("IDPOS")) & "</IDPOS>"
        Me.request &= "<IDTienda>" & CStr(parameter("IDTienda")) & "</IDTienda>"
        Me.request &= "<Tipo>" & CStr(parameter("Tipo")) & "</Tipo>"
        Me.request &= "</ws:DPT_AccountStatus>"
        Me.request &= "</soapenv:Body>"
        Me.request &= "</soapenv:Envelope>"
        dsResultado = ConsumeXML(Me.CallMethod, Me.request)
        'dsResultado = ConsumeWSBroker(Me.CallMethod, Me.request)
        'ActualizarConsecutivoPOS()
        If Not dsResultado Is Nothing Then
            If dsResultado.Tables.Contains("DPT_AccountStatusResponse") = True Then
                Dim table As DataTable = dsResultado.Tables("DPT_AccountStatusResponse")
                For Each row As DataRow In table.Rows
                    For Each column As DataColumn In table.Columns
                        If row.IsNull(column.ColumnName) = False Then
                            resultado(column.ColumnName) = row(column.ColumnName)
                        End If
                    Next
                Next
            ElseIf dsResultado.Tables.Contains("Message") = True Then
                Dim table As DataTable = dsResultado.Tables("Message")
                For Each row As DataRow In table.Rows
                    For Each column As DataColumn In table.Columns
                        If row.IsNull(column.ColumnName) = False Then
                            resultado(column.ColumnName) = row(column.ColumnName)
                        End If
                    Next
                Next
            End If
        End If
        Return resultado
    End Function

    '------------------------------------------------------------------------------------------------
    'FLIZARRAGA 20/02/2015: Invoca WebService que anula un pago hecho a Karum
    '------------------------------------------------------------------------------------------------

    Public Function PaymentVoid(ByVal parameter As Hashtable) As Hashtable
        Dim dsResultado As New DataSet
        Dim resultado As New Hashtable
        Me.request = "<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:ws=""http://WS_KARUM"">"
        Me.request &= "<soapenv:Header/>"
        Me.request &= "<soapenv:Body>"
        Me.request &= "<ws:DPT_PaymentVoid>"
        Me.request &= "<NoTarjeta>" & CStr(parameter("NoTarjeta")) & "</NoTarjeta>"
        Me.request &= "<Monto>" & CDec(parameter("Monto")).ToString("##,##0.00").Replace(",", "") & "</Monto>"
        Me.request &= "<Fecha>" & CStr(parameter("Fecha")) & "</Fecha>"
        'Me.request &= "<ConsecutivoPOS>" & CStr(parameter("ConsecutivoPOS")) & "</ConsecutivoPOS>"
        Me.request &= "<ConsecutivoPOS></ConsecutivoPOS>"
        Me.request &= "<IDPOS>" & CStr(parameter("IDPOS")) & "</IDPOS>"
        Me.request &= "<IDTienda>" & CStr(parameter("IDTienda")) & "</IDTienda>"
        Me.request &= "<Tipo>" & CStr(parameter("Tipo")) & "</Tipo>"
        Me.request &= "<Promocion>" & CStr(parameter("Promocion")) & "</Promocion>"
        Me.request &= "</ws:DPT_PaymentVoid>"
        Me.request &= "</soapenv:Body>"
        Me.request &= "</soapenv:Envelope>"
        dsResultado = ConsumeXML(Me.CallMethod, Me.request)
        'dsResultado = ConsumeWSBroker(Me.CallMethod, Me.request)
        'ActualizarConsecutivoPOS()
        If Not dsResultado Is Nothing Then
            If dsResultado.Tables.Contains("DPT_PaymentVoidResponse") = True Then
                Dim table As DataTable = dsResultado.Tables("DPT_PaymentVoidResponse")
                For Each row As DataRow In table.Rows
                    For Each column As DataColumn In table.Columns
                        If row.IsNull(column.ColumnName) = False Then
                            resultado(column.ColumnName) = row(column.ColumnName)
                        End If
                    Next
                Next
            ElseIf dsResultado.Tables.Contains("Message") = True Then
                Dim table As DataTable = dsResultado.Tables("Message")
                For Each row As DataRow In table.Rows
                    For Each column As DataColumn In table.Columns
                        If row.IsNull(column.ColumnName) = False Then
                            resultado(column.ColumnName) = row(column.ColumnName)
                        End If
                    Next
                Next
            End If
        End If
        Return resultado
    End Function

    '------------------------------------------------------------------------------------------------
    'FLIZARRAGA 20/02/2015: Invoca WebService que anula una venta hecha con Karum
    '------------------------------------------------------------------------------------------------

    Public Function PurchaseVoid(ByVal parameter As Hashtable, Optional ByVal dtDetalle As DataTable = Nothing) As Hashtable
        Dim dsResultado As New DataSet
        Dim resultado As New Hashtable
        Me.request = "<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:ws=""http://WS_KARUM"">"
        Me.request &= "<soapenv:Header/>"
        Me.request &= "<soapenv:Body>"
        Me.request &= "<ws:DPT_PurchaseVoid>"
        Me.request &= "<NoTarjeta>" & CStr(parameter("NoTarjeta")) & "</NoTarjeta>"
        Me.request &= "<Monto>" & CDec(parameter("Monto")).ToString("##,##0.00").Replace(",", "") & "</Monto>"
        Me.request &= "<Promocion>" & CStr(parameter("Promocion")) & "</Promocion>"
        Me.request &= "<Fecha>" & CStr(parameter("Fecha")) & "</Fecha>"
        'Me.request &= "<ConsecutivoPOS>" & CStr(parameter("ConsecutivoPOS")) & "</ConsecutivoPOS>"
        Me.request &= "<ConsecutivoPOS></ConsecutivoPOS>"
        Me.request &= "<IDPOS>" & CStr(parameter("IDPOS")) & "</IDPOS>"
        Me.request &= "<IDTienda>" & CStr(parameter("IDTienda")) & "</IDTienda>"
        Me.request &= "<Tipo>" & CStr(parameter("Tipo")) & "</Tipo>"
        If Not dtDetalle Is Nothing Then
            Dim ArticuloMgr As New DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos.CatalogoArticuloManager(oAppContext)
            Dim articulo As DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos.Articulo
            Dim total As Decimal = 0, descSistema As Decimal = 0, descuento As Decimal = 0, unitPrice As Decimal = 0
            Dim cantidad As Decimal = 0
            For Each row As DataRow In dtDetalle.Rows
                Me.request &= "<Detalles>"
                articulo = ArticuloMgr.Load(CStr(row("CodArticulo")))
                cantidad = Math.Round(CDec(row("Cantidad")), 2)
                total = Math.Round(CDec(row("Total")), 2)
                unitPrice = total / cantidad
                descSistema = Math.Round(row("CantDescuentoSistema"), 2)
                descuento = Math.Round(row("Descuento"), 2)
                total = total - descSistema
                descuento = total * (descuento / 100)
                unitPrice = unitPrice - (descSistema / cantidad) - (descuento / cantidad)
                unitPrice = Decimal.Round(unitPrice * (1 + oAppContext.ApplicationConfiguration.IVA), 2)
                total = unitPrice * cantidad
                Me.request &= "<SkuUpcCode>" & articulo.Jerarquia.Remove(0, 1) & "</SkuUpcCode>"
                Me.request &= "<Quantity>" & CStr(row("Cantidad")) & "</Quantity>"
                Me.request &= "<UnitPrice>" & unitPrice.ToString("##,##0.00").Replace(",", "") & "</UnitPrice>"
                Me.request &= "<Amount>" & total.ToString("##,##0.00").Replace(",", "") & "</Amount>"
                Me.request &= "</Detalles>"
            Next
        End If
        Me.request &= "</ws:DPT_PurchaseVoid>"
        Me.request &= "</soapenv:Body>"
        Me.request &= "</soapenv:Envelope>"
        dsResultado = ConsumeXML(Me.CallMethod, Me.request)
        'dsResultado = ConsumeWSBroker(Me.CallMethod, Me.request)
        'ActualizarConsecutivoPOS()
        If Not dsResultado Is Nothing Then
            If dsResultado.Tables.Contains("DPT_PurchaseVoidResponse") = True Then
                Dim table As DataTable = dsResultado.Tables("DPT_PurchaseVoidResponse")
                For Each row As DataRow In table.Rows
                    For Each column As DataColumn In table.Columns
                        If row.IsNull(column.ColumnName) = False Then
                            resultado(column.ColumnName) = row(column.ColumnName)
                        End If
                    Next
                Next
            ElseIf dsResultado.Tables.Contains("Message") = True Then
                Dim table As DataTable = dsResultado.Tables("Message")
                For Each row As DataRow In table.Rows
                    For Each column As DataColumn In table.Columns
                        If row.IsNull(column.ColumnName) = False Then
                            resultado(column.ColumnName) = row(column.ColumnName)
                        End If
                    Next
                Next
            End If
        End If
        Return resultado
    End Function

    '------------------------------------------------------------------------------------------------
    'FLIZARRAGA 20/02/2015: Invoca WebService que anula una venta hecha con Karum
    '------------------------------------------------------------------------------------------------

    Public Function PurchaseVoidPrestamo(ByVal parameter As Hashtable) As Hashtable
        Dim dsResultado As New DataSet
        Dim resultado As New Hashtable
        Me.request = "<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:ws=""http://WS_KARUM"">"
        Me.request &= "<soapenv:Header/>"
        Me.request &= "<soapenv:Body>"
        Me.request &= "<ws:DPT_PurchaseVoid>"
        Me.request &= "<NoTarjeta>" & CStr(parameter("NoTarjeta")) & "</NoTarjeta>"
        Me.request &= "<Monto>" & CDec(parameter("Monto")).ToString("##,##0.00").Replace(",", "") & "</Monto>"
        Me.request &= "<Promocion>" & CStr(parameter("Promocion")) & "</Promocion>"
        Me.request &= "<Fecha>" & CStr(parameter("Fecha")) & "</Fecha>"
        'Me.request &= "<ConsecutivoPOS>" & CStr(parameter("ConsecutivoPOS")) & "</ConsecutivoPOS>"
        Me.request &= "<ConsecutivoPOS></ConsecutivoPOS>"
        Me.request &= "<IDPOS>" & CStr(parameter("IDPOS")) & "</IDPOS>"
        Me.request &= "<IDTienda>" & CStr(parameter("IDTienda")) & "</IDTienda>"
        Me.request &= "<Tipo>" & CStr(parameter("Tipo")) & "</Tipo>"
        Me.request &= "<Detalles>"
        Me.request &= "<SkuUpcCode>" & CStr(parameter("SKU")) & "</SkuUpcCode>"
        Me.request &= "<Quantity>1</Quantity>"
        Me.request &= "<UnitPrice>" & CDec(parameter("Monto")).ToString("##,##0.00").Replace(",", "") & "</UnitPrice>"
        Me.request &= "<Amount>" & CDec(parameter("Monto")).ToString("##,##0.00").Replace(",", "") & "</Amount>"
        Me.request &= "</Detalles>"
        Me.request &= "</ws:DPT_PurchaseVoid>"
        Me.request &= "</soapenv:Body>"
        Me.request &= "</soapenv:Envelope>"
        dsResultado = ConsumeXML(Me.CallMethod, Me.request)
        'dsResultado = ConsumeWSBroker(Me.CallMethod, Me.request)
        'ActualizarConsecutivoPOS()
        If Not dsResultado Is Nothing Then
            If dsResultado.Tables.Contains("DPT_PurchaseVoidResponse") = True Then
                Dim table As DataTable = dsResultado.Tables("DPT_PurchaseVoidResponse")
                For Each row As DataRow In table.Rows
                    For Each column As DataColumn In table.Columns
                        If row.IsNull(column.ColumnName) = False Then
                            resultado(column.ColumnName) = row(column.ColumnName)
                        End If
                    Next
                Next
            ElseIf dsResultado.Tables.Contains("Message") = True Then
                Dim table As DataTable = dsResultado.Tables("Message")
                For Each row As DataRow In table.Rows
                    For Each column As DataColumn In table.Columns
                        If row.IsNull(column.ColumnName) = False Then
                            resultado(column.ColumnName) = row(column.ColumnName)
                        End If
                    Next
                Next
            End If
        End If
        Return resultado
    End Function

    'Private Function ConsumeWSBroker(ByVal UrlWS As String, ByVal strSoapEnvelope As String) As DataSet
    '    Dim objXMLHttp As XMLHTTP40
    '    Dim TextResponse As String = String.Empty
    '    Dim Status As String = String.Empty
    '    Dim StatusText As String = String.Empty

    '    Try
    '        objXMLHttp = New XMLHTTP40
    '        objXMLHttp.open("POST", UrlWS, False, "", "")
    '        objXMLHttp.setRequestHeader("Content-Type", "text/xml; charset=utf-8")
    '        objXMLHttp.send(strSoapEnvelope.ToString())
    '        'objXMLHttp.send()
    '        Status = objXMLHttp.status
    '        StatusText = objXMLHttp.statusText
    '        TextResponse = objXMLHttp.responseText.ToString

    '        '/////////////////////////////////////////////
    '        'Preparamos datos de respuesta
    '        '/////////////////////////////////////////////
    '        Dim XMLReader As New StringReader(TextResponse)
    '        Dim dsXML As New DataSet
    '        dsXML.ReadXml(XMLReader)

    '        '/////////////////////////////////////////////
    '        'Verificamos respuesta del servidor
    '        '/////////////////////////////////////////////
    '        If Status = 200 Then '// Si conexion HTTP es buena regresamos el DataSet
    '            Return dsXML
    '        Else '// De lo contrario mostramos Excepcion generada en el Servicio Web
    '            ShowExceptionXMLHTTP40(dsXML)
    '        End If

    '        'Eliminamos la conexion abierta dandole valor nulo al objeto
    '        objXMLHttp = Nothing

    '    Catch ex0 As Xml.XmlException
    '        MessageBox.Show(ex0.Message, "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        'Throw ex0
    '    Catch ex1 As ObjectDisposedException
    '        MessageBox.Show(ex1.Message, "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        'Throw ex1
    '    Catch ex2 As Exception
    '        MessageBox.Show(ex2.Message, "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        'Throw ex2
    '    Finally
    '        'Eliminamos la conexion abierta dandole valor nulo al objet
    '        objXMLHttp = Nothing
    '    End Try

    '    Return Nothing

    'End Function

    Private Function ConsumeXML(ByVal URL As String, ByVal strSoapEnvelope As String) As DataSet
        Dim oRequest As HttpWebRequest
        Dim oStream As Stream
        Dim oResponse As HttpWebResponse
        Dim oReader As StreamReader
        Dim strResponse As String
        Dim dsXML As New DataSet
        Try
            Dim data() As Byte
            'Instanciamos Objeto y seteamos parametros necesarios para consumir correctamente el REST
            oRequest = TryCast(WebRequest.Create(URL), HttpWebRequest)
            oRequest.Timeout = -1
            oRequest.Method = "POST"
            data = UTF8Encoding.UTF8.GetBytes(strSoapEnvelope)
            oRequest.ContentLength = data.Length
            oRequest.ContentType = "text/xml; charset=utf-8"
            oRequest.Accept = "text/xml; charset=utf-8"
            oStream = oRequest.GetRequestStream
            oStream.Write(data, 0, data.Length)
            'Obtenemos Respuesta
            oResponse = TryCast(oRequest.GetResponse(), HttpWebResponse)
            oReader = New StreamReader(oResponse.GetResponseStream())
            strResponse = oReader.ReadToEnd()
            oStream.Close()
            oReader.Close()
            Dim XMLReader As New StringReader(strResponse)
            dsXML.ReadXml(XMLReader)
        Catch web As System.Web.HttpException
            If web.ErrorCode = 404 Then
                Throw New Exception(Convert.ToString("WebService no encontrado") & URL)
            Else
                Throw web
            End If
        Catch ex As Exception
            Throw New ApplicationException(ex.Message, ex)
        End Try
        Return dsXML
    End Function


    Private Function ValidarColumna(ByVal ColumnName As String, ByVal Table As DataTable) As DataTable
        Dim dt As DataTable = Table.Copy
        If Not dt.Columns.Contains(ColumnName) Then
            dt.Columns.Add(ColumnName)
            For Each oRow As DataRow In dt.Rows
                oRow(ColumnName) = ""
            Next
            dt.AcceptChanges()
        End If
        Return dt
    End Function

    Private Sub ShowExceptionXMLHTTP40(ByVal dsXML As DataSet)
        Dim FaultCode As String = dsXML.Tables(1).Rows(0).Item(0).ToString() 'faultCode
        Dim FaultString As String = dsXML.Tables(1).Rows(0).Item(1).ToString() 'faultString
        Dim Exception As String = dsXML.Tables(2).Rows(0).Item(0).ToString() 'Exception
        Dim Ex As New Exception(FaultString & vbCrLf & vbCrLf & Exception)
        Throw Ex
    End Sub

#Region "DPCARD"

    '-----------------------------------------------------------------------------------------------------------------------------
    'RGERMAIN 14/04/2015: Consulta el saldo de una tarjeta DPCard Puntos
    '-----------------------------------------------------------------------------------------------------------------------------
    Public Function GetBalance(ByVal parameter As Hashtable) As Hashtable
        Dim dsResultado As New DataSet
        Dim resultado As New Hashtable
        Me.request = "<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:ws=""http://WS_BLUE"">"
        Me.request &= "<soapenv:Header/>"
        Me.request &= "<soapenv:Body>"
        Me.request &= "<ws:GetBalance>"
        Me.request &= "<cardId>" & CStr(parameter("cardId")) & "</cardId>"
        Me.request &= "<transactionDate>" & CStr(parameter("transactionDate")) & "</transactionDate>"
        Me.request &= "<ticketid>" & CStr(parameter("ticketid")) & "</ticketid>"
        Me.request &= "<storeid>" & CStr(parameter("storeid")) & "</storeid>"
        Me.request &= "<referenceId3>" & CStr(parameter("referenceId3")) & "</referenceId3>"
        Me.request &= "<referenceId4>" & CStr(parameter("referenceId4")) & "</referenceId4>"
        Me.request &= "<cashierCode>" & CStr(parameter("cashierCode")) & "</cashierCode>"
        Me.request &= "<cashierName>" & CStr(parameter("cashierName")) & "</cashierName>"
        Me.request &= "<supervisorCode>" & CStr(parameter("supervisorCode")) & "</supervisorCode>"
        Me.request &= "<supervisorName>" & CStr(parameter("supervisorName")) & "</supervisorName>"
        Me.request &= "<sellerCode>" & CStr(parameter("sellerCode")) & "</sellerCode>"
        Me.request &= "<sellerName>" & CStr(parameter("sellerName")) & "</sellerName>"
        Me.request &= "<tipo>" & CStr(parameter("tipo")) & "</tipo>" & vbCrLf
        Me.request &= "</ws:GetBalance>"
        Me.request &= "</soapenv:Body>"
        Me.request &= "</soapenv:Envelope>"
        dsResultado = ConsumeXML(Me.CallMethod, Me.request)
        'dsResultado = ConsumeWSBroker(Me.CallMethod, Me.request)
        If Not dsResultado Is Nothing Then
            If dsResultado.Tables.Contains("GetBalanceResponse") = True Then
                Dim table As DataTable = dsResultado.Tables("GetBalanceResponse")
                For Each row As DataRow In table.Rows
                    For Each column As DataColumn In table.Columns
                        If row.IsNull(column.ColumnName) = False Then
                            resultado(column.ColumnName) = row(column.ColumnName)
                        End If
                    Next
                Next
            End If
        End If
        Return resultado
    End Function

    '-----------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 14/04/2015: Activa la tarjeta DPCard Puntos
    '-----------------------------------------------------------------------------------------------------------------------------

    Public Function Activate(ByVal parameter As Hashtable) As Hashtable
        Dim resultado As New Hashtable
        Dim dsResultado As DataSet = Nothing
        Me.request = "<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:ws=""http://WS_BLUE"">" & vbCrLf
        Me.request &= "<soapenv:Header/>" & vbCrLf
        Me.request &= "<soapenv:Body>" & vbCrLf
        Me.request &= "<ws:Activate>" & vbCrLf
        Me.request &= "<cardId>" & CStr(parameter("CardId")) & "</cardId>" & vbCrLf
        Me.request &= "<transactionDate>" & CStr(parameter("TransactionDate")) & "</transactionDate>" & vbCrLf
        Me.request &= "<ticketid>" & CStr(parameter("TicketId")) & "</ticketid>" & vbCrLf
        Me.request &= "<storeid>" & CStr(parameter("storeid")) & "</storeid>" & vbCrLf
        Me.request &= "<referenceId3>" & CStr(parameter("ReferenceId3")) & "</referenceId3>" & vbCrLf
        Me.request &= "<referenceId4>" & CStr(parameter("ReferenceId4")) & "</referenceId4>" & vbCrLf
        Me.request &= "<cashierCode>" & CStr(parameter("CashierCode")) & "</cashierCode>" & vbCrLf
        Me.request &= "<cashierName>" & CStr(parameter("CashierName")) & "</cashierName>" & vbCrLf
        Me.request &= "<supervisorCode>" & CStr(parameter("SupervisorCode")) & "</supervisorCode>" & vbCrLf
        Me.request &= "<supervisorName>" & CStr(parameter("SupervisorName")) & "</supervisorName>" & vbCrLf
        Me.request &= "<sellerCode>" & CStr(parameter("SellerCode")) & "</sellerCode>" & vbCrLf
        Me.request &= "<sellerName>" & CStr(parameter("SellerName")) & "</sellerName>" & vbCrLf
        Me.request &= "<noassigned1>" & CStr(parameter("NoAssigned1")) & "</noassigned1>" & vbCrLf
        Me.request &= "<noassigned2>" & CStr(parameter("NoAssigned2")) & "</noassigned2>" & vbCrLf
        Me.request &= "<tipo>" & CStr(parameter("tipo")) & "</tipo>" & vbCrLf
        Me.request &= "</ws:Activate>" & vbCrLf
        Me.request &= "</soapenv:Body>" & vbCrLf
        Me.request &= "</soapenv:Envelope>"
        dsResultado = ConsumeXML(Me.CallMethod, Me.request)
        'dsResultado = ConsumeWSBroker(Me.CallMethod, Me.request)
        If Not dsResultado Is Nothing AndAlso dsResultado.Tables.Count > 0 Then
            If dsResultado.Tables.Contains("ActivateResponse") = True Then
                Dim table As DataTable = dsResultado.Tables("ActivateResponse")
                For Each row As DataRow In table.Rows
                    For Each column As DataColumn In table.Columns
                        If row.IsNull(column.ColumnName) = False Then
                            resultado(column.ColumnName) = row(column.ColumnName)
                        End If
                    Next
                Next
            End If
        End If
        Return resultado
    End Function

    '-----------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 14/04/2015: Bonifica puntos en la tarjeta DPCard
    '-----------------------------------------------------------------------------------------------------------------------------

    Public Function Collect(ByVal parameter As Hashtable) As Hashtable
        Dim resultado As New Hashtable
        Dim dsResultado As DataSet = Nothing
        Me.request = "<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:ws=""http://WS_BLUE"">" & vbCrLf
        Me.request &= "<soapenv:Header/>" & vbCrLf
        Me.request &= "<soapenv:Body>" & vbCrLf
        Me.request &= "<ws:Collect>" & vbCrLf
        Me.request &= "<cardId>" & CStr(parameter("CardId")) & "</cardId>" & vbCrLf
        Me.request &= "<transactionDate>" & CStr(parameter("TransactionDate")) & "</transactionDate>" & vbCrLf
        Me.request &= "<amount>" & CStr(parameter("Amount")) & "</amount>" & vbCrLf
        Me.request &= "<totalAmount>" & CStr(parameter("TotalAmount")) & "</totalAmount>" & vbCrLf
        Me.request &= "<ticketid>" & CStr(parameter("TicketId")) & "</ticketid>" & vbCrLf
        Me.request &= "<storeid>" & CStr(parameter("StoreId")) & "</storeid>" & vbCrLf
        Me.request &= "<referenceId3>" & CStr(parameter("ReferenceId3")) & "</referenceId3>" & vbCrLf
        Me.request &= "<referenceId4>" & CStr(parameter("ReferenceId4")) & "</referenceId4>" & vbCrLf
        Me.request &= "<cashierCode>" & CStr(parameter("CashierCode")) & "</cashierCode>" & vbCrLf
        Me.request &= "<cashierName>" & CStr(parameter("CashierName")) & "</cashierName>" & vbCrLf
        Me.request &= "<supervisorCode>" & CStr(parameter("SupervisorCode")) & "</supervisorCode>" & vbCrLf
        Me.request &= "<supervisorName>" & CStr(parameter("SupervisorName")) & "</supervisorName>" & vbCrLf
        Me.request &= "<sellerCode>" & CStr(parameter("SellerCode")) & "</sellerCode>" & vbCrLf
        Me.request &= "<sellerName>" & CStr(parameter("SellerName")) & "</sellerName>" & vbCrLf
        Me.request &= "<products>" & CStr(parameter("Products")) & "</products>" & vbCrLf
        Me.request &= "</ws:Collect>" & vbCrLf
        Me.request &= "</soapenv:Body>" & vbCrLf
        Me.request &= "</soapenv:Envelope>"
        dsResultado = ConsumeXML(Me.CallMethod, Me.request)
        'dsResultado = ConsumeWSBroker(Me.CallMethod, Me.request)
        If Not dsResultado Is Nothing AndAlso dsResultado.Tables.Count > 0 Then
            If dsResultado.Tables.Contains("CollectResponse") = True Then
                Dim table As DataTable = dsResultado.Tables("CollectResponse")
                For Each row As DataRow In table.Rows
                    For Each column As DataColumn In table.Columns
                        If row.IsNull(column.ColumnName) = False Then
                            resultado(column.ColumnName) = row(column.ColumnName)
                        End If
                    Next
                Next
            End If
        End If
        Return resultado
    End Function

    '---------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 15/04/2015: Validar DPCard Puntos Blue Engine.
    '---------------------------------------------------------------------------------------------------------------------------

    Public Function ValidateDPCardPuntos(ByVal parameter As Hashtable) As Hashtable
        Dim resultado As New Hashtable
        Dim dsResultado As DataSet = Nothing
        Me.request = "<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:ws=""http://WS_BLUE"">" & vbCrLf
        Me.request &= "<soapenv:Header/>"
        Me.request &= "<soapenv:Body>"
        Me.request &= "<ws:ValidateCard>"
        Me.request &= "<cardId>" & CStr(parameter("CardId")) & "</cardId>" & vbCrLf
        Me.request &= "<transactionDate>" & CStr(parameter("TransactionDate")) & "</transactionDate>" & vbCrLf
        Me.request &= "<ticketid>" & CStr(parameter("TicketId")) & "</ticketid>" & vbCrLf
        Me.request &= "<storeid>" & CStr(parameter("StoreId")) & "</storeid>" & vbCrLf
        Me.request &= "<referenceId3>" & CStr(parameter("ReferenceId3")) & "</referenceId3>" & vbCrLf
        Me.request &= "<referenceId4>" & CStr(parameter("ReferenceId4")) & "</referenceId4>" & vbCrLf
        Me.request &= "<cashierCode>" & CStr(parameter("CashierCode")) & "</cashierCode>" & vbCrLf
        Me.request &= "<cashierName>" & CStr(parameter("CashierName")) & "</cashierName>" & vbCrLf
        Me.request &= "<supervisorCode>" & CStr(parameter("SupervisorCode")) & "</supervisorCode>" & vbCrLf
        Me.request &= "<supervisorName>" & CStr(parameter("SupervisorName")) & "</supervisorName>" & vbCrLf
        Me.request &= "<sellerCode>" & CStr(parameter("SellerCode")) & "</sellerCode>" & vbCrLf
        Me.request &= "<sellerName>" & CStr(parameter("SellerName")) & "</sellerName>" & vbCrLf
        Me.request &= "<noAssigned1>" & CStr(parameter("NoAssigned1")) & "</noAssigned1>" & vbCrLf
        Me.request &= "<noAssigned2>" & CStr(parameter("NoAssigned2")) & "</noAssigned2>" & vbCrLf
        Me.request &= "</ws:ValidateCard>" & vbCrLf
        Me.request &= "</soapenv:Body>" & vbCrLf
        Me.request &= "</soapenv:Envelope>"
        dsResultado = ConsumeXML(Me.CallMethod, Me.request)
        'dsResultado = ConsumeWSBroker(Me.CallMethod, Me.request)
        If Not dsResultado Is Nothing AndAlso dsResultado.Tables.Count > 0 Then
            If dsResultado.Tables.Contains("ValidateCardResponse") = True Then
                Dim table As DataTable = dsResultado.Tables("ValidateCardResponse")
                For Each row As DataRow In table.Rows
                    For Each column As DataColumn In table.Columns
                        If row.IsNull(column.ColumnName) = False Then
                            resultado(column.ColumnName) = row(column.ColumnName)
                        End If
                    Next
                Next
            End If
        End If
        Return resultado
    End Function

    Public Function Redeem(ByVal parameter As Hashtable) As Hashtable
        Dim resultado As New Hashtable
        Dim dsResultado As DataSet = Nothing
        Me.request = "<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:ws=""http://WS_BLUE"">" & vbCrLf
        Me.request &= "<soapenv:Header/>"
        Me.request &= "<soapenv:Body>"
        Me.request &= "<ws:Redeem>"
        Me.request &= "<cardId>" & CStr(parameter("CardId")) & "</cardId>" & vbCrLf
        Me.request &= "<transactionDate>" & CStr(parameter("TransactionDate")) & "</transactionDate>" & vbCrLf
        Me.request &= "<amount>" & CStr(parameter("amount")) & "</amount>" & vbCrLf
        Me.request &= "<totalAmount>" & CStr(parameter("totalAmount")) & "</totalAmount>" & vbCrLf
        Me.request &= "<ticketid>" & CStr(parameter("ticketid")) & "</ticketid>" & vbCrLf
        Me.request &= "<storeid>" & CStr(parameter("StoreId")) & "</storeid>" & vbCrLf
        Me.request &= "<referenceId3>" & CStr(parameter("ReferenceId3")) & "</referenceId3>" & vbCrLf
        Me.request &= "<referenceId4>" & CStr(parameter("ReferenceId4")) & "</referenceId4>" & vbCrLf
        Me.request &= "<cashierCode>" & CStr(parameter("CashierCode")) & "</cashierCode>" & vbCrLf
        Me.request &= "<cashierName>" & CStr(parameter("CashierName")) & "</cashierName>" & vbCrLf
        Me.request &= "<supervisorCode>" & CStr(parameter("SupervisorCode")) & "</supervisorCode>" & vbCrLf
        Me.request &= "<supervisorName>" & CStr(parameter("SupervisorName")) & "</supervisorName>" & vbCrLf
        Me.request &= "<sellerCode>" & CStr(parameter("SellerCode")) & "</sellerCode>" & vbCrLf
        Me.request &= "<sellerName>" & CStr(parameter("SellerName")) & "</sellerName>" & vbCrLf
        Me.request &= "<localHour>" & CStr(parameter("localHour")) & "</localHour>" & vbCrLf
        Me.request &= "<products>" & CStr(parameter("products")) & "</products>" & vbCrLf
        Me.request &= "<consecutivoKarum>" & CStr(parameter("ConsecutivoKarum")) & "</consecutivoKarum>" & vbCrLf
        Me.request &= "<tipo>" & CStr(parameter("tipo")) & "</tipo>" & vbCrLf
        Me.request &= "</ws:Redeem>" & vbCrLf
        Me.request &= "</soapenv:Body>" & vbCrLf
        Me.request &= "</soapenv:Envelope>"
        dsResultado = ConsumeXML(Me.CallMethod, Me.request)
        'dsResultado = ConsumeWSBroker(Me.CallMethod, Me.request)
        If Not dsResultado Is Nothing AndAlso dsResultado.Tables.Count > 0 Then
            If dsResultado.Tables.Contains("RedeemResponse") = True Then
                Dim table As DataTable = dsResultado.Tables("RedeemResponse")
                For Each row As DataRow In table.Rows
                    For Each column As DataColumn In table.Columns
                        If row.IsNull(column.ColumnName) = False Then
                            resultado(column.ColumnName) = row(column.ColumnName)
                        End If
                    Next
                Next
            End If
        End If
        Return resultado
    End Function

    Public Function FindCardByPOSArray(ByVal parameter As Hashtable) As Hashtable
        Dim resultado As New Hashtable
        Dim dsResultado As DataSet = Nothing
        Me.request = "<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:ws=""http://WS_BLUE"">" & vbCrLf
        Me.request &= "<soapenv:Header/>"
        Me.request &= "<soapenv:Body>"
        Me.request &= "<ws:FindCardByPOSArray>"
        Me.request &= "<storeid>" & CStr(parameter("storeid")) & "</storeid>" & vbCrLf
        Me.request &= "<transDate>" & CStr(parameter("transDate")) & "</transDate>" & vbCrLf
        Me.request &= "<lastName>" & CStr(parameter("lastName")) & "</lastName>" & vbCrLf
        Me.request &= "<phone>" & CStr(parameter("phone")) & "</phone>" & vbCrLf
        Me.request &= "</ws:FindCardByPOSArray>" & vbCrLf
        Me.request &= "</soapenv:Body>" & vbCrLf
        Me.request &= "</soapenv:Envelope>"
        dsResultado = ConsumeXML(Me.CallMethod, Me.request)
        'dsResultado = ConsumeWSBroker(Me.CallMethod, Me.request)
        If Not dsResultado Is Nothing AndAlso dsResultado.Tables.Count > 0 Then
            If dsResultado.Tables.Contains("FindCardByPOSArrayResponse") = True Then
                Dim table As DataTable = dsResultado.Tables("FindCardByPOSArrayResponse")
                For Each row As DataRow In table.Rows
                    For Each column As DataColumn In table.Columns
                        If row.IsNull(column.ColumnName) = False Then
                            resultado(column.ColumnName) = row(column.ColumnName)
                        End If
                    Next
                Next
            End If
            If dsResultado.Tables.Contains("FindCardByPOSResult") = True Then
                Dim table As DataTable = dsResultado.Tables("FindCardByPOSResult")
                For Each row As DataRow In table.Rows
                    For Each column As DataColumn In table.Columns
                        If row.IsNull(column.ColumnName) = False Then
                            resultado(column.ColumnName) = row(column.ColumnName)
                        End If
                    Next
                Next
            End If
        End If
        Return resultado
    End Function

    Public Function TransferPoints(ByVal parameter As Hashtable) As Hashtable
        Dim resultado As New Hashtable
        Dim dsResultado As DataSet = Nothing
        Me.request = "<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:ws=""http://WS_BLUE"">" & vbCrLf
        Me.request &= "<soapenv:Header/>" & vbCrLf
        Me.request &= "<soapenv:Body>" & vbCrLf
        Me.request &= "<ws:TransferPoints>" & vbCrLf
        Me.request &= "<cardId>" & CStr(parameter("CardId")) & "</cardId>" & vbCrLf
        Me.request &= "<transactionDate>" & CStr(parameter("TransactionDate")) & "</transactionDate>" & vbCrLf
        Me.request &= "<oldCardID>" & CStr(parameter("OldCardId")) & "</oldCardID>" & vbCrLf
        Me.request &= "<storeid>" & CStr(parameter("StoreId")) & "</storeid>" & vbCrLf
        Me.request &= "<referenceId3>" & CStr(parameter("ReferenceId3")) & "</referenceId3>" & vbCrLf
        Me.request &= "<referenceId4>" & CStr(parameter("ReferenceId4")) & "</referenceId4>" & vbCrLf
        Me.request &= "<cashierCode>" & CStr(parameter("CashierCode")) & "</cashierCode>" & vbCrLf
        Me.request &= "<cashierName>" & CStr(parameter("CashierName")) & "</cashierName>" & vbCrLf
        Me.request &= "<supervisorCode>" & CStr(parameter("SupervisorCode")) & "</supervisorCode>" & vbCrLf
        Me.request &= "<supervisorName>" & CStr(parameter("SupervisorName")) & "</supervisorName>" & vbCrLf
        Me.request &= "<sellerCode>" & CStr(parameter("SellerCode")) & "</sellerCode>" & vbCrLf
        Me.request &= "<sellerName>" & CStr(parameter("SellerName")) & "</sellerName>" & vbCrLf
        Me.request &= "<transactionTypeId>" & CStr(parameter("TransactionTypeId")) & "</transactionTypeId>" & vbCrLf
        Me.request &= "</ws:TransferPoints>" & vbCrLf
        Me.request &= "</soapenv:Body>" & vbCrLf
        Me.request &= "</soapenv:Envelope>"
        dsResultado = ConsumeXML(Me.CallMethod, Me.request)
        'dsResultado = ConsumeWSBroker(Me.CallMethod, Me.request)
        If Not dsResultado Is Nothing AndAlso dsResultado.Tables.Count > 0 Then
            If dsResultado.Tables.Contains("TransferPointsResponse") = True Then
                Dim table As DataTable = dsResultado.Tables("TransferPointsResponse")
                For Each row As DataRow In table.Rows
                    For Each column As DataColumn In table.Columns
                        If row.IsNull(column.ColumnName) = False Then
                            resultado(column.ColumnName) = row(column.ColumnName)
                        End If
                    Next
                Next
            End If
        End If
        Return resultado
    End Function

    '----------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 17/04/2015: Renueva la membresia de DPCard Puntos.
    '----------------------------------------------------------------------------------------------------------------------------

    Public Function RenewMembership(ByVal parameter As Hashtable) As Hashtable
        Dim resultado As New Hashtable
        Dim dsResultado As DataSet = Nothing
        Me.request = "<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:ws=""http://WS_BLUE"">" & vbCrLf
        Me.request &= "<soapenv:Header/>" & vbCrLf
        Me.request &= "<soapenv:Body>" & vbCrLf
        Me.request &= "<ws:RenewMembership>" & vbCrLf
        Me.request &= "<cardId>" & CStr(parameter("CardId")) & "</cardId>" & vbCrLf
        Me.request &= "<transactionDate>" & CStr(parameter("TransactionDate")) & "</transactionDate>" & vbCrLf
        Me.request &= "<ticketid>" & CStr(parameter("ticketid")) & "</ticketid>" & vbCrLf
        Me.request &= "<storeid>" & CStr(parameter("StoreId")) & "</storeid>" & vbCrLf
        Me.request &= "<referenceId3>" & CStr(parameter("ReferenceId3")) & "</referenceId3>" & vbCrLf
        Me.request &= "<referenceId4>" & CStr(parameter("ReferenceId4")) & "</referenceId4>" & vbCrLf
        Me.request &= "<cashierCode>" & CStr(parameter("CashierCode")) & "</cashierCode>" & vbCrLf
        Me.request &= "<cashierName>" & CStr(parameter("CashierName")) & "</cashierName>" & vbCrLf
        Me.request &= "<supervisorCode>" & CStr(parameter("SupervisorCode")) & "</supervisorCode>" & vbCrLf
        Me.request &= "<supervisorName>" & CStr(parameter("SupervisorName")) & "</supervisorName>" & vbCrLf
        Me.request &= "<sellerCode>" & CStr(parameter("SellerCode")) & "</sellerCode>" & vbCrLf
        Me.request &= "<sellerName>" & CStr(parameter("SellerName")) & "</sellerName>" & vbCrLf
        Me.request &= "<amount>" & CStr(parameter("Amount")) & "</amount>" & vbCrLf
        Me.request &= "</ws:RenewMembership>" & vbCrLf
        Me.request &= "</soapenv:Body>" & vbCrLf
        Me.request &= "</soapenv:Envelope>"
        dsResultado = ConsumeXML(Me.CallMethod, Me.request)
        'dsResultado = ConsumeWSBroker(Me.CallMethod, Me.request)
        If Not dsResultado Is Nothing AndAlso dsResultado.Tables.Count > 0 Then
            If dsResultado.Tables.Contains("RenewMembershipResponse") = True Then
                Dim table As DataTable = dsResultado.Tables("RenewMembershipResponse")
                For Each row As DataRow In table.Rows
                    For Each column As DataColumn In table.Columns
                        If row.IsNull(column.ColumnName) = False Then
                            resultado(column.ColumnName) = row(column.ColumnName)
                        End If
                    Next
                Next
            End If
        End If
        Return resultado
    End Function

    '-------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 18/04/2015: Devolución de articulos cuando se retorna un vale de caja
    '-------------------------------------------------------------------------------------------------------------------------

    Public Function ReturnRegister(ByVal parameter As Hashtable) As Hashtable
        Dim resultado As New Hashtable
        Dim dsResultado As DataSet = Nothing
        Me.request = "<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:ws=""http://WS_BLUE"">" & vbCrLf
        Me.request &= "<soapenv:Header/>" & vbCrLf
        Me.request &= "<soapenv:Body>" & vbCrLf
        Me.request &= "<ws:ReturnRegister>" & vbCrLf
        Me.request &= "<cardId>" & CStr(parameter("CardId")) & "</cardId>" & vbCrLf
        Me.request &= "<transactionDate>" & CStr(parameter("TransactionDate")) & "</transactionDate>" & vbCrLf
        Me.request &= "<amount>" & CStr(parameter("Amount")) & "</amount>" & vbCrLf
        Me.request &= "<totalAmount>" & CStr(parameter("TotalAmount")) & "</totalAmount>" & vbCrLf
        Me.request &= "<ticketid>" & CStr(parameter("ticketid")) & "</ticketid>" & vbCrLf
        Me.request &= "<storeid>" & CStr(parameter("StoreId")) & "</storeid>" & vbCrLf
        Me.request &= "<referenceId3>" & CStr(parameter("ReferenceId3")) & "</referenceId3>" & vbCrLf
        Me.request &= "<referenceId4>" & CStr(parameter("ReferenceId4")) & "</referenceId4>" & vbCrLf
        Me.request &= "<cashierCode>" & CStr(parameter("CashierCode")) & "</cashierCode>" & vbCrLf
        Me.request &= "<cashierName>" & CStr(parameter("CashierName")) & "</cashierName>" & vbCrLf
        Me.request &= "<supervisorCode>" & CStr(parameter("SupervisorCode")) & "</supervisorCode>" & vbCrLf
        Me.request &= "<supervisorName>" & CStr(parameter("SupervisorName")) & "</supervisorName>" & vbCrLf
        Me.request &= "<sellerCode>" & CStr(parameter("SellerCode")) & "</sellerCode>" & vbCrLf
        Me.request &= "<sellerName>" & CStr(parameter("SellerName")) & "</sellerName>" & vbCrLf
        Me.request &= "<products>" & CStr(parameter("Products")) & "</products>" & vbCrLf
        Me.request &= "</ws:ReturnRegister>" & vbCrLf
        Me.request &= "</soapenv:Body>" & vbCrLf
        Me.request &= "</soapenv:Envelope>"
        dsResultado = ConsumeXML(Me.CallMethod, Me.request)
        'dsResultado = ConsumeWSBroker(Me.CallMethod, Me.request)
        If Not dsResultado Is Nothing AndAlso dsResultado.Tables.Count > 0 Then
            If dsResultado.Tables.Contains("ReturnRegisterResponse") = True Then
                Dim table As DataTable = dsResultado.Tables("ReturnRegisterResponse")
                For Each row As DataRow In table.Rows
                    For Each column As DataColumn In table.Columns
                        If row.IsNull(column.ColumnName) = False Then
                            resultado(column.ColumnName) = row(column.ColumnName)
                        End If
                    Next
                Next
            End If
        End If
        Return resultado
    End Function

    '----------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 21/04/2015: Devolución de articulos cuando se retorna efectivo
    '----------------------------------------------------------------------------------------------------------------------------

    Public Function ReturnByMoneyRegister(ByVal parameter As Hashtable) As Hashtable
        Dim resultado As New Hashtable
        Dim dsResultado As DataSet = Nothing
        Me.request = "<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:ws=""http://WS_BLUE"">" & vbCrLf
        Me.request &= "<soapenv:Header/>" & vbCrLf
        Me.request &= "<soapenv:Body>" & vbCrLf
        Me.request &= "<ws:ReturnByMoneyRegister>" & vbCrLf
        Me.request &= "<cardId>" & CStr(parameter("CardId")) & "</cardId>" & vbCrLf
        Me.request &= "<transactionDate>" & CStr(parameter("TransactionDate")) & "</transactionDate>" & vbCrLf
        Me.request &= "<amount>" & CStr(parameter("Amount")) & "</amount>" & vbCrLf
        Me.request &= "<totalAmount>" & CStr(parameter("TotalAmount")) & "</totalAmount>" & vbCrLf
        Me.request &= "<ticketid>" & CStr(parameter("ticketid")) & "</ticketid>" & vbCrLf
        Me.request &= "<storeid>" & CStr(parameter("StoreId")) & "</storeid>" & vbCrLf
        Me.request &= "<referenceId3>" & CStr(parameter("ReferenceId3")) & "</referenceId3>" & vbCrLf
        Me.request &= "<referenceId4>" & CStr(parameter("ReferenceId4")) & "</referenceId4>" & vbCrLf
        Me.request &= "<cashierCode>" & CStr(parameter("CashierCode")) & "</cashierCode>" & vbCrLf
        Me.request &= "<cashierName>" & CStr(parameter("CashierName")) & "</cashierName>" & vbCrLf
        Me.request &= "<supervisorCode>" & CStr(parameter("SupervisorCode")) & "</supervisorCode>" & vbCrLf
        Me.request &= "<supervisorName>" & CStr(parameter("SupervisorName")) & "</supervisorName>" & vbCrLf
        Me.request &= "<sellerCode>" & CStr(parameter("SellerCode")) & "</sellerCode>" & vbCrLf
        Me.request &= "<sellerName>" & CStr(parameter("SellerName")) & "</sellerName>" & vbCrLf
        Me.request &= "<products>" & CStr(parameter("Products")) & "</products>" & vbCrLf
        Me.request &= "<tipo>" & CStr(parameter("tipo")) & "</tipo>" & vbCrLf
        Me.request &= "</ws:ReturnByMoneyRegister>" & vbCrLf
        Me.request &= "</soapenv:Body>" & vbCrLf
        Me.request &= "</soapenv:Envelope>"
        dsResultado = ConsumeXML(Me.CallMethod, Me.request)
        'dsResultado = ConsumeWSBroker(Me.CallMethod, Me.request)
        If Not dsResultado Is Nothing AndAlso dsResultado.Tables.Count > 0 Then
            If dsResultado.Tables.Contains("ReturnByMoneyRegisterResponse") = True Then
                Dim table As DataTable = dsResultado.Tables("ReturnByMoneyRegisterResponse")
                For Each row As DataRow In table.Rows
                    For Each column As DataColumn In table.Columns
                        If row.IsNull(column.ColumnName) = False Then
                            resultado(column.ColumnName) = row(column.ColumnName)
                        End If
                    Next
                Next
            End If
        End If
        Return resultado
    End Function

#End Region

#Region "Guias DHL"

    Public Function DHLCompleteSOAP(ByVal OficinaVtas As String, ByVal Pedido As String) As Hashtable

        Dim dsResultado As New DataSet
        Dim resultado As New Hashtable
        Me.request = "<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:dhl=""http://dhl.dportenis.com"">"
        Me.request &= "   <soapenv:Header/>"
        Me.request &= "   <soapenv:Body>"
        Me.request &= "      <dhl:SapZinfoPaqueteServ>"
        Me.request &= "         <IOficinaventas>" & OficinaVtas & "</IOficinaventas>"
        Me.request &= "         <IPaqueteria>DHL</IPaqueteria>"
        Me.request &= "         <IPedido>" & Pedido & "</IPedido>"
        Me.request &= "      </dhl:SapZinfoPaqueteServ>"
        Me.request &= "   </soapenv:Body>"
        Me.request &= "</soapenv:Envelope>"
        dsResultado = ConsumeXML(Me.CallMethod, Me.request)
        'dsResultado = ConsumeWSBroker(Me.CallMethod, Me.request)

        If Not dsResultado Is Nothing Then
            If dsResultado.Tables.Contains("ShipmentValidateResponse") = True Then
                Dim table As DataTable = dsResultado.Tables("ShipmentValidateResponse")
                For Each row As DataRow In table.Rows
                    For Each column As DataColumn In table.Columns
                        If row.IsNull(column.ColumnName) = False Then
                            resultado(column.ColumnName) = row(column.ColumnName)
                        End If
                    Next
                Next
            ElseIf dsResultado.Tables.Contains("ShipmentValidateErrorResponse") = True Then
                Dim strError As String = String.Empty
                Dim table As DataTable = dsResultado.Tables("Status")
                For Each row As DataRow In table.Rows
                    strError &= row!ActionStatus & vbCrLf
                Next
                EscribeLog(strError.TrimEnd, "Error al generar Guía de DHL en EC.")
            End If
        End If
        Return resultado

    End Function

#End Region

#Region "Consumo Blue"
    Public Function nuevos_servicios_blue(ByVal obj_envia As Dictionary(Of String, Object)) As Hashtable
        'Dim Servicio As String = "blue_api_s1/GetBalance"
        Dim Servicio As String = ""
        Dim oParams As New Dictionary(Of String, Object)

        '------------------------------------------------------------------
        ' JNAVA (16.03.2016): Ejecutamos la Transaccion
        '------------------------------------------------------------------
        Dim oRespuesta As Dictionary(Of String, Object)
        Dim oRespuesta_1 As String
        'oRespuesta = Me.ExecuteService(Servicio, oParams)
        oRespuesta_1 = Me.ExecuteService(Servicio, obj_envia)
        oRespuesta = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(oRespuesta_1)
        Dim return_hast As Hashtable
        return_hast = JsonConvert.DeserializeObject(Of Hashtable)(oRespuesta_1)

        '------------------------------------------------------------------
        ' JNAVA (16.03.2016): Obtenemos Informacion recibida
        '------------------------------------------------------------------
        If oRespuesta.ContainsKey("ErrorMessage") Then
            ' MessageBox.Show("Aqui se implementará el proceso de Offline" & vbCrLf & "", "Facturacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            oRespuesta = Nothing
            Exit Function
        End If
        Return return_hast
    End Function

    Private Function ExecuteService(Optional ByVal Name As String = "", Optional ByVal oServicio As Object = Nothing) As String

        Dim strJSON As String = ""
        Dim URL_REST As String
        Dim strRespuesta As String
        Dim result As Dictionary(Of String, Object)
        Dim result_hast As Hashtable

        'Definimos URL del Servicio REST
        URL_REST = Me.CallMethod

        'Seteamos parametros de cabecera
        'Me.htParametros("Satelite") = Me.Satelite
        'Me.htParametros("Tipo") = "S"
        'If htParametros.ContainsKey("SerialID") = False Then
        '    htParametros("SerialID") = oAppContext.ApplicationConfiguration.Almacen & oAppContext.ApplicationConfiguration.NoCaja & Guid.NewGuid().ToString()
        'End If

        Try
            'Serializamos datos de usuario a JSON
            If Not oServicio Is Nothing Then
                strJSON = CreateObjectPost(oServicio)
            End If

            'Obtenemos respuesta del servicio REST            
            strRespuesta = Consume_servicio(URL_REST, "", strJSON)

            'deserializamos JSON
            result = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(strRespuesta)
            If result.ContainsKey("ErrorMessage") Then
                Dim ErrorMessage As New Dictionary(Of String, Object)
                Dim Mensaje As String = String.Empty
                ErrorMessage = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(result("ErrorMessage").ToString)

                If ErrorMessage.ContainsKey("Mensaje") Then
                    Mensaje = "Servicio: " & Name & " Codigo: " & CStr(ErrorMessage("Codigo")) & vbCrLf & CStr(ErrorMessage("Mensaje"))
                ElseIf ErrorMessage.ContainsKey("msn") Then
                    Mensaje = "Servicio: " & Name & " " & Date.Now.ToShortDateString & ": " & vbCrLf & CStr(ErrorMessage("msn"))
                End If
                EscribeLog(Mensaje, "Ocurrio un error en en el WS de BLUE." + URL_REST)
                'MessageBox.Show("Ocurrio un error en S2Credit:" & vbCrLf & CStr(result("ErrorMessage")("msn")) & _
                '                vbCrLf & "Favor de reportar a Soporte.", "DPVale AIO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                'result = Nothing
            End If

        Catch ex As Exception
            Throw New ApplicationException(ex.Message, ex)
        End Try

        'Devolvemos informacion
        Return strRespuesta

    End Function
    Public Function CreateObjectPost(ByVal param As Dictionary(Of String, Object)) As String
        Dim conversion As New Dictionary(Of String, Object)
        Dim parametro As New Dictionary(Of String, Object)
        For Each row As String In param.Keys
            parametro(row) = param(row)
        Next
        Return JsonConvert.SerializeObject(parametro)
    End Function
    Public Function Consume_servicio(ByVal URL As String, ByVal strSoapEnvelope As String, ByRef StrXML As String) As String
        Dim oRequest As HttpWebRequest
        Dim oStream As Stream
        Dim oResponse As HttpWebResponse
        Dim oReader As StreamReader
        Dim strResponse As String
        Dim dsXML As New DataSet
        Dim result As Dictionary(Of String, Object)
        Dim XMLReader As New Hashtable
        Dim address As Uri
        Dim strRespuesta As String
        Dim return_hast As New Hashtable
        Dim lstOrdenDetail As Dictionary(Of String, Object)
        address = New Uri(URL)

        Try

            Dim data() As Byte
            'Instanciamos Objeto y seteamos parametros necesarios para consumir correctamente el REST
            oRequest = TryCast(WebRequest.Create(URL), HttpWebRequest)
            oRequest.Timeout = -1
            oRequest.Method = "POST"
            'oRequest.Headers.Add("X-Auth-User", "abel.sanchez") 'oConfigCierreFI
            oRequest.Headers.Add("X-Auth-User", oConfigCierreFI.UsrTokenBlue) 'oConfigCierreFI
            oRequest.Headers.Add("X-Auth-Token", "5F6UH_B}YvC?DVD9!5]W)8@v")
            data = UTF8Encoding.UTF8.GetBytes(StrXML)
            oRequest.ContentLength = data.Length
            oRequest.ContentType = "text/xml; charset=utf-8"
            oRequest.Accept = "text/xml; charset=utf-8"
            oStream = oRequest.GetRequestStream
            oStream.Write(data, 0, data.Length)
            'Obtenemos Respuesta
            oResponse = TryCast(oRequest.GetResponse(), HttpWebResponse)
            oReader = New StreamReader(oResponse.GetResponseStream())
            strRespuesta = oReader.ReadToEnd()
            return_hast = JsonConvert.DeserializeObject(Of Hashtable)(strRespuesta)
        Catch web As System.Web.HttpException
            If web.ErrorCode = 404 Then
                Throw New Exception(Convert.ToString("WebService no encontrado") & URL)
            Else
                Throw web
            End If
        Catch ex As Exception
            Throw New ApplicationException(ex.Message, ex)
        End Try
        Return strRespuesta
    End Function
#End Region

#End Region

End Class
