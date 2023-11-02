Imports DportenisPro.DPTienda.Core
Imports DportenisPro.DPTienda.ApplicationUnits.ConfigSaveArchivos.SaveConfigArchivos

Public Class ServerUPCManager
    Dim oApplicationContext As ApplicationContext
    Private oServerUPCDG As ServerUPCDataGateWay
    Private m_strFirmaConfig As ConfigSaveArchivos.SaveConfigArchivos

#Region "Propiedades"
    Public Property FirmaConfig() As ConfigSaveArchivos.SaveConfigArchivos
        Get
            Return m_strFirmaConfig
        End Get
        Set(ByVal Value As ConfigSaveArchivos.SaveConfigArchivos)
            m_strFirmaConfig = Value
        End Set
    End Property

#End Region


#Region "Constructors / Destructors"

    Public Sub New(ByVal ApplicationContext As ApplicationContext, ByVal oServer As ConfigSaveArchivos.SaveConfigArchivos)

        oApplicationContext = ApplicationContext
        FirmaConfig = oServer
        oServerUPCDG = New ServerUPCDataGateWay(Me)

    End Sub

#End Region


#Region "Funciones"
    Public Function GetCatalogoUPC() As DataSet

        Dim oServerUPCDG As ServerUPCDataGateWay
        oServerUPCDG = New ServerUPCDataGateWay(Me)

        Return oServerUPCDG.SelectUPC

        oServerUPCDG = Nothing

    End Function

    Public Function CargasInicialesSelByTienda(ByVal strTienda As String) As DataSet

        Dim oServerUPCDG As ServerUPCDataGateWay
        oServerUPCDG = New ServerUPCDataGateWay(Me)

        Return oServerUPCDG.CargasInicialesSelByTienda(strTienda)

        oServerUPCDG = Nothing

    End Function

    Public Sub CargasInicialesUpdByCatalogo(ByVal strTienda As String, ByVal strCodigo As String, ByVal Status As String, ByVal TdaNueva As Boolean, ByVal Desc As String, ByVal Nocturna As Boolean, Optional ByVal Cierre As Boolean = False)

        Dim oServerUPCDG As ServerUPCDataGateWay
        oServerUPCDG = New ServerUPCDataGateWay(Me)

        oServerUPCDG.CargasInicialesUpdByCatalogo(strTienda, strCodigo, Status, TdaNueva, Desc, Nocturna, Cierre)

        oServerUPCDG = Nothing

    End Sub

    Public Sub SetCargasIniciales(ByVal strAlmacen As String)

        Dim oServerUPCDG As ServerUPCDataGateWay
        oServerUPCDG = New ServerUPCDataGateWay(Me)

        oServerUPCDG.SetCargasIniciales(strAlmacen)

        oServerUPCDG = Nothing

    End Sub

    Public Sub SetCargasInicialesDiaria(ByVal strAlmacen As String)

        Dim oServerUPCDG As ServerUPCDataGateWay
        oServerUPCDG = New ServerUPCDataGateWay(Me)

        oServerUPCDG.SetCargasInicialesDiarias(strAlmacen)

        oServerUPCDG = Nothing

    End Sub

#End Region

End Class
