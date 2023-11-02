Imports DportenisPro.DPTienda.ApplicationUnits.ConfigSaveArchivos

Public Class LiveUpdateManager

    'Dim oApplicationContext As ApplicationContext
    Dim oConfigCierre As SaveConfigArchivos
    Dim oLiveDG As LiveUpdateDataGateway

#Region "Properties"

    'Public ReadOnly Property ApplicationContext() As ApplicationContext

    '    Get
    '        Return oApplicationContext
    '    End Get

    'End Property

    Public ReadOnly Property ConfigCierreFI() As SaveConfigArchivos
        Get
            Return oConfigCierre
        End Get
    End Property

#End Region

#Region "Constructor / Destructor"

    Public Sub New(ByVal ConfigCierreFI As SaveConfigArchivos) ', ByVal oConfig As ConfigSaveArchivos.SaveConfigArchivos)

        'oApplicationContext = ApplicationContext
        oConfigCierre = oConfigCierreFI
        oLiveDG = New LiveUpdateDataGateway(Me)

    End Sub

    Public Sub Dispose()

        MyBase.Finalize()

        oLiveDG = Nothing

    End Sub

#End Region

#Region "Methods"

    Public Sub ActualizaVersionSuc(ByVal CodAlmacen As String, ByVal CodCaja As String, ByVal Version As Long, ByVal Campo As String)

        oLiveDG = New LiveUpdateDataGateway(Me)

        oLiveDG.VersionSucursalUpdate(CodAlmacen, CodCaja, Version, Campo)

    End Sub

    Public Function GetUltimaVersion(ByVal Sistema As String, ByRef Critica As Boolean, ByVal Almacen As String) As Long

        oLiveDG = New LiveUpdateDataGateway(Me)

        Return oLiveDG.SelectUltimaVersion(Sistema, Critica, Almacen)

    End Function

    Public Function GetVersionSucursal(ByVal CodAlmacen As String, ByVal CodCaja As String, ByVal Version As String) As Long

        oLiveDG = New LiveUpdateDataGateway(Me)

        Return oLiveDG.SelectVersionSucursal(CodAlmacen, CodCaja, Version)

    End Function

    Public Sub ActualizaVersionWindowsSQL(ByVal CodAlmacen As String, ByVal CodCaja As String, ByVal Windows As String, ByVal SQL As String, ByVal Ciudad As String)

        oLiveDG = New LiveUpdateDataGateway(Me)

        oLiveDG.VersionSucursalUpdateWindowsSQL(CodAlmacen, CodCaja, Windows, SQL, Ciudad)

    End Sub

#End Region

End Class
