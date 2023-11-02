Imports System.Data.SqlClient
Imports DportenisPro.DPTienda.ApplicationUnits.AbonosApartadosAU
Imports DportenisPro.DPTienda.ApplicationUnits.Facturas
Imports DportenisPro.DPTienda.ApplicationUnits.FacturasCorrida
Imports DportenisPro.DPTienda.ApplicationUnits.CancelaFacturaAU
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU
Imports DportenisPro.DPTienda.ApplicationUnits.ContratosAU
Imports DportenisPro.DPTienda.ApplicationUnits.ValeCaja
Imports DportenisPro.DPTienda.ApplicationUnits.Clientes
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos
Imports System.Collections.Generic
Imports Newtonsoft.Json


Public Class Pedidos

#Region "Constructores"
    '---------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 25/04/2013: Constructor cuando se genera un pedido Nuevo
    '---------------------------------------------------------------------------------------------------------------------------------
    Public Sub New()

    End Sub

    '---------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 25/04/2013: Constructor cuando se carga un pedido por el ID Si el default es 0, 1: Folio del pedido, 2:Folio SAP
    '---------------------------------------------------------------------------------------------------------------------------------
    Public Sub New(ByVal ID As String, Optional ByVal Opcion As Integer = 0)
        Me.LoadData(ID, Opcion)
    End Sub

#End Region

#Region "Variables Pedidos"
    Private m_PedidoID As Integer = 0
    Private m_CodAlmacen As String = ""
    Private m_CodCaja As String = ""
    Private m_FolioPedido As Integer = 0
    Private m_Status As String = ""
    Private m_CodTipoVenta As String = ""
    Private m_ClienteID As String = ""
    Private m_ClientePGID As Integer = 0
    Private m_DistribuidorID As String = ""
    Private m_CodVendedor As String = ""
    Private m_DescTotal As Decimal = 0
    Private m_SubTotal As Decimal = 0
    Private m_IVA As Decimal = 0
    Private m_Total As Decimal = 0
    Private m_Impresa As Boolean = False
    Private m_Usuario As String = ""
    Private m_Fecha As DateTime = DateTime.Now
    Private m_StatusRegistro As Boolean = False
    Private m_NumeroFacilito As String = ""
    Private m_FolioSAP As String = ""
    Private m_FolioFISAP As String = ""
    Private m_DPesos As Decimal = 0
    Private m_FCFolioSAP As String = ""
    Private m_FCFolioFISAP As String = ""
    Private m_PedidoDetalle() As PedidoDetalles
    Private m_Facturas() As Factura
    Private m_ArticulosNoFacturados As DataTable
    Private m_ArticulosFacturados As DataTable
    Private m_ExistenciasMinimas As DataTable
    Private m_FormasPago As DataTable
    Private m_IsNew As Boolean = True
    Private m_IsDirty As Boolean = False
    Private m_strCuponDevuelto As String = ""
    Private m_NoDPCardPuntos As String = ""
    Private m_CodDPCardPunto As String = ""
    Private m_ValeEmpleado As String = ""
    Private m_Referencia As String = ""
    Private m_SerialId As String = ""
    Private m_DPValeId As String = ""
    Private m_CancelaPedidoSH As Boolean = False
#End Region

#Region "Propiedades"
    Public ReadOnly Property PedidoID() As Integer
        Get
            Return m_PedidoID
        End Get
    End Property

    Public Property CodAlmacen() As String
        Get
            Return m_CodAlmacen
        End Get
        Set(ByVal Value As String)
            Me.m_IsDirty = True
            m_CodAlmacen = Value
        End Set
    End Property

    Public Property CodCaja() As String
        Get
            Return m_CodCaja
        End Get
        Set(ByVal Value As String)
            Me.m_IsDirty = True
            m_CodCaja = Value
        End Set
    End Property

    Public Property FolioPedido() As Integer
        Get
            Return m_FolioPedido
        End Get
        Set(ByVal Value As Integer)
            Me.m_IsDirty = True
            m_FolioPedido = Value
        End Set
    End Property

    Public Property Status() As String
        Get
            Return m_Status
        End Get
        Set(ByVal Value As String)
            Me.m_IsDirty = True
            m_Status = Value
        End Set
    End Property

    Public Property CodTipoVenta() As String
        Get
            Return m_CodTipoVenta
        End Get
        Set(ByVal Value As String)
            Me.m_IsDirty = True
            m_CodTipoVenta = Value
        End Set
    End Property

    Public Property ClienteID() As String
        Get
            Return m_ClienteID
        End Get
        Set(ByVal Value As String)
            Me.m_IsDirty = True
            m_ClienteID = Value
        End Set
    End Property

    Public Property ClientePGID() As Integer
        Get
            Return m_ClientePGID
        End Get
        Set(ByVal Value As Integer)
            Me.m_IsDirty = True
            m_ClientePGID = Value
        End Set
    End Property

    Public Property DistribuidorID() As String
        Get
            Return m_DistribuidorID
        End Get
        Set(ByVal Value As String)
            m_DistribuidorID = Value
        End Set
    End Property

    Public Property CodVendedor() As String
        Get
            Return m_CodVendedor
        End Get
        Set(ByVal Value As String)
            Me.m_IsDirty = True
            m_CodVendedor = Value
        End Set
    End Property

    Public Property DescTotal() As Decimal
        Get
            Return m_DescTotal
        End Get
        Set(ByVal Value As Decimal)
            Me.m_IsDirty = True
            m_DescTotal = Value
        End Set
    End Property

    Public Property SubTotal() As Decimal
        Get
            Return m_SubTotal
        End Get
        Set(ByVal Value As Decimal)
            Me.m_IsDirty = True
            m_SubTotal = Value
        End Set
    End Property

    Public Property IVA() As Decimal
        Get
            Return m_IVA
        End Get
        Set(ByVal Value As Decimal)
            Me.m_IsDirty = True
            m_IVA = Value
        End Set
    End Property

    Public Property Total() As Decimal
        Get
            Return m_Total
        End Get
        Set(ByVal Value As Decimal)
            Me.m_IsDirty = True
            m_Total = Value
        End Set
    End Property

    Public Property Impresa() As Boolean
        Get
            Return m_Impresa
        End Get
        Set(ByVal Value As Boolean)
            Me.m_IsDirty = True
            m_Impresa = Value
        End Set
    End Property

    Public Property Usuario() As String
        Get
            Return m_Usuario
        End Get
        Set(ByVal Value As String)
            Me.m_IsDirty = True
            m_Usuario = Value
        End Set
    End Property

    Public Property Fecha() As DateTime
        Get
            Return m_Fecha
        End Get
        Set(ByVal Value As DateTime)
            Me.m_IsDirty = True
            m_Fecha = Value
        End Set
    End Property

    Public Property StatusRegistro() As Boolean
        Get
            Return m_StatusRegistro
        End Get
        Set(ByVal Value As Boolean)
            Me.m_IsDirty = True
            m_StatusRegistro = Value
        End Set
    End Property

    Public Property NumeroFacilito() As String
        Get
            Return m_NumeroFacilito
        End Get
        Set(ByVal Value As String)
            Me.m_IsDirty = True
            m_NumeroFacilito = Value
        End Set
    End Property

    Public Property FolioSAP() As String
        Get
            Return m_FolioSAP
        End Get
        Set(ByVal Value As String)
            Me.m_IsDirty = True
            m_FolioSAP = Value
        End Set
    End Property

    Public Property FolioFISAP() As String
        Get
            Return m_FolioFISAP
        End Get
        Set(ByVal Value As String)
            Me.m_IsDirty = True
            m_FolioFISAP = Value
        End Set
    End Property

    Public Property DPesos() As Decimal
        Get
            Return m_DPesos
        End Get
        Set(ByVal Value As Decimal)
            Me.m_IsDirty = True
            m_DPesos = Value
        End Set
    End Property

    Public Property FCFolioSAP() As String
        Get
            Return m_FCFolioSAP
        End Get
        Set(ByVal Value As String)
            Me.m_IsDirty = True
            m_FCFolioSAP = Value
        End Set
    End Property

    Public Property FCFolioFISAP() As String
        Get
            Return m_FCFolioFISAP
        End Get
        Set(ByVal Value As String)
            Me.m_IsDirty = True
            m_FCFolioFISAP = Value
        End Set
    End Property

    Public Property PedidosDetalles() As PedidoDetalles()
        Get
            Return m_PedidoDetalle
        End Get
        Set(ByVal Value() As PedidoDetalles)
            Me.m_IsDirty = True
            m_PedidoDetalle = Value
        End Set
    End Property

    Public ReadOnly Property Facturas() As Factura()
        Get
            Return m_Facturas
        End Get
    End Property

    Public ReadOnly Property ArticulosNoFacturados() As DataTable
        Get
            Return m_ArticulosNoFacturados
        End Get
    End Property

    Public ReadOnly Property ArticulosFacturados() As DataTable
        Get
            Return m_ArticulosFacturados
        End Get
    End Property

    Public Property ExistenciasMinimas() As DataTable
        Get
            Return m_ExistenciasMinimas
        End Get
        Set(ByVal Value As DataTable)
            m_ExistenciasMinimas = Value
        End Set
    End Property

    Public ReadOnly Property FormasPago() As DataTable
        Get
            Return m_FormasPago
        End Get
    End Property

    Public ReadOnly Property IsNew() As Boolean
        Get
            Return m_IsNew
        End Get
    End Property

    Public ReadOnly Property IsDirty() As Boolean
        Get
            Return m_IsDirty
        End Get
    End Property

    Public Property CuponDevuelto() As String
        Get
            Return m_strCuponDevuelto
        End Get
        Set(ByVal Value As String)
            m_strCuponDevuelto = Value
        End Set
    End Property

    Public Property NoDPCardPuntos() As String
        Get
            Return m_NoDPCardPuntos
        End Get
        Set(ByVal Value As String)
            m_NoDPCardPuntos = Value
        End Set
    End Property

    Public Property CodDPCardPunto() As String
        Get
            Return m_CodDPCardPunto
        End Get
        Set(ByVal Value As String)
            m_CodDPCardPunto = Value
        End Set
    End Property

    Public Property ValeEmpleado As String
        Get
            Return m_ValeEmpleado
        End Get
        Set(value As String)
            m_ValeEmpleado = value
        End Set
    End Property

    Public Property Referencia As String
        Get
            Return m_Referencia
        End Get
        Set(value As String)
            m_Referencia = value
        End Set
    End Property

    Public Property SerialId As String
        Get
            Return m_SerialId
        End Get
        Set(value As String)
            m_SerialId = value
        End Set
    End Property

    Public Property DPValeID As String
        Get
            Return m_DPValeId
        End Get
        Set(ByVal value As String)
            m_DPValeId = value
        End Set
    End Property

    Public Property CancelaPedidoSH() As Boolean
        Get
            Return m_CancelaPedidoSH
        End Get
        Set(ByVal Value As Boolean)
            m_CancelaPedidoSH = Value
        End Set
    End Property

#End Region

