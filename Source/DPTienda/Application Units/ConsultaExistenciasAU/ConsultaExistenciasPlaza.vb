Imports DportenisPro.DPTienda.Core

''' <summary>
'''     Proporciona métodos para realizar consultas de existencia de artículos en el inventario 
'''     local de la tienda.
''' </summary>
''' 
Public Class ConsultaExistenciasPlaza
    Inherits ConsultaExistenciasAbstract

    Private oConsultaExisDG As ConsultaExistenciasDataGateway
    Private strPlazaID As String

    Public Sub New(ByVal ApplicationContext As ApplicationContext, ByVal PlazaID As String)
        MyBase.New(ApplicationContext)
        strPlazaID = PlazaID
    End Sub

    ''' <summary>
    '''     Agrega la información de la existencia al ResultadoConsultaExistencias especificado.
    ''' </summary>
    ''' <param name="ArticleID" type="String">
    '''     <para>
    '''         Codigo del Artículo a consultar.
    '''     </para>
    ''' </param>
    ''' <param name="Result" type="ResultadoConsultaExistencias">
    '''     <para>
    '''         Objeto al que se agregará la información.
    '''     </para>
    ''' </param>
    Public Overrides Sub FillDetailData(ByVal ArticleID As String, ByVal AlmacenID As String, ByVal Result As ResultadoConsultaExistencias, Optional BuscaPadre As Boolean = False)

        'TODO: CLM - Utilizar un DataGateway para obtener las existencias locales
        'TODO: CLM - Agregar estos datos a la propiedad Existencias objeto oResult
        oConsultaExisDG = New ConsultaExistenciasDataGateway(Me)
        Result.Existencias = oConsultaExisDG.SelectPlaza(ArticleID, strPlazaID)

    End Sub

End Class

