
Option Explicit On

Imports DportenisPro.DPTienda.Core
Imports DportenisPro.DPTienda.ApplicationUnits.ConfiguracionSAPAU
Imports DportenisPro.DPTienda.ApplicationUnits.ConfigSaveArchivos
Imports System.Collections.Generic

Public Class CierreDiaManager

    Private oApplicationContext As ApplicationContext
    Private oCierreDiaDG As CierreDiaDataGateWay
    Dim oSAPConfiguration As SAPApplicationConfig
    Dim oConfigSaveArchivos As SaveConfigArchivos



#Region "Constructors / Destructors"

    'TODO earagon Quitar Optional a parametro SAPConfiguration.
    Public Sub New(ByVal ApplicationContext As ApplicationContext, Optional ByVal SAPConfiguration As SAPApplicationConfig = Nothing, Optional ByVal ConfigArchivosFI As SaveConfigArchivos = Nothing)

        oApplicationContext = ApplicationContext
        oSAPConfiguration = SAPConfiguration
        oConfigSaveArchivos = ConfigArchivosFI
        oCierreDiaDG = New CierreDiaDataGateWay(Me)


    End Sub



    Public Sub Dispose()

        MyBase.Finalize()

        oCierreDiaDG = Nothing

    End Sub

#End Region



#Region "Properties"

    Public ReadOnly Property ApplicationContext() As ApplicationContext

        Get
            Return oApplicationContext
        End Get

    End Property

    Public ReadOnly Property SAPApplicationConfig() As SAPApplicationConfig
        Get
            Return oSAPConfiguration
        End Get
    End Property

    Public ReadOnly Property ConfigSaveArchivos() As SaveConfigArchivos
        Get
            Return oConfigSaveArchivos
        End Get
    End Property

#End Region



#Region "Methods"


    Public Function Create() As CierreDia

        Dim oNuevoCierreDia As CierreDia
        oNuevoCierreDia = New CierreDia(Me)

        Return oNuevoCierreDia

    End Function



    Public Sub Save(ByVal pCierreDia As CierreDia)

        If (pCierreDia Is Nothing) Then
            Throw New ArgumentNullException("El parámetro CierreDia no puede ser nulo.")
        End If

        If (pCierreDia.IsNew) Then
            oCierreDiaDG.Insert(pCierreDia)
        Else
            'oCatalogoCajaDG.Update(pCaja)
        End If

    End Sub



    Public Function LoadFecha(ByVal Fecha As Date) As CierreDia

        'If (Fecha = Date) Then
        'Throw New ArgumentException("Debe especificar un Código de Banco")
        'End If

        'If (Fecha.Length > 4) Then
        'Throw New ArgumentException("El Código de Banco no debe exceder los 4 caracteres de longitud.")
        'End If

        Dim oReadedCierreDia As CierreDia

        oReadedCierreDia = oCierreDiaDG.SelectFecha(Fecha)

        Return oReadedCierreDia

    End Function



    Public Function ValidarCierreDiaImpresion(ByVal FechaCierreUser As Date) As Boolean

        Return oCierreDiaDG.ValidarCierreDiaImpresion(FechaCierreUser)

    End Function

    Public Function ValidarCierreDiaCobranza(ByVal Fecha As DateTime) As Boolean

        Return oCierreDiaDG.ValidaCobranza(Fecha)

    End Function

    Public Function ValidarCierreDia(ByVal FechaCierreUser As Date) As Boolean

        Return oCierreDiaDG.ValidarCierreDia(FechaCierreUser)

    End Function

    Public Function ValidarCajasCerradas(ByVal FechaCierreUser As Date) As Boolean

        Return oCierreDiaDG.ValidarCajasCerradas(FechaCierreUser)

    End Function

    Public Function ValidarInicioDia(ByVal FechaCierreUser As Date) As Integer

        oCierreDiaDG = New CierreDiaDataGateWay(Me)

        Return oCierreDiaDG.ExtraerInicioDiaID(FechaCierreUser)

    End Function

    Public Function GetReporteVentasGeneral(ByVal FechaCierre As Date) As DataSet

        Return oCierreDiaDG.GetReporteVentasGeneral(FechaCierre)

    End Function



    Public Function ValidarReporteNotasCredito(ByVal datFechaCierre As Date) As Boolean

        Return oCierreDiaDG.ValidarReporteNotasCredito(datFechaCierre)

    End Function



    Public Function ValidarReporteCancelacionApartados(ByVal datFechaCierre As Date) As Boolean

        Return oCierreDiaDG.ValidarReporteCancelacionApartados(datFechaCierre)

    End Function

    Public Function GetFacturasDPVale(ByVal datFechaCierre As Date) As DataTable

        Return oCierreDiaDG.ReadSQLFacturasDPVale(datFechaCierre)

    End Function

    Public Function GetFacturasSinDPVale(ByVal FechaCierre As DateTime) As DataTable
        Return oCierreDiaDG.GetFacturasSinVale(FechaCierre)
    End Function

    Public Function GetFacturas(ByVal FechaInicio As DateTime, ByVal FechaFin As DateTime) As DataTable
        Return oCierreDiaDG.GetFacturas(FechaInicio, FechaFin)
    End Function


    Public Sub CerrarAnio(ByVal intAnio As Integer)

        Dim oMessage As New frmMensaje(Me)
        oMessage.ShowMe(intAnio)

        oMessage.Dispose()
        oMessage = Nothing

    End Sub

    Public Sub BorrarPreciosArticulos()

        Dim oCierreDiaDG As New CierreDiaDataGateWay(Me)

        oCierreDiaDG.PreciosArticulosDelAll()

    End Sub