#Region "Metodos Privados"

    '---------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA: 25/04/2013: Funcion para cargar los datos del pedido al objeto
    '---------------------------------------------------------------------------------------------------------------------------------
    Private Function LoadData(ByVal ID As String, ByVal Opcion As Integer)
        Dim conexion As New SqlConnection(oAppContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString())
        Dim command As New SqlCommand("LoadDataPedido", conexion)
        Dim adapter As SqlDataAdapter = Nothing
        Dim reader As SqlDataReader = Nothing
        Dim datos As New DataTable
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@ID", ID)
            command.Parameters.Add("@Opcion", Opcion)
            reader = command.ExecuteReader()
            While reader.Read
                Me.m_PedidoID = CInt(reader("PedidoID"))
                Me.CodAlmacen = CStr(reader("CodAlmacen"))
                Me.CodCaja = CStr(reader("CodCaja"))
                Me.FolioPedido = CInt(reader("FolioPedido"))
                Me.Status = CStr(reader("Status"))
                Me.CodTipoVenta = CStr(reader("CodTipoVenta"))
                Me.ClienteID = CInt(reader("ClienteID")).ToString()
                Me.ClientePGID = CInt(reader("ClientePGID"))
                Me.CodVendedor = CStr(reader("CodVendedor"))
                Me.DescTotal = CDec(reader("DescTotal"))
                Me.SubTotal = CDec(reader("SubTotal"))
                Me.IVA = CDec(reader("IVA"))
                Me.Total = CDec(reader("Total"))
                Me.Impresa = CBool(reader("Impresa"))
                Me.Usuario = CStr(reader("Usuario"))
                Me.Fecha = CDate(reader("Fecha"))
                Me.StatusRegistro = CBool(reader("StatusRegistro"))
                Me.NumeroFacilito = CStr(reader("NumeroFacilito"))
                Me.FolioSAP = CStr(reader("FolioSAP"))
                Me.FolioFISAP = CStr(reader("FolioFISAP"))
                Me.DPesos = CDec(reader("DPesos"))
                Me.FCFolioSAP = CStr(reader("FCFolioSAP"))
                Me.FCFolioFISAP = CStr(reader("FCFolioFISAP"))
                If IsDBNull(reader("CuponDevuelto")) = False Then Me.CuponDevuelto = CStr(reader("CuponDevuelto"))
                If IsDBNull(reader("NoDPCardPuntos")) = False Then Me.NoDPCardPuntos = CStr(reader("NoDPCardPuntos"))
                If IsDBNull(reader("CodDPCardPunto")) = False Then Me.CodDPCardPunto = CStr(reader("CodDPCardPunto"))
                Me.Referencia = CStr(reader("Referencia"))
            End While
            Me.m_IsNew = False
            Me.m_IsDirty = False
            command.Dispose()
            If Me.PedidoID > 0 Then
                Me.PedidosDetalles = PedidoDetalles.GetPedidoDetallesByPedidoID(Me.PedidoID)
                Me.m_Facturas = Me.GetFacturas()
                Me.m_FormasPago = Me.GetFormasPagoByPedido()
                If Me.m_FormasPago.Rows.Count > 0 Then
                    For Each row As DataRow In Me.m_FormasPago.Rows
                        If CStr(row("DPValeID")).Trim() <> "" AndAlso CStr(row("CodFormasPago")).Trim().ToUpper() = "DPVL" Then
                            Me.m_DPValeId = CStr(row("DPValeID"))
                        End If
                    Next
                End If
                Me.m_ArticulosNoFacturados = GetArticulosNoFacturados()
            End If
            reader.Close()
            command.Dispose()
            conexion.Close()
        Catch sql As SqlException
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            EscribeLog(sql.Message, "Hubo un error al leer el objeto en la base de datos")
            Throw New ApplicationException("Hubo un error al leer el objeto en la base de datos", sql)
        Catch ex As Exception
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            EscribeLog(ex.Message, "Hubo un error en la aplicación")
            Throw New ApplicationException("Hubo un error en la aplicación", ex)
        End Try
    End Function

    Public Function CargarFormasPagoDPVale(ByVal dsFormasPago As DataSet, ByVal ebCambioCliente As Decimal)
        Dim dtFormasPago As DataTable = dsFormasPago.Tables(0).Copy()
        Dim fila As DataRow = Nothing
        For Each row As DataRow In dtFormasPago.Rows
            With row
                If .Item("CodFormasPago") = "EFEC" And ebCambioCliente > 0 Then
                    .Item("MontoPago") = .Item("MontoPago") - ebCambioCliente
                End If
                .AcceptChanges()
            End With
        Next
        dtFormasPago.AcceptChanges()
        Me.m_FormasPago = dtFormasPago
    End Function

    '---------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 26/04/2013: Limpia los valores del objeto
    '---------------------------------------------------------------------------------------------------------------------------------

    Private Function ClearValues()
        Me.m_PedidoID = 0
        Me.CodAlmacen = ""
        Me.CodCaja = ""
        Me.FolioPedido = 0
        Me.Status = ""
        Me.CodTipoVenta = ""
        Me.ClienteID = 0
        Me.CodVendedor = ""
        Me.DescTotal = 0
        Me.SubTotal = 0
        Me.IVA = 0
        Me.Total = 0
        Me.Impresa = False
        Me.Usuario = ""
        Me.Fecha = DateTime.Now
        Me.StatusRegistro = False
        Me.NumeroFacilito = ""
        Me.FolioSAP = ""
        Me.FolioFISAP = ""
        Me.DPesos = 0
        Me.FCFolioSAP = ""
        Me.FCFolioFISAP = ""
    End Function

    '---------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 03/05/2013: Obtiene las facturas que se han hecho del Pedido
    '---------------------------------------------------------------------------------------------------------------------------------

    Private Shared Function GetFacturasByPedido(ByVal PedidoID As Integer) As DataTable
        Dim conexion As New SqlConnection(oAppContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString())
        Dim command As New SqlCommand("GetFacturasByPedido", conexion)
        Dim adapter As SqlDataAdapter = Nothing
        Dim ds As New DataTable
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@PedidoID", PedidoID)
            adapter = New SqlDataAdapter(command)
            adapter.Fill(ds)
            command.Dispose()
            conexion.Close()
        Catch sql As SqlException
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            EscribeLog(sql.Message, "Hubo un error al leer el objeto en la base de datos")
            Throw New ApplicationException("Hubo un error al leer el objeto en la base de datos", sql)
        Catch ex As Exception
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            EscribeLog(ex.Message, "Hubo un error en la aplicación")
            Throw New ApplicationException("Hubo un error en la aplicación", ex)
        End Try
        Return ds
    End Function

    '---------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 03/05/2013: Obtiene las colección de facturas que tenga el Pedido
    '---------------------------------------------------------------------------------------------------------------------------------

    Private Function GetFacturas() As Factura()
        Dim FacturaMgr As New FacturaManager(oAppContext, oConfigCierreFI)
        Dim FacturaCorridaMgr As New FacturaCorridaManager(oAppContext)
        Dim Facturas() As Factura
        Dim count As Integer = 0, facturaID As Integer = 0, FolioFactura As Integer = 0
        Dim dsFacturas As DataTable = GetFacturasByPedido(Me.PedidoID)

        If dsFacturas.Rows.Count > 0 Then
            ReDim Facturas(dsFacturas.Rows.Count - 1)
        End If
        Dim index As Integer = 0
        For Each row As DataRow In dsFacturas.Rows
            facturaID = CInt(row!FacturaID)
            FolioFactura = CInt(row!FolioFactura)
            Facturas(index) = FacturaMgr.Create()
            FacturaMgr.LoadInto(facturaID, Facturas(index))
            Facturas(index).Detalle = FacturaCorridaMgr.LoadDetalle(FolioFactura, Me.PedidoID)
            count = Facturas(index).Detalle.Tables(0).Rows.Count
            index += 1
        Next
        Return Facturas
    End Function
    '--------------------------------------------------------------------------------------------------------------------------------------
    'RGERMAIN 03.11.2014: Cargamos la estrcutura con sus datos de la factura que se va a generar por lo productos que si hay en la tienda
    '--------------------------------------------------------------------------------------------------------------------------------------
    Private Function CargaFactura(ByVal dtDetalle As DataTable, ByRef oFactura As Factura) As Factura

    End Function
    '--------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 03/05/2013: Obtiene los productos Articulos que aun no se han Facturado
    '--------------------------------------------------------------------------------------------------------------------------------

    Private Function GetArticulosNoFacturados() As DataTable
        Dim dtArticulos As DataTable = CreateStructureArticulosNoFacturados()
        If Me.PedidosDetalles.Length > 0 Then
            Dim catalogoArticulo As New CatalogoArticuloManager(oAppContext)
            Dim oArticulo As Articulo = catalogoArticulo.Create()
            For Each detalle As PedidoDetalles In PedidosDetalles
                oArticulo.ClearFields()
                catalogoArticulo.LoadInto(detalle.CodArticulo, oArticulo)
                If Not Me.Facturas Is Nothing Then
                    Dim existe As Boolean = Me.ExisteDetalle(detalle.CodArticulo, detalle.Numero)
                    If existe = True Then
                        Dim cantDetalle As Integer = GetSumCantidad(detalle.CodArticulo, detalle.Numero)
                        If detalle.Cantidad - cantDetalle > 0 Then
                            Dim row As DataRow = dtArticulos.NewRow()
                            row("CodArticulo") = detalle.CodArticulo
                            row("Descripcion") = oArticulo.Descripcion
                            row("Numero") = detalle.Numero
                            row("Cantidad") = detalle.Cantidad - cantDetalle
                            row("PrecioUnitario") = detalle.PrecioUnit
                            row("Preciooferta") = detalle.PrecioUnit
                            row("Total") = detalle.PrecioUnit * (detalle.Cantidad - cantDetalle)
                            row("CantDescuentoSistema") = (detalle.CantDescuentoSistema / detalle.Cantidad) * (detalle.Cantidad - cantDetalle)
                            row("Descuento") = detalle.Descuento
                            row("Adicional") = detalle.Descuento
                            row("Condicion") = detalle.Condicion
                            dtArticulos.Rows.Add(row)
                        End If
                    Else
                        Dim row As DataRow = dtArticulos.NewRow()
                        row("CodArticulo") = detalle.CodArticulo
                        row("Descripcion") = oArticulo.Descripcion
                        row("Numero") = detalle.Numero
                        row("Cantidad") = detalle.Cantidad
                        row("PrecioUnitario") = detalle.PrecioUnit
                        row("Preciooferta") = detalle.PrecioUnit
                        row("Total") = detalle.Total
                        row("CantDescuentoSistema") = detalle.CantDescuentoSistema
                        row("Descuento") = detalle.Descuento
                        row("Adicional") = detalle.Descuento
                        row("Condicion") = detalle.Condicion
                        dtArticulos.Rows.Add(row)
                    End If
                Else
                    Dim row As DataRow = dtArticulos.NewRow()
                    row("CodArticulo") = detalle.CodArticulo
                    row("Descripcion") = oArticulo.Descripcion
                    row("Numero") = detalle.Numero
                    row("Cantidad") = detalle.Cantidad
                    row("PrecioUnitario") = detalle.PrecioUnit
                    row("Preciooferta") = detalle.PrecioUnit
                    row("Total") = detalle.Total
                    row("CantDescuentoSistema") = detalle.CantDescuentoSistema
                    row("Descuento") = detalle.Descuento
                    row("Adicional") = detalle.Descuento
                    row("Condicion") = detalle.Condicion
                    dtArticulos.Rows.Add(row)
                End If
            Next
        End If
        Return dtArticulos
    End Function

    Private Function GetArticulosFacturados() As DataTable
        Dim dtArticulos As DataTable = CreateStructureArticulosNoFacturados()
        If Me.PedidosDetalles.Length > 0 Then
            Dim catalogoArticulo As New CatalogoArticuloManager(oAppContext)
            Dim oArticulo As Articulo = catalogoArticulo.Create()
            For Each detalle As PedidoDetalles In PedidosDetalles
                oArticulo.ClearFields()
                catalogoArticulo.LoadInto(detalle.CodArticulo, oArticulo)
                Dim row As DataRow = dtArticulos.NewRow()
                row("CodArticulo") = detalle.CodArticulo
                row("Descripcion") = oArticulo.Descripcion
                row("Numero") = detalle.Numero
                row("Cantidad") = detalle.Cantidad
                row("PrecioUnitario") = detalle.PrecioUnit
                row("Preciooferta") = detalle.PrecioUnit
                row("Total") = detalle.Total
                row("CantDescuentoSistema") = detalle.CantDescuentoSistema
                row("Descuento") = detalle.Descuento
                row("Adicional") = detalle.Descuento
                row("Condicion") = detalle.Condicion
                dtArticulos.Rows.Add(row)

                'If Not Me.Facturas Is Nothing Then
                '    Dim existe As Boolean = Me.ExisteDetalle(detalle.CodArticulo, detalle.Numero)
                '    If existe = True Then
                '        Dim cantDetalle As Integer = GetSumCantidad(detalle.CodArticulo, detalle.Numero)
                '        If detalle.Cantidad - cantDetalle > 0 Then
                '            Dim row As DataRow = dtArticulos.NewRow()
                '            row("CodArticulo") = detalle.CodArticulo
                '            row("Descripcion") = oArticulo.Descripcion
                '            row("Numero") = detalle.Numero
                '            row("Cantidad") = detalle.Cantidad - cantDetalle
                '            row("PrecioUnitario") = detalle.PrecioUnit
                '            row("Preciooferta") = detalle.PrecioUnit
                '            row("Total") = detalle.PrecioUnit * (detalle.Cantidad - cantDetalle)
                '            row("CantDescuentoSistema") = (detalle.CantDescuentoSistema / detalle.Cantidad) * (detalle.Cantidad - cantDetalle)
                '            row("Descuento") = detalle.Descuento
                '            row("Adicional") = detalle.Descuento
                '            row("Condicion") = detalle.Condicion
                '            dtArticulos.Rows.Add(row)
                '        End If
                '    Else
                '        Dim row As DataRow = dtArticulos.NewRow()
                '        row("CodArticulo") = detalle.CodArticulo
                '        row("Descripcion") = oArticulo.Descripcion
                '        row("Numero") = detalle.Numero
                '        row("Cantidad") = detalle.Cantidad
                '        row("PrecioUnitario") = detalle.PrecioUnit
                '        row("Preciooferta") = detalle.PrecioUnit
                '        row("Total") = detalle.Total
                '        row("CantDescuentoSistema") = detalle.CantDescuentoSistema
                '        row("Descuento") = detalle.Descuento
                '        row("Adicional") = detalle.Descuento
                '        row("Condicion") = detalle.Condicion
                '        dtArticulos.Rows.Add(row)
                '    End If
                'Else
                '    Dim row As DataRow = dtArticulos.NewRow()
                '    row("CodArticulo") = detalle.CodArticulo
                '    row("Descripcion") = oArticulo.Descripcion
                '    row("Numero") = detalle.Numero
                '    row("Cantidad") = detalle.Cantidad
                '    row("PrecioUnitario") = detalle.PrecioUnit
                '    row("Preciooferta") = detalle.PrecioUnit
                '    row("Total") = detalle.Total
                '    row("CantDescuentoSistema") = detalle.CantDescuentoSistema
                '    row("Descuento") = detalle.Descuento
                '    row("Adicional") = detalle.Descuento
                '    row("Condicion") = detalle.Condicion
                '    dtArticulos.Rows.Add(row)
                'End If
            Next
        End If
        Return dtArticulos
    End Function

    '---------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 03/05/2013: Creacion de la estructura de los articulos no Facturados
    '---------------------------------------------------------------------------------------------------------------------------------

    Private Function CreateStructureArticulosNoFacturados() As DataTable
        Dim dtArticulos As New DataTable("ArticulosConExistencia")
        dtArticulos.Columns.Add("CodArticulo", GetType(String))
        dtArticulos.Columns.Add("Descripcion", GetType(String))
        dtArticulos.Columns.Add("Numero", GetType(String))
        dtArticulos.Columns.Add("Cantidad", GetType(Integer))
        dtArticulos.Columns.Add("PrecioUnitario", GetType(Decimal))
        dtArticulos.Columns.Add("Preciooferta", GetType(Decimal))
        dtArticulos.Columns.Add("Total", GetType(Decimal))
        dtArticulos.Columns.Add("CantDescuentoSistema", GetType(Decimal))
        dtArticulos.Columns.Add("Descuento", GetType(Decimal))
        dtArticulos.Columns.Add("Condicion", GetType(String))
        dtArticulos.Columns.Add("Adicional", GetType(Decimal))
        dtArticulos.AcceptChanges()
        Return dtArticulos
    End Function

    '--------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 03/05/2013: Retorna la cantidad de articulos facturado en el detalle
    '--------------------------------------------------------------------------------------------------------------------------------

    Private Function GetSumCantidad(ByVal CodArticulo As String, ByVal Numero As String) As Integer
        Dim cantidad As Integer = 0
        If Not Me.Facturas Is Nothing Then
            For Each factura As Factura In Me.Facturas
                For Each row As DataRow In factura.Detalle.Tables(0).Rows
                    Dim codigo As String = CStr(row!CodArticulo)
                    Dim talla As String = CStr(row!Numero)
                    Dim cant As Integer = CInt(row!Cantidad)
                    If CodArticulo = codigo Then  'AndAlso Numero = talla 
                        cantidad += cant
                    End If
                Next
            Next
        End If
        Return cantidad
    End Function

    '-------------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 21/05/2013: Revisa si existe el articulo en el detalle de las facturas
    '-------------------------------------------------------------------------------------------------------------------------------------

    Private Function ExisteDetalle(ByVal CodArticulo As String, ByVal Numero As String) As Boolean
        Dim existe As Boolean = False
        If Not Me.Facturas Is Nothing Then
            For Each factura As Factura In Me.Facturas
                For Each row As DataRow In factura.Detalle.Tables(0).Rows
                    Dim codigo As String = CStr(row!CodArticulo)
                    Dim talla As String = CStr(row!Numero)
                    If CodArticulo = codigo Then  'AndAlso Numero = talla 
                        Return True
                    End If
                Next
            Next
        End If
        Return existe
    End Function

    '-------------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 13/05/2013: Crea la tabla de Productos con el que se va guardar el pedido en SAP
    '-------------------------------------------------------------------------------------------------------------------------------------

    Private Function CreateTableT_Productos() As DataTable
        Dim T_Productos As New DataTable("T_PRODUCTOS")
        T_Productos.Columns.Add("INDEX", GetType(Integer))
        T_Productos.Columns.Add("CENTRO", GetType(String))
        T_Productos.Columns.Add("MATNR", GetType(String))
        T_Productos.Columns.Add("TALLA", GetType(String))
        T_Productos.Columns.Add("CANTIDAD", GetType(Integer))
        T_Productos.Columns.Add("CANT_FACT", GetType(Integer))
        T_Productos.AcceptChanges()
        Return T_Productos
    End Function

    '-------------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 13/05/2013: Crea la tabla de T_FPAGOS para su posterior guardado en SAP
    '-------------------------------------------------------------------------------------------------------------------------------------

    Private Function CreateTableT_FPAGOS() As DataTable
        Dim T_FPAGOS As New DataTable("T_FPAGOS")
        T_FPAGOS.Columns.Add("POSNR", GetType(String))
        T_FPAGOS.Columns.Add("FORMA_PAGO", GetType(String))
        T_FPAGOS.Columns.Add("NUMVA", GetType(String))
        T_FPAGOS.Columns.Add("DISTRIB", GetType(String))
        T_FPAGOS.Columns.Add("KUNNR", GetType(String))
        T_FPAGOS.Columns.Add("IMPORTE", GetType(Decimal))
        T_FPAGOS.Columns.Add("INTERESES", GetType(Decimal))
        T_FPAGOS.Columns.Add("NUMDE", GetType(String))
        T_FPAGOS.Columns.Add("PARES_PZAS", GetType(String))
        T_FPAGOS.Columns.Add("RPARES_PZAS", GetType(Integer))
        T_FPAGOS.Columns.Add("MONTOUTILIZADO", GetType(String))
        T_FPAGOS.Columns.Add("MONTODPVALE", GetType(Decimal))
        T_FPAGOS.Columns.Add("RMONTODPVALE", GetType(Decimal))
        T_FPAGOS.Columns.Add("REVALE", GetType(String))
        T_FPAGOS.Columns.Add("FECCO", GetType(String))
        T_FPAGOS.Columns.Add("REFERENCIA", GetType(String))
        T_FPAGOS.Columns.Add("FOLIO", GetType(String))
        T_FPAGOS.Columns.Add("PER_FINANC", GetType(String))
        T_FPAGOS.Columns.Add("NUM_APROBACION", GetType(String))
        T_FPAGOS.Columns.Add("NTARJETA", GetType(String))
        T_FPAGOS.Columns.Add("SIHAY", GetType(String))
        T_FPAGOS.Columns.Add("PEDIDOSH", GetType(String))
        T_FPAGOS.Columns.Add("STATUS", GetType(String))
        T_FPAGOS.Columns.Add("ZSEG", GetType(String))
        T_FPAGOS.Columns.Add("IMPSEG", GetType(Decimal))
        T_FPAGOS.Columns.Add("FOLSEG", GetType(Decimal))
        T_FPAGOS.Columns.Add("DIV", GetType(Decimal))
        'T_FPAGOS.Columns.Add("SIHAY", GetType(String))

        T_FPAGOS.AcceptChanges()
        Return T_FPAGOS
    End Function

    '------------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 13/05/2013: Crea la tabla de T_CONDICIONES guarda las condiciones de la venta en SAP
    '------------------------------------------------------------------------------------------------------------------------------------

    Private Function CreateTableT_CONDICIONES() As DataTable
        Dim T_CONDICIONES As New DataTable("T_CONDICIONES")
        T_CONDICIONES.Columns.Add("INDEX", GetType(Integer))
        T_CONDICIONES.Columns.Add("CONDICION", GetType(String))
        T_CONDICIONES.Columns.Add("IMPORTE", GetType(Decimal))
        T_CONDICIONES.AcceptChanges()
        Return T_CONDICIONES
    End Function

    '------------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 13/05/2013: Función para obtener las formas de pago del pedido
    '------------------------------------------------------------------------------------------------------------------------------------

    Private Function GetFormasPagoByPedido() As DataTable
        Dim conexion As New SqlConnection(oAppContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString())
        Dim command As New SqlCommand("GetFormasPagoByPedido", conexion)
        Dim adapter As SqlDataAdapter = Nothing
        Dim formaspago As New DataTable
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@PedidoID", Me.PedidoID)
            adapter = New SqlDataAdapter(command)
            adapter.Fill(formaspago)
            command.Dispose()
            conexion.Close()
        Catch sql As SqlException
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            EscribeLog(sql.Message, "Hubo un error al leer el objeto en la base de datos")
            Throw New ApplicationException("Hubo un error al leer el objeto en la base de datos", sql)
        Catch ex As Exception
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            EscribeLog(ex.Message, "Hubo un error en la aplicación")
            Throw New ApplicationException("Hubo un error en la aplicación", ex)
        End Try
        Return formaspago
    End Function

    '-------------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 13/05/2013: Obtiene la cantidad del articulo que ya ha sido facturada
    '-------------------------------------------------------------------------------------------------------------------------------------

    Private Function GetCant_Factura(ByVal material As String, ByVal talla As String, Optional ByVal dtDetalleFactura As DataTable = Nothing) As Integer
        Dim CorridaMgr As New FacturaCorridaManager(oAppContext)
        Dim cantidad As Integer = 0, detalle As DataTable, rows() As DataRow

        If Me.CodTipoVenta.Trim.ToUpper <> "V" Then
            If Not Me.Facturas Is Nothing AndAlso Me.Facturas.Length > 0 Then
                For Each factura As Factura In Me.Facturas
                    detalle = CorridaMgr.LoadDetalle(factura.FolioFactura, oAppContext.ApplicationConfiguration.NoCaja).Tables(0)
                    rows = detalle.Select("CodArticulo='" & material & "' AND Numero='" & talla & "'")
                    If rows.Length > 0 Then
                        cantidad += CInt(rows(0)!Cantidad)
                    End If
                Next
            End If
        ElseIf Not dtDetalleFactura Is Nothing Then
            rows = dtDetalleFactura.Select("CodArticulo='" & material & "' AND Numero='" & talla & "'")
            If rows.Length > 0 Then cantidad = CInt(rows(0)!Cantidad)
        End If

        Return cantidad
    End Function

    '-------------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 15/05/2013: Obtiene la cantidad que va ir en la cabecera principal del detalle de Articulo
    '-------------------------------------------------------------------------------------------------------------------------------------

    Private Function GetCantidad(ByVal material As String, ByVal talla As String) As Integer
        Dim cantidad As Integer = 0
        If Not Me.ExistenciasMinimas Is Nothing Then
            If IsNumeric(talla) Then
                talla = Format(CDec(talla), "#.0")
            End If
            Dim resta As Object = Me.ExistenciasMinimas.Compute("SUM(Cantidad)", "CodArticulo='" & material & "' AND Talla='" & talla & "'")
            If IsDBNull(resta) = False Then
                cantidad = resta
            End If
        End If
        Return cantidad
    End Function

    '-------------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 22/05/2013: Obtiene los mensajes de error que haya enviado la RFCs
    '-------------------------------------------------------------------------------------------------------------------------------------

    Private Function GetMessageRFC(ByVal dtError As DataTable) As String
        Dim strError As String = ""
        For Each row As DataRow In dtError.Rows
            strError &= CStr(row!MESSAGE) & vbCrLf
        Next
        Return strError
    End Function

    '-------------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 22/05/2013: Genera el vale de caja
    '-------------------------------------------------------------------------------------------------------------------------------------

    Private Function GenerarValeCaja(ByVal Devolucion As Integer, ByVal ImporteValeCaja As Decimal, ByRef strMensaje As String, Optional ByVal DocFiEfectivo As String = "") As Integer
        strMensaje = ""
        Dim ValeCajaID As Integer = 0
        Try
            Dim oValeNuevo As ValeCaja
            Dim oValeCajaMgr As New ValeCajaManager(oAppContext)
            Dim oClientesMgr As New ClientesManager(oAppContext, oAppSAPConfig, oConfigCierreFI)
            Dim oCliente As ClienteAlterno
            Dim CodCliente As String, ClienteNombre As String

            ''Obtenemos los datos necesariso del Cliente
            oCliente = oClientesMgr.CreateAlterno
            If Me.CodTipoVenta.Trim() = "P" Then
                oClientesMgr.Load(CStr(Me.ClientePGID).PadLeft(10, "0"), oCliente)
            Else
                oClientesMgr.Load(CStr(Me.ClienteID).PadLeft(10, "0"), oCliente, Me.CodTipoVenta)
            End If

            CodCliente = oCliente.CodigoAlterno
            ClienteNombre = oCliente.NombreCompleto
            oCliente = Nothing
            ''Obtenemos los datos necesariso del Cliente

            ''Asignamos el valor del Importe Total
            Dim decValeCaja As Decimal = ImporteValeCaja

            ''Generamos el vale de caja
            If decValeCaja > 0 Then
                oValeNuevo = oValeCajaMgr.Create
                If Me.CodTipoVenta.Trim = "P" AndAlso Me.ClientePGID > 0 Then
                    oValeNuevo.CodCliente = CStr(Me.ClientePGID).PadLeft(10, "0")
                Else
                    oValeNuevo.CodCliente = Me.ClienteID.PadLeft(10, "0")
                End If
                oValeNuevo.DocumentoID = Me.PedidoID
                oValeNuevo.DocumentoImporte = decValeCaja
                oValeNuevo.Fecha = Now
                oValeNuevo.FolioDocumento = DocFiEfectivo 'IIf(Devolucion = 1, DocFiEfectivo, Me.FolioSAP)
                If oValeNuevo.FolioDocumento Is Nothing OrElse oValeNuevo.FolioDocumento.Trim = "" Then oValeNuevo.FolioDocumento = Me.FolioSAP
                oValeNuevo.Importe = decValeCaja
                oValeNuevo.MontoUtilizado = 0.0
                '--------------------------------------------------------------------------------------------------------------------------------
                'RGERMAIN 01.04.2015: Si el nombre del cliente está en blanco dejamos uno fijo para que no detenga la creacion del vale de caja
                '--------------------------------------------------------------------------------------------------------------------------------
                If ClienteNombre.Trim = "" Then
                    oValeNuevo.Nombre = "Público en General"
                Else
                    oValeNuevo.Nombre = ClienteNombre
                End If
                'Lo generamos deshabilitado, asi si ocurre un error en SAP al actualizar el status del pedido, no pueda utilizarse
                oValeNuevo.StastusRegistro = False
                oValeNuevo.TipoDocumento = "CP"
                oValeNuevo.Usuario = oAppContext.Security.CurrentUser.SessionLoginName
                oValeNuevo.DevEfectivo = IIf(Devolucion = 1, True, False)

                Dim frmValeC As New FrmValeCaja
                frmValeC.DevolucionEfectivo = IIf(Devolucion = 1, True, False)
                frmValeC.ValeCajaNuevo(oValeNuevo, 0, decValeCaja, True)

                oValeNuevo.ValeCajaID = frmValeC.intValeCajaID 'Se saca el id del vale de caja generado
                ValeCajaID = oValeNuevo.ValeCajaID
                frmValeC.Dispose()
                frmValeC = Nothing
                oValeNuevo = Nothing
            End If
        Catch ex As Exception
            strMensaje = "Ocurrio un error al generar el Vale de Caja."
            EscribeLog(ex.ToString, "-Error al generar el Vale de Caja-")
            ValeCajaID = 0
        End Try
        Return ValeCajaID
    End Function

    '---------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 22/05/2013: Activa el vale de caja
    '---------------------------------------------------------------------------------------------------------------------------------

    Private Sub ActivarValeCaja(ByVal ValeCajaID As Integer)
        Try
            Dim oValeCaja As ValeCaja
            Dim oValeCajaMgr As New ValeCajaManager(oAppContext)
            oValeCaja = oValeCajaMgr.Load(ValeCajaID)
            oValeCaja.StastusRegistro = True
            oValeCaja.Save()
            oValeCaja = Nothing
            oValeCajaMgr = Nothing
        Catch ex As Exception
            EscribeLog(ex.ToString, "-Error al Activar el Vale de Caja con ID: " & ValeCajaID & "-")
            Throw ex
        End Try
    End Sub

    '-------------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 23/05/2013: Imprimendo el cupon de descuento
    '-------------------------------------------------------------------------------------------------------------------------------------

    Private Function PrintCupon(ByVal Cupon As CuponDescuento) As String
        Dim errMessage As String = ""
        If Cupon.Folio.Trim <> "" Then
            Try
                If oConfigCierreFI.MiniPrinter Then
                    Dim strCliente As String = ""
                    '----------------------------------------------------------------------------------------------------------------------------------------
                    'FLIZARRAGA: Cuando el cliente es diferente a publico en general y a empleado se toma el nombre del cliente en caso contrario queda vacio
                    '----------------------------------------------------------------------------------------------------------------------------------------
                    If Me.ClienteID <> "1" AndAlso Me.ClienteID <> "99999" Then
                        Dim ClienteManager As New ClientesManager(oAppContext, oAppSAPConfig)
                        Dim cliente As ClienteAlterno = ClienteManager.CreateAlterno()
                        cliente = ClienteManager.Load(Me.ClienteID, cliente)
                        strCliente = cliente.NombreCompleto
                    End If
                    Dim oRpt As New rptReCupon(Cupon.Folio, Cupon.Minimo, Cupon.Descuento, Cupon.FechaVigencia, strCliente, Cupon.TipoDescuento, "CD", Cupon.LimiteDescuento)
                    oRpt.Document.Name = "Cupon de Descuento"
                    oRpt.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
                    oRpt.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed
                    oRpt.Run()

                    Dim RepView As New ReportViewerForm
                    RepView.Report = oRpt
                    RepView.Show()
                End If
            Catch ex As Exception
                errMessage = "Ocurrio un error al imprimir el cupon de descuento."
                EscribeLog(ex.ToString, "-Error al actualizar status del pedido en SAP-")
            End Try
        End If
        Return errMessage
    End Function

    '-------------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 23/05/2013: Se carga la información del cupon, en un objeto CuponDescuento para su posterior impresión
    '-------------------------------------------------------------------------------------------------------------------------------------

    Private Function CreateInfoCupon(ByVal cupon As Hashtable) As CuponDescuento
        Dim oCupon As New CuponDescuento
        Dim FechaVig As String = ""
        'Llenamos el objeto oCupon
        With oCupon
            .Descripcion = cupon.Item("DESCRIPCION")
            .Descuento = cupon.Item("DESCUENTO")
            'Formateamos la Fecha
            FechaVig = cupon.Item("FIN")
            .FechaVigencia = CDate(FechaVig.Substring(6, 2) & "/" & FechaVig.Substring(4, 2) & "/" & FechaVig.Substring(0, 4))
            'Formateamos la Fecha
            .Folio = cupon.Item("FOLIO")
            .LimiteDescuento = cupon.Item("LIMITE_DESCTO")
            .Maximo = cupon.Item("MAXIMO")
            .Minimo = cupon.Item("MINIMO")
            .TipoDescuento = cupon.Item("TIPO_DESCTO")
        End With
        Return oCupon
    End Function

