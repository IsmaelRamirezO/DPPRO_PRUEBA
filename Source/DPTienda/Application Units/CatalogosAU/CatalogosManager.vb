Imports DportenisPro.DPTienda
Imports DportenisPro.DPTienda.Core

Public Class CatalogosManager
    Private oAppContext As ApplicationContext
    Private oCatalogoUPCDG As CatalogoUPCDataGateWay

    Public Sub New(ByVal AppContext As ApplicationContext)
        oAppContext = AppContext
        oCatalogoUPCDG = New CatalogoUPCDataGateWay(Me.oAppContext)
    End Sub

    Public Function GetDatosUPC(ByVal strCodUPC As String) As Material
        Return oCatalogoUPCDG.ConsultaUPC(strCodUPC)
    End Function
    Public Function GetCorridaArt(ByVal strCodArt As String) As String
        Return oCatalogoUPCDG.ConsultaCorrida(strCodArt)
    End Function

    Public Function GetMateriales(ByVal strCodigos As String, ByVal intCargarTodo As Boolean) As DataTable
        Return oCatalogoUPCDG.ConsultaMateriales(strCodigos, intCargarTodo)
    End Function

    Public Function GetExistencias(ByVal strCodigos As String, ByVal intCargarTodo As Boolean) As DataTable
        Return oCatalogoUPCDG.ConsultaExistencias(strCodigos, intCargarTodo)
    End Function

    Public Function GetLinea(ByVal CodLinea As String) As String
        Return oCatalogoUPCDG.ConsultaLinea(CodLinea)
    End Function

    Public Function GetFamilia(ByVal CodFamilia As String) As String
        Return oCatalogoUPCDG.ConsultaFamilia(CodFamilia)
    End Function
    Public Function GetMarca(ByVal CodMarca As String) As String
        Return oCatalogoUPCDG.ConsultaMarca(CodMarca)
    End Function
End Class