#End Region


#Region "Methods SQL"

    Public Sub RespaldoBDDportenisPRO(ByVal strRuta As String)
        oCierreDiaDG.RespaldoBDDportenisPRO(strRuta)
    End Sub

    Public Function ReadSQLAbonosApartadosCanceladosSinRegSAP() As DataTable
        Return oCierreDiaDG.ReadSQLAbonosApartadosCanceladosSinRegSAP()
    End Function

    Public Function ReadSQLAbonosApartadosSinRegSAP() As DataTable
        Return oCierreDiaDG.ReadSQLAbonosApartadosSinRegSAP
    End Function

    Public Function ReadSQLApartadosCanceladosSinRegSAP() As DataTable
        Return oCierreDiaDG.ReadSQLApartadosCanceladosSinRegSAP
    End Function

    Public Function ReadSQLApartadosSinRegSAP() As DataTable
        Return oCierreDiaDG.ReadSQLApartadosSinRegSAP
    End Function

    Public Function ReadSQLAbonosCDTSinRegSAP() As DataTable
        Return oCierreDiaDG.ReadSQLAbonosCDTSinRegSAP
    End Function

    Public Function ReadSQLApartadosDetalles(ByVal id As Integer) As DataTable
        Return oCierreDiaDG.ReadSQLApartadosDetalles(id)
    End Function

    Public Function ReadSQLNotasCreditoSinRegSAP() As DataTable
        Return oCierreDiaDG.ReadSQLNotasCreditoSinRegSAP()
    End Function

    Public Function ReadSQLApartadosDetallesLiquids(ByVal id As Integer) As DataTable
        Return oCierreDiaDG.ReadSQLApartadosDetallesLiquids(id)
    End Function

    Public Function SelectCOntratoFromApartadoID(ByVal id As Integer) As Integer
        Return oCierreDiaDG.SelectContratoFromApartadoID(id)
    End Function

    Public Function BancoSel(ByVal Tienda As String, ByVal ClaCobr As String) As DataSet
        Return oCierreDiaDG.BancoSel(Tienda, ClaCobr)
    End Function
#End Region

