Imports DportenisPro.DPTienda.Core


Public Class FirmaManager

    Private oFacturaDG As FirmaDataGateway
    Private m_strFirmaConfig As ConfigSaveArchivos.SaveConfigArchivos
    Private m_appAplication As ApplicationContext

#Region "Propiedades"
    Public Property FirmaConfig() As ConfigSaveArchivos.SaveConfigArchivos
        Get
            Return m_strFirmaConfig
        End Get
        Set(ByVal Value As ConfigSaveArchivos.SaveConfigArchivos)
            m_strFirmaConfig = Value
        End Set
    End Property

    Public Property oApplicationContext() As ApplicationContext
        Get
            Return m_appAplication
        End Get
        Set(ByVal Value As ApplicationContext)
            m_appAplication = Value
        End Set
    End Property


#End Region


#Region "Constructors / Destructors"

    Public Sub New(ByVal ApplicationContext As ApplicationContext, ByVal oFirma As ConfigSaveArchivos.SaveConfigArchivos)

        oApplicationContext = ApplicationContext
        FirmaConfig = oFirma
        oFacturaDG = New FirmaDataGateway(Me)

    End Sub

#End Region

    Public Function GetImagenFirmaAsociado(ByVal strAsociado As String) As Byte()

        Dim oFacturaDG As FirmaDataGateway
        oFacturaDG = New FirmaDataGateway(Me)

        Return oFacturaDG.SelectImagenFirmaAsociado(strAsociado)

        oFacturaDG = Nothing

    End Function

    Public Function ValidaDescuento(ByVal strDescuento As String, ByVal Centro As String) As Boolean

        Dim oFirmaDG As New FirmaDataGateway(Me)

        Return oFirmaDG.SelectDescuentosPermitidos(strDescuento, Centro)

        oFirmaDG = Nothing

    End Function



End Class
