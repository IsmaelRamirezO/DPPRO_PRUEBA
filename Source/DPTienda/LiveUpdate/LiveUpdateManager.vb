'Imports DPValeFinanciero.Core

Public Class LiveUpdateManager

    'Dim oApplicationContext As ApplicationContext
    Dim oLiveUpdateDG As LiveUpdateDataGateway
    Dim strConnectionString As String

    'Public ReadOnly Property ApplicationContext() As ApplicationContext
    '    Get
    '        Return oApplicationContext
    '    End Get
    'End Property

#Region "Constructors / Destructors"

    Public Sub New(ByVal ConnectionString As String) 'ByVal ApplicationContext As ApplicationContext)
        'oApplicationContext = ApplicationContext
        strConnectionString = ConnectionString
    End Sub

#End Region

#Region "Metodos"

    Public Function GetUltimaVersion(ByVal Sistema As String, ByVal Almacen As String) As Long

        oLiveUpdateDG = New LiveUpdateDataGateway(strConnectionString) 'Me)

        Return oLiveUpdateDG.SelectUltimaVersion(Sistema, Almacen)

    End Function

    Public Function GetVersionSucursal(ByVal CodAlmacen As String, ByVal CodCaja As String, ByVal Version As String) As Long

        oLiveUpdateDG = New LiveUpdateDataGateway(strConnectionString) 'Me)

        Return oLiveUpdateDG.SelectVersionSucursal(CodAlmacen, CodCaja, Version)

    End Function

    Public Sub ActualizaVersionSuc(ByVal CodAlmacen As String, ByVal CodCaja As String, ByVal Version As Long, ByVal Campo As String)

        oLiveUpdateDG = New LiveUpdateDataGateway(strConnectionString) 'Me)

        oLiveUpdateDG.VersionSucursalUpdate(CodAlmacen, CodCaja, Version, Campo)

        oLiveUpdateDG = Nothing

    End Sub

    Public Function EjecutaSPVersion(ByVal query As String) As Boolean

        Dim bRes As Boolean = False

        oLiveUpdateDG = New LiveUpdateDataGateway(strConnectionString) 'Me)

        bRes = oLiveUpdateDG.EjecutaSPVersion(query)

        oLiveUpdateDG = Nothing

        Return bRes

    End Function

#End Region

End Class