#Region "Methods SAP"

    Public Function EjecutarZBAPIFI05_VENTASDIA(ByVal FechaCierre As DateTime) As Boolean
        Return oCierreDiaDG.EjecutarZBAPIFI05_VENTASDIA(FechaCierre)
    End Function

    Public Function VentasTienda(ByVal FechaCierre As Date, Optional ByVal band As Boolean = True, Optional ByVal VPN As Boolean = True) As DataSet
        Return oCierreDiaDG.VentasTienda(FechaCierre, band, VPN)
    End Function
    'Funcion Cobranza UP
    Public Function VentasTiendaUp(ByVal FechaCierre As Date, ByRef strMensaje As String, Optional ByVal band As Boolean = True, Optional ByVal VPN As Boolean = True) As String
        Return oCierreDiaDG.VentasTiendaUp(FechaCierre, strMensaje, band, VPN)
    End Function
    'Funcion Vale Caja UP
    Public Function VentasTiendaUpVC(ByVal FechaCierre As Date, ByRef strMensaje As String, Optional ByVal band As Boolean = True, Optional ByVal VPN As Boolean = True) As String
        Return oCierreDiaDG.VentasTiendaUpVC(FechaCierre, strMensaje, band, VPN)
    End Function
    'Funcion Vale Caja DPVL UP
    Public Function VentasTiendaUpVCDPVL(ByVal FechaCierre As Date, ByRef strMensaje As String, Optional ByVal band As Boolean = True, Optional ByVal VPN As Boolean = True) As String
        Return oCierreDiaDG.VentasTiendaUpVCDPVL(FechaCierre, strMensaje, band, VPN)
    End Function
    'Funcion Abonos UP
    Public Function VentasTiendaUpAB(ByVal FechaCierre As Date, ByRef strMensaje As String, Optional ByVal band As Boolean = True, Optional ByVal VPN As Boolean = True) As String
        Return oCierreDiaDG.VentasTiendaUpAB(FechaCierre, strMensaje, band, VPN)
    End Function
    'Funcion Vale Caja CANCAPAR UP
    Public Function VentasTiendaUpVCCANCAPAR(ByVal FechaCierre As Date, ByRef strMensaje As String, Optional ByVal band As Boolean = True, Optional ByVal VPN As Boolean = True) As String
        Return oCierreDiaDG.VentasTiendaUpVCCANCAPAR(FechaCierre, strMensaje, band, VPN)
    End Function
    Public Function SelectMotivosFac(ByVal datFechaIni As Date, ByVal datFechaFin As Date, ByVal strTipoMovto As String) As DataSet
        Return oCierreDiaDG.SelectMotivosFac(datFechaIni, datFechaFin, strTipoMovto)
    End Function
    Public Function FacturaSelDontSaved() As DataSet
        Return oCierreDiaDG.FacturaSelDontSaved
    End Function

    Public Function FacturaCANSelDontSaved() As DataSet
        Return oCierreDiaDG.FacturaCANSelDontSaved
    End Function

    '1. - Este el Primero a Mandar a Llamar
    Public Function ApartadosNoGrabadosSAP()
        oCierreDiaDG.Write_ApartadosSAPNoReg()
    End Function

    '2. - Este el Segundo a Mandar a Llamar
    Public Function AbonosApartadosNoRegSAP()
        oCierreDiaDG.Write_AbonosApartadosSAPNoReg()
    End Function

    '3. - Este el Tercero a Mandar a Llamar
    Public Function ApartadosCancelNoRegSAP()
        oCierreDiaDG.Write_ApartadosCanceladosSAPNoReg()
    End Function

    '4. - Este el Cuarto a Mandar a Llamar
    Public Function AbonosApartadosCancelPNoRegSAP()
        oCierreDiaDG.Write_AbonosApartadosCanceladosSAPNoReg()
    End Function

    'Abonos a Credito Directo
    Public Function AbonosCDTNoRegSAP()
        oCierreDiaDG.Write_AnonosCDTSAPNoReg()
    End Function

    'Notas de Credito
    Public Function NotasCreditoSAPNoReg()
        oCierreDiaDG.Write_NotasCreditoSAPNoReg()
    End Function

    Public Function GetDpValeID(ByVal FolioFactura As Integer) As String
        Return oCierreDiaDG.GetDpValeIDDP(FolioFactura)
    End Function

#End Region

#Region "Web Service"

    Public Function GetDPValeInfo(ByVal dpValeID As Integer) As String()

        Return oCierreDiaDG.GetDPValeInfo(dpValeID)

    End Function

    Public Function GetNombreCliente(ByVal ClienteID As Integer) As String

        'Dim wsAsociado As New WSAsociadoNombre.AsociadoInfo

        'If Not ApplicationContext.ApplicationConfiguration.WSUrl = String.Empty Then
        '    wsAsociado.Url = ApplicationContext.ApplicationConfiguration.WSUrl.TrimEnd("/") _
        '            & "/" & wsAsociado.strURL.TrimStart("/")
        '    Return wsAsociado.GetAosiadoInfo(ClienteID)
        'Else
        '    Return String.Empty
        'End If

    End Function



#End Region

