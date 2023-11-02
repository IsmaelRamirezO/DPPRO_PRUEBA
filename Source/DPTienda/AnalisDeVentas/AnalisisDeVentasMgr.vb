Option Explicit On 

Imports DportenisPro.DPTienda.Core

Public Class AnalisisDeVentasMgr

    Private oApplicationContext As ApplicationContext
    Private oAnalisisDeVentasDG As AnalisisDeVentasDataGateWay

#Region "Constructors / Destructors"

    Public Sub New(ByVal ApplicationContext As ApplicationContext)

        oApplicationContext = ApplicationContext

        oAnalisisDeVentasDG = New AnalisisDeVentasDataGateWay(Me)

    End Sub



    Public Sub Dispose()

        MyBase.Finalize()

        oAnalisisDeVentasDG = Nothing

    End Sub

#End Region

#Region "Properties"

    Public ReadOnly Property ApplicationContext() As ApplicationContext

        Get
            Return oApplicationContext
        End Get

    End Property


#End Region

#Region "Methods"

    Public Function GetVentasAsociadosDPVale(ByVal TipoVenta As String, ByVal FechaDe As Date, ByVal FechaHasta As Date) As DataSet

        Return oAnalisisDeVentasDG.GetVentasAsociadosDPVale(TipoVenta, FechaDe, FechaHasta)

    End Function

    Public Function GenerarAnalisisVentasFamiliaMarca(ByVal Familia As String, ByVal TipoVenta As String, ByVal datFROM As Date, ByVal datTO As Date, ByVal OrdenarPor As String) As DataTable

        Return oAnalisisDeVentasDG.ObtenerAnalisisVtasFamiliaMarca(Familia, TipoVenta, datFROM, datTO, OrdenarPor)

    End Function

    Public Function GenerarAnalisisVentasMarcaLineaFamilia(ByVal Marca As String, ByVal Linea As String, ByVal Familia As String, ByVal TipoVenta As String, ByVal datFROM As Date, ByVal datTO As Date, ByVal OrdenarPor As String) As DataTable

        Return oAnalisisDeVentasDG.ObtenerAnalisisVtasMarcaLineaFamilia(Marca, Linea, Familia, TipoVenta, datFROM, datTO, OrdenarPor)

    End Function

    Public Function GenerarAnalisisVentasLineaFamilia(ByVal Linea As String, ByVal Familia As String, ByVal TipoVenta As String, ByVal datFROM As Date, ByVal datTO As Date, ByVal OrdenarPor As String) As DataTable

        Return oAnalisisDeVentasDG.ObtenerAnalisisVtasLineaFamilia(Linea, Familia, TipoVenta, datFROM, datTO, OrdenarPor)

    End Function

    Public Function GenerarAnalisisVentasCodigo(ByVal TipoVenta As String, ByVal datFROM As Date, ByVal datTO As Date, ByVal OrdenarPor As String) As DataTable

        Return oAnalisisDeVentasDG.ObtenerAnalisisVtasCodigo(TipoVenta, datFROM, datTO, OrdenarPor)

    End Function

    Public Function GenerarAnalisisVentasPlayers(ByVal TipoVenta As String, ByVal datFROM As Date, ByVal datTO As Date, ByVal OrdenarPor As String) As DataTable

        Return oAnalisisDeVentasDG.ObtenerAnalisisVtasPlayers(TipoVenta, datFROM, datTO, OrdenarPor)

    End Function

    Public Function GenerarAnalisisVentasMarcas(ByVal TipoVenta As String, ByVal datFROM As Date, ByVal datTO As Date, ByVal OrdenarPor As String) As DataTable

        Return oAnalisisDeVentasDG.ObtenerAnalisisVtasMarcas(TipoVenta, datFROM, datTO, OrdenarPor)

    End Function

    Public Function GenerarAnalisisVentasLineas(ByVal TipoVenta As String, ByVal datFROM As Date, ByVal datTO As Date, ByVal OrdenarPor As String) As DataTable

        Return oAnalisisDeVentasDG.ObtenerAnalisisVtasLineas(TipoVenta, datFROM, datTO, OrdenarPor)

    End Function

    Public Function GenerarAnalisisVentasFamilias(ByVal TipoVenta As String, ByVal datFROM As Date, ByVal datTO As Date, ByVal OrdenarPor As String) As DataTable

        Return oAnalisisDeVentasDG.ObtenerAnalisisVtasFamilias(TipoVenta, datFROM, datTO, OrdenarPor)

    End Function

    Public Function GenerarAnalisisVentasSucursal(ByVal TipoVenta As String, ByVal datFROM As Date, ByVal datTO As Date, ByVal OrdenarPor As String) As DataTable

        Return oAnalisisDeVentasDG.ObtenerAnalisisVtasSucursal(TipoVenta, datFROM, datTO, OrdenarPor)

    End Function

    Public Function GenerarAnalisisVentasCategorias(ByVal TipoVenta As String, ByVal datFROM As Date, ByVal datTO As Date, ByVal OrdenarPor As String) As DataTable

        Return oAnalisisDeVentasDG.ObtenerAnalisisVtasCategorias(TipoVenta, datFROM, datTO, OrdenarPor)

    End Function

    Public Function GenerarAnalisisComparativo(ByVal TipoVenta As String, ByVal datFROM As Date, ByVal datTO As Date, ByVal OrdenarPor As String) As DataTable

        Return oAnalisisDeVentasDG.ObtenerAnalisisVtasComparativo(TipoVenta, datFROM, datTO, OrdenarPor)

    End Function

    Public Function GenerarAnalisisVentasporDia(ByVal TipoVenta As String, ByVal datFROM As Date, ByVal datTO As Date, ByVal OrdenarPor As String) As DataTable

        Return oAnalisisDeVentasDG.ObtenerAnalisisVtasporDia(TipoVenta, datFROM, datTO, OrdenarPor)

    End Function

    Public Function [VentasPromedioPorHora](ByVal FechaDel As DateTime, ByVal FechaAl As DateTime, ByVal CodCaja As String) As DataSet

        Return oAnalisisDeVentasDG.VentasPromedioPorHora(FechaDel, FechaAl, CodCaja)

    End Function

    Public Function [VentasTotalesPorHora](ByVal FechaDel As DateTime, ByVal FechaAl As DateTime, ByVal CodCaja As String) As DataSet

        Return oAnalisisDeVentasDG.VentasTotalesPorHora(FechaDel, FechaAl, CodCaja)

    End Function

    Public Function [VentasDetallePorHora](ByVal FechaDel As DateTime, ByVal FechaAl As DateTime, ByVal CodCaja As String) As DataSet

        Return oAnalisisDeVentasDG.VentasDetallePorHora(FechaDel, FechaAl, CodCaja)

    End Function
    Public Function GetFolioSAP(ByVal codCaja As String, ByVal FolioFactura As String) As DataSet

        Return oAnalisisDeVentasDG.SelectFolioSAP(codCaja, FolioFactura)

        oAnalisisDeVentasDG = Nothing

    End Function

#End Region
End Class
