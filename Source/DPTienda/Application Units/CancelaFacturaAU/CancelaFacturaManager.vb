Imports DportenisPro.DPTienda.Core
Imports DportenisPro.DPTienda.ApplicationUnits.ConfiguracionSAPAU
Imports DportenisPro.DPTienda.ApplicationUnits.ConfigSaveArchivos
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU
Imports System.Collections.Generic


Public Class CancelaFacturaManager

    Dim oApplicationContext As ApplicationContext
    Dim oSAPConfiguration As SAPApplicationConfig
    Dim oConfigSaveArchivos As SaveConfigArchivos

    Public ReadOnly Property ApplicationContext() As ApplicationContext
        Get
            Return oApplicationContext
        End Get
    End Property

#Region "Constructors / Destructors"

    Public Sub New(ByVal ApplicationContext As ApplicationContext, ByVal SAPConfiguration As SAPApplicationConfig, _
    ByVal ConfigSaveArchivo As SaveConfigArchivos)

        oApplicationContext = ApplicationContext
        oSAPConfiguration = SAPConfiguration
        oConfigSaveArchivos = ConfigSaveArchivo

    End Sub

#End Region

    Public Sub UpdateStatusFactura(ByVal FacturaID As Integer, ByVal FolioSAP As String, ByVal CodVendedor As String, ByVal CodAlmacen As String, Optional ByRef strFIDOCUMENT As String = "", Optional ByRef strSALESDOCUMENT As String = "")

        Dim oCancelaFacturaDG As CancelaFacturaDataGateway
        oCancelaFacturaDG = New CancelaFacturaDataGateway(Me)

        oCancelaFacturaDG.UpdateStatusFactura(FacturaID, FolioSAP, CodVendedor, CodAlmacen, strFIDOCUMENT, strSALESDOCUMENT)

        oCancelaFacturaDG = Nothing

    End Sub

    Public Sub ReviveValeEmpleado(ByVal FacturaID As Integer)

        Dim oCancelaFacturaDG As New CancelaFacturaDataGateway(Me)

        oCancelaFacturaDG.DeleteValeEmpleado(FacturaID)

        oCancelaFacturaDG = Nothing

    End Sub

    Public Sub ReviveValEmpleadoByPedidoId(ByVal PedidoId As Integer)
        Dim oCancelarFacturaDG As New CancelaFacturaDataGateway(Me)
        oCancelarFacturaDG.DeleteValeEmpleadoByPedidoId(PedidoId)
    End Sub
    Public Sub UpdateStatusFacturaCierreDia(ByVal FacturaID As Integer, ByVal FolioSAP As String, ByVal CodVendedor As String, ByVal CodAlmacen As String, Optional ByRef strFIDOCUMENT As String = "", Optional ByRef strSALESDOCUMENT As String = "")
        Dim oCancelaFacturaDG As CancelaFacturaDataGateway
        oCancelaFacturaDG = New CancelaFacturaDataGateway(Me)

        oCancelaFacturaDG.UpdateStatusFacturaCierreDia(FacturaID, FolioSAP, CodVendedor, CodAlmacen, strFIDOCUMENT, strSALESDOCUMENT)

        oCancelaFacturaDG = Nothing
    End Sub

    Public Sub UpdateStatusFacturaCierreDiaRetail(ByVal FacturaID As Integer, ByVal FolioSAP As String, ByVal CodVendedor As String, ByVal CodAlmacen As String, Optional ByRef strFIDOCUMENT As String = "", Optional ByRef strSALESDOCUMENT As String = "")
        Dim oCancelaFacturaDG As CancelaFacturaDataGateway
        oCancelaFacturaDG = New CancelaFacturaDataGateway(Me)

        oCancelaFacturaDG.UpdateStatusFacturaCierreDia(FacturaID, FolioSAP, CodVendedor, CodAlmacen, strFIDOCUMENT, strSALESDOCUMENT)

        oCancelaFacturaDG = Nothing
    End Sub

    Public Sub UpdateStatusFacturaDPVale(ByVal FacturaID As Integer, ByVal FolioSAP As String, ByVal CodVendedor As String, ByVal CodAlmacen As String, _
                                         Optional ByVal strFIDOCUMENT As String = "", Optional ByVal strSALESDOCUMENT As String = "", _
                                         Optional ByVal FolioFISAP As String = "")

        Dim oCancelaFacturaDG As CancelaFacturaDataGateway
        oCancelaFacturaDG = New CancelaFacturaDataGateway(Me)

        oCancelaFacturaDG.UpdateStatusFacturaDPVale(FacturaID, FolioSAP, CodVendedor, CodAlmacen, strFIDOCUMENT, strSALESDOCUMENT, FolioFISAP)

        oCancelaFacturaDG = Nothing

    End Sub

    Public Sub UpdateStatusFacturaDPValeRetail(ByVal FacturaID As Integer, ByVal CodVendedor As String, ByVal CodAlmacen As String, _
                                         Optional ByVal strFIDOCUMENT As String = "", Optional ByVal strSALESDOCUMENT As String = "", _
                                         Optional ByVal FolioFISAP As String = "")

        Dim oCancelaFacturaDG As CancelaFacturaDataGateway
        oCancelaFacturaDG = New CancelaFacturaDataGateway(Me)
        oCancelaFacturaDG.UpdateStatusFacturaDPValeRetail(FacturaID, CodVendedor, CodAlmacen, strFIDOCUMENT, strSALESDOCUMENT, FolioFISAP)

        oCancelaFacturaDG = Nothing

    End Sub

    Public Sub UpdateStatusFacturaRetail(ByVal FacturaID As Integer, ByVal FolioSAP As String, ByVal CodVendedor As String, ByVal CodAlmacen As String, Optional ByRef strFIDOCUMENT As String = "", Optional ByRef strSALESDOCUMENT As String = "")
        Dim oCancelaFacturaDG As CancelaFacturaDataGateway
        oCancelaFacturaDG = New CancelaFacturaDataGateway(Me)

        oCancelaFacturaDG.UpdateStatusFacturaRetail(FacturaID, FolioSAP, CodVendedor, CodAlmacen, strFIDOCUMENT, strSALESDOCUMENT)

        oCancelaFacturaDG = Nothing
    End Sub

    Public Function ValidaFacturaPRO(ByVal FolioSap As String, ByVal ClienteID As String, ByRef strFIDOCUMENT As String, ByRef strSALESDOCUMENT As String) As String

        Dim oCancelaFacturaDG As CancelaFacturaDataGateway
        oCancelaFacturaDG = New CancelaFacturaDataGateway(Me)

        Return oCancelaFacturaDG.ValidaFolioPRO(FolioSap, ClienteID, strFIDOCUMENT, strSALESDOCUMENT)

        oCancelaFacturaDG = Nothing

    End Function

    Public Function GetNombreClienteSAP(ByVal strCliente As String) As String


        Dim oCancelaFacturaDG As CancelaFacturaDataGateway
        oCancelaFacturaDG = New CancelaFacturaDataGateway(Me)

        Return oCancelaFacturaDG.GetNombreClienteSAP(strCliente)

        oCancelaFacturaDG = Nothing

    End Function

    Public Function GetDPvaleInfoSap(ByVal strDPVAleID As String) As cDPVale


        Dim oCancelaFacturaDG As CancelaFacturaDataGateway
        oCancelaFacturaDG = New CancelaFacturaDataGateway(Me)

        Return oCancelaFacturaDG.GetDPvaleInfoSap(strDPVAleID)

        oCancelaFacturaDG = Nothing

    End Function


    Public Sub UpdateStatusValeCaja(ByVal FacturaID As Integer)

        Dim oCancelaFacturaDG As CancelaFacturaDataGateway
        oCancelaFacturaDG = New CancelaFacturaDataGateway(Me)

        oCancelaFacturaDG.UpdateStatusValeCaja(FacturaID)

        oCancelaFacturaDG = Nothing

    End Sub

    Public Sub UpdateStatusValeCajaSH(ByVal PedidoID As Integer)

        Dim oCancelaFacturaDG As CancelaFacturaDataGateway
        oCancelaFacturaDG = New CancelaFacturaDataGateway(Me)

        oCancelaFacturaDG.UpdateStatusValeCajaSH(PedidoID)

        oCancelaFacturaDG = Nothing

    End Sub



    Public Function GetDateServer() As DateTime

        Dim oResult As DateTime

        Dim oCancelaFacturaDG As CancelaFacturaDataGateway
        oCancelaFacturaDG = New CancelaFacturaDataGateway(Me)

        oResult = oCancelaFacturaDG.SelectFechaServidor()

        oCancelaFacturaDG = Nothing

        Return oResult

    End Function

    Public Function IsDayClosed(ByVal dFechaFactura As DateTime) As Boolean

        Dim oResult As Boolean

        Dim oCancelaFacturaDG As CancelaFacturaDataGateway
        oCancelaFacturaDG = New CancelaFacturaDataGateway(Me)

        oResult = oCancelaFacturaDG.SelectDiaCierre(dFechaFactura)

        oCancelaFacturaDG = Nothing

        Return oResult

    End Function

    Public Function FacturasDelDia(ByVal strNoCaja As String, ByVal strAlmacen As String, ByVal FechaCierre As Date) As DataSet

        Dim oCancelaFacturaDG As CancelaFacturaDataGateway
        oCancelaFacturaDG = New CancelaFacturaDataGateway(Me)

        Return oCancelaFacturaDG.FacturasDelDia(strNoCaja, strAlmacen, FechaCierre)

    End Function

    Public ReadOnly Property SaveConfigArchivos() As SaveConfigArchivos
        Get
            Return oConfigSaveArchivos
        End Get
    End Property

    Public ReadOnly Property SAPApplicationConfig() As SAPApplicationConfig
        Get
            Return oSAPConfiguration
        End Get
    End Property

    'Public Sub SaveSAP(ByRef strFolioSAP As String, ByRef strFIDOCUMENT As String, ByRef strSALESDOCUMENT As String, ByVal CodVendedor As String, ByVal CodAlmacen As String)
    '    Dim oCancelaFacturaDG As CancelaFacturaDataGateway
    '    oCancelaFacturaDG = New CancelaFacturaDataGateway(Me)
    '    oCancelaFacturaDG.SaveSAP(strFolioSAP, strFIDOCUMENT, strSALESDOCUMENT, CodVendedor, CodAlmacen)
    'End Sub


    Public Function FacturaDPvaleIdSel(ByVal FacturaID As Integer) As String

        Dim oCancelaFacturaDG As CancelaFacturaDataGateway
        oCancelaFacturaDG = New CancelaFacturaDataGateway(Me)

        Return oCancelaFacturaDG.FacturaDPvaleIdSel(FacturaID)

        oCancelaFacturaDG = Nothing

    End Function


End Class