#Region " Proyecto SiHay "

    '-------------------------------------------------------------------------------------------------
    ' JNAVA (04/06/2013): Funcion para obtener las fechas de las citas segun el folio del pedido
    '-------------------------------------------------------------------------------------------------
    Public Function GetFechaCitaSH(ByVal Pedido As String) As Date

        oCierreDiaDG = New CierreDiaDataGateWay(Me)

        Return oCierreDiaDG.GetFechaCitaSiHayByFolioPedido(Pedido)

    End Function

    '-------------------------------------------------------------------------------------------------
    ' JNAVA (19/06/2013): Funcion para obtener los pedidos cancelados segun la fecha ingresada
    '-------------------------------------------------------------------------------------------------
    Public Function GetPedidosCanceladoSH(ByVal Fecha As DateTime) As DataTable

        oCierreDiaDG = New CierreDiaDataGateWay(Me)

        Return oCierreDiaDG.GetPedidosCanceladosSiHayByFecha(Fecha)

    End Function

    Public Function GetPedidosSHSinFolioSAP(ByVal Fecha As DateTime) As DataTable

        oCierreDiaDG = New CierreDiaDataGateWay(Me)

        Return oCierreDiaDG.GetPedidosSiHaySinFolioSAP(Fecha)

    End Function

    '-------------------------------------------------------------------------------------------------
    'JNAVA (21/06/2013): FUNCION PARA COMPENSAR PEDIDOS SI HAY EN SAP
    '-------------------------------------------------------------------------------------------------
    Public Function CompensarPedidosSiHay(ByVal FechaCierre As DateTime) As String
        Dim oSAPMgr As New ProcesoSAPAU.ProcesoSAPManager(Me.ApplicationContext, Me.oSAPConfiguration)
        Dim dtFacturas As DataTable = oSAPMgr.GetFacturasSiHay(FechaCierre)
        Dim strResult As String = ""
        Dim datos As New Dictionary(Of String, Object)
        '-------------------------------------------------------------------------------------------------------------------------
        'FLIZARRAGA 21/06/2016: Se Filtra por las facturas de publico en general
        '-------------------------------------------------------------------------------------------------------------------------
        Dim viewFilter As New DataView(dtFacturas)
        viewFilter.RowFilter = "CodTipoVenta='P'"
        If viewFilter.Count > 0 Then
            datos = New Dictionary(Of String, Object)
            datos("TIENDA") = "T" & Me.ApplicationContext.ApplicationConfiguration.Almacen
            datos("I_MOT_PED") = "ZPG"
            strResult &= oCierreDiaDG.CompensarPedidosSiHay(FechaCierre, viewFilter, datos)
        End If
        '---------------------------------------------------------------------------------------------------------------------------
        'FLIZARRAGA 21/06/2016: Se envian las facturas del si hay DIPS
        '---------------------------------------------------------------------------------------------------------------------------
        viewFilter = New DataView(dtFacturas)
        viewFilter.RowFilter = "CodTipoVenta='D'"
        If viewFilter.Count > 0 Then
            datos = New Dictionary(Of String, Object)
            datos("TIENDA") = "T" & Me.ApplicationContext.ApplicationConfiguration.Almacen
            datos("I_MOT_PED") = "ZDC"
            strResult &= oCierreDiaDG.CompensarPedidosSiHayIndividual(FechaCierre, viewFilter, datos)
        End If
        '---------------------------------------------------------------------------------------------------------------------------
        'FLIZARRAGA 21/06/2016: Se envian las facturas del si hay de Facturación Fiscal
        '---------------------------------------------------------------------------------------------------------------------------
        viewFilter = New DataView(dtFacturas)
        viewFilter.RowFilter = "CodTipoVenta='I'"
        If viewFilter.Count > 0 Then
            datos = New Dictionary(Of String, Object)
            datos("TIENDA") = "T" & Me.ApplicationContext.ApplicationConfiguration.Almacen
            datos("I_MOT_PED") = "ZFF"
            strResult &= oCierreDiaDG.CompensarPedidosSiHayIndividual(FechaCierre, viewFilter, datos)
        End If
        '---------------------------------------------------------------------------------------------------------------------------
        'FLIZARRAGA 21/06/2016: Se envian las facturas del si hay de Ventas de Empleados
        '---------------------------------------------------------------------------------------------------------------------------
        viewFilter = New DataView(dtFacturas)
        viewFilter.RowFilter = "CodTipoVenta='E'"
        If viewFilter.Count > 0 Then
            datos = New Dictionary(Of String, Object)
            datos("TIENDA") = "T" & Me.ApplicationContext.ApplicationConfiguration.Almacen
            datos("I_MOT_PED") = "ZVE"
            strResult &= oCierreDiaDG.CompensarPedidosSiHay(FechaCierre, viewFilter, datos)
        End If
        '---------------------------------------------------------------------------------------------------------------------------
        'FLIZARRAGA 21/06/2016: Se envian las facturas del si hay de Ventas de DPVale
        '---------------------------------------------------------------------------------------------------------------------------
        viewFilter = New DataView(dtFacturas)
        viewFilter.RowFilter = "CodTipoVenta='V'"
        If viewFilter.Count > 0 Then
            datos = New Dictionary(Of String, Object)
            datos("TIENDA") = "T" & Me.ApplicationContext.ApplicationConfiguration.Almacen
            datos("I_MOT_PED") = "ZDV"
            strResult &= oCierreDiaDG.CompensarPedidosSiHay(FechaCierre, viewFilter, datos)
        End If
        Return strResult
    End Function

#End Region

End Class
