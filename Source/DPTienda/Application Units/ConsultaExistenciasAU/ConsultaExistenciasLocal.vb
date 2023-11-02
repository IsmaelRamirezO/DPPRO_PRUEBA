Imports DportenisPro.DPTienda.Core

''' <summary>
'''     Proporciona m�todos para realizar consultas de existencia de art�culos en el inventario 
'''     local de la tienda.
''' </summary>
Public Class ConsultaExistenciasLocal
    Inherits ConsultaExistenciasAbstract
    Private oConsultaExisDG As ConsultaExistenciasDataGateway

    Public Sub New(ByVal ApplicationContext As ApplicationContext, ByVal AlmacenID As String)
        MyBase.New(ApplicationContext)
    End Sub

    ''' <summary>
    '''     Agrega la informaci�n de la existencia al ResultadoConsultaExistencias especificado.
    ''' </summary>
    ''' <param name="ArticleID" type="String">
    '''     <para>
    '''         Codigo del Art�culo a consultar.
    '''     </para>
    ''' </param>
    ''' <param name="Result" type="ResultadoConsultaExistencias">
    '''     <para>
    '''         Objeto al que se agregar� la informaci�n.
    '''     </para>
    ''' </param>
    Public Overrides Sub FillDetailData(ByVal ArticleID As String, ByVal AlmacenID As String, ByVal Result As ResultadoConsultaExistencias, Optional BuscaPadre As Boolean = False)
        'TODO: CLM - Utilizar un DataGateway para obtener las existencias locales
        'TODO: CLM - Agregar estos datos a la propiedad Existencias objeto oResult
        oConsultaExisDG = New ConsultaExistenciasDataGateway(Me)
        Result.Existencias = oConsultaExisDG.Select(ArticleID, AlmacenID, BuscaPadre)
    End Sub

End Class
