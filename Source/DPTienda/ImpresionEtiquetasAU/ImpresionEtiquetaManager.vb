
Imports DportenisPro.DPTienda.Core


Public Class ImpresionEtiquetaManager


    Private oApplicationContext As ApplicationContext

    Private oImpresionEtiquetaDG As ImpresionEtiquetaDataGateway



#Region "Constructors / Destructors"

    Public Sub New(ByVal ApplicationContext As ApplicationContext)

        oApplicationContext = ApplicationContext

        oImpresionEtiquetaDG = New ImpresionEtiquetaDataGateway(Me)

    End Sub



    Public Sub Dispose()

        MyBase.Finalize()

        oImpresionEtiquetaDG = Nothing

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

    Public Function GetAll(ByVal bolopc As Boolean, Optional ByVal strCodArticulo As String = "", Optional ByVal strCodMarca As String = "", _
                           Optional ByVal strCodFamilia As String = "", Optional ByVal strCodLinea As String = "", _
                           Optional ByVal strCodTipoPrecio As String = "", Optional ByVal strCodCategoria As String = "", _
                           Optional ByVal strTalla As String = "", Optional ByVal Tipo As Integer = 1) _
                           As DataSet

        Return oImpresionEtiquetaDG.Select(bolopc, strCodArticulo, strCodMarca, strCodFamilia, strCodLinea, strCodTipoPrecio, strCodCategoria, strTalla, Tipo)

    End Function

    Public Function GetCorrida(ByVal CodArticulo As String, ByVal CodAlmacen As String) As DataTable
        Return oImpresionEtiquetaDG.GetCorrida(CodArticulo, CodAlmacen)
    End Function

    Public Function GetExistenciaArticulo(ByVal CodArticulo As String, ByVal talla As String) As Integer
        Return oImpresionEtiquetaDG.GetExistenciaArticulo(CodArticulo, talla)
    End Function

    '--------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 03/06/2014: Función para obtener las tallas con existencias de un articulo
    '--------------------------------------------------------------------------------------------------------------------

    Public Function GetCorridaExistencia(ByVal CodArticulo As String, ByVal numero As String) As DataTable
        Return oImpresionEtiquetaDG.GetCorridaExistencia(CodArticulo, numero)
    End Function

#End Region

End Class