#End Region

#Region "Metodos de Movimiento"

    '---------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 25/04/2013: Guarda los datos del pedido con sus detalles
    '---------------------------------------------------------------------------------------------------------------------------------

    Public Function Save() As Boolean
        Dim valido As Boolean = False
        Dim conexion As New SqlConnection(oAppContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString())
        Dim command As New SqlCommand("SavePedido", conexion)
        Dim ts As SqlTransaction = Nothing
        Try
            conexion.Open()
            ts = conexion.BeginTransaction()
            command.Transaction = ts
            command.CommandType = CommandType.StoredProcedure
            Dim PedidoParameter As New SqlParameter("@PedidoID", SqlDbType.Int)
            PedidoParameter.Direction = ParameterDirection.InputOutput
            PedidoParameter.Value = Me.m_PedidoID
            command.Parameters.Add(PedidoParameter)
            command.Parameters.Add("@CodAlmacen", Me.CodAlmacen)
            command.Parameters.Add("@CodCaja", Me.CodCaja)
            command.Parameters.Add("@FolioPedido", Me.FolioPedido)
            command.Parameters.Add("@Status", Me.Status)
            command.Parameters.Add("@CodTipoVenta", Me.CodTipoVenta)
            command.Parameters.Add("@ClienteID", Me.ClienteID)
            command.Parameters.Add("@ClientePGID", Me.ClientePGID)
            command.Parameters.Add("@CodVendedor", Me.CodVendedor)
            command.Parameters.Add("@DescTotal", Me.DescTotal)
            command.Parameters.Add("@SubTotal", Me.SubTotal)
            command.Parameters.Add("@IVA", Me.IVA)
            command.Parameters.Add("@Total", Me.Total)
            command.Parameters.Add("@Impresa", Me.Impresa)
            command.Parameters.Add("@Usuario", Me.Usuario)
            command.Parameters.Add("@Fecha", Me.Fecha)
            command.Parameters.Add("@StatusRegistro", Me.StatusRegistro)
            command.Parameters.Add("@NumeroFacilito", Me.NumeroFacilito)
            command.Parameters.Add("@FolioSAP", Me.FolioSAP)
            command.Parameters.Add("@FolioFISAP", Me.FolioFISAP)
            command.Parameters.Add("@DPesos", Me.DPesos)
            command.Parameters.Add("@FCFolioSAP", Me.FCFolioSAP)
            command.Parameters.Add("@FCFolioFISAP", Me.FCFolioFISAP)
            command.Parameters.AddWithValue("@Referencia", Me.Referencia)
            command.ExecuteScalar()
            If Not PedidoParameter.Value Is Nothing Then
                Me.m_PedidoID = CInt(PedidoParameter.Value)
                For Each detalle As PedidoDetalles In Me.PedidosDetalles
                    If Me.m_IsNew = True Then
                        detalle.PedidoID = Me.PedidoID
                    End If
                    detalle.Save()
                Next
                Me.m_IsNew = False
                Me.m_IsDirty = False
            End If
            ts.Commit()
            command.Dispose()
            conexion.Close()
            valido = True
        Catch sql As SqlException
            If conexion.State <> ConnectionState.Closed Then
                ts.Rollback()
                RollBack(Me.PedidoID)
                conexion.Close()
            End If
            EscribeLog(sql.Message, "Hubo un error al guardar el objeto en la base de datos")
            Throw New ApplicationException("Hubo un error al guardar el objeto en la base de datos", sql)
        Catch ex As Exception
            If conexion.State <> ConnectionState.Closed Then
                ts.Rollback()
                RollBack(Me.PedidoID)
                conexion.Close()
            End If
            EscribeLog(ex.Message, "Hubo un error en la aplicación")
            Throw New ApplicationException("Hubo un error en la aplicación", ex)
        End Try
        Return valido
    End Function

    '---------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 29/04/2015: Actualiza los datos de la DPCard Puntos
    '---------------------------------------------------------------------------------------------------------------------------------

    Public Function UpdateDPCardPuntos(ByVal pedidoId As Integer, ByVal datos As Hashtable) As Boolean
        Dim valido As Boolean = False
        Dim conexion As New SqlConnection(oAppContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString())
        Dim command As New SqlCommand("UpdateDPCardPuntosByPedidoId", conexion)
        Dim ts As SqlTransaction = Nothing
        Try
            conexion.Open()
            ts = conexion.BeginTransaction()
            command.Transaction = ts
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@PedidoId", pedidoId)
            command.Parameters.Add("@NoDPCardPuntos", CStr(datos("NoTarjeta")))
            command.Parameters.Add("@CodDPCardPunto", CStr(datos("CodDPCardPunto")))
            command.ExecuteNonQuery()
            ts.Commit()
            command.Dispose()
            conexion.Close()
            valido = True
        Catch sql As SqlException
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
                ts.Rollback()
            End If
            Throw New ApplicationException(sql.Message, sql)
        Catch ex As Exception
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
                ts.Rollback()
            End If
            Throw New ApplicationException(ex.Message, ex)
        End Try
        Return valido
    End Function

    '---------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 25/04/2013: Elimina el pedido con todos sus detalles
    '---------------------------------------------------------------------------------------------------------------------------------

    Public Function Delete() As Boolean
        Dim valido As Boolean = False
        Dim conexion As New SqlConnection(oAppContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString())
        Dim command As New SqlCommand("DeletePedido", conexion)
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@PedidoID", Me.PedidoID)
            command.ExecuteScalar()
            command.Dispose()
            conexion.Close()
            ClearValues()
            valido = True
        Catch sql As SqlException
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            EscribeLog(sql.Message, "Hubo un error al eliminar el objeto en la base de datos")
            Throw New ApplicationException("Hubo un error al eliminar el objeto en la base de datos", sql)
        Catch ex As Exception
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            EscribeLog(ex.Message, "Hubo un error en la aplicación")
            Throw New ApplicationException("Hubo un error en la aplicación", ex)
        End Try
        Return valido
    End Function

    '---------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 25/04/2013: Funcion Estatica para eliminar el Pedido con todos sus detalles
    '---------------------------------------------------------------------------------------------------------------------------------

    Public Shared Function Delete(ByVal PedidoID As Integer) As Boolean
        Dim valido As Boolean = False
        Dim conexion As New SqlConnection(oAppContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString())
        Dim command As New SqlCommand("DeletePedido", conexion)
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@PedidoID", PedidoID)
            command.ExecuteScalar()
            command.Dispose()
            conexion.Close()
            valido = True
        Catch sql As SqlException
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            EscribeLog(sql.Message, "Hubo un error al eliminar el objeto en la base de datos")
            Throw New ApplicationException("Hubo un error al eliminar el objeto en la base de datos", sql)
        Catch ex As Exception
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            EscribeLog(ex.Message, "Hubo un error en la aplicación")
            Throw New ApplicationException("Hubo un error en la aplicación", ex)
        End Try
        Return valido
    End Function

    '---------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 25/04/2013: Guarda todos el Pedido con todos sus detalles en SAP
    '---------------------------------------------------------------------------------------------------------------------------------

    Public Function SaveSAP(ByRef oFactura As Factura, ByRef msg As DataTable, Optional ByVal oVentasFacturaSAP As VentasFacturaSAP = Nothing, _
                            Optional ByVal dtDetalleFactura As DataTable = Nothing) As Boolean
        Dim valido As Boolean = False
        If Me.PedidoID <> 0 Or Me.CodTipoVenta = "V" Then
            Me.Refresh()
            Dim ProcesoMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
            Dim exports As New Hashtable, resultado As Hashtable
            Dim ZSH_FACTURACION As New DataSet
            Dim ResultMessage As DataTable = Nothing
            Dim E_Pedido As String = "", E_Factura As String = "", E_FacturaFI As String = ""
            Dim FactMgr As New FacturaManager(oAppContext, oConfigCierreFI)
            '----------------------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 23/05/2013: Crea las tablas a llenar para su envio a la RFC de SAP para su posterior guardado
            '----------------------------------------------------------------------------------------------------------------------------
            Dim T_Producto As DataTable = CreateTableT_Productos()
            Dim T_Condiciones As DataTable = CreateTableT_CONDICIONES()
            Dim T_FormasPago As DataTable = CreateTableT_FPAGOS()
            Dim index As Integer = 0
            '----------------------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 23/05/2013 Se realiza un barrido de todos los detalles del pedido
            '----------------------------------------------------------------------------------------------------------------------------
            Dim fila As DataRow
            Dim cant_fact As Integer
            Dim cantidad As Integer
            Dim talla As String = ""
            For Each detalle As PedidoDetalles In Me.PedidosDetalles
                'fila = T_Producto.NewRow()
                cant_fact = Me.GetCant_Factura(detalle.CodArticulo, detalle.Numero, dtDetalleFactura)
                cantidad = Me.GetCantidad(detalle.CodArticulo, detalle.Numero)
                talla = ""
                Dim minimos() As DataRow
                If IsNumeric(detalle.Numero) Then
                    talla = Format(CDec(detalle.Numero), "#.0")
                End If
                '-------------------------------------------------------------------------------------------------------------------------
                'FLIZARRAGA 23/05/2013: Valida si tiene existencias minimas para el pedido
                '-------------------------------------------------------------------------------------------------------------------------
                If Not Me.ExistenciasMinimas Is Nothing Then
                    minimos = Me.ExistenciasMinimas.Select("CodArticulo='" & detalle.CodArticulo & "' AND Talla='" & talla & "'")
                    For Each row As DataRow In minimos
                        fila = T_Producto.NewRow()
                        fila("INDEX") = index
                        fila("CENTRO") = CStr(row!Sucursal)
                        fila("MATNR") = detalle.CodArticulo
                        fila("TALLA") = detalle.Numero
                        fila("CANTIDAD") = CInt(row!Cantidad)
                        fila("CANT_FACT") = 0
                        If detalle.Descuento <> 0 Then
                            Dim condicion As DataRow = T_Condiciones.NewRow()
                            condicion("INDEX") = index
                            condicion("CONDICION") = detalle.Condicion
                            condicion("IMPORTE") = CDec(detalle.Descuento).ToString("##,##0.00").Replace(",", "") 'detalle.Descuento
                            T_Condiciones.Rows.Add(condicion)
                        End If
                        T_Producto.Rows.Add(fila)
                        index += 1
                    Next
                    If minimos.Length > 0 Then
                        If cant_fact > 0 Then
                            fila = T_Producto.NewRow()
                            fila("INDEX") = index
                            fila("MATNR") = detalle.CodArticulo
                            fila("TALLA") = detalle.Numero
                            fila("CANTIDAD") = detalle.Cantidad - cantidad
                            fila("CANT_FACT") = cant_fact
                            T_Producto.Rows.Add(fila)
                            If detalle.Descuento <> 0 Then
                                Dim condicion As DataRow = T_Condiciones.NewRow()
                                condicion("INDEX") = index
                                condicion("CONDICION") = detalle.Condicion
                                condicion("IMPORTE") = CDec(detalle.Descuento).ToString("##,##0.00").Replace(",", "") 'detalle.Descuento
                                T_Condiciones.Rows.Add(condicion)
                            End If
                        End If
                    Else
                        fila = T_Producto.NewRow()
                        fila("INDEX") = index
                        fila("MATNR") = detalle.CodArticulo
                        fila("TALLA") = detalle.Numero
                        fila("CANTIDAD") = detalle.Cantidad
                        fila("CANT_FACT") = cant_fact
                        T_Producto.Rows.Add(fila)
                        If detalle.Descuento <> 0 Then
                            Dim condicion As DataRow = T_Condiciones.NewRow()
                            condicion("INDEX") = index
                            condicion("CONDICION") = detalle.Condicion
                            condicion("IMPORTE") = CDec(detalle.Descuento).ToString("##,##0.00").Replace(",", "") 'detalle.Descuento
                            T_Condiciones.Rows.Add(condicion)
                        End If
                    End If
                Else
                    fila = T_Producto.NewRow()
                    fila("INDEX") = index
                    fila("MATNR") = detalle.CodArticulo
                    fila("TALLA") = detalle.Numero
                    fila("CANTIDAD") = detalle.Cantidad
                    fila("CANT_FACT") = cant_fact
                    T_Producto.Rows.Add(fila)
                    If detalle.Descuento <> 0 Then
                        Dim condicion As DataRow = T_Condiciones.NewRow()
                        condicion("INDEX") = index
                        condicion("CONDICION") = detalle.Condicion
                        condicion("IMPORTE") = CDec(detalle.Descuento).ToString("##,##0.00").Replace(",", "") 'detalle.Descuento
                        T_Condiciones.Rows.Add(condicion)
                    End If
                End If
                index += 1
            Next
            '-----------------------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 23/05/2013: Carga todas las formas de pago que se realizaron en el pedido
            '-----------------------------------------------------------------------------------------------------------------------------
            Dim formapago As String = ""
            'Dim fila As DataRow
            For Each row As DataRow In Me.FormasPago.Rows
                fila = T_FormasPago.NewRow()
                formapago = CStr(row!CodFormasPago)
                '-----------------------------------------------------------------------------------------------------------------------------
                ' JNAVA (13.03.2015): Si la la forma de pago es DPCA, la cambiamos a TACR para SAP
                '-----------------------------------------------------------------------------------------------------------------------------
                fila("POSNR") = ""
                fila("FORMA_PAGO") = IIf(formapago = "DPCA", "TACR", formapago)
                fila("IMPORTE") = CDec(row!MontoPago).ToString("##,##0.00").Replace(",", "") 'CDec(row!MontoPago)
                fila("REFERENCIA") = ""
                fila("FOLIO") = ""
                fila("PER_FINANC") = ""
                fila("INTERESES") = 0
                fila("NUM_APROBACION") = ""
                fila("NTARJETA") = ""
                fila("SIHAY") = "X"
                fila("PEDIDOSH") = ""
                fila("STATUS") = ""
                '-----------------------------------------------------------------------------------------------------------------------------
                If formapago = "DPVL" Then

                    '-----------------------------------------------------------------------------------------------------------------------------
                    'JNAVA 27/05/2013: Carga los datos nuevos de las formas de pago (para cuando son DPVALE)
                    '-----------------------------------------------------------------------------------------------------------------------------
                    With oVentasFacturaSAP
                        fila("NUMVA") = .NumeroVale 'CInt(row!DPValeID)
                        fila("DISTRIB") = .ClienteDistribuidor 'DPValeSAP(2).PadLeft(10, "0")
                        fila("CTEDIST") = .CodigoCliente
                        'fila("KUNNR") = .CodigoCliente  'DPValeSAP(0).PadLeft(10, "0")

                        fila("NUMDE") = CStr(.NUMDE)
                        fila("PARES_PZAS") = CStr(.PARES_PZAS)
                        fila("RPARES_PZAS") = CStr(.RPARES_PZAS)
                        fila("MONTOUTILIZADO") = .MONTOUTILIZADO.ToString("##,##0.00").Replace(",", "")
                        fila("MONTODPVALE") = CDec(.MontoDPVale).ToString("##,##0.00").Replace(",", "")
                        fila("RMONTODPVALE") = CDec(.RMONTODPVALE).ToString("##,##0.00").Replace(",", "")
                        fila("REVALE") = IIf(.REVALE, "X", "")
                        fila("FECCO") = Format(.FechaCobroDPVL, "yyyyMMdd")
                        '-----------------------------------------------------------------------------------------------------------------
                        'FLIZARRAGA 06/02/2016: Por si algun día quieren hacer seguros de vida con DPVale Si Hay
                        '-----------------------------------------------------------------------------------------------------------------
                        'If oConfigCierreFI.GenerarSeguro Then
                        '    fila("ZSEG") = "1"
                        'Else
                        '    fila("ZSEG") = "0"
                        'End If
                        'fila("FOLSEG")=0
                        ''If Not DatosTicketSeguro Is Nothing AndAlso DatosTicketSeguro.Count > 0 Then .Add("FOLSEG", DatosTicketSeguro("folseg")) Else .Add("FOLSEG", 0)
                        'fila("IMPSEG") = 0
                        'fila("DIV") = ""
                    End With
                End If

                T_FormasPago.Rows.Add(fila)
            Next
            '------------------------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 23/05/2013: Agrega todas las tablas que se enviaran a SAP en un DataSet para enviarlo a la RFC que hara su creacion
            '------------------------------------------------------------------------------------------------------------------------------
            ZSH_FACTURACION.Tables.Add(T_Producto)
            ZSH_FACTURACION.Tables.Add(T_Condiciones)
            ZSH_FACTURACION.Tables.Add(T_FormasPago)
            exports("I_VKBUR") = "T" & oAppContext.ApplicationConfiguration.Almacen
            'exports("I_CLASEPEDIDO") = "Z" & Mid(oAppContext.ApplicationConfiguration.Almacen, 2, 2) & "1"
            exports("I_VKORG") = oConfigCierreFI.OrganizacionCompra
            exports("I_FACDPPRO") = oFactura.Referencia
            exports("I_RESPONSABLE") = oAppContext.Security.CurrentUser.Name
            exports("I_VALEEMP") = Me.ValeEmpleado
            exports("I_REP_VENTAS") = Me.CodVendedor.Trim
            exports("I_MOT_PEDIDO") = oFactura.MotivoPedido
            exports("I_SERIALID") = oFactura.SerialId
            exports("I_REFERENCIA") = Me.Referencia
            exports("I_CANAL") = "10"
            exports("I_KUNNR") = CStr(Me.ClienteID).PadLeft(10, "0")
            '--------------------------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 23/05/2013: Se manda a llamar la RFC en SAP para la creación del Pedido
            '--------------------------------------------------------------------------------------------------------------------------------
            resultado = ProcesoMgr.ZSH_FACTURACION(exports, ZSH_FACTURACION)
            ResultMessage = CType(resultado("T_RETURN"), DataTable)
            msg = ResultMessage
            If CBool(resultado("Success")) = True Then
                FactMgr.SaveSerial(Me.SerialId, "S", Me.CodVendedor, 0, 0, Me.PedidoID)
                valido = True
                E_Pedido = CStr(resultado("E_PEDIDO"))
                E_Factura = CStr(resultado("E_FACTURA"))
                E_FacturaFI = CStr(resultado("E_FACTURAFI"))
                If Not oFactura Is Nothing Then
                    oFactura.FolioSAP = E_Factura.Trim
                    oFactura.FolioFISAP = E_FacturaFI.Trim
                End If
                If Not Me.Facturas Is Nothing Then
                    Me.Facturas(0).FolioSAP = E_Factura
                    'oFactura.FolioSAP = E_Factura
                    'oFactura.FolioFISAP = E_FacturaFI
                    If oVentasFacturaSAP Is Nothing Then
                        Me.Refresh()
                    End If
                    'Me.Refresh()
                    Me.Facturas(0).FolioSAP = E_Factura
                    Me.Facturas(0).FolioFISAP = E_FacturaFI
                    'Dim FacturaMgr As New FacturaManager(oAppContext, oConfigCierreFI)
                    FactMgr.UpdateFolioSAP(Me.Facturas(0))
                End If
                Me.FolioSAP = E_Pedido
                If oVentasFacturaSAP Is Nothing Then
                    Me.Save()
                End If
                '--------------------------------------------------------------------------------------------------------------------------------------
                'FLIZARRAGA 05/07/2013: Subimos cada uno de los pagos a la cuenta de anticipos en SAP (Se crea el DZ)
                '--------------------------------------------------------------------------------------------------------------------------------------
                Dim oAbonosApartadosMgr As New AbonosApartadosManager(oAppContext)
                Dim montoPago As Decimal = 0
                Dim ClienteID As String = ""
                Dim codFormaPago As String = ""
                Dim codBanco As String = ""
                Dim strTipoPago As String = "", strTienda As String = "", strDivision As String = ""
                Dim NoAfiliacion As String = ""
                For Each row As DataRow In Me.FormasPago.Rows
                    codFormaPago = CStr(row("CodFormasPago"))
                    If codFormaPago.Trim.ToUpper <> "DPVL" Then
                        montoPago = CDec(row!MontoPago)
                        ClienteID = CStr(Me.ClienteID)
                        codBanco = CStr(row("CodBanco"))
                        NoAfiliacion = CStr(row("NoAfiliacion"))
                        If codFormaPago.Trim() <> "FACI" AndAlso codFormaPago.Trim.ToUpper <> "VCJA" Then
                            If codFormaPago.Trim() = "EFEC" Then
                                strTipoPago = "EFECTIVO"
                                strTienda = oAbonosApartadosMgr.SelectNombreTienda(strTipoPago, ProcesoMgr.Read_Centros)
                            ElseIf codBanco.Trim() = "T1" Then
                                '"BANCOMER" 
                                strTipoPago = "TARJETA 1"
                                strTienda = oAbonosApartadosMgr.SelectNombreTienda(strTipoPago, ProcesoMgr.Read_Centros)
                            ElseIf codBanco.Trim() = "T2" Then
                                '"SERFIN" Then
                                strTipoPago = "TARJETA 2"
                                strTienda = oAbonosApartadosMgr.SelectNombreTienda(strTipoPago, ProcesoMgr.Read_Centros)
                            ElseIf codBanco.Trim() = "T3" Then
                                '"BANAMEX" Then
                                strTipoPago = "TARJETA 3"
                                strTienda = oAbonosApartadosMgr.SelectNombreTienda(strTipoPago, ProcesoMgr.Read_Centros)
                                '-----------------------------------------------------------
                                'JNAVA (13.03.2015): Agregamos datos de cuenta de DP Card
                                '-----------------------------------------------------------
                            ElseIf codFormaPago.Trim() = "DPCA" Then
                                strTipoPago = "DPCARDCR"
                                strTienda = oAbonosApartadosMgr.SelectNombreTienda(strTipoPago, ProcesoMgr.Read_Centros)
                            End If
                            'strDivision = oAbonosApartadosMgr.SelectDivision(strTipoPago, ProcesoMgr.Read_Centros)
                            'If strDivision = "0000" Or strDivision = String.Empty Then
                            '    EscribeLog("La division no es correcta, corregir en TABLA ZPP_COBRANZAS en SAP, El campo GSBER es Incorrecto", "Error al subir un pago en " & codFormaPago & " del Pedido " & Me.FolioSAP)
                            '    MessageBox.Show("La division no es correcta, corregir en TABLA ZPP_COBRANZAS en SAP", "El campo GSBER es Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            'Else
                            Dim strError As String = ""
                            oFactura.FolioFISAP = ProcesoMgr.Write_Anticipoapartado("Pedido SH: " & Me.Referencia, montoPago, ClienteID, _
                                                                Me.FolioSAP, "SH", strTienda, strTipoPago, "", _
                                                                oAppContext.ApplicationConfiguration.Almacen, NoAfiliacion, codFormaPago, strError, oFactura.MotivoPedido)
                            If strError.Trim <> "" Then EscribeLog(strError, "Error al subir el pago del pedido " & Me.FolioSAP)
                            'End If
                            MessageBox.Show("El pedido se registro correctamente", "DPortenis Retail", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    End If
                Next
            Else
                FactMgr.SaveSerial(Me.SerialId, "E", Me.CodVendedor, 0, 0, Me.PedidoID)
                valido = False
            End If
        End If
        Return valido
    End Function

    Public Function SaveSAPRest(ByRef oFactura As Factura, ByRef msg As DataTable, Optional ByVal oVentasFacturaSAP As VentasFacturaSAP = Nothing, _
                            Optional ByVal dtDetalleFactura As DataTable = Nothing, Optional ByRef DatoSeguro As Dictionary(Of String, Object) = Nothing) As Boolean
        Dim valido As Boolean = False
        If Me.PedidoID <> 0 Or Me.CodTipoVenta = "V" Then
            Me.Refresh()
            Dim ProcesoMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
            Dim FactMgr As New FacturaManager(oAppContext, oConfigCierreFI)
            Dim exports As New Dictionary(Of String, Object), resultado As New Dictionary(Of String, Object)
            Dim ResultMessage As DataTable = Nothing
            Dim E_Pedido As String = "", E_Factura As String = "", E_FacturaFI As String = ""
            Dim lstProducto As New List(Of Dictionary(Of String, Object))
            Dim lstCondiciones As New List(Of Dictionary(Of String, Object))
            Dim lstFormasPago As New List(Of Dictionary(Of String, Object))
            Dim TipoVenta As New DportenisPro.DPTienda.ApplicationUnits.CatalogoTipoVenta.CatalogoTipoVentaManager(oAppContext)
            '----------------------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 23/05/2013: Crea las tablas a llenar para su envio a la RFC de SAP para su posterior guardado
            '----------------------------------------------------------------------------------------------------------------------------
            Dim index As Integer = 0
            '----------------------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 23/05/2013 Se realiza un barrido de todos los detalles del pedido
            '----------------------------------------------------------------------------------------------------------------------------
            For Each detalle As PedidoDetalles In Me.PedidosDetalles
                Dim cant_fact As Integer = Me.GetCant_Factura(detalle.CodArticulo, detalle.Numero, dtDetalleFactura)
                Dim cantidad As Integer = Me.GetCantidad(detalle.CodArticulo, detalle.Numero)
                Dim talla As String = ""
                Dim minimos() As DataRow
                If IsNumeric(detalle.Numero) Then
                    talla = Format(CDec(detalle.Numero), "#.0")
                End If
                '-------------------------------------------------------------------------------------------------------------------------
                'FLIZARRAGA 23/05/2013: Valida si tiene existencias minimas para el pedido
                '-------------------------------------------------------------------------------------------------------------------------
                If Not Me.ExistenciasMinimas Is Nothing Then
                    minimos = Me.ExistenciasMinimas.Select("CodArticulo='" & detalle.CodArticulo & "' AND Talla='" & talla & "'")
                    For Each row As DataRow In minimos
                        Dim fila As New Dictionary(Of String, Object)
                        fila("INDEX") = index
                        fila("CENTRO") = CStr(row!Sucursal)
                        fila("MATNR") = detalle.CodArticulo
                        fila("TALLA") = detalle.Numero
                        fila("CANTIDAD") = CDec(row!Cantidad).ToString("##,##0.00").Replace(",", "")
                        fila("CANT_FACT") = 0
                        If detalle.Descuento <> 0 Then
                            Dim condicion As New Dictionary(Of String, Object)
                            condicion("INDEX") = index
                            condicion("CONDICION") = detalle.Condicion
                            condicion("IMPORTE") = CDec(detalle.Descuento).ToString("##,##0.00").Replace(",", "")
                            lstCondiciones.Add(condicion)
                        End If
                        lstProducto.Add(fila)
                        index += 1
                    Next
                    If minimos.Length > 0 Then
                        If cant_fact > 0 Then
                            Dim fila As New Dictionary(Of String, Object)
                            fila("INDEX") = index
                            fila("MATNR") = detalle.CodArticulo
                            fila("TALLA") = detalle.Numero
                            fila("CANTIDAD") = CDec(detalle.Cantidad - cantidad).ToString("##,##0.00").Replace(",", "")
                            fila("CANT_FACT") = cant_fact
                            lstProducto.Add(fila)
                            If detalle.Descuento <> 0 Then
                                Dim condicion As New Dictionary(Of String, Object)
                                condicion("INDEX") = index
                                condicion("CONDICION") = detalle.Condicion
                                condicion("IMPORTE") = CDec(detalle.Descuento).ToString("##,##0.00").Replace(",", "")
                                lstCondiciones.Add(condicion)
                            End If
                        End If
                    Else
                        Dim fila As New Dictionary(Of String, Object)
                        fila("INDEX") = index
                        fila("MATNR") = detalle.CodArticulo
                        fila("TALLA") = detalle.Numero
                        fila("CANTIDAD") = detalle.Cantidad.ToString("##,##0.00").Replace(",", "")
                        fila("CANT_FACT") = cant_fact
                        lstProducto.Add(fila)
                        If detalle.Descuento <> 0 Then
                            Dim condicion As New Dictionary(Of String, Object)
                            condicion("INDEX") = index
                            condicion("CONDICION") = detalle.Condicion
                            condicion("IMPORTE") = CDec(detalle.Descuento).ToString("##,##0.00").Replace(",", "")
                            lstCondiciones.Add(condicion)
                        End If
                    End If
                Else
                    Dim fila As New Dictionary(Of String, Object)
                    fila("INDEX") = index
                    fila("MATNR") = detalle.CodArticulo
                    fila("TALLA") = detalle.Numero
                    fila("CANTIDAD") = detalle.Cantidad.ToString("##,##0.00").Replace(",", "")
                    fila("CANT_FACT") = cant_fact
                    lstProducto.Add(fila)
                    If detalle.Descuento <> 0 Then
                        Dim condicion As New Dictionary(Of String, Object)
                        condicion("INDEX") = index
                        condicion("CONDICION") = detalle.Condicion
                        condicion("IMPORTE") = CDec(detalle.Descuento).ToString("##,##0.00").Replace(",", "")
                        lstCondiciones.Add(condicion)
                    End If
                End If
                index += 1
            Next
            '-----------------------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 23/05/2013: Carga todas las formas de pago que se realizaron en el pedido
            '-----------------------------------------------------------------------------------------------------------------------------
            Dim formapago As String = ""
            For Each row As DataRow In Me.FormasPago.Rows
                Dim fila As New Dictionary(Of String, Object)
                'Dim fila As DataRow = T_FormasPago.NewRow()
                formapago = CStr(row!CodFormasPago)
                '-----------------------------------------------------------------------------------------------------------------------------
                ' JNAVA (13.03.2015): Si la la forma de pago es DPCA, la cambiamos a TACR para SAP
                '-----------------------------------------------------------------------------------------------------------------------------
                fila("POSNR") = ""
                fila("FORMA_PAGO") = IIf(formapago = "DPCA", "TACR", formapago)
                fila("IMPORTE") = CDec(row!MontoPago).ToString("##,##0.00").Replace(",", "")
                fila("REFERENCIA") = ""
                fila("FOLIO") = ""
                fila("PER_FINANC") = ""
                fila("INTERESES") = 0
                fila("NUM_APROBACION") = ""
                fila("NTARJETA") = ""
                fila("SIHAY") = "X"
                fila("PEDIDOSH") = ""
                fila("STATUS") = ""
                '-----------------------------------------------------------------------------------------------------------------------------
                ' JNAVA (14.03.2017):Agregamos la tienda en el detalle de las forams de pago
                '-----------------------------------------------------------------------------------------------------------------------------
                fila("I_VKBUR") = "T" & oAppContext.ApplicationConfiguration.Almacen
                '-----------------------------------------------------------------------------------------------------------------------------
                If formapago = "DPVL" Then

                    '-----------------------------------------------------------------------------------------------------------------------------
                    'JNAVA 27/05/2013: Carga los datos nuevos de las formas de pago (para cuando son DPVALE)
                    '-----------------------------------------------------------------------------------------------------------------------------
                    With oVentasFacturaSAP
                        fila("NUMVA") = .NumeroVale 'CInt(row!DPValeID)
                        fila("DISTRIB") = .ClienteDistribuidor 'DPValeSAP(2).PadLeft(10, "0")
                        fila("CTEDIST") = .CodigoCliente
                        'fila("KUNNR") = .CodigoCliente  'DPValeSAP(0).PadLeft(10, "0")

                        fila("NUMDE") = CStr(.NUMDE)
                        fila("PARES_PZAS") = CStr(.PARES_PZAS)
                        fila("RPARES_PZAS") = CStr(.RPARES_PZAS)
                        fila("MONTO_UTILIZADO") = .MONTOUTILIZADO.ToString("##,##0.00").Replace(",", "")
                        fila("MONTODPVALE") = CDec(.MontoDPVale).ToString("##,##0.00").Replace(",", "")
                        fila("RMONTODPVALE") = CDec(.RMONTODPVALE).ToString("##,##0.00").Replace(",", "")
                        fila("REVALE") = IIf(.REVALE, "X", "")
                        fila("FECCO") = Format(.FechaCobroDPVL, "yyyyMMdd")
                        fila("STATUS") = "P"
                        '-----------------------------------------------------------------------------------------------------------------
                        'FLIZARRAGA 06/02/2016: Por si algun día quieren hacer seguros de vida con DPVale Si Hay
                        '-----------------------------------------------------------------------------------------------------------------
                        'If oConfigCierreFI.GenerarSeguro Then
                        '    fila("ZSEG") = "1"
                        'Else
                        '    fila("ZSEG") = "0"
                        'End If
                        'fila("FOLSEG")=0
                        ''If Not DatosTicketSeguro Is Nothing AndAlso DatosTicketSeguro.Count > 0 Then .Add("FOLSEG", DatosTicketSeguro("folseg")) Else .Add("FOLSEG", 0)
                        'fila("IMPSEG") = 0
                        'fila("DIV") = ""
                    End With
                End If
                lstFormasPago.Add(fila)
                'T_FormasPago.Rows.Add(fila)
            Next
            '------------------------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 23/05/2013: Agrega todas las tablas que se enviaran a SAP en un DataSet para enviarlo a la RFC que hara su creacion
            '------------------------------------------------------------------------------------------------------------------------------
            exports("I_VKBUR") = "T" & oAppContext.ApplicationConfiguration.Almacen
            exports("I_VKORG") = oConfigCierreFI.OrganizacionCompra
            exports("I_FACDPPRO") = oFactura.Referencia
            exports("I_RESPONSABLE") = oAppContext.Security.CurrentUser.Name
            exports("I_VALEEMP") = Me.ValeEmpleado
            exports("I_REP_VENTAS") = Me.CodVendedor.Trim()
            exports("I_MOT_PEDIDO") = TipoVenta.GetMotivoPedidoByTipoVenta(oFactura.CodTipoVenta)
            exports("I_SERIALID") = oFactura.SerialId
            exports("I_REFERENCIA") = Me.Referencia
            exports("I_CANAL") = "10"
            '------------------------------------------------------------------------------------
            ' JNAVA (07.03.2016): Se agrego parametro de KUNNR para venta con dips
            '------------------------------------------------------------------------------------
            If Me.CodTipoVenta = "D" Then
                exports("I_KUNNR") = CStr(oFactura.ClienteId).PadLeft(10, "0")
            Else
                ' -------------------------------------------------------------------------------
                ' JNAVA (09.03.2016): Llenamos datos de las interlocutor 
                '--------------------------------------------------------------------------------
                Dim oInterlocutores As New List(Of Dictionary(Of String, Object))
                Dim oCodigo As New Dictionary(Of String, Object)
                With oCodigo
                    .Add("TIPO_INTERLOCUTOR", "WE")
                    If CodTipoVenta = "V" Then
                        Dim cteSap As ClientesSAP = GetClienteDPVale(oVentasFacturaSAP.CodigoCliente)
                        Dim apellido() As String = cteSap.Apellidos.Split(" ")
                        .Add("CLIENTE", oConfigCierreFI.PublicoGeneral.PadLeft(10, "0"))

                    Else
                        .Add("CLIENTE", CStr(oFactura.ClienteId).PadLeft(10, "0"))
                    End If
                End With
                oInterlocutores.Add(oCodigo)
                '--------------------------------------------------------------------------------
                ' JNAVA (09.03.2016): Agregamos la tabla de interlocutores al objeto principal
                '--------------------------------------------------------------------------------
                exports.Add("T_INTERLOCUTORES", oInterlocutores)
            End If

            exports("T_PRODUCTOS") = lstProducto
            exports("T_FPAGOS") = lstFormasPago
            exports("T_CONDICIONES") = lstCondiciones

            '--------------------------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 23/05/2013: Se manda a llamar la RFC en SAP para la creación del Pedido
            '--------------------------------------------------------------------------------------------------------------------------------
            Dim restService As New ProcesosRetail("/pos/sh", "POST")
            resultado = restService.SapZshFacturacion(exports, msg)

            '----------------------------------------------------------------------------------
            ' JNAVA (15.09.2016): Realizamos venta de dpvale en S2Credit
            '----------------------------------------------------------------------------------
            If oConfigCierreFI.AplicarS2Credit Then
                If oFactura.CodTipoVenta = "V" And CBool(resultado("Success")) = True Then
                    '----------------------------------------------------------------------------------
                    ' Por Default el Seguro es 1, cuando se quiera cambiar es desde aqui
                    '----------------------------------------------------------------------------------
                    Dim oS2Credit As New ProcesosS2Credit
                    Dim SeguroID As String = "1"
                    '----------------------------------------------------------------------------------
                    ' Limpiamos el ID de la Venta en S2credit
                    '----------------------------------------------------------------------------------
                    oFactura.VentaS2CreditID = String.Empty

                    '----------------------------------------------------------------------------------
                    '  Realizamos venta de dpvale en S2Credit
                    '----------------------------------------------------------------------------------
                    Dim mensaje As String = String.Empty
                    oFactura.VentaS2CreditID = oS2Credit.RealizarVentaSH(oVentasFacturaSAP, SeguroID, mensaje, DatoSeguro)
                    If mensaje <> String.Empty Then
                        MessageBox.Show("Ocurrio un guardar en s2credit." & vbCrLf & mensaje, "Pedidos Si Hay", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If
                    '----------------------------------------------------------------------------------
                    ' Si regresa ID de la venta es que se genero seguro
                    '----------------------------------------------------------------------------------
                    If oFactura.VentaS2CreditID <> String.Empty Then
                        oFactura.SeguroVidaSAPDPVL = True
                    Else
                        oFactura.SeguroVidaSAPDPVL = False
                    End If
                End If
            End If
            '----------------------------------------------------------------------------------


            If CBool(resultado("Success")) = True Then
                FactMgr.SaveSerial(Me.SerialId, "S", Me.CodVendedor, 0, 0, Me.PedidoID)
                valido = True
                Dim zsh As Dictionary(Of String, Object) = CType(resultado("ZshFacturacion"), Dictionary(Of String, Object))
                If zsh.ContainsKey("E_PEDIDO") Then
                    E_Pedido = CStr(zsh("E_PEDIDO"))
                Else
                    E_Pedido = ""
                End If
                If zsh.ContainsKey("E_FACTURA") Then
                    E_Factura = CStr(zsh("E_FACTURA"))
                Else
                    E_Factura = ""
                End If
                If zsh.ContainsKey("E_FACTURAFI") Then
                    E_FacturaFI = CStr(zsh("E_FACTURAFI"))
                Else
                    E_FacturaFI = ""
                End If
                If Not oFactura Is Nothing Then
                    oFactura.FolioSAP = E_Factura.Trim
                    oFactura.FolioFISAP = E_FacturaFI.Trim
                End If
                If Not Me.Facturas Is Nothing Then
                    Me.Facturas(0).FolioSAP = E_Factura
                    'oFactura.FolioSAP = E_Factura
                    'oFactura.FolioFISAP = E_FacturaFI
                    If oVentasFacturaSAP Is Nothing Then
                        Me.Refresh()
                    End If
                    'Me.Refresh()
                    Me.Facturas(0).FolioSAP = E_Factura
                    Me.Facturas(0).FolioFISAP = E_FacturaFI
                    Dim FacturaMgr As New FacturaManager(oAppContext, oConfigCierreFI)
                    FacturaMgr.UpdateFolioSAP(Me.Facturas(0))
                End If
                Me.FolioSAP = E_Pedido
                If oVentasFacturaSAP Is Nothing Then
                    Me.Save()
                End If
                Dim oAbonosApartadosMgr As New AbonosApartadosManager(oAppContext)
                Dim montoPago As Decimal = 0
                Dim ClienteID As String = ""
                Dim codFormaPago As String = ""
                Dim codBanco As String = ""
                Dim strTipoPago As String = "", strTienda As String = "", strDivision As String = ""
                Dim NoAfiliacion As String = ""
                For Each row As DataRow In Me.FormasPago.Rows
                    codFormaPago = CStr(row("CodFormasPago"))
                    If codFormaPago.Trim.ToUpper <> "DPVL" Then
                        montoPago = CDec(row!MontoPago)
                        ClienteID = CStr(Me.ClienteID)
                        codBanco = CStr(row("CodBanco"))
                        NoAfiliacion = CStr(row("NoAfiliacion"))
                        If codFormaPago.Trim() <> "FACI" AndAlso codFormaPago.Trim.ToUpper <> "VCJA" Then
                            If codFormaPago.Trim() = "EFEC" Then
                                strTipoPago = "EFECTIVO"
                                strTienda = oAbonosApartadosMgr.SelectNombreTienda(strTipoPago, ProcesoMgr.Read_Centros)
                            ElseIf codBanco.Trim() = "T1" Then
                                '"BANCOMER" 
                                strTipoPago = "TARJETA 1"
                                strTienda = oAbonosApartadosMgr.SelectNombreTienda(strTipoPago, ProcesoMgr.Read_Centros)
                            ElseIf codBanco.Trim() = "T2" Then
                                '"SERFIN" Then
                                strTipoPago = "TARJETA 2"
                                strTienda = oAbonosApartadosMgr.SelectNombreTienda(strTipoPago, ProcesoMgr.Read_Centros)
                            ElseIf codBanco.Trim() = "T3" Then
                                '"BANAMEX" Then
                                strTipoPago = "TARJETA 3"
                                strTienda = oAbonosApartadosMgr.SelectNombreTienda(strTipoPago, ProcesoMgr.Read_Centros)
                                '-----------------------------------------------------------
                                'JNAVA (13.03.2015): Agregamos datos de cuenta de DP Card
                                '-----------------------------------------------------------
                            ElseIf codFormaPago.Trim() = "DPCA" Then
                                codFormaPago = "TACR"
                                strTipoPago = "DPCARDCR"
                                strTienda = oAbonosApartadosMgr.SelectNombreTienda(strTipoPago, ProcesoMgr.Read_Centros)
                            End If
                            'strDivision = oAbonosApartadosMgr.SelectDivision(strTipoPago, ProcesoMgr.Read_Centros)
                            'If strDivision = "0000" Or strDivision = String.Empty Then
                            '    EscribeLog("La division no es correcta, corregir en TABLA ZPP_COBRANZAS en SAP, El campo GSBER es Incorrecto", "Error al subir un pago en " & codFormaPago & " del Pedido " & Me.FolioSAP)
                            '    MessageBox.Show("La division no es correcta, corregir en TABLA ZPP_COBRANZAS en SAP", "El campo GSBER es Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            'Else
                            Dim strError As String = ""
                            oFactura.FolioFISAP = ProcesoMgr.Write_Anticipoapartado("Pedido SH: " & Me.Referencia, montoPago, ClienteID, _
                                                                Me.FolioSAP, "SH", strTienda, strTipoPago, "", _
                                                                oAppContext.ApplicationConfiguration.Almacen, NoAfiliacion, codFormaPago, strError, TipoVenta.GetMotivoPedidoByTipoVenta(oFactura.CodTipoVenta))
                            If strError.Trim <> "" Then EscribeLog(strError, "Error al subir el pago del pedido " & Me.FolioSAP)
                            'End If
                            MessageBox.Show("El pedido se registro correctamente", "Dportenis Retail", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    End If
                Next
            Else
                FactMgr.SaveSerial(Me.SerialId, "E", Me.CodVendedor, 0, 0, Me.PedidoID)
                valido = False

                '---------------------------------------------------------------------------------------------------------------------------------
                'MLVARGAS 05/05/2022: Verificar si no es un pedido insurtible
                '---------------------------------------------------------------------------------------------------------------------------------
                If Not msg Is Nothing AndAlso msg.Rows.Count > 0 Then
                    For Each oRow As DataRow In msg.Rows
                        Dim message As String
                        message = oRow!MESSAGE

                        If message.ToUpper = "PEDIDO INSURTIBLE" Then
                            Me.Status = "INS"
                            Me.Save()
                        End If

                    Next
                End If

            End If
        End If
        Return valido
    End Function



    '---------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 25/04/2013: Obtiene el folio nuevo en el pedido
    '---------------------------------------------------------------------------------------------------------------------------------

    Public Function NewFolio()
        Dim conexion As New SqlConnection(oAppContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString())
        Dim command As New SqlCommand("GetNewFolioPedido", conexion)
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@CodCaja", Me.CodCaja)
            Me.FolioPedido = CInt(command.ExecuteScalar())
            command.Dispose()
            conexion.Close()
        Catch sql As SqlException
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            EscribeLog(sql.Message, "Hubo un error al obtener el folio en la base de datos")
            Throw New ApplicationException("Hubo un error al obtener el folio en la base de datos", sql)
        Catch ex As Exception
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            EscribeLog(ex.Message, "Hubo un error en la aplicación")
            Throw New ApplicationException("Hubo un error en la aplicación", ex)
        End Try
    End Function

    '---------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 25/04/2013: Elimina los detalles y el pedido en caso de surgir un error
    '---------------------------------------------------------------------------------------------------------------------------------

    Public Function RollBack(ByVal ID As Integer)
        Dim conexion As New SqlConnection(oAppContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString())
        Dim command As New SqlCommand("RollBackPedidosDetalles", conexion)
        Dim ts As SqlTransaction = Nothing
        Try
            conexion.Open()
            ts = conexion.BeginTransaction()
            command.Transaction = ts
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@PedidoID", ID)
            command.ExecuteScalar()
            ts.Commit()
            command.Dispose()
            conexion.Close()
        Catch sql As SqlException
            If conexion.State <> ConnectionState.Closed Then
                ts.Rollback()
                conexion.Close()
            End If
            EscribeLog(sql.Message, "Hubo un error al hacer el rollback el objeto en la base de datos")
            Throw New ApplicationException("Hubo un error al hacer el rollback en la base de datos", sql)
        Catch ex As Exception
            If conexion.State <> ConnectionState.Closed Then
                ts.Rollback()
                conexion.Close()
            End If
            EscribeLog(ex.Message, "Hubo un error en la aplicación")
            Throw New ApplicationException("Hubo un error en la aplicación", ex)
        End Try
    End Function

    '--------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 03/05/2013: Cargar todos los pedidos
    '--------------------------------------------------------------------------------------------------------------------------------

    Public Shared Function GetAll(ByVal EnableRecords As Boolean, ByVal CodCaja As String) As DataSet
        Dim conexion As New SqlConnection(oAppContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString())
        Dim command As New SqlCommand("SeletPedidosAll", conexion)
        Dim adapter As SqlDataAdapter = Nothing
        Dim ds As New DataSet
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@EnableRecords", EnableRecords)
            command.Parameters.Add("@CodCaja", CodCaja)
            command.Parameters.Add("@CodAlmacen", oAppContext.ApplicationConfiguration.Almacen)
            adapter = New SqlDataAdapter(command)
            adapter.Fill(ds)
            command.Dispose()
            conexion.Close()
        Catch sql As SqlException
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            EscribeLog(sql.Message, "Hubo un error al obtener datos en la base de datos")
            Throw New ApplicationException("Hubo un error al obtener datos en la base de datos", sql)
        Catch ex As Exception
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            EscribeLog(ex.Message, "Hubo un error en la aplicación")
            Throw New ApplicationException("Hubo un error en la aplicación", ex)
        End Try
        Return ds
    End Function

    '---------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 21/06/2013: Obtiene los Pedidos que esten pendientes por surtir, por recibir, por Facturar
    '---------------------------------------------------------------------------------------------------------------------------------

    Public Shared Function GetAllActivosSAP(ByVal estatus As String, Optional ByRef dtDetalle As DataTable = Nothing) As DataTable
        Dim ProcesoMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        Dim dtPedido As DataTable, dtCabecera As DataTable ', dtDetalle As DataTable
        Dim Status As New Hashtable
        Dim lstStatus() As String = estatus.Split(",")
        For Each str As String In lstStatus
            Status(str) = str
        Next
        dtPedido = ProcesoMgr.ZSH_PEDIDOS_PENDIENTES(ProcesoMgr.Read_Centros(), dtCabecera, dtDetalle, Status)
        dtCabecera.Columns.Add("REFERENCIA", GetType(String))
        Dim view As DataView = Nothing
        For Each row As DataRow In dtCabecera.Rows
            view = New DataView(dtPedido, "VBELN='" & CStr(row!VBELN) & "'", "", DataViewRowState.CurrentRows)
            row("Referencia") = view(0)!REFERENCIA

            Dim strDate As String = CStr(row("FECHA"))
            If CInt(strDate) > 0 Then
                Dim fecha As New DateTime(strDate.Substring(0, 4), strDate.Substring(4, 2), strDate.Substring(6, 2))
                row("Fecha") = fecha.ToString("dd/MM/yyyy")
            End If
            row.AcceptChanges()
        Next
        dtCabecera.AcceptChanges()
        Return dtCabecera
    End Function


    '---------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 03/05/2013: Obtiene las facturas por medio del Pedido ID es una funcion estatica
    '---------------------------------------------------------------------------------------------------------------------------------

    Public Shared Function GetFacturas(ByVal PedidoID As Integer)
        Dim FacturaMgr As New FacturaManager(oAppContext, oConfigCierreFI)
        Dim FacturaCorridaMgr As New FacturaCorridaManager(oAppContext)
        Dim Facturas() As Factura, facturaID As Integer = 0, folioFactura As Integer = 0
        Dim dsFacturas As DataTable = GetFacturasByPedido(PedidoID)
        If dsFacturas.Rows.Count > 0 Then
            ReDim Facturas(dsFacturas.Rows.Count - 1)
        End If
        Dim index As Integer = 0
        For Each row As DataRow In dsFacturas.Rows
            facturaID = CInt(row!FacturaId)
            folioFactura = CInt(row!FolioFactura)
            Facturas(index) = FacturaMgr.Create()
            FacturaMgr.LoadInto(facturaID, Facturas(index))
            Facturas(index).Detalle = FacturaCorridaMgr.LoadDetalle(folioFactura, PedidoID) 'oAppContext.ApplicationConfiguration.NoCaja
            index += 1
        Next
        Return Facturas
    End Function

    '---------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 03/05/2013: Funcion para refrescar el pedido con todos sus detalles
    '---------------------------------------------------------------------------------------------------------------------------------

    Public Function Refresh()
        If Me.PedidoID <> 0 Then
            Me.LoadData(Me.PedidoID, 0)
        End If
    End Function
    '-------------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 21/05/2013: Cancela el pedido y genera el vale de caja
    '-------------------------------------------------------------------------------------------------------------------------------------
    Public Function CancelarPedido(ByVal Devolucion As Integer) As Hashtable
        Dim retorno As New Hashtable
        If Me.PedidoID <> 0 Then
            Dim Manager As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
            Dim oContratosMgr As New ContratoManager(oAppContext)
            Dim oCancelaFacturaMgr As New CancelaFacturaManager(oAppContext, oAppSAPConfig, oConfigCierreFI)
            Dim division As String = oContratosMgr.DivisionSel()
            Dim exportar As New Hashtable
            Dim ImpValeCaja As Decimal, ImpEfectivo As Decimal, mensaje As String, efecObj As Object, ImpFacilito As Decimal, ImpDPVale As Decimal
            Dim revale As Boolean = False, DPValeID As String = ""
            Dim RestService As New ProcesosRetail("", "POST")
            Dim FechaPedido As DateTime = Me.Fecha.Date
            Dim FechaServidor As DateTime = Manager.MSS_GET_SY_DATE_TIME().Date
            CancelarFormasPagoTarjeta(FechaPedido, FechaServidor)


            '-----------------------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 23/05/2013: Se mandan cancelar todas las solicitudes que se hayan hechos o que esten pendientes por surtir
            '-----------------------------------------------------------------------------------------------------------------------------
            Dim result As Hashtable = Manager.ZSH_CANCELAR_SOLICITUDES(Me.FolioSAP, "")
            Dim resultado As Hashtable
            mensaje = CStr(result("E_ERROR"))
            Dim zsh_treturn As DataTable = CType(result("T_RETURN"), DataTable)
            If mensaje.Trim() <> "X" Then
                Dim sale_documento As String = CStr(result("E_SALESDOCUMENT"))
                CancelarFacturas(FechaPedido, FechaServidor, sale_documento)
                ImpValeCaja = CDec(result("E_IMP_VALECAJA"))
                ImpDPVale = CDec(result("E_IMP_DPVALE"))
                If FechaServidor > FechaPedido Then
                    ImpEfectivo = CDec(result("E_IMP_EFECTIVO"))
                    ImpFacilito = CDec(result("E_IMP_FACILITO"))
                    If ImpValeCaja = 0 AndAlso ImpEfectivo = 0 Then
                        If ImpDPVale = 0 Then
                            retorno("Success") = False
                            retorno("Mensaje") = "No se puede realizar el Reembolso ya que los importes calculados estan en cero."
                            Return retorno
                        End If
                    End If
                    exportar("I_TIPO") = "Canc SiHay"
                    exportar("I_PEDIDO") = Me.FolioSAP
                    exportar("I_KUNNR") = GetClientePedidoSH(Me)
                    exportar("I_GSBER") = division
                    exportar("I_TIENDA") = oAppContext.ApplicationConfiguration.Almacen
                    exportar("I_MODO") = "N"
                    Select Case Devolucion
                        Case 0
                            '---------------------------------------------------------------------------------------------------------------------
                            'FLIZARRAGA 21/05/2013: Se realiza vale de caja
                            '---------------------------------------------------------------------------------------------------------------------
                            Dim total As Decimal = ImpValeCaja + ImpEfectivo
                            exportar("I_IMPORTE_EFECTIVO") = 0
                            exportar("I_IMPORTE_VALECJA") = total
                        Case 1
                            '---------------------------------------------------------------------------------------------------------------------
                            'FLIZARRAGA 22/05/2013: Se realiza el reembolso en efectivo y vale de caja en caso de que haya pago con tarjetas
                            '---------------------------------------------------------------------------------------------------------------------

                            'If ImpEfectivo = 0 Then
                            '    retorno("Success") = False
                            '    retorno("Mensaje") = "No existe una forma de pago en efectivo. Para realizar el reembolso, debe seleccionar Vale de Caja."
                            '    Return retorno
                            'End If
                            If Me.CodTipoVenta = "O" Then
                                If oConfigCierreFI.DevolverEfectivoSH = True Then
                                    MessageBox.Show("La venta fue facilito solo se devolvera el efectivo de las formas de pago que hayan sido diferentes a la misma", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    exportar("I_IMPORTE_EFECTIVO") = ImpEfectivo + ImpValeCaja
                                    exportar("I_IMPORTE_VALECJA") = ImpFacilito
                                Else
                                    exportar("I_IMPORTE_EFECTIVO") = ImpEfectivo
                                    exportar("I_IMPORTE_VALECJA") = ImpFacilito + ImpValeCaja
                                End If
                                MessageBox.Show("La venta fue facilito solo se devolvera las formas de pago que hayan sido diferentes a la misma", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                exportar("I_IMPORTE_EFECTIVO") = ImpEfectivo
                                exportar("I_IMPORTE_VALECJA") = ImpValeCaja
                            Else
                                If oConfigCierreFI.DevolverEfectivoSH = True Then
                                    exportar("I_IMPORTE_EFECTIVO") = ImpEfectivo + ImpValeCaja
                                    exportar("I_IMPORTE_VALECJA") = 0
                                Else
                                    exportar("I_IMPORTE_EFECTIVO") = ImpEfectivo
                                    exportar("I_IMPORTE_VALECJA") = ImpValeCaja
                                End If
                            End If

                    End Select
                    Dim fechaHoy As DateTime = Manager.MSS_GET_SY_DATE_TIME()
                    If Me.Fecha.Date = fechaHoy.Date Then
                        exportar("I_IMPORTE_EFECTIVO") = ImpEfectivo + ImpValeCaja
                        exportar("I_IMPORTE_VALECJA") = 0
                    End If
                    '-----------------------------------------------------------------------------------------------------------------------------
                    'FLIZARRAGA 29/04/2015: Valida si tiene que retornar DPCard Puntos
                    '-----------------------------------------------------------------------------------------------------------------------------
                    Dim impDev As Decimal = 0
                    If CDec(exportar("I_IMPORTE_EFECTIVO")) > 0 Then
                        DPCardPuntos(True, CDec(exportar("I_IMPORTE_EFECTIVO")), impDev)
                        exportar("I_IMPORTE_VALECJA") = CDec(exportar("I_IMPORTE_VALECJA")) - impDev
                    End If
                    If CDec(exportar("I_IMPORTE_VALECJA")) > 0 Then
                        DPCardPuntos(False, CDec(exportar("I_IMPORTE_VALECJA")))
                    End If
                    '-----------------------------------------------------------------------------------------------------------------------------
                    'FLIZARRAGA 30/10/2014: Se pregunta si quiere generar revale
                    '-----------------------------------------------------------------------------------------------------------------------------
                    revale = PreguntarGeneraRevale(ImpDPVale, DPValeID)
                    'GoTo fin
                    '-----------------------------------------------------------------------------------------------------------------------------
                    'FLIZARRAGA 23/05/2013: Se manda a realizar el reembolsa en SAP
                    '-----------------------------------------------------------------------------------------------------------------------------
                    Dim res As New Dictionary(Of String, Object)
                    'RestService.Metodo = "/pos/sh"
                    'res = RestService.SapZshReembolso(Me.Referencia, exportar("I_KUNNR"), oAppContext.ApplicationConfiguration.Almacen, CDec(exportar("I_IMPORTE_VALECJA")), CStr(exportar("I_IMPORTE_EFECTIVO")), division, "Canc SiHay", Manager.Read_Centros(), "X", "", ImpDPVale, revale)
                    '--------------------------------------------------------------------------------------
                    ' JNAVA (21.03.2017): Ejecutamos Nueva RFC de Reembolso de SH en SAP
                    '--------------------------------------------------------------------------------------
                    res = Manager.Z_MF_FYCMX1005_REEMBOLSO_SH(Me.FolioSAP, oAppContext.ApplicationConfiguration.Almacen, CDec(exportar("I_IMPORTE_VALECJA")), CStr(exportar("I_IMPORTE_EFECTIVO")), String.Empty, ImpDPVale, revale)
                    '--------------------------------------------------------------------------------------
                    If Me.CodTipoVenta = "V" Then
                        '-----------------------------------------------------------------------------------------------------------------------------
                        ' JNAVA (07/09/2016): Si esta activo S2credit, hace la devolucion en S2Credit. Si no hace lo normal
                        '-----------------------------------------------------------------------------------------------------------------------------
                        If oConfigCierreFI.AplicarS2Credit Then

                            Dim oS2Credit As New ProcesosS2Credit

                            '---------------------------------------------------------------------------------------------
                            ' JNAVA (07.09.2016): Validamos vale en s2credit para obtener el distribuidor
                            '---------------------------------------------------------------------------------------------
                            Dim oDPVale As New cDPVale
                            oDPVale.INUMVA = Me.DPValeID.ToString.PadLeft(10, "0")
                            oDPVale = oS2Credit.ValidaDPVale(oDPVale, Nothing, String.Empty)

                            '---------------------------------------------------------------------------------------------
                            ' JNAVA (07.09.2016): Validamos vale en s2credit para obtener el distribuidor
                            '---------------------------------------------------------------------------------------------
                            Dim DistribuidorID As String
                            Dim oRow As DataRow
                            oRow = oDPVale.InfoDPVALE.Rows(0)
                            DistribuidorID = CStr(oRow("KUNNR"))
                            oRow = Nothing

                            '---------------------------------------------------------------------------------------------
                            ' JNAVA (07.09.2016): Generamos Devolucion en S2Credit
                            '---------------------------------------------------------------------------------------------
                            Dim MensajeDev As String = oS2Credit.GeneraDevolucion(Me.DPValeID, DistribuidorID.PadLeft(10, "0"), ImpDPVale)
                            If MensajeDev <> String.Empty Then
                                MessageBox.Show("Ocurrio un error al grabar la devolución del DPVale en S2Credit: " & vbCrLf & vbCrLf & MensajeDev & vbCrLf & vbCrLf & ". Favor de comunicarse a Soporte.", "Cancelacion de Pedidos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            End If

                        Else
                            Manager.ZSH_REEMBOLSOAFS(Me.Referencia, exportar("I_KUNNR"), oAppContext.ApplicationConfiguration.Almacen, CDec(exportar("I_IMPORTE_VALECJA")), CStr(exportar("I_IMPORTE_EFECTIVO")), division, "Canc SiHay", "X", "", ImpDPVale, revale)
                        End If
                    End If
                    'resultado = Manager.ZSH_REEMBOLSO(Me.FolioSAP, exportar("I_KUNNR"), oAppContext.ApplicationConfiguration.Almacen, CDec(exportar("I_IMPORTE_VALECJA")), CStr(exportar("I_IMPORTE_EFECTIVO")), division, "Canc SiHay", "X", "", ImpDPVale, revale)
                    'resultado = Manager.ZSH_REEMBOLSO(exportar)
                    'Dim sapReembolso As Dictionary(Of String, Object) = CType(res("SapZshReembolso"), Dictionary(Of String, Object))
                    Dim msg As String = CStr(res("MENSAJE"))
                    'Dim ErrorTable As DataTable = CType(resultado("T_RETURN"), DataTable)
                    If msg.Trim() = "" Then
                        'If ErrorTable.Rows.Count = 0 Then
                        Dim efectivo As String = "", valeCaja As String = ""
                        Dim cupon As Hashtable, FactEnTienda As String = "", FactXSiHay As String = "", strMensaje As String = ""
                        Dim ValeCajaID As Integer = 0, ValeCajaIDEfect As Integer = 0, FacturaMgr As New FacturaManager(oAppContext, oConfigCierreFI)
                        Dim fechaServer As DateTime = Manager.MSS_GET_SY_DATE_TIME
                        Me.StatusRegistro = False
                        Me.Status = "CAN"
                        If CancelaPedidoSH Then
                            Me.GetPedidoDetallesCorreccionDesc()
                        End If
                        Me.Save()
                        efectivo = CStr(res("SapZshReembolso")("E_BELNR_EFECTIVO"))
                        valeCaja = CStr(res("SapZshReembolso")("E_BELNR_VALECJA"))
                        FactEnTienda = ""
                        FactXSiHay = ""
                        'FactEnTienda = CStr(res("SapZshReembolso")("E_FACTENTIENDA"))
                        'FactXSiHay = CStr(res("SapZshReembolso")("E_FACTXSIHAY"))
                        'efectivo = CStr(resultado("E_BELNR_EFECTIVO"))
                        'valeCaja = CStr(resultado("E_BELNR_VALECJA"))
                        'cupon = CType(result("E_CUPON"), Hashtable)
                        'FactEnTienda = CStr(result("E_FACTENTIENDA"))
                        'FactXSiHay = CStr(result("E_FACTXSIHAY"))
                        retorno("Revale") = revale
                        retorno("MontoDPVale") = ImpDPVale
                        retorno("DPValeID") = DPValeID
                        '--------------------------------------------------------------------------------------------------------------------
                        'FLIZARRAGA 22/05/2013: Se valida si el pedido es del día de hoy o es posterior
                        '--------------------------------------------------------------------------------------------------------------------
                        Dim ValeManager As New ValeCajaManager(oAppContext)
                        If Me.Fecha.Date = fechaServer.Date Then
                            Select Case Devolucion
                                Case 0
                                    If ImpValeCaja > 0 Or ImpEfectivo Then
                                        Dim total As Decimal = ImpEfectivo + ImpValeCaja
                                        ValeCajaID = GenerarValeCaja(Devolucion, total, strMensaje, valeCaja)
                                        If strMensaje <> String.Empty Then
                                            Exit Select
                                        Else
                                            ValeManager.ActualizarDocumentoFIValeCaja(ValeCajaID, valeCaja)
                                        End If
                                    End If
                                Case 1
                                    Dim impEfec As Decimal = CDec(exportar("I_IMPORTE_EFECTIVO"))
                                    Dim impVcja As Decimal = CDec(exportar("I_IMPORTE_VALECJA"))
                                    If impVcja > 0 Then
                                        ValeCajaID = GenerarValeCaja(0, impVcja, strMensaje, valeCaja)
                                        If strMensaje <> String.Empty Then
                                            Exit Select
                                        Else
                                            ValeManager.ActualizarDocumentoFIValeCaja(ValeCajaID, valeCaja)
                                        End If
                                    End If
                                    If impEfec > 0 Then
                                        ValeCajaIDEfect = GenerarValeCaja(1, impEfec, strMensaje, efectivo)
                                        If strMensaje <> String.Empty Then
                                            Exit Select
                                        Else
                                            ValeManager.ActualizarDocumentoFIValeCaja(ValeCajaIDEfect, efectivo)
                                        End If
                                    End If
                            End Select
                            If strMensaje <> String.Empty Then
                                retorno("Success") = True
                                retorno("SuccessValeCaja") = False
                                retorno("Mensaje") = strMensaje
                                Return retorno
                            End If
                        Else
                            If ImpEfectivo > 0 Or ImpValeCaja > 0 Then
                                Dim total As Decimal = ImpEfectivo + ImpValeCaja
                                ValeCajaID = GenerarValeCaja(Devolucion, total, strMensaje, valeCaja)
                                If strMensaje <> String.Empty Then
                                    retorno("Success") = True
                                    retorno("SuccessValeCaja") = False
                                    retorno("Mensaje") = strMensaje
                                    Return retorno
                                Else
                                    ValeManager.ActualizarDocumentoFIValeCaja(ValeCajaID, valeCaja)
                                End If
                            End If
                        End If
                        '---------------------------------------------------------------------------------------------------------------------
                        'FLIZARRAGA 23/05/2013: Se valida si se genero el vale de caja para activarlo
                        '---------------------------------------------------------------------------------------------------------------------
                        If ValeCajaID <> 0 Then
                            ActivarValeCaja(ValeCajaID)
                        End If
                        If ValeCajaIDEfect <> 0 Then
                            ActivarValeCaja(ValeCajaIDEfect)
                        End If
                        '---------------------------------------------------------------------------------------------------------------------
                        'FLIZARRAGA 23/05/2013: Se valida si en el pedido hay facturas de la tienda o del SiHay para revivir el cupon en caso
                        '                       de que en el mismo se haya realizado con alguno.
                        '---------------------------------------------------------------------------------------------------------------------
                        If FactEnTienda.Trim() = String.Empty AndAlso FactXSiHay.Trim() = String.Empty AndAlso Me.CuponDevuelto <> String.Empty Then
                            Dim cuponimprimir As String
                            Dim dic As Dictionary(Of String, Object) = RestService.SapZCupCancelacion(Me.CuponDevuelto)
                            cuponimprimir = CStr(dic("SapZCupCancelacion")("E_ORIGINAL"))
                            If CStr(dic("SapZCupCancelacion")("E_RESULTADO")) = 0 Then
                                retorno("Success") = True
                                retorno("SuccessCuponVenta") = False
                                retorno("Mensaje") = "Hubo un error al revivir el cupon"
                                Return retorno
                                'Else

                                'End If
                                'If Manager.ZBAPI_REVIVE_CUPON(Me.CuponDevuelto, cuponimprimir) = 0 Then
                                '    retorno("Success") = True
                                '    retorno("SuccessCuponVenta") = False
                                '    retorno("Mensaje") = "Hubo un error al revivir el cupon"
                                '    Return retorno
                            Else
                                Dim err As String = ""
                                Dim cuponinfo As CuponDescuento = Manager.ZCUP_INFO_CUPON(cuponimprimir.Trim(), Me.CodTipoVenta, err)
                                If err.Trim = "" Then
                                    If fechaServer.Date <= cuponinfo.FechaVigencia.Date Then
                                        Dim errResult As String = PrintCupon(cuponinfo)
                                        If errResult <> "" Then
                                            retorno("Success") = True
                                            retorno("SuccessCuponVenta") = False
                                            retorno("Mensaje") = errResult
                                            Return retorno
                                        End If
                                    Else
                                        retorno("Success") = True
                                        retorno("SuccessCuponVenta") = False
                                        retorno("Mensaje") = "La fecha de vigencia del cupon ha caducado"
                                        Return retorno
                                    End If
                                Else
                                    retorno("Success") = True
                                    retorno("SuccessCuponVenta") = False
                                    retorno("Mensaje") = err
                                    Return retorno
                                End If
                            End If
                        End If
                        '--------------------------------------------------------------------------------------------------------------------
                        'FLIZARRAGA 23/05/2013: Se genera un cupon de cortesia, en caso de que haya hecho alguna venta por medio del SiHay
                        '--------------------------------------------------------------------------------------------------------------------
                        If Not cupon Is Nothing AndAlso CStr(cupon("FOLIO")).Trim() <> "" Then
                            Dim errResult As String = PrintCupon(CreateInfoCupon(cupon))
                            If errResult <> "" Then
                                retorno("Success") = True
                                retorno("SuccessCupon") = False
                                retorno("Mensaje") = errResult
                                Return retorno
                            End If
                        End If
                        retorno("Success") = True
                        retorno("SuccessValeCaja") = True
                        retorno("SuccessCuponVenta") = True
                        retorno("SuccessCupon") = True
                    Else
                        retorno("Success") = False
                        'retorno("Mensaje") = Me.GetMessageRFC(ErrorTable)
                        retorno("Mensaje") = msg
                    End If
                Else
                    If Me.CodTipoVenta = "V" Then
                        '-----------------------------------------------------------------------------------------------------------------------------
                        ' JNAVA (07/09/2016): Si esta activo S2credit, hace la devolucion en S2Credit. Si no hace lo normal
                        '-----------------------------------------------------------------------------------------------------------------------------
                        If oConfigCierreFI.AplicarS2Credit Then

                            Dim oS2Credit As New ProcesosS2Credit

                            '---------------------------------------------------------------------------------------------
                            ' JNAVA (07.09.2016): Validamos vale en s2credit para obtener el distribuidor
                            '---------------------------------------------------------------------------------------------
                            Dim oDPVale As New cDPVale
                            oDPVale.INUMVA = Me.DPValeID.ToString.PadLeft(10, "0")
                            oDPVale = oS2Credit.ValidaDPVale(oDPVale, Nothing, String.Empty)

                            '---------------------------------------------------------------------------------------------
                            ' JNAVA (07.09.2016): Validamos vale en s2credit para obtener el distribuidor
                            '---------------------------------------------------------------------------------------------
                            Dim DistribuidorID As String
                            Dim oRow As DataRow
                            oRow = oDPVale.InfoDPVALE.Rows(0)
                            DistribuidorID = CStr(oRow("KUNNR"))
                            oRow = Nothing

                            '---------------------------------------------------------------------------------------------
                            ' JNAVA (07.09.2016): Generamos Devolucion en S2Credit
                            '---------------------------------------------------------------------------------------------
                            Dim MensajeDev As String = oS2Credit.GeneraDevolucion(Me.DPValeID, DistribuidorID.PadLeft(10, "0"), ImpDPVale)
                            If MensajeDev <> String.Empty Then
                                MessageBox.Show("Ocurrio un error al grabar la devolución del DPVale en S2Credit: " & vbCrLf & vbCrLf & MensajeDev & vbCrLf & vbCrLf & ". Favor de comunicarse a Soporte.", "Cancelacion de Pedidos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            End If

                        Else
                            Manager.ZSH_REEMBOLSOAFS(Me.Referencia, exportar("I_KUNNR"), oAppContext.ApplicationConfiguration.Almacen, CDec(exportar("I_IMPORTE_VALECJA")), CStr(exportar("I_IMPORTE_EFECTIVO")), division, "Canc SiHay", "X", "", ImpDPVale, revale)
                        End If
                    ElseIf Me.CodTipoVenta = "E" Then
                        If Manager.ZBAPI_REVIVE_VALE_EMPLEADO(Me.FolioSAP).Trim = "1" Then
                            MessageBox.Show("No se pudo reactivar el vale de empleado utilizado en esta factura.", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Else
                            oCancelaFacturaMgr.ReviveValEmpleadoByPedidoId(Me.PedidoID)
                        End If
                    End If
                    Me.StatusRegistro = False
                    Me.Status = "CAN"
                    If CancelaPedidoSH Then
                        Me.GetPedidoDetallesCorreccionDesc()
                    End If
                    Me.Save()
                    retorno("Success") = True
                End If
            Else
fin:
                retorno("Success") = False
                retorno("Mensaje") = Me.GetMessageRFC(zsh_treturn)
            End If
        End If
        Return retorno
    End Function

    'Funcion de correccion de descuento

    Private Function GetPedidoDetallesCorreccionDesc()

        Dim index As Integer = 0
        For Each detalle As PedidoDetalles In PedidosDetalles
            detalle.Descuento = detalle.Descuento * 100
            Me.PedidosDetalles(index) = detalle
            index += 1
        Next

    End Function

    '-----------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 07/07/2017: Se cancelan todas las formas de pago del si hay solo cuando es del mismo día.
    '-----------------------------------------------------------------------------------------------------------

    Private Sub CancelarFormasPagoTarjeta(ByVal FechaPedido As DateTime, ByVal FechaServidor As DateTime)
        If FechaPedido = FechaServidor Then
            Dim valido As Boolean = False
            Dim dtFormasPago As DataTable = Me.FormasPago.Clone()
            Dim dsFormaPago As New DataSet()
            '------------------------------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 24/04/2015: Omite todas formas de Pago hechas con DPCard Puntos
            '------------------------------------------------------------------------------------------------------------------------------------
            For Each orow As DataRow In Me.FormasPago.Rows
                If CBool(orow("StatusRegistro")) = True AndAlso orow("CodTipoTarjeta") = "TE" AndAlso CStr(orow("CodFormasPago")) <> "DPPT" Then
                    dtFormasPago.ImportRow(orow)

                End If
            Next
            If dtFormasPago.Rows.Count > 0 Then
                dsFormaPago.Tables.Add(dtFormasPago)
                Dim oFrmCancelarPagoTarjeta As New frmCancelarPagoTarjeta

                oFrmCancelarPagoTarjeta.oPedido = Me
                oFrmCancelarPagoTarjeta.EsSiHay = True
                oFrmCancelarPagoTarjeta.dsFormasPago = dsFormaPago
                If oFrmCancelarPagoTarjeta.ShowDialog() <> DialogResult.OK Then
                    Exit Sub
                End If
            End If
        End If
    End Sub

    Private Sub CancelarFacturas(ByVal FechaPedido As DateTime, ByVal FechaServidor As DateTime, ByVal DocumentSales As String)
        If FechaPedido = FechaServidor Then
            Dim oCancelaFacturaMgr As CancelaFacturaManager
            oCancelaFacturaMgr = New CancelaFacturaManager(oAppContext, oAppSAPConfig, oConfigCierreFI)
            If Not Me.Facturas Is Nothing Then
                For Each Factura As Factura In Me.Facturas
                    oCancelaFacturaMgr.UpdateStatusFacturaDPValeRetail(Factura.FacturaID, Factura.CodVendedor, Factura.CodAlmacen, "", DocumentSales, Factura.FolioFISAP)
                Next
            End If
        End If
    End Sub

    Private Function PreguntarGeneraRevale(ByVal MontoDPVL As Decimal, ByRef DPValeID As String) As Boolean
        Dim revale As Boolean = False
        If Me.CodTipoVenta = "V" Then
            If MontoDPVL > 0 Then
                Try
                    '-----------------------------------------------------------------------------------------------------
                    'FLIZARRAGA 30/10/2014: Obtenemos el folio del vale de las Formas de pago del Pedido
                    '-----------------------------------------------------------------------------------------------------
                    For Each oRow As DataRow In Me.FormasPago.Rows
                        If oRow!CodFormasPago = "DPVL" Then
                            DPValeID = CStr(oRow!DPValeID)
                        End If

                    Next
                    If DPValeID = "" Then Return False
                    'Preguntamos si desea Generar el Rerevale
                    If MessageBox.Show("El Cliente cuenta con saldo de $" & MontoDPVL & " para Generar un Revale." & vbCrLf & "¿Desea generarlo?", "Imprimir ReVale", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                        revale = True
                    End If
                Catch ex As Exception
                    MessageBox.Show("Ocurrio un error al generar el Revale cliente.", "Cancelacion de Pedido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    EscribeLog(ex.ToString, "-Error al generar el Revale de Venta con DPVale-")
                End Try
            End If
        End If
        Return revale
    End Function

#End Region

#Region "DPCard Puntos"

    Private Sub DPCardPuntos(ByVal efectivo As Boolean, ByVal Importe As Decimal, Optional ByRef importeDev As Decimal = 0)
        If oConfigCierreFI.DPCardPuntos = True Then
            If Me.NoDPCardPuntos <> "" AndAlso Me.CodDPCardPunto = "CAN" Then
                Dim ws As New WSBroker("WS_BLUE", True)
                Dim oSAPMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
                Dim fecha As DateTime = oSAPMgr.MSS_GET_SY_DATE_TIME()
                Dim ArticuloMgr As New DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos.CatalogoArticuloManager(oAppContext)
                Dim articulo As DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos.Articulo
                Dim total As Decimal = 0, descSistema As Decimal = 0, descuento As Decimal = 0, unitPrice As Decimal = 0
                Dim cantidad As Decimal = 0, FacturaID As Integer
                Dim oVendedoresMgr As New DportenisPro.DPTienda.ApplicationUnits.CatalogoVendedores.CatalogoVendedoresManager(oAppContext)
                Dim oVendedor As DportenisPro.DPTienda.ApplicationUnits.CatalogoVendedores.Vendedor = oVendedoresMgr.Create()
                oVendedor.ClearFields()
                oVendedoresMgr.LoadInto(Me.CodVendedor, oVendedor)
                Dim resultado As Hashtable
                Dim params As Hashtable
                params("CardId") = Me.NoDPCardPuntos
                params("TransactionDate") = fecha.ToString("yyyy-MM-dd") & "T" & fecha.ToString("HH:mm:ss")
                params("Amount") = Importe
                params("TotalAmount") = Importe
                params("ticketid") = Me.FolioSAP
                '-----------------------------------------------------------------------------
                'JNAVA (08.12.2015): Correccion de Almacen (storeID)
                '-----------------------------------------------------------------------------
                params("StoreId") = oAppContext.ApplicationConfiguration.Almacen
                'params("StoreId") = "004"
                '-----------------------------------------------------------------------------
                Select Case Me.CodTipoVenta
                    Case "V"
                        params("ReferenceId3") = "CFDPV"
                    Case "D"
                        params("ReferenceId3") = "DPC"
                    Case Else
                        params("ReferenceId3") = "CF"
                End Select
                params("ReferenceId4") = ""
                params("CashierCode") = oAppContext.ApplicationConfiguration.NoCaja
                params("CashierName") = oAppContext.ApplicationConfiguration.NoCaja
                params("SupervisorCode") = Me.CodVendedor
                params("SupervisorName") = oVendedor.Nombre
                params("SellerCode") = Me.CodVendedor
                params("SellerName") = oVendedor.Nombre
                Dim product As String = ""
                For Each row As DataRow In Me.ArticulosNoFacturados.Rows
                    total = 0
                    unitPrice = 0
                    cantidad = 0
                    articulo = ArticuloMgr.Load(CStr(row("CodArticulo")))
                    cantidad = Math.Round(CDec(row("Cantidad")), 2)
                    unitPrice = Math.Round(CDec(row("PrecioUnit")), 2)
                    'unitPrice = total / cantidad
                    product &= articulo.Jerarquia & "|1|" & CStr(cantidad) & "|" & CStr(unitPrice) & "|PZA|"
                Next
                params("Products") = product.Remove(product.Length - 1, 1)
                If efectivo = True Then
                    resultado = ws.ReturnByMoneyRegister(params)
                Else
                    resultado = ws.ReturnRegister(params)
                End If
                If resultado.Count > 0 Then
                    If resultado.ContainsKey("ResultID") = True Then
                        If CInt(resultado("ResultID")) >= 0 Then
                            Dim totalCash As Decimal = CDec(resultado("TotalPointsInCash"))
                            If totalCash < 0 AndAlso efectivo = True Then
                                importeDev = totalCash
                            End If
                        Else
                            MessageBox.Show(CStr(resultado("Description")), "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End If
                End If
            End If
        End If
    End Sub

#End Region

End Class
