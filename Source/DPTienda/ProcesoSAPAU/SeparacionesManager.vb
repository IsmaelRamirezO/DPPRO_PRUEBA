Imports DportenisPro.DPTienda.Core

Public Class SeparacionesManager


    Dim oApplicationContext As ApplicationContext
    Private oSeparacionesDG As SeparacionesDataGateWay
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

    Public Sub New(ByVal ApplicationContext As ApplicationContext, ByVal oSeparaciones As ConfigSaveArchivos.SaveConfigArchivos)

        oApplicationContext = ApplicationContext
        FirmaConfig = oSeparaciones
        oSeparacionesDG = New SeparacionesDataGateWay(Me)

    End Sub

#End Region

    Public Function SelectUPCNuevo(ByVal datFechaIni As Date, ByVal datFechaFin As Date, ByVal Todo As Boolean, Optional ByVal CodArticulo As String = "") As DataSet

        Dim oSeparacionesDG As SeparacionesDataGateWay
        oSeparacionesDG = New SeparacionesDataGateWay(Me)

        Return oSeparacionesDG.SelectUPCNuevo(datFechaIni, datFechaFin, Todo, CodArticulo)

        oSeparacionesDG = Nothing

    End Function



End Class


